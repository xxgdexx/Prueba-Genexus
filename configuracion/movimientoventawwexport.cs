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
   public class movimientoventawwexport : GXProcedure
   {
      public movimientoventawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public movimientoventawwexport( IGxContext context )
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
         movimientoventawwexport objmovimientoventawwexport;
         objmovimientoventawwexport = new movimientoventawwexport();
         objmovimientoventawwexport.AV11Filename = "" ;
         objmovimientoventawwexport.AV12ErrorMessage = "" ;
         objmovimientoventawwexport.context.SetSubmitInitialConfig(context);
         objmovimientoventawwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmovimientoventawwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((movimientoventawwexport)stateInfo).executePrivate();
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
         AV11Filename = "MovimientoVentaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MOVVDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20MovVDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20MovVDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Movimiento de Venta", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Movimiento de Venta", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20MovVDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MOVVTIP") == 0 )
            {
               AV48MovVTip1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48MovVTip1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Credito / Debito";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV48MovVTip1), "C") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Credito";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV48MovVTip1), "D") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Debito";
                  }
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "MOVVDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24MovVDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24MovVDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Movimiento de Venta", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Movimiento de Venta", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24MovVDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "MOVVTIP") == 0 )
               {
                  AV49MovVTip2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49MovVTip2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Credito / Debito";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( AV49MovVTip2), "C") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Credito";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV49MovVTip2), "D") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Debito";
                     }
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "MOVVDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28MovVDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28MovVDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Movimiento de Venta", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Movimiento de Venta", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28MovVDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "MOVVTIP") == 0 )
                  {
                     AV50MovVTip3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50MovVTip3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Credito / Debito";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV50MovVTip3), "C") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Credito";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV50MovVTip3), "D") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Debito";
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFMovVCod) && (0==AV35TFMovVCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFMovVCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFMovVCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFMovVDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Movimiento de Venta") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFMovVDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFMovVDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Movimiento de Venta") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFMovVDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV39TFMovVAbr_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Afecta Unidades") ;
            AV13CellRow = GXt_int2;
            AV47i = 1;
            AV53GXV1 = 1;
            while ( AV53GXV1 <= AV39TFMovVAbr_Sels.Count )
            {
               AV40TFMovVAbr_Sel = AV39TFMovVAbr_Sels.GetString(AV53GXV1);
               if ( AV47i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV40TFMovVAbr_Sel), "SI") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"SI";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV40TFMovVAbr_Sel), "NO") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"NO";
               }
               AV47i = (long)(AV47i+1);
               AV53GXV1 = (int)(AV53GXV1+1);
            }
         }
         if ( ! ( ( AV42TFMovVTip_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cargo / Abono") ;
            AV13CellRow = GXt_int2;
            AV47i = 1;
            AV54GXV2 = 1;
            while ( AV54GXV2 <= AV42TFMovVTip_Sels.Count )
            {
               AV43TFMovVTip_Sel = AV42TFMovVTip_Sels.GetString(AV54GXV2);
               if ( AV47i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV43TFMovVTip_Sel), "C") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Credito";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV43TFMovVTip_Sel), "D") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Debito";
               }
               AV47i = (long)(AV47i+1);
               AV54GXV2 = (int)(AV54GXV2+1);
            }
         }
         if ( ! ( ( AV45TFMovVSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV47i = 1;
            AV55GXV3 = 1;
            while ( AV55GXV3 <= AV45TFMovVSts_Sels.Count )
            {
               AV46TFMovVSts_Sel = (short)(AV45TFMovVSts_Sels.GetNumeric(AV55GXV3));
               if ( AV47i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV46TFMovVSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV46TFMovVSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV47i = (long)(AV47i+1);
               AV55GXV3 = (int)(AV55GXV3+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Movimiento de Venta";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Afecta Unidades";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Cargo / Abono";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV57Configuracion_movimientoventawwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV58Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV59Configuracion_movimientoventawwds_3_movvdsc1 = AV20MovVDsc1;
         AV60Configuracion_movimientoventawwds_4_movvtip1 = AV48MovVTip1;
         AV61Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV62Configuracion_movimientoventawwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV63Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV64Configuracion_movimientoventawwds_8_movvdsc2 = AV24MovVDsc2;
         AV65Configuracion_movimientoventawwds_9_movvtip2 = AV49MovVTip2;
         AV66Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV67Configuracion_movimientoventawwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV68Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV69Configuracion_movimientoventawwds_13_movvdsc3 = AV28MovVDsc3;
         AV70Configuracion_movimientoventawwds_14_movvtip3 = AV50MovVTip3;
         AV71Configuracion_movimientoventawwds_15_tfmovvcod = AV34TFMovVCod;
         AV72Configuracion_movimientoventawwds_16_tfmovvcod_to = AV35TFMovVCod_To;
         AV73Configuracion_movimientoventawwds_17_tfmovvdsc = AV36TFMovVDsc;
         AV74Configuracion_movimientoventawwds_18_tfmovvdsc_sel = AV37TFMovVDsc_Sel;
         AV75Configuracion_movimientoventawwds_19_tfmovvabr_sels = AV39TFMovVAbr_Sels;
         AV76Configuracion_movimientoventawwds_20_tfmovvtip_sels = AV42TFMovVTip_Sels;
         AV77Configuracion_movimientoventawwds_21_tfmovvsts_sels = AV45TFMovVSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1242MovVAbr ,
                                              AV75Configuracion_movimientoventawwds_19_tfmovvabr_sels ,
                                              A1245MovVTip ,
                                              AV76Configuracion_movimientoventawwds_20_tfmovvtip_sels ,
                                              A1244MovVSts ,
                                              AV77Configuracion_movimientoventawwds_21_tfmovvsts_sels ,
                                              AV57Configuracion_movimientoventawwds_1_dynamicfiltersselector1 ,
                                              AV58Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 ,
                                              AV59Configuracion_movimientoventawwds_3_movvdsc1 ,
                                              AV60Configuracion_movimientoventawwds_4_movvtip1 ,
                                              AV61Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 ,
                                              AV62Configuracion_movimientoventawwds_6_dynamicfiltersselector2 ,
                                              AV63Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 ,
                                              AV64Configuracion_movimientoventawwds_8_movvdsc2 ,
                                              AV65Configuracion_movimientoventawwds_9_movvtip2 ,
                                              AV66Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 ,
                                              AV67Configuracion_movimientoventawwds_11_dynamicfiltersselector3 ,
                                              AV68Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 ,
                                              AV69Configuracion_movimientoventawwds_13_movvdsc3 ,
                                              AV70Configuracion_movimientoventawwds_14_movvtip3 ,
                                              AV71Configuracion_movimientoventawwds_15_tfmovvcod ,
                                              AV72Configuracion_movimientoventawwds_16_tfmovvcod_to ,
                                              AV74Configuracion_movimientoventawwds_18_tfmovvdsc_sel ,
                                              AV73Configuracion_movimientoventawwds_17_tfmovvdsc ,
                                              AV75Configuracion_movimientoventawwds_19_tfmovvabr_sels.Count ,
                                              AV76Configuracion_movimientoventawwds_20_tfmovvtip_sels.Count ,
                                              AV77Configuracion_movimientoventawwds_21_tfmovvsts_sels.Count ,
                                              A1243MovVDsc ,
                                              A235MovVCod ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Configuracion_movimientoventawwds_3_movvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_movimientoventawwds_3_movvdsc1), 100, "%");
         lV59Configuracion_movimientoventawwds_3_movvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_movimientoventawwds_3_movvdsc1), 100, "%");
         lV64Configuracion_movimientoventawwds_8_movvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_movimientoventawwds_8_movvdsc2), 100, "%");
         lV64Configuracion_movimientoventawwds_8_movvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_movimientoventawwds_8_movvdsc2), 100, "%");
         lV69Configuracion_movimientoventawwds_13_movvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_movimientoventawwds_13_movvdsc3), 100, "%");
         lV69Configuracion_movimientoventawwds_13_movvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_movimientoventawwds_13_movvdsc3), 100, "%");
         lV73Configuracion_movimientoventawwds_17_tfmovvdsc = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_movimientoventawwds_17_tfmovvdsc), 100, "%");
         /* Using cursor P003F2 */
         pr_default.execute(0, new Object[] {lV59Configuracion_movimientoventawwds_3_movvdsc1, lV59Configuracion_movimientoventawwds_3_movvdsc1, AV60Configuracion_movimientoventawwds_4_movvtip1, lV64Configuracion_movimientoventawwds_8_movvdsc2, lV64Configuracion_movimientoventawwds_8_movvdsc2, AV65Configuracion_movimientoventawwds_9_movvtip2, lV69Configuracion_movimientoventawwds_13_movvdsc3, lV69Configuracion_movimientoventawwds_13_movvdsc3, AV70Configuracion_movimientoventawwds_14_movvtip3, AV71Configuracion_movimientoventawwds_15_tfmovvcod, AV72Configuracion_movimientoventawwds_16_tfmovvcod_to, lV73Configuracion_movimientoventawwds_17_tfmovvdsc, AV74Configuracion_movimientoventawwds_18_tfmovvdsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1244MovVSts = P003F2_A1244MovVSts[0];
            A1242MovVAbr = P003F2_A1242MovVAbr[0];
            A235MovVCod = P003F2_A235MovVCod[0];
            A1245MovVTip = P003F2_A1245MovVTip[0];
            A1243MovVDsc = P003F2_A1243MovVDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A235MovVCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1243MovVDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( A1242MovVAbr), "SI") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "SI";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A1242MovVAbr), "NO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "NO";
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( A1245MovVTip), "C") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Credito";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A1245MovVTip), "D") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Debito";
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A1244MovVSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "ACTIVO";
            }
            else if ( A1244MovVSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.MovimientoVentaWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.MovimientoVentaWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.MovimientoVentaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV78GXV4 = 1;
         while ( AV78GXV4 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV78GXV4));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMOVVCOD") == 0 )
            {
               AV34TFMovVCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFMovVCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMOVVDSC") == 0 )
            {
               AV36TFMovVDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMOVVDSC_SEL") == 0 )
            {
               AV37TFMovVDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMOVVABR_SEL") == 0 )
            {
               AV38TFMovVAbr_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV39TFMovVAbr_Sels.FromJSonString(AV38TFMovVAbr_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMOVVTIP_SEL") == 0 )
            {
               AV41TFMovVTip_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV42TFMovVTip_Sels.FromJSonString(AV41TFMovVTip_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMOVVSTS_SEL") == 0 )
            {
               AV44TFMovVSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV45TFMovVSts_Sels.FromJSonString(AV44TFMovVSts_SelsJson, null);
            }
            AV78GXV4 = (int)(AV78GXV4+1);
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
         AV20MovVDsc1 = "";
         AV48MovVTip1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24MovVDsc2 = "";
         AV49MovVTip2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28MovVDsc3 = "";
         AV50MovVTip3 = "";
         AV37TFMovVDsc_Sel = "";
         AV36TFMovVDsc = "";
         AV39TFMovVAbr_Sels = new GxSimpleCollection<string>();
         AV40TFMovVAbr_Sel = "";
         AV42TFMovVTip_Sels = new GxSimpleCollection<string>();
         AV43TFMovVTip_Sel = "";
         AV45TFMovVSts_Sels = new GxSimpleCollection<short>();
         AV57Configuracion_movimientoventawwds_1_dynamicfiltersselector1 = "";
         AV59Configuracion_movimientoventawwds_3_movvdsc1 = "";
         AV60Configuracion_movimientoventawwds_4_movvtip1 = "";
         AV62Configuracion_movimientoventawwds_6_dynamicfiltersselector2 = "";
         AV64Configuracion_movimientoventawwds_8_movvdsc2 = "";
         AV65Configuracion_movimientoventawwds_9_movvtip2 = "";
         AV67Configuracion_movimientoventawwds_11_dynamicfiltersselector3 = "";
         AV69Configuracion_movimientoventawwds_13_movvdsc3 = "";
         AV70Configuracion_movimientoventawwds_14_movvtip3 = "";
         AV73Configuracion_movimientoventawwds_17_tfmovvdsc = "";
         AV74Configuracion_movimientoventawwds_18_tfmovvdsc_sel = "";
         AV75Configuracion_movimientoventawwds_19_tfmovvabr_sels = new GxSimpleCollection<string>();
         AV76Configuracion_movimientoventawwds_20_tfmovvtip_sels = new GxSimpleCollection<string>();
         AV77Configuracion_movimientoventawwds_21_tfmovvsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV59Configuracion_movimientoventawwds_3_movvdsc1 = "";
         lV64Configuracion_movimientoventawwds_8_movvdsc2 = "";
         lV69Configuracion_movimientoventawwds_13_movvdsc3 = "";
         lV73Configuracion_movimientoventawwds_17_tfmovvdsc = "";
         A1242MovVAbr = "";
         A1245MovVTip = "";
         A1243MovVDsc = "";
         P003F2_A1244MovVSts = new short[1] ;
         P003F2_A1242MovVAbr = new string[] {""} ;
         P003F2_A235MovVCod = new int[1] ;
         P003F2_A1245MovVTip = new string[] {""} ;
         P003F2_A1243MovVDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38TFMovVAbr_SelsJson = "";
         AV41TFMovVTip_SelsJson = "";
         AV44TFMovVSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.movimientoventawwexport__default(),
            new Object[][] {
                new Object[] {
               P003F2_A1244MovVSts, P003F2_A1242MovVAbr, P003F2_A235MovVCod, P003F2_A1245MovVTip, P003F2_A1243MovVDsc
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
      private short AV46TFMovVSts_Sel ;
      private short AV58Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 ;
      private short AV63Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 ;
      private short AV68Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 ;
      private short A1244MovVSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFMovVCod ;
      private int AV35TFMovVCod_To ;
      private int AV53GXV1 ;
      private int AV54GXV2 ;
      private int AV55GXV3 ;
      private int AV71Configuracion_movimientoventawwds_15_tfmovvcod ;
      private int AV72Configuracion_movimientoventawwds_16_tfmovvcod_to ;
      private int AV75Configuracion_movimientoventawwds_19_tfmovvabr_sels_Count ;
      private int AV76Configuracion_movimientoventawwds_20_tfmovvtip_sels_Count ;
      private int AV77Configuracion_movimientoventawwds_21_tfmovvsts_sels_Count ;
      private int A235MovVCod ;
      private int AV78GXV4 ;
      private long AV47i ;
      private string AV20MovVDsc1 ;
      private string AV48MovVTip1 ;
      private string AV24MovVDsc2 ;
      private string AV49MovVTip2 ;
      private string AV28MovVDsc3 ;
      private string AV50MovVTip3 ;
      private string AV37TFMovVDsc_Sel ;
      private string AV36TFMovVDsc ;
      private string AV40TFMovVAbr_Sel ;
      private string AV43TFMovVTip_Sel ;
      private string AV59Configuracion_movimientoventawwds_3_movvdsc1 ;
      private string AV60Configuracion_movimientoventawwds_4_movvtip1 ;
      private string AV64Configuracion_movimientoventawwds_8_movvdsc2 ;
      private string AV65Configuracion_movimientoventawwds_9_movvtip2 ;
      private string AV69Configuracion_movimientoventawwds_13_movvdsc3 ;
      private string AV70Configuracion_movimientoventawwds_14_movvtip3 ;
      private string AV73Configuracion_movimientoventawwds_17_tfmovvdsc ;
      private string AV74Configuracion_movimientoventawwds_18_tfmovvdsc_sel ;
      private string scmdbuf ;
      private string lV59Configuracion_movimientoventawwds_3_movvdsc1 ;
      private string lV64Configuracion_movimientoventawwds_8_movvdsc2 ;
      private string lV69Configuracion_movimientoventawwds_13_movvdsc3 ;
      private string lV73Configuracion_movimientoventawwds_17_tfmovvdsc ;
      private string A1242MovVAbr ;
      private string A1245MovVTip ;
      private string A1243MovVDsc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV61Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 ;
      private bool AV66Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV38TFMovVAbr_SelsJson ;
      private string AV41TFMovVTip_SelsJson ;
      private string AV44TFMovVSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV57Configuracion_movimientoventawwds_1_dynamicfiltersselector1 ;
      private string AV62Configuracion_movimientoventawwds_6_dynamicfiltersselector2 ;
      private string AV67Configuracion_movimientoventawwds_11_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV45TFMovVSts_Sels ;
      private GxSimpleCollection<short> AV77Configuracion_movimientoventawwds_21_tfmovvsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003F2_A1244MovVSts ;
      private string[] P003F2_A1242MovVAbr ;
      private int[] P003F2_A235MovVCod ;
      private string[] P003F2_A1245MovVTip ;
      private string[] P003F2_A1243MovVDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GxSimpleCollection<string> AV39TFMovVAbr_Sels ;
      private GxSimpleCollection<string> AV42TFMovVTip_Sels ;
      private GxSimpleCollection<string> AV75Configuracion_movimientoventawwds_19_tfmovvabr_sels ;
      private GxSimpleCollection<string> AV76Configuracion_movimientoventawwds_20_tfmovvtip_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class movimientoventawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003F2( IGxContext context ,
                                             string A1242MovVAbr ,
                                             GxSimpleCollection<string> AV75Configuracion_movimientoventawwds_19_tfmovvabr_sels ,
                                             string A1245MovVTip ,
                                             GxSimpleCollection<string> AV76Configuracion_movimientoventawwds_20_tfmovvtip_sels ,
                                             short A1244MovVSts ,
                                             GxSimpleCollection<short> AV77Configuracion_movimientoventawwds_21_tfmovvsts_sels ,
                                             string AV57Configuracion_movimientoventawwds_1_dynamicfiltersselector1 ,
                                             short AV58Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 ,
                                             string AV59Configuracion_movimientoventawwds_3_movvdsc1 ,
                                             string AV60Configuracion_movimientoventawwds_4_movvtip1 ,
                                             bool AV61Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 ,
                                             string AV62Configuracion_movimientoventawwds_6_dynamicfiltersselector2 ,
                                             short AV63Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 ,
                                             string AV64Configuracion_movimientoventawwds_8_movvdsc2 ,
                                             string AV65Configuracion_movimientoventawwds_9_movvtip2 ,
                                             bool AV66Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 ,
                                             string AV67Configuracion_movimientoventawwds_11_dynamicfiltersselector3 ,
                                             short AV68Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 ,
                                             string AV69Configuracion_movimientoventawwds_13_movvdsc3 ,
                                             string AV70Configuracion_movimientoventawwds_14_movvtip3 ,
                                             int AV71Configuracion_movimientoventawwds_15_tfmovvcod ,
                                             int AV72Configuracion_movimientoventawwds_16_tfmovvcod_to ,
                                             string AV74Configuracion_movimientoventawwds_18_tfmovvdsc_sel ,
                                             string AV73Configuracion_movimientoventawwds_17_tfmovvdsc ,
                                             int AV75Configuracion_movimientoventawwds_19_tfmovvabr_sels_Count ,
                                             int AV76Configuracion_movimientoventawwds_20_tfmovvtip_sels_Count ,
                                             int AV77Configuracion_movimientoventawwds_21_tfmovvsts_sels_Count ,
                                             string A1243MovVDsc ,
                                             int A235MovVCod ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[13];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [MovVSts], [MovVAbr], [MovVCod], [MovVTip], [MovVDsc] FROM [CMOVVENTAS]";
         if ( ( StringUtil.StrCmp(AV57Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVDSC") == 0 ) && ( AV58Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_movimientoventawwds_3_movvdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV59Configuracion_movimientoventawwds_3_movvdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVDSC") == 0 ) && ( AV58Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_movimientoventawwds_3_movvdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV59Configuracion_movimientoventawwds_3_movvdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_movimientoventawwds_4_movvtip1)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV60Configuracion_movimientoventawwds_4_movvtip1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV61Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVDSC") == 0 ) && ( AV63Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_movimientoventawwds_8_movvdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV64Configuracion_movimientoventawwds_8_movvdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV61Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVDSC") == 0 ) && ( AV63Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_movimientoventawwds_8_movvdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV64Configuracion_movimientoventawwds_8_movvdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV61Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_movimientoventawwds_9_movvtip2)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV65Configuracion_movimientoventawwds_9_movvtip2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV66Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVDSC") == 0 ) && ( AV68Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_movimientoventawwds_13_movvdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV69Configuracion_movimientoventawwds_13_movvdsc3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV66Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVDSC") == 0 ) && ( AV68Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_movimientoventawwds_13_movvdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV69Configuracion_movimientoventawwds_13_movvdsc3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV66Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_movimientoventawwds_14_movvtip3)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV70Configuracion_movimientoventawwds_14_movvtip3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV71Configuracion_movimientoventawwds_15_tfmovvcod) )
         {
            AddWhere(sWhereString, "([MovVCod] >= @AV71Configuracion_movimientoventawwds_15_tfmovvcod)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (0==AV72Configuracion_movimientoventawwds_16_tfmovvcod_to) )
         {
            AddWhere(sWhereString, "([MovVCod] <= @AV72Configuracion_movimientoventawwds_16_tfmovvcod_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_movimientoventawwds_18_tfmovvdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_movimientoventawwds_17_tfmovvdsc)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV73Configuracion_movimientoventawwds_17_tfmovvdsc)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_movimientoventawwds_18_tfmovvdsc_sel)) )
         {
            AddWhere(sWhereString, "([MovVDsc] = @AV74Configuracion_movimientoventawwds_18_tfmovvdsc_sel)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV75Configuracion_movimientoventawwds_19_tfmovvabr_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Configuracion_movimientoventawwds_19_tfmovvabr_sels, "[MovVAbr] IN (", ")")+")");
         }
         if ( AV76Configuracion_movimientoventawwds_20_tfmovvtip_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Configuracion_movimientoventawwds_20_tfmovvtip_sels, "[MovVTip] IN (", ")")+")");
         }
         if ( AV77Configuracion_movimientoventawwds_21_tfmovvsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Configuracion_movimientoventawwds_21_tfmovvsts_sels, "[MovVSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovVCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovVCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovVDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovVDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovVAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovVAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovVTip]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovVTip] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovVSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovVSts] DESC";
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
                     return conditional_P003F2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (GxSimpleCollection<short>)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (int)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP003F2;
          prmP003F2 = new Object[] {
          new ParDef("@lV59Configuracion_movimientoventawwds_3_movvdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_movimientoventawwds_3_movvdsc1",GXType.NChar,100,0) ,
          new ParDef("@AV60Configuracion_movimientoventawwds_4_movvtip1",GXType.NChar,1,0) ,
          new ParDef("@lV64Configuracion_movimientoventawwds_8_movvdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV64Configuracion_movimientoventawwds_8_movvdsc2",GXType.NChar,100,0) ,
          new ParDef("@AV65Configuracion_movimientoventawwds_9_movvtip2",GXType.NChar,1,0) ,
          new ParDef("@lV69Configuracion_movimientoventawwds_13_movvdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_movimientoventawwds_13_movvdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV70Configuracion_movimientoventawwds_14_movvtip3",GXType.NChar,1,0) ,
          new ParDef("@AV71Configuracion_movimientoventawwds_15_tfmovvcod",GXType.Int32,6,0) ,
          new ParDef("@AV72Configuracion_movimientoventawwds_16_tfmovvcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV73Configuracion_movimientoventawwds_17_tfmovvdsc",GXType.NChar,100,0) ,
          new ParDef("@AV74Configuracion_movimientoventawwds_18_tfmovvdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003F2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
