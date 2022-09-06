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
   public class almaceneswwexportreport : GXWebProcedure
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

      public almaceneswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public almaceneswwexportreport( IGxContext context )
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
         almaceneswwexportreport objalmaceneswwexportreport;
         objalmaceneswwexportreport = new almaceneswwexportreport();
         objalmaceneswwexportreport.context.SetSubmitInitialConfig(context);
         objalmaceneswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objalmaceneswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((almaceneswwexportreport)stateInfo).executePrivate();
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
            AV54Title = "Lista de Almacenes";
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
            H2G0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "ALMDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV14AlmDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14AlmDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterAlmDscDescription = StringUtil.Format( "%1 (%2)", "Almacen", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterAlmDscDescription = StringUtil.Format( "%1 (%2)", "Almacen", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16AlmDsc = AV14AlmDsc1;
                  H2G0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterAlmDscDescription, "")), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16AlmDsc, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "ALMDSC") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV20AlmDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20AlmDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterAlmDscDescription = StringUtil.Format( "%1 (%2)", "Almacen", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterAlmDscDescription = StringUtil.Format( "%1 (%2)", "Almacen", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16AlmDsc = AV20AlmDsc2;
                     H2G0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterAlmDscDescription, "")), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16AlmDsc, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "ALMDSC") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV24AlmDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24AlmDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterAlmDscDescription = StringUtil.Format( "%1 (%2)", "Almacen", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterAlmDscDescription = StringUtil.Format( "%1 (%2)", "Almacen", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16AlmDsc = AV24AlmDsc3;
                        H2G0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterAlmDscDescription, "")), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16AlmDsc, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV30TFAlmCod) && (0==AV31TFAlmCod_To) ) )
         {
            H2G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30TFAlmCod), "ZZZZZ9")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV42TFAlmCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H2G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFAlmCod_To_Description, "")), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFAlmCod_To), "ZZZZZ9")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFAlmDsc_Sel)) )
         {
            H2G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Almacen", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFAlmDsc_Sel, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFAlmDsc)) )
            {
               H2G0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Almacen", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFAlmDsc, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFAlmDir_Sel)) )
         {
            H2G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Dirección Almacen", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFAlmDir_Sel, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFAlmDir)) )
            {
               H2G0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Dirección Almacen", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFAlmDir, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFAlmAbr_Sel)) )
         {
            H2G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFAlmAbr_Sel, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFAlmAbr)) )
            {
               H2G0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFAlmAbr, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV63TFAlmCos) && (0==AV64TFAlmCos_To) ) )
         {
            H2G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Valoriza", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV63TFAlmCos), "9")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV65TFAlmCos_To_Description = StringUtil.Format( "%1 (%2)", "Valoriza", "Hasta", "", "", "", "", "", "", "");
            H2G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65TFAlmCos_To_Description, "")), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV64TFAlmCos_To), "9")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV38TFAlmPed_Sel) )
         {
            H2G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Afecta Pedidos", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TFAlmPed_Sel), "9")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV59TFAlmSts_Sels.FromJSonString(AV57TFAlmSts_SelsJson, null);
         if ( ! ( AV59TFAlmSts_Sels.Count == 0 ) )
         {
            AV62i = 1;
            AV70GXV1 = 1;
            while ( AV70GXV1 <= AV59TFAlmSts_Sels.Count )
            {
               AV60TFAlmSts_Sel = (short)(AV59TFAlmSts_Sels.GetNumeric(AV70GXV1));
               if ( AV62i == 1 )
               {
                  AV58TFAlmSts_SelDscs = "";
               }
               else
               {
                  AV58TFAlmSts_SelDscs += ", ";
               }
               if ( AV60TFAlmSts_Sel == 1 )
               {
                  AV61FilterTFAlmSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV60TFAlmSts_Sel == 0 )
               {
                  AV61FilterTFAlmSts_SelValueDescription = "INACTIVO";
               }
               AV58TFAlmSts_SelDscs += AV61FilterTFAlmSts_SelValueDescription;
               AV62i = (long)(AV62i+1);
               AV70GXV1 = (int)(AV70GXV1+1);
            }
            H2G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58TFAlmSts_SelDscs, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H2G0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 10, 77, 152, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H2G0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 10, 77, 152, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 103, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Almacen", 107, Gx_line+10, 253, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Dirección Almacen", 257, Gx_line+10, 403, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Abreviatura", 407, Gx_line+10, 480, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Valoriza", 484, Gx_line+10, 557, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Afecta Pedidos", 561, Gx_line+10, 635, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 639, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV72Configuracion_almaceneswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV73Configuracion_almaceneswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV74Configuracion_almaceneswwds_3_almdsc1 = AV14AlmDsc1;
         AV75Configuracion_almaceneswwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV76Configuracion_almaceneswwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV77Configuracion_almaceneswwds_6_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV78Configuracion_almaceneswwds_7_almdsc2 = AV20AlmDsc2;
         AV79Configuracion_almaceneswwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV80Configuracion_almaceneswwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV81Configuracion_almaceneswwds_10_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV82Configuracion_almaceneswwds_11_almdsc3 = AV24AlmDsc3;
         AV83Configuracion_almaceneswwds_12_tfalmcod = AV30TFAlmCod;
         AV84Configuracion_almaceneswwds_13_tfalmcod_to = AV31TFAlmCod_To;
         AV85Configuracion_almaceneswwds_14_tfalmdsc = AV32TFAlmDsc;
         AV86Configuracion_almaceneswwds_15_tfalmdsc_sel = AV33TFAlmDsc_Sel;
         AV87Configuracion_almaceneswwds_16_tfalmdir = AV34TFAlmDir;
         AV88Configuracion_almaceneswwds_17_tfalmdir_sel = AV35TFAlmDir_Sel;
         AV89Configuracion_almaceneswwds_18_tfalmabr = AV36TFAlmAbr;
         AV90Configuracion_almaceneswwds_19_tfalmabr_sel = AV37TFAlmAbr_Sel;
         AV91Configuracion_almaceneswwds_20_tfalmcos = AV63TFAlmCos;
         AV92Configuracion_almaceneswwds_21_tfalmcos_to = AV64TFAlmCos_To;
         AV93Configuracion_almaceneswwds_22_tfalmped_sel = AV38TFAlmPed_Sel;
         AV94Configuracion_almaceneswwds_23_tfalmsts_sels = AV59TFAlmSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A438AlmSts ,
                                              AV94Configuracion_almaceneswwds_23_tfalmsts_sels ,
                                              AV72Configuracion_almaceneswwds_1_dynamicfiltersselector1 ,
                                              AV73Configuracion_almaceneswwds_2_dynamicfiltersoperator1 ,
                                              AV74Configuracion_almaceneswwds_3_almdsc1 ,
                                              AV75Configuracion_almaceneswwds_4_dynamicfiltersenabled2 ,
                                              AV76Configuracion_almaceneswwds_5_dynamicfiltersselector2 ,
                                              AV77Configuracion_almaceneswwds_6_dynamicfiltersoperator2 ,
                                              AV78Configuracion_almaceneswwds_7_almdsc2 ,
                                              AV79Configuracion_almaceneswwds_8_dynamicfiltersenabled3 ,
                                              AV80Configuracion_almaceneswwds_9_dynamicfiltersselector3 ,
                                              AV81Configuracion_almaceneswwds_10_dynamicfiltersoperator3 ,
                                              AV82Configuracion_almaceneswwds_11_almdsc3 ,
                                              AV83Configuracion_almaceneswwds_12_tfalmcod ,
                                              AV84Configuracion_almaceneswwds_13_tfalmcod_to ,
                                              AV86Configuracion_almaceneswwds_15_tfalmdsc_sel ,
                                              AV85Configuracion_almaceneswwds_14_tfalmdsc ,
                                              AV88Configuracion_almaceneswwds_17_tfalmdir_sel ,
                                              AV87Configuracion_almaceneswwds_16_tfalmdir ,
                                              AV90Configuracion_almaceneswwds_19_tfalmabr_sel ,
                                              AV89Configuracion_almaceneswwds_18_tfalmabr ,
                                              AV91Configuracion_almaceneswwds_20_tfalmcos ,
                                              AV92Configuracion_almaceneswwds_21_tfalmcos_to ,
                                              AV93Configuracion_almaceneswwds_22_tfalmped_sel ,
                                              AV94Configuracion_almaceneswwds_23_tfalmsts_sels.Count ,
                                              A436AlmDsc ,
                                              A63AlmCod ,
                                              A435AlmDir ,
                                              A433AlmAbr ,
                                              A434AlmCos ,
                                              A437AlmPed ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Configuracion_almaceneswwds_3_almdsc1 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_almaceneswwds_3_almdsc1), 100, "%");
         lV74Configuracion_almaceneswwds_3_almdsc1 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_almaceneswwds_3_almdsc1), 100, "%");
         lV78Configuracion_almaceneswwds_7_almdsc2 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_almaceneswwds_7_almdsc2), 100, "%");
         lV78Configuracion_almaceneswwds_7_almdsc2 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_almaceneswwds_7_almdsc2), 100, "%");
         lV82Configuracion_almaceneswwds_11_almdsc3 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_almaceneswwds_11_almdsc3), 100, "%");
         lV82Configuracion_almaceneswwds_11_almdsc3 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_almaceneswwds_11_almdsc3), 100, "%");
         lV85Configuracion_almaceneswwds_14_tfalmdsc = StringUtil.PadR( StringUtil.RTrim( AV85Configuracion_almaceneswwds_14_tfalmdsc), 100, "%");
         lV87Configuracion_almaceneswwds_16_tfalmdir = StringUtil.Concat( StringUtil.RTrim( AV87Configuracion_almaceneswwds_16_tfalmdir), "%", "");
         lV89Configuracion_almaceneswwds_18_tfalmabr = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_almaceneswwds_18_tfalmabr), 10, "%");
         /* Using cursor P002G2 */
         pr_default.execute(0, new Object[] {lV74Configuracion_almaceneswwds_3_almdsc1, lV74Configuracion_almaceneswwds_3_almdsc1, lV78Configuracion_almaceneswwds_7_almdsc2, lV78Configuracion_almaceneswwds_7_almdsc2, lV82Configuracion_almaceneswwds_11_almdsc3, lV82Configuracion_almaceneswwds_11_almdsc3, AV83Configuracion_almaceneswwds_12_tfalmcod, AV84Configuracion_almaceneswwds_13_tfalmcod_to, lV85Configuracion_almaceneswwds_14_tfalmdsc, AV86Configuracion_almaceneswwds_15_tfalmdsc_sel, lV87Configuracion_almaceneswwds_16_tfalmdir, AV88Configuracion_almaceneswwds_17_tfalmdir_sel, lV89Configuracion_almaceneswwds_18_tfalmabr, AV90Configuracion_almaceneswwds_19_tfalmabr_sel, AV91Configuracion_almaceneswwds_20_tfalmcos, AV92Configuracion_almaceneswwds_21_tfalmcos_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A438AlmSts = P002G2_A438AlmSts[0];
            A437AlmPed = P002G2_A437AlmPed[0];
            A434AlmCos = P002G2_A434AlmCos[0];
            A433AlmAbr = P002G2_A433AlmAbr[0];
            A435AlmDir = P002G2_A435AlmDir[0];
            A63AlmCod = P002G2_A63AlmCod[0];
            A436AlmDsc = P002G2_A436AlmDsc[0];
            if ( A438AlmSts == 1 )
            {
               AV56AlmStsDescription = "ACTIVO";
            }
            else if ( A438AlmSts == 0 )
            {
               AV56AlmStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H2G0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A63AlmCod), "ZZZZZ9")), 30, Gx_line+10, 103, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A436AlmDsc, "")), 107, Gx_line+10, 253, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A435AlmDir, "")), 257, Gx_line+10, 403, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A433AlmAbr, "")), 407, Gx_line+10, 480, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A434AlmCos), "9")), 484, Gx_line+10, 557, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A437AlmPed), "9")), 561, Gx_line+10, 635, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56AlmStsDescription, "")), 639, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Configuracion.AlmacenesWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.AlmacenesWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Configuracion.AlmacenesWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV95GXV2 = 1;
         while ( AV95GXV2 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV95GXV2));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFALMCOD") == 0 )
            {
               AV30TFAlmCod = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV31TFAlmCod_To = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFALMDSC") == 0 )
            {
               AV32TFAlmDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFALMDSC_SEL") == 0 )
            {
               AV33TFAlmDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFALMDIR") == 0 )
            {
               AV34TFAlmDir = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFALMDIR_SEL") == 0 )
            {
               AV35TFAlmDir_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFALMABR") == 0 )
            {
               AV36TFAlmAbr = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFALMABR_SEL") == 0 )
            {
               AV37TFAlmAbr_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFALMCOS") == 0 )
            {
               AV63TFAlmCos = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV64TFAlmCos_To = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFALMPED_SEL") == 0 )
            {
               AV38TFAlmPed_Sel = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFALMSTS_SEL") == 0 )
            {
               AV57TFAlmSts_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV59TFAlmSts_Sels.FromJSonString(AV57TFAlmSts_SelsJson, null);
            }
            AV95GXV2 = (int)(AV95GXV2+1);
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

      protected void H2G0( bool bFoot ,
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
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
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
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
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
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV25GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14AlmDsc1 = "";
         AV15FilterAlmDscDescription = "";
         AV16AlmDsc = "";
         AV18DynamicFiltersSelector2 = "";
         AV20AlmDsc2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV24AlmDsc3 = "";
         AV42TFAlmCod_To_Description = "";
         AV33TFAlmDsc_Sel = "";
         AV32TFAlmDsc = "";
         AV35TFAlmDir_Sel = "";
         AV34TFAlmDir = "";
         AV37TFAlmAbr_Sel = "";
         AV36TFAlmAbr = "";
         AV65TFAlmCos_To_Description = "";
         AV59TFAlmSts_Sels = new GxSimpleCollection<short>();
         AV57TFAlmSts_SelsJson = "";
         AV58TFAlmSts_SelDscs = "";
         AV61FilterTFAlmSts_SelValueDescription = "";
         AV72Configuracion_almaceneswwds_1_dynamicfiltersselector1 = "";
         AV74Configuracion_almaceneswwds_3_almdsc1 = "";
         AV76Configuracion_almaceneswwds_5_dynamicfiltersselector2 = "";
         AV78Configuracion_almaceneswwds_7_almdsc2 = "";
         AV80Configuracion_almaceneswwds_9_dynamicfiltersselector3 = "";
         AV82Configuracion_almaceneswwds_11_almdsc3 = "";
         AV85Configuracion_almaceneswwds_14_tfalmdsc = "";
         AV86Configuracion_almaceneswwds_15_tfalmdsc_sel = "";
         AV87Configuracion_almaceneswwds_16_tfalmdir = "";
         AV88Configuracion_almaceneswwds_17_tfalmdir_sel = "";
         AV89Configuracion_almaceneswwds_18_tfalmabr = "";
         AV90Configuracion_almaceneswwds_19_tfalmabr_sel = "";
         AV94Configuracion_almaceneswwds_23_tfalmsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV74Configuracion_almaceneswwds_3_almdsc1 = "";
         lV78Configuracion_almaceneswwds_7_almdsc2 = "";
         lV82Configuracion_almaceneswwds_11_almdsc3 = "";
         lV85Configuracion_almaceneswwds_14_tfalmdsc = "";
         lV87Configuracion_almaceneswwds_16_tfalmdir = "";
         lV89Configuracion_almaceneswwds_18_tfalmabr = "";
         A436AlmDsc = "";
         A435AlmDir = "";
         A433AlmAbr = "";
         P002G2_A438AlmSts = new short[1] ;
         P002G2_A437AlmPed = new short[1] ;
         P002G2_A434AlmCos = new short[1] ;
         P002G2_A433AlmAbr = new string[] {""} ;
         P002G2_A435AlmDir = new string[] {""} ;
         P002G2_A63AlmCod = new int[1] ;
         P002G2_A436AlmDsc = new string[] {""} ;
         AV56AlmStsDescription = "";
         AV26Session = context.GetSession();
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.almaceneswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P002G2_A438AlmSts, P002G2_A437AlmPed, P002G2_A434AlmCos, P002G2_A433AlmAbr, P002G2_A435AlmDir, P002G2_A63AlmCod, P002G2_A436AlmDsc
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
      private short AV63TFAlmCos ;
      private short AV64TFAlmCos_To ;
      private short AV38TFAlmPed_Sel ;
      private short AV60TFAlmSts_Sel ;
      private short AV73Configuracion_almaceneswwds_2_dynamicfiltersoperator1 ;
      private short AV77Configuracion_almaceneswwds_6_dynamicfiltersoperator2 ;
      private short AV81Configuracion_almaceneswwds_10_dynamicfiltersoperator3 ;
      private short AV91Configuracion_almaceneswwds_20_tfalmcos ;
      private short AV92Configuracion_almaceneswwds_21_tfalmcos_to ;
      private short AV93Configuracion_almaceneswwds_22_tfalmped_sel ;
      private short A438AlmSts ;
      private short A434AlmCos ;
      private short A437AlmPed ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV30TFAlmCod ;
      private int AV31TFAlmCod_To ;
      private int AV70GXV1 ;
      private int AV83Configuracion_almaceneswwds_12_tfalmcod ;
      private int AV84Configuracion_almaceneswwds_13_tfalmcod_to ;
      private int AV94Configuracion_almaceneswwds_23_tfalmsts_sels_Count ;
      private int A63AlmCod ;
      private int AV95GXV2 ;
      private long AV62i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14AlmDsc1 ;
      private string AV16AlmDsc ;
      private string AV20AlmDsc2 ;
      private string AV24AlmDsc3 ;
      private string AV33TFAlmDsc_Sel ;
      private string AV32TFAlmDsc ;
      private string AV37TFAlmAbr_Sel ;
      private string AV36TFAlmAbr ;
      private string AV74Configuracion_almaceneswwds_3_almdsc1 ;
      private string AV78Configuracion_almaceneswwds_7_almdsc2 ;
      private string AV82Configuracion_almaceneswwds_11_almdsc3 ;
      private string AV85Configuracion_almaceneswwds_14_tfalmdsc ;
      private string AV86Configuracion_almaceneswwds_15_tfalmdsc_sel ;
      private string AV89Configuracion_almaceneswwds_18_tfalmabr ;
      private string AV90Configuracion_almaceneswwds_19_tfalmabr_sel ;
      private string scmdbuf ;
      private string lV74Configuracion_almaceneswwds_3_almdsc1 ;
      private string lV78Configuracion_almaceneswwds_7_almdsc2 ;
      private string lV82Configuracion_almaceneswwds_11_almdsc3 ;
      private string lV85Configuracion_almaceneswwds_14_tfalmdsc ;
      private string lV89Configuracion_almaceneswwds_18_tfalmabr ;
      private string A436AlmDsc ;
      private string A433AlmAbr ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV75Configuracion_almaceneswwds_4_dynamicfiltersenabled2 ;
      private bool AV79Configuracion_almaceneswwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV57TFAlmSts_SelsJson ;
      private string AV54Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterAlmDscDescription ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV42TFAlmCod_To_Description ;
      private string AV35TFAlmDir_Sel ;
      private string AV34TFAlmDir ;
      private string AV65TFAlmCos_To_Description ;
      private string AV58TFAlmSts_SelDscs ;
      private string AV61FilterTFAlmSts_SelValueDescription ;
      private string AV72Configuracion_almaceneswwds_1_dynamicfiltersselector1 ;
      private string AV76Configuracion_almaceneswwds_5_dynamicfiltersselector2 ;
      private string AV80Configuracion_almaceneswwds_9_dynamicfiltersselector3 ;
      private string AV87Configuracion_almaceneswwds_16_tfalmdir ;
      private string AV88Configuracion_almaceneswwds_17_tfalmdir_sel ;
      private string lV87Configuracion_almaceneswwds_16_tfalmdir ;
      private string A435AlmDir ;
      private string AV56AlmStsDescription ;
      private string AV52PageInfo ;
      private string AV49DateInfo ;
      private string AV47AppName ;
      private string AV53Phone ;
      private string AV51Mail ;
      private string AV55Website ;
      private string AV44AddressLine1 ;
      private string AV45AddressLine2 ;
      private string AV46AddressLine3 ;
      private GxSimpleCollection<short> AV59TFAlmSts_Sels ;
      private GxSimpleCollection<short> AV94Configuracion_almaceneswwds_23_tfalmsts_sels ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002G2_A438AlmSts ;
      private short[] P002G2_A437AlmPed ;
      private short[] P002G2_A434AlmCos ;
      private string[] P002G2_A433AlmAbr ;
      private string[] P002G2_A435AlmDir ;
      private int[] P002G2_A63AlmCod ;
      private string[] P002G2_A436AlmDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class almaceneswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002G2( IGxContext context ,
                                             short A438AlmSts ,
                                             GxSimpleCollection<short> AV94Configuracion_almaceneswwds_23_tfalmsts_sels ,
                                             string AV72Configuracion_almaceneswwds_1_dynamicfiltersselector1 ,
                                             short AV73Configuracion_almaceneswwds_2_dynamicfiltersoperator1 ,
                                             string AV74Configuracion_almaceneswwds_3_almdsc1 ,
                                             bool AV75Configuracion_almaceneswwds_4_dynamicfiltersenabled2 ,
                                             string AV76Configuracion_almaceneswwds_5_dynamicfiltersselector2 ,
                                             short AV77Configuracion_almaceneswwds_6_dynamicfiltersoperator2 ,
                                             string AV78Configuracion_almaceneswwds_7_almdsc2 ,
                                             bool AV79Configuracion_almaceneswwds_8_dynamicfiltersenabled3 ,
                                             string AV80Configuracion_almaceneswwds_9_dynamicfiltersselector3 ,
                                             short AV81Configuracion_almaceneswwds_10_dynamicfiltersoperator3 ,
                                             string AV82Configuracion_almaceneswwds_11_almdsc3 ,
                                             int AV83Configuracion_almaceneswwds_12_tfalmcod ,
                                             int AV84Configuracion_almaceneswwds_13_tfalmcod_to ,
                                             string AV86Configuracion_almaceneswwds_15_tfalmdsc_sel ,
                                             string AV85Configuracion_almaceneswwds_14_tfalmdsc ,
                                             string AV88Configuracion_almaceneswwds_17_tfalmdir_sel ,
                                             string AV87Configuracion_almaceneswwds_16_tfalmdir ,
                                             string AV90Configuracion_almaceneswwds_19_tfalmabr_sel ,
                                             string AV89Configuracion_almaceneswwds_18_tfalmabr ,
                                             short AV91Configuracion_almaceneswwds_20_tfalmcos ,
                                             short AV92Configuracion_almaceneswwds_21_tfalmcos_to ,
                                             short AV93Configuracion_almaceneswwds_22_tfalmped_sel ,
                                             int AV94Configuracion_almaceneswwds_23_tfalmsts_sels_Count ,
                                             string A436AlmDsc ,
                                             int A63AlmCod ,
                                             string A435AlmDir ,
                                             string A433AlmAbr ,
                                             short A434AlmCos ,
                                             short A437AlmPed ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [AlmSts], [AlmPed], [AlmCos], [AlmAbr], [AlmDir], [AlmCod], [AlmDsc] FROM [CALMACEN]";
         if ( ( StringUtil.StrCmp(AV72Configuracion_almaceneswwds_1_dynamicfiltersselector1, "ALMDSC") == 0 ) && ( AV73Configuracion_almaceneswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_almaceneswwds_3_almdsc1)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV74Configuracion_almaceneswwds_3_almdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Configuracion_almaceneswwds_1_dynamicfiltersselector1, "ALMDSC") == 0 ) && ( AV73Configuracion_almaceneswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_almaceneswwds_3_almdsc1)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV74Configuracion_almaceneswwds_3_almdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV75Configuracion_almaceneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Configuracion_almaceneswwds_5_dynamicfiltersselector2, "ALMDSC") == 0 ) && ( AV77Configuracion_almaceneswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_almaceneswwds_7_almdsc2)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV78Configuracion_almaceneswwds_7_almdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV75Configuracion_almaceneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Configuracion_almaceneswwds_5_dynamicfiltersselector2, "ALMDSC") == 0 ) && ( AV77Configuracion_almaceneswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_almaceneswwds_7_almdsc2)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV78Configuracion_almaceneswwds_7_almdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV79Configuracion_almaceneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Configuracion_almaceneswwds_9_dynamicfiltersselector3, "ALMDSC") == 0 ) && ( AV81Configuracion_almaceneswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_almaceneswwds_11_almdsc3)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV82Configuracion_almaceneswwds_11_almdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV79Configuracion_almaceneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Configuracion_almaceneswwds_9_dynamicfiltersselector3, "ALMDSC") == 0 ) && ( AV81Configuracion_almaceneswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_almaceneswwds_11_almdsc3)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV82Configuracion_almaceneswwds_11_almdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV83Configuracion_almaceneswwds_12_tfalmcod) )
         {
            AddWhere(sWhereString, "([AlmCod] >= @AV83Configuracion_almaceneswwds_12_tfalmcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV84Configuracion_almaceneswwds_13_tfalmcod_to) )
         {
            AddWhere(sWhereString, "([AlmCod] <= @AV84Configuracion_almaceneswwds_13_tfalmcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_almaceneswwds_15_tfalmdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_almaceneswwds_14_tfalmdsc)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV85Configuracion_almaceneswwds_14_tfalmdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_almaceneswwds_15_tfalmdsc_sel)) )
         {
            AddWhere(sWhereString, "([AlmDsc] = @AV86Configuracion_almaceneswwds_15_tfalmdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_almaceneswwds_17_tfalmdir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_almaceneswwds_16_tfalmdir)) ) )
         {
            AddWhere(sWhereString, "([AlmDir] like @lV87Configuracion_almaceneswwds_16_tfalmdir)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_almaceneswwds_17_tfalmdir_sel)) )
         {
            AddWhere(sWhereString, "([AlmDir] = @AV88Configuracion_almaceneswwds_17_tfalmdir_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Configuracion_almaceneswwds_19_tfalmabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_almaceneswwds_18_tfalmabr)) ) )
         {
            AddWhere(sWhereString, "([AlmAbr] like @lV89Configuracion_almaceneswwds_18_tfalmabr)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Configuracion_almaceneswwds_19_tfalmabr_sel)) )
         {
            AddWhere(sWhereString, "([AlmAbr] = @AV90Configuracion_almaceneswwds_19_tfalmabr_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (0==AV91Configuracion_almaceneswwds_20_tfalmcos) )
         {
            AddWhere(sWhereString, "([AlmCos] >= @AV91Configuracion_almaceneswwds_20_tfalmcos)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (0==AV92Configuracion_almaceneswwds_21_tfalmcos_to) )
         {
            AddWhere(sWhereString, "([AlmCos] <= @AV92Configuracion_almaceneswwds_21_tfalmcos_to)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV93Configuracion_almaceneswwds_22_tfalmped_sel == 1 )
         {
            AddWhere(sWhereString, "([AlmPed] = 1)");
         }
         if ( AV93Configuracion_almaceneswwds_22_tfalmped_sel == 2 )
         {
            AddWhere(sWhereString, "([AlmPed] = 0)");
         }
         if ( AV94Configuracion_almaceneswwds_23_tfalmsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV94Configuracion_almaceneswwds_23_tfalmsts_sels, "[AlmSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [AlmCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AlmCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [AlmDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AlmDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [AlmDir]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AlmDir] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [AlmAbr]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AlmAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [AlmCos]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AlmCos] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [AlmPed]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AlmPed] DESC";
         }
         else if ( ( AV10OrderedBy == 7 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [AlmSts]";
         }
         else if ( ( AV10OrderedBy == 7 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AlmSts] DESC";
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
                     return conditional_P002G2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (bool)dynConstraints[32] );
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
          Object[] prmP002G2;
          prmP002G2 = new Object[] {
          new ParDef("@lV74Configuracion_almaceneswwds_3_almdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_almaceneswwds_3_almdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_almaceneswwds_7_almdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_almaceneswwds_7_almdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_almaceneswwds_11_almdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_almaceneswwds_11_almdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV83Configuracion_almaceneswwds_12_tfalmcod",GXType.Int32,6,0) ,
          new ParDef("@AV84Configuracion_almaceneswwds_13_tfalmcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV85Configuracion_almaceneswwds_14_tfalmdsc",GXType.NChar,100,0) ,
          new ParDef("@AV86Configuracion_almaceneswwds_15_tfalmdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV87Configuracion_almaceneswwds_16_tfalmdir",GXType.NVarChar,100,0) ,
          new ParDef("@AV88Configuracion_almaceneswwds_17_tfalmdir_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV89Configuracion_almaceneswwds_18_tfalmabr",GXType.NChar,10,0) ,
          new ParDef("@AV90Configuracion_almaceneswwds_19_tfalmabr_sel",GXType.NChar,10,0) ,
          new ParDef("@AV91Configuracion_almaceneswwds_20_tfalmcos",GXType.Int16,1,0) ,
          new ParDef("@AV92Configuracion_almaceneswwds_21_tfalmcos_to",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002G2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                return;
       }
    }

 }

}
