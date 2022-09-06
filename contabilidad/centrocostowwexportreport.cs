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
   public class centrocostowwexportreport : GXWebProcedure
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

      public centrocostowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public centrocostowwexportreport( IGxContext context )
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
         centrocostowwexportreport objcentrocostowwexportreport;
         objcentrocostowwexportreport = new centrocostowwexportreport();
         objcentrocostowwexportreport.context.SetSubmitInitialConfig(context);
         objcentrocostowwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcentrocostowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((centrocostowwexportreport)stateInfo).executePrivate();
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
            AV58Title = "Lista de Centros de Costos";
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
            H6T0( true, 0) ;
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
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV12DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "COSDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV14COSDsc1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14COSDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterCOSDscDescription = StringUtil.Format( "%1 (%2)", "Centro de Costos", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterCOSDscDescription = StringUtil.Format( "%1 (%2)", "Centro de Costos", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16COSDsc = AV14COSDsc1;
                  H6T0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCOSDscDescription, "")), 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16COSDsc, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "COSCOD") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV61COSCod1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61COSCod1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV62FilterCOSCodDescription = StringUtil.Format( "%1 (%2)", "Codigo Centro Costo", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV62FilterCOSCodDescription = StringUtil.Format( "%1 (%2)", "Codigo Centro Costo", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV63COSCod = AV61COSCod1;
                  H6T0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62FilterCOSCodDescription, "")), 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63COSCod, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV20DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "COSDSC") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV23COSDsc2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23COSDsc2)) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterCOSDscDescription = StringUtil.Format( "%1 (%2)", "Centro de Costos", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterCOSDscDescription = StringUtil.Format( "%1 (%2)", "Centro de Costos", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16COSDsc = AV23COSDsc2;
                     H6T0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCOSDscDescription, "")), 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16COSDsc, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "COSCOD") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV64COSCod2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64COSCod2)) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV62FilterCOSCodDescription = StringUtil.Format( "%1 (%2)", "Codigo Centro Costo", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV62FilterCOSCodDescription = StringUtil.Format( "%1 (%2)", "Codigo Centro Costo", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV63COSCod = AV64COSCod2;
                     H6T0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62FilterCOSCodDescription, "")), 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63COSCod, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "COSDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV28COSDsc3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28COSDsc3)) )
                     {
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterCOSDscDescription = StringUtil.Format( "%1 (%2)", "Centro de Costos", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterCOSDscDescription = StringUtil.Format( "%1 (%2)", "Centro de Costos", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16COSDsc = AV28COSDsc3;
                        H6T0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCOSDscDescription, "")), 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16COSDsc, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "COSCOD") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV65COSCod3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65COSCod3)) )
                     {
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV62FilterCOSCodDescription = StringUtil.Format( "%1 (%2)", "Codigo Centro Costo", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV62FilterCOSCodDescription = StringUtil.Format( "%1 (%2)", "Codigo Centro Costo", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV63COSCod = AV65COSCod3;
                        H6T0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62FilterCOSCodDescription, "")), 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63COSCod, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCOSCod_Sel)) )
         {
            H6T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFCOSCod_Sel, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCOSCod)) )
            {
               H6T0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFCOSCod, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCOSDsc_Sel)) )
         {
            H6T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Centro de Costos", 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFCOSDsc_Sel, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCOSDsc)) )
            {
               H6T0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Centro de Costos", 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFCOSDsc, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCOSAbr_Sel)) )
         {
            H6T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFCOSAbr_Sel, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCOSAbr)) )
            {
               H6T0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFCOSAbr, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCOSCueDestino_Sel)) )
         {
            H6T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFCOSCueDestino_Sel, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFCOSCueDestino)) )
            {
               H6T0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFCOSCueDestino, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV68TFCOSSts_Sels.FromJSonString(AV66TFCOSSts_SelsJson, null);
         if ( ! ( AV68TFCOSSts_Sels.Count == 0 ) )
         {
            AV71i = 1;
            AV76GXV1 = 1;
            while ( AV76GXV1 <= AV68TFCOSSts_Sels.Count )
            {
               AV69TFCOSSts_Sel = (short)(AV68TFCOSSts_Sels.GetNumeric(AV76GXV1));
               if ( AV71i == 1 )
               {
                  AV67TFCOSSts_SelDscs = "";
               }
               else
               {
                  AV67TFCOSSts_SelDscs += ", ";
               }
               if ( AV69TFCOSSts_Sel == 1 )
               {
                  AV70FilterTFCOSSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV69TFCOSSts_Sel == 0 )
               {
                  AV70FilterTFCOSSts_SelValueDescription = "INACTIVO";
               }
               AV67TFCOSSts_SelDscs += AV70FilterTFCOSSts_SelValueDescription;
               AV71i = (long)(AV71i+1);
               AV76GXV1 = (int)(AV76GXV1+1);
            }
            H6T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 245, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TFCOSSts_SelDscs, "")), 245, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6T0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6T0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 135, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Centro de Costos", 139, Gx_line+10, 351, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Abreviatura", 355, Gx_line+10, 461, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Cuenta Contable", 465, Gx_line+10, 571, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 575, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV78Contabilidad_centrocostowwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV79Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV80Contabilidad_centrocostowwds_3_cosdsc1 = AV14COSDsc1;
         AV81Contabilidad_centrocostowwds_4_coscod1 = AV61COSCod1;
         AV82Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV83Contabilidad_centrocostowwds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV84Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV85Contabilidad_centrocostowwds_8_cosdsc2 = AV23COSDsc2;
         AV86Contabilidad_centrocostowwds_9_coscod2 = AV64COSCod2;
         AV87Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV88Contabilidad_centrocostowwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV89Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV90Contabilidad_centrocostowwds_13_cosdsc3 = AV28COSDsc3;
         AV91Contabilidad_centrocostowwds_14_coscod3 = AV65COSCod3;
         AV92Contabilidad_centrocostowwds_15_tfcoscod = AV35TFCOSCod;
         AV93Contabilidad_centrocostowwds_16_tfcoscod_sel = AV36TFCOSCod_Sel;
         AV94Contabilidad_centrocostowwds_17_tfcosdsc = AV37TFCOSDsc;
         AV95Contabilidad_centrocostowwds_18_tfcosdsc_sel = AV38TFCOSDsc_Sel;
         AV96Contabilidad_centrocostowwds_19_tfcosabr = AV39TFCOSAbr;
         AV97Contabilidad_centrocostowwds_20_tfcosabr_sel = AV40TFCOSAbr_Sel;
         AV98Contabilidad_centrocostowwds_21_tfcoscuedestino = AV43TFCOSCueDestino;
         AV99Contabilidad_centrocostowwds_22_tfcoscuedestino_sel = AV44TFCOSCueDestino_Sel;
         AV100Contabilidad_centrocostowwds_23_tfcossts_sels = AV68TFCOSSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A762COSSts ,
                                              AV100Contabilidad_centrocostowwds_23_tfcossts_sels ,
                                              AV78Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ,
                                              AV79Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ,
                                              AV80Contabilidad_centrocostowwds_3_cosdsc1 ,
                                              AV81Contabilidad_centrocostowwds_4_coscod1 ,
                                              AV82Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ,
                                              AV83Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ,
                                              AV84Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ,
                                              AV85Contabilidad_centrocostowwds_8_cosdsc2 ,
                                              AV86Contabilidad_centrocostowwds_9_coscod2 ,
                                              AV87Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ,
                                              AV88Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ,
                                              AV89Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ,
                                              AV90Contabilidad_centrocostowwds_13_cosdsc3 ,
                                              AV91Contabilidad_centrocostowwds_14_coscod3 ,
                                              AV93Contabilidad_centrocostowwds_16_tfcoscod_sel ,
                                              AV92Contabilidad_centrocostowwds_15_tfcoscod ,
                                              AV95Contabilidad_centrocostowwds_18_tfcosdsc_sel ,
                                              AV94Contabilidad_centrocostowwds_17_tfcosdsc ,
                                              AV97Contabilidad_centrocostowwds_20_tfcosabr_sel ,
                                              AV96Contabilidad_centrocostowwds_19_tfcosabr ,
                                              AV99Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ,
                                              AV98Contabilidad_centrocostowwds_21_tfcoscuedestino ,
                                              AV100Contabilidad_centrocostowwds_23_tfcossts_sels.Count ,
                                              A761COSDsc ,
                                              A79COSCod ,
                                              A759COSAbr ,
                                              A80COSCueDestino ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV80Contabilidad_centrocostowwds_3_cosdsc1 = StringUtil.PadR( StringUtil.RTrim( AV80Contabilidad_centrocostowwds_3_cosdsc1), 100, "%");
         lV80Contabilidad_centrocostowwds_3_cosdsc1 = StringUtil.PadR( StringUtil.RTrim( AV80Contabilidad_centrocostowwds_3_cosdsc1), 100, "%");
         lV81Contabilidad_centrocostowwds_4_coscod1 = StringUtil.PadR( StringUtil.RTrim( AV81Contabilidad_centrocostowwds_4_coscod1), 10, "%");
         lV81Contabilidad_centrocostowwds_4_coscod1 = StringUtil.PadR( StringUtil.RTrim( AV81Contabilidad_centrocostowwds_4_coscod1), 10, "%");
         lV85Contabilidad_centrocostowwds_8_cosdsc2 = StringUtil.PadR( StringUtil.RTrim( AV85Contabilidad_centrocostowwds_8_cosdsc2), 100, "%");
         lV85Contabilidad_centrocostowwds_8_cosdsc2 = StringUtil.PadR( StringUtil.RTrim( AV85Contabilidad_centrocostowwds_8_cosdsc2), 100, "%");
         lV86Contabilidad_centrocostowwds_9_coscod2 = StringUtil.PadR( StringUtil.RTrim( AV86Contabilidad_centrocostowwds_9_coscod2), 10, "%");
         lV86Contabilidad_centrocostowwds_9_coscod2 = StringUtil.PadR( StringUtil.RTrim( AV86Contabilidad_centrocostowwds_9_coscod2), 10, "%");
         lV90Contabilidad_centrocostowwds_13_cosdsc3 = StringUtil.PadR( StringUtil.RTrim( AV90Contabilidad_centrocostowwds_13_cosdsc3), 100, "%");
         lV90Contabilidad_centrocostowwds_13_cosdsc3 = StringUtil.PadR( StringUtil.RTrim( AV90Contabilidad_centrocostowwds_13_cosdsc3), 100, "%");
         lV91Contabilidad_centrocostowwds_14_coscod3 = StringUtil.PadR( StringUtil.RTrim( AV91Contabilidad_centrocostowwds_14_coscod3), 10, "%");
         lV91Contabilidad_centrocostowwds_14_coscod3 = StringUtil.PadR( StringUtil.RTrim( AV91Contabilidad_centrocostowwds_14_coscod3), 10, "%");
         lV92Contabilidad_centrocostowwds_15_tfcoscod = StringUtil.PadR( StringUtil.RTrim( AV92Contabilidad_centrocostowwds_15_tfcoscod), 10, "%");
         lV94Contabilidad_centrocostowwds_17_tfcosdsc = StringUtil.PadR( StringUtil.RTrim( AV94Contabilidad_centrocostowwds_17_tfcosdsc), 100, "%");
         lV96Contabilidad_centrocostowwds_19_tfcosabr = StringUtil.PadR( StringUtil.RTrim( AV96Contabilidad_centrocostowwds_19_tfcosabr), 5, "%");
         lV98Contabilidad_centrocostowwds_21_tfcoscuedestino = StringUtil.PadR( StringUtil.RTrim( AV98Contabilidad_centrocostowwds_21_tfcoscuedestino), 15, "%");
         /* Using cursor P006T2 */
         pr_default.execute(0, new Object[] {lV80Contabilidad_centrocostowwds_3_cosdsc1, lV80Contabilidad_centrocostowwds_3_cosdsc1, lV81Contabilidad_centrocostowwds_4_coscod1, lV81Contabilidad_centrocostowwds_4_coscod1, lV85Contabilidad_centrocostowwds_8_cosdsc2, lV85Contabilidad_centrocostowwds_8_cosdsc2, lV86Contabilidad_centrocostowwds_9_coscod2, lV86Contabilidad_centrocostowwds_9_coscod2, lV90Contabilidad_centrocostowwds_13_cosdsc3, lV90Contabilidad_centrocostowwds_13_cosdsc3, lV91Contabilidad_centrocostowwds_14_coscod3, lV91Contabilidad_centrocostowwds_14_coscod3, lV92Contabilidad_centrocostowwds_15_tfcoscod, AV93Contabilidad_centrocostowwds_16_tfcoscod_sel, lV94Contabilidad_centrocostowwds_17_tfcosdsc, AV95Contabilidad_centrocostowwds_18_tfcosdsc_sel, lV96Contabilidad_centrocostowwds_19_tfcosabr, AV97Contabilidad_centrocostowwds_20_tfcosabr_sel, lV98Contabilidad_centrocostowwds_21_tfcoscuedestino, AV99Contabilidad_centrocostowwds_22_tfcoscuedestino_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A762COSSts = P006T2_A762COSSts[0];
            A80COSCueDestino = P006T2_A80COSCueDestino[0];
            n80COSCueDestino = P006T2_n80COSCueDestino[0];
            A759COSAbr = P006T2_A759COSAbr[0];
            A79COSCod = P006T2_A79COSCod[0];
            A761COSDsc = P006T2_A761COSDsc[0];
            if ( A762COSSts == 1 )
            {
               AV60COSStsDescription = "ACTIVO";
            }
            else if ( A762COSSts == 0 )
            {
               AV60COSStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6T0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A79COSCod, "")), 30, Gx_line+10, 135, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A761COSDsc, "")), 139, Gx_line+10, 351, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A759COSAbr, "")), 355, Gx_line+10, 461, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A80COSCueDestino, "")), 465, Gx_line+10, 571, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60COSStsDescription, "")), 575, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV31Session.Get("Contabilidad.CentroCostoWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.CentroCostoWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Contabilidad.CentroCostoWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV101GXV2 = 1;
         while ( AV101GXV2 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV101GXV2));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCOSCOD") == 0 )
            {
               AV35TFCOSCod = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCOSCOD_SEL") == 0 )
            {
               AV36TFCOSCod_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCOSDSC") == 0 )
            {
               AV37TFCOSDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCOSDSC_SEL") == 0 )
            {
               AV38TFCOSDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCOSABR") == 0 )
            {
               AV39TFCOSAbr = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCOSABR_SEL") == 0 )
            {
               AV40TFCOSAbr_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCOSCUEDESTINO") == 0 )
            {
               AV43TFCOSCueDestino = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCOSCUEDESTINO_SEL") == 0 )
            {
               AV44TFCOSCueDestino_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCOSSTS_SEL") == 0 )
            {
               AV66TFCOSSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV68TFCOSSts_Sels.FromJSonString(AV66TFCOSSts_SelsJson, null);
            }
            AV101GXV2 = (int)(AV101GXV2+1);
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

      protected void H6T0( bool bFoot ,
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
                  AV56PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV53DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV51AppName = "DVelop Software Solutions";
               AV57Phone = "+1 550 8923";
               AV55Mail = "info@mail.com";
               AV59Website = "http://www.web.com";
               AV48AddressLine1 = "French Boulevard 2859";
               AV49AddressLine2 = "Downtown";
               AV50AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV58Title = "";
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14COSDsc1 = "";
         AV15FilterCOSDscDescription = "";
         AV16COSDsc = "";
         AV61COSCod1 = "";
         AV62FilterCOSCodDescription = "";
         AV63COSCod = "";
         AV21DynamicFiltersSelector2 = "";
         AV23COSDsc2 = "";
         AV64COSCod2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28COSDsc3 = "";
         AV65COSCod3 = "";
         AV36TFCOSCod_Sel = "";
         AV35TFCOSCod = "";
         AV38TFCOSDsc_Sel = "";
         AV37TFCOSDsc = "";
         AV40TFCOSAbr_Sel = "";
         AV39TFCOSAbr = "";
         AV44TFCOSCueDestino_Sel = "";
         AV43TFCOSCueDestino = "";
         AV68TFCOSSts_Sels = new GxSimpleCollection<short>();
         AV66TFCOSSts_SelsJson = "";
         AV67TFCOSSts_SelDscs = "";
         AV70FilterTFCOSSts_SelValueDescription = "";
         AV78Contabilidad_centrocostowwds_1_dynamicfiltersselector1 = "";
         AV80Contabilidad_centrocostowwds_3_cosdsc1 = "";
         AV81Contabilidad_centrocostowwds_4_coscod1 = "";
         AV83Contabilidad_centrocostowwds_6_dynamicfiltersselector2 = "";
         AV85Contabilidad_centrocostowwds_8_cosdsc2 = "";
         AV86Contabilidad_centrocostowwds_9_coscod2 = "";
         AV88Contabilidad_centrocostowwds_11_dynamicfiltersselector3 = "";
         AV90Contabilidad_centrocostowwds_13_cosdsc3 = "";
         AV91Contabilidad_centrocostowwds_14_coscod3 = "";
         AV92Contabilidad_centrocostowwds_15_tfcoscod = "";
         AV93Contabilidad_centrocostowwds_16_tfcoscod_sel = "";
         AV94Contabilidad_centrocostowwds_17_tfcosdsc = "";
         AV95Contabilidad_centrocostowwds_18_tfcosdsc_sel = "";
         AV96Contabilidad_centrocostowwds_19_tfcosabr = "";
         AV97Contabilidad_centrocostowwds_20_tfcosabr_sel = "";
         AV98Contabilidad_centrocostowwds_21_tfcoscuedestino = "";
         AV99Contabilidad_centrocostowwds_22_tfcoscuedestino_sel = "";
         AV100Contabilidad_centrocostowwds_23_tfcossts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV80Contabilidad_centrocostowwds_3_cosdsc1 = "";
         lV81Contabilidad_centrocostowwds_4_coscod1 = "";
         lV85Contabilidad_centrocostowwds_8_cosdsc2 = "";
         lV86Contabilidad_centrocostowwds_9_coscod2 = "";
         lV90Contabilidad_centrocostowwds_13_cosdsc3 = "";
         lV91Contabilidad_centrocostowwds_14_coscod3 = "";
         lV92Contabilidad_centrocostowwds_15_tfcoscod = "";
         lV94Contabilidad_centrocostowwds_17_tfcosdsc = "";
         lV96Contabilidad_centrocostowwds_19_tfcosabr = "";
         lV98Contabilidad_centrocostowwds_21_tfcoscuedestino = "";
         A761COSDsc = "";
         A79COSCod = "";
         A759COSAbr = "";
         A80COSCueDestino = "";
         P006T2_A762COSSts = new short[1] ;
         P006T2_A80COSCueDestino = new string[] {""} ;
         P006T2_n80COSCueDestino = new bool[] {false} ;
         P006T2_A759COSAbr = new string[] {""} ;
         P006T2_A79COSCod = new string[] {""} ;
         P006T2_A761COSDsc = new string[] {""} ;
         AV60COSStsDescription = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV56PageInfo = "";
         AV53DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV51AppName = "";
         AV57Phone = "";
         AV55Mail = "";
         AV59Website = "";
         AV48AddressLine1 = "";
         AV49AddressLine2 = "";
         AV50AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.centrocostowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006T2_A762COSSts, P006T2_A80COSCueDestino, P006T2_n80COSCueDestino, P006T2_A759COSAbr, P006T2_A79COSCod, P006T2_A761COSDsc
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
      private short AV22DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV69TFCOSSts_Sel ;
      private short AV79Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ;
      private short AV84Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ;
      private short AV89Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ;
      private short A762COSSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV76GXV1 ;
      private int AV100Contabilidad_centrocostowwds_23_tfcossts_sels_Count ;
      private int AV101GXV2 ;
      private long AV71i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14COSDsc1 ;
      private string AV16COSDsc ;
      private string AV61COSCod1 ;
      private string AV63COSCod ;
      private string AV23COSDsc2 ;
      private string AV64COSCod2 ;
      private string AV28COSDsc3 ;
      private string AV65COSCod3 ;
      private string AV36TFCOSCod_Sel ;
      private string AV35TFCOSCod ;
      private string AV38TFCOSDsc_Sel ;
      private string AV37TFCOSDsc ;
      private string AV40TFCOSAbr_Sel ;
      private string AV39TFCOSAbr ;
      private string AV44TFCOSCueDestino_Sel ;
      private string AV43TFCOSCueDestino ;
      private string AV80Contabilidad_centrocostowwds_3_cosdsc1 ;
      private string AV81Contabilidad_centrocostowwds_4_coscod1 ;
      private string AV85Contabilidad_centrocostowwds_8_cosdsc2 ;
      private string AV86Contabilidad_centrocostowwds_9_coscod2 ;
      private string AV90Contabilidad_centrocostowwds_13_cosdsc3 ;
      private string AV91Contabilidad_centrocostowwds_14_coscod3 ;
      private string AV92Contabilidad_centrocostowwds_15_tfcoscod ;
      private string AV93Contabilidad_centrocostowwds_16_tfcoscod_sel ;
      private string AV94Contabilidad_centrocostowwds_17_tfcosdsc ;
      private string AV95Contabilidad_centrocostowwds_18_tfcosdsc_sel ;
      private string AV96Contabilidad_centrocostowwds_19_tfcosabr ;
      private string AV97Contabilidad_centrocostowwds_20_tfcosabr_sel ;
      private string AV98Contabilidad_centrocostowwds_21_tfcoscuedestino ;
      private string AV99Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ;
      private string scmdbuf ;
      private string lV80Contabilidad_centrocostowwds_3_cosdsc1 ;
      private string lV81Contabilidad_centrocostowwds_4_coscod1 ;
      private string lV85Contabilidad_centrocostowwds_8_cosdsc2 ;
      private string lV86Contabilidad_centrocostowwds_9_coscod2 ;
      private string lV90Contabilidad_centrocostowwds_13_cosdsc3 ;
      private string lV91Contabilidad_centrocostowwds_14_coscod3 ;
      private string lV92Contabilidad_centrocostowwds_15_tfcoscod ;
      private string lV94Contabilidad_centrocostowwds_17_tfcosdsc ;
      private string lV96Contabilidad_centrocostowwds_19_tfcosabr ;
      private string lV98Contabilidad_centrocostowwds_21_tfcoscuedestino ;
      private string A761COSDsc ;
      private string A79COSCod ;
      private string A759COSAbr ;
      private string A80COSCueDestino ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV82Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ;
      private bool AV87Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private bool n80COSCueDestino ;
      private string AV66TFCOSSts_SelsJson ;
      private string AV58Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterCOSDscDescription ;
      private string AV62FilterCOSCodDescription ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV67TFCOSSts_SelDscs ;
      private string AV70FilterTFCOSSts_SelValueDescription ;
      private string AV78Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ;
      private string AV83Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ;
      private string AV88Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ;
      private string AV60COSStsDescription ;
      private string AV56PageInfo ;
      private string AV53DateInfo ;
      private string AV51AppName ;
      private string AV57Phone ;
      private string AV55Mail ;
      private string AV59Website ;
      private string AV48AddressLine1 ;
      private string AV49AddressLine2 ;
      private string AV50AddressLine3 ;
      private GxSimpleCollection<short> AV68TFCOSSts_Sels ;
      private GxSimpleCollection<short> AV100Contabilidad_centrocostowwds_23_tfcossts_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006T2_A762COSSts ;
      private string[] P006T2_A80COSCueDestino ;
      private bool[] P006T2_n80COSCueDestino ;
      private string[] P006T2_A759COSAbr ;
      private string[] P006T2_A79COSCod ;
      private string[] P006T2_A761COSDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
   }

   public class centrocostowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006T2( IGxContext context ,
                                             short A762COSSts ,
                                             GxSimpleCollection<short> AV100Contabilidad_centrocostowwds_23_tfcossts_sels ,
                                             string AV78Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ,
                                             short AV79Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ,
                                             string AV80Contabilidad_centrocostowwds_3_cosdsc1 ,
                                             string AV81Contabilidad_centrocostowwds_4_coscod1 ,
                                             bool AV82Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ,
                                             string AV83Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ,
                                             short AV84Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ,
                                             string AV85Contabilidad_centrocostowwds_8_cosdsc2 ,
                                             string AV86Contabilidad_centrocostowwds_9_coscod2 ,
                                             bool AV87Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ,
                                             string AV88Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ,
                                             short AV89Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ,
                                             string AV90Contabilidad_centrocostowwds_13_cosdsc3 ,
                                             string AV91Contabilidad_centrocostowwds_14_coscod3 ,
                                             string AV93Contabilidad_centrocostowwds_16_tfcoscod_sel ,
                                             string AV92Contabilidad_centrocostowwds_15_tfcoscod ,
                                             string AV95Contabilidad_centrocostowwds_18_tfcosdsc_sel ,
                                             string AV94Contabilidad_centrocostowwds_17_tfcosdsc ,
                                             string AV97Contabilidad_centrocostowwds_20_tfcosabr_sel ,
                                             string AV96Contabilidad_centrocostowwds_19_tfcosabr ,
                                             string AV99Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ,
                                             string AV98Contabilidad_centrocostowwds_21_tfcoscuedestino ,
                                             int AV100Contabilidad_centrocostowwds_23_tfcossts_sels_Count ,
                                             string A761COSDsc ,
                                             string A79COSCod ,
                                             string A759COSAbr ,
                                             string A80COSCueDestino ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [COSSts], [COSCueDestino], [COSAbr], [COSCod], [COSDsc] FROM [CBCOSTOS]";
         if ( ( StringUtil.StrCmp(AV78Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSDSC") == 0 ) && ( AV79Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_centrocostowwds_3_cosdsc1)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV80Contabilidad_centrocostowwds_3_cosdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSDSC") == 0 ) && ( AV79Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_centrocostowwds_3_cosdsc1)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV80Contabilidad_centrocostowwds_3_cosdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSCOD") == 0 ) && ( AV79Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_centrocostowwds_4_coscod1)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV81Contabilidad_centrocostowwds_4_coscod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSCOD") == 0 ) && ( AV79Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_centrocostowwds_4_coscod1)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV81Contabilidad_centrocostowwds_4_coscod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV82Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSDSC") == 0 ) && ( AV84Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Contabilidad_centrocostowwds_8_cosdsc2)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV85Contabilidad_centrocostowwds_8_cosdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV82Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSDSC") == 0 ) && ( AV84Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Contabilidad_centrocostowwds_8_cosdsc2)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV85Contabilidad_centrocostowwds_8_cosdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV82Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSCOD") == 0 ) && ( AV84Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Contabilidad_centrocostowwds_9_coscod2)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV86Contabilidad_centrocostowwds_9_coscod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV82Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSCOD") == 0 ) && ( AV84Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Contabilidad_centrocostowwds_9_coscod2)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV86Contabilidad_centrocostowwds_9_coscod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV87Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSDSC") == 0 ) && ( AV89Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Contabilidad_centrocostowwds_13_cosdsc3)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV90Contabilidad_centrocostowwds_13_cosdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV87Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSDSC") == 0 ) && ( AV89Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Contabilidad_centrocostowwds_13_cosdsc3)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV90Contabilidad_centrocostowwds_13_cosdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV87Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSCOD") == 0 ) && ( AV89Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Contabilidad_centrocostowwds_14_coscod3)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV91Contabilidad_centrocostowwds_14_coscod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV87Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSCOD") == 0 ) && ( AV89Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Contabilidad_centrocostowwds_14_coscod3)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV91Contabilidad_centrocostowwds_14_coscod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Contabilidad_centrocostowwds_16_tfcoscod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Contabilidad_centrocostowwds_15_tfcoscod)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV92Contabilidad_centrocostowwds_15_tfcoscod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Contabilidad_centrocostowwds_16_tfcoscod_sel)) )
         {
            AddWhere(sWhereString, "([COSCod] = @AV93Contabilidad_centrocostowwds_16_tfcoscod_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Contabilidad_centrocostowwds_18_tfcosdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Contabilidad_centrocostowwds_17_tfcosdsc)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV94Contabilidad_centrocostowwds_17_tfcosdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Contabilidad_centrocostowwds_18_tfcosdsc_sel)) )
         {
            AddWhere(sWhereString, "([COSDsc] = @AV95Contabilidad_centrocostowwds_18_tfcosdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Contabilidad_centrocostowwds_20_tfcosabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Contabilidad_centrocostowwds_19_tfcosabr)) ) )
         {
            AddWhere(sWhereString, "([COSAbr] like @lV96Contabilidad_centrocostowwds_19_tfcosabr)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Contabilidad_centrocostowwds_20_tfcosabr_sel)) )
         {
            AddWhere(sWhereString, "([COSAbr] = @AV97Contabilidad_centrocostowwds_20_tfcosabr_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Contabilidad_centrocostowwds_21_tfcoscuedestino)) ) )
         {
            AddWhere(sWhereString, "([COSCueDestino] like @lV98Contabilidad_centrocostowwds_21_tfcoscuedestino)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)) )
         {
            AddWhere(sWhereString, "([COSCueDestino] = @AV99Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV100Contabilidad_centrocostowwds_23_tfcossts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV100Contabilidad_centrocostowwds_23_tfcossts_sels, "[COSSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [COSCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [COSCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [COSDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [COSDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [COSAbr]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [COSAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [COSCueDestino]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [COSCueDestino] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [COSSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [COSSts] DESC";
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
                     return conditional_P006T2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP006T2;
          prmP006T2 = new Object[] {
          new ParDef("@lV80Contabilidad_centrocostowwds_3_cosdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV80Contabilidad_centrocostowwds_3_cosdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV81Contabilidad_centrocostowwds_4_coscod1",GXType.NChar,10,0) ,
          new ParDef("@lV81Contabilidad_centrocostowwds_4_coscod1",GXType.NChar,10,0) ,
          new ParDef("@lV85Contabilidad_centrocostowwds_8_cosdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV85Contabilidad_centrocostowwds_8_cosdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV86Contabilidad_centrocostowwds_9_coscod2",GXType.NChar,10,0) ,
          new ParDef("@lV86Contabilidad_centrocostowwds_9_coscod2",GXType.NChar,10,0) ,
          new ParDef("@lV90Contabilidad_centrocostowwds_13_cosdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV90Contabilidad_centrocostowwds_13_cosdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV91Contabilidad_centrocostowwds_14_coscod3",GXType.NChar,10,0) ,
          new ParDef("@lV91Contabilidad_centrocostowwds_14_coscod3",GXType.NChar,10,0) ,
          new ParDef("@lV92Contabilidad_centrocostowwds_15_tfcoscod",GXType.NChar,10,0) ,
          new ParDef("@AV93Contabilidad_centrocostowwds_16_tfcoscod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV94Contabilidad_centrocostowwds_17_tfcosdsc",GXType.NChar,100,0) ,
          new ParDef("@AV95Contabilidad_centrocostowwds_18_tfcosdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV96Contabilidad_centrocostowwds_19_tfcosabr",GXType.NChar,5,0) ,
          new ParDef("@AV97Contabilidad_centrocostowwds_20_tfcosabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV98Contabilidad_centrocostowwds_21_tfcoscuedestino",GXType.NChar,15,0) ,
          new ParDef("@AV99Contabilidad_centrocostowwds_22_tfcoscuedestino_sel",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006T2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 5);
                ((string[]) buf[4])[0] = rslt.getString(4, 10);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
