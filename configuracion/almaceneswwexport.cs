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
   public class almaceneswwexport : GXProcedure
   {
      public almaceneswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public almaceneswwexport( IGxContext context )
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
         almaceneswwexport objalmaceneswwexport;
         objalmaceneswwexport = new almaceneswwexport();
         objalmaceneswwexport.AV11Filename = "" ;
         objalmaceneswwexport.AV12ErrorMessage = "" ;
         objalmaceneswwexport.context.SetSubmitInitialConfig(context);
         objalmaceneswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objalmaceneswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((almaceneswwexport)stateInfo).executePrivate();
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
         AV11Filename = "AlmacenesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "ALMDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20AlmDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20AlmDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Almacen", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Almacen", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20AlmDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "ALMDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24AlmDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24AlmDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Almacen", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Almacen", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24AlmDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "ALMDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28AlmDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28AlmDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Almacen", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Almacen", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28AlmDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFAlmCod) && (0==AV35TFAlmCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFAlmCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFAlmCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFAlmDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Almacen") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFAlmDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFAlmDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Almacen") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFAlmDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFAlmDir_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Dirección Almacen") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFAlmDir_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFAlmDir)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Dirección Almacen") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFAlmDir, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFAlmAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFAlmAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFAlmAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFAlmAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV50TFAlmCos) && (0==AV51TFAlmCos_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valoriza") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV50TFAlmCos;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV51TFAlmCos_To;
         }
         if ( ! ( (0==AV42TFAlmPed_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Afecta Pedidos") ;
            AV13CellRow = GXt_int2;
            if ( AV42TFAlmPed_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV42TFAlmPed_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( ( AV47TFAlmSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV49i = 1;
            AV54GXV1 = 1;
            while ( AV54GXV1 <= AV47TFAlmSts_Sels.Count )
            {
               AV48TFAlmSts_Sel = (short)(AV47TFAlmSts_Sels.GetNumeric(AV54GXV1));
               if ( AV49i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV48TFAlmSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV48TFAlmSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV49i = (long)(AV49i+1);
               AV54GXV1 = (int)(AV54GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Almacen";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Dirección Almacen";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Abreviatura";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Valoriza";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Afecta Pedidos";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV56Configuracion_almaceneswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV57Configuracion_almaceneswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV58Configuracion_almaceneswwds_3_almdsc1 = AV20AlmDsc1;
         AV59Configuracion_almaceneswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV60Configuracion_almaceneswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV61Configuracion_almaceneswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV62Configuracion_almaceneswwds_7_almdsc2 = AV24AlmDsc2;
         AV63Configuracion_almaceneswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV64Configuracion_almaceneswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV65Configuracion_almaceneswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV66Configuracion_almaceneswwds_11_almdsc3 = AV28AlmDsc3;
         AV67Configuracion_almaceneswwds_12_tfalmcod = AV34TFAlmCod;
         AV68Configuracion_almaceneswwds_13_tfalmcod_to = AV35TFAlmCod_To;
         AV69Configuracion_almaceneswwds_14_tfalmdsc = AV36TFAlmDsc;
         AV70Configuracion_almaceneswwds_15_tfalmdsc_sel = AV37TFAlmDsc_Sel;
         AV71Configuracion_almaceneswwds_16_tfalmdir = AV38TFAlmDir;
         AV72Configuracion_almaceneswwds_17_tfalmdir_sel = AV39TFAlmDir_Sel;
         AV73Configuracion_almaceneswwds_18_tfalmabr = AV40TFAlmAbr;
         AV74Configuracion_almaceneswwds_19_tfalmabr_sel = AV41TFAlmAbr_Sel;
         AV75Configuracion_almaceneswwds_20_tfalmcos = AV50TFAlmCos;
         AV76Configuracion_almaceneswwds_21_tfalmcos_to = AV51TFAlmCos_To;
         AV77Configuracion_almaceneswwds_22_tfalmped_sel = AV42TFAlmPed_Sel;
         AV78Configuracion_almaceneswwds_23_tfalmsts_sels = AV47TFAlmSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A438AlmSts ,
                                              AV78Configuracion_almaceneswwds_23_tfalmsts_sels ,
                                              AV56Configuracion_almaceneswwds_1_dynamicfiltersselector1 ,
                                              AV57Configuracion_almaceneswwds_2_dynamicfiltersoperator1 ,
                                              AV58Configuracion_almaceneswwds_3_almdsc1 ,
                                              AV59Configuracion_almaceneswwds_4_dynamicfiltersenabled2 ,
                                              AV60Configuracion_almaceneswwds_5_dynamicfiltersselector2 ,
                                              AV61Configuracion_almaceneswwds_6_dynamicfiltersoperator2 ,
                                              AV62Configuracion_almaceneswwds_7_almdsc2 ,
                                              AV63Configuracion_almaceneswwds_8_dynamicfiltersenabled3 ,
                                              AV64Configuracion_almaceneswwds_9_dynamicfiltersselector3 ,
                                              AV65Configuracion_almaceneswwds_10_dynamicfiltersoperator3 ,
                                              AV66Configuracion_almaceneswwds_11_almdsc3 ,
                                              AV67Configuracion_almaceneswwds_12_tfalmcod ,
                                              AV68Configuracion_almaceneswwds_13_tfalmcod_to ,
                                              AV70Configuracion_almaceneswwds_15_tfalmdsc_sel ,
                                              AV69Configuracion_almaceneswwds_14_tfalmdsc ,
                                              AV72Configuracion_almaceneswwds_17_tfalmdir_sel ,
                                              AV71Configuracion_almaceneswwds_16_tfalmdir ,
                                              AV74Configuracion_almaceneswwds_19_tfalmabr_sel ,
                                              AV73Configuracion_almaceneswwds_18_tfalmabr ,
                                              AV75Configuracion_almaceneswwds_20_tfalmcos ,
                                              AV76Configuracion_almaceneswwds_21_tfalmcos_to ,
                                              AV77Configuracion_almaceneswwds_22_tfalmped_sel ,
                                              AV78Configuracion_almaceneswwds_23_tfalmsts_sels.Count ,
                                              A436AlmDsc ,
                                              A63AlmCod ,
                                              A435AlmDir ,
                                              A433AlmAbr ,
                                              A434AlmCos ,
                                              A437AlmPed ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Configuracion_almaceneswwds_3_almdsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_almaceneswwds_3_almdsc1), 100, "%");
         lV58Configuracion_almaceneswwds_3_almdsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_almaceneswwds_3_almdsc1), 100, "%");
         lV62Configuracion_almaceneswwds_7_almdsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_almaceneswwds_7_almdsc2), 100, "%");
         lV62Configuracion_almaceneswwds_7_almdsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_almaceneswwds_7_almdsc2), 100, "%");
         lV66Configuracion_almaceneswwds_11_almdsc3 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_almaceneswwds_11_almdsc3), 100, "%");
         lV66Configuracion_almaceneswwds_11_almdsc3 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_almaceneswwds_11_almdsc3), 100, "%");
         lV69Configuracion_almaceneswwds_14_tfalmdsc = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_almaceneswwds_14_tfalmdsc), 100, "%");
         lV71Configuracion_almaceneswwds_16_tfalmdir = StringUtil.Concat( StringUtil.RTrim( AV71Configuracion_almaceneswwds_16_tfalmdir), "%", "");
         lV73Configuracion_almaceneswwds_18_tfalmabr = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_almaceneswwds_18_tfalmabr), 10, "%");
         /* Using cursor P002F2 */
         pr_default.execute(0, new Object[] {lV58Configuracion_almaceneswwds_3_almdsc1, lV58Configuracion_almaceneswwds_3_almdsc1, lV62Configuracion_almaceneswwds_7_almdsc2, lV62Configuracion_almaceneswwds_7_almdsc2, lV66Configuracion_almaceneswwds_11_almdsc3, lV66Configuracion_almaceneswwds_11_almdsc3, AV67Configuracion_almaceneswwds_12_tfalmcod, AV68Configuracion_almaceneswwds_13_tfalmcod_to, lV69Configuracion_almaceneswwds_14_tfalmdsc, AV70Configuracion_almaceneswwds_15_tfalmdsc_sel, lV71Configuracion_almaceneswwds_16_tfalmdir, AV72Configuracion_almaceneswwds_17_tfalmdir_sel, lV73Configuracion_almaceneswwds_18_tfalmabr, AV74Configuracion_almaceneswwds_19_tfalmabr_sel, AV75Configuracion_almaceneswwds_20_tfalmcos, AV76Configuracion_almaceneswwds_21_tfalmcos_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A438AlmSts = P002F2_A438AlmSts[0];
            A437AlmPed = P002F2_A437AlmPed[0];
            A434AlmCos = P002F2_A434AlmCos[0];
            A433AlmAbr = P002F2_A433AlmAbr[0];
            A435AlmDir = P002F2_A435AlmDir[0];
            A63AlmCod = P002F2_A63AlmCod[0];
            A436AlmDsc = P002F2_A436AlmDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A63AlmCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A436AlmDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A435AlmDir, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A433AlmAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = A434AlmCos;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Number = A437AlmPed;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "";
            if ( A438AlmSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "ACTIVO";
            }
            else if ( A438AlmSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "INACTIVO";
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.AlmacenesWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.AlmacenesWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.AlmacenesWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV79GXV2 = 1;
         while ( AV79GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV79GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFALMCOD") == 0 )
            {
               AV34TFAlmCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFAlmCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFALMDSC") == 0 )
            {
               AV36TFAlmDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFALMDSC_SEL") == 0 )
            {
               AV37TFAlmDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFALMDIR") == 0 )
            {
               AV38TFAlmDir = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFALMDIR_SEL") == 0 )
            {
               AV39TFAlmDir_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFALMABR") == 0 )
            {
               AV40TFAlmAbr = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFALMABR_SEL") == 0 )
            {
               AV41TFAlmAbr_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFALMCOS") == 0 )
            {
               AV50TFAlmCos = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV51TFAlmCos_To = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFALMPED_SEL") == 0 )
            {
               AV42TFAlmPed_Sel = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFALMSTS_SEL") == 0 )
            {
               AV46TFAlmSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV47TFAlmSts_Sels.FromJSonString(AV46TFAlmSts_SelsJson, null);
            }
            AV79GXV2 = (int)(AV79GXV2+1);
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
         AV20AlmDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24AlmDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28AlmDsc3 = "";
         AV37TFAlmDsc_Sel = "";
         AV36TFAlmDsc = "";
         AV39TFAlmDir_Sel = "";
         AV38TFAlmDir = "";
         AV41TFAlmAbr_Sel = "";
         AV40TFAlmAbr = "";
         AV47TFAlmSts_Sels = new GxSimpleCollection<short>();
         AV56Configuracion_almaceneswwds_1_dynamicfiltersselector1 = "";
         AV58Configuracion_almaceneswwds_3_almdsc1 = "";
         AV60Configuracion_almaceneswwds_5_dynamicfiltersselector2 = "";
         AV62Configuracion_almaceneswwds_7_almdsc2 = "";
         AV64Configuracion_almaceneswwds_9_dynamicfiltersselector3 = "";
         AV66Configuracion_almaceneswwds_11_almdsc3 = "";
         AV69Configuracion_almaceneswwds_14_tfalmdsc = "";
         AV70Configuracion_almaceneswwds_15_tfalmdsc_sel = "";
         AV71Configuracion_almaceneswwds_16_tfalmdir = "";
         AV72Configuracion_almaceneswwds_17_tfalmdir_sel = "";
         AV73Configuracion_almaceneswwds_18_tfalmabr = "";
         AV74Configuracion_almaceneswwds_19_tfalmabr_sel = "";
         AV78Configuracion_almaceneswwds_23_tfalmsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV58Configuracion_almaceneswwds_3_almdsc1 = "";
         lV62Configuracion_almaceneswwds_7_almdsc2 = "";
         lV66Configuracion_almaceneswwds_11_almdsc3 = "";
         lV69Configuracion_almaceneswwds_14_tfalmdsc = "";
         lV71Configuracion_almaceneswwds_16_tfalmdir = "";
         lV73Configuracion_almaceneswwds_18_tfalmabr = "";
         A436AlmDsc = "";
         A435AlmDir = "";
         A433AlmAbr = "";
         P002F2_A438AlmSts = new short[1] ;
         P002F2_A437AlmPed = new short[1] ;
         P002F2_A434AlmCos = new short[1] ;
         P002F2_A433AlmAbr = new string[] {""} ;
         P002F2_A435AlmDir = new string[] {""} ;
         P002F2_A63AlmCod = new int[1] ;
         P002F2_A436AlmDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46TFAlmSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.almaceneswwexport__default(),
            new Object[][] {
                new Object[] {
               P002F2_A438AlmSts, P002F2_A437AlmPed, P002F2_A434AlmCos, P002F2_A433AlmAbr, P002F2_A435AlmDir, P002F2_A63AlmCod, P002F2_A436AlmDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV50TFAlmCos ;
      private short AV51TFAlmCos_To ;
      private short AV42TFAlmPed_Sel ;
      private short GXt_int2 ;
      private short AV48TFAlmSts_Sel ;
      private short AV57Configuracion_almaceneswwds_2_dynamicfiltersoperator1 ;
      private short AV61Configuracion_almaceneswwds_6_dynamicfiltersoperator2 ;
      private short AV65Configuracion_almaceneswwds_10_dynamicfiltersoperator3 ;
      private short AV75Configuracion_almaceneswwds_20_tfalmcos ;
      private short AV76Configuracion_almaceneswwds_21_tfalmcos_to ;
      private short AV77Configuracion_almaceneswwds_22_tfalmped_sel ;
      private short A438AlmSts ;
      private short A434AlmCos ;
      private short A437AlmPed ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFAlmCod ;
      private int AV35TFAlmCod_To ;
      private int AV54GXV1 ;
      private int AV67Configuracion_almaceneswwds_12_tfalmcod ;
      private int AV68Configuracion_almaceneswwds_13_tfalmcod_to ;
      private int AV78Configuracion_almaceneswwds_23_tfalmsts_sels_Count ;
      private int A63AlmCod ;
      private int AV79GXV2 ;
      private long AV49i ;
      private string AV20AlmDsc1 ;
      private string AV24AlmDsc2 ;
      private string AV28AlmDsc3 ;
      private string AV37TFAlmDsc_Sel ;
      private string AV36TFAlmDsc ;
      private string AV41TFAlmAbr_Sel ;
      private string AV40TFAlmAbr ;
      private string AV58Configuracion_almaceneswwds_3_almdsc1 ;
      private string AV62Configuracion_almaceneswwds_7_almdsc2 ;
      private string AV66Configuracion_almaceneswwds_11_almdsc3 ;
      private string AV69Configuracion_almaceneswwds_14_tfalmdsc ;
      private string AV70Configuracion_almaceneswwds_15_tfalmdsc_sel ;
      private string AV73Configuracion_almaceneswwds_18_tfalmabr ;
      private string AV74Configuracion_almaceneswwds_19_tfalmabr_sel ;
      private string scmdbuf ;
      private string lV58Configuracion_almaceneswwds_3_almdsc1 ;
      private string lV62Configuracion_almaceneswwds_7_almdsc2 ;
      private string lV66Configuracion_almaceneswwds_11_almdsc3 ;
      private string lV69Configuracion_almaceneswwds_14_tfalmdsc ;
      private string lV73Configuracion_almaceneswwds_18_tfalmabr ;
      private string A436AlmDsc ;
      private string A433AlmAbr ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV59Configuracion_almaceneswwds_4_dynamicfiltersenabled2 ;
      private bool AV63Configuracion_almaceneswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV46TFAlmSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV39TFAlmDir_Sel ;
      private string AV38TFAlmDir ;
      private string AV56Configuracion_almaceneswwds_1_dynamicfiltersselector1 ;
      private string AV60Configuracion_almaceneswwds_5_dynamicfiltersselector2 ;
      private string AV64Configuracion_almaceneswwds_9_dynamicfiltersselector3 ;
      private string AV71Configuracion_almaceneswwds_16_tfalmdir ;
      private string AV72Configuracion_almaceneswwds_17_tfalmdir_sel ;
      private string lV71Configuracion_almaceneswwds_16_tfalmdir ;
      private string A435AlmDir ;
      private GxSimpleCollection<short> AV47TFAlmSts_Sels ;
      private GxSimpleCollection<short> AV78Configuracion_almaceneswwds_23_tfalmsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002F2_A438AlmSts ;
      private short[] P002F2_A437AlmPed ;
      private short[] P002F2_A434AlmCos ;
      private string[] P002F2_A433AlmAbr ;
      private string[] P002F2_A435AlmDir ;
      private int[] P002F2_A63AlmCod ;
      private string[] P002F2_A436AlmDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class almaceneswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002F2( IGxContext context ,
                                             short A438AlmSts ,
                                             GxSimpleCollection<short> AV78Configuracion_almaceneswwds_23_tfalmsts_sels ,
                                             string AV56Configuracion_almaceneswwds_1_dynamicfiltersselector1 ,
                                             short AV57Configuracion_almaceneswwds_2_dynamicfiltersoperator1 ,
                                             string AV58Configuracion_almaceneswwds_3_almdsc1 ,
                                             bool AV59Configuracion_almaceneswwds_4_dynamicfiltersenabled2 ,
                                             string AV60Configuracion_almaceneswwds_5_dynamicfiltersselector2 ,
                                             short AV61Configuracion_almaceneswwds_6_dynamicfiltersoperator2 ,
                                             string AV62Configuracion_almaceneswwds_7_almdsc2 ,
                                             bool AV63Configuracion_almaceneswwds_8_dynamicfiltersenabled3 ,
                                             string AV64Configuracion_almaceneswwds_9_dynamicfiltersselector3 ,
                                             short AV65Configuracion_almaceneswwds_10_dynamicfiltersoperator3 ,
                                             string AV66Configuracion_almaceneswwds_11_almdsc3 ,
                                             int AV67Configuracion_almaceneswwds_12_tfalmcod ,
                                             int AV68Configuracion_almaceneswwds_13_tfalmcod_to ,
                                             string AV70Configuracion_almaceneswwds_15_tfalmdsc_sel ,
                                             string AV69Configuracion_almaceneswwds_14_tfalmdsc ,
                                             string AV72Configuracion_almaceneswwds_17_tfalmdir_sel ,
                                             string AV71Configuracion_almaceneswwds_16_tfalmdir ,
                                             string AV74Configuracion_almaceneswwds_19_tfalmabr_sel ,
                                             string AV73Configuracion_almaceneswwds_18_tfalmabr ,
                                             short AV75Configuracion_almaceneswwds_20_tfalmcos ,
                                             short AV76Configuracion_almaceneswwds_21_tfalmcos_to ,
                                             short AV77Configuracion_almaceneswwds_22_tfalmped_sel ,
                                             int AV78Configuracion_almaceneswwds_23_tfalmsts_sels_Count ,
                                             string A436AlmDsc ,
                                             int A63AlmCod ,
                                             string A435AlmDir ,
                                             string A433AlmAbr ,
                                             short A434AlmCos ,
                                             short A437AlmPed ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [AlmSts], [AlmPed], [AlmCos], [AlmAbr], [AlmDir], [AlmCod], [AlmDsc] FROM [CALMACEN]";
         if ( ( StringUtil.StrCmp(AV56Configuracion_almaceneswwds_1_dynamicfiltersselector1, "ALMDSC") == 0 ) && ( AV57Configuracion_almaceneswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_almaceneswwds_3_almdsc1)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV58Configuracion_almaceneswwds_3_almdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Configuracion_almaceneswwds_1_dynamicfiltersselector1, "ALMDSC") == 0 ) && ( AV57Configuracion_almaceneswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_almaceneswwds_3_almdsc1)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV58Configuracion_almaceneswwds_3_almdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV59Configuracion_almaceneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Configuracion_almaceneswwds_5_dynamicfiltersselector2, "ALMDSC") == 0 ) && ( AV61Configuracion_almaceneswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_almaceneswwds_7_almdsc2)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV62Configuracion_almaceneswwds_7_almdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV59Configuracion_almaceneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Configuracion_almaceneswwds_5_dynamicfiltersselector2, "ALMDSC") == 0 ) && ( AV61Configuracion_almaceneswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_almaceneswwds_7_almdsc2)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV62Configuracion_almaceneswwds_7_almdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV63Configuracion_almaceneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_almaceneswwds_9_dynamicfiltersselector3, "ALMDSC") == 0 ) && ( AV65Configuracion_almaceneswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_almaceneswwds_11_almdsc3)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV66Configuracion_almaceneswwds_11_almdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV63Configuracion_almaceneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_almaceneswwds_9_dynamicfiltersselector3, "ALMDSC") == 0 ) && ( AV65Configuracion_almaceneswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_almaceneswwds_11_almdsc3)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV66Configuracion_almaceneswwds_11_almdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV67Configuracion_almaceneswwds_12_tfalmcod) )
         {
            AddWhere(sWhereString, "([AlmCod] >= @AV67Configuracion_almaceneswwds_12_tfalmcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV68Configuracion_almaceneswwds_13_tfalmcod_to) )
         {
            AddWhere(sWhereString, "([AlmCod] <= @AV68Configuracion_almaceneswwds_13_tfalmcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_almaceneswwds_15_tfalmdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_almaceneswwds_14_tfalmdsc)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV69Configuracion_almaceneswwds_14_tfalmdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_almaceneswwds_15_tfalmdsc_sel)) )
         {
            AddWhere(sWhereString, "([AlmDsc] = @AV70Configuracion_almaceneswwds_15_tfalmdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_almaceneswwds_17_tfalmdir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_almaceneswwds_16_tfalmdir)) ) )
         {
            AddWhere(sWhereString, "([AlmDir] like @lV71Configuracion_almaceneswwds_16_tfalmdir)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_almaceneswwds_17_tfalmdir_sel)) )
         {
            AddWhere(sWhereString, "([AlmDir] = @AV72Configuracion_almaceneswwds_17_tfalmdir_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_almaceneswwds_19_tfalmabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_almaceneswwds_18_tfalmabr)) ) )
         {
            AddWhere(sWhereString, "([AlmAbr] like @lV73Configuracion_almaceneswwds_18_tfalmabr)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_almaceneswwds_19_tfalmabr_sel)) )
         {
            AddWhere(sWhereString, "([AlmAbr] = @AV74Configuracion_almaceneswwds_19_tfalmabr_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (0==AV75Configuracion_almaceneswwds_20_tfalmcos) )
         {
            AddWhere(sWhereString, "([AlmCos] >= @AV75Configuracion_almaceneswwds_20_tfalmcos)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (0==AV76Configuracion_almaceneswwds_21_tfalmcos_to) )
         {
            AddWhere(sWhereString, "([AlmCos] <= @AV76Configuracion_almaceneswwds_21_tfalmcos_to)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV77Configuracion_almaceneswwds_22_tfalmped_sel == 1 )
         {
            AddWhere(sWhereString, "([AlmPed] = 1)");
         }
         if ( AV77Configuracion_almaceneswwds_22_tfalmped_sel == 2 )
         {
            AddWhere(sWhereString, "([AlmPed] = 0)");
         }
         if ( AV78Configuracion_almaceneswwds_23_tfalmsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Configuracion_almaceneswwds_23_tfalmsts_sels, "[AlmSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [AlmCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AlmCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [AlmDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AlmDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [AlmDir]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AlmDir] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [AlmAbr]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AlmAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [AlmCos]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AlmCos] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [AlmPed]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AlmPed] DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [AlmSts]";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AlmSts] DESC";
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
                     return conditional_P002F2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (bool)dynConstraints[32] );
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
          Object[] prmP002F2;
          prmP002F2 = new Object[] {
          new ParDef("@lV58Configuracion_almaceneswwds_3_almdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_almaceneswwds_3_almdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_almaceneswwds_7_almdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_almaceneswwds_7_almdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_almaceneswwds_11_almdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_almaceneswwds_11_almdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV67Configuracion_almaceneswwds_12_tfalmcod",GXType.Int32,6,0) ,
          new ParDef("@AV68Configuracion_almaceneswwds_13_tfalmcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV69Configuracion_almaceneswwds_14_tfalmdsc",GXType.NChar,100,0) ,
          new ParDef("@AV70Configuracion_almaceneswwds_15_tfalmdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV71Configuracion_almaceneswwds_16_tfalmdir",GXType.NVarChar,100,0) ,
          new ParDef("@AV72Configuracion_almaceneswwds_17_tfalmdir_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV73Configuracion_almaceneswwds_18_tfalmabr",GXType.NChar,10,0) ,
          new ParDef("@AV74Configuracion_almaceneswwds_19_tfalmabr_sel",GXType.NChar,10,0) ,
          new ParDef("@AV75Configuracion_almaceneswwds_20_tfalmcos",GXType.Int16,1,0) ,
          new ParDef("@AV76Configuracion_almaceneswwds_21_tfalmcos_to",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                return;
       }
    }

 }

}
