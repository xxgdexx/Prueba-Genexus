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
   public class monedaswwexport : GXProcedure
   {
      public monedaswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public monedaswwexport( IGxContext context )
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
         monedaswwexport objmonedaswwexport;
         objmonedaswwexport = new monedaswwexport();
         objmonedaswwexport.AV11Filename = "" ;
         objmonedaswwexport.AV12ErrorMessage = "" ;
         objmonedaswwexport.context.SetSubmitInitialConfig(context);
         objmonedaswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmonedaswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((monedaswwexport)stateInfo).executePrivate();
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
         AV11Filename = "MonedasWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MONDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20MonDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20MonDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Moneda", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Moneda", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20MonDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "MONDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24MonDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24MonDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Moneda", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Moneda", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24MonDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "MONDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28MonDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28MonDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Moneda", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Moneda", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28MonDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFMonCod) && (0==AV35TFMonCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFMonCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFMonCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFMonDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Moneda") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFMonDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFMonDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Moneda") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFMonDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFMonAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFMonAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFMonAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFMonAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFMonSunat_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sunat") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFMonSunat_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFMonSunat)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sunat") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFMonSunat, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV45TFMonSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV47i = 1;
            AV50GXV1 = 1;
            while ( AV50GXV1 <= AV45TFMonSts_Sels.Count )
            {
               AV46TFMonSts_Sel = (short)(AV45TFMonSts_Sels.GetNumeric(AV50GXV1));
               if ( AV47i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV46TFMonSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV46TFMonSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV47i = (long)(AV47i+1);
               AV50GXV1 = (int)(AV50GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Moneda";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Abreviatura";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Codigo Sunat";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV52Configuracion_monedaswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV53Configuracion_monedaswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV54Configuracion_monedaswwds_3_mondsc1 = AV20MonDsc1;
         AV55Configuracion_monedaswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV56Configuracion_monedaswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV57Configuracion_monedaswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV58Configuracion_monedaswwds_7_mondsc2 = AV24MonDsc2;
         AV59Configuracion_monedaswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV60Configuracion_monedaswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV61Configuracion_monedaswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV62Configuracion_monedaswwds_11_mondsc3 = AV28MonDsc3;
         AV63Configuracion_monedaswwds_12_tfmoncod = AV34TFMonCod;
         AV64Configuracion_monedaswwds_13_tfmoncod_to = AV35TFMonCod_To;
         AV65Configuracion_monedaswwds_14_tfmondsc = AV36TFMonDsc;
         AV66Configuracion_monedaswwds_15_tfmondsc_sel = AV37TFMonDsc_Sel;
         AV67Configuracion_monedaswwds_16_tfmonabr = AV38TFMonAbr;
         AV68Configuracion_monedaswwds_17_tfmonabr_sel = AV39TFMonAbr_Sel;
         AV69Configuracion_monedaswwds_18_tfmonsunat = AV42TFMonSunat;
         AV70Configuracion_monedaswwds_19_tfmonsunat_sel = AV43TFMonSunat_Sel;
         AV71Configuracion_monedaswwds_20_tfmonsts_sels = AV45TFMonSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1235MonSts ,
                                              AV71Configuracion_monedaswwds_20_tfmonsts_sels ,
                                              AV52Configuracion_monedaswwds_1_dynamicfiltersselector1 ,
                                              AV53Configuracion_monedaswwds_2_dynamicfiltersoperator1 ,
                                              AV54Configuracion_monedaswwds_3_mondsc1 ,
                                              AV55Configuracion_monedaswwds_4_dynamicfiltersenabled2 ,
                                              AV56Configuracion_monedaswwds_5_dynamicfiltersselector2 ,
                                              AV57Configuracion_monedaswwds_6_dynamicfiltersoperator2 ,
                                              AV58Configuracion_monedaswwds_7_mondsc2 ,
                                              AV59Configuracion_monedaswwds_8_dynamicfiltersenabled3 ,
                                              AV60Configuracion_monedaswwds_9_dynamicfiltersselector3 ,
                                              AV61Configuracion_monedaswwds_10_dynamicfiltersoperator3 ,
                                              AV62Configuracion_monedaswwds_11_mondsc3 ,
                                              AV63Configuracion_monedaswwds_12_tfmoncod ,
                                              AV64Configuracion_monedaswwds_13_tfmoncod_to ,
                                              AV66Configuracion_monedaswwds_15_tfmondsc_sel ,
                                              AV65Configuracion_monedaswwds_14_tfmondsc ,
                                              AV68Configuracion_monedaswwds_17_tfmonabr_sel ,
                                              AV67Configuracion_monedaswwds_16_tfmonabr ,
                                              AV70Configuracion_monedaswwds_19_tfmonsunat_sel ,
                                              AV69Configuracion_monedaswwds_18_tfmonsunat ,
                                              AV71Configuracion_monedaswwds_20_tfmonsts_sels.Count ,
                                              A1234MonDsc ,
                                              A180MonCod ,
                                              A1233MonAbr ,
                                              A1236MonSunat ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Configuracion_monedaswwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_monedaswwds_3_mondsc1), 100, "%");
         lV54Configuracion_monedaswwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_monedaswwds_3_mondsc1), 100, "%");
         lV58Configuracion_monedaswwds_7_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_monedaswwds_7_mondsc2), 100, "%");
         lV58Configuracion_monedaswwds_7_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_monedaswwds_7_mondsc2), 100, "%");
         lV62Configuracion_monedaswwds_11_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_monedaswwds_11_mondsc3), 100, "%");
         lV62Configuracion_monedaswwds_11_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_monedaswwds_11_mondsc3), 100, "%");
         lV65Configuracion_monedaswwds_14_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_monedaswwds_14_tfmondsc), 100, "%");
         lV67Configuracion_monedaswwds_16_tfmonabr = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_monedaswwds_16_tfmonabr), 5, "%");
         lV69Configuracion_monedaswwds_18_tfmonsunat = StringUtil.Concat( StringUtil.RTrim( AV69Configuracion_monedaswwds_18_tfmonsunat), "%", "");
         /* Using cursor P004D2 */
         pr_default.execute(0, new Object[] {lV54Configuracion_monedaswwds_3_mondsc1, lV54Configuracion_monedaswwds_3_mondsc1, lV58Configuracion_monedaswwds_7_mondsc2, lV58Configuracion_monedaswwds_7_mondsc2, lV62Configuracion_monedaswwds_11_mondsc3, lV62Configuracion_monedaswwds_11_mondsc3, AV63Configuracion_monedaswwds_12_tfmoncod, AV64Configuracion_monedaswwds_13_tfmoncod_to, lV65Configuracion_monedaswwds_14_tfmondsc, AV66Configuracion_monedaswwds_15_tfmondsc_sel, lV67Configuracion_monedaswwds_16_tfmonabr, AV68Configuracion_monedaswwds_17_tfmonabr_sel, lV69Configuracion_monedaswwds_18_tfmonsunat, AV70Configuracion_monedaswwds_19_tfmonsunat_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1235MonSts = P004D2_A1235MonSts[0];
            A1236MonSunat = P004D2_A1236MonSunat[0];
            A1233MonAbr = P004D2_A1233MonAbr[0];
            A180MonCod = P004D2_A180MonCod[0];
            A1234MonDsc = P004D2_A1234MonDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A180MonCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1234MonDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1233MonAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1236MonSunat, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A1235MonSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "ACTIVO";
            }
            else if ( A1235MonSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.MonedasWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.MonedasWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.MonedasWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV72GXV2 = 1;
         while ( AV72GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV72GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMONCOD") == 0 )
            {
               AV34TFMonCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFMonCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMONDSC") == 0 )
            {
               AV36TFMonDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMONDSC_SEL") == 0 )
            {
               AV37TFMonDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMONABR") == 0 )
            {
               AV38TFMonAbr = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMONABR_SEL") == 0 )
            {
               AV39TFMonAbr_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMONSUNAT") == 0 )
            {
               AV42TFMonSunat = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMONSUNAT_SEL") == 0 )
            {
               AV43TFMonSunat_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMONSTS_SEL") == 0 )
            {
               AV44TFMonSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV45TFMonSts_Sels.FromJSonString(AV44TFMonSts_SelsJson, null);
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
         AV20MonDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24MonDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28MonDsc3 = "";
         AV37TFMonDsc_Sel = "";
         AV36TFMonDsc = "";
         AV39TFMonAbr_Sel = "";
         AV38TFMonAbr = "";
         AV43TFMonSunat_Sel = "";
         AV42TFMonSunat = "";
         AV45TFMonSts_Sels = new GxSimpleCollection<short>();
         AV52Configuracion_monedaswwds_1_dynamicfiltersselector1 = "";
         AV54Configuracion_monedaswwds_3_mondsc1 = "";
         AV56Configuracion_monedaswwds_5_dynamicfiltersselector2 = "";
         AV58Configuracion_monedaswwds_7_mondsc2 = "";
         AV60Configuracion_monedaswwds_9_dynamicfiltersselector3 = "";
         AV62Configuracion_monedaswwds_11_mondsc3 = "";
         AV65Configuracion_monedaswwds_14_tfmondsc = "";
         AV66Configuracion_monedaswwds_15_tfmondsc_sel = "";
         AV67Configuracion_monedaswwds_16_tfmonabr = "";
         AV68Configuracion_monedaswwds_17_tfmonabr_sel = "";
         AV69Configuracion_monedaswwds_18_tfmonsunat = "";
         AV70Configuracion_monedaswwds_19_tfmonsunat_sel = "";
         AV71Configuracion_monedaswwds_20_tfmonsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV54Configuracion_monedaswwds_3_mondsc1 = "";
         lV58Configuracion_monedaswwds_7_mondsc2 = "";
         lV62Configuracion_monedaswwds_11_mondsc3 = "";
         lV65Configuracion_monedaswwds_14_tfmondsc = "";
         lV67Configuracion_monedaswwds_16_tfmonabr = "";
         lV69Configuracion_monedaswwds_18_tfmonsunat = "";
         A1234MonDsc = "";
         A1233MonAbr = "";
         A1236MonSunat = "";
         P004D2_A1235MonSts = new short[1] ;
         P004D2_A1236MonSunat = new string[] {""} ;
         P004D2_A1233MonAbr = new string[] {""} ;
         P004D2_A180MonCod = new int[1] ;
         P004D2_A1234MonDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV44TFMonSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.monedaswwexport__default(),
            new Object[][] {
                new Object[] {
               P004D2_A1235MonSts, P004D2_A1236MonSunat, P004D2_A1233MonAbr, P004D2_A180MonCod, P004D2_A1234MonDsc
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
      private short AV46TFMonSts_Sel ;
      private short AV53Configuracion_monedaswwds_2_dynamicfiltersoperator1 ;
      private short AV57Configuracion_monedaswwds_6_dynamicfiltersoperator2 ;
      private short AV61Configuracion_monedaswwds_10_dynamicfiltersoperator3 ;
      private short A1235MonSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFMonCod ;
      private int AV35TFMonCod_To ;
      private int AV50GXV1 ;
      private int AV63Configuracion_monedaswwds_12_tfmoncod ;
      private int AV64Configuracion_monedaswwds_13_tfmoncod_to ;
      private int AV71Configuracion_monedaswwds_20_tfmonsts_sels_Count ;
      private int A180MonCod ;
      private int AV72GXV2 ;
      private long AV47i ;
      private string AV20MonDsc1 ;
      private string AV24MonDsc2 ;
      private string AV28MonDsc3 ;
      private string AV37TFMonDsc_Sel ;
      private string AV36TFMonDsc ;
      private string AV39TFMonAbr_Sel ;
      private string AV38TFMonAbr ;
      private string AV54Configuracion_monedaswwds_3_mondsc1 ;
      private string AV58Configuracion_monedaswwds_7_mondsc2 ;
      private string AV62Configuracion_monedaswwds_11_mondsc3 ;
      private string AV65Configuracion_monedaswwds_14_tfmondsc ;
      private string AV66Configuracion_monedaswwds_15_tfmondsc_sel ;
      private string AV67Configuracion_monedaswwds_16_tfmonabr ;
      private string AV68Configuracion_monedaswwds_17_tfmonabr_sel ;
      private string scmdbuf ;
      private string lV54Configuracion_monedaswwds_3_mondsc1 ;
      private string lV58Configuracion_monedaswwds_7_mondsc2 ;
      private string lV62Configuracion_monedaswwds_11_mondsc3 ;
      private string lV65Configuracion_monedaswwds_14_tfmondsc ;
      private string lV67Configuracion_monedaswwds_16_tfmonabr ;
      private string A1234MonDsc ;
      private string A1233MonAbr ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV55Configuracion_monedaswwds_4_dynamicfiltersenabled2 ;
      private bool AV59Configuracion_monedaswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV44TFMonSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV43TFMonSunat_Sel ;
      private string AV42TFMonSunat ;
      private string AV52Configuracion_monedaswwds_1_dynamicfiltersselector1 ;
      private string AV56Configuracion_monedaswwds_5_dynamicfiltersselector2 ;
      private string AV60Configuracion_monedaswwds_9_dynamicfiltersselector3 ;
      private string AV69Configuracion_monedaswwds_18_tfmonsunat ;
      private string AV70Configuracion_monedaswwds_19_tfmonsunat_sel ;
      private string lV69Configuracion_monedaswwds_18_tfmonsunat ;
      private string A1236MonSunat ;
      private GxSimpleCollection<short> AV45TFMonSts_Sels ;
      private GxSimpleCollection<short> AV71Configuracion_monedaswwds_20_tfmonsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P004D2_A1235MonSts ;
      private string[] P004D2_A1236MonSunat ;
      private string[] P004D2_A1233MonAbr ;
      private int[] P004D2_A180MonCod ;
      private string[] P004D2_A1234MonDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class monedaswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004D2( IGxContext context ,
                                             short A1235MonSts ,
                                             GxSimpleCollection<short> AV71Configuracion_monedaswwds_20_tfmonsts_sels ,
                                             string AV52Configuracion_monedaswwds_1_dynamicfiltersselector1 ,
                                             short AV53Configuracion_monedaswwds_2_dynamicfiltersoperator1 ,
                                             string AV54Configuracion_monedaswwds_3_mondsc1 ,
                                             bool AV55Configuracion_monedaswwds_4_dynamicfiltersenabled2 ,
                                             string AV56Configuracion_monedaswwds_5_dynamicfiltersselector2 ,
                                             short AV57Configuracion_monedaswwds_6_dynamicfiltersoperator2 ,
                                             string AV58Configuracion_monedaswwds_7_mondsc2 ,
                                             bool AV59Configuracion_monedaswwds_8_dynamicfiltersenabled3 ,
                                             string AV60Configuracion_monedaswwds_9_dynamicfiltersselector3 ,
                                             short AV61Configuracion_monedaswwds_10_dynamicfiltersoperator3 ,
                                             string AV62Configuracion_monedaswwds_11_mondsc3 ,
                                             int AV63Configuracion_monedaswwds_12_tfmoncod ,
                                             int AV64Configuracion_monedaswwds_13_tfmoncod_to ,
                                             string AV66Configuracion_monedaswwds_15_tfmondsc_sel ,
                                             string AV65Configuracion_monedaswwds_14_tfmondsc ,
                                             string AV68Configuracion_monedaswwds_17_tfmonabr_sel ,
                                             string AV67Configuracion_monedaswwds_16_tfmonabr ,
                                             string AV70Configuracion_monedaswwds_19_tfmonsunat_sel ,
                                             string AV69Configuracion_monedaswwds_18_tfmonsunat ,
                                             int AV71Configuracion_monedaswwds_20_tfmonsts_sels_Count ,
                                             string A1234MonDsc ,
                                             int A180MonCod ,
                                             string A1233MonAbr ,
                                             string A1236MonSunat ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [MonSts], [MonSunat], [MonAbr], [MonCod], [MonDsc] FROM [CMONEDAS]";
         if ( ( StringUtil.StrCmp(AV52Configuracion_monedaswwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV53Configuracion_monedaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_monedaswwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV54Configuracion_monedaswwds_3_mondsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Configuracion_monedaswwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV53Configuracion_monedaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_monedaswwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV54Configuracion_monedaswwds_3_mondsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV55Configuracion_monedaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Configuracion_monedaswwds_5_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV57Configuracion_monedaswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_monedaswwds_7_mondsc2)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV58Configuracion_monedaswwds_7_mondsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV55Configuracion_monedaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Configuracion_monedaswwds_5_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV57Configuracion_monedaswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_monedaswwds_7_mondsc2)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV58Configuracion_monedaswwds_7_mondsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV59Configuracion_monedaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Configuracion_monedaswwds_9_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV61Configuracion_monedaswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_monedaswwds_11_mondsc3)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV62Configuracion_monedaswwds_11_mondsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV59Configuracion_monedaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Configuracion_monedaswwds_9_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV61Configuracion_monedaswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_monedaswwds_11_mondsc3)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV62Configuracion_monedaswwds_11_mondsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV63Configuracion_monedaswwds_12_tfmoncod) )
         {
            AddWhere(sWhereString, "([MonCod] >= @AV63Configuracion_monedaswwds_12_tfmoncod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV64Configuracion_monedaswwds_13_tfmoncod_to) )
         {
            AddWhere(sWhereString, "([MonCod] <= @AV64Configuracion_monedaswwds_13_tfmoncod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_monedaswwds_15_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_monedaswwds_14_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV65Configuracion_monedaswwds_14_tfmondsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_monedaswwds_15_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "([MonDsc] = @AV66Configuracion_monedaswwds_15_tfmondsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_monedaswwds_17_tfmonabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_monedaswwds_16_tfmonabr)) ) )
         {
            AddWhere(sWhereString, "([MonAbr] like @lV67Configuracion_monedaswwds_16_tfmonabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_monedaswwds_17_tfmonabr_sel)) )
         {
            AddWhere(sWhereString, "([MonAbr] = @AV68Configuracion_monedaswwds_17_tfmonabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_monedaswwds_19_tfmonsunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_monedaswwds_18_tfmonsunat)) ) )
         {
            AddWhere(sWhereString, "([MonSunat] like @lV69Configuracion_monedaswwds_18_tfmonsunat)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_monedaswwds_19_tfmonsunat_sel)) )
         {
            AddWhere(sWhereString, "([MonSunat] = @AV70Configuracion_monedaswwds_19_tfmonsunat_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV71Configuracion_monedaswwds_20_tfmonsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71Configuracion_monedaswwds_20_tfmonsts_sels, "[MonSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MonCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MonCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MonDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MonDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MonAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MonAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MonSunat]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MonSunat] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MonSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MonSts] DESC";
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
                     return conditional_P004D2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP004D2;
          prmP004D2 = new Object[] {
          new ParDef("@lV54Configuracion_monedaswwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV54Configuracion_monedaswwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_monedaswwds_7_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_monedaswwds_7_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_monedaswwds_11_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_monedaswwds_11_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@AV63Configuracion_monedaswwds_12_tfmoncod",GXType.Int32,6,0) ,
          new ParDef("@AV64Configuracion_monedaswwds_13_tfmoncod_to",GXType.Int32,6,0) ,
          new ParDef("@lV65Configuracion_monedaswwds_14_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV66Configuracion_monedaswwds_15_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_monedaswwds_16_tfmonabr",GXType.NChar,5,0) ,
          new ParDef("@AV68Configuracion_monedaswwds_17_tfmonabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV69Configuracion_monedaswwds_18_tfmonsunat",GXType.NVarChar,3,0) ,
          new ParDef("@AV70Configuracion_monedaswwds_19_tfmonsunat_sel",GXType.NVarChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004D2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
