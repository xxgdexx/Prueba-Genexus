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
   public class correlativoswwexportreport : GXWebProcedure
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

      public correlativoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public correlativoswwexportreport( IGxContext context )
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
         correlativoswwexportreport objcorrelativoswwexportreport;
         objcorrelativoswwexportreport = new correlativoswwexportreport();
         objcorrelativoswwexportreport.context.SetSubmitInitialConfig(context);
         objcorrelativoswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcorrelativoswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((correlativoswwexportreport)stateInfo).executePrivate();
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
            AV45Title = "Lista de Correlativos";
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
            H500( true, 0) ;
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
         if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(1));
            AV12DynamicFiltersSelector1 = AV25GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CORTIP") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV47CorTip1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47CorTip1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV48FilterCorTipDescription = StringUtil.Format( "%1 (%2)", "Tipo de Correlativo", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV48FilterCorTipDescription = StringUtil.Format( "%1 (%2)", "Tipo de Correlativo", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV49CorTip = AV47CorTip1;
                  H500( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48FilterCorTipDescription, "")), 25, Gx_line+0, 236, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49CorTip, "")), 236, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "CORTIP") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV50CorTip2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50CorTip2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV48FilterCorTipDescription = StringUtil.Format( "%1 (%2)", "Tipo de Correlativo", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV48FilterCorTipDescription = StringUtil.Format( "%1 (%2)", "Tipo de Correlativo", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV49CorTip = AV50CorTip2;
                     H500( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48FilterCorTipDescription, "")), 25, Gx_line+0, 236, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49CorTip, "")), 236, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "CORTIP") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV51CorTip3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51CorTip3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV48FilterCorTipDescription = StringUtil.Format( "%1 (%2)", "Tipo de Correlativo", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV48FilterCorTipDescription = StringUtil.Format( "%1 (%2)", "Tipo de Correlativo", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV49CorTip = AV51CorTip3;
                        H500( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48FilterCorTipDescription, "")), 25, Gx_line+0, 236, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49CorTip, "")), 236, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFCorTip_Sel)) )
         {
            H500( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo de Correlativo", 25, Gx_line+0, 236, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TFCorTip_Sel, "")), 236, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFCorTip)) )
            {
               H500( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo de Correlativo", 25, Gx_line+0, 236, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30TFCorTip, "")), 236, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV32TFCorNum) && (0==AV33TFCorNum_To) ) )
         {
            H500( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Numero", 25, Gx_line+0, 236, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFCorNum), "ZZZZZZZZZ9")), 236, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV34TFCorNum_To_Description = StringUtil.Format( "%1 (%2)", "Numero", "Hasta", "", "", "", "", "", "", "");
            H500( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFCorNum_To_Description, "")), 25, Gx_line+0, 236, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFCorNum_To), "ZZZZZZZZZ9")), 236, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H500( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H500( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Tipo de Correlativo", 30, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Numero", 410, Gx_line+10, 787, Gx_line+27, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV57Configuracion_correlativoswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV58Configuracion_correlativoswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV59Configuracion_correlativoswwds_3_cortip1 = AV47CorTip1;
         AV60Configuracion_correlativoswwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV61Configuracion_correlativoswwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV62Configuracion_correlativoswwds_6_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV63Configuracion_correlativoswwds_7_cortip2 = AV50CorTip2;
         AV64Configuracion_correlativoswwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV65Configuracion_correlativoswwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV66Configuracion_correlativoswwds_10_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV67Configuracion_correlativoswwds_11_cortip3 = AV51CorTip3;
         AV68Configuracion_correlativoswwds_12_tfcortip = AV30TFCorTip;
         AV69Configuracion_correlativoswwds_13_tfcortip_sel = AV31TFCorTip_Sel;
         AV70Configuracion_correlativoswwds_14_tfcornum = AV32TFCorNum;
         AV71Configuracion_correlativoswwds_15_tfcornum_to = AV33TFCorNum_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV57Configuracion_correlativoswwds_1_dynamicfiltersselector1 ,
                                              AV58Configuracion_correlativoswwds_2_dynamicfiltersoperator1 ,
                                              AV59Configuracion_correlativoswwds_3_cortip1 ,
                                              AV60Configuracion_correlativoswwds_4_dynamicfiltersenabled2 ,
                                              AV61Configuracion_correlativoswwds_5_dynamicfiltersselector2 ,
                                              AV62Configuracion_correlativoswwds_6_dynamicfiltersoperator2 ,
                                              AV63Configuracion_correlativoswwds_7_cortip2 ,
                                              AV64Configuracion_correlativoswwds_8_dynamicfiltersenabled3 ,
                                              AV65Configuracion_correlativoswwds_9_dynamicfiltersselector3 ,
                                              AV66Configuracion_correlativoswwds_10_dynamicfiltersoperator3 ,
                                              AV67Configuracion_correlativoswwds_11_cortip3 ,
                                              AV69Configuracion_correlativoswwds_13_tfcortip_sel ,
                                              AV68Configuracion_correlativoswwds_12_tfcortip ,
                                              AV70Configuracion_correlativoswwds_14_tfcornum ,
                                              AV71Configuracion_correlativoswwds_15_tfcornum_to ,
                                              A138CorTip ,
                                              A758CorNum ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Configuracion_correlativoswwds_3_cortip1 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_correlativoswwds_3_cortip1), 10, "%");
         lV59Configuracion_correlativoswwds_3_cortip1 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_correlativoswwds_3_cortip1), 10, "%");
         lV63Configuracion_correlativoswwds_7_cortip2 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_correlativoswwds_7_cortip2), 10, "%");
         lV63Configuracion_correlativoswwds_7_cortip2 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_correlativoswwds_7_cortip2), 10, "%");
         lV67Configuracion_correlativoswwds_11_cortip3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_correlativoswwds_11_cortip3), 10, "%");
         lV67Configuracion_correlativoswwds_11_cortip3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_correlativoswwds_11_cortip3), 10, "%");
         lV68Configuracion_correlativoswwds_12_tfcortip = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_correlativoswwds_12_tfcortip), 10, "%");
         /* Using cursor P00502 */
         pr_default.execute(0, new Object[] {lV59Configuracion_correlativoswwds_3_cortip1, lV59Configuracion_correlativoswwds_3_cortip1, lV63Configuracion_correlativoswwds_7_cortip2, lV63Configuracion_correlativoswwds_7_cortip2, lV67Configuracion_correlativoswwds_11_cortip3, lV67Configuracion_correlativoswwds_11_cortip3, lV68Configuracion_correlativoswwds_12_tfcortip, AV69Configuracion_correlativoswwds_13_tfcortip_sel, AV70Configuracion_correlativoswwds_14_tfcornum, AV71Configuracion_correlativoswwds_15_tfcornum_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A758CorNum = P00502_A758CorNum[0];
            A138CorTip = P00502_A138CorTip[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H500( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A138CorTip, "")), 30, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A758CorNum), "ZZZZZZZZZ9")), 410, Gx_line+10, 787, Gx_line+25, 2, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Configuracion.CorrelativosWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.CorrelativosWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Configuracion.CorrelativosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV72GXV1 = 1;
         while ( AV72GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV72GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCORTIP") == 0 )
            {
               AV30TFCorTip = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCORTIP_SEL") == 0 )
            {
               AV31TFCorTip_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCORNUM") == 0 )
            {
               AV32TFCorNum = (long)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV33TFCorNum_To = (long)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV72GXV1 = (int)(AV72GXV1+1);
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

      protected void H500( bool bFoot ,
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
                  AV43PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV40DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV38AppName = "DVelop Software Solutions";
               AV44Phone = "+1 550 8923";
               AV42Mail = "info@mail.com";
               AV46Website = "http://www.web.com";
               AV35AddressLine1 = "French Boulevard 2859";
               AV36AddressLine2 = "Downtown";
               AV37AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV45Title = "";
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV25GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV47CorTip1 = "";
         AV48FilterCorTipDescription = "";
         AV49CorTip = "";
         AV18DynamicFiltersSelector2 = "";
         AV50CorTip2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV51CorTip3 = "";
         AV31TFCorTip_Sel = "";
         AV30TFCorTip = "";
         AV34TFCorNum_To_Description = "";
         AV57Configuracion_correlativoswwds_1_dynamicfiltersselector1 = "";
         AV59Configuracion_correlativoswwds_3_cortip1 = "";
         AV61Configuracion_correlativoswwds_5_dynamicfiltersselector2 = "";
         AV63Configuracion_correlativoswwds_7_cortip2 = "";
         AV65Configuracion_correlativoswwds_9_dynamicfiltersselector3 = "";
         AV67Configuracion_correlativoswwds_11_cortip3 = "";
         AV68Configuracion_correlativoswwds_12_tfcortip = "";
         AV69Configuracion_correlativoswwds_13_tfcortip_sel = "";
         scmdbuf = "";
         lV59Configuracion_correlativoswwds_3_cortip1 = "";
         lV63Configuracion_correlativoswwds_7_cortip2 = "";
         lV67Configuracion_correlativoswwds_11_cortip3 = "";
         lV68Configuracion_correlativoswwds_12_tfcortip = "";
         A138CorTip = "";
         P00502_A758CorNum = new long[1] ;
         P00502_A138CorTip = new string[] {""} ;
         AV26Session = context.GetSession();
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43PageInfo = "";
         AV40DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV38AppName = "";
         AV44Phone = "";
         AV42Mail = "";
         AV46Website = "";
         AV35AddressLine1 = "";
         AV36AddressLine2 = "";
         AV37AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.correlativoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00502_A758CorNum, P00502_A138CorTip
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
      private short AV13DynamicFiltersOperator1 ;
      private short AV19DynamicFiltersOperator2 ;
      private short AV23DynamicFiltersOperator3 ;
      private short AV58Configuracion_correlativoswwds_2_dynamicfiltersoperator1 ;
      private short AV62Configuracion_correlativoswwds_6_dynamicfiltersoperator2 ;
      private short AV66Configuracion_correlativoswwds_10_dynamicfiltersoperator3 ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV72GXV1 ;
      private long AV32TFCorNum ;
      private long AV33TFCorNum_To ;
      private long AV70Configuracion_correlativoswwds_14_tfcornum ;
      private long AV71Configuracion_correlativoswwds_15_tfcornum_to ;
      private long A758CorNum ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV47CorTip1 ;
      private string AV49CorTip ;
      private string AV50CorTip2 ;
      private string AV51CorTip3 ;
      private string AV31TFCorTip_Sel ;
      private string AV30TFCorTip ;
      private string AV59Configuracion_correlativoswwds_3_cortip1 ;
      private string AV63Configuracion_correlativoswwds_7_cortip2 ;
      private string AV67Configuracion_correlativoswwds_11_cortip3 ;
      private string AV68Configuracion_correlativoswwds_12_tfcortip ;
      private string AV69Configuracion_correlativoswwds_13_tfcortip_sel ;
      private string scmdbuf ;
      private string lV59Configuracion_correlativoswwds_3_cortip1 ;
      private string lV63Configuracion_correlativoswwds_7_cortip2 ;
      private string lV67Configuracion_correlativoswwds_11_cortip3 ;
      private string lV68Configuracion_correlativoswwds_12_tfcortip ;
      private string A138CorTip ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV60Configuracion_correlativoswwds_4_dynamicfiltersenabled2 ;
      private bool AV64Configuracion_correlativoswwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV45Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV48FilterCorTipDescription ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV34TFCorNum_To_Description ;
      private string AV57Configuracion_correlativoswwds_1_dynamicfiltersselector1 ;
      private string AV61Configuracion_correlativoswwds_5_dynamicfiltersselector2 ;
      private string AV65Configuracion_correlativoswwds_9_dynamicfiltersselector3 ;
      private string AV43PageInfo ;
      private string AV40DateInfo ;
      private string AV38AppName ;
      private string AV44Phone ;
      private string AV42Mail ;
      private string AV46Website ;
      private string AV35AddressLine1 ;
      private string AV36AddressLine2 ;
      private string AV37AddressLine3 ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00502_A758CorNum ;
      private string[] P00502_A138CorTip ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class correlativoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00502( IGxContext context ,
                                             string AV57Configuracion_correlativoswwds_1_dynamicfiltersselector1 ,
                                             short AV58Configuracion_correlativoswwds_2_dynamicfiltersoperator1 ,
                                             string AV59Configuracion_correlativoswwds_3_cortip1 ,
                                             bool AV60Configuracion_correlativoswwds_4_dynamicfiltersenabled2 ,
                                             string AV61Configuracion_correlativoswwds_5_dynamicfiltersselector2 ,
                                             short AV62Configuracion_correlativoswwds_6_dynamicfiltersoperator2 ,
                                             string AV63Configuracion_correlativoswwds_7_cortip2 ,
                                             bool AV64Configuracion_correlativoswwds_8_dynamicfiltersenabled3 ,
                                             string AV65Configuracion_correlativoswwds_9_dynamicfiltersselector3 ,
                                             short AV66Configuracion_correlativoswwds_10_dynamicfiltersoperator3 ,
                                             string AV67Configuracion_correlativoswwds_11_cortip3 ,
                                             string AV69Configuracion_correlativoswwds_13_tfcortip_sel ,
                                             string AV68Configuracion_correlativoswwds_12_tfcortip ,
                                             long AV70Configuracion_correlativoswwds_14_tfcornum ,
                                             long AV71Configuracion_correlativoswwds_15_tfcornum_to ,
                                             string A138CorTip ,
                                             long A758CorNum ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [CorNum], [CorTip] FROM [CCORRELATIVOS]";
         if ( ( StringUtil.StrCmp(AV57Configuracion_correlativoswwds_1_dynamicfiltersselector1, "CORTIP") == 0 ) && ( AV58Configuracion_correlativoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_correlativoswwds_3_cortip1)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like @lV59Configuracion_correlativoswwds_3_cortip1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Configuracion_correlativoswwds_1_dynamicfiltersselector1, "CORTIP") == 0 ) && ( AV58Configuracion_correlativoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_correlativoswwds_3_cortip1)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like '%' + @lV59Configuracion_correlativoswwds_3_cortip1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV60Configuracion_correlativoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_correlativoswwds_5_dynamicfiltersselector2, "CORTIP") == 0 ) && ( AV62Configuracion_correlativoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_correlativoswwds_7_cortip2)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like @lV63Configuracion_correlativoswwds_7_cortip2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV60Configuracion_correlativoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_correlativoswwds_5_dynamicfiltersselector2, "CORTIP") == 0 ) && ( AV62Configuracion_correlativoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_correlativoswwds_7_cortip2)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like '%' + @lV63Configuracion_correlativoswwds_7_cortip2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV64Configuracion_correlativoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Configuracion_correlativoswwds_9_dynamicfiltersselector3, "CORTIP") == 0 ) && ( AV66Configuracion_correlativoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_correlativoswwds_11_cortip3)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like @lV67Configuracion_correlativoswwds_11_cortip3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV64Configuracion_correlativoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Configuracion_correlativoswwds_9_dynamicfiltersselector3, "CORTIP") == 0 ) && ( AV66Configuracion_correlativoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_correlativoswwds_11_cortip3)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like '%' + @lV67Configuracion_correlativoswwds_11_cortip3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_correlativoswwds_13_tfcortip_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_correlativoswwds_12_tfcortip)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like @lV68Configuracion_correlativoswwds_12_tfcortip)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_correlativoswwds_13_tfcortip_sel)) )
         {
            AddWhere(sWhereString, "([CorTip] = @AV69Configuracion_correlativoswwds_13_tfcortip_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV70Configuracion_correlativoswwds_14_tfcornum) )
         {
            AddWhere(sWhereString, "([CorNum] >= @AV70Configuracion_correlativoswwds_14_tfcornum)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV71Configuracion_correlativoswwds_15_tfcornum_to) )
         {
            AddWhere(sWhereString, "([CorNum] <= @AV71Configuracion_correlativoswwds_15_tfcornum_to)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CorTip]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CorTip] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CorNum]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CorNum] DESC";
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
                     return conditional_P00502(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (short)dynConstraints[17] , (bool)dynConstraints[18] );
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
          Object[] prmP00502;
          prmP00502 = new Object[] {
          new ParDef("@lV59Configuracion_correlativoswwds_3_cortip1",GXType.NChar,10,0) ,
          new ParDef("@lV59Configuracion_correlativoswwds_3_cortip1",GXType.NChar,10,0) ,
          new ParDef("@lV63Configuracion_correlativoswwds_7_cortip2",GXType.NChar,10,0) ,
          new ParDef("@lV63Configuracion_correlativoswwds_7_cortip2",GXType.NChar,10,0) ,
          new ParDef("@lV67Configuracion_correlativoswwds_11_cortip3",GXType.NChar,10,0) ,
          new ParDef("@lV67Configuracion_correlativoswwds_11_cortip3",GXType.NChar,10,0) ,
          new ParDef("@lV68Configuracion_correlativoswwds_12_tfcortip",GXType.NChar,10,0) ,
          new ParDef("@AV69Configuracion_correlativoswwds_13_tfcortip_sel",GXType.NChar,10,0) ,
          new ParDef("@AV70Configuracion_correlativoswwds_14_tfcornum",GXType.Decimal,10,0) ,
          new ParDef("@AV71Configuracion_correlativoswwds_15_tfcornum_to",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00502", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00502,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                return;
       }
    }

 }

}
