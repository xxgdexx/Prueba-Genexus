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
   public class actclase : GXHttpHandler
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"TIPACOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLATIPACOD6V189( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A70TipACod = (int)(NumberUtil.Val( GetPar( "TipACod"), "."));
            n70TipACod = false;
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A70TipACod) ;
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
            Form.Meta.addItem("description", "Tipos de Activos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public actclase( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actclase( IGxContext context )
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
         dynTipACod = new GXCombobox();
         cmbACTClaSts = new GXCombobox();
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
         if ( dynTipACod.ItemCount > 0 )
         {
            A70TipACod = (int)(NumberUtil.Val( dynTipACod.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A70TipACod), 6, 0))), "."));
            n70TipACod = false;
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTipACod.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A70TipACod), 6, 0));
            AssignProp("", false, dynTipACod_Internalname, "Values", dynTipACod.ToJavascriptSource(), true);
         }
         if ( cmbACTClaSts.ItemCount > 0 )
         {
            A2185ACTClaSts = (short)(NumberUtil.Val( cmbACTClaSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0))), "."));
            AssignAttri("", false, "A2185ACTClaSts", StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbACTClaSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0));
            AssignProp("", false, cmbACTClaSts_Internalname, "Values", cmbACTClaSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm6V189( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
         /* Control Group */
         GxWebStd.gx_group_start( context, grpGroup1_Internalname, "Tipo de Activo", 1, 100, "%", 0, "px", "Group", "", "HLP_ACTCLASE.htm");
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
         GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage1_Visible, imgImage1_Enabled, "", "Grabar", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"EENTER."+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ACTCLASE.htm");
         /* Active images/pictures */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "Image";
         StyleString = "";
         sImgUrl = "(none)";
         GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage2_Visible, 1, "", "Salir", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'SALIR\\'."+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ACTCLASE.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTCLASE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTClaCod_Internalname, A426ACTClaCod, StringUtil.RTrim( context.localUtil.Format( A426ACTClaCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,15);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTClaCod_Jsonclick, 0, "AttSIG", "", "", "", "", 1, edtACTClaCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTCLASE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Tipo Activo", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTCLASE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTClaDsc_Internalname, A2184ACTClaDsc, StringUtil.RTrim( context.localUtil.Format( A2184ACTClaDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTClaDsc_Jsonclick, 0, "AttSIG", "", "", "", "", 1, edtACTClaDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTCLASE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Tipo de Auxiliar", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTCLASE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynTipACod, dynTipACod_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A70TipACod), 6, 0)), 1, dynTipACod_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynTipACod.Enabled, 0, 0, 0, "em", 0, "", "", "Combo150SIG", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "", true, 1, "HLP_ACTCLASE.htm");
         dynTipACod.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A70TipACod), 6, 0));
         AssignProp("", false, dynTipACod_Internalname, "Values", (string)(dynTipACod.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Estado", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTCLASE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbACTClaSts, cmbACTClaSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0)), 1, cmbACTClaSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbACTClaSts.Enabled, 0, 0, 0, "em", 0, "", "", "AttSIG", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 1, "HLP_ACTCLASE.htm");
         cmbACTClaSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0));
         AssignProp("", false, cmbACTClaSts_Internalname, "Values", (string)(cmbACTClaSts.ToJavascriptSource()), true);
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
            Z2184ACTClaDsc = cgiGet( "Z2184ACTClaDsc");
            Z2185ACTClaSts = (short)(context.localUtil.CToN( cgiGet( "Z2185ACTClaSts"), ".", ","));
            Z70TipACod = (int)(context.localUtil.CToN( cgiGet( "Z70TipACod"), ".", ","));
            n70TipACod = ((0==A70TipACod) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A426ACTClaCod = cgiGet( edtACTClaCod_Internalname);
            n426ACTClaCod = false;
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2184ACTClaDsc = cgiGet( edtACTClaDsc_Internalname);
            AssignAttri("", false, "A2184ACTClaDsc", A2184ACTClaDsc);
            dynTipACod.CurrentValue = cgiGet( dynTipACod_Internalname);
            A70TipACod = (int)(NumberUtil.Val( cgiGet( dynTipACod_Internalname), "."));
            n70TipACod = false;
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            n70TipACod = ((0==A70TipACod) ? true : false);
            cmbACTClaSts.CurrentValue = cgiGet( cmbACTClaSts_Internalname);
            A2185ACTClaSts = (short)(NumberUtil.Val( cgiGet( cmbACTClaSts_Internalname), "."));
            AssignAttri("", false, "A2185ACTClaSts", StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0));
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
               n426ACTClaCod = false;
               AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
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
               InitAll6V189( ) ;
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
         DisableAttributes6V189( ) ;
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

      protected void ResetCaption6V0( )
      {
      }

      protected void ZM6V189( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2184ACTClaDsc = T006V3_A2184ACTClaDsc[0];
               Z2185ACTClaSts = T006V3_A2185ACTClaSts[0];
               Z70TipACod = T006V3_A70TipACod[0];
            }
            else
            {
               Z2184ACTClaDsc = A2184ACTClaDsc;
               Z2185ACTClaSts = A2185ACTClaSts;
               Z70TipACod = A70TipACod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z426ACTClaCod = A426ACTClaCod;
            Z2184ACTClaDsc = A2184ACTClaDsc;
            Z2185ACTClaSts = A2185ACTClaSts;
            Z70TipACod = A70TipACod;
         }
      }

      protected void standaloneNotModal( )
      {
         GXATIPACOD_html6V189( ) ;
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

      protected void Load6V189( )
      {
         /* Using cursor T006V5 */
         pr_default.execute(3, new Object[] {n426ACTClaCod, A426ACTClaCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound189 = 1;
            A2184ACTClaDsc = T006V5_A2184ACTClaDsc[0];
            AssignAttri("", false, "A2184ACTClaDsc", A2184ACTClaDsc);
            A2185ACTClaSts = T006V5_A2185ACTClaSts[0];
            AssignAttri("", false, "A2185ACTClaSts", StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0));
            A70TipACod = T006V5_A70TipACod[0];
            n70TipACod = T006V5_n70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            ZM6V189( -2) ;
         }
         pr_default.close(3);
         OnLoadActions6V189( ) ;
      }

      protected void OnLoadActions6V189( )
      {
      }

      protected void CheckExtendedTable6V189( )
      {
         nIsDirty_189 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T006V4 */
         pr_default.execute(2, new Object[] {n70TipACod, A70TipACod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A70TipACod) ) )
            {
               GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
               AnyError = 1;
               GX_FocusControl = dynTipACod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors6V189( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A70TipACod )
      {
         /* Using cursor T006V6 */
         pr_default.execute(4, new Object[] {n70TipACod, A70TipACod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A70TipACod) ) )
            {
               GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
               AnyError = 1;
               GX_FocusControl = dynTipACod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void GetKey6V189( )
      {
         /* Using cursor T006V7 */
         pr_default.execute(5, new Object[] {n426ACTClaCod, A426ACTClaCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound189 = 1;
         }
         else
         {
            RcdFound189 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006V3 */
         pr_default.execute(1, new Object[] {n426ACTClaCod, A426ACTClaCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6V189( 2) ;
            RcdFound189 = 1;
            A426ACTClaCod = T006V3_A426ACTClaCod[0];
            n426ACTClaCod = T006V3_n426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2184ACTClaDsc = T006V3_A2184ACTClaDsc[0];
            AssignAttri("", false, "A2184ACTClaDsc", A2184ACTClaDsc);
            A2185ACTClaSts = T006V3_A2185ACTClaSts[0];
            AssignAttri("", false, "A2185ACTClaSts", StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0));
            A70TipACod = T006V3_A70TipACod[0];
            n70TipACod = T006V3_n70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            Z426ACTClaCod = A426ACTClaCod;
            sMode189 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load6V189( ) ;
            if ( AnyError == 1 )
            {
               RcdFound189 = 0;
               InitializeNonKey6V189( ) ;
            }
            Gx_mode = sMode189;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound189 = 0;
            InitializeNonKey6V189( ) ;
            sMode189 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode189;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6V189( ) ;
         if ( RcdFound189 == 0 )
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
         RcdFound189 = 0;
         /* Using cursor T006V8 */
         pr_default.execute(6, new Object[] {n426ACTClaCod, A426ACTClaCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T006V8_A426ACTClaCod[0], A426ACTClaCod) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T006V8_A426ACTClaCod[0], A426ACTClaCod) > 0 ) ) )
            {
               A426ACTClaCod = T006V8_A426ACTClaCod[0];
               n426ACTClaCod = T006V8_n426ACTClaCod[0];
               AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
               RcdFound189 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound189 = 0;
         /* Using cursor T006V9 */
         pr_default.execute(7, new Object[] {n426ACTClaCod, A426ACTClaCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T006V9_A426ACTClaCod[0], A426ACTClaCod) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T006V9_A426ACTClaCod[0], A426ACTClaCod) < 0 ) ) )
            {
               A426ACTClaCod = T006V9_A426ACTClaCod[0];
               n426ACTClaCod = T006V9_n426ACTClaCod[0];
               AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
               RcdFound189 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6V189( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6V189( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound189 == 1 )
            {
               if ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 )
               {
                  A426ACTClaCod = Z426ACTClaCod;
                  n426ACTClaCod = false;
                  AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ACTCLACOD");
                  AnyError = 1;
                  GX_FocusControl = edtACTClaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtACTClaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update6V189( ) ;
                  GX_FocusControl = edtACTClaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtACTClaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6V189( ) ;
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
                     GX_FocusControl = edtACTClaCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtACTClaCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6V189( ) ;
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
         if ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 )
         {
            A426ACTClaCod = Z426ACTClaCod;
            n426ACTClaCod = false;
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ACTCLACOD");
            AnyError = 1;
            GX_FocusControl = edtACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtACTClaCod_Internalname;
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
         if ( RcdFound189 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACTCLACOD");
            AnyError = 1;
            GX_FocusControl = edtACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtACTClaDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart6V189( ) ;
         if ( RcdFound189 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTClaDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6V189( ) ;
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
         if ( RcdFound189 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTClaDsc_Internalname;
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
         if ( RcdFound189 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTClaDsc_Internalname;
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
         ScanStart6V189( ) ;
         if ( RcdFound189 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound189 != 0 )
            {
               ScanNext6V189( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTClaDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6V189( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency6V189( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006V2 */
            pr_default.execute(0, new Object[] {n426ACTClaCod, A426ACTClaCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTCLASE"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2184ACTClaDsc, T006V2_A2184ACTClaDsc[0]) != 0 ) || ( Z2185ACTClaSts != T006V2_A2185ACTClaSts[0] ) || ( Z70TipACod != T006V2_A70TipACod[0] ) )
            {
               if ( StringUtil.StrCmp(Z2184ACTClaDsc, T006V2_A2184ACTClaDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("actclase:[seudo value changed for attri]"+"ACTClaDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2184ACTClaDsc);
                  GXUtil.WriteLogRaw("Current: ",T006V2_A2184ACTClaDsc[0]);
               }
               if ( Z2185ACTClaSts != T006V2_A2185ACTClaSts[0] )
               {
                  GXUtil.WriteLog("actclase:[seudo value changed for attri]"+"ACTClaSts");
                  GXUtil.WriteLogRaw("Old: ",Z2185ACTClaSts);
                  GXUtil.WriteLogRaw("Current: ",T006V2_A2185ACTClaSts[0]);
               }
               if ( Z70TipACod != T006V2_A70TipACod[0] )
               {
                  GXUtil.WriteLog("actclase:[seudo value changed for attri]"+"TipACod");
                  GXUtil.WriteLogRaw("Old: ",Z70TipACod);
                  GXUtil.WriteLogRaw("Current: ",T006V2_A70TipACod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTCLASE"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6V189( )
      {
         BeforeValidate6V189( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6V189( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6V189( 0) ;
            CheckOptimisticConcurrency6V189( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6V189( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6V189( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006V10 */
                     pr_default.execute(8, new Object[] {n426ACTClaCod, A426ACTClaCod, A2184ACTClaDsc, A2185ACTClaSts, n70TipACod, A70TipACod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTCLASE");
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
                           ResetCaption6V0( ) ;
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
               Load6V189( ) ;
            }
            EndLevel6V189( ) ;
         }
         CloseExtendedTableCursors6V189( ) ;
      }

      protected void Update6V189( )
      {
         BeforeValidate6V189( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6V189( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6V189( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6V189( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6V189( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006V11 */
                     pr_default.execute(9, new Object[] {A2184ACTClaDsc, A2185ACTClaSts, n70TipACod, A70TipACod, n426ACTClaCod, A426ACTClaCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTCLASE");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTCLASE"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6V189( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption6V0( ) ;
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
            EndLevel6V189( ) ;
         }
         CloseExtendedTableCursors6V189( ) ;
      }

      protected void DeferredUpdate6V189( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate6V189( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6V189( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6V189( ) ;
            AfterConfirm6V189( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6V189( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006V12 */
                  pr_default.execute(10, new Object[] {n426ACTClaCod, A426ACTClaCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("ACTCLASE");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound189 == 0 )
                        {
                           InitAll6V189( ) ;
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
                        ResetCaption6V0( ) ;
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
         sMode189 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6V189( ) ;
         Gx_mode = sMode189;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6V189( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T006V13 */
            pr_default.execute(11, new Object[] {n426ACTClaCod, A426ACTClaCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Activo Fijo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T006V14 */
            pr_default.execute(12, new Object[] {n426ACTClaCod, A426ACTClaCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Grupo de Activo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel6V189( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6V189( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("actclase",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6V0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("actclase",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6V189( )
      {
         /* Using cursor T006V15 */
         pr_default.execute(13);
         RcdFound189 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound189 = 1;
            A426ACTClaCod = T006V15_A426ACTClaCod[0];
            n426ACTClaCod = T006V15_n426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6V189( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound189 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound189 = 1;
            A426ACTClaCod = T006V15_A426ACTClaCod[0];
            n426ACTClaCod = T006V15_n426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         }
      }

      protected void ScanEnd6V189( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm6V189( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6V189( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6V189( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6V189( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6V189( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6V189( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6V189( )
      {
         edtACTClaCod_Enabled = 0;
         AssignProp("", false, edtACTClaCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTClaCod_Enabled), 5, 0), true);
         edtACTClaDsc_Enabled = 0;
         AssignProp("", false, edtACTClaDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTClaDsc_Enabled), 5, 0), true);
         dynTipACod.Enabled = 0;
         AssignProp("", false, dynTipACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTipACod.Enabled), 5, 0), true);
         cmbACTClaSts.Enabled = 0;
         AssignProp("", false, cmbACTClaSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbACTClaSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6V189( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6V0( )
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
         context.SendWebValue( "Tipos de Activos") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810264828", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("actclase.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2184ACTClaDsc", Z2184ACTClaDsc);
         GxWebStd.gx_hidden_field( context, "Z2185ACTClaSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2185ACTClaSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z70TipACod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm6V189( )
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
         return "ACTCLASE" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipos de Activos" ;
      }

      protected void InitializeNonKey6V189( )
      {
         A2184ACTClaDsc = "";
         AssignAttri("", false, "A2184ACTClaDsc", A2184ACTClaDsc);
         A70TipACod = 0;
         n70TipACod = false;
         AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
         n70TipACod = ((0==A70TipACod) ? true : false);
         A2185ACTClaSts = 0;
         AssignAttri("", false, "A2185ACTClaSts", StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0));
         Z2184ACTClaDsc = "";
         Z2185ACTClaSts = 0;
         Z70TipACod = 0;
      }

      protected void InitAll6V189( )
      {
         A426ACTClaCod = "";
         n426ACTClaCod = false;
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         InitializeNonKey6V189( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810264833", true, true);
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
         context.AddJavascriptSource("actclase.js", "?202281810264833", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         imgImage1_Internalname = "IMAGE1";
         imgImage2_Internalname = "IMAGE2";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtACTClaCod_Internalname = "ACTCLACOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtACTClaDsc_Internalname = "ACTCLADSC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         dynTipACod_Internalname = "TIPACOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         cmbACTClaSts_Internalname = "ACTCLASTS";
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
         cmbACTClaSts_Jsonclick = "";
         cmbACTClaSts.Enabled = 1;
         dynTipACod_Jsonclick = "";
         dynTipACod.Enabled = 1;
         edtACTClaDsc_Jsonclick = "";
         edtACTClaDsc_Enabled = 1;
         edtACTClaCod_Jsonclick = "";
         edtACTClaCod_Enabled = 1;
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

      protected void GXDLATIPACOD6V189( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLATIPACOD_data6V189( ) ;
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

      protected void GXATIPACOD_html6V189( )
      {
         int gxdynajaxvalue;
         GXDLATIPACOD_data6V189( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynTipACod.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynTipACod.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLATIPACOD_data6V189( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor T006V16 */
         pr_default.execute(14);
         while ( (pr_default.getStatus(14) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T006V16_A70TipACod[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T006V16_A1900TipADsc[0]));
            pr_default.readNext(14);
         }
         pr_default.close(14);
      }

      protected void init_web_controls( )
      {
         dynTipACod.Name = "TIPACOD";
         dynTipACod.WebTags = "";
         cmbACTClaSts.Name = "ACTCLASTS";
         cmbACTClaSts.WebTags = "";
         cmbACTClaSts.addItem("1", "Activo", 0);
         cmbACTClaSts.addItem("0", "Inactivo", 0);
         if ( cmbACTClaSts.ItemCount > 0 )
         {
            A2185ACTClaSts = (short)(NumberUtil.Val( cmbACTClaSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0))), "."));
            AssignAttri("", false, "A2185ACTClaSts", StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtACTClaDsc_Internalname;
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
         A2185ACTClaSts = (short)(NumberUtil.Val( cmbACTClaSts.CurrentValue, "."));
         cmbACTClaSts.CurrentValue = StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0);
         n426ACTClaCod = false;
         n70TipACod = false;
         A70TipACod = (int)(NumberUtil.Val( dynTipACod.CurrentValue, "."));
         n70TipACod = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( dynTipACod.ItemCount > 0 )
         {
            A70TipACod = (int)(NumberUtil.Val( dynTipACod.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A70TipACod), 6, 0))), "."));
            n70TipACod = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTipACod.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A70TipACod), 6, 0));
         }
         if ( cmbACTClaSts.ItemCount > 0 )
         {
            A2185ACTClaSts = (short)(NumberUtil.Val( cmbACTClaSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0))), "."));
            cmbACTClaSts.CurrentValue = StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbACTClaSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A2184ACTClaDsc", A2184ACTClaDsc);
         AssignAttri("", false, "A70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")));
         dynTipACod.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A70TipACod), 6, 0));
         AssignProp("", false, dynTipACod_Internalname, "Values", dynTipACod.ToJavascriptSource(), true);
         AssignAttri("", false, "A2185ACTClaSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2185ACTClaSts), 1, 0, ".", "")));
         cmbACTClaSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2185ACTClaSts), 1, 0));
         AssignProp("", false, cmbACTClaSts_Internalname, "Values", cmbACTClaSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z426ACTClaCod", Z426ACTClaCod);
         GxWebStd.gx_hidden_field( context, "Z2184ACTClaDsc", Z2184ACTClaDsc);
         GxWebStd.gx_hidden_field( context, "Z70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z70TipACod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2185ACTClaSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2185ACTClaSts), 1, 0, ".", "")));
         AssignProp("", false, imgImage1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgImage1_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Tipacod( )
      {
         n70TipACod = false;
         A70TipACod = (int)(NumberUtil.Val( dynTipACod.CurrentValue, "."));
         n70TipACod = false;
         /* Using cursor T006V17 */
         pr_default.execute(15, new Object[] {n70TipACod, A70TipACod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A70TipACod) ) )
            {
               GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
               AnyError = 1;
               GX_FocusControl = dynTipACod_Internalname;
            }
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'dynTipACod'},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynTipACod'},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'dynTipACod'},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynTipACod'},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_ACTCLACOD","{handler:'Valid_Actclacod',iparms:[{av:'cmbACTClaSts'},{av:'A2185ACTClaSts',fld:'ACTCLASTS',pic:'9'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'dynTipACod'},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_ACTCLACOD",",oparms:[{av:'A2184ACTClaDsc',fld:'ACTCLADSC',pic:''},{av:'cmbACTClaSts'},{av:'A2185ACTClaSts',fld:'ACTCLASTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z426ACTClaCod'},{av:'Z2184ACTClaDsc'},{av:'Z70TipACod'},{av:'Z2185ACTClaSts'},{av:'imgImage1_Enabled',ctrl:'IMAGE1',prop:'Enabled'},{av:'dynTipACod'},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_TIPACOD","{handler:'Valid_Tipacod',iparms:[{av:'dynTipACod'},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TIPACOD",",oparms:[{av:'dynTipACod'},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]}");
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
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z426ACTClaCod = "";
         Z2184ACTClaDsc = "";
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
         A426ACTClaCod = "";
         lblTextblock2_Jsonclick = "";
         A2184ACTClaDsc = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T006V5_A426ACTClaCod = new string[] {""} ;
         T006V5_n426ACTClaCod = new bool[] {false} ;
         T006V5_A2184ACTClaDsc = new string[] {""} ;
         T006V5_A2185ACTClaSts = new short[1] ;
         T006V5_A70TipACod = new int[1] ;
         T006V5_n70TipACod = new bool[] {false} ;
         T006V4_A70TipACod = new int[1] ;
         T006V4_n70TipACod = new bool[] {false} ;
         T006V6_A70TipACod = new int[1] ;
         T006V6_n70TipACod = new bool[] {false} ;
         T006V7_A426ACTClaCod = new string[] {""} ;
         T006V7_n426ACTClaCod = new bool[] {false} ;
         T006V3_A426ACTClaCod = new string[] {""} ;
         T006V3_n426ACTClaCod = new bool[] {false} ;
         T006V3_A2184ACTClaDsc = new string[] {""} ;
         T006V3_A2185ACTClaSts = new short[1] ;
         T006V3_A70TipACod = new int[1] ;
         T006V3_n70TipACod = new bool[] {false} ;
         sMode189 = "";
         T006V8_A426ACTClaCod = new string[] {""} ;
         T006V8_n426ACTClaCod = new bool[] {false} ;
         T006V9_A426ACTClaCod = new string[] {""} ;
         T006V9_n426ACTClaCod = new bool[] {false} ;
         T006V2_A426ACTClaCod = new string[] {""} ;
         T006V2_n426ACTClaCod = new bool[] {false} ;
         T006V2_A2184ACTClaDsc = new string[] {""} ;
         T006V2_A2185ACTClaSts = new short[1] ;
         T006V2_A70TipACod = new int[1] ;
         T006V2_n70TipACod = new bool[] {false} ;
         T006V13_A83ParTip = new string[] {""} ;
         T006V13_A84ParCod = new int[1] ;
         T006V13_A85ParDActItem = new int[1] ;
         T006V14_A426ACTClaCod = new string[] {""} ;
         T006V14_n426ACTClaCod = new bool[] {false} ;
         T006V14_A2103ACTGrupCod = new string[] {""} ;
         T006V15_A426ACTClaCod = new string[] {""} ;
         T006V15_n426ACTClaCod = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T006V16_A70TipACod = new int[1] ;
         T006V16_n70TipACod = new bool[] {false} ;
         T006V16_A1900TipADsc = new string[] {""} ;
         T006V16_A1902TipASts = new short[1] ;
         ZZ426ACTClaCod = "";
         ZZ2184ACTClaDsc = "";
         T006V17_A70TipACod = new int[1] ;
         T006V17_n70TipACod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actclase__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actclase__default(),
            new Object[][] {
                new Object[] {
               T006V2_A426ACTClaCod, T006V2_A2184ACTClaDsc, T006V2_A2185ACTClaSts, T006V2_A70TipACod, T006V2_n70TipACod
               }
               , new Object[] {
               T006V3_A426ACTClaCod, T006V3_A2184ACTClaDsc, T006V3_A2185ACTClaSts, T006V3_A70TipACod, T006V3_n70TipACod
               }
               , new Object[] {
               T006V4_A70TipACod
               }
               , new Object[] {
               T006V5_A426ACTClaCod, T006V5_A2184ACTClaDsc, T006V5_A2185ACTClaSts, T006V5_A70TipACod, T006V5_n70TipACod
               }
               , new Object[] {
               T006V6_A70TipACod
               }
               , new Object[] {
               T006V7_A426ACTClaCod
               }
               , new Object[] {
               T006V8_A426ACTClaCod
               }
               , new Object[] {
               T006V9_A426ACTClaCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006V13_A83ParTip, T006V13_A84ParCod, T006V13_A85ParDActItem
               }
               , new Object[] {
               T006V14_A426ACTClaCod, T006V14_A2103ACTGrupCod
               }
               , new Object[] {
               T006V15_A426ACTClaCod
               }
               , new Object[] {
               T006V16_A70TipACod, T006V16_A1900TipADsc, T006V16_A1902TipASts
               }
               , new Object[] {
               T006V17_A70TipACod
               }
            }
         );
      }

      private short Z2185ACTClaSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A2185ACTClaSts ;
      private short GX_JID ;
      private short RcdFound189 ;
      private short nIsDirty_189 ;
      private short Gx_BScreen ;
      private short ZZ2185ACTClaSts ;
      private int Z70TipACod ;
      private int A70TipACod ;
      private int trnEnded ;
      private int imgImage1_Visible ;
      private int imgImage1_Enabled ;
      private int imgImage2_Visible ;
      private int edtACTClaCod_Enabled ;
      private int edtACTClaDsc_Enabled ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private int ZZ70TipACod ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtACTClaCod_Internalname ;
      private string dynTipACod_Internalname ;
      private string cmbACTClaSts_Internalname ;
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
      private string edtACTClaCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtACTClaDsc_Internalname ;
      private string edtACTClaDsc_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string dynTipACod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string cmbACTClaSts_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode189 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n70TipACod ;
      private bool wbErr ;
      private bool n426ACTClaCod ;
      private bool gxdyncontrolsrefreshing ;
      private string Z426ACTClaCod ;
      private string Z2184ACTClaDsc ;
      private string A426ACTClaCod ;
      private string A2184ACTClaDsc ;
      private string ZZ426ACTClaCod ;
      private string ZZ2184ACTClaDsc ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynTipACod ;
      private GXCombobox cmbACTClaSts ;
      private IDataStoreProvider pr_default ;
      private string[] T006V5_A426ACTClaCod ;
      private bool[] T006V5_n426ACTClaCod ;
      private string[] T006V5_A2184ACTClaDsc ;
      private short[] T006V5_A2185ACTClaSts ;
      private int[] T006V5_A70TipACod ;
      private bool[] T006V5_n70TipACod ;
      private int[] T006V4_A70TipACod ;
      private bool[] T006V4_n70TipACod ;
      private int[] T006V6_A70TipACod ;
      private bool[] T006V6_n70TipACod ;
      private string[] T006V7_A426ACTClaCod ;
      private bool[] T006V7_n426ACTClaCod ;
      private string[] T006V3_A426ACTClaCod ;
      private bool[] T006V3_n426ACTClaCod ;
      private string[] T006V3_A2184ACTClaDsc ;
      private short[] T006V3_A2185ACTClaSts ;
      private int[] T006V3_A70TipACod ;
      private bool[] T006V3_n70TipACod ;
      private string[] T006V8_A426ACTClaCod ;
      private bool[] T006V8_n426ACTClaCod ;
      private string[] T006V9_A426ACTClaCod ;
      private bool[] T006V9_n426ACTClaCod ;
      private string[] T006V2_A426ACTClaCod ;
      private bool[] T006V2_n426ACTClaCod ;
      private string[] T006V2_A2184ACTClaDsc ;
      private short[] T006V2_A2185ACTClaSts ;
      private int[] T006V2_A70TipACod ;
      private bool[] T006V2_n70TipACod ;
      private string[] T006V13_A83ParTip ;
      private int[] T006V13_A84ParCod ;
      private int[] T006V13_A85ParDActItem ;
      private string[] T006V14_A426ACTClaCod ;
      private bool[] T006V14_n426ACTClaCod ;
      private string[] T006V14_A2103ACTGrupCod ;
      private string[] T006V15_A426ACTClaCod ;
      private bool[] T006V15_n426ACTClaCod ;
      private int[] T006V16_A70TipACod ;
      private bool[] T006V16_n70TipACod ;
      private string[] T006V16_A1900TipADsc ;
      private short[] T006V16_A1902TipASts ;
      private int[] T006V17_A70TipACod ;
      private bool[] T006V17_n70TipACod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class actclase__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actclase__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT006V5;
        prmT006V5 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006V4;
        prmT006V4 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT006V6;
        prmT006V6 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT006V7;
        prmT006V7 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006V3;
        prmT006V3 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006V8;
        prmT006V8 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006V9;
        prmT006V9 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006V2;
        prmT006V2 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006V10;
        prmT006V10 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@ACTClaDsc",GXType.NVarChar,100,0) ,
        new ParDef("@ACTClaSts",GXType.Int16,1,0) ,
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT006V11;
        prmT006V11 = new Object[] {
        new ParDef("@ACTClaDsc",GXType.NVarChar,100,0) ,
        new ParDef("@ACTClaSts",GXType.Int16,1,0) ,
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006V12;
        prmT006V12 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006V13;
        prmT006V13 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006V14;
        prmT006V14 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT006V15;
        prmT006V15 = new Object[] {
        };
        Object[] prmT006V16;
        prmT006V16 = new Object[] {
        };
        Object[] prmT006V17;
        prmT006V17 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T006V2", "SELECT [ACTClaCod], [ACTClaDsc], [ACTClaSts], [TipACod] FROM [ACTCLASE] WITH (UPDLOCK) WHERE [ACTClaCod] = @ACTClaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006V2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006V3", "SELECT [ACTClaCod], [ACTClaDsc], [ACTClaSts], [TipACod] FROM [ACTCLASE] WHERE [ACTClaCod] = @ACTClaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006V3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006V4", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006V4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006V5", "SELECT TM1.[ACTClaCod], TM1.[ACTClaDsc], TM1.[ACTClaSts], TM1.[TipACod] FROM [ACTCLASE] TM1 WHERE TM1.[ACTClaCod] = @ACTClaCod ORDER BY TM1.[ACTClaCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006V5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006V6", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006V6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006V7", "SELECT [ACTClaCod] FROM [ACTCLASE] WHERE [ACTClaCod] = @ACTClaCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006V7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006V8", "SELECT TOP 1 [ACTClaCod] FROM [ACTCLASE] WHERE ( [ACTClaCod] > @ACTClaCod) ORDER BY [ACTClaCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006V8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006V9", "SELECT TOP 1 [ACTClaCod] FROM [ACTCLASE] WHERE ( [ACTClaCod] < @ACTClaCod) ORDER BY [ACTClaCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006V9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006V10", "INSERT INTO [ACTCLASE]([ACTClaCod], [ACTClaDsc], [ACTClaSts], [TipACod]) VALUES(@ACTClaCod, @ACTClaDsc, @ACTClaSts, @TipACod)", GxErrorMask.GX_NOMASK,prmT006V10)
           ,new CursorDef("T006V11", "UPDATE [ACTCLASE] SET [ACTClaDsc]=@ACTClaDsc, [ACTClaSts]=@ACTClaSts, [TipACod]=@TipACod  WHERE [ACTClaCod] = @ACTClaCod", GxErrorMask.GX_NOMASK,prmT006V11)
           ,new CursorDef("T006V12", "DELETE FROM [ACTCLASE]  WHERE [ACTClaCod] = @ACTClaCod", GxErrorMask.GX_NOMASK,prmT006V12)
           ,new CursorDef("T006V13", "SELECT TOP 1 [ParTip], [ParCod], [ParDActItem] FROM [CBPARAMACTIVO] WHERE [ACTClaCod] = @ACTClaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006V13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006V14", "SELECT TOP 1 [ACTClaCod], [ACTGrupCod] FROM [ACTGRUPO] WHERE [ACTClaCod] = @ACTClaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006V14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006V15", "SELECT [ACTClaCod] FROM [ACTCLASE] ORDER BY [ACTClaCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006V15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006V16", "SELECT [TipACod], [TipADsc], [TipASts] FROM [CBTIPAUXILIAR] WHERE [TipASts] = 1 ORDER BY [TipADsc] ",true, GxErrorMask.GX_NOMASK, false, this,prmT006V16,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006V17", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006V17,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
