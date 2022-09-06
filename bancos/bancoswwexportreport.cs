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
namespace GeneXus.Programs.bancos {
   public class bancoswwexportreport : GXWebProcedure
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

      public bancoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public bancoswwexportreport( IGxContext context )
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
         bancoswwexportreport objbancoswwexportreport;
         objbancoswwexportreport = new bancoswwexportreport();
         objbancoswwexportreport.context.SetSubmitInitialConfig(context);
         objbancoswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objbancoswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((bancoswwexportreport)stateInfo).executePrivate();
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
            AV52Title = "Lista de Bancos";
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
            H5B0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "BANDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV14BanDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14BanDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterBanDscDescription = StringUtil.Format( "%1 (%2)", "Banco", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterBanDscDescription = StringUtil.Format( "%1 (%2)", "Banco", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16BanDsc = AV14BanDsc1;
                  H5B0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterBanDscDescription, "")), 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16BanDsc, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "BANDSC") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV20BanDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20BanDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterBanDscDescription = StringUtil.Format( "%1 (%2)", "Banco", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterBanDscDescription = StringUtil.Format( "%1 (%2)", "Banco", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16BanDsc = AV20BanDsc2;
                     H5B0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterBanDscDescription, "")), 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16BanDsc, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "BANDSC") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV24BanDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24BanDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterBanDscDescription = StringUtil.Format( "%1 (%2)", "Banco", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterBanDscDescription = StringUtil.Format( "%1 (%2)", "Banco", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16BanDsc = AV24BanDsc3;
                        H5B0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterBanDscDescription, "")), 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16BanDsc, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV30TFBanCod) && (0==AV31TFBanCod_To) ) )
         {
            H5B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30TFBanCod), "ZZZZZ9")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV40TFBanCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H5B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFBanCod_To_Description, "")), 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFBanCod_To), "ZZZZZ9")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFBanDsc_Sel)) )
         {
            H5B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Banco", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFBanDsc_Sel, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFBanDsc)) )
            {
               H5B0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Banco", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFBanDsc, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFBanAbr_Sel)) )
         {
            H5B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFBanAbr_Sel, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFBanAbr)) )
            {
               H5B0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFBanAbr, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFBanSunat_Sel)) )
         {
            H5B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Sunat", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFBanSunat_Sel, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFBanSunat)) )
            {
               H5B0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo Sunat", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFBanSunat, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV36TFBanSts) && (0==AV37TFBanSts_To) ) )
         {
            H5B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36TFBanSts), "9")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV41TFBanSts_To_Description = StringUtil.Format( "%1 (%2)", "Estado", "Hasta", "", "", "", "", "", "", "");
            H5B0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFBanSts_To_Description, "")), 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37TFBanSts_To), "9")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H5B0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H5B0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 153, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Banco", 157, Gx_line+10, 403, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Abreviatura", 407, Gx_line+10, 531, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo Sunat", 535, Gx_line+10, 659, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 663, Gx_line+10, 787, Gx_line+27, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV66Bancos_bancoswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV67Bancos_bancoswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV68Bancos_bancoswwds_3_bandsc1 = AV14BanDsc1;
         AV69Bancos_bancoswwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV70Bancos_bancoswwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV71Bancos_bancoswwds_6_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV72Bancos_bancoswwds_7_bandsc2 = AV20BanDsc2;
         AV73Bancos_bancoswwds_8_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV74Bancos_bancoswwds_9_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV75Bancos_bancoswwds_10_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV76Bancos_bancoswwds_11_bandsc3 = AV24BanDsc3;
         AV77Bancos_bancoswwds_12_tfbancod = AV30TFBanCod;
         AV78Bancos_bancoswwds_13_tfbancod_to = AV31TFBanCod_To;
         AV79Bancos_bancoswwds_14_tfbandsc = AV32TFBanDsc;
         AV80Bancos_bancoswwds_15_tfbandsc_sel = AV33TFBanDsc_Sel;
         AV81Bancos_bancoswwds_16_tfbanabr = AV34TFBanAbr;
         AV82Bancos_bancoswwds_17_tfbanabr_sel = AV35TFBanAbr_Sel;
         AV83Bancos_bancoswwds_18_tfbansunat = AV38TFBanSunat;
         AV84Bancos_bancoswwds_19_tfbansunat_sel = AV39TFBanSunat_Sel;
         AV85Bancos_bancoswwds_20_tfbansts = AV36TFBanSts;
         AV86Bancos_bancoswwds_21_tfbansts_to = AV37TFBanSts_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV66Bancos_bancoswwds_1_dynamicfiltersselector1 ,
                                              AV67Bancos_bancoswwds_2_dynamicfiltersoperator1 ,
                                              AV68Bancos_bancoswwds_3_bandsc1 ,
                                              AV69Bancos_bancoswwds_4_dynamicfiltersenabled2 ,
                                              AV70Bancos_bancoswwds_5_dynamicfiltersselector2 ,
                                              AV71Bancos_bancoswwds_6_dynamicfiltersoperator2 ,
                                              AV72Bancos_bancoswwds_7_bandsc2 ,
                                              AV73Bancos_bancoswwds_8_dynamicfiltersenabled3 ,
                                              AV74Bancos_bancoswwds_9_dynamicfiltersselector3 ,
                                              AV75Bancos_bancoswwds_10_dynamicfiltersoperator3 ,
                                              AV76Bancos_bancoswwds_11_bandsc3 ,
                                              AV77Bancos_bancoswwds_12_tfbancod ,
                                              AV78Bancos_bancoswwds_13_tfbancod_to ,
                                              AV80Bancos_bancoswwds_15_tfbandsc_sel ,
                                              AV79Bancos_bancoswwds_14_tfbandsc ,
                                              AV82Bancos_bancoswwds_17_tfbanabr_sel ,
                                              AV81Bancos_bancoswwds_16_tfbanabr ,
                                              AV84Bancos_bancoswwds_19_tfbansunat_sel ,
                                              AV83Bancos_bancoswwds_18_tfbansunat ,
                                              AV85Bancos_bancoswwds_20_tfbansts ,
                                              AV86Bancos_bancoswwds_21_tfbansts_to ,
                                              A482BanDsc ,
                                              A372BanCod ,
                                              A481BanAbr ,
                                              A484BanSunat ,
                                              A483BanSts ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV68Bancos_bancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_bancoswwds_3_bandsc1), 100, "%");
         lV68Bancos_bancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_bancoswwds_3_bandsc1), 100, "%");
         lV72Bancos_bancoswwds_7_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_bancoswwds_7_bandsc2), 100, "%");
         lV72Bancos_bancoswwds_7_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_bancoswwds_7_bandsc2), 100, "%");
         lV76Bancos_bancoswwds_11_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_bancoswwds_11_bandsc3), 100, "%");
         lV76Bancos_bancoswwds_11_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_bancoswwds_11_bandsc3), 100, "%");
         lV79Bancos_bancoswwds_14_tfbandsc = StringUtil.PadR( StringUtil.RTrim( AV79Bancos_bancoswwds_14_tfbandsc), 100, "%");
         lV81Bancos_bancoswwds_16_tfbanabr = StringUtil.PadR( StringUtil.RTrim( AV81Bancos_bancoswwds_16_tfbanabr), 5, "%");
         lV83Bancos_bancoswwds_18_tfbansunat = StringUtil.PadR( StringUtil.RTrim( AV83Bancos_bancoswwds_18_tfbansunat), 5, "%");
         /* Using cursor P005B2 */
         pr_default.execute(0, new Object[] {lV68Bancos_bancoswwds_3_bandsc1, lV68Bancos_bancoswwds_3_bandsc1, lV72Bancos_bancoswwds_7_bandsc2, lV72Bancos_bancoswwds_7_bandsc2, lV76Bancos_bancoswwds_11_bandsc3, lV76Bancos_bancoswwds_11_bandsc3, AV77Bancos_bancoswwds_12_tfbancod, AV78Bancos_bancoswwds_13_tfbancod_to, lV79Bancos_bancoswwds_14_tfbandsc, AV80Bancos_bancoswwds_15_tfbandsc_sel, lV81Bancos_bancoswwds_16_tfbanabr, AV82Bancos_bancoswwds_17_tfbanabr_sel, lV83Bancos_bancoswwds_18_tfbansunat, AV84Bancos_bancoswwds_19_tfbansunat_sel, AV85Bancos_bancoswwds_20_tfbansts, AV86Bancos_bancoswwds_21_tfbansts_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A483BanSts = P005B2_A483BanSts[0];
            A484BanSunat = P005B2_A484BanSunat[0];
            A481BanAbr = P005B2_A481BanAbr[0];
            A372BanCod = P005B2_A372BanCod[0];
            A482BanDsc = P005B2_A482BanDsc[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H5B0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A372BanCod), "ZZZZZ9")), 30, Gx_line+10, 153, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A482BanDsc, "")), 157, Gx_line+10, 403, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A481BanAbr, "")), 407, Gx_line+10, 531, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A484BanSunat, "")), 535, Gx_line+10, 659, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A483BanSts), "9")), 663, Gx_line+10, 787, Gx_line+25, 2, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Bancos.BancosWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.BancosWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Bancos.BancosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV87GXV1 = 1;
         while ( AV87GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV87GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFBANCOD") == 0 )
            {
               AV30TFBanCod = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV31TFBanCod_To = (int)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFBANDSC") == 0 )
            {
               AV32TFBanDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFBANDSC_SEL") == 0 )
            {
               AV33TFBanDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFBANABR") == 0 )
            {
               AV34TFBanAbr = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFBANABR_SEL") == 0 )
            {
               AV35TFBanAbr_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFBANSUNAT") == 0 )
            {
               AV38TFBanSunat = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFBANSUNAT_SEL") == 0 )
            {
               AV39TFBanSunat_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFBANSTS") == 0 )
            {
               AV36TFBanSts = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV37TFBanSts_To = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV87GXV1 = (int)(AV87GXV1+1);
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

      protected void H5B0( bool bFoot ,
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
         AV14BanDsc1 = "";
         AV15FilterBanDscDescription = "";
         AV16BanDsc = "";
         AV18DynamicFiltersSelector2 = "";
         AV20BanDsc2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV24BanDsc3 = "";
         AV40TFBanCod_To_Description = "";
         AV33TFBanDsc_Sel = "";
         AV32TFBanDsc = "";
         AV35TFBanAbr_Sel = "";
         AV34TFBanAbr = "";
         AV39TFBanSunat_Sel = "";
         AV38TFBanSunat = "";
         AV41TFBanSts_To_Description = "";
         AV66Bancos_bancoswwds_1_dynamicfiltersselector1 = "";
         AV68Bancos_bancoswwds_3_bandsc1 = "";
         AV70Bancos_bancoswwds_5_dynamicfiltersselector2 = "";
         AV72Bancos_bancoswwds_7_bandsc2 = "";
         AV74Bancos_bancoswwds_9_dynamicfiltersselector3 = "";
         AV76Bancos_bancoswwds_11_bandsc3 = "";
         AV79Bancos_bancoswwds_14_tfbandsc = "";
         AV80Bancos_bancoswwds_15_tfbandsc_sel = "";
         AV81Bancos_bancoswwds_16_tfbanabr = "";
         AV82Bancos_bancoswwds_17_tfbanabr_sel = "";
         AV83Bancos_bancoswwds_18_tfbansunat = "";
         AV84Bancos_bancoswwds_19_tfbansunat_sel = "";
         scmdbuf = "";
         lV68Bancos_bancoswwds_3_bandsc1 = "";
         lV72Bancos_bancoswwds_7_bandsc2 = "";
         lV76Bancos_bancoswwds_11_bandsc3 = "";
         lV79Bancos_bancoswwds_14_tfbandsc = "";
         lV81Bancos_bancoswwds_16_tfbanabr = "";
         lV83Bancos_bancoswwds_18_tfbansunat = "";
         A482BanDsc = "";
         A481BanAbr = "";
         A484BanSunat = "";
         P005B2_A483BanSts = new short[1] ;
         P005B2_A484BanSunat = new string[] {""} ;
         P005B2_A481BanAbr = new string[] {""} ;
         P005B2_A372BanCod = new int[1] ;
         P005B2_A482BanDsc = new string[] {""} ;
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.bancoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P005B2_A483BanSts, P005B2_A484BanSunat, P005B2_A481BanAbr, P005B2_A372BanCod, P005B2_A482BanDsc
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
      private short AV36TFBanSts ;
      private short AV37TFBanSts_To ;
      private short AV67Bancos_bancoswwds_2_dynamicfiltersoperator1 ;
      private short AV71Bancos_bancoswwds_6_dynamicfiltersoperator2 ;
      private short AV75Bancos_bancoswwds_10_dynamicfiltersoperator3 ;
      private short AV85Bancos_bancoswwds_20_tfbansts ;
      private short AV86Bancos_bancoswwds_21_tfbansts_to ;
      private short A483BanSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV30TFBanCod ;
      private int AV31TFBanCod_To ;
      private int AV77Bancos_bancoswwds_12_tfbancod ;
      private int AV78Bancos_bancoswwds_13_tfbancod_to ;
      private int A372BanCod ;
      private int AV87GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14BanDsc1 ;
      private string AV16BanDsc ;
      private string AV20BanDsc2 ;
      private string AV24BanDsc3 ;
      private string AV33TFBanDsc_Sel ;
      private string AV32TFBanDsc ;
      private string AV35TFBanAbr_Sel ;
      private string AV34TFBanAbr ;
      private string AV39TFBanSunat_Sel ;
      private string AV38TFBanSunat ;
      private string AV68Bancos_bancoswwds_3_bandsc1 ;
      private string AV72Bancos_bancoswwds_7_bandsc2 ;
      private string AV76Bancos_bancoswwds_11_bandsc3 ;
      private string AV79Bancos_bancoswwds_14_tfbandsc ;
      private string AV80Bancos_bancoswwds_15_tfbandsc_sel ;
      private string AV81Bancos_bancoswwds_16_tfbanabr ;
      private string AV82Bancos_bancoswwds_17_tfbanabr_sel ;
      private string AV83Bancos_bancoswwds_18_tfbansunat ;
      private string AV84Bancos_bancoswwds_19_tfbansunat_sel ;
      private string scmdbuf ;
      private string lV68Bancos_bancoswwds_3_bandsc1 ;
      private string lV72Bancos_bancoswwds_7_bandsc2 ;
      private string lV76Bancos_bancoswwds_11_bandsc3 ;
      private string lV79Bancos_bancoswwds_14_tfbandsc ;
      private string lV81Bancos_bancoswwds_16_tfbanabr ;
      private string lV83Bancos_bancoswwds_18_tfbansunat ;
      private string A482BanDsc ;
      private string A481BanAbr ;
      private string A484BanSunat ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV69Bancos_bancoswwds_4_dynamicfiltersenabled2 ;
      private bool AV73Bancos_bancoswwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV52Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterBanDscDescription ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV40TFBanCod_To_Description ;
      private string AV41TFBanSts_To_Description ;
      private string AV66Bancos_bancoswwds_1_dynamicfiltersselector1 ;
      private string AV70Bancos_bancoswwds_5_dynamicfiltersselector2 ;
      private string AV74Bancos_bancoswwds_9_dynamicfiltersselector3 ;
      private string AV50PageInfo ;
      private string AV47DateInfo ;
      private string AV45AppName ;
      private string AV51Phone ;
      private string AV49Mail ;
      private string AV53Website ;
      private string AV42AddressLine1 ;
      private string AV43AddressLine2 ;
      private string AV44AddressLine3 ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005B2_A483BanSts ;
      private string[] P005B2_A484BanSunat ;
      private string[] P005B2_A481BanAbr ;
      private int[] P005B2_A372BanCod ;
      private string[] P005B2_A482BanDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class bancoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005B2( IGxContext context ,
                                             string AV66Bancos_bancoswwds_1_dynamicfiltersselector1 ,
                                             short AV67Bancos_bancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV68Bancos_bancoswwds_3_bandsc1 ,
                                             bool AV69Bancos_bancoswwds_4_dynamicfiltersenabled2 ,
                                             string AV70Bancos_bancoswwds_5_dynamicfiltersselector2 ,
                                             short AV71Bancos_bancoswwds_6_dynamicfiltersoperator2 ,
                                             string AV72Bancos_bancoswwds_7_bandsc2 ,
                                             bool AV73Bancos_bancoswwds_8_dynamicfiltersenabled3 ,
                                             string AV74Bancos_bancoswwds_9_dynamicfiltersselector3 ,
                                             short AV75Bancos_bancoswwds_10_dynamicfiltersoperator3 ,
                                             string AV76Bancos_bancoswwds_11_bandsc3 ,
                                             int AV77Bancos_bancoswwds_12_tfbancod ,
                                             int AV78Bancos_bancoswwds_13_tfbancod_to ,
                                             string AV80Bancos_bancoswwds_15_tfbandsc_sel ,
                                             string AV79Bancos_bancoswwds_14_tfbandsc ,
                                             string AV82Bancos_bancoswwds_17_tfbanabr_sel ,
                                             string AV81Bancos_bancoswwds_16_tfbanabr ,
                                             string AV84Bancos_bancoswwds_19_tfbansunat_sel ,
                                             string AV83Bancos_bancoswwds_18_tfbansunat ,
                                             short AV85Bancos_bancoswwds_20_tfbansts ,
                                             short AV86Bancos_bancoswwds_21_tfbansts_to ,
                                             string A482BanDsc ,
                                             int A372BanCod ,
                                             string A481BanAbr ,
                                             string A484BanSunat ,
                                             short A483BanSts ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [BanSts], [BanSunat], [BanAbr], [BanCod], [BanDsc] FROM [TSBANCOS]";
         if ( ( StringUtil.StrCmp(AV66Bancos_bancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV67Bancos_bancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_bancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV68Bancos_bancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Bancos_bancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV67Bancos_bancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_bancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV68Bancos_bancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV69Bancos_bancoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Bancos_bancoswwds_5_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV71Bancos_bancoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_bancoswwds_7_bandsc2)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV72Bancos_bancoswwds_7_bandsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV69Bancos_bancoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Bancos_bancoswwds_5_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV71Bancos_bancoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_bancoswwds_7_bandsc2)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV72Bancos_bancoswwds_7_bandsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV73Bancos_bancoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Bancos_bancoswwds_9_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV75Bancos_bancoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_bancoswwds_11_bandsc3)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV76Bancos_bancoswwds_11_bandsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV73Bancos_bancoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Bancos_bancoswwds_9_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV75Bancos_bancoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_bancoswwds_11_bandsc3)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV76Bancos_bancoswwds_11_bandsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV77Bancos_bancoswwds_12_tfbancod) )
         {
            AddWhere(sWhereString, "([BanCod] >= @AV77Bancos_bancoswwds_12_tfbancod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV78Bancos_bancoswwds_13_tfbancod_to) )
         {
            AddWhere(sWhereString, "([BanCod] <= @AV78Bancos_bancoswwds_13_tfbancod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_bancoswwds_15_tfbandsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_bancoswwds_14_tfbandsc)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV79Bancos_bancoswwds_14_tfbandsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_bancoswwds_15_tfbandsc_sel)) )
         {
            AddWhere(sWhereString, "([BanDsc] = @AV80Bancos_bancoswwds_15_tfbandsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_bancoswwds_17_tfbanabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Bancos_bancoswwds_16_tfbanabr)) ) )
         {
            AddWhere(sWhereString, "([BanAbr] like @lV81Bancos_bancoswwds_16_tfbanabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_bancoswwds_17_tfbanabr_sel)) )
         {
            AddWhere(sWhereString, "([BanAbr] = @AV82Bancos_bancoswwds_17_tfbanabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Bancos_bancoswwds_19_tfbansunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Bancos_bancoswwds_18_tfbansunat)) ) )
         {
            AddWhere(sWhereString, "([BanSunat] like @lV83Bancos_bancoswwds_18_tfbansunat)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Bancos_bancoswwds_19_tfbansunat_sel)) )
         {
            AddWhere(sWhereString, "([BanSunat] = @AV84Bancos_bancoswwds_19_tfbansunat_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (0==AV85Bancos_bancoswwds_20_tfbansts) )
         {
            AddWhere(sWhereString, "([BanSts] >= @AV85Bancos_bancoswwds_20_tfbansts)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (0==AV86Bancos_bancoswwds_21_tfbansts_to) )
         {
            AddWhere(sWhereString, "([BanSts] <= @AV86Bancos_bancoswwds_21_tfbansts_to)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [BanCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [BanCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [BanDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [BanDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [BanAbr]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [BanAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [BanSunat]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [BanSunat] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [BanSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [BanSts] DESC";
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
                     return conditional_P005B2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP005B2;
          prmP005B2 = new Object[] {
          new ParDef("@lV68Bancos_bancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV68Bancos_bancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV72Bancos_bancoswwds_7_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV72Bancos_bancoswwds_7_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV76Bancos_bancoswwds_11_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@lV76Bancos_bancoswwds_11_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@AV77Bancos_bancoswwds_12_tfbancod",GXType.Int32,6,0) ,
          new ParDef("@AV78Bancos_bancoswwds_13_tfbancod_to",GXType.Int32,6,0) ,
          new ParDef("@lV79Bancos_bancoswwds_14_tfbandsc",GXType.NChar,100,0) ,
          new ParDef("@AV80Bancos_bancoswwds_15_tfbandsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV81Bancos_bancoswwds_16_tfbanabr",GXType.NChar,5,0) ,
          new ParDef("@AV82Bancos_bancoswwds_17_tfbanabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV83Bancos_bancoswwds_18_tfbansunat",GXType.NChar,5,0) ,
          new ParDef("@AV84Bancos_bancoswwds_19_tfbansunat_sel",GXType.NChar,5,0) ,
          new ParDef("@AV85Bancos_bancoswwds_20_tfbansts",GXType.Int16,1,0) ,
          new ParDef("@AV86Bancos_bancoswwds_21_tfbansts_to",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005B2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
