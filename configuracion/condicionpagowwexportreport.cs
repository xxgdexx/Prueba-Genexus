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
   public class condicionpagowwexportreport : GXWebProcedure
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

      public condicionpagowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public condicionpagowwexportreport( IGxContext context )
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
         condicionpagowwexportreport objcondicionpagowwexportreport;
         objcondicionpagowwexportreport = new condicionpagowwexportreport();
         objcondicionpagowwexportreport.context.SetSubmitInitialConfig(context);
         objcondicionpagowwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcondicionpagowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((condicionpagowwexportreport)stateInfo).executePrivate();
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
            AV53Title = "Lista de Condiciones de Pago";
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
            H2K0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CONPDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV14ConpDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14ConpDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterConpDscDescription = StringUtil.Format( "%1 (%2)", "Condición de Pago", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterConpDscDescription = StringUtil.Format( "%1 (%2)", "Condición de Pago", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16ConpDsc = AV14ConpDsc1;
                  H2K0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterConpDscDescription, "")), 25, Gx_line+0, 237, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ConpDsc, "")), 237, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "CONPDSC") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV20ConpDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ConpDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterConpDscDescription = StringUtil.Format( "%1 (%2)", "Condición de Pago", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterConpDscDescription = StringUtil.Format( "%1 (%2)", "Condición de Pago", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16ConpDsc = AV20ConpDsc2;
                     H2K0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterConpDscDescription, "")), 25, Gx_line+0, 237, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ConpDsc, "")), 237, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "CONPDSC") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV24ConpDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ConpDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterConpDscDescription = StringUtil.Format( "%1 (%2)", "Condición de Pago", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterConpDscDescription = StringUtil.Format( "%1 (%2)", "Condición de Pago", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16ConpDsc = AV24ConpDsc3;
                        H2K0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterConpDscDescription, "")), 25, Gx_line+0, 237, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ConpDsc, "")), 237, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV30TFConpcod) && (0==AV31TFConpcod_To) ) )
         {
            H2K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 237, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30TFConpcod), "ZZZZZ9")), 237, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV40TFConpcod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H2K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFConpcod_To_Description, "")), 25, Gx_line+0, 237, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFConpcod_To), "ZZZZZ9")), 237, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFConpDsc_Sel)) )
         {
            H2K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Condición de Pago", 25, Gx_line+0, 237, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFConpDsc_Sel, "")), 237, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFConpDsc)) )
            {
               H2K0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Condición de Pago", 25, Gx_line+0, 237, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFConpDsc, "")), 237, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFConpAbr_Sel)) )
         {
            H2K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 237, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFConpAbr_Sel, "")), 237, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFConpAbr)) )
            {
               H2K0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 237, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFConpAbr, "")), 237, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV36TFConpDias) && (0==AV37TFConpDias_To) ) )
         {
            H2K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("N° Dias", 25, Gx_line+0, 237, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36TFConpDias), "ZZZ9")), 237, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV41TFConpDias_To_Description = StringUtil.Format( "%1 (%2)", "N° Dias", "Hasta", "", "", "", "", "", "", "");
            H2K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFConpDias_To_Description, "")), 25, Gx_line+0, 237, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37TFConpDias_To), "ZZZ9")), 237, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV58TFConpSts_Sels.FromJSonString(AV56TFConpSts_SelsJson, null);
         if ( ! ( AV58TFConpSts_Sels.Count == 0 ) )
         {
            AV61i = 1;
            AV66GXV1 = 1;
            while ( AV66GXV1 <= AV58TFConpSts_Sels.Count )
            {
               AV59TFConpSts_Sel = (short)(AV58TFConpSts_Sels.GetNumeric(AV66GXV1));
               if ( AV61i == 1 )
               {
                  AV57TFConpSts_SelDscs = "";
               }
               else
               {
                  AV57TFConpSts_SelDscs += ", ";
               }
               if ( AV59TFConpSts_Sel == 1 )
               {
                  AV60FilterTFConpSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV59TFConpSts_Sel == 0 )
               {
                  AV60FilterTFConpSts_SelValueDescription = "INACTIVO";
               }
               AV57TFConpSts_SelDscs += AV60FilterTFConpSts_SelValueDescription;
               AV61i = (long)(AV61i+1);
               AV66GXV1 = (int)(AV66GXV1+1);
            }
            H2K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 237, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57TFConpSts_SelDscs, "")), 237, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H2K0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H2K0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 135, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Condición de Pago", 139, Gx_line+10, 351, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Abreviatura", 355, Gx_line+10, 461, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("N° Dias", 465, Gx_line+10, 571, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 575, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV68Configuracion_condicionpagowwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV69Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV70Configuracion_condicionpagowwds_3_conpdsc1 = AV14ConpDsc1;
         AV71Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV72Configuracion_condicionpagowwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV73Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV74Configuracion_condicionpagowwds_7_conpdsc2 = AV20ConpDsc2;
         AV75Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV76Configuracion_condicionpagowwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV77Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV78Configuracion_condicionpagowwds_11_conpdsc3 = AV24ConpDsc3;
         AV79Configuracion_condicionpagowwds_12_tfconpcod = AV30TFConpcod;
         AV80Configuracion_condicionpagowwds_13_tfconpcod_to = AV31TFConpcod_To;
         AV81Configuracion_condicionpagowwds_14_tfconpdsc = AV32TFConpDsc;
         AV82Configuracion_condicionpagowwds_15_tfconpdsc_sel = AV33TFConpDsc_Sel;
         AV83Configuracion_condicionpagowwds_16_tfconpabr = AV34TFConpAbr;
         AV84Configuracion_condicionpagowwds_17_tfconpabr_sel = AV35TFConpAbr_Sel;
         AV85Configuracion_condicionpagowwds_18_tfconpdias = AV36TFConpDias;
         AV86Configuracion_condicionpagowwds_19_tfconpdias_to = AV37TFConpDias_To;
         AV87Configuracion_condicionpagowwds_20_tfconpsts_sels = AV58TFConpSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A754ConpSts ,
                                              AV87Configuracion_condicionpagowwds_20_tfconpsts_sels ,
                                              AV68Configuracion_condicionpagowwds_1_dynamicfiltersselector1 ,
                                              AV69Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 ,
                                              AV70Configuracion_condicionpagowwds_3_conpdsc1 ,
                                              AV71Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 ,
                                              AV72Configuracion_condicionpagowwds_5_dynamicfiltersselector2 ,
                                              AV73Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 ,
                                              AV74Configuracion_condicionpagowwds_7_conpdsc2 ,
                                              AV75Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 ,
                                              AV76Configuracion_condicionpagowwds_9_dynamicfiltersselector3 ,
                                              AV77Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 ,
                                              AV78Configuracion_condicionpagowwds_11_conpdsc3 ,
                                              AV79Configuracion_condicionpagowwds_12_tfconpcod ,
                                              AV80Configuracion_condicionpagowwds_13_tfconpcod_to ,
                                              AV82Configuracion_condicionpagowwds_15_tfconpdsc_sel ,
                                              AV81Configuracion_condicionpagowwds_14_tfconpdsc ,
                                              AV84Configuracion_condicionpagowwds_17_tfconpabr_sel ,
                                              AV83Configuracion_condicionpagowwds_16_tfconpabr ,
                                              AV85Configuracion_condicionpagowwds_18_tfconpdias ,
                                              AV86Configuracion_condicionpagowwds_19_tfconpdias_to ,
                                              AV87Configuracion_condicionpagowwds_20_tfconpsts_sels.Count ,
                                              A753ConpDsc ,
                                              A137Conpcod ,
                                              A751ConpAbr ,
                                              A752ConpDias ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV70Configuracion_condicionpagowwds_3_conpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_condicionpagowwds_3_conpdsc1), 100, "%");
         lV70Configuracion_condicionpagowwds_3_conpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_condicionpagowwds_3_conpdsc1), 100, "%");
         lV74Configuracion_condicionpagowwds_7_conpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_condicionpagowwds_7_conpdsc2), 100, "%");
         lV74Configuracion_condicionpagowwds_7_conpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_condicionpagowwds_7_conpdsc2), 100, "%");
         lV78Configuracion_condicionpagowwds_11_conpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_condicionpagowwds_11_conpdsc3), 100, "%");
         lV78Configuracion_condicionpagowwds_11_conpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_condicionpagowwds_11_conpdsc3), 100, "%");
         lV81Configuracion_condicionpagowwds_14_tfconpdsc = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_condicionpagowwds_14_tfconpdsc), 100, "%");
         lV83Configuracion_condicionpagowwds_16_tfconpabr = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_condicionpagowwds_16_tfconpabr), 5, "%");
         /* Using cursor P002K2 */
         pr_default.execute(0, new Object[] {lV70Configuracion_condicionpagowwds_3_conpdsc1, lV70Configuracion_condicionpagowwds_3_conpdsc1, lV74Configuracion_condicionpagowwds_7_conpdsc2, lV74Configuracion_condicionpagowwds_7_conpdsc2, lV78Configuracion_condicionpagowwds_11_conpdsc3, lV78Configuracion_condicionpagowwds_11_conpdsc3, AV79Configuracion_condicionpagowwds_12_tfconpcod, AV80Configuracion_condicionpagowwds_13_tfconpcod_to, lV81Configuracion_condicionpagowwds_14_tfconpdsc, AV82Configuracion_condicionpagowwds_15_tfconpdsc_sel, lV83Configuracion_condicionpagowwds_16_tfconpabr, AV84Configuracion_condicionpagowwds_17_tfconpabr_sel, AV85Configuracion_condicionpagowwds_18_tfconpdias, AV86Configuracion_condicionpagowwds_19_tfconpdias_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A754ConpSts = P002K2_A754ConpSts[0];
            A752ConpDias = P002K2_A752ConpDias[0];
            A751ConpAbr = P002K2_A751ConpAbr[0];
            A137Conpcod = P002K2_A137Conpcod[0];
            A753ConpDsc = P002K2_A753ConpDsc[0];
            if ( A754ConpSts == 1 )
            {
               AV55ConpStsDescription = "ACTIVO";
            }
            else if ( A754ConpSts == 0 )
            {
               AV55ConpStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H2K0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A137Conpcod), "ZZZZZ9")), 30, Gx_line+10, 135, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A753ConpDsc, "")), 139, Gx_line+10, 351, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A751ConpAbr, "")), 355, Gx_line+10, 461, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A752ConpDias), "ZZZ9")), 465, Gx_line+10, 571, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55ConpStsDescription, "")), 575, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Configuracion.CondicionPagoWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.CondicionPagoWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Configuracion.CondicionPagoWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV88GXV2 = 1;
         while ( AV88GXV2 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV88GXV2));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCONPCOD") == 0 )
            {
               AV30TFConpcod = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV31TFConpcod_To = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCONPDSC") == 0 )
            {
               AV32TFConpDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCONPDSC_SEL") == 0 )
            {
               AV33TFConpDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCONPABR") == 0 )
            {
               AV34TFConpAbr = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCONPABR_SEL") == 0 )
            {
               AV35TFConpAbr_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCONPDIAS") == 0 )
            {
               AV36TFConpDias = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV37TFConpDias_To = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCONPSTS_SEL") == 0 )
            {
               AV56TFConpSts_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV58TFConpSts_Sels.FromJSonString(AV56TFConpSts_SelsJson, null);
            }
            AV88GXV2 = (int)(AV88GXV2+1);
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

      protected void H2K0( bool bFoot ,
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
                  AV51PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV48DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV46AppName = "DVelop Software Solutions";
               AV52Phone = "+1 550 8923";
               AV50Mail = "info@mail.com";
               AV54Website = "http://www.web.com";
               AV43AddressLine1 = "French Boulevard 2859";
               AV44AddressLine2 = "Downtown";
               AV45AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV53Title = "";
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV25GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14ConpDsc1 = "";
         AV15FilterConpDscDescription = "";
         AV16ConpDsc = "";
         AV18DynamicFiltersSelector2 = "";
         AV20ConpDsc2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV24ConpDsc3 = "";
         AV40TFConpcod_To_Description = "";
         AV33TFConpDsc_Sel = "";
         AV32TFConpDsc = "";
         AV35TFConpAbr_Sel = "";
         AV34TFConpAbr = "";
         AV41TFConpDias_To_Description = "";
         AV58TFConpSts_Sels = new GxSimpleCollection<short>();
         AV56TFConpSts_SelsJson = "";
         AV57TFConpSts_SelDscs = "";
         AV60FilterTFConpSts_SelValueDescription = "";
         AV68Configuracion_condicionpagowwds_1_dynamicfiltersselector1 = "";
         AV70Configuracion_condicionpagowwds_3_conpdsc1 = "";
         AV72Configuracion_condicionpagowwds_5_dynamicfiltersselector2 = "";
         AV74Configuracion_condicionpagowwds_7_conpdsc2 = "";
         AV76Configuracion_condicionpagowwds_9_dynamicfiltersselector3 = "";
         AV78Configuracion_condicionpagowwds_11_conpdsc3 = "";
         AV81Configuracion_condicionpagowwds_14_tfconpdsc = "";
         AV82Configuracion_condicionpagowwds_15_tfconpdsc_sel = "";
         AV83Configuracion_condicionpagowwds_16_tfconpabr = "";
         AV84Configuracion_condicionpagowwds_17_tfconpabr_sel = "";
         AV87Configuracion_condicionpagowwds_20_tfconpsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV70Configuracion_condicionpagowwds_3_conpdsc1 = "";
         lV74Configuracion_condicionpagowwds_7_conpdsc2 = "";
         lV78Configuracion_condicionpagowwds_11_conpdsc3 = "";
         lV81Configuracion_condicionpagowwds_14_tfconpdsc = "";
         lV83Configuracion_condicionpagowwds_16_tfconpabr = "";
         A753ConpDsc = "";
         A751ConpAbr = "";
         P002K2_A754ConpSts = new short[1] ;
         P002K2_A752ConpDias = new short[1] ;
         P002K2_A751ConpAbr = new string[] {""} ;
         P002K2_A137Conpcod = new int[1] ;
         P002K2_A753ConpDsc = new string[] {""} ;
         AV55ConpStsDescription = "";
         AV26Session = context.GetSession();
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51PageInfo = "";
         AV48DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV46AppName = "";
         AV52Phone = "";
         AV50Mail = "";
         AV54Website = "";
         AV43AddressLine1 = "";
         AV44AddressLine2 = "";
         AV45AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.condicionpagowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P002K2_A754ConpSts, P002K2_A752ConpDias, P002K2_A751ConpAbr, P002K2_A137Conpcod, P002K2_A753ConpDsc
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
      private short AV36TFConpDias ;
      private short AV37TFConpDias_To ;
      private short AV59TFConpSts_Sel ;
      private short AV69Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 ;
      private short AV73Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 ;
      private short AV77Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 ;
      private short AV85Configuracion_condicionpagowwds_18_tfconpdias ;
      private short AV86Configuracion_condicionpagowwds_19_tfconpdias_to ;
      private short A754ConpSts ;
      private short A752ConpDias ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV30TFConpcod ;
      private int AV31TFConpcod_To ;
      private int AV66GXV1 ;
      private int AV79Configuracion_condicionpagowwds_12_tfconpcod ;
      private int AV80Configuracion_condicionpagowwds_13_tfconpcod_to ;
      private int AV87Configuracion_condicionpagowwds_20_tfconpsts_sels_Count ;
      private int A137Conpcod ;
      private int AV88GXV2 ;
      private long AV61i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14ConpDsc1 ;
      private string AV16ConpDsc ;
      private string AV20ConpDsc2 ;
      private string AV24ConpDsc3 ;
      private string AV33TFConpDsc_Sel ;
      private string AV32TFConpDsc ;
      private string AV35TFConpAbr_Sel ;
      private string AV34TFConpAbr ;
      private string AV70Configuracion_condicionpagowwds_3_conpdsc1 ;
      private string AV74Configuracion_condicionpagowwds_7_conpdsc2 ;
      private string AV78Configuracion_condicionpagowwds_11_conpdsc3 ;
      private string AV81Configuracion_condicionpagowwds_14_tfconpdsc ;
      private string AV82Configuracion_condicionpagowwds_15_tfconpdsc_sel ;
      private string AV83Configuracion_condicionpagowwds_16_tfconpabr ;
      private string AV84Configuracion_condicionpagowwds_17_tfconpabr_sel ;
      private string scmdbuf ;
      private string lV70Configuracion_condicionpagowwds_3_conpdsc1 ;
      private string lV74Configuracion_condicionpagowwds_7_conpdsc2 ;
      private string lV78Configuracion_condicionpagowwds_11_conpdsc3 ;
      private string lV81Configuracion_condicionpagowwds_14_tfconpdsc ;
      private string lV83Configuracion_condicionpagowwds_16_tfconpabr ;
      private string A753ConpDsc ;
      private string A751ConpAbr ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV71Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 ;
      private bool AV75Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV56TFConpSts_SelsJson ;
      private string AV53Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterConpDscDescription ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV40TFConpcod_To_Description ;
      private string AV41TFConpDias_To_Description ;
      private string AV57TFConpSts_SelDscs ;
      private string AV60FilterTFConpSts_SelValueDescription ;
      private string AV68Configuracion_condicionpagowwds_1_dynamicfiltersselector1 ;
      private string AV72Configuracion_condicionpagowwds_5_dynamicfiltersselector2 ;
      private string AV76Configuracion_condicionpagowwds_9_dynamicfiltersselector3 ;
      private string AV55ConpStsDescription ;
      private string AV51PageInfo ;
      private string AV48DateInfo ;
      private string AV46AppName ;
      private string AV52Phone ;
      private string AV50Mail ;
      private string AV54Website ;
      private string AV43AddressLine1 ;
      private string AV44AddressLine2 ;
      private string AV45AddressLine3 ;
      private GxSimpleCollection<short> AV58TFConpSts_Sels ;
      private GxSimpleCollection<short> AV87Configuracion_condicionpagowwds_20_tfconpsts_sels ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002K2_A754ConpSts ;
      private short[] P002K2_A752ConpDias ;
      private string[] P002K2_A751ConpAbr ;
      private int[] P002K2_A137Conpcod ;
      private string[] P002K2_A753ConpDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class condicionpagowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002K2( IGxContext context ,
                                             short A754ConpSts ,
                                             GxSimpleCollection<short> AV87Configuracion_condicionpagowwds_20_tfconpsts_sels ,
                                             string AV68Configuracion_condicionpagowwds_1_dynamicfiltersselector1 ,
                                             short AV69Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 ,
                                             string AV70Configuracion_condicionpagowwds_3_conpdsc1 ,
                                             bool AV71Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 ,
                                             string AV72Configuracion_condicionpagowwds_5_dynamicfiltersselector2 ,
                                             short AV73Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 ,
                                             string AV74Configuracion_condicionpagowwds_7_conpdsc2 ,
                                             bool AV75Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 ,
                                             string AV76Configuracion_condicionpagowwds_9_dynamicfiltersselector3 ,
                                             short AV77Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 ,
                                             string AV78Configuracion_condicionpagowwds_11_conpdsc3 ,
                                             int AV79Configuracion_condicionpagowwds_12_tfconpcod ,
                                             int AV80Configuracion_condicionpagowwds_13_tfconpcod_to ,
                                             string AV82Configuracion_condicionpagowwds_15_tfconpdsc_sel ,
                                             string AV81Configuracion_condicionpagowwds_14_tfconpdsc ,
                                             string AV84Configuracion_condicionpagowwds_17_tfconpabr_sel ,
                                             string AV83Configuracion_condicionpagowwds_16_tfconpabr ,
                                             short AV85Configuracion_condicionpagowwds_18_tfconpdias ,
                                             short AV86Configuracion_condicionpagowwds_19_tfconpdias_to ,
                                             int AV87Configuracion_condicionpagowwds_20_tfconpsts_sels_Count ,
                                             string A753ConpDsc ,
                                             int A137Conpcod ,
                                             string A751ConpAbr ,
                                             short A752ConpDias ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ConpSts], [ConpDias], [ConpAbr], [Conpcod], [ConpDsc] FROM [CCONDICIONPAGO]";
         if ( ( StringUtil.StrCmp(AV68Configuracion_condicionpagowwds_1_dynamicfiltersselector1, "CONPDSC") == 0 ) && ( AV69Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_condicionpagowwds_3_conpdsc1)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV70Configuracion_condicionpagowwds_3_conpdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Configuracion_condicionpagowwds_1_dynamicfiltersselector1, "CONPDSC") == 0 ) && ( AV69Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_condicionpagowwds_3_conpdsc1)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like '%' + @lV70Configuracion_condicionpagowwds_3_conpdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV71Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Configuracion_condicionpagowwds_5_dynamicfiltersselector2, "CONPDSC") == 0 ) && ( AV73Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_condicionpagowwds_7_conpdsc2)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV74Configuracion_condicionpagowwds_7_conpdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV71Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Configuracion_condicionpagowwds_5_dynamicfiltersselector2, "CONPDSC") == 0 ) && ( AV73Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_condicionpagowwds_7_conpdsc2)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like '%' + @lV74Configuracion_condicionpagowwds_7_conpdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV75Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_condicionpagowwds_9_dynamicfiltersselector3, "CONPDSC") == 0 ) && ( AV77Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_condicionpagowwds_11_conpdsc3)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV78Configuracion_condicionpagowwds_11_conpdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV75Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_condicionpagowwds_9_dynamicfiltersselector3, "CONPDSC") == 0 ) && ( AV77Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_condicionpagowwds_11_conpdsc3)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like '%' + @lV78Configuracion_condicionpagowwds_11_conpdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV79Configuracion_condicionpagowwds_12_tfconpcod) )
         {
            AddWhere(sWhereString, "([Conpcod] >= @AV79Configuracion_condicionpagowwds_12_tfconpcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV80Configuracion_condicionpagowwds_13_tfconpcod_to) )
         {
            AddWhere(sWhereString, "([Conpcod] <= @AV80Configuracion_condicionpagowwds_13_tfconpcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_condicionpagowwds_15_tfconpdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_condicionpagowwds_14_tfconpdsc)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV81Configuracion_condicionpagowwds_14_tfconpdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_condicionpagowwds_15_tfconpdsc_sel)) )
         {
            AddWhere(sWhereString, "([ConpDsc] = @AV82Configuracion_condicionpagowwds_15_tfconpdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_condicionpagowwds_17_tfconpabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_condicionpagowwds_16_tfconpabr)) ) )
         {
            AddWhere(sWhereString, "([ConpAbr] like @lV83Configuracion_condicionpagowwds_16_tfconpabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_condicionpagowwds_17_tfconpabr_sel)) )
         {
            AddWhere(sWhereString, "([ConpAbr] = @AV84Configuracion_condicionpagowwds_17_tfconpabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV85Configuracion_condicionpagowwds_18_tfconpdias) )
         {
            AddWhere(sWhereString, "([ConpDias] >= @AV85Configuracion_condicionpagowwds_18_tfconpdias)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV86Configuracion_condicionpagowwds_19_tfconpdias_to) )
         {
            AddWhere(sWhereString, "([ConpDias] <= @AV86Configuracion_condicionpagowwds_19_tfconpdias_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV87Configuracion_condicionpagowwds_20_tfconpsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV87Configuracion_condicionpagowwds_20_tfconpsts_sels, "[ConpSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [Conpcod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Conpcod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConpDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConpDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConpAbr]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConpAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConpDias]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConpDias] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConpSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConpSts] DESC";
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
                     return conditional_P002K2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP002K2;
          prmP002K2 = new Object[] {
          new ParDef("@lV70Configuracion_condicionpagowwds_3_conpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_condicionpagowwds_3_conpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_condicionpagowwds_7_conpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_condicionpagowwds_7_conpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_condicionpagowwds_11_conpdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_condicionpagowwds_11_conpdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV79Configuracion_condicionpagowwds_12_tfconpcod",GXType.Int32,6,0) ,
          new ParDef("@AV80Configuracion_condicionpagowwds_13_tfconpcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV81Configuracion_condicionpagowwds_14_tfconpdsc",GXType.NChar,100,0) ,
          new ParDef("@AV82Configuracion_condicionpagowwds_15_tfconpdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV83Configuracion_condicionpagowwds_16_tfconpabr",GXType.NChar,5,0) ,
          new ParDef("@AV84Configuracion_condicionpagowwds_17_tfconpabr_sel",GXType.NChar,5,0) ,
          new ParDef("@AV85Configuracion_condicionpagowwds_18_tfconpdias",GXType.Int16,4,0) ,
          new ParDef("@AV86Configuracion_condicionpagowwds_19_tfconpdias_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002K2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
