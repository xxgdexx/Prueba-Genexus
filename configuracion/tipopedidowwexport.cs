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
   public class tipopedidowwexport : GXProcedure
   {
      public tipopedidowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipopedidowwexport( IGxContext context )
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
         tipopedidowwexport objtipopedidowwexport;
         objtipopedidowwexport = new tipopedidowwexport();
         objtipopedidowwexport.AV11Filename = "" ;
         objtipopedidowwexport.AV12ErrorMessage = "" ;
         objtipopedidowwexport.context.SetSubmitInitialConfig(context);
         objtipopedidowwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipopedidowwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipopedidowwexport)stateInfo).executePrivate();
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
         AV11Filename = "TipoPedidoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TPEDDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20TPedDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TPedDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Pedido", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Pedido", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20TPedDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TPEDDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24TPedDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TPedDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Pedido", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Pedido", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24TPedDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TPEDDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28TPedDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TPedDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Pedido", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Pedido", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28TPedDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFTPedCod) && (0==AV35TFTPedCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFTPedCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFTPedCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTPedDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Pedido") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFTPedDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTPedDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Pedido") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFTPedDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV39TFTPedGuia_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Afecta Guia") ;
            AV13CellRow = GXt_int2;
            if ( AV39TFTPedGuia_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV39TFTPedGuia_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV38TFTPedFac_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Afecta Factura") ;
            AV13CellRow = GXt_int2;
            if ( AV38TFTPedFac_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV38TFTPedFac_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( ( AV41TFTPedSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV43i = 1;
            AV49GXV1 = 1;
            while ( AV49GXV1 <= AV41TFTPedSts_Sels.Count )
            {
               AV42TFTPedSts_Sel = (short)(AV41TFTPedSts_Sels.GetNumeric(AV49GXV1));
               if ( AV43i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV42TFTPedSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV42TFTPedSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV43i = (long)(AV43i+1);
               AV49GXV1 = (int)(AV49GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Tipo de Pedido";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Afecta Guia";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Afecta Factura";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV51Configuracion_tipopedidowwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV52Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV53Configuracion_tipopedidowwds_3_tpeddsc1 = AV20TPedDsc1;
         AV54Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV55Configuracion_tipopedidowwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV56Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV57Configuracion_tipopedidowwds_7_tpeddsc2 = AV24TPedDsc2;
         AV58Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV59Configuracion_tipopedidowwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV60Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV61Configuracion_tipopedidowwds_11_tpeddsc3 = AV28TPedDsc3;
         AV62Configuracion_tipopedidowwds_12_tftpedcod = AV34TFTPedCod;
         AV63Configuracion_tipopedidowwds_13_tftpedcod_to = AV35TFTPedCod_To;
         AV64Configuracion_tipopedidowwds_14_tftpeddsc = AV36TFTPedDsc;
         AV65Configuracion_tipopedidowwds_15_tftpeddsc_sel = AV37TFTPedDsc_Sel;
         AV66Configuracion_tipopedidowwds_16_tftpedguia_sel = AV39TFTPedGuia_Sel;
         AV67Configuracion_tipopedidowwds_17_tftpedfac_sel = AV38TFTPedFac_Sel;
         AV68Configuracion_tipopedidowwds_18_tftpedsts_sels = AV41TFTPedSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1936TPedSts ,
                                              AV68Configuracion_tipopedidowwds_18_tftpedsts_sels ,
                                              AV51Configuracion_tipopedidowwds_1_dynamicfiltersselector1 ,
                                              AV52Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 ,
                                              AV53Configuracion_tipopedidowwds_3_tpeddsc1 ,
                                              AV54Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 ,
                                              AV55Configuracion_tipopedidowwds_5_dynamicfiltersselector2 ,
                                              AV56Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 ,
                                              AV57Configuracion_tipopedidowwds_7_tpeddsc2 ,
                                              AV58Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 ,
                                              AV59Configuracion_tipopedidowwds_9_dynamicfiltersselector3 ,
                                              AV60Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 ,
                                              AV61Configuracion_tipopedidowwds_11_tpeddsc3 ,
                                              AV62Configuracion_tipopedidowwds_12_tftpedcod ,
                                              AV63Configuracion_tipopedidowwds_13_tftpedcod_to ,
                                              AV65Configuracion_tipopedidowwds_15_tftpeddsc_sel ,
                                              AV64Configuracion_tipopedidowwds_14_tftpeddsc ,
                                              AV66Configuracion_tipopedidowwds_16_tftpedguia_sel ,
                                              AV67Configuracion_tipopedidowwds_17_tftpedfac_sel ,
                                              AV68Configuracion_tipopedidowwds_18_tftpedsts_sels.Count ,
                                              A1931TPedDsc ,
                                              A212TPedCod ,
                                              A1933TPedGuia ,
                                              A1932TPedFac ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV53Configuracion_tipopedidowwds_3_tpeddsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_tipopedidowwds_3_tpeddsc1), 100, "%");
         lV53Configuracion_tipopedidowwds_3_tpeddsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_tipopedidowwds_3_tpeddsc1), 100, "%");
         lV57Configuracion_tipopedidowwds_7_tpeddsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipopedidowwds_7_tpeddsc2), 100, "%");
         lV57Configuracion_tipopedidowwds_7_tpeddsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipopedidowwds_7_tpeddsc2), 100, "%");
         lV61Configuracion_tipopedidowwds_11_tpeddsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipopedidowwds_11_tpeddsc3), 100, "%");
         lV61Configuracion_tipopedidowwds_11_tpeddsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipopedidowwds_11_tpeddsc3), 100, "%");
         lV64Configuracion_tipopedidowwds_14_tftpeddsc = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_tipopedidowwds_14_tftpeddsc), 100, "%");
         /* Using cursor P004S2 */
         pr_default.execute(0, new Object[] {lV53Configuracion_tipopedidowwds_3_tpeddsc1, lV53Configuracion_tipopedidowwds_3_tpeddsc1, lV57Configuracion_tipopedidowwds_7_tpeddsc2, lV57Configuracion_tipopedidowwds_7_tpeddsc2, lV61Configuracion_tipopedidowwds_11_tpeddsc3, lV61Configuracion_tipopedidowwds_11_tpeddsc3, AV62Configuracion_tipopedidowwds_12_tftpedcod, AV63Configuracion_tipopedidowwds_13_tftpedcod_to, lV64Configuracion_tipopedidowwds_14_tftpeddsc, AV65Configuracion_tipopedidowwds_15_tftpeddsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1936TPedSts = P004S2_A1936TPedSts[0];
            A1932TPedFac = P004S2_A1932TPedFac[0];
            A1933TPedGuia = P004S2_A1933TPedGuia[0];
            A212TPedCod = P004S2_A212TPedCod[0];
            A1931TPedDsc = P004S2_A1931TPedDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A212TPedCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1931TPedDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = A1933TPedGuia;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = A1932TPedFac;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A1936TPedSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "ACTIVO";
            }
            else if ( A1936TPedSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.TipoPedidoWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoPedidoWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.TipoPedidoWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV69GXV2 = 1;
         while ( AV69GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV69GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTPEDCOD") == 0 )
            {
               AV34TFTPedCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFTPedCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTPEDDSC") == 0 )
            {
               AV36TFTPedDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTPEDDSC_SEL") == 0 )
            {
               AV37TFTPedDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTPEDGUIA_SEL") == 0 )
            {
               AV39TFTPedGuia_Sel = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTPEDFAC_SEL") == 0 )
            {
               AV38TFTPedFac_Sel = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTPEDSTS_SEL") == 0 )
            {
               AV40TFTPedSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV41TFTPedSts_Sels.FromJSonString(AV40TFTPedSts_SelsJson, null);
            }
            AV69GXV2 = (int)(AV69GXV2+1);
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
         AV20TPedDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24TPedDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28TPedDsc3 = "";
         AV37TFTPedDsc_Sel = "";
         AV36TFTPedDsc = "";
         AV41TFTPedSts_Sels = new GxSimpleCollection<short>();
         AV51Configuracion_tipopedidowwds_1_dynamicfiltersselector1 = "";
         AV53Configuracion_tipopedidowwds_3_tpeddsc1 = "";
         AV55Configuracion_tipopedidowwds_5_dynamicfiltersselector2 = "";
         AV57Configuracion_tipopedidowwds_7_tpeddsc2 = "";
         AV59Configuracion_tipopedidowwds_9_dynamicfiltersselector3 = "";
         AV61Configuracion_tipopedidowwds_11_tpeddsc3 = "";
         AV64Configuracion_tipopedidowwds_14_tftpeddsc = "";
         AV65Configuracion_tipopedidowwds_15_tftpeddsc_sel = "";
         AV68Configuracion_tipopedidowwds_18_tftpedsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV53Configuracion_tipopedidowwds_3_tpeddsc1 = "";
         lV57Configuracion_tipopedidowwds_7_tpeddsc2 = "";
         lV61Configuracion_tipopedidowwds_11_tpeddsc3 = "";
         lV64Configuracion_tipopedidowwds_14_tftpeddsc = "";
         A1931TPedDsc = "";
         P004S2_A1936TPedSts = new short[1] ;
         P004S2_A1932TPedFac = new short[1] ;
         P004S2_A1933TPedGuia = new short[1] ;
         P004S2_A212TPedCod = new int[1] ;
         P004S2_A1931TPedDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40TFTPedSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipopedidowwexport__default(),
            new Object[][] {
                new Object[] {
               P004S2_A1936TPedSts, P004S2_A1932TPedFac, P004S2_A1933TPedGuia, P004S2_A212TPedCod, P004S2_A1931TPedDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV39TFTPedGuia_Sel ;
      private short AV38TFTPedFac_Sel ;
      private short GXt_int2 ;
      private short AV42TFTPedSts_Sel ;
      private short AV52Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 ;
      private short AV56Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 ;
      private short AV60Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 ;
      private short AV66Configuracion_tipopedidowwds_16_tftpedguia_sel ;
      private short AV67Configuracion_tipopedidowwds_17_tftpedfac_sel ;
      private short A1936TPedSts ;
      private short A1933TPedGuia ;
      private short A1932TPedFac ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFTPedCod ;
      private int AV35TFTPedCod_To ;
      private int AV49GXV1 ;
      private int AV62Configuracion_tipopedidowwds_12_tftpedcod ;
      private int AV63Configuracion_tipopedidowwds_13_tftpedcod_to ;
      private int AV68Configuracion_tipopedidowwds_18_tftpedsts_sels_Count ;
      private int A212TPedCod ;
      private int AV69GXV2 ;
      private long AV43i ;
      private string AV20TPedDsc1 ;
      private string AV24TPedDsc2 ;
      private string AV28TPedDsc3 ;
      private string AV37TFTPedDsc_Sel ;
      private string AV36TFTPedDsc ;
      private string AV53Configuracion_tipopedidowwds_3_tpeddsc1 ;
      private string AV57Configuracion_tipopedidowwds_7_tpeddsc2 ;
      private string AV61Configuracion_tipopedidowwds_11_tpeddsc3 ;
      private string AV64Configuracion_tipopedidowwds_14_tftpeddsc ;
      private string AV65Configuracion_tipopedidowwds_15_tftpeddsc_sel ;
      private string scmdbuf ;
      private string lV53Configuracion_tipopedidowwds_3_tpeddsc1 ;
      private string lV57Configuracion_tipopedidowwds_7_tpeddsc2 ;
      private string lV61Configuracion_tipopedidowwds_11_tpeddsc3 ;
      private string lV64Configuracion_tipopedidowwds_14_tftpeddsc ;
      private string A1931TPedDsc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV54Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 ;
      private bool AV58Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV40TFTPedSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV51Configuracion_tipopedidowwds_1_dynamicfiltersselector1 ;
      private string AV55Configuracion_tipopedidowwds_5_dynamicfiltersselector2 ;
      private string AV59Configuracion_tipopedidowwds_9_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV41TFTPedSts_Sels ;
      private GxSimpleCollection<short> AV68Configuracion_tipopedidowwds_18_tftpedsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P004S2_A1936TPedSts ;
      private short[] P004S2_A1932TPedFac ;
      private short[] P004S2_A1933TPedGuia ;
      private int[] P004S2_A212TPedCod ;
      private string[] P004S2_A1931TPedDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class tipopedidowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004S2( IGxContext context ,
                                             short A1936TPedSts ,
                                             GxSimpleCollection<short> AV68Configuracion_tipopedidowwds_18_tftpedsts_sels ,
                                             string AV51Configuracion_tipopedidowwds_1_dynamicfiltersselector1 ,
                                             short AV52Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 ,
                                             string AV53Configuracion_tipopedidowwds_3_tpeddsc1 ,
                                             bool AV54Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 ,
                                             string AV55Configuracion_tipopedidowwds_5_dynamicfiltersselector2 ,
                                             short AV56Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 ,
                                             string AV57Configuracion_tipopedidowwds_7_tpeddsc2 ,
                                             bool AV58Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 ,
                                             string AV59Configuracion_tipopedidowwds_9_dynamicfiltersselector3 ,
                                             short AV60Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 ,
                                             string AV61Configuracion_tipopedidowwds_11_tpeddsc3 ,
                                             int AV62Configuracion_tipopedidowwds_12_tftpedcod ,
                                             int AV63Configuracion_tipopedidowwds_13_tftpedcod_to ,
                                             string AV65Configuracion_tipopedidowwds_15_tftpeddsc_sel ,
                                             string AV64Configuracion_tipopedidowwds_14_tftpeddsc ,
                                             short AV66Configuracion_tipopedidowwds_16_tftpedguia_sel ,
                                             short AV67Configuracion_tipopedidowwds_17_tftpedfac_sel ,
                                             int AV68Configuracion_tipopedidowwds_18_tftpedsts_sels_Count ,
                                             string A1931TPedDsc ,
                                             int A212TPedCod ,
                                             short A1933TPedGuia ,
                                             short A1932TPedFac ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TPedSts], [TPedFac], [TPedGuia], [TPedCod], [TPedDsc] FROM [CTIPPEDIDO]";
         if ( ( StringUtil.StrCmp(AV51Configuracion_tipopedidowwds_1_dynamicfiltersselector1, "TPEDDSC") == 0 ) && ( AV52Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_tipopedidowwds_3_tpeddsc1)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like @lV53Configuracion_tipopedidowwds_3_tpeddsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_tipopedidowwds_1_dynamicfiltersselector1, "TPEDDSC") == 0 ) && ( AV52Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_tipopedidowwds_3_tpeddsc1)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like '%' + @lV53Configuracion_tipopedidowwds_3_tpeddsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV54Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_tipopedidowwds_5_dynamicfiltersselector2, "TPEDDSC") == 0 ) && ( AV56Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipopedidowwds_7_tpeddsc2)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like @lV57Configuracion_tipopedidowwds_7_tpeddsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV54Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_tipopedidowwds_5_dynamicfiltersselector2, "TPEDDSC") == 0 ) && ( AV56Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipopedidowwds_7_tpeddsc2)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like '%' + @lV57Configuracion_tipopedidowwds_7_tpeddsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV58Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_tipopedidowwds_9_dynamicfiltersselector3, "TPEDDSC") == 0 ) && ( AV60Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipopedidowwds_11_tpeddsc3)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like @lV61Configuracion_tipopedidowwds_11_tpeddsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV58Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_tipopedidowwds_9_dynamicfiltersselector3, "TPEDDSC") == 0 ) && ( AV60Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipopedidowwds_11_tpeddsc3)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like '%' + @lV61Configuracion_tipopedidowwds_11_tpeddsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV62Configuracion_tipopedidowwds_12_tftpedcod) )
         {
            AddWhere(sWhereString, "([TPedCod] >= @AV62Configuracion_tipopedidowwds_12_tftpedcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV63Configuracion_tipopedidowwds_13_tftpedcod_to) )
         {
            AddWhere(sWhereString, "([TPedCod] <= @AV63Configuracion_tipopedidowwds_13_tftpedcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_tipopedidowwds_15_tftpeddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipopedidowwds_14_tftpeddsc)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like @lV64Configuracion_tipopedidowwds_14_tftpeddsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_tipopedidowwds_15_tftpeddsc_sel)) )
         {
            AddWhere(sWhereString, "([TPedDsc] = @AV65Configuracion_tipopedidowwds_15_tftpeddsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV66Configuracion_tipopedidowwds_16_tftpedguia_sel == 1 )
         {
            AddWhere(sWhereString, "([TPedGuia] = 1)");
         }
         if ( AV66Configuracion_tipopedidowwds_16_tftpedguia_sel == 2 )
         {
            AddWhere(sWhereString, "([TPedGuia] = 0)");
         }
         if ( AV67Configuracion_tipopedidowwds_17_tftpedfac_sel == 1 )
         {
            AddWhere(sWhereString, "([TPedFac] = 1)");
         }
         if ( AV67Configuracion_tipopedidowwds_17_tftpedfac_sel == 2 )
         {
            AddWhere(sWhereString, "([TPedFac] = 0)");
         }
         if ( AV68Configuracion_tipopedidowwds_18_tftpedsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Configuracion_tipopedidowwds_18_tftpedsts_sels, "[TPedSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TPedCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TPedCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TPedDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TPedDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TPedGuia]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TPedGuia] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TPedFac]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TPedFac] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TPedSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TPedSts] DESC";
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
                     return conditional_P004S2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] );
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
          Object[] prmP004S2;
          prmP004S2 = new Object[] {
          new ParDef("@lV53Configuracion_tipopedidowwds_3_tpeddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Configuracion_tipopedidowwds_3_tpeddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipopedidowwds_7_tpeddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipopedidowwds_7_tpeddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_tipopedidowwds_11_tpeddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_tipopedidowwds_11_tpeddsc3",GXType.NChar,100,0) ,
          new ParDef("@AV62Configuracion_tipopedidowwds_12_tftpedcod",GXType.Int32,6,0) ,
          new ParDef("@AV63Configuracion_tipopedidowwds_13_tftpedcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Configuracion_tipopedidowwds_14_tftpeddsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Configuracion_tipopedidowwds_15_tftpeddsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004S2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
