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
   public class listaprecioswwexportreport : GXWebProcedure
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

      public listaprecioswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public listaprecioswwexportreport( IGxContext context )
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
         listaprecioswwexportreport objlistaprecioswwexportreport;
         objlistaprecioswwexportreport = new listaprecioswwexportreport();
         objlistaprecioswwexportreport.context.SetSubmitInitialConfig(context);
         objlistaprecioswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlistaprecioswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listaprecioswwexportreport)stateInfo).executePrivate();
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
            AV70Title = "Lista de Lista de Precios";
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
            H4K0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "TIPLPRODDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV14TipLProdDsc1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TipLProdDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterTipLProdDscDescription = StringUtil.Format( "%1 (%2)", "Producto", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterTipLProdDscDescription = StringUtil.Format( "%1 (%2)", "Producto", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16TipLProdDsc = AV14TipLProdDsc1;
                  H4K0( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterTipLProdDscDescription, "")), 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TipLProdDsc, "")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "TIPLDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV17TipLDsc1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TipLDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV18FilterTipLDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV18FilterTipLDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV19TipLDsc = AV17TipLDsc1;
                  H4K0( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterTipLDscDescription, "")), 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19TipLDsc, "")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV20DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "TIPLPRODDSC") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV23TipLProdDsc2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TipLProdDsc2)) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterTipLProdDscDescription = StringUtil.Format( "%1 (%2)", "Producto", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterTipLProdDscDescription = StringUtil.Format( "%1 (%2)", "Producto", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16TipLProdDsc = AV23TipLProdDsc2;
                     H4K0( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterTipLProdDscDescription, "")), 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TipLProdDsc, "")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "TIPLDSC") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV24TipLDsc2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TipLDsc2)) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV18FilterTipLDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV18FilterTipLDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV19TipLDsc = AV24TipLDsc2;
                     H4K0( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterTipLDscDescription, "")), 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19TipLDsc, "")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIPLPRODDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV28TipLProdDsc3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TipLProdDsc3)) )
                     {
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterTipLProdDscDescription = StringUtil.Format( "%1 (%2)", "Producto", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterTipLProdDscDescription = StringUtil.Format( "%1 (%2)", "Producto", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16TipLProdDsc = AV28TipLProdDsc3;
                        H4K0( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterTipLProdDscDescription, "")), 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TipLProdDsc, "")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIPLDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29TipLDsc3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TipLDsc3)) )
                     {
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV18FilterTipLDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV18FilterTipLDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV19TipLDsc = AV29TipLDsc3;
                        H4K0( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterTipLDscDescription, "")), 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19TipLDsc, "")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFTipLDsc_Sel)) )
         {
            H4K0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo de Lista", 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFTipLDsc_Sel, "")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTipLDsc)) )
            {
               H4K0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo de Lista", 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFTipLDsc, "")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFProdCod_Sel)) )
         {
            H4K0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFProdCod_Sel, "@!")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFProdCod)) )
            {
               H4K0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFProdCod, "@!")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFTipLProdDsc_Sel)) )
         {
            H4K0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Producto", 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFTipLProdDsc_Sel, "")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFTipLProdDsc)) )
            {
               H4K0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Producto", 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFTipLProdDsc, "")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCliCod_Sel)) )
         {
            H4K0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("R.U.C. Cliente", 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFCliCod_Sel, "")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCliCod)) )
            {
               H4K0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("R.U.C. Cliente", 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFCliCod, "")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV45TFPreLis) && (Convert.ToDecimal(0)==AV46TFPreLis_To) ) )
         {
            H4K0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Precio", 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TFPreLis, "ZZZZ,ZZZ,ZZ9.9999")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV57TFPreLis_To_Description = StringUtil.Format( "%1 (%2)", "Precio", "Hasta", "", "", "", "", "", "", "");
            H4K0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57TFPreLis_To_Description, "")), 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46TFPreLis_To, "ZZZZ,ZZZ,ZZ9.9999")), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (DateTime.MinValue==AV51TFLisFech) && (DateTime.MinValue==AV52TFLisFech_To) ) )
         {
            H4K0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Fecha", 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV51TFLisFech, "99/99/99"), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV58TFLisFech_To_Description = StringUtil.Format( "%1 (%2)", "Fecha", "Hasta", "", "", "", "", "", "", "");
            H4K0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58TFLisFech_To_Description, "")), 25, Gx_line+0, 209, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV52TFLisFech_To, "99/99/99"), 209, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4K0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4K0( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Tipo de Lista", 30, Gx_line+10, 193, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo", 197, Gx_line+10, 279, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Producto", 283, Gx_line+10, 447, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("R.U.C. Cliente", 451, Gx_line+10, 615, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Precio", 619, Gx_line+10, 701, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Fecha", 705, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV77Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV78Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV79Configuracion_listaprecioswwds_3_tiplproddsc1 = AV14TipLProdDsc1;
         AV80Configuracion_listaprecioswwds_4_tipldsc1 = AV17TipLDsc1;
         AV81Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV82Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV83Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV84Configuracion_listaprecioswwds_8_tiplproddsc2 = AV23TipLProdDsc2;
         AV85Configuracion_listaprecioswwds_9_tipldsc2 = AV24TipLDsc2;
         AV86Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV87Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV88Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV89Configuracion_listaprecioswwds_13_tiplproddsc3 = AV28TipLProdDsc3;
         AV90Configuracion_listaprecioswwds_14_tipldsc3 = AV29TipLDsc3;
         AV91Configuracion_listaprecioswwds_15_tftipldsc = AV43TFTipLDsc;
         AV92Configuracion_listaprecioswwds_16_tftipldsc_sel = AV44TFTipLDsc_Sel;
         AV93Configuracion_listaprecioswwds_17_tfprodcod = AV39TFProdCod;
         AV94Configuracion_listaprecioswwds_18_tfprodcod_sel = AV40TFProdCod_Sel;
         AV95Configuracion_listaprecioswwds_19_tftiplproddsc = AV41TFTipLProdDsc;
         AV96Configuracion_listaprecioswwds_20_tftiplproddsc_sel = AV42TFTipLProdDsc_Sel;
         AV97Configuracion_listaprecioswwds_21_tfclicod = AV47TFCliCod;
         AV98Configuracion_listaprecioswwds_22_tfclicod_sel = AV48TFCliCod_Sel;
         AV99Configuracion_listaprecioswwds_23_tfprelis = AV45TFPreLis;
         AV100Configuracion_listaprecioswwds_24_tfprelis_to = AV46TFPreLis_To;
         AV101Configuracion_listaprecioswwds_25_tflisfech = AV51TFLisFech;
         AV102Configuracion_listaprecioswwds_26_tflisfech_to = AV52TFLisFech_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV77Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                              AV78Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                              AV79Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                              AV80Configuracion_listaprecioswwds_4_tipldsc1 ,
                                              AV81Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                              AV82Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                              AV83Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                              AV84Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                              AV85Configuracion_listaprecioswwds_9_tipldsc2 ,
                                              AV86Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                              AV87Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                              AV88Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                              AV89Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                              AV90Configuracion_listaprecioswwds_14_tipldsc3 ,
                                              AV92Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                              AV91Configuracion_listaprecioswwds_15_tftipldsc ,
                                              AV94Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                              AV93Configuracion_listaprecioswwds_17_tfprodcod ,
                                              AV96Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                              AV95Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                              AV98Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                              AV97Configuracion_listaprecioswwds_21_tfclicod ,
                                              AV99Configuracion_listaprecioswwds_23_tfprelis ,
                                              AV100Configuracion_listaprecioswwds_24_tfprelis_to ,
                                              AV101Configuracion_listaprecioswwds_25_tflisfech ,
                                              AV102Configuracion_listaprecioswwds_26_tflisfech_to ,
                                              A1913TipLProdDsc ,
                                              A1912TipLDsc ,
                                              A28ProdCod ,
                                              A45CliCod ,
                                              A1651PreLis ,
                                              A1205LisFech ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV79Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
         lV79Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
         lV80Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
         lV80Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
         lV84Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
         lV84Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
         lV85Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV85Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
         lV85Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV85Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
         lV89Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
         lV89Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
         lV90Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV90Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
         lV90Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV90Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
         lV91Configuracion_listaprecioswwds_15_tftipldsc = StringUtil.PadR( StringUtil.RTrim( AV91Configuracion_listaprecioswwds_15_tftipldsc), 100, "%");
         lV93Configuracion_listaprecioswwds_17_tfprodcod = StringUtil.PadR( StringUtil.RTrim( AV93Configuracion_listaprecioswwds_17_tfprodcod), 15, "%");
         lV95Configuracion_listaprecioswwds_19_tftiplproddsc = StringUtil.PadR( StringUtil.RTrim( AV95Configuracion_listaprecioswwds_19_tftiplproddsc), 100, "%");
         lV97Configuracion_listaprecioswwds_21_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV97Configuracion_listaprecioswwds_21_tfclicod), 20, "%");
         /* Using cursor P004K2 */
         pr_default.execute(0, new Object[] {lV79Configuracion_listaprecioswwds_3_tiplproddsc1, lV79Configuracion_listaprecioswwds_3_tiplproddsc1, lV80Configuracion_listaprecioswwds_4_tipldsc1, lV80Configuracion_listaprecioswwds_4_tipldsc1, lV84Configuracion_listaprecioswwds_8_tiplproddsc2, lV84Configuracion_listaprecioswwds_8_tiplproddsc2, lV85Configuracion_listaprecioswwds_9_tipldsc2, lV85Configuracion_listaprecioswwds_9_tipldsc2, lV89Configuracion_listaprecioswwds_13_tiplproddsc3, lV89Configuracion_listaprecioswwds_13_tiplproddsc3, lV90Configuracion_listaprecioswwds_14_tipldsc3, lV90Configuracion_listaprecioswwds_14_tipldsc3, lV91Configuracion_listaprecioswwds_15_tftipldsc, AV92Configuracion_listaprecioswwds_16_tftipldsc_sel, lV93Configuracion_listaprecioswwds_17_tfprodcod, AV94Configuracion_listaprecioswwds_18_tfprodcod_sel, lV95Configuracion_listaprecioswwds_19_tftiplproddsc, AV96Configuracion_listaprecioswwds_20_tftiplproddsc_sel, lV97Configuracion_listaprecioswwds_21_tfclicod, AV98Configuracion_listaprecioswwds_22_tfclicod_sel, AV99Configuracion_listaprecioswwds_23_tfprelis, AV100Configuracion_listaprecioswwds_24_tfprelis_to, AV101Configuracion_listaprecioswwds_25_tflisfech, AV102Configuracion_listaprecioswwds_26_tflisfech_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1205LisFech = P004K2_A1205LisFech[0];
            A1651PreLis = P004K2_A1651PreLis[0];
            A45CliCod = P004K2_A45CliCod[0];
            n45CliCod = P004K2_n45CliCod[0];
            A28ProdCod = P004K2_A28ProdCod[0];
            A1912TipLDsc = P004K2_A1912TipLDsc[0];
            A1913TipLProdDsc = P004K2_A1913TipLProdDsc[0];
            A202TipLCod = P004K2_A202TipLCod[0];
            A203TipLItem = P004K2_A203TipLItem[0];
            A1912TipLDsc = P004K2_A1912TipLDsc[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H4K0( false, 35) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1912TipLDsc, "")), 30, Gx_line+10, 193, Gx_line+24, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 197, Gx_line+10, 279, Gx_line+24, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1913TipLProdDsc, "")), 283, Gx_line+10, 447, Gx_line+24, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A45CliCod, "")), 451, Gx_line+10, 615, Gx_line+24, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1651PreLis, "ZZZZ,ZZZ,ZZ9.9999")), 619, Gx_line+10, 701, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A1205LisFech, "99/99/99"), 705, Gx_line+10, 787, Gx_line+24, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+34, 789, Gx_line+34, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+35);
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
         if ( StringUtil.StrCmp(AV31Session.Get("Configuracion.ListaPreciosWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.ListaPreciosWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Configuracion.ListaPreciosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV103GXV1 = 1;
         while ( AV103GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV103GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPLDSC") == 0 )
            {
               AV43TFTipLDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPLDSC_SEL") == 0 )
            {
               AV44TFTipLDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPRODCOD") == 0 )
            {
               AV39TFProdCod = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPRODCOD_SEL") == 0 )
            {
               AV40TFProdCod_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPLPRODDSC") == 0 )
            {
               AV41TFTipLProdDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPLPRODDSC_SEL") == 0 )
            {
               AV42TFTipLProdDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLICOD") == 0 )
            {
               AV47TFCliCod = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLICOD_SEL") == 0 )
            {
               AV48TFCliCod_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPRELIS") == 0 )
            {
               AV45TFPreLis = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV46TFPreLis_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFLISFECH") == 0 )
            {
               AV51TFLisFech = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Value, 2);
               AV52TFLisFech_To = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV103GXV1 = (int)(AV103GXV1+1);
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

      protected void H4K0( bool bFoot ,
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
                  AV68PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV65DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+39);
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
               AV63AppName = "DVelop Software Solutions";
               AV69Phone = "+1 550 8923";
               AV67Mail = "info@mail.com";
               AV71Website = "http://www.web.com";
               AV60AddressLine1 = "French Boulevard 2859";
               AV61AddressLine2 = "Downtown";
               AV62AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+127);
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
         AV70Title = "";
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14TipLProdDsc1 = "";
         AV15FilterTipLProdDscDescription = "";
         AV16TipLProdDsc = "";
         AV17TipLDsc1 = "";
         AV18FilterTipLDscDescription = "";
         AV19TipLDsc = "";
         AV21DynamicFiltersSelector2 = "";
         AV23TipLProdDsc2 = "";
         AV24TipLDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28TipLProdDsc3 = "";
         AV29TipLDsc3 = "";
         AV44TFTipLDsc_Sel = "";
         AV43TFTipLDsc = "";
         AV40TFProdCod_Sel = "";
         AV39TFProdCod = "";
         AV42TFTipLProdDsc_Sel = "";
         AV41TFTipLProdDsc = "";
         AV48TFCliCod_Sel = "";
         AV47TFCliCod = "";
         AV57TFPreLis_To_Description = "";
         AV51TFLisFech = DateTime.MinValue;
         AV52TFLisFech_To = DateTime.MinValue;
         AV58TFLisFech_To_Description = "";
         AV77Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = "";
         AV79Configuracion_listaprecioswwds_3_tiplproddsc1 = "";
         AV80Configuracion_listaprecioswwds_4_tipldsc1 = "";
         AV82Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = "";
         AV84Configuracion_listaprecioswwds_8_tiplproddsc2 = "";
         AV85Configuracion_listaprecioswwds_9_tipldsc2 = "";
         AV87Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = "";
         AV89Configuracion_listaprecioswwds_13_tiplproddsc3 = "";
         AV90Configuracion_listaprecioswwds_14_tipldsc3 = "";
         AV91Configuracion_listaprecioswwds_15_tftipldsc = "";
         AV92Configuracion_listaprecioswwds_16_tftipldsc_sel = "";
         AV93Configuracion_listaprecioswwds_17_tfprodcod = "";
         AV94Configuracion_listaprecioswwds_18_tfprodcod_sel = "";
         AV95Configuracion_listaprecioswwds_19_tftiplproddsc = "";
         AV96Configuracion_listaprecioswwds_20_tftiplproddsc_sel = "";
         AV97Configuracion_listaprecioswwds_21_tfclicod = "";
         AV98Configuracion_listaprecioswwds_22_tfclicod_sel = "";
         AV101Configuracion_listaprecioswwds_25_tflisfech = DateTime.MinValue;
         AV102Configuracion_listaprecioswwds_26_tflisfech_to = DateTime.MinValue;
         scmdbuf = "";
         lV79Configuracion_listaprecioswwds_3_tiplproddsc1 = "";
         lV80Configuracion_listaprecioswwds_4_tipldsc1 = "";
         lV84Configuracion_listaprecioswwds_8_tiplproddsc2 = "";
         lV85Configuracion_listaprecioswwds_9_tipldsc2 = "";
         lV89Configuracion_listaprecioswwds_13_tiplproddsc3 = "";
         lV90Configuracion_listaprecioswwds_14_tipldsc3 = "";
         lV91Configuracion_listaprecioswwds_15_tftipldsc = "";
         lV93Configuracion_listaprecioswwds_17_tfprodcod = "";
         lV95Configuracion_listaprecioswwds_19_tftiplproddsc = "";
         lV97Configuracion_listaprecioswwds_21_tfclicod = "";
         A1913TipLProdDsc = "";
         A1912TipLDsc = "";
         A28ProdCod = "";
         A45CliCod = "";
         A1205LisFech = DateTime.MinValue;
         P004K2_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         P004K2_A1651PreLis = new decimal[1] ;
         P004K2_A45CliCod = new string[] {""} ;
         P004K2_n45CliCod = new bool[] {false} ;
         P004K2_A28ProdCod = new string[] {""} ;
         P004K2_A1912TipLDsc = new string[] {""} ;
         P004K2_A1913TipLProdDsc = new string[] {""} ;
         P004K2_A202TipLCod = new int[1] ;
         P004K2_A203TipLItem = new int[1] ;
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV68PageInfo = "";
         AV65DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV63AppName = "";
         AV69Phone = "";
         AV67Mail = "";
         AV71Website = "";
         AV60AddressLine1 = "";
         AV61AddressLine2 = "";
         AV62AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.listaprecioswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004K2_A1205LisFech, P004K2_A1651PreLis, P004K2_A45CliCod, P004K2_n45CliCod, P004K2_A28ProdCod, P004K2_A1912TipLDsc, P004K2_A1913TipLProdDsc, P004K2_A202TipLCod, P004K2_A203TipLItem
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
      private short AV78Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ;
      private short AV83Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ;
      private short AV88Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A202TipLCod ;
      private int A203TipLItem ;
      private int AV103GXV1 ;
      private decimal AV45TFPreLis ;
      private decimal AV46TFPreLis_To ;
      private decimal AV99Configuracion_listaprecioswwds_23_tfprelis ;
      private decimal AV100Configuracion_listaprecioswwds_24_tfprelis_to ;
      private decimal A1651PreLis ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14TipLProdDsc1 ;
      private string AV16TipLProdDsc ;
      private string AV17TipLDsc1 ;
      private string AV19TipLDsc ;
      private string AV23TipLProdDsc2 ;
      private string AV24TipLDsc2 ;
      private string AV28TipLProdDsc3 ;
      private string AV29TipLDsc3 ;
      private string AV44TFTipLDsc_Sel ;
      private string AV43TFTipLDsc ;
      private string AV40TFProdCod_Sel ;
      private string AV39TFProdCod ;
      private string AV42TFTipLProdDsc_Sel ;
      private string AV41TFTipLProdDsc ;
      private string AV48TFCliCod_Sel ;
      private string AV47TFCliCod ;
      private string AV79Configuracion_listaprecioswwds_3_tiplproddsc1 ;
      private string AV80Configuracion_listaprecioswwds_4_tipldsc1 ;
      private string AV84Configuracion_listaprecioswwds_8_tiplproddsc2 ;
      private string AV85Configuracion_listaprecioswwds_9_tipldsc2 ;
      private string AV89Configuracion_listaprecioswwds_13_tiplproddsc3 ;
      private string AV90Configuracion_listaprecioswwds_14_tipldsc3 ;
      private string AV91Configuracion_listaprecioswwds_15_tftipldsc ;
      private string AV92Configuracion_listaprecioswwds_16_tftipldsc_sel ;
      private string AV93Configuracion_listaprecioswwds_17_tfprodcod ;
      private string AV94Configuracion_listaprecioswwds_18_tfprodcod_sel ;
      private string AV95Configuracion_listaprecioswwds_19_tftiplproddsc ;
      private string AV96Configuracion_listaprecioswwds_20_tftiplproddsc_sel ;
      private string AV97Configuracion_listaprecioswwds_21_tfclicod ;
      private string AV98Configuracion_listaprecioswwds_22_tfclicod_sel ;
      private string scmdbuf ;
      private string lV79Configuracion_listaprecioswwds_3_tiplproddsc1 ;
      private string lV80Configuracion_listaprecioswwds_4_tipldsc1 ;
      private string lV84Configuracion_listaprecioswwds_8_tiplproddsc2 ;
      private string lV85Configuracion_listaprecioswwds_9_tipldsc2 ;
      private string lV89Configuracion_listaprecioswwds_13_tiplproddsc3 ;
      private string lV90Configuracion_listaprecioswwds_14_tipldsc3 ;
      private string lV91Configuracion_listaprecioswwds_15_tftipldsc ;
      private string lV93Configuracion_listaprecioswwds_17_tfprodcod ;
      private string lV95Configuracion_listaprecioswwds_19_tftiplproddsc ;
      private string lV97Configuracion_listaprecioswwds_21_tfclicod ;
      private string A1913TipLProdDsc ;
      private string A1912TipLDsc ;
      private string A28ProdCod ;
      private string A45CliCod ;
      private DateTime AV51TFLisFech ;
      private DateTime AV52TFLisFech_To ;
      private DateTime AV101Configuracion_listaprecioswwds_25_tflisfech ;
      private DateTime AV102Configuracion_listaprecioswwds_26_tflisfech_to ;
      private DateTime A1205LisFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV81Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ;
      private bool AV86Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private bool n45CliCod ;
      private string AV70Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterTipLProdDscDescription ;
      private string AV18FilterTipLDscDescription ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV57TFPreLis_To_Description ;
      private string AV58TFLisFech_To_Description ;
      private string AV77Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ;
      private string AV82Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ;
      private string AV87Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ;
      private string AV68PageInfo ;
      private string AV65DateInfo ;
      private string AV63AppName ;
      private string AV69Phone ;
      private string AV67Mail ;
      private string AV71Website ;
      private string AV60AddressLine1 ;
      private string AV61AddressLine2 ;
      private string AV62AddressLine3 ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P004K2_A1205LisFech ;
      private decimal[] P004K2_A1651PreLis ;
      private string[] P004K2_A45CliCod ;
      private bool[] P004K2_n45CliCod ;
      private string[] P004K2_A28ProdCod ;
      private string[] P004K2_A1912TipLDsc ;
      private string[] P004K2_A1913TipLProdDsc ;
      private int[] P004K2_A202TipLCod ;
      private int[] P004K2_A203TipLItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
   }

   public class listaprecioswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004K2( IGxContext context ,
                                             string AV77Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                             short AV78Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                             string AV79Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                             string AV80Configuracion_listaprecioswwds_4_tipldsc1 ,
                                             bool AV81Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                             string AV82Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                             short AV83Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                             string AV84Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                             string AV85Configuracion_listaprecioswwds_9_tipldsc2 ,
                                             bool AV86Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                             string AV87Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                             short AV88Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                             string AV89Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                             string AV90Configuracion_listaprecioswwds_14_tipldsc3 ,
                                             string AV92Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                             string AV91Configuracion_listaprecioswwds_15_tftipldsc ,
                                             string AV94Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                             string AV93Configuracion_listaprecioswwds_17_tfprodcod ,
                                             string AV96Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                             string AV95Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                             string AV98Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                             string AV97Configuracion_listaprecioswwds_21_tfclicod ,
                                             decimal AV99Configuracion_listaprecioswwds_23_tfprelis ,
                                             decimal AV100Configuracion_listaprecioswwds_24_tfprelis_to ,
                                             DateTime AV101Configuracion_listaprecioswwds_25_tflisfech ,
                                             DateTime AV102Configuracion_listaprecioswwds_26_tflisfech_to ,
                                             string A1913TipLProdDsc ,
                                             string A1912TipLDsc ,
                                             string A28ProdCod ,
                                             string A45CliCod ,
                                             decimal A1651PreLis ,
                                             DateTime A1205LisFech ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[24];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[LisFech], T1.[PreLis], T1.[CliCod], T1.[ProdCod], T2.[TipLDsc], T1.[TipLProdDsc], T1.[TipLCod], T1.[TipLItem] FROM ([CLISTAPRECIOS] T1 INNER JOIN [CTIPOSLISTAS] T2 ON T2.[TipLCod] = T1.[TipLCod])";
         if ( ( StringUtil.StrCmp(AV77Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV78Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV79Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV77Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV78Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV79Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV77Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV78Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV80Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV77Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV78Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV80Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV81Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV83Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV84Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV81Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV83Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV84Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV81Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV83Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV85Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV81Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV83Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV85Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV86Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV88Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV89Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV86Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV88Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV89Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV86Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV88Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV90Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV86Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV88Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV90Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_listaprecioswwds_16_tftipldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Configuracion_listaprecioswwds_15_tftipldsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV91Configuracion_listaprecioswwds_15_tftipldsc)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_listaprecioswwds_16_tftipldsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] = @AV92Configuracion_listaprecioswwds_16_tftipldsc_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Configuracion_listaprecioswwds_18_tfprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_listaprecioswwds_17_tfprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV93Configuracion_listaprecioswwds_17_tfprodcod)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Configuracion_listaprecioswwds_18_tfprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV94Configuracion_listaprecioswwds_18_tfprodcod_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_listaprecioswwds_19_tftiplproddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV95Configuracion_listaprecioswwds_19_tftiplproddsc)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] = @AV96Configuracion_listaprecioswwds_20_tftiplproddsc_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_listaprecioswwds_22_tfclicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_listaprecioswwds_21_tfclicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] like @lV97Configuracion_listaprecioswwds_21_tfclicod)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_listaprecioswwds_22_tfclicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV98Configuracion_listaprecioswwds_22_tfclicod_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV99Configuracion_listaprecioswwds_23_tfprelis) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] >= @AV99Configuracion_listaprecioswwds_23_tfprelis)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV100Configuracion_listaprecioswwds_24_tfprelis_to) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] <= @AV100Configuracion_listaprecioswwds_24_tfprelis_to)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV101Configuracion_listaprecioswwds_25_tflisfech) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] >= @AV101Configuracion_listaprecioswwds_25_tflisfech)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV102Configuracion_listaprecioswwds_26_tflisfech_to) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] <= @AV102Configuracion_listaprecioswwds_26_tflisfech_to)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[TipLCod], T1.[ProdCod]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[TipLDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[TipLDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdCod]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdCod] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipLProdDsc]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipLProdDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliCod]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliCod] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PreLis]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PreLis] DESC";
         }
         else if ( ( AV10OrderedBy == 7 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[LisFech]";
         }
         else if ( ( AV10OrderedBy == 7 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[LisFech] DESC";
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
                     return conditional_P004K2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (DateTime)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] );
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
          Object[] prmP004K2;
          prmP004K2 = new Object[] {
          new ParDef("@lV79Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV84Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV84Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV85Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV85Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV89Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV89Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV90Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV90Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV91Configuracion_listaprecioswwds_15_tftipldsc",GXType.NChar,100,0) ,
          new ParDef("@AV92Configuracion_listaprecioswwds_16_tftipldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV93Configuracion_listaprecioswwds_17_tfprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV94Configuracion_listaprecioswwds_18_tfprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV95Configuracion_listaprecioswwds_19_tftiplproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV96Configuracion_listaprecioswwds_20_tftiplproddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV97Configuracion_listaprecioswwds_21_tfclicod",GXType.NChar,20,0) ,
          new ParDef("@AV98Configuracion_listaprecioswwds_22_tfclicod_sel",GXType.NChar,20,0) ,
          new ParDef("@AV99Configuracion_listaprecioswwds_23_tfprelis",GXType.Decimal,15,4) ,
          new ParDef("@AV100Configuracion_listaprecioswwds_24_tfprelis_to",GXType.Decimal,15,4) ,
          new ParDef("@AV101Configuracion_listaprecioswwds_25_tflisfech",GXType.Date,8,0) ,
          new ParDef("@AV102Configuracion_listaprecioswwds_26_tflisfech_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004K2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 15);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
       }
    }

 }

}
