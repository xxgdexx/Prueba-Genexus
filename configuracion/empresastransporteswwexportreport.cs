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
   public class empresastransporteswwexportreport : GXWebProcedure
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

      public empresastransporteswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public empresastransporteswwexportreport( IGxContext context )
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
         empresastransporteswwexportreport objempresastransporteswwexportreport;
         objempresastransporteswwexportreport = new empresastransporteswwexportreport();
         objempresastransporteswwexportreport.context.SetSubmitInitialConfig(context);
         objempresastransporteswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objempresastransporteswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((empresastransporteswwexportreport)stateInfo).executePrivate();
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
            AV56Title = "Lista de Empresas de Transportes";
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
            H360( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "EMPTDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15EmpTDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15EmpTDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterEmpTDscDescription = StringUtil.Format( "%1 (%2)", "Empresa de Transporte", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterEmpTDscDescription = StringUtil.Format( "%1 (%2)", "Empresa de Transporte", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17EmpTDsc = AV15EmpTDsc1;
                  H360( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEmpTDscDescription, "")), 25, Gx_line+0, 258, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EmpTDsc, "")), 258, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "EMPTDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21EmpTDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21EmpTDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterEmpTDscDescription = StringUtil.Format( "%1 (%2)", "Empresa de Transporte", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterEmpTDscDescription = StringUtil.Format( "%1 (%2)", "Empresa de Transporte", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17EmpTDsc = AV21EmpTDsc2;
                     H360( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEmpTDscDescription, "")), 25, Gx_line+0, 258, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EmpTDsc, "")), 258, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "EMPTDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25EmpTDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25EmpTDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterEmpTDscDescription = StringUtil.Format( "%1 (%2)", "Empresa de Transporte", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterEmpTDscDescription = StringUtil.Format( "%1 (%2)", "Empresa de Transporte", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17EmpTDsc = AV25EmpTDsc3;
                        H360( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEmpTDscDescription, "")), 25, Gx_line+0, 258, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EmpTDsc, "")), 258, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFEmpTCod) && (0==AV32TFEmpTCod_To) ) )
         {
            H360( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 258, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFEmpTCod), "ZZZZZ9")), 258, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFEmpTCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H360( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFEmpTCod_To_Description, "")), 25, Gx_line+0, 258, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFEmpTCod_To), "ZZZZZ9")), 258, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFEmpTDsc_Sel)) )
         {
            H360( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Empresa de Transporte", 25, Gx_line+0, 258, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFEmpTDsc_Sel, "")), 258, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFEmpTDsc)) )
            {
               H360( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Empresa de Transporte", 25, Gx_line+0, 258, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFEmpTDsc, "")), 258, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFEmptDir_Sel)) )
         {
            H360( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Dirección", 25, Gx_line+0, 258, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFEmptDir_Sel, "")), 258, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFEmptDir)) )
            {
               H360( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Dirección", 25, Gx_line+0, 258, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFEmptDir, "")), 258, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEmpTRuc_Sel)) )
         {
            H360( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("R.U.C.", 25, Gx_line+0, 258, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFEmpTRuc_Sel, "")), 258, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFEmpTRuc)) )
            {
               H360( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("R.U.C.", 25, Gx_line+0, 258, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFEmpTRuc, "")), 258, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV41TFEmpTSts_Sels.FromJSonString(AV39TFEmpTSts_SelsJson, null);
         if ( ! ( AV41TFEmpTSts_Sels.Count == 0 ) )
         {
            AV45i = 1;
            AV62GXV1 = 1;
            while ( AV62GXV1 <= AV41TFEmpTSts_Sels.Count )
            {
               AV42TFEmpTSts_Sel = (short)(AV41TFEmpTSts_Sels.GetNumeric(AV62GXV1));
               if ( AV45i == 1 )
               {
                  AV40TFEmpTSts_SelDscs = "";
               }
               else
               {
                  AV40TFEmpTSts_SelDscs += ", ";
               }
               if ( AV42TFEmpTSts_Sel == 1 )
               {
                  AV44FilterTFEmpTSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV42TFEmpTSts_Sel == 0 )
               {
                  AV44FilterTFEmpTSts_SelValueDescription = "INACTIVO";
               }
               AV40TFEmpTSts_SelDscs += AV44FilterTFEmpTSts_SelValueDescription;
               AV45i = (long)(AV45i+1);
               AV62GXV1 = (int)(AV62GXV1+1);
            }
            H360( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 258, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFEmpTSts_SelDscs, "")), 258, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H360( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H360( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 112, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Empresa de Transporte", 116, Gx_line+10, 280, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Dirección", 284, Gx_line+10, 448, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("R.U.C.", 452, Gx_line+10, 617, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 621, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV64Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV65Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV66Configuracion_empresastransporteswwds_3_emptdsc1 = AV15EmpTDsc1;
         AV67Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV68Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV69Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV70Configuracion_empresastransporteswwds_7_emptdsc2 = AV21EmpTDsc2;
         AV71Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV72Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV73Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV74Configuracion_empresastransporteswwds_11_emptdsc3 = AV25EmpTDsc3;
         AV75Configuracion_empresastransporteswwds_12_tfemptcod = AV31TFEmpTCod;
         AV76Configuracion_empresastransporteswwds_13_tfemptcod_to = AV32TFEmpTCod_To;
         AV77Configuracion_empresastransporteswwds_14_tfemptdsc = AV33TFEmpTDsc;
         AV78Configuracion_empresastransporteswwds_15_tfemptdsc_sel = AV34TFEmpTDsc_Sel;
         AV79Configuracion_empresastransporteswwds_16_tfemptdir = AV35TFEmptDir;
         AV80Configuracion_empresastransporteswwds_17_tfemptdir_sel = AV36TFEmptDir_Sel;
         AV81Configuracion_empresastransporteswwds_18_tfemptruc = AV37TFEmpTRuc;
         AV82Configuracion_empresastransporteswwds_19_tfemptruc_sel = AV38TFEmpTRuc_Sel;
         AV83Configuracion_empresastransporteswwds_20_tfemptsts_sels = AV41TFEmpTSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A967EmpTSts ,
                                              AV83Configuracion_empresastransporteswwds_20_tfemptsts_sels ,
                                              AV64Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 ,
                                              AV65Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 ,
                                              AV66Configuracion_empresastransporteswwds_3_emptdsc1 ,
                                              AV67Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 ,
                                              AV68Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 ,
                                              AV69Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 ,
                                              AV70Configuracion_empresastransporteswwds_7_emptdsc2 ,
                                              AV71Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 ,
                                              AV72Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 ,
                                              AV73Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 ,
                                              AV74Configuracion_empresastransporteswwds_11_emptdsc3 ,
                                              AV75Configuracion_empresastransporteswwds_12_tfemptcod ,
                                              AV76Configuracion_empresastransporteswwds_13_tfemptcod_to ,
                                              AV78Configuracion_empresastransporteswwds_15_tfemptdsc_sel ,
                                              AV77Configuracion_empresastransporteswwds_14_tfemptdsc ,
                                              AV80Configuracion_empresastransporteswwds_17_tfemptdir_sel ,
                                              AV79Configuracion_empresastransporteswwds_16_tfemptdir ,
                                              AV82Configuracion_empresastransporteswwds_19_tfemptruc_sel ,
                                              AV81Configuracion_empresastransporteswwds_18_tfemptruc ,
                                              AV83Configuracion_empresastransporteswwds_20_tfemptsts_sels.Count ,
                                              A964EmpTDsc ,
                                              A17EmpTCod ,
                                              A963EmptDir ,
                                              A966EmpTRuc ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV66Configuracion_empresastransporteswwds_3_emptdsc1 = StringUtil.Concat( StringUtil.RTrim( AV66Configuracion_empresastransporteswwds_3_emptdsc1), "%", "");
         lV66Configuracion_empresastransporteswwds_3_emptdsc1 = StringUtil.Concat( StringUtil.RTrim( AV66Configuracion_empresastransporteswwds_3_emptdsc1), "%", "");
         lV70Configuracion_empresastransporteswwds_7_emptdsc2 = StringUtil.Concat( StringUtil.RTrim( AV70Configuracion_empresastransporteswwds_7_emptdsc2), "%", "");
         lV70Configuracion_empresastransporteswwds_7_emptdsc2 = StringUtil.Concat( StringUtil.RTrim( AV70Configuracion_empresastransporteswwds_7_emptdsc2), "%", "");
         lV74Configuracion_empresastransporteswwds_11_emptdsc3 = StringUtil.Concat( StringUtil.RTrim( AV74Configuracion_empresastransporteswwds_11_emptdsc3), "%", "");
         lV74Configuracion_empresastransporteswwds_11_emptdsc3 = StringUtil.Concat( StringUtil.RTrim( AV74Configuracion_empresastransporteswwds_11_emptdsc3), "%", "");
         lV77Configuracion_empresastransporteswwds_14_tfemptdsc = StringUtil.Concat( StringUtil.RTrim( AV77Configuracion_empresastransporteswwds_14_tfemptdsc), "%", "");
         lV79Configuracion_empresastransporteswwds_16_tfemptdir = StringUtil.Concat( StringUtil.RTrim( AV79Configuracion_empresastransporteswwds_16_tfemptdir), "%", "");
         lV81Configuracion_empresastransporteswwds_18_tfemptruc = StringUtil.Concat( StringUtil.RTrim( AV81Configuracion_empresastransporteswwds_18_tfemptruc), "%", "");
         /* Using cursor P00362 */
         pr_default.execute(0, new Object[] {lV66Configuracion_empresastransporteswwds_3_emptdsc1, lV66Configuracion_empresastransporteswwds_3_emptdsc1, lV70Configuracion_empresastransporteswwds_7_emptdsc2, lV70Configuracion_empresastransporteswwds_7_emptdsc2, lV74Configuracion_empresastransporteswwds_11_emptdsc3, lV74Configuracion_empresastransporteswwds_11_emptdsc3, AV75Configuracion_empresastransporteswwds_12_tfemptcod, AV76Configuracion_empresastransporteswwds_13_tfemptcod_to, lV77Configuracion_empresastransporteswwds_14_tfemptdsc, AV78Configuracion_empresastransporteswwds_15_tfemptdsc_sel, lV79Configuracion_empresastransporteswwds_16_tfemptdir, AV80Configuracion_empresastransporteswwds_17_tfemptdir_sel, lV81Configuracion_empresastransporteswwds_18_tfemptruc, AV82Configuracion_empresastransporteswwds_19_tfemptruc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A967EmpTSts = P00362_A967EmpTSts[0];
            A966EmpTRuc = P00362_A966EmpTRuc[0];
            A963EmptDir = P00362_A963EmptDir[0];
            A17EmpTCod = P00362_A17EmpTCod[0];
            A964EmpTDsc = P00362_A964EmpTDsc[0];
            if ( A967EmpTSts == 1 )
            {
               AV12EmpTStsDescription = "ACTIVO";
            }
            else if ( A967EmpTSts == 0 )
            {
               AV12EmpTStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H360( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A17EmpTCod), "ZZZZZ9")), 30, Gx_line+10, 112, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A964EmpTDsc, "")), 116, Gx_line+10, 280, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A963EmptDir, "")), 284, Gx_line+10, 448, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A966EmpTRuc, "")), 452, Gx_line+10, 617, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12EmpTStsDescription, "")), 621, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.EmpresasTransportesWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.EmpresasTransportesWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.EmpresasTransportesWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV84GXV2 = 1;
         while ( AV84GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV84GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPTCOD") == 0 )
            {
               AV31TFEmpTCod = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AV32TFEmpTCod_To = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPTDSC") == 0 )
            {
               AV33TFEmpTDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPTDSC_SEL") == 0 )
            {
               AV34TFEmpTDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPTDIR") == 0 )
            {
               AV35TFEmptDir = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPTDIR_SEL") == 0 )
            {
               AV36TFEmptDir_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPTRUC") == 0 )
            {
               AV37TFEmpTRuc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPTRUC_SEL") == 0 )
            {
               AV38TFEmpTRuc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPTSTS_SEL") == 0 )
            {
               AV39TFEmpTSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV41TFEmpTSts_Sels.FromJSonString(AV39TFEmpTSts_SelsJson, null);
            }
            AV84GXV2 = (int)(AV84GXV2+1);
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

      protected void H360( bool bFoot ,
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
                  AV54PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV51DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV49AppName = "DVelop Software Solutions";
               AV55Phone = "+1 550 8923";
               AV53Mail = "info@mail.com";
               AV57Website = "http://www.web.com";
               AV46AddressLine1 = "French Boulevard 2859";
               AV47AddressLine2 = "Downtown";
               AV48AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV56Title = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15EmpTDsc1 = "";
         AV16FilterEmpTDscDescription = "";
         AV17EmpTDsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21EmpTDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25EmpTDsc3 = "";
         AV43TFEmpTCod_To_Description = "";
         AV34TFEmpTDsc_Sel = "";
         AV33TFEmpTDsc = "";
         AV36TFEmptDir_Sel = "";
         AV35TFEmptDir = "";
         AV38TFEmpTRuc_Sel = "";
         AV37TFEmpTRuc = "";
         AV41TFEmpTSts_Sels = new GxSimpleCollection<short>();
         AV39TFEmpTSts_SelsJson = "";
         AV40TFEmpTSts_SelDscs = "";
         AV44FilterTFEmpTSts_SelValueDescription = "";
         AV64Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 = "";
         AV66Configuracion_empresastransporteswwds_3_emptdsc1 = "";
         AV68Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 = "";
         AV70Configuracion_empresastransporteswwds_7_emptdsc2 = "";
         AV72Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 = "";
         AV74Configuracion_empresastransporteswwds_11_emptdsc3 = "";
         AV77Configuracion_empresastransporteswwds_14_tfemptdsc = "";
         AV78Configuracion_empresastransporteswwds_15_tfemptdsc_sel = "";
         AV79Configuracion_empresastransporteswwds_16_tfemptdir = "";
         AV80Configuracion_empresastransporteswwds_17_tfemptdir_sel = "";
         AV81Configuracion_empresastransporteswwds_18_tfemptruc = "";
         AV82Configuracion_empresastransporteswwds_19_tfemptruc_sel = "";
         AV83Configuracion_empresastransporteswwds_20_tfemptsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV66Configuracion_empresastransporteswwds_3_emptdsc1 = "";
         lV70Configuracion_empresastransporteswwds_7_emptdsc2 = "";
         lV74Configuracion_empresastransporteswwds_11_emptdsc3 = "";
         lV77Configuracion_empresastransporteswwds_14_tfemptdsc = "";
         lV79Configuracion_empresastransporteswwds_16_tfemptdir = "";
         lV81Configuracion_empresastransporteswwds_18_tfemptruc = "";
         A964EmpTDsc = "";
         A963EmptDir = "";
         A966EmpTRuc = "";
         P00362_A967EmpTSts = new short[1] ;
         P00362_A966EmpTRuc = new string[] {""} ;
         P00362_A963EmptDir = new string[] {""} ;
         P00362_A17EmpTCod = new int[1] ;
         P00362_A964EmpTDsc = new string[] {""} ;
         AV12EmpTStsDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV54PageInfo = "";
         AV51DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV49AppName = "";
         AV55Phone = "";
         AV53Mail = "";
         AV57Website = "";
         AV46AddressLine1 = "";
         AV47AddressLine2 = "";
         AV48AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.empresastransporteswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00362_A967EmpTSts, P00362_A966EmpTRuc, P00362_A963EmptDir, P00362_A17EmpTCod, P00362_A964EmpTDsc
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
      private short AV42TFEmpTSts_Sel ;
      private short AV65Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 ;
      private short AV69Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 ;
      private short AV73Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 ;
      private short A967EmpTSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV31TFEmpTCod ;
      private int AV32TFEmpTCod_To ;
      private int AV62GXV1 ;
      private int AV75Configuracion_empresastransporteswwds_12_tfemptcod ;
      private int AV76Configuracion_empresastransporteswwds_13_tfemptcod_to ;
      private int AV83Configuracion_empresastransporteswwds_20_tfemptsts_sels_Count ;
      private int A17EmpTCod ;
      private int AV84GXV2 ;
      private long AV45i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV67Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 ;
      private bool AV71Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV39TFEmpTSts_SelsJson ;
      private string AV56Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15EmpTDsc1 ;
      private string AV16FilterEmpTDscDescription ;
      private string AV17EmpTDsc ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21EmpTDsc2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25EmpTDsc3 ;
      private string AV43TFEmpTCod_To_Description ;
      private string AV34TFEmpTDsc_Sel ;
      private string AV33TFEmpTDsc ;
      private string AV36TFEmptDir_Sel ;
      private string AV35TFEmptDir ;
      private string AV38TFEmpTRuc_Sel ;
      private string AV37TFEmpTRuc ;
      private string AV40TFEmpTSts_SelDscs ;
      private string AV44FilterTFEmpTSts_SelValueDescription ;
      private string AV64Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 ;
      private string AV66Configuracion_empresastransporteswwds_3_emptdsc1 ;
      private string AV68Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 ;
      private string AV70Configuracion_empresastransporteswwds_7_emptdsc2 ;
      private string AV72Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 ;
      private string AV74Configuracion_empresastransporteswwds_11_emptdsc3 ;
      private string AV77Configuracion_empresastransporteswwds_14_tfemptdsc ;
      private string AV78Configuracion_empresastransporteswwds_15_tfemptdsc_sel ;
      private string AV79Configuracion_empresastransporteswwds_16_tfemptdir ;
      private string AV80Configuracion_empresastransporteswwds_17_tfemptdir_sel ;
      private string AV81Configuracion_empresastransporteswwds_18_tfemptruc ;
      private string AV82Configuracion_empresastransporteswwds_19_tfemptruc_sel ;
      private string lV66Configuracion_empresastransporteswwds_3_emptdsc1 ;
      private string lV70Configuracion_empresastransporteswwds_7_emptdsc2 ;
      private string lV74Configuracion_empresastransporteswwds_11_emptdsc3 ;
      private string lV77Configuracion_empresastransporteswwds_14_tfemptdsc ;
      private string lV79Configuracion_empresastransporteswwds_16_tfemptdir ;
      private string lV81Configuracion_empresastransporteswwds_18_tfemptruc ;
      private string A964EmpTDsc ;
      private string A963EmptDir ;
      private string A966EmpTRuc ;
      private string AV12EmpTStsDescription ;
      private string AV54PageInfo ;
      private string AV51DateInfo ;
      private string AV49AppName ;
      private string AV55Phone ;
      private string AV53Mail ;
      private string AV57Website ;
      private string AV46AddressLine1 ;
      private string AV47AddressLine2 ;
      private string AV48AddressLine3 ;
      private GxSimpleCollection<short> AV41TFEmpTSts_Sels ;
      private GxSimpleCollection<short> AV83Configuracion_empresastransporteswwds_20_tfemptsts_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00362_A967EmpTSts ;
      private string[] P00362_A966EmpTRuc ;
      private string[] P00362_A963EmptDir ;
      private int[] P00362_A17EmpTCod ;
      private string[] P00362_A964EmpTDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class empresastransporteswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00362( IGxContext context ,
                                             short A967EmpTSts ,
                                             GxSimpleCollection<short> AV83Configuracion_empresastransporteswwds_20_tfemptsts_sels ,
                                             string AV64Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 ,
                                             short AV65Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 ,
                                             string AV66Configuracion_empresastransporteswwds_3_emptdsc1 ,
                                             bool AV67Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 ,
                                             string AV68Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 ,
                                             short AV69Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 ,
                                             string AV70Configuracion_empresastransporteswwds_7_emptdsc2 ,
                                             bool AV71Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 ,
                                             string AV72Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 ,
                                             short AV73Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 ,
                                             string AV74Configuracion_empresastransporteswwds_11_emptdsc3 ,
                                             int AV75Configuracion_empresastransporteswwds_12_tfemptcod ,
                                             int AV76Configuracion_empresastransporteswwds_13_tfemptcod_to ,
                                             string AV78Configuracion_empresastransporteswwds_15_tfemptdsc_sel ,
                                             string AV77Configuracion_empresastransporteswwds_14_tfemptdsc ,
                                             string AV80Configuracion_empresastransporteswwds_17_tfemptdir_sel ,
                                             string AV79Configuracion_empresastransporteswwds_16_tfemptdir ,
                                             string AV82Configuracion_empresastransporteswwds_19_tfemptruc_sel ,
                                             string AV81Configuracion_empresastransporteswwds_18_tfemptruc ,
                                             int AV83Configuracion_empresastransporteswwds_20_tfemptsts_sels_Count ,
                                             string A964EmpTDsc ,
                                             int A17EmpTCod ,
                                             string A963EmptDir ,
                                             string A966EmpTRuc ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [EmpTSts], [EmpTRuc], [EmptDir], [EmpTCod], [EmpTDsc] FROM [CEMPTRANSPORTE]";
         if ( ( StringUtil.StrCmp(AV64Configuracion_empresastransporteswwds_1_dynamicfiltersselector1, "EMPTDSC") == 0 ) && ( AV65Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_empresastransporteswwds_3_emptdsc1)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV66Configuracion_empresastransporteswwds_3_emptdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Configuracion_empresastransporteswwds_1_dynamicfiltersselector1, "EMPTDSC") == 0 ) && ( AV65Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_empresastransporteswwds_3_emptdsc1)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV66Configuracion_empresastransporteswwds_3_emptdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV67Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Configuracion_empresastransporteswwds_5_dynamicfiltersselector2, "EMPTDSC") == 0 ) && ( AV69Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_empresastransporteswwds_7_emptdsc2)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV70Configuracion_empresastransporteswwds_7_emptdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV67Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Configuracion_empresastransporteswwds_5_dynamicfiltersselector2, "EMPTDSC") == 0 ) && ( AV69Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_empresastransporteswwds_7_emptdsc2)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV70Configuracion_empresastransporteswwds_7_emptdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV71Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Configuracion_empresastransporteswwds_9_dynamicfiltersselector3, "EMPTDSC") == 0 ) && ( AV73Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_empresastransporteswwds_11_emptdsc3)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV74Configuracion_empresastransporteswwds_11_emptdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV71Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Configuracion_empresastransporteswwds_9_dynamicfiltersselector3, "EMPTDSC") == 0 ) && ( AV73Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_empresastransporteswwds_11_emptdsc3)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV74Configuracion_empresastransporteswwds_11_emptdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV75Configuracion_empresastransporteswwds_12_tfemptcod) )
         {
            AddWhere(sWhereString, "([EmpTCod] >= @AV75Configuracion_empresastransporteswwds_12_tfemptcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV76Configuracion_empresastransporteswwds_13_tfemptcod_to) )
         {
            AddWhere(sWhereString, "([EmpTCod] <= @AV76Configuracion_empresastransporteswwds_13_tfemptcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_empresastransporteswwds_15_tfemptdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_empresastransporteswwds_14_tfemptdsc)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV77Configuracion_empresastransporteswwds_14_tfemptdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_empresastransporteswwds_15_tfemptdsc_sel)) )
         {
            AddWhere(sWhereString, "([EmpTDsc] = @AV78Configuracion_empresastransporteswwds_15_tfemptdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_empresastransporteswwds_17_tfemptdir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_empresastransporteswwds_16_tfemptdir)) ) )
         {
            AddWhere(sWhereString, "([EmptDir] like @lV79Configuracion_empresastransporteswwds_16_tfemptdir)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_empresastransporteswwds_17_tfemptdir_sel)) )
         {
            AddWhere(sWhereString, "([EmptDir] = @AV80Configuracion_empresastransporteswwds_17_tfemptdir_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_empresastransporteswwds_19_tfemptruc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_empresastransporteswwds_18_tfemptruc)) ) )
         {
            AddWhere(sWhereString, "([EmpTRuc] like @lV81Configuracion_empresastransporteswwds_18_tfemptruc)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_empresastransporteswwds_19_tfemptruc_sel)) )
         {
            AddWhere(sWhereString, "([EmpTRuc] = @AV82Configuracion_empresastransporteswwds_19_tfemptruc_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV83Configuracion_empresastransporteswwds_20_tfemptsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Configuracion_empresastransporteswwds_20_tfemptsts_sels, "[EmpTSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [EmpTCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EmpTCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [EmpTDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EmpTDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [EmptDir]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EmptDir] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [EmpTRuc]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EmpTRuc] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [EmpTSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EmpTSts] DESC";
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
                     return conditional_P00362(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP00362;
          prmP00362 = new Object[] {
          new ParDef("@lV66Configuracion_empresastransporteswwds_3_emptdsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV66Configuracion_empresastransporteswwds_3_emptdsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV70Configuracion_empresastransporteswwds_7_emptdsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV70Configuracion_empresastransporteswwds_7_emptdsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV74Configuracion_empresastransporteswwds_11_emptdsc3",GXType.NVarChar,100,0) ,
          new ParDef("@lV74Configuracion_empresastransporteswwds_11_emptdsc3",GXType.NVarChar,100,0) ,
          new ParDef("@AV75Configuracion_empresastransporteswwds_12_tfemptcod",GXType.Int32,6,0) ,
          new ParDef("@AV76Configuracion_empresastransporteswwds_13_tfemptcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV77Configuracion_empresastransporteswwds_14_tfemptdsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV78Configuracion_empresastransporteswwds_15_tfemptdsc_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV79Configuracion_empresastransporteswwds_16_tfemptdir",GXType.NVarChar,100,0) ,
          new ParDef("@AV80Configuracion_empresastransporteswwds_17_tfemptdir_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV81Configuracion_empresastransporteswwds_18_tfemptruc",GXType.NVarChar,20,0) ,
          new ParDef("@AV82Configuracion_empresastransporteswwds_19_tfemptruc_sel",GXType.NVarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00362", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00362,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
