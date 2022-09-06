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
   public class tipoasientoswwexport : GXProcedure
   {
      public tipoasientoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipoasientoswwexport( IGxContext context )
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
         tipoasientoswwexport objtipoasientoswwexport;
         objtipoasientoswwexport = new tipoasientoswwexport();
         objtipoasientoswwexport.AV11Filename = "" ;
         objtipoasientoswwexport.AV12ErrorMessage = "" ;
         objtipoasientoswwexport.context.SetSubmitInitialConfig(context);
         objtipoasientoswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipoasientoswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipoasientoswwexport)stateInfo).executePrivate();
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
         AV11Filename = "TipoAsientosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TASIDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20TASIDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TASIDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo Asiento", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo Asiento", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20TASIDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TASIDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24TASIDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TASIDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo Asiento", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo Asiento", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24TASIDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TASIDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28TASIDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TASIDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo Asiento", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo Asiento", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28TASIDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFTASICod) && (0==AV35TFTASICod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFTASICod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFTASICod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTASIDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo Asiento") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFTASIDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTASIDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo Asiento") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFTASIDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFTASIAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFTASIAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTASIAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFTASIAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV41TFTASISts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV43i = 1;
            AV46GXV1 = 1;
            while ( AV46GXV1 <= AV41TFTASISts_Sels.Count )
            {
               AV42TFTASISts_Sel = (short)(AV41TFTASISts_Sels.GetNumeric(AV46GXV1));
               if ( AV43i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV42TFTASISts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV42TFTASISts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV43i = (long)(AV43i+1);
               AV46GXV1 = (int)(AV46GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Codigo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Tipo Asiento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Abreviatura";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV48Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV49Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV50Contabilidad_tipoasientoswwds_3_tasidsc1 = AV20TASIDsc1;
         AV51Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV52Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV53Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV54Contabilidad_tipoasientoswwds_7_tasidsc2 = AV24TASIDsc2;
         AV55Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV56Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV57Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV58Contabilidad_tipoasientoswwds_11_tasidsc3 = AV28TASIDsc3;
         AV59Contabilidad_tipoasientoswwds_12_tftasicod = AV34TFTASICod;
         AV60Contabilidad_tipoasientoswwds_13_tftasicod_to = AV35TFTASICod_To;
         AV61Contabilidad_tipoasientoswwds_14_tftasidsc = AV36TFTASIDsc;
         AV62Contabilidad_tipoasientoswwds_15_tftasidsc_sel = AV37TFTASIDsc_Sel;
         AV63Contabilidad_tipoasientoswwds_16_tftasiabr = AV38TFTASIAbr;
         AV64Contabilidad_tipoasientoswwds_17_tftasiabr_sel = AV39TFTASIAbr_Sel;
         AV65Contabilidad_tipoasientoswwds_18_tftasists_sels = AV41TFTASISts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1896TASISts ,
                                              AV65Contabilidad_tipoasientoswwds_18_tftasists_sels ,
                                              AV48Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1 ,
                                              AV49Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 ,
                                              AV50Contabilidad_tipoasientoswwds_3_tasidsc1 ,
                                              AV51Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 ,
                                              AV52Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2 ,
                                              AV53Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 ,
                                              AV54Contabilidad_tipoasientoswwds_7_tasidsc2 ,
                                              AV55Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 ,
                                              AV56Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3 ,
                                              AV57Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 ,
                                              AV58Contabilidad_tipoasientoswwds_11_tasidsc3 ,
                                              AV59Contabilidad_tipoasientoswwds_12_tftasicod ,
                                              AV60Contabilidad_tipoasientoswwds_13_tftasicod_to ,
                                              AV62Contabilidad_tipoasientoswwds_15_tftasidsc_sel ,
                                              AV61Contabilidad_tipoasientoswwds_14_tftasidsc ,
                                              AV64Contabilidad_tipoasientoswwds_17_tftasiabr_sel ,
                                              AV63Contabilidad_tipoasientoswwds_16_tftasiabr ,
                                              AV65Contabilidad_tipoasientoswwds_18_tftasists_sels.Count ,
                                              A1895TASIDsc ,
                                              A126TASICod ,
                                              A1894TASIAbr ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV50Contabilidad_tipoasientoswwds_3_tasidsc1 = StringUtil.PadR( StringUtil.RTrim( AV50Contabilidad_tipoasientoswwds_3_tasidsc1), 100, "%");
         lV50Contabilidad_tipoasientoswwds_3_tasidsc1 = StringUtil.PadR( StringUtil.RTrim( AV50Contabilidad_tipoasientoswwds_3_tasidsc1), 100, "%");
         lV54Contabilidad_tipoasientoswwds_7_tasidsc2 = StringUtil.PadR( StringUtil.RTrim( AV54Contabilidad_tipoasientoswwds_7_tasidsc2), 100, "%");
         lV54Contabilidad_tipoasientoswwds_7_tasidsc2 = StringUtil.PadR( StringUtil.RTrim( AV54Contabilidad_tipoasientoswwds_7_tasidsc2), 100, "%");
         lV58Contabilidad_tipoasientoswwds_11_tasidsc3 = StringUtil.PadR( StringUtil.RTrim( AV58Contabilidad_tipoasientoswwds_11_tasidsc3), 100, "%");
         lV58Contabilidad_tipoasientoswwds_11_tasidsc3 = StringUtil.PadR( StringUtil.RTrim( AV58Contabilidad_tipoasientoswwds_11_tasidsc3), 100, "%");
         lV61Contabilidad_tipoasientoswwds_14_tftasidsc = StringUtil.PadR( StringUtil.RTrim( AV61Contabilidad_tipoasientoswwds_14_tftasidsc), 100, "%");
         lV63Contabilidad_tipoasientoswwds_16_tftasiabr = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_tipoasientoswwds_16_tftasiabr), 5, "%");
         /* Using cursor P007A2 */
         pr_default.execute(0, new Object[] {lV50Contabilidad_tipoasientoswwds_3_tasidsc1, lV50Contabilidad_tipoasientoswwds_3_tasidsc1, lV54Contabilidad_tipoasientoswwds_7_tasidsc2, lV54Contabilidad_tipoasientoswwds_7_tasidsc2, lV58Contabilidad_tipoasientoswwds_11_tasidsc3, lV58Contabilidad_tipoasientoswwds_11_tasidsc3, AV59Contabilidad_tipoasientoswwds_12_tftasicod, AV60Contabilidad_tipoasientoswwds_13_tftasicod_to, lV61Contabilidad_tipoasientoswwds_14_tftasidsc, AV62Contabilidad_tipoasientoswwds_15_tftasidsc_sel, lV63Contabilidad_tipoasientoswwds_16_tftasiabr, AV64Contabilidad_tipoasientoswwds_17_tftasiabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1896TASISts = P007A2_A1896TASISts[0];
            A1894TASIAbr = P007A2_A1894TASIAbr[0];
            A126TASICod = P007A2_A126TASICod[0];
            A1895TASIDsc = P007A2_A1895TASIDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A126TASICod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1895TASIDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1894TASIAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A1896TASISts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "ACTIVO";
            }
            else if ( A1896TASISts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Contabilidad.TipoAsientosWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.TipoAsientosWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Contabilidad.TipoAsientosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV66GXV2 = 1;
         while ( AV66GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV66GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTASICOD") == 0 )
            {
               AV34TFTASICod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFTASICod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTASIDSC") == 0 )
            {
               AV36TFTASIDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTASIDSC_SEL") == 0 )
            {
               AV37TFTASIDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTASIABR") == 0 )
            {
               AV38TFTASIAbr = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTASIABR_SEL") == 0 )
            {
               AV39TFTASIAbr_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTASISTS_SEL") == 0 )
            {
               AV40TFTASISts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV41TFTASISts_Sels.FromJSonString(AV40TFTASISts_SelsJson, null);
            }
            AV66GXV2 = (int)(AV66GXV2+1);
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
         AV20TASIDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24TASIDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28TASIDsc3 = "";
         AV37TFTASIDsc_Sel = "";
         AV36TFTASIDsc = "";
         AV39TFTASIAbr_Sel = "";
         AV38TFTASIAbr = "";
         AV41TFTASISts_Sels = new GxSimpleCollection<short>();
         AV48Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1 = "";
         AV50Contabilidad_tipoasientoswwds_3_tasidsc1 = "";
         AV52Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2 = "";
         AV54Contabilidad_tipoasientoswwds_7_tasidsc2 = "";
         AV56Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3 = "";
         AV58Contabilidad_tipoasientoswwds_11_tasidsc3 = "";
         AV61Contabilidad_tipoasientoswwds_14_tftasidsc = "";
         AV62Contabilidad_tipoasientoswwds_15_tftasidsc_sel = "";
         AV63Contabilidad_tipoasientoswwds_16_tftasiabr = "";
         AV64Contabilidad_tipoasientoswwds_17_tftasiabr_sel = "";
         AV65Contabilidad_tipoasientoswwds_18_tftasists_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV50Contabilidad_tipoasientoswwds_3_tasidsc1 = "";
         lV54Contabilidad_tipoasientoswwds_7_tasidsc2 = "";
         lV58Contabilidad_tipoasientoswwds_11_tasidsc3 = "";
         lV61Contabilidad_tipoasientoswwds_14_tftasidsc = "";
         lV63Contabilidad_tipoasientoswwds_16_tftasiabr = "";
         A1895TASIDsc = "";
         A1894TASIAbr = "";
         P007A2_A1896TASISts = new short[1] ;
         P007A2_A1894TASIAbr = new string[] {""} ;
         P007A2_A126TASICod = new int[1] ;
         P007A2_A1895TASIDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40TFTASISts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.tipoasientoswwexport__default(),
            new Object[][] {
                new Object[] {
               P007A2_A1896TASISts, P007A2_A1894TASIAbr, P007A2_A126TASICod, P007A2_A1895TASIDsc
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
      private short AV42TFTASISts_Sel ;
      private short AV49Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 ;
      private short AV53Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 ;
      private short AV57Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 ;
      private short A1896TASISts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFTASICod ;
      private int AV35TFTASICod_To ;
      private int AV46GXV1 ;
      private int AV59Contabilidad_tipoasientoswwds_12_tftasicod ;
      private int AV60Contabilidad_tipoasientoswwds_13_tftasicod_to ;
      private int AV65Contabilidad_tipoasientoswwds_18_tftasists_sels_Count ;
      private int A126TASICod ;
      private int AV66GXV2 ;
      private long AV43i ;
      private string AV20TASIDsc1 ;
      private string AV24TASIDsc2 ;
      private string AV28TASIDsc3 ;
      private string AV37TFTASIDsc_Sel ;
      private string AV36TFTASIDsc ;
      private string AV39TFTASIAbr_Sel ;
      private string AV38TFTASIAbr ;
      private string AV50Contabilidad_tipoasientoswwds_3_tasidsc1 ;
      private string AV54Contabilidad_tipoasientoswwds_7_tasidsc2 ;
      private string AV58Contabilidad_tipoasientoswwds_11_tasidsc3 ;
      private string AV61Contabilidad_tipoasientoswwds_14_tftasidsc ;
      private string AV62Contabilidad_tipoasientoswwds_15_tftasidsc_sel ;
      private string AV63Contabilidad_tipoasientoswwds_16_tftasiabr ;
      private string AV64Contabilidad_tipoasientoswwds_17_tftasiabr_sel ;
      private string scmdbuf ;
      private string lV50Contabilidad_tipoasientoswwds_3_tasidsc1 ;
      private string lV54Contabilidad_tipoasientoswwds_7_tasidsc2 ;
      private string lV58Contabilidad_tipoasientoswwds_11_tasidsc3 ;
      private string lV61Contabilidad_tipoasientoswwds_14_tftasidsc ;
      private string lV63Contabilidad_tipoasientoswwds_16_tftasiabr ;
      private string A1895TASIDsc ;
      private string A1894TASIAbr ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV51Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 ;
      private bool AV55Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV40TFTASISts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV48Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1 ;
      private string AV52Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2 ;
      private string AV56Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV41TFTASISts_Sels ;
      private GxSimpleCollection<short> AV65Contabilidad_tipoasientoswwds_18_tftasists_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P007A2_A1896TASISts ;
      private string[] P007A2_A1894TASIAbr ;
      private int[] P007A2_A126TASICod ;
      private string[] P007A2_A1895TASIDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class tipoasientoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007A2( IGxContext context ,
                                             short A1896TASISts ,
                                             GxSimpleCollection<short> AV65Contabilidad_tipoasientoswwds_18_tftasists_sels ,
                                             string AV48Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1 ,
                                             short AV49Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 ,
                                             string AV50Contabilidad_tipoasientoswwds_3_tasidsc1 ,
                                             bool AV51Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 ,
                                             string AV52Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2 ,
                                             short AV53Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 ,
                                             string AV54Contabilidad_tipoasientoswwds_7_tasidsc2 ,
                                             bool AV55Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 ,
                                             string AV56Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3 ,
                                             short AV57Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 ,
                                             string AV58Contabilidad_tipoasientoswwds_11_tasidsc3 ,
                                             int AV59Contabilidad_tipoasientoswwds_12_tftasicod ,
                                             int AV60Contabilidad_tipoasientoswwds_13_tftasicod_to ,
                                             string AV62Contabilidad_tipoasientoswwds_15_tftasidsc_sel ,
                                             string AV61Contabilidad_tipoasientoswwds_14_tftasidsc ,
                                             string AV64Contabilidad_tipoasientoswwds_17_tftasiabr_sel ,
                                             string AV63Contabilidad_tipoasientoswwds_16_tftasiabr ,
                                             int AV65Contabilidad_tipoasientoswwds_18_tftasists_sels_Count ,
                                             string A1895TASIDsc ,
                                             int A126TASICod ,
                                             string A1894TASIAbr ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TASISts], [TASIAbr], [TASICod], [TASIDsc] FROM [CBTIPOASIENTO]";
         if ( ( StringUtil.StrCmp(AV48Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1, "TASIDSC") == 0 ) && ( AV49Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Contabilidad_tipoasientoswwds_3_tasidsc1)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like @lV50Contabilidad_tipoasientoswwds_3_tasidsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV48Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1, "TASIDSC") == 0 ) && ( AV49Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Contabilidad_tipoasientoswwds_3_tasidsc1)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like '%' + @lV50Contabilidad_tipoasientoswwds_3_tasidsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV51Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV52Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2, "TASIDSC") == 0 ) && ( AV53Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Contabilidad_tipoasientoswwds_7_tasidsc2)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like @lV54Contabilidad_tipoasientoswwds_7_tasidsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV51Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV52Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2, "TASIDSC") == 0 ) && ( AV53Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Contabilidad_tipoasientoswwds_7_tasidsc2)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like '%' + @lV54Contabilidad_tipoasientoswwds_7_tasidsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV55Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3, "TASIDSC") == 0 ) && ( AV57Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contabilidad_tipoasientoswwds_11_tasidsc3)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like @lV58Contabilidad_tipoasientoswwds_11_tasidsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV55Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3, "TASIDSC") == 0 ) && ( AV57Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contabilidad_tipoasientoswwds_11_tasidsc3)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like '%' + @lV58Contabilidad_tipoasientoswwds_11_tasidsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV59Contabilidad_tipoasientoswwds_12_tftasicod) )
         {
            AddWhere(sWhereString, "([TASICod] >= @AV59Contabilidad_tipoasientoswwds_12_tftasicod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV60Contabilidad_tipoasientoswwds_13_tftasicod_to) )
         {
            AddWhere(sWhereString, "([TASICod] <= @AV60Contabilidad_tipoasientoswwds_13_tftasicod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Contabilidad_tipoasientoswwds_15_tftasidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Contabilidad_tipoasientoswwds_14_tftasidsc)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like @lV61Contabilidad_tipoasientoswwds_14_tftasidsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contabilidad_tipoasientoswwds_15_tftasidsc_sel)) )
         {
            AddWhere(sWhereString, "([TASIDsc] = @AV62Contabilidad_tipoasientoswwds_15_tftasidsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_tipoasientoswwds_17_tftasiabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_tipoasientoswwds_16_tftasiabr)) ) )
         {
            AddWhere(sWhereString, "([TASIAbr] like @lV63Contabilidad_tipoasientoswwds_16_tftasiabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_tipoasientoswwds_17_tftasiabr_sel)) )
         {
            AddWhere(sWhereString, "([TASIAbr] = @AV64Contabilidad_tipoasientoswwds_17_tftasiabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV65Contabilidad_tipoasientoswwds_18_tftasists_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV65Contabilidad_tipoasientoswwds_18_tftasists_sels, "[TASISts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TASICod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TASICod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TASIDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TASIDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TASIAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TASIAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TASISts]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TASISts] DESC";
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
                     return conditional_P007A2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP007A2;
          prmP007A2 = new Object[] {
          new ParDef("@lV50Contabilidad_tipoasientoswwds_3_tasidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV50Contabilidad_tipoasientoswwds_3_tasidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV54Contabilidad_tipoasientoswwds_7_tasidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV54Contabilidad_tipoasientoswwds_7_tasidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV58Contabilidad_tipoasientoswwds_11_tasidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV58Contabilidad_tipoasientoswwds_11_tasidsc3",GXType.NChar,100,0) ,
          new ParDef("@AV59Contabilidad_tipoasientoswwds_12_tftasicod",GXType.Int32,6,0) ,
          new ParDef("@AV60Contabilidad_tipoasientoswwds_13_tftasicod_to",GXType.Int32,6,0) ,
          new ParDef("@lV61Contabilidad_tipoasientoswwds_14_tftasidsc",GXType.NChar,100,0) ,
          new ParDef("@AV62Contabilidad_tipoasientoswwds_15_tftasidsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV63Contabilidad_tipoasientoswwds_16_tftasiabr",GXType.NChar,5,0) ,
          new ParDef("@AV64Contabilidad_tipoasientoswwds_17_tftasiabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
