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
   public class formapagowwexportreport : GXWebProcedure
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

      public formapagowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public formapagowwexportreport( IGxContext context )
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
         formapagowwexportreport objformapagowwexportreport;
         objformapagowwexportreport = new formapagowwexportreport();
         objformapagowwexportreport.context.SetSubmitInitialConfig(context);
         objformapagowwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objformapagowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((formapagowwexportreport)stateInfo).executePrivate();
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
            AV59Title = "Lista de Forma Pago";
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
            H2O0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "FORDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15ForDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ForDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterForDscDescription = StringUtil.Format( "%1 (%2)", "Forma de Pago", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterForDscDescription = StringUtil.Format( "%1 (%2)", "Forma de Pago", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17ForDsc = AV15ForDsc1;
                  H2O0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterForDscDescription, "")), 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ForDsc, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "FORDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21ForDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ForDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterForDscDescription = StringUtil.Format( "%1 (%2)", "Forma de Pago", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterForDscDescription = StringUtil.Format( "%1 (%2)", "Forma de Pago", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17ForDsc = AV21ForDsc2;
                     H2O0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterForDscDescription, "")), 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ForDsc, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "FORDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25ForDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ForDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterForDscDescription = StringUtil.Format( "%1 (%2)", "Forma de Pago", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterForDscDescription = StringUtil.Format( "%1 (%2)", "Forma de Pago", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17ForDsc = AV25ForDsc3;
                        H2O0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterForDscDescription, "")), 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ForDsc, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFForCod) && (0==AV32TFForCod_To) ) )
         {
            H2O0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFForCod), "ZZZZZ9")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV45TFForCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H2O0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFForCod_To_Description, "")), 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFForCod_To), "ZZZZZ9")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFForDsc_Sel)) )
         {
            H2O0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Forma de Pago", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFForDsc_Sel, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFForDsc)) )
            {
               H2O0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Forma de Pago", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFForDsc, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFForAbr_Sel)) )
         {
            H2O0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFForAbr_Sel, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFForAbr)) )
            {
               H2O0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFForAbr, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFForSunat_Sel)) )
         {
            H2O0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Sunat", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFForSunat_Sel, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFForSunat)) )
            {
               H2O0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo Sunat", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFForSunat, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV61TFForBanSts_Sel) )
         {
            H2O0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Afecta Banco", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV61TFForBanSts_Sel), "9")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV43TFForSts_Sels.FromJSonString(AV41TFForSts_SelsJson, null);
         if ( ! ( AV43TFForSts_Sels.Count == 0 ) )
         {
            AV48i = 1;
            AV66GXV1 = 1;
            while ( AV66GXV1 <= AV43TFForSts_Sels.Count )
            {
               AV44TFForSts_Sel = (short)(AV43TFForSts_Sels.GetNumeric(AV66GXV1));
               if ( AV48i == 1 )
               {
                  AV42TFForSts_SelDscs = "";
               }
               else
               {
                  AV42TFForSts_SelDscs += ", ";
               }
               if ( AV44TFForSts_Sel == 1 )
               {
                  AV47FilterTFForSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV44TFForSts_Sel == 0 )
               {
                  AV47FilterTFForSts_SelValueDescription = "INACTIVO";
               }
               AV42TFForSts_SelDscs += AV47FilterTFForSts_SelValueDescription;
               AV48i = (long)(AV48i+1);
               AV66GXV1 = (int)(AV66GXV1+1);
            }
            H2O0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFForSts_SelDscs, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H2O0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H2O0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 122, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Forma de Pago", 126, Gx_line+10, 310, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Abreviatura", 314, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo Sunat", 410, Gx_line+10, 502, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Afecta Banco", 506, Gx_line+10, 598, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 602, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV68Configuracion_formapagowwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV69Configuracion_formapagowwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV70Configuracion_formapagowwds_3_fordsc1 = AV15ForDsc1;
         AV71Configuracion_formapagowwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV72Configuracion_formapagowwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV73Configuracion_formapagowwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV74Configuracion_formapagowwds_7_fordsc2 = AV21ForDsc2;
         AV75Configuracion_formapagowwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV76Configuracion_formapagowwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV77Configuracion_formapagowwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV78Configuracion_formapagowwds_11_fordsc3 = AV25ForDsc3;
         AV79Configuracion_formapagowwds_12_tfforcod = AV31TFForCod;
         AV80Configuracion_formapagowwds_13_tfforcod_to = AV32TFForCod_To;
         AV81Configuracion_formapagowwds_14_tffordsc = AV33TFForDsc;
         AV82Configuracion_formapagowwds_15_tffordsc_sel = AV34TFForDsc_Sel;
         AV83Configuracion_formapagowwds_16_tfforabr = AV35TFForAbr;
         AV84Configuracion_formapagowwds_17_tfforabr_sel = AV36TFForAbr_Sel;
         AV85Configuracion_formapagowwds_18_tfforsunat = AV37TFForSunat;
         AV86Configuracion_formapagowwds_19_tfforsunat_sel = AV38TFForSunat_Sel;
         AV87Configuracion_formapagowwds_20_tfforbansts_sel = AV61TFForBanSts_Sel;
         AV88Configuracion_formapagowwds_21_tfforsts_sels = AV43TFForSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A989ForSts ,
                                              AV88Configuracion_formapagowwds_21_tfforsts_sels ,
                                              AV68Configuracion_formapagowwds_1_dynamicfiltersselector1 ,
                                              AV69Configuracion_formapagowwds_2_dynamicfiltersoperator1 ,
                                              AV70Configuracion_formapagowwds_3_fordsc1 ,
                                              AV71Configuracion_formapagowwds_4_dynamicfiltersenabled2 ,
                                              AV72Configuracion_formapagowwds_5_dynamicfiltersselector2 ,
                                              AV73Configuracion_formapagowwds_6_dynamicfiltersoperator2 ,
                                              AV74Configuracion_formapagowwds_7_fordsc2 ,
                                              AV75Configuracion_formapagowwds_8_dynamicfiltersenabled3 ,
                                              AV76Configuracion_formapagowwds_9_dynamicfiltersselector3 ,
                                              AV77Configuracion_formapagowwds_10_dynamicfiltersoperator3 ,
                                              AV78Configuracion_formapagowwds_11_fordsc3 ,
                                              AV79Configuracion_formapagowwds_12_tfforcod ,
                                              AV80Configuracion_formapagowwds_13_tfforcod_to ,
                                              AV82Configuracion_formapagowwds_15_tffordsc_sel ,
                                              AV81Configuracion_formapagowwds_14_tffordsc ,
                                              AV84Configuracion_formapagowwds_17_tfforabr_sel ,
                                              AV83Configuracion_formapagowwds_16_tfforabr ,
                                              AV86Configuracion_formapagowwds_19_tfforsunat_sel ,
                                              AV85Configuracion_formapagowwds_18_tfforsunat ,
                                              AV87Configuracion_formapagowwds_20_tfforbansts_sel ,
                                              AV88Configuracion_formapagowwds_21_tfforsts_sels.Count ,
                                              A988ForDsc ,
                                              A143ForCod ,
                                              A986ForAbr ,
                                              A990ForSunat ,
                                              A987ForBanSts ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV70Configuracion_formapagowwds_3_fordsc1 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_formapagowwds_3_fordsc1), 100, "%");
         lV70Configuracion_formapagowwds_3_fordsc1 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_formapagowwds_3_fordsc1), 100, "%");
         lV74Configuracion_formapagowwds_7_fordsc2 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_formapagowwds_7_fordsc2), 100, "%");
         lV74Configuracion_formapagowwds_7_fordsc2 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_formapagowwds_7_fordsc2), 100, "%");
         lV78Configuracion_formapagowwds_11_fordsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_formapagowwds_11_fordsc3), 100, "%");
         lV78Configuracion_formapagowwds_11_fordsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_formapagowwds_11_fordsc3), 100, "%");
         lV81Configuracion_formapagowwds_14_tffordsc = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_formapagowwds_14_tffordsc), 100, "%");
         lV83Configuracion_formapagowwds_16_tfforabr = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_formapagowwds_16_tfforabr), 5, "%");
         lV85Configuracion_formapagowwds_18_tfforsunat = StringUtil.PadR( StringUtil.RTrim( AV85Configuracion_formapagowwds_18_tfforsunat), 5, "%");
         /* Using cursor P002O2 */
         pr_default.execute(0, new Object[] {lV70Configuracion_formapagowwds_3_fordsc1, lV70Configuracion_formapagowwds_3_fordsc1, lV74Configuracion_formapagowwds_7_fordsc2, lV74Configuracion_formapagowwds_7_fordsc2, lV78Configuracion_formapagowwds_11_fordsc3, lV78Configuracion_formapagowwds_11_fordsc3, AV79Configuracion_formapagowwds_12_tfforcod, AV80Configuracion_formapagowwds_13_tfforcod_to, lV81Configuracion_formapagowwds_14_tffordsc, AV82Configuracion_formapagowwds_15_tffordsc_sel, lV83Configuracion_formapagowwds_16_tfforabr, AV84Configuracion_formapagowwds_17_tfforabr_sel, lV85Configuracion_formapagowwds_18_tfforsunat, AV86Configuracion_formapagowwds_19_tfforsunat_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A989ForSts = P002O2_A989ForSts[0];
            A987ForBanSts = P002O2_A987ForBanSts[0];
            A990ForSunat = P002O2_A990ForSunat[0];
            A986ForAbr = P002O2_A986ForAbr[0];
            A143ForCod = P002O2_A143ForCod[0];
            A988ForDsc = P002O2_A988ForDsc[0];
            if ( A989ForSts == 1 )
            {
               AV12ForStsDescription = "ACTIVO";
            }
            else if ( A989ForSts == 0 )
            {
               AV12ForStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H2O0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A143ForCod), "ZZZZZ9")), 30, Gx_line+10, 122, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A988ForDsc, "")), 126, Gx_line+10, 310, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A986ForAbr, "")), 314, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A990ForSunat, "")), 410, Gx_line+10, 502, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A987ForBanSts), "9")), 506, Gx_line+10, 598, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12ForStsDescription, "")), 602, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.FormaPagoWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.FormaPagoWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.FormaPagoWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV89GXV2 = 1;
         while ( AV89GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV89GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFORCOD") == 0 )
            {
               AV31TFForCod = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AV32TFForCod_To = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFORDSC") == 0 )
            {
               AV33TFForDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFORDSC_SEL") == 0 )
            {
               AV34TFForDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFORABR") == 0 )
            {
               AV35TFForAbr = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFORABR_SEL") == 0 )
            {
               AV36TFForAbr_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFORSUNAT") == 0 )
            {
               AV37TFForSunat = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFORSUNAT_SEL") == 0 )
            {
               AV38TFForSunat_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFORBANSTS_SEL") == 0 )
            {
               AV61TFForBanSts_Sel = (short)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFFORSTS_SEL") == 0 )
            {
               AV41TFForSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV43TFForSts_Sels.FromJSonString(AV41TFForSts_SelsJson, null);
            }
            AV89GXV2 = (int)(AV89GXV2+1);
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

      protected void H2O0( bool bFoot ,
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
                  AV57PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV54DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV52AppName = "DVelop Software Solutions";
               AV58Phone = "+1 550 8923";
               AV56Mail = "info@mail.com";
               AV60Website = "http://www.web.com";
               AV49AddressLine1 = "French Boulevard 2859";
               AV50AddressLine2 = "Downtown";
               AV51AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV59Title = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15ForDsc1 = "";
         AV16FilterForDscDescription = "";
         AV17ForDsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21ForDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25ForDsc3 = "";
         AV45TFForCod_To_Description = "";
         AV34TFForDsc_Sel = "";
         AV33TFForDsc = "";
         AV36TFForAbr_Sel = "";
         AV35TFForAbr = "";
         AV38TFForSunat_Sel = "";
         AV37TFForSunat = "";
         AV43TFForSts_Sels = new GxSimpleCollection<short>();
         AV41TFForSts_SelsJson = "";
         AV42TFForSts_SelDscs = "";
         AV47FilterTFForSts_SelValueDescription = "";
         AV68Configuracion_formapagowwds_1_dynamicfiltersselector1 = "";
         AV70Configuracion_formapagowwds_3_fordsc1 = "";
         AV72Configuracion_formapagowwds_5_dynamicfiltersselector2 = "";
         AV74Configuracion_formapagowwds_7_fordsc2 = "";
         AV76Configuracion_formapagowwds_9_dynamicfiltersselector3 = "";
         AV78Configuracion_formapagowwds_11_fordsc3 = "";
         AV81Configuracion_formapagowwds_14_tffordsc = "";
         AV82Configuracion_formapagowwds_15_tffordsc_sel = "";
         AV83Configuracion_formapagowwds_16_tfforabr = "";
         AV84Configuracion_formapagowwds_17_tfforabr_sel = "";
         AV85Configuracion_formapagowwds_18_tfforsunat = "";
         AV86Configuracion_formapagowwds_19_tfforsunat_sel = "";
         AV88Configuracion_formapagowwds_21_tfforsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV70Configuracion_formapagowwds_3_fordsc1 = "";
         lV74Configuracion_formapagowwds_7_fordsc2 = "";
         lV78Configuracion_formapagowwds_11_fordsc3 = "";
         lV81Configuracion_formapagowwds_14_tffordsc = "";
         lV83Configuracion_formapagowwds_16_tfforabr = "";
         lV85Configuracion_formapagowwds_18_tfforsunat = "";
         A988ForDsc = "";
         A986ForAbr = "";
         A990ForSunat = "";
         P002O2_A989ForSts = new short[1] ;
         P002O2_A987ForBanSts = new short[1] ;
         P002O2_A990ForSunat = new string[] {""} ;
         P002O2_A986ForAbr = new string[] {""} ;
         P002O2_A143ForCod = new int[1] ;
         P002O2_A988ForDsc = new string[] {""} ;
         AV12ForStsDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV57PageInfo = "";
         AV54DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV52AppName = "";
         AV58Phone = "";
         AV56Mail = "";
         AV60Website = "";
         AV49AddressLine1 = "";
         AV50AddressLine2 = "";
         AV51AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.formapagowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P002O2_A989ForSts, P002O2_A987ForBanSts, P002O2_A990ForSunat, P002O2_A986ForAbr, P002O2_A143ForCod, P002O2_A988ForDsc
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
      private short AV61TFForBanSts_Sel ;
      private short AV44TFForSts_Sel ;
      private short AV69Configuracion_formapagowwds_2_dynamicfiltersoperator1 ;
      private short AV73Configuracion_formapagowwds_6_dynamicfiltersoperator2 ;
      private short AV77Configuracion_formapagowwds_10_dynamicfiltersoperator3 ;
      private short AV87Configuracion_formapagowwds_20_tfforbansts_sel ;
      private short A989ForSts ;
      private short A987ForBanSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV31TFForCod ;
      private int AV32TFForCod_To ;
      private int AV66GXV1 ;
      private int AV79Configuracion_formapagowwds_12_tfforcod ;
      private int AV80Configuracion_formapagowwds_13_tfforcod_to ;
      private int AV88Configuracion_formapagowwds_21_tfforsts_sels_Count ;
      private int A143ForCod ;
      private int AV89GXV2 ;
      private long AV48i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15ForDsc1 ;
      private string AV17ForDsc ;
      private string AV21ForDsc2 ;
      private string AV25ForDsc3 ;
      private string AV34TFForDsc_Sel ;
      private string AV33TFForDsc ;
      private string AV36TFForAbr_Sel ;
      private string AV35TFForAbr ;
      private string AV38TFForSunat_Sel ;
      private string AV37TFForSunat ;
      private string AV70Configuracion_formapagowwds_3_fordsc1 ;
      private string AV74Configuracion_formapagowwds_7_fordsc2 ;
      private string AV78Configuracion_formapagowwds_11_fordsc3 ;
      private string AV81Configuracion_formapagowwds_14_tffordsc ;
      private string AV82Configuracion_formapagowwds_15_tffordsc_sel ;
      private string AV83Configuracion_formapagowwds_16_tfforabr ;
      private string AV84Configuracion_formapagowwds_17_tfforabr_sel ;
      private string AV85Configuracion_formapagowwds_18_tfforsunat ;
      private string AV86Configuracion_formapagowwds_19_tfforsunat_sel ;
      private string scmdbuf ;
      private string lV70Configuracion_formapagowwds_3_fordsc1 ;
      private string lV74Configuracion_formapagowwds_7_fordsc2 ;
      private string lV78Configuracion_formapagowwds_11_fordsc3 ;
      private string lV81Configuracion_formapagowwds_14_tffordsc ;
      private string lV83Configuracion_formapagowwds_16_tfforabr ;
      private string lV85Configuracion_formapagowwds_18_tfforsunat ;
      private string A988ForDsc ;
      private string A986ForAbr ;
      private string A990ForSunat ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV71Configuracion_formapagowwds_4_dynamicfiltersenabled2 ;
      private bool AV75Configuracion_formapagowwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV41TFForSts_SelsJson ;
      private string AV59Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterForDscDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV45TFForCod_To_Description ;
      private string AV42TFForSts_SelDscs ;
      private string AV47FilterTFForSts_SelValueDescription ;
      private string AV68Configuracion_formapagowwds_1_dynamicfiltersselector1 ;
      private string AV72Configuracion_formapagowwds_5_dynamicfiltersselector2 ;
      private string AV76Configuracion_formapagowwds_9_dynamicfiltersselector3 ;
      private string AV12ForStsDescription ;
      private string AV57PageInfo ;
      private string AV54DateInfo ;
      private string AV52AppName ;
      private string AV58Phone ;
      private string AV56Mail ;
      private string AV60Website ;
      private string AV49AddressLine1 ;
      private string AV50AddressLine2 ;
      private string AV51AddressLine3 ;
      private GxSimpleCollection<short> AV43TFForSts_Sels ;
      private GxSimpleCollection<short> AV88Configuracion_formapagowwds_21_tfforsts_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002O2_A989ForSts ;
      private short[] P002O2_A987ForBanSts ;
      private string[] P002O2_A990ForSunat ;
      private string[] P002O2_A986ForAbr ;
      private int[] P002O2_A143ForCod ;
      private string[] P002O2_A988ForDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class formapagowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002O2( IGxContext context ,
                                             short A989ForSts ,
                                             GxSimpleCollection<short> AV88Configuracion_formapagowwds_21_tfforsts_sels ,
                                             string AV68Configuracion_formapagowwds_1_dynamicfiltersselector1 ,
                                             short AV69Configuracion_formapagowwds_2_dynamicfiltersoperator1 ,
                                             string AV70Configuracion_formapagowwds_3_fordsc1 ,
                                             bool AV71Configuracion_formapagowwds_4_dynamicfiltersenabled2 ,
                                             string AV72Configuracion_formapagowwds_5_dynamicfiltersselector2 ,
                                             short AV73Configuracion_formapagowwds_6_dynamicfiltersoperator2 ,
                                             string AV74Configuracion_formapagowwds_7_fordsc2 ,
                                             bool AV75Configuracion_formapagowwds_8_dynamicfiltersenabled3 ,
                                             string AV76Configuracion_formapagowwds_9_dynamicfiltersselector3 ,
                                             short AV77Configuracion_formapagowwds_10_dynamicfiltersoperator3 ,
                                             string AV78Configuracion_formapagowwds_11_fordsc3 ,
                                             int AV79Configuracion_formapagowwds_12_tfforcod ,
                                             int AV80Configuracion_formapagowwds_13_tfforcod_to ,
                                             string AV82Configuracion_formapagowwds_15_tffordsc_sel ,
                                             string AV81Configuracion_formapagowwds_14_tffordsc ,
                                             string AV84Configuracion_formapagowwds_17_tfforabr_sel ,
                                             string AV83Configuracion_formapagowwds_16_tfforabr ,
                                             string AV86Configuracion_formapagowwds_19_tfforsunat_sel ,
                                             string AV85Configuracion_formapagowwds_18_tfforsunat ,
                                             short AV87Configuracion_formapagowwds_20_tfforbansts_sel ,
                                             int AV88Configuracion_formapagowwds_21_tfforsts_sels_Count ,
                                             string A988ForDsc ,
                                             int A143ForCod ,
                                             string A986ForAbr ,
                                             string A990ForSunat ,
                                             short A987ForBanSts ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ForSts], [ForBanSts], [ForSunat], [ForAbr], [ForCod], [ForDsc] FROM [CFORMAPAGO]";
         if ( ( StringUtil.StrCmp(AV68Configuracion_formapagowwds_1_dynamicfiltersselector1, "FORDSC") == 0 ) && ( AV69Configuracion_formapagowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_formapagowwds_3_fordsc1)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV70Configuracion_formapagowwds_3_fordsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Configuracion_formapagowwds_1_dynamicfiltersselector1, "FORDSC") == 0 ) && ( AV69Configuracion_formapagowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_formapagowwds_3_fordsc1)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV70Configuracion_formapagowwds_3_fordsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV71Configuracion_formapagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Configuracion_formapagowwds_5_dynamicfiltersselector2, "FORDSC") == 0 ) && ( AV73Configuracion_formapagowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_formapagowwds_7_fordsc2)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV74Configuracion_formapagowwds_7_fordsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV71Configuracion_formapagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Configuracion_formapagowwds_5_dynamicfiltersselector2, "FORDSC") == 0 ) && ( AV73Configuracion_formapagowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_formapagowwds_7_fordsc2)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV74Configuracion_formapagowwds_7_fordsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV75Configuracion_formapagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_formapagowwds_9_dynamicfiltersselector3, "FORDSC") == 0 ) && ( AV77Configuracion_formapagowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_formapagowwds_11_fordsc3)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV78Configuracion_formapagowwds_11_fordsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV75Configuracion_formapagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_formapagowwds_9_dynamicfiltersselector3, "FORDSC") == 0 ) && ( AV77Configuracion_formapagowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_formapagowwds_11_fordsc3)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV78Configuracion_formapagowwds_11_fordsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV79Configuracion_formapagowwds_12_tfforcod) )
         {
            AddWhere(sWhereString, "([ForCod] >= @AV79Configuracion_formapagowwds_12_tfforcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV80Configuracion_formapagowwds_13_tfforcod_to) )
         {
            AddWhere(sWhereString, "([ForCod] <= @AV80Configuracion_formapagowwds_13_tfforcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_formapagowwds_15_tffordsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_formapagowwds_14_tffordsc)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV81Configuracion_formapagowwds_14_tffordsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_formapagowwds_15_tffordsc_sel)) )
         {
            AddWhere(sWhereString, "([ForDsc] = @AV82Configuracion_formapagowwds_15_tffordsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_formapagowwds_17_tfforabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_formapagowwds_16_tfforabr)) ) )
         {
            AddWhere(sWhereString, "([ForAbr] like @lV83Configuracion_formapagowwds_16_tfforabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_formapagowwds_17_tfforabr_sel)) )
         {
            AddWhere(sWhereString, "([ForAbr] = @AV84Configuracion_formapagowwds_17_tfforabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_formapagowwds_19_tfforsunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_formapagowwds_18_tfforsunat)) ) )
         {
            AddWhere(sWhereString, "([ForSunat] like @lV85Configuracion_formapagowwds_18_tfforsunat)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_formapagowwds_19_tfforsunat_sel)) )
         {
            AddWhere(sWhereString, "([ForSunat] = @AV86Configuracion_formapagowwds_19_tfforsunat_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV87Configuracion_formapagowwds_20_tfforbansts_sel == 1 )
         {
            AddWhere(sWhereString, "([ForBanSts] = 1)");
         }
         if ( AV87Configuracion_formapagowwds_20_tfforbansts_sel == 2 )
         {
            AddWhere(sWhereString, "([ForBanSts] = 0)");
         }
         if ( AV88Configuracion_formapagowwds_21_tfforsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV88Configuracion_formapagowwds_21_tfforsts_sels, "[ForSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ForCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ForCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ForDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ForDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ForAbr]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ForAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ForSunat]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ForSunat] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ForBanSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ForBanSts] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ForSts]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ForSts] DESC";
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
                     return conditional_P002O2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] );
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
          Object[] prmP002O2;
          prmP002O2 = new Object[] {
          new ParDef("@lV70Configuracion_formapagowwds_3_fordsc1",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_formapagowwds_3_fordsc1",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_formapagowwds_7_fordsc2",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_formapagowwds_7_fordsc2",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_formapagowwds_11_fordsc3",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_formapagowwds_11_fordsc3",GXType.NChar,100,0) ,
          new ParDef("@AV79Configuracion_formapagowwds_12_tfforcod",GXType.Int32,6,0) ,
          new ParDef("@AV80Configuracion_formapagowwds_13_tfforcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV81Configuracion_formapagowwds_14_tffordsc",GXType.NChar,100,0) ,
          new ParDef("@AV82Configuracion_formapagowwds_15_tffordsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV83Configuracion_formapagowwds_16_tfforabr",GXType.NChar,5,0) ,
          new ParDef("@AV84Configuracion_formapagowwds_17_tfforabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV85Configuracion_formapagowwds_18_tfforsunat",GXType.NChar,5,0) ,
          new ParDef("@AV86Configuracion_formapagowwds_19_tfforsunat_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002O2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                return;
       }
    }

 }

}
