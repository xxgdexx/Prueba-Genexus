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
   public class familiawwexport : GXProcedure
   {
      public familiawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public familiawwexport( IGxContext context )
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
         familiawwexport objfamiliawwexport;
         objfamiliawwexport = new familiawwexport();
         objfamiliawwexport.AV11Filename = "" ;
         objfamiliawwexport.AV12ErrorMessage = "" ;
         objfamiliawwexport.context.SetSubmitInitialConfig(context);
         objfamiliawwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objfamiliawwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((familiawwexport)stateInfo).executePrivate();
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
         AV11Filename = "FamiliaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "FAMDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20FamDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20FamDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Familia", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Familia", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20FamDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "FAMDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24FamDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24FamDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Familia", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Familia", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24FamDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "FAMDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28FamDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28FamDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Familia", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Familia", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28FamDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFFamCod) && (0==AV35TFFamCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFFamCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFFamCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFFamDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Familia") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFFamDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFFamDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Familia") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFFamDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFFamAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFFamAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFFamAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFFamAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV41TFFamSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV43i = 1;
            AV46GXV1 = 1;
            while ( AV46GXV1 <= AV41TFFamSts_Sels.Count )
            {
               AV42TFFamSts_Sel = (short)(AV41TFFamSts_Sels.GetNumeric(AV46GXV1));
               if ( AV43i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV42TFFamSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV42TFFamSts_Sel == 0 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Familia";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Abreviatura";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Estado";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Foto";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV48Configuracion_familiawwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV49Configuracion_familiawwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV50Configuracion_familiawwds_3_famdsc1 = AV20FamDsc1;
         AV51Configuracion_familiawwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV52Configuracion_familiawwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV53Configuracion_familiawwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV54Configuracion_familiawwds_7_famdsc2 = AV24FamDsc2;
         AV55Configuracion_familiawwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV56Configuracion_familiawwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV57Configuracion_familiawwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV58Configuracion_familiawwds_11_famdsc3 = AV28FamDsc3;
         AV59Configuracion_familiawwds_12_tffamcod = AV34TFFamCod;
         AV60Configuracion_familiawwds_13_tffamcod_to = AV35TFFamCod_To;
         AV61Configuracion_familiawwds_14_tffamdsc = AV36TFFamDsc;
         AV62Configuracion_familiawwds_15_tffamdsc_sel = AV37TFFamDsc_Sel;
         AV63Configuracion_familiawwds_16_tffamabr = AV38TFFamAbr;
         AV64Configuracion_familiawwds_17_tffamabr_sel = AV39TFFamAbr_Sel;
         AV65Configuracion_familiawwds_18_tffamsts_sels = AV41TFFamSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A979FamSts ,
                                              AV65Configuracion_familiawwds_18_tffamsts_sels ,
                                              AV48Configuracion_familiawwds_1_dynamicfiltersselector1 ,
                                              AV49Configuracion_familiawwds_2_dynamicfiltersoperator1 ,
                                              AV50Configuracion_familiawwds_3_famdsc1 ,
                                              AV51Configuracion_familiawwds_4_dynamicfiltersenabled2 ,
                                              AV52Configuracion_familiawwds_5_dynamicfiltersselector2 ,
                                              AV53Configuracion_familiawwds_6_dynamicfiltersoperator2 ,
                                              AV54Configuracion_familiawwds_7_famdsc2 ,
                                              AV55Configuracion_familiawwds_8_dynamicfiltersenabled3 ,
                                              AV56Configuracion_familiawwds_9_dynamicfiltersselector3 ,
                                              AV57Configuracion_familiawwds_10_dynamicfiltersoperator3 ,
                                              AV58Configuracion_familiawwds_11_famdsc3 ,
                                              AV59Configuracion_familiawwds_12_tffamcod ,
                                              AV60Configuracion_familiawwds_13_tffamcod_to ,
                                              AV62Configuracion_familiawwds_15_tffamdsc_sel ,
                                              AV61Configuracion_familiawwds_14_tffamdsc ,
                                              AV64Configuracion_familiawwds_17_tffamabr_sel ,
                                              AV63Configuracion_familiawwds_16_tffamabr ,
                                              AV65Configuracion_familiawwds_18_tffamsts_sels.Count ,
                                              A977FamDsc ,
                                              A50FamCod ,
                                              A976FamAbr ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV50Configuracion_familiawwds_3_famdsc1 = StringUtil.PadR( StringUtil.RTrim( AV50Configuracion_familiawwds_3_famdsc1), 100, "%");
         lV50Configuracion_familiawwds_3_famdsc1 = StringUtil.PadR( StringUtil.RTrim( AV50Configuracion_familiawwds_3_famdsc1), 100, "%");
         lV54Configuracion_familiawwds_7_famdsc2 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_familiawwds_7_famdsc2), 100, "%");
         lV54Configuracion_familiawwds_7_famdsc2 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_familiawwds_7_famdsc2), 100, "%");
         lV58Configuracion_familiawwds_11_famdsc3 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_familiawwds_11_famdsc3), 100, "%");
         lV58Configuracion_familiawwds_11_famdsc3 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_familiawwds_11_famdsc3), 100, "%");
         lV61Configuracion_familiawwds_14_tffamdsc = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_familiawwds_14_tffamdsc), 100, "%");
         lV63Configuracion_familiawwds_16_tffamabr = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_familiawwds_16_tffamabr), 5, "%");
         /* Using cursor P002Z2 */
         pr_default.execute(0, new Object[] {lV50Configuracion_familiawwds_3_famdsc1, lV50Configuracion_familiawwds_3_famdsc1, lV54Configuracion_familiawwds_7_famdsc2, lV54Configuracion_familiawwds_7_famdsc2, lV58Configuracion_familiawwds_11_famdsc3, lV58Configuracion_familiawwds_11_famdsc3, AV59Configuracion_familiawwds_12_tffamcod, AV60Configuracion_familiawwds_13_tffamcod_to, lV61Configuracion_familiawwds_14_tffamdsc, AV62Configuracion_familiawwds_15_tffamdsc_sel, lV63Configuracion_familiawwds_16_tffamabr, AV64Configuracion_familiawwds_17_tffamabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A979FamSts = P002Z2_A979FamSts[0];
            A976FamAbr = P002Z2_A976FamAbr[0];
            A50FamCod = P002Z2_A50FamCod[0];
            A977FamDsc = P002Z2_A977FamDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A50FamCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A977FamDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A976FamAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A979FamSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "ACTIVO";
            }
            else if ( A979FamSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "INACTIVO";
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.FamiliaWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.FamiliaWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.FamiliaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV66GXV2 = 1;
         while ( AV66GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV66GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFAMCOD") == 0 )
            {
               AV34TFFamCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFFamCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFAMDSC") == 0 )
            {
               AV36TFFamDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFAMDSC_SEL") == 0 )
            {
               AV37TFFamDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFAMABR") == 0 )
            {
               AV38TFFamAbr = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFAMABR_SEL") == 0 )
            {
               AV39TFFamAbr_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFAMSTS_SEL") == 0 )
            {
               AV40TFFamSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV41TFFamSts_Sels.FromJSonString(AV40TFFamSts_SelsJson, null);
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
         AV20FamDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24FamDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28FamDsc3 = "";
         AV37TFFamDsc_Sel = "";
         AV36TFFamDsc = "";
         AV39TFFamAbr_Sel = "";
         AV38TFFamAbr = "";
         AV41TFFamSts_Sels = new GxSimpleCollection<short>();
         AV48Configuracion_familiawwds_1_dynamicfiltersselector1 = "";
         AV50Configuracion_familiawwds_3_famdsc1 = "";
         AV52Configuracion_familiawwds_5_dynamicfiltersselector2 = "";
         AV54Configuracion_familiawwds_7_famdsc2 = "";
         AV56Configuracion_familiawwds_9_dynamicfiltersselector3 = "";
         AV58Configuracion_familiawwds_11_famdsc3 = "";
         AV61Configuracion_familiawwds_14_tffamdsc = "";
         AV62Configuracion_familiawwds_15_tffamdsc_sel = "";
         AV63Configuracion_familiawwds_16_tffamabr = "";
         AV64Configuracion_familiawwds_17_tffamabr_sel = "";
         AV65Configuracion_familiawwds_18_tffamsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV50Configuracion_familiawwds_3_famdsc1 = "";
         lV54Configuracion_familiawwds_7_famdsc2 = "";
         lV58Configuracion_familiawwds_11_famdsc3 = "";
         lV61Configuracion_familiawwds_14_tffamdsc = "";
         lV63Configuracion_familiawwds_16_tffamabr = "";
         A977FamDsc = "";
         A976FamAbr = "";
         P002Z2_A979FamSts = new short[1] ;
         P002Z2_A976FamAbr = new string[] {""} ;
         P002Z2_A50FamCod = new int[1] ;
         P002Z2_A977FamDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40TFFamSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.familiawwexport__default(),
            new Object[][] {
                new Object[] {
               P002Z2_A979FamSts, P002Z2_A976FamAbr, P002Z2_A50FamCod, P002Z2_A977FamDsc
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
      private short AV42TFFamSts_Sel ;
      private short AV49Configuracion_familiawwds_2_dynamicfiltersoperator1 ;
      private short AV53Configuracion_familiawwds_6_dynamicfiltersoperator2 ;
      private short AV57Configuracion_familiawwds_10_dynamicfiltersoperator3 ;
      private short A979FamSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFFamCod ;
      private int AV35TFFamCod_To ;
      private int AV46GXV1 ;
      private int AV59Configuracion_familiawwds_12_tffamcod ;
      private int AV60Configuracion_familiawwds_13_tffamcod_to ;
      private int AV65Configuracion_familiawwds_18_tffamsts_sels_Count ;
      private int A50FamCod ;
      private int AV66GXV2 ;
      private long AV43i ;
      private string AV20FamDsc1 ;
      private string AV24FamDsc2 ;
      private string AV28FamDsc3 ;
      private string AV37TFFamDsc_Sel ;
      private string AV36TFFamDsc ;
      private string AV39TFFamAbr_Sel ;
      private string AV38TFFamAbr ;
      private string AV50Configuracion_familiawwds_3_famdsc1 ;
      private string AV54Configuracion_familiawwds_7_famdsc2 ;
      private string AV58Configuracion_familiawwds_11_famdsc3 ;
      private string AV61Configuracion_familiawwds_14_tffamdsc ;
      private string AV62Configuracion_familiawwds_15_tffamdsc_sel ;
      private string AV63Configuracion_familiawwds_16_tffamabr ;
      private string AV64Configuracion_familiawwds_17_tffamabr_sel ;
      private string scmdbuf ;
      private string lV50Configuracion_familiawwds_3_famdsc1 ;
      private string lV54Configuracion_familiawwds_7_famdsc2 ;
      private string lV58Configuracion_familiawwds_11_famdsc3 ;
      private string lV61Configuracion_familiawwds_14_tffamdsc ;
      private string lV63Configuracion_familiawwds_16_tffamabr ;
      private string A977FamDsc ;
      private string A976FamAbr ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV51Configuracion_familiawwds_4_dynamicfiltersenabled2 ;
      private bool AV55Configuracion_familiawwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV40TFFamSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV48Configuracion_familiawwds_1_dynamicfiltersselector1 ;
      private string AV52Configuracion_familiawwds_5_dynamicfiltersselector2 ;
      private string AV56Configuracion_familiawwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV41TFFamSts_Sels ;
      private GxSimpleCollection<short> AV65Configuracion_familiawwds_18_tffamsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002Z2_A979FamSts ;
      private string[] P002Z2_A976FamAbr ;
      private int[] P002Z2_A50FamCod ;
      private string[] P002Z2_A977FamDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class familiawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002Z2( IGxContext context ,
                                             short A979FamSts ,
                                             GxSimpleCollection<short> AV65Configuracion_familiawwds_18_tffamsts_sels ,
                                             string AV48Configuracion_familiawwds_1_dynamicfiltersselector1 ,
                                             short AV49Configuracion_familiawwds_2_dynamicfiltersoperator1 ,
                                             string AV50Configuracion_familiawwds_3_famdsc1 ,
                                             bool AV51Configuracion_familiawwds_4_dynamicfiltersenabled2 ,
                                             string AV52Configuracion_familiawwds_5_dynamicfiltersselector2 ,
                                             short AV53Configuracion_familiawwds_6_dynamicfiltersoperator2 ,
                                             string AV54Configuracion_familiawwds_7_famdsc2 ,
                                             bool AV55Configuracion_familiawwds_8_dynamicfiltersenabled3 ,
                                             string AV56Configuracion_familiawwds_9_dynamicfiltersselector3 ,
                                             short AV57Configuracion_familiawwds_10_dynamicfiltersoperator3 ,
                                             string AV58Configuracion_familiawwds_11_famdsc3 ,
                                             int AV59Configuracion_familiawwds_12_tffamcod ,
                                             int AV60Configuracion_familiawwds_13_tffamcod_to ,
                                             string AV62Configuracion_familiawwds_15_tffamdsc_sel ,
                                             string AV61Configuracion_familiawwds_14_tffamdsc ,
                                             string AV64Configuracion_familiawwds_17_tffamabr_sel ,
                                             string AV63Configuracion_familiawwds_16_tffamabr ,
                                             int AV65Configuracion_familiawwds_18_tffamsts_sels_Count ,
                                             string A977FamDsc ,
                                             int A50FamCod ,
                                             string A976FamAbr ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [FamSts], [FamAbr], [FamCod], [FamDsc] FROM [CFAMILIA]";
         if ( ( StringUtil.StrCmp(AV48Configuracion_familiawwds_1_dynamicfiltersselector1, "FAMDSC") == 0 ) && ( AV49Configuracion_familiawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Configuracion_familiawwds_3_famdsc1)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV50Configuracion_familiawwds_3_famdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV48Configuracion_familiawwds_1_dynamicfiltersselector1, "FAMDSC") == 0 ) && ( AV49Configuracion_familiawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Configuracion_familiawwds_3_famdsc1)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like '%' + @lV50Configuracion_familiawwds_3_famdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV51Configuracion_familiawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV52Configuracion_familiawwds_5_dynamicfiltersselector2, "FAMDSC") == 0 ) && ( AV53Configuracion_familiawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_familiawwds_7_famdsc2)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV54Configuracion_familiawwds_7_famdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV51Configuracion_familiawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV52Configuracion_familiawwds_5_dynamicfiltersselector2, "FAMDSC") == 0 ) && ( AV53Configuracion_familiawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_familiawwds_7_famdsc2)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like '%' + @lV54Configuracion_familiawwds_7_famdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV55Configuracion_familiawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Configuracion_familiawwds_9_dynamicfiltersselector3, "FAMDSC") == 0 ) && ( AV57Configuracion_familiawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_familiawwds_11_famdsc3)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV58Configuracion_familiawwds_11_famdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV55Configuracion_familiawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Configuracion_familiawwds_9_dynamicfiltersselector3, "FAMDSC") == 0 ) && ( AV57Configuracion_familiawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_familiawwds_11_famdsc3)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like '%' + @lV58Configuracion_familiawwds_11_famdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV59Configuracion_familiawwds_12_tffamcod) )
         {
            AddWhere(sWhereString, "([FamCod] >= @AV59Configuracion_familiawwds_12_tffamcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV60Configuracion_familiawwds_13_tffamcod_to) )
         {
            AddWhere(sWhereString, "([FamCod] <= @AV60Configuracion_familiawwds_13_tffamcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_familiawwds_15_tffamdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_familiawwds_14_tffamdsc)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV61Configuracion_familiawwds_14_tffamdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_familiawwds_15_tffamdsc_sel)) )
         {
            AddWhere(sWhereString, "([FamDsc] = @AV62Configuracion_familiawwds_15_tffamdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_familiawwds_17_tffamabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_familiawwds_16_tffamabr)) ) )
         {
            AddWhere(sWhereString, "([FamAbr] like @lV63Configuracion_familiawwds_16_tffamabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_familiawwds_17_tffamabr_sel)) )
         {
            AddWhere(sWhereString, "([FamAbr] = @AV64Configuracion_familiawwds_17_tffamabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV65Configuracion_familiawwds_18_tffamsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV65Configuracion_familiawwds_18_tffamsts_sels, "[FamSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [FamCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [FamCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [FamDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [FamDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [FamAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [FamAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [FamSts]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [FamSts] DESC";
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
                     return conditional_P002Z2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP002Z2;
          prmP002Z2 = new Object[] {
          new ParDef("@lV50Configuracion_familiawwds_3_famdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV50Configuracion_familiawwds_3_famdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV54Configuracion_familiawwds_7_famdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV54Configuracion_familiawwds_7_famdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_familiawwds_11_famdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_familiawwds_11_famdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV59Configuracion_familiawwds_12_tffamcod",GXType.Int32,6,0) ,
          new ParDef("@AV60Configuracion_familiawwds_13_tffamcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV61Configuracion_familiawwds_14_tffamdsc",GXType.NChar,100,0) ,
          new ParDef("@AV62Configuracion_familiawwds_15_tffamdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_familiawwds_16_tffamabr",GXType.NChar,5,0) ,
          new ParDef("@AV64Configuracion_familiawwds_17_tffamabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Z2,100, GxCacheFrequency.OFF ,true,false )
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
