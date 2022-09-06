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
   public class departamentoswwexport : GXProcedure
   {
      public departamentoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public departamentoswwexport( IGxContext context )
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
         departamentoswwexport objdepartamentoswwexport;
         objdepartamentoswwexport = new departamentoswwexport();
         objdepartamentoswwexport.AV11Filename = "" ;
         objdepartamentoswwexport.AV12ErrorMessage = "" ;
         objdepartamentoswwexport.context.SetSubmitInitialConfig(context);
         objdepartamentoswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdepartamentoswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((departamentoswwexport)stateInfo).executePrivate();
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
         AV11Filename = "DepartamentosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "ESTDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20EstDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20EstDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Departamento", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Departamento", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20EstDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PAICOD") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV44PaiCod1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44PaiCod1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pais", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pais", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44PaiCod1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "ESTDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24EstDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24EstDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Departamento", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Departamento", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24EstDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PAICOD") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV45PaiCod2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45PaiCod2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pais", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pais", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45PaiCod2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "ESTDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28EstDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28EstDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Departamento", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Departamento", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28EstDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PAICOD") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV46PaiCod3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46PaiCod3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pais", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pais", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46PaiCod3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFEstCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFEstCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFEstCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34TFEstCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFEstDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Departamento") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFEstDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFEstDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Departamento") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFEstDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFPaiDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Pais") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFPaiDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPaiDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Pais") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFPaiDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV41TFEstSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV43i = 1;
            AV49GXV1 = 1;
            while ( AV49GXV1 <= AV41TFEstSts_Sels.Count )
            {
               AV42TFEstSts_Sel = (short)(AV41TFEstSts_Sels.GetNumeric(AV49GXV1));
               if ( AV43i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV42TFEstSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV42TFEstSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV43i = (long)(AV43i+1);
               AV49GXV1 = (int)(AV49GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Departamento";
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
         AV51Configuracion_departamentoswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV52Configuracion_departamentoswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV53Configuracion_departamentoswwds_3_estdsc1 = AV20EstDsc1;
         AV54Configuracion_departamentoswwds_4_paicod1 = AV44PaiCod1;
         AV55Configuracion_departamentoswwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV56Configuracion_departamentoswwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV57Configuracion_departamentoswwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV58Configuracion_departamentoswwds_8_estdsc2 = AV24EstDsc2;
         AV59Configuracion_departamentoswwds_9_paicod2 = AV45PaiCod2;
         AV60Configuracion_departamentoswwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV61Configuracion_departamentoswwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV62Configuracion_departamentoswwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV63Configuracion_departamentoswwds_13_estdsc3 = AV28EstDsc3;
         AV64Configuracion_departamentoswwds_14_paicod3 = AV46PaiCod3;
         AV65Configuracion_departamentoswwds_15_tfestcod = AV34TFEstCod;
         AV66Configuracion_departamentoswwds_16_tfestcod_sel = AV35TFEstCod_Sel;
         AV67Configuracion_departamentoswwds_17_tfestdsc = AV36TFEstDsc;
         AV68Configuracion_departamentoswwds_18_tfestdsc_sel = AV37TFEstDsc_Sel;
         AV69Configuracion_departamentoswwds_19_tfpaidsc = AV38TFPaiDsc;
         AV70Configuracion_departamentoswwds_20_tfpaidsc_sel = AV39TFPaiDsc_Sel;
         AV71Configuracion_departamentoswwds_21_tfeststs_sels = AV41TFEstSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A975EstSts ,
                                              AV71Configuracion_departamentoswwds_21_tfeststs_sels ,
                                              AV51Configuracion_departamentoswwds_1_dynamicfiltersselector1 ,
                                              AV52Configuracion_departamentoswwds_2_dynamicfiltersoperator1 ,
                                              AV53Configuracion_departamentoswwds_3_estdsc1 ,
                                              AV54Configuracion_departamentoswwds_4_paicod1 ,
                                              AV55Configuracion_departamentoswwds_5_dynamicfiltersenabled2 ,
                                              AV56Configuracion_departamentoswwds_6_dynamicfiltersselector2 ,
                                              AV57Configuracion_departamentoswwds_7_dynamicfiltersoperator2 ,
                                              AV58Configuracion_departamentoswwds_8_estdsc2 ,
                                              AV59Configuracion_departamentoswwds_9_paicod2 ,
                                              AV60Configuracion_departamentoswwds_10_dynamicfiltersenabled3 ,
                                              AV61Configuracion_departamentoswwds_11_dynamicfiltersselector3 ,
                                              AV62Configuracion_departamentoswwds_12_dynamicfiltersoperator3 ,
                                              AV63Configuracion_departamentoswwds_13_estdsc3 ,
                                              AV64Configuracion_departamentoswwds_14_paicod3 ,
                                              AV66Configuracion_departamentoswwds_16_tfestcod_sel ,
                                              AV65Configuracion_departamentoswwds_15_tfestcod ,
                                              AV68Configuracion_departamentoswwds_18_tfestdsc_sel ,
                                              AV67Configuracion_departamentoswwds_17_tfestdsc ,
                                              AV70Configuracion_departamentoswwds_20_tfpaidsc_sel ,
                                              AV69Configuracion_departamentoswwds_19_tfpaidsc ,
                                              AV71Configuracion_departamentoswwds_21_tfeststs_sels.Count ,
                                              A602EstDsc ,
                                              A139PaiCod ,
                                              A140EstCod ,
                                              A1500PaiDsc ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV53Configuracion_departamentoswwds_3_estdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_departamentoswwds_3_estdsc1), 100, "%");
         lV53Configuracion_departamentoswwds_3_estdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_departamentoswwds_3_estdsc1), 100, "%");
         lV54Configuracion_departamentoswwds_4_paicod1 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_departamentoswwds_4_paicod1), 4, "%");
         lV54Configuracion_departamentoswwds_4_paicod1 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_departamentoswwds_4_paicod1), 4, "%");
         lV58Configuracion_departamentoswwds_8_estdsc2 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_departamentoswwds_8_estdsc2), 100, "%");
         lV58Configuracion_departamentoswwds_8_estdsc2 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_departamentoswwds_8_estdsc2), 100, "%");
         lV59Configuracion_departamentoswwds_9_paicod2 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_departamentoswwds_9_paicod2), 4, "%");
         lV59Configuracion_departamentoswwds_9_paicod2 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_departamentoswwds_9_paicod2), 4, "%");
         lV63Configuracion_departamentoswwds_13_estdsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_departamentoswwds_13_estdsc3), 100, "%");
         lV63Configuracion_departamentoswwds_13_estdsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_departamentoswwds_13_estdsc3), 100, "%");
         lV64Configuracion_departamentoswwds_14_paicod3 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_departamentoswwds_14_paicod3), 4, "%");
         lV64Configuracion_departamentoswwds_14_paicod3 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_departamentoswwds_14_paicod3), 4, "%");
         lV65Configuracion_departamentoswwds_15_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_departamentoswwds_15_tfestcod), 4, "%");
         lV67Configuracion_departamentoswwds_17_tfestdsc = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_departamentoswwds_17_tfestdsc), 100, "%");
         lV69Configuracion_departamentoswwds_19_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_departamentoswwds_19_tfpaidsc), 100, "%");
         /* Using cursor P003L2 */
         pr_default.execute(0, new Object[] {lV53Configuracion_departamentoswwds_3_estdsc1, lV53Configuracion_departamentoswwds_3_estdsc1, lV54Configuracion_departamentoswwds_4_paicod1, lV54Configuracion_departamentoswwds_4_paicod1, lV58Configuracion_departamentoswwds_8_estdsc2, lV58Configuracion_departamentoswwds_8_estdsc2, lV59Configuracion_departamentoswwds_9_paicod2, lV59Configuracion_departamentoswwds_9_paicod2, lV63Configuracion_departamentoswwds_13_estdsc3, lV63Configuracion_departamentoswwds_13_estdsc3, lV64Configuracion_departamentoswwds_14_paicod3, lV64Configuracion_departamentoswwds_14_paicod3, lV65Configuracion_departamentoswwds_15_tfestcod, AV66Configuracion_departamentoswwds_16_tfestcod_sel, lV67Configuracion_departamentoswwds_17_tfestdsc, AV68Configuracion_departamentoswwds_18_tfestdsc_sel, lV69Configuracion_departamentoswwds_19_tfpaidsc, AV70Configuracion_departamentoswwds_20_tfpaidsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A975EstSts = P003L2_A975EstSts[0];
            A1500PaiDsc = P003L2_A1500PaiDsc[0];
            A140EstCod = P003L2_A140EstCod[0];
            A139PaiCod = P003L2_A139PaiCod[0];
            A602EstDsc = P003L2_A602EstDsc[0];
            A1500PaiDsc = P003L2_A1500PaiDsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A140EstCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A602EstDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1500PaiDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A975EstSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "ACTIVO";
            }
            else if ( A975EstSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.DepartamentosWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.DepartamentosWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.DepartamentosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV72GXV2 = 1;
         while ( AV72GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV72GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFESTCOD") == 0 )
            {
               AV34TFEstCod = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFESTCOD_SEL") == 0 )
            {
               AV35TFEstCod_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFESTDSC") == 0 )
            {
               AV36TFEstDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFESTDSC_SEL") == 0 )
            {
               AV37TFEstDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAIDSC") == 0 )
            {
               AV38TFPaiDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAIDSC_SEL") == 0 )
            {
               AV39TFPaiDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFESTSTS_SEL") == 0 )
            {
               AV40TFEstSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV41TFEstSts_Sels.FromJSonString(AV40TFEstSts_SelsJson, null);
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
         AV20EstDsc1 = "";
         AV44PaiCod1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24EstDsc2 = "";
         AV45PaiCod2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28EstDsc3 = "";
         AV46PaiCod3 = "";
         AV35TFEstCod_Sel = "";
         AV34TFEstCod = "";
         AV37TFEstDsc_Sel = "";
         AV36TFEstDsc = "";
         AV39TFPaiDsc_Sel = "";
         AV38TFPaiDsc = "";
         AV41TFEstSts_Sels = new GxSimpleCollection<short>();
         AV51Configuracion_departamentoswwds_1_dynamicfiltersselector1 = "";
         AV53Configuracion_departamentoswwds_3_estdsc1 = "";
         AV54Configuracion_departamentoswwds_4_paicod1 = "";
         AV56Configuracion_departamentoswwds_6_dynamicfiltersselector2 = "";
         AV58Configuracion_departamentoswwds_8_estdsc2 = "";
         AV59Configuracion_departamentoswwds_9_paicod2 = "";
         AV61Configuracion_departamentoswwds_11_dynamicfiltersselector3 = "";
         AV63Configuracion_departamentoswwds_13_estdsc3 = "";
         AV64Configuracion_departamentoswwds_14_paicod3 = "";
         AV65Configuracion_departamentoswwds_15_tfestcod = "";
         AV66Configuracion_departamentoswwds_16_tfestcod_sel = "";
         AV67Configuracion_departamentoswwds_17_tfestdsc = "";
         AV68Configuracion_departamentoswwds_18_tfestdsc_sel = "";
         AV69Configuracion_departamentoswwds_19_tfpaidsc = "";
         AV70Configuracion_departamentoswwds_20_tfpaidsc_sel = "";
         AV71Configuracion_departamentoswwds_21_tfeststs_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV53Configuracion_departamentoswwds_3_estdsc1 = "";
         lV54Configuracion_departamentoswwds_4_paicod1 = "";
         lV58Configuracion_departamentoswwds_8_estdsc2 = "";
         lV59Configuracion_departamentoswwds_9_paicod2 = "";
         lV63Configuracion_departamentoswwds_13_estdsc3 = "";
         lV64Configuracion_departamentoswwds_14_paicod3 = "";
         lV65Configuracion_departamentoswwds_15_tfestcod = "";
         lV67Configuracion_departamentoswwds_17_tfestdsc = "";
         lV69Configuracion_departamentoswwds_19_tfpaidsc = "";
         A602EstDsc = "";
         A139PaiCod = "";
         A140EstCod = "";
         A1500PaiDsc = "";
         P003L2_A975EstSts = new short[1] ;
         P003L2_A1500PaiDsc = new string[] {""} ;
         P003L2_A140EstCod = new string[] {""} ;
         P003L2_A139PaiCod = new string[] {""} ;
         P003L2_A602EstDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40TFEstSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.departamentoswwexport__default(),
            new Object[][] {
                new Object[] {
               P003L2_A975EstSts, P003L2_A1500PaiDsc, P003L2_A140EstCod, P003L2_A139PaiCod, P003L2_A602EstDsc
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
      private short AV42TFEstSts_Sel ;
      private short AV52Configuracion_departamentoswwds_2_dynamicfiltersoperator1 ;
      private short AV57Configuracion_departamentoswwds_7_dynamicfiltersoperator2 ;
      private short AV62Configuracion_departamentoswwds_12_dynamicfiltersoperator3 ;
      private short A975EstSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV49GXV1 ;
      private int AV71Configuracion_departamentoswwds_21_tfeststs_sels_Count ;
      private int AV72GXV2 ;
      private long AV43i ;
      private string AV20EstDsc1 ;
      private string AV44PaiCod1 ;
      private string AV24EstDsc2 ;
      private string AV45PaiCod2 ;
      private string AV28EstDsc3 ;
      private string AV46PaiCod3 ;
      private string AV35TFEstCod_Sel ;
      private string AV34TFEstCod ;
      private string AV37TFEstDsc_Sel ;
      private string AV36TFEstDsc ;
      private string AV39TFPaiDsc_Sel ;
      private string AV38TFPaiDsc ;
      private string AV53Configuracion_departamentoswwds_3_estdsc1 ;
      private string AV54Configuracion_departamentoswwds_4_paicod1 ;
      private string AV58Configuracion_departamentoswwds_8_estdsc2 ;
      private string AV59Configuracion_departamentoswwds_9_paicod2 ;
      private string AV63Configuracion_departamentoswwds_13_estdsc3 ;
      private string AV64Configuracion_departamentoswwds_14_paicod3 ;
      private string AV65Configuracion_departamentoswwds_15_tfestcod ;
      private string AV66Configuracion_departamentoswwds_16_tfestcod_sel ;
      private string AV67Configuracion_departamentoswwds_17_tfestdsc ;
      private string AV68Configuracion_departamentoswwds_18_tfestdsc_sel ;
      private string AV69Configuracion_departamentoswwds_19_tfpaidsc ;
      private string AV70Configuracion_departamentoswwds_20_tfpaidsc_sel ;
      private string scmdbuf ;
      private string lV53Configuracion_departamentoswwds_3_estdsc1 ;
      private string lV54Configuracion_departamentoswwds_4_paicod1 ;
      private string lV58Configuracion_departamentoswwds_8_estdsc2 ;
      private string lV59Configuracion_departamentoswwds_9_paicod2 ;
      private string lV63Configuracion_departamentoswwds_13_estdsc3 ;
      private string lV64Configuracion_departamentoswwds_14_paicod3 ;
      private string lV65Configuracion_departamentoswwds_15_tfestcod ;
      private string lV67Configuracion_departamentoswwds_17_tfestdsc ;
      private string lV69Configuracion_departamentoswwds_19_tfpaidsc ;
      private string A602EstDsc ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A1500PaiDsc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV55Configuracion_departamentoswwds_5_dynamicfiltersenabled2 ;
      private bool AV60Configuracion_departamentoswwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV40TFEstSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV51Configuracion_departamentoswwds_1_dynamicfiltersselector1 ;
      private string AV56Configuracion_departamentoswwds_6_dynamicfiltersselector2 ;
      private string AV61Configuracion_departamentoswwds_11_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV41TFEstSts_Sels ;
      private GxSimpleCollection<short> AV71Configuracion_departamentoswwds_21_tfeststs_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003L2_A975EstSts ;
      private string[] P003L2_A1500PaiDsc ;
      private string[] P003L2_A140EstCod ;
      private string[] P003L2_A139PaiCod ;
      private string[] P003L2_A602EstDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class departamentoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003L2( IGxContext context ,
                                             short A975EstSts ,
                                             GxSimpleCollection<short> AV71Configuracion_departamentoswwds_21_tfeststs_sels ,
                                             string AV51Configuracion_departamentoswwds_1_dynamicfiltersselector1 ,
                                             short AV52Configuracion_departamentoswwds_2_dynamicfiltersoperator1 ,
                                             string AV53Configuracion_departamentoswwds_3_estdsc1 ,
                                             string AV54Configuracion_departamentoswwds_4_paicod1 ,
                                             bool AV55Configuracion_departamentoswwds_5_dynamicfiltersenabled2 ,
                                             string AV56Configuracion_departamentoswwds_6_dynamicfiltersselector2 ,
                                             short AV57Configuracion_departamentoswwds_7_dynamicfiltersoperator2 ,
                                             string AV58Configuracion_departamentoswwds_8_estdsc2 ,
                                             string AV59Configuracion_departamentoswwds_9_paicod2 ,
                                             bool AV60Configuracion_departamentoswwds_10_dynamicfiltersenabled3 ,
                                             string AV61Configuracion_departamentoswwds_11_dynamicfiltersselector3 ,
                                             short AV62Configuracion_departamentoswwds_12_dynamicfiltersoperator3 ,
                                             string AV63Configuracion_departamentoswwds_13_estdsc3 ,
                                             string AV64Configuracion_departamentoswwds_14_paicod3 ,
                                             string AV66Configuracion_departamentoswwds_16_tfestcod_sel ,
                                             string AV65Configuracion_departamentoswwds_15_tfestcod ,
                                             string AV68Configuracion_departamentoswwds_18_tfestdsc_sel ,
                                             string AV67Configuracion_departamentoswwds_17_tfestdsc ,
                                             string AV70Configuracion_departamentoswwds_20_tfpaidsc_sel ,
                                             string AV69Configuracion_departamentoswwds_19_tfpaidsc ,
                                             int AV71Configuracion_departamentoswwds_21_tfeststs_sels_Count ,
                                             string A602EstDsc ,
                                             string A139PaiCod ,
                                             string A140EstCod ,
                                             string A1500PaiDsc ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[EstSts], T2.[PaiDsc], T1.[EstCod], T1.[PaiCod], T1.[EstDsc] FROM ([CESTADOS] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV51Configuracion_departamentoswwds_1_dynamicfiltersselector1, "ESTDSC") == 0 ) && ( AV52Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_departamentoswwds_3_estdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV53Configuracion_departamentoswwds_3_estdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_departamentoswwds_1_dynamicfiltersselector1, "ESTDSC") == 0 ) && ( AV52Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_departamentoswwds_3_estdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV53Configuracion_departamentoswwds_3_estdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_departamentoswwds_1_dynamicfiltersselector1, "PAICOD") == 0 ) && ( AV52Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_departamentoswwds_4_paicod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV54Configuracion_departamentoswwds_4_paicod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_departamentoswwds_1_dynamicfiltersselector1, "PAICOD") == 0 ) && ( AV52Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_departamentoswwds_4_paicod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV54Configuracion_departamentoswwds_4_paicod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV55Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Configuracion_departamentoswwds_6_dynamicfiltersselector2, "ESTDSC") == 0 ) && ( AV57Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_departamentoswwds_8_estdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV58Configuracion_departamentoswwds_8_estdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV55Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Configuracion_departamentoswwds_6_dynamicfiltersselector2, "ESTDSC") == 0 ) && ( AV57Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_departamentoswwds_8_estdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV58Configuracion_departamentoswwds_8_estdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV55Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Configuracion_departamentoswwds_6_dynamicfiltersselector2, "PAICOD") == 0 ) && ( AV57Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_departamentoswwds_9_paicod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV59Configuracion_departamentoswwds_9_paicod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV55Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Configuracion_departamentoswwds_6_dynamicfiltersselector2, "PAICOD") == 0 ) && ( AV57Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_departamentoswwds_9_paicod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV59Configuracion_departamentoswwds_9_paicod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV60Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_departamentoswwds_11_dynamicfiltersselector3, "ESTDSC") == 0 ) && ( AV62Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_departamentoswwds_13_estdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV63Configuracion_departamentoswwds_13_estdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV60Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_departamentoswwds_11_dynamicfiltersselector3, "ESTDSC") == 0 ) && ( AV62Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_departamentoswwds_13_estdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV63Configuracion_departamentoswwds_13_estdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV60Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_departamentoswwds_11_dynamicfiltersselector3, "PAICOD") == 0 ) && ( AV62Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_departamentoswwds_14_paicod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV64Configuracion_departamentoswwds_14_paicod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV60Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_departamentoswwds_11_dynamicfiltersselector3, "PAICOD") == 0 ) && ( AV62Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_departamentoswwds_14_paicod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV64Configuracion_departamentoswwds_14_paicod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_departamentoswwds_16_tfestcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_departamentoswwds_15_tfestcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] like @lV65Configuracion_departamentoswwds_15_tfestcod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_departamentoswwds_16_tfestcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] = @AV66Configuracion_departamentoswwds_16_tfestcod_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_departamentoswwds_18_tfestdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_departamentoswwds_17_tfestdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV67Configuracion_departamentoswwds_17_tfestdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_departamentoswwds_18_tfestdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] = @AV68Configuracion_departamentoswwds_18_tfestdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_departamentoswwds_20_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_departamentoswwds_19_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV69Configuracion_departamentoswwds_19_tfpaidsc)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_departamentoswwds_20_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV70Configuracion_departamentoswwds_20_tfpaidsc_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV71Configuracion_departamentoswwds_21_tfeststs_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71Configuracion_departamentoswwds_21_tfeststs_sels, "T1.[EstSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[PaiCod], T1.[EstCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstCod] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstDsc]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstDsc] DESC";
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
            scmdbuf += " ORDER BY T1.[EstSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstSts] DESC";
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
                     return conditional_P003L2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
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
          Object[] prmP003L2;
          prmP003L2 = new Object[] {
          new ParDef("@lV53Configuracion_departamentoswwds_3_estdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Configuracion_departamentoswwds_3_estdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV54Configuracion_departamentoswwds_4_paicod1",GXType.NChar,4,0) ,
          new ParDef("@lV54Configuracion_departamentoswwds_4_paicod1",GXType.NChar,4,0) ,
          new ParDef("@lV58Configuracion_departamentoswwds_8_estdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_departamentoswwds_8_estdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_departamentoswwds_9_paicod2",GXType.NChar,4,0) ,
          new ParDef("@lV59Configuracion_departamentoswwds_9_paicod2",GXType.NChar,4,0) ,
          new ParDef("@lV63Configuracion_departamentoswwds_13_estdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_departamentoswwds_13_estdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV64Configuracion_departamentoswwds_14_paicod3",GXType.NChar,4,0) ,
          new ParDef("@lV64Configuracion_departamentoswwds_14_paicod3",GXType.NChar,4,0) ,
          new ParDef("@lV65Configuracion_departamentoswwds_15_tfestcod",GXType.NChar,4,0) ,
          new ParDef("@AV66Configuracion_departamentoswwds_16_tfestcod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV67Configuracion_departamentoswwds_17_tfestdsc",GXType.NChar,100,0) ,
          new ParDef("@AV68Configuracion_departamentoswwds_18_tfestdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_departamentoswwds_19_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV70Configuracion_departamentoswwds_20_tfpaidsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003L2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
