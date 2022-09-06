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
   public class rubrostotaleswwexport : GXProcedure
   {
      public rubrostotaleswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rubrostotaleswwexport( IGxContext context )
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
         rubrostotaleswwexport objrubrostotaleswwexport;
         objrubrostotaleswwexport = new rubrostotaleswwexport();
         objrubrostotaleswwexport.AV11Filename = "" ;
         objrubrostotaleswwexport.AV12ErrorMessage = "" ;
         objrubrostotaleswwexport.context.SetSubmitInitialConfig(context);
         objrubrostotaleswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrubrostotaleswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rubrostotaleswwexport)stateInfo).executePrivate();
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
         AV11Filename = "RubrosTotalesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
               AV49TotTipo1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TotTipo1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Reporte";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TotTipo1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TOTTIPO") == 0 )
               {
                  AV50TotTipo2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TotTipo2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Reporte";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV50TotTipo2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TOTTIPO") == 0 )
                  {
                     AV51TotTipo3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TotTipo3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Reporte";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TotTipo3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( ( AV35TFTotTipo_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Reporte") ;
            AV13CellRow = GXt_int2;
            AV48i = 1;
            AV55GXV1 = 1;
            while ( AV55GXV1 <= AV35TFTotTipo_Sels.Count )
            {
               AV36TFTotTipo_Sel = AV35TFTotTipo_Sels.GetString(AV55GXV1);
               if ( AV48i == 1 )
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
               AV48i = (long)(AV48i+1);
               AV55GXV1 = (int)(AV55GXV1+1);
            }
         }
         if ( ! ( (0==AV37TFTotRub) && (0==AV38TFTotRub_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV37TFTotRub;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV38TFTotRub_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFTotDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Titulo de Totales") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFTotDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFTotDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Titulo de Totales") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFTotDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFTotDscTot_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Totales") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFTotDscTot_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFTotDscTot)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Totales") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFTotDscTot, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV43TFTotOrd) && (0==AV44TFTotOrd_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "N° Orden") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV43TFTotOrd;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV44TFTotOrd_To;
         }
         if ( ! ( ( AV46TFTotSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV48i = 1;
            AV56GXV2 = 1;
            while ( AV56GXV2 <= AV46TFTotSts_Sels.Count )
            {
               AV47TFTotSts_Sel = (short)(AV46TFTotSts_Sels.GetNumeric(AV56GXV2));
               if ( AV48i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV47TFTotSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV47TFTotSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV48i = (long)(AV48i+1);
               AV56GXV2 = (int)(AV56GXV2+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Codigo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Titulo de Totales";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Totales";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "N° Orden";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV58Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV59Contabilidad_rubrostotaleswwds_2_tottipo1 = AV49TotTipo1;
         AV60Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV61Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV62Contabilidad_rubrostotaleswwds_5_tottipo2 = AV50TotTipo2;
         AV63Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV64Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV65Contabilidad_rubrostotaleswwds_8_tottipo3 = AV51TotTipo3;
         AV66Contabilidad_rubrostotaleswwds_9_tftottipo_sels = AV35TFTotTipo_Sels;
         AV67Contabilidad_rubrostotaleswwds_10_tftotrub = AV37TFTotRub;
         AV68Contabilidad_rubrostotaleswwds_11_tftotrub_to = AV38TFTotRub_To;
         AV69Contabilidad_rubrostotaleswwds_12_tftotdsc = AV39TFTotDsc;
         AV70Contabilidad_rubrostotaleswwds_13_tftotdsc_sel = AV40TFTotDsc_Sel;
         AV71Contabilidad_rubrostotaleswwds_14_tftotdsctot = AV41TFTotDscTot;
         AV72Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel = AV42TFTotDscTot_Sel;
         AV73Contabilidad_rubrostotaleswwds_16_tftotord = AV43TFTotOrd;
         AV74Contabilidad_rubrostotaleswwds_17_tftotord_to = AV44TFTotOrd_To;
         AV75Contabilidad_rubrostotaleswwds_18_tftotsts_sels = AV46TFTotSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A114TotTipo ,
                                              AV66Contabilidad_rubrostotaleswwds_9_tftottipo_sels ,
                                              A1930TotSts ,
                                              AV75Contabilidad_rubrostotaleswwds_18_tftotsts_sels ,
                                              AV58Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 ,
                                              AV59Contabilidad_rubrostotaleswwds_2_tottipo1 ,
                                              AV60Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 ,
                                              AV61Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 ,
                                              AV62Contabilidad_rubrostotaleswwds_5_tottipo2 ,
                                              AV63Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 ,
                                              AV64Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 ,
                                              AV65Contabilidad_rubrostotaleswwds_8_tottipo3 ,
                                              AV66Contabilidad_rubrostotaleswwds_9_tftottipo_sels.Count ,
                                              AV67Contabilidad_rubrostotaleswwds_10_tftotrub ,
                                              AV68Contabilidad_rubrostotaleswwds_11_tftotrub_to ,
                                              AV70Contabilidad_rubrostotaleswwds_13_tftotdsc_sel ,
                                              AV69Contabilidad_rubrostotaleswwds_12_tftotdsc ,
                                              AV72Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel ,
                                              AV71Contabilidad_rubrostotaleswwds_14_tftotdsctot ,
                                              AV73Contabilidad_rubrostotaleswwds_16_tftotord ,
                                              AV74Contabilidad_rubrostotaleswwds_17_tftotord_to ,
                                              AV75Contabilidad_rubrostotaleswwds_18_tftotsts_sels.Count ,
                                              A115TotRub ,
                                              A1928TotDsc ,
                                              A1929TotDscTot ,
                                              A120TotOrd ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV69Contabilidad_rubrostotaleswwds_12_tftotdsc = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_rubrostotaleswwds_12_tftotdsc), 100, "%");
         lV71Contabilidad_rubrostotaleswwds_14_tftotdsctot = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_rubrostotaleswwds_14_tftotdsctot), 100, "%");
         /* Using cursor P00702 */
         pr_default.execute(0, new Object[] {AV59Contabilidad_rubrostotaleswwds_2_tottipo1, AV62Contabilidad_rubrostotaleswwds_5_tottipo2, AV65Contabilidad_rubrostotaleswwds_8_tottipo3, AV67Contabilidad_rubrostotaleswwds_10_tftotrub, AV68Contabilidad_rubrostotaleswwds_11_tftotrub_to, lV69Contabilidad_rubrostotaleswwds_12_tftotdsc, AV70Contabilidad_rubrostotaleswwds_13_tftotdsc_sel, lV71Contabilidad_rubrostotaleswwds_14_tftotdsctot, AV72Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel, AV73Contabilidad_rubrostotaleswwds_16_tftotord, AV74Contabilidad_rubrostotaleswwds_17_tftotord_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1930TotSts = P00702_A1930TotSts[0];
            A120TotOrd = P00702_A120TotOrd[0];
            A1929TotDscTot = P00702_A1929TotDscTot[0];
            A1928TotDsc = P00702_A1928TotDsc[0];
            A115TotRub = P00702_A115TotRub[0];
            A114TotTipo = P00702_A114TotTipo[0];
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
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1928TotDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1929TotDscTot, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = A120TotOrd;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "";
            if ( A1930TotSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "ACTIVO";
            }
            else if ( A1930TotSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "INACTIVO";
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
         if ( StringUtil.StrCmp(AV30Session.Get("Contabilidad.RubrosTotalesWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.RubrosTotalesWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Contabilidad.RubrosTotalesWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV76GXV3 = 1;
         while ( AV76GXV3 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV76GXV3));
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
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTOTDSC") == 0 )
            {
               AV39TFTotDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTOTDSC_SEL") == 0 )
            {
               AV40TFTotDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTOTDSCTOT") == 0 )
            {
               AV41TFTotDscTot = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTOTDSCTOT_SEL") == 0 )
            {
               AV42TFTotDscTot_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTOTORD") == 0 )
            {
               AV43TFTotOrd = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV44TFTotOrd_To = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTOTSTS_SEL") == 0 )
            {
               AV45TFTotSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV46TFTotSts_Sels.FromJSonString(AV45TFTotSts_SelsJson, null);
            }
            AV76GXV3 = (int)(AV76GXV3+1);
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
         AV49TotTipo1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV50TotTipo2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV51TotTipo3 = "";
         AV35TFTotTipo_Sels = new GxSimpleCollection<string>();
         AV36TFTotTipo_Sel = "";
         AV40TFTotDsc_Sel = "";
         AV39TFTotDsc = "";
         AV42TFTotDscTot_Sel = "";
         AV41TFTotDscTot = "";
         AV46TFTotSts_Sels = new GxSimpleCollection<short>();
         AV58Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 = "";
         AV59Contabilidad_rubrostotaleswwds_2_tottipo1 = "";
         AV61Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 = "";
         AV62Contabilidad_rubrostotaleswwds_5_tottipo2 = "";
         AV64Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 = "";
         AV65Contabilidad_rubrostotaleswwds_8_tottipo3 = "";
         AV66Contabilidad_rubrostotaleswwds_9_tftottipo_sels = new GxSimpleCollection<string>();
         AV69Contabilidad_rubrostotaleswwds_12_tftotdsc = "";
         AV70Contabilidad_rubrostotaleswwds_13_tftotdsc_sel = "";
         AV71Contabilidad_rubrostotaleswwds_14_tftotdsctot = "";
         AV72Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel = "";
         AV75Contabilidad_rubrostotaleswwds_18_tftotsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV69Contabilidad_rubrostotaleswwds_12_tftotdsc = "";
         lV71Contabilidad_rubrostotaleswwds_14_tftotdsctot = "";
         A114TotTipo = "";
         A1928TotDsc = "";
         A1929TotDscTot = "";
         P00702_A1930TotSts = new short[1] ;
         P00702_A120TotOrd = new short[1] ;
         P00702_A1929TotDscTot = new string[] {""} ;
         P00702_A1928TotDsc = new string[] {""} ;
         P00702_A115TotRub = new int[1] ;
         P00702_A114TotTipo = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV34TFTotTipo_SelsJson = "";
         AV45TFTotSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rubrostotaleswwexport__default(),
            new Object[][] {
                new Object[] {
               P00702_A1930TotSts, P00702_A120TotOrd, P00702_A1929TotDscTot, P00702_A1928TotDsc, P00702_A115TotRub, P00702_A114TotTipo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV43TFTotOrd ;
      private short AV44TFTotOrd_To ;
      private short GXt_int2 ;
      private short AV47TFTotSts_Sel ;
      private short AV73Contabilidad_rubrostotaleswwds_16_tftotord ;
      private short AV74Contabilidad_rubrostotaleswwds_17_tftotord_to ;
      private short A1930TotSts ;
      private short A120TotOrd ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV55GXV1 ;
      private int AV37TFTotRub ;
      private int AV38TFTotRub_To ;
      private int AV56GXV2 ;
      private int AV67Contabilidad_rubrostotaleswwds_10_tftotrub ;
      private int AV68Contabilidad_rubrostotaleswwds_11_tftotrub_to ;
      private int AV66Contabilidad_rubrostotaleswwds_9_tftottipo_sels_Count ;
      private int AV75Contabilidad_rubrostotaleswwds_18_tftotsts_sels_Count ;
      private int A115TotRub ;
      private int AV76GXV3 ;
      private long AV48i ;
      private string AV49TotTipo1 ;
      private string AV50TotTipo2 ;
      private string AV51TotTipo3 ;
      private string AV36TFTotTipo_Sel ;
      private string AV40TFTotDsc_Sel ;
      private string AV39TFTotDsc ;
      private string AV42TFTotDscTot_Sel ;
      private string AV41TFTotDscTot ;
      private string AV59Contabilidad_rubrostotaleswwds_2_tottipo1 ;
      private string AV62Contabilidad_rubrostotaleswwds_5_tottipo2 ;
      private string AV65Contabilidad_rubrostotaleswwds_8_tottipo3 ;
      private string AV69Contabilidad_rubrostotaleswwds_12_tftotdsc ;
      private string AV70Contabilidad_rubrostotaleswwds_13_tftotdsc_sel ;
      private string AV71Contabilidad_rubrostotaleswwds_14_tftotdsctot ;
      private string AV72Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel ;
      private string scmdbuf ;
      private string lV69Contabilidad_rubrostotaleswwds_12_tftotdsc ;
      private string lV71Contabilidad_rubrostotaleswwds_14_tftotdsctot ;
      private string A114TotTipo ;
      private string A1928TotDsc ;
      private string A1929TotDscTot ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV60Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 ;
      private bool AV63Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV34TFTotTipo_SelsJson ;
      private string AV45TFTotSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV58Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 ;
      private string AV61Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 ;
      private string AV64Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV46TFTotSts_Sels ;
      private GxSimpleCollection<short> AV75Contabilidad_rubrostotaleswwds_18_tftotsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00702_A1930TotSts ;
      private short[] P00702_A120TotOrd ;
      private string[] P00702_A1929TotDscTot ;
      private string[] P00702_A1928TotDsc ;
      private int[] P00702_A115TotRub ;
      private string[] P00702_A114TotTipo ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GxSimpleCollection<string> AV35TFTotTipo_Sels ;
      private GxSimpleCollection<string> AV66Contabilidad_rubrostotaleswwds_9_tftottipo_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class rubrostotaleswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00702( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV66Contabilidad_rubrostotaleswwds_9_tftottipo_sels ,
                                             short A1930TotSts ,
                                             GxSimpleCollection<short> AV75Contabilidad_rubrostotaleswwds_18_tftotsts_sels ,
                                             string AV58Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 ,
                                             string AV59Contabilidad_rubrostotaleswwds_2_tottipo1 ,
                                             bool AV60Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 ,
                                             string AV61Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 ,
                                             string AV62Contabilidad_rubrostotaleswwds_5_tottipo2 ,
                                             bool AV63Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 ,
                                             string AV64Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 ,
                                             string AV65Contabilidad_rubrostotaleswwds_8_tottipo3 ,
                                             int AV66Contabilidad_rubrostotaleswwds_9_tftottipo_sels_Count ,
                                             int AV67Contabilidad_rubrostotaleswwds_10_tftotrub ,
                                             int AV68Contabilidad_rubrostotaleswwds_11_tftotrub_to ,
                                             string AV70Contabilidad_rubrostotaleswwds_13_tftotdsc_sel ,
                                             string AV69Contabilidad_rubrostotaleswwds_12_tftotdsc ,
                                             string AV72Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel ,
                                             string AV71Contabilidad_rubrostotaleswwds_14_tftotdsctot ,
                                             short AV73Contabilidad_rubrostotaleswwds_16_tftotord ,
                                             short AV74Contabilidad_rubrostotaleswwds_17_tftotord_to ,
                                             int AV75Contabilidad_rubrostotaleswwds_18_tftotsts_sels_Count ,
                                             int A115TotRub ,
                                             string A1928TotDsc ,
                                             string A1929TotDscTot ,
                                             short A120TotOrd ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[11];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TotSts], [TotOrd], [TotDscTot], [TotDsc], [TotRub], [TotTipo] FROM [CBRUBROST]";
         if ( ( StringUtil.StrCmp(AV58Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Contabilidad_rubrostotaleswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV59Contabilidad_rubrostotaleswwds_2_tottipo1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( AV60Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contabilidad_rubrostotaleswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV62Contabilidad_rubrostotaleswwds_5_tottipo2)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV63Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_rubrostotaleswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV65Contabilidad_rubrostotaleswwds_8_tottipo3)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV66Contabilidad_rubrostotaleswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV66Contabilidad_rubrostotaleswwds_9_tftottipo_sels, "[TotTipo] IN (", ")")+")");
         }
         if ( ! (0==AV67Contabilidad_rubrostotaleswwds_10_tftotrub) )
         {
            AddWhere(sWhereString, "([TotRub] >= @AV67Contabilidad_rubrostotaleswwds_10_tftotrub)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV68Contabilidad_rubrostotaleswwds_11_tftotrub_to) )
         {
            AddWhere(sWhereString, "([TotRub] <= @AV68Contabilidad_rubrostotaleswwds_11_tftotrub_to)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_rubrostotaleswwds_13_tftotdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_rubrostotaleswwds_12_tftotdsc)) ) )
         {
            AddWhere(sWhereString, "([TotDsc] like @lV69Contabilidad_rubrostotaleswwds_12_tftotdsc)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_rubrostotaleswwds_13_tftotdsc_sel)) )
         {
            AddWhere(sWhereString, "([TotDsc] = @AV70Contabilidad_rubrostotaleswwds_13_tftotdsc_sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_rubrostotaleswwds_14_tftotdsctot)) ) )
         {
            AddWhere(sWhereString, "([TotDscTot] like @lV71Contabilidad_rubrostotaleswwds_14_tftotdsctot)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel)) )
         {
            AddWhere(sWhereString, "([TotDscTot] = @AV72Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV73Contabilidad_rubrostotaleswwds_16_tftotord) )
         {
            AddWhere(sWhereString, "([TotOrd] >= @AV73Contabilidad_rubrostotaleswwds_16_tftotord)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (0==AV74Contabilidad_rubrostotaleswwds_17_tftotord_to) )
         {
            AddWhere(sWhereString, "([TotOrd] <= @AV74Contabilidad_rubrostotaleswwds_17_tftotord_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV75Contabilidad_rubrostotaleswwds_18_tftotsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Contabilidad_rubrostotaleswwds_18_tftotsts_sels, "[TotSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [TotTipo], [TotRub]";
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
            scmdbuf += " ORDER BY [TotDsc]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TotDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TotDscTot]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TotDscTot] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TotOrd]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TotOrd] DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TotSts]";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TotSts] DESC";
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
                     return conditional_P00702(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (int)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP00702;
          prmP00702 = new Object[] {
          new ParDef("@AV59Contabilidad_rubrostotaleswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV62Contabilidad_rubrostotaleswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV65Contabilidad_rubrostotaleswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@AV67Contabilidad_rubrostotaleswwds_10_tftotrub",GXType.Int32,6,0) ,
          new ParDef("@AV68Contabilidad_rubrostotaleswwds_11_tftotrub_to",GXType.Int32,6,0) ,
          new ParDef("@lV69Contabilidad_rubrostotaleswwds_12_tftotdsc",GXType.NChar,100,0) ,
          new ParDef("@AV70Contabilidad_rubrostotaleswwds_13_tftotdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV71Contabilidad_rubrostotaleswwds_14_tftotdsctot",GXType.NChar,100,0) ,
          new ParDef("@AV72Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV73Contabilidad_rubrostotaleswwds_16_tftotord",GXType.Int16,2,0) ,
          new ParDef("@AV74Contabilidad_rubrostotaleswwds_17_tftotord_to",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00702", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00702,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
       }
    }

 }

}
