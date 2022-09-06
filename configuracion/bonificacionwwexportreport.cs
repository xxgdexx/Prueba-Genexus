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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.configuracion {
   public class bonificacionwwexportreport : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public bonificacionwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public bonificacionwwexportreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         bonificacionwwexportreport objbonificacionwwexportreport;
         objbonificacionwwexportreport = new bonificacionwwexportreport();
         objbonificacionwwexportreport.context.SetSubmitInitialConfig(context);
         objbonificacionwwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objbonificacionwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((bonificacionwwexportreport)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            AV40Title = "Lista de Bonificacion";
            /* Execute user subroutine: 'PRINTFILTERS' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTDATA' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTFOOTER' */
            S171 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H570( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( AV24GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV21GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV24GridState.gxTpr_Dynamicfilters.Item(1));
            AV12DynamicFiltersSelector1 = AV21GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CBONPRODCOD") == 0 )
            {
               AV13CBonProdCod1 = AV21GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CBonProdCod1)) )
               {
                  AV14CBonProdCod = AV13CBonProdCod1;
                  H570( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Producto", 25, Gx_line+0, 77, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14CBonProdCod, "@!")), 77, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV24GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV15DynamicFiltersEnabled2 = true;
               AV21GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV24GridState.gxTpr_Dynamicfilters.Item(2));
               AV16DynamicFiltersSelector2 = AV21GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV16DynamicFiltersSelector2, "CBONPRODCOD") == 0 )
               {
                  AV17CBonProdCod2 = AV21GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17CBonProdCod2)) )
                  {
                     AV14CBonProdCod = AV17CBonProdCod2;
                     H570( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Producto", 25, Gx_line+0, 77, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14CBonProdCod, "@!")), 77, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV24GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV18DynamicFiltersEnabled3 = true;
                  AV21GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV24GridState.gxTpr_Dynamicfilters.Item(3));
                  AV19DynamicFiltersSelector3 = AV21GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV19DynamicFiltersSelector3, "CBONPRODCOD") == 0 )
                  {
                     AV20CBonProdCod3 = AV21GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20CBonProdCod3)) )
                     {
                        AV14CBonProdCod = AV20CBonProdCod3;
                        H570( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText("Producto", 25, Gx_line+0, 77, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14CBonProdCod, "@!")), 77, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFCBonProdCod_Sel)) )
         {
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 77, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27TFCBonProdCod_Sel, "@!")), 77, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFCBonProdCod)) )
            {
               H570( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 77, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26TFCBonProdCod, "@!")), 77, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFCBonProdDsc_Sel)) )
         {
            H570( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Producto", 25, Gx_line+0, 77, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29TFCBonProdDsc_Sel, "")), 77, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCBonProdDsc)) )
            {
               H570( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Producto", 25, Gx_line+0, 77, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28TFCBonProdDsc, "")), 77, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H570( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H570( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 281, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Producto", 285, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV47Configuracion_bonificacionwwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV48Configuracion_bonificacionwwds_2_cbonprodcod1 = AV13CBonProdCod1;
         AV49Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 = AV15DynamicFiltersEnabled2;
         AV50Configuracion_bonificacionwwds_4_dynamicfiltersselector2 = AV16DynamicFiltersSelector2;
         AV51Configuracion_bonificacionwwds_5_cbonprodcod2 = AV17CBonProdCod2;
         AV52Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 = AV18DynamicFiltersEnabled3;
         AV53Configuracion_bonificacionwwds_7_dynamicfiltersselector3 = AV19DynamicFiltersSelector3;
         AV54Configuracion_bonificacionwwds_8_cbonprodcod3 = AV20CBonProdCod3;
         AV55Configuracion_bonificacionwwds_9_tfcbonprodcod = AV26TFCBonProdCod;
         AV56Configuracion_bonificacionwwds_10_tfcbonprodcod_sel = AV27TFCBonProdCod_Sel;
         AV57Configuracion_bonificacionwwds_11_tfcbonproddsc = AV28TFCBonProdDsc;
         AV58Configuracion_bonificacionwwds_12_tfcbonproddsc_sel = AV29TFCBonProdDsc_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV47Configuracion_bonificacionwwds_1_dynamicfiltersselector1 ,
                                              AV48Configuracion_bonificacionwwds_2_cbonprodcod1 ,
                                              AV49Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 ,
                                              AV50Configuracion_bonificacionwwds_4_dynamicfiltersselector2 ,
                                              AV51Configuracion_bonificacionwwds_5_cbonprodcod2 ,
                                              AV52Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 ,
                                              AV53Configuracion_bonificacionwwds_7_dynamicfiltersselector3 ,
                                              AV54Configuracion_bonificacionwwds_8_cbonprodcod3 ,
                                              AV56Configuracion_bonificacionwwds_10_tfcbonprodcod_sel ,
                                              AV55Configuracion_bonificacionwwds_9_tfcbonprodcod ,
                                              AV58Configuracion_bonificacionwwds_12_tfcbonproddsc_sel ,
                                              AV57Configuracion_bonificacionwwds_11_tfcbonproddsc ,
                                              A81CBonProdCod ,
                                              A503CBonProdDsc ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Configuracion_bonificacionwwds_9_tfcbonprodcod = StringUtil.PadR( StringUtil.RTrim( AV55Configuracion_bonificacionwwds_9_tfcbonprodcod), 15, "%");
         lV57Configuracion_bonificacionwwds_11_tfcbonproddsc = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_bonificacionwwds_11_tfcbonproddsc), 100, "%");
         /* Using cursor P00572 */
         pr_default.execute(0, new Object[] {AV48Configuracion_bonificacionwwds_2_cbonprodcod1, AV51Configuracion_bonificacionwwds_5_cbonprodcod2, AV54Configuracion_bonificacionwwds_8_cbonprodcod3, lV55Configuracion_bonificacionwwds_9_tfcbonprodcod, AV56Configuracion_bonificacionwwds_10_tfcbonprodcod_sel, lV57Configuracion_bonificacionwwds_11_tfcbonproddsc, AV58Configuracion_bonificacionwwds_12_tfcbonproddsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A503CBonProdDsc = P00572_A503CBonProdDsc[0];
            A81CBonProdCod = P00572_A81CBonProdCod[0];
            A503CBonProdDsc = P00572_A503CBonProdDsc[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H570( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A81CBonProdCod, "@!")), 30, Gx_line+10, 281, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A503CBonProdDsc, "")), 285, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+36);
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S161 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV22Session.Get("Configuracion.BonificacionWWGridState"), "") == 0 )
         {
            AV24GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.BonificacionWWGridState"), null, "", "");
         }
         else
         {
            AV24GridState.FromXml(AV22Session.Get("Configuracion.BonificacionWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV24GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV24GridState.gxTpr_Ordereddsc;
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV24GridState.gxTpr_Filtervalues.Count )
         {
            AV25GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV24GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV25GridStateFilterValue.gxTpr_Name, "TFCBONPRODCOD") == 0 )
            {
               AV26TFCBonProdCod = AV25GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV25GridStateFilterValue.gxTpr_Name, "TFCBONPRODCOD_SEL") == 0 )
            {
               AV27TFCBonProdCod_Sel = AV25GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV25GridStateFilterValue.gxTpr_Name, "TFCBONPRODDSC") == 0 )
            {
               AV28TFCBonProdDsc = AV25GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV25GridStateFilterValue.gxTpr_Name, "TFCBONPRODDSC_SEL") == 0 )
            {
               AV29TFCBonProdDsc_Sel = AV25GridStateFilterValue.gxTpr_Value;
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void H570( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV38PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV35DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               AV33AppName = "DVelop Software Solutions";
               AV39Phone = "+1 550 8923";
               AV37Mail = "info@mail.com";
               AV41Website = "http://www.web.com";
               AV30AddressLine1 = "French Boulevard 2859";
               AV31AddressLine2 = "Downtown";
               AV32AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+128);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Title = "";
         AV24GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV21GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV13CBonProdCod1 = "";
         AV14CBonProdCod = "";
         AV16DynamicFiltersSelector2 = "";
         AV17CBonProdCod2 = "";
         AV19DynamicFiltersSelector3 = "";
         AV20CBonProdCod3 = "";
         AV27TFCBonProdCod_Sel = "";
         AV26TFCBonProdCod = "";
         AV29TFCBonProdDsc_Sel = "";
         AV28TFCBonProdDsc = "";
         AV47Configuracion_bonificacionwwds_1_dynamicfiltersselector1 = "";
         AV48Configuracion_bonificacionwwds_2_cbonprodcod1 = "";
         AV50Configuracion_bonificacionwwds_4_dynamicfiltersselector2 = "";
         AV51Configuracion_bonificacionwwds_5_cbonprodcod2 = "";
         AV53Configuracion_bonificacionwwds_7_dynamicfiltersselector3 = "";
         AV54Configuracion_bonificacionwwds_8_cbonprodcod3 = "";
         AV55Configuracion_bonificacionwwds_9_tfcbonprodcod = "";
         AV56Configuracion_bonificacionwwds_10_tfcbonprodcod_sel = "";
         AV57Configuracion_bonificacionwwds_11_tfcbonproddsc = "";
         AV58Configuracion_bonificacionwwds_12_tfcbonproddsc_sel = "";
         scmdbuf = "";
         lV55Configuracion_bonificacionwwds_9_tfcbonprodcod = "";
         lV57Configuracion_bonificacionwwds_11_tfcbonproddsc = "";
         A81CBonProdCod = "";
         A503CBonProdDsc = "";
         P00572_A503CBonProdDsc = new string[] {""} ;
         P00572_A81CBonProdCod = new string[] {""} ;
         AV22Session = context.GetSession();
         AV25GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38PageInfo = "";
         AV35DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV33AppName = "";
         AV39Phone = "";
         AV37Mail = "";
         AV41Website = "";
         AV30AddressLine1 = "";
         AV31AddressLine2 = "";
         AV32AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.bonificacionwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00572_A503CBonProdDsc, P00572_A81CBonProdCod
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV59GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV13CBonProdCod1 ;
      private string AV14CBonProdCod ;
      private string AV17CBonProdCod2 ;
      private string AV20CBonProdCod3 ;
      private string AV27TFCBonProdCod_Sel ;
      private string AV26TFCBonProdCod ;
      private string AV29TFCBonProdDsc_Sel ;
      private string AV28TFCBonProdDsc ;
      private string AV48Configuracion_bonificacionwwds_2_cbonprodcod1 ;
      private string AV51Configuracion_bonificacionwwds_5_cbonprodcod2 ;
      private string AV54Configuracion_bonificacionwwds_8_cbonprodcod3 ;
      private string AV55Configuracion_bonificacionwwds_9_tfcbonprodcod ;
      private string AV56Configuracion_bonificacionwwds_10_tfcbonprodcod_sel ;
      private string AV57Configuracion_bonificacionwwds_11_tfcbonproddsc ;
      private string AV58Configuracion_bonificacionwwds_12_tfcbonproddsc_sel ;
      private string scmdbuf ;
      private string lV55Configuracion_bonificacionwwds_9_tfcbonprodcod ;
      private string lV57Configuracion_bonificacionwwds_11_tfcbonproddsc ;
      private string A81CBonProdCod ;
      private string A503CBonProdDsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV15DynamicFiltersEnabled2 ;
      private bool AV18DynamicFiltersEnabled3 ;
      private bool AV49Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 ;
      private bool AV52Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV40Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV16DynamicFiltersSelector2 ;
      private string AV19DynamicFiltersSelector3 ;
      private string AV47Configuracion_bonificacionwwds_1_dynamicfiltersselector1 ;
      private string AV50Configuracion_bonificacionwwds_4_dynamicfiltersselector2 ;
      private string AV53Configuracion_bonificacionwwds_7_dynamicfiltersselector3 ;
      private string AV38PageInfo ;
      private string AV35DateInfo ;
      private string AV33AppName ;
      private string AV39Phone ;
      private string AV37Mail ;
      private string AV41Website ;
      private string AV30AddressLine1 ;
      private string AV31AddressLine2 ;
      private string AV32AddressLine3 ;
      private IGxSession AV22Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00572_A503CBonProdDsc ;
      private string[] P00572_A81CBonProdCod ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV24GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV25GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV21GridStateDynamicFilter ;
   }

   public class bonificacionwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00572( IGxContext context ,
                                             string AV47Configuracion_bonificacionwwds_1_dynamicfiltersselector1 ,
                                             string AV48Configuracion_bonificacionwwds_2_cbonprodcod1 ,
                                             bool AV49Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 ,
                                             string AV50Configuracion_bonificacionwwds_4_dynamicfiltersselector2 ,
                                             string AV51Configuracion_bonificacionwwds_5_cbonprodcod2 ,
                                             bool AV52Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 ,
                                             string AV53Configuracion_bonificacionwwds_7_dynamicfiltersselector3 ,
                                             string AV54Configuracion_bonificacionwwds_8_cbonprodcod3 ,
                                             string AV56Configuracion_bonificacionwwds_10_tfcbonprodcod_sel ,
                                             string AV55Configuracion_bonificacionwwds_9_tfcbonprodcod ,
                                             string AV58Configuracion_bonificacionwwds_12_tfcbonproddsc_sel ,
                                             string AV57Configuracion_bonificacionwwds_11_tfcbonproddsc ,
                                             string A81CBonProdCod ,
                                             string A503CBonProdDsc ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.[ProdDsc] AS CBonProdDsc, T1.[CBonProdCod] AS CBonProdCod FROM ([CBONIFICACION] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[CBonProdCod])";
         if ( ( StringUtil.StrCmp(AV47Configuracion_bonificacionwwds_1_dynamicfiltersselector1, "CBONPRODCOD") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Configuracion_bonificacionwwds_2_cbonprodcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV48Configuracion_bonificacionwwds_2_cbonprodcod1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( AV49Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV50Configuracion_bonificacionwwds_4_dynamicfiltersselector2, "CBONPRODCOD") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Configuracion_bonificacionwwds_5_cbonprodcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV51Configuracion_bonificacionwwds_5_cbonprodcod2)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV52Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV53Configuracion_bonificacionwwds_7_dynamicfiltersselector3, "CBONPRODCOD") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_bonificacionwwds_8_cbonprodcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV54Configuracion_bonificacionwwds_8_cbonprodcod3)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_bonificacionwwds_10_tfcbonprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_bonificacionwwds_9_tfcbonprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] like @lV55Configuracion_bonificacionwwds_9_tfcbonprodcod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_bonificacionwwds_10_tfcbonprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV56Configuracion_bonificacionwwds_10_tfcbonprodcod_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_bonificacionwwds_12_tfcbonproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_bonificacionwwds_11_tfcbonproddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[ProdDsc] like @lV57Configuracion_bonificacionwwds_11_tfcbonproddsc)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_bonificacionwwds_12_tfcbonproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[ProdDsc] = @AV58Configuracion_bonificacionwwds_12_tfcbonproddsc_sel)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CBonProdCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CBonProdCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProdDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProdDsc] DESC";
         }
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00572(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00572;
          prmP00572 = new Object[] {
          new ParDef("@AV48Configuracion_bonificacionwwds_2_cbonprodcod1",GXType.NChar,15,0) ,
          new ParDef("@AV51Configuracion_bonificacionwwds_5_cbonprodcod2",GXType.NChar,15,0) ,
          new ParDef("@AV54Configuracion_bonificacionwwds_8_cbonprodcod3",GXType.NChar,15,0) ,
          new ParDef("@lV55Configuracion_bonificacionwwds_9_tfcbonprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV56Configuracion_bonificacionwwds_10_tfcbonprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV57Configuracion_bonificacionwwds_11_tfcbonproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV58Configuracion_bonificacionwwds_12_tfcbonproddsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00572", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00572,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                return;
       }
    }

 }

}
