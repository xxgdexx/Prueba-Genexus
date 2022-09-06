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
   public class rubroswwexport : GXProcedure
   {
      public rubroswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rubroswwexport( IGxContext context )
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
         rubroswwexport objrubroswwexport;
         objrubroswwexport = new rubroswwexport();
         objrubroswwexport.AV11Filename = "" ;
         objrubroswwexport.AV12ErrorMessage = "" ;
         objrubroswwexport.context.SetSubmitInitialConfig(context);
         objrubroswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrubroswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rubroswwexport)stateInfo).executePrivate();
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
         AV11Filename = "RubrosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
               AV51TotTipo1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TotTipo1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Reporte";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV51TotTipo1), "BAL") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Situación Financiera";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV51TotTipo1), "FUN") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Resultados Integrales";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV51TotTipo1), "NAT") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Ganancia y Perdidad";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV51TotTipo1), "COS") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Registro de Costos";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV51TotTipo1), "RCC") == 0 )
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
                  AV52TotTipo2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TotTipo2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Reporte";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( AV52TotTipo2), "BAL") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Situación Financiera";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV52TotTipo2), "FUN") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Resultados Integrales";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV52TotTipo2), "NAT") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Ganancia y Perdidad";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV52TotTipo2), "COS") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Registro de Costos";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV52TotTipo2), "RCC") == 0 )
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
                     AV53TotTipo3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53TotTipo3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Reporte";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV53TotTipo3), "BAL") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Situación Financiera";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV53TotTipo3), "FUN") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Resultados Integrales";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV53TotTipo3), "NAT") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Estado de Ganancia y Perdidad";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV53TotTipo3), "COS") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Registro de Costos";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV53TotTipo3), "RCC") == 0 )
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
            AV50i = 1;
            AV61GXV1 = 1;
            while ( AV61GXV1 <= AV35TFTotTipo_Sels.Count )
            {
               AV36TFTotTipo_Sel = AV35TFTotTipo_Sels.GetString(AV61GXV1);
               if ( AV50i == 1 )
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
               AV50i = (long)(AV50i+1);
               AV61GXV1 = (int)(AV61GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFTotDsc_Sel)) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Titulo de Totales") ;
            AV13CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55TFTotDsc_Sel, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFTotDsc)) ) )
            {
               GXt_int1 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Titulo de Totales") ;
               AV13CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54TFTotDsc, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFRubDsc_Sel)) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Rubro") ;
            AV13CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFRubDsc_Sel, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFRubDsc)) ) )
            {
               GXt_int1 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Rubro") ;
               AV13CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFRubDsc, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFRubDscTot_Sel)) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Totales de Rubros") ;
            AV13CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFRubDscTot_Sel, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFRubDscTot)) ) )
            {
               GXt_int1 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Totales de Rubros") ;
               AV13CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFRubDscTot, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (0==AV45TFRubOrd) && (0==AV46TFRubOrd_To) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "N° Orden") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV45TFRubOrd;
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV46TFRubOrd_To;
         }
         if ( ! ( ( AV48TFRubSts_Sels.Count == 0 ) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int1;
            AV50i = 1;
            AV62GXV2 = 1;
            while ( AV62GXV2 <= AV48TFRubSts_Sels.Count )
            {
               AV49TFRubSts_Sel = (short)(AV48TFRubSts_Sels.GetNumeric(AV62GXV2));
               if ( AV50i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV49TFRubSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV49TFRubSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV50i = (long)(AV50i+1);
               AV62GXV2 = (int)(AV62GXV2+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Titulo de Totales";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Codigo Rubro";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Rubro";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Totales de Rubros";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "N° Orden";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV64Contabilidad_rubroswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV65Contabilidad_rubroswwds_2_tottipo1 = AV51TotTipo1;
         AV66Contabilidad_rubroswwds_3_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV67Contabilidad_rubroswwds_4_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV68Contabilidad_rubroswwds_5_tottipo2 = AV52TotTipo2;
         AV69Contabilidad_rubroswwds_6_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV70Contabilidad_rubroswwds_7_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV71Contabilidad_rubroswwds_8_tottipo3 = AV53TotTipo3;
         AV72Contabilidad_rubroswwds_9_tftottipo_sels = AV35TFTotTipo_Sels;
         AV73Contabilidad_rubroswwds_10_tftotdsc = AV54TFTotDsc;
         AV74Contabilidad_rubroswwds_11_tftotdsc_sel = AV55TFTotDsc_Sel;
         AV75Contabilidad_rubroswwds_12_tfrubcod = AV39TFRubCod;
         AV76Contabilidad_rubroswwds_13_tfrubcod_to = AV40TFRubCod_To;
         AV77Contabilidad_rubroswwds_14_tfrubdsc = AV41TFRubDsc;
         AV78Contabilidad_rubroswwds_15_tfrubdsc_sel = AV42TFRubDsc_Sel;
         AV79Contabilidad_rubroswwds_16_tfrubdsctot = AV43TFRubDscTot;
         AV80Contabilidad_rubroswwds_17_tfrubdsctot_sel = AV44TFRubDscTot_Sel;
         AV81Contabilidad_rubroswwds_18_tfrubord = AV45TFRubOrd;
         AV82Contabilidad_rubroswwds_19_tfrubord_to = AV46TFRubOrd_To;
         AV83Contabilidad_rubroswwds_20_tfrubsts_sels = AV48TFRubSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A114TotTipo ,
                                              AV72Contabilidad_rubroswwds_9_tftottipo_sels ,
                                              A1829RubSts ,
                                              AV83Contabilidad_rubroswwds_20_tfrubsts_sels ,
                                              AV64Contabilidad_rubroswwds_1_dynamicfiltersselector1 ,
                                              AV65Contabilidad_rubroswwds_2_tottipo1 ,
                                              AV66Contabilidad_rubroswwds_3_dynamicfiltersenabled2 ,
                                              AV67Contabilidad_rubroswwds_4_dynamicfiltersselector2 ,
                                              AV68Contabilidad_rubroswwds_5_tottipo2 ,
                                              AV69Contabilidad_rubroswwds_6_dynamicfiltersenabled3 ,
                                              AV70Contabilidad_rubroswwds_7_dynamicfiltersselector3 ,
                                              AV71Contabilidad_rubroswwds_8_tottipo3 ,
                                              AV72Contabilidad_rubroswwds_9_tftottipo_sels.Count ,
                                              AV74Contabilidad_rubroswwds_11_tftotdsc_sel ,
                                              AV73Contabilidad_rubroswwds_10_tftotdsc ,
                                              AV75Contabilidad_rubroswwds_12_tfrubcod ,
                                              AV76Contabilidad_rubroswwds_13_tfrubcod_to ,
                                              AV78Contabilidad_rubroswwds_15_tfrubdsc_sel ,
                                              AV77Contabilidad_rubroswwds_14_tfrubdsc ,
                                              AV80Contabilidad_rubroswwds_17_tfrubdsctot_sel ,
                                              AV79Contabilidad_rubroswwds_16_tfrubdsctot ,
                                              AV81Contabilidad_rubroswwds_18_tfrubord ,
                                              AV82Contabilidad_rubroswwds_19_tfrubord_to ,
                                              AV83Contabilidad_rubroswwds_20_tfrubsts_sels.Count ,
                                              A1928TotDsc ,
                                              A116RubCod ,
                                              A1822RubDsc ,
                                              A1823RubDscTot ,
                                              A117RubOrd ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV73Contabilidad_rubroswwds_10_tftotdsc = StringUtil.PadR( StringUtil.RTrim( AV73Contabilidad_rubroswwds_10_tftotdsc), 100, "%");
         lV77Contabilidad_rubroswwds_14_tfrubdsc = StringUtil.PadR( StringUtil.RTrim( AV77Contabilidad_rubroswwds_14_tfrubdsc), 100, "%");
         lV79Contabilidad_rubroswwds_16_tfrubdsctot = StringUtil.PadR( StringUtil.RTrim( AV79Contabilidad_rubroswwds_16_tfrubdsctot), 100, "%");
         /* Using cursor P00732 */
         pr_default.execute(0, new Object[] {AV65Contabilidad_rubroswwds_2_tottipo1, AV68Contabilidad_rubroswwds_5_tottipo2, AV71Contabilidad_rubroswwds_8_tottipo3, lV73Contabilidad_rubroswwds_10_tftotdsc, AV74Contabilidad_rubroswwds_11_tftotdsc_sel, AV75Contabilidad_rubroswwds_12_tfrubcod, AV76Contabilidad_rubroswwds_13_tfrubcod_to, lV77Contabilidad_rubroswwds_14_tfrubdsc, AV78Contabilidad_rubroswwds_15_tfrubdsc_sel, lV79Contabilidad_rubroswwds_16_tfrubdsctot, AV80Contabilidad_rubroswwds_17_tfrubdsctot_sel, AV81Contabilidad_rubroswwds_18_tfrubord, AV82Contabilidad_rubroswwds_19_tfrubord_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A115TotRub = P00732_A115TotRub[0];
            A1829RubSts = P00732_A1829RubSts[0];
            A117RubOrd = P00732_A117RubOrd[0];
            A1823RubDscTot = P00732_A1823RubDscTot[0];
            A1822RubDsc = P00732_A1822RubDsc[0];
            A116RubCod = P00732_A116RubCod[0];
            A1928TotDsc = P00732_A1928TotDsc[0];
            A114TotTipo = P00732_A114TotTipo[0];
            A1928TotDsc = P00732_A1928TotDsc[0];
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
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1928TotDsc, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = A116RubCod;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1822RubDsc, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char2;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1823RubDscTot, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Number = A117RubOrd;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "";
            if ( A1829RubSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "ACTIVO";
            }
            else if ( A1829RubSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "INACTIVO";
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
         if ( StringUtil.StrCmp(AV30Session.Get("Contabilidad.RubrosWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.RubrosWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Contabilidad.RubrosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV84GXV3 = 1;
         while ( AV84GXV3 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV84GXV3));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTOTTIPO_SEL") == 0 )
            {
               AV34TFTotTipo_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV35TFTotTipo_Sels.FromJSonString(AV34TFTotTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTOTDSC") == 0 )
            {
               AV54TFTotDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTOTDSC_SEL") == 0 )
            {
               AV55TFTotDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBCOD") == 0 )
            {
               AV39TFRubCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV40TFRubCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBDSC") == 0 )
            {
               AV41TFRubDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBDSC_SEL") == 0 )
            {
               AV42TFRubDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBDSCTOT") == 0 )
            {
               AV43TFRubDscTot = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBDSCTOT_SEL") == 0 )
            {
               AV44TFRubDscTot_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBORD") == 0 )
            {
               AV45TFRubOrd = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV46TFRubOrd_To = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRUBSTS_SEL") == 0 )
            {
               AV47TFRubSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV48TFRubSts_Sels.FromJSonString(AV47TFRubSts_SelsJson, null);
            }
            AV84GXV3 = (int)(AV84GXV3+1);
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
         AV51TotTipo1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV52TotTipo2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV53TotTipo3 = "";
         AV35TFTotTipo_Sels = new GxSimpleCollection<string>();
         AV36TFTotTipo_Sel = "";
         AV55TFTotDsc_Sel = "";
         AV54TFTotDsc = "";
         AV42TFRubDsc_Sel = "";
         AV41TFRubDsc = "";
         AV44TFRubDscTot_Sel = "";
         AV43TFRubDscTot = "";
         AV48TFRubSts_Sels = new GxSimpleCollection<short>();
         AV64Contabilidad_rubroswwds_1_dynamicfiltersselector1 = "";
         AV65Contabilidad_rubroswwds_2_tottipo1 = "";
         AV67Contabilidad_rubroswwds_4_dynamicfiltersselector2 = "";
         AV68Contabilidad_rubroswwds_5_tottipo2 = "";
         AV70Contabilidad_rubroswwds_7_dynamicfiltersselector3 = "";
         AV71Contabilidad_rubroswwds_8_tottipo3 = "";
         AV72Contabilidad_rubroswwds_9_tftottipo_sels = new GxSimpleCollection<string>();
         AV73Contabilidad_rubroswwds_10_tftotdsc = "";
         AV74Contabilidad_rubroswwds_11_tftotdsc_sel = "";
         AV77Contabilidad_rubroswwds_14_tfrubdsc = "";
         AV78Contabilidad_rubroswwds_15_tfrubdsc_sel = "";
         AV79Contabilidad_rubroswwds_16_tfrubdsctot = "";
         AV80Contabilidad_rubroswwds_17_tfrubdsctot_sel = "";
         AV83Contabilidad_rubroswwds_20_tfrubsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV73Contabilidad_rubroswwds_10_tftotdsc = "";
         lV77Contabilidad_rubroswwds_14_tfrubdsc = "";
         lV79Contabilidad_rubroswwds_16_tfrubdsctot = "";
         A114TotTipo = "";
         A1928TotDsc = "";
         A1822RubDsc = "";
         A1823RubDscTot = "";
         P00732_A115TotRub = new int[1] ;
         P00732_A1829RubSts = new short[1] ;
         P00732_A117RubOrd = new short[1] ;
         P00732_A1823RubDscTot = new string[] {""} ;
         P00732_A1822RubDsc = new string[] {""} ;
         P00732_A116RubCod = new int[1] ;
         P00732_A1928TotDsc = new string[] {""} ;
         P00732_A114TotTipo = new string[] {""} ;
         GXt_char2 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV34TFTotTipo_SelsJson = "";
         AV47TFRubSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rubroswwexport__default(),
            new Object[][] {
                new Object[] {
               P00732_A115TotRub, P00732_A1829RubSts, P00732_A117RubOrd, P00732_A1823RubDscTot, P00732_A1822RubDsc, P00732_A116RubCod, P00732_A1928TotDsc, P00732_A114TotTipo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV45TFRubOrd ;
      private short AV46TFRubOrd_To ;
      private short GXt_int1 ;
      private short AV49TFRubSts_Sel ;
      private short AV81Contabilidad_rubroswwds_18_tfrubord ;
      private short AV82Contabilidad_rubroswwds_19_tfrubord_to ;
      private short A1829RubSts ;
      private short A117RubOrd ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV61GXV1 ;
      private int AV39TFRubCod ;
      private int AV40TFRubCod_To ;
      private int AV62GXV2 ;
      private int AV75Contabilidad_rubroswwds_12_tfrubcod ;
      private int AV76Contabilidad_rubroswwds_13_tfrubcod_to ;
      private int AV72Contabilidad_rubroswwds_9_tftottipo_sels_Count ;
      private int AV83Contabilidad_rubroswwds_20_tfrubsts_sels_Count ;
      private int A116RubCod ;
      private int A115TotRub ;
      private int AV84GXV3 ;
      private long AV50i ;
      private string AV51TotTipo1 ;
      private string AV52TotTipo2 ;
      private string AV53TotTipo3 ;
      private string AV36TFTotTipo_Sel ;
      private string AV55TFTotDsc_Sel ;
      private string AV54TFTotDsc ;
      private string AV42TFRubDsc_Sel ;
      private string AV41TFRubDsc ;
      private string AV44TFRubDscTot_Sel ;
      private string AV43TFRubDscTot ;
      private string AV65Contabilidad_rubroswwds_2_tottipo1 ;
      private string AV68Contabilidad_rubroswwds_5_tottipo2 ;
      private string AV71Contabilidad_rubroswwds_8_tottipo3 ;
      private string AV73Contabilidad_rubroswwds_10_tftotdsc ;
      private string AV74Contabilidad_rubroswwds_11_tftotdsc_sel ;
      private string AV77Contabilidad_rubroswwds_14_tfrubdsc ;
      private string AV78Contabilidad_rubroswwds_15_tfrubdsc_sel ;
      private string AV79Contabilidad_rubroswwds_16_tfrubdsctot ;
      private string AV80Contabilidad_rubroswwds_17_tfrubdsctot_sel ;
      private string scmdbuf ;
      private string lV73Contabilidad_rubroswwds_10_tftotdsc ;
      private string lV77Contabilidad_rubroswwds_14_tfrubdsc ;
      private string lV79Contabilidad_rubroswwds_16_tfrubdsctot ;
      private string A114TotTipo ;
      private string A1928TotDsc ;
      private string A1822RubDsc ;
      private string A1823RubDscTot ;
      private string GXt_char2 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV66Contabilidad_rubroswwds_3_dynamicfiltersenabled2 ;
      private bool AV69Contabilidad_rubroswwds_6_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV34TFTotTipo_SelsJson ;
      private string AV47TFRubSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV64Contabilidad_rubroswwds_1_dynamicfiltersselector1 ;
      private string AV67Contabilidad_rubroswwds_4_dynamicfiltersselector2 ;
      private string AV70Contabilidad_rubroswwds_7_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV48TFRubSts_Sels ;
      private GxSimpleCollection<short> AV83Contabilidad_rubroswwds_20_tfrubsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00732_A115TotRub ;
      private short[] P00732_A1829RubSts ;
      private short[] P00732_A117RubOrd ;
      private string[] P00732_A1823RubDscTot ;
      private string[] P00732_A1822RubDsc ;
      private int[] P00732_A116RubCod ;
      private string[] P00732_A1928TotDsc ;
      private string[] P00732_A114TotTipo ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GxSimpleCollection<string> AV35TFTotTipo_Sels ;
      private GxSimpleCollection<string> AV72Contabilidad_rubroswwds_9_tftottipo_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class rubroswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00732( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV72Contabilidad_rubroswwds_9_tftottipo_sels ,
                                             short A1829RubSts ,
                                             GxSimpleCollection<short> AV83Contabilidad_rubroswwds_20_tfrubsts_sels ,
                                             string AV64Contabilidad_rubroswwds_1_dynamicfiltersselector1 ,
                                             string AV65Contabilidad_rubroswwds_2_tottipo1 ,
                                             bool AV66Contabilidad_rubroswwds_3_dynamicfiltersenabled2 ,
                                             string AV67Contabilidad_rubroswwds_4_dynamicfiltersselector2 ,
                                             string AV68Contabilidad_rubroswwds_5_tottipo2 ,
                                             bool AV69Contabilidad_rubroswwds_6_dynamicfiltersenabled3 ,
                                             string AV70Contabilidad_rubroswwds_7_dynamicfiltersselector3 ,
                                             string AV71Contabilidad_rubroswwds_8_tottipo3 ,
                                             int AV72Contabilidad_rubroswwds_9_tftottipo_sels_Count ,
                                             string AV74Contabilidad_rubroswwds_11_tftotdsc_sel ,
                                             string AV73Contabilidad_rubroswwds_10_tftotdsc ,
                                             int AV75Contabilidad_rubroswwds_12_tfrubcod ,
                                             int AV76Contabilidad_rubroswwds_13_tfrubcod_to ,
                                             string AV78Contabilidad_rubroswwds_15_tfrubdsc_sel ,
                                             string AV77Contabilidad_rubroswwds_14_tfrubdsc ,
                                             string AV80Contabilidad_rubroswwds_17_tfrubdsctot_sel ,
                                             string AV79Contabilidad_rubroswwds_16_tfrubdsctot ,
                                             short AV81Contabilidad_rubroswwds_18_tfrubord ,
                                             short AV82Contabilidad_rubroswwds_19_tfrubord_to ,
                                             int AV83Contabilidad_rubroswwds_20_tfrubsts_sels_Count ,
                                             string A1928TotDsc ,
                                             int A116RubCod ,
                                             string A1822RubDsc ,
                                             string A1823RubDscTot ,
                                             short A117RubOrd ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[13];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[TotRub], T1.[RubSts], T1.[RubOrd], T1.[RubDscTot], T1.[RubDsc], T1.[RubCod], T2.[TotDsc], T1.[TotTipo] FROM ([CBRUBROS] T1 INNER JOIN [CBRUBROST] T2 ON T2.[TotTipo] = T1.[TotTipo] AND T2.[TotRub] = T1.[TotRub])";
         if ( ( StringUtil.StrCmp(AV64Contabilidad_rubroswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_rubroswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV65Contabilidad_rubroswwds_2_tottipo1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( AV66Contabilidad_rubroswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Contabilidad_rubroswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_rubroswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV68Contabilidad_rubroswwds_5_tottipo2)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV69Contabilidad_rubroswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Contabilidad_rubroswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_rubroswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV71Contabilidad_rubroswwds_8_tottipo3)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV72Contabilidad_rubroswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Contabilidad_rubroswwds_9_tftottipo_sels, "T1.[TotTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_rubroswwds_11_tftotdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_rubroswwds_10_tftotdsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TotDsc] like @lV73Contabilidad_rubroswwds_10_tftotdsc)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_rubroswwds_11_tftotdsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TotDsc] = @AV74Contabilidad_rubroswwds_11_tftotdsc_sel)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV75Contabilidad_rubroswwds_12_tfrubcod) )
         {
            AddWhere(sWhereString, "(T1.[RubCod] >= @AV75Contabilidad_rubroswwds_12_tfrubcod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV76Contabilidad_rubroswwds_13_tfrubcod_to) )
         {
            AddWhere(sWhereString, "(T1.[RubCod] <= @AV76Contabilidad_rubroswwds_13_tfrubcod_to)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_rubroswwds_15_tfrubdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_rubroswwds_14_tfrubdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[RubDsc] like @lV77Contabilidad_rubroswwds_14_tfrubdsc)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_rubroswwds_15_tfrubdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[RubDsc] = @AV78Contabilidad_rubroswwds_15_tfrubdsc_sel)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_rubroswwds_17_tfrubdsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_rubroswwds_16_tfrubdsctot)) ) )
         {
            AddWhere(sWhereString, "(T1.[RubDscTot] like @lV79Contabilidad_rubroswwds_16_tfrubdsctot)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_rubroswwds_17_tfrubdsctot_sel)) )
         {
            AddWhere(sWhereString, "(T1.[RubDscTot] = @AV80Contabilidad_rubroswwds_17_tfrubdsctot_sel)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (0==AV81Contabilidad_rubroswwds_18_tfrubord) )
         {
            AddWhere(sWhereString, "(T1.[RubOrd] >= @AV81Contabilidad_rubroswwds_18_tfrubord)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV82Contabilidad_rubroswwds_19_tfrubord_to) )
         {
            AddWhere(sWhereString, "(T1.[RubOrd] <= @AV82Contabilidad_rubroswwds_19_tfrubord_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV83Contabilidad_rubroswwds_20_tfrubsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Contabilidad_rubroswwds_20_tfrubsts_sels, "T1.[RubSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubDsc]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TotTipo]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TotTipo] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[TotDsc]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[TotDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubCod]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubCod] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubDscTot]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubDscTot] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubOrd]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubOrd] DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubSts]";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubSts] DESC";
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
                     return conditional_P00732(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (short)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP00732;
          prmP00732 = new Object[] {
          new ParDef("@AV65Contabilidad_rubroswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV68Contabilidad_rubroswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV71Contabilidad_rubroswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@lV73Contabilidad_rubroswwds_10_tftotdsc",GXType.NChar,100,0) ,
          new ParDef("@AV74Contabilidad_rubroswwds_11_tftotdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV75Contabilidad_rubroswwds_12_tfrubcod",GXType.Int32,6,0) ,
          new ParDef("@AV76Contabilidad_rubroswwds_13_tfrubcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV77Contabilidad_rubroswwds_14_tfrubdsc",GXType.NChar,100,0) ,
          new ParDef("@AV78Contabilidad_rubroswwds_15_tfrubdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV79Contabilidad_rubroswwds_16_tfrubdsctot",GXType.NChar,100,0) ,
          new ParDef("@AV80Contabilidad_rubroswwds_17_tfrubdsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV81Contabilidad_rubroswwds_18_tfrubord",GXType.Int16,2,0) ,
          new ParDef("@AV82Contabilidad_rubroswwds_19_tfrubord_to",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00732", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00732,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 3);
                return;
       }
    }

 }

}
