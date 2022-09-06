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
   public class tscajareposicion : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A358CajCod = (int)(NumberUtil.Val( GetPar( "CajCod"), "."));
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A359AperCajCod = GetPar( "AperCajCod");
            AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A358CajCod, A359AperCajCod) ;
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
            Form.Meta.addItem("description", "Reposición de Caja Chica", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tscajareposicion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tscajareposicion( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJAREPOSICION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJAREPOSICION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJAREPOSICION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJAREPOSICION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSCAJAREPOSICION.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Caja Chica", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCajCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A358CajCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCajCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A358CajCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A358CajCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCajCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCajCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Caja Chica", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperCajCod_Internalname, StringUtil.RTrim( A359AperCajCod), StringUtil.RTrim( context.localUtil.Format( A359AperCajCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperCajCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperCajCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Item", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperCajItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A373AperCajItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperCajItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A373AperCajItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A373AperCajItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperCajItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperCajItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCAJAREPOSICION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Fecha", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAperRepFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAperRepFec_Internalname, context.localUtil.Format(A463AperRepFec, "99/99/99"), context.localUtil.Format( A463AperRepFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperRepFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperRepFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCAJAREPOSICION.htm");
         GxWebStd.gx_bitmap( context, edtAperRepFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAperRepFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Moneda", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperRepMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A466AperRepMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperRepMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A466AperRepMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A466AperRepMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperRepMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperRepMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Forma de Pago", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperRepForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A464AperRepForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperRepForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A464AperRepForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A464AperRepForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperRepForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperRepForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Banco", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperRepBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A459AperRepBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperRepBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A459AperRepBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A459AperRepBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperRepBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperRepBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Cuenta", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperRepCueBan_Internalname, StringUtil.RTrim( A462AperRepCueBan), StringUtil.RTrim( context.localUtil.Format( A462AperRepCueBan, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperRepCueBan_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperRepCueBan_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Cheque", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperRepCheq_Internalname, StringUtil.RTrim( A461AperRepCheq), StringUtil.RTrim( context.localUtil.Format( A461AperRepCheq, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperRepCheq_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperRepCheq_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Importe", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperRepImp_Internalname, StringUtil.LTrim( StringUtil.NToC( A465AperRepImp, 17, 2, ".", "")), StringUtil.LTrim( ((edtAperRepImp_Enabled!=0) ? context.localUtil.Format( A465AperRepImp, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A465AperRepImp, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperRepImp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperRepImp_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Tipo Movimiento", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperRepTMov_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A469AperRepTMov), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperRepTMov_Enabled!=0) ? context.localUtil.Format( (decimal)(A469AperRepTMov), "ZZZZZ9") : context.localUtil.Format( (decimal)(A469AperRepTMov), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperRepTMov_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperRepTMov_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "N° Registro", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperRepBanReg_Internalname, StringUtil.RTrim( A460AperRepBanReg), StringUtil.RTrim( context.localUtil.Format( A460AperRepBanReg, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperRepBanReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperRepBanReg_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Estado", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperRepSts_Internalname, StringUtil.RTrim( A468AperRepSts), StringUtil.RTrim( context.localUtil.Format( A468AperRepSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperRepSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperRepSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCAJAREPOSICION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJAREPOSICION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJAREPOSICION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJAREPOSICION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJAREPOSICION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_TSCAJAREPOSICION.htm");
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
            Z358CajCod = (int)(context.localUtil.CToN( cgiGet( "Z358CajCod"), ".", ","));
            Z359AperCajCod = cgiGet( "Z359AperCajCod");
            Z373AperCajItem = (int)(context.localUtil.CToN( cgiGet( "Z373AperCajItem"), ".", ","));
            Z463AperRepFec = context.localUtil.CToD( cgiGet( "Z463AperRepFec"), 0);
            Z466AperRepMonCod = (int)(context.localUtil.CToN( cgiGet( "Z466AperRepMonCod"), ".", ","));
            Z464AperRepForCod = (int)(context.localUtil.CToN( cgiGet( "Z464AperRepForCod"), ".", ","));
            Z459AperRepBanCod = (int)(context.localUtil.CToN( cgiGet( "Z459AperRepBanCod"), ".", ","));
            Z462AperRepCueBan = cgiGet( "Z462AperRepCueBan");
            Z461AperRepCheq = cgiGet( "Z461AperRepCheq");
            Z465AperRepImp = context.localUtil.CToN( cgiGet( "Z465AperRepImp"), ".", ",");
            Z469AperRepTMov = (int)(context.localUtil.CToN( cgiGet( "Z469AperRepTMov"), ".", ","));
            Z460AperRepBanReg = cgiGet( "Z460AperRepBanReg");
            Z468AperRepSts = cgiGet( "Z468AperRepSts");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAJCOD");
               AnyError = 1;
               GX_FocusControl = edtCajCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A358CajCod = 0;
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            }
            else
            {
               A358CajCod = (int)(context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ","));
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            }
            A359AperCajCod = cgiGet( edtAperCajCod_Internalname);
            AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperCajItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperCajItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERCAJITEM");
               AnyError = 1;
               GX_FocusControl = edtAperCajItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A373AperCajItem = 0;
               AssignAttri("", false, "A373AperCajItem", StringUtil.LTrimStr( (decimal)(A373AperCajItem), 6, 0));
            }
            else
            {
               A373AperCajItem = (int)(context.localUtil.CToN( cgiGet( edtAperCajItem_Internalname), ".", ","));
               AssignAttri("", false, "A373AperCajItem", StringUtil.LTrimStr( (decimal)(A373AperCajItem), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtAperRepFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "APERREPFEC");
               AnyError = 1;
               GX_FocusControl = edtAperRepFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A463AperRepFec = DateTime.MinValue;
               AssignAttri("", false, "A463AperRepFec", context.localUtil.Format(A463AperRepFec, "99/99/99"));
            }
            else
            {
               A463AperRepFec = context.localUtil.CToD( cgiGet( edtAperRepFec_Internalname), 2);
               AssignAttri("", false, "A463AperRepFec", context.localUtil.Format(A463AperRepFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperRepMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperRepMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERREPMONCOD");
               AnyError = 1;
               GX_FocusControl = edtAperRepMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A466AperRepMonCod = 0;
               AssignAttri("", false, "A466AperRepMonCod", StringUtil.LTrimStr( (decimal)(A466AperRepMonCod), 6, 0));
            }
            else
            {
               A466AperRepMonCod = (int)(context.localUtil.CToN( cgiGet( edtAperRepMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A466AperRepMonCod", StringUtil.LTrimStr( (decimal)(A466AperRepMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperRepForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperRepForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERREPFORCOD");
               AnyError = 1;
               GX_FocusControl = edtAperRepForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A464AperRepForCod = 0;
               AssignAttri("", false, "A464AperRepForCod", StringUtil.LTrimStr( (decimal)(A464AperRepForCod), 6, 0));
            }
            else
            {
               A464AperRepForCod = (int)(context.localUtil.CToN( cgiGet( edtAperRepForCod_Internalname), ".", ","));
               AssignAttri("", false, "A464AperRepForCod", StringUtil.LTrimStr( (decimal)(A464AperRepForCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperRepBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperRepBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERREPBANCOD");
               AnyError = 1;
               GX_FocusControl = edtAperRepBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A459AperRepBanCod = 0;
               AssignAttri("", false, "A459AperRepBanCod", StringUtil.LTrimStr( (decimal)(A459AperRepBanCod), 6, 0));
            }
            else
            {
               A459AperRepBanCod = (int)(context.localUtil.CToN( cgiGet( edtAperRepBanCod_Internalname), ".", ","));
               AssignAttri("", false, "A459AperRepBanCod", StringUtil.LTrimStr( (decimal)(A459AperRepBanCod), 6, 0));
            }
            A462AperRepCueBan = cgiGet( edtAperRepCueBan_Internalname);
            AssignAttri("", false, "A462AperRepCueBan", A462AperRepCueBan);
            A461AperRepCheq = cgiGet( edtAperRepCheq_Internalname);
            AssignAttri("", false, "A461AperRepCheq", A461AperRepCheq);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperRepImp_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtAperRepImp_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERREPIMP");
               AnyError = 1;
               GX_FocusControl = edtAperRepImp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A465AperRepImp = 0;
               AssignAttri("", false, "A465AperRepImp", StringUtil.LTrimStr( A465AperRepImp, 15, 2));
            }
            else
            {
               A465AperRepImp = context.localUtil.CToN( cgiGet( edtAperRepImp_Internalname), ".", ",");
               AssignAttri("", false, "A465AperRepImp", StringUtil.LTrimStr( A465AperRepImp, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperRepTMov_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperRepTMov_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERREPTMOV");
               AnyError = 1;
               GX_FocusControl = edtAperRepTMov_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A469AperRepTMov = 0;
               AssignAttri("", false, "A469AperRepTMov", StringUtil.LTrimStr( (decimal)(A469AperRepTMov), 6, 0));
            }
            else
            {
               A469AperRepTMov = (int)(context.localUtil.CToN( cgiGet( edtAperRepTMov_Internalname), ".", ","));
               AssignAttri("", false, "A469AperRepTMov", StringUtil.LTrimStr( (decimal)(A469AperRepTMov), 6, 0));
            }
            A460AperRepBanReg = cgiGet( edtAperRepBanReg_Internalname);
            AssignAttri("", false, "A460AperRepBanReg", A460AperRepBanReg);
            A468AperRepSts = cgiGet( edtAperRepSts_Internalname);
            AssignAttri("", false, "A468AperRepSts", A468AperRepSts);
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
               A358CajCod = (int)(NumberUtil.Val( GetPar( "CajCod"), "."));
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               A359AperCajCod = GetPar( "AperCajCod");
               AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
               A373AperCajItem = (int)(NumberUtil.Val( GetPar( "AperCajItem"), "."));
               AssignAttri("", false, "A373AperCajItem", StringUtil.LTrimStr( (decimal)(A373AperCajItem), 6, 0));
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
               InitAll53170( ) ;
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
         DisableAttributes53170( ) ;
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

      protected void CONFIRM_530( )
      {
         BeforeValidate53170( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls53170( ) ;
            }
            else
            {
               CheckExtendedTable53170( ) ;
               if ( AnyError == 0 )
               {
                  ZM53170( 3) ;
               }
               CloseExtendedTableCursors53170( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues530( ) ;
         }
      }

      protected void ResetCaption530( )
      {
      }

      protected void ZM53170( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z463AperRepFec = T00533_A463AperRepFec[0];
               Z466AperRepMonCod = T00533_A466AperRepMonCod[0];
               Z464AperRepForCod = T00533_A464AperRepForCod[0];
               Z459AperRepBanCod = T00533_A459AperRepBanCod[0];
               Z462AperRepCueBan = T00533_A462AperRepCueBan[0];
               Z461AperRepCheq = T00533_A461AperRepCheq[0];
               Z465AperRepImp = T00533_A465AperRepImp[0];
               Z469AperRepTMov = T00533_A469AperRepTMov[0];
               Z460AperRepBanReg = T00533_A460AperRepBanReg[0];
               Z468AperRepSts = T00533_A468AperRepSts[0];
            }
            else
            {
               Z463AperRepFec = A463AperRepFec;
               Z466AperRepMonCod = A466AperRepMonCod;
               Z464AperRepForCod = A464AperRepForCod;
               Z459AperRepBanCod = A459AperRepBanCod;
               Z462AperRepCueBan = A462AperRepCueBan;
               Z461AperRepCheq = A461AperRepCheq;
               Z465AperRepImp = A465AperRepImp;
               Z469AperRepTMov = A469AperRepTMov;
               Z460AperRepBanReg = A460AperRepBanReg;
               Z468AperRepSts = A468AperRepSts;
            }
         }
         if ( GX_JID == -2 )
         {
            Z373AperCajItem = A373AperCajItem;
            Z463AperRepFec = A463AperRepFec;
            Z466AperRepMonCod = A466AperRepMonCod;
            Z464AperRepForCod = A464AperRepForCod;
            Z459AperRepBanCod = A459AperRepBanCod;
            Z462AperRepCueBan = A462AperRepCueBan;
            Z461AperRepCheq = A461AperRepCheq;
            Z465AperRepImp = A465AperRepImp;
            Z469AperRepTMov = A469AperRepTMov;
            Z460AperRepBanReg = A460AperRepBanReg;
            Z468AperRepSts = A468AperRepSts;
            Z358CajCod = A358CajCod;
            Z359AperCajCod = A359AperCajCod;
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

      protected void Load53170( )
      {
         /* Using cursor T00535 */
         pr_default.execute(3, new Object[] {A358CajCod, A359AperCajCod, A373AperCajItem});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound170 = 1;
            A463AperRepFec = T00535_A463AperRepFec[0];
            AssignAttri("", false, "A463AperRepFec", context.localUtil.Format(A463AperRepFec, "99/99/99"));
            A466AperRepMonCod = T00535_A466AperRepMonCod[0];
            AssignAttri("", false, "A466AperRepMonCod", StringUtil.LTrimStr( (decimal)(A466AperRepMonCod), 6, 0));
            A464AperRepForCod = T00535_A464AperRepForCod[0];
            AssignAttri("", false, "A464AperRepForCod", StringUtil.LTrimStr( (decimal)(A464AperRepForCod), 6, 0));
            A459AperRepBanCod = T00535_A459AperRepBanCod[0];
            AssignAttri("", false, "A459AperRepBanCod", StringUtil.LTrimStr( (decimal)(A459AperRepBanCod), 6, 0));
            A462AperRepCueBan = T00535_A462AperRepCueBan[0];
            AssignAttri("", false, "A462AperRepCueBan", A462AperRepCueBan);
            A461AperRepCheq = T00535_A461AperRepCheq[0];
            AssignAttri("", false, "A461AperRepCheq", A461AperRepCheq);
            A465AperRepImp = T00535_A465AperRepImp[0];
            AssignAttri("", false, "A465AperRepImp", StringUtil.LTrimStr( A465AperRepImp, 15, 2));
            A469AperRepTMov = T00535_A469AperRepTMov[0];
            AssignAttri("", false, "A469AperRepTMov", StringUtil.LTrimStr( (decimal)(A469AperRepTMov), 6, 0));
            A460AperRepBanReg = T00535_A460AperRepBanReg[0];
            AssignAttri("", false, "A460AperRepBanReg", A460AperRepBanReg);
            A468AperRepSts = T00535_A468AperRepSts[0];
            AssignAttri("", false, "A468AperRepSts", A468AperRepSts);
            ZM53170( -2) ;
         }
         pr_default.close(3);
         OnLoadActions53170( ) ;
      }

      protected void OnLoadActions53170( )
      {
      }

      protected void CheckExtendedTable53170( )
      {
         nIsDirty_170 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00534 */
         pr_default.execute(2, new Object[] {A358CajCod, A359AperCajCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Apertura Caja'.", "ForeignKeyNotFound", 1, "APERCAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A463AperRepFec) || ( DateTimeUtil.ResetTime ( A463AperRepFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "APERREPFEC");
            AnyError = 1;
            GX_FocusControl = edtAperRepFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors53170( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A358CajCod ,
                               string A359AperCajCod )
      {
         /* Using cursor T00536 */
         pr_default.execute(4, new Object[] {A358CajCod, A359AperCajCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Apertura Caja'.", "ForeignKeyNotFound", 1, "APERCAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
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

      protected void GetKey53170( )
      {
         /* Using cursor T00537 */
         pr_default.execute(5, new Object[] {A358CajCod, A359AperCajCod, A373AperCajItem});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound170 = 1;
         }
         else
         {
            RcdFound170 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00533 */
         pr_default.execute(1, new Object[] {A358CajCod, A359AperCajCod, A373AperCajItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM53170( 2) ;
            RcdFound170 = 1;
            A373AperCajItem = T00533_A373AperCajItem[0];
            AssignAttri("", false, "A373AperCajItem", StringUtil.LTrimStr( (decimal)(A373AperCajItem), 6, 0));
            A463AperRepFec = T00533_A463AperRepFec[0];
            AssignAttri("", false, "A463AperRepFec", context.localUtil.Format(A463AperRepFec, "99/99/99"));
            A466AperRepMonCod = T00533_A466AperRepMonCod[0];
            AssignAttri("", false, "A466AperRepMonCod", StringUtil.LTrimStr( (decimal)(A466AperRepMonCod), 6, 0));
            A464AperRepForCod = T00533_A464AperRepForCod[0];
            AssignAttri("", false, "A464AperRepForCod", StringUtil.LTrimStr( (decimal)(A464AperRepForCod), 6, 0));
            A459AperRepBanCod = T00533_A459AperRepBanCod[0];
            AssignAttri("", false, "A459AperRepBanCod", StringUtil.LTrimStr( (decimal)(A459AperRepBanCod), 6, 0));
            A462AperRepCueBan = T00533_A462AperRepCueBan[0];
            AssignAttri("", false, "A462AperRepCueBan", A462AperRepCueBan);
            A461AperRepCheq = T00533_A461AperRepCheq[0];
            AssignAttri("", false, "A461AperRepCheq", A461AperRepCheq);
            A465AperRepImp = T00533_A465AperRepImp[0];
            AssignAttri("", false, "A465AperRepImp", StringUtil.LTrimStr( A465AperRepImp, 15, 2));
            A469AperRepTMov = T00533_A469AperRepTMov[0];
            AssignAttri("", false, "A469AperRepTMov", StringUtil.LTrimStr( (decimal)(A469AperRepTMov), 6, 0));
            A460AperRepBanReg = T00533_A460AperRepBanReg[0];
            AssignAttri("", false, "A460AperRepBanReg", A460AperRepBanReg);
            A468AperRepSts = T00533_A468AperRepSts[0];
            AssignAttri("", false, "A468AperRepSts", A468AperRepSts);
            A358CajCod = T00533_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A359AperCajCod = T00533_A359AperCajCod[0];
            AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
            Z358CajCod = A358CajCod;
            Z359AperCajCod = A359AperCajCod;
            Z373AperCajItem = A373AperCajItem;
            sMode170 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load53170( ) ;
            if ( AnyError == 1 )
            {
               RcdFound170 = 0;
               InitializeNonKey53170( ) ;
            }
            Gx_mode = sMode170;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound170 = 0;
            InitializeNonKey53170( ) ;
            sMode170 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode170;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey53170( ) ;
         if ( RcdFound170 == 0 )
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
         RcdFound170 = 0;
         /* Using cursor T00538 */
         pr_default.execute(6, new Object[] {A358CajCod, A359AperCajCod, A373AperCajItem});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00538_A358CajCod[0] < A358CajCod ) || ( T00538_A358CajCod[0] == A358CajCod ) && ( StringUtil.StrCmp(T00538_A359AperCajCod[0], A359AperCajCod) < 0 ) || ( StringUtil.StrCmp(T00538_A359AperCajCod[0], A359AperCajCod) == 0 ) && ( T00538_A358CajCod[0] == A358CajCod ) && ( T00538_A373AperCajItem[0] < A373AperCajItem ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00538_A358CajCod[0] > A358CajCod ) || ( T00538_A358CajCod[0] == A358CajCod ) && ( StringUtil.StrCmp(T00538_A359AperCajCod[0], A359AperCajCod) > 0 ) || ( StringUtil.StrCmp(T00538_A359AperCajCod[0], A359AperCajCod) == 0 ) && ( T00538_A358CajCod[0] == A358CajCod ) && ( T00538_A373AperCajItem[0] > A373AperCajItem ) ) )
            {
               A358CajCod = T00538_A358CajCod[0];
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               A359AperCajCod = T00538_A359AperCajCod[0];
               AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
               A373AperCajItem = T00538_A373AperCajItem[0];
               AssignAttri("", false, "A373AperCajItem", StringUtil.LTrimStr( (decimal)(A373AperCajItem), 6, 0));
               RcdFound170 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound170 = 0;
         /* Using cursor T00539 */
         pr_default.execute(7, new Object[] {A358CajCod, A359AperCajCod, A373AperCajItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00539_A358CajCod[0] > A358CajCod ) || ( T00539_A358CajCod[0] == A358CajCod ) && ( StringUtil.StrCmp(T00539_A359AperCajCod[0], A359AperCajCod) > 0 ) || ( StringUtil.StrCmp(T00539_A359AperCajCod[0], A359AperCajCod) == 0 ) && ( T00539_A358CajCod[0] == A358CajCod ) && ( T00539_A373AperCajItem[0] > A373AperCajItem ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00539_A358CajCod[0] < A358CajCod ) || ( T00539_A358CajCod[0] == A358CajCod ) && ( StringUtil.StrCmp(T00539_A359AperCajCod[0], A359AperCajCod) < 0 ) || ( StringUtil.StrCmp(T00539_A359AperCajCod[0], A359AperCajCod) == 0 ) && ( T00539_A358CajCod[0] == A358CajCod ) && ( T00539_A373AperCajItem[0] < A373AperCajItem ) ) )
            {
               A358CajCod = T00539_A358CajCod[0];
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               A359AperCajCod = T00539_A359AperCajCod[0];
               AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
               A373AperCajItem = T00539_A373AperCajItem[0];
               AssignAttri("", false, "A373AperCajItem", StringUtil.LTrimStr( (decimal)(A373AperCajItem), 6, 0));
               RcdFound170 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey53170( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert53170( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound170 == 1 )
            {
               if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A359AperCajCod, Z359AperCajCod) != 0 ) || ( A373AperCajItem != Z373AperCajItem ) )
               {
                  A358CajCod = Z358CajCod;
                  AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
                  A359AperCajCod = Z359AperCajCod;
                  AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
                  A373AperCajItem = Z373AperCajItem;
                  AssignAttri("", false, "A373AperCajItem", StringUtil.LTrimStr( (decimal)(A373AperCajItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CAJCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update53170( ) ;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A359AperCajCod, Z359AperCajCod) != 0 ) || ( A373AperCajItem != Z373AperCajItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert53170( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CAJCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCajCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCajCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert53170( ) ;
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
         if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A359AperCajCod, Z359AperCajCod) != 0 ) || ( A373AperCajItem != Z373AperCajItem ) )
         {
            A358CajCod = Z358CajCod;
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A359AperCajCod = Z359AperCajCod;
            AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
            A373AperCajItem = Z373AperCajItem;
            AssignAttri("", false, "A373AperCajItem", StringUtil.LTrimStr( (decimal)(A373AperCajItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCajCod_Internalname;
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
         GetKey53170( ) ;
         if ( RcdFound170 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CAJCOD");
               AnyError = 1;
               GX_FocusControl = edtCajCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A359AperCajCod, Z359AperCajCod) != 0 ) || ( A373AperCajItem != Z373AperCajItem ) )
            {
               A358CajCod = Z358CajCod;
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               A359AperCajCod = Z359AperCajCod;
               AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
               A373AperCajItem = Z373AperCajItem;
               AssignAttri("", false, "A373AperCajItem", StringUtil.LTrimStr( (decimal)(A373AperCajItem), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CAJCOD");
               AnyError = 1;
               GX_FocusControl = edtCajCod_Internalname;
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
            if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A359AperCajCod, Z359AperCajCod) != 0 ) || ( A373AperCajItem != Z373AperCajItem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CAJCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCajCod_Internalname;
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
         context.RollbackDataStores("tscajareposicion",pr_default);
         GX_FocusControl = edtAperRepFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_530( ) ;
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
         if ( RcdFound170 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAperRepFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart53170( ) ;
         if ( RcdFound170 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAperRepFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd53170( ) ;
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
         if ( RcdFound170 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAperRepFec_Internalname;
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
         if ( RcdFound170 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAperRepFec_Internalname;
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
         ScanStart53170( ) ;
         if ( RcdFound170 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound170 != 0 )
            {
               ScanNext53170( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAperRepFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd53170( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency53170( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00532 */
            pr_default.execute(0, new Object[] {A358CajCod, A359AperCajCod, A373AperCajItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCAJAREPOSICION"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z463AperRepFec ) != DateTimeUtil.ResetTime ( T00532_A463AperRepFec[0] ) ) || ( Z466AperRepMonCod != T00532_A466AperRepMonCod[0] ) || ( Z464AperRepForCod != T00532_A464AperRepForCod[0] ) || ( Z459AperRepBanCod != T00532_A459AperRepBanCod[0] ) || ( StringUtil.StrCmp(Z462AperRepCueBan, T00532_A462AperRepCueBan[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z461AperRepCheq, T00532_A461AperRepCheq[0]) != 0 ) || ( Z465AperRepImp != T00532_A465AperRepImp[0] ) || ( Z469AperRepTMov != T00532_A469AperRepTMov[0] ) || ( StringUtil.StrCmp(Z460AperRepBanReg, T00532_A460AperRepBanReg[0]) != 0 ) || ( StringUtil.StrCmp(Z468AperRepSts, T00532_A468AperRepSts[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z463AperRepFec ) != DateTimeUtil.ResetTime ( T00532_A463AperRepFec[0] ) )
               {
                  GXUtil.WriteLog("tscajareposicion:[seudo value changed for attri]"+"AperRepFec");
                  GXUtil.WriteLogRaw("Old: ",Z463AperRepFec);
                  GXUtil.WriteLogRaw("Current: ",T00532_A463AperRepFec[0]);
               }
               if ( Z466AperRepMonCod != T00532_A466AperRepMonCod[0] )
               {
                  GXUtil.WriteLog("tscajareposicion:[seudo value changed for attri]"+"AperRepMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z466AperRepMonCod);
                  GXUtil.WriteLogRaw("Current: ",T00532_A466AperRepMonCod[0]);
               }
               if ( Z464AperRepForCod != T00532_A464AperRepForCod[0] )
               {
                  GXUtil.WriteLog("tscajareposicion:[seudo value changed for attri]"+"AperRepForCod");
                  GXUtil.WriteLogRaw("Old: ",Z464AperRepForCod);
                  GXUtil.WriteLogRaw("Current: ",T00532_A464AperRepForCod[0]);
               }
               if ( Z459AperRepBanCod != T00532_A459AperRepBanCod[0] )
               {
                  GXUtil.WriteLog("tscajareposicion:[seudo value changed for attri]"+"AperRepBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z459AperRepBanCod);
                  GXUtil.WriteLogRaw("Current: ",T00532_A459AperRepBanCod[0]);
               }
               if ( StringUtil.StrCmp(Z462AperRepCueBan, T00532_A462AperRepCueBan[0]) != 0 )
               {
                  GXUtil.WriteLog("tscajareposicion:[seudo value changed for attri]"+"AperRepCueBan");
                  GXUtil.WriteLogRaw("Old: ",Z462AperRepCueBan);
                  GXUtil.WriteLogRaw("Current: ",T00532_A462AperRepCueBan[0]);
               }
               if ( StringUtil.StrCmp(Z461AperRepCheq, T00532_A461AperRepCheq[0]) != 0 )
               {
                  GXUtil.WriteLog("tscajareposicion:[seudo value changed for attri]"+"AperRepCheq");
                  GXUtil.WriteLogRaw("Old: ",Z461AperRepCheq);
                  GXUtil.WriteLogRaw("Current: ",T00532_A461AperRepCheq[0]);
               }
               if ( Z465AperRepImp != T00532_A465AperRepImp[0] )
               {
                  GXUtil.WriteLog("tscajareposicion:[seudo value changed for attri]"+"AperRepImp");
                  GXUtil.WriteLogRaw("Old: ",Z465AperRepImp);
                  GXUtil.WriteLogRaw("Current: ",T00532_A465AperRepImp[0]);
               }
               if ( Z469AperRepTMov != T00532_A469AperRepTMov[0] )
               {
                  GXUtil.WriteLog("tscajareposicion:[seudo value changed for attri]"+"AperRepTMov");
                  GXUtil.WriteLogRaw("Old: ",Z469AperRepTMov);
                  GXUtil.WriteLogRaw("Current: ",T00532_A469AperRepTMov[0]);
               }
               if ( StringUtil.StrCmp(Z460AperRepBanReg, T00532_A460AperRepBanReg[0]) != 0 )
               {
                  GXUtil.WriteLog("tscajareposicion:[seudo value changed for attri]"+"AperRepBanReg");
                  GXUtil.WriteLogRaw("Old: ",Z460AperRepBanReg);
                  GXUtil.WriteLogRaw("Current: ",T00532_A460AperRepBanReg[0]);
               }
               if ( StringUtil.StrCmp(Z468AperRepSts, T00532_A468AperRepSts[0]) != 0 )
               {
                  GXUtil.WriteLog("tscajareposicion:[seudo value changed for attri]"+"AperRepSts");
                  GXUtil.WriteLogRaw("Old: ",Z468AperRepSts);
                  GXUtil.WriteLogRaw("Current: ",T00532_A468AperRepSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSCAJAREPOSICION"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert53170( )
      {
         BeforeValidate53170( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable53170( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM53170( 0) ;
            CheckOptimisticConcurrency53170( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm53170( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert53170( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005310 */
                     pr_default.execute(8, new Object[] {A373AperCajItem, A463AperRepFec, A466AperRepMonCod, A464AperRepForCod, A459AperRepBanCod, A462AperRepCueBan, A461AperRepCheq, A465AperRepImp, A469AperRepTMov, A460AperRepBanReg, A468AperRepSts, A358CajCod, A359AperCajCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCAJAREPOSICION");
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
                           ResetCaption530( ) ;
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
               Load53170( ) ;
            }
            EndLevel53170( ) ;
         }
         CloseExtendedTableCursors53170( ) ;
      }

      protected void Update53170( )
      {
         BeforeValidate53170( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable53170( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency53170( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm53170( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate53170( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005311 */
                     pr_default.execute(9, new Object[] {A463AperRepFec, A466AperRepMonCod, A464AperRepForCod, A459AperRepBanCod, A462AperRepCueBan, A461AperRepCheq, A465AperRepImp, A469AperRepTMov, A460AperRepBanReg, A468AperRepSts, A358CajCod, A359AperCajCod, A373AperCajItem});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCAJAREPOSICION");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCAJAREPOSICION"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate53170( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption530( ) ;
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
            EndLevel53170( ) ;
         }
         CloseExtendedTableCursors53170( ) ;
      }

      protected void DeferredUpdate53170( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate53170( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency53170( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls53170( ) ;
            AfterConfirm53170( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete53170( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005312 */
                  pr_default.execute(10, new Object[] {A358CajCod, A359AperCajCod, A373AperCajItem});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("TSCAJAREPOSICION");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound170 == 0 )
                        {
                           InitAll53170( ) ;
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
                        ResetCaption530( ) ;
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
         sMode170 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel53170( ) ;
         Gx_mode = sMode170;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls53170( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel53170( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete53170( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tscajareposicion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues530( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tscajareposicion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart53170( )
      {
         /* Using cursor T005313 */
         pr_default.execute(11);
         RcdFound170 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound170 = 1;
            A358CajCod = T005313_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A359AperCajCod = T005313_A359AperCajCod[0];
            AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
            A373AperCajItem = T005313_A373AperCajItem[0];
            AssignAttri("", false, "A373AperCajItem", StringUtil.LTrimStr( (decimal)(A373AperCajItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext53170( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound170 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound170 = 1;
            A358CajCod = T005313_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A359AperCajCod = T005313_A359AperCajCod[0];
            AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
            A373AperCajItem = T005313_A373AperCajItem[0];
            AssignAttri("", false, "A373AperCajItem", StringUtil.LTrimStr( (decimal)(A373AperCajItem), 6, 0));
         }
      }

      protected void ScanEnd53170( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm53170( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert53170( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate53170( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete53170( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete53170( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate53170( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes53170( )
      {
         edtCajCod_Enabled = 0;
         AssignProp("", false, edtCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCajCod_Enabled), 5, 0), true);
         edtAperCajCod_Enabled = 0;
         AssignProp("", false, edtAperCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperCajCod_Enabled), 5, 0), true);
         edtAperCajItem_Enabled = 0;
         AssignProp("", false, edtAperCajItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperCajItem_Enabled), 5, 0), true);
         edtAperRepFec_Enabled = 0;
         AssignProp("", false, edtAperRepFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperRepFec_Enabled), 5, 0), true);
         edtAperRepMonCod_Enabled = 0;
         AssignProp("", false, edtAperRepMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperRepMonCod_Enabled), 5, 0), true);
         edtAperRepForCod_Enabled = 0;
         AssignProp("", false, edtAperRepForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperRepForCod_Enabled), 5, 0), true);
         edtAperRepBanCod_Enabled = 0;
         AssignProp("", false, edtAperRepBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperRepBanCod_Enabled), 5, 0), true);
         edtAperRepCueBan_Enabled = 0;
         AssignProp("", false, edtAperRepCueBan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperRepCueBan_Enabled), 5, 0), true);
         edtAperRepCheq_Enabled = 0;
         AssignProp("", false, edtAperRepCheq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperRepCheq_Enabled), 5, 0), true);
         edtAperRepImp_Enabled = 0;
         AssignProp("", false, edtAperRepImp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperRepImp_Enabled), 5, 0), true);
         edtAperRepTMov_Enabled = 0;
         AssignProp("", false, edtAperRepTMov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperRepTMov_Enabled), 5, 0), true);
         edtAperRepBanReg_Enabled = 0;
         AssignProp("", false, edtAperRepBanReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperRepBanReg_Enabled), 5, 0), true);
         edtAperRepSts_Enabled = 0;
         AssignProp("", false, edtAperRepSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperRepSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes53170( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues530( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810254694", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("tscajareposicion.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z358CajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z358CajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z359AperCajCod", StringUtil.RTrim( Z359AperCajCod));
         GxWebStd.gx_hidden_field( context, "Z373AperCajItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z373AperCajItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z463AperRepFec", context.localUtil.DToC( Z463AperRepFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z466AperRepMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z466AperRepMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z464AperRepForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z464AperRepForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z459AperRepBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z459AperRepBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z462AperRepCueBan", StringUtil.RTrim( Z462AperRepCueBan));
         GxWebStd.gx_hidden_field( context, "Z461AperRepCheq", StringUtil.RTrim( Z461AperRepCheq));
         GxWebStd.gx_hidden_field( context, "Z465AperRepImp", StringUtil.LTrim( StringUtil.NToC( Z465AperRepImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z469AperRepTMov", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z469AperRepTMov), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z460AperRepBanReg", StringUtil.RTrim( Z460AperRepBanReg));
         GxWebStd.gx_hidden_field( context, "Z468AperRepSts", StringUtil.RTrim( Z468AperRepSts));
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
         return formatLink("tscajareposicion.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TSCAJAREPOSICION" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reposición de Caja Chica" ;
      }

      protected void InitializeNonKey53170( )
      {
         A463AperRepFec = DateTime.MinValue;
         AssignAttri("", false, "A463AperRepFec", context.localUtil.Format(A463AperRepFec, "99/99/99"));
         A466AperRepMonCod = 0;
         AssignAttri("", false, "A466AperRepMonCod", StringUtil.LTrimStr( (decimal)(A466AperRepMonCod), 6, 0));
         A464AperRepForCod = 0;
         AssignAttri("", false, "A464AperRepForCod", StringUtil.LTrimStr( (decimal)(A464AperRepForCod), 6, 0));
         A459AperRepBanCod = 0;
         AssignAttri("", false, "A459AperRepBanCod", StringUtil.LTrimStr( (decimal)(A459AperRepBanCod), 6, 0));
         A462AperRepCueBan = "";
         AssignAttri("", false, "A462AperRepCueBan", A462AperRepCueBan);
         A461AperRepCheq = "";
         AssignAttri("", false, "A461AperRepCheq", A461AperRepCheq);
         A465AperRepImp = 0;
         AssignAttri("", false, "A465AperRepImp", StringUtil.LTrimStr( A465AperRepImp, 15, 2));
         A469AperRepTMov = 0;
         AssignAttri("", false, "A469AperRepTMov", StringUtil.LTrimStr( (decimal)(A469AperRepTMov), 6, 0));
         A460AperRepBanReg = "";
         AssignAttri("", false, "A460AperRepBanReg", A460AperRepBanReg);
         A468AperRepSts = "";
         AssignAttri("", false, "A468AperRepSts", A468AperRepSts);
         Z463AperRepFec = DateTime.MinValue;
         Z466AperRepMonCod = 0;
         Z464AperRepForCod = 0;
         Z459AperRepBanCod = 0;
         Z462AperRepCueBan = "";
         Z461AperRepCheq = "";
         Z465AperRepImp = 0;
         Z469AperRepTMov = 0;
         Z460AperRepBanReg = "";
         Z468AperRepSts = "";
      }

      protected void InitAll53170( )
      {
         A358CajCod = 0;
         AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
         A359AperCajCod = "";
         AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
         A373AperCajItem = 0;
         AssignAttri("", false, "A373AperCajItem", StringUtil.LTrimStr( (decimal)(A373AperCajItem), 6, 0));
         InitializeNonKey53170( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025474", true, true);
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
         context.AddJavascriptSource("tscajareposicion.js", "?20228181025474", false, true);
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
         edtCajCod_Internalname = "CAJCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtAperCajCod_Internalname = "APERCAJCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtAperCajItem_Internalname = "APERCAJITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtAperRepFec_Internalname = "APERREPFEC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtAperRepMonCod_Internalname = "APERREPMONCOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtAperRepForCod_Internalname = "APERREPFORCOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtAperRepBanCod_Internalname = "APERREPBANCOD";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtAperRepCueBan_Internalname = "APERREPCUEBAN";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtAperRepCheq_Internalname = "APERREPCHEQ";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtAperRepImp_Internalname = "APERREPIMP";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtAperRepTMov_Internalname = "APERREPTMOV";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtAperRepBanReg_Internalname = "APERREPBANREG";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtAperRepSts_Internalname = "APERREPSTS";
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
         Form.Caption = "Reposición de Caja Chica";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtAperRepSts_Jsonclick = "";
         edtAperRepSts_Enabled = 1;
         edtAperRepBanReg_Jsonclick = "";
         edtAperRepBanReg_Enabled = 1;
         edtAperRepTMov_Jsonclick = "";
         edtAperRepTMov_Enabled = 1;
         edtAperRepImp_Jsonclick = "";
         edtAperRepImp_Enabled = 1;
         edtAperRepCheq_Jsonclick = "";
         edtAperRepCheq_Enabled = 1;
         edtAperRepCueBan_Jsonclick = "";
         edtAperRepCueBan_Enabled = 1;
         edtAperRepBanCod_Jsonclick = "";
         edtAperRepBanCod_Enabled = 1;
         edtAperRepForCod_Jsonclick = "";
         edtAperRepForCod_Enabled = 1;
         edtAperRepMonCod_Jsonclick = "";
         edtAperRepMonCod_Enabled = 1;
         edtAperRepFec_Jsonclick = "";
         edtAperRepFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtAperCajItem_Jsonclick = "";
         edtAperCajItem_Enabled = 1;
         edtAperCajCod_Jsonclick = "";
         edtAperCajCod_Enabled = 1;
         edtCajCod_Jsonclick = "";
         edtCajCod_Enabled = 1;
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
         /* Using cursor T005314 */
         pr_default.execute(12, new Object[] {A358CajCod, A359AperCajCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Apertura Caja'.", "ForeignKeyNotFound", 1, "APERCAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtAperRepFec_Internalname;
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

      public void Valid_Apercajcod( )
      {
         /* Using cursor T005314 */
         pr_default.execute(12, new Object[] {A358CajCod, A359AperCajCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Apertura Caja'.", "ForeignKeyNotFound", 1, "APERCAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Apercajitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A463AperRepFec", context.localUtil.Format(A463AperRepFec, "99/99/99"));
         AssignAttri("", false, "A466AperRepMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A466AperRepMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A464AperRepForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A464AperRepForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A459AperRepBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A459AperRepBanCod), 6, 0, ".", "")));
         AssignAttri("", false, "A462AperRepCueBan", StringUtil.RTrim( A462AperRepCueBan));
         AssignAttri("", false, "A461AperRepCheq", StringUtil.RTrim( A461AperRepCheq));
         AssignAttri("", false, "A465AperRepImp", StringUtil.LTrim( StringUtil.NToC( A465AperRepImp, 15, 2, ".", "")));
         AssignAttri("", false, "A469AperRepTMov", StringUtil.LTrim( StringUtil.NToC( (decimal)(A469AperRepTMov), 6, 0, ".", "")));
         AssignAttri("", false, "A460AperRepBanReg", StringUtil.RTrim( A460AperRepBanReg));
         AssignAttri("", false, "A468AperRepSts", StringUtil.RTrim( A468AperRepSts));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z358CajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z358CajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z359AperCajCod", StringUtil.RTrim( Z359AperCajCod));
         GxWebStd.gx_hidden_field( context, "Z373AperCajItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z373AperCajItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z463AperRepFec", context.localUtil.Format(Z463AperRepFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z466AperRepMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z466AperRepMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z464AperRepForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z464AperRepForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z459AperRepBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z459AperRepBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z462AperRepCueBan", StringUtil.RTrim( Z462AperRepCueBan));
         GxWebStd.gx_hidden_field( context, "Z461AperRepCheq", StringUtil.RTrim( Z461AperRepCheq));
         GxWebStd.gx_hidden_field( context, "Z465AperRepImp", StringUtil.LTrim( StringUtil.NToC( Z465AperRepImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z469AperRepTMov", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z469AperRepTMov), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z460AperRepBanReg", StringUtil.RTrim( Z460AperRepBanReg));
         GxWebStd.gx_hidden_field( context, "Z468AperRepSts", StringUtil.RTrim( Z468AperRepSts));
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
         setEventMetadata("VALID_CAJCOD","{handler:'Valid_Cajcod',iparms:[]");
         setEventMetadata("VALID_CAJCOD",",oparms:[]}");
         setEventMetadata("VALID_APERCAJCOD","{handler:'Valid_Apercajcod',iparms:[{av:'A358CajCod',fld:'CAJCOD',pic:'ZZZZZ9'},{av:'A359AperCajCod',fld:'APERCAJCOD',pic:''}]");
         setEventMetadata("VALID_APERCAJCOD",",oparms:[]}");
         setEventMetadata("VALID_APERCAJITEM","{handler:'Valid_Apercajitem',iparms:[{av:'A358CajCod',fld:'CAJCOD',pic:'ZZZZZ9'},{av:'A359AperCajCod',fld:'APERCAJCOD',pic:''},{av:'A373AperCajItem',fld:'APERCAJITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_APERCAJITEM",",oparms:[{av:'A463AperRepFec',fld:'APERREPFEC',pic:''},{av:'A466AperRepMonCod',fld:'APERREPMONCOD',pic:'ZZZZZ9'},{av:'A464AperRepForCod',fld:'APERREPFORCOD',pic:'ZZZZZ9'},{av:'A459AperRepBanCod',fld:'APERREPBANCOD',pic:'ZZZZZ9'},{av:'A462AperRepCueBan',fld:'APERREPCUEBAN',pic:''},{av:'A461AperRepCheq',fld:'APERREPCHEQ',pic:''},{av:'A465AperRepImp',fld:'APERREPIMP',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A469AperRepTMov',fld:'APERREPTMOV',pic:'ZZZZZ9'},{av:'A460AperRepBanReg',fld:'APERREPBANREG',pic:''},{av:'A468AperRepSts',fld:'APERREPSTS',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z358CajCod'},{av:'Z359AperCajCod'},{av:'Z373AperCajItem'},{av:'Z463AperRepFec'},{av:'Z466AperRepMonCod'},{av:'Z464AperRepForCod'},{av:'Z459AperRepBanCod'},{av:'Z462AperRepCueBan'},{av:'Z461AperRepCheq'},{av:'Z465AperRepImp'},{av:'Z469AperRepTMov'},{av:'Z460AperRepBanReg'},{av:'Z468AperRepSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_APERREPFEC","{handler:'Valid_Aperrepfec',iparms:[]");
         setEventMetadata("VALID_APERREPFEC",",oparms:[]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z359AperCajCod = "";
         Z463AperRepFec = DateTime.MinValue;
         Z462AperRepCueBan = "";
         Z461AperRepCheq = "";
         Z460AperRepBanReg = "";
         Z468AperRepSts = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A359AperCajCod = "";
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
         bttBtn_get_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A463AperRepFec = DateTime.MinValue;
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         A462AperRepCueBan = "";
         lblTextblock9_Jsonclick = "";
         A461AperRepCheq = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         A460AperRepBanReg = "";
         lblTextblock13_Jsonclick = "";
         A468AperRepSts = "";
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
         T00535_A373AperCajItem = new int[1] ;
         T00535_A463AperRepFec = new DateTime[] {DateTime.MinValue} ;
         T00535_A466AperRepMonCod = new int[1] ;
         T00535_A464AperRepForCod = new int[1] ;
         T00535_A459AperRepBanCod = new int[1] ;
         T00535_A462AperRepCueBan = new string[] {""} ;
         T00535_A461AperRepCheq = new string[] {""} ;
         T00535_A465AperRepImp = new decimal[1] ;
         T00535_A469AperRepTMov = new int[1] ;
         T00535_A460AperRepBanReg = new string[] {""} ;
         T00535_A468AperRepSts = new string[] {""} ;
         T00535_A358CajCod = new int[1] ;
         T00535_A359AperCajCod = new string[] {""} ;
         T00534_A358CajCod = new int[1] ;
         T00536_A358CajCod = new int[1] ;
         T00537_A358CajCod = new int[1] ;
         T00537_A359AperCajCod = new string[] {""} ;
         T00537_A373AperCajItem = new int[1] ;
         T00533_A373AperCajItem = new int[1] ;
         T00533_A463AperRepFec = new DateTime[] {DateTime.MinValue} ;
         T00533_A466AperRepMonCod = new int[1] ;
         T00533_A464AperRepForCod = new int[1] ;
         T00533_A459AperRepBanCod = new int[1] ;
         T00533_A462AperRepCueBan = new string[] {""} ;
         T00533_A461AperRepCheq = new string[] {""} ;
         T00533_A465AperRepImp = new decimal[1] ;
         T00533_A469AperRepTMov = new int[1] ;
         T00533_A460AperRepBanReg = new string[] {""} ;
         T00533_A468AperRepSts = new string[] {""} ;
         T00533_A358CajCod = new int[1] ;
         T00533_A359AperCajCod = new string[] {""} ;
         sMode170 = "";
         T00538_A358CajCod = new int[1] ;
         T00538_A359AperCajCod = new string[] {""} ;
         T00538_A373AperCajItem = new int[1] ;
         T00539_A358CajCod = new int[1] ;
         T00539_A359AperCajCod = new string[] {""} ;
         T00539_A373AperCajItem = new int[1] ;
         T00532_A373AperCajItem = new int[1] ;
         T00532_A463AperRepFec = new DateTime[] {DateTime.MinValue} ;
         T00532_A466AperRepMonCod = new int[1] ;
         T00532_A464AperRepForCod = new int[1] ;
         T00532_A459AperRepBanCod = new int[1] ;
         T00532_A462AperRepCueBan = new string[] {""} ;
         T00532_A461AperRepCheq = new string[] {""} ;
         T00532_A465AperRepImp = new decimal[1] ;
         T00532_A469AperRepTMov = new int[1] ;
         T00532_A460AperRepBanReg = new string[] {""} ;
         T00532_A468AperRepSts = new string[] {""} ;
         T00532_A358CajCod = new int[1] ;
         T00532_A359AperCajCod = new string[] {""} ;
         T005313_A358CajCod = new int[1] ;
         T005313_A359AperCajCod = new string[] {""} ;
         T005313_A373AperCajItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T005314_A358CajCod = new int[1] ;
         ZZ359AperCajCod = "";
         ZZ463AperRepFec = DateTime.MinValue;
         ZZ462AperRepCueBan = "";
         ZZ461AperRepCheq = "";
         ZZ460AperRepBanReg = "";
         ZZ468AperRepSts = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tscajareposicion__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tscajareposicion__default(),
            new Object[][] {
                new Object[] {
               T00532_A373AperCajItem, T00532_A463AperRepFec, T00532_A466AperRepMonCod, T00532_A464AperRepForCod, T00532_A459AperRepBanCod, T00532_A462AperRepCueBan, T00532_A461AperRepCheq, T00532_A465AperRepImp, T00532_A469AperRepTMov, T00532_A460AperRepBanReg,
               T00532_A468AperRepSts, T00532_A358CajCod, T00532_A359AperCajCod
               }
               , new Object[] {
               T00533_A373AperCajItem, T00533_A463AperRepFec, T00533_A466AperRepMonCod, T00533_A464AperRepForCod, T00533_A459AperRepBanCod, T00533_A462AperRepCueBan, T00533_A461AperRepCheq, T00533_A465AperRepImp, T00533_A469AperRepTMov, T00533_A460AperRepBanReg,
               T00533_A468AperRepSts, T00533_A358CajCod, T00533_A359AperCajCod
               }
               , new Object[] {
               T00534_A358CajCod
               }
               , new Object[] {
               T00535_A373AperCajItem, T00535_A463AperRepFec, T00535_A466AperRepMonCod, T00535_A464AperRepForCod, T00535_A459AperRepBanCod, T00535_A462AperRepCueBan, T00535_A461AperRepCheq, T00535_A465AperRepImp, T00535_A469AperRepTMov, T00535_A460AperRepBanReg,
               T00535_A468AperRepSts, T00535_A358CajCod, T00535_A359AperCajCod
               }
               , new Object[] {
               T00536_A358CajCod
               }
               , new Object[] {
               T00537_A358CajCod, T00537_A359AperCajCod, T00537_A373AperCajItem
               }
               , new Object[] {
               T00538_A358CajCod, T00538_A359AperCajCod, T00538_A373AperCajItem
               }
               , new Object[] {
               T00539_A358CajCod, T00539_A359AperCajCod, T00539_A373AperCajItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005313_A358CajCod, T005313_A359AperCajCod, T005313_A373AperCajItem
               }
               , new Object[] {
               T005314_A358CajCod
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
      private short RcdFound170 ;
      private short nIsDirty_170 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z358CajCod ;
      private int Z373AperCajItem ;
      private int Z466AperRepMonCod ;
      private int Z464AperRepForCod ;
      private int Z459AperRepBanCod ;
      private int Z469AperRepTMov ;
      private int A358CajCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCajCod_Enabled ;
      private int edtAperCajCod_Enabled ;
      private int A373AperCajItem ;
      private int edtAperCajItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtAperRepFec_Enabled ;
      private int A466AperRepMonCod ;
      private int edtAperRepMonCod_Enabled ;
      private int A464AperRepForCod ;
      private int edtAperRepForCod_Enabled ;
      private int A459AperRepBanCod ;
      private int edtAperRepBanCod_Enabled ;
      private int edtAperRepCueBan_Enabled ;
      private int edtAperRepCheq_Enabled ;
      private int edtAperRepImp_Enabled ;
      private int A469AperRepTMov ;
      private int edtAperRepTMov_Enabled ;
      private int edtAperRepBanReg_Enabled ;
      private int edtAperRepSts_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ358CajCod ;
      private int ZZ373AperCajItem ;
      private int ZZ466AperRepMonCod ;
      private int ZZ464AperRepForCod ;
      private int ZZ459AperRepBanCod ;
      private int ZZ469AperRepTMov ;
      private decimal Z465AperRepImp ;
      private decimal A465AperRepImp ;
      private decimal ZZ465AperRepImp ;
      private string sPrefix ;
      private string Z359AperCajCod ;
      private string Z462AperRepCueBan ;
      private string Z461AperRepCheq ;
      private string Z460AperRepBanReg ;
      private string Z468AperRepSts ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A359AperCajCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCajCod_Internalname ;
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
      private string edtCajCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtAperCajCod_Internalname ;
      private string edtAperCajCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtAperCajItem_Internalname ;
      private string edtAperCajItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtAperRepFec_Internalname ;
      private string edtAperRepFec_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtAperRepMonCod_Internalname ;
      private string edtAperRepMonCod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtAperRepForCod_Internalname ;
      private string edtAperRepForCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtAperRepBanCod_Internalname ;
      private string edtAperRepBanCod_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtAperRepCueBan_Internalname ;
      private string A462AperRepCueBan ;
      private string edtAperRepCueBan_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtAperRepCheq_Internalname ;
      private string A461AperRepCheq ;
      private string edtAperRepCheq_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtAperRepImp_Internalname ;
      private string edtAperRepImp_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtAperRepTMov_Internalname ;
      private string edtAperRepTMov_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtAperRepBanReg_Internalname ;
      private string A460AperRepBanReg ;
      private string edtAperRepBanReg_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtAperRepSts_Internalname ;
      private string A468AperRepSts ;
      private string edtAperRepSts_Jsonclick ;
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
      private string sMode170 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ359AperCajCod ;
      private string ZZ462AperRepCueBan ;
      private string ZZ461AperRepCheq ;
      private string ZZ460AperRepBanReg ;
      private string ZZ468AperRepSts ;
      private DateTime Z463AperRepFec ;
      private DateTime A463AperRepFec ;
      private DateTime ZZ463AperRepFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00535_A373AperCajItem ;
      private DateTime[] T00535_A463AperRepFec ;
      private int[] T00535_A466AperRepMonCod ;
      private int[] T00535_A464AperRepForCod ;
      private int[] T00535_A459AperRepBanCod ;
      private string[] T00535_A462AperRepCueBan ;
      private string[] T00535_A461AperRepCheq ;
      private decimal[] T00535_A465AperRepImp ;
      private int[] T00535_A469AperRepTMov ;
      private string[] T00535_A460AperRepBanReg ;
      private string[] T00535_A468AperRepSts ;
      private int[] T00535_A358CajCod ;
      private string[] T00535_A359AperCajCod ;
      private int[] T00534_A358CajCod ;
      private int[] T00536_A358CajCod ;
      private int[] T00537_A358CajCod ;
      private string[] T00537_A359AperCajCod ;
      private int[] T00537_A373AperCajItem ;
      private int[] T00533_A373AperCajItem ;
      private DateTime[] T00533_A463AperRepFec ;
      private int[] T00533_A466AperRepMonCod ;
      private int[] T00533_A464AperRepForCod ;
      private int[] T00533_A459AperRepBanCod ;
      private string[] T00533_A462AperRepCueBan ;
      private string[] T00533_A461AperRepCheq ;
      private decimal[] T00533_A465AperRepImp ;
      private int[] T00533_A469AperRepTMov ;
      private string[] T00533_A460AperRepBanReg ;
      private string[] T00533_A468AperRepSts ;
      private int[] T00533_A358CajCod ;
      private string[] T00533_A359AperCajCod ;
      private int[] T00538_A358CajCod ;
      private string[] T00538_A359AperCajCod ;
      private int[] T00538_A373AperCajItem ;
      private int[] T00539_A358CajCod ;
      private string[] T00539_A359AperCajCod ;
      private int[] T00539_A373AperCajItem ;
      private int[] T00532_A373AperCajItem ;
      private DateTime[] T00532_A463AperRepFec ;
      private int[] T00532_A466AperRepMonCod ;
      private int[] T00532_A464AperRepForCod ;
      private int[] T00532_A459AperRepBanCod ;
      private string[] T00532_A462AperRepCueBan ;
      private string[] T00532_A461AperRepCheq ;
      private decimal[] T00532_A465AperRepImp ;
      private int[] T00532_A469AperRepTMov ;
      private string[] T00532_A460AperRepBanReg ;
      private string[] T00532_A468AperRepSts ;
      private int[] T00532_A358CajCod ;
      private string[] T00532_A359AperCajCod ;
      private int[] T005313_A358CajCod ;
      private string[] T005313_A359AperCajCod ;
      private int[] T005313_A373AperCajItem ;
      private int[] T005314_A358CajCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class tscajareposicion__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tscajareposicion__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00535;
        prmT00535 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0) ,
        new ParDef("@AperCajItem",GXType.Int32,6,0)
        };
        Object[] prmT00534;
        prmT00534 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0)
        };
        Object[] prmT00536;
        prmT00536 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0)
        };
        Object[] prmT00537;
        prmT00537 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0) ,
        new ParDef("@AperCajItem",GXType.Int32,6,0)
        };
        Object[] prmT00533;
        prmT00533 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0) ,
        new ParDef("@AperCajItem",GXType.Int32,6,0)
        };
        Object[] prmT00538;
        prmT00538 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0) ,
        new ParDef("@AperCajItem",GXType.Int32,6,0)
        };
        Object[] prmT00539;
        prmT00539 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0) ,
        new ParDef("@AperCajItem",GXType.Int32,6,0)
        };
        Object[] prmT00532;
        prmT00532 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0) ,
        new ParDef("@AperCajItem",GXType.Int32,6,0)
        };
        Object[] prmT005310;
        prmT005310 = new Object[] {
        new ParDef("@AperCajItem",GXType.Int32,6,0) ,
        new ParDef("@AperRepFec",GXType.Date,8,0) ,
        new ParDef("@AperRepMonCod",GXType.Int32,6,0) ,
        new ParDef("@AperRepForCod",GXType.Int32,6,0) ,
        new ParDef("@AperRepBanCod",GXType.Int32,6,0) ,
        new ParDef("@AperRepCueBan",GXType.NChar,20,0) ,
        new ParDef("@AperRepCheq",GXType.NChar,20,0) ,
        new ParDef("@AperRepImp",GXType.Decimal,15,2) ,
        new ParDef("@AperRepTMov",GXType.Int32,6,0) ,
        new ParDef("@AperRepBanReg",GXType.NChar,10,0) ,
        new ParDef("@AperRepSts",GXType.NChar,1,0) ,
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0)
        };
        Object[] prmT005311;
        prmT005311 = new Object[] {
        new ParDef("@AperRepFec",GXType.Date,8,0) ,
        new ParDef("@AperRepMonCod",GXType.Int32,6,0) ,
        new ParDef("@AperRepForCod",GXType.Int32,6,0) ,
        new ParDef("@AperRepBanCod",GXType.Int32,6,0) ,
        new ParDef("@AperRepCueBan",GXType.NChar,20,0) ,
        new ParDef("@AperRepCheq",GXType.NChar,20,0) ,
        new ParDef("@AperRepImp",GXType.Decimal,15,2) ,
        new ParDef("@AperRepTMov",GXType.Int32,6,0) ,
        new ParDef("@AperRepBanReg",GXType.NChar,10,0) ,
        new ParDef("@AperRepSts",GXType.NChar,1,0) ,
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0) ,
        new ParDef("@AperCajItem",GXType.Int32,6,0)
        };
        Object[] prmT005312;
        prmT005312 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0) ,
        new ParDef("@AperCajItem",GXType.Int32,6,0)
        };
        Object[] prmT005313;
        prmT005313 = new Object[] {
        };
        Object[] prmT005314;
        prmT005314 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00532", "SELECT [AperCajItem], [AperRepFec], [AperRepMonCod], [AperRepForCod], [AperRepBanCod], [AperRepCueBan], [AperRepCheq], [AperRepImp], [AperRepTMov], [AperRepBanReg], [AperRepSts], [CajCod], [AperCajCod] FROM [TSCAJAREPOSICION] WITH (UPDLOCK) WHERE [CajCod] = @CajCod AND [AperCajCod] = @AperCajCod AND [AperCajItem] = @AperCajItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00532,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00533", "SELECT [AperCajItem], [AperRepFec], [AperRepMonCod], [AperRepForCod], [AperRepBanCod], [AperRepCueBan], [AperRepCheq], [AperRepImp], [AperRepTMov], [AperRepBanReg], [AperRepSts], [CajCod], [AperCajCod] FROM [TSCAJAREPOSICION] WHERE [CajCod] = @CajCod AND [AperCajCod] = @AperCajCod AND [AperCajItem] = @AperCajItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00533,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00534", "SELECT [CajCod] FROM [TSAPERTURACAJA] WHERE [CajCod] = @CajCod AND [AperCajCod] = @AperCajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00534,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00535", "SELECT TM1.[AperCajItem], TM1.[AperRepFec], TM1.[AperRepMonCod], TM1.[AperRepForCod], TM1.[AperRepBanCod], TM1.[AperRepCueBan], TM1.[AperRepCheq], TM1.[AperRepImp], TM1.[AperRepTMov], TM1.[AperRepBanReg], TM1.[AperRepSts], TM1.[CajCod], TM1.[AperCajCod] FROM [TSCAJAREPOSICION] TM1 WHERE TM1.[CajCod] = @CajCod and TM1.[AperCajCod] = @AperCajCod and TM1.[AperCajItem] = @AperCajItem ORDER BY TM1.[CajCod], TM1.[AperCajCod], TM1.[AperCajItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00535,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00536", "SELECT [CajCod] FROM [TSAPERTURACAJA] WHERE [CajCod] = @CajCod AND [AperCajCod] = @AperCajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00536,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00537", "SELECT [CajCod], [AperCajCod], [AperCajItem] FROM [TSCAJAREPOSICION] WHERE [CajCod] = @CajCod AND [AperCajCod] = @AperCajCod AND [AperCajItem] = @AperCajItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00537,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00538", "SELECT TOP 1 [CajCod], [AperCajCod], [AperCajItem] FROM [TSCAJAREPOSICION] WHERE ( [CajCod] > @CajCod or [CajCod] = @CajCod and [AperCajCod] > @AperCajCod or [AperCajCod] = @AperCajCod and [CajCod] = @CajCod and [AperCajItem] > @AperCajItem) ORDER BY [CajCod], [AperCajCod], [AperCajItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00538,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00539", "SELECT TOP 1 [CajCod], [AperCajCod], [AperCajItem] FROM [TSCAJAREPOSICION] WHERE ( [CajCod] < @CajCod or [CajCod] = @CajCod and [AperCajCod] < @AperCajCod or [AperCajCod] = @AperCajCod and [CajCod] = @CajCod and [AperCajItem] < @AperCajItem) ORDER BY [CajCod] DESC, [AperCajCod] DESC, [AperCajItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00539,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005310", "INSERT INTO [TSCAJAREPOSICION]([AperCajItem], [AperRepFec], [AperRepMonCod], [AperRepForCod], [AperRepBanCod], [AperRepCueBan], [AperRepCheq], [AperRepImp], [AperRepTMov], [AperRepBanReg], [AperRepSts], [CajCod], [AperCajCod]) VALUES(@AperCajItem, @AperRepFec, @AperRepMonCod, @AperRepForCod, @AperRepBanCod, @AperRepCueBan, @AperRepCheq, @AperRepImp, @AperRepTMov, @AperRepBanReg, @AperRepSts, @CajCod, @AperCajCod)", GxErrorMask.GX_NOMASK,prmT005310)
           ,new CursorDef("T005311", "UPDATE [TSCAJAREPOSICION] SET [AperRepFec]=@AperRepFec, [AperRepMonCod]=@AperRepMonCod, [AperRepForCod]=@AperRepForCod, [AperRepBanCod]=@AperRepBanCod, [AperRepCueBan]=@AperRepCueBan, [AperRepCheq]=@AperRepCheq, [AperRepImp]=@AperRepImp, [AperRepTMov]=@AperRepTMov, [AperRepBanReg]=@AperRepBanReg, [AperRepSts]=@AperRepSts  WHERE [CajCod] = @CajCod AND [AperCajCod] = @AperCajCod AND [AperCajItem] = @AperCajItem", GxErrorMask.GX_NOMASK,prmT005311)
           ,new CursorDef("T005312", "DELETE FROM [TSCAJAREPOSICION]  WHERE [CajCod] = @CajCod AND [AperCajCod] = @AperCajCod AND [AperCajItem] = @AperCajItem", GxErrorMask.GX_NOMASK,prmT005312)
           ,new CursorDef("T005313", "SELECT [CajCod], [AperCajCod], [AperCajItem] FROM [TSCAJAREPOSICION] ORDER BY [CajCod], [AperCajCod], [AperCajItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005313,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005314", "SELECT [CajCod] FROM [TSAPERTURACAJA] WHERE [CajCod] = @CajCod AND [AperCajCod] = @AperCajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005314,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((string[]) buf[10])[0] = rslt.getString(11, 1);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((string[]) buf[10])[0] = rslt.getString(11, 1);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((string[]) buf[10])[0] = rslt.getString(11, 1);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
