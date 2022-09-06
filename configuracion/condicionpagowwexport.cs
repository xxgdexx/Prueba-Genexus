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
namespace GeneXus.Programs.configuracion {
   public class condicionpagowwexport : GXProcedure
   {
      public condicionpagowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public condicionpagowwexport( IGxContext context )
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
         condicionpagowwexport objcondicionpagowwexport;
         objcondicionpagowwexport = new condicionpagowwexport();
         objcondicionpagowwexport.AV11Filename = "" ;
         objcondicionpagowwexport.AV12ErrorMessage = "" ;
         objcondicionpagowwexport.context.SetSubmitInitialConfig(context);
         objcondicionpagowwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcondicionpagowwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((condicionpagowwexport)stateInfo).executePrivate();
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
         AV11Filename = "CondicionPagoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CONPDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20ConpDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ConpDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Condición de Pago", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Condición de Pago", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20ConpDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONPDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24ConpDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ConpDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Condición de Pago", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Condición de Pago", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24ConpDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONPDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28ConpDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ConpDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Condición de Pago", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Condición de Pago", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ConpDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFConpcod) && (0==AV35TFConpcod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFConpcod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFConpcod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFConpDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Condición de Pago") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFConpDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFConpDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Condición de Pago") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFConpDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFConpAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFConpAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFConpAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFConpAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV40TFConpDias) && (0==AV41TFConpDias_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "N° Dias") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV40TFConpDias;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV41TFConpDias_To;
         }
         if ( ! ( ( AV45TFConpSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV47i = 1;
            AV50GXV1 = 1;
            while ( AV50GXV1 <= AV45TFConpSts_Sels.Count )
            {
               AV46TFConpSts_Sel = (short)(AV45TFConpSts_Sels.GetNumeric(AV50GXV1));
               if ( AV47i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV46TFConpSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV46TFConpSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV47i = (long)(AV47i+1);
               AV50GXV1 = (int)(AV50GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Condición de Pago";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Abreviatura";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "N° Dias";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV52Configuracion_condicionpagowwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV53Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV54Configuracion_condicionpagowwds_3_conpdsc1 = AV20ConpDsc1;
         AV55Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV56Configuracion_condicionpagowwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV57Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV58Configuracion_condicionpagowwds_7_conpdsc2 = AV24ConpDsc2;
         AV59Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV60Configuracion_condicionpagowwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV61Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV62Configuracion_condicionpagowwds_11_conpdsc3 = AV28ConpDsc3;
         AV63Configuracion_condicionpagowwds_12_tfconpcod = AV34TFConpcod;
         AV64Configuracion_condicionpagowwds_13_tfconpcod_to = AV35TFConpcod_To;
         AV65Configuracion_condicionpagowwds_14_tfconpdsc = AV36TFConpDsc;
         AV66Configuracion_condicionpagowwds_15_tfconpdsc_sel = AV37TFConpDsc_Sel;
         AV67Configuracion_condicionpagowwds_16_tfconpabr = AV38TFConpAbr;
         AV68Configuracion_condicionpagowwds_17_tfconpabr_sel = AV39TFConpAbr_Sel;
         AV69Configuracion_condicionpagowwds_18_tfconpdias = AV40TFConpDias;
         AV70Configuracion_condicionpagowwds_19_tfconpdias_to = AV41TFConpDias_To;
         AV71Configuracion_condicionpagowwds_20_tfconpsts_sels = AV45TFConpSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A754ConpSts ,
                                              AV71Configuracion_condicionpagowwds_20_tfconpsts_sels ,
                                              AV52Configuracion_condicionpagowwds_1_dynamicfiltersselector1 ,
                                              AV53Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 ,
                                              AV54Configuracion_condicionpagowwds_3_conpdsc1 ,
                                              AV55Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 ,
                                              AV56Configuracion_condicionpagowwds_5_dynamicfiltersselector2 ,
                                              AV57Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 ,
                                              AV58Configuracion_condicionpagowwds_7_conpdsc2 ,
                                              AV59Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 ,
                                              AV60Configuracion_condicionpagowwds_9_dynamicfiltersselector3 ,
                                              AV61Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 ,
                                              AV62Configuracion_condicionpagowwds_11_conpdsc3 ,
                                              AV63Configuracion_condicionpagowwds_12_tfconpcod ,
                                              AV64Configuracion_condicionpagowwds_13_tfconpcod_to ,
                                              AV66Configuracion_condicionpagowwds_15_tfconpdsc_sel ,
                                              AV65Configuracion_condicionpagowwds_14_tfconpdsc ,
                                              AV68Configuracion_condicionpagowwds_17_tfconpabr_sel ,
                                              AV67Configuracion_condicionpagowwds_16_tfconpabr ,
                                              AV69Configuracion_condicionpagowwds_18_tfconpdias ,
                                              AV70Configuracion_condicionpagowwds_19_tfconpdias_to ,
                                              AV71Configuracion_condicionpagowwds_20_tfconpsts_sels.Count ,
                                              A753ConpDsc ,
                                              A137Conpcod ,
                                              A751ConpAbr ,
                                              A752ConpDias ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Configuracion_condicionpagowwds_3_conpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_condicionpagowwds_3_conpdsc1), 100, "%");
         lV54Configuracion_condicionpagowwds_3_conpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_condicionpagowwds_3_conpdsc1), 100, "%");
         lV58Configuracion_condicionpagowwds_7_conpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_condicionpagowwds_7_conpdsc2), 100, "%");
         lV58Configuracion_condicionpagowwds_7_conpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_condicionpagowwds_7_conpdsc2), 100, "%");
         lV62Configuracion_condicionpagowwds_11_conpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_condicionpagowwds_11_conpdsc3), 100, "%");
         lV62Configuracion_condicionpagowwds_11_conpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_condicionpagowwds_11_conpdsc3), 100, "%");
         lV65Configuracion_condicionpagowwds_14_tfconpdsc = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_condicionpagowwds_14_tfconpdsc), 100, "%");
         lV67Configuracion_condicionpagowwds_16_tfconpabr = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_condicionpagowwds_16_tfconpabr), 5, "%");
         /* Using cursor P002J2 */
         pr_default.execute(0, new Object[] {lV54Configuracion_condicionpagowwds_3_conpdsc1, lV54Configuracion_condicionpagowwds_3_conpdsc1, lV58Configuracion_condicionpagowwds_7_conpdsc2, lV58Configuracion_condicionpagowwds_7_conpdsc2, lV62Configuracion_condicionpagowwds_11_conpdsc3, lV62Configuracion_condicionpagowwds_11_conpdsc3, AV63Configuracion_condicionpagowwds_12_tfconpcod, AV64Configuracion_condicionpagowwds_13_tfconpcod_to, lV65Configuracion_condicionpagowwds_14_tfconpdsc, AV66Configuracion_condicionpagowwds_15_tfconpdsc_sel, lV67Configuracion_condicionpagowwds_16_tfconpabr, AV68Configuracion_condicionpagowwds_17_tfconpabr_sel, AV69Configuracion_condicionpagowwds_18_tfconpdias, AV70Configuracion_condicionpagowwds_19_tfconpdias_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A754ConpSts = P002J2_A754ConpSts[0];
            A752ConpDias = P002J2_A752ConpDias[0];
            A751ConpAbr = P002J2_A751ConpAbr[0];
            A137Conpcod = P002J2_A137Conpcod[0];
            A753ConpDsc = P002J2_A753ConpDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A137Conpcod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A753ConpDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A751ConpAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = A752ConpDias;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A754ConpSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "ACTIVO";
            }
            else if ( A754ConpSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "INACTIVO";
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.CondicionPagoWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.CondicionPagoWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.CondicionPagoWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV72GXV2 = 1;
         while ( AV72GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV72GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONPCOD") == 0 )
            {
               AV34TFConpcod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFConpcod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONPDSC") == 0 )
            {
               AV36TFConpDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONPDSC_SEL") == 0 )
            {
               AV37TFConpDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONPABR") == 0 )
            {
               AV38TFConpAbr = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONPABR_SEL") == 0 )
            {
               AV39TFConpAbr_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONPDIAS") == 0 )
            {
               AV40TFConpDias = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV41TFConpDias_To = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONPSTS_SEL") == 0 )
            {
               AV44TFConpSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV45TFConpSts_Sels.FromJSonString(AV44TFConpSts_SelsJson, null);
            }
            AV72GXV2 = (int)(AV72GXV2+1);
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
         AV20ConpDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24ConpDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28ConpDsc3 = "";
         AV37TFConpDsc_Sel = "";
         AV36TFConpDsc = "";
         AV39TFConpAbr_Sel = "";
         AV38TFConpAbr = "";
         AV45TFConpSts_Sels = new GxSimpleCollection<short>();
         AV52Configuracion_condicionpagowwds_1_dynamicfiltersselector1 = "";
         AV54Configuracion_condicionpagowwds_3_conpdsc1 = "";
         AV56Configuracion_condicionpagowwds_5_dynamicfiltersselector2 = "";
         AV58Configuracion_condicionpagowwds_7_conpdsc2 = "";
         AV60Configuracion_condicionpagowwds_9_dynamicfiltersselector3 = "";
         AV62Configuracion_condicionpagowwds_11_conpdsc3 = "";
         AV65Configuracion_condicionpagowwds_14_tfconpdsc = "";
         AV66Configuracion_condicionpagowwds_15_tfconpdsc_sel = "";
         AV67Configuracion_condicionpagowwds_16_tfconpabr = "";
         AV68Configuracion_condicionpagowwds_17_tfconpabr_sel = "";
         AV71Configuracion_condicionpagowwds_20_tfconpsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV54Configuracion_condicionpagowwds_3_conpdsc1 = "";
         lV58Configuracion_condicionpagowwds_7_conpdsc2 = "";
         lV62Configuracion_condicionpagowwds_11_conpdsc3 = "";
         lV65Configuracion_condicionpagowwds_14_tfconpdsc = "";
         lV67Configuracion_condicionpagowwds_16_tfconpabr = "";
         A753ConpDsc = "";
         A751ConpAbr = "";
         P002J2_A754ConpSts = new short[1] ;
         P002J2_A752ConpDias = new short[1] ;
         P002J2_A751ConpAbr = new string[] {""} ;
         P002J2_A137Conpcod = new int[1] ;
         P002J2_A753ConpDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV44TFConpSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.condicionpagowwexport__default(),
            new Object[][] {
                new Object[] {
               P002J2_A754ConpSts, P002J2_A752ConpDias, P002J2_A751ConpAbr, P002J2_A137Conpcod, P002J2_A753ConpDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV40TFConpDias ;
      private short AV41TFConpDias_To ;
      private short GXt_int2 ;
      private short AV46TFConpSts_Sel ;
      private short AV53Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 ;
      private short AV57Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 ;
      private short AV61Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 ;
      private short AV69Configuracion_condicionpagowwds_18_tfconpdias ;
      private short AV70Configuracion_condicionpagowwds_19_tfconpdias_to ;
      private short A754ConpSts ;
      private short A752ConpDias ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFConpcod ;
      private int AV35TFConpcod_To ;
      private int AV50GXV1 ;
      private int AV63Configuracion_condicionpagowwds_12_tfconpcod ;
      private int AV64Configuracion_condicionpagowwds_13_tfconpcod_to ;
      private int AV71Configuracion_condicionpagowwds_20_tfconpsts_sels_Count ;
      private int A137Conpcod ;
      private int AV72GXV2 ;
      private long AV47i ;
      private string AV20ConpDsc1 ;
      private string AV24ConpDsc2 ;
      private string AV28ConpDsc3 ;
      private string AV37TFConpDsc_Sel ;
      private string AV36TFConpDsc ;
      private string AV39TFConpAbr_Sel ;
      private string AV38TFConpAbr ;
      private string AV54Configuracion_condicionpagowwds_3_conpdsc1 ;
      private string AV58Configuracion_condicionpagowwds_7_conpdsc2 ;
      private string AV62Configuracion_condicionpagowwds_11_conpdsc3 ;
      private string AV65Configuracion_condicionpagowwds_14_tfconpdsc ;
      private string AV66Configuracion_condicionpagowwds_15_tfconpdsc_sel ;
      private string AV67Configuracion_condicionpagowwds_16_tfconpabr ;
      private string AV68Configuracion_condicionpagowwds_17_tfconpabr_sel ;
      private string scmdbuf ;
      private string lV54Configuracion_condicionpagowwds_3_conpdsc1 ;
      private string lV58Configuracion_condicionpagowwds_7_conpdsc2 ;
      private string lV62Configuracion_condicionpagowwds_11_conpdsc3 ;
      private string lV65Configuracion_condicionpagowwds_14_tfconpdsc ;
      private string lV67Configuracion_condicionpagowwds_16_tfconpabr ;
      private string A753ConpDsc ;
      private string A751ConpAbr ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV55Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 ;
      private bool AV59Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV44TFConpSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV52Configuracion_condicionpagowwds_1_dynamicfiltersselector1 ;
      private string AV56Configuracion_condicionpagowwds_5_dynamicfiltersselector2 ;
      private string AV60Configuracion_condicionpagowwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV45TFConpSts_Sels ;
      private GxSimpleCollection<short> AV71Configuracion_condicionpagowwds_20_tfconpsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002J2_A754ConpSts ;
      private short[] P002J2_A752ConpDias ;
      private string[] P002J2_A751ConpAbr ;
      private int[] P002J2_A137Conpcod ;
      private string[] P002J2_A753ConpDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class condicionpagowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002J2( IGxContext context ,
                                             short A754ConpSts ,
                                             GxSimpleCollection<short> AV71Configuracion_condicionpagowwds_20_tfconpsts_sels ,
                                             string AV52Configuracion_condicionpagowwds_1_dynamicfiltersselector1 ,
                                             short AV53Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 ,
                                             string AV54Configuracion_condicionpagowwds_3_conpdsc1 ,
                                             bool AV55Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 ,
                                             string AV56Configuracion_condicionpagowwds_5_dynamicfiltersselector2 ,
                                             short AV57Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 ,
                                             string AV58Configuracion_condicionpagowwds_7_conpdsc2 ,
                                             bool AV59Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 ,
                                             string AV60Configuracion_condicionpagowwds_9_dynamicfiltersselector3 ,
                                             short AV61Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 ,
                                             string AV62Configuracion_condicionpagowwds_11_conpdsc3 ,
                                             int AV63Configuracion_condicionpagowwds_12_tfconpcod ,
                                             int AV64Configuracion_condicionpagowwds_13_tfconpcod_to ,
                                             string AV66Configuracion_condicionpagowwds_15_tfconpdsc_sel ,
                                             string AV65Configuracion_condicionpagowwds_14_tfconpdsc ,
                                             string AV68Configuracion_condicionpagowwds_17_tfconpabr_sel ,
                                             string AV67Configuracion_condicionpagowwds_16_tfconpabr ,
                                             short AV69Configuracion_condicionpagowwds_18_tfconpdias ,
                                             short AV70Configuracion_condicionpagowwds_19_tfconpdias_to ,
                                             int AV71Configuracion_condicionpagowwds_20_tfconpsts_sels_Count ,
                                             string A753ConpDsc ,
                                             int A137Conpcod ,
                                             string A751ConpAbr ,
                                             short A752ConpDias ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [ConpSts], [ConpDias], [ConpAbr], [Conpcod], [ConpDsc] FROM [CCONDICIONPAGO]";
         if ( ( StringUtil.StrCmp(AV52Configuracion_condicionpagowwds_1_dynamicfiltersselector1, "CONPDSC") == 0 ) && ( AV53Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_condicionpagowwds_3_conpdsc1)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV54Configuracion_condicionpagowwds_3_conpdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Configuracion_condicionpagowwds_1_dynamicfiltersselector1, "CONPDSC") == 0 ) && ( AV53Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_condicionpagowwds_3_conpdsc1)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like '%' + @lV54Configuracion_condicionpagowwds_3_conpdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV55Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Configuracion_condicionpagowwds_5_dynamicfiltersselector2, "CONPDSC") == 0 ) && ( AV57Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_condicionpagowwds_7_conpdsc2)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV58Configuracion_condicionpagowwds_7_conpdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV55Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Configuracion_condicionpagowwds_5_dynamicfiltersselector2, "CONPDSC") == 0 ) && ( AV57Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_condicionpagowwds_7_conpdsc2)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like '%' + @lV58Configuracion_condicionpagowwds_7_conpdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV59Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Configuracion_condicionpagowwds_9_dynamicfiltersselector3, "CONPDSC") == 0 ) && ( AV61Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_condicionpagowwds_11_conpdsc3)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV62Configuracion_condicionpagowwds_11_conpdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV59Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Configuracion_condicionpagowwds_9_dynamicfiltersselector3, "CONPDSC") == 0 ) && ( AV61Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_condicionpagowwds_11_conpdsc3)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like '%' + @lV62Configuracion_condicionpagowwds_11_conpdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV63Configuracion_condicionpagowwds_12_tfconpcod) )
         {
            AddWhere(sWhereString, "([Conpcod] >= @AV63Configuracion_condicionpagowwds_12_tfconpcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV64Configuracion_condicionpagowwds_13_tfconpcod_to) )
         {
            AddWhere(sWhereString, "([Conpcod] <= @AV64Configuracion_condicionpagowwds_13_tfconpcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_condicionpagowwds_15_tfconpdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_condicionpagowwds_14_tfconpdsc)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV65Configuracion_condicionpagowwds_14_tfconpdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_condicionpagowwds_15_tfconpdsc_sel)) )
         {
            AddWhere(sWhereString, "([ConpDsc] = @AV66Configuracion_condicionpagowwds_15_tfconpdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_condicionpagowwds_17_tfconpabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_condicionpagowwds_16_tfconpabr)) ) )
         {
            AddWhere(sWhereString, "([ConpAbr] like @lV67Configuracion_condicionpagowwds_16_tfconpabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_condicionpagowwds_17_tfconpabr_sel)) )
         {
            AddWhere(sWhereString, "([ConpAbr] = @AV68Configuracion_condicionpagowwds_17_tfconpabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV69Configuracion_condicionpagowwds_18_tfconpdias) )
         {
            AddWhere(sWhereString, "([ConpDias] >= @AV69Configuracion_condicionpagowwds_18_tfconpdias)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV70Configuracion_condicionpagowwds_19_tfconpdias_to) )
         {
            AddWhere(sWhereString, "([ConpDias] <= @AV70Configuracion_condicionpagowwds_19_tfconpdias_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV71Configuracion_condicionpagowwds_20_tfconpsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71Configuracion_condicionpagowwds_20_tfconpsts_sels, "[ConpSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [Conpcod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Conpcod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConpDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConpDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConpAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConpAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConpDias]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConpDias] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConpSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConpSts] DESC";
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
                     return conditional_P002J2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP002J2;
          prmP002J2 = new Object[] {
          new ParDef("@lV54Configuracion_condicionpagowwds_3_conpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV54Configuracion_condicionpagowwds_3_conpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_condicionpagowwds_7_conpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_condicionpagowwds_7_conpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_condicionpagowwds_11_conpdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_condicionpagowwds_11_conpdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV63Configuracion_condicionpagowwds_12_tfconpcod",GXType.Int32,6,0) ,
          new ParDef("@AV64Configuracion_condicionpagowwds_13_tfconpcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV65Configuracion_condicionpagowwds_14_tfconpdsc",GXType.NChar,100,0) ,
          new ParDef("@AV66Configuracion_condicionpagowwds_15_tfconpdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_condicionpagowwds_16_tfconpabr",GXType.NChar,5,0) ,
          new ParDef("@AV68Configuracion_condicionpagowwds_17_tfconpabr_sel",GXType.NChar,5,0) ,
          new ParDef("@AV69Configuracion_condicionpagowwds_18_tfconpdias",GXType.Int16,4,0) ,
          new ParDef("@AV70Configuracion_condicionpagowwds_19_tfconpdias_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002J2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
