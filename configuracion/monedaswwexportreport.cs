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
   public class monedaswwexportreport : GXWebProcedure
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

      public monedaswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public monedaswwexportreport( IGxContext context )
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
         monedaswwexportreport objmonedaswwexportreport;
         objmonedaswwexportreport = new monedaswwexportreport();
         objmonedaswwexportreport.context.SetSubmitInitialConfig(context);
         objmonedaswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmonedaswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((monedaswwexportreport)stateInfo).executePrivate();
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
            AV52Title = "Lista de Monedas";
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
            H4E0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "MONDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV14MonDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14MonDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterMonDscDescription = StringUtil.Format( "%1 (%2)", "Moneda", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterMonDscDescription = StringUtil.Format( "%1 (%2)", "Moneda", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16MonDsc = AV14MonDsc1;
                  H4E0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterMonDscDescription, "")), 25, Gx_line+0, 184, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16MonDsc, "")), 184, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "MONDSC") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV20MonDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20MonDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterMonDscDescription = StringUtil.Format( "%1 (%2)", "Moneda", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterMonDscDescription = StringUtil.Format( "%1 (%2)", "Moneda", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16MonDsc = AV20MonDsc2;
                     H4E0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterMonDscDescription, "")), 25, Gx_line+0, 184, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16MonDsc, "")), 184, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "MONDSC") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV24MonDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24MonDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterMonDscDescription = StringUtil.Format( "%1 (%2)", "Moneda", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterMonDscDescription = StringUtil.Format( "%1 (%2)", "Moneda", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16MonDsc = AV24MonDsc3;
                        H4E0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterMonDscDescription, "")), 25, Gx_line+0, 184, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16MonDsc, "")), 184, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV30TFMonCod) && (0==AV31TFMonCod_To) ) )
         {
            H4E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 184, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30TFMonCod), "ZZZZZ9")), 184, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV40TFMonCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H4E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFMonCod_To_Description, "")), 25, Gx_line+0, 184, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFMonCod_To), "ZZZZZ9")), 184, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFMonDsc_Sel)) )
         {
            H4E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Moneda", 25, Gx_line+0, 184, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFMonDsc_Sel, "")), 184, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFMonDsc)) )
            {
               H4E0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Moneda", 25, Gx_line+0, 184, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFMonDsc, "")), 184, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFMonAbr_Sel)) )
         {
            H4E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 184, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFMonAbr_Sel, "")), 184, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFMonAbr)) )
            {
               H4E0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 184, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFMonAbr, "")), 184, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFMonSunat_Sel)) )
         {
            H4E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Sunat", 25, Gx_line+0, 184, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFMonSunat_Sel, "")), 184, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFMonSunat)) )
            {
               H4E0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo Sunat", 25, Gx_line+0, 184, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFMonSunat, "")), 184, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV57TFMonSts_Sels.FromJSonString(AV55TFMonSts_SelsJson, null);
         if ( ! ( AV57TFMonSts_Sels.Count == 0 ) )
         {
            AV60i = 1;
            AV65GXV1 = 1;
            while ( AV65GXV1 <= AV57TFMonSts_Sels.Count )
            {
               AV58TFMonSts_Sel = (short)(AV57TFMonSts_Sels.GetNumeric(AV65GXV1));
               if ( AV60i == 1 )
               {
                  AV56TFMonSts_SelDscs = "";
               }
               else
               {
                  AV56TFMonSts_SelDscs += ", ";
               }
               if ( AV58TFMonSts_Sel == 1 )
               {
                  AV59FilterTFMonSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV58TFMonSts_Sel == 0 )
               {
                  AV59FilterTFMonSts_SelValueDescription = "INACTIVO";
               }
               AV56TFMonSts_SelDscs += AV59FilterTFMonSts_SelValueDescription;
               AV60i = (long)(AV60i+1);
               AV65GXV1 = (int)(AV65GXV1+1);
            }
            H4E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 184, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56TFMonSts_SelDscs, "")), 184, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4E0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4E0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 135, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Moneda", 139, Gx_line+10, 351, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Abreviatura", 355, Gx_line+10, 461, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo Sunat", 465, Gx_line+10, 571, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 575, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV67Configuracion_monedaswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV68Configuracion_monedaswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV69Configuracion_monedaswwds_3_mondsc1 = AV14MonDsc1;
         AV70Configuracion_monedaswwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV71Configuracion_monedaswwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV72Configuracion_monedaswwds_6_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV73Configuracion_monedaswwds_7_mondsc2 = AV20MonDsc2;
         AV74Configuracion_monedaswwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV75Configuracion_monedaswwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV76Configuracion_monedaswwds_10_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV77Configuracion_monedaswwds_11_mondsc3 = AV24MonDsc3;
         AV78Configuracion_monedaswwds_12_tfmoncod = AV30TFMonCod;
         AV79Configuracion_monedaswwds_13_tfmoncod_to = AV31TFMonCod_To;
         AV80Configuracion_monedaswwds_14_tfmondsc = AV32TFMonDsc;
         AV81Configuracion_monedaswwds_15_tfmondsc_sel = AV33TFMonDsc_Sel;
         AV82Configuracion_monedaswwds_16_tfmonabr = AV34TFMonAbr;
         AV83Configuracion_monedaswwds_17_tfmonabr_sel = AV35TFMonAbr_Sel;
         AV84Configuracion_monedaswwds_18_tfmonsunat = AV38TFMonSunat;
         AV85Configuracion_monedaswwds_19_tfmonsunat_sel = AV39TFMonSunat_Sel;
         AV86Configuracion_monedaswwds_20_tfmonsts_sels = AV57TFMonSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1235MonSts ,
                                              AV86Configuracion_monedaswwds_20_tfmonsts_sels ,
                                              AV67Configuracion_monedaswwds_1_dynamicfiltersselector1 ,
                                              AV68Configuracion_monedaswwds_2_dynamicfiltersoperator1 ,
                                              AV69Configuracion_monedaswwds_3_mondsc1 ,
                                              AV70Configuracion_monedaswwds_4_dynamicfiltersenabled2 ,
                                              AV71Configuracion_monedaswwds_5_dynamicfiltersselector2 ,
                                              AV72Configuracion_monedaswwds_6_dynamicfiltersoperator2 ,
                                              AV73Configuracion_monedaswwds_7_mondsc2 ,
                                              AV74Configuracion_monedaswwds_8_dynamicfiltersenabled3 ,
                                              AV75Configuracion_monedaswwds_9_dynamicfiltersselector3 ,
                                              AV76Configuracion_monedaswwds_10_dynamicfiltersoperator3 ,
                                              AV77Configuracion_monedaswwds_11_mondsc3 ,
                                              AV78Configuracion_monedaswwds_12_tfmoncod ,
                                              AV79Configuracion_monedaswwds_13_tfmoncod_to ,
                                              AV81Configuracion_monedaswwds_15_tfmondsc_sel ,
                                              AV80Configuracion_monedaswwds_14_tfmondsc ,
                                              AV83Configuracion_monedaswwds_17_tfmonabr_sel ,
                                              AV82Configuracion_monedaswwds_16_tfmonabr ,
                                              AV85Configuracion_monedaswwds_19_tfmonsunat_sel ,
                                              AV84Configuracion_monedaswwds_18_tfmonsunat ,
                                              AV86Configuracion_monedaswwds_20_tfmonsts_sels.Count ,
                                              A1234MonDsc ,
                                              A180MonCod ,
                                              A1233MonAbr ,
                                              A1236MonSunat ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV69Configuracion_monedaswwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_monedaswwds_3_mondsc1), 100, "%");
         lV69Configuracion_monedaswwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_monedaswwds_3_mondsc1), 100, "%");
         lV73Configuracion_monedaswwds_7_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_monedaswwds_7_mondsc2), 100, "%");
         lV73Configuracion_monedaswwds_7_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_monedaswwds_7_mondsc2), 100, "%");
         lV77Configuracion_monedaswwds_11_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_monedaswwds_11_mondsc3), 100, "%");
         lV77Configuracion_monedaswwds_11_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_monedaswwds_11_mondsc3), 100, "%");
         lV80Configuracion_monedaswwds_14_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_monedaswwds_14_tfmondsc), 100, "%");
         lV82Configuracion_monedaswwds_16_tfmonabr = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_monedaswwds_16_tfmonabr), 5, "%");
         lV84Configuracion_monedaswwds_18_tfmonsunat = StringUtil.Concat( StringUtil.RTrim( AV84Configuracion_monedaswwds_18_tfmonsunat), "%", "");
         /* Using cursor P004E2 */
         pr_default.execute(0, new Object[] {lV69Configuracion_monedaswwds_3_mondsc1, lV69Configuracion_monedaswwds_3_mondsc1, lV73Configuracion_monedaswwds_7_mondsc2, lV73Configuracion_monedaswwds_7_mondsc2, lV77Configuracion_monedaswwds_11_mondsc3, lV77Configuracion_monedaswwds_11_mondsc3, AV78Configuracion_monedaswwds_12_tfmoncod, AV79Configuracion_monedaswwds_13_tfmoncod_to, lV80Configuracion_monedaswwds_14_tfmondsc, AV81Configuracion_monedaswwds_15_tfmondsc_sel, lV82Configuracion_monedaswwds_16_tfmonabr, AV83Configuracion_monedaswwds_17_tfmonabr_sel, lV84Configuracion_monedaswwds_18_tfmonsunat, AV85Configuracion_monedaswwds_19_tfmonsunat_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1235MonSts = P004E2_A1235MonSts[0];
            A1236MonSunat = P004E2_A1236MonSunat[0];
            A1233MonAbr = P004E2_A1233MonAbr[0];
            A180MonCod = P004E2_A180MonCod[0];
            A1234MonDsc = P004E2_A1234MonDsc[0];
            if ( A1235MonSts == 1 )
            {
               AV54MonStsDescription = "ACTIVO";
            }
            else if ( A1235MonSts == 0 )
            {
               AV54MonStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H4E0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A180MonCod), "ZZZZZ9")), 30, Gx_line+10, 135, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 139, Gx_line+10, 351, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1233MonAbr, "")), 355, Gx_line+10, 461, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1236MonSunat, "")), 465, Gx_line+10, 571, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54MonStsDescription, "")), 575, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Configuracion.MonedasWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.MonedasWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Configuracion.MonedasWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV87GXV2 = 1;
         while ( AV87GXV2 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV87GXV2));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFMONCOD") == 0 )
            {
               AV30TFMonCod = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV31TFMonCod_To = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFMONDSC") == 0 )
            {
               AV32TFMonDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFMONDSC_SEL") == 0 )
            {
               AV33TFMonDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFMONABR") == 0 )
            {
               AV34TFMonAbr = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFMONABR_SEL") == 0 )
            {
               AV35TFMonAbr_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFMONSUNAT") == 0 )
            {
               AV38TFMonSunat = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFMONSUNAT_SEL") == 0 )
            {
               AV39TFMonSunat_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFMONSTS_SEL") == 0 )
            {
               AV55TFMonSts_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV57TFMonSts_Sels.FromJSonString(AV55TFMonSts_SelsJson, null);
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

      protected void H4E0( bool bFoot ,
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
                  AV50PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV47DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV45AppName = "DVelop Software Solutions";
               AV51Phone = "+1 550 8923";
               AV49Mail = "info@mail.com";
               AV53Website = "http://www.web.com";
               AV42AddressLine1 = "French Boulevard 2859";
               AV43AddressLine2 = "Downtown";
               AV44AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV52Title = "";
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV25GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14MonDsc1 = "";
         AV15FilterMonDscDescription = "";
         AV16MonDsc = "";
         AV18DynamicFiltersSelector2 = "";
         AV20MonDsc2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV24MonDsc3 = "";
         AV40TFMonCod_To_Description = "";
         AV33TFMonDsc_Sel = "";
         AV32TFMonDsc = "";
         AV35TFMonAbr_Sel = "";
         AV34TFMonAbr = "";
         AV39TFMonSunat_Sel = "";
         AV38TFMonSunat = "";
         AV57TFMonSts_Sels = new GxSimpleCollection<short>();
         AV55TFMonSts_SelsJson = "";
         AV56TFMonSts_SelDscs = "";
         AV59FilterTFMonSts_SelValueDescription = "";
         AV67Configuracion_monedaswwds_1_dynamicfiltersselector1 = "";
         AV69Configuracion_monedaswwds_3_mondsc1 = "";
         AV71Configuracion_monedaswwds_5_dynamicfiltersselector2 = "";
         AV73Configuracion_monedaswwds_7_mondsc2 = "";
         AV75Configuracion_monedaswwds_9_dynamicfiltersselector3 = "";
         AV77Configuracion_monedaswwds_11_mondsc3 = "";
         AV80Configuracion_monedaswwds_14_tfmondsc = "";
         AV81Configuracion_monedaswwds_15_tfmondsc_sel = "";
         AV82Configuracion_monedaswwds_16_tfmonabr = "";
         AV83Configuracion_monedaswwds_17_tfmonabr_sel = "";
         AV84Configuracion_monedaswwds_18_tfmonsunat = "";
         AV85Configuracion_monedaswwds_19_tfmonsunat_sel = "";
         AV86Configuracion_monedaswwds_20_tfmonsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV69Configuracion_monedaswwds_3_mondsc1 = "";
         lV73Configuracion_monedaswwds_7_mondsc2 = "";
         lV77Configuracion_monedaswwds_11_mondsc3 = "";
         lV80Configuracion_monedaswwds_14_tfmondsc = "";
         lV82Configuracion_monedaswwds_16_tfmonabr = "";
         lV84Configuracion_monedaswwds_18_tfmonsunat = "";
         A1234MonDsc = "";
         A1233MonAbr = "";
         A1236MonSunat = "";
         P004E2_A1235MonSts = new short[1] ;
         P004E2_A1236MonSunat = new string[] {""} ;
         P004E2_A1233MonAbr = new string[] {""} ;
         P004E2_A180MonCod = new int[1] ;
         P004E2_A1234MonDsc = new string[] {""} ;
         AV54MonStsDescription = "";
         AV26Session = context.GetSession();
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV50PageInfo = "";
         AV47DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV45AppName = "";
         AV51Phone = "";
         AV49Mail = "";
         AV53Website = "";
         AV42AddressLine1 = "";
         AV43AddressLine2 = "";
         AV44AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.monedaswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004E2_A1235MonSts, P004E2_A1236MonSunat, P004E2_A1233MonAbr, P004E2_A180MonCod, P004E2_A1234MonDsc
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
      private short AV58TFMonSts_Sel ;
      private short AV68Configuracion_monedaswwds_2_dynamicfiltersoperator1 ;
      private short AV72Configuracion_monedaswwds_6_dynamicfiltersoperator2 ;
      private short AV76Configuracion_monedaswwds_10_dynamicfiltersoperator3 ;
      private short A1235MonSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV30TFMonCod ;
      private int AV31TFMonCod_To ;
      private int AV65GXV1 ;
      private int AV78Configuracion_monedaswwds_12_tfmoncod ;
      private int AV79Configuracion_monedaswwds_13_tfmoncod_to ;
      private int AV86Configuracion_monedaswwds_20_tfmonsts_sels_Count ;
      private int A180MonCod ;
      private int AV87GXV2 ;
      private long AV60i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14MonDsc1 ;
      private string AV16MonDsc ;
      private string AV20MonDsc2 ;
      private string AV24MonDsc3 ;
      private string AV33TFMonDsc_Sel ;
      private string AV32TFMonDsc ;
      private string AV35TFMonAbr_Sel ;
      private string AV34TFMonAbr ;
      private string AV69Configuracion_monedaswwds_3_mondsc1 ;
      private string AV73Configuracion_monedaswwds_7_mondsc2 ;
      private string AV77Configuracion_monedaswwds_11_mondsc3 ;
      private string AV80Configuracion_monedaswwds_14_tfmondsc ;
      private string AV81Configuracion_monedaswwds_15_tfmondsc_sel ;
      private string AV82Configuracion_monedaswwds_16_tfmonabr ;
      private string AV83Configuracion_monedaswwds_17_tfmonabr_sel ;
      private string scmdbuf ;
      private string lV69Configuracion_monedaswwds_3_mondsc1 ;
      private string lV73Configuracion_monedaswwds_7_mondsc2 ;
      private string lV77Configuracion_monedaswwds_11_mondsc3 ;
      private string lV80Configuracion_monedaswwds_14_tfmondsc ;
      private string lV82Configuracion_monedaswwds_16_tfmonabr ;
      private string A1234MonDsc ;
      private string A1233MonAbr ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV70Configuracion_monedaswwds_4_dynamicfiltersenabled2 ;
      private bool AV74Configuracion_monedaswwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV55TFMonSts_SelsJson ;
      private string AV52Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterMonDscDescription ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV40TFMonCod_To_Description ;
      private string AV39TFMonSunat_Sel ;
      private string AV38TFMonSunat ;
      private string AV56TFMonSts_SelDscs ;
      private string AV59FilterTFMonSts_SelValueDescription ;
      private string AV67Configuracion_monedaswwds_1_dynamicfiltersselector1 ;
      private string AV71Configuracion_monedaswwds_5_dynamicfiltersselector2 ;
      private string AV75Configuracion_monedaswwds_9_dynamicfiltersselector3 ;
      private string AV84Configuracion_monedaswwds_18_tfmonsunat ;
      private string AV85Configuracion_monedaswwds_19_tfmonsunat_sel ;
      private string lV84Configuracion_monedaswwds_18_tfmonsunat ;
      private string A1236MonSunat ;
      private string AV54MonStsDescription ;
      private string AV50PageInfo ;
      private string AV47DateInfo ;
      private string AV45AppName ;
      private string AV51Phone ;
      private string AV49Mail ;
      private string AV53Website ;
      private string AV42AddressLine1 ;
      private string AV43AddressLine2 ;
      private string AV44AddressLine3 ;
      private GxSimpleCollection<short> AV57TFMonSts_Sels ;
      private GxSimpleCollection<short> AV86Configuracion_monedaswwds_20_tfmonsts_sels ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P004E2_A1235MonSts ;
      private string[] P004E2_A1236MonSunat ;
      private string[] P004E2_A1233MonAbr ;
      private int[] P004E2_A180MonCod ;
      private string[] P004E2_A1234MonDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class monedaswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004E2( IGxContext context ,
                                             short A1235MonSts ,
                                             GxSimpleCollection<short> AV86Configuracion_monedaswwds_20_tfmonsts_sels ,
                                             string AV67Configuracion_monedaswwds_1_dynamicfiltersselector1 ,
                                             short AV68Configuracion_monedaswwds_2_dynamicfiltersoperator1 ,
                                             string AV69Configuracion_monedaswwds_3_mondsc1 ,
                                             bool AV70Configuracion_monedaswwds_4_dynamicfiltersenabled2 ,
                                             string AV71Configuracion_monedaswwds_5_dynamicfiltersselector2 ,
                                             short AV72Configuracion_monedaswwds_6_dynamicfiltersoperator2 ,
                                             string AV73Configuracion_monedaswwds_7_mondsc2 ,
                                             bool AV74Configuracion_monedaswwds_8_dynamicfiltersenabled3 ,
                                             string AV75Configuracion_monedaswwds_9_dynamicfiltersselector3 ,
                                             short AV76Configuracion_monedaswwds_10_dynamicfiltersoperator3 ,
                                             string AV77Configuracion_monedaswwds_11_mondsc3 ,
                                             int AV78Configuracion_monedaswwds_12_tfmoncod ,
                                             int AV79Configuracion_monedaswwds_13_tfmoncod_to ,
                                             string AV81Configuracion_monedaswwds_15_tfmondsc_sel ,
                                             string AV80Configuracion_monedaswwds_14_tfmondsc ,
                                             string AV83Configuracion_monedaswwds_17_tfmonabr_sel ,
                                             string AV82Configuracion_monedaswwds_16_tfmonabr ,
                                             string AV85Configuracion_monedaswwds_19_tfmonsunat_sel ,
                                             string AV84Configuracion_monedaswwds_18_tfmonsunat ,
                                             int AV86Configuracion_monedaswwds_20_tfmonsts_sels_Count ,
                                             string A1234MonDsc ,
                                             int A180MonCod ,
                                             string A1233MonAbr ,
                                             string A1236MonSunat ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [MonSts], [MonSunat], [MonAbr], [MonCod], [MonDsc] FROM [CMONEDAS]";
         if ( ( StringUtil.StrCmp(AV67Configuracion_monedaswwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV68Configuracion_monedaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_monedaswwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV69Configuracion_monedaswwds_3_mondsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Configuracion_monedaswwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV68Configuracion_monedaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_monedaswwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV69Configuracion_monedaswwds_3_mondsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV70Configuracion_monedaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_monedaswwds_5_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV72Configuracion_monedaswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_monedaswwds_7_mondsc2)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV73Configuracion_monedaswwds_7_mondsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV70Configuracion_monedaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_monedaswwds_5_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV72Configuracion_monedaswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_monedaswwds_7_mondsc2)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV73Configuracion_monedaswwds_7_mondsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV74Configuracion_monedaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Configuracion_monedaswwds_9_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV76Configuracion_monedaswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_monedaswwds_11_mondsc3)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV77Configuracion_monedaswwds_11_mondsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV74Configuracion_monedaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Configuracion_monedaswwds_9_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV76Configuracion_monedaswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_monedaswwds_11_mondsc3)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV77Configuracion_monedaswwds_11_mondsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV78Configuracion_monedaswwds_12_tfmoncod) )
         {
            AddWhere(sWhereString, "([MonCod] >= @AV78Configuracion_monedaswwds_12_tfmoncod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV79Configuracion_monedaswwds_13_tfmoncod_to) )
         {
            AddWhere(sWhereString, "([MonCod] <= @AV79Configuracion_monedaswwds_13_tfmoncod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_monedaswwds_15_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_monedaswwds_14_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV80Configuracion_monedaswwds_14_tfmondsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_monedaswwds_15_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "([MonDsc] = @AV81Configuracion_monedaswwds_15_tfmondsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_monedaswwds_17_tfmonabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_monedaswwds_16_tfmonabr)) ) )
         {
            AddWhere(sWhereString, "([MonAbr] like @lV82Configuracion_monedaswwds_16_tfmonabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_monedaswwds_17_tfmonabr_sel)) )
         {
            AddWhere(sWhereString, "([MonAbr] = @AV83Configuracion_monedaswwds_17_tfmonabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_monedaswwds_19_tfmonsunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_monedaswwds_18_tfmonsunat)) ) )
         {
            AddWhere(sWhereString, "([MonSunat] like @lV84Configuracion_monedaswwds_18_tfmonsunat)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_monedaswwds_19_tfmonsunat_sel)) )
         {
            AddWhere(sWhereString, "([MonSunat] = @AV85Configuracion_monedaswwds_19_tfmonsunat_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV86Configuracion_monedaswwds_20_tfmonsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV86Configuracion_monedaswwds_20_tfmonsts_sels, "[MonSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MonCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MonCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MonDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MonDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MonAbr]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MonAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MonSunat]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MonSunat] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MonSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MonSts] DESC";
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
                     return conditional_P004E2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP004E2;
          prmP004E2 = new Object[] {
          new ParDef("@lV69Configuracion_monedaswwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_monedaswwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_monedaswwds_7_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_monedaswwds_7_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV77Configuracion_monedaswwds_11_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@lV77Configuracion_monedaswwds_11_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@AV78Configuracion_monedaswwds_12_tfmoncod",GXType.Int32,6,0) ,
          new ParDef("@AV79Configuracion_monedaswwds_13_tfmoncod_to",GXType.Int32,6,0) ,
          new ParDef("@lV80Configuracion_monedaswwds_14_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV81Configuracion_monedaswwds_15_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_monedaswwds_16_tfmonabr",GXType.NChar,5,0) ,
          new ParDef("@AV83Configuracion_monedaswwds_17_tfmonabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV84Configuracion_monedaswwds_18_tfmonsunat",GXType.NVarChar,3,0) ,
          new ParDef("@AV85Configuracion_monedaswwds_19_tfmonsunat_sel",GXType.NVarChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004E2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
