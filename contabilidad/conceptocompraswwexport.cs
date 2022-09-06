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
namespace GeneXus.Programs.contabilidad {
   public class conceptocompraswwexport : GXProcedure
   {
      public conceptocompraswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptocompraswwexport( IGxContext context )
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
         conceptocompraswwexport objconceptocompraswwexport;
         objconceptocompraswwexport = new conceptocompraswwexport();
         objconceptocompraswwexport.AV11Filename = "" ;
         objconceptocompraswwexport.AV12ErrorMessage = "" ;
         objconceptocompraswwexport.context.SetSubmitInitialConfig(context);
         objconceptocompraswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptocompraswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptocompraswwexport)stateInfo).executePrivate();
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
         AV11Filename = "ConceptoComprasWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CCONPDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV20CConpDsc1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20CConpDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20CConpDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CCONPCUECOD") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV47CConpCueCod1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47CConpCueCod1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47CConpCueCod1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CCONPDSC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25CConpDsc2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25CConpDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25CConpDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CCONPCUECOD") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV48CConpCueCod2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48CConpCueCod2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48CConpCueCod2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CCONPDSC") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30CConpDsc3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30CConpDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30CConpDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CCONPCUECOD") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV49CConpCueCod3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49CConpCueCod3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49CConpCueCod3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV37TFCConpCod) && (0==AV38TFCConpCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV37TFCConpCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV38TFCConpCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCConpDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Concepto") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFCConpDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCConpDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Concepto") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFCConpDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFCConpCueCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFCConpCueCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFCConpCueCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFCConpCueCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV51TFCConpSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV53i = 1;
            AV56GXV1 = 1;
            while ( AV56GXV1 <= AV51TFCConpSts_Sels.Count )
            {
               AV52TFCConpSts_Sel = (short)(AV51TFCConpSts_Sels.GetNumeric(AV56GXV1));
               if ( AV53i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV52TFCConpSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV52TFCConpSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV53i = (long)(AV53i+1);
               AV56GXV1 = (int)(AV56GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Concepto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Cuenta Contable";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV58Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV59Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV60Contabilidad_conceptocompraswwds_3_cconpdsc1 = AV20CConpDsc1;
         AV61Contabilidad_conceptocompraswwds_4_cconpcuecod1 = AV47CConpCueCod1;
         AV62Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV63Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV64Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV65Contabilidad_conceptocompraswwds_8_cconpdsc2 = AV25CConpDsc2;
         AV66Contabilidad_conceptocompraswwds_9_cconpcuecod2 = AV48CConpCueCod2;
         AV67Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV68Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV69Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV70Contabilidad_conceptocompraswwds_13_cconpdsc3 = AV30CConpDsc3;
         AV71Contabilidad_conceptocompraswwds_14_cconpcuecod3 = AV49CConpCueCod3;
         AV72Contabilidad_conceptocompraswwds_15_tfcconpcod = AV37TFCConpCod;
         AV73Contabilidad_conceptocompraswwds_16_tfcconpcod_to = AV38TFCConpCod_To;
         AV74Contabilidad_conceptocompraswwds_17_tfcconpdsc = AV39TFCConpDsc;
         AV75Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel = AV40TFCConpDsc_Sel;
         AV76Contabilidad_conceptocompraswwds_19_tfcconpcuecod = AV41TFCConpCueCod;
         AV77Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel = AV42TFCConpCueCod_Sel;
         AV78Contabilidad_conceptocompraswwds_21_tfcconpsts_sels = AV51TFCConpSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A517CConpSts ,
                                              AV78Contabilidad_conceptocompraswwds_21_tfcconpsts_sels ,
                                              AV58Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 ,
                                              AV59Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 ,
                                              AV60Contabilidad_conceptocompraswwds_3_cconpdsc1 ,
                                              AV61Contabilidad_conceptocompraswwds_4_cconpcuecod1 ,
                                              AV62Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 ,
                                              AV63Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 ,
                                              AV64Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 ,
                                              AV65Contabilidad_conceptocompraswwds_8_cconpdsc2 ,
                                              AV66Contabilidad_conceptocompraswwds_9_cconpcuecod2 ,
                                              AV67Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 ,
                                              AV68Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 ,
                                              AV69Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 ,
                                              AV70Contabilidad_conceptocompraswwds_13_cconpdsc3 ,
                                              AV71Contabilidad_conceptocompraswwds_14_cconpcuecod3 ,
                                              AV72Contabilidad_conceptocompraswwds_15_tfcconpcod ,
                                              AV73Contabilidad_conceptocompraswwds_16_tfcconpcod_to ,
                                              AV75Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel ,
                                              AV74Contabilidad_conceptocompraswwds_17_tfcconpdsc ,
                                              AV77Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel ,
                                              AV76Contabilidad_conceptocompraswwds_19_tfcconpcuecod ,
                                              AV78Contabilidad_conceptocompraswwds_21_tfcconpsts_sels.Count ,
                                              A78CConpDsc ,
                                              A77CConpCueCod ,
                                              A76CConpCod ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV60Contabilidad_conceptocompraswwds_3_cconpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Contabilidad_conceptocompraswwds_3_cconpdsc1), 100, "%");
         lV60Contabilidad_conceptocompraswwds_3_cconpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Contabilidad_conceptocompraswwds_3_cconpdsc1), 100, "%");
         lV61Contabilidad_conceptocompraswwds_4_cconpcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV61Contabilidad_conceptocompraswwds_4_cconpcuecod1), 15, "%");
         lV61Contabilidad_conceptocompraswwds_4_cconpcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV61Contabilidad_conceptocompraswwds_4_cconpcuecod1), 15, "%");
         lV65Contabilidad_conceptocompraswwds_8_cconpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Contabilidad_conceptocompraswwds_8_cconpdsc2), 100, "%");
         lV65Contabilidad_conceptocompraswwds_8_cconpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Contabilidad_conceptocompraswwds_8_cconpdsc2), 100, "%");
         lV66Contabilidad_conceptocompraswwds_9_cconpcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV66Contabilidad_conceptocompraswwds_9_cconpcuecod2), 15, "%");
         lV66Contabilidad_conceptocompraswwds_9_cconpcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV66Contabilidad_conceptocompraswwds_9_cconpcuecod2), 15, "%");
         lV70Contabilidad_conceptocompraswwds_13_cconpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Contabilidad_conceptocompraswwds_13_cconpdsc3), 100, "%");
         lV70Contabilidad_conceptocompraswwds_13_cconpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Contabilidad_conceptocompraswwds_13_cconpdsc3), 100, "%");
         lV71Contabilidad_conceptocompraswwds_14_cconpcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_conceptocompraswwds_14_cconpcuecod3), 15, "%");
         lV71Contabilidad_conceptocompraswwds_14_cconpcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_conceptocompraswwds_14_cconpcuecod3), 15, "%");
         lV74Contabilidad_conceptocompraswwds_17_tfcconpdsc = StringUtil.PadR( StringUtil.RTrim( AV74Contabilidad_conceptocompraswwds_17_tfcconpdsc), 100, "%");
         lV76Contabilidad_conceptocompraswwds_19_tfcconpcuecod = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_conceptocompraswwds_19_tfcconpcuecod), 15, "%");
         /* Using cursor P006W2 */
         pr_default.execute(0, new Object[] {lV60Contabilidad_conceptocompraswwds_3_cconpdsc1, lV60Contabilidad_conceptocompraswwds_3_cconpdsc1, lV61Contabilidad_conceptocompraswwds_4_cconpcuecod1, lV61Contabilidad_conceptocompraswwds_4_cconpcuecod1, lV65Contabilidad_conceptocompraswwds_8_cconpdsc2, lV65Contabilidad_conceptocompraswwds_8_cconpdsc2, lV66Contabilidad_conceptocompraswwds_9_cconpcuecod2, lV66Contabilidad_conceptocompraswwds_9_cconpcuecod2, lV70Contabilidad_conceptocompraswwds_13_cconpdsc3, lV70Contabilidad_conceptocompraswwds_13_cconpdsc3, lV71Contabilidad_conceptocompraswwds_14_cconpcuecod3, lV71Contabilidad_conceptocompraswwds_14_cconpcuecod3, AV72Contabilidad_conceptocompraswwds_15_tfcconpcod, AV73Contabilidad_conceptocompraswwds_16_tfcconpcod_to, lV74Contabilidad_conceptocompraswwds_17_tfcconpdsc, AV75Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel, lV76Contabilidad_conceptocompraswwds_19_tfcconpcuecod, AV77Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A517CConpSts = P006W2_A517CConpSts[0];
            A76CConpCod = P006W2_A76CConpCod[0];
            A77CConpCueCod = P006W2_A77CConpCueCod[0];
            A78CConpDsc = P006W2_A78CConpDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A76CConpCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A78CConpDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A77CConpCueCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A517CConpSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "ACTIVO";
            }
            else if ( A517CConpSts == 0 )
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
         if ( StringUtil.StrCmp(AV33Session.Get("Contabilidad.ConceptoComprasWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.ConceptoComprasWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Contabilidad.ConceptoComprasWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV79GXV2 = 1;
         while ( AV79GXV2 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV79GXV2));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCCONPCOD") == 0 )
            {
               AV37TFCConpCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV38TFCConpCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCCONPDSC") == 0 )
            {
               AV39TFCConpDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCCONPDSC_SEL") == 0 )
            {
               AV40TFCConpDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCCONPCUECOD") == 0 )
            {
               AV41TFCConpCueCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCCONPCUECOD_SEL") == 0 )
            {
               AV42TFCConpCueCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCCONPSTS_SEL") == 0 )
            {
               AV50TFCConpSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV51TFCConpSts_Sels.FromJSonString(AV50TFCConpSts_SelsJson, null);
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
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV20CConpDsc1 = "";
         AV47CConpCueCod1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25CConpDsc2 = "";
         AV48CConpCueCod2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30CConpDsc3 = "";
         AV49CConpCueCod3 = "";
         AV40TFCConpDsc_Sel = "";
         AV39TFCConpDsc = "";
         AV42TFCConpCueCod_Sel = "";
         AV41TFCConpCueCod = "";
         AV51TFCConpSts_Sels = new GxSimpleCollection<short>();
         AV58Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 = "";
         AV60Contabilidad_conceptocompraswwds_3_cconpdsc1 = "";
         AV61Contabilidad_conceptocompraswwds_4_cconpcuecod1 = "";
         AV63Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 = "";
         AV65Contabilidad_conceptocompraswwds_8_cconpdsc2 = "";
         AV66Contabilidad_conceptocompraswwds_9_cconpcuecod2 = "";
         AV68Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 = "";
         AV70Contabilidad_conceptocompraswwds_13_cconpdsc3 = "";
         AV71Contabilidad_conceptocompraswwds_14_cconpcuecod3 = "";
         AV74Contabilidad_conceptocompraswwds_17_tfcconpdsc = "";
         AV75Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel = "";
         AV76Contabilidad_conceptocompraswwds_19_tfcconpcuecod = "";
         AV77Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel = "";
         AV78Contabilidad_conceptocompraswwds_21_tfcconpsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV60Contabilidad_conceptocompraswwds_3_cconpdsc1 = "";
         lV61Contabilidad_conceptocompraswwds_4_cconpcuecod1 = "";
         lV65Contabilidad_conceptocompraswwds_8_cconpdsc2 = "";
         lV66Contabilidad_conceptocompraswwds_9_cconpcuecod2 = "";
         lV70Contabilidad_conceptocompraswwds_13_cconpdsc3 = "";
         lV71Contabilidad_conceptocompraswwds_14_cconpcuecod3 = "";
         lV74Contabilidad_conceptocompraswwds_17_tfcconpdsc = "";
         lV76Contabilidad_conceptocompraswwds_19_tfcconpcuecod = "";
         A78CConpDsc = "";
         A77CConpCueCod = "";
         P006W2_A517CConpSts = new short[1] ;
         P006W2_A76CConpCod = new int[1] ;
         P006W2_A77CConpCueCod = new string[] {""} ;
         P006W2_A78CConpDsc = new string[] {""} ;
         GXt_char1 = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV50TFCConpSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.conceptocompraswwexport__default(),
            new Object[][] {
                new Object[] {
               P006W2_A517CConpSts, P006W2_A76CConpCod, P006W2_A77CConpCueCod, P006W2_A78CConpDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV52TFCConpSts_Sel ;
      private short AV59Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 ;
      private short AV64Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 ;
      private short AV69Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 ;
      private short A517CConpSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV37TFCConpCod ;
      private int AV38TFCConpCod_To ;
      private int AV56GXV1 ;
      private int AV72Contabilidad_conceptocompraswwds_15_tfcconpcod ;
      private int AV73Contabilidad_conceptocompraswwds_16_tfcconpcod_to ;
      private int AV78Contabilidad_conceptocompraswwds_21_tfcconpsts_sels_Count ;
      private int A76CConpCod ;
      private int AV79GXV2 ;
      private long AV53i ;
      private string AV20CConpDsc1 ;
      private string AV47CConpCueCod1 ;
      private string AV25CConpDsc2 ;
      private string AV48CConpCueCod2 ;
      private string AV30CConpDsc3 ;
      private string AV49CConpCueCod3 ;
      private string AV40TFCConpDsc_Sel ;
      private string AV39TFCConpDsc ;
      private string AV42TFCConpCueCod_Sel ;
      private string AV41TFCConpCueCod ;
      private string AV60Contabilidad_conceptocompraswwds_3_cconpdsc1 ;
      private string AV61Contabilidad_conceptocompraswwds_4_cconpcuecod1 ;
      private string AV65Contabilidad_conceptocompraswwds_8_cconpdsc2 ;
      private string AV66Contabilidad_conceptocompraswwds_9_cconpcuecod2 ;
      private string AV70Contabilidad_conceptocompraswwds_13_cconpdsc3 ;
      private string AV71Contabilidad_conceptocompraswwds_14_cconpcuecod3 ;
      private string AV74Contabilidad_conceptocompraswwds_17_tfcconpdsc ;
      private string AV75Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel ;
      private string AV76Contabilidad_conceptocompraswwds_19_tfcconpcuecod ;
      private string AV77Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel ;
      private string scmdbuf ;
      private string lV60Contabilidad_conceptocompraswwds_3_cconpdsc1 ;
      private string lV61Contabilidad_conceptocompraswwds_4_cconpcuecod1 ;
      private string lV65Contabilidad_conceptocompraswwds_8_cconpdsc2 ;
      private string lV66Contabilidad_conceptocompraswwds_9_cconpcuecod2 ;
      private string lV70Contabilidad_conceptocompraswwds_13_cconpdsc3 ;
      private string lV71Contabilidad_conceptocompraswwds_14_cconpcuecod3 ;
      private string lV74Contabilidad_conceptocompraswwds_17_tfcconpdsc ;
      private string lV76Contabilidad_conceptocompraswwds_19_tfcconpcuecod ;
      private string A78CConpDsc ;
      private string A77CConpCueCod ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV62Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 ;
      private bool AV67Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV50TFCConpSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV58Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 ;
      private string AV63Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 ;
      private string AV68Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV51TFCConpSts_Sels ;
      private GxSimpleCollection<short> AV78Contabilidad_conceptocompraswwds_21_tfcconpsts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006W2_A517CConpSts ;
      private int[] P006W2_A76CConpCod ;
      private string[] P006W2_A77CConpCueCod ;
      private string[] P006W2_A78CConpDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
   }

   public class conceptocompraswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006W2( IGxContext context ,
                                             short A517CConpSts ,
                                             GxSimpleCollection<short> AV78Contabilidad_conceptocompraswwds_21_tfcconpsts_sels ,
                                             string AV58Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1 ,
                                             short AV59Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 ,
                                             string AV60Contabilidad_conceptocompraswwds_3_cconpdsc1 ,
                                             string AV61Contabilidad_conceptocompraswwds_4_cconpcuecod1 ,
                                             bool AV62Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 ,
                                             string AV63Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2 ,
                                             short AV64Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 ,
                                             string AV65Contabilidad_conceptocompraswwds_8_cconpdsc2 ,
                                             string AV66Contabilidad_conceptocompraswwds_9_cconpcuecod2 ,
                                             bool AV67Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 ,
                                             string AV68Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3 ,
                                             short AV69Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 ,
                                             string AV70Contabilidad_conceptocompraswwds_13_cconpdsc3 ,
                                             string AV71Contabilidad_conceptocompraswwds_14_cconpcuecod3 ,
                                             int AV72Contabilidad_conceptocompraswwds_15_tfcconpcod ,
                                             int AV73Contabilidad_conceptocompraswwds_16_tfcconpcod_to ,
                                             string AV75Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel ,
                                             string AV74Contabilidad_conceptocompraswwds_17_tfcconpdsc ,
                                             string AV77Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel ,
                                             string AV76Contabilidad_conceptocompraswwds_19_tfcconpcuecod ,
                                             int AV78Contabilidad_conceptocompraswwds_21_tfcconpsts_sels_Count ,
                                             string A78CConpDsc ,
                                             string A77CConpCueCod ,
                                             int A76CConpCod ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [CConpSts], [CConpCod], [CConpCueCod], [CConpDsc] FROM [CBCOMPRASCONC]";
         if ( ( StringUtil.StrCmp(AV58Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPDSC") == 0 ) && ( AV59Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Contabilidad_conceptocompraswwds_3_cconpdsc1)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV60Contabilidad_conceptocompraswwds_3_cconpdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPDSC") == 0 ) && ( AV59Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Contabilidad_conceptocompraswwds_3_cconpdsc1)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like '%' + @lV60Contabilidad_conceptocompraswwds_3_cconpdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPCUECOD") == 0 ) && ( AV59Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Contabilidad_conceptocompraswwds_4_cconpcuecod1)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV61Contabilidad_conceptocompraswwds_4_cconpcuecod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Contabilidad_conceptocompraswwds_1_dynamicfiltersselector1, "CCONPCUECOD") == 0 ) && ( AV59Contabilidad_conceptocompraswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Contabilidad_conceptocompraswwds_4_cconpcuecod1)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like '%' + @lV61Contabilidad_conceptocompraswwds_4_cconpcuecod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV62Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPDSC") == 0 ) && ( AV64Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_conceptocompraswwds_8_cconpdsc2)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV65Contabilidad_conceptocompraswwds_8_cconpdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV62Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPDSC") == 0 ) && ( AV64Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_conceptocompraswwds_8_cconpdsc2)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like '%' + @lV65Contabilidad_conceptocompraswwds_8_cconpdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV62Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPCUECOD") == 0 ) && ( AV64Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_conceptocompraswwds_9_cconpcuecod2)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV66Contabilidad_conceptocompraswwds_9_cconpcuecod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV62Contabilidad_conceptocompraswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Contabilidad_conceptocompraswwds_6_dynamicfiltersselector2, "CCONPCUECOD") == 0 ) && ( AV64Contabilidad_conceptocompraswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_conceptocompraswwds_9_cconpcuecod2)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like '%' + @lV66Contabilidad_conceptocompraswwds_9_cconpcuecod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV67Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPDSC") == 0 ) && ( AV69Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_conceptocompraswwds_13_cconpdsc3)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV70Contabilidad_conceptocompraswwds_13_cconpdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV67Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPDSC") == 0 ) && ( AV69Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_conceptocompraswwds_13_cconpdsc3)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like '%' + @lV70Contabilidad_conceptocompraswwds_13_cconpdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV67Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPCUECOD") == 0 ) && ( AV69Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_conceptocompraswwds_14_cconpcuecod3)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV71Contabilidad_conceptocompraswwds_14_cconpcuecod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV67Contabilidad_conceptocompraswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Contabilidad_conceptocompraswwds_11_dynamicfiltersselector3, "CCONPCUECOD") == 0 ) && ( AV69Contabilidad_conceptocompraswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_conceptocompraswwds_14_cconpcuecod3)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like '%' + @lV71Contabilidad_conceptocompraswwds_14_cconpcuecod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV72Contabilidad_conceptocompraswwds_15_tfcconpcod) )
         {
            AddWhere(sWhereString, "([CConpCod] >= @AV72Contabilidad_conceptocompraswwds_15_tfcconpcod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV73Contabilidad_conceptocompraswwds_16_tfcconpcod_to) )
         {
            AddWhere(sWhereString, "([CConpCod] <= @AV73Contabilidad_conceptocompraswwds_16_tfcconpcod_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_conceptocompraswwds_17_tfcconpdsc)) ) )
         {
            AddWhere(sWhereString, "([CConpDsc] like @lV74Contabilidad_conceptocompraswwds_17_tfcconpdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel)) )
         {
            AddWhere(sWhereString, "([CConpDsc] = @AV75Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_conceptocompraswwds_19_tfcconpcuecod)) ) )
         {
            AddWhere(sWhereString, "([CConpCueCod] like @lV76Contabilidad_conceptocompraswwds_19_tfcconpcuecod)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel)) )
         {
            AddWhere(sWhereString, "([CConpCueCod] = @AV77Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV78Contabilidad_conceptocompraswwds_21_tfcconpsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Contabilidad_conceptocompraswwds_21_tfcconpsts_sels, "[CConpSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CConpCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CConpCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CConpDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CConpDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CConpCueCod]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CConpCueCod] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CConpSts]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CConpSts] DESC";
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
                     return conditional_P006W2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP006W2;
          prmP006W2 = new Object[] {
          new ParDef("@lV60Contabilidad_conceptocompraswwds_3_cconpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Contabilidad_conceptocompraswwds_3_cconpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Contabilidad_conceptocompraswwds_4_cconpcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV61Contabilidad_conceptocompraswwds_4_cconpcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV65Contabilidad_conceptocompraswwds_8_cconpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Contabilidad_conceptocompraswwds_8_cconpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Contabilidad_conceptocompraswwds_9_cconpcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV66Contabilidad_conceptocompraswwds_9_cconpcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV70Contabilidad_conceptocompraswwds_13_cconpdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Contabilidad_conceptocompraswwds_13_cconpdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV71Contabilidad_conceptocompraswwds_14_cconpcuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV71Contabilidad_conceptocompraswwds_14_cconpcuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV72Contabilidad_conceptocompraswwds_15_tfcconpcod",GXType.Int32,6,0) ,
          new ParDef("@AV73Contabilidad_conceptocompraswwds_16_tfcconpcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV74Contabilidad_conceptocompraswwds_17_tfcconpdsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Contabilidad_conceptocompraswwds_18_tfcconpdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV76Contabilidad_conceptocompraswwds_19_tfcconpcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV77Contabilidad_conceptocompraswwds_20_tfcconpcuecod_sel",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006W2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
