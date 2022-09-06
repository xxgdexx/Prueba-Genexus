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
   public class sublineawwexportreport : GXWebProcedure
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

      public sublineawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sublineawwexportreport( IGxContext context )
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
         sublineawwexportreport objsublineawwexportreport;
         objsublineawwexportreport = new sublineawwexportreport();
         objsublineawwexportreport.context.SetSubmitInitialConfig(context);
         objsublineawwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objsublineawwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sublineawwexportreport)stateInfo).executePrivate();
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
            AV50Title = "Lista de Sub Linea Productos";
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
            H2U0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "SUBLDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV14SublDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SublDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterSublDscDescription = StringUtil.Format( "%1 (%2)", "Sub Linea", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterSublDscDescription = StringUtil.Format( "%1 (%2)", "Sub Linea", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16SublDsc = AV14SublDsc1;
                  H2U0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterSublDscDescription, "")), 25, Gx_line+0, 193, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16SublDsc, "")), 193, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "SUBLDSC") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV20SublDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20SublDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterSublDscDescription = StringUtil.Format( "%1 (%2)", "Sub Linea", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterSublDscDescription = StringUtil.Format( "%1 (%2)", "Sub Linea", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16SublDsc = AV20SublDsc2;
                     H2U0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterSublDscDescription, "")), 25, Gx_line+0, 193, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16SublDsc, "")), 193, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "SUBLDSC") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV24SublDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SublDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterSublDscDescription = StringUtil.Format( "%1 (%2)", "Sub Linea", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterSublDscDescription = StringUtil.Format( "%1 (%2)", "Sub Linea", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16SublDsc = AV24SublDsc3;
                        H2U0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterSublDscDescription, "")), 25, Gx_line+0, 193, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16SublDsc, "")), 193, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV30TFSublCod) && (0==AV31TFSublCod_To) ) )
         {
            H2U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 193, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30TFSublCod), "ZZZZZ9")), 193, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV38TFSublCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H2U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFSublCod_To_Description, "")), 25, Gx_line+0, 193, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFSublCod_To), "ZZZZZ9")), 193, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSublDsc_Sel)) )
         {
            H2U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Sub Linea", 25, Gx_line+0, 193, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFSublDsc_Sel, "")), 193, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSublDsc)) )
            {
               H2U0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Sub Linea", 25, Gx_line+0, 193, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFSublDsc, "")), 193, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSublAbr_Sel)) )
         {
            H2U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 193, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFSublAbr_Sel, "")), 193, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSublAbr)) )
            {
               H2U0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 193, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFSublAbr, "")), 193, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV55TFSublSts_Sels.FromJSonString(AV53TFSublSts_SelsJson, null);
         if ( ! ( AV55TFSublSts_Sels.Count == 0 ) )
         {
            AV58i = 1;
            AV63GXV1 = 1;
            while ( AV63GXV1 <= AV55TFSublSts_Sels.Count )
            {
               AV56TFSublSts_Sel = (short)(AV55TFSublSts_Sels.GetNumeric(AV63GXV1));
               if ( AV58i == 1 )
               {
                  AV54TFSublSts_SelDscs = "";
               }
               else
               {
                  AV54TFSublSts_SelDscs += ", ";
               }
               if ( AV56TFSublSts_Sel == 1 )
               {
                  AV57FilterTFSublSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV56TFSublSts_Sel == 0 )
               {
                  AV57FilterTFSublSts_SelValueDescription = "INACTIVO";
               }
               AV54TFSublSts_SelDscs += AV57FilterTFSublSts_SelValueDescription;
               AV58i = (long)(AV58i+1);
               AV63GXV1 = (int)(AV63GXV1+1);
            }
            H2U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 193, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54TFSublSts_SelDscs, "")), 193, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H2U0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H2U0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 154, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Sub Linea", 158, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Abreviatura", 410, Gx_line+10, 534, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 538, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV65Configuracion_sublineawwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV66Configuracion_sublineawwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV67Configuracion_sublineawwds_3_subldsc1 = AV14SublDsc1;
         AV68Configuracion_sublineawwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV69Configuracion_sublineawwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV70Configuracion_sublineawwds_6_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV71Configuracion_sublineawwds_7_subldsc2 = AV20SublDsc2;
         AV72Configuracion_sublineawwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV73Configuracion_sublineawwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV74Configuracion_sublineawwds_10_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV75Configuracion_sublineawwds_11_subldsc3 = AV24SublDsc3;
         AV76Configuracion_sublineawwds_12_tfsublcod = AV30TFSublCod;
         AV77Configuracion_sublineawwds_13_tfsublcod_to = AV31TFSublCod_To;
         AV78Configuracion_sublineawwds_14_tfsubldsc = AV32TFSublDsc;
         AV79Configuracion_sublineawwds_15_tfsubldsc_sel = AV33TFSublDsc_Sel;
         AV80Configuracion_sublineawwds_16_tfsublabr = AV34TFSublAbr;
         AV81Configuracion_sublineawwds_17_tfsublabr_sel = AV35TFSublAbr_Sel;
         AV82Configuracion_sublineawwds_18_tfsublsts_sels = AV55TFSublSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1893SublSts ,
                                              AV82Configuracion_sublineawwds_18_tfsublsts_sels ,
                                              AV65Configuracion_sublineawwds_1_dynamicfiltersselector1 ,
                                              AV66Configuracion_sublineawwds_2_dynamicfiltersoperator1 ,
                                              AV67Configuracion_sublineawwds_3_subldsc1 ,
                                              AV68Configuracion_sublineawwds_4_dynamicfiltersenabled2 ,
                                              AV69Configuracion_sublineawwds_5_dynamicfiltersselector2 ,
                                              AV70Configuracion_sublineawwds_6_dynamicfiltersoperator2 ,
                                              AV71Configuracion_sublineawwds_7_subldsc2 ,
                                              AV72Configuracion_sublineawwds_8_dynamicfiltersenabled3 ,
                                              AV73Configuracion_sublineawwds_9_dynamicfiltersselector3 ,
                                              AV74Configuracion_sublineawwds_10_dynamicfiltersoperator3 ,
                                              AV75Configuracion_sublineawwds_11_subldsc3 ,
                                              AV76Configuracion_sublineawwds_12_tfsublcod ,
                                              AV77Configuracion_sublineawwds_13_tfsublcod_to ,
                                              AV79Configuracion_sublineawwds_15_tfsubldsc_sel ,
                                              AV78Configuracion_sublineawwds_14_tfsubldsc ,
                                              AV81Configuracion_sublineawwds_17_tfsublabr_sel ,
                                              AV80Configuracion_sublineawwds_16_tfsublabr ,
                                              AV82Configuracion_sublineawwds_18_tfsublsts_sels.Count ,
                                              A1892SublDsc ,
                                              A51SublCod ,
                                              A1891SublAbr ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV67Configuracion_sublineawwds_3_subldsc1 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_sublineawwds_3_subldsc1), 100, "%");
         lV67Configuracion_sublineawwds_3_subldsc1 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_sublineawwds_3_subldsc1), 100, "%");
         lV71Configuracion_sublineawwds_7_subldsc2 = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_sublineawwds_7_subldsc2), 100, "%");
         lV71Configuracion_sublineawwds_7_subldsc2 = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_sublineawwds_7_subldsc2), 100, "%");
         lV75Configuracion_sublineawwds_11_subldsc3 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_sublineawwds_11_subldsc3), 100, "%");
         lV75Configuracion_sublineawwds_11_subldsc3 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_sublineawwds_11_subldsc3), 100, "%");
         lV78Configuracion_sublineawwds_14_tfsubldsc = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_sublineawwds_14_tfsubldsc), 100, "%");
         lV80Configuracion_sublineawwds_16_tfsublabr = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_sublineawwds_16_tfsublabr), 5, "%");
         /* Using cursor P002U2 */
         pr_default.execute(0, new Object[] {lV67Configuracion_sublineawwds_3_subldsc1, lV67Configuracion_sublineawwds_3_subldsc1, lV71Configuracion_sublineawwds_7_subldsc2, lV71Configuracion_sublineawwds_7_subldsc2, lV75Configuracion_sublineawwds_11_subldsc3, lV75Configuracion_sublineawwds_11_subldsc3, AV76Configuracion_sublineawwds_12_tfsublcod, AV77Configuracion_sublineawwds_13_tfsublcod_to, lV78Configuracion_sublineawwds_14_tfsubldsc, AV79Configuracion_sublineawwds_15_tfsubldsc_sel, lV80Configuracion_sublineawwds_16_tfsublabr, AV81Configuracion_sublineawwds_17_tfsublabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1893SublSts = P002U2_A1893SublSts[0];
            A1891SublAbr = P002U2_A1891SublAbr[0];
            A51SublCod = P002U2_A51SublCod[0];
            A1892SublDsc = P002U2_A1892SublDsc[0];
            if ( A1893SublSts == 1 )
            {
               AV52SublStsDescription = "ACTIVO";
            }
            else if ( A1893SublSts == 0 )
            {
               AV52SublStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H2U0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A51SublCod), "ZZZZZ9")), 30, Gx_line+10, 154, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1892SublDsc, "")), 158, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1891SublAbr, "")), 410, Gx_line+10, 534, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52SublStsDescription, "")), 538, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Configuracion.SubLineaWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.SubLineaWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Configuracion.SubLineaWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV83GXV2 = 1;
         while ( AV83GXV2 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV83GXV2));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSUBLCOD") == 0 )
            {
               AV30TFSublCod = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV31TFSublCod_To = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSUBLDSC") == 0 )
            {
               AV32TFSublDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSUBLDSC_SEL") == 0 )
            {
               AV33TFSublDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSUBLABR") == 0 )
            {
               AV34TFSublAbr = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSUBLABR_SEL") == 0 )
            {
               AV35TFSublAbr_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSUBLSTS_SEL") == 0 )
            {
               AV53TFSublSts_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV55TFSublSts_Sels.FromJSonString(AV53TFSublSts_SelsJson, null);
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

      protected void H2U0( bool bFoot ,
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
         AV14SublDsc1 = "";
         AV15FilterSublDscDescription = "";
         AV16SublDsc = "";
         AV18DynamicFiltersSelector2 = "";
         AV20SublDsc2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV24SublDsc3 = "";
         AV38TFSublCod_To_Description = "";
         AV33TFSublDsc_Sel = "";
         AV32TFSublDsc = "";
         AV35TFSublAbr_Sel = "";
         AV34TFSublAbr = "";
         AV55TFSublSts_Sels = new GxSimpleCollection<short>();
         AV53TFSublSts_SelsJson = "";
         AV54TFSublSts_SelDscs = "";
         AV57FilterTFSublSts_SelValueDescription = "";
         AV65Configuracion_sublineawwds_1_dynamicfiltersselector1 = "";
         AV67Configuracion_sublineawwds_3_subldsc1 = "";
         AV69Configuracion_sublineawwds_5_dynamicfiltersselector2 = "";
         AV71Configuracion_sublineawwds_7_subldsc2 = "";
         AV73Configuracion_sublineawwds_9_dynamicfiltersselector3 = "";
         AV75Configuracion_sublineawwds_11_subldsc3 = "";
         AV78Configuracion_sublineawwds_14_tfsubldsc = "";
         AV79Configuracion_sublineawwds_15_tfsubldsc_sel = "";
         AV80Configuracion_sublineawwds_16_tfsublabr = "";
         AV81Configuracion_sublineawwds_17_tfsublabr_sel = "";
         AV82Configuracion_sublineawwds_18_tfsublsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV67Configuracion_sublineawwds_3_subldsc1 = "";
         lV71Configuracion_sublineawwds_7_subldsc2 = "";
         lV75Configuracion_sublineawwds_11_subldsc3 = "";
         lV78Configuracion_sublineawwds_14_tfsubldsc = "";
         lV80Configuracion_sublineawwds_16_tfsublabr = "";
         A1892SublDsc = "";
         A1891SublAbr = "";
         P002U2_A1893SublSts = new short[1] ;
         P002U2_A1891SublAbr = new string[] {""} ;
         P002U2_A51SublCod = new int[1] ;
         P002U2_A1892SublDsc = new string[] {""} ;
         AV52SublStsDescription = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.sublineawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P002U2_A1893SublSts, P002U2_A1891SublAbr, P002U2_A51SublCod, P002U2_A1892SublDsc
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
      private short AV56TFSublSts_Sel ;
      private short AV66Configuracion_sublineawwds_2_dynamicfiltersoperator1 ;
      private short AV70Configuracion_sublineawwds_6_dynamicfiltersoperator2 ;
      private short AV74Configuracion_sublineawwds_10_dynamicfiltersoperator3 ;
      private short A1893SublSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV30TFSublCod ;
      private int AV31TFSublCod_To ;
      private int AV63GXV1 ;
      private int AV76Configuracion_sublineawwds_12_tfsublcod ;
      private int AV77Configuracion_sublineawwds_13_tfsublcod_to ;
      private int AV82Configuracion_sublineawwds_18_tfsublsts_sels_Count ;
      private int A51SublCod ;
      private int AV83GXV2 ;
      private long AV58i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14SublDsc1 ;
      private string AV16SublDsc ;
      private string AV20SublDsc2 ;
      private string AV24SublDsc3 ;
      private string AV33TFSublDsc_Sel ;
      private string AV32TFSublDsc ;
      private string AV35TFSublAbr_Sel ;
      private string AV34TFSublAbr ;
      private string AV67Configuracion_sublineawwds_3_subldsc1 ;
      private string AV71Configuracion_sublineawwds_7_subldsc2 ;
      private string AV75Configuracion_sublineawwds_11_subldsc3 ;
      private string AV78Configuracion_sublineawwds_14_tfsubldsc ;
      private string AV79Configuracion_sublineawwds_15_tfsubldsc_sel ;
      private string AV80Configuracion_sublineawwds_16_tfsublabr ;
      private string AV81Configuracion_sublineawwds_17_tfsublabr_sel ;
      private string scmdbuf ;
      private string lV67Configuracion_sublineawwds_3_subldsc1 ;
      private string lV71Configuracion_sublineawwds_7_subldsc2 ;
      private string lV75Configuracion_sublineawwds_11_subldsc3 ;
      private string lV78Configuracion_sublineawwds_14_tfsubldsc ;
      private string lV80Configuracion_sublineawwds_16_tfsublabr ;
      private string A1892SublDsc ;
      private string A1891SublAbr ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV68Configuracion_sublineawwds_4_dynamicfiltersenabled2 ;
      private bool AV72Configuracion_sublineawwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV53TFSublSts_SelsJson ;
      private string AV50Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterSublDscDescription ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV38TFSublCod_To_Description ;
      private string AV54TFSublSts_SelDscs ;
      private string AV57FilterTFSublSts_SelValueDescription ;
      private string AV65Configuracion_sublineawwds_1_dynamicfiltersselector1 ;
      private string AV69Configuracion_sublineawwds_5_dynamicfiltersselector2 ;
      private string AV73Configuracion_sublineawwds_9_dynamicfiltersselector3 ;
      private string AV52SublStsDescription ;
      private string AV48PageInfo ;
      private string AV45DateInfo ;
      private string AV43AppName ;
      private string AV49Phone ;
      private string AV47Mail ;
      private string AV51Website ;
      private string AV40AddressLine1 ;
      private string AV41AddressLine2 ;
      private string AV42AddressLine3 ;
      private GxSimpleCollection<short> AV55TFSublSts_Sels ;
      private GxSimpleCollection<short> AV82Configuracion_sublineawwds_18_tfsublsts_sels ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002U2_A1893SublSts ;
      private string[] P002U2_A1891SublAbr ;
      private int[] P002U2_A51SublCod ;
      private string[] P002U2_A1892SublDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class sublineawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002U2( IGxContext context ,
                                             short A1893SublSts ,
                                             GxSimpleCollection<short> AV82Configuracion_sublineawwds_18_tfsublsts_sels ,
                                             string AV65Configuracion_sublineawwds_1_dynamicfiltersselector1 ,
                                             short AV66Configuracion_sublineawwds_2_dynamicfiltersoperator1 ,
                                             string AV67Configuracion_sublineawwds_3_subldsc1 ,
                                             bool AV68Configuracion_sublineawwds_4_dynamicfiltersenabled2 ,
                                             string AV69Configuracion_sublineawwds_5_dynamicfiltersselector2 ,
                                             short AV70Configuracion_sublineawwds_6_dynamicfiltersoperator2 ,
                                             string AV71Configuracion_sublineawwds_7_subldsc2 ,
                                             bool AV72Configuracion_sublineawwds_8_dynamicfiltersenabled3 ,
                                             string AV73Configuracion_sublineawwds_9_dynamicfiltersselector3 ,
                                             short AV74Configuracion_sublineawwds_10_dynamicfiltersoperator3 ,
                                             string AV75Configuracion_sublineawwds_11_subldsc3 ,
                                             int AV76Configuracion_sublineawwds_12_tfsublcod ,
                                             int AV77Configuracion_sublineawwds_13_tfsublcod_to ,
                                             string AV79Configuracion_sublineawwds_15_tfsubldsc_sel ,
                                             string AV78Configuracion_sublineawwds_14_tfsubldsc ,
                                             string AV81Configuracion_sublineawwds_17_tfsublabr_sel ,
                                             string AV80Configuracion_sublineawwds_16_tfsublabr ,
                                             int AV82Configuracion_sublineawwds_18_tfsublsts_sels_Count ,
                                             string A1892SublDsc ,
                                             int A51SublCod ,
                                             string A1891SublAbr ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [SublSts], [SublAbr], [SublCod], [SublDsc] FROM [CSUBLPROD]";
         if ( ( StringUtil.StrCmp(AV65Configuracion_sublineawwds_1_dynamicfiltersselector1, "SUBLDSC") == 0 ) && ( AV66Configuracion_sublineawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_sublineawwds_3_subldsc1)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV67Configuracion_sublineawwds_3_subldsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Configuracion_sublineawwds_1_dynamicfiltersselector1, "SUBLDSC") == 0 ) && ( AV66Configuracion_sublineawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_sublineawwds_3_subldsc1)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like '%' + @lV67Configuracion_sublineawwds_3_subldsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV68Configuracion_sublineawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Configuracion_sublineawwds_5_dynamicfiltersselector2, "SUBLDSC") == 0 ) && ( AV70Configuracion_sublineawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_sublineawwds_7_subldsc2)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV71Configuracion_sublineawwds_7_subldsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV68Configuracion_sublineawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Configuracion_sublineawwds_5_dynamicfiltersselector2, "SUBLDSC") == 0 ) && ( AV70Configuracion_sublineawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_sublineawwds_7_subldsc2)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like '%' + @lV71Configuracion_sublineawwds_7_subldsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV72Configuracion_sublineawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Configuracion_sublineawwds_9_dynamicfiltersselector3, "SUBLDSC") == 0 ) && ( AV74Configuracion_sublineawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_sublineawwds_11_subldsc3)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV75Configuracion_sublineawwds_11_subldsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV72Configuracion_sublineawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Configuracion_sublineawwds_9_dynamicfiltersselector3, "SUBLDSC") == 0 ) && ( AV74Configuracion_sublineawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_sublineawwds_11_subldsc3)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like '%' + @lV75Configuracion_sublineawwds_11_subldsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV76Configuracion_sublineawwds_12_tfsublcod) )
         {
            AddWhere(sWhereString, "([SublCod] >= @AV76Configuracion_sublineawwds_12_tfsublcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV77Configuracion_sublineawwds_13_tfsublcod_to) )
         {
            AddWhere(sWhereString, "([SublCod] <= @AV77Configuracion_sublineawwds_13_tfsublcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_sublineawwds_15_tfsubldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_sublineawwds_14_tfsubldsc)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV78Configuracion_sublineawwds_14_tfsubldsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_sublineawwds_15_tfsubldsc_sel)) )
         {
            AddWhere(sWhereString, "([SublDsc] = @AV79Configuracion_sublineawwds_15_tfsubldsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_sublineawwds_17_tfsublabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_sublineawwds_16_tfsublabr)) ) )
         {
            AddWhere(sWhereString, "([SublAbr] like @lV80Configuracion_sublineawwds_16_tfsublabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_sublineawwds_17_tfsublabr_sel)) )
         {
            AddWhere(sWhereString, "([SublAbr] = @AV81Configuracion_sublineawwds_17_tfsublabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV82Configuracion_sublineawwds_18_tfsublsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Configuracion_sublineawwds_18_tfsublsts_sels, "[SublSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [SublCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [SublCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [SublDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [SublDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [SublAbr]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [SublAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [SublSts]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [SublSts] DESC";
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
                     return conditional_P002U2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP002U2;
          prmP002U2 = new Object[] {
          new ParDef("@lV67Configuracion_sublineawwds_3_subldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_sublineawwds_3_subldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV71Configuracion_sublineawwds_7_subldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV71Configuracion_sublineawwds_7_subldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_sublineawwds_11_subldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_sublineawwds_11_subldsc3",GXType.NChar,100,0) ,
          new ParDef("@AV76Configuracion_sublineawwds_12_tfsublcod",GXType.Int32,6,0) ,
          new ParDef("@AV77Configuracion_sublineawwds_13_tfsublcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV78Configuracion_sublineawwds_14_tfsubldsc",GXType.NChar,100,0) ,
          new ParDef("@AV79Configuracion_sublineawwds_15_tfsubldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_sublineawwds_16_tfsublabr",GXType.NChar,5,0) ,
          new ParDef("@AV81Configuracion_sublineawwds_17_tfsublabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002U2,100, GxCacheFrequency.OFF ,true,false )
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
