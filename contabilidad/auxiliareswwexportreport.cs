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
   public class auxiliareswwexportreport : GXWebProcedure
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

      public auxiliareswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public auxiliareswwexportreport( IGxContext context )
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
         auxiliareswwexportreport objauxiliareswwexportreport;
         objauxiliareswwexportreport = new auxiliareswwexportreport();
         objauxiliareswwexportreport.context.SetSubmitInitialConfig(context);
         objauxiliareswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objauxiliareswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((auxiliareswwexportreport)stateInfo).executePrivate();
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
            AV54Title = "Lista de Auxiliares";
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
            H6P0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "TIPADDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15TipADDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TipADDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterTipADDscDescription = StringUtil.Format( "%1 (%2)", "Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterTipADDscDescription = StringUtil.Format( "%1 (%2)", "Auxiliar", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17TipADDsc = AV15TipADDsc1;
                  H6P0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipADDscDescription, "")), 25, Gx_line+0, 215, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipADDsc, "")), 215, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "TIPADCOD") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV56TipADCod1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TipADCod1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV57FilterTipADCodDescription = StringUtil.Format( "%1 (%2)", "Codigo Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV57FilterTipADCodDescription = StringUtil.Format( "%1 (%2)", "Codigo Auxiliar", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV58TipADCod = AV56TipADCod1;
                  H6P0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FilterTipADCodDescription, "")), 25, Gx_line+0, 215, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58TipADCod, "")), 215, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPADDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21TipADDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TipADDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterTipADDscDescription = StringUtil.Format( "%1 (%2)", "Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterTipADDscDescription = StringUtil.Format( "%1 (%2)", "Auxiliar", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17TipADDsc = AV21TipADDsc2;
                     H6P0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipADDscDescription, "")), 25, Gx_line+0, 215, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipADDsc, "")), 215, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPADCOD") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV59TipADCod2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59TipADCod2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV57FilterTipADCodDescription = StringUtil.Format( "%1 (%2)", "Codigo Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV57FilterTipADCodDescription = StringUtil.Format( "%1 (%2)", "Codigo Auxiliar", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV58TipADCod = AV59TipADCod2;
                     H6P0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FilterTipADCodDescription, "")), 25, Gx_line+0, 215, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58TipADCod, "")), 215, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPADDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25TipADDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TipADDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterTipADDscDescription = StringUtil.Format( "%1 (%2)", "Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterTipADDscDescription = StringUtil.Format( "%1 (%2)", "Auxiliar", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17TipADDsc = AV25TipADDsc3;
                        H6P0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipADDscDescription, "")), 25, Gx_line+0, 215, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipADDsc, "")), 215, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPADCOD") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV60TipADCod3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TipADCod3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV57FilterTipADCodDescription = StringUtil.Format( "%1 (%2)", "Codigo Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV57FilterTipADCodDescription = StringUtil.Format( "%1 (%2)", "Codigo Auxiliar", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV58TipADCod = AV60TipADCod3;
                        H6P0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FilterTipADCodDescription, "")), 25, Gx_line+0, 215, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58TipADCod, "")), 215, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFTipADsc_Sel)) )
         {
            H6P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo de Auxiliar", 25, Gx_line+0, 215, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62TFTipADsc_Sel, "")), 215, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTipADsc)) )
            {
               H6P0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo de Auxiliar", 25, Gx_line+0, 215, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61TFTipADsc, "")), 215, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTipADCod_Sel)) )
         {
            H6P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 215, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFTipADCod_Sel, "")), 215, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTipADCod)) )
            {
               H6P0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 215, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFTipADCod, "")), 215, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTipADDsc_Sel)) )
         {
            H6P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Auxiliar", 25, Gx_line+0, 215, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFTipADDsc_Sel, "")), 215, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFTipADDsc)) )
            {
               H6P0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Auxiliar", 25, Gx_line+0, 215, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFTipADDsc, "")), 215, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV39TFTipADSts_Sels.FromJSonString(AV37TFTipADSts_SelsJson, null);
         if ( ! ( AV39TFTipADSts_Sels.Count == 0 ) )
         {
            AV43i = 1;
            AV67GXV1 = 1;
            while ( AV67GXV1 <= AV39TFTipADSts_Sels.Count )
            {
               AV40TFTipADSts_Sel = (short)(AV39TFTipADSts_Sels.GetNumeric(AV67GXV1));
               if ( AV43i == 1 )
               {
                  AV38TFTipADSts_SelDscs = "";
               }
               else
               {
                  AV38TFTipADSts_SelDscs += ", ";
               }
               if ( AV40TFTipADSts_Sel == 1 )
               {
                  AV42FilterTFTipADSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV40TFTipADSts_Sel == 0 )
               {
                  AV42FilterTFTipADSts_SelValueDescription = "INACTIVO";
               }
               AV38TFTipADSts_SelDscs += AV42FilterTFTipADSts_SelValueDescription;
               AV43i = (long)(AV43i+1);
               AV67GXV1 = (int)(AV67GXV1+1);
            }
            H6P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 215, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFTipADSts_SelDscs, "")), 215, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6P0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6P0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Tipo de Auxiliar", 30, Gx_line+10, 216, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo", 220, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Auxiliar", 410, Gx_line+10, 596, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 600, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV69Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV70Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV71Contabilidad_auxiliareswwds_3_tipaddsc1 = AV15TipADDsc1;
         AV72Contabilidad_auxiliareswwds_4_tipadcod1 = AV56TipADCod1;
         AV73Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV74Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV75Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV76Contabilidad_auxiliareswwds_8_tipaddsc2 = AV21TipADDsc2;
         AV77Contabilidad_auxiliareswwds_9_tipadcod2 = AV59TipADCod2;
         AV78Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV79Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV80Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV81Contabilidad_auxiliareswwds_13_tipaddsc3 = AV25TipADDsc3;
         AV82Contabilidad_auxiliareswwds_14_tipadcod3 = AV60TipADCod3;
         AV83Contabilidad_auxiliareswwds_15_tftipadsc = AV61TFTipADsc;
         AV84Contabilidad_auxiliareswwds_16_tftipadsc_sel = AV62TFTipADsc_Sel;
         AV85Contabilidad_auxiliareswwds_17_tftipadcod = AV33TFTipADCod;
         AV86Contabilidad_auxiliareswwds_18_tftipadcod_sel = AV34TFTipADCod_Sel;
         AV87Contabilidad_auxiliareswwds_19_tftipaddsc = AV35TFTipADDsc;
         AV88Contabilidad_auxiliareswwds_20_tftipaddsc_sel = AV36TFTipADDsc_Sel;
         AV89Contabilidad_auxiliareswwds_21_tftipadsts_sels = AV39TFTipADSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1901TipADSts ,
                                              AV89Contabilidad_auxiliareswwds_21_tftipadsts_sels ,
                                              AV69Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ,
                                              AV70Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ,
                                              AV71Contabilidad_auxiliareswwds_3_tipaddsc1 ,
                                              AV72Contabilidad_auxiliareswwds_4_tipadcod1 ,
                                              AV73Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ,
                                              AV74Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ,
                                              AV75Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ,
                                              AV76Contabilidad_auxiliareswwds_8_tipaddsc2 ,
                                              AV77Contabilidad_auxiliareswwds_9_tipadcod2 ,
                                              AV78Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ,
                                              AV79Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ,
                                              AV80Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ,
                                              AV81Contabilidad_auxiliareswwds_13_tipaddsc3 ,
                                              AV82Contabilidad_auxiliareswwds_14_tipadcod3 ,
                                              AV84Contabilidad_auxiliareswwds_16_tftipadsc_sel ,
                                              AV83Contabilidad_auxiliareswwds_15_tftipadsc ,
                                              AV86Contabilidad_auxiliareswwds_18_tftipadcod_sel ,
                                              AV85Contabilidad_auxiliareswwds_17_tftipadcod ,
                                              AV88Contabilidad_auxiliareswwds_20_tftipaddsc_sel ,
                                              AV87Contabilidad_auxiliareswwds_19_tftipaddsc ,
                                              AV89Contabilidad_auxiliareswwds_21_tftipadsts_sels.Count ,
                                              A72TipADDsc ,
                                              A71TipADCod ,
                                              A1900TipADsc ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV71Contabilidad_auxiliareswwds_3_tipaddsc1 = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_3_tipaddsc1), 100, "%");
         lV71Contabilidad_auxiliareswwds_3_tipaddsc1 = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_3_tipaddsc1), 100, "%");
         lV72Contabilidad_auxiliareswwds_4_tipadcod1 = StringUtil.PadR( StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_4_tipadcod1), 20, "%");
         lV72Contabilidad_auxiliareswwds_4_tipadcod1 = StringUtil.PadR( StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_4_tipadcod1), 20, "%");
         lV76Contabilidad_auxiliareswwds_8_tipaddsc2 = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_auxiliareswwds_8_tipaddsc2), 100, "%");
         lV76Contabilidad_auxiliareswwds_8_tipaddsc2 = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_auxiliareswwds_8_tipaddsc2), 100, "%");
         lV77Contabilidad_auxiliareswwds_9_tipadcod2 = StringUtil.PadR( StringUtil.RTrim( AV77Contabilidad_auxiliareswwds_9_tipadcod2), 20, "%");
         lV77Contabilidad_auxiliareswwds_9_tipadcod2 = StringUtil.PadR( StringUtil.RTrim( AV77Contabilidad_auxiliareswwds_9_tipadcod2), 20, "%");
         lV81Contabilidad_auxiliareswwds_13_tipaddsc3 = StringUtil.PadR( StringUtil.RTrim( AV81Contabilidad_auxiliareswwds_13_tipaddsc3), 100, "%");
         lV81Contabilidad_auxiliareswwds_13_tipaddsc3 = StringUtil.PadR( StringUtil.RTrim( AV81Contabilidad_auxiliareswwds_13_tipaddsc3), 100, "%");
         lV82Contabilidad_auxiliareswwds_14_tipadcod3 = StringUtil.PadR( StringUtil.RTrim( AV82Contabilidad_auxiliareswwds_14_tipadcod3), 20, "%");
         lV82Contabilidad_auxiliareswwds_14_tipadcod3 = StringUtil.PadR( StringUtil.RTrim( AV82Contabilidad_auxiliareswwds_14_tipadcod3), 20, "%");
         lV83Contabilidad_auxiliareswwds_15_tftipadsc = StringUtil.PadR( StringUtil.RTrim( AV83Contabilidad_auxiliareswwds_15_tftipadsc), 100, "%");
         lV85Contabilidad_auxiliareswwds_17_tftipadcod = StringUtil.PadR( StringUtil.RTrim( AV85Contabilidad_auxiliareswwds_17_tftipadcod), 20, "%");
         lV87Contabilidad_auxiliareswwds_19_tftipaddsc = StringUtil.PadR( StringUtil.RTrim( AV87Contabilidad_auxiliareswwds_19_tftipaddsc), 100, "%");
         /* Using cursor P006P2 */
         pr_default.execute(0, new Object[] {lV71Contabilidad_auxiliareswwds_3_tipaddsc1, lV71Contabilidad_auxiliareswwds_3_tipaddsc1, lV72Contabilidad_auxiliareswwds_4_tipadcod1, lV72Contabilidad_auxiliareswwds_4_tipadcod1, lV76Contabilidad_auxiliareswwds_8_tipaddsc2, lV76Contabilidad_auxiliareswwds_8_tipaddsc2, lV77Contabilidad_auxiliareswwds_9_tipadcod2, lV77Contabilidad_auxiliareswwds_9_tipadcod2, lV81Contabilidad_auxiliareswwds_13_tipaddsc3, lV81Contabilidad_auxiliareswwds_13_tipaddsc3, lV82Contabilidad_auxiliareswwds_14_tipadcod3, lV82Contabilidad_auxiliareswwds_14_tipadcod3, lV83Contabilidad_auxiliareswwds_15_tftipadsc, AV84Contabilidad_auxiliareswwds_16_tftipadsc_sel, lV85Contabilidad_auxiliareswwds_17_tftipadcod, AV86Contabilidad_auxiliareswwds_18_tftipadcod_sel, lV87Contabilidad_auxiliareswwds_19_tftipaddsc, AV88Contabilidad_auxiliareswwds_20_tftipaddsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1901TipADSts = P006P2_A1901TipADSts[0];
            A1900TipADsc = P006P2_A1900TipADsc[0];
            A71TipADCod = P006P2_A71TipADCod[0];
            A72TipADDsc = P006P2_A72TipADDsc[0];
            A70TipACod = P006P2_A70TipACod[0];
            A1900TipADsc = P006P2_A1900TipADsc[0];
            if ( A1901TipADSts == 1 )
            {
               AV12TipADStsDescription = "ACTIVO";
            }
            else if ( A1901TipADSts == 0 )
            {
               AV12TipADStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6P0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1900TipADsc, "")), 30, Gx_line+10, 216, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A71TipADCod, "")), 220, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A72TipADDsc, "")), 410, Gx_line+10, 596, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12TipADStsDescription, "")), 600, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Contabilidad.AuxiliaresWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.AuxiliaresWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Contabilidad.AuxiliaresWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV90GXV2 = 1;
         while ( AV90GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV90GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPADSC") == 0 )
            {
               AV61TFTipADsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPADSC_SEL") == 0 )
            {
               AV62TFTipADsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPADCOD") == 0 )
            {
               AV33TFTipADCod = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPADCOD_SEL") == 0 )
            {
               AV34TFTipADCod_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPADDSC") == 0 )
            {
               AV35TFTipADDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPADDSC_SEL") == 0 )
            {
               AV36TFTipADDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPADSTS_SEL") == 0 )
            {
               AV37TFTipADSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV39TFTipADSts_Sels.FromJSonString(AV37TFTipADSts_SelsJson, null);
            }
            AV90GXV2 = (int)(AV90GXV2+1);
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

      protected void H6P0( bool bFoot ,
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
         AV15TipADDsc1 = "";
         AV16FilterTipADDscDescription = "";
         AV17TipADDsc = "";
         AV56TipADCod1 = "";
         AV57FilterTipADCodDescription = "";
         AV58TipADCod = "";
         AV19DynamicFiltersSelector2 = "";
         AV21TipADDsc2 = "";
         AV59TipADCod2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25TipADDsc3 = "";
         AV60TipADCod3 = "";
         AV62TFTipADsc_Sel = "";
         AV61TFTipADsc = "";
         AV34TFTipADCod_Sel = "";
         AV33TFTipADCod = "";
         AV36TFTipADDsc_Sel = "";
         AV35TFTipADDsc = "";
         AV39TFTipADSts_Sels = new GxSimpleCollection<short>();
         AV37TFTipADSts_SelsJson = "";
         AV38TFTipADSts_SelDscs = "";
         AV42FilterTFTipADSts_SelValueDescription = "";
         AV69Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = "";
         AV71Contabilidad_auxiliareswwds_3_tipaddsc1 = "";
         AV72Contabilidad_auxiliareswwds_4_tipadcod1 = "";
         AV74Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = "";
         AV76Contabilidad_auxiliareswwds_8_tipaddsc2 = "";
         AV77Contabilidad_auxiliareswwds_9_tipadcod2 = "";
         AV79Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = "";
         AV81Contabilidad_auxiliareswwds_13_tipaddsc3 = "";
         AV82Contabilidad_auxiliareswwds_14_tipadcod3 = "";
         AV83Contabilidad_auxiliareswwds_15_tftipadsc = "";
         AV84Contabilidad_auxiliareswwds_16_tftipadsc_sel = "";
         AV85Contabilidad_auxiliareswwds_17_tftipadcod = "";
         AV86Contabilidad_auxiliareswwds_18_tftipadcod_sel = "";
         AV87Contabilidad_auxiliareswwds_19_tftipaddsc = "";
         AV88Contabilidad_auxiliareswwds_20_tftipaddsc_sel = "";
         AV89Contabilidad_auxiliareswwds_21_tftipadsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV71Contabilidad_auxiliareswwds_3_tipaddsc1 = "";
         lV72Contabilidad_auxiliareswwds_4_tipadcod1 = "";
         lV76Contabilidad_auxiliareswwds_8_tipaddsc2 = "";
         lV77Contabilidad_auxiliareswwds_9_tipadcod2 = "";
         lV81Contabilidad_auxiliareswwds_13_tipaddsc3 = "";
         lV82Contabilidad_auxiliareswwds_14_tipadcod3 = "";
         lV83Contabilidad_auxiliareswwds_15_tftipadsc = "";
         lV85Contabilidad_auxiliareswwds_17_tftipadcod = "";
         lV87Contabilidad_auxiliareswwds_19_tftipaddsc = "";
         A72TipADDsc = "";
         A71TipADCod = "";
         A1900TipADsc = "";
         P006P2_A1901TipADSts = new short[1] ;
         P006P2_A1900TipADsc = new string[] {""} ;
         P006P2_A71TipADCod = new string[] {""} ;
         P006P2_A72TipADDsc = new string[] {""} ;
         P006P2_A70TipACod = new int[1] ;
         AV12TipADStsDescription = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.auxiliareswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006P2_A1901TipADSts, P006P2_A1900TipADsc, P006P2_A71TipADCod, P006P2_A72TipADDsc, P006P2_A70TipACod
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
      private short AV40TFTipADSts_Sel ;
      private short AV70Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ;
      private short AV75Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ;
      private short AV80Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ;
      private short A1901TipADSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV67GXV1 ;
      private int AV89Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count ;
      private int A70TipACod ;
      private int AV90GXV2 ;
      private long AV43i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15TipADDsc1 ;
      private string AV17TipADDsc ;
      private string AV56TipADCod1 ;
      private string AV58TipADCod ;
      private string AV21TipADDsc2 ;
      private string AV59TipADCod2 ;
      private string AV25TipADDsc3 ;
      private string AV60TipADCod3 ;
      private string AV62TFTipADsc_Sel ;
      private string AV61TFTipADsc ;
      private string AV34TFTipADCod_Sel ;
      private string AV33TFTipADCod ;
      private string AV36TFTipADDsc_Sel ;
      private string AV35TFTipADDsc ;
      private string AV71Contabilidad_auxiliareswwds_3_tipaddsc1 ;
      private string AV72Contabilidad_auxiliareswwds_4_tipadcod1 ;
      private string AV76Contabilidad_auxiliareswwds_8_tipaddsc2 ;
      private string AV77Contabilidad_auxiliareswwds_9_tipadcod2 ;
      private string AV81Contabilidad_auxiliareswwds_13_tipaddsc3 ;
      private string AV82Contabilidad_auxiliareswwds_14_tipadcod3 ;
      private string AV83Contabilidad_auxiliareswwds_15_tftipadsc ;
      private string AV84Contabilidad_auxiliareswwds_16_tftipadsc_sel ;
      private string AV85Contabilidad_auxiliareswwds_17_tftipadcod ;
      private string AV86Contabilidad_auxiliareswwds_18_tftipadcod_sel ;
      private string AV87Contabilidad_auxiliareswwds_19_tftipaddsc ;
      private string AV88Contabilidad_auxiliareswwds_20_tftipaddsc_sel ;
      private string scmdbuf ;
      private string lV71Contabilidad_auxiliareswwds_3_tipaddsc1 ;
      private string lV72Contabilidad_auxiliareswwds_4_tipadcod1 ;
      private string lV76Contabilidad_auxiliareswwds_8_tipaddsc2 ;
      private string lV77Contabilidad_auxiliareswwds_9_tipadcod2 ;
      private string lV81Contabilidad_auxiliareswwds_13_tipaddsc3 ;
      private string lV82Contabilidad_auxiliareswwds_14_tipadcod3 ;
      private string lV83Contabilidad_auxiliareswwds_15_tftipadsc ;
      private string lV85Contabilidad_auxiliareswwds_17_tftipadcod ;
      private string lV87Contabilidad_auxiliareswwds_19_tftipaddsc ;
      private string A72TipADDsc ;
      private string A71TipADCod ;
      private string A1900TipADsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV73Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ;
      private bool AV78Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV37TFTipADSts_SelsJson ;
      private string AV54Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterTipADDscDescription ;
      private string AV57FilterTipADCodDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV38TFTipADSts_SelDscs ;
      private string AV42FilterTFTipADSts_SelValueDescription ;
      private string AV69Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ;
      private string AV74Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ;
      private string AV79Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ;
      private string AV12TipADStsDescription ;
      private string AV52PageInfo ;
      private string AV49DateInfo ;
      private string AV47AppName ;
      private string AV53Phone ;
      private string AV51Mail ;
      private string AV55Website ;
      private string AV44AddressLine1 ;
      private string AV45AddressLine2 ;
      private string AV46AddressLine3 ;
      private GxSimpleCollection<short> AV39TFTipADSts_Sels ;
      private GxSimpleCollection<short> AV89Contabilidad_auxiliareswwds_21_tftipadsts_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006P2_A1901TipADSts ;
      private string[] P006P2_A1900TipADsc ;
      private string[] P006P2_A71TipADCod ;
      private string[] P006P2_A72TipADDsc ;
      private int[] P006P2_A70TipACod ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class auxiliareswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006P2( IGxContext context ,
                                             short A1901TipADSts ,
                                             GxSimpleCollection<short> AV89Contabilidad_auxiliareswwds_21_tftipadsts_sels ,
                                             string AV69Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ,
                                             short AV70Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ,
                                             string AV71Contabilidad_auxiliareswwds_3_tipaddsc1 ,
                                             string AV72Contabilidad_auxiliareswwds_4_tipadcod1 ,
                                             bool AV73Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ,
                                             string AV74Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ,
                                             short AV75Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ,
                                             string AV76Contabilidad_auxiliareswwds_8_tipaddsc2 ,
                                             string AV77Contabilidad_auxiliareswwds_9_tipadcod2 ,
                                             bool AV78Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ,
                                             string AV79Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ,
                                             short AV80Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ,
                                             string AV81Contabilidad_auxiliareswwds_13_tipaddsc3 ,
                                             string AV82Contabilidad_auxiliareswwds_14_tipadcod3 ,
                                             string AV84Contabilidad_auxiliareswwds_16_tftipadsc_sel ,
                                             string AV83Contabilidad_auxiliareswwds_15_tftipadsc ,
                                             string AV86Contabilidad_auxiliareswwds_18_tftipadcod_sel ,
                                             string AV85Contabilidad_auxiliareswwds_17_tftipadcod ,
                                             string AV88Contabilidad_auxiliareswwds_20_tftipaddsc_sel ,
                                             string AV87Contabilidad_auxiliareswwds_19_tftipaddsc ,
                                             int AV89Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count ,
                                             string A72TipADDsc ,
                                             string A71TipADCod ,
                                             string A1900TipADsc ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[18];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[TipADSts], T2.[TipADsc], T1.[TipADCod], T1.[TipADDsc], T1.[TipACod] FROM ([CBAUXILIARES] T1 INNER JOIN [CBTIPAUXILIAR] T2 ON T2.[TipACod] = T1.[TipACod])";
         if ( ( StringUtil.StrCmp(AV69Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADDSC") == 0 ) && ( AV70Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_3_tipaddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV71Contabilidad_auxiliareswwds_3_tipaddsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADDSC") == 0 ) && ( AV70Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_3_tipaddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV71Contabilidad_auxiliareswwds_3_tipaddsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADCOD") == 0 ) && ( AV70Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_4_tipadcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV72Contabilidad_auxiliareswwds_4_tipadcod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADCOD") == 0 ) && ( AV70Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_4_tipadcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV72Contabilidad_auxiliareswwds_4_tipadcod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV73Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADDSC") == 0 ) && ( AV75Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_auxiliareswwds_8_tipaddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV76Contabilidad_auxiliareswwds_8_tipaddsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV73Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADDSC") == 0 ) && ( AV75Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_auxiliareswwds_8_tipaddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV76Contabilidad_auxiliareswwds_8_tipaddsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV73Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADCOD") == 0 ) && ( AV75Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_auxiliareswwds_9_tipadcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV77Contabilidad_auxiliareswwds_9_tipadcod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV73Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADCOD") == 0 ) && ( AV75Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_auxiliareswwds_9_tipadcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV77Contabilidad_auxiliareswwds_9_tipadcod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV78Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADDSC") == 0 ) && ( AV80Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_auxiliareswwds_13_tipaddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV81Contabilidad_auxiliareswwds_13_tipaddsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV78Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADDSC") == 0 ) && ( AV80Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_auxiliareswwds_13_tipaddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV81Contabilidad_auxiliareswwds_13_tipaddsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV78Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADCOD") == 0 ) && ( AV80Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Contabilidad_auxiliareswwds_14_tipadcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV82Contabilidad_auxiliareswwds_14_tipadcod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV78Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADCOD") == 0 ) && ( AV80Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Contabilidad_auxiliareswwds_14_tipadcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV82Contabilidad_auxiliareswwds_14_tipadcod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabilidad_auxiliareswwds_16_tftipadsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Contabilidad_auxiliareswwds_15_tftipadsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipADsc] like @lV83Contabilidad_auxiliareswwds_15_tftipadsc)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabilidad_auxiliareswwds_16_tftipadsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipADsc] = @AV84Contabilidad_auxiliareswwds_16_tftipadsc_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Contabilidad_auxiliareswwds_18_tftipadcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Contabilidad_auxiliareswwds_17_tftipadcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV85Contabilidad_auxiliareswwds_17_tftipadcod)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Contabilidad_auxiliareswwds_18_tftipadcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] = @AV86Contabilidad_auxiliareswwds_18_tftipadcod_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Contabilidad_auxiliareswwds_20_tftipaddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Contabilidad_auxiliareswwds_19_tftipaddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV87Contabilidad_auxiliareswwds_19_tftipaddsc)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Contabilidad_auxiliareswwds_20_tftipaddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] = @AV88Contabilidad_auxiliareswwds_20_tftipaddsc_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV89Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV89Contabilidad_auxiliareswwds_21_tftipadsts_sels, "T1.[TipADSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[TipACod], T1.[TipADCod]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[TipADsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[TipADsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipADCod]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipADCod] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipADDsc]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipADDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipADSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipADSts] DESC";
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
                     return conditional_P006P2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP006P2;
          prmP006P2 = new Object[] {
          new ParDef("@lV71Contabilidad_auxiliareswwds_3_tipaddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV71Contabilidad_auxiliareswwds_3_tipaddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV72Contabilidad_auxiliareswwds_4_tipadcod1",GXType.NChar,20,0) ,
          new ParDef("@lV72Contabilidad_auxiliareswwds_4_tipadcod1",GXType.NChar,20,0) ,
          new ParDef("@lV76Contabilidad_auxiliareswwds_8_tipaddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV76Contabilidad_auxiliareswwds_8_tipaddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV77Contabilidad_auxiliareswwds_9_tipadcod2",GXType.NChar,20,0) ,
          new ParDef("@lV77Contabilidad_auxiliareswwds_9_tipadcod2",GXType.NChar,20,0) ,
          new ParDef("@lV81Contabilidad_auxiliareswwds_13_tipaddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV81Contabilidad_auxiliareswwds_13_tipaddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV82Contabilidad_auxiliareswwds_14_tipadcod3",GXType.NChar,20,0) ,
          new ParDef("@lV82Contabilidad_auxiliareswwds_14_tipadcod3",GXType.NChar,20,0) ,
          new ParDef("@lV83Contabilidad_auxiliareswwds_15_tftipadsc",GXType.NChar,100,0) ,
          new ParDef("@AV84Contabilidad_auxiliareswwds_16_tftipadsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV85Contabilidad_auxiliareswwds_17_tftipadcod",GXType.NChar,20,0) ,
          new ParDef("@AV86Contabilidad_auxiliareswwds_18_tftipadcod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV87Contabilidad_auxiliareswwds_19_tftipaddsc",GXType.NChar,100,0) ,
          new ParDef("@AV88Contabilidad_auxiliareswwds_20_tftipaddsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006P2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
