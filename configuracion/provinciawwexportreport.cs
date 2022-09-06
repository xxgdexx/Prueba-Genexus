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
   public class provinciawwexportreport : GXWebProcedure
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

      public provinciawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public provinciawwexportreport( IGxContext context )
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
         provinciawwexportreport objprovinciawwexportreport;
         objprovinciawwexportreport = new provinciawwexportreport();
         objprovinciawwexportreport.context.SetSubmitInitialConfig(context);
         objprovinciawwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprovinciawwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((provinciawwexportreport)stateInfo).executePrivate();
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
            AV57Title = "Lista de Provincia";
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
            H3U0( true, 0) ;
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
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "PROVDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15ProvDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ProvDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterProvDscDescription = StringUtil.Format( "%1 (%2)", "Provincia", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterProvDscDescription = StringUtil.Format( "%1 (%2)", "Provincia", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17ProvDsc = AV15ProvDsc1;
                  H3U0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterProvDscDescription, "")), 25, Gx_line+0, 189, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ProvDsc, "")), 189, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "PROVDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21ProvDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ProvDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterProvDscDescription = StringUtil.Format( "%1 (%2)", "Provincia", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterProvDscDescription = StringUtil.Format( "%1 (%2)", "Provincia", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17ProvDsc = AV21ProvDsc2;
                     H3U0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterProvDscDescription, "")), 25, Gx_line+0, 189, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ProvDsc, "")), 189, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "PROVDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25ProvDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ProvDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterProvDscDescription = StringUtil.Format( "%1 (%2)", "Provincia", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterProvDscDescription = StringUtil.Format( "%1 (%2)", "Provincia", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17ProvDsc = AV25ProvDsc3;
                        H3U0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterProvDscDescription, "")), 25, Gx_line+0, 189, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ProvDsc, "")), 189, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFProvCod_Sel)) )
         {
            H3U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 189, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFProvCod_Sel, "")), 189, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFProvCod)) )
            {
               H3U0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 189, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFProvCod, "")), 189, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFProvDsc_Sel)) )
         {
            H3U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Provincia", 25, Gx_line+0, 189, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFProvDsc_Sel, "")), 189, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFProvDsc)) )
            {
               H3U0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Provincia", 25, Gx_line+0, 189, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFProvDsc, "")), 189, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPaiDsc_Sel)) )
         {
            H3U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Pais", 25, Gx_line+0, 189, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFPaiDsc_Sel, "")), 189, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFPaiDsc)) )
            {
               H3U0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Pais", 25, Gx_line+0, 189, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFPaiDsc, "")), 189, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV43TFProvSts_Sels.FromJSonString(AV41TFProvSts_SelsJson, null);
         if ( ! ( AV43TFProvSts_Sels.Count == 0 ) )
         {
            AV46i = 1;
            AV63GXV1 = 1;
            while ( AV63GXV1 <= AV43TFProvSts_Sels.Count )
            {
               AV44TFProvSts_Sel = (short)(AV43TFProvSts_Sels.GetNumeric(AV63GXV1));
               if ( AV46i == 1 )
               {
                  AV42TFProvSts_SelDscs = "";
               }
               else
               {
                  AV42TFProvSts_SelDscs += ", ";
               }
               if ( AV44TFProvSts_Sel == 1 )
               {
                  AV45FilterTFProvSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV44TFProvSts_Sel == 0 )
               {
                  AV45FilterTFProvSts_SelValueDescription = "INACTIVO";
               }
               AV42TFProvSts_SelDscs += AV45FilterTFProvSts_SelValueDescription;
               AV46i = (long)(AV46i+1);
               AV63GXV1 = (int)(AV63GXV1+1);
            }
            H3U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 189, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFProvSts_SelDscs, "")), 189, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H3U0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H3U0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 136, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Provincia", 140, Gx_line+10, 352, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Pais", 356, Gx_line+10, 569, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 573, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV65Configuracion_provinciawwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV66Configuracion_provinciawwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV67Configuracion_provinciawwds_3_provdsc1 = AV15ProvDsc1;
         AV68Configuracion_provinciawwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV69Configuracion_provinciawwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV70Configuracion_provinciawwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV71Configuracion_provinciawwds_7_provdsc2 = AV21ProvDsc2;
         AV72Configuracion_provinciawwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV73Configuracion_provinciawwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV74Configuracion_provinciawwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV75Configuracion_provinciawwds_11_provdsc3 = AV25ProvDsc3;
         AV76Configuracion_provinciawwds_12_tfprovcod = AV33TFProvCod;
         AV77Configuracion_provinciawwds_13_tfprovcod_sel = AV34TFProvCod_Sel;
         AV78Configuracion_provinciawwds_14_tfprovdsc = AV35TFProvDsc;
         AV79Configuracion_provinciawwds_15_tfprovdsc_sel = AV36TFProvDsc_Sel;
         AV80Configuracion_provinciawwds_16_tfpaidsc = AV37TFPaiDsc;
         AV81Configuracion_provinciawwds_17_tfpaidsc_sel = AV38TFPaiDsc_Sel;
         AV82Configuracion_provinciawwds_18_tfprovsts_sels = AV43TFProvSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1742ProvSts ,
                                              AV82Configuracion_provinciawwds_18_tfprovsts_sels ,
                                              AV65Configuracion_provinciawwds_1_dynamicfiltersselector1 ,
                                              AV66Configuracion_provinciawwds_2_dynamicfiltersoperator1 ,
                                              AV67Configuracion_provinciawwds_3_provdsc1 ,
                                              AV68Configuracion_provinciawwds_4_dynamicfiltersenabled2 ,
                                              AV69Configuracion_provinciawwds_5_dynamicfiltersselector2 ,
                                              AV70Configuracion_provinciawwds_6_dynamicfiltersoperator2 ,
                                              AV71Configuracion_provinciawwds_7_provdsc2 ,
                                              AV72Configuracion_provinciawwds_8_dynamicfiltersenabled3 ,
                                              AV73Configuracion_provinciawwds_9_dynamicfiltersselector3 ,
                                              AV74Configuracion_provinciawwds_10_dynamicfiltersoperator3 ,
                                              AV75Configuracion_provinciawwds_11_provdsc3 ,
                                              AV77Configuracion_provinciawwds_13_tfprovcod_sel ,
                                              AV76Configuracion_provinciawwds_12_tfprovcod ,
                                              AV79Configuracion_provinciawwds_15_tfprovdsc_sel ,
                                              AV78Configuracion_provinciawwds_14_tfprovdsc ,
                                              AV81Configuracion_provinciawwds_17_tfpaidsc_sel ,
                                              AV80Configuracion_provinciawwds_16_tfpaidsc ,
                                              AV82Configuracion_provinciawwds_18_tfprovsts_sels.Count ,
                                              A603ProvDsc ,
                                              A141ProvCod ,
                                              A1500PaiDsc ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV67Configuracion_provinciawwds_3_provdsc1 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_provinciawwds_3_provdsc1), 100, "%");
         lV67Configuracion_provinciawwds_3_provdsc1 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_provinciawwds_3_provdsc1), 100, "%");
         lV71Configuracion_provinciawwds_7_provdsc2 = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_provinciawwds_7_provdsc2), 100, "%");
         lV71Configuracion_provinciawwds_7_provdsc2 = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_provinciawwds_7_provdsc2), 100, "%");
         lV75Configuracion_provinciawwds_11_provdsc3 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_provinciawwds_11_provdsc3), 100, "%");
         lV75Configuracion_provinciawwds_11_provdsc3 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_provinciawwds_11_provdsc3), 100, "%");
         lV76Configuracion_provinciawwds_12_tfprovcod = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_provinciawwds_12_tfprovcod), 4, "%");
         lV78Configuracion_provinciawwds_14_tfprovdsc = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_provinciawwds_14_tfprovdsc), 100, "%");
         lV80Configuracion_provinciawwds_16_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_provinciawwds_16_tfpaidsc), 100, "%");
         /* Using cursor P003U2 */
         pr_default.execute(0, new Object[] {lV67Configuracion_provinciawwds_3_provdsc1, lV67Configuracion_provinciawwds_3_provdsc1, lV71Configuracion_provinciawwds_7_provdsc2, lV71Configuracion_provinciawwds_7_provdsc2, lV75Configuracion_provinciawwds_11_provdsc3, lV75Configuracion_provinciawwds_11_provdsc3, lV76Configuracion_provinciawwds_12_tfprovcod, AV77Configuracion_provinciawwds_13_tfprovcod_sel, lV78Configuracion_provinciawwds_14_tfprovdsc, AV79Configuracion_provinciawwds_15_tfprovdsc_sel, lV80Configuracion_provinciawwds_16_tfpaidsc, AV81Configuracion_provinciawwds_17_tfpaidsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1742ProvSts = P003U2_A1742ProvSts[0];
            A1500PaiDsc = P003U2_A1500PaiDsc[0];
            A141ProvCod = P003U2_A141ProvCod[0];
            A603ProvDsc = P003U2_A603ProvDsc[0];
            A139PaiCod = P003U2_A139PaiCod[0];
            A140EstCod = P003U2_A140EstCod[0];
            A1500PaiDsc = P003U2_A1500PaiDsc[0];
            if ( A1742ProvSts == 1 )
            {
               AV12ProvStsDescription = "ACTIVO";
            }
            else if ( A1742ProvSts == 0 )
            {
               AV12ProvStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H3U0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A141ProvCod, "")), 30, Gx_line+10, 136, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A603ProvDsc, "")), 140, Gx_line+10, 352, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1500PaiDsc, "")), 356, Gx_line+10, 569, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12ProvStsDescription, "")), 573, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.ProvinciaWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.ProvinciaWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.ProvinciaWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV83GXV2 = 1;
         while ( AV83GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV83GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPROVCOD") == 0 )
            {
               AV33TFProvCod = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPROVCOD_SEL") == 0 )
            {
               AV34TFProvCod_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPROVDSC") == 0 )
            {
               AV35TFProvDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPROVDSC_SEL") == 0 )
            {
               AV36TFProvDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPAIDSC") == 0 )
            {
               AV37TFPaiDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPAIDSC_SEL") == 0 )
            {
               AV38TFPaiDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPROVSTS_SEL") == 0 )
            {
               AV41TFProvSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV43TFProvSts_Sels.FromJSonString(AV41TFProvSts_SelsJson, null);
            }
            AV83GXV2 = (int)(AV83GXV2+1);
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

      protected void H3U0( bool bFoot ,
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
                  AV55PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV52DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV50AppName = "DVelop Software Solutions";
               AV56Phone = "+1 550 8923";
               AV54Mail = "info@mail.com";
               AV58Website = "http://www.web.com";
               AV47AddressLine1 = "French Boulevard 2859";
               AV48AddressLine2 = "Downtown";
               AV49AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV57Title = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15ProvDsc1 = "";
         AV16FilterProvDscDescription = "";
         AV17ProvDsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21ProvDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25ProvDsc3 = "";
         AV34TFProvCod_Sel = "";
         AV33TFProvCod = "";
         AV36TFProvDsc_Sel = "";
         AV35TFProvDsc = "";
         AV38TFPaiDsc_Sel = "";
         AV37TFPaiDsc = "";
         AV43TFProvSts_Sels = new GxSimpleCollection<short>();
         AV41TFProvSts_SelsJson = "";
         AV42TFProvSts_SelDscs = "";
         AV45FilterTFProvSts_SelValueDescription = "";
         AV65Configuracion_provinciawwds_1_dynamicfiltersselector1 = "";
         AV67Configuracion_provinciawwds_3_provdsc1 = "";
         AV69Configuracion_provinciawwds_5_dynamicfiltersselector2 = "";
         AV71Configuracion_provinciawwds_7_provdsc2 = "";
         AV73Configuracion_provinciawwds_9_dynamicfiltersselector3 = "";
         AV75Configuracion_provinciawwds_11_provdsc3 = "";
         AV76Configuracion_provinciawwds_12_tfprovcod = "";
         AV77Configuracion_provinciawwds_13_tfprovcod_sel = "";
         AV78Configuracion_provinciawwds_14_tfprovdsc = "";
         AV79Configuracion_provinciawwds_15_tfprovdsc_sel = "";
         AV80Configuracion_provinciawwds_16_tfpaidsc = "";
         AV81Configuracion_provinciawwds_17_tfpaidsc_sel = "";
         AV82Configuracion_provinciawwds_18_tfprovsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV67Configuracion_provinciawwds_3_provdsc1 = "";
         lV71Configuracion_provinciawwds_7_provdsc2 = "";
         lV75Configuracion_provinciawwds_11_provdsc3 = "";
         lV76Configuracion_provinciawwds_12_tfprovcod = "";
         lV78Configuracion_provinciawwds_14_tfprovdsc = "";
         lV80Configuracion_provinciawwds_16_tfpaidsc = "";
         A603ProvDsc = "";
         A141ProvCod = "";
         A1500PaiDsc = "";
         P003U2_A1742ProvSts = new short[1] ;
         P003U2_A1500PaiDsc = new string[] {""} ;
         P003U2_A141ProvCod = new string[] {""} ;
         P003U2_A603ProvDsc = new string[] {""} ;
         P003U2_A139PaiCod = new string[] {""} ;
         P003U2_A140EstCod = new string[] {""} ;
         A139PaiCod = "";
         A140EstCod = "";
         AV12ProvStsDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV55PageInfo = "";
         AV52DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV50AppName = "";
         AV56Phone = "";
         AV54Mail = "";
         AV58Website = "";
         AV47AddressLine1 = "";
         AV48AddressLine2 = "";
         AV49AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.provinciawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P003U2_A1742ProvSts, P003U2_A1500PaiDsc, P003U2_A141ProvCod, P003U2_A603ProvDsc, P003U2_A139PaiCod, P003U2_A140EstCod
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
      private short AV14DynamicFiltersOperator1 ;
      private short AV20DynamicFiltersOperator2 ;
      private short AV24DynamicFiltersOperator3 ;
      private short AV44TFProvSts_Sel ;
      private short AV66Configuracion_provinciawwds_2_dynamicfiltersoperator1 ;
      private short AV70Configuracion_provinciawwds_6_dynamicfiltersoperator2 ;
      private short AV74Configuracion_provinciawwds_10_dynamicfiltersoperator3 ;
      private short A1742ProvSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV63GXV1 ;
      private int AV82Configuracion_provinciawwds_18_tfprovsts_sels_Count ;
      private int AV83GXV2 ;
      private long AV46i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15ProvDsc1 ;
      private string AV17ProvDsc ;
      private string AV21ProvDsc2 ;
      private string AV25ProvDsc3 ;
      private string AV34TFProvCod_Sel ;
      private string AV33TFProvCod ;
      private string AV36TFProvDsc_Sel ;
      private string AV35TFProvDsc ;
      private string AV38TFPaiDsc_Sel ;
      private string AV37TFPaiDsc ;
      private string AV67Configuracion_provinciawwds_3_provdsc1 ;
      private string AV71Configuracion_provinciawwds_7_provdsc2 ;
      private string AV75Configuracion_provinciawwds_11_provdsc3 ;
      private string AV76Configuracion_provinciawwds_12_tfprovcod ;
      private string AV77Configuracion_provinciawwds_13_tfprovcod_sel ;
      private string AV78Configuracion_provinciawwds_14_tfprovdsc ;
      private string AV79Configuracion_provinciawwds_15_tfprovdsc_sel ;
      private string AV80Configuracion_provinciawwds_16_tfpaidsc ;
      private string AV81Configuracion_provinciawwds_17_tfpaidsc_sel ;
      private string scmdbuf ;
      private string lV67Configuracion_provinciawwds_3_provdsc1 ;
      private string lV71Configuracion_provinciawwds_7_provdsc2 ;
      private string lV75Configuracion_provinciawwds_11_provdsc3 ;
      private string lV76Configuracion_provinciawwds_12_tfprovcod ;
      private string lV78Configuracion_provinciawwds_14_tfprovdsc ;
      private string lV80Configuracion_provinciawwds_16_tfpaidsc ;
      private string A603ProvDsc ;
      private string A141ProvCod ;
      private string A1500PaiDsc ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV68Configuracion_provinciawwds_4_dynamicfiltersenabled2 ;
      private bool AV72Configuracion_provinciawwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV41TFProvSts_SelsJson ;
      private string AV57Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterProvDscDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV42TFProvSts_SelDscs ;
      private string AV45FilterTFProvSts_SelValueDescription ;
      private string AV65Configuracion_provinciawwds_1_dynamicfiltersselector1 ;
      private string AV69Configuracion_provinciawwds_5_dynamicfiltersselector2 ;
      private string AV73Configuracion_provinciawwds_9_dynamicfiltersselector3 ;
      private string AV12ProvStsDescription ;
      private string AV55PageInfo ;
      private string AV52DateInfo ;
      private string AV50AppName ;
      private string AV56Phone ;
      private string AV54Mail ;
      private string AV58Website ;
      private string AV47AddressLine1 ;
      private string AV48AddressLine2 ;
      private string AV49AddressLine3 ;
      private GxSimpleCollection<short> AV43TFProvSts_Sels ;
      private GxSimpleCollection<short> AV82Configuracion_provinciawwds_18_tfprovsts_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003U2_A1742ProvSts ;
      private string[] P003U2_A1500PaiDsc ;
      private string[] P003U2_A141ProvCod ;
      private string[] P003U2_A603ProvDsc ;
      private string[] P003U2_A139PaiCod ;
      private string[] P003U2_A140EstCod ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class provinciawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003U2( IGxContext context ,
                                             short A1742ProvSts ,
                                             GxSimpleCollection<short> AV82Configuracion_provinciawwds_18_tfprovsts_sels ,
                                             string AV65Configuracion_provinciawwds_1_dynamicfiltersselector1 ,
                                             short AV66Configuracion_provinciawwds_2_dynamicfiltersoperator1 ,
                                             string AV67Configuracion_provinciawwds_3_provdsc1 ,
                                             bool AV68Configuracion_provinciawwds_4_dynamicfiltersenabled2 ,
                                             string AV69Configuracion_provinciawwds_5_dynamicfiltersselector2 ,
                                             short AV70Configuracion_provinciawwds_6_dynamicfiltersoperator2 ,
                                             string AV71Configuracion_provinciawwds_7_provdsc2 ,
                                             bool AV72Configuracion_provinciawwds_8_dynamicfiltersenabled3 ,
                                             string AV73Configuracion_provinciawwds_9_dynamicfiltersselector3 ,
                                             short AV74Configuracion_provinciawwds_10_dynamicfiltersoperator3 ,
                                             string AV75Configuracion_provinciawwds_11_provdsc3 ,
                                             string AV77Configuracion_provinciawwds_13_tfprovcod_sel ,
                                             string AV76Configuracion_provinciawwds_12_tfprovcod ,
                                             string AV79Configuracion_provinciawwds_15_tfprovdsc_sel ,
                                             string AV78Configuracion_provinciawwds_14_tfprovdsc ,
                                             string AV81Configuracion_provinciawwds_17_tfpaidsc_sel ,
                                             string AV80Configuracion_provinciawwds_16_tfpaidsc ,
                                             int AV82Configuracion_provinciawwds_18_tfprovsts_sels_Count ,
                                             string A603ProvDsc ,
                                             string A141ProvCod ,
                                             string A1500PaiDsc ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ProvSts], T2.[PaiDsc], T1.[ProvCod], T1.[ProvDsc], T1.[PaiCod], T1.[EstCod] FROM ([CPROVINCIA] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV65Configuracion_provinciawwds_1_dynamicfiltersselector1, "PROVDSC") == 0 ) && ( AV66Configuracion_provinciawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_provinciawwds_3_provdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV67Configuracion_provinciawwds_3_provdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Configuracion_provinciawwds_1_dynamicfiltersselector1, "PROVDSC") == 0 ) && ( AV66Configuracion_provinciawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_provinciawwds_3_provdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV67Configuracion_provinciawwds_3_provdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV68Configuracion_provinciawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Configuracion_provinciawwds_5_dynamicfiltersselector2, "PROVDSC") == 0 ) && ( AV70Configuracion_provinciawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_provinciawwds_7_provdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV71Configuracion_provinciawwds_7_provdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV68Configuracion_provinciawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Configuracion_provinciawwds_5_dynamicfiltersselector2, "PROVDSC") == 0 ) && ( AV70Configuracion_provinciawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_provinciawwds_7_provdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV71Configuracion_provinciawwds_7_provdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV72Configuracion_provinciawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Configuracion_provinciawwds_9_dynamicfiltersselector3, "PROVDSC") == 0 ) && ( AV74Configuracion_provinciawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_provinciawwds_11_provdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV75Configuracion_provinciawwds_11_provdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV72Configuracion_provinciawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Configuracion_provinciawwds_9_dynamicfiltersselector3, "PROVDSC") == 0 ) && ( AV74Configuracion_provinciawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_provinciawwds_11_provdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV75Configuracion_provinciawwds_11_provdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_provinciawwds_13_tfprovcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_provinciawwds_12_tfprovcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvCod] like @lV76Configuracion_provinciawwds_12_tfprovcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_provinciawwds_13_tfprovcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProvCod] = @AV77Configuracion_provinciawwds_13_tfprovcod_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_provinciawwds_15_tfprovdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_provinciawwds_14_tfprovdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV78Configuracion_provinciawwds_14_tfprovdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_provinciawwds_15_tfprovdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] = @AV79Configuracion_provinciawwds_15_tfprovdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_provinciawwds_17_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_provinciawwds_16_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV80Configuracion_provinciawwds_16_tfpaidsc)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_provinciawwds_17_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV81Configuracion_provinciawwds_17_tfpaidsc_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV82Configuracion_provinciawwds_18_tfprovsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Configuracion_provinciawwds_18_tfprovsts_sels, "T1.[ProvSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[PaiCod], T1.[ProvCod]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProvCod]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProvCod] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProvDsc]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProvDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[PaiDsc]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[PaiDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProvSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProvSts] DESC";
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
                     return conditional_P003U2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP003U2;
          prmP003U2 = new Object[] {
          new ParDef("@lV67Configuracion_provinciawwds_3_provdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_provinciawwds_3_provdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV71Configuracion_provinciawwds_7_provdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV71Configuracion_provinciawwds_7_provdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_provinciawwds_11_provdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_provinciawwds_11_provdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_provinciawwds_12_tfprovcod",GXType.NChar,4,0) ,
          new ParDef("@AV77Configuracion_provinciawwds_13_tfprovcod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV78Configuracion_provinciawwds_14_tfprovdsc",GXType.NChar,100,0) ,
          new ParDef("@AV79Configuracion_provinciawwds_15_tfprovdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_provinciawwds_16_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV81Configuracion_provinciawwds_17_tfpaidsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003U2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 4);
                ((string[]) buf[5])[0] = rslt.getString(6, 4);
                return;
       }
    }

 }

}
