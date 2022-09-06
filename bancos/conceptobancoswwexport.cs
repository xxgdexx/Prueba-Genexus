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
   public class conceptobancoswwexport : GXProcedure
   {
      public conceptobancoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptobancoswwexport( IGxContext context )
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
         conceptobancoswwexport objconceptobancoswwexport;
         objconceptobancoswwexport = new conceptobancoswwexport();
         objconceptobancoswwexport.AV11Filename = "" ;
         objconceptobancoswwexport.AV12ErrorMessage = "" ;
         objconceptobancoswwexport.context.SetSubmitInitialConfig(context);
         objconceptobancoswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptobancoswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptobancoswwexport)stateInfo).executePrivate();
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
         AV11Filename = "ConceptoBancosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CONBDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV20ConBDsc1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ConBDsc1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20ConBDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CONBCUECOD") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV51ConBCueCod1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51ConBCueCod1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51ConBCueCod1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONBDSC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25ConBDsc2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ConBDsc2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25ConBDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONBCUECOD") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV52ConBCueCod2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52ConBCueCod2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52ConBCueCod2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CONBDSC") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30ConBDsc3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ConBDsc3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30ConBDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CONBCUECOD") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV53ConBCueCod3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53ConBCueCod3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53ConBCueCod3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV37TFConBCod) && (0==AV38TFConBCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV37TFConBCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV38TFConBCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFConBDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Concepto") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFConBDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFConBDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Concepto") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFConBDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFConBCueCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFConBCueCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFConBCueCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFConBCueCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFConBCueDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción de Cuenta") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TFConBCueDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFConBCueDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción de Cuenta") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45TFConBCueDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV48TFConBSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV50i = 1;
            AV56GXV1 = 1;
            while ( AV56GXV1 <= AV48TFConBSts_Sels.Count )
            {
               AV49TFConBSts_Sel = (short)(AV48TFConBSts_Sels.GetNumeric(AV56GXV1));
               if ( AV50i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV49TFConBSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV49TFConBSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV50i = (long)(AV50i+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Descripción de Cuenta";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV58Bancos_conceptobancoswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV59Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV60Bancos_conceptobancoswwds_3_conbdsc1 = AV20ConBDsc1;
         AV61Bancos_conceptobancoswwds_4_conbcuecod1 = AV51ConBCueCod1;
         AV62Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV63Bancos_conceptobancoswwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV64Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV65Bancos_conceptobancoswwds_8_conbdsc2 = AV25ConBDsc2;
         AV66Bancos_conceptobancoswwds_9_conbcuecod2 = AV52ConBCueCod2;
         AV67Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV68Bancos_conceptobancoswwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV69Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV70Bancos_conceptobancoswwds_13_conbdsc3 = AV30ConBDsc3;
         AV71Bancos_conceptobancoswwds_14_conbcuecod3 = AV53ConBCueCod3;
         AV72Bancos_conceptobancoswwds_15_tfconbcod = AV37TFConBCod;
         AV73Bancos_conceptobancoswwds_16_tfconbcod_to = AV38TFConBCod_To;
         AV74Bancos_conceptobancoswwds_17_tfconbdsc = AV39TFConBDsc;
         AV75Bancos_conceptobancoswwds_18_tfconbdsc_sel = AV40TFConBDsc_Sel;
         AV76Bancos_conceptobancoswwds_19_tfconbcuecod = AV41TFConBCueCod;
         AV77Bancos_conceptobancoswwds_20_tfconbcuecod_sel = AV42TFConBCueCod_Sel;
         AV78Bancos_conceptobancoswwds_21_tfconbcuedsc = AV45TFConBCueDsc;
         AV79Bancos_conceptobancoswwds_22_tfconbcuedsc_sel = AV46TFConBCueDsc_Sel;
         AV80Bancos_conceptobancoswwds_23_tfconbsts_sels = AV48TFConBSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A746ConBSts ,
                                              AV80Bancos_conceptobancoswwds_23_tfconbsts_sels ,
                                              AV58Bancos_conceptobancoswwds_1_dynamicfiltersselector1 ,
                                              AV59Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 ,
                                              AV60Bancos_conceptobancoswwds_3_conbdsc1 ,
                                              AV61Bancos_conceptobancoswwds_4_conbcuecod1 ,
                                              AV62Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 ,
                                              AV63Bancos_conceptobancoswwds_6_dynamicfiltersselector2 ,
                                              AV64Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 ,
                                              AV65Bancos_conceptobancoswwds_8_conbdsc2 ,
                                              AV66Bancos_conceptobancoswwds_9_conbcuecod2 ,
                                              AV67Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 ,
                                              AV68Bancos_conceptobancoswwds_11_dynamicfiltersselector3 ,
                                              AV69Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 ,
                                              AV70Bancos_conceptobancoswwds_13_conbdsc3 ,
                                              AV71Bancos_conceptobancoswwds_14_conbcuecod3 ,
                                              AV72Bancos_conceptobancoswwds_15_tfconbcod ,
                                              AV73Bancos_conceptobancoswwds_16_tfconbcod_to ,
                                              AV75Bancos_conceptobancoswwds_18_tfconbdsc_sel ,
                                              AV74Bancos_conceptobancoswwds_17_tfconbdsc ,
                                              AV77Bancos_conceptobancoswwds_20_tfconbcuecod_sel ,
                                              AV76Bancos_conceptobancoswwds_19_tfconbcuecod ,
                                              AV79Bancos_conceptobancoswwds_22_tfconbcuedsc_sel ,
                                              AV78Bancos_conceptobancoswwds_21_tfconbcuedsc ,
                                              AV80Bancos_conceptobancoswwds_23_tfconbsts_sels.Count ,
                                              A745ConBDsc ,
                                              A374ConBCueCod ,
                                              A355ConBCod ,
                                              A744ConBCueDsc ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV60Bancos_conceptobancoswwds_3_conbdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_conceptobancoswwds_3_conbdsc1), 100, "%");
         lV60Bancos_conceptobancoswwds_3_conbdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_conceptobancoswwds_3_conbdsc1), 100, "%");
         lV61Bancos_conceptobancoswwds_4_conbcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_conceptobancoswwds_4_conbcuecod1), 15, "%");
         lV61Bancos_conceptobancoswwds_4_conbcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_conceptobancoswwds_4_conbcuecod1), 15, "%");
         lV65Bancos_conceptobancoswwds_8_conbdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_conceptobancoswwds_8_conbdsc2), 100, "%");
         lV65Bancos_conceptobancoswwds_8_conbdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_conceptobancoswwds_8_conbdsc2), 100, "%");
         lV66Bancos_conceptobancoswwds_9_conbcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_conceptobancoswwds_9_conbcuecod2), 15, "%");
         lV66Bancos_conceptobancoswwds_9_conbcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_conceptobancoswwds_9_conbcuecod2), 15, "%");
         lV70Bancos_conceptobancoswwds_13_conbdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_conceptobancoswwds_13_conbdsc3), 100, "%");
         lV70Bancos_conceptobancoswwds_13_conbdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_conceptobancoswwds_13_conbdsc3), 100, "%");
         lV71Bancos_conceptobancoswwds_14_conbcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_conceptobancoswwds_14_conbcuecod3), 15, "%");
         lV71Bancos_conceptobancoswwds_14_conbcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_conceptobancoswwds_14_conbcuecod3), 15, "%");
         lV74Bancos_conceptobancoswwds_17_tfconbdsc = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptobancoswwds_17_tfconbdsc), 100, "%");
         lV76Bancos_conceptobancoswwds_19_tfconbcuecod = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_conceptobancoswwds_19_tfconbcuecod), 15, "%");
         lV78Bancos_conceptobancoswwds_21_tfconbcuedsc = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_conceptobancoswwds_21_tfconbcuedsc), 100, "%");
         /* Using cursor P005H2 */
         pr_default.execute(0, new Object[] {lV60Bancos_conceptobancoswwds_3_conbdsc1, lV60Bancos_conceptobancoswwds_3_conbdsc1, lV61Bancos_conceptobancoswwds_4_conbcuecod1, lV61Bancos_conceptobancoswwds_4_conbcuecod1, lV65Bancos_conceptobancoswwds_8_conbdsc2, lV65Bancos_conceptobancoswwds_8_conbdsc2, lV66Bancos_conceptobancoswwds_9_conbcuecod2, lV66Bancos_conceptobancoswwds_9_conbcuecod2, lV70Bancos_conceptobancoswwds_13_conbdsc3, lV70Bancos_conceptobancoswwds_13_conbdsc3, lV71Bancos_conceptobancoswwds_14_conbcuecod3, lV71Bancos_conceptobancoswwds_14_conbcuecod3, AV72Bancos_conceptobancoswwds_15_tfconbcod, AV73Bancos_conceptobancoswwds_16_tfconbcod_to, lV74Bancos_conceptobancoswwds_17_tfconbdsc, AV75Bancos_conceptobancoswwds_18_tfconbdsc_sel, lV76Bancos_conceptobancoswwds_19_tfconbcuecod, AV77Bancos_conceptobancoswwds_20_tfconbcuecod_sel, lV78Bancos_conceptobancoswwds_21_tfconbcuedsc, AV79Bancos_conceptobancoswwds_22_tfconbcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A746ConBSts = P005H2_A746ConBSts[0];
            A744ConBCueDsc = P005H2_A744ConBCueDsc[0];
            A355ConBCod = P005H2_A355ConBCod[0];
            A374ConBCueCod = P005H2_A374ConBCueCod[0];
            A745ConBDsc = P005H2_A745ConBDsc[0];
            A744ConBCueDsc = P005H2_A744ConBCueDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A355ConBCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A745ConBDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A374ConBCueCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A744ConBCueDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A746ConBSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "ACTIVO";
            }
            else if ( A746ConBSts == 0 )
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
         if ( StringUtil.StrCmp(AV33Session.Get("Bancos.ConceptoBancosWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.ConceptoBancosWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Bancos.ConceptoBancosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV81GXV2 = 1;
         while ( AV81GXV2 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV81GXV2));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBCOD") == 0 )
            {
               AV37TFConBCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV38TFConBCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBDSC") == 0 )
            {
               AV39TFConBDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBDSC_SEL") == 0 )
            {
               AV40TFConBDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBCUECOD") == 0 )
            {
               AV41TFConBCueCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBCUECOD_SEL") == 0 )
            {
               AV42TFConBCueCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBCUEDSC") == 0 )
            {
               AV45TFConBCueDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBCUEDSC_SEL") == 0 )
            {
               AV46TFConBCueDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBSTS_SEL") == 0 )
            {
               AV47TFConBSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV48TFConBSts_Sels.FromJSonString(AV47TFConBSts_SelsJson, null);
            }
            AV81GXV2 = (int)(AV81GXV2+1);
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
         AV20ConBDsc1 = "";
         AV51ConBCueCod1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25ConBDsc2 = "";
         AV52ConBCueCod2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30ConBDsc3 = "";
         AV53ConBCueCod3 = "";
         AV40TFConBDsc_Sel = "";
         AV39TFConBDsc = "";
         AV42TFConBCueCod_Sel = "";
         AV41TFConBCueCod = "";
         AV46TFConBCueDsc_Sel = "";
         AV45TFConBCueDsc = "";
         AV48TFConBSts_Sels = new GxSimpleCollection<short>();
         AV58Bancos_conceptobancoswwds_1_dynamicfiltersselector1 = "";
         AV60Bancos_conceptobancoswwds_3_conbdsc1 = "";
         AV61Bancos_conceptobancoswwds_4_conbcuecod1 = "";
         AV63Bancos_conceptobancoswwds_6_dynamicfiltersselector2 = "";
         AV65Bancos_conceptobancoswwds_8_conbdsc2 = "";
         AV66Bancos_conceptobancoswwds_9_conbcuecod2 = "";
         AV68Bancos_conceptobancoswwds_11_dynamicfiltersselector3 = "";
         AV70Bancos_conceptobancoswwds_13_conbdsc3 = "";
         AV71Bancos_conceptobancoswwds_14_conbcuecod3 = "";
         AV74Bancos_conceptobancoswwds_17_tfconbdsc = "";
         AV75Bancos_conceptobancoswwds_18_tfconbdsc_sel = "";
         AV76Bancos_conceptobancoswwds_19_tfconbcuecod = "";
         AV77Bancos_conceptobancoswwds_20_tfconbcuecod_sel = "";
         AV78Bancos_conceptobancoswwds_21_tfconbcuedsc = "";
         AV79Bancos_conceptobancoswwds_22_tfconbcuedsc_sel = "";
         AV80Bancos_conceptobancoswwds_23_tfconbsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV60Bancos_conceptobancoswwds_3_conbdsc1 = "";
         lV61Bancos_conceptobancoswwds_4_conbcuecod1 = "";
         lV65Bancos_conceptobancoswwds_8_conbdsc2 = "";
         lV66Bancos_conceptobancoswwds_9_conbcuecod2 = "";
         lV70Bancos_conceptobancoswwds_13_conbdsc3 = "";
         lV71Bancos_conceptobancoswwds_14_conbcuecod3 = "";
         lV74Bancos_conceptobancoswwds_17_tfconbdsc = "";
         lV76Bancos_conceptobancoswwds_19_tfconbcuecod = "";
         lV78Bancos_conceptobancoswwds_21_tfconbcuedsc = "";
         A745ConBDsc = "";
         A374ConBCueCod = "";
         A744ConBCueDsc = "";
         P005H2_A746ConBSts = new short[1] ;
         P005H2_A744ConBCueDsc = new string[] {""} ;
         P005H2_A355ConBCod = new int[1] ;
         P005H2_A374ConBCueCod = new string[] {""} ;
         P005H2_A745ConBDsc = new string[] {""} ;
         GXt_char1 = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47TFConBSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.conceptobancoswwexport__default(),
            new Object[][] {
                new Object[] {
               P005H2_A746ConBSts, P005H2_A744ConBCueDsc, P005H2_A355ConBCod, P005H2_A374ConBCueCod, P005H2_A745ConBDsc
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
      private short AV49TFConBSts_Sel ;
      private short AV59Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 ;
      private short AV64Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 ;
      private short AV69Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 ;
      private short A746ConBSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV37TFConBCod ;
      private int AV38TFConBCod_To ;
      private int AV56GXV1 ;
      private int AV72Bancos_conceptobancoswwds_15_tfconbcod ;
      private int AV73Bancos_conceptobancoswwds_16_tfconbcod_to ;
      private int AV80Bancos_conceptobancoswwds_23_tfconbsts_sels_Count ;
      private int A355ConBCod ;
      private int AV81GXV2 ;
      private long AV50i ;
      private string AV20ConBDsc1 ;
      private string AV51ConBCueCod1 ;
      private string AV25ConBDsc2 ;
      private string AV52ConBCueCod2 ;
      private string AV30ConBDsc3 ;
      private string AV53ConBCueCod3 ;
      private string AV40TFConBDsc_Sel ;
      private string AV39TFConBDsc ;
      private string AV42TFConBCueCod_Sel ;
      private string AV41TFConBCueCod ;
      private string AV46TFConBCueDsc_Sel ;
      private string AV45TFConBCueDsc ;
      private string AV60Bancos_conceptobancoswwds_3_conbdsc1 ;
      private string AV61Bancos_conceptobancoswwds_4_conbcuecod1 ;
      private string AV65Bancos_conceptobancoswwds_8_conbdsc2 ;
      private string AV66Bancos_conceptobancoswwds_9_conbcuecod2 ;
      private string AV70Bancos_conceptobancoswwds_13_conbdsc3 ;
      private string AV71Bancos_conceptobancoswwds_14_conbcuecod3 ;
      private string AV74Bancos_conceptobancoswwds_17_tfconbdsc ;
      private string AV75Bancos_conceptobancoswwds_18_tfconbdsc_sel ;
      private string AV76Bancos_conceptobancoswwds_19_tfconbcuecod ;
      private string AV77Bancos_conceptobancoswwds_20_tfconbcuecod_sel ;
      private string AV78Bancos_conceptobancoswwds_21_tfconbcuedsc ;
      private string AV79Bancos_conceptobancoswwds_22_tfconbcuedsc_sel ;
      private string scmdbuf ;
      private string lV60Bancos_conceptobancoswwds_3_conbdsc1 ;
      private string lV61Bancos_conceptobancoswwds_4_conbcuecod1 ;
      private string lV65Bancos_conceptobancoswwds_8_conbdsc2 ;
      private string lV66Bancos_conceptobancoswwds_9_conbcuecod2 ;
      private string lV70Bancos_conceptobancoswwds_13_conbdsc3 ;
      private string lV71Bancos_conceptobancoswwds_14_conbcuecod3 ;
      private string lV74Bancos_conceptobancoswwds_17_tfconbdsc ;
      private string lV76Bancos_conceptobancoswwds_19_tfconbcuecod ;
      private string lV78Bancos_conceptobancoswwds_21_tfconbcuedsc ;
      private string A745ConBDsc ;
      private string A374ConBCueCod ;
      private string A744ConBCueDsc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV62Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 ;
      private bool AV67Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV47TFConBSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV58Bancos_conceptobancoswwds_1_dynamicfiltersselector1 ;
      private string AV63Bancos_conceptobancoswwds_6_dynamicfiltersselector2 ;
      private string AV68Bancos_conceptobancoswwds_11_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV48TFConBSts_Sels ;
      private GxSimpleCollection<short> AV80Bancos_conceptobancoswwds_23_tfconbsts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005H2_A746ConBSts ;
      private string[] P005H2_A744ConBCueDsc ;
      private int[] P005H2_A355ConBCod ;
      private string[] P005H2_A374ConBCueCod ;
      private string[] P005H2_A745ConBDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
   }

   public class conceptobancoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005H2( IGxContext context ,
                                             short A746ConBSts ,
                                             GxSimpleCollection<short> AV80Bancos_conceptobancoswwds_23_tfconbsts_sels ,
                                             string AV58Bancos_conceptobancoswwds_1_dynamicfiltersselector1 ,
                                             short AV59Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV60Bancos_conceptobancoswwds_3_conbdsc1 ,
                                             string AV61Bancos_conceptobancoswwds_4_conbcuecod1 ,
                                             bool AV62Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 ,
                                             string AV63Bancos_conceptobancoswwds_6_dynamicfiltersselector2 ,
                                             short AV64Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 ,
                                             string AV65Bancos_conceptobancoswwds_8_conbdsc2 ,
                                             string AV66Bancos_conceptobancoswwds_9_conbcuecod2 ,
                                             bool AV67Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 ,
                                             string AV68Bancos_conceptobancoswwds_11_dynamicfiltersselector3 ,
                                             short AV69Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 ,
                                             string AV70Bancos_conceptobancoswwds_13_conbdsc3 ,
                                             string AV71Bancos_conceptobancoswwds_14_conbcuecod3 ,
                                             int AV72Bancos_conceptobancoswwds_15_tfconbcod ,
                                             int AV73Bancos_conceptobancoswwds_16_tfconbcod_to ,
                                             string AV75Bancos_conceptobancoswwds_18_tfconbdsc_sel ,
                                             string AV74Bancos_conceptobancoswwds_17_tfconbdsc ,
                                             string AV77Bancos_conceptobancoswwds_20_tfconbcuecod_sel ,
                                             string AV76Bancos_conceptobancoswwds_19_tfconbcuecod ,
                                             string AV79Bancos_conceptobancoswwds_22_tfconbcuedsc_sel ,
                                             string AV78Bancos_conceptobancoswwds_21_tfconbcuedsc ,
                                             int AV80Bancos_conceptobancoswwds_23_tfconbsts_sels_Count ,
                                             string A745ConBDsc ,
                                             string A374ConBCueCod ,
                                             int A355ConBCod ,
                                             string A744ConBCueDsc ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[ConBSts], T2.[CueDsc] AS ConBCueDsc, T1.[ConBCod], T1.[ConBCueCod] AS ConBCueCod, T1.[ConBDsc] FROM ([TSCONCEPTOBANCOS] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[ConBCueCod])";
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBDSC") == 0 ) && ( AV59Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_conceptobancoswwds_3_conbdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV60Bancos_conceptobancoswwds_3_conbdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBDSC") == 0 ) && ( AV59Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_conceptobancoswwds_3_conbdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV60Bancos_conceptobancoswwds_3_conbdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBCUECOD") == 0 ) && ( AV59Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_conceptobancoswwds_4_conbcuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV61Bancos_conceptobancoswwds_4_conbcuecod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBCUECOD") == 0 ) && ( AV59Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_conceptobancoswwds_4_conbcuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV61Bancos_conceptobancoswwds_4_conbcuecod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV62Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBDSC") == 0 ) && ( AV64Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_conceptobancoswwds_8_conbdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV65Bancos_conceptobancoswwds_8_conbdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV62Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBDSC") == 0 ) && ( AV64Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_conceptobancoswwds_8_conbdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV65Bancos_conceptobancoswwds_8_conbdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV62Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBCUECOD") == 0 ) && ( AV64Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_conceptobancoswwds_9_conbcuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV66Bancos_conceptobancoswwds_9_conbcuecod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV62Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBCUECOD") == 0 ) && ( AV64Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_conceptobancoswwds_9_conbcuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV66Bancos_conceptobancoswwds_9_conbcuecod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV67Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBDSC") == 0 ) && ( AV69Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_conceptobancoswwds_13_conbdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV70Bancos_conceptobancoswwds_13_conbdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV67Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBDSC") == 0 ) && ( AV69Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_conceptobancoswwds_13_conbdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV70Bancos_conceptobancoswwds_13_conbdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV67Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBCUECOD") == 0 ) && ( AV69Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_conceptobancoswwds_14_conbcuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV71Bancos_conceptobancoswwds_14_conbcuecod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV67Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBCUECOD") == 0 ) && ( AV69Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_conceptobancoswwds_14_conbcuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV71Bancos_conceptobancoswwds_14_conbcuecod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV72Bancos_conceptobancoswwds_15_tfconbcod) )
         {
            AddWhere(sWhereString, "(T1.[ConBCod] >= @AV72Bancos_conceptobancoswwds_15_tfconbcod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV73Bancos_conceptobancoswwds_16_tfconbcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConBCod] <= @AV73Bancos_conceptobancoswwds_16_tfconbcod_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptobancoswwds_18_tfconbdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptobancoswwds_17_tfconbdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV74Bancos_conceptobancoswwds_17_tfconbdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptobancoswwds_18_tfconbdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] = @AV75Bancos_conceptobancoswwds_18_tfconbdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptobancoswwds_20_tfconbcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptobancoswwds_19_tfconbcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV76Bancos_conceptobancoswwds_19_tfconbcuecod)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptobancoswwds_20_tfconbcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] = @AV77Bancos_conceptobancoswwds_20_tfconbcuecod_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_conceptobancoswwds_21_tfconbcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV78Bancos_conceptobancoswwds_21_tfconbcuedsc)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV79Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV80Bancos_conceptobancoswwds_23_tfconbsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV80Bancos_conceptobancoswwds_23_tfconbsts_sels, "T1.[ConBSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConBCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConBCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConBDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConBDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConBCueCod]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConBCueCod] DESC";
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
            scmdbuf += " ORDER BY T1.[ConBSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConBSts] DESC";
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
                     return conditional_P005H2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP005H2;
          prmP005H2 = new Object[] {
          new ParDef("@lV60Bancos_conceptobancoswwds_3_conbdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Bancos_conceptobancoswwds_3_conbdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_conceptobancoswwds_4_conbcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV61Bancos_conceptobancoswwds_4_conbcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV65Bancos_conceptobancoswwds_8_conbdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_conceptobancoswwds_8_conbdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Bancos_conceptobancoswwds_9_conbcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV66Bancos_conceptobancoswwds_9_conbcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV70Bancos_conceptobancoswwds_13_conbdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_conceptobancoswwds_13_conbdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV71Bancos_conceptobancoswwds_14_conbcuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV71Bancos_conceptobancoswwds_14_conbcuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV72Bancos_conceptobancoswwds_15_tfconbcod",GXType.Int32,6,0) ,
          new ParDef("@AV73Bancos_conceptobancoswwds_16_tfconbcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV74Bancos_conceptobancoswwds_17_tfconbdsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Bancos_conceptobancoswwds_18_tfconbdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV76Bancos_conceptobancoswwds_19_tfconbcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV77Bancos_conceptobancoswwds_20_tfconbcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV78Bancos_conceptobancoswwds_21_tfconbcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV79Bancos_conceptobancoswwds_22_tfconbcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005H2,100, GxCacheFrequency.OFF ,true,false )
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
