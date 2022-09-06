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
   public class vendedoreswwexport : GXProcedure
   {
      public vendedoreswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public vendedoreswwexport( IGxContext context )
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
         vendedoreswwexport objvendedoreswwexport;
         objvendedoreswwexport = new vendedoreswwexport();
         objvendedoreswwexport.AV11Filename = "" ;
         objvendedoreswwexport.AV12ErrorMessage = "" ;
         objvendedoreswwexport.context.SetSubmitInitialConfig(context);
         objvendedoreswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objvendedoreswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((vendedoreswwexport)stateInfo).executePrivate();
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
         AV11Filename = "VendedoresWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "VENDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV21VenDsc1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21VenDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor / Cobrador", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor / Cobrador", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21VenDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "VENTIPO") == 0 )
            {
               AV20VenTipo1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20VenTipo1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV20VenTipo1), "T") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Ambos";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV20VenTipo1), "V") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Vendedor";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV20VenTipo1), "C") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Cobrador";
                  }
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "VENDSC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV26VenDsc2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26VenDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor / Cobrador", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor / Cobrador", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26VenDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "VENTIPO") == 0 )
               {
                  AV25VenTipo2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25VenTipo2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( AV25VenTipo2), "T") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Ambos";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV25VenTipo2), "V") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Vendedor";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV25VenTipo2), "C") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Cobrador";
                     }
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "VENDSC") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31VenDsc3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31VenDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor / Cobrador", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor / Cobrador", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV31VenDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "VENTIPO") == 0 )
                  {
                     AV30VenTipo3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30VenTipo3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV30VenTipo3), "T") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Ambos";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV30VenTipo3), "V") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Vendedor";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV30VenTipo3), "C") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Cobrador";
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV37TFVenCod) && (0==AV38TFVenCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV37TFVenCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV38TFVenCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFVenDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vendedor / Cobrador") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFVenDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFVenDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vendedor / Cobrador") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFVenDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFVenDir_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Dirección") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFVenDir_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFVenDir)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Dirección") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFVenDir, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV50TFVenTipo_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo") ;
            AV13CellRow = GXt_int2;
            AV48i = 1;
            AV53GXV1 = 1;
            while ( AV53GXV1 <= AV50TFVenTipo_Sels.Count )
            {
               AV44TFVenTipo_Sel = AV50TFVenTipo_Sels.GetString(AV53GXV1);
               if ( AV48i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV44TFVenTipo_Sel), "T") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Ambos";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV44TFVenTipo_Sel), "V") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Vendedor";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV44TFVenTipo_Sel), "C") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Cobrador";
               }
               AV48i = (long)(AV48i+1);
               AV53GXV1 = (int)(AV53GXV1+1);
            }
         }
         if ( ! ( ( AV46TFVenSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV48i = 1;
            AV54GXV2 = 1;
            while ( AV54GXV2 <= AV46TFVenSts_Sels.Count )
            {
               AV47TFVenSts_Sel = (short)(AV46TFVenSts_Sels.GetNumeric(AV54GXV2));
               if ( AV48i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV47TFVenSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV47TFVenSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV48i = (long)(AV48i+1);
               AV54GXV2 = (int)(AV54GXV2+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Vendedor / Cobrador";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Dirección";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Tipo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV56Configuracion_vendedoreswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV57Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV58Configuracion_vendedoreswwds_3_vendsc1 = AV21VenDsc1;
         AV59Configuracion_vendedoreswwds_4_ventipo1 = AV20VenTipo1;
         AV60Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV61Configuracion_vendedoreswwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV62Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV63Configuracion_vendedoreswwds_8_vendsc2 = AV26VenDsc2;
         AV64Configuracion_vendedoreswwds_9_ventipo2 = AV25VenTipo2;
         AV65Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV66Configuracion_vendedoreswwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV67Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV68Configuracion_vendedoreswwds_13_vendsc3 = AV31VenDsc3;
         AV69Configuracion_vendedoreswwds_14_ventipo3 = AV30VenTipo3;
         AV70Configuracion_vendedoreswwds_15_tfvencod = AV37TFVenCod;
         AV71Configuracion_vendedoreswwds_16_tfvencod_to = AV38TFVenCod_To;
         AV72Configuracion_vendedoreswwds_17_tfvendsc = AV39TFVenDsc;
         AV73Configuracion_vendedoreswwds_18_tfvendsc_sel = AV40TFVenDsc_Sel;
         AV74Configuracion_vendedoreswwds_19_tfvendir = AV41TFVenDir;
         AV75Configuracion_vendedoreswwds_20_tfvendir_sel = AV42TFVenDir_Sel;
         AV76Configuracion_vendedoreswwds_21_tfventipo_sels = AV50TFVenTipo_Sels;
         AV77Configuracion_vendedoreswwds_22_tfvensts_sels = AV46TFVenSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A2049VenTipo ,
                                              AV76Configuracion_vendedoreswwds_21_tfventipo_sels ,
                                              A2047VenSts ,
                                              AV77Configuracion_vendedoreswwds_22_tfvensts_sels ,
                                              AV56Configuracion_vendedoreswwds_1_dynamicfiltersselector1 ,
                                              AV57Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 ,
                                              AV58Configuracion_vendedoreswwds_3_vendsc1 ,
                                              AV59Configuracion_vendedoreswwds_4_ventipo1 ,
                                              AV60Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 ,
                                              AV61Configuracion_vendedoreswwds_6_dynamicfiltersselector2 ,
                                              AV62Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 ,
                                              AV63Configuracion_vendedoreswwds_8_vendsc2 ,
                                              AV64Configuracion_vendedoreswwds_9_ventipo2 ,
                                              AV65Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 ,
                                              AV66Configuracion_vendedoreswwds_11_dynamicfiltersselector3 ,
                                              AV67Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 ,
                                              AV68Configuracion_vendedoreswwds_13_vendsc3 ,
                                              AV69Configuracion_vendedoreswwds_14_ventipo3 ,
                                              AV70Configuracion_vendedoreswwds_15_tfvencod ,
                                              AV71Configuracion_vendedoreswwds_16_tfvencod_to ,
                                              AV73Configuracion_vendedoreswwds_18_tfvendsc_sel ,
                                              AV72Configuracion_vendedoreswwds_17_tfvendsc ,
                                              AV75Configuracion_vendedoreswwds_20_tfvendir_sel ,
                                              AV74Configuracion_vendedoreswwds_19_tfvendir ,
                                              AV76Configuracion_vendedoreswwds_21_tfventipo_sels.Count ,
                                              AV77Configuracion_vendedoreswwds_22_tfvensts_sels.Count ,
                                              A2045VenDsc ,
                                              A309VenCod ,
                                              A2044VenDir ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Configuracion_vendedoreswwds_3_vendsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_vendedoreswwds_3_vendsc1), 100, "%");
         lV58Configuracion_vendedoreswwds_3_vendsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_vendedoreswwds_3_vendsc1), 100, "%");
         lV63Configuracion_vendedoreswwds_8_vendsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_vendedoreswwds_8_vendsc2), 100, "%");
         lV63Configuracion_vendedoreswwds_8_vendsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_vendedoreswwds_8_vendsc2), 100, "%");
         lV68Configuracion_vendedoreswwds_13_vendsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_vendedoreswwds_13_vendsc3), 100, "%");
         lV68Configuracion_vendedoreswwds_13_vendsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_vendedoreswwds_13_vendsc3), 100, "%");
         lV72Configuracion_vendedoreswwds_17_tfvendsc = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_vendedoreswwds_17_tfvendsc), 100, "%");
         lV74Configuracion_vendedoreswwds_19_tfvendir = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_vendedoreswwds_19_tfvendir), 100, "%");
         /* Using cursor P00392 */
         pr_default.execute(0, new Object[] {lV58Configuracion_vendedoreswwds_3_vendsc1, lV58Configuracion_vendedoreswwds_3_vendsc1, AV59Configuracion_vendedoreswwds_4_ventipo1, lV63Configuracion_vendedoreswwds_8_vendsc2, lV63Configuracion_vendedoreswwds_8_vendsc2, AV64Configuracion_vendedoreswwds_9_ventipo2, lV68Configuracion_vendedoreswwds_13_vendsc3, lV68Configuracion_vendedoreswwds_13_vendsc3, AV69Configuracion_vendedoreswwds_14_ventipo3, AV70Configuracion_vendedoreswwds_15_tfvencod, AV71Configuracion_vendedoreswwds_16_tfvencod_to, lV72Configuracion_vendedoreswwds_17_tfvendsc, AV73Configuracion_vendedoreswwds_18_tfvendsc_sel, lV74Configuracion_vendedoreswwds_19_tfvendir, AV75Configuracion_vendedoreswwds_20_tfvendir_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2047VenSts = P00392_A2047VenSts[0];
            A2044VenDir = P00392_A2044VenDir[0];
            A309VenCod = P00392_A309VenCod[0];
            A2049VenTipo = P00392_A2049VenTipo[0];
            A2045VenDsc = P00392_A2045VenDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A309VenCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2045VenDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2044VenDir, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( A2049VenTipo), "T") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Ambos";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A2049VenTipo), "V") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Vendedor";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A2049VenTipo), "C") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Cobrador";
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A2047VenSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "ACTIVO";
            }
            else if ( A2047VenSts == 0 )
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
         if ( StringUtil.StrCmp(AV33Session.Get("Configuracion.VendedoresWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.VendedoresWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Configuracion.VendedoresWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV78GXV3 = 1;
         while ( AV78GXV3 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV78GXV3));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVENCOD") == 0 )
            {
               AV37TFVenCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV38TFVenCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVENDSC") == 0 )
            {
               AV39TFVenDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVENDSC_SEL") == 0 )
            {
               AV40TFVenDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVENDIR") == 0 )
            {
               AV41TFVenDir = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVENDIR_SEL") == 0 )
            {
               AV42TFVenDir_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVENTIPO_SEL") == 0 )
            {
               AV49TFVenTipo_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV50TFVenTipo_Sels.FromJSonString(AV49TFVenTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVENSTS_SEL") == 0 )
            {
               AV45TFVenSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV46TFVenSts_Sels.FromJSonString(AV45TFVenSts_SelsJson, null);
            }
            AV78GXV3 = (int)(AV78GXV3+1);
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
         AV21VenDsc1 = "";
         AV20VenTipo1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV26VenDsc2 = "";
         AV25VenTipo2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV31VenDsc3 = "";
         AV30VenTipo3 = "";
         AV40TFVenDsc_Sel = "";
         AV39TFVenDsc = "";
         AV42TFVenDir_Sel = "";
         AV41TFVenDir = "";
         AV50TFVenTipo_Sels = new GxSimpleCollection<string>();
         AV44TFVenTipo_Sel = "";
         AV46TFVenSts_Sels = new GxSimpleCollection<short>();
         AV56Configuracion_vendedoreswwds_1_dynamicfiltersselector1 = "";
         AV58Configuracion_vendedoreswwds_3_vendsc1 = "";
         AV59Configuracion_vendedoreswwds_4_ventipo1 = "";
         AV61Configuracion_vendedoreswwds_6_dynamicfiltersselector2 = "";
         AV63Configuracion_vendedoreswwds_8_vendsc2 = "";
         AV64Configuracion_vendedoreswwds_9_ventipo2 = "";
         AV66Configuracion_vendedoreswwds_11_dynamicfiltersselector3 = "";
         AV68Configuracion_vendedoreswwds_13_vendsc3 = "";
         AV69Configuracion_vendedoreswwds_14_ventipo3 = "";
         AV72Configuracion_vendedoreswwds_17_tfvendsc = "";
         AV73Configuracion_vendedoreswwds_18_tfvendsc_sel = "";
         AV74Configuracion_vendedoreswwds_19_tfvendir = "";
         AV75Configuracion_vendedoreswwds_20_tfvendir_sel = "";
         AV76Configuracion_vendedoreswwds_21_tfventipo_sels = new GxSimpleCollection<string>();
         AV77Configuracion_vendedoreswwds_22_tfvensts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV58Configuracion_vendedoreswwds_3_vendsc1 = "";
         lV63Configuracion_vendedoreswwds_8_vendsc2 = "";
         lV68Configuracion_vendedoreswwds_13_vendsc3 = "";
         lV72Configuracion_vendedoreswwds_17_tfvendsc = "";
         lV74Configuracion_vendedoreswwds_19_tfvendir = "";
         A2049VenTipo = "";
         A2045VenDsc = "";
         A2044VenDir = "";
         P00392_A2047VenSts = new short[1] ;
         P00392_A2044VenDir = new string[] {""} ;
         P00392_A309VenCod = new int[1] ;
         P00392_A2049VenTipo = new string[] {""} ;
         P00392_A2045VenDsc = new string[] {""} ;
         GXt_char1 = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV49TFVenTipo_SelsJson = "";
         AV45TFVenSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.vendedoreswwexport__default(),
            new Object[][] {
                new Object[] {
               P00392_A2047VenSts, P00392_A2044VenDir, P00392_A309VenCod, P00392_A2049VenTipo, P00392_A2045VenDsc
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
      private short AV47TFVenSts_Sel ;
      private short AV57Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 ;
      private short AV62Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 ;
      private short AV67Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 ;
      private short A2047VenSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV37TFVenCod ;
      private int AV38TFVenCod_To ;
      private int AV53GXV1 ;
      private int AV54GXV2 ;
      private int AV70Configuracion_vendedoreswwds_15_tfvencod ;
      private int AV71Configuracion_vendedoreswwds_16_tfvencod_to ;
      private int AV76Configuracion_vendedoreswwds_21_tfventipo_sels_Count ;
      private int AV77Configuracion_vendedoreswwds_22_tfvensts_sels_Count ;
      private int A309VenCod ;
      private int AV78GXV3 ;
      private long AV48i ;
      private string AV21VenDsc1 ;
      private string AV20VenTipo1 ;
      private string AV26VenDsc2 ;
      private string AV25VenTipo2 ;
      private string AV31VenDsc3 ;
      private string AV30VenTipo3 ;
      private string AV40TFVenDsc_Sel ;
      private string AV39TFVenDsc ;
      private string AV42TFVenDir_Sel ;
      private string AV41TFVenDir ;
      private string AV44TFVenTipo_Sel ;
      private string AV58Configuracion_vendedoreswwds_3_vendsc1 ;
      private string AV59Configuracion_vendedoreswwds_4_ventipo1 ;
      private string AV63Configuracion_vendedoreswwds_8_vendsc2 ;
      private string AV64Configuracion_vendedoreswwds_9_ventipo2 ;
      private string AV68Configuracion_vendedoreswwds_13_vendsc3 ;
      private string AV69Configuracion_vendedoreswwds_14_ventipo3 ;
      private string AV72Configuracion_vendedoreswwds_17_tfvendsc ;
      private string AV73Configuracion_vendedoreswwds_18_tfvendsc_sel ;
      private string AV74Configuracion_vendedoreswwds_19_tfvendir ;
      private string AV75Configuracion_vendedoreswwds_20_tfvendir_sel ;
      private string scmdbuf ;
      private string lV58Configuracion_vendedoreswwds_3_vendsc1 ;
      private string lV63Configuracion_vendedoreswwds_8_vendsc2 ;
      private string lV68Configuracion_vendedoreswwds_13_vendsc3 ;
      private string lV72Configuracion_vendedoreswwds_17_tfvendsc ;
      private string lV74Configuracion_vendedoreswwds_19_tfvendir ;
      private string A2049VenTipo ;
      private string A2045VenDsc ;
      private string A2044VenDir ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV60Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 ;
      private bool AV65Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV49TFVenTipo_SelsJson ;
      private string AV45TFVenSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV56Configuracion_vendedoreswwds_1_dynamicfiltersselector1 ;
      private string AV61Configuracion_vendedoreswwds_6_dynamicfiltersselector2 ;
      private string AV66Configuracion_vendedoreswwds_11_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV46TFVenSts_Sels ;
      private GxSimpleCollection<short> AV77Configuracion_vendedoreswwds_22_tfvensts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00392_A2047VenSts ;
      private string[] P00392_A2044VenDir ;
      private int[] P00392_A309VenCod ;
      private string[] P00392_A2049VenTipo ;
      private string[] P00392_A2045VenDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GxSimpleCollection<string> AV50TFVenTipo_Sels ;
      private GxSimpleCollection<string> AV76Configuracion_vendedoreswwds_21_tfventipo_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
   }

   public class vendedoreswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00392( IGxContext context ,
                                             string A2049VenTipo ,
                                             GxSimpleCollection<string> AV76Configuracion_vendedoreswwds_21_tfventipo_sels ,
                                             short A2047VenSts ,
                                             GxSimpleCollection<short> AV77Configuracion_vendedoreswwds_22_tfvensts_sels ,
                                             string AV56Configuracion_vendedoreswwds_1_dynamicfiltersselector1 ,
                                             short AV57Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 ,
                                             string AV58Configuracion_vendedoreswwds_3_vendsc1 ,
                                             string AV59Configuracion_vendedoreswwds_4_ventipo1 ,
                                             bool AV60Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 ,
                                             string AV61Configuracion_vendedoreswwds_6_dynamicfiltersselector2 ,
                                             short AV62Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 ,
                                             string AV63Configuracion_vendedoreswwds_8_vendsc2 ,
                                             string AV64Configuracion_vendedoreswwds_9_ventipo2 ,
                                             bool AV65Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 ,
                                             string AV66Configuracion_vendedoreswwds_11_dynamicfiltersselector3 ,
                                             short AV67Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 ,
                                             string AV68Configuracion_vendedoreswwds_13_vendsc3 ,
                                             string AV69Configuracion_vendedoreswwds_14_ventipo3 ,
                                             int AV70Configuracion_vendedoreswwds_15_tfvencod ,
                                             int AV71Configuracion_vendedoreswwds_16_tfvencod_to ,
                                             string AV73Configuracion_vendedoreswwds_18_tfvendsc_sel ,
                                             string AV72Configuracion_vendedoreswwds_17_tfvendsc ,
                                             string AV75Configuracion_vendedoreswwds_20_tfvendir_sel ,
                                             string AV74Configuracion_vendedoreswwds_19_tfvendir ,
                                             int AV76Configuracion_vendedoreswwds_21_tfventipo_sels_Count ,
                                             int AV77Configuracion_vendedoreswwds_22_tfvensts_sels_Count ,
                                             string A2045VenDsc ,
                                             int A309VenCod ,
                                             string A2044VenDir ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [VenSts], [VenDir], [VenCod], [VenTipo], [VenDsc] FROM [CVENDEDORES]";
         if ( ( StringUtil.StrCmp(AV56Configuracion_vendedoreswwds_1_dynamicfiltersselector1, "VENDSC") == 0 ) && ( AV57Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_vendedoreswwds_3_vendsc1)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV58Configuracion_vendedoreswwds_3_vendsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Configuracion_vendedoreswwds_1_dynamicfiltersselector1, "VENDSC") == 0 ) && ( AV57Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_vendedoreswwds_3_vendsc1)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like '%' + @lV58Configuracion_vendedoreswwds_3_vendsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Configuracion_vendedoreswwds_1_dynamicfiltersselector1, "VENTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_vendedoreswwds_4_ventipo1)) ) )
         {
            AddWhere(sWhereString, "([VenTipo] = @AV59Configuracion_vendedoreswwds_4_ventipo1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV60Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_vendedoreswwds_6_dynamicfiltersselector2, "VENDSC") == 0 ) && ( AV62Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_vendedoreswwds_8_vendsc2)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV63Configuracion_vendedoreswwds_8_vendsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV60Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_vendedoreswwds_6_dynamicfiltersselector2, "VENDSC") == 0 ) && ( AV62Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_vendedoreswwds_8_vendsc2)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like '%' + @lV63Configuracion_vendedoreswwds_8_vendsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV60Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_vendedoreswwds_6_dynamicfiltersselector2, "VENTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_vendedoreswwds_9_ventipo2)) ) )
         {
            AddWhere(sWhereString, "([VenTipo] = @AV64Configuracion_vendedoreswwds_9_ventipo2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV65Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Configuracion_vendedoreswwds_11_dynamicfiltersselector3, "VENDSC") == 0 ) && ( AV67Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_vendedoreswwds_13_vendsc3)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV68Configuracion_vendedoreswwds_13_vendsc3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV65Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Configuracion_vendedoreswwds_11_dynamicfiltersselector3, "VENDSC") == 0 ) && ( AV67Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_vendedoreswwds_13_vendsc3)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like '%' + @lV68Configuracion_vendedoreswwds_13_vendsc3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV65Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Configuracion_vendedoreswwds_11_dynamicfiltersselector3, "VENTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_vendedoreswwds_14_ventipo3)) ) )
         {
            AddWhere(sWhereString, "([VenTipo] = @AV69Configuracion_vendedoreswwds_14_ventipo3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV70Configuracion_vendedoreswwds_15_tfvencod) )
         {
            AddWhere(sWhereString, "([VenCod] >= @AV70Configuracion_vendedoreswwds_15_tfvencod)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (0==AV71Configuracion_vendedoreswwds_16_tfvencod_to) )
         {
            AddWhere(sWhereString, "([VenCod] <= @AV71Configuracion_vendedoreswwds_16_tfvencod_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_vendedoreswwds_18_tfvendsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_vendedoreswwds_17_tfvendsc)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV72Configuracion_vendedoreswwds_17_tfvendsc)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_vendedoreswwds_18_tfvendsc_sel)) )
         {
            AddWhere(sWhereString, "([VenDsc] = @AV73Configuracion_vendedoreswwds_18_tfvendsc_sel)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_vendedoreswwds_20_tfvendir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_vendedoreswwds_19_tfvendir)) ) )
         {
            AddWhere(sWhereString, "([VenDir] like @lV74Configuracion_vendedoreswwds_19_tfvendir)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_vendedoreswwds_20_tfvendir_sel)) )
         {
            AddWhere(sWhereString, "([VenDir] = @AV75Configuracion_vendedoreswwds_20_tfvendir_sel)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV76Configuracion_vendedoreswwds_21_tfventipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Configuracion_vendedoreswwds_21_tfventipo_sels, "[VenTipo] IN (", ")")+")");
         }
         if ( AV77Configuracion_vendedoreswwds_22_tfvensts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Configuracion_vendedoreswwds_22_tfvensts_sels, "[VenSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [VenCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [VenCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [VenDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [VenDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [VenDir]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [VenDir] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [VenTipo]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [VenTipo] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [VenSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [VenSts] DESC";
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
                     return conditional_P00392(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP00392;
          prmP00392 = new Object[] {
          new ParDef("@lV58Configuracion_vendedoreswwds_3_vendsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_vendedoreswwds_3_vendsc1",GXType.NChar,100,0) ,
          new ParDef("@AV59Configuracion_vendedoreswwds_4_ventipo1",GXType.NChar,1,0) ,
          new ParDef("@lV63Configuracion_vendedoreswwds_8_vendsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_vendedoreswwds_8_vendsc2",GXType.NChar,100,0) ,
          new ParDef("@AV64Configuracion_vendedoreswwds_9_ventipo2",GXType.NChar,1,0) ,
          new ParDef("@lV68Configuracion_vendedoreswwds_13_vendsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_vendedoreswwds_13_vendsc3",GXType.NChar,100,0) ,
          new ParDef("@AV69Configuracion_vendedoreswwds_14_ventipo3",GXType.NChar,1,0) ,
          new ParDef("@AV70Configuracion_vendedoreswwds_15_tfvencod",GXType.Int32,6,0) ,
          new ParDef("@AV71Configuracion_vendedoreswwds_16_tfvencod_to",GXType.Int32,6,0) ,
          new ParDef("@lV72Configuracion_vendedoreswwds_17_tfvendsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_vendedoreswwds_18_tfvendsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_vendedoreswwds_19_tfvendir",GXType.NChar,100,0) ,
          new ParDef("@AV75Configuracion_vendedoreswwds_20_tfvendir_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00392", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00392,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
