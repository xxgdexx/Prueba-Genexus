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
namespace GeneXus.Programs.bancos {
   public class conceptoscajachicawwexport : GXProcedure
   {
      public conceptoscajachicawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptoscajachicawwexport( IGxContext context )
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
         conceptoscajachicawwexport objconceptoscajachicawwexport;
         objconceptoscajachicawwexport = new conceptoscajachicawwexport();
         objconceptoscajachicawwexport.AV11Filename = "" ;
         objconceptoscajachicawwexport.AV12ErrorMessage = "" ;
         objconceptoscajachicawwexport.context.SetSubmitInitialConfig(context);
         objconceptoscajachicawwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptoscajachicawwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptoscajachicawwexport)stateInfo).executePrivate();
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
         AV11Filename = "ConceptosCajaChicaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CONCAJDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20ConCajDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ConCajDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto Caja Chica", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto Caja Chica", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20ConCajDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CUECOD") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV46CueCod1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46CueCod1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46CueCod1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONCAJDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24ConCajDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ConCajDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto Caja Chica", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto Caja Chica", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24ConCajDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CUECOD") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV47CueCod2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47CueCod2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47CueCod2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONCAJDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28ConCajDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ConCajDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto Caja Chica", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto Caja Chica", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ConCajDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CUECOD") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV48CueCod3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48CueCod3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48CueCod3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFConCajCod) && (0==AV35TFConCajCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFConCajCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFConCajCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFConCajDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Concepto de Caja Chica") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFConCajDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFConCajDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Concepto de Caja Chica") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFConCajDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCueCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFCueCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCueCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFCueCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFCueDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción de Cuenta") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFCueDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCueDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción de Cuenta") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFCueDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV43TFConCajSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV45i = 1;
            AV51GXV1 = 1;
            while ( AV51GXV1 <= AV43TFConCajSts_Sels.Count )
            {
               AV44TFConCajSts_Sel = (short)(AV43TFConCajSts_Sels.GetNumeric(AV51GXV1));
               if ( AV45i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV44TFConCajSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV44TFConCajSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV45i = (long)(AV45i+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Concepto de Caja Chica";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Cuenta Contable";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Descripción de Cuenta";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV53Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV54Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV55Bancos_conceptoscajachicawwds_3_concajdsc1 = AV20ConCajDsc1;
         AV56Bancos_conceptoscajachicawwds_4_cuecod1 = AV46CueCod1;
         AV57Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV58Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV59Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV60Bancos_conceptoscajachicawwds_8_concajdsc2 = AV24ConCajDsc2;
         AV61Bancos_conceptoscajachicawwds_9_cuecod2 = AV47CueCod2;
         AV62Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV63Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV64Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV65Bancos_conceptoscajachicawwds_13_concajdsc3 = AV28ConCajDsc3;
         AV66Bancos_conceptoscajachicawwds_14_cuecod3 = AV48CueCod3;
         AV67Bancos_conceptoscajachicawwds_15_tfconcajcod = AV34TFConCajCod;
         AV68Bancos_conceptoscajachicawwds_16_tfconcajcod_to = AV35TFConCajCod_To;
         AV69Bancos_conceptoscajachicawwds_17_tfconcajdsc = AV36TFConCajDsc;
         AV70Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel = AV37TFConCajDsc_Sel;
         AV71Bancos_conceptoscajachicawwds_19_tfcuecod = AV38TFCueCod;
         AV72Bancos_conceptoscajachicawwds_20_tfcuecod_sel = AV39TFCueCod_Sel;
         AV73Bancos_conceptoscajachicawwds_21_tfcuedsc = AV40TFCueDsc;
         AV74Bancos_conceptoscajachicawwds_22_tfcuedsc_sel = AV41TFCueDsc_Sel;
         AV75Bancos_conceptoscajachicawwds_23_tfconcajsts_sels = AV43TFConCajSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A748ConCajSts ,
                                              AV75Bancos_conceptoscajachicawwds_23_tfconcajsts_sels ,
                                              AV53Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 ,
                                              AV54Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 ,
                                              AV55Bancos_conceptoscajachicawwds_3_concajdsc1 ,
                                              AV56Bancos_conceptoscajachicawwds_4_cuecod1 ,
                                              AV57Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 ,
                                              AV58Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 ,
                                              AV59Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 ,
                                              AV60Bancos_conceptoscajachicawwds_8_concajdsc2 ,
                                              AV61Bancos_conceptoscajachicawwds_9_cuecod2 ,
                                              AV62Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 ,
                                              AV63Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 ,
                                              AV64Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 ,
                                              AV65Bancos_conceptoscajachicawwds_13_concajdsc3 ,
                                              AV66Bancos_conceptoscajachicawwds_14_cuecod3 ,
                                              AV67Bancos_conceptoscajachicawwds_15_tfconcajcod ,
                                              AV68Bancos_conceptoscajachicawwds_16_tfconcajcod_to ,
                                              AV70Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel ,
                                              AV69Bancos_conceptoscajachicawwds_17_tfconcajdsc ,
                                              AV72Bancos_conceptoscajachicawwds_20_tfcuecod_sel ,
                                              AV71Bancos_conceptoscajachicawwds_19_tfcuecod ,
                                              AV74Bancos_conceptoscajachicawwds_22_tfcuedsc_sel ,
                                              AV73Bancos_conceptoscajachicawwds_21_tfcuedsc ,
                                              AV75Bancos_conceptoscajachicawwds_23_tfconcajsts_sels.Count ,
                                              A747ConCajDsc ,
                                              A91CueCod ,
                                              A375ConCajCod ,
                                              A860CueDsc ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Bancos_conceptoscajachicawwds_3_concajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Bancos_conceptoscajachicawwds_3_concajdsc1), 100, "%");
         lV55Bancos_conceptoscajachicawwds_3_concajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Bancos_conceptoscajachicawwds_3_concajdsc1), 100, "%");
         lV56Bancos_conceptoscajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV56Bancos_conceptoscajachicawwds_4_cuecod1), 15, "%");
         lV56Bancos_conceptoscajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV56Bancos_conceptoscajachicawwds_4_cuecod1), 15, "%");
         lV60Bancos_conceptoscajachicawwds_8_concajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_conceptoscajachicawwds_8_concajdsc2), 100, "%");
         lV60Bancos_conceptoscajachicawwds_8_concajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_conceptoscajachicawwds_8_concajdsc2), 100, "%");
         lV61Bancos_conceptoscajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_conceptoscajachicawwds_9_cuecod2), 15, "%");
         lV61Bancos_conceptoscajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_conceptoscajachicawwds_9_cuecod2), 15, "%");
         lV65Bancos_conceptoscajachicawwds_13_concajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_conceptoscajachicawwds_13_concajdsc3), 100, "%");
         lV65Bancos_conceptoscajachicawwds_13_concajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_conceptoscajachicawwds_13_concajdsc3), 100, "%");
         lV66Bancos_conceptoscajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_conceptoscajachicawwds_14_cuecod3), 15, "%");
         lV66Bancos_conceptoscajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_conceptoscajachicawwds_14_cuecod3), 15, "%");
         lV69Bancos_conceptoscajachicawwds_17_tfconcajdsc = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptoscajachicawwds_17_tfconcajdsc), 100, "%");
         lV71Bancos_conceptoscajachicawwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_conceptoscajachicawwds_19_tfcuecod), 15, "%");
         lV73Bancos_conceptoscajachicawwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_conceptoscajachicawwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005P2 */
         pr_default.execute(0, new Object[] {lV55Bancos_conceptoscajachicawwds_3_concajdsc1, lV55Bancos_conceptoscajachicawwds_3_concajdsc1, lV56Bancos_conceptoscajachicawwds_4_cuecod1, lV56Bancos_conceptoscajachicawwds_4_cuecod1, lV60Bancos_conceptoscajachicawwds_8_concajdsc2, lV60Bancos_conceptoscajachicawwds_8_concajdsc2, lV61Bancos_conceptoscajachicawwds_9_cuecod2, lV61Bancos_conceptoscajachicawwds_9_cuecod2, lV65Bancos_conceptoscajachicawwds_13_concajdsc3, lV65Bancos_conceptoscajachicawwds_13_concajdsc3, lV66Bancos_conceptoscajachicawwds_14_cuecod3, lV66Bancos_conceptoscajachicawwds_14_cuecod3, AV67Bancos_conceptoscajachicawwds_15_tfconcajcod, AV68Bancos_conceptoscajachicawwds_16_tfconcajcod_to, lV69Bancos_conceptoscajachicawwds_17_tfconcajdsc, AV70Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel, lV71Bancos_conceptoscajachicawwds_19_tfcuecod, AV72Bancos_conceptoscajachicawwds_20_tfcuecod_sel, lV73Bancos_conceptoscajachicawwds_21_tfcuedsc, AV74Bancos_conceptoscajachicawwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A748ConCajSts = P005P2_A748ConCajSts[0];
            A860CueDsc = P005P2_A860CueDsc[0];
            A375ConCajCod = P005P2_A375ConCajCod[0];
            A91CueCod = P005P2_A91CueCod[0];
            A747ConCajDsc = P005P2_A747ConCajDsc[0];
            A860CueDsc = P005P2_A860CueDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A375ConCajCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A747ConCajDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A91CueCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A860CueDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A748ConCajSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "ACTIVO";
            }
            else if ( A748ConCajSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Bancos.ConceptosCajaChicaWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.ConceptosCajaChicaWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Bancos.ConceptosCajaChicaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV76GXV2 = 1;
         while ( AV76GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV76GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONCAJCOD") == 0 )
            {
               AV34TFConCajCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFConCajCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONCAJDSC") == 0 )
            {
               AV36TFConCajDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONCAJDSC_SEL") == 0 )
            {
               AV37TFConCajDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV38TFCueCod = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV39TFCueCod_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV40TFCueDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV41TFCueDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONCAJSTS_SEL") == 0 )
            {
               AV42TFConCajSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV43TFConCajSts_Sels.FromJSonString(AV42TFConCajSts_SelsJson, null);
            }
            AV76GXV2 = (int)(AV76GXV2+1);
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
         AV20ConCajDsc1 = "";
         AV46CueCod1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24ConCajDsc2 = "";
         AV47CueCod2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28ConCajDsc3 = "";
         AV48CueCod3 = "";
         AV37TFConCajDsc_Sel = "";
         AV36TFConCajDsc = "";
         AV39TFCueCod_Sel = "";
         AV38TFCueCod = "";
         AV41TFCueDsc_Sel = "";
         AV40TFCueDsc = "";
         AV43TFConCajSts_Sels = new GxSimpleCollection<short>();
         AV53Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 = "";
         AV55Bancos_conceptoscajachicawwds_3_concajdsc1 = "";
         AV56Bancos_conceptoscajachicawwds_4_cuecod1 = "";
         AV58Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 = "";
         AV60Bancos_conceptoscajachicawwds_8_concajdsc2 = "";
         AV61Bancos_conceptoscajachicawwds_9_cuecod2 = "";
         AV63Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 = "";
         AV65Bancos_conceptoscajachicawwds_13_concajdsc3 = "";
         AV66Bancos_conceptoscajachicawwds_14_cuecod3 = "";
         AV69Bancos_conceptoscajachicawwds_17_tfconcajdsc = "";
         AV70Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel = "";
         AV71Bancos_conceptoscajachicawwds_19_tfcuecod = "";
         AV72Bancos_conceptoscajachicawwds_20_tfcuecod_sel = "";
         AV73Bancos_conceptoscajachicawwds_21_tfcuedsc = "";
         AV74Bancos_conceptoscajachicawwds_22_tfcuedsc_sel = "";
         AV75Bancos_conceptoscajachicawwds_23_tfconcajsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV55Bancos_conceptoscajachicawwds_3_concajdsc1 = "";
         lV56Bancos_conceptoscajachicawwds_4_cuecod1 = "";
         lV60Bancos_conceptoscajachicawwds_8_concajdsc2 = "";
         lV61Bancos_conceptoscajachicawwds_9_cuecod2 = "";
         lV65Bancos_conceptoscajachicawwds_13_concajdsc3 = "";
         lV66Bancos_conceptoscajachicawwds_14_cuecod3 = "";
         lV69Bancos_conceptoscajachicawwds_17_tfconcajdsc = "";
         lV71Bancos_conceptoscajachicawwds_19_tfcuecod = "";
         lV73Bancos_conceptoscajachicawwds_21_tfcuedsc = "";
         A747ConCajDsc = "";
         A91CueCod = "";
         A860CueDsc = "";
         P005P2_A748ConCajSts = new short[1] ;
         P005P2_A860CueDsc = new string[] {""} ;
         P005P2_A375ConCajCod = new int[1] ;
         P005P2_A91CueCod = new string[] {""} ;
         P005P2_A747ConCajDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV42TFConCajSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.conceptoscajachicawwexport__default(),
            new Object[][] {
                new Object[] {
               P005P2_A748ConCajSts, P005P2_A860CueDsc, P005P2_A375ConCajCod, P005P2_A91CueCod, P005P2_A747ConCajDsc
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
      private short AV44TFConCajSts_Sel ;
      private short AV54Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 ;
      private short AV59Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 ;
      private short AV64Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 ;
      private short A748ConCajSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFConCajCod ;
      private int AV35TFConCajCod_To ;
      private int AV51GXV1 ;
      private int AV67Bancos_conceptoscajachicawwds_15_tfconcajcod ;
      private int AV68Bancos_conceptoscajachicawwds_16_tfconcajcod_to ;
      private int AV75Bancos_conceptoscajachicawwds_23_tfconcajsts_sels_Count ;
      private int A375ConCajCod ;
      private int AV76GXV2 ;
      private long AV45i ;
      private string AV20ConCajDsc1 ;
      private string AV46CueCod1 ;
      private string AV24ConCajDsc2 ;
      private string AV47CueCod2 ;
      private string AV28ConCajDsc3 ;
      private string AV48CueCod3 ;
      private string AV37TFConCajDsc_Sel ;
      private string AV36TFConCajDsc ;
      private string AV39TFCueCod_Sel ;
      private string AV38TFCueCod ;
      private string AV41TFCueDsc_Sel ;
      private string AV40TFCueDsc ;
      private string AV55Bancos_conceptoscajachicawwds_3_concajdsc1 ;
      private string AV56Bancos_conceptoscajachicawwds_4_cuecod1 ;
      private string AV60Bancos_conceptoscajachicawwds_8_concajdsc2 ;
      private string AV61Bancos_conceptoscajachicawwds_9_cuecod2 ;
      private string AV65Bancos_conceptoscajachicawwds_13_concajdsc3 ;
      private string AV66Bancos_conceptoscajachicawwds_14_cuecod3 ;
      private string AV69Bancos_conceptoscajachicawwds_17_tfconcajdsc ;
      private string AV70Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel ;
      private string AV71Bancos_conceptoscajachicawwds_19_tfcuecod ;
      private string AV72Bancos_conceptoscajachicawwds_20_tfcuecod_sel ;
      private string AV73Bancos_conceptoscajachicawwds_21_tfcuedsc ;
      private string AV74Bancos_conceptoscajachicawwds_22_tfcuedsc_sel ;
      private string scmdbuf ;
      private string lV55Bancos_conceptoscajachicawwds_3_concajdsc1 ;
      private string lV56Bancos_conceptoscajachicawwds_4_cuecod1 ;
      private string lV60Bancos_conceptoscajachicawwds_8_concajdsc2 ;
      private string lV61Bancos_conceptoscajachicawwds_9_cuecod2 ;
      private string lV65Bancos_conceptoscajachicawwds_13_concajdsc3 ;
      private string lV66Bancos_conceptoscajachicawwds_14_cuecod3 ;
      private string lV69Bancos_conceptoscajachicawwds_17_tfconcajdsc ;
      private string lV71Bancos_conceptoscajachicawwds_19_tfcuecod ;
      private string lV73Bancos_conceptoscajachicawwds_21_tfcuedsc ;
      private string A747ConCajDsc ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV57Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 ;
      private bool AV62Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV42TFConCajSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV53Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 ;
      private string AV58Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 ;
      private string AV63Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV43TFConCajSts_Sels ;
      private GxSimpleCollection<short> AV75Bancos_conceptoscajachicawwds_23_tfconcajsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005P2_A748ConCajSts ;
      private string[] P005P2_A860CueDsc ;
      private int[] P005P2_A375ConCajCod ;
      private string[] P005P2_A91CueCod ;
      private string[] P005P2_A747ConCajDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class conceptoscajachicawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005P2( IGxContext context ,
                                             short A748ConCajSts ,
                                             GxSimpleCollection<short> AV75Bancos_conceptoscajachicawwds_23_tfconcajsts_sels ,
                                             string AV53Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 ,
                                             short AV54Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 ,
                                             string AV55Bancos_conceptoscajachicawwds_3_concajdsc1 ,
                                             string AV56Bancos_conceptoscajachicawwds_4_cuecod1 ,
                                             bool AV57Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 ,
                                             string AV58Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 ,
                                             short AV59Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 ,
                                             string AV60Bancos_conceptoscajachicawwds_8_concajdsc2 ,
                                             string AV61Bancos_conceptoscajachicawwds_9_cuecod2 ,
                                             bool AV62Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 ,
                                             string AV63Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 ,
                                             short AV64Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 ,
                                             string AV65Bancos_conceptoscajachicawwds_13_concajdsc3 ,
                                             string AV66Bancos_conceptoscajachicawwds_14_cuecod3 ,
                                             int AV67Bancos_conceptoscajachicawwds_15_tfconcajcod ,
                                             int AV68Bancos_conceptoscajachicawwds_16_tfconcajcod_to ,
                                             string AV70Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel ,
                                             string AV69Bancos_conceptoscajachicawwds_17_tfconcajdsc ,
                                             string AV72Bancos_conceptoscajachicawwds_20_tfcuecod_sel ,
                                             string AV71Bancos_conceptoscajachicawwds_19_tfcuecod ,
                                             string AV74Bancos_conceptoscajachicawwds_22_tfcuedsc_sel ,
                                             string AV73Bancos_conceptoscajachicawwds_21_tfcuedsc ,
                                             int AV75Bancos_conceptoscajachicawwds_23_tfconcajsts_sels_Count ,
                                             string A747ConCajDsc ,
                                             string A91CueCod ,
                                             int A375ConCajCod ,
                                             string A860CueDsc ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[ConCajSts], T2.[CueDsc], T1.[ConCajCod], T1.[CueCod], T1.[ConCajDsc] FROM ([TSCONCEPTOCAJA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV53Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CONCAJDSC") == 0 ) && ( AV54Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Bancos_conceptoscajachicawwds_3_concajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV55Bancos_conceptoscajachicawwds_3_concajdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CONCAJDSC") == 0 ) && ( AV54Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Bancos_conceptoscajachicawwds_3_concajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV55Bancos_conceptoscajachicawwds_3_concajdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV54Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Bancos_conceptoscajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV56Bancos_conceptoscajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV54Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Bancos_conceptoscajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV56Bancos_conceptoscajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV57Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CONCAJDSC") == 0 ) && ( AV59Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_conceptoscajachicawwds_8_concajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV60Bancos_conceptoscajachicawwds_8_concajdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV57Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CONCAJDSC") == 0 ) && ( AV59Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_conceptoscajachicawwds_8_concajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV60Bancos_conceptoscajachicawwds_8_concajdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV57Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV59Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_conceptoscajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV61Bancos_conceptoscajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV57Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV59Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_conceptoscajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV61Bancos_conceptoscajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV62Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CONCAJDSC") == 0 ) && ( AV64Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_conceptoscajachicawwds_13_concajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV65Bancos_conceptoscajachicawwds_13_concajdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV62Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CONCAJDSC") == 0 ) && ( AV64Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_conceptoscajachicawwds_13_concajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV65Bancos_conceptoscajachicawwds_13_concajdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV62Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV64Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_conceptoscajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV66Bancos_conceptoscajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV62Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV64Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_conceptoscajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV66Bancos_conceptoscajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV67Bancos_conceptoscajachicawwds_15_tfconcajcod) )
         {
            AddWhere(sWhereString, "(T1.[ConCajCod] >= @AV67Bancos_conceptoscajachicawwds_15_tfconcajcod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV68Bancos_conceptoscajachicawwds_16_tfconcajcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConCajCod] <= @AV68Bancos_conceptoscajachicawwds_16_tfconcajcod_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptoscajachicawwds_17_tfconcajdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV69Bancos_conceptoscajachicawwds_17_tfconcajdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] = @AV70Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_conceptoscajachicawwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_conceptoscajachicawwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV71Bancos_conceptoscajachicawwds_19_tfcuecod)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_conceptoscajachicawwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV72Bancos_conceptoscajachicawwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptoscajachicawwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV73Bancos_conceptoscajachicawwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV74Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV75Bancos_conceptoscajachicawwds_23_tfconcajsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Bancos_conceptoscajachicawwds_23_tfconcajsts_sels, "T1.[ConCajSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConCajCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConCajCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConCajDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConCajDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CueCod]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CueCod] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[CueDsc]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[CueDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConCajSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConCajSts] DESC";
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
                     return conditional_P005P2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP005P2;
          prmP005P2 = new Object[] {
          new ParDef("@lV55Bancos_conceptoscajachicawwds_3_concajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Bancos_conceptoscajachicawwds_3_concajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV56Bancos_conceptoscajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV56Bancos_conceptoscajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV60Bancos_conceptoscajachicawwds_8_concajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV60Bancos_conceptoscajachicawwds_8_concajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_conceptoscajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV61Bancos_conceptoscajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV65Bancos_conceptoscajachicawwds_13_concajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_conceptoscajachicawwds_13_concajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV66Bancos_conceptoscajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV66Bancos_conceptoscajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV67Bancos_conceptoscajachicawwds_15_tfconcajcod",GXType.Int32,6,0) ,
          new ParDef("@AV68Bancos_conceptoscajachicawwds_16_tfconcajcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV69Bancos_conceptoscajachicawwds_17_tfconcajdsc",GXType.NChar,100,0) ,
          new ParDef("@AV70Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV71Bancos_conceptoscajachicawwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV72Bancos_conceptoscajachicawwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV73Bancos_conceptoscajachicawwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV74Bancos_conceptoscajachicawwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005P2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
