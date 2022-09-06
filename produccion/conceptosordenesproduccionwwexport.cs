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
namespace GeneXus.Programs.produccion {
   public class conceptosordenesproduccionwwexport : GXProcedure
   {
      public conceptosordenesproduccionwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptosordenesproduccionwwexport( IGxContext context )
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
         conceptosordenesproduccionwwexport objconceptosordenesproduccionwwexport;
         objconceptosordenesproduccionwwexport = new conceptosordenesproduccionwwexport();
         objconceptosordenesproduccionwwexport.AV11Filename = "" ;
         objconceptosordenesproduccionwwexport.AV12ErrorMessage = "" ;
         objconceptosordenesproduccionwwexport.context.SetSubmitInitialConfig(context);
         objconceptosordenesproduccionwwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptosordenesproduccionwwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptosordenesproduccionwwexport)stateInfo).executePrivate();
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
         AV11Filename = "ConceptosOrdenesProduccionWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "POCONCDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20PoConcDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20PoConcDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20PoConcDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "POCONCDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24PoConcDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24PoConcDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24PoConcDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "POCONCDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28PoConcDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28PoConcDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28PoConcDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFPoConcCod) && (0==AV35TFPoConcCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Concepto") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFPoConcCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFPoConcCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFPoConcDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Concepto") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFPoConcDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPoConcDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Concepto") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFPoConcDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV45TFPoConcTip_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Distribución") ;
            AV13CellRow = GXt_int2;
            AV43i = 1;
            AV48GXV1 = 1;
            while ( AV48GXV1 <= AV45TFPoConcTip_Sels.Count )
            {
               AV39TFPoConcTip_Sel = AV45TFPoConcTip_Sels.GetString(AV48GXV1);
               if ( AV43i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV39TFPoConcTip_Sel), "C") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Cantidad";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV39TFPoConcTip_Sel), "T") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Costo";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV39TFPoConcTip_Sel), "H") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Horas";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV39TFPoConcTip_Sel), "P") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Peso";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV39TFPoConcTip_Sel), "V") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Volumen";
               }
               AV43i = (long)(AV43i+1);
               AV48GXV1 = (int)(AV48GXV1+1);
            }
         }
         if ( ! ( ( AV41TFPoConcSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV43i = 1;
            AV49GXV2 = 1;
            while ( AV49GXV2 <= AV41TFPoConcSts_Sels.Count )
            {
               AV42TFPoConcSts_Sel = (short)(AV41TFPoConcSts_Sels.GetNumeric(AV49GXV2));
               if ( AV43i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV42TFPoConcSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV42TFPoConcSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV43i = (long)(AV43i+1);
               AV49GXV2 = (int)(AV49GXV2+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Codigo Concepto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Concepto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Tipo de Distribución";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV51Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV52Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = AV20PoConcDsc1;
         AV54Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV55Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV56Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = AV24PoConcDsc2;
         AV58Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV59Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV60Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = AV28PoConcDsc3;
         AV62Produccion_conceptosordenesproduccionwwds_12_tfpoconccod = AV34TFPoConcCod;
         AV63Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to = AV35TFPoConcCod_To;
         AV64Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = AV36TFPoConcDsc;
         AV65Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel = AV37TFPoConcDsc_Sel;
         AV66Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels = AV45TFPoConcTip_Sels;
         AV67Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels = AV41TFPoConcSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1650PoConcTip ,
                                              AV66Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels ,
                                              A1649PoConcSts ,
                                              AV67Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels ,
                                              AV51Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 ,
                                              AV52Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 ,
                                              AV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ,
                                              AV54Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 ,
                                              AV55Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 ,
                                              AV56Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 ,
                                              AV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ,
                                              AV58Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 ,
                                              AV59Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 ,
                                              AV60Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 ,
                                              AV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ,
                                              AV62Produccion_conceptosordenesproduccionwwds_12_tfpoconccod ,
                                              AV63Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to ,
                                              AV65Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel ,
                                              AV64Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ,
                                              AV66Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels.Count ,
                                              AV67Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels.Count ,
                                              A1648PoConcDsc ,
                                              A313PoConcCod ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1), 100, "%");
         lV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1), 100, "%");
         lV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2), 100, "%");
         lV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2), 100, "%");
         lV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3), 100, "%");
         lV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3), 100, "%");
         lV64Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = StringUtil.PadR( StringUtil.RTrim( AV64Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc), 100, "%");
         /* Using cursor P00692 */
         pr_default.execute(0, new Object[] {lV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1, lV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1, lV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2, lV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2, lV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3, lV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3, AV62Produccion_conceptosordenesproduccionwwds_12_tfpoconccod, AV63Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to, lV64Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc, AV65Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1649PoConcSts = P00692_A1649PoConcSts[0];
            A1650PoConcTip = P00692_A1650PoConcTip[0];
            A313PoConcCod = P00692_A313PoConcCod[0];
            A1648PoConcDsc = P00692_A1648PoConcDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A313PoConcCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1648PoConcDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( A1650PoConcTip), "C") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Cantidad";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A1650PoConcTip), "T") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Costo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A1650PoConcTip), "H") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Horas";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A1650PoConcTip), "P") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Peso";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A1650PoConcTip), "V") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Volumen";
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A1649PoConcSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "ACTIVO";
            }
            else if ( A1649PoConcSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "INACTIVO";
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
         if ( StringUtil.StrCmp(AV30Session.Get("Produccion.ConceptosOrdenesProduccionWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Produccion.ConceptosOrdenesProduccionWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Produccion.ConceptosOrdenesProduccionWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV68GXV3 = 1;
         while ( AV68GXV3 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV68GXV3));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPOCONCCOD") == 0 )
            {
               AV34TFPoConcCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFPoConcCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPOCONCDSC") == 0 )
            {
               AV36TFPoConcDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPOCONCDSC_SEL") == 0 )
            {
               AV37TFPoConcDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPOCONCTIP_SEL") == 0 )
            {
               AV44TFPoConcTip_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV45TFPoConcTip_Sels.FromJSonString(AV44TFPoConcTip_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPOCONCSTS_SEL") == 0 )
            {
               AV40TFPoConcSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV41TFPoConcSts_Sels.FromJSonString(AV40TFPoConcSts_SelsJson, null);
            }
            AV68GXV3 = (int)(AV68GXV3+1);
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
         AV20PoConcDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24PoConcDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28PoConcDsc3 = "";
         AV37TFPoConcDsc_Sel = "";
         AV36TFPoConcDsc = "";
         AV45TFPoConcTip_Sels = new GxSimpleCollection<string>();
         AV39TFPoConcTip_Sel = "";
         AV41TFPoConcSts_Sels = new GxSimpleCollection<short>();
         AV51Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 = "";
         AV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = "";
         AV55Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 = "";
         AV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = "";
         AV59Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 = "";
         AV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = "";
         AV64Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = "";
         AV65Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel = "";
         AV66Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels = new GxSimpleCollection<string>();
         AV67Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = "";
         lV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = "";
         lV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = "";
         lV64Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = "";
         A1650PoConcTip = "";
         A1648PoConcDsc = "";
         P00692_A1649PoConcSts = new short[1] ;
         P00692_A1650PoConcTip = new string[] {""} ;
         P00692_A313PoConcCod = new int[1] ;
         P00692_A1648PoConcDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV44TFPoConcTip_SelsJson = "";
         AV40TFPoConcSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.conceptosordenesproduccionwwexport__default(),
            new Object[][] {
                new Object[] {
               P00692_A1649PoConcSts, P00692_A1650PoConcTip, P00692_A313PoConcCod, P00692_A1648PoConcDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV42TFPoConcSts_Sel ;
      private short AV52Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 ;
      private short AV56Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 ;
      private short AV60Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 ;
      private short A1649PoConcSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFPoConcCod ;
      private int AV35TFPoConcCod_To ;
      private int AV48GXV1 ;
      private int AV49GXV2 ;
      private int AV62Produccion_conceptosordenesproduccionwwds_12_tfpoconccod ;
      private int AV63Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to ;
      private int AV66Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels_Count ;
      private int AV67Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels_Count ;
      private int A313PoConcCod ;
      private int AV68GXV3 ;
      private long AV43i ;
      private string AV20PoConcDsc1 ;
      private string AV24PoConcDsc2 ;
      private string AV28PoConcDsc3 ;
      private string AV37TFPoConcDsc_Sel ;
      private string AV36TFPoConcDsc ;
      private string AV39TFPoConcTip_Sel ;
      private string AV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ;
      private string AV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ;
      private string AV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ;
      private string AV64Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ;
      private string AV65Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel ;
      private string scmdbuf ;
      private string lV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ;
      private string lV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ;
      private string lV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ;
      private string lV64Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ;
      private string A1650PoConcTip ;
      private string A1648PoConcDsc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV54Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 ;
      private bool AV58Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV44TFPoConcTip_SelsJson ;
      private string AV40TFPoConcSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV51Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 ;
      private string AV55Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 ;
      private string AV59Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV41TFPoConcSts_Sels ;
      private GxSimpleCollection<short> AV67Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00692_A1649PoConcSts ;
      private string[] P00692_A1650PoConcTip ;
      private int[] P00692_A313PoConcCod ;
      private string[] P00692_A1648PoConcDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GxSimpleCollection<string> AV45TFPoConcTip_Sels ;
      private GxSimpleCollection<string> AV66Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class conceptosordenesproduccionwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00692( IGxContext context ,
                                             string A1650PoConcTip ,
                                             GxSimpleCollection<string> AV66Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels ,
                                             short A1649PoConcSts ,
                                             GxSimpleCollection<short> AV67Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels ,
                                             string AV51Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 ,
                                             short AV52Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 ,
                                             string AV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ,
                                             bool AV54Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 ,
                                             string AV55Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 ,
                                             short AV56Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 ,
                                             string AV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ,
                                             bool AV58Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 ,
                                             string AV59Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 ,
                                             short AV60Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 ,
                                             string AV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ,
                                             int AV62Produccion_conceptosordenesproduccionwwds_12_tfpoconccod ,
                                             int AV63Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to ,
                                             string AV65Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel ,
                                             string AV64Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ,
                                             int AV66Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels_Count ,
                                             int AV67Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels_Count ,
                                             string A1648PoConcDsc ,
                                             int A313PoConcCod ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [PoConcSts], [PoConcTip], [PoConcCod], [PoConcDsc] FROM [POCONCEPTOS]";
         if ( ( StringUtil.StrCmp(AV51Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1, "POCONCDSC") == 0 ) && ( AV52Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1, "POCONCDSC") == 0 ) && ( AV52Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV54Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2, "POCONCDSC") == 0 ) && ( AV56Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV54Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2, "POCONCDSC") == 0 ) && ( AV56Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV58Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3, "POCONCDSC") == 0 ) && ( AV60Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV58Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3, "POCONCDSC") == 0 ) && ( AV60Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV62Produccion_conceptosordenesproduccionwwds_12_tfpoconccod) )
         {
            AddWhere(sWhereString, "([PoConcCod] >= @AV62Produccion_conceptosordenesproduccionwwds_12_tfpoconccod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV63Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to) )
         {
            AddWhere(sWhereString, "([PoConcCod] <= @AV63Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV64Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)) )
         {
            AddWhere(sWhereString, "([PoConcDsc] = @AV65Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV66Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV66Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels, "[PoConcTip] IN (", ")")+")");
         }
         if ( AV67Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV67Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels, "[PoConcSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [PoConcDsc]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PoConcDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [PoConcCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PoConcCod] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [PoConcTip]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PoConcTip] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [PoConcSts]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PoConcSts] DESC";
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
                     return conditional_P00692(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP00692;
          prmP00692 = new Object[] {
          new ParDef("@lV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Produccion_conceptosordenesproduccionwwds_3_poconcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Produccion_conceptosordenesproduccionwwds_7_poconcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Produccion_conceptosordenesproduccionwwds_11_poconcdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV62Produccion_conceptosordenesproduccionwwds_12_tfpoconccod",GXType.Int32,6,0) ,
          new ParDef("@AV63Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00692", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00692,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
