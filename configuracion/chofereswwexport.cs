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
   public class chofereswwexport : GXProcedure
   {
      public chofereswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public chofereswwexport( IGxContext context )
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
         chofereswwexport objchofereswwexport;
         objchofereswwexport = new chofereswwexport();
         objchofereswwexport.AV11Filename = "" ;
         objchofereswwexport.AV12ErrorMessage = "" ;
         objchofereswwexport.context.SetSubmitInitialConfig(context);
         objchofereswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objchofereswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((chofereswwexport)stateInfo).executePrivate();
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
         AV11Filename = "ChoferesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CHODSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20ChoDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ChoDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Chofer", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Chofer", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20ChoDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CHOPLACA") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV60ChoPlaca1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60ChoPlaca1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Placa", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Placa", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV60ChoPlaca1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CHOLICENCIA") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV61ChoLicencia1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ChoLicencia1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Licencia", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Licencia", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV61ChoLicencia1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CHODSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24ChoDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ChoDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Chofer", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Chofer", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24ChoDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CHOPLACA") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV62ChoPlaca2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62ChoPlaca2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Placa", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Placa", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62ChoPlaca2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CHOLICENCIA") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV63ChoLicencia2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ChoLicencia2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Licencia", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Licencia", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV63ChoLicencia2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CHODSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28ChoDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ChoDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Chofer", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Chofer", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ChoDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CHOPLACA") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV64ChoPlaca3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64ChoPlaca3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Placa", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Placa", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV64ChoPlaca3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CHOLICENCIA") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV65ChoLicencia3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65ChoLicencia3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Licencia", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "N° Licencia", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV65ChoLicencia3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFChoCod) && (0==AV35TFChoCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFChoCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFChoCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFChoDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Chofer") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFChoDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFChoDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Chofer") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFChoDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFChoDir_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Dirección") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFChoDir_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFChoDir)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Dirección") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFChoDir, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFChoRuc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "R.U.C.") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFChoRuc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFChoRuc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "R.U.C.") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFChoRuc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFChoPlaca_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Placa") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFChoPlaca_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFChoPlaca)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Placa") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TFChoPlaca, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFChoLicencia_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "N° Licencia") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFChoLicencia_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFChoLicencia)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "N° Licencia") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48TFChoLicencia, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV57TFChoSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV59i = 1;
            AV68GXV1 = 1;
            while ( AV68GXV1 <= AV57TFChoSts_Sels.Count )
            {
               AV58TFChoSts_Sel = (short)(AV57TFChoSts_Sels.GetNumeric(AV68GXV1));
               if ( AV59i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV58TFChoSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV58TFChoSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV59i = (long)(AV59i+1);
               AV68GXV1 = (int)(AV68GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Chofer";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Dirección";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "R.U.C.";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Placa";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "N° Licencia";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV70Configuracion_chofereswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV71Configuracion_chofereswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV72Configuracion_chofereswwds_3_chodsc1 = AV20ChoDsc1;
         AV73Configuracion_chofereswwds_4_choplaca1 = AV60ChoPlaca1;
         AV74Configuracion_chofereswwds_5_cholicencia1 = AV61ChoLicencia1;
         AV75Configuracion_chofereswwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV76Configuracion_chofereswwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV77Configuracion_chofereswwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV78Configuracion_chofereswwds_9_chodsc2 = AV24ChoDsc2;
         AV79Configuracion_chofereswwds_10_choplaca2 = AV62ChoPlaca2;
         AV80Configuracion_chofereswwds_11_cholicencia2 = AV63ChoLicencia2;
         AV81Configuracion_chofereswwds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV82Configuracion_chofereswwds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV83Configuracion_chofereswwds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV84Configuracion_chofereswwds_15_chodsc3 = AV28ChoDsc3;
         AV85Configuracion_chofereswwds_16_choplaca3 = AV64ChoPlaca3;
         AV86Configuracion_chofereswwds_17_cholicencia3 = AV65ChoLicencia3;
         AV87Configuracion_chofereswwds_18_tfchocod = AV34TFChoCod;
         AV88Configuracion_chofereswwds_19_tfchocod_to = AV35TFChoCod_To;
         AV89Configuracion_chofereswwds_20_tfchodsc = AV36TFChoDsc;
         AV90Configuracion_chofereswwds_21_tfchodsc_sel = AV37TFChoDsc_Sel;
         AV91Configuracion_chofereswwds_22_tfchodir = AV38TFChoDir;
         AV92Configuracion_chofereswwds_23_tfchodir_sel = AV39TFChoDir_Sel;
         AV93Configuracion_chofereswwds_24_tfchoruc = AV42TFChoRuc;
         AV94Configuracion_chofereswwds_25_tfchoruc_sel = AV43TFChoRuc_Sel;
         AV95Configuracion_chofereswwds_26_tfchoplaca = AV46TFChoPlaca;
         AV96Configuracion_chofereswwds_27_tfchoplaca_sel = AV47TFChoPlaca_Sel;
         AV97Configuracion_chofereswwds_28_tfcholicencia = AV48TFChoLicencia;
         AV98Configuracion_chofereswwds_29_tfcholicencia_sel = AV49TFChoLicencia_Sel;
         AV99Configuracion_chofereswwds_30_tfchosts_sels = AV57TFChoSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A549ChoSts ,
                                              AV99Configuracion_chofereswwds_30_tfchosts_sels ,
                                              AV70Configuracion_chofereswwds_1_dynamicfiltersselector1 ,
                                              AV71Configuracion_chofereswwds_2_dynamicfiltersoperator1 ,
                                              AV72Configuracion_chofereswwds_3_chodsc1 ,
                                              AV73Configuracion_chofereswwds_4_choplaca1 ,
                                              AV74Configuracion_chofereswwds_5_cholicencia1 ,
                                              AV75Configuracion_chofereswwds_6_dynamicfiltersenabled2 ,
                                              AV76Configuracion_chofereswwds_7_dynamicfiltersselector2 ,
                                              AV77Configuracion_chofereswwds_8_dynamicfiltersoperator2 ,
                                              AV78Configuracion_chofereswwds_9_chodsc2 ,
                                              AV79Configuracion_chofereswwds_10_choplaca2 ,
                                              AV80Configuracion_chofereswwds_11_cholicencia2 ,
                                              AV81Configuracion_chofereswwds_12_dynamicfiltersenabled3 ,
                                              AV82Configuracion_chofereswwds_13_dynamicfiltersselector3 ,
                                              AV83Configuracion_chofereswwds_14_dynamicfiltersoperator3 ,
                                              AV84Configuracion_chofereswwds_15_chodsc3 ,
                                              AV85Configuracion_chofereswwds_16_choplaca3 ,
                                              AV86Configuracion_chofereswwds_17_cholicencia3 ,
                                              AV87Configuracion_chofereswwds_18_tfchocod ,
                                              AV88Configuracion_chofereswwds_19_tfchocod_to ,
                                              AV90Configuracion_chofereswwds_21_tfchodsc_sel ,
                                              AV89Configuracion_chofereswwds_20_tfchodsc ,
                                              AV92Configuracion_chofereswwds_23_tfchodir_sel ,
                                              AV91Configuracion_chofereswwds_22_tfchodir ,
                                              AV94Configuracion_chofereswwds_25_tfchoruc_sel ,
                                              AV93Configuracion_chofereswwds_24_tfchoruc ,
                                              AV96Configuracion_chofereswwds_27_tfchoplaca_sel ,
                                              AV95Configuracion_chofereswwds_26_tfchoplaca ,
                                              AV98Configuracion_chofereswwds_29_tfcholicencia_sel ,
                                              AV97Configuracion_chofereswwds_28_tfcholicencia ,
                                              AV99Configuracion_chofereswwds_30_tfchosts_sels.Count ,
                                              A542ChoDsc ,
                                              A543ChoPlaca ,
                                              A546ChoLicencia ,
                                              A10ChoCod ,
                                              A545ChoDir ,
                                              A548ChoRuc ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV72Configuracion_chofereswwds_3_chodsc1 = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_chofereswwds_3_chodsc1), 100, "%");
         lV72Configuracion_chofereswwds_3_chodsc1 = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_chofereswwds_3_chodsc1), 100, "%");
         lV73Configuracion_chofereswwds_4_choplaca1 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_chofereswwds_4_choplaca1), 20, "%");
         lV73Configuracion_chofereswwds_4_choplaca1 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_chofereswwds_4_choplaca1), 20, "%");
         lV74Configuracion_chofereswwds_5_cholicencia1 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_chofereswwds_5_cholicencia1), 20, "%");
         lV74Configuracion_chofereswwds_5_cholicencia1 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_chofereswwds_5_cholicencia1), 20, "%");
         lV78Configuracion_chofereswwds_9_chodsc2 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_chofereswwds_9_chodsc2), 100, "%");
         lV78Configuracion_chofereswwds_9_chodsc2 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_chofereswwds_9_chodsc2), 100, "%");
         lV79Configuracion_chofereswwds_10_choplaca2 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_chofereswwds_10_choplaca2), 20, "%");
         lV79Configuracion_chofereswwds_10_choplaca2 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_chofereswwds_10_choplaca2), 20, "%");
         lV80Configuracion_chofereswwds_11_cholicencia2 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_chofereswwds_11_cholicencia2), 20, "%");
         lV80Configuracion_chofereswwds_11_cholicencia2 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_chofereswwds_11_cholicencia2), 20, "%");
         lV84Configuracion_chofereswwds_15_chodsc3 = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_chofereswwds_15_chodsc3), 100, "%");
         lV84Configuracion_chofereswwds_15_chodsc3 = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_chofereswwds_15_chodsc3), 100, "%");
         lV85Configuracion_chofereswwds_16_choplaca3 = StringUtil.PadR( StringUtil.RTrim( AV85Configuracion_chofereswwds_16_choplaca3), 20, "%");
         lV85Configuracion_chofereswwds_16_choplaca3 = StringUtil.PadR( StringUtil.RTrim( AV85Configuracion_chofereswwds_16_choplaca3), 20, "%");
         lV86Configuracion_chofereswwds_17_cholicencia3 = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_chofereswwds_17_cholicencia3), 20, "%");
         lV86Configuracion_chofereswwds_17_cholicencia3 = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_chofereswwds_17_cholicencia3), 20, "%");
         lV89Configuracion_chofereswwds_20_tfchodsc = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_chofereswwds_20_tfchodsc), 100, "%");
         lV91Configuracion_chofereswwds_22_tfchodir = StringUtil.PadR( StringUtil.RTrim( AV91Configuracion_chofereswwds_22_tfchodir), 100, "%");
         lV93Configuracion_chofereswwds_24_tfchoruc = StringUtil.PadR( StringUtil.RTrim( AV93Configuracion_chofereswwds_24_tfchoruc), 20, "%");
         lV95Configuracion_chofereswwds_26_tfchoplaca = StringUtil.PadR( StringUtil.RTrim( AV95Configuracion_chofereswwds_26_tfchoplaca), 20, "%");
         lV97Configuracion_chofereswwds_28_tfcholicencia = StringUtil.PadR( StringUtil.RTrim( AV97Configuracion_chofereswwds_28_tfcholicencia), 20, "%");
         /* Using cursor P00322 */
         pr_default.execute(0, new Object[] {lV72Configuracion_chofereswwds_3_chodsc1, lV72Configuracion_chofereswwds_3_chodsc1, lV73Configuracion_chofereswwds_4_choplaca1, lV73Configuracion_chofereswwds_4_choplaca1, lV74Configuracion_chofereswwds_5_cholicencia1, lV74Configuracion_chofereswwds_5_cholicencia1, lV78Configuracion_chofereswwds_9_chodsc2, lV78Configuracion_chofereswwds_9_chodsc2, lV79Configuracion_chofereswwds_10_choplaca2, lV79Configuracion_chofereswwds_10_choplaca2, lV80Configuracion_chofereswwds_11_cholicencia2, lV80Configuracion_chofereswwds_11_cholicencia2, lV84Configuracion_chofereswwds_15_chodsc3, lV84Configuracion_chofereswwds_15_chodsc3, lV85Configuracion_chofereswwds_16_choplaca3, lV85Configuracion_chofereswwds_16_choplaca3, lV86Configuracion_chofereswwds_17_cholicencia3, lV86Configuracion_chofereswwds_17_cholicencia3, AV87Configuracion_chofereswwds_18_tfchocod, AV88Configuracion_chofereswwds_19_tfchocod_to, lV89Configuracion_chofereswwds_20_tfchodsc, AV90Configuracion_chofereswwds_21_tfchodsc_sel, lV91Configuracion_chofereswwds_22_tfchodir, AV92Configuracion_chofereswwds_23_tfchodir_sel, lV93Configuracion_chofereswwds_24_tfchoruc, AV94Configuracion_chofereswwds_25_tfchoruc_sel, lV95Configuracion_chofereswwds_26_tfchoplaca, AV96Configuracion_chofereswwds_27_tfchoplaca_sel, lV97Configuracion_chofereswwds_28_tfcholicencia, AV98Configuracion_chofereswwds_29_tfcholicencia_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A549ChoSts = P00322_A549ChoSts[0];
            A548ChoRuc = P00322_A548ChoRuc[0];
            A545ChoDir = P00322_A545ChoDir[0];
            A10ChoCod = P00322_A10ChoCod[0];
            A546ChoLicencia = P00322_A546ChoLicencia[0];
            A543ChoPlaca = P00322_A543ChoPlaca[0];
            A542ChoDsc = P00322_A542ChoDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A10ChoCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A542ChoDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A545ChoDir, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A548ChoRuc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A543ChoPlaca, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A546ChoLicencia, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "";
            if ( A549ChoSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "ACTIVO";
            }
            else if ( A549ChoSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "INACTIVO";
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.ChoferesWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.ChoferesWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.ChoferesWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV100GXV2 = 1;
         while ( AV100GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV100GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCHOCOD") == 0 )
            {
               AV34TFChoCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFChoCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCHODSC") == 0 )
            {
               AV36TFChoDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCHODSC_SEL") == 0 )
            {
               AV37TFChoDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCHODIR") == 0 )
            {
               AV38TFChoDir = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCHODIR_SEL") == 0 )
            {
               AV39TFChoDir_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCHORUC") == 0 )
            {
               AV42TFChoRuc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCHORUC_SEL") == 0 )
            {
               AV43TFChoRuc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCHOPLACA") == 0 )
            {
               AV46TFChoPlaca = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCHOPLACA_SEL") == 0 )
            {
               AV47TFChoPlaca_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCHOLICENCIA") == 0 )
            {
               AV48TFChoLicencia = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCHOLICENCIA_SEL") == 0 )
            {
               AV49TFChoLicencia_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCHOSTS_SEL") == 0 )
            {
               AV56TFChoSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV57TFChoSts_Sels.FromJSonString(AV56TFChoSts_SelsJson, null);
            }
            AV100GXV2 = (int)(AV100GXV2+1);
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
         AV20ChoDsc1 = "";
         AV60ChoPlaca1 = "";
         AV61ChoLicencia1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24ChoDsc2 = "";
         AV62ChoPlaca2 = "";
         AV63ChoLicencia2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28ChoDsc3 = "";
         AV64ChoPlaca3 = "";
         AV65ChoLicencia3 = "";
         AV37TFChoDsc_Sel = "";
         AV36TFChoDsc = "";
         AV39TFChoDir_Sel = "";
         AV38TFChoDir = "";
         AV43TFChoRuc_Sel = "";
         AV42TFChoRuc = "";
         AV47TFChoPlaca_Sel = "";
         AV46TFChoPlaca = "";
         AV49TFChoLicencia_Sel = "";
         AV48TFChoLicencia = "";
         AV57TFChoSts_Sels = new GxSimpleCollection<short>();
         AV70Configuracion_chofereswwds_1_dynamicfiltersselector1 = "";
         AV72Configuracion_chofereswwds_3_chodsc1 = "";
         AV73Configuracion_chofereswwds_4_choplaca1 = "";
         AV74Configuracion_chofereswwds_5_cholicencia1 = "";
         AV76Configuracion_chofereswwds_7_dynamicfiltersselector2 = "";
         AV78Configuracion_chofereswwds_9_chodsc2 = "";
         AV79Configuracion_chofereswwds_10_choplaca2 = "";
         AV80Configuracion_chofereswwds_11_cholicencia2 = "";
         AV82Configuracion_chofereswwds_13_dynamicfiltersselector3 = "";
         AV84Configuracion_chofereswwds_15_chodsc3 = "";
         AV85Configuracion_chofereswwds_16_choplaca3 = "";
         AV86Configuracion_chofereswwds_17_cholicencia3 = "";
         AV89Configuracion_chofereswwds_20_tfchodsc = "";
         AV90Configuracion_chofereswwds_21_tfchodsc_sel = "";
         AV91Configuracion_chofereswwds_22_tfchodir = "";
         AV92Configuracion_chofereswwds_23_tfchodir_sel = "";
         AV93Configuracion_chofereswwds_24_tfchoruc = "";
         AV94Configuracion_chofereswwds_25_tfchoruc_sel = "";
         AV95Configuracion_chofereswwds_26_tfchoplaca = "";
         AV96Configuracion_chofereswwds_27_tfchoplaca_sel = "";
         AV97Configuracion_chofereswwds_28_tfcholicencia = "";
         AV98Configuracion_chofereswwds_29_tfcholicencia_sel = "";
         AV99Configuracion_chofereswwds_30_tfchosts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV72Configuracion_chofereswwds_3_chodsc1 = "";
         lV73Configuracion_chofereswwds_4_choplaca1 = "";
         lV74Configuracion_chofereswwds_5_cholicencia1 = "";
         lV78Configuracion_chofereswwds_9_chodsc2 = "";
         lV79Configuracion_chofereswwds_10_choplaca2 = "";
         lV80Configuracion_chofereswwds_11_cholicencia2 = "";
         lV84Configuracion_chofereswwds_15_chodsc3 = "";
         lV85Configuracion_chofereswwds_16_choplaca3 = "";
         lV86Configuracion_chofereswwds_17_cholicencia3 = "";
         lV89Configuracion_chofereswwds_20_tfchodsc = "";
         lV91Configuracion_chofereswwds_22_tfchodir = "";
         lV93Configuracion_chofereswwds_24_tfchoruc = "";
         lV95Configuracion_chofereswwds_26_tfchoplaca = "";
         lV97Configuracion_chofereswwds_28_tfcholicencia = "";
         A542ChoDsc = "";
         A543ChoPlaca = "";
         A546ChoLicencia = "";
         A545ChoDir = "";
         A548ChoRuc = "";
         P00322_A549ChoSts = new short[1] ;
         P00322_A548ChoRuc = new string[] {""} ;
         P00322_A545ChoDir = new string[] {""} ;
         P00322_A10ChoCod = new int[1] ;
         P00322_A546ChoLicencia = new string[] {""} ;
         P00322_A543ChoPlaca = new string[] {""} ;
         P00322_A542ChoDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV56TFChoSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.chofereswwexport__default(),
            new Object[][] {
                new Object[] {
               P00322_A549ChoSts, P00322_A548ChoRuc, P00322_A545ChoDir, P00322_A10ChoCod, P00322_A546ChoLicencia, P00322_A543ChoPlaca, P00322_A542ChoDsc
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
      private short AV58TFChoSts_Sel ;
      private short AV71Configuracion_chofereswwds_2_dynamicfiltersoperator1 ;
      private short AV77Configuracion_chofereswwds_8_dynamicfiltersoperator2 ;
      private short AV83Configuracion_chofereswwds_14_dynamicfiltersoperator3 ;
      private short A549ChoSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFChoCod ;
      private int AV35TFChoCod_To ;
      private int AV68GXV1 ;
      private int AV87Configuracion_chofereswwds_18_tfchocod ;
      private int AV88Configuracion_chofereswwds_19_tfchocod_to ;
      private int AV99Configuracion_chofereswwds_30_tfchosts_sels_Count ;
      private int A10ChoCod ;
      private int AV100GXV2 ;
      private long AV59i ;
      private string AV20ChoDsc1 ;
      private string AV60ChoPlaca1 ;
      private string AV61ChoLicencia1 ;
      private string AV24ChoDsc2 ;
      private string AV62ChoPlaca2 ;
      private string AV63ChoLicencia2 ;
      private string AV28ChoDsc3 ;
      private string AV64ChoPlaca3 ;
      private string AV65ChoLicencia3 ;
      private string AV37TFChoDsc_Sel ;
      private string AV36TFChoDsc ;
      private string AV39TFChoDir_Sel ;
      private string AV38TFChoDir ;
      private string AV43TFChoRuc_Sel ;
      private string AV42TFChoRuc ;
      private string AV47TFChoPlaca_Sel ;
      private string AV46TFChoPlaca ;
      private string AV49TFChoLicencia_Sel ;
      private string AV48TFChoLicencia ;
      private string AV72Configuracion_chofereswwds_3_chodsc1 ;
      private string AV73Configuracion_chofereswwds_4_choplaca1 ;
      private string AV74Configuracion_chofereswwds_5_cholicencia1 ;
      private string AV78Configuracion_chofereswwds_9_chodsc2 ;
      private string AV79Configuracion_chofereswwds_10_choplaca2 ;
      private string AV80Configuracion_chofereswwds_11_cholicencia2 ;
      private string AV84Configuracion_chofereswwds_15_chodsc3 ;
      private string AV85Configuracion_chofereswwds_16_choplaca3 ;
      private string AV86Configuracion_chofereswwds_17_cholicencia3 ;
      private string AV89Configuracion_chofereswwds_20_tfchodsc ;
      private string AV90Configuracion_chofereswwds_21_tfchodsc_sel ;
      private string AV91Configuracion_chofereswwds_22_tfchodir ;
      private string AV92Configuracion_chofereswwds_23_tfchodir_sel ;
      private string AV93Configuracion_chofereswwds_24_tfchoruc ;
      private string AV94Configuracion_chofereswwds_25_tfchoruc_sel ;
      private string AV95Configuracion_chofereswwds_26_tfchoplaca ;
      private string AV96Configuracion_chofereswwds_27_tfchoplaca_sel ;
      private string AV97Configuracion_chofereswwds_28_tfcholicencia ;
      private string AV98Configuracion_chofereswwds_29_tfcholicencia_sel ;
      private string scmdbuf ;
      private string lV72Configuracion_chofereswwds_3_chodsc1 ;
      private string lV73Configuracion_chofereswwds_4_choplaca1 ;
      private string lV74Configuracion_chofereswwds_5_cholicencia1 ;
      private string lV78Configuracion_chofereswwds_9_chodsc2 ;
      private string lV79Configuracion_chofereswwds_10_choplaca2 ;
      private string lV80Configuracion_chofereswwds_11_cholicencia2 ;
      private string lV84Configuracion_chofereswwds_15_chodsc3 ;
      private string lV85Configuracion_chofereswwds_16_choplaca3 ;
      private string lV86Configuracion_chofereswwds_17_cholicencia3 ;
      private string lV89Configuracion_chofereswwds_20_tfchodsc ;
      private string lV91Configuracion_chofereswwds_22_tfchodir ;
      private string lV93Configuracion_chofereswwds_24_tfchoruc ;
      private string lV95Configuracion_chofereswwds_26_tfchoplaca ;
      private string lV97Configuracion_chofereswwds_28_tfcholicencia ;
      private string A542ChoDsc ;
      private string A543ChoPlaca ;
      private string A546ChoLicencia ;
      private string A545ChoDir ;
      private string A548ChoRuc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV75Configuracion_chofereswwds_6_dynamicfiltersenabled2 ;
      private bool AV81Configuracion_chofereswwds_12_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV56TFChoSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV70Configuracion_chofereswwds_1_dynamicfiltersselector1 ;
      private string AV76Configuracion_chofereswwds_7_dynamicfiltersselector2 ;
      private string AV82Configuracion_chofereswwds_13_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV57TFChoSts_Sels ;
      private GxSimpleCollection<short> AV99Configuracion_chofereswwds_30_tfchosts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00322_A549ChoSts ;
      private string[] P00322_A548ChoRuc ;
      private string[] P00322_A545ChoDir ;
      private int[] P00322_A10ChoCod ;
      private string[] P00322_A546ChoLicencia ;
      private string[] P00322_A543ChoPlaca ;
      private string[] P00322_A542ChoDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class chofereswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00322( IGxContext context ,
                                             short A549ChoSts ,
                                             GxSimpleCollection<short> AV99Configuracion_chofereswwds_30_tfchosts_sels ,
                                             string AV70Configuracion_chofereswwds_1_dynamicfiltersselector1 ,
                                             short AV71Configuracion_chofereswwds_2_dynamicfiltersoperator1 ,
                                             string AV72Configuracion_chofereswwds_3_chodsc1 ,
                                             string AV73Configuracion_chofereswwds_4_choplaca1 ,
                                             string AV74Configuracion_chofereswwds_5_cholicencia1 ,
                                             bool AV75Configuracion_chofereswwds_6_dynamicfiltersenabled2 ,
                                             string AV76Configuracion_chofereswwds_7_dynamicfiltersselector2 ,
                                             short AV77Configuracion_chofereswwds_8_dynamicfiltersoperator2 ,
                                             string AV78Configuracion_chofereswwds_9_chodsc2 ,
                                             string AV79Configuracion_chofereswwds_10_choplaca2 ,
                                             string AV80Configuracion_chofereswwds_11_cholicencia2 ,
                                             bool AV81Configuracion_chofereswwds_12_dynamicfiltersenabled3 ,
                                             string AV82Configuracion_chofereswwds_13_dynamicfiltersselector3 ,
                                             short AV83Configuracion_chofereswwds_14_dynamicfiltersoperator3 ,
                                             string AV84Configuracion_chofereswwds_15_chodsc3 ,
                                             string AV85Configuracion_chofereswwds_16_choplaca3 ,
                                             string AV86Configuracion_chofereswwds_17_cholicencia3 ,
                                             int AV87Configuracion_chofereswwds_18_tfchocod ,
                                             int AV88Configuracion_chofereswwds_19_tfchocod_to ,
                                             string AV90Configuracion_chofereswwds_21_tfchodsc_sel ,
                                             string AV89Configuracion_chofereswwds_20_tfchodsc ,
                                             string AV92Configuracion_chofereswwds_23_tfchodir_sel ,
                                             string AV91Configuracion_chofereswwds_22_tfchodir ,
                                             string AV94Configuracion_chofereswwds_25_tfchoruc_sel ,
                                             string AV93Configuracion_chofereswwds_24_tfchoruc ,
                                             string AV96Configuracion_chofereswwds_27_tfchoplaca_sel ,
                                             string AV95Configuracion_chofereswwds_26_tfchoplaca ,
                                             string AV98Configuracion_chofereswwds_29_tfcholicencia_sel ,
                                             string AV97Configuracion_chofereswwds_28_tfcholicencia ,
                                             int AV99Configuracion_chofereswwds_30_tfchosts_sels_Count ,
                                             string A542ChoDsc ,
                                             string A543ChoPlaca ,
                                             string A546ChoLicencia ,
                                             int A10ChoCod ,
                                             string A545ChoDir ,
                                             string A548ChoRuc ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[30];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [ChoSts], [ChoRuc], [ChoDir], [ChoCod], [ChoLicencia], [ChoPlaca], [ChoDsc] FROM [CCHOFERES]";
         if ( ( StringUtil.StrCmp(AV70Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHODSC") == 0 ) && ( AV71Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_chofereswwds_3_chodsc1)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV72Configuracion_chofereswwds_3_chodsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHODSC") == 0 ) && ( AV71Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_chofereswwds_3_chodsc1)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV72Configuracion_chofereswwds_3_chodsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOPLACA") == 0 ) && ( AV71Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_chofereswwds_4_choplaca1)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV73Configuracion_chofereswwds_4_choplaca1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOPLACA") == 0 ) && ( AV71Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_chofereswwds_4_choplaca1)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV73Configuracion_chofereswwds_4_choplaca1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOLICENCIA") == 0 ) && ( AV71Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_chofereswwds_5_cholicencia1)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV74Configuracion_chofereswwds_5_cholicencia1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOLICENCIA") == 0 ) && ( AV71Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_chofereswwds_5_cholicencia1)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV74Configuracion_chofereswwds_5_cholicencia1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV75Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHODSC") == 0 ) && ( AV77Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_chofereswwds_9_chodsc2)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV78Configuracion_chofereswwds_9_chodsc2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV75Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHODSC") == 0 ) && ( AV77Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_chofereswwds_9_chodsc2)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV78Configuracion_chofereswwds_9_chodsc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV75Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOPLACA") == 0 ) && ( AV77Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_chofereswwds_10_choplaca2)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV79Configuracion_chofereswwds_10_choplaca2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV75Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOPLACA") == 0 ) && ( AV77Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_chofereswwds_10_choplaca2)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV79Configuracion_chofereswwds_10_choplaca2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV75Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOLICENCIA") == 0 ) && ( AV77Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_chofereswwds_11_cholicencia2)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV80Configuracion_chofereswwds_11_cholicencia2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV75Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOLICENCIA") == 0 ) && ( AV77Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_chofereswwds_11_cholicencia2)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV80Configuracion_chofereswwds_11_cholicencia2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV81Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHODSC") == 0 ) && ( AV83Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_chofereswwds_15_chodsc3)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV84Configuracion_chofereswwds_15_chodsc3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV81Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHODSC") == 0 ) && ( AV83Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_chofereswwds_15_chodsc3)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV84Configuracion_chofereswwds_15_chodsc3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV81Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOPLACA") == 0 ) && ( AV83Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_chofereswwds_16_choplaca3)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV85Configuracion_chofereswwds_16_choplaca3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV81Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOPLACA") == 0 ) && ( AV83Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_chofereswwds_16_choplaca3)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV85Configuracion_chofereswwds_16_choplaca3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV81Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOLICENCIA") == 0 ) && ( AV83Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_chofereswwds_17_cholicencia3)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV86Configuracion_chofereswwds_17_cholicencia3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV81Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOLICENCIA") == 0 ) && ( AV83Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_chofereswwds_17_cholicencia3)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV86Configuracion_chofereswwds_17_cholicencia3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (0==AV87Configuracion_chofereswwds_18_tfchocod) )
         {
            AddWhere(sWhereString, "([ChoCod] >= @AV87Configuracion_chofereswwds_18_tfchocod)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! (0==AV88Configuracion_chofereswwds_19_tfchocod_to) )
         {
            AddWhere(sWhereString, "([ChoCod] <= @AV88Configuracion_chofereswwds_19_tfchocod_to)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Configuracion_chofereswwds_21_tfchodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_chofereswwds_20_tfchodsc)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV89Configuracion_chofereswwds_20_tfchodsc)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Configuracion_chofereswwds_21_tfchodsc_sel)) )
         {
            AddWhere(sWhereString, "([ChoDsc] = @AV90Configuracion_chofereswwds_21_tfchodsc_sel)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_chofereswwds_23_tfchodir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Configuracion_chofereswwds_22_tfchodir)) ) )
         {
            AddWhere(sWhereString, "([ChoDir] like @lV91Configuracion_chofereswwds_22_tfchodir)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_chofereswwds_23_tfchodir_sel)) )
         {
            AddWhere(sWhereString, "([ChoDir] = @AV92Configuracion_chofereswwds_23_tfchodir_sel)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Configuracion_chofereswwds_25_tfchoruc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_chofereswwds_24_tfchoruc)) ) )
         {
            AddWhere(sWhereString, "([ChoRuc] like @lV93Configuracion_chofereswwds_24_tfchoruc)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Configuracion_chofereswwds_25_tfchoruc_sel)) )
         {
            AddWhere(sWhereString, "([ChoRuc] = @AV94Configuracion_chofereswwds_25_tfchoruc_sel)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Configuracion_chofereswwds_27_tfchoplaca_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_chofereswwds_26_tfchoplaca)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV95Configuracion_chofereswwds_26_tfchoplaca)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Configuracion_chofereswwds_27_tfchoplaca_sel)) )
         {
            AddWhere(sWhereString, "([ChoPlaca] = @AV96Configuracion_chofereswwds_27_tfchoplaca_sel)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_chofereswwds_29_tfcholicencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_chofereswwds_28_tfcholicencia)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV97Configuracion_chofereswwds_28_tfcholicencia)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_chofereswwds_29_tfcholicencia_sel)) )
         {
            AddWhere(sWhereString, "([ChoLicencia] = @AV98Configuracion_chofereswwds_29_tfcholicencia_sel)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( AV99Configuracion_chofereswwds_30_tfchosts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV99Configuracion_chofereswwds_30_tfchosts_sels, "[ChoSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ChoCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ChoCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ChoDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ChoDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ChoDir]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ChoDir] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ChoRuc]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ChoRuc] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ChoPlaca]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ChoPlaca] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ChoLicencia]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ChoLicencia] DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [ChoSts]";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ChoSts] DESC";
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
                     return conditional_P00322(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (int)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] );
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
          Object[] prmP00322;
          prmP00322 = new Object[] {
          new ParDef("@lV72Configuracion_chofereswwds_3_chodsc1",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_chofereswwds_3_chodsc1",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_chofereswwds_4_choplaca1",GXType.NChar,20,0) ,
          new ParDef("@lV73Configuracion_chofereswwds_4_choplaca1",GXType.NChar,20,0) ,
          new ParDef("@lV74Configuracion_chofereswwds_5_cholicencia1",GXType.NChar,20,0) ,
          new ParDef("@lV74Configuracion_chofereswwds_5_cholicencia1",GXType.NChar,20,0) ,
          new ParDef("@lV78Configuracion_chofereswwds_9_chodsc2",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_chofereswwds_9_chodsc2",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_chofereswwds_10_choplaca2",GXType.NChar,20,0) ,
          new ParDef("@lV79Configuracion_chofereswwds_10_choplaca2",GXType.NChar,20,0) ,
          new ParDef("@lV80Configuracion_chofereswwds_11_cholicencia2",GXType.NChar,20,0) ,
          new ParDef("@lV80Configuracion_chofereswwds_11_cholicencia2",GXType.NChar,20,0) ,
          new ParDef("@lV84Configuracion_chofereswwds_15_chodsc3",GXType.NChar,100,0) ,
          new ParDef("@lV84Configuracion_chofereswwds_15_chodsc3",GXType.NChar,100,0) ,
          new ParDef("@lV85Configuracion_chofereswwds_16_choplaca3",GXType.NChar,20,0) ,
          new ParDef("@lV85Configuracion_chofereswwds_16_choplaca3",GXType.NChar,20,0) ,
          new ParDef("@lV86Configuracion_chofereswwds_17_cholicencia3",GXType.NChar,20,0) ,
          new ParDef("@lV86Configuracion_chofereswwds_17_cholicencia3",GXType.NChar,20,0) ,
          new ParDef("@AV87Configuracion_chofereswwds_18_tfchocod",GXType.Int32,6,0) ,
          new ParDef("@AV88Configuracion_chofereswwds_19_tfchocod_to",GXType.Int32,6,0) ,
          new ParDef("@lV89Configuracion_chofereswwds_20_tfchodsc",GXType.NChar,100,0) ,
          new ParDef("@AV90Configuracion_chofereswwds_21_tfchodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV91Configuracion_chofereswwds_22_tfchodir",GXType.NChar,100,0) ,
          new ParDef("@AV92Configuracion_chofereswwds_23_tfchodir_sel",GXType.NChar,100,0) ,
          new ParDef("@lV93Configuracion_chofereswwds_24_tfchoruc",GXType.NChar,20,0) ,
          new ParDef("@AV94Configuracion_chofereswwds_25_tfchoruc_sel",GXType.NChar,20,0) ,
          new ParDef("@lV95Configuracion_chofereswwds_26_tfchoplaca",GXType.NChar,20,0) ,
          new ParDef("@AV96Configuracion_chofereswwds_27_tfchoplaca_sel",GXType.NChar,20,0) ,
          new ParDef("@lV97Configuracion_chofereswwds_28_tfcholicencia",GXType.NChar,20,0) ,
          new ParDef("@AV98Configuracion_chofereswwds_29_tfcholicencia_sel",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00322", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00322,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                return;
       }
    }

 }

}
