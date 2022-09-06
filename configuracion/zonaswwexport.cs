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
   public class zonaswwexport : GXProcedure
   {
      public zonaswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public zonaswwexport( IGxContext context )
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
         zonaswwexport objzonaswwexport;
         objzonaswwexport = new zonaswwexport();
         objzonaswwexport.AV11Filename = "" ;
         objzonaswwexport.AV12ErrorMessage = "" ;
         objzonaswwexport.context.SetSubmitInitialConfig(context);
         objzonaswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objzonaswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((zonaswwexport)stateInfo).executePrivate();
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
         AV11Filename = "ZonasWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "ZONDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20ZonDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ZonDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Zona", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Zona", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20ZonDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "ZONDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24ZonDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ZonDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Zona", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Zona", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24ZonDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "ZONDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28ZonDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ZonDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Zona", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Zona", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ZonDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFZonCod) && (0==AV35TFZonCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFZonCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFZonCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFZonDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Zona") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFZonDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFZonDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Zona") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFZonDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV39TFZonSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV41i = 1;
            AV44GXV1 = 1;
            while ( AV44GXV1 <= AV39TFZonSts_Sels.Count )
            {
               AV40TFZonSts_Sel = (short)(AV39TFZonSts_Sels.GetNumeric(AV44GXV1));
               if ( AV41i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV40TFZonSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV40TFZonSts_Sel == 0 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Zona";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV46Configuracion_zonaswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV47Configuracion_zonaswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV48Configuracion_zonaswwds_3_zondsc1 = AV20ZonDsc1;
         AV49Configuracion_zonaswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV50Configuracion_zonaswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV51Configuracion_zonaswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV52Configuracion_zonaswwds_7_zondsc2 = AV24ZonDsc2;
         AV53Configuracion_zonaswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV54Configuracion_zonaswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV55Configuracion_zonaswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV56Configuracion_zonaswwds_11_zondsc3 = AV28ZonDsc3;
         AV57Configuracion_zonaswwds_12_tfzoncod = AV34TFZonCod;
         AV58Configuracion_zonaswwds_13_tfzoncod_to = AV35TFZonCod_To;
         AV59Configuracion_zonaswwds_14_tfzondsc = AV36TFZonDsc;
         AV60Configuracion_zonaswwds_15_tfzondsc_sel = AV37TFZonDsc_Sel;
         AV61Configuracion_zonaswwds_16_tfzonsts_sels = AV39TFZonSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A2095ZonSts ,
                                              AV61Configuracion_zonaswwds_16_tfzonsts_sels ,
                                              AV46Configuracion_zonaswwds_1_dynamicfiltersselector1 ,
                                              AV47Configuracion_zonaswwds_2_dynamicfiltersoperator1 ,
                                              AV48Configuracion_zonaswwds_3_zondsc1 ,
                                              AV49Configuracion_zonaswwds_4_dynamicfiltersenabled2 ,
                                              AV50Configuracion_zonaswwds_5_dynamicfiltersselector2 ,
                                              AV51Configuracion_zonaswwds_6_dynamicfiltersoperator2 ,
                                              AV52Configuracion_zonaswwds_7_zondsc2 ,
                                              AV53Configuracion_zonaswwds_8_dynamicfiltersenabled3 ,
                                              AV54Configuracion_zonaswwds_9_dynamicfiltersselector3 ,
                                              AV55Configuracion_zonaswwds_10_dynamicfiltersoperator3 ,
                                              AV56Configuracion_zonaswwds_11_zondsc3 ,
                                              AV57Configuracion_zonaswwds_12_tfzoncod ,
                                              AV58Configuracion_zonaswwds_13_tfzoncod_to ,
                                              AV60Configuracion_zonaswwds_15_tfzondsc_sel ,
                                              AV59Configuracion_zonaswwds_14_tfzondsc ,
                                              AV61Configuracion_zonaswwds_16_tfzonsts_sels.Count ,
                                              A2094ZonDsc ,
                                              A158ZonCod ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Configuracion_zonaswwds_3_zondsc1 = StringUtil.PadR( StringUtil.RTrim( AV48Configuracion_zonaswwds_3_zondsc1), 100, "%");
         lV48Configuracion_zonaswwds_3_zondsc1 = StringUtil.PadR( StringUtil.RTrim( AV48Configuracion_zonaswwds_3_zondsc1), 100, "%");
         lV52Configuracion_zonaswwds_7_zondsc2 = StringUtil.PadR( StringUtil.RTrim( AV52Configuracion_zonaswwds_7_zondsc2), 100, "%");
         lV52Configuracion_zonaswwds_7_zondsc2 = StringUtil.PadR( StringUtil.RTrim( AV52Configuracion_zonaswwds_7_zondsc2), 100, "%");
         lV56Configuracion_zonaswwds_11_zondsc3 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_zonaswwds_11_zondsc3), 100, "%");
         lV56Configuracion_zonaswwds_11_zondsc3 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_zonaswwds_11_zondsc3), 100, "%");
         lV59Configuracion_zonaswwds_14_tfzondsc = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_zonaswwds_14_tfzondsc), 100, "%");
         /* Using cursor P00412 */
         pr_default.execute(0, new Object[] {lV48Configuracion_zonaswwds_3_zondsc1, lV48Configuracion_zonaswwds_3_zondsc1, lV52Configuracion_zonaswwds_7_zondsc2, lV52Configuracion_zonaswwds_7_zondsc2, lV56Configuracion_zonaswwds_11_zondsc3, lV56Configuracion_zonaswwds_11_zondsc3, AV57Configuracion_zonaswwds_12_tfzoncod, AV58Configuracion_zonaswwds_13_tfzoncod_to, lV59Configuracion_zonaswwds_14_tfzondsc, AV60Configuracion_zonaswwds_15_tfzondsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2095ZonSts = P00412_A2095ZonSts[0];
            A158ZonCod = P00412_A158ZonCod[0];
            A2094ZonDsc = P00412_A2094ZonDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A158ZonCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2094ZonDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( A2095ZonSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "ACTIVO";
            }
            else if ( A2095ZonSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.ZonasWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.ZonasWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.ZonasWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV62GXV2 = 1;
         while ( AV62GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV62GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFZONCOD") == 0 )
            {
               AV34TFZonCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFZonCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFZONDSC") == 0 )
            {
               AV36TFZonDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFZONDSC_SEL") == 0 )
            {
               AV37TFZonDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFZONSTS_SEL") == 0 )
            {
               AV38TFZonSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV39TFZonSts_Sels.FromJSonString(AV38TFZonSts_SelsJson, null);
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
         AV20ZonDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24ZonDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28ZonDsc3 = "";
         AV37TFZonDsc_Sel = "";
         AV36TFZonDsc = "";
         AV39TFZonSts_Sels = new GxSimpleCollection<short>();
         AV46Configuracion_zonaswwds_1_dynamicfiltersselector1 = "";
         AV48Configuracion_zonaswwds_3_zondsc1 = "";
         AV50Configuracion_zonaswwds_5_dynamicfiltersselector2 = "";
         AV52Configuracion_zonaswwds_7_zondsc2 = "";
         AV54Configuracion_zonaswwds_9_dynamicfiltersselector3 = "";
         AV56Configuracion_zonaswwds_11_zondsc3 = "";
         AV59Configuracion_zonaswwds_14_tfzondsc = "";
         AV60Configuracion_zonaswwds_15_tfzondsc_sel = "";
         AV61Configuracion_zonaswwds_16_tfzonsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV48Configuracion_zonaswwds_3_zondsc1 = "";
         lV52Configuracion_zonaswwds_7_zondsc2 = "";
         lV56Configuracion_zonaswwds_11_zondsc3 = "";
         lV59Configuracion_zonaswwds_14_tfzondsc = "";
         A2094ZonDsc = "";
         P00412_A2095ZonSts = new short[1] ;
         P00412_A158ZonCod = new int[1] ;
         P00412_A2094ZonDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38TFZonSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.zonaswwexport__default(),
            new Object[][] {
                new Object[] {
               P00412_A2095ZonSts, P00412_A158ZonCod, P00412_A2094ZonDsc
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
      private short AV40TFZonSts_Sel ;
      private short AV47Configuracion_zonaswwds_2_dynamicfiltersoperator1 ;
      private short AV51Configuracion_zonaswwds_6_dynamicfiltersoperator2 ;
      private short AV55Configuracion_zonaswwds_10_dynamicfiltersoperator3 ;
      private short A2095ZonSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFZonCod ;
      private int AV35TFZonCod_To ;
      private int AV44GXV1 ;
      private int AV57Configuracion_zonaswwds_12_tfzoncod ;
      private int AV58Configuracion_zonaswwds_13_tfzoncod_to ;
      private int AV61Configuracion_zonaswwds_16_tfzonsts_sels_Count ;
      private int A158ZonCod ;
      private int AV62GXV2 ;
      private long AV41i ;
      private string AV20ZonDsc1 ;
      private string AV24ZonDsc2 ;
      private string AV28ZonDsc3 ;
      private string AV37TFZonDsc_Sel ;
      private string AV36TFZonDsc ;
      private string AV48Configuracion_zonaswwds_3_zondsc1 ;
      private string AV52Configuracion_zonaswwds_7_zondsc2 ;
      private string AV56Configuracion_zonaswwds_11_zondsc3 ;
      private string AV59Configuracion_zonaswwds_14_tfzondsc ;
      private string AV60Configuracion_zonaswwds_15_tfzondsc_sel ;
      private string scmdbuf ;
      private string lV48Configuracion_zonaswwds_3_zondsc1 ;
      private string lV52Configuracion_zonaswwds_7_zondsc2 ;
      private string lV56Configuracion_zonaswwds_11_zondsc3 ;
      private string lV59Configuracion_zonaswwds_14_tfzondsc ;
      private string A2094ZonDsc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV49Configuracion_zonaswwds_4_dynamicfiltersenabled2 ;
      private bool AV53Configuracion_zonaswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV38TFZonSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV46Configuracion_zonaswwds_1_dynamicfiltersselector1 ;
      private string AV50Configuracion_zonaswwds_5_dynamicfiltersselector2 ;
      private string AV54Configuracion_zonaswwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV39TFZonSts_Sels ;
      private GxSimpleCollection<short> AV61Configuracion_zonaswwds_16_tfzonsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00412_A2095ZonSts ;
      private int[] P00412_A158ZonCod ;
      private string[] P00412_A2094ZonDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class zonaswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00412( IGxContext context ,
                                             short A2095ZonSts ,
                                             GxSimpleCollection<short> AV61Configuracion_zonaswwds_16_tfzonsts_sels ,
                                             string AV46Configuracion_zonaswwds_1_dynamicfiltersselector1 ,
                                             short AV47Configuracion_zonaswwds_2_dynamicfiltersoperator1 ,
                                             string AV48Configuracion_zonaswwds_3_zondsc1 ,
                                             bool AV49Configuracion_zonaswwds_4_dynamicfiltersenabled2 ,
                                             string AV50Configuracion_zonaswwds_5_dynamicfiltersselector2 ,
                                             short AV51Configuracion_zonaswwds_6_dynamicfiltersoperator2 ,
                                             string AV52Configuracion_zonaswwds_7_zondsc2 ,
                                             bool AV53Configuracion_zonaswwds_8_dynamicfiltersenabled3 ,
                                             string AV54Configuracion_zonaswwds_9_dynamicfiltersselector3 ,
                                             short AV55Configuracion_zonaswwds_10_dynamicfiltersoperator3 ,
                                             string AV56Configuracion_zonaswwds_11_zondsc3 ,
                                             int AV57Configuracion_zonaswwds_12_tfzoncod ,
                                             int AV58Configuracion_zonaswwds_13_tfzoncod_to ,
                                             string AV60Configuracion_zonaswwds_15_tfzondsc_sel ,
                                             string AV59Configuracion_zonaswwds_14_tfzondsc ,
                                             int AV61Configuracion_zonaswwds_16_tfzonsts_sels_Count ,
                                             string A2094ZonDsc ,
                                             int A158ZonCod ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [ZonSts], [ZonCod], [ZonDsc] FROM [CZONAS]";
         if ( ( StringUtil.StrCmp(AV46Configuracion_zonaswwds_1_dynamicfiltersselector1, "ZONDSC") == 0 ) && ( AV47Configuracion_zonaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Configuracion_zonaswwds_3_zondsc1)) ) )
         {
            AddWhere(sWhereString, "([ZonDsc] like @lV48Configuracion_zonaswwds_3_zondsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV46Configuracion_zonaswwds_1_dynamicfiltersselector1, "ZONDSC") == 0 ) && ( AV47Configuracion_zonaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Configuracion_zonaswwds_3_zondsc1)) ) )
         {
            AddWhere(sWhereString, "([ZonDsc] like '%' + @lV48Configuracion_zonaswwds_3_zondsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV49Configuracion_zonaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV50Configuracion_zonaswwds_5_dynamicfiltersselector2, "ZONDSC") == 0 ) && ( AV51Configuracion_zonaswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracion_zonaswwds_7_zondsc2)) ) )
         {
            AddWhere(sWhereString, "([ZonDsc] like @lV52Configuracion_zonaswwds_7_zondsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV49Configuracion_zonaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV50Configuracion_zonaswwds_5_dynamicfiltersselector2, "ZONDSC") == 0 ) && ( AV51Configuracion_zonaswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracion_zonaswwds_7_zondsc2)) ) )
         {
            AddWhere(sWhereString, "([ZonDsc] like '%' + @lV52Configuracion_zonaswwds_7_zondsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV53Configuracion_zonaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV54Configuracion_zonaswwds_9_dynamicfiltersselector3, "ZONDSC") == 0 ) && ( AV55Configuracion_zonaswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_zonaswwds_11_zondsc3)) ) )
         {
            AddWhere(sWhereString, "([ZonDsc] like @lV56Configuracion_zonaswwds_11_zondsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV53Configuracion_zonaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV54Configuracion_zonaswwds_9_dynamicfiltersselector3, "ZONDSC") == 0 ) && ( AV55Configuracion_zonaswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_zonaswwds_11_zondsc3)) ) )
         {
            AddWhere(sWhereString, "([ZonDsc] like '%' + @lV56Configuracion_zonaswwds_11_zondsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV57Configuracion_zonaswwds_12_tfzoncod) )
         {
            AddWhere(sWhereString, "([ZonCod] >= @AV57Configuracion_zonaswwds_12_tfzoncod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV58Configuracion_zonaswwds_13_tfzoncod_to) )
         {
            AddWhere(sWhereString, "([ZonCod] <= @AV58Configuracion_zonaswwds_13_tfzoncod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_zonaswwds_15_tfzondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_zonaswwds_14_tfzondsc)) ) )
         {
            AddWhere(sWhereString, "([ZonDsc] like @lV59Configuracion_zonaswwds_14_tfzondsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_zonaswwds_15_tfzondsc_sel)) )
         {
            AddWhere(sWhereString, "([ZonDsc] = @AV60Configuracion_zonaswwds_15_tfzondsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV61Configuracion_zonaswwds_16_tfzonsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV61Configuracion_zonaswwds_16_tfzonsts_sels, "[ZonSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ZonCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ZonCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ZonDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ZonDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ZonSts]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ZonSts] DESC";
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
                     return conditional_P00412(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP00412;
          prmP00412 = new Object[] {
          new ParDef("@lV48Configuracion_zonaswwds_3_zondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV48Configuracion_zonaswwds_3_zondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV52Configuracion_zonaswwds_7_zondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV52Configuracion_zonaswwds_7_zondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV56Configuracion_zonaswwds_11_zondsc3",GXType.NChar,100,0) ,
          new ParDef("@lV56Configuracion_zonaswwds_11_zondsc3",GXType.NChar,100,0) ,
          new ParDef("@AV57Configuracion_zonaswwds_12_tfzoncod",GXType.Int32,6,0) ,
          new ParDef("@AV58Configuracion_zonaswwds_13_tfzoncod_to",GXType.Int32,6,0) ,
          new ParDef("@lV59Configuracion_zonaswwds_14_tfzondsc",GXType.NChar,100,0) ,
          new ParDef("@AV60Configuracion_zonaswwds_15_tfzondsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00412", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00412,100, GxCacheFrequency.OFF ,true,false )
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
