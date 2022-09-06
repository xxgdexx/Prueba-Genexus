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
namespace GeneXus.Programs.seguridad {
   public class localeswwexport : GXProcedure
   {
      public localeswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public localeswwexport( IGxContext context )
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
         localeswwexport objlocaleswwexport;
         objlocaleswwexport = new localeswwexport();
         objlocaleswwexport.AV11Filename = "" ;
         objlocaleswwexport.AV12ErrorMessage = "" ;
         objlocaleswwexport.context.SetSubmitInitialConfig(context);
         objlocaleswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlocaleswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((localeswwexport)stateInfo).executePrivate();
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
         AV11Filename = "LocalesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIEDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20TieDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TieDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Local", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Local", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20TieDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TIEDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24TieDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TieDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Local", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Local", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24TieDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIEDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28TieDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TieDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Local", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Local", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28TieDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFTieCod) && (0==AV35TFTieCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFTieCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFTieCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTieDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Local") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFTieDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTieDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Local") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFTieDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFTieAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFTieAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTieAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFTieAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV43TFTieSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV45i = 1;
            AV48GXV1 = 1;
            while ( AV48GXV1 <= AV43TFTieSts_Sels.Count )
            {
               AV44TFTieSts_Sel = (short)(AV43TFTieSts_Sels.GetNumeric(AV48GXV1));
               if ( AV45i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV44TFTieSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV44TFTieSts_Sel == 0 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Local";
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
         AV50Seguridad_localeswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV51Seguridad_localeswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV52Seguridad_localeswwds_3_tiedsc1 = AV20TieDsc1;
         AV53Seguridad_localeswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV54Seguridad_localeswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV55Seguridad_localeswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV56Seguridad_localeswwds_7_tiedsc2 = AV24TieDsc2;
         AV57Seguridad_localeswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV58Seguridad_localeswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV59Seguridad_localeswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV60Seguridad_localeswwds_11_tiedsc3 = AV28TieDsc3;
         AV61Seguridad_localeswwds_12_tftiecod = AV34TFTieCod;
         AV62Seguridad_localeswwds_13_tftiecod_to = AV35TFTieCod_To;
         AV63Seguridad_localeswwds_14_tftiedsc = AV36TFTieDsc;
         AV64Seguridad_localeswwds_15_tftiedsc_sel = AV37TFTieDsc_Sel;
         AV65Seguridad_localeswwds_16_tftieabr = AV38TFTieAbr;
         AV66Seguridad_localeswwds_17_tftieabr_sel = AV39TFTieAbr_Sel;
         AV67Seguridad_localeswwds_18_tftiests_sels = AV43TFTieSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1899TieSts ,
                                              AV67Seguridad_localeswwds_18_tftiests_sels ,
                                              AV50Seguridad_localeswwds_1_dynamicfiltersselector1 ,
                                              AV51Seguridad_localeswwds_2_dynamicfiltersoperator1 ,
                                              AV52Seguridad_localeswwds_3_tiedsc1 ,
                                              AV53Seguridad_localeswwds_4_dynamicfiltersenabled2 ,
                                              AV54Seguridad_localeswwds_5_dynamicfiltersselector2 ,
                                              AV55Seguridad_localeswwds_6_dynamicfiltersoperator2 ,
                                              AV56Seguridad_localeswwds_7_tiedsc2 ,
                                              AV57Seguridad_localeswwds_8_dynamicfiltersenabled3 ,
                                              AV58Seguridad_localeswwds_9_dynamicfiltersselector3 ,
                                              AV59Seguridad_localeswwds_10_dynamicfiltersoperator3 ,
                                              AV60Seguridad_localeswwds_11_tiedsc3 ,
                                              AV61Seguridad_localeswwds_12_tftiecod ,
                                              AV62Seguridad_localeswwds_13_tftiecod_to ,
                                              AV64Seguridad_localeswwds_15_tftiedsc_sel ,
                                              AV63Seguridad_localeswwds_14_tftiedsc ,
                                              AV66Seguridad_localeswwds_17_tftieabr_sel ,
                                              AV65Seguridad_localeswwds_16_tftieabr ,
                                              AV67Seguridad_localeswwds_18_tftiests_sels.Count ,
                                              A1898TieDsc ,
                                              A178TieCod ,
                                              A1897TieAbr ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Seguridad_localeswwds_3_tiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV52Seguridad_localeswwds_3_tiedsc1), 100, "%");
         lV52Seguridad_localeswwds_3_tiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV52Seguridad_localeswwds_3_tiedsc1), 100, "%");
         lV56Seguridad_localeswwds_7_tiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV56Seguridad_localeswwds_7_tiedsc2), 100, "%");
         lV56Seguridad_localeswwds_7_tiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV56Seguridad_localeswwds_7_tiedsc2), 100, "%");
         lV60Seguridad_localeswwds_11_tiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV60Seguridad_localeswwds_11_tiedsc3), 100, "%");
         lV60Seguridad_localeswwds_11_tiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV60Seguridad_localeswwds_11_tiedsc3), 100, "%");
         lV63Seguridad_localeswwds_14_tftiedsc = StringUtil.PadR( StringUtil.RTrim( AV63Seguridad_localeswwds_14_tftiedsc), 100, "%");
         lV65Seguridad_localeswwds_16_tftieabr = StringUtil.Concat( StringUtil.RTrim( AV65Seguridad_localeswwds_16_tftieabr), "%", "");
         /* Using cursor P00202 */
         pr_default.execute(0, new Object[] {lV52Seguridad_localeswwds_3_tiedsc1, lV52Seguridad_localeswwds_3_tiedsc1, lV56Seguridad_localeswwds_7_tiedsc2, lV56Seguridad_localeswwds_7_tiedsc2, lV60Seguridad_localeswwds_11_tiedsc3, lV60Seguridad_localeswwds_11_tiedsc3, AV61Seguridad_localeswwds_12_tftiecod, AV62Seguridad_localeswwds_13_tftiecod_to, lV63Seguridad_localeswwds_14_tftiedsc, AV64Seguridad_localeswwds_15_tftiedsc_sel, lV65Seguridad_localeswwds_16_tftieabr, AV66Seguridad_localeswwds_17_tftieabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1899TieSts = P00202_A1899TieSts[0];
            A1897TieAbr = P00202_A1897TieAbr[0];
            A178TieCod = P00202_A178TieCod[0];
            A1898TieDsc = P00202_A1898TieDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A178TieCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1898TieDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1897TieAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A1899TieSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "ACTIVO";
            }
            else if ( A1899TieSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Seguridad.LocalesWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.LocalesWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Seguridad.LocalesWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV68GXV2 = 1;
         while ( AV68GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV68GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIECOD") == 0 )
            {
               AV34TFTieCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFTieCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIEDSC") == 0 )
            {
               AV36TFTieDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIEDSC_SEL") == 0 )
            {
               AV37TFTieDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIEABR") == 0 )
            {
               AV38TFTieAbr = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIEABR_SEL") == 0 )
            {
               AV39TFTieAbr_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIESTS_SEL") == 0 )
            {
               AV42TFTieSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV43TFTieSts_Sels.FromJSonString(AV42TFTieSts_SelsJson, null);
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
         AV20TieDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24TieDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28TieDsc3 = "";
         AV37TFTieDsc_Sel = "";
         AV36TFTieDsc = "";
         AV39TFTieAbr_Sel = "";
         AV38TFTieAbr = "";
         AV43TFTieSts_Sels = new GxSimpleCollection<short>();
         AV50Seguridad_localeswwds_1_dynamicfiltersselector1 = "";
         AV52Seguridad_localeswwds_3_tiedsc1 = "";
         AV54Seguridad_localeswwds_5_dynamicfiltersselector2 = "";
         AV56Seguridad_localeswwds_7_tiedsc2 = "";
         AV58Seguridad_localeswwds_9_dynamicfiltersselector3 = "";
         AV60Seguridad_localeswwds_11_tiedsc3 = "";
         AV63Seguridad_localeswwds_14_tftiedsc = "";
         AV64Seguridad_localeswwds_15_tftiedsc_sel = "";
         AV65Seguridad_localeswwds_16_tftieabr = "";
         AV66Seguridad_localeswwds_17_tftieabr_sel = "";
         AV67Seguridad_localeswwds_18_tftiests_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV52Seguridad_localeswwds_3_tiedsc1 = "";
         lV56Seguridad_localeswwds_7_tiedsc2 = "";
         lV60Seguridad_localeswwds_11_tiedsc3 = "";
         lV63Seguridad_localeswwds_14_tftiedsc = "";
         lV65Seguridad_localeswwds_16_tftieabr = "";
         A1898TieDsc = "";
         A1897TieAbr = "";
         P00202_A1899TieSts = new short[1] ;
         P00202_A1897TieAbr = new string[] {""} ;
         P00202_A178TieCod = new int[1] ;
         P00202_A1898TieDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV42TFTieSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.localeswwexport__default(),
            new Object[][] {
                new Object[] {
               P00202_A1899TieSts, P00202_A1897TieAbr, P00202_A178TieCod, P00202_A1898TieDsc
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
      private short AV44TFTieSts_Sel ;
      private short AV51Seguridad_localeswwds_2_dynamicfiltersoperator1 ;
      private short AV55Seguridad_localeswwds_6_dynamicfiltersoperator2 ;
      private short AV59Seguridad_localeswwds_10_dynamicfiltersoperator3 ;
      private short A1899TieSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFTieCod ;
      private int AV35TFTieCod_To ;
      private int AV48GXV1 ;
      private int AV61Seguridad_localeswwds_12_tftiecod ;
      private int AV62Seguridad_localeswwds_13_tftiecod_to ;
      private int AV67Seguridad_localeswwds_18_tftiests_sels_Count ;
      private int A178TieCod ;
      private int AV68GXV2 ;
      private long AV45i ;
      private string AV20TieDsc1 ;
      private string AV24TieDsc2 ;
      private string AV28TieDsc3 ;
      private string AV37TFTieDsc_Sel ;
      private string AV36TFTieDsc ;
      private string AV52Seguridad_localeswwds_3_tiedsc1 ;
      private string AV56Seguridad_localeswwds_7_tiedsc2 ;
      private string AV60Seguridad_localeswwds_11_tiedsc3 ;
      private string AV63Seguridad_localeswwds_14_tftiedsc ;
      private string AV64Seguridad_localeswwds_15_tftiedsc_sel ;
      private string scmdbuf ;
      private string lV52Seguridad_localeswwds_3_tiedsc1 ;
      private string lV56Seguridad_localeswwds_7_tiedsc2 ;
      private string lV60Seguridad_localeswwds_11_tiedsc3 ;
      private string lV63Seguridad_localeswwds_14_tftiedsc ;
      private string A1898TieDsc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV53Seguridad_localeswwds_4_dynamicfiltersenabled2 ;
      private bool AV57Seguridad_localeswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV42TFTieSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV39TFTieAbr_Sel ;
      private string AV38TFTieAbr ;
      private string AV50Seguridad_localeswwds_1_dynamicfiltersselector1 ;
      private string AV54Seguridad_localeswwds_5_dynamicfiltersselector2 ;
      private string AV58Seguridad_localeswwds_9_dynamicfiltersselector3 ;
      private string AV65Seguridad_localeswwds_16_tftieabr ;
      private string AV66Seguridad_localeswwds_17_tftieabr_sel ;
      private string lV65Seguridad_localeswwds_16_tftieabr ;
      private string A1897TieAbr ;
      private GxSimpleCollection<short> AV43TFTieSts_Sels ;
      private GxSimpleCollection<short> AV67Seguridad_localeswwds_18_tftiests_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00202_A1899TieSts ;
      private string[] P00202_A1897TieAbr ;
      private int[] P00202_A178TieCod ;
      private string[] P00202_A1898TieDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class localeswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00202( IGxContext context ,
                                             short A1899TieSts ,
                                             GxSimpleCollection<short> AV67Seguridad_localeswwds_18_tftiests_sels ,
                                             string AV50Seguridad_localeswwds_1_dynamicfiltersselector1 ,
                                             short AV51Seguridad_localeswwds_2_dynamicfiltersoperator1 ,
                                             string AV52Seguridad_localeswwds_3_tiedsc1 ,
                                             bool AV53Seguridad_localeswwds_4_dynamicfiltersenabled2 ,
                                             string AV54Seguridad_localeswwds_5_dynamicfiltersselector2 ,
                                             short AV55Seguridad_localeswwds_6_dynamicfiltersoperator2 ,
                                             string AV56Seguridad_localeswwds_7_tiedsc2 ,
                                             bool AV57Seguridad_localeswwds_8_dynamicfiltersenabled3 ,
                                             string AV58Seguridad_localeswwds_9_dynamicfiltersselector3 ,
                                             short AV59Seguridad_localeswwds_10_dynamicfiltersoperator3 ,
                                             string AV60Seguridad_localeswwds_11_tiedsc3 ,
                                             int AV61Seguridad_localeswwds_12_tftiecod ,
                                             int AV62Seguridad_localeswwds_13_tftiecod_to ,
                                             string AV64Seguridad_localeswwds_15_tftiedsc_sel ,
                                             string AV63Seguridad_localeswwds_14_tftiedsc ,
                                             string AV66Seguridad_localeswwds_17_tftieabr_sel ,
                                             string AV65Seguridad_localeswwds_16_tftieabr ,
                                             int AV67Seguridad_localeswwds_18_tftiests_sels_Count ,
                                             string A1898TieDsc ,
                                             int A178TieCod ,
                                             string A1897TieAbr ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TieSts], [TieAbr], [TieCod], [TieDsc] FROM [SGTIENDAS]";
         if ( ( StringUtil.StrCmp(AV50Seguridad_localeswwds_1_dynamicfiltersselector1, "TIEDSC") == 0 ) && ( AV51Seguridad_localeswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Seguridad_localeswwds_3_tiedsc1)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV52Seguridad_localeswwds_3_tiedsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Seguridad_localeswwds_1_dynamicfiltersselector1, "TIEDSC") == 0 ) && ( AV51Seguridad_localeswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Seguridad_localeswwds_3_tiedsc1)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like '%' + @lV52Seguridad_localeswwds_3_tiedsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV53Seguridad_localeswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Seguridad_localeswwds_5_dynamicfiltersselector2, "TIEDSC") == 0 ) && ( AV55Seguridad_localeswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Seguridad_localeswwds_7_tiedsc2)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV56Seguridad_localeswwds_7_tiedsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV53Seguridad_localeswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Seguridad_localeswwds_5_dynamicfiltersselector2, "TIEDSC") == 0 ) && ( AV55Seguridad_localeswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Seguridad_localeswwds_7_tiedsc2)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like '%' + @lV56Seguridad_localeswwds_7_tiedsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV57Seguridad_localeswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Seguridad_localeswwds_9_dynamicfiltersselector3, "TIEDSC") == 0 ) && ( AV59Seguridad_localeswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Seguridad_localeswwds_11_tiedsc3)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV60Seguridad_localeswwds_11_tiedsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV57Seguridad_localeswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Seguridad_localeswwds_9_dynamicfiltersselector3, "TIEDSC") == 0 ) && ( AV59Seguridad_localeswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Seguridad_localeswwds_11_tiedsc3)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like '%' + @lV60Seguridad_localeswwds_11_tiedsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV61Seguridad_localeswwds_12_tftiecod) )
         {
            AddWhere(sWhereString, "([TieCod] >= @AV61Seguridad_localeswwds_12_tftiecod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV62Seguridad_localeswwds_13_tftiecod_to) )
         {
            AddWhere(sWhereString, "([TieCod] <= @AV62Seguridad_localeswwds_13_tftiecod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Seguridad_localeswwds_15_tftiedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Seguridad_localeswwds_14_tftiedsc)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV63Seguridad_localeswwds_14_tftiedsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Seguridad_localeswwds_15_tftiedsc_sel)) )
         {
            AddWhere(sWhereString, "([TieDsc] = @AV64Seguridad_localeswwds_15_tftiedsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Seguridad_localeswwds_17_tftieabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Seguridad_localeswwds_16_tftieabr)) ) )
         {
            AddWhere(sWhereString, "([TieAbr] like @lV65Seguridad_localeswwds_16_tftieabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Seguridad_localeswwds_17_tftieabr_sel)) )
         {
            AddWhere(sWhereString, "([TieAbr] = @AV66Seguridad_localeswwds_17_tftieabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV67Seguridad_localeswwds_18_tftiests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV67Seguridad_localeswwds_18_tftiests_sels, "[TieSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TieCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TieCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TieDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TieDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TieAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TieAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TieSts]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TieSts] DESC";
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
                     return conditional_P00202(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP00202;
          prmP00202 = new Object[] {
          new ParDef("@lV52Seguridad_localeswwds_3_tiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV52Seguridad_localeswwds_3_tiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV56Seguridad_localeswwds_7_tiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV56Seguridad_localeswwds_7_tiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV60Seguridad_localeswwds_11_tiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV60Seguridad_localeswwds_11_tiedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV61Seguridad_localeswwds_12_tftiecod",GXType.Int32,6,0) ,
          new ParDef("@AV62Seguridad_localeswwds_13_tftiecod_to",GXType.Int32,6,0) ,
          new ParDef("@lV63Seguridad_localeswwds_14_tftiedsc",GXType.NChar,100,0) ,
          new ParDef("@AV64Seguridad_localeswwds_15_tftiedsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV65Seguridad_localeswwds_16_tftieabr",GXType.NVarChar,10,0) ,
          new ParDef("@AV66Seguridad_localeswwds_17_tftieabr_sel",GXType.NVarChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00202", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00202,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
