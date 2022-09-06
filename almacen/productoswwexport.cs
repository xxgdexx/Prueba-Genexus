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
namespace GeneXus.Programs.almacen {
   public class productoswwexport : GXProcedure
   {
      public productoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public productoswwexport( IGxContext context )
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
         productoswwexport objproductoswwexport;
         objproductoswwexport = new productoswwexport();
         objproductoswwexport.AV11Filename = "" ;
         objproductoswwexport.AV12ErrorMessage = "" ;
         objproductoswwexport.context.SetSubmitInitialConfig(context);
         objproductoswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objproductoswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productoswwexport)stateInfo).executePrivate();
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
         AV11Filename = "ProductosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV38GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PRODDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV20ProdDsc1 = AV38GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ProdDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripcion producto", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripcion producto", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20ProdDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PRODCUENTAVDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV21ProdCuentaVDsc1 = AV38GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ProdCuentaVDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Venta", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Venta", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21ProdCuentaVDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PRODCUENTACDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV22ProdCuentaCDsc1 = AV38GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ProdCuentaCDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Compra", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Compra", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ProdCuentaCDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PRODCUENTAADSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV23ProdCuentaADsc1 = AV38GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ProdCuentaADsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Almacen", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Almacen", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23ProdCuentaADsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "LINDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV103LinDsc1 = AV38GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103LinDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripcion de Linea", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripcion de Linea", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV103LinDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV38GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PRODDSC") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV27ProdDsc2 = AV38GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ProdDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripcion producto", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripcion producto", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27ProdDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PRODCUENTAVDSC") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV28ProdCuentaVDsc2 = AV38GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ProdCuentaVDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Venta", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Venta", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ProdCuentaVDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PRODCUENTACDSC") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV29ProdCuentaCDsc2 = AV38GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ProdCuentaCDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Compra", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Compra", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29ProdCuentaCDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PRODCUENTAADSC") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV30ProdCuentaADsc2 = AV38GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ProdCuentaADsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Almacen", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Almacen", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30ProdCuentaADsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "LINDSC") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV104LinDsc2 = AV38GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104LinDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripcion de Linea", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripcion de Linea", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV104LinDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV31DynamicFiltersEnabled3 = true;
                  AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(3));
                  AV32DynamicFiltersSelector3 = AV38GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "PRODDSC") == 0 )
                  {
                     AV33DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV34ProdDsc3 = AV38GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ProdDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV33DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripcion producto", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV33DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripcion producto", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34ProdDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "PRODCUENTAVDSC") == 0 )
                  {
                     AV33DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV35ProdCuentaVDsc3 = AV38GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35ProdCuentaVDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV33DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Venta", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV33DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Venta", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35ProdCuentaVDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "PRODCUENTACDSC") == 0 )
                  {
                     AV33DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV36ProdCuentaCDsc3 = AV38GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36ProdCuentaCDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV33DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Compra", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV33DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Compra", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36ProdCuentaCDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "PRODCUENTAADSC") == 0 )
                  {
                     AV33DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV37ProdCuentaADsc3 = AV38GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37ProdCuentaADsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV33DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Almacen", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV33DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción Cuenta Almacen", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37ProdCuentaADsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "LINDSC") == 0 )
                  {
                     AV33DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV105LinDsc3 = AV38GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105LinDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV33DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripcion de Linea", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV33DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripcion de Linea", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV105LinDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFProdCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Producto") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFProdCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFProdCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Producto") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFProdCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV45TFLinCod) && (0==AV46TFLinCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo de Linea") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV45TFLinCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV46TFLinCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProdDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripcion producto") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48TFProdDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFProdDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripcion producto") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFProdDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV49TFSublCod) && (0==AV50TFSublCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sub Linea") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV49TFSublCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV50TFSublCod_To;
         }
         if ( ! ( (0==AV51TFFamCod) && (0==AV52TFFamCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Familia") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV51TFFamCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV52TFFamCod_To;
         }
         if ( ! ( (0==AV53TFUniCod) && (0==AV54TFUniCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Unidad Medida") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV53TFUniCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV54TFUniCod_To;
         }
         if ( ! ( (0==AV97TFProdVta_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Destinado Venta") ;
            AV13CellRow = GXt_int2;
            if ( AV97TFProdVta_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV97TFProdVta_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV98TFProdCmp_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Destinado Compra") ;
            AV13CellRow = GXt_int2;
            if ( AV98TFProdCmp_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV98TFProdCmp_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV59TFProdPeso) && (Convert.ToDecimal(0)==AV60TFProdPeso_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Peso producto") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV59TFProdPeso);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV60TFProdPeso_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV61TFProdVolumen) && (Convert.ToDecimal(0)==AV62TFProdVolumen_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Volumen producto") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV61TFProdVolumen);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV62TFProdVolumen_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV63TFProdStkMax) && (Convert.ToDecimal(0)==AV64TFProdStkMax_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Stock Maximo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV63TFProdStkMax);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV64TFProdStkMax_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV65TFProdStkMin) && (Convert.ToDecimal(0)==AV66TFProdStkMin_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Stock Minimo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV65TFProdStkMin);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV66TFProdStkMin_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFProdRef1_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 1") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV68TFProdRef1_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV67TFProdRef1)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 1") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV67TFProdRef1, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV70TFProdRef2_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 2") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV70TFProdRef2_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV69TFProdRef2)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 2") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV69TFProdRef2, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV72TFProdRef3_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 3") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV72TFProdRef3_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV71TFProdRef3)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 3") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV71TFProdRef3, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV74TFProdRef4_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 4") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV74TFProdRef4_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV73TFProdRef4)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 4") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV73TFProdRef4, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV76TFProdRef5_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 5") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV76TFProdRef5_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV75TFProdRef5)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 5") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV75TFProdRef5, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV78TFProdRef6_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 6") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV78TFProdRef6_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV77TFProdRef6)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 6") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV77TFProdRef6, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV80TFProdRef7_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 7") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV80TFProdRef7_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV79TFProdRef7)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 7") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV79TFProdRef7, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV82TFProdRef8_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 8") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV82TFProdRef8_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV81TFProdRef8)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 8") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV81TFProdRef8, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV84TFProdRef9_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 9") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV84TFProdRef9_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV83TFProdRef9)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 9") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV83TFProdRef9, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV86TFProdRef10_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 10") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV86TFProdRef10_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV85TFProdRef10)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Referencia 10") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV85TFProdRef10, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV100TFProdSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Situacion") ;
            AV13CellRow = GXt_int2;
            AV102i = 1;
            AV108GXV1 = 1;
            while ( AV108GXV1 <= AV100TFProdSts_Sels.Count )
            {
               AV101TFProdSts_Sel = (short)(AV100TFProdSts_Sels.GetNumeric(AV108GXV1));
               if ( AV102i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV101TFProdSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV101TFProdSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV102i = (long)(AV102i+1);
               AV108GXV1 = (int)(AV108GXV1+1);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV89TFProdCosto) && (Convert.ToDecimal(0)==AV90TFProdCosto_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Ult. Costo MN") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV89TFProdCosto);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV90TFProdCosto_To);
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Codigo Producto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Codigo de Linea";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Descripcion producto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Codigo Sub Linea";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Codigo Familia";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Codigo Unidad Medida";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Destinado Venta";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Destinado Compra";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "Peso producto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Text = "Volumen producto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Text = "Stock Maximo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+11, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+11, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+11, 1, 1).Text = "Stock Minimo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+12, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+12, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+12, 1, 1).Text = "Foto Producto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+13, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+13, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+13, 1, 1).Text = "Referencia 1";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+14, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+14, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+14, 1, 1).Text = "Referencia 2";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+15, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+15, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+15, 1, 1).Text = "Referencia 3";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+16, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+16, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+16, 1, 1).Text = "Referencia 4";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+17, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+17, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+17, 1, 1).Text = "Referencia 5";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+18, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+18, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+18, 1, 1).Text = "Referencia 6";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+19, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+19, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+19, 1, 1).Text = "Referencia 7";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+20, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+20, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+20, 1, 1).Text = "Referencia 8";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+21, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+21, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+21, 1, 1).Text = "Referencia 9";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+22, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+22, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+22, 1, 1).Text = "Referencia 10";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+23, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+23, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+23, 1, 1).Text = "Situacion";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+24, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+24, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+24, 1, 1).Text = "Ult. Costo MN";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV110Almacen_productoswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV111Almacen_productoswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV112Almacen_productoswwds_3_proddsc1 = AV20ProdDsc1;
         AV113Almacen_productoswwds_4_prodcuentavdsc1 = AV21ProdCuentaVDsc1;
         AV114Almacen_productoswwds_5_prodcuentacdsc1 = AV22ProdCuentaCDsc1;
         AV115Almacen_productoswwds_6_prodcuentaadsc1 = AV23ProdCuentaADsc1;
         AV116Almacen_productoswwds_7_lindsc1 = AV103LinDsc1;
         AV117Almacen_productoswwds_8_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV118Almacen_productoswwds_9_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV119Almacen_productoswwds_10_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV120Almacen_productoswwds_11_proddsc2 = AV27ProdDsc2;
         AV121Almacen_productoswwds_12_prodcuentavdsc2 = AV28ProdCuentaVDsc2;
         AV122Almacen_productoswwds_13_prodcuentacdsc2 = AV29ProdCuentaCDsc2;
         AV123Almacen_productoswwds_14_prodcuentaadsc2 = AV30ProdCuentaADsc2;
         AV124Almacen_productoswwds_15_lindsc2 = AV104LinDsc2;
         AV125Almacen_productoswwds_16_dynamicfiltersenabled3 = AV31DynamicFiltersEnabled3;
         AV126Almacen_productoswwds_17_dynamicfiltersselector3 = AV32DynamicFiltersSelector3;
         AV127Almacen_productoswwds_18_dynamicfiltersoperator3 = AV33DynamicFiltersOperator3;
         AV128Almacen_productoswwds_19_proddsc3 = AV34ProdDsc3;
         AV129Almacen_productoswwds_20_prodcuentavdsc3 = AV35ProdCuentaVDsc3;
         AV130Almacen_productoswwds_21_prodcuentacdsc3 = AV36ProdCuentaCDsc3;
         AV131Almacen_productoswwds_22_prodcuentaadsc3 = AV37ProdCuentaADsc3;
         AV132Almacen_productoswwds_23_lindsc3 = AV105LinDsc3;
         AV133Almacen_productoswwds_24_tfprodcod = AV43TFProdCod;
         AV134Almacen_productoswwds_25_tfprodcod_sel = AV44TFProdCod_Sel;
         AV135Almacen_productoswwds_26_tflincod = AV45TFLinCod;
         AV136Almacen_productoswwds_27_tflincod_to = AV46TFLinCod_To;
         AV137Almacen_productoswwds_28_tfproddsc = AV47TFProdDsc;
         AV138Almacen_productoswwds_29_tfproddsc_sel = AV48TFProdDsc_Sel;
         AV139Almacen_productoswwds_30_tfsublcod = AV49TFSublCod;
         AV140Almacen_productoswwds_31_tfsublcod_to = AV50TFSublCod_To;
         AV141Almacen_productoswwds_32_tffamcod = AV51TFFamCod;
         AV142Almacen_productoswwds_33_tffamcod_to = AV52TFFamCod_To;
         AV143Almacen_productoswwds_34_tfunicod = AV53TFUniCod;
         AV144Almacen_productoswwds_35_tfunicod_to = AV54TFUniCod_To;
         AV145Almacen_productoswwds_36_tfprodvta_sel = AV97TFProdVta_Sel;
         AV146Almacen_productoswwds_37_tfprodcmp_sel = AV98TFProdCmp_Sel;
         AV147Almacen_productoswwds_38_tfprodpeso = AV59TFProdPeso;
         AV148Almacen_productoswwds_39_tfprodpeso_to = AV60TFProdPeso_To;
         AV149Almacen_productoswwds_40_tfprodvolumen = AV61TFProdVolumen;
         AV150Almacen_productoswwds_41_tfprodvolumen_to = AV62TFProdVolumen_To;
         AV151Almacen_productoswwds_42_tfprodstkmax = AV63TFProdStkMax;
         AV152Almacen_productoswwds_43_tfprodstkmax_to = AV64TFProdStkMax_To;
         AV153Almacen_productoswwds_44_tfprodstkmin = AV65TFProdStkMin;
         AV154Almacen_productoswwds_45_tfprodstkmin_to = AV66TFProdStkMin_To;
         AV155Almacen_productoswwds_46_tfprodref1 = AV67TFProdRef1;
         AV156Almacen_productoswwds_47_tfprodref1_sel = AV68TFProdRef1_Sel;
         AV157Almacen_productoswwds_48_tfprodref2 = AV69TFProdRef2;
         AV158Almacen_productoswwds_49_tfprodref2_sel = AV70TFProdRef2_Sel;
         AV159Almacen_productoswwds_50_tfprodref3 = AV71TFProdRef3;
         AV160Almacen_productoswwds_51_tfprodref3_sel = AV72TFProdRef3_Sel;
         AV161Almacen_productoswwds_52_tfprodref4 = AV73TFProdRef4;
         AV162Almacen_productoswwds_53_tfprodref4_sel = AV74TFProdRef4_Sel;
         AV163Almacen_productoswwds_54_tfprodref5 = AV75TFProdRef5;
         AV164Almacen_productoswwds_55_tfprodref5_sel = AV76TFProdRef5_Sel;
         AV165Almacen_productoswwds_56_tfprodref6 = AV77TFProdRef6;
         AV166Almacen_productoswwds_57_tfprodref6_sel = AV78TFProdRef6_Sel;
         AV167Almacen_productoswwds_58_tfprodref7 = AV79TFProdRef7;
         AV168Almacen_productoswwds_59_tfprodref7_sel = AV80TFProdRef7_Sel;
         AV169Almacen_productoswwds_60_tfprodref8 = AV81TFProdRef8;
         AV170Almacen_productoswwds_61_tfprodref8_sel = AV82TFProdRef8_Sel;
         AV171Almacen_productoswwds_62_tfprodref9 = AV83TFProdRef9;
         AV172Almacen_productoswwds_63_tfprodref9_sel = AV84TFProdRef9_Sel;
         AV173Almacen_productoswwds_64_tfprodref10 = AV85TFProdRef10;
         AV174Almacen_productoswwds_65_tfprodref10_sel = AV86TFProdRef10_Sel;
         AV175Almacen_productoswwds_66_tfprodsts_sels = AV100TFProdSts_Sels;
         AV176Almacen_productoswwds_67_tfprodcosto = AV89TFProdCosto;
         AV177Almacen_productoswwds_68_tfprodcosto_to = AV90TFProdCosto_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1718ProdSts ,
                                              AV175Almacen_productoswwds_66_tfprodsts_sels ,
                                              AV110Almacen_productoswwds_1_dynamicfiltersselector1 ,
                                              AV111Almacen_productoswwds_2_dynamicfiltersoperator1 ,
                                              AV112Almacen_productoswwds_3_proddsc1 ,
                                              AV113Almacen_productoswwds_4_prodcuentavdsc1 ,
                                              AV114Almacen_productoswwds_5_prodcuentacdsc1 ,
                                              AV115Almacen_productoswwds_6_prodcuentaadsc1 ,
                                              AV116Almacen_productoswwds_7_lindsc1 ,
                                              AV117Almacen_productoswwds_8_dynamicfiltersenabled2 ,
                                              AV118Almacen_productoswwds_9_dynamicfiltersselector2 ,
                                              AV119Almacen_productoswwds_10_dynamicfiltersoperator2 ,
                                              AV120Almacen_productoswwds_11_proddsc2 ,
                                              AV121Almacen_productoswwds_12_prodcuentavdsc2 ,
                                              AV122Almacen_productoswwds_13_prodcuentacdsc2 ,
                                              AV123Almacen_productoswwds_14_prodcuentaadsc2 ,
                                              AV124Almacen_productoswwds_15_lindsc2 ,
                                              AV125Almacen_productoswwds_16_dynamicfiltersenabled3 ,
                                              AV126Almacen_productoswwds_17_dynamicfiltersselector3 ,
                                              AV127Almacen_productoswwds_18_dynamicfiltersoperator3 ,
                                              AV128Almacen_productoswwds_19_proddsc3 ,
                                              AV129Almacen_productoswwds_20_prodcuentavdsc3 ,
                                              AV130Almacen_productoswwds_21_prodcuentacdsc3 ,
                                              AV131Almacen_productoswwds_22_prodcuentaadsc3 ,
                                              AV132Almacen_productoswwds_23_lindsc3 ,
                                              AV134Almacen_productoswwds_25_tfprodcod_sel ,
                                              AV133Almacen_productoswwds_24_tfprodcod ,
                                              AV135Almacen_productoswwds_26_tflincod ,
                                              AV136Almacen_productoswwds_27_tflincod_to ,
                                              AV138Almacen_productoswwds_29_tfproddsc_sel ,
                                              AV137Almacen_productoswwds_28_tfproddsc ,
                                              AV139Almacen_productoswwds_30_tfsublcod ,
                                              AV140Almacen_productoswwds_31_tfsublcod_to ,
                                              AV141Almacen_productoswwds_32_tffamcod ,
                                              AV142Almacen_productoswwds_33_tffamcod_to ,
                                              AV143Almacen_productoswwds_34_tfunicod ,
                                              AV144Almacen_productoswwds_35_tfunicod_to ,
                                              AV145Almacen_productoswwds_36_tfprodvta_sel ,
                                              AV146Almacen_productoswwds_37_tfprodcmp_sel ,
                                              AV147Almacen_productoswwds_38_tfprodpeso ,
                                              AV148Almacen_productoswwds_39_tfprodpeso_to ,
                                              AV149Almacen_productoswwds_40_tfprodvolumen ,
                                              AV150Almacen_productoswwds_41_tfprodvolumen_to ,
                                              AV151Almacen_productoswwds_42_tfprodstkmax ,
                                              AV152Almacen_productoswwds_43_tfprodstkmax_to ,
                                              AV153Almacen_productoswwds_44_tfprodstkmin ,
                                              AV154Almacen_productoswwds_45_tfprodstkmin_to ,
                                              AV156Almacen_productoswwds_47_tfprodref1_sel ,
                                              AV155Almacen_productoswwds_46_tfprodref1 ,
                                              AV158Almacen_productoswwds_49_tfprodref2_sel ,
                                              AV157Almacen_productoswwds_48_tfprodref2 ,
                                              AV160Almacen_productoswwds_51_tfprodref3_sel ,
                                              AV159Almacen_productoswwds_50_tfprodref3 ,
                                              AV162Almacen_productoswwds_53_tfprodref4_sel ,
                                              AV161Almacen_productoswwds_52_tfprodref4 ,
                                              AV164Almacen_productoswwds_55_tfprodref5_sel ,
                                              AV163Almacen_productoswwds_54_tfprodref5 ,
                                              AV166Almacen_productoswwds_57_tfprodref6_sel ,
                                              AV165Almacen_productoswwds_56_tfprodref6 ,
                                              AV168Almacen_productoswwds_59_tfprodref7_sel ,
                                              AV167Almacen_productoswwds_58_tfprodref7 ,
                                              AV170Almacen_productoswwds_61_tfprodref8_sel ,
                                              AV169Almacen_productoswwds_60_tfprodref8 ,
                                              AV172Almacen_productoswwds_63_tfprodref9_sel ,
                                              AV171Almacen_productoswwds_62_tfprodref9 ,
                                              AV174Almacen_productoswwds_65_tfprodref10_sel ,
                                              AV173Almacen_productoswwds_64_tfprodref10 ,
                                              AV175Almacen_productoswwds_66_tfprodsts_sels.Count ,
                                              AV176Almacen_productoswwds_67_tfprodcosto ,
                                              AV177Almacen_productoswwds_68_tfprodcosto_to ,
                                              A55ProdDsc ,
                                              A1686ProdCuentaVDsc ,
                                              A1685ProdCuentaCDsc ,
                                              A1684ProdCuentaADsc ,
                                              A1153LinDsc ,
                                              A28ProdCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A49UniCod ,
                                              A1724ProdVta ,
                                              A1679ProdCmp ,
                                              A1702ProdPeso ,
                                              A1723ProdVolumen ,
                                              A1716ProdStkMax ,
                                              A1717ProdStkMin ,
                                              A1705ProdRef1 ,
                                              A1707ProdRef2 ,
                                              A1708ProdRef3 ,
                                              A1709ProdRef4 ,
                                              A1710ProdRef5 ,
                                              A1711ProdRef6 ,
                                              A1712ProdRef7 ,
                                              A1713ProdRef8 ,
                                              A1714ProdRef9 ,
                                              A1706ProdRef10 ,
                                              A1681ProdCosto ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV112Almacen_productoswwds_3_proddsc1 = StringUtil.PadR( StringUtil.RTrim( AV112Almacen_productoswwds_3_proddsc1), 100, "%");
         lV112Almacen_productoswwds_3_proddsc1 = StringUtil.PadR( StringUtil.RTrim( AV112Almacen_productoswwds_3_proddsc1), 100, "%");
         lV113Almacen_productoswwds_4_prodcuentavdsc1 = StringUtil.PadR( StringUtil.RTrim( AV113Almacen_productoswwds_4_prodcuentavdsc1), 100, "%");
         lV113Almacen_productoswwds_4_prodcuentavdsc1 = StringUtil.PadR( StringUtil.RTrim( AV113Almacen_productoswwds_4_prodcuentavdsc1), 100, "%");
         lV114Almacen_productoswwds_5_prodcuentacdsc1 = StringUtil.PadR( StringUtil.RTrim( AV114Almacen_productoswwds_5_prodcuentacdsc1), 100, "%");
         lV114Almacen_productoswwds_5_prodcuentacdsc1 = StringUtil.PadR( StringUtil.RTrim( AV114Almacen_productoswwds_5_prodcuentacdsc1), 100, "%");
         lV115Almacen_productoswwds_6_prodcuentaadsc1 = StringUtil.PadR( StringUtil.RTrim( AV115Almacen_productoswwds_6_prodcuentaadsc1), 100, "%");
         lV115Almacen_productoswwds_6_prodcuentaadsc1 = StringUtil.PadR( StringUtil.RTrim( AV115Almacen_productoswwds_6_prodcuentaadsc1), 100, "%");
         lV116Almacen_productoswwds_7_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV116Almacen_productoswwds_7_lindsc1), 100, "%");
         lV116Almacen_productoswwds_7_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV116Almacen_productoswwds_7_lindsc1), 100, "%");
         lV120Almacen_productoswwds_11_proddsc2 = StringUtil.PadR( StringUtil.RTrim( AV120Almacen_productoswwds_11_proddsc2), 100, "%");
         lV120Almacen_productoswwds_11_proddsc2 = StringUtil.PadR( StringUtil.RTrim( AV120Almacen_productoswwds_11_proddsc2), 100, "%");
         lV121Almacen_productoswwds_12_prodcuentavdsc2 = StringUtil.PadR( StringUtil.RTrim( AV121Almacen_productoswwds_12_prodcuentavdsc2), 100, "%");
         lV121Almacen_productoswwds_12_prodcuentavdsc2 = StringUtil.PadR( StringUtil.RTrim( AV121Almacen_productoswwds_12_prodcuentavdsc2), 100, "%");
         lV122Almacen_productoswwds_13_prodcuentacdsc2 = StringUtil.PadR( StringUtil.RTrim( AV122Almacen_productoswwds_13_prodcuentacdsc2), 100, "%");
         lV122Almacen_productoswwds_13_prodcuentacdsc2 = StringUtil.PadR( StringUtil.RTrim( AV122Almacen_productoswwds_13_prodcuentacdsc2), 100, "%");
         lV123Almacen_productoswwds_14_prodcuentaadsc2 = StringUtil.PadR( StringUtil.RTrim( AV123Almacen_productoswwds_14_prodcuentaadsc2), 100, "%");
         lV123Almacen_productoswwds_14_prodcuentaadsc2 = StringUtil.PadR( StringUtil.RTrim( AV123Almacen_productoswwds_14_prodcuentaadsc2), 100, "%");
         lV124Almacen_productoswwds_15_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV124Almacen_productoswwds_15_lindsc2), 100, "%");
         lV124Almacen_productoswwds_15_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV124Almacen_productoswwds_15_lindsc2), 100, "%");
         lV128Almacen_productoswwds_19_proddsc3 = StringUtil.PadR( StringUtil.RTrim( AV128Almacen_productoswwds_19_proddsc3), 100, "%");
         lV128Almacen_productoswwds_19_proddsc3 = StringUtil.PadR( StringUtil.RTrim( AV128Almacen_productoswwds_19_proddsc3), 100, "%");
         lV129Almacen_productoswwds_20_prodcuentavdsc3 = StringUtil.PadR( StringUtil.RTrim( AV129Almacen_productoswwds_20_prodcuentavdsc3), 100, "%");
         lV129Almacen_productoswwds_20_prodcuentavdsc3 = StringUtil.PadR( StringUtil.RTrim( AV129Almacen_productoswwds_20_prodcuentavdsc3), 100, "%");
         lV130Almacen_productoswwds_21_prodcuentacdsc3 = StringUtil.PadR( StringUtil.RTrim( AV130Almacen_productoswwds_21_prodcuentacdsc3), 100, "%");
         lV130Almacen_productoswwds_21_prodcuentacdsc3 = StringUtil.PadR( StringUtil.RTrim( AV130Almacen_productoswwds_21_prodcuentacdsc3), 100, "%");
         lV131Almacen_productoswwds_22_prodcuentaadsc3 = StringUtil.PadR( StringUtil.RTrim( AV131Almacen_productoswwds_22_prodcuentaadsc3), 100, "%");
         lV131Almacen_productoswwds_22_prodcuentaadsc3 = StringUtil.PadR( StringUtil.RTrim( AV131Almacen_productoswwds_22_prodcuentaadsc3), 100, "%");
         lV132Almacen_productoswwds_23_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV132Almacen_productoswwds_23_lindsc3), 100, "%");
         lV132Almacen_productoswwds_23_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV132Almacen_productoswwds_23_lindsc3), 100, "%");
         lV133Almacen_productoswwds_24_tfprodcod = StringUtil.PadR( StringUtil.RTrim( AV133Almacen_productoswwds_24_tfprodcod), 15, "%");
         lV137Almacen_productoswwds_28_tfproddsc = StringUtil.PadR( StringUtil.RTrim( AV137Almacen_productoswwds_28_tfproddsc), 100, "%");
         lV155Almacen_productoswwds_46_tfprodref1 = StringUtil.PadR( StringUtil.RTrim( AV155Almacen_productoswwds_46_tfprodref1), 20, "%");
         lV157Almacen_productoswwds_48_tfprodref2 = StringUtil.PadR( StringUtil.RTrim( AV157Almacen_productoswwds_48_tfprodref2), 20, "%");
         lV159Almacen_productoswwds_50_tfprodref3 = StringUtil.PadR( StringUtil.RTrim( AV159Almacen_productoswwds_50_tfprodref3), 20, "%");
         lV161Almacen_productoswwds_52_tfprodref4 = StringUtil.PadR( StringUtil.RTrim( AV161Almacen_productoswwds_52_tfprodref4), 20, "%");
         lV163Almacen_productoswwds_54_tfprodref5 = StringUtil.PadR( StringUtil.RTrim( AV163Almacen_productoswwds_54_tfprodref5), 20, "%");
         lV165Almacen_productoswwds_56_tfprodref6 = StringUtil.PadR( StringUtil.RTrim( AV165Almacen_productoswwds_56_tfprodref6), 20, "%");
         lV167Almacen_productoswwds_58_tfprodref7 = StringUtil.PadR( StringUtil.RTrim( AV167Almacen_productoswwds_58_tfprodref7), 20, "%");
         lV169Almacen_productoswwds_60_tfprodref8 = StringUtil.PadR( StringUtil.RTrim( AV169Almacen_productoswwds_60_tfprodref8), 20, "%");
         lV171Almacen_productoswwds_62_tfprodref9 = StringUtil.PadR( StringUtil.RTrim( AV171Almacen_productoswwds_62_tfprodref9), 20, "%");
         lV173Almacen_productoswwds_64_tfprodref10 = StringUtil.PadR( StringUtil.RTrim( AV173Almacen_productoswwds_64_tfprodref10), 20, "%");
         /* Using cursor P00DU2 */
         pr_default.execute(0, new Object[] {lV112Almacen_productoswwds_3_proddsc1, lV112Almacen_productoswwds_3_proddsc1, lV113Almacen_productoswwds_4_prodcuentavdsc1, lV113Almacen_productoswwds_4_prodcuentavdsc1, lV114Almacen_productoswwds_5_prodcuentacdsc1, lV114Almacen_productoswwds_5_prodcuentacdsc1, lV115Almacen_productoswwds_6_prodcuentaadsc1, lV115Almacen_productoswwds_6_prodcuentaadsc1, lV116Almacen_productoswwds_7_lindsc1, lV116Almacen_productoswwds_7_lindsc1, lV120Almacen_productoswwds_11_proddsc2, lV120Almacen_productoswwds_11_proddsc2, lV121Almacen_productoswwds_12_prodcuentavdsc2, lV121Almacen_productoswwds_12_prodcuentavdsc2, lV122Almacen_productoswwds_13_prodcuentacdsc2, lV122Almacen_productoswwds_13_prodcuentacdsc2, lV123Almacen_productoswwds_14_prodcuentaadsc2, lV123Almacen_productoswwds_14_prodcuentaadsc2, lV124Almacen_productoswwds_15_lindsc2, lV124Almacen_productoswwds_15_lindsc2, lV128Almacen_productoswwds_19_proddsc3, lV128Almacen_productoswwds_19_proddsc3, lV129Almacen_productoswwds_20_prodcuentavdsc3, lV129Almacen_productoswwds_20_prodcuentavdsc3, lV130Almacen_productoswwds_21_prodcuentacdsc3, lV130Almacen_productoswwds_21_prodcuentacdsc3, lV131Almacen_productoswwds_22_prodcuentaadsc3, lV131Almacen_productoswwds_22_prodcuentaadsc3, lV132Almacen_productoswwds_23_lindsc3, lV132Almacen_productoswwds_23_lindsc3, lV133Almacen_productoswwds_24_tfprodcod, AV134Almacen_productoswwds_25_tfprodcod_sel, AV135Almacen_productoswwds_26_tflincod, AV136Almacen_productoswwds_27_tflincod_to, lV137Almacen_productoswwds_28_tfproddsc, AV138Almacen_productoswwds_29_tfproddsc_sel, AV139Almacen_productoswwds_30_tfsublcod, AV140Almacen_productoswwds_31_tfsublcod_to, AV141Almacen_productoswwds_32_tffamcod, AV142Almacen_productoswwds_33_tffamcod_to, AV143Almacen_productoswwds_34_tfunicod, AV144Almacen_productoswwds_35_tfunicod_to, AV147Almacen_productoswwds_38_tfprodpeso, AV148Almacen_productoswwds_39_tfprodpeso_to, AV149Almacen_productoswwds_40_tfprodvolumen, AV150Almacen_productoswwds_41_tfprodvolumen_to, AV151Almacen_productoswwds_42_tfprodstkmax, AV152Almacen_productoswwds_43_tfprodstkmax_to, AV153Almacen_productoswwds_44_tfprodstkmin, AV154Almacen_productoswwds_45_tfprodstkmin_to, lV155Almacen_productoswwds_46_tfprodref1, AV156Almacen_productoswwds_47_tfprodref1_sel, lV157Almacen_productoswwds_48_tfprodref2, AV158Almacen_productoswwds_49_tfprodref2_sel, lV159Almacen_productoswwds_50_tfprodref3, AV160Almacen_productoswwds_51_tfprodref3_sel, lV161Almacen_productoswwds_52_tfprodref4, AV162Almacen_productoswwds_53_tfprodref4_sel, lV163Almacen_productoswwds_54_tfprodref5, AV164Almacen_productoswwds_55_tfprodref5_sel, lV165Almacen_productoswwds_56_tfprodref6, AV166Almacen_productoswwds_57_tfprodref6_sel, lV167Almacen_productoswwds_58_tfprodref7, AV168Almacen_productoswwds_59_tfprodref7_sel, lV169Almacen_productoswwds_60_tfprodref8, AV170Almacen_productoswwds_61_tfprodref8_sel, lV171Almacen_productoswwds_62_tfprodref9, AV172Almacen_productoswwds_63_tfprodref9_sel, lV173Almacen_productoswwds_64_tfprodref10, AV174Almacen_productoswwds_65_tfprodref10_sel, AV176Almacen_productoswwds_67_tfprodcosto, AV177Almacen_productoswwds_68_tfprodcosto_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A48ProdCuentaV = P00DU2_A48ProdCuentaV[0];
            n48ProdCuentaV = P00DU2_n48ProdCuentaV[0];
            A53ProdCuentaC = P00DU2_A53ProdCuentaC[0];
            n53ProdCuentaC = P00DU2_n53ProdCuentaC[0];
            A54ProdCuentaA = P00DU2_A54ProdCuentaA[0];
            n54ProdCuentaA = P00DU2_n54ProdCuentaA[0];
            A1681ProdCosto = P00DU2_A1681ProdCosto[0];
            A1718ProdSts = P00DU2_A1718ProdSts[0];
            A1706ProdRef10 = P00DU2_A1706ProdRef10[0];
            A1714ProdRef9 = P00DU2_A1714ProdRef9[0];
            A1713ProdRef8 = P00DU2_A1713ProdRef8[0];
            A1712ProdRef7 = P00DU2_A1712ProdRef7[0];
            A1711ProdRef6 = P00DU2_A1711ProdRef6[0];
            A1710ProdRef5 = P00DU2_A1710ProdRef5[0];
            A1709ProdRef4 = P00DU2_A1709ProdRef4[0];
            A1708ProdRef3 = P00DU2_A1708ProdRef3[0];
            A1707ProdRef2 = P00DU2_A1707ProdRef2[0];
            A1705ProdRef1 = P00DU2_A1705ProdRef1[0];
            A1717ProdStkMin = P00DU2_A1717ProdStkMin[0];
            A1716ProdStkMax = P00DU2_A1716ProdStkMax[0];
            A1723ProdVolumen = P00DU2_A1723ProdVolumen[0];
            A1702ProdPeso = P00DU2_A1702ProdPeso[0];
            A1679ProdCmp = P00DU2_A1679ProdCmp[0];
            A1724ProdVta = P00DU2_A1724ProdVta[0];
            A49UniCod = P00DU2_A49UniCod[0];
            A50FamCod = P00DU2_A50FamCod[0];
            n50FamCod = P00DU2_n50FamCod[0];
            A51SublCod = P00DU2_A51SublCod[0];
            n51SublCod = P00DU2_n51SublCod[0];
            A52LinCod = P00DU2_A52LinCod[0];
            A28ProdCod = P00DU2_A28ProdCod[0];
            A1153LinDsc = P00DU2_A1153LinDsc[0];
            A1684ProdCuentaADsc = P00DU2_A1684ProdCuentaADsc[0];
            A1685ProdCuentaCDsc = P00DU2_A1685ProdCuentaCDsc[0];
            A1686ProdCuentaVDsc = P00DU2_A1686ProdCuentaVDsc[0];
            A55ProdDsc = P00DU2_A55ProdDsc[0];
            A1686ProdCuentaVDsc = P00DU2_A1686ProdCuentaVDsc[0];
            A1685ProdCuentaCDsc = P00DU2_A1685ProdCuentaCDsc[0];
            A1684ProdCuentaADsc = P00DU2_A1684ProdCuentaADsc[0];
            A1153LinDsc = P00DU2_A1153LinDsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A28ProdCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = A52LinCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A55ProdDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = A51SublCod;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = A50FamCod;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Number = A49UniCod;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Number = A1724ProdVta;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Number = A1679ProdCmp;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Number = (double)(A1702ProdPeso);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Number = (double)(A1723ProdVolumen);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Number = (double)(A1716ProdStkMax);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+11, 1, 1).Number = (double)(A1717ProdStkMin);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+12, 1, 1).Text = "";
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1705ProdRef1, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+13, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1707ProdRef2, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+14, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1708ProdRef3, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+15, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1709ProdRef4, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+16, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1710ProdRef5, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+17, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1711ProdRef6, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+18, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1712ProdRef7, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+19, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1713ProdRef8, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+20, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1714ProdRef9, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+21, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1706ProdRef10, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+22, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+23, 1, 1).Text = "";
            if ( A1718ProdSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+23, 1, 1).Text = "ACTIVO";
            }
            else if ( A1718ProdSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+23, 1, 1).Text = "INACTIVO";
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+24, 1, 1).Number = (double)(A1681ProdCosto);
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
         if ( StringUtil.StrCmp(AV39Session.Get("Almacen.ProductosWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Almacen.ProductosWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("Almacen.ProductosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV41GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV41GridState.gxTpr_Ordereddsc;
         AV178GXV2 = 1;
         while ( AV178GXV2 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV178GXV2));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODCOD") == 0 )
            {
               AV43TFProdCod = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODCOD_SEL") == 0 )
            {
               AV44TFProdCod_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFLINCOD") == 0 )
            {
               AV45TFLinCod = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
               AV46TFLinCod_To = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODDSC") == 0 )
            {
               AV47TFProdDsc = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODDSC_SEL") == 0 )
            {
               AV48TFProdDsc_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSUBLCOD") == 0 )
            {
               AV49TFSublCod = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
               AV50TFSublCod_To = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFFAMCOD") == 0 )
            {
               AV51TFFamCod = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
               AV52TFFamCod_To = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFUNICOD") == 0 )
            {
               AV53TFUniCod = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
               AV54TFUniCod_To = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODVTA_SEL") == 0 )
            {
               AV97TFProdVta_Sel = (short)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODCMP_SEL") == 0 )
            {
               AV98TFProdCmp_Sel = (short)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODPESO") == 0 )
            {
               AV59TFProdPeso = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, ".");
               AV60TFProdPeso_To = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODVOLUMEN") == 0 )
            {
               AV61TFProdVolumen = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, ".");
               AV62TFProdVolumen_To = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODSTKMAX") == 0 )
            {
               AV63TFProdStkMax = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, ".");
               AV64TFProdStkMax_To = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODSTKMIN") == 0 )
            {
               AV65TFProdStkMin = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, ".");
               AV66TFProdStkMin_To = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF1") == 0 )
            {
               AV67TFProdRef1 = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF1_SEL") == 0 )
            {
               AV68TFProdRef1_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF2") == 0 )
            {
               AV69TFProdRef2 = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF2_SEL") == 0 )
            {
               AV70TFProdRef2_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF3") == 0 )
            {
               AV71TFProdRef3 = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF3_SEL") == 0 )
            {
               AV72TFProdRef3_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF4") == 0 )
            {
               AV73TFProdRef4 = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF4_SEL") == 0 )
            {
               AV74TFProdRef4_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF5") == 0 )
            {
               AV75TFProdRef5 = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF5_SEL") == 0 )
            {
               AV76TFProdRef5_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF6") == 0 )
            {
               AV77TFProdRef6 = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF6_SEL") == 0 )
            {
               AV78TFProdRef6_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF7") == 0 )
            {
               AV79TFProdRef7 = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF7_SEL") == 0 )
            {
               AV80TFProdRef7_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF8") == 0 )
            {
               AV81TFProdRef8 = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF8_SEL") == 0 )
            {
               AV82TFProdRef8_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF9") == 0 )
            {
               AV83TFProdRef9 = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF9_SEL") == 0 )
            {
               AV84TFProdRef9_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF10") == 0 )
            {
               AV85TFProdRef10 = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODREF10_SEL") == 0 )
            {
               AV86TFProdRef10_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODSTS_SEL") == 0 )
            {
               AV99TFProdSts_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV100TFProdSts_Sels.FromJSonString(AV99TFProdSts_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPRODCOSTO") == 0 )
            {
               AV89TFProdCosto = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, ".");
               AV90TFProdCosto_To = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV178GXV2 = (int)(AV178GXV2+1);
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
         AV41GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV20ProdDsc1 = "";
         AV21ProdCuentaVDsc1 = "";
         AV22ProdCuentaCDsc1 = "";
         AV23ProdCuentaADsc1 = "";
         AV103LinDsc1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV27ProdDsc2 = "";
         AV28ProdCuentaVDsc2 = "";
         AV29ProdCuentaCDsc2 = "";
         AV30ProdCuentaADsc2 = "";
         AV104LinDsc2 = "";
         AV32DynamicFiltersSelector3 = "";
         AV34ProdDsc3 = "";
         AV35ProdCuentaVDsc3 = "";
         AV36ProdCuentaCDsc3 = "";
         AV37ProdCuentaADsc3 = "";
         AV105LinDsc3 = "";
         AV44TFProdCod_Sel = "";
         AV43TFProdCod = "";
         AV48TFProdDsc_Sel = "";
         AV47TFProdDsc = "";
         AV68TFProdRef1_Sel = "";
         AV67TFProdRef1 = "";
         AV70TFProdRef2_Sel = "";
         AV69TFProdRef2 = "";
         AV72TFProdRef3_Sel = "";
         AV71TFProdRef3 = "";
         AV74TFProdRef4_Sel = "";
         AV73TFProdRef4 = "";
         AV76TFProdRef5_Sel = "";
         AV75TFProdRef5 = "";
         AV78TFProdRef6_Sel = "";
         AV77TFProdRef6 = "";
         AV80TFProdRef7_Sel = "";
         AV79TFProdRef7 = "";
         AV82TFProdRef8_Sel = "";
         AV81TFProdRef8 = "";
         AV84TFProdRef9_Sel = "";
         AV83TFProdRef9 = "";
         AV86TFProdRef10_Sel = "";
         AV85TFProdRef10 = "";
         AV100TFProdSts_Sels = new GxSimpleCollection<short>();
         AV110Almacen_productoswwds_1_dynamicfiltersselector1 = "";
         AV112Almacen_productoswwds_3_proddsc1 = "";
         AV113Almacen_productoswwds_4_prodcuentavdsc1 = "";
         AV114Almacen_productoswwds_5_prodcuentacdsc1 = "";
         AV115Almacen_productoswwds_6_prodcuentaadsc1 = "";
         AV116Almacen_productoswwds_7_lindsc1 = "";
         AV118Almacen_productoswwds_9_dynamicfiltersselector2 = "";
         AV120Almacen_productoswwds_11_proddsc2 = "";
         AV121Almacen_productoswwds_12_prodcuentavdsc2 = "";
         AV122Almacen_productoswwds_13_prodcuentacdsc2 = "";
         AV123Almacen_productoswwds_14_prodcuentaadsc2 = "";
         AV124Almacen_productoswwds_15_lindsc2 = "";
         AV126Almacen_productoswwds_17_dynamicfiltersselector3 = "";
         AV128Almacen_productoswwds_19_proddsc3 = "";
         AV129Almacen_productoswwds_20_prodcuentavdsc3 = "";
         AV130Almacen_productoswwds_21_prodcuentacdsc3 = "";
         AV131Almacen_productoswwds_22_prodcuentaadsc3 = "";
         AV132Almacen_productoswwds_23_lindsc3 = "";
         AV133Almacen_productoswwds_24_tfprodcod = "";
         AV134Almacen_productoswwds_25_tfprodcod_sel = "";
         AV137Almacen_productoswwds_28_tfproddsc = "";
         AV138Almacen_productoswwds_29_tfproddsc_sel = "";
         AV155Almacen_productoswwds_46_tfprodref1 = "";
         AV156Almacen_productoswwds_47_tfprodref1_sel = "";
         AV157Almacen_productoswwds_48_tfprodref2 = "";
         AV158Almacen_productoswwds_49_tfprodref2_sel = "";
         AV159Almacen_productoswwds_50_tfprodref3 = "";
         AV160Almacen_productoswwds_51_tfprodref3_sel = "";
         AV161Almacen_productoswwds_52_tfprodref4 = "";
         AV162Almacen_productoswwds_53_tfprodref4_sel = "";
         AV163Almacen_productoswwds_54_tfprodref5 = "";
         AV164Almacen_productoswwds_55_tfprodref5_sel = "";
         AV165Almacen_productoswwds_56_tfprodref6 = "";
         AV166Almacen_productoswwds_57_tfprodref6_sel = "";
         AV167Almacen_productoswwds_58_tfprodref7 = "";
         AV168Almacen_productoswwds_59_tfprodref7_sel = "";
         AV169Almacen_productoswwds_60_tfprodref8 = "";
         AV170Almacen_productoswwds_61_tfprodref8_sel = "";
         AV171Almacen_productoswwds_62_tfprodref9 = "";
         AV172Almacen_productoswwds_63_tfprodref9_sel = "";
         AV173Almacen_productoswwds_64_tfprodref10 = "";
         AV174Almacen_productoswwds_65_tfprodref10_sel = "";
         AV175Almacen_productoswwds_66_tfprodsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV112Almacen_productoswwds_3_proddsc1 = "";
         lV113Almacen_productoswwds_4_prodcuentavdsc1 = "";
         lV114Almacen_productoswwds_5_prodcuentacdsc1 = "";
         lV115Almacen_productoswwds_6_prodcuentaadsc1 = "";
         lV116Almacen_productoswwds_7_lindsc1 = "";
         lV120Almacen_productoswwds_11_proddsc2 = "";
         lV121Almacen_productoswwds_12_prodcuentavdsc2 = "";
         lV122Almacen_productoswwds_13_prodcuentacdsc2 = "";
         lV123Almacen_productoswwds_14_prodcuentaadsc2 = "";
         lV124Almacen_productoswwds_15_lindsc2 = "";
         lV128Almacen_productoswwds_19_proddsc3 = "";
         lV129Almacen_productoswwds_20_prodcuentavdsc3 = "";
         lV130Almacen_productoswwds_21_prodcuentacdsc3 = "";
         lV131Almacen_productoswwds_22_prodcuentaadsc3 = "";
         lV132Almacen_productoswwds_23_lindsc3 = "";
         lV133Almacen_productoswwds_24_tfprodcod = "";
         lV137Almacen_productoswwds_28_tfproddsc = "";
         lV155Almacen_productoswwds_46_tfprodref1 = "";
         lV157Almacen_productoswwds_48_tfprodref2 = "";
         lV159Almacen_productoswwds_50_tfprodref3 = "";
         lV161Almacen_productoswwds_52_tfprodref4 = "";
         lV163Almacen_productoswwds_54_tfprodref5 = "";
         lV165Almacen_productoswwds_56_tfprodref6 = "";
         lV167Almacen_productoswwds_58_tfprodref7 = "";
         lV169Almacen_productoswwds_60_tfprodref8 = "";
         lV171Almacen_productoswwds_62_tfprodref9 = "";
         lV173Almacen_productoswwds_64_tfprodref10 = "";
         A55ProdDsc = "";
         A1686ProdCuentaVDsc = "";
         A1685ProdCuentaCDsc = "";
         A1684ProdCuentaADsc = "";
         A1153LinDsc = "";
         A28ProdCod = "";
         A1705ProdRef1 = "";
         A1707ProdRef2 = "";
         A1708ProdRef3 = "";
         A1709ProdRef4 = "";
         A1710ProdRef5 = "";
         A1711ProdRef6 = "";
         A1712ProdRef7 = "";
         A1713ProdRef8 = "";
         A1714ProdRef9 = "";
         A1706ProdRef10 = "";
         P00DU2_A48ProdCuentaV = new string[] {""} ;
         P00DU2_n48ProdCuentaV = new bool[] {false} ;
         P00DU2_A53ProdCuentaC = new string[] {""} ;
         P00DU2_n53ProdCuentaC = new bool[] {false} ;
         P00DU2_A54ProdCuentaA = new string[] {""} ;
         P00DU2_n54ProdCuentaA = new bool[] {false} ;
         P00DU2_A1681ProdCosto = new decimal[1] ;
         P00DU2_A1718ProdSts = new short[1] ;
         P00DU2_A1706ProdRef10 = new string[] {""} ;
         P00DU2_A1714ProdRef9 = new string[] {""} ;
         P00DU2_A1713ProdRef8 = new string[] {""} ;
         P00DU2_A1712ProdRef7 = new string[] {""} ;
         P00DU2_A1711ProdRef6 = new string[] {""} ;
         P00DU2_A1710ProdRef5 = new string[] {""} ;
         P00DU2_A1709ProdRef4 = new string[] {""} ;
         P00DU2_A1708ProdRef3 = new string[] {""} ;
         P00DU2_A1707ProdRef2 = new string[] {""} ;
         P00DU2_A1705ProdRef1 = new string[] {""} ;
         P00DU2_A1717ProdStkMin = new decimal[1] ;
         P00DU2_A1716ProdStkMax = new decimal[1] ;
         P00DU2_A1723ProdVolumen = new decimal[1] ;
         P00DU2_A1702ProdPeso = new decimal[1] ;
         P00DU2_A1679ProdCmp = new short[1] ;
         P00DU2_A1724ProdVta = new short[1] ;
         P00DU2_A49UniCod = new int[1] ;
         P00DU2_A50FamCod = new int[1] ;
         P00DU2_n50FamCod = new bool[] {false} ;
         P00DU2_A51SublCod = new int[1] ;
         P00DU2_n51SublCod = new bool[] {false} ;
         P00DU2_A52LinCod = new int[1] ;
         P00DU2_A28ProdCod = new string[] {""} ;
         P00DU2_A1153LinDsc = new string[] {""} ;
         P00DU2_A1684ProdCuentaADsc = new string[] {""} ;
         P00DU2_A1685ProdCuentaCDsc = new string[] {""} ;
         P00DU2_A1686ProdCuentaVDsc = new string[] {""} ;
         P00DU2_A55ProdDsc = new string[] {""} ;
         A48ProdCuentaV = "";
         A53ProdCuentaC = "";
         A54ProdCuentaA = "";
         GXt_char1 = "";
         AV39Session = context.GetSession();
         AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV99TFProdSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.productoswwexport__default(),
            new Object[][] {
                new Object[] {
               P00DU2_A48ProdCuentaV, P00DU2_n48ProdCuentaV, P00DU2_A53ProdCuentaC, P00DU2_n53ProdCuentaC, P00DU2_A54ProdCuentaA, P00DU2_n54ProdCuentaA, P00DU2_A1681ProdCosto, P00DU2_A1718ProdSts, P00DU2_A1706ProdRef10, P00DU2_A1714ProdRef9,
               P00DU2_A1713ProdRef8, P00DU2_A1712ProdRef7, P00DU2_A1711ProdRef6, P00DU2_A1710ProdRef5, P00DU2_A1709ProdRef4, P00DU2_A1708ProdRef3, P00DU2_A1707ProdRef2, P00DU2_A1705ProdRef1, P00DU2_A1717ProdStkMin, P00DU2_A1716ProdStkMax,
               P00DU2_A1723ProdVolumen, P00DU2_A1702ProdPeso, P00DU2_A1679ProdCmp, P00DU2_A1724ProdVta, P00DU2_A49UniCod, P00DU2_A50FamCod, P00DU2_n50FamCod, P00DU2_A51SublCod, P00DU2_n51SublCod, P00DU2_A52LinCod,
               P00DU2_A28ProdCod, P00DU2_A1153LinDsc, P00DU2_A1684ProdCuentaADsc, P00DU2_A1685ProdCuentaCDsc, P00DU2_A1686ProdCuentaVDsc, P00DU2_A55ProdDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV33DynamicFiltersOperator3 ;
      private short AV97TFProdVta_Sel ;
      private short AV98TFProdCmp_Sel ;
      private short AV101TFProdSts_Sel ;
      private short GXt_int2 ;
      private short AV111Almacen_productoswwds_2_dynamicfiltersoperator1 ;
      private short AV119Almacen_productoswwds_10_dynamicfiltersoperator2 ;
      private short AV127Almacen_productoswwds_18_dynamicfiltersoperator3 ;
      private short AV145Almacen_productoswwds_36_tfprodvta_sel ;
      private short AV146Almacen_productoswwds_37_tfprodcmp_sel ;
      private short A1718ProdSts ;
      private short A1724ProdVta ;
      private short A1679ProdCmp ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV45TFLinCod ;
      private int AV46TFLinCod_To ;
      private int AV49TFSublCod ;
      private int AV50TFSublCod_To ;
      private int AV51TFFamCod ;
      private int AV52TFFamCod_To ;
      private int AV53TFUniCod ;
      private int AV54TFUniCod_To ;
      private int AV108GXV1 ;
      private int AV135Almacen_productoswwds_26_tflincod ;
      private int AV136Almacen_productoswwds_27_tflincod_to ;
      private int AV139Almacen_productoswwds_30_tfsublcod ;
      private int AV140Almacen_productoswwds_31_tfsublcod_to ;
      private int AV141Almacen_productoswwds_32_tffamcod ;
      private int AV142Almacen_productoswwds_33_tffamcod_to ;
      private int AV143Almacen_productoswwds_34_tfunicod ;
      private int AV144Almacen_productoswwds_35_tfunicod_to ;
      private int AV175Almacen_productoswwds_66_tfprodsts_sels_Count ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A49UniCod ;
      private int AV178GXV2 ;
      private long AV102i ;
      private decimal AV59TFProdPeso ;
      private decimal AV60TFProdPeso_To ;
      private decimal AV61TFProdVolumen ;
      private decimal AV62TFProdVolumen_To ;
      private decimal AV63TFProdStkMax ;
      private decimal AV64TFProdStkMax_To ;
      private decimal AV65TFProdStkMin ;
      private decimal AV66TFProdStkMin_To ;
      private decimal AV89TFProdCosto ;
      private decimal AV90TFProdCosto_To ;
      private decimal AV147Almacen_productoswwds_38_tfprodpeso ;
      private decimal AV148Almacen_productoswwds_39_tfprodpeso_to ;
      private decimal AV149Almacen_productoswwds_40_tfprodvolumen ;
      private decimal AV150Almacen_productoswwds_41_tfprodvolumen_to ;
      private decimal AV151Almacen_productoswwds_42_tfprodstkmax ;
      private decimal AV152Almacen_productoswwds_43_tfprodstkmax_to ;
      private decimal AV153Almacen_productoswwds_44_tfprodstkmin ;
      private decimal AV154Almacen_productoswwds_45_tfprodstkmin_to ;
      private decimal AV176Almacen_productoswwds_67_tfprodcosto ;
      private decimal AV177Almacen_productoswwds_68_tfprodcosto_to ;
      private decimal A1702ProdPeso ;
      private decimal A1723ProdVolumen ;
      private decimal A1716ProdStkMax ;
      private decimal A1717ProdStkMin ;
      private decimal A1681ProdCosto ;
      private string AV20ProdDsc1 ;
      private string AV21ProdCuentaVDsc1 ;
      private string AV22ProdCuentaCDsc1 ;
      private string AV23ProdCuentaADsc1 ;
      private string AV103LinDsc1 ;
      private string AV27ProdDsc2 ;
      private string AV28ProdCuentaVDsc2 ;
      private string AV29ProdCuentaCDsc2 ;
      private string AV30ProdCuentaADsc2 ;
      private string AV104LinDsc2 ;
      private string AV34ProdDsc3 ;
      private string AV35ProdCuentaVDsc3 ;
      private string AV36ProdCuentaCDsc3 ;
      private string AV37ProdCuentaADsc3 ;
      private string AV105LinDsc3 ;
      private string AV44TFProdCod_Sel ;
      private string AV43TFProdCod ;
      private string AV48TFProdDsc_Sel ;
      private string AV47TFProdDsc ;
      private string AV68TFProdRef1_Sel ;
      private string AV67TFProdRef1 ;
      private string AV70TFProdRef2_Sel ;
      private string AV69TFProdRef2 ;
      private string AV72TFProdRef3_Sel ;
      private string AV71TFProdRef3 ;
      private string AV74TFProdRef4_Sel ;
      private string AV73TFProdRef4 ;
      private string AV76TFProdRef5_Sel ;
      private string AV75TFProdRef5 ;
      private string AV78TFProdRef6_Sel ;
      private string AV77TFProdRef6 ;
      private string AV80TFProdRef7_Sel ;
      private string AV79TFProdRef7 ;
      private string AV82TFProdRef8_Sel ;
      private string AV81TFProdRef8 ;
      private string AV84TFProdRef9_Sel ;
      private string AV83TFProdRef9 ;
      private string AV86TFProdRef10_Sel ;
      private string AV85TFProdRef10 ;
      private string AV112Almacen_productoswwds_3_proddsc1 ;
      private string AV113Almacen_productoswwds_4_prodcuentavdsc1 ;
      private string AV114Almacen_productoswwds_5_prodcuentacdsc1 ;
      private string AV115Almacen_productoswwds_6_prodcuentaadsc1 ;
      private string AV116Almacen_productoswwds_7_lindsc1 ;
      private string AV120Almacen_productoswwds_11_proddsc2 ;
      private string AV121Almacen_productoswwds_12_prodcuentavdsc2 ;
      private string AV122Almacen_productoswwds_13_prodcuentacdsc2 ;
      private string AV123Almacen_productoswwds_14_prodcuentaadsc2 ;
      private string AV124Almacen_productoswwds_15_lindsc2 ;
      private string AV128Almacen_productoswwds_19_proddsc3 ;
      private string AV129Almacen_productoswwds_20_prodcuentavdsc3 ;
      private string AV130Almacen_productoswwds_21_prodcuentacdsc3 ;
      private string AV131Almacen_productoswwds_22_prodcuentaadsc3 ;
      private string AV132Almacen_productoswwds_23_lindsc3 ;
      private string AV133Almacen_productoswwds_24_tfprodcod ;
      private string AV134Almacen_productoswwds_25_tfprodcod_sel ;
      private string AV137Almacen_productoswwds_28_tfproddsc ;
      private string AV138Almacen_productoswwds_29_tfproddsc_sel ;
      private string AV155Almacen_productoswwds_46_tfprodref1 ;
      private string AV156Almacen_productoswwds_47_tfprodref1_sel ;
      private string AV157Almacen_productoswwds_48_tfprodref2 ;
      private string AV158Almacen_productoswwds_49_tfprodref2_sel ;
      private string AV159Almacen_productoswwds_50_tfprodref3 ;
      private string AV160Almacen_productoswwds_51_tfprodref3_sel ;
      private string AV161Almacen_productoswwds_52_tfprodref4 ;
      private string AV162Almacen_productoswwds_53_tfprodref4_sel ;
      private string AV163Almacen_productoswwds_54_tfprodref5 ;
      private string AV164Almacen_productoswwds_55_tfprodref5_sel ;
      private string AV165Almacen_productoswwds_56_tfprodref6 ;
      private string AV166Almacen_productoswwds_57_tfprodref6_sel ;
      private string AV167Almacen_productoswwds_58_tfprodref7 ;
      private string AV168Almacen_productoswwds_59_tfprodref7_sel ;
      private string AV169Almacen_productoswwds_60_tfprodref8 ;
      private string AV170Almacen_productoswwds_61_tfprodref8_sel ;
      private string AV171Almacen_productoswwds_62_tfprodref9 ;
      private string AV172Almacen_productoswwds_63_tfprodref9_sel ;
      private string AV173Almacen_productoswwds_64_tfprodref10 ;
      private string AV174Almacen_productoswwds_65_tfprodref10_sel ;
      private string scmdbuf ;
      private string lV112Almacen_productoswwds_3_proddsc1 ;
      private string lV113Almacen_productoswwds_4_prodcuentavdsc1 ;
      private string lV114Almacen_productoswwds_5_prodcuentacdsc1 ;
      private string lV115Almacen_productoswwds_6_prodcuentaadsc1 ;
      private string lV116Almacen_productoswwds_7_lindsc1 ;
      private string lV120Almacen_productoswwds_11_proddsc2 ;
      private string lV121Almacen_productoswwds_12_prodcuentavdsc2 ;
      private string lV122Almacen_productoswwds_13_prodcuentacdsc2 ;
      private string lV123Almacen_productoswwds_14_prodcuentaadsc2 ;
      private string lV124Almacen_productoswwds_15_lindsc2 ;
      private string lV128Almacen_productoswwds_19_proddsc3 ;
      private string lV129Almacen_productoswwds_20_prodcuentavdsc3 ;
      private string lV130Almacen_productoswwds_21_prodcuentacdsc3 ;
      private string lV131Almacen_productoswwds_22_prodcuentaadsc3 ;
      private string lV132Almacen_productoswwds_23_lindsc3 ;
      private string lV133Almacen_productoswwds_24_tfprodcod ;
      private string lV137Almacen_productoswwds_28_tfproddsc ;
      private string lV155Almacen_productoswwds_46_tfprodref1 ;
      private string lV157Almacen_productoswwds_48_tfprodref2 ;
      private string lV159Almacen_productoswwds_50_tfprodref3 ;
      private string lV161Almacen_productoswwds_52_tfprodref4 ;
      private string lV163Almacen_productoswwds_54_tfprodref5 ;
      private string lV165Almacen_productoswwds_56_tfprodref6 ;
      private string lV167Almacen_productoswwds_58_tfprodref7 ;
      private string lV169Almacen_productoswwds_60_tfprodref8 ;
      private string lV171Almacen_productoswwds_62_tfprodref9 ;
      private string lV173Almacen_productoswwds_64_tfprodref10 ;
      private string A55ProdDsc ;
      private string A1686ProdCuentaVDsc ;
      private string A1685ProdCuentaCDsc ;
      private string A1684ProdCuentaADsc ;
      private string A1153LinDsc ;
      private string A28ProdCod ;
      private string A1705ProdRef1 ;
      private string A1707ProdRef2 ;
      private string A1708ProdRef3 ;
      private string A1709ProdRef4 ;
      private string A1710ProdRef5 ;
      private string A1711ProdRef6 ;
      private string A1712ProdRef7 ;
      private string A1713ProdRef8 ;
      private string A1714ProdRef9 ;
      private string A1706ProdRef10 ;
      private string A48ProdCuentaV ;
      private string A53ProdCuentaC ;
      private string A54ProdCuentaA ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV31DynamicFiltersEnabled3 ;
      private bool AV117Almacen_productoswwds_8_dynamicfiltersenabled2 ;
      private bool AV125Almacen_productoswwds_16_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n48ProdCuentaV ;
      private bool n53ProdCuentaC ;
      private bool n54ProdCuentaA ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private string AV99TFProdSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV32DynamicFiltersSelector3 ;
      private string AV110Almacen_productoswwds_1_dynamicfiltersselector1 ;
      private string AV118Almacen_productoswwds_9_dynamicfiltersselector2 ;
      private string AV126Almacen_productoswwds_17_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV100TFProdSts_Sels ;
      private GxSimpleCollection<short> AV175Almacen_productoswwds_66_tfprodsts_sels ;
      private IGxSession AV39Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00DU2_A48ProdCuentaV ;
      private bool[] P00DU2_n48ProdCuentaV ;
      private string[] P00DU2_A53ProdCuentaC ;
      private bool[] P00DU2_n53ProdCuentaC ;
      private string[] P00DU2_A54ProdCuentaA ;
      private bool[] P00DU2_n54ProdCuentaA ;
      private decimal[] P00DU2_A1681ProdCosto ;
      private short[] P00DU2_A1718ProdSts ;
      private string[] P00DU2_A1706ProdRef10 ;
      private string[] P00DU2_A1714ProdRef9 ;
      private string[] P00DU2_A1713ProdRef8 ;
      private string[] P00DU2_A1712ProdRef7 ;
      private string[] P00DU2_A1711ProdRef6 ;
      private string[] P00DU2_A1710ProdRef5 ;
      private string[] P00DU2_A1709ProdRef4 ;
      private string[] P00DU2_A1708ProdRef3 ;
      private string[] P00DU2_A1707ProdRef2 ;
      private string[] P00DU2_A1705ProdRef1 ;
      private decimal[] P00DU2_A1717ProdStkMin ;
      private decimal[] P00DU2_A1716ProdStkMax ;
      private decimal[] P00DU2_A1723ProdVolumen ;
      private decimal[] P00DU2_A1702ProdPeso ;
      private short[] P00DU2_A1679ProdCmp ;
      private short[] P00DU2_A1724ProdVta ;
      private int[] P00DU2_A49UniCod ;
      private int[] P00DU2_A50FamCod ;
      private bool[] P00DU2_n50FamCod ;
      private int[] P00DU2_A51SublCod ;
      private bool[] P00DU2_n51SublCod ;
      private int[] P00DU2_A52LinCod ;
      private string[] P00DU2_A28ProdCod ;
      private string[] P00DU2_A1153LinDsc ;
      private string[] P00DU2_A1684ProdCuentaADsc ;
      private string[] P00DU2_A1685ProdCuentaCDsc ;
      private string[] P00DU2_A1686ProdCuentaVDsc ;
      private string[] P00DU2_A55ProdDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV38GridStateDynamicFilter ;
   }

   public class productoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DU2( IGxContext context ,
                                             short A1718ProdSts ,
                                             GxSimpleCollection<short> AV175Almacen_productoswwds_66_tfprodsts_sels ,
                                             string AV110Almacen_productoswwds_1_dynamicfiltersselector1 ,
                                             short AV111Almacen_productoswwds_2_dynamicfiltersoperator1 ,
                                             string AV112Almacen_productoswwds_3_proddsc1 ,
                                             string AV113Almacen_productoswwds_4_prodcuentavdsc1 ,
                                             string AV114Almacen_productoswwds_5_prodcuentacdsc1 ,
                                             string AV115Almacen_productoswwds_6_prodcuentaadsc1 ,
                                             string AV116Almacen_productoswwds_7_lindsc1 ,
                                             bool AV117Almacen_productoswwds_8_dynamicfiltersenabled2 ,
                                             string AV118Almacen_productoswwds_9_dynamicfiltersselector2 ,
                                             short AV119Almacen_productoswwds_10_dynamicfiltersoperator2 ,
                                             string AV120Almacen_productoswwds_11_proddsc2 ,
                                             string AV121Almacen_productoswwds_12_prodcuentavdsc2 ,
                                             string AV122Almacen_productoswwds_13_prodcuentacdsc2 ,
                                             string AV123Almacen_productoswwds_14_prodcuentaadsc2 ,
                                             string AV124Almacen_productoswwds_15_lindsc2 ,
                                             bool AV125Almacen_productoswwds_16_dynamicfiltersenabled3 ,
                                             string AV126Almacen_productoswwds_17_dynamicfiltersselector3 ,
                                             short AV127Almacen_productoswwds_18_dynamicfiltersoperator3 ,
                                             string AV128Almacen_productoswwds_19_proddsc3 ,
                                             string AV129Almacen_productoswwds_20_prodcuentavdsc3 ,
                                             string AV130Almacen_productoswwds_21_prodcuentacdsc3 ,
                                             string AV131Almacen_productoswwds_22_prodcuentaadsc3 ,
                                             string AV132Almacen_productoswwds_23_lindsc3 ,
                                             string AV134Almacen_productoswwds_25_tfprodcod_sel ,
                                             string AV133Almacen_productoswwds_24_tfprodcod ,
                                             int AV135Almacen_productoswwds_26_tflincod ,
                                             int AV136Almacen_productoswwds_27_tflincod_to ,
                                             string AV138Almacen_productoswwds_29_tfproddsc_sel ,
                                             string AV137Almacen_productoswwds_28_tfproddsc ,
                                             int AV139Almacen_productoswwds_30_tfsublcod ,
                                             int AV140Almacen_productoswwds_31_tfsublcod_to ,
                                             int AV141Almacen_productoswwds_32_tffamcod ,
                                             int AV142Almacen_productoswwds_33_tffamcod_to ,
                                             int AV143Almacen_productoswwds_34_tfunicod ,
                                             int AV144Almacen_productoswwds_35_tfunicod_to ,
                                             short AV145Almacen_productoswwds_36_tfprodvta_sel ,
                                             short AV146Almacen_productoswwds_37_tfprodcmp_sel ,
                                             decimal AV147Almacen_productoswwds_38_tfprodpeso ,
                                             decimal AV148Almacen_productoswwds_39_tfprodpeso_to ,
                                             decimal AV149Almacen_productoswwds_40_tfprodvolumen ,
                                             decimal AV150Almacen_productoswwds_41_tfprodvolumen_to ,
                                             decimal AV151Almacen_productoswwds_42_tfprodstkmax ,
                                             decimal AV152Almacen_productoswwds_43_tfprodstkmax_to ,
                                             decimal AV153Almacen_productoswwds_44_tfprodstkmin ,
                                             decimal AV154Almacen_productoswwds_45_tfprodstkmin_to ,
                                             string AV156Almacen_productoswwds_47_tfprodref1_sel ,
                                             string AV155Almacen_productoswwds_46_tfprodref1 ,
                                             string AV158Almacen_productoswwds_49_tfprodref2_sel ,
                                             string AV157Almacen_productoswwds_48_tfprodref2 ,
                                             string AV160Almacen_productoswwds_51_tfprodref3_sel ,
                                             string AV159Almacen_productoswwds_50_tfprodref3 ,
                                             string AV162Almacen_productoswwds_53_tfprodref4_sel ,
                                             string AV161Almacen_productoswwds_52_tfprodref4 ,
                                             string AV164Almacen_productoswwds_55_tfprodref5_sel ,
                                             string AV163Almacen_productoswwds_54_tfprodref5 ,
                                             string AV166Almacen_productoswwds_57_tfprodref6_sel ,
                                             string AV165Almacen_productoswwds_56_tfprodref6 ,
                                             string AV168Almacen_productoswwds_59_tfprodref7_sel ,
                                             string AV167Almacen_productoswwds_58_tfprodref7 ,
                                             string AV170Almacen_productoswwds_61_tfprodref8_sel ,
                                             string AV169Almacen_productoswwds_60_tfprodref8 ,
                                             string AV172Almacen_productoswwds_63_tfprodref9_sel ,
                                             string AV171Almacen_productoswwds_62_tfprodref9 ,
                                             string AV174Almacen_productoswwds_65_tfprodref10_sel ,
                                             string AV173Almacen_productoswwds_64_tfprodref10 ,
                                             int AV175Almacen_productoswwds_66_tfprodsts_sels_Count ,
                                             decimal AV176Almacen_productoswwds_67_tfprodcosto ,
                                             decimal AV177Almacen_productoswwds_68_tfprodcosto_to ,
                                             string A55ProdDsc ,
                                             string A1686ProdCuentaVDsc ,
                                             string A1685ProdCuentaCDsc ,
                                             string A1684ProdCuentaADsc ,
                                             string A1153LinDsc ,
                                             string A28ProdCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A49UniCod ,
                                             short A1724ProdVta ,
                                             short A1679ProdCmp ,
                                             decimal A1702ProdPeso ,
                                             decimal A1723ProdVolumen ,
                                             decimal A1716ProdStkMax ,
                                             decimal A1717ProdStkMin ,
                                             string A1705ProdRef1 ,
                                             string A1707ProdRef2 ,
                                             string A1708ProdRef3 ,
                                             string A1709ProdRef4 ,
                                             string A1710ProdRef5 ,
                                             string A1711ProdRef6 ,
                                             string A1712ProdRef7 ,
                                             string A1713ProdRef8 ,
                                             string A1714ProdRef9 ,
                                             string A1706ProdRef10 ,
                                             decimal A1681ProdCosto ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[72];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[ProdCuentaV] AS ProdCuentaV, T1.[ProdCuentaC] AS ProdCuentaC, T1.[ProdCuentaA] AS ProdCuentaA, T1.[ProdCosto], T1.[ProdSts], T1.[ProdRef10], T1.[ProdRef9], T1.[ProdRef8], T1.[ProdRef7], T1.[ProdRef6], T1.[ProdRef5], T1.[ProdRef4], T1.[ProdRef3], T1.[ProdRef2], T1.[ProdRef1], T1.[ProdStkMin], T1.[ProdStkMax], T1.[ProdVolumen], T1.[ProdPeso], T1.[ProdCmp], T1.[ProdVta], T1.[UniCod], T1.[FamCod], T1.[SublCod], T1.[LinCod], T1.[ProdCod], T5.[LinDsc], T4.[CueDsc] AS ProdCuentaADsc, T3.[CueDsc] AS ProdCuentaCDsc, T2.[CueDsc] AS ProdCuentaVDsc, T1.[ProdDsc] FROM (((([APRODUCTOS] T1 LEFT JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[ProdCuentaV]) LEFT JOIN [CBPLANCUENTA] T3 ON T3.[CueCod] = T1.[ProdCuentaC]) LEFT JOIN [CBPLANCUENTA] T4 ON T4.[CueCod] = T1.[ProdCuentaA]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T1.[LinCod])";
         if ( ( StringUtil.StrCmp(AV110Almacen_productoswwds_1_dynamicfiltersselector1, "PRODDSC") == 0 ) && ( AV111Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Almacen_productoswwds_3_proddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV112Almacen_productoswwds_3_proddsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV110Almacen_productoswwds_1_dynamicfiltersselector1, "PRODDSC") == 0 ) && ( AV111Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Almacen_productoswwds_3_proddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like '%' + @lV112Almacen_productoswwds_3_proddsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV110Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAVDSC") == 0 ) && ( AV111Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Almacen_productoswwds_4_prodcuentavdsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV113Almacen_productoswwds_4_prodcuentavdsc1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV110Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAVDSC") == 0 ) && ( AV111Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Almacen_productoswwds_4_prodcuentavdsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV113Almacen_productoswwds_4_prodcuentavdsc1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV110Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTACDSC") == 0 ) && ( AV111Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Almacen_productoswwds_5_prodcuentacdsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like @lV114Almacen_productoswwds_5_prodcuentacdsc1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV110Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTACDSC") == 0 ) && ( AV111Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Almacen_productoswwds_5_prodcuentacdsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like '%' + @lV114Almacen_productoswwds_5_prodcuentacdsc1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV110Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAADSC") == 0 ) && ( AV111Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Almacen_productoswwds_6_prodcuentaadsc1)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like @lV115Almacen_productoswwds_6_prodcuentaadsc1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV110Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAADSC") == 0 ) && ( AV111Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Almacen_productoswwds_6_prodcuentaadsc1)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like '%' + @lV115Almacen_productoswwds_6_prodcuentaadsc1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV110Almacen_productoswwds_1_dynamicfiltersselector1, "LINDSC") == 0 ) && ( AV111Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Almacen_productoswwds_7_lindsc1)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like @lV116Almacen_productoswwds_7_lindsc1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV110Almacen_productoswwds_1_dynamicfiltersselector1, "LINDSC") == 0 ) && ( AV111Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Almacen_productoswwds_7_lindsc1)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like '%' + @lV116Almacen_productoswwds_7_lindsc1)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV117Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV118Almacen_productoswwds_9_dynamicfiltersselector2, "PRODDSC") == 0 ) && ( AV119Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Almacen_productoswwds_11_proddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV120Almacen_productoswwds_11_proddsc2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV117Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV118Almacen_productoswwds_9_dynamicfiltersselector2, "PRODDSC") == 0 ) && ( AV119Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Almacen_productoswwds_11_proddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like '%' + @lV120Almacen_productoswwds_11_proddsc2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV117Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV118Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAVDSC") == 0 ) && ( AV119Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Almacen_productoswwds_12_prodcuentavdsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV121Almacen_productoswwds_12_prodcuentavdsc2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV117Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV118Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAVDSC") == 0 ) && ( AV119Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Almacen_productoswwds_12_prodcuentavdsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV121Almacen_productoswwds_12_prodcuentavdsc2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV117Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV118Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTACDSC") == 0 ) && ( AV119Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Almacen_productoswwds_13_prodcuentacdsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like @lV122Almacen_productoswwds_13_prodcuentacdsc2)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV117Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV118Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTACDSC") == 0 ) && ( AV119Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Almacen_productoswwds_13_prodcuentacdsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like '%' + @lV122Almacen_productoswwds_13_prodcuentacdsc2)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV117Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV118Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAADSC") == 0 ) && ( AV119Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Almacen_productoswwds_14_prodcuentaadsc2)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like @lV123Almacen_productoswwds_14_prodcuentaadsc2)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV117Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV118Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAADSC") == 0 ) && ( AV119Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Almacen_productoswwds_14_prodcuentaadsc2)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like '%' + @lV123Almacen_productoswwds_14_prodcuentaadsc2)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV117Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV118Almacen_productoswwds_9_dynamicfiltersselector2, "LINDSC") == 0 ) && ( AV119Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Almacen_productoswwds_15_lindsc2)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like @lV124Almacen_productoswwds_15_lindsc2)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV117Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV118Almacen_productoswwds_9_dynamicfiltersselector2, "LINDSC") == 0 ) && ( AV119Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Almacen_productoswwds_15_lindsc2)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like '%' + @lV124Almacen_productoswwds_15_lindsc2)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV125Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Almacen_productoswwds_17_dynamicfiltersselector3, "PRODDSC") == 0 ) && ( AV127Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Almacen_productoswwds_19_proddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV128Almacen_productoswwds_19_proddsc3)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( AV125Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Almacen_productoswwds_17_dynamicfiltersselector3, "PRODDSC") == 0 ) && ( AV127Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Almacen_productoswwds_19_proddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like '%' + @lV128Almacen_productoswwds_19_proddsc3)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( AV125Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAVDSC") == 0 ) && ( AV127Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Almacen_productoswwds_20_prodcuentavdsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV129Almacen_productoswwds_20_prodcuentavdsc3)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV125Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAVDSC") == 0 ) && ( AV127Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Almacen_productoswwds_20_prodcuentavdsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV129Almacen_productoswwds_20_prodcuentavdsc3)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV125Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTACDSC") == 0 ) && ( AV127Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Almacen_productoswwds_21_prodcuentacdsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like @lV130Almacen_productoswwds_21_prodcuentacdsc3)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( AV125Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTACDSC") == 0 ) && ( AV127Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Almacen_productoswwds_21_prodcuentacdsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like '%' + @lV130Almacen_productoswwds_21_prodcuentacdsc3)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( AV125Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAADSC") == 0 ) && ( AV127Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Almacen_productoswwds_22_prodcuentaadsc3)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like @lV131Almacen_productoswwds_22_prodcuentaadsc3)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( AV125Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAADSC") == 0 ) && ( AV127Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Almacen_productoswwds_22_prodcuentaadsc3)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like '%' + @lV131Almacen_productoswwds_22_prodcuentaadsc3)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV125Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Almacen_productoswwds_17_dynamicfiltersselector3, "LINDSC") == 0 ) && ( AV127Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Almacen_productoswwds_23_lindsc3)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like @lV132Almacen_productoswwds_23_lindsc3)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( AV125Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Almacen_productoswwds_17_dynamicfiltersselector3, "LINDSC") == 0 ) && ( AV127Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Almacen_productoswwds_23_lindsc3)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like '%' + @lV132Almacen_productoswwds_23_lindsc3)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV134Almacen_productoswwds_25_tfprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Almacen_productoswwds_24_tfprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV133Almacen_productoswwds_24_tfprodcod)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Almacen_productoswwds_25_tfprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV134Almacen_productoswwds_25_tfprodcod_sel)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( ! (0==AV135Almacen_productoswwds_26_tflincod) )
         {
            AddWhere(sWhereString, "(T1.[LinCod] >= @AV135Almacen_productoswwds_26_tflincod)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( ! (0==AV136Almacen_productoswwds_27_tflincod_to) )
         {
            AddWhere(sWhereString, "(T1.[LinCod] <= @AV136Almacen_productoswwds_27_tflincod_to)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV138Almacen_productoswwds_29_tfproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Almacen_productoswwds_28_tfproddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV137Almacen_productoswwds_28_tfproddsc)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Almacen_productoswwds_29_tfproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] = @AV138Almacen_productoswwds_29_tfproddsc_sel)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( ! (0==AV139Almacen_productoswwds_30_tfsublcod) )
         {
            AddWhere(sWhereString, "(T1.[SublCod] >= @AV139Almacen_productoswwds_30_tfsublcod)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( ! (0==AV140Almacen_productoswwds_31_tfsublcod_to) )
         {
            AddWhere(sWhereString, "(T1.[SublCod] <= @AV140Almacen_productoswwds_31_tfsublcod_to)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( ! (0==AV141Almacen_productoswwds_32_tffamcod) )
         {
            AddWhere(sWhereString, "(T1.[FamCod] >= @AV141Almacen_productoswwds_32_tffamcod)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( ! (0==AV142Almacen_productoswwds_33_tffamcod_to) )
         {
            AddWhere(sWhereString, "(T1.[FamCod] <= @AV142Almacen_productoswwds_33_tffamcod_to)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( ! (0==AV143Almacen_productoswwds_34_tfunicod) )
         {
            AddWhere(sWhereString, "(T1.[UniCod] >= @AV143Almacen_productoswwds_34_tfunicod)");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( ! (0==AV144Almacen_productoswwds_35_tfunicod_to) )
         {
            AddWhere(sWhereString, "(T1.[UniCod] <= @AV144Almacen_productoswwds_35_tfunicod_to)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( AV145Almacen_productoswwds_36_tfprodvta_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[ProdVta] = 1)");
         }
         if ( AV145Almacen_productoswwds_36_tfprodvta_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[ProdVta] = 0)");
         }
         if ( AV146Almacen_productoswwds_37_tfprodcmp_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[ProdCmp] = 1)");
         }
         if ( AV146Almacen_productoswwds_37_tfprodcmp_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[ProdCmp] = 0)");
         }
         if ( ! (Convert.ToDecimal(0)==AV147Almacen_productoswwds_38_tfprodpeso) )
         {
            AddWhere(sWhereString, "(T1.[ProdPeso] >= @AV147Almacen_productoswwds_38_tfprodpeso)");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV148Almacen_productoswwds_39_tfprodpeso_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdPeso] <= @AV148Almacen_productoswwds_39_tfprodpeso_to)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV149Almacen_productoswwds_40_tfprodvolumen) )
         {
            AddWhere(sWhereString, "(T1.[ProdVolumen] >= @AV149Almacen_productoswwds_40_tfprodvolumen)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV150Almacen_productoswwds_41_tfprodvolumen_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdVolumen] <= @AV150Almacen_productoswwds_41_tfprodvolumen_to)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV151Almacen_productoswwds_42_tfprodstkmax) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMax] >= @AV151Almacen_productoswwds_42_tfprodstkmax)");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV152Almacen_productoswwds_43_tfprodstkmax_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMax] <= @AV152Almacen_productoswwds_43_tfprodstkmax_to)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV153Almacen_productoswwds_44_tfprodstkmin) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMin] >= @AV153Almacen_productoswwds_44_tfprodstkmin)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV154Almacen_productoswwds_45_tfprodstkmin_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMin] <= @AV154Almacen_productoswwds_45_tfprodstkmin_to)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Almacen_productoswwds_47_tfprodref1_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Almacen_productoswwds_46_tfprodref1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef1] like @lV155Almacen_productoswwds_46_tfprodref1)");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Almacen_productoswwds_47_tfprodref1_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef1] = @AV156Almacen_productoswwds_47_tfprodref1_sel)");
         }
         else
         {
            GXv_int3[51] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Almacen_productoswwds_49_tfprodref2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Almacen_productoswwds_48_tfprodref2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef2] like @lV157Almacen_productoswwds_48_tfprodref2)");
         }
         else
         {
            GXv_int3[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Almacen_productoswwds_49_tfprodref2_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef2] = @AV158Almacen_productoswwds_49_tfprodref2_sel)");
         }
         else
         {
            GXv_int3[53] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Almacen_productoswwds_51_tfprodref3_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Almacen_productoswwds_50_tfprodref3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef3] like @lV159Almacen_productoswwds_50_tfprodref3)");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Almacen_productoswwds_51_tfprodref3_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef3] = @AV160Almacen_productoswwds_51_tfprodref3_sel)");
         }
         else
         {
            GXv_int3[55] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Almacen_productoswwds_53_tfprodref4_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Almacen_productoswwds_52_tfprodref4)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef4] like @lV161Almacen_productoswwds_52_tfprodref4)");
         }
         else
         {
            GXv_int3[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Almacen_productoswwds_53_tfprodref4_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef4] = @AV162Almacen_productoswwds_53_tfprodref4_sel)");
         }
         else
         {
            GXv_int3[57] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV164Almacen_productoswwds_55_tfprodref5_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV163Almacen_productoswwds_54_tfprodref5)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef5] like @lV163Almacen_productoswwds_54_tfprodref5)");
         }
         else
         {
            GXv_int3[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV164Almacen_productoswwds_55_tfprodref5_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef5] = @AV164Almacen_productoswwds_55_tfprodref5_sel)");
         }
         else
         {
            GXv_int3[59] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV166Almacen_productoswwds_57_tfprodref6_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV165Almacen_productoswwds_56_tfprodref6)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef6] like @lV165Almacen_productoswwds_56_tfprodref6)");
         }
         else
         {
            GXv_int3[60] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV166Almacen_productoswwds_57_tfprodref6_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef6] = @AV166Almacen_productoswwds_57_tfprodref6_sel)");
         }
         else
         {
            GXv_int3[61] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV168Almacen_productoswwds_59_tfprodref7_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV167Almacen_productoswwds_58_tfprodref7)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef7] like @lV167Almacen_productoswwds_58_tfprodref7)");
         }
         else
         {
            GXv_int3[62] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV168Almacen_productoswwds_59_tfprodref7_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef7] = @AV168Almacen_productoswwds_59_tfprodref7_sel)");
         }
         else
         {
            GXv_int3[63] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV170Almacen_productoswwds_61_tfprodref8_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV169Almacen_productoswwds_60_tfprodref8)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef8] like @lV169Almacen_productoswwds_60_tfprodref8)");
         }
         else
         {
            GXv_int3[64] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV170Almacen_productoswwds_61_tfprodref8_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef8] = @AV170Almacen_productoswwds_61_tfprodref8_sel)");
         }
         else
         {
            GXv_int3[65] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV172Almacen_productoswwds_63_tfprodref9_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV171Almacen_productoswwds_62_tfprodref9)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef9] like @lV171Almacen_productoswwds_62_tfprodref9)");
         }
         else
         {
            GXv_int3[66] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV172Almacen_productoswwds_63_tfprodref9_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef9] = @AV172Almacen_productoswwds_63_tfprodref9_sel)");
         }
         else
         {
            GXv_int3[67] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV174Almacen_productoswwds_65_tfprodref10_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV173Almacen_productoswwds_64_tfprodref10)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef10] like @lV173Almacen_productoswwds_64_tfprodref10)");
         }
         else
         {
            GXv_int3[68] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV174Almacen_productoswwds_65_tfprodref10_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef10] = @AV174Almacen_productoswwds_65_tfprodref10_sel)");
         }
         else
         {
            GXv_int3[69] = 1;
         }
         if ( AV175Almacen_productoswwds_66_tfprodsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV175Almacen_productoswwds_66_tfprodsts_sels, "T1.[ProdSts] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV176Almacen_productoswwds_67_tfprodcosto) )
         {
            AddWhere(sWhereString, "(T1.[ProdCosto] >= @AV176Almacen_productoswwds_67_tfprodcosto)");
         }
         else
         {
            GXv_int3[70] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV177Almacen_productoswwds_68_tfprodcosto_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdCosto] <= @AV177Almacen_productoswwds_68_tfprodcosto_to)");
         }
         else
         {
            GXv_int3[71] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdDsc]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdCod] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[LinCod]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[LinCod] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SublCod]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SublCod] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[FamCod]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[FamCod] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[UniCod]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[UniCod] DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdVta]";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdVta] DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdCmp]";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdCmp] DESC";
         }
         else if ( ( AV16OrderedBy == 9 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdPeso]";
         }
         else if ( ( AV16OrderedBy == 9 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdPeso] DESC";
         }
         else if ( ( AV16OrderedBy == 10 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdVolumen]";
         }
         else if ( ( AV16OrderedBy == 10 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdVolumen] DESC";
         }
         else if ( ( AV16OrderedBy == 11 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdStkMax]";
         }
         else if ( ( AV16OrderedBy == 11 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdStkMax] DESC";
         }
         else if ( ( AV16OrderedBy == 12 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdStkMin]";
         }
         else if ( ( AV16OrderedBy == 12 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdStkMin] DESC";
         }
         else if ( ( AV16OrderedBy == 13 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef1]";
         }
         else if ( ( AV16OrderedBy == 13 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef1] DESC";
         }
         else if ( ( AV16OrderedBy == 14 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef2]";
         }
         else if ( ( AV16OrderedBy == 14 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef2] DESC";
         }
         else if ( ( AV16OrderedBy == 15 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef3]";
         }
         else if ( ( AV16OrderedBy == 15 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef3] DESC";
         }
         else if ( ( AV16OrderedBy == 16 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef4]";
         }
         else if ( ( AV16OrderedBy == 16 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef4] DESC";
         }
         else if ( ( AV16OrderedBy == 17 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef5]";
         }
         else if ( ( AV16OrderedBy == 17 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef5] DESC";
         }
         else if ( ( AV16OrderedBy == 18 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef6]";
         }
         else if ( ( AV16OrderedBy == 18 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef6] DESC";
         }
         else if ( ( AV16OrderedBy == 19 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef7]";
         }
         else if ( ( AV16OrderedBy == 19 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef7] DESC";
         }
         else if ( ( AV16OrderedBy == 20 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef8]";
         }
         else if ( ( AV16OrderedBy == 20 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef8] DESC";
         }
         else if ( ( AV16OrderedBy == 21 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef9]";
         }
         else if ( ( AV16OrderedBy == 21 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef9] DESC";
         }
         else if ( ( AV16OrderedBy == 22 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdRef10]";
         }
         else if ( ( AV16OrderedBy == 22 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdRef10] DESC";
         }
         else if ( ( AV16OrderedBy == 23 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdSts]";
         }
         else if ( ( AV16OrderedBy == 23 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdSts] DESC";
         }
         else if ( ( AV16OrderedBy == 24 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProdCosto]";
         }
         else if ( ( AV16OrderedBy == 24 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProdCosto] DESC";
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
                     return conditional_P00DU2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (int)dynConstraints[31] , (int)dynConstraints[32] , (int)dynConstraints[33] , (int)dynConstraints[34] , (int)dynConstraints[35] , (int)dynConstraints[36] , (short)dynConstraints[37] , (short)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (decimal)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (decimal)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (int)dynConstraints[67] , (decimal)dynConstraints[68] , (decimal)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (int)dynConstraints[76] , (int)dynConstraints[77] , (int)dynConstraints[78] , (int)dynConstraints[79] , (short)dynConstraints[80] , (short)dynConstraints[81] , (decimal)dynConstraints[82] , (decimal)dynConstraints[83] , (decimal)dynConstraints[84] , (decimal)dynConstraints[85] , (string)dynConstraints[86] , (string)dynConstraints[87] , (string)dynConstraints[88] , (string)dynConstraints[89] , (string)dynConstraints[90] , (string)dynConstraints[91] , (string)dynConstraints[92] , (string)dynConstraints[93] , (string)dynConstraints[94] , (string)dynConstraints[95] , (decimal)dynConstraints[96] , (short)dynConstraints[97] , (bool)dynConstraints[98] );
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
          Object[] prmP00DU2;
          prmP00DU2 = new Object[] {
          new ParDef("@lV112Almacen_productoswwds_3_proddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV112Almacen_productoswwds_3_proddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV113Almacen_productoswwds_4_prodcuentavdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV113Almacen_productoswwds_4_prodcuentavdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV114Almacen_productoswwds_5_prodcuentacdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV114Almacen_productoswwds_5_prodcuentacdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV115Almacen_productoswwds_6_prodcuentaadsc1",GXType.NChar,100,0) ,
          new ParDef("@lV115Almacen_productoswwds_6_prodcuentaadsc1",GXType.NChar,100,0) ,
          new ParDef("@lV116Almacen_productoswwds_7_lindsc1",GXType.NChar,100,0) ,
          new ParDef("@lV116Almacen_productoswwds_7_lindsc1",GXType.NChar,100,0) ,
          new ParDef("@lV120Almacen_productoswwds_11_proddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV120Almacen_productoswwds_11_proddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV121Almacen_productoswwds_12_prodcuentavdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV121Almacen_productoswwds_12_prodcuentavdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV122Almacen_productoswwds_13_prodcuentacdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV122Almacen_productoswwds_13_prodcuentacdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV123Almacen_productoswwds_14_prodcuentaadsc2",GXType.NChar,100,0) ,
          new ParDef("@lV123Almacen_productoswwds_14_prodcuentaadsc2",GXType.NChar,100,0) ,
          new ParDef("@lV124Almacen_productoswwds_15_lindsc2",GXType.NChar,100,0) ,
          new ParDef("@lV124Almacen_productoswwds_15_lindsc2",GXType.NChar,100,0) ,
          new ParDef("@lV128Almacen_productoswwds_19_proddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV128Almacen_productoswwds_19_proddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV129Almacen_productoswwds_20_prodcuentavdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV129Almacen_productoswwds_20_prodcuentavdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV130Almacen_productoswwds_21_prodcuentacdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV130Almacen_productoswwds_21_prodcuentacdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV131Almacen_productoswwds_22_prodcuentaadsc3",GXType.NChar,100,0) ,
          new ParDef("@lV131Almacen_productoswwds_22_prodcuentaadsc3",GXType.NChar,100,0) ,
          new ParDef("@lV132Almacen_productoswwds_23_lindsc3",GXType.NChar,100,0) ,
          new ParDef("@lV132Almacen_productoswwds_23_lindsc3",GXType.NChar,100,0) ,
          new ParDef("@lV133Almacen_productoswwds_24_tfprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV134Almacen_productoswwds_25_tfprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@AV135Almacen_productoswwds_26_tflincod",GXType.Int32,6,0) ,
          new ParDef("@AV136Almacen_productoswwds_27_tflincod_to",GXType.Int32,6,0) ,
          new ParDef("@lV137Almacen_productoswwds_28_tfproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV138Almacen_productoswwds_29_tfproddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV139Almacen_productoswwds_30_tfsublcod",GXType.Int32,6,0) ,
          new ParDef("@AV140Almacen_productoswwds_31_tfsublcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV141Almacen_productoswwds_32_tffamcod",GXType.Int32,6,0) ,
          new ParDef("@AV142Almacen_productoswwds_33_tffamcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV143Almacen_productoswwds_34_tfunicod",GXType.Int32,6,0) ,
          new ParDef("@AV144Almacen_productoswwds_35_tfunicod_to",GXType.Int32,6,0) ,
          new ParDef("@AV147Almacen_productoswwds_38_tfprodpeso",GXType.Decimal,15,5) ,
          new ParDef("@AV148Almacen_productoswwds_39_tfprodpeso_to",GXType.Decimal,15,5) ,
          new ParDef("@AV149Almacen_productoswwds_40_tfprodvolumen",GXType.Decimal,15,5) ,
          new ParDef("@AV150Almacen_productoswwds_41_tfprodvolumen_to",GXType.Decimal,15,5) ,
          new ParDef("@AV151Almacen_productoswwds_42_tfprodstkmax",GXType.Decimal,15,4) ,
          new ParDef("@AV152Almacen_productoswwds_43_tfprodstkmax_to",GXType.Decimal,15,4) ,
          new ParDef("@AV153Almacen_productoswwds_44_tfprodstkmin",GXType.Decimal,15,4) ,
          new ParDef("@AV154Almacen_productoswwds_45_tfprodstkmin_to",GXType.Decimal,15,4) ,
          new ParDef("@lV155Almacen_productoswwds_46_tfprodref1",GXType.NChar,20,0) ,
          new ParDef("@AV156Almacen_productoswwds_47_tfprodref1_sel",GXType.NChar,20,0) ,
          new ParDef("@lV157Almacen_productoswwds_48_tfprodref2",GXType.NChar,20,0) ,
          new ParDef("@AV158Almacen_productoswwds_49_tfprodref2_sel",GXType.NChar,20,0) ,
          new ParDef("@lV159Almacen_productoswwds_50_tfprodref3",GXType.NChar,20,0) ,
          new ParDef("@AV160Almacen_productoswwds_51_tfprodref3_sel",GXType.NChar,20,0) ,
          new ParDef("@lV161Almacen_productoswwds_52_tfprodref4",GXType.NChar,20,0) ,
          new ParDef("@AV162Almacen_productoswwds_53_tfprodref4_sel",GXType.NChar,20,0) ,
          new ParDef("@lV163Almacen_productoswwds_54_tfprodref5",GXType.NChar,20,0) ,
          new ParDef("@AV164Almacen_productoswwds_55_tfprodref5_sel",GXType.NChar,20,0) ,
          new ParDef("@lV165Almacen_productoswwds_56_tfprodref6",GXType.NChar,20,0) ,
          new ParDef("@AV166Almacen_productoswwds_57_tfprodref6_sel",GXType.NChar,20,0) ,
          new ParDef("@lV167Almacen_productoswwds_58_tfprodref7",GXType.NChar,20,0) ,
          new ParDef("@AV168Almacen_productoswwds_59_tfprodref7_sel",GXType.NChar,20,0) ,
          new ParDef("@lV169Almacen_productoswwds_60_tfprodref8",GXType.NChar,20,0) ,
          new ParDef("@AV170Almacen_productoswwds_61_tfprodref8_sel",GXType.NChar,20,0) ,
          new ParDef("@lV171Almacen_productoswwds_62_tfprodref9",GXType.NChar,20,0) ,
          new ParDef("@AV172Almacen_productoswwds_63_tfprodref9_sel",GXType.NChar,20,0) ,
          new ParDef("@lV173Almacen_productoswwds_64_tfprodref10",GXType.NChar,20,0) ,
          new ParDef("@AV174Almacen_productoswwds_65_tfprodref10_sel",GXType.NChar,20,0) ,
          new ParDef("@AV176Almacen_productoswwds_67_tfprodcosto",GXType.Decimal,18,5) ,
          new ParDef("@AV177Almacen_productoswwds_68_tfprodcosto_to",GXType.Decimal,18,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00DU2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DU2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 15);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 15);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 20);
                ((string[]) buf[9])[0] = rslt.getString(7, 20);
                ((string[]) buf[10])[0] = rslt.getString(8, 20);
                ((string[]) buf[11])[0] = rslt.getString(9, 20);
                ((string[]) buf[12])[0] = rslt.getString(10, 20);
                ((string[]) buf[13])[0] = rslt.getString(11, 20);
                ((string[]) buf[14])[0] = rslt.getString(12, 20);
                ((string[]) buf[15])[0] = rslt.getString(13, 20);
                ((string[]) buf[16])[0] = rslt.getString(14, 20);
                ((string[]) buf[17])[0] = rslt.getString(15, 20);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(19);
                ((short[]) buf[22])[0] = rslt.getShort(20);
                ((short[]) buf[23])[0] = rslt.getShort(21);
                ((int[]) buf[24])[0] = rslt.getInt(22);
                ((int[]) buf[25])[0] = rslt.getInt(23);
                ((bool[]) buf[26])[0] = rslt.wasNull(23);
                ((int[]) buf[27])[0] = rslt.getInt(24);
                ((bool[]) buf[28])[0] = rslt.wasNull(24);
                ((int[]) buf[29])[0] = rslt.getInt(25);
                ((string[]) buf[30])[0] = rslt.getString(26, 15);
                ((string[]) buf[31])[0] = rslt.getString(27, 100);
                ((string[]) buf[32])[0] = rslt.getString(28, 100);
                ((string[]) buf[33])[0] = rslt.getString(29, 100);
                ((string[]) buf[34])[0] = rslt.getString(30, 100);
                ((string[]) buf[35])[0] = rslt.getString(31, 100);
                return;
       }
    }

 }

}
