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
   public class localeswwexportreport : GXWebProcedure
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

      public localeswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public localeswwexportreport( IGxContext context )
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
         localeswwexportreport objlocaleswwexportreport;
         objlocaleswwexportreport = new localeswwexportreport();
         objlocaleswwexportreport.context.SetSubmitInitialConfig(context);
         objlocaleswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlocaleswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((localeswwexportreport)stateInfo).executePrivate();
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
            AV50Title = "Lista de Locales";
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
            H210( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "TIEDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV14TieDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TieDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterTieDscDescription = StringUtil.Format( "%1 (%2)", "Local", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterTieDscDescription = StringUtil.Format( "%1 (%2)", "Local", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16TieDsc = AV14TieDsc1;
                  H210( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterTieDscDescription, "")), 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TieDsc, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "TIEDSC") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV20TieDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TieDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterTieDscDescription = StringUtil.Format( "%1 (%2)", "Local", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterTieDscDescription = StringUtil.Format( "%1 (%2)", "Local", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16TieDsc = AV20TieDsc2;
                     H210( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterTieDscDescription, "")), 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TieDsc, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "TIEDSC") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV24TieDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TieDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterTieDscDescription = StringUtil.Format( "%1 (%2)", "Local", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterTieDscDescription = StringUtil.Format( "%1 (%2)", "Local", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16TieDsc = AV24TieDsc3;
                        H210( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterTieDscDescription, "")), 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TieDsc, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV30TFTieCod) && (0==AV31TFTieCod_To) ) )
         {
            H210( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30TFTieCod), "ZZZZZ9")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV38TFTieCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H210( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFTieCod_To_Description, "")), 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFTieCod_To), "ZZZZZ9")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTieDsc_Sel)) )
         {
            H210( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Local", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFTieDsc_Sel, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFTieDsc)) )
            {
               H210( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Local", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFTieDsc, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFTieAbr_Sel)) )
         {
            H210( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFTieAbr_Sel, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTieAbr)) )
            {
               H210( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFTieAbr, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV55TFTieSts_Sels.FromJSonString(AV53TFTieSts_SelsJson, null);
         if ( ! ( AV55TFTieSts_Sels.Count == 0 ) )
         {
            AV58i = 1;
            AV63GXV1 = 1;
            while ( AV63GXV1 <= AV55TFTieSts_Sels.Count )
            {
               AV56TFTieSts_Sel = (short)(AV55TFTieSts_Sels.GetNumeric(AV63GXV1));
               if ( AV58i == 1 )
               {
                  AV54TFTieSts_SelDscs = "";
               }
               else
               {
                  AV54TFTieSts_SelDscs += ", ";
               }
               if ( AV56TFTieSts_Sel == 1 )
               {
                  AV57FilterTFTieSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV56TFTieSts_Sel == 0 )
               {
                  AV57FilterTFTieSts_SelValueDescription = "INACTIVO";
               }
               AV54TFTieSts_SelDscs += AV57FilterTFTieSts_SelValueDescription;
               AV58i = (long)(AV58i+1);
               AV63GXV1 = (int)(AV63GXV1+1);
            }
            H210( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 171, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54TFTieSts_SelDscs, "")), 171, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H210( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H210( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 154, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Local", 158, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Abreviatura", 410, Gx_line+10, 534, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 538, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV65Seguridad_localeswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV66Seguridad_localeswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV67Seguridad_localeswwds_3_tiedsc1 = AV14TieDsc1;
         AV68Seguridad_localeswwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV69Seguridad_localeswwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV70Seguridad_localeswwds_6_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV71Seguridad_localeswwds_7_tiedsc2 = AV20TieDsc2;
         AV72Seguridad_localeswwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV73Seguridad_localeswwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV74Seguridad_localeswwds_10_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV75Seguridad_localeswwds_11_tiedsc3 = AV24TieDsc3;
         AV76Seguridad_localeswwds_12_tftiecod = AV30TFTieCod;
         AV77Seguridad_localeswwds_13_tftiecod_to = AV31TFTieCod_To;
         AV78Seguridad_localeswwds_14_tftiedsc = AV32TFTieDsc;
         AV79Seguridad_localeswwds_15_tftiedsc_sel = AV33TFTieDsc_Sel;
         AV80Seguridad_localeswwds_16_tftieabr = AV34TFTieAbr;
         AV81Seguridad_localeswwds_17_tftieabr_sel = AV35TFTieAbr_Sel;
         AV82Seguridad_localeswwds_18_tftiests_sels = AV55TFTieSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1899TieSts ,
                                              AV82Seguridad_localeswwds_18_tftiests_sels ,
                                              AV65Seguridad_localeswwds_1_dynamicfiltersselector1 ,
                                              AV66Seguridad_localeswwds_2_dynamicfiltersoperator1 ,
                                              AV67Seguridad_localeswwds_3_tiedsc1 ,
                                              AV68Seguridad_localeswwds_4_dynamicfiltersenabled2 ,
                                              AV69Seguridad_localeswwds_5_dynamicfiltersselector2 ,
                                              AV70Seguridad_localeswwds_6_dynamicfiltersoperator2 ,
                                              AV71Seguridad_localeswwds_7_tiedsc2 ,
                                              AV72Seguridad_localeswwds_8_dynamicfiltersenabled3 ,
                                              AV73Seguridad_localeswwds_9_dynamicfiltersselector3 ,
                                              AV74Seguridad_localeswwds_10_dynamicfiltersoperator3 ,
                                              AV75Seguridad_localeswwds_11_tiedsc3 ,
                                              AV76Seguridad_localeswwds_12_tftiecod ,
                                              AV77Seguridad_localeswwds_13_tftiecod_to ,
                                              AV79Seguridad_localeswwds_15_tftiedsc_sel ,
                                              AV78Seguridad_localeswwds_14_tftiedsc ,
                                              AV81Seguridad_localeswwds_17_tftieabr_sel ,
                                              AV80Seguridad_localeswwds_16_tftieabr ,
                                              AV82Seguridad_localeswwds_18_tftiests_sels.Count ,
                                              A1898TieDsc ,
                                              A178TieCod ,
                                              A1897TieAbr ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV67Seguridad_localeswwds_3_tiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV67Seguridad_localeswwds_3_tiedsc1), 100, "%");
         lV67Seguridad_localeswwds_3_tiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV67Seguridad_localeswwds_3_tiedsc1), 100, "%");
         lV71Seguridad_localeswwds_7_tiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV71Seguridad_localeswwds_7_tiedsc2), 100, "%");
         lV71Seguridad_localeswwds_7_tiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV71Seguridad_localeswwds_7_tiedsc2), 100, "%");
         lV75Seguridad_localeswwds_11_tiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV75Seguridad_localeswwds_11_tiedsc3), 100, "%");
         lV75Seguridad_localeswwds_11_tiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV75Seguridad_localeswwds_11_tiedsc3), 100, "%");
         lV78Seguridad_localeswwds_14_tftiedsc = StringUtil.PadR( StringUtil.RTrim( AV78Seguridad_localeswwds_14_tftiedsc), 100, "%");
         lV80Seguridad_localeswwds_16_tftieabr = StringUtil.Concat( StringUtil.RTrim( AV80Seguridad_localeswwds_16_tftieabr), "%", "");
         /* Using cursor P00212 */
         pr_default.execute(0, new Object[] {lV67Seguridad_localeswwds_3_tiedsc1, lV67Seguridad_localeswwds_3_tiedsc1, lV71Seguridad_localeswwds_7_tiedsc2, lV71Seguridad_localeswwds_7_tiedsc2, lV75Seguridad_localeswwds_11_tiedsc3, lV75Seguridad_localeswwds_11_tiedsc3, AV76Seguridad_localeswwds_12_tftiecod, AV77Seguridad_localeswwds_13_tftiecod_to, lV78Seguridad_localeswwds_14_tftiedsc, AV79Seguridad_localeswwds_15_tftiedsc_sel, lV80Seguridad_localeswwds_16_tftieabr, AV81Seguridad_localeswwds_17_tftieabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1899TieSts = P00212_A1899TieSts[0];
            A1897TieAbr = P00212_A1897TieAbr[0];
            A178TieCod = P00212_A178TieCod[0];
            A1898TieDsc = P00212_A1898TieDsc[0];
            if ( A1899TieSts == 1 )
            {
               AV52TieStsDescription = "ACTIVO";
            }
            else if ( A1899TieSts == 0 )
            {
               AV52TieStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H210( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A178TieCod), "ZZZZZ9")), 30, Gx_line+10, 154, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1898TieDsc, "")), 158, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1897TieAbr, "")), 410, Gx_line+10, 534, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TieStsDescription, "")), 538, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Seguridad.LocalesWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.LocalesWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Seguridad.LocalesWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV83GXV2 = 1;
         while ( AV83GXV2 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV83GXV2));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIECOD") == 0 )
            {
               AV30TFTieCod = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV31TFTieCod_To = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIEDSC") == 0 )
            {
               AV32TFTieDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIEDSC_SEL") == 0 )
            {
               AV33TFTieDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIEABR") == 0 )
            {
               AV34TFTieAbr = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIEABR_SEL") == 0 )
            {
               AV35TFTieAbr_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTIESTS_SEL") == 0 )
            {
               AV53TFTieSts_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV55TFTieSts_Sels.FromJSonString(AV53TFTieSts_SelsJson, null);
            }
            AV83GXV2 = (int)(AV83GXV2+1);
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

      protected void H210( bool bFoot ,
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
                  AV48PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV45DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV43AppName = "DVelop Software Solutions";
               AV49Phone = "+1 550 8923";
               AV47Mail = "info@mail.com";
               AV51Website = "http://www.web.com";
               AV40AddressLine1 = "French Boulevard 2859";
               AV41AddressLine2 = "Downtown";
               AV42AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV50Title = "";
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV25GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14TieDsc1 = "";
         AV15FilterTieDscDescription = "";
         AV16TieDsc = "";
         AV18DynamicFiltersSelector2 = "";
         AV20TieDsc2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV24TieDsc3 = "";
         AV38TFTieCod_To_Description = "";
         AV33TFTieDsc_Sel = "";
         AV32TFTieDsc = "";
         AV35TFTieAbr_Sel = "";
         AV34TFTieAbr = "";
         AV55TFTieSts_Sels = new GxSimpleCollection<short>();
         AV53TFTieSts_SelsJson = "";
         AV54TFTieSts_SelDscs = "";
         AV57FilterTFTieSts_SelValueDescription = "";
         AV65Seguridad_localeswwds_1_dynamicfiltersselector1 = "";
         AV67Seguridad_localeswwds_3_tiedsc1 = "";
         AV69Seguridad_localeswwds_5_dynamicfiltersselector2 = "";
         AV71Seguridad_localeswwds_7_tiedsc2 = "";
         AV73Seguridad_localeswwds_9_dynamicfiltersselector3 = "";
         AV75Seguridad_localeswwds_11_tiedsc3 = "";
         AV78Seguridad_localeswwds_14_tftiedsc = "";
         AV79Seguridad_localeswwds_15_tftiedsc_sel = "";
         AV80Seguridad_localeswwds_16_tftieabr = "";
         AV81Seguridad_localeswwds_17_tftieabr_sel = "";
         AV82Seguridad_localeswwds_18_tftiests_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV67Seguridad_localeswwds_3_tiedsc1 = "";
         lV71Seguridad_localeswwds_7_tiedsc2 = "";
         lV75Seguridad_localeswwds_11_tiedsc3 = "";
         lV78Seguridad_localeswwds_14_tftiedsc = "";
         lV80Seguridad_localeswwds_16_tftieabr = "";
         A1898TieDsc = "";
         A1897TieAbr = "";
         P00212_A1899TieSts = new short[1] ;
         P00212_A1897TieAbr = new string[] {""} ;
         P00212_A178TieCod = new int[1] ;
         P00212_A1898TieDsc = new string[] {""} ;
         AV52TieStsDescription = "";
         AV26Session = context.GetSession();
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV48PageInfo = "";
         AV45DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV43AppName = "";
         AV49Phone = "";
         AV47Mail = "";
         AV51Website = "";
         AV40AddressLine1 = "";
         AV41AddressLine2 = "";
         AV42AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.localeswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00212_A1899TieSts, P00212_A1897TieAbr, P00212_A178TieCod, P00212_A1898TieDsc
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
      private short AV56TFTieSts_Sel ;
      private short AV66Seguridad_localeswwds_2_dynamicfiltersoperator1 ;
      private short AV70Seguridad_localeswwds_6_dynamicfiltersoperator2 ;
      private short AV74Seguridad_localeswwds_10_dynamicfiltersoperator3 ;
      private short A1899TieSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV30TFTieCod ;
      private int AV31TFTieCod_To ;
      private int AV63GXV1 ;
      private int AV76Seguridad_localeswwds_12_tftiecod ;
      private int AV77Seguridad_localeswwds_13_tftiecod_to ;
      private int AV82Seguridad_localeswwds_18_tftiests_sels_Count ;
      private int A178TieCod ;
      private int AV83GXV2 ;
      private long AV58i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14TieDsc1 ;
      private string AV16TieDsc ;
      private string AV20TieDsc2 ;
      private string AV24TieDsc3 ;
      private string AV33TFTieDsc_Sel ;
      private string AV32TFTieDsc ;
      private string AV67Seguridad_localeswwds_3_tiedsc1 ;
      private string AV71Seguridad_localeswwds_7_tiedsc2 ;
      private string AV75Seguridad_localeswwds_11_tiedsc3 ;
      private string AV78Seguridad_localeswwds_14_tftiedsc ;
      private string AV79Seguridad_localeswwds_15_tftiedsc_sel ;
      private string scmdbuf ;
      private string lV67Seguridad_localeswwds_3_tiedsc1 ;
      private string lV71Seguridad_localeswwds_7_tiedsc2 ;
      private string lV75Seguridad_localeswwds_11_tiedsc3 ;
      private string lV78Seguridad_localeswwds_14_tftiedsc ;
      private string A1898TieDsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV68Seguridad_localeswwds_4_dynamicfiltersenabled2 ;
      private bool AV72Seguridad_localeswwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV53TFTieSts_SelsJson ;
      private string AV50Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterTieDscDescription ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV38TFTieCod_To_Description ;
      private string AV35TFTieAbr_Sel ;
      private string AV34TFTieAbr ;
      private string AV54TFTieSts_SelDscs ;
      private string AV57FilterTFTieSts_SelValueDescription ;
      private string AV65Seguridad_localeswwds_1_dynamicfiltersselector1 ;
      private string AV69Seguridad_localeswwds_5_dynamicfiltersselector2 ;
      private string AV73Seguridad_localeswwds_9_dynamicfiltersselector3 ;
      private string AV80Seguridad_localeswwds_16_tftieabr ;
      private string AV81Seguridad_localeswwds_17_tftieabr_sel ;
      private string lV80Seguridad_localeswwds_16_tftieabr ;
      private string A1897TieAbr ;
      private string AV52TieStsDescription ;
      private string AV48PageInfo ;
      private string AV45DateInfo ;
      private string AV43AppName ;
      private string AV49Phone ;
      private string AV47Mail ;
      private string AV51Website ;
      private string AV40AddressLine1 ;
      private string AV41AddressLine2 ;
      private string AV42AddressLine3 ;
      private GxSimpleCollection<short> AV55TFTieSts_Sels ;
      private GxSimpleCollection<short> AV82Seguridad_localeswwds_18_tftiests_sels ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00212_A1899TieSts ;
      private string[] P00212_A1897TieAbr ;
      private int[] P00212_A178TieCod ;
      private string[] P00212_A1898TieDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class localeswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00212( IGxContext context ,
                                             short A1899TieSts ,
                                             GxSimpleCollection<short> AV82Seguridad_localeswwds_18_tftiests_sels ,
                                             string AV65Seguridad_localeswwds_1_dynamicfiltersselector1 ,
                                             short AV66Seguridad_localeswwds_2_dynamicfiltersoperator1 ,
                                             string AV67Seguridad_localeswwds_3_tiedsc1 ,
                                             bool AV68Seguridad_localeswwds_4_dynamicfiltersenabled2 ,
                                             string AV69Seguridad_localeswwds_5_dynamicfiltersselector2 ,
                                             short AV70Seguridad_localeswwds_6_dynamicfiltersoperator2 ,
                                             string AV71Seguridad_localeswwds_7_tiedsc2 ,
                                             bool AV72Seguridad_localeswwds_8_dynamicfiltersenabled3 ,
                                             string AV73Seguridad_localeswwds_9_dynamicfiltersselector3 ,
                                             short AV74Seguridad_localeswwds_10_dynamicfiltersoperator3 ,
                                             string AV75Seguridad_localeswwds_11_tiedsc3 ,
                                             int AV76Seguridad_localeswwds_12_tftiecod ,
                                             int AV77Seguridad_localeswwds_13_tftiecod_to ,
                                             string AV79Seguridad_localeswwds_15_tftiedsc_sel ,
                                             string AV78Seguridad_localeswwds_14_tftiedsc ,
                                             string AV81Seguridad_localeswwds_17_tftieabr_sel ,
                                             string AV80Seguridad_localeswwds_16_tftieabr ,
                                             int AV82Seguridad_localeswwds_18_tftiests_sels_Count ,
                                             string A1898TieDsc ,
                                             int A178TieCod ,
                                             string A1897TieAbr ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TieSts], [TieAbr], [TieCod], [TieDsc] FROM [SGTIENDAS]";
         if ( ( StringUtil.StrCmp(AV65Seguridad_localeswwds_1_dynamicfiltersselector1, "TIEDSC") == 0 ) && ( AV66Seguridad_localeswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Seguridad_localeswwds_3_tiedsc1)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV67Seguridad_localeswwds_3_tiedsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Seguridad_localeswwds_1_dynamicfiltersselector1, "TIEDSC") == 0 ) && ( AV66Seguridad_localeswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Seguridad_localeswwds_3_tiedsc1)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like '%' + @lV67Seguridad_localeswwds_3_tiedsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV68Seguridad_localeswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Seguridad_localeswwds_5_dynamicfiltersselector2, "TIEDSC") == 0 ) && ( AV70Seguridad_localeswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Seguridad_localeswwds_7_tiedsc2)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV71Seguridad_localeswwds_7_tiedsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV68Seguridad_localeswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Seguridad_localeswwds_5_dynamicfiltersselector2, "TIEDSC") == 0 ) && ( AV70Seguridad_localeswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Seguridad_localeswwds_7_tiedsc2)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like '%' + @lV71Seguridad_localeswwds_7_tiedsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV72Seguridad_localeswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Seguridad_localeswwds_9_dynamicfiltersselector3, "TIEDSC") == 0 ) && ( AV74Seguridad_localeswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_localeswwds_11_tiedsc3)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV75Seguridad_localeswwds_11_tiedsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV72Seguridad_localeswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Seguridad_localeswwds_9_dynamicfiltersselector3, "TIEDSC") == 0 ) && ( AV74Seguridad_localeswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_localeswwds_11_tiedsc3)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like '%' + @lV75Seguridad_localeswwds_11_tiedsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV76Seguridad_localeswwds_12_tftiecod) )
         {
            AddWhere(sWhereString, "([TieCod] >= @AV76Seguridad_localeswwds_12_tftiecod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV77Seguridad_localeswwds_13_tftiecod_to) )
         {
            AddWhere(sWhereString, "([TieCod] <= @AV77Seguridad_localeswwds_13_tftiecod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_localeswwds_15_tftiedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Seguridad_localeswwds_14_tftiedsc)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV78Seguridad_localeswwds_14_tftiedsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_localeswwds_15_tftiedsc_sel)) )
         {
            AddWhere(sWhereString, "([TieDsc] = @AV79Seguridad_localeswwds_15_tftiedsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_localeswwds_17_tftieabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_localeswwds_16_tftieabr)) ) )
         {
            AddWhere(sWhereString, "([TieAbr] like @lV80Seguridad_localeswwds_16_tftieabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_localeswwds_17_tftieabr_sel)) )
         {
            AddWhere(sWhereString, "([TieAbr] = @AV81Seguridad_localeswwds_17_tftieabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV82Seguridad_localeswwds_18_tftiests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Seguridad_localeswwds_18_tftiests_sels, "[TieSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TieCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TieCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TieDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TieDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TieAbr]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TieAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TieSts]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TieSts] DESC";
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
                     return conditional_P00212(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP00212;
          prmP00212 = new Object[] {
          new ParDef("@lV67Seguridad_localeswwds_3_tiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV67Seguridad_localeswwds_3_tiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV71Seguridad_localeswwds_7_tiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV71Seguridad_localeswwds_7_tiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV75Seguridad_localeswwds_11_tiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV75Seguridad_localeswwds_11_tiedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV76Seguridad_localeswwds_12_tftiecod",GXType.Int32,6,0) ,
          new ParDef("@AV77Seguridad_localeswwds_13_tftiecod_to",GXType.Int32,6,0) ,
          new ParDef("@lV78Seguridad_localeswwds_14_tftiedsc",GXType.NChar,100,0) ,
          new ParDef("@AV79Seguridad_localeswwds_15_tftiedsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV80Seguridad_localeswwds_16_tftieabr",GXType.NVarChar,10,0) ,
          new ParDef("@AV81Seguridad_localeswwds_17_tftieabr_sel",GXType.NVarChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00212", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00212,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
