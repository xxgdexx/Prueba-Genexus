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
   public class movimientoalmacenwwexportreport : GXWebProcedure
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

      public movimientoalmacenwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public movimientoalmacenwwexportreport( IGxContext context )
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
         movimientoalmacenwwexportreport objmovimientoalmacenwwexportreport;
         objmovimientoalmacenwwexportreport = new movimientoalmacenwwexportreport();
         objmovimientoalmacenwwexportreport.context.SetSubmitInitialConfig(context);
         objmovimientoalmacenwwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmovimientoalmacenwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((movimientoalmacenwwexportreport)stateInfo).executePrivate();
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
            AV71Title = "Lista de Movimiento Almacen";
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
            H3D0( true, 0) ;
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
         if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "MOVDSC") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV16MovDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16MovDsc1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterMovDscDescription = StringUtil.Format( "%1 (%2)", "Movimiento de Almacen", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterMovDscDescription = StringUtil.Format( "%1 (%2)", "Movimiento de Almacen", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV18MovDsc = AV16MovDsc1;
                  H3D0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMovDscDescription, "")), 25, Gx_line+0, 261, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18MovDsc, "")), 261, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "MOVTIP") == 0 )
            {
               AV19MovTip1 = (short)(NumberUtil.Val( AV35GridStateDynamicFilter.gxTpr_Value, "."));
               if ( ! (0==AV19MovTip1) )
               {
                  if ( AV19MovTip1 == 1 )
                  {
                     AV22FilterMovTip1ValueDescription = "Entrada";
                  }
                  else if ( AV19MovTip1 == 2 )
                  {
                     AV22FilterMovTip1ValueDescription = "Salida";
                  }
                  AV21FilterMovTipValueDescription = AV22FilterMovTip1ValueDescription;
                  H3D0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Tipo de Movimiento", 25, Gx_line+0, 261, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterMovTipValueDescription, "")), 261, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "MOVDSC") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV26MovDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26MovDsc2)) )
                  {
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterMovDscDescription = StringUtil.Format( "%1 (%2)", "Movimiento de Almacen", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterMovDscDescription = StringUtil.Format( "%1 (%2)", "Movimiento de Almacen", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV18MovDsc = AV26MovDsc2;
                     H3D0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMovDscDescription, "")), 25, Gx_line+0, 261, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18MovDsc, "")), 261, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "MOVTIP") == 0 )
               {
                  AV27MovTip2 = (short)(NumberUtil.Val( AV35GridStateDynamicFilter.gxTpr_Value, "."));
                  if ( ! (0==AV27MovTip2) )
                  {
                     if ( AV27MovTip2 == 1 )
                     {
                        AV28FilterMovTip2ValueDescription = "Entrada";
                     }
                     else if ( AV27MovTip2 == 2 )
                     {
                        AV28FilterMovTip2ValueDescription = "Salida";
                     }
                     AV21FilterMovTipValueDescription = AV28FilterMovTip2ValueDescription;
                     H3D0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Tipo de Movimiento", 25, Gx_line+0, 261, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterMovTipValueDescription, "")), 261, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "MOVDSC") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV32MovDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32MovDsc3)) )
                     {
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterMovDscDescription = StringUtil.Format( "%1 (%2)", "Movimiento de Almacen", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterMovDscDescription = StringUtil.Format( "%1 (%2)", "Movimiento de Almacen", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV18MovDsc = AV32MovDsc3;
                        H3D0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMovDscDescription, "")), 25, Gx_line+0, 261, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18MovDsc, "")), 261, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "MOVTIP") == 0 )
                  {
                     AV33MovTip3 = (short)(NumberUtil.Val( AV35GridStateDynamicFilter.gxTpr_Value, "."));
                     if ( ! (0==AV33MovTip3) )
                     {
                        if ( AV33MovTip3 == 1 )
                        {
                           AV34FilterMovTip3ValueDescription = "Entrada";
                        }
                        else if ( AV33MovTip3 == 2 )
                        {
                           AV34FilterMovTip3ValueDescription = "Salida";
                        }
                        AV21FilterMovTipValueDescription = AV34FilterMovTip3ValueDescription;
                        H3D0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText("Tipo de Movimiento", 25, Gx_line+0, 261, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterMovTipValueDescription, "")), 261, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV40TFMovCod) && (0==AV41TFMovCod_To) ) )
         {
            H3D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 261, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40TFMovCod), "ZZZZZ9")), 261, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV56TFMovCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H3D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56TFMovCod_To_Description, "")), 25, Gx_line+0, 261, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV41TFMovCod_To), "ZZZZZ9")), 261, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFMovDsc_Sel)) )
         {
            H3D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Movimiento Almacen", 25, Gx_line+0, 261, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFMovDsc_Sel, "")), 261, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFMovDsc)) )
            {
               H3D0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Movimiento Almacen", 25, Gx_line+0, 261, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFMovDsc, "")), 261, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFMovAbr_Sel)) )
         {
            H3D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Sunat", 25, Gx_line+0, 261, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFMovAbr_Sel, "")), 261, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFMovAbr)) )
            {
               H3D0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo Sunat", 25, Gx_line+0, 261, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFMovAbr, "")), 261, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV48TFMovTip_Sels.FromJSonString(AV46TFMovTip_SelsJson, null);
         if ( ! ( AV48TFMovTip_Sels.Count == 0 ) )
         {
            AV60i = 1;
            AV77GXV1 = 1;
            while ( AV77GXV1 <= AV48TFMovTip_Sels.Count )
            {
               AV49TFMovTip_Sel = (short)(AV48TFMovTip_Sels.GetNumeric(AV77GXV1));
               if ( AV60i == 1 )
               {
                  AV47TFMovTip_SelDscs = "";
               }
               else
               {
                  AV47TFMovTip_SelDscs += ", ";
               }
               if ( AV49TFMovTip_Sel == 1 )
               {
                  AV57FilterTFMovTip_SelValueDescription = "Entrada";
               }
               else if ( AV49TFMovTip_Sel == 2 )
               {
                  AV57FilterTFMovTip_SelValueDescription = "Salida";
               }
               AV47TFMovTip_SelDscs += AV57FilterTFMovTip_SelValueDescription;
               AV60i = (long)(AV60i+1);
               AV77GXV1 = (int)(AV77GXV1+1);
            }
            H3D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo Movimiento", 25, Gx_line+0, 261, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFMovTip_SelDscs, "")), 261, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV52TFMovSts_Sels.FromJSonString(AV50TFMovSts_SelsJson, null);
         if ( ! ( AV52TFMovSts_Sels.Count == 0 ) )
         {
            AV60i = 1;
            AV78GXV2 = 1;
            while ( AV78GXV2 <= AV52TFMovSts_Sels.Count )
            {
               AV53TFMovSts_Sel = (short)(AV52TFMovSts_Sels.GetNumeric(AV78GXV2));
               if ( AV60i == 1 )
               {
                  AV51TFMovSts_SelDscs = "";
               }
               else
               {
                  AV51TFMovSts_SelDscs += ", ";
               }
               if ( AV53TFMovSts_Sel == 1 )
               {
                  AV58FilterTFMovSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV53TFMovSts_Sel == 0 )
               {
                  AV58FilterTFMovSts_SelValueDescription = "INACTIVO";
               }
               AV51TFMovSts_SelDscs += AV58FilterTFMovSts_SelValueDescription;
               AV60i = (long)(AV60i+1);
               AV78GXV2 = (int)(AV78GXV2+1);
            }
            H3D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 261, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFMovSts_SelDscs, "")), 261, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H3D0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H3D0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 122, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Movimiento Almacen", 126, Gx_line+10, 310, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo Sunat", 314, Gx_line+10, 407, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo Movimiento", 411, Gx_line+10, 597, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 601, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV80Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV81Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV82Configuracion_movimientoalmacenwwds_3_movdsc1 = AV16MovDsc1;
         AV83Configuracion_movimientoalmacenwwds_4_movtip1 = AV19MovTip1;
         AV84Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV85Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV86Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV87Configuracion_movimientoalmacenwwds_8_movdsc2 = AV26MovDsc2;
         AV88Configuracion_movimientoalmacenwwds_9_movtip2 = AV27MovTip2;
         AV89Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV90Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV91Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV92Configuracion_movimientoalmacenwwds_13_movdsc3 = AV32MovDsc3;
         AV93Configuracion_movimientoalmacenwwds_14_movtip3 = AV33MovTip3;
         AV94Configuracion_movimientoalmacenwwds_15_tfmovcod = AV40TFMovCod;
         AV95Configuracion_movimientoalmacenwwds_16_tfmovcod_to = AV41TFMovCod_To;
         AV96Configuracion_movimientoalmacenwwds_17_tfmovdsc = AV42TFMovDsc;
         AV97Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel = AV43TFMovDsc_Sel;
         AV98Configuracion_movimientoalmacenwwds_19_tfmovabr = AV44TFMovAbr;
         AV99Configuracion_movimientoalmacenwwds_20_tfmovabr_sel = AV45TFMovAbr_Sel;
         AV100Configuracion_movimientoalmacenwwds_21_tfmovtip_sels = AV48TFMovTip_Sels;
         AV101Configuracion_movimientoalmacenwwds_22_tfmovsts_sels = AV52TFMovSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1241MovTip ,
                                              AV100Configuracion_movimientoalmacenwwds_21_tfmovtip_sels ,
                                              A1240MovSts ,
                                              AV101Configuracion_movimientoalmacenwwds_22_tfmovsts_sels ,
                                              AV80Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 ,
                                              AV81Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 ,
                                              AV82Configuracion_movimientoalmacenwwds_3_movdsc1 ,
                                              AV83Configuracion_movimientoalmacenwwds_4_movtip1 ,
                                              AV84Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 ,
                                              AV85Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 ,
                                              AV86Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 ,
                                              AV87Configuracion_movimientoalmacenwwds_8_movdsc2 ,
                                              AV88Configuracion_movimientoalmacenwwds_9_movtip2 ,
                                              AV89Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 ,
                                              AV90Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 ,
                                              AV91Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 ,
                                              AV92Configuracion_movimientoalmacenwwds_13_movdsc3 ,
                                              AV93Configuracion_movimientoalmacenwwds_14_movtip3 ,
                                              AV94Configuracion_movimientoalmacenwwds_15_tfmovcod ,
                                              AV95Configuracion_movimientoalmacenwwds_16_tfmovcod_to ,
                                              AV97Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel ,
                                              AV96Configuracion_movimientoalmacenwwds_17_tfmovdsc ,
                                              AV99Configuracion_movimientoalmacenwwds_20_tfmovabr_sel ,
                                              AV98Configuracion_movimientoalmacenwwds_19_tfmovabr ,
                                              AV100Configuracion_movimientoalmacenwwds_21_tfmovtip_sels.Count ,
                                              AV101Configuracion_movimientoalmacenwwds_22_tfmovsts_sels.Count ,
                                              A1239MovDsc ,
                                              A234MovCod ,
                                              A1237MovAbr ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV82Configuracion_movimientoalmacenwwds_3_movdsc1 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_movimientoalmacenwwds_3_movdsc1), 100, "%");
         lV82Configuracion_movimientoalmacenwwds_3_movdsc1 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_movimientoalmacenwwds_3_movdsc1), 100, "%");
         lV87Configuracion_movimientoalmacenwwds_8_movdsc2 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_movimientoalmacenwwds_8_movdsc2), 100, "%");
         lV87Configuracion_movimientoalmacenwwds_8_movdsc2 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_movimientoalmacenwwds_8_movdsc2), 100, "%");
         lV92Configuracion_movimientoalmacenwwds_13_movdsc3 = StringUtil.PadR( StringUtil.RTrim( AV92Configuracion_movimientoalmacenwwds_13_movdsc3), 100, "%");
         lV92Configuracion_movimientoalmacenwwds_13_movdsc3 = StringUtil.PadR( StringUtil.RTrim( AV92Configuracion_movimientoalmacenwwds_13_movdsc3), 100, "%");
         lV96Configuracion_movimientoalmacenwwds_17_tfmovdsc = StringUtil.PadR( StringUtil.RTrim( AV96Configuracion_movimientoalmacenwwds_17_tfmovdsc), 100, "%");
         lV98Configuracion_movimientoalmacenwwds_19_tfmovabr = StringUtil.PadR( StringUtil.RTrim( AV98Configuracion_movimientoalmacenwwds_19_tfmovabr), 5, "%");
         /* Using cursor P003D2 */
         pr_default.execute(0, new Object[] {lV82Configuracion_movimientoalmacenwwds_3_movdsc1, lV82Configuracion_movimientoalmacenwwds_3_movdsc1, AV83Configuracion_movimientoalmacenwwds_4_movtip1, lV87Configuracion_movimientoalmacenwwds_8_movdsc2, lV87Configuracion_movimientoalmacenwwds_8_movdsc2, AV88Configuracion_movimientoalmacenwwds_9_movtip2, lV92Configuracion_movimientoalmacenwwds_13_movdsc3, lV92Configuracion_movimientoalmacenwwds_13_movdsc3, AV93Configuracion_movimientoalmacenwwds_14_movtip3, AV94Configuracion_movimientoalmacenwwds_15_tfmovcod, AV95Configuracion_movimientoalmacenwwds_16_tfmovcod_to, lV96Configuracion_movimientoalmacenwwds_17_tfmovdsc, AV97Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel, lV98Configuracion_movimientoalmacenwwds_19_tfmovabr, AV99Configuracion_movimientoalmacenwwds_20_tfmovabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1240MovSts = P003D2_A1240MovSts[0];
            A1237MovAbr = P003D2_A1237MovAbr[0];
            A234MovCod = P003D2_A234MovCod[0];
            A1241MovTip = P003D2_A1241MovTip[0];
            A1239MovDsc = P003D2_A1239MovDsc[0];
            if ( A1241MovTip == 1 )
            {
               AV12MovTipDescription = "Entrada";
            }
            else if ( A1241MovTip == 2 )
            {
               AV12MovTipDescription = "Salida";
            }
            if ( A1240MovSts == 1 )
            {
               AV13MovStsDescription = "ACTIVO";
            }
            else if ( A1240MovSts == 0 )
            {
               AV13MovStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H3D0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A234MovCod), "ZZZZZ9")), 30, Gx_line+10, 122, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1239MovDsc, "")), 126, Gx_line+10, 310, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1237MovAbr, "")), 314, Gx_line+10, 407, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12MovTipDescription, "")), 411, Gx_line+10, 597, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13MovStsDescription, "")), 601, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV36Session.Get("Configuracion.MovimientoAlmacenWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.MovimientoAlmacenWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("Configuracion.MovimientoAlmacenWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV38GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV38GridState.gxTpr_Ordereddsc;
         AV102GXV3 = 1;
         while ( AV102GXV3 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV102GXV3));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMOVCOD") == 0 )
            {
               AV40TFMovCod = (int)(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."));
               AV41TFMovCod_To = (int)(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMOVDSC") == 0 )
            {
               AV42TFMovDsc = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMOVDSC_SEL") == 0 )
            {
               AV43TFMovDsc_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMOVABR") == 0 )
            {
               AV44TFMovAbr = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMOVABR_SEL") == 0 )
            {
               AV45TFMovAbr_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMOVTIP_SEL") == 0 )
            {
               AV46TFMovTip_SelsJson = AV39GridStateFilterValue.gxTpr_Value;
               AV48TFMovTip_Sels.FromJSonString(AV46TFMovTip_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMOVSTS_SEL") == 0 )
            {
               AV50TFMovSts_SelsJson = AV39GridStateFilterValue.gxTpr_Value;
               AV52TFMovSts_Sels.FromJSonString(AV50TFMovSts_SelsJson, null);
            }
            AV102GXV3 = (int)(AV102GXV3+1);
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

      protected void H3D0( bool bFoot ,
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
                  AV69PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV66DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV64AppName = "DVelop Software Solutions";
               AV70Phone = "+1 550 8923";
               AV68Mail = "info@mail.com";
               AV72Website = "http://www.web.com";
               AV61AddressLine1 = "French Boulevard 2859";
               AV62AddressLine2 = "Downtown";
               AV63AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV71Title = "";
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16MovDsc1 = "";
         AV17FilterMovDscDescription = "";
         AV18MovDsc = "";
         AV22FilterMovTip1ValueDescription = "";
         AV21FilterMovTipValueDescription = "";
         AV24DynamicFiltersSelector2 = "";
         AV26MovDsc2 = "";
         AV28FilterMovTip2ValueDescription = "";
         AV30DynamicFiltersSelector3 = "";
         AV32MovDsc3 = "";
         AV34FilterMovTip3ValueDescription = "";
         AV56TFMovCod_To_Description = "";
         AV43TFMovDsc_Sel = "";
         AV42TFMovDsc = "";
         AV45TFMovAbr_Sel = "";
         AV44TFMovAbr = "";
         AV48TFMovTip_Sels = new GxSimpleCollection<short>();
         AV46TFMovTip_SelsJson = "";
         AV47TFMovTip_SelDscs = "";
         AV57FilterTFMovTip_SelValueDescription = "";
         AV52TFMovSts_Sels = new GxSimpleCollection<short>();
         AV50TFMovSts_SelsJson = "";
         AV51TFMovSts_SelDscs = "";
         AV58FilterTFMovSts_SelValueDescription = "";
         AV80Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 = "";
         AV82Configuracion_movimientoalmacenwwds_3_movdsc1 = "";
         AV85Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 = "";
         AV87Configuracion_movimientoalmacenwwds_8_movdsc2 = "";
         AV90Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 = "";
         AV92Configuracion_movimientoalmacenwwds_13_movdsc3 = "";
         AV96Configuracion_movimientoalmacenwwds_17_tfmovdsc = "";
         AV97Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel = "";
         AV98Configuracion_movimientoalmacenwwds_19_tfmovabr = "";
         AV99Configuracion_movimientoalmacenwwds_20_tfmovabr_sel = "";
         AV100Configuracion_movimientoalmacenwwds_21_tfmovtip_sels = new GxSimpleCollection<short>();
         AV101Configuracion_movimientoalmacenwwds_22_tfmovsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV82Configuracion_movimientoalmacenwwds_3_movdsc1 = "";
         lV87Configuracion_movimientoalmacenwwds_8_movdsc2 = "";
         lV92Configuracion_movimientoalmacenwwds_13_movdsc3 = "";
         lV96Configuracion_movimientoalmacenwwds_17_tfmovdsc = "";
         lV98Configuracion_movimientoalmacenwwds_19_tfmovabr = "";
         A1239MovDsc = "";
         A1237MovAbr = "";
         P003D2_A1240MovSts = new short[1] ;
         P003D2_A1237MovAbr = new string[] {""} ;
         P003D2_A234MovCod = new int[1] ;
         P003D2_A1241MovTip = new short[1] ;
         P003D2_A1239MovDsc = new string[] {""} ;
         AV12MovTipDescription = "";
         AV13MovStsDescription = "";
         AV36Session = context.GetSession();
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV69PageInfo = "";
         AV66DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV64AppName = "";
         AV70Phone = "";
         AV68Mail = "";
         AV72Website = "";
         AV61AddressLine1 = "";
         AV62AddressLine2 = "";
         AV63AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.movimientoalmacenwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P003D2_A1240MovSts, P003D2_A1237MovAbr, P003D2_A234MovCod, P003D2_A1241MovTip, P003D2_A1239MovDsc
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
      private short AV15DynamicFiltersOperator1 ;
      private short AV19MovTip1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV27MovTip2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short AV33MovTip3 ;
      private short AV49TFMovTip_Sel ;
      private short AV53TFMovSts_Sel ;
      private short AV81Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 ;
      private short AV83Configuracion_movimientoalmacenwwds_4_movtip1 ;
      private short AV86Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 ;
      private short AV88Configuracion_movimientoalmacenwwds_9_movtip2 ;
      private short AV91Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 ;
      private short AV93Configuracion_movimientoalmacenwwds_14_movtip3 ;
      private short A1241MovTip ;
      private short A1240MovSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV40TFMovCod ;
      private int AV41TFMovCod_To ;
      private int AV77GXV1 ;
      private int AV78GXV2 ;
      private int AV94Configuracion_movimientoalmacenwwds_15_tfmovcod ;
      private int AV95Configuracion_movimientoalmacenwwds_16_tfmovcod_to ;
      private int AV100Configuracion_movimientoalmacenwwds_21_tfmovtip_sels_Count ;
      private int AV101Configuracion_movimientoalmacenwwds_22_tfmovsts_sels_Count ;
      private int A234MovCod ;
      private int AV102GXV3 ;
      private long AV60i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV16MovDsc1 ;
      private string AV18MovDsc ;
      private string AV26MovDsc2 ;
      private string AV32MovDsc3 ;
      private string AV43TFMovDsc_Sel ;
      private string AV42TFMovDsc ;
      private string AV45TFMovAbr_Sel ;
      private string AV44TFMovAbr ;
      private string AV82Configuracion_movimientoalmacenwwds_3_movdsc1 ;
      private string AV87Configuracion_movimientoalmacenwwds_8_movdsc2 ;
      private string AV92Configuracion_movimientoalmacenwwds_13_movdsc3 ;
      private string AV96Configuracion_movimientoalmacenwwds_17_tfmovdsc ;
      private string AV97Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel ;
      private string AV98Configuracion_movimientoalmacenwwds_19_tfmovabr ;
      private string AV99Configuracion_movimientoalmacenwwds_20_tfmovabr_sel ;
      private string scmdbuf ;
      private string lV82Configuracion_movimientoalmacenwwds_3_movdsc1 ;
      private string lV87Configuracion_movimientoalmacenwwds_8_movdsc2 ;
      private string lV92Configuracion_movimientoalmacenwwds_13_movdsc3 ;
      private string lV96Configuracion_movimientoalmacenwwds_17_tfmovdsc ;
      private string lV98Configuracion_movimientoalmacenwwds_19_tfmovabr ;
      private string A1239MovDsc ;
      private string A1237MovAbr ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV84Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 ;
      private bool AV89Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV46TFMovTip_SelsJson ;
      private string AV50TFMovSts_SelsJson ;
      private string AV71Title ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterMovDscDescription ;
      private string AV22FilterMovTip1ValueDescription ;
      private string AV21FilterMovTipValueDescription ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28FilterMovTip2ValueDescription ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV34FilterMovTip3ValueDescription ;
      private string AV56TFMovCod_To_Description ;
      private string AV47TFMovTip_SelDscs ;
      private string AV57FilterTFMovTip_SelValueDescription ;
      private string AV51TFMovSts_SelDscs ;
      private string AV58FilterTFMovSts_SelValueDescription ;
      private string AV80Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 ;
      private string AV85Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 ;
      private string AV90Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 ;
      private string AV12MovTipDescription ;
      private string AV13MovStsDescription ;
      private string AV69PageInfo ;
      private string AV66DateInfo ;
      private string AV64AppName ;
      private string AV70Phone ;
      private string AV68Mail ;
      private string AV72Website ;
      private string AV61AddressLine1 ;
      private string AV62AddressLine2 ;
      private string AV63AddressLine3 ;
      private GxSimpleCollection<short> AV48TFMovTip_Sels ;
      private GxSimpleCollection<short> AV52TFMovSts_Sels ;
      private GxSimpleCollection<short> AV100Configuracion_movimientoalmacenwwds_21_tfmovtip_sels ;
      private GxSimpleCollection<short> AV101Configuracion_movimientoalmacenwwds_22_tfmovsts_sels ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003D2_A1240MovSts ;
      private string[] P003D2_A1237MovAbr ;
      private int[] P003D2_A234MovCod ;
      private short[] P003D2_A1241MovTip ;
      private string[] P003D2_A1239MovDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV35GridStateDynamicFilter ;
   }

   public class movimientoalmacenwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003D2( IGxContext context ,
                                             short A1241MovTip ,
                                             GxSimpleCollection<short> AV100Configuracion_movimientoalmacenwwds_21_tfmovtip_sels ,
                                             short A1240MovSts ,
                                             GxSimpleCollection<short> AV101Configuracion_movimientoalmacenwwds_22_tfmovsts_sels ,
                                             string AV80Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 ,
                                             short AV81Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 ,
                                             string AV82Configuracion_movimientoalmacenwwds_3_movdsc1 ,
                                             short AV83Configuracion_movimientoalmacenwwds_4_movtip1 ,
                                             bool AV84Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 ,
                                             string AV85Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 ,
                                             short AV86Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 ,
                                             string AV87Configuracion_movimientoalmacenwwds_8_movdsc2 ,
                                             short AV88Configuracion_movimientoalmacenwwds_9_movtip2 ,
                                             bool AV89Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 ,
                                             string AV90Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 ,
                                             short AV91Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 ,
                                             string AV92Configuracion_movimientoalmacenwwds_13_movdsc3 ,
                                             short AV93Configuracion_movimientoalmacenwwds_14_movtip3 ,
                                             int AV94Configuracion_movimientoalmacenwwds_15_tfmovcod ,
                                             int AV95Configuracion_movimientoalmacenwwds_16_tfmovcod_to ,
                                             string AV97Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel ,
                                             string AV96Configuracion_movimientoalmacenwwds_17_tfmovdsc ,
                                             string AV99Configuracion_movimientoalmacenwwds_20_tfmovabr_sel ,
                                             string AV98Configuracion_movimientoalmacenwwds_19_tfmovabr ,
                                             int AV100Configuracion_movimientoalmacenwwds_21_tfmovtip_sels_Count ,
                                             int AV101Configuracion_movimientoalmacenwwds_22_tfmovsts_sels_Count ,
                                             string A1239MovDsc ,
                                             int A234MovCod ,
                                             string A1237MovAbr ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [MovSts], [MovAbr], [MovCod], [MovTip], [MovDsc] FROM [CMOVALMACEN]";
         if ( ( StringUtil.StrCmp(AV80Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1, "MOVDSC") == 0 ) && ( AV81Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_movimientoalmacenwwds_3_movdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV82Configuracion_movimientoalmacenwwds_3_movdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV80Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1, "MOVDSC") == 0 ) && ( AV81Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_movimientoalmacenwwds_3_movdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like '%' + @lV82Configuracion_movimientoalmacenwwds_3_movdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV80Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1, "MOVTIP") == 0 ) && ( ! (0==AV83Configuracion_movimientoalmacenwwds_4_movtip1) ) )
         {
            AddWhere(sWhereString, "([MovTip] = @AV83Configuracion_movimientoalmacenwwds_4_movtip1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV84Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2, "MOVDSC") == 0 ) && ( AV86Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_movimientoalmacenwwds_8_movdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV87Configuracion_movimientoalmacenwwds_8_movdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV84Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2, "MOVDSC") == 0 ) && ( AV86Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_movimientoalmacenwwds_8_movdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like '%' + @lV87Configuracion_movimientoalmacenwwds_8_movdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV84Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2, "MOVTIP") == 0 ) && ( ! (0==AV88Configuracion_movimientoalmacenwwds_9_movtip2) ) )
         {
            AddWhere(sWhereString, "([MovTip] = @AV88Configuracion_movimientoalmacenwwds_9_movtip2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV89Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3, "MOVDSC") == 0 ) && ( AV91Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_movimientoalmacenwwds_13_movdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV92Configuracion_movimientoalmacenwwds_13_movdsc3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV89Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3, "MOVDSC") == 0 ) && ( AV91Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_movimientoalmacenwwds_13_movdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like '%' + @lV92Configuracion_movimientoalmacenwwds_13_movdsc3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV89Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3, "MOVTIP") == 0 ) && ( ! (0==AV93Configuracion_movimientoalmacenwwds_14_movtip3) ) )
         {
            AddWhere(sWhereString, "([MovTip] = @AV93Configuracion_movimientoalmacenwwds_14_movtip3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV94Configuracion_movimientoalmacenwwds_15_tfmovcod) )
         {
            AddWhere(sWhereString, "([MovCod] >= @AV94Configuracion_movimientoalmacenwwds_15_tfmovcod)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV95Configuracion_movimientoalmacenwwds_16_tfmovcod_to) )
         {
            AddWhere(sWhereString, "([MovCod] <= @AV95Configuracion_movimientoalmacenwwds_16_tfmovcod_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Configuracion_movimientoalmacenwwds_17_tfmovdsc)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV96Configuracion_movimientoalmacenwwds_17_tfmovdsc)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel)) )
         {
            AddWhere(sWhereString, "([MovDsc] = @AV97Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_movimientoalmacenwwds_20_tfmovabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_movimientoalmacenwwds_19_tfmovabr)) ) )
         {
            AddWhere(sWhereString, "([MovAbr] like @lV98Configuracion_movimientoalmacenwwds_19_tfmovabr)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_movimientoalmacenwwds_20_tfmovabr_sel)) )
         {
            AddWhere(sWhereString, "([MovAbr] = @AV99Configuracion_movimientoalmacenwwds_20_tfmovabr_sel)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV100Configuracion_movimientoalmacenwwds_21_tfmovtip_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV100Configuracion_movimientoalmacenwwds_21_tfmovtip_sels, "[MovTip] IN (", ")")+")");
         }
         if ( AV101Configuracion_movimientoalmacenwwds_22_tfmovsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV101Configuracion_movimientoalmacenwwds_22_tfmovsts_sels, "[MovSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovAbr]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovTip]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovTip] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovSts] DESC";
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
                     return conditional_P003D2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP003D2;
          prmP003D2 = new Object[] {
          new ParDef("@lV82Configuracion_movimientoalmacenwwds_3_movdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_movimientoalmacenwwds_3_movdsc1",GXType.NChar,100,0) ,
          new ParDef("@AV83Configuracion_movimientoalmacenwwds_4_movtip1",GXType.Int16,1,0) ,
          new ParDef("@lV87Configuracion_movimientoalmacenwwds_8_movdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV87Configuracion_movimientoalmacenwwds_8_movdsc2",GXType.NChar,100,0) ,
          new ParDef("@AV88Configuracion_movimientoalmacenwwds_9_movtip2",GXType.Int16,1,0) ,
          new ParDef("@lV92Configuracion_movimientoalmacenwwds_13_movdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV92Configuracion_movimientoalmacenwwds_13_movdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV93Configuracion_movimientoalmacenwwds_14_movtip3",GXType.Int16,1,0) ,
          new ParDef("@AV94Configuracion_movimientoalmacenwwds_15_tfmovcod",GXType.Int32,6,0) ,
          new ParDef("@AV95Configuracion_movimientoalmacenwwds_16_tfmovcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV96Configuracion_movimientoalmacenwwds_17_tfmovdsc",GXType.NChar,100,0) ,
          new ParDef("@AV97Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV98Configuracion_movimientoalmacenwwds_19_tfmovabr",GXType.NChar,5,0) ,
          new ParDef("@AV99Configuracion_movimientoalmacenwwds_20_tfmovabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003D2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
