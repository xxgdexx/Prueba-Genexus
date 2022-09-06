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
   public class sublineawwexport : GXProcedure
   {
      public sublineawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sublineawwexport( IGxContext context )
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
         sublineawwexport objsublineawwexport;
         objsublineawwexport = new sublineawwexport();
         objsublineawwexport.AV11Filename = "" ;
         objsublineawwexport.AV12ErrorMessage = "" ;
         objsublineawwexport.context.SetSubmitInitialConfig(context);
         objsublineawwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objsublineawwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sublineawwexport)stateInfo).executePrivate();
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
         AV11Filename = "SubLineaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "SUBLDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20SublDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20SublDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sub Linea", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sub Linea", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20SublDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "SUBLDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24SublDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SublDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sub Linea", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sub Linea", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24SublDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SUBLDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28SublDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28SublDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sub Linea", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sub Linea", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28SublDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFSublCod) && (0==AV35TFSublCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFSublCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFSublCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSublDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Sub Linea") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFSublDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSublDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Sub Linea") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFSublDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSublAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFSublAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSublAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFSublAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV43TFSublSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV45i = 1;
            AV48GXV1 = 1;
            while ( AV48GXV1 <= AV43TFSublSts_Sels.Count )
            {
               AV44TFSublSts_Sel = (short)(AV43TFSublSts_Sels.GetNumeric(AV48GXV1));
               if ( AV45i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV44TFSublSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV44TFSublSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV45i = (long)(AV45i+1);
               AV48GXV1 = (int)(AV48GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Sub Linea";
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
         AV50Configuracion_sublineawwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV51Configuracion_sublineawwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV52Configuracion_sublineawwds_3_subldsc1 = AV20SublDsc1;
         AV53Configuracion_sublineawwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV54Configuracion_sublineawwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV55Configuracion_sublineawwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV56Configuracion_sublineawwds_7_subldsc2 = AV24SublDsc2;
         AV57Configuracion_sublineawwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV58Configuracion_sublineawwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV59Configuracion_sublineawwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV60Configuracion_sublineawwds_11_subldsc3 = AV28SublDsc3;
         AV61Configuracion_sublineawwds_12_tfsublcod = AV34TFSublCod;
         AV62Configuracion_sublineawwds_13_tfsublcod_to = AV35TFSublCod_To;
         AV63Configuracion_sublineawwds_14_tfsubldsc = AV36TFSublDsc;
         AV64Configuracion_sublineawwds_15_tfsubldsc_sel = AV37TFSublDsc_Sel;
         AV65Configuracion_sublineawwds_16_tfsublabr = AV38TFSublAbr;
         AV66Configuracion_sublineawwds_17_tfsublabr_sel = AV39TFSublAbr_Sel;
         AV67Configuracion_sublineawwds_18_tfsublsts_sels = AV43TFSublSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1893SublSts ,
                                              AV67Configuracion_sublineawwds_18_tfsublsts_sels ,
                                              AV50Configuracion_sublineawwds_1_dynamicfiltersselector1 ,
                                              AV51Configuracion_sublineawwds_2_dynamicfiltersoperator1 ,
                                              AV52Configuracion_sublineawwds_3_subldsc1 ,
                                              AV53Configuracion_sublineawwds_4_dynamicfiltersenabled2 ,
                                              AV54Configuracion_sublineawwds_5_dynamicfiltersselector2 ,
                                              AV55Configuracion_sublineawwds_6_dynamicfiltersoperator2 ,
                                              AV56Configuracion_sublineawwds_7_subldsc2 ,
                                              AV57Configuracion_sublineawwds_8_dynamicfiltersenabled3 ,
                                              AV58Configuracion_sublineawwds_9_dynamicfiltersselector3 ,
                                              AV59Configuracion_sublineawwds_10_dynamicfiltersoperator3 ,
                                              AV60Configuracion_sublineawwds_11_subldsc3 ,
                                              AV61Configuracion_sublineawwds_12_tfsublcod ,
                                              AV62Configuracion_sublineawwds_13_tfsublcod_to ,
                                              AV64Configuracion_sublineawwds_15_tfsubldsc_sel ,
                                              AV63Configuracion_sublineawwds_14_tfsubldsc ,
                                              AV66Configuracion_sublineawwds_17_tfsublabr_sel ,
                                              AV65Configuracion_sublineawwds_16_tfsublabr ,
                                              AV67Configuracion_sublineawwds_18_tfsublsts_sels.Count ,
                                              A1892SublDsc ,
                                              A51SublCod ,
                                              A1891SublAbr ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Configuracion_sublineawwds_3_subldsc1 = StringUtil.PadR( StringUtil.RTrim( AV52Configuracion_sublineawwds_3_subldsc1), 100, "%");
         lV52Configuracion_sublineawwds_3_subldsc1 = StringUtil.PadR( StringUtil.RTrim( AV52Configuracion_sublineawwds_3_subldsc1), 100, "%");
         lV56Configuracion_sublineawwds_7_subldsc2 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_sublineawwds_7_subldsc2), 100, "%");
         lV56Configuracion_sublineawwds_7_subldsc2 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_sublineawwds_7_subldsc2), 100, "%");
         lV60Configuracion_sublineawwds_11_subldsc3 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_sublineawwds_11_subldsc3), 100, "%");
         lV60Configuracion_sublineawwds_11_subldsc3 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_sublineawwds_11_subldsc3), 100, "%");
         lV63Configuracion_sublineawwds_14_tfsubldsc = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_sublineawwds_14_tfsubldsc), 100, "%");
         lV65Configuracion_sublineawwds_16_tfsublabr = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_sublineawwds_16_tfsublabr), 5, "%");
         /* Using cursor P002T2 */
         pr_default.execute(0, new Object[] {lV52Configuracion_sublineawwds_3_subldsc1, lV52Configuracion_sublineawwds_3_subldsc1, lV56Configuracion_sublineawwds_7_subldsc2, lV56Configuracion_sublineawwds_7_subldsc2, lV60Configuracion_sublineawwds_11_subldsc3, lV60Configuracion_sublineawwds_11_subldsc3, AV61Configuracion_sublineawwds_12_tfsublcod, AV62Configuracion_sublineawwds_13_tfsublcod_to, lV63Configuracion_sublineawwds_14_tfsubldsc, AV64Configuracion_sublineawwds_15_tfsubldsc_sel, lV65Configuracion_sublineawwds_16_tfsublabr, AV66Configuracion_sublineawwds_17_tfsublabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1893SublSts = P002T2_A1893SublSts[0];
            A1891SublAbr = P002T2_A1891SublAbr[0];
            A51SublCod = P002T2_A51SublCod[0];
            A1892SublDsc = P002T2_A1892SublDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A51SublCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1892SublDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1891SublAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A1893SublSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "ACTIVO";
            }
            else if ( A1893SublSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.SubLineaWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.SubLineaWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.SubLineaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV68GXV2 = 1;
         while ( AV68GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV68GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSUBLCOD") == 0 )
            {
               AV34TFSublCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFSublCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSUBLDSC") == 0 )
            {
               AV36TFSublDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSUBLDSC_SEL") == 0 )
            {
               AV37TFSublDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSUBLABR") == 0 )
            {
               AV38TFSublAbr = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSUBLABR_SEL") == 0 )
            {
               AV39TFSublAbr_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSUBLSTS_SEL") == 0 )
            {
               AV42TFSublSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV43TFSublSts_Sels.FromJSonString(AV42TFSublSts_SelsJson, null);
            }
            AV68GXV2 = (int)(AV68GXV2+1);
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
         AV20SublDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24SublDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28SublDsc3 = "";
         AV37TFSublDsc_Sel = "";
         AV36TFSublDsc = "";
         AV39TFSublAbr_Sel = "";
         AV38TFSublAbr = "";
         AV43TFSublSts_Sels = new GxSimpleCollection<short>();
         AV50Configuracion_sublineawwds_1_dynamicfiltersselector1 = "";
         AV52Configuracion_sublineawwds_3_subldsc1 = "";
         AV54Configuracion_sublineawwds_5_dynamicfiltersselector2 = "";
         AV56Configuracion_sublineawwds_7_subldsc2 = "";
         AV58Configuracion_sublineawwds_9_dynamicfiltersselector3 = "";
         AV60Configuracion_sublineawwds_11_subldsc3 = "";
         AV63Configuracion_sublineawwds_14_tfsubldsc = "";
         AV64Configuracion_sublineawwds_15_tfsubldsc_sel = "";
         AV65Configuracion_sublineawwds_16_tfsublabr = "";
         AV66Configuracion_sublineawwds_17_tfsublabr_sel = "";
         AV67Configuracion_sublineawwds_18_tfsublsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV52Configuracion_sublineawwds_3_subldsc1 = "";
         lV56Configuracion_sublineawwds_7_subldsc2 = "";
         lV60Configuracion_sublineawwds_11_subldsc3 = "";
         lV63Configuracion_sublineawwds_14_tfsubldsc = "";
         lV65Configuracion_sublineawwds_16_tfsublabr = "";
         A1892SublDsc = "";
         A1891SublAbr = "";
         P002T2_A1893SublSts = new short[1] ;
         P002T2_A1891SublAbr = new string[] {""} ;
         P002T2_A51SublCod = new int[1] ;
         P002T2_A1892SublDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV42TFSublSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.sublineawwexport__default(),
            new Object[][] {
                new Object[] {
               P002T2_A1893SublSts, P002T2_A1891SublAbr, P002T2_A51SublCod, P002T2_A1892SublDsc
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
      private short AV44TFSublSts_Sel ;
      private short AV51Configuracion_sublineawwds_2_dynamicfiltersoperator1 ;
      private short AV55Configuracion_sublineawwds_6_dynamicfiltersoperator2 ;
      private short AV59Configuracion_sublineawwds_10_dynamicfiltersoperator3 ;
      private short A1893SublSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFSublCod ;
      private int AV35TFSublCod_To ;
      private int AV48GXV1 ;
      private int AV61Configuracion_sublineawwds_12_tfsublcod ;
      private int AV62Configuracion_sublineawwds_13_tfsublcod_to ;
      private int AV67Configuracion_sublineawwds_18_tfsublsts_sels_Count ;
      private int A51SublCod ;
      private int AV68GXV2 ;
      private long AV45i ;
      private string AV20SublDsc1 ;
      private string AV24SublDsc2 ;
      private string AV28SublDsc3 ;
      private string AV37TFSublDsc_Sel ;
      private string AV36TFSublDsc ;
      private string AV39TFSublAbr_Sel ;
      private string AV38TFSublAbr ;
      private string AV52Configuracion_sublineawwds_3_subldsc1 ;
      private string AV56Configuracion_sublineawwds_7_subldsc2 ;
      private string AV60Configuracion_sublineawwds_11_subldsc3 ;
      private string AV63Configuracion_sublineawwds_14_tfsubldsc ;
      private string AV64Configuracion_sublineawwds_15_tfsubldsc_sel ;
      private string AV65Configuracion_sublineawwds_16_tfsublabr ;
      private string AV66Configuracion_sublineawwds_17_tfsublabr_sel ;
      private string scmdbuf ;
      private string lV52Configuracion_sublineawwds_3_subldsc1 ;
      private string lV56Configuracion_sublineawwds_7_subldsc2 ;
      private string lV60Configuracion_sublineawwds_11_subldsc3 ;
      private string lV63Configuracion_sublineawwds_14_tfsubldsc ;
      private string lV65Configuracion_sublineawwds_16_tfsublabr ;
      private string A1892SublDsc ;
      private string A1891SublAbr ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV53Configuracion_sublineawwds_4_dynamicfiltersenabled2 ;
      private bool AV57Configuracion_sublineawwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV42TFSublSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV50Configuracion_sublineawwds_1_dynamicfiltersselector1 ;
      private string AV54Configuracion_sublineawwds_5_dynamicfiltersselector2 ;
      private string AV58Configuracion_sublineawwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV43TFSublSts_Sels ;
      private GxSimpleCollection<short> AV67Configuracion_sublineawwds_18_tfsublsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002T2_A1893SublSts ;
      private string[] P002T2_A1891SublAbr ;
      private int[] P002T2_A51SublCod ;
      private string[] P002T2_A1892SublDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class sublineawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002T2( IGxContext context ,
                                             short A1893SublSts ,
                                             GxSimpleCollection<short> AV67Configuracion_sublineawwds_18_tfsublsts_sels ,
                                             string AV50Configuracion_sublineawwds_1_dynamicfiltersselector1 ,
                                             short AV51Configuracion_sublineawwds_2_dynamicfiltersoperator1 ,
                                             string AV52Configuracion_sublineawwds_3_subldsc1 ,
                                             bool AV53Configuracion_sublineawwds_4_dynamicfiltersenabled2 ,
                                             string AV54Configuracion_sublineawwds_5_dynamicfiltersselector2 ,
                                             short AV55Configuracion_sublineawwds_6_dynamicfiltersoperator2 ,
                                             string AV56Configuracion_sublineawwds_7_subldsc2 ,
                                             bool AV57Configuracion_sublineawwds_8_dynamicfiltersenabled3 ,
                                             string AV58Configuracion_sublineawwds_9_dynamicfiltersselector3 ,
                                             short AV59Configuracion_sublineawwds_10_dynamicfiltersoperator3 ,
                                             string AV60Configuracion_sublineawwds_11_subldsc3 ,
                                             int AV61Configuracion_sublineawwds_12_tfsublcod ,
                                             int AV62Configuracion_sublineawwds_13_tfsublcod_to ,
                                             string AV64Configuracion_sublineawwds_15_tfsubldsc_sel ,
                                             string AV63Configuracion_sublineawwds_14_tfsubldsc ,
                                             string AV66Configuracion_sublineawwds_17_tfsublabr_sel ,
                                             string AV65Configuracion_sublineawwds_16_tfsublabr ,
                                             int AV67Configuracion_sublineawwds_18_tfsublsts_sels_Count ,
                                             string A1892SublDsc ,
                                             int A51SublCod ,
                                             string A1891SublAbr ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [SublSts], [SublAbr], [SublCod], [SublDsc] FROM [CSUBLPROD]";
         if ( ( StringUtil.StrCmp(AV50Configuracion_sublineawwds_1_dynamicfiltersselector1, "SUBLDSC") == 0 ) && ( AV51Configuracion_sublineawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracion_sublineawwds_3_subldsc1)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV52Configuracion_sublineawwds_3_subldsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Configuracion_sublineawwds_1_dynamicfiltersselector1, "SUBLDSC") == 0 ) && ( AV51Configuracion_sublineawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracion_sublineawwds_3_subldsc1)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like '%' + @lV52Configuracion_sublineawwds_3_subldsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV53Configuracion_sublineawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Configuracion_sublineawwds_5_dynamicfiltersselector2, "SUBLDSC") == 0 ) && ( AV55Configuracion_sublineawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_sublineawwds_7_subldsc2)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV56Configuracion_sublineawwds_7_subldsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV53Configuracion_sublineawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Configuracion_sublineawwds_5_dynamicfiltersselector2, "SUBLDSC") == 0 ) && ( AV55Configuracion_sublineawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_sublineawwds_7_subldsc2)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like '%' + @lV56Configuracion_sublineawwds_7_subldsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV57Configuracion_sublineawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Configuracion_sublineawwds_9_dynamicfiltersselector3, "SUBLDSC") == 0 ) && ( AV59Configuracion_sublineawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_sublineawwds_11_subldsc3)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV60Configuracion_sublineawwds_11_subldsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV57Configuracion_sublineawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Configuracion_sublineawwds_9_dynamicfiltersselector3, "SUBLDSC") == 0 ) && ( AV59Configuracion_sublineawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_sublineawwds_11_subldsc3)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like '%' + @lV60Configuracion_sublineawwds_11_subldsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV61Configuracion_sublineawwds_12_tfsublcod) )
         {
            AddWhere(sWhereString, "([SublCod] >= @AV61Configuracion_sublineawwds_12_tfsublcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV62Configuracion_sublineawwds_13_tfsublcod_to) )
         {
            AddWhere(sWhereString, "([SublCod] <= @AV62Configuracion_sublineawwds_13_tfsublcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_sublineawwds_15_tfsubldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_sublineawwds_14_tfsubldsc)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV63Configuracion_sublineawwds_14_tfsubldsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_sublineawwds_15_tfsubldsc_sel)) )
         {
            AddWhere(sWhereString, "([SublDsc] = @AV64Configuracion_sublineawwds_15_tfsubldsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_sublineawwds_17_tfsublabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_sublineawwds_16_tfsublabr)) ) )
         {
            AddWhere(sWhereString, "([SublAbr] like @lV65Configuracion_sublineawwds_16_tfsublabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_sublineawwds_17_tfsublabr_sel)) )
         {
            AddWhere(sWhereString, "([SublAbr] = @AV66Configuracion_sublineawwds_17_tfsublabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV67Configuracion_sublineawwds_18_tfsublsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV67Configuracion_sublineawwds_18_tfsublsts_sels, "[SublSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [SublCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [SublCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [SublDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [SublDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [SublAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [SublAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [SublSts]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [SublSts] DESC";
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
                     return conditional_P002T2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP002T2;
          prmP002T2 = new Object[] {
          new ParDef("@lV52Configuracion_sublineawwds_3_subldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV52Configuracion_sublineawwds_3_subldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV56Configuracion_sublineawwds_7_subldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV56Configuracion_sublineawwds_7_subldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV60Configuracion_sublineawwds_11_subldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV60Configuracion_sublineawwds_11_subldsc3",GXType.NChar,100,0) ,
          new ParDef("@AV61Configuracion_sublineawwds_12_tfsublcod",GXType.Int32,6,0) ,
          new ParDef("@AV62Configuracion_sublineawwds_13_tfsublcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV63Configuracion_sublineawwds_14_tfsubldsc",GXType.NChar,100,0) ,
          new ParDef("@AV64Configuracion_sublineawwds_15_tfsubldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_sublineawwds_16_tfsublabr",GXType.NChar,5,0) ,
          new ParDef("@AV66Configuracion_sublineawwds_17_tfsublabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002T2,100, GxCacheFrequency.OFF ,true,false )
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
