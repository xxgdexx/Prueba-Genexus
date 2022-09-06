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
namespace GeneXus.Programs.almacen {
   public class productoswwexportreport : GXWebProcedure
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

      public productoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public productoswwexportreport( IGxContext context )
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
         productoswwexportreport objproductoswwexportreport;
         objproductoswwexportreport = new productoswwexportreport();
         objproductoswwexportreport.context.SetSubmitInitialConfig(context);
         objproductoswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objproductoswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productoswwexportreport)stateInfo).executePrivate();
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
            AV115Title = "Lista de Productos";
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
            HDV0( true, 0) ;
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
         if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(1));
            AV12DynamicFiltersSelector1 = AV40GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "PRODDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV14ProdDsc1 = AV40GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14ProdDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterProdDscDescription = StringUtil.Format( "%1 (%2)", "Descripcion producto", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterProdDscDescription = StringUtil.Format( "%1 (%2)", "Descripcion producto", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16ProdDsc = AV14ProdDsc1;
                  HDV0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterProdDscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ProdDsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "PRODCUENTAVDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV17ProdCuentaVDsc1 = AV40GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17ProdCuentaVDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV18FilterProdCuentaVDscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Venta", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV18FilterProdCuentaVDscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Venta", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV19ProdCuentaVDsc = AV17ProdCuentaVDsc1;
                  HDV0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterProdCuentaVDscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19ProdCuentaVDsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "PRODCUENTACDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV20ProdCuentaCDsc1 = AV40GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ProdCuentaCDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV21FilterProdCuentaCDscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Compra", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV21FilterProdCuentaCDscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Compra", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV22ProdCuentaCDsc = AV20ProdCuentaCDsc1;
                  HDV0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterProdCuentaCDscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22ProdCuentaCDsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "PRODCUENTAADSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV23ProdCuentaADsc1 = AV40GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ProdCuentaADsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV24FilterProdCuentaADscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Almacen", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV24FilterProdCuentaADscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Almacen", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV25ProdCuentaADsc = AV23ProdCuentaADsc1;
                  HDV0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24FilterProdCuentaADscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25ProdCuentaADsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "LINDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV132LinDsc1 = AV40GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132LinDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV133FilterLinDscDescription = StringUtil.Format( "%1 (%2)", "Descripcion de Linea", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV133FilterLinDscDescription = StringUtil.Format( "%1 (%2)", "Descripcion de Linea", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV134LinDsc = AV132LinDsc1;
                  HDV0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV133FilterLinDscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV134LinDsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV26DynamicFiltersEnabled2 = true;
               AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(2));
               AV27DynamicFiltersSelector2 = AV40GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "PRODDSC") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV29ProdDsc2 = AV40GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ProdDsc2)) )
                  {
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterProdDscDescription = StringUtil.Format( "%1 (%2)", "Descripcion producto", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterProdDscDescription = StringUtil.Format( "%1 (%2)", "Descripcion producto", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16ProdDsc = AV29ProdDsc2;
                     HDV0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterProdDscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ProdDsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "PRODCUENTAVDSC") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV30ProdCuentaVDsc2 = AV40GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ProdCuentaVDsc2)) )
                  {
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV18FilterProdCuentaVDscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Venta", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV18FilterProdCuentaVDscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Venta", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV19ProdCuentaVDsc = AV30ProdCuentaVDsc2;
                     HDV0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterProdCuentaVDscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19ProdCuentaVDsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "PRODCUENTACDSC") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV31ProdCuentaCDsc2 = AV40GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ProdCuentaCDsc2)) )
                  {
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV21FilterProdCuentaCDscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Compra", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV21FilterProdCuentaCDscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Compra", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV22ProdCuentaCDsc = AV31ProdCuentaCDsc2;
                     HDV0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterProdCuentaCDscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22ProdCuentaCDsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "PRODCUENTAADSC") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV32ProdCuentaADsc2 = AV40GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32ProdCuentaADsc2)) )
                  {
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV24FilterProdCuentaADscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Almacen", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV24FilterProdCuentaADscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Almacen", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV25ProdCuentaADsc = AV32ProdCuentaADsc2;
                     HDV0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24FilterProdCuentaADscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25ProdCuentaADsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "LINDSC") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV135LinDsc2 = AV40GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135LinDsc2)) )
                  {
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV133FilterLinDscDescription = StringUtil.Format( "%1 (%2)", "Descripcion de Linea", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV133FilterLinDscDescription = StringUtil.Format( "%1 (%2)", "Descripcion de Linea", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV134LinDsc = AV135LinDsc2;
                     HDV0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV133FilterLinDscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV134LinDsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV33DynamicFiltersEnabled3 = true;
                  AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(3));
                  AV34DynamicFiltersSelector3 = AV40GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV34DynamicFiltersSelector3, "PRODDSC") == 0 )
                  {
                     AV35DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV36ProdDsc3 = AV40GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36ProdDsc3)) )
                     {
                        if ( AV35DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterProdDscDescription = StringUtil.Format( "%1 (%2)", "Descripcion producto", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterProdDscDescription = StringUtil.Format( "%1 (%2)", "Descripcion producto", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16ProdDsc = AV36ProdDsc3;
                        HDV0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterProdDscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ProdDsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV34DynamicFiltersSelector3, "PRODCUENTAVDSC") == 0 )
                  {
                     AV35DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV37ProdCuentaVDsc3 = AV40GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37ProdCuentaVDsc3)) )
                     {
                        if ( AV35DynamicFiltersOperator3 == 0 )
                        {
                           AV18FilterProdCuentaVDscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Venta", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 1 )
                        {
                           AV18FilterProdCuentaVDscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Venta", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV19ProdCuentaVDsc = AV37ProdCuentaVDsc3;
                        HDV0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterProdCuentaVDscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19ProdCuentaVDsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV34DynamicFiltersSelector3, "PRODCUENTACDSC") == 0 )
                  {
                     AV35DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV38ProdCuentaCDsc3 = AV40GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38ProdCuentaCDsc3)) )
                     {
                        if ( AV35DynamicFiltersOperator3 == 0 )
                        {
                           AV21FilterProdCuentaCDscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Compra", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 1 )
                        {
                           AV21FilterProdCuentaCDscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Compra", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV22ProdCuentaCDsc = AV38ProdCuentaCDsc3;
                        HDV0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterProdCuentaCDscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22ProdCuentaCDsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV34DynamicFiltersSelector3, "PRODCUENTAADSC") == 0 )
                  {
                     AV35DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV39ProdCuentaADsc3 = AV40GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39ProdCuentaADsc3)) )
                     {
                        if ( AV35DynamicFiltersOperator3 == 0 )
                        {
                           AV24FilterProdCuentaADscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Almacen", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 1 )
                        {
                           AV24FilterProdCuentaADscDescription = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Almacen", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV25ProdCuentaADsc = AV39ProdCuentaADsc3;
                        HDV0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24FilterProdCuentaADscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25ProdCuentaADsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV34DynamicFiltersSelector3, "LINDSC") == 0 )
                  {
                     AV35DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV136LinDsc3 = AV40GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136LinDsc3)) )
                     {
                        if ( AV35DynamicFiltersOperator3 == 0 )
                        {
                           AV133FilterLinDscDescription = StringUtil.Format( "%1 (%2)", "Descripcion de Linea", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 1 )
                        {
                           AV133FilterLinDscDescription = StringUtil.Format( "%1 (%2)", "Descripcion de Linea", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV134LinDsc = AV136LinDsc3;
                        HDV0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV133FilterLinDscDescription, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV134LinDsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TFProdCod_Sel)) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Producto", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TFProdCod_Sel, "@!")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFProdCod)) )
            {
               HDV0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo Producto", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFProdCod, "@!")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV47TFLinCod) && (0==AV48TFLinCod_To) ) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo de Linea", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV47TFLinCod), "ZZZZZ9")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV93TFLinCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo de Linea", "Hasta", "", "", "", "", "", "", "");
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV93TFLinCod_To_Description, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV48TFLinCod_To), "ZZZZZ9")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProdDsc_Sel)) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descripcion producto", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFProdDsc_Sel, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProdDsc)) )
            {
               HDV0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripcion producto", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFProdDsc, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV51TFSublCod) && (0==AV52TFSublCod_To) ) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Sub Linea", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV51TFSublCod), "ZZZZZ9")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV94TFSublCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo Sub Linea", "Hasta", "", "", "", "", "", "", "");
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94TFSublCod_To_Description, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV52TFSublCod_To), "ZZZZZ9")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV53TFFamCod) && (0==AV54TFFamCod_To) ) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Familia", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV53TFFamCod), "ZZZZZ9")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV95TFFamCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo Familia", "Hasta", "", "", "", "", "", "", "");
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95TFFamCod_To_Description, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV54TFFamCod_To), "ZZZZZ9")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV55TFUniCod) && (0==AV56TFUniCod_To) ) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Unidad Medida", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV55TFUniCod), "ZZZZZ9")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV96TFUniCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo Unidad Medida", "Hasta", "", "", "", "", "", "", "");
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV96TFUniCod_To_Description, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV56TFUniCod_To), "ZZZZZ9")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV123TFProdVta_Sel) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Destinado Venta", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV123TFProdVta_Sel), "9")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV124TFProdCmp_Sel) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Destinado Compra", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV124TFProdCmp_Sel), "9")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV61TFProdPeso) && (Convert.ToDecimal(0)==AV62TFProdPeso_To) ) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Peso producto", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61TFProdPeso, "ZZZZZZZZ9.99999")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV99TFProdPeso_To_Description = StringUtil.Format( "%1 (%2)", "Peso producto", "Hasta", "", "", "", "", "", "", "");
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV99TFProdPeso_To_Description, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62TFProdPeso_To, "ZZZZZZZZ9.99999")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV63TFProdVolumen) && (Convert.ToDecimal(0)==AV64TFProdVolumen_To) ) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Volumen producto", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63TFProdVolumen, "ZZZZZZZZ9.99999")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV100TFProdVolumen_To_Description = StringUtil.Format( "%1 (%2)", "Volumen producto", "Hasta", "", "", "", "", "", "", "");
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV100TFProdVolumen_To_Description, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TFProdVolumen_To, "ZZZZZZZZ9.99999")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV65TFProdStkMax) && (Convert.ToDecimal(0)==AV66TFProdStkMax_To) ) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Stock Maximo", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TFProdStkMax, "ZZZZ,ZZZ,ZZ9.9999")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV101TFProdStkMax_To_Description = StringUtil.Format( "%1 (%2)", "Stock Maximo", "Hasta", "", "", "", "", "", "", "");
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV101TFProdStkMax_To_Description, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66TFProdStkMax_To, "ZZZZ,ZZZ,ZZ9.9999")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV67TFProdStkMin) && (Convert.ToDecimal(0)==AV68TFProdStkMin_To) ) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Stock Minimo", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67TFProdStkMin, "ZZZZ,ZZZ,ZZ9.9999")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV102TFProdStkMin_To_Description = StringUtil.Format( "%1 (%2)", "Stock Minimo", "Hasta", "", "", "", "", "", "", "");
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV102TFProdStkMin_To_Description, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68TFProdStkMin_To, "ZZZZ,ZZZ,ZZ9.9999")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70TFProdRef1_Sel)) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 1", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70TFProdRef1_Sel, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69TFProdRef1)) )
            {
               HDV0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 1", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TFProdRef1, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TFProdRef2_Sel)) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 2", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72TFProdRef2_Sel, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71TFProdRef2)) )
            {
               HDV0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 2", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71TFProdRef2, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74TFProdRef3_Sel)) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 3", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74TFProdRef3_Sel, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73TFProdRef3)) )
            {
               HDV0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 3", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73TFProdRef3, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76TFProdRef4_Sel)) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 4", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76TFProdRef4_Sel, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75TFProdRef4)) )
            {
               HDV0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 4", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75TFProdRef4, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78TFProdRef5_Sel)) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 5", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78TFProdRef5_Sel, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77TFProdRef5)) )
            {
               HDV0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 5", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77TFProdRef5, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80TFProdRef6_Sel)) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 6", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80TFProdRef6_Sel, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79TFProdRef6)) )
            {
               HDV0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 6", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79TFProdRef6, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82TFProdRef7_Sel)) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 7", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82TFProdRef7_Sel, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TFProdRef7)) )
            {
               HDV0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 7", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81TFProdRef7, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84TFProdRef8_Sel)) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 8", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84TFProdRef8_Sel, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83TFProdRef8)) )
            {
               HDV0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 8", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83TFProdRef8, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86TFProdRef9_Sel)) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 9", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV86TFProdRef9_Sel, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85TFProdRef9)) )
            {
               HDV0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 9", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85TFProdRef9, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88TFProdRef10_Sel)) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 10", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV88TFProdRef10_Sel, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87TFProdRef10)) )
            {
               HDV0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 10", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV87TFProdRef10, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV128TFProdSts_Sels.FromJSonString(AV126TFProdSts_SelsJson, null);
         if ( ! ( AV128TFProdSts_Sels.Count == 0 ) )
         {
            AV131i = 1;
            AV141GXV1 = 1;
            while ( AV141GXV1 <= AV128TFProdSts_Sels.Count )
            {
               AV129TFProdSts_Sel = (short)(AV128TFProdSts_Sels.GetNumeric(AV141GXV1));
               if ( AV131i == 1 )
               {
                  AV127TFProdSts_SelDscs = "";
               }
               else
               {
                  AV127TFProdSts_SelDscs += ", ";
               }
               if ( AV129TFProdSts_Sel == 1 )
               {
                  AV130FilterTFProdSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV129TFProdSts_Sel == 0 )
               {
                  AV130FilterTFProdSts_SelValueDescription = "INACTIVO";
               }
               AV127TFProdSts_SelDscs += AV130FilterTFProdSts_SelValueDescription;
               AV131i = (long)(AV131i+1);
               AV141GXV1 = (int)(AV141GXV1+1);
            }
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Situacion", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV127TFProdSts_SelDscs, "")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV91TFProdCosto) && (Convert.ToDecimal(0)==AV92TFProdCosto_To) ) )
         {
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Ult. Costo MN", 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV91TFProdCosto, "ZZZZZZZZZZZ9.99999")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV104TFProdCosto_To_Description = StringUtil.Format( "%1 (%2)", "Ult. Costo MN", "Hasta", "", "", "", "", "", "", "");
            HDV0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV104TFProdCosto_To_Description, "")), 25, Gx_line+0, 286, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV92TFProdCosto_To, "ZZZZZZZZZZZ9.99999")), 286, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HDV0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 10, 77, 152, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HDV0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 10, 77, 152, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo Producto", 30, Gx_line+10, 56, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo de Linea", 60, Gx_line+10, 86, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Descripcion producto", 90, Gx_line+10, 116, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo Sub Linea", 120, Gx_line+10, 146, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo Familia", 150, Gx_line+10, 176, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo Unidad Medida", 180, Gx_line+10, 206, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Destinado Venta", 210, Gx_line+10, 236, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Destinado Compra", 240, Gx_line+10, 266, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Peso producto", 270, Gx_line+10, 296, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Volumen producto", 300, Gx_line+10, 326, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Stock Maximo", 330, Gx_line+10, 356, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Stock Minimo", 360, Gx_line+10, 386, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Foto Producto", 390, Gx_line+10, 416, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 1", 420, Gx_line+10, 446, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 2", 450, Gx_line+10, 476, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 3", 480, Gx_line+10, 506, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 4", 510, Gx_line+10, 536, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 5", 540, Gx_line+10, 566, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 6", 570, Gx_line+10, 596, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 7", 600, Gx_line+10, 628, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 8", 632, Gx_line+10, 660, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 9", 664, Gx_line+10, 692, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 10", 696, Gx_line+10, 724, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Situacion", 728, Gx_line+10, 756, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Ult. Costo MN", 760, Gx_line+10, 787, Gx_line+27, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV143Almacen_productoswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV144Almacen_productoswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV145Almacen_productoswwds_3_proddsc1 = AV14ProdDsc1;
         AV146Almacen_productoswwds_4_prodcuentavdsc1 = AV17ProdCuentaVDsc1;
         AV147Almacen_productoswwds_5_prodcuentacdsc1 = AV20ProdCuentaCDsc1;
         AV148Almacen_productoswwds_6_prodcuentaadsc1 = AV23ProdCuentaADsc1;
         AV149Almacen_productoswwds_7_lindsc1 = AV132LinDsc1;
         AV150Almacen_productoswwds_8_dynamicfiltersenabled2 = AV26DynamicFiltersEnabled2;
         AV151Almacen_productoswwds_9_dynamicfiltersselector2 = AV27DynamicFiltersSelector2;
         AV152Almacen_productoswwds_10_dynamicfiltersoperator2 = AV28DynamicFiltersOperator2;
         AV153Almacen_productoswwds_11_proddsc2 = AV29ProdDsc2;
         AV154Almacen_productoswwds_12_prodcuentavdsc2 = AV30ProdCuentaVDsc2;
         AV155Almacen_productoswwds_13_prodcuentacdsc2 = AV31ProdCuentaCDsc2;
         AV156Almacen_productoswwds_14_prodcuentaadsc2 = AV32ProdCuentaADsc2;
         AV157Almacen_productoswwds_15_lindsc2 = AV135LinDsc2;
         AV158Almacen_productoswwds_16_dynamicfiltersenabled3 = AV33DynamicFiltersEnabled3;
         AV159Almacen_productoswwds_17_dynamicfiltersselector3 = AV34DynamicFiltersSelector3;
         AV160Almacen_productoswwds_18_dynamicfiltersoperator3 = AV35DynamicFiltersOperator3;
         AV161Almacen_productoswwds_19_proddsc3 = AV36ProdDsc3;
         AV162Almacen_productoswwds_20_prodcuentavdsc3 = AV37ProdCuentaVDsc3;
         AV163Almacen_productoswwds_21_prodcuentacdsc3 = AV38ProdCuentaCDsc3;
         AV164Almacen_productoswwds_22_prodcuentaadsc3 = AV39ProdCuentaADsc3;
         AV165Almacen_productoswwds_23_lindsc3 = AV136LinDsc3;
         AV166Almacen_productoswwds_24_tfprodcod = AV45TFProdCod;
         AV167Almacen_productoswwds_25_tfprodcod_sel = AV46TFProdCod_Sel;
         AV168Almacen_productoswwds_26_tflincod = AV47TFLinCod;
         AV169Almacen_productoswwds_27_tflincod_to = AV48TFLinCod_To;
         AV170Almacen_productoswwds_28_tfproddsc = AV49TFProdDsc;
         AV171Almacen_productoswwds_29_tfproddsc_sel = AV50TFProdDsc_Sel;
         AV172Almacen_productoswwds_30_tfsublcod = AV51TFSublCod;
         AV173Almacen_productoswwds_31_tfsublcod_to = AV52TFSublCod_To;
         AV174Almacen_productoswwds_32_tffamcod = AV53TFFamCod;
         AV175Almacen_productoswwds_33_tffamcod_to = AV54TFFamCod_To;
         AV176Almacen_productoswwds_34_tfunicod = AV55TFUniCod;
         AV177Almacen_productoswwds_35_tfunicod_to = AV56TFUniCod_To;
         AV178Almacen_productoswwds_36_tfprodvta_sel = AV123TFProdVta_Sel;
         AV179Almacen_productoswwds_37_tfprodcmp_sel = AV124TFProdCmp_Sel;
         AV180Almacen_productoswwds_38_tfprodpeso = AV61TFProdPeso;
         AV181Almacen_productoswwds_39_tfprodpeso_to = AV62TFProdPeso_To;
         AV182Almacen_productoswwds_40_tfprodvolumen = AV63TFProdVolumen;
         AV183Almacen_productoswwds_41_tfprodvolumen_to = AV64TFProdVolumen_To;
         AV184Almacen_productoswwds_42_tfprodstkmax = AV65TFProdStkMax;
         AV185Almacen_productoswwds_43_tfprodstkmax_to = AV66TFProdStkMax_To;
         AV186Almacen_productoswwds_44_tfprodstkmin = AV67TFProdStkMin;
         AV187Almacen_productoswwds_45_tfprodstkmin_to = AV68TFProdStkMin_To;
         AV188Almacen_productoswwds_46_tfprodref1 = AV69TFProdRef1;
         AV189Almacen_productoswwds_47_tfprodref1_sel = AV70TFProdRef1_Sel;
         AV190Almacen_productoswwds_48_tfprodref2 = AV71TFProdRef2;
         AV191Almacen_productoswwds_49_tfprodref2_sel = AV72TFProdRef2_Sel;
         AV192Almacen_productoswwds_50_tfprodref3 = AV73TFProdRef3;
         AV193Almacen_productoswwds_51_tfprodref3_sel = AV74TFProdRef3_Sel;
         AV194Almacen_productoswwds_52_tfprodref4 = AV75TFProdRef4;
         AV195Almacen_productoswwds_53_tfprodref4_sel = AV76TFProdRef4_Sel;
         AV196Almacen_productoswwds_54_tfprodref5 = AV77TFProdRef5;
         AV197Almacen_productoswwds_55_tfprodref5_sel = AV78TFProdRef5_Sel;
         AV198Almacen_productoswwds_56_tfprodref6 = AV79TFProdRef6;
         AV199Almacen_productoswwds_57_tfprodref6_sel = AV80TFProdRef6_Sel;
         AV200Almacen_productoswwds_58_tfprodref7 = AV81TFProdRef7;
         AV201Almacen_productoswwds_59_tfprodref7_sel = AV82TFProdRef7_Sel;
         AV202Almacen_productoswwds_60_tfprodref8 = AV83TFProdRef8;
         AV203Almacen_productoswwds_61_tfprodref8_sel = AV84TFProdRef8_Sel;
         AV204Almacen_productoswwds_62_tfprodref9 = AV85TFProdRef9;
         AV205Almacen_productoswwds_63_tfprodref9_sel = AV86TFProdRef9_Sel;
         AV206Almacen_productoswwds_64_tfprodref10 = AV87TFProdRef10;
         AV207Almacen_productoswwds_65_tfprodref10_sel = AV88TFProdRef10_Sel;
         AV208Almacen_productoswwds_66_tfprodsts_sels = AV128TFProdSts_Sels;
         AV209Almacen_productoswwds_67_tfprodcosto = AV91TFProdCosto;
         AV210Almacen_productoswwds_68_tfprodcosto_to = AV92TFProdCosto_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1718ProdSts ,
                                              AV208Almacen_productoswwds_66_tfprodsts_sels ,
                                              AV143Almacen_productoswwds_1_dynamicfiltersselector1 ,
                                              AV144Almacen_productoswwds_2_dynamicfiltersoperator1 ,
                                              AV145Almacen_productoswwds_3_proddsc1 ,
                                              AV146Almacen_productoswwds_4_prodcuentavdsc1 ,
                                              AV147Almacen_productoswwds_5_prodcuentacdsc1 ,
                                              AV148Almacen_productoswwds_6_prodcuentaadsc1 ,
                                              AV149Almacen_productoswwds_7_lindsc1 ,
                                              AV150Almacen_productoswwds_8_dynamicfiltersenabled2 ,
                                              AV151Almacen_productoswwds_9_dynamicfiltersselector2 ,
                                              AV152Almacen_productoswwds_10_dynamicfiltersoperator2 ,
                                              AV153Almacen_productoswwds_11_proddsc2 ,
                                              AV154Almacen_productoswwds_12_prodcuentavdsc2 ,
                                              AV155Almacen_productoswwds_13_prodcuentacdsc2 ,
                                              AV156Almacen_productoswwds_14_prodcuentaadsc2 ,
                                              AV157Almacen_productoswwds_15_lindsc2 ,
                                              AV158Almacen_productoswwds_16_dynamicfiltersenabled3 ,
                                              AV159Almacen_productoswwds_17_dynamicfiltersselector3 ,
                                              AV160Almacen_productoswwds_18_dynamicfiltersoperator3 ,
                                              AV161Almacen_productoswwds_19_proddsc3 ,
                                              AV162Almacen_productoswwds_20_prodcuentavdsc3 ,
                                              AV163Almacen_productoswwds_21_prodcuentacdsc3 ,
                                              AV164Almacen_productoswwds_22_prodcuentaadsc3 ,
                                              AV165Almacen_productoswwds_23_lindsc3 ,
                                              AV167Almacen_productoswwds_25_tfprodcod_sel ,
                                              AV166Almacen_productoswwds_24_tfprodcod ,
                                              AV168Almacen_productoswwds_26_tflincod ,
                                              AV169Almacen_productoswwds_27_tflincod_to ,
                                              AV171Almacen_productoswwds_29_tfproddsc_sel ,
                                              AV170Almacen_productoswwds_28_tfproddsc ,
                                              AV172Almacen_productoswwds_30_tfsublcod ,
                                              AV173Almacen_productoswwds_31_tfsublcod_to ,
                                              AV174Almacen_productoswwds_32_tffamcod ,
                                              AV175Almacen_productoswwds_33_tffamcod_to ,
                                              AV176Almacen_productoswwds_34_tfunicod ,
                                              AV177Almacen_productoswwds_35_tfunicod_to ,
                                              AV178Almacen_productoswwds_36_tfprodvta_sel ,
                                              AV179Almacen_productoswwds_37_tfprodcmp_sel ,
                                              AV180Almacen_productoswwds_38_tfprodpeso ,
                                              AV181Almacen_productoswwds_39_tfprodpeso_to ,
                                              AV182Almacen_productoswwds_40_tfprodvolumen ,
                                              AV183Almacen_productoswwds_41_tfprodvolumen_to ,
                                              AV184Almacen_productoswwds_42_tfprodstkmax ,
                                              AV185Almacen_productoswwds_43_tfprodstkmax_to ,
                                              AV186Almacen_productoswwds_44_tfprodstkmin ,
                                              AV187Almacen_productoswwds_45_tfprodstkmin_to ,
                                              AV189Almacen_productoswwds_47_tfprodref1_sel ,
                                              AV188Almacen_productoswwds_46_tfprodref1 ,
                                              AV191Almacen_productoswwds_49_tfprodref2_sel ,
                                              AV190Almacen_productoswwds_48_tfprodref2 ,
                                              AV193Almacen_productoswwds_51_tfprodref3_sel ,
                                              AV192Almacen_productoswwds_50_tfprodref3 ,
                                              AV195Almacen_productoswwds_53_tfprodref4_sel ,
                                              AV194Almacen_productoswwds_52_tfprodref4 ,
                                              AV197Almacen_productoswwds_55_tfprodref5_sel ,
                                              AV196Almacen_productoswwds_54_tfprodref5 ,
                                              AV199Almacen_productoswwds_57_tfprodref6_sel ,
                                              AV198Almacen_productoswwds_56_tfprodref6 ,
                                              AV201Almacen_productoswwds_59_tfprodref7_sel ,
                                              AV200Almacen_productoswwds_58_tfprodref7 ,
                                              AV203Almacen_productoswwds_61_tfprodref8_sel ,
                                              AV202Almacen_productoswwds_60_tfprodref8 ,
                                              AV205Almacen_productoswwds_63_tfprodref9_sel ,
                                              AV204Almacen_productoswwds_62_tfprodref9 ,
                                              AV207Almacen_productoswwds_65_tfprodref10_sel ,
                                              AV206Almacen_productoswwds_64_tfprodref10 ,
                                              AV208Almacen_productoswwds_66_tfprodsts_sels.Count ,
                                              AV209Almacen_productoswwds_67_tfprodcosto ,
                                              AV210Almacen_productoswwds_68_tfprodcosto_to ,
                                              A55ProdDsc ,
                                              A1686ProdCuentaVDsc ,
                                              A1685ProdCuentaCDsc ,
                                              A1684ProdCuentaADsc ,
                                              A1153LinDsc ,
                                              A28ProdCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A49UniCod ,
                                              A1724ProdVta ,
                                              A1679ProdCmp ,
                                              A1702ProdPeso ,
                                              A1723ProdVolumen ,
                                              A1716ProdStkMax ,
                                              A1717ProdStkMin ,
                                              A1705ProdRef1 ,
                                              A1707ProdRef2 ,
                                              A1708ProdRef3 ,
                                              A1709ProdRef4 ,
                                              A1710ProdRef5 ,
                                              A1711ProdRef6 ,
                                              A1712ProdRef7 ,
                                              A1713ProdRef8 ,
                                              A1714ProdRef9 ,
                                              A1706ProdRef10 ,
                                              A1681ProdCosto ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV145Almacen_productoswwds_3_proddsc1 = StringUtil.PadR( StringUtil.RTrim( AV145Almacen_productoswwds_3_proddsc1), 100, "%");
         lV145Almacen_productoswwds_3_proddsc1 = StringUtil.PadR( StringUtil.RTrim( AV145Almacen_productoswwds_3_proddsc1), 100, "%");
         lV146Almacen_productoswwds_4_prodcuentavdsc1 = StringUtil.PadR( StringUtil.RTrim( AV146Almacen_productoswwds_4_prodcuentavdsc1), 100, "%");
         lV146Almacen_productoswwds_4_prodcuentavdsc1 = StringUtil.PadR( StringUtil.RTrim( AV146Almacen_productoswwds_4_prodcuentavdsc1), 100, "%");
         lV147Almacen_productoswwds_5_prodcuentacdsc1 = StringUtil.PadR( StringUtil.RTrim( AV147Almacen_productoswwds_5_prodcuentacdsc1), 100, "%");
         lV147Almacen_productoswwds_5_prodcuentacdsc1 = StringUtil.PadR( StringUtil.RTrim( AV147Almacen_productoswwds_5_prodcuentacdsc1), 100, "%");
         lV148Almacen_productoswwds_6_prodcuentaadsc1 = StringUtil.PadR( StringUtil.RTrim( AV148Almacen_productoswwds_6_prodcuentaadsc1), 100, "%");
         lV148Almacen_productoswwds_6_prodcuentaadsc1 = StringUtil.PadR( StringUtil.RTrim( AV148Almacen_productoswwds_6_prodcuentaadsc1), 100, "%");
         lV149Almacen_productoswwds_7_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV149Almacen_productoswwds_7_lindsc1), 100, "%");
         lV149Almacen_productoswwds_7_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV149Almacen_productoswwds_7_lindsc1), 100, "%");
         lV153Almacen_productoswwds_11_proddsc2 = StringUtil.PadR( StringUtil.RTrim( AV153Almacen_productoswwds_11_proddsc2), 100, "%");
         lV153Almacen_productoswwds_11_proddsc2 = StringUtil.PadR( StringUtil.RTrim( AV153Almacen_productoswwds_11_proddsc2), 100, "%");
         lV154Almacen_productoswwds_12_prodcuentavdsc2 = StringUtil.PadR( StringUtil.RTrim( AV154Almacen_productoswwds_12_prodcuentavdsc2), 100, "%");
         lV154Almacen_productoswwds_12_prodcuentavdsc2 = StringUtil.PadR( StringUtil.RTrim( AV154Almacen_productoswwds_12_prodcuentavdsc2), 100, "%");
         lV155Almacen_productoswwds_13_prodcuentacdsc2 = StringUtil.PadR( StringUtil.RTrim( AV155Almacen_productoswwds_13_prodcuentacdsc2), 100, "%");
         lV155Almacen_productoswwds_13_prodcuentacdsc2 = StringUtil.PadR( StringUtil.RTrim( AV155Almacen_productoswwds_13_prodcuentacdsc2), 100, "%");
         lV156Almacen_productoswwds_14_prodcuentaadsc2 = StringUtil.PadR( StringUtil.RTrim( AV156Almacen_productoswwds_14_prodcuentaadsc2), 100, "%");
         lV156Almacen_productoswwds_14_prodcuentaadsc2 = StringUtil.PadR( StringUtil.RTrim( AV156Almacen_productoswwds_14_prodcuentaadsc2), 100, "%");
         lV157Almacen_productoswwds_15_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV157Almacen_productoswwds_15_lindsc2), 100, "%");
         lV157Almacen_productoswwds_15_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV157Almacen_productoswwds_15_lindsc2), 100, "%");
         lV161Almacen_productoswwds_19_proddsc3 = StringUtil.PadR( StringUtil.RTrim( AV161Almacen_productoswwds_19_proddsc3), 100, "%");
         lV161Almacen_productoswwds_19_proddsc3 = StringUtil.PadR( StringUtil.RTrim( AV161Almacen_productoswwds_19_proddsc3), 100, "%");
         lV162Almacen_productoswwds_20_prodcuentavdsc3 = StringUtil.PadR( StringUtil.RTrim( AV162Almacen_productoswwds_20_prodcuentavdsc3), 100, "%");
         lV162Almacen_productoswwds_20_prodcuentavdsc3 = StringUtil.PadR( StringUtil.RTrim( AV162Almacen_productoswwds_20_prodcuentavdsc3), 100, "%");
         lV163Almacen_productoswwds_21_prodcuentacdsc3 = StringUtil.PadR( StringUtil.RTrim( AV163Almacen_productoswwds_21_prodcuentacdsc3), 100, "%");
         lV163Almacen_productoswwds_21_prodcuentacdsc3 = StringUtil.PadR( StringUtil.RTrim( AV163Almacen_productoswwds_21_prodcuentacdsc3), 100, "%");
         lV164Almacen_productoswwds_22_prodcuentaadsc3 = StringUtil.PadR( StringUtil.RTrim( AV164Almacen_productoswwds_22_prodcuentaadsc3), 100, "%");
         lV164Almacen_productoswwds_22_prodcuentaadsc3 = StringUtil.PadR( StringUtil.RTrim( AV164Almacen_productoswwds_22_prodcuentaadsc3), 100, "%");
         lV165Almacen_productoswwds_23_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV165Almacen_productoswwds_23_lindsc3), 100, "%");
         lV165Almacen_productoswwds_23_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV165Almacen_productoswwds_23_lindsc3), 100, "%");
         lV166Almacen_productoswwds_24_tfprodcod = StringUtil.PadR( StringUtil.RTrim( AV166Almacen_productoswwds_24_tfprodcod), 15, "%");
         lV170Almacen_productoswwds_28_tfproddsc = StringUtil.PadR( StringUtil.RTrim( AV170Almacen_productoswwds_28_tfproddsc), 100, "%");
         lV188Almacen_productoswwds_46_tfprodref1 = StringUtil.PadR( StringUtil.RTrim( AV188Almacen_productoswwds_46_tfprodref1), 20, "%");
         lV190Almacen_productoswwds_48_tfprodref2 = StringUtil.PadR( StringUtil.RTrim( AV190Almacen_productoswwds_48_tfprodref2), 20, "%");
         lV192Almacen_productoswwds_50_tfprodref3 = StringUtil.PadR( StringUtil.RTrim( AV192Almacen_productoswwds_50_tfprodref3), 20, "%");
         lV194Almacen_productoswwds_52_tfprodref4 = StringUtil.PadR( StringUtil.RTrim( AV194Almacen_productoswwds_52_tfprodref4), 20, "%");
         lV196Almacen_productoswwds_54_tfprodref5 = StringUtil.PadR( StringUtil.RTrim( AV196Almacen_productoswwds_54_tfprodref5), 20, "%");
         lV198Almacen_productoswwds_56_tfprodref6 = StringUtil.PadR( StringUtil.RTrim( AV198Almacen_productoswwds_56_tfprodref6), 20, "%");
         lV200Almacen_productoswwds_58_tfprodref7 = StringUtil.PadR( StringUtil.RTrim( AV200Almacen_productoswwds_58_tfprodref7), 20, "%");
         lV202Almacen_productoswwds_60_tfprodref8 = StringUtil.PadR( StringUtil.RTrim( AV202Almacen_productoswwds_60_tfprodref8), 20, "%");
         lV204Almacen_productoswwds_62_tfprodref9 = StringUtil.PadR( StringUtil.RTrim( AV204Almacen_productoswwds_62_tfprodref9), 20, "%");
         lV206Almacen_productoswwds_64_tfprodref10 = StringUtil.PadR( StringUtil.RTrim( AV206Almacen_productoswwds_64_tfprodref10), 20, "%");
         /* Using cursor P00DV2 */
         pr_default.execute(0, new Object[] {lV145Almacen_productoswwds_3_proddsc1, lV145Almacen_productoswwds_3_proddsc1, lV146Almacen_productoswwds_4_prodcuentavdsc1, lV146Almacen_productoswwds_4_prodcuentavdsc1, lV147Almacen_productoswwds_5_prodcuentacdsc1, lV147Almacen_productoswwds_5_prodcuentacdsc1, lV148Almacen_productoswwds_6_prodcuentaadsc1, lV148Almacen_productoswwds_6_prodcuentaadsc1, lV149Almacen_productoswwds_7_lindsc1, lV149Almacen_productoswwds_7_lindsc1, lV153Almacen_productoswwds_11_proddsc2, lV153Almacen_productoswwds_11_proddsc2, lV154Almacen_productoswwds_12_prodcuentavdsc2, lV154Almacen_productoswwds_12_prodcuentavdsc2, lV155Almacen_productoswwds_13_prodcuentacdsc2, lV155Almacen_productoswwds_13_prodcuentacdsc2, lV156Almacen_productoswwds_14_prodcuentaadsc2, lV156Almacen_productoswwds_14_prodcuentaadsc2, lV157Almacen_productoswwds_15_lindsc2, lV157Almacen_productoswwds_15_lindsc2, lV161Almacen_productoswwds_19_proddsc3, lV161Almacen_productoswwds_19_proddsc3, lV162Almacen_productoswwds_20_prodcuentavdsc3, lV162Almacen_productoswwds_20_prodcuentavdsc3, lV163Almacen_productoswwds_21_prodcuentacdsc3, lV163Almacen_productoswwds_21_prodcuentacdsc3, lV164Almacen_productoswwds_22_prodcuentaadsc3, lV164Almacen_productoswwds_22_prodcuentaadsc3, lV165Almacen_productoswwds_23_lindsc3, lV165Almacen_productoswwds_23_lindsc3, lV166Almacen_productoswwds_24_tfprodcod, AV167Almacen_productoswwds_25_tfprodcod_sel, AV168Almacen_productoswwds_26_tflincod, AV169Almacen_productoswwds_27_tflincod_to, lV170Almacen_productoswwds_28_tfproddsc, AV171Almacen_productoswwds_29_tfproddsc_sel, AV172Almacen_productoswwds_30_tfsublcod, AV173Almacen_productoswwds_31_tfsublcod_to, AV174Almacen_productoswwds_32_tffamcod, AV175Almacen_productoswwds_33_tffamcod_to, AV176Almacen_productoswwds_34_tfunicod, AV177Almacen_productoswwds_35_tfunicod_to, AV180Almacen_productoswwds_38_tfprodpeso, AV181Almacen_productoswwds_39_tfprodpeso_to, AV182Almacen_productoswwds_40_tfprodvolumen, AV183Almacen_productoswwds_41_tfprodvolumen_to, AV184Almacen_productoswwds_42_tfprodstkmax, AV185Almacen_productoswwds_43_tfprodstkmax_to, AV186Almacen_productoswwds_44_tfprodstkmin, AV187Almacen_productoswwds_45_tfprodstkmin_to, lV188Almacen_productoswwds_46_tfprodref1, AV189Almacen_productoswwds_47_tfprodref1_sel, lV190Almacen_productoswwds_48_tfprodref2, AV191Almacen_productoswwds_49_tfprodref2_sel, lV192Almacen_productoswwds_50_tfprodref3, AV193Almacen_productoswwds_51_tfprodref3_sel, lV194Almacen_productoswwds_52_tfprodref4, AV195Almacen_productoswwds_53_tfprodref4_sel, lV196Almacen_productoswwds_54_tfprodref5, AV197Almacen_productoswwds_55_tfprodref5_sel, lV198Almacen_productoswwds_56_tfprodref6, AV199Almacen_productoswwds_57_tfprodref6_sel, lV200Almacen_productoswwds_58_tfprodref7, AV201Almacen_productoswwds_59_tfprodref7_sel, lV202Almacen_productoswwds_60_tfprodref8, AV203Almacen_productoswwds_61_tfprodref8_sel, lV204Almacen_productoswwds_62_tfprodref9, AV205Almacen_productoswwds_63_tfprodref9_sel, lV206Almacen_productoswwds_64_tfprodref10, AV207Almacen_productoswwds_65_tfprodref10_sel, AV209Almacen_productoswwds_67_tfprodcosto, AV210Almacen_productoswwds_68_tfprodcosto_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A48ProdCuentaV = P00DV2_A48ProdCuentaV[0];
            n48ProdCuentaV = P00DV2_n48ProdCuentaV[0];
            A53ProdCuentaC = P00DV2_A53ProdCuentaC[0];
            n53ProdCuentaC = P00DV2_n53ProdCuentaC[0];
            A54ProdCuentaA = P00DV2_A54ProdCuentaA[0];
            n54ProdCuentaA = P00DV2_n54ProdCuentaA[0];
            A1681ProdCosto = P00DV2_A1681ProdCosto[0];
            A1718ProdSts = P00DV2_A1718ProdSts[0];
            A1706ProdRef10 = P00DV2_A1706ProdRef10[0];
            A1714ProdRef9 = P00DV2_A1714ProdRef9[0];
            A1713ProdRef8 = P00DV2_A1713ProdRef8[0];
            A1712ProdRef7 = P00DV2_A1712ProdRef7[0];
            A1711ProdRef6 = P00DV2_A1711ProdRef6[0];
            A1710ProdRef5 = P00DV2_A1710ProdRef5[0];
            A1709ProdRef4 = P00DV2_A1709ProdRef4[0];
            A1708ProdRef3 = P00DV2_A1708ProdRef3[0];
            A1707ProdRef2 = P00DV2_A1707ProdRef2[0];
            A1705ProdRef1 = P00DV2_A1705ProdRef1[0];
            A1717ProdStkMin = P00DV2_A1717ProdStkMin[0];
            A1716ProdStkMax = P00DV2_A1716ProdStkMax[0];
            A1723ProdVolumen = P00DV2_A1723ProdVolumen[0];
            A1702ProdPeso = P00DV2_A1702ProdPeso[0];
            A1679ProdCmp = P00DV2_A1679ProdCmp[0];
            A1724ProdVta = P00DV2_A1724ProdVta[0];
            A49UniCod = P00DV2_A49UniCod[0];
            A50FamCod = P00DV2_A50FamCod[0];
            n50FamCod = P00DV2_n50FamCod[0];
            A51SublCod = P00DV2_A51SublCod[0];
            n51SublCod = P00DV2_n51SublCod[0];
            A52LinCod = P00DV2_A52LinCod[0];
            A28ProdCod = P00DV2_A28ProdCod[0];
            A1153LinDsc = P00DV2_A1153LinDsc[0];
            A1684ProdCuentaADsc = P00DV2_A1684ProdCuentaADsc[0];
            A1685ProdCuentaCDsc = P00DV2_A1685ProdCuentaCDsc[0];
            A1686ProdCuentaVDsc = P00DV2_A1686ProdCuentaVDsc[0];
            A55ProdDsc = P00DV2_A55ProdDsc[0];
            A40000ProdFoto_GXI = P00DV2_A40000ProdFoto_GXI[0];
            n40000ProdFoto_GXI = P00DV2_n40000ProdFoto_GXI[0];
            A1695ProdFoto = P00DV2_A1695ProdFoto[0];
            n1695ProdFoto = P00DV2_n1695ProdFoto[0];
            A1686ProdCuentaVDsc = P00DV2_A1686ProdCuentaVDsc[0];
            A1685ProdCuentaCDsc = P00DV2_A1685ProdCuentaCDsc[0];
            A1684ProdCuentaADsc = P00DV2_A1684ProdCuentaADsc[0];
            A1153LinDsc = P00DV2_A1153LinDsc[0];
            if ( A1718ProdSts == 1 )
            {
               AV125ProdStsDescription = "ACTIVO";
            }
            else if ( A1718ProdSts == 0 )
            {
               AV125ProdStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HDV0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 30, Gx_line+10, 56, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A52LinCod), "ZZZZZ9")), 60, Gx_line+10, 86, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 90, Gx_line+10, 116, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A51SublCod), "ZZZZZ9")), 120, Gx_line+10, 146, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A50FamCod), "ZZZZZ9")), 150, Gx_line+10, 176, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A49UniCod), "ZZZZZ9")), 180, Gx_line+10, 206, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1724ProdVta), "9")), 210, Gx_line+10, 236, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1679ProdCmp), "9")), 240, Gx_line+10, 266, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1702ProdPeso, "ZZZZZZZZ9.99999")), 270, Gx_line+10, 296, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1723ProdVolumen, "ZZZZZZZZ9.99999")), 300, Gx_line+10, 326, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1716ProdStkMax, "ZZZZ,ZZZ,ZZ9.9999")), 330, Gx_line+10, 356, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1717ProdStkMin, "ZZZZ,ZZZ,ZZ9.9999")), 360, Gx_line+10, 386, Gx_line+25, 2, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : A1695ProdFoto);
            getPrinter().GxDrawBitMap(sImgUrl, 390, Gx_line+10, 416, Gx_line+25) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1705ProdRef1, "")), 420, Gx_line+10, 446, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1707ProdRef2, "")), 450, Gx_line+10, 476, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1708ProdRef3, "")), 480, Gx_line+10, 506, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1709ProdRef4, "")), 510, Gx_line+10, 536, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1710ProdRef5, "")), 540, Gx_line+10, 566, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1711ProdRef6, "")), 570, Gx_line+10, 596, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1712ProdRef7, "")), 600, Gx_line+10, 628, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1713ProdRef8, "")), 632, Gx_line+10, 660, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1714ProdRef9, "")), 664, Gx_line+10, 692, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1706ProdRef10, "")), 696, Gx_line+10, 724, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV125ProdStsDescription, "")), 728, Gx_line+10, 756, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1681ProdCosto, "ZZZZZZZZZZZ9.99999")), 760, Gx_line+10, 787, Gx_line+25, 2, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV41Session.Get("Almacen.ProductosWWGridState"), "") == 0 )
         {
            AV43GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Almacen.ProductosWWGridState"), null, "", "");
         }
         else
         {
            AV43GridState.FromXml(AV41Session.Get("Almacen.ProductosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV43GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV43GridState.gxTpr_Ordereddsc;
         AV211GXV2 = 1;
         while ( AV211GXV2 <= AV43GridState.gxTpr_Filtervalues.Count )
         {
            AV44GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV43GridState.gxTpr_Filtervalues.Item(AV211GXV2));
            if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODCOD") == 0 )
            {
               AV45TFProdCod = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODCOD_SEL") == 0 )
            {
               AV46TFProdCod_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFLINCOD") == 0 )
            {
               AV47TFLinCod = (int)(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."));
               AV48TFLinCod_To = (int)(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODDSC") == 0 )
            {
               AV49TFProdDsc = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODDSC_SEL") == 0 )
            {
               AV50TFProdDsc_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSUBLCOD") == 0 )
            {
               AV51TFSublCod = (int)(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."));
               AV52TFSublCod_To = (int)(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFFAMCOD") == 0 )
            {
               AV53TFFamCod = (int)(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."));
               AV54TFFamCod_To = (int)(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFUNICOD") == 0 )
            {
               AV55TFUniCod = (int)(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."));
               AV56TFUniCod_To = (int)(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODVTA_SEL") == 0 )
            {
               AV123TFProdVta_Sel = (short)(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODCMP_SEL") == 0 )
            {
               AV124TFProdCmp_Sel = (short)(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODPESO") == 0 )
            {
               AV61TFProdPeso = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, ".");
               AV62TFProdPeso_To = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODVOLUMEN") == 0 )
            {
               AV63TFProdVolumen = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, ".");
               AV64TFProdVolumen_To = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODSTKMAX") == 0 )
            {
               AV65TFProdStkMax = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, ".");
               AV66TFProdStkMax_To = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODSTKMIN") == 0 )
            {
               AV67TFProdStkMin = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, ".");
               AV68TFProdStkMin_To = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF1") == 0 )
            {
               AV69TFProdRef1 = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF1_SEL") == 0 )
            {
               AV70TFProdRef1_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF2") == 0 )
            {
               AV71TFProdRef2 = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF2_SEL") == 0 )
            {
               AV72TFProdRef2_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF3") == 0 )
            {
               AV73TFProdRef3 = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF3_SEL") == 0 )
            {
               AV74TFProdRef3_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF4") == 0 )
            {
               AV75TFProdRef4 = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF4_SEL") == 0 )
            {
               AV76TFProdRef4_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF5") == 0 )
            {
               AV77TFProdRef5 = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF5_SEL") == 0 )
            {
               AV78TFProdRef5_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF6") == 0 )
            {
               AV79TFProdRef6 = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF6_SEL") == 0 )
            {
               AV80TFProdRef6_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF7") == 0 )
            {
               AV81TFProdRef7 = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF7_SEL") == 0 )
            {
               AV82TFProdRef7_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF8") == 0 )
            {
               AV83TFProdRef8 = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF8_SEL") == 0 )
            {
               AV84TFProdRef8_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF9") == 0 )
            {
               AV85TFProdRef9 = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF9_SEL") == 0 )
            {
               AV86TFProdRef9_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF10") == 0 )
            {
               AV87TFProdRef10 = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODREF10_SEL") == 0 )
            {
               AV88TFProdRef10_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODSTS_SEL") == 0 )
            {
               AV126TFProdSts_SelsJson = AV44GridStateFilterValue.gxTpr_Value;
               AV128TFProdSts_Sels.FromJSonString(AV126TFProdSts_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPRODCOSTO") == 0 )
            {
               AV91TFProdCosto = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, ".");
               AV92TFProdCosto_To = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV211GXV2 = (int)(AV211GXV2+1);
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

      protected void HDV0( bool bFoot ,
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
                  AV113PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV110DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV113PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV110DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV108AppName = "DVelop Software Solutions";
               AV114Phone = "+1 550 8923";
               AV112Mail = "info@mail.com";
               AV116Website = "http://www.web.com";
               AV105AddressLine1 = "French Boulevard 2859";
               AV106AddressLine2 = "Downtown";
               AV107AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV108AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV115Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV114Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV112Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV116Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV105AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV106AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV107AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV115Title = "";
         AV43GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV40GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14ProdDsc1 = "";
         AV15FilterProdDscDescription = "";
         AV16ProdDsc = "";
         AV17ProdCuentaVDsc1 = "";
         AV18FilterProdCuentaVDscDescription = "";
         AV19ProdCuentaVDsc = "";
         AV20ProdCuentaCDsc1 = "";
         AV21FilterProdCuentaCDscDescription = "";
         AV22ProdCuentaCDsc = "";
         AV23ProdCuentaADsc1 = "";
         AV24FilterProdCuentaADscDescription = "";
         AV25ProdCuentaADsc = "";
         AV132LinDsc1 = "";
         AV133FilterLinDscDescription = "";
         AV134LinDsc = "";
         AV27DynamicFiltersSelector2 = "";
         AV29ProdDsc2 = "";
         AV30ProdCuentaVDsc2 = "";
         AV31ProdCuentaCDsc2 = "";
         AV32ProdCuentaADsc2 = "";
         AV135LinDsc2 = "";
         AV34DynamicFiltersSelector3 = "";
         AV36ProdDsc3 = "";
         AV37ProdCuentaVDsc3 = "";
         AV38ProdCuentaCDsc3 = "";
         AV39ProdCuentaADsc3 = "";
         AV136LinDsc3 = "";
         AV46TFProdCod_Sel = "";
         AV45TFProdCod = "";
         AV93TFLinCod_To_Description = "";
         AV50TFProdDsc_Sel = "";
         AV49TFProdDsc = "";
         AV94TFSublCod_To_Description = "";
         AV95TFFamCod_To_Description = "";
         AV96TFUniCod_To_Description = "";
         AV99TFProdPeso_To_Description = "";
         AV100TFProdVolumen_To_Description = "";
         AV101TFProdStkMax_To_Description = "";
         AV102TFProdStkMin_To_Description = "";
         AV70TFProdRef1_Sel = "";
         AV69TFProdRef1 = "";
         AV72TFProdRef2_Sel = "";
         AV71TFProdRef2 = "";
         AV74TFProdRef3_Sel = "";
         AV73TFProdRef3 = "";
         AV76TFProdRef4_Sel = "";
         AV75TFProdRef4 = "";
         AV78TFProdRef5_Sel = "";
         AV77TFProdRef5 = "";
         AV80TFProdRef6_Sel = "";
         AV79TFProdRef6 = "";
         AV82TFProdRef7_Sel = "";
         AV81TFProdRef7 = "";
         AV84TFProdRef8_Sel = "";
         AV83TFProdRef8 = "";
         AV86TFProdRef9_Sel = "";
         AV85TFProdRef9 = "";
         AV88TFProdRef10_Sel = "";
         AV87TFProdRef10 = "";
         AV128TFProdSts_Sels = new GxSimpleCollection<short>();
         AV126TFProdSts_SelsJson = "";
         AV127TFProdSts_SelDscs = "";
         AV130FilterTFProdSts_SelValueDescription = "";
         AV104TFProdCosto_To_Description = "";
         AV143Almacen_productoswwds_1_dynamicfiltersselector1 = "";
         AV145Almacen_productoswwds_3_proddsc1 = "";
         AV146Almacen_productoswwds_4_prodcuentavdsc1 = "";
         AV147Almacen_productoswwds_5_prodcuentacdsc1 = "";
         AV148Almacen_productoswwds_6_prodcuentaadsc1 = "";
         AV149Almacen_productoswwds_7_lindsc1 = "";
         AV151Almacen_productoswwds_9_dynamicfiltersselector2 = "";
         AV153Almacen_productoswwds_11_proddsc2 = "";
         AV154Almacen_productoswwds_12_prodcuentavdsc2 = "";
         AV155Almacen_productoswwds_13_prodcuentacdsc2 = "";
         AV156Almacen_productoswwds_14_prodcuentaadsc2 = "";
         AV157Almacen_productoswwds_15_lindsc2 = "";
         AV159Almacen_productoswwds_17_dynamicfiltersselector3 = "";
         AV161Almacen_productoswwds_19_proddsc3 = "";
         AV162Almacen_productoswwds_20_prodcuentavdsc3 = "";
         AV163Almacen_productoswwds_21_prodcuentacdsc3 = "";
         AV164Almacen_productoswwds_22_prodcuentaadsc3 = "";
         AV165Almacen_productoswwds_23_lindsc3 = "";
         AV166Almacen_productoswwds_24_tfprodcod = "";
         AV167Almacen_productoswwds_25_tfprodcod_sel = "";
         AV170Almacen_productoswwds_28_tfproddsc = "";
         AV171Almacen_productoswwds_29_tfproddsc_sel = "";
         AV188Almacen_productoswwds_46_tfprodref1 = "";
         AV189Almacen_productoswwds_47_tfprodref1_sel = "";
         AV190Almacen_productoswwds_48_tfprodref2 = "";
         AV191Almacen_productoswwds_49_tfprodref2_sel = "";
         AV192Almacen_productoswwds_50_tfprodref3 = "";
         AV193Almacen_productoswwds_51_tfprodref3_sel = "";
         AV194Almacen_productoswwds_52_tfprodref4 = "";
         AV195Almacen_productoswwds_53_tfprodref4_sel = "";
         AV196Almacen_productoswwds_54_tfprodref5 = "";
         AV197Almacen_productoswwds_55_tfprodref5_sel = "";
         AV198Almacen_productoswwds_56_tfprodref6 = "";
         AV199Almacen_productoswwds_57_tfprodref6_sel = "";
         AV200Almacen_productoswwds_58_tfprodref7 = "";
         AV201Almacen_productoswwds_59_tfprodref7_sel = "";
         AV202Almacen_productoswwds_60_tfprodref8 = "";
         AV203Almacen_productoswwds_61_tfprodref8_sel = "";
         AV204Almacen_productoswwds_62_tfprodref9 = "";
         AV205Almacen_productoswwds_63_tfprodref9_sel = "";
         AV206Almacen_productoswwds_64_tfprodref10 = "";
         AV207Almacen_productoswwds_65_tfprodref10_sel = "";
         AV208Almacen_productoswwds_66_tfprodsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV145Almacen_productoswwds_3_proddsc1 = "";
         lV146Almacen_productoswwds_4_prodcuentavdsc1 = "";
         lV147Almacen_productoswwds_5_prodcuentacdsc1 = "";
         lV148Almacen_productoswwds_6_prodcuentaadsc1 = "";
         lV149Almacen_productoswwds_7_lindsc1 = "";
         lV153Almacen_productoswwds_11_proddsc2 = "";
         lV154Almacen_productoswwds_12_prodcuentavdsc2 = "";
         lV155Almacen_productoswwds_13_prodcuentacdsc2 = "";
         lV156Almacen_productoswwds_14_prodcuentaadsc2 = "";
         lV157Almacen_productoswwds_15_lindsc2 = "";
         lV161Almacen_productoswwds_19_proddsc3 = "";
         lV162Almacen_productoswwds_20_prodcuentavdsc3 = "";
         lV163Almacen_productoswwds_21_prodcuentacdsc3 = "";
         lV164Almacen_productoswwds_22_prodcuentaadsc3 = "";
         lV165Almacen_productoswwds_23_lindsc3 = "";
         lV166Almacen_productoswwds_24_tfprodcod = "";
         lV170Almacen_productoswwds_28_tfproddsc = "";
         lV188Almacen_productoswwds_46_tfprodref1 = "";
         lV190Almacen_productoswwds_48_tfprodref2 = "";
         lV192Almacen_productoswwds_50_tfprodref3 = "";
         lV194Almacen_productoswwds_52_tfprodref4 = "";
         lV196Almacen_productoswwds_54_tfprodref5 = "";
         lV198Almacen_productoswwds_56_tfprodref6 = "";
         lV200Almacen_productoswwds_58_tfprodref7 = "";
         lV202Almacen_productoswwds_60_tfprodref8 = "";
         lV204Almacen_productoswwds_62_tfprodref9 = "";
         lV206Almacen_productoswwds_64_tfprodref10 = "";
         A55ProdDsc = "";
         A1686ProdCuentaVDsc = "";
         A1685ProdCuentaCDsc = "";
         A1684ProdCuentaADsc = "";
         A1153LinDsc = "";
         A28ProdCod = "";
         A1705ProdRef1 = "";
         A1707ProdRef2 = "";
         A1708ProdRef3 = "";
         A1709ProdRef4 = "";
         A1710ProdRef5 = "";
         A1711ProdRef6 = "";
         A1712ProdRef7 = "";
         A1713ProdRef8 = "";
         A1714ProdRef9 = "";
         A1706ProdRef10 = "";
         P00DV2_A48ProdCuentaV = new string[] {""} ;
         P00DV2_n48ProdCuentaV = new bool[] {false} ;
         P00DV2_A53ProdCuentaC = new string[] {""} ;
         P00DV2_n53ProdCuentaC = new bool[] {false} ;
         P00DV2_A54ProdCuentaA = new string[] {""} ;
         P00DV2_n54ProdCuentaA = new bool[] {false} ;
         P00DV2_A1681ProdCosto = new decimal[1] ;
         P00DV2_A1718ProdSts = new short[1] ;
         P00DV2_A1706ProdRef10 = new string[] {""} ;
         P00DV2_A1714ProdRef9 = new string[] {""} ;
         P00DV2_A1713ProdRef8 = new string[] {""} ;
         P00DV2_A1712ProdRef7 = new string[] {""} ;
         P00DV2_A1711ProdRef6 = new string[] {""} ;
         P00DV2_A1710ProdRef5 = new string[] {""} ;
         P00DV2_A1709ProdRef4 = new string[] {""} ;
         P00DV2_A1708ProdRef3 = new string[] {""} ;
         P00DV2_A1707ProdRef2 = new string[] {""} ;
         P00DV2_A1705ProdRef1 = new string[] {""} ;
         P00DV2_A1717ProdStkMin = new decimal[1] ;
         P00DV2_A1716ProdStkMax = new decimal[1] ;
         P00DV2_A1723ProdVolumen = new decimal[1] ;
         P00DV2_A1702ProdPeso = new decimal[1] ;
         P00DV2_A1679ProdCmp = new short[1] ;
         P00DV2_A1724ProdVta = new short[1] ;
         P00DV2_A49UniCod = new int[1] ;
         P00DV2_A50FamCod = new int[1] ;
         P00DV2_n50FamCod = new bool[] {false} ;
         P00DV2_A51SublCod = new int[1] ;
         P00DV2_n51SublCod = new bool[] {false} ;
         P00DV2_A52LinCod = new int[1] ;
         P00DV2_A28ProdCod = new string[] {""} ;
         P00DV2_A1153LinDsc = new string[] {""} ;
         P00DV2_A1684ProdCuentaADsc = new string[] {""} ;
         P00DV2_A1685ProdCuentaCDsc = new string[] {""} ;
         P00DV2_A1686ProdCuentaVDsc = new string[] {""} ;
         P00DV2_A55ProdDsc = new string[] {""} ;
         P00DV2_A40000ProdFoto_GXI = new string[] {""} ;
         P00DV2_n40000ProdFoto_GXI = new bool[] {false} ;
         P00DV2_A1695ProdFoto = new string[] {""} ;
         P00DV2_n1695ProdFoto = new bool[] {false} ;
         A48ProdCuentaV = "";
         A53ProdCuentaC = "";
         A54ProdCuentaA = "";
         A40000ProdFoto_GXI = "";
         A1695ProdFoto = "";
         AV125ProdStsDescription = "";
         sImgUrl = "";
         AV41Session = context.GetSession();
         AV44GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV113PageInfo = "";
         AV110DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV108AppName = "";
         AV114Phone = "";
         AV112Mail = "";
         AV116Website = "";
         AV105AddressLine1 = "";
         AV106AddressLine2 = "";
         AV107AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.productoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00DV2_A48ProdCuentaV, P00DV2_n48ProdCuentaV, P00DV2_A53ProdCuentaC, P00DV2_n53ProdCuentaC, P00DV2_A54ProdCuentaA, P00DV2_n54ProdCuentaA, P00DV2_A1681ProdCosto, P00DV2_A1718ProdSts, P00DV2_A1706ProdRef10, P00DV2_A1714ProdRef9,
               P00DV2_A1713ProdRef8, P00DV2_A1712ProdRef7, P00DV2_A1711ProdRef6, P00DV2_A1710ProdRef5, P00DV2_A1709ProdRef4, P00DV2_A1708ProdRef3, P00DV2_A1707ProdRef2, P00DV2_A1705ProdRef1, P00DV2_A1717ProdStkMin, P00DV2_A1716ProdStkMax,
               P00DV2_A1723ProdVolumen, P00DV2_A1702ProdPeso, P00DV2_A1679ProdCmp, P00DV2_A1724ProdVta, P00DV2_A49UniCod, P00DV2_A50FamCod, P00DV2_n50FamCod, P00DV2_A51SublCod, P00DV2_n51SublCod, P00DV2_A52LinCod,
               P00DV2_A28ProdCod, P00DV2_A1153LinDsc, P00DV2_A1684ProdCuentaADsc, P00DV2_A1685ProdCuentaCDsc, P00DV2_A1686ProdCuentaVDsc, P00DV2_A55ProdDsc, P00DV2_A40000ProdFoto_GXI, P00DV2_n40000ProdFoto_GXI, P00DV2_A1695ProdFoto, P00DV2_n1695ProdFoto
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
      private short AV28DynamicFiltersOperator2 ;
      private short AV35DynamicFiltersOperator3 ;
      private short AV123TFProdVta_Sel ;
      private short AV124TFProdCmp_Sel ;
      private short AV129TFProdSts_Sel ;
      private short AV144Almacen_productoswwds_2_dynamicfiltersoperator1 ;
      private short AV152Almacen_productoswwds_10_dynamicfiltersoperator2 ;
      private short AV160Almacen_productoswwds_18_dynamicfiltersoperator3 ;
      private short AV178Almacen_productoswwds_36_tfprodvta_sel ;
      private short AV179Almacen_productoswwds_37_tfprodcmp_sel ;
      private short A1718ProdSts ;
      private short A1724ProdVta ;
      private short A1679ProdCmp ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV47TFLinCod ;
      private int AV48TFLinCod_To ;
      private int AV51TFSublCod ;
      private int AV52TFSublCod_To ;
      private int AV53TFFamCod ;
      private int AV54TFFamCod_To ;
      private int AV55TFUniCod ;
      private int AV56TFUniCod_To ;
      private int AV141GXV1 ;
      private int AV168Almacen_productoswwds_26_tflincod ;
      private int AV169Almacen_productoswwds_27_tflincod_to ;
      private int AV172Almacen_productoswwds_30_tfsublcod ;
      private int AV173Almacen_productoswwds_31_tfsublcod_to ;
      private int AV174Almacen_productoswwds_32_tffamcod ;
      private int AV175Almacen_productoswwds_33_tffamcod_to ;
      private int AV176Almacen_productoswwds_34_tfunicod ;
      private int AV177Almacen_productoswwds_35_tfunicod_to ;
      private int AV208Almacen_productoswwds_66_tfprodsts_sels_Count ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A49UniCod ;
      private int AV211GXV2 ;
      private long AV131i ;
      private decimal AV61TFProdPeso ;
      private decimal AV62TFProdPeso_To ;
      private decimal AV63TFProdVolumen ;
      private decimal AV64TFProdVolumen_To ;
      private decimal AV65TFProdStkMax ;
      private decimal AV66TFProdStkMax_To ;
      private decimal AV67TFProdStkMin ;
      private decimal AV68TFProdStkMin_To ;
      private decimal AV91TFProdCosto ;
      private decimal AV92TFProdCosto_To ;
      private decimal AV180Almacen_productoswwds_38_tfprodpeso ;
      private decimal AV181Almacen_productoswwds_39_tfprodpeso_to ;
      private decimal AV182Almacen_productoswwds_40_tfprodvolumen ;
      private decimal AV183Almacen_productoswwds_41_tfprodvolumen_to ;
      private decimal AV184Almacen_productoswwds_42_tfprodstkmax ;
      private decimal AV185Almacen_productoswwds_43_tfprodstkmax_to ;
      private decimal AV186Almacen_productoswwds_44_tfprodstkmin ;
      private decimal AV187Almacen_productoswwds_45_tfprodstkmin_to ;
      private decimal AV209Almacen_productoswwds_67_tfprodcosto ;
      private decimal AV210Almacen_productoswwds_68_tfprodcosto_to ;
      private decimal A1702ProdPeso ;
      private decimal A1723ProdVolumen ;
      private decimal A1716ProdStkMax ;
      private decimal A1717ProdStkMin ;
      private decimal A1681ProdCosto ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14ProdDsc1 ;
      private string AV16ProdDsc ;
      private string AV17ProdCuentaVDsc1 ;
      private string AV19ProdCuentaVDsc ;
      private string AV20ProdCuentaCDsc1 ;
      private string AV22ProdCuentaCDsc ;
      private string AV23ProdCuentaADsc1 ;
      private string AV25ProdCuentaADsc ;
      private string AV132LinDsc1 ;
      private string AV134LinDsc ;
      private string AV29ProdDsc2 ;
      private string AV30ProdCuentaVDsc2 ;
      private string AV31ProdCuentaCDsc2 ;
      private string AV32ProdCuentaADsc2 ;
      private string AV135LinDsc2 ;
      private string AV36ProdDsc3 ;
      private string AV37ProdCuentaVDsc3 ;
      private string AV38ProdCuentaCDsc3 ;
      private string AV39ProdCuentaADsc3 ;
      private string AV136LinDsc3 ;
      private string AV46TFProdCod_Sel ;
      private string AV45TFProdCod ;
      private string AV50TFProdDsc_Sel ;
      private string AV49TFProdDsc ;
      private string AV70TFProdRef1_Sel ;
      private string AV69TFProdRef1 ;
      private string AV72TFProdRef2_Sel ;
      private string AV71TFProdRef2 ;
      private string AV74TFProdRef3_Sel ;
      private string AV73TFProdRef3 ;
      private string AV76TFProdRef4_Sel ;
      private string AV75TFProdRef4 ;
      private string AV78TFProdRef5_Sel ;
      private string AV77TFProdRef5 ;
      private string AV80TFProdRef6_Sel ;
      private string AV79TFProdRef6 ;
      private string AV82TFProdRef7_Sel ;
      private string AV81TFProdRef7 ;
      private string AV84TFProdRef8_Sel ;
      private string AV83TFProdRef8 ;
      private string AV86TFProdRef9_Sel ;
      private string AV85TFProdRef9 ;
      private string AV88TFProdRef10_Sel ;
      private string AV87TFProdRef10 ;
      private string AV145Almacen_productoswwds_3_proddsc1 ;
      private string AV146Almacen_productoswwds_4_prodcuentavdsc1 ;
      private string AV147Almacen_productoswwds_5_prodcuentacdsc1 ;
      private string AV148Almacen_productoswwds_6_prodcuentaadsc1 ;
      private string AV149Almacen_productoswwds_7_lindsc1 ;
      private string AV153Almacen_productoswwds_11_proddsc2 ;
      private string AV154Almacen_productoswwds_12_prodcuentavdsc2 ;
      private string AV155Almacen_productoswwds_13_prodcuentacdsc2 ;
      private string AV156Almacen_productoswwds_14_prodcuentaadsc2 ;
      private string AV157Almacen_productoswwds_15_lindsc2 ;
      private string AV161Almacen_productoswwds_19_proddsc3 ;
      private string AV162Almacen_productoswwds_20_prodcuentavdsc3 ;
      private string AV163Almacen_productoswwds_21_prodcuentacdsc3 ;
      private string AV164Almacen_productoswwds_22_prodcuentaadsc3 ;
      private string AV165Almacen_productoswwds_23_lindsc3 ;
      private string AV166Almacen_productoswwds_24_tfprodcod ;
      private string AV167Almacen_productoswwds_25_tfprodcod_sel ;
      private string AV170Almacen_productoswwds_28_tfproddsc ;
      private string AV171Almacen_productoswwds_29_tfproddsc_sel ;
      private string AV188Almacen_productoswwds_46_tfprodref1 ;
      private string AV189Almacen_productoswwds_47_tfprodref1_sel ;
      private string AV190Almacen_productoswwds_48_tfprodref2 ;
      private string AV191Almacen_productoswwds_49_tfprodref2_sel ;
      private string AV192Almacen_productoswwds_50_tfprodref3 ;
      private string AV193Almacen_productoswwds_51_tfprodref3_sel ;
      private string AV194Almacen_productoswwds_52_tfprodref4 ;
      private string AV195Almacen_productoswwds_53_tfprodref4_sel ;
      private string AV196Almacen_productoswwds_54_tfprodref5 ;
      private string AV197Almacen_productoswwds_55_tfprodref5_sel ;
      private string AV198Almacen_productoswwds_56_tfprodref6 ;
      private string AV199Almacen_productoswwds_57_tfprodref6_sel ;
      private string AV200Almacen_productoswwds_58_tfprodref7 ;
      private string AV201Almacen_productoswwds_59_tfprodref7_sel ;
      private string AV202Almacen_productoswwds_60_tfprodref8 ;
      private string AV203Almacen_productoswwds_61_tfprodref8_sel ;
      private string AV204Almacen_productoswwds_62_tfprodref9 ;
      private string AV205Almacen_productoswwds_63_tfprodref9_sel ;
      private string AV206Almacen_productoswwds_64_tfprodref10 ;
      private string AV207Almacen_productoswwds_65_tfprodref10_sel ;
      private string scmdbuf ;
      private string lV145Almacen_productoswwds_3_proddsc1 ;
      private string lV146Almacen_productoswwds_4_prodcuentavdsc1 ;
      private string lV147Almacen_productoswwds_5_prodcuentacdsc1 ;
      private string lV148Almacen_productoswwds_6_prodcuentaadsc1 ;
      private string lV149Almacen_productoswwds_7_lindsc1 ;
      private string lV153Almacen_productoswwds_11_proddsc2 ;
      private string lV154Almacen_productoswwds_12_prodcuentavdsc2 ;
      private string lV155Almacen_productoswwds_13_prodcuentacdsc2 ;
      private string lV156Almacen_productoswwds_14_prodcuentaadsc2 ;
      private string lV157Almacen_productoswwds_15_lindsc2 ;
      private string lV161Almacen_productoswwds_19_proddsc3 ;
      private string lV162Almacen_productoswwds_20_prodcuentavdsc3 ;
      private string lV163Almacen_productoswwds_21_prodcuentacdsc3 ;
      private string lV164Almacen_productoswwds_22_prodcuentaadsc3 ;
      private string lV165Almacen_productoswwds_23_lindsc3 ;
      private string lV166Almacen_productoswwds_24_tfprodcod ;
      private string lV170Almacen_productoswwds_28_tfproddsc ;
      private string lV188Almacen_productoswwds_46_tfprodref1 ;
      private string lV190Almacen_productoswwds_48_tfprodref2 ;
      private string lV192Almacen_productoswwds_50_tfprodref3 ;
      private string lV194Almacen_productoswwds_52_tfprodref4 ;
      private string lV196Almacen_productoswwds_54_tfprodref5 ;
      private string lV198Almacen_productoswwds_56_tfprodref6 ;
      private string lV200Almacen_productoswwds_58_tfprodref7 ;
      private string lV202Almacen_productoswwds_60_tfprodref8 ;
      private string lV204Almacen_productoswwds_62_tfprodref9 ;
      private string lV206Almacen_productoswwds_64_tfprodref10 ;
      private string A55ProdDsc ;
      private string A1686ProdCuentaVDsc ;
      private string A1685ProdCuentaCDsc ;
      private string A1684ProdCuentaADsc ;
      private string A1153LinDsc ;
      private string A28ProdCod ;
      private string A1705ProdRef1 ;
      private string A1707ProdRef2 ;
      private string A1708ProdRef3 ;
      private string A1709ProdRef4 ;
      private string A1710ProdRef5 ;
      private string A1711ProdRef6 ;
      private string A1712ProdRef7 ;
      private string A1713ProdRef8 ;
      private string A1714ProdRef9 ;
      private string A1706ProdRef10 ;
      private string A48ProdCuentaV ;
      private string A53ProdCuentaC ;
      private string A54ProdCuentaA ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV26DynamicFiltersEnabled2 ;
      private bool AV33DynamicFiltersEnabled3 ;
      private bool AV150Almacen_productoswwds_8_dynamicfiltersenabled2 ;
      private bool AV158Almacen_productoswwds_16_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private bool n48ProdCuentaV ;
      private bool n53ProdCuentaC ;
      private bool n54ProdCuentaA ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool n40000ProdFoto_GXI ;
      private bool n1695ProdFoto ;
      private string AV126TFProdSts_SelsJson ;
      private string AV115Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterProdDscDescription ;
      private string AV18FilterProdCuentaVDscDescription ;
      private string AV21FilterProdCuentaCDscDescription ;
      private string AV24FilterProdCuentaADscDescription ;
      private string AV133FilterLinDscDescription ;
      private string AV27DynamicFiltersSelector2 ;
      private string AV34DynamicFiltersSelector3 ;
      private string AV93TFLinCod_To_Description ;
      private string AV94TFSublCod_To_Description ;
      private string AV95TFFamCod_To_Description ;
      private string AV96TFUniCod_To_Description ;
      private string AV99TFProdPeso_To_Description ;
      private string AV100TFProdVolumen_To_Description ;
      private string AV101TFProdStkMax_To_Description ;
      private string AV102TFProdStkMin_To_Description ;
      private string AV127TFProdSts_SelDscs ;
      private string AV130FilterTFProdSts_SelValueDescription ;
      private string AV104TFProdCosto_To_Description ;
      private string AV143Almacen_productoswwds_1_dynamicfiltersselector1 ;
      private string AV151Almacen_productoswwds_9_dynamicfiltersselector2 ;
      private string AV159Almacen_productoswwds_17_dynamicfiltersselector3 ;
      private string A40000ProdFoto_GXI ;
      private string AV125ProdStsDescription ;
      private string AV113PageInfo ;
      private string AV110DateInfo ;
      private string AV108AppName ;
      private string AV114Phone ;
      private string AV112Mail ;
      private string AV116Website ;
      private string AV105AddressLine1 ;
      private string AV106AddressLine2 ;
      private string AV107AddressLine3 ;
      private string A1695ProdFoto ;
      private GxSimpleCollection<short> AV128TFProdSts_Sels ;
      private GxSimpleCollection<short> AV208Almacen_productoswwds_66_tfprodsts_sels ;
      private IGxSession AV41Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00DV2_A48ProdCuentaV ;
      private bool[] P00DV2_n48ProdCuentaV ;
      private string[] P00DV2_A53ProdCuentaC ;
      private bool[] P00DV2_n53ProdCuentaC ;
      private string[] P00DV2_A54ProdCuentaA ;
      private bool[] P00DV2_n54ProdCuentaA ;
      private decimal[] P00DV2_A1681ProdCosto ;
      private short[] P00DV2_A1718ProdSts ;
      private string[] P00DV2_A1706ProdRef10 ;
      private string[] P00DV2_A1714ProdRef9 ;
      private string[] P00DV2_A1713ProdRef8 ;
      private string[] P00DV2_A1712ProdRef7 ;
      private string[] P00DV2_A1711ProdRef6 ;
      private string[] P00DV2_A1710ProdRef5 ;
      private string[] P00DV2_A1709ProdRef4 ;
      private string[] P00DV2_A1708ProdRef3 ;
      private string[] P00DV2_A1707ProdRef2 ;
      private string[] P00DV2_A1705ProdRef1 ;
      private decimal[] P00DV2_A1717ProdStkMin ;
      private decimal[] P00DV2_A1716ProdStkMax ;
      private decimal[] P00DV2_A1723ProdVolumen ;
      private decimal[] P00DV2_A1702ProdPeso ;
      private short[] P00DV2_A1679ProdCmp ;
      private short[] P00DV2_A1724ProdVta ;
      private int[] P00DV2_A49UniCod ;
      private int[] P00DV2_A50FamCod ;
      private bool[] P00DV2_n50FamCod ;
      private int[] P00DV2_A51SublCod ;
      private bool[] P00DV2_n51SublCod ;
      private int[] P00DV2_A52LinCod ;
      private string[] P00DV2_A28ProdCod ;
      private string[] P00DV2_A1153LinDsc ;
      private string[] P00DV2_A1684ProdCuentaADsc ;
      private string[] P00DV2_A1685ProdCuentaCDsc ;
      private string[] P00DV2_A1686ProdCuentaVDsc ;
      private string[] P00DV2_A55ProdDsc ;
      private string[] P00DV2_A40000ProdFoto_GXI ;
      private bool[] P00DV2_n40000ProdFoto_GXI ;
      private string[] P00DV2_A1695ProdFoto ;
      private bool[] P00DV2_n1695ProdFoto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV43GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV44GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV40GridStateDynamicFilter ;
   }

   public class productoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DV2( IGxContext context ,
                                             short A1718ProdSts ,
                                             GxSimpleCollection<short> AV208Almacen_productoswwds_66_tfprodsts_sels ,
                                             string AV143Almacen_productoswwds_1_dynamicfiltersselector1 ,
                                             short AV144Almacen_productoswwds_2_dynamicfiltersoperator1 ,
                                             string AV145Almacen_productoswwds_3_proddsc1 ,
                                             string AV146Almacen_productoswwds_4_prodcuentavdsc1 ,
                                             string AV147Almacen_productoswwds_5_prodcuentacdsc1 ,
                                             string AV148Almacen_productoswwds_6_prodcuentaadsc1 ,
                                             string AV149Almacen_productoswwds_7_lindsc1 ,
                                             bool AV150Almacen_productoswwds_8_dynamicfiltersenabled2 ,
                                             string AV151Almacen_productoswwds_9_dynamicfiltersselector2 ,
                                             short AV152Almacen_productoswwds_10_dynamicfiltersoperator2 ,
                                             string AV153Almacen_productoswwds_11_proddsc2 ,
                                             string AV154Almacen_productoswwds_12_prodcuentavdsc2 ,
                                             string AV155Almacen_productoswwds_13_prodcuentacdsc2 ,
                                             string AV156Almacen_productoswwds_14_prodcuentaadsc2 ,
                                             string AV157Almacen_productoswwds_15_lindsc2 ,
                                             bool AV158Almacen_productoswwds_16_dynamicfiltersenabled3 ,
                                             string AV159Almacen_productoswwds_17_dynamicfiltersselector3 ,
                                             short AV160Almacen_productoswwds_18_dynamicfiltersoperator3 ,
                                             string AV161Almacen_productoswwds_19_proddsc3 ,
                                             string AV162Almacen_productoswwds_20_prodcuentavdsc3 ,
                                             string AV163Almacen_productoswwds_21_prodcuentacdsc3 ,
                                             string AV164Almacen_productoswwds_22_prodcuentaadsc3 ,
                                             string AV165Almacen_productoswwds_23_lindsc3 ,
                                             string AV167Almacen_productoswwds_25_tfprodcod_sel ,
                                             string AV166Almacen_productoswwds_24_tfprodcod ,
                                             int AV168Almacen_productoswwds_26_tflincod ,
                                             int AV169Almacen_productoswwds_27_tflincod_to ,
                                             string AV171Almacen_productoswwds_29_tfproddsc_sel ,
                                             string AV170Almacen_productoswwds_28_tfproddsc ,
                                             int AV172Almacen_productoswwds_30_tfsublcod ,
                                             int AV173Almacen_productoswwds_31_tfsublcod_to ,
                                             int AV174Almacen_productoswwds_32_tffamcod ,
                                             int AV175Almacen_productoswwds_33_tffamcod_to ,
                                             int AV176Almacen_productoswwds_34_tfunicod ,
                                             int AV177Almacen_productoswwds_35_tfunicod_to ,
                                             short AV178Almacen_productoswwds_36_tfprodvta_sel ,
                                             short AV179Almacen_productoswwds_37_tfprodcmp_sel ,
                                             decimal AV180Almacen_productoswwds_38_tfprodpeso ,
                                             decimal AV181Almacen_productoswwds_39_tfprodpeso_to ,
                                             decimal AV182Almacen_productoswwds_40_tfprodvolumen ,
                                             decimal AV183Almacen_productoswwds_41_tfprodvolumen_to ,
                                             decimal AV184Almacen_productoswwds_42_tfprodstkmax ,
                                             decimal AV185Almacen_productoswwds_43_tfprodstkmax_to ,
                                             decimal AV186Almacen_productoswwds_44_tfprodstkmin ,
                                             decimal AV187Almacen_productoswwds_45_tfprodstkmin_to ,
                                             string AV189Almacen_productoswwds_47_tfprodref1_sel ,
                                             string AV188Almacen_productoswwds_46_tfprodref1 ,
                                             string AV191Almacen_productoswwds_49_tfprodref2_sel ,
                                             string AV190Almacen_productoswwds_48_tfprodref2 ,
                                             string AV193Almacen_productoswwds_51_tfprodref3_sel ,
                                             string AV192Almacen_productoswwds_50_tfprodref3 ,
                                             string AV195Almacen_productoswwds_53_tfprodref4_sel ,
                                             string AV194Almacen_productoswwds_52_tfprodref4 ,
                                             string AV197Almacen_productoswwds_55_tfprodref5_sel ,
                                             string AV196Almacen_productoswwds_54_tfprodref5 ,
                                             string AV199Almacen_productoswwds_57_tfprodref6_sel ,
                                             string AV198Almacen_productoswwds_56_tfprodref6 ,
                                             string AV201Almacen_productoswwds_59_tfprodref7_sel ,
                                             string AV200Almacen_productoswwds_58_tfprodref7 ,
                                             string AV203Almacen_productoswwds_61_tfprodref8_sel ,
                                             string AV202Almacen_productoswwds_60_tfprodref8 ,
                                             string AV205Almacen_productoswwds_63_tfprodref9_sel ,
                                             string AV204Almacen_productoswwds_62_tfprodref9 ,
                                             string AV207Almacen_productoswwds_65_tfprodref10_sel ,
                                             string AV206Almacen_productoswwds_64_tfprodref10 ,
                                             int AV208Almacen_productoswwds_66_tfprodsts_sels_Count ,
                                             decimal AV209Almacen_productoswwds_67_tfprodcosto ,
                                             decimal AV210Almacen_productoswwds_68_tfprodcosto_to ,
                                             string A55ProdDsc ,
                                             string A1686ProdCuentaVDsc ,
                                             string A1685ProdCuentaCDsc ,
                                             string A1684ProdCuentaADsc ,
                                             string A1153LinDsc ,
                                             string A28ProdCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A49UniCod ,
                                             short A1724ProdVta ,
                                             short A1679ProdCmp ,
                                             decimal A1702ProdPeso ,
                                             decimal A1723ProdVolumen ,
                                             decimal A1716ProdStkMax ,
                                             decimal A1717ProdStkMin ,
                                             string A1705ProdRef1 ,
                                             string A1707ProdRef2 ,
                                             string A1708ProdRef3 ,
                                             string A1709ProdRef4 ,
                                             string A1710ProdRef5 ,
                                             string A1711ProdRef6 ,
                                             string A1712ProdRef7 ,
                                             string A1713ProdRef8 ,
                                             string A1714ProdRef9 ,
                                             string A1706ProdRef10 ,
                                             decimal A1681ProdCosto ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[72];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ProdCuentaV] AS ProdCuentaV, T1.[ProdCuentaC] AS ProdCuentaC, T1.[ProdCuentaA] AS ProdCuentaA, T1.[ProdCosto], T1.[ProdSts], T1.[ProdRef10], T1.[ProdRef9], T1.[ProdRef8], T1.[ProdRef7], T1.[ProdRef6], T1.[ProdRef5], T1.[ProdRef4], T1.[ProdRef3], T1.[ProdRef2], T1.[ProdRef1], T1.[ProdStkMin], T1.[ProdStkMax], T1.[ProdVolumen], T1.[ProdPeso], T1.[ProdCmp], T1.[ProdVta], T1.[UniCod], T1.[FamCod], T1.[SublCod], T1.[LinCod], T1.[ProdCod], T5.[LinDsc], T4.[CueDsc] AS ProdCuentaADsc, T3.[CueDsc] AS ProdCuentaCDsc, T2.[CueDsc] AS ProdCuentaVDsc, T1.[ProdDsc], T1.[ProdFoto_GXI], T1.[ProdFoto] FROM (((([APRODUCTOS] T1 LEFT JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[ProdCuentaV]) LEFT JOIN [CBPLANCUENTA] T3 ON T3.[CueCod] = T1.[ProdCuentaC]) LEFT JOIN [CBPLANCUENTA] T4 ON T4.[CueCod] = T1.[ProdCuentaA]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T1.[LinCod])";
         if ( ( StringUtil.StrCmp(AV143Almacen_productoswwds_1_dynamicfiltersselector1, "PRODDSC") == 0 ) && ( AV144Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Almacen_productoswwds_3_proddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV145Almacen_productoswwds_3_proddsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV143Almacen_productoswwds_1_dynamicfiltersselector1, "PRODDSC") == 0 ) && ( AV144Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Almacen_productoswwds_3_proddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like '%' + @lV145Almacen_productoswwds_3_proddsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV143Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAVDSC") == 0 ) && ( AV144Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Almacen_productoswwds_4_prodcuentavdsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV146Almacen_productoswwds_4_prodcuentavdsc1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV143Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAVDSC") == 0 ) && ( AV144Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Almacen_productoswwds_4_prodcuentavdsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV146Almacen_productoswwds_4_prodcuentavdsc1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV143Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTACDSC") == 0 ) && ( AV144Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Almacen_productoswwds_5_prodcuentacdsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like @lV147Almacen_productoswwds_5_prodcuentacdsc1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV143Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTACDSC") == 0 ) && ( AV144Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Almacen_productoswwds_5_prodcuentacdsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like '%' + @lV147Almacen_productoswwds_5_prodcuentacdsc1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV143Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAADSC") == 0 ) && ( AV144Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Almacen_productoswwds_6_prodcuentaadsc1)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like @lV148Almacen_productoswwds_6_prodcuentaadsc1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV143Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAADSC") == 0 ) && ( AV144Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Almacen_productoswwds_6_prodcuentaadsc1)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like '%' + @lV148Almacen_productoswwds_6_prodcuentaadsc1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV143Almacen_productoswwds_1_dynamicfiltersselector1, "LINDSC") == 0 ) && ( AV144Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Almacen_productoswwds_7_lindsc1)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like @lV149Almacen_productoswwds_7_lindsc1)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV143Almacen_productoswwds_1_dynamicfiltersselector1, "LINDSC") == 0 ) && ( AV144Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Almacen_productoswwds_7_lindsc1)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like '%' + @lV149Almacen_productoswwds_7_lindsc1)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV150Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV151Almacen_productoswwds_9_dynamicfiltersselector2, "PRODDSC") == 0 ) && ( AV152Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Almacen_productoswwds_11_proddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV153Almacen_productoswwds_11_proddsc2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV150Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV151Almacen_productoswwds_9_dynamicfiltersselector2, "PRODDSC") == 0 ) && ( AV152Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Almacen_productoswwds_11_proddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like '%' + @lV153Almacen_productoswwds_11_proddsc2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV150Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV151Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAVDSC") == 0 ) && ( AV152Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Almacen_productoswwds_12_prodcuentavdsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV154Almacen_productoswwds_12_prodcuentavdsc2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV150Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV151Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAVDSC") == 0 ) && ( AV152Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Almacen_productoswwds_12_prodcuentavdsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV154Almacen_productoswwds_12_prodcuentavdsc2)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV150Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV151Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTACDSC") == 0 ) && ( AV152Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Almacen_productoswwds_13_prodcuentacdsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like @lV155Almacen_productoswwds_13_prodcuentacdsc2)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV150Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV151Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTACDSC") == 0 ) && ( AV152Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Almacen_productoswwds_13_prodcuentacdsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like '%' + @lV155Almacen_productoswwds_13_prodcuentacdsc2)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV150Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV151Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAADSC") == 0 ) && ( AV152Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Almacen_productoswwds_14_prodcuentaadsc2)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like @lV156Almacen_productoswwds_14_prodcuentaadsc2)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV150Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV151Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAADSC") == 0 ) && ( AV152Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Almacen_productoswwds_14_prodcuentaadsc2)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like '%' + @lV156Almacen_productoswwds_14_prodcuentaadsc2)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV150Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV151Almacen_productoswwds_9_dynamicfiltersselector2, "LINDSC") == 0 ) && ( AV152Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Almacen_productoswwds_15_lindsc2)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like @lV157Almacen_productoswwds_15_lindsc2)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV150Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV151Almacen_productoswwds_9_dynamicfiltersselector2, "LINDSC") == 0 ) && ( AV152Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Almacen_productoswwds_15_lindsc2)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like '%' + @lV157Almacen_productoswwds_15_lindsc2)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV158Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV159Almacen_productoswwds_17_dynamicfiltersselector3, "PRODDSC") == 0 ) && ( AV160Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Almacen_productoswwds_19_proddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV161Almacen_productoswwds_19_proddsc3)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( AV158Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV159Almacen_productoswwds_17_dynamicfiltersselector3, "PRODDSC") == 0 ) && ( AV160Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Almacen_productoswwds_19_proddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like '%' + @lV161Almacen_productoswwds_19_proddsc3)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( AV158Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV159Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAVDSC") == 0 ) && ( AV160Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Almacen_productoswwds_20_prodcuentavdsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV162Almacen_productoswwds_20_prodcuentavdsc3)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( AV158Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV159Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAVDSC") == 0 ) && ( AV160Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Almacen_productoswwds_20_prodcuentavdsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV162Almacen_productoswwds_20_prodcuentavdsc3)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( AV158Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV159Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTACDSC") == 0 ) && ( AV160Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV163Almacen_productoswwds_21_prodcuentacdsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like @lV163Almacen_productoswwds_21_prodcuentacdsc3)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( AV158Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV159Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTACDSC") == 0 ) && ( AV160Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV163Almacen_productoswwds_21_prodcuentacdsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like '%' + @lV163Almacen_productoswwds_21_prodcuentacdsc3)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( AV158Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV159Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAADSC") == 0 ) && ( AV160Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV164Almacen_productoswwds_22_prodcuentaadsc3)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like @lV164Almacen_productoswwds_22_prodcuentaadsc3)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( AV158Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV159Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAADSC") == 0 ) && ( AV160Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV164Almacen_productoswwds_22_prodcuentaadsc3)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like '%' + @lV164Almacen_productoswwds_22_prodcuentaadsc3)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( AV158Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV159Almacen_productoswwds_17_dynamicfiltersselector3, "LINDSC") == 0 ) && ( AV160Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV165Almacen_productoswwds_23_lindsc3)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like @lV165Almacen_productoswwds_23_lindsc3)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( AV158Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV159Almacen_productoswwds_17_dynamicfiltersselector3, "LINDSC") == 0 ) && ( AV160Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV165Almacen_productoswwds_23_lindsc3)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like '%' + @lV165Almacen_productoswwds_23_lindsc3)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV167Almacen_productoswwds_25_tfprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV166Almacen_productoswwds_24_tfprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV166Almacen_productoswwds_24_tfprodcod)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV167Almacen_productoswwds_25_tfprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV167Almacen_productoswwds_25_tfprodcod_sel)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( ! (0==AV168Almacen_productoswwds_26_tflincod) )
         {
            AddWhere(sWhereString, "(T1.[LinCod] >= @AV168Almacen_productoswwds_26_tflincod)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( ! (0==AV169Almacen_productoswwds_27_tflincod_to) )
         {
            AddWhere(sWhereString, "(T1.[LinCod] <= @AV169Almacen_productoswwds_27_tflincod_to)");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV171Almacen_productoswwds_29_tfproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV170Almacen_productoswwds_28_tfproddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV170Almacen_productoswwds_28_tfproddsc)");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV171Almacen_productoswwds_29_tfproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] = @AV171Almacen_productoswwds_29_tfproddsc_sel)");
         }
         else
         {
            GXv_int1[35] = 1;
         }
         if ( ! (0==AV172Almacen_productoswwds_30_tfsublcod) )
         {
            AddWhere(sWhereString, "(T1.[SublCod] >= @AV172Almacen_productoswwds_30_tfsublcod)");
         }
         else
         {
            GXv_int1[36] = 1;
         }
         if ( ! (0==AV173Almacen_productoswwds_31_tfsublcod_to) )
         {
            AddWhere(sWhereString, "(T1.[SublCod] <= @AV173Almacen_productoswwds_31_tfsublcod_to)");
         }
         else
         {
            GXv_int1[37] = 1;
         }
         if ( ! (0==AV174Almacen_productoswwds_32_tffamcod) )
         {
            AddWhere(sWhereString, "(T1.[FamCod] >= @AV174Almacen_productoswwds_32_tffamcod)");
         }
         else
         {
            GXv_int1[38] = 1;
         }
         if ( ! (0==AV175Almacen_productoswwds_33_tffamcod_to) )
         {
            AddWhere(sWhereString, "(T1.[FamCod] <= @AV175Almacen_productoswwds_33_tffamcod_to)");
         }
         else
         {
            GXv_int1[39] = 1;
         }
         if ( ! (0==AV176Almacen_productoswwds_34_tfunicod) )
         {
            AddWhere(sWhereString, "(T1.[UniCod] >= @AV176Almacen_productoswwds_34_tfunicod)");
         }
         else
         {
            GXv_int1[40] = 1;
         }
         if ( ! (0==AV177Almacen_productoswwds_35_tfunicod_to) )
         {
            AddWhere(sWhereString, "(T1.[UniCod] <= @AV177Almacen_productoswwds_35_tfunicod_to)");
         }
         else
         {
            GXv_int1[41] = 1;
         }
         if ( AV178Almacen_productoswwds_36_tfprodvta_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[ProdVta] = 1)");
         }
         if ( AV178Almacen_productoswwds_36_tfprodvta_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[ProdVta] = 0)");
         }
         if ( AV179Almacen_productoswwds_37_tfprodcmp_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[ProdCmp] = 1)");
         }
         if ( AV179Almacen_productoswwds_37_tfprodcmp_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[ProdCmp] = 0)");
         }
         if ( ! (Convert.ToDecimal(0)==AV180Almacen_productoswwds_38_tfprodpeso) )
         {
            AddWhere(sWhereString, "(T1.[ProdPeso] >= @AV180Almacen_productoswwds_38_tfprodpeso)");
         }
         else
         {
            GXv_int1[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV181Almacen_productoswwds_39_tfprodpeso_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdPeso] <= @AV181Almacen_productoswwds_39_tfprodpeso_to)");
         }
         else
         {
            GXv_int1[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV182Almacen_productoswwds_40_tfprodvolumen) )
         {
            AddWhere(sWhereString, "(T1.[ProdVolumen] >= @AV182Almacen_productoswwds_40_tfprodvolumen)");
         }
         else
         {
            GXv_int1[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV183Almacen_productoswwds_41_tfprodvolumen_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdVolumen] <= @AV183Almacen_productoswwds_41_tfprodvolumen_to)");
         }
         else
         {
            GXv_int1[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV184Almacen_productoswwds_42_tfprodstkmax) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMax] >= @AV184Almacen_productoswwds_42_tfprodstkmax)");
         }
         else
         {
            GXv_int1[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV185Almacen_productoswwds_43_tfprodstkmax_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMax] <= @AV185Almacen_productoswwds_43_tfprodstkmax_to)");
         }
         else
         {
            GXv_int1[47] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV186Almacen_productoswwds_44_tfprodstkmin) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMin] >= @AV186Almacen_productoswwds_44_tfprodstkmin)");
         }
         else
         {
            GXv_int1[48] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV187Almacen_productoswwds_45_tfprodstkmin_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMin] <= @AV187Almacen_productoswwds_45_tfprodstkmin_to)");
         }
         else
         {
            GXv_int1[49] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV189Almacen_productoswwds_47_tfprodref1_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV188Almacen_productoswwds_46_tfprodref1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef1] like @lV188Almacen_productoswwds_46_tfprodref1)");
         }
         else
         {
            GXv_int1[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV189Almacen_productoswwds_47_tfprodref1_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef1] = @AV189Almacen_productoswwds_47_tfprodref1_sel)");
         }
         else
         {
            GXv_int1[51] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV191Almacen_productoswwds_49_tfprodref2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV190Almacen_productoswwds_48_tfprodref2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef2] like @lV190Almacen_productoswwds_48_tfprodref2)");
         }
         else
         {
            GXv_int1[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV191Almacen_productoswwds_49_tfprodref2_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef2] = @AV191Almacen_productoswwds_49_tfprodref2_sel)");
         }
         else
         {
            GXv_int1[53] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV193Almacen_productoswwds_51_tfprodref3_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV192Almacen_productoswwds_50_tfprodref3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef3] like @lV192Almacen_productoswwds_50_tfprodref3)");
         }
         else
         {
            GXv_int1[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV193Almacen_productoswwds_51_tfprodref3_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef3] = @AV193Almacen_productoswwds_51_tfprodref3_sel)");
         }
         else
         {
            GXv_int1[55] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV195Almacen_productoswwds_53_tfprodref4_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV194Almacen_productoswwds_52_tfprodref4)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef4] like @lV194Almacen_productoswwds_52_tfprodref4)");
         }
         else
         {
            GXv_int1[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV195Almacen_productoswwds_53_tfprodref4_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef4] = @AV195Almacen_productoswwds_53_tfprodref4_sel)");
         }
         else
         {
            GXv_int1[57] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV197Almacen_productoswwds_55_tfprodref5_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV196Almacen_productoswwds_54_tfprodref5)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef5] like @lV196Almacen_productoswwds_54_tfprodref5)");
         }
         else
         {
            GXv_int1[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV197Almacen_productoswwds_55_tfprodref5_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef5] = @AV197Almacen_productoswwds_55_tfprodref5_sel)");
         }
         else
         {
            GXv_int1[59] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV199Almacen_productoswwds_57_tfprodref6_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV198Almacen_productoswwds_56_tfprodref6)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef6] like @lV198Almacen_productoswwds_56_tfprodref6)");
         }
         else
         {
            GXv_int1[60] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV199Almacen_productoswwds_57_tfprodref6_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef6] = @AV199Almacen_productoswwds_57_tfprodref6_sel)");
         }
         else
         {
            GXv_int1[61] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV201Almacen_productoswwds_59_tfprodref7_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV200Almacen_productoswwds_58_tfprodref7)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef7] like @lV200Almacen_productoswwds_58_tfprodref7)");
         }
         else
         {
            GXv_int1[62] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV201Almacen_productoswwds_59_tfprodref7_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef7] = @AV201Almacen_productoswwds_59_tfprodref7_sel)");
         }
         else
         {
            GXv_int1[63] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV203Almacen_productoswwds_61_tfprodref8_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV202Almacen_productoswwds_60_tfprodref8)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef8] like @lV202Almacen_productoswwds_60_tfprodref8)");
         }
         else
         {
            GXv_int1[64] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV203Almacen_productoswwds_61_tfprodref8_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef8] = @AV203Almacen_productoswwds_61_tfprodref8_sel)");
         }
         else
         {
            GXv_int1[65] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV205Almacen_productoswwds_63_tfprodref9_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV204Almacen_productoswwds_62_tfprodref9)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef9] like @lV204Almacen_productoswwds_62_tfprodref9)");
         }
         else
         {
            GXv_int1[66] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV205Almacen_productoswwds_63_tfprodref9_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef9] = @AV205Almacen_productoswwds_63_tfprodref9_sel)");
         }
         else
         {
            GXv_int1[67] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV207Almacen_productoswwds_65_tfprodref10_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV206Almacen_productoswwds_64_tfprodref10)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef10] like @lV206Almacen_productoswwds_64_tfprodref10)");
         }
         else
         {
            GXv_int1[68] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV207Almacen_productoswwds_65_tfprodref10_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef10] = @AV207Almacen_productoswwds_65_tfprodref10_sel)");
         }
         else
         {
            GXv_int1[69] = 1;
         }
         if ( AV208Almacen_productoswwds_66_tfprodsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV208Almacen_productoswwds_66_tfprodsts_sels, "T1.[ProdSts] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV209Almacen_productoswwds_67_tfprodcosto) )
         {
            AddWhere(sWhereString, "(T1.[ProdCosto] >= @AV209Almacen_productoswwds_67_tfprodcosto)");
         }
         else
         {
            GXv_int1[70] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV210Almacen_productoswwds_68_tfprodcosto_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdCosto] <= @AV210Almacen_productoswwds_68_tfprodcosto_to)");
         }
         else
         {
            GXv_int1[71] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdDsc]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdCod]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdCod] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[LinCod]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[LinCod] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SublCod]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SublCod] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[FamCod]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[FamCod] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[UniCod]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[UniCod] DESC";
         }
         else if ( ( AV10OrderedBy == 7 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdVta]";
         }
         else if ( ( AV10OrderedBy == 7 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdVta] DESC";
         }
         else if ( ( AV10OrderedBy == 8 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdCmp]";
         }
         else if ( ( AV10OrderedBy == 8 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdCmp] DESC";
         }
         else if ( ( AV10OrderedBy == 9 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdPeso]";
         }
         else if ( ( AV10OrderedBy == 9 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdPeso] DESC";
         }
         else if ( ( AV10OrderedBy == 10 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdVolumen]";
         }
         else if ( ( AV10OrderedBy == 10 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdVolumen] DESC";
         }
         else if ( ( AV10OrderedBy == 11 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdStkMax]";
         }
         else if ( ( AV10OrderedBy == 11 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdStkMax] DESC";
         }
         else if ( ( AV10OrderedBy == 12 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdStkMin]";
         }
         else if ( ( AV10OrderedBy == 12 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdStkMin] DESC";
         }
         else if ( ( AV10OrderedBy == 13 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef1]";
         }
         else if ( ( AV10OrderedBy == 13 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef1] DESC";
         }
         else if ( ( AV10OrderedBy == 14 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef2]";
         }
         else if ( ( AV10OrderedBy == 14 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef2] DESC";
         }
         else if ( ( AV10OrderedBy == 15 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef3]";
         }
         else if ( ( AV10OrderedBy == 15 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef3] DESC";
         }
         else if ( ( AV10OrderedBy == 16 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef4]";
         }
         else if ( ( AV10OrderedBy == 16 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef4] DESC";
         }
         else if ( ( AV10OrderedBy == 17 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef5]";
         }
         else if ( ( AV10OrderedBy == 17 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef5] DESC";
         }
         else if ( ( AV10OrderedBy == 18 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef6]";
         }
         else if ( ( AV10OrderedBy == 18 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef6] DESC";
         }
         else if ( ( AV10OrderedBy == 19 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef7]";
         }
         else if ( ( AV10OrderedBy == 19 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef7] DESC";
         }
         else if ( ( AV10OrderedBy == 20 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef8]";
         }
         else if ( ( AV10OrderedBy == 20 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef8] DESC";
         }
         else if ( ( AV10OrderedBy == 21 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef9]";
         }
         else if ( ( AV10OrderedBy == 21 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef9] DESC";
         }
         else if ( ( AV10OrderedBy == 22 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef10]";
         }
         else if ( ( AV10OrderedBy == 22 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef10] DESC";
         }
         else if ( ( AV10OrderedBy == 23 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdSts]";
         }
         else if ( ( AV10OrderedBy == 23 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdSts] DESC";
         }
         else if ( ( AV10OrderedBy == 24 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdCosto]";
         }
         else if ( ( AV10OrderedBy == 24 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdCosto] DESC";
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
                     return conditional_P00DV2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (int)dynConstraints[31] , (int)dynConstraints[32] , (int)dynConstraints[33] , (int)dynConstraints[34] , (int)dynConstraints[35] , (int)dynConstraints[36] , (short)dynConstraints[37] , (short)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (decimal)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (decimal)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (int)dynConstraints[67] , (decimal)dynConstraints[68] , (decimal)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (int)dynConstraints[76] , (int)dynConstraints[77] , (int)dynConstraints[78] , (int)dynConstraints[79] , (short)dynConstraints[80] , (short)dynConstraints[81] , (decimal)dynConstraints[82] , (decimal)dynConstraints[83] , (decimal)dynConstraints[84] , (decimal)dynConstraints[85] , (string)dynConstraints[86] , (string)dynConstraints[87] , (string)dynConstraints[88] , (string)dynConstraints[89] , (string)dynConstraints[90] , (string)dynConstraints[91] , (string)dynConstraints[92] , (string)dynConstraints[93] , (string)dynConstraints[94] , (string)dynConstraints[95] , (decimal)dynConstraints[96] , (short)dynConstraints[97] , (bool)dynConstraints[98] );
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
          Object[] prmP00DV2;
          prmP00DV2 = new Object[] {
          new ParDef("@lV145Almacen_productoswwds_3_proddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV145Almacen_productoswwds_3_proddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV146Almacen_productoswwds_4_prodcuentavdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV146Almacen_productoswwds_4_prodcuentavdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV147Almacen_productoswwds_5_prodcuentacdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV147Almacen_productoswwds_5_prodcuentacdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV148Almacen_productoswwds_6_prodcuentaadsc1",GXType.NChar,100,0) ,
          new ParDef("@lV148Almacen_productoswwds_6_prodcuentaadsc1",GXType.NChar,100,0) ,
          new ParDef("@lV149Almacen_productoswwds_7_lindsc1",GXType.NChar,100,0) ,
          new ParDef("@lV149Almacen_productoswwds_7_lindsc1",GXType.NChar,100,0) ,
          new ParDef("@lV153Almacen_productoswwds_11_proddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV153Almacen_productoswwds_11_proddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV154Almacen_productoswwds_12_prodcuentavdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV154Almacen_productoswwds_12_prodcuentavdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV155Almacen_productoswwds_13_prodcuentacdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV155Almacen_productoswwds_13_prodcuentacdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV156Almacen_productoswwds_14_prodcuentaadsc2",GXType.NChar,100,0) ,
          new ParDef("@lV156Almacen_productoswwds_14_prodcuentaadsc2",GXType.NChar,100,0) ,
          new ParDef("@lV157Almacen_productoswwds_15_lindsc2",GXType.NChar,100,0) ,
          new ParDef("@lV157Almacen_productoswwds_15_lindsc2",GXType.NChar,100,0) ,
          new ParDef("@lV161Almacen_productoswwds_19_proddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV161Almacen_productoswwds_19_proddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV162Almacen_productoswwds_20_prodcuentavdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV162Almacen_productoswwds_20_prodcuentavdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV163Almacen_productoswwds_21_prodcuentacdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV163Almacen_productoswwds_21_prodcuentacdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV164Almacen_productoswwds_22_prodcuentaadsc3",GXType.NChar,100,0) ,
          new ParDef("@lV164Almacen_productoswwds_22_prodcuentaadsc3",GXType.NChar,100,0) ,
          new ParDef("@lV165Almacen_productoswwds_23_lindsc3",GXType.NChar,100,0) ,
          new ParDef("@lV165Almacen_productoswwds_23_lindsc3",GXType.NChar,100,0) ,
          new ParDef("@lV166Almacen_productoswwds_24_tfprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV167Almacen_productoswwds_25_tfprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@AV168Almacen_productoswwds_26_tflincod",GXType.Int32,6,0) ,
          new ParDef("@AV169Almacen_productoswwds_27_tflincod_to",GXType.Int32,6,0) ,
          new ParDef("@lV170Almacen_productoswwds_28_tfproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV171Almacen_productoswwds_29_tfproddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV172Almacen_productoswwds_30_tfsublcod",GXType.Int32,6,0) ,
          new ParDef("@AV173Almacen_productoswwds_31_tfsublcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV174Almacen_productoswwds_32_tffamcod",GXType.Int32,6,0) ,
          new ParDef("@AV175Almacen_productoswwds_33_tffamcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV176Almacen_productoswwds_34_tfunicod",GXType.Int32,6,0) ,
          new ParDef("@AV177Almacen_productoswwds_35_tfunicod_to",GXType.Int32,6,0) ,
          new ParDef("@AV180Almacen_productoswwds_38_tfprodpeso",GXType.Decimal,15,5) ,
          new ParDef("@AV181Almacen_productoswwds_39_tfprodpeso_to",GXType.Decimal,15,5) ,
          new ParDef("@AV182Almacen_productoswwds_40_tfprodvolumen",GXType.Decimal,15,5) ,
          new ParDef("@AV183Almacen_productoswwds_41_tfprodvolumen_to",GXType.Decimal,15,5) ,
          new ParDef("@AV184Almacen_productoswwds_42_tfprodstkmax",GXType.Decimal,15,4) ,
          new ParDef("@AV185Almacen_productoswwds_43_tfprodstkmax_to",GXType.Decimal,15,4) ,
          new ParDef("@AV186Almacen_productoswwds_44_tfprodstkmin",GXType.Decimal,15,4) ,
          new ParDef("@AV187Almacen_productoswwds_45_tfprodstkmin_to",GXType.Decimal,15,4) ,
          new ParDef("@lV188Almacen_productoswwds_46_tfprodref1",GXType.NChar,20,0) ,
          new ParDef("@AV189Almacen_productoswwds_47_tfprodref1_sel",GXType.NChar,20,0) ,
          new ParDef("@lV190Almacen_productoswwds_48_tfprodref2",GXType.NChar,20,0) ,
          new ParDef("@AV191Almacen_productoswwds_49_tfprodref2_sel",GXType.NChar,20,0) ,
          new ParDef("@lV192Almacen_productoswwds_50_tfprodref3",GXType.NChar,20,0) ,
          new ParDef("@AV193Almacen_productoswwds_51_tfprodref3_sel",GXType.NChar,20,0) ,
          new ParDef("@lV194Almacen_productoswwds_52_tfprodref4",GXType.NChar,20,0) ,
          new ParDef("@AV195Almacen_productoswwds_53_tfprodref4_sel",GXType.NChar,20,0) ,
          new ParDef("@lV196Almacen_productoswwds_54_tfprodref5",GXType.NChar,20,0) ,
          new ParDef("@AV197Almacen_productoswwds_55_tfprodref5_sel",GXType.NChar,20,0) ,
          new ParDef("@lV198Almacen_productoswwds_56_tfprodref6",GXType.NChar,20,0) ,
          new ParDef("@AV199Almacen_productoswwds_57_tfprodref6_sel",GXType.NChar,20,0) ,
          new ParDef("@lV200Almacen_productoswwds_58_tfprodref7",GXType.NChar,20,0) ,
          new ParDef("@AV201Almacen_productoswwds_59_tfprodref7_sel",GXType.NChar,20,0) ,
          new ParDef("@lV202Almacen_productoswwds_60_tfprodref8",GXType.NChar,20,0) ,
          new ParDef("@AV203Almacen_productoswwds_61_tfprodref8_sel",GXType.NChar,20,0) ,
          new ParDef("@lV204Almacen_productoswwds_62_tfprodref9",GXType.NChar,20,0) ,
          new ParDef("@AV205Almacen_productoswwds_63_tfprodref9_sel",GXType.NChar,20,0) ,
          new ParDef("@lV206Almacen_productoswwds_64_tfprodref10",GXType.NChar,20,0) ,
          new ParDef("@AV207Almacen_productoswwds_65_tfprodref10_sel",GXType.NChar,20,0) ,
          new ParDef("@AV209Almacen_productoswwds_67_tfprodcosto",GXType.Decimal,18,5) ,
          new ParDef("@AV210Almacen_productoswwds_68_tfprodcosto_to",GXType.Decimal,18,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00DV2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DV2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 15);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 15);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 20);
                ((string[]) buf[9])[0] = rslt.getString(7, 20);
                ((string[]) buf[10])[0] = rslt.getString(8, 20);
                ((string[]) buf[11])[0] = rslt.getString(9, 20);
                ((string[]) buf[12])[0] = rslt.getString(10, 20);
                ((string[]) buf[13])[0] = rslt.getString(11, 20);
                ((string[]) buf[14])[0] = rslt.getString(12, 20);
                ((string[]) buf[15])[0] = rslt.getString(13, 20);
                ((string[]) buf[16])[0] = rslt.getString(14, 20);
                ((string[]) buf[17])[0] = rslt.getString(15, 20);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(19);
                ((short[]) buf[22])[0] = rslt.getShort(20);
                ((short[]) buf[23])[0] = rslt.getShort(21);
                ((int[]) buf[24])[0] = rslt.getInt(22);
                ((int[]) buf[25])[0] = rslt.getInt(23);
                ((bool[]) buf[26])[0] = rslt.wasNull(23);
                ((int[]) buf[27])[0] = rslt.getInt(24);
                ((bool[]) buf[28])[0] = rslt.wasNull(24);
                ((int[]) buf[29])[0] = rslt.getInt(25);
                ((string[]) buf[30])[0] = rslt.getString(26, 15);
                ((string[]) buf[31])[0] = rslt.getString(27, 100);
                ((string[]) buf[32])[0] = rslt.getString(28, 100);
                ((string[]) buf[33])[0] = rslt.getString(29, 100);
                ((string[]) buf[34])[0] = rslt.getString(30, 100);
                ((string[]) buf[35])[0] = rslt.getString(31, 100);
                ((string[]) buf[36])[0] = rslt.getMultimediaUri(32);
                ((bool[]) buf[37])[0] = rslt.wasNull(32);
                ((string[]) buf[38])[0] = rslt.getMultimediaFile(33, rslt.getVarchar(32));
                ((bool[]) buf[39])[0] = rslt.wasNull(33);
                return;
       }
    }

 }

}
