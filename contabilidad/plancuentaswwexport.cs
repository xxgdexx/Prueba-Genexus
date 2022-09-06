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
   public class plancuentaswwexport : GXProcedure
   {
      public plancuentaswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public plancuentaswwexport( IGxContext context )
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
         plancuentaswwexport objplancuentaswwexport;
         objplancuentaswwexport = new plancuentaswwexport();
         objplancuentaswwexport.AV11Filename = "" ;
         objplancuentaswwexport.AV12ErrorMessage = "" ;
         objplancuentaswwexport.context.SetSubmitInitialConfig(context);
         objplancuentaswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objplancuentaswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((plancuentaswwexport)stateInfo).executePrivate();
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
         AV11Filename = "PlanCuentasWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CUECOD") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV79CueCod1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79CueCod1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV79CueCod1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CUEDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV20CueDsc1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20CueDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20CueDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CUEMOV") == 0 )
            {
               AV89CueMov1 = (short)(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."));
               if ( ! (0==AV89CueMov1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Movimiento Cuenta";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                  if ( AV89CueMov1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "SOLO MOVIMIENTO";
                  }
                  else if ( AV89CueMov1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "CUENTAS TITULO";
                  }
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CUECOD") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV80CueCod2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80CueCod2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV80CueCod2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CUEDSC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25CueDsc2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25CueDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25CueDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CUEMOV") == 0 )
               {
                  AV90CueMov2 = (short)(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."));
                  if ( ! (0==AV90CueMov2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Movimiento Cuenta";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                     if ( AV90CueMov2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "SOLO MOVIMIENTO";
                     }
                     else if ( AV90CueMov2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "CUENTAS TITULO";
                     }
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CUECOD") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV81CueCod3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81CueCod3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV81CueCod3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CUEDSC") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30CueDsc3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30CueDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30CueDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CUEMOV") == 0 )
                  {
                     AV91CueMov3 = (short)(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."));
                     if ( ! (0==AV91CueMov3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Movimiento Cuenta";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                        if ( AV91CueMov3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "SOLO MOVIMIENTO";
                        }
                        else if ( AV91CueMov3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "CUENTAS TITULO";
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCueCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFCueCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCueCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFCueCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCueDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFCueDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCueDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFCueDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV82TFCueMov_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Movimiento") ;
            AV13CellRow = GXt_int2;
            if ( AV82TFCueMov_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV82TFCueMov_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV83TFCueMon_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Monetaria") ;
            AV13CellRow = GXt_int2;
            if ( AV83TFCueMon_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV83TFCueMon_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV84TFCueCos_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Centro de Costos") ;
            AV13CellRow = GXt_int2;
            if ( AV84TFCueCos_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV84TFCueCos_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFCueGasDebe_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Gasto Debe") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFCueGasDebe_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCueGasDebe)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Gasto Debe") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFCueGasDebe, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFCueGasHaber_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Gasto Haber") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54TFCueGasHaber_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFCueGasHaber)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Gasto Haber") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53TFCueGasHaber, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV86TFCueSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV88i = 1;
            AV94GXV1 = 1;
            while ( AV94GXV1 <= AV86TFCueSts_Sels.Count )
            {
               AV87TFCueSts_Sel = (short)(AV86TFCueSts_Sels.GetNumeric(AV94GXV1));
               if ( AV88i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV87TFCueSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV87TFCueSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV88i = (long)(AV88i+1);
               AV94GXV1 = (int)(AV94GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Cuenta Contable";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Descripción";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Movimiento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Monetaria";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Centro de Costos";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Gasto Debe";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Gasto Haber";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV96Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV97Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV98Contabilidad_plancuentaswwds_3_cuecod1 = AV79CueCod1;
         AV99Contabilidad_plancuentaswwds_4_cuedsc1 = AV20CueDsc1;
         AV100Contabilidad_plancuentaswwds_5_cuemov1 = AV89CueMov1;
         AV101Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV102Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV103Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV104Contabilidad_plancuentaswwds_9_cuecod2 = AV80CueCod2;
         AV105Contabilidad_plancuentaswwds_10_cuedsc2 = AV25CueDsc2;
         AV106Contabilidad_plancuentaswwds_11_cuemov2 = AV90CueMov2;
         AV107Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV108Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV109Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV110Contabilidad_plancuentaswwds_15_cuecod3 = AV81CueCod3;
         AV111Contabilidad_plancuentaswwds_16_cuedsc3 = AV30CueDsc3;
         AV112Contabilidad_plancuentaswwds_17_cuemov3 = AV91CueMov3;
         AV113Contabilidad_plancuentaswwds_18_tfcuecod = AV37TFCueCod;
         AV114Contabilidad_plancuentaswwds_19_tfcuecod_sel = AV38TFCueCod_Sel;
         AV115Contabilidad_plancuentaswwds_20_tfcuedsc = AV39TFCueDsc;
         AV116Contabilidad_plancuentaswwds_21_tfcuedsc_sel = AV40TFCueDsc_Sel;
         AV117Contabilidad_plancuentaswwds_22_tfcuemov_sel = AV82TFCueMov_Sel;
         AV118Contabilidad_plancuentaswwds_23_tfcuemon_sel = AV83TFCueMon_Sel;
         AV119Contabilidad_plancuentaswwds_24_tfcuecos_sel = AV84TFCueCos_Sel;
         AV120Contabilidad_plancuentaswwds_25_tfcuegasdebe = AV51TFCueGasDebe;
         AV121Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = AV52TFCueGasDebe_Sel;
         AV122Contabilidad_plancuentaswwds_27_tfcuegashaber = AV53TFCueGasHaber;
         AV123Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = AV54TFCueGasHaber_Sel;
         AV124Contabilidad_plancuentaswwds_29_tfcuests_sels = AV86TFCueSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A873CueSts ,
                                              AV124Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                              AV96Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                              AV97Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                              AV98Contabilidad_plancuentaswwds_3_cuecod1 ,
                                              AV99Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                              AV101Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                              AV102Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                              AV103Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                              AV104Contabilidad_plancuentaswwds_9_cuecod2 ,
                                              AV105Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                              AV107Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                              AV108Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                              AV109Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                              AV110Contabilidad_plancuentaswwds_15_cuecod3 ,
                                              AV111Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                              AV114Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                              AV113Contabilidad_plancuentaswwds_18_tfcuecod ,
                                              AV116Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                              AV115Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                              AV117Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                              AV118Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                              AV119Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                              AV121Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                              AV120Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                              AV123Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                              AV122Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                              AV124Contabilidad_plancuentaswwds_29_tfcuests_sels.Count ,
                                              A91CueCod ,
                                              A860CueDsc ,
                                              A867CueMov ,
                                              AV100Contabilidad_plancuentaswwds_5_cuemov1 ,
                                              AV106Contabilidad_plancuentaswwds_11_cuemov2 ,
                                              AV112Contabilidad_plancuentaswwds_17_cuemov3 ,
                                              A864CueMon ,
                                              A859CueCos ,
                                              A109CueGasDebe ,
                                              A110CueGasHaber ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV98Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV98Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
         lV98Contabilidad_plancuentaswwds_3_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV98Contabilidad_plancuentaswwds_3_cuecod1), 15, "%");
         lV99Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV99Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
         lV99Contabilidad_plancuentaswwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV99Contabilidad_plancuentaswwds_4_cuedsc1), 100, "%");
         lV104Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV104Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
         lV104Contabilidad_plancuentaswwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV104Contabilidad_plancuentaswwds_9_cuecod2), 15, "%");
         lV105Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV105Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
         lV105Contabilidad_plancuentaswwds_10_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV105Contabilidad_plancuentaswwds_10_cuedsc2), 100, "%");
         lV110Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV110Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
         lV110Contabilidad_plancuentaswwds_15_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV110Contabilidad_plancuentaswwds_15_cuecod3), 15, "%");
         lV111Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV111Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
         lV111Contabilidad_plancuentaswwds_16_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV111Contabilidad_plancuentaswwds_16_cuedsc3), 100, "%");
         lV113Contabilidad_plancuentaswwds_18_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_18_tfcuecod), 15, "%");
         lV115Contabilidad_plancuentaswwds_20_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV115Contabilidad_plancuentaswwds_20_tfcuedsc), 100, "%");
         lV120Contabilidad_plancuentaswwds_25_tfcuegasdebe = StringUtil.PadR( StringUtil.RTrim( AV120Contabilidad_plancuentaswwds_25_tfcuegasdebe), 15, "%");
         lV122Contabilidad_plancuentaswwds_27_tfcuegashaber = StringUtil.PadR( StringUtil.RTrim( AV122Contabilidad_plancuentaswwds_27_tfcuegashaber), 15, "%");
         /* Using cursor P006H2 */
         pr_default.execute(0, new Object[] {lV98Contabilidad_plancuentaswwds_3_cuecod1, lV98Contabilidad_plancuentaswwds_3_cuecod1, lV99Contabilidad_plancuentaswwds_4_cuedsc1, lV99Contabilidad_plancuentaswwds_4_cuedsc1, AV100Contabilidad_plancuentaswwds_5_cuemov1, lV104Contabilidad_plancuentaswwds_9_cuecod2, lV104Contabilidad_plancuentaswwds_9_cuecod2, lV105Contabilidad_plancuentaswwds_10_cuedsc2, lV105Contabilidad_plancuentaswwds_10_cuedsc2, AV106Contabilidad_plancuentaswwds_11_cuemov2, lV110Contabilidad_plancuentaswwds_15_cuecod3, lV110Contabilidad_plancuentaswwds_15_cuecod3, lV111Contabilidad_plancuentaswwds_16_cuedsc3, lV111Contabilidad_plancuentaswwds_16_cuedsc3, AV112Contabilidad_plancuentaswwds_17_cuemov3, lV113Contabilidad_plancuentaswwds_18_tfcuecod, AV114Contabilidad_plancuentaswwds_19_tfcuecod_sel, lV115Contabilidad_plancuentaswwds_20_tfcuedsc, AV116Contabilidad_plancuentaswwds_21_tfcuedsc_sel, lV120Contabilidad_plancuentaswwds_25_tfcuegasdebe, AV121Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel, lV122Contabilidad_plancuentaswwds_27_tfcuegashaber, AV123Contabilidad_plancuentaswwds_28_tfcuegashaber_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A873CueSts = P006H2_A873CueSts[0];
            A110CueGasHaber = P006H2_A110CueGasHaber[0];
            n110CueGasHaber = P006H2_n110CueGasHaber[0];
            A109CueGasDebe = P006H2_A109CueGasDebe[0];
            n109CueGasDebe = P006H2_n109CueGasDebe[0];
            A859CueCos = P006H2_A859CueCos[0];
            A864CueMon = P006H2_A864CueMon[0];
            A867CueMov = P006H2_A867CueMov[0];
            A860CueDsc = P006H2_A860CueDsc[0];
            A91CueCod = P006H2_A91CueCod[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A91CueCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A860CueDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = A867CueMov;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = A864CueMon;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = A859CueCos;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A109CueGasDebe, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A110CueGasHaber, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "";
            if ( A873CueSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "ACTIVO";
            }
            else if ( A873CueSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "INACTIVO";
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
         if ( StringUtil.StrCmp(AV33Session.Get("Contabilidad.PlanCuentasWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.PlanCuentasWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Contabilidad.PlanCuentasWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV125GXV2 = 1;
         while ( AV125GXV2 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV125GXV2));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV37TFCueCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV38TFCueCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV39TFCueDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV40TFCueDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUEMOV_SEL") == 0 )
            {
               AV82TFCueMov_Sel = (short)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUEMON_SEL") == 0 )
            {
               AV83TFCueMon_Sel = (short)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUECOS_SEL") == 0 )
            {
               AV84TFCueCos_Sel = (short)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUEGASDEBE") == 0 )
            {
               AV51TFCueGasDebe = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUEGASDEBE_SEL") == 0 )
            {
               AV52TFCueGasDebe_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUEGASHABER") == 0 )
            {
               AV53TFCueGasHaber = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUEGASHABER_SEL") == 0 )
            {
               AV54TFCueGasHaber_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUESTS_SEL") == 0 )
            {
               AV85TFCueSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV86TFCueSts_Sels.FromJSonString(AV85TFCueSts_SelsJson, null);
            }
            AV125GXV2 = (int)(AV125GXV2+1);
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
         AV79CueCod1 = "";
         AV20CueDsc1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV80CueCod2 = "";
         AV25CueDsc2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV81CueCod3 = "";
         AV30CueDsc3 = "";
         AV38TFCueCod_Sel = "";
         AV37TFCueCod = "";
         AV40TFCueDsc_Sel = "";
         AV39TFCueDsc = "";
         AV52TFCueGasDebe_Sel = "";
         AV51TFCueGasDebe = "";
         AV54TFCueGasHaber_Sel = "";
         AV53TFCueGasHaber = "";
         AV86TFCueSts_Sels = new GxSimpleCollection<short>();
         AV96Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 = "";
         AV98Contabilidad_plancuentaswwds_3_cuecod1 = "";
         AV99Contabilidad_plancuentaswwds_4_cuedsc1 = "";
         AV102Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 = "";
         AV104Contabilidad_plancuentaswwds_9_cuecod2 = "";
         AV105Contabilidad_plancuentaswwds_10_cuedsc2 = "";
         AV108Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 = "";
         AV110Contabilidad_plancuentaswwds_15_cuecod3 = "";
         AV111Contabilidad_plancuentaswwds_16_cuedsc3 = "";
         AV113Contabilidad_plancuentaswwds_18_tfcuecod = "";
         AV114Contabilidad_plancuentaswwds_19_tfcuecod_sel = "";
         AV115Contabilidad_plancuentaswwds_20_tfcuedsc = "";
         AV116Contabilidad_plancuentaswwds_21_tfcuedsc_sel = "";
         AV120Contabilidad_plancuentaswwds_25_tfcuegasdebe = "";
         AV121Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel = "";
         AV122Contabilidad_plancuentaswwds_27_tfcuegashaber = "";
         AV123Contabilidad_plancuentaswwds_28_tfcuegashaber_sel = "";
         AV124Contabilidad_plancuentaswwds_29_tfcuests_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV98Contabilidad_plancuentaswwds_3_cuecod1 = "";
         lV99Contabilidad_plancuentaswwds_4_cuedsc1 = "";
         lV104Contabilidad_plancuentaswwds_9_cuecod2 = "";
         lV105Contabilidad_plancuentaswwds_10_cuedsc2 = "";
         lV110Contabilidad_plancuentaswwds_15_cuecod3 = "";
         lV111Contabilidad_plancuentaswwds_16_cuedsc3 = "";
         lV113Contabilidad_plancuentaswwds_18_tfcuecod = "";
         lV115Contabilidad_plancuentaswwds_20_tfcuedsc = "";
         lV120Contabilidad_plancuentaswwds_25_tfcuegasdebe = "";
         lV122Contabilidad_plancuentaswwds_27_tfcuegashaber = "";
         A91CueCod = "";
         A860CueDsc = "";
         A109CueGasDebe = "";
         A110CueGasHaber = "";
         P006H2_A873CueSts = new short[1] ;
         P006H2_A110CueGasHaber = new string[] {""} ;
         P006H2_n110CueGasHaber = new bool[] {false} ;
         P006H2_A109CueGasDebe = new string[] {""} ;
         P006H2_n109CueGasDebe = new bool[] {false} ;
         P006H2_A859CueCos = new short[1] ;
         P006H2_A864CueMon = new short[1] ;
         P006H2_A867CueMov = new short[1] ;
         P006H2_A860CueDsc = new string[] {""} ;
         P006H2_A91CueCod = new string[] {""} ;
         GXt_char1 = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV85TFCueSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.plancuentaswwexport__default(),
            new Object[][] {
                new Object[] {
               P006H2_A873CueSts, P006H2_A110CueGasHaber, P006H2_n110CueGasHaber, P006H2_A109CueGasDebe, P006H2_n109CueGasDebe, P006H2_A859CueCos, P006H2_A864CueMon, P006H2_A867CueMov, P006H2_A860CueDsc, P006H2_A91CueCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV89CueMov1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV90CueMov2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV91CueMov3 ;
      private short AV82TFCueMov_Sel ;
      private short AV83TFCueMon_Sel ;
      private short AV84TFCueCos_Sel ;
      private short GXt_int2 ;
      private short AV87TFCueSts_Sel ;
      private short AV97Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ;
      private short AV100Contabilidad_plancuentaswwds_5_cuemov1 ;
      private short AV103Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ;
      private short AV106Contabilidad_plancuentaswwds_11_cuemov2 ;
      private short AV109Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ;
      private short AV112Contabilidad_plancuentaswwds_17_cuemov3 ;
      private short AV117Contabilidad_plancuentaswwds_22_tfcuemov_sel ;
      private short AV118Contabilidad_plancuentaswwds_23_tfcuemon_sel ;
      private short AV119Contabilidad_plancuentaswwds_24_tfcuecos_sel ;
      private short A873CueSts ;
      private short A867CueMov ;
      private short A864CueMon ;
      private short A859CueCos ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV94GXV1 ;
      private int AV124Contabilidad_plancuentaswwds_29_tfcuests_sels_Count ;
      private int AV125GXV2 ;
      private long AV88i ;
      private string AV79CueCod1 ;
      private string AV20CueDsc1 ;
      private string AV80CueCod2 ;
      private string AV25CueDsc2 ;
      private string AV81CueCod3 ;
      private string AV30CueDsc3 ;
      private string AV38TFCueCod_Sel ;
      private string AV37TFCueCod ;
      private string AV40TFCueDsc_Sel ;
      private string AV39TFCueDsc ;
      private string AV52TFCueGasDebe_Sel ;
      private string AV51TFCueGasDebe ;
      private string AV54TFCueGasHaber_Sel ;
      private string AV53TFCueGasHaber ;
      private string AV98Contabilidad_plancuentaswwds_3_cuecod1 ;
      private string AV99Contabilidad_plancuentaswwds_4_cuedsc1 ;
      private string AV104Contabilidad_plancuentaswwds_9_cuecod2 ;
      private string AV105Contabilidad_plancuentaswwds_10_cuedsc2 ;
      private string AV110Contabilidad_plancuentaswwds_15_cuecod3 ;
      private string AV111Contabilidad_plancuentaswwds_16_cuedsc3 ;
      private string AV113Contabilidad_plancuentaswwds_18_tfcuecod ;
      private string AV114Contabilidad_plancuentaswwds_19_tfcuecod_sel ;
      private string AV115Contabilidad_plancuentaswwds_20_tfcuedsc ;
      private string AV116Contabilidad_plancuentaswwds_21_tfcuedsc_sel ;
      private string AV120Contabilidad_plancuentaswwds_25_tfcuegasdebe ;
      private string AV121Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ;
      private string AV122Contabilidad_plancuentaswwds_27_tfcuegashaber ;
      private string AV123Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ;
      private string scmdbuf ;
      private string lV98Contabilidad_plancuentaswwds_3_cuecod1 ;
      private string lV99Contabilidad_plancuentaswwds_4_cuedsc1 ;
      private string lV104Contabilidad_plancuentaswwds_9_cuecod2 ;
      private string lV105Contabilidad_plancuentaswwds_10_cuedsc2 ;
      private string lV110Contabilidad_plancuentaswwds_15_cuecod3 ;
      private string lV111Contabilidad_plancuentaswwds_16_cuedsc3 ;
      private string lV113Contabilidad_plancuentaswwds_18_tfcuecod ;
      private string lV115Contabilidad_plancuentaswwds_20_tfcuedsc ;
      private string lV120Contabilidad_plancuentaswwds_25_tfcuegasdebe ;
      private string lV122Contabilidad_plancuentaswwds_27_tfcuegashaber ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string A109CueGasDebe ;
      private string A110CueGasHaber ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV101Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ;
      private bool AV107Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n110CueGasHaber ;
      private bool n109CueGasDebe ;
      private string AV85TFCueSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV96Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ;
      private string AV102Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ;
      private string AV108Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV86TFCueSts_Sels ;
      private GxSimpleCollection<short> AV124Contabilidad_plancuentaswwds_29_tfcuests_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006H2_A873CueSts ;
      private string[] P006H2_A110CueGasHaber ;
      private bool[] P006H2_n110CueGasHaber ;
      private string[] P006H2_A109CueGasDebe ;
      private bool[] P006H2_n109CueGasDebe ;
      private short[] P006H2_A859CueCos ;
      private short[] P006H2_A864CueMon ;
      private short[] P006H2_A867CueMov ;
      private string[] P006H2_A860CueDsc ;
      private string[] P006H2_A91CueCod ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
   }

   public class plancuentaswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006H2( IGxContext context ,
                                             short A873CueSts ,
                                             GxSimpleCollection<short> AV124Contabilidad_plancuentaswwds_29_tfcuests_sels ,
                                             string AV96Contabilidad_plancuentaswwds_1_dynamicfiltersselector1 ,
                                             short AV97Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 ,
                                             string AV98Contabilidad_plancuentaswwds_3_cuecod1 ,
                                             string AV99Contabilidad_plancuentaswwds_4_cuedsc1 ,
                                             bool AV101Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 ,
                                             string AV102Contabilidad_plancuentaswwds_7_dynamicfiltersselector2 ,
                                             short AV103Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 ,
                                             string AV104Contabilidad_plancuentaswwds_9_cuecod2 ,
                                             string AV105Contabilidad_plancuentaswwds_10_cuedsc2 ,
                                             bool AV107Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 ,
                                             string AV108Contabilidad_plancuentaswwds_13_dynamicfiltersselector3 ,
                                             short AV109Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 ,
                                             string AV110Contabilidad_plancuentaswwds_15_cuecod3 ,
                                             string AV111Contabilidad_plancuentaswwds_16_cuedsc3 ,
                                             string AV114Contabilidad_plancuentaswwds_19_tfcuecod_sel ,
                                             string AV113Contabilidad_plancuentaswwds_18_tfcuecod ,
                                             string AV116Contabilidad_plancuentaswwds_21_tfcuedsc_sel ,
                                             string AV115Contabilidad_plancuentaswwds_20_tfcuedsc ,
                                             short AV117Contabilidad_plancuentaswwds_22_tfcuemov_sel ,
                                             short AV118Contabilidad_plancuentaswwds_23_tfcuemon_sel ,
                                             short AV119Contabilidad_plancuentaswwds_24_tfcuecos_sel ,
                                             string AV121Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel ,
                                             string AV120Contabilidad_plancuentaswwds_25_tfcuegasdebe ,
                                             string AV123Contabilidad_plancuentaswwds_28_tfcuegashaber_sel ,
                                             string AV122Contabilidad_plancuentaswwds_27_tfcuegashaber ,
                                             int AV124Contabilidad_plancuentaswwds_29_tfcuests_sels_Count ,
                                             string A91CueCod ,
                                             string A860CueDsc ,
                                             short A867CueMov ,
                                             short AV100Contabilidad_plancuentaswwds_5_cuemov1 ,
                                             short AV106Contabilidad_plancuentaswwds_11_cuemov2 ,
                                             short AV112Contabilidad_plancuentaswwds_17_cuemov3 ,
                                             short A864CueMon ,
                                             short A859CueCos ,
                                             string A109CueGasDebe ,
                                             string A110CueGasHaber ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[23];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [CueSts], [CueGasHaber], [CueGasDebe], [CueCos], [CueMon], [CueMov], [CueDsc], [CueCod] FROM [CBPLANCUENTA]";
         if ( ( StringUtil.StrCmp(AV96Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV97Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV98Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV97Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Contabilidad_plancuentaswwds_3_cuecod1)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV98Contabilidad_plancuentaswwds_3_cuecod1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV97Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV99Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV97Contabilidad_plancuentaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Contabilidad_plancuentaswwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV99Contabilidad_plancuentaswwds_4_cuedsc1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV96Contabilidad_plancuentaswwds_1_dynamicfiltersselector1, "CUEMOV") == 0 )
         {
            AddWhere(sWhereString, "([CueMov] = @AV100Contabilidad_plancuentaswwds_5_cuemov1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV101Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV102Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV103Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV104Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV101Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV102Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV103Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Contabilidad_plancuentaswwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV104Contabilidad_plancuentaswwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV101Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV102Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV103Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV105Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV101Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV102Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV103Contabilidad_plancuentaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Contabilidad_plancuentaswwds_10_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV105Contabilidad_plancuentaswwds_10_cuedsc2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV101Contabilidad_plancuentaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV102Contabilidad_plancuentaswwds_7_dynamicfiltersselector2, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV106Contabilidad_plancuentaswwds_11_cuemov2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV107Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV109Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV110Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV107Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV109Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Contabilidad_plancuentaswwds_15_cuecod3)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like '%' + @lV110Contabilidad_plancuentaswwds_15_cuecod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV107Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV109Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV111Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV107Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV109Contabilidad_plancuentaswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Contabilidad_plancuentaswwds_16_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV111Contabilidad_plancuentaswwds_16_cuedsc3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV107Contabilidad_plancuentaswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Contabilidad_plancuentaswwds_13_dynamicfiltersselector3, "CUEMOV") == 0 ) )
         {
            AddWhere(sWhereString, "([CueMov] = @AV112Contabilidad_plancuentaswwds_17_cuemov3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_19_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabilidad_plancuentaswwds_18_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "([CueCod] like @lV113Contabilidad_plancuentaswwds_18_tfcuecod)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Contabilidad_plancuentaswwds_19_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "([CueCod] = @AV114Contabilidad_plancuentaswwds_19_tfcuecod_sel)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Contabilidad_plancuentaswwds_20_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "([CueDsc] like @lV115Contabilidad_plancuentaswwds_20_tfcuedsc)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Contabilidad_plancuentaswwds_21_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "([CueDsc] = @AV116Contabilidad_plancuentaswwds_21_tfcuedsc_sel)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV117Contabilidad_plancuentaswwds_22_tfcuemov_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMov] = 1)");
         }
         if ( AV117Contabilidad_plancuentaswwds_22_tfcuemov_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMov] = 0)");
         }
         if ( AV118Contabilidad_plancuentaswwds_23_tfcuemon_sel == 1 )
         {
            AddWhere(sWhereString, "([CueMon] = 1)");
         }
         if ( AV118Contabilidad_plancuentaswwds_23_tfcuemon_sel == 2 )
         {
            AddWhere(sWhereString, "([CueMon] = 0)");
         }
         if ( AV119Contabilidad_plancuentaswwds_24_tfcuecos_sel == 1 )
         {
            AddWhere(sWhereString, "([CueCos] = 1)");
         }
         if ( AV119Contabilidad_plancuentaswwds_24_tfcuecos_sel == 2 )
         {
            AddWhere(sWhereString, "([CueCos] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV121Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Contabilidad_plancuentaswwds_25_tfcuegasdebe)) ) )
         {
            AddWhere(sWhereString, "([CueGasDebe] like @lV120Contabilidad_plancuentaswwds_25_tfcuegasdebe)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)) )
         {
            AddWhere(sWhereString, "([CueGasDebe] = @AV121Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Contabilidad_plancuentaswwds_27_tfcuegashaber)) ) )
         {
            AddWhere(sWhereString, "([CueGasHaber] like @lV122Contabilidad_plancuentaswwds_27_tfcuegashaber)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)) )
         {
            AddWhere(sWhereString, "([CueGasHaber] = @AV123Contabilidad_plancuentaswwds_28_tfcuegashaber_sel)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV124Contabilidad_plancuentaswwds_29_tfcuests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV124Contabilidad_plancuentaswwds_29_tfcuests_sels, "[CueSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueMov]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueMov] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueMon]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueMon] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueCos]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueCos] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueGasDebe]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueGasDebe] DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueGasHaber]";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueGasHaber] DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CueSts]";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CueSts] DESC";
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
                     return conditional_P006H2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] );
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
          Object[] prmP006H2;
          prmP006H2 = new Object[] {
          new ParDef("@lV98Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV98Contabilidad_plancuentaswwds_3_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV99Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV99Contabilidad_plancuentaswwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@AV100Contabilidad_plancuentaswwds_5_cuemov1",GXType.Int16,1,0) ,
          new ParDef("@lV104Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV104Contabilidad_plancuentaswwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV105Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV105Contabilidad_plancuentaswwds_10_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@AV106Contabilidad_plancuentaswwds_11_cuemov2",GXType.Int16,1,0) ,
          new ParDef("@lV110Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV110Contabilidad_plancuentaswwds_15_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV111Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV111Contabilidad_plancuentaswwds_16_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV112Contabilidad_plancuentaswwds_17_cuemov3",GXType.Int16,1,0) ,
          new ParDef("@lV113Contabilidad_plancuentaswwds_18_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV114Contabilidad_plancuentaswwds_19_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV115Contabilidad_plancuentaswwds_20_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV116Contabilidad_plancuentaswwds_21_tfcuedsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV120Contabilidad_plancuentaswwds_25_tfcuegasdebe",GXType.NChar,15,0) ,
          new ParDef("@AV121Contabilidad_plancuentaswwds_26_tfcuegasdebe_sel",GXType.NChar,15,0) ,
          new ParDef("@lV122Contabilidad_plancuentaswwds_27_tfcuegashaber",GXType.NChar,15,0) ,
          new ParDef("@AV123Contabilidad_plancuentaswwds_28_tfcuegashaber_sel",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006H2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(3, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 100);
                ((string[]) buf[9])[0] = rslt.getString(8, 15);
                return;
       }
    }

 }

}
