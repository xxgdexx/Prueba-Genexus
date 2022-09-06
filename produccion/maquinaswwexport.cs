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
   public class maquinaswwexport : GXProcedure
   {
      public maquinaswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public maquinaswwexport( IGxContext context )
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
         maquinaswwexport objmaquinaswwexport;
         objmaquinaswwexport = new maquinaswwexport();
         objmaquinaswwexport.AV11Filename = "" ;
         objmaquinaswwexport.AV12ErrorMessage = "" ;
         objmaquinaswwexport.context.SetSubmitInitialConfig(context);
         objmaquinaswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmaquinaswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((maquinaswwexport)stateInfo).executePrivate();
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
         AV11Filename = "MaquinasWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MAQDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20MAQDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20MAQDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Maquina", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Maquina", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20MAQDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "MAQDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24MAQDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24MAQDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Maquina", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Maquina", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24MAQDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "MAQDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28MAQDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28MAQDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Maquina", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Maquina", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28MAQDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFMAQCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFMAQCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFMAQCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34TFMAQCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFMAQDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Maquina") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFMAQDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFMAQDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Maquina") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFMAQDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV39TFMAQSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV41i = 1;
            AV44GXV1 = 1;
            while ( AV44GXV1 <= AV39TFMAQSts_Sels.Count )
            {
               AV40TFMAQSts_Sel = (short)(AV39TFMAQSts_Sels.GetNumeric(AV44GXV1));
               if ( AV41i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV40TFMAQSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV40TFMAQSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV41i = (long)(AV41i+1);
               AV44GXV1 = (int)(AV44GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Maquina";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV46Produccion_maquinaswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV47Produccion_maquinaswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV48Produccion_maquinaswwds_3_maqdsc1 = AV20MAQDsc1;
         AV49Produccion_maquinaswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV50Produccion_maquinaswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV51Produccion_maquinaswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV52Produccion_maquinaswwds_7_maqdsc2 = AV24MAQDsc2;
         AV53Produccion_maquinaswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV54Produccion_maquinaswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV55Produccion_maquinaswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV56Produccion_maquinaswwds_11_maqdsc3 = AV28MAQDsc3;
         AV57Produccion_maquinaswwds_12_tfmaqcod = AV34TFMAQCod;
         AV58Produccion_maquinaswwds_13_tfmaqcod_sel = AV35TFMAQCod_Sel;
         AV59Produccion_maquinaswwds_14_tfmaqdsc = AV36TFMAQDsc;
         AV60Produccion_maquinaswwds_15_tfmaqdsc_sel = AV37TFMAQDsc_Sel;
         AV61Produccion_maquinaswwds_16_tfmaqsts_sels = AV39TFMAQSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1221MAQSts ,
                                              AV61Produccion_maquinaswwds_16_tfmaqsts_sels ,
                                              AV46Produccion_maquinaswwds_1_dynamicfiltersselector1 ,
                                              AV47Produccion_maquinaswwds_2_dynamicfiltersoperator1 ,
                                              AV48Produccion_maquinaswwds_3_maqdsc1 ,
                                              AV49Produccion_maquinaswwds_4_dynamicfiltersenabled2 ,
                                              AV50Produccion_maquinaswwds_5_dynamicfiltersselector2 ,
                                              AV51Produccion_maquinaswwds_6_dynamicfiltersoperator2 ,
                                              AV52Produccion_maquinaswwds_7_maqdsc2 ,
                                              AV53Produccion_maquinaswwds_8_dynamicfiltersenabled3 ,
                                              AV54Produccion_maquinaswwds_9_dynamicfiltersselector3 ,
                                              AV55Produccion_maquinaswwds_10_dynamicfiltersoperator3 ,
                                              AV56Produccion_maquinaswwds_11_maqdsc3 ,
                                              AV58Produccion_maquinaswwds_13_tfmaqcod_sel ,
                                              AV57Produccion_maquinaswwds_12_tfmaqcod ,
                                              AV60Produccion_maquinaswwds_15_tfmaqdsc_sel ,
                                              AV59Produccion_maquinaswwds_14_tfmaqdsc ,
                                              AV61Produccion_maquinaswwds_16_tfmaqsts_sels.Count ,
                                              A1220MAQDsc ,
                                              A320MAQCod ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Produccion_maquinaswwds_3_maqdsc1 = StringUtil.PadR( StringUtil.RTrim( AV48Produccion_maquinaswwds_3_maqdsc1), 100, "%");
         lV48Produccion_maquinaswwds_3_maqdsc1 = StringUtil.PadR( StringUtil.RTrim( AV48Produccion_maquinaswwds_3_maqdsc1), 100, "%");
         lV52Produccion_maquinaswwds_7_maqdsc2 = StringUtil.PadR( StringUtil.RTrim( AV52Produccion_maquinaswwds_7_maqdsc2), 100, "%");
         lV52Produccion_maquinaswwds_7_maqdsc2 = StringUtil.PadR( StringUtil.RTrim( AV52Produccion_maquinaswwds_7_maqdsc2), 100, "%");
         lV56Produccion_maquinaswwds_11_maqdsc3 = StringUtil.PadR( StringUtil.RTrim( AV56Produccion_maquinaswwds_11_maqdsc3), 100, "%");
         lV56Produccion_maquinaswwds_11_maqdsc3 = StringUtil.PadR( StringUtil.RTrim( AV56Produccion_maquinaswwds_11_maqdsc3), 100, "%");
         lV57Produccion_maquinaswwds_12_tfmaqcod = StringUtil.PadR( StringUtil.RTrim( AV57Produccion_maquinaswwds_12_tfmaqcod), 10, "%");
         lV59Produccion_maquinaswwds_14_tfmaqdsc = StringUtil.PadR( StringUtil.RTrim( AV59Produccion_maquinaswwds_14_tfmaqdsc), 100, "%");
         /* Using cursor P00632 */
         pr_default.execute(0, new Object[] {lV48Produccion_maquinaswwds_3_maqdsc1, lV48Produccion_maquinaswwds_3_maqdsc1, lV52Produccion_maquinaswwds_7_maqdsc2, lV52Produccion_maquinaswwds_7_maqdsc2, lV56Produccion_maquinaswwds_11_maqdsc3, lV56Produccion_maquinaswwds_11_maqdsc3, lV57Produccion_maquinaswwds_12_tfmaqcod, AV58Produccion_maquinaswwds_13_tfmaqcod_sel, lV59Produccion_maquinaswwds_14_tfmaqdsc, AV60Produccion_maquinaswwds_15_tfmaqdsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1221MAQSts = P00632_A1221MAQSts[0];
            A320MAQCod = P00632_A320MAQCod[0];
            A1220MAQDsc = P00632_A1220MAQDsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A320MAQCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1220MAQDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( A1221MAQSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "ACTIVO";
            }
            else if ( A1221MAQSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Produccion.MaquinasWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Produccion.MaquinasWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Produccion.MaquinasWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV62GXV2 = 1;
         while ( AV62GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV62GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAQCOD") == 0 )
            {
               AV34TFMAQCod = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAQCOD_SEL") == 0 )
            {
               AV35TFMAQCod_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAQDSC") == 0 )
            {
               AV36TFMAQDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAQDSC_SEL") == 0 )
            {
               AV37TFMAQDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAQSTS_SEL") == 0 )
            {
               AV38TFMAQSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV39TFMAQSts_Sels.FromJSonString(AV38TFMAQSts_SelsJson, null);
            }
            AV62GXV2 = (int)(AV62GXV2+1);
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
         AV20MAQDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24MAQDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28MAQDsc3 = "";
         AV35TFMAQCod_Sel = "";
         AV34TFMAQCod = "";
         AV37TFMAQDsc_Sel = "";
         AV36TFMAQDsc = "";
         AV39TFMAQSts_Sels = new GxSimpleCollection<short>();
         AV46Produccion_maquinaswwds_1_dynamicfiltersselector1 = "";
         AV48Produccion_maquinaswwds_3_maqdsc1 = "";
         AV50Produccion_maquinaswwds_5_dynamicfiltersselector2 = "";
         AV52Produccion_maquinaswwds_7_maqdsc2 = "";
         AV54Produccion_maquinaswwds_9_dynamicfiltersselector3 = "";
         AV56Produccion_maquinaswwds_11_maqdsc3 = "";
         AV57Produccion_maquinaswwds_12_tfmaqcod = "";
         AV58Produccion_maquinaswwds_13_tfmaqcod_sel = "";
         AV59Produccion_maquinaswwds_14_tfmaqdsc = "";
         AV60Produccion_maquinaswwds_15_tfmaqdsc_sel = "";
         AV61Produccion_maquinaswwds_16_tfmaqsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV48Produccion_maquinaswwds_3_maqdsc1 = "";
         lV52Produccion_maquinaswwds_7_maqdsc2 = "";
         lV56Produccion_maquinaswwds_11_maqdsc3 = "";
         lV57Produccion_maquinaswwds_12_tfmaqcod = "";
         lV59Produccion_maquinaswwds_14_tfmaqdsc = "";
         A1220MAQDsc = "";
         A320MAQCod = "";
         P00632_A1221MAQSts = new short[1] ;
         P00632_A320MAQCod = new string[] {""} ;
         P00632_A1220MAQDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38TFMAQSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.maquinaswwexport__default(),
            new Object[][] {
                new Object[] {
               P00632_A1221MAQSts, P00632_A320MAQCod, P00632_A1220MAQDsc
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
      private short AV40TFMAQSts_Sel ;
      private short AV47Produccion_maquinaswwds_2_dynamicfiltersoperator1 ;
      private short AV51Produccion_maquinaswwds_6_dynamicfiltersoperator2 ;
      private short AV55Produccion_maquinaswwds_10_dynamicfiltersoperator3 ;
      private short A1221MAQSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV44GXV1 ;
      private int AV61Produccion_maquinaswwds_16_tfmaqsts_sels_Count ;
      private int AV62GXV2 ;
      private long AV41i ;
      private string AV20MAQDsc1 ;
      private string AV24MAQDsc2 ;
      private string AV28MAQDsc3 ;
      private string AV35TFMAQCod_Sel ;
      private string AV34TFMAQCod ;
      private string AV37TFMAQDsc_Sel ;
      private string AV36TFMAQDsc ;
      private string AV48Produccion_maquinaswwds_3_maqdsc1 ;
      private string AV52Produccion_maquinaswwds_7_maqdsc2 ;
      private string AV56Produccion_maquinaswwds_11_maqdsc3 ;
      private string AV57Produccion_maquinaswwds_12_tfmaqcod ;
      private string AV58Produccion_maquinaswwds_13_tfmaqcod_sel ;
      private string AV59Produccion_maquinaswwds_14_tfmaqdsc ;
      private string AV60Produccion_maquinaswwds_15_tfmaqdsc_sel ;
      private string scmdbuf ;
      private string lV48Produccion_maquinaswwds_3_maqdsc1 ;
      private string lV52Produccion_maquinaswwds_7_maqdsc2 ;
      private string lV56Produccion_maquinaswwds_11_maqdsc3 ;
      private string lV57Produccion_maquinaswwds_12_tfmaqcod ;
      private string lV59Produccion_maquinaswwds_14_tfmaqdsc ;
      private string A1220MAQDsc ;
      private string A320MAQCod ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV49Produccion_maquinaswwds_4_dynamicfiltersenabled2 ;
      private bool AV53Produccion_maquinaswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV38TFMAQSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV46Produccion_maquinaswwds_1_dynamicfiltersselector1 ;
      private string AV50Produccion_maquinaswwds_5_dynamicfiltersselector2 ;
      private string AV54Produccion_maquinaswwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV39TFMAQSts_Sels ;
      private GxSimpleCollection<short> AV61Produccion_maquinaswwds_16_tfmaqsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00632_A1221MAQSts ;
      private string[] P00632_A320MAQCod ;
      private string[] P00632_A1220MAQDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class maquinaswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00632( IGxContext context ,
                                             short A1221MAQSts ,
                                             GxSimpleCollection<short> AV61Produccion_maquinaswwds_16_tfmaqsts_sels ,
                                             string AV46Produccion_maquinaswwds_1_dynamicfiltersselector1 ,
                                             short AV47Produccion_maquinaswwds_2_dynamicfiltersoperator1 ,
                                             string AV48Produccion_maquinaswwds_3_maqdsc1 ,
                                             bool AV49Produccion_maquinaswwds_4_dynamicfiltersenabled2 ,
                                             string AV50Produccion_maquinaswwds_5_dynamicfiltersselector2 ,
                                             short AV51Produccion_maquinaswwds_6_dynamicfiltersoperator2 ,
                                             string AV52Produccion_maquinaswwds_7_maqdsc2 ,
                                             bool AV53Produccion_maquinaswwds_8_dynamicfiltersenabled3 ,
                                             string AV54Produccion_maquinaswwds_9_dynamicfiltersselector3 ,
                                             short AV55Produccion_maquinaswwds_10_dynamicfiltersoperator3 ,
                                             string AV56Produccion_maquinaswwds_11_maqdsc3 ,
                                             string AV58Produccion_maquinaswwds_13_tfmaqcod_sel ,
                                             string AV57Produccion_maquinaswwds_12_tfmaqcod ,
                                             string AV60Produccion_maquinaswwds_15_tfmaqdsc_sel ,
                                             string AV59Produccion_maquinaswwds_14_tfmaqdsc ,
                                             int AV61Produccion_maquinaswwds_16_tfmaqsts_sels_Count ,
                                             string A1220MAQDsc ,
                                             string A320MAQCod ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [MAQSts], [MAQCod], [MAQDsc] FROM [POMAQUINA]";
         if ( ( StringUtil.StrCmp(AV46Produccion_maquinaswwds_1_dynamicfiltersselector1, "MAQDSC") == 0 ) && ( AV47Produccion_maquinaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Produccion_maquinaswwds_3_maqdsc1)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV48Produccion_maquinaswwds_3_maqdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV46Produccion_maquinaswwds_1_dynamicfiltersselector1, "MAQDSC") == 0 ) && ( AV47Produccion_maquinaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Produccion_maquinaswwds_3_maqdsc1)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like '%' + @lV48Produccion_maquinaswwds_3_maqdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV49Produccion_maquinaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV50Produccion_maquinaswwds_5_dynamicfiltersselector2, "MAQDSC") == 0 ) && ( AV51Produccion_maquinaswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Produccion_maquinaswwds_7_maqdsc2)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV52Produccion_maquinaswwds_7_maqdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV49Produccion_maquinaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV50Produccion_maquinaswwds_5_dynamicfiltersselector2, "MAQDSC") == 0 ) && ( AV51Produccion_maquinaswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Produccion_maquinaswwds_7_maqdsc2)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like '%' + @lV52Produccion_maquinaswwds_7_maqdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV53Produccion_maquinaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV54Produccion_maquinaswwds_9_dynamicfiltersselector3, "MAQDSC") == 0 ) && ( AV55Produccion_maquinaswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Produccion_maquinaswwds_11_maqdsc3)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV56Produccion_maquinaswwds_11_maqdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV53Produccion_maquinaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV54Produccion_maquinaswwds_9_dynamicfiltersselector3, "MAQDSC") == 0 ) && ( AV55Produccion_maquinaswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Produccion_maquinaswwds_11_maqdsc3)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like '%' + @lV56Produccion_maquinaswwds_11_maqdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Produccion_maquinaswwds_13_tfmaqcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Produccion_maquinaswwds_12_tfmaqcod)) ) )
         {
            AddWhere(sWhereString, "([MAQCod] like @lV57Produccion_maquinaswwds_12_tfmaqcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Produccion_maquinaswwds_13_tfmaqcod_sel)) )
         {
            AddWhere(sWhereString, "([MAQCod] = @AV58Produccion_maquinaswwds_13_tfmaqcod_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Produccion_maquinaswwds_15_tfmaqdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Produccion_maquinaswwds_14_tfmaqdsc)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV59Produccion_maquinaswwds_14_tfmaqdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Produccion_maquinaswwds_15_tfmaqdsc_sel)) )
         {
            AddWhere(sWhereString, "([MAQDsc] = @AV60Produccion_maquinaswwds_15_tfmaqdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV61Produccion_maquinaswwds_16_tfmaqsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV61Produccion_maquinaswwds_16_tfmaqsts_sels, "[MAQSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MAQCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MAQCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MAQDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MAQDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MAQSts]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MAQSts] DESC";
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
                     return conditional_P00632(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP00632;
          prmP00632 = new Object[] {
          new ParDef("@lV48Produccion_maquinaswwds_3_maqdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV48Produccion_maquinaswwds_3_maqdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV52Produccion_maquinaswwds_7_maqdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV52Produccion_maquinaswwds_7_maqdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV56Produccion_maquinaswwds_11_maqdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV56Produccion_maquinaswwds_11_maqdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV57Produccion_maquinaswwds_12_tfmaqcod",GXType.NChar,10,0) ,
          new ParDef("@AV58Produccion_maquinaswwds_13_tfmaqcod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV59Produccion_maquinaswwds_14_tfmaqdsc",GXType.NChar,100,0) ,
          new ParDef("@AV60Produccion_maquinaswwds_15_tfmaqdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00632", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00632,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
