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
namespace GeneXus.Programs.contabilidad {
   public class rubrostotaleswwexportreport : GXWebProcedure
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

      public rubrostotaleswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rubrostotaleswwexportreport( IGxContext context )
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
         rubrostotaleswwexportreport objrubrostotaleswwexportreport;
         objrubrostotaleswwexportreport = new rubrostotaleswwexportreport();
         objrubrostotaleswwexportreport.context.SetSubmitInitialConfig(context);
         objrubrostotaleswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrubrostotaleswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rubrostotaleswwexportreport)stateInfo).executePrivate();
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
            AV63Title = "Lista de Rubros Totales";
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
            H710( true, 0) ;
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
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "TOTTIPO") == 0 )
            {
               AV65TotTipo1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TotTipo1)) )
               {
                  AV66TotTipo = AV65TotTipo1;
                  H710( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Tipo de Reporte", 25, Gx_line+0, 152, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66TotTipo, "")), 152, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TOTTIPO") == 0 )
               {
                  AV69TotTipo2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69TotTipo2)) )
                  {
                     AV66TotTipo = AV69TotTipo2;
                     H710( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Tipo de Reporte", 25, Gx_line+0, 152, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66TotTipo, "")), 152, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TOTTIPO") == 0 )
                  {
                     AV71TotTipo3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71TotTipo3)) )
                     {
                        AV66TotTipo = AV71TotTipo3;
                        H710( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText("Tipo de Reporte", 25, Gx_line+0, 152, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66TotTipo, "")), 152, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         AV34TFTotTipo_Sels.FromJSonString(AV32TFTotTipo_SelsJson, null);
         if ( ! ( AV34TFTotTipo_Sels.Count == 0 ) )
         {
            AV52i = 1;
            AV78GXV1 = 1;
            while ( AV78GXV1 <= AV34TFTotTipo_Sels.Count )
            {
               AV35TFTotTipo_Sel = AV34TFTotTipo_Sels.GetString(AV78GXV1);
               if ( AV52i == 1 )
               {
                  AV33TFTotTipo_SelDscs = "";
               }
               else
               {
                  AV33TFTotTipo_SelDscs += ", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "BAL") == 0 )
               {
                  AV48FilterTFTotTipo_SelValueDescription = "Estado de Situación Financiera";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "FUN") == 0 )
               {
                  AV48FilterTFTotTipo_SelValueDescription = "Estado de Resultados Integrales";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "NAT") == 0 )
               {
                  AV48FilterTFTotTipo_SelValueDescription = "Estado de Ganancia y Perdidad";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "COS") == 0 )
               {
                  AV48FilterTFTotTipo_SelValueDescription = "Registro de Costos";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "RCC") == 0 )
               {
                  AV48FilterTFTotTipo_SelValueDescription = "Registro de Costos / Centro de Costos";
               }
               AV33TFTotTipo_SelDscs += AV48FilterTFTotTipo_SelValueDescription;
               AV52i = (long)(AV52i+1);
               AV78GXV1 = (int)(AV78GXV1+1);
            }
            H710( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo de Reporte", 25, Gx_line+0, 152, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFTotTipo_SelDscs, "")), 152, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV36TFTotRub) && (0==AV37TFTotRub_To) ) )
         {
            H710( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 152, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36TFTotRub), "ZZZZZ9")), 152, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV49TFTotRub_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H710( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFTotRub_To_Description, "")), 25, Gx_line+0, 152, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37TFTotRub_To), "ZZZZZ9")), 152, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFTotDsc_Sel)) )
         {
            H710( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Titulo de Totales", 25, Gx_line+0, 152, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFTotDsc_Sel, "")), 152, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTotDsc)) )
            {
               H710( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Titulo de Totales", 25, Gx_line+0, 152, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFTotDsc, "")), 152, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFTotDscTot_Sel)) )
         {
            H710( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Totales", 25, Gx_line+0, 152, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFTotDscTot_Sel, "")), 152, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFTotDscTot)) )
            {
               H710( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Totales", 25, Gx_line+0, 152, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFTotDscTot, "")), 152, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV42TFTotOrd) && (0==AV43TFTotOrd_To) ) )
         {
            H710( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("N° Orden", 25, Gx_line+0, 152, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV42TFTotOrd), "Z9")), 152, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV50TFTotOrd_To_Description = StringUtil.Format( "%1 (%2)", "N° Orden", "Hasta", "", "", "", "", "", "", "");
            H710( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFTotOrd_To_Description, "")), 25, Gx_line+0, 152, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV43TFTotOrd_To), "Z9")), 152, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV46TFTotSts_Sels.FromJSonString(AV44TFTotSts_SelsJson, null);
         if ( ! ( AV46TFTotSts_Sels.Count == 0 ) )
         {
            AV52i = 1;
            AV79GXV2 = 1;
            while ( AV79GXV2 <= AV46TFTotSts_Sels.Count )
            {
               AV47TFTotSts_Sel = (short)(AV46TFTotSts_Sels.GetNumeric(AV79GXV2));
               if ( AV52i == 1 )
               {
                  AV45TFTotSts_SelDscs = "";
               }
               else
               {
                  AV45TFTotSts_SelDscs += ", ";
               }
               if ( AV47TFTotSts_Sel == 1 )
               {
                  AV51FilterTFTotSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV47TFTotSts_Sel == 0 )
               {
                  AV51FilterTFTotSts_SelValueDescription = "INACTIVO";
               }
               AV45TFTotSts_SelDscs += AV51FilterTFTotSts_SelValueDescription;
               AV52i = (long)(AV52i+1);
               AV79GXV2 = (int)(AV79GXV2+1);
            }
            H710( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 152, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFTotSts_SelDscs, "")), 152, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H710( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H710( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Tipo de Reporte", 30, Gx_line+10, 176, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo", 180, Gx_line+10, 253, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Titulo de Totales", 257, Gx_line+10, 405, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Totales", 409, Gx_line+10, 557, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("N° Orden", 561, Gx_line+10, 635, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 639, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV81Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV82Contabilidad_rubrostotaleswwds_2_tottipo1 = AV65TotTipo1;
         AV83Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV84Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV85Contabilidad_rubrostotaleswwds_5_tottipo2 = AV69TotTipo2;
         AV86Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV87Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV88Contabilidad_rubrostotaleswwds_8_tottipo3 = AV71TotTipo3;
         AV89Contabilidad_rubrostotaleswwds_9_tftottipo_sels = AV34TFTotTipo_Sels;
         AV90Contabilidad_rubrostotaleswwds_10_tftotrub = AV36TFTotRub;
         AV91Contabilidad_rubrostotaleswwds_11_tftotrub_to = AV37TFTotRub_To;
         AV92Contabilidad_rubrostotaleswwds_12_tftotdsc = AV38TFTotDsc;
         AV93Contabilidad_rubrostotaleswwds_13_tftotdsc_sel = AV39TFTotDsc_Sel;
         AV94Contabilidad_rubrostotaleswwds_14_tftotdsctot = AV40TFTotDscTot;
         AV95Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel = AV41TFTotDscTot_Sel;
         AV96Contabilidad_rubrostotaleswwds_16_tftotord = AV42TFTotOrd;
         AV97Contabilidad_rubrostotaleswwds_17_tftotord_to = AV43TFTotOrd_To;
         AV98Contabilidad_rubrostotaleswwds_18_tftotsts_sels = AV46TFTotSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A114TotTipo ,
                                              AV89Contabilidad_rubrostotaleswwds_9_tftottipo_sels ,
                                              A1930TotSts ,
                                              AV98Contabilidad_rubrostotaleswwds_18_tftotsts_sels ,
                                              AV81Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 ,
                                              AV82Contabilidad_rubrostotaleswwds_2_tottipo1 ,
                                              AV83Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 ,
                                              AV84Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 ,
                                              AV85Contabilidad_rubrostotaleswwds_5_tottipo2 ,
                                              AV86Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 ,
                                              AV87Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 ,
                                              AV88Contabilidad_rubrostotaleswwds_8_tottipo3 ,
                                              AV89Contabilidad_rubrostotaleswwds_9_tftottipo_sels.Count ,
                                              AV90Contabilidad_rubrostotaleswwds_10_tftotrub ,
                                              AV91Contabilidad_rubrostotaleswwds_11_tftotrub_to ,
                                              AV93Contabilidad_rubrostotaleswwds_13_tftotdsc_sel ,
                                              AV92Contabilidad_rubrostotaleswwds_12_tftotdsc ,
                                              AV95Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel ,
                                              AV94Contabilidad_rubrostotaleswwds_14_tftotdsctot ,
                                              AV96Contabilidad_rubrostotaleswwds_16_tftotord ,
                                              AV97Contabilidad_rubrostotaleswwds_17_tftotord_to ,
                                              AV98Contabilidad_rubrostotaleswwds_18_tftotsts_sels.Count ,
                                              A115TotRub ,
                                              A1928TotDsc ,
                                              A1929TotDscTot ,
                                              A120TotOrd ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV92Contabilidad_rubrostotaleswwds_12_tftotdsc = StringUtil.PadR( StringUtil.RTrim( AV92Contabilidad_rubrostotaleswwds_12_tftotdsc), 100, "%");
         lV94Contabilidad_rubrostotaleswwds_14_tftotdsctot = StringUtil.PadR( StringUtil.RTrim( AV94Contabilidad_rubrostotaleswwds_14_tftotdsctot), 100, "%");
         /* Using cursor P00712 */
         pr_default.execute(0, new Object[] {AV82Contabilidad_rubrostotaleswwds_2_tottipo1, AV85Contabilidad_rubrostotaleswwds_5_tottipo2, AV88Contabilidad_rubrostotaleswwds_8_tottipo3, AV90Contabilidad_rubrostotaleswwds_10_tftotrub, AV91Contabilidad_rubrostotaleswwds_11_tftotrub_to, lV92Contabilidad_rubrostotaleswwds_12_tftotdsc, AV93Contabilidad_rubrostotaleswwds_13_tftotdsc_sel, lV94Contabilidad_rubrostotaleswwds_14_tftotdsctot, AV95Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel, AV96Contabilidad_rubrostotaleswwds_16_tftotord, AV97Contabilidad_rubrostotaleswwds_17_tftotord_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1930TotSts = P00712_A1930TotSts[0];
            A120TotOrd = P00712_A120TotOrd[0];
            A1929TotDscTot = P00712_A1929TotDscTot[0];
            A1928TotDsc = P00712_A1928TotDsc[0];
            A115TotRub = P00712_A115TotRub[0];
            A114TotTipo = P00712_A114TotTipo[0];
            if ( StringUtil.StrCmp(StringUtil.Trim( A114TotTipo), "BAL") == 0 )
            {
               AV12TotTipoDescription = "Estado de Situación Financiera";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A114TotTipo), "FUN") == 0 )
            {
               AV12TotTipoDescription = "Estado de Resultados Integrales";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A114TotTipo), "NAT") == 0 )
            {
               AV12TotTipoDescription = "Estado de Ganancia y Perdidad";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A114TotTipo), "COS") == 0 )
            {
               AV12TotTipoDescription = "Registro de Costos";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A114TotTipo), "RCC") == 0 )
            {
               AV12TotTipoDescription = "Registro de Costos / Centro de Costos";
            }
            if ( A1930TotSts == 1 )
            {
               AV13TotStsDescription = "ACTIVO";
            }
            else if ( A1930TotSts == 0 )
            {
               AV13TotStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H710( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12TotTipoDescription, "")), 30, Gx_line+10, 176, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A115TotRub), "ZZZZZ9")), 180, Gx_line+10, 253, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1928TotDsc, "")), 257, Gx_line+10, 405, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1929TotDscTot, "")), 409, Gx_line+10, 557, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A120TotOrd), "Z9")), 561, Gx_line+10, 635, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13TotStsDescription, "")), 639, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV28Session.Get("Contabilidad.RubrosTotalesWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.RubrosTotalesWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("Contabilidad.RubrosTotalesWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV99GXV3 = 1;
         while ( AV99GXV3 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV99GXV3));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTOTTIPO_SEL") == 0 )
            {
               AV32TFTotTipo_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV34TFTotTipo_Sels.FromJSonString(AV32TFTotTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTOTRUB") == 0 )
            {
               AV36TFTotRub = (int)(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."));
               AV37TFTotRub_To = (int)(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTOTDSC") == 0 )
            {
               AV38TFTotDsc = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTOTDSC_SEL") == 0 )
            {
               AV39TFTotDsc_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTOTDSCTOT") == 0 )
            {
               AV40TFTotDscTot = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTOTDSCTOT_SEL") == 0 )
            {
               AV41TFTotDscTot_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTOTORD") == 0 )
            {
               AV42TFTotOrd = (short)(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."));
               AV43TFTotOrd_To = (short)(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTOTSTS_SEL") == 0 )
            {
               AV44TFTotSts_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV46TFTotSts_Sels.FromJSonString(AV44TFTotSts_SelsJson, null);
            }
            AV99GXV3 = (int)(AV99GXV3+1);
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

      protected void H710( bool bFoot ,
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
                  AV61PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV58DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV56AppName = "DVelop Software Solutions";
               AV62Phone = "+1 550 8923";
               AV60Mail = "info@mail.com";
               AV64Website = "http://www.web.com";
               AV53AddressLine1 = "French Boulevard 2859";
               AV54AddressLine2 = "Downtown";
               AV55AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV63Title = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV65TotTipo1 = "";
         AV66TotTipo = "";
         AV20DynamicFiltersSelector2 = "";
         AV69TotTipo2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV71TotTipo3 = "";
         AV34TFTotTipo_Sels = new GxSimpleCollection<string>();
         AV32TFTotTipo_SelsJson = "";
         AV35TFTotTipo_Sel = "";
         AV33TFTotTipo_SelDscs = "";
         AV48FilterTFTotTipo_SelValueDescription = "";
         AV49TFTotRub_To_Description = "";
         AV39TFTotDsc_Sel = "";
         AV38TFTotDsc = "";
         AV41TFTotDscTot_Sel = "";
         AV40TFTotDscTot = "";
         AV50TFTotOrd_To_Description = "";
         AV46TFTotSts_Sels = new GxSimpleCollection<short>();
         AV44TFTotSts_SelsJson = "";
         AV45TFTotSts_SelDscs = "";
         AV51FilterTFTotSts_SelValueDescription = "";
         AV81Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 = "";
         AV82Contabilidad_rubrostotaleswwds_2_tottipo1 = "";
         AV84Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 = "";
         AV85Contabilidad_rubrostotaleswwds_5_tottipo2 = "";
         AV87Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 = "";
         AV88Contabilidad_rubrostotaleswwds_8_tottipo3 = "";
         AV89Contabilidad_rubrostotaleswwds_9_tftottipo_sels = new GxSimpleCollection<string>();
         AV92Contabilidad_rubrostotaleswwds_12_tftotdsc = "";
         AV93Contabilidad_rubrostotaleswwds_13_tftotdsc_sel = "";
         AV94Contabilidad_rubrostotaleswwds_14_tftotdsctot = "";
         AV95Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel = "";
         AV98Contabilidad_rubrostotaleswwds_18_tftotsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV92Contabilidad_rubrostotaleswwds_12_tftotdsc = "";
         lV94Contabilidad_rubrostotaleswwds_14_tftotdsctot = "";
         A114TotTipo = "";
         A1928TotDsc = "";
         A1929TotDscTot = "";
         P00712_A1930TotSts = new short[1] ;
         P00712_A120TotOrd = new short[1] ;
         P00712_A1929TotDscTot = new string[] {""} ;
         P00712_A1928TotDsc = new string[] {""} ;
         P00712_A115TotRub = new int[1] ;
         P00712_A114TotTipo = new string[] {""} ;
         AV12TotTipoDescription = "";
         AV13TotStsDescription = "";
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV61PageInfo = "";
         AV58DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV56AppName = "";
         AV62Phone = "";
         AV60Mail = "";
         AV64Website = "";
         AV53AddressLine1 = "";
         AV54AddressLine2 = "";
         AV55AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rubrostotaleswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00712_A1930TotSts, P00712_A120TotOrd, P00712_A1929TotDscTot, P00712_A1928TotDsc, P00712_A115TotRub, P00712_A114TotTipo
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
      private short AV42TFTotOrd ;
      private short AV43TFTotOrd_To ;
      private short AV47TFTotSts_Sel ;
      private short AV96Contabilidad_rubrostotaleswwds_16_tftotord ;
      private short AV97Contabilidad_rubrostotaleswwds_17_tftotord_to ;
      private short A1930TotSts ;
      private short A120TotOrd ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV78GXV1 ;
      private int AV36TFTotRub ;
      private int AV37TFTotRub_To ;
      private int AV79GXV2 ;
      private int AV90Contabilidad_rubrostotaleswwds_10_tftotrub ;
      private int AV91Contabilidad_rubrostotaleswwds_11_tftotrub_to ;
      private int AV89Contabilidad_rubrostotaleswwds_9_tftottipo_sels_Count ;
      private int AV98Contabilidad_rubrostotaleswwds_18_tftotsts_sels_Count ;
      private int A115TotRub ;
      private int AV99GXV3 ;
      private long AV52i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV65TotTipo1 ;
      private string AV66TotTipo ;
      private string AV69TotTipo2 ;
      private string AV71TotTipo3 ;
      private string AV35TFTotTipo_Sel ;
      private string AV39TFTotDsc_Sel ;
      private string AV38TFTotDsc ;
      private string AV41TFTotDscTot_Sel ;
      private string AV40TFTotDscTot ;
      private string AV82Contabilidad_rubrostotaleswwds_2_tottipo1 ;
      private string AV85Contabilidad_rubrostotaleswwds_5_tottipo2 ;
      private string AV88Contabilidad_rubrostotaleswwds_8_tottipo3 ;
      private string AV92Contabilidad_rubrostotaleswwds_12_tftotdsc ;
      private string AV93Contabilidad_rubrostotaleswwds_13_tftotdsc_sel ;
      private string AV94Contabilidad_rubrostotaleswwds_14_tftotdsctot ;
      private string AV95Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel ;
      private string scmdbuf ;
      private string lV92Contabilidad_rubrostotaleswwds_12_tftotdsc ;
      private string lV94Contabilidad_rubrostotaleswwds_14_tftotdsctot ;
      private string A114TotTipo ;
      private string A1928TotDsc ;
      private string A1929TotDscTot ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV83Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 ;
      private bool AV86Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV32TFTotTipo_SelsJson ;
      private string AV44TFTotSts_SelsJson ;
      private string AV63Title ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV33TFTotTipo_SelDscs ;
      private string AV48FilterTFTotTipo_SelValueDescription ;
      private string AV49TFTotRub_To_Description ;
      private string AV50TFTotOrd_To_Description ;
      private string AV45TFTotSts_SelDscs ;
      private string AV51FilterTFTotSts_SelValueDescription ;
      private string AV81Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 ;
      private string AV84Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 ;
      private string AV87Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 ;
      private string AV12TotTipoDescription ;
      private string AV13TotStsDescription ;
      private string AV61PageInfo ;
      private string AV58DateInfo ;
      private string AV56AppName ;
      private string AV62Phone ;
      private string AV60Mail ;
      private string AV64Website ;
      private string AV53AddressLine1 ;
      private string AV54AddressLine2 ;
      private string AV55AddressLine3 ;
      private GxSimpleCollection<short> AV46TFTotSts_Sels ;
      private GxSimpleCollection<short> AV98Contabilidad_rubrostotaleswwds_18_tftotsts_sels ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00712_A1930TotSts ;
      private short[] P00712_A120TotOrd ;
      private string[] P00712_A1929TotDscTot ;
      private string[] P00712_A1928TotDsc ;
      private int[] P00712_A115TotRub ;
      private string[] P00712_A114TotTipo ;
      private GxSimpleCollection<string> AV34TFTotTipo_Sels ;
      private GxSimpleCollection<string> AV89Contabilidad_rubrostotaleswwds_9_tftottipo_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
   }

   public class rubrostotaleswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00712( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV89Contabilidad_rubrostotaleswwds_9_tftottipo_sels ,
                                             short A1930TotSts ,
                                             GxSimpleCollection<short> AV98Contabilidad_rubrostotaleswwds_18_tftotsts_sels ,
                                             string AV81Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 ,
                                             string AV82Contabilidad_rubrostotaleswwds_2_tottipo1 ,
                                             bool AV83Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 ,
                                             string AV84Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 ,
                                             string AV85Contabilidad_rubrostotaleswwds_5_tottipo2 ,
                                             bool AV86Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 ,
                                             string AV87Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 ,
                                             string AV88Contabilidad_rubrostotaleswwds_8_tottipo3 ,
                                             int AV89Contabilidad_rubrostotaleswwds_9_tftottipo_sels_Count ,
                                             int AV90Contabilidad_rubrostotaleswwds_10_tftotrub ,
                                             int AV91Contabilidad_rubrostotaleswwds_11_tftotrub_to ,
                                             string AV93Contabilidad_rubrostotaleswwds_13_tftotdsc_sel ,
                                             string AV92Contabilidad_rubrostotaleswwds_12_tftotdsc ,
                                             string AV95Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel ,
                                             string AV94Contabilidad_rubrostotaleswwds_14_tftotdsctot ,
                                             short AV96Contabilidad_rubrostotaleswwds_16_tftotord ,
                                             short AV97Contabilidad_rubrostotaleswwds_17_tftotord_to ,
                                             int AV98Contabilidad_rubrostotaleswwds_18_tftotsts_sels_Count ,
                                             int A115TotRub ,
                                             string A1928TotDsc ,
                                             string A1929TotDscTot ,
                                             short A120TotOrd ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[11];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TotSts], [TotOrd], [TotDscTot], [TotDsc], [TotRub], [TotTipo] FROM [CBRUBROST]";
         if ( ( StringUtil.StrCmp(AV81Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Contabilidad_rubrostotaleswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV82Contabilidad_rubrostotaleswwds_2_tottipo1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( AV83Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Contabilidad_rubrostotaleswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV85Contabilidad_rubrostotaleswwds_5_tottipo2)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV86Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Contabilidad_rubrostotaleswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV88Contabilidad_rubrostotaleswwds_8_tottipo3)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV89Contabilidad_rubrostotaleswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV89Contabilidad_rubrostotaleswwds_9_tftottipo_sels, "[TotTipo] IN (", ")")+")");
         }
         if ( ! (0==AV90Contabilidad_rubrostotaleswwds_10_tftotrub) )
         {
            AddWhere(sWhereString, "([TotRub] >= @AV90Contabilidad_rubrostotaleswwds_10_tftotrub)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV91Contabilidad_rubrostotaleswwds_11_tftotrub_to) )
         {
            AddWhere(sWhereString, "([TotRub] <= @AV91Contabilidad_rubrostotaleswwds_11_tftotrub_to)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Contabilidad_rubrostotaleswwds_13_tftotdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Contabilidad_rubrostotaleswwds_12_tftotdsc)) ) )
         {
            AddWhere(sWhereString, "([TotDsc] like @lV92Contabilidad_rubrostotaleswwds_12_tftotdsc)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Contabilidad_rubrostotaleswwds_13_tftotdsc_sel)) )
         {
            AddWhere(sWhereString, "([TotDsc] = @AV93Contabilidad_rubrostotaleswwds_13_tftotdsc_sel)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Contabilidad_rubrostotaleswwds_14_tftotdsctot)) ) )
         {
            AddWhere(sWhereString, "([TotDscTot] like @lV94Contabilidad_rubrostotaleswwds_14_tftotdsctot)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel)) )
         {
            AddWhere(sWhereString, "([TotDscTot] = @AV95Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV96Contabilidad_rubrostotaleswwds_16_tftotord) )
         {
            AddWhere(sWhereString, "([TotOrd] >= @AV96Contabilidad_rubrostotaleswwds_16_tftotord)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV97Contabilidad_rubrostotaleswwds_17_tftotord_to) )
         {
            AddWhere(sWhereString, "([TotOrd] <= @AV97Contabilidad_rubrostotaleswwds_17_tftotord_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV98Contabilidad_rubrostotaleswwds_18_tftotsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV98Contabilidad_rubrostotaleswwds_18_tftotsts_sels, "[TotSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [TotTipo], [TotRub]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TotTipo]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TotTipo] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TotRub]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TotRub] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TotDsc]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TotDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TotDscTot]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TotDscTot] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TotOrd]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TotOrd] DESC";
         }
         else if ( ( AV10OrderedBy == 7 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TotSts]";
         }
         else if ( ( AV10OrderedBy == 7 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TotSts] DESC";
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
                     return conditional_P00712(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (int)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP00712;
          prmP00712 = new Object[] {
          new ParDef("@AV82Contabilidad_rubrostotaleswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV85Contabilidad_rubrostotaleswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV88Contabilidad_rubrostotaleswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@AV90Contabilidad_rubrostotaleswwds_10_tftotrub",GXType.Int32,6,0) ,
          new ParDef("@AV91Contabilidad_rubrostotaleswwds_11_tftotrub_to",GXType.Int32,6,0) ,
          new ParDef("@lV92Contabilidad_rubrostotaleswwds_12_tftotdsc",GXType.NChar,100,0) ,
          new ParDef("@AV93Contabilidad_rubrostotaleswwds_13_tftotdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV94Contabilidad_rubrostotaleswwds_14_tftotdsctot",GXType.NChar,100,0) ,
          new ParDef("@AV95Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV96Contabilidad_rubrostotaleswwds_16_tftotord",GXType.Int16,2,0) ,
          new ParDef("@AV97Contabilidad_rubrostotaleswwds_17_tftotord_to",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00712", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00712,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
       }
    }

 }

}
