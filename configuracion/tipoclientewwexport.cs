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
   public class tipoclientewwexport : GXProcedure
   {
      public tipoclientewwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipoclientewwexport( IGxContext context )
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
         tipoclientewwexport objtipoclientewwexport;
         objtipoclientewwexport = new tipoclientewwexport();
         objtipoclientewwexport.AV11Filename = "" ;
         objtipoclientewwexport.AV12ErrorMessage = "" ;
         objtipoclientewwexport.context.SetSubmitInitialConfig(context);
         objtipoclientewwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipoclientewwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipoclientewwexport)stateInfo).executePrivate();
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
         AV11Filename = "TipoClienteWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIPCDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20TipCDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TipCDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Cliente", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Cliente", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20TipCDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TIPCDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24TipCDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TipCDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Cliente", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Cliente", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24TipCDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIPCDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28TipCDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TipCDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Cliente", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Cliente", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28TipCDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFTipCCod) && (0==AV35TFTipCCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFTipCCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFTipCCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTipCDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Cliente") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFTipCDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTipCDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Cliente") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFTipCDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFTipCAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFTipCAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTipCAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFTipCAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV41TFTipCSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV43i = 1;
            AV46GXV1 = 1;
            while ( AV46GXV1 <= AV41TFTipCSts_Sels.Count )
            {
               AV42TFTipCSts_Sel = (short)(AV41TFTipCSts_Sels.GetNumeric(AV46GXV1));
               if ( AV43i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV42TFTipCSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV42TFTipCSts_Sel == 0 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Tipo de Cliente";
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
         AV48Configuracion_tipoclientewwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV49Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV50Configuracion_tipoclientewwds_3_tipcdsc1 = AV20TipCDsc1;
         AV51Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV52Configuracion_tipoclientewwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV53Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV54Configuracion_tipoclientewwds_7_tipcdsc2 = AV24TipCDsc2;
         AV55Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV56Configuracion_tipoclientewwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV57Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV58Configuracion_tipoclientewwds_11_tipcdsc3 = AV28TipCDsc3;
         AV59Configuracion_tipoclientewwds_12_tftipccod = AV34TFTipCCod;
         AV60Configuracion_tipoclientewwds_13_tftipccod_to = AV35TFTipCCod_To;
         AV61Configuracion_tipoclientewwds_14_tftipcdsc = AV36TFTipCDsc;
         AV62Configuracion_tipoclientewwds_15_tftipcdsc_sel = AV37TFTipCDsc_Sel;
         AV63Configuracion_tipoclientewwds_16_tftipcabr = AV38TFTipCAbr;
         AV64Configuracion_tipoclientewwds_17_tftipcabr_sel = AV39TFTipCAbr_Sel;
         AV65Configuracion_tipoclientewwds_18_tftipcsts_sels = AV41TFTipCSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1908TipCSts ,
                                              AV65Configuracion_tipoclientewwds_18_tftipcsts_sels ,
                                              AV48Configuracion_tipoclientewwds_1_dynamicfiltersselector1 ,
                                              AV49Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 ,
                                              AV50Configuracion_tipoclientewwds_3_tipcdsc1 ,
                                              AV51Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 ,
                                              AV52Configuracion_tipoclientewwds_5_dynamicfiltersselector2 ,
                                              AV53Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 ,
                                              AV54Configuracion_tipoclientewwds_7_tipcdsc2 ,
                                              AV55Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 ,
                                              AV56Configuracion_tipoclientewwds_9_dynamicfiltersselector3 ,
                                              AV57Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 ,
                                              AV58Configuracion_tipoclientewwds_11_tipcdsc3 ,
                                              AV59Configuracion_tipoclientewwds_12_tftipccod ,
                                              AV60Configuracion_tipoclientewwds_13_tftipccod_to ,
                                              AV62Configuracion_tipoclientewwds_15_tftipcdsc_sel ,
                                              AV61Configuracion_tipoclientewwds_14_tftipcdsc ,
                                              AV64Configuracion_tipoclientewwds_17_tftipcabr_sel ,
                                              AV63Configuracion_tipoclientewwds_16_tftipcabr ,
                                              AV65Configuracion_tipoclientewwds_18_tftipcsts_sels.Count ,
                                              A1905TipCDsc ,
                                              A159TipCCod ,
                                              A1904TipCAbr ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV50Configuracion_tipoclientewwds_3_tipcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV50Configuracion_tipoclientewwds_3_tipcdsc1), 100, "%");
         lV50Configuracion_tipoclientewwds_3_tipcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV50Configuracion_tipoclientewwds_3_tipcdsc1), 100, "%");
         lV54Configuracion_tipoclientewwds_7_tipcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_tipoclientewwds_7_tipcdsc2), 100, "%");
         lV54Configuracion_tipoclientewwds_7_tipcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_tipoclientewwds_7_tipcdsc2), 100, "%");
         lV58Configuracion_tipoclientewwds_11_tipcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_tipoclientewwds_11_tipcdsc3), 100, "%");
         lV58Configuracion_tipoclientewwds_11_tipcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_tipoclientewwds_11_tipcdsc3), 100, "%");
         lV61Configuracion_tipoclientewwds_14_tftipcdsc = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipoclientewwds_14_tftipcdsc), 100, "%");
         lV63Configuracion_tipoclientewwds_16_tftipcabr = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_tipoclientewwds_16_tftipcabr), 5, "%");
         /* Using cursor P00442 */
         pr_default.execute(0, new Object[] {lV50Configuracion_tipoclientewwds_3_tipcdsc1, lV50Configuracion_tipoclientewwds_3_tipcdsc1, lV54Configuracion_tipoclientewwds_7_tipcdsc2, lV54Configuracion_tipoclientewwds_7_tipcdsc2, lV58Configuracion_tipoclientewwds_11_tipcdsc3, lV58Configuracion_tipoclientewwds_11_tipcdsc3, AV59Configuracion_tipoclientewwds_12_tftipccod, AV60Configuracion_tipoclientewwds_13_tftipccod_to, lV61Configuracion_tipoclientewwds_14_tftipcdsc, AV62Configuracion_tipoclientewwds_15_tftipcdsc_sel, lV63Configuracion_tipoclientewwds_16_tftipcabr, AV64Configuracion_tipoclientewwds_17_tftipcabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1908TipCSts = P00442_A1908TipCSts[0];
            A1904TipCAbr = P00442_A1904TipCAbr[0];
            A159TipCCod = P00442_A159TipCCod[0];
            A1905TipCDsc = P00442_A1905TipCDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A159TipCCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1905TipCDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1904TipCAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A1908TipCSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "ACTIVO";
            }
            else if ( A1908TipCSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.TipoClienteWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoClienteWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.TipoClienteWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV66GXV2 = 1;
         while ( AV66GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV66GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPCCOD") == 0 )
            {
               AV34TFTipCCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFTipCCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPCDSC") == 0 )
            {
               AV36TFTipCDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPCDSC_SEL") == 0 )
            {
               AV37TFTipCDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPCABR") == 0 )
            {
               AV38TFTipCAbr = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPCABR_SEL") == 0 )
            {
               AV39TFTipCAbr_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPCSTS_SEL") == 0 )
            {
               AV40TFTipCSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV41TFTipCSts_Sels.FromJSonString(AV40TFTipCSts_SelsJson, null);
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
         AV20TipCDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24TipCDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28TipCDsc3 = "";
         AV37TFTipCDsc_Sel = "";
         AV36TFTipCDsc = "";
         AV39TFTipCAbr_Sel = "";
         AV38TFTipCAbr = "";
         AV41TFTipCSts_Sels = new GxSimpleCollection<short>();
         AV48Configuracion_tipoclientewwds_1_dynamicfiltersselector1 = "";
         AV50Configuracion_tipoclientewwds_3_tipcdsc1 = "";
         AV52Configuracion_tipoclientewwds_5_dynamicfiltersselector2 = "";
         AV54Configuracion_tipoclientewwds_7_tipcdsc2 = "";
         AV56Configuracion_tipoclientewwds_9_dynamicfiltersselector3 = "";
         AV58Configuracion_tipoclientewwds_11_tipcdsc3 = "";
         AV61Configuracion_tipoclientewwds_14_tftipcdsc = "";
         AV62Configuracion_tipoclientewwds_15_tftipcdsc_sel = "";
         AV63Configuracion_tipoclientewwds_16_tftipcabr = "";
         AV64Configuracion_tipoclientewwds_17_tftipcabr_sel = "";
         AV65Configuracion_tipoclientewwds_18_tftipcsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV50Configuracion_tipoclientewwds_3_tipcdsc1 = "";
         lV54Configuracion_tipoclientewwds_7_tipcdsc2 = "";
         lV58Configuracion_tipoclientewwds_11_tipcdsc3 = "";
         lV61Configuracion_tipoclientewwds_14_tftipcdsc = "";
         lV63Configuracion_tipoclientewwds_16_tftipcabr = "";
         A1905TipCDsc = "";
         A1904TipCAbr = "";
         P00442_A1908TipCSts = new short[1] ;
         P00442_A1904TipCAbr = new string[] {""} ;
         P00442_A159TipCCod = new int[1] ;
         P00442_A1905TipCDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40TFTipCSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipoclientewwexport__default(),
            new Object[][] {
                new Object[] {
               P00442_A1908TipCSts, P00442_A1904TipCAbr, P00442_A159TipCCod, P00442_A1905TipCDsc
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
      private short AV42TFTipCSts_Sel ;
      private short AV49Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 ;
      private short AV53Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 ;
      private short AV57Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 ;
      private short A1908TipCSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFTipCCod ;
      private int AV35TFTipCCod_To ;
      private int AV46GXV1 ;
      private int AV59Configuracion_tipoclientewwds_12_tftipccod ;
      private int AV60Configuracion_tipoclientewwds_13_tftipccod_to ;
      private int AV65Configuracion_tipoclientewwds_18_tftipcsts_sels_Count ;
      private int A159TipCCod ;
      private int AV66GXV2 ;
      private long AV43i ;
      private string AV20TipCDsc1 ;
      private string AV24TipCDsc2 ;
      private string AV28TipCDsc3 ;
      private string AV37TFTipCDsc_Sel ;
      private string AV36TFTipCDsc ;
      private string AV39TFTipCAbr_Sel ;
      private string AV38TFTipCAbr ;
      private string AV50Configuracion_tipoclientewwds_3_tipcdsc1 ;
      private string AV54Configuracion_tipoclientewwds_7_tipcdsc2 ;
      private string AV58Configuracion_tipoclientewwds_11_tipcdsc3 ;
      private string AV61Configuracion_tipoclientewwds_14_tftipcdsc ;
      private string AV62Configuracion_tipoclientewwds_15_tftipcdsc_sel ;
      private string AV63Configuracion_tipoclientewwds_16_tftipcabr ;
      private string AV64Configuracion_tipoclientewwds_17_tftipcabr_sel ;
      private string scmdbuf ;
      private string lV50Configuracion_tipoclientewwds_3_tipcdsc1 ;
      private string lV54Configuracion_tipoclientewwds_7_tipcdsc2 ;
      private string lV58Configuracion_tipoclientewwds_11_tipcdsc3 ;
      private string lV61Configuracion_tipoclientewwds_14_tftipcdsc ;
      private string lV63Configuracion_tipoclientewwds_16_tftipcabr ;
      private string A1905TipCDsc ;
      private string A1904TipCAbr ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV51Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 ;
      private bool AV55Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV40TFTipCSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV48Configuracion_tipoclientewwds_1_dynamicfiltersselector1 ;
      private string AV52Configuracion_tipoclientewwds_5_dynamicfiltersselector2 ;
      private string AV56Configuracion_tipoclientewwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV41TFTipCSts_Sels ;
      private GxSimpleCollection<short> AV65Configuracion_tipoclientewwds_18_tftipcsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00442_A1908TipCSts ;
      private string[] P00442_A1904TipCAbr ;
      private int[] P00442_A159TipCCod ;
      private string[] P00442_A1905TipCDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class tipoclientewwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00442( IGxContext context ,
                                             short A1908TipCSts ,
                                             GxSimpleCollection<short> AV65Configuracion_tipoclientewwds_18_tftipcsts_sels ,
                                             string AV48Configuracion_tipoclientewwds_1_dynamicfiltersselector1 ,
                                             short AV49Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 ,
                                             string AV50Configuracion_tipoclientewwds_3_tipcdsc1 ,
                                             bool AV51Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 ,
                                             string AV52Configuracion_tipoclientewwds_5_dynamicfiltersselector2 ,
                                             short AV53Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 ,
                                             string AV54Configuracion_tipoclientewwds_7_tipcdsc2 ,
                                             bool AV55Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 ,
                                             string AV56Configuracion_tipoclientewwds_9_dynamicfiltersselector3 ,
                                             short AV57Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 ,
                                             string AV58Configuracion_tipoclientewwds_11_tipcdsc3 ,
                                             int AV59Configuracion_tipoclientewwds_12_tftipccod ,
                                             int AV60Configuracion_tipoclientewwds_13_tftipccod_to ,
                                             string AV62Configuracion_tipoclientewwds_15_tftipcdsc_sel ,
                                             string AV61Configuracion_tipoclientewwds_14_tftipcdsc ,
                                             string AV64Configuracion_tipoclientewwds_17_tftipcabr_sel ,
                                             string AV63Configuracion_tipoclientewwds_16_tftipcabr ,
                                             int AV65Configuracion_tipoclientewwds_18_tftipcsts_sels_Count ,
                                             string A1905TipCDsc ,
                                             int A159TipCCod ,
                                             string A1904TipCAbr ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TipCSts], [TipCAbr], [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE]";
         if ( ( StringUtil.StrCmp(AV48Configuracion_tipoclientewwds_1_dynamicfiltersselector1, "TIPCDSC") == 0 ) && ( AV49Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Configuracion_tipoclientewwds_3_tipcdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV50Configuracion_tipoclientewwds_3_tipcdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV48Configuracion_tipoclientewwds_1_dynamicfiltersselector1, "TIPCDSC") == 0 ) && ( AV49Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Configuracion_tipoclientewwds_3_tipcdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like '%' + @lV50Configuracion_tipoclientewwds_3_tipcdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV51Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV52Configuracion_tipoclientewwds_5_dynamicfiltersselector2, "TIPCDSC") == 0 ) && ( AV53Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_tipoclientewwds_7_tipcdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV54Configuracion_tipoclientewwds_7_tipcdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV51Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV52Configuracion_tipoclientewwds_5_dynamicfiltersselector2, "TIPCDSC") == 0 ) && ( AV53Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_tipoclientewwds_7_tipcdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like '%' + @lV54Configuracion_tipoclientewwds_7_tipcdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV55Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Configuracion_tipoclientewwds_9_dynamicfiltersselector3, "TIPCDSC") == 0 ) && ( AV57Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_tipoclientewwds_11_tipcdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV58Configuracion_tipoclientewwds_11_tipcdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV55Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Configuracion_tipoclientewwds_9_dynamicfiltersselector3, "TIPCDSC") == 0 ) && ( AV57Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_tipoclientewwds_11_tipcdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like '%' + @lV58Configuracion_tipoclientewwds_11_tipcdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV59Configuracion_tipoclientewwds_12_tftipccod) )
         {
            AddWhere(sWhereString, "([TipCCod] >= @AV59Configuracion_tipoclientewwds_12_tftipccod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV60Configuracion_tipoclientewwds_13_tftipccod_to) )
         {
            AddWhere(sWhereString, "([TipCCod] <= @AV60Configuracion_tipoclientewwds_13_tftipccod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_tipoclientewwds_15_tftipcdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipoclientewwds_14_tftipcdsc)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV61Configuracion_tipoclientewwds_14_tftipcdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_tipoclientewwds_15_tftipcdsc_sel)) )
         {
            AddWhere(sWhereString, "([TipCDsc] = @AV62Configuracion_tipoclientewwds_15_tftipcdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipoclientewwds_17_tftipcabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_tipoclientewwds_16_tftipcabr)) ) )
         {
            AddWhere(sWhereString, "([TipCAbr] like @lV63Configuracion_tipoclientewwds_16_tftipcabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipoclientewwds_17_tftipcabr_sel)) )
         {
            AddWhere(sWhereString, "([TipCAbr] = @AV64Configuracion_tipoclientewwds_17_tftipcabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV65Configuracion_tipoclientewwds_18_tftipcsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV65Configuracion_tipoclientewwds_18_tftipcsts_sels, "[TipCSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipCCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipCCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipCDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipCDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipCAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipCAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipCSts]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipCSts] DESC";
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
                     return conditional_P00442(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP00442;
          prmP00442 = new Object[] {
          new ParDef("@lV50Configuracion_tipoclientewwds_3_tipcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV50Configuracion_tipoclientewwds_3_tipcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV54Configuracion_tipoclientewwds_7_tipcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV54Configuracion_tipoclientewwds_7_tipcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_tipoclientewwds_11_tipcdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_tipoclientewwds_11_tipcdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV59Configuracion_tipoclientewwds_12_tftipccod",GXType.Int32,6,0) ,
          new ParDef("@AV60Configuracion_tipoclientewwds_13_tftipccod_to",GXType.Int32,6,0) ,
          new ParDef("@lV61Configuracion_tipoclientewwds_14_tftipcdsc",GXType.NChar,100,0) ,
          new ParDef("@AV62Configuracion_tipoclientewwds_15_tftipcdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_tipoclientewwds_16_tftipcabr",GXType.NChar,5,0) ,
          new ParDef("@AV64Configuracion_tipoclientewwds_17_tftipcabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00442", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00442,100, GxCacheFrequency.OFF ,true,false )
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
