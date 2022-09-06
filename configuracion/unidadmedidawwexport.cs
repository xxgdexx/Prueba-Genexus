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
   public class unidadmedidawwexport : GXProcedure
   {
      public unidadmedidawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public unidadmedidawwexport( IGxContext context )
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
         unidadmedidawwexport objunidadmedidawwexport;
         objunidadmedidawwexport = new unidadmedidawwexport();
         objunidadmedidawwexport.AV11Filename = "" ;
         objunidadmedidawwexport.AV12ErrorMessage = "" ;
         objunidadmedidawwexport.context.SetSubmitInitialConfig(context);
         objunidadmedidawwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objunidadmedidawwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((unidadmedidawwexport)stateInfo).executePrivate();
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
         AV11Filename = "UnidadMedidaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "UNIDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20UniDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20UniDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Unidad de Medida", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Unidad de Medida", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20UniDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "UNIDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24UniDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24UniDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Unidad de Medida", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Unidad de Medida", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24UniDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "UNIDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28UniDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28UniDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Unidad de Medida", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Unidad de Medida", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28UniDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFUniCod) && (0==AV35TFUniCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFUniCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFUniCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFUniDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Unidad Medida") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFUniDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFUniDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Unidad Medida") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFUniDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFUniAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFUniAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFUniAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFUniAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFUniSunat_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sunat") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFUniSunat_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFUniSunat)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sunat") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFUniSunat, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV43TFUniSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV45i = 1;
            AV48GXV1 = 1;
            while ( AV48GXV1 <= AV43TFUniSts_Sels.Count )
            {
               AV44TFUniSts_Sel = (short)(AV43TFUniSts_Sels.GetNumeric(AV48GXV1));
               if ( AV45i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV44TFUniSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV44TFUniSts_Sel == 0 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Unidad Medida";
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
         AV50Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV51Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV52Configuracion_unidadmedidawwds_3_unidsc1 = AV20UniDsc1;
         AV53Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV54Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV55Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV56Configuracion_unidadmedidawwds_7_unidsc2 = AV24UniDsc2;
         AV57Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV58Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV59Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV60Configuracion_unidadmedidawwds_11_unidsc3 = AV28UniDsc3;
         AV61Configuracion_unidadmedidawwds_12_tfunicod = AV34TFUniCod;
         AV62Configuracion_unidadmedidawwds_13_tfunicod_to = AV35TFUniCod_To;
         AV63Configuracion_unidadmedidawwds_14_tfunidsc = AV36TFUniDsc;
         AV64Configuracion_unidadmedidawwds_15_tfunidsc_sel = AV37TFUniDsc_Sel;
         AV65Configuracion_unidadmedidawwds_16_tfuniabr = AV38TFUniAbr;
         AV66Configuracion_unidadmedidawwds_17_tfuniabr_sel = AV39TFUniAbr_Sel;
         AV67Configuracion_unidadmedidawwds_18_tfunisunat = AV40TFUniSunat;
         AV68Configuracion_unidadmedidawwds_19_tfunisunat_sel = AV41TFUniSunat_Sel;
         AV69Configuracion_unidadmedidawwds_20_tfunists_sels = AV43TFUniSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1999UniSts ,
                                              AV69Configuracion_unidadmedidawwds_20_tfunists_sels ,
                                              AV50Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 ,
                                              AV51Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 ,
                                              AV52Configuracion_unidadmedidawwds_3_unidsc1 ,
                                              AV53Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 ,
                                              AV54Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 ,
                                              AV55Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 ,
                                              AV56Configuracion_unidadmedidawwds_7_unidsc2 ,
                                              AV57Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 ,
                                              AV58Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 ,
                                              AV59Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 ,
                                              AV60Configuracion_unidadmedidawwds_11_unidsc3 ,
                                              AV61Configuracion_unidadmedidawwds_12_tfunicod ,
                                              AV62Configuracion_unidadmedidawwds_13_tfunicod_to ,
                                              AV64Configuracion_unidadmedidawwds_15_tfunidsc_sel ,
                                              AV63Configuracion_unidadmedidawwds_14_tfunidsc ,
                                              AV66Configuracion_unidadmedidawwds_17_tfuniabr_sel ,
                                              AV65Configuracion_unidadmedidawwds_16_tfuniabr ,
                                              AV68Configuracion_unidadmedidawwds_19_tfunisunat_sel ,
                                              AV67Configuracion_unidadmedidawwds_18_tfunisunat ,
                                              AV69Configuracion_unidadmedidawwds_20_tfunists_sels.Count ,
                                              A1998UniDsc ,
                                              A49UniCod ,
                                              A1997UniAbr ,
                                              A2000UniSunat ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Configuracion_unidadmedidawwds_3_unidsc1 = StringUtil.PadR( StringUtil.RTrim( AV52Configuracion_unidadmedidawwds_3_unidsc1), 100, "%");
         lV52Configuracion_unidadmedidawwds_3_unidsc1 = StringUtil.PadR( StringUtil.RTrim( AV52Configuracion_unidadmedidawwds_3_unidsc1), 100, "%");
         lV56Configuracion_unidadmedidawwds_7_unidsc2 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_unidadmedidawwds_7_unidsc2), 100, "%");
         lV56Configuracion_unidadmedidawwds_7_unidsc2 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_unidadmedidawwds_7_unidsc2), 100, "%");
         lV60Configuracion_unidadmedidawwds_11_unidsc3 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_unidadmedidawwds_11_unidsc3), 100, "%");
         lV60Configuracion_unidadmedidawwds_11_unidsc3 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_unidadmedidawwds_11_unidsc3), 100, "%");
         lV63Configuracion_unidadmedidawwds_14_tfunidsc = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_unidadmedidawwds_14_tfunidsc), 100, "%");
         lV65Configuracion_unidadmedidawwds_16_tfuniabr = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_unidadmedidawwds_16_tfuniabr), 5, "%");
         lV67Configuracion_unidadmedidawwds_18_tfunisunat = StringUtil.Concat( StringUtil.RTrim( AV67Configuracion_unidadmedidawwds_18_tfunisunat), "%", "");
         /* Using cursor P002Q2 */
         pr_default.execute(0, new Object[] {lV52Configuracion_unidadmedidawwds_3_unidsc1, lV52Configuracion_unidadmedidawwds_3_unidsc1, lV56Configuracion_unidadmedidawwds_7_unidsc2, lV56Configuracion_unidadmedidawwds_7_unidsc2, lV60Configuracion_unidadmedidawwds_11_unidsc3, lV60Configuracion_unidadmedidawwds_11_unidsc3, AV61Configuracion_unidadmedidawwds_12_tfunicod, AV62Configuracion_unidadmedidawwds_13_tfunicod_to, lV63Configuracion_unidadmedidawwds_14_tfunidsc, AV64Configuracion_unidadmedidawwds_15_tfunidsc_sel, lV65Configuracion_unidadmedidawwds_16_tfuniabr, AV66Configuracion_unidadmedidawwds_17_tfuniabr_sel, lV67Configuracion_unidadmedidawwds_18_tfunisunat, AV68Configuracion_unidadmedidawwds_19_tfunisunat_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1999UniSts = P002Q2_A1999UniSts[0];
            A2000UniSunat = P002Q2_A2000UniSunat[0];
            A1997UniAbr = P002Q2_A1997UniAbr[0];
            A49UniCod = P002Q2_A49UniCod[0];
            A1998UniDsc = P002Q2_A1998UniDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A49UniCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1998UniDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1997UniAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2000UniSunat, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A1999UniSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "ACTIVO";
            }
            else if ( A1999UniSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.UnidadMedidaWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.UnidadMedidaWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.UnidadMedidaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV70GXV2 = 1;
         while ( AV70GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV70GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUNICOD") == 0 )
            {
               AV34TFUniCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFUniCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUNIDSC") == 0 )
            {
               AV36TFUniDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUNIDSC_SEL") == 0 )
            {
               AV37TFUniDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUNIABR") == 0 )
            {
               AV38TFUniAbr = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUNIABR_SEL") == 0 )
            {
               AV39TFUniAbr_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUNISUNAT") == 0 )
            {
               AV40TFUniSunat = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUNISUNAT_SEL") == 0 )
            {
               AV41TFUniSunat_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUNISTS_SEL") == 0 )
            {
               AV42TFUniSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV43TFUniSts_Sels.FromJSonString(AV42TFUniSts_SelsJson, null);
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
         AV20UniDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24UniDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28UniDsc3 = "";
         AV37TFUniDsc_Sel = "";
         AV36TFUniDsc = "";
         AV39TFUniAbr_Sel = "";
         AV38TFUniAbr = "";
         AV41TFUniSunat_Sel = "";
         AV40TFUniSunat = "";
         AV43TFUniSts_Sels = new GxSimpleCollection<short>();
         AV50Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 = "";
         AV52Configuracion_unidadmedidawwds_3_unidsc1 = "";
         AV54Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 = "";
         AV56Configuracion_unidadmedidawwds_7_unidsc2 = "";
         AV58Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 = "";
         AV60Configuracion_unidadmedidawwds_11_unidsc3 = "";
         AV63Configuracion_unidadmedidawwds_14_tfunidsc = "";
         AV64Configuracion_unidadmedidawwds_15_tfunidsc_sel = "";
         AV65Configuracion_unidadmedidawwds_16_tfuniabr = "";
         AV66Configuracion_unidadmedidawwds_17_tfuniabr_sel = "";
         AV67Configuracion_unidadmedidawwds_18_tfunisunat = "";
         AV68Configuracion_unidadmedidawwds_19_tfunisunat_sel = "";
         AV69Configuracion_unidadmedidawwds_20_tfunists_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV52Configuracion_unidadmedidawwds_3_unidsc1 = "";
         lV56Configuracion_unidadmedidawwds_7_unidsc2 = "";
         lV60Configuracion_unidadmedidawwds_11_unidsc3 = "";
         lV63Configuracion_unidadmedidawwds_14_tfunidsc = "";
         lV65Configuracion_unidadmedidawwds_16_tfuniabr = "";
         lV67Configuracion_unidadmedidawwds_18_tfunisunat = "";
         A1998UniDsc = "";
         A1997UniAbr = "";
         A2000UniSunat = "";
         P002Q2_A1999UniSts = new short[1] ;
         P002Q2_A2000UniSunat = new string[] {""} ;
         P002Q2_A1997UniAbr = new string[] {""} ;
         P002Q2_A49UniCod = new int[1] ;
         P002Q2_A1998UniDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV42TFUniSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.unidadmedidawwexport__default(),
            new Object[][] {
                new Object[] {
               P002Q2_A1999UniSts, P002Q2_A2000UniSunat, P002Q2_A1997UniAbr, P002Q2_A49UniCod, P002Q2_A1998UniDsc
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
      private short AV44TFUniSts_Sel ;
      private short AV51Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 ;
      private short AV55Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 ;
      private short AV59Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 ;
      private short A1999UniSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFUniCod ;
      private int AV35TFUniCod_To ;
      private int AV48GXV1 ;
      private int AV61Configuracion_unidadmedidawwds_12_tfunicod ;
      private int AV62Configuracion_unidadmedidawwds_13_tfunicod_to ;
      private int AV69Configuracion_unidadmedidawwds_20_tfunists_sels_Count ;
      private int A49UniCod ;
      private int AV70GXV2 ;
      private long AV45i ;
      private string AV20UniDsc1 ;
      private string AV24UniDsc2 ;
      private string AV28UniDsc3 ;
      private string AV37TFUniDsc_Sel ;
      private string AV36TFUniDsc ;
      private string AV39TFUniAbr_Sel ;
      private string AV38TFUniAbr ;
      private string AV52Configuracion_unidadmedidawwds_3_unidsc1 ;
      private string AV56Configuracion_unidadmedidawwds_7_unidsc2 ;
      private string AV60Configuracion_unidadmedidawwds_11_unidsc3 ;
      private string AV63Configuracion_unidadmedidawwds_14_tfunidsc ;
      private string AV64Configuracion_unidadmedidawwds_15_tfunidsc_sel ;
      private string AV65Configuracion_unidadmedidawwds_16_tfuniabr ;
      private string AV66Configuracion_unidadmedidawwds_17_tfuniabr_sel ;
      private string scmdbuf ;
      private string lV52Configuracion_unidadmedidawwds_3_unidsc1 ;
      private string lV56Configuracion_unidadmedidawwds_7_unidsc2 ;
      private string lV60Configuracion_unidadmedidawwds_11_unidsc3 ;
      private string lV63Configuracion_unidadmedidawwds_14_tfunidsc ;
      private string lV65Configuracion_unidadmedidawwds_16_tfuniabr ;
      private string A1998UniDsc ;
      private string A1997UniAbr ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV53Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 ;
      private bool AV57Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV42TFUniSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV41TFUniSunat_Sel ;
      private string AV40TFUniSunat ;
      private string AV50Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 ;
      private string AV54Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 ;
      private string AV58Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 ;
      private string AV67Configuracion_unidadmedidawwds_18_tfunisunat ;
      private string AV68Configuracion_unidadmedidawwds_19_tfunisunat_sel ;
      private string lV67Configuracion_unidadmedidawwds_18_tfunisunat ;
      private string A2000UniSunat ;
      private GxSimpleCollection<short> AV43TFUniSts_Sels ;
      private GxSimpleCollection<short> AV69Configuracion_unidadmedidawwds_20_tfunists_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002Q2_A1999UniSts ;
      private string[] P002Q2_A2000UniSunat ;
      private string[] P002Q2_A1997UniAbr ;
      private int[] P002Q2_A49UniCod ;
      private string[] P002Q2_A1998UniDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class unidadmedidawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002Q2( IGxContext context ,
                                             short A1999UniSts ,
                                             GxSimpleCollection<short> AV69Configuracion_unidadmedidawwds_20_tfunists_sels ,
                                             string AV50Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 ,
                                             short AV51Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 ,
                                             string AV52Configuracion_unidadmedidawwds_3_unidsc1 ,
                                             bool AV53Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 ,
                                             string AV54Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 ,
                                             short AV55Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 ,
                                             string AV56Configuracion_unidadmedidawwds_7_unidsc2 ,
                                             bool AV57Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 ,
                                             string AV58Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 ,
                                             short AV59Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 ,
                                             string AV60Configuracion_unidadmedidawwds_11_unidsc3 ,
                                             int AV61Configuracion_unidadmedidawwds_12_tfunicod ,
                                             int AV62Configuracion_unidadmedidawwds_13_tfunicod_to ,
                                             string AV64Configuracion_unidadmedidawwds_15_tfunidsc_sel ,
                                             string AV63Configuracion_unidadmedidawwds_14_tfunidsc ,
                                             string AV66Configuracion_unidadmedidawwds_17_tfuniabr_sel ,
                                             string AV65Configuracion_unidadmedidawwds_16_tfuniabr ,
                                             string AV68Configuracion_unidadmedidawwds_19_tfunisunat_sel ,
                                             string AV67Configuracion_unidadmedidawwds_18_tfunisunat ,
                                             int AV69Configuracion_unidadmedidawwds_20_tfunists_sels_Count ,
                                             string A1998UniDsc ,
                                             int A49UniCod ,
                                             string A1997UniAbr ,
                                             string A2000UniSunat ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [UniSts], [UniSunat], [UniAbr], [UniCod], [UniDsc] FROM [CUNIDADMEDIDA]";
         if ( ( StringUtil.StrCmp(AV50Configuracion_unidadmedidawwds_1_dynamicfiltersselector1, "UNIDSC") == 0 ) && ( AV51Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracion_unidadmedidawwds_3_unidsc1)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV52Configuracion_unidadmedidawwds_3_unidsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Configuracion_unidadmedidawwds_1_dynamicfiltersselector1, "UNIDSC") == 0 ) && ( AV51Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracion_unidadmedidawwds_3_unidsc1)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV52Configuracion_unidadmedidawwds_3_unidsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV53Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Configuracion_unidadmedidawwds_5_dynamicfiltersselector2, "UNIDSC") == 0 ) && ( AV55Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_unidadmedidawwds_7_unidsc2)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV56Configuracion_unidadmedidawwds_7_unidsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV53Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Configuracion_unidadmedidawwds_5_dynamicfiltersselector2, "UNIDSC") == 0 ) && ( AV55Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_unidadmedidawwds_7_unidsc2)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV56Configuracion_unidadmedidawwds_7_unidsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV57Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Configuracion_unidadmedidawwds_9_dynamicfiltersselector3, "UNIDSC") == 0 ) && ( AV59Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_unidadmedidawwds_11_unidsc3)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV60Configuracion_unidadmedidawwds_11_unidsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV57Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Configuracion_unidadmedidawwds_9_dynamicfiltersselector3, "UNIDSC") == 0 ) && ( AV59Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_unidadmedidawwds_11_unidsc3)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV60Configuracion_unidadmedidawwds_11_unidsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV61Configuracion_unidadmedidawwds_12_tfunicod) )
         {
            AddWhere(sWhereString, "([UniCod] >= @AV61Configuracion_unidadmedidawwds_12_tfunicod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV62Configuracion_unidadmedidawwds_13_tfunicod_to) )
         {
            AddWhere(sWhereString, "([UniCod] <= @AV62Configuracion_unidadmedidawwds_13_tfunicod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_unidadmedidawwds_15_tfunidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_unidadmedidawwds_14_tfunidsc)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV63Configuracion_unidadmedidawwds_14_tfunidsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_unidadmedidawwds_15_tfunidsc_sel)) )
         {
            AddWhere(sWhereString, "([UniDsc] = @AV64Configuracion_unidadmedidawwds_15_tfunidsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_unidadmedidawwds_17_tfuniabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_unidadmedidawwds_16_tfuniabr)) ) )
         {
            AddWhere(sWhereString, "([UniAbr] like @lV65Configuracion_unidadmedidawwds_16_tfuniabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_unidadmedidawwds_17_tfuniabr_sel)) )
         {
            AddWhere(sWhereString, "([UniAbr] = @AV66Configuracion_unidadmedidawwds_17_tfuniabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_unidadmedidawwds_19_tfunisunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_unidadmedidawwds_18_tfunisunat)) ) )
         {
            AddWhere(sWhereString, "([UniSunat] like @lV67Configuracion_unidadmedidawwds_18_tfunisunat)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_unidadmedidawwds_19_tfunisunat_sel)) )
         {
            AddWhere(sWhereString, "([UniSunat] = @AV68Configuracion_unidadmedidawwds_19_tfunisunat_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV69Configuracion_unidadmedidawwds_20_tfunists_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV69Configuracion_unidadmedidawwds_20_tfunists_sels, "[UniSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [UniCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [UniCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [UniDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [UniDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [UniAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [UniAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [UniSunat]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [UniSunat] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [UniSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [UniSts] DESC";
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
                     return conditional_P002Q2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP002Q2;
          prmP002Q2 = new Object[] {
          new ParDef("@lV52Configuracion_unidadmedidawwds_3_unidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV52Configuracion_unidadmedidawwds_3_unidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV56Configuracion_unidadmedidawwds_7_unidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV56Configuracion_unidadmedidawwds_7_unidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV60Configuracion_unidadmedidawwds_11_unidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV60Configuracion_unidadmedidawwds_11_unidsc3",GXType.NChar,100,0) ,
          new ParDef("@AV61Configuracion_unidadmedidawwds_12_tfunicod",GXType.Int32,6,0) ,
          new ParDef("@AV62Configuracion_unidadmedidawwds_13_tfunicod_to",GXType.Int32,6,0) ,
          new ParDef("@lV63Configuracion_unidadmedidawwds_14_tfunidsc",GXType.NChar,100,0) ,
          new ParDef("@AV64Configuracion_unidadmedidawwds_15_tfunidsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_unidadmedidawwds_16_tfuniabr",GXType.NChar,5,0) ,
          new ParDef("@AV66Configuracion_unidadmedidawwds_17_tfuniabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV67Configuracion_unidadmedidawwds_18_tfunisunat",GXType.NVarChar,5,0) ,
          new ParDef("@AV68Configuracion_unidadmedidawwds_19_tfunisunat_sel",GXType.NVarChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Q2,100, GxCacheFrequency.OFF ,true,false )
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
