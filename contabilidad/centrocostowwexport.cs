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
   public class centrocostowwexport : GXProcedure
   {
      public centrocostowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public centrocostowwexport( IGxContext context )
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
         centrocostowwexport objcentrocostowwexport;
         objcentrocostowwexport = new centrocostowwexport();
         objcentrocostowwexport.AV11Filename = "" ;
         objcentrocostowwexport.AV12ErrorMessage = "" ;
         objcentrocostowwexport.context.SetSubmitInitialConfig(context);
         objcentrocostowwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcentrocostowwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((centrocostowwexport)stateInfo).executePrivate();
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
         AV11Filename = "CentroCostoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "COSDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV20COSDsc1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20COSDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Centro de Costos", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Centro de Costos", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20COSDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "COSCOD") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV49COSCod1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49COSCod1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Centro Costo", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Centro Costo", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49COSCod1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "COSDSC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25COSDsc2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25COSDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Centro de Costos", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Centro de Costos", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25COSDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "COSCOD") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV50COSCod2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50COSCod2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Centro Costo", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Centro Costo", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV50COSCod2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "COSDSC") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30COSDsc3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30COSDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Centro de Costos", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Centro de Costos", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30COSDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "COSCOD") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV51COSCod3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51COSCod3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Centro Costo", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Centro Costo", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51COSCod3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCOSCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFCOSCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCOSCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFCOSCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCOSDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Centro de Costos") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFCOSDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCOSDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Centro de Costos") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFCOSDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFCOSAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFCOSAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFCOSAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFCOSAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFCOSCueDestino_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TFCOSCueDestino_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCOSCueDestino)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45TFCOSCueDestino, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV53TFCOSSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV55i = 1;
            AV58GXV1 = 1;
            while ( AV58GXV1 <= AV53TFCOSSts_Sels.Count )
            {
               AV54TFCOSSts_Sel = (short)(AV53TFCOSSts_Sels.GetNumeric(AV58GXV1));
               if ( AV55i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV54TFCOSSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV54TFCOSSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV55i = (long)(AV55i+1);
               AV58GXV1 = (int)(AV58GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Centro de Costos";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Abreviatura";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Cuenta Contable";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV60Contabilidad_centrocostowwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV61Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV62Contabilidad_centrocostowwds_3_cosdsc1 = AV20COSDsc1;
         AV63Contabilidad_centrocostowwds_4_coscod1 = AV49COSCod1;
         AV64Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV65Contabilidad_centrocostowwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV66Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV67Contabilidad_centrocostowwds_8_cosdsc2 = AV25COSDsc2;
         AV68Contabilidad_centrocostowwds_9_coscod2 = AV50COSCod2;
         AV69Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV70Contabilidad_centrocostowwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV71Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV72Contabilidad_centrocostowwds_13_cosdsc3 = AV30COSDsc3;
         AV73Contabilidad_centrocostowwds_14_coscod3 = AV51COSCod3;
         AV74Contabilidad_centrocostowwds_15_tfcoscod = AV37TFCOSCod;
         AV75Contabilidad_centrocostowwds_16_tfcoscod_sel = AV38TFCOSCod_Sel;
         AV76Contabilidad_centrocostowwds_17_tfcosdsc = AV39TFCOSDsc;
         AV77Contabilidad_centrocostowwds_18_tfcosdsc_sel = AV40TFCOSDsc_Sel;
         AV78Contabilidad_centrocostowwds_19_tfcosabr = AV41TFCOSAbr;
         AV79Contabilidad_centrocostowwds_20_tfcosabr_sel = AV42TFCOSAbr_Sel;
         AV80Contabilidad_centrocostowwds_21_tfcoscuedestino = AV45TFCOSCueDestino;
         AV81Contabilidad_centrocostowwds_22_tfcoscuedestino_sel = AV46TFCOSCueDestino_Sel;
         AV82Contabilidad_centrocostowwds_23_tfcossts_sels = AV53TFCOSSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A762COSSts ,
                                              AV82Contabilidad_centrocostowwds_23_tfcossts_sels ,
                                              AV60Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ,
                                              AV61Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ,
                                              AV62Contabilidad_centrocostowwds_3_cosdsc1 ,
                                              AV63Contabilidad_centrocostowwds_4_coscod1 ,
                                              AV64Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ,
                                              AV65Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ,
                                              AV66Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ,
                                              AV67Contabilidad_centrocostowwds_8_cosdsc2 ,
                                              AV68Contabilidad_centrocostowwds_9_coscod2 ,
                                              AV69Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ,
                                              AV70Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ,
                                              AV71Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ,
                                              AV72Contabilidad_centrocostowwds_13_cosdsc3 ,
                                              AV73Contabilidad_centrocostowwds_14_coscod3 ,
                                              AV75Contabilidad_centrocostowwds_16_tfcoscod_sel ,
                                              AV74Contabilidad_centrocostowwds_15_tfcoscod ,
                                              AV77Contabilidad_centrocostowwds_18_tfcosdsc_sel ,
                                              AV76Contabilidad_centrocostowwds_17_tfcosdsc ,
                                              AV79Contabilidad_centrocostowwds_20_tfcosabr_sel ,
                                              AV78Contabilidad_centrocostowwds_19_tfcosabr ,
                                              AV81Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ,
                                              AV80Contabilidad_centrocostowwds_21_tfcoscuedestino ,
                                              AV82Contabilidad_centrocostowwds_23_tfcossts_sels.Count ,
                                              A761COSDsc ,
                                              A79COSCod ,
                                              A759COSAbr ,
                                              A80COSCueDestino ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV62Contabilidad_centrocostowwds_3_cosdsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Contabilidad_centrocostowwds_3_cosdsc1), 100, "%");
         lV62Contabilidad_centrocostowwds_3_cosdsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Contabilidad_centrocostowwds_3_cosdsc1), 100, "%");
         lV63Contabilidad_centrocostowwds_4_coscod1 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_centrocostowwds_4_coscod1), 10, "%");
         lV63Contabilidad_centrocostowwds_4_coscod1 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_centrocostowwds_4_coscod1), 10, "%");
         lV67Contabilidad_centrocostowwds_8_cosdsc2 = StringUtil.PadR( StringUtil.RTrim( AV67Contabilidad_centrocostowwds_8_cosdsc2), 100, "%");
         lV67Contabilidad_centrocostowwds_8_cosdsc2 = StringUtil.PadR( StringUtil.RTrim( AV67Contabilidad_centrocostowwds_8_cosdsc2), 100, "%");
         lV68Contabilidad_centrocostowwds_9_coscod2 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_centrocostowwds_9_coscod2), 10, "%");
         lV68Contabilidad_centrocostowwds_9_coscod2 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_centrocostowwds_9_coscod2), 10, "%");
         lV72Contabilidad_centrocostowwds_13_cosdsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Contabilidad_centrocostowwds_13_cosdsc3), 100, "%");
         lV72Contabilidad_centrocostowwds_13_cosdsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Contabilidad_centrocostowwds_13_cosdsc3), 100, "%");
         lV73Contabilidad_centrocostowwds_14_coscod3 = StringUtil.PadR( StringUtil.RTrim( AV73Contabilidad_centrocostowwds_14_coscod3), 10, "%");
         lV73Contabilidad_centrocostowwds_14_coscod3 = StringUtil.PadR( StringUtil.RTrim( AV73Contabilidad_centrocostowwds_14_coscod3), 10, "%");
         lV74Contabilidad_centrocostowwds_15_tfcoscod = StringUtil.PadR( StringUtil.RTrim( AV74Contabilidad_centrocostowwds_15_tfcoscod), 10, "%");
         lV76Contabilidad_centrocostowwds_17_tfcosdsc = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_centrocostowwds_17_tfcosdsc), 100, "%");
         lV78Contabilidad_centrocostowwds_19_tfcosabr = StringUtil.PadR( StringUtil.RTrim( AV78Contabilidad_centrocostowwds_19_tfcosabr), 5, "%");
         lV80Contabilidad_centrocostowwds_21_tfcoscuedestino = StringUtil.PadR( StringUtil.RTrim( AV80Contabilidad_centrocostowwds_21_tfcoscuedestino), 15, "%");
         /* Using cursor P006S2 */
         pr_default.execute(0, new Object[] {lV62Contabilidad_centrocostowwds_3_cosdsc1, lV62Contabilidad_centrocostowwds_3_cosdsc1, lV63Contabilidad_centrocostowwds_4_coscod1, lV63Contabilidad_centrocostowwds_4_coscod1, lV67Contabilidad_centrocostowwds_8_cosdsc2, lV67Contabilidad_centrocostowwds_8_cosdsc2, lV68Contabilidad_centrocostowwds_9_coscod2, lV68Contabilidad_centrocostowwds_9_coscod2, lV72Contabilidad_centrocostowwds_13_cosdsc3, lV72Contabilidad_centrocostowwds_13_cosdsc3, lV73Contabilidad_centrocostowwds_14_coscod3, lV73Contabilidad_centrocostowwds_14_coscod3, lV74Contabilidad_centrocostowwds_15_tfcoscod, AV75Contabilidad_centrocostowwds_16_tfcoscod_sel, lV76Contabilidad_centrocostowwds_17_tfcosdsc, AV77Contabilidad_centrocostowwds_18_tfcosdsc_sel, lV78Contabilidad_centrocostowwds_19_tfcosabr, AV79Contabilidad_centrocostowwds_20_tfcosabr_sel, lV80Contabilidad_centrocostowwds_21_tfcoscuedestino, AV81Contabilidad_centrocostowwds_22_tfcoscuedestino_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A762COSSts = P006S2_A762COSSts[0];
            A80COSCueDestino = P006S2_A80COSCueDestino[0];
            n80COSCueDestino = P006S2_n80COSCueDestino[0];
            A759COSAbr = P006S2_A759COSAbr[0];
            A79COSCod = P006S2_A79COSCod[0];
            A761COSDsc = P006S2_A761COSDsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A79COSCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A761COSDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A759COSAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A80COSCueDestino, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A762COSSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "ACTIVO";
            }
            else if ( A762COSSts == 0 )
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
         if ( StringUtil.StrCmp(AV33Session.Get("Contabilidad.CentroCostoWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.CentroCostoWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Contabilidad.CentroCostoWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV83GXV2 = 1;
         while ( AV83GXV2 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV83GXV2));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOSCOD") == 0 )
            {
               AV37TFCOSCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOSCOD_SEL") == 0 )
            {
               AV38TFCOSCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOSDSC") == 0 )
            {
               AV39TFCOSDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOSDSC_SEL") == 0 )
            {
               AV40TFCOSDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOSABR") == 0 )
            {
               AV41TFCOSAbr = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOSABR_SEL") == 0 )
            {
               AV42TFCOSAbr_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOSCUEDESTINO") == 0 )
            {
               AV45TFCOSCueDestino = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOSCUEDESTINO_SEL") == 0 )
            {
               AV46TFCOSCueDestino_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOSSTS_SEL") == 0 )
            {
               AV52TFCOSSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV53TFCOSSts_Sels.FromJSonString(AV52TFCOSSts_SelsJson, null);
            }
            AV83GXV2 = (int)(AV83GXV2+1);
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
         AV20COSDsc1 = "";
         AV49COSCod1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25COSDsc2 = "";
         AV50COSCod2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30COSDsc3 = "";
         AV51COSCod3 = "";
         AV38TFCOSCod_Sel = "";
         AV37TFCOSCod = "";
         AV40TFCOSDsc_Sel = "";
         AV39TFCOSDsc = "";
         AV42TFCOSAbr_Sel = "";
         AV41TFCOSAbr = "";
         AV46TFCOSCueDestino_Sel = "";
         AV45TFCOSCueDestino = "";
         AV53TFCOSSts_Sels = new GxSimpleCollection<short>();
         AV60Contabilidad_centrocostowwds_1_dynamicfiltersselector1 = "";
         AV62Contabilidad_centrocostowwds_3_cosdsc1 = "";
         AV63Contabilidad_centrocostowwds_4_coscod1 = "";
         AV65Contabilidad_centrocostowwds_6_dynamicfiltersselector2 = "";
         AV67Contabilidad_centrocostowwds_8_cosdsc2 = "";
         AV68Contabilidad_centrocostowwds_9_coscod2 = "";
         AV70Contabilidad_centrocostowwds_11_dynamicfiltersselector3 = "";
         AV72Contabilidad_centrocostowwds_13_cosdsc3 = "";
         AV73Contabilidad_centrocostowwds_14_coscod3 = "";
         AV74Contabilidad_centrocostowwds_15_tfcoscod = "";
         AV75Contabilidad_centrocostowwds_16_tfcoscod_sel = "";
         AV76Contabilidad_centrocostowwds_17_tfcosdsc = "";
         AV77Contabilidad_centrocostowwds_18_tfcosdsc_sel = "";
         AV78Contabilidad_centrocostowwds_19_tfcosabr = "";
         AV79Contabilidad_centrocostowwds_20_tfcosabr_sel = "";
         AV80Contabilidad_centrocostowwds_21_tfcoscuedestino = "";
         AV81Contabilidad_centrocostowwds_22_tfcoscuedestino_sel = "";
         AV82Contabilidad_centrocostowwds_23_tfcossts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV62Contabilidad_centrocostowwds_3_cosdsc1 = "";
         lV63Contabilidad_centrocostowwds_4_coscod1 = "";
         lV67Contabilidad_centrocostowwds_8_cosdsc2 = "";
         lV68Contabilidad_centrocostowwds_9_coscod2 = "";
         lV72Contabilidad_centrocostowwds_13_cosdsc3 = "";
         lV73Contabilidad_centrocostowwds_14_coscod3 = "";
         lV74Contabilidad_centrocostowwds_15_tfcoscod = "";
         lV76Contabilidad_centrocostowwds_17_tfcosdsc = "";
         lV78Contabilidad_centrocostowwds_19_tfcosabr = "";
         lV80Contabilidad_centrocostowwds_21_tfcoscuedestino = "";
         A761COSDsc = "";
         A79COSCod = "";
         A759COSAbr = "";
         A80COSCueDestino = "";
         P006S2_A762COSSts = new short[1] ;
         P006S2_A80COSCueDestino = new string[] {""} ;
         P006S2_n80COSCueDestino = new bool[] {false} ;
         P006S2_A759COSAbr = new string[] {""} ;
         P006S2_A79COSCod = new string[] {""} ;
         P006S2_A761COSDsc = new string[] {""} ;
         GXt_char1 = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV52TFCOSSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.centrocostowwexport__default(),
            new Object[][] {
                new Object[] {
               P006S2_A762COSSts, P006S2_A80COSCueDestino, P006S2_n80COSCueDestino, P006S2_A759COSAbr, P006S2_A79COSCod, P006S2_A761COSDsc
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
      private short AV54TFCOSSts_Sel ;
      private short AV61Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ;
      private short AV66Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ;
      private short AV71Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ;
      private short A762COSSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV58GXV1 ;
      private int AV82Contabilidad_centrocostowwds_23_tfcossts_sels_Count ;
      private int AV83GXV2 ;
      private long AV55i ;
      private string AV20COSDsc1 ;
      private string AV49COSCod1 ;
      private string AV25COSDsc2 ;
      private string AV50COSCod2 ;
      private string AV30COSDsc3 ;
      private string AV51COSCod3 ;
      private string AV38TFCOSCod_Sel ;
      private string AV37TFCOSCod ;
      private string AV40TFCOSDsc_Sel ;
      private string AV39TFCOSDsc ;
      private string AV42TFCOSAbr_Sel ;
      private string AV41TFCOSAbr ;
      private string AV46TFCOSCueDestino_Sel ;
      private string AV45TFCOSCueDestino ;
      private string AV62Contabilidad_centrocostowwds_3_cosdsc1 ;
      private string AV63Contabilidad_centrocostowwds_4_coscod1 ;
      private string AV67Contabilidad_centrocostowwds_8_cosdsc2 ;
      private string AV68Contabilidad_centrocostowwds_9_coscod2 ;
      private string AV72Contabilidad_centrocostowwds_13_cosdsc3 ;
      private string AV73Contabilidad_centrocostowwds_14_coscod3 ;
      private string AV74Contabilidad_centrocostowwds_15_tfcoscod ;
      private string AV75Contabilidad_centrocostowwds_16_tfcoscod_sel ;
      private string AV76Contabilidad_centrocostowwds_17_tfcosdsc ;
      private string AV77Contabilidad_centrocostowwds_18_tfcosdsc_sel ;
      private string AV78Contabilidad_centrocostowwds_19_tfcosabr ;
      private string AV79Contabilidad_centrocostowwds_20_tfcosabr_sel ;
      private string AV80Contabilidad_centrocostowwds_21_tfcoscuedestino ;
      private string AV81Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ;
      private string scmdbuf ;
      private string lV62Contabilidad_centrocostowwds_3_cosdsc1 ;
      private string lV63Contabilidad_centrocostowwds_4_coscod1 ;
      private string lV67Contabilidad_centrocostowwds_8_cosdsc2 ;
      private string lV68Contabilidad_centrocostowwds_9_coscod2 ;
      private string lV72Contabilidad_centrocostowwds_13_cosdsc3 ;
      private string lV73Contabilidad_centrocostowwds_14_coscod3 ;
      private string lV74Contabilidad_centrocostowwds_15_tfcoscod ;
      private string lV76Contabilidad_centrocostowwds_17_tfcosdsc ;
      private string lV78Contabilidad_centrocostowwds_19_tfcosabr ;
      private string lV80Contabilidad_centrocostowwds_21_tfcoscuedestino ;
      private string A761COSDsc ;
      private string A79COSCod ;
      private string A759COSAbr ;
      private string A80COSCueDestino ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV64Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ;
      private bool AV69Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n80COSCueDestino ;
      private string AV52TFCOSSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV60Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ;
      private string AV65Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ;
      private string AV70Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV53TFCOSSts_Sels ;
      private GxSimpleCollection<short> AV82Contabilidad_centrocostowwds_23_tfcossts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006S2_A762COSSts ;
      private string[] P006S2_A80COSCueDestino ;
      private bool[] P006S2_n80COSCueDestino ;
      private string[] P006S2_A759COSAbr ;
      private string[] P006S2_A79COSCod ;
      private string[] P006S2_A761COSDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
   }

   public class centrocostowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006S2( IGxContext context ,
                                             short A762COSSts ,
                                             GxSimpleCollection<short> AV82Contabilidad_centrocostowwds_23_tfcossts_sels ,
                                             string AV60Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ,
                                             short AV61Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ,
                                             string AV62Contabilidad_centrocostowwds_3_cosdsc1 ,
                                             string AV63Contabilidad_centrocostowwds_4_coscod1 ,
                                             bool AV64Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ,
                                             string AV65Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ,
                                             short AV66Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ,
                                             string AV67Contabilidad_centrocostowwds_8_cosdsc2 ,
                                             string AV68Contabilidad_centrocostowwds_9_coscod2 ,
                                             bool AV69Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ,
                                             string AV70Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ,
                                             short AV71Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ,
                                             string AV72Contabilidad_centrocostowwds_13_cosdsc3 ,
                                             string AV73Contabilidad_centrocostowwds_14_coscod3 ,
                                             string AV75Contabilidad_centrocostowwds_16_tfcoscod_sel ,
                                             string AV74Contabilidad_centrocostowwds_15_tfcoscod ,
                                             string AV77Contabilidad_centrocostowwds_18_tfcosdsc_sel ,
                                             string AV76Contabilidad_centrocostowwds_17_tfcosdsc ,
                                             string AV79Contabilidad_centrocostowwds_20_tfcosabr_sel ,
                                             string AV78Contabilidad_centrocostowwds_19_tfcosabr ,
                                             string AV81Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ,
                                             string AV80Contabilidad_centrocostowwds_21_tfcoscuedestino ,
                                             int AV82Contabilidad_centrocostowwds_23_tfcossts_sels_Count ,
                                             string A761COSDsc ,
                                             string A79COSCod ,
                                             string A759COSAbr ,
                                             string A80COSCueDestino ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [COSSts], [COSCueDestino], [COSAbr], [COSCod], [COSDsc] FROM [CBCOSTOS]";
         if ( ( StringUtil.StrCmp(AV60Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSDSC") == 0 ) && ( AV61Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contabilidad_centrocostowwds_3_cosdsc1)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV62Contabilidad_centrocostowwds_3_cosdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSDSC") == 0 ) && ( AV61Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contabilidad_centrocostowwds_3_cosdsc1)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV62Contabilidad_centrocostowwds_3_cosdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSCOD") == 0 ) && ( AV61Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_centrocostowwds_4_coscod1)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV63Contabilidad_centrocostowwds_4_coscod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSCOD") == 0 ) && ( AV61Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_centrocostowwds_4_coscod1)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV63Contabilidad_centrocostowwds_4_coscod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV64Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSDSC") == 0 ) && ( AV66Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contabilidad_centrocostowwds_8_cosdsc2)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV67Contabilidad_centrocostowwds_8_cosdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV64Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSDSC") == 0 ) && ( AV66Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contabilidad_centrocostowwds_8_cosdsc2)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV67Contabilidad_centrocostowwds_8_cosdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV64Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSCOD") == 0 ) && ( AV66Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_centrocostowwds_9_coscod2)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV68Contabilidad_centrocostowwds_9_coscod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV64Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSCOD") == 0 ) && ( AV66Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_centrocostowwds_9_coscod2)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV68Contabilidad_centrocostowwds_9_coscod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV69Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSDSC") == 0 ) && ( AV71Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_centrocostowwds_13_cosdsc3)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV72Contabilidad_centrocostowwds_13_cosdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV69Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSDSC") == 0 ) && ( AV71Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_centrocostowwds_13_cosdsc3)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV72Contabilidad_centrocostowwds_13_cosdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV69Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSCOD") == 0 ) && ( AV71Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_centrocostowwds_14_coscod3)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV73Contabilidad_centrocostowwds_14_coscod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV69Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSCOD") == 0 ) && ( AV71Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_centrocostowwds_14_coscod3)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV73Contabilidad_centrocostowwds_14_coscod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_centrocostowwds_16_tfcoscod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_centrocostowwds_15_tfcoscod)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV74Contabilidad_centrocostowwds_15_tfcoscod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_centrocostowwds_16_tfcoscod_sel)) )
         {
            AddWhere(sWhereString, "([COSCod] = @AV75Contabilidad_centrocostowwds_16_tfcoscod_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_centrocostowwds_18_tfcosdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_centrocostowwds_17_tfcosdsc)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV76Contabilidad_centrocostowwds_17_tfcosdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_centrocostowwds_18_tfcosdsc_sel)) )
         {
            AddWhere(sWhereString, "([COSDsc] = @AV77Contabilidad_centrocostowwds_18_tfcosdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_centrocostowwds_20_tfcosabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_centrocostowwds_19_tfcosabr)) ) )
         {
            AddWhere(sWhereString, "([COSAbr] like @lV78Contabilidad_centrocostowwds_19_tfcosabr)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_centrocostowwds_20_tfcosabr_sel)) )
         {
            AddWhere(sWhereString, "([COSAbr] = @AV79Contabilidad_centrocostowwds_20_tfcosabr_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_centrocostowwds_21_tfcoscuedestino)) ) )
         {
            AddWhere(sWhereString, "([COSCueDestino] like @lV80Contabilidad_centrocostowwds_21_tfcoscuedestino)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)) )
         {
            AddWhere(sWhereString, "([COSCueDestino] = @AV81Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV82Contabilidad_centrocostowwds_23_tfcossts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Contabilidad_centrocostowwds_23_tfcossts_sels, "[COSSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [COSCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [COSCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [COSDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [COSDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [COSAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [COSAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [COSCueDestino]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [COSCueDestino] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [COSSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [COSSts] DESC";
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
                     return conditional_P006S2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP006S2;
          prmP006S2 = new Object[] {
          new ParDef("@lV62Contabilidad_centrocostowwds_3_cosdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV62Contabilidad_centrocostowwds_3_cosdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Contabilidad_centrocostowwds_4_coscod1",GXType.NChar,10,0) ,
          new ParDef("@lV63Contabilidad_centrocostowwds_4_coscod1",GXType.NChar,10,0) ,
          new ParDef("@lV67Contabilidad_centrocostowwds_8_cosdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV67Contabilidad_centrocostowwds_8_cosdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Contabilidad_centrocostowwds_9_coscod2",GXType.NChar,10,0) ,
          new ParDef("@lV68Contabilidad_centrocostowwds_9_coscod2",GXType.NChar,10,0) ,
          new ParDef("@lV72Contabilidad_centrocostowwds_13_cosdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV72Contabilidad_centrocostowwds_13_cosdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV73Contabilidad_centrocostowwds_14_coscod3",GXType.NChar,10,0) ,
          new ParDef("@lV73Contabilidad_centrocostowwds_14_coscod3",GXType.NChar,10,0) ,
          new ParDef("@lV74Contabilidad_centrocostowwds_15_tfcoscod",GXType.NChar,10,0) ,
          new ParDef("@AV75Contabilidad_centrocostowwds_16_tfcoscod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV76Contabilidad_centrocostowwds_17_tfcosdsc",GXType.NChar,100,0) ,
          new ParDef("@AV77Contabilidad_centrocostowwds_18_tfcosdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV78Contabilidad_centrocostowwds_19_tfcosabr",GXType.NChar,5,0) ,
          new ParDef("@AV79Contabilidad_centrocostowwds_20_tfcosabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV80Contabilidad_centrocostowwds_21_tfcoscuedestino",GXType.NChar,15,0) ,
          new ParDef("@AV81Contabilidad_centrocostowwds_22_tfcoscuedestino_sel",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006S2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 5);
                ((string[]) buf[4])[0] = rslt.getString(4, 10);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
