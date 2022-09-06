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
namespace GeneXus.Programs.seguridad {
   public class cierremoduloswwexportreport : GXWebProcedure
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

      public cierremoduloswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cierremoduloswwexportreport( IGxContext context )
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
         cierremoduloswwexportreport objcierremoduloswwexportreport;
         objcierremoduloswwexportreport = new cierremoduloswwexportreport();
         objcierremoduloswwexportreport.context.SetSubmitInitialConfig(context);
         objcierremoduloswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcierremoduloswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cierremoduloswwexportreport)stateInfo).executePrivate();
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
            AV61Title = "Lista de Cierre Modulos";
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
            H1P0( true, 0) ;
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
         if ( ! (0==AV63CMModAno) )
         {
            H1P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Año", 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV63CMModAno), "ZZZ9")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV64CMModMes) )
         {
            if ( AV64CMModMes == 1 )
            {
               AV65FilterCMModMesValueDescription = "Enero";
            }
            else if ( AV64CMModMes == 2 )
            {
               AV65FilterCMModMesValueDescription = "Febrero";
            }
            else if ( AV64CMModMes == 3 )
            {
               AV65FilterCMModMesValueDescription = "Marzo";
            }
            else if ( AV64CMModMes == 4 )
            {
               AV65FilterCMModMesValueDescription = "Abril";
            }
            else if ( AV64CMModMes == 5 )
            {
               AV65FilterCMModMesValueDescription = "Mayo";
            }
            else if ( AV64CMModMes == 6 )
            {
               AV65FilterCMModMesValueDescription = "Junio";
            }
            else if ( AV64CMModMes == 7 )
            {
               AV65FilterCMModMesValueDescription = "Julio";
            }
            else if ( AV64CMModMes == 8 )
            {
               AV65FilterCMModMesValueDescription = "Agosto";
            }
            else if ( AV64CMModMes == 9 )
            {
               AV65FilterCMModMesValueDescription = "Setiembre";
            }
            else if ( AV64CMModMes == 10 )
            {
               AV65FilterCMModMesValueDescription = "Octubre";
            }
            else if ( AV64CMModMes == 11 )
            {
               AV65FilterCMModMesValueDescription = "Noviembre";
            }
            else if ( AV64CMModMes == 12 )
            {
               AV65FilterCMModMesValueDescription = "Diciembre";
            }
            H1P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Mes", 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65FilterCMModMesValueDescription, "")), 203, Gx_line+0, 814, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV32TFCMModAno) && (0==AV33TFCMModAno_To) ) )
         {
            H1P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Año", 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFCMModAno), "ZZZ9")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV46TFCMModAno_To_Description = StringUtil.Format( "%1 (%2)", "Año", "Hasta", "", "", "", "", "", "", "");
            H1P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TFCMModAno_To_Description, "")), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFCMModAno_To), "ZZZ9")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV71TFCMModMes_Sels.FromJSonString(AV69TFCMModMes_SelsJson, null);
         if ( ! ( AV71TFCMModMes_Sels.Count == 0 ) )
         {
            AV83i = 1;
            AV88GXV1 = 1;
            while ( AV88GXV1 <= AV71TFCMModMes_Sels.Count )
            {
               AV72TFCMModMes_Sel = (short)(AV71TFCMModMes_Sels.GetNumeric(AV88GXV1));
               if ( AV83i == 1 )
               {
                  AV70TFCMModMes_SelDscs = "";
               }
               else
               {
                  AV70TFCMModMes_SelDscs += ", ";
               }
               if ( AV72TFCMModMes_Sel == 1 )
               {
                  AV80FilterTFCMModMes_SelValueDescription = "Enero";
               }
               else if ( AV72TFCMModMes_Sel == 2 )
               {
                  AV80FilterTFCMModMes_SelValueDescription = "Febrero";
               }
               else if ( AV72TFCMModMes_Sel == 3 )
               {
                  AV80FilterTFCMModMes_SelValueDescription = "Marzo";
               }
               else if ( AV72TFCMModMes_Sel == 4 )
               {
                  AV80FilterTFCMModMes_SelValueDescription = "Abril";
               }
               else if ( AV72TFCMModMes_Sel == 5 )
               {
                  AV80FilterTFCMModMes_SelValueDescription = "Mayo";
               }
               else if ( AV72TFCMModMes_Sel == 6 )
               {
                  AV80FilterTFCMModMes_SelValueDescription = "Junio";
               }
               else if ( AV72TFCMModMes_Sel == 7 )
               {
                  AV80FilterTFCMModMes_SelValueDescription = "Julio";
               }
               else if ( AV72TFCMModMes_Sel == 8 )
               {
                  AV80FilterTFCMModMes_SelValueDescription = "Agosto";
               }
               else if ( AV72TFCMModMes_Sel == 9 )
               {
                  AV80FilterTFCMModMes_SelValueDescription = "Setiembre";
               }
               else if ( AV72TFCMModMes_Sel == 10 )
               {
                  AV80FilterTFCMModMes_SelValueDescription = "Octubre";
               }
               else if ( AV72TFCMModMes_Sel == 11 )
               {
                  AV80FilterTFCMModMes_SelValueDescription = "Noviembre";
               }
               else if ( AV72TFCMModMes_Sel == 12 )
               {
                  AV80FilterTFCMModMes_SelValueDescription = "Diciembre";
               }
               AV70TFCMModMes_SelDscs += AV80FilterTFCMModMes_SelValueDescription;
               AV83i = (long)(AV83i+1);
               AV88GXV1 = (int)(AV88GXV1+1);
            }
            H1P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Mes", 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70TFCMModMes_SelDscs, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV75TFCMModCod_Sels.FromJSonString(AV73TFCMModCod_SelsJson, null);
         if ( ! ( AV75TFCMModCod_Sels.Count == 0 ) )
         {
            AV83i = 1;
            AV89GXV2 = 1;
            while ( AV89GXV2 <= AV75TFCMModCod_Sels.Count )
            {
               AV31TFCMModCod_Sel = AV75TFCMModCod_Sels.GetString(AV89GXV2);
               if ( AV83i == 1 )
               {
                  AV74TFCMModCod_SelDscs = "";
               }
               else
               {
                  AV74TFCMModCod_SelDscs += ", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV31TFCMModCod_Sel), "ALM") == 0 )
               {
                  AV81FilterTFCMModCod_SelValueDescription = "Almacenes";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV31TFCMModCod_Sel), "CLI") == 0 )
               {
                  AV81FilterTFCMModCod_SelValueDescription = "Ventas";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV31TFCMModCod_Sel), "PRV") == 0 )
               {
                  AV81FilterTFCMModCod_SelValueDescription = "Compras";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV31TFCMModCod_Sel), "TES") == 0 )
               {
                  AV81FilterTFCMModCod_SelValueDescription = "Bancos";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV31TFCMModCod_Sel), "CON") == 0 )
               {
                  AV81FilterTFCMModCod_SelValueDescription = "Contabilidad";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV31TFCMModCod_Sel), "PRO") == 0 )
               {
                  AV81FilterTFCMModCod_SelValueDescription = "Produccion";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV31TFCMModCod_Sel), "PLA") == 0 )
               {
                  AV81FilterTFCMModCod_SelValueDescription = "Planilla";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV31TFCMModCod_Sel), "ACT") == 0 )
               {
                  AV81FilterTFCMModCod_SelValueDescription = "Activos Fijos";
               }
               AV74TFCMModCod_SelDscs += AV81FilterTFCMModCod_SelValueDescription;
               AV83i = (long)(AV83i+1);
               AV89GXV2 = (int)(AV89GXV2+1);
            }
            H1P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Modulo", 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74TFCMModCod_SelDscs, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV78TFCMModSts_Sels.FromJSonString(AV76TFCMModSts_SelsJson, null);
         if ( ! ( AV78TFCMModSts_Sels.Count == 0 ) )
         {
            AV83i = 1;
            AV90GXV3 = 1;
            while ( AV90GXV3 <= AV78TFCMModSts_Sels.Count )
            {
               AV79TFCMModSts_Sel = (short)(AV78TFCMModSts_Sels.GetNumeric(AV90GXV3));
               if ( AV83i == 1 )
               {
                  AV77TFCMModSts_SelDscs = "";
               }
               else
               {
                  AV77TFCMModSts_SelDscs += ", ";
               }
               if ( AV79TFCMModSts_Sel == 1 )
               {
                  AV82FilterTFCMModSts_SelValueDescription = "Abierto";
               }
               else if ( AV79TFCMModSts_Sel == 2 )
               {
                  AV82FilterTFCMModSts_SelValueDescription = "Cerrado";
               }
               AV77TFCMModSts_SelDscs += AV82FilterTFCMModSts_SelValueDescription;
               AV83i = (long)(AV83i+1);
               AV90GXV3 = (int)(AV90GXV3+1);
            }
            H1P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77TFCMModSts_SelDscs, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCMModUsuC_Sel)) )
         {
            H1P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Usuario Creación", 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFCMModUsuC_Sel, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCMModUsuC)) )
            {
               H1P0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuario Creación", 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFCMModUsuC, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV40TFCMModFecC) && (DateTime.MinValue==AV41TFCMModFecC_To) ) )
         {
            H1P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Fecha Creación", 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV40TFCMModFecC, "99/99/99"), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV49TFCMModFecC_To_Description = StringUtil.Format( "%1 (%2)", "Fecha Creación", "Hasta", "", "", "", "", "", "", "");
            H1P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFCMModFecC_To_Description, "")), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV41TFCMModFecC_To, "99/99/99"), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFCMModUsuM_Sel)) )
         {
            H1P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Usuario Modificación", 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFCMModUsuM_Sel, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFCMModUsuM)) )
            {
               H1P0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuario Modificación", 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFCMModUsuM, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV44TFCMModFecM) && (DateTime.MinValue==AV45TFCMModFecM_To) ) )
         {
            H1P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Fecha Modificación", 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV44TFCMModFecM, "99/99/99"), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV50TFCMModFecM_To_Description = StringUtil.Format( "%1 (%2)", "Fecha Modificación", "Hasta", "", "", "", "", "", "", "");
            H1P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFCMModFecM_To_Description, "")), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV45TFCMModFecM_To, "99/99/99"), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H1P0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H1P0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Año", 30, Gx_line+10, 121, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Mes", 125, Gx_line+10, 216, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Modulo", 220, Gx_line+10, 311, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 315, Gx_line+10, 406, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Usuario Creación", 410, Gx_line+10, 501, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Fecha Creación", 505, Gx_line+10, 596, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Usuario Modificación", 600, Gx_line+10, 691, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Fecha Modificación", 695, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV92Seguridad_cierremoduloswwds_1_cmmodano = AV63CMModAno;
         AV93Seguridad_cierremoduloswwds_2_cmmodmes = AV64CMModMes;
         AV94Seguridad_cierremoduloswwds_3_tfcmmodano = AV32TFCMModAno;
         AV95Seguridad_cierremoduloswwds_4_tfcmmodano_to = AV33TFCMModAno_To;
         AV96Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = AV71TFCMModMes_Sels;
         AV97Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = AV75TFCMModCod_Sels;
         AV98Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = AV78TFCMModSts_Sels;
         AV99Seguridad_cierremoduloswwds_8_tfcmmodusuc = AV38TFCMModUsuC;
         AV100Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = AV39TFCMModUsuC_Sel;
         AV101Seguridad_cierremoduloswwds_10_tfcmmodfecc = AV40TFCMModFecC;
         AV102Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = AV41TFCMModFecC_To;
         AV103Seguridad_cierremoduloswwds_12_tfcmmodusum = AV42TFCMModUsuM;
         AV104Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = AV43TFCMModUsuM_Sel;
         AV105Seguridad_cierremoduloswwds_14_tfcmmodfecm = AV44TFCMModFecM;
         AV106Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = AV45TFCMModFecM_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A75CMModMes ,
                                              AV96Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ,
                                              A73CMModCod ,
                                              AV97Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ,
                                              A640CMModSts ,
                                              AV98Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ,
                                              AV92Seguridad_cierremoduloswwds_1_cmmodano ,
                                              AV93Seguridad_cierremoduloswwds_2_cmmodmes ,
                                              AV94Seguridad_cierremoduloswwds_3_tfcmmodano ,
                                              AV95Seguridad_cierremoduloswwds_4_tfcmmodano_to ,
                                              AV96Seguridad_cierremoduloswwds_5_tfcmmodmes_sels.Count ,
                                              AV97Seguridad_cierremoduloswwds_6_tfcmmodcod_sels.Count ,
                                              AV98Seguridad_cierremoduloswwds_7_tfcmmodsts_sels.Count ,
                                              AV100Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ,
                                              AV99Seguridad_cierremoduloswwds_8_tfcmmodusuc ,
                                              AV101Seguridad_cierremoduloswwds_10_tfcmmodfecc ,
                                              AV102Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ,
                                              AV104Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ,
                                              AV103Seguridad_cierremoduloswwds_12_tfcmmodusum ,
                                              AV105Seguridad_cierremoduloswwds_14_tfcmmodfecm ,
                                              AV106Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ,
                                              A74CMModAno ,
                                              A641CMModUsuC ,
                                              A638CMModFecC ,
                                              A642CMModUsuM ,
                                              A639CMModFecM ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV99Seguridad_cierremoduloswwds_8_tfcmmodusuc = StringUtil.PadR( StringUtil.RTrim( AV99Seguridad_cierremoduloswwds_8_tfcmmodusuc), 10, "%");
         lV103Seguridad_cierremoduloswwds_12_tfcmmodusum = StringUtil.PadR( StringUtil.RTrim( AV103Seguridad_cierremoduloswwds_12_tfcmmodusum), 10, "%");
         /* Using cursor P001P2 */
         pr_default.execute(0, new Object[] {AV92Seguridad_cierremoduloswwds_1_cmmodano, AV93Seguridad_cierremoduloswwds_2_cmmodmes, AV94Seguridad_cierremoduloswwds_3_tfcmmodano, AV95Seguridad_cierremoduloswwds_4_tfcmmodano_to, lV99Seguridad_cierremoduloswwds_8_tfcmmodusuc, AV100Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel, AV101Seguridad_cierremoduloswwds_10_tfcmmodfecc, AV102Seguridad_cierremoduloswwds_11_tfcmmodfecc_to, lV103Seguridad_cierremoduloswwds_12_tfcmmodusum, AV104Seguridad_cierremoduloswwds_13_tfcmmodusum_sel, AV105Seguridad_cierremoduloswwds_14_tfcmmodfecm, AV106Seguridad_cierremoduloswwds_15_tfcmmodfecm_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A639CMModFecM = P001P2_A639CMModFecM[0];
            A642CMModUsuM = P001P2_A642CMModUsuM[0];
            A638CMModFecC = P001P2_A638CMModFecC[0];
            A641CMModUsuC = P001P2_A641CMModUsuC[0];
            A640CMModSts = P001P2_A640CMModSts[0];
            A73CMModCod = P001P2_A73CMModCod[0];
            A75CMModMes = P001P2_A75CMModMes[0];
            A74CMModAno = P001P2_A74CMModAno[0];
            if ( A75CMModMes == 1 )
            {
               AV66CMModMesDescription = "Enero";
            }
            else if ( A75CMModMes == 2 )
            {
               AV66CMModMesDescription = "Febrero";
            }
            else if ( A75CMModMes == 3 )
            {
               AV66CMModMesDescription = "Marzo";
            }
            else if ( A75CMModMes == 4 )
            {
               AV66CMModMesDescription = "Abril";
            }
            else if ( A75CMModMes == 5 )
            {
               AV66CMModMesDescription = "Mayo";
            }
            else if ( A75CMModMes == 6 )
            {
               AV66CMModMesDescription = "Junio";
            }
            else if ( A75CMModMes == 7 )
            {
               AV66CMModMesDescription = "Julio";
            }
            else if ( A75CMModMes == 8 )
            {
               AV66CMModMesDescription = "Agosto";
            }
            else if ( A75CMModMes == 9 )
            {
               AV66CMModMesDescription = "Setiembre";
            }
            else if ( A75CMModMes == 10 )
            {
               AV66CMModMesDescription = "Octubre";
            }
            else if ( A75CMModMes == 11 )
            {
               AV66CMModMesDescription = "Noviembre";
            }
            else if ( A75CMModMes == 12 )
            {
               AV66CMModMesDescription = "Diciembre";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "ALM") == 0 )
            {
               AV67CMModCodDescription = "Almacenes";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "CLI") == 0 )
            {
               AV67CMModCodDescription = "Ventas";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "PRV") == 0 )
            {
               AV67CMModCodDescription = "Compras";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "TES") == 0 )
            {
               AV67CMModCodDescription = "Bancos";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "CON") == 0 )
            {
               AV67CMModCodDescription = "Contabilidad";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "PRO") == 0 )
            {
               AV67CMModCodDescription = "Produccion";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "PLA") == 0 )
            {
               AV67CMModCodDescription = "Planilla";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "ACT") == 0 )
            {
               AV67CMModCodDescription = "Activos Fijos";
            }
            if ( A640CMModSts == 1 )
            {
               AV68CMModStsDescription = "Abierto";
            }
            else if ( A640CMModSts == 2 )
            {
               AV68CMModStsDescription = "Cerrado";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H1P0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A74CMModAno), "ZZZ9")), 30, Gx_line+10, 121, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66CMModMesDescription, "")), 125, Gx_line+10, 216, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67CMModCodDescription, "")), 220, Gx_line+10, 311, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68CMModStsDescription, "")), 315, Gx_line+10, 406, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A641CMModUsuC, "")), 410, Gx_line+10, 501, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A638CMModFecC, "99/99/99"), 505, Gx_line+10, 596, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A642CMModUsuM, "")), 600, Gx_line+10, 691, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A639CMModFecM, "99/99/99"), 695, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Seguridad.CierreModulosWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.CierreModulosWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Seguridad.CierreModulosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV107GXV4 = 1;
         while ( AV107GXV4 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV107GXV4));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "CMMODANO") == 0 )
            {
               AV63CMModAno = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "CMMODMES") == 0 )
            {
               AV64CMModMes = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCMMODANO") == 0 )
            {
               AV32TFCMModAno = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV33TFCMModAno_To = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCMMODMES_SEL") == 0 )
            {
               AV69TFCMModMes_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV71TFCMModMes_Sels.FromJSonString(AV69TFCMModMes_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCMMODCOD_SEL") == 0 )
            {
               AV73TFCMModCod_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV75TFCMModCod_Sels.FromJSonString(AV73TFCMModCod_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCMMODSTS_SEL") == 0 )
            {
               AV76TFCMModSts_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV78TFCMModSts_Sels.FromJSonString(AV76TFCMModSts_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCMMODUSUC") == 0 )
            {
               AV38TFCMModUsuC = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCMMODUSUC_SEL") == 0 )
            {
               AV39TFCMModUsuC_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCMMODFECC") == 0 )
            {
               AV40TFCMModFecC = context.localUtil.CToD( AV29GridStateFilterValue.gxTpr_Value, 2);
               AV41TFCMModFecC_To = context.localUtil.CToD( AV29GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCMMODUSUM") == 0 )
            {
               AV42TFCMModUsuM = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCMMODUSUM_SEL") == 0 )
            {
               AV43TFCMModUsuM_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCMMODFECM") == 0 )
            {
               AV44TFCMModFecM = context.localUtil.CToD( AV29GridStateFilterValue.gxTpr_Value, 2);
               AV45TFCMModFecM_To = context.localUtil.CToD( AV29GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV107GXV4 = (int)(AV107GXV4+1);
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

      protected void H1P0( bool bFoot ,
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
                  AV59PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV56DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV54AppName = "DVelop Software Solutions";
               AV60Phone = "+1 550 8923";
               AV58Mail = "info@mail.com";
               AV62Website = "http://www.web.com";
               AV51AddressLine1 = "French Boulevard 2859";
               AV52AddressLine2 = "Downtown";
               AV53AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV61Title = "";
         AV65FilterCMModMesValueDescription = "";
         AV46TFCMModAno_To_Description = "";
         AV71TFCMModMes_Sels = new GxSimpleCollection<short>();
         AV69TFCMModMes_SelsJson = "";
         AV70TFCMModMes_SelDscs = "";
         AV80FilterTFCMModMes_SelValueDescription = "";
         AV75TFCMModCod_Sels = new GxSimpleCollection<string>();
         AV73TFCMModCod_SelsJson = "";
         AV31TFCMModCod_Sel = "";
         AV74TFCMModCod_SelDscs = "";
         AV81FilterTFCMModCod_SelValueDescription = "";
         AV78TFCMModSts_Sels = new GxSimpleCollection<short>();
         AV76TFCMModSts_SelsJson = "";
         AV77TFCMModSts_SelDscs = "";
         AV82FilterTFCMModSts_SelValueDescription = "";
         AV39TFCMModUsuC_Sel = "";
         AV38TFCMModUsuC = "";
         AV40TFCMModFecC = DateTime.MinValue;
         AV41TFCMModFecC_To = DateTime.MinValue;
         AV49TFCMModFecC_To_Description = "";
         AV43TFCMModUsuM_Sel = "";
         AV42TFCMModUsuM = "";
         AV44TFCMModFecM = DateTime.MinValue;
         AV45TFCMModFecM_To = DateTime.MinValue;
         AV50TFCMModFecM_To_Description = "";
         AV96Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = new GxSimpleCollection<short>();
         AV97Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = new GxSimpleCollection<string>();
         AV98Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = new GxSimpleCollection<short>();
         AV99Seguridad_cierremoduloswwds_8_tfcmmodusuc = "";
         AV100Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = "";
         AV101Seguridad_cierremoduloswwds_10_tfcmmodfecc = DateTime.MinValue;
         AV102Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = DateTime.MinValue;
         AV103Seguridad_cierremoduloswwds_12_tfcmmodusum = "";
         AV104Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = "";
         AV105Seguridad_cierremoduloswwds_14_tfcmmodfecm = DateTime.MinValue;
         AV106Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = DateTime.MinValue;
         scmdbuf = "";
         lV99Seguridad_cierremoduloswwds_8_tfcmmodusuc = "";
         lV103Seguridad_cierremoduloswwds_12_tfcmmodusum = "";
         A73CMModCod = "";
         A641CMModUsuC = "";
         A638CMModFecC = DateTime.MinValue;
         A642CMModUsuM = "";
         A639CMModFecM = DateTime.MinValue;
         P001P2_A639CMModFecM = new DateTime[] {DateTime.MinValue} ;
         P001P2_A642CMModUsuM = new string[] {""} ;
         P001P2_A638CMModFecC = new DateTime[] {DateTime.MinValue} ;
         P001P2_A641CMModUsuC = new string[] {""} ;
         P001P2_A640CMModSts = new short[1] ;
         P001P2_A73CMModCod = new string[] {""} ;
         P001P2_A75CMModMes = new short[1] ;
         P001P2_A74CMModAno = new short[1] ;
         AV66CMModMesDescription = "";
         AV67CMModCodDescription = "";
         AV68CMModStsDescription = "";
         AV26Session = context.GetSession();
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV59PageInfo = "";
         AV56DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV54AppName = "";
         AV60Phone = "";
         AV58Mail = "";
         AV62Website = "";
         AV51AddressLine1 = "";
         AV52AddressLine2 = "";
         AV53AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.cierremoduloswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P001P2_A639CMModFecM, P001P2_A642CMModUsuM, P001P2_A638CMModFecC, P001P2_A641CMModUsuC, P001P2_A640CMModSts, P001P2_A73CMModCod, P001P2_A75CMModMes, P001P2_A74CMModAno
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
      private short AV63CMModAno ;
      private short AV64CMModMes ;
      private short AV32TFCMModAno ;
      private short AV33TFCMModAno_To ;
      private short AV72TFCMModMes_Sel ;
      private short AV79TFCMModSts_Sel ;
      private short AV92Seguridad_cierremoduloswwds_1_cmmodano ;
      private short AV93Seguridad_cierremoduloswwds_2_cmmodmes ;
      private short AV94Seguridad_cierremoduloswwds_3_tfcmmodano ;
      private short AV95Seguridad_cierremoduloswwds_4_tfcmmodano_to ;
      private short A75CMModMes ;
      private short A640CMModSts ;
      private short A74CMModAno ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV88GXV1 ;
      private int AV89GXV2 ;
      private int AV90GXV3 ;
      private int AV96Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count ;
      private int AV97Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count ;
      private int AV98Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count ;
      private int AV107GXV4 ;
      private long AV83i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV31TFCMModCod_Sel ;
      private string AV39TFCMModUsuC_Sel ;
      private string AV38TFCMModUsuC ;
      private string AV43TFCMModUsuM_Sel ;
      private string AV42TFCMModUsuM ;
      private string AV99Seguridad_cierremoduloswwds_8_tfcmmodusuc ;
      private string AV100Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ;
      private string AV103Seguridad_cierremoduloswwds_12_tfcmmodusum ;
      private string AV104Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ;
      private string scmdbuf ;
      private string lV99Seguridad_cierremoduloswwds_8_tfcmmodusuc ;
      private string lV103Seguridad_cierremoduloswwds_12_tfcmmodusum ;
      private string A73CMModCod ;
      private string A641CMModUsuC ;
      private string A642CMModUsuM ;
      private DateTime AV40TFCMModFecC ;
      private DateTime AV41TFCMModFecC_To ;
      private DateTime AV44TFCMModFecM ;
      private DateTime AV45TFCMModFecM_To ;
      private DateTime AV101Seguridad_cierremoduloswwds_10_tfcmmodfecc ;
      private DateTime AV102Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ;
      private DateTime AV105Seguridad_cierremoduloswwds_14_tfcmmodfecm ;
      private DateTime AV106Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ;
      private DateTime A638CMModFecC ;
      private DateTime A639CMModFecM ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV11OrderedDsc ;
      private string AV69TFCMModMes_SelsJson ;
      private string AV73TFCMModCod_SelsJson ;
      private string AV76TFCMModSts_SelsJson ;
      private string AV61Title ;
      private string AV65FilterCMModMesValueDescription ;
      private string AV46TFCMModAno_To_Description ;
      private string AV70TFCMModMes_SelDscs ;
      private string AV80FilterTFCMModMes_SelValueDescription ;
      private string AV74TFCMModCod_SelDscs ;
      private string AV81FilterTFCMModCod_SelValueDescription ;
      private string AV77TFCMModSts_SelDscs ;
      private string AV82FilterTFCMModSts_SelValueDescription ;
      private string AV49TFCMModFecC_To_Description ;
      private string AV50TFCMModFecM_To_Description ;
      private string AV66CMModMesDescription ;
      private string AV67CMModCodDescription ;
      private string AV68CMModStsDescription ;
      private string AV59PageInfo ;
      private string AV56DateInfo ;
      private string AV54AppName ;
      private string AV60Phone ;
      private string AV58Mail ;
      private string AV62Website ;
      private string AV51AddressLine1 ;
      private string AV52AddressLine2 ;
      private string AV53AddressLine3 ;
      private GxSimpleCollection<short> AV71TFCMModMes_Sels ;
      private GxSimpleCollection<short> AV78TFCMModSts_Sels ;
      private GxSimpleCollection<short> AV96Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ;
      private GxSimpleCollection<short> AV98Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P001P2_A639CMModFecM ;
      private string[] P001P2_A642CMModUsuM ;
      private DateTime[] P001P2_A638CMModFecC ;
      private string[] P001P2_A641CMModUsuC ;
      private short[] P001P2_A640CMModSts ;
      private string[] P001P2_A73CMModCod ;
      private short[] P001P2_A75CMModMes ;
      private short[] P001P2_A74CMModAno ;
      private GxSimpleCollection<string> AV75TFCMModCod_Sels ;
      private GxSimpleCollection<string> AV97Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
   }

   public class cierremoduloswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001P2( IGxContext context ,
                                             short A75CMModMes ,
                                             GxSimpleCollection<short> AV96Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ,
                                             string A73CMModCod ,
                                             GxSimpleCollection<string> AV97Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ,
                                             short A640CMModSts ,
                                             GxSimpleCollection<short> AV98Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ,
                                             short AV92Seguridad_cierremoduloswwds_1_cmmodano ,
                                             short AV93Seguridad_cierremoduloswwds_2_cmmodmes ,
                                             short AV94Seguridad_cierremoduloswwds_3_tfcmmodano ,
                                             short AV95Seguridad_cierremoduloswwds_4_tfcmmodano_to ,
                                             int AV96Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count ,
                                             int AV97Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count ,
                                             int AV98Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count ,
                                             string AV100Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ,
                                             string AV99Seguridad_cierremoduloswwds_8_tfcmmodusuc ,
                                             DateTime AV101Seguridad_cierremoduloswwds_10_tfcmmodfecc ,
                                             DateTime AV102Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ,
                                             string AV104Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ,
                                             string AV103Seguridad_cierremoduloswwds_12_tfcmmodusum ,
                                             DateTime AV105Seguridad_cierremoduloswwds_14_tfcmmodfecm ,
                                             DateTime AV106Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ,
                                             short A74CMModAno ,
                                             string A641CMModUsuC ,
                                             DateTime A638CMModFecC ,
                                             string A642CMModUsuM ,
                                             DateTime A639CMModFecM ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [CMModFecM], [CMModUsuM], [CMModFecC], [CMModUsuC], [CMModSts], [CMModCod], [CMModMes], [CMModAno] FROM [CBCIERREMODULO]";
         if ( ! (0==AV92Seguridad_cierremoduloswwds_1_cmmodano) )
         {
            AddWhere(sWhereString, "([CMModAno] = @AV92Seguridad_cierremoduloswwds_1_cmmodano)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV93Seguridad_cierremoduloswwds_2_cmmodmes) )
         {
            AddWhere(sWhereString, "([CMModMes] = @AV93Seguridad_cierremoduloswwds_2_cmmodmes)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV94Seguridad_cierremoduloswwds_3_tfcmmodano) )
         {
            AddWhere(sWhereString, "([CMModAno] >= @AV94Seguridad_cierremoduloswwds_3_tfcmmodano)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV95Seguridad_cierremoduloswwds_4_tfcmmodano_to) )
         {
            AddWhere(sWhereString, "([CMModAno] <= @AV95Seguridad_cierremoduloswwds_4_tfcmmodano_to)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV96Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV96Seguridad_cierremoduloswwds_5_tfcmmodmes_sels, "[CMModMes] IN (", ")")+")");
         }
         if ( AV97Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV97Seguridad_cierremoduloswwds_6_tfcmmodcod_sels, "[CMModCod] IN (", ")")+")");
         }
         if ( AV98Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV98Seguridad_cierremoduloswwds_7_tfcmmodsts_sels, "[CMModSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Seguridad_cierremoduloswwds_8_tfcmmodusuc)) ) )
         {
            AddWhere(sWhereString, "([CMModUsuC] like @lV99Seguridad_cierremoduloswwds_8_tfcmmodusuc)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)) )
         {
            AddWhere(sWhereString, "([CMModUsuC] = @AV100Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV101Seguridad_cierremoduloswwds_10_tfcmmodfecc) )
         {
            AddWhere(sWhereString, "([CMModFecC] >= @AV101Seguridad_cierremoduloswwds_10_tfcmmodfecc)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV102Seguridad_cierremoduloswwds_11_tfcmmodfecc_to) )
         {
            AddWhere(sWhereString, "([CMModFecC] <= @AV102Seguridad_cierremoduloswwds_11_tfcmmodfecc_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Seguridad_cierremoduloswwds_12_tfcmmodusum)) ) )
         {
            AddWhere(sWhereString, "([CMModUsuM] like @lV103Seguridad_cierremoduloswwds_12_tfcmmodusum)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)) )
         {
            AddWhere(sWhereString, "([CMModUsuM] = @AV104Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV105Seguridad_cierremoduloswwds_14_tfcmmodfecm) )
         {
            AddWhere(sWhereString, "([CMModFecM] >= @AV105Seguridad_cierremoduloswwds_14_tfcmmodfecm)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV106Seguridad_cierremoduloswwds_15_tfcmmodfecm_to) )
         {
            AddWhere(sWhereString, "([CMModFecM] <= @AV106Seguridad_cierremoduloswwds_15_tfcmmodfecm_to)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModAno]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModAno] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModMes]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModMes] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModCod]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModCod] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModSts]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModSts] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModUsuC]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModUsuC] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModFecC]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModFecC] DESC";
         }
         else if ( ( AV10OrderedBy == 7 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModUsuM]";
         }
         else if ( ( AV10OrderedBy == 7 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModUsuM] DESC";
         }
         else if ( ( AV10OrderedBy == 8 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModFecM]";
         }
         else if ( ( AV10OrderedBy == 8 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModFecM] DESC";
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
                     return conditional_P001P2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (GxSimpleCollection<short>)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP001P2;
          prmP001P2 = new Object[] {
          new ParDef("@AV92Seguridad_cierremoduloswwds_1_cmmodano",GXType.Int16,4,0) ,
          new ParDef("@AV93Seguridad_cierremoduloswwds_2_cmmodmes",GXType.Int16,2,0) ,
          new ParDef("@AV94Seguridad_cierremoduloswwds_3_tfcmmodano",GXType.Int16,4,0) ,
          new ParDef("@AV95Seguridad_cierremoduloswwds_4_tfcmmodano_to",GXType.Int16,4,0) ,
          new ParDef("@lV99Seguridad_cierremoduloswwds_8_tfcmmodusuc",GXType.NChar,10,0) ,
          new ParDef("@AV100Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel",GXType.NChar,10,0) ,
          new ParDef("@AV101Seguridad_cierremoduloswwds_10_tfcmmodfecc",GXType.Date,8,0) ,
          new ParDef("@AV102Seguridad_cierremoduloswwds_11_tfcmmodfecc_to",GXType.Date,8,0) ,
          new ParDef("@lV103Seguridad_cierremoduloswwds_12_tfcmmodusum",GXType.NChar,10,0) ,
          new ParDef("@AV104Seguridad_cierremoduloswwds_13_tfcmmodusum_sel",GXType.NChar,10,0) ,
          new ParDef("@AV105Seguridad_cierremoduloswwds_14_tfcmmodfecm",GXType.Date,8,0) ,
          new ParDef("@AV106Seguridad_cierremoduloswwds_15_tfcmmodfecm_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001P2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}
