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
   public class conceptosordenesserviciowwexport : GXProcedure
   {
      public conceptosordenesserviciowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptosordenesserviciowwexport( IGxContext context )
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
         conceptosordenesserviciowwexport objconceptosordenesserviciowwexport;
         objconceptosordenesserviciowwexport = new conceptosordenesserviciowwexport();
         objconceptosordenesserviciowwexport.AV11Filename = "" ;
         objconceptosordenesserviciowwexport.AV12ErrorMessage = "" ;
         objconceptosordenesserviciowwexport.context.SetSubmitInitialConfig(context);
         objconceptosordenesserviciowwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptosordenesserviciowwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptosordenesserviciowwexport)stateInfo).executePrivate();
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
         AV11Filename = "ConceptosOrdenesServicioWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PSERCONCDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20PSerConcDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20PSerConcDsc1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20PSerConcDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PSERCONCDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24PSerConcDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24PSerConcDsc2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24PSerConcDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PSERCONCDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28PSerConcDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28PSerConcDsc3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28PSerConcDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFPSerConcCod) && (0==AV35TFPSerConcCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Item") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFPSerConcCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFPSerConcCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFPSerConcDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Concepto") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFPSerConcDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPSerConcDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Concepto") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFPSerConcDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV39TFPSerConcTipo_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo Distribuci?n") ;
            AV13CellRow = GXt_int2;
            AV44i = 1;
            AV47GXV1 = 1;
            while ( AV47GXV1 <= AV39TFPSerConcTipo_Sels.Count )
            {
               AV40TFPSerConcTipo_Sel = ((string)AV39TFPSerConcTipo_Sels.Item(AV47GXV1));
               if ( AV44i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV40TFPSerConcTipo_Sel), "O") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Horas Mano de Obra";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV40TFPSerConcTipo_Sel), "M") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Horas Maquinas";
               }
               AV44i = (long)(AV44i+1);
               AV47GXV1 = (int)(AV47GXV1+1);
            }
         }
         if ( ! ( ( AV42TFPSerConcSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV44i = 1;
            AV48GXV2 = 1;
            while ( AV48GXV2 <= AV42TFPSerConcSts_Sels.Count )
            {
               AV43TFPSerConcSts_Sel = (short)(AV42TFPSerConcSts_Sels.GetNumeric(AV48GXV2));
               if ( AV44i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV43TFPSerConcSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Activo";
               }
               else if ( AV43TFPSerConcSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Inactivo";
               }
               AV44i = (long)(AV44i+1);
               AV48GXV2 = (int)(AV48GXV2+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Item";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Concepto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Tipo Distribuci?n";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV50Produccion_conceptosordenesserviciowwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV51Produccion_conceptosordenesserviciowwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 = AV20PSerConcDsc1;
         AV53Produccion_conceptosordenesserviciowwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV54Produccion_conceptosordenesserviciowwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV55Produccion_conceptosordenesserviciowwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 = AV24PSerConcDsc2;
         AV57Produccion_conceptosordenesserviciowwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV58Produccion_conceptosordenesserviciowwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV59Produccion_conceptosordenesserviciowwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 = AV28PSerConcDsc3;
         AV61Produccion_conceptosordenesserviciowwds_12_tfpserconccod = AV34TFPSerConcCod;
         AV62Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to = AV35TFPSerConcCod_To;
         AV63Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc = AV36TFPSerConcDsc;
         AV64Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel = AV37TFPSerConcDsc_Sel;
         AV65Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels = AV39TFPSerConcTipo_Sels;
         AV66Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels = AV42TFPSerConcSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1797PSerConcTipo ,
                                              AV65Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels ,
                                              A1796PSerConcSts ,
                                              AV66Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels ,
                                              AV50Produccion_conceptosordenesserviciowwds_1_dynamicfiltersselector1 ,
                                              AV51Produccion_conceptosordenesserviciowwds_2_dynamicfiltersoperator1 ,
                                              AV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 ,
                                              AV53Produccion_conceptosordenesserviciowwds_4_dynamicfiltersenabled2 ,
                                              AV54Produccion_conceptosordenesserviciowwds_5_dynamicfiltersselector2 ,
                                              AV55Produccion_conceptosordenesserviciowwds_6_dynamicfiltersoperator2 ,
                                              AV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 ,
                                              AV57Produccion_conceptosordenesserviciowwds_8_dynamicfiltersenabled3 ,
                                              AV58Produccion_conceptosordenesserviciowwds_9_dynamicfiltersselector3 ,
                                              AV59Produccion_conceptosordenesserviciowwds_10_dynamicfiltersoperator3 ,
                                              AV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 ,
                                              AV61Produccion_conceptosordenesserviciowwds_12_tfpserconccod ,
                                              AV62Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to ,
                                              AV64Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel ,
                                              AV63Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc ,
                                              AV65Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels.Count ,
                                              AV66Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels.Count ,
                                              A1795PSerConcDsc ,
                                              A332PSerConcCod ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 = StringUtil.Concat( StringUtil.RTrim( AV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1), "%", "");
         lV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 = StringUtil.Concat( StringUtil.RTrim( AV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1), "%", "");
         lV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 = StringUtil.Concat( StringUtil.RTrim( AV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2), "%", "");
         lV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 = StringUtil.Concat( StringUtil.RTrim( AV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2), "%", "");
         lV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 = StringUtil.Concat( StringUtil.RTrim( AV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3), "%", "");
         lV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 = StringUtil.Concat( StringUtil.RTrim( AV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3), "%", "");
         lV63Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc = StringUtil.Concat( StringUtil.RTrim( AV63Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc), "%", "");
         /* Using cursor P006D2 */
         pr_default.execute(0, new Object[] {lV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1, lV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1, lV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2, lV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2, lV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3, lV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3, AV61Produccion_conceptosordenesserviciowwds_12_tfpserconccod, AV62Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to, lV63Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc, AV64Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1796PSerConcSts = P006D2_A1796PSerConcSts[0];
            A1797PSerConcTipo = P006D2_A1797PSerConcTipo[0];
            A332PSerConcCod = P006D2_A332PSerConcCod[0];
            A1795PSerConcDsc = P006D2_A1795PSerConcDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A332PSerConcCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1795PSerConcDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( A1797PSerConcTipo), "O") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Horas Mano de Obra";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A1797PSerConcTipo), "M") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Horas Maquinas";
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A1796PSerConcSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Activo";
            }
            else if ( A1796PSerConcSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Inactivo";
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
         if ( StringUtil.StrCmp(AV30Session.Get("Produccion.ConceptosOrdenesServicioWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Produccion.ConceptosOrdenesServicioWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Produccion.ConceptosOrdenesServicioWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV67GXV3 = 1;
         while ( AV67GXV3 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV67GXV3));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPSERCONCCOD") == 0 )
            {
               AV34TFPSerConcCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFPSerConcCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPSERCONCDSC") == 0 )
            {
               AV36TFPSerConcDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPSERCONCDSC_SEL") == 0 )
            {
               AV37TFPSerConcDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPSERCONCTIPO_SEL") == 0 )
            {
               AV38TFPSerConcTipo_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV39TFPSerConcTipo_Sels.FromJSonString(AV38TFPSerConcTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPSERCONCSTS_SEL") == 0 )
            {
               AV41TFPSerConcSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV42TFPSerConcSts_Sels.FromJSonString(AV41TFPSerConcSts_SelsJson, null);
            }
            AV67GXV3 = (int)(AV67GXV3+1);
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
         AV20PSerConcDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24PSerConcDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28PSerConcDsc3 = "";
         AV37TFPSerConcDsc_Sel = "";
         AV36TFPSerConcDsc = "";
         AV39TFPSerConcTipo_Sels = new GxSimpleCollection<string>();
         AV40TFPSerConcTipo_Sel = "";
         AV42TFPSerConcSts_Sels = new GxSimpleCollection<short>();
         AV50Produccion_conceptosordenesserviciowwds_1_dynamicfiltersselector1 = "";
         AV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 = "";
         AV54Produccion_conceptosordenesserviciowwds_5_dynamicfiltersselector2 = "";
         AV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 = "";
         AV58Produccion_conceptosordenesserviciowwds_9_dynamicfiltersselector3 = "";
         AV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 = "";
         AV63Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc = "";
         AV64Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel = "";
         AV65Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels = new GxSimpleCollection<string>();
         AV66Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 = "";
         lV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 = "";
         lV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 = "";
         lV63Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc = "";
         A1797PSerConcTipo = "";
         A1795PSerConcDsc = "";
         P006D2_A1796PSerConcSts = new short[1] ;
         P006D2_A1797PSerConcTipo = new string[] {""} ;
         P006D2_A332PSerConcCod = new int[1] ;
         P006D2_A1795PSerConcDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38TFPSerConcTipo_SelsJson = "";
         AV41TFPSerConcSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.conceptosordenesserviciowwexport__default(),
            new Object[][] {
                new Object[] {
               P006D2_A1796PSerConcSts, P006D2_A1797PSerConcTipo, P006D2_A332PSerConcCod, P006D2_A1795PSerConcDsc
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
      private short AV43TFPSerConcSts_Sel ;
      private short AV51Produccion_conceptosordenesserviciowwds_2_dynamicfiltersoperator1 ;
      private short AV55Produccion_conceptosordenesserviciowwds_6_dynamicfiltersoperator2 ;
      private short AV59Produccion_conceptosordenesserviciowwds_10_dynamicfiltersoperator3 ;
      private short A1796PSerConcSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFPSerConcCod ;
      private int AV35TFPSerConcCod_To ;
      private int AV47GXV1 ;
      private int AV48GXV2 ;
      private int AV61Produccion_conceptosordenesserviciowwds_12_tfpserconccod ;
      private int AV62Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to ;
      private int AV65Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels_Count ;
      private int AV66Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels_Count ;
      private int A332PSerConcCod ;
      private int AV67GXV3 ;
      private long AV44i ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV53Produccion_conceptosordenesserviciowwds_4_dynamicfiltersenabled2 ;
      private bool AV57Produccion_conceptosordenesserviciowwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV38TFPSerConcTipo_SelsJson ;
      private string AV41TFPSerConcSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20PSerConcDsc1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24PSerConcDsc2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28PSerConcDsc3 ;
      private string AV37TFPSerConcDsc_Sel ;
      private string AV36TFPSerConcDsc ;
      private string AV40TFPSerConcTipo_Sel ;
      private string AV50Produccion_conceptosordenesserviciowwds_1_dynamicfiltersselector1 ;
      private string AV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 ;
      private string AV54Produccion_conceptosordenesserviciowwds_5_dynamicfiltersselector2 ;
      private string AV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 ;
      private string AV58Produccion_conceptosordenesserviciowwds_9_dynamicfiltersselector3 ;
      private string AV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 ;
      private string AV63Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc ;
      private string AV64Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel ;
      private string lV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 ;
      private string lV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 ;
      private string lV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 ;
      private string lV63Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc ;
      private string A1797PSerConcTipo ;
      private string A1795PSerConcDsc ;
      private GxSimpleCollection<short> AV42TFPSerConcSts_Sels ;
      private GxSimpleCollection<short> AV66Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006D2_A1796PSerConcSts ;
      private string[] P006D2_A1797PSerConcTipo ;
      private int[] P006D2_A332PSerConcCod ;
      private string[] P006D2_A1795PSerConcDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GxSimpleCollection<string> AV39TFPSerConcTipo_Sels ;
      private GxSimpleCollection<string> AV65Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class conceptosordenesserviciowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006D2( IGxContext context ,
                                             string A1797PSerConcTipo ,
                                             GxSimpleCollection<string> AV65Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels ,
                                             short A1796PSerConcSts ,
                                             GxSimpleCollection<short> AV66Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels ,
                                             string AV50Produccion_conceptosordenesserviciowwds_1_dynamicfiltersselector1 ,
                                             short AV51Produccion_conceptosordenesserviciowwds_2_dynamicfiltersoperator1 ,
                                             string AV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 ,
                                             bool AV53Produccion_conceptosordenesserviciowwds_4_dynamicfiltersenabled2 ,
                                             string AV54Produccion_conceptosordenesserviciowwds_5_dynamicfiltersselector2 ,
                                             short AV55Produccion_conceptosordenesserviciowwds_6_dynamicfiltersoperator2 ,
                                             string AV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 ,
                                             bool AV57Produccion_conceptosordenesserviciowwds_8_dynamicfiltersenabled3 ,
                                             string AV58Produccion_conceptosordenesserviciowwds_9_dynamicfiltersselector3 ,
                                             short AV59Produccion_conceptosordenesserviciowwds_10_dynamicfiltersoperator3 ,
                                             string AV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 ,
                                             int AV61Produccion_conceptosordenesserviciowwds_12_tfpserconccod ,
                                             int AV62Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to ,
                                             string AV64Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel ,
                                             string AV63Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc ,
                                             int AV65Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels_Count ,
                                             int AV66Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels_Count ,
                                             string A1795PSerConcDsc ,
                                             int A332PSerConcCod ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [PSerConcSts], [PSerConcTipo], [PSerConcCod], [PSerConcDsc] FROM [POSERCONCEPTOS]";
         if ( ( StringUtil.StrCmp(AV50Produccion_conceptosordenesserviciowwds_1_dynamicfiltersselector1, "PSERCONCDSC") == 0 ) && ( AV51Produccion_conceptosordenesserviciowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1)) ) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] like @lV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Produccion_conceptosordenesserviciowwds_1_dynamicfiltersselector1, "PSERCONCDSC") == 0 ) && ( AV51Produccion_conceptosordenesserviciowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1)) ) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] like '%' + @lV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV53Produccion_conceptosordenesserviciowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Produccion_conceptosordenesserviciowwds_5_dynamicfiltersselector2, "PSERCONCDSC") == 0 ) && ( AV55Produccion_conceptosordenesserviciowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2)) ) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] like @lV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV53Produccion_conceptosordenesserviciowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Produccion_conceptosordenesserviciowwds_5_dynamicfiltersselector2, "PSERCONCDSC") == 0 ) && ( AV55Produccion_conceptosordenesserviciowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2)) ) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] like '%' + @lV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV57Produccion_conceptosordenesserviciowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Produccion_conceptosordenesserviciowwds_9_dynamicfiltersselector3, "PSERCONCDSC") == 0 ) && ( AV59Produccion_conceptosordenesserviciowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3)) ) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] like @lV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV57Produccion_conceptosordenesserviciowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Produccion_conceptosordenesserviciowwds_9_dynamicfiltersselector3, "PSERCONCDSC") == 0 ) && ( AV59Produccion_conceptosordenesserviciowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3)) ) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] like '%' + @lV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV61Produccion_conceptosordenesserviciowwds_12_tfpserconccod) )
         {
            AddWhere(sWhereString, "([PSerConcCod] >= @AV61Produccion_conceptosordenesserviciowwds_12_tfpserconccod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV62Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to) )
         {
            AddWhere(sWhereString, "([PSerConcCod] <= @AV62Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc)) ) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] like @lV63Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel)) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] = @AV64Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV65Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV65Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels, "[PSerConcTipo] IN (", ")")+")");
         }
         if ( AV66Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV66Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels, "[PSerConcSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [PSerConcDsc]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PSerConcDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [PSerConcCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PSerConcCod] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [PSerConcTipo]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PSerConcTipo] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [PSerConcSts]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PSerConcSts] DESC";
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
                     return conditional_P006D2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP006D2;
          prmP006D2 = new Object[] {
          new ParDef("@lV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV52Produccion_conceptosordenesserviciowwds_3_pserconcdsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV56Produccion_conceptosordenesserviciowwds_7_pserconcdsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3",GXType.NVarChar,100,0) ,
          new ParDef("@lV60Produccion_conceptosordenesserviciowwds_11_pserconcdsc3",GXType.NVarChar,100,0) ,
          new ParDef("@AV61Produccion_conceptosordenesserviciowwds_12_tfpserconccod",GXType.Int32,6,0) ,
          new ParDef("@AV62Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to",GXType.Int32,6,0) ,
          new ParDef("@lV63Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV64Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006D2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
