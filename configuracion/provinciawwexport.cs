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
   public class provinciawwexport : GXProcedure
   {
      public provinciawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public provinciawwexport( IGxContext context )
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
         provinciawwexport objprovinciawwexport;
         objprovinciawwexport = new provinciawwexport();
         objprovinciawwexport.AV11Filename = "" ;
         objprovinciawwexport.AV12ErrorMessage = "" ;
         objprovinciawwexport.context.SetSubmitInitialConfig(context);
         objprovinciawwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprovinciawwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((provinciawwexport)stateInfo).executePrivate();
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
         AV11Filename = "ProvinciaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROVDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20ProvDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ProvDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Provincia", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Provincia", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20ProvDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROVDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24ProvDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ProvDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Provincia", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Provincia", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24ProvDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PROVDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28ProvDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ProvDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Provincia", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Provincia", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ProvDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFProvCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFProvCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFProvCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFProvCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFProvDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Provincia") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFProvDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProvDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Provincia") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFProvDsc, out  GXt_char1) ;
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
         if ( ! ( ( AV45TFProvSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV47i = 1;
            AV50GXV1 = 1;
            while ( AV50GXV1 <= AV45TFProvSts_Sels.Count )
            {
               AV46TFProvSts_Sel = (short)(AV45TFProvSts_Sels.GetNumeric(AV50GXV1));
               if ( AV47i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV46TFProvSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV46TFProvSts_Sel == 0 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Provincia";
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
         AV52Configuracion_provinciawwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV53Configuracion_provinciawwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV54Configuracion_provinciawwds_3_provdsc1 = AV20ProvDsc1;
         AV55Configuracion_provinciawwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV56Configuracion_provinciawwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV57Configuracion_provinciawwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV58Configuracion_provinciawwds_7_provdsc2 = AV24ProvDsc2;
         AV59Configuracion_provinciawwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV60Configuracion_provinciawwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV61Configuracion_provinciawwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV62Configuracion_provinciawwds_11_provdsc3 = AV28ProvDsc3;
         AV63Configuracion_provinciawwds_12_tfprovcod = AV36TFProvCod;
         AV64Configuracion_provinciawwds_13_tfprovcod_sel = AV37TFProvCod_Sel;
         AV65Configuracion_provinciawwds_14_tfprovdsc = AV38TFProvDsc;
         AV66Configuracion_provinciawwds_15_tfprovdsc_sel = AV39TFProvDsc_Sel;
         AV67Configuracion_provinciawwds_16_tfpaidsc = AV40TFPaiDsc;
         AV68Configuracion_provinciawwds_17_tfpaidsc_sel = AV41TFPaiDsc_Sel;
         AV69Configuracion_provinciawwds_18_tfprovsts_sels = AV45TFProvSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1742ProvSts ,
                                              AV69Configuracion_provinciawwds_18_tfprovsts_sels ,
                                              AV52Configuracion_provinciawwds_1_dynamicfiltersselector1 ,
                                              AV53Configuracion_provinciawwds_2_dynamicfiltersoperator1 ,
                                              AV54Configuracion_provinciawwds_3_provdsc1 ,
                                              AV55Configuracion_provinciawwds_4_dynamicfiltersenabled2 ,
                                              AV56Configuracion_provinciawwds_5_dynamicfiltersselector2 ,
                                              AV57Configuracion_provinciawwds_6_dynamicfiltersoperator2 ,
                                              AV58Configuracion_provinciawwds_7_provdsc2 ,
                                              AV59Configuracion_provinciawwds_8_dynamicfiltersenabled3 ,
                                              AV60Configuracion_provinciawwds_9_dynamicfiltersselector3 ,
                                              AV61Configuracion_provinciawwds_10_dynamicfiltersoperator3 ,
                                              AV62Configuracion_provinciawwds_11_provdsc3 ,
                                              AV64Configuracion_provinciawwds_13_tfprovcod_sel ,
                                              AV63Configuracion_provinciawwds_12_tfprovcod ,
                                              AV66Configuracion_provinciawwds_15_tfprovdsc_sel ,
                                              AV65Configuracion_provinciawwds_14_tfprovdsc ,
                                              AV68Configuracion_provinciawwds_17_tfpaidsc_sel ,
                                              AV67Configuracion_provinciawwds_16_tfpaidsc ,
                                              AV69Configuracion_provinciawwds_18_tfprovsts_sels.Count ,
                                              A603ProvDsc ,
                                              A141ProvCod ,
                                              A1500PaiDsc ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Configuracion_provinciawwds_3_provdsc1 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_provinciawwds_3_provdsc1), 100, "%");
         lV54Configuracion_provinciawwds_3_provdsc1 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_provinciawwds_3_provdsc1), 100, "%");
         lV58Configuracion_provinciawwds_7_provdsc2 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_provinciawwds_7_provdsc2), 100, "%");
         lV58Configuracion_provinciawwds_7_provdsc2 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_provinciawwds_7_provdsc2), 100, "%");
         lV62Configuracion_provinciawwds_11_provdsc3 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_provinciawwds_11_provdsc3), 100, "%");
         lV62Configuracion_provinciawwds_11_provdsc3 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_provinciawwds_11_provdsc3), 100, "%");
         lV63Configuracion_provinciawwds_12_tfprovcod = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_provinciawwds_12_tfprovcod), 4, "%");
         lV65Configuracion_provinciawwds_14_tfprovdsc = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_provinciawwds_14_tfprovdsc), 100, "%");
         lV67Configuracion_provinciawwds_16_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_provinciawwds_16_tfpaidsc), 100, "%");
         /* Using cursor P003T2 */
         pr_default.execute(0, new Object[] {lV54Configuracion_provinciawwds_3_provdsc1, lV54Configuracion_provinciawwds_3_provdsc1, lV58Configuracion_provinciawwds_7_provdsc2, lV58Configuracion_provinciawwds_7_provdsc2, lV62Configuracion_provinciawwds_11_provdsc3, lV62Configuracion_provinciawwds_11_provdsc3, lV63Configuracion_provinciawwds_12_tfprovcod, AV64Configuracion_provinciawwds_13_tfprovcod_sel, lV65Configuracion_provinciawwds_14_tfprovdsc, AV66Configuracion_provinciawwds_15_tfprovdsc_sel, lV67Configuracion_provinciawwds_16_tfpaidsc, AV68Configuracion_provinciawwds_17_tfpaidsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1742ProvSts = P003T2_A1742ProvSts[0];
            A1500PaiDsc = P003T2_A1500PaiDsc[0];
            A141ProvCod = P003T2_A141ProvCod[0];
            A603ProvDsc = P003T2_A603ProvDsc[0];
            A139PaiCod = P003T2_A139PaiCod[0];
            A140EstCod = P003T2_A140EstCod[0];
            A1500PaiDsc = P003T2_A1500PaiDsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A141ProvCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A603ProvDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1500PaiDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A1742ProvSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "ACTIVO";
            }
            else if ( A1742ProvSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.ProvinciaWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.ProvinciaWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.ProvinciaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV70GXV2 = 1;
         while ( AV70GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV70GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROVCOD") == 0 )
            {
               AV36TFProvCod = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROVCOD_SEL") == 0 )
            {
               AV37TFProvCod_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROVDSC") == 0 )
            {
               AV38TFProvDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROVDSC_SEL") == 0 )
            {
               AV39TFProvDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAIDSC") == 0 )
            {
               AV40TFPaiDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAIDSC_SEL") == 0 )
            {
               AV41TFPaiDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROVSTS_SEL") == 0 )
            {
               AV44TFProvSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV45TFProvSts_Sels.FromJSonString(AV44TFProvSts_SelsJson, null);
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
         AV20ProvDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24ProvDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28ProvDsc3 = "";
         AV37TFProvCod_Sel = "";
         AV36TFProvCod = "";
         AV39TFProvDsc_Sel = "";
         AV38TFProvDsc = "";
         AV41TFPaiDsc_Sel = "";
         AV40TFPaiDsc = "";
         AV45TFProvSts_Sels = new GxSimpleCollection<short>();
         AV52Configuracion_provinciawwds_1_dynamicfiltersselector1 = "";
         AV54Configuracion_provinciawwds_3_provdsc1 = "";
         AV56Configuracion_provinciawwds_5_dynamicfiltersselector2 = "";
         AV58Configuracion_provinciawwds_7_provdsc2 = "";
         AV60Configuracion_provinciawwds_9_dynamicfiltersselector3 = "";
         AV62Configuracion_provinciawwds_11_provdsc3 = "";
         AV63Configuracion_provinciawwds_12_tfprovcod = "";
         AV64Configuracion_provinciawwds_13_tfprovcod_sel = "";
         AV65Configuracion_provinciawwds_14_tfprovdsc = "";
         AV66Configuracion_provinciawwds_15_tfprovdsc_sel = "";
         AV67Configuracion_provinciawwds_16_tfpaidsc = "";
         AV68Configuracion_provinciawwds_17_tfpaidsc_sel = "";
         AV69Configuracion_provinciawwds_18_tfprovsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV54Configuracion_provinciawwds_3_provdsc1 = "";
         lV58Configuracion_provinciawwds_7_provdsc2 = "";
         lV62Configuracion_provinciawwds_11_provdsc3 = "";
         lV63Configuracion_provinciawwds_12_tfprovcod = "";
         lV65Configuracion_provinciawwds_14_tfprovdsc = "";
         lV67Configuracion_provinciawwds_16_tfpaidsc = "";
         A603ProvDsc = "";
         A141ProvCod = "";
         A1500PaiDsc = "";
         P003T2_A1742ProvSts = new short[1] ;
         P003T2_A1500PaiDsc = new string[] {""} ;
         P003T2_A141ProvCod = new string[] {""} ;
         P003T2_A603ProvDsc = new string[] {""} ;
         P003T2_A139PaiCod = new string[] {""} ;
         P003T2_A140EstCod = new string[] {""} ;
         A139PaiCod = "";
         A140EstCod = "";
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV44TFProvSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.provinciawwexport__default(),
            new Object[][] {
                new Object[] {
               P003T2_A1742ProvSts, P003T2_A1500PaiDsc, P003T2_A141ProvCod, P003T2_A603ProvDsc, P003T2_A139PaiCod, P003T2_A140EstCod
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
      private short AV46TFProvSts_Sel ;
      private short AV53Configuracion_provinciawwds_2_dynamicfiltersoperator1 ;
      private short AV57Configuracion_provinciawwds_6_dynamicfiltersoperator2 ;
      private short AV61Configuracion_provinciawwds_10_dynamicfiltersoperator3 ;
      private short A1742ProvSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV50GXV1 ;
      private int AV69Configuracion_provinciawwds_18_tfprovsts_sels_Count ;
      private int AV70GXV2 ;
      private long AV47i ;
      private string AV20ProvDsc1 ;
      private string AV24ProvDsc2 ;
      private string AV28ProvDsc3 ;
      private string AV37TFProvCod_Sel ;
      private string AV36TFProvCod ;
      private string AV39TFProvDsc_Sel ;
      private string AV38TFProvDsc ;
      private string AV41TFPaiDsc_Sel ;
      private string AV40TFPaiDsc ;
      private string AV54Configuracion_provinciawwds_3_provdsc1 ;
      private string AV58Configuracion_provinciawwds_7_provdsc2 ;
      private string AV62Configuracion_provinciawwds_11_provdsc3 ;
      private string AV63Configuracion_provinciawwds_12_tfprovcod ;
      private string AV64Configuracion_provinciawwds_13_tfprovcod_sel ;
      private string AV65Configuracion_provinciawwds_14_tfprovdsc ;
      private string AV66Configuracion_provinciawwds_15_tfprovdsc_sel ;
      private string AV67Configuracion_provinciawwds_16_tfpaidsc ;
      private string AV68Configuracion_provinciawwds_17_tfpaidsc_sel ;
      private string scmdbuf ;
      private string lV54Configuracion_provinciawwds_3_provdsc1 ;
      private string lV58Configuracion_provinciawwds_7_provdsc2 ;
      private string lV62Configuracion_provinciawwds_11_provdsc3 ;
      private string lV63Configuracion_provinciawwds_12_tfprovcod ;
      private string lV65Configuracion_provinciawwds_14_tfprovdsc ;
      private string lV67Configuracion_provinciawwds_16_tfpaidsc ;
      private string A603ProvDsc ;
      private string A141ProvCod ;
      private string A1500PaiDsc ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV55Configuracion_provinciawwds_4_dynamicfiltersenabled2 ;
      private bool AV59Configuracion_provinciawwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV44TFProvSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV52Configuracion_provinciawwds_1_dynamicfiltersselector1 ;
      private string AV56Configuracion_provinciawwds_5_dynamicfiltersselector2 ;
      private string AV60Configuracion_provinciawwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV45TFProvSts_Sels ;
      private GxSimpleCollection<short> AV69Configuracion_provinciawwds_18_tfprovsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003T2_A1742ProvSts ;
      private string[] P003T2_A1500PaiDsc ;
      private string[] P003T2_A141ProvCod ;
      private string[] P003T2_A603ProvDsc ;
      private string[] P003T2_A139PaiCod ;
      private string[] P003T2_A140EstCod ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class provinciawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003T2( IGxContext context ,
                                             short A1742ProvSts ,
                                             GxSimpleCollection<short> AV69Configuracion_provinciawwds_18_tfprovsts_sels ,
                                             string AV52Configuracion_provinciawwds_1_dynamicfiltersselector1 ,
                                             short AV53Configuracion_provinciawwds_2_dynamicfiltersoperator1 ,
                                             string AV54Configuracion_provinciawwds_3_provdsc1 ,
                                             bool AV55Configuracion_provinciawwds_4_dynamicfiltersenabled2 ,
                                             string AV56Configuracion_provinciawwds_5_dynamicfiltersselector2 ,
                                             short AV57Configuracion_provinciawwds_6_dynamicfiltersoperator2 ,
                                             string AV58Configuracion_provinciawwds_7_provdsc2 ,
                                             bool AV59Configuracion_provinciawwds_8_dynamicfiltersenabled3 ,
                                             string AV60Configuracion_provinciawwds_9_dynamicfiltersselector3 ,
                                             short AV61Configuracion_provinciawwds_10_dynamicfiltersoperator3 ,
                                             string AV62Configuracion_provinciawwds_11_provdsc3 ,
                                             string AV64Configuracion_provinciawwds_13_tfprovcod_sel ,
                                             string AV63Configuracion_provinciawwds_12_tfprovcod ,
                                             string AV66Configuracion_provinciawwds_15_tfprovdsc_sel ,
                                             string AV65Configuracion_provinciawwds_14_tfprovdsc ,
                                             string AV68Configuracion_provinciawwds_17_tfpaidsc_sel ,
                                             string AV67Configuracion_provinciawwds_16_tfpaidsc ,
                                             int AV69Configuracion_provinciawwds_18_tfprovsts_sels_Count ,
                                             string A603ProvDsc ,
                                             string A141ProvCod ,
                                             string A1500PaiDsc ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[ProvSts], T2.[PaiDsc], T1.[ProvCod], T1.[ProvDsc], T1.[PaiCod], T1.[EstCod] FROM ([CPROVINCIA] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV52Configuracion_provinciawwds_1_dynamicfiltersselector1, "PROVDSC") == 0 ) && ( AV53Configuracion_provinciawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_provinciawwds_3_provdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV54Configuracion_provinciawwds_3_provdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Configuracion_provinciawwds_1_dynamicfiltersselector1, "PROVDSC") == 0 ) && ( AV53Configuracion_provinciawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_provinciawwds_3_provdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV54Configuracion_provinciawwds_3_provdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV55Configuracion_provinciawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Configuracion_provinciawwds_5_dynamicfiltersselector2, "PROVDSC") == 0 ) && ( AV57Configuracion_provinciawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_provinciawwds_7_provdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV58Configuracion_provinciawwds_7_provdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV55Configuracion_provinciawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Configuracion_provinciawwds_5_dynamicfiltersselector2, "PROVDSC") == 0 ) && ( AV57Configuracion_provinciawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_provinciawwds_7_provdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV58Configuracion_provinciawwds_7_provdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV59Configuracion_provinciawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Configuracion_provinciawwds_9_dynamicfiltersselector3, "PROVDSC") == 0 ) && ( AV61Configuracion_provinciawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_provinciawwds_11_provdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV62Configuracion_provinciawwds_11_provdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV59Configuracion_provinciawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Configuracion_provinciawwds_9_dynamicfiltersselector3, "PROVDSC") == 0 ) && ( AV61Configuracion_provinciawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_provinciawwds_11_provdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV62Configuracion_provinciawwds_11_provdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_provinciawwds_13_tfprovcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_provinciawwds_12_tfprovcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvCod] like @lV63Configuracion_provinciawwds_12_tfprovcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_provinciawwds_13_tfprovcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProvCod] = @AV64Configuracion_provinciawwds_13_tfprovcod_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_provinciawwds_15_tfprovdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_provinciawwds_14_tfprovdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV65Configuracion_provinciawwds_14_tfprovdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_provinciawwds_15_tfprovdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] = @AV66Configuracion_provinciawwds_15_tfprovdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_provinciawwds_17_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_provinciawwds_16_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV67Configuracion_provinciawwds_16_tfpaidsc)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_provinciawwds_17_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV68Configuracion_provinciawwds_17_tfpaidsc_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV69Configuracion_provinciawwds_18_tfprovsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV69Configuracion_provinciawwds_18_tfprovsts_sels, "T1.[ProvSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[PaiCod], T1.[ProvCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProvCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProvCod] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProvDsc]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProvDsc] DESC";
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
            scmdbuf += " ORDER BY T1.[ProvSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProvSts] DESC";
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
                     return conditional_P003T2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP003T2;
          prmP003T2 = new Object[] {
          new ParDef("@lV54Configuracion_provinciawwds_3_provdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV54Configuracion_provinciawwds_3_provdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_provinciawwds_7_provdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_provinciawwds_7_provdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_provinciawwds_11_provdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_provinciawwds_11_provdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_provinciawwds_12_tfprovcod",GXType.NChar,4,0) ,
          new ParDef("@AV64Configuracion_provinciawwds_13_tfprovcod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV65Configuracion_provinciawwds_14_tfprovdsc",GXType.NChar,100,0) ,
          new ParDef("@AV66Configuracion_provinciawwds_15_tfprovdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_provinciawwds_16_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV68Configuracion_provinciawwds_17_tfpaidsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003T2,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
