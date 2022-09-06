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
   public class movimientoalmacenwwexport : GXProcedure
   {
      public movimientoalmacenwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public movimientoalmacenwwexport( IGxContext context )
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
         movimientoalmacenwwexport objmovimientoalmacenwwexport;
         objmovimientoalmacenwwexport = new movimientoalmacenwwexport();
         objmovimientoalmacenwwexport.AV11Filename = "" ;
         objmovimientoalmacenwwexport.AV12ErrorMessage = "" ;
         objmovimientoalmacenwwexport.context.SetSubmitInitialConfig(context);
         objmovimientoalmacenwwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmovimientoalmacenwwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((movimientoalmacenwwexport)stateInfo).executePrivate();
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
         AV11Filename = "MovimientoAlmacenWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MOVDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV20MovDsc1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20MovDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Movimiento de Almacen", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Movimiento de Almacen", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20MovDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MOVTIP") == 0 )
            {
               AV21MovTip1 = (short)(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."));
               if ( ! (0==AV21MovTip1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Movimiento";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                  if ( AV21MovTip1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Entrada";
                  }
                  else if ( AV21MovTip1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Salida";
                  }
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "MOVDSC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25MovDsc2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25MovDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Movimiento de Almacen", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Movimiento de Almacen", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25MovDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "MOVTIP") == 0 )
               {
                  AV26MovTip2 = (short)(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."));
                  if ( ! (0==AV26MovTip2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Movimiento";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                     if ( AV26MovTip2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Entrada";
                     }
                     else if ( AV26MovTip2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Salida";
                     }
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "MOVDSC") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30MovDsc3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30MovDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Movimiento de Almacen", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Movimiento de Almacen", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30MovDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "MOVTIP") == 0 )
                  {
                     AV31MovTip3 = (short)(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."));
                     if ( ! (0==AV31MovTip3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo de Movimiento";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                        if ( AV31MovTip3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Entrada";
                        }
                        else if ( AV31MovTip3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Salida";
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV37TFMovCod) && (0==AV38TFMovCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV37TFMovCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV38TFMovCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFMovDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Movimiento Almacen") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFMovDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFMovDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Movimiento Almacen") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFMovDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFMovAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sunat") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFMovAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFMovAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sunat") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFMovAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV44TFMovTip_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo Movimiento") ;
            AV13CellRow = GXt_int2;
            AV51i = 1;
            AV54GXV1 = 1;
            while ( AV54GXV1 <= AV44TFMovTip_Sels.Count )
            {
               AV45TFMovTip_Sel = (short)(AV44TFMovTip_Sels.GetNumeric(AV54GXV1));
               if ( AV51i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV45TFMovTip_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Entrada";
               }
               else if ( AV45TFMovTip_Sel == 2 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Salida";
               }
               AV51i = (long)(AV51i+1);
               AV54GXV1 = (int)(AV54GXV1+1);
            }
         }
         if ( ! ( ( AV47TFMovSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV51i = 1;
            AV55GXV2 = 1;
            while ( AV55GXV2 <= AV47TFMovSts_Sels.Count )
            {
               AV48TFMovSts_Sel = (short)(AV47TFMovSts_Sels.GetNumeric(AV55GXV2));
               if ( AV51i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV48TFMovSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV48TFMovSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV51i = (long)(AV51i+1);
               AV55GXV2 = (int)(AV55GXV2+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Movimiento Almacen";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Codigo Sunat";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Tipo Movimiento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV57Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV58Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV59Configuracion_movimientoalmacenwwds_3_movdsc1 = AV20MovDsc1;
         AV60Configuracion_movimientoalmacenwwds_4_movtip1 = AV21MovTip1;
         AV61Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV62Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV63Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV64Configuracion_movimientoalmacenwwds_8_movdsc2 = AV25MovDsc2;
         AV65Configuracion_movimientoalmacenwwds_9_movtip2 = AV26MovTip2;
         AV66Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV67Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV68Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV69Configuracion_movimientoalmacenwwds_13_movdsc3 = AV30MovDsc3;
         AV70Configuracion_movimientoalmacenwwds_14_movtip3 = AV31MovTip3;
         AV71Configuracion_movimientoalmacenwwds_15_tfmovcod = AV37TFMovCod;
         AV72Configuracion_movimientoalmacenwwds_16_tfmovcod_to = AV38TFMovCod_To;
         AV73Configuracion_movimientoalmacenwwds_17_tfmovdsc = AV39TFMovDsc;
         AV74Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel = AV40TFMovDsc_Sel;
         AV75Configuracion_movimientoalmacenwwds_19_tfmovabr = AV41TFMovAbr;
         AV76Configuracion_movimientoalmacenwwds_20_tfmovabr_sel = AV42TFMovAbr_Sel;
         AV77Configuracion_movimientoalmacenwwds_21_tfmovtip_sels = AV44TFMovTip_Sels;
         AV78Configuracion_movimientoalmacenwwds_22_tfmovsts_sels = AV47TFMovSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1241MovTip ,
                                              AV77Configuracion_movimientoalmacenwwds_21_tfmovtip_sels ,
                                              A1240MovSts ,
                                              AV78Configuracion_movimientoalmacenwwds_22_tfmovsts_sels ,
                                              AV57Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 ,
                                              AV58Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 ,
                                              AV59Configuracion_movimientoalmacenwwds_3_movdsc1 ,
                                              AV60Configuracion_movimientoalmacenwwds_4_movtip1 ,
                                              AV61Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 ,
                                              AV62Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 ,
                                              AV63Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 ,
                                              AV64Configuracion_movimientoalmacenwwds_8_movdsc2 ,
                                              AV65Configuracion_movimientoalmacenwwds_9_movtip2 ,
                                              AV66Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 ,
                                              AV67Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 ,
                                              AV68Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 ,
                                              AV69Configuracion_movimientoalmacenwwds_13_movdsc3 ,
                                              AV70Configuracion_movimientoalmacenwwds_14_movtip3 ,
                                              AV71Configuracion_movimientoalmacenwwds_15_tfmovcod ,
                                              AV72Configuracion_movimientoalmacenwwds_16_tfmovcod_to ,
                                              AV74Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel ,
                                              AV73Configuracion_movimientoalmacenwwds_17_tfmovdsc ,
                                              AV76Configuracion_movimientoalmacenwwds_20_tfmovabr_sel ,
                                              AV75Configuracion_movimientoalmacenwwds_19_tfmovabr ,
                                              AV77Configuracion_movimientoalmacenwwds_21_tfmovtip_sels.Count ,
                                              AV78Configuracion_movimientoalmacenwwds_22_tfmovsts_sels.Count ,
                                              A1239MovDsc ,
                                              A234MovCod ,
                                              A1237MovAbr ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Configuracion_movimientoalmacenwwds_3_movdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_movimientoalmacenwwds_3_movdsc1), 100, "%");
         lV59Configuracion_movimientoalmacenwwds_3_movdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_movimientoalmacenwwds_3_movdsc1), 100, "%");
         lV64Configuracion_movimientoalmacenwwds_8_movdsc2 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_movimientoalmacenwwds_8_movdsc2), 100, "%");
         lV64Configuracion_movimientoalmacenwwds_8_movdsc2 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_movimientoalmacenwwds_8_movdsc2), 100, "%");
         lV69Configuracion_movimientoalmacenwwds_13_movdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_movimientoalmacenwwds_13_movdsc3), 100, "%");
         lV69Configuracion_movimientoalmacenwwds_13_movdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_movimientoalmacenwwds_13_movdsc3), 100, "%");
         lV73Configuracion_movimientoalmacenwwds_17_tfmovdsc = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_movimientoalmacenwwds_17_tfmovdsc), 100, "%");
         lV75Configuracion_movimientoalmacenwwds_19_tfmovabr = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_movimientoalmacenwwds_19_tfmovabr), 5, "%");
         /* Using cursor P003C2 */
         pr_default.execute(0, new Object[] {lV59Configuracion_movimientoalmacenwwds_3_movdsc1, lV59Configuracion_movimientoalmacenwwds_3_movdsc1, AV60Configuracion_movimientoalmacenwwds_4_movtip1, lV64Configuracion_movimientoalmacenwwds_8_movdsc2, lV64Configuracion_movimientoalmacenwwds_8_movdsc2, AV65Configuracion_movimientoalmacenwwds_9_movtip2, lV69Configuracion_movimientoalmacenwwds_13_movdsc3, lV69Configuracion_movimientoalmacenwwds_13_movdsc3, AV70Configuracion_movimientoalmacenwwds_14_movtip3, AV71Configuracion_movimientoalmacenwwds_15_tfmovcod, AV72Configuracion_movimientoalmacenwwds_16_tfmovcod_to, lV73Configuracion_movimientoalmacenwwds_17_tfmovdsc, AV74Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel, lV75Configuracion_movimientoalmacenwwds_19_tfmovabr, AV76Configuracion_movimientoalmacenwwds_20_tfmovabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1240MovSts = P003C2_A1240MovSts[0];
            A1237MovAbr = P003C2_A1237MovAbr[0];
            A234MovCod = P003C2_A234MovCod[0];
            A1241MovTip = P003C2_A1241MovTip[0];
            A1239MovDsc = P003C2_A1239MovDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A234MovCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1239MovDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1237MovAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A1241MovTip == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Entrada";
            }
            else if ( A1241MovTip == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Salida";
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A1240MovSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "ACTIVO";
            }
            else if ( A1240MovSts == 0 )
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
         if ( StringUtil.StrCmp(AV33Session.Get("Configuracion.MovimientoAlmacenWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.MovimientoAlmacenWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Configuracion.MovimientoAlmacenWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV79GXV3 = 1;
         while ( AV79GXV3 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV79GXV3));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMOVCOD") == 0 )
            {
               AV37TFMovCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV38TFMovCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMOVDSC") == 0 )
            {
               AV39TFMovDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMOVDSC_SEL") == 0 )
            {
               AV40TFMovDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMOVABR") == 0 )
            {
               AV41TFMovAbr = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMOVABR_SEL") == 0 )
            {
               AV42TFMovAbr_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMOVTIP_SEL") == 0 )
            {
               AV43TFMovTip_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV44TFMovTip_Sels.FromJSonString(AV43TFMovTip_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMOVSTS_SEL") == 0 )
            {
               AV46TFMovSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV47TFMovSts_Sels.FromJSonString(AV46TFMovSts_SelsJson, null);
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
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV20MovDsc1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25MovDsc2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30MovDsc3 = "";
         AV40TFMovDsc_Sel = "";
         AV39TFMovDsc = "";
         AV42TFMovAbr_Sel = "";
         AV41TFMovAbr = "";
         AV44TFMovTip_Sels = new GxSimpleCollection<short>();
         AV47TFMovSts_Sels = new GxSimpleCollection<short>();
         AV57Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 = "";
         AV59Configuracion_movimientoalmacenwwds_3_movdsc1 = "";
         AV62Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 = "";
         AV64Configuracion_movimientoalmacenwwds_8_movdsc2 = "";
         AV67Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 = "";
         AV69Configuracion_movimientoalmacenwwds_13_movdsc3 = "";
         AV73Configuracion_movimientoalmacenwwds_17_tfmovdsc = "";
         AV74Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel = "";
         AV75Configuracion_movimientoalmacenwwds_19_tfmovabr = "";
         AV76Configuracion_movimientoalmacenwwds_20_tfmovabr_sel = "";
         AV77Configuracion_movimientoalmacenwwds_21_tfmovtip_sels = new GxSimpleCollection<short>();
         AV78Configuracion_movimientoalmacenwwds_22_tfmovsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV59Configuracion_movimientoalmacenwwds_3_movdsc1 = "";
         lV64Configuracion_movimientoalmacenwwds_8_movdsc2 = "";
         lV69Configuracion_movimientoalmacenwwds_13_movdsc3 = "";
         lV73Configuracion_movimientoalmacenwwds_17_tfmovdsc = "";
         lV75Configuracion_movimientoalmacenwwds_19_tfmovabr = "";
         A1239MovDsc = "";
         A1237MovAbr = "";
         P003C2_A1240MovSts = new short[1] ;
         P003C2_A1237MovAbr = new string[] {""} ;
         P003C2_A234MovCod = new int[1] ;
         P003C2_A1241MovTip = new short[1] ;
         P003C2_A1239MovDsc = new string[] {""} ;
         GXt_char1 = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43TFMovTip_SelsJson = "";
         AV46TFMovSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.movimientoalmacenwwexport__default(),
            new Object[][] {
                new Object[] {
               P003C2_A1240MovSts, P003C2_A1237MovAbr, P003C2_A234MovCod, P003C2_A1241MovTip, P003C2_A1239MovDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV21MovTip1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV26MovTip2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV31MovTip3 ;
      private short AV45TFMovTip_Sel ;
      private short GXt_int2 ;
      private short AV48TFMovSts_Sel ;
      private short AV58Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 ;
      private short AV60Configuracion_movimientoalmacenwwds_4_movtip1 ;
      private short AV63Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 ;
      private short AV65Configuracion_movimientoalmacenwwds_9_movtip2 ;
      private short AV68Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 ;
      private short AV70Configuracion_movimientoalmacenwwds_14_movtip3 ;
      private short A1241MovTip ;
      private short A1240MovSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV37TFMovCod ;
      private int AV38TFMovCod_To ;
      private int AV54GXV1 ;
      private int AV55GXV2 ;
      private int AV71Configuracion_movimientoalmacenwwds_15_tfmovcod ;
      private int AV72Configuracion_movimientoalmacenwwds_16_tfmovcod_to ;
      private int AV77Configuracion_movimientoalmacenwwds_21_tfmovtip_sels_Count ;
      private int AV78Configuracion_movimientoalmacenwwds_22_tfmovsts_sels_Count ;
      private int A234MovCod ;
      private int AV79GXV3 ;
      private long AV51i ;
      private string AV20MovDsc1 ;
      private string AV25MovDsc2 ;
      private string AV30MovDsc3 ;
      private string AV40TFMovDsc_Sel ;
      private string AV39TFMovDsc ;
      private string AV42TFMovAbr_Sel ;
      private string AV41TFMovAbr ;
      private string AV59Configuracion_movimientoalmacenwwds_3_movdsc1 ;
      private string AV64Configuracion_movimientoalmacenwwds_8_movdsc2 ;
      private string AV69Configuracion_movimientoalmacenwwds_13_movdsc3 ;
      private string AV73Configuracion_movimientoalmacenwwds_17_tfmovdsc ;
      private string AV74Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel ;
      private string AV75Configuracion_movimientoalmacenwwds_19_tfmovabr ;
      private string AV76Configuracion_movimientoalmacenwwds_20_tfmovabr_sel ;
      private string scmdbuf ;
      private string lV59Configuracion_movimientoalmacenwwds_3_movdsc1 ;
      private string lV64Configuracion_movimientoalmacenwwds_8_movdsc2 ;
      private string lV69Configuracion_movimientoalmacenwwds_13_movdsc3 ;
      private string lV73Configuracion_movimientoalmacenwwds_17_tfmovdsc ;
      private string lV75Configuracion_movimientoalmacenwwds_19_tfmovabr ;
      private string A1239MovDsc ;
      private string A1237MovAbr ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV61Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 ;
      private bool AV66Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV43TFMovTip_SelsJson ;
      private string AV46TFMovSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV57Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 ;
      private string AV62Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 ;
      private string AV67Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV44TFMovTip_Sels ;
      private GxSimpleCollection<short> AV47TFMovSts_Sels ;
      private GxSimpleCollection<short> AV77Configuracion_movimientoalmacenwwds_21_tfmovtip_sels ;
      private GxSimpleCollection<short> AV78Configuracion_movimientoalmacenwwds_22_tfmovsts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003C2_A1240MovSts ;
      private string[] P003C2_A1237MovAbr ;
      private int[] P003C2_A234MovCod ;
      private short[] P003C2_A1241MovTip ;
      private string[] P003C2_A1239MovDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
   }

   public class movimientoalmacenwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003C2( IGxContext context ,
                                             short A1241MovTip ,
                                             GxSimpleCollection<short> AV77Configuracion_movimientoalmacenwwds_21_tfmovtip_sels ,
                                             short A1240MovSts ,
                                             GxSimpleCollection<short> AV78Configuracion_movimientoalmacenwwds_22_tfmovsts_sels ,
                                             string AV57Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 ,
                                             short AV58Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 ,
                                             string AV59Configuracion_movimientoalmacenwwds_3_movdsc1 ,
                                             short AV60Configuracion_movimientoalmacenwwds_4_movtip1 ,
                                             bool AV61Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 ,
                                             string AV62Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 ,
                                             short AV63Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 ,
                                             string AV64Configuracion_movimientoalmacenwwds_8_movdsc2 ,
                                             short AV65Configuracion_movimientoalmacenwwds_9_movtip2 ,
                                             bool AV66Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 ,
                                             string AV67Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 ,
                                             short AV68Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 ,
                                             string AV69Configuracion_movimientoalmacenwwds_13_movdsc3 ,
                                             short AV70Configuracion_movimientoalmacenwwds_14_movtip3 ,
                                             int AV71Configuracion_movimientoalmacenwwds_15_tfmovcod ,
                                             int AV72Configuracion_movimientoalmacenwwds_16_tfmovcod_to ,
                                             string AV74Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel ,
                                             string AV73Configuracion_movimientoalmacenwwds_17_tfmovdsc ,
                                             string AV76Configuracion_movimientoalmacenwwds_20_tfmovabr_sel ,
                                             string AV75Configuracion_movimientoalmacenwwds_19_tfmovabr ,
                                             int AV77Configuracion_movimientoalmacenwwds_21_tfmovtip_sels_Count ,
                                             int AV78Configuracion_movimientoalmacenwwds_22_tfmovsts_sels_Count ,
                                             string A1239MovDsc ,
                                             int A234MovCod ,
                                             string A1237MovAbr ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [MovSts], [MovAbr], [MovCod], [MovTip], [MovDsc] FROM [CMOVALMACEN]";
         if ( ( StringUtil.StrCmp(AV57Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1, "MOVDSC") == 0 ) && ( AV58Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_movimientoalmacenwwds_3_movdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV59Configuracion_movimientoalmacenwwds_3_movdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1, "MOVDSC") == 0 ) && ( AV58Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_movimientoalmacenwwds_3_movdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like '%' + @lV59Configuracion_movimientoalmacenwwds_3_movdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1, "MOVTIP") == 0 ) && ( ! (0==AV60Configuracion_movimientoalmacenwwds_4_movtip1) ) )
         {
            AddWhere(sWhereString, "([MovTip] = @AV60Configuracion_movimientoalmacenwwds_4_movtip1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV61Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2, "MOVDSC") == 0 ) && ( AV63Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_movimientoalmacenwwds_8_movdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV64Configuracion_movimientoalmacenwwds_8_movdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV61Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2, "MOVDSC") == 0 ) && ( AV63Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_movimientoalmacenwwds_8_movdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like '%' + @lV64Configuracion_movimientoalmacenwwds_8_movdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV61Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2, "MOVTIP") == 0 ) && ( ! (0==AV65Configuracion_movimientoalmacenwwds_9_movtip2) ) )
         {
            AddWhere(sWhereString, "([MovTip] = @AV65Configuracion_movimientoalmacenwwds_9_movtip2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV66Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3, "MOVDSC") == 0 ) && ( AV68Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_movimientoalmacenwwds_13_movdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV69Configuracion_movimientoalmacenwwds_13_movdsc3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV66Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3, "MOVDSC") == 0 ) && ( AV68Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_movimientoalmacenwwds_13_movdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like '%' + @lV69Configuracion_movimientoalmacenwwds_13_movdsc3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV66Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3, "MOVTIP") == 0 ) && ( ! (0==AV70Configuracion_movimientoalmacenwwds_14_movtip3) ) )
         {
            AddWhere(sWhereString, "([MovTip] = @AV70Configuracion_movimientoalmacenwwds_14_movtip3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV71Configuracion_movimientoalmacenwwds_15_tfmovcod) )
         {
            AddWhere(sWhereString, "([MovCod] >= @AV71Configuracion_movimientoalmacenwwds_15_tfmovcod)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (0==AV72Configuracion_movimientoalmacenwwds_16_tfmovcod_to) )
         {
            AddWhere(sWhereString, "([MovCod] <= @AV72Configuracion_movimientoalmacenwwds_16_tfmovcod_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_movimientoalmacenwwds_17_tfmovdsc)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV73Configuracion_movimientoalmacenwwds_17_tfmovdsc)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel)) )
         {
            AddWhere(sWhereString, "([MovDsc] = @AV74Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_movimientoalmacenwwds_20_tfmovabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_movimientoalmacenwwds_19_tfmovabr)) ) )
         {
            AddWhere(sWhereString, "([MovAbr] like @lV75Configuracion_movimientoalmacenwwds_19_tfmovabr)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_movimientoalmacenwwds_20_tfmovabr_sel)) )
         {
            AddWhere(sWhereString, "([MovAbr] = @AV76Configuracion_movimientoalmacenwwds_20_tfmovabr_sel)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV77Configuracion_movimientoalmacenwwds_21_tfmovtip_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Configuracion_movimientoalmacenwwds_21_tfmovtip_sels, "[MovTip] IN (", ")")+")");
         }
         if ( AV78Configuracion_movimientoalmacenwwds_22_tfmovsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Configuracion_movimientoalmacenwwds_22_tfmovsts_sels, "[MovSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovTip]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovTip] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [MovSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MovSts] DESC";
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
                     return conditional_P003C2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP003C2;
          prmP003C2 = new Object[] {
          new ParDef("@lV59Configuracion_movimientoalmacenwwds_3_movdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_movimientoalmacenwwds_3_movdsc1",GXType.NChar,100,0) ,
          new ParDef("@AV60Configuracion_movimientoalmacenwwds_4_movtip1",GXType.Int16,1,0) ,
          new ParDef("@lV64Configuracion_movimientoalmacenwwds_8_movdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV64Configuracion_movimientoalmacenwwds_8_movdsc2",GXType.NChar,100,0) ,
          new ParDef("@AV65Configuracion_movimientoalmacenwwds_9_movtip2",GXType.Int16,1,0) ,
          new ParDef("@lV69Configuracion_movimientoalmacenwwds_13_movdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_movimientoalmacenwwds_13_movdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV70Configuracion_movimientoalmacenwwds_14_movtip3",GXType.Int16,1,0) ,
          new ParDef("@AV71Configuracion_movimientoalmacenwwds_15_tfmovcod",GXType.Int32,6,0) ,
          new ParDef("@AV72Configuracion_movimientoalmacenwwds_16_tfmovcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV73Configuracion_movimientoalmacenwwds_17_tfmovdsc",GXType.NChar,100,0) ,
          new ParDef("@AV74Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_movimientoalmacenwwds_19_tfmovabr",GXType.NChar,5,0) ,
          new ParDef("@AV76Configuracion_movimientoalmacenwwds_20_tfmovabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003C2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
