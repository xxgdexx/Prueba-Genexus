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
   public class movimientoventawwexportreport : GXWebProcedure
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

      public movimientoventawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public movimientoventawwexportreport( IGxContext context )
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
         movimientoventawwexportreport objmovimientoventawwexportreport;
         objmovimientoventawwexportreport = new movimientoventawwexportreport();
         objmovimientoventawwexportreport.context.SetSubmitInitialConfig(context);
         objmovimientoventawwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmovimientoventawwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((movimientoventawwexportreport)stateInfo).executePrivate();
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
            AV64Title = "Lista de Movimiento Venta";
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
            H3G0( true, 0) ;
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
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV15DynamicFiltersSelector1 = AV28GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MOVVDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV28GridStateDynamicFilter.gxTpr_Operator;
               AV17MovVDsc1 = AV28GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17MovVDsc1)) )
               {
                  if ( AV16DynamicFiltersOperator1 == 0 )
                  {
                     AV18FilterMovVDscDescription = StringUtil.Format( "%1 (%2)", "Movimiento de Venta", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV16DynamicFiltersOperator1 == 1 )
                  {
                     AV18FilterMovVDscDescription = StringUtil.Format( "%1 (%2)", "Movimiento de Venta", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV19MovVDsc = AV17MovVDsc1;
                  H3G0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterMovVDscDescription, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19MovVDsc, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "MOVVTIP") == 0 )
            {
               AV66MovVTip1 = AV28GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66MovVTip1)) )
               {
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV66MovVTip1), "C") == 0 )
                  {
                     AV69FilterMovVTip1ValueDescription = "Credito";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV66MovVTip1), "D") == 0 )
                  {
                     AV69FilterMovVTip1ValueDescription = "Debito";
                  }
                  AV68FilterMovVTipValueDescription = AV69FilterMovVTip1ValueDescription;
                  H3G0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Tipo de Credito / Debito", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68FilterMovVTipValueDescription, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV20DynamicFiltersEnabled2 = true;
               AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV28GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "MOVVDSC") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV28GridStateDynamicFilter.gxTpr_Operator;
                  AV23MovVDsc2 = AV28GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23MovVDsc2)) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV18FilterMovVDscDescription = StringUtil.Format( "%1 (%2)", "Movimiento de Venta", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV18FilterMovVDscDescription = StringUtil.Format( "%1 (%2)", "Movimiento de Venta", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV19MovVDsc = AV23MovVDsc2;
                     H3G0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterMovVDscDescription, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19MovVDsc, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "MOVVTIP") == 0 )
               {
                  AV70MovVTip2 = AV28GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70MovVTip2)) )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Trim( AV70MovVTip2), "C") == 0 )
                     {
                        AV71FilterMovVTip2ValueDescription = "Credito";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV70MovVTip2), "D") == 0 )
                     {
                        AV71FilterMovVTip2ValueDescription = "Debito";
                     }
                     AV68FilterMovVTipValueDescription = AV71FilterMovVTip2ValueDescription;
                     H3G0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Tipo de Credito / Debito", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68FilterMovVTipValueDescription, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV24DynamicFiltersEnabled3 = true;
                  AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV25DynamicFiltersSelector3 = AV28GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "MOVVDSC") == 0 )
                  {
                     AV26DynamicFiltersOperator3 = AV28GridStateDynamicFilter.gxTpr_Operator;
                     AV27MovVDsc3 = AV28GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27MovVDsc3)) )
                     {
                        if ( AV26DynamicFiltersOperator3 == 0 )
                        {
                           AV18FilterMovVDscDescription = StringUtil.Format( "%1 (%2)", "Movimiento de Venta", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV26DynamicFiltersOperator3 == 1 )
                        {
                           AV18FilterMovVDscDescription = StringUtil.Format( "%1 (%2)", "Movimiento de Venta", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV19MovVDsc = AV27MovVDsc3;
                        H3G0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterMovVDscDescription, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19MovVDsc, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "MOVVTIP") == 0 )
                  {
                     AV72MovVTip3 = AV28GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72MovVTip3)) )
                     {
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV72MovVTip3), "C") == 0 )
                        {
                           AV73FilterMovVTip3ValueDescription = "Credito";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV72MovVTip3), "D") == 0 )
                        {
                           AV73FilterMovVTip3ValueDescription = "Debito";
                        }
                        AV68FilterMovVTipValueDescription = AV73FilterMovVTip3ValueDescription;
                        H3G0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText("Tipo de Credito / Debito", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68FilterMovVTipValueDescription, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV33TFMovVCod) && (0==AV34TFMovVCod_To) ) )
         {
            H3G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFMovVCod), "ZZZZZ9")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV49TFMovVCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H3G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFMovVCod_To_Description, "")), 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFMovVCod_To), "ZZZZZ9")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFMovVDsc_Sel)) )
         {
            H3G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Movimiento de Venta", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFMovVDsc_Sel, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFMovVDsc)) )
            {
               H3G0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Movimiento de Venta", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFMovVDsc, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV39TFMovVAbr_Sels.FromJSonString(AV37TFMovVAbr_SelsJson, null);
         if ( ! ( AV39TFMovVAbr_Sels.Count == 0 ) )
         {
            AV53i = 1;
            AV78GXV1 = 1;
            while ( AV78GXV1 <= AV39TFMovVAbr_Sels.Count )
            {
               AV40TFMovVAbr_Sel = AV39TFMovVAbr_Sels.GetString(AV78GXV1);
               if ( AV53i == 1 )
               {
                  AV38TFMovVAbr_SelDscs = "";
               }
               else
               {
                  AV38TFMovVAbr_SelDscs += ", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV40TFMovVAbr_Sel), "SI") == 0 )
               {
                  AV50FilterTFMovVAbr_SelValueDescription = "SI";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV40TFMovVAbr_Sel), "NO") == 0 )
               {
                  AV50FilterTFMovVAbr_SelValueDescription = "NO";
               }
               AV38TFMovVAbr_SelDscs += AV50FilterTFMovVAbr_SelValueDescription;
               AV53i = (long)(AV53i+1);
               AV78GXV1 = (int)(AV78GXV1+1);
            }
            H3G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Afecta Unidades", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFMovVAbr_SelDscs, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV43TFMovVTip_Sels.FromJSonString(AV41TFMovVTip_SelsJson, null);
         if ( ! ( AV43TFMovVTip_Sels.Count == 0 ) )
         {
            AV53i = 1;
            AV79GXV2 = 1;
            while ( AV79GXV2 <= AV43TFMovVTip_Sels.Count )
            {
               AV44TFMovVTip_Sel = AV43TFMovVTip_Sels.GetString(AV79GXV2);
               if ( AV53i == 1 )
               {
                  AV42TFMovVTip_SelDscs = "";
               }
               else
               {
                  AV42TFMovVTip_SelDscs += ", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV44TFMovVTip_Sel), "C") == 0 )
               {
                  AV51FilterTFMovVTip_SelValueDescription = "Credito";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV44TFMovVTip_Sel), "D") == 0 )
               {
                  AV51FilterTFMovVTip_SelValueDescription = "Debito";
               }
               AV42TFMovVTip_SelDscs += AV51FilterTFMovVTip_SelValueDescription;
               AV53i = (long)(AV53i+1);
               AV79GXV2 = (int)(AV79GXV2+1);
            }
            H3G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Cargo / Abono", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFMovVTip_SelDscs, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV47TFMovVSts_Sels.FromJSonString(AV45TFMovVSts_SelsJson, null);
         if ( ! ( AV47TFMovVSts_Sels.Count == 0 ) )
         {
            AV53i = 1;
            AV80GXV3 = 1;
            while ( AV80GXV3 <= AV47TFMovVSts_Sels.Count )
            {
               AV48TFMovVSts_Sel = (short)(AV47TFMovVSts_Sels.GetNumeric(AV80GXV3));
               if ( AV53i == 1 )
               {
                  AV46TFMovVSts_SelDscs = "";
               }
               else
               {
                  AV46TFMovVSts_SelDscs += ", ";
               }
               if ( AV48TFMovVSts_Sel == 1 )
               {
                  AV52FilterTFMovVSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV48TFMovVSts_Sel == 0 )
               {
                  AV52FilterTFMovVSts_SelValueDescription = "INACTIVO";
               }
               AV46TFMovVSts_SelDscs += AV52FilterTFMovVSts_SelValueDescription;
               AV53i = (long)(AV53i+1);
               AV80GXV3 = (int)(AV80GXV3+1);
            }
            H3G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 248, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TFMovVSts_SelDscs, "")), 248, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H3G0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H3G0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 112, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Movimiento de Venta", 116, Gx_line+10, 280, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Afecta Unidades", 284, Gx_line+10, 448, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Cargo / Abono", 452, Gx_line+10, 617, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 621, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV82Configuracion_movimientoventawwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV83Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV84Configuracion_movimientoventawwds_3_movvdsc1 = AV17MovVDsc1;
         AV85Configuracion_movimientoventawwds_4_movvtip1 = AV66MovVTip1;
         AV86Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV87Configuracion_movimientoventawwds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV88Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV89Configuracion_movimientoventawwds_8_movvdsc2 = AV23MovVDsc2;
         AV90Configuracion_movimientoventawwds_9_movvtip2 = AV70MovVTip2;
         AV91Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV92Configuracion_movimientoventawwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV93Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV94Configuracion_movimientoventawwds_13_movvdsc3 = AV27MovVDsc3;
         AV95Configuracion_movimientoventawwds_14_movvtip3 = AV72MovVTip3;
         AV96Configuracion_movimientoventawwds_15_tfmovvcod = AV33TFMovVCod;
         AV97Configuracion_movimientoventawwds_16_tfmovvcod_to = AV34TFMovVCod_To;
         AV98Configuracion_movimientoventawwds_17_tfmovvdsc = AV35TFMovVDsc;
         AV99Configuracion_movimientoventawwds_18_tfmovvdsc_sel = AV36TFMovVDsc_Sel;
         AV100Configuracion_movimientoventawwds_19_tfmovvabr_sels = AV39TFMovVAbr_Sels;
         AV101Configuracion_movimientoventawwds_20_tfmovvtip_sels = AV43TFMovVTip_Sels;
         AV102Configuracion_movimientoventawwds_21_tfmovvsts_sels = AV47TFMovVSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1242MovVAbr ,
                                              AV100Configuracion_movimientoventawwds_19_tfmovvabr_sels ,
                                              A1245MovVTip ,
                                              AV101Configuracion_movimientoventawwds_20_tfmovvtip_sels ,
                                              A1244MovVSts ,
                                              AV102Configuracion_movimientoventawwds_21_tfmovvsts_sels ,
                                              AV82Configuracion_movimientoventawwds_1_dynamicfiltersselector1 ,
                                              AV83Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 ,
                                              AV84Configuracion_movimientoventawwds_3_movvdsc1 ,
                                              AV85Configuracion_movimientoventawwds_4_movvtip1 ,
                                              AV86Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 ,
                                              AV87Configuracion_movimientoventawwds_6_dynamicfiltersselector2 ,
                                              AV88Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 ,
                                              AV89Configuracion_movimientoventawwds_8_movvdsc2 ,
                                              AV90Configuracion_movimientoventawwds_9_movvtip2 ,
                                              AV91Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 ,
                                              AV92Configuracion_movimientoventawwds_11_dynamicfiltersselector3 ,
                                              AV93Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 ,
                                              AV94Configuracion_movimientoventawwds_13_movvdsc3 ,
                                              AV95Configuracion_movimientoventawwds_14_movvtip3 ,
                                              AV96Configuracion_movimientoventawwds_15_tfmovvcod ,
                                              AV97Configuracion_movimientoventawwds_16_tfmovvcod_to ,
                                              AV99Configuracion_movimientoventawwds_18_tfmovvdsc_sel ,
                                              AV98Configuracion_movimientoventawwds_17_tfmovvdsc ,
                                              AV100Configuracion_movimientoventawwds_19_tfmovvabr_sels.Count ,
                                              AV101Configuracion_movimientoventawwds_20_tfmovvtip_sels.Count ,
                                              AV102Configuracion_movimientoventawwds_21_tfmovvsts_sels.Count ,
                                              A1243MovVDsc ,
                                              A235MovVCod ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV84Configuracion_movimientoventawwds_3_movvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_movimientoventawwds_3_movvdsc1), 100, "%");
         lV84Configuracion_movimientoventawwds_3_movvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_movimientoventawwds_3_movvdsc1), 100, "%");
         lV89Configuracion_movimientoventawwds_8_movvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_movimientoventawwds_8_movvdsc2), 100, "%");
         lV89Configuracion_movimientoventawwds_8_movvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_movimientoventawwds_8_movvdsc2), 100, "%");
         lV94Configuracion_movimientoventawwds_13_movvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV94Configuracion_movimientoventawwds_13_movvdsc3), 100, "%");
         lV94Configuracion_movimientoventawwds_13_movvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV94Configuracion_movimientoventawwds_13_movvdsc3), 100, "%");
         lV98Configuracion_movimientoventawwds_17_tfmovvdsc = StringUtil.PadR( StringUtil.RTrim( AV98Configuracion_movimientoventawwds_17_tfmovvdsc), 100, "%");
         /* Using cursor P003G2 */
         pr_default.execute(0, new Object[] {lV84Configuracion_movimientoventawwds_3_movvdsc1, lV84Configuracion_movimientoventawwds_3_movvdsc1, AV85Configuracion_movimientoventawwds_4_movvtip1, lV89Configuracion_movimientoventawwds_8_movvdsc2, lV89Configuracion_movimientoventawwds_8_movvdsc2, AV90Configuracion_movimientoventawwds_9_movvtip2, lV94Configuracion_movimientoventawwds_13_movvdsc3, lV94Configuracion_movimientoventawwds_13_movvdsc3, AV95Configuracion_movimientoventawwds_14_movvtip3, AV96Configuracion_movimientoventawwds_15_tfmovvcod, AV97Configuracion_movimientoventawwds_16_tfmovvcod_to, lV98Configuracion_movimientoventawwds_17_tfmovvdsc, AV99Configuracion_movimientoventawwds_18_tfmovvdsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1244MovVSts = P003G2_A1244MovVSts[0];
            A1242MovVAbr = P003G2_A1242MovVAbr[0];
            A235MovVCod = P003G2_A235MovVCod[0];
            A1245MovVTip = P003G2_A1245MovVTip[0];
            A1243MovVDsc = P003G2_A1243MovVDsc[0];
            if ( StringUtil.StrCmp(StringUtil.Trim( A1242MovVAbr), "SI") == 0 )
            {
               AV12MovVAbrDescription = "SI";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A1242MovVAbr), "NO") == 0 )
            {
               AV12MovVAbrDescription = "NO";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( A1245MovVTip), "C") == 0 )
            {
               AV13MovVTipDescription = "Credito";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A1245MovVTip), "D") == 0 )
            {
               AV13MovVTipDescription = "Debito";
            }
            if ( A1244MovVSts == 1 )
            {
               AV14MovVStsDescription = "ACTIVO";
            }
            else if ( A1244MovVSts == 0 )
            {
               AV14MovVStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H3G0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A235MovVCod), "ZZZZZ9")), 30, Gx_line+10, 112, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1243MovVDsc, "")), 116, Gx_line+10, 280, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12MovVAbrDescription, "")), 284, Gx_line+10, 448, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13MovVTipDescription, "")), 452, Gx_line+10, 617, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14MovVStsDescription, "")), 621, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV29Session.Get("Configuracion.MovimientoVentaWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.MovimientoVentaWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("Configuracion.MovimientoVentaWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV103GXV4 = 1;
         while ( AV103GXV4 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV103GXV4));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMOVVCOD") == 0 )
            {
               AV33TFMovVCod = (int)(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."));
               AV34TFMovVCod_To = (int)(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMOVVDSC") == 0 )
            {
               AV35TFMovVDsc = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMOVVDSC_SEL") == 0 )
            {
               AV36TFMovVDsc_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMOVVABR_SEL") == 0 )
            {
               AV37TFMovVAbr_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV39TFMovVAbr_Sels.FromJSonString(AV37TFMovVAbr_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMOVVTIP_SEL") == 0 )
            {
               AV41TFMovVTip_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV43TFMovVTip_Sels.FromJSonString(AV41TFMovVTip_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMOVVSTS_SEL") == 0 )
            {
               AV45TFMovVSts_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV47TFMovVSts_Sels.FromJSonString(AV45TFMovVSts_SelsJson, null);
            }
            AV103GXV4 = (int)(AV103GXV4+1);
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

      protected void H3G0( bool bFoot ,
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
                  AV62PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV59DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV57AppName = "DVelop Software Solutions";
               AV63Phone = "+1 550 8923";
               AV61Mail = "info@mail.com";
               AV65Website = "http://www.web.com";
               AV54AddressLine1 = "French Boulevard 2859";
               AV55AddressLine2 = "Downtown";
               AV56AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV64Title = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV28GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV15DynamicFiltersSelector1 = "";
         AV17MovVDsc1 = "";
         AV18FilterMovVDscDescription = "";
         AV19MovVDsc = "";
         AV66MovVTip1 = "";
         AV69FilterMovVTip1ValueDescription = "";
         AV68FilterMovVTipValueDescription = "";
         AV21DynamicFiltersSelector2 = "";
         AV23MovVDsc2 = "";
         AV70MovVTip2 = "";
         AV71FilterMovVTip2ValueDescription = "";
         AV25DynamicFiltersSelector3 = "";
         AV27MovVDsc3 = "";
         AV72MovVTip3 = "";
         AV73FilterMovVTip3ValueDescription = "";
         AV49TFMovVCod_To_Description = "";
         AV36TFMovVDsc_Sel = "";
         AV35TFMovVDsc = "";
         AV39TFMovVAbr_Sels = new GxSimpleCollection<string>();
         AV37TFMovVAbr_SelsJson = "";
         AV40TFMovVAbr_Sel = "";
         AV38TFMovVAbr_SelDscs = "";
         AV50FilterTFMovVAbr_SelValueDescription = "";
         AV43TFMovVTip_Sels = new GxSimpleCollection<string>();
         AV41TFMovVTip_SelsJson = "";
         AV44TFMovVTip_Sel = "";
         AV42TFMovVTip_SelDscs = "";
         AV51FilterTFMovVTip_SelValueDescription = "";
         AV47TFMovVSts_Sels = new GxSimpleCollection<short>();
         AV45TFMovVSts_SelsJson = "";
         AV46TFMovVSts_SelDscs = "";
         AV52FilterTFMovVSts_SelValueDescription = "";
         AV82Configuracion_movimientoventawwds_1_dynamicfiltersselector1 = "";
         AV84Configuracion_movimientoventawwds_3_movvdsc1 = "";
         AV85Configuracion_movimientoventawwds_4_movvtip1 = "";
         AV87Configuracion_movimientoventawwds_6_dynamicfiltersselector2 = "";
         AV89Configuracion_movimientoventawwds_8_movvdsc2 = "";
         AV90Configuracion_movimientoventawwds_9_movvtip2 = "";
         AV92Configuracion_movimientoventawwds_11_dynamicfiltersselector3 = "";
         AV94Configuracion_movimientoventawwds_13_movvdsc3 = "";
         AV95Configuracion_movimientoventawwds_14_movvtip3 = "";
         AV98Configuracion_movimientoventawwds_17_tfmovvdsc = "";
         AV99Configuracion_movimientoventawwds_18_tfmovvdsc_sel = "";
         AV100Configuracion_movimientoventawwds_19_tfmovvabr_sels = new GxSimpleCollection<string>();
         AV101Configuracion_movimientoventawwds_20_tfmovvtip_sels = new GxSimpleCollection<string>();
         AV102Configuracion_movimientoventawwds_21_tfmovvsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV84Configuracion_movimientoventawwds_3_movvdsc1 = "";
         lV89Configuracion_movimientoventawwds_8_movvdsc2 = "";
         lV94Configuracion_movimientoventawwds_13_movvdsc3 = "";
         lV98Configuracion_movimientoventawwds_17_tfmovvdsc = "";
         A1242MovVAbr = "";
         A1245MovVTip = "";
         A1243MovVDsc = "";
         P003G2_A1244MovVSts = new short[1] ;
         P003G2_A1242MovVAbr = new string[] {""} ;
         P003G2_A235MovVCod = new int[1] ;
         P003G2_A1245MovVTip = new string[] {""} ;
         P003G2_A1243MovVDsc = new string[] {""} ;
         AV12MovVAbrDescription = "";
         AV13MovVTipDescription = "";
         AV14MovVStsDescription = "";
         AV29Session = context.GetSession();
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV62PageInfo = "";
         AV59DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV57AppName = "";
         AV63Phone = "";
         AV61Mail = "";
         AV65Website = "";
         AV54AddressLine1 = "";
         AV55AddressLine2 = "";
         AV56AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.movimientoventawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P003G2_A1244MovVSts, P003G2_A1242MovVAbr, P003G2_A235MovVCod, P003G2_A1245MovVTip, P003G2_A1243MovVDsc
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
      private short AV16DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV26DynamicFiltersOperator3 ;
      private short AV48TFMovVSts_Sel ;
      private short AV83Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 ;
      private short AV88Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 ;
      private short AV93Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 ;
      private short A1244MovVSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV33TFMovVCod ;
      private int AV34TFMovVCod_To ;
      private int AV78GXV1 ;
      private int AV79GXV2 ;
      private int AV80GXV3 ;
      private int AV96Configuracion_movimientoventawwds_15_tfmovvcod ;
      private int AV97Configuracion_movimientoventawwds_16_tfmovvcod_to ;
      private int AV100Configuracion_movimientoventawwds_19_tfmovvabr_sels_Count ;
      private int AV101Configuracion_movimientoventawwds_20_tfmovvtip_sels_Count ;
      private int AV102Configuracion_movimientoventawwds_21_tfmovvsts_sels_Count ;
      private int A235MovVCod ;
      private int AV103GXV4 ;
      private long AV53i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV17MovVDsc1 ;
      private string AV19MovVDsc ;
      private string AV66MovVTip1 ;
      private string AV23MovVDsc2 ;
      private string AV70MovVTip2 ;
      private string AV27MovVDsc3 ;
      private string AV72MovVTip3 ;
      private string AV36TFMovVDsc_Sel ;
      private string AV35TFMovVDsc ;
      private string AV40TFMovVAbr_Sel ;
      private string AV44TFMovVTip_Sel ;
      private string AV84Configuracion_movimientoventawwds_3_movvdsc1 ;
      private string AV85Configuracion_movimientoventawwds_4_movvtip1 ;
      private string AV89Configuracion_movimientoventawwds_8_movvdsc2 ;
      private string AV90Configuracion_movimientoventawwds_9_movvtip2 ;
      private string AV94Configuracion_movimientoventawwds_13_movvdsc3 ;
      private string AV95Configuracion_movimientoventawwds_14_movvtip3 ;
      private string AV98Configuracion_movimientoventawwds_17_tfmovvdsc ;
      private string AV99Configuracion_movimientoventawwds_18_tfmovvdsc_sel ;
      private string scmdbuf ;
      private string lV84Configuracion_movimientoventawwds_3_movvdsc1 ;
      private string lV89Configuracion_movimientoventawwds_8_movvdsc2 ;
      private string lV94Configuracion_movimientoventawwds_13_movvdsc3 ;
      private string lV98Configuracion_movimientoventawwds_17_tfmovvdsc ;
      private string A1242MovVAbr ;
      private string A1245MovVTip ;
      private string A1243MovVDsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV24DynamicFiltersEnabled3 ;
      private bool AV86Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 ;
      private bool AV91Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV37TFMovVAbr_SelsJson ;
      private string AV41TFMovVTip_SelsJson ;
      private string AV45TFMovVSts_SelsJson ;
      private string AV64Title ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV18FilterMovVDscDescription ;
      private string AV69FilterMovVTip1ValueDescription ;
      private string AV68FilterMovVTipValueDescription ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV71FilterMovVTip2ValueDescription ;
      private string AV25DynamicFiltersSelector3 ;
      private string AV73FilterMovVTip3ValueDescription ;
      private string AV49TFMovVCod_To_Description ;
      private string AV38TFMovVAbr_SelDscs ;
      private string AV50FilterTFMovVAbr_SelValueDescription ;
      private string AV42TFMovVTip_SelDscs ;
      private string AV51FilterTFMovVTip_SelValueDescription ;
      private string AV46TFMovVSts_SelDscs ;
      private string AV52FilterTFMovVSts_SelValueDescription ;
      private string AV82Configuracion_movimientoventawwds_1_dynamicfiltersselector1 ;
      private string AV87Configuracion_movimientoventawwds_6_dynamicfiltersselector2 ;
      private string AV92Configuracion_movimientoventawwds_11_dynamicfiltersselector3 ;
      private string AV12MovVAbrDescription ;
      private string AV13MovVTipDescription ;
      private string AV14MovVStsDescription ;
      private string AV62PageInfo ;
      private string AV59DateInfo ;
      private string AV57AppName ;
      private string AV63Phone ;
      private string AV61Mail ;
      private string AV65Website ;
      private string AV54AddressLine1 ;
      private string AV55AddressLine2 ;
      private string AV56AddressLine3 ;
      private GxSimpleCollection<short> AV47TFMovVSts_Sels ;
      private GxSimpleCollection<short> AV102Configuracion_movimientoventawwds_21_tfmovvsts_sels ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003G2_A1244MovVSts ;
      private string[] P003G2_A1242MovVAbr ;
      private int[] P003G2_A235MovVCod ;
      private string[] P003G2_A1245MovVTip ;
      private string[] P003G2_A1243MovVDsc ;
      private GxSimpleCollection<string> AV39TFMovVAbr_Sels ;
      private GxSimpleCollection<string> AV43TFMovVTip_Sels ;
      private GxSimpleCollection<string> AV100Configuracion_movimientoventawwds_19_tfmovvabr_sels ;
      private GxSimpleCollection<string> AV101Configuracion_movimientoventawwds_20_tfmovvtip_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV28GridStateDynamicFilter ;
   }

   public class movimientoventawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003G2( IGxContext context ,
                                             string A1242MovVAbr ,
                                             GxSimpleCollection<string> AV100Configuracion_movimientoventawwds_19_tfmovvabr_sels ,
                                             string A1245MovVTip ,
                                             GxSimpleCollection<string> AV101Configuracion_movimientoventawwds_20_tfmovvtip_sels ,
                                             short A1244MovVSts ,
                                             GxSimpleCollection<short> AV102Configuracion_movimientoventawwds_21_tfmovvsts_sels ,
                                             string AV82Configuracion_movimientoventawwds_1_dynamicfiltersselector1 ,
                                             short AV83Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 ,
                                             string AV84Configuracion_movimientoventawwds_3_movvdsc1 ,
                                             string AV85Configuracion_movimientoventawwds_4_movvtip1 ,
                                             bool AV86Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 ,
                                             string AV87Configuracion_movimientoventawwds_6_dynamicfiltersselector2 ,
                                             short AV88Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 ,
                                             string AV89Configuracion_movimientoventawwds_8_movvdsc2 ,
                                             string AV90Configuracion_movimientoventawwds_9_movvtip2 ,
                                             bool AV91Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 ,
                                             string AV92Configuracion_movimientoventawwds_11_dynamicfiltersselector3 ,
                                             short AV93Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 ,
                                             string AV94Configuracion_movimientoventawwds_13_movvdsc3 ,
                                             string AV95Configuracion_movimientoventawwds_14_movvtip3 ,
                                             int AV96Configuracion_movimientoventawwds_15_tfmovvcod ,
                                             int AV97Configuracion_movimientoventawwds_16_tfmovvcod_to ,
                                             string AV99Configuracion_movimientoventawwds_18_tfmovvdsc_sel ,
                                             string AV98Configuracion_movimientoventawwds_17_tfmovvdsc ,
                                             int AV100Configuracion_movimientoventawwds_19_tfmovvabr_sels_Count ,
                                             int AV101Configuracion_movimientoventawwds_20_tfmovvtip_sels_Count ,
                                             int AV102Configuracion_movimientoventawwds_21_tfmovvsts_sels_Count ,
                                             string A1243MovVDsc ,
                                             int A235MovVCod ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[13];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [MovVSts], [MovVAbr], [MovVCod], [MovVTip], [MovVDsc] FROM [CMOVVENTAS]";
         if ( ( StringUtil.StrCmp(AV82Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVDSC") == 0 ) && ( AV83Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_movimientoventawwds_3_movvdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV84Configuracion_movimientoventawwds_3_movvdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVDSC") == 0 ) && ( AV83Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_movimientoventawwds_3_movvdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV84Configuracion_movimientoventawwds_3_movvdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_movimientoventawwds_4_movvtip1)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV85Configuracion_movimientoventawwds_4_movvtip1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV86Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVDSC") == 0 ) && ( AV88Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_movimientoventawwds_8_movvdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV89Configuracion_movimientoventawwds_8_movvdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV86Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVDSC") == 0 ) && ( AV88Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_movimientoventawwds_8_movvdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV89Configuracion_movimientoventawwds_8_movvdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV86Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Configuracion_movimientoventawwds_9_movvtip2)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV90Configuracion_movimientoventawwds_9_movvtip2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV91Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVDSC") == 0 ) && ( AV93Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Configuracion_movimientoventawwds_13_movvdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV94Configuracion_movimientoventawwds_13_movvdsc3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV91Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVDSC") == 0 ) && ( AV93Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Configuracion_movimientoventawwds_13_movvdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV94Configuracion_movimientoventawwds_13_movvdsc3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV91Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_movimientoventawwds_14_movvtip3)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV95Configuracion_movimientoventawwds_14_movvtip3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV96Configuracion_movimientoventawwds_15_tfmovvcod) )
         {
            AddWhere(sWhereString, "([MovVCod] >= @AV96Configuracion_movimientoventawwds_15_tfmovvcod)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV97Configuracion_movimientoventawwds_16_tfmovvcod_to) )
         {
            AddWhere(sWhereString, "([MovVCod] <= @AV97Configuracion_movimientoventawwds_16_tfmovvcod_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_movimientoventawwds_18_tfmovvdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_movimientoventawwds_17_tfmovvdsc)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV98Configuracion_movimientoventawwds_17_tfmovvdsc)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_movimientoventawwds_18_tfmovvdsc_sel)) )
         {
            AddWhere(sWhereString, "([MovVDsc] = @AV99Configuracion_movimientoventawwds_18_tfmovvdsc_sel)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV100Configuracion_movimientoventawwds_19_tfmovvabr_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV100Configuracion_movimientoventawwds_19_tfmovvabr_sels, "[MovVAbr] IN (", ")")+")");
         }
         if ( AV101Configuracion_movimientoventawwds_20_tfmovvtip_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV101Configuracion_movimientoventawwds_20_tfmovvtip_sels, "[MovVTip] IN (", ")")+")");
         }
         if ( AV102Configuracion_movimientoventawwds_21_tfmovvsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV102Configuracion_movimientoventawwds_21_tfmovvsts_sels, "[MovVSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovVCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovVCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovVDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovVDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovVAbr]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovVAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovVTip]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovVTip] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovVSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovVSts] DESC";
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
                     return conditional_P003G2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (GxSimpleCollection<short>)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (int)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP003G2;
          prmP003G2 = new Object[] {
          new ParDef("@lV84Configuracion_movimientoventawwds_3_movvdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV84Configuracion_movimientoventawwds_3_movvdsc1",GXType.NChar,100,0) ,
          new ParDef("@AV85Configuracion_movimientoventawwds_4_movvtip1",GXType.NChar,1,0) ,
          new ParDef("@lV89Configuracion_movimientoventawwds_8_movvdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV89Configuracion_movimientoventawwds_8_movvdsc2",GXType.NChar,100,0) ,
          new ParDef("@AV90Configuracion_movimientoventawwds_9_movvtip2",GXType.NChar,1,0) ,
          new ParDef("@lV94Configuracion_movimientoventawwds_13_movvdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV94Configuracion_movimientoventawwds_13_movvdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV95Configuracion_movimientoventawwds_14_movvtip3",GXType.NChar,1,0) ,
          new ParDef("@AV96Configuracion_movimientoventawwds_15_tfmovvcod",GXType.Int32,6,0) ,
          new ParDef("@AV97Configuracion_movimientoventawwds_16_tfmovvcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV98Configuracion_movimientoventawwds_17_tfmovvdsc",GXType.NChar,100,0) ,
          new ParDef("@AV99Configuracion_movimientoventawwds_18_tfmovvdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003G2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
