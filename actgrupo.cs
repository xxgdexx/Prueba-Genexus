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
   public class actgrupo : GXHttpHandler
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"ACTCLACOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAACTCLACOD6X191( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A426ACTClaCod = GetPar( "ACTClaCod");
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A426ACTClaCod) ;
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
            Form.Meta.addItem("description", "Grupo de Activo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = dynACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public actgrupo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actgrupo( IGxContext context )
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
         dynACTClaCod = new GXCombobox();
         cmbACTGrupSts = new GXCombobox();
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
         if ( dynACTClaCod.ItemCount > 0 )
         {
            A426ACTClaCod = dynACTClaCod.getValidValue(A426ACTClaCod);
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynACTClaCod.CurrentValue = StringUtil.RTrim( A426ACTClaCod);
            AssignProp("", false, dynACTClaCod_Internalname, "Values", dynACTClaCod.ToJavascriptSource(), true);
         }
         if ( cmbACTGrupSts.ItemCount > 0 )
         {
            A2197ACTGrupSts = (short)(NumberUtil.Val( cmbACTGrupSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0))), "."));
            AssignAttri("", false, "A2197ACTGrupSts", StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbACTGrupSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0));
            AssignProp("", false, cmbACTGrupSts_Internalname, "Values", cmbACTGrupSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm6X191( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
         /* Control Group */
         GxWebStd.gx_group_start( context, grpGroup1_Internalname, "Grupos", 1, 100, "%", 0, "px", "Group", "", "HLP_ACTGRUPO.htm");
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
         GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage1_Visible, imgImage1_Enabled, "", "Grabar", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"EENTER."+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ACTGRUPO.htm");
         /* Active images/pictures */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "Image";
         StyleString = "";
         sImgUrl = "(none)";
         GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage2_Visible, 1, "", "Salir", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'SALIR\\'."+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ACTGRUPO.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Tipo de Activo", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynACTClaCod, dynACTClaCod_Internalname, StringUtil.RTrim( A426ACTClaCod), 1, dynACTClaCod_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, dynACTClaCod.Enabled, 0, 0, 0, "em", 0, "", "", "Combo150SIG", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,15);\"", "", true, 1, "HLP_ACTGRUPO.htm");
         dynACTClaCod.CurrentValue = StringUtil.RTrim( A426ACTClaCod);
         AssignProp("", false, dynACTClaCod_Internalname, "Values", (string)(dynACTClaCod.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTGrupCod_Internalname, A2103ACTGrupCod, StringUtil.RTrim( context.localUtil.Format( A2103ACTGrupCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTGrupCod_Jsonclick, 0, "AttSIG", "", "", "", "", 1, edtACTGrupCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Grupo", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTGrupDsc_Internalname, A2196ACTGrupDsc, StringUtil.RTrim( context.localUtil.Format( A2196ACTGrupDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTGrupDsc_Jsonclick, 0, "AttSIG", "", "", "", "", 1, edtACTGrupDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Ref. Codigo Activo", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTGrupAbr_Internalname, A2195ACTGrupAbr, StringUtil.RTrim( context.localUtil.Format( A2195ACTGrupAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTGrupAbr_Jsonclick, 0, "AttSIG", "", "", "", "", 1, edtACTGrupAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Estado", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbACTGrupSts, cmbACTGrupSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0)), 1, cmbACTGrupSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbACTGrupSts.Enabled, 0, 0, 0, "em", 0, "", "", "AttSIG", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_ACTGRUPO.htm");
         cmbACTGrupSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0));
         AssignProp("", false, cmbACTGrupSts_Internalname, "Values", (string)(cmbACTGrupSts.ToJavascriptSource()), true);
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
            Z426ACTClaCod = cgiGet( "Z426ACTClaCod");
            Z2103ACTGrupCod = cgiGet( "Z2103ACTGrupCod");
            Z2196ACTGrupDsc = cgiGet( "Z2196ACTGrupDsc");
            Z2195ACTGrupAbr = cgiGet( "Z2195ACTGrupAbr");
            Z2197ACTGrupSts = (short)(context.localUtil.CToN( cgiGet( "Z2197ACTGrupSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            dynACTClaCod.CurrentValue = cgiGet( dynACTClaCod_Internalname);
            A426ACTClaCod = cgiGet( dynACTClaCod_Internalname);
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = cgiGet( edtACTGrupCod_Internalname);
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2196ACTGrupDsc = cgiGet( edtACTGrupDsc_Internalname);
            AssignAttri("", false, "A2196ACTGrupDsc", A2196ACTGrupDsc);
            A2195ACTGrupAbr = cgiGet( edtACTGrupAbr_Internalname);
            AssignAttri("", false, "A2195ACTGrupAbr", A2195ACTGrupAbr);
            cmbACTGrupSts.CurrentValue = cgiGet( cmbACTGrupSts_Internalname);
            A2197ACTGrupSts = (short)(NumberUtil.Val( cgiGet( cmbACTGrupSts_Internalname), "."));
            AssignAttri("", false, "A2197ACTGrupSts", StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0));
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
               A426ACTClaCod = GetPar( "ACTClaCod");
               AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
               A2103ACTGrupCod = GetPar( "ACTGrupCod");
               AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
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
               InitAll6X191( ) ;
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
         DisableAttributes6X191( ) ;
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

      protected void ResetCaption6X0( )
      {
      }

      protected void ZM6X191( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2196ACTGrupDsc = T006X3_A2196ACTGrupDsc[0];
               Z2195ACTGrupAbr = T006X3_A2195ACTGrupAbr[0];
               Z2197ACTGrupSts = T006X3_A2197ACTGrupSts[0];
            }
            else
            {
               Z2196ACTGrupDsc = A2196ACTGrupDsc;
               Z2195ACTGrupAbr = A2195ACTGrupAbr;
               Z2197ACTGrupSts = A2197ACTGrupSts;
            }
         }
         if ( GX_JID == -2 )
         {
            Z2103ACTGrupCod = A2103ACTGrupCod;
            Z2196ACTGrupDsc = A2196ACTGrupDsc;
            Z2195ACTGrupAbr = A2195ACTGrupAbr;
            Z2197ACTGrupSts = A2197ACTGrupSts;
            Z426ACTClaCod = A426ACTClaCod;
         }
      }

      protected void standaloneNotModal( )
      {
         GXAACTCLACOD_html6X191( ) ;
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

      protected void Load6X191( )
      {
         /* Using cursor T006X5 */
         pr_default.execute(3, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound191 = 1;
            A2196ACTGrupDsc = T006X5_A2196ACTGrupDsc[0];
            AssignAttri("", false, "A2196ACTGrupDsc", A2196ACTGrupDsc);
            A2195ACTGrupAbr = T006X5_A2195ACTGrupAbr[0];
            AssignAttri("", false, "A2195ACTGrupAbr", A2195ACTGrupAbr);
            A2197ACTGrupSts = T006X5_A2197ACTGrupSts[0];
            AssignAttri("", false, "A2197ACTGrupSts", StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0));
            ZM6X191( -2) ;
         }
         pr_default.close(3);
         OnLoadActions6X191( ) ;
      }

      protected void OnLoadActions6X191( )
      {
      }

      protected void CheckExtendedTable6X191( )
      {
         nIsDirty_191 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T006X4 */
         pr_default.execute(2, new Object[] {A426ACTClaCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Clase de Activo'.", "ForeignKeyNotFound", 1, "ACTCLACOD");
            AnyError = 1;
            GX_FocusControl = dynACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors6X191( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A426ACTClaCod )
      {
         /* Using cursor T006X6 */
         pr_default.execute(4, new Object[] {A426ACTClaCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Clase de Activo'.", "ForeignKeyNotFound", 1, "ACTCLACOD");
            AnyError = 1;
            GX_FocusControl = dynACTClaCod_Internalname;
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

      protected void GetKey6X191( )
      {
         /* Using cursor T006X7 */
         pr_default.execute(5, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound191 = 1;
         }
         else
         {
            RcdFound191 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006X3 */
         pr_default.execute(1, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6X191( 2) ;
            RcdFound191 = 1;
            A2103ACTGrupCod = T006X3_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2196ACTGrupDsc = T006X3_A2196ACTGrupDsc[0];
            AssignAttri("", false, "A2196ACTGrupDsc", A2196ACTGrupDsc);
            A2195ACTGrupAbr = T006X3_A2195ACTGrupAbr[0];
            AssignAttri("", false, "A2195ACTGrupAbr", A2195ACTGrupAbr);
            A2197ACTGrupSts = T006X3_A2197ACTGrupSts[0];
            AssignAttri("", false, "A2197ACTGrupSts", StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0));
            A426ACTClaCod = T006X3_A426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            Z426ACTClaCod = A426ACTClaCod;
            Z2103ACTGrupCod = A2103ACTGrupCod;
            sMode191 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load6X191( ) ;
            if ( AnyError == 1 )
            {
               RcdFound191 = 0;
               InitializeNonKey6X191( ) ;
            }
            Gx_mode = sMode191;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound191 = 0;
            InitializeNonKey6X191( ) ;
            sMode191 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode191;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6X191( ) ;
         if ( RcdFound191 == 0 )
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
         RcdFound191 = 0;
         /* Using cursor T006X8 */
         pr_default.execute(6, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T006X8_A426ACTClaCod[0], A426ACTClaCod) < 0 ) || ( StringUtil.StrCmp(T006X8_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T006X8_A2103ACTGrupCod[0], A2103ACTGrupCod) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T006X8_A426ACTClaCod[0], A426ACTClaCod) > 0 ) || ( StringUtil.StrCmp(T006X8_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T006X8_A2103ACTGrupCod[0], A2103ACTGrupCod) > 0 ) ) )
            {
               A426ACTClaCod = T006X8_A426ACTClaCod[0];
               AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
               A2103ACTGrupCod = T006X8_A2103ACTGrupCod[0];
               AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
               RcdFound191 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound191 = 0;
         /* Using cursor T006X9 */
         pr_default.execute(7, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T006X9_A426ACTClaCod[0], A426ACTClaCod) > 0 ) || ( StringUtil.StrCmp(T006X9_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T006X9_A2103ACTGrupCod[0], A2103ACTGrupCod) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T006X9_A426ACTClaCod[0], A426ACTClaCod) < 0 ) || ( StringUtil.StrCmp(T006X9_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T006X9_A2103ACTGrupCod[0], A2103ACTGrupCod) < 0 ) ) )
            {
               A426ACTClaCod = T006X9_A426ACTClaCod[0];
               AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
               A2103ACTGrupCod = T006X9_A2103ACTGrupCod[0];
               AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
               RcdFound191 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6X191( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = dynACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6X191( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound191 == 1 )
            {
               if ( ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 ) || ( StringUtil.StrCmp(A2103ACTGrupCod, Z2103ACTGrupCod) != 0 ) )
               {
                  A426ACTClaCod = Z426ACTClaCod;
                  AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
                  A2103ACTGrupCod = Z2103ACTGrupCod;
                  AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ACTCLACOD");
                  AnyError = 1;
                  GX_FocusControl = dynACTClaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = dynACTClaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update6X191( ) ;
                  GX_FocusControl = dynACTClaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 ) || ( StringUtil.StrCmp(A2103ACTGrupCod, Z2103ACTGrupCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = dynACTClaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6X191( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACTCLACOD");
                     AnyError = 1;
                     GX_FocusControl = dynACTClaCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = dynACTClaCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6X191( ) ;
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
         if ( ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 ) || ( StringUtil.StrCmp(A2103ACTGrupCod, Z2103ACTGrupCod) != 0 ) )
         {
            A426ACTClaCod = Z426ACTClaCod;
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = Z2103ACTGrupCod;
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ACTCLACOD");
            AnyError = 1;
            GX_FocusControl = dynACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = dynACTClaCod_Internalname;
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
         if ( RcdFound191 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACTCLACOD");
            AnyError = 1;
            GX_FocusControl = dynACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtACTGrupDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart6X191( ) ;
         if ( RcdFound191 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTGrupDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6X191( ) ;
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
         if ( RcdFound191 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTGrupDsc_Internalname;
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
         if ( RcdFound191 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTGrupDsc_Internalname;
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
         ScanStart6X191( ) ;
         if ( RcdFound191 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound191 != 0 )
            {
               ScanNext6X191( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTGrupDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6X191( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency6X191( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006X2 */
            pr_default.execute(0, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTGRUPO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2196ACTGrupDsc, T006X2_A2196ACTGrupDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z2195ACTGrupAbr, T006X2_A2195ACTGrupAbr[0]) != 0 ) || ( Z2197ACTGrupSts != T006X2_A2197ACTGrupSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z2196ACTGrupDsc, T006X2_A2196ACTGrupDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("actgrupo:[seudo value changed for attri]"+"ACTGrupDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2196ACTGrupDsc);
                  GXUtil.WriteLogRaw("Current: ",T006X2_A2196ACTGrupDsc[0]);
               }
               if ( StringUtil.StrCmp(Z2195ACTGrupAbr, T006X2_A2195ACTGrupAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("actgrupo:[seudo value changed for attri]"+"ACTGrupAbr");
                  GXUtil.WriteLogRaw("Old: ",Z2195ACTGrupAbr);
                  GXUtil.WriteLogRaw("Current: ",T006X2_A2195ACTGrupAbr[0]);
               }
               if ( Z2197ACTGrupSts != T006X2_A2197ACTGrupSts[0] )
               {
                  GXUtil.WriteLog("actgrupo:[seudo value changed for attri]"+"ACTGrupSts");
                  GXUtil.WriteLogRaw("Old: ",Z2197ACTGrupSts);
                  GXUtil.WriteLogRaw("Current: ",T006X2_A2197ACTGrupSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTGRUPO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6X191( )
      {
         BeforeValidate6X191( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6X191( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6X191( 0) ;
            CheckOptimisticConcurrency6X191( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6X191( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6X191( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006X10 */
                     pr_default.execute(8, new Object[] {A2103ACTGrupCod, A2196ACTGrupDsc, A2195ACTGrupAbr, A2197ACTGrupSts, A426ACTClaCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTGRUPO");
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
                           ResetCaption6X0( ) ;
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
               Load6X191( ) ;
            }
            EndLevel6X191( ) ;
         }
         CloseExtendedTableCursors6X191( ) ;
      }

      protected void Update6X191( )
      {
         BeforeValidate6X191( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6X191( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6X191( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6X191( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6X191( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006X11 */
                     pr_default.execute(9, new Object[] {A2196ACTGrupDsc, A2195ACTGrupAbr, A2197ACTGrupSts, A426ACTClaCod, A2103ACTGrupCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTGRUPO");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTGRUPO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6X191( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption6X0( ) ;
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
            EndLevel6X191( ) ;
         }
         CloseExtendedTableCursors6X191( ) ;
      }

      protected void DeferredUpdate6X191( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate6X191( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6X191( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6X191( ) ;
            AfterConfirm6X191( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6X191( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006X12 */
                  pr_default.execute(10, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("ACTGRUPO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound191 == 0 )
                        {
                           InitAll6X191( ) ;
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
                        ResetCaption6X0( ) ;
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
         sMode191 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6X191( ) ;
         Gx_mode = sMode191;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6X191( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T006X13 */
            pr_default.execute(11, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ACTACTIVOS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T006X14 */
            pr_default.execute(12, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sub Grupo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel6X191( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6X191( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("actgrupo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6X0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("actgrupo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6X191( )
      {
         /* Using cursor T006X15 */
         pr_default.execute(13);
         RcdFound191 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound191 = 1;
            A426ACTClaCod = T006X15_A426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = T006X15_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6X191( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound191 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound191 = 1;
            A426ACTClaCod = T006X15_A426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = T006X15_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         }
      }

      protected void ScanEnd6X191( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm6X191( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6X191( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6X191( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6X191( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6X191( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6X191( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6X191( )
      {
         dynACTClaCod.Enabled = 0;
         AssignProp("", false, dynACTClaCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynACTClaCod.Enabled), 5, 0), true);
         edtACTGrupCod_Enabled = 0;
         AssignProp("", false, edtACTGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTGrupCod_Enabled), 5, 0), true);
         edtACTGrupDsc_Enabled = 0;
         AssignProp("", false, edtACTGrupDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTGrupDsc_Enabled), 5, 0), true);
         edtACTGrupAbr_Enabled = 0;
         AssignProp("", false, edtACTGrupAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTGrupAbr_Enabled), 5, 0), true);
         cmbACTGrupSts.Enabled = 0;
         AssignProp("", false, cmbACTGrupSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbACTGrupSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6X191( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6X0( )
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
         context.SendWebValue( "Grupo de Activo") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810265055", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("actgrupo.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z426ACTClaCod", Z426ACTClaCod);
         GxWebStd.gx_hidden_field( context, "Z2103ACTGrupCod", Z2103ACTGrupCod);
         GxWebStd.gx_hidden_field( context, "Z2196ACTGrupDsc", Z2196ACTGrupDsc);
         GxWebStd.gx_hidden_field( context, "Z2195ACTGrupAbr", Z2195ACTGrupAbr);
         GxWebStd.gx_hidden_field( context, "Z2197ACTGrupSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2197ACTGrupSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm6X191( )
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
         return "ACTGRUPO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Grupo de Activo" ;
      }

      protected void InitializeNonKey6X191( )
      {
         A2196ACTGrupDsc = "";
         AssignAttri("", false, "A2196ACTGrupDsc", A2196ACTGrupDsc);
         A2195ACTGrupAbr = "";
         AssignAttri("", false, "A2195ACTGrupAbr", A2195ACTGrupAbr);
         A2197ACTGrupSts = 0;
         AssignAttri("", false, "A2197ACTGrupSts", StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0));
         Z2196ACTGrupDsc = "";
         Z2195ACTGrupAbr = "";
         Z2197ACTGrupSts = 0;
      }

      protected void InitAll6X191( )
      {
         A426ACTClaCod = "";
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         A2103ACTGrupCod = "";
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         InitializeNonKey6X191( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810265059", true, true);
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
         context.AddJavascriptSource("actgrupo.js", "?202281810265060", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         imgImage1_Internalname = "IMAGE1";
         imgImage2_Internalname = "IMAGE2";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         dynACTClaCod_Internalname = "ACTCLACOD";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtACTGrupCod_Internalname = "ACTGRUPCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtACTGrupDsc_Internalname = "ACTGRUPDSC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtACTGrupAbr_Internalname = "ACTGRUPABR";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         cmbACTGrupSts_Internalname = "ACTGRUPSTS";
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
         cmbACTGrupSts_Jsonclick = "";
         cmbACTGrupSts.Enabled = 1;
         edtACTGrupAbr_Jsonclick = "";
         edtACTGrupAbr_Enabled = 1;
         edtACTGrupDsc_Jsonclick = "";
         edtACTGrupDsc_Enabled = 1;
         edtACTGrupCod_Jsonclick = "";
         edtACTGrupCod_Enabled = 1;
         dynACTClaCod_Jsonclick = "";
         dynACTClaCod.Enabled = 1;
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

      protected void GXDLAACTCLACOD6X191( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAACTCLACOD_data6X191( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXAACTCLACOD_html6X191( )
      {
         string gxdynajaxvalue;
         GXDLAACTCLACOD_data6X191( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynACTClaCod.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex));
            dynACTClaCod.addItem(gxdynajaxvalue, ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAACTCLACOD_data6X191( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add("");
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor T006X16 */
         pr_default.execute(14);
         while ( (pr_default.getStatus(14) != 101) )
         {
            gxdynajaxctrlcodr.Add(T006X16_A426ACTClaCod[0]);
            gxdynajaxctrldescr.Add(T006X16_A2184ACTClaDsc[0]);
            pr_default.readNext(14);
         }
         pr_default.close(14);
      }

      protected void init_web_controls( )
      {
         dynACTClaCod.Name = "ACTCLACOD";
         dynACTClaCod.WebTags = "";
         cmbACTGrupSts.Name = "ACTGRUPSTS";
         cmbACTGrupSts.WebTags = "";
         cmbACTGrupSts.addItem("1", "Activo", 0);
         cmbACTGrupSts.addItem("0", "Inactivo", 0);
         if ( cmbACTGrupSts.ItemCount > 0 )
         {
            A2197ACTGrupSts = (short)(NumberUtil.Val( cmbACTGrupSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0))), "."));
            AssignAttri("", false, "A2197ACTGrupSts", StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T006X17 */
         pr_default.execute(15, new Object[] {A426ACTClaCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Clase de Activo'.", "ForeignKeyNotFound", 1, "ACTCLACOD");
            AnyError = 1;
            GX_FocusControl = dynACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtACTGrupDsc_Internalname;
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

      public void Valid_Actclacod( )
      {
         A426ACTClaCod = dynACTClaCod.CurrentValue;
         /* Using cursor T006X18 */
         pr_default.execute(16, new Object[] {A426ACTClaCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Clase de Activo'.", "ForeignKeyNotFound", 1, "ACTCLACOD");
            AnyError = 1;
            GX_FocusControl = dynACTClaCod_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         if ( dynACTClaCod.ItemCount > 0 )
         {
            A426ACTClaCod = dynACTClaCod.getValidValue(A426ACTClaCod);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynACTClaCod.CurrentValue = StringUtil.RTrim( A426ACTClaCod);
         }
         /*  Sending validation outputs */
      }

      public void Valid_Actgrupcod( )
      {
         A2197ACTGrupSts = (short)(NumberUtil.Val( cmbACTGrupSts.CurrentValue, "."));
         cmbACTGrupSts.CurrentValue = StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0);
         A426ACTClaCod = dynACTClaCod.CurrentValue;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( dynACTClaCod.ItemCount > 0 )
         {
            A426ACTClaCod = dynACTClaCod.getValidValue(A426ACTClaCod);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynACTClaCod.CurrentValue = StringUtil.RTrim( A426ACTClaCod);
         }
         if ( cmbACTGrupSts.ItemCount > 0 )
         {
            A2197ACTGrupSts = (short)(NumberUtil.Val( cmbACTGrupSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0))), "."));
            cmbACTGrupSts.CurrentValue = StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbACTGrupSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A2196ACTGrupDsc", A2196ACTGrupDsc);
         AssignAttri("", false, "A2195ACTGrupAbr", A2195ACTGrupAbr);
         AssignAttri("", false, "A2197ACTGrupSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2197ACTGrupSts), 1, 0, ".", "")));
         cmbACTGrupSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2197ACTGrupSts), 1, 0));
         AssignProp("", false, cmbACTGrupSts_Internalname, "Values", cmbACTGrupSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z426ACTClaCod", Z426ACTClaCod);
         GxWebStd.gx_hidden_field( context, "Z2103ACTGrupCod", Z2103ACTGrupCod);
         GxWebStd.gx_hidden_field( context, "Z2196ACTGrupDsc", Z2196ACTGrupDsc);
         GxWebStd.gx_hidden_field( context, "Z2195ACTGrupAbr", Z2195ACTGrupAbr);
         GxWebStd.gx_hidden_field( context, "Z2197ACTGrupSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2197ACTGrupSts), 1, 0, ".", "")));
         AssignProp("", false, imgImage1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgImage1_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''}]}");
         setEventMetadata("VALID_ACTCLACOD","{handler:'Valid_Actclacod',iparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''}]");
         setEventMetadata("VALID_ACTCLACOD",",oparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''}]}");
         setEventMetadata("VALID_ACTGRUPCOD","{handler:'Valid_Actgrupcod',iparms:[{av:'cmbACTGrupSts'},{av:'A2197ACTGrupSts',fld:'ACTGRUPSTS',pic:'9'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''}]");
         setEventMetadata("VALID_ACTGRUPCOD",",oparms:[{av:'A2196ACTGrupDsc',fld:'ACTGRUPDSC',pic:''},{av:'A2195ACTGrupAbr',fld:'ACTGRUPABR',pic:''},{av:'cmbACTGrupSts'},{av:'A2197ACTGrupSts',fld:'ACTGRUPSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z426ACTClaCod'},{av:'Z2103ACTGrupCod'},{av:'Z2196ACTGrupDsc'},{av:'Z2195ACTGrupAbr'},{av:'Z2197ACTGrupSts'},{av:'imgImage1_Enabled',ctrl:'IMAGE1',prop:'Enabled'},{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''}]}");
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
         pr_default.close(16);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z426ACTClaCod = "";
         Z2103ACTGrupCod = "";
         Z2196ACTGrupDsc = "";
         Z2195ACTGrupAbr = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A426ACTClaCod = "";
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
         lblTextblock5_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         A2103ACTGrupCod = "";
         lblTextblock2_Jsonclick = "";
         A2196ACTGrupDsc = "";
         lblTextblock4_Jsonclick = "";
         A2195ACTGrupAbr = "";
         lblTextblock3_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T006X5_A2103ACTGrupCod = new string[] {""} ;
         T006X5_A2196ACTGrupDsc = new string[] {""} ;
         T006X5_A2195ACTGrupAbr = new string[] {""} ;
         T006X5_A2197ACTGrupSts = new short[1] ;
         T006X5_A426ACTClaCod = new string[] {""} ;
         T006X4_A426ACTClaCod = new string[] {""} ;
         T006X6_A426ACTClaCod = new string[] {""} ;
         T006X7_A426ACTClaCod = new string[] {""} ;
         T006X7_A2103ACTGrupCod = new string[] {""} ;
         T006X3_A2103ACTGrupCod = new string[] {""} ;
         T006X3_A2196ACTGrupDsc = new string[] {""} ;
         T006X3_A2195ACTGrupAbr = new string[] {""} ;
         T006X3_A2197ACTGrupSts = new short[1] ;
         T006X3_A426ACTClaCod = new string[] {""} ;
         sMode191 = "";
         T006X8_A426ACTClaCod = new string[] {""} ;
         T006X8_A2103ACTGrupCod = new string[] {""} ;
         T006X9_A426ACTClaCod = new string[] {""} ;
         T006X9_A2103ACTGrupCod = new string[] {""} ;
         T006X2_A2103ACTGrupCod = new string[] {""} ;
         T006X2_A2196ACTGrupDsc = new string[] {""} ;
         T006X2_A2195ACTGrupAbr = new string[] {""} ;
         T006X2_A2197ACTGrupSts = new short[1] ;
         T006X2_A426ACTClaCod = new string[] {""} ;
         T006X13_A2100ACTActCod = new string[] {""} ;
         T006X14_A426ACTClaCod = new string[] {""} ;
         T006X14_A2103ACTGrupCod = new string[] {""} ;
         T006X14_A2114ACTSGrupCod = new string[] {""} ;
         T006X15_A426ACTClaCod = new string[] {""} ;
         T006X15_A2103ACTGrupCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T006X16_A426ACTClaCod = new string[] {""} ;
         T006X16_A2184ACTClaDsc = new string[] {""} ;
         T006X16_A2185ACTClaSts = new short[1] ;
         T006X17_A426ACTClaCod = new string[] {""} ;
         T006X18_A426ACTClaCod = new string[] {""} ;
         ZZ426ACTClaCod = "";
         ZZ2103ACTGrupCod = "";
         ZZ2196ACTGrupDsc = "";
         ZZ2195ACTGrupAbr = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actgrupo__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actgrupo__default(),
            new Object[][] {
                new Object[] {
               T006X2_A2103ACTGrupCod, T006X2_A2196ACTGrupDsc, T006X2_A2195ACTGrupAbr, T006X2_A2197ACTGrupSts, T006X2_A426ACTClaCod
               }
               , new Object[] {
               T006X3_A2103ACTGrupCod, T006X3_A2196ACTGrupDsc, T006X3_A2195ACTGrupAbr, T006X3_A2197ACTGrupSts, T006X3_A426ACTClaCod
               }
               , new Object[] {
               T006X4_A426ACTClaCod
               }
               , new Object[] {
               T006X5_A2103ACTGrupCod, T006X5_A2196ACTGrupDsc, T006X5_A2195ACTGrupAbr, T006X5_A2197ACTGrupSts, T006X5_A426ACTClaCod
               }
               , new Object[] {
               T006X6_A426ACTClaCod
               }
               , new Object[] {
               T006X7_A426ACTClaCod, T006X7_A2103ACTGrupCod
               }
               , new Object[] {
               T006X8_A426ACTClaCod, T006X8_A2103ACTGrupCod
               }
               , new Object[] {
               T006X9_A426ACTClaCod, T006X9_A2103ACTGrupCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006X13_A2100ACTActCod
               }
               , new Object[] {
               T006X14_A426ACTClaCod, T006X14_A2103ACTGrupCod, T006X14_A2114ACTSGrupCod
               }
               , new Object[] {
               T006X15_A426ACTClaCod, T006X15_A2103ACTGrupCod
               }
               , new Object[] {
               T006X16_A426ACTClaCod, T006X16_A2184ACTClaDsc, T006X16_A2185ACTClaSts
               }
               , new Object[] {
               T006X17_A426ACTClaCod
               }
               , new Object[] {
               T006X18_A426ACTClaCod
               }
            }
         );
      }

      private short Z2197ACTGrupSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A2197ACTGrupSts ;
      private short GX_JID ;
      private short RcdFound191 ;
      private short nIsDirty_191 ;
      private short Gx_BScreen ;
      private short ZZ2197ACTGrupSts ;
      private int trnEnded ;
      private int imgImage1_Visible ;
      private int imgImage1_Enabled ;
      private int imgImage2_Visible ;
      private int edtACTGrupCod_Enabled ;
      private int edtACTGrupDsc_Enabled ;
      private int edtACTGrupAbr_Enabled ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string dynACTClaCod_Internalname ;
      private string cmbACTGrupSts_Internalname ;
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
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string dynACTClaCod_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string edtACTGrupCod_Internalname ;
      private string edtACTGrupCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtACTGrupDsc_Internalname ;
      private string edtACTGrupDsc_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtACTGrupAbr_Internalname ;
      private string edtACTGrupAbr_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string cmbACTGrupSts_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode191 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private string Z426ACTClaCod ;
      private string Z2103ACTGrupCod ;
      private string Z2196ACTGrupDsc ;
      private string Z2195ACTGrupAbr ;
      private string A426ACTClaCod ;
      private string A2103ACTGrupCod ;
      private string A2196ACTGrupDsc ;
      private string A2195ACTGrupAbr ;
      private string ZZ426ACTClaCod ;
      private string ZZ2103ACTGrupCod ;
      private string ZZ2196ACTGrupDsc ;
      private string ZZ2195ACTGrupAbr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynACTClaCod ;
      private GXCombobox cmbACTGrupSts ;
      private IDataStoreProvider pr_default ;
      private string[] T006X5_A2103ACTGrupCod ;
      private string[] T006X5_A2196ACTGrupDsc ;
      private string[] T006X5_A2195ACTGrupAbr ;
      private short[] T006X5_A2197ACTGrupSts ;
      private string[] T006X5_A426ACTClaCod ;
      private string[] T006X4_A426ACTClaCod ;
      private string[] T006X6_A426ACTClaCod ;
      private string[] T006X7_A426ACTClaCod ;
      private string[] T006X7_A2103ACTGrupCod ;
      private string[] T006X3_A2103ACTGrupCod ;
      private string[] T006X3_A2196ACTGrupDsc ;
      private string[] T006X3_A2195ACTGrupAbr ;
      private short[] T006X3_A2197ACTGrupSts ;
      private string[] T006X3_A426ACTClaCod ;
      private string[] T006X8_A426ACTClaCod ;
      private string[] T006X8_A2103ACTGrupCod ;
      private string[] T006X9_A426ACTClaCod ;
      private string[] T006X9_A2103ACTGrupCod ;
      private string[] T006X2_A2103ACTGrupCod ;
      private string[] T006X2_A2196ACTGrupDsc ;
      private string[] T006X2_A2195ACTGrupAbr ;
      private short[] T006X2_A2197ACTGrupSts ;
      private string[] T006X2_A426ACTClaCod ;
      private string[] T006X13_A2100ACTActCod ;
      private string[] T006X14_A426ACTClaCod ;
      private string[] T006X14_A2103ACTGrupCod ;
      private string[] T006X14_A2114ACTSGrupCod ;
      private string[] T006X15_A426ACTClaCod ;
      private string[] T006X15_A2103ACTGrupCod ;
      private string[] T006X16_A426ACTClaCod ;
      private string[] T006X16_A2184ACTClaDsc ;
      private short[] T006X16_A2185ACTClaSts ;
      private string[] T006X17_A426ACTClaCod ;
      private string[] T006X18_A426ACTClaCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class actgrupo__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actgrupo__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT006X5;
        prmT006X5 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006X4;
        prmT006X4 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006X6;
        prmT006X6 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006X7;
        prmT006X7 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006X3;
        prmT006X3 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006X8;
        prmT006X8 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006X9;
        prmT006X9 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006X2;
        prmT006X2 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006X10;
        prmT006X10 = new Object[] {
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupDsc",GXType.NVarChar,100,0) ,
        new ParDef("@ACTGrupAbr",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupSts",GXType.Int16,1,0) ,
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006X11;
        prmT006X11 = new Object[] {
        new ParDef("@ACTGrupDsc",GXType.NVarChar,100,0) ,
        new ParDef("@ACTGrupAbr",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupSts",GXType.Int16,1,0) ,
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006X12;
        prmT006X12 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006X13;
        prmT006X13 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006X14;
        prmT006X14 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006X15;
        prmT006X15 = new Object[] {
        };
        Object[] prmT006X16;
        prmT006X16 = new Object[] {
        };
        Object[] prmT006X17;
        prmT006X17 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006X18;
        prmT006X18 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0)
        };
        def= new CursorDef[] {
            new CursorDef("T006X2", "SELECT [ACTGrupCod], [ACTGrupDsc], [ACTGrupAbr], [ACTGrupSts], [ACTClaCod] FROM [ACTGRUPO] WITH (UPDLOCK) WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006X2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006X3", "SELECT [ACTGrupCod], [ACTGrupDsc], [ACTGrupAbr], [ACTGrupSts], [ACTClaCod] FROM [ACTGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006X3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006X4", "SELECT [ACTClaCod] FROM [ACTCLASE] WHERE [ACTClaCod] = @ACTClaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006X4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006X5", "SELECT TM1.[ACTGrupCod], TM1.[ACTGrupDsc], TM1.[ACTGrupAbr], TM1.[ACTGrupSts], TM1.[ACTClaCod] FROM [ACTGRUPO] TM1 WHERE TM1.[ACTClaCod] = @ACTClaCod and TM1.[ACTGrupCod] = @ACTGrupCod ORDER BY TM1.[ACTClaCod], TM1.[ACTGrupCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006X5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006X6", "SELECT [ACTClaCod] FROM [ACTCLASE] WHERE [ACTClaCod] = @ACTClaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006X6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006X7", "SELECT [ACTClaCod], [ACTGrupCod] FROM [ACTGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006X7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006X8", "SELECT TOP 1 [ACTClaCod], [ACTGrupCod] FROM [ACTGRUPO] WHERE ( [ACTClaCod] > @ACTClaCod or [ACTClaCod] = @ACTClaCod and [ACTGrupCod] > @ACTGrupCod) ORDER BY [ACTClaCod], [ACTGrupCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006X8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006X9", "SELECT TOP 1 [ACTClaCod], [ACTGrupCod] FROM [ACTGRUPO] WHERE ( [ACTClaCod] < @ACTClaCod or [ACTClaCod] = @ACTClaCod and [ACTGrupCod] < @ACTGrupCod) ORDER BY [ACTClaCod] DESC, [ACTGrupCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006X9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006X10", "INSERT INTO [ACTGRUPO]([ACTGrupCod], [ACTGrupDsc], [ACTGrupAbr], [ACTGrupSts], [ACTClaCod]) VALUES(@ACTGrupCod, @ACTGrupDsc, @ACTGrupAbr, @ACTGrupSts, @ACTClaCod)", GxErrorMask.GX_NOMASK,prmT006X10)
           ,new CursorDef("T006X11", "UPDATE [ACTGRUPO] SET [ACTGrupDsc]=@ACTGrupDsc, [ACTGrupAbr]=@ACTGrupAbr, [ACTGrupSts]=@ACTGrupSts  WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod", GxErrorMask.GX_NOMASK,prmT006X11)
           ,new CursorDef("T006X12", "DELETE FROM [ACTGRUPO]  WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod", GxErrorMask.GX_NOMASK,prmT006X12)
           ,new CursorDef("T006X13", "SELECT TOP 1 [ACTActCod] FROM [ACTACTIVOS] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006X13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006X14", "SELECT TOP 1 [ACTClaCod], [ACTGrupCod], [ACTSGrupCod] FROM [ACTSUBGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006X14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006X15", "SELECT [ACTClaCod], [ACTGrupCod] FROM [ACTGRUPO] ORDER BY [ACTClaCod], [ACTGrupCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006X15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006X16", "SELECT [ACTClaCod], [ACTClaDsc], [ACTClaSts] FROM [ACTCLASE] WHERE [ACTClaSts] = 1 ORDER BY [ACTClaDsc] ",true, GxErrorMask.GX_NOMASK, false, this,prmT006X16,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006X17", "SELECT [ACTClaCod] FROM [ACTCLASE] WHERE [ACTClaCod] = @ACTClaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006X17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006X18", "SELECT [ACTClaCod] FROM [ACTCLASE] WHERE [ACTClaCod] = @ACTClaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006X18,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
