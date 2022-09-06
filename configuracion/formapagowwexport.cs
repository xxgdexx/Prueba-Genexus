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
   public class formapagowwexport : GXProcedure
   {
      public formapagowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public formapagowwexport( IGxContext context )
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
         formapagowwexport objformapagowwexport;
         objformapagowwexport = new formapagowwexport();
         objformapagowwexport.AV11Filename = "" ;
         objformapagowwexport.AV12ErrorMessage = "" ;
         objformapagowwexport.context.SetSubmitInitialConfig(context);
         objformapagowwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objformapagowwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((formapagowwexport)stateInfo).executePrivate();
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
         AV11Filename = "FormaPagoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "FORDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20ForDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ForDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Forma de Pago", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Forma de Pago", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20ForDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "FORDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24ForDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ForDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Forma de Pago", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Forma de Pago", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24ForDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "FORDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28ForDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ForDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Forma de Pago", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Forma de Pago", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ForDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFForCod) && (0==AV35TFForCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFForCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFForCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFForDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Forma de Pago") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFForDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFForDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Forma de Pago") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFForDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFForAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFForAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFForAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFForAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFForSunat_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sunat") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFForSunat_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFForSunat)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sunat") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFForSunat, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV48TFForBanSts_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Afecta Banco") ;
            AV13CellRow = GXt_int2;
            if ( AV48TFForBanSts_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV48TFForBanSts_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( ( AV45TFForSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV47i = 1;
            AV51GXV1 = 1;
            while ( AV51GXV1 <= AV45TFForSts_Sels.Count )
            {
               AV46TFForSts_Sel = (short)(AV45TFForSts_Sels.GetNumeric(AV51GXV1));
               if ( AV47i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV46TFForSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV46TFForSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV47i = (long)(AV47i+1);
               AV51GXV1 = (int)(AV51GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Forma de Pago";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Abreviatura";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Codigo Sunat";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Afecta Banco";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV53Configuracion_formapagowwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV54Configuracion_formapagowwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV55Configuracion_formapagowwds_3_fordsc1 = AV20ForDsc1;
         AV56Configuracion_formapagowwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV57Configuracion_formapagowwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV58Configuracion_formapagowwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV59Configuracion_formapagowwds_7_fordsc2 = AV24ForDsc2;
         AV60Configuracion_formapagowwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV61Configuracion_formapagowwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV62Configuracion_formapagowwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV63Configuracion_formapagowwds_11_fordsc3 = AV28ForDsc3;
         AV64Configuracion_formapagowwds_12_tfforcod = AV34TFForCod;
         AV65Configuracion_formapagowwds_13_tfforcod_to = AV35TFForCod_To;
         AV66Configuracion_formapagowwds_14_tffordsc = AV36TFForDsc;
         AV67Configuracion_formapagowwds_15_tffordsc_sel = AV37TFForDsc_Sel;
         AV68Configuracion_formapagowwds_16_tfforabr = AV38TFForAbr;
         AV69Configuracion_formapagowwds_17_tfforabr_sel = AV39TFForAbr_Sel;
         AV70Configuracion_formapagowwds_18_tfforsunat = AV40TFForSunat;
         AV71Configuracion_formapagowwds_19_tfforsunat_sel = AV41TFForSunat_Sel;
         AV72Configuracion_formapagowwds_20_tfforbansts_sel = AV48TFForBanSts_Sel;
         AV73Configuracion_formapagowwds_21_tfforsts_sels = AV45TFForSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A989ForSts ,
                                              AV73Configuracion_formapagowwds_21_tfforsts_sels ,
                                              AV53Configuracion_formapagowwds_1_dynamicfiltersselector1 ,
                                              AV54Configuracion_formapagowwds_2_dynamicfiltersoperator1 ,
                                              AV55Configuracion_formapagowwds_3_fordsc1 ,
                                              AV56Configuracion_formapagowwds_4_dynamicfiltersenabled2 ,
                                              AV57Configuracion_formapagowwds_5_dynamicfiltersselector2 ,
                                              AV58Configuracion_formapagowwds_6_dynamicfiltersoperator2 ,
                                              AV59Configuracion_formapagowwds_7_fordsc2 ,
                                              AV60Configuracion_formapagowwds_8_dynamicfiltersenabled3 ,
                                              AV61Configuracion_formapagowwds_9_dynamicfiltersselector3 ,
                                              AV62Configuracion_formapagowwds_10_dynamicfiltersoperator3 ,
                                              AV63Configuracion_formapagowwds_11_fordsc3 ,
                                              AV64Configuracion_formapagowwds_12_tfforcod ,
                                              AV65Configuracion_formapagowwds_13_tfforcod_to ,
                                              AV67Configuracion_formapagowwds_15_tffordsc_sel ,
                                              AV66Configuracion_formapagowwds_14_tffordsc ,
                                              AV69Configuracion_formapagowwds_17_tfforabr_sel ,
                                              AV68Configuracion_formapagowwds_16_tfforabr ,
                                              AV71Configuracion_formapagowwds_19_tfforsunat_sel ,
                                              AV70Configuracion_formapagowwds_18_tfforsunat ,
                                              AV72Configuracion_formapagowwds_20_tfforbansts_sel ,
                                              AV73Configuracion_formapagowwds_21_tfforsts_sels.Count ,
                                              A988ForDsc ,
                                              A143ForCod ,
                                              A986ForAbr ,
                                              A990ForSunat ,
                                              A987ForBanSts ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Configuracion_formapagowwds_3_fordsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Configuracion_formapagowwds_3_fordsc1), 100, "%");
         lV55Configuracion_formapagowwds_3_fordsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Configuracion_formapagowwds_3_fordsc1), 100, "%");
         lV59Configuracion_formapagowwds_7_fordsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_formapagowwds_7_fordsc2), 100, "%");
         lV59Configuracion_formapagowwds_7_fordsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_formapagowwds_7_fordsc2), 100, "%");
         lV63Configuracion_formapagowwds_11_fordsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_formapagowwds_11_fordsc3), 100, "%");
         lV63Configuracion_formapagowwds_11_fordsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_formapagowwds_11_fordsc3), 100, "%");
         lV66Configuracion_formapagowwds_14_tffordsc = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_formapagowwds_14_tffordsc), 100, "%");
         lV68Configuracion_formapagowwds_16_tfforabr = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_formapagowwds_16_tfforabr), 5, "%");
         lV70Configuracion_formapagowwds_18_tfforsunat = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_formapagowwds_18_tfforsunat), 5, "%");
         /* Using cursor P002N2 */
         pr_default.execute(0, new Object[] {lV55Configuracion_formapagowwds_3_fordsc1, lV55Configuracion_formapagowwds_3_fordsc1, lV59Configuracion_formapagowwds_7_fordsc2, lV59Configuracion_formapagowwds_7_fordsc2, lV63Configuracion_formapagowwds_11_fordsc3, lV63Configuracion_formapagowwds_11_fordsc3, AV64Configuracion_formapagowwds_12_tfforcod, AV65Configuracion_formapagowwds_13_tfforcod_to, lV66Configuracion_formapagowwds_14_tffordsc, AV67Configuracion_formapagowwds_15_tffordsc_sel, lV68Configuracion_formapagowwds_16_tfforabr, AV69Configuracion_formapagowwds_17_tfforabr_sel, lV70Configuracion_formapagowwds_18_tfforsunat, AV71Configuracion_formapagowwds_19_tfforsunat_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A989ForSts = P002N2_A989ForSts[0];
            A987ForBanSts = P002N2_A987ForBanSts[0];
            A990ForSunat = P002N2_A990ForSunat[0];
            A986ForAbr = P002N2_A986ForAbr[0];
            A143ForCod = P002N2_A143ForCod[0];
            A988ForDsc = P002N2_A988ForDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A143ForCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A988ForDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A986ForAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A990ForSunat, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = A987ForBanSts;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "";
            if ( A989ForSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "ACTIVO";
            }
            else if ( A989ForSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "INACTIVO";
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.FormaPagoWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.FormaPagoWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.FormaPagoWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV74GXV2 = 1;
         while ( AV74GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV74GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFORCOD") == 0 )
            {
               AV34TFForCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFForCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFORDSC") == 0 )
            {
               AV36TFForDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFORDSC_SEL") == 0 )
            {
               AV37TFForDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFORABR") == 0 )
            {
               AV38TFForAbr = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFORABR_SEL") == 0 )
            {
               AV39TFForAbr_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFORSUNAT") == 0 )
            {
               AV40TFForSunat = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFORSUNAT_SEL") == 0 )
            {
               AV41TFForSunat_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFORBANSTS_SEL") == 0 )
            {
               AV48TFForBanSts_Sel = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFFORSTS_SEL") == 0 )
            {
               AV44TFForSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV45TFForSts_Sels.FromJSonString(AV44TFForSts_SelsJson, null);
            }
            AV74GXV2 = (int)(AV74GXV2+1);
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
         AV20ForDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24ForDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28ForDsc3 = "";
         AV37TFForDsc_Sel = "";
         AV36TFForDsc = "";
         AV39TFForAbr_Sel = "";
         AV38TFForAbr = "";
         AV41TFForSunat_Sel = "";
         AV40TFForSunat = "";
         AV45TFForSts_Sels = new GxSimpleCollection<short>();
         AV53Configuracion_formapagowwds_1_dynamicfiltersselector1 = "";
         AV55Configuracion_formapagowwds_3_fordsc1 = "";
         AV57Configuracion_formapagowwds_5_dynamicfiltersselector2 = "";
         AV59Configuracion_formapagowwds_7_fordsc2 = "";
         AV61Configuracion_formapagowwds_9_dynamicfiltersselector3 = "";
         AV63Configuracion_formapagowwds_11_fordsc3 = "";
         AV66Configuracion_formapagowwds_14_tffordsc = "";
         AV67Configuracion_formapagowwds_15_tffordsc_sel = "";
         AV68Configuracion_formapagowwds_16_tfforabr = "";
         AV69Configuracion_formapagowwds_17_tfforabr_sel = "";
         AV70Configuracion_formapagowwds_18_tfforsunat = "";
         AV71Configuracion_formapagowwds_19_tfforsunat_sel = "";
         AV73Configuracion_formapagowwds_21_tfforsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV55Configuracion_formapagowwds_3_fordsc1 = "";
         lV59Configuracion_formapagowwds_7_fordsc2 = "";
         lV63Configuracion_formapagowwds_11_fordsc3 = "";
         lV66Configuracion_formapagowwds_14_tffordsc = "";
         lV68Configuracion_formapagowwds_16_tfforabr = "";
         lV70Configuracion_formapagowwds_18_tfforsunat = "";
         A988ForDsc = "";
         A986ForAbr = "";
         A990ForSunat = "";
         P002N2_A989ForSts = new short[1] ;
         P002N2_A987ForBanSts = new short[1] ;
         P002N2_A990ForSunat = new string[] {""} ;
         P002N2_A986ForAbr = new string[] {""} ;
         P002N2_A143ForCod = new int[1] ;
         P002N2_A988ForDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV44TFForSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.formapagowwexport__default(),
            new Object[][] {
                new Object[] {
               P002N2_A989ForSts, P002N2_A987ForBanSts, P002N2_A990ForSunat, P002N2_A986ForAbr, P002N2_A143ForCod, P002N2_A988ForDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV48TFForBanSts_Sel ;
      private short GXt_int2 ;
      private short AV46TFForSts_Sel ;
      private short AV54Configuracion_formapagowwds_2_dynamicfiltersoperator1 ;
      private short AV58Configuracion_formapagowwds_6_dynamicfiltersoperator2 ;
      private short AV62Configuracion_formapagowwds_10_dynamicfiltersoperator3 ;
      private short AV72Configuracion_formapagowwds_20_tfforbansts_sel ;
      private short A989ForSts ;
      private short A987ForBanSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFForCod ;
      private int AV35TFForCod_To ;
      private int AV51GXV1 ;
      private int AV64Configuracion_formapagowwds_12_tfforcod ;
      private int AV65Configuracion_formapagowwds_13_tfforcod_to ;
      private int AV73Configuracion_formapagowwds_21_tfforsts_sels_Count ;
      private int A143ForCod ;
      private int AV74GXV2 ;
      private long AV47i ;
      private string AV20ForDsc1 ;
      private string AV24ForDsc2 ;
      private string AV28ForDsc3 ;
      private string AV37TFForDsc_Sel ;
      private string AV36TFForDsc ;
      private string AV39TFForAbr_Sel ;
      private string AV38TFForAbr ;
      private string AV41TFForSunat_Sel ;
      private string AV40TFForSunat ;
      private string AV55Configuracion_formapagowwds_3_fordsc1 ;
      private string AV59Configuracion_formapagowwds_7_fordsc2 ;
      private string AV63Configuracion_formapagowwds_11_fordsc3 ;
      private string AV66Configuracion_formapagowwds_14_tffordsc ;
      private string AV67Configuracion_formapagowwds_15_tffordsc_sel ;
      private string AV68Configuracion_formapagowwds_16_tfforabr ;
      private string AV69Configuracion_formapagowwds_17_tfforabr_sel ;
      private string AV70Configuracion_formapagowwds_18_tfforsunat ;
      private string AV71Configuracion_formapagowwds_19_tfforsunat_sel ;
      private string scmdbuf ;
      private string lV55Configuracion_formapagowwds_3_fordsc1 ;
      private string lV59Configuracion_formapagowwds_7_fordsc2 ;
      private string lV63Configuracion_formapagowwds_11_fordsc3 ;
      private string lV66Configuracion_formapagowwds_14_tffordsc ;
      private string lV68Configuracion_formapagowwds_16_tfforabr ;
      private string lV70Configuracion_formapagowwds_18_tfforsunat ;
      private string A988ForDsc ;
      private string A986ForAbr ;
      private string A990ForSunat ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV56Configuracion_formapagowwds_4_dynamicfiltersenabled2 ;
      private bool AV60Configuracion_formapagowwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV44TFForSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV53Configuracion_formapagowwds_1_dynamicfiltersselector1 ;
      private string AV57Configuracion_formapagowwds_5_dynamicfiltersselector2 ;
      private string AV61Configuracion_formapagowwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV45TFForSts_Sels ;
      private GxSimpleCollection<short> AV73Configuracion_formapagowwds_21_tfforsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002N2_A989ForSts ;
      private short[] P002N2_A987ForBanSts ;
      private string[] P002N2_A990ForSunat ;
      private string[] P002N2_A986ForAbr ;
      private int[] P002N2_A143ForCod ;
      private string[] P002N2_A988ForDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class formapagowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002N2( IGxContext context ,
                                             short A989ForSts ,
                                             GxSimpleCollection<short> AV73Configuracion_formapagowwds_21_tfforsts_sels ,
                                             string AV53Configuracion_formapagowwds_1_dynamicfiltersselector1 ,
                                             short AV54Configuracion_formapagowwds_2_dynamicfiltersoperator1 ,
                                             string AV55Configuracion_formapagowwds_3_fordsc1 ,
                                             bool AV56Configuracion_formapagowwds_4_dynamicfiltersenabled2 ,
                                             string AV57Configuracion_formapagowwds_5_dynamicfiltersselector2 ,
                                             short AV58Configuracion_formapagowwds_6_dynamicfiltersoperator2 ,
                                             string AV59Configuracion_formapagowwds_7_fordsc2 ,
                                             bool AV60Configuracion_formapagowwds_8_dynamicfiltersenabled3 ,
                                             string AV61Configuracion_formapagowwds_9_dynamicfiltersselector3 ,
                                             short AV62Configuracion_formapagowwds_10_dynamicfiltersoperator3 ,
                                             string AV63Configuracion_formapagowwds_11_fordsc3 ,
                                             int AV64Configuracion_formapagowwds_12_tfforcod ,
                                             int AV65Configuracion_formapagowwds_13_tfforcod_to ,
                                             string AV67Configuracion_formapagowwds_15_tffordsc_sel ,
                                             string AV66Configuracion_formapagowwds_14_tffordsc ,
                                             string AV69Configuracion_formapagowwds_17_tfforabr_sel ,
                                             string AV68Configuracion_formapagowwds_16_tfforabr ,
                                             string AV71Configuracion_formapagowwds_19_tfforsunat_sel ,
                                             string AV70Configuracion_formapagowwds_18_tfforsunat ,
                                             short AV72Configuracion_formapagowwds_20_tfforbansts_sel ,
                                             int AV73Configuracion_formapagowwds_21_tfforsts_sels_Count ,
                                             string A988ForDsc ,
                                             int A143ForCod ,
                                             string A986ForAbr ,
                                             string A990ForSunat ,
                                             short A987ForBanSts ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [ForSts], [ForBanSts], [ForSunat], [ForAbr], [ForCod], [ForDsc] FROM [CFORMAPAGO]";
         if ( ( StringUtil.StrCmp(AV53Configuracion_formapagowwds_1_dynamicfiltersselector1, "FORDSC") == 0 ) && ( AV54Configuracion_formapagowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_formapagowwds_3_fordsc1)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV55Configuracion_formapagowwds_3_fordsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracion_formapagowwds_1_dynamicfiltersselector1, "FORDSC") == 0 ) && ( AV54Configuracion_formapagowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_formapagowwds_3_fordsc1)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV55Configuracion_formapagowwds_3_fordsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV56Configuracion_formapagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_formapagowwds_5_dynamicfiltersselector2, "FORDSC") == 0 ) && ( AV58Configuracion_formapagowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_formapagowwds_7_fordsc2)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV59Configuracion_formapagowwds_7_fordsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV56Configuracion_formapagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_formapagowwds_5_dynamicfiltersselector2, "FORDSC") == 0 ) && ( AV58Configuracion_formapagowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_formapagowwds_7_fordsc2)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV59Configuracion_formapagowwds_7_fordsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV60Configuracion_formapagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_formapagowwds_9_dynamicfiltersselector3, "FORDSC") == 0 ) && ( AV62Configuracion_formapagowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_formapagowwds_11_fordsc3)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV63Configuracion_formapagowwds_11_fordsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV60Configuracion_formapagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_formapagowwds_9_dynamicfiltersselector3, "FORDSC") == 0 ) && ( AV62Configuracion_formapagowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_formapagowwds_11_fordsc3)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like '%' + @lV63Configuracion_formapagowwds_11_fordsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV64Configuracion_formapagowwds_12_tfforcod) )
         {
            AddWhere(sWhereString, "([ForCod] >= @AV64Configuracion_formapagowwds_12_tfforcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV65Configuracion_formapagowwds_13_tfforcod_to) )
         {
            AddWhere(sWhereString, "([ForCod] <= @AV65Configuracion_formapagowwds_13_tfforcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_formapagowwds_15_tffordsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_formapagowwds_14_tffordsc)) ) )
         {
            AddWhere(sWhereString, "([ForDsc] like @lV66Configuracion_formapagowwds_14_tffordsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_formapagowwds_15_tffordsc_sel)) )
         {
            AddWhere(sWhereString, "([ForDsc] = @AV67Configuracion_formapagowwds_15_tffordsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_formapagowwds_17_tfforabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_formapagowwds_16_tfforabr)) ) )
         {
            AddWhere(sWhereString, "([ForAbr] like @lV68Configuracion_formapagowwds_16_tfforabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_formapagowwds_17_tfforabr_sel)) )
         {
            AddWhere(sWhereString, "([ForAbr] = @AV69Configuracion_formapagowwds_17_tfforabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_formapagowwds_19_tfforsunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_formapagowwds_18_tfforsunat)) ) )
         {
            AddWhere(sWhereString, "([ForSunat] like @lV70Configuracion_formapagowwds_18_tfforsunat)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_formapagowwds_19_tfforsunat_sel)) )
         {
            AddWhere(sWhereString, "([ForSunat] = @AV71Configuracion_formapagowwds_19_tfforsunat_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV72Configuracion_formapagowwds_20_tfforbansts_sel == 1 )
         {
            AddWhere(sWhereString, "([ForBanSts] = 1)");
         }
         if ( AV72Configuracion_formapagowwds_20_tfforbansts_sel == 2 )
         {
            AddWhere(sWhereString, "([ForBanSts] = 0)");
         }
         if ( AV73Configuracion_formapagowwds_21_tfforsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Configuracion_formapagowwds_21_tfforsts_sels, "[ForSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ForCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ForCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ForDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ForDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ForAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ForAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ForSunat]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ForSunat] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ForBanSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ForBanSts] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ForSts]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ForSts] DESC";
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
                     return conditional_P002N2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] );
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
          Object[] prmP002N2;
          prmP002N2 = new Object[] {
          new ParDef("@lV55Configuracion_formapagowwds_3_fordsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Configuracion_formapagowwds_3_fordsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_formapagowwds_7_fordsc2",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_formapagowwds_7_fordsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_formapagowwds_11_fordsc3",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_formapagowwds_11_fordsc3",GXType.NChar,100,0) ,
          new ParDef("@AV64Configuracion_formapagowwds_12_tfforcod",GXType.Int32,6,0) ,
          new ParDef("@AV65Configuracion_formapagowwds_13_tfforcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV66Configuracion_formapagowwds_14_tffordsc",GXType.NChar,100,0) ,
          new ParDef("@AV67Configuracion_formapagowwds_15_tffordsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_formapagowwds_16_tfforabr",GXType.NChar,5,0) ,
          new ParDef("@AV69Configuracion_formapagowwds_17_tfforabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV70Configuracion_formapagowwds_18_tfforsunat",GXType.NChar,5,0) ,
          new ParDef("@AV71Configuracion_formapagowwds_19_tfforsunat_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002N2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                return;
       }
    }

 }

}
