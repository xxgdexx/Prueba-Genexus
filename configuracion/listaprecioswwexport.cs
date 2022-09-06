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
   public class listaprecioswwexport : GXProcedure
   {
      public listaprecioswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public listaprecioswwexport( IGxContext context )
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
         listaprecioswwexport objlistaprecioswwexport;
         objlistaprecioswwexport = new listaprecioswwexport();
         objlistaprecioswwexport.AV11Filename = "" ;
         objlistaprecioswwexport.AV12ErrorMessage = "" ;
         objlistaprecioswwexport.context.SetSubmitInitialConfig(context);
         objlistaprecioswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlistaprecioswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listaprecioswwexport)stateInfo).executePrivate();
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
         AV11Filename = "ListaPreciosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIPLPRODDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV20TipLProdDsc1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TipLProdDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Producto", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Producto", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20TipLProdDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIPLDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV21TipLDsc1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TipLDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21TipLDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TIPLPRODDSC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25TipLProdDsc2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TipLProdDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Producto", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Producto", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25TipLProdDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TIPLDSC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV26TipLDsc2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TipLDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26TipLDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "TIPLPRODDSC") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30TipLProdDsc3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TipLProdDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Producto", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Producto", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30TipLProdDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "TIPLDSC") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31TipLDsc3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TipLDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Lista", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV31TipLDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFTipLDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Lista") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TFTipLDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFTipLDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Lista") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45TFTipLDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFProdCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFProdCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProdCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFProdCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFTipLProdDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Producto") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFTipLProdDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTipLProdDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Producto") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFTipLProdDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFCliCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "R.U.C. Cliente") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV50TFCliCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFCliCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "R.U.C. Cliente") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFCliCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV47TFPreLis) && (Convert.ToDecimal(0)==AV48TFPreLis_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Precio") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV47TFPreLis);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV48TFPreLis_To);
         }
         if ( ! ( (DateTime.MinValue==AV53TFLisFech) && (DateTime.MinValue==AV54TFLisFech_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Fecha") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV53TFLisFech ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV54TFLisFech_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Tipo de Lista";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Codigo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Producto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "R.U.C. Cliente";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Precio";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Fecha";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV60Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV61Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV62Configuracion_listaprecioswwds_3_tiplproddsc1 = AV20TipLProdDsc1;
         AV63Configuracion_listaprecioswwds_4_tipldsc1 = AV21TipLDsc1;
         AV64Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV65Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV66Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV67Configuracion_listaprecioswwds_8_tiplproddsc2 = AV25TipLProdDsc2;
         AV68Configuracion_listaprecioswwds_9_tipldsc2 = AV26TipLDsc2;
         AV69Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV70Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV71Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV72Configuracion_listaprecioswwds_13_tiplproddsc3 = AV30TipLProdDsc3;
         AV73Configuracion_listaprecioswwds_14_tipldsc3 = AV31TipLDsc3;
         AV74Configuracion_listaprecioswwds_15_tftipldsc = AV45TFTipLDsc;
         AV75Configuracion_listaprecioswwds_16_tftipldsc_sel = AV46TFTipLDsc_Sel;
         AV76Configuracion_listaprecioswwds_17_tfprodcod = AV41TFProdCod;
         AV77Configuracion_listaprecioswwds_18_tfprodcod_sel = AV42TFProdCod_Sel;
         AV78Configuracion_listaprecioswwds_19_tftiplproddsc = AV43TFTipLProdDsc;
         AV79Configuracion_listaprecioswwds_20_tftiplproddsc_sel = AV44TFTipLProdDsc_Sel;
         AV80Configuracion_listaprecioswwds_21_tfclicod = AV49TFCliCod;
         AV81Configuracion_listaprecioswwds_22_tfclicod_sel = AV50TFCliCod_Sel;
         AV82Configuracion_listaprecioswwds_23_tfprelis = AV47TFPreLis;
         AV83Configuracion_listaprecioswwds_24_tfprelis_to = AV48TFPreLis_To;
         AV84Configuracion_listaprecioswwds_25_tflisfech = AV53TFLisFech;
         AV85Configuracion_listaprecioswwds_26_tflisfech_to = AV54TFLisFech_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV60Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                              AV61Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                              AV62Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                              AV63Configuracion_listaprecioswwds_4_tipldsc1 ,
                                              AV64Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                              AV65Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                              AV66Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                              AV67Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                              AV68Configuracion_listaprecioswwds_9_tipldsc2 ,
                                              AV69Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                              AV70Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                              AV71Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                              AV72Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                              AV73Configuracion_listaprecioswwds_14_tipldsc3 ,
                                              AV75Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                              AV74Configuracion_listaprecioswwds_15_tftipldsc ,
                                              AV77Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                              AV76Configuracion_listaprecioswwds_17_tfprodcod ,
                                              AV79Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                              AV78Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                              AV81Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                              AV80Configuracion_listaprecioswwds_21_tfclicod ,
                                              AV82Configuracion_listaprecioswwds_23_tfprelis ,
                                              AV83Configuracion_listaprecioswwds_24_tfprelis_to ,
                                              AV84Configuracion_listaprecioswwds_25_tflisfech ,
                                              AV85Configuracion_listaprecioswwds_26_tflisfech_to ,
                                              A1913TipLProdDsc ,
                                              A1912TipLDsc ,
                                              A28ProdCod ,
                                              A45CliCod ,
                                              A1651PreLis ,
                                              A1205LisFech ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV62Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
         lV62Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
         lV63Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
         lV63Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
         lV67Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
         lV67Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
         lV68Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
         lV68Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
         lV72Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
         lV72Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
         lV73Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
         lV73Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
         lV74Configuracion_listaprecioswwds_15_tftipldsc = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_listaprecioswwds_15_tftipldsc), 100, "%");
         lV76Configuracion_listaprecioswwds_17_tfprodcod = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_listaprecioswwds_17_tfprodcod), 15, "%");
         lV78Configuracion_listaprecioswwds_19_tftiplproddsc = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_listaprecioswwds_19_tftiplproddsc), 100, "%");
         lV80Configuracion_listaprecioswwds_21_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_listaprecioswwds_21_tfclicod), 20, "%");
         /* Using cursor P004J2 */
         pr_default.execute(0, new Object[] {lV62Configuracion_listaprecioswwds_3_tiplproddsc1, lV62Configuracion_listaprecioswwds_3_tiplproddsc1, lV63Configuracion_listaprecioswwds_4_tipldsc1, lV63Configuracion_listaprecioswwds_4_tipldsc1, lV67Configuracion_listaprecioswwds_8_tiplproddsc2, lV67Configuracion_listaprecioswwds_8_tiplproddsc2, lV68Configuracion_listaprecioswwds_9_tipldsc2, lV68Configuracion_listaprecioswwds_9_tipldsc2, lV72Configuracion_listaprecioswwds_13_tiplproddsc3, lV72Configuracion_listaprecioswwds_13_tiplproddsc3, lV73Configuracion_listaprecioswwds_14_tipldsc3, lV73Configuracion_listaprecioswwds_14_tipldsc3, lV74Configuracion_listaprecioswwds_15_tftipldsc, AV75Configuracion_listaprecioswwds_16_tftipldsc_sel, lV76Configuracion_listaprecioswwds_17_tfprodcod, AV77Configuracion_listaprecioswwds_18_tfprodcod_sel, lV78Configuracion_listaprecioswwds_19_tftiplproddsc, AV79Configuracion_listaprecioswwds_20_tftiplproddsc_sel, lV80Configuracion_listaprecioswwds_21_tfclicod, AV81Configuracion_listaprecioswwds_22_tfclicod_sel, AV82Configuracion_listaprecioswwds_23_tfprelis, AV83Configuracion_listaprecioswwds_24_tfprelis_to, AV84Configuracion_listaprecioswwds_25_tflisfech, AV85Configuracion_listaprecioswwds_26_tflisfech_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1205LisFech = P004J2_A1205LisFech[0];
            A1651PreLis = P004J2_A1651PreLis[0];
            A45CliCod = P004J2_A45CliCod[0];
            n45CliCod = P004J2_n45CliCod[0];
            A28ProdCod = P004J2_A28ProdCod[0];
            A1912TipLDsc = P004J2_A1912TipLDsc[0];
            A1913TipLProdDsc = P004J2_A1913TipLProdDsc[0];
            A202TipLCod = P004J2_A202TipLCod[0];
            A203TipLItem = P004J2_A203TipLItem[0];
            A1912TipLDsc = P004J2_A1912TipLDsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1912TipLDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A28ProdCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1913TipLProdDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A45CliCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = (double)(A1651PreLis);
            GXt_dtime3 = DateTimeUtil.ResetTime( A1205LisFech ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Date = GXt_dtime3;
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
         if ( StringUtil.StrCmp(AV33Session.Get("Configuracion.ListaPreciosWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.ListaPreciosWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Configuracion.ListaPreciosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV86GXV1 = 1;
         while ( AV86GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV86GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPLDSC") == 0 )
            {
               AV45TFTipLDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPLDSC_SEL") == 0 )
            {
               AV46TFTipLDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPRODCOD") == 0 )
            {
               AV41TFProdCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPRODCOD_SEL") == 0 )
            {
               AV42TFProdCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPLPRODDSC") == 0 )
            {
               AV43TFTipLProdDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPLPRODDSC_SEL") == 0 )
            {
               AV44TFTipLProdDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLICOD") == 0 )
            {
               AV49TFCliCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLICOD_SEL") == 0 )
            {
               AV50TFCliCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPRELIS") == 0 )
            {
               AV47TFPreLis = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV48TFPreLis_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFLISFECH") == 0 )
            {
               AV53TFLisFech = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Value, 2);
               AV54TFLisFech_To = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV86GXV1 = (int)(AV86GXV1+1);
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
         AV20TipLProdDsc1 = "";
         AV21TipLDsc1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25TipLProdDsc2 = "";
         AV26TipLDsc2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30TipLProdDsc3 = "";
         AV31TipLDsc3 = "";
         AV46TFTipLDsc_Sel = "";
         AV45TFTipLDsc = "";
         AV42TFProdCod_Sel = "";
         AV41TFProdCod = "";
         AV44TFTipLProdDsc_Sel = "";
         AV43TFTipLProdDsc = "";
         AV50TFCliCod_Sel = "";
         AV49TFCliCod = "";
         AV53TFLisFech = DateTime.MinValue;
         AV54TFLisFech_To = DateTime.MinValue;
         AV60Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = "";
         AV62Configuracion_listaprecioswwds_3_tiplproddsc1 = "";
         AV63Configuracion_listaprecioswwds_4_tipldsc1 = "";
         AV65Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = "";
         AV67Configuracion_listaprecioswwds_8_tiplproddsc2 = "";
         AV68Configuracion_listaprecioswwds_9_tipldsc2 = "";
         AV70Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = "";
         AV72Configuracion_listaprecioswwds_13_tiplproddsc3 = "";
         AV73Configuracion_listaprecioswwds_14_tipldsc3 = "";
         AV74Configuracion_listaprecioswwds_15_tftipldsc = "";
         AV75Configuracion_listaprecioswwds_16_tftipldsc_sel = "";
         AV76Configuracion_listaprecioswwds_17_tfprodcod = "";
         AV77Configuracion_listaprecioswwds_18_tfprodcod_sel = "";
         AV78Configuracion_listaprecioswwds_19_tftiplproddsc = "";
         AV79Configuracion_listaprecioswwds_20_tftiplproddsc_sel = "";
         AV80Configuracion_listaprecioswwds_21_tfclicod = "";
         AV81Configuracion_listaprecioswwds_22_tfclicod_sel = "";
         AV84Configuracion_listaprecioswwds_25_tflisfech = DateTime.MinValue;
         AV85Configuracion_listaprecioswwds_26_tflisfech_to = DateTime.MinValue;
         scmdbuf = "";
         lV62Configuracion_listaprecioswwds_3_tiplproddsc1 = "";
         lV63Configuracion_listaprecioswwds_4_tipldsc1 = "";
         lV67Configuracion_listaprecioswwds_8_tiplproddsc2 = "";
         lV68Configuracion_listaprecioswwds_9_tipldsc2 = "";
         lV72Configuracion_listaprecioswwds_13_tiplproddsc3 = "";
         lV73Configuracion_listaprecioswwds_14_tipldsc3 = "";
         lV74Configuracion_listaprecioswwds_15_tftipldsc = "";
         lV76Configuracion_listaprecioswwds_17_tfprodcod = "";
         lV78Configuracion_listaprecioswwds_19_tftiplproddsc = "";
         lV80Configuracion_listaprecioswwds_21_tfclicod = "";
         A1913TipLProdDsc = "";
         A1912TipLDsc = "";
         A28ProdCod = "";
         A45CliCod = "";
         A1205LisFech = DateTime.MinValue;
         P004J2_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         P004J2_A1651PreLis = new decimal[1] ;
         P004J2_A45CliCod = new string[] {""} ;
         P004J2_n45CliCod = new bool[] {false} ;
         P004J2_A28ProdCod = new string[] {""} ;
         P004J2_A1912TipLDsc = new string[] {""} ;
         P004J2_A1913TipLProdDsc = new string[] {""} ;
         P004J2_A202TipLCod = new int[1] ;
         P004J2_A203TipLItem = new int[1] ;
         GXt_char1 = "";
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.listaprecioswwexport__default(),
            new Object[][] {
                new Object[] {
               P004J2_A1205LisFech, P004J2_A1651PreLis, P004J2_A45CliCod, P004J2_n45CliCod, P004J2_A28ProdCod, P004J2_A1912TipLDsc, P004J2_A1913TipLProdDsc, P004J2_A202TipLCod, P004J2_A203TipLItem
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
      private short AV61Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ;
      private short AV66Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ;
      private short AV71Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A202TipLCod ;
      private int A203TipLItem ;
      private int AV86GXV1 ;
      private decimal AV47TFPreLis ;
      private decimal AV48TFPreLis_To ;
      private decimal AV82Configuracion_listaprecioswwds_23_tfprelis ;
      private decimal AV83Configuracion_listaprecioswwds_24_tfprelis_to ;
      private decimal A1651PreLis ;
      private string AV20TipLProdDsc1 ;
      private string AV21TipLDsc1 ;
      private string AV25TipLProdDsc2 ;
      private string AV26TipLDsc2 ;
      private string AV30TipLProdDsc3 ;
      private string AV31TipLDsc3 ;
      private string AV46TFTipLDsc_Sel ;
      private string AV45TFTipLDsc ;
      private string AV42TFProdCod_Sel ;
      private string AV41TFProdCod ;
      private string AV44TFTipLProdDsc_Sel ;
      private string AV43TFTipLProdDsc ;
      private string AV50TFCliCod_Sel ;
      private string AV49TFCliCod ;
      private string AV62Configuracion_listaprecioswwds_3_tiplproddsc1 ;
      private string AV63Configuracion_listaprecioswwds_4_tipldsc1 ;
      private string AV67Configuracion_listaprecioswwds_8_tiplproddsc2 ;
      private string AV68Configuracion_listaprecioswwds_9_tipldsc2 ;
      private string AV72Configuracion_listaprecioswwds_13_tiplproddsc3 ;
      private string AV73Configuracion_listaprecioswwds_14_tipldsc3 ;
      private string AV74Configuracion_listaprecioswwds_15_tftipldsc ;
      private string AV75Configuracion_listaprecioswwds_16_tftipldsc_sel ;
      private string AV76Configuracion_listaprecioswwds_17_tfprodcod ;
      private string AV77Configuracion_listaprecioswwds_18_tfprodcod_sel ;
      private string AV78Configuracion_listaprecioswwds_19_tftiplproddsc ;
      private string AV79Configuracion_listaprecioswwds_20_tftiplproddsc_sel ;
      private string AV80Configuracion_listaprecioswwds_21_tfclicod ;
      private string AV81Configuracion_listaprecioswwds_22_tfclicod_sel ;
      private string scmdbuf ;
      private string lV62Configuracion_listaprecioswwds_3_tiplproddsc1 ;
      private string lV63Configuracion_listaprecioswwds_4_tipldsc1 ;
      private string lV67Configuracion_listaprecioswwds_8_tiplproddsc2 ;
      private string lV68Configuracion_listaprecioswwds_9_tipldsc2 ;
      private string lV72Configuracion_listaprecioswwds_13_tiplproddsc3 ;
      private string lV73Configuracion_listaprecioswwds_14_tipldsc3 ;
      private string lV74Configuracion_listaprecioswwds_15_tftipldsc ;
      private string lV76Configuracion_listaprecioswwds_17_tfprodcod ;
      private string lV78Configuracion_listaprecioswwds_19_tftiplproddsc ;
      private string lV80Configuracion_listaprecioswwds_21_tfclicod ;
      private string A1913TipLProdDsc ;
      private string A1912TipLDsc ;
      private string A28ProdCod ;
      private string A45CliCod ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV53TFLisFech ;
      private DateTime AV54TFLisFech_To ;
      private DateTime AV84Configuracion_listaprecioswwds_25_tflisfech ;
      private DateTime AV85Configuracion_listaprecioswwds_26_tflisfech_to ;
      private DateTime A1205LisFech ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV64Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ;
      private bool AV69Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n45CliCod ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV60Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ;
      private string AV65Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ;
      private string AV70Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P004J2_A1205LisFech ;
      private decimal[] P004J2_A1651PreLis ;
      private string[] P004J2_A45CliCod ;
      private bool[] P004J2_n45CliCod ;
      private string[] P004J2_A28ProdCod ;
      private string[] P004J2_A1912TipLDsc ;
      private string[] P004J2_A1913TipLProdDsc ;
      private int[] P004J2_A202TipLCod ;
      private int[] P004J2_A203TipLItem ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
   }

   public class listaprecioswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004J2( IGxContext context ,
                                             string AV60Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                             short AV61Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                             string AV62Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                             string AV63Configuracion_listaprecioswwds_4_tipldsc1 ,
                                             bool AV64Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                             string AV65Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                             short AV66Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                             string AV67Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                             string AV68Configuracion_listaprecioswwds_9_tipldsc2 ,
                                             bool AV69Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                             string AV70Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                             short AV71Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                             string AV72Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                             string AV73Configuracion_listaprecioswwds_14_tipldsc3 ,
                                             string AV75Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                             string AV74Configuracion_listaprecioswwds_15_tftipldsc ,
                                             string AV77Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                             string AV76Configuracion_listaprecioswwds_17_tfprodcod ,
                                             string AV79Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                             string AV78Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                             string AV81Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                             string AV80Configuracion_listaprecioswwds_21_tfclicod ,
                                             decimal AV82Configuracion_listaprecioswwds_23_tfprelis ,
                                             decimal AV83Configuracion_listaprecioswwds_24_tfprelis_to ,
                                             DateTime AV84Configuracion_listaprecioswwds_25_tflisfech ,
                                             DateTime AV85Configuracion_listaprecioswwds_26_tflisfech_to ,
                                             string A1913TipLProdDsc ,
                                             string A1912TipLDsc ,
                                             string A28ProdCod ,
                                             string A45CliCod ,
                                             decimal A1651PreLis ,
                                             DateTime A1205LisFech ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[24];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[LisFech], T1.[PreLis], T1.[CliCod], T1.[ProdCod], T2.[TipLDsc], T1.[TipLProdDsc], T1.[TipLCod], T1.[TipLItem] FROM ([CLISTAPRECIOS] T1 INNER JOIN [CTIPOSLISTAS] T2 ON T2.[TipLCod] = T1.[TipLCod])";
         if ( ( StringUtil.StrCmp(AV60Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV61Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV62Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV61Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV62Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV61Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV63Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV61Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV63Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV64Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV66Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV67Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV64Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV66Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV67Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV64Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV66Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV68Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV64Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV66Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV68Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV69Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV71Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV72Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV69Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV71Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV72Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV69Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV71Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV73Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV69Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV71Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV73Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_listaprecioswwds_16_tftipldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_listaprecioswwds_15_tftipldsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV74Configuracion_listaprecioswwds_15_tftipldsc)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_listaprecioswwds_16_tftipldsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] = @AV75Configuracion_listaprecioswwds_16_tftipldsc_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_listaprecioswwds_18_tfprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_listaprecioswwds_17_tfprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV76Configuracion_listaprecioswwds_17_tfprodcod)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_listaprecioswwds_18_tfprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV77Configuracion_listaprecioswwds_18_tfprodcod_sel)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_listaprecioswwds_19_tftiplproddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV78Configuracion_listaprecioswwds_19_tftiplproddsc)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] = @AV79Configuracion_listaprecioswwds_20_tftiplproddsc_sel)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_listaprecioswwds_22_tfclicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_listaprecioswwds_21_tfclicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] like @lV80Configuracion_listaprecioswwds_21_tfclicod)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_listaprecioswwds_22_tfclicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV81Configuracion_listaprecioswwds_22_tfclicod_sel)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Configuracion_listaprecioswwds_23_tfprelis) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] >= @AV82Configuracion_listaprecioswwds_23_tfprelis)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV83Configuracion_listaprecioswwds_24_tfprelis_to) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] <= @AV83Configuracion_listaprecioswwds_24_tfprelis_to)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Configuracion_listaprecioswwds_25_tflisfech) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] >= @AV84Configuracion_listaprecioswwds_25_tflisfech)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Configuracion_listaprecioswwds_26_tflisfech_to) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] <= @AV85Configuracion_listaprecioswwds_26_tflisfech_to)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[TipLCod], T1.[ProdCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[TipLDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[TipLDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdCod]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdCod] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipLProdDsc]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipLProdDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CliCod]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CliCod] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PreLis]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PreLis] DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[LisFech]";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[LisFech] DESC";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004J2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (DateTime)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] );
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
          Object[] prmP004J2;
          prmP004J2 = new Object[] {
          new ParDef("@lV62Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_listaprecioswwds_15_tftipldsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Configuracion_listaprecioswwds_16_tftipldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_listaprecioswwds_17_tfprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV77Configuracion_listaprecioswwds_18_tfprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV78Configuracion_listaprecioswwds_19_tftiplproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV79Configuracion_listaprecioswwds_20_tftiplproddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_listaprecioswwds_21_tfclicod",GXType.NChar,20,0) ,
          new ParDef("@AV81Configuracion_listaprecioswwds_22_tfclicod_sel",GXType.NChar,20,0) ,
          new ParDef("@AV82Configuracion_listaprecioswwds_23_tfprelis",GXType.Decimal,15,4) ,
          new ParDef("@AV83Configuracion_listaprecioswwds_24_tfprelis_to",GXType.Decimal,15,4) ,
          new ParDef("@AV84Configuracion_listaprecioswwds_25_tflisfech",GXType.Date,8,0) ,
          new ParDef("@AV85Configuracion_listaprecioswwds_26_tflisfech_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004J2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 15);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
       }
    }

 }

}
