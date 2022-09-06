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
   public class zonaswwexportreport : GXWebProcedure
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

      public zonaswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public zonaswwexportreport( IGxContext context )
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
         zonaswwexportreport objzonaswwexportreport;
         objzonaswwexportreport = new zonaswwexportreport();
         objzonaswwexportreport.context.SetSubmitInitialConfig(context);
         objzonaswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objzonaswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((zonaswwexportreport)stateInfo).executePrivate();
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
            AV52Title = "Lista de Zonas";
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
            H420( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "ZONDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15ZonDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ZonDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterZonDscDescription = StringUtil.Format( "%1 (%2)", "Zona", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterZonDscDescription = StringUtil.Format( "%1 (%2)", "Zona", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17ZonDsc = AV15ZonDsc1;
                  H420( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterZonDscDescription, "")), 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ZonDsc, "")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "ZONDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21ZonDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ZonDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterZonDscDescription = StringUtil.Format( "%1 (%2)", "Zona", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterZonDscDescription = StringUtil.Format( "%1 (%2)", "Zona", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17ZonDsc = AV21ZonDsc2;
                     H420( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterZonDscDescription, "")), 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ZonDsc, "")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "ZONDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25ZonDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ZonDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterZonDscDescription = StringUtil.Format( "%1 (%2)", "Zona", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterZonDscDescription = StringUtil.Format( "%1 (%2)", "Zona", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17ZonDsc = AV25ZonDsc3;
                        H420( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterZonDscDescription, "")), 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ZonDsc, "")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFZonCod) && (0==AV32TFZonCod_To) ) )
         {
            H420( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFZonCod), "ZZZZZ9")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV39TFZonCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H420( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFZonCod_To_Description, "")), 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFZonCod_To), "ZZZZZ9")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFZonDsc_Sel)) )
         {
            H420( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Zona", 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFZonDsc_Sel, "")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFZonDsc)) )
            {
               H420( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Zona", 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFZonDsc, "")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV37TFZonSts_Sels.FromJSonString(AV35TFZonSts_SelsJson, null);
         if ( ! ( AV37TFZonSts_Sels.Count == 0 ) )
         {
            AV41i = 1;
            AV58GXV1 = 1;
            while ( AV58GXV1 <= AV37TFZonSts_Sels.Count )
            {
               AV38TFZonSts_Sel = (short)(AV37TFZonSts_Sels.GetNumeric(AV58GXV1));
               if ( AV41i == 1 )
               {
                  AV36TFZonSts_SelDscs = "";
               }
               else
               {
                  AV36TFZonSts_SelDscs += ", ";
               }
               if ( AV38TFZonSts_Sel == 1 )
               {
                  AV40FilterTFZonSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV38TFZonSts_Sel == 0 )
               {
                  AV40FilterTFZonSts_SelValueDescription = "INACTIVO";
               }
               AV36TFZonSts_SelDscs += AV40FilterTFZonSts_SelValueDescription;
               AV41i = (long)(AV41i+1);
               AV58GXV1 = (int)(AV58GXV1+1);
            }
            H420( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 170, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFZonSts_SelDscs, "")), 170, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H420( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H420( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 179, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Zona", 183, Gx_line+10, 483, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 487, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV60Configuracion_zonaswwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV61Configuracion_zonaswwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV62Configuracion_zonaswwds_3_zondsc1 = AV15ZonDsc1;
         AV63Configuracion_zonaswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV64Configuracion_zonaswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV65Configuracion_zonaswwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV66Configuracion_zonaswwds_7_zondsc2 = AV21ZonDsc2;
         AV67Configuracion_zonaswwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV68Configuracion_zonaswwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV69Configuracion_zonaswwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV70Configuracion_zonaswwds_11_zondsc3 = AV25ZonDsc3;
         AV71Configuracion_zonaswwds_12_tfzoncod = AV31TFZonCod;
         AV72Configuracion_zonaswwds_13_tfzoncod_to = AV32TFZonCod_To;
         AV73Configuracion_zonaswwds_14_tfzondsc = AV33TFZonDsc;
         AV74Configuracion_zonaswwds_15_tfzondsc_sel = AV34TFZonDsc_Sel;
         AV75Configuracion_zonaswwds_16_tfzonsts_sels = AV37TFZonSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A2095ZonSts ,
                                              AV75Configuracion_zonaswwds_16_tfzonsts_sels ,
                                              AV60Configuracion_zonaswwds_1_dynamicfiltersselector1 ,
                                              AV61Configuracion_zonaswwds_2_dynamicfiltersoperator1 ,
                                              AV62Configuracion_zonaswwds_3_zondsc1 ,
                                              AV63Configuracion_zonaswwds_4_dynamicfiltersenabled2 ,
                                              AV64Configuracion_zonaswwds_5_dynamicfiltersselector2 ,
                                              AV65Configuracion_zonaswwds_6_dynamicfiltersoperator2 ,
                                              AV66Configuracion_zonaswwds_7_zondsc2 ,
                                              AV67Configuracion_zonaswwds_8_dynamicfiltersenabled3 ,
                                              AV68Configuracion_zonaswwds_9_dynamicfiltersselector3 ,
                                              AV69Configuracion_zonaswwds_10_dynamicfiltersoperator3 ,
                                              AV70Configuracion_zonaswwds_11_zondsc3 ,
                                              AV71Configuracion_zonaswwds_12_tfzoncod ,
                                              AV72Configuracion_zonaswwds_13_tfzoncod_to ,
                                              AV74Configuracion_zonaswwds_15_tfzondsc_sel ,
                                              AV73Configuracion_zonaswwds_14_tfzondsc ,
                                              AV75Configuracion_zonaswwds_16_tfzonsts_sels.Count ,
                                              A2094ZonDsc ,
                                              A158ZonCod ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV62Configuracion_zonaswwds_3_zondsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_zonaswwds_3_zondsc1), 100, "%");
         lV62Configuracion_zonaswwds_3_zondsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_zonaswwds_3_zondsc1), 100, "%");
         lV66Configuracion_zonaswwds_7_zondsc2 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_zonaswwds_7_zondsc2), 100, "%");
         lV66Configuracion_zonaswwds_7_zondsc2 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_zonaswwds_7_zondsc2), 100, "%");
         lV70Configuracion_zonaswwds_11_zondsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_zonaswwds_11_zondsc3), 100, "%");
         lV70Configuracion_zonaswwds_11_zondsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_zonaswwds_11_zondsc3), 100, "%");
         lV73Configuracion_zonaswwds_14_tfzondsc = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_zonaswwds_14_tfzondsc), 100, "%");
         /* Using cursor P00422 */
         pr_default.execute(0, new Object[] {lV62Configuracion_zonaswwds_3_zondsc1, lV62Configuracion_zonaswwds_3_zondsc1, lV66Configuracion_zonaswwds_7_zondsc2, lV66Configuracion_zonaswwds_7_zondsc2, lV70Configuracion_zonaswwds_11_zondsc3, lV70Configuracion_zonaswwds_11_zondsc3, AV71Configuracion_zonaswwds_12_tfzoncod, AV72Configuracion_zonaswwds_13_tfzoncod_to, lV73Configuracion_zonaswwds_14_tfzondsc, AV74Configuracion_zonaswwds_15_tfzondsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2095ZonSts = P00422_A2095ZonSts[0];
            A158ZonCod = P00422_A158ZonCod[0];
            A2094ZonDsc = P00422_A2094ZonDsc[0];
            if ( A2095ZonSts == 1 )
            {
               AV12ZonStsDescription = "ACTIVO";
            }
            else if ( A2095ZonSts == 0 )
            {
               AV12ZonStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H420( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A158ZonCod), "ZZZZZ9")), 30, Gx_line+10, 179, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2094ZonDsc, "")), 183, Gx_line+10, 483, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12ZonStsDescription, "")), 487, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.ZonasWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.ZonasWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.ZonasWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV76GXV2 = 1;
         while ( AV76GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV76GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFZONCOD") == 0 )
            {
               AV31TFZonCod = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AV32TFZonCod_To = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFZONDSC") == 0 )
            {
               AV33TFZonDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFZONDSC_SEL") == 0 )
            {
               AV34TFZonDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFZONSTS_SEL") == 0 )
            {
               AV35TFZonSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV37TFZonSts_Sels.FromJSonString(AV35TFZonSts_SelsJson, null);
            }
            AV76GXV2 = (int)(AV76GXV2+1);
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

      protected void H420( bool bFoot ,
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
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15ZonDsc1 = "";
         AV16FilterZonDscDescription = "";
         AV17ZonDsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21ZonDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25ZonDsc3 = "";
         AV39TFZonCod_To_Description = "";
         AV34TFZonDsc_Sel = "";
         AV33TFZonDsc = "";
         AV37TFZonSts_Sels = new GxSimpleCollection<short>();
         AV35TFZonSts_SelsJson = "";
         AV36TFZonSts_SelDscs = "";
         AV40FilterTFZonSts_SelValueDescription = "";
         AV60Configuracion_zonaswwds_1_dynamicfiltersselector1 = "";
         AV62Configuracion_zonaswwds_3_zondsc1 = "";
         AV64Configuracion_zonaswwds_5_dynamicfiltersselector2 = "";
         AV66Configuracion_zonaswwds_7_zondsc2 = "";
         AV68Configuracion_zonaswwds_9_dynamicfiltersselector3 = "";
         AV70Configuracion_zonaswwds_11_zondsc3 = "";
         AV73Configuracion_zonaswwds_14_tfzondsc = "";
         AV74Configuracion_zonaswwds_15_tfzondsc_sel = "";
         AV75Configuracion_zonaswwds_16_tfzonsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV62Configuracion_zonaswwds_3_zondsc1 = "";
         lV66Configuracion_zonaswwds_7_zondsc2 = "";
         lV70Configuracion_zonaswwds_11_zondsc3 = "";
         lV73Configuracion_zonaswwds_14_tfzondsc = "";
         A2094ZonDsc = "";
         P00422_A2095ZonSts = new short[1] ;
         P00422_A158ZonCod = new int[1] ;
         P00422_A2094ZonDsc = new string[] {""} ;
         AV12ZonStsDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.zonaswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00422_A2095ZonSts, P00422_A158ZonCod, P00422_A2094ZonDsc
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
      private short AV38TFZonSts_Sel ;
      private short AV61Configuracion_zonaswwds_2_dynamicfiltersoperator1 ;
      private short AV65Configuracion_zonaswwds_6_dynamicfiltersoperator2 ;
      private short AV69Configuracion_zonaswwds_10_dynamicfiltersoperator3 ;
      private short A2095ZonSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV31TFZonCod ;
      private int AV32TFZonCod_To ;
      private int AV58GXV1 ;
      private int AV71Configuracion_zonaswwds_12_tfzoncod ;
      private int AV72Configuracion_zonaswwds_13_tfzoncod_to ;
      private int AV75Configuracion_zonaswwds_16_tfzonsts_sels_Count ;
      private int A158ZonCod ;
      private int AV76GXV2 ;
      private long AV41i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15ZonDsc1 ;
      private string AV17ZonDsc ;
      private string AV21ZonDsc2 ;
      private string AV25ZonDsc3 ;
      private string AV34TFZonDsc_Sel ;
      private string AV33TFZonDsc ;
      private string AV62Configuracion_zonaswwds_3_zondsc1 ;
      private string AV66Configuracion_zonaswwds_7_zondsc2 ;
      private string AV70Configuracion_zonaswwds_11_zondsc3 ;
      private string AV73Configuracion_zonaswwds_14_tfzondsc ;
      private string AV74Configuracion_zonaswwds_15_tfzondsc_sel ;
      private string scmdbuf ;
      private string lV62Configuracion_zonaswwds_3_zondsc1 ;
      private string lV66Configuracion_zonaswwds_7_zondsc2 ;
      private string lV70Configuracion_zonaswwds_11_zondsc3 ;
      private string lV73Configuracion_zonaswwds_14_tfzondsc ;
      private string A2094ZonDsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV63Configuracion_zonaswwds_4_dynamicfiltersenabled2 ;
      private bool AV67Configuracion_zonaswwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV35TFZonSts_SelsJson ;
      private string AV52Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterZonDscDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV39TFZonCod_To_Description ;
      private string AV36TFZonSts_SelDscs ;
      private string AV40FilterTFZonSts_SelValueDescription ;
      private string AV60Configuracion_zonaswwds_1_dynamicfiltersselector1 ;
      private string AV64Configuracion_zonaswwds_5_dynamicfiltersselector2 ;
      private string AV68Configuracion_zonaswwds_9_dynamicfiltersselector3 ;
      private string AV12ZonStsDescription ;
      private string AV50PageInfo ;
      private string AV47DateInfo ;
      private string AV45AppName ;
      private string AV51Phone ;
      private string AV49Mail ;
      private string AV53Website ;
      private string AV42AddressLine1 ;
      private string AV43AddressLine2 ;
      private string AV44AddressLine3 ;
      private GxSimpleCollection<short> AV37TFZonSts_Sels ;
      private GxSimpleCollection<short> AV75Configuracion_zonaswwds_16_tfzonsts_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00422_A2095ZonSts ;
      private int[] P00422_A158ZonCod ;
      private string[] P00422_A2094ZonDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class zonaswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00422( IGxContext context ,
                                             short A2095ZonSts ,
                                             GxSimpleCollection<short> AV75Configuracion_zonaswwds_16_tfzonsts_sels ,
                                             string AV60Configuracion_zonaswwds_1_dynamicfiltersselector1 ,
                                             short AV61Configuracion_zonaswwds_2_dynamicfiltersoperator1 ,
                                             string AV62Configuracion_zonaswwds_3_zondsc1 ,
                                             bool AV63Configuracion_zonaswwds_4_dynamicfiltersenabled2 ,
                                             string AV64Configuracion_zonaswwds_5_dynamicfiltersselector2 ,
                                             short AV65Configuracion_zonaswwds_6_dynamicfiltersoperator2 ,
                                             string AV66Configuracion_zonaswwds_7_zondsc2 ,
                                             bool AV67Configuracion_zonaswwds_8_dynamicfiltersenabled3 ,
                                             string AV68Configuracion_zonaswwds_9_dynamicfiltersselector3 ,
                                             short AV69Configuracion_zonaswwds_10_dynamicfiltersoperator3 ,
                                             string AV70Configuracion_zonaswwds_11_zondsc3 ,
                                             int AV71Configuracion_zonaswwds_12_tfzoncod ,
                                             int AV72Configuracion_zonaswwds_13_tfzoncod_to ,
                                             string AV74Configuracion_zonaswwds_15_tfzondsc_sel ,
                                             string AV73Configuracion_zonaswwds_14_tfzondsc ,
                                             int AV75Configuracion_zonaswwds_16_tfzonsts_sels_Count ,
                                             string A2094ZonDsc ,
                                             int A158ZonCod ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ZonSts], [ZonCod], [ZonDsc] FROM [CZONAS]";
         if ( ( StringUtil.StrCmp(AV60Configuracion_zonaswwds_1_dynamicfiltersselector1, "ZONDSC") == 0 ) && ( AV61Configuracion_zonaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_zonaswwds_3_zondsc1)) ) )
         {
            AddWhere(sWhereString, "([ZonDsc] like @lV62Configuracion_zonaswwds_3_zondsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Configuracion_zonaswwds_1_dynamicfiltersselector1, "ZONDSC") == 0 ) && ( AV61Configuracion_zonaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_zonaswwds_3_zondsc1)) ) )
         {
            AddWhere(sWhereString, "([ZonDsc] like '%' + @lV62Configuracion_zonaswwds_3_zondsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV63Configuracion_zonaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Configuracion_zonaswwds_5_dynamicfiltersselector2, "ZONDSC") == 0 ) && ( AV65Configuracion_zonaswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_zonaswwds_7_zondsc2)) ) )
         {
            AddWhere(sWhereString, "([ZonDsc] like @lV66Configuracion_zonaswwds_7_zondsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV63Configuracion_zonaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Configuracion_zonaswwds_5_dynamicfiltersselector2, "ZONDSC") == 0 ) && ( AV65Configuracion_zonaswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_zonaswwds_7_zondsc2)) ) )
         {
            AddWhere(sWhereString, "([ZonDsc] like '%' + @lV66Configuracion_zonaswwds_7_zondsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV67Configuracion_zonaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configuracion_zonaswwds_9_dynamicfiltersselector3, "ZONDSC") == 0 ) && ( AV69Configuracion_zonaswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_zonaswwds_11_zondsc3)) ) )
         {
            AddWhere(sWhereString, "([ZonDsc] like @lV70Configuracion_zonaswwds_11_zondsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV67Configuracion_zonaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configuracion_zonaswwds_9_dynamicfiltersselector3, "ZONDSC") == 0 ) && ( AV69Configuracion_zonaswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_zonaswwds_11_zondsc3)) ) )
         {
            AddWhere(sWhereString, "([ZonDsc] like '%' + @lV70Configuracion_zonaswwds_11_zondsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV71Configuracion_zonaswwds_12_tfzoncod) )
         {
            AddWhere(sWhereString, "([ZonCod] >= @AV71Configuracion_zonaswwds_12_tfzoncod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV72Configuracion_zonaswwds_13_tfzoncod_to) )
         {
            AddWhere(sWhereString, "([ZonCod] <= @AV72Configuracion_zonaswwds_13_tfzoncod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_zonaswwds_15_tfzondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_zonaswwds_14_tfzondsc)) ) )
         {
            AddWhere(sWhereString, "([ZonDsc] like @lV73Configuracion_zonaswwds_14_tfzondsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_zonaswwds_15_tfzondsc_sel)) )
         {
            AddWhere(sWhereString, "([ZonDsc] = @AV74Configuracion_zonaswwds_15_tfzondsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV75Configuracion_zonaswwds_16_tfzonsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Configuracion_zonaswwds_16_tfzonsts_sels, "[ZonSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ZonCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ZonCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ZonDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ZonDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [ZonSts]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ZonSts] DESC";
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
                     return conditional_P00422(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP00422;
          prmP00422 = new Object[] {
          new ParDef("@lV62Configuracion_zonaswwds_3_zondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_zonaswwds_3_zondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_zonaswwds_7_zondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_zonaswwds_7_zondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_zonaswwds_11_zondsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_zonaswwds_11_zondsc3",GXType.NChar,100,0) ,
          new ParDef("@AV71Configuracion_zonaswwds_12_tfzoncod",GXType.Int32,6,0) ,
          new ParDef("@AV72Configuracion_zonaswwds_13_tfzoncod_to",GXType.Int32,6,0) ,
          new ParDef("@lV73Configuracion_zonaswwds_14_tfzondsc",GXType.NChar,100,0) ,
          new ParDef("@AV74Configuracion_zonaswwds_15_tfzondsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00422", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00422,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
