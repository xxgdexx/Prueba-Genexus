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
   public class tipoclientewwexportreport : GXWebProcedure
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

      public tipoclientewwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipoclientewwexportreport( IGxContext context )
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
         tipoclientewwexportreport objtipoclientewwexportreport;
         objtipoclientewwexportreport = new tipoclientewwexportreport();
         objtipoclientewwexportreport.context.SetSubmitInitialConfig(context);
         objtipoclientewwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipoclientewwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipoclientewwexportreport)stateInfo).executePrivate();
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
            AV54Title = "Lista de Tipo Cliente";
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
            H450( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "TIPCDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15TipCDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TipCDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterTipCDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Cliente", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterTipCDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Cliente", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17TipCDsc = AV15TipCDsc1;
                  H450( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipCDscDescription, "")), 25, Gx_line+0, 217, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipCDsc, "")), 217, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPCDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21TipCDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TipCDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterTipCDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Cliente", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterTipCDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Cliente", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17TipCDsc = AV21TipCDsc2;
                     H450( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipCDscDescription, "")), 25, Gx_line+0, 217, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipCDsc, "")), 217, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPCDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25TipCDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TipCDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterTipCDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Cliente", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterTipCDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Cliente", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17TipCDsc = AV25TipCDsc3;
                        H450( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipCDscDescription, "")), 25, Gx_line+0, 217, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipCDsc, "")), 217, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFTipCCod) && (0==AV32TFTipCCod_To) ) )
         {
            H450( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 217, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFTipCCod), "ZZZZZ9")), 217, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV41TFTipCCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H450( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFTipCCod_To_Description, "")), 25, Gx_line+0, 217, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFTipCCod_To), "ZZZZZ9")), 217, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTipCDsc_Sel)) )
         {
            H450( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo de Cliente", 25, Gx_line+0, 217, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFTipCDsc_Sel, "")), 217, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTipCDsc)) )
            {
               H450( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo de Cliente", 25, Gx_line+0, 217, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFTipCDsc, "")), 217, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTipCAbr_Sel)) )
         {
            H450( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 217, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFTipCAbr_Sel, "")), 217, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFTipCAbr)) )
            {
               H450( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 217, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFTipCAbr, "")), 217, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV39TFTipCSts_Sels.FromJSonString(AV37TFTipCSts_SelsJson, null);
         if ( ! ( AV39TFTipCSts_Sels.Count == 0 ) )
         {
            AV43i = 1;
            AV60GXV1 = 1;
            while ( AV60GXV1 <= AV39TFTipCSts_Sels.Count )
            {
               AV40TFTipCSts_Sel = (short)(AV39TFTipCSts_Sels.GetNumeric(AV60GXV1));
               if ( AV43i == 1 )
               {
                  AV38TFTipCSts_SelDscs = "";
               }
               else
               {
                  AV38TFTipCSts_SelDscs += ", ";
               }
               if ( AV40TFTipCSts_Sel == 1 )
               {
                  AV42FilterTFTipCSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV40TFTipCSts_Sel == 0 )
               {
                  AV42FilterTFTipCSts_SelValueDescription = "INACTIVO";
               }
               AV38TFTipCSts_SelDscs += AV42FilterTFTipCSts_SelValueDescription;
               AV43i = (long)(AV43i+1);
               AV60GXV1 = (int)(AV60GXV1+1);
            }
            H450( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 217, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFTipCSts_SelDscs, "")), 217, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H450( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H450( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 154, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo de Cliente", 158, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Abreviatura", 410, Gx_line+10, 534, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 538, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV62Configuracion_tipoclientewwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV63Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV64Configuracion_tipoclientewwds_3_tipcdsc1 = AV15TipCDsc1;
         AV65Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV66Configuracion_tipoclientewwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV67Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV68Configuracion_tipoclientewwds_7_tipcdsc2 = AV21TipCDsc2;
         AV69Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV70Configuracion_tipoclientewwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV71Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV72Configuracion_tipoclientewwds_11_tipcdsc3 = AV25TipCDsc3;
         AV73Configuracion_tipoclientewwds_12_tftipccod = AV31TFTipCCod;
         AV74Configuracion_tipoclientewwds_13_tftipccod_to = AV32TFTipCCod_To;
         AV75Configuracion_tipoclientewwds_14_tftipcdsc = AV33TFTipCDsc;
         AV76Configuracion_tipoclientewwds_15_tftipcdsc_sel = AV34TFTipCDsc_Sel;
         AV77Configuracion_tipoclientewwds_16_tftipcabr = AV35TFTipCAbr;
         AV78Configuracion_tipoclientewwds_17_tftipcabr_sel = AV36TFTipCAbr_Sel;
         AV79Configuracion_tipoclientewwds_18_tftipcsts_sels = AV39TFTipCSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1908TipCSts ,
                                              AV79Configuracion_tipoclientewwds_18_tftipcsts_sels ,
                                              AV62Configuracion_tipoclientewwds_1_dynamicfiltersselector1 ,
                                              AV63Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 ,
                                              AV64Configuracion_tipoclientewwds_3_tipcdsc1 ,
                                              AV65Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 ,
                                              AV66Configuracion_tipoclientewwds_5_dynamicfiltersselector2 ,
                                              AV67Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 ,
                                              AV68Configuracion_tipoclientewwds_7_tipcdsc2 ,
                                              AV69Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 ,
                                              AV70Configuracion_tipoclientewwds_9_dynamicfiltersselector3 ,
                                              AV71Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 ,
                                              AV72Configuracion_tipoclientewwds_11_tipcdsc3 ,
                                              AV73Configuracion_tipoclientewwds_12_tftipccod ,
                                              AV74Configuracion_tipoclientewwds_13_tftipccod_to ,
                                              AV76Configuracion_tipoclientewwds_15_tftipcdsc_sel ,
                                              AV75Configuracion_tipoclientewwds_14_tftipcdsc ,
                                              AV78Configuracion_tipoclientewwds_17_tftipcabr_sel ,
                                              AV77Configuracion_tipoclientewwds_16_tftipcabr ,
                                              AV79Configuracion_tipoclientewwds_18_tftipcsts_sels.Count ,
                                              A1905TipCDsc ,
                                              A159TipCCod ,
                                              A1904TipCAbr ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV64Configuracion_tipoclientewwds_3_tipcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_tipoclientewwds_3_tipcdsc1), 100, "%");
         lV64Configuracion_tipoclientewwds_3_tipcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_tipoclientewwds_3_tipcdsc1), 100, "%");
         lV68Configuracion_tipoclientewwds_7_tipcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_tipoclientewwds_7_tipcdsc2), 100, "%");
         lV68Configuracion_tipoclientewwds_7_tipcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_tipoclientewwds_7_tipcdsc2), 100, "%");
         lV72Configuracion_tipoclientewwds_11_tipcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_tipoclientewwds_11_tipcdsc3), 100, "%");
         lV72Configuracion_tipoclientewwds_11_tipcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_tipoclientewwds_11_tipcdsc3), 100, "%");
         lV75Configuracion_tipoclientewwds_14_tftipcdsc = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_tipoclientewwds_14_tftipcdsc), 100, "%");
         lV77Configuracion_tipoclientewwds_16_tftipcabr = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_tipoclientewwds_16_tftipcabr), 5, "%");
         /* Using cursor P00452 */
         pr_default.execute(0, new Object[] {lV64Configuracion_tipoclientewwds_3_tipcdsc1, lV64Configuracion_tipoclientewwds_3_tipcdsc1, lV68Configuracion_tipoclientewwds_7_tipcdsc2, lV68Configuracion_tipoclientewwds_7_tipcdsc2, lV72Configuracion_tipoclientewwds_11_tipcdsc3, lV72Configuracion_tipoclientewwds_11_tipcdsc3, AV73Configuracion_tipoclientewwds_12_tftipccod, AV74Configuracion_tipoclientewwds_13_tftipccod_to, lV75Configuracion_tipoclientewwds_14_tftipcdsc, AV76Configuracion_tipoclientewwds_15_tftipcdsc_sel, lV77Configuracion_tipoclientewwds_16_tftipcabr, AV78Configuracion_tipoclientewwds_17_tftipcabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1908TipCSts = P00452_A1908TipCSts[0];
            A1904TipCAbr = P00452_A1904TipCAbr[0];
            A159TipCCod = P00452_A159TipCCod[0];
            A1905TipCDsc = P00452_A1905TipCDsc[0];
            if ( A1908TipCSts == 1 )
            {
               AV12TipCStsDescription = "ACTIVO";
            }
            else if ( A1908TipCSts == 0 )
            {
               AV12TipCStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H450( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A159TipCCod), "ZZZZZ9")), 30, Gx_line+10, 154, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1905TipCDsc, "")), 158, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1904TipCAbr, "")), 410, Gx_line+10, 534, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12TipCStsDescription, "")), 538, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.TipoClienteWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoClienteWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.TipoClienteWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV80GXV2 = 1;
         while ( AV80GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV80GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPCCOD") == 0 )
            {
               AV31TFTipCCod = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AV32TFTipCCod_To = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPCDSC") == 0 )
            {
               AV33TFTipCDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPCDSC_SEL") == 0 )
            {
               AV34TFTipCDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPCABR") == 0 )
            {
               AV35TFTipCAbr = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPCABR_SEL") == 0 )
            {
               AV36TFTipCAbr_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPCSTS_SEL") == 0 )
            {
               AV37TFTipCSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV39TFTipCSts_Sels.FromJSonString(AV37TFTipCSts_SelsJson, null);
            }
            AV80GXV2 = (int)(AV80GXV2+1);
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

      protected void H450( bool bFoot ,
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
         AV15TipCDsc1 = "";
         AV16FilterTipCDscDescription = "";
         AV17TipCDsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21TipCDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25TipCDsc3 = "";
         AV41TFTipCCod_To_Description = "";
         AV34TFTipCDsc_Sel = "";
         AV33TFTipCDsc = "";
         AV36TFTipCAbr_Sel = "";
         AV35TFTipCAbr = "";
         AV39TFTipCSts_Sels = new GxSimpleCollection<short>();
         AV37TFTipCSts_SelsJson = "";
         AV38TFTipCSts_SelDscs = "";
         AV42FilterTFTipCSts_SelValueDescription = "";
         AV62Configuracion_tipoclientewwds_1_dynamicfiltersselector1 = "";
         AV64Configuracion_tipoclientewwds_3_tipcdsc1 = "";
         AV66Configuracion_tipoclientewwds_5_dynamicfiltersselector2 = "";
         AV68Configuracion_tipoclientewwds_7_tipcdsc2 = "";
         AV70Configuracion_tipoclientewwds_9_dynamicfiltersselector3 = "";
         AV72Configuracion_tipoclientewwds_11_tipcdsc3 = "";
         AV75Configuracion_tipoclientewwds_14_tftipcdsc = "";
         AV76Configuracion_tipoclientewwds_15_tftipcdsc_sel = "";
         AV77Configuracion_tipoclientewwds_16_tftipcabr = "";
         AV78Configuracion_tipoclientewwds_17_tftipcabr_sel = "";
         AV79Configuracion_tipoclientewwds_18_tftipcsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV64Configuracion_tipoclientewwds_3_tipcdsc1 = "";
         lV68Configuracion_tipoclientewwds_7_tipcdsc2 = "";
         lV72Configuracion_tipoclientewwds_11_tipcdsc3 = "";
         lV75Configuracion_tipoclientewwds_14_tftipcdsc = "";
         lV77Configuracion_tipoclientewwds_16_tftipcabr = "";
         A1905TipCDsc = "";
         A1904TipCAbr = "";
         P00452_A1908TipCSts = new short[1] ;
         P00452_A1904TipCAbr = new string[] {""} ;
         P00452_A159TipCCod = new int[1] ;
         P00452_A1905TipCDsc = new string[] {""} ;
         AV12TipCStsDescription = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipoclientewwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00452_A1908TipCSts, P00452_A1904TipCAbr, P00452_A159TipCCod, P00452_A1905TipCDsc
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
      private short AV40TFTipCSts_Sel ;
      private short AV63Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 ;
      private short AV67Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 ;
      private short AV71Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 ;
      private short A1908TipCSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV31TFTipCCod ;
      private int AV32TFTipCCod_To ;
      private int AV60GXV1 ;
      private int AV73Configuracion_tipoclientewwds_12_tftipccod ;
      private int AV74Configuracion_tipoclientewwds_13_tftipccod_to ;
      private int AV79Configuracion_tipoclientewwds_18_tftipcsts_sels_Count ;
      private int A159TipCCod ;
      private int AV80GXV2 ;
      private long AV43i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15TipCDsc1 ;
      private string AV17TipCDsc ;
      private string AV21TipCDsc2 ;
      private string AV25TipCDsc3 ;
      private string AV34TFTipCDsc_Sel ;
      private string AV33TFTipCDsc ;
      private string AV36TFTipCAbr_Sel ;
      private string AV35TFTipCAbr ;
      private string AV64Configuracion_tipoclientewwds_3_tipcdsc1 ;
      private string AV68Configuracion_tipoclientewwds_7_tipcdsc2 ;
      private string AV72Configuracion_tipoclientewwds_11_tipcdsc3 ;
      private string AV75Configuracion_tipoclientewwds_14_tftipcdsc ;
      private string AV76Configuracion_tipoclientewwds_15_tftipcdsc_sel ;
      private string AV77Configuracion_tipoclientewwds_16_tftipcabr ;
      private string AV78Configuracion_tipoclientewwds_17_tftipcabr_sel ;
      private string scmdbuf ;
      private string lV64Configuracion_tipoclientewwds_3_tipcdsc1 ;
      private string lV68Configuracion_tipoclientewwds_7_tipcdsc2 ;
      private string lV72Configuracion_tipoclientewwds_11_tipcdsc3 ;
      private string lV75Configuracion_tipoclientewwds_14_tftipcdsc ;
      private string lV77Configuracion_tipoclientewwds_16_tftipcabr ;
      private string A1905TipCDsc ;
      private string A1904TipCAbr ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV65Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 ;
      private bool AV69Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV37TFTipCSts_SelsJson ;
      private string AV54Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterTipCDscDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV41TFTipCCod_To_Description ;
      private string AV38TFTipCSts_SelDscs ;
      private string AV42FilterTFTipCSts_SelValueDescription ;
      private string AV62Configuracion_tipoclientewwds_1_dynamicfiltersselector1 ;
      private string AV66Configuracion_tipoclientewwds_5_dynamicfiltersselector2 ;
      private string AV70Configuracion_tipoclientewwds_9_dynamicfiltersselector3 ;
      private string AV12TipCStsDescription ;
      private string AV52PageInfo ;
      private string AV49DateInfo ;
      private string AV47AppName ;
      private string AV53Phone ;
      private string AV51Mail ;
      private string AV55Website ;
      private string AV44AddressLine1 ;
      private string AV45AddressLine2 ;
      private string AV46AddressLine3 ;
      private GxSimpleCollection<short> AV39TFTipCSts_Sels ;
      private GxSimpleCollection<short> AV79Configuracion_tipoclientewwds_18_tftipcsts_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00452_A1908TipCSts ;
      private string[] P00452_A1904TipCAbr ;
      private int[] P00452_A159TipCCod ;
      private string[] P00452_A1905TipCDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class tipoclientewwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00452( IGxContext context ,
                                             short A1908TipCSts ,
                                             GxSimpleCollection<short> AV79Configuracion_tipoclientewwds_18_tftipcsts_sels ,
                                             string AV62Configuracion_tipoclientewwds_1_dynamicfiltersselector1 ,
                                             short AV63Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 ,
                                             string AV64Configuracion_tipoclientewwds_3_tipcdsc1 ,
                                             bool AV65Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 ,
                                             string AV66Configuracion_tipoclientewwds_5_dynamicfiltersselector2 ,
                                             short AV67Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 ,
                                             string AV68Configuracion_tipoclientewwds_7_tipcdsc2 ,
                                             bool AV69Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 ,
                                             string AV70Configuracion_tipoclientewwds_9_dynamicfiltersselector3 ,
                                             short AV71Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 ,
                                             string AV72Configuracion_tipoclientewwds_11_tipcdsc3 ,
                                             int AV73Configuracion_tipoclientewwds_12_tftipccod ,
                                             int AV74Configuracion_tipoclientewwds_13_tftipccod_to ,
                                             string AV76Configuracion_tipoclientewwds_15_tftipcdsc_sel ,
                                             string AV75Configuracion_tipoclientewwds_14_tftipcdsc ,
                                             string AV78Configuracion_tipoclientewwds_17_tftipcabr_sel ,
                                             string AV77Configuracion_tipoclientewwds_16_tftipcabr ,
                                             int AV79Configuracion_tipoclientewwds_18_tftipcsts_sels_Count ,
                                             string A1905TipCDsc ,
                                             int A159TipCCod ,
                                             string A1904TipCAbr ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TipCSts], [TipCAbr], [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE]";
         if ( ( StringUtil.StrCmp(AV62Configuracion_tipoclientewwds_1_dynamicfiltersselector1, "TIPCDSC") == 0 ) && ( AV63Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipoclientewwds_3_tipcdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV64Configuracion_tipoclientewwds_3_tipcdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Configuracion_tipoclientewwds_1_dynamicfiltersselector1, "TIPCDSC") == 0 ) && ( AV63Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipoclientewwds_3_tipcdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like '%' + @lV64Configuracion_tipoclientewwds_3_tipcdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV65Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Configuracion_tipoclientewwds_5_dynamicfiltersselector2, "TIPCDSC") == 0 ) && ( AV67Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_tipoclientewwds_7_tipcdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV68Configuracion_tipoclientewwds_7_tipcdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV65Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Configuracion_tipoclientewwds_5_dynamicfiltersselector2, "TIPCDSC") == 0 ) && ( AV67Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_tipoclientewwds_7_tipcdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like '%' + @lV68Configuracion_tipoclientewwds_7_tipcdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV69Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Configuracion_tipoclientewwds_9_dynamicfiltersselector3, "TIPCDSC") == 0 ) && ( AV71Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_tipoclientewwds_11_tipcdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV72Configuracion_tipoclientewwds_11_tipcdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV69Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Configuracion_tipoclientewwds_9_dynamicfiltersselector3, "TIPCDSC") == 0 ) && ( AV71Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_tipoclientewwds_11_tipcdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like '%' + @lV72Configuracion_tipoclientewwds_11_tipcdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV73Configuracion_tipoclientewwds_12_tftipccod) )
         {
            AddWhere(sWhereString, "([TipCCod] >= @AV73Configuracion_tipoclientewwds_12_tftipccod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV74Configuracion_tipoclientewwds_13_tftipccod_to) )
         {
            AddWhere(sWhereString, "([TipCCod] <= @AV74Configuracion_tipoclientewwds_13_tftipccod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_tipoclientewwds_15_tftipcdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_tipoclientewwds_14_tftipcdsc)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV75Configuracion_tipoclientewwds_14_tftipcdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_tipoclientewwds_15_tftipcdsc_sel)) )
         {
            AddWhere(sWhereString, "([TipCDsc] = @AV76Configuracion_tipoclientewwds_15_tftipcdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_tipoclientewwds_17_tftipcabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_tipoclientewwds_16_tftipcabr)) ) )
         {
            AddWhere(sWhereString, "([TipCAbr] like @lV77Configuracion_tipoclientewwds_16_tftipcabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_tipoclientewwds_17_tftipcabr_sel)) )
         {
            AddWhere(sWhereString, "([TipCAbr] = @AV78Configuracion_tipoclientewwds_17_tftipcabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV79Configuracion_tipoclientewwds_18_tftipcsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Configuracion_tipoclientewwds_18_tftipcsts_sels, "[TipCSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipCCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipCCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipCDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipCDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipCAbr]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipCAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipCSts]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipCSts] DESC";
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
                     return conditional_P00452(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP00452;
          prmP00452 = new Object[] {
          new ParDef("@lV64Configuracion_tipoclientewwds_3_tipcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV64Configuracion_tipoclientewwds_3_tipcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_tipoclientewwds_7_tipcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_tipoclientewwds_7_tipcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_tipoclientewwds_11_tipcdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_tipoclientewwds_11_tipcdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_tipoclientewwds_12_tftipccod",GXType.Int32,6,0) ,
          new ParDef("@AV74Configuracion_tipoclientewwds_13_tftipccod_to",GXType.Int32,6,0) ,
          new ParDef("@lV75Configuracion_tipoclientewwds_14_tftipcdsc",GXType.NChar,100,0) ,
          new ParDef("@AV76Configuracion_tipoclientewwds_15_tftipcdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV77Configuracion_tipoclientewwds_16_tftipcabr",GXType.NChar,5,0) ,
          new ParDef("@AV78Configuracion_tipoclientewwds_17_tftipcabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00452", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00452,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
