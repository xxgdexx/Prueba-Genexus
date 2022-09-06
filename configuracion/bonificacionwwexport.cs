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
   public class bonificacionwwexport : GXProcedure
   {
      public bonificacionwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public bonificacionwwexport( IGxContext context )
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
         bonificacionwwexport objbonificacionwwexport;
         objbonificacionwwexport = new bonificacionwwexport();
         objbonificacionwwexport.AV11Filename = "" ;
         objbonificacionwwexport.AV12ErrorMessage = "" ;
         objbonificacionwwexport.context.SetSubmitInitialConfig(context);
         objbonificacionwwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objbonificacionwwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((bonificacionwwexport)stateInfo).executePrivate();
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
         AV11Filename = "BonificacionWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CBONPRODCOD") == 0 )
            {
               AV19CBonProdCod1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19CBonProdCod1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Producto";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19CBonProdCod1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV20DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CBONPRODCOD") == 0 )
               {
                  AV22CBonProdCod2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CBonProdCod2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Producto";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22CBonProdCod2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CBONPRODCOD") == 0 )
                  {
                     AV25CBonProdCod3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25CBonProdCod3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Producto";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25CBonProdCod3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV32TFCBonProdCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV32TFCBonProdCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV31TFCBonProdCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV31TFCBonProdCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFCBonProdDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Producto") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34TFCBonProdDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV33TFCBonProdDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Producto") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV33TFCBonProdDsc, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Codigo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Producto";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV38Configuracion_bonificacionwwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV39Configuracion_bonificacionwwds_2_cbonprodcod1 = AV19CBonProdCod1;
         AV40Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV41Configuracion_bonificacionwwds_4_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV42Configuracion_bonificacionwwds_5_cbonprodcod2 = AV22CBonProdCod2;
         AV43Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV44Configuracion_bonificacionwwds_7_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV45Configuracion_bonificacionwwds_8_cbonprodcod3 = AV25CBonProdCod3;
         AV46Configuracion_bonificacionwwds_9_tfcbonprodcod = AV31TFCBonProdCod;
         AV47Configuracion_bonificacionwwds_10_tfcbonprodcod_sel = AV32TFCBonProdCod_Sel;
         AV48Configuracion_bonificacionwwds_11_tfcbonproddsc = AV33TFCBonProdDsc;
         AV49Configuracion_bonificacionwwds_12_tfcbonproddsc_sel = AV34TFCBonProdDsc_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV38Configuracion_bonificacionwwds_1_dynamicfiltersselector1 ,
                                              AV39Configuracion_bonificacionwwds_2_cbonprodcod1 ,
                                              AV40Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 ,
                                              AV41Configuracion_bonificacionwwds_4_dynamicfiltersselector2 ,
                                              AV42Configuracion_bonificacionwwds_5_cbonprodcod2 ,
                                              AV43Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 ,
                                              AV44Configuracion_bonificacionwwds_7_dynamicfiltersselector3 ,
                                              AV45Configuracion_bonificacionwwds_8_cbonprodcod3 ,
                                              AV47Configuracion_bonificacionwwds_10_tfcbonprodcod_sel ,
                                              AV46Configuracion_bonificacionwwds_9_tfcbonprodcod ,
                                              AV49Configuracion_bonificacionwwds_12_tfcbonproddsc_sel ,
                                              AV48Configuracion_bonificacionwwds_11_tfcbonproddsc ,
                                              A81CBonProdCod ,
                                              A503CBonProdDsc ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV46Configuracion_bonificacionwwds_9_tfcbonprodcod = StringUtil.PadR( StringUtil.RTrim( AV46Configuracion_bonificacionwwds_9_tfcbonprodcod), 15, "%");
         lV48Configuracion_bonificacionwwds_11_tfcbonproddsc = StringUtil.PadR( StringUtil.RTrim( AV48Configuracion_bonificacionwwds_11_tfcbonproddsc), 100, "%");
         /* Using cursor P00562 */
         pr_default.execute(0, new Object[] {AV39Configuracion_bonificacionwwds_2_cbonprodcod1, AV42Configuracion_bonificacionwwds_5_cbonprodcod2, AV45Configuracion_bonificacionwwds_8_cbonprodcod3, lV46Configuracion_bonificacionwwds_9_tfcbonprodcod, AV47Configuracion_bonificacionwwds_10_tfcbonprodcod_sel, lV48Configuracion_bonificacionwwds_11_tfcbonproddsc, AV49Configuracion_bonificacionwwds_12_tfcbonproddsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A503CBonProdDsc = P00562_A503CBonProdDsc[0];
            A81CBonProdCod = P00562_A81CBonProdCod[0];
            A503CBonProdDsc = P00562_A503CBonProdDsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A81CBonProdCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A503CBonProdDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.BonificacionWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.BonificacionWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.BonificacionWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCBONPRODCOD") == 0 )
            {
               AV31TFCBonProdCod = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCBONPRODCOD_SEL") == 0 )
            {
               AV32TFCBonProdCod_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCBONPRODDSC") == 0 )
            {
               AV33TFCBonProdDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCBONPRODDSC_SEL") == 0 )
            {
               AV34TFCBonProdDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV50GXV1 = (int)(AV50GXV1+1);
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
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV19CBonProdCod1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV22CBonProdCod2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV25CBonProdCod3 = "";
         AV32TFCBonProdCod_Sel = "";
         AV31TFCBonProdCod = "";
         AV34TFCBonProdDsc_Sel = "";
         AV33TFCBonProdDsc = "";
         AV38Configuracion_bonificacionwwds_1_dynamicfiltersselector1 = "";
         AV39Configuracion_bonificacionwwds_2_cbonprodcod1 = "";
         AV41Configuracion_bonificacionwwds_4_dynamicfiltersselector2 = "";
         AV42Configuracion_bonificacionwwds_5_cbonprodcod2 = "";
         AV44Configuracion_bonificacionwwds_7_dynamicfiltersselector3 = "";
         AV45Configuracion_bonificacionwwds_8_cbonprodcod3 = "";
         AV46Configuracion_bonificacionwwds_9_tfcbonprodcod = "";
         AV47Configuracion_bonificacionwwds_10_tfcbonprodcod_sel = "";
         AV48Configuracion_bonificacionwwds_11_tfcbonproddsc = "";
         AV49Configuracion_bonificacionwwds_12_tfcbonproddsc_sel = "";
         scmdbuf = "";
         lV46Configuracion_bonificacionwwds_9_tfcbonprodcod = "";
         lV48Configuracion_bonificacionwwds_11_tfcbonproddsc = "";
         A81CBonProdCod = "";
         A503CBonProdDsc = "";
         P00562_A503CBonProdDsc = new string[] {""} ;
         P00562_A81CBonProdCod = new string[] {""} ;
         GXt_char1 = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.bonificacionwwexport__default(),
            new Object[][] {
                new Object[] {
               P00562_A503CBonProdDsc, P00562_A81CBonProdCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GXt_int2 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV50GXV1 ;
      private string AV19CBonProdCod1 ;
      private string AV22CBonProdCod2 ;
      private string AV25CBonProdCod3 ;
      private string AV32TFCBonProdCod_Sel ;
      private string AV31TFCBonProdCod ;
      private string AV34TFCBonProdDsc_Sel ;
      private string AV33TFCBonProdDsc ;
      private string AV39Configuracion_bonificacionwwds_2_cbonprodcod1 ;
      private string AV42Configuracion_bonificacionwwds_5_cbonprodcod2 ;
      private string AV45Configuracion_bonificacionwwds_8_cbonprodcod3 ;
      private string AV46Configuracion_bonificacionwwds_9_tfcbonprodcod ;
      private string AV47Configuracion_bonificacionwwds_10_tfcbonprodcod_sel ;
      private string AV48Configuracion_bonificacionwwds_11_tfcbonproddsc ;
      private string AV49Configuracion_bonificacionwwds_12_tfcbonproddsc_sel ;
      private string scmdbuf ;
      private string lV46Configuracion_bonificacionwwds_9_tfcbonprodcod ;
      private string lV48Configuracion_bonificacionwwds_11_tfcbonproddsc ;
      private string A81CBonProdCod ;
      private string A503CBonProdDsc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV40Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 ;
      private bool AV43Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV38Configuracion_bonificacionwwds_1_dynamicfiltersselector1 ;
      private string AV41Configuracion_bonificacionwwds_4_dynamicfiltersselector2 ;
      private string AV44Configuracion_bonificacionwwds_7_dynamicfiltersselector3 ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00562_A503CBonProdDsc ;
      private string[] P00562_A81CBonProdCod ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class bonificacionwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00562( IGxContext context ,
                                             string AV38Configuracion_bonificacionwwds_1_dynamicfiltersselector1 ,
                                             string AV39Configuracion_bonificacionwwds_2_cbonprodcod1 ,
                                             bool AV40Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 ,
                                             string AV41Configuracion_bonificacionwwds_4_dynamicfiltersselector2 ,
                                             string AV42Configuracion_bonificacionwwds_5_cbonprodcod2 ,
                                             bool AV43Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 ,
                                             string AV44Configuracion_bonificacionwwds_7_dynamicfiltersselector3 ,
                                             string AV45Configuracion_bonificacionwwds_8_cbonprodcod3 ,
                                             string AV47Configuracion_bonificacionwwds_10_tfcbonprodcod_sel ,
                                             string AV46Configuracion_bonificacionwwds_9_tfcbonprodcod ,
                                             string AV49Configuracion_bonificacionwwds_12_tfcbonproddsc_sel ,
                                             string AV48Configuracion_bonificacionwwds_11_tfcbonproddsc ,
                                             string A81CBonProdCod ,
                                             string A503CBonProdDsc ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.[ProdDsc] AS CBonProdDsc, T1.[CBonProdCod] AS CBonProdCod FROM ([CBONIFICACION] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[CBonProdCod])";
         if ( ( StringUtil.StrCmp(AV38Configuracion_bonificacionwwds_1_dynamicfiltersselector1, "CBONPRODCOD") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Configuracion_bonificacionwwds_2_cbonprodcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV39Configuracion_bonificacionwwds_2_cbonprodcod1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( AV40Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV41Configuracion_bonificacionwwds_4_dynamicfiltersselector2, "CBONPRODCOD") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Configuracion_bonificacionwwds_5_cbonprodcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV42Configuracion_bonificacionwwds_5_cbonprodcod2)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV43Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV44Configuracion_bonificacionwwds_7_dynamicfiltersselector3, "CBONPRODCOD") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Configuracion_bonificacionwwds_8_cbonprodcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV45Configuracion_bonificacionwwds_8_cbonprodcod3)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Configuracion_bonificacionwwds_10_tfcbonprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Configuracion_bonificacionwwds_9_tfcbonprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] like @lV46Configuracion_bonificacionwwds_9_tfcbonprodcod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Configuracion_bonificacionwwds_10_tfcbonprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV47Configuracion_bonificacionwwds_10_tfcbonprodcod_sel)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Configuracion_bonificacionwwds_12_tfcbonproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Configuracion_bonificacionwwds_11_tfcbonproddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[ProdDsc] like @lV48Configuracion_bonificacionwwds_11_tfcbonproddsc)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Configuracion_bonificacionwwds_12_tfcbonproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[ProdDsc] = @AV49Configuracion_bonificacionwwds_12_tfcbonproddsc_sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CBonProdCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CBonProdCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProdDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProdDsc] DESC";
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
                     return conditional_P00562(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] );
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
          Object[] prmP00562;
          prmP00562 = new Object[] {
          new ParDef("@AV39Configuracion_bonificacionwwds_2_cbonprodcod1",GXType.NChar,15,0) ,
          new ParDef("@AV42Configuracion_bonificacionwwds_5_cbonprodcod2",GXType.NChar,15,0) ,
          new ParDef("@AV45Configuracion_bonificacionwwds_8_cbonprodcod3",GXType.NChar,15,0) ,
          new ParDef("@lV46Configuracion_bonificacionwwds_9_tfcbonprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV47Configuracion_bonificacionwwds_10_tfcbonprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV48Configuracion_bonificacionwwds_11_tfcbonproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV49Configuracion_bonificacionwwds_12_tfcbonproddsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00562", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00562,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                return;
       }
    }

 }

}
