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
namespace GeneXus.Programs.produccion {
   public class conceptosordenesproduccionwwexportreport : GXWebProcedure
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

      public conceptosordenesproduccionwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptosordenesproduccionwwexportreport( IGxContext context )
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
         conceptosordenesproduccionwwexportreport objconceptosordenesproduccionwwexportreport;
         objconceptosordenesproduccionwwexportreport = new conceptosordenesproduccionwwexportreport();
         objconceptosordenesproduccionwwexportreport.context.SetSubmitInitialConfig(context);
         objconceptosordenesproduccionwwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptosordenesproduccionwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptosordenesproduccionwwexportreport)stateInfo).executePrivate();
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
            AV54Title = "Lista de Conceptos de Ordenes de Produccion";
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
            H6A0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "POCONCDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15PoConcDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15PoConcDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterPoConcDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterPoConcDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17PoConcDsc = AV15PoConcDsc1;
                  H6A0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterPoConcDscDescription, "")), 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17PoConcDsc, "")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "POCONCDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21PoConcDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21PoConcDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterPoConcDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterPoConcDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17PoConcDsc = AV21PoConcDsc2;
                     H6A0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterPoConcDscDescription, "")), 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17PoConcDsc, "")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "POCONCDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25PoConcDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25PoConcDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterPoConcDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterPoConcDscDescription = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17PoConcDsc = AV25PoConcDsc3;
                        H6A0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterPoConcDscDescription, "")), 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17PoConcDsc, "")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFPoConcCod) && (0==AV32TFPoConcCod_To) ) )
         {
            H6A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Concepto", 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFPoConcCod), "ZZZZZ9")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV41TFPoConcCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo Concepto", "Hasta", "", "", "", "", "", "", "");
            H6A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFPoConcCod_To_Description, "")), 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFPoConcCod_To), "ZZZZZ9")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFPoConcDsc_Sel)) )
         {
            H6A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Concepto", 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFPoConcDsc_Sel, "")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFPoConcDsc)) )
            {
               H6A0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Concepto", 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFPoConcDsc, "")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV59TFPoConcTip_Sels.FromJSonString(AV57TFPoConcTip_SelsJson, null);
         if ( ! ( AV59TFPoConcTip_Sels.Count == 0 ) )
         {
            AV43i = 1;
            AV65GXV1 = 1;
            while ( AV65GXV1 <= AV59TFPoConcTip_Sels.Count )
            {
               AV36TFPoConcTip_Sel = AV59TFPoConcTip_Sels.GetString(AV65GXV1);
               if ( AV43i == 1 )
               {
                  AV58TFPoConcTip_SelDscs = "";
               }
               else
               {
                  AV58TFPoConcTip_SelDscs += ", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV36TFPoConcTip_Sel), "C") == 0 )
               {
                  AV60FilterTFPoConcTip_SelValueDescription = "Cantidad";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV36TFPoConcTip_Sel), "T") == 0 )
               {
                  AV60FilterTFPoConcTip_SelValueDescription = "Costo";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV36TFPoConcTip_Sel), "H") == 0 )
               {
                  AV60FilterTFPoConcTip_SelValueDescription = "Horas";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV36TFPoConcTip_Sel), "P") == 0 )
               {
                  AV60FilterTFPoConcTip_SelValueDescription = "Peso";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV36TFPoConcTip_Sel), "V") == 0 )
               {
                  AV60FilterTFPoConcTip_SelValueDescription = "Volumen";
               }
               AV58TFPoConcTip_SelDscs += AV60FilterTFPoConcTip_SelValueDescription;
               AV43i = (long)(AV43i+1);
               AV65GXV1 = (int)(AV65GXV1+1);
            }
            H6A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo de Distribución", 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58TFPoConcTip_SelDscs, "")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV39TFPoConcSts_Sels.FromJSonString(AV37TFPoConcSts_SelsJson, null);
         if ( ! ( AV39TFPoConcSts_Sels.Count == 0 ) )
         {
            AV43i = 1;
            AV66GXV2 = 1;
            while ( AV66GXV2 <= AV39TFPoConcSts_Sels.Count )
            {
               AV40TFPoConcSts_Sel = (short)(AV39TFPoConcSts_Sels.GetNumeric(AV66GXV2));
               if ( AV43i == 1 )
               {
                  AV38TFPoConcSts_SelDscs = "";
               }
               else
               {
                  AV38TFPoConcSts_SelDscs += ", ";
               }
               if ( AV40TFPoConcSts_Sel == 1 )
               {
                  AV42FilterTFPoConcSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV40TFPoConcSts_Sel == 0 )
               {
                  AV42FilterTFPoConcSts_SelValueDescription = "INACTIVO";
               }
               AV38TFPoConcSts_SelDscs += AV42FilterTFPoConcSts_SelValueDescription;
               AV43i = (long)(AV43i+1);
               AV66GXV2 = (int)(AV66GXV2+1);
            }
            H6A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 191, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFPoConcSts_SelDscs, "")), 191, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6A0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6A0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo Concepto", 30, Gx_line+10, 136, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Concepto", 140, Gx_line+10, 352, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo de Distribución", 356, Gx_line+10, 569, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 573, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV68Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV69Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = AV15PoConcDsc1;
         AV71Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV72Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV73Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = AV21PoConcDsc2;
         AV75Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV76Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV77Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = AV25PoConcDsc3;
         AV79Produccion_conceptosordenesproduccionwwds_12_tfpoconccod = AV31TFPoConcCod;
         AV80Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to = AV32TFPoConcCod_To;
         AV81Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = AV33TFPoConcDsc;
         AV82Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel = AV34TFPoConcDsc_Sel;
         AV83Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels = AV59TFPoConcTip_Sels;
         AV84Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels = AV39TFPoConcSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1650PoConcTip ,
                                              AV83Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels ,
                                              A1649PoConcSts ,
                                              AV84Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels ,
                                              AV68Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 ,
                                              AV69Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 ,
                                              AV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ,
                                              AV71Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 ,
                                              AV72Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 ,
                                              AV73Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 ,
                                              AV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ,
                                              AV75Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 ,
                                              AV76Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 ,
                                              AV77Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 ,
                                              AV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ,
                                              AV79Produccion_conceptosordenesproduccionwwds_12_tfpoconccod ,
                                              AV80Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to ,
                                              AV82Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel ,
                                              AV81Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ,
                                              AV83Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels.Count ,
                                              AV84Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels.Count ,
                                              A1648PoConcDsc ,
                                              A313PoConcCod ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1), 100, "%");
         lV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1), 100, "%");
         lV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2), 100, "%");
         lV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2), 100, "%");
         lV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3), 100, "%");
         lV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3), 100, "%");
         lV81Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = StringUtil.PadR( StringUtil.RTrim( AV81Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc), 100, "%");
         /* Using cursor P006A2 */
         pr_default.execute(0, new Object[] {lV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1, lV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1, lV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2, lV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2, lV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3, lV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3, AV79Produccion_conceptosordenesproduccionwwds_12_tfpoconccod, AV80Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to, lV81Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc, AV82Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1649PoConcSts = P006A2_A1649PoConcSts[0];
            A1650PoConcTip = P006A2_A1650PoConcTip[0];
            A313PoConcCod = P006A2_A313PoConcCod[0];
            A1648PoConcDsc = P006A2_A1648PoConcDsc[0];
            if ( StringUtil.StrCmp(StringUtil.Trim( A1650PoConcTip), "C") == 0 )
            {
               AV56PoConcTipDescription = "Cantidad";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A1650PoConcTip), "T") == 0 )
            {
               AV56PoConcTipDescription = "Costo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A1650PoConcTip), "H") == 0 )
            {
               AV56PoConcTipDescription = "Horas";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A1650PoConcTip), "P") == 0 )
            {
               AV56PoConcTipDescription = "Peso";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A1650PoConcTip), "V") == 0 )
            {
               AV56PoConcTipDescription = "Volumen";
            }
            if ( A1649PoConcSts == 1 )
            {
               AV12PoConcStsDescription = "ACTIVO";
            }
            else if ( A1649PoConcSts == 0 )
            {
               AV12PoConcStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6A0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A313PoConcCod), "ZZZZZ9")), 30, Gx_line+10, 136, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1648PoConcDsc, "")), 140, Gx_line+10, 352, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56PoConcTipDescription, "")), 356, Gx_line+10, 569, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12PoConcStsDescription, "")), 573, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Produccion.ConceptosOrdenesProduccionWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Produccion.ConceptosOrdenesProduccionWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Produccion.ConceptosOrdenesProduccionWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV85GXV3 = 1;
         while ( AV85GXV3 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV85GXV3));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPOCONCCOD") == 0 )
            {
               AV31TFPoConcCod = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AV32TFPoConcCod_To = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPOCONCDSC") == 0 )
            {
               AV33TFPoConcDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPOCONCDSC_SEL") == 0 )
            {
               AV34TFPoConcDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPOCONCTIP_SEL") == 0 )
            {
               AV57TFPoConcTip_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV59TFPoConcTip_Sels.FromJSonString(AV57TFPoConcTip_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFPOCONCSTS_SEL") == 0 )
            {
               AV37TFPoConcSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV39TFPoConcSts_Sels.FromJSonString(AV37TFPoConcSts_SelsJson, null);
            }
            AV85GXV3 = (int)(AV85GXV3+1);
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

      protected void H6A0( bool bFoot ,
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
         AV15PoConcDsc1 = "";
         AV16FilterPoConcDscDescription = "";
         AV17PoConcDsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21PoConcDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25PoConcDsc3 = "";
         AV41TFPoConcCod_To_Description = "";
         AV34TFPoConcDsc_Sel = "";
         AV33TFPoConcDsc = "";
         AV59TFPoConcTip_Sels = new GxSimpleCollection<string>();
         AV57TFPoConcTip_SelsJson = "";
         AV36TFPoConcTip_Sel = "";
         AV58TFPoConcTip_SelDscs = "";
         AV60FilterTFPoConcTip_SelValueDescription = "";
         AV39TFPoConcSts_Sels = new GxSimpleCollection<short>();
         AV37TFPoConcSts_SelsJson = "";
         AV38TFPoConcSts_SelDscs = "";
         AV42FilterTFPoConcSts_SelValueDescription = "";
         AV68Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 = "";
         AV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = "";
         AV72Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 = "";
         AV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = "";
         AV76Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 = "";
         AV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = "";
         AV81Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = "";
         AV82Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel = "";
         AV83Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels = new GxSimpleCollection<string>();
         AV84Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = "";
         lV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = "";
         lV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = "";
         lV81Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = "";
         A1650PoConcTip = "";
         A1648PoConcDsc = "";
         P006A2_A1649PoConcSts = new short[1] ;
         P006A2_A1650PoConcTip = new string[] {""} ;
         P006A2_A313PoConcCod = new int[1] ;
         P006A2_A1648PoConcDsc = new string[] {""} ;
         AV56PoConcTipDescription = "";
         AV12PoConcStsDescription = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.conceptosordenesproduccionwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006A2_A1649PoConcSts, P006A2_A1650PoConcTip, P006A2_A313PoConcCod, P006A2_A1648PoConcDsc
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
      private short AV40TFPoConcSts_Sel ;
      private short AV69Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 ;
      private short AV73Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 ;
      private short AV77Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 ;
      private short A1649PoConcSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV31TFPoConcCod ;
      private int AV32TFPoConcCod_To ;
      private int AV65GXV1 ;
      private int AV66GXV2 ;
      private int AV79Produccion_conceptosordenesproduccionwwds_12_tfpoconccod ;
      private int AV80Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to ;
      private int AV83Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels_Count ;
      private int AV84Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels_Count ;
      private int A313PoConcCod ;
      private int AV85GXV3 ;
      private long AV43i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15PoConcDsc1 ;
      private string AV17PoConcDsc ;
      private string AV21PoConcDsc2 ;
      private string AV25PoConcDsc3 ;
      private string AV34TFPoConcDsc_Sel ;
      private string AV33TFPoConcDsc ;
      private string AV36TFPoConcTip_Sel ;
      private string AV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ;
      private string AV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ;
      private string AV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ;
      private string AV81Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ;
      private string AV82Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel ;
      private string scmdbuf ;
      private string lV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ;
      private string lV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ;
      private string lV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ;
      private string lV81Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ;
      private string A1650PoConcTip ;
      private string A1648PoConcDsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV71Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 ;
      private bool AV75Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV57TFPoConcTip_SelsJson ;
      private string AV37TFPoConcSts_SelsJson ;
      private string AV54Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterPoConcDscDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV41TFPoConcCod_To_Description ;
      private string AV58TFPoConcTip_SelDscs ;
      private string AV60FilterTFPoConcTip_SelValueDescription ;
      private string AV38TFPoConcSts_SelDscs ;
      private string AV42FilterTFPoConcSts_SelValueDescription ;
      private string AV68Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 ;
      private string AV72Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 ;
      private string AV76Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 ;
      private string AV56PoConcTipDescription ;
      private string AV12PoConcStsDescription ;
      private string AV52PageInfo ;
      private string AV49DateInfo ;
      private string AV47AppName ;
      private string AV53Phone ;
      private string AV51Mail ;
      private string AV55Website ;
      private string AV44AddressLine1 ;
      private string AV45AddressLine2 ;
      private string AV46AddressLine3 ;
      private GxSimpleCollection<short> AV39TFPoConcSts_Sels ;
      private GxSimpleCollection<short> AV84Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006A2_A1649PoConcSts ;
      private string[] P006A2_A1650PoConcTip ;
      private int[] P006A2_A313PoConcCod ;
      private string[] P006A2_A1648PoConcDsc ;
      private GxSimpleCollection<string> AV59TFPoConcTip_Sels ;
      private GxSimpleCollection<string> AV83Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class conceptosordenesproduccionwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006A2( IGxContext context ,
                                             string A1650PoConcTip ,
                                             GxSimpleCollection<string> AV83Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels ,
                                             short A1649PoConcSts ,
                                             GxSimpleCollection<short> AV84Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels ,
                                             string AV68Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 ,
                                             short AV69Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 ,
                                             string AV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ,
                                             bool AV71Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 ,
                                             string AV72Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 ,
                                             short AV73Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 ,
                                             string AV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ,
                                             bool AV75Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 ,
                                             string AV76Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 ,
                                             short AV77Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 ,
                                             string AV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ,
                                             int AV79Produccion_conceptosordenesproduccionwwds_12_tfpoconccod ,
                                             int AV80Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to ,
                                             string AV82Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel ,
                                             string AV81Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ,
                                             int AV83Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels_Count ,
                                             int AV84Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels_Count ,
                                             string A1648PoConcDsc ,
                                             int A313PoConcCod ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [PoConcSts], [PoConcTip], [PoConcCod], [PoConcDsc] FROM [POCONCEPTOS]";
         if ( ( StringUtil.StrCmp(AV68Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1, "POCONCDSC") == 0 ) && ( AV69Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1, "POCONCDSC") == 0 ) && ( AV69Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV71Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2, "POCONCDSC") == 0 ) && ( AV73Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV71Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2, "POCONCDSC") == 0 ) && ( AV73Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV75Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3, "POCONCDSC") == 0 ) && ( AV77Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV75Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3, "POCONCDSC") == 0 ) && ( AV77Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV79Produccion_conceptosordenesproduccionwwds_12_tfpoconccod) )
         {
            AddWhere(sWhereString, "([PoConcCod] >= @AV79Produccion_conceptosordenesproduccionwwds_12_tfpoconccod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV80Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to) )
         {
            AddWhere(sWhereString, "([PoConcCod] <= @AV80Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV81Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)) )
         {
            AddWhere(sWhereString, "([PoConcDsc] = @AV82Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV83Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels, "[PoConcTip] IN (", ")")+")");
         }
         if ( AV84Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV84Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels, "[PoConcSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [PoConcDsc]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PoConcDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [PoConcCod]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PoConcCod] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [PoConcTip]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PoConcTip] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [PoConcSts]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PoConcSts] DESC";
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
                     return conditional_P006A2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP006A2;
          prmP006A2 = new Object[] {
          new ParDef("@lV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV70Produccion_conceptosordenesproduccionwwds_3_poconcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV74Produccion_conceptosordenesproduccionwwds_7_poconcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV78Produccion_conceptosordenesproduccionwwds_11_poconcdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV79Produccion_conceptosordenesproduccionwwds_12_tfpoconccod",GXType.Int32,6,0) ,
          new ParDef("@AV80Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to",GXType.Int32,6,0) ,
          new ParDef("@lV81Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc",GXType.NChar,100,0) ,
          new ParDef("@AV82Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
