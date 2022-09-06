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
   public class departamentoswwexportreport : GXWebProcedure
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

      public departamentoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public departamentoswwexportreport( IGxContext context )
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
         departamentoswwexportreport objdepartamentoswwexportreport;
         objdepartamentoswwexportreport = new departamentoswwexportreport();
         objdepartamentoswwexportreport.context.SetSubmitInitialConfig(context);
         objdepartamentoswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdepartamentoswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((departamentoswwexportreport)stateInfo).executePrivate();
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
            AV53Title = "Lista de Departamentos";
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
            H3M0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "ESTDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15EstDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15EstDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterEstDscDescription = StringUtil.Format( "%1 (%2)", "Departamento", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterEstDscDescription = StringUtil.Format( "%1 (%2)", "Departamento", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17EstDsc = AV15EstDsc1;
                  H3M0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEstDscDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EstDsc, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "PAICOD") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV55PaiCod1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55PaiCod1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV56FilterPaiCodDescription = StringUtil.Format( "%1 (%2)", "Pais", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV56FilterPaiCodDescription = StringUtil.Format( "%1 (%2)", "Pais", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV57PaiCod = AV55PaiCod1;
                  H3M0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FilterPaiCodDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57PaiCod, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "ESTDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21EstDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21EstDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterEstDscDescription = StringUtil.Format( "%1 (%2)", "Departamento", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterEstDscDescription = StringUtil.Format( "%1 (%2)", "Departamento", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17EstDsc = AV21EstDsc2;
                     H3M0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEstDscDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EstDsc, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "PAICOD") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV58PaiCod2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58PaiCod2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV56FilterPaiCodDescription = StringUtil.Format( "%1 (%2)", "Pais", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV56FilterPaiCodDescription = StringUtil.Format( "%1 (%2)", "Pais", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV57PaiCod = AV58PaiCod2;
                     H3M0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FilterPaiCodDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57PaiCod, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "ESTDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25EstDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25EstDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterEstDscDescription = StringUtil.Format( "%1 (%2)", "Departamento", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterEstDscDescription = StringUtil.Format( "%1 (%2)", "Departamento", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17EstDsc = AV25EstDsc3;
                        H3M0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEstDscDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EstDsc, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "PAICOD") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV59PaiCod3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59PaiCod3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV56FilterPaiCodDescription = StringUtil.Format( "%1 (%2)", "Pais", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV56FilterPaiCodDescription = StringUtil.Format( "%1 (%2)", "Pais", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV57PaiCod = AV59PaiCod3;
                        H3M0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FilterPaiCodDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57PaiCod, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFEstCod_Sel)) )
         {
            H3M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFEstCod_Sel, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFEstCod)) )
            {
               H3M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TFEstCod, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFEstDsc_Sel)) )
         {
            H3M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Departamento", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFEstDsc_Sel, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFEstDsc)) )
            {
               H3M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Departamento", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFEstDsc, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPaiDsc_Sel)) )
         {
            H3M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Pais", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFPaiDsc_Sel, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPaiDsc)) )
            {
               H3M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Pais", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFPaiDsc, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV39TFEstSts_Sels.FromJSonString(AV37TFEstSts_SelsJson, null);
         if ( ! ( AV39TFEstSts_Sels.Count == 0 ) )
         {
            AV42i = 1;
            AV64GXV1 = 1;
            while ( AV64GXV1 <= AV39TFEstSts_Sels.Count )
            {
               AV40TFEstSts_Sel = (short)(AV39TFEstSts_Sels.GetNumeric(AV64GXV1));
               if ( AV42i == 1 )
               {
                  AV38TFEstSts_SelDscs = "";
               }
               else
               {
                  AV38TFEstSts_SelDscs += ", ";
               }
               if ( AV40TFEstSts_Sel == 1 )
               {
                  AV41FilterTFEstSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV40TFEstSts_Sel == 0 )
               {
                  AV41FilterTFEstSts_SelValueDescription = "INACTIVO";
               }
               AV38TFEstSts_SelDscs += AV41FilterTFEstSts_SelValueDescription;
               AV42i = (long)(AV42i+1);
               AV64GXV1 = (int)(AV64GXV1+1);
            }
            H3M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFEstSts_SelDscs, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H3M0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H3M0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 136, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Departamento", 140, Gx_line+10, 352, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Pais", 356, Gx_line+10, 569, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 573, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV66Configuracion_departamentoswwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV67Configuracion_departamentoswwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV68Configuracion_departamentoswwds_3_estdsc1 = AV15EstDsc1;
         AV69Configuracion_departamentoswwds_4_paicod1 = AV55PaiCod1;
         AV70Configuracion_departamentoswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV71Configuracion_departamentoswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV72Configuracion_departamentoswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV73Configuracion_departamentoswwds_8_estdsc2 = AV21EstDsc2;
         AV74Configuracion_departamentoswwds_9_paicod2 = AV58PaiCod2;
         AV75Configuracion_departamentoswwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV76Configuracion_departamentoswwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV77Configuracion_departamentoswwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV78Configuracion_departamentoswwds_13_estdsc3 = AV25EstDsc3;
         AV79Configuracion_departamentoswwds_14_paicod3 = AV59PaiCod3;
         AV80Configuracion_departamentoswwds_15_tfestcod = AV31TFEstCod;
         AV81Configuracion_departamentoswwds_16_tfestcod_sel = AV32TFEstCod_Sel;
         AV82Configuracion_departamentoswwds_17_tfestdsc = AV33TFEstDsc;
         AV83Configuracion_departamentoswwds_18_tfestdsc_sel = AV34TFEstDsc_Sel;
         AV84Configuracion_departamentoswwds_19_tfpaidsc = AV35TFPaiDsc;
         AV85Configuracion_departamentoswwds_20_tfpaidsc_sel = AV36TFPaiDsc_Sel;
         AV86Configuracion_departamentoswwds_21_tfeststs_sels = AV39TFEstSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A975EstSts ,
                                              AV86Configuracion_departamentoswwds_21_tfeststs_sels ,
                                              AV66Configuracion_departamentoswwds_1_dynamicfiltersselector1 ,
                                              AV67Configuracion_departamentoswwds_2_dynamicfiltersoperator1 ,
                                              AV68Configuracion_departamentoswwds_3_estdsc1 ,
                                              AV69Configuracion_departamentoswwds_4_paicod1 ,
                                              AV70Configuracion_departamentoswwds_5_dynamicfiltersenabled2 ,
                                              AV71Configuracion_departamentoswwds_6_dynamicfiltersselector2 ,
                                              AV72Configuracion_departamentoswwds_7_dynamicfiltersoperator2 ,
                                              AV73Configuracion_departamentoswwds_8_estdsc2 ,
                                              AV74Configuracion_departamentoswwds_9_paicod2 ,
                                              AV75Configuracion_departamentoswwds_10_dynamicfiltersenabled3 ,
                                              AV76Configuracion_departamentoswwds_11_dynamicfiltersselector3 ,
                                              AV77Configuracion_departamentoswwds_12_dynamicfiltersoperator3 ,
                                              AV78Configuracion_departamentoswwds_13_estdsc3 ,
                                              AV79Configuracion_departamentoswwds_14_paicod3 ,
                                              AV81Configuracion_departamentoswwds_16_tfestcod_sel ,
                                              AV80Configuracion_departamentoswwds_15_tfestcod ,
                                              AV83Configuracion_departamentoswwds_18_tfestdsc_sel ,
                                              AV82Configuracion_departamentoswwds_17_tfestdsc ,
                                              AV85Configuracion_departamentoswwds_20_tfpaidsc_sel ,
                                              AV84Configuracion_departamentoswwds_19_tfpaidsc ,
                                              AV86Configuracion_departamentoswwds_21_tfeststs_sels.Count ,
                                              A602EstDsc ,
                                              A139PaiCod ,
                                              A140EstCod ,
                                              A1500PaiDsc ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV68Configuracion_departamentoswwds_3_estdsc1 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_departamentoswwds_3_estdsc1), 100, "%");
         lV68Configuracion_departamentoswwds_3_estdsc1 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_departamentoswwds_3_estdsc1), 100, "%");
         lV69Configuracion_departamentoswwds_4_paicod1 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_departamentoswwds_4_paicod1), 4, "%");
         lV69Configuracion_departamentoswwds_4_paicod1 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_departamentoswwds_4_paicod1), 4, "%");
         lV73Configuracion_departamentoswwds_8_estdsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_departamentoswwds_8_estdsc2), 100, "%");
         lV73Configuracion_departamentoswwds_8_estdsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_departamentoswwds_8_estdsc2), 100, "%");
         lV74Configuracion_departamentoswwds_9_paicod2 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_departamentoswwds_9_paicod2), 4, "%");
         lV74Configuracion_departamentoswwds_9_paicod2 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_departamentoswwds_9_paicod2), 4, "%");
         lV78Configuracion_departamentoswwds_13_estdsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_departamentoswwds_13_estdsc3), 100, "%");
         lV78Configuracion_departamentoswwds_13_estdsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_departamentoswwds_13_estdsc3), 100, "%");
         lV79Configuracion_departamentoswwds_14_paicod3 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_departamentoswwds_14_paicod3), 4, "%");
         lV79Configuracion_departamentoswwds_14_paicod3 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_departamentoswwds_14_paicod3), 4, "%");
         lV80Configuracion_departamentoswwds_15_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_departamentoswwds_15_tfestcod), 4, "%");
         lV82Configuracion_departamentoswwds_17_tfestdsc = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_departamentoswwds_17_tfestdsc), 100, "%");
         lV84Configuracion_departamentoswwds_19_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_departamentoswwds_19_tfpaidsc), 100, "%");
         /* Using cursor P003M2 */
         pr_default.execute(0, new Object[] {lV68Configuracion_departamentoswwds_3_estdsc1, lV68Configuracion_departamentoswwds_3_estdsc1, lV69Configuracion_departamentoswwds_4_paicod1, lV69Configuracion_departamentoswwds_4_paicod1, lV73Configuracion_departamentoswwds_8_estdsc2, lV73Configuracion_departamentoswwds_8_estdsc2, lV74Configuracion_departamentoswwds_9_paicod2, lV74Configuracion_departamentoswwds_9_paicod2, lV78Configuracion_departamentoswwds_13_estdsc3, lV78Configuracion_departamentoswwds_13_estdsc3, lV79Configuracion_departamentoswwds_14_paicod3, lV79Configuracion_departamentoswwds_14_paicod3, lV80Configuracion_departamentoswwds_15_tfestcod, AV81Configuracion_departamentoswwds_16_tfestcod_sel, lV82Configuracion_departamentoswwds_17_tfestdsc, AV83Configuracion_departamentoswwds_18_tfestdsc_sel, lV84Configuracion_departamentoswwds_19_tfpaidsc, AV85Configuracion_departamentoswwds_20_tfpaidsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A975EstSts = P003M2_A975EstSts[0];
            A1500PaiDsc = P003M2_A1500PaiDsc[0];
            A140EstCod = P003M2_A140EstCod[0];
            A139PaiCod = P003M2_A139PaiCod[0];
            A602EstDsc = P003M2_A602EstDsc[0];
            A1500PaiDsc = P003M2_A1500PaiDsc[0];
            if ( A975EstSts == 1 )
            {
               AV12EstStsDescription = "ACTIVO";
            }
            else if ( A975EstSts == 0 )
            {
               AV12EstStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H3M0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A140EstCod, "")), 30, Gx_line+10, 136, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A602EstDsc, "")), 140, Gx_line+10, 352, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1500PaiDsc, "")), 356, Gx_line+10, 569, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12EstStsDescription, "")), 573, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.DepartamentosWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.DepartamentosWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.DepartamentosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV87GXV2 = 1;
         while ( AV87GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV87GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFESTCOD") == 0 )
            {
               AV31TFEstCod = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFESTCOD_SEL") == 0 )
            {
               AV32TFEstCod_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFESTDSC") == 0 )
            {
               AV33TFEstDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFESTDSC_SEL") == 0 )
            {
               AV34TFEstDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPAIDSC") == 0 )
            {
               AV35TFPaiDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPAIDSC_SEL") == 0 )
            {
               AV36TFPaiDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFESTSTS_SEL") == 0 )
            {
               AV37TFEstSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV39TFEstSts_Sels.FromJSonString(AV37TFEstSts_SelsJson, null);
            }
            AV87GXV2 = (int)(AV87GXV2+1);
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

      protected void H3M0( bool bFoot ,
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
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15EstDsc1 = "";
         AV16FilterEstDscDescription = "";
         AV17EstDsc = "";
         AV55PaiCod1 = "";
         AV56FilterPaiCodDescription = "";
         AV57PaiCod = "";
         AV19DynamicFiltersSelector2 = "";
         AV21EstDsc2 = "";
         AV58PaiCod2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25EstDsc3 = "";
         AV59PaiCod3 = "";
         AV32TFEstCod_Sel = "";
         AV31TFEstCod = "";
         AV34TFEstDsc_Sel = "";
         AV33TFEstDsc = "";
         AV36TFPaiDsc_Sel = "";
         AV35TFPaiDsc = "";
         AV39TFEstSts_Sels = new GxSimpleCollection<short>();
         AV37TFEstSts_SelsJson = "";
         AV38TFEstSts_SelDscs = "";
         AV41FilterTFEstSts_SelValueDescription = "";
         AV66Configuracion_departamentoswwds_1_dynamicfiltersselector1 = "";
         AV68Configuracion_departamentoswwds_3_estdsc1 = "";
         AV69Configuracion_departamentoswwds_4_paicod1 = "";
         AV71Configuracion_departamentoswwds_6_dynamicfiltersselector2 = "";
         AV73Configuracion_departamentoswwds_8_estdsc2 = "";
         AV74Configuracion_departamentoswwds_9_paicod2 = "";
         AV76Configuracion_departamentoswwds_11_dynamicfiltersselector3 = "";
         AV78Configuracion_departamentoswwds_13_estdsc3 = "";
         AV79Configuracion_departamentoswwds_14_paicod3 = "";
         AV80Configuracion_departamentoswwds_15_tfestcod = "";
         AV81Configuracion_departamentoswwds_16_tfestcod_sel = "";
         AV82Configuracion_departamentoswwds_17_tfestdsc = "";
         AV83Configuracion_departamentoswwds_18_tfestdsc_sel = "";
         AV84Configuracion_departamentoswwds_19_tfpaidsc = "";
         AV85Configuracion_departamentoswwds_20_tfpaidsc_sel = "";
         AV86Configuracion_departamentoswwds_21_tfeststs_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV68Configuracion_departamentoswwds_3_estdsc1 = "";
         lV69Configuracion_departamentoswwds_4_paicod1 = "";
         lV73Configuracion_departamentoswwds_8_estdsc2 = "";
         lV74Configuracion_departamentoswwds_9_paicod2 = "";
         lV78Configuracion_departamentoswwds_13_estdsc3 = "";
         lV79Configuracion_departamentoswwds_14_paicod3 = "";
         lV80Configuracion_departamentoswwds_15_tfestcod = "";
         lV82Configuracion_departamentoswwds_17_tfestdsc = "";
         lV84Configuracion_departamentoswwds_19_tfpaidsc = "";
         A602EstDsc = "";
         A139PaiCod = "";
         A140EstCod = "";
         A1500PaiDsc = "";
         P003M2_A975EstSts = new short[1] ;
         P003M2_A1500PaiDsc = new string[] {""} ;
         P003M2_A140EstCod = new string[] {""} ;
         P003M2_A139PaiCod = new string[] {""} ;
         P003M2_A602EstDsc = new string[] {""} ;
         AV12EstStsDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.departamentoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P003M2_A975EstSts, P003M2_A1500PaiDsc, P003M2_A140EstCod, P003M2_A139PaiCod, P003M2_A602EstDsc
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
      private short AV40TFEstSts_Sel ;
      private short AV67Configuracion_departamentoswwds_2_dynamicfiltersoperator1 ;
      private short AV72Configuracion_departamentoswwds_7_dynamicfiltersoperator2 ;
      private short AV77Configuracion_departamentoswwds_12_dynamicfiltersoperator3 ;
      private short A975EstSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV64GXV1 ;
      private int AV86Configuracion_departamentoswwds_21_tfeststs_sels_Count ;
      private int AV87GXV2 ;
      private long AV42i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15EstDsc1 ;
      private string AV17EstDsc ;
      private string AV55PaiCod1 ;
      private string AV57PaiCod ;
      private string AV21EstDsc2 ;
      private string AV58PaiCod2 ;
      private string AV25EstDsc3 ;
      private string AV59PaiCod3 ;
      private string AV32TFEstCod_Sel ;
      private string AV31TFEstCod ;
      private string AV34TFEstDsc_Sel ;
      private string AV33TFEstDsc ;
      private string AV36TFPaiDsc_Sel ;
      private string AV35TFPaiDsc ;
      private string AV68Configuracion_departamentoswwds_3_estdsc1 ;
      private string AV69Configuracion_departamentoswwds_4_paicod1 ;
      private string AV73Configuracion_departamentoswwds_8_estdsc2 ;
      private string AV74Configuracion_departamentoswwds_9_paicod2 ;
      private string AV78Configuracion_departamentoswwds_13_estdsc3 ;
      private string AV79Configuracion_departamentoswwds_14_paicod3 ;
      private string AV80Configuracion_departamentoswwds_15_tfestcod ;
      private string AV81Configuracion_departamentoswwds_16_tfestcod_sel ;
      private string AV82Configuracion_departamentoswwds_17_tfestdsc ;
      private string AV83Configuracion_departamentoswwds_18_tfestdsc_sel ;
      private string AV84Configuracion_departamentoswwds_19_tfpaidsc ;
      private string AV85Configuracion_departamentoswwds_20_tfpaidsc_sel ;
      private string scmdbuf ;
      private string lV68Configuracion_departamentoswwds_3_estdsc1 ;
      private string lV69Configuracion_departamentoswwds_4_paicod1 ;
      private string lV73Configuracion_departamentoswwds_8_estdsc2 ;
      private string lV74Configuracion_departamentoswwds_9_paicod2 ;
      private string lV78Configuracion_departamentoswwds_13_estdsc3 ;
      private string lV79Configuracion_departamentoswwds_14_paicod3 ;
      private string lV80Configuracion_departamentoswwds_15_tfestcod ;
      private string lV82Configuracion_departamentoswwds_17_tfestdsc ;
      private string lV84Configuracion_departamentoswwds_19_tfpaidsc ;
      private string A602EstDsc ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A1500PaiDsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV70Configuracion_departamentoswwds_5_dynamicfiltersenabled2 ;
      private bool AV75Configuracion_departamentoswwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV37TFEstSts_SelsJson ;
      private string AV53Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterEstDscDescription ;
      private string AV56FilterPaiCodDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV38TFEstSts_SelDscs ;
      private string AV41FilterTFEstSts_SelValueDescription ;
      private string AV66Configuracion_departamentoswwds_1_dynamicfiltersselector1 ;
      private string AV71Configuracion_departamentoswwds_6_dynamicfiltersselector2 ;
      private string AV76Configuracion_departamentoswwds_11_dynamicfiltersselector3 ;
      private string AV12EstStsDescription ;
      private string AV51PageInfo ;
      private string AV48DateInfo ;
      private string AV46AppName ;
      private string AV52Phone ;
      private string AV50Mail ;
      private string AV54Website ;
      private string AV43AddressLine1 ;
      private string AV44AddressLine2 ;
      private string AV45AddressLine3 ;
      private GxSimpleCollection<short> AV39TFEstSts_Sels ;
      private GxSimpleCollection<short> AV86Configuracion_departamentoswwds_21_tfeststs_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003M2_A975EstSts ;
      private string[] P003M2_A1500PaiDsc ;
      private string[] P003M2_A140EstCod ;
      private string[] P003M2_A139PaiCod ;
      private string[] P003M2_A602EstDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class departamentoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003M2( IGxContext context ,
                                             short A975EstSts ,
                                             GxSimpleCollection<short> AV86Configuracion_departamentoswwds_21_tfeststs_sels ,
                                             string AV66Configuracion_departamentoswwds_1_dynamicfiltersselector1 ,
                                             short AV67Configuracion_departamentoswwds_2_dynamicfiltersoperator1 ,
                                             string AV68Configuracion_departamentoswwds_3_estdsc1 ,
                                             string AV69Configuracion_departamentoswwds_4_paicod1 ,
                                             bool AV70Configuracion_departamentoswwds_5_dynamicfiltersenabled2 ,
                                             string AV71Configuracion_departamentoswwds_6_dynamicfiltersselector2 ,
                                             short AV72Configuracion_departamentoswwds_7_dynamicfiltersoperator2 ,
                                             string AV73Configuracion_departamentoswwds_8_estdsc2 ,
                                             string AV74Configuracion_departamentoswwds_9_paicod2 ,
                                             bool AV75Configuracion_departamentoswwds_10_dynamicfiltersenabled3 ,
                                             string AV76Configuracion_departamentoswwds_11_dynamicfiltersselector3 ,
                                             short AV77Configuracion_departamentoswwds_12_dynamicfiltersoperator3 ,
                                             string AV78Configuracion_departamentoswwds_13_estdsc3 ,
                                             string AV79Configuracion_departamentoswwds_14_paicod3 ,
                                             string AV81Configuracion_departamentoswwds_16_tfestcod_sel ,
                                             string AV80Configuracion_departamentoswwds_15_tfestcod ,
                                             string AV83Configuracion_departamentoswwds_18_tfestdsc_sel ,
                                             string AV82Configuracion_departamentoswwds_17_tfestdsc ,
                                             string AV85Configuracion_departamentoswwds_20_tfpaidsc_sel ,
                                             string AV84Configuracion_departamentoswwds_19_tfpaidsc ,
                                             int AV86Configuracion_departamentoswwds_21_tfeststs_sels_Count ,
                                             string A602EstDsc ,
                                             string A139PaiCod ,
                                             string A140EstCod ,
                                             string A1500PaiDsc ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[18];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[EstSts], T2.[PaiDsc], T1.[EstCod], T1.[PaiCod], T1.[EstDsc] FROM ([CESTADOS] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV66Configuracion_departamentoswwds_1_dynamicfiltersselector1, "ESTDSC") == 0 ) && ( AV67Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_departamentoswwds_3_estdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV68Configuracion_departamentoswwds_3_estdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_departamentoswwds_1_dynamicfiltersselector1, "ESTDSC") == 0 ) && ( AV67Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_departamentoswwds_3_estdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV68Configuracion_departamentoswwds_3_estdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_departamentoswwds_1_dynamicfiltersselector1, "PAICOD") == 0 ) && ( AV67Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_departamentoswwds_4_paicod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV69Configuracion_departamentoswwds_4_paicod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_departamentoswwds_1_dynamicfiltersselector1, "PAICOD") == 0 ) && ( AV67Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_departamentoswwds_4_paicod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV69Configuracion_departamentoswwds_4_paicod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV70Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_departamentoswwds_6_dynamicfiltersselector2, "ESTDSC") == 0 ) && ( AV72Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_departamentoswwds_8_estdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV73Configuracion_departamentoswwds_8_estdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV70Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_departamentoswwds_6_dynamicfiltersselector2, "ESTDSC") == 0 ) && ( AV72Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_departamentoswwds_8_estdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV73Configuracion_departamentoswwds_8_estdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV70Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_departamentoswwds_6_dynamicfiltersselector2, "PAICOD") == 0 ) && ( AV72Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_departamentoswwds_9_paicod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV74Configuracion_departamentoswwds_9_paicod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV70Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_departamentoswwds_6_dynamicfiltersselector2, "PAICOD") == 0 ) && ( AV72Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_departamentoswwds_9_paicod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV74Configuracion_departamentoswwds_9_paicod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV75Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_departamentoswwds_11_dynamicfiltersselector3, "ESTDSC") == 0 ) && ( AV77Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_departamentoswwds_13_estdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV78Configuracion_departamentoswwds_13_estdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV75Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_departamentoswwds_11_dynamicfiltersselector3, "ESTDSC") == 0 ) && ( AV77Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_departamentoswwds_13_estdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV78Configuracion_departamentoswwds_13_estdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV75Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_departamentoswwds_11_dynamicfiltersselector3, "PAICOD") == 0 ) && ( AV77Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_departamentoswwds_14_paicod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV79Configuracion_departamentoswwds_14_paicod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV75Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_departamentoswwds_11_dynamicfiltersselector3, "PAICOD") == 0 ) && ( AV77Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_departamentoswwds_14_paicod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV79Configuracion_departamentoswwds_14_paicod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_departamentoswwds_16_tfestcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_departamentoswwds_15_tfestcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] like @lV80Configuracion_departamentoswwds_15_tfestcod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_departamentoswwds_16_tfestcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] = @AV81Configuracion_departamentoswwds_16_tfestcod_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_departamentoswwds_18_tfestdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_departamentoswwds_17_tfestdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV82Configuracion_departamentoswwds_17_tfestdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_departamentoswwds_18_tfestdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] = @AV83Configuracion_departamentoswwds_18_tfestdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_departamentoswwds_20_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_departamentoswwds_19_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV84Configuracion_departamentoswwds_19_tfpaidsc)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_departamentoswwds_20_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV85Configuracion_departamentoswwds_20_tfpaidsc_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV86Configuracion_departamentoswwds_21_tfeststs_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV86Configuracion_departamentoswwds_21_tfeststs_sels, "T1.[EstSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[PaiCod], T1.[EstCod]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstCod]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstCod] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstDsc]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstDsc] DESC";
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
            scmdbuf += " ORDER BY T1.[EstSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstSts] DESC";
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
                     return conditional_P003M2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
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
          Object[] prmP003M2;
          prmP003M2 = new Object[] {
          new ParDef("@lV68Configuracion_departamentoswwds_3_estdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_departamentoswwds_3_estdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_departamentoswwds_4_paicod1",GXType.NChar,4,0) ,
          new ParDef("@lV69Configuracion_departamentoswwds_4_paicod1",GXType.NChar,4,0) ,
          new ParDef("@lV73Configuracion_departamentoswwds_8_estdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_departamentoswwds_8_estdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_departamentoswwds_9_paicod2",GXType.NChar,4,0) ,
          new ParDef("@lV74Configuracion_departamentoswwds_9_paicod2",GXType.NChar,4,0) ,
          new ParDef("@lV78Configuracion_departamentoswwds_13_estdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_departamentoswwds_13_estdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_departamentoswwds_14_paicod3",GXType.NChar,4,0) ,
          new ParDef("@lV79Configuracion_departamentoswwds_14_paicod3",GXType.NChar,4,0) ,
          new ParDef("@lV80Configuracion_departamentoswwds_15_tfestcod",GXType.NChar,4,0) ,
          new ParDef("@AV81Configuracion_departamentoswwds_16_tfestcod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV82Configuracion_departamentoswwds_17_tfestdsc",GXType.NChar,100,0) ,
          new ParDef("@AV83Configuracion_departamentoswwds_18_tfestdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV84Configuracion_departamentoswwds_19_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV85Configuracion_departamentoswwds_20_tfpaidsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003M2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
