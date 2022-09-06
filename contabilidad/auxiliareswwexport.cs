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
   public class auxiliareswwexport : GXProcedure
   {
      public auxiliareswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public auxiliareswwexport( IGxContext context )
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
         auxiliareswwexport objauxiliareswwexport;
         objauxiliareswwexport = new auxiliareswwexport();
         objauxiliareswwexport.AV11Filename = "" ;
         objauxiliareswwexport.AV12ErrorMessage = "" ;
         objauxiliareswwexport.context.SetSubmitInitialConfig(context);
         objauxiliareswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objauxiliareswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((auxiliareswwexport)stateInfo).executePrivate();
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
         AV11Filename = "AuxiliaresWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIPADDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20TipADDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TipADDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Auxiliar", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20TipADDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIPADCOD") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV44TipADCod1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TipADCod1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Auxiliar", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TipADCod1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TIPADDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24TipADDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TipADDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Auxiliar", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24TipADDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TIPADCOD") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV45TipADCod2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TipADCod2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Auxiliar", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45TipADCod2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIPADDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28TipADDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TipADDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Auxiliar", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28TipADDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIPADCOD") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV46TipADCod3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TipADCod3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Auxiliar", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Auxiliar", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TipADCod3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFTipADsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Auxiliar") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48TFTipADsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFTipADsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Auxiliar") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFTipADsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTipADCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFTipADCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTipADCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFTipADCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFTipADDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Auxiliar") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFTipADDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTipADDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Auxiliar") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFTipADDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV41TFTipADSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV43i = 1;
            AV51GXV1 = 1;
            while ( AV51GXV1 <= AV41TFTipADSts_Sels.Count )
            {
               AV42TFTipADSts_Sel = (short)(AV41TFTipADSts_Sels.GetNumeric(AV51GXV1));
               if ( AV43i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV42TFTipADSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV42TFTipADSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV43i = (long)(AV43i+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Tipo de Auxiliar";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Codigo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Auxiliar";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV53Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV54Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV55Contabilidad_auxiliareswwds_3_tipaddsc1 = AV20TipADDsc1;
         AV56Contabilidad_auxiliareswwds_4_tipadcod1 = AV44TipADCod1;
         AV57Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV58Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV59Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV60Contabilidad_auxiliareswwds_8_tipaddsc2 = AV24TipADDsc2;
         AV61Contabilidad_auxiliareswwds_9_tipadcod2 = AV45TipADCod2;
         AV62Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV63Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV64Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV65Contabilidad_auxiliareswwds_13_tipaddsc3 = AV28TipADDsc3;
         AV66Contabilidad_auxiliareswwds_14_tipadcod3 = AV46TipADCod3;
         AV67Contabilidad_auxiliareswwds_15_tftipadsc = AV47TFTipADsc;
         AV68Contabilidad_auxiliareswwds_16_tftipadsc_sel = AV48TFTipADsc_Sel;
         AV69Contabilidad_auxiliareswwds_17_tftipadcod = AV36TFTipADCod;
         AV70Contabilidad_auxiliareswwds_18_tftipadcod_sel = AV37TFTipADCod_Sel;
         AV71Contabilidad_auxiliareswwds_19_tftipaddsc = AV38TFTipADDsc;
         AV72Contabilidad_auxiliareswwds_20_tftipaddsc_sel = AV39TFTipADDsc_Sel;
         AV73Contabilidad_auxiliareswwds_21_tftipadsts_sels = AV41TFTipADSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1901TipADSts ,
                                              AV73Contabilidad_auxiliareswwds_21_tftipadsts_sels ,
                                              AV53Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ,
                                              AV54Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ,
                                              AV55Contabilidad_auxiliareswwds_3_tipaddsc1 ,
                                              AV56Contabilidad_auxiliareswwds_4_tipadcod1 ,
                                              AV57Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ,
                                              AV58Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ,
                                              AV59Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ,
                                              AV60Contabilidad_auxiliareswwds_8_tipaddsc2 ,
                                              AV61Contabilidad_auxiliareswwds_9_tipadcod2 ,
                                              AV62Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ,
                                              AV63Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ,
                                              AV64Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ,
                                              AV65Contabilidad_auxiliareswwds_13_tipaddsc3 ,
                                              AV66Contabilidad_auxiliareswwds_14_tipadcod3 ,
                                              AV68Contabilidad_auxiliareswwds_16_tftipadsc_sel ,
                                              AV67Contabilidad_auxiliareswwds_15_tftipadsc ,
                                              AV70Contabilidad_auxiliareswwds_18_tftipadcod_sel ,
                                              AV69Contabilidad_auxiliareswwds_17_tftipadcod ,
                                              AV72Contabilidad_auxiliareswwds_20_tftipaddsc_sel ,
                                              AV71Contabilidad_auxiliareswwds_19_tftipaddsc ,
                                              AV73Contabilidad_auxiliareswwds_21_tftipadsts_sels.Count ,
                                              A72TipADDsc ,
                                              A71TipADCod ,
                                              A1900TipADsc ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Contabilidad_auxiliareswwds_3_tipaddsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Contabilidad_auxiliareswwds_3_tipaddsc1), 100, "%");
         lV55Contabilidad_auxiliareswwds_3_tipaddsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Contabilidad_auxiliareswwds_3_tipaddsc1), 100, "%");
         lV56Contabilidad_auxiliareswwds_4_tipadcod1 = StringUtil.PadR( StringUtil.RTrim( AV56Contabilidad_auxiliareswwds_4_tipadcod1), 20, "%");
         lV56Contabilidad_auxiliareswwds_4_tipadcod1 = StringUtil.PadR( StringUtil.RTrim( AV56Contabilidad_auxiliareswwds_4_tipadcod1), 20, "%");
         lV60Contabilidad_auxiliareswwds_8_tipaddsc2 = StringUtil.PadR( StringUtil.RTrim( AV60Contabilidad_auxiliareswwds_8_tipaddsc2), 100, "%");
         lV60Contabilidad_auxiliareswwds_8_tipaddsc2 = StringUtil.PadR( StringUtil.RTrim( AV60Contabilidad_auxiliareswwds_8_tipaddsc2), 100, "%");
         lV61Contabilidad_auxiliareswwds_9_tipadcod2 = StringUtil.PadR( StringUtil.RTrim( AV61Contabilidad_auxiliareswwds_9_tipadcod2), 20, "%");
         lV61Contabilidad_auxiliareswwds_9_tipadcod2 = StringUtil.PadR( StringUtil.RTrim( AV61Contabilidad_auxiliareswwds_9_tipadcod2), 20, "%");
         lV65Contabilidad_auxiliareswwds_13_tipaddsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Contabilidad_auxiliareswwds_13_tipaddsc3), 100, "%");
         lV65Contabilidad_auxiliareswwds_13_tipaddsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Contabilidad_auxiliareswwds_13_tipaddsc3), 100, "%");
         lV66Contabilidad_auxiliareswwds_14_tipadcod3 = StringUtil.PadR( StringUtil.RTrim( AV66Contabilidad_auxiliareswwds_14_tipadcod3), 20, "%");
         lV66Contabilidad_auxiliareswwds_14_tipadcod3 = StringUtil.PadR( StringUtil.RTrim( AV66Contabilidad_auxiliareswwds_14_tipadcod3), 20, "%");
         lV67Contabilidad_auxiliareswwds_15_tftipadsc = StringUtil.PadR( StringUtil.RTrim( AV67Contabilidad_auxiliareswwds_15_tftipadsc), 100, "%");
         lV69Contabilidad_auxiliareswwds_17_tftipadcod = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_17_tftipadcod), 20, "%");
         lV71Contabilidad_auxiliareswwds_19_tftipaddsc = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_19_tftipaddsc), 100, "%");
         /* Using cursor P006O2 */
         pr_default.execute(0, new Object[] {lV55Contabilidad_auxiliareswwds_3_tipaddsc1, lV55Contabilidad_auxiliareswwds_3_tipaddsc1, lV56Contabilidad_auxiliareswwds_4_tipadcod1, lV56Contabilidad_auxiliareswwds_4_tipadcod1, lV60Contabilidad_auxiliareswwds_8_tipaddsc2, lV60Contabilidad_auxiliareswwds_8_tipaddsc2, lV61Contabilidad_auxiliareswwds_9_tipadcod2, lV61Contabilidad_auxiliareswwds_9_tipadcod2, lV65Contabilidad_auxiliareswwds_13_tipaddsc3, lV65Contabilidad_auxiliareswwds_13_tipaddsc3, lV66Contabilidad_auxiliareswwds_14_tipadcod3, lV66Contabilidad_auxiliareswwds_14_tipadcod3, lV67Contabilidad_auxiliareswwds_15_tftipadsc, AV68Contabilidad_auxiliareswwds_16_tftipadsc_sel, lV69Contabilidad_auxiliareswwds_17_tftipadcod, AV70Contabilidad_auxiliareswwds_18_tftipadcod_sel, lV71Contabilidad_auxiliareswwds_19_tftipaddsc, AV72Contabilidad_auxiliareswwds_20_tftipaddsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1901TipADSts = P006O2_A1901TipADSts[0];
            A1900TipADsc = P006O2_A1900TipADsc[0];
            A71TipADCod = P006O2_A71TipADCod[0];
            A72TipADDsc = P006O2_A72TipADDsc[0];
            A70TipACod = P006O2_A70TipACod[0];
            A1900TipADsc = P006O2_A1900TipADsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1900TipADsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A71TipADCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A72TipADDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A1901TipADSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "ACTIVO";
            }
            else if ( A1901TipADSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Contabilidad.AuxiliaresWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.AuxiliaresWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Contabilidad.AuxiliaresWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV74GXV2 = 1;
         while ( AV74GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV74GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPADSC") == 0 )
            {
               AV47TFTipADsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPADSC_SEL") == 0 )
            {
               AV48TFTipADsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPADCOD") == 0 )
            {
               AV36TFTipADCod = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPADCOD_SEL") == 0 )
            {
               AV37TFTipADCod_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPADDSC") == 0 )
            {
               AV38TFTipADDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPADDSC_SEL") == 0 )
            {
               AV39TFTipADDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPADSTS_SEL") == 0 )
            {
               AV40TFTipADSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV41TFTipADSts_Sels.FromJSonString(AV40TFTipADSts_SelsJson, null);
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
         AV20TipADDsc1 = "";
         AV44TipADCod1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24TipADDsc2 = "";
         AV45TipADCod2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28TipADDsc3 = "";
         AV46TipADCod3 = "";
         AV48TFTipADsc_Sel = "";
         AV47TFTipADsc = "";
         AV37TFTipADCod_Sel = "";
         AV36TFTipADCod = "";
         AV39TFTipADDsc_Sel = "";
         AV38TFTipADDsc = "";
         AV41TFTipADSts_Sels = new GxSimpleCollection<short>();
         AV53Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = "";
         AV55Contabilidad_auxiliareswwds_3_tipaddsc1 = "";
         AV56Contabilidad_auxiliareswwds_4_tipadcod1 = "";
         AV58Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = "";
         AV60Contabilidad_auxiliareswwds_8_tipaddsc2 = "";
         AV61Contabilidad_auxiliareswwds_9_tipadcod2 = "";
         AV63Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = "";
         AV65Contabilidad_auxiliareswwds_13_tipaddsc3 = "";
         AV66Contabilidad_auxiliareswwds_14_tipadcod3 = "";
         AV67Contabilidad_auxiliareswwds_15_tftipadsc = "";
         AV68Contabilidad_auxiliareswwds_16_tftipadsc_sel = "";
         AV69Contabilidad_auxiliareswwds_17_tftipadcod = "";
         AV70Contabilidad_auxiliareswwds_18_tftipadcod_sel = "";
         AV71Contabilidad_auxiliareswwds_19_tftipaddsc = "";
         AV72Contabilidad_auxiliareswwds_20_tftipaddsc_sel = "";
         AV73Contabilidad_auxiliareswwds_21_tftipadsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV55Contabilidad_auxiliareswwds_3_tipaddsc1 = "";
         lV56Contabilidad_auxiliareswwds_4_tipadcod1 = "";
         lV60Contabilidad_auxiliareswwds_8_tipaddsc2 = "";
         lV61Contabilidad_auxiliareswwds_9_tipadcod2 = "";
         lV65Contabilidad_auxiliareswwds_13_tipaddsc3 = "";
         lV66Contabilidad_auxiliareswwds_14_tipadcod3 = "";
         lV67Contabilidad_auxiliareswwds_15_tftipadsc = "";
         lV69Contabilidad_auxiliareswwds_17_tftipadcod = "";
         lV71Contabilidad_auxiliareswwds_19_tftipaddsc = "";
         A72TipADDsc = "";
         A71TipADCod = "";
         A1900TipADsc = "";
         P006O2_A1901TipADSts = new short[1] ;
         P006O2_A1900TipADsc = new string[] {""} ;
         P006O2_A71TipADCod = new string[] {""} ;
         P006O2_A72TipADDsc = new string[] {""} ;
         P006O2_A70TipACod = new int[1] ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40TFTipADSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.auxiliareswwexport__default(),
            new Object[][] {
                new Object[] {
               P006O2_A1901TipADSts, P006O2_A1900TipADsc, P006O2_A71TipADCod, P006O2_A72TipADDsc, P006O2_A70TipACod
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
      private short AV42TFTipADSts_Sel ;
      private short AV54Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ;
      private short AV59Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ;
      private short AV64Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ;
      private short A1901TipADSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV51GXV1 ;
      private int AV73Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count ;
      private int A70TipACod ;
      private int AV74GXV2 ;
      private long AV43i ;
      private string AV20TipADDsc1 ;
      private string AV44TipADCod1 ;
      private string AV24TipADDsc2 ;
      private string AV45TipADCod2 ;
      private string AV28TipADDsc3 ;
      private string AV46TipADCod3 ;
      private string AV48TFTipADsc_Sel ;
      private string AV47TFTipADsc ;
      private string AV37TFTipADCod_Sel ;
      private string AV36TFTipADCod ;
      private string AV39TFTipADDsc_Sel ;
      private string AV38TFTipADDsc ;
      private string AV55Contabilidad_auxiliareswwds_3_tipaddsc1 ;
      private string AV56Contabilidad_auxiliareswwds_4_tipadcod1 ;
      private string AV60Contabilidad_auxiliareswwds_8_tipaddsc2 ;
      private string AV61Contabilidad_auxiliareswwds_9_tipadcod2 ;
      private string AV65Contabilidad_auxiliareswwds_13_tipaddsc3 ;
      private string AV66Contabilidad_auxiliareswwds_14_tipadcod3 ;
      private string AV67Contabilidad_auxiliareswwds_15_tftipadsc ;
      private string AV68Contabilidad_auxiliareswwds_16_tftipadsc_sel ;
      private string AV69Contabilidad_auxiliareswwds_17_tftipadcod ;
      private string AV70Contabilidad_auxiliareswwds_18_tftipadcod_sel ;
      private string AV71Contabilidad_auxiliareswwds_19_tftipaddsc ;
      private string AV72Contabilidad_auxiliareswwds_20_tftipaddsc_sel ;
      private string scmdbuf ;
      private string lV55Contabilidad_auxiliareswwds_3_tipaddsc1 ;
      private string lV56Contabilidad_auxiliareswwds_4_tipadcod1 ;
      private string lV60Contabilidad_auxiliareswwds_8_tipaddsc2 ;
      private string lV61Contabilidad_auxiliareswwds_9_tipadcod2 ;
      private string lV65Contabilidad_auxiliareswwds_13_tipaddsc3 ;
      private string lV66Contabilidad_auxiliareswwds_14_tipadcod3 ;
      private string lV67Contabilidad_auxiliareswwds_15_tftipadsc ;
      private string lV69Contabilidad_auxiliareswwds_17_tftipadcod ;
      private string lV71Contabilidad_auxiliareswwds_19_tftipaddsc ;
      private string A72TipADDsc ;
      private string A71TipADCod ;
      private string A1900TipADsc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV57Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ;
      private bool AV62Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV40TFTipADSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV53Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ;
      private string AV58Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ;
      private string AV63Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV41TFTipADSts_Sels ;
      private GxSimpleCollection<short> AV73Contabilidad_auxiliareswwds_21_tftipadsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006O2_A1901TipADSts ;
      private string[] P006O2_A1900TipADsc ;
      private string[] P006O2_A71TipADCod ;
      private string[] P006O2_A72TipADDsc ;
      private int[] P006O2_A70TipACod ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class auxiliareswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006O2( IGxContext context ,
                                             short A1901TipADSts ,
                                             GxSimpleCollection<short> AV73Contabilidad_auxiliareswwds_21_tftipadsts_sels ,
                                             string AV53Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ,
                                             short AV54Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ,
                                             string AV55Contabilidad_auxiliareswwds_3_tipaddsc1 ,
                                             string AV56Contabilidad_auxiliareswwds_4_tipadcod1 ,
                                             bool AV57Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ,
                                             string AV58Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ,
                                             short AV59Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ,
                                             string AV60Contabilidad_auxiliareswwds_8_tipaddsc2 ,
                                             string AV61Contabilidad_auxiliareswwds_9_tipadcod2 ,
                                             bool AV62Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ,
                                             string AV63Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ,
                                             short AV64Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ,
                                             string AV65Contabilidad_auxiliareswwds_13_tipaddsc3 ,
                                             string AV66Contabilidad_auxiliareswwds_14_tipadcod3 ,
                                             string AV68Contabilidad_auxiliareswwds_16_tftipadsc_sel ,
                                             string AV67Contabilidad_auxiliareswwds_15_tftipadsc ,
                                             string AV70Contabilidad_auxiliareswwds_18_tftipadcod_sel ,
                                             string AV69Contabilidad_auxiliareswwds_17_tftipadcod ,
                                             string AV72Contabilidad_auxiliareswwds_20_tftipaddsc_sel ,
                                             string AV71Contabilidad_auxiliareswwds_19_tftipaddsc ,
                                             int AV73Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count ,
                                             string A72TipADDsc ,
                                             string A71TipADCod ,
                                             string A1900TipADsc ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[TipADSts], T2.[TipADsc], T1.[TipADCod], T1.[TipADDsc], T1.[TipACod] FROM ([CBAUXILIARES] T1 INNER JOIN [CBTIPAUXILIAR] T2 ON T2.[TipACod] = T1.[TipACod])";
         if ( ( StringUtil.StrCmp(AV53Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADDSC") == 0 ) && ( AV54Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Contabilidad_auxiliareswwds_3_tipaddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV55Contabilidad_auxiliareswwds_3_tipaddsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADDSC") == 0 ) && ( AV54Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Contabilidad_auxiliareswwds_3_tipaddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV55Contabilidad_auxiliareswwds_3_tipaddsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADCOD") == 0 ) && ( AV54Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Contabilidad_auxiliareswwds_4_tipadcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV56Contabilidad_auxiliareswwds_4_tipadcod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADCOD") == 0 ) && ( AV54Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Contabilidad_auxiliareswwds_4_tipadcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV56Contabilidad_auxiliareswwds_4_tipadcod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV57Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADDSC") == 0 ) && ( AV59Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Contabilidad_auxiliareswwds_8_tipaddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV60Contabilidad_auxiliareswwds_8_tipaddsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV57Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADDSC") == 0 ) && ( AV59Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Contabilidad_auxiliareswwds_8_tipaddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV60Contabilidad_auxiliareswwds_8_tipaddsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV57Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADCOD") == 0 ) && ( AV59Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Contabilidad_auxiliareswwds_9_tipadcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV61Contabilidad_auxiliareswwds_9_tipadcod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV57Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADCOD") == 0 ) && ( AV59Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Contabilidad_auxiliareswwds_9_tipadcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV61Contabilidad_auxiliareswwds_9_tipadcod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV62Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADDSC") == 0 ) && ( AV64Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_auxiliareswwds_13_tipaddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV65Contabilidad_auxiliareswwds_13_tipaddsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV62Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADDSC") == 0 ) && ( AV64Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_auxiliareswwds_13_tipaddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV65Contabilidad_auxiliareswwds_13_tipaddsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV62Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADCOD") == 0 ) && ( AV64Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_auxiliareswwds_14_tipadcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV66Contabilidad_auxiliareswwds_14_tipadcod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV62Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADCOD") == 0 ) && ( AV64Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_auxiliareswwds_14_tipadcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV66Contabilidad_auxiliareswwds_14_tipadcod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_16_tftipadsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contabilidad_auxiliareswwds_15_tftipadsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipADsc] like @lV67Contabilidad_auxiliareswwds_15_tftipadsc)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_16_tftipadsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipADsc] = @AV68Contabilidad_auxiliareswwds_16_tftipadsc_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_auxiliareswwds_18_tftipadcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_17_tftipadcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV69Contabilidad_auxiliareswwds_17_tftipadcod)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_auxiliareswwds_18_tftipadcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] = @AV70Contabilidad_auxiliareswwds_18_tftipadcod_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_20_tftipaddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_19_tftipaddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV71Contabilidad_auxiliareswwds_19_tftipaddsc)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_20_tftipaddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] = @AV72Contabilidad_auxiliareswwds_20_tftipaddsc_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV73Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Contabilidad_auxiliareswwds_21_tftipadsts_sels, "T1.[TipADSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[TipACod], T1.[TipADCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[TipADsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[TipADsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipADCod]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipADCod] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipADDsc]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipADDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipADSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipADSts] DESC";
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
                     return conditional_P006O2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP006O2;
          prmP006O2 = new Object[] {
          new ParDef("@lV55Contabilidad_auxiliareswwds_3_tipaddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Contabilidad_auxiliareswwds_3_tipaddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV56Contabilidad_auxiliareswwds_4_tipadcod1",GXType.NChar,20,0) ,
          new ParDef("@lV56Contabilidad_auxiliareswwds_4_tipadcod1",GXType.NChar,20,0) ,
          new ParDef("@lV60Contabilidad_auxiliareswwds_8_tipaddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV60Contabilidad_auxiliareswwds_8_tipaddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Contabilidad_auxiliareswwds_9_tipadcod2",GXType.NChar,20,0) ,
          new ParDef("@lV61Contabilidad_auxiliareswwds_9_tipadcod2",GXType.NChar,20,0) ,
          new ParDef("@lV65Contabilidad_auxiliareswwds_13_tipaddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV65Contabilidad_auxiliareswwds_13_tipaddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV66Contabilidad_auxiliareswwds_14_tipadcod3",GXType.NChar,20,0) ,
          new ParDef("@lV66Contabilidad_auxiliareswwds_14_tipadcod3",GXType.NChar,20,0) ,
          new ParDef("@lV67Contabilidad_auxiliareswwds_15_tftipadsc",GXType.NChar,100,0) ,
          new ParDef("@AV68Contabilidad_auxiliareswwds_16_tftipadsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV69Contabilidad_auxiliareswwds_17_tftipadcod",GXType.NChar,20,0) ,
          new ParDef("@AV70Contabilidad_auxiliareswwds_18_tftipadcod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV71Contabilidad_auxiliareswwds_19_tftipaddsc",GXType.NChar,100,0) ,
          new ParDef("@AV72Contabilidad_auxiliareswwds_20_tftipaddsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006O2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
