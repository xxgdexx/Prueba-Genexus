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
   public class tipolistapreciowwexport : GXProcedure
   {
      public tipolistapreciowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipolistapreciowwexport( IGxContext context )
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
         tipolistapreciowwexport objtipolistapreciowwexport;
         objtipolistapreciowwexport = new tipolistapreciowwexport();
         objtipolistapreciowwexport.AV11Filename = "" ;
         objtipolistapreciowwexport.AV12ErrorMessage = "" ;
         objtipolistapreciowwexport.context.SetSubmitInitialConfig(context);
         objtipolistapreciowwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipolistapreciowwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipolistapreciowwexport)stateInfo).executePrivate();
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
         AV11Filename = "TipoListaPrecioWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIPLDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20TipLDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TipLDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20TipLDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TIPLDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24TipLDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TipLDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24TipLDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIPLDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28TipLDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TipLDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28TipLDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFTipLCod) && (0==AV35TFTipLCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFTipLCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFTipLCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTipLDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Lista") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFTipLDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTipLDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Lista") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFTipLDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFTipLAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFTipLAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTipLAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFTipLAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV41TFTipLSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV43i = 1;
            AV46GXV1 = 1;
            while ( AV46GXV1 <= AV41TFTipLSts_Sels.Count )
            {
               AV42TFTipLSts_Sel = (short)(AV41TFTipLSts_Sels.GetNumeric(AV46GXV1));
               if ( AV43i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV42TFTipLSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV42TFTipLSts_Sel == 0 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Tipo de Lista";
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
         AV48Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV49Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV50Configuracion_tipolistapreciowwds_3_tipldsc1 = AV20TipLDsc1;
         AV51Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV52Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV53Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV54Configuracion_tipolistapreciowwds_7_tipldsc2 = AV24TipLDsc2;
         AV55Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV56Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV57Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV58Configuracion_tipolistapreciowwds_11_tipldsc3 = AV28TipLDsc3;
         AV59Configuracion_tipolistapreciowwds_12_tftiplcod = AV34TFTipLCod;
         AV60Configuracion_tipolistapreciowwds_13_tftiplcod_to = AV35TFTipLCod_To;
         AV61Configuracion_tipolistapreciowwds_14_tftipldsc = AV36TFTipLDsc;
         AV62Configuracion_tipolistapreciowwds_15_tftipldsc_sel = AV37TFTipLDsc_Sel;
         AV63Configuracion_tipolistapreciowwds_16_tftiplabr = AV38TFTipLAbr;
         AV64Configuracion_tipolistapreciowwds_17_tftiplabr_sel = AV39TFTipLAbr_Sel;
         AV65Configuracion_tipolistapreciowwds_18_tftiplsts_sels = AV41TFTipLSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1914TipLSts ,
                                              AV65Configuracion_tipolistapreciowwds_18_tftiplsts_sels ,
                                              AV48Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1 ,
                                              AV49Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 ,
                                              AV50Configuracion_tipolistapreciowwds_3_tipldsc1 ,
                                              AV51Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 ,
                                              AV52Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2 ,
                                              AV53Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 ,
                                              AV54Configuracion_tipolistapreciowwds_7_tipldsc2 ,
                                              AV55Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 ,
                                              AV56Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3 ,
                                              AV57Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 ,
                                              AV58Configuracion_tipolistapreciowwds_11_tipldsc3 ,
                                              AV59Configuracion_tipolistapreciowwds_12_tftiplcod ,
                                              AV60Configuracion_tipolistapreciowwds_13_tftiplcod_to ,
                                              AV62Configuracion_tipolistapreciowwds_15_tftipldsc_sel ,
                                              AV61Configuracion_tipolistapreciowwds_14_tftipldsc ,
                                              AV64Configuracion_tipolistapreciowwds_17_tftiplabr_sel ,
                                              AV63Configuracion_tipolistapreciowwds_16_tftiplabr ,
                                              AV65Configuracion_tipolistapreciowwds_18_tftiplsts_sels.Count ,
                                              A1912TipLDsc ,
                                              A202TipLCod ,
                                              A1911TipLAbr ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV50Configuracion_tipolistapreciowwds_3_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV50Configuracion_tipolistapreciowwds_3_tipldsc1), 100, "%");
         lV50Configuracion_tipolistapreciowwds_3_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV50Configuracion_tipolistapreciowwds_3_tipldsc1), 100, "%");
         lV54Configuracion_tipolistapreciowwds_7_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_tipolistapreciowwds_7_tipldsc2), 100, "%");
         lV54Configuracion_tipolistapreciowwds_7_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_tipolistapreciowwds_7_tipldsc2), 100, "%");
         lV58Configuracion_tipolistapreciowwds_11_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_tipolistapreciowwds_11_tipldsc3), 100, "%");
         lV58Configuracion_tipolistapreciowwds_11_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_tipolistapreciowwds_11_tipldsc3), 100, "%");
         lV61Configuracion_tipolistapreciowwds_14_tftipldsc = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipolistapreciowwds_14_tftipldsc), 100, "%");
         lV63Configuracion_tipolistapreciowwds_16_tftiplabr = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_tipolistapreciowwds_16_tftiplabr), 5, "%");
         /* Using cursor P004G2 */
         pr_default.execute(0, new Object[] {lV50Configuracion_tipolistapreciowwds_3_tipldsc1, lV50Configuracion_tipolistapreciowwds_3_tipldsc1, lV54Configuracion_tipolistapreciowwds_7_tipldsc2, lV54Configuracion_tipolistapreciowwds_7_tipldsc2, lV58Configuracion_tipolistapreciowwds_11_tipldsc3, lV58Configuracion_tipolistapreciowwds_11_tipldsc3, AV59Configuracion_tipolistapreciowwds_12_tftiplcod, AV60Configuracion_tipolistapreciowwds_13_tftiplcod_to, lV61Configuracion_tipolistapreciowwds_14_tftipldsc, AV62Configuracion_tipolistapreciowwds_15_tftipldsc_sel, lV63Configuracion_tipolistapreciowwds_16_tftiplabr, AV64Configuracion_tipolistapreciowwds_17_tftiplabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1914TipLSts = P004G2_A1914TipLSts[0];
            A1911TipLAbr = P004G2_A1911TipLAbr[0];
            A202TipLCod = P004G2_A202TipLCod[0];
            A1912TipLDsc = P004G2_A1912TipLDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A202TipLCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1912TipLDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1911TipLAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A1914TipLSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "ACTIVO";
            }
            else if ( A1914TipLSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.TipoListaPrecioWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoListaPrecioWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.TipoListaPrecioWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV66GXV2 = 1;
         while ( AV66GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV66GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPLCOD") == 0 )
            {
               AV34TFTipLCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFTipLCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPLDSC") == 0 )
            {
               AV36TFTipLDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPLDSC_SEL") == 0 )
            {
               AV37TFTipLDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPLABR") == 0 )
            {
               AV38TFTipLAbr = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPLABR_SEL") == 0 )
            {
               AV39TFTipLAbr_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPLSTS_SEL") == 0 )
            {
               AV40TFTipLSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV41TFTipLSts_Sels.FromJSonString(AV40TFTipLSts_SelsJson, null);
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
         AV20TipLDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24TipLDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28TipLDsc3 = "";
         AV37TFTipLDsc_Sel = "";
         AV36TFTipLDsc = "";
         AV39TFTipLAbr_Sel = "";
         AV38TFTipLAbr = "";
         AV41TFTipLSts_Sels = new GxSimpleCollection<short>();
         AV48Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1 = "";
         AV50Configuracion_tipolistapreciowwds_3_tipldsc1 = "";
         AV52Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2 = "";
         AV54Configuracion_tipolistapreciowwds_7_tipldsc2 = "";
         AV56Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3 = "";
         AV58Configuracion_tipolistapreciowwds_11_tipldsc3 = "";
         AV61Configuracion_tipolistapreciowwds_14_tftipldsc = "";
         AV62Configuracion_tipolistapreciowwds_15_tftipldsc_sel = "";
         AV63Configuracion_tipolistapreciowwds_16_tftiplabr = "";
         AV64Configuracion_tipolistapreciowwds_17_tftiplabr_sel = "";
         AV65Configuracion_tipolistapreciowwds_18_tftiplsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV50Configuracion_tipolistapreciowwds_3_tipldsc1 = "";
         lV54Configuracion_tipolistapreciowwds_7_tipldsc2 = "";
         lV58Configuracion_tipolistapreciowwds_11_tipldsc3 = "";
         lV61Configuracion_tipolistapreciowwds_14_tftipldsc = "";
         lV63Configuracion_tipolistapreciowwds_16_tftiplabr = "";
         A1912TipLDsc = "";
         A1911TipLAbr = "";
         P004G2_A1914TipLSts = new short[1] ;
         P004G2_A1911TipLAbr = new string[] {""} ;
         P004G2_A202TipLCod = new int[1] ;
         P004G2_A1912TipLDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40TFTipLSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipolistapreciowwexport__default(),
            new Object[][] {
                new Object[] {
               P004G2_A1914TipLSts, P004G2_A1911TipLAbr, P004G2_A202TipLCod, P004G2_A1912TipLDsc
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
      private short AV42TFTipLSts_Sel ;
      private short AV49Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 ;
      private short AV53Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 ;
      private short AV57Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 ;
      private short A1914TipLSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFTipLCod ;
      private int AV35TFTipLCod_To ;
      private int AV46GXV1 ;
      private int AV59Configuracion_tipolistapreciowwds_12_tftiplcod ;
      private int AV60Configuracion_tipolistapreciowwds_13_tftiplcod_to ;
      private int AV65Configuracion_tipolistapreciowwds_18_tftiplsts_sels_Count ;
      private int A202TipLCod ;
      private int AV66GXV2 ;
      private long AV43i ;
      private string AV20TipLDsc1 ;
      private string AV24TipLDsc2 ;
      private string AV28TipLDsc3 ;
      private string AV37TFTipLDsc_Sel ;
      private string AV36TFTipLDsc ;
      private string AV39TFTipLAbr_Sel ;
      private string AV38TFTipLAbr ;
      private string AV50Configuracion_tipolistapreciowwds_3_tipldsc1 ;
      private string AV54Configuracion_tipolistapreciowwds_7_tipldsc2 ;
      private string AV58Configuracion_tipolistapreciowwds_11_tipldsc3 ;
      private string AV61Configuracion_tipolistapreciowwds_14_tftipldsc ;
      private string AV62Configuracion_tipolistapreciowwds_15_tftipldsc_sel ;
      private string AV63Configuracion_tipolistapreciowwds_16_tftiplabr ;
      private string AV64Configuracion_tipolistapreciowwds_17_tftiplabr_sel ;
      private string scmdbuf ;
      private string lV50Configuracion_tipolistapreciowwds_3_tipldsc1 ;
      private string lV54Configuracion_tipolistapreciowwds_7_tipldsc2 ;
      private string lV58Configuracion_tipolistapreciowwds_11_tipldsc3 ;
      private string lV61Configuracion_tipolistapreciowwds_14_tftipldsc ;
      private string lV63Configuracion_tipolistapreciowwds_16_tftiplabr ;
      private string A1912TipLDsc ;
      private string A1911TipLAbr ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV51Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 ;
      private bool AV55Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV40TFTipLSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV48Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1 ;
      private string AV52Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2 ;
      private string AV56Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV41TFTipLSts_Sels ;
      private GxSimpleCollection<short> AV65Configuracion_tipolistapreciowwds_18_tftiplsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P004G2_A1914TipLSts ;
      private string[] P004G2_A1911TipLAbr ;
      private int[] P004G2_A202TipLCod ;
      private string[] P004G2_A1912TipLDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class tipolistapreciowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004G2( IGxContext context ,
                                             short A1914TipLSts ,
                                             GxSimpleCollection<short> AV65Configuracion_tipolistapreciowwds_18_tftiplsts_sels ,
                                             string AV48Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1 ,
                                             short AV49Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 ,
                                             string AV50Configuracion_tipolistapreciowwds_3_tipldsc1 ,
                                             bool AV51Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 ,
                                             string AV52Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2 ,
                                             short AV53Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 ,
                                             string AV54Configuracion_tipolistapreciowwds_7_tipldsc2 ,
                                             bool AV55Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 ,
                                             string AV56Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3 ,
                                             short AV57Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 ,
                                             string AV58Configuracion_tipolistapreciowwds_11_tipldsc3 ,
                                             int AV59Configuracion_tipolistapreciowwds_12_tftiplcod ,
                                             int AV60Configuracion_tipolistapreciowwds_13_tftiplcod_to ,
                                             string AV62Configuracion_tipolistapreciowwds_15_tftipldsc_sel ,
                                             string AV61Configuracion_tipolistapreciowwds_14_tftipldsc ,
                                             string AV64Configuracion_tipolistapreciowwds_17_tftiplabr_sel ,
                                             string AV63Configuracion_tipolistapreciowwds_16_tftiplabr ,
                                             int AV65Configuracion_tipolistapreciowwds_18_tftiplsts_sels_Count ,
                                             string A1912TipLDsc ,
                                             int A202TipLCod ,
                                             string A1911TipLAbr ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TipLSts], [TipLAbr], [TipLCod], [TipLDsc] FROM [CTIPOSLISTAS]";
         if ( ( StringUtil.StrCmp(AV48Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV49Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Configuracion_tipolistapreciowwds_3_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like @lV50Configuracion_tipolistapreciowwds_3_tipldsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV48Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV49Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Configuracion_tipolistapreciowwds_3_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like '%' + @lV50Configuracion_tipolistapreciowwds_3_tipldsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV51Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV52Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV53Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_tipolistapreciowwds_7_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like @lV54Configuracion_tipolistapreciowwds_7_tipldsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV51Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV52Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV53Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_tipolistapreciowwds_7_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like '%' + @lV54Configuracion_tipolistapreciowwds_7_tipldsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV55Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV57Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_tipolistapreciowwds_11_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like @lV58Configuracion_tipolistapreciowwds_11_tipldsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV55Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV57Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_tipolistapreciowwds_11_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like '%' + @lV58Configuracion_tipolistapreciowwds_11_tipldsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV59Configuracion_tipolistapreciowwds_12_tftiplcod) )
         {
            AddWhere(sWhereString, "([TipLCod] >= @AV59Configuracion_tipolistapreciowwds_12_tftiplcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV60Configuracion_tipolistapreciowwds_13_tftiplcod_to) )
         {
            AddWhere(sWhereString, "([TipLCod] <= @AV60Configuracion_tipolistapreciowwds_13_tftiplcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_tipolistapreciowwds_15_tftipldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipolistapreciowwds_14_tftipldsc)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like @lV61Configuracion_tipolistapreciowwds_14_tftipldsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_tipolistapreciowwds_15_tftipldsc_sel)) )
         {
            AddWhere(sWhereString, "([TipLDsc] = @AV62Configuracion_tipolistapreciowwds_15_tftipldsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipolistapreciowwds_17_tftiplabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_tipolistapreciowwds_16_tftiplabr)) ) )
         {
            AddWhere(sWhereString, "([TipLAbr] like @lV63Configuracion_tipolistapreciowwds_16_tftiplabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipolistapreciowwds_17_tftiplabr_sel)) )
         {
            AddWhere(sWhereString, "([TipLAbr] = @AV64Configuracion_tipolistapreciowwds_17_tftiplabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV65Configuracion_tipolistapreciowwds_18_tftiplsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV65Configuracion_tipolistapreciowwds_18_tftiplsts_sels, "[TipLSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipLCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipLCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipLDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipLDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipLAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipLAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipLSts]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipLSts] DESC";
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
                     return conditional_P004G2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP004G2;
          prmP004G2 = new Object[] {
          new ParDef("@lV50Configuracion_tipolistapreciowwds_3_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV50Configuracion_tipolistapreciowwds_3_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV54Configuracion_tipolistapreciowwds_7_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV54Configuracion_tipolistapreciowwds_7_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_tipolistapreciowwds_11_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_tipolistapreciowwds_11_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@AV59Configuracion_tipolistapreciowwds_12_tftiplcod",GXType.Int32,6,0) ,
          new ParDef("@AV60Configuracion_tipolistapreciowwds_13_tftiplcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV61Configuracion_tipolistapreciowwds_14_tftipldsc",GXType.NChar,100,0) ,
          new ParDef("@AV62Configuracion_tipolistapreciowwds_15_tftipldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_tipolistapreciowwds_16_tftiplabr",GXType.NChar,5,0) ,
          new ParDef("@AV64Configuracion_tipolistapreciowwds_17_tftiplabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004G2,100, GxCacheFrequency.OFF ,true,false )
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
