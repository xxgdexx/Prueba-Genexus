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
   public class tipoauxiliarwwexport : GXProcedure
   {
      public tipoauxiliarwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipoauxiliarwwexport( IGxContext context )
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
         tipoauxiliarwwexport objtipoauxiliarwwexport;
         objtipoauxiliarwwexport = new tipoauxiliarwwexport();
         objtipoauxiliarwwexport.AV11Filename = "" ;
         objtipoauxiliarwwexport.AV12ErrorMessage = "" ;
         objtipoauxiliarwwexport.context.SetSubmitInitialConfig(context);
         objtipoauxiliarwwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipoauxiliarwwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipoauxiliarwwexport)stateInfo).executePrivate();
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
         AV11Filename = "TipoAuxiliarWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIPADSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20TipADsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TipADsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Auxiliar", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20TipADsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TIPADSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24TipADsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TipADsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Auxiliar", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24TipADsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIPADSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28TipADsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TipADsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Auxiliar", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28TipADsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFTipACod) && (0==AV35TFTipACod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFTipACod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFTipACod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTipADsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Auxiliar") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFTipADsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTipADsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Auxiliar") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFTipADsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV39TFTipASts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV41i = 1;
            AV46GXV1 = 1;
            while ( AV46GXV1 <= AV39TFTipASts_Sels.Count )
            {
               AV40TFTipASts_Sel = (short)(AV39TFTipASts_Sels.GetNumeric(AV46GXV1));
               if ( AV41i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV40TFTipASts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Activo";
               }
               else if ( AV40TFTipASts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Inactivo";
               }
               AV41i = (long)(AV41i+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Tipo de Auxiliar";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV48Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV49Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV50Contabilidad_tipoauxiliarwwds_3_tipadsc1 = AV20TipADsc1;
         AV51Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV52Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV53Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV54Contabilidad_tipoauxiliarwwds_7_tipadsc2 = AV24TipADsc2;
         AV55Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV56Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV57Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV58Contabilidad_tipoauxiliarwwds_11_tipadsc3 = AV28TipADsc3;
         AV59Contabilidad_tipoauxiliarwwds_12_tftipacod = AV34TFTipACod;
         AV60Contabilidad_tipoauxiliarwwds_13_tftipacod_to = AV35TFTipACod_To;
         AV61Contabilidad_tipoauxiliarwwds_14_tftipadsc = AV36TFTipADsc;
         AV62Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel = AV37TFTipADsc_Sel;
         AV63Contabilidad_tipoauxiliarwwds_16_tftipasts_sels = AV39TFTipASts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1902TipASts ,
                                              AV63Contabilidad_tipoauxiliarwwds_16_tftipasts_sels ,
                                              AV48Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 ,
                                              AV49Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 ,
                                              AV50Contabilidad_tipoauxiliarwwds_3_tipadsc1 ,
                                              AV51Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 ,
                                              AV52Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 ,
                                              AV53Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 ,
                                              AV54Contabilidad_tipoauxiliarwwds_7_tipadsc2 ,
                                              AV55Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 ,
                                              AV56Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 ,
                                              AV57Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 ,
                                              AV58Contabilidad_tipoauxiliarwwds_11_tipadsc3 ,
                                              AV59Contabilidad_tipoauxiliarwwds_12_tftipacod ,
                                              AV60Contabilidad_tipoauxiliarwwds_13_tftipacod_to ,
                                              AV62Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel ,
                                              AV61Contabilidad_tipoauxiliarwwds_14_tftipadsc ,
                                              AV63Contabilidad_tipoauxiliarwwds_16_tftipasts_sels.Count ,
                                              A1900TipADsc ,
                                              A70TipACod ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV50Contabilidad_tipoauxiliarwwds_3_tipadsc1 = StringUtil.PadR( StringUtil.RTrim( AV50Contabilidad_tipoauxiliarwwds_3_tipadsc1), 100, "%");
         lV50Contabilidad_tipoauxiliarwwds_3_tipadsc1 = StringUtil.PadR( StringUtil.RTrim( AV50Contabilidad_tipoauxiliarwwds_3_tipadsc1), 100, "%");
         lV54Contabilidad_tipoauxiliarwwds_7_tipadsc2 = StringUtil.PadR( StringUtil.RTrim( AV54Contabilidad_tipoauxiliarwwds_7_tipadsc2), 100, "%");
         lV54Contabilidad_tipoauxiliarwwds_7_tipadsc2 = StringUtil.PadR( StringUtil.RTrim( AV54Contabilidad_tipoauxiliarwwds_7_tipadsc2), 100, "%");
         lV58Contabilidad_tipoauxiliarwwds_11_tipadsc3 = StringUtil.PadR( StringUtil.RTrim( AV58Contabilidad_tipoauxiliarwwds_11_tipadsc3), 100, "%");
         lV58Contabilidad_tipoauxiliarwwds_11_tipadsc3 = StringUtil.PadR( StringUtil.RTrim( AV58Contabilidad_tipoauxiliarwwds_11_tipadsc3), 100, "%");
         lV61Contabilidad_tipoauxiliarwwds_14_tftipadsc = StringUtil.PadR( StringUtil.RTrim( AV61Contabilidad_tipoauxiliarwwds_14_tftipadsc), 100, "%");
         /* Using cursor P006L2 */
         pr_default.execute(0, new Object[] {lV50Contabilidad_tipoauxiliarwwds_3_tipadsc1, lV50Contabilidad_tipoauxiliarwwds_3_tipadsc1, lV54Contabilidad_tipoauxiliarwwds_7_tipadsc2, lV54Contabilidad_tipoauxiliarwwds_7_tipadsc2, lV58Contabilidad_tipoauxiliarwwds_11_tipadsc3, lV58Contabilidad_tipoauxiliarwwds_11_tipadsc3, AV59Contabilidad_tipoauxiliarwwds_12_tftipacod, AV60Contabilidad_tipoauxiliarwwds_13_tftipacod_to, lV61Contabilidad_tipoauxiliarwwds_14_tftipadsc, AV62Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1902TipASts = P006L2_A1902TipASts[0];
            A70TipACod = P006L2_A70TipACod[0];
            A1900TipADsc = P006L2_A1900TipADsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A70TipACod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1900TipADsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( A1902TipASts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Activo";
            }
            else if ( A1902TipASts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Inactivo";
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
         if ( StringUtil.StrCmp(AV30Session.Get("Contabilidad.TipoAuxiliarWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.TipoAuxiliarWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Contabilidad.TipoAuxiliarWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV64GXV2 = 1;
         while ( AV64GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV64GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPACOD") == 0 )
            {
               AV34TFTipACod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFTipACod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPADSC") == 0 )
            {
               AV36TFTipADsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPADSC_SEL") == 0 )
            {
               AV37TFTipADsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPASTS_SEL") == 0 )
            {
               AV38TFTipASts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV39TFTipASts_Sels.FromJSonString(AV38TFTipASts_SelsJson, null);
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
         AV20TipADsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24TipADsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28TipADsc3 = "";
         AV37TFTipADsc_Sel = "";
         AV36TFTipADsc = "";
         AV39TFTipASts_Sels = new GxSimpleCollection<short>();
         AV48Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 = "";
         AV50Contabilidad_tipoauxiliarwwds_3_tipadsc1 = "";
         AV52Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 = "";
         AV54Contabilidad_tipoauxiliarwwds_7_tipadsc2 = "";
         AV56Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 = "";
         AV58Contabilidad_tipoauxiliarwwds_11_tipadsc3 = "";
         AV61Contabilidad_tipoauxiliarwwds_14_tftipadsc = "";
         AV62Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel = "";
         AV63Contabilidad_tipoauxiliarwwds_16_tftipasts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV50Contabilidad_tipoauxiliarwwds_3_tipadsc1 = "";
         lV54Contabilidad_tipoauxiliarwwds_7_tipadsc2 = "";
         lV58Contabilidad_tipoauxiliarwwds_11_tipadsc3 = "";
         lV61Contabilidad_tipoauxiliarwwds_14_tftipadsc = "";
         A1900TipADsc = "";
         P006L2_A1902TipASts = new short[1] ;
         P006L2_A70TipACod = new int[1] ;
         P006L2_A1900TipADsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38TFTipASts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.tipoauxiliarwwexport__default(),
            new Object[][] {
                new Object[] {
               P006L2_A1902TipASts, P006L2_A70TipACod, P006L2_A1900TipADsc
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
      private short AV40TFTipASts_Sel ;
      private short AV49Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 ;
      private short AV53Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 ;
      private short AV57Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 ;
      private short A1902TipASts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFTipACod ;
      private int AV35TFTipACod_To ;
      private int AV46GXV1 ;
      private int AV59Contabilidad_tipoauxiliarwwds_12_tftipacod ;
      private int AV60Contabilidad_tipoauxiliarwwds_13_tftipacod_to ;
      private int AV63Contabilidad_tipoauxiliarwwds_16_tftipasts_sels_Count ;
      private int A70TipACod ;
      private int AV64GXV2 ;
      private long AV41i ;
      private string AV20TipADsc1 ;
      private string AV24TipADsc2 ;
      private string AV28TipADsc3 ;
      private string AV37TFTipADsc_Sel ;
      private string AV36TFTipADsc ;
      private string AV50Contabilidad_tipoauxiliarwwds_3_tipadsc1 ;
      private string AV54Contabilidad_tipoauxiliarwwds_7_tipadsc2 ;
      private string AV58Contabilidad_tipoauxiliarwwds_11_tipadsc3 ;
      private string AV61Contabilidad_tipoauxiliarwwds_14_tftipadsc ;
      private string AV62Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel ;
      private string scmdbuf ;
      private string lV50Contabilidad_tipoauxiliarwwds_3_tipadsc1 ;
      private string lV54Contabilidad_tipoauxiliarwwds_7_tipadsc2 ;
      private string lV58Contabilidad_tipoauxiliarwwds_11_tipadsc3 ;
      private string lV61Contabilidad_tipoauxiliarwwds_14_tftipadsc ;
      private string A1900TipADsc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV51Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 ;
      private bool AV55Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV38TFTipASts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV48Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 ;
      private string AV52Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 ;
      private string AV56Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV39TFTipASts_Sels ;
      private GxSimpleCollection<short> AV63Contabilidad_tipoauxiliarwwds_16_tftipasts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006L2_A1902TipASts ;
      private int[] P006L2_A70TipACod ;
      private string[] P006L2_A1900TipADsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class tipoauxiliarwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006L2( IGxContext context ,
                                             short A1902TipASts ,
                                             GxSimpleCollection<short> AV63Contabilidad_tipoauxiliarwwds_16_tftipasts_sels ,
                                             string AV48Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 ,
                                             short AV49Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 ,
                                             string AV50Contabilidad_tipoauxiliarwwds_3_tipadsc1 ,
                                             bool AV51Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 ,
                                             string AV52Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 ,
                                             short AV53Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 ,
                                             string AV54Contabilidad_tipoauxiliarwwds_7_tipadsc2 ,
                                             bool AV55Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 ,
                                             string AV56Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 ,
                                             short AV57Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 ,
                                             string AV58Contabilidad_tipoauxiliarwwds_11_tipadsc3 ,
                                             int AV59Contabilidad_tipoauxiliarwwds_12_tftipacod ,
                                             int AV60Contabilidad_tipoauxiliarwwds_13_tftipacod_to ,
                                             string AV62Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel ,
                                             string AV61Contabilidad_tipoauxiliarwwds_14_tftipadsc ,
                                             int AV63Contabilidad_tipoauxiliarwwds_16_tftipasts_sels_Count ,
                                             string A1900TipADsc ,
                                             int A70TipACod ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TipASts], [TipACod], [TipADsc] FROM [CBTIPAUXILIAR]";
         if ( ( StringUtil.StrCmp(AV48Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1, "TIPADSC") == 0 ) && ( AV49Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Contabilidad_tipoauxiliarwwds_3_tipadsc1)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like @lV50Contabilidad_tipoauxiliarwwds_3_tipadsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV48Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1, "TIPADSC") == 0 ) && ( AV49Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Contabilidad_tipoauxiliarwwds_3_tipadsc1)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like '%' + @lV50Contabilidad_tipoauxiliarwwds_3_tipadsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV51Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV52Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2, "TIPADSC") == 0 ) && ( AV53Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Contabilidad_tipoauxiliarwwds_7_tipadsc2)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like @lV54Contabilidad_tipoauxiliarwwds_7_tipadsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV51Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV52Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2, "TIPADSC") == 0 ) && ( AV53Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Contabilidad_tipoauxiliarwwds_7_tipadsc2)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like '%' + @lV54Contabilidad_tipoauxiliarwwds_7_tipadsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV55Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3, "TIPADSC") == 0 ) && ( AV57Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contabilidad_tipoauxiliarwwds_11_tipadsc3)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like @lV58Contabilidad_tipoauxiliarwwds_11_tipadsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV55Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3, "TIPADSC") == 0 ) && ( AV57Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contabilidad_tipoauxiliarwwds_11_tipadsc3)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like '%' + @lV58Contabilidad_tipoauxiliarwwds_11_tipadsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV59Contabilidad_tipoauxiliarwwds_12_tftipacod) )
         {
            AddWhere(sWhereString, "([TipACod] >= @AV59Contabilidad_tipoauxiliarwwds_12_tftipacod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV60Contabilidad_tipoauxiliarwwds_13_tftipacod_to) )
         {
            AddWhere(sWhereString, "([TipACod] <= @AV60Contabilidad_tipoauxiliarwwds_13_tftipacod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Contabilidad_tipoauxiliarwwds_14_tftipadsc)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like @lV61Contabilidad_tipoauxiliarwwds_14_tftipadsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel)) )
         {
            AddWhere(sWhereString, "([TipADsc] = @AV62Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV63Contabilidad_tipoauxiliarwwds_16_tftipasts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV63Contabilidad_tipoauxiliarwwds_16_tftipasts_sels, "[TipASts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipACod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipACod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipADsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipADsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipASts]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipASts] DESC";
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
                     return conditional_P006L2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP006L2;
          prmP006L2 = new Object[] {
          new ParDef("@lV50Contabilidad_tipoauxiliarwwds_3_tipadsc1",GXType.NChar,100,0) ,
          new ParDef("@lV50Contabilidad_tipoauxiliarwwds_3_tipadsc1",GXType.NChar,100,0) ,
          new ParDef("@lV54Contabilidad_tipoauxiliarwwds_7_tipadsc2",GXType.NChar,100,0) ,
          new ParDef("@lV54Contabilidad_tipoauxiliarwwds_7_tipadsc2",GXType.NChar,100,0) ,
          new ParDef("@lV58Contabilidad_tipoauxiliarwwds_11_tipadsc3",GXType.NChar,100,0) ,
          new ParDef("@lV58Contabilidad_tipoauxiliarwwds_11_tipadsc3",GXType.NChar,100,0) ,
          new ParDef("@AV59Contabilidad_tipoauxiliarwwds_12_tftipacod",GXType.Int32,6,0) ,
          new ParDef("@AV60Contabilidad_tipoauxiliarwwds_13_tftipacod_to",GXType.Int32,6,0) ,
          new ParDef("@lV61Contabilidad_tipoauxiliarwwds_14_tftipadsc",GXType.NChar,100,0) ,
          new ParDef("@AV62Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006L2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
