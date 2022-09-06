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
   public class empresastransporteswwexport : GXProcedure
   {
      public empresastransporteswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public empresastransporteswwexport( IGxContext context )
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
         empresastransporteswwexport objempresastransporteswwexport;
         objempresastransporteswwexport = new empresastransporteswwexport();
         objempresastransporteswwexport.AV11Filename = "" ;
         objempresastransporteswwexport.AV12ErrorMessage = "" ;
         objempresastransporteswwexport.context.SetSubmitInitialConfig(context);
         objempresastransporteswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objempresastransporteswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((empresastransporteswwexport)stateInfo).executePrivate();
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
         AV11Filename = "EmpresasTransportesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "EMPTDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20EmpTDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20EmpTDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Empresa de Transporte", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Empresa de Transporte", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20EmpTDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "EMPTDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24EmpTDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24EmpTDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Empresa de Transporte", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Empresa de Transporte", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24EmpTDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "EMPTDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28EmpTDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28EmpTDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Empresa de Transporte", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Empresa de Transporte", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28EmpTDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFEmpTCod) && (0==AV35TFEmpTCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFEmpTCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFEmpTCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFEmpTDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Empresa de Transporte") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFEmpTDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFEmpTDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Empresa de Transporte") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFEmpTDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFEmptDir_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Dirección") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFEmptDir_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEmptDir)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Dirección") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFEmptDir, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFEmpTRuc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "R.U.C.") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFEmpTRuc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFEmpTRuc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "R.U.C.") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFEmpTRuc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV43TFEmpTSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV45i = 1;
            AV48GXV1 = 1;
            while ( AV48GXV1 <= AV43TFEmpTSts_Sels.Count )
            {
               AV44TFEmpTSts_Sel = (short)(AV43TFEmpTSts_Sels.GetNumeric(AV48GXV1));
               if ( AV45i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV44TFEmpTSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV44TFEmpTSts_Sel == 0 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Empresa de Transporte";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Dirección";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "R.U.C.";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV50Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV51Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV52Configuracion_empresastransporteswwds_3_emptdsc1 = AV20EmpTDsc1;
         AV53Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV54Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV55Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV56Configuracion_empresastransporteswwds_7_emptdsc2 = AV24EmpTDsc2;
         AV57Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV58Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV59Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV60Configuracion_empresastransporteswwds_11_emptdsc3 = AV28EmpTDsc3;
         AV61Configuracion_empresastransporteswwds_12_tfemptcod = AV34TFEmpTCod;
         AV62Configuracion_empresastransporteswwds_13_tfemptcod_to = AV35TFEmpTCod_To;
         AV63Configuracion_empresastransporteswwds_14_tfemptdsc = AV36TFEmpTDsc;
         AV64Configuracion_empresastransporteswwds_15_tfemptdsc_sel = AV37TFEmpTDsc_Sel;
         AV65Configuracion_empresastransporteswwds_16_tfemptdir = AV38TFEmptDir;
         AV66Configuracion_empresastransporteswwds_17_tfemptdir_sel = AV39TFEmptDir_Sel;
         AV67Configuracion_empresastransporteswwds_18_tfemptruc = AV40TFEmpTRuc;
         AV68Configuracion_empresastransporteswwds_19_tfemptruc_sel = AV41TFEmpTRuc_Sel;
         AV69Configuracion_empresastransporteswwds_20_tfemptsts_sels = AV43TFEmpTSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A967EmpTSts ,
                                              AV69Configuracion_empresastransporteswwds_20_tfemptsts_sels ,
                                              AV50Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 ,
                                              AV51Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 ,
                                              AV52Configuracion_empresastransporteswwds_3_emptdsc1 ,
                                              AV53Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 ,
                                              AV54Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 ,
                                              AV55Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 ,
                                              AV56Configuracion_empresastransporteswwds_7_emptdsc2 ,
                                              AV57Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 ,
                                              AV58Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 ,
                                              AV59Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 ,
                                              AV60Configuracion_empresastransporteswwds_11_emptdsc3 ,
                                              AV61Configuracion_empresastransporteswwds_12_tfemptcod ,
                                              AV62Configuracion_empresastransporteswwds_13_tfemptcod_to ,
                                              AV64Configuracion_empresastransporteswwds_15_tfemptdsc_sel ,
                                              AV63Configuracion_empresastransporteswwds_14_tfemptdsc ,
                                              AV66Configuracion_empresastransporteswwds_17_tfemptdir_sel ,
                                              AV65Configuracion_empresastransporteswwds_16_tfemptdir ,
                                              AV68Configuracion_empresastransporteswwds_19_tfemptruc_sel ,
                                              AV67Configuracion_empresastransporteswwds_18_tfemptruc ,
                                              AV69Configuracion_empresastransporteswwds_20_tfemptsts_sels.Count ,
                                              A964EmpTDsc ,
                                              A17EmpTCod ,
                                              A963EmptDir ,
                                              A966EmpTRuc ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Configuracion_empresastransporteswwds_3_emptdsc1 = StringUtil.Concat( StringUtil.RTrim( AV52Configuracion_empresastransporteswwds_3_emptdsc1), "%", "");
         lV52Configuracion_empresastransporteswwds_3_emptdsc1 = StringUtil.Concat( StringUtil.RTrim( AV52Configuracion_empresastransporteswwds_3_emptdsc1), "%", "");
         lV56Configuracion_empresastransporteswwds_7_emptdsc2 = StringUtil.Concat( StringUtil.RTrim( AV56Configuracion_empresastransporteswwds_7_emptdsc2), "%", "");
         lV56Configuracion_empresastransporteswwds_7_emptdsc2 = StringUtil.Concat( StringUtil.RTrim( AV56Configuracion_empresastransporteswwds_7_emptdsc2), "%", "");
         lV60Configuracion_empresastransporteswwds_11_emptdsc3 = StringUtil.Concat( StringUtil.RTrim( AV60Configuracion_empresastransporteswwds_11_emptdsc3), "%", "");
         lV60Configuracion_empresastransporteswwds_11_emptdsc3 = StringUtil.Concat( StringUtil.RTrim( AV60Configuracion_empresastransporteswwds_11_emptdsc3), "%", "");
         lV63Configuracion_empresastransporteswwds_14_tfemptdsc = StringUtil.Concat( StringUtil.RTrim( AV63Configuracion_empresastransporteswwds_14_tfemptdsc), "%", "");
         lV65Configuracion_empresastransporteswwds_16_tfemptdir = StringUtil.Concat( StringUtil.RTrim( AV65Configuracion_empresastransporteswwds_16_tfemptdir), "%", "");
         lV67Configuracion_empresastransporteswwds_18_tfemptruc = StringUtil.Concat( StringUtil.RTrim( AV67Configuracion_empresastransporteswwds_18_tfemptruc), "%", "");
         /* Using cursor P00352 */
         pr_default.execute(0, new Object[] {lV52Configuracion_empresastransporteswwds_3_emptdsc1, lV52Configuracion_empresastransporteswwds_3_emptdsc1, lV56Configuracion_empresastransporteswwds_7_emptdsc2, lV56Configuracion_empresastransporteswwds_7_emptdsc2, lV60Configuracion_empresastransporteswwds_11_emptdsc3, lV60Configuracion_empresastransporteswwds_11_emptdsc3, AV61Configuracion_empresastransporteswwds_12_tfemptcod, AV62Configuracion_empresastransporteswwds_13_tfemptcod_to, lV63Configuracion_empresastransporteswwds_14_tfemptdsc, AV64Configuracion_empresastransporteswwds_15_tfemptdsc_sel, lV65Configuracion_empresastransporteswwds_16_tfemptdir, AV66Configuracion_empresastransporteswwds_17_tfemptdir_sel, lV67Configuracion_empresastransporteswwds_18_tfemptruc, AV68Configuracion_empresastransporteswwds_19_tfemptruc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A967EmpTSts = P00352_A967EmpTSts[0];
            A966EmpTRuc = P00352_A966EmpTRuc[0];
            A963EmptDir = P00352_A963EmptDir[0];
            A17EmpTCod = P00352_A17EmpTCod[0];
            A964EmpTDsc = P00352_A964EmpTDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A17EmpTCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A964EmpTDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A963EmptDir, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A966EmpTRuc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A967EmpTSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "ACTIVO";
            }
            else if ( A967EmpTSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.EmpresasTransportesWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.EmpresasTransportesWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.EmpresasTransportesWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV70GXV2 = 1;
         while ( AV70GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV70GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFEMPTCOD") == 0 )
            {
               AV34TFEmpTCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFEmpTCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFEMPTDSC") == 0 )
            {
               AV36TFEmpTDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFEMPTDSC_SEL") == 0 )
            {
               AV37TFEmpTDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFEMPTDIR") == 0 )
            {
               AV38TFEmptDir = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFEMPTDIR_SEL") == 0 )
            {
               AV39TFEmptDir_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFEMPTRUC") == 0 )
            {
               AV40TFEmpTRuc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFEMPTRUC_SEL") == 0 )
            {
               AV41TFEmpTRuc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFEMPTSTS_SEL") == 0 )
            {
               AV42TFEmpTSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV43TFEmpTSts_Sels.FromJSonString(AV42TFEmpTSts_SelsJson, null);
            }
            AV70GXV2 = (int)(AV70GXV2+1);
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
         AV20EmpTDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24EmpTDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28EmpTDsc3 = "";
         AV37TFEmpTDsc_Sel = "";
         AV36TFEmpTDsc = "";
         AV39TFEmptDir_Sel = "";
         AV38TFEmptDir = "";
         AV41TFEmpTRuc_Sel = "";
         AV40TFEmpTRuc = "";
         AV43TFEmpTSts_Sels = new GxSimpleCollection<short>();
         AV50Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 = "";
         AV52Configuracion_empresastransporteswwds_3_emptdsc1 = "";
         AV54Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 = "";
         AV56Configuracion_empresastransporteswwds_7_emptdsc2 = "";
         AV58Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 = "";
         AV60Configuracion_empresastransporteswwds_11_emptdsc3 = "";
         AV63Configuracion_empresastransporteswwds_14_tfemptdsc = "";
         AV64Configuracion_empresastransporteswwds_15_tfemptdsc_sel = "";
         AV65Configuracion_empresastransporteswwds_16_tfemptdir = "";
         AV66Configuracion_empresastransporteswwds_17_tfemptdir_sel = "";
         AV67Configuracion_empresastransporteswwds_18_tfemptruc = "";
         AV68Configuracion_empresastransporteswwds_19_tfemptruc_sel = "";
         AV69Configuracion_empresastransporteswwds_20_tfemptsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV52Configuracion_empresastransporteswwds_3_emptdsc1 = "";
         lV56Configuracion_empresastransporteswwds_7_emptdsc2 = "";
         lV60Configuracion_empresastransporteswwds_11_emptdsc3 = "";
         lV63Configuracion_empresastransporteswwds_14_tfemptdsc = "";
         lV65Configuracion_empresastransporteswwds_16_tfemptdir = "";
         lV67Configuracion_empresastransporteswwds_18_tfemptruc = "";
         A964EmpTDsc = "";
         A963EmptDir = "";
         A966EmpTRuc = "";
         P00352_A967EmpTSts = new short[1] ;
         P00352_A966EmpTRuc = new string[] {""} ;
         P00352_A963EmptDir = new string[] {""} ;
         P00352_A17EmpTCod = new int[1] ;
         P00352_A964EmpTDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV42TFEmpTSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.empresastransporteswwexport__default(),
            new Object[][] {
                new Object[] {
               P00352_A967EmpTSts, P00352_A966EmpTRuc, P00352_A963EmptDir, P00352_A17EmpTCod, P00352_A964EmpTDsc
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
      private short AV44TFEmpTSts_Sel ;
      private short AV51Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 ;
      private short AV55Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 ;
      private short AV59Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 ;
      private short A967EmpTSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFEmpTCod ;
      private int AV35TFEmpTCod_To ;
      private int AV48GXV1 ;
      private int AV61Configuracion_empresastransporteswwds_12_tfemptcod ;
      private int AV62Configuracion_empresastransporteswwds_13_tfemptcod_to ;
      private int AV69Configuracion_empresastransporteswwds_20_tfemptsts_sels_Count ;
      private int A17EmpTCod ;
      private int AV70GXV2 ;
      private long AV45i ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV53Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 ;
      private bool AV57Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV42TFEmpTSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20EmpTDsc1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24EmpTDsc2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28EmpTDsc3 ;
      private string AV37TFEmpTDsc_Sel ;
      private string AV36TFEmpTDsc ;
      private string AV39TFEmptDir_Sel ;
      private string AV38TFEmptDir ;
      private string AV41TFEmpTRuc_Sel ;
      private string AV40TFEmpTRuc ;
      private string AV50Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 ;
      private string AV52Configuracion_empresastransporteswwds_3_emptdsc1 ;
      private string AV54Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 ;
      private string AV56Configuracion_empresastransporteswwds_7_emptdsc2 ;
      private string AV58Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 ;
      private string AV60Configuracion_empresastransporteswwds_11_emptdsc3 ;
      private string AV63Configuracion_empresastransporteswwds_14_tfemptdsc ;
      private string AV64Configuracion_empresastransporteswwds_15_tfemptdsc_sel ;
      private string AV65Configuracion_empresastransporteswwds_16_tfemptdir ;
      private string AV66Configuracion_empresastransporteswwds_17_tfemptdir_sel ;
      private string AV67Configuracion_empresastransporteswwds_18_tfemptruc ;
      private string AV68Configuracion_empresastransporteswwds_19_tfemptruc_sel ;
      private string lV52Configuracion_empresastransporteswwds_3_emptdsc1 ;
      private string lV56Configuracion_empresastransporteswwds_7_emptdsc2 ;
      private string lV60Configuracion_empresastransporteswwds_11_emptdsc3 ;
      private string lV63Configuracion_empresastransporteswwds_14_tfemptdsc ;
      private string lV65Configuracion_empresastransporteswwds_16_tfemptdir ;
      private string lV67Configuracion_empresastransporteswwds_18_tfemptruc ;
      private string A964EmpTDsc ;
      private string A963EmptDir ;
      private string A966EmpTRuc ;
      private GxSimpleCollection<short> AV43TFEmpTSts_Sels ;
      private GxSimpleCollection<short> AV69Configuracion_empresastransporteswwds_20_tfemptsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00352_A967EmpTSts ;
      private string[] P00352_A966EmpTRuc ;
      private string[] P00352_A963EmptDir ;
      private int[] P00352_A17EmpTCod ;
      private string[] P00352_A964EmpTDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class empresastransporteswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00352( IGxContext context ,
                                             short A967EmpTSts ,
                                             GxSimpleCollection<short> AV69Configuracion_empresastransporteswwds_20_tfemptsts_sels ,
                                             string AV50Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 ,
                                             short AV51Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 ,
                                             string AV52Configuracion_empresastransporteswwds_3_emptdsc1 ,
                                             bool AV53Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 ,
                                             string AV54Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 ,
                                             short AV55Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 ,
                                             string AV56Configuracion_empresastransporteswwds_7_emptdsc2 ,
                                             bool AV57Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 ,
                                             string AV58Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 ,
                                             short AV59Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 ,
                                             string AV60Configuracion_empresastransporteswwds_11_emptdsc3 ,
                                             int AV61Configuracion_empresastransporteswwds_12_tfemptcod ,
                                             int AV62Configuracion_empresastransporteswwds_13_tfemptcod_to ,
                                             string AV64Configuracion_empresastransporteswwds_15_tfemptdsc_sel ,
                                             string AV63Configuracion_empresastransporteswwds_14_tfemptdsc ,
                                             string AV66Configuracion_empresastransporteswwds_17_tfemptdir_sel ,
                                             string AV65Configuracion_empresastransporteswwds_16_tfemptdir ,
                                             string AV68Configuracion_empresastransporteswwds_19_tfemptruc_sel ,
                                             string AV67Configuracion_empresastransporteswwds_18_tfemptruc ,
                                             int AV69Configuracion_empresastransporteswwds_20_tfemptsts_sels_Count ,
                                             string A964EmpTDsc ,
                                             int A17EmpTCod ,
                                             string A963EmptDir ,
                                             string A966EmpTRuc ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [EmpTSts], [EmpTRuc], [EmptDir], [EmpTCod], [EmpTDsc] FROM [CEMPTRANSPORTE]";
         if ( ( StringUtil.StrCmp(AV50Configuracion_empresastransporteswwds_1_dynamicfiltersselector1, "EMPTDSC") == 0 ) && ( AV51Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracion_empresastransporteswwds_3_emptdsc1)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV52Configuracion_empresastransporteswwds_3_emptdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Configuracion_empresastransporteswwds_1_dynamicfiltersselector1, "EMPTDSC") == 0 ) && ( AV51Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracion_empresastransporteswwds_3_emptdsc1)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV52Configuracion_empresastransporteswwds_3_emptdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV53Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Configuracion_empresastransporteswwds_5_dynamicfiltersselector2, "EMPTDSC") == 0 ) && ( AV55Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_empresastransporteswwds_7_emptdsc2)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV56Configuracion_empresastransporteswwds_7_emptdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV53Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Configuracion_empresastransporteswwds_5_dynamicfiltersselector2, "EMPTDSC") == 0 ) && ( AV55Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_empresastransporteswwds_7_emptdsc2)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV56Configuracion_empresastransporteswwds_7_emptdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV57Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Configuracion_empresastransporteswwds_9_dynamicfiltersselector3, "EMPTDSC") == 0 ) && ( AV59Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_empresastransporteswwds_11_emptdsc3)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV60Configuracion_empresastransporteswwds_11_emptdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV57Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Configuracion_empresastransporteswwds_9_dynamicfiltersselector3, "EMPTDSC") == 0 ) && ( AV59Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_empresastransporteswwds_11_emptdsc3)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV60Configuracion_empresastransporteswwds_11_emptdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV61Configuracion_empresastransporteswwds_12_tfemptcod) )
         {
            AddWhere(sWhereString, "([EmpTCod] >= @AV61Configuracion_empresastransporteswwds_12_tfemptcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV62Configuracion_empresastransporteswwds_13_tfemptcod_to) )
         {
            AddWhere(sWhereString, "([EmpTCod] <= @AV62Configuracion_empresastransporteswwds_13_tfemptcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_empresastransporteswwds_15_tfemptdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_empresastransporteswwds_14_tfemptdsc)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV63Configuracion_empresastransporteswwds_14_tfemptdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_empresastransporteswwds_15_tfemptdsc_sel)) )
         {
            AddWhere(sWhereString, "([EmpTDsc] = @AV64Configuracion_empresastransporteswwds_15_tfemptdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_empresastransporteswwds_17_tfemptdir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_empresastransporteswwds_16_tfemptdir)) ) )
         {
            AddWhere(sWhereString, "([EmptDir] like @lV65Configuracion_empresastransporteswwds_16_tfemptdir)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_empresastransporteswwds_17_tfemptdir_sel)) )
         {
            AddWhere(sWhereString, "([EmptDir] = @AV66Configuracion_empresastransporteswwds_17_tfemptdir_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_empresastransporteswwds_19_tfemptruc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_empresastransporteswwds_18_tfemptruc)) ) )
         {
            AddWhere(sWhereString, "([EmpTRuc] like @lV67Configuracion_empresastransporteswwds_18_tfemptruc)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_empresastransporteswwds_19_tfemptruc_sel)) )
         {
            AddWhere(sWhereString, "([EmpTRuc] = @AV68Configuracion_empresastransporteswwds_19_tfemptruc_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV69Configuracion_empresastransporteswwds_20_tfemptsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV69Configuracion_empresastransporteswwds_20_tfemptsts_sels, "[EmpTSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [EmpTCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EmpTCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [EmpTDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EmpTDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [EmptDir]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EmptDir] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [EmpTRuc]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EmpTRuc] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [EmpTSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EmpTSts] DESC";
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
                     return conditional_P00352(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP00352;
          prmP00352 = new Object[] {
          new ParDef("@lV52Configuracion_empresastransporteswwds_3_emptdsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV52Configuracion_empresastransporteswwds_3_emptdsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV56Configuracion_empresastransporteswwds_7_emptdsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV56Configuracion_empresastransporteswwds_7_emptdsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV60Configuracion_empresastransporteswwds_11_emptdsc3",GXType.NVarChar,100,0) ,
          new ParDef("@lV60Configuracion_empresastransporteswwds_11_emptdsc3",GXType.NVarChar,100,0) ,
          new ParDef("@AV61Configuracion_empresastransporteswwds_12_tfemptcod",GXType.Int32,6,0) ,
          new ParDef("@AV62Configuracion_empresastransporteswwds_13_tfemptcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV63Configuracion_empresastransporteswwds_14_tfemptdsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV64Configuracion_empresastransporteswwds_15_tfemptdsc_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV65Configuracion_empresastransporteswwds_16_tfemptdir",GXType.NVarChar,100,0) ,
          new ParDef("@AV66Configuracion_empresastransporteswwds_17_tfemptdir_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV67Configuracion_empresastransporteswwds_18_tfemptruc",GXType.NVarChar,20,0) ,
          new ParDef("@AV68Configuracion_empresastransporteswwds_19_tfemptruc_sel",GXType.NVarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00352", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00352,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
