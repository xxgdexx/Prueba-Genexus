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
   public class lineaswwexportreport : GXWebProcedure
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

      public lineaswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public lineaswwexportreport( IGxContext context )
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
         lineaswwexportreport objlineaswwexportreport;
         objlineaswwexportreport = new lineaswwexportreport();
         objlineaswwexportreport.context.SetSubmitInitialConfig(context);
         objlineaswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlineaswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((lineaswwexportreport)stateInfo).executePrivate();
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
            AV69Title = "Lista de Lineas";
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
            H770( true, 0) ;
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
               AV71TotTipo1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71TotTipo1)) )
               {
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV71TotTipo1), "BAL") == 0 )
                  {
                     AV74FilterTotTipo1ValueDescription = "Estado de Situación Financiera";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV71TotTipo1), "FUN") == 0 )
                  {
                     AV74FilterTotTipo1ValueDescription = "Estado de Resultados Integrales";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV71TotTipo1), "NAT") == 0 )
                  {
                     AV74FilterTotTipo1ValueDescription = "Estado de Ganancia y Perdidad";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV71TotTipo1), "COS") == 0 )
                  {
                     AV74FilterTotTipo1ValueDescription = "Registro de Costos";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV71TotTipo1), "RCC") == 0 )
                  {
                     AV74FilterTotTipo1ValueDescription = "Registro de Costos / Centro de Costos";
                  }
                  AV73FilterTotTipoValueDescription = AV74FilterTotTipo1ValueDescription;
                  H770( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Tipo de Reporte", 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73FilterTotTipoValueDescription, "")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TOTTIPO") == 0 )
               {
                  AV75TotTipo2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75TotTipo2)) )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Trim( AV75TotTipo2), "BAL") == 0 )
                     {
                        AV76FilterTotTipo2ValueDescription = "Estado de Situación Financiera";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV75TotTipo2), "FUN") == 0 )
                     {
                        AV76FilterTotTipo2ValueDescription = "Estado de Resultados Integrales";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV75TotTipo2), "NAT") == 0 )
                     {
                        AV76FilterTotTipo2ValueDescription = "Estado de Ganancia y Perdidad";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV75TotTipo2), "COS") == 0 )
                     {
                        AV76FilterTotTipo2ValueDescription = "Registro de Costos";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV75TotTipo2), "RCC") == 0 )
                     {
                        AV76FilterTotTipo2ValueDescription = "Registro de Costos / Centro de Costos";
                     }
                     AV73FilterTotTipoValueDescription = AV76FilterTotTipo2ValueDescription;
                     H770( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Tipo de Reporte", 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73FilterTotTipoValueDescription, "")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TOTTIPO") == 0 )
                  {
                     AV77TotTipo3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77TotTipo3)) )
                     {
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV77TotTipo3), "BAL") == 0 )
                        {
                           AV78FilterTotTipo3ValueDescription = "Estado de Situación Financiera";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV77TotTipo3), "FUN") == 0 )
                        {
                           AV78FilterTotTipo3ValueDescription = "Estado de Resultados Integrales";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV77TotTipo3), "NAT") == 0 )
                        {
                           AV78FilterTotTipo3ValueDescription = "Estado de Ganancia y Perdidad";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV77TotTipo3), "COS") == 0 )
                        {
                           AV78FilterTotTipo3ValueDescription = "Registro de Costos";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV77TotTipo3), "RCC") == 0 )
                        {
                           AV78FilterTotTipo3ValueDescription = "Registro de Costos / Centro de Costos";
                        }
                        AV73FilterTotTipoValueDescription = AV78FilterTotTipo3ValueDescription;
                        H770( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText("Tipo de Reporte", 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73FilterTotTipoValueDescription, "")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         AV34TFTotTipo_Sels.FromJSonString(AV32TFTotTipo_SelsJson, null);
         if ( ! ( AV34TFTotTipo_Sels.Count == 0 ) )
         {
            AV58i = 1;
            AV83GXV1 = 1;
            while ( AV83GXV1 <= AV34TFTotTipo_Sels.Count )
            {
               AV35TFTotTipo_Sel = AV34TFTotTipo_Sels.GetString(AV83GXV1);
               if ( AV58i == 1 )
               {
                  AV33TFTotTipo_SelDscs = "";
               }
               else
               {
                  AV33TFTotTipo_SelDscs += ", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "BAL") == 0 )
               {
                  AV52FilterTFTotTipo_SelValueDescription = "Estado de Situación Financiera";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "FUN") == 0 )
               {
                  AV52FilterTFTotTipo_SelValueDescription = "Estado de Resultados Integrales";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "NAT") == 0 )
               {
                  AV52FilterTFTotTipo_SelValueDescription = "Estado de Ganancia y Perdidad";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "COS") == 0 )
               {
                  AV52FilterTFTotTipo_SelValueDescription = "Registro de Costos";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFTotTipo_Sel), "RCC") == 0 )
               {
                  AV52FilterTFTotTipo_SelValueDescription = "Registro de Costos / Centro de Costos";
               }
               AV33TFTotTipo_SelDscs += AV52FilterTFTotTipo_SelValueDescription;
               AV58i = (long)(AV58i+1);
               AV83GXV1 = (int)(AV83GXV1+1);
            }
            H770( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo de Reporte", 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFTotTipo_SelDscs, "")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV36TFTotRub) && (0==AV37TFTotRub_To) ) )
         {
            H770( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Rubro Totales", 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36TFTotRub), "ZZZZZ9")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV53TFTotRub_To_Description = StringUtil.Format( "%1 (%2)", "Codigo Rubro Totales", "Hasta", "", "", "", "", "", "", "");
            H770( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53TFTotRub_To_Description, "")), 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37TFTotRub_To), "ZZZZZ9")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV38TFRubCod) && (0==AV39TFRubCod_To) ) )
         {
            H770( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Rubro", 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TFRubCod), "ZZZZZ9")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV54TFRubCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo Rubro", "Hasta", "", "", "", "", "", "", "");
            H770( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54TFRubCod_To_Description, "")), 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV39TFRubCod_To), "ZZZZZ9")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV40TFRubLinCod) && (0==AV41TFRubLinCod_To) ) )
         {
            H770( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Linea", 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40TFRubLinCod), "ZZZZZ9")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV55TFRubLinCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo Linea", "Hasta", "", "", "", "", "", "", "");
            H770( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TFRubLinCod_To_Description, "")), 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV41TFRubLinCod_To), "ZZZZZ9")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFRubLinDsc_Sel)) )
         {
            H770( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Linea", 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFRubLinDsc_Sel, "")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFRubLinDsc)) )
            {
               H770( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Linea", 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFRubLinDsc, "")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFRubLinDscTot_Sel)) )
         {
            H770( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Totales Linea", 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFRubLinDscTot_Sel, "")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFRubLinDscTot)) )
            {
               H770( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Totales Linea", 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFRubLinDscTot, "")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (0==AV46TFRubLinOrd) && (0==AV47TFRubLinOrd_To) ) )
         {
            H770( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("N° Orden", 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV46TFRubLinOrd), "Z9")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV56TFRubLinOrd_To_Description = StringUtil.Format( "%1 (%2)", "N° Orden", "Hasta", "", "", "", "", "", "", "");
            H770( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56TFRubLinOrd_To_Description, "")), 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV47TFRubLinOrd_To), "Z9")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV50TFRubLinSts_Sels.FromJSonString(AV48TFRubLinSts_SelsJson, null);
         if ( ! ( AV50TFRubLinSts_Sels.Count == 0 ) )
         {
            AV58i = 1;
            AV84GXV2 = 1;
            while ( AV84GXV2 <= AV50TFRubLinSts_Sels.Count )
            {
               AV51TFRubLinSts_Sel = (short)(AV50TFRubLinSts_Sels.GetNumeric(AV84GXV2));
               if ( AV58i == 1 )
               {
                  AV49TFRubLinSts_SelDscs = "";
               }
               else
               {
                  AV49TFRubLinSts_SelDscs += ", ";
               }
               if ( AV51TFRubLinSts_Sel == 1 )
               {
                  AV57FilterTFRubLinSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV51TFRubLinSts_Sel == 0 )
               {
                  AV57FilterTFRubLinSts_SelValueDescription = "INACTIVO";
               }
               AV49TFRubLinSts_SelDscs += AV57FilterTFRubLinSts_SelValueDescription;
               AV58i = (long)(AV58i+1);
               AV84GXV2 = (int)(AV84GXV2+1);
            }
            H770( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 216, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFRubLinSts_SelDscs, "")), 216, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H770( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H770( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Tipo de Reporte", 30, Gx_line+10, 150, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo Rubro Totales", 154, Gx_line+10, 214, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo Rubro", 218, Gx_line+10, 279, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo Linea", 283, Gx_line+10, 344, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Linea", 348, Gx_line+10, 470, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Totales Linea", 474, Gx_line+10, 596, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("N° Orden", 600, Gx_line+10, 661, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 665, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV86Contabilidad_lineaswwds_1_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV87Contabilidad_lineaswwds_2_tottipo1 = AV71TotTipo1;
         AV88Contabilidad_lineaswwds_3_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV89Contabilidad_lineaswwds_4_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV90Contabilidad_lineaswwds_5_tottipo2 = AV75TotTipo2;
         AV91Contabilidad_lineaswwds_6_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV92Contabilidad_lineaswwds_7_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV93Contabilidad_lineaswwds_8_tottipo3 = AV77TotTipo3;
         AV94Contabilidad_lineaswwds_9_tftottipo_sels = AV34TFTotTipo_Sels;
         AV95Contabilidad_lineaswwds_10_tftotrub = AV36TFTotRub;
         AV96Contabilidad_lineaswwds_11_tftotrub_to = AV37TFTotRub_To;
         AV97Contabilidad_lineaswwds_12_tfrubcod = AV38TFRubCod;
         AV98Contabilidad_lineaswwds_13_tfrubcod_to = AV39TFRubCod_To;
         AV99Contabilidad_lineaswwds_14_tfrublincod = AV40TFRubLinCod;
         AV100Contabilidad_lineaswwds_15_tfrublincod_to = AV41TFRubLinCod_To;
         AV101Contabilidad_lineaswwds_16_tfrublindsc = AV42TFRubLinDsc;
         AV102Contabilidad_lineaswwds_17_tfrublindsc_sel = AV43TFRubLinDsc_Sel;
         AV103Contabilidad_lineaswwds_18_tfrublindsctot = AV44TFRubLinDscTot;
         AV104Contabilidad_lineaswwds_19_tfrublindsctot_sel = AV45TFRubLinDscTot_Sel;
         AV105Contabilidad_lineaswwds_20_tfrublinord = AV46TFRubLinOrd;
         AV106Contabilidad_lineaswwds_21_tfrublinord_to = AV47TFRubLinOrd_To;
         AV107Contabilidad_lineaswwds_22_tfrublinsts_sels = AV50TFRubLinSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A114TotTipo ,
                                              AV94Contabilidad_lineaswwds_9_tftottipo_sels ,
                                              A1828RubLinSts ,
                                              AV107Contabilidad_lineaswwds_22_tfrublinsts_sels ,
                                              AV86Contabilidad_lineaswwds_1_dynamicfiltersselector1 ,
                                              AV87Contabilidad_lineaswwds_2_tottipo1 ,
                                              AV88Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ,
                                              AV89Contabilidad_lineaswwds_4_dynamicfiltersselector2 ,
                                              AV90Contabilidad_lineaswwds_5_tottipo2 ,
                                              AV91Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ,
                                              AV92Contabilidad_lineaswwds_7_dynamicfiltersselector3 ,
                                              AV93Contabilidad_lineaswwds_8_tottipo3 ,
                                              AV94Contabilidad_lineaswwds_9_tftottipo_sels.Count ,
                                              AV95Contabilidad_lineaswwds_10_tftotrub ,
                                              AV96Contabilidad_lineaswwds_11_tftotrub_to ,
                                              AV97Contabilidad_lineaswwds_12_tfrubcod ,
                                              AV98Contabilidad_lineaswwds_13_tfrubcod_to ,
                                              AV99Contabilidad_lineaswwds_14_tfrublincod ,
                                              AV100Contabilidad_lineaswwds_15_tfrublincod_to ,
                                              AV102Contabilidad_lineaswwds_17_tfrublindsc_sel ,
                                              AV101Contabilidad_lineaswwds_16_tfrublindsc ,
                                              AV104Contabilidad_lineaswwds_19_tfrublindsctot_sel ,
                                              AV103Contabilidad_lineaswwds_18_tfrublindsctot ,
                                              AV105Contabilidad_lineaswwds_20_tfrublinord ,
                                              AV106Contabilidad_lineaswwds_21_tfrublinord_to ,
                                              AV107Contabilidad_lineaswwds_22_tfrublinsts_sels.Count ,
                                              A115TotRub ,
                                              A116RubCod ,
                                              A118RubLinCod ,
                                              A1826RubLinDsc ,
                                              A1827RubLinDscTot ,
                                              A119RubLinOrd ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV101Contabilidad_lineaswwds_16_tfrublindsc = StringUtil.PadR( StringUtil.RTrim( AV101Contabilidad_lineaswwds_16_tfrublindsc), 100, "%");
         lV103Contabilidad_lineaswwds_18_tfrublindsctot = StringUtil.PadR( StringUtil.RTrim( AV103Contabilidad_lineaswwds_18_tfrublindsctot), 100, "%");
         /* Using cursor P00772 */
         pr_default.execute(0, new Object[] {AV87Contabilidad_lineaswwds_2_tottipo1, AV90Contabilidad_lineaswwds_5_tottipo2, AV93Contabilidad_lineaswwds_8_tottipo3, AV95Contabilidad_lineaswwds_10_tftotrub, AV96Contabilidad_lineaswwds_11_tftotrub_to, AV97Contabilidad_lineaswwds_12_tfrubcod, AV98Contabilidad_lineaswwds_13_tfrubcod_to, AV99Contabilidad_lineaswwds_14_tfrublincod, AV100Contabilidad_lineaswwds_15_tfrublincod_to, lV101Contabilidad_lineaswwds_16_tfrublindsc, AV102Contabilidad_lineaswwds_17_tfrublindsc_sel, lV103Contabilidad_lineaswwds_18_tfrublindsctot, AV104Contabilidad_lineaswwds_19_tfrublindsctot_sel, AV105Contabilidad_lineaswwds_20_tfrublinord, AV106Contabilidad_lineaswwds_21_tfrublinord_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1828RubLinSts = P00772_A1828RubLinSts[0];
            A119RubLinOrd = P00772_A119RubLinOrd[0];
            A1827RubLinDscTot = P00772_A1827RubLinDscTot[0];
            A1826RubLinDsc = P00772_A1826RubLinDsc[0];
            A118RubLinCod = P00772_A118RubLinCod[0];
            A116RubCod = P00772_A116RubCod[0];
            A115TotRub = P00772_A115TotRub[0];
            A114TotTipo = P00772_A114TotTipo[0];
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
            if ( A1828RubLinSts == 1 )
            {
               AV13RubLinStsDescription = "ACTIVO";
            }
            else if ( A1828RubLinSts == 0 )
            {
               AV13RubLinStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H770( false, 35) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12TotTipoDescription, "")), 30, Gx_line+10, 150, Gx_line+24, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A115TotRub), "ZZZZZ9")), 154, Gx_line+10, 214, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A116RubCod), "ZZZZZ9")), 218, Gx_line+10, 279, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A118RubLinCod), "ZZZZZ9")), 283, Gx_line+10, 344, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1826RubLinDsc, "")), 348, Gx_line+10, 470, Gx_line+24, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1827RubLinDscTot, "")), 474, Gx_line+10, 596, Gx_line+24, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A119RubLinOrd), "Z9")), 600, Gx_line+10, 661, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13RubLinStsDescription, "")), 665, Gx_line+10, 787, Gx_line+24, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+34, 789, Gx_line+34, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+35);
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
         if ( StringUtil.StrCmp(AV28Session.Get("Contabilidad.LineasWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.LineasWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("Contabilidad.LineasWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV108GXV3 = 1;
         while ( AV108GXV3 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV108GXV3));
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
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBCOD") == 0 )
            {
               AV38TFRubCod = (int)(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."));
               AV39TFRubCod_To = (int)(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBLINCOD") == 0 )
            {
               AV40TFRubLinCod = (int)(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."));
               AV41TFRubLinCod_To = (int)(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBLINDSC") == 0 )
            {
               AV42TFRubLinDsc = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBLINDSC_SEL") == 0 )
            {
               AV43TFRubLinDsc_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBLINDSCTOT") == 0 )
            {
               AV44TFRubLinDscTot = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBLINDSCTOT_SEL") == 0 )
            {
               AV45TFRubLinDscTot_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBLINORD") == 0 )
            {
               AV46TFRubLinOrd = (short)(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."));
               AV47TFRubLinOrd_To = (short)(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBLINSTS_SEL") == 0 )
            {
               AV48TFRubLinSts_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV50TFRubLinSts_Sels.FromJSonString(AV48TFRubLinSts_SelsJson, null);
            }
            AV108GXV3 = (int)(AV108GXV3+1);
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

      protected void H770( bool bFoot ,
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
                  AV67PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV64DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+39);
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
               AV62AppName = "DVelop Software Solutions";
               AV68Phone = "+1 550 8923";
               AV66Mail = "info@mail.com";
               AV70Website = "http://www.web.com";
               AV59AddressLine1 = "French Boulevard 2859";
               AV60AddressLine2 = "Downtown";
               AV61AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+127);
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
         AV69Title = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV71TotTipo1 = "";
         AV74FilterTotTipo1ValueDescription = "";
         AV73FilterTotTipoValueDescription = "";
         AV20DynamicFiltersSelector2 = "";
         AV75TotTipo2 = "";
         AV76FilterTotTipo2ValueDescription = "";
         AV24DynamicFiltersSelector3 = "";
         AV77TotTipo3 = "";
         AV78FilterTotTipo3ValueDescription = "";
         AV34TFTotTipo_Sels = new GxSimpleCollection<string>();
         AV32TFTotTipo_SelsJson = "";
         AV35TFTotTipo_Sel = "";
         AV33TFTotTipo_SelDscs = "";
         AV52FilterTFTotTipo_SelValueDescription = "";
         AV53TFTotRub_To_Description = "";
         AV54TFRubCod_To_Description = "";
         AV55TFRubLinCod_To_Description = "";
         AV43TFRubLinDsc_Sel = "";
         AV42TFRubLinDsc = "";
         AV45TFRubLinDscTot_Sel = "";
         AV44TFRubLinDscTot = "";
         AV56TFRubLinOrd_To_Description = "";
         AV50TFRubLinSts_Sels = new GxSimpleCollection<short>();
         AV48TFRubLinSts_SelsJson = "";
         AV49TFRubLinSts_SelDscs = "";
         AV57FilterTFRubLinSts_SelValueDescription = "";
         AV86Contabilidad_lineaswwds_1_dynamicfiltersselector1 = "";
         AV87Contabilidad_lineaswwds_2_tottipo1 = "";
         AV89Contabilidad_lineaswwds_4_dynamicfiltersselector2 = "";
         AV90Contabilidad_lineaswwds_5_tottipo2 = "";
         AV92Contabilidad_lineaswwds_7_dynamicfiltersselector3 = "";
         AV93Contabilidad_lineaswwds_8_tottipo3 = "";
         AV94Contabilidad_lineaswwds_9_tftottipo_sels = new GxSimpleCollection<string>();
         AV101Contabilidad_lineaswwds_16_tfrublindsc = "";
         AV102Contabilidad_lineaswwds_17_tfrublindsc_sel = "";
         AV103Contabilidad_lineaswwds_18_tfrublindsctot = "";
         AV104Contabilidad_lineaswwds_19_tfrublindsctot_sel = "";
         AV107Contabilidad_lineaswwds_22_tfrublinsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV101Contabilidad_lineaswwds_16_tfrublindsc = "";
         lV103Contabilidad_lineaswwds_18_tfrublindsctot = "";
         A114TotTipo = "";
         A1826RubLinDsc = "";
         A1827RubLinDscTot = "";
         P00772_A1828RubLinSts = new short[1] ;
         P00772_A119RubLinOrd = new short[1] ;
         P00772_A1827RubLinDscTot = new string[] {""} ;
         P00772_A1826RubLinDsc = new string[] {""} ;
         P00772_A118RubLinCod = new int[1] ;
         P00772_A116RubCod = new int[1] ;
         P00772_A115TotRub = new int[1] ;
         P00772_A114TotTipo = new string[] {""} ;
         AV12TotTipoDescription = "";
         AV13RubLinStsDescription = "";
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV67PageInfo = "";
         AV64DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV62AppName = "";
         AV68Phone = "";
         AV66Mail = "";
         AV70Website = "";
         AV59AddressLine1 = "";
         AV60AddressLine2 = "";
         AV61AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.lineaswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00772_A1828RubLinSts, P00772_A119RubLinOrd, P00772_A1827RubLinDscTot, P00772_A1826RubLinDsc, P00772_A118RubLinCod, P00772_A116RubCod, P00772_A115TotRub, P00772_A114TotTipo
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
      private short AV46TFRubLinOrd ;
      private short AV47TFRubLinOrd_To ;
      private short AV51TFRubLinSts_Sel ;
      private short AV105Contabilidad_lineaswwds_20_tfrublinord ;
      private short AV106Contabilidad_lineaswwds_21_tfrublinord_to ;
      private short A1828RubLinSts ;
      private short A119RubLinOrd ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV83GXV1 ;
      private int AV36TFTotRub ;
      private int AV37TFTotRub_To ;
      private int AV38TFRubCod ;
      private int AV39TFRubCod_To ;
      private int AV40TFRubLinCod ;
      private int AV41TFRubLinCod_To ;
      private int AV84GXV2 ;
      private int AV95Contabilidad_lineaswwds_10_tftotrub ;
      private int AV96Contabilidad_lineaswwds_11_tftotrub_to ;
      private int AV97Contabilidad_lineaswwds_12_tfrubcod ;
      private int AV98Contabilidad_lineaswwds_13_tfrubcod_to ;
      private int AV99Contabilidad_lineaswwds_14_tfrublincod ;
      private int AV100Contabilidad_lineaswwds_15_tfrublincod_to ;
      private int AV94Contabilidad_lineaswwds_9_tftottipo_sels_Count ;
      private int AV107Contabilidad_lineaswwds_22_tfrublinsts_sels_Count ;
      private int A115TotRub ;
      private int A116RubCod ;
      private int A118RubLinCod ;
      private int AV108GXV3 ;
      private long AV58i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV71TotTipo1 ;
      private string AV75TotTipo2 ;
      private string AV77TotTipo3 ;
      private string AV35TFTotTipo_Sel ;
      private string AV43TFRubLinDsc_Sel ;
      private string AV42TFRubLinDsc ;
      private string AV45TFRubLinDscTot_Sel ;
      private string AV44TFRubLinDscTot ;
      private string AV87Contabilidad_lineaswwds_2_tottipo1 ;
      private string AV90Contabilidad_lineaswwds_5_tottipo2 ;
      private string AV93Contabilidad_lineaswwds_8_tottipo3 ;
      private string AV101Contabilidad_lineaswwds_16_tfrublindsc ;
      private string AV102Contabilidad_lineaswwds_17_tfrublindsc_sel ;
      private string AV103Contabilidad_lineaswwds_18_tfrublindsctot ;
      private string AV104Contabilidad_lineaswwds_19_tfrublindsctot_sel ;
      private string scmdbuf ;
      private string lV101Contabilidad_lineaswwds_16_tfrublindsc ;
      private string lV103Contabilidad_lineaswwds_18_tfrublindsctot ;
      private string A114TotTipo ;
      private string A1826RubLinDsc ;
      private string A1827RubLinDscTot ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV88Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ;
      private bool AV91Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV32TFTotTipo_SelsJson ;
      private string AV48TFRubLinSts_SelsJson ;
      private string AV69Title ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV74FilterTotTipo1ValueDescription ;
      private string AV73FilterTotTipoValueDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV76FilterTotTipo2ValueDescription ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV78FilterTotTipo3ValueDescription ;
      private string AV33TFTotTipo_SelDscs ;
      private string AV52FilterTFTotTipo_SelValueDescription ;
      private string AV53TFTotRub_To_Description ;
      private string AV54TFRubCod_To_Description ;
      private string AV55TFRubLinCod_To_Description ;
      private string AV56TFRubLinOrd_To_Description ;
      private string AV49TFRubLinSts_SelDscs ;
      private string AV57FilterTFRubLinSts_SelValueDescription ;
      private string AV86Contabilidad_lineaswwds_1_dynamicfiltersselector1 ;
      private string AV89Contabilidad_lineaswwds_4_dynamicfiltersselector2 ;
      private string AV92Contabilidad_lineaswwds_7_dynamicfiltersselector3 ;
      private string AV12TotTipoDescription ;
      private string AV13RubLinStsDescription ;
      private string AV67PageInfo ;
      private string AV64DateInfo ;
      private string AV62AppName ;
      private string AV68Phone ;
      private string AV66Mail ;
      private string AV70Website ;
      private string AV59AddressLine1 ;
      private string AV60AddressLine2 ;
      private string AV61AddressLine3 ;
      private GxSimpleCollection<short> AV50TFRubLinSts_Sels ;
      private GxSimpleCollection<short> AV107Contabilidad_lineaswwds_22_tfrublinsts_sels ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00772_A1828RubLinSts ;
      private short[] P00772_A119RubLinOrd ;
      private string[] P00772_A1827RubLinDscTot ;
      private string[] P00772_A1826RubLinDsc ;
      private int[] P00772_A118RubLinCod ;
      private int[] P00772_A116RubCod ;
      private int[] P00772_A115TotRub ;
      private string[] P00772_A114TotTipo ;
      private GxSimpleCollection<string> AV34TFTotTipo_Sels ;
      private GxSimpleCollection<string> AV94Contabilidad_lineaswwds_9_tftottipo_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
   }

   public class lineaswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00772( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV94Contabilidad_lineaswwds_9_tftottipo_sels ,
                                             short A1828RubLinSts ,
                                             GxSimpleCollection<short> AV107Contabilidad_lineaswwds_22_tfrublinsts_sels ,
                                             string AV86Contabilidad_lineaswwds_1_dynamicfiltersselector1 ,
                                             string AV87Contabilidad_lineaswwds_2_tottipo1 ,
                                             bool AV88Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ,
                                             string AV89Contabilidad_lineaswwds_4_dynamicfiltersselector2 ,
                                             string AV90Contabilidad_lineaswwds_5_tottipo2 ,
                                             bool AV91Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ,
                                             string AV92Contabilidad_lineaswwds_7_dynamicfiltersselector3 ,
                                             string AV93Contabilidad_lineaswwds_8_tottipo3 ,
                                             int AV94Contabilidad_lineaswwds_9_tftottipo_sels_Count ,
                                             int AV95Contabilidad_lineaswwds_10_tftotrub ,
                                             int AV96Contabilidad_lineaswwds_11_tftotrub_to ,
                                             int AV97Contabilidad_lineaswwds_12_tfrubcod ,
                                             int AV98Contabilidad_lineaswwds_13_tfrubcod_to ,
                                             int AV99Contabilidad_lineaswwds_14_tfrublincod ,
                                             int AV100Contabilidad_lineaswwds_15_tfrublincod_to ,
                                             string AV102Contabilidad_lineaswwds_17_tfrublindsc_sel ,
                                             string AV101Contabilidad_lineaswwds_16_tfrublindsc ,
                                             string AV104Contabilidad_lineaswwds_19_tfrublindsctot_sel ,
                                             string AV103Contabilidad_lineaswwds_18_tfrublindsctot ,
                                             short AV105Contabilidad_lineaswwds_20_tfrublinord ,
                                             short AV106Contabilidad_lineaswwds_21_tfrublinord_to ,
                                             int AV107Contabilidad_lineaswwds_22_tfrublinsts_sels_Count ,
                                             int A115TotRub ,
                                             int A116RubCod ,
                                             int A118RubLinCod ,
                                             string A1826RubLinDsc ,
                                             string A1827RubLinDscTot ,
                                             short A119RubLinOrd ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [RubLinSts], [RubLinOrd], [RubLinDscTot], [RubLinDsc], [RubLinCod], [RubCod], [TotRub], [TotTipo] FROM [CBRUBROSL]";
         if ( ( StringUtil.StrCmp(AV86Contabilidad_lineaswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Contabilidad_lineaswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV87Contabilidad_lineaswwds_2_tottipo1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( AV88Contabilidad_lineaswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Contabilidad_lineaswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Contabilidad_lineaswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV90Contabilidad_lineaswwds_5_tottipo2)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV91Contabilidad_lineaswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Contabilidad_lineaswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Contabilidad_lineaswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV93Contabilidad_lineaswwds_8_tottipo3)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV94Contabilidad_lineaswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV94Contabilidad_lineaswwds_9_tftottipo_sels, "[TotTipo] IN (", ")")+")");
         }
         if ( ! (0==AV95Contabilidad_lineaswwds_10_tftotrub) )
         {
            AddWhere(sWhereString, "([TotRub] >= @AV95Contabilidad_lineaswwds_10_tftotrub)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV96Contabilidad_lineaswwds_11_tftotrub_to) )
         {
            AddWhere(sWhereString, "([TotRub] <= @AV96Contabilidad_lineaswwds_11_tftotrub_to)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV97Contabilidad_lineaswwds_12_tfrubcod) )
         {
            AddWhere(sWhereString, "([RubCod] >= @AV97Contabilidad_lineaswwds_12_tfrubcod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV98Contabilidad_lineaswwds_13_tfrubcod_to) )
         {
            AddWhere(sWhereString, "([RubCod] <= @AV98Contabilidad_lineaswwds_13_tfrubcod_to)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV99Contabilidad_lineaswwds_14_tfrublincod) )
         {
            AddWhere(sWhereString, "([RubLinCod] >= @AV99Contabilidad_lineaswwds_14_tfrublincod)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV100Contabilidad_lineaswwds_15_tfrublincod_to) )
         {
            AddWhere(sWhereString, "([RubLinCod] <= @AV100Contabilidad_lineaswwds_15_tfrublincod_to)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabilidad_lineaswwds_17_tfrublindsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Contabilidad_lineaswwds_16_tfrublindsc)) ) )
         {
            AddWhere(sWhereString, "([RubLinDsc] like @lV101Contabilidad_lineaswwds_16_tfrublindsc)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabilidad_lineaswwds_17_tfrublindsc_sel)) )
         {
            AddWhere(sWhereString, "([RubLinDsc] = @AV102Contabilidad_lineaswwds_17_tfrublindsc_sel)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Contabilidad_lineaswwds_19_tfrublindsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Contabilidad_lineaswwds_18_tfrublindsctot)) ) )
         {
            AddWhere(sWhereString, "([RubLinDscTot] like @lV103Contabilidad_lineaswwds_18_tfrublindsctot)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Contabilidad_lineaswwds_19_tfrublindsctot_sel)) )
         {
            AddWhere(sWhereString, "([RubLinDscTot] = @AV104Contabilidad_lineaswwds_19_tfrublindsctot_sel)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV105Contabilidad_lineaswwds_20_tfrublinord) )
         {
            AddWhere(sWhereString, "([RubLinOrd] >= @AV105Contabilidad_lineaswwds_20_tfrublinord)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (0==AV106Contabilidad_lineaswwds_21_tfrublinord_to) )
         {
            AddWhere(sWhereString, "([RubLinOrd] <= @AV106Contabilidad_lineaswwds_21_tfrublinord_to)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV107Contabilidad_lineaswwds_22_tfrublinsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV107Contabilidad_lineaswwds_22_tfrublinsts_sels, "[RubLinSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [TotTipo], [TotRub], [RubCod], [RubLinCod]";
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
            scmdbuf += " ORDER BY [RubCod]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubCod] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubLinCod]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubLinCod] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubLinDsc]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubLinDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 7 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubLinDscTot]";
         }
         else if ( ( AV10OrderedBy == 7 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubLinDscTot] DESC";
         }
         else if ( ( AV10OrderedBy == 8 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubLinOrd]";
         }
         else if ( ( AV10OrderedBy == 8 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubLinOrd] DESC";
         }
         else if ( ( AV10OrderedBy == 9 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubLinSts]";
         }
         else if ( ( AV10OrderedBy == 9 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubLinSts] DESC";
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
                     return conditional_P00772(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] );
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
          Object[] prmP00772;
          prmP00772 = new Object[] {
          new ParDef("@AV87Contabilidad_lineaswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV90Contabilidad_lineaswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV93Contabilidad_lineaswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@AV95Contabilidad_lineaswwds_10_tftotrub",GXType.Int32,6,0) ,
          new ParDef("@AV96Contabilidad_lineaswwds_11_tftotrub_to",GXType.Int32,6,0) ,
          new ParDef("@AV97Contabilidad_lineaswwds_12_tfrubcod",GXType.Int32,6,0) ,
          new ParDef("@AV98Contabilidad_lineaswwds_13_tfrubcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV99Contabilidad_lineaswwds_14_tfrublincod",GXType.Int32,6,0) ,
          new ParDef("@AV100Contabilidad_lineaswwds_15_tfrublincod_to",GXType.Int32,6,0) ,
          new ParDef("@lV101Contabilidad_lineaswwds_16_tfrublindsc",GXType.NChar,100,0) ,
          new ParDef("@AV102Contabilidad_lineaswwds_17_tfrublindsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV103Contabilidad_lineaswwds_18_tfrublindsctot",GXType.NChar,100,0) ,
          new ParDef("@AV104Contabilidad_lineaswwds_19_tfrublindsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV105Contabilidad_lineaswwds_20_tfrublinord",GXType.Int16,2,0) ,
          new ParDef("@AV106Contabilidad_lineaswwds_21_tfrublinord_to",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00772", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00772,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 3);
                return;
       }
    }

 }

}
