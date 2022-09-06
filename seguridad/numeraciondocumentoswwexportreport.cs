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
namespace GeneXus.Programs.seguridad {
   public class numeraciondocumentoswwexportreport : GXWebProcedure
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

      public numeraciondocumentoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public numeraciondocumentoswwexportreport( IGxContext context )
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
         numeraciondocumentoswwexportreport objnumeraciondocumentoswwexportreport;
         objnumeraciondocumentoswwexportreport = new numeraciondocumentoswwexportreport();
         objnumeraciondocumentoswwexportreport.context.SetSubmitInitialConfig(context);
         objnumeraciondocumentoswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objnumeraciondocumentoswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((numeraciondocumentoswwexportreport)stateInfo).executePrivate();
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
            AV60Title = "Lista de Numeracion Documentos";
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
            H240( true, 0) ;
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
            AV12DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CORDOC") == 0 )
            {
               AV14CorDoc1 = AV35GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14CorDoc1)) )
               {
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV14CorDoc1), "FACTURA") == 0 )
                  {
                     AV63FilterCorDoc1ValueDescription = "FACTURA";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV14CorDoc1), "NOTCREDITO") == 0 )
                  {
                     AV63FilterCorDoc1ValueDescription = "NOTA DE CREDITO";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV14CorDoc1), "NOTDEBITO") == 0 )
                  {
                     AV63FilterCorDoc1ValueDescription = "NOTA DE DEBITO";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV14CorDoc1), "BOLETA") == 0 )
                  {
                     AV63FilterCorDoc1ValueDescription = "BOLETA";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV14CorDoc1), "REMISION") == 0 )
                  {
                     AV63FilterCorDoc1ValueDescription = "REMISION";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV14CorDoc1), "LETRA") == 0 )
                  {
                     AV63FilterCorDoc1ValueDescription = "LETRA DE CAMBIO";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV14CorDoc1), "PERCEPCION") == 0 )
                  {
                     AV63FilterCorDoc1ValueDescription = "PERCEPCION";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV14CorDoc1), "RECIBO") == 0 )
                  {
                     AV63FilterCorDoc1ValueDescription = "RECIBO";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV14CorDoc1), "ENTRADA") == 0 )
                  {
                     AV63FilterCorDoc1ValueDescription = "ENTRADA";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV14CorDoc1), "SALIDA") == 0 )
                  {
                     AV63FilterCorDoc1ValueDescription = "SALIDA";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV14CorDoc1), "ORDENCOMPR") == 0 )
                  {
                     AV63FilterCorDoc1ValueDescription = "ORDEN DE COMPRA";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV14CorDoc1), "RETENCION") == 0 )
                  {
                     AV63FilterCorDoc1ValueDescription = "RETENCION";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV14CorDoc1), "TICKET") == 0 )
                  {
                     AV63FilterCorDoc1ValueDescription = "TICKET";
                  }
                  AV62FilterCorDocValueDescription = AV63FilterCorDoc1ValueDescription;
                  H240( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Tipo Documento", 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62FilterCorDocValueDescription, "")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "NUMDOC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV17NumDoc1 = (long)(NumberUtil.Val( AV35GridStateDynamicFilter.gxTpr_Value, "."));
               if ( ! (0==AV17NumDoc1) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV18FilterNumDocDescription = StringUtil.Format( "%1 (%2)", "N° Documento", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV18FilterNumDocDescription = StringUtil.Format( "%1 (%2)", "N° Documento", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 2 )
                  {
                     AV18FilterNumDocDescription = StringUtil.Format( "%1 (%2)", "N° Documento", ">", "", "", "", "", "", "", "");
                  }
                  AV19NumDoc = AV17NumDoc1;
                  H240( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterNumDocDescription, "")), 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19NumDoc), "ZZZZZZZZZ9")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "CORSERIE") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV20CorSerie1 = AV35GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20CorSerie1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV21FilterCorSerieDescription = StringUtil.Format( "%1 (%2)", "Serie", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV21FilterCorSerieDescription = StringUtil.Format( "%1 (%2)", "Serie", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV22CorSerie = AV20CorSerie1;
                  H240( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterCorSerieDescription, "")), 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22CorSerie, "")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CORDOC") == 0 )
               {
                  AV26CorDoc2 = AV35GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26CorDoc2)) )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "FACTURA") == 0 )
                     {
                        AV64FilterCorDoc2ValueDescription = "FACTURA";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "NOTCREDITO") == 0 )
                     {
                        AV64FilterCorDoc2ValueDescription = "NOTA DE CREDITO";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "NOTDEBITO") == 0 )
                     {
                        AV64FilterCorDoc2ValueDescription = "NOTA DE DEBITO";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "BOLETA") == 0 )
                     {
                        AV64FilterCorDoc2ValueDescription = "BOLETA";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "REMISION") == 0 )
                     {
                        AV64FilterCorDoc2ValueDescription = "REMISION";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "LETRA") == 0 )
                     {
                        AV64FilterCorDoc2ValueDescription = "LETRA DE CAMBIO";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "PERCEPCION") == 0 )
                     {
                        AV64FilterCorDoc2ValueDescription = "PERCEPCION";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "RECIBO") == 0 )
                     {
                        AV64FilterCorDoc2ValueDescription = "RECIBO";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "ENTRADA") == 0 )
                     {
                        AV64FilterCorDoc2ValueDescription = "ENTRADA";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "SALIDA") == 0 )
                     {
                        AV64FilterCorDoc2ValueDescription = "SALIDA";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "ORDENCOMPR") == 0 )
                     {
                        AV64FilterCorDoc2ValueDescription = "ORDEN DE COMPRA";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "RETENCION") == 0 )
                     {
                        AV64FilterCorDoc2ValueDescription = "RETENCION";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "TICKET") == 0 )
                     {
                        AV64FilterCorDoc2ValueDescription = "TICKET";
                     }
                     AV62FilterCorDocValueDescription = AV64FilterCorDoc2ValueDescription;
                     H240( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Tipo Documento", 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62FilterCorDocValueDescription, "")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "NUMDOC") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV27NumDoc2 = (long)(NumberUtil.Val( AV35GridStateDynamicFilter.gxTpr_Value, "."));
                  if ( ! (0==AV27NumDoc2) )
                  {
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV18FilterNumDocDescription = StringUtil.Format( "%1 (%2)", "N° Documento", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV18FilterNumDocDescription = StringUtil.Format( "%1 (%2)", "N° Documento", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 2 )
                     {
                        AV18FilterNumDocDescription = StringUtil.Format( "%1 (%2)", "N° Documento", ">", "", "", "", "", "", "", "");
                     }
                     AV19NumDoc = AV27NumDoc2;
                     H240( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterNumDocDescription, "")), 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19NumDoc), "ZZZZZZZZZ9")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CORSERIE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV28CorSerie2 = AV35GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28CorSerie2)) )
                  {
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV21FilterCorSerieDescription = StringUtil.Format( "%1 (%2)", "Serie", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV21FilterCorSerieDescription = StringUtil.Format( "%1 (%2)", "Serie", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV22CorSerie = AV28CorSerie2;
                     H240( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterCorSerieDescription, "")), 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22CorSerie, "")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CORDOC") == 0 )
                  {
                     AV32CorDoc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32CorDoc3)) )
                     {
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "FACTURA") == 0 )
                        {
                           AV65FilterCorDoc3ValueDescription = "FACTURA";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "NOTCREDITO") == 0 )
                        {
                           AV65FilterCorDoc3ValueDescription = "NOTA DE CREDITO";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "NOTDEBITO") == 0 )
                        {
                           AV65FilterCorDoc3ValueDescription = "NOTA DE DEBITO";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "BOLETA") == 0 )
                        {
                           AV65FilterCorDoc3ValueDescription = "BOLETA";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "REMISION") == 0 )
                        {
                           AV65FilterCorDoc3ValueDescription = "REMISION";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "LETRA") == 0 )
                        {
                           AV65FilterCorDoc3ValueDescription = "LETRA DE CAMBIO";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "PERCEPCION") == 0 )
                        {
                           AV65FilterCorDoc3ValueDescription = "PERCEPCION";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "RECIBO") == 0 )
                        {
                           AV65FilterCorDoc3ValueDescription = "RECIBO";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "ENTRADA") == 0 )
                        {
                           AV65FilterCorDoc3ValueDescription = "ENTRADA";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "SALIDA") == 0 )
                        {
                           AV65FilterCorDoc3ValueDescription = "SALIDA";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "ORDENCOMPR") == 0 )
                        {
                           AV65FilterCorDoc3ValueDescription = "ORDEN DE COMPRA";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "RETENCION") == 0 )
                        {
                           AV65FilterCorDoc3ValueDescription = "RETENCION";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "TICKET") == 0 )
                        {
                           AV65FilterCorDoc3ValueDescription = "TICKET";
                        }
                        AV62FilterCorDocValueDescription = AV65FilterCorDoc3ValueDescription;
                        H240( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText("Tipo Documento", 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62FilterCorDocValueDescription, "")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "NUMDOC") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV33NumDoc3 = (long)(NumberUtil.Val( AV35GridStateDynamicFilter.gxTpr_Value, "."));
                     if ( ! (0==AV33NumDoc3) )
                     {
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV18FilterNumDocDescription = StringUtil.Format( "%1 (%2)", "N° Documento", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV18FilterNumDocDescription = StringUtil.Format( "%1 (%2)", "N° Documento", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 2 )
                        {
                           AV18FilterNumDocDescription = StringUtil.Format( "%1 (%2)", "N° Documento", ">", "", "", "", "", "", "", "");
                        }
                        AV19NumDoc = AV33NumDoc3;
                        H240( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterNumDocDescription, "")), 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19NumDoc), "ZZZZZZZZZ9")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CORSERIE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV34CorSerie3 = AV35GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34CorSerie3)) )
                     {
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV21FilterCorSerieDescription = StringUtil.Format( "%1 (%2)", "Serie", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV21FilterCorSerieDescription = StringUtil.Format( "%1 (%2)", "Serie", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV22CorSerie = AV34CorSerie3;
                        H240( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterCorSerieDescription, "")), 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22CorSerie, "")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFCorDoc_Sel)) )
         {
            H240( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Documento", 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFCorDoc_Sel, "")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCorDoc)) )
            {
               H240( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Documento", 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFCorDoc, "")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV42TFNumDoc) && (0==AV43TFNumDoc_To) ) )
         {
            H240( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("N° Documento", 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV42TFNumDoc), "ZZZZZZZZZ9")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV49TFNumDoc_To_Description = StringUtil.Format( "%1 (%2)", "N° Documento", "Hasta", "", "", "", "", "", "", "");
            H240( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFNumDoc_To_Description, "")), 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV43TFNumDoc_To), "ZZZZZZZZZ9")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCorSerie_Sel)) )
         {
            H240( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Serie", 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFCorSerie_Sel, "")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCorSerie)) )
            {
               H240( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Serie", 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFCorSerie, "")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV46TFCorFE_Sel) )
         {
            H240( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Electronica", 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV46TFCorFE_Sel), "9")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCorFormato_Sel)) )
         {
            H240( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Formato", 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFCorFormato_Sel, "")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCorFormato)) )
            {
               H240( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Formato", 25, Gx_line+0, 179, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFCorFormato, "")), 179, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H240( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H240( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Documento", 30, Gx_line+10, 153, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("N° Documento", 157, Gx_line+10, 280, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Serie", 284, Gx_line+10, 407, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Electronica", 411, Gx_line+10, 535, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Formato", 539, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV71Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV72Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV73Seguridad_numeraciondocumentoswwds_3_cordoc1 = AV14CorDoc1;
         AV74Seguridad_numeraciondocumentoswwds_4_numdoc1 = AV17NumDoc1;
         AV75Seguridad_numeraciondocumentoswwds_5_corserie1 = AV20CorSerie1;
         AV76Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV77Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV78Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV79Seguridad_numeraciondocumentoswwds_9_cordoc2 = AV26CorDoc2;
         AV80Seguridad_numeraciondocumentoswwds_10_numdoc2 = AV27NumDoc2;
         AV81Seguridad_numeraciondocumentoswwds_11_corserie2 = AV28CorSerie2;
         AV82Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV83Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV84Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV85Seguridad_numeraciondocumentoswwds_15_cordoc3 = AV32CorDoc3;
         AV86Seguridad_numeraciondocumentoswwds_16_numdoc3 = AV33NumDoc3;
         AV87Seguridad_numeraciondocumentoswwds_17_corserie3 = AV34CorSerie3;
         AV88Seguridad_numeraciondocumentoswwds_18_tfcordoc = AV40TFCorDoc;
         AV89Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = AV41TFCorDoc_Sel;
         AV90Seguridad_numeraciondocumentoswwds_20_tfnumdoc = AV42TFNumDoc;
         AV91Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to = AV43TFNumDoc_To;
         AV92Seguridad_numeraciondocumentoswwds_22_tfcorserie = AV44TFCorSerie;
         AV93Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = AV45TFCorSerie_Sel;
         AV94Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel = AV46TFCorFE_Sel;
         AV95Seguridad_numeraciondocumentoswwds_25_tfcorformato = AV47TFCorFormato;
         AV96Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = AV48TFCorFormato_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV71Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ,
                                              AV73Seguridad_numeraciondocumentoswwds_3_cordoc1 ,
                                              AV72Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ,
                                              AV74Seguridad_numeraciondocumentoswwds_4_numdoc1 ,
                                              AV75Seguridad_numeraciondocumentoswwds_5_corserie1 ,
                                              AV76Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ,
                                              AV77Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ,
                                              AV79Seguridad_numeraciondocumentoswwds_9_cordoc2 ,
                                              AV78Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ,
                                              AV80Seguridad_numeraciondocumentoswwds_10_numdoc2 ,
                                              AV81Seguridad_numeraciondocumentoswwds_11_corserie2 ,
                                              AV82Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ,
                                              AV83Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ,
                                              AV85Seguridad_numeraciondocumentoswwds_15_cordoc3 ,
                                              AV84Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ,
                                              AV86Seguridad_numeraciondocumentoswwds_16_numdoc3 ,
                                              AV87Seguridad_numeraciondocumentoswwds_17_corserie3 ,
                                              AV89Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ,
                                              AV88Seguridad_numeraciondocumentoswwds_18_tfcordoc ,
                                              AV90Seguridad_numeraciondocumentoswwds_20_tfnumdoc ,
                                              AV91Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ,
                                              AV93Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ,
                                              AV92Seguridad_numeraciondocumentoswwds_22_tfcorserie ,
                                              AV94Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ,
                                              AV96Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ,
                                              AV95Seguridad_numeraciondocumentoswwds_25_tfcorformato ,
                                              A339CorDoc ,
                                              A1377NumDoc ,
                                              A340CorSerie ,
                                              A756CorFE ,
                                              A757CorFormato ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV75Seguridad_numeraciondocumentoswwds_5_corserie1 = StringUtil.PadR( StringUtil.RTrim( AV75Seguridad_numeraciondocumentoswwds_5_corserie1), 4, "%");
         lV75Seguridad_numeraciondocumentoswwds_5_corserie1 = StringUtil.PadR( StringUtil.RTrim( AV75Seguridad_numeraciondocumentoswwds_5_corserie1), 4, "%");
         lV81Seguridad_numeraciondocumentoswwds_11_corserie2 = StringUtil.PadR( StringUtil.RTrim( AV81Seguridad_numeraciondocumentoswwds_11_corserie2), 4, "%");
         lV81Seguridad_numeraciondocumentoswwds_11_corserie2 = StringUtil.PadR( StringUtil.RTrim( AV81Seguridad_numeraciondocumentoswwds_11_corserie2), 4, "%");
         lV87Seguridad_numeraciondocumentoswwds_17_corserie3 = StringUtil.PadR( StringUtil.RTrim( AV87Seguridad_numeraciondocumentoswwds_17_corserie3), 4, "%");
         lV87Seguridad_numeraciondocumentoswwds_17_corserie3 = StringUtil.PadR( StringUtil.RTrim( AV87Seguridad_numeraciondocumentoswwds_17_corserie3), 4, "%");
         lV88Seguridad_numeraciondocumentoswwds_18_tfcordoc = StringUtil.PadR( StringUtil.RTrim( AV88Seguridad_numeraciondocumentoswwds_18_tfcordoc), 10, "%");
         lV92Seguridad_numeraciondocumentoswwds_22_tfcorserie = StringUtil.PadR( StringUtil.RTrim( AV92Seguridad_numeraciondocumentoswwds_22_tfcorserie), 4, "%");
         lV95Seguridad_numeraciondocumentoswwds_25_tfcorformato = StringUtil.Concat( StringUtil.RTrim( AV95Seguridad_numeraciondocumentoswwds_25_tfcorformato), "%", "");
         /* Using cursor P00242 */
         pr_default.execute(0, new Object[] {AV73Seguridad_numeraciondocumentoswwds_3_cordoc1, AV74Seguridad_numeraciondocumentoswwds_4_numdoc1, AV74Seguridad_numeraciondocumentoswwds_4_numdoc1, AV74Seguridad_numeraciondocumentoswwds_4_numdoc1, lV75Seguridad_numeraciondocumentoswwds_5_corserie1, lV75Seguridad_numeraciondocumentoswwds_5_corserie1, AV79Seguridad_numeraciondocumentoswwds_9_cordoc2, AV80Seguridad_numeraciondocumentoswwds_10_numdoc2, AV80Seguridad_numeraciondocumentoswwds_10_numdoc2, AV80Seguridad_numeraciondocumentoswwds_10_numdoc2, lV81Seguridad_numeraciondocumentoswwds_11_corserie2, lV81Seguridad_numeraciondocumentoswwds_11_corserie2, AV85Seguridad_numeraciondocumentoswwds_15_cordoc3, AV86Seguridad_numeraciondocumentoswwds_16_numdoc3, AV86Seguridad_numeraciondocumentoswwds_16_numdoc3, AV86Seguridad_numeraciondocumentoswwds_16_numdoc3, lV87Seguridad_numeraciondocumentoswwds_17_corserie3, lV87Seguridad_numeraciondocumentoswwds_17_corserie3, lV88Seguridad_numeraciondocumentoswwds_18_tfcordoc, AV89Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel, AV90Seguridad_numeraciondocumentoswwds_20_tfnumdoc, AV91Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to, lV92Seguridad_numeraciondocumentoswwds_22_tfcorserie, AV93Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel, lV95Seguridad_numeraciondocumentoswwds_25_tfcorformato, AV96Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A757CorFormato = P00242_A757CorFormato[0];
            A756CorFE = P00242_A756CorFE[0];
            A340CorSerie = P00242_A340CorSerie[0];
            A1377NumDoc = P00242_A1377NumDoc[0];
            A339CorDoc = P00242_A339CorDoc[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H240( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A339CorDoc, "")), 30, Gx_line+10, 153, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1377NumDoc), "ZZZZZZZZZ9")), 157, Gx_line+10, 280, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A340CorSerie, "")), 284, Gx_line+10, 407, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A756CorFE), "9")), 411, Gx_line+10, 535, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A757CorFormato, "")), 539, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV36Session.Get("Seguridad.NumeracionDocumentosWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.NumeracionDocumentosWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("Seguridad.NumeracionDocumentosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV38GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV38GridState.gxTpr_Ordereddsc;
         AV97GXV1 = 1;
         while ( AV97GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV97GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCORDOC") == 0 )
            {
               AV40TFCorDoc = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCORDOC_SEL") == 0 )
            {
               AV41TFCorDoc_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFNUMDOC") == 0 )
            {
               AV42TFNumDoc = (long)(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."));
               AV43TFNumDoc_To = (long)(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCORSERIE") == 0 )
            {
               AV44TFCorSerie = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCORSERIE_SEL") == 0 )
            {
               AV45TFCorSerie_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCORFE_SEL") == 0 )
            {
               AV46TFCorFE_Sel = (short)(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCORFORMATO") == 0 )
            {
               AV47TFCorFormato = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCORFORMATO_SEL") == 0 )
            {
               AV48TFCorFormato_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV97GXV1 = (int)(AV97GXV1+1);
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

      protected void H240( bool bFoot ,
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
                  AV58PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV55DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV53AppName = "DVelop Software Solutions";
               AV59Phone = "+1 550 8923";
               AV57Mail = "info@mail.com";
               AV61Website = "http://www.web.com";
               AV50AddressLine1 = "French Boulevard 2859";
               AV51AddressLine2 = "Downtown";
               AV52AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV60Title = "";
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14CorDoc1 = "";
         AV63FilterCorDoc1ValueDescription = "";
         AV62FilterCorDocValueDescription = "";
         AV18FilterNumDocDescription = "";
         AV20CorSerie1 = "";
         AV21FilterCorSerieDescription = "";
         AV22CorSerie = "";
         AV24DynamicFiltersSelector2 = "";
         AV26CorDoc2 = "";
         AV64FilterCorDoc2ValueDescription = "";
         AV28CorSerie2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV32CorDoc3 = "";
         AV65FilterCorDoc3ValueDescription = "";
         AV34CorSerie3 = "";
         AV41TFCorDoc_Sel = "";
         AV40TFCorDoc = "";
         AV49TFNumDoc_To_Description = "";
         AV45TFCorSerie_Sel = "";
         AV44TFCorSerie = "";
         AV48TFCorFormato_Sel = "";
         AV47TFCorFormato = "";
         AV71Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = "";
         AV73Seguridad_numeraciondocumentoswwds_3_cordoc1 = "";
         AV75Seguridad_numeraciondocumentoswwds_5_corserie1 = "";
         AV77Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = "";
         AV79Seguridad_numeraciondocumentoswwds_9_cordoc2 = "";
         AV81Seguridad_numeraciondocumentoswwds_11_corserie2 = "";
         AV83Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = "";
         AV85Seguridad_numeraciondocumentoswwds_15_cordoc3 = "";
         AV87Seguridad_numeraciondocumentoswwds_17_corserie3 = "";
         AV88Seguridad_numeraciondocumentoswwds_18_tfcordoc = "";
         AV89Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = "";
         AV92Seguridad_numeraciondocumentoswwds_22_tfcorserie = "";
         AV93Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = "";
         AV95Seguridad_numeraciondocumentoswwds_25_tfcorformato = "";
         AV96Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = "";
         scmdbuf = "";
         lV75Seguridad_numeraciondocumentoswwds_5_corserie1 = "";
         lV81Seguridad_numeraciondocumentoswwds_11_corserie2 = "";
         lV87Seguridad_numeraciondocumentoswwds_17_corserie3 = "";
         lV88Seguridad_numeraciondocumentoswwds_18_tfcordoc = "";
         lV92Seguridad_numeraciondocumentoswwds_22_tfcorserie = "";
         lV95Seguridad_numeraciondocumentoswwds_25_tfcorformato = "";
         A339CorDoc = "";
         A340CorSerie = "";
         A757CorFormato = "";
         P00242_A757CorFormato = new string[] {""} ;
         P00242_A756CorFE = new short[1] ;
         P00242_A340CorSerie = new string[] {""} ;
         P00242_A1377NumDoc = new long[1] ;
         P00242_A339CorDoc = new string[] {""} ;
         AV36Session = context.GetSession();
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV58PageInfo = "";
         AV55DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV53AppName = "";
         AV59Phone = "";
         AV57Mail = "";
         AV61Website = "";
         AV50AddressLine1 = "";
         AV51AddressLine2 = "";
         AV52AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.numeraciondocumentoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00242_A757CorFormato, P00242_A756CorFE, P00242_A340CorSerie, P00242_A1377NumDoc, P00242_A339CorDoc
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
      private short AV25DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short AV46TFCorFE_Sel ;
      private short AV72Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ;
      private short AV78Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ;
      private short AV84Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ;
      private short AV94Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ;
      private short A756CorFE ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV97GXV1 ;
      private long AV17NumDoc1 ;
      private long AV19NumDoc ;
      private long AV27NumDoc2 ;
      private long AV33NumDoc3 ;
      private long AV42TFNumDoc ;
      private long AV43TFNumDoc_To ;
      private long AV74Seguridad_numeraciondocumentoswwds_4_numdoc1 ;
      private long AV80Seguridad_numeraciondocumentoswwds_10_numdoc2 ;
      private long AV86Seguridad_numeraciondocumentoswwds_16_numdoc3 ;
      private long AV90Seguridad_numeraciondocumentoswwds_20_tfnumdoc ;
      private long AV91Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ;
      private long A1377NumDoc ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV14CorDoc1 ;
      private string AV20CorSerie1 ;
      private string AV22CorSerie ;
      private string AV26CorDoc2 ;
      private string AV28CorSerie2 ;
      private string AV32CorDoc3 ;
      private string AV34CorSerie3 ;
      private string AV41TFCorDoc_Sel ;
      private string AV40TFCorDoc ;
      private string AV45TFCorSerie_Sel ;
      private string AV44TFCorSerie ;
      private string AV73Seguridad_numeraciondocumentoswwds_3_cordoc1 ;
      private string AV75Seguridad_numeraciondocumentoswwds_5_corserie1 ;
      private string AV79Seguridad_numeraciondocumentoswwds_9_cordoc2 ;
      private string AV81Seguridad_numeraciondocumentoswwds_11_corserie2 ;
      private string AV85Seguridad_numeraciondocumentoswwds_15_cordoc3 ;
      private string AV87Seguridad_numeraciondocumentoswwds_17_corserie3 ;
      private string AV88Seguridad_numeraciondocumentoswwds_18_tfcordoc ;
      private string AV89Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ;
      private string AV92Seguridad_numeraciondocumentoswwds_22_tfcorserie ;
      private string AV93Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ;
      private string scmdbuf ;
      private string lV75Seguridad_numeraciondocumentoswwds_5_corserie1 ;
      private string lV81Seguridad_numeraciondocumentoswwds_11_corserie2 ;
      private string lV87Seguridad_numeraciondocumentoswwds_17_corserie3 ;
      private string lV88Seguridad_numeraciondocumentoswwds_18_tfcordoc ;
      private string lV92Seguridad_numeraciondocumentoswwds_22_tfcorserie ;
      private string A339CorDoc ;
      private string A340CorSerie ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV76Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ;
      private bool AV82Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV60Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV63FilterCorDoc1ValueDescription ;
      private string AV62FilterCorDocValueDescription ;
      private string AV18FilterNumDocDescription ;
      private string AV21FilterCorSerieDescription ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV64FilterCorDoc2ValueDescription ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV65FilterCorDoc3ValueDescription ;
      private string AV49TFNumDoc_To_Description ;
      private string AV48TFCorFormato_Sel ;
      private string AV47TFCorFormato ;
      private string AV71Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ;
      private string AV77Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ;
      private string AV83Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ;
      private string AV95Seguridad_numeraciondocumentoswwds_25_tfcorformato ;
      private string AV96Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ;
      private string lV95Seguridad_numeraciondocumentoswwds_25_tfcorformato ;
      private string A757CorFormato ;
      private string AV58PageInfo ;
      private string AV55DateInfo ;
      private string AV53AppName ;
      private string AV59Phone ;
      private string AV57Mail ;
      private string AV61Website ;
      private string AV50AddressLine1 ;
      private string AV51AddressLine2 ;
      private string AV52AddressLine3 ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00242_A757CorFormato ;
      private short[] P00242_A756CorFE ;
      private string[] P00242_A340CorSerie ;
      private long[] P00242_A1377NumDoc ;
      private string[] P00242_A339CorDoc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV35GridStateDynamicFilter ;
   }

   public class numeraciondocumentoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00242( IGxContext context ,
                                             string AV71Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ,
                                             string AV73Seguridad_numeraciondocumentoswwds_3_cordoc1 ,
                                             short AV72Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ,
                                             long AV74Seguridad_numeraciondocumentoswwds_4_numdoc1 ,
                                             string AV75Seguridad_numeraciondocumentoswwds_5_corserie1 ,
                                             bool AV76Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ,
                                             string AV77Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ,
                                             string AV79Seguridad_numeraciondocumentoswwds_9_cordoc2 ,
                                             short AV78Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ,
                                             long AV80Seguridad_numeraciondocumentoswwds_10_numdoc2 ,
                                             string AV81Seguridad_numeraciondocumentoswwds_11_corserie2 ,
                                             bool AV82Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ,
                                             string AV83Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ,
                                             string AV85Seguridad_numeraciondocumentoswwds_15_cordoc3 ,
                                             short AV84Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ,
                                             long AV86Seguridad_numeraciondocumentoswwds_16_numdoc3 ,
                                             string AV87Seguridad_numeraciondocumentoswwds_17_corserie3 ,
                                             string AV89Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ,
                                             string AV88Seguridad_numeraciondocumentoswwds_18_tfcordoc ,
                                             long AV90Seguridad_numeraciondocumentoswwds_20_tfnumdoc ,
                                             long AV91Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ,
                                             string AV93Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ,
                                             string AV92Seguridad_numeraciondocumentoswwds_22_tfcorserie ,
                                             short AV94Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ,
                                             string AV96Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ,
                                             string AV95Seguridad_numeraciondocumentoswwds_25_tfcorformato ,
                                             string A339CorDoc ,
                                             long A1377NumDoc ,
                                             string A340CorSerie ,
                                             short A756CorFE ,
                                             string A757CorFormato ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[26];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [CorFormato], [CorFE], [CorSerie], [NumDoc], [CorDoc] FROM [SGCDOCUMENTOS]";
         if ( ( StringUtil.StrCmp(AV71Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_numeraciondocumentoswwds_3_cordoc1)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV73Seguridad_numeraciondocumentoswwds_3_cordoc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV72Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV74Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV74Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV72Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV74Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV74Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV72Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV74Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV74Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORSERIE") == 0 ) && ( AV72Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_numeraciondocumentoswwds_5_corserie1)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV75Seguridad_numeraciondocumentoswwds_5_corserie1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORSERIE") == 0 ) && ( AV72Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_numeraciondocumentoswwds_5_corserie1)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV75Seguridad_numeraciondocumentoswwds_5_corserie1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV76Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_numeraciondocumentoswwds_9_cordoc2)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV79Seguridad_numeraciondocumentoswwds_9_cordoc2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV76Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV78Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV80Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV80Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV76Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV78Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV80Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV80Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV76Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV78Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV80Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV80Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV76Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORSERIE") == 0 ) && ( AV78Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_numeraciondocumentoswwds_11_corserie2)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV81Seguridad_numeraciondocumentoswwds_11_corserie2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV76Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORSERIE") == 0 ) && ( AV78Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_numeraciondocumentoswwds_11_corserie2)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV81Seguridad_numeraciondocumentoswwds_11_corserie2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV82Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Seguridad_numeraciondocumentoswwds_15_cordoc3)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV85Seguridad_numeraciondocumentoswwds_15_cordoc3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV82Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV84Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV86Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV86Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV82Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV84Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV86Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV86Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV82Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV84Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV86Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV86Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV82Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORSERIE") == 0 ) && ( AV84Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Seguridad_numeraciondocumentoswwds_17_corserie3)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV87Seguridad_numeraciondocumentoswwds_17_corserie3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV82Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORSERIE") == 0 ) && ( AV84Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Seguridad_numeraciondocumentoswwds_17_corserie3)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV87Seguridad_numeraciondocumentoswwds_17_corserie3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_numeraciondocumentoswwds_18_tfcordoc)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] like @lV88Seguridad_numeraciondocumentoswwds_18_tfcordoc)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV89Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! (0==AV90Seguridad_numeraciondocumentoswwds_20_tfnumdoc) )
         {
            AddWhere(sWhereString, "([NumDoc] >= @AV90Seguridad_numeraciondocumentoswwds_20_tfnumdoc)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! (0==AV91Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to) )
         {
            AddWhere(sWhereString, "([NumDoc] <= @AV91Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_numeraciondocumentoswwds_22_tfcorserie)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV92Seguridad_numeraciondocumentoswwds_22_tfcorserie)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)) )
         {
            AddWhere(sWhereString, "([CorSerie] = @AV93Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( AV94Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel == 1 )
         {
            AddWhere(sWhereString, "([CorFE] = 1)");
         }
         if ( AV94Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel == 2 )
         {
            AddWhere(sWhereString, "([CorFE] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Seguridad_numeraciondocumentoswwds_25_tfcorformato)) ) )
         {
            AddWhere(sWhereString, "([CorFormato] like @lV95Seguridad_numeraciondocumentoswwds_25_tfcorformato)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)) )
         {
            AddWhere(sWhereString, "([CorFormato] = @AV96Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [CorDoc], [NumDoc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CorDoc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CorDoc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [NumDoc]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [NumDoc] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CorSerie]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CorSerie] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CorFE]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CorFE] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CorFormato]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CorFormato] DESC";
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
                     return conditional_P00242(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (bool)dynConstraints[32] );
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
          Object[] prmP00242;
          prmP00242 = new Object[] {
          new ParDef("@AV73Seguridad_numeraciondocumentoswwds_3_cordoc1",GXType.NChar,10,0) ,
          new ParDef("@AV74Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@AV74Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@AV74Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@lV75Seguridad_numeraciondocumentoswwds_5_corserie1",GXType.NChar,4,0) ,
          new ParDef("@lV75Seguridad_numeraciondocumentoswwds_5_corserie1",GXType.NChar,4,0) ,
          new ParDef("@AV79Seguridad_numeraciondocumentoswwds_9_cordoc2",GXType.NChar,10,0) ,
          new ParDef("@AV80Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@AV80Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@AV80Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@lV81Seguridad_numeraciondocumentoswwds_11_corserie2",GXType.NChar,4,0) ,
          new ParDef("@lV81Seguridad_numeraciondocumentoswwds_11_corserie2",GXType.NChar,4,0) ,
          new ParDef("@AV85Seguridad_numeraciondocumentoswwds_15_cordoc3",GXType.NChar,10,0) ,
          new ParDef("@AV86Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@AV86Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@AV86Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@lV87Seguridad_numeraciondocumentoswwds_17_corserie3",GXType.NChar,4,0) ,
          new ParDef("@lV87Seguridad_numeraciondocumentoswwds_17_corserie3",GXType.NChar,4,0) ,
          new ParDef("@lV88Seguridad_numeraciondocumentoswwds_18_tfcordoc",GXType.NChar,10,0) ,
          new ParDef("@AV89Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel",GXType.NChar,10,0) ,
          new ParDef("@AV90Seguridad_numeraciondocumentoswwds_20_tfnumdoc",GXType.Decimal,10,0) ,
          new ParDef("@AV91Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to",GXType.Decimal,10,0) ,
          new ParDef("@lV92Seguridad_numeraciondocumentoswwds_22_tfcorserie",GXType.NChar,4,0) ,
          new ParDef("@AV93Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel",GXType.NChar,4,0) ,
          new ParDef("@lV95Seguridad_numeraciondocumentoswwds_25_tfcorformato",GXType.NVarChar,50,0) ,
          new ParDef("@AV96Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel",GXType.NVarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00242", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00242,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                return;
       }
    }

 }

}
