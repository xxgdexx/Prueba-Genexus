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
   public class lineasproductoswwexport : GXProcedure
   {
      public lineasproductoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public lineasproductoswwexport( IGxContext context )
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
         lineasproductoswwexport objlineasproductoswwexport;
         objlineasproductoswwexport = new lineasproductoswwexport();
         objlineasproductoswwexport.AV11Filename = "" ;
         objlineasproductoswwexport.AV12ErrorMessage = "" ;
         objlineasproductoswwexport.context.SetSubmitInitialConfig(context);
         objlineasproductoswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlineasproductoswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((lineasproductoswwexport)stateInfo).executePrivate();
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
         AV11Filename = "LineasProductosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "LINDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20LinDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20LinDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Linea", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Linea", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20LinDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "LINDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24LinDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24LinDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Linea", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Linea", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24LinDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "LINDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28LinDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28LinDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Linea", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Linea", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28LinDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFLinCod) && (0==AV35TFLinCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFLinCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFLinCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFLinDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFLinDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFLinDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFLinDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFLinAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFLinAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFLinAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFLinAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFLinSunat_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sunat") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFLinSunat_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFLinSunat)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sunat") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFLinSunat, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV52TFLinStk_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Controla Stock") ;
            AV13CellRow = GXt_int2;
            AV49i = 1;
            AV55GXV1 = 1;
            while ( AV55GXV1 <= AV52TFLinStk_Sels.Count )
            {
               AV50TFLinStk_Sel = (short)(AV52TFLinStk_Sels.GetNumeric(AV55GXV1));
               if ( AV49i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV50TFLinStk_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"NO";
               }
               else if ( AV50TFLinStk_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"SI";
               }
               AV49i = (long)(AV49i+1);
               AV55GXV1 = (int)(AV55GXV1+1);
            }
         }
         if ( ! ( ( AV47TFLinSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV49i = 1;
            AV56GXV2 = 1;
            while ( AV56GXV2 <= AV47TFLinSts_Sels.Count )
            {
               AV48TFLinSts_Sel = (short)(AV47TFLinSts_Sels.GetNumeric(AV56GXV2));
               if ( AV49i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV48TFLinSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV48TFLinSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV49i = (long)(AV49i+1);
               AV56GXV2 = (int)(AV56GXV2+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Descripción";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Abreviatura";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Codigo Sunat";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Controla Stock";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV58Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV59Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV60Configuracion_lineasproductoswwds_3_lindsc1 = AV20LinDsc1;
         AV61Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV62Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV63Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV64Configuracion_lineasproductoswwds_7_lindsc2 = AV24LinDsc2;
         AV65Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV66Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV67Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV68Configuracion_lineasproductoswwds_11_lindsc3 = AV28LinDsc3;
         AV69Configuracion_lineasproductoswwds_12_tflincod = AV34TFLinCod;
         AV70Configuracion_lineasproductoswwds_13_tflincod_to = AV35TFLinCod_To;
         AV71Configuracion_lineasproductoswwds_14_tflindsc = AV36TFLinDsc;
         AV72Configuracion_lineasproductoswwds_15_tflindsc_sel = AV37TFLinDsc_Sel;
         AV73Configuracion_lineasproductoswwds_16_tflinabr = AV38TFLinAbr;
         AV74Configuracion_lineasproductoswwds_17_tflinabr_sel = AV39TFLinAbr_Sel;
         AV75Configuracion_lineasproductoswwds_18_tflinsunat = AV40TFLinSunat;
         AV76Configuracion_lineasproductoswwds_19_tflinsunat_sel = AV41TFLinSunat_Sel;
         AV77Configuracion_lineasproductoswwds_20_tflinstk_sels = AV52TFLinStk_Sels;
         AV78Configuracion_lineasproductoswwds_21_tflinsts_sels = AV47TFLinSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1158LinStk ,
                                              AV77Configuracion_lineasproductoswwds_20_tflinstk_sels ,
                                              A1159LinSts ,
                                              AV78Configuracion_lineasproductoswwds_21_tflinsts_sels ,
                                              AV58Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 ,
                                              AV59Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 ,
                                              AV60Configuracion_lineasproductoswwds_3_lindsc1 ,
                                              AV61Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 ,
                                              AV62Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 ,
                                              AV63Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 ,
                                              AV64Configuracion_lineasproductoswwds_7_lindsc2 ,
                                              AV65Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 ,
                                              AV66Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 ,
                                              AV67Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 ,
                                              AV68Configuracion_lineasproductoswwds_11_lindsc3 ,
                                              AV69Configuracion_lineasproductoswwds_12_tflincod ,
                                              AV70Configuracion_lineasproductoswwds_13_tflincod_to ,
                                              AV72Configuracion_lineasproductoswwds_15_tflindsc_sel ,
                                              AV71Configuracion_lineasproductoswwds_14_tflindsc ,
                                              AV74Configuracion_lineasproductoswwds_17_tflinabr_sel ,
                                              AV73Configuracion_lineasproductoswwds_16_tflinabr ,
                                              AV76Configuracion_lineasproductoswwds_19_tflinsunat_sel ,
                                              AV75Configuracion_lineasproductoswwds_18_tflinsunat ,
                                              AV77Configuracion_lineasproductoswwds_20_tflinstk_sels.Count ,
                                              AV78Configuracion_lineasproductoswwds_21_tflinsts_sels.Count ,
                                              A1153LinDsc ,
                                              A52LinCod ,
                                              A1152LinAbr ,
                                              A1160LinSunat ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV60Configuracion_lineasproductoswwds_3_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_lineasproductoswwds_3_lindsc1), 100, "%");
         lV60Configuracion_lineasproductoswwds_3_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_lineasproductoswwds_3_lindsc1), 100, "%");
         lV64Configuracion_lineasproductoswwds_7_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_lineasproductoswwds_7_lindsc2), 100, "%");
         lV64Configuracion_lineasproductoswwds_7_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_lineasproductoswwds_7_lindsc2), 100, "%");
         lV68Configuracion_lineasproductoswwds_11_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_lineasproductoswwds_11_lindsc3), 100, "%");
         lV68Configuracion_lineasproductoswwds_11_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_lineasproductoswwds_11_lindsc3), 100, "%");
         lV71Configuracion_lineasproductoswwds_14_tflindsc = StringUtil.PadR( StringUtil.RTrim( AV71Configuracion_lineasproductoswwds_14_tflindsc), 100, "%");
         lV73Configuracion_lineasproductoswwds_16_tflinabr = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_lineasproductoswwds_16_tflinabr), 5, "%");
         lV75Configuracion_lineasproductoswwds_18_tflinsunat = StringUtil.Concat( StringUtil.RTrim( AV75Configuracion_lineasproductoswwds_18_tflinsunat), "%", "");
         /* Using cursor P001W2 */
         pr_default.execute(0, new Object[] {lV60Configuracion_lineasproductoswwds_3_lindsc1, lV60Configuracion_lineasproductoswwds_3_lindsc1, lV64Configuracion_lineasproductoswwds_7_lindsc2, lV64Configuracion_lineasproductoswwds_7_lindsc2, lV68Configuracion_lineasproductoswwds_11_lindsc3, lV68Configuracion_lineasproductoswwds_11_lindsc3, AV69Configuracion_lineasproductoswwds_12_tflincod, AV70Configuracion_lineasproductoswwds_13_tflincod_to, lV71Configuracion_lineasproductoswwds_14_tflindsc, AV72Configuracion_lineasproductoswwds_15_tflindsc_sel, lV73Configuracion_lineasproductoswwds_16_tflinabr, AV74Configuracion_lineasproductoswwds_17_tflinabr_sel, lV75Configuracion_lineasproductoswwds_18_tflinsunat, AV76Configuracion_lineasproductoswwds_19_tflinsunat_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1159LinSts = P001W2_A1159LinSts[0];
            A1158LinStk = P001W2_A1158LinStk[0];
            A1160LinSunat = P001W2_A1160LinSunat[0];
            A1152LinAbr = P001W2_A1152LinAbr[0];
            A52LinCod = P001W2_A52LinCod[0];
            A1153LinDsc = P001W2_A1153LinDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A52LinCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1153LinDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1152LinAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1160LinSunat, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A1158LinStk == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "NO";
            }
            else if ( A1158LinStk == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "SI";
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "";
            if ( A1159LinSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "ACTIVO";
            }
            else if ( A1159LinSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.LineasProductosWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.LineasProductosWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.LineasProductosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV79GXV3 = 1;
         while ( AV79GXV3 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV79GXV3));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLINCOD") == 0 )
            {
               AV34TFLinCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFLinCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLINDSC") == 0 )
            {
               AV36TFLinDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLINDSC_SEL") == 0 )
            {
               AV37TFLinDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLINABR") == 0 )
            {
               AV38TFLinAbr = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLINABR_SEL") == 0 )
            {
               AV39TFLinAbr_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLINSUNAT") == 0 )
            {
               AV40TFLinSunat = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLINSUNAT_SEL") == 0 )
            {
               AV41TFLinSunat_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLINSTK_SEL") == 0 )
            {
               AV51TFLinStk_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV52TFLinStk_Sels.FromJSonString(AV51TFLinStk_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLINSTS_SEL") == 0 )
            {
               AV46TFLinSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV47TFLinSts_Sels.FromJSonString(AV46TFLinSts_SelsJson, null);
            }
            AV79GXV3 = (int)(AV79GXV3+1);
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
         AV20LinDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24LinDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28LinDsc3 = "";
         AV37TFLinDsc_Sel = "";
         AV36TFLinDsc = "";
         AV39TFLinAbr_Sel = "";
         AV38TFLinAbr = "";
         AV41TFLinSunat_Sel = "";
         AV40TFLinSunat = "";
         AV52TFLinStk_Sels = new GxSimpleCollection<short>();
         AV47TFLinSts_Sels = new GxSimpleCollection<short>();
         AV58Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 = "";
         AV60Configuracion_lineasproductoswwds_3_lindsc1 = "";
         AV62Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 = "";
         AV64Configuracion_lineasproductoswwds_7_lindsc2 = "";
         AV66Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 = "";
         AV68Configuracion_lineasproductoswwds_11_lindsc3 = "";
         AV71Configuracion_lineasproductoswwds_14_tflindsc = "";
         AV72Configuracion_lineasproductoswwds_15_tflindsc_sel = "";
         AV73Configuracion_lineasproductoswwds_16_tflinabr = "";
         AV74Configuracion_lineasproductoswwds_17_tflinabr_sel = "";
         AV75Configuracion_lineasproductoswwds_18_tflinsunat = "";
         AV76Configuracion_lineasproductoswwds_19_tflinsunat_sel = "";
         AV77Configuracion_lineasproductoswwds_20_tflinstk_sels = new GxSimpleCollection<short>();
         AV78Configuracion_lineasproductoswwds_21_tflinsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV60Configuracion_lineasproductoswwds_3_lindsc1 = "";
         lV64Configuracion_lineasproductoswwds_7_lindsc2 = "";
         lV68Configuracion_lineasproductoswwds_11_lindsc3 = "";
         lV71Configuracion_lineasproductoswwds_14_tflindsc = "";
         lV73Configuracion_lineasproductoswwds_16_tflinabr = "";
         lV75Configuracion_lineasproductoswwds_18_tflinsunat = "";
         A1153LinDsc = "";
         A1152LinAbr = "";
         A1160LinSunat = "";
         P001W2_A1159LinSts = new short[1] ;
         P001W2_A1158LinStk = new short[1] ;
         P001W2_A1160LinSunat = new string[] {""} ;
         P001W2_A1152LinAbr = new string[] {""} ;
         P001W2_A52LinCod = new int[1] ;
         P001W2_A1153LinDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51TFLinStk_SelsJson = "";
         AV46TFLinSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.lineasproductoswwexport__default(),
            new Object[][] {
                new Object[] {
               P001W2_A1159LinSts, P001W2_A1158LinStk, P001W2_A1160LinSunat, P001W2_A1152LinAbr, P001W2_A52LinCod, P001W2_A1153LinDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV50TFLinStk_Sel ;
      private short GXt_int2 ;
      private short AV48TFLinSts_Sel ;
      private short AV59Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 ;
      private short AV63Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 ;
      private short AV67Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 ;
      private short A1158LinStk ;
      private short A1159LinSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFLinCod ;
      private int AV35TFLinCod_To ;
      private int AV55GXV1 ;
      private int AV56GXV2 ;
      private int AV69Configuracion_lineasproductoswwds_12_tflincod ;
      private int AV70Configuracion_lineasproductoswwds_13_tflincod_to ;
      private int AV77Configuracion_lineasproductoswwds_20_tflinstk_sels_Count ;
      private int AV78Configuracion_lineasproductoswwds_21_tflinsts_sels_Count ;
      private int A52LinCod ;
      private int AV79GXV3 ;
      private long AV49i ;
      private string AV20LinDsc1 ;
      private string AV24LinDsc2 ;
      private string AV28LinDsc3 ;
      private string AV37TFLinDsc_Sel ;
      private string AV36TFLinDsc ;
      private string AV39TFLinAbr_Sel ;
      private string AV38TFLinAbr ;
      private string AV60Configuracion_lineasproductoswwds_3_lindsc1 ;
      private string AV64Configuracion_lineasproductoswwds_7_lindsc2 ;
      private string AV68Configuracion_lineasproductoswwds_11_lindsc3 ;
      private string AV71Configuracion_lineasproductoswwds_14_tflindsc ;
      private string AV72Configuracion_lineasproductoswwds_15_tflindsc_sel ;
      private string AV73Configuracion_lineasproductoswwds_16_tflinabr ;
      private string AV74Configuracion_lineasproductoswwds_17_tflinabr_sel ;
      private string scmdbuf ;
      private string lV60Configuracion_lineasproductoswwds_3_lindsc1 ;
      private string lV64Configuracion_lineasproductoswwds_7_lindsc2 ;
      private string lV68Configuracion_lineasproductoswwds_11_lindsc3 ;
      private string lV71Configuracion_lineasproductoswwds_14_tflindsc ;
      private string lV73Configuracion_lineasproductoswwds_16_tflinabr ;
      private string A1153LinDsc ;
      private string A1152LinAbr ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV61Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 ;
      private bool AV65Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV51TFLinStk_SelsJson ;
      private string AV46TFLinSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV41TFLinSunat_Sel ;
      private string AV40TFLinSunat ;
      private string AV58Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 ;
      private string AV62Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 ;
      private string AV66Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 ;
      private string AV75Configuracion_lineasproductoswwds_18_tflinsunat ;
      private string AV76Configuracion_lineasproductoswwds_19_tflinsunat_sel ;
      private string lV75Configuracion_lineasproductoswwds_18_tflinsunat ;
      private string A1160LinSunat ;
      private GxSimpleCollection<short> AV52TFLinStk_Sels ;
      private GxSimpleCollection<short> AV47TFLinSts_Sels ;
      private GxSimpleCollection<short> AV77Configuracion_lineasproductoswwds_20_tflinstk_sels ;
      private GxSimpleCollection<short> AV78Configuracion_lineasproductoswwds_21_tflinsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P001W2_A1159LinSts ;
      private short[] P001W2_A1158LinStk ;
      private string[] P001W2_A1160LinSunat ;
      private string[] P001W2_A1152LinAbr ;
      private int[] P001W2_A52LinCod ;
      private string[] P001W2_A1153LinDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class lineasproductoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001W2( IGxContext context ,
                                             short A1158LinStk ,
                                             GxSimpleCollection<short> AV77Configuracion_lineasproductoswwds_20_tflinstk_sels ,
                                             short A1159LinSts ,
                                             GxSimpleCollection<short> AV78Configuracion_lineasproductoswwds_21_tflinsts_sels ,
                                             string AV58Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 ,
                                             short AV59Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 ,
                                             string AV60Configuracion_lineasproductoswwds_3_lindsc1 ,
                                             bool AV61Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 ,
                                             string AV62Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 ,
                                             short AV63Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 ,
                                             string AV64Configuracion_lineasproductoswwds_7_lindsc2 ,
                                             bool AV65Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 ,
                                             string AV66Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 ,
                                             short AV67Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 ,
                                             string AV68Configuracion_lineasproductoswwds_11_lindsc3 ,
                                             int AV69Configuracion_lineasproductoswwds_12_tflincod ,
                                             int AV70Configuracion_lineasproductoswwds_13_tflincod_to ,
                                             string AV72Configuracion_lineasproductoswwds_15_tflindsc_sel ,
                                             string AV71Configuracion_lineasproductoswwds_14_tflindsc ,
                                             string AV74Configuracion_lineasproductoswwds_17_tflinabr_sel ,
                                             string AV73Configuracion_lineasproductoswwds_16_tflinabr ,
                                             string AV76Configuracion_lineasproductoswwds_19_tflinsunat_sel ,
                                             string AV75Configuracion_lineasproductoswwds_18_tflinsunat ,
                                             int AV77Configuracion_lineasproductoswwds_20_tflinstk_sels_Count ,
                                             int AV78Configuracion_lineasproductoswwds_21_tflinsts_sels_Count ,
                                             string A1153LinDsc ,
                                             int A52LinCod ,
                                             string A1152LinAbr ,
                                             string A1160LinSunat ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [LinSts], [LinStk], [LinSunat], [LinAbr], [LinCod], [LinDsc] FROM [CLINEAPROD]";
         if ( ( StringUtil.StrCmp(AV58Configuracion_lineasproductoswwds_1_dynamicfiltersselector1, "LINDSC") == 0 ) && ( AV59Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_lineasproductoswwds_3_lindsc1)) ) )
         {
            AddWhere(sWhereString, "([LinDsc] like @lV60Configuracion_lineasproductoswwds_3_lindsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Configuracion_lineasproductoswwds_1_dynamicfiltersselector1, "LINDSC") == 0 ) && ( AV59Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_lineasproductoswwds_3_lindsc1)) ) )
         {
            AddWhere(sWhereString, "([LinDsc] like '%' + @lV60Configuracion_lineasproductoswwds_3_lindsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV61Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Configuracion_lineasproductoswwds_5_dynamicfiltersselector2, "LINDSC") == 0 ) && ( AV63Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_lineasproductoswwds_7_lindsc2)) ) )
         {
            AddWhere(sWhereString, "([LinDsc] like @lV64Configuracion_lineasproductoswwds_7_lindsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV61Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Configuracion_lineasproductoswwds_5_dynamicfiltersselector2, "LINDSC") == 0 ) && ( AV63Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_lineasproductoswwds_7_lindsc2)) ) )
         {
            AddWhere(sWhereString, "([LinDsc] like '%' + @lV64Configuracion_lineasproductoswwds_7_lindsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV65Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Configuracion_lineasproductoswwds_9_dynamicfiltersselector3, "LINDSC") == 0 ) && ( AV67Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_lineasproductoswwds_11_lindsc3)) ) )
         {
            AddWhere(sWhereString, "([LinDsc] like @lV68Configuracion_lineasproductoswwds_11_lindsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV65Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Configuracion_lineasproductoswwds_9_dynamicfiltersselector3, "LINDSC") == 0 ) && ( AV67Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_lineasproductoswwds_11_lindsc3)) ) )
         {
            AddWhere(sWhereString, "([LinDsc] like '%' + @lV68Configuracion_lineasproductoswwds_11_lindsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV69Configuracion_lineasproductoswwds_12_tflincod) )
         {
            AddWhere(sWhereString, "([LinCod] >= @AV69Configuracion_lineasproductoswwds_12_tflincod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV70Configuracion_lineasproductoswwds_13_tflincod_to) )
         {
            AddWhere(sWhereString, "([LinCod] <= @AV70Configuracion_lineasproductoswwds_13_tflincod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_lineasproductoswwds_15_tflindsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_lineasproductoswwds_14_tflindsc)) ) )
         {
            AddWhere(sWhereString, "([LinDsc] like @lV71Configuracion_lineasproductoswwds_14_tflindsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_lineasproductoswwds_15_tflindsc_sel)) )
         {
            AddWhere(sWhereString, "([LinDsc] = @AV72Configuracion_lineasproductoswwds_15_tflindsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_lineasproductoswwds_17_tflinabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_lineasproductoswwds_16_tflinabr)) ) )
         {
            AddWhere(sWhereString, "([LinAbr] like @lV73Configuracion_lineasproductoswwds_16_tflinabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_lineasproductoswwds_17_tflinabr_sel)) )
         {
            AddWhere(sWhereString, "([LinAbr] = @AV74Configuracion_lineasproductoswwds_17_tflinabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_lineasproductoswwds_19_tflinsunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_lineasproductoswwds_18_tflinsunat)) ) )
         {
            AddWhere(sWhereString, "([LinSunat] like @lV75Configuracion_lineasproductoswwds_18_tflinsunat)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_lineasproductoswwds_19_tflinsunat_sel)) )
         {
            AddWhere(sWhereString, "([LinSunat] = @AV76Configuracion_lineasproductoswwds_19_tflinsunat_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV77Configuracion_lineasproductoswwds_20_tflinstk_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Configuracion_lineasproductoswwds_20_tflinstk_sels, "[LinStk] IN (", ")")+")");
         }
         if ( AV78Configuracion_lineasproductoswwds_21_tflinsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Configuracion_lineasproductoswwds_21_tflinsts_sels, "[LinSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [LinCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [LinCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [LinDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [LinDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [LinAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [LinAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [LinSunat]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [LinSunat] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [LinStk]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [LinStk] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [LinSts]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [LinSts] DESC";
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
                     return conditional_P001W2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP001W2;
          prmP001W2 = new Object[] {
          new ParDef("@lV60Configuracion_lineasproductoswwds_3_lindsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Configuracion_lineasproductoswwds_3_lindsc1",GXType.NChar,100,0) ,
          new ParDef("@lV64Configuracion_lineasproductoswwds_7_lindsc2",GXType.NChar,100,0) ,
          new ParDef("@lV64Configuracion_lineasproductoswwds_7_lindsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_lineasproductoswwds_11_lindsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_lineasproductoswwds_11_lindsc3",GXType.NChar,100,0) ,
          new ParDef("@AV69Configuracion_lineasproductoswwds_12_tflincod",GXType.Int32,6,0) ,
          new ParDef("@AV70Configuracion_lineasproductoswwds_13_tflincod_to",GXType.Int32,6,0) ,
          new ParDef("@lV71Configuracion_lineasproductoswwds_14_tflindsc",GXType.NChar,100,0) ,
          new ParDef("@AV72Configuracion_lineasproductoswwds_15_tflindsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_lineasproductoswwds_16_tflinabr",GXType.NChar,5,0) ,
          new ParDef("@AV74Configuracion_lineasproductoswwds_17_tflinabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV75Configuracion_lineasproductoswwds_18_tflinsunat",GXType.NVarChar,5,0) ,
          new ParDef("@AV76Configuracion_lineasproductoswwds_19_tflinsunat_sel",GXType.NVarChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001W2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                return;
       }
    }

 }

}
