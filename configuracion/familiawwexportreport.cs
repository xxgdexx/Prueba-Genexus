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
   public class familiawwexportreport : GXWebProcedure
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

      public familiawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public familiawwexportreport( IGxContext context )
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
         familiawwexportreport objfamiliawwexportreport;
         objfamiliawwexportreport = new familiawwexportreport();
         objfamiliawwexportreport.context.SetSubmitInitialConfig(context);
         objfamiliawwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objfamiliawwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((familiawwexportreport)stateInfo).executePrivate();
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
            AV54Title = "Lista de Familia";
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
            H300( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "FAMDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15FamDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15FamDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterFamDscDescription = StringUtil.Format( "%1 (%2)", "Familia", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterFamDscDescription = StringUtil.Format( "%1 (%2)", "Familia", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17FamDsc = AV15FamDsc1;
                  H300( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterFamDscDescription, "")), 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FamDsc, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "FAMDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21FamDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21FamDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterFamDscDescription = StringUtil.Format( "%1 (%2)", "Familia", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterFamDscDescription = StringUtil.Format( "%1 (%2)", "Familia", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17FamDsc = AV21FamDsc2;
                     H300( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterFamDscDescription, "")), 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FamDsc, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "FAMDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25FamDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25FamDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterFamDscDescription = StringUtil.Format( "%1 (%2)", "Familia", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterFamDscDescription = StringUtil.Format( "%1 (%2)", "Familia", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17FamDsc = AV25FamDsc3;
                        H300( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterFamDscDescription, "")), 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FamDsc, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFFamCod) && (0==AV32TFFamCod_To) ) )
         {
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFFamCod), "ZZZZZ9")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV41TFFamCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFFamCod_To_Description, "")), 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFFamCod_To), "ZZZZZ9")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFFamDsc_Sel)) )
         {
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Familia", 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFFamDsc_Sel, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFFamDsc)) )
            {
               H300( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Familia", 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFFamDsc, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFFamAbr_Sel)) )
         {
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFFamAbr_Sel, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFFamAbr)) )
            {
               H300( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFFamAbr, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV39TFFamSts_Sels.FromJSonString(AV37TFFamSts_SelsJson, null);
         if ( ! ( AV39TFFamSts_Sels.Count == 0 ) )
         {
            AV43i = 1;
            AV60GXV1 = 1;
            while ( AV60GXV1 <= AV39TFFamSts_Sels.Count )
            {
               AV40TFFamSts_Sel = (short)(AV39TFFamSts_Sels.GetNumeric(AV60GXV1));
               if ( AV43i == 1 )
               {
                  AV38TFFamSts_SelDscs = "";
               }
               else
               {
                  AV38TFFamSts_SelDscs += ", ";
               }
               if ( AV40TFFamSts_Sel == 1 )
               {
                  AV42FilterTFFamSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV40TFFamSts_Sel == 0 )
               {
                  AV42FilterTFFamSts_SelValueDescription = "INACTIVO";
               }
               AV38TFFamSts_SelDscs += AV42FilterTFFamSts_SelValueDescription;
               AV43i = (long)(AV43i+1);
               AV60GXV1 = (int)(AV60GXV1+1);
            }
            H300( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 177, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFFamSts_SelDscs, "")), 177, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H300( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H300( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 135, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Familia", 139, Gx_line+10, 351, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Abreviatura", 355, Gx_line+10, 461, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 465, Gx_line+10, 677, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Foto", 681, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV62Configuracion_familiawwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV63Configuracion_familiawwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV64Configuracion_familiawwds_3_famdsc1 = AV15FamDsc1;
         AV65Configuracion_familiawwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV66Configuracion_familiawwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV67Configuracion_familiawwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV68Configuracion_familiawwds_7_famdsc2 = AV21FamDsc2;
         AV69Configuracion_familiawwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV70Configuracion_familiawwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV71Configuracion_familiawwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV72Configuracion_familiawwds_11_famdsc3 = AV25FamDsc3;
         AV73Configuracion_familiawwds_12_tffamcod = AV31TFFamCod;
         AV74Configuracion_familiawwds_13_tffamcod_to = AV32TFFamCod_To;
         AV75Configuracion_familiawwds_14_tffamdsc = AV33TFFamDsc;
         AV76Configuracion_familiawwds_15_tffamdsc_sel = AV34TFFamDsc_Sel;
         AV77Configuracion_familiawwds_16_tffamabr = AV35TFFamAbr;
         AV78Configuracion_familiawwds_17_tffamabr_sel = AV36TFFamAbr_Sel;
         AV79Configuracion_familiawwds_18_tffamsts_sels = AV39TFFamSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A979FamSts ,
                                              AV79Configuracion_familiawwds_18_tffamsts_sels ,
                                              AV62Configuracion_familiawwds_1_dynamicfiltersselector1 ,
                                              AV63Configuracion_familiawwds_2_dynamicfiltersoperator1 ,
                                              AV64Configuracion_familiawwds_3_famdsc1 ,
                                              AV65Configuracion_familiawwds_4_dynamicfiltersenabled2 ,
                                              AV66Configuracion_familiawwds_5_dynamicfiltersselector2 ,
                                              AV67Configuracion_familiawwds_6_dynamicfiltersoperator2 ,
                                              AV68Configuracion_familiawwds_7_famdsc2 ,
                                              AV69Configuracion_familiawwds_8_dynamicfiltersenabled3 ,
                                              AV70Configuracion_familiawwds_9_dynamicfiltersselector3 ,
                                              AV71Configuracion_familiawwds_10_dynamicfiltersoperator3 ,
                                              AV72Configuracion_familiawwds_11_famdsc3 ,
                                              AV73Configuracion_familiawwds_12_tffamcod ,
                                              AV74Configuracion_familiawwds_13_tffamcod_to ,
                                              AV76Configuracion_familiawwds_15_tffamdsc_sel ,
                                              AV75Configuracion_familiawwds_14_tffamdsc ,
                                              AV78Configuracion_familiawwds_17_tffamabr_sel ,
                                              AV77Configuracion_familiawwds_16_tffamabr ,
                                              AV79Configuracion_familiawwds_18_tffamsts_sels.Count ,
                                              A977FamDsc ,
                                              A50FamCod ,
                                              A976FamAbr ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV64Configuracion_familiawwds_3_famdsc1 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_familiawwds_3_famdsc1), 100, "%");
         lV64Configuracion_familiawwds_3_famdsc1 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_familiawwds_3_famdsc1), 100, "%");
         lV68Configuracion_familiawwds_7_famdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_familiawwds_7_famdsc2), 100, "%");
         lV68Configuracion_familiawwds_7_famdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_familiawwds_7_famdsc2), 100, "%");
         lV72Configuracion_familiawwds_11_famdsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_familiawwds_11_famdsc3), 100, "%");
         lV72Configuracion_familiawwds_11_famdsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_familiawwds_11_famdsc3), 100, "%");
         lV75Configuracion_familiawwds_14_tffamdsc = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_familiawwds_14_tffamdsc), 100, "%");
         lV77Configuracion_familiawwds_16_tffamabr = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_familiawwds_16_tffamabr), 5, "%");
         /* Using cursor P00302 */
         pr_default.execute(0, new Object[] {lV64Configuracion_familiawwds_3_famdsc1, lV64Configuracion_familiawwds_3_famdsc1, lV68Configuracion_familiawwds_7_famdsc2, lV68Configuracion_familiawwds_7_famdsc2, lV72Configuracion_familiawwds_11_famdsc3, lV72Configuracion_familiawwds_11_famdsc3, AV73Configuracion_familiawwds_12_tffamcod, AV74Configuracion_familiawwds_13_tffamcod_to, lV75Configuracion_familiawwds_14_tffamdsc, AV76Configuracion_familiawwds_15_tffamdsc_sel, lV77Configuracion_familiawwds_16_tffamabr, AV78Configuracion_familiawwds_17_tffamabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A979FamSts = P00302_A979FamSts[0];
            A976FamAbr = P00302_A976FamAbr[0];
            A50FamCod = P00302_A50FamCod[0];
            A977FamDsc = P00302_A977FamDsc[0];
            A40000FamFoto_GXI = P00302_A40000FamFoto_GXI[0];
            A978FamFoto = P00302_A978FamFoto[0];
            if ( A979FamSts == 1 )
            {
               AV12FamStsDescription = "ACTIVO";
            }
            else if ( A979FamSts == 0 )
            {
               AV12FamStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H300( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A50FamCod), "ZZZZZ9")), 30, Gx_line+10, 135, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A977FamDsc, "")), 139, Gx_line+10, 351, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A976FamAbr, "")), 355, Gx_line+10, 461, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FamStsDescription, "")), 465, Gx_line+10, 677, Gx_line+25, 0, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : A978FamFoto);
            getPrinter().GxDrawBitMap(sImgUrl, 681, Gx_line+10, 787, Gx_line+25) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.FamiliaWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.FamiliaWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.FamiliaWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV80GXV2 = 1;
         while ( AV80GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV80GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFAMCOD") == 0 )
            {
               AV31TFFamCod = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AV32TFFamCod_To = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFAMDSC") == 0 )
            {
               AV33TFFamDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFAMDSC_SEL") == 0 )
            {
               AV34TFFamDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFAMABR") == 0 )
            {
               AV35TFFamAbr = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFAMABR_SEL") == 0 )
            {
               AV36TFFamAbr_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFAMSTS_SEL") == 0 )
            {
               AV37TFFamSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV39TFFamSts_Sels.FromJSonString(AV37TFFamSts_SelsJson, null);
            }
            AV80GXV2 = (int)(AV80GXV2+1);
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

      protected void H300( bool bFoot ,
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
                  AV52PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV49DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV47AppName = "DVelop Software Solutions";
               AV53Phone = "+1 550 8923";
               AV51Mail = "info@mail.com";
               AV55Website = "http://www.web.com";
               AV44AddressLine1 = "French Boulevard 2859";
               AV45AddressLine2 = "Downtown";
               AV46AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV54Title = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15FamDsc1 = "";
         AV16FilterFamDscDescription = "";
         AV17FamDsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21FamDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25FamDsc3 = "";
         AV41TFFamCod_To_Description = "";
         AV34TFFamDsc_Sel = "";
         AV33TFFamDsc = "";
         AV36TFFamAbr_Sel = "";
         AV35TFFamAbr = "";
         AV39TFFamSts_Sels = new GxSimpleCollection<short>();
         AV37TFFamSts_SelsJson = "";
         AV38TFFamSts_SelDscs = "";
         AV42FilterTFFamSts_SelValueDescription = "";
         AV62Configuracion_familiawwds_1_dynamicfiltersselector1 = "";
         AV64Configuracion_familiawwds_3_famdsc1 = "";
         AV66Configuracion_familiawwds_5_dynamicfiltersselector2 = "";
         AV68Configuracion_familiawwds_7_famdsc2 = "";
         AV70Configuracion_familiawwds_9_dynamicfiltersselector3 = "";
         AV72Configuracion_familiawwds_11_famdsc3 = "";
         AV75Configuracion_familiawwds_14_tffamdsc = "";
         AV76Configuracion_familiawwds_15_tffamdsc_sel = "";
         AV77Configuracion_familiawwds_16_tffamabr = "";
         AV78Configuracion_familiawwds_17_tffamabr_sel = "";
         AV79Configuracion_familiawwds_18_tffamsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV64Configuracion_familiawwds_3_famdsc1 = "";
         lV68Configuracion_familiawwds_7_famdsc2 = "";
         lV72Configuracion_familiawwds_11_famdsc3 = "";
         lV75Configuracion_familiawwds_14_tffamdsc = "";
         lV77Configuracion_familiawwds_16_tffamabr = "";
         A977FamDsc = "";
         A976FamAbr = "";
         P00302_A979FamSts = new short[1] ;
         P00302_A976FamAbr = new string[] {""} ;
         P00302_A50FamCod = new int[1] ;
         P00302_A977FamDsc = new string[] {""} ;
         P00302_A40000FamFoto_GXI = new string[] {""} ;
         P00302_A978FamFoto = new string[] {""} ;
         A40000FamFoto_GXI = "";
         A978FamFoto = "";
         AV12FamStsDescription = "";
         sImgUrl = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV52PageInfo = "";
         AV49DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV47AppName = "";
         AV53Phone = "";
         AV51Mail = "";
         AV55Website = "";
         AV44AddressLine1 = "";
         AV45AddressLine2 = "";
         AV46AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.familiawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00302_A979FamSts, P00302_A976FamAbr, P00302_A50FamCod, P00302_A977FamDsc, P00302_A40000FamFoto_GXI, P00302_A978FamFoto
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
      private short AV40TFFamSts_Sel ;
      private short AV63Configuracion_familiawwds_2_dynamicfiltersoperator1 ;
      private short AV67Configuracion_familiawwds_6_dynamicfiltersoperator2 ;
      private short AV71Configuracion_familiawwds_10_dynamicfiltersoperator3 ;
      private short A979FamSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV31TFFamCod ;
      private int AV32TFFamCod_To ;
      private int AV60GXV1 ;
      private int AV73Configuracion_familiawwds_12_tffamcod ;
      private int AV74Configuracion_familiawwds_13_tffamcod_to ;
      private int AV79Configuracion_familiawwds_18_tffamsts_sels_Count ;
      private int A50FamCod ;
      private int AV80GXV2 ;
      private long AV43i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15FamDsc1 ;
      private string AV17FamDsc ;
      private string AV21FamDsc2 ;
      private string AV25FamDsc3 ;
      private string AV34TFFamDsc_Sel ;
      private string AV33TFFamDsc ;
      private string AV36TFFamAbr_Sel ;
      private string AV35TFFamAbr ;
      private string AV64Configuracion_familiawwds_3_famdsc1 ;
      private string AV68Configuracion_familiawwds_7_famdsc2 ;
      private string AV72Configuracion_familiawwds_11_famdsc3 ;
      private string AV75Configuracion_familiawwds_14_tffamdsc ;
      private string AV76Configuracion_familiawwds_15_tffamdsc_sel ;
      private string AV77Configuracion_familiawwds_16_tffamabr ;
      private string AV78Configuracion_familiawwds_17_tffamabr_sel ;
      private string scmdbuf ;
      private string lV64Configuracion_familiawwds_3_famdsc1 ;
      private string lV68Configuracion_familiawwds_7_famdsc2 ;
      private string lV72Configuracion_familiawwds_11_famdsc3 ;
      private string lV75Configuracion_familiawwds_14_tffamdsc ;
      private string lV77Configuracion_familiawwds_16_tffamabr ;
      private string A977FamDsc ;
      private string A976FamAbr ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV65Configuracion_familiawwds_4_dynamicfiltersenabled2 ;
      private bool AV69Configuracion_familiawwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV37TFFamSts_SelsJson ;
      private string AV54Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterFamDscDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV41TFFamCod_To_Description ;
      private string AV38TFFamSts_SelDscs ;
      private string AV42FilterTFFamSts_SelValueDescription ;
      private string AV62Configuracion_familiawwds_1_dynamicfiltersselector1 ;
      private string AV66Configuracion_familiawwds_5_dynamicfiltersselector2 ;
      private string AV70Configuracion_familiawwds_9_dynamicfiltersselector3 ;
      private string A40000FamFoto_GXI ;
      private string AV12FamStsDescription ;
      private string AV52PageInfo ;
      private string AV49DateInfo ;
      private string AV47AppName ;
      private string AV53Phone ;
      private string AV51Mail ;
      private string AV55Website ;
      private string AV44AddressLine1 ;
      private string AV45AddressLine2 ;
      private string AV46AddressLine3 ;
      private string A978FamFoto ;
      private GxSimpleCollection<short> AV39TFFamSts_Sels ;
      private GxSimpleCollection<short> AV79Configuracion_familiawwds_18_tffamsts_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00302_A979FamSts ;
      private string[] P00302_A976FamAbr ;
      private int[] P00302_A50FamCod ;
      private string[] P00302_A977FamDsc ;
      private string[] P00302_A40000FamFoto_GXI ;
      private string[] P00302_A978FamFoto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class familiawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00302( IGxContext context ,
                                             short A979FamSts ,
                                             GxSimpleCollection<short> AV79Configuracion_familiawwds_18_tffamsts_sels ,
                                             string AV62Configuracion_familiawwds_1_dynamicfiltersselector1 ,
                                             short AV63Configuracion_familiawwds_2_dynamicfiltersoperator1 ,
                                             string AV64Configuracion_familiawwds_3_famdsc1 ,
                                             bool AV65Configuracion_familiawwds_4_dynamicfiltersenabled2 ,
                                             string AV66Configuracion_familiawwds_5_dynamicfiltersselector2 ,
                                             short AV67Configuracion_familiawwds_6_dynamicfiltersoperator2 ,
                                             string AV68Configuracion_familiawwds_7_famdsc2 ,
                                             bool AV69Configuracion_familiawwds_8_dynamicfiltersenabled3 ,
                                             string AV70Configuracion_familiawwds_9_dynamicfiltersselector3 ,
                                             short AV71Configuracion_familiawwds_10_dynamicfiltersoperator3 ,
                                             string AV72Configuracion_familiawwds_11_famdsc3 ,
                                             int AV73Configuracion_familiawwds_12_tffamcod ,
                                             int AV74Configuracion_familiawwds_13_tffamcod_to ,
                                             string AV76Configuracion_familiawwds_15_tffamdsc_sel ,
                                             string AV75Configuracion_familiawwds_14_tffamdsc ,
                                             string AV78Configuracion_familiawwds_17_tffamabr_sel ,
                                             string AV77Configuracion_familiawwds_16_tffamabr ,
                                             int AV79Configuracion_familiawwds_18_tffamsts_sels_Count ,
                                             string A977FamDsc ,
                                             int A50FamCod ,
                                             string A976FamAbr ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [FamSts], [FamAbr], [FamCod], [FamDsc], [FamFoto_GXI], [FamFoto] FROM [CFAMILIA]";
         if ( ( StringUtil.StrCmp(AV62Configuracion_familiawwds_1_dynamicfiltersselector1, "FAMDSC") == 0 ) && ( AV63Configuracion_familiawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_familiawwds_3_famdsc1)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV64Configuracion_familiawwds_3_famdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Configuracion_familiawwds_1_dynamicfiltersselector1, "FAMDSC") == 0 ) && ( AV63Configuracion_familiawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_familiawwds_3_famdsc1)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like '%' + @lV64Configuracion_familiawwds_3_famdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV65Configuracion_familiawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Configuracion_familiawwds_5_dynamicfiltersselector2, "FAMDSC") == 0 ) && ( AV67Configuracion_familiawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_familiawwds_7_famdsc2)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV68Configuracion_familiawwds_7_famdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV65Configuracion_familiawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Configuracion_familiawwds_5_dynamicfiltersselector2, "FAMDSC") == 0 ) && ( AV67Configuracion_familiawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_familiawwds_7_famdsc2)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like '%' + @lV68Configuracion_familiawwds_7_famdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV69Configuracion_familiawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Configuracion_familiawwds_9_dynamicfiltersselector3, "FAMDSC") == 0 ) && ( AV71Configuracion_familiawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_familiawwds_11_famdsc3)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV72Configuracion_familiawwds_11_famdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV69Configuracion_familiawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Configuracion_familiawwds_9_dynamicfiltersselector3, "FAMDSC") == 0 ) && ( AV71Configuracion_familiawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_familiawwds_11_famdsc3)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like '%' + @lV72Configuracion_familiawwds_11_famdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV73Configuracion_familiawwds_12_tffamcod) )
         {
            AddWhere(sWhereString, "([FamCod] >= @AV73Configuracion_familiawwds_12_tffamcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV74Configuracion_familiawwds_13_tffamcod_to) )
         {
            AddWhere(sWhereString, "([FamCod] <= @AV74Configuracion_familiawwds_13_tffamcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_familiawwds_15_tffamdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_familiawwds_14_tffamdsc)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV75Configuracion_familiawwds_14_tffamdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_familiawwds_15_tffamdsc_sel)) )
         {
            AddWhere(sWhereString, "([FamDsc] = @AV76Configuracion_familiawwds_15_tffamdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_familiawwds_17_tffamabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_familiawwds_16_tffamabr)) ) )
         {
            AddWhere(sWhereString, "([FamAbr] like @lV77Configuracion_familiawwds_16_tffamabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_familiawwds_17_tffamabr_sel)) )
         {
            AddWhere(sWhereString, "([FamAbr] = @AV78Configuracion_familiawwds_17_tffamabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV79Configuracion_familiawwds_18_tffamsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Configuracion_familiawwds_18_tffamsts_sels, "[FamSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [FamCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [FamCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [FamDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [FamDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [FamAbr]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [FamAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [FamSts]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [FamSts] DESC";
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
                     return conditional_P00302(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP00302;
          prmP00302 = new Object[] {
          new ParDef("@lV64Configuracion_familiawwds_3_famdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV64Configuracion_familiawwds_3_famdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_familiawwds_7_famdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_familiawwds_7_famdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_familiawwds_11_famdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_familiawwds_11_famdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_familiawwds_12_tffamcod",GXType.Int32,6,0) ,
          new ParDef("@AV74Configuracion_familiawwds_13_tffamcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV75Configuracion_familiawwds_14_tffamdsc",GXType.NChar,100,0) ,
          new ParDef("@AV76Configuracion_familiawwds_15_tffamdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV77Configuracion_familiawwds_16_tffamabr",GXType.NChar,5,0) ,
          new ParDef("@AV78Configuracion_familiawwds_17_tffamabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00302", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00302,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(5));
                return;
       }
    }

 }

}
