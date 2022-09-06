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
   public class cajachicawwexport : GXProcedure
   {
      public cajachicawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cajachicawwexport( IGxContext context )
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
         cajachicawwexport objcajachicawwexport;
         objcajachicawwexport = new cajachicawwexport();
         objcajachicawwexport.AV11Filename = "" ;
         objcajachicawwexport.AV12ErrorMessage = "" ;
         objcajachicawwexport.context.SetSubmitInitialConfig(context);
         objcajachicawwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcajachicawwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cajachicawwexport)stateInfo).executePrivate();
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
         AV11Filename = "CajaChicaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CAJDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20CajDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20CajDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Caja Chica", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Caja Chica", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20CajDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CUECOD") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV48CueCod1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48CueCod1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48CueCod1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CAJDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24CajDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24CajDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Caja Chica", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Caja Chica", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24CajDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CUECOD") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV49CueCod2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49CueCod2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49CueCod2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CAJDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28CajDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28CajDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Caja Chica", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Caja Chica", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28CajDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CUECOD") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV50CueCod3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50CueCod3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV50CueCod3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFCajCod) && (0==AV35TFCajCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFCajCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFCajCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCajDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Caja Chica") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFCajDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCajDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Caja Chica") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFCajDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFCueCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFCueCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCueCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFCueCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFCueDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción de Cuenta") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFCueDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCueDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción de Cuenta") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFCueDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV45TFCajSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV47i = 1;
            AV55GXV1 = 1;
            while ( AV55GXV1 <= AV45TFCajSts_Sels.Count )
            {
               AV46TFCajSts_Sel = (short)(AV45TFCajSts_Sels.GetNumeric(AV55GXV1));
               if ( AV47i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV46TFCajSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV46TFCajSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV47i = (long)(AV47i+1);
               AV55GXV1 = (int)(AV55GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Caja Chica";
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
         AV57Bancos_cajachicawwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV58Bancos_cajachicawwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV59Bancos_cajachicawwds_3_cajdsc1 = AV20CajDsc1;
         AV60Bancos_cajachicawwds_4_cuecod1 = AV48CueCod1;
         AV61Bancos_cajachicawwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV62Bancos_cajachicawwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV63Bancos_cajachicawwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV64Bancos_cajachicawwds_8_cajdsc2 = AV24CajDsc2;
         AV65Bancos_cajachicawwds_9_cuecod2 = AV49CueCod2;
         AV66Bancos_cajachicawwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV67Bancos_cajachicawwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV68Bancos_cajachicawwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV69Bancos_cajachicawwds_13_cajdsc3 = AV28CajDsc3;
         AV70Bancos_cajachicawwds_14_cuecod3 = AV50CueCod3;
         AV71Bancos_cajachicawwds_15_tfcajcod = AV34TFCajCod;
         AV72Bancos_cajachicawwds_16_tfcajcod_to = AV35TFCajCod_To;
         AV73Bancos_cajachicawwds_17_tfcajdsc = AV36TFCajDsc;
         AV74Bancos_cajachicawwds_18_tfcajdsc_sel = AV37TFCajDsc_Sel;
         AV75Bancos_cajachicawwds_19_tfcuecod = AV40TFCueCod;
         AV76Bancos_cajachicawwds_20_tfcuecod_sel = AV41TFCueCod_Sel;
         AV77Bancos_cajachicawwds_21_tfcuedsc = AV51TFCueDsc;
         AV78Bancos_cajachicawwds_22_tfcuedsc_sel = AV52TFCueDsc_Sel;
         AV79Bancos_cajachicawwds_23_tfcajsts_sels = AV45TFCajSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A487CajSts ,
                                              AV79Bancos_cajachicawwds_23_tfcajsts_sels ,
                                              AV57Bancos_cajachicawwds_1_dynamicfiltersselector1 ,
                                              AV58Bancos_cajachicawwds_2_dynamicfiltersoperator1 ,
                                              AV59Bancos_cajachicawwds_3_cajdsc1 ,
                                              AV60Bancos_cajachicawwds_4_cuecod1 ,
                                              AV61Bancos_cajachicawwds_5_dynamicfiltersenabled2 ,
                                              AV62Bancos_cajachicawwds_6_dynamicfiltersselector2 ,
                                              AV63Bancos_cajachicawwds_7_dynamicfiltersoperator2 ,
                                              AV64Bancos_cajachicawwds_8_cajdsc2 ,
                                              AV65Bancos_cajachicawwds_9_cuecod2 ,
                                              AV66Bancos_cajachicawwds_10_dynamicfiltersenabled3 ,
                                              AV67Bancos_cajachicawwds_11_dynamicfiltersselector3 ,
                                              AV68Bancos_cajachicawwds_12_dynamicfiltersoperator3 ,
                                              AV69Bancos_cajachicawwds_13_cajdsc3 ,
                                              AV70Bancos_cajachicawwds_14_cuecod3 ,
                                              AV71Bancos_cajachicawwds_15_tfcajcod ,
                                              AV72Bancos_cajachicawwds_16_tfcajcod_to ,
                                              AV74Bancos_cajachicawwds_18_tfcajdsc_sel ,
                                              AV73Bancos_cajachicawwds_17_tfcajdsc ,
                                              AV76Bancos_cajachicawwds_20_tfcuecod_sel ,
                                              AV75Bancos_cajachicawwds_19_tfcuecod ,
                                              AV78Bancos_cajachicawwds_22_tfcuedsc_sel ,
                                              AV77Bancos_cajachicawwds_21_tfcuedsc ,
                                              AV79Bancos_cajachicawwds_23_tfcajsts_sels.Count ,
                                              A486CajDsc ,
                                              A91CueCod ,
                                              A358CajCod ,
                                              A860CueDsc ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Bancos_cajachicawwds_3_cajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Bancos_cajachicawwds_3_cajdsc1), 100, "%");
         lV59Bancos_cajachicawwds_3_cajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Bancos_cajachicawwds_3_cajdsc1), 100, "%");
         lV60Bancos_cajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_cajachicawwds_4_cuecod1), 15, "%");
         lV60Bancos_cajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_cajachicawwds_4_cuecod1), 15, "%");
         lV64Bancos_cajachicawwds_8_cajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_cajachicawwds_8_cajdsc2), 100, "%");
         lV64Bancos_cajachicawwds_8_cajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_cajachicawwds_8_cajdsc2), 100, "%");
         lV65Bancos_cajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_cajachicawwds_9_cuecod2), 15, "%");
         lV65Bancos_cajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_cajachicawwds_9_cuecod2), 15, "%");
         lV69Bancos_cajachicawwds_13_cajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_cajachicawwds_13_cajdsc3), 100, "%");
         lV69Bancos_cajachicawwds_13_cajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_cajachicawwds_13_cajdsc3), 100, "%");
         lV70Bancos_cajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_cajachicawwds_14_cuecod3), 15, "%");
         lV70Bancos_cajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_cajachicawwds_14_cuecod3), 15, "%");
         lV73Bancos_cajachicawwds_17_tfcajdsc = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_cajachicawwds_17_tfcajdsc), 100, "%");
         lV75Bancos_cajachicawwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV75Bancos_cajachicawwds_19_tfcuecod), 15, "%");
         lV77Bancos_cajachicawwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV77Bancos_cajachicawwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005L2 */
         pr_default.execute(0, new Object[] {lV59Bancos_cajachicawwds_3_cajdsc1, lV59Bancos_cajachicawwds_3_cajdsc1, lV60Bancos_cajachicawwds_4_cuecod1, lV60Bancos_cajachicawwds_4_cuecod1, lV64Bancos_cajachicawwds_8_cajdsc2, lV64Bancos_cajachicawwds_8_cajdsc2, lV65Bancos_cajachicawwds_9_cuecod2, lV65Bancos_cajachicawwds_9_cuecod2, lV69Bancos_cajachicawwds_13_cajdsc3, lV69Bancos_cajachicawwds_13_cajdsc3, lV70Bancos_cajachicawwds_14_cuecod3, lV70Bancos_cajachicawwds_14_cuecod3, AV71Bancos_cajachicawwds_15_tfcajcod, AV72Bancos_cajachicawwds_16_tfcajcod_to, lV73Bancos_cajachicawwds_17_tfcajdsc, AV74Bancos_cajachicawwds_18_tfcajdsc_sel, lV75Bancos_cajachicawwds_19_tfcuecod, AV76Bancos_cajachicawwds_20_tfcuecod_sel, lV77Bancos_cajachicawwds_21_tfcuedsc, AV78Bancos_cajachicawwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A487CajSts = P005L2_A487CajSts[0];
            A860CueDsc = P005L2_A860CueDsc[0];
            A358CajCod = P005L2_A358CajCod[0];
            A91CueCod = P005L2_A91CueCod[0];
            A486CajDsc = P005L2_A486CajDsc[0];
            A860CueDsc = P005L2_A860CueDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A358CajCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A486CajDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A91CueCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A860CueDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A487CajSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "ACTIVO";
            }
            else if ( A487CajSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Bancos.CajaChicaWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.CajaChicaWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Bancos.CajaChicaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV80GXV2 = 1;
         while ( AV80GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV80GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCAJCOD") == 0 )
            {
               AV34TFCajCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFCajCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCAJDSC") == 0 )
            {
               AV36TFCajDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCAJDSC_SEL") == 0 )
            {
               AV37TFCajDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV40TFCueCod = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV41TFCueCod_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV51TFCueDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV52TFCueDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCAJSTS_SEL") == 0 )
            {
               AV44TFCajSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV45TFCajSts_Sels.FromJSonString(AV44TFCajSts_SelsJson, null);
            }
            AV80GXV2 = (int)(AV80GXV2+1);
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
         AV20CajDsc1 = "";
         AV48CueCod1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24CajDsc2 = "";
         AV49CueCod2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28CajDsc3 = "";
         AV50CueCod3 = "";
         AV37TFCajDsc_Sel = "";
         AV36TFCajDsc = "";
         AV41TFCueCod_Sel = "";
         AV40TFCueCod = "";
         AV52TFCueDsc_Sel = "";
         AV51TFCueDsc = "";
         AV45TFCajSts_Sels = new GxSimpleCollection<short>();
         AV57Bancos_cajachicawwds_1_dynamicfiltersselector1 = "";
         AV59Bancos_cajachicawwds_3_cajdsc1 = "";
         AV60Bancos_cajachicawwds_4_cuecod1 = "";
         AV62Bancos_cajachicawwds_6_dynamicfiltersselector2 = "";
         AV64Bancos_cajachicawwds_8_cajdsc2 = "";
         AV65Bancos_cajachicawwds_9_cuecod2 = "";
         AV67Bancos_cajachicawwds_11_dynamicfiltersselector3 = "";
         AV69Bancos_cajachicawwds_13_cajdsc3 = "";
         AV70Bancos_cajachicawwds_14_cuecod3 = "";
         AV73Bancos_cajachicawwds_17_tfcajdsc = "";
         AV74Bancos_cajachicawwds_18_tfcajdsc_sel = "";
         AV75Bancos_cajachicawwds_19_tfcuecod = "";
         AV76Bancos_cajachicawwds_20_tfcuecod_sel = "";
         AV77Bancos_cajachicawwds_21_tfcuedsc = "";
         AV78Bancos_cajachicawwds_22_tfcuedsc_sel = "";
         AV79Bancos_cajachicawwds_23_tfcajsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV59Bancos_cajachicawwds_3_cajdsc1 = "";
         lV60Bancos_cajachicawwds_4_cuecod1 = "";
         lV64Bancos_cajachicawwds_8_cajdsc2 = "";
         lV65Bancos_cajachicawwds_9_cuecod2 = "";
         lV69Bancos_cajachicawwds_13_cajdsc3 = "";
         lV70Bancos_cajachicawwds_14_cuecod3 = "";
         lV73Bancos_cajachicawwds_17_tfcajdsc = "";
         lV75Bancos_cajachicawwds_19_tfcuecod = "";
         lV77Bancos_cajachicawwds_21_tfcuedsc = "";
         A486CajDsc = "";
         A91CueCod = "";
         A860CueDsc = "";
         P005L2_A487CajSts = new short[1] ;
         P005L2_A860CueDsc = new string[] {""} ;
         P005L2_A358CajCod = new int[1] ;
         P005L2_A91CueCod = new string[] {""} ;
         P005L2_A486CajDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV44TFCajSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.cajachicawwexport__default(),
            new Object[][] {
                new Object[] {
               P005L2_A487CajSts, P005L2_A860CueDsc, P005L2_A358CajCod, P005L2_A91CueCod, P005L2_A486CajDsc
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
      private short AV46TFCajSts_Sel ;
      private short AV58Bancos_cajachicawwds_2_dynamicfiltersoperator1 ;
      private short AV63Bancos_cajachicawwds_7_dynamicfiltersoperator2 ;
      private short AV68Bancos_cajachicawwds_12_dynamicfiltersoperator3 ;
      private short A487CajSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFCajCod ;
      private int AV35TFCajCod_To ;
      private int AV55GXV1 ;
      private int AV71Bancos_cajachicawwds_15_tfcajcod ;
      private int AV72Bancos_cajachicawwds_16_tfcajcod_to ;
      private int AV79Bancos_cajachicawwds_23_tfcajsts_sels_Count ;
      private int A358CajCod ;
      private int AV80GXV2 ;
      private long AV47i ;
      private string AV20CajDsc1 ;
      private string AV48CueCod1 ;
      private string AV24CajDsc2 ;
      private string AV49CueCod2 ;
      private string AV28CajDsc3 ;
      private string AV50CueCod3 ;
      private string AV37TFCajDsc_Sel ;
      private string AV36TFCajDsc ;
      private string AV41TFCueCod_Sel ;
      private string AV40TFCueCod ;
      private string AV52TFCueDsc_Sel ;
      private string AV51TFCueDsc ;
      private string AV59Bancos_cajachicawwds_3_cajdsc1 ;
      private string AV60Bancos_cajachicawwds_4_cuecod1 ;
      private string AV64Bancos_cajachicawwds_8_cajdsc2 ;
      private string AV65Bancos_cajachicawwds_9_cuecod2 ;
      private string AV69Bancos_cajachicawwds_13_cajdsc3 ;
      private string AV70Bancos_cajachicawwds_14_cuecod3 ;
      private string AV73Bancos_cajachicawwds_17_tfcajdsc ;
      private string AV74Bancos_cajachicawwds_18_tfcajdsc_sel ;
      private string AV75Bancos_cajachicawwds_19_tfcuecod ;
      private string AV76Bancos_cajachicawwds_20_tfcuecod_sel ;
      private string AV77Bancos_cajachicawwds_21_tfcuedsc ;
      private string AV78Bancos_cajachicawwds_22_tfcuedsc_sel ;
      private string scmdbuf ;
      private string lV59Bancos_cajachicawwds_3_cajdsc1 ;
      private string lV60Bancos_cajachicawwds_4_cuecod1 ;
      private string lV64Bancos_cajachicawwds_8_cajdsc2 ;
      private string lV65Bancos_cajachicawwds_9_cuecod2 ;
      private string lV69Bancos_cajachicawwds_13_cajdsc3 ;
      private string lV70Bancos_cajachicawwds_14_cuecod3 ;
      private string lV73Bancos_cajachicawwds_17_tfcajdsc ;
      private string lV75Bancos_cajachicawwds_19_tfcuecod ;
      private string lV77Bancos_cajachicawwds_21_tfcuedsc ;
      private string A486CajDsc ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV61Bancos_cajachicawwds_5_dynamicfiltersenabled2 ;
      private bool AV66Bancos_cajachicawwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV44TFCajSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV57Bancos_cajachicawwds_1_dynamicfiltersselector1 ;
      private string AV62Bancos_cajachicawwds_6_dynamicfiltersselector2 ;
      private string AV67Bancos_cajachicawwds_11_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV45TFCajSts_Sels ;
      private GxSimpleCollection<short> AV79Bancos_cajachicawwds_23_tfcajsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005L2_A487CajSts ;
      private string[] P005L2_A860CueDsc ;
      private int[] P005L2_A358CajCod ;
      private string[] P005L2_A91CueCod ;
      private string[] P005L2_A486CajDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class cajachicawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005L2( IGxContext context ,
                                             short A487CajSts ,
                                             GxSimpleCollection<short> AV79Bancos_cajachicawwds_23_tfcajsts_sels ,
                                             string AV57Bancos_cajachicawwds_1_dynamicfiltersselector1 ,
                                             short AV58Bancos_cajachicawwds_2_dynamicfiltersoperator1 ,
                                             string AV59Bancos_cajachicawwds_3_cajdsc1 ,
                                             string AV60Bancos_cajachicawwds_4_cuecod1 ,
                                             bool AV61Bancos_cajachicawwds_5_dynamicfiltersenabled2 ,
                                             string AV62Bancos_cajachicawwds_6_dynamicfiltersselector2 ,
                                             short AV63Bancos_cajachicawwds_7_dynamicfiltersoperator2 ,
                                             string AV64Bancos_cajachicawwds_8_cajdsc2 ,
                                             string AV65Bancos_cajachicawwds_9_cuecod2 ,
                                             bool AV66Bancos_cajachicawwds_10_dynamicfiltersenabled3 ,
                                             string AV67Bancos_cajachicawwds_11_dynamicfiltersselector3 ,
                                             short AV68Bancos_cajachicawwds_12_dynamicfiltersoperator3 ,
                                             string AV69Bancos_cajachicawwds_13_cajdsc3 ,
                                             string AV70Bancos_cajachicawwds_14_cuecod3 ,
                                             int AV71Bancos_cajachicawwds_15_tfcajcod ,
                                             int AV72Bancos_cajachicawwds_16_tfcajcod_to ,
                                             string AV74Bancos_cajachicawwds_18_tfcajdsc_sel ,
                                             string AV73Bancos_cajachicawwds_17_tfcajdsc ,
                                             string AV76Bancos_cajachicawwds_20_tfcuecod_sel ,
                                             string AV75Bancos_cajachicawwds_19_tfcuecod ,
                                             string AV78Bancos_cajachicawwds_22_tfcuedsc_sel ,
                                             string AV77Bancos_cajachicawwds_21_tfcuedsc ,
                                             int AV79Bancos_cajachicawwds_23_tfcajsts_sels_Count ,
                                             string A486CajDsc ,
                                             string A91CueCod ,
                                             int A358CajCod ,
                                             string A860CueDsc ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CajSts], T2.[CueDsc], T1.[CajCod], T1.[CueCod], T1.[CajDsc] FROM ([TSCAJACHICA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV57Bancos_cajachicawwds_1_dynamicfiltersselector1, "CAJDSC") == 0 ) && ( AV58Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Bancos_cajachicawwds_3_cajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV59Bancos_cajachicawwds_3_cajdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Bancos_cajachicawwds_1_dynamicfiltersselector1, "CAJDSC") == 0 ) && ( AV58Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Bancos_cajachicawwds_3_cajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV59Bancos_cajachicawwds_3_cajdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Bancos_cajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV58Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_cajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV60Bancos_cajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Bancos_cajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV58Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_cajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV60Bancos_cajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV61Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Bancos_cajachicawwds_6_dynamicfiltersselector2, "CAJDSC") == 0 ) && ( AV63Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_cajachicawwds_8_cajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV64Bancos_cajachicawwds_8_cajdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV61Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Bancos_cajachicawwds_6_dynamicfiltersselector2, "CAJDSC") == 0 ) && ( AV63Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_cajachicawwds_8_cajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV64Bancos_cajachicawwds_8_cajdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV61Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Bancos_cajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV63Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_cajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV65Bancos_cajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV61Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Bancos_cajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV63Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_cajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV65Bancos_cajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV66Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Bancos_cajachicawwds_11_dynamicfiltersselector3, "CAJDSC") == 0 ) && ( AV68Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_cajachicawwds_13_cajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV69Bancos_cajachicawwds_13_cajdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV66Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Bancos_cajachicawwds_11_dynamicfiltersselector3, "CAJDSC") == 0 ) && ( AV68Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_cajachicawwds_13_cajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV69Bancos_cajachicawwds_13_cajdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV66Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Bancos_cajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV68Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_cajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV70Bancos_cajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV66Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Bancos_cajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV68Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_cajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV70Bancos_cajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV71Bancos_cajachicawwds_15_tfcajcod) )
         {
            AddWhere(sWhereString, "(T1.[CajCod] >= @AV71Bancos_cajachicawwds_15_tfcajcod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV72Bancos_cajachicawwds_16_tfcajcod_to) )
         {
            AddWhere(sWhereString, "(T1.[CajCod] <= @AV72Bancos_cajachicawwds_16_tfcajcod_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_cajachicawwds_18_tfcajdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_cajachicawwds_17_tfcajdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV73Bancos_cajachicawwds_17_tfcajdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_cajachicawwds_18_tfcajdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] = @AV74Bancos_cajachicawwds_18_tfcajdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_cajachicawwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_cajachicawwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV75Bancos_cajachicawwds_19_tfcuecod)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_cajachicawwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV76Bancos_cajachicawwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_cajachicawwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_cajachicawwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV77Bancos_cajachicawwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_cajachicawwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV78Bancos_cajachicawwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV79Bancos_cajachicawwds_23_tfcajsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Bancos_cajachicawwds_23_tfcajsts_sels, "T1.[CajSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CajCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CajCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CajDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CajDsc] DESC";
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
            scmdbuf += " ORDER BY T1.[CajSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CajSts] DESC";
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
                     return conditional_P005L2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP005L2;
          prmP005L2 = new Object[] {
          new ParDef("@lV59Bancos_cajachicawwds_3_cajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Bancos_cajachicawwds_3_cajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Bancos_cajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV60Bancos_cajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV64Bancos_cajachicawwds_8_cajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV64Bancos_cajachicawwds_8_cajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_cajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV65Bancos_cajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV69Bancos_cajachicawwds_13_cajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Bancos_cajachicawwds_13_cajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_cajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV70Bancos_cajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV71Bancos_cajachicawwds_15_tfcajcod",GXType.Int32,6,0) ,
          new ParDef("@AV72Bancos_cajachicawwds_16_tfcajcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV73Bancos_cajachicawwds_17_tfcajdsc",GXType.NChar,100,0) ,
          new ParDef("@AV74Bancos_cajachicawwds_18_tfcajdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV75Bancos_cajachicawwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV76Bancos_cajachicawwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV77Bancos_cajachicawwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV78Bancos_cajachicawwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005L2,100, GxCacheFrequency.OFF ,true,false )
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
