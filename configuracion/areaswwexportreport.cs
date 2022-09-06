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
   public class areaswwexportreport : GXWebProcedure
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

      public areaswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public areaswwexportreport( IGxContext context )
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
         areaswwexportreport objareaswwexportreport;
         objareaswwexportreport = new areaswwexportreport();
         objareaswwexportreport.context.SetSubmitInitialConfig(context);
         objareaswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objareaswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((areaswwexportreport)stateInfo).executePrivate();
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
            AV48Title = "Lista de Areas";
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
            H4W0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "AREDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV14AreDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14AreDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterAreDscDescription = StringUtil.Format( "%1 (%2)", "Area de la Empresa", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterAreDscDescription = StringUtil.Format( "%1 (%2)", "Area de la Empresa", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16AreDsc = AV14AreDsc1;
                  H4W0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterAreDscDescription, "")), 25, Gx_line+0, 239, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16AreDsc, "")), 239, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "AREDSC") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV20AreDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20AreDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterAreDscDescription = StringUtil.Format( "%1 (%2)", "Area de la Empresa", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterAreDscDescription = StringUtil.Format( "%1 (%2)", "Area de la Empresa", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16AreDsc = AV20AreDsc2;
                     H4W0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterAreDscDescription, "")), 25, Gx_line+0, 239, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16AreDsc, "")), 239, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "AREDSC") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV24AreDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24AreDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterAreDscDescription = StringUtil.Format( "%1 (%2)", "Area de la Empresa", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterAreDscDescription = StringUtil.Format( "%1 (%2)", "Area de la Empresa", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16AreDsc = AV24AreDsc3;
                        H4W0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterAreDscDescription, "")), 25, Gx_line+0, 239, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16AreDsc, "")), 239, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV30TFAreCod) && (0==AV31TFAreCod_To) ) )
         {
            H4W0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 239, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30TFAreCod), "ZZZZZ9")), 239, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV36TFAreCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H4W0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFAreCod_To_Description, "")), 25, Gx_line+0, 239, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFAreCod_To), "ZZZZZ9")), 239, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFAreDsc_Sel)) )
         {
            H4W0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Area de la Empresa", 25, Gx_line+0, 239, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFAreDsc_Sel, "")), 239, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFAreDsc)) )
            {
               H4W0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Area de la Empresa", 25, Gx_line+0, 239, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFAreDsc, "")), 239, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV53TFAreSts_Sels.FromJSonString(AV51TFAreSts_SelsJson, null);
         if ( ! ( AV53TFAreSts_Sels.Count == 0 ) )
         {
            AV56i = 1;
            AV61GXV1 = 1;
            while ( AV61GXV1 <= AV53TFAreSts_Sels.Count )
            {
               AV54TFAreSts_Sel = (short)(AV53TFAreSts_Sels.GetNumeric(AV61GXV1));
               if ( AV56i == 1 )
               {
                  AV52TFAreSts_SelDscs = "";
               }
               else
               {
                  AV52TFAreSts_SelDscs += ", ";
               }
               if ( AV54TFAreSts_Sel == 1 )
               {
                  AV55FilterTFAreSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV54TFAreSts_Sel == 0 )
               {
                  AV55FilterTFAreSts_SelValueDescription = "INACTIVO";
               }
               AV52TFAreSts_SelDscs += AV55FilterTFAreSts_SelValueDescription;
               AV56i = (long)(AV56i+1);
               AV61GXV1 = (int)(AV61GXV1+1);
            }
            H4W0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 239, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFAreSts_SelDscs, "")), 239, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4W0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4W0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 179, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Area de la Empresa", 183, Gx_line+10, 483, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 487, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV63Configuracion_areaswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV64Configuracion_areaswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV65Configuracion_areaswwds_3_aredsc1 = AV14AreDsc1;
         AV66Configuracion_areaswwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV67Configuracion_areaswwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV68Configuracion_areaswwds_6_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV69Configuracion_areaswwds_7_aredsc2 = AV20AreDsc2;
         AV70Configuracion_areaswwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV71Configuracion_areaswwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV72Configuracion_areaswwds_10_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV73Configuracion_areaswwds_11_aredsc3 = AV24AreDsc3;
         AV74Configuracion_areaswwds_12_tfarecod = AV30TFAreCod;
         AV75Configuracion_areaswwds_13_tfarecod_to = AV31TFAreCod_To;
         AV76Configuracion_areaswwds_14_tfaredsc = AV32TFAreDsc;
         AV77Configuracion_areaswwds_15_tfaredsc_sel = AV33TFAreDsc_Sel;
         AV78Configuracion_areaswwds_16_tfarests_sels = AV53TFAreSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A475AreSts ,
                                              AV78Configuracion_areaswwds_16_tfarests_sels ,
                                              AV63Configuracion_areaswwds_1_dynamicfiltersselector1 ,
                                              AV64Configuracion_areaswwds_2_dynamicfiltersoperator1 ,
                                              AV65Configuracion_areaswwds_3_aredsc1 ,
                                              AV66Configuracion_areaswwds_4_dynamicfiltersenabled2 ,
                                              AV67Configuracion_areaswwds_5_dynamicfiltersselector2 ,
                                              AV68Configuracion_areaswwds_6_dynamicfiltersoperator2 ,
                                              AV69Configuracion_areaswwds_7_aredsc2 ,
                                              AV70Configuracion_areaswwds_8_dynamicfiltersenabled3 ,
                                              AV71Configuracion_areaswwds_9_dynamicfiltersselector3 ,
                                              AV72Configuracion_areaswwds_10_dynamicfiltersoperator3 ,
                                              AV73Configuracion_areaswwds_11_aredsc3 ,
                                              AV74Configuracion_areaswwds_12_tfarecod ,
                                              AV75Configuracion_areaswwds_13_tfarecod_to ,
                                              AV77Configuracion_areaswwds_15_tfaredsc_sel ,
                                              AV76Configuracion_areaswwds_14_tfaredsc ,
                                              AV78Configuracion_areaswwds_16_tfarests_sels.Count ,
                                              A474AreDsc ,
                                              A69AreCod ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV65Configuracion_areaswwds_3_aredsc1 = StringUtil.Concat( StringUtil.RTrim( AV65Configuracion_areaswwds_3_aredsc1), "%", "");
         lV65Configuracion_areaswwds_3_aredsc1 = StringUtil.Concat( StringUtil.RTrim( AV65Configuracion_areaswwds_3_aredsc1), "%", "");
         lV69Configuracion_areaswwds_7_aredsc2 = StringUtil.Concat( StringUtil.RTrim( AV69Configuracion_areaswwds_7_aredsc2), "%", "");
         lV69Configuracion_areaswwds_7_aredsc2 = StringUtil.Concat( StringUtil.RTrim( AV69Configuracion_areaswwds_7_aredsc2), "%", "");
         lV73Configuracion_areaswwds_11_aredsc3 = StringUtil.Concat( StringUtil.RTrim( AV73Configuracion_areaswwds_11_aredsc3), "%", "");
         lV73Configuracion_areaswwds_11_aredsc3 = StringUtil.Concat( StringUtil.RTrim( AV73Configuracion_areaswwds_11_aredsc3), "%", "");
         lV76Configuracion_areaswwds_14_tfaredsc = StringUtil.Concat( StringUtil.RTrim( AV76Configuracion_areaswwds_14_tfaredsc), "%", "");
         /* Using cursor P004W2 */
         pr_default.execute(0, new Object[] {lV65Configuracion_areaswwds_3_aredsc1, lV65Configuracion_areaswwds_3_aredsc1, lV69Configuracion_areaswwds_7_aredsc2, lV69Configuracion_areaswwds_7_aredsc2, lV73Configuracion_areaswwds_11_aredsc3, lV73Configuracion_areaswwds_11_aredsc3, AV74Configuracion_areaswwds_12_tfarecod, AV75Configuracion_areaswwds_13_tfarecod_to, lV76Configuracion_areaswwds_14_tfaredsc, AV77Configuracion_areaswwds_15_tfaredsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A475AreSts = P004W2_A475AreSts[0];
            A69AreCod = P004W2_A69AreCod[0];
            A474AreDsc = P004W2_A474AreDsc[0];
            if ( A475AreSts == 1 )
            {
               AV50AreStsDescription = "ACTIVO";
            }
            else if ( A475AreSts == 0 )
            {
               AV50AreStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H4W0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A69AreCod), "ZZZZZ9")), 30, Gx_line+10, 179, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A474AreDsc, "")), 183, Gx_line+10, 483, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AreStsDescription, "")), 487, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Configuracion.AreasWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.AreasWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Configuracion.AreasWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV79GXV2 = 1;
         while ( AV79GXV2 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV79GXV2));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFARECOD") == 0 )
            {
               AV30TFAreCod = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV31TFAreCod_To = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFAREDSC") == 0 )
            {
               AV32TFAreDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFAREDSC_SEL") == 0 )
            {
               AV33TFAreDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFARESTS_SEL") == 0 )
            {
               AV51TFAreSts_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV53TFAreSts_Sels.FromJSonString(AV51TFAreSts_SelsJson, null);
            }
            AV79GXV2 = (int)(AV79GXV2+1);
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

      protected void H4W0( bool bFoot ,
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
                  AV46PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV43DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV41AppName = "DVelop Software Solutions";
               AV47Phone = "+1 550 8923";
               AV45Mail = "info@mail.com";
               AV49Website = "http://www.web.com";
               AV38AddressLine1 = "French Boulevard 2859";
               AV39AddressLine2 = "Downtown";
               AV40AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV48Title = "";
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV25GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14AreDsc1 = "";
         AV15FilterAreDscDescription = "";
         AV16AreDsc = "";
         AV18DynamicFiltersSelector2 = "";
         AV20AreDsc2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV24AreDsc3 = "";
         AV36TFAreCod_To_Description = "";
         AV33TFAreDsc_Sel = "";
         AV32TFAreDsc = "";
         AV53TFAreSts_Sels = new GxSimpleCollection<short>();
         AV51TFAreSts_SelsJson = "";
         AV52TFAreSts_SelDscs = "";
         AV55FilterTFAreSts_SelValueDescription = "";
         AV63Configuracion_areaswwds_1_dynamicfiltersselector1 = "";
         AV65Configuracion_areaswwds_3_aredsc1 = "";
         AV67Configuracion_areaswwds_5_dynamicfiltersselector2 = "";
         AV69Configuracion_areaswwds_7_aredsc2 = "";
         AV71Configuracion_areaswwds_9_dynamicfiltersselector3 = "";
         AV73Configuracion_areaswwds_11_aredsc3 = "";
         AV76Configuracion_areaswwds_14_tfaredsc = "";
         AV77Configuracion_areaswwds_15_tfaredsc_sel = "";
         AV78Configuracion_areaswwds_16_tfarests_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV65Configuracion_areaswwds_3_aredsc1 = "";
         lV69Configuracion_areaswwds_7_aredsc2 = "";
         lV73Configuracion_areaswwds_11_aredsc3 = "";
         lV76Configuracion_areaswwds_14_tfaredsc = "";
         A474AreDsc = "";
         P004W2_A475AreSts = new short[1] ;
         P004W2_A69AreCod = new int[1] ;
         P004W2_A474AreDsc = new string[] {""} ;
         AV50AreStsDescription = "";
         AV26Session = context.GetSession();
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46PageInfo = "";
         AV43DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV41AppName = "";
         AV47Phone = "";
         AV45Mail = "";
         AV49Website = "";
         AV38AddressLine1 = "";
         AV39AddressLine2 = "";
         AV40AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.areaswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004W2_A475AreSts, P004W2_A69AreCod, P004W2_A474AreDsc
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
      private short AV54TFAreSts_Sel ;
      private short AV64Configuracion_areaswwds_2_dynamicfiltersoperator1 ;
      private short AV68Configuracion_areaswwds_6_dynamicfiltersoperator2 ;
      private short AV72Configuracion_areaswwds_10_dynamicfiltersoperator3 ;
      private short A475AreSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV30TFAreCod ;
      private int AV31TFAreCod_To ;
      private int AV61GXV1 ;
      private int AV74Configuracion_areaswwds_12_tfarecod ;
      private int AV75Configuracion_areaswwds_13_tfarecod_to ;
      private int AV78Configuracion_areaswwds_16_tfarests_sels_Count ;
      private int A69AreCod ;
      private int AV79GXV2 ;
      private long AV56i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV66Configuracion_areaswwds_4_dynamicfiltersenabled2 ;
      private bool AV70Configuracion_areaswwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV51TFAreSts_SelsJson ;
      private string AV48Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV14AreDsc1 ;
      private string AV15FilterAreDscDescription ;
      private string AV16AreDsc ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV20AreDsc2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV24AreDsc3 ;
      private string AV36TFAreCod_To_Description ;
      private string AV33TFAreDsc_Sel ;
      private string AV32TFAreDsc ;
      private string AV52TFAreSts_SelDscs ;
      private string AV55FilterTFAreSts_SelValueDescription ;
      private string AV63Configuracion_areaswwds_1_dynamicfiltersselector1 ;
      private string AV65Configuracion_areaswwds_3_aredsc1 ;
      private string AV67Configuracion_areaswwds_5_dynamicfiltersselector2 ;
      private string AV69Configuracion_areaswwds_7_aredsc2 ;
      private string AV71Configuracion_areaswwds_9_dynamicfiltersselector3 ;
      private string AV73Configuracion_areaswwds_11_aredsc3 ;
      private string AV76Configuracion_areaswwds_14_tfaredsc ;
      private string AV77Configuracion_areaswwds_15_tfaredsc_sel ;
      private string lV65Configuracion_areaswwds_3_aredsc1 ;
      private string lV69Configuracion_areaswwds_7_aredsc2 ;
      private string lV73Configuracion_areaswwds_11_aredsc3 ;
      private string lV76Configuracion_areaswwds_14_tfaredsc ;
      private string A474AreDsc ;
      private string AV50AreStsDescription ;
      private string AV46PageInfo ;
      private string AV43DateInfo ;
      private string AV41AppName ;
      private string AV47Phone ;
      private string AV45Mail ;
      private string AV49Website ;
      private string AV38AddressLine1 ;
      private string AV39AddressLine2 ;
      private string AV40AddressLine3 ;
      private GxSimpleCollection<short> AV53TFAreSts_Sels ;
      private GxSimpleCollection<short> AV78Configuracion_areaswwds_16_tfarests_sels ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P004W2_A475AreSts ;
      private int[] P004W2_A69AreCod ;
      private string[] P004W2_A474AreDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class areaswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004W2( IGxContext context ,
                                             short A475AreSts ,
                                             GxSimpleCollection<short> AV78Configuracion_areaswwds_16_tfarests_sels ,
                                             string AV63Configuracion_areaswwds_1_dynamicfiltersselector1 ,
                                             short AV64Configuracion_areaswwds_2_dynamicfiltersoperator1 ,
                                             string AV65Configuracion_areaswwds_3_aredsc1 ,
                                             bool AV66Configuracion_areaswwds_4_dynamicfiltersenabled2 ,
                                             string AV67Configuracion_areaswwds_5_dynamicfiltersselector2 ,
                                             short AV68Configuracion_areaswwds_6_dynamicfiltersoperator2 ,
                                             string AV69Configuracion_areaswwds_7_aredsc2 ,
                                             bool AV70Configuracion_areaswwds_8_dynamicfiltersenabled3 ,
                                             string AV71Configuracion_areaswwds_9_dynamicfiltersselector3 ,
                                             short AV72Configuracion_areaswwds_10_dynamicfiltersoperator3 ,
                                             string AV73Configuracion_areaswwds_11_aredsc3 ,
                                             int AV74Configuracion_areaswwds_12_tfarecod ,
                                             int AV75Configuracion_areaswwds_13_tfarecod_to ,
                                             string AV77Configuracion_areaswwds_15_tfaredsc_sel ,
                                             string AV76Configuracion_areaswwds_14_tfaredsc ,
                                             int AV78Configuracion_areaswwds_16_tfarests_sels_Count ,
                                             string A474AreDsc ,
                                             int A69AreCod ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [AreSts], [AreCod], [AreDsc] FROM [CAREAS]";
         if ( ( StringUtil.StrCmp(AV63Configuracion_areaswwds_1_dynamicfiltersselector1, "AREDSC") == 0 ) && ( AV64Configuracion_areaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_areaswwds_3_aredsc1)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like @lV65Configuracion_areaswwds_3_aredsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Configuracion_areaswwds_1_dynamicfiltersselector1, "AREDSC") == 0 ) && ( AV64Configuracion_areaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_areaswwds_3_aredsc1)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like '%' + @lV65Configuracion_areaswwds_3_aredsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV66Configuracion_areaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Configuracion_areaswwds_5_dynamicfiltersselector2, "AREDSC") == 0 ) && ( AV68Configuracion_areaswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_areaswwds_7_aredsc2)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like @lV69Configuracion_areaswwds_7_aredsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV66Configuracion_areaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Configuracion_areaswwds_5_dynamicfiltersselector2, "AREDSC") == 0 ) && ( AV68Configuracion_areaswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_areaswwds_7_aredsc2)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like '%' + @lV69Configuracion_areaswwds_7_aredsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV70Configuracion_areaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Configuracion_areaswwds_9_dynamicfiltersselector3, "AREDSC") == 0 ) && ( AV72Configuracion_areaswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_areaswwds_11_aredsc3)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like @lV73Configuracion_areaswwds_11_aredsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV70Configuracion_areaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Configuracion_areaswwds_9_dynamicfiltersselector3, "AREDSC") == 0 ) && ( AV72Configuracion_areaswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_areaswwds_11_aredsc3)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like '%' + @lV73Configuracion_areaswwds_11_aredsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV74Configuracion_areaswwds_12_tfarecod) )
         {
            AddWhere(sWhereString, "([AreCod] >= @AV74Configuracion_areaswwds_12_tfarecod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV75Configuracion_areaswwds_13_tfarecod_to) )
         {
            AddWhere(sWhereString, "([AreCod] <= @AV75Configuracion_areaswwds_13_tfarecod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_areaswwds_15_tfaredsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_areaswwds_14_tfaredsc)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like @lV76Configuracion_areaswwds_14_tfaredsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_areaswwds_15_tfaredsc_sel)) )
         {
            AddWhere(sWhereString, "([AreDsc] = @AV77Configuracion_areaswwds_15_tfaredsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV78Configuracion_areaswwds_16_tfarests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Configuracion_areaswwds_16_tfarests_sels, "[AreSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [AreDsc]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AreDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [AreCod]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AreCod] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [AreSts]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AreSts] DESC";
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
                     return conditional_P004W2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP004W2;
          prmP004W2 = new Object[] {
          new ParDef("@lV65Configuracion_areaswwds_3_aredsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV65Configuracion_areaswwds_3_aredsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV69Configuracion_areaswwds_7_aredsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV69Configuracion_areaswwds_7_aredsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV73Configuracion_areaswwds_11_aredsc3",GXType.NVarChar,100,0) ,
          new ParDef("@lV73Configuracion_areaswwds_11_aredsc3",GXType.NVarChar,100,0) ,
          new ParDef("@AV74Configuracion_areaswwds_12_tfarecod",GXType.Int32,6,0) ,
          new ParDef("@AV75Configuracion_areaswwds_13_tfarecod_to",GXType.Int32,6,0) ,
          new ParDef("@lV76Configuracion_areaswwds_14_tfaredsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV77Configuracion_areaswwds_15_tfaredsc_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004W2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
