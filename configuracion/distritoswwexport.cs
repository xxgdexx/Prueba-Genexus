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
   public class distritoswwexport : GXProcedure
   {
      public distritoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public distritoswwexport( IGxContext context )
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
         distritoswwexport objdistritoswwexport;
         objdistritoswwexport = new distritoswwexport();
         objdistritoswwexport.AV11Filename = "" ;
         objdistritoswwexport.AV12ErrorMessage = "" ;
         objdistritoswwexport.context.SetSubmitInitialConfig(context);
         objdistritoswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdistritoswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((distritoswwexport)stateInfo).executePrivate();
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
         AV11Filename = "DistritosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "DISDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20DisDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20DisDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Distrito", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Distrito", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20DisDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "DISDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24DisDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24DisDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Distrito", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Distrito", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24DisDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "DISDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28DisDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28DisDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Distrito", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Distrito", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28DisDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFDisCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFDisCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFDisCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFDisCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFDisDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Distrito") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFDisDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFDisDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Distrito") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFDisDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFPaiDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Pais") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFPaiDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPaiDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Pais") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFPaiDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV47TFDisSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV49i = 1;
            AV52GXV1 = 1;
            while ( AV52GXV1 <= AV47TFDisSts_Sels.Count )
            {
               AV48TFDisSts_Sel = (short)(AV47TFDisSts_Sels.GetNumeric(AV52GXV1));
               if ( AV49i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV48TFDisSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV48TFDisSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV49i = (long)(AV49i+1);
               AV52GXV1 = (int)(AV52GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Distrito";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Pais";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV54Configuracion_distritoswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV55Configuracion_distritoswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV56Configuracion_distritoswwds_3_disdsc1 = AV20DisDsc1;
         AV57Configuracion_distritoswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV58Configuracion_distritoswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV59Configuracion_distritoswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV60Configuracion_distritoswwds_7_disdsc2 = AV24DisDsc2;
         AV61Configuracion_distritoswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV62Configuracion_distritoswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV63Configuracion_distritoswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV64Configuracion_distritoswwds_11_disdsc3 = AV28DisDsc3;
         AV65Configuracion_distritoswwds_12_tfdiscod = AV38TFDisCod;
         AV66Configuracion_distritoswwds_13_tfdiscod_sel = AV39TFDisCod_Sel;
         AV67Configuracion_distritoswwds_14_tfdisdsc = AV42TFDisDsc;
         AV68Configuracion_distritoswwds_15_tfdisdsc_sel = AV43TFDisDsc_Sel;
         AV69Configuracion_distritoswwds_16_tfpaidsc = AV40TFPaiDsc;
         AV70Configuracion_distritoswwds_17_tfpaidsc_sel = AV41TFPaiDsc_Sel;
         AV71Configuracion_distritoswwds_18_tfdissts_sels = AV47TFDisSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A878DisSts ,
                                              AV71Configuracion_distritoswwds_18_tfdissts_sels ,
                                              AV54Configuracion_distritoswwds_1_dynamicfiltersselector1 ,
                                              AV55Configuracion_distritoswwds_2_dynamicfiltersoperator1 ,
                                              AV56Configuracion_distritoswwds_3_disdsc1 ,
                                              AV57Configuracion_distritoswwds_4_dynamicfiltersenabled2 ,
                                              AV58Configuracion_distritoswwds_5_dynamicfiltersselector2 ,
                                              AV59Configuracion_distritoswwds_6_dynamicfiltersoperator2 ,
                                              AV60Configuracion_distritoswwds_7_disdsc2 ,
                                              AV61Configuracion_distritoswwds_8_dynamicfiltersenabled3 ,
                                              AV62Configuracion_distritoswwds_9_dynamicfiltersselector3 ,
                                              AV63Configuracion_distritoswwds_10_dynamicfiltersoperator3 ,
                                              AV64Configuracion_distritoswwds_11_disdsc3 ,
                                              AV66Configuracion_distritoswwds_13_tfdiscod_sel ,
                                              AV65Configuracion_distritoswwds_12_tfdiscod ,
                                              AV68Configuracion_distritoswwds_15_tfdisdsc_sel ,
                                              AV67Configuracion_distritoswwds_14_tfdisdsc ,
                                              AV70Configuracion_distritoswwds_17_tfpaidsc_sel ,
                                              AV69Configuracion_distritoswwds_16_tfpaidsc ,
                                              AV71Configuracion_distritoswwds_18_tfdissts_sels.Count ,
                                              A604DisDsc ,
                                              A142DisCod ,
                                              A1500PaiDsc ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV56Configuracion_distritoswwds_3_disdsc1 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_distritoswwds_3_disdsc1), 100, "%");
         lV56Configuracion_distritoswwds_3_disdsc1 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_distritoswwds_3_disdsc1), 100, "%");
         lV60Configuracion_distritoswwds_7_disdsc2 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_distritoswwds_7_disdsc2), 100, "%");
         lV60Configuracion_distritoswwds_7_disdsc2 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_distritoswwds_7_disdsc2), 100, "%");
         lV64Configuracion_distritoswwds_11_disdsc3 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_distritoswwds_11_disdsc3), 100, "%");
         lV64Configuracion_distritoswwds_11_disdsc3 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_distritoswwds_11_disdsc3), 100, "%");
         lV65Configuracion_distritoswwds_12_tfdiscod = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_distritoswwds_12_tfdiscod), 4, "%");
         lV67Configuracion_distritoswwds_14_tfdisdsc = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_distritoswwds_14_tfdisdsc), 100, "%");
         lV69Configuracion_distritoswwds_16_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_distritoswwds_16_tfpaidsc), 100, "%");
         /* Using cursor P003X2 */
         pr_default.execute(0, new Object[] {lV56Configuracion_distritoswwds_3_disdsc1, lV56Configuracion_distritoswwds_3_disdsc1, lV60Configuracion_distritoswwds_7_disdsc2, lV60Configuracion_distritoswwds_7_disdsc2, lV64Configuracion_distritoswwds_11_disdsc3, lV64Configuracion_distritoswwds_11_disdsc3, lV65Configuracion_distritoswwds_12_tfdiscod, AV66Configuracion_distritoswwds_13_tfdiscod_sel, lV67Configuracion_distritoswwds_14_tfdisdsc, AV68Configuracion_distritoswwds_15_tfdisdsc_sel, lV69Configuracion_distritoswwds_16_tfpaidsc, AV70Configuracion_distritoswwds_17_tfpaidsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A878DisSts = P003X2_A878DisSts[0];
            A1500PaiDsc = P003X2_A1500PaiDsc[0];
            A142DisCod = P003X2_A142DisCod[0];
            A604DisDsc = P003X2_A604DisDsc[0];
            A139PaiCod = P003X2_A139PaiCod[0];
            A140EstCod = P003X2_A140EstCod[0];
            A141ProvCod = P003X2_A141ProvCod[0];
            A1500PaiDsc = P003X2_A1500PaiDsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A142DisCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A604DisDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1500PaiDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A878DisSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "ACTIVO";
            }
            else if ( A878DisSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.DistritosWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.DistritosWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.DistritosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV72GXV2 = 1;
         while ( AV72GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV72GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDISCOD") == 0 )
            {
               AV38TFDisCod = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDISCOD_SEL") == 0 )
            {
               AV39TFDisCod_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDISDSC") == 0 )
            {
               AV42TFDisDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDISDSC_SEL") == 0 )
            {
               AV43TFDisDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAIDSC") == 0 )
            {
               AV40TFPaiDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAIDSC_SEL") == 0 )
            {
               AV41TFPaiDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDISSTS_SEL") == 0 )
            {
               AV46TFDisSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV47TFDisSts_Sels.FromJSonString(AV46TFDisSts_SelsJson, null);
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
         AV20DisDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24DisDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28DisDsc3 = "";
         AV39TFDisCod_Sel = "";
         AV38TFDisCod = "";
         AV43TFDisDsc_Sel = "";
         AV42TFDisDsc = "";
         AV41TFPaiDsc_Sel = "";
         AV40TFPaiDsc = "";
         AV47TFDisSts_Sels = new GxSimpleCollection<short>();
         AV54Configuracion_distritoswwds_1_dynamicfiltersselector1 = "";
         AV56Configuracion_distritoswwds_3_disdsc1 = "";
         AV58Configuracion_distritoswwds_5_dynamicfiltersselector2 = "";
         AV60Configuracion_distritoswwds_7_disdsc2 = "";
         AV62Configuracion_distritoswwds_9_dynamicfiltersselector3 = "";
         AV64Configuracion_distritoswwds_11_disdsc3 = "";
         AV65Configuracion_distritoswwds_12_tfdiscod = "";
         AV66Configuracion_distritoswwds_13_tfdiscod_sel = "";
         AV67Configuracion_distritoswwds_14_tfdisdsc = "";
         AV68Configuracion_distritoswwds_15_tfdisdsc_sel = "";
         AV69Configuracion_distritoswwds_16_tfpaidsc = "";
         AV70Configuracion_distritoswwds_17_tfpaidsc_sel = "";
         AV71Configuracion_distritoswwds_18_tfdissts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV56Configuracion_distritoswwds_3_disdsc1 = "";
         lV60Configuracion_distritoswwds_7_disdsc2 = "";
         lV64Configuracion_distritoswwds_11_disdsc3 = "";
         lV65Configuracion_distritoswwds_12_tfdiscod = "";
         lV67Configuracion_distritoswwds_14_tfdisdsc = "";
         lV69Configuracion_distritoswwds_16_tfpaidsc = "";
         A604DisDsc = "";
         A142DisCod = "";
         A1500PaiDsc = "";
         P003X2_A878DisSts = new short[1] ;
         P003X2_A1500PaiDsc = new string[] {""} ;
         P003X2_A142DisCod = new string[] {""} ;
         P003X2_A604DisDsc = new string[] {""} ;
         P003X2_A139PaiCod = new string[] {""} ;
         P003X2_A140EstCod = new string[] {""} ;
         P003X2_A141ProvCod = new string[] {""} ;
         A139PaiCod = "";
         A140EstCod = "";
         A141ProvCod = "";
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46TFDisSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.distritoswwexport__default(),
            new Object[][] {
                new Object[] {
               P003X2_A878DisSts, P003X2_A1500PaiDsc, P003X2_A142DisCod, P003X2_A604DisDsc, P003X2_A139PaiCod, P003X2_A140EstCod, P003X2_A141ProvCod
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
      private short AV48TFDisSts_Sel ;
      private short AV55Configuracion_distritoswwds_2_dynamicfiltersoperator1 ;
      private short AV59Configuracion_distritoswwds_6_dynamicfiltersoperator2 ;
      private short AV63Configuracion_distritoswwds_10_dynamicfiltersoperator3 ;
      private short A878DisSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV52GXV1 ;
      private int AV71Configuracion_distritoswwds_18_tfdissts_sels_Count ;
      private int AV72GXV2 ;
      private long AV49i ;
      private string AV20DisDsc1 ;
      private string AV24DisDsc2 ;
      private string AV28DisDsc3 ;
      private string AV39TFDisCod_Sel ;
      private string AV38TFDisCod ;
      private string AV43TFDisDsc_Sel ;
      private string AV42TFDisDsc ;
      private string AV41TFPaiDsc_Sel ;
      private string AV40TFPaiDsc ;
      private string AV56Configuracion_distritoswwds_3_disdsc1 ;
      private string AV60Configuracion_distritoswwds_7_disdsc2 ;
      private string AV64Configuracion_distritoswwds_11_disdsc3 ;
      private string AV65Configuracion_distritoswwds_12_tfdiscod ;
      private string AV66Configuracion_distritoswwds_13_tfdiscod_sel ;
      private string AV67Configuracion_distritoswwds_14_tfdisdsc ;
      private string AV68Configuracion_distritoswwds_15_tfdisdsc_sel ;
      private string AV69Configuracion_distritoswwds_16_tfpaidsc ;
      private string AV70Configuracion_distritoswwds_17_tfpaidsc_sel ;
      private string scmdbuf ;
      private string lV56Configuracion_distritoswwds_3_disdsc1 ;
      private string lV60Configuracion_distritoswwds_7_disdsc2 ;
      private string lV64Configuracion_distritoswwds_11_disdsc3 ;
      private string lV65Configuracion_distritoswwds_12_tfdiscod ;
      private string lV67Configuracion_distritoswwds_14_tfdisdsc ;
      private string lV69Configuracion_distritoswwds_16_tfpaidsc ;
      private string A604DisDsc ;
      private string A142DisCod ;
      private string A1500PaiDsc ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A141ProvCod ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV57Configuracion_distritoswwds_4_dynamicfiltersenabled2 ;
      private bool AV61Configuracion_distritoswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV46TFDisSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV54Configuracion_distritoswwds_1_dynamicfiltersselector1 ;
      private string AV58Configuracion_distritoswwds_5_dynamicfiltersselector2 ;
      private string AV62Configuracion_distritoswwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV47TFDisSts_Sels ;
      private GxSimpleCollection<short> AV71Configuracion_distritoswwds_18_tfdissts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003X2_A878DisSts ;
      private string[] P003X2_A1500PaiDsc ;
      private string[] P003X2_A142DisCod ;
      private string[] P003X2_A604DisDsc ;
      private string[] P003X2_A139PaiCod ;
      private string[] P003X2_A140EstCod ;
      private string[] P003X2_A141ProvCod ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class distritoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003X2( IGxContext context ,
                                             short A878DisSts ,
                                             GxSimpleCollection<short> AV71Configuracion_distritoswwds_18_tfdissts_sels ,
                                             string AV54Configuracion_distritoswwds_1_dynamicfiltersselector1 ,
                                             short AV55Configuracion_distritoswwds_2_dynamicfiltersoperator1 ,
                                             string AV56Configuracion_distritoswwds_3_disdsc1 ,
                                             bool AV57Configuracion_distritoswwds_4_dynamicfiltersenabled2 ,
                                             string AV58Configuracion_distritoswwds_5_dynamicfiltersselector2 ,
                                             short AV59Configuracion_distritoswwds_6_dynamicfiltersoperator2 ,
                                             string AV60Configuracion_distritoswwds_7_disdsc2 ,
                                             bool AV61Configuracion_distritoswwds_8_dynamicfiltersenabled3 ,
                                             string AV62Configuracion_distritoswwds_9_dynamicfiltersselector3 ,
                                             short AV63Configuracion_distritoswwds_10_dynamicfiltersoperator3 ,
                                             string AV64Configuracion_distritoswwds_11_disdsc3 ,
                                             string AV66Configuracion_distritoswwds_13_tfdiscod_sel ,
                                             string AV65Configuracion_distritoswwds_12_tfdiscod ,
                                             string AV68Configuracion_distritoswwds_15_tfdisdsc_sel ,
                                             string AV67Configuracion_distritoswwds_14_tfdisdsc ,
                                             string AV70Configuracion_distritoswwds_17_tfpaidsc_sel ,
                                             string AV69Configuracion_distritoswwds_16_tfpaidsc ,
                                             int AV71Configuracion_distritoswwds_18_tfdissts_sels_Count ,
                                             string A604DisDsc ,
                                             string A142DisCod ,
                                             string A1500PaiDsc ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[DisSts], T2.[PaiDsc], T1.[DisCod], T1.[DisDsc], T1.[PaiCod], T1.[EstCod], T1.[ProvCod] FROM ([CDISTRITOS] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV54Configuracion_distritoswwds_1_dynamicfiltersselector1, "DISDSC") == 0 ) && ( AV55Configuracion_distritoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_distritoswwds_3_disdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV56Configuracion_distritoswwds_3_disdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Configuracion_distritoswwds_1_dynamicfiltersselector1, "DISDSC") == 0 ) && ( AV55Configuracion_distritoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_distritoswwds_3_disdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV56Configuracion_distritoswwds_3_disdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV57Configuracion_distritoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Configuracion_distritoswwds_5_dynamicfiltersselector2, "DISDSC") == 0 ) && ( AV59Configuracion_distritoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_distritoswwds_7_disdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV60Configuracion_distritoswwds_7_disdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV57Configuracion_distritoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Configuracion_distritoswwds_5_dynamicfiltersselector2, "DISDSC") == 0 ) && ( AV59Configuracion_distritoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_distritoswwds_7_disdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV60Configuracion_distritoswwds_7_disdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV61Configuracion_distritoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Configuracion_distritoswwds_9_dynamicfiltersselector3, "DISDSC") == 0 ) && ( AV63Configuracion_distritoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_distritoswwds_11_disdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV64Configuracion_distritoswwds_11_disdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV61Configuracion_distritoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Configuracion_distritoswwds_9_dynamicfiltersselector3, "DISDSC") == 0 ) && ( AV63Configuracion_distritoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_distritoswwds_11_disdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV64Configuracion_distritoswwds_11_disdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_distritoswwds_13_tfdiscod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_distritoswwds_12_tfdiscod)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisCod] like @lV65Configuracion_distritoswwds_12_tfdiscod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_distritoswwds_13_tfdiscod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[DisCod] = @AV66Configuracion_distritoswwds_13_tfdiscod_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_distritoswwds_15_tfdisdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_distritoswwds_14_tfdisdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV67Configuracion_distritoswwds_14_tfdisdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_distritoswwds_15_tfdisdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] = @AV68Configuracion_distritoswwds_15_tfdisdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_distritoswwds_17_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_distritoswwds_16_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV69Configuracion_distritoswwds_16_tfpaidsc)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_distritoswwds_17_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV70Configuracion_distritoswwds_17_tfpaidsc_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV71Configuracion_distritoswwds_18_tfdissts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71Configuracion_distritoswwds_18_tfdissts_sels, "T1.[DisSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[PaiCod], T1.[DisCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DisCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DisCod] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DisDsc]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DisDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[PaiDsc]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[PaiDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[DisSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[DisSts] DESC";
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
                     return conditional_P003X2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP003X2;
          prmP003X2 = new Object[] {
          new ParDef("@lV56Configuracion_distritoswwds_3_disdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV56Configuracion_distritoswwds_3_disdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Configuracion_distritoswwds_7_disdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV60Configuracion_distritoswwds_7_disdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV64Configuracion_distritoswwds_11_disdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV64Configuracion_distritoswwds_11_disdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_distritoswwds_12_tfdiscod",GXType.NChar,4,0) ,
          new ParDef("@AV66Configuracion_distritoswwds_13_tfdiscod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV67Configuracion_distritoswwds_14_tfdisdsc",GXType.NChar,100,0) ,
          new ParDef("@AV68Configuracion_distritoswwds_15_tfdisdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_distritoswwds_16_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV70Configuracion_distritoswwds_17_tfpaidsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003X2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 4);
                ((string[]) buf[5])[0] = rslt.getString(6, 4);
                ((string[]) buf[6])[0] = rslt.getString(7, 4);
                return;
       }
    }

 }

}
