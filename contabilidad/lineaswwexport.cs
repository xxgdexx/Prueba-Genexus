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
namespace GeneXus.Programs.contabilidad {
   public class lineaswwexport : GXProcedure
   {
      public lineaswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public lineaswwexport( IGxContext context )
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
         lineaswwexport objlineaswwexport;
         objlineaswwexport = new lineaswwexport();
         objlineaswwexport.AV11Filename = "" ;
         objlineaswwexport.AV12ErrorMessage = "" ;
         objlineaswwexport.context.SetSubmitInitialConfig(context);
         objlineaswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlineaswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((lineaswwexport)stateInfo).executePrivate();
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
         AV11Filename = "LineasWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV29GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TOTTIPO") == 0 )
            {
               AV53TotTipo1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53TotTipo1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Reporte";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV53TotTipo1), "BAL") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Situación Financiera";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV53TotTipo1), "FUN") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Resultados Integrales";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV53TotTipo1), "NAT") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Ganancia y Perdidad";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV53TotTipo1), "COS") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Registro de Costos";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV53TotTipo1), "RCC") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Registro de Costos / Centro de Costos";
                  }
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TOTTIPO") == 0 )
               {
                  AV54TotTipo2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54TotTipo2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Reporte";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( AV54TotTipo2), "BAL") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Situación Financiera";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV54TotTipo2), "FUN") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Resultados Integrales";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV54TotTipo2), "NAT") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Ganancia y Perdidad";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV54TotTipo2), "COS") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Registro de Costos";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV54TotTipo2), "RCC") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Registro de Costos / Centro de Costos";
                     }
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TOTTIPO") == 0 )
                  {
                     AV55TotTipo3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TotTipo3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Reporte";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV55TotTipo3), "BAL") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Situación Financiera";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV55TotTipo3), "FUN") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Resultados Integrales";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV55TotTipo3), "NAT") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Ganancia y Perdidad";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV55TotTipo3), "COS") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Registro de Costos";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV55TotTipo3), "RCC") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Registro de Costos / Centro de Costos";
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( ( AV35TFTotTipo_Sels.Count == 0 ) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Tipo de Reporte") ;
            AV13CellRow = GXt_int1;
            AV52i = 1;
            AV58GXV1 = 1;
            while ( AV58GXV1 <= AV35TFTotTipo_Sels.Count )
            {
               AV36TFTotTipo_Sel = AV35TFTotTipo_Sels.GetString(AV58GXV1);
               if ( AV52i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV36TFTotTipo_Sel), "BAL") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Estado de Situación Financiera";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV36TFTotTipo_Sel), "FUN") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Estado de Resultados Integrales";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV36TFTotTipo_Sel), "NAT") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Estado de Ganancia y Perdidad";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV36TFTotTipo_Sel), "COS") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Registro de Costos";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV36TFTotTipo_Sel), "RCC") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Registro de Costos / Centro de Costos";
               }
               AV52i = (long)(AV52i+1);
               AV58GXV1 = (int)(AV58GXV1+1);
            }
         }
         if ( ! ( (0==AV37TFTotRub) && (0==AV38TFTotRub_To) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Codigo Rubro Totales") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV37TFTotRub;
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV38TFTotRub_To;
         }
         if ( ! ( (0==AV39TFRubCod) && (0==AV40TFRubCod_To) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Codigo Rubro") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV39TFRubCod;
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV40TFRubCod_To;
         }
         if ( ! ( (0==AV41TFRubLinCod) && (0==AV42TFRubLinCod_To) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Codigo Linea") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV41TFRubLinCod;
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV42TFRubLinCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFRubLinDsc_Sel)) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Linea") ;
            AV13CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFRubLinDsc_Sel, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFRubLinDsc)) ) )
            {
               GXt_int1 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Linea") ;
               AV13CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFRubLinDsc, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFRubLinDscTot_Sel)) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Totales Linea") ;
            AV13CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TFRubLinDscTot_Sel, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFRubLinDscTot)) ) )
            {
               GXt_int1 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Totales Linea") ;
               AV13CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45TFRubLinDscTot, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (0==AV47TFRubLinOrd) && (0==AV48TFRubLinOrd_To) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "N° Orden") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV47TFRubLinOrd;
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV48TFRubLinOrd_To;
         }
         if ( ! ( ( AV50TFRubLinSts_Sels.Count == 0 ) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int1;
            AV52i = 1;
            AV59GXV2 = 1;
            while ( AV59GXV2 <= AV50TFRubLinSts_Sels.Count )
            {
               AV51TFRubLinSts_Sel = (short)(AV50TFRubLinSts_Sels.GetNumeric(AV59GXV2));
               if ( AV52i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV51TFRubLinSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV51TFRubLinSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV52i = (long)(AV52i+1);
               AV59GXV2 = (int)(AV59GXV2+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Tipo de Reporte";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Codigo Rubro Totales";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Codigo Rubro";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Codigo Linea";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Linea";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Totales Linea";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "N° Orden";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV62Contabilidad_lineaswwds_2_tottipo1 = AV53TotTipo1;
         AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV65Contabilidad_lineaswwds_5_tottipo2 = AV54TotTipo2;
         AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV68Contabilidad_lineaswwds_8_tottipo3 = AV55TotTipo3;
         AV69Contabilidad_lineaswwds_9_tftottipo_sels = AV35TFTotTipo_Sels;
         AV70Contabilidad_lineaswwds_10_tftotrub = AV37TFTotRub;
         AV71Contabilidad_lineaswwds_11_tftotrub_to = AV38TFTotRub_To;
         AV72Contabilidad_lineaswwds_12_tfrubcod = AV39TFRubCod;
         AV73Contabilidad_lineaswwds_13_tfrubcod_to = AV40TFRubCod_To;
         AV74Contabilidad_lineaswwds_14_tfrublincod = AV41TFRubLinCod;
         AV75Contabilidad_lineaswwds_15_tfrublincod_to = AV42TFRubLinCod_To;
         AV76Contabilidad_lineaswwds_16_tfrublindsc = AV43TFRubLinDsc;
         AV77Contabilidad_lineaswwds_17_tfrublindsc_sel = AV44TFRubLinDsc_Sel;
         AV78Contabilidad_lineaswwds_18_tfrublindsctot = AV45TFRubLinDscTot;
         AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel = AV46TFRubLinDscTot_Sel;
         AV80Contabilidad_lineaswwds_20_tfrublinord = AV47TFRubLinOrd;
         AV81Contabilidad_lineaswwds_21_tfrublinord_to = AV48TFRubLinOrd_To;
         AV82Contabilidad_lineaswwds_22_tfrublinsts_sels = AV50TFRubLinSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A114TotTipo ,
                                              AV69Contabilidad_lineaswwds_9_tftottipo_sels ,
                                              A1828RubLinSts ,
                                              AV82Contabilidad_lineaswwds_22_tfrublinsts_sels ,
                                              AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 ,
                                              AV62Contabilidad_lineaswwds_2_tottipo1 ,
                                              AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ,
                                              AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 ,
                                              AV65Contabilidad_lineaswwds_5_tottipo2 ,
                                              AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ,
                                              AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 ,
                                              AV68Contabilidad_lineaswwds_8_tottipo3 ,
                                              AV69Contabilidad_lineaswwds_9_tftottipo_sels.Count ,
                                              AV70Contabilidad_lineaswwds_10_tftotrub ,
                                              AV71Contabilidad_lineaswwds_11_tftotrub_to ,
                                              AV72Contabilidad_lineaswwds_12_tfrubcod ,
                                              AV73Contabilidad_lineaswwds_13_tfrubcod_to ,
                                              AV74Contabilidad_lineaswwds_14_tfrublincod ,
                                              AV75Contabilidad_lineaswwds_15_tfrublincod_to ,
                                              AV77Contabilidad_lineaswwds_17_tfrublindsc_sel ,
                                              AV76Contabilidad_lineaswwds_16_tfrublindsc ,
                                              AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel ,
                                              AV78Contabilidad_lineaswwds_18_tfrublindsctot ,
                                              AV80Contabilidad_lineaswwds_20_tfrublinord ,
                                              AV81Contabilidad_lineaswwds_21_tfrublinord_to ,
                                              AV82Contabilidad_lineaswwds_22_tfrublinsts_sels.Count ,
                                              A115TotRub ,
                                              A116RubCod ,
                                              A118RubLinCod ,
                                              A1826RubLinDsc ,
                                              A1827RubLinDscTot ,
                                              A119RubLinOrd ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV76Contabilidad_lineaswwds_16_tfrublindsc = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_lineaswwds_16_tfrublindsc), 100, "%");
         lV78Contabilidad_lineaswwds_18_tfrublindsctot = StringUtil.PadR( StringUtil.RTrim( AV78Contabilidad_lineaswwds_18_tfrublindsctot), 100, "%");
         /* Using cursor P00762 */
         pr_default.execute(0, new Object[] {AV62Contabilidad_lineaswwds_2_tottipo1, AV65Contabilidad_lineaswwds_5_tottipo2, AV68Contabilidad_lineaswwds_8_tottipo3, AV70Contabilidad_lineaswwds_10_tftotrub, AV71Contabilidad_lineaswwds_11_tftotrub_to, AV72Contabilidad_lineaswwds_12_tfrubcod, AV73Contabilidad_lineaswwds_13_tfrubcod_to, AV74Contabilidad_lineaswwds_14_tfrublincod, AV75Contabilidad_lineaswwds_15_tfrublincod_to, lV76Contabilidad_lineaswwds_16_tfrublindsc, AV77Contabilidad_lineaswwds_17_tfrublindsc_sel, lV78Contabilidad_lineaswwds_18_tfrublindsctot, AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel, AV80Contabilidad_lineaswwds_20_tfrublinord, AV81Contabilidad_lineaswwds_21_tfrublinord_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1828RubLinSts = P00762_A1828RubLinSts[0];
            A119RubLinOrd = P00762_A119RubLinOrd[0];
            A1827RubLinDscTot = P00762_A1827RubLinDscTot[0];
            A1826RubLinDsc = P00762_A1826RubLinDsc[0];
            A118RubLinCod = P00762_A118RubLinCod[0];
            A116RubCod = P00762_A116RubCod[0];
            A115TotRub = P00762_A115TotRub[0];
            A114TotTipo = P00762_A114TotTipo[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( A114TotTipo), "BAL") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Estado de Situación Financiera";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A114TotTipo), "FUN") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Estado de Resultados Integrales";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A114TotTipo), "NAT") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Estado de Ganancia y Perdidad";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A114TotTipo), "COS") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Registro de Costos";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A114TotTipo), "RCC") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Registro de Costos / Centro de Costos";
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = A115TotRub;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = A116RubCod;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = A118RubLinCod;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1826RubLinDsc, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char2;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1827RubLinDscTot, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = GXt_char2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Number = A119RubLinOrd;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "";
            if ( A1828RubLinSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "ACTIVO";
            }
            else if ( A1828RubLinSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "INACTIVO";
            }
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
         if ( StringUtil.StrCmp(AV30Session.Get("Contabilidad.LineasWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.LineasWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Contabilidad.LineasWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV83GXV3 = 1;
         while ( AV83GXV3 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV83GXV3));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTOTTIPO_SEL") == 0 )
            {
               AV34TFTotTipo_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV35TFTotTipo_Sels.FromJSonString(AV34TFTotTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTOTRUB") == 0 )
            {
               AV37TFTotRub = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV38TFTotRub_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBCOD") == 0 )
            {
               AV39TFRubCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV40TFRubCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBLINCOD") == 0 )
            {
               AV41TFRubLinCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV42TFRubLinCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBLINDSC") == 0 )
            {
               AV43TFRubLinDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBLINDSC_SEL") == 0 )
            {
               AV44TFRubLinDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBLINDSCTOT") == 0 )
            {
               AV45TFRubLinDscTot = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBLINDSCTOT_SEL") == 0 )
            {
               AV46TFRubLinDscTot_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBLINORD") == 0 )
            {
               AV47TFRubLinOrd = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV48TFRubLinOrd_To = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBLINSTS_SEL") == 0 )
            {
               AV49TFRubLinSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV50TFRubLinSts_Sels.FromJSonString(AV49TFRubLinSts_SelsJson, null);
            }
            AV83GXV3 = (int)(AV83GXV3+1);
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
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV53TotTipo1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV54TotTipo2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV55TotTipo3 = "";
         AV35TFTotTipo_Sels = new GxSimpleCollection<string>();
         AV36TFTotTipo_Sel = "";
         AV44TFRubLinDsc_Sel = "";
         AV43TFRubLinDsc = "";
         AV46TFRubLinDscTot_Sel = "";
         AV45TFRubLinDscTot = "";
         AV50TFRubLinSts_Sels = new GxSimpleCollection<short>();
         AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 = "";
         AV62Contabilidad_lineaswwds_2_tottipo1 = "";
         AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 = "";
         AV65Contabilidad_lineaswwds_5_tottipo2 = "";
         AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 = "";
         AV68Contabilidad_lineaswwds_8_tottipo3 = "";
         AV69Contabilidad_lineaswwds_9_tftottipo_sels = new GxSimpleCollection<string>();
         AV76Contabilidad_lineaswwds_16_tfrublindsc = "";
         AV77Contabilidad_lineaswwds_17_tfrublindsc_sel = "";
         AV78Contabilidad_lineaswwds_18_tfrublindsctot = "";
         AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel = "";
         AV82Contabilidad_lineaswwds_22_tfrublinsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV76Contabilidad_lineaswwds_16_tfrublindsc = "";
         lV78Contabilidad_lineaswwds_18_tfrublindsctot = "";
         A114TotTipo = "";
         A1826RubLinDsc = "";
         A1827RubLinDscTot = "";
         P00762_A1828RubLinSts = new short[1] ;
         P00762_A119RubLinOrd = new short[1] ;
         P00762_A1827RubLinDscTot = new string[] {""} ;
         P00762_A1826RubLinDsc = new string[] {""} ;
         P00762_A118RubLinCod = new int[1] ;
         P00762_A116RubCod = new int[1] ;
         P00762_A115TotRub = new int[1] ;
         P00762_A114TotTipo = new string[] {""} ;
         GXt_char2 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV34TFTotTipo_SelsJson = "";
         AV49TFRubLinSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.lineaswwexport__default(),
            new Object[][] {
                new Object[] {
               P00762_A1828RubLinSts, P00762_A119RubLinOrd, P00762_A1827RubLinDscTot, P00762_A1826RubLinDsc, P00762_A118RubLinCod, P00762_A116RubCod, P00762_A115TotRub, P00762_A114TotTipo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV47TFRubLinOrd ;
      private short AV48TFRubLinOrd_To ;
      private short GXt_int1 ;
      private short AV51TFRubLinSts_Sel ;
      private short AV80Contabilidad_lineaswwds_20_tfrublinord ;
      private short AV81Contabilidad_lineaswwds_21_tfrublinord_to ;
      private short A1828RubLinSts ;
      private short A119RubLinOrd ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV58GXV1 ;
      private int AV37TFTotRub ;
      private int AV38TFTotRub_To ;
      private int AV39TFRubCod ;
      private int AV40TFRubCod_To ;
      private int AV41TFRubLinCod ;
      private int AV42TFRubLinCod_To ;
      private int AV59GXV2 ;
      private int AV70Contabilidad_lineaswwds_10_tftotrub ;
      private int AV71Contabilidad_lineaswwds_11_tftotrub_to ;
      private int AV72Contabilidad_lineaswwds_12_tfrubcod ;
      private int AV73Contabilidad_lineaswwds_13_tfrubcod_to ;
      private int AV74Contabilidad_lineaswwds_14_tfrublincod ;
      private int AV75Contabilidad_lineaswwds_15_tfrublincod_to ;
      private int AV69Contabilidad_lineaswwds_9_tftottipo_sels_Count ;
      private int AV82Contabilidad_lineaswwds_22_tfrublinsts_sels_Count ;
      private int A115TotRub ;
      private int A116RubCod ;
      private int A118RubLinCod ;
      private int AV83GXV3 ;
      private long AV52i ;
      private string AV53TotTipo1 ;
      private string AV54TotTipo2 ;
      private string AV55TotTipo3 ;
      private string AV36TFTotTipo_Sel ;
      private string AV44TFRubLinDsc_Sel ;
      private string AV43TFRubLinDsc ;
      private string AV46TFRubLinDscTot_Sel ;
      private string AV45TFRubLinDscTot ;
      private string AV62Contabilidad_lineaswwds_2_tottipo1 ;
      private string AV65Contabilidad_lineaswwds_5_tottipo2 ;
      private string AV68Contabilidad_lineaswwds_8_tottipo3 ;
      private string AV76Contabilidad_lineaswwds_16_tfrublindsc ;
      private string AV77Contabilidad_lineaswwds_17_tfrublindsc_sel ;
      private string AV78Contabilidad_lineaswwds_18_tfrublindsctot ;
      private string AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel ;
      private string scmdbuf ;
      private string lV76Contabilidad_lineaswwds_16_tfrublindsc ;
      private string lV78Contabilidad_lineaswwds_18_tfrublindsctot ;
      private string A114TotTipo ;
      private string A1826RubLinDsc ;
      private string A1827RubLinDscTot ;
      private string GXt_char2 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ;
      private bool AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV34TFTotTipo_SelsJson ;
      private string AV49TFRubLinSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 ;
      private string AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 ;
      private string AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV50TFRubLinSts_Sels ;
      private GxSimpleCollection<short> AV82Contabilidad_lineaswwds_22_tfrublinsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00762_A1828RubLinSts ;
      private short[] P00762_A119RubLinOrd ;
      private string[] P00762_A1827RubLinDscTot ;
      private string[] P00762_A1826RubLinDsc ;
      private int[] P00762_A118RubLinCod ;
      private int[] P00762_A116RubCod ;
      private int[] P00762_A115TotRub ;
      private string[] P00762_A114TotTipo ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GxSimpleCollection<string> AV35TFTotTipo_Sels ;
      private GxSimpleCollection<string> AV69Contabilidad_lineaswwds_9_tftottipo_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class lineaswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00762( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV69Contabilidad_lineaswwds_9_tftottipo_sels ,
                                             short A1828RubLinSts ,
                                             GxSimpleCollection<short> AV82Contabilidad_lineaswwds_22_tfrublinsts_sels ,
                                             string AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1 ,
                                             string AV62Contabilidad_lineaswwds_2_tottipo1 ,
                                             bool AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ,
                                             string AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2 ,
                                             string AV65Contabilidad_lineaswwds_5_tottipo2 ,
                                             bool AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ,
                                             string AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3 ,
                                             string AV68Contabilidad_lineaswwds_8_tottipo3 ,
                                             int AV69Contabilidad_lineaswwds_9_tftottipo_sels_Count ,
                                             int AV70Contabilidad_lineaswwds_10_tftotrub ,
                                             int AV71Contabilidad_lineaswwds_11_tftotrub_to ,
                                             int AV72Contabilidad_lineaswwds_12_tfrubcod ,
                                             int AV73Contabilidad_lineaswwds_13_tfrubcod_to ,
                                             int AV74Contabilidad_lineaswwds_14_tfrublincod ,
                                             int AV75Contabilidad_lineaswwds_15_tfrublincod_to ,
                                             string AV77Contabilidad_lineaswwds_17_tfrublindsc_sel ,
                                             string AV76Contabilidad_lineaswwds_16_tfrublindsc ,
                                             string AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel ,
                                             string AV78Contabilidad_lineaswwds_18_tfrublindsctot ,
                                             short AV80Contabilidad_lineaswwds_20_tfrublinord ,
                                             short AV81Contabilidad_lineaswwds_21_tfrublinord_to ,
                                             int AV82Contabilidad_lineaswwds_22_tfrublinsts_sels_Count ,
                                             int A115TotRub ,
                                             int A116RubCod ,
                                             int A118RubLinCod ,
                                             string A1826RubLinDsc ,
                                             string A1827RubLinDscTot ,
                                             short A119RubLinOrd ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [RubLinSts], [RubLinOrd], [RubLinDscTot], [RubLinDsc], [RubLinCod], [RubCod], [TotRub], [TotTipo] FROM [CBRUBROSL]";
         if ( ( StringUtil.StrCmp(AV61Contabilidad_lineaswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contabilidad_lineaswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV62Contabilidad_lineaswwds_2_tottipo1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( AV63Contabilidad_lineaswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Contabilidad_lineaswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_lineaswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV65Contabilidad_lineaswwds_5_tottipo2)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV66Contabilidad_lineaswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Contabilidad_lineaswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_lineaswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV68Contabilidad_lineaswwds_8_tottipo3)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV69Contabilidad_lineaswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV69Contabilidad_lineaswwds_9_tftottipo_sels, "[TotTipo] IN (", ")")+")");
         }
         if ( ! (0==AV70Contabilidad_lineaswwds_10_tftotrub) )
         {
            AddWhere(sWhereString, "([TotRub] >= @AV70Contabilidad_lineaswwds_10_tftotrub)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV71Contabilidad_lineaswwds_11_tftotrub_to) )
         {
            AddWhere(sWhereString, "([TotRub] <= @AV71Contabilidad_lineaswwds_11_tftotrub_to)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV72Contabilidad_lineaswwds_12_tfrubcod) )
         {
            AddWhere(sWhereString, "([RubCod] >= @AV72Contabilidad_lineaswwds_12_tfrubcod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV73Contabilidad_lineaswwds_13_tfrubcod_to) )
         {
            AddWhere(sWhereString, "([RubCod] <= @AV73Contabilidad_lineaswwds_13_tfrubcod_to)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV74Contabilidad_lineaswwds_14_tfrublincod) )
         {
            AddWhere(sWhereString, "([RubLinCod] >= @AV74Contabilidad_lineaswwds_14_tfrublincod)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (0==AV75Contabilidad_lineaswwds_15_tfrublincod_to) )
         {
            AddWhere(sWhereString, "([RubLinCod] <= @AV75Contabilidad_lineaswwds_15_tfrublincod_to)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_lineaswwds_17_tfrublindsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_lineaswwds_16_tfrublindsc)) ) )
         {
            AddWhere(sWhereString, "([RubLinDsc] like @lV76Contabilidad_lineaswwds_16_tfrublindsc)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_lineaswwds_17_tfrublindsc_sel)) )
         {
            AddWhere(sWhereString, "([RubLinDsc] = @AV77Contabilidad_lineaswwds_17_tfrublindsc_sel)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_lineaswwds_18_tfrublindsctot)) ) )
         {
            AddWhere(sWhereString, "([RubLinDscTot] like @lV78Contabilidad_lineaswwds_18_tfrublindsctot)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel)) )
         {
            AddWhere(sWhereString, "([RubLinDscTot] = @AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV80Contabilidad_lineaswwds_20_tfrublinord) )
         {
            AddWhere(sWhereString, "([RubLinOrd] >= @AV80Contabilidad_lineaswwds_20_tfrublinord)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (0==AV81Contabilidad_lineaswwds_21_tfrublinord_to) )
         {
            AddWhere(sWhereString, "([RubLinOrd] <= @AV81Contabilidad_lineaswwds_21_tfrublinord_to)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV82Contabilidad_lineaswwds_22_tfrublinsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Contabilidad_lineaswwds_22_tfrublinsts_sels, "[RubLinSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [TotTipo], [TotRub], [RubCod], [RubLinCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TotTipo]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TotTipo] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TotRub]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TotRub] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubCod]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubCod] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubLinCod]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubLinCod] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubLinDsc]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubLinDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubLinDscTot]";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubLinDscTot] DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubLinOrd]";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubLinOrd] DESC";
         }
         else if ( ( AV16OrderedBy == 9 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubLinSts]";
         }
         else if ( ( AV16OrderedBy == 9 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubLinSts] DESC";
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
                     return conditional_P00762(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] );
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
          Object[] prmP00762;
          prmP00762 = new Object[] {
          new ParDef("@AV62Contabilidad_lineaswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV65Contabilidad_lineaswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV68Contabilidad_lineaswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@AV70Contabilidad_lineaswwds_10_tftotrub",GXType.Int32,6,0) ,
          new ParDef("@AV71Contabilidad_lineaswwds_11_tftotrub_to",GXType.Int32,6,0) ,
          new ParDef("@AV72Contabilidad_lineaswwds_12_tfrubcod",GXType.Int32,6,0) ,
          new ParDef("@AV73Contabilidad_lineaswwds_13_tfrubcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV74Contabilidad_lineaswwds_14_tfrublincod",GXType.Int32,6,0) ,
          new ParDef("@AV75Contabilidad_lineaswwds_15_tfrublincod_to",GXType.Int32,6,0) ,
          new ParDef("@lV76Contabilidad_lineaswwds_16_tfrublindsc",GXType.NChar,100,0) ,
          new ParDef("@AV77Contabilidad_lineaswwds_17_tfrublindsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV78Contabilidad_lineaswwds_18_tfrublindsctot",GXType.NChar,100,0) ,
          new ParDef("@AV79Contabilidad_lineaswwds_19_tfrublindsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV80Contabilidad_lineaswwds_20_tfrublinord",GXType.Int16,2,0) ,
          new ParDef("@AV81Contabilidad_lineaswwds_21_tfrublinord_to",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00762", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00762,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 3);
                return;
       }
    }

 }

}
