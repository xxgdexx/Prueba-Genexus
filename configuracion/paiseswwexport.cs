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
   public class paiseswwexport : GXProcedure
   {
      public paiseswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public paiseswwexport( IGxContext context )
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
         paiseswwexport objpaiseswwexport;
         objpaiseswwexport = new paiseswwexport();
         objpaiseswwexport.AV11Filename = "" ;
         objpaiseswwexport.AV12ErrorMessage = "" ;
         objpaiseswwexport.context.SetSubmitInitialConfig(context);
         objpaiseswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpaiseswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((paiseswwexport)stateInfo).executePrivate();
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
         AV11Filename = "PaisesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PAIDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20PaiDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20PaiDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pais", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pais", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20PaiDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PAIDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24PaiDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24PaiDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pais", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pais", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24PaiDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PAIDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28PaiDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28PaiDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pais", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pais", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28PaiDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPaiCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFPaiCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFPaiCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34TFPaiCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFPaiDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Pais") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFPaiDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPaiDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Pais") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFPaiDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV41TFPaiSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV43i = 1;
            AV46GXV1 = 1;
            while ( AV46GXV1 <= AV41TFPaiSts_Sels.Count )
            {
               AV42TFPaiSts_Sel = (short)(AV41TFPaiSts_Sels.GetNumeric(AV46GXV1));
               if ( AV43i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV42TFPaiSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV42TFPaiSts_Sel == 0 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Pais";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV48Configuracion_paiseswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV49Configuracion_paiseswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV50Configuracion_paiseswwds_3_paidsc1 = AV20PaiDsc1;
         AV51Configuracion_paiseswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV52Configuracion_paiseswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV53Configuracion_paiseswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV54Configuracion_paiseswwds_7_paidsc2 = AV24PaiDsc2;
         AV55Configuracion_paiseswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV56Configuracion_paiseswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV57Configuracion_paiseswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV58Configuracion_paiseswwds_11_paidsc3 = AV28PaiDsc3;
         AV59Configuracion_paiseswwds_12_tfpaicod = AV34TFPaiCod;
         AV60Configuracion_paiseswwds_13_tfpaicod_sel = AV35TFPaiCod_Sel;
         AV61Configuracion_paiseswwds_14_tfpaidsc = AV36TFPaiDsc;
         AV62Configuracion_paiseswwds_15_tfpaidsc_sel = AV37TFPaiDsc_Sel;
         AV63Configuracion_paiseswwds_16_tfpaists_sels = AV41TFPaiSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1501PaiSts ,
                                              AV63Configuracion_paiseswwds_16_tfpaists_sels ,
                                              AV48Configuracion_paiseswwds_1_dynamicfiltersselector1 ,
                                              AV49Configuracion_paiseswwds_2_dynamicfiltersoperator1 ,
                                              AV50Configuracion_paiseswwds_3_paidsc1 ,
                                              AV51Configuracion_paiseswwds_4_dynamicfiltersenabled2 ,
                                              AV52Configuracion_paiseswwds_5_dynamicfiltersselector2 ,
                                              AV53Configuracion_paiseswwds_6_dynamicfiltersoperator2 ,
                                              AV54Configuracion_paiseswwds_7_paidsc2 ,
                                              AV55Configuracion_paiseswwds_8_dynamicfiltersenabled3 ,
                                              AV56Configuracion_paiseswwds_9_dynamicfiltersselector3 ,
                                              AV57Configuracion_paiseswwds_10_dynamicfiltersoperator3 ,
                                              AV58Configuracion_paiseswwds_11_paidsc3 ,
                                              AV60Configuracion_paiseswwds_13_tfpaicod_sel ,
                                              AV59Configuracion_paiseswwds_12_tfpaicod ,
                                              AV62Configuracion_paiseswwds_15_tfpaidsc_sel ,
                                              AV61Configuracion_paiseswwds_14_tfpaidsc ,
                                              AV63Configuracion_paiseswwds_16_tfpaists_sels.Count ,
                                              A1500PaiDsc ,
                                              A139PaiCod ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV50Configuracion_paiseswwds_3_paidsc1 = StringUtil.PadR( StringUtil.RTrim( AV50Configuracion_paiseswwds_3_paidsc1), 100, "%");
         lV50Configuracion_paiseswwds_3_paidsc1 = StringUtil.PadR( StringUtil.RTrim( AV50Configuracion_paiseswwds_3_paidsc1), 100, "%");
         lV54Configuracion_paiseswwds_7_paidsc2 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_paiseswwds_7_paidsc2), 100, "%");
         lV54Configuracion_paiseswwds_7_paidsc2 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_paiseswwds_7_paidsc2), 100, "%");
         lV58Configuracion_paiseswwds_11_paidsc3 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_paiseswwds_11_paidsc3), 100, "%");
         lV58Configuracion_paiseswwds_11_paidsc3 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_paiseswwds_11_paidsc3), 100, "%");
         lV59Configuracion_paiseswwds_12_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_paiseswwds_12_tfpaicod), 4, "%");
         lV61Configuracion_paiseswwds_14_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_paiseswwds_14_tfpaidsc), 100, "%");
         /* Using cursor P003I2 */
         pr_default.execute(0, new Object[] {lV50Configuracion_paiseswwds_3_paidsc1, lV50Configuracion_paiseswwds_3_paidsc1, lV54Configuracion_paiseswwds_7_paidsc2, lV54Configuracion_paiseswwds_7_paidsc2, lV58Configuracion_paiseswwds_11_paidsc3, lV58Configuracion_paiseswwds_11_paidsc3, lV59Configuracion_paiseswwds_12_tfpaicod, AV60Configuracion_paiseswwds_13_tfpaicod_sel, lV61Configuracion_paiseswwds_14_tfpaidsc, AV62Configuracion_paiseswwds_15_tfpaidsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1501PaiSts = P003I2_A1501PaiSts[0];
            A139PaiCod = P003I2_A139PaiCod[0];
            A1500PaiDsc = P003I2_A1500PaiDsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A139PaiCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1500PaiDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( A1501PaiSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "ACTIVO";
            }
            else if ( A1501PaiSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "INACTIVO";
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.PaisesWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.PaisesWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.PaisesWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV64GXV2 = 1;
         while ( AV64GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV64GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAICOD") == 0 )
            {
               AV34TFPaiCod = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAICOD_SEL") == 0 )
            {
               AV35TFPaiCod_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAIDSC") == 0 )
            {
               AV36TFPaiDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAIDSC_SEL") == 0 )
            {
               AV37TFPaiDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAISTS_SEL") == 0 )
            {
               AV40TFPaiSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV41TFPaiSts_Sels.FromJSonString(AV40TFPaiSts_SelsJson, null);
            }
            AV64GXV2 = (int)(AV64GXV2+1);
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
         AV20PaiDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24PaiDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28PaiDsc3 = "";
         AV35TFPaiCod_Sel = "";
         AV34TFPaiCod = "";
         AV37TFPaiDsc_Sel = "";
         AV36TFPaiDsc = "";
         AV41TFPaiSts_Sels = new GxSimpleCollection<short>();
         AV48Configuracion_paiseswwds_1_dynamicfiltersselector1 = "";
         AV50Configuracion_paiseswwds_3_paidsc1 = "";
         AV52Configuracion_paiseswwds_5_dynamicfiltersselector2 = "";
         AV54Configuracion_paiseswwds_7_paidsc2 = "";
         AV56Configuracion_paiseswwds_9_dynamicfiltersselector3 = "";
         AV58Configuracion_paiseswwds_11_paidsc3 = "";
         AV59Configuracion_paiseswwds_12_tfpaicod = "";
         AV60Configuracion_paiseswwds_13_tfpaicod_sel = "";
         AV61Configuracion_paiseswwds_14_tfpaidsc = "";
         AV62Configuracion_paiseswwds_15_tfpaidsc_sel = "";
         AV63Configuracion_paiseswwds_16_tfpaists_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV50Configuracion_paiseswwds_3_paidsc1 = "";
         lV54Configuracion_paiseswwds_7_paidsc2 = "";
         lV58Configuracion_paiseswwds_11_paidsc3 = "";
         lV59Configuracion_paiseswwds_12_tfpaicod = "";
         lV61Configuracion_paiseswwds_14_tfpaidsc = "";
         A1500PaiDsc = "";
         A139PaiCod = "";
         P003I2_A1501PaiSts = new short[1] ;
         P003I2_A139PaiCod = new string[] {""} ;
         P003I2_A1500PaiDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40TFPaiSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.paiseswwexport__default(),
            new Object[][] {
                new Object[] {
               P003I2_A1501PaiSts, P003I2_A139PaiCod, P003I2_A1500PaiDsc
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
      private short AV42TFPaiSts_Sel ;
      private short AV49Configuracion_paiseswwds_2_dynamicfiltersoperator1 ;
      private short AV53Configuracion_paiseswwds_6_dynamicfiltersoperator2 ;
      private short AV57Configuracion_paiseswwds_10_dynamicfiltersoperator3 ;
      private short A1501PaiSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV46GXV1 ;
      private int AV63Configuracion_paiseswwds_16_tfpaists_sels_Count ;
      private int AV64GXV2 ;
      private long AV43i ;
      private string AV20PaiDsc1 ;
      private string AV24PaiDsc2 ;
      private string AV28PaiDsc3 ;
      private string AV35TFPaiCod_Sel ;
      private string AV34TFPaiCod ;
      private string AV37TFPaiDsc_Sel ;
      private string AV36TFPaiDsc ;
      private string AV50Configuracion_paiseswwds_3_paidsc1 ;
      private string AV54Configuracion_paiseswwds_7_paidsc2 ;
      private string AV58Configuracion_paiseswwds_11_paidsc3 ;
      private string AV59Configuracion_paiseswwds_12_tfpaicod ;
      private string AV60Configuracion_paiseswwds_13_tfpaicod_sel ;
      private string AV61Configuracion_paiseswwds_14_tfpaidsc ;
      private string AV62Configuracion_paiseswwds_15_tfpaidsc_sel ;
      private string scmdbuf ;
      private string lV50Configuracion_paiseswwds_3_paidsc1 ;
      private string lV54Configuracion_paiseswwds_7_paidsc2 ;
      private string lV58Configuracion_paiseswwds_11_paidsc3 ;
      private string lV59Configuracion_paiseswwds_12_tfpaicod ;
      private string lV61Configuracion_paiseswwds_14_tfpaidsc ;
      private string A1500PaiDsc ;
      private string A139PaiCod ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV51Configuracion_paiseswwds_4_dynamicfiltersenabled2 ;
      private bool AV55Configuracion_paiseswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV40TFPaiSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV48Configuracion_paiseswwds_1_dynamicfiltersselector1 ;
      private string AV52Configuracion_paiseswwds_5_dynamicfiltersselector2 ;
      private string AV56Configuracion_paiseswwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV41TFPaiSts_Sels ;
      private GxSimpleCollection<short> AV63Configuracion_paiseswwds_16_tfpaists_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003I2_A1501PaiSts ;
      private string[] P003I2_A139PaiCod ;
      private string[] P003I2_A1500PaiDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class paiseswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003I2( IGxContext context ,
                                             short A1501PaiSts ,
                                             GxSimpleCollection<short> AV63Configuracion_paiseswwds_16_tfpaists_sels ,
                                             string AV48Configuracion_paiseswwds_1_dynamicfiltersselector1 ,
                                             short AV49Configuracion_paiseswwds_2_dynamicfiltersoperator1 ,
                                             string AV50Configuracion_paiseswwds_3_paidsc1 ,
                                             bool AV51Configuracion_paiseswwds_4_dynamicfiltersenabled2 ,
                                             string AV52Configuracion_paiseswwds_5_dynamicfiltersselector2 ,
                                             short AV53Configuracion_paiseswwds_6_dynamicfiltersoperator2 ,
                                             string AV54Configuracion_paiseswwds_7_paidsc2 ,
                                             bool AV55Configuracion_paiseswwds_8_dynamicfiltersenabled3 ,
                                             string AV56Configuracion_paiseswwds_9_dynamicfiltersselector3 ,
                                             short AV57Configuracion_paiseswwds_10_dynamicfiltersoperator3 ,
                                             string AV58Configuracion_paiseswwds_11_paidsc3 ,
                                             string AV60Configuracion_paiseswwds_13_tfpaicod_sel ,
                                             string AV59Configuracion_paiseswwds_12_tfpaicod ,
                                             string AV62Configuracion_paiseswwds_15_tfpaidsc_sel ,
                                             string AV61Configuracion_paiseswwds_14_tfpaidsc ,
                                             int AV63Configuracion_paiseswwds_16_tfpaists_sels_Count ,
                                             string A1500PaiDsc ,
                                             string A139PaiCod ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [PaiSts], [PaiCod], [PaiDsc] FROM [CPAISES]";
         if ( ( StringUtil.StrCmp(AV48Configuracion_paiseswwds_1_dynamicfiltersselector1, "PAIDSC") == 0 ) && ( AV49Configuracion_paiseswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Configuracion_paiseswwds_3_paidsc1)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV50Configuracion_paiseswwds_3_paidsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV48Configuracion_paiseswwds_1_dynamicfiltersselector1, "PAIDSC") == 0 ) && ( AV49Configuracion_paiseswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Configuracion_paiseswwds_3_paidsc1)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV50Configuracion_paiseswwds_3_paidsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV51Configuracion_paiseswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV52Configuracion_paiseswwds_5_dynamicfiltersselector2, "PAIDSC") == 0 ) && ( AV53Configuracion_paiseswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_paiseswwds_7_paidsc2)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV54Configuracion_paiseswwds_7_paidsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV51Configuracion_paiseswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV52Configuracion_paiseswwds_5_dynamicfiltersselector2, "PAIDSC") == 0 ) && ( AV53Configuracion_paiseswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_paiseswwds_7_paidsc2)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV54Configuracion_paiseswwds_7_paidsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV55Configuracion_paiseswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Configuracion_paiseswwds_9_dynamicfiltersselector3, "PAIDSC") == 0 ) && ( AV57Configuracion_paiseswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_paiseswwds_11_paidsc3)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV58Configuracion_paiseswwds_11_paidsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV55Configuracion_paiseswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Configuracion_paiseswwds_9_dynamicfiltersselector3, "PAIDSC") == 0 ) && ( AV57Configuracion_paiseswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_paiseswwds_11_paidsc3)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV58Configuracion_paiseswwds_11_paidsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_paiseswwds_13_tfpaicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_paiseswwds_12_tfpaicod)) ) )
         {
            AddWhere(sWhereString, "([PaiCod] like @lV59Configuracion_paiseswwds_12_tfpaicod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_paiseswwds_13_tfpaicod_sel)) )
         {
            AddWhere(sWhereString, "([PaiCod] = @AV60Configuracion_paiseswwds_13_tfpaicod_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_paiseswwds_15_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_paiseswwds_14_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV61Configuracion_paiseswwds_14_tfpaidsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_paiseswwds_15_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "([PaiDsc] = @AV62Configuracion_paiseswwds_15_tfpaidsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV63Configuracion_paiseswwds_16_tfpaists_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV63Configuracion_paiseswwds_16_tfpaists_sels, "[PaiSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [PaiCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PaiCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [PaiDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PaiDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [PaiSts]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PaiSts] DESC";
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
                     return conditional_P003I2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP003I2;
          prmP003I2 = new Object[] {
          new ParDef("@lV50Configuracion_paiseswwds_3_paidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV50Configuracion_paiseswwds_3_paidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV54Configuracion_paiseswwds_7_paidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV54Configuracion_paiseswwds_7_paidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_paiseswwds_11_paidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_paiseswwds_11_paidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_paiseswwds_12_tfpaicod",GXType.NChar,4,0) ,
          new ParDef("@AV60Configuracion_paiseswwds_13_tfpaicod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV61Configuracion_paiseswwds_14_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV62Configuracion_paiseswwds_15_tfpaidsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003I2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
