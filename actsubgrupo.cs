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
   public class actsubgrupo : GXHttpHandler
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
            GXDLAACTCLACOD71195( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"ACTGRUPCOD") == 0 )
         {
            A426ACTClaCod = GetPar( "ACTClaCod");
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAACTGRUPCOD71195( A426ACTClaCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A426ACTClaCod = GetPar( "ACTClaCod");
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = GetPar( "ACTGrupCod");
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A426ACTClaCod, A2103ACTGrupCod) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
         {
            nRC_GXsfl_43 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."));
            nGXsfl_43_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."));
            sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGrid1_newrow( ) ;
            return  ;
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
            Form.Meta.addItem("description", "Componentes", 0) ;
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

      public actsubgrupo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actsubgrupo( IGxContext context )
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
         dynACTGrupCod = new GXCombobox();
         cmbACTSGrupSts = new GXCombobox();
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
         if ( dynACTGrupCod.ItemCount > 0 )
         {
            A2103ACTGrupCod = dynACTGrupCod.getValidValue(A2103ACTGrupCod);
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynACTGrupCod.CurrentValue = StringUtil.RTrim( A2103ACTGrupCod);
            AssignProp("", false, dynACTGrupCod_Internalname, "Values", dynACTGrupCod.ToJavascriptSource(), true);
         }
         if ( cmbACTSGrupSts.ItemCount > 0 )
         {
            A2227ACTSGrupSts = (short)(NumberUtil.Val( cmbACTSGrupSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0))), "."));
            AssignAttri("", false, "A2227ACTSGrupSts", StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbACTSGrupSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0));
            AssignProp("", false, cmbACTSGrupSts_Internalname, "Values", cmbACTSGrupSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm71195( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
         /* Control Group */
         GxWebStd.gx_group_start( context, grpGroup1_Internalname, "Componente", 1, 100, "%", 0, "px", "Group", "", "HLP_ACTSUBGRUPO.htm");
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
         GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage1_Visible, imgImage1_Enabled, "", "Grabar", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"EENTER."+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ACTSUBGRUPO.htm");
         /* Active images/pictures */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "Image";
         StyleString = "";
         sImgUrl = "(none)";
         GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage2_Visible, 1, "", "Salir", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'SALIR\\'."+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ACTSUBGRUPO.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Tipo Activo", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTSUBGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynACTClaCod, dynACTClaCod_Internalname, StringUtil.RTrim( A426ACTClaCod), 1, dynACTClaCod_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, dynACTClaCod.Enabled, 0, 0, 0, "em", 0, "", "", "Combo150SIG", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,15);\"", "", true, 1, "HLP_ACTSUBGRUPO.htm");
         dynACTClaCod.CurrentValue = StringUtil.RTrim( A426ACTClaCod);
         AssignProp("", false, dynACTClaCod_Internalname, "Values", (string)(dynACTClaCod.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Grupo de Activo", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTSUBGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynACTGrupCod, dynACTGrupCod_Internalname, StringUtil.RTrim( A2103ACTGrupCod), 1, dynACTGrupCod_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, dynACTGrupCod.Enabled, 0, 0, 0, "em", 0, "", "", "Combo150SIG", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "", true, 1, "HLP_ACTSUBGRUPO.htm");
         dynACTGrupCod.CurrentValue = StringUtil.RTrim( A2103ACTGrupCod);
         AssignProp("", false, dynACTGrupCod_Internalname, "Values", (string)(dynACTGrupCod.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTSUBGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTSGrupCod_Internalname, A2114ACTSGrupCod, StringUtil.RTrim( context.localUtil.Format( A2114ACTSGrupCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTSGrupCod_Jsonclick, 0, "AttSIG", "", "", "", "", 1, edtACTSGrupCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTSUBGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Componente", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTSUBGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTSGrupDsc_Internalname, StringUtil.RTrim( A2155ACTSGrupDsc), StringUtil.RTrim( context.localUtil.Format( A2155ACTSGrupDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTSGrupDsc_Jsonclick, 0, "AttSIG", "", "", "", "", 1, edtACTSGrupDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTSUBGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "% Distribución", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTSUBGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTSGrupPor_Internalname, StringUtil.LTrim( StringUtil.NToC( A2156ACTSGrupPor, 6, 2, ".", "")), StringUtil.LTrim( ((edtACTSGrupPor_Enabled!=0) ? context.localUtil.Format( A2156ACTSGrupPor, "ZZ9.99") : context.localUtil.Format( A2156ACTSGrupPor, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTSGrupPor_Jsonclick, 0, "AttSIG", "", "", "", "", 1, edtACTSGrupPor_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_ACTSUBGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Año", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTSUBGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTSGrupAno_Internalname, StringUtil.LTrim( StringUtil.NToC( A2226ACTSGrupAno, 6, 2, ".", "")), StringUtil.LTrim( ((edtACTSGrupAno_Enabled!=0) ? context.localUtil.Format( A2226ACTSGrupAno, "ZZ9.99") : context.localUtil.Format( A2226ACTSGrupAno, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTSGrupAno_Jsonclick, 0, "AttSIG", "", "", "", "", 1, edtACTSGrupAno_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTSUBGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td colspan=\"2\"  style=\""+CSSHelper.Prettify( "vertical-align:top")+"\">") ;
         /*  Grid Control  */
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("Header", subGrid1_Header);
         Grid1Container.AddObjectProperty("Class", "GrdWeb");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.AddObjectProperty("Width", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Width), 9, 0, ".", "")));
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2115ACTSSGrupCod), 5, 0, ".", "")));
         Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtACTSSGrupCod_Enabled), 5, 0, ".", "")));
         Grid1Container.AddColumnProperties(Grid1Column);
         Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Grid1Column.AddObjectProperty("Value", A2230ACTSSGrupDsc);
         Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtACTSSGrupDsc_Enabled), 5, 0, ".", "")));
         Grid1Container.AddColumnProperties(Grid1Column);
         Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A2229ACTSSGrupPor, 6, 2, ".", "")));
         Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtACTSSGrupPor_Enabled), 5, 0, ".", "")));
         Grid1Container.AddColumnProperties(Grid1Column);
         Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
         Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
         Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
         Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
         Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
         Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         nGXsfl_43_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount196 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_196 = 1;
               ScanStart71196( ) ;
               while ( RcdFound196 != 0 )
               {
                  init_level_properties196( ) ;
                  getByPrimaryKey71196( ) ;
                  AddRow71196( ) ;
                  ScanNext71196( ) ;
               }
               ScanEnd71196( ) ;
               nBlankRcdCount196 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal71196( ) ;
            standaloneModal71196( ) ;
            sMode196 = Gx_mode;
            while ( nGXsfl_43_idx < nRC_GXsfl_43 )
            {
               bGXsfl_43_Refreshing = true;
               ReadRow71196( ) ;
               edtACTSSGrupCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "ACTSSGRUPCOD_"+sGXsfl_43_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtACTSSGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSSGrupCod_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtACTSSGrupDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "ACTSSGRUPDSC_"+sGXsfl_43_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtACTSSGrupDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSSGrupDsc_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtACTSSGrupPor_Enabled = (int)(context.localUtil.CToN( cgiGet( "ACTSSGRUPPOR_"+sGXsfl_43_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtACTSSGrupPor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSSGrupPor_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               if ( ( nRcdExists_196 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal71196( ) ;
               }
               SendRow71196( ) ;
               bGXsfl_43_Refreshing = false;
            }
            Gx_mode = sMode196;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount196 = 5;
            nRcdExists_196 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart71196( ) ;
               while ( RcdFound196 != 0 )
               {
                  sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_43196( ) ;
                  init_level_properties196( ) ;
                  standaloneNotModal71196( ) ;
                  getByPrimaryKey71196( ) ;
                  standaloneModal71196( ) ;
                  AddRow71196( ) ;
                  ScanNext71196( ) ;
               }
               ScanEnd71196( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode196 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx+1), 4, 0), 4, "0");
         SubsflControlProps_43196( ) ;
         InitAll71196( ) ;
         init_level_properties196( ) ;
         nRcdExists_196 = 0;
         nIsMod_196 = 0;
         nRcdDeleted_196 = 0;
         nBlankRcdCount196 = (short)(nBlankRcdUsr196+nBlankRcdCount196);
         fRowAdded = 0;
         while ( nBlankRcdCount196 > 0 )
         {
            standaloneNotModal71196( ) ;
            standaloneModal71196( ) ;
            AddRow71196( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtACTSSGrupDsc_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount196 = (short)(nBlankRcdCount196-1);
         }
         Gx_mode = sMode196;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
         }
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Estado", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTSUBGRUPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbACTSGrupSts, cmbACTSGrupSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0)), 1, cmbACTSGrupSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbACTSGrupSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 1, "HLP_ACTSUBGRUPO.htm");
         cmbACTSGrupSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0));
         AssignProp("", false, cmbACTSGrupSts_Internalname, "Values", (string)(cmbACTSGrupSts.ToJavascriptSource()), true);
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
            Z2114ACTSGrupCod = cgiGet( "Z2114ACTSGrupCod");
            Z2155ACTSGrupDsc = cgiGet( "Z2155ACTSGrupDsc");
            Z2227ACTSGrupSts = (short)(context.localUtil.CToN( cgiGet( "Z2227ACTSGrupSts"), ".", ","));
            Z2156ACTSGrupPor = context.localUtil.CToN( cgiGet( "Z2156ACTSGrupPor"), ".", ",");
            Z2226ACTSGrupAno = context.localUtil.CToN( cgiGet( "Z2226ACTSGrupAno"), ".", ",");
            Z2228ACTSGrupTot = (int)(context.localUtil.CToN( cgiGet( "Z2228ACTSGrupTot"), ".", ","));
            A2228ACTSGrupTot = (int)(context.localUtil.CToN( cgiGet( "Z2228ACTSGrupTot"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_43 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), ".", ","));
            A2228ACTSGrupTot = (int)(context.localUtil.CToN( cgiGet( "ACTSGRUPTOT"), ".", ","));
            /* Read variables values. */
            dynACTClaCod.Name = dynACTClaCod_Internalname;
            dynACTClaCod.CurrentValue = cgiGet( dynACTClaCod_Internalname);
            A426ACTClaCod = cgiGet( dynACTClaCod_Internalname);
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            dynACTGrupCod.Name = dynACTGrupCod_Internalname;
            dynACTGrupCod.CurrentValue = cgiGet( dynACTGrupCod_Internalname);
            A2103ACTGrupCod = cgiGet( dynACTGrupCod_Internalname);
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2114ACTSGrupCod = cgiGet( edtACTSGrupCod_Internalname);
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            A2155ACTSGrupDsc = cgiGet( edtACTSGrupDsc_Internalname);
            AssignAttri("", false, "A2155ACTSGrupDsc", A2155ACTSGrupDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTSGrupPor_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTSGrupPor_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTSGRUPPOR");
               AnyError = 1;
               GX_FocusControl = edtACTSGrupPor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2156ACTSGrupPor = 0;
               AssignAttri("", false, "A2156ACTSGrupPor", StringUtil.LTrimStr( A2156ACTSGrupPor, 6, 2));
            }
            else
            {
               A2156ACTSGrupPor = context.localUtil.CToN( cgiGet( edtACTSGrupPor_Internalname), ".", ",");
               AssignAttri("", false, "A2156ACTSGrupPor", StringUtil.LTrimStr( A2156ACTSGrupPor, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTSGrupAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTSGrupAno_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTSGRUPANO");
               AnyError = 1;
               GX_FocusControl = edtACTSGrupAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2226ACTSGrupAno = 0;
               AssignAttri("", false, "A2226ACTSGrupAno", StringUtil.LTrimStr( A2226ACTSGrupAno, 6, 2));
            }
            else
            {
               A2226ACTSGrupAno = context.localUtil.CToN( cgiGet( edtACTSGrupAno_Internalname), ".", ",");
               AssignAttri("", false, "A2226ACTSGrupAno", StringUtil.LTrimStr( A2226ACTSGrupAno, 6, 2));
            }
            cmbACTSGrupSts.Name = cmbACTSGrupSts_Internalname;
            cmbACTSGrupSts.CurrentValue = cgiGet( cmbACTSGrupSts_Internalname);
            A2227ACTSGrupSts = (short)(NumberUtil.Val( cgiGet( cmbACTSGrupSts_Internalname), "."));
            AssignAttri("", false, "A2227ACTSGrupSts", StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"ACTSUBGRUPO");
            forbiddenHiddens.Add("ACTSGrupTot", context.localUtil.Format( (decimal)(A2228ACTSGrupTot), "ZZZZ9"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 ) || ( StringUtil.StrCmp(A2103ACTGrupCod, Z2103ACTGrupCod) != 0 ) || ( StringUtil.StrCmp(A2114ACTSGrupCod, Z2114ACTSGrupCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("actsubgrupo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               AnyError = 1;
               return  ;
            }
            /* Check if conditions changed and reset current page numbers */
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
               A2114ACTSGrupCod = GetPar( "ACTSGrupCod");
               AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
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
                     sEvtType = StringUtil.Right( sEvt, 4);
                     sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
               InitAll71195( ) ;
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
         DisableAttributes71195( ) ;
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

      protected void CONFIRM_71196( )
      {
         nGXsfl_43_idx = 0;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            ReadRow71196( ) ;
            if ( ( nRcdExists_196 != 0 ) || ( nIsMod_196 != 0 ) )
            {
               GetKey71196( ) ;
               if ( ( nRcdExists_196 == 0 ) && ( nRcdDeleted_196 == 0 ) )
               {
                  if ( RcdFound196 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate71196( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable71196( ) ;
                        CloseExtendedTableCursors71196( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "ACTCLACOD");
                     AnyError = 1;
                     GX_FocusControl = dynACTClaCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound196 != 0 )
                  {
                     if ( nRcdDeleted_196 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey71196( ) ;
                        Load71196( ) ;
                        BeforeValidate71196( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls71196( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_196 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate71196( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable71196( ) ;
                              CloseExtendedTableCursors71196( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_196 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACTCLACOD");
                        AnyError = 1;
                        GX_FocusControl = dynACTClaCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtACTSSGrupCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2115ACTSSGrupCod), 5, 0, ".", ""))) ;
            ChangePostValue( edtACTSSGrupDsc_Internalname, A2230ACTSSGrupDsc) ;
            ChangePostValue( edtACTSSGrupPor_Internalname, StringUtil.LTrim( StringUtil.NToC( A2229ACTSSGrupPor, 6, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2115ACTSSGrupCod_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2115ACTSSGrupCod), 5, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2229ACTSSGrupPor_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( Z2229ACTSSGrupPor, 6, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2230ACTSSGrupDsc_"+sGXsfl_43_idx, Z2230ACTSSGrupDsc) ;
            ChangePostValue( "nRcdDeleted_196_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_196), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_196_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_196), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_196_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_196), 4, 0, ".", ""))) ;
            if ( nIsMod_196 != 0 )
            {
               ChangePostValue( "ACTSSGRUPCOD_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtACTSSGrupCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ACTSSGRUPDSC_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtACTSSGrupDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ACTSSGRUPPOR_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtACTSSGrupPor_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption710( )
      {
      }

      protected void ZM71195( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2155ACTSGrupDsc = T00715_A2155ACTSGrupDsc[0];
               Z2227ACTSGrupSts = T00715_A2227ACTSGrupSts[0];
               Z2156ACTSGrupPor = T00715_A2156ACTSGrupPor[0];
               Z2226ACTSGrupAno = T00715_A2226ACTSGrupAno[0];
               Z2228ACTSGrupTot = T00715_A2228ACTSGrupTot[0];
            }
            else
            {
               Z2155ACTSGrupDsc = A2155ACTSGrupDsc;
               Z2227ACTSGrupSts = A2227ACTSGrupSts;
               Z2156ACTSGrupPor = A2156ACTSGrupPor;
               Z2226ACTSGrupAno = A2226ACTSGrupAno;
               Z2228ACTSGrupTot = A2228ACTSGrupTot;
            }
         }
         if ( GX_JID == -4 )
         {
            Z2114ACTSGrupCod = A2114ACTSGrupCod;
            Z2155ACTSGrupDsc = A2155ACTSGrupDsc;
            Z2227ACTSGrupSts = A2227ACTSGrupSts;
            Z2156ACTSGrupPor = A2156ACTSGrupPor;
            Z2226ACTSGrupAno = A2226ACTSGrupAno;
            Z2228ACTSGrupTot = A2228ACTSGrupTot;
            Z426ACTClaCod = A426ACTClaCod;
            Z2103ACTGrupCod = A2103ACTGrupCod;
         }
      }

      protected void standaloneNotModal( )
      {
         GXAACTCLACOD_html71195( ) ;
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            GXAACTGRUPCOD_html71195( A426ACTClaCod) ;
         }
      }

      protected void Load71195( )
      {
         /* Using cursor T00717 */
         pr_default.execute(5, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound195 = 1;
            A2155ACTSGrupDsc = T00717_A2155ACTSGrupDsc[0];
            AssignAttri("", false, "A2155ACTSGrupDsc", A2155ACTSGrupDsc);
            A2227ACTSGrupSts = T00717_A2227ACTSGrupSts[0];
            AssignAttri("", false, "A2227ACTSGrupSts", StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0));
            A2156ACTSGrupPor = T00717_A2156ACTSGrupPor[0];
            AssignAttri("", false, "A2156ACTSGrupPor", StringUtil.LTrimStr( A2156ACTSGrupPor, 6, 2));
            A2226ACTSGrupAno = T00717_A2226ACTSGrupAno[0];
            AssignAttri("", false, "A2226ACTSGrupAno", StringUtil.LTrimStr( A2226ACTSGrupAno, 6, 2));
            A2228ACTSGrupTot = T00717_A2228ACTSGrupTot[0];
            ZM71195( -4) ;
         }
         pr_default.close(5);
         OnLoadActions71195( ) ;
      }

      protected void OnLoadActions71195( )
      {
         GXAACTGRUPCOD_html71195( A426ACTClaCod) ;
      }

      protected void CheckExtendedTable71195( )
      {
         nIsDirty_195 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         GXAACTGRUPCOD_html71195( A426ACTClaCod) ;
         /* Using cursor T00716 */
         pr_default.execute(4, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Grupo de Activo'.", "ForeignKeyNotFound", 1, "ACTGRUPCOD");
            AnyError = 1;
            GX_FocusControl = dynACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors71195( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( string A426ACTClaCod ,
                               string A2103ACTGrupCod )
      {
         /* Using cursor T00718 */
         pr_default.execute(6, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Grupo de Activo'.", "ForeignKeyNotFound", 1, "ACTGRUPCOD");
            AnyError = 1;
            GX_FocusControl = dynACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey71195( )
      {
         /* Using cursor T00719 */
         pr_default.execute(7, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound195 = 1;
         }
         else
         {
            RcdFound195 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00715 */
         pr_default.execute(3, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM71195( 4) ;
            RcdFound195 = 1;
            A2114ACTSGrupCod = T00715_A2114ACTSGrupCod[0];
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            A2155ACTSGrupDsc = T00715_A2155ACTSGrupDsc[0];
            AssignAttri("", false, "A2155ACTSGrupDsc", A2155ACTSGrupDsc);
            A2227ACTSGrupSts = T00715_A2227ACTSGrupSts[0];
            AssignAttri("", false, "A2227ACTSGrupSts", StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0));
            A2156ACTSGrupPor = T00715_A2156ACTSGrupPor[0];
            AssignAttri("", false, "A2156ACTSGrupPor", StringUtil.LTrimStr( A2156ACTSGrupPor, 6, 2));
            A2226ACTSGrupAno = T00715_A2226ACTSGrupAno[0];
            AssignAttri("", false, "A2226ACTSGrupAno", StringUtil.LTrimStr( A2226ACTSGrupAno, 6, 2));
            A2228ACTSGrupTot = T00715_A2228ACTSGrupTot[0];
            A426ACTClaCod = T00715_A426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = T00715_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            Z426ACTClaCod = A426ACTClaCod;
            Z2103ACTGrupCod = A2103ACTGrupCod;
            Z2114ACTSGrupCod = A2114ACTSGrupCod;
            sMode195 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load71195( ) ;
            if ( AnyError == 1 )
            {
               RcdFound195 = 0;
               InitializeNonKey71195( ) ;
            }
            Gx_mode = sMode195;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound195 = 0;
            InitializeNonKey71195( ) ;
            sMode195 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode195;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey71195( ) ;
         if ( RcdFound195 == 0 )
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
         RcdFound195 = 0;
         /* Using cursor T007110 */
         pr_default.execute(8, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T007110_A426ACTClaCod[0], A426ACTClaCod) < 0 ) || ( StringUtil.StrCmp(T007110_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T007110_A2103ACTGrupCod[0], A2103ACTGrupCod) < 0 ) || ( StringUtil.StrCmp(T007110_A2103ACTGrupCod[0], A2103ACTGrupCod) == 0 ) && ( StringUtil.StrCmp(T007110_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T007110_A2114ACTSGrupCod[0], A2114ACTSGrupCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T007110_A426ACTClaCod[0], A426ACTClaCod) > 0 ) || ( StringUtil.StrCmp(T007110_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T007110_A2103ACTGrupCod[0], A2103ACTGrupCod) > 0 ) || ( StringUtil.StrCmp(T007110_A2103ACTGrupCod[0], A2103ACTGrupCod) == 0 ) && ( StringUtil.StrCmp(T007110_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T007110_A2114ACTSGrupCod[0], A2114ACTSGrupCod) > 0 ) ) )
            {
               A426ACTClaCod = T007110_A426ACTClaCod[0];
               AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
               A2103ACTGrupCod = T007110_A2103ACTGrupCod[0];
               AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
               A2114ACTSGrupCod = T007110_A2114ACTSGrupCod[0];
               AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
               RcdFound195 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound195 = 0;
         /* Using cursor T007111 */
         pr_default.execute(9, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T007111_A426ACTClaCod[0], A426ACTClaCod) > 0 ) || ( StringUtil.StrCmp(T007111_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T007111_A2103ACTGrupCod[0], A2103ACTGrupCod) > 0 ) || ( StringUtil.StrCmp(T007111_A2103ACTGrupCod[0], A2103ACTGrupCod) == 0 ) && ( StringUtil.StrCmp(T007111_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T007111_A2114ACTSGrupCod[0], A2114ACTSGrupCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T007111_A426ACTClaCod[0], A426ACTClaCod) < 0 ) || ( StringUtil.StrCmp(T007111_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T007111_A2103ACTGrupCod[0], A2103ACTGrupCod) < 0 ) || ( StringUtil.StrCmp(T007111_A2103ACTGrupCod[0], A2103ACTGrupCod) == 0 ) && ( StringUtil.StrCmp(T007111_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T007111_A2114ACTSGrupCod[0], A2114ACTSGrupCod) < 0 ) ) )
            {
               A426ACTClaCod = T007111_A426ACTClaCod[0];
               AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
               A2103ACTGrupCod = T007111_A2103ACTGrupCod[0];
               AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
               A2114ACTSGrupCod = T007111_A2114ACTSGrupCod[0];
               AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
               RcdFound195 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey71195( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = dynACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert71195( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound195 == 1 )
            {
               if ( ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 ) || ( StringUtil.StrCmp(A2103ACTGrupCod, Z2103ACTGrupCod) != 0 ) || ( StringUtil.StrCmp(A2114ACTSGrupCod, Z2114ACTSGrupCod) != 0 ) )
               {
                  A426ACTClaCod = Z426ACTClaCod;
                  AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
                  A2103ACTGrupCod = Z2103ACTGrupCod;
                  AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
                  A2114ACTSGrupCod = Z2114ACTSGrupCod;
                  AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
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
                  Update71195( ) ;
                  GX_FocusControl = dynACTClaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 ) || ( StringUtil.StrCmp(A2103ACTGrupCod, Z2103ACTGrupCod) != 0 ) || ( StringUtil.StrCmp(A2114ACTSGrupCod, Z2114ACTSGrupCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = dynACTClaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert71195( ) ;
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
                     Insert71195( ) ;
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
         if ( ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 ) || ( StringUtil.StrCmp(A2103ACTGrupCod, Z2103ACTGrupCod) != 0 ) || ( StringUtil.StrCmp(A2114ACTSGrupCod, Z2114ACTSGrupCod) != 0 ) )
         {
            A426ACTClaCod = Z426ACTClaCod;
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = Z2103ACTGrupCod;
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2114ACTSGrupCod = Z2114ACTSGrupCod;
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
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
         if ( RcdFound195 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACTCLACOD");
            AnyError = 1;
            GX_FocusControl = dynACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtACTSGrupDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart71195( ) ;
         if ( RcdFound195 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTSGrupDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd71195( ) ;
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
         if ( RcdFound195 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTSGrupDsc_Internalname;
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
         if ( RcdFound195 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTSGrupDsc_Internalname;
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
         ScanStart71195( ) ;
         if ( RcdFound195 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound195 != 0 )
            {
               ScanNext71195( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTSGrupDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd71195( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency71195( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00714 */
            pr_default.execute(2, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTSUBGRUPO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z2155ACTSGrupDsc, T00714_A2155ACTSGrupDsc[0]) != 0 ) || ( Z2227ACTSGrupSts != T00714_A2227ACTSGrupSts[0] ) || ( Z2156ACTSGrupPor != T00714_A2156ACTSGrupPor[0] ) || ( Z2226ACTSGrupAno != T00714_A2226ACTSGrupAno[0] ) || ( Z2228ACTSGrupTot != T00714_A2228ACTSGrupTot[0] ) )
            {
               if ( StringUtil.StrCmp(Z2155ACTSGrupDsc, T00714_A2155ACTSGrupDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("actsubgrupo:[seudo value changed for attri]"+"ACTSGrupDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2155ACTSGrupDsc);
                  GXUtil.WriteLogRaw("Current: ",T00714_A2155ACTSGrupDsc[0]);
               }
               if ( Z2227ACTSGrupSts != T00714_A2227ACTSGrupSts[0] )
               {
                  GXUtil.WriteLog("actsubgrupo:[seudo value changed for attri]"+"ACTSGrupSts");
                  GXUtil.WriteLogRaw("Old: ",Z2227ACTSGrupSts);
                  GXUtil.WriteLogRaw("Current: ",T00714_A2227ACTSGrupSts[0]);
               }
               if ( Z2156ACTSGrupPor != T00714_A2156ACTSGrupPor[0] )
               {
                  GXUtil.WriteLog("actsubgrupo:[seudo value changed for attri]"+"ACTSGrupPor");
                  GXUtil.WriteLogRaw("Old: ",Z2156ACTSGrupPor);
                  GXUtil.WriteLogRaw("Current: ",T00714_A2156ACTSGrupPor[0]);
               }
               if ( Z2226ACTSGrupAno != T00714_A2226ACTSGrupAno[0] )
               {
                  GXUtil.WriteLog("actsubgrupo:[seudo value changed for attri]"+"ACTSGrupAno");
                  GXUtil.WriteLogRaw("Old: ",Z2226ACTSGrupAno);
                  GXUtil.WriteLogRaw("Current: ",T00714_A2226ACTSGrupAno[0]);
               }
               if ( Z2228ACTSGrupTot != T00714_A2228ACTSGrupTot[0] )
               {
                  GXUtil.WriteLog("actsubgrupo:[seudo value changed for attri]"+"ACTSGrupTot");
                  GXUtil.WriteLogRaw("Old: ",Z2228ACTSGrupTot);
                  GXUtil.WriteLogRaw("Current: ",T00714_A2228ACTSGrupTot[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTSUBGRUPO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert71195( )
      {
         BeforeValidate71195( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable71195( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM71195( 0) ;
            CheckOptimisticConcurrency71195( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm71195( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert71195( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007112 */
                     pr_default.execute(10, new Object[] {A2114ACTSGrupCod, A2155ACTSGrupDsc, A2227ACTSGrupSts, A2156ACTSGrupPor, A2226ACTSGrupAno, A2228ACTSGrupTot, A426ACTClaCod, A2103ACTGrupCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTSUBGRUPO");
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
                           ProcessLevel71195( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption710( ) ;
                           }
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
               Load71195( ) ;
            }
            EndLevel71195( ) ;
         }
         CloseExtendedTableCursors71195( ) ;
      }

      protected void Update71195( )
      {
         BeforeValidate71195( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable71195( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency71195( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm71195( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate71195( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007113 */
                     pr_default.execute(11, new Object[] {A2155ACTSGrupDsc, A2227ACTSGrupSts, A2156ACTSGrupPor, A2226ACTSGrupAno, A2228ACTSGrupTot, A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTSUBGRUPO");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTSUBGRUPO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate71195( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel71195( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption710( ) ;
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
            }
            EndLevel71195( ) ;
         }
         CloseExtendedTableCursors71195( ) ;
      }

      protected void DeferredUpdate71195( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate71195( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency71195( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls71195( ) ;
            AfterConfirm71195( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete71195( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart71196( ) ;
                  while ( RcdFound196 != 0 )
                  {
                     getByPrimaryKey71196( ) ;
                     Delete71196( ) ;
                     ScanNext71196( ) ;
                  }
                  ScanEnd71196( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007114 */
                     pr_default.execute(12, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTSUBGRUPO");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound195 == 0 )
                           {
                              InitAll71195( ) ;
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
                           ResetCaption710( ) ;
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
         }
         sMode195 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel71195( ) ;
         Gx_mode = sMode195;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls71195( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXAACTGRUPCOD_html71195( A426ACTClaCod) ;
         }
      }

      protected void ProcessNestedLevel71196( )
      {
         nGXsfl_43_idx = 0;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            ReadRow71196( ) ;
            if ( ( nRcdExists_196 != 0 ) || ( nIsMod_196 != 0 ) )
            {
               standaloneNotModal71196( ) ;
               GetKey71196( ) ;
               if ( ( nRcdExists_196 == 0 ) && ( nRcdDeleted_196 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert71196( ) ;
               }
               else
               {
                  if ( RcdFound196 != 0 )
                  {
                     if ( ( nRcdDeleted_196 != 0 ) && ( nRcdExists_196 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete71196( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_196 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update71196( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_196 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACTCLACOD");
                        AnyError = 1;
                        GX_FocusControl = dynACTClaCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtACTSSGrupCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2115ACTSSGrupCod), 5, 0, ".", ""))) ;
            ChangePostValue( edtACTSSGrupDsc_Internalname, A2230ACTSSGrupDsc) ;
            ChangePostValue( edtACTSSGrupPor_Internalname, StringUtil.LTrim( StringUtil.NToC( A2229ACTSSGrupPor, 6, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2115ACTSSGrupCod_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2115ACTSSGrupCod), 5, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2229ACTSSGrupPor_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( Z2229ACTSSGrupPor, 6, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z2230ACTSSGrupDsc_"+sGXsfl_43_idx, Z2230ACTSSGrupDsc) ;
            ChangePostValue( "nRcdDeleted_196_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_196), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_196_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_196), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_196_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_196), 4, 0, ".", ""))) ;
            if ( nIsMod_196 != 0 )
            {
               ChangePostValue( "ACTSSGRUPCOD_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtACTSSGrupCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ACTSSGRUPDSC_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtACTSSGrupDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ACTSSGRUPPOR_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtACTSSGrupPor_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll71196( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_196 = 0;
         nIsMod_196 = 0;
         nRcdDeleted_196 = 0;
      }

      protected void ProcessLevel71195( )
      {
         /* Save parent mode. */
         sMode195 = Gx_mode;
         ProcessNestedLevel71196( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode195;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel71195( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete71195( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("actsubgrupo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues710( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.RollbackDataStores("actsubgrupo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart71195( )
      {
         /* Using cursor T007115 */
         pr_default.execute(13);
         RcdFound195 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound195 = 1;
            A426ACTClaCod = T007115_A426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = T007115_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2114ACTSGrupCod = T007115_A2114ACTSGrupCod[0];
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext71195( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound195 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound195 = 1;
            A426ACTClaCod = T007115_A426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = T007115_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2114ACTSGrupCod = T007115_A2114ACTSGrupCod[0];
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
         }
      }

      protected void ScanEnd71195( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm71195( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert71195( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate71195( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete71195( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete71195( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate71195( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes71195( )
      {
         dynACTClaCod.Enabled = 0;
         AssignProp("", false, dynACTClaCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynACTClaCod.Enabled), 5, 0), true);
         dynACTGrupCod.Enabled = 0;
         AssignProp("", false, dynACTGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynACTGrupCod.Enabled), 5, 0), true);
         edtACTSGrupCod_Enabled = 0;
         AssignProp("", false, edtACTSGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSGrupCod_Enabled), 5, 0), true);
         edtACTSGrupDsc_Enabled = 0;
         AssignProp("", false, edtACTSGrupDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSGrupDsc_Enabled), 5, 0), true);
         edtACTSGrupPor_Enabled = 0;
         AssignProp("", false, edtACTSGrupPor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSGrupPor_Enabled), 5, 0), true);
         edtACTSGrupAno_Enabled = 0;
         AssignProp("", false, edtACTSGrupAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSGrupAno_Enabled), 5, 0), true);
         cmbACTSGrupSts.Enabled = 0;
         AssignProp("", false, cmbACTSGrupSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbACTSGrupSts.Enabled), 5, 0), true);
      }

      protected void ZM71196( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2229ACTSSGrupPor = T00713_A2229ACTSSGrupPor[0];
               Z2230ACTSSGrupDsc = T00713_A2230ACTSSGrupDsc[0];
            }
            else
            {
               Z2229ACTSSGrupPor = A2229ACTSSGrupPor;
               Z2230ACTSSGrupDsc = A2230ACTSSGrupDsc;
            }
         }
         if ( GX_JID == -6 )
         {
            Z426ACTClaCod = A426ACTClaCod;
            Z2103ACTGrupCod = A2103ACTGrupCod;
            Z2114ACTSGrupCod = A2114ACTSGrupCod;
            Z2115ACTSSGrupCod = A2115ACTSSGrupCod;
            Z2229ACTSSGrupPor = A2229ACTSSGrupPor;
            Z2230ACTSSGrupDsc = A2230ACTSSGrupDsc;
         }
      }

      protected void standaloneNotModal71196( )
      {
         edtACTSSGrupCod_Enabled = 0;
         AssignProp("", false, edtACTSSGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSSGrupCod_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void standaloneModal71196( )
      {
      }

      protected void Load71196( )
      {
         /* Using cursor T007116 */
         pr_default.execute(14, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound196 = 1;
            A2229ACTSSGrupPor = T007116_A2229ACTSSGrupPor[0];
            A2230ACTSSGrupDsc = T007116_A2230ACTSSGrupDsc[0];
            ZM71196( -6) ;
         }
         pr_default.close(14);
         OnLoadActions71196( ) ;
      }

      protected void OnLoadActions71196( )
      {
      }

      protected void CheckExtendedTable71196( )
      {
         nIsDirty_196 = 0;
         Gx_BScreen = 1;
         standaloneModal71196( ) ;
      }

      protected void CloseExtendedTableCursors71196( )
      {
      }

      protected void enableDisable71196( )
      {
      }

      protected void GetKey71196( )
      {
         /* Using cursor T007117 */
         pr_default.execute(15, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound196 = 1;
         }
         else
         {
            RcdFound196 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey71196( )
      {
         /* Using cursor T00713 */
         pr_default.execute(1, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM71196( 6) ;
            RcdFound196 = 1;
            InitializeNonKey71196( ) ;
            A2115ACTSSGrupCod = T00713_A2115ACTSSGrupCod[0];
            A2229ACTSSGrupPor = T00713_A2229ACTSSGrupPor[0];
            A2230ACTSSGrupDsc = T00713_A2230ACTSSGrupDsc[0];
            Z426ACTClaCod = A426ACTClaCod;
            Z2103ACTGrupCod = A2103ACTGrupCod;
            Z2114ACTSGrupCod = A2114ACTSGrupCod;
            Z2115ACTSSGrupCod = A2115ACTSSGrupCod;
            sMode196 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal71196( ) ;
            Load71196( ) ;
            Gx_mode = sMode196;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound196 = 0;
            InitializeNonKey71196( ) ;
            sMode196 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal71196( ) ;
            Gx_mode = sMode196;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes71196( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency71196( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00712 */
            pr_default.execute(0, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTSUBGRUPODET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z2229ACTSSGrupPor != T00712_A2229ACTSSGrupPor[0] ) || ( StringUtil.StrCmp(Z2230ACTSSGrupDsc, T00712_A2230ACTSSGrupDsc[0]) != 0 ) )
            {
               if ( Z2229ACTSSGrupPor != T00712_A2229ACTSSGrupPor[0] )
               {
                  GXUtil.WriteLog("actsubgrupo:[seudo value changed for attri]"+"ACTSSGrupPor");
                  GXUtil.WriteLogRaw("Old: ",Z2229ACTSSGrupPor);
                  GXUtil.WriteLogRaw("Current: ",T00712_A2229ACTSSGrupPor[0]);
               }
               if ( StringUtil.StrCmp(Z2230ACTSSGrupDsc, T00712_A2230ACTSSGrupDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("actsubgrupo:[seudo value changed for attri]"+"ACTSSGrupDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2230ACTSSGrupDsc);
                  GXUtil.WriteLogRaw("Current: ",T00712_A2230ACTSSGrupDsc[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTSUBGRUPODET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert71196( )
      {
         BeforeValidate71196( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable71196( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM71196( 0) ;
            CheckOptimisticConcurrency71196( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm71196( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert71196( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007118 */
                     pr_default.execute(16, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod, A2229ACTSSGrupPor, A2230ACTSSGrupDsc});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTSUBGRUPODET");
                     if ( (pr_default.getStatus(16) == 1) )
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
               Load71196( ) ;
            }
            EndLevel71196( ) ;
         }
         CloseExtendedTableCursors71196( ) ;
      }

      protected void Update71196( )
      {
         BeforeValidate71196( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable71196( ) ;
         }
         if ( ( nIsMod_196 != 0 ) || ( nIsDirty_196 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency71196( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm71196( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate71196( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T007119 */
                        pr_default.execute(17, new Object[] {A2229ACTSSGrupPor, A2230ACTSSGrupDsc, A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod});
                        pr_default.close(17);
                        dsDefault.SmartCacheProvider.SetUpdated("ACTSUBGRUPODET");
                        if ( (pr_default.getStatus(17) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTSUBGRUPODET"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate71196( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey71196( ) ;
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
               EndLevel71196( ) ;
            }
         }
         CloseExtendedTableCursors71196( ) ;
      }

      protected void DeferredUpdate71196( )
      {
      }

      protected void Delete71196( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate71196( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency71196( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls71196( ) ;
            AfterConfirm71196( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete71196( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007120 */
                  pr_default.execute(18, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("ACTSUBGRUPODET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode196 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel71196( ) ;
         Gx_mode = sMode196;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls71196( )
      {
         standaloneModal71196( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel71196( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart71196( )
      {
         /* Scan By routine */
         /* Using cursor T007121 */
         pr_default.execute(19, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
         RcdFound196 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound196 = 1;
            A2115ACTSSGrupCod = T007121_A2115ACTSSGrupCod[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext71196( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound196 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound196 = 1;
            A2115ACTSSGrupCod = T007121_A2115ACTSSGrupCod[0];
         }
      }

      protected void ScanEnd71196( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm71196( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert71196( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate71196( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete71196( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete71196( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate71196( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes71196( )
      {
         edtACTSSGrupCod_Enabled = 0;
         AssignProp("", false, edtACTSSGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSSGrupCod_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtACTSSGrupDsc_Enabled = 0;
         AssignProp("", false, edtACTSSGrupDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSSGrupDsc_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtACTSSGrupPor_Enabled = 0;
         AssignProp("", false, edtACTSSGrupPor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSSGrupPor_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void send_integrity_lvl_hashes71196( )
      {
      }

      protected void send_integrity_lvl_hashes71195( )
      {
      }

      protected void SubsflControlProps_43196( )
      {
         edtACTSSGrupCod_Internalname = "ACTSSGRUPCOD_"+sGXsfl_43_idx;
         edtACTSSGrupDsc_Internalname = "ACTSSGRUPDSC_"+sGXsfl_43_idx;
         edtACTSSGrupPor_Internalname = "ACTSSGRUPPOR_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_43196( )
      {
         edtACTSSGrupCod_Internalname = "ACTSSGRUPCOD_"+sGXsfl_43_fel_idx;
         edtACTSSGrupDsc_Internalname = "ACTSSGRUPDSC_"+sGXsfl_43_fel_idx;
         edtACTSSGrupPor_Internalname = "ACTSSGRUPPOR_"+sGXsfl_43_fel_idx;
      }

      protected void AddRow71196( )
      {
         nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_43196( ) ;
         SendRow71196( ) ;
      }

      protected void SendRow71196( )
      {
         Grid1Row = GXWebRow.GetNew(context);
         if ( subGrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
         }
         else if ( subGrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid1_Backstyle = 0;
            subGrid1_Backcolor = subGrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Uniform";
            }
         }
         else if ( subGrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
            subGrid1_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtACTSSGrupCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A2115ACTSSGrupCod), 5, 0, ".", "")),StringUtil.LTrim( ((edtACTSSGrupCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2115ACTSSGrupCod), "ZZZZ9") : context.localUtil.Format( (decimal)(A2115ACTSSGrupCod), "ZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtACTSSGrupCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtACTSSGrupCod_Enabled,(short)0,(string)"text",(string)"1",(short)54,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_196_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtACTSSGrupDsc_Internalname,(string)A2230ACTSSGrupDsc,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtACTSSGrupDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtACTSSGrupDsc_Enabled,(short)0,(string)"text",(string)"",(short)400,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_196_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtACTSSGrupPor_Internalname,StringUtil.LTrim( StringUtil.NToC( A2229ACTSSGrupPor, 6, 2, ".", "")),StringUtil.LTrim( ((edtACTSSGrupPor_Enabled!=0) ? context.localUtil.Format( A2229ACTSSGrupPor, "ZZ9.99") : context.localUtil.Format( A2229ACTSSGrupPor, "ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtACTSSGrupPor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtACTSSGrupPor_Enabled,(short)0,(string)"text",(string)"",(short)120,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         ajax_sending_grid_row(Grid1Row);
         send_integrity_lvl_hashes71196( ) ;
         GXCCtl = "Z2115ACTSSGrupCod_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2115ACTSSGrupCod), 5, 0, ".", "")));
         GXCCtl = "Z2229ACTSSGrupPor_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z2229ACTSSGrupPor, 6, 2, ".", "")));
         GXCCtl = "Z2230ACTSSGrupDsc_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z2230ACTSSGrupDsc);
         GXCCtl = "nRcdDeleted_196_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_196), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_196_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_196), 4, 0, ".", "")));
         GXCCtl = "nIsMod_196_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_196), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ACTSSGRUPCOD_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtACTSSGrupCod_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ACTSSGRUPDSC_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtACTSSGrupDsc_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ACTSSGRUPPOR_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtACTSSGrupPor_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Grid1Container.AddRow(Grid1Row);
      }

      protected void ReadRow71196( )
      {
         nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_43196( ) ;
         edtACTSSGrupCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "ACTSSGRUPCOD_"+sGXsfl_43_idx+"Enabled"), ".", ","));
         edtACTSSGrupDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "ACTSSGRUPDSC_"+sGXsfl_43_idx+"Enabled"), ".", ","));
         edtACTSSGrupPor_Enabled = (int)(context.localUtil.CToN( cgiGet( "ACTSSGRUPPOR_"+sGXsfl_43_idx+"Enabled"), ".", ","));
         A2115ACTSSGrupCod = (int)(context.localUtil.CToN( cgiGet( edtACTSSGrupCod_Internalname), ".", ","));
         A2230ACTSSGrupDsc = cgiGet( edtACTSSGrupDsc_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtACTSSGrupPor_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTSSGrupPor_Internalname), ".", ",") > 999.99m ) ) )
         {
            GXCCtl = "ACTSSGRUPPOR_" + sGXsfl_43_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtACTSSGrupPor_Internalname;
            wbErr = true;
            A2229ACTSSGrupPor = 0;
         }
         else
         {
            A2229ACTSSGrupPor = context.localUtil.CToN( cgiGet( edtACTSSGrupPor_Internalname), ".", ",");
         }
         GXCCtl = "Z2115ACTSSGrupCod_" + sGXsfl_43_idx;
         Z2115ACTSSGrupCod = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z2229ACTSSGrupPor_" + sGXsfl_43_idx;
         Z2229ACTSSGrupPor = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z2230ACTSSGrupDsc_" + sGXsfl_43_idx;
         Z2230ACTSSGrupDsc = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_196_" + sGXsfl_43_idx;
         nRcdDeleted_196 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_196_" + sGXsfl_43_idx;
         nRcdExists_196 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_196_" + sGXsfl_43_idx;
         nIsMod_196 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtACTSSGrupCod_Enabled = edtACTSSGrupCod_Enabled;
      }

      protected void ConfirmValues710( )
      {
         nGXsfl_43_idx = 0;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_43196( ) ;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_43196( ) ;
            ChangePostValue( "Z2115ACTSSGrupCod_"+sGXsfl_43_idx, cgiGet( "ZT_"+"Z2115ACTSSGrupCod_"+sGXsfl_43_idx)) ;
            DeletePostValue( "ZT_"+"Z2115ACTSSGrupCod_"+sGXsfl_43_idx) ;
            ChangePostValue( "Z2229ACTSSGrupPor_"+sGXsfl_43_idx, cgiGet( "ZT_"+"Z2229ACTSSGrupPor_"+sGXsfl_43_idx)) ;
            DeletePostValue( "ZT_"+"Z2229ACTSSGrupPor_"+sGXsfl_43_idx) ;
            ChangePostValue( "Z2230ACTSSGrupDsc_"+sGXsfl_43_idx, cgiGet( "ZT_"+"Z2230ACTSSGrupDsc_"+sGXsfl_43_idx)) ;
            DeletePostValue( "ZT_"+"Z2230ACTSSGrupDsc_"+sGXsfl_43_idx) ;
         }
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
         context.SendWebValue( "Componentes") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810265687", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("actsubgrupo.aspx") +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ACTSUBGRUPO");
         forbiddenHiddens.Add("ACTSGrupTot", context.localUtil.Format( (decimal)(A2228ACTSGrupTot), "ZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("actsubgrupo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z426ACTClaCod", Z426ACTClaCod);
         GxWebStd.gx_hidden_field( context, "Z2103ACTGrupCod", Z2103ACTGrupCod);
         GxWebStd.gx_hidden_field( context, "Z2114ACTSGrupCod", Z2114ACTSGrupCod);
         GxWebStd.gx_hidden_field( context, "Z2155ACTSGrupDsc", StringUtil.RTrim( Z2155ACTSGrupDsc));
         GxWebStd.gx_hidden_field( context, "Z2227ACTSGrupSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2227ACTSGrupSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2156ACTSGrupPor", StringUtil.LTrim( StringUtil.NToC( Z2156ACTSGrupPor, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2226ACTSGrupAno", StringUtil.LTrim( StringUtil.NToC( Z2226ACTSGrupAno, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2228ACTSGrupTot", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2228ACTSGrupTot), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_43_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ACTSGRUPTOT", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2228ACTSGrupTot), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm71195( )
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
         return "ACTSUBGRUPO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Componentes" ;
      }

      protected void InitializeNonKey71195( )
      {
         A2155ACTSGrupDsc = "";
         AssignAttri("", false, "A2155ACTSGrupDsc", A2155ACTSGrupDsc);
         A2227ACTSGrupSts = 0;
         AssignAttri("", false, "A2227ACTSGrupSts", StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0));
         A2156ACTSGrupPor = 0;
         AssignAttri("", false, "A2156ACTSGrupPor", StringUtil.LTrimStr( A2156ACTSGrupPor, 6, 2));
         A2226ACTSGrupAno = 0;
         AssignAttri("", false, "A2226ACTSGrupAno", StringUtil.LTrimStr( A2226ACTSGrupAno, 6, 2));
         A2228ACTSGrupTot = 0;
         AssignAttri("", false, "A2228ACTSGrupTot", StringUtil.LTrimStr( (decimal)(A2228ACTSGrupTot), 5, 0));
         Z2155ACTSGrupDsc = "";
         Z2227ACTSGrupSts = 0;
         Z2156ACTSGrupPor = 0;
         Z2226ACTSGrupAno = 0;
         Z2228ACTSGrupTot = 0;
      }

      protected void InitAll71195( )
      {
         A426ACTClaCod = "";
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         A2103ACTGrupCod = "";
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         A2114ACTSGrupCod = "";
         AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
         InitializeNonKey71195( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey71196( )
      {
         A2229ACTSSGrupPor = 0;
         A2230ACTSSGrupDsc = "";
         Z2229ACTSSGrupPor = 0;
         Z2230ACTSSGrupDsc = "";
      }

      protected void InitAll71196( )
      {
         A2115ACTSSGrupCod = 0;
         InitializeNonKey71196( ) ;
      }

      protected void StandaloneModalInsert71196( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810265695", true, true);
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
         context.AddJavascriptSource("actsubgrupo.js", "?202281810265696", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties196( )
      {
         edtACTSSGrupCod_Enabled = defedtACTSSGrupCod_Enabled;
         AssignProp("", false, edtACTSSGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSSGrupCod_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void init_default_properties( )
      {
         imgImage1_Internalname = "IMAGE1";
         imgImage2_Internalname = "IMAGE2";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         dynACTClaCod_Internalname = "ACTCLACOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         dynACTGrupCod_Internalname = "ACTGRUPCOD";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtACTSGrupCod_Internalname = "ACTSGRUPCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtACTSGrupDsc_Internalname = "ACTSGRUPDSC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtACTSGrupPor_Internalname = "ACTSGRUPPOR";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtACTSGrupAno_Internalname = "ACTSGRUPANO";
         edtACTSSGrupCod_Internalname = "ACTSSGRUPCOD";
         edtACTSSGrupDsc_Internalname = "ACTSSGRUPDSC";
         edtACTSSGrupPor_Internalname = "ACTSSGRUPPOR";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         cmbACTSGrupSts_Internalname = "ACTSGRUPSTS";
         tblTable2_Internalname = "TABLE2";
         grpGroup1_Internalname = "GROUP1";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtACTSSGrupPor_Jsonclick = "";
         edtACTSSGrupDsc_Jsonclick = "";
         edtACTSSGrupCod_Jsonclick = "";
         subGrid1_Class = "GrdWeb";
         cmbACTSGrupSts_Jsonclick = "";
         cmbACTSGrupSts.Enabled = 1;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtACTSSGrupPor_Enabled = 1;
         edtACTSSGrupDsc_Enabled = 1;
         edtACTSSGrupCod_Enabled = 0;
         subGrid1_Width = 400;
         subGrid1_Backcolorstyle = 3;
         subGrid1_Header = "";
         edtACTSGrupAno_Jsonclick = "";
         edtACTSGrupAno_Enabled = 1;
         edtACTSGrupPor_Jsonclick = "";
         edtACTSGrupPor_Enabled = 1;
         edtACTSGrupDsc_Jsonclick = "";
         edtACTSGrupDsc_Enabled = 1;
         edtACTSGrupCod_Jsonclick = "";
         edtACTSGrupCod_Enabled = 1;
         dynACTGrupCod_Jsonclick = "";
         dynACTGrupCod.Enabled = 1;
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
         GXAACTGRUPCOD_html71195( A426ACTClaCod) ;
         /* End function dynload_actions */
      }

      protected void GXDLAACTCLACOD71195( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAACTCLACOD_data71195( ) ;
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

      protected void GXAACTCLACOD_html71195( )
      {
         string gxdynajaxvalue;
         GXDLAACTCLACOD_data71195( ) ;
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

      protected void GXDLAACTCLACOD_data71195( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add("");
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor T007122 */
         pr_default.execute(20);
         while ( (pr_default.getStatus(20) != 101) )
         {
            gxdynajaxctrlcodr.Add(T007122_A426ACTClaCod[0]);
            gxdynajaxctrldescr.Add(T007122_A2184ACTClaDsc[0]);
            pr_default.readNext(20);
         }
         pr_default.close(20);
      }

      protected void GXDLAACTGRUPCOD71195( string A426ACTClaCod )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAACTGRUPCOD_data71195( A426ACTClaCod) ;
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

      protected void GXAACTGRUPCOD_html71195( string A426ACTClaCod )
      {
         string gxdynajaxvalue;
         GXDLAACTGRUPCOD_data71195( A426ACTClaCod) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynACTGrupCod.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex));
            dynACTGrupCod.addItem(gxdynajaxvalue, ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAACTGRUPCOD_data71195( string A426ACTClaCod )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add("");
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor T007123 */
         pr_default.execute(21, new Object[] {A426ACTClaCod});
         while ( (pr_default.getStatus(21) != 101) )
         {
            gxdynajaxctrlcodr.Add(T007123_A2103ACTGrupCod[0]);
            gxdynajaxctrldescr.Add(T007123_A2196ACTGrupDsc[0]);
            pr_default.readNext(21);
         }
         pr_default.close(21);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_43196( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal71196( ) ;
            standaloneModal71196( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow71196( ) ;
            nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_43196( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void init_web_controls( )
      {
         dynACTClaCod.Name = "ACTCLACOD";
         dynACTClaCod.WebTags = "";
         dynACTGrupCod.Name = "ACTGRUPCOD";
         dynACTGrupCod.WebTags = "";
         cmbACTSGrupSts.Name = "ACTSGRUPSTS";
         cmbACTSGrupSts.WebTags = "";
         cmbACTSGrupSts.addItem("1", "Activo", 0);
         cmbACTSGrupSts.addItem("0", "Inactivo", 0);
         if ( cmbACTSGrupSts.ItemCount > 0 )
         {
            A2227ACTSGrupSts = (short)(NumberUtil.Val( cmbACTSGrupSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0))), "."));
            AssignAttri("", false, "A2227ACTSGrupSts", StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T007124 */
         pr_default.execute(22, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Grupo de Activo'.", "ForeignKeyNotFound", 1, "ACTGRUPCOD");
            AnyError = 1;
            GX_FocusControl = dynACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(22);
         GX_FocusControl = edtACTSGrupDsc_Internalname;
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
         A2103ACTGrupCod = dynACTGrupCod.CurrentValue;
         GXAACTGRUPCOD_html71195( A426ACTClaCod) ;
         dynload_actions( ) ;
         if ( dynACTClaCod.ItemCount > 0 )
         {
            A426ACTClaCod = dynACTClaCod.getValidValue(A426ACTClaCod);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynACTClaCod.CurrentValue = StringUtil.RTrim( A426ACTClaCod);
         }
         if ( dynACTGrupCod.ItemCount > 0 )
         {
            A2103ACTGrupCod = dynACTGrupCod.getValidValue(A2103ACTGrupCod);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynACTGrupCod.CurrentValue = StringUtil.RTrim( A2103ACTGrupCod);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         dynACTGrupCod.CurrentValue = StringUtil.RTrim( A2103ACTGrupCod);
         AssignProp("", false, dynACTGrupCod_Internalname, "Values", dynACTGrupCod.ToJavascriptSource(), true);
      }

      public void Valid_Actgrupcod( )
      {
         A426ACTClaCod = dynACTClaCod.CurrentValue;
         A2103ACTGrupCod = dynACTGrupCod.CurrentValue;
         /* Using cursor T007125 */
         pr_default.execute(23, new Object[] {A426ACTClaCod, A2103ACTGrupCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Grupo de Activo'.", "ForeignKeyNotFound", 1, "ACTGRUPCOD");
            AnyError = 1;
            GX_FocusControl = dynACTClaCod_Internalname;
         }
         pr_default.close(23);
         dynload_actions( ) ;
         if ( dynACTClaCod.ItemCount > 0 )
         {
            A426ACTClaCod = dynACTClaCod.getValidValue(A426ACTClaCod);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynACTClaCod.CurrentValue = StringUtil.RTrim( A426ACTClaCod);
         }
         if ( dynACTGrupCod.ItemCount > 0 )
         {
            A2103ACTGrupCod = dynACTGrupCod.getValidValue(A2103ACTGrupCod);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynACTGrupCod.CurrentValue = StringUtil.RTrim( A2103ACTGrupCod);
         }
         /*  Sending validation outputs */
      }

      public void Valid_Actsgrupcod( )
      {
         A2227ACTSGrupSts = (short)(NumberUtil.Val( cmbACTSGrupSts.CurrentValue, "."));
         cmbACTSGrupSts.CurrentValue = StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0);
         A426ACTClaCod = dynACTClaCod.CurrentValue;
         A2103ACTGrupCod = dynACTGrupCod.CurrentValue;
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
         if ( cmbACTSGrupSts.ItemCount > 0 )
         {
            A2227ACTSGrupSts = (short)(NumberUtil.Val( cmbACTSGrupSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0))), "."));
            cmbACTSGrupSts.CurrentValue = StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbACTSGrupSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0));
         }
         if ( dynACTGrupCod.ItemCount > 0 )
         {
            A2103ACTGrupCod = dynACTGrupCod.getValidValue(A2103ACTGrupCod);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynACTGrupCod.CurrentValue = StringUtil.RTrim( A2103ACTGrupCod);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A2155ACTSGrupDsc", StringUtil.RTrim( A2155ACTSGrupDsc));
         AssignAttri("", false, "A2227ACTSGrupSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2227ACTSGrupSts), 1, 0, ".", "")));
         cmbACTSGrupSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2227ACTSGrupSts), 1, 0));
         AssignProp("", false, cmbACTSGrupSts_Internalname, "Values", cmbACTSGrupSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A2156ACTSGrupPor", StringUtil.LTrim( StringUtil.NToC( A2156ACTSGrupPor, 6, 2, ".", "")));
         AssignAttri("", false, "A2226ACTSGrupAno", StringUtil.LTrim( StringUtil.NToC( A2226ACTSGrupAno, 6, 2, ".", "")));
         AssignAttri("", false, "A2228ACTSGrupTot", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2228ACTSGrupTot), 5, 0, ".", "")));
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         dynACTGrupCod.CurrentValue = StringUtil.RTrim( A2103ACTGrupCod);
         AssignProp("", false, dynACTGrupCod_Internalname, "Values", dynACTGrupCod.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z426ACTClaCod", Z426ACTClaCod);
         GxWebStd.gx_hidden_field( context, "Z2114ACTSGrupCod", Z2114ACTSGrupCod);
         GxWebStd.gx_hidden_field( context, "Z2155ACTSGrupDsc", StringUtil.RTrim( Z2155ACTSGrupDsc));
         GxWebStd.gx_hidden_field( context, "Z2227ACTSGrupSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2227ACTSGrupSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2156ACTSGrupPor", StringUtil.LTrim( StringUtil.NToC( Z2156ACTSGrupPor, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2226ACTSGrupAno", StringUtil.LTrim( StringUtil.NToC( Z2226ACTSGrupAno, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2228ACTSGrupTot", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2228ACTSGrupTot), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2103ACTGrupCod", Z2103ACTGrupCod);
         AssignProp("", false, imgImage1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgImage1_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'dynACTGrupCod'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'dynACTGrupCod'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A2228ACTSGrupTot',fld:'ACTSGRUPTOT',pic:'ZZZZ9'},{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'dynACTGrupCod'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'dynACTGrupCod'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]}");
         setEventMetadata("VALID_ACTCLACOD","{handler:'Valid_Actclacod',iparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'dynACTGrupCod'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]");
         setEventMetadata("VALID_ACTCLACOD",",oparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'dynACTGrupCod'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]}");
         setEventMetadata("VALID_ACTGRUPCOD","{handler:'Valid_Actgrupcod',iparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'dynACTGrupCod'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]");
         setEventMetadata("VALID_ACTGRUPCOD",",oparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'dynACTGrupCod'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]}");
         setEventMetadata("VALID_ACTSGRUPCOD","{handler:'Valid_Actsgrupcod',iparms:[{av:'A2228ACTSGrupTot',fld:'ACTSGRUPTOT',pic:'ZZZZ9'},{av:'cmbACTSGrupSts'},{av:'A2227ACTSGrupSts',fld:'ACTSGRUPSTS',pic:'9'},{av:'A2114ACTSGrupCod',fld:'ACTSGRUPCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'dynACTGrupCod'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]");
         setEventMetadata("VALID_ACTSGRUPCOD",",oparms:[{av:'A2155ACTSGrupDsc',fld:'ACTSGRUPDSC',pic:''},{av:'cmbACTSGrupSts'},{av:'A2227ACTSGrupSts',fld:'ACTSGRUPSTS',pic:'9'},{av:'A2156ACTSGrupPor',fld:'ACTSGRUPPOR',pic:'ZZ9.99'},{av:'A2226ACTSGrupAno',fld:'ACTSGRUPANO',pic:'ZZ9.99'},{av:'A2228ACTSGrupTot',fld:'ACTSGRUPTOT',pic:'ZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z426ACTClaCod'},{av:'Z2114ACTSGrupCod'},{av:'Z2155ACTSGrupDsc'},{av:'Z2227ACTSGrupSts'},{av:'Z2156ACTSGrupPor'},{av:'Z2226ACTSGrupAno'},{av:'Z2228ACTSGrupTot'},{av:'Z2103ACTGrupCod'},{av:'imgImage1_Enabled',ctrl:'IMAGE1',prop:'Enabled'},{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'dynACTGrupCod'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]}");
         setEventMetadata("VALID_ACTSSGRUPCOD","{handler:'Valid_Actssgrupcod',iparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'dynACTGrupCod'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]");
         setEventMetadata("VALID_ACTSSGRUPCOD",",oparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'dynACTGrupCod'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Actssgruppor',iparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'dynACTGrupCod'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'dynACTClaCod'},{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'dynACTGrupCod'},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''}]}");
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
         pr_default.close(3);
         pr_default.close(23);
         pr_default.close(22);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z426ACTClaCod = "";
         Z2103ACTGrupCod = "";
         Z2114ACTSGrupCod = "";
         Z2155ACTSGrupDsc = "";
         Z2230ACTSSGrupDsc = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A426ACTClaCod = "";
         A2103ACTGrupCod = "";
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
         lblTextblock4_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         A2114ACTSGrupCod = "";
         lblTextblock2_Jsonclick = "";
         A2155ACTSGrupDsc = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         Grid1Column = new GXWebColumn();
         A2230ACTSSGrupDsc = "";
         sMode196 = "";
         Gx_mode = "";
         lblTextblock3_Jsonclick = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T00717_A2114ACTSGrupCod = new string[] {""} ;
         T00717_A2155ACTSGrupDsc = new string[] {""} ;
         T00717_A2227ACTSGrupSts = new short[1] ;
         T00717_A2156ACTSGrupPor = new decimal[1] ;
         T00717_A2226ACTSGrupAno = new decimal[1] ;
         T00717_A2228ACTSGrupTot = new int[1] ;
         T00717_A426ACTClaCod = new string[] {""} ;
         T00717_A2103ACTGrupCod = new string[] {""} ;
         T00716_A426ACTClaCod = new string[] {""} ;
         T00718_A426ACTClaCod = new string[] {""} ;
         T00719_A426ACTClaCod = new string[] {""} ;
         T00719_A2103ACTGrupCod = new string[] {""} ;
         T00719_A2114ACTSGrupCod = new string[] {""} ;
         T00715_A2114ACTSGrupCod = new string[] {""} ;
         T00715_A2155ACTSGrupDsc = new string[] {""} ;
         T00715_A2227ACTSGrupSts = new short[1] ;
         T00715_A2156ACTSGrupPor = new decimal[1] ;
         T00715_A2226ACTSGrupAno = new decimal[1] ;
         T00715_A2228ACTSGrupTot = new int[1] ;
         T00715_A426ACTClaCod = new string[] {""} ;
         T00715_A2103ACTGrupCod = new string[] {""} ;
         sMode195 = "";
         T007110_A426ACTClaCod = new string[] {""} ;
         T007110_A2103ACTGrupCod = new string[] {""} ;
         T007110_A2114ACTSGrupCod = new string[] {""} ;
         T007111_A426ACTClaCod = new string[] {""} ;
         T007111_A2103ACTGrupCod = new string[] {""} ;
         T007111_A2114ACTSGrupCod = new string[] {""} ;
         T00714_A2114ACTSGrupCod = new string[] {""} ;
         T00714_A2155ACTSGrupDsc = new string[] {""} ;
         T00714_A2227ACTSGrupSts = new short[1] ;
         T00714_A2156ACTSGrupPor = new decimal[1] ;
         T00714_A2226ACTSGrupAno = new decimal[1] ;
         T00714_A2228ACTSGrupTot = new int[1] ;
         T00714_A426ACTClaCod = new string[] {""} ;
         T00714_A2103ACTGrupCod = new string[] {""} ;
         T007115_A426ACTClaCod = new string[] {""} ;
         T007115_A2103ACTGrupCod = new string[] {""} ;
         T007115_A2114ACTSGrupCod = new string[] {""} ;
         T007116_A426ACTClaCod = new string[] {""} ;
         T007116_A2103ACTGrupCod = new string[] {""} ;
         T007116_A2114ACTSGrupCod = new string[] {""} ;
         T007116_A2115ACTSSGrupCod = new int[1] ;
         T007116_A2229ACTSSGrupPor = new decimal[1] ;
         T007116_A2230ACTSSGrupDsc = new string[] {""} ;
         T007117_A426ACTClaCod = new string[] {""} ;
         T007117_A2103ACTGrupCod = new string[] {""} ;
         T007117_A2114ACTSGrupCod = new string[] {""} ;
         T007117_A2115ACTSSGrupCod = new int[1] ;
         T00713_A426ACTClaCod = new string[] {""} ;
         T00713_A2103ACTGrupCod = new string[] {""} ;
         T00713_A2114ACTSGrupCod = new string[] {""} ;
         T00713_A2115ACTSSGrupCod = new int[1] ;
         T00713_A2229ACTSSGrupPor = new decimal[1] ;
         T00713_A2230ACTSSGrupDsc = new string[] {""} ;
         T00712_A426ACTClaCod = new string[] {""} ;
         T00712_A2103ACTGrupCod = new string[] {""} ;
         T00712_A2114ACTSGrupCod = new string[] {""} ;
         T00712_A2115ACTSSGrupCod = new int[1] ;
         T00712_A2229ACTSSGrupPor = new decimal[1] ;
         T00712_A2230ACTSSGrupDsc = new string[] {""} ;
         T007121_A426ACTClaCod = new string[] {""} ;
         T007121_A2103ACTGrupCod = new string[] {""} ;
         T007121_A2114ACTSGrupCod = new string[] {""} ;
         T007121_A2115ACTSSGrupCod = new int[1] ;
         Grid1Row = new GXWebRow();
         subGrid1_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T007122_A426ACTClaCod = new string[] {""} ;
         T007122_A2184ACTClaDsc = new string[] {""} ;
         T007122_A2185ACTClaSts = new short[1] ;
         T007123_A426ACTClaCod = new string[] {""} ;
         T007123_A2103ACTGrupCod = new string[] {""} ;
         T007123_A2196ACTGrupDsc = new string[] {""} ;
         T007123_A2197ACTGrupSts = new short[1] ;
         T007124_A426ACTClaCod = new string[] {""} ;
         T007125_A426ACTClaCod = new string[] {""} ;
         ZZ426ACTClaCod = "";
         ZZ2114ACTSGrupCod = "";
         ZZ2155ACTSGrupDsc = "";
         ZZ2103ACTGrupCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actsubgrupo__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actsubgrupo__default(),
            new Object[][] {
                new Object[] {
               T00712_A426ACTClaCod, T00712_A2103ACTGrupCod, T00712_A2114ACTSGrupCod, T00712_A2115ACTSSGrupCod, T00712_A2229ACTSSGrupPor, T00712_A2230ACTSSGrupDsc
               }
               , new Object[] {
               T00713_A426ACTClaCod, T00713_A2103ACTGrupCod, T00713_A2114ACTSGrupCod, T00713_A2115ACTSSGrupCod, T00713_A2229ACTSSGrupPor, T00713_A2230ACTSSGrupDsc
               }
               , new Object[] {
               T00714_A2114ACTSGrupCod, T00714_A2155ACTSGrupDsc, T00714_A2227ACTSGrupSts, T00714_A2156ACTSGrupPor, T00714_A2226ACTSGrupAno, T00714_A2228ACTSGrupTot, T00714_A426ACTClaCod, T00714_A2103ACTGrupCod
               }
               , new Object[] {
               T00715_A2114ACTSGrupCod, T00715_A2155ACTSGrupDsc, T00715_A2227ACTSGrupSts, T00715_A2156ACTSGrupPor, T00715_A2226ACTSGrupAno, T00715_A2228ACTSGrupTot, T00715_A426ACTClaCod, T00715_A2103ACTGrupCod
               }
               , new Object[] {
               T00716_A426ACTClaCod
               }
               , new Object[] {
               T00717_A2114ACTSGrupCod, T00717_A2155ACTSGrupDsc, T00717_A2227ACTSGrupSts, T00717_A2156ACTSGrupPor, T00717_A2226ACTSGrupAno, T00717_A2228ACTSGrupTot, T00717_A426ACTClaCod, T00717_A2103ACTGrupCod
               }
               , new Object[] {
               T00718_A426ACTClaCod
               }
               , new Object[] {
               T00719_A426ACTClaCod, T00719_A2103ACTGrupCod, T00719_A2114ACTSGrupCod
               }
               , new Object[] {
               T007110_A426ACTClaCod, T007110_A2103ACTGrupCod, T007110_A2114ACTSGrupCod
               }
               , new Object[] {
               T007111_A426ACTClaCod, T007111_A2103ACTGrupCod, T007111_A2114ACTSGrupCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007115_A426ACTClaCod, T007115_A2103ACTGrupCod, T007115_A2114ACTSGrupCod
               }
               , new Object[] {
               T007116_A426ACTClaCod, T007116_A2103ACTGrupCod, T007116_A2114ACTSGrupCod, T007116_A2115ACTSSGrupCod, T007116_A2229ACTSSGrupPor, T007116_A2230ACTSSGrupDsc
               }
               , new Object[] {
               T007117_A426ACTClaCod, T007117_A2103ACTGrupCod, T007117_A2114ACTSGrupCod, T007117_A2115ACTSSGrupCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007121_A426ACTClaCod, T007121_A2103ACTGrupCod, T007121_A2114ACTSGrupCod, T007121_A2115ACTSSGrupCod
               }
               , new Object[] {
               T007122_A426ACTClaCod, T007122_A2184ACTClaDsc, T007122_A2185ACTClaSts
               }
               , new Object[] {
               T007123_A426ACTClaCod, T007123_A2103ACTGrupCod, T007123_A2196ACTGrupDsc, T007123_A2197ACTGrupSts
               }
               , new Object[] {
               T007124_A426ACTClaCod
               }
               , new Object[] {
               T007125_A426ACTClaCod
               }
            }
         );
      }

      private short Z2227ACTSGrupSts ;
      private short nRcdDeleted_196 ;
      private short nRcdExists_196 ;
      private short nIsMod_196 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A2227ACTSGrupSts ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nBlankRcdCount196 ;
      private short RcdFound196 ;
      private short nBlankRcdUsr196 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound195 ;
      private short nIsDirty_195 ;
      private short nIsDirty_196 ;
      private short subGrid1_Backstyle ;
      private short ZZ2227ACTSGrupSts ;
      private int Z2228ACTSGrupTot ;
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int Z2115ACTSSGrupCod ;
      private int trnEnded ;
      private int imgImage1_Visible ;
      private int imgImage1_Enabled ;
      private int imgImage2_Visible ;
      private int edtACTSGrupCod_Enabled ;
      private int edtACTSGrupDsc_Enabled ;
      private int edtACTSGrupPor_Enabled ;
      private int edtACTSGrupAno_Enabled ;
      private int subGrid1_Width ;
      private int A2115ACTSSGrupCod ;
      private int edtACTSSGrupCod_Enabled ;
      private int edtACTSSGrupDsc_Enabled ;
      private int edtACTSSGrupPor_Enabled ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int fRowAdded ;
      private int A2228ACTSGrupTot ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int defedtACTSSGrupCod_Enabled ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private int ZZ2228ACTSGrupTot ;
      private long GRID1_nFirstRecordOnPage ;
      private decimal Z2156ACTSGrupPor ;
      private decimal Z2226ACTSGrupAno ;
      private decimal Z2229ACTSSGrupPor ;
      private decimal A2156ACTSGrupPor ;
      private decimal A2226ACTSGrupAno ;
      private decimal A2229ACTSSGrupPor ;
      private decimal ZZ2156ACTSGrupPor ;
      private decimal ZZ2226ACTSGrupAno ;
      private string sPrefix ;
      private string Z2155ACTSGrupDsc ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_43_idx="0001" ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string dynACTClaCod_Internalname ;
      private string dynACTGrupCod_Internalname ;
      private string cmbACTSGrupSts_Internalname ;
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
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string dynACTClaCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string dynACTGrupCod_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string edtACTSGrupCod_Internalname ;
      private string edtACTSGrupCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtACTSGrupDsc_Internalname ;
      private string A2155ACTSGrupDsc ;
      private string edtACTSGrupDsc_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtACTSGrupPor_Internalname ;
      private string edtACTSGrupPor_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtACTSGrupAno_Internalname ;
      private string edtACTSGrupAno_Jsonclick ;
      private string subGrid1_Header ;
      private string sMode196 ;
      private string Gx_mode ;
      private string edtACTSSGrupCod_Internalname ;
      private string edtACTSSGrupDsc_Internalname ;
      private string edtACTSSGrupPor_Internalname ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string cmbACTSGrupSts_Jsonclick ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode195 ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtACTSSGrupCod_Jsonclick ;
      private string edtACTSSGrupDsc_Jsonclick ;
      private string edtACTSSGrupPor_Jsonclick ;
      private string GXCCtl ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGrid1_Internalname ;
      private string gxwrpcisep ;
      private string ZZ2155ACTSGrupDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private string Z426ACTClaCod ;
      private string Z2103ACTGrupCod ;
      private string Z2114ACTSGrupCod ;
      private string Z2230ACTSSGrupDsc ;
      private string A426ACTClaCod ;
      private string A2103ACTGrupCod ;
      private string A2114ACTSGrupCod ;
      private string A2230ACTSSGrupDsc ;
      private string ZZ426ACTClaCod ;
      private string ZZ2114ACTSGrupCod ;
      private string ZZ2103ACTGrupCod ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynACTClaCod ;
      private GXCombobox dynACTGrupCod ;
      private GXCombobox cmbACTSGrupSts ;
      private IDataStoreProvider pr_default ;
      private string[] T00717_A2114ACTSGrupCod ;
      private string[] T00717_A2155ACTSGrupDsc ;
      private short[] T00717_A2227ACTSGrupSts ;
      private decimal[] T00717_A2156ACTSGrupPor ;
      private decimal[] T00717_A2226ACTSGrupAno ;
      private int[] T00717_A2228ACTSGrupTot ;
      private string[] T00717_A426ACTClaCod ;
      private string[] T00717_A2103ACTGrupCod ;
      private string[] T00716_A426ACTClaCod ;
      private string[] T00718_A426ACTClaCod ;
      private string[] T00719_A426ACTClaCod ;
      private string[] T00719_A2103ACTGrupCod ;
      private string[] T00719_A2114ACTSGrupCod ;
      private string[] T00715_A2114ACTSGrupCod ;
      private string[] T00715_A2155ACTSGrupDsc ;
      private short[] T00715_A2227ACTSGrupSts ;
      private decimal[] T00715_A2156ACTSGrupPor ;
      private decimal[] T00715_A2226ACTSGrupAno ;
      private int[] T00715_A2228ACTSGrupTot ;
      private string[] T00715_A426ACTClaCod ;
      private string[] T00715_A2103ACTGrupCod ;
      private string[] T007110_A426ACTClaCod ;
      private string[] T007110_A2103ACTGrupCod ;
      private string[] T007110_A2114ACTSGrupCod ;
      private string[] T007111_A426ACTClaCod ;
      private string[] T007111_A2103ACTGrupCod ;
      private string[] T007111_A2114ACTSGrupCod ;
      private string[] T00714_A2114ACTSGrupCod ;
      private string[] T00714_A2155ACTSGrupDsc ;
      private short[] T00714_A2227ACTSGrupSts ;
      private decimal[] T00714_A2156ACTSGrupPor ;
      private decimal[] T00714_A2226ACTSGrupAno ;
      private int[] T00714_A2228ACTSGrupTot ;
      private string[] T00714_A426ACTClaCod ;
      private string[] T00714_A2103ACTGrupCod ;
      private string[] T007115_A426ACTClaCod ;
      private string[] T007115_A2103ACTGrupCod ;
      private string[] T007115_A2114ACTSGrupCod ;
      private string[] T007116_A426ACTClaCod ;
      private string[] T007116_A2103ACTGrupCod ;
      private string[] T007116_A2114ACTSGrupCod ;
      private int[] T007116_A2115ACTSSGrupCod ;
      private decimal[] T007116_A2229ACTSSGrupPor ;
      private string[] T007116_A2230ACTSSGrupDsc ;
      private string[] T007117_A426ACTClaCod ;
      private string[] T007117_A2103ACTGrupCod ;
      private string[] T007117_A2114ACTSGrupCod ;
      private int[] T007117_A2115ACTSSGrupCod ;
      private string[] T00713_A426ACTClaCod ;
      private string[] T00713_A2103ACTGrupCod ;
      private string[] T00713_A2114ACTSGrupCod ;
      private int[] T00713_A2115ACTSSGrupCod ;
      private decimal[] T00713_A2229ACTSSGrupPor ;
      private string[] T00713_A2230ACTSSGrupDsc ;
      private string[] T00712_A426ACTClaCod ;
      private string[] T00712_A2103ACTGrupCod ;
      private string[] T00712_A2114ACTSGrupCod ;
      private int[] T00712_A2115ACTSSGrupCod ;
      private decimal[] T00712_A2229ACTSSGrupPor ;
      private string[] T00712_A2230ACTSSGrupDsc ;
      private string[] T007121_A426ACTClaCod ;
      private string[] T007121_A2103ACTGrupCod ;
      private string[] T007121_A2114ACTSGrupCod ;
      private int[] T007121_A2115ACTSSGrupCod ;
      private string[] T007122_A426ACTClaCod ;
      private string[] T007122_A2184ACTClaDsc ;
      private short[] T007122_A2185ACTClaSts ;
      private string[] T007123_A426ACTClaCod ;
      private string[] T007123_A2103ACTGrupCod ;
      private string[] T007123_A2196ACTGrupDsc ;
      private short[] T007123_A2197ACTGrupSts ;
      private string[] T007124_A426ACTClaCod ;
      private string[] T007125_A426ACTClaCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class actsubgrupo__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actsubgrupo__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00717;
        prmT00717 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT00716;
        prmT00716 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT00718;
        prmT00718 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT00719;
        prmT00719 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT00715;
        prmT00715 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT007110;
        prmT007110 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT007111;
        prmT007111 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT00714;
        prmT00714 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT007112;
        prmT007112 = new Object[] {
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupDsc",GXType.NChar,100,0) ,
        new ParDef("@ACTSGrupSts",GXType.Int16,1,0) ,
        new ParDef("@ACTSGrupPor",GXType.Decimal,6,2) ,
        new ParDef("@ACTSGrupAno",GXType.Decimal,6,2) ,
        new ParDef("@ACTSGrupTot",GXType.Int32,5,0) ,
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT007113;
        prmT007113 = new Object[] {
        new ParDef("@ACTSGrupDsc",GXType.NChar,100,0) ,
        new ParDef("@ACTSGrupSts",GXType.Int16,1,0) ,
        new ParDef("@ACTSGrupPor",GXType.Decimal,6,2) ,
        new ParDef("@ACTSGrupAno",GXType.Decimal,6,2) ,
        new ParDef("@ACTSGrupTot",GXType.Int32,5,0) ,
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT007114;
        prmT007114 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT007115;
        prmT007115 = new Object[] {
        };
        Object[] prmT007116;
        prmT007116 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0)
        };
        Object[] prmT007117;
        prmT007117 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0)
        };
        Object[] prmT00713;
        prmT00713 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0)
        };
        Object[] prmT00712;
        prmT00712 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0)
        };
        Object[] prmT007118;
        prmT007118 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0) ,
        new ParDef("@ACTSSGrupPor",GXType.Decimal,6,2) ,
        new ParDef("@ACTSSGrupDsc",GXType.NVarChar,100,0)
        };
        Object[] prmT007119;
        prmT007119 = new Object[] {
        new ParDef("@ACTSSGrupPor",GXType.Decimal,6,2) ,
        new ParDef("@ACTSSGrupDsc",GXType.NVarChar,100,0) ,
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0)
        };
        Object[] prmT007120;
        prmT007120 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0)
        };
        Object[] prmT007121;
        prmT007121 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT007122;
        prmT007122 = new Object[] {
        };
        Object[] prmT007123;
        prmT007123 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT007124;
        prmT007124 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT007125;
        prmT007125 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00712", "SELECT [ACTClaCod], [ACTGrupCod], [ACTSGrupCod], [ACTSSGrupCod], [ACTSSGrupPor], [ACTSSGrupDsc] FROM [ACTSUBGRUPODET] WITH (UPDLOCK) WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod AND [ACTSSGrupCod] = @ACTSSGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00712,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00713", "SELECT [ACTClaCod], [ACTGrupCod], [ACTSGrupCod], [ACTSSGrupCod], [ACTSSGrupPor], [ACTSSGrupDsc] FROM [ACTSUBGRUPODET] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod AND [ACTSSGrupCod] = @ACTSSGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00713,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00714", "SELECT [ACTSGrupCod], [ACTSGrupDsc], [ACTSGrupSts], [ACTSGrupPor], [ACTSGrupAno], [ACTSGrupTot], [ACTClaCod], [ACTGrupCod] FROM [ACTSUBGRUPO] WITH (UPDLOCK) WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00714,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00715", "SELECT [ACTSGrupCod], [ACTSGrupDsc], [ACTSGrupSts], [ACTSGrupPor], [ACTSGrupAno], [ACTSGrupTot], [ACTClaCod], [ACTGrupCod] FROM [ACTSUBGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00715,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00716", "SELECT [ACTClaCod] FROM [ACTGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00716,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00717", "SELECT TM1.[ACTSGrupCod], TM1.[ACTSGrupDsc], TM1.[ACTSGrupSts], TM1.[ACTSGrupPor], TM1.[ACTSGrupAno], TM1.[ACTSGrupTot], TM1.[ACTClaCod], TM1.[ACTGrupCod] FROM [ACTSUBGRUPO] TM1 WHERE TM1.[ACTClaCod] = @ACTClaCod and TM1.[ACTGrupCod] = @ACTGrupCod and TM1.[ACTSGrupCod] = @ACTSGrupCod ORDER BY TM1.[ACTClaCod], TM1.[ACTGrupCod], TM1.[ACTSGrupCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00717,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00718", "SELECT [ACTClaCod] FROM [ACTGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00718,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00719", "SELECT [ACTClaCod], [ACTGrupCod], [ACTSGrupCod] FROM [ACTSUBGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00719,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007110", "SELECT TOP 1 [ACTClaCod], [ACTGrupCod], [ACTSGrupCod] FROM [ACTSUBGRUPO] WHERE ( [ACTClaCod] > @ACTClaCod or [ACTClaCod] = @ACTClaCod and [ACTGrupCod] > @ACTGrupCod or [ACTGrupCod] = @ACTGrupCod and [ACTClaCod] = @ACTClaCod and [ACTSGrupCod] > @ACTSGrupCod) ORDER BY [ACTClaCod], [ACTGrupCod], [ACTSGrupCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007110,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007111", "SELECT TOP 1 [ACTClaCod], [ACTGrupCod], [ACTSGrupCod] FROM [ACTSUBGRUPO] WHERE ( [ACTClaCod] < @ACTClaCod or [ACTClaCod] = @ACTClaCod and [ACTGrupCod] < @ACTGrupCod or [ACTGrupCod] = @ACTGrupCod and [ACTClaCod] = @ACTClaCod and [ACTSGrupCod] < @ACTSGrupCod) ORDER BY [ACTClaCod] DESC, [ACTGrupCod] DESC, [ACTSGrupCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007111,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007112", "INSERT INTO [ACTSUBGRUPO]([ACTSGrupCod], [ACTSGrupDsc], [ACTSGrupSts], [ACTSGrupPor], [ACTSGrupAno], [ACTSGrupTot], [ACTClaCod], [ACTGrupCod]) VALUES(@ACTSGrupCod, @ACTSGrupDsc, @ACTSGrupSts, @ACTSGrupPor, @ACTSGrupAno, @ACTSGrupTot, @ACTClaCod, @ACTGrupCod)", GxErrorMask.GX_NOMASK,prmT007112)
           ,new CursorDef("T007113", "UPDATE [ACTSUBGRUPO] SET [ACTSGrupDsc]=@ACTSGrupDsc, [ACTSGrupSts]=@ACTSGrupSts, [ACTSGrupPor]=@ACTSGrupPor, [ACTSGrupAno]=@ACTSGrupAno, [ACTSGrupTot]=@ACTSGrupTot  WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod", GxErrorMask.GX_NOMASK,prmT007113)
           ,new CursorDef("T007114", "DELETE FROM [ACTSUBGRUPO]  WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod", GxErrorMask.GX_NOMASK,prmT007114)
           ,new CursorDef("T007115", "SELECT [ACTClaCod], [ACTGrupCod], [ACTSGrupCod] FROM [ACTSUBGRUPO] ORDER BY [ACTClaCod], [ACTGrupCod], [ACTSGrupCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007115,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007116", "SELECT [ACTClaCod], [ACTGrupCod], [ACTSGrupCod], [ACTSSGrupCod], [ACTSSGrupPor], [ACTSSGrupDsc] FROM [ACTSUBGRUPODET] WHERE [ACTClaCod] = @ACTClaCod and [ACTGrupCod] = @ACTGrupCod and [ACTSGrupCod] = @ACTSGrupCod and [ACTSSGrupCod] = @ACTSSGrupCod ORDER BY [ACTClaCod], [ACTGrupCod], [ACTSGrupCod], [ACTSSGrupCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007116,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007117", "SELECT [ACTClaCod], [ACTGrupCod], [ACTSGrupCod], [ACTSSGrupCod] FROM [ACTSUBGRUPODET] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod AND [ACTSSGrupCod] = @ACTSSGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007117,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007118", "INSERT INTO [ACTSUBGRUPODET]([ACTClaCod], [ACTGrupCod], [ACTSGrupCod], [ACTSSGrupCod], [ACTSSGrupPor], [ACTSSGrupDsc]) VALUES(@ACTClaCod, @ACTGrupCod, @ACTSGrupCod, @ACTSSGrupCod, @ACTSSGrupPor, @ACTSSGrupDsc)", GxErrorMask.GX_NOMASK,prmT007118)
           ,new CursorDef("T007119", "UPDATE [ACTSUBGRUPODET] SET [ACTSSGrupPor]=@ACTSSGrupPor, [ACTSSGrupDsc]=@ACTSSGrupDsc  WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod AND [ACTSSGrupCod] = @ACTSSGrupCod", GxErrorMask.GX_NOMASK,prmT007119)
           ,new CursorDef("T007120", "DELETE FROM [ACTSUBGRUPODET]  WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod AND [ACTSSGrupCod] = @ACTSSGrupCod", GxErrorMask.GX_NOMASK,prmT007120)
           ,new CursorDef("T007121", "SELECT [ACTClaCod], [ACTGrupCod], [ACTSGrupCod], [ACTSSGrupCod] FROM [ACTSUBGRUPODET] WHERE [ACTClaCod] = @ACTClaCod and [ACTGrupCod] = @ACTGrupCod and [ACTSGrupCod] = @ACTSGrupCod ORDER BY [ACTClaCod], [ACTGrupCod], [ACTSGrupCod], [ACTSSGrupCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007121,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007122", "SELECT [ACTClaCod], [ACTClaDsc], [ACTClaSts] FROM [ACTCLASE] WHERE [ACTClaSts] = 1 ORDER BY [ACTClaDsc] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007122,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007123", "SELECT [ACTClaCod], [ACTGrupCod], [ACTGrupDsc], [ACTGrupSts] FROM [ACTGRUPO] WHERE ([ACTClaCod] = @ACTClaCod) AND ([ACTGrupSts] = 1) ORDER BY [ACTGrupDsc] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007123,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007124", "SELECT [ACTClaCod] FROM [ACTGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007124,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007125", "SELECT [ACTClaCod] FROM [ACTGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007125,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
