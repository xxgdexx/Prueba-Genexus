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
   public class tipodocumentowwexportreport : GXWebProcedure
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

      public tipodocumentowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipodocumentowwexportreport( IGxContext context )
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
         tipodocumentowwexportreport objtipodocumentowwexportreport;
         objtipodocumentowwexportreport = new tipodocumentowwexportreport();
         objtipodocumentowwexportreport.context.SetSubmitInitialConfig(context);
         objtipodocumentowwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipodocumentowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipodocumentowwexportreport)stateInfo).executePrivate();
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
            AV67Title = "Lista de Tipo Documento";
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
            H4B0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "TIPDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV14TipDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TipDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterTipDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Documento", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterTipDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Documento", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16TipDsc = AV14TipDsc1;
                  H4B0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterTipDscDescription, "")), 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TipDsc, "")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "TIPABR") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV81TipAbr1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TipAbr1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV82FilterTipAbrDescription = StringUtil.Format( "%1 (%2)", "Codigo Sunat", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV82FilterTipAbrDescription = StringUtil.Format( "%1 (%2)", "Codigo Sunat", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV83TipAbr = AV81TipAbr1;
                  H4B0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82FilterTipAbrDescription, "")), 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83TipAbr, "")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "TIPDSC") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV20TipDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TipDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterTipDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Documento", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterTipDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Documento", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16TipDsc = AV20TipDsc2;
                     H4B0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterTipDscDescription, "")), 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TipDsc, "")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "TIPABR") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV84TipAbr2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84TipAbr2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV82FilterTipAbrDescription = StringUtil.Format( "%1 (%2)", "Codigo Sunat", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV82FilterTipAbrDescription = StringUtil.Format( "%1 (%2)", "Codigo Sunat", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV83TipAbr = AV84TipAbr2;
                     H4B0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82FilterTipAbrDescription, "")), 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83TipAbr, "")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "TIPDSC") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV24TipDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TipDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterTipDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Documento", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterTipDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Documento", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16TipDsc = AV24TipDsc3;
                        H4B0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterTipDscDescription, "")), 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TipDsc, "")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "TIPABR") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV85TipAbr3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85TipAbr3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV82FilterTipAbrDescription = StringUtil.Format( "%1 (%2)", "Codigo Sunat", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV82FilterTipAbrDescription = StringUtil.Format( "%1 (%2)", "Codigo Sunat", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV83TipAbr = AV85TipAbr3;
                        H4B0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82FilterTipAbrDescription, "")), 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83TipAbr, "")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFTipAbr_Sel)) )
         {
            H4B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Sunat", 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFTipAbr_Sel, "")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTipAbr)) )
            {
               H4B0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo Sunat", 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFTipAbr, "")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTipDsc_Sel)) )
         {
            H4B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo de Documento", 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFTipDsc_Sel, "")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFTipDsc)) )
            {
               H4B0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo de Documento", 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFTipDsc, "")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV70TFTipVta_Sel) )
         {
            H4B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Afecta Registro Venta", 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV70TFTipVta_Sel), "9")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV71TFTipCmp_Sel) )
         {
            H4B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Afecta Registro Compra", 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV71TFTipCmp_Sel), "9")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV72TFTipRHo_Sel) )
         {
            H4B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Afecta Honorarios", 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV72TFTipRHo_Sel), "9")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV73TFTipCxP_Sel) )
         {
            H4B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Afecta Cuenta x Pagar", 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV73TFTipCxP_Sel), "9")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV74TFTipBan_Sel) )
         {
            H4B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Afecta Bancos", 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV74TFTipBan_Sel), "9")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV77TFTipSts_Sels.FromJSonString(AV75TFTipSts_SelsJson, null);
         if ( ! ( AV77TFTipSts_Sels.Count == 0 ) )
         {
            AV80i = 1;
            AV90GXV1 = 1;
            while ( AV90GXV1 <= AV77TFTipSts_Sels.Count )
            {
               AV78TFTipSts_Sel = (short)(AV77TFTipSts_Sels.GetNumeric(AV90GXV1));
               if ( AV80i == 1 )
               {
                  AV76TFTipSts_SelDscs = "";
               }
               else
               {
                  AV76TFTipSts_SelDscs += ", ";
               }
               if ( AV78TFTipSts_Sel == 1 )
               {
                  AV79FilterTFTipSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV78TFTipSts_Sel == 0 )
               {
                  AV79FilterTFTipSts_SelValueDescription = "INACTIVO";
               }
               AV76TFTipSts_SelDscs += AV79FilterTFTipSts_SelValueDescription;
               AV80i = (long)(AV80i+1);
               AV90GXV1 = (int)(AV90GXV1+1);
            }
            H4B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 241, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76TFTipSts_SelDscs, "")), 241, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4B0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4B0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo Sunat", 30, Gx_line+10, 102, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo de Documento", 106, Gx_line+10, 252, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Afecta Registro Venta", 256, Gx_line+10, 329, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Afecta Registro Compra", 333, Gx_line+10, 406, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Afecta Honorarios", 410, Gx_line+10, 483, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Afecta Cuenta x Pagar", 487, Gx_line+10, 560, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Afecta Bancos", 564, Gx_line+10, 637, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 641, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV92Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV93Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV94Configuracion_tipodocumentowwds_3_tipdsc1 = AV14TipDsc1;
         AV95Configuracion_tipodocumentowwds_4_tipabr1 = AV81TipAbr1;
         AV96Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV97Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV98Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV99Configuracion_tipodocumentowwds_8_tipdsc2 = AV20TipDsc2;
         AV100Configuracion_tipodocumentowwds_9_tipabr2 = AV84TipAbr2;
         AV101Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV102Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV103Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV104Configuracion_tipodocumentowwds_13_tipdsc3 = AV24TipDsc3;
         AV105Configuracion_tipodocumentowwds_14_tipabr3 = AV85TipAbr3;
         AV106Configuracion_tipodocumentowwds_15_tftipabr = AV34TFTipAbr;
         AV107Configuracion_tipodocumentowwds_16_tftipabr_sel = AV35TFTipAbr_Sel;
         AV108Configuracion_tipodocumentowwds_17_tftipdsc = AV32TFTipDsc;
         AV109Configuracion_tipodocumentowwds_18_tftipdsc_sel = AV33TFTipDsc_Sel;
         AV110Configuracion_tipodocumentowwds_19_tftipvta_sel = AV70TFTipVta_Sel;
         AV111Configuracion_tipodocumentowwds_20_tftipcmp_sel = AV71TFTipCmp_Sel;
         AV112Configuracion_tipodocumentowwds_21_tftiprho_sel = AV72TFTipRHo_Sel;
         AV113Configuracion_tipodocumentowwds_22_tftipcxp_sel = AV73TFTipCxP_Sel;
         AV114Configuracion_tipodocumentowwds_23_tftipban_sel = AV74TFTipBan_Sel;
         AV115Configuracion_tipodocumentowwds_24_tftipsts_sels = AV77TFTipSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1919TipSts ,
                                              AV115Configuracion_tipodocumentowwds_24_tftipsts_sels ,
                                              AV92Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ,
                                              AV93Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ,
                                              AV94Configuracion_tipodocumentowwds_3_tipdsc1 ,
                                              AV95Configuracion_tipodocumentowwds_4_tipabr1 ,
                                              AV96Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ,
                                              AV97Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ,
                                              AV98Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ,
                                              AV99Configuracion_tipodocumentowwds_8_tipdsc2 ,
                                              AV100Configuracion_tipodocumentowwds_9_tipabr2 ,
                                              AV101Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ,
                                              AV102Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ,
                                              AV103Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ,
                                              AV104Configuracion_tipodocumentowwds_13_tipdsc3 ,
                                              AV105Configuracion_tipodocumentowwds_14_tipabr3 ,
                                              AV107Configuracion_tipodocumentowwds_16_tftipabr_sel ,
                                              AV106Configuracion_tipodocumentowwds_15_tftipabr ,
                                              AV109Configuracion_tipodocumentowwds_18_tftipdsc_sel ,
                                              AV108Configuracion_tipodocumentowwds_17_tftipdsc ,
                                              AV110Configuracion_tipodocumentowwds_19_tftipvta_sel ,
                                              AV111Configuracion_tipodocumentowwds_20_tftipcmp_sel ,
                                              AV112Configuracion_tipodocumentowwds_21_tftiprho_sel ,
                                              AV113Configuracion_tipodocumentowwds_22_tftipcxp_sel ,
                                              AV114Configuracion_tipodocumentowwds_23_tftipban_sel ,
                                              AV115Configuracion_tipodocumentowwds_24_tftipsts_sels.Count ,
                                              A1910TipDsc ,
                                              A306TipAbr ,
                                              A1921TipVta ,
                                              A1906TipCmp ,
                                              A1915TipRHo ,
                                              A1909TipCxP ,
                                              A1903TipBan ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV94Configuracion_tipodocumentowwds_3_tipdsc1 = StringUtil.PadR( StringUtil.RTrim( AV94Configuracion_tipodocumentowwds_3_tipdsc1), 100, "%");
         lV94Configuracion_tipodocumentowwds_3_tipdsc1 = StringUtil.PadR( StringUtil.RTrim( AV94Configuracion_tipodocumentowwds_3_tipdsc1), 100, "%");
         lV95Configuracion_tipodocumentowwds_4_tipabr1 = StringUtil.PadR( StringUtil.RTrim( AV95Configuracion_tipodocumentowwds_4_tipabr1), 5, "%");
         lV95Configuracion_tipodocumentowwds_4_tipabr1 = StringUtil.PadR( StringUtil.RTrim( AV95Configuracion_tipodocumentowwds_4_tipabr1), 5, "%");
         lV99Configuracion_tipodocumentowwds_8_tipdsc2 = StringUtil.PadR( StringUtil.RTrim( AV99Configuracion_tipodocumentowwds_8_tipdsc2), 100, "%");
         lV99Configuracion_tipodocumentowwds_8_tipdsc2 = StringUtil.PadR( StringUtil.RTrim( AV99Configuracion_tipodocumentowwds_8_tipdsc2), 100, "%");
         lV100Configuracion_tipodocumentowwds_9_tipabr2 = StringUtil.PadR( StringUtil.RTrim( AV100Configuracion_tipodocumentowwds_9_tipabr2), 5, "%");
         lV100Configuracion_tipodocumentowwds_9_tipabr2 = StringUtil.PadR( StringUtil.RTrim( AV100Configuracion_tipodocumentowwds_9_tipabr2), 5, "%");
         lV104Configuracion_tipodocumentowwds_13_tipdsc3 = StringUtil.PadR( StringUtil.RTrim( AV104Configuracion_tipodocumentowwds_13_tipdsc3), 100, "%");
         lV104Configuracion_tipodocumentowwds_13_tipdsc3 = StringUtil.PadR( StringUtil.RTrim( AV104Configuracion_tipodocumentowwds_13_tipdsc3), 100, "%");
         lV105Configuracion_tipodocumentowwds_14_tipabr3 = StringUtil.PadR( StringUtil.RTrim( AV105Configuracion_tipodocumentowwds_14_tipabr3), 5, "%");
         lV105Configuracion_tipodocumentowwds_14_tipabr3 = StringUtil.PadR( StringUtil.RTrim( AV105Configuracion_tipodocumentowwds_14_tipabr3), 5, "%");
         lV106Configuracion_tipodocumentowwds_15_tftipabr = StringUtil.PadR( StringUtil.RTrim( AV106Configuracion_tipodocumentowwds_15_tftipabr), 5, "%");
         lV108Configuracion_tipodocumentowwds_17_tftipdsc = StringUtil.PadR( StringUtil.RTrim( AV108Configuracion_tipodocumentowwds_17_tftipdsc), 100, "%");
         /* Using cursor P004B2 */
         pr_default.execute(0, new Object[] {lV94Configuracion_tipodocumentowwds_3_tipdsc1, lV94Configuracion_tipodocumentowwds_3_tipdsc1, lV95Configuracion_tipodocumentowwds_4_tipabr1, lV95Configuracion_tipodocumentowwds_4_tipabr1, lV99Configuracion_tipodocumentowwds_8_tipdsc2, lV99Configuracion_tipodocumentowwds_8_tipdsc2, lV100Configuracion_tipodocumentowwds_9_tipabr2, lV100Configuracion_tipodocumentowwds_9_tipabr2, lV104Configuracion_tipodocumentowwds_13_tipdsc3, lV104Configuracion_tipodocumentowwds_13_tipdsc3, lV105Configuracion_tipodocumentowwds_14_tipabr3, lV105Configuracion_tipodocumentowwds_14_tipabr3, lV106Configuracion_tipodocumentowwds_15_tftipabr, AV107Configuracion_tipodocumentowwds_16_tftipabr_sel, lV108Configuracion_tipodocumentowwds_17_tftipdsc, AV109Configuracion_tipodocumentowwds_18_tftipdsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1919TipSts = P004B2_A1919TipSts[0];
            A1903TipBan = P004B2_A1903TipBan[0];
            A1909TipCxP = P004B2_A1909TipCxP[0];
            A1915TipRHo = P004B2_A1915TipRHo[0];
            A1906TipCmp = P004B2_A1906TipCmp[0];
            A1921TipVta = P004B2_A1921TipVta[0];
            A306TipAbr = P004B2_A306TipAbr[0];
            A1910TipDsc = P004B2_A1910TipDsc[0];
            A149TipCod = P004B2_A149TipCod[0];
            if ( A1919TipSts == 1 )
            {
               AV69TipStsDescription = "ACTIVO";
            }
            else if ( A1919TipSts == 0 )
            {
               AV69TipStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H4B0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 30, Gx_line+10, 102, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1910TipDsc, "")), 106, Gx_line+10, 252, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1921TipVta), "9")), 256, Gx_line+10, 329, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1906TipCmp), "9")), 333, Gx_line+10, 406, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1915TipRHo), "9")), 410, Gx_line+10, 483, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1909TipCxP), "9")), 487, Gx_line+10, 560, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1903TipBan), "9")), 564, Gx_line+10, 637, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TipStsDescription, "")), 641, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Configuracion.TipoDocumentoWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoDocumentoWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Configuracion.TipoDocumentoWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV116GXV2 = 1;
         while ( AV116GXV2 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV116GXV2));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIPABR") == 0 )
            {
               AV34TFTipAbr = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIPABR_SEL") == 0 )
            {
               AV35TFTipAbr_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIPDSC") == 0 )
            {
               AV32TFTipDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIPDSC_SEL") == 0 )
            {
               AV33TFTipDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIPVTA_SEL") == 0 )
            {
               AV70TFTipVta_Sel = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIPCMP_SEL") == 0 )
            {
               AV71TFTipCmp_Sel = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIPRHO_SEL") == 0 )
            {
               AV72TFTipRHo_Sel = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIPCXP_SEL") == 0 )
            {
               AV73TFTipCxP_Sel = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIPBAN_SEL") == 0 )
            {
               AV74TFTipBan_Sel = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIPSTS_SEL") == 0 )
            {
               AV75TFTipSts_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV77TFTipSts_Sels.FromJSonString(AV75TFTipSts_SelsJson, null);
            }
            AV116GXV2 = (int)(AV116GXV2+1);
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

      protected void H4B0( bool bFoot ,
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
                  AV65PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV62DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV60AppName = "DVelop Software Solutions";
               AV66Phone = "+1 550 8923";
               AV64Mail = "info@mail.com";
               AV68Website = "http://www.web.com";
               AV57AddressLine1 = "French Boulevard 2859";
               AV58AddressLine2 = "Downtown";
               AV59AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV67Title = "";
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV25GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14TipDsc1 = "";
         AV15FilterTipDscDescription = "";
         AV16TipDsc = "";
         AV81TipAbr1 = "";
         AV82FilterTipAbrDescription = "";
         AV83TipAbr = "";
         AV18DynamicFiltersSelector2 = "";
         AV20TipDsc2 = "";
         AV84TipAbr2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV24TipDsc3 = "";
         AV85TipAbr3 = "";
         AV35TFTipAbr_Sel = "";
         AV34TFTipAbr = "";
         AV33TFTipDsc_Sel = "";
         AV32TFTipDsc = "";
         AV77TFTipSts_Sels = new GxSimpleCollection<short>();
         AV75TFTipSts_SelsJson = "";
         AV76TFTipSts_SelDscs = "";
         AV79FilterTFTipSts_SelValueDescription = "";
         AV92Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = "";
         AV94Configuracion_tipodocumentowwds_3_tipdsc1 = "";
         AV95Configuracion_tipodocumentowwds_4_tipabr1 = "";
         AV97Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = "";
         AV99Configuracion_tipodocumentowwds_8_tipdsc2 = "";
         AV100Configuracion_tipodocumentowwds_9_tipabr2 = "";
         AV102Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = "";
         AV104Configuracion_tipodocumentowwds_13_tipdsc3 = "";
         AV105Configuracion_tipodocumentowwds_14_tipabr3 = "";
         AV106Configuracion_tipodocumentowwds_15_tftipabr = "";
         AV107Configuracion_tipodocumentowwds_16_tftipabr_sel = "";
         AV108Configuracion_tipodocumentowwds_17_tftipdsc = "";
         AV109Configuracion_tipodocumentowwds_18_tftipdsc_sel = "";
         AV115Configuracion_tipodocumentowwds_24_tftipsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV94Configuracion_tipodocumentowwds_3_tipdsc1 = "";
         lV95Configuracion_tipodocumentowwds_4_tipabr1 = "";
         lV99Configuracion_tipodocumentowwds_8_tipdsc2 = "";
         lV100Configuracion_tipodocumentowwds_9_tipabr2 = "";
         lV104Configuracion_tipodocumentowwds_13_tipdsc3 = "";
         lV105Configuracion_tipodocumentowwds_14_tipabr3 = "";
         lV106Configuracion_tipodocumentowwds_15_tftipabr = "";
         lV108Configuracion_tipodocumentowwds_17_tftipdsc = "";
         A1910TipDsc = "";
         A306TipAbr = "";
         P004B2_A1919TipSts = new short[1] ;
         P004B2_A1903TipBan = new short[1] ;
         P004B2_A1909TipCxP = new short[1] ;
         P004B2_A1915TipRHo = new short[1] ;
         P004B2_A1906TipCmp = new short[1] ;
         P004B2_A1921TipVta = new short[1] ;
         P004B2_A306TipAbr = new string[] {""} ;
         P004B2_A1910TipDsc = new string[] {""} ;
         P004B2_A149TipCod = new string[] {""} ;
         A149TipCod = "";
         AV69TipStsDescription = "";
         AV26Session = context.GetSession();
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV65PageInfo = "";
         AV62DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV60AppName = "";
         AV66Phone = "";
         AV64Mail = "";
         AV68Website = "";
         AV57AddressLine1 = "";
         AV58AddressLine2 = "";
         AV59AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipodocumentowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004B2_A1919TipSts, P004B2_A1903TipBan, P004B2_A1909TipCxP, P004B2_A1915TipRHo, P004B2_A1906TipCmp, P004B2_A1921TipVta, P004B2_A306TipAbr, P004B2_A1910TipDsc, P004B2_A149TipCod
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
      private short AV70TFTipVta_Sel ;
      private short AV71TFTipCmp_Sel ;
      private short AV72TFTipRHo_Sel ;
      private short AV73TFTipCxP_Sel ;
      private short AV74TFTipBan_Sel ;
      private short AV78TFTipSts_Sel ;
      private short AV93Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ;
      private short AV98Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ;
      private short AV103Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ;
      private short AV110Configuracion_tipodocumentowwds_19_tftipvta_sel ;
      private short AV111Configuracion_tipodocumentowwds_20_tftipcmp_sel ;
      private short AV112Configuracion_tipodocumentowwds_21_tftiprho_sel ;
      private short AV113Configuracion_tipodocumentowwds_22_tftipcxp_sel ;
      private short AV114Configuracion_tipodocumentowwds_23_tftipban_sel ;
      private short A1919TipSts ;
      private short A1921TipVta ;
      private short A1906TipCmp ;
      private short A1915TipRHo ;
      private short A1909TipCxP ;
      private short A1903TipBan ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV90GXV1 ;
      private int AV115Configuracion_tipodocumentowwds_24_tftipsts_sels_Count ;
      private int AV116GXV2 ;
      private long AV80i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14TipDsc1 ;
      private string AV16TipDsc ;
      private string AV81TipAbr1 ;
      private string AV83TipAbr ;
      private string AV20TipDsc2 ;
      private string AV84TipAbr2 ;
      private string AV24TipDsc3 ;
      private string AV85TipAbr3 ;
      private string AV35TFTipAbr_Sel ;
      private string AV34TFTipAbr ;
      private string AV33TFTipDsc_Sel ;
      private string AV32TFTipDsc ;
      private string AV94Configuracion_tipodocumentowwds_3_tipdsc1 ;
      private string AV95Configuracion_tipodocumentowwds_4_tipabr1 ;
      private string AV99Configuracion_tipodocumentowwds_8_tipdsc2 ;
      private string AV100Configuracion_tipodocumentowwds_9_tipabr2 ;
      private string AV104Configuracion_tipodocumentowwds_13_tipdsc3 ;
      private string AV105Configuracion_tipodocumentowwds_14_tipabr3 ;
      private string AV106Configuracion_tipodocumentowwds_15_tftipabr ;
      private string AV107Configuracion_tipodocumentowwds_16_tftipabr_sel ;
      private string AV108Configuracion_tipodocumentowwds_17_tftipdsc ;
      private string AV109Configuracion_tipodocumentowwds_18_tftipdsc_sel ;
      private string scmdbuf ;
      private string lV94Configuracion_tipodocumentowwds_3_tipdsc1 ;
      private string lV95Configuracion_tipodocumentowwds_4_tipabr1 ;
      private string lV99Configuracion_tipodocumentowwds_8_tipdsc2 ;
      private string lV100Configuracion_tipodocumentowwds_9_tipabr2 ;
      private string lV104Configuracion_tipodocumentowwds_13_tipdsc3 ;
      private string lV105Configuracion_tipodocumentowwds_14_tipabr3 ;
      private string lV106Configuracion_tipodocumentowwds_15_tftipabr ;
      private string lV108Configuracion_tipodocumentowwds_17_tftipdsc ;
      private string A1910TipDsc ;
      private string A306TipAbr ;
      private string A149TipCod ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV96Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ;
      private bool AV101Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV75TFTipSts_SelsJson ;
      private string AV67Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterTipDscDescription ;
      private string AV82FilterTipAbrDescription ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV76TFTipSts_SelDscs ;
      private string AV79FilterTFTipSts_SelValueDescription ;
      private string AV92Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ;
      private string AV97Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ;
      private string AV102Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ;
      private string AV69TipStsDescription ;
      private string AV65PageInfo ;
      private string AV62DateInfo ;
      private string AV60AppName ;
      private string AV66Phone ;
      private string AV64Mail ;
      private string AV68Website ;
      private string AV57AddressLine1 ;
      private string AV58AddressLine2 ;
      private string AV59AddressLine3 ;
      private GxSimpleCollection<short> AV77TFTipSts_Sels ;
      private GxSimpleCollection<short> AV115Configuracion_tipodocumentowwds_24_tftipsts_sels ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P004B2_A1919TipSts ;
      private short[] P004B2_A1903TipBan ;
      private short[] P004B2_A1909TipCxP ;
      private short[] P004B2_A1915TipRHo ;
      private short[] P004B2_A1906TipCmp ;
      private short[] P004B2_A1921TipVta ;
      private string[] P004B2_A306TipAbr ;
      private string[] P004B2_A1910TipDsc ;
      private string[] P004B2_A149TipCod ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class tipodocumentowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004B2( IGxContext context ,
                                             short A1919TipSts ,
                                             GxSimpleCollection<short> AV115Configuracion_tipodocumentowwds_24_tftipsts_sels ,
                                             string AV92Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ,
                                             short AV93Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ,
                                             string AV94Configuracion_tipodocumentowwds_3_tipdsc1 ,
                                             string AV95Configuracion_tipodocumentowwds_4_tipabr1 ,
                                             bool AV96Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ,
                                             string AV97Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ,
                                             short AV98Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ,
                                             string AV99Configuracion_tipodocumentowwds_8_tipdsc2 ,
                                             string AV100Configuracion_tipodocumentowwds_9_tipabr2 ,
                                             bool AV101Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ,
                                             string AV102Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ,
                                             short AV103Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ,
                                             string AV104Configuracion_tipodocumentowwds_13_tipdsc3 ,
                                             string AV105Configuracion_tipodocumentowwds_14_tipabr3 ,
                                             string AV107Configuracion_tipodocumentowwds_16_tftipabr_sel ,
                                             string AV106Configuracion_tipodocumentowwds_15_tftipabr ,
                                             string AV109Configuracion_tipodocumentowwds_18_tftipdsc_sel ,
                                             string AV108Configuracion_tipodocumentowwds_17_tftipdsc ,
                                             short AV110Configuracion_tipodocumentowwds_19_tftipvta_sel ,
                                             short AV111Configuracion_tipodocumentowwds_20_tftipcmp_sel ,
                                             short AV112Configuracion_tipodocumentowwds_21_tftiprho_sel ,
                                             short AV113Configuracion_tipodocumentowwds_22_tftipcxp_sel ,
                                             short AV114Configuracion_tipodocumentowwds_23_tftipban_sel ,
                                             int AV115Configuracion_tipodocumentowwds_24_tftipsts_sels_Count ,
                                             string A1910TipDsc ,
                                             string A306TipAbr ,
                                             short A1921TipVta ,
                                             short A1906TipCmp ,
                                             short A1915TipRHo ,
                                             short A1909TipCxP ,
                                             short A1903TipBan ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TipSts], [TipBan], [TipCxP], [TipRHo], [TipCmp], [TipVta], [TipAbr], [TipDsc], [TipCod] FROM [CTIPDOC]";
         if ( ( StringUtil.StrCmp(AV92Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPDSC") == 0 ) && ( AV93Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Configuracion_tipodocumentowwds_3_tipdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV94Configuracion_tipodocumentowwds_3_tipdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPDSC") == 0 ) && ( AV93Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Configuracion_tipodocumentowwds_3_tipdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV94Configuracion_tipodocumentowwds_3_tipdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPABR") == 0 ) && ( AV93Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_tipodocumentowwds_4_tipabr1)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV95Configuracion_tipodocumentowwds_4_tipabr1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPABR") == 0 ) && ( AV93Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_tipodocumentowwds_4_tipabr1)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV95Configuracion_tipodocumentowwds_4_tipabr1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV96Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPDSC") == 0 ) && ( AV98Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_tipodocumentowwds_8_tipdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV99Configuracion_tipodocumentowwds_8_tipdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV96Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPDSC") == 0 ) && ( AV98Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_tipodocumentowwds_8_tipdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV99Configuracion_tipodocumentowwds_8_tipdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV96Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPABR") == 0 ) && ( AV98Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Configuracion_tipodocumentowwds_9_tipabr2)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV100Configuracion_tipodocumentowwds_9_tipabr2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV96Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPABR") == 0 ) && ( AV98Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Configuracion_tipodocumentowwds_9_tipabr2)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV100Configuracion_tipodocumentowwds_9_tipabr2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV101Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPDSC") == 0 ) && ( AV103Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Configuracion_tipodocumentowwds_13_tipdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV104Configuracion_tipodocumentowwds_13_tipdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV101Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPDSC") == 0 ) && ( AV103Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Configuracion_tipodocumentowwds_13_tipdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV104Configuracion_tipodocumentowwds_13_tipdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV101Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPABR") == 0 ) && ( AV103Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Configuracion_tipodocumentowwds_14_tipabr3)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV105Configuracion_tipodocumentowwds_14_tipabr3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV101Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPABR") == 0 ) && ( AV103Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Configuracion_tipodocumentowwds_14_tipabr3)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV105Configuracion_tipodocumentowwds_14_tipabr3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Configuracion_tipodocumentowwds_16_tftipabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Configuracion_tipodocumentowwds_15_tftipabr)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV106Configuracion_tipodocumentowwds_15_tftipabr)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Configuracion_tipodocumentowwds_16_tftipabr_sel)) )
         {
            AddWhere(sWhereString, "([TipAbr] = @AV107Configuracion_tipodocumentowwds_16_tftipabr_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Configuracion_tipodocumentowwds_18_tftipdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Configuracion_tipodocumentowwds_17_tftipdsc)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV108Configuracion_tipodocumentowwds_17_tftipdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Configuracion_tipodocumentowwds_18_tftipdsc_sel)) )
         {
            AddWhere(sWhereString, "([TipDsc] = @AV109Configuracion_tipodocumentowwds_18_tftipdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV110Configuracion_tipodocumentowwds_19_tftipvta_sel == 1 )
         {
            AddWhere(sWhereString, "([TipVta] = 1)");
         }
         if ( AV110Configuracion_tipodocumentowwds_19_tftipvta_sel == 2 )
         {
            AddWhere(sWhereString, "([TipVta] = 0)");
         }
         if ( AV111Configuracion_tipodocumentowwds_20_tftipcmp_sel == 1 )
         {
            AddWhere(sWhereString, "([TipCmp] = 1)");
         }
         if ( AV111Configuracion_tipodocumentowwds_20_tftipcmp_sel == 2 )
         {
            AddWhere(sWhereString, "([TipCmp] = 0)");
         }
         if ( AV112Configuracion_tipodocumentowwds_21_tftiprho_sel == 1 )
         {
            AddWhere(sWhereString, "([TipRHo] = 1)");
         }
         if ( AV112Configuracion_tipodocumentowwds_21_tftiprho_sel == 2 )
         {
            AddWhere(sWhereString, "([TipRHo] = 0)");
         }
         if ( AV113Configuracion_tipodocumentowwds_22_tftipcxp_sel == 1 )
         {
            AddWhere(sWhereString, "([TipCxP] = 1)");
         }
         if ( AV113Configuracion_tipodocumentowwds_22_tftipcxp_sel == 2 )
         {
            AddWhere(sWhereString, "([TipCxP] = 0)");
         }
         if ( AV114Configuracion_tipodocumentowwds_23_tftipban_sel == 1 )
         {
            AddWhere(sWhereString, "([TipBan] = 1)");
         }
         if ( AV114Configuracion_tipodocumentowwds_23_tftipban_sel == 2 )
         {
            AddWhere(sWhereString, "([TipBan] = 0)");
         }
         if ( AV115Configuracion_tipodocumentowwds_24_tftipsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV115Configuracion_tipodocumentowwds_24_tftipsts_sels, "[TipSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipAbr]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipVta]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipVta] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipCmp]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipCmp] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipRHo]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipRHo] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipCxP]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipCxP] DESC";
         }
         else if ( ( AV10OrderedBy == 7 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipBan]";
         }
         else if ( ( AV10OrderedBy == 7 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipBan] DESC";
         }
         else if ( ( AV10OrderedBy == 8 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipSts]";
         }
         else if ( ( AV10OrderedBy == 8 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipSts] DESC";
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
                     return conditional_P004B2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (short)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] );
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
          Object[] prmP004B2;
          prmP004B2 = new Object[] {
          new ParDef("@lV94Configuracion_tipodocumentowwds_3_tipdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV94Configuracion_tipodocumentowwds_3_tipdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV95Configuracion_tipodocumentowwds_4_tipabr1",GXType.NChar,5,0) ,
          new ParDef("@lV95Configuracion_tipodocumentowwds_4_tipabr1",GXType.NChar,5,0) ,
          new ParDef("@lV99Configuracion_tipodocumentowwds_8_tipdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV99Configuracion_tipodocumentowwds_8_tipdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV100Configuracion_tipodocumentowwds_9_tipabr2",GXType.NChar,5,0) ,
          new ParDef("@lV100Configuracion_tipodocumentowwds_9_tipabr2",GXType.NChar,5,0) ,
          new ParDef("@lV104Configuracion_tipodocumentowwds_13_tipdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV104Configuracion_tipodocumentowwds_13_tipdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV105Configuracion_tipodocumentowwds_14_tipabr3",GXType.NChar,5,0) ,
          new ParDef("@lV105Configuracion_tipodocumentowwds_14_tipabr3",GXType.NChar,5,0) ,
          new ParDef("@lV106Configuracion_tipodocumentowwds_15_tftipabr",GXType.NChar,5,0) ,
          new ParDef("@AV107Configuracion_tipodocumentowwds_16_tftipabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV108Configuracion_tipodocumentowwds_17_tftipdsc",GXType.NChar,100,0) ,
          new ParDef("@AV109Configuracion_tipodocumentowwds_18_tftipdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004B2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                return;
       }
    }

 }

}
