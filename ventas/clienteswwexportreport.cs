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
namespace GeneXus.Programs.ventas {
   public class clienteswwexportreport : GXWebProcedure
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

      public clienteswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clienteswwexportreport( IGxContext context )
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
         clienteswwexportreport objclienteswwexportreport;
         objclienteswwexportreport = new clienteswwexportreport();
         objclienteswwexportreport.context.SetSubmitInitialConfig(context);
         objclienteswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objclienteswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clienteswwexportreport)stateInfo).executePrivate();
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
            AV98Title = "Lista de Clientes";
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
            HGC0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CLIDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV14CliDsc1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14CliDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterCliDscDescription = StringUtil.Format( "%1 (%2)", "Razon Social", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterCliDscDescription = StringUtil.Format( "%1 (%2)", "Razon Social", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16CliDsc = AV14CliDsc1;
                  HGC0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCliDscDescription, "")), 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CliDsc, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CLIVENDDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV17CliVendDsc1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17CliVendDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV18FilterCliVendDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV18FilterCliVendDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV19CliVendDsc = AV17CliVendDsc1;
                  HGC0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterCliVendDscDescription, "")), 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CliVendDsc, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV20DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CLIDSC") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV23CliDsc2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23CliDsc2)) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterCliDscDescription = StringUtil.Format( "%1 (%2)", "Razon Social", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterCliDscDescription = StringUtil.Format( "%1 (%2)", "Razon Social", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16CliDsc = AV23CliDsc2;
                     HGC0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCliDscDescription, "")), 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CliDsc, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CLIVENDDSC") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV24CliVendDsc2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24CliVendDsc2)) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV18FilterCliVendDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV18FilterCliVendDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV19CliVendDsc = AV24CliVendDsc2;
                     HGC0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterCliVendDscDescription, "")), 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CliVendDsc, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV28CliDsc3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28CliDsc3)) )
                     {
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterCliDscDescription = StringUtil.Format( "%1 (%2)", "Razon Social", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterCliDscDescription = StringUtil.Format( "%1 (%2)", "Razon Social", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16CliDsc = AV28CliDsc3;
                        HGC0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterCliDscDescription, "")), 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CliDsc, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CLIVENDDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29CliVendDsc3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29CliVendDsc3)) )
                     {
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV18FilterCliVendDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV18FilterCliVendDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV19CliVendDsc = AV29CliVendDsc3;
                        HGC0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterCliVendDscDescription, "")), 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CliVendDsc, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCliCod_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Cliente", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFCliCod_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCliCod)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo Cliente", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFCliCod, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCliDsc_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Razon Social", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFCliDsc_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCliDsc)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Razon Social", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFCliDsc, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCliDir_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Dirección", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFCliDir_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCliDir)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Dirección", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFCliDir, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFEstCod_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFEstCod_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFEstCod)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Estado", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFEstCod, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFPaiCod_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Pais", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFPaiCod_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFPaiCod)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Pais", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFPaiCod, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TFCliTel1_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Telefono 1", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TFCliTel1_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCliTel1)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Telefono 1", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFCliTel1, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCliTel2_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Telefono 2", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFCliTel2_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCliTel2)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Telefono 2", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFCliTel2, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFCliFax_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Fax", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFCliFax_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFCliFax)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fax", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFCliFax, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TFCliCel_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Celular", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFCliCel_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCliCel)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Celular", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFCliCel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54TFCliEma_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("E-Mail", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54TFCliEma_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53TFCliEma)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("E-Mail", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53TFCliEma, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TFCliWeb_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Pagina Web", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56TFCliWeb_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TFCliWeb)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Pagina Web", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TFCliWeb, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV57TFTipCCod) && (0==AV58TFTipCCod_To) ) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo T. Cliente", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV57TFTipCCod), "ZZZZZ9")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV83TFTipCCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo T. Cliente", "Hasta", "", "", "", "", "", "", "");
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83TFTipCCod_To_Description, "")), 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV58TFTipCCod_To), "ZZZZZ9")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV59TFCliSts) && (0==AV60TFCliSts_To) ) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Situación", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV59TFCliSts), "9")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV84TFCliSts_To_Description = StringUtil.Format( "%1 (%2)", "Situación", "Hasta", "", "", "", "", "", "", "");
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84TFCliSts_To_Description, "")), 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV60TFCliSts_To), "9")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV61TFConpcod) && (0==AV62TFConpcod_To) ) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo condicion pago", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV61TFConpcod), "ZZZZZ9")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV85TFConpcod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo condicion pago", "Hasta", "", "", "", "", "", "", "");
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85TFConpcod_To_Description, "")), 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV62TFConpcod_To), "ZZZZZ9")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV63TFCliLim) && (Convert.ToDecimal(0)==AV64TFCliLim_To) ) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Limite Credito", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63TFCliLim, "ZZZZZZZZZZZ9.99")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV86TFCliLim_To_Description = StringUtil.Format( "%1 (%2)", "Limite Credito", "Hasta", "", "", "", "", "", "", "");
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV86TFCliLim_To_Description, "")), 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TFCliLim_To, "ZZZZZZZZZZZ9.99")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV65TFCliVend) && (0==AV66TFCliVend_To) ) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Vendedor", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV65TFCliVend), "ZZZZZ9")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV87TFCliVend_To_Description = StringUtil.Format( "%1 (%2)", "Vendedor", "Hasta", "", "", "", "", "", "", "");
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV87TFCliVend_To_Description, "")), 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV66TFCliVend_To), "ZZZZZ9")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCliVendDsc_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Vendedor", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68TFCliVendDsc_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFCliVendDsc)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Vendedor", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TFCliVendDsc, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70TFCliRef1_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 1", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70TFCliRef1_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69TFCliRef1)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 1", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TFCliRef1, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TFCliRef2_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 2", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72TFCliRef2_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71TFCliRef2)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 2", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71TFCliRef2, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74TFCliRef3_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 3", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74TFCliRef3_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73TFCliRef3)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 3", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73TFCliRef3, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76TFCliRef4_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 4", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76TFCliRef4_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75TFCliRef4)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 4", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75TFCliRef4, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78TFCliRef5_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 5", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78TFCliRef5_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77TFCliRef5)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 5", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77TFCliRef5, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80TFCliRef6_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 6", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80TFCliRef6_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79TFCliRef6)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 6", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79TFCliRef6, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82TFCliRef7_Sel)) )
         {
            HGC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Referencia 7", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82TFCliRef7_Sel, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TFCliRef7)) )
            {
               HGC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia 7", 25, Gx_line+0, 220, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81TFCliRef7, "")), 220, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HGC0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 10, 77, 152, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HGC0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 10, 77, 152, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo Cliente", 30, Gx_line+10, 56, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Razon Social", 60, Gx_line+10, 86, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Dirección", 90, Gx_line+10, 116, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 120, Gx_line+10, 146, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Pais", 150, Gx_line+10, 176, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Telefono 1", 180, Gx_line+10, 206, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Telefono 2", 210, Gx_line+10, 236, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Fax", 240, Gx_line+10, 266, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Celular", 270, Gx_line+10, 296, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("E-Mail", 300, Gx_line+10, 326, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Pagina Web", 330, Gx_line+10, 356, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo T. Cliente", 360, Gx_line+10, 386, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Foto", 390, Gx_line+10, 416, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Situación", 420, Gx_line+10, 446, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo condicion pago", 450, Gx_line+10, 476, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Limite Credito", 480, Gx_line+10, 506, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Vendedor", 510, Gx_line+10, 536, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Vendedor", 540, Gx_line+10, 566, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 1", 570, Gx_line+10, 596, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 2", 600, Gx_line+10, 627, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 3", 631, Gx_line+10, 659, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 4", 663, Gx_line+10, 691, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 5", 695, Gx_line+10, 723, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 6", 727, Gx_line+10, 755, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Referencia 7", 759, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV105Ventas_clienteswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV106Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV107Ventas_clienteswwds_3_clidsc1 = AV14CliDsc1;
         AV108Ventas_clienteswwds_4_clivenddsc1 = AV17CliVendDsc1;
         AV109Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV110Ventas_clienteswwds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV111Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV112Ventas_clienteswwds_8_clidsc2 = AV23CliDsc2;
         AV113Ventas_clienteswwds_9_clivenddsc2 = AV24CliVendDsc2;
         AV114Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV115Ventas_clienteswwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV116Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV117Ventas_clienteswwds_13_clidsc3 = AV28CliDsc3;
         AV118Ventas_clienteswwds_14_clivenddsc3 = AV29CliVendDsc3;
         AV119Ventas_clienteswwds_15_tfclicod = AV35TFCliCod;
         AV120Ventas_clienteswwds_16_tfclicod_sel = AV36TFCliCod_Sel;
         AV121Ventas_clienteswwds_17_tfclidsc = AV37TFCliDsc;
         AV122Ventas_clienteswwds_18_tfclidsc_sel = AV38TFCliDsc_Sel;
         AV123Ventas_clienteswwds_19_tfclidir = AV39TFCliDir;
         AV124Ventas_clienteswwds_20_tfclidir_sel = AV40TFCliDir_Sel;
         AV125Ventas_clienteswwds_21_tfestcod = AV41TFEstCod;
         AV126Ventas_clienteswwds_22_tfestcod_sel = AV42TFEstCod_Sel;
         AV127Ventas_clienteswwds_23_tfpaicod = AV43TFPaiCod;
         AV128Ventas_clienteswwds_24_tfpaicod_sel = AV44TFPaiCod_Sel;
         AV129Ventas_clienteswwds_25_tfclitel1 = AV45TFCliTel1;
         AV130Ventas_clienteswwds_26_tfclitel1_sel = AV46TFCliTel1_Sel;
         AV131Ventas_clienteswwds_27_tfclitel2 = AV47TFCliTel2;
         AV132Ventas_clienteswwds_28_tfclitel2_sel = AV48TFCliTel2_Sel;
         AV133Ventas_clienteswwds_29_tfclifax = AV49TFCliFax;
         AV134Ventas_clienteswwds_30_tfclifax_sel = AV50TFCliFax_Sel;
         AV135Ventas_clienteswwds_31_tfclicel = AV51TFCliCel;
         AV136Ventas_clienteswwds_32_tfclicel_sel = AV52TFCliCel_Sel;
         AV137Ventas_clienteswwds_33_tfcliema = AV53TFCliEma;
         AV138Ventas_clienteswwds_34_tfcliema_sel = AV54TFCliEma_Sel;
         AV139Ventas_clienteswwds_35_tfcliweb = AV55TFCliWeb;
         AV140Ventas_clienteswwds_36_tfcliweb_sel = AV56TFCliWeb_Sel;
         AV141Ventas_clienteswwds_37_tftipccod = AV57TFTipCCod;
         AV142Ventas_clienteswwds_38_tftipccod_to = AV58TFTipCCod_To;
         AV143Ventas_clienteswwds_39_tfclists = AV59TFCliSts;
         AV144Ventas_clienteswwds_40_tfclists_to = AV60TFCliSts_To;
         AV145Ventas_clienteswwds_41_tfconpcod = AV61TFConpcod;
         AV146Ventas_clienteswwds_42_tfconpcod_to = AV62TFConpcod_To;
         AV147Ventas_clienteswwds_43_tfclilim = AV63TFCliLim;
         AV148Ventas_clienteswwds_44_tfclilim_to = AV64TFCliLim_To;
         AV149Ventas_clienteswwds_45_tfclivend = AV65TFCliVend;
         AV150Ventas_clienteswwds_46_tfclivend_to = AV66TFCliVend_To;
         AV151Ventas_clienteswwds_47_tfclivenddsc = AV67TFCliVendDsc;
         AV152Ventas_clienteswwds_48_tfclivenddsc_sel = AV68TFCliVendDsc_Sel;
         AV153Ventas_clienteswwds_49_tfcliref1 = AV69TFCliRef1;
         AV154Ventas_clienteswwds_50_tfcliref1_sel = AV70TFCliRef1_Sel;
         AV155Ventas_clienteswwds_51_tfcliref2 = AV71TFCliRef2;
         AV156Ventas_clienteswwds_52_tfcliref2_sel = AV72TFCliRef2_Sel;
         AV157Ventas_clienteswwds_53_tfcliref3 = AV73TFCliRef3;
         AV158Ventas_clienteswwds_54_tfcliref3_sel = AV74TFCliRef3_Sel;
         AV159Ventas_clienteswwds_55_tfcliref4 = AV75TFCliRef4;
         AV160Ventas_clienteswwds_56_tfcliref4_sel = AV76TFCliRef4_Sel;
         AV161Ventas_clienteswwds_57_tfcliref5 = AV77TFCliRef5;
         AV162Ventas_clienteswwds_58_tfcliref5_sel = AV78TFCliRef5_Sel;
         AV163Ventas_clienteswwds_59_tfcliref6 = AV79TFCliRef6;
         AV164Ventas_clienteswwds_60_tfcliref6_sel = AV80TFCliRef6_Sel;
         AV165Ventas_clienteswwds_61_tfcliref7 = AV81TFCliRef7;
         AV166Ventas_clienteswwds_62_tfcliref7_sel = AV82TFCliRef7_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV105Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV106Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV107Ventas_clienteswwds_3_clidsc1 ,
                                              AV108Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV109Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV110Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV111Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV112Ventas_clienteswwds_8_clidsc2 ,
                                              AV113Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV114Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV115Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV116Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV117Ventas_clienteswwds_13_clidsc3 ,
                                              AV118Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV120Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV119Ventas_clienteswwds_15_tfclicod ,
                                              AV122Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV121Ventas_clienteswwds_17_tfclidsc ,
                                              AV124Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV123Ventas_clienteswwds_19_tfclidir ,
                                              AV126Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV125Ventas_clienteswwds_21_tfestcod ,
                                              AV128Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV127Ventas_clienteswwds_23_tfpaicod ,
                                              AV130Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV129Ventas_clienteswwds_25_tfclitel1 ,
                                              AV132Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV131Ventas_clienteswwds_27_tfclitel2 ,
                                              AV134Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV133Ventas_clienteswwds_29_tfclifax ,
                                              AV136Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV135Ventas_clienteswwds_31_tfclicel ,
                                              AV138Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV137Ventas_clienteswwds_33_tfcliema ,
                                              AV140Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV139Ventas_clienteswwds_35_tfcliweb ,
                                              AV141Ventas_clienteswwds_37_tftipccod ,
                                              AV142Ventas_clienteswwds_38_tftipccod_to ,
                                              AV143Ventas_clienteswwds_39_tfclists ,
                                              AV144Ventas_clienteswwds_40_tfclists_to ,
                                              AV145Ventas_clienteswwds_41_tfconpcod ,
                                              AV146Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV147Ventas_clienteswwds_43_tfclilim ,
                                              AV148Ventas_clienteswwds_44_tfclilim_to ,
                                              AV149Ventas_clienteswwds_45_tfclivend ,
                                              AV150Ventas_clienteswwds_46_tfclivend_to ,
                                              AV152Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV151Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV154Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV153Ventas_clienteswwds_49_tfcliref1 ,
                                              AV156Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV155Ventas_clienteswwds_51_tfcliref2 ,
                                              AV158Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV157Ventas_clienteswwds_53_tfcliref3 ,
                                              AV160Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV159Ventas_clienteswwds_55_tfcliref4 ,
                                              AV162Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV161Ventas_clienteswwds_57_tfcliref5 ,
                                              AV164Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV163Ventas_clienteswwds_59_tfcliref6 ,
                                              AV166Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV165Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV107Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV107Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV108Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV108Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV112Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV112Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV113Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV113Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV113Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV113Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV117Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV117Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV117Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV117Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV118Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV118Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV119Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV119Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV121Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV121Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV123Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV123Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV125Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV125Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV127Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV127Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV129Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV129Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV131Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV131Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV133Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV133Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV135Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV135Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV137Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV137Ventas_clienteswwds_33_tfcliema), "%", "");
         lV139Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV139Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV151Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV151Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV153Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV153Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV155Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV155Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV157Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV157Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV159Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV159Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV161Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV161Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV163Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV163Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV165Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV165Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GC2 */
         pr_default.execute(0, new Object[] {lV107Ventas_clienteswwds_3_clidsc1, lV107Ventas_clienteswwds_3_clidsc1, lV108Ventas_clienteswwds_4_clivenddsc1, lV108Ventas_clienteswwds_4_clivenddsc1, lV112Ventas_clienteswwds_8_clidsc2, lV112Ventas_clienteswwds_8_clidsc2, lV113Ventas_clienteswwds_9_clivenddsc2, lV113Ventas_clienteswwds_9_clivenddsc2, lV117Ventas_clienteswwds_13_clidsc3, lV117Ventas_clienteswwds_13_clidsc3, lV118Ventas_clienteswwds_14_clivenddsc3, lV118Ventas_clienteswwds_14_clivenddsc3, lV119Ventas_clienteswwds_15_tfclicod, AV120Ventas_clienteswwds_16_tfclicod_sel, lV121Ventas_clienteswwds_17_tfclidsc, AV122Ventas_clienteswwds_18_tfclidsc_sel, lV123Ventas_clienteswwds_19_tfclidir, AV124Ventas_clienteswwds_20_tfclidir_sel, lV125Ventas_clienteswwds_21_tfestcod, AV126Ventas_clienteswwds_22_tfestcod_sel, lV127Ventas_clienteswwds_23_tfpaicod, AV128Ventas_clienteswwds_24_tfpaicod_sel, lV129Ventas_clienteswwds_25_tfclitel1, AV130Ventas_clienteswwds_26_tfclitel1_sel, lV131Ventas_clienteswwds_27_tfclitel2, AV132Ventas_clienteswwds_28_tfclitel2_sel, lV133Ventas_clienteswwds_29_tfclifax, AV134Ventas_clienteswwds_30_tfclifax_sel, lV135Ventas_clienteswwds_31_tfclicel, AV136Ventas_clienteswwds_32_tfclicel_sel, lV137Ventas_clienteswwds_33_tfcliema, AV138Ventas_clienteswwds_34_tfcliema_sel, lV139Ventas_clienteswwds_35_tfcliweb, AV140Ventas_clienteswwds_36_tfcliweb_sel, AV141Ventas_clienteswwds_37_tftipccod, AV142Ventas_clienteswwds_38_tftipccod_to, AV143Ventas_clienteswwds_39_tfclists, AV144Ventas_clienteswwds_40_tfclists_to, AV145Ventas_clienteswwds_41_tfconpcod, AV146Ventas_clienteswwds_42_tfconpcod_to, AV147Ventas_clienteswwds_43_tfclilim, AV148Ventas_clienteswwds_44_tfclilim_to, AV149Ventas_clienteswwds_45_tfclivend, AV150Ventas_clienteswwds_46_tfclivend_to, lV151Ventas_clienteswwds_47_tfclivenddsc, AV152Ventas_clienteswwds_48_tfclivenddsc_sel, lV153Ventas_clienteswwds_49_tfcliref1, AV154Ventas_clienteswwds_50_tfcliref1_sel, lV155Ventas_clienteswwds_51_tfcliref2, AV156Ventas_clienteswwds_52_tfcliref2_sel, lV157Ventas_clienteswwds_53_tfcliref3, AV158Ventas_clienteswwds_54_tfcliref3_sel, lV159Ventas_clienteswwds_55_tfcliref4, AV160Ventas_clienteswwds_56_tfcliref4_sel, lV161Ventas_clienteswwds_57_tfcliref5, AV162Ventas_clienteswwds_58_tfcliref5_sel, lV163Ventas_clienteswwds_59_tfcliref6, AV164Ventas_clienteswwds_60_tfcliref6_sel, lV165Ventas_clienteswwds_61_tfcliref7, AV166Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A624CliRef7 = P00GC2_A624CliRef7[0];
            A623CliRef6 = P00GC2_A623CliRef6[0];
            A622CliRef5 = P00GC2_A622CliRef5[0];
            A621CliRef4 = P00GC2_A621CliRef4[0];
            A620CliRef3 = P00GC2_A620CliRef3[0];
            A619CliRef2 = P00GC2_A619CliRef2[0];
            A618CliRef1 = P00GC2_A618CliRef1[0];
            A160CliVend = P00GC2_A160CliVend[0];
            A613CliLim = P00GC2_A613CliLim[0];
            A137Conpcod = P00GC2_A137Conpcod[0];
            A627CliSts = P00GC2_A627CliSts[0];
            A159TipCCod = P00GC2_A159TipCCod[0];
            A637CliWeb = P00GC2_A637CliWeb[0];
            A609CliEma = P00GC2_A609CliEma[0];
            A575CliCel = P00GC2_A575CliCel[0];
            A611CliFax = P00GC2_A611CliFax[0];
            A630CliTel2 = P00GC2_A630CliTel2[0];
            A629CliTel1 = P00GC2_A629CliTel1[0];
            A139PaiCod = P00GC2_A139PaiCod[0];
            A140EstCod = P00GC2_A140EstCod[0];
            A596CliDir = P00GC2_A596CliDir[0];
            A45CliCod = P00GC2_A45CliCod[0];
            A635CliVendDsc = P00GC2_A635CliVendDsc[0];
            A161CliDsc = P00GC2_A161CliDsc[0];
            A40000CliFoto_GXI = P00GC2_A40000CliFoto_GXI[0];
            n40000CliFoto_GXI = P00GC2_n40000CliFoto_GXI[0];
            A612CliFoto = P00GC2_A612CliFoto[0];
            n612CliFoto = P00GC2_n612CliFoto[0];
            A635CliVendDsc = P00GC2_A635CliVendDsc[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HGC0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A45CliCod, "")), 30, Gx_line+10, 56, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A161CliDsc, "")), 60, Gx_line+10, 86, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A596CliDir, "")), 90, Gx_line+10, 116, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A140EstCod, "")), 120, Gx_line+10, 146, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A139PaiCod, "")), 150, Gx_line+10, 176, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A629CliTel1, "")), 180, Gx_line+10, 206, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A630CliTel2, "")), 210, Gx_line+10, 236, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A611CliFax, "")), 240, Gx_line+10, 266, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A575CliCel, "")), 270, Gx_line+10, 296, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A609CliEma, "")), 300, Gx_line+10, 326, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A637CliWeb, "")), 330, Gx_line+10, 356, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A159TipCCod), "ZZZZZ9")), 360, Gx_line+10, 386, Gx_line+25, 2, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : A612CliFoto);
            getPrinter().GxDrawBitMap(sImgUrl, 390, Gx_line+10, 416, Gx_line+25) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A627CliSts), "9")), 420, Gx_line+10, 446, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A137Conpcod), "ZZZZZ9")), 450, Gx_line+10, 476, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A613CliLim, "ZZZZZZZZZZZ9.99")), 480, Gx_line+10, 506, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A160CliVend), "ZZZZZ9")), 510, Gx_line+10, 536, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A635CliVendDsc, "")), 540, Gx_line+10, 566, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A618CliRef1, "")), 570, Gx_line+10, 596, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A619CliRef2, "")), 600, Gx_line+10, 627, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A620CliRef3, "")), 631, Gx_line+10, 659, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A621CliRef4, "")), 663, Gx_line+10, 691, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A622CliRef5, "")), 695, Gx_line+10, 723, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A623CliRef6, "")), 727, Gx_line+10, 755, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A624CliRef7, "")), 759, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV31Session.Get("Ventas.ClientesWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Ventas.ClientesWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Ventas.ClientesWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV167GXV1 = 1;
         while ( AV167GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV167GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLICOD") == 0 )
            {
               AV35TFCliCod = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLICOD_SEL") == 0 )
            {
               AV36TFCliCod_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIDSC") == 0 )
            {
               AV37TFCliDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIDSC_SEL") == 0 )
            {
               AV38TFCliDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIDIR") == 0 )
            {
               AV39TFCliDir = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIDIR_SEL") == 0 )
            {
               AV40TFCliDir_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTCOD") == 0 )
            {
               AV41TFEstCod = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTCOD_SEL") == 0 )
            {
               AV42TFEstCod_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPAICOD") == 0 )
            {
               AV43TFPaiCod = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPAICOD_SEL") == 0 )
            {
               AV44TFPaiCod_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLITEL1") == 0 )
            {
               AV45TFCliTel1 = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLITEL1_SEL") == 0 )
            {
               AV46TFCliTel1_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLITEL2") == 0 )
            {
               AV47TFCliTel2 = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLITEL2_SEL") == 0 )
            {
               AV48TFCliTel2_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIFAX") == 0 )
            {
               AV49TFCliFax = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIFAX_SEL") == 0 )
            {
               AV50TFCliFax_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLICEL") == 0 )
            {
               AV51TFCliCel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLICEL_SEL") == 0 )
            {
               AV52TFCliCel_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIEMA") == 0 )
            {
               AV53TFCliEma = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIEMA_SEL") == 0 )
            {
               AV54TFCliEma_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIWEB") == 0 )
            {
               AV55TFCliWeb = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIWEB_SEL") == 0 )
            {
               AV56TFCliWeb_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPCCOD") == 0 )
            {
               AV57TFTipCCod = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV58TFTipCCod_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLISTS") == 0 )
            {
               AV59TFCliSts = (short)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV60TFCliSts_To = (short)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONPCOD") == 0 )
            {
               AV61TFConpcod = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV62TFConpcod_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLILIM") == 0 )
            {
               AV63TFCliLim = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV64TFCliLim_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIVEND") == 0 )
            {
               AV65TFCliVend = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV66TFCliVend_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIVENDDSC") == 0 )
            {
               AV67TFCliVendDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIVENDDSC_SEL") == 0 )
            {
               AV68TFCliVendDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIREF1") == 0 )
            {
               AV69TFCliRef1 = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIREF1_SEL") == 0 )
            {
               AV70TFCliRef1_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIREF2") == 0 )
            {
               AV71TFCliRef2 = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIREF2_SEL") == 0 )
            {
               AV72TFCliRef2_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIREF3") == 0 )
            {
               AV73TFCliRef3 = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIREF3_SEL") == 0 )
            {
               AV74TFCliRef3_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIREF4") == 0 )
            {
               AV75TFCliRef4 = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIREF4_SEL") == 0 )
            {
               AV76TFCliRef4_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIREF5") == 0 )
            {
               AV77TFCliRef5 = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIREF5_SEL") == 0 )
            {
               AV78TFCliRef5_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIREF6") == 0 )
            {
               AV79TFCliRef6 = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIREF6_SEL") == 0 )
            {
               AV80TFCliRef6_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIREF7") == 0 )
            {
               AV81TFCliRef7 = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIREF7_SEL") == 0 )
            {
               AV82TFCliRef7_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            AV167GXV1 = (int)(AV167GXV1+1);
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

      protected void HGC0( bool bFoot ,
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
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
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
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
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
         AV14CliDsc1 = "";
         AV15FilterCliDscDescription = "";
         AV16CliDsc = "";
         AV17CliVendDsc1 = "";
         AV18FilterCliVendDscDescription = "";
         AV19CliVendDsc = "";
         AV21DynamicFiltersSelector2 = "";
         AV23CliDsc2 = "";
         AV24CliVendDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28CliDsc3 = "";
         AV29CliVendDsc3 = "";
         AV36TFCliCod_Sel = "";
         AV35TFCliCod = "";
         AV38TFCliDsc_Sel = "";
         AV37TFCliDsc = "";
         AV40TFCliDir_Sel = "";
         AV39TFCliDir = "";
         AV42TFEstCod_Sel = "";
         AV41TFEstCod = "";
         AV44TFPaiCod_Sel = "";
         AV43TFPaiCod = "";
         AV46TFCliTel1_Sel = "";
         AV45TFCliTel1 = "";
         AV48TFCliTel2_Sel = "";
         AV47TFCliTel2 = "";
         AV50TFCliFax_Sel = "";
         AV49TFCliFax = "";
         AV52TFCliCel_Sel = "";
         AV51TFCliCel = "";
         AV54TFCliEma_Sel = "";
         AV53TFCliEma = "";
         AV56TFCliWeb_Sel = "";
         AV55TFCliWeb = "";
         AV83TFTipCCod_To_Description = "";
         AV84TFCliSts_To_Description = "";
         AV85TFConpcod_To_Description = "";
         AV86TFCliLim_To_Description = "";
         AV87TFCliVend_To_Description = "";
         AV68TFCliVendDsc_Sel = "";
         AV67TFCliVendDsc = "";
         AV70TFCliRef1_Sel = "";
         AV69TFCliRef1 = "";
         AV72TFCliRef2_Sel = "";
         AV71TFCliRef2 = "";
         AV74TFCliRef3_Sel = "";
         AV73TFCliRef3 = "";
         AV76TFCliRef4_Sel = "";
         AV75TFCliRef4 = "";
         AV78TFCliRef5_Sel = "";
         AV77TFCliRef5 = "";
         AV80TFCliRef6_Sel = "";
         AV79TFCliRef6 = "";
         AV82TFCliRef7_Sel = "";
         AV81TFCliRef7 = "";
         AV105Ventas_clienteswwds_1_dynamicfiltersselector1 = "";
         AV107Ventas_clienteswwds_3_clidsc1 = "";
         AV108Ventas_clienteswwds_4_clivenddsc1 = "";
         AV110Ventas_clienteswwds_6_dynamicfiltersselector2 = "";
         AV112Ventas_clienteswwds_8_clidsc2 = "";
         AV113Ventas_clienteswwds_9_clivenddsc2 = "";
         AV115Ventas_clienteswwds_11_dynamicfiltersselector3 = "";
         AV117Ventas_clienteswwds_13_clidsc3 = "";
         AV118Ventas_clienteswwds_14_clivenddsc3 = "";
         AV119Ventas_clienteswwds_15_tfclicod = "";
         AV120Ventas_clienteswwds_16_tfclicod_sel = "";
         AV121Ventas_clienteswwds_17_tfclidsc = "";
         AV122Ventas_clienteswwds_18_tfclidsc_sel = "";
         AV123Ventas_clienteswwds_19_tfclidir = "";
         AV124Ventas_clienteswwds_20_tfclidir_sel = "";
         AV125Ventas_clienteswwds_21_tfestcod = "";
         AV126Ventas_clienteswwds_22_tfestcod_sel = "";
         AV127Ventas_clienteswwds_23_tfpaicod = "";
         AV128Ventas_clienteswwds_24_tfpaicod_sel = "";
         AV129Ventas_clienteswwds_25_tfclitel1 = "";
         AV130Ventas_clienteswwds_26_tfclitel1_sel = "";
         AV131Ventas_clienteswwds_27_tfclitel2 = "";
         AV132Ventas_clienteswwds_28_tfclitel2_sel = "";
         AV133Ventas_clienteswwds_29_tfclifax = "";
         AV134Ventas_clienteswwds_30_tfclifax_sel = "";
         AV135Ventas_clienteswwds_31_tfclicel = "";
         AV136Ventas_clienteswwds_32_tfclicel_sel = "";
         AV137Ventas_clienteswwds_33_tfcliema = "";
         AV138Ventas_clienteswwds_34_tfcliema_sel = "";
         AV139Ventas_clienteswwds_35_tfcliweb = "";
         AV140Ventas_clienteswwds_36_tfcliweb_sel = "";
         AV151Ventas_clienteswwds_47_tfclivenddsc = "";
         AV152Ventas_clienteswwds_48_tfclivenddsc_sel = "";
         AV153Ventas_clienteswwds_49_tfcliref1 = "";
         AV154Ventas_clienteswwds_50_tfcliref1_sel = "";
         AV155Ventas_clienteswwds_51_tfcliref2 = "";
         AV156Ventas_clienteswwds_52_tfcliref2_sel = "";
         AV157Ventas_clienteswwds_53_tfcliref3 = "";
         AV158Ventas_clienteswwds_54_tfcliref3_sel = "";
         AV159Ventas_clienteswwds_55_tfcliref4 = "";
         AV160Ventas_clienteswwds_56_tfcliref4_sel = "";
         AV161Ventas_clienteswwds_57_tfcliref5 = "";
         AV162Ventas_clienteswwds_58_tfcliref5_sel = "";
         AV163Ventas_clienteswwds_59_tfcliref6 = "";
         AV164Ventas_clienteswwds_60_tfcliref6_sel = "";
         AV165Ventas_clienteswwds_61_tfcliref7 = "";
         AV166Ventas_clienteswwds_62_tfcliref7_sel = "";
         scmdbuf = "";
         lV107Ventas_clienteswwds_3_clidsc1 = "";
         lV108Ventas_clienteswwds_4_clivenddsc1 = "";
         lV112Ventas_clienteswwds_8_clidsc2 = "";
         lV113Ventas_clienteswwds_9_clivenddsc2 = "";
         lV117Ventas_clienteswwds_13_clidsc3 = "";
         lV118Ventas_clienteswwds_14_clivenddsc3 = "";
         lV119Ventas_clienteswwds_15_tfclicod = "";
         lV121Ventas_clienteswwds_17_tfclidsc = "";
         lV123Ventas_clienteswwds_19_tfclidir = "";
         lV125Ventas_clienteswwds_21_tfestcod = "";
         lV127Ventas_clienteswwds_23_tfpaicod = "";
         lV129Ventas_clienteswwds_25_tfclitel1 = "";
         lV131Ventas_clienteswwds_27_tfclitel2 = "";
         lV133Ventas_clienteswwds_29_tfclifax = "";
         lV135Ventas_clienteswwds_31_tfclicel = "";
         lV137Ventas_clienteswwds_33_tfcliema = "";
         lV139Ventas_clienteswwds_35_tfcliweb = "";
         lV151Ventas_clienteswwds_47_tfclivenddsc = "";
         lV153Ventas_clienteswwds_49_tfcliref1 = "";
         lV155Ventas_clienteswwds_51_tfcliref2 = "";
         lV157Ventas_clienteswwds_53_tfcliref3 = "";
         lV159Ventas_clienteswwds_55_tfcliref4 = "";
         lV161Ventas_clienteswwds_57_tfcliref5 = "";
         lV163Ventas_clienteswwds_59_tfcliref6 = "";
         lV165Ventas_clienteswwds_61_tfcliref7 = "";
         A161CliDsc = "";
         A635CliVendDsc = "";
         A45CliCod = "";
         A596CliDir = "";
         A140EstCod = "";
         A139PaiCod = "";
         A629CliTel1 = "";
         A630CliTel2 = "";
         A611CliFax = "";
         A575CliCel = "";
         A609CliEma = "";
         A637CliWeb = "";
         A618CliRef1 = "";
         A619CliRef2 = "";
         A620CliRef3 = "";
         A621CliRef4 = "";
         A622CliRef5 = "";
         A623CliRef6 = "";
         A624CliRef7 = "";
         P00GC2_A624CliRef7 = new string[] {""} ;
         P00GC2_A623CliRef6 = new string[] {""} ;
         P00GC2_A622CliRef5 = new string[] {""} ;
         P00GC2_A621CliRef4 = new string[] {""} ;
         P00GC2_A620CliRef3 = new string[] {""} ;
         P00GC2_A619CliRef2 = new string[] {""} ;
         P00GC2_A618CliRef1 = new string[] {""} ;
         P00GC2_A160CliVend = new int[1] ;
         P00GC2_A613CliLim = new decimal[1] ;
         P00GC2_A137Conpcod = new int[1] ;
         P00GC2_A627CliSts = new short[1] ;
         P00GC2_A159TipCCod = new int[1] ;
         P00GC2_A637CliWeb = new string[] {""} ;
         P00GC2_A609CliEma = new string[] {""} ;
         P00GC2_A575CliCel = new string[] {""} ;
         P00GC2_A611CliFax = new string[] {""} ;
         P00GC2_A630CliTel2 = new string[] {""} ;
         P00GC2_A629CliTel1 = new string[] {""} ;
         P00GC2_A139PaiCod = new string[] {""} ;
         P00GC2_A140EstCod = new string[] {""} ;
         P00GC2_A596CliDir = new string[] {""} ;
         P00GC2_A45CliCod = new string[] {""} ;
         P00GC2_A635CliVendDsc = new string[] {""} ;
         P00GC2_A161CliDsc = new string[] {""} ;
         P00GC2_A40000CliFoto_GXI = new string[] {""} ;
         P00GC2_n40000CliFoto_GXI = new bool[] {false} ;
         P00GC2_A612CliFoto = new string[] {""} ;
         P00GC2_n612CliFoto = new bool[] {false} ;
         A40000CliFoto_GXI = "";
         A612CliFoto = "";
         sImgUrl = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas.clienteswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00GC2_A624CliRef7, P00GC2_A623CliRef6, P00GC2_A622CliRef5, P00GC2_A621CliRef4, P00GC2_A620CliRef3, P00GC2_A619CliRef2, P00GC2_A618CliRef1, P00GC2_A160CliVend, P00GC2_A613CliLim, P00GC2_A137Conpcod,
               P00GC2_A627CliSts, P00GC2_A159TipCCod, P00GC2_A637CliWeb, P00GC2_A609CliEma, P00GC2_A575CliCel, P00GC2_A611CliFax, P00GC2_A630CliTel2, P00GC2_A629CliTel1, P00GC2_A139PaiCod, P00GC2_A140EstCod,
               P00GC2_A596CliDir, P00GC2_A45CliCod, P00GC2_A635CliVendDsc, P00GC2_A161CliDsc, P00GC2_A40000CliFoto_GXI, P00GC2_n40000CliFoto_GXI, P00GC2_A612CliFoto, P00GC2_n612CliFoto
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
      private short AV59TFCliSts ;
      private short AV60TFCliSts_To ;
      private short AV106Ventas_clienteswwds_2_dynamicfiltersoperator1 ;
      private short AV111Ventas_clienteswwds_7_dynamicfiltersoperator2 ;
      private short AV116Ventas_clienteswwds_12_dynamicfiltersoperator3 ;
      private short AV143Ventas_clienteswwds_39_tfclists ;
      private short AV144Ventas_clienteswwds_40_tfclists_to ;
      private short A627CliSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV57TFTipCCod ;
      private int AV58TFTipCCod_To ;
      private int AV61TFConpcod ;
      private int AV62TFConpcod_To ;
      private int AV65TFCliVend ;
      private int AV66TFCliVend_To ;
      private int AV141Ventas_clienteswwds_37_tftipccod ;
      private int AV142Ventas_clienteswwds_38_tftipccod_to ;
      private int AV145Ventas_clienteswwds_41_tfconpcod ;
      private int AV146Ventas_clienteswwds_42_tfconpcod_to ;
      private int AV149Ventas_clienteswwds_45_tfclivend ;
      private int AV150Ventas_clienteswwds_46_tfclivend_to ;
      private int A159TipCCod ;
      private int A137Conpcod ;
      private int A160CliVend ;
      private int AV167GXV1 ;
      private decimal AV63TFCliLim ;
      private decimal AV64TFCliLim_To ;
      private decimal AV147Ventas_clienteswwds_43_tfclilim ;
      private decimal AV148Ventas_clienteswwds_44_tfclilim_to ;
      private decimal A613CliLim ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14CliDsc1 ;
      private string AV16CliDsc ;
      private string AV17CliVendDsc1 ;
      private string AV19CliVendDsc ;
      private string AV23CliDsc2 ;
      private string AV24CliVendDsc2 ;
      private string AV28CliDsc3 ;
      private string AV29CliVendDsc3 ;
      private string AV36TFCliCod_Sel ;
      private string AV35TFCliCod ;
      private string AV38TFCliDsc_Sel ;
      private string AV37TFCliDsc ;
      private string AV40TFCliDir_Sel ;
      private string AV39TFCliDir ;
      private string AV42TFEstCod_Sel ;
      private string AV41TFEstCod ;
      private string AV44TFPaiCod_Sel ;
      private string AV43TFPaiCod ;
      private string AV46TFCliTel1_Sel ;
      private string AV45TFCliTel1 ;
      private string AV48TFCliTel2_Sel ;
      private string AV47TFCliTel2 ;
      private string AV50TFCliFax_Sel ;
      private string AV49TFCliFax ;
      private string AV52TFCliCel_Sel ;
      private string AV51TFCliCel ;
      private string AV56TFCliWeb_Sel ;
      private string AV55TFCliWeb ;
      private string AV68TFCliVendDsc_Sel ;
      private string AV67TFCliVendDsc ;
      private string AV70TFCliRef1_Sel ;
      private string AV69TFCliRef1 ;
      private string AV72TFCliRef2_Sel ;
      private string AV71TFCliRef2 ;
      private string AV74TFCliRef3_Sel ;
      private string AV73TFCliRef3 ;
      private string AV76TFCliRef4_Sel ;
      private string AV75TFCliRef4 ;
      private string AV78TFCliRef5_Sel ;
      private string AV77TFCliRef5 ;
      private string AV80TFCliRef6_Sel ;
      private string AV79TFCliRef6 ;
      private string AV82TFCliRef7_Sel ;
      private string AV81TFCliRef7 ;
      private string AV107Ventas_clienteswwds_3_clidsc1 ;
      private string AV108Ventas_clienteswwds_4_clivenddsc1 ;
      private string AV112Ventas_clienteswwds_8_clidsc2 ;
      private string AV113Ventas_clienteswwds_9_clivenddsc2 ;
      private string AV117Ventas_clienteswwds_13_clidsc3 ;
      private string AV118Ventas_clienteswwds_14_clivenddsc3 ;
      private string AV119Ventas_clienteswwds_15_tfclicod ;
      private string AV120Ventas_clienteswwds_16_tfclicod_sel ;
      private string AV121Ventas_clienteswwds_17_tfclidsc ;
      private string AV122Ventas_clienteswwds_18_tfclidsc_sel ;
      private string AV123Ventas_clienteswwds_19_tfclidir ;
      private string AV124Ventas_clienteswwds_20_tfclidir_sel ;
      private string AV125Ventas_clienteswwds_21_tfestcod ;
      private string AV126Ventas_clienteswwds_22_tfestcod_sel ;
      private string AV127Ventas_clienteswwds_23_tfpaicod ;
      private string AV128Ventas_clienteswwds_24_tfpaicod_sel ;
      private string AV129Ventas_clienteswwds_25_tfclitel1 ;
      private string AV130Ventas_clienteswwds_26_tfclitel1_sel ;
      private string AV131Ventas_clienteswwds_27_tfclitel2 ;
      private string AV132Ventas_clienteswwds_28_tfclitel2_sel ;
      private string AV133Ventas_clienteswwds_29_tfclifax ;
      private string AV134Ventas_clienteswwds_30_tfclifax_sel ;
      private string AV135Ventas_clienteswwds_31_tfclicel ;
      private string AV136Ventas_clienteswwds_32_tfclicel_sel ;
      private string AV139Ventas_clienteswwds_35_tfcliweb ;
      private string AV140Ventas_clienteswwds_36_tfcliweb_sel ;
      private string AV151Ventas_clienteswwds_47_tfclivenddsc ;
      private string AV152Ventas_clienteswwds_48_tfclivenddsc_sel ;
      private string AV153Ventas_clienteswwds_49_tfcliref1 ;
      private string AV154Ventas_clienteswwds_50_tfcliref1_sel ;
      private string AV155Ventas_clienteswwds_51_tfcliref2 ;
      private string AV156Ventas_clienteswwds_52_tfcliref2_sel ;
      private string AV157Ventas_clienteswwds_53_tfcliref3 ;
      private string AV158Ventas_clienteswwds_54_tfcliref3_sel ;
      private string AV159Ventas_clienteswwds_55_tfcliref4 ;
      private string AV160Ventas_clienteswwds_56_tfcliref4_sel ;
      private string AV161Ventas_clienteswwds_57_tfcliref5 ;
      private string AV162Ventas_clienteswwds_58_tfcliref5_sel ;
      private string AV163Ventas_clienteswwds_59_tfcliref6 ;
      private string AV164Ventas_clienteswwds_60_tfcliref6_sel ;
      private string AV165Ventas_clienteswwds_61_tfcliref7 ;
      private string AV166Ventas_clienteswwds_62_tfcliref7_sel ;
      private string scmdbuf ;
      private string lV107Ventas_clienteswwds_3_clidsc1 ;
      private string lV108Ventas_clienteswwds_4_clivenddsc1 ;
      private string lV112Ventas_clienteswwds_8_clidsc2 ;
      private string lV113Ventas_clienteswwds_9_clivenddsc2 ;
      private string lV117Ventas_clienteswwds_13_clidsc3 ;
      private string lV118Ventas_clienteswwds_14_clivenddsc3 ;
      private string lV119Ventas_clienteswwds_15_tfclicod ;
      private string lV121Ventas_clienteswwds_17_tfclidsc ;
      private string lV123Ventas_clienteswwds_19_tfclidir ;
      private string lV125Ventas_clienteswwds_21_tfestcod ;
      private string lV127Ventas_clienteswwds_23_tfpaicod ;
      private string lV129Ventas_clienteswwds_25_tfclitel1 ;
      private string lV131Ventas_clienteswwds_27_tfclitel2 ;
      private string lV133Ventas_clienteswwds_29_tfclifax ;
      private string lV135Ventas_clienteswwds_31_tfclicel ;
      private string lV139Ventas_clienteswwds_35_tfcliweb ;
      private string lV151Ventas_clienteswwds_47_tfclivenddsc ;
      private string lV153Ventas_clienteswwds_49_tfcliref1 ;
      private string lV155Ventas_clienteswwds_51_tfcliref2 ;
      private string lV157Ventas_clienteswwds_53_tfcliref3 ;
      private string lV159Ventas_clienteswwds_55_tfcliref4 ;
      private string lV161Ventas_clienteswwds_57_tfcliref5 ;
      private string lV163Ventas_clienteswwds_59_tfcliref6 ;
      private string lV165Ventas_clienteswwds_61_tfcliref7 ;
      private string A161CliDsc ;
      private string A635CliVendDsc ;
      private string A45CliCod ;
      private string A596CliDir ;
      private string A140EstCod ;
      private string A139PaiCod ;
      private string A629CliTel1 ;
      private string A630CliTel2 ;
      private string A611CliFax ;
      private string A575CliCel ;
      private string A637CliWeb ;
      private string A618CliRef1 ;
      private string A619CliRef2 ;
      private string A620CliRef3 ;
      private string A621CliRef4 ;
      private string A622CliRef5 ;
      private string A623CliRef6 ;
      private string A624CliRef7 ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV109Ventas_clienteswwds_5_dynamicfiltersenabled2 ;
      private bool AV114Ventas_clienteswwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private bool n40000CliFoto_GXI ;
      private bool n612CliFoto ;
      private string AV98Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV15FilterCliDscDescription ;
      private string AV18FilterCliVendDscDescription ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV54TFCliEma_Sel ;
      private string AV53TFCliEma ;
      private string AV83TFTipCCod_To_Description ;
      private string AV84TFCliSts_To_Description ;
      private string AV85TFConpcod_To_Description ;
      private string AV86TFCliLim_To_Description ;
      private string AV87TFCliVend_To_Description ;
      private string AV105Ventas_clienteswwds_1_dynamicfiltersselector1 ;
      private string AV110Ventas_clienteswwds_6_dynamicfiltersselector2 ;
      private string AV115Ventas_clienteswwds_11_dynamicfiltersselector3 ;
      private string AV137Ventas_clienteswwds_33_tfcliema ;
      private string AV138Ventas_clienteswwds_34_tfcliema_sel ;
      private string lV137Ventas_clienteswwds_33_tfcliema ;
      private string A609CliEma ;
      private string A40000CliFoto_GXI ;
      private string AV96PageInfo ;
      private string AV93DateInfo ;
      private string AV91AppName ;
      private string AV97Phone ;
      private string AV95Mail ;
      private string AV99Website ;
      private string AV88AddressLine1 ;
      private string AV89AddressLine2 ;
      private string AV90AddressLine3 ;
      private string A612CliFoto ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00GC2_A624CliRef7 ;
      private string[] P00GC2_A623CliRef6 ;
      private string[] P00GC2_A622CliRef5 ;
      private string[] P00GC2_A621CliRef4 ;
      private string[] P00GC2_A620CliRef3 ;
      private string[] P00GC2_A619CliRef2 ;
      private string[] P00GC2_A618CliRef1 ;
      private int[] P00GC2_A160CliVend ;
      private decimal[] P00GC2_A613CliLim ;
      private int[] P00GC2_A137Conpcod ;
      private short[] P00GC2_A627CliSts ;
      private int[] P00GC2_A159TipCCod ;
      private string[] P00GC2_A637CliWeb ;
      private string[] P00GC2_A609CliEma ;
      private string[] P00GC2_A575CliCel ;
      private string[] P00GC2_A611CliFax ;
      private string[] P00GC2_A630CliTel2 ;
      private string[] P00GC2_A629CliTel1 ;
      private string[] P00GC2_A139PaiCod ;
      private string[] P00GC2_A140EstCod ;
      private string[] P00GC2_A596CliDir ;
      private string[] P00GC2_A45CliCod ;
      private string[] P00GC2_A635CliVendDsc ;
      private string[] P00GC2_A161CliDsc ;
      private string[] P00GC2_A40000CliFoto_GXI ;
      private bool[] P00GC2_n40000CliFoto_GXI ;
      private string[] P00GC2_A612CliFoto ;
      private bool[] P00GC2_n612CliFoto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
   }

   public class clienteswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GC2( IGxContext context ,
                                             string AV105Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                             short AV106Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                             string AV107Ventas_clienteswwds_3_clidsc1 ,
                                             string AV108Ventas_clienteswwds_4_clivenddsc1 ,
                                             bool AV109Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                             string AV110Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                             short AV111Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                             string AV112Ventas_clienteswwds_8_clidsc2 ,
                                             string AV113Ventas_clienteswwds_9_clivenddsc2 ,
                                             bool AV114Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                             string AV115Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                             short AV116Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                             string AV117Ventas_clienteswwds_13_clidsc3 ,
                                             string AV118Ventas_clienteswwds_14_clivenddsc3 ,
                                             string AV120Ventas_clienteswwds_16_tfclicod_sel ,
                                             string AV119Ventas_clienteswwds_15_tfclicod ,
                                             string AV122Ventas_clienteswwds_18_tfclidsc_sel ,
                                             string AV121Ventas_clienteswwds_17_tfclidsc ,
                                             string AV124Ventas_clienteswwds_20_tfclidir_sel ,
                                             string AV123Ventas_clienteswwds_19_tfclidir ,
                                             string AV126Ventas_clienteswwds_22_tfestcod_sel ,
                                             string AV125Ventas_clienteswwds_21_tfestcod ,
                                             string AV128Ventas_clienteswwds_24_tfpaicod_sel ,
                                             string AV127Ventas_clienteswwds_23_tfpaicod ,
                                             string AV130Ventas_clienteswwds_26_tfclitel1_sel ,
                                             string AV129Ventas_clienteswwds_25_tfclitel1 ,
                                             string AV132Ventas_clienteswwds_28_tfclitel2_sel ,
                                             string AV131Ventas_clienteswwds_27_tfclitel2 ,
                                             string AV134Ventas_clienteswwds_30_tfclifax_sel ,
                                             string AV133Ventas_clienteswwds_29_tfclifax ,
                                             string AV136Ventas_clienteswwds_32_tfclicel_sel ,
                                             string AV135Ventas_clienteswwds_31_tfclicel ,
                                             string AV138Ventas_clienteswwds_34_tfcliema_sel ,
                                             string AV137Ventas_clienteswwds_33_tfcliema ,
                                             string AV140Ventas_clienteswwds_36_tfcliweb_sel ,
                                             string AV139Ventas_clienteswwds_35_tfcliweb ,
                                             int AV141Ventas_clienteswwds_37_tftipccod ,
                                             int AV142Ventas_clienteswwds_38_tftipccod_to ,
                                             short AV143Ventas_clienteswwds_39_tfclists ,
                                             short AV144Ventas_clienteswwds_40_tfclists_to ,
                                             int AV145Ventas_clienteswwds_41_tfconpcod ,
                                             int AV146Ventas_clienteswwds_42_tfconpcod_to ,
                                             decimal AV147Ventas_clienteswwds_43_tfclilim ,
                                             decimal AV148Ventas_clienteswwds_44_tfclilim_to ,
                                             int AV149Ventas_clienteswwds_45_tfclivend ,
                                             int AV150Ventas_clienteswwds_46_tfclivend_to ,
                                             string AV152Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                             string AV151Ventas_clienteswwds_47_tfclivenddsc ,
                                             string AV154Ventas_clienteswwds_50_tfcliref1_sel ,
                                             string AV153Ventas_clienteswwds_49_tfcliref1 ,
                                             string AV156Ventas_clienteswwds_52_tfcliref2_sel ,
                                             string AV155Ventas_clienteswwds_51_tfcliref2 ,
                                             string AV158Ventas_clienteswwds_54_tfcliref3_sel ,
                                             string AV157Ventas_clienteswwds_53_tfcliref3 ,
                                             string AV160Ventas_clienteswwds_56_tfcliref4_sel ,
                                             string AV159Ventas_clienteswwds_55_tfcliref4 ,
                                             string AV162Ventas_clienteswwds_58_tfcliref5_sel ,
                                             string AV161Ventas_clienteswwds_57_tfcliref5 ,
                                             string AV164Ventas_clienteswwds_60_tfcliref6_sel ,
                                             string AV163Ventas_clienteswwds_59_tfcliref6 ,
                                             string AV166Ventas_clienteswwds_62_tfcliref7_sel ,
                                             string AV165Ventas_clienteswwds_61_tfcliref7 ,
                                             string A161CliDsc ,
                                             string A635CliVendDsc ,
                                             string A45CliCod ,
                                             string A596CliDir ,
                                             string A140EstCod ,
                                             string A139PaiCod ,
                                             string A629CliTel1 ,
                                             string A630CliTel2 ,
                                             string A611CliFax ,
                                             string A575CliCel ,
                                             string A609CliEma ,
                                             string A637CliWeb ,
                                             int A159TipCCod ,
                                             short A627CliSts ,
                                             int A137Conpcod ,
                                             decimal A613CliLim ,
                                             int A160CliVend ,
                                             string A618CliRef1 ,
                                             string A619CliRef2 ,
                                             string A620CliRef3 ,
                                             string A621CliRef4 ,
                                             string A622CliRef5 ,
                                             string A623CliRef6 ,
                                             string A624CliRef7 ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[60];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CliRef7], T1.[CliRef6], T1.[CliRef5], T1.[CliRef4], T1.[CliRef3], T1.[CliRef2], T1.[CliRef1], T1.[CliVend] AS CliVend, T1.[CliLim], T1.[Conpcod], T1.[CliSts], T1.[TipCCod], T1.[CliWeb], T1.[CliEma], T1.[CliCel], T1.[CliFax], T1.[CliTel2], T1.[CliTel1], T1.[PaiCod], T1.[EstCod], T1.[CliDir], T1.[CliCod], T2.[VenDsc] AS CliVendDsc, T1.[CliDsc], T1.[CliFoto_GXI], T1.[CliFoto] FROM ([CLCLIENTES] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[CliVend])";
         if ( ( StringUtil.StrCmp(AV105Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIDSC") == 0 ) && ( AV106Ventas_clienteswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Ventas_clienteswwds_3_clidsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV107Ventas_clienteswwds_3_clidsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV105Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIDSC") == 0 ) && ( AV106Ventas_clienteswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Ventas_clienteswwds_3_clidsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like '%' + @lV107Ventas_clienteswwds_3_clidsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV105Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIVENDDSC") == 0 ) && ( AV106Ventas_clienteswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Ventas_clienteswwds_4_clivenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV108Ventas_clienteswwds_4_clivenddsc1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV105Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIVENDDSC") == 0 ) && ( AV106Ventas_clienteswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Ventas_clienteswwds_4_clivenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV108Ventas_clienteswwds_4_clivenddsc1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV109Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIDSC") == 0 ) && ( AV111Ventas_clienteswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Ventas_clienteswwds_8_clidsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV112Ventas_clienteswwds_8_clidsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV109Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIDSC") == 0 ) && ( AV111Ventas_clienteswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Ventas_clienteswwds_8_clidsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like '%' + @lV112Ventas_clienteswwds_8_clidsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV109Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIVENDDSC") == 0 ) && ( AV111Ventas_clienteswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Ventas_clienteswwds_9_clivenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV113Ventas_clienteswwds_9_clivenddsc2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV109Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIVENDDSC") == 0 ) && ( AV111Ventas_clienteswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Ventas_clienteswwds_9_clivenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV113Ventas_clienteswwds_9_clivenddsc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV114Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV115Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIDSC") == 0 ) && ( AV116Ventas_clienteswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Ventas_clienteswwds_13_clidsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV117Ventas_clienteswwds_13_clidsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV114Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV115Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIDSC") == 0 ) && ( AV116Ventas_clienteswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Ventas_clienteswwds_13_clidsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like '%' + @lV117Ventas_clienteswwds_13_clidsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV114Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV115Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIVENDDSC") == 0 ) && ( AV116Ventas_clienteswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Ventas_clienteswwds_14_clivenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV118Ventas_clienteswwds_14_clivenddsc3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV114Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV115Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIVENDDSC") == 0 ) && ( AV116Ventas_clienteswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Ventas_clienteswwds_14_clivenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV118Ventas_clienteswwds_14_clivenddsc3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV120Ventas_clienteswwds_16_tfclicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Ventas_clienteswwds_15_tfclicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] like @lV119Ventas_clienteswwds_15_tfclicod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Ventas_clienteswwds_16_tfclicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV120Ventas_clienteswwds_16_tfclicod_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Ventas_clienteswwds_18_tfclidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Ventas_clienteswwds_17_tfclidsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV121Ventas_clienteswwds_17_tfclidsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Ventas_clienteswwds_18_tfclidsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] = @AV122Ventas_clienteswwds_18_tfclidsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Ventas_clienteswwds_20_tfclidir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Ventas_clienteswwds_19_tfclidir)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDir] like @lV123Ventas_clienteswwds_19_tfclidir)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Ventas_clienteswwds_20_tfclidir_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliDir] = @AV124Ventas_clienteswwds_20_tfclidir_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Ventas_clienteswwds_22_tfestcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Ventas_clienteswwds_21_tfestcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] like @lV125Ventas_clienteswwds_21_tfestcod)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Ventas_clienteswwds_22_tfestcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] = @AV126Ventas_clienteswwds_22_tfestcod_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Ventas_clienteswwds_24_tfpaicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Ventas_clienteswwds_23_tfpaicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV127Ventas_clienteswwds_23_tfpaicod)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Ventas_clienteswwds_24_tfpaicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] = @AV128Ventas_clienteswwds_24_tfpaicod_sel)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV130Ventas_clienteswwds_26_tfclitel1_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Ventas_clienteswwds_25_tfclitel1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliTel1] like @lV129Ventas_clienteswwds_25_tfclitel1)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Ventas_clienteswwds_26_tfclitel1_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliTel1] = @AV130Ventas_clienteswwds_26_tfclitel1_sel)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV132Ventas_clienteswwds_28_tfclitel2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Ventas_clienteswwds_27_tfclitel2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliTel2] like @lV131Ventas_clienteswwds_27_tfclitel2)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Ventas_clienteswwds_28_tfclitel2_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliTel2] = @AV132Ventas_clienteswwds_28_tfclitel2_sel)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV134Ventas_clienteswwds_30_tfclifax_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Ventas_clienteswwds_29_tfclifax)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliFax] like @lV133Ventas_clienteswwds_29_tfclifax)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Ventas_clienteswwds_30_tfclifax_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliFax] = @AV134Ventas_clienteswwds_30_tfclifax_sel)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV136Ventas_clienteswwds_32_tfclicel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Ventas_clienteswwds_31_tfclicel)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCel] like @lV135Ventas_clienteswwds_31_tfclicel)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Ventas_clienteswwds_32_tfclicel_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCel] = @AV136Ventas_clienteswwds_32_tfclicel_sel)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV138Ventas_clienteswwds_34_tfcliema_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Ventas_clienteswwds_33_tfcliema)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliEma] like @lV137Ventas_clienteswwds_33_tfcliema)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Ventas_clienteswwds_34_tfcliema_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliEma] = @AV138Ventas_clienteswwds_34_tfcliema_sel)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Ventas_clienteswwds_36_tfcliweb_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Ventas_clienteswwds_35_tfcliweb)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliWeb] like @lV139Ventas_clienteswwds_35_tfcliweb)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Ventas_clienteswwds_36_tfcliweb_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliWeb] = @AV140Ventas_clienteswwds_36_tfcliweb_sel)");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( ! (0==AV141Ventas_clienteswwds_37_tftipccod) )
         {
            AddWhere(sWhereString, "(T1.[TipCCod] >= @AV141Ventas_clienteswwds_37_tftipccod)");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         if ( ! (0==AV142Ventas_clienteswwds_38_tftipccod_to) )
         {
            AddWhere(sWhereString, "(T1.[TipCCod] <= @AV142Ventas_clienteswwds_38_tftipccod_to)");
         }
         else
         {
            GXv_int1[35] = 1;
         }
         if ( ! (0==AV143Ventas_clienteswwds_39_tfclists) )
         {
            AddWhere(sWhereString, "(T1.[CliSts] >= @AV143Ventas_clienteswwds_39_tfclists)");
         }
         else
         {
            GXv_int1[36] = 1;
         }
         if ( ! (0==AV144Ventas_clienteswwds_40_tfclists_to) )
         {
            AddWhere(sWhereString, "(T1.[CliSts] <= @AV144Ventas_clienteswwds_40_tfclists_to)");
         }
         else
         {
            GXv_int1[37] = 1;
         }
         if ( ! (0==AV145Ventas_clienteswwds_41_tfconpcod) )
         {
            AddWhere(sWhereString, "(T1.[Conpcod] >= @AV145Ventas_clienteswwds_41_tfconpcod)");
         }
         else
         {
            GXv_int1[38] = 1;
         }
         if ( ! (0==AV146Ventas_clienteswwds_42_tfconpcod_to) )
         {
            AddWhere(sWhereString, "(T1.[Conpcod] <= @AV146Ventas_clienteswwds_42_tfconpcod_to)");
         }
         else
         {
            GXv_int1[39] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV147Ventas_clienteswwds_43_tfclilim) )
         {
            AddWhere(sWhereString, "(T1.[CliLim] >= @AV147Ventas_clienteswwds_43_tfclilim)");
         }
         else
         {
            GXv_int1[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV148Ventas_clienteswwds_44_tfclilim_to) )
         {
            AddWhere(sWhereString, "(T1.[CliLim] <= @AV148Ventas_clienteswwds_44_tfclilim_to)");
         }
         else
         {
            GXv_int1[41] = 1;
         }
         if ( ! (0==AV149Ventas_clienteswwds_45_tfclivend) )
         {
            AddWhere(sWhereString, "(T1.[CliVend] >= @AV149Ventas_clienteswwds_45_tfclivend)");
         }
         else
         {
            GXv_int1[42] = 1;
         }
         if ( ! (0==AV150Ventas_clienteswwds_46_tfclivend_to) )
         {
            AddWhere(sWhereString, "(T1.[CliVend] <= @AV150Ventas_clienteswwds_46_tfclivend_to)");
         }
         else
         {
            GXv_int1[43] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Ventas_clienteswwds_48_tfclivenddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Ventas_clienteswwds_47_tfclivenddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV151Ventas_clienteswwds_47_tfclivenddsc)");
         }
         else
         {
            GXv_int1[44] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Ventas_clienteswwds_48_tfclivenddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] = @AV152Ventas_clienteswwds_48_tfclivenddsc_sel)");
         }
         else
         {
            GXv_int1[45] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Ventas_clienteswwds_50_tfcliref1_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Ventas_clienteswwds_49_tfcliref1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef1] like @lV153Ventas_clienteswwds_49_tfcliref1)");
         }
         else
         {
            GXv_int1[46] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Ventas_clienteswwds_50_tfcliref1_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef1] = @AV154Ventas_clienteswwds_50_tfcliref1_sel)");
         }
         else
         {
            GXv_int1[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Ventas_clienteswwds_52_tfcliref2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Ventas_clienteswwds_51_tfcliref2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef2] like @lV155Ventas_clienteswwds_51_tfcliref2)");
         }
         else
         {
            GXv_int1[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Ventas_clienteswwds_52_tfcliref2_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef2] = @AV156Ventas_clienteswwds_52_tfcliref2_sel)");
         }
         else
         {
            GXv_int1[49] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Ventas_clienteswwds_54_tfcliref3_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Ventas_clienteswwds_53_tfcliref3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef3] like @lV157Ventas_clienteswwds_53_tfcliref3)");
         }
         else
         {
            GXv_int1[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Ventas_clienteswwds_54_tfcliref3_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef3] = @AV158Ventas_clienteswwds_54_tfcliref3_sel)");
         }
         else
         {
            GXv_int1[51] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Ventas_clienteswwds_56_tfcliref4_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Ventas_clienteswwds_55_tfcliref4)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef4] like @lV159Ventas_clienteswwds_55_tfcliref4)");
         }
         else
         {
            GXv_int1[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Ventas_clienteswwds_56_tfcliref4_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef4] = @AV160Ventas_clienteswwds_56_tfcliref4_sel)");
         }
         else
         {
            GXv_int1[53] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Ventas_clienteswwds_58_tfcliref5_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Ventas_clienteswwds_57_tfcliref5)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef5] like @lV161Ventas_clienteswwds_57_tfcliref5)");
         }
         else
         {
            GXv_int1[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Ventas_clienteswwds_58_tfcliref5_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef5] = @AV162Ventas_clienteswwds_58_tfcliref5_sel)");
         }
         else
         {
            GXv_int1[55] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV164Ventas_clienteswwds_60_tfcliref6_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV163Ventas_clienteswwds_59_tfcliref6)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef6] like @lV163Ventas_clienteswwds_59_tfcliref6)");
         }
         else
         {
            GXv_int1[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV164Ventas_clienteswwds_60_tfcliref6_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef6] = @AV164Ventas_clienteswwds_60_tfcliref6_sel)");
         }
         else
         {
            GXv_int1[57] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV166Ventas_clienteswwds_62_tfcliref7_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV165Ventas_clienteswwds_61_tfcliref7)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef7] like @lV165Ventas_clienteswwds_61_tfcliref7)");
         }
         else
         {
            GXv_int1[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV166Ventas_clienteswwds_62_tfcliref7_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef7] = @AV166Ventas_clienteswwds_62_tfcliref7_sel)");
         }
         else
         {
            GXv_int1[59] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliDsc]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliCod]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliCod] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliDir]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliDir] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstCod]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstCod] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PaiCod]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PaiCod] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliTel1]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliTel1] DESC";
         }
         else if ( ( AV10OrderedBy == 7 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliTel2]";
         }
         else if ( ( AV10OrderedBy == 7 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliTel2] DESC";
         }
         else if ( ( AV10OrderedBy == 8 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliFax]";
         }
         else if ( ( AV10OrderedBy == 8 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliFax] DESC";
         }
         else if ( ( AV10OrderedBy == 9 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliCel]";
         }
         else if ( ( AV10OrderedBy == 9 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliCel] DESC";
         }
         else if ( ( AV10OrderedBy == 10 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliEma]";
         }
         else if ( ( AV10OrderedBy == 10 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliEma] DESC";
         }
         else if ( ( AV10OrderedBy == 11 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliWeb]";
         }
         else if ( ( AV10OrderedBy == 11 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliWeb] DESC";
         }
         else if ( ( AV10OrderedBy == 12 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipCCod]";
         }
         else if ( ( AV10OrderedBy == 12 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipCCod] DESC";
         }
         else if ( ( AV10OrderedBy == 13 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliSts]";
         }
         else if ( ( AV10OrderedBy == 13 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliSts] DESC";
         }
         else if ( ( AV10OrderedBy == 14 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[Conpcod]";
         }
         else if ( ( AV10OrderedBy == 14 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[Conpcod] DESC";
         }
         else if ( ( AV10OrderedBy == 15 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliLim]";
         }
         else if ( ( AV10OrderedBy == 15 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliLim] DESC";
         }
         else if ( ( AV10OrderedBy == 16 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliVend]";
         }
         else if ( ( AV10OrderedBy == 16 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliVend] DESC";
         }
         else if ( ( AV10OrderedBy == 17 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[VenDsc]";
         }
         else if ( ( AV10OrderedBy == 17 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[VenDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 18 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliRef1]";
         }
         else if ( ( AV10OrderedBy == 18 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliRef1] DESC";
         }
         else if ( ( AV10OrderedBy == 19 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliRef2]";
         }
         else if ( ( AV10OrderedBy == 19 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliRef2] DESC";
         }
         else if ( ( AV10OrderedBy == 20 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliRef3]";
         }
         else if ( ( AV10OrderedBy == 20 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliRef3] DESC";
         }
         else if ( ( AV10OrderedBy == 21 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliRef4]";
         }
         else if ( ( AV10OrderedBy == 21 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliRef4] DESC";
         }
         else if ( ( AV10OrderedBy == 22 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliRef5]";
         }
         else if ( ( AV10OrderedBy == 22 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliRef5] DESC";
         }
         else if ( ( AV10OrderedBy == 23 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliRef6]";
         }
         else if ( ( AV10OrderedBy == 23 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliRef6] DESC";
         }
         else if ( ( AV10OrderedBy == 24 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliRef7]";
         }
         else if ( ( AV10OrderedBy == 24 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliRef7] DESC";
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
                     return conditional_P00GC2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (int)dynConstraints[37] , (short)dynConstraints[38] , (short)dynConstraints[39] , (int)dynConstraints[40] , (int)dynConstraints[41] , (decimal)dynConstraints[42] , (decimal)dynConstraints[43] , (int)dynConstraints[44] , (int)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (int)dynConstraints[74] , (short)dynConstraints[75] , (int)dynConstraints[76] , (decimal)dynConstraints[77] , (int)dynConstraints[78] , (string)dynConstraints[79] , (string)dynConstraints[80] , (string)dynConstraints[81] , (string)dynConstraints[82] , (string)dynConstraints[83] , (string)dynConstraints[84] , (string)dynConstraints[85] , (short)dynConstraints[86] , (bool)dynConstraints[87] );
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
          Object[] prmP00GC2;
          prmP00GC2 = new Object[] {
          new ParDef("@lV107Ventas_clienteswwds_3_clidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV107Ventas_clienteswwds_3_clidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV108Ventas_clienteswwds_4_clivenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV108Ventas_clienteswwds_4_clivenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV112Ventas_clienteswwds_8_clidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV112Ventas_clienteswwds_8_clidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV113Ventas_clienteswwds_9_clivenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV113Ventas_clienteswwds_9_clivenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV117Ventas_clienteswwds_13_clidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV117Ventas_clienteswwds_13_clidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV118Ventas_clienteswwds_14_clivenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV118Ventas_clienteswwds_14_clivenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV119Ventas_clienteswwds_15_tfclicod",GXType.NChar,20,0) ,
          new ParDef("@AV120Ventas_clienteswwds_16_tfclicod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV121Ventas_clienteswwds_17_tfclidsc",GXType.NChar,100,0) ,
          new ParDef("@AV122Ventas_clienteswwds_18_tfclidsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV123Ventas_clienteswwds_19_tfclidir",GXType.NChar,100,0) ,
          new ParDef("@AV124Ventas_clienteswwds_20_tfclidir_sel",GXType.NChar,100,0) ,
          new ParDef("@lV125Ventas_clienteswwds_21_tfestcod",GXType.NChar,4,0) ,
          new ParDef("@AV126Ventas_clienteswwds_22_tfestcod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV127Ventas_clienteswwds_23_tfpaicod",GXType.NChar,4,0) ,
          new ParDef("@AV128Ventas_clienteswwds_24_tfpaicod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV129Ventas_clienteswwds_25_tfclitel1",GXType.NChar,20,0) ,
          new ParDef("@AV130Ventas_clienteswwds_26_tfclitel1_sel",GXType.NChar,20,0) ,
          new ParDef("@lV131Ventas_clienteswwds_27_tfclitel2",GXType.NChar,20,0) ,
          new ParDef("@AV132Ventas_clienteswwds_28_tfclitel2_sel",GXType.NChar,20,0) ,
          new ParDef("@lV133Ventas_clienteswwds_29_tfclifax",GXType.NChar,20,0) ,
          new ParDef("@AV134Ventas_clienteswwds_30_tfclifax_sel",GXType.NChar,20,0) ,
          new ParDef("@lV135Ventas_clienteswwds_31_tfclicel",GXType.NChar,20,0) ,
          new ParDef("@AV136Ventas_clienteswwds_32_tfclicel_sel",GXType.NChar,20,0) ,
          new ParDef("@lV137Ventas_clienteswwds_33_tfcliema",GXType.NVarChar,100,0) ,
          new ParDef("@AV138Ventas_clienteswwds_34_tfcliema_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV139Ventas_clienteswwds_35_tfcliweb",GXType.NChar,50,0) ,
          new ParDef("@AV140Ventas_clienteswwds_36_tfcliweb_sel",GXType.NChar,50,0) ,
          new ParDef("@AV141Ventas_clienteswwds_37_tftipccod",GXType.Int32,6,0) ,
          new ParDef("@AV142Ventas_clienteswwds_38_tftipccod_to",GXType.Int32,6,0) ,
          new ParDef("@AV143Ventas_clienteswwds_39_tfclists",GXType.Int16,1,0) ,
          new ParDef("@AV144Ventas_clienteswwds_40_tfclists_to",GXType.Int16,1,0) ,
          new ParDef("@AV145Ventas_clienteswwds_41_tfconpcod",GXType.Int32,6,0) ,
          new ParDef("@AV146Ventas_clienteswwds_42_tfconpcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV147Ventas_clienteswwds_43_tfclilim",GXType.Decimal,15,2) ,
          new ParDef("@AV148Ventas_clienteswwds_44_tfclilim_to",GXType.Decimal,15,2) ,
          new ParDef("@AV149Ventas_clienteswwds_45_tfclivend",GXType.Int32,6,0) ,
          new ParDef("@AV150Ventas_clienteswwds_46_tfclivend_to",GXType.Int32,6,0) ,
          new ParDef("@lV151Ventas_clienteswwds_47_tfclivenddsc",GXType.NChar,100,0) ,
          new ParDef("@AV152Ventas_clienteswwds_48_tfclivenddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV153Ventas_clienteswwds_49_tfcliref1",GXType.NChar,50,0) ,
          new ParDef("@AV154Ventas_clienteswwds_50_tfcliref1_sel",GXType.NChar,50,0) ,
          new ParDef("@lV155Ventas_clienteswwds_51_tfcliref2",GXType.NChar,50,0) ,
          new ParDef("@AV156Ventas_clienteswwds_52_tfcliref2_sel",GXType.NChar,50,0) ,
          new ParDef("@lV157Ventas_clienteswwds_53_tfcliref3",GXType.NChar,50,0) ,
          new ParDef("@AV158Ventas_clienteswwds_54_tfcliref3_sel",GXType.NChar,50,0) ,
          new ParDef("@lV159Ventas_clienteswwds_55_tfcliref4",GXType.NChar,50,0) ,
          new ParDef("@AV160Ventas_clienteswwds_56_tfcliref4_sel",GXType.NChar,50,0) ,
          new ParDef("@lV161Ventas_clienteswwds_57_tfcliref5",GXType.NChar,50,0) ,
          new ParDef("@AV162Ventas_clienteswwds_58_tfcliref5_sel",GXType.NChar,50,0) ,
          new ParDef("@lV163Ventas_clienteswwds_59_tfcliref6",GXType.NChar,50,0) ,
          new ParDef("@AV164Ventas_clienteswwds_60_tfcliref6_sel",GXType.NChar,50,0) ,
          new ParDef("@lV165Ventas_clienteswwds_61_tfcliref7",GXType.NChar,50,0) ,
          new ParDef("@AV166Ventas_clienteswwds_62_tfcliref7_sel",GXType.NChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GC2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GC2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getString(5, 50);
                ((string[]) buf[5])[0] = rslt.getString(6, 50);
                ((string[]) buf[6])[0] = rslt.getString(7, 50);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((int[]) buf[11])[0] = rslt.getInt(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 50);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getString(15, 20);
                ((string[]) buf[15])[0] = rslt.getString(16, 20);
                ((string[]) buf[16])[0] = rslt.getString(17, 20);
                ((string[]) buf[17])[0] = rslt.getString(18, 20);
                ((string[]) buf[18])[0] = rslt.getString(19, 4);
                ((string[]) buf[19])[0] = rslt.getString(20, 4);
                ((string[]) buf[20])[0] = rslt.getString(21, 100);
                ((string[]) buf[21])[0] = rslt.getString(22, 20);
                ((string[]) buf[22])[0] = rslt.getString(23, 100);
                ((string[]) buf[23])[0] = rslt.getString(24, 100);
                ((string[]) buf[24])[0] = rslt.getMultimediaUri(25);
                ((bool[]) buf[25])[0] = rslt.wasNull(25);
                ((string[]) buf[26])[0] = rslt.getMultimediaFile(26, rslt.getVarchar(25));
                ((bool[]) buf[27])[0] = rslt.wasNull(26);
                return;
       }
    }

 }

}
