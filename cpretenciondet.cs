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
   public class cpretenciondet : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A302CPRetCod = GetPar( "CPRetCod");
            AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A302CPRetCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A304CPRetTipCod = GetPar( "CPRetTipCod");
            AssignAttri("", false, "A304CPRetTipCod", A304CPRetTipCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A304CPRetTipCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A304CPRetTipCod = GetPar( "CPRetTipCod");
            AssignAttri("", false, "A304CPRetTipCod", A304CPRetTipCod);
            A305CPRetComCod = GetPar( "CPRetComCod");
            AssignAttri("", false, "A305CPRetComCod", A305CPRetComCod);
            A303CPRetPrvCod = GetPar( "CPRetPrvCod");
            AssignAttri("", false, "A303CPRetPrvCod", A303CPRetPrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A304CPRetTipCod, A305CPRetComCod, A303CPRetPrvCod) ;
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
            Form.Meta.addItem("description", "Retención Detalle", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCPRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cpretenciondet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpretenciondet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPRETENCIONDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Retención", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetCod_Internalname, StringUtil.RTrim( A302CPRetCod), StringUtil.RTrim( context.localUtil.Format( A302CPRetCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Proveedor", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetPrvCod_Internalname, StringUtil.RTrim( A303CPRetPrvCod), StringUtil.RTrim( context.localUtil.Format( A303CPRetPrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "T/D", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetTipCod_Internalname, StringUtil.RTrim( A304CPRetTipCod), StringUtil.RTrim( context.localUtil.Format( A304CPRetTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "N° Documento", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetComCod_Internalname, StringUtil.RTrim( A305CPRetComCod), StringUtil.RTrim( context.localUtil.Format( A305CPRetComCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetComCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetComCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPRETENCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Moneda", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCPRetComMon_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A833CPRetComMon), 6, 0, ".", "")), StringUtil.LTrim( ((edtCPRetComMon_Enabled!=0) ? context.localUtil.Format( (decimal)(A833CPRetComMon), "ZZZZZ9") : context.localUtil.Format( (decimal)(A833CPRetComMon), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetComMon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetComMon_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Importe Total", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A839CPRetTotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtCPRetTotal_Enabled!=0) ? context.localUtil.Format( A839CPRetTotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A839CPRetTotal, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetTotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Retención", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCPRetRet_Internalname, StringUtil.LTrim( StringUtil.NToC( A843CPRetRet, 17, 2, ".", "")), StringUtil.LTrim( ((edtCPRetRet_Enabled!=0) ? context.localUtil.Format( A843CPRetRet, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A843CPRetRet, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetRet_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetRet_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "% Porcentaje", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetPor_Internalname, StringUtil.LTrim( StringUtil.NToC( A844CPRetPor, 6, 2, ".", "")), StringUtil.LTrim( ((edtCPRetPor_Enabled!=0) ? context.localUtil.Format( A844CPRetPor, "ZZ9.99") : context.localUtil.Format( A844CPRetPor, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetPor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetPor_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Total MN", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCPRetTotalMN_Internalname, StringUtil.LTrim( StringUtil.NToC( A838CPRetTotalMN, 17, 2, ".", "")), StringUtil.LTrim( ((edtCPRetTotalMN_Enabled!=0) ? context.localUtil.Format( A838CPRetTotalMN, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A838CPRetTotalMN, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetTotalMN_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetTotalMN_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Retención", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCPRetRetMN_Internalname, StringUtil.LTrim( StringUtil.NToC( A842CPRetRetMN, 17, 2, ".", "")), StringUtil.LTrim( ((edtCPRetRetMN_Enabled!=0) ? context.localUtil.Format( A842CPRetRetMN, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A842CPRetRetMN, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetRetMN_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetRetMN_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPRETENCIONDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPRETENCIONDET.htm");
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
            Z302CPRetCod = cgiGet( "Z302CPRetCod");
            Z303CPRetPrvCod = cgiGet( "Z303CPRetPrvCod");
            Z304CPRetTipCod = cgiGet( "Z304CPRetTipCod");
            Z305CPRetComCod = cgiGet( "Z305CPRetComCod");
            Z843CPRetRet = context.localUtil.CToN( cgiGet( "Z843CPRetRet"), ".", ",");
            Z839CPRetTotal = context.localUtil.CToN( cgiGet( "Z839CPRetTotal"), ".", ",");
            Z844CPRetPor = context.localUtil.CToN( cgiGet( "Z844CPRetPor"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A840CPRetTipCmb = context.localUtil.CToN( cgiGet( "CPRETTIPCMB"), ".", ",");
            A849CPRetTipAbr = cgiGet( "CPRETTIPABR");
            /* Read variables values. */
            A302CPRetCod = cgiGet( edtCPRetCod_Internalname);
            AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
            A303CPRetPrvCod = StringUtil.Upper( cgiGet( edtCPRetPrvCod_Internalname));
            AssignAttri("", false, "A303CPRetPrvCod", A303CPRetPrvCod);
            A304CPRetTipCod = cgiGet( edtCPRetTipCod_Internalname);
            AssignAttri("", false, "A304CPRetTipCod", A304CPRetTipCod);
            A305CPRetComCod = cgiGet( edtCPRetComCod_Internalname);
            AssignAttri("", false, "A305CPRetComCod", A305CPRetComCod);
            A833CPRetComMon = (int)(context.localUtil.CToN( cgiGet( edtCPRetComMon_Internalname), ".", ","));
            AssignAttri("", false, "A833CPRetComMon", StringUtil.LTrimStr( (decimal)(A833CPRetComMon), 6, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPRetTotal_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCPRetTotal_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPRETTOTAL");
               AnyError = 1;
               GX_FocusControl = edtCPRetTotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A839CPRetTotal = 0;
               AssignAttri("", false, "A839CPRetTotal", StringUtil.LTrimStr( A839CPRetTotal, 15, 2));
            }
            else
            {
               A839CPRetTotal = context.localUtil.CToN( cgiGet( edtCPRetTotal_Internalname), ".", ",");
               AssignAttri("", false, "A839CPRetTotal", StringUtil.LTrimStr( A839CPRetTotal, 15, 2));
            }
            A843CPRetRet = context.localUtil.CToN( cgiGet( edtCPRetRet_Internalname), ".", ",");
            AssignAttri("", false, "A843CPRetRet", StringUtil.LTrimStr( A843CPRetRet, 15, 2));
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPRetPor_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCPRetPor_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPRETPOR");
               AnyError = 1;
               GX_FocusControl = edtCPRetPor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A844CPRetPor = 0;
               AssignAttri("", false, "A844CPRetPor", StringUtil.LTrimStr( A844CPRetPor, 6, 2));
            }
            else
            {
               A844CPRetPor = context.localUtil.CToN( cgiGet( edtCPRetPor_Internalname), ".", ",");
               AssignAttri("", false, "A844CPRetPor", StringUtil.LTrimStr( A844CPRetPor, 6, 2));
            }
            A838CPRetTotalMN = context.localUtil.CToN( cgiGet( edtCPRetTotalMN_Internalname), ".", ",");
            AssignAttri("", false, "A838CPRetTotalMN", StringUtil.LTrimStr( A838CPRetTotalMN, 15, 2));
            A842CPRetRetMN = context.localUtil.CToN( cgiGet( edtCPRetRetMN_Internalname), ".", ",");
            AssignAttri("", false, "A842CPRetRetMN", StringUtil.LTrimStr( A842CPRetRetMN, 15, 2));
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
               A302CPRetCod = GetPar( "CPRetCod");
               AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
               A303CPRetPrvCod = GetPar( "CPRetPrvCod");
               AssignAttri("", false, "A303CPRetPrvCod", A303CPRetPrvCod);
               A304CPRetTipCod = GetPar( "CPRetTipCod");
               AssignAttri("", false, "A304CPRetTipCod", A304CPRetTipCod);
               A305CPRetComCod = GetPar( "CPRetComCod");
               AssignAttri("", false, "A305CPRetComCod", A305CPRetComCod);
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
               InitAll3N126( ) ;
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
         DisableAttributes3N126( ) ;
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

      protected void CONFIRM_3N0( )
      {
         BeforeValidate3N126( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3N126( ) ;
            }
            else
            {
               CheckExtendedTable3N126( ) ;
               if ( AnyError == 0 )
               {
                  ZM3N126( 5) ;
                  ZM3N126( 6) ;
                  ZM3N126( 7) ;
               }
               CloseExtendedTableCursors3N126( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3N0( ) ;
         }
      }

      protected void ResetCaption3N0( )
      {
      }

      protected void ZM3N126( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z843CPRetRet = T003N3_A843CPRetRet[0];
               Z839CPRetTotal = T003N3_A839CPRetTotal[0];
               Z844CPRetPor = T003N3_A844CPRetPor[0];
            }
            else
            {
               Z843CPRetRet = A843CPRetRet;
               Z839CPRetTotal = A839CPRetTotal;
               Z844CPRetPor = A844CPRetPor;
            }
         }
         if ( GX_JID == -4 )
         {
            Z843CPRetRet = A843CPRetRet;
            Z839CPRetTotal = A839CPRetTotal;
            Z844CPRetPor = A844CPRetPor;
            Z302CPRetCod = A302CPRetCod;
            Z304CPRetTipCod = A304CPRetTipCod;
            Z305CPRetComCod = A305CPRetComCod;
            Z303CPRetPrvCod = A303CPRetPrvCod;
            Z840CPRetTipCmb = A840CPRetTipCmb;
            Z849CPRetTipAbr = A849CPRetTipAbr;
            Z833CPRetComMon = A833CPRetComMon;
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

      protected void Load3N126( )
      {
         /* Using cursor T003N7 */
         pr_default.execute(5, new Object[] {A302CPRetCod, A303CPRetPrvCod, A304CPRetTipCod, A305CPRetComCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound126 = 1;
            A843CPRetRet = T003N7_A843CPRetRet[0];
            AssignAttri("", false, "A843CPRetRet", StringUtil.LTrimStr( A843CPRetRet, 15, 2));
            A849CPRetTipAbr = T003N7_A849CPRetTipAbr[0];
            A839CPRetTotal = T003N7_A839CPRetTotal[0];
            AssignAttri("", false, "A839CPRetTotal", StringUtil.LTrimStr( A839CPRetTotal, 15, 2));
            A844CPRetPor = T003N7_A844CPRetPor[0];
            AssignAttri("", false, "A844CPRetPor", StringUtil.LTrimStr( A844CPRetPor, 6, 2));
            A840CPRetTipCmb = T003N7_A840CPRetTipCmb[0];
            A833CPRetComMon = T003N7_A833CPRetComMon[0];
            AssignAttri("", false, "A833CPRetComMon", StringUtil.LTrimStr( (decimal)(A833CPRetComMon), 6, 0));
            ZM3N126( -4) ;
         }
         pr_default.close(5);
         OnLoadActions3N126( ) ;
      }

      protected void OnLoadActions3N126( )
      {
         A838CPRetTotalMN = ((A833CPRetComMon==2) ? NumberUtil.Round( A839CPRetTotal*A840CPRetTipCmb, 2) : A839CPRetTotal);
         AssignAttri("", false, "A838CPRetTotalMN", StringUtil.LTrimStr( A838CPRetTotalMN, 15, 2));
         A843CPRetRet = NumberUtil.Round( (A839CPRetTotal*A844CPRetPor)/ (decimal)(100), 2);
         AssignAttri("", false, "A843CPRetRet", StringUtil.LTrimStr( A843CPRetRet, 15, 2));
         A842CPRetRetMN = ((A833CPRetComMon==2) ? NumberUtil.Round( A843CPRetRet*A840CPRetTipCmb, 2) : A843CPRetRet);
         AssignAttri("", false, "A842CPRetRetMN", StringUtil.LTrimStr( A842CPRetRetMN, 15, 2));
      }

      protected void CheckExtendedTable3N126( )
      {
         nIsDirty_126 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T003N4 */
         pr_default.execute(2, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Retención'.", "ForeignKeyNotFound", 1, "CPRETCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A840CPRetTipCmb = T003N4_A840CPRetTipCmb[0];
         pr_default.close(2);
         /* Using cursor T003N6 */
         pr_default.execute(4, new Object[] {A304CPRetTipCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "CPRETTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A849CPRetTipAbr = T003N6_A849CPRetTipAbr[0];
         pr_default.close(4);
         /* Using cursor T003N5 */
         pr_default.execute(3, new Object[] {A304CPRetTipCod, A305CPRetComCod, A303CPRetPrvCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Retencion'.", "ForeignKeyNotFound", 1, "CPRETPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A833CPRetComMon = T003N5_A833CPRetComMon[0];
         AssignAttri("", false, "A833CPRetComMon", StringUtil.LTrimStr( (decimal)(A833CPRetComMon), 6, 0));
         pr_default.close(3);
         nIsDirty_126 = 1;
         A838CPRetTotalMN = ((A833CPRetComMon==2) ? NumberUtil.Round( A839CPRetTotal*A840CPRetTipCmb, 2) : A839CPRetTotal);
         AssignAttri("", false, "A838CPRetTotalMN", StringUtil.LTrimStr( A838CPRetTotalMN, 15, 2));
         nIsDirty_126 = 1;
         A843CPRetRet = NumberUtil.Round( (A839CPRetTotal*A844CPRetPor)/ (decimal)(100), 2);
         AssignAttri("", false, "A843CPRetRet", StringUtil.LTrimStr( A843CPRetRet, 15, 2));
         nIsDirty_126 = 1;
         A842CPRetRetMN = ((A833CPRetComMon==2) ? NumberUtil.Round( A843CPRetRet*A840CPRetTipCmb, 2) : A843CPRetRet);
         AssignAttri("", false, "A842CPRetRetMN", StringUtil.LTrimStr( A842CPRetRetMN, 15, 2));
      }

      protected void CloseExtendedTableCursors3N126( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( string A302CPRetCod )
      {
         /* Using cursor T003N8 */
         pr_default.execute(6, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Retención'.", "ForeignKeyNotFound", 1, "CPRETCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A840CPRetTipCmb = T003N8_A840CPRetTipCmb[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A840CPRetTipCmb, 15, 5, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_7( string A304CPRetTipCod )
      {
         /* Using cursor T003N9 */
         pr_default.execute(7, new Object[] {A304CPRetTipCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "CPRETTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A849CPRetTipAbr = T003N9_A849CPRetTipAbr[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A849CPRetTipAbr))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_6( string A304CPRetTipCod ,
                               string A305CPRetComCod ,
                               string A303CPRetPrvCod )
      {
         /* Using cursor T003N10 */
         pr_default.execute(8, new Object[] {A304CPRetTipCod, A305CPRetComCod, A303CPRetPrvCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Retencion'.", "ForeignKeyNotFound", 1, "CPRETPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A833CPRetComMon = T003N10_A833CPRetComMon[0];
         AssignAttri("", false, "A833CPRetComMon", StringUtil.LTrimStr( (decimal)(A833CPRetComMon), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A833CPRetComMon), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey3N126( )
      {
         /* Using cursor T003N11 */
         pr_default.execute(9, new Object[] {A302CPRetCod, A303CPRetPrvCod, A304CPRetTipCod, A305CPRetComCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound126 = 1;
         }
         else
         {
            RcdFound126 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003N3 */
         pr_default.execute(1, new Object[] {A302CPRetCod, A303CPRetPrvCod, A304CPRetTipCod, A305CPRetComCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3N126( 4) ;
            RcdFound126 = 1;
            A843CPRetRet = T003N3_A843CPRetRet[0];
            AssignAttri("", false, "A843CPRetRet", StringUtil.LTrimStr( A843CPRetRet, 15, 2));
            A839CPRetTotal = T003N3_A839CPRetTotal[0];
            AssignAttri("", false, "A839CPRetTotal", StringUtil.LTrimStr( A839CPRetTotal, 15, 2));
            A844CPRetPor = T003N3_A844CPRetPor[0];
            AssignAttri("", false, "A844CPRetPor", StringUtil.LTrimStr( A844CPRetPor, 6, 2));
            A302CPRetCod = T003N3_A302CPRetCod[0];
            AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
            A304CPRetTipCod = T003N3_A304CPRetTipCod[0];
            AssignAttri("", false, "A304CPRetTipCod", A304CPRetTipCod);
            A305CPRetComCod = T003N3_A305CPRetComCod[0];
            AssignAttri("", false, "A305CPRetComCod", A305CPRetComCod);
            A303CPRetPrvCod = T003N3_A303CPRetPrvCod[0];
            AssignAttri("", false, "A303CPRetPrvCod", A303CPRetPrvCod);
            Z302CPRetCod = A302CPRetCod;
            Z303CPRetPrvCod = A303CPRetPrvCod;
            Z304CPRetTipCod = A304CPRetTipCod;
            Z305CPRetComCod = A305CPRetComCod;
            sMode126 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3N126( ) ;
            if ( AnyError == 1 )
            {
               RcdFound126 = 0;
               InitializeNonKey3N126( ) ;
            }
            Gx_mode = sMode126;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound126 = 0;
            InitializeNonKey3N126( ) ;
            sMode126 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode126;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3N126( ) ;
         if ( RcdFound126 == 0 )
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
         RcdFound126 = 0;
         /* Using cursor T003N12 */
         pr_default.execute(10, new Object[] {A302CPRetCod, A303CPRetPrvCod, A304CPRetTipCod, A305CPRetComCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T003N12_A302CPRetCod[0], A302CPRetCod) < 0 ) || ( StringUtil.StrCmp(T003N12_A302CPRetCod[0], A302CPRetCod) == 0 ) && ( StringUtil.StrCmp(T003N12_A303CPRetPrvCod[0], A303CPRetPrvCod) < 0 ) || ( StringUtil.StrCmp(T003N12_A303CPRetPrvCod[0], A303CPRetPrvCod) == 0 ) && ( StringUtil.StrCmp(T003N12_A302CPRetCod[0], A302CPRetCod) == 0 ) && ( StringUtil.StrCmp(T003N12_A304CPRetTipCod[0], A304CPRetTipCod) < 0 ) || ( StringUtil.StrCmp(T003N12_A304CPRetTipCod[0], A304CPRetTipCod) == 0 ) && ( StringUtil.StrCmp(T003N12_A303CPRetPrvCod[0], A303CPRetPrvCod) == 0 ) && ( StringUtil.StrCmp(T003N12_A302CPRetCod[0], A302CPRetCod) == 0 ) && ( StringUtil.StrCmp(T003N12_A305CPRetComCod[0], A305CPRetComCod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T003N12_A302CPRetCod[0], A302CPRetCod) > 0 ) || ( StringUtil.StrCmp(T003N12_A302CPRetCod[0], A302CPRetCod) == 0 ) && ( StringUtil.StrCmp(T003N12_A303CPRetPrvCod[0], A303CPRetPrvCod) > 0 ) || ( StringUtil.StrCmp(T003N12_A303CPRetPrvCod[0], A303CPRetPrvCod) == 0 ) && ( StringUtil.StrCmp(T003N12_A302CPRetCod[0], A302CPRetCod) == 0 ) && ( StringUtil.StrCmp(T003N12_A304CPRetTipCod[0], A304CPRetTipCod) > 0 ) || ( StringUtil.StrCmp(T003N12_A304CPRetTipCod[0], A304CPRetTipCod) == 0 ) && ( StringUtil.StrCmp(T003N12_A303CPRetPrvCod[0], A303CPRetPrvCod) == 0 ) && ( StringUtil.StrCmp(T003N12_A302CPRetCod[0], A302CPRetCod) == 0 ) && ( StringUtil.StrCmp(T003N12_A305CPRetComCod[0], A305CPRetComCod) > 0 ) ) )
            {
               A302CPRetCod = T003N12_A302CPRetCod[0];
               AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
               A303CPRetPrvCod = T003N12_A303CPRetPrvCod[0];
               AssignAttri("", false, "A303CPRetPrvCod", A303CPRetPrvCod);
               A304CPRetTipCod = T003N12_A304CPRetTipCod[0];
               AssignAttri("", false, "A304CPRetTipCod", A304CPRetTipCod);
               A305CPRetComCod = T003N12_A305CPRetComCod[0];
               AssignAttri("", false, "A305CPRetComCod", A305CPRetComCod);
               RcdFound126 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound126 = 0;
         /* Using cursor T003N13 */
         pr_default.execute(11, new Object[] {A302CPRetCod, A303CPRetPrvCod, A304CPRetTipCod, A305CPRetComCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T003N13_A302CPRetCod[0], A302CPRetCod) > 0 ) || ( StringUtil.StrCmp(T003N13_A302CPRetCod[0], A302CPRetCod) == 0 ) && ( StringUtil.StrCmp(T003N13_A303CPRetPrvCod[0], A303CPRetPrvCod) > 0 ) || ( StringUtil.StrCmp(T003N13_A303CPRetPrvCod[0], A303CPRetPrvCod) == 0 ) && ( StringUtil.StrCmp(T003N13_A302CPRetCod[0], A302CPRetCod) == 0 ) && ( StringUtil.StrCmp(T003N13_A304CPRetTipCod[0], A304CPRetTipCod) > 0 ) || ( StringUtil.StrCmp(T003N13_A304CPRetTipCod[0], A304CPRetTipCod) == 0 ) && ( StringUtil.StrCmp(T003N13_A303CPRetPrvCod[0], A303CPRetPrvCod) == 0 ) && ( StringUtil.StrCmp(T003N13_A302CPRetCod[0], A302CPRetCod) == 0 ) && ( StringUtil.StrCmp(T003N13_A305CPRetComCod[0], A305CPRetComCod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T003N13_A302CPRetCod[0], A302CPRetCod) < 0 ) || ( StringUtil.StrCmp(T003N13_A302CPRetCod[0], A302CPRetCod) == 0 ) && ( StringUtil.StrCmp(T003N13_A303CPRetPrvCod[0], A303CPRetPrvCod) < 0 ) || ( StringUtil.StrCmp(T003N13_A303CPRetPrvCod[0], A303CPRetPrvCod) == 0 ) && ( StringUtil.StrCmp(T003N13_A302CPRetCod[0], A302CPRetCod) == 0 ) && ( StringUtil.StrCmp(T003N13_A304CPRetTipCod[0], A304CPRetTipCod) < 0 ) || ( StringUtil.StrCmp(T003N13_A304CPRetTipCod[0], A304CPRetTipCod) == 0 ) && ( StringUtil.StrCmp(T003N13_A303CPRetPrvCod[0], A303CPRetPrvCod) == 0 ) && ( StringUtil.StrCmp(T003N13_A302CPRetCod[0], A302CPRetCod) == 0 ) && ( StringUtil.StrCmp(T003N13_A305CPRetComCod[0], A305CPRetComCod) < 0 ) ) )
            {
               A302CPRetCod = T003N13_A302CPRetCod[0];
               AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
               A303CPRetPrvCod = T003N13_A303CPRetPrvCod[0];
               AssignAttri("", false, "A303CPRetPrvCod", A303CPRetPrvCod);
               A304CPRetTipCod = T003N13_A304CPRetTipCod[0];
               AssignAttri("", false, "A304CPRetTipCod", A304CPRetTipCod);
               A305CPRetComCod = T003N13_A305CPRetComCod[0];
               AssignAttri("", false, "A305CPRetComCod", A305CPRetComCod);
               RcdFound126 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3N126( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCPRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3N126( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound126 == 1 )
            {
               if ( ( StringUtil.StrCmp(A302CPRetCod, Z302CPRetCod) != 0 ) || ( StringUtil.StrCmp(A303CPRetPrvCod, Z303CPRetPrvCod) != 0 ) || ( StringUtil.StrCmp(A304CPRetTipCod, Z304CPRetTipCod) != 0 ) || ( StringUtil.StrCmp(A305CPRetComCod, Z305CPRetComCod) != 0 ) )
               {
                  A302CPRetCod = Z302CPRetCod;
                  AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
                  A303CPRetPrvCod = Z303CPRetPrvCod;
                  AssignAttri("", false, "A303CPRetPrvCod", A303CPRetPrvCod);
                  A304CPRetTipCod = Z304CPRetTipCod;
                  AssignAttri("", false, "A304CPRetTipCod", A304CPRetTipCod);
                  A305CPRetComCod = Z305CPRetComCod;
                  AssignAttri("", false, "A305CPRetComCod", A305CPRetComCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CPRETCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCPRetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCPRetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3N126( ) ;
                  GX_FocusControl = edtCPRetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A302CPRetCod, Z302CPRetCod) != 0 ) || ( StringUtil.StrCmp(A303CPRetPrvCod, Z303CPRetPrvCod) != 0 ) || ( StringUtil.StrCmp(A304CPRetTipCod, Z304CPRetTipCod) != 0 ) || ( StringUtil.StrCmp(A305CPRetComCod, Z305CPRetComCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCPRetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3N126( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CPRETCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCPRetCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCPRetCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3N126( ) ;
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
         if ( ( StringUtil.StrCmp(A302CPRetCod, Z302CPRetCod) != 0 ) || ( StringUtil.StrCmp(A303CPRetPrvCod, Z303CPRetPrvCod) != 0 ) || ( StringUtil.StrCmp(A304CPRetTipCod, Z304CPRetTipCod) != 0 ) || ( StringUtil.StrCmp(A305CPRetComCod, Z305CPRetComCod) != 0 ) )
         {
            A302CPRetCod = Z302CPRetCod;
            AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
            A303CPRetPrvCod = Z303CPRetPrvCod;
            AssignAttri("", false, "A303CPRetPrvCod", A303CPRetPrvCod);
            A304CPRetTipCod = Z304CPRetTipCod;
            AssignAttri("", false, "A304CPRetTipCod", A304CPRetTipCod);
            A305CPRetComCod = Z305CPRetComCod;
            AssignAttri("", false, "A305CPRetComCod", A305CPRetComCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CPRETCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCPRetCod_Internalname;
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
         GetKey3N126( ) ;
         if ( RcdFound126 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CPRETCOD");
               AnyError = 1;
               GX_FocusControl = edtCPRetCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A302CPRetCod, Z302CPRetCod) != 0 ) || ( StringUtil.StrCmp(A303CPRetPrvCod, Z303CPRetPrvCod) != 0 ) || ( StringUtil.StrCmp(A304CPRetTipCod, Z304CPRetTipCod) != 0 ) || ( StringUtil.StrCmp(A305CPRetComCod, Z305CPRetComCod) != 0 ) )
            {
               A302CPRetCod = Z302CPRetCod;
               AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
               A303CPRetPrvCod = Z303CPRetPrvCod;
               AssignAttri("", false, "A303CPRetPrvCod", A303CPRetPrvCod);
               A304CPRetTipCod = Z304CPRetTipCod;
               AssignAttri("", false, "A304CPRetTipCod", A304CPRetTipCod);
               A305CPRetComCod = Z305CPRetComCod;
               AssignAttri("", false, "A305CPRetComCod", A305CPRetComCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CPRETCOD");
               AnyError = 1;
               GX_FocusControl = edtCPRetCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A302CPRetCod, Z302CPRetCod) != 0 ) || ( StringUtil.StrCmp(A303CPRetPrvCod, Z303CPRetPrvCod) != 0 ) || ( StringUtil.StrCmp(A304CPRetTipCod, Z304CPRetTipCod) != 0 ) || ( StringUtil.StrCmp(A305CPRetComCod, Z305CPRetComCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CPRETCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCPRetCod_Internalname;
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
         context.RollbackDataStores("cpretenciondet",pr_default);
         GX_FocusControl = edtCPRetTotal_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3N0( ) ;
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
         if ( RcdFound126 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CPRETCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCPRetTotal_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3N126( ) ;
         if ( RcdFound126 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPRetTotal_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3N126( ) ;
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
         if ( RcdFound126 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPRetTotal_Internalname;
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
         if ( RcdFound126 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPRetTotal_Internalname;
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
         ScanStart3N126( ) ;
         if ( RcdFound126 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound126 != 0 )
            {
               ScanNext3N126( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPRetTotal_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3N126( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3N126( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003N2 */
            pr_default.execute(0, new Object[] {A302CPRetCod, A303CPRetPrvCod, A304CPRetTipCod, A305CPRetComCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPRETENCIONDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z843CPRetRet != T003N2_A843CPRetRet[0] ) || ( Z839CPRetTotal != T003N2_A839CPRetTotal[0] ) || ( Z844CPRetPor != T003N2_A844CPRetPor[0] ) )
            {
               if ( Z843CPRetRet != T003N2_A843CPRetRet[0] )
               {
                  GXUtil.WriteLog("cpretenciondet:[seudo value changed for attri]"+"CPRetRet");
                  GXUtil.WriteLogRaw("Old: ",Z843CPRetRet);
                  GXUtil.WriteLogRaw("Current: ",T003N2_A843CPRetRet[0]);
               }
               if ( Z839CPRetTotal != T003N2_A839CPRetTotal[0] )
               {
                  GXUtil.WriteLog("cpretenciondet:[seudo value changed for attri]"+"CPRetTotal");
                  GXUtil.WriteLogRaw("Old: ",Z839CPRetTotal);
                  GXUtil.WriteLogRaw("Current: ",T003N2_A839CPRetTotal[0]);
               }
               if ( Z844CPRetPor != T003N2_A844CPRetPor[0] )
               {
                  GXUtil.WriteLog("cpretenciondet:[seudo value changed for attri]"+"CPRetPor");
                  GXUtil.WriteLogRaw("Old: ",Z844CPRetPor);
                  GXUtil.WriteLogRaw("Current: ",T003N2_A844CPRetPor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPRETENCIONDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3N126( )
      {
         BeforeValidate3N126( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3N126( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3N126( 0) ;
            CheckOptimisticConcurrency3N126( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3N126( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3N126( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003N14 */
                     pr_default.execute(12, new Object[] {A843CPRetRet, A839CPRetTotal, A844CPRetPor, A302CPRetCod, A304CPRetTipCod, A305CPRetComCod, A303CPRetPrvCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("CPRETENCIONDET");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ResetCaption3N0( ) ;
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
               Load3N126( ) ;
            }
            EndLevel3N126( ) ;
         }
         CloseExtendedTableCursors3N126( ) ;
      }

      protected void Update3N126( )
      {
         BeforeValidate3N126( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3N126( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3N126( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3N126( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3N126( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003N15 */
                     pr_default.execute(13, new Object[] {A843CPRetRet, A839CPRetTotal, A844CPRetPor, A302CPRetCod, A303CPRetPrvCod, A304CPRetTipCod, A305CPRetComCod});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("CPRETENCIONDET");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPRETENCIONDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3N126( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3N0( ) ;
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
            EndLevel3N126( ) ;
         }
         CloseExtendedTableCursors3N126( ) ;
      }

      protected void DeferredUpdate3N126( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3N126( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3N126( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3N126( ) ;
            AfterConfirm3N126( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3N126( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003N16 */
                  pr_default.execute(14, new Object[] {A302CPRetCod, A303CPRetPrvCod, A304CPRetTipCod, A305CPRetComCod});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("CPRETENCIONDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound126 == 0 )
                        {
                           InitAll3N126( ) ;
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
                        ResetCaption3N0( ) ;
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
         sMode126 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3N126( ) ;
         Gx_mode = sMode126;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3N126( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003N17 */
            pr_default.execute(15, new Object[] {A302CPRetCod});
            A840CPRetTipCmb = T003N17_A840CPRetTipCmb[0];
            pr_default.close(15);
            /* Using cursor T003N18 */
            pr_default.execute(16, new Object[] {A304CPRetTipCod});
            A849CPRetTipAbr = T003N18_A849CPRetTipAbr[0];
            pr_default.close(16);
            /* Using cursor T003N19 */
            pr_default.execute(17, new Object[] {A304CPRetTipCod, A305CPRetComCod, A303CPRetPrvCod});
            A833CPRetComMon = T003N19_A833CPRetComMon[0];
            AssignAttri("", false, "A833CPRetComMon", StringUtil.LTrimStr( (decimal)(A833CPRetComMon), 6, 0));
            pr_default.close(17);
            A838CPRetTotalMN = ((A833CPRetComMon==2) ? NumberUtil.Round( A839CPRetTotal*A840CPRetTipCmb, 2) : A839CPRetTotal);
            AssignAttri("", false, "A838CPRetTotalMN", StringUtil.LTrimStr( A838CPRetTotalMN, 15, 2));
            A842CPRetRetMN = ((A833CPRetComMon==2) ? NumberUtil.Round( A843CPRetRet*A840CPRetTipCmb, 2) : A843CPRetRet);
            AssignAttri("", false, "A842CPRetRetMN", StringUtil.LTrimStr( A842CPRetRetMN, 15, 2));
         }
      }

      protected void EndLevel3N126( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3N126( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(17);
            pr_default.close(16);
            context.CommitDataStores("cpretenciondet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(17);
            pr_default.close(16);
            context.RollbackDataStores("cpretenciondet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3N126( )
      {
         /* Using cursor T003N20 */
         pr_default.execute(18);
         RcdFound126 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound126 = 1;
            A302CPRetCod = T003N20_A302CPRetCod[0];
            AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
            A303CPRetPrvCod = T003N20_A303CPRetPrvCod[0];
            AssignAttri("", false, "A303CPRetPrvCod", A303CPRetPrvCod);
            A304CPRetTipCod = T003N20_A304CPRetTipCod[0];
            AssignAttri("", false, "A304CPRetTipCod", A304CPRetTipCod);
            A305CPRetComCod = T003N20_A305CPRetComCod[0];
            AssignAttri("", false, "A305CPRetComCod", A305CPRetComCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3N126( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound126 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound126 = 1;
            A302CPRetCod = T003N20_A302CPRetCod[0];
            AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
            A303CPRetPrvCod = T003N20_A303CPRetPrvCod[0];
            AssignAttri("", false, "A303CPRetPrvCod", A303CPRetPrvCod);
            A304CPRetTipCod = T003N20_A304CPRetTipCod[0];
            AssignAttri("", false, "A304CPRetTipCod", A304CPRetTipCod);
            A305CPRetComCod = T003N20_A305CPRetComCod[0];
            AssignAttri("", false, "A305CPRetComCod", A305CPRetComCod);
         }
      }

      protected void ScanEnd3N126( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm3N126( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3N126( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3N126( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3N126( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3N126( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3N126( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3N126( )
      {
         edtCPRetCod_Enabled = 0;
         AssignProp("", false, edtCPRetCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetCod_Enabled), 5, 0), true);
         edtCPRetPrvCod_Enabled = 0;
         AssignProp("", false, edtCPRetPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetPrvCod_Enabled), 5, 0), true);
         edtCPRetTipCod_Enabled = 0;
         AssignProp("", false, edtCPRetTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetTipCod_Enabled), 5, 0), true);
         edtCPRetComCod_Enabled = 0;
         AssignProp("", false, edtCPRetComCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetComCod_Enabled), 5, 0), true);
         edtCPRetComMon_Enabled = 0;
         AssignProp("", false, edtCPRetComMon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetComMon_Enabled), 5, 0), true);
         edtCPRetTotal_Enabled = 0;
         AssignProp("", false, edtCPRetTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetTotal_Enabled), 5, 0), true);
         edtCPRetRet_Enabled = 0;
         AssignProp("", false, edtCPRetRet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetRet_Enabled), 5, 0), true);
         edtCPRetPor_Enabled = 0;
         AssignProp("", false, edtCPRetPor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetPor_Enabled), 5, 0), true);
         edtCPRetTotalMN_Enabled = 0;
         AssignProp("", false, edtCPRetTotalMN_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetTotalMN_Enabled), 5, 0), true);
         edtCPRetRetMN_Enabled = 0;
         AssignProp("", false, edtCPRetRetMN_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetRetMN_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3N126( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3N0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025177", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cpretenciondet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z302CPRetCod", StringUtil.RTrim( Z302CPRetCod));
         GxWebStd.gx_hidden_field( context, "Z303CPRetPrvCod", StringUtil.RTrim( Z303CPRetPrvCod));
         GxWebStd.gx_hidden_field( context, "Z304CPRetTipCod", StringUtil.RTrim( Z304CPRetTipCod));
         GxWebStd.gx_hidden_field( context, "Z305CPRetComCod", StringUtil.RTrim( Z305CPRetComCod));
         GxWebStd.gx_hidden_field( context, "Z843CPRetRet", StringUtil.LTrim( StringUtil.NToC( Z843CPRetRet, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z839CPRetTotal", StringUtil.LTrim( StringUtil.NToC( Z839CPRetTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z844CPRetPor", StringUtil.LTrim( StringUtil.NToC( Z844CPRetPor, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "CPRETTIPCMB", StringUtil.LTrim( StringUtil.NToC( A840CPRetTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "CPRETTIPABR", StringUtil.RTrim( A849CPRetTipAbr));
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
         return formatLink("cpretenciondet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPRETENCIONDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Retención Detalle" ;
      }

      protected void InitializeNonKey3N126( )
      {
         A843CPRetRet = 0;
         AssignAttri("", false, "A843CPRetRet", StringUtil.LTrimStr( A843CPRetRet, 15, 2));
         A838CPRetTotalMN = 0;
         AssignAttri("", false, "A838CPRetTotalMN", StringUtil.LTrimStr( A838CPRetTotalMN, 15, 2));
         A842CPRetRetMN = 0;
         AssignAttri("", false, "A842CPRetRetMN", StringUtil.LTrimStr( A842CPRetRetMN, 15, 2));
         A833CPRetComMon = 0;
         AssignAttri("", false, "A833CPRetComMon", StringUtil.LTrimStr( (decimal)(A833CPRetComMon), 6, 0));
         A849CPRetTipAbr = "";
         AssignAttri("", false, "A849CPRetTipAbr", A849CPRetTipAbr);
         A839CPRetTotal = 0;
         AssignAttri("", false, "A839CPRetTotal", StringUtil.LTrimStr( A839CPRetTotal, 15, 2));
         A844CPRetPor = 0;
         AssignAttri("", false, "A844CPRetPor", StringUtil.LTrimStr( A844CPRetPor, 6, 2));
         A840CPRetTipCmb = 0;
         AssignAttri("", false, "A840CPRetTipCmb", StringUtil.LTrimStr( A840CPRetTipCmb, 15, 5));
         Z843CPRetRet = 0;
         Z839CPRetTotal = 0;
         Z844CPRetPor = 0;
      }

      protected void InitAll3N126( )
      {
         A302CPRetCod = "";
         AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
         A303CPRetPrvCod = "";
         AssignAttri("", false, "A303CPRetPrvCod", A303CPRetPrvCod);
         A304CPRetTipCod = "";
         AssignAttri("", false, "A304CPRetTipCod", A304CPRetTipCod);
         A305CPRetComCod = "";
         AssignAttri("", false, "A305CPRetComCod", A305CPRetComCod);
         InitializeNonKey3N126( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810251715", true, true);
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
         context.AddJavascriptSource("cpretenciondet.js", "?202281810251716", false, true);
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
         edtCPRetCod_Internalname = "CPRETCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCPRetPrvCod_Internalname = "CPRETPRVCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtCPRetTipCod_Internalname = "CPRETTIPCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCPRetComCod_Internalname = "CPRETCOMCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtCPRetComMon_Internalname = "CPRETCOMMON";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCPRetTotal_Internalname = "CPRETTOTAL";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtCPRetRet_Internalname = "CPRETRET";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtCPRetPor_Internalname = "CPRETPOR";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtCPRetTotalMN_Internalname = "CPRETTOTALMN";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtCPRetRetMN_Internalname = "CPRETRETMN";
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
         Form.Caption = "Retención Detalle";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCPRetRetMN_Jsonclick = "";
         edtCPRetRetMN_Enabled = 0;
         edtCPRetTotalMN_Jsonclick = "";
         edtCPRetTotalMN_Enabled = 0;
         edtCPRetPor_Jsonclick = "";
         edtCPRetPor_Enabled = 1;
         edtCPRetRet_Jsonclick = "";
         edtCPRetRet_Enabled = 0;
         edtCPRetTotal_Jsonclick = "";
         edtCPRetTotal_Enabled = 1;
         edtCPRetComMon_Jsonclick = "";
         edtCPRetComMon_Enabled = 0;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCPRetComCod_Jsonclick = "";
         edtCPRetComCod_Enabled = 1;
         edtCPRetTipCod_Jsonclick = "";
         edtCPRetTipCod_Enabled = 1;
         edtCPRetPrvCod_Jsonclick = "";
         edtCPRetPrvCod_Enabled = 1;
         edtCPRetCod_Jsonclick = "";
         edtCPRetCod_Enabled = 1;
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
         /* Using cursor T003N17 */
         pr_default.execute(15, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Retención'.", "ForeignKeyNotFound", 1, "CPRETCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A840CPRetTipCmb = T003N17_A840CPRetTipCmb[0];
         pr_default.close(15);
         /* Using cursor T003N18 */
         pr_default.execute(16, new Object[] {A304CPRetTipCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "CPRETTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A849CPRetTipAbr = T003N18_A849CPRetTipAbr[0];
         pr_default.close(16);
         /* Using cursor T003N19 */
         pr_default.execute(17, new Object[] {A304CPRetTipCod, A305CPRetComCod, A303CPRetPrvCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Retencion'.", "ForeignKeyNotFound", 1, "CPRETPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A833CPRetComMon = T003N19_A833CPRetComMon[0];
         AssignAttri("", false, "A833CPRetComMon", StringUtil.LTrimStr( (decimal)(A833CPRetComMon), 6, 0));
         pr_default.close(17);
         GX_FocusControl = edtCPRetTotal_Internalname;
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

      public void Valid_Cpretcod( )
      {
         /* Using cursor T003N17 */
         pr_default.execute(15, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Retención'.", "ForeignKeyNotFound", 1, "CPRETCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetCod_Internalname;
         }
         A840CPRetTipCmb = T003N17_A840CPRetTipCmb[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A840CPRetTipCmb", StringUtil.LTrim( StringUtil.NToC( A840CPRetTipCmb, 15, 5, ".", "")));
      }

      public void Valid_Cprettipcod( )
      {
         /* Using cursor T003N18 */
         pr_default.execute(16, new Object[] {A304CPRetTipCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "CPRETTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetTipCod_Internalname;
         }
         A849CPRetTipAbr = T003N18_A849CPRetTipAbr[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A849CPRetTipAbr", StringUtil.RTrim( A849CPRetTipAbr));
      }

      public void Valid_Cpretcomcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T003N19 */
         pr_default.execute(17, new Object[] {A304CPRetTipCod, A305CPRetComCod, A303CPRetPrvCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Retencion'.", "ForeignKeyNotFound", 1, "CPRETPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetTipCod_Internalname;
         }
         A833CPRetComMon = T003N19_A833CPRetComMon[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A839CPRetTotal", StringUtil.LTrim( StringUtil.NToC( A839CPRetTotal, 15, 2, ".", "")));
         AssignAttri("", false, "A844CPRetPor", StringUtil.LTrim( StringUtil.NToC( A844CPRetPor, 6, 2, ".", "")));
         AssignAttri("", false, "A840CPRetTipCmb", StringUtil.LTrim( StringUtil.NToC( A840CPRetTipCmb, 15, 5, ".", "")));
         AssignAttri("", false, "A849CPRetTipAbr", StringUtil.RTrim( A849CPRetTipAbr));
         AssignAttri("", false, "A833CPRetComMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(A833CPRetComMon), 6, 0, ".", "")));
         AssignAttri("", false, "A838CPRetTotalMN", StringUtil.LTrim( StringUtil.NToC( A838CPRetTotalMN, 15, 2, ".", "")));
         AssignAttri("", false, "A843CPRetRet", StringUtil.LTrim( StringUtil.NToC( A843CPRetRet, 15, 2, ".", "")));
         AssignAttri("", false, "A842CPRetRetMN", StringUtil.LTrim( StringUtil.NToC( A842CPRetRetMN, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z302CPRetCod", StringUtil.RTrim( Z302CPRetCod));
         GxWebStd.gx_hidden_field( context, "Z303CPRetPrvCod", StringUtil.RTrim( Z303CPRetPrvCod));
         GxWebStd.gx_hidden_field( context, "Z304CPRetTipCod", StringUtil.RTrim( Z304CPRetTipCod));
         GxWebStd.gx_hidden_field( context, "Z305CPRetComCod", StringUtil.RTrim( Z305CPRetComCod));
         GxWebStd.gx_hidden_field( context, "Z839CPRetTotal", StringUtil.LTrim( StringUtil.NToC( Z839CPRetTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z844CPRetPor", StringUtil.LTrim( StringUtil.NToC( Z844CPRetPor, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z840CPRetTipCmb", StringUtil.LTrim( StringUtil.NToC( Z840CPRetTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z849CPRetTipAbr", StringUtil.RTrim( Z849CPRetTipAbr));
         GxWebStd.gx_hidden_field( context, "Z833CPRetComMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z833CPRetComMon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z838CPRetTotalMN", StringUtil.LTrim( StringUtil.NToC( Z838CPRetTotalMN, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z843CPRetRet", StringUtil.LTrim( StringUtil.NToC( Z843CPRetRet, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z842CPRetRetMN", StringUtil.LTrim( StringUtil.NToC( Z842CPRetRetMN, 15, 2, ".", "")));
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
         setEventMetadata("VALID_CPRETCOD","{handler:'Valid_Cpretcod',iparms:[{av:'A302CPRetCod',fld:'CPRETCOD',pic:''},{av:'A840CPRetTipCmb',fld:'CPRETTIPCMB',pic:'ZZZZZZZZ9.99999'}]");
         setEventMetadata("VALID_CPRETCOD",",oparms:[{av:'A840CPRetTipCmb',fld:'CPRETTIPCMB',pic:'ZZZZZZZZ9.99999'}]}");
         setEventMetadata("VALID_CPRETPRVCOD","{handler:'Valid_Cpretprvcod',iparms:[]");
         setEventMetadata("VALID_CPRETPRVCOD",",oparms:[]}");
         setEventMetadata("VALID_CPRETTIPCOD","{handler:'Valid_Cprettipcod',iparms:[{av:'A304CPRetTipCod',fld:'CPRETTIPCOD',pic:''},{av:'A849CPRetTipAbr',fld:'CPRETTIPABR',pic:''}]");
         setEventMetadata("VALID_CPRETTIPCOD",",oparms:[{av:'A849CPRetTipAbr',fld:'CPRETTIPABR',pic:''}]}");
         setEventMetadata("VALID_CPRETCOMCOD","{handler:'Valid_Cpretcomcod',iparms:[{av:'A302CPRetCod',fld:'CPRETCOD',pic:''},{av:'A303CPRetPrvCod',fld:'CPRETPRVCOD',pic:'@!'},{av:'A304CPRetTipCod',fld:'CPRETTIPCOD',pic:''},{av:'A305CPRetComCod',fld:'CPRETCOMCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CPRETCOMCOD",",oparms:[{av:'A839CPRetTotal',fld:'CPRETTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A844CPRetPor',fld:'CPRETPOR',pic:'ZZ9.99'},{av:'A840CPRetTipCmb',fld:'CPRETTIPCMB',pic:'ZZZZZZZZ9.99999'},{av:'A849CPRetTipAbr',fld:'CPRETTIPABR',pic:''},{av:'A833CPRetComMon',fld:'CPRETCOMMON',pic:'ZZZZZ9'},{av:'A838CPRetTotalMN',fld:'CPRETTOTALMN',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A843CPRetRet',fld:'CPRETRET',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A842CPRetRetMN',fld:'CPRETRETMN',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z302CPRetCod'},{av:'Z303CPRetPrvCod'},{av:'Z304CPRetTipCod'},{av:'Z305CPRetComCod'},{av:'Z839CPRetTotal'},{av:'Z844CPRetPor'},{av:'Z840CPRetTipCmb'},{av:'Z849CPRetTipAbr'},{av:'Z833CPRetComMon'},{av:'Z838CPRetTotalMN'},{av:'Z843CPRetRet'},{av:'Z842CPRetRetMN'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CPRETCOMMON","{handler:'Valid_Cpretcommon',iparms:[]");
         setEventMetadata("VALID_CPRETCOMMON",",oparms:[]}");
         setEventMetadata("VALID_CPRETTOTAL","{handler:'Valid_Cprettotal',iparms:[]");
         setEventMetadata("VALID_CPRETTOTAL",",oparms:[]}");
         setEventMetadata("VALID_CPRETRET","{handler:'Valid_Cpretret',iparms:[]");
         setEventMetadata("VALID_CPRETRET",",oparms:[]}");
         setEventMetadata("VALID_CPRETPOR","{handler:'Valid_Cpretpor',iparms:[]");
         setEventMetadata("VALID_CPRETPOR",",oparms:[]}");
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
         pr_default.close(17);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z302CPRetCod = "";
         Z303CPRetPrvCod = "";
         Z304CPRetTipCod = "";
         Z305CPRetComCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A302CPRetCod = "";
         A304CPRetTipCod = "";
         A305CPRetComCod = "";
         A303CPRetPrvCod = "";
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
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         Gx_mode = "";
         A849CPRetTipAbr = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z849CPRetTipAbr = "";
         T003N7_A843CPRetRet = new decimal[1] ;
         T003N7_A849CPRetTipAbr = new string[] {""} ;
         T003N7_A839CPRetTotal = new decimal[1] ;
         T003N7_A844CPRetPor = new decimal[1] ;
         T003N7_A840CPRetTipCmb = new decimal[1] ;
         T003N7_A302CPRetCod = new string[] {""} ;
         T003N7_A304CPRetTipCod = new string[] {""} ;
         T003N7_A305CPRetComCod = new string[] {""} ;
         T003N7_A303CPRetPrvCod = new string[] {""} ;
         T003N7_A833CPRetComMon = new int[1] ;
         T003N4_A840CPRetTipCmb = new decimal[1] ;
         T003N6_A849CPRetTipAbr = new string[] {""} ;
         T003N5_A833CPRetComMon = new int[1] ;
         T003N8_A840CPRetTipCmb = new decimal[1] ;
         T003N9_A849CPRetTipAbr = new string[] {""} ;
         T003N10_A833CPRetComMon = new int[1] ;
         T003N11_A302CPRetCod = new string[] {""} ;
         T003N11_A303CPRetPrvCod = new string[] {""} ;
         T003N11_A304CPRetTipCod = new string[] {""} ;
         T003N11_A305CPRetComCod = new string[] {""} ;
         T003N3_A843CPRetRet = new decimal[1] ;
         T003N3_A839CPRetTotal = new decimal[1] ;
         T003N3_A844CPRetPor = new decimal[1] ;
         T003N3_A302CPRetCod = new string[] {""} ;
         T003N3_A304CPRetTipCod = new string[] {""} ;
         T003N3_A305CPRetComCod = new string[] {""} ;
         T003N3_A303CPRetPrvCod = new string[] {""} ;
         sMode126 = "";
         T003N12_A302CPRetCod = new string[] {""} ;
         T003N12_A303CPRetPrvCod = new string[] {""} ;
         T003N12_A304CPRetTipCod = new string[] {""} ;
         T003N12_A305CPRetComCod = new string[] {""} ;
         T003N13_A302CPRetCod = new string[] {""} ;
         T003N13_A303CPRetPrvCod = new string[] {""} ;
         T003N13_A304CPRetTipCod = new string[] {""} ;
         T003N13_A305CPRetComCod = new string[] {""} ;
         T003N2_A843CPRetRet = new decimal[1] ;
         T003N2_A839CPRetTotal = new decimal[1] ;
         T003N2_A844CPRetPor = new decimal[1] ;
         T003N2_A302CPRetCod = new string[] {""} ;
         T003N2_A304CPRetTipCod = new string[] {""} ;
         T003N2_A305CPRetComCod = new string[] {""} ;
         T003N2_A303CPRetPrvCod = new string[] {""} ;
         T003N17_A840CPRetTipCmb = new decimal[1] ;
         T003N18_A849CPRetTipAbr = new string[] {""} ;
         T003N19_A833CPRetComMon = new int[1] ;
         T003N20_A302CPRetCod = new string[] {""} ;
         T003N20_A303CPRetPrvCod = new string[] {""} ;
         T003N20_A304CPRetTipCod = new string[] {""} ;
         T003N20_A305CPRetComCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ302CPRetCod = "";
         ZZ303CPRetPrvCod = "";
         ZZ304CPRetTipCod = "";
         ZZ305CPRetComCod = "";
         ZZ849CPRetTipAbr = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpretenciondet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpretenciondet__default(),
            new Object[][] {
                new Object[] {
               T003N2_A843CPRetRet, T003N2_A839CPRetTotal, T003N2_A844CPRetPor, T003N2_A302CPRetCod, T003N2_A304CPRetTipCod, T003N2_A305CPRetComCod, T003N2_A303CPRetPrvCod
               }
               , new Object[] {
               T003N3_A843CPRetRet, T003N3_A839CPRetTotal, T003N3_A844CPRetPor, T003N3_A302CPRetCod, T003N3_A304CPRetTipCod, T003N3_A305CPRetComCod, T003N3_A303CPRetPrvCod
               }
               , new Object[] {
               T003N4_A840CPRetTipCmb
               }
               , new Object[] {
               T003N5_A833CPRetComMon
               }
               , new Object[] {
               T003N6_A849CPRetTipAbr
               }
               , new Object[] {
               T003N7_A843CPRetRet, T003N7_A849CPRetTipAbr, T003N7_A839CPRetTotal, T003N7_A844CPRetPor, T003N7_A840CPRetTipCmb, T003N7_A302CPRetCod, T003N7_A304CPRetTipCod, T003N7_A305CPRetComCod, T003N7_A303CPRetPrvCod, T003N7_A833CPRetComMon
               }
               , new Object[] {
               T003N8_A840CPRetTipCmb
               }
               , new Object[] {
               T003N9_A849CPRetTipAbr
               }
               , new Object[] {
               T003N10_A833CPRetComMon
               }
               , new Object[] {
               T003N11_A302CPRetCod, T003N11_A303CPRetPrvCod, T003N11_A304CPRetTipCod, T003N11_A305CPRetComCod
               }
               , new Object[] {
               T003N12_A302CPRetCod, T003N12_A303CPRetPrvCod, T003N12_A304CPRetTipCod, T003N12_A305CPRetComCod
               }
               , new Object[] {
               T003N13_A302CPRetCod, T003N13_A303CPRetPrvCod, T003N13_A304CPRetTipCod, T003N13_A305CPRetComCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003N17_A840CPRetTipCmb
               }
               , new Object[] {
               T003N18_A849CPRetTipAbr
               }
               , new Object[] {
               T003N19_A833CPRetComMon
               }
               , new Object[] {
               T003N20_A302CPRetCod, T003N20_A303CPRetPrvCod, T003N20_A304CPRetTipCod, T003N20_A305CPRetComCod
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
      private short RcdFound126 ;
      private short nIsDirty_126 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCPRetCod_Enabled ;
      private int edtCPRetPrvCod_Enabled ;
      private int edtCPRetTipCod_Enabled ;
      private int edtCPRetComCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int A833CPRetComMon ;
      private int edtCPRetComMon_Enabled ;
      private int edtCPRetTotal_Enabled ;
      private int edtCPRetRet_Enabled ;
      private int edtCPRetPor_Enabled ;
      private int edtCPRetTotalMN_Enabled ;
      private int edtCPRetRetMN_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int Z833CPRetComMon ;
      private int idxLst ;
      private int ZZ833CPRetComMon ;
      private decimal Z843CPRetRet ;
      private decimal Z839CPRetTotal ;
      private decimal Z844CPRetPor ;
      private decimal A839CPRetTotal ;
      private decimal A843CPRetRet ;
      private decimal A844CPRetPor ;
      private decimal A838CPRetTotalMN ;
      private decimal A842CPRetRetMN ;
      private decimal A840CPRetTipCmb ;
      private decimal Z840CPRetTipCmb ;
      private decimal Z838CPRetTotalMN ;
      private decimal Z842CPRetRetMN ;
      private decimal ZZ839CPRetTotal ;
      private decimal ZZ844CPRetPor ;
      private decimal ZZ840CPRetTipCmb ;
      private decimal ZZ838CPRetTotalMN ;
      private decimal ZZ843CPRetRet ;
      private decimal ZZ842CPRetRetMN ;
      private string sPrefix ;
      private string Z302CPRetCod ;
      private string Z303CPRetPrvCod ;
      private string Z304CPRetTipCod ;
      private string Z305CPRetComCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A302CPRetCod ;
      private string A304CPRetTipCod ;
      private string A305CPRetComCod ;
      private string A303CPRetPrvCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCPRetCod_Internalname ;
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
      private string edtCPRetCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCPRetPrvCod_Internalname ;
      private string edtCPRetPrvCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtCPRetTipCod_Internalname ;
      private string edtCPRetTipCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCPRetComCod_Internalname ;
      private string edtCPRetComCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtCPRetComMon_Internalname ;
      private string edtCPRetComMon_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtCPRetTotal_Internalname ;
      private string edtCPRetTotal_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtCPRetRet_Internalname ;
      private string edtCPRetRet_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtCPRetPor_Internalname ;
      private string edtCPRetPor_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtCPRetTotalMN_Internalname ;
      private string edtCPRetTotalMN_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtCPRetRetMN_Internalname ;
      private string edtCPRetRetMN_Jsonclick ;
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
      private string A849CPRetTipAbr ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z849CPRetTipAbr ;
      private string sMode126 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ302CPRetCod ;
      private string ZZ303CPRetPrvCod ;
      private string ZZ304CPRetTipCod ;
      private string ZZ305CPRetComCod ;
      private string ZZ849CPRetTipAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T003N7_A843CPRetRet ;
      private string[] T003N7_A849CPRetTipAbr ;
      private decimal[] T003N7_A839CPRetTotal ;
      private decimal[] T003N7_A844CPRetPor ;
      private decimal[] T003N7_A840CPRetTipCmb ;
      private string[] T003N7_A302CPRetCod ;
      private string[] T003N7_A304CPRetTipCod ;
      private string[] T003N7_A305CPRetComCod ;
      private string[] T003N7_A303CPRetPrvCod ;
      private int[] T003N7_A833CPRetComMon ;
      private decimal[] T003N4_A840CPRetTipCmb ;
      private string[] T003N6_A849CPRetTipAbr ;
      private int[] T003N5_A833CPRetComMon ;
      private decimal[] T003N8_A840CPRetTipCmb ;
      private string[] T003N9_A849CPRetTipAbr ;
      private int[] T003N10_A833CPRetComMon ;
      private string[] T003N11_A302CPRetCod ;
      private string[] T003N11_A303CPRetPrvCod ;
      private string[] T003N11_A304CPRetTipCod ;
      private string[] T003N11_A305CPRetComCod ;
      private decimal[] T003N3_A843CPRetRet ;
      private decimal[] T003N3_A839CPRetTotal ;
      private decimal[] T003N3_A844CPRetPor ;
      private string[] T003N3_A302CPRetCod ;
      private string[] T003N3_A304CPRetTipCod ;
      private string[] T003N3_A305CPRetComCod ;
      private string[] T003N3_A303CPRetPrvCod ;
      private string[] T003N12_A302CPRetCod ;
      private string[] T003N12_A303CPRetPrvCod ;
      private string[] T003N12_A304CPRetTipCod ;
      private string[] T003N12_A305CPRetComCod ;
      private string[] T003N13_A302CPRetCod ;
      private string[] T003N13_A303CPRetPrvCod ;
      private string[] T003N13_A304CPRetTipCod ;
      private string[] T003N13_A305CPRetComCod ;
      private decimal[] T003N2_A843CPRetRet ;
      private decimal[] T003N2_A839CPRetTotal ;
      private decimal[] T003N2_A844CPRetPor ;
      private string[] T003N2_A302CPRetCod ;
      private string[] T003N2_A304CPRetTipCod ;
      private string[] T003N2_A305CPRetComCod ;
      private string[] T003N2_A303CPRetPrvCod ;
      private decimal[] T003N17_A840CPRetTipCmb ;
      private string[] T003N18_A849CPRetTipAbr ;
      private int[] T003N19_A833CPRetComMon ;
      private string[] T003N20_A302CPRetCod ;
      private string[] T003N20_A303CPRetPrvCod ;
      private string[] T003N20_A304CPRetTipCod ;
      private string[] T003N20_A305CPRetComCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpretenciondet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpretenciondet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT003N7;
        prmT003N7 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0) ,
        new ParDef("@CPRetPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPRetTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPRetComCod",GXType.NChar,15,0)
        };
        Object[] prmT003N4;
        prmT003N4 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003N6;
        prmT003N6 = new Object[] {
        new ParDef("@CPRetTipCod",GXType.NChar,3,0)
        };
        Object[] prmT003N5;
        prmT003N5 = new Object[] {
        new ParDef("@CPRetTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPRetComCod",GXType.NChar,15,0) ,
        new ParDef("@CPRetPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003N8;
        prmT003N8 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003N9;
        prmT003N9 = new Object[] {
        new ParDef("@CPRetTipCod",GXType.NChar,3,0)
        };
        Object[] prmT003N10;
        prmT003N10 = new Object[] {
        new ParDef("@CPRetTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPRetComCod",GXType.NChar,15,0) ,
        new ParDef("@CPRetPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003N11;
        prmT003N11 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0) ,
        new ParDef("@CPRetPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPRetTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPRetComCod",GXType.NChar,15,0)
        };
        Object[] prmT003N3;
        prmT003N3 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0) ,
        new ParDef("@CPRetPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPRetTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPRetComCod",GXType.NChar,15,0)
        };
        Object[] prmT003N12;
        prmT003N12 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0) ,
        new ParDef("@CPRetPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPRetTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPRetComCod",GXType.NChar,15,0)
        };
        Object[] prmT003N13;
        prmT003N13 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0) ,
        new ParDef("@CPRetPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPRetTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPRetComCod",GXType.NChar,15,0)
        };
        Object[] prmT003N2;
        prmT003N2 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0) ,
        new ParDef("@CPRetPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPRetTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPRetComCod",GXType.NChar,15,0)
        };
        Object[] prmT003N14;
        prmT003N14 = new Object[] {
        new ParDef("@CPRetRet",GXType.Decimal,15,2) ,
        new ParDef("@CPRetTotal",GXType.Decimal,15,2) ,
        new ParDef("@CPRetPor",GXType.Decimal,6,2) ,
        new ParDef("@CPRetCod",GXType.NChar,10,0) ,
        new ParDef("@CPRetTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPRetComCod",GXType.NChar,15,0) ,
        new ParDef("@CPRetPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003N15;
        prmT003N15 = new Object[] {
        new ParDef("@CPRetRet",GXType.Decimal,15,2) ,
        new ParDef("@CPRetTotal",GXType.Decimal,15,2) ,
        new ParDef("@CPRetPor",GXType.Decimal,6,2) ,
        new ParDef("@CPRetCod",GXType.NChar,10,0) ,
        new ParDef("@CPRetPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPRetTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPRetComCod",GXType.NChar,15,0)
        };
        Object[] prmT003N16;
        prmT003N16 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0) ,
        new ParDef("@CPRetPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPRetTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPRetComCod",GXType.NChar,15,0)
        };
        Object[] prmT003N20;
        prmT003N20 = new Object[] {
        };
        Object[] prmT003N17;
        prmT003N17 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003N18;
        prmT003N18 = new Object[] {
        new ParDef("@CPRetTipCod",GXType.NChar,3,0)
        };
        Object[] prmT003N19;
        prmT003N19 = new Object[] {
        new ParDef("@CPRetTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPRetComCod",GXType.NChar,15,0) ,
        new ParDef("@CPRetPrvCod",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("T003N2", "SELECT [CPRetRet], [CPRetTotal], [CPRetPor], [CPRetCod], [CPRetTipCod] AS CPRetTipCod, [CPRetComCod] AS CPRetComCod, [CPRetPrvCod] AS CPRetPrvCod FROM [CPRETENCIONDET] WITH (UPDLOCK) WHERE [CPRetCod] = @CPRetCod AND [CPRetPrvCod] = @CPRetPrvCod AND [CPRetTipCod] = @CPRetTipCod AND [CPRetComCod] = @CPRetComCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003N3", "SELECT [CPRetRet], [CPRetTotal], [CPRetPor], [CPRetCod], [CPRetTipCod] AS CPRetTipCod, [CPRetComCod] AS CPRetComCod, [CPRetPrvCod] AS CPRetPrvCod FROM [CPRETENCIONDET] WHERE [CPRetCod] = @CPRetCod AND [CPRetPrvCod] = @CPRetPrvCod AND [CPRetTipCod] = @CPRetTipCod AND [CPRetComCod] = @CPRetComCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003N4", "SELECT [CPRetTipCmb] FROM [CPRETENCION] WHERE [CPRetCod] = @CPRetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003N4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003N5", "SELECT [CPMonCod] AS CPRetComMon FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @CPRetTipCod AND [CPComCod] = @CPRetComCod AND [CPPrvCod] = @CPRetPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003N5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003N6", "SELECT [TipAbr] AS CPRetTipAbr FROM [CTIPDOC] WHERE [TipCod] = @CPRetTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003N6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003N7", "SELECT TM1.[CPRetRet], T3.[TipAbr] AS CPRetTipAbr, TM1.[CPRetTotal], TM1.[CPRetPor], T2.[CPRetTipCmb], TM1.[CPRetCod], TM1.[CPRetTipCod] AS CPRetTipCod, TM1.[CPRetComCod] AS CPRetComCod, TM1.[CPRetPrvCod] AS CPRetPrvCod, T4.[CPMonCod] AS CPRetComMon FROM ((([CPRETENCIONDET] TM1 INNER JOIN [CPRETENCION] T2 ON T2.[CPRetCod] = TM1.[CPRetCod]) INNER JOIN [CPCUENTAPAGAR] T4 ON T4.[CPTipCod] = TM1.[CPRetTipCod] AND T4.[CPComCod] = TM1.[CPRetComCod] AND T4.[CPPrvCod] = TM1.[CPRetPrvCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T4.[CPTipCod]) WHERE TM1.[CPRetCod] = @CPRetCod and TM1.[CPRetPrvCod] = @CPRetPrvCod and TM1.[CPRetTipCod] = @CPRetTipCod and TM1.[CPRetComCod] = @CPRetComCod ORDER BY TM1.[CPRetCod], TM1.[CPRetPrvCod], TM1.[CPRetTipCod], TM1.[CPRetComCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003N7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003N8", "SELECT [CPRetTipCmb] FROM [CPRETENCION] WHERE [CPRetCod] = @CPRetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003N8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003N9", "SELECT [TipAbr] AS CPRetTipAbr FROM [CTIPDOC] WHERE [TipCod] = @CPRetTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003N9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003N10", "SELECT [CPMonCod] AS CPRetComMon FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @CPRetTipCod AND [CPComCod] = @CPRetComCod AND [CPPrvCod] = @CPRetPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003N10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003N11", "SELECT [CPRetCod], [CPRetPrvCod] AS CPRetPrvCod, [CPRetTipCod] AS CPRetTipCod, [CPRetComCod] AS CPRetComCod FROM [CPRETENCIONDET] WHERE [CPRetCod] = @CPRetCod AND [CPRetPrvCod] = @CPRetPrvCod AND [CPRetTipCod] = @CPRetTipCod AND [CPRetComCod] = @CPRetComCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003N11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003N12", "SELECT TOP 1 [CPRetCod], [CPRetPrvCod] AS CPRetPrvCod, [CPRetTipCod] AS CPRetTipCod, [CPRetComCod] AS CPRetComCod FROM [CPRETENCIONDET] WHERE ( [CPRetCod] > @CPRetCod or [CPRetCod] = @CPRetCod and [CPRetPrvCod] > @CPRetPrvCod or [CPRetPrvCod] = @CPRetPrvCod and [CPRetCod] = @CPRetCod and [CPRetTipCod] > @CPRetTipCod or [CPRetTipCod] = @CPRetTipCod and [CPRetPrvCod] = @CPRetPrvCod and [CPRetCod] = @CPRetCod and [CPRetComCod] > @CPRetComCod) ORDER BY [CPRetCod], [CPRetPrvCod], [CPRetTipCod], [CPRetComCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003N12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003N13", "SELECT TOP 1 [CPRetCod], [CPRetPrvCod] AS CPRetPrvCod, [CPRetTipCod] AS CPRetTipCod, [CPRetComCod] AS CPRetComCod FROM [CPRETENCIONDET] WHERE ( [CPRetCod] < @CPRetCod or [CPRetCod] = @CPRetCod and [CPRetPrvCod] < @CPRetPrvCod or [CPRetPrvCod] = @CPRetPrvCod and [CPRetCod] = @CPRetCod and [CPRetTipCod] < @CPRetTipCod or [CPRetTipCod] = @CPRetTipCod and [CPRetPrvCod] = @CPRetPrvCod and [CPRetCod] = @CPRetCod and [CPRetComCod] < @CPRetComCod) ORDER BY [CPRetCod] DESC, [CPRetPrvCod] DESC, [CPRetTipCod] DESC, [CPRetComCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003N13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003N14", "INSERT INTO [CPRETENCIONDET]([CPRetRet], [CPRetTotal], [CPRetPor], [CPRetCod], [CPRetTipCod], [CPRetComCod], [CPRetPrvCod]) VALUES(@CPRetRet, @CPRetTotal, @CPRetPor, @CPRetCod, @CPRetTipCod, @CPRetComCod, @CPRetPrvCod)", GxErrorMask.GX_NOMASK,prmT003N14)
           ,new CursorDef("T003N15", "UPDATE [CPRETENCIONDET] SET [CPRetRet]=@CPRetRet, [CPRetTotal]=@CPRetTotal, [CPRetPor]=@CPRetPor  WHERE [CPRetCod] = @CPRetCod AND [CPRetPrvCod] = @CPRetPrvCod AND [CPRetTipCod] = @CPRetTipCod AND [CPRetComCod] = @CPRetComCod", GxErrorMask.GX_NOMASK,prmT003N15)
           ,new CursorDef("T003N16", "DELETE FROM [CPRETENCIONDET]  WHERE [CPRetCod] = @CPRetCod AND [CPRetPrvCod] = @CPRetPrvCod AND [CPRetTipCod] = @CPRetTipCod AND [CPRetComCod] = @CPRetComCod", GxErrorMask.GX_NOMASK,prmT003N16)
           ,new CursorDef("T003N17", "SELECT [CPRetTipCmb] FROM [CPRETENCION] WHERE [CPRetCod] = @CPRetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003N17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003N18", "SELECT [TipAbr] AS CPRetTipAbr FROM [CTIPDOC] WHERE [TipCod] = @CPRetTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003N18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003N19", "SELECT [CPMonCod] AS CPRetComMon FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @CPRetTipCod AND [CPComCod] = @CPRetComCod AND [CPPrvCod] = @CPRetPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003N19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003N20", "SELECT [CPRetCod], [CPRetPrvCod] AS CPRetPrvCod, [CPRetTipCod] AS CPRetTipCod, [CPRetComCod] AS CPRetComCod FROM [CPRETENCIONDET] ORDER BY [CPRetCod], [CPRetPrvCod], [CPRetTipCod], [CPRetComCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003N20,100, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              return;
           case 2 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              return;
           case 5 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 6 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 15 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
     }
  }

}

}
