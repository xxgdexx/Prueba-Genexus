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
   public class rubroswwexportreport : GXWebProcedure
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

      public rubroswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rubroswwexportreport( IGxContext context )
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
         rubroswwexportreport objrubroswwexportreport;
         objrubroswwexportreport = new rubroswwexportreport();
         objrubroswwexportreport.context.SetSubmitInitialConfig(context);
         objrubroswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrubroswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rubroswwexportreport)stateInfo).executePrivate();
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
            AV66Title = "Lista de Rubros";
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
            H740( true, 0) ;
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
               AV68TotTipo1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TotTipo1)) )
               {
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV68TotTipo1), "BAL") == 0 )
                  {
                     AV71FilterTotTipo1ValueDescription = "Estado de Situación Financiera";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV68TotTipo1), "FUN") == 0 )
                  {
                     AV71FilterTotTipo1ValueDescription = "Estado de Resultados Integrales";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV68TotTipo1), "NAT") == 0 )
                  {
                     AV71FilterTotTipo1ValueDescription = "Estado de Ganancia y Perdidad";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV68TotTipo1), "COS") == 0 )
                  {
                     AV71FilterTotTipo1ValueDescription = "Registro de Costos";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV68TotTipo1), "RCC") == 0 )
                  {
                     AV71FilterTotTipo1ValueDescription = "Registro de Costos / Centro de Costos";
                  }
                  AV70FilterTotTipoValueDescription = AV71FilterTotTipo1ValueDescription;
                  H740( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Tipo de Reporte", 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70FilterTotTipoValueDescription, "")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
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
                  AV72TotTipo2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TotTipo2)) )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Trim( AV72TotTipo2), "BAL") == 0 )
                     {
                        AV73FilterTotTipo2ValueDescription = "Estado de Situación Financiera";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV72TotTipo2), "FUN") == 0 )
                     {
                        AV73FilterTotTipo2ValueDescription = "Estado de Resultados Integrales";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV72TotTipo2), "NAT") == 0 )
                     {
                        AV73FilterTotTipo2ValueDescription = "Estado de Ganancia y Perdidad";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV72TotTipo2), "COS") == 0 )
                     {
                        AV73FilterTotTipo2ValueDescription = "Registro de Costos";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV72TotTipo2), "RCC") == 0 )
                     {
                        AV73FilterTotTipo2ValueDescription = "Registro de Costos / Centro de Costos";
                     }
                     AV70FilterTotTipoValueDescription = AV73FilterTotTipo2ValueDescription;
                     H740( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Tipo de Reporte", 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70FilterTotTipoValueDescription, "")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
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
                     AV74TotTipo3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74TotTipo3)) )
                     {
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV74TotTipo3), "BAL") == 0 )
                        {
                           AV75FilterTotTipo3ValueDescription = "Estado de Situación Financiera";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV74TotTipo3), "FUN") == 0 )
                        {
                           AV75FilterTotTipo3ValueDescription = "Estado de Resultados Integrales";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV74TotTipo3), "NAT") == 0 )
                        {
                           AV75FilterTotTipo3ValueDescription = "Estado de Ganancia y Perdidad";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV74TotTipo3), "COS") == 0 )
                        {
                           AV75FilterTotTipo3ValueDescription = "Registro de Costos";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV74TotTipo3), "RCC") == 0 )
                        {
                           AV75FilterTotTipo3ValueDescription = "Registro de Costos / Centro de Costos";
                        }
                        AV70FilterTotTipoValueDescription = AV75FilterTotTipo3ValueDescription;
                        H740( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText("Tipo de Reporte", 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70FilterTotTipoValueDescription, "")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
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
            AV55i = 1;
            AV87GXV1 = 1;
            while ( AV87GXV1 <= AV34TFTotTipo_Sels.Count )
            {
               AV35TFTotTipo_Sel = AV34TFTotTipo_Sels.GetString(AV87GXV1);
               if ( AV55i == 1 )
               {
                  AV33TFTotTipo_SelDscs = "";
               }
               else
               {
                  AV33TFTotTipo_SelDscs += ", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "BAL") == 0 )
               {
                  AV50FilterTFTotTipo_SelValueDescription = "Estado de Situación Financiera";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "FUN") == 0 )
               {
                  AV50FilterTFTotTipo_SelValueDescription = "Estado de Resultados Integrales";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "NAT") == 0 )
               {
                  AV50FilterTFTotTipo_SelValueDescription = "Estado de Ganancia y Perdidad";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "COS") == 0 )
               {
                  AV50FilterTFTotTipo_SelValueDescription = "Registro de Costos";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "RCC") == 0 )
               {
                  AV50FilterTFTotTipo_SelValueDescription = "Registro de Costos / Centro de Costos";
               }
               AV33TFTotTipo_SelDscs += AV50FilterTFTotTipo_SelValueDescription;
               AV55i = (long)(AV55i+1);
               AV87GXV1 = (int)(AV87GXV1+1);
            }
            H740( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo de Reporte", 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFTotTipo_SelDscs, "")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77TFTotDsc_Sel)) )
         {
            H740( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Titulo de Totales", 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77TFTotDsc_Sel, "")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76TFTotDsc)) )
            {
               H740( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Titulo de Totales", 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76TFTotDsc, "")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV38TFRubCod) && (0==AV39TFRubCod_To) ) )
         {
            H740( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Rubro", 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TFRubCod), "ZZZZZ9")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV52TFRubCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo Rubro", "Hasta", "", "", "", "", "", "", "");
            H740( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFRubCod_To_Description, "")), 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV39TFRubCod_To), "ZZZZZ9")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFRubDsc_Sel)) )
         {
            H740( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Rubro", 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFRubDsc_Sel, "")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFRubDsc)) )
            {
               H740( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Rubro", 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFRubDsc, "")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFRubDscTot_Sel)) )
         {
            H740( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Totales de Rubros", 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFRubDscTot_Sel, "")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFRubDscTot)) )
            {
               H740( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Totales de Rubros", 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFRubDscTot, "")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV44TFRubOrd) && (0==AV45TFRubOrd_To) ) )
         {
            H740( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("N° Orden", 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV44TFRubOrd), "Z9")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV53TFRubOrd_To_Description = StringUtil.Format( "%1 (%2)", "N° Orden", "Hasta", "", "", "", "", "", "", "");
            H740( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53TFRubOrd_To_Description, "")), 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV45TFRubOrd_To), "Z9")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV48TFRubSts_Sels.FromJSonString(AV46TFRubSts_SelsJson, null);
         if ( ! ( AV48TFRubSts_Sels.Count == 0 ) )
         {
            AV55i = 1;
            AV88GXV2 = 1;
            while ( AV88GXV2 <= AV48TFRubSts_Sels.Count )
            {
               AV49TFRubSts_Sel = (short)(AV48TFRubSts_Sels.GetNumeric(AV88GXV2));
               if ( AV55i == 1 )
               {
                  AV47TFRubSts_SelDscs = "";
               }
               else
               {
                  AV47TFRubSts_SelDscs += ", ";
               }
               if ( AV49TFRubSts_Sel == 1 )
               {
                  AV54FilterTFRubSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV49TFRubSts_Sel == 0 )
               {
                  AV54FilterTFRubSts_SelValueDescription = "INACTIVO";
               }
               AV47TFRubSts_SelDscs += AV54FilterTFRubSts_SelValueDescription;
               AV55i = (long)(AV55i+1);
               AV88GXV2 = (int)(AV88GXV2+1);
            }
            H740( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 174, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFRubSts_SelDscs, "")), 174, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H740( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H740( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Tipo de Reporte", 30, Gx_line+10, 152, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Titulo de Totales", 156, Gx_line+10, 278, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo Rubro", 282, Gx_line+10, 343, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Rubro", 347, Gx_line+10, 469, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Totales de Rubros", 473, Gx_line+10, 595, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("N° Orden", 599, Gx_line+10, 660, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 664, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV90Contabilidad_rubroswwds_1_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV91Contabilidad_rubroswwds_2_tottipo1 = AV68TotTipo1;
         AV92Contabilidad_rubroswwds_3_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV93Contabilidad_rubroswwds_4_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV94Contabilidad_rubroswwds_5_tottipo2 = AV72TotTipo2;
         AV95Contabilidad_rubroswwds_6_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV96Contabilidad_rubroswwds_7_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV97Contabilidad_rubroswwds_8_tottipo3 = AV74TotTipo3;
         AV98Contabilidad_rubroswwds_9_tftottipo_sels = AV34TFTotTipo_Sels;
         AV99Contabilidad_rubroswwds_10_tftotdsc = AV76TFTotDsc;
         AV100Contabilidad_rubroswwds_11_tftotdsc_sel = AV77TFTotDsc_Sel;
         AV101Contabilidad_rubroswwds_12_tfrubcod = AV38TFRubCod;
         AV102Contabilidad_rubroswwds_13_tfrubcod_to = AV39TFRubCod_To;
         AV103Contabilidad_rubroswwds_14_tfrubdsc = AV40TFRubDsc;
         AV104Contabilidad_rubroswwds_15_tfrubdsc_sel = AV41TFRubDsc_Sel;
         AV105Contabilidad_rubroswwds_16_tfrubdsctot = AV42TFRubDscTot;
         AV106Contabilidad_rubroswwds_17_tfrubdsctot_sel = AV43TFRubDscTot_Sel;
         AV107Contabilidad_rubroswwds_18_tfrubord = AV44TFRubOrd;
         AV108Contabilidad_rubroswwds_19_tfrubord_to = AV45TFRubOrd_To;
         AV109Contabilidad_rubroswwds_20_tfrubsts_sels = AV48TFRubSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A114TotTipo ,
                                              AV98Contabilidad_rubroswwds_9_tftottipo_sels ,
                                              A1829RubSts ,
                                              AV109Contabilidad_rubroswwds_20_tfrubsts_sels ,
                                              AV90Contabilidad_rubroswwds_1_dynamicfiltersselector1 ,
                                              AV91Contabilidad_rubroswwds_2_tottipo1 ,
                                              AV92Contabilidad_rubroswwds_3_dynamicfiltersenabled2 ,
                                              AV93Contabilidad_rubroswwds_4_dynamicfiltersselector2 ,
                                              AV94Contabilidad_rubroswwds_5_tottipo2 ,
                                              AV95Contabilidad_rubroswwds_6_dynamicfiltersenabled3 ,
                                              AV96Contabilidad_rubroswwds_7_dynamicfiltersselector3 ,
                                              AV97Contabilidad_rubroswwds_8_tottipo3 ,
                                              AV98Contabilidad_rubroswwds_9_tftottipo_sels.Count ,
                                              AV100Contabilidad_rubroswwds_11_tftotdsc_sel ,
                                              AV99Contabilidad_rubroswwds_10_tftotdsc ,
                                              AV101Contabilidad_rubroswwds_12_tfrubcod ,
                                              AV102Contabilidad_rubroswwds_13_tfrubcod_to ,
                                              AV104Contabilidad_rubroswwds_15_tfrubdsc_sel ,
                                              AV103Contabilidad_rubroswwds_14_tfrubdsc ,
                                              AV106Contabilidad_rubroswwds_17_tfrubdsctot_sel ,
                                              AV105Contabilidad_rubroswwds_16_tfrubdsctot ,
                                              AV107Contabilidad_rubroswwds_18_tfrubord ,
                                              AV108Contabilidad_rubroswwds_19_tfrubord_to ,
                                              AV109Contabilidad_rubroswwds_20_tfrubsts_sels.Count ,
                                              A1928TotDsc ,
                                              A116RubCod ,
                                              A1822RubDsc ,
                                              A1823RubDscTot ,
                                              A117RubOrd ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV99Contabilidad_rubroswwds_10_tftotdsc = StringUtil.PadR( StringUtil.RTrim( AV99Contabilidad_rubroswwds_10_tftotdsc), 100, "%");
         lV103Contabilidad_rubroswwds_14_tfrubdsc = StringUtil.PadR( StringUtil.RTrim( AV103Contabilidad_rubroswwds_14_tfrubdsc), 100, "%");
         lV105Contabilidad_rubroswwds_16_tfrubdsctot = StringUtil.PadR( StringUtil.RTrim( AV105Contabilidad_rubroswwds_16_tfrubdsctot), 100, "%");
         /* Using cursor P00742 */
         pr_default.execute(0, new Object[] {AV91Contabilidad_rubroswwds_2_tottipo1, AV94Contabilidad_rubroswwds_5_tottipo2, AV97Contabilidad_rubroswwds_8_tottipo3, lV99Contabilidad_rubroswwds_10_tftotdsc, AV100Contabilidad_rubroswwds_11_tftotdsc_sel, AV101Contabilidad_rubroswwds_12_tfrubcod, AV102Contabilidad_rubroswwds_13_tfrubcod_to, lV103Contabilidad_rubroswwds_14_tfrubdsc, AV104Contabilidad_rubroswwds_15_tfrubdsc_sel, lV105Contabilidad_rubroswwds_16_tfrubdsctot, AV106Contabilidad_rubroswwds_17_tfrubdsctot_sel, AV107Contabilidad_rubroswwds_18_tfrubord, AV108Contabilidad_rubroswwds_19_tfrubord_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A115TotRub = P00742_A115TotRub[0];
            A1829RubSts = P00742_A1829RubSts[0];
            A117RubOrd = P00742_A117RubOrd[0];
            A1823RubDscTot = P00742_A1823RubDscTot[0];
            A1822RubDsc = P00742_A1822RubDsc[0];
            A116RubCod = P00742_A116RubCod[0];
            A1928TotDsc = P00742_A1928TotDsc[0];
            A114TotTipo = P00742_A114TotTipo[0];
            A1928TotDsc = P00742_A1928TotDsc[0];
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
            if ( A1829RubSts == 1 )
            {
               AV13RubStsDescription = "ACTIVO";
            }
            else if ( A1829RubSts == 0 )
            {
               AV13RubStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H740( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12TotTipoDescription, "")), 30, Gx_line+10, 152, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1928TotDsc, "")), 156, Gx_line+10, 278, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A116RubCod), "ZZZZZ9")), 282, Gx_line+10, 343, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1822RubDsc, "")), 347, Gx_line+10, 469, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1823RubDscTot, "")), 473, Gx_line+10, 595, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A117RubOrd), "Z9")), 599, Gx_line+10, 660, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13RubStsDescription, "")), 664, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV28Session.Get("Contabilidad.RubrosWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.RubrosWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("Contabilidad.RubrosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV110GXV3 = 1;
         while ( AV110GXV3 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV110GXV3));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTOTTIPO_SEL") == 0 )
            {
               AV32TFTotTipo_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV34TFTotTipo_Sels.FromJSonString(AV32TFTotTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTOTDSC") == 0 )
            {
               AV76TFTotDsc = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTOTDSC_SEL") == 0 )
            {
               AV77TFTotDsc_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBCOD") == 0 )
            {
               AV38TFRubCod = (int)(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."));
               AV39TFRubCod_To = (int)(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBDSC") == 0 )
            {
               AV40TFRubDsc = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBDSC_SEL") == 0 )
            {
               AV41TFRubDsc_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBDSCTOT") == 0 )
            {
               AV42TFRubDscTot = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBDSCTOT_SEL") == 0 )
            {
               AV43TFRubDscTot_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBORD") == 0 )
            {
               AV44TFRubOrd = (short)(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."));
               AV45TFRubOrd_To = (short)(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBSTS_SEL") == 0 )
            {
               AV46TFRubSts_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV48TFRubSts_Sels.FromJSonString(AV46TFRubSts_SelsJson, null);
            }
            AV110GXV3 = (int)(AV110GXV3+1);
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

      protected void H740( bool bFoot ,
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
                  AV64PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV61DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV59AppName = "DVelop Software Solutions";
               AV65Phone = "+1 550 8923";
               AV63Mail = "info@mail.com";
               AV67Website = "http://www.web.com";
               AV56AddressLine1 = "French Boulevard 2859";
               AV57AddressLine2 = "Downtown";
               AV58AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV66Title = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV68TotTipo1 = "";
         AV71FilterTotTipo1ValueDescription = "";
         AV70FilterTotTipoValueDescription = "";
         AV20DynamicFiltersSelector2 = "";
         AV72TotTipo2 = "";
         AV73FilterTotTipo2ValueDescription = "";
         AV24DynamicFiltersSelector3 = "";
         AV74TotTipo3 = "";
         AV75FilterTotTipo3ValueDescription = "";
         AV34TFTotTipo_Sels = new GxSimpleCollection<string>();
         AV32TFTotTipo_SelsJson = "";
         AV35TFTotTipo_Sel = "";
         AV33TFTotTipo_SelDscs = "";
         AV50FilterTFTotTipo_SelValueDescription = "";
         AV77TFTotDsc_Sel = "";
         AV76TFTotDsc = "";
         AV52TFRubCod_To_Description = "";
         AV41TFRubDsc_Sel = "";
         AV40TFRubDsc = "";
         AV43TFRubDscTot_Sel = "";
         AV42TFRubDscTot = "";
         AV53TFRubOrd_To_Description = "";
         AV48TFRubSts_Sels = new GxSimpleCollection<short>();
         AV46TFRubSts_SelsJson = "";
         AV47TFRubSts_SelDscs = "";
         AV54FilterTFRubSts_SelValueDescription = "";
         AV90Contabilidad_rubroswwds_1_dynamicfiltersselector1 = "";
         AV91Contabilidad_rubroswwds_2_tottipo1 = "";
         AV93Contabilidad_rubroswwds_4_dynamicfiltersselector2 = "";
         AV94Contabilidad_rubroswwds_5_tottipo2 = "";
         AV96Contabilidad_rubroswwds_7_dynamicfiltersselector3 = "";
         AV97Contabilidad_rubroswwds_8_tottipo3 = "";
         AV98Contabilidad_rubroswwds_9_tftottipo_sels = new GxSimpleCollection<string>();
         AV99Contabilidad_rubroswwds_10_tftotdsc = "";
         AV100Contabilidad_rubroswwds_11_tftotdsc_sel = "";
         AV103Contabilidad_rubroswwds_14_tfrubdsc = "";
         AV104Contabilidad_rubroswwds_15_tfrubdsc_sel = "";
         AV105Contabilidad_rubroswwds_16_tfrubdsctot = "";
         AV106Contabilidad_rubroswwds_17_tfrubdsctot_sel = "";
         AV109Contabilidad_rubroswwds_20_tfrubsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV99Contabilidad_rubroswwds_10_tftotdsc = "";
         lV103Contabilidad_rubroswwds_14_tfrubdsc = "";
         lV105Contabilidad_rubroswwds_16_tfrubdsctot = "";
         A114TotTipo = "";
         A1928TotDsc = "";
         A1822RubDsc = "";
         A1823RubDscTot = "";
         P00742_A115TotRub = new int[1] ;
         P00742_A1829RubSts = new short[1] ;
         P00742_A117RubOrd = new short[1] ;
         P00742_A1823RubDscTot = new string[] {""} ;
         P00742_A1822RubDsc = new string[] {""} ;
         P00742_A116RubCod = new int[1] ;
         P00742_A1928TotDsc = new string[] {""} ;
         P00742_A114TotTipo = new string[] {""} ;
         AV12TotTipoDescription = "";
         AV13RubStsDescription = "";
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV64PageInfo = "";
         AV61DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV59AppName = "";
         AV65Phone = "";
         AV63Mail = "";
         AV67Website = "";
         AV56AddressLine1 = "";
         AV57AddressLine2 = "";
         AV58AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rubroswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00742_A115TotRub, P00742_A1829RubSts, P00742_A117RubOrd, P00742_A1823RubDscTot, P00742_A1822RubDsc, P00742_A116RubCod, P00742_A1928TotDsc, P00742_A114TotTipo
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
      private short AV44TFRubOrd ;
      private short AV45TFRubOrd_To ;
      private short AV49TFRubSts_Sel ;
      private short AV107Contabilidad_rubroswwds_18_tfrubord ;
      private short AV108Contabilidad_rubroswwds_19_tfrubord_to ;
      private short A1829RubSts ;
      private short A117RubOrd ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV87GXV1 ;
      private int AV38TFRubCod ;
      private int AV39TFRubCod_To ;
      private int AV88GXV2 ;
      private int AV101Contabilidad_rubroswwds_12_tfrubcod ;
      private int AV102Contabilidad_rubroswwds_13_tfrubcod_to ;
      private int AV98Contabilidad_rubroswwds_9_tftottipo_sels_Count ;
      private int AV109Contabilidad_rubroswwds_20_tfrubsts_sels_Count ;
      private int A116RubCod ;
      private int A115TotRub ;
      private int AV110GXV3 ;
      private long AV55i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV68TotTipo1 ;
      private string AV72TotTipo2 ;
      private string AV74TotTipo3 ;
      private string AV35TFTotTipo_Sel ;
      private string AV77TFTotDsc_Sel ;
      private string AV76TFTotDsc ;
      private string AV41TFRubDsc_Sel ;
      private string AV40TFRubDsc ;
      private string AV43TFRubDscTot_Sel ;
      private string AV42TFRubDscTot ;
      private string AV91Contabilidad_rubroswwds_2_tottipo1 ;
      private string AV94Contabilidad_rubroswwds_5_tottipo2 ;
      private string AV97Contabilidad_rubroswwds_8_tottipo3 ;
      private string AV99Contabilidad_rubroswwds_10_tftotdsc ;
      private string AV100Contabilidad_rubroswwds_11_tftotdsc_sel ;
      private string AV103Contabilidad_rubroswwds_14_tfrubdsc ;
      private string AV104Contabilidad_rubroswwds_15_tfrubdsc_sel ;
      private string AV105Contabilidad_rubroswwds_16_tfrubdsctot ;
      private string AV106Contabilidad_rubroswwds_17_tfrubdsctot_sel ;
      private string scmdbuf ;
      private string lV99Contabilidad_rubroswwds_10_tftotdsc ;
      private string lV103Contabilidad_rubroswwds_14_tfrubdsc ;
      private string lV105Contabilidad_rubroswwds_16_tfrubdsctot ;
      private string A114TotTipo ;
      private string A1928TotDsc ;
      private string A1822RubDsc ;
      private string A1823RubDscTot ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV92Contabilidad_rubroswwds_3_dynamicfiltersenabled2 ;
      private bool AV95Contabilidad_rubroswwds_6_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV32TFTotTipo_SelsJson ;
      private string AV46TFRubSts_SelsJson ;
      private string AV66Title ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV71FilterTotTipo1ValueDescription ;
      private string AV70FilterTotTipoValueDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV73FilterTotTipo2ValueDescription ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV75FilterTotTipo3ValueDescription ;
      private string AV33TFTotTipo_SelDscs ;
      private string AV50FilterTFTotTipo_SelValueDescription ;
      private string AV52TFRubCod_To_Description ;
      private string AV53TFRubOrd_To_Description ;
      private string AV47TFRubSts_SelDscs ;
      private string AV54FilterTFRubSts_SelValueDescription ;
      private string AV90Contabilidad_rubroswwds_1_dynamicfiltersselector1 ;
      private string AV93Contabilidad_rubroswwds_4_dynamicfiltersselector2 ;
      private string AV96Contabilidad_rubroswwds_7_dynamicfiltersselector3 ;
      private string AV12TotTipoDescription ;
      private string AV13RubStsDescription ;
      private string AV64PageInfo ;
      private string AV61DateInfo ;
      private string AV59AppName ;
      private string AV65Phone ;
      private string AV63Mail ;
      private string AV67Website ;
      private string AV56AddressLine1 ;
      private string AV57AddressLine2 ;
      private string AV58AddressLine3 ;
      private GxSimpleCollection<short> AV48TFRubSts_Sels ;
      private GxSimpleCollection<short> AV109Contabilidad_rubroswwds_20_tfrubsts_sels ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00742_A115TotRub ;
      private short[] P00742_A1829RubSts ;
      private short[] P00742_A117RubOrd ;
      private string[] P00742_A1823RubDscTot ;
      private string[] P00742_A1822RubDsc ;
      private int[] P00742_A116RubCod ;
      private string[] P00742_A1928TotDsc ;
      private string[] P00742_A114TotTipo ;
      private GxSimpleCollection<string> AV34TFTotTipo_Sels ;
      private GxSimpleCollection<string> AV98Contabilidad_rubroswwds_9_tftottipo_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
   }

   public class rubroswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00742( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV98Contabilidad_rubroswwds_9_tftottipo_sels ,
                                             short A1829RubSts ,
                                             GxSimpleCollection<short> AV109Contabilidad_rubroswwds_20_tfrubsts_sels ,
                                             string AV90Contabilidad_rubroswwds_1_dynamicfiltersselector1 ,
                                             string AV91Contabilidad_rubroswwds_2_tottipo1 ,
                                             bool AV92Contabilidad_rubroswwds_3_dynamicfiltersenabled2 ,
                                             string AV93Contabilidad_rubroswwds_4_dynamicfiltersselector2 ,
                                             string AV94Contabilidad_rubroswwds_5_tottipo2 ,
                                             bool AV95Contabilidad_rubroswwds_6_dynamicfiltersenabled3 ,
                                             string AV96Contabilidad_rubroswwds_7_dynamicfiltersselector3 ,
                                             string AV97Contabilidad_rubroswwds_8_tottipo3 ,
                                             int AV98Contabilidad_rubroswwds_9_tftottipo_sels_Count ,
                                             string AV100Contabilidad_rubroswwds_11_tftotdsc_sel ,
                                             string AV99Contabilidad_rubroswwds_10_tftotdsc ,
                                             int AV101Contabilidad_rubroswwds_12_tfrubcod ,
                                             int AV102Contabilidad_rubroswwds_13_tfrubcod_to ,
                                             string AV104Contabilidad_rubroswwds_15_tfrubdsc_sel ,
                                             string AV103Contabilidad_rubroswwds_14_tfrubdsc ,
                                             string AV106Contabilidad_rubroswwds_17_tfrubdsctot_sel ,
                                             string AV105Contabilidad_rubroswwds_16_tfrubdsctot ,
                                             short AV107Contabilidad_rubroswwds_18_tfrubord ,
                                             short AV108Contabilidad_rubroswwds_19_tfrubord_to ,
                                             int AV109Contabilidad_rubroswwds_20_tfrubsts_sels_Count ,
                                             string A1928TotDsc ,
                                             int A116RubCod ,
                                             string A1822RubDsc ,
                                             string A1823RubDscTot ,
                                             short A117RubOrd ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[13];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[TotRub], T1.[RubSts], T1.[RubOrd], T1.[RubDscTot], T1.[RubDsc], T1.[RubCod], T2.[TotDsc], T1.[TotTipo] FROM ([CBRUBROS] T1 INNER JOIN [CBRUBROST] T2 ON T2.[TotTipo] = T1.[TotTipo] AND T2.[TotRub] = T1.[TotRub])";
         if ( ( StringUtil.StrCmp(AV90Contabilidad_rubroswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Contabilidad_rubroswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV91Contabilidad_rubroswwds_2_tottipo1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( AV92Contabilidad_rubroswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Contabilidad_rubroswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Contabilidad_rubroswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV94Contabilidad_rubroswwds_5_tottipo2)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV95Contabilidad_rubroswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Contabilidad_rubroswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Contabilidad_rubroswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV97Contabilidad_rubroswwds_8_tottipo3)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV98Contabilidad_rubroswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV98Contabilidad_rubroswwds_9_tftottipo_sels, "T1.[TotTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Contabilidad_rubroswwds_11_tftotdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Contabilidad_rubroswwds_10_tftotdsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TotDsc] like @lV99Contabilidad_rubroswwds_10_tftotdsc)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Contabilidad_rubroswwds_11_tftotdsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TotDsc] = @AV100Contabilidad_rubroswwds_11_tftotdsc_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV101Contabilidad_rubroswwds_12_tfrubcod) )
         {
            AddWhere(sWhereString, "(T1.[RubCod] >= @AV101Contabilidad_rubroswwds_12_tfrubcod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV102Contabilidad_rubroswwds_13_tfrubcod_to) )
         {
            AddWhere(sWhereString, "(T1.[RubCod] <= @AV102Contabilidad_rubroswwds_13_tfrubcod_to)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Contabilidad_rubroswwds_15_tfrubdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Contabilidad_rubroswwds_14_tfrubdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[RubDsc] like @lV103Contabilidad_rubroswwds_14_tfrubdsc)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Contabilidad_rubroswwds_15_tfrubdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[RubDsc] = @AV104Contabilidad_rubroswwds_15_tfrubdsc_sel)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Contabilidad_rubroswwds_17_tfrubdsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Contabilidad_rubroswwds_16_tfrubdsctot)) ) )
         {
            AddWhere(sWhereString, "(T1.[RubDscTot] like @lV105Contabilidad_rubroswwds_16_tfrubdsctot)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Contabilidad_rubroswwds_17_tfrubdsctot_sel)) )
         {
            AddWhere(sWhereString, "(T1.[RubDscTot] = @AV106Contabilidad_rubroswwds_17_tfrubdsctot_sel)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (0==AV107Contabilidad_rubroswwds_18_tfrubord) )
         {
            AddWhere(sWhereString, "(T1.[RubOrd] >= @AV107Contabilidad_rubroswwds_18_tfrubord)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV108Contabilidad_rubroswwds_19_tfrubord_to) )
         {
            AddWhere(sWhereString, "(T1.[RubOrd] <= @AV108Contabilidad_rubroswwds_19_tfrubord_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV109Contabilidad_rubroswwds_20_tfrubsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV109Contabilidad_rubroswwds_20_tfrubsts_sels, "T1.[RubSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubDsc]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TotTipo]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TotTipo] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[TotDsc]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[TotDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubCod]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubCod] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubDscTot]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubDscTot] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubOrd]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubOrd] DESC";
         }
         else if ( ( AV10OrderedBy == 7 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubSts]";
         }
         else if ( ( AV10OrderedBy == 7 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubSts] DESC";
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
                     return conditional_P00742(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (short)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP00742;
          prmP00742 = new Object[] {
          new ParDef("@AV91Contabilidad_rubroswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV94Contabilidad_rubroswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV97Contabilidad_rubroswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@lV99Contabilidad_rubroswwds_10_tftotdsc",GXType.NChar,100,0) ,
          new ParDef("@AV100Contabilidad_rubroswwds_11_tftotdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV101Contabilidad_rubroswwds_12_tfrubcod",GXType.Int32,6,0) ,
          new ParDef("@AV102Contabilidad_rubroswwds_13_tfrubcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV103Contabilidad_rubroswwds_14_tfrubdsc",GXType.NChar,100,0) ,
          new ParDef("@AV104Contabilidad_rubroswwds_15_tfrubdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV105Contabilidad_rubroswwds_16_tfrubdsctot",GXType.NChar,100,0) ,
          new ParDef("@AV106Contabilidad_rubroswwds_17_tfrubdsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV107Contabilidad_rubroswwds_18_tfrubord",GXType.Int16,2,0) ,
          new ParDef("@AV108Contabilidad_rubroswwds_19_tfrubord_to",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00742", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00742,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 3);
                return;
       }
    }

 }

}
