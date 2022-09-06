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
namespace GeneXus.Programs.ventas {
   public class clienteswwexport : GXProcedure
   {
      public clienteswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clienteswwexport( IGxContext context )
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
         clienteswwexport objclienteswwexport;
         objclienteswwexport = new clienteswwexport();
         objclienteswwexport.AV11Filename = "" ;
         objclienteswwexport.AV12ErrorMessage = "" ;
         objclienteswwexport.context.SetSubmitInitialConfig(context);
         objclienteswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objclienteswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clienteswwexport)stateInfo).executePrivate();
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
         AV11Filename = "ClientesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV20CliDsc1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20CliDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Razon Social", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Razon Social", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20CliDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CLIVENDDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV21CliVendDsc1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21CliVendDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21CliVendDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIDSC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25CliDsc2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25CliDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Razon Social", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Razon Social", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25CliDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CLIVENDDSC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV26CliVendDsc2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26CliVendDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26CliVendDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CLIDSC") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30CliDsc3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30CliDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Razon Social", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Razon Social", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30CliDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CLIVENDDSC") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31CliVendDsc3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31CliVendDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV31CliVendDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCliCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Cliente") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFCliCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCliCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Cliente") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFCliCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCliDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Razon Social") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFCliDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCliDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Razon Social") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFCliDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFCliDir_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Dirección") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFCliDir_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFCliDir)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Dirección") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFCliDir, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFEstCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFEstCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFEstCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFEstCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFPaiCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Pais") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TFPaiCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFPaiCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Pais") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45TFPaiCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCliTel1_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Telefono 1") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48TFCliTel1_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCliTel1)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Telefono 1") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFCliTel1, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFCliTel2_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Telefono 2") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV50TFCliTel2_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFCliTel2)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Telefono 2") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFCliTel2, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFCliFax_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Fax") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFCliFax_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCliFax)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Fax") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFCliFax, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFCliCel_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Celular") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54TFCliCel_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFCliCel)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Celular") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53TFCliCel, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFCliEma_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "E-Mail") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFCliEma_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFCliEma)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "E-Mail") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55TFCliEma, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFCliWeb_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Pagina Web") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV58TFCliWeb_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFCliWeb)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Pagina Web") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFCliWeb, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV59TFTipCCod) && (0==AV60TFTipCCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo T. Cliente") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV59TFTipCCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV60TFTipCCod_To;
         }
         if ( ! ( (0==AV61TFCliSts) && (0==AV62TFCliSts_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Situación") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV61TFCliSts;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV62TFCliSts_To;
         }
         if ( ! ( (0==AV63TFConpcod) && (0==AV64TFConpcod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo condicion pago") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV63TFConpcod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV64TFConpcod_To;
         }
         if ( ! ( (Convert.ToDecimal(0)==AV65TFCliLim) && (Convert.ToDecimal(0)==AV66TFCliLim_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Limite Credito") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV65TFCliLim);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV66TFCliLim_To);
         }
         if ( ! ( (0==AV67TFCliVend) && (0==AV68TFCliVend_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vendedor") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV67TFCliVend;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV68TFCliVend_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV70TFCliVendDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vendedor") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV70TFCliVendDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV69TFCliVendDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vendedor") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV69TFCliVendDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV72TFCliRef1_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 1") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV72TFCliRef1_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV71TFCliRef1)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 1") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV71TFCliRef1, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV74TFCliRef2_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 2") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV74TFCliRef2_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV73TFCliRef2)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 2") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV73TFCliRef2, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV76TFCliRef3_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 3") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV76TFCliRef3_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV75TFCliRef3)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 3") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV75TFCliRef3, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV78TFCliRef4_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 4") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV78TFCliRef4_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV77TFCliRef4)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 4") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV77TFCliRef4, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV80TFCliRef5_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 5") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV80TFCliRef5_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV79TFCliRef5)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 5") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV79TFCliRef5, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV82TFCliRef6_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 6") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV82TFCliRef6_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV81TFCliRef6)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 6") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV81TFCliRef6, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV84TFCliRef7_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 7") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV84TFCliRef7_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV83TFCliRef7)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 7") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV83TFCliRef7, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Codigo Cliente";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Razon Social";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Dirección";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Estado";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Pais";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Telefono 1";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Telefono 2";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Fax";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "Celular";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Text = "E-Mail";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Text = "Pagina Web";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+11, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+11, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+11, 1, 1).Text = "Codigo T. Cliente";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+12, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+12, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+12, 1, 1).Text = "Foto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+13, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+13, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+13, 1, 1).Text = "Situación";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+14, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+14, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+14, 1, 1).Text = "Codigo condicion pago";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+15, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+15, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+15, 1, 1).Text = "Limite Credito";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+16, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+16, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+16, 1, 1).Text = "Vendedor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+17, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+17, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+17, 1, 1).Text = "Vendedor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+18, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+18, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+18, 1, 1).Text = "Referencia 1";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+19, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+19, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+19, 1, 1).Text = "Referencia 2";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+20, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+20, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+20, 1, 1).Text = "Referencia 3";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+21, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+21, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+21, 1, 1).Text = "Referencia 4";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+22, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+22, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+22, 1, 1).Text = "Referencia 5";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+23, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+23, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+23, 1, 1).Text = "Referencia 6";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+24, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+24, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+24, 1, 1).Text = "Referencia 7";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV88Ventas_clienteswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV89Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV90Ventas_clienteswwds_3_clidsc1 = AV20CliDsc1;
         AV91Ventas_clienteswwds_4_clivenddsc1 = AV21CliVendDsc1;
         AV92Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV93Ventas_clienteswwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV94Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV95Ventas_clienteswwds_8_clidsc2 = AV25CliDsc2;
         AV96Ventas_clienteswwds_9_clivenddsc2 = AV26CliVendDsc2;
         AV97Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV98Ventas_clienteswwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV99Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV100Ventas_clienteswwds_13_clidsc3 = AV30CliDsc3;
         AV101Ventas_clienteswwds_14_clivenddsc3 = AV31CliVendDsc3;
         AV102Ventas_clienteswwds_15_tfclicod = AV37TFCliCod;
         AV103Ventas_clienteswwds_16_tfclicod_sel = AV38TFCliCod_Sel;
         AV104Ventas_clienteswwds_17_tfclidsc = AV39TFCliDsc;
         AV105Ventas_clienteswwds_18_tfclidsc_sel = AV40TFCliDsc_Sel;
         AV106Ventas_clienteswwds_19_tfclidir = AV41TFCliDir;
         AV107Ventas_clienteswwds_20_tfclidir_sel = AV42TFCliDir_Sel;
         AV108Ventas_clienteswwds_21_tfestcod = AV43TFEstCod;
         AV109Ventas_clienteswwds_22_tfestcod_sel = AV44TFEstCod_Sel;
         AV110Ventas_clienteswwds_23_tfpaicod = AV45TFPaiCod;
         AV111Ventas_clienteswwds_24_tfpaicod_sel = AV46TFPaiCod_Sel;
         AV112Ventas_clienteswwds_25_tfclitel1 = AV47TFCliTel1;
         AV113Ventas_clienteswwds_26_tfclitel1_sel = AV48TFCliTel1_Sel;
         AV114Ventas_clienteswwds_27_tfclitel2 = AV49TFCliTel2;
         AV115Ventas_clienteswwds_28_tfclitel2_sel = AV50TFCliTel2_Sel;
         AV116Ventas_clienteswwds_29_tfclifax = AV51TFCliFax;
         AV117Ventas_clienteswwds_30_tfclifax_sel = AV52TFCliFax_Sel;
         AV118Ventas_clienteswwds_31_tfclicel = AV53TFCliCel;
         AV119Ventas_clienteswwds_32_tfclicel_sel = AV54TFCliCel_Sel;
         AV120Ventas_clienteswwds_33_tfcliema = AV55TFCliEma;
         AV121Ventas_clienteswwds_34_tfcliema_sel = AV56TFCliEma_Sel;
         AV122Ventas_clienteswwds_35_tfcliweb = AV57TFCliWeb;
         AV123Ventas_clienteswwds_36_tfcliweb_sel = AV58TFCliWeb_Sel;
         AV124Ventas_clienteswwds_37_tftipccod = AV59TFTipCCod;
         AV125Ventas_clienteswwds_38_tftipccod_to = AV60TFTipCCod_To;
         AV126Ventas_clienteswwds_39_tfclists = AV61TFCliSts;
         AV127Ventas_clienteswwds_40_tfclists_to = AV62TFCliSts_To;
         AV128Ventas_clienteswwds_41_tfconpcod = AV63TFConpcod;
         AV129Ventas_clienteswwds_42_tfconpcod_to = AV64TFConpcod_To;
         AV130Ventas_clienteswwds_43_tfclilim = AV65TFCliLim;
         AV131Ventas_clienteswwds_44_tfclilim_to = AV66TFCliLim_To;
         AV132Ventas_clienteswwds_45_tfclivend = AV67TFCliVend;
         AV133Ventas_clienteswwds_46_tfclivend_to = AV68TFCliVend_To;
         AV134Ventas_clienteswwds_47_tfclivenddsc = AV69TFCliVendDsc;
         AV135Ventas_clienteswwds_48_tfclivenddsc_sel = AV70TFCliVendDsc_Sel;
         AV136Ventas_clienteswwds_49_tfcliref1 = AV71TFCliRef1;
         AV137Ventas_clienteswwds_50_tfcliref1_sel = AV72TFCliRef1_Sel;
         AV138Ventas_clienteswwds_51_tfcliref2 = AV73TFCliRef2;
         AV139Ventas_clienteswwds_52_tfcliref2_sel = AV74TFCliRef2_Sel;
         AV140Ventas_clienteswwds_53_tfcliref3 = AV75TFCliRef3;
         AV141Ventas_clienteswwds_54_tfcliref3_sel = AV76TFCliRef3_Sel;
         AV142Ventas_clienteswwds_55_tfcliref4 = AV77TFCliRef4;
         AV143Ventas_clienteswwds_56_tfcliref4_sel = AV78TFCliRef4_Sel;
         AV144Ventas_clienteswwds_57_tfcliref5 = AV79TFCliRef5;
         AV145Ventas_clienteswwds_58_tfcliref5_sel = AV80TFCliRef5_Sel;
         AV146Ventas_clienteswwds_59_tfcliref6 = AV81TFCliRef6;
         AV147Ventas_clienteswwds_60_tfcliref6_sel = AV82TFCliRef6_Sel;
         AV148Ventas_clienteswwds_61_tfcliref7 = AV83TFCliRef7;
         AV149Ventas_clienteswwds_62_tfcliref7_sel = AV84TFCliRef7_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV88Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV89Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV90Ventas_clienteswwds_3_clidsc1 ,
                                              AV91Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV92Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV93Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV94Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV95Ventas_clienteswwds_8_clidsc2 ,
                                              AV96Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV97Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV98Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV99Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV100Ventas_clienteswwds_13_clidsc3 ,
                                              AV101Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV103Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV102Ventas_clienteswwds_15_tfclicod ,
                                              AV105Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV104Ventas_clienteswwds_17_tfclidsc ,
                                              AV107Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV106Ventas_clienteswwds_19_tfclidir ,
                                              AV109Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV108Ventas_clienteswwds_21_tfestcod ,
                                              AV111Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV110Ventas_clienteswwds_23_tfpaicod ,
                                              AV113Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV112Ventas_clienteswwds_25_tfclitel1 ,
                                              AV115Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV114Ventas_clienteswwds_27_tfclitel2 ,
                                              AV117Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV116Ventas_clienteswwds_29_tfclifax ,
                                              AV119Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV118Ventas_clienteswwds_31_tfclicel ,
                                              AV121Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV120Ventas_clienteswwds_33_tfcliema ,
                                              AV123Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV122Ventas_clienteswwds_35_tfcliweb ,
                                              AV124Ventas_clienteswwds_37_tftipccod ,
                                              AV125Ventas_clienteswwds_38_tftipccod_to ,
                                              AV126Ventas_clienteswwds_39_tfclists ,
                                              AV127Ventas_clienteswwds_40_tfclists_to ,
                                              AV128Ventas_clienteswwds_41_tfconpcod ,
                                              AV129Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV130Ventas_clienteswwds_43_tfclilim ,
                                              AV131Ventas_clienteswwds_44_tfclilim_to ,
                                              AV132Ventas_clienteswwds_45_tfclivend ,
                                              AV133Ventas_clienteswwds_46_tfclivend_to ,
                                              AV135Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV134Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV137Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV136Ventas_clienteswwds_49_tfcliref1 ,
                                              AV139Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV138Ventas_clienteswwds_51_tfcliref2 ,
                                              AV141Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV140Ventas_clienteswwds_53_tfcliref3 ,
                                              AV143Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV142Ventas_clienteswwds_55_tfcliref4 ,
                                              AV145Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV144Ventas_clienteswwds_57_tfcliref5 ,
                                              AV147Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV146Ventas_clienteswwds_59_tfcliref6 ,
                                              AV149Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV148Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV90Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV90Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV90Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV90Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV91Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV91Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV91Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV91Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV95Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV95Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV95Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV95Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV96Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV96Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV100Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV100Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV100Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV100Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV101Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV101Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV102Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV104Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV104Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV106Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV108Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV110Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV112Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV114Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV116Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV118Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV120Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV120Ventas_clienteswwds_33_tfcliema), "%", "");
         lV122Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV134Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV134Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV136Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV136Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV138Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV138Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV140Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV142Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV144Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV146Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV148Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GB2 */
         pr_default.execute(0, new Object[] {lV90Ventas_clienteswwds_3_clidsc1, lV90Ventas_clienteswwds_3_clidsc1, lV91Ventas_clienteswwds_4_clivenddsc1, lV91Ventas_clienteswwds_4_clivenddsc1, lV95Ventas_clienteswwds_8_clidsc2, lV95Ventas_clienteswwds_8_clidsc2, lV96Ventas_clienteswwds_9_clivenddsc2, lV96Ventas_clienteswwds_9_clivenddsc2, lV100Ventas_clienteswwds_13_clidsc3, lV100Ventas_clienteswwds_13_clidsc3, lV101Ventas_clienteswwds_14_clivenddsc3, lV101Ventas_clienteswwds_14_clivenddsc3, lV102Ventas_clienteswwds_15_tfclicod, AV103Ventas_clienteswwds_16_tfclicod_sel, lV104Ventas_clienteswwds_17_tfclidsc, AV105Ventas_clienteswwds_18_tfclidsc_sel, lV106Ventas_clienteswwds_19_tfclidir, AV107Ventas_clienteswwds_20_tfclidir_sel, lV108Ventas_clienteswwds_21_tfestcod, AV109Ventas_clienteswwds_22_tfestcod_sel, lV110Ventas_clienteswwds_23_tfpaicod, AV111Ventas_clienteswwds_24_tfpaicod_sel, lV112Ventas_clienteswwds_25_tfclitel1, AV113Ventas_clienteswwds_26_tfclitel1_sel, lV114Ventas_clienteswwds_27_tfclitel2, AV115Ventas_clienteswwds_28_tfclitel2_sel, lV116Ventas_clienteswwds_29_tfclifax, AV117Ventas_clienteswwds_30_tfclifax_sel, lV118Ventas_clienteswwds_31_tfclicel, AV119Ventas_clienteswwds_32_tfclicel_sel, lV120Ventas_clienteswwds_33_tfcliema, AV121Ventas_clienteswwds_34_tfcliema_sel, lV122Ventas_clienteswwds_35_tfcliweb, AV123Ventas_clienteswwds_36_tfcliweb_sel, AV124Ventas_clienteswwds_37_tftipccod, AV125Ventas_clienteswwds_38_tftipccod_to, AV126Ventas_clienteswwds_39_tfclists, AV127Ventas_clienteswwds_40_tfclists_to, AV128Ventas_clienteswwds_41_tfconpcod, AV129Ventas_clienteswwds_42_tfconpcod_to, AV130Ventas_clienteswwds_43_tfclilim, AV131Ventas_clienteswwds_44_tfclilim_to, AV132Ventas_clienteswwds_45_tfclivend, AV133Ventas_clienteswwds_46_tfclivend_to, lV134Ventas_clienteswwds_47_tfclivenddsc, AV135Ventas_clienteswwds_48_tfclivenddsc_sel, lV136Ventas_clienteswwds_49_tfcliref1, AV137Ventas_clienteswwds_50_tfcliref1_sel, lV138Ventas_clienteswwds_51_tfcliref2, AV139Ventas_clienteswwds_52_tfcliref2_sel, lV140Ventas_clienteswwds_53_tfcliref3, AV141Ventas_clienteswwds_54_tfcliref3_sel, lV142Ventas_clienteswwds_55_tfcliref4, AV143Ventas_clienteswwds_56_tfcliref4_sel, lV144Ventas_clienteswwds_57_tfcliref5, AV145Ventas_clienteswwds_58_tfcliref5_sel, lV146Ventas_clienteswwds_59_tfcliref6, AV147Ventas_clienteswwds_60_tfcliref6_sel, lV148Ventas_clienteswwds_61_tfcliref7, AV149Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A624CliRef7 = P00GB2_A624CliRef7[0];
            A623CliRef6 = P00GB2_A623CliRef6[0];
            A622CliRef5 = P00GB2_A622CliRef5[0];
            A621CliRef4 = P00GB2_A621CliRef4[0];
            A620CliRef3 = P00GB2_A620CliRef3[0];
            A619CliRef2 = P00GB2_A619CliRef2[0];
            A618CliRef1 = P00GB2_A618CliRef1[0];
            A160CliVend = P00GB2_A160CliVend[0];
            A613CliLim = P00GB2_A613CliLim[0];
            A137Conpcod = P00GB2_A137Conpcod[0];
            A627CliSts = P00GB2_A627CliSts[0];
            A159TipCCod = P00GB2_A159TipCCod[0];
            A637CliWeb = P00GB2_A637CliWeb[0];
            A609CliEma = P00GB2_A609CliEma[0];
            A575CliCel = P00GB2_A575CliCel[0];
            A611CliFax = P00GB2_A611CliFax[0];
            A630CliTel2 = P00GB2_A630CliTel2[0];
            A629CliTel1 = P00GB2_A629CliTel1[0];
            A139PaiCod = P00GB2_A139PaiCod[0];
            A140EstCod = P00GB2_A140EstCod[0];
            A596CliDir = P00GB2_A596CliDir[0];
            A45CliCod = P00GB2_A45CliCod[0];
            A635CliVendDsc = P00GB2_A635CliVendDsc[0];
            A161CliDsc = P00GB2_A161CliDsc[0];
            A635CliVendDsc = P00GB2_A635CliVendDsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A45CliCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A161CliDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A596CliDir, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A140EstCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A139PaiCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A629CliTel1, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A630CliTel2, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A611CliFax, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A575CliCel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A609CliEma, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A637CliWeb, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+11, 1, 1).Number = A159TipCCod;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+12, 1, 1).Text = "";
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+13, 1, 1).Number = A627CliSts;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+14, 1, 1).Number = A137Conpcod;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+15, 1, 1).Number = (double)(A613CliLim);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+16, 1, 1).Number = A160CliVend;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A635CliVendDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+17, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A618CliRef1, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+18, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A619CliRef2, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+19, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A620CliRef3, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+20, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A621CliRef4, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+21, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A622CliRef5, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+22, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A623CliRef6, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+23, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A624CliRef7, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+24, 1, 1).Text = GXt_char1;
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
         if ( StringUtil.StrCmp(AV33Session.Get("Ventas.ClientesWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Ventas.ClientesWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Ventas.ClientesWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV150GXV1 = 1;
         while ( AV150GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV150GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLICOD") == 0 )
            {
               AV37TFCliCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLICOD_SEL") == 0 )
            {
               AV38TFCliCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIDSC") == 0 )
            {
               AV39TFCliDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIDSC_SEL") == 0 )
            {
               AV40TFCliDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIDIR") == 0 )
            {
               AV41TFCliDir = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIDIR_SEL") == 0 )
            {
               AV42TFCliDir_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFESTCOD") == 0 )
            {
               AV43TFEstCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFESTCOD_SEL") == 0 )
            {
               AV44TFEstCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPAICOD") == 0 )
            {
               AV45TFPaiCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPAICOD_SEL") == 0 )
            {
               AV46TFPaiCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLITEL1") == 0 )
            {
               AV47TFCliTel1 = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLITEL1_SEL") == 0 )
            {
               AV48TFCliTel1_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLITEL2") == 0 )
            {
               AV49TFCliTel2 = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLITEL2_SEL") == 0 )
            {
               AV50TFCliTel2_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIFAX") == 0 )
            {
               AV51TFCliFax = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIFAX_SEL") == 0 )
            {
               AV52TFCliFax_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLICEL") == 0 )
            {
               AV53TFCliCel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLICEL_SEL") == 0 )
            {
               AV54TFCliCel_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIEMA") == 0 )
            {
               AV55TFCliEma = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIEMA_SEL") == 0 )
            {
               AV56TFCliEma_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIWEB") == 0 )
            {
               AV57TFCliWeb = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIWEB_SEL") == 0 )
            {
               AV58TFCliWeb_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPCCOD") == 0 )
            {
               AV59TFTipCCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV60TFTipCCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLISTS") == 0 )
            {
               AV61TFCliSts = (short)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV62TFCliSts_To = (short)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONPCOD") == 0 )
            {
               AV63TFConpcod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV64TFConpcod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLILIM") == 0 )
            {
               AV65TFCliLim = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV66TFCliLim_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIVEND") == 0 )
            {
               AV67TFCliVend = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV68TFCliVend_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIVENDDSC") == 0 )
            {
               AV69TFCliVendDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIVENDDSC_SEL") == 0 )
            {
               AV70TFCliVendDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIREF1") == 0 )
            {
               AV71TFCliRef1 = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIREF1_SEL") == 0 )
            {
               AV72TFCliRef1_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIREF2") == 0 )
            {
               AV73TFCliRef2 = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIREF2_SEL") == 0 )
            {
               AV74TFCliRef2_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIREF3") == 0 )
            {
               AV75TFCliRef3 = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIREF3_SEL") == 0 )
            {
               AV76TFCliRef3_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIREF4") == 0 )
            {
               AV77TFCliRef4 = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIREF4_SEL") == 0 )
            {
               AV78TFCliRef4_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIREF5") == 0 )
            {
               AV79TFCliRef5 = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIREF5_SEL") == 0 )
            {
               AV80TFCliRef5_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIREF6") == 0 )
            {
               AV81TFCliRef6 = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIREF6_SEL") == 0 )
            {
               AV82TFCliRef6_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIREF7") == 0 )
            {
               AV83TFCliRef7 = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIREF7_SEL") == 0 )
            {
               AV84TFCliRef7_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            AV150GXV1 = (int)(AV150GXV1+1);
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
         AV20CliDsc1 = "";
         AV21CliVendDsc1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25CliDsc2 = "";
         AV26CliVendDsc2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30CliDsc3 = "";
         AV31CliVendDsc3 = "";
         AV38TFCliCod_Sel = "";
         AV37TFCliCod = "";
         AV40TFCliDsc_Sel = "";
         AV39TFCliDsc = "";
         AV42TFCliDir_Sel = "";
         AV41TFCliDir = "";
         AV44TFEstCod_Sel = "";
         AV43TFEstCod = "";
         AV46TFPaiCod_Sel = "";
         AV45TFPaiCod = "";
         AV48TFCliTel1_Sel = "";
         AV47TFCliTel1 = "";
         AV50TFCliTel2_Sel = "";
         AV49TFCliTel2 = "";
         AV52TFCliFax_Sel = "";
         AV51TFCliFax = "";
         AV54TFCliCel_Sel = "";
         AV53TFCliCel = "";
         AV56TFCliEma_Sel = "";
         AV55TFCliEma = "";
         AV58TFCliWeb_Sel = "";
         AV57TFCliWeb = "";
         AV70TFCliVendDsc_Sel = "";
         AV69TFCliVendDsc = "";
         AV72TFCliRef1_Sel = "";
         AV71TFCliRef1 = "";
         AV74TFCliRef2_Sel = "";
         AV73TFCliRef2 = "";
         AV76TFCliRef3_Sel = "";
         AV75TFCliRef3 = "";
         AV78TFCliRef4_Sel = "";
         AV77TFCliRef4 = "";
         AV80TFCliRef5_Sel = "";
         AV79TFCliRef5 = "";
         AV82TFCliRef6_Sel = "";
         AV81TFCliRef6 = "";
         AV84TFCliRef7_Sel = "";
         AV83TFCliRef7 = "";
         AV88Ventas_clienteswwds_1_dynamicfiltersselector1 = "";
         AV90Ventas_clienteswwds_3_clidsc1 = "";
         AV91Ventas_clienteswwds_4_clivenddsc1 = "";
         AV93Ventas_clienteswwds_6_dynamicfiltersselector2 = "";
         AV95Ventas_clienteswwds_8_clidsc2 = "";
         AV96Ventas_clienteswwds_9_clivenddsc2 = "";
         AV98Ventas_clienteswwds_11_dynamicfiltersselector3 = "";
         AV100Ventas_clienteswwds_13_clidsc3 = "";
         AV101Ventas_clienteswwds_14_clivenddsc3 = "";
         AV102Ventas_clienteswwds_15_tfclicod = "";
         AV103Ventas_clienteswwds_16_tfclicod_sel = "";
         AV104Ventas_clienteswwds_17_tfclidsc = "";
         AV105Ventas_clienteswwds_18_tfclidsc_sel = "";
         AV106Ventas_clienteswwds_19_tfclidir = "";
         AV107Ventas_clienteswwds_20_tfclidir_sel = "";
         AV108Ventas_clienteswwds_21_tfestcod = "";
         AV109Ventas_clienteswwds_22_tfestcod_sel = "";
         AV110Ventas_clienteswwds_23_tfpaicod = "";
         AV111Ventas_clienteswwds_24_tfpaicod_sel = "";
         AV112Ventas_clienteswwds_25_tfclitel1 = "";
         AV113Ventas_clienteswwds_26_tfclitel1_sel = "";
         AV114Ventas_clienteswwds_27_tfclitel2 = "";
         AV115Ventas_clienteswwds_28_tfclitel2_sel = "";
         AV116Ventas_clienteswwds_29_tfclifax = "";
         AV117Ventas_clienteswwds_30_tfclifax_sel = "";
         AV118Ventas_clienteswwds_31_tfclicel = "";
         AV119Ventas_clienteswwds_32_tfclicel_sel = "";
         AV120Ventas_clienteswwds_33_tfcliema = "";
         AV121Ventas_clienteswwds_34_tfcliema_sel = "";
         AV122Ventas_clienteswwds_35_tfcliweb = "";
         AV123Ventas_clienteswwds_36_tfcliweb_sel = "";
         AV134Ventas_clienteswwds_47_tfclivenddsc = "";
         AV135Ventas_clienteswwds_48_tfclivenddsc_sel = "";
         AV136Ventas_clienteswwds_49_tfcliref1 = "";
         AV137Ventas_clienteswwds_50_tfcliref1_sel = "";
         AV138Ventas_clienteswwds_51_tfcliref2 = "";
         AV139Ventas_clienteswwds_52_tfcliref2_sel = "";
         AV140Ventas_clienteswwds_53_tfcliref3 = "";
         AV141Ventas_clienteswwds_54_tfcliref3_sel = "";
         AV142Ventas_clienteswwds_55_tfcliref4 = "";
         AV143Ventas_clienteswwds_56_tfcliref4_sel = "";
         AV144Ventas_clienteswwds_57_tfcliref5 = "";
         AV145Ventas_clienteswwds_58_tfcliref5_sel = "";
         AV146Ventas_clienteswwds_59_tfcliref6 = "";
         AV147Ventas_clienteswwds_60_tfcliref6_sel = "";
         AV148Ventas_clienteswwds_61_tfcliref7 = "";
         AV149Ventas_clienteswwds_62_tfcliref7_sel = "";
         scmdbuf = "";
         lV90Ventas_clienteswwds_3_clidsc1 = "";
         lV91Ventas_clienteswwds_4_clivenddsc1 = "";
         lV95Ventas_clienteswwds_8_clidsc2 = "";
         lV96Ventas_clienteswwds_9_clivenddsc2 = "";
         lV100Ventas_clienteswwds_13_clidsc3 = "";
         lV101Ventas_clienteswwds_14_clivenddsc3 = "";
         lV102Ventas_clienteswwds_15_tfclicod = "";
         lV104Ventas_clienteswwds_17_tfclidsc = "";
         lV106Ventas_clienteswwds_19_tfclidir = "";
         lV108Ventas_clienteswwds_21_tfestcod = "";
         lV110Ventas_clienteswwds_23_tfpaicod = "";
         lV112Ventas_clienteswwds_25_tfclitel1 = "";
         lV114Ventas_clienteswwds_27_tfclitel2 = "";
         lV116Ventas_clienteswwds_29_tfclifax = "";
         lV118Ventas_clienteswwds_31_tfclicel = "";
         lV120Ventas_clienteswwds_33_tfcliema = "";
         lV122Ventas_clienteswwds_35_tfcliweb = "";
         lV134Ventas_clienteswwds_47_tfclivenddsc = "";
         lV136Ventas_clienteswwds_49_tfcliref1 = "";
         lV138Ventas_clienteswwds_51_tfcliref2 = "";
         lV140Ventas_clienteswwds_53_tfcliref3 = "";
         lV142Ventas_clienteswwds_55_tfcliref4 = "";
         lV144Ventas_clienteswwds_57_tfcliref5 = "";
         lV146Ventas_clienteswwds_59_tfcliref6 = "";
         lV148Ventas_clienteswwds_61_tfcliref7 = "";
         A161CliDsc = "";
         A635CliVendDsc = "";
         A45CliCod = "";
         A596CliDir = "";
         A140EstCod = "";
         A139PaiCod = "";
         A629CliTel1 = "";
         A630CliTel2 = "";
         A611CliFax = "";
         A575CliCel = "";
         A609CliEma = "";
         A637CliWeb = "";
         A618CliRef1 = "";
         A619CliRef2 = "";
         A620CliRef3 = "";
         A621CliRef4 = "";
         A622CliRef5 = "";
         A623CliRef6 = "";
         A624CliRef7 = "";
         P00GB2_A624CliRef7 = new string[] {""} ;
         P00GB2_A623CliRef6 = new string[] {""} ;
         P00GB2_A622CliRef5 = new string[] {""} ;
         P00GB2_A621CliRef4 = new string[] {""} ;
         P00GB2_A620CliRef3 = new string[] {""} ;
         P00GB2_A619CliRef2 = new string[] {""} ;
         P00GB2_A618CliRef1 = new string[] {""} ;
         P00GB2_A160CliVend = new int[1] ;
         P00GB2_A613CliLim = new decimal[1] ;
         P00GB2_A137Conpcod = new int[1] ;
         P00GB2_A627CliSts = new short[1] ;
         P00GB2_A159TipCCod = new int[1] ;
         P00GB2_A637CliWeb = new string[] {""} ;
         P00GB2_A609CliEma = new string[] {""} ;
         P00GB2_A575CliCel = new string[] {""} ;
         P00GB2_A611CliFax = new string[] {""} ;
         P00GB2_A630CliTel2 = new string[] {""} ;
         P00GB2_A629CliTel1 = new string[] {""} ;
         P00GB2_A139PaiCod = new string[] {""} ;
         P00GB2_A140EstCod = new string[] {""} ;
         P00GB2_A596CliDir = new string[] {""} ;
         P00GB2_A45CliCod = new string[] {""} ;
         P00GB2_A635CliVendDsc = new string[] {""} ;
         P00GB2_A161CliDsc = new string[] {""} ;
         GXt_char1 = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas.clienteswwexport__default(),
            new Object[][] {
                new Object[] {
               P00GB2_A624CliRef7, P00GB2_A623CliRef6, P00GB2_A622CliRef5, P00GB2_A621CliRef4, P00GB2_A620CliRef3, P00GB2_A619CliRef2, P00GB2_A618CliRef1, P00GB2_A160CliVend, P00GB2_A613CliLim, P00GB2_A137Conpcod,
               P00GB2_A627CliSts, P00GB2_A159TipCCod, P00GB2_A637CliWeb, P00GB2_A609CliEma, P00GB2_A575CliCel, P00GB2_A611CliFax, P00GB2_A630CliTel2, P00GB2_A629CliTel1, P00GB2_A139PaiCod, P00GB2_A140EstCod,
               P00GB2_A596CliDir, P00GB2_A45CliCod, P00GB2_A635CliVendDsc, P00GB2_A161CliDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV61TFCliSts ;
      private short AV62TFCliSts_To ;
      private short GXt_int2 ;
      private short AV89Ventas_clienteswwds_2_dynamicfiltersoperator1 ;
      private short AV94Ventas_clienteswwds_7_dynamicfiltersoperator2 ;
      private short AV99Ventas_clienteswwds_12_dynamicfiltersoperator3 ;
      private short AV126Ventas_clienteswwds_39_tfclists ;
      private short AV127Ventas_clienteswwds_40_tfclists_to ;
      private short A627CliSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV59TFTipCCod ;
      private int AV60TFTipCCod_To ;
      private int AV63TFConpcod ;
      private int AV64TFConpcod_To ;
      private int AV67TFCliVend ;
      private int AV68TFCliVend_To ;
      private int AV124Ventas_clienteswwds_37_tftipccod ;
      private int AV125Ventas_clienteswwds_38_tftipccod_to ;
      private int AV128Ventas_clienteswwds_41_tfconpcod ;
      private int AV129Ventas_clienteswwds_42_tfconpcod_to ;
      private int AV132Ventas_clienteswwds_45_tfclivend ;
      private int AV133Ventas_clienteswwds_46_tfclivend_to ;
      private int A159TipCCod ;
      private int A137Conpcod ;
      private int A160CliVend ;
      private int AV150GXV1 ;
      private decimal AV65TFCliLim ;
      private decimal AV66TFCliLim_To ;
      private decimal AV130Ventas_clienteswwds_43_tfclilim ;
      private decimal AV131Ventas_clienteswwds_44_tfclilim_to ;
      private decimal A613CliLim ;
      private string AV20CliDsc1 ;
      private string AV21CliVendDsc1 ;
      private string AV25CliDsc2 ;
      private string AV26CliVendDsc2 ;
      private string AV30CliDsc3 ;
      private string AV31CliVendDsc3 ;
      private string AV38TFCliCod_Sel ;
      private string AV37TFCliCod ;
      private string AV40TFCliDsc_Sel ;
      private string AV39TFCliDsc ;
      private string AV42TFCliDir_Sel ;
      private string AV41TFCliDir ;
      private string AV44TFEstCod_Sel ;
      private string AV43TFEstCod ;
      private string AV46TFPaiCod_Sel ;
      private string AV45TFPaiCod ;
      private string AV48TFCliTel1_Sel ;
      private string AV47TFCliTel1 ;
      private string AV50TFCliTel2_Sel ;
      private string AV49TFCliTel2 ;
      private string AV52TFCliFax_Sel ;
      private string AV51TFCliFax ;
      private string AV54TFCliCel_Sel ;
      private string AV53TFCliCel ;
      private string AV58TFCliWeb_Sel ;
      private string AV57TFCliWeb ;
      private string AV70TFCliVendDsc_Sel ;
      private string AV69TFCliVendDsc ;
      private string AV72TFCliRef1_Sel ;
      private string AV71TFCliRef1 ;
      private string AV74TFCliRef2_Sel ;
      private string AV73TFCliRef2 ;
      private string AV76TFCliRef3_Sel ;
      private string AV75TFCliRef3 ;
      private string AV78TFCliRef4_Sel ;
      private string AV77TFCliRef4 ;
      private string AV80TFCliRef5_Sel ;
      private string AV79TFCliRef5 ;
      private string AV82TFCliRef6_Sel ;
      private string AV81TFCliRef6 ;
      private string AV84TFCliRef7_Sel ;
      private string AV83TFCliRef7 ;
      private string AV90Ventas_clienteswwds_3_clidsc1 ;
      private string AV91Ventas_clienteswwds_4_clivenddsc1 ;
      private string AV95Ventas_clienteswwds_8_clidsc2 ;
      private string AV96Ventas_clienteswwds_9_clivenddsc2 ;
      private string AV100Ventas_clienteswwds_13_clidsc3 ;
      private string AV101Ventas_clienteswwds_14_clivenddsc3 ;
      private string AV102Ventas_clienteswwds_15_tfclicod ;
      private string AV103Ventas_clienteswwds_16_tfclicod_sel ;
      private string AV104Ventas_clienteswwds_17_tfclidsc ;
      private string AV105Ventas_clienteswwds_18_tfclidsc_sel ;
      private string AV106Ventas_clienteswwds_19_tfclidir ;
      private string AV107Ventas_clienteswwds_20_tfclidir_sel ;
      private string AV108Ventas_clienteswwds_21_tfestcod ;
      private string AV109Ventas_clienteswwds_22_tfestcod_sel ;
      private string AV110Ventas_clienteswwds_23_tfpaicod ;
      private string AV111Ventas_clienteswwds_24_tfpaicod_sel ;
      private string AV112Ventas_clienteswwds_25_tfclitel1 ;
      private string AV113Ventas_clienteswwds_26_tfclitel1_sel ;
      private string AV114Ventas_clienteswwds_27_tfclitel2 ;
      private string AV115Ventas_clienteswwds_28_tfclitel2_sel ;
      private string AV116Ventas_clienteswwds_29_tfclifax ;
      private string AV117Ventas_clienteswwds_30_tfclifax_sel ;
      private string AV118Ventas_clienteswwds_31_tfclicel ;
      private string AV119Ventas_clienteswwds_32_tfclicel_sel ;
      private string AV122Ventas_clienteswwds_35_tfcliweb ;
      private string AV123Ventas_clienteswwds_36_tfcliweb_sel ;
      private string AV134Ventas_clienteswwds_47_tfclivenddsc ;
      private string AV135Ventas_clienteswwds_48_tfclivenddsc_sel ;
      private string AV136Ventas_clienteswwds_49_tfcliref1 ;
      private string AV137Ventas_clienteswwds_50_tfcliref1_sel ;
      private string AV138Ventas_clienteswwds_51_tfcliref2 ;
      private string AV139Ventas_clienteswwds_52_tfcliref2_sel ;
      private string AV140Ventas_clienteswwds_53_tfcliref3 ;
      private string AV141Ventas_clienteswwds_54_tfcliref3_sel ;
      private string AV142Ventas_clienteswwds_55_tfcliref4 ;
      private string AV143Ventas_clienteswwds_56_tfcliref4_sel ;
      private string AV144Ventas_clienteswwds_57_tfcliref5 ;
      private string AV145Ventas_clienteswwds_58_tfcliref5_sel ;
      private string AV146Ventas_clienteswwds_59_tfcliref6 ;
      private string AV147Ventas_clienteswwds_60_tfcliref6_sel ;
      private string AV148Ventas_clienteswwds_61_tfcliref7 ;
      private string AV149Ventas_clienteswwds_62_tfcliref7_sel ;
      private string scmdbuf ;
      private string lV90Ventas_clienteswwds_3_clidsc1 ;
      private string lV91Ventas_clienteswwds_4_clivenddsc1 ;
      private string lV95Ventas_clienteswwds_8_clidsc2 ;
      private string lV96Ventas_clienteswwds_9_clivenddsc2 ;
      private string lV100Ventas_clienteswwds_13_clidsc3 ;
      private string lV101Ventas_clienteswwds_14_clivenddsc3 ;
      private string lV102Ventas_clienteswwds_15_tfclicod ;
      private string lV104Ventas_clienteswwds_17_tfclidsc ;
      private string lV106Ventas_clienteswwds_19_tfclidir ;
      private string lV108Ventas_clienteswwds_21_tfestcod ;
      private string lV110Ventas_clienteswwds_23_tfpaicod ;
      private string lV112Ventas_clienteswwds_25_tfclitel1 ;
      private string lV114Ventas_clienteswwds_27_tfclitel2 ;
      private string lV116Ventas_clienteswwds_29_tfclifax ;
      private string lV118Ventas_clienteswwds_31_tfclicel ;
      private string lV122Ventas_clienteswwds_35_tfcliweb ;
      private string lV134Ventas_clienteswwds_47_tfclivenddsc ;
      private string lV136Ventas_clienteswwds_49_tfcliref1 ;
      private string lV138Ventas_clienteswwds_51_tfcliref2 ;
      private string lV140Ventas_clienteswwds_53_tfcliref3 ;
      private string lV142Ventas_clienteswwds_55_tfcliref4 ;
      private string lV144Ventas_clienteswwds_57_tfcliref5 ;
      private string lV146Ventas_clienteswwds_59_tfcliref6 ;
      private string lV148Ventas_clienteswwds_61_tfcliref7 ;
      private string A161CliDsc ;
      private string A635CliVendDsc ;
      private string A45CliCod ;
      private string A596CliDir ;
      private string A140EstCod ;
      private string A139PaiCod ;
      private string A629CliTel1 ;
      private string A630CliTel2 ;
      private string A611CliFax ;
      private string A575CliCel ;
      private string A637CliWeb ;
      private string A618CliRef1 ;
      private string A619CliRef2 ;
      private string A620CliRef3 ;
      private string A621CliRef4 ;
      private string A622CliRef5 ;
      private string A623CliRef6 ;
      private string A624CliRef7 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV92Ventas_clienteswwds_5_dynamicfiltersenabled2 ;
      private bool AV97Ventas_clienteswwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV56TFCliEma_Sel ;
      private string AV55TFCliEma ;
      private string AV88Ventas_clienteswwds_1_dynamicfiltersselector1 ;
      private string AV93Ventas_clienteswwds_6_dynamicfiltersselector2 ;
      private string AV98Ventas_clienteswwds_11_dynamicfiltersselector3 ;
      private string AV120Ventas_clienteswwds_33_tfcliema ;
      private string AV121Ventas_clienteswwds_34_tfcliema_sel ;
      private string lV120Ventas_clienteswwds_33_tfcliema ;
      private string A609CliEma ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00GB2_A624CliRef7 ;
      private string[] P00GB2_A623CliRef6 ;
      private string[] P00GB2_A622CliRef5 ;
      private string[] P00GB2_A621CliRef4 ;
      private string[] P00GB2_A620CliRef3 ;
      private string[] P00GB2_A619CliRef2 ;
      private string[] P00GB2_A618CliRef1 ;
      private int[] P00GB2_A160CliVend ;
      private decimal[] P00GB2_A613CliLim ;
      private int[] P00GB2_A137Conpcod ;
      private short[] P00GB2_A627CliSts ;
      private int[] P00GB2_A159TipCCod ;
      private string[] P00GB2_A637CliWeb ;
      private string[] P00GB2_A609CliEma ;
      private string[] P00GB2_A575CliCel ;
      private string[] P00GB2_A611CliFax ;
      private string[] P00GB2_A630CliTel2 ;
      private string[] P00GB2_A629CliTel1 ;
      private string[] P00GB2_A139PaiCod ;
      private string[] P00GB2_A140EstCod ;
      private string[] P00GB2_A596CliDir ;
      private string[] P00GB2_A45CliCod ;
      private string[] P00GB2_A635CliVendDsc ;
      private string[] P00GB2_A161CliDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
   }

   public class clienteswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GB2( IGxContext context ,
                                             string AV88Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                             short AV89Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                             string AV90Ventas_clienteswwds_3_clidsc1 ,
                                             string AV91Ventas_clienteswwds_4_clivenddsc1 ,
                                             bool AV92Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                             string AV93Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                             short AV94Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                             string AV95Ventas_clienteswwds_8_clidsc2 ,
                                             string AV96Ventas_clienteswwds_9_clivenddsc2 ,
                                             bool AV97Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                             string AV98Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                             short AV99Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                             string AV100Ventas_clienteswwds_13_clidsc3 ,
                                             string AV101Ventas_clienteswwds_14_clivenddsc3 ,
                                             string AV103Ventas_clienteswwds_16_tfclicod_sel ,
                                             string AV102Ventas_clienteswwds_15_tfclicod ,
                                             string AV105Ventas_clienteswwds_18_tfclidsc_sel ,
                                             string AV104Ventas_clienteswwds_17_tfclidsc ,
                                             string AV107Ventas_clienteswwds_20_tfclidir_sel ,
                                             string AV106Ventas_clienteswwds_19_tfclidir ,
                                             string AV109Ventas_clienteswwds_22_tfestcod_sel ,
                                             string AV108Ventas_clienteswwds_21_tfestcod ,
                                             string AV111Ventas_clienteswwds_24_tfpaicod_sel ,
                                             string AV110Ventas_clienteswwds_23_tfpaicod ,
                                             string AV113Ventas_clienteswwds_26_tfclitel1_sel ,
                                             string AV112Ventas_clienteswwds_25_tfclitel1 ,
                                             string AV115Ventas_clienteswwds_28_tfclitel2_sel ,
                                             string AV114Ventas_clienteswwds_27_tfclitel2 ,
                                             string AV117Ventas_clienteswwds_30_tfclifax_sel ,
                                             string AV116Ventas_clienteswwds_29_tfclifax ,
                                             string AV119Ventas_clienteswwds_32_tfclicel_sel ,
                                             string AV118Ventas_clienteswwds_31_tfclicel ,
                                             string AV121Ventas_clienteswwds_34_tfcliema_sel ,
                                             string AV120Ventas_clienteswwds_33_tfcliema ,
                                             string AV123Ventas_clienteswwds_36_tfcliweb_sel ,
                                             string AV122Ventas_clienteswwds_35_tfcliweb ,
                                             int AV124Ventas_clienteswwds_37_tftipccod ,
                                             int AV125Ventas_clienteswwds_38_tftipccod_to ,
                                             short AV126Ventas_clienteswwds_39_tfclists ,
                                             short AV127Ventas_clienteswwds_40_tfclists_to ,
                                             int AV128Ventas_clienteswwds_41_tfconpcod ,
                                             int AV129Ventas_clienteswwds_42_tfconpcod_to ,
                                             decimal AV130Ventas_clienteswwds_43_tfclilim ,
                                             decimal AV131Ventas_clienteswwds_44_tfclilim_to ,
                                             int AV132Ventas_clienteswwds_45_tfclivend ,
                                             int AV133Ventas_clienteswwds_46_tfclivend_to ,
                                             string AV135Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                             string AV134Ventas_clienteswwds_47_tfclivenddsc ,
                                             string AV137Ventas_clienteswwds_50_tfcliref1_sel ,
                                             string AV136Ventas_clienteswwds_49_tfcliref1 ,
                                             string AV139Ventas_clienteswwds_52_tfcliref2_sel ,
                                             string AV138Ventas_clienteswwds_51_tfcliref2 ,
                                             string AV141Ventas_clienteswwds_54_tfcliref3_sel ,
                                             string AV140Ventas_clienteswwds_53_tfcliref3 ,
                                             string AV143Ventas_clienteswwds_56_tfcliref4_sel ,
                                             string AV142Ventas_clienteswwds_55_tfcliref4 ,
                                             string AV145Ventas_clienteswwds_58_tfcliref5_sel ,
                                             string AV144Ventas_clienteswwds_57_tfcliref5 ,
                                             string AV147Ventas_clienteswwds_60_tfcliref6_sel ,
                                             string AV146Ventas_clienteswwds_59_tfcliref6 ,
                                             string AV149Ventas_clienteswwds_62_tfcliref7_sel ,
                                             string AV148Ventas_clienteswwds_61_tfcliref7 ,
                                             string A161CliDsc ,
                                             string A635CliVendDsc ,
                                             string A45CliCod ,
                                             string A596CliDir ,
                                             string A140EstCod ,
                                             string A139PaiCod ,
                                             string A629CliTel1 ,
                                             string A630CliTel2 ,
                                             string A611CliFax ,
                                             string A575CliCel ,
                                             string A609CliEma ,
                                             string A637CliWeb ,
                                             int A159TipCCod ,
                                             short A627CliSts ,
                                             int A137Conpcod ,
                                             decimal A613CliLim ,
                                             int A160CliVend ,
                                             string A618CliRef1 ,
                                             string A619CliRef2 ,
                                             string A620CliRef3 ,
                                             string A621CliRef4 ,
                                             string A622CliRef5 ,
                                             string A623CliRef6 ,
                                             string A624CliRef7 ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[60];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CliRef7], T1.[CliRef6], T1.[CliRef5], T1.[CliRef4], T1.[CliRef3], T1.[CliRef2], T1.[CliRef1], T1.[CliVend] AS CliVend, T1.[CliLim], T1.[Conpcod], T1.[CliSts], T1.[TipCCod], T1.[CliWeb], T1.[CliEma], T1.[CliCel], T1.[CliFax], T1.[CliTel2], T1.[CliTel1], T1.[PaiCod], T1.[EstCod], T1.[CliDir], T1.[CliCod], T2.[VenDsc] AS CliVendDsc, T1.[CliDsc] FROM ([CLCLIENTES] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[CliVend])";
         if ( ( StringUtil.StrCmp(AV88Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIDSC") == 0 ) && ( AV89Ventas_clienteswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Ventas_clienteswwds_3_clidsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV90Ventas_clienteswwds_3_clidsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIDSC") == 0 ) && ( AV89Ventas_clienteswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Ventas_clienteswwds_3_clidsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like '%' + @lV90Ventas_clienteswwds_3_clidsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIVENDDSC") == 0 ) && ( AV89Ventas_clienteswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Ventas_clienteswwds_4_clivenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV91Ventas_clienteswwds_4_clivenddsc1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIVENDDSC") == 0 ) && ( AV89Ventas_clienteswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Ventas_clienteswwds_4_clivenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV91Ventas_clienteswwds_4_clivenddsc1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV92Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIDSC") == 0 ) && ( AV94Ventas_clienteswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Ventas_clienteswwds_8_clidsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV95Ventas_clienteswwds_8_clidsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV92Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIDSC") == 0 ) && ( AV94Ventas_clienteswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Ventas_clienteswwds_8_clidsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like '%' + @lV95Ventas_clienteswwds_8_clidsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV92Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIVENDDSC") == 0 ) && ( AV94Ventas_clienteswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Ventas_clienteswwds_9_clivenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV96Ventas_clienteswwds_9_clivenddsc2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV92Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIVENDDSC") == 0 ) && ( AV94Ventas_clienteswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Ventas_clienteswwds_9_clivenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV96Ventas_clienteswwds_9_clivenddsc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV97Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIDSC") == 0 ) && ( AV99Ventas_clienteswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Ventas_clienteswwds_13_clidsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV100Ventas_clienteswwds_13_clidsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV97Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIDSC") == 0 ) && ( AV99Ventas_clienteswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Ventas_clienteswwds_13_clidsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like '%' + @lV100Ventas_clienteswwds_13_clidsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV97Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIVENDDSC") == 0 ) && ( AV99Ventas_clienteswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Ventas_clienteswwds_14_clivenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV101Ventas_clienteswwds_14_clivenddsc3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV97Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIVENDDSC") == 0 ) && ( AV99Ventas_clienteswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Ventas_clienteswwds_14_clivenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV101Ventas_clienteswwds_14_clivenddsc3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Ventas_clienteswwds_16_tfclicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Ventas_clienteswwds_15_tfclicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] like @lV102Ventas_clienteswwds_15_tfclicod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Ventas_clienteswwds_16_tfclicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV103Ventas_clienteswwds_16_tfclicod_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Ventas_clienteswwds_18_tfclidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Ventas_clienteswwds_17_tfclidsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV104Ventas_clienteswwds_17_tfclidsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Ventas_clienteswwds_18_tfclidsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] = @AV105Ventas_clienteswwds_18_tfclidsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Ventas_clienteswwds_20_tfclidir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Ventas_clienteswwds_19_tfclidir)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDir] like @lV106Ventas_clienteswwds_19_tfclidir)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Ventas_clienteswwds_20_tfclidir_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliDir] = @AV107Ventas_clienteswwds_20_tfclidir_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Ventas_clienteswwds_22_tfestcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Ventas_clienteswwds_21_tfestcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] like @lV108Ventas_clienteswwds_21_tfestcod)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Ventas_clienteswwds_22_tfestcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] = @AV109Ventas_clienteswwds_22_tfestcod_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Ventas_clienteswwds_24_tfpaicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Ventas_clienteswwds_23_tfpaicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV110Ventas_clienteswwds_23_tfpaicod)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Ventas_clienteswwds_24_tfpaicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] = @AV111Ventas_clienteswwds_24_tfpaicod_sel)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Ventas_clienteswwds_26_tfclitel1_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Ventas_clienteswwds_25_tfclitel1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliTel1] like @lV112Ventas_clienteswwds_25_tfclitel1)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Ventas_clienteswwds_26_tfclitel1_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliTel1] = @AV113Ventas_clienteswwds_26_tfclitel1_sel)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Ventas_clienteswwds_28_tfclitel2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Ventas_clienteswwds_27_tfclitel2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliTel2] like @lV114Ventas_clienteswwds_27_tfclitel2)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Ventas_clienteswwds_28_tfclitel2_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliTel2] = @AV115Ventas_clienteswwds_28_tfclitel2_sel)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Ventas_clienteswwds_30_tfclifax_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Ventas_clienteswwds_29_tfclifax)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliFax] like @lV116Ventas_clienteswwds_29_tfclifax)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Ventas_clienteswwds_30_tfclifax_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliFax] = @AV117Ventas_clienteswwds_30_tfclifax_sel)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Ventas_clienteswwds_32_tfclicel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Ventas_clienteswwds_31_tfclicel)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCel] like @lV118Ventas_clienteswwds_31_tfclicel)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Ventas_clienteswwds_32_tfclicel_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCel] = @AV119Ventas_clienteswwds_32_tfclicel_sel)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV121Ventas_clienteswwds_34_tfcliema_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Ventas_clienteswwds_33_tfcliema)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliEma] like @lV120Ventas_clienteswwds_33_tfcliema)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Ventas_clienteswwds_34_tfcliema_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliEma] = @AV121Ventas_clienteswwds_34_tfcliema_sel)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Ventas_clienteswwds_36_tfcliweb_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Ventas_clienteswwds_35_tfcliweb)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliWeb] like @lV122Ventas_clienteswwds_35_tfcliweb)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Ventas_clienteswwds_36_tfcliweb_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliWeb] = @AV123Ventas_clienteswwds_36_tfcliweb_sel)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( ! (0==AV124Ventas_clienteswwds_37_tftipccod) )
         {
            AddWhere(sWhereString, "(T1.[TipCCod] >= @AV124Ventas_clienteswwds_37_tftipccod)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( ! (0==AV125Ventas_clienteswwds_38_tftipccod_to) )
         {
            AddWhere(sWhereString, "(T1.[TipCCod] <= @AV125Ventas_clienteswwds_38_tftipccod_to)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( ! (0==AV126Ventas_clienteswwds_39_tfclists) )
         {
            AddWhere(sWhereString, "(T1.[CliSts] >= @AV126Ventas_clienteswwds_39_tfclists)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( ! (0==AV127Ventas_clienteswwds_40_tfclists_to) )
         {
            AddWhere(sWhereString, "(T1.[CliSts] <= @AV127Ventas_clienteswwds_40_tfclists_to)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( ! (0==AV128Ventas_clienteswwds_41_tfconpcod) )
         {
            AddWhere(sWhereString, "(T1.[Conpcod] >= @AV128Ventas_clienteswwds_41_tfconpcod)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( ! (0==AV129Ventas_clienteswwds_42_tfconpcod_to) )
         {
            AddWhere(sWhereString, "(T1.[Conpcod] <= @AV129Ventas_clienteswwds_42_tfconpcod_to)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV130Ventas_clienteswwds_43_tfclilim) )
         {
            AddWhere(sWhereString, "(T1.[CliLim] >= @AV130Ventas_clienteswwds_43_tfclilim)");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV131Ventas_clienteswwds_44_tfclilim_to) )
         {
            AddWhere(sWhereString, "(T1.[CliLim] <= @AV131Ventas_clienteswwds_44_tfclilim_to)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( ! (0==AV132Ventas_clienteswwds_45_tfclivend) )
         {
            AddWhere(sWhereString, "(T1.[CliVend] >= @AV132Ventas_clienteswwds_45_tfclivend)");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( ! (0==AV133Ventas_clienteswwds_46_tfclivend_to) )
         {
            AddWhere(sWhereString, "(T1.[CliVend] <= @AV133Ventas_clienteswwds_46_tfclivend_to)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV135Ventas_clienteswwds_48_tfclivenddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Ventas_clienteswwds_47_tfclivenddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV134Ventas_clienteswwds_47_tfclivenddsc)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Ventas_clienteswwds_48_tfclivenddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] = @AV135Ventas_clienteswwds_48_tfclivenddsc_sel)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV137Ventas_clienteswwds_50_tfcliref1_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Ventas_clienteswwds_49_tfcliref1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef1] like @lV136Ventas_clienteswwds_49_tfcliref1)");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Ventas_clienteswwds_50_tfcliref1_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef1] = @AV137Ventas_clienteswwds_50_tfcliref1_sel)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV139Ventas_clienteswwds_52_tfcliref2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Ventas_clienteswwds_51_tfcliref2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef2] like @lV138Ventas_clienteswwds_51_tfcliref2)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Ventas_clienteswwds_52_tfcliref2_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef2] = @AV139Ventas_clienteswwds_52_tfcliref2_sel)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Ventas_clienteswwds_54_tfcliref3_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Ventas_clienteswwds_53_tfcliref3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef3] like @lV140Ventas_clienteswwds_53_tfcliref3)");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Ventas_clienteswwds_54_tfcliref3_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef3] = @AV141Ventas_clienteswwds_54_tfcliref3_sel)");
         }
         else
         {
            GXv_int3[51] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Ventas_clienteswwds_56_tfcliref4_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Ventas_clienteswwds_55_tfcliref4)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef4] like @lV142Ventas_clienteswwds_55_tfcliref4)");
         }
         else
         {
            GXv_int3[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Ventas_clienteswwds_56_tfcliref4_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef4] = @AV143Ventas_clienteswwds_56_tfcliref4_sel)");
         }
         else
         {
            GXv_int3[53] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV145Ventas_clienteswwds_58_tfcliref5_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Ventas_clienteswwds_57_tfcliref5)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef5] like @lV144Ventas_clienteswwds_57_tfcliref5)");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Ventas_clienteswwds_58_tfcliref5_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef5] = @AV145Ventas_clienteswwds_58_tfcliref5_sel)");
         }
         else
         {
            GXv_int3[55] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV147Ventas_clienteswwds_60_tfcliref6_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Ventas_clienteswwds_59_tfcliref6)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef6] like @lV146Ventas_clienteswwds_59_tfcliref6)");
         }
         else
         {
            GXv_int3[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Ventas_clienteswwds_60_tfcliref6_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef6] = @AV147Ventas_clienteswwds_60_tfcliref6_sel)");
         }
         else
         {
            GXv_int3[57] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV149Ventas_clienteswwds_62_tfcliref7_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Ventas_clienteswwds_61_tfcliref7)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef7] like @lV148Ventas_clienteswwds_61_tfcliref7)");
         }
         else
         {
            GXv_int3[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Ventas_clienteswwds_62_tfcliref7_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef7] = @AV149Ventas_clienteswwds_62_tfcliref7_sel)");
         }
         else
         {
            GXv_int3[59] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliDsc]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliCod] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliDir]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliDir] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstCod]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstCod] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PaiCod]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PaiCod] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliTel1]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliTel1] DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliTel2]";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliTel2] DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliFax]";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliFax] DESC";
         }
         else if ( ( AV16OrderedBy == 9 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliCel]";
         }
         else if ( ( AV16OrderedBy == 9 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliCel] DESC";
         }
         else if ( ( AV16OrderedBy == 10 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliEma]";
         }
         else if ( ( AV16OrderedBy == 10 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliEma] DESC";
         }
         else if ( ( AV16OrderedBy == 11 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliWeb]";
         }
         else if ( ( AV16OrderedBy == 11 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliWeb] DESC";
         }
         else if ( ( AV16OrderedBy == 12 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipCCod]";
         }
         else if ( ( AV16OrderedBy == 12 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipCCod] DESC";
         }
         else if ( ( AV16OrderedBy == 13 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliSts]";
         }
         else if ( ( AV16OrderedBy == 13 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliSts] DESC";
         }
         else if ( ( AV16OrderedBy == 14 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[Conpcod]";
         }
         else if ( ( AV16OrderedBy == 14 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[Conpcod] DESC";
         }
         else if ( ( AV16OrderedBy == 15 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliLim]";
         }
         else if ( ( AV16OrderedBy == 15 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliLim] DESC";
         }
         else if ( ( AV16OrderedBy == 16 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliVend]";
         }
         else if ( ( AV16OrderedBy == 16 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliVend] DESC";
         }
         else if ( ( AV16OrderedBy == 17 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[VenDsc]";
         }
         else if ( ( AV16OrderedBy == 17 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[VenDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 18 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliRef1]";
         }
         else if ( ( AV16OrderedBy == 18 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliRef1] DESC";
         }
         else if ( ( AV16OrderedBy == 19 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliRef2]";
         }
         else if ( ( AV16OrderedBy == 19 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliRef2] DESC";
         }
         else if ( ( AV16OrderedBy == 20 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliRef3]";
         }
         else if ( ( AV16OrderedBy == 20 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliRef3] DESC";
         }
         else if ( ( AV16OrderedBy == 21 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliRef4]";
         }
         else if ( ( AV16OrderedBy == 21 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliRef4] DESC";
         }
         else if ( ( AV16OrderedBy == 22 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliRef5]";
         }
         else if ( ( AV16OrderedBy == 22 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliRef5] DESC";
         }
         else if ( ( AV16OrderedBy == 23 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliRef6]";
         }
         else if ( ( AV16OrderedBy == 23 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliRef6] DESC";
         }
         else if ( ( AV16OrderedBy == 24 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliRef7]";
         }
         else if ( ( AV16OrderedBy == 24 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliRef7] DESC";
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
                     return conditional_P00GB2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (int)dynConstraints[37] , (short)dynConstraints[38] , (short)dynConstraints[39] , (int)dynConstraints[40] , (int)dynConstraints[41] , (decimal)dynConstraints[42] , (decimal)dynConstraints[43] , (int)dynConstraints[44] , (int)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (int)dynConstraints[74] , (short)dynConstraints[75] , (int)dynConstraints[76] , (decimal)dynConstraints[77] , (int)dynConstraints[78] , (string)dynConstraints[79] , (string)dynConstraints[80] , (string)dynConstraints[81] , (string)dynConstraints[82] , (string)dynConstraints[83] , (string)dynConstraints[84] , (string)dynConstraints[85] , (short)dynConstraints[86] , (bool)dynConstraints[87] );
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
          Object[] prmP00GB2;
          prmP00GB2 = new Object[] {
          new ParDef("@lV90Ventas_clienteswwds_3_clidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV90Ventas_clienteswwds_3_clidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV91Ventas_clienteswwds_4_clivenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV91Ventas_clienteswwds_4_clivenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV95Ventas_clienteswwds_8_clidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV95Ventas_clienteswwds_8_clidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV96Ventas_clienteswwds_9_clivenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV96Ventas_clienteswwds_9_clivenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV100Ventas_clienteswwds_13_clidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV100Ventas_clienteswwds_13_clidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV101Ventas_clienteswwds_14_clivenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV101Ventas_clienteswwds_14_clivenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV102Ventas_clienteswwds_15_tfclicod",GXType.NChar,20,0) ,
          new ParDef("@AV103Ventas_clienteswwds_16_tfclicod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV104Ventas_clienteswwds_17_tfclidsc",GXType.NChar,100,0) ,
          new ParDef("@AV105Ventas_clienteswwds_18_tfclidsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV106Ventas_clienteswwds_19_tfclidir",GXType.NChar,100,0) ,
          new ParDef("@AV107Ventas_clienteswwds_20_tfclidir_sel",GXType.NChar,100,0) ,
          new ParDef("@lV108Ventas_clienteswwds_21_tfestcod",GXType.NChar,4,0) ,
          new ParDef("@AV109Ventas_clienteswwds_22_tfestcod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV110Ventas_clienteswwds_23_tfpaicod",GXType.NChar,4,0) ,
          new ParDef("@AV111Ventas_clienteswwds_24_tfpaicod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV112Ventas_clienteswwds_25_tfclitel1",GXType.NChar,20,0) ,
          new ParDef("@AV113Ventas_clienteswwds_26_tfclitel1_sel",GXType.NChar,20,0) ,
          new ParDef("@lV114Ventas_clienteswwds_27_tfclitel2",GXType.NChar,20,0) ,
          new ParDef("@AV115Ventas_clienteswwds_28_tfclitel2_sel",GXType.NChar,20,0) ,
          new ParDef("@lV116Ventas_clienteswwds_29_tfclifax",GXType.NChar,20,0) ,
          new ParDef("@AV117Ventas_clienteswwds_30_tfclifax_sel",GXType.NChar,20,0) ,
          new ParDef("@lV118Ventas_clienteswwds_31_tfclicel",GXType.NChar,20,0) ,
          new ParDef("@AV119Ventas_clienteswwds_32_tfclicel_sel",GXType.NChar,20,0) ,
          new ParDef("@lV120Ventas_clienteswwds_33_tfcliema",GXType.NVarChar,100,0) ,
          new ParDef("@AV121Ventas_clienteswwds_34_tfcliema_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV122Ventas_clienteswwds_35_tfcliweb",GXType.NChar,50,0) ,
          new ParDef("@AV123Ventas_clienteswwds_36_tfcliweb_sel",GXType.NChar,50,0) ,
          new ParDef("@AV124Ventas_clienteswwds_37_tftipccod",GXType.Int32,6,0) ,
          new ParDef("@AV125Ventas_clienteswwds_38_tftipccod_to",GXType.Int32,6,0) ,
          new ParDef("@AV126Ventas_clienteswwds_39_tfclists",GXType.Int16,1,0) ,
          new ParDef("@AV127Ventas_clienteswwds_40_tfclists_to",GXType.Int16,1,0) ,
          new ParDef("@AV128Ventas_clienteswwds_41_tfconpcod",GXType.Int32,6,0) ,
          new ParDef("@AV129Ventas_clienteswwds_42_tfconpcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV130Ventas_clienteswwds_43_tfclilim",GXType.Decimal,15,2) ,
          new ParDef("@AV131Ventas_clienteswwds_44_tfclilim_to",GXType.Decimal,15,2) ,
          new ParDef("@AV132Ventas_clienteswwds_45_tfclivend",GXType.Int32,6,0) ,
          new ParDef("@AV133Ventas_clienteswwds_46_tfclivend_to",GXType.Int32,6,0) ,
          new ParDef("@lV134Ventas_clienteswwds_47_tfclivenddsc",GXType.NChar,100,0) ,
          new ParDef("@AV135Ventas_clienteswwds_48_tfclivenddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV136Ventas_clienteswwds_49_tfcliref1",GXType.NChar,50,0) ,
          new ParDef("@AV137Ventas_clienteswwds_50_tfcliref1_sel",GXType.NChar,50,0) ,
          new ParDef("@lV138Ventas_clienteswwds_51_tfcliref2",GXType.NChar,50,0) ,
          new ParDef("@AV139Ventas_clienteswwds_52_tfcliref2_sel",GXType.NChar,50,0) ,
          new ParDef("@lV140Ventas_clienteswwds_53_tfcliref3",GXType.NChar,50,0) ,
          new ParDef("@AV141Ventas_clienteswwds_54_tfcliref3_sel",GXType.NChar,50,0) ,
          new ParDef("@lV142Ventas_clienteswwds_55_tfcliref4",GXType.NChar,50,0) ,
          new ParDef("@AV143Ventas_clienteswwds_56_tfcliref4_sel",GXType.NChar,50,0) ,
          new ParDef("@lV144Ventas_clienteswwds_57_tfcliref5",GXType.NChar,50,0) ,
          new ParDef("@AV145Ventas_clienteswwds_58_tfcliref5_sel",GXType.NChar,50,0) ,
          new ParDef("@lV146Ventas_clienteswwds_59_tfcliref6",GXType.NChar,50,0) ,
          new ParDef("@AV147Ventas_clienteswwds_60_tfcliref6_sel",GXType.NChar,50,0) ,
          new ParDef("@lV148Ventas_clienteswwds_61_tfcliref7",GXType.NChar,50,0) ,
          new ParDef("@AV149Ventas_clienteswwds_62_tfcliref7_sel",GXType.NChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GB2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GB2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getString(5, 50);
                ((string[]) buf[5])[0] = rslt.getString(6, 50);
                ((string[]) buf[6])[0] = rslt.getString(7, 50);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((int[]) buf[11])[0] = rslt.getInt(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 50);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getString(15, 20);
                ((string[]) buf[15])[0] = rslt.getString(16, 20);
                ((string[]) buf[16])[0] = rslt.getString(17, 20);
                ((string[]) buf[17])[0] = rslt.getString(18, 20);
                ((string[]) buf[18])[0] = rslt.getString(19, 4);
                ((string[]) buf[19])[0] = rslt.getString(20, 4);
                ((string[]) buf[20])[0] = rslt.getString(21, 100);
                ((string[]) buf[21])[0] = rslt.getString(22, 20);
                ((string[]) buf[22])[0] = rslt.getString(23, 100);
                ((string[]) buf[23])[0] = rslt.getString(24, 100);
                return;
       }
    }

 }

}
