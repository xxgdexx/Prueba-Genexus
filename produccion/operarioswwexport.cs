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
   public class operarioswwexport : GXProcedure
   {
      public operarioswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public operarioswwexport( IGxContext context )
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
         operarioswwexport objoperarioswwexport;
         objoperarioswwexport = new operarioswwexport();
         objoperarioswwexport.AV11Filename = "" ;
         objoperarioswwexport.AV12ErrorMessage = "" ;
         objoperarioswwexport.context.SetSubmitInitialConfig(context);
         objoperarioswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objoperarioswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((operarioswwexport)stateInfo).executePrivate();
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
         AV11Filename = "OperariosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "OPEDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20OPEDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20OPEDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Operario", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Operario", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20OPEDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "OPEDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24OPEDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24OPEDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Operario", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Operario", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24OPEDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "OPEDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28OPEDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28OPEDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Operario", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Operario", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28OPEDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFOPECod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Operario") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFOPECod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFOPECod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Operario") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34TFOPECod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFOPEDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Operario") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFOPEDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFOPEDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Operario") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFOPEDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV39TFOPESts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV41i = 1;
            AV44GXV1 = 1;
            while ( AV44GXV1 <= AV39TFOPESts_Sels.Count )
            {
               AV40TFOPESts_Sel = (short)(AV39TFOPESts_Sels.GetNumeric(AV44GXV1));
               if ( AV41i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV40TFOPESts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV40TFOPESts_Sel == 0 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Codigo Operario";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Operario";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV46Produccion_operarioswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV47Produccion_operarioswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV48Produccion_operarioswwds_3_opedsc1 = AV20OPEDsc1;
         AV49Produccion_operarioswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV50Produccion_operarioswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV51Produccion_operarioswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV52Produccion_operarioswwds_7_opedsc2 = AV24OPEDsc2;
         AV53Produccion_operarioswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV54Produccion_operarioswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV55Produccion_operarioswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV56Produccion_operarioswwds_11_opedsc3 = AV28OPEDsc3;
         AV57Produccion_operarioswwds_12_tfopecod = AV34TFOPECod;
         AV58Produccion_operarioswwds_13_tfopecod_sel = AV35TFOPECod_Sel;
         AV59Produccion_operarioswwds_14_tfopedsc = AV36TFOPEDsc;
         AV60Produccion_operarioswwds_15_tfopedsc_sel = AV37TFOPEDsc_Sel;
         AV61Produccion_operarioswwds_16_tfopests_sels = AV39TFOPESts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1423OPESts ,
                                              AV61Produccion_operarioswwds_16_tfopests_sels ,
                                              AV46Produccion_operarioswwds_1_dynamicfiltersselector1 ,
                                              AV47Produccion_operarioswwds_2_dynamicfiltersoperator1 ,
                                              AV48Produccion_operarioswwds_3_opedsc1 ,
                                              AV49Produccion_operarioswwds_4_dynamicfiltersenabled2 ,
                                              AV50Produccion_operarioswwds_5_dynamicfiltersselector2 ,
                                              AV51Produccion_operarioswwds_6_dynamicfiltersoperator2 ,
                                              AV52Produccion_operarioswwds_7_opedsc2 ,
                                              AV53Produccion_operarioswwds_8_dynamicfiltersenabled3 ,
                                              AV54Produccion_operarioswwds_9_dynamicfiltersselector3 ,
                                              AV55Produccion_operarioswwds_10_dynamicfiltersoperator3 ,
                                              AV56Produccion_operarioswwds_11_opedsc3 ,
                                              AV58Produccion_operarioswwds_13_tfopecod_sel ,
                                              AV57Produccion_operarioswwds_12_tfopecod ,
                                              AV60Produccion_operarioswwds_15_tfopedsc_sel ,
                                              AV59Produccion_operarioswwds_14_tfopedsc ,
                                              AV61Produccion_operarioswwds_16_tfopests_sels.Count ,
                                              A1422OPEDsc ,
                                              A321OPECod ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Produccion_operarioswwds_3_opedsc1 = StringUtil.PadR( StringUtil.RTrim( AV48Produccion_operarioswwds_3_opedsc1), 100, "%");
         lV48Produccion_operarioswwds_3_opedsc1 = StringUtil.PadR( StringUtil.RTrim( AV48Produccion_operarioswwds_3_opedsc1), 100, "%");
         lV52Produccion_operarioswwds_7_opedsc2 = StringUtil.PadR( StringUtil.RTrim( AV52Produccion_operarioswwds_7_opedsc2), 100, "%");
         lV52Produccion_operarioswwds_7_opedsc2 = StringUtil.PadR( StringUtil.RTrim( AV52Produccion_operarioswwds_7_opedsc2), 100, "%");
         lV56Produccion_operarioswwds_11_opedsc3 = StringUtil.PadR( StringUtil.RTrim( AV56Produccion_operarioswwds_11_opedsc3), 100, "%");
         lV56Produccion_operarioswwds_11_opedsc3 = StringUtil.PadR( StringUtil.RTrim( AV56Produccion_operarioswwds_11_opedsc3), 100, "%");
         lV57Produccion_operarioswwds_12_tfopecod = StringUtil.PadR( StringUtil.RTrim( AV57Produccion_operarioswwds_12_tfopecod), 20, "%");
         lV59Produccion_operarioswwds_14_tfopedsc = StringUtil.PadR( StringUtil.RTrim( AV59Produccion_operarioswwds_14_tfopedsc), 100, "%");
         /* Using cursor P00662 */
         pr_default.execute(0, new Object[] {lV48Produccion_operarioswwds_3_opedsc1, lV48Produccion_operarioswwds_3_opedsc1, lV52Produccion_operarioswwds_7_opedsc2, lV52Produccion_operarioswwds_7_opedsc2, lV56Produccion_operarioswwds_11_opedsc3, lV56Produccion_operarioswwds_11_opedsc3, lV57Produccion_operarioswwds_12_tfopecod, AV58Produccion_operarioswwds_13_tfopecod_sel, lV59Produccion_operarioswwds_14_tfopedsc, AV60Produccion_operarioswwds_15_tfopedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1423OPESts = P00662_A1423OPESts[0];
            A321OPECod = P00662_A321OPECod[0];
            A1422OPEDsc = P00662_A1422OPEDsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A321OPECod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1422OPEDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( A1423OPESts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "ACTIVO";
            }
            else if ( A1423OPESts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Produccion.OperariosWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Produccion.OperariosWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Produccion.OperariosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV62GXV2 = 1;
         while ( AV62GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV62GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFOPECOD") == 0 )
            {
               AV34TFOPECod = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFOPECOD_SEL") == 0 )
            {
               AV35TFOPECod_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFOPEDSC") == 0 )
            {
               AV36TFOPEDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFOPEDSC_SEL") == 0 )
            {
               AV37TFOPEDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFOPESTS_SEL") == 0 )
            {
               AV38TFOPESts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV39TFOPESts_Sels.FromJSonString(AV38TFOPESts_SelsJson, null);
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
         AV20OPEDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24OPEDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28OPEDsc3 = "";
         AV35TFOPECod_Sel = "";
         AV34TFOPECod = "";
         AV37TFOPEDsc_Sel = "";
         AV36TFOPEDsc = "";
         AV39TFOPESts_Sels = new GxSimpleCollection<short>();
         AV46Produccion_operarioswwds_1_dynamicfiltersselector1 = "";
         AV48Produccion_operarioswwds_3_opedsc1 = "";
         AV50Produccion_operarioswwds_5_dynamicfiltersselector2 = "";
         AV52Produccion_operarioswwds_7_opedsc2 = "";
         AV54Produccion_operarioswwds_9_dynamicfiltersselector3 = "";
         AV56Produccion_operarioswwds_11_opedsc3 = "";
         AV57Produccion_operarioswwds_12_tfopecod = "";
         AV58Produccion_operarioswwds_13_tfopecod_sel = "";
         AV59Produccion_operarioswwds_14_tfopedsc = "";
         AV60Produccion_operarioswwds_15_tfopedsc_sel = "";
         AV61Produccion_operarioswwds_16_tfopests_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV48Produccion_operarioswwds_3_opedsc1 = "";
         lV52Produccion_operarioswwds_7_opedsc2 = "";
         lV56Produccion_operarioswwds_11_opedsc3 = "";
         lV57Produccion_operarioswwds_12_tfopecod = "";
         lV59Produccion_operarioswwds_14_tfopedsc = "";
         A1422OPEDsc = "";
         A321OPECod = "";
         P00662_A1423OPESts = new short[1] ;
         P00662_A321OPECod = new string[] {""} ;
         P00662_A1422OPEDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38TFOPESts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.operarioswwexport__default(),
            new Object[][] {
                new Object[] {
               P00662_A1423OPESts, P00662_A321OPECod, P00662_A1422OPEDsc
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
      private short AV40TFOPESts_Sel ;
      private short AV47Produccion_operarioswwds_2_dynamicfiltersoperator1 ;
      private short AV51Produccion_operarioswwds_6_dynamicfiltersoperator2 ;
      private short AV55Produccion_operarioswwds_10_dynamicfiltersoperator3 ;
      private short A1423OPESts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV44GXV1 ;
      private int AV61Produccion_operarioswwds_16_tfopests_sels_Count ;
      private int AV62GXV2 ;
      private long AV41i ;
      private string AV20OPEDsc1 ;
      private string AV24OPEDsc2 ;
      private string AV28OPEDsc3 ;
      private string AV35TFOPECod_Sel ;
      private string AV34TFOPECod ;
      private string AV37TFOPEDsc_Sel ;
      private string AV36TFOPEDsc ;
      private string AV48Produccion_operarioswwds_3_opedsc1 ;
      private string AV52Produccion_operarioswwds_7_opedsc2 ;
      private string AV56Produccion_operarioswwds_11_opedsc3 ;
      private string AV57Produccion_operarioswwds_12_tfopecod ;
      private string AV58Produccion_operarioswwds_13_tfopecod_sel ;
      private string AV59Produccion_operarioswwds_14_tfopedsc ;
      private string AV60Produccion_operarioswwds_15_tfopedsc_sel ;
      private string scmdbuf ;
      private string lV48Produccion_operarioswwds_3_opedsc1 ;
      private string lV52Produccion_operarioswwds_7_opedsc2 ;
      private string lV56Produccion_operarioswwds_11_opedsc3 ;
      private string lV57Produccion_operarioswwds_12_tfopecod ;
      private string lV59Produccion_operarioswwds_14_tfopedsc ;
      private string A1422OPEDsc ;
      private string A321OPECod ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV49Produccion_operarioswwds_4_dynamicfiltersenabled2 ;
      private bool AV53Produccion_operarioswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV38TFOPESts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV46Produccion_operarioswwds_1_dynamicfiltersselector1 ;
      private string AV50Produccion_operarioswwds_5_dynamicfiltersselector2 ;
      private string AV54Produccion_operarioswwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV39TFOPESts_Sels ;
      private GxSimpleCollection<short> AV61Produccion_operarioswwds_16_tfopests_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00662_A1423OPESts ;
      private string[] P00662_A321OPECod ;
      private string[] P00662_A1422OPEDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class operarioswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00662( IGxContext context ,
                                             short A1423OPESts ,
                                             GxSimpleCollection<short> AV61Produccion_operarioswwds_16_tfopests_sels ,
                                             string AV46Produccion_operarioswwds_1_dynamicfiltersselector1 ,
                                             short AV47Produccion_operarioswwds_2_dynamicfiltersoperator1 ,
                                             string AV48Produccion_operarioswwds_3_opedsc1 ,
                                             bool AV49Produccion_operarioswwds_4_dynamicfiltersenabled2 ,
                                             string AV50Produccion_operarioswwds_5_dynamicfiltersselector2 ,
                                             short AV51Produccion_operarioswwds_6_dynamicfiltersoperator2 ,
                                             string AV52Produccion_operarioswwds_7_opedsc2 ,
                                             bool AV53Produccion_operarioswwds_8_dynamicfiltersenabled3 ,
                                             string AV54Produccion_operarioswwds_9_dynamicfiltersselector3 ,
                                             short AV55Produccion_operarioswwds_10_dynamicfiltersoperator3 ,
                                             string AV56Produccion_operarioswwds_11_opedsc3 ,
                                             string AV58Produccion_operarioswwds_13_tfopecod_sel ,
                                             string AV57Produccion_operarioswwds_12_tfopecod ,
                                             string AV60Produccion_operarioswwds_15_tfopedsc_sel ,
                                             string AV59Produccion_operarioswwds_14_tfopedsc ,
                                             int AV61Produccion_operarioswwds_16_tfopests_sels_Count ,
                                             string A1422OPEDsc ,
                                             string A321OPECod ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [OPESts], [OPECod], [OPEDsc] FROM [POOPERARIOS]";
         if ( ( StringUtil.StrCmp(AV46Produccion_operarioswwds_1_dynamicfiltersselector1, "OPEDSC") == 0 ) && ( AV47Produccion_operarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Produccion_operarioswwds_3_opedsc1)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV48Produccion_operarioswwds_3_opedsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV46Produccion_operarioswwds_1_dynamicfiltersselector1, "OPEDSC") == 0 ) && ( AV47Produccion_operarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Produccion_operarioswwds_3_opedsc1)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like '%' + @lV48Produccion_operarioswwds_3_opedsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV49Produccion_operarioswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV50Produccion_operarioswwds_5_dynamicfiltersselector2, "OPEDSC") == 0 ) && ( AV51Produccion_operarioswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Produccion_operarioswwds_7_opedsc2)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV52Produccion_operarioswwds_7_opedsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV49Produccion_operarioswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV50Produccion_operarioswwds_5_dynamicfiltersselector2, "OPEDSC") == 0 ) && ( AV51Produccion_operarioswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Produccion_operarioswwds_7_opedsc2)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like '%' + @lV52Produccion_operarioswwds_7_opedsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV53Produccion_operarioswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV54Produccion_operarioswwds_9_dynamicfiltersselector3, "OPEDSC") == 0 ) && ( AV55Produccion_operarioswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Produccion_operarioswwds_11_opedsc3)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV56Produccion_operarioswwds_11_opedsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV53Produccion_operarioswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV54Produccion_operarioswwds_9_dynamicfiltersselector3, "OPEDSC") == 0 ) && ( AV55Produccion_operarioswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Produccion_operarioswwds_11_opedsc3)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like '%' + @lV56Produccion_operarioswwds_11_opedsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Produccion_operarioswwds_13_tfopecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Produccion_operarioswwds_12_tfopecod)) ) )
         {
            AddWhere(sWhereString, "([OPECod] like @lV57Produccion_operarioswwds_12_tfopecod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Produccion_operarioswwds_13_tfopecod_sel)) )
         {
            AddWhere(sWhereString, "([OPECod] = @AV58Produccion_operarioswwds_13_tfopecod_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Produccion_operarioswwds_15_tfopedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Produccion_operarioswwds_14_tfopedsc)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV59Produccion_operarioswwds_14_tfopedsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Produccion_operarioswwds_15_tfopedsc_sel)) )
         {
            AddWhere(sWhereString, "([OPEDsc] = @AV60Produccion_operarioswwds_15_tfopedsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV61Produccion_operarioswwds_16_tfopests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV61Produccion_operarioswwds_16_tfopests_sels, "[OPESts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [OPECod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OPECod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [OPEDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OPEDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [OPESts]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OPESts] DESC";
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
                     return conditional_P00662(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP00662;
          prmP00662 = new Object[] {
          new ParDef("@lV48Produccion_operarioswwds_3_opedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV48Produccion_operarioswwds_3_opedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV52Produccion_operarioswwds_7_opedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV52Produccion_operarioswwds_7_opedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV56Produccion_operarioswwds_11_opedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV56Produccion_operarioswwds_11_opedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV57Produccion_operarioswwds_12_tfopecod",GXType.NChar,20,0) ,
          new ParDef("@AV58Produccion_operarioswwds_13_tfopecod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV59Produccion_operarioswwds_14_tfopedsc",GXType.NChar,100,0) ,
          new ParDef("@AV60Produccion_operarioswwds_15_tfopedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00662", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00662,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
