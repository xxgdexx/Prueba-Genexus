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
using GeneXus.XML;
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.seguridad {
   public class numeraciondocumentoswwexport : GXProcedure
   {
      public numeraciondocumentoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public numeraciondocumentoswwexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV11Filename = "" ;
         this.AV12ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV12ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         numeraciondocumentoswwexport objnumeraciondocumentoswwexport;
         objnumeraciondocumentoswwexport = new numeraciondocumentoswwexport();
         objnumeraciondocumentoswwexport.AV11Filename = "" ;
         objnumeraciondocumentoswwexport.AV12ErrorMessage = "" ;
         objnumeraciondocumentoswwexport.context.SetSubmitInitialConfig(context);
         objnumeraciondocumentoswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objnumeraciondocumentoswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((numeraciondocumentoswwexport)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13CellRow = 1;
         AV14FirstColumn = 1;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S191 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFILTERS' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S151 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S181 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV15Random = (int)(NumberUtil.Random( )*10000);
         AV11Filename = "NumeracionDocumentosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
         AV10ExcelDocument.Open(AV11Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CORDOC") == 0 )
            {
               AV20CorDoc1 = AV35GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20CorDoc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo Documento";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV20CorDoc1), "FACTURA") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "FACTURA";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV20CorDoc1), "NOTCREDITO") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "NOTA DE CREDITO";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV20CorDoc1), "NOTDEBITO") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "NOTA DE DEBITO";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV20CorDoc1), "BOLETA") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "BOLETA";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV20CorDoc1), "REMISION") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "REMISION";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV20CorDoc1), "LETRA") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "LETRA DE CAMBIO";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV20CorDoc1), "PERCEPCION") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "PERCEPCION";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV20CorDoc1), "RECIBO") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "RECIBO";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV20CorDoc1), "ENTRADA") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "ENTRADA";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV20CorDoc1), "SALIDA") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "SALIDA";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV20CorDoc1), "ORDENCOMPR") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "ORDEN DE COMPRA";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV20CorDoc1), "RETENCION") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "RETENCION";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV20CorDoc1), "TICKET") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "TICKET";
                  }
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "NUMDOC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV21NumDoc1 = (long)(NumberUtil.Val( AV35GridStateDynamicFilter.gxTpr_Value, "."));
               if ( ! (0==AV21NumDoc1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Documento", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Documento", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Documento", ">", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV21NumDoc1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CORSERIE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV22CorSerie1 = AV35GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CorSerie1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Serie", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Serie", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22CorSerie1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
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
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo Documento";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "FACTURA") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "FACTURA";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "NOTCREDITO") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "NOTA DE CREDITO";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "NOTDEBITO") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "NOTA DE DEBITO";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "BOLETA") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "BOLETA";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "REMISION") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "REMISION";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "LETRA") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "LETRA DE CAMBIO";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "PERCEPCION") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "PERCEPCION";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "RECIBO") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "RECIBO";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "ENTRADA") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "ENTRADA";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "SALIDA") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "SALIDA";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "ORDENCOMPR") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "ORDEN DE COMPRA";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "RETENCION") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "RETENCION";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV26CorDoc2), "TICKET") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "TICKET";
                     }
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "NUMDOC") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV27NumDoc2 = (long)(NumberUtil.Val( AV35GridStateDynamicFilter.gxTpr_Value, "."));
                  if ( ! (0==AV27NumDoc2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Documento", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Documento", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Documento", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV27NumDoc2;
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CORSERIE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV28CorSerie2 = AV35GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28CorSerie2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Serie", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Serie", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28CorSerie2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
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
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo Documento";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "FACTURA") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "FACTURA";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "NOTCREDITO") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "NOTA DE CREDITO";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "NOTDEBITO") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "NOTA DE DEBITO";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "BOLETA") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "BOLETA";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "REMISION") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "REMISION";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "LETRA") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "LETRA DE CAMBIO";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "PERCEPCION") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "PERCEPCION";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "RECIBO") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "RECIBO";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "ENTRADA") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "ENTRADA";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "SALIDA") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "SALIDA";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "ORDENCOMPR") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "ORDEN DE COMPRA";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "RETENCION") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "RETENCION";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV32CorDoc3), "TICKET") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "TICKET";
                        }
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "NUMDOC") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV33NumDoc3 = (long)(NumberUtil.Val( AV35GridStateDynamicFilter.gxTpr_Value, "."));
                     if ( ! (0==AV33NumDoc3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Documento", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Documento", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Documento", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV33NumDoc3;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CORSERIE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV34CorSerie3 = AV35GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34CorSerie3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Serie", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Serie", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34CorSerie3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFCorDoc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Documento") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFCorDoc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCorDoc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Documento") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFCorDoc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV42TFNumDoc) && (0==AV43TFNumDoc_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "N° Documento") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV42TFNumDoc;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV43TFNumDoc_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCorSerie_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Serie") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45TFCorSerie_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCorSerie)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Serie") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFCorSerie, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV46TFCorFE_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Electronica") ;
            AV13CellRow = GXt_int2;
            if ( AV46TFCorFE_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV46TFCorFE_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCorFormato_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Formato") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48TFCorFormato_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCorFormato)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Formato") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFCorFormato, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Documento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "N° Documento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Serie";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Electronica";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Formato";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV52Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV53Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV54Seguridad_numeraciondocumentoswwds_3_cordoc1 = AV20CorDoc1;
         AV55Seguridad_numeraciondocumentoswwds_4_numdoc1 = AV21NumDoc1;
         AV56Seguridad_numeraciondocumentoswwds_5_corserie1 = AV22CorSerie1;
         AV57Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV58Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV59Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV60Seguridad_numeraciondocumentoswwds_9_cordoc2 = AV26CorDoc2;
         AV61Seguridad_numeraciondocumentoswwds_10_numdoc2 = AV27NumDoc2;
         AV62Seguridad_numeraciondocumentoswwds_11_corserie2 = AV28CorSerie2;
         AV63Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV64Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV65Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV66Seguridad_numeraciondocumentoswwds_15_cordoc3 = AV32CorDoc3;
         AV67Seguridad_numeraciondocumentoswwds_16_numdoc3 = AV33NumDoc3;
         AV68Seguridad_numeraciondocumentoswwds_17_corserie3 = AV34CorSerie3;
         AV69Seguridad_numeraciondocumentoswwds_18_tfcordoc = AV40TFCorDoc;
         AV70Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = AV41TFCorDoc_Sel;
         AV71Seguridad_numeraciondocumentoswwds_20_tfnumdoc = AV42TFNumDoc;
         AV72Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to = AV43TFNumDoc_To;
         AV73Seguridad_numeraciondocumentoswwds_22_tfcorserie = AV44TFCorSerie;
         AV74Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = AV45TFCorSerie_Sel;
         AV75Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel = AV46TFCorFE_Sel;
         AV76Seguridad_numeraciondocumentoswwds_25_tfcorformato = AV47TFCorFormato;
         AV77Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = AV48TFCorFormato_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV52Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ,
                                              AV54Seguridad_numeraciondocumentoswwds_3_cordoc1 ,
                                              AV53Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ,
                                              AV55Seguridad_numeraciondocumentoswwds_4_numdoc1 ,
                                              AV56Seguridad_numeraciondocumentoswwds_5_corserie1 ,
                                              AV57Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ,
                                              AV58Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ,
                                              AV60Seguridad_numeraciondocumentoswwds_9_cordoc2 ,
                                              AV59Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ,
                                              AV61Seguridad_numeraciondocumentoswwds_10_numdoc2 ,
                                              AV62Seguridad_numeraciondocumentoswwds_11_corserie2 ,
                                              AV63Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ,
                                              AV64Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ,
                                              AV66Seguridad_numeraciondocumentoswwds_15_cordoc3 ,
                                              AV65Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ,
                                              AV67Seguridad_numeraciondocumentoswwds_16_numdoc3 ,
                                              AV68Seguridad_numeraciondocumentoswwds_17_corserie3 ,
                                              AV70Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ,
                                              AV69Seguridad_numeraciondocumentoswwds_18_tfcordoc ,
                                              AV71Seguridad_numeraciondocumentoswwds_20_tfnumdoc ,
                                              AV72Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ,
                                              AV74Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ,
                                              AV73Seguridad_numeraciondocumentoswwds_22_tfcorserie ,
                                              AV75Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ,
                                              AV77Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ,
                                              AV76Seguridad_numeraciondocumentoswwds_25_tfcorformato ,
                                              A339CorDoc ,
                                              A1377NumDoc ,
                                              A340CorSerie ,
                                              A756CorFE ,
                                              A757CorFormato ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV56Seguridad_numeraciondocumentoswwds_5_corserie1 = StringUtil.PadR( StringUtil.RTrim( AV56Seguridad_numeraciondocumentoswwds_5_corserie1), 4, "%");
         lV56Seguridad_numeraciondocumentoswwds_5_corserie1 = StringUtil.PadR( StringUtil.RTrim( AV56Seguridad_numeraciondocumentoswwds_5_corserie1), 4, "%");
         lV62Seguridad_numeraciondocumentoswwds_11_corserie2 = StringUtil.PadR( StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_11_corserie2), 4, "%");
         lV62Seguridad_numeraciondocumentoswwds_11_corserie2 = StringUtil.PadR( StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_11_corserie2), 4, "%");
         lV68Seguridad_numeraciondocumentoswwds_17_corserie3 = StringUtil.PadR( StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_17_corserie3), 4, "%");
         lV68Seguridad_numeraciondocumentoswwds_17_corserie3 = StringUtil.PadR( StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_17_corserie3), 4, "%");
         lV69Seguridad_numeraciondocumentoswwds_18_tfcordoc = StringUtil.PadR( StringUtil.RTrim( AV69Seguridad_numeraciondocumentoswwds_18_tfcordoc), 10, "%");
         lV73Seguridad_numeraciondocumentoswwds_22_tfcorserie = StringUtil.PadR( StringUtil.RTrim( AV73Seguridad_numeraciondocumentoswwds_22_tfcorserie), 4, "%");
         lV76Seguridad_numeraciondocumentoswwds_25_tfcorformato = StringUtil.Concat( StringUtil.RTrim( AV76Seguridad_numeraciondocumentoswwds_25_tfcorformato), "%", "");
         /* Using cursor P00232 */
         pr_default.execute(0, new Object[] {AV54Seguridad_numeraciondocumentoswwds_3_cordoc1, AV55Seguridad_numeraciondocumentoswwds_4_numdoc1, AV55Seguridad_numeraciondocumentoswwds_4_numdoc1, AV55Seguridad_numeraciondocumentoswwds_4_numdoc1, lV56Seguridad_numeraciondocumentoswwds_5_corserie1, lV56Seguridad_numeraciondocumentoswwds_5_corserie1, AV60Seguridad_numeraciondocumentoswwds_9_cordoc2, AV61Seguridad_numeraciondocumentoswwds_10_numdoc2, AV61Seguridad_numeraciondocumentoswwds_10_numdoc2, AV61Seguridad_numeraciondocumentoswwds_10_numdoc2, lV62Seguridad_numeraciondocumentoswwds_11_corserie2, lV62Seguridad_numeraciondocumentoswwds_11_corserie2, AV66Seguridad_numeraciondocumentoswwds_15_cordoc3, AV67Seguridad_numeraciondocumentoswwds_16_numdoc3, AV67Seguridad_numeraciondocumentoswwds_16_numdoc3, AV67Seguridad_numeraciondocumentoswwds_16_numdoc3, lV68Seguridad_numeraciondocumentoswwds_17_corserie3, lV68Seguridad_numeraciondocumentoswwds_17_corserie3, lV69Seguridad_numeraciondocumentoswwds_18_tfcordoc, AV70Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel, AV71Seguridad_numeraciondocumentoswwds_20_tfnumdoc, AV72Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to, lV73Seguridad_numeraciondocumentoswwds_22_tfcorserie, AV74Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel, lV76Seguridad_numeraciondocumentoswwds_25_tfcorformato, AV77Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A757CorFormato = P00232_A757CorFormato[0];
            A756CorFE = P00232_A756CorFE[0];
            A340CorSerie = P00232_A340CorSerie[0];
            A1377NumDoc = P00232_A1377NumDoc[0];
            A339CorDoc = P00232_A339CorDoc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A339CorDoc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = A1377NumDoc;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A340CorSerie, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = A756CorFE;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A757CorFormato, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char1;
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S172 ();
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

      protected void S181( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV10ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Close();
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV10ExcelDocument.ErrCode != 0 )
         {
            AV11Filename = "";
            AV12ErrorMessage = AV10ExcelDocument.ErrDescription;
            AV10ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S191( )
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
         AV16OrderedBy = AV38GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV38GridState.gxTpr_Ordereddsc;
         AV78GXV1 = 1;
         while ( AV78GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV78GXV1));
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
            AV78GXV1 = (int)(AV78GXV1+1);
         }
      }

      protected void S162( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S172( )
      {
         /* 'AFTERWRITELINE' Routine */
         returnInSub = false;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
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
         AV11Filename = "";
         AV12ErrorMessage = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10ExcelDocument = new ExcelDocumentI();
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV20CorDoc1 = "";
         AV22CorSerie1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26CorDoc2 = "";
         AV28CorSerie2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV32CorDoc3 = "";
         AV34CorSerie3 = "";
         AV41TFCorDoc_Sel = "";
         AV40TFCorDoc = "";
         AV45TFCorSerie_Sel = "";
         AV44TFCorSerie = "";
         AV48TFCorFormato_Sel = "";
         AV47TFCorFormato = "";
         AV52Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = "";
         AV54Seguridad_numeraciondocumentoswwds_3_cordoc1 = "";
         AV56Seguridad_numeraciondocumentoswwds_5_corserie1 = "";
         AV58Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = "";
         AV60Seguridad_numeraciondocumentoswwds_9_cordoc2 = "";
         AV62Seguridad_numeraciondocumentoswwds_11_corserie2 = "";
         AV64Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = "";
         AV66Seguridad_numeraciondocumentoswwds_15_cordoc3 = "";
         AV68Seguridad_numeraciondocumentoswwds_17_corserie3 = "";
         AV69Seguridad_numeraciondocumentoswwds_18_tfcordoc = "";
         AV70Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = "";
         AV73Seguridad_numeraciondocumentoswwds_22_tfcorserie = "";
         AV74Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = "";
         AV76Seguridad_numeraciondocumentoswwds_25_tfcorformato = "";
         AV77Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = "";
         scmdbuf = "";
         lV56Seguridad_numeraciondocumentoswwds_5_corserie1 = "";
         lV62Seguridad_numeraciondocumentoswwds_11_corserie2 = "";
         lV68Seguridad_numeraciondocumentoswwds_17_corserie3 = "";
         lV69Seguridad_numeraciondocumentoswwds_18_tfcordoc = "";
         lV73Seguridad_numeraciondocumentoswwds_22_tfcorserie = "";
         lV76Seguridad_numeraciondocumentoswwds_25_tfcorformato = "";
         A339CorDoc = "";
         A340CorSerie = "";
         A757CorFormato = "";
         P00232_A757CorFormato = new string[] {""} ;
         P00232_A756CorFE = new short[1] ;
         P00232_A340CorSerie = new string[] {""} ;
         P00232_A1377NumDoc = new long[1] ;
         P00232_A339CorDoc = new string[] {""} ;
         GXt_char1 = "";
         AV36Session = context.GetSession();
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.numeraciondocumentoswwexport__default(),
            new Object[][] {
                new Object[] {
               P00232_A757CorFormato, P00232_A756CorFE, P00232_A340CorSerie, P00232_A1377NumDoc, P00232_A339CorDoc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short AV46TFCorFE_Sel ;
      private short GXt_int2 ;
      private short AV53Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ;
      private short AV59Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ;
      private short AV65Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ;
      private short AV75Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ;
      private short A756CorFE ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV78GXV1 ;
      private long AV21NumDoc1 ;
      private long AV27NumDoc2 ;
      private long AV33NumDoc3 ;
      private long AV42TFNumDoc ;
      private long AV43TFNumDoc_To ;
      private long AV55Seguridad_numeraciondocumentoswwds_4_numdoc1 ;
      private long AV61Seguridad_numeraciondocumentoswwds_10_numdoc2 ;
      private long AV67Seguridad_numeraciondocumentoswwds_16_numdoc3 ;
      private long AV71Seguridad_numeraciondocumentoswwds_20_tfnumdoc ;
      private long AV72Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ;
      private long A1377NumDoc ;
      private string AV20CorDoc1 ;
      private string AV22CorSerie1 ;
      private string AV26CorDoc2 ;
      private string AV28CorSerie2 ;
      private string AV32CorDoc3 ;
      private string AV34CorSerie3 ;
      private string AV41TFCorDoc_Sel ;
      private string AV40TFCorDoc ;
      private string AV45TFCorSerie_Sel ;
      private string AV44TFCorSerie ;
      private string AV54Seguridad_numeraciondocumentoswwds_3_cordoc1 ;
      private string AV56Seguridad_numeraciondocumentoswwds_5_corserie1 ;
      private string AV60Seguridad_numeraciondocumentoswwds_9_cordoc2 ;
      private string AV62Seguridad_numeraciondocumentoswwds_11_corserie2 ;
      private string AV66Seguridad_numeraciondocumentoswwds_15_cordoc3 ;
      private string AV68Seguridad_numeraciondocumentoswwds_17_corserie3 ;
      private string AV69Seguridad_numeraciondocumentoswwds_18_tfcordoc ;
      private string AV70Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ;
      private string AV73Seguridad_numeraciondocumentoswwds_22_tfcorserie ;
      private string AV74Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ;
      private string scmdbuf ;
      private string lV56Seguridad_numeraciondocumentoswwds_5_corserie1 ;
      private string lV62Seguridad_numeraciondocumentoswwds_11_corserie2 ;
      private string lV68Seguridad_numeraciondocumentoswwds_17_corserie3 ;
      private string lV69Seguridad_numeraciondocumentoswwds_18_tfcordoc ;
      private string lV73Seguridad_numeraciondocumentoswwds_22_tfcorserie ;
      private string A339CorDoc ;
      private string A340CorSerie ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV57Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ;
      private bool AV63Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV48TFCorFormato_Sel ;
      private string AV47TFCorFormato ;
      private string AV52Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ;
      private string AV58Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ;
      private string AV64Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ;
      private string AV76Seguridad_numeraciondocumentoswwds_25_tfcorformato ;
      private string AV77Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ;
      private string lV76Seguridad_numeraciondocumentoswwds_25_tfcorformato ;
      private string A757CorFormato ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00232_A757CorFormato ;
      private short[] P00232_A756CorFE ;
      private string[] P00232_A340CorSerie ;
      private long[] P00232_A1377NumDoc ;
      private string[] P00232_A339CorDoc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV35GridStateDynamicFilter ;
   }

   public class numeraciondocumentoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00232( IGxContext context ,
                                             string AV52Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ,
                                             string AV54Seguridad_numeraciondocumentoswwds_3_cordoc1 ,
                                             short AV53Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ,
                                             long AV55Seguridad_numeraciondocumentoswwds_4_numdoc1 ,
                                             string AV56Seguridad_numeraciondocumentoswwds_5_corserie1 ,
                                             bool AV57Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ,
                                             string AV58Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ,
                                             string AV60Seguridad_numeraciondocumentoswwds_9_cordoc2 ,
                                             short AV59Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ,
                                             long AV61Seguridad_numeraciondocumentoswwds_10_numdoc2 ,
                                             string AV62Seguridad_numeraciondocumentoswwds_11_corserie2 ,
                                             bool AV63Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ,
                                             string AV64Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ,
                                             string AV66Seguridad_numeraciondocumentoswwds_15_cordoc3 ,
                                             short AV65Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ,
                                             long AV67Seguridad_numeraciondocumentoswwds_16_numdoc3 ,
                                             string AV68Seguridad_numeraciondocumentoswwds_17_corserie3 ,
                                             string AV70Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ,
                                             string AV69Seguridad_numeraciondocumentoswwds_18_tfcordoc ,
                                             long AV71Seguridad_numeraciondocumentoswwds_20_tfnumdoc ,
                                             long AV72Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ,
                                             string AV74Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ,
                                             string AV73Seguridad_numeraciondocumentoswwds_22_tfcorserie ,
                                             short AV75Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ,
                                             string AV77Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ,
                                             string AV76Seguridad_numeraciondocumentoswwds_25_tfcorformato ,
                                             string A339CorDoc ,
                                             long A1377NumDoc ,
                                             string A340CorSerie ,
                                             short A756CorFE ,
                                             string A757CorFormato ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[26];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [CorFormato], [CorFE], [CorSerie], [NumDoc], [CorDoc] FROM [SGCDOCUMENTOS]";
         if ( ( StringUtil.StrCmp(AV52Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Seguridad_numeraciondocumentoswwds_3_cordoc1)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV54Seguridad_numeraciondocumentoswwds_3_cordoc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV53Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV55Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV55Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV53Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV55Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV55Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV53Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV55Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV55Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORSERIE") == 0 ) && ( AV53Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Seguridad_numeraciondocumentoswwds_5_corserie1)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV56Seguridad_numeraciondocumentoswwds_5_corserie1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORSERIE") == 0 ) && ( AV53Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Seguridad_numeraciondocumentoswwds_5_corserie1)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV56Seguridad_numeraciondocumentoswwds_5_corserie1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV57Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Seguridad_numeraciondocumentoswwds_9_cordoc2)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV60Seguridad_numeraciondocumentoswwds_9_cordoc2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV57Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV61Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV61Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV57Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV61Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV61Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV57Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV61Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV61Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV57Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORSERIE") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_11_corserie2)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV62Seguridad_numeraciondocumentoswwds_11_corserie2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV57Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORSERIE") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_11_corserie2)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV62Seguridad_numeraciondocumentoswwds_11_corserie2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Seguridad_numeraciondocumentoswwds_15_cordoc3)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV66Seguridad_numeraciondocumentoswwds_15_cordoc3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV67Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV67Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV67Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV67Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV67Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV67Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORSERIE") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_17_corserie3)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV68Seguridad_numeraciondocumentoswwds_17_corserie3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORSERIE") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_17_corserie3)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV68Seguridad_numeraciondocumentoswwds_17_corserie3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Seguridad_numeraciondocumentoswwds_18_tfcordoc)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] like @lV69Seguridad_numeraciondocumentoswwds_18_tfcordoc)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV70Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! (0==AV71Seguridad_numeraciondocumentoswwds_20_tfnumdoc) )
         {
            AddWhere(sWhereString, "([NumDoc] >= @AV71Seguridad_numeraciondocumentoswwds_20_tfnumdoc)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! (0==AV72Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to) )
         {
            AddWhere(sWhereString, "([NumDoc] <= @AV72Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_numeraciondocumentoswwds_22_tfcorserie)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV73Seguridad_numeraciondocumentoswwds_22_tfcorserie)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)) )
         {
            AddWhere(sWhereString, "([CorSerie] = @AV74Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV75Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel == 1 )
         {
            AddWhere(sWhereString, "([CorFE] = 1)");
         }
         if ( AV75Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel == 2 )
         {
            AddWhere(sWhereString, "([CorFE] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Seguridad_numeraciondocumentoswwds_25_tfcorformato)) ) )
         {
            AddWhere(sWhereString, "([CorFormato] like @lV76Seguridad_numeraciondocumentoswwds_25_tfcorformato)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)) )
         {
            AddWhere(sWhereString, "([CorFormato] = @AV77Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [CorDoc], [NumDoc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CorDoc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CorDoc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [NumDoc]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [NumDoc] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CorSerie]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CorSerie] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CorFE]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CorFE] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CorFormato]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CorFormato] DESC";
         }
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00232(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (bool)dynConstraints[32] );
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
          Object[] prmP00232;
          prmP00232 = new Object[] {
          new ParDef("@AV54Seguridad_numeraciondocumentoswwds_3_cordoc1",GXType.NChar,10,0) ,
          new ParDef("@AV55Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@AV55Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@AV55Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@lV56Seguridad_numeraciondocumentoswwds_5_corserie1",GXType.NChar,4,0) ,
          new ParDef("@lV56Seguridad_numeraciondocumentoswwds_5_corserie1",GXType.NChar,4,0) ,
          new ParDef("@AV60Seguridad_numeraciondocumentoswwds_9_cordoc2",GXType.NChar,10,0) ,
          new ParDef("@AV61Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@AV61Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@AV61Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@lV62Seguridad_numeraciondocumentoswwds_11_corserie2",GXType.NChar,4,0) ,
          new ParDef("@lV62Seguridad_numeraciondocumentoswwds_11_corserie2",GXType.NChar,4,0) ,
          new ParDef("@AV66Seguridad_numeraciondocumentoswwds_15_cordoc3",GXType.NChar,10,0) ,
          new ParDef("@AV67Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@AV67Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@AV67Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@lV68Seguridad_numeraciondocumentoswwds_17_corserie3",GXType.NChar,4,0) ,
          new ParDef("@lV68Seguridad_numeraciondocumentoswwds_17_corserie3",GXType.NChar,4,0) ,
          new ParDef("@lV69Seguridad_numeraciondocumentoswwds_18_tfcordoc",GXType.NChar,10,0) ,
          new ParDef("@AV70Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel",GXType.NChar,10,0) ,
          new ParDef("@AV71Seguridad_numeraciondocumentoswwds_20_tfnumdoc",GXType.Decimal,10,0) ,
          new ParDef("@AV72Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to",GXType.Decimal,10,0) ,
          new ParDef("@lV73Seguridad_numeraciondocumentoswwds_22_tfcorserie",GXType.NChar,4,0) ,
          new ParDef("@AV74Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel",GXType.NChar,4,0) ,
          new ParDef("@lV76Seguridad_numeraciondocumentoswwds_25_tfcorformato",GXType.NVarChar,50,0) ,
          new ParDef("@AV77Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel",GXType.NVarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00232", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00232,100, GxCacheFrequency.OFF ,true,false )
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
