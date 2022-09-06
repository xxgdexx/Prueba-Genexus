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
   public class vendedoreswwexportreport : GXWebProcedure
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

      public vendedoreswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public vendedoreswwexportreport( IGxContext context )
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
         vendedoreswwexportreport objvendedoreswwexportreport;
         objvendedoreswwexportreport = new vendedoreswwexportreport();
         objvendedoreswwexportreport.context.SetSubmitInitialConfig(context);
         objvendedoreswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objvendedoreswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((vendedoreswwexportreport)stateInfo).executePrivate();
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
            AV61Title = "Lista de Vendedores";
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
            H3A0( true, 0) ;
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
         if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "VENDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV18VenDsc1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18VenDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV19FilterVenDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor / Cobrador", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV19FilterVenDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor / Cobrador", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV20VenDsc = AV18VenDsc1;
                  H3A0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterVenDscDescription, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20VenDsc, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "VENTIPO") == 0 )
            {
               AV15VenTipo1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15VenTipo1)) )
               {
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV15VenTipo1), "T") == 0 )
                  {
                     AV69FilterVenTipo1ValueDescription = "Ambos";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV15VenTipo1), "V") == 0 )
                  {
                     AV69FilterVenTipo1ValueDescription = "Vendedor";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV15VenTipo1), "C") == 0 )
                  {
                     AV69FilterVenTipo1ValueDescription = "Cobrador";
                  }
                  AV68FilterVenTipoValueDescription = AV69FilterVenTipo1ValueDescription;
                  H3A0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68FilterVenTipoValueDescription, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "VENDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV25VenDsc2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25VenDsc2)) )
                  {
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV19FilterVenDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor / Cobrador", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV19FilterVenDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor / Cobrador", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV20VenDsc = AV25VenDsc2;
                     H3A0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterVenDscDescription, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20VenDsc, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "VENTIPO") == 0 )
               {
                  AV24VenTipo2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24VenTipo2)) )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Trim( AV24VenTipo2), "T") == 0 )
                     {
                        AV70FilterVenTipo2ValueDescription = "Ambos";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV24VenTipo2), "V") == 0 )
                     {
                        AV70FilterVenTipo2ValueDescription = "Vendedor";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV24VenTipo2), "C") == 0 )
                     {
                        AV70FilterVenTipo2ValueDescription = "Cobrador";
                     }
                     AV68FilterVenTipoValueDescription = AV70FilterVenTipo2ValueDescription;
                     H3A0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68FilterVenTipoValueDescription, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "VENDSC") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30VenDsc3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30VenDsc3)) )
                     {
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV19FilterVenDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor / Cobrador", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV19FilterVenDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor / Cobrador", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV20VenDsc = AV30VenDsc3;
                        H3A0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FilterVenDscDescription, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20VenDsc, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "VENTIPO") == 0 )
                  {
                     AV29VenTipo3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29VenTipo3)) )
                     {
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV29VenTipo3), "T") == 0 )
                        {
                           AV71FilterVenTipo3ValueDescription = "Ambos";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV29VenTipo3), "V") == 0 )
                        {
                           AV71FilterVenTipo3ValueDescription = "Vendedor";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV29VenTipo3), "C") == 0 )
                        {
                           AV71FilterVenTipo3ValueDescription = "Cobrador";
                        }
                        AV68FilterVenTipoValueDescription = AV71FilterVenTipo3ValueDescription;
                        H3A0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68FilterVenTipoValueDescription, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV36TFVenCod) && (0==AV37TFVenCod_To) ) )
         {
            H3A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36TFVenCod), "ZZZZZ9")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV48TFVenCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H3A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFVenCod_To_Description, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37TFVenCod_To), "ZZZZZ9")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFVenDsc_Sel)) )
         {
            H3A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Vendedor / Cobrador", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFVenDsc_Sel, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFVenDsc)) )
            {
               H3A0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Vendedor / Cobrador", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFVenDsc, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFVenDir_Sel)) )
         {
            H3A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Dirección", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFVenDir_Sel, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFVenDir)) )
            {
               H3A0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Dirección", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFVenDir, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV66TFVenTipo_Sels.FromJSonString(AV64TFVenTipo_SelsJson, null);
         if ( ! ( AV66TFVenTipo_Sels.Count == 0 ) )
         {
            AV50i = 1;
            AV76GXV1 = 1;
            while ( AV76GXV1 <= AV66TFVenTipo_Sels.Count )
            {
               AV43TFVenTipo_Sel = AV66TFVenTipo_Sels.GetString(AV76GXV1);
               if ( AV50i == 1 )
               {
                  AV65TFVenTipo_SelDscs = "";
               }
               else
               {
                  AV65TFVenTipo_SelDscs += ", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV43TFVenTipo_Sel), "T") == 0 )
               {
                  AV67FilterTFVenTipo_SelValueDescription = "Ambos";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV43TFVenTipo_Sel), "V") == 0 )
               {
                  AV67FilterTFVenTipo_SelValueDescription = "Vendedor";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV43TFVenTipo_Sel), "C") == 0 )
               {
                  AV67FilterTFVenTipo_SelValueDescription = "Cobrador";
               }
               AV65TFVenTipo_SelDscs += AV67FilterTFVenTipo_SelValueDescription;
               AV50i = (long)(AV50i+1);
               AV76GXV1 = (int)(AV76GXV1+1);
            }
            H3A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65TFVenTipo_SelDscs, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV46TFVenSts_Sels.FromJSonString(AV44TFVenSts_SelsJson, null);
         if ( ! ( AV46TFVenSts_Sels.Count == 0 ) )
         {
            AV50i = 1;
            AV77GXV2 = 1;
            while ( AV77GXV2 <= AV46TFVenSts_Sels.Count )
            {
               AV47TFVenSts_Sel = (short)(AV46TFVenSts_Sels.GetNumeric(AV77GXV2));
               if ( AV50i == 1 )
               {
                  AV45TFVenSts_SelDscs = "";
               }
               else
               {
                  AV45TFVenSts_SelDscs += ", ";
               }
               if ( AV47TFVenSts_Sel == 1 )
               {
                  AV49FilterTFVenSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV47TFVenSts_Sel == 0 )
               {
                  AV49FilterTFVenSts_SelValueDescription = "INACTIVO";
               }
               AV45TFVenSts_SelDscs += AV49FilterTFVenSts_SelValueDescription;
               AV50i = (long)(AV50i+1);
               AV77GXV2 = (int)(AV77GXV2+1);
            }
            H3A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFVenSts_SelDscs, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H3A0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H3A0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 112, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Vendedor / Cobrador", 116, Gx_line+10, 280, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Dirección", 284, Gx_line+10, 448, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo", 452, Gx_line+10, 617, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 621, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV79Configuracion_vendedoreswwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV80Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV81Configuracion_vendedoreswwds_3_vendsc1 = AV18VenDsc1;
         AV82Configuracion_vendedoreswwds_4_ventipo1 = AV15VenTipo1;
         AV83Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV84Configuracion_vendedoreswwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV85Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV86Configuracion_vendedoreswwds_8_vendsc2 = AV25VenDsc2;
         AV87Configuracion_vendedoreswwds_9_ventipo2 = AV24VenTipo2;
         AV88Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV89Configuracion_vendedoreswwds_11_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV90Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV91Configuracion_vendedoreswwds_13_vendsc3 = AV30VenDsc3;
         AV92Configuracion_vendedoreswwds_14_ventipo3 = AV29VenTipo3;
         AV93Configuracion_vendedoreswwds_15_tfvencod = AV36TFVenCod;
         AV94Configuracion_vendedoreswwds_16_tfvencod_to = AV37TFVenCod_To;
         AV95Configuracion_vendedoreswwds_17_tfvendsc = AV38TFVenDsc;
         AV96Configuracion_vendedoreswwds_18_tfvendsc_sel = AV39TFVenDsc_Sel;
         AV97Configuracion_vendedoreswwds_19_tfvendir = AV40TFVenDir;
         AV98Configuracion_vendedoreswwds_20_tfvendir_sel = AV41TFVenDir_Sel;
         AV99Configuracion_vendedoreswwds_21_tfventipo_sels = AV66TFVenTipo_Sels;
         AV100Configuracion_vendedoreswwds_22_tfvensts_sels = AV46TFVenSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A2049VenTipo ,
                                              AV99Configuracion_vendedoreswwds_21_tfventipo_sels ,
                                              A2047VenSts ,
                                              AV100Configuracion_vendedoreswwds_22_tfvensts_sels ,
                                              AV79Configuracion_vendedoreswwds_1_dynamicfiltersselector1 ,
                                              AV80Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 ,
                                              AV81Configuracion_vendedoreswwds_3_vendsc1 ,
                                              AV82Configuracion_vendedoreswwds_4_ventipo1 ,
                                              AV83Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 ,
                                              AV84Configuracion_vendedoreswwds_6_dynamicfiltersselector2 ,
                                              AV85Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 ,
                                              AV86Configuracion_vendedoreswwds_8_vendsc2 ,
                                              AV87Configuracion_vendedoreswwds_9_ventipo2 ,
                                              AV88Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 ,
                                              AV89Configuracion_vendedoreswwds_11_dynamicfiltersselector3 ,
                                              AV90Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 ,
                                              AV91Configuracion_vendedoreswwds_13_vendsc3 ,
                                              AV92Configuracion_vendedoreswwds_14_ventipo3 ,
                                              AV93Configuracion_vendedoreswwds_15_tfvencod ,
                                              AV94Configuracion_vendedoreswwds_16_tfvencod_to ,
                                              AV96Configuracion_vendedoreswwds_18_tfvendsc_sel ,
                                              AV95Configuracion_vendedoreswwds_17_tfvendsc ,
                                              AV98Configuracion_vendedoreswwds_20_tfvendir_sel ,
                                              AV97Configuracion_vendedoreswwds_19_tfvendir ,
                                              AV99Configuracion_vendedoreswwds_21_tfventipo_sels.Count ,
                                              AV100Configuracion_vendedoreswwds_22_tfvensts_sels.Count ,
                                              A2045VenDsc ,
                                              A309VenCod ,
                                              A2044VenDir ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV81Configuracion_vendedoreswwds_3_vendsc1 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_vendedoreswwds_3_vendsc1), 100, "%");
         lV81Configuracion_vendedoreswwds_3_vendsc1 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_vendedoreswwds_3_vendsc1), 100, "%");
         lV86Configuracion_vendedoreswwds_8_vendsc2 = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_vendedoreswwds_8_vendsc2), 100, "%");
         lV86Configuracion_vendedoreswwds_8_vendsc2 = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_vendedoreswwds_8_vendsc2), 100, "%");
         lV91Configuracion_vendedoreswwds_13_vendsc3 = StringUtil.PadR( StringUtil.RTrim( AV91Configuracion_vendedoreswwds_13_vendsc3), 100, "%");
         lV91Configuracion_vendedoreswwds_13_vendsc3 = StringUtil.PadR( StringUtil.RTrim( AV91Configuracion_vendedoreswwds_13_vendsc3), 100, "%");
         lV95Configuracion_vendedoreswwds_17_tfvendsc = StringUtil.PadR( StringUtil.RTrim( AV95Configuracion_vendedoreswwds_17_tfvendsc), 100, "%");
         lV97Configuracion_vendedoreswwds_19_tfvendir = StringUtil.PadR( StringUtil.RTrim( AV97Configuracion_vendedoreswwds_19_tfvendir), 100, "%");
         /* Using cursor P003A2 */
         pr_default.execute(0, new Object[] {lV81Configuracion_vendedoreswwds_3_vendsc1, lV81Configuracion_vendedoreswwds_3_vendsc1, AV82Configuracion_vendedoreswwds_4_ventipo1, lV86Configuracion_vendedoreswwds_8_vendsc2, lV86Configuracion_vendedoreswwds_8_vendsc2, AV87Configuracion_vendedoreswwds_9_ventipo2, lV91Configuracion_vendedoreswwds_13_vendsc3, lV91Configuracion_vendedoreswwds_13_vendsc3, AV92Configuracion_vendedoreswwds_14_ventipo3, AV93Configuracion_vendedoreswwds_15_tfvencod, AV94Configuracion_vendedoreswwds_16_tfvencod_to, lV95Configuracion_vendedoreswwds_17_tfvendsc, AV96Configuracion_vendedoreswwds_18_tfvendsc_sel, lV97Configuracion_vendedoreswwds_19_tfvendir, AV98Configuracion_vendedoreswwds_20_tfvendir_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2047VenSts = P003A2_A2047VenSts[0];
            A2044VenDir = P003A2_A2044VenDir[0];
            A309VenCod = P003A2_A309VenCod[0];
            A2049VenTipo = P003A2_A2049VenTipo[0];
            A2045VenDsc = P003A2_A2045VenDsc[0];
            if ( StringUtil.StrCmp(StringUtil.Trim( A2049VenTipo), "T") == 0 )
            {
               AV63VenTipoDescription = "Ambos";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A2049VenTipo), "V") == 0 )
            {
               AV63VenTipoDescription = "Vendedor";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A2049VenTipo), "C") == 0 )
            {
               AV63VenTipoDescription = "Cobrador";
            }
            if ( A2047VenSts == 1 )
            {
               AV12VenStsDescription = "ACTIVO";
            }
            else if ( A2047VenSts == 0 )
            {
               AV12VenStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H3A0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A309VenCod), "ZZZZZ9")), 30, Gx_line+10, 112, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2045VenDsc, "")), 116, Gx_line+10, 280, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2044VenDir, "")), 284, Gx_line+10, 448, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63VenTipoDescription, "")), 452, Gx_line+10, 617, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12VenStsDescription, "")), 621, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("Configuracion.VendedoresWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.VendedoresWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("Configuracion.VendedoresWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV101GXV3 = 1;
         while ( AV101GXV3 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV101GXV3));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFVENCOD") == 0 )
            {
               AV36TFVenCod = (int)(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."));
               AV37TFVenCod_To = (int)(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFVENDSC") == 0 )
            {
               AV38TFVenDsc = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFVENDSC_SEL") == 0 )
            {
               AV39TFVenDsc_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFVENDIR") == 0 )
            {
               AV40TFVenDir = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFVENDIR_SEL") == 0 )
            {
               AV41TFVenDir_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFVENTIPO_SEL") == 0 )
            {
               AV64TFVenTipo_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV66TFVenTipo_Sels.FromJSonString(AV64TFVenTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFVENSTS_SEL") == 0 )
            {
               AV44TFVenSts_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV46TFVenSts_Sels.FromJSonString(AV44TFVenSts_SelsJson, null);
            }
            AV101GXV3 = (int)(AV101GXV3+1);
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

      protected void H3A0( bool bFoot ,
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
                  AV59PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV56DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV54AppName = "DVelop Software Solutions";
               AV60Phone = "+1 550 8923";
               AV58Mail = "info@mail.com";
               AV62Website = "http://www.web.com";
               AV51AddressLine1 = "French Boulevard 2859";
               AV52AddressLine2 = "Downtown";
               AV53AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV61Title = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV18VenDsc1 = "";
         AV19FilterVenDscDescription = "";
         AV20VenDsc = "";
         AV15VenTipo1 = "";
         AV69FilterVenTipo1ValueDescription = "";
         AV68FilterVenTipoValueDescription = "";
         AV22DynamicFiltersSelector2 = "";
         AV25VenDsc2 = "";
         AV24VenTipo2 = "";
         AV70FilterVenTipo2ValueDescription = "";
         AV27DynamicFiltersSelector3 = "";
         AV30VenDsc3 = "";
         AV29VenTipo3 = "";
         AV71FilterVenTipo3ValueDescription = "";
         AV48TFVenCod_To_Description = "";
         AV39TFVenDsc_Sel = "";
         AV38TFVenDsc = "";
         AV41TFVenDir_Sel = "";
         AV40TFVenDir = "";
         AV66TFVenTipo_Sels = new GxSimpleCollection<string>();
         AV64TFVenTipo_SelsJson = "";
         AV43TFVenTipo_Sel = "";
         AV65TFVenTipo_SelDscs = "";
         AV67FilterTFVenTipo_SelValueDescription = "";
         AV46TFVenSts_Sels = new GxSimpleCollection<short>();
         AV44TFVenSts_SelsJson = "";
         AV45TFVenSts_SelDscs = "";
         AV49FilterTFVenSts_SelValueDescription = "";
         AV79Configuracion_vendedoreswwds_1_dynamicfiltersselector1 = "";
         AV81Configuracion_vendedoreswwds_3_vendsc1 = "";
         AV82Configuracion_vendedoreswwds_4_ventipo1 = "";
         AV84Configuracion_vendedoreswwds_6_dynamicfiltersselector2 = "";
         AV86Configuracion_vendedoreswwds_8_vendsc2 = "";
         AV87Configuracion_vendedoreswwds_9_ventipo2 = "";
         AV89Configuracion_vendedoreswwds_11_dynamicfiltersselector3 = "";
         AV91Configuracion_vendedoreswwds_13_vendsc3 = "";
         AV92Configuracion_vendedoreswwds_14_ventipo3 = "";
         AV95Configuracion_vendedoreswwds_17_tfvendsc = "";
         AV96Configuracion_vendedoreswwds_18_tfvendsc_sel = "";
         AV97Configuracion_vendedoreswwds_19_tfvendir = "";
         AV98Configuracion_vendedoreswwds_20_tfvendir_sel = "";
         AV99Configuracion_vendedoreswwds_21_tfventipo_sels = new GxSimpleCollection<string>();
         AV100Configuracion_vendedoreswwds_22_tfvensts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV81Configuracion_vendedoreswwds_3_vendsc1 = "";
         lV86Configuracion_vendedoreswwds_8_vendsc2 = "";
         lV91Configuracion_vendedoreswwds_13_vendsc3 = "";
         lV95Configuracion_vendedoreswwds_17_tfvendsc = "";
         lV97Configuracion_vendedoreswwds_19_tfvendir = "";
         A2049VenTipo = "";
         A2045VenDsc = "";
         A2044VenDir = "";
         P003A2_A2047VenSts = new short[1] ;
         P003A2_A2044VenDir = new string[] {""} ;
         P003A2_A309VenCod = new int[1] ;
         P003A2_A2049VenTipo = new string[] {""} ;
         P003A2_A2045VenDsc = new string[] {""} ;
         AV63VenTipoDescription = "";
         AV12VenStsDescription = "";
         AV32Session = context.GetSession();
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV59PageInfo = "";
         AV56DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV54AppName = "";
         AV60Phone = "";
         AV58Mail = "";
         AV62Website = "";
         AV51AddressLine1 = "";
         AV52AddressLine2 = "";
         AV53AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.vendedoreswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P003A2_A2047VenSts, P003A2_A2044VenDir, P003A2_A309VenCod, P003A2_A2049VenTipo, P003A2_A2045VenDsc
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
      private short AV23DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV47TFVenSts_Sel ;
      private short AV80Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 ;
      private short AV85Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 ;
      private short AV90Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 ;
      private short A2047VenSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV36TFVenCod ;
      private int AV37TFVenCod_To ;
      private int AV76GXV1 ;
      private int AV77GXV2 ;
      private int AV93Configuracion_vendedoreswwds_15_tfvencod ;
      private int AV94Configuracion_vendedoreswwds_16_tfvencod_to ;
      private int AV99Configuracion_vendedoreswwds_21_tfventipo_sels_Count ;
      private int AV100Configuracion_vendedoreswwds_22_tfvensts_sels_Count ;
      private int A309VenCod ;
      private int AV101GXV3 ;
      private long AV50i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV18VenDsc1 ;
      private string AV20VenDsc ;
      private string AV15VenTipo1 ;
      private string AV25VenDsc2 ;
      private string AV24VenTipo2 ;
      private string AV30VenDsc3 ;
      private string AV29VenTipo3 ;
      private string AV39TFVenDsc_Sel ;
      private string AV38TFVenDsc ;
      private string AV41TFVenDir_Sel ;
      private string AV40TFVenDir ;
      private string AV43TFVenTipo_Sel ;
      private string AV81Configuracion_vendedoreswwds_3_vendsc1 ;
      private string AV82Configuracion_vendedoreswwds_4_ventipo1 ;
      private string AV86Configuracion_vendedoreswwds_8_vendsc2 ;
      private string AV87Configuracion_vendedoreswwds_9_ventipo2 ;
      private string AV91Configuracion_vendedoreswwds_13_vendsc3 ;
      private string AV92Configuracion_vendedoreswwds_14_ventipo3 ;
      private string AV95Configuracion_vendedoreswwds_17_tfvendsc ;
      private string AV96Configuracion_vendedoreswwds_18_tfvendsc_sel ;
      private string AV97Configuracion_vendedoreswwds_19_tfvendir ;
      private string AV98Configuracion_vendedoreswwds_20_tfvendir_sel ;
      private string scmdbuf ;
      private string lV81Configuracion_vendedoreswwds_3_vendsc1 ;
      private string lV86Configuracion_vendedoreswwds_8_vendsc2 ;
      private string lV91Configuracion_vendedoreswwds_13_vendsc3 ;
      private string lV95Configuracion_vendedoreswwds_17_tfvendsc ;
      private string lV97Configuracion_vendedoreswwds_19_tfvendir ;
      private string A2049VenTipo ;
      private string A2045VenDsc ;
      private string A2044VenDir ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV83Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 ;
      private bool AV88Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV64TFVenTipo_SelsJson ;
      private string AV44TFVenSts_SelsJson ;
      private string AV61Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV19FilterVenDscDescription ;
      private string AV69FilterVenTipo1ValueDescription ;
      private string AV68FilterVenTipoValueDescription ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV70FilterVenTipo2ValueDescription ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV71FilterVenTipo3ValueDescription ;
      private string AV48TFVenCod_To_Description ;
      private string AV65TFVenTipo_SelDscs ;
      private string AV67FilterTFVenTipo_SelValueDescription ;
      private string AV45TFVenSts_SelDscs ;
      private string AV49FilterTFVenSts_SelValueDescription ;
      private string AV79Configuracion_vendedoreswwds_1_dynamicfiltersselector1 ;
      private string AV84Configuracion_vendedoreswwds_6_dynamicfiltersselector2 ;
      private string AV89Configuracion_vendedoreswwds_11_dynamicfiltersselector3 ;
      private string AV63VenTipoDescription ;
      private string AV12VenStsDescription ;
      private string AV59PageInfo ;
      private string AV56DateInfo ;
      private string AV54AppName ;
      private string AV60Phone ;
      private string AV58Mail ;
      private string AV62Website ;
      private string AV51AddressLine1 ;
      private string AV52AddressLine2 ;
      private string AV53AddressLine3 ;
      private GxSimpleCollection<short> AV46TFVenSts_Sels ;
      private GxSimpleCollection<short> AV100Configuracion_vendedoreswwds_22_tfvensts_sels ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003A2_A2047VenSts ;
      private string[] P003A2_A2044VenDir ;
      private int[] P003A2_A309VenCod ;
      private string[] P003A2_A2049VenTipo ;
      private string[] P003A2_A2045VenDsc ;
      private GxSimpleCollection<string> AV66TFVenTipo_Sels ;
      private GxSimpleCollection<string> AV99Configuracion_vendedoreswwds_21_tfventipo_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
   }

   public class vendedoreswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003A2( IGxContext context ,
                                             string A2049VenTipo ,
                                             GxSimpleCollection<string> AV99Configuracion_vendedoreswwds_21_tfventipo_sels ,
                                             short A2047VenSts ,
                                             GxSimpleCollection<short> AV100Configuracion_vendedoreswwds_22_tfvensts_sels ,
                                             string AV79Configuracion_vendedoreswwds_1_dynamicfiltersselector1 ,
                                             short AV80Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 ,
                                             string AV81Configuracion_vendedoreswwds_3_vendsc1 ,
                                             string AV82Configuracion_vendedoreswwds_4_ventipo1 ,
                                             bool AV83Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 ,
                                             string AV84Configuracion_vendedoreswwds_6_dynamicfiltersselector2 ,
                                             short AV85Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 ,
                                             string AV86Configuracion_vendedoreswwds_8_vendsc2 ,
                                             string AV87Configuracion_vendedoreswwds_9_ventipo2 ,
                                             bool AV88Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 ,
                                             string AV89Configuracion_vendedoreswwds_11_dynamicfiltersselector3 ,
                                             short AV90Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 ,
                                             string AV91Configuracion_vendedoreswwds_13_vendsc3 ,
                                             string AV92Configuracion_vendedoreswwds_14_ventipo3 ,
                                             int AV93Configuracion_vendedoreswwds_15_tfvencod ,
                                             int AV94Configuracion_vendedoreswwds_16_tfvencod_to ,
                                             string AV96Configuracion_vendedoreswwds_18_tfvendsc_sel ,
                                             string AV95Configuracion_vendedoreswwds_17_tfvendsc ,
                                             string AV98Configuracion_vendedoreswwds_20_tfvendir_sel ,
                                             string AV97Configuracion_vendedoreswwds_19_tfvendir ,
                                             int AV99Configuracion_vendedoreswwds_21_tfventipo_sels_Count ,
                                             int AV100Configuracion_vendedoreswwds_22_tfvensts_sels_Count ,
                                             string A2045VenDsc ,
                                             int A309VenCod ,
                                             string A2044VenDir ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [VenSts], [VenDir], [VenCod], [VenTipo], [VenDsc] FROM [CVENDEDORES]";
         if ( ( StringUtil.StrCmp(AV79Configuracion_vendedoreswwds_1_dynamicfiltersselector1, "VENDSC") == 0 ) && ( AV80Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_vendedoreswwds_3_vendsc1)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV81Configuracion_vendedoreswwds_3_vendsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Configuracion_vendedoreswwds_1_dynamicfiltersselector1, "VENDSC") == 0 ) && ( AV80Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_vendedoreswwds_3_vendsc1)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like '%' + @lV81Configuracion_vendedoreswwds_3_vendsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Configuracion_vendedoreswwds_1_dynamicfiltersselector1, "VENTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_vendedoreswwds_4_ventipo1)) ) )
         {
            AddWhere(sWhereString, "([VenTipo] = @AV82Configuracion_vendedoreswwds_4_ventipo1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV83Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Configuracion_vendedoreswwds_6_dynamicfiltersselector2, "VENDSC") == 0 ) && ( AV85Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_vendedoreswwds_8_vendsc2)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV86Configuracion_vendedoreswwds_8_vendsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV83Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Configuracion_vendedoreswwds_6_dynamicfiltersselector2, "VENDSC") == 0 ) && ( AV85Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_vendedoreswwds_8_vendsc2)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like '%' + @lV86Configuracion_vendedoreswwds_8_vendsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV83Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Configuracion_vendedoreswwds_6_dynamicfiltersselector2, "VENTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_vendedoreswwds_9_ventipo2)) ) )
         {
            AddWhere(sWhereString, "([VenTipo] = @AV87Configuracion_vendedoreswwds_9_ventipo2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV88Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV89Configuracion_vendedoreswwds_11_dynamicfiltersselector3, "VENDSC") == 0 ) && ( AV90Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Configuracion_vendedoreswwds_13_vendsc3)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV91Configuracion_vendedoreswwds_13_vendsc3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV88Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV89Configuracion_vendedoreswwds_11_dynamicfiltersselector3, "VENDSC") == 0 ) && ( AV90Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Configuracion_vendedoreswwds_13_vendsc3)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like '%' + @lV91Configuracion_vendedoreswwds_13_vendsc3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV88Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV89Configuracion_vendedoreswwds_11_dynamicfiltersselector3, "VENTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_vendedoreswwds_14_ventipo3)) ) )
         {
            AddWhere(sWhereString, "([VenTipo] = @AV92Configuracion_vendedoreswwds_14_ventipo3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV93Configuracion_vendedoreswwds_15_tfvencod) )
         {
            AddWhere(sWhereString, "([VenCod] >= @AV93Configuracion_vendedoreswwds_15_tfvencod)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV94Configuracion_vendedoreswwds_16_tfvencod_to) )
         {
            AddWhere(sWhereString, "([VenCod] <= @AV94Configuracion_vendedoreswwds_16_tfvencod_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Configuracion_vendedoreswwds_18_tfvendsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_vendedoreswwds_17_tfvendsc)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV95Configuracion_vendedoreswwds_17_tfvendsc)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Configuracion_vendedoreswwds_18_tfvendsc_sel)) )
         {
            AddWhere(sWhereString, "([VenDsc] = @AV96Configuracion_vendedoreswwds_18_tfvendsc_sel)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_vendedoreswwds_20_tfvendir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_vendedoreswwds_19_tfvendir)) ) )
         {
            AddWhere(sWhereString, "([VenDir] like @lV97Configuracion_vendedoreswwds_19_tfvendir)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_vendedoreswwds_20_tfvendir_sel)) )
         {
            AddWhere(sWhereString, "([VenDir] = @AV98Configuracion_vendedoreswwds_20_tfvendir_sel)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV99Configuracion_vendedoreswwds_21_tfventipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV99Configuracion_vendedoreswwds_21_tfventipo_sels, "[VenTipo] IN (", ")")+")");
         }
         if ( AV100Configuracion_vendedoreswwds_22_tfvensts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV100Configuracion_vendedoreswwds_22_tfvensts_sels, "[VenSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [VenCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [VenCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [VenDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [VenDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [VenDir]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [VenDir] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [VenTipo]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [VenTipo] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [VenSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [VenSts] DESC";
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
                     return conditional_P003A2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP003A2;
          prmP003A2 = new Object[] {
          new ParDef("@lV81Configuracion_vendedoreswwds_3_vendsc1",GXType.NChar,100,0) ,
          new ParDef("@lV81Configuracion_vendedoreswwds_3_vendsc1",GXType.NChar,100,0) ,
          new ParDef("@AV82Configuracion_vendedoreswwds_4_ventipo1",GXType.NChar,1,0) ,
          new ParDef("@lV86Configuracion_vendedoreswwds_8_vendsc2",GXType.NChar,100,0) ,
          new ParDef("@lV86Configuracion_vendedoreswwds_8_vendsc2",GXType.NChar,100,0) ,
          new ParDef("@AV87Configuracion_vendedoreswwds_9_ventipo2",GXType.NChar,1,0) ,
          new ParDef("@lV91Configuracion_vendedoreswwds_13_vendsc3",GXType.NChar,100,0) ,
          new ParDef("@lV91Configuracion_vendedoreswwds_13_vendsc3",GXType.NChar,100,0) ,
          new ParDef("@AV92Configuracion_vendedoreswwds_14_ventipo3",GXType.NChar,1,0) ,
          new ParDef("@AV93Configuracion_vendedoreswwds_15_tfvencod",GXType.Int32,6,0) ,
          new ParDef("@AV94Configuracion_vendedoreswwds_16_tfvencod_to",GXType.Int32,6,0) ,
          new ParDef("@lV95Configuracion_vendedoreswwds_17_tfvendsc",GXType.NChar,100,0) ,
          new ParDef("@AV96Configuracion_vendedoreswwds_18_tfvendsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV97Configuracion_vendedoreswwds_19_tfvendir",GXType.NChar,100,0) ,
          new ParDef("@AV98Configuracion_vendedoreswwds_20_tfvendir_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003A2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
