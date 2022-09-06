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
   public class tipocambiowwexportreport : GXWebProcedure
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

      public tipocambiowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipocambiowwexportreport( IGxContext context )
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
         tipocambiowwexportreport objtipocambiowwexportreport;
         objtipocambiowwexportreport = new tipocambiowwexportreport();
         objtipocambiowwexportreport.context.SetSubmitInitialConfig(context);
         objtipocambiowwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipocambiowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipocambiowwexportreport)stateInfo).executePrivate();
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
            AV49Title = "Lista de Tipo Cambio";
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
            H520( true, 0) ;
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
               AV53MonDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53MonDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV54FilterMonDscDescription = StringUtil.Format( "%1 (%2)", "Moneda", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV54FilterMonDscDescription = StringUtil.Format( "%1 (%2)", "Moneda", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV55MonDsc = AV53MonDsc1;
                  H520( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54FilterMonDscDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55MonDsc, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "TIPFECH") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV58TipFech1 = context.localUtil.CToD( AV25GridStateDynamicFilter.gxTpr_Value, 2);
               AV59TipFech_To1 = context.localUtil.CToD( AV25GridStateDynamicFilter.gxTpr_Valueto, 2);
               if ( ! (DateTime.MinValue==AV58TipFech1) || ! (DateTime.MinValue==AV59TipFech_To1) )
               {
                  AV56FixedValueOperatorDsc = "Fecha";
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV57FixedValueOperatorValue = "Pasado";
                     H520( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FixedValueOperatorDsc, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FixedValueOperatorValue, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV57FixedValueOperatorValue = "Hoy";
                     H520( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FixedValueOperatorDsc, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FixedValueOperatorValue, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
                  else if ( AV13DynamicFiltersOperator1 == 2 )
                  {
                     AV57FixedValueOperatorValue = "En el futuro";
                     H520( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FixedValueOperatorDsc, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FixedValueOperatorValue, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
                  else if ( AV13DynamicFiltersOperator1 == 3 )
                  {
                     AV60FilterTipFechDescription = StringUtil.Format( "%1 (%2)", "Fecha", "Período", "", "", "", "", "", "", "");
                     AV61TipFech = AV58TipFech1;
                     H520( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60FilterTipFechDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV61TipFech, "99/99/99"), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                     AV60FilterTipFechDescription = StringUtil.Format( "%1 (%2) %3", "Fecha", "Período", "", "", "", "", "", "", "");
                     AV61TipFech = AV59TipFech_To1;
                     H520( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60FilterTipFechDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV61TipFech, "99/99/99"), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
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
                  AV62MonDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62MonDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV54FilterMonDscDescription = StringUtil.Format( "%1 (%2)", "Moneda", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV54FilterMonDscDescription = StringUtil.Format( "%1 (%2)", "Moneda", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV55MonDsc = AV62MonDsc2;
                     H520( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54FilterMonDscDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55MonDsc, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "TIPFECH") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV63TipFech2 = context.localUtil.CToD( AV25GridStateDynamicFilter.gxTpr_Value, 2);
                  AV64TipFech_To2 = context.localUtil.CToD( AV25GridStateDynamicFilter.gxTpr_Valueto, 2);
                  if ( ! (DateTime.MinValue==AV63TipFech2) || ! (DateTime.MinValue==AV64TipFech_To2) )
                  {
                     AV56FixedValueOperatorDsc = "Fecha";
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV57FixedValueOperatorValue = "Pasado";
                        H520( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FixedValueOperatorDsc, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FixedValueOperatorValue, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV57FixedValueOperatorValue = "Hoy";
                        H520( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FixedValueOperatorDsc, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FixedValueOperatorValue, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                     else if ( AV19DynamicFiltersOperator2 == 2 )
                     {
                        AV57FixedValueOperatorValue = "En el futuro";
                        H520( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FixedValueOperatorDsc, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FixedValueOperatorValue, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                     else if ( AV19DynamicFiltersOperator2 == 3 )
                     {
                        AV60FilterTipFechDescription = StringUtil.Format( "%1 (%2)", "Fecha", "Período", "", "", "", "", "", "", "");
                        AV61TipFech = AV63TipFech2;
                        H520( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60FilterTipFechDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV61TipFech, "99/99/99"), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                        AV60FilterTipFechDescription = StringUtil.Format( "%1 (%2) %3", "Fecha", "Período", "", "", "", "", "", "", "");
                        AV61TipFech = AV64TipFech_To2;
                        H520( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60FilterTipFechDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV61TipFech, "99/99/99"), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
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
                     AV65MonDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65MonDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV54FilterMonDscDescription = StringUtil.Format( "%1 (%2)", "Moneda", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV54FilterMonDscDescription = StringUtil.Format( "%1 (%2)", "Moneda", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV55MonDsc = AV65MonDsc3;
                        H520( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54FilterMonDscDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55MonDsc, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "TIPFECH") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV66TipFech3 = context.localUtil.CToD( AV25GridStateDynamicFilter.gxTpr_Value, 2);
                     AV67TipFech_To3 = context.localUtil.CToD( AV25GridStateDynamicFilter.gxTpr_Valueto, 2);
                     if ( ! (DateTime.MinValue==AV66TipFech3) || ! (DateTime.MinValue==AV67TipFech_To3) )
                     {
                        AV56FixedValueOperatorDsc = "Fecha";
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV57FixedValueOperatorValue = "Pasado";
                           H520( false, 20) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FixedValueOperatorDsc, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FixedValueOperatorValue, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+20);
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV57FixedValueOperatorValue = "Hoy";
                           H520( false, 20) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FixedValueOperatorDsc, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FixedValueOperatorValue, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+20);
                        }
                        else if ( AV23DynamicFiltersOperator3 == 2 )
                        {
                           AV57FixedValueOperatorValue = "En el futuro";
                           H520( false, 20) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56FixedValueOperatorDsc, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57FixedValueOperatorValue, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+20);
                        }
                        else if ( AV23DynamicFiltersOperator3 == 3 )
                        {
                           AV60FilterTipFechDescription = StringUtil.Format( "%1 (%2)", "Fecha", "Período", "", "", "", "", "", "", "");
                           AV61TipFech = AV66TipFech3;
                           H520( false, 20) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60FilterTipFechDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.localUtil.Format( AV61TipFech, "99/99/99"), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+20);
                           AV60FilterTipFechDescription = StringUtil.Format( "%1 (%2) %3", "Fecha", "Período", "", "", "", "", "", "", "");
                           AV61TipFech = AV67TipFech_To3;
                           H520( false, 20) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60FilterTipFechDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.localUtil.Format( AV61TipFech, "99/99/99"), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+20);
                        }
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TFMonDsc_Sel)) )
         {
            H520( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Moneda", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFMonDsc_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFMonDsc)) )
            {
               H520( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Moneda", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFMonDsc, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV30TFTipFech) && (DateTime.MinValue==AV31TFTipFech_To) ) )
         {
            H520( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Fecha", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV30TFTipFech, "99/99/99"), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV36TFTipFech_To_Description = StringUtil.Format( "%1 (%2)", "Fecha", "Hasta", "", "", "", "", "", "", "");
            H520( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFTipFech_To_Description, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV31TFTipFech_To, "99/99/99"), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV32TFTipCompra) && (Convert.ToDecimal(0)==AV33TFTipCompra_To) ) )
         {
            H520( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Compra", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32TFTipCompra, "ZZZZZZZZ9.99999")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV37TFTipCompra_To_Description = StringUtil.Format( "%1 (%2)", "Compra", "Hasta", "", "", "", "", "", "", "");
            H520( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFTipCompra_To_Description, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33TFTipCompra_To, "ZZZZZZZZ9.99999")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV34TFTipVenta) && (Convert.ToDecimal(0)==AV35TFTipVenta_To) ) )
         {
            H520( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Venta", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34TFTipVenta, "ZZZZZZZZ9.99999")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV38TFTipVenta_To_Description = StringUtil.Format( "%1 (%2)", "Venta", "Hasta", "", "", "", "", "", "", "");
            H520( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFTipVenta_To_Description, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35TFTipVenta_To, "ZZZZZZZZ9.99999")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H520( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H520( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Moneda", 30, Gx_line+10, 328, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Fecha", 332, Gx_line+10, 481, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Compra", 485, Gx_line+10, 634, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Venta", 638, Gx_line+10, 787, Gx_line+27, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV73Configuracion_tipocambiowwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV74Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV75Configuracion_tipocambiowwds_3_mondsc1 = AV53MonDsc1;
         AV76Configuracion_tipocambiowwds_4_tipfech1 = AV58TipFech1;
         AV77Configuracion_tipocambiowwds_5_tipfech_to1 = AV59TipFech_To1;
         AV78Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV79Configuracion_tipocambiowwds_7_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV80Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV81Configuracion_tipocambiowwds_9_mondsc2 = AV62MonDsc2;
         AV82Configuracion_tipocambiowwds_10_tipfech2 = AV63TipFech2;
         AV83Configuracion_tipocambiowwds_11_tipfech_to2 = AV64TipFech_To2;
         AV84Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV85Configuracion_tipocambiowwds_13_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV86Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV87Configuracion_tipocambiowwds_15_mondsc3 = AV65MonDsc3;
         AV88Configuracion_tipocambiowwds_16_tipfech3 = AV66TipFech3;
         AV89Configuracion_tipocambiowwds_17_tipfech_to3 = AV67TipFech_To3;
         AV90Configuracion_tipocambiowwds_18_tfmondsc = AV51TFMonDsc;
         AV91Configuracion_tipocambiowwds_19_tfmondsc_sel = AV52TFMonDsc_Sel;
         AV92Configuracion_tipocambiowwds_20_tftipfech = AV30TFTipFech;
         AV93Configuracion_tipocambiowwds_21_tftipfech_to = AV31TFTipFech_To;
         AV94Configuracion_tipocambiowwds_22_tftipcompra = AV32TFTipCompra;
         AV95Configuracion_tipocambiowwds_23_tftipcompra_to = AV33TFTipCompra_To;
         AV96Configuracion_tipocambiowwds_24_tftipventa = AV34TFTipVenta;
         AV97Configuracion_tipocambiowwds_25_tftipventa_to = AV35TFTipVenta_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV73Configuracion_tipocambiowwds_1_dynamicfiltersselector1 ,
                                              AV74Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 ,
                                              AV75Configuracion_tipocambiowwds_3_mondsc1 ,
                                              AV76Configuracion_tipocambiowwds_4_tipfech1 ,
                                              AV77Configuracion_tipocambiowwds_5_tipfech_to1 ,
                                              AV78Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 ,
                                              AV79Configuracion_tipocambiowwds_7_dynamicfiltersselector2 ,
                                              AV80Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 ,
                                              AV81Configuracion_tipocambiowwds_9_mondsc2 ,
                                              AV82Configuracion_tipocambiowwds_10_tipfech2 ,
                                              AV83Configuracion_tipocambiowwds_11_tipfech_to2 ,
                                              AV84Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 ,
                                              AV85Configuracion_tipocambiowwds_13_dynamicfiltersselector3 ,
                                              AV86Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 ,
                                              AV87Configuracion_tipocambiowwds_15_mondsc3 ,
                                              AV88Configuracion_tipocambiowwds_16_tipfech3 ,
                                              AV89Configuracion_tipocambiowwds_17_tipfech_to3 ,
                                              AV91Configuracion_tipocambiowwds_19_tfmondsc_sel ,
                                              AV90Configuracion_tipocambiowwds_18_tfmondsc ,
                                              AV92Configuracion_tipocambiowwds_20_tftipfech ,
                                              AV93Configuracion_tipocambiowwds_21_tftipfech_to ,
                                              AV94Configuracion_tipocambiowwds_22_tftipcompra ,
                                              AV95Configuracion_tipocambiowwds_23_tftipcompra_to ,
                                              AV96Configuracion_tipocambiowwds_24_tftipventa ,
                                              AV97Configuracion_tipocambiowwds_25_tftipventa_to ,
                                              A1234MonDsc ,
                                              A308TipFech ,
                                              A1907TipCompra ,
                                              A1920TipVenta ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV75Configuracion_tipocambiowwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_tipocambiowwds_3_mondsc1), 100, "%");
         lV75Configuracion_tipocambiowwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_tipocambiowwds_3_mondsc1), 100, "%");
         lV81Configuracion_tipocambiowwds_9_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_tipocambiowwds_9_mondsc2), 100, "%");
         lV81Configuracion_tipocambiowwds_9_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_tipocambiowwds_9_mondsc2), 100, "%");
         lV87Configuracion_tipocambiowwds_15_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_tipocambiowwds_15_mondsc3), 100, "%");
         lV87Configuracion_tipocambiowwds_15_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_tipocambiowwds_15_mondsc3), 100, "%");
         lV90Configuracion_tipocambiowwds_18_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV90Configuracion_tipocambiowwds_18_tfmondsc), 100, "%");
         /* Using cursor P00522 */
         pr_default.execute(0, new Object[] {lV75Configuracion_tipocambiowwds_3_mondsc1, lV75Configuracion_tipocambiowwds_3_mondsc1, AV76Configuracion_tipocambiowwds_4_tipfech1, AV76Configuracion_tipocambiowwds_4_tipfech1, AV76Configuracion_tipocambiowwds_4_tipfech1, AV76Configuracion_tipocambiowwds_4_tipfech1, AV77Configuracion_tipocambiowwds_5_tipfech_to1, lV81Configuracion_tipocambiowwds_9_mondsc2, lV81Configuracion_tipocambiowwds_9_mondsc2, AV82Configuracion_tipocambiowwds_10_tipfech2, AV82Configuracion_tipocambiowwds_10_tipfech2, AV82Configuracion_tipocambiowwds_10_tipfech2, AV82Configuracion_tipocambiowwds_10_tipfech2, AV83Configuracion_tipocambiowwds_11_tipfech_to2, lV87Configuracion_tipocambiowwds_15_mondsc3, lV87Configuracion_tipocambiowwds_15_mondsc3, AV88Configuracion_tipocambiowwds_16_tipfech3, AV88Configuracion_tipocambiowwds_16_tipfech3, AV88Configuracion_tipocambiowwds_16_tipfech3, AV88Configuracion_tipocambiowwds_16_tipfech3, AV89Configuracion_tipocambiowwds_17_tipfech_to3, lV90Configuracion_tipocambiowwds_18_tfmondsc, AV91Configuracion_tipocambiowwds_19_tfmondsc_sel, AV92Configuracion_tipocambiowwds_20_tftipfech, AV93Configuracion_tipocambiowwds_21_tftipfech_to, AV94Configuracion_tipocambiowwds_22_tftipcompra, AV95Configuracion_tipocambiowwds_23_tftipcompra_to, AV96Configuracion_tipocambiowwds_24_tftipventa, AV97Configuracion_tipocambiowwds_25_tftipventa_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A307TipMonCod = P00522_A307TipMonCod[0];
            A1920TipVenta = P00522_A1920TipVenta[0];
            A1907TipCompra = P00522_A1907TipCompra[0];
            A308TipFech = P00522_A308TipFech[0];
            A1234MonDsc = P00522_A1234MonDsc[0];
            n1234MonDsc = P00522_n1234MonDsc[0];
            A1234MonDsc = P00522_A1234MonDsc[0];
            n1234MonDsc = P00522_n1234MonDsc[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H520( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 30, Gx_line+10, 328, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A308TipFech, "99/99/99"), 332, Gx_line+10, 481, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1907TipCompra, "ZZZZZZZZ9.99999")), 485, Gx_line+10, 634, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1920TipVenta, "ZZZZZZZZ9.99999")), 638, Gx_line+10, 787, Gx_line+25, 2, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Configuracion.TipoCambioWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoCambioWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Configuracion.TipoCambioWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV98GXV1 = 1;
         while ( AV98GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV98GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFMONDSC") == 0 )
            {
               AV51TFMonDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFMONDSC_SEL") == 0 )
            {
               AV52TFMonDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIPFECH") == 0 )
            {
               AV30TFTipFech = context.localUtil.CToD( AV29GridStateFilterValue.gxTpr_Value, 2);
               AV31TFTipFech_To = context.localUtil.CToD( AV29GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIPCOMPRA") == 0 )
            {
               AV32TFTipCompra = NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, ".");
               AV33TFTipCompra_To = NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIPVENTA") == 0 )
            {
               AV34TFTipVenta = NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, ".");
               AV35TFTipVenta_To = NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV98GXV1 = (int)(AV98GXV1+1);
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

      protected void H520( bool bFoot ,
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
                  AV47PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV44DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV42AppName = "DVelop Software Solutions";
               AV48Phone = "+1 550 8923";
               AV46Mail = "info@mail.com";
               AV50Website = "http://www.web.com";
               AV39AddressLine1 = "French Boulevard 2859";
               AV40AddressLine2 = "Downtown";
               AV41AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV49Title = "";
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV25GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV53MonDsc1 = "";
         AV54FilterMonDscDescription = "";
         AV55MonDsc = "";
         AV58TipFech1 = DateTime.MinValue;
         AV59TipFech_To1 = DateTime.MinValue;
         AV56FixedValueOperatorDsc = "";
         AV57FixedValueOperatorValue = "";
         AV60FilterTipFechDescription = "";
         AV61TipFech = DateTime.MinValue;
         AV18DynamicFiltersSelector2 = "";
         AV62MonDsc2 = "";
         AV63TipFech2 = DateTime.MinValue;
         AV64TipFech_To2 = DateTime.MinValue;
         AV22DynamicFiltersSelector3 = "";
         AV65MonDsc3 = "";
         AV66TipFech3 = DateTime.MinValue;
         AV67TipFech_To3 = DateTime.MinValue;
         AV52TFMonDsc_Sel = "";
         AV51TFMonDsc = "";
         AV30TFTipFech = DateTime.MinValue;
         AV31TFTipFech_To = DateTime.MinValue;
         AV36TFTipFech_To_Description = "";
         AV37TFTipCompra_To_Description = "";
         AV38TFTipVenta_To_Description = "";
         AV73Configuracion_tipocambiowwds_1_dynamicfiltersselector1 = "";
         AV75Configuracion_tipocambiowwds_3_mondsc1 = "";
         AV76Configuracion_tipocambiowwds_4_tipfech1 = DateTime.MinValue;
         AV77Configuracion_tipocambiowwds_5_tipfech_to1 = DateTime.MinValue;
         AV79Configuracion_tipocambiowwds_7_dynamicfiltersselector2 = "";
         AV81Configuracion_tipocambiowwds_9_mondsc2 = "";
         AV82Configuracion_tipocambiowwds_10_tipfech2 = DateTime.MinValue;
         AV83Configuracion_tipocambiowwds_11_tipfech_to2 = DateTime.MinValue;
         AV85Configuracion_tipocambiowwds_13_dynamicfiltersselector3 = "";
         AV87Configuracion_tipocambiowwds_15_mondsc3 = "";
         AV88Configuracion_tipocambiowwds_16_tipfech3 = DateTime.MinValue;
         AV89Configuracion_tipocambiowwds_17_tipfech_to3 = DateTime.MinValue;
         AV90Configuracion_tipocambiowwds_18_tfmondsc = "";
         AV91Configuracion_tipocambiowwds_19_tfmondsc_sel = "";
         AV92Configuracion_tipocambiowwds_20_tftipfech = DateTime.MinValue;
         AV93Configuracion_tipocambiowwds_21_tftipfech_to = DateTime.MinValue;
         scmdbuf = "";
         lV75Configuracion_tipocambiowwds_3_mondsc1 = "";
         lV81Configuracion_tipocambiowwds_9_mondsc2 = "";
         lV87Configuracion_tipocambiowwds_15_mondsc3 = "";
         lV90Configuracion_tipocambiowwds_18_tfmondsc = "";
         A1234MonDsc = "";
         A308TipFech = DateTime.MinValue;
         P00522_A307TipMonCod = new int[1] ;
         P00522_A1920TipVenta = new decimal[1] ;
         P00522_A1907TipCompra = new decimal[1] ;
         P00522_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         P00522_A1234MonDsc = new string[] {""} ;
         P00522_n1234MonDsc = new bool[] {false} ;
         AV26Session = context.GetSession();
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47PageInfo = "";
         AV44DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV42AppName = "";
         AV48Phone = "";
         AV46Mail = "";
         AV50Website = "";
         AV39AddressLine1 = "";
         AV40AddressLine2 = "";
         AV41AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipocambiowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00522_A307TipMonCod, P00522_A1920TipVenta, P00522_A1907TipCompra, P00522_A308TipFech, P00522_A1234MonDsc, P00522_n1234MonDsc
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
      private short AV74Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 ;
      private short AV80Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 ;
      private short AV86Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A307TipMonCod ;
      private int AV98GXV1 ;
      private decimal AV32TFTipCompra ;
      private decimal AV33TFTipCompra_To ;
      private decimal AV34TFTipVenta ;
      private decimal AV35TFTipVenta_To ;
      private decimal AV94Configuracion_tipocambiowwds_22_tftipcompra ;
      private decimal AV95Configuracion_tipocambiowwds_23_tftipcompra_to ;
      private decimal AV96Configuracion_tipocambiowwds_24_tftipventa ;
      private decimal AV97Configuracion_tipocambiowwds_25_tftipventa_to ;
      private decimal A1907TipCompra ;
      private decimal A1920TipVenta ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV53MonDsc1 ;
      private string AV55MonDsc ;
      private string AV62MonDsc2 ;
      private string AV65MonDsc3 ;
      private string AV52TFMonDsc_Sel ;
      private string AV51TFMonDsc ;
      private string AV75Configuracion_tipocambiowwds_3_mondsc1 ;
      private string AV81Configuracion_tipocambiowwds_9_mondsc2 ;
      private string AV87Configuracion_tipocambiowwds_15_mondsc3 ;
      private string AV90Configuracion_tipocambiowwds_18_tfmondsc ;
      private string AV91Configuracion_tipocambiowwds_19_tfmondsc_sel ;
      private string scmdbuf ;
      private string lV75Configuracion_tipocambiowwds_3_mondsc1 ;
      private string lV81Configuracion_tipocambiowwds_9_mondsc2 ;
      private string lV87Configuracion_tipocambiowwds_15_mondsc3 ;
      private string lV90Configuracion_tipocambiowwds_18_tfmondsc ;
      private string A1234MonDsc ;
      private DateTime AV58TipFech1 ;
      private DateTime AV59TipFech_To1 ;
      private DateTime AV61TipFech ;
      private DateTime AV63TipFech2 ;
      private DateTime AV64TipFech_To2 ;
      private DateTime AV66TipFech3 ;
      private DateTime AV67TipFech_To3 ;
      private DateTime AV30TFTipFech ;
      private DateTime AV31TFTipFech_To ;
      private DateTime AV76Configuracion_tipocambiowwds_4_tipfech1 ;
      private DateTime AV77Configuracion_tipocambiowwds_5_tipfech_to1 ;
      private DateTime AV82Configuracion_tipocambiowwds_10_tipfech2 ;
      private DateTime AV83Configuracion_tipocambiowwds_11_tipfech_to2 ;
      private DateTime AV88Configuracion_tipocambiowwds_16_tipfech3 ;
      private DateTime AV89Configuracion_tipocambiowwds_17_tipfech_to3 ;
      private DateTime AV92Configuracion_tipocambiowwds_20_tftipfech ;
      private DateTime AV93Configuracion_tipocambiowwds_21_tftipfech_to ;
      private DateTime A308TipFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV78Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 ;
      private bool AV84Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private bool n1234MonDsc ;
      private string AV49Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV54FilterMonDscDescription ;
      private string AV56FixedValueOperatorDsc ;
      private string AV57FixedValueOperatorValue ;
      private string AV60FilterTipFechDescription ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV36TFTipFech_To_Description ;
      private string AV37TFTipCompra_To_Description ;
      private string AV38TFTipVenta_To_Description ;
      private string AV73Configuracion_tipocambiowwds_1_dynamicfiltersselector1 ;
      private string AV79Configuracion_tipocambiowwds_7_dynamicfiltersselector2 ;
      private string AV85Configuracion_tipocambiowwds_13_dynamicfiltersselector3 ;
      private string AV47PageInfo ;
      private string AV44DateInfo ;
      private string AV42AppName ;
      private string AV48Phone ;
      private string AV46Mail ;
      private string AV50Website ;
      private string AV39AddressLine1 ;
      private string AV40AddressLine2 ;
      private string AV41AddressLine3 ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00522_A307TipMonCod ;
      private decimal[] P00522_A1920TipVenta ;
      private decimal[] P00522_A1907TipCompra ;
      private DateTime[] P00522_A308TipFech ;
      private string[] P00522_A1234MonDsc ;
      private bool[] P00522_n1234MonDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class tipocambiowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00522( IGxContext context ,
                                             string AV73Configuracion_tipocambiowwds_1_dynamicfiltersselector1 ,
                                             short AV74Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 ,
                                             string AV75Configuracion_tipocambiowwds_3_mondsc1 ,
                                             DateTime AV76Configuracion_tipocambiowwds_4_tipfech1 ,
                                             DateTime AV77Configuracion_tipocambiowwds_5_tipfech_to1 ,
                                             bool AV78Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 ,
                                             string AV79Configuracion_tipocambiowwds_7_dynamicfiltersselector2 ,
                                             short AV80Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 ,
                                             string AV81Configuracion_tipocambiowwds_9_mondsc2 ,
                                             DateTime AV82Configuracion_tipocambiowwds_10_tipfech2 ,
                                             DateTime AV83Configuracion_tipocambiowwds_11_tipfech_to2 ,
                                             bool AV84Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 ,
                                             string AV85Configuracion_tipocambiowwds_13_dynamicfiltersselector3 ,
                                             short AV86Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 ,
                                             string AV87Configuracion_tipocambiowwds_15_mondsc3 ,
                                             DateTime AV88Configuracion_tipocambiowwds_16_tipfech3 ,
                                             DateTime AV89Configuracion_tipocambiowwds_17_tipfech_to3 ,
                                             string AV91Configuracion_tipocambiowwds_19_tfmondsc_sel ,
                                             string AV90Configuracion_tipocambiowwds_18_tfmondsc ,
                                             DateTime AV92Configuracion_tipocambiowwds_20_tftipfech ,
                                             DateTime AV93Configuracion_tipocambiowwds_21_tftipfech_to ,
                                             decimal AV94Configuracion_tipocambiowwds_22_tftipcompra ,
                                             decimal AV95Configuracion_tipocambiowwds_23_tftipcompra_to ,
                                             decimal AV96Configuracion_tipocambiowwds_24_tftipventa ,
                                             decimal AV97Configuracion_tipocambiowwds_25_tftipventa_to ,
                                             string A1234MonDsc ,
                                             DateTime A308TipFech ,
                                             decimal A1907TipCompra ,
                                             decimal A1920TipVenta ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[29];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[TipMonCod] AS TipMonCod, T1.[TipVenta], T1.[TipCompra], T1.[TipFech], T2.[MonDsc] FROM ([CTIPOCAMBIO] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[TipMonCod])";
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV74Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_tipocambiowwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV75Configuracion_tipocambiowwds_3_mondsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV74Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_tipocambiowwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV75Configuracion_tipocambiowwds_3_mondsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV74Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV76Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV76Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV74Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV76Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV76Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV74Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV76Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV76Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV74Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV76Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV76Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV74Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV77Configuracion_tipocambiowwds_5_tipfech_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV77Configuracion_tipocambiowwds_5_tipfech_to1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV78Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV80Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_tipocambiowwds_9_mondsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV81Configuracion_tipocambiowwds_9_mondsc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV78Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV80Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_tipocambiowwds_9_mondsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV81Configuracion_tipocambiowwds_9_mondsc2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV78Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV80Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV82Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV82Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV78Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV80Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV82Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV82Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV78Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV80Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV82Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV82Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV78Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV80Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV82Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV82Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV78Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV80Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV83Configuracion_tipocambiowwds_11_tipfech_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV83Configuracion_tipocambiowwds_11_tipfech_to2)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV84Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV86Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_tipocambiowwds_15_mondsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV87Configuracion_tipocambiowwds_15_mondsc3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV84Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV86Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_tipocambiowwds_15_mondsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV87Configuracion_tipocambiowwds_15_mondsc3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV84Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV86Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV88Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV88Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV84Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV86Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV88Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV88Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV84Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV86Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV88Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV88Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV84Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV86Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV88Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV88Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV84Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV86Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV89Configuracion_tipocambiowwds_17_tipfech_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV89Configuracion_tipocambiowwds_17_tipfech_to3)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Configuracion_tipocambiowwds_19_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Configuracion_tipocambiowwds_18_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV90Configuracion_tipocambiowwds_18_tfmondsc)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Configuracion_tipocambiowwds_19_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] = @AV91Configuracion_tipocambiowwds_19_tfmondsc_sel)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Configuracion_tipocambiowwds_20_tftipfech) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV92Configuracion_tipocambiowwds_20_tftipfech)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Configuracion_tipocambiowwds_21_tftipfech_to) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV93Configuracion_tipocambiowwds_21_tftipfech_to)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV94Configuracion_tipocambiowwds_22_tftipcompra) )
         {
            AddWhere(sWhereString, "(T1.[TipCompra] >= @AV94Configuracion_tipocambiowwds_22_tftipcompra)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV95Configuracion_tipocambiowwds_23_tftipcompra_to) )
         {
            AddWhere(sWhereString, "(T1.[TipCompra] <= @AV95Configuracion_tipocambiowwds_23_tftipcompra_to)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV96Configuracion_tipocambiowwds_24_tftipventa) )
         {
            AddWhere(sWhereString, "(T1.[TipVenta] >= @AV96Configuracion_tipocambiowwds_24_tftipventa)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV97Configuracion_tipocambiowwds_25_tftipventa_to) )
         {
            AddWhere(sWhereString, "(T1.[TipVenta] <= @AV97Configuracion_tipocambiowwds_25_tftipventa_to)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipFech]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipFech] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MonDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MonDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipCompra]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipCompra] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipVenta]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipVenta] DESC";
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
                     return conditional_P00522(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP00522;
          prmP00522 = new Object[] {
          new ParDef("@lV75Configuracion_tipocambiowwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_tipocambiowwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@AV76Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV76Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV76Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV76Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV77Configuracion_tipocambiowwds_5_tipfech_to1",GXType.Date,8,0) ,
          new ParDef("@lV81Configuracion_tipocambiowwds_9_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV81Configuracion_tipocambiowwds_9_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@AV82Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV82Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV82Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV82Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV83Configuracion_tipocambiowwds_11_tipfech_to2",GXType.Date,8,0) ,
          new ParDef("@lV87Configuracion_tipocambiowwds_15_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@lV87Configuracion_tipocambiowwds_15_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@AV88Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV88Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV88Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV88Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV89Configuracion_tipocambiowwds_17_tipfech_to3",GXType.Date,8,0) ,
          new ParDef("@lV90Configuracion_tipocambiowwds_18_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV91Configuracion_tipocambiowwds_19_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV92Configuracion_tipocambiowwds_20_tftipfech",GXType.Date,8,0) ,
          new ParDef("@AV93Configuracion_tipocambiowwds_21_tftipfech_to",GXType.Date,8,0) ,
          new ParDef("@AV94Configuracion_tipocambiowwds_22_tftipcompra",GXType.Decimal,15,5) ,
          new ParDef("@AV95Configuracion_tipocambiowwds_23_tftipcompra_to",GXType.Decimal,15,5) ,
          new ParDef("@AV96Configuracion_tipocambiowwds_24_tftipventa",GXType.Decimal,15,5) ,
          new ParDef("@AV97Configuracion_tipocambiowwds_25_tftipventa_to",GXType.Decimal,15,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00522", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00522,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
