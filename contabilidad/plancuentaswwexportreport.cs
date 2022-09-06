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
   public class plancuentaswwexportreport : GXWebProcedure
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

      public plancuentaswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public plancuentaswwexportreport( IGxContext context )
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
         plancuentaswwexportreport objplancuentaswwexportreport;
         objplancuentaswwexportreport = new plancuentaswwexportreport();
         objplancuentaswwexportreport.context.SetSubmitInitialConfig(context);
         objplancuentaswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objplancuentaswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((plancuentaswwexportreport)stateInfo).executePrivate();
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
            AV98Title = "Lista de Plan de Cuentas";
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
            H6I0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CUECOD") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV100CueCod1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100CueCod1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV101FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV101FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV102CueCod = AV100CueCod1;
                  H6I0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV101FilterCueCodDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV102CueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CUEDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV14CueDsc1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14CueDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterCueDscDescription = StringUtil.Format( "%1 (%2)", "Descripción", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterCueDscDescription = StringUtil.Format( "%1 (%2)", "Descripción", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16CueDsc = AV14CueDsc1;
                  H6I0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCueDscDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CueDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CUEMOV") == 0 )
            {
               AV115CueMov1 = (short)(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."));
               if ( ! (0==AV115CueMov1) )
               {
                  if ( AV115CueMov1 == 1 )
                  {
                     AV118FilterCueMov1ValueDescription = "SOLO MOVIMIENTO";
                  }
                  else if ( AV115CueMov1 == 0 )
                  {
                     AV118FilterCueMov1ValueDescription = "CUENTAS TITULO";
                  }
                  AV117FilterCueMovValueDescription = AV118FilterCueMov1ValueDescription;
                  H6I0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Movimiento Cuenta", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV117FilterCueMovValueDescription, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV20DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CUECOD") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV103CueCod2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103CueCod2)) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV101FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV101FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV102CueCod = AV103CueCod2;
                     H6I0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV101FilterCueCodDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV102CueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CUEDSC") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV23CueDsc2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23CueDsc2)) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterCueDscDescription = StringUtil.Format( "%1 (%2)", "Descripción", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterCueDscDescription = StringUtil.Format( "%1 (%2)", "Descripción", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16CueDsc = AV23CueDsc2;
                     H6I0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCueDscDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CueDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CUEMOV") == 0 )
               {
                  AV119CueMov2 = (short)(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."));
                  if ( ! (0==AV119CueMov2) )
                  {
                     if ( AV119CueMov2 == 1 )
                     {
                        AV120FilterCueMov2ValueDescription = "SOLO MOVIMIENTO";
                     }
                     else if ( AV119CueMov2 == 0 )
                     {
                        AV120FilterCueMov2ValueDescription = "CUENTAS TITULO";
                     }
                     AV117FilterCueMovValueDescription = AV120FilterCueMov2ValueDescription;
                     H6I0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Movimiento Cuenta", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV117FilterCueMovValueDescription, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CUECOD") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV104CueCod3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104CueCod3)) )
                     {
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV101FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV101FilterCueCodDescription = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV102CueCod = AV104CueCod3;
                        H6I0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV101FilterCueCodDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV102CueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CUEDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV28CueDsc3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28CueDsc3)) )
                     {
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterCueDscDescription = StringUtil.Format( "%1 (%2)", "Descripción", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterCueDscDescription = StringUtil.Format( "%1 (%2)", "Descripción", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16CueDsc = AV28CueDsc3;
                        H6I0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCueDscDescription, "")), 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CueDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CUEMOV") == 0 )
                  {
                     AV121CueMov3 = (short)(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."));
                     if ( ! (0==AV121CueMov3) )
                     {
                        if ( AV121CueMov3 == 1 )
                        {
                           AV122FilterCueMov3ValueDescription = "SOLO MOVIMIENTO";
                        }
                        else if ( AV121CueMov3 == 0 )
                        {
                           AV122FilterCueMov3ValueDescription = "CUENTAS TITULO";
                        }
                        AV117FilterCueMovValueDescription = AV122FilterCueMov3ValueDescription;
                        H6I0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText("Movimiento Cuenta", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV117FilterCueMovValueDescription, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCueCod_Sel)) )
         {
            H6I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFCueCod_Sel, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCueCod)) )
            {
               H6I0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuenta Contable", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFCueCod, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCueDsc_Sel)) )
         {
            H6I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descripción", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFCueDsc_Sel, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCueDsc)) )
            {
               H6I0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFCueDsc, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV106TFCueMov_Sel) )
         {
            H6I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Movimiento", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV106TFCueMov_Sel), "9")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV107TFCueMon_Sel) )
         {
            H6I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Monetaria", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV107TFCueMon_Sel), "9")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV108TFCueCos_Sel) )
         {
            H6I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Centro de Costos", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV108TFCueCos_Sel), "9")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFCueGasDebe_Sel)) )
         {
            H6I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Gasto Debe", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFCueGasDebe_Sel, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFCueGasDebe)) )
            {
               H6I0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Gasto Debe", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFCueGasDebe, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TFCueGasHaber_Sel)) )
         {
            H6I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Gasto Haber", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFCueGasHaber_Sel, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCueGasHaber)) )
            {
               H6I0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Gasto Haber", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFCueGasHaber, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV111TFCueSts_Sels.FromJSonString(AV109TFCueSts_SelsJson, null);
         if ( ! ( AV111TFCueSts_Sels.Count == 0 ) )
         {
            AV114i = 1;
            AV127GXV1 = 1;
            while ( AV127GXV1 <= AV111TFCueSts_Sels.Count )
            {
               AV112TFCueSts_Sel = (short)(AV111TFCueSts_Sels.GetNumeric(AV127GXV1));
               if ( AV114i == 1 )
               {
                  AV110TFCueSts_SelDscs = "";
               }
               else
               {
                  AV110TFCueSts_SelDscs += ", ";
               }
               if ( AV112TFCueSts_Sel == 1 )
               {
                  AV113FilterTFCueSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV112TFCueSts_Sel == 0 )
               {
                  AV113FilterTFCueSts_SelValueDescription = "INACTIVO";
               }
               AV110TFCueSts_SelDscs += AV113FilterTFCueSts_SelValueDescription;
               AV114i = (long)(AV114i+1);
               AV127GXV1 = (int)(AV127GXV1+1);
            }
            H6I0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 226, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV110TFCueSts_SelDscs, "")), 226, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6I0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6I0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Cuenta Contable", 30, Gx_line+10, 102, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Descripción", 106, Gx_line+10, 252, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Movimiento", 256, Gx_line+10, 329, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Monetaria", 333, Gx_line+10, 406, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Centro de Costos", 410, Gx_line+10, 483, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Gasto Debe", 487, Gx_line+10, 560, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Gasto Haber", 564, Gx_line+10, 637, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 641, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV129Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV130Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV131Contabilidad_plancuentaswwds_3_cuecod1 = AV100CueCod1;
         AV132Contabilidad_plancuentaswwds_4_cuedsc1 = AV14CueDsc1;
         AV133Contabilidad_plancuentaswwds_5_cuemov1 = AV115CueMov1;
         AV134Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV135Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV136Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV137Contabilidad_plancuentaswwds_9_cuecod2 = AV103CueCod2;
         AV138Contabilidad_plancuentaswwds_10_cuedsc2 = AV23CueDsc2;
         AV139Contabilidad_plancuentaswwds_11_cuemov2 = AV119CueMov2;
         AV140Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV141Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV142Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV143Contabilidad_plancuentaswwds_15_cuecod3 = AV104CueCod3;
         AV144Contabilidad_plancuentaswwds_16_cuedsc3 = AV28CueDsc3;
         AV145Contabilidad_plancuentaswwds_17_cuemov3 = AV121CueMov3;
         AV146Contabilidad_plancuentaswwds_18_tfcuecod = AV35TFCueCod;
         AV147Contabilidad_plancuentaswwds_19_tfcuecod_sel = AV36TFCueCod_Sel;
         AV148Contabilidad_plancuentaswwds_20_tfcuedsc = AV37TFCueDsc;
         AV149Contabilidad_plancuentaswwds_21_tfcuedsc_sel = AV38TFCueDsc_Sel;
         AV150Contabilidad_plancuentaswwds_22_tfcuemov_sel = AV106TFCueMov_Sel;
         AV151Contabilidad_plancuentaswwds_23_tfcuemon_sel = AV107TFCueMon_Sel;
         AV152Contabilidad_plancuentaswwds_24_tfcuecos_sel = AV108TFCueCos_Sel;
         AV153Contabilidad_plancuentaswwds_25_tfcuegasdebe = AV49TFCueGasDebe;
         AV154Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = AV50TFCueGasDebe_Sel;
         AV155Contabilidad_plancuentaswwds_27_tfcuegashaber = AV51TFCueGasHaber;
         AV156Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = AV52TFCueGasHaber_Sel;
         AV157Contabilidad_plancuentaswwds_29_tfcuests_sels = AV111TFCueSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A873CueSts ,
                                              AV157Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                              AV129Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                              AV130Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                              AV131Contabilidad_plancuentaswwds_3_cuecod1 ,
                                              AV132Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                              AV134Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                              AV135Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                              AV136Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                              AV137Contabilidad_plancuentaswwds_9_cuecod2 ,
                                              AV138Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                              AV140Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                              AV141Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                              AV142Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                              AV143Contabilidad_plancuentaswwds_15_cuecod3 ,
                                              AV144Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                              AV147Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                              AV146Contabilidad_plancuentaswwds_18_tfcuecod ,
                                              AV149Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                              AV148Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                              AV150Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                              AV151Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                              AV152Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                              AV154Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                              AV153Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                              AV156Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                              AV155Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                              AV157Contabilidad_plancuentaswwds_29_tfcuests_sels.Count ,
                                              A91CueCod ,
                                              A860CueDsc ,
                                              A867CueMov ,
                                              AV133Contabilidad_plancuentaswwds_5_cuemov1 ,
                                              AV139Contabilidad_plancuentaswwds_11_cuemov2 ,
                                              AV145Contabilidad_plancuentaswwds_17_cuemov3 ,
                                              A864CueMon ,
                                              A859CueCos ,
                                              A109CueGasDebe ,
                                              A110CueGasHaber ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV131Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV131Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
         lV131Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV131Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
         lV132Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV132Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
         lV132Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV132Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
         lV137Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV137Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
         lV137Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV137Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
         lV138Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV138Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
         lV138Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV138Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
         lV143Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV143Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
         lV143Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV143Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
         lV144Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV144Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
         lV144Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV144Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
         lV146Contabilidad_plancuentaswwds_18_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV146Contabilidad_plancuentaswwds_18_tfcuecod), 15, "%");
         lV148Contabilidad_plancuentaswwds_20_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV148Contabilidad_plancuentaswwds_20_tfcuedsc), 100, "%");
         lV153Contabilidad_plancuentaswwds_25_tfcuegasdebe = StringUtil.PadR( StringUtil.RTrim( AV153Contabilidad_plancuentaswwds_25_tfcuegasdebe), 15, "%");
         lV155Contabilidad_plancuentaswwds_27_tfcuegashaber = StringUtil.PadR( StringUtil.RTrim( AV155Contabilidad_plancuentaswwds_27_tfcuegashaber), 15, "%");
         /* Using cursor P006I2 */
         pr_default.execute(0, new Object[] {lV131Contabilidad_plancuentaswwds_3_cuecod1, lV131Contabilidad_plancuentaswwds_3_cuecod1, lV132Contabilidad_plancuentaswwds_4_cuedsc1, lV132Contabilidad_plancuentaswwds_4_cuedsc1, AV133Contabilidad_plancuentaswwds_5_cuemov1, lV137Contabilidad_plancuentaswwds_9_cuecod2, lV137Contabilidad_plancuentaswwds_9_cuecod2, lV138Contabilidad_plancuentaswwds_10_cuedsc2, lV138Contabilidad_plancuentaswwds_10_cuedsc2, AV139Contabilidad_plancuentaswwds_11_cuemov2, lV143Contabilidad_plancuentaswwds_15_cuecod3, lV143Contabilidad_plancuentaswwds_15_cuecod3, lV144Contabilidad_plancuentaswwds_16_cuedsc3, lV144Contabilidad_plancuentaswwds_16_cuedsc3, AV145Contabilidad_plancuentaswwds_17_cuemov3, lV146Contabilidad_plancuentaswwds_18_tfcuecod, AV147Contabilidad_plancuentaswwds_19_tfcuecod_sel, lV148Contabilidad_plancuentaswwds_20_tfcuedsc, AV149Contabilidad_plancuentaswwds_21_tfcuedsc_sel, lV153Contabilidad_plancuentaswwds_25_tfcuegasdebe, AV154Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel, lV155Contabilidad_plancuentaswwds_27_tfcuegashaber, AV156Contabilidad_plancuentaswwds_28_tfcuegashaber_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A873CueSts = P006I2_A873CueSts[0];
            A110CueGasHaber = P006I2_A110CueGasHaber[0];
            n110CueGasHaber = P006I2_n110CueGasHaber[0];
            A109CueGasDebe = P006I2_A109CueGasDebe[0];
            n109CueGasDebe = P006I2_n109CueGasDebe[0];
            A859CueCos = P006I2_A859CueCos[0];
            A864CueMon = P006I2_A864CueMon[0];
            A867CueMov = P006I2_A867CueMov[0];
            A860CueDsc = P006I2_A860CueDsc[0];
            A91CueCod = P006I2_A91CueCod[0];
            if ( A873CueSts == 1 )
            {
               AV105CueStsDescription = "ACTIVO";
            }
            else if ( A873CueSts == 0 )
            {
               AV105CueStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6I0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), 30, Gx_line+10, 102, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A860CueDsc, "")), 106, Gx_line+10, 252, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A867CueMov), "9")), 256, Gx_line+10, 329, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A864CueMon), "9")), 333, Gx_line+10, 406, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A859CueCos), "9")), 410, Gx_line+10, 483, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A109CueGasDebe, "")), 487, Gx_line+10, 560, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A110CueGasHaber, "")), 564, Gx_line+10, 637, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV105CueStsDescription, "")), 641, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV31Session.Get("Contabilidad.PlanCuentasWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.PlanCuentasWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Contabilidad.PlanCuentasWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV158GXV2 = 1;
         while ( AV158GXV2 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV158GXV2));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV35TFCueCod = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV36TFCueCod_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV37TFCueDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV38TFCueDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUEMOV_SEL") == 0 )
            {
               AV106TFCueMov_Sel = (short)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUEMON_SEL") == 0 )
            {
               AV107TFCueMon_Sel = (short)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUECOS_SEL") == 0 )
            {
               AV108TFCueCos_Sel = (short)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUEGASDEBE") == 0 )
            {
               AV49TFCueGasDebe = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUEGASDEBE_SEL") == 0 )
            {
               AV50TFCueGasDebe_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUEGASHABER") == 0 )
            {
               AV51TFCueGasHaber = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUEGASHABER_SEL") == 0 )
            {
               AV52TFCueGasHaber_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUESTS_SEL") == 0 )
            {
               AV109TFCueSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV111TFCueSts_Sels.FromJSonString(AV109TFCueSts_SelsJson, null);
            }
            AV158GXV2 = (int)(AV158GXV2+1);
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

      protected void H6I0( bool bFoot ,
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
                  AV96PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV93DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV96PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV93DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV91AppName = "DVelop Software Solutions";
               AV97Phone = "+1 550 8923";
               AV95Mail = "info@mail.com";
               AV99Website = "http://www.web.com";
               AV88AddressLine1 = "French Boulevard 2859";
               AV89AddressLine2 = "Downtown";
               AV90AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV91AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV98Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV99Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV88AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV89AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV90AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV98Title = "";
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV100CueCod1 = "";
         AV101FilterCueCodDescription = "";
         AV102CueCod = "";
         AV14CueDsc1 = "";
         AV15FilterCueDscDescription = "";
         AV16CueDsc = "";
         AV118FilterCueMov1ValueDescription = "";
         AV117FilterCueMovValueDescription = "";
         AV21DynamicFiltersSelector2 = "";
         AV103CueCod2 = "";
         AV23CueDsc2 = "";
         AV120FilterCueMov2ValueDescription = "";
         AV26DynamicFiltersSelector3 = "";
         AV104CueCod3 = "";
         AV28CueDsc3 = "";
         AV122FilterCueMov3ValueDescription = "";
         AV36TFCueCod_Sel = "";
         AV35TFCueCod = "";
         AV38TFCueDsc_Sel = "";
         AV37TFCueDsc = "";
         AV50TFCueGasDebe_Sel = "";
         AV49TFCueGasDebe = "";
         AV52TFCueGasHaber_Sel = "";
         AV51TFCueGasHaber = "";
         AV111TFCueSts_Sels = new GxSimpleCollection<short>();
         AV109TFCueSts_SelsJson = "";
         AV110TFCueSts_SelDscs = "";
         AV113FilterTFCueSts_SelValueDescription = "";
         AV129Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = "";
         AV131Contabilidad_plancuentaswwds_3_cuecod1 = "";
         AV132Contabilidad_plancuentaswwds_4_cuedsc1 = "";
         AV135Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = "";
         AV137Contabilidad_plancuentaswwds_9_cuecod2 = "";
         AV138Contabilidad_plancuentaswwds_10_cuedsc2 = "";
         AV141Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = "";
         AV143Contabilidad_plancuentaswwds_15_cuecod3 = "";
         AV144Contabilidad_plancuentaswwds_16_cuedsc3 = "";
         AV146Contabilidad_plancuentaswwds_18_tfcuecod = "";
         AV147Contabilidad_plancuentaswwds_19_tfcuecod_sel = "";
         AV148Contabilidad_plancuentaswwds_20_tfcuedsc = "";
         AV149Contabilidad_plancuentaswwds_21_tfcuedsc_sel = "";
         AV153Contabilidad_plancuentaswwds_25_tfcuegasdebe = "";
         AV154Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = "";
         AV155Contabilidad_plancuentaswwds_27_tfcuegashaber = "";
         AV156Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = "";
         AV157Contabilidad_plancuentaswwds_29_tfcuests_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV131Contabilidad_plancuentaswwds_3_cuecod1 = "";
         lV132Contabilidad_plancuentaswwds_4_cuedsc1 = "";
         lV137Contabilidad_plancuentaswwds_9_cuecod2 = "";
         lV138Contabilidad_plancuentaswwds_10_cuedsc2 = "";
         lV143Contabilidad_plancuentaswwds_15_cuecod3 = "";
         lV144Contabilidad_plancuentaswwds_16_cuedsc3 = "";
         lV146Contabilidad_plancuentaswwds_18_tfcuecod = "";
         lV148Contabilidad_plancuentaswwds_20_tfcuedsc = "";
         lV153Contabilidad_plancuentaswwds_25_tfcuegasdebe = "";
         lV155Contabilidad_plancuentaswwds_27_tfcuegashaber = "";
         A91CueCod = "";
         A860CueDsc = "";
         A109CueGasDebe = "";
         A110CueGasHaber = "";
         P006I2_A873CueSts = new short[1] ;
         P006I2_A110CueGasHaber = new string[] {""} ;
         P006I2_n110CueGasHaber = new bool[] {false} ;
         P006I2_A109CueGasDebe = new string[] {""} ;
         P006I2_n109CueGasDebe = new bool[] {false} ;
         P006I2_A859CueCos = new short[1] ;
         P006I2_A864CueMon = new short[1] ;
         P006I2_A867CueMov = new short[1] ;
         P006I2_A860CueDsc = new string[] {""} ;
         P006I2_A91CueCod = new string[] {""} ;
         AV105CueStsDescription = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV96PageInfo = "";
         AV93DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV91AppName = "";
         AV97Phone = "";
         AV95Mail = "";
         AV99Website = "";
         AV88AddressLine1 = "";
         AV89AddressLine2 = "";
         AV90AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.plancuentaswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006I2_A873CueSts, P006I2_A110CueGasHaber, P006I2_n110CueGasHaber, P006I2_A109CueGasDebe, P006I2_n109CueGasDebe, P006I2_A859CueCos, P006I2_A864CueMon, P006I2_A867CueMov, P006I2_A860CueDsc, P006I2_A91CueCod
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
      private short AV115CueMov1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV119CueMov2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV121CueMov3 ;
      private short AV106TFCueMov_Sel ;
      private short AV107TFCueMon_Sel ;
      private short AV108TFCueCos_Sel ;
      private short AV112TFCueSts_Sel ;
      private short AV130Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ;
      private short AV133Contabilidad_plancuentaswwds_5_cuemov1 ;
      private short AV136Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ;
      private short AV139Contabilidad_plancuentaswwds_11_cuemov2 ;
      private short AV142Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ;
      private short AV145Contabilidad_plancuentaswwds_17_cuemov3 ;
      private short AV150Contabilidad_plancuentaswwds_22_tfcuemov_sel ;
      private short AV151Contabilidad_plancuentaswwds_23_tfcuemon_sel ;
      private short AV152Contabilidad_plancuentaswwds_24_tfcuecos_sel ;
      private short A873CueSts ;
      private short A867CueMov ;
      private short A864CueMon ;
      private short A859CueCos ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV127GXV1 ;
      private int AV157Contabilidad_plancuentaswwds_29_tfcuests_sels_Count ;
      private int AV158GXV2 ;
      private long AV114i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV100CueCod1 ;
      private string AV102CueCod ;
      private string AV14CueDsc1 ;
      private string AV16CueDsc ;
      private string AV103CueCod2 ;
      private string AV23CueDsc2 ;
      private string AV104CueCod3 ;
      private string AV28CueDsc3 ;
      private string AV36TFCueCod_Sel ;
      private string AV35TFCueCod ;
      private string AV38TFCueDsc_Sel ;
      private string AV37TFCueDsc ;
      private string AV50TFCueGasDebe_Sel ;
      private string AV49TFCueGasDebe ;
      private string AV52TFCueGasHaber_Sel ;
      private string AV51TFCueGasHaber ;
      private string AV131Contabilidad_plancuentaswwds_3_cuecod1 ;
      private string AV132Contabilidad_plancuentaswwds_4_cuedsc1 ;
      private string AV137Contabilidad_plancuentaswwds_9_cuecod2 ;
      private string AV138Contabilidad_plancuentaswwds_10_cuedsc2 ;
      private string AV143Contabilidad_plancuentaswwds_15_cuecod3 ;
      private string AV144Contabilidad_plancuentaswwds_16_cuedsc3 ;
      private string AV146Contabilidad_plancuentaswwds_18_tfcuecod ;
      private string AV147Contabilidad_plancuentaswwds_19_tfcuecod_sel ;
      private string AV148Contabilidad_plancuentaswwds_20_tfcuedsc ;
      private string AV149Contabilidad_plancuentaswwds_21_tfcuedsc_sel ;
      private string AV153Contabilidad_plancuentaswwds_25_tfcuegasdebe ;
      private string AV154Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ;
      private string AV155Contabilidad_plancuentaswwds_27_tfcuegashaber ;
      private string AV156Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ;
      private string scmdbuf ;
      private string lV131Contabilidad_plancuentaswwds_3_cuecod1 ;
      private string lV132Contabilidad_plancuentaswwds_4_cuedsc1 ;
      private string lV137Contabilidad_plancuentaswwds_9_cuecod2 ;
      private string lV138Contabilidad_plancuentaswwds_10_cuedsc2 ;
      private string lV143Contabilidad_plancuentaswwds_15_cuecod3 ;
      private string lV144Contabilidad_plancuentaswwds_16_cuedsc3 ;
      private string lV146Contabilidad_plancuentaswwds_18_tfcuecod ;
      private string lV148Contabilidad_plancuentaswwds_20_tfcuedsc ;
      private string lV153Contabilidad_plancuentaswwds_25_tfcuegasdebe ;
      private string lV155Contabilidad_plancuentaswwds_27_tfcuegashaber ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string A109CueGasDebe ;
      private string A110CueGasHaber ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV134Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ;
      private bool AV140Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private bool n110CueGasHaber ;
      private bool n109CueGasDebe ;
      private string AV109TFCueSts_SelsJson ;
      private string AV98Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV101FilterCueCodDescription ;
      private string AV15FilterCueDscDescription ;
      private string AV118FilterCueMov1ValueDescription ;
      private string AV117FilterCueMovValueDescription ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV120FilterCueMov2ValueDescription ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV122FilterCueMov3ValueDescription ;
      private string AV110TFCueSts_SelDscs ;
      private string AV113FilterTFCueSts_SelValueDescription ;
      private string AV129Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ;
      private string AV135Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ;
      private string AV141Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ;
      private string AV105CueStsDescription ;
      private string AV96PageInfo ;
      private string AV93DateInfo ;
      private string AV91AppName ;
      private string AV97Phone ;
      private string AV95Mail ;
      private string AV99Website ;
      private string AV88AddressLine1 ;
      private string AV89AddressLine2 ;
      private string AV90AddressLine3 ;
      private GxSimpleCollection<short> AV111TFCueSts_Sels ;
      private GxSimpleCollection<short> AV157Contabilidad_plancuentaswwds_29_tfcuests_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006I2_A873CueSts ;
      private string[] P006I2_A110CueGasHaber ;
      private bool[] P006I2_n110CueGasHaber ;
      private string[] P006I2_A109CueGasDebe ;
      private bool[] P006I2_n109CueGasDebe ;
      private short[] P006I2_A859CueCos ;
      private short[] P006I2_A864CueMon ;
      private short[] P006I2_A867CueMov ;
      private string[] P006I2_A860CueDsc ;
      private string[] P006I2_A91CueCod ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
   }

   public class plancuentaswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006I2( IGxContext context ,
                                             short A873CueSts ,
                                             GxSimpleCollection<short> AV157Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                             string AV129Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                             short AV130Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                             string AV131Contabilidad_plancuentaswwds_3_cuecod1 ,
                                             string AV132Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                             bool AV134Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                             string AV135Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                             short AV136Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                             string AV137Contabilidad_plancuentaswwds_9_cuecod2 ,
                                             string AV138Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                             bool AV140Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                             string AV141Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                             short AV142Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                             string AV143Contabilidad_plancuentaswwds_15_cuecod3 ,
                                             string AV144Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                             string AV147Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                             string AV146Contabilidad_plancuentaswwds_18_tfcuecod ,
                                             string AV149Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                             string AV148Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                             short AV150Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                             short AV151Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                             short AV152Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                             string AV154Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                             string AV153Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                             string AV156Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                             string AV155Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                             int AV157Contabilidad_plancuentaswwds_29_tfcuests_sels_Count ,
                                             string A91CueCod ,
                                             string A860CueDsc ,
                                             short A867CueMov ,
                                             short AV133Contabilidad_plancuentaswwds_5_cuemov1 ,
                                             short AV139Contabilidad_plancuentaswwds_11_cuemov2 ,
                                             short AV145Contabilidad_plancuentaswwds_17_cuemov3 ,
                                             short A864CueMon ,
                                             short A859CueCos ,
                                             string A109CueGasDebe ,
                                             string A110CueGasHaber ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[23];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [CueSts], [CueGasHaber], [CueGasDebe], [CueCos], [CueMon], [CueMov], [CueDsc], [CueCod] FROM [CBPLANCUENTA]";
         if ( ( StringUtil.StrCmp(AV129Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV130Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV131Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV129Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV130Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV131Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV129Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV130Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV132Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV129Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV130Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV132Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV129Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEMOV") == 0 )
         {
            AddWhere(sWhereString, "([CueMov] = @AV133Contabilidad_plancuentaswwds_5_cuemov1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV134Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV135Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV136Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV137Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV134Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV135Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV136Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV137Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV134Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV135Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV136Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV138Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV134Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV135Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV136Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV138Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV134Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV135Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV139Contabilidad_plancuentaswwds_11_cuemov2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV140Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV142Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV143Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV140Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV142Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV143Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV140Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV142Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV144Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV140Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV142Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV144Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV140Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV145Contabilidad_plancuentaswwds_17_cuemov3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV147Contabilidad_plancuentaswwds_19_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Contabilidad_plancuentaswwds_18_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV146Contabilidad_plancuentaswwds_18_tfcuecod)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Contabilidad_plancuentaswwds_19_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "([CueCod] = @AV147Contabilidad_plancuentaswwds_19_tfcuecod_sel)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV149Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Contabilidad_plancuentaswwds_20_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV148Contabilidad_plancuentaswwds_20_tfcuedsc)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "([CueDsc] = @AV149Contabilidad_plancuentaswwds_21_tfcuedsc_sel)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV150Contabilidad_plancuentaswwds_22_tfcuemov_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMov] = 1)");
         }
         if ( AV150Contabilidad_plancuentaswwds_22_tfcuemov_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMov] = 0)");
         }
         if ( AV151Contabilidad_plancuentaswwds_23_tfcuemon_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMon] = 1)");
         }
         if ( AV151Contabilidad_plancuentaswwds_23_tfcuemon_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMon] = 0)");
         }
         if ( AV152Contabilidad_plancuentaswwds_24_tfcuecos_sel == 1 )
         {
            AddWhere(sWhereString, "([CueCos] = 1)");
         }
         if ( AV152Contabilidad_plancuentaswwds_24_tfcuecos_sel == 2 )
         {
            AddWhere(sWhereString, "([CueCos] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Contabilidad_plancuentaswwds_25_tfcuegasdebe)) ) )
         {
            AddWhere(sWhereString, "([CueGasDebe] like @lV153Contabilidad_plancuentaswwds_25_tfcuegasdebe)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) )
         {
            AddWhere(sWhereString, "([CueGasDebe] = @AV154Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Contabilidad_plancuentaswwds_27_tfcuegashaber)) ) )
         {
            AddWhere(sWhereString, "([CueGasHaber] like @lV155Contabilidad_plancuentaswwds_27_tfcuegashaber)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) )
         {
            AddWhere(sWhereString, "([CueGasHaber] = @AV156Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( AV157Contabilidad_plancuentaswwds_29_tfcuests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV157Contabilidad_plancuentaswwds_29_tfcuests_sels, "[CueSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueMov]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueMov] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueMon]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueMon] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueCos]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueCos] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueGasDebe]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueGasDebe] DESC";
         }
         else if ( ( AV10OrderedBy == 7 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueGasHaber]";
         }
         else if ( ( AV10OrderedBy == 7 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueGasHaber] DESC";
         }
         else if ( ( AV10OrderedBy == 8 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueSts]";
         }
         else if ( ( AV10OrderedBy == 8 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueSts] DESC";
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
                     return conditional_P006I2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] );
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
          Object[] prmP006I2;
          prmP006I2 = new Object[] {
          new ParDef("@lV131Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV131Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV132Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV132Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@AV133Contabilidad_plancuentaswwds_5_cuemov1",GXType.Int16,1,0) ,
          new ParDef("@lV137Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV137Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV138Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV138Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@AV139Contabilidad_plancuentaswwds_11_cuemov2",GXType.Int16,1,0) ,
          new ParDef("@lV143Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV143Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV144Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV144Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV145Contabilidad_plancuentaswwds_17_cuemov3",GXType.Int16,1,0) ,
          new ParDef("@lV146Contabilidad_plancuentaswwds_18_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV147Contabilidad_plancuentaswwds_19_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV148Contabilidad_plancuentaswwds_20_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV149Contabilidad_plancuentaswwds_21_tfcuedsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV153Contabilidad_plancuentaswwds_25_tfcuegasdebe",GXType.NChar,15,0) ,
          new ParDef("@AV154Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel",GXType.NChar,15,0) ,
          new ParDef("@lV155Contabilidad_plancuentaswwds_27_tfcuegashaber",GXType.NChar,15,0) ,
          new ParDef("@AV156Contabilidad_plancuentaswwds_28_tfcuegashaber_sel",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006I2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(3, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 100);
                ((string[]) buf[9])[0] = rslt.getString(8, 15);
                return;
       }
    }

 }

}
