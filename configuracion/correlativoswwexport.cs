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
   public class correlativoswwexport : GXProcedure
   {
      public correlativoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public correlativoswwexport( IGxContext context )
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
         correlativoswwexport objcorrelativoswwexport;
         objcorrelativoswwexport = new correlativoswwexport();
         objcorrelativoswwexport.AV11Filename = "" ;
         objcorrelativoswwexport.AV12ErrorMessage = "" ;
         objcorrelativoswwexport.context.SetSubmitInitialConfig(context);
         objcorrelativoswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcorrelativoswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((correlativoswwexport)stateInfo).executePrivate();
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
         AV11Filename = "CorrelativosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CORTIP") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV38CorTip1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38CorTip1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Correlativo", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Correlativo", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38CorTip1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CORTIP") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV39CorTip2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39CorTip2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Correlativo", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Correlativo", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39CorTip2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CORTIP") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV40CorTip3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40CorTip3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Correlativo", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Correlativo", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40CorTip3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCorTip_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Correlativo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFCorTip_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFCorTip)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Correlativo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34TFCorTip, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV36TFCorNum) && (0==AV37TFCorNum_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Numero") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV36TFCorNum;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV37TFCorNum_To;
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Tipo de Correlativo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Numero";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV44Configuracion_correlativoswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV45Configuracion_correlativoswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV46Configuracion_correlativoswwds_3_cortip1 = AV38CorTip1;
         AV47Configuracion_correlativoswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV48Configuracion_correlativoswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV49Configuracion_correlativoswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV50Configuracion_correlativoswwds_7_cortip2 = AV39CorTip2;
         AV51Configuracion_correlativoswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV52Configuracion_correlativoswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV53Configuracion_correlativoswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV54Configuracion_correlativoswwds_11_cortip3 = AV40CorTip3;
         AV55Configuracion_correlativoswwds_12_tfcortip = AV34TFCorTip;
         AV56Configuracion_correlativoswwds_13_tfcortip_sel = AV35TFCorTip_Sel;
         AV57Configuracion_correlativoswwds_14_tfcornum = AV36TFCorNum;
         AV58Configuracion_correlativoswwds_15_tfcornum_to = AV37TFCorNum_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Configuracion_correlativoswwds_1_dynamicfiltersselector1 ,
                                              AV45Configuracion_correlativoswwds_2_dynamicfiltersoperator1 ,
                                              AV46Configuracion_correlativoswwds_3_cortip1 ,
                                              AV47Configuracion_correlativoswwds_4_dynamicfiltersenabled2 ,
                                              AV48Configuracion_correlativoswwds_5_dynamicfiltersselector2 ,
                                              AV49Configuracion_correlativoswwds_6_dynamicfiltersoperator2 ,
                                              AV50Configuracion_correlativoswwds_7_cortip2 ,
                                              AV51Configuracion_correlativoswwds_8_dynamicfiltersenabled3 ,
                                              AV52Configuracion_correlativoswwds_9_dynamicfiltersselector3 ,
                                              AV53Configuracion_correlativoswwds_10_dynamicfiltersoperator3 ,
                                              AV54Configuracion_correlativoswwds_11_cortip3 ,
                                              AV56Configuracion_correlativoswwds_13_tfcortip_sel ,
                                              AV55Configuracion_correlativoswwds_12_tfcortip ,
                                              AV57Configuracion_correlativoswwds_14_tfcornum ,
                                              AV58Configuracion_correlativoswwds_15_tfcornum_to ,
                                              A138CorTip ,
                                              A758CorNum ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV46Configuracion_correlativoswwds_3_cortip1 = StringUtil.PadR( StringUtil.RTrim( AV46Configuracion_correlativoswwds_3_cortip1), 10, "%");
         lV46Configuracion_correlativoswwds_3_cortip1 = StringUtil.PadR( StringUtil.RTrim( AV46Configuracion_correlativoswwds_3_cortip1), 10, "%");
         lV50Configuracion_correlativoswwds_7_cortip2 = StringUtil.PadR( StringUtil.RTrim( AV50Configuracion_correlativoswwds_7_cortip2), 10, "%");
         lV50Configuracion_correlativoswwds_7_cortip2 = StringUtil.PadR( StringUtil.RTrim( AV50Configuracion_correlativoswwds_7_cortip2), 10, "%");
         lV54Configuracion_correlativoswwds_11_cortip3 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_correlativoswwds_11_cortip3), 10, "%");
         lV54Configuracion_correlativoswwds_11_cortip3 = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_correlativoswwds_11_cortip3), 10, "%");
         lV55Configuracion_correlativoswwds_12_tfcortip = StringUtil.PadR( StringUtil.RTrim( AV55Configuracion_correlativoswwds_12_tfcortip), 10, "%");
         /* Using cursor P004Z2 */
         pr_default.execute(0, new Object[] {lV46Configuracion_correlativoswwds_3_cortip1, lV46Configuracion_correlativoswwds_3_cortip1, lV50Configuracion_correlativoswwds_7_cortip2, lV50Configuracion_correlativoswwds_7_cortip2, lV54Configuracion_correlativoswwds_11_cortip3, lV54Configuracion_correlativoswwds_11_cortip3, lV55Configuracion_correlativoswwds_12_tfcortip, AV56Configuracion_correlativoswwds_13_tfcortip_sel, AV57Configuracion_correlativoswwds_14_tfcornum, AV58Configuracion_correlativoswwds_15_tfcornum_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A758CorNum = P004Z2_A758CorNum[0];
            A138CorTip = P004Z2_A138CorTip[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A138CorTip, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = A758CorNum;
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.CorrelativosWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.CorrelativosWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.CorrelativosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCORTIP") == 0 )
            {
               AV34TFCorTip = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCORTIP_SEL") == 0 )
            {
               AV35TFCorTip_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCORNUM") == 0 )
            {
               AV36TFCorNum = (long)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV37TFCorNum_To = (long)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV59GXV1 = (int)(AV59GXV1+1);
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
         AV38CorTip1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV39CorTip2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV40CorTip3 = "";
         AV35TFCorTip_Sel = "";
         AV34TFCorTip = "";
         AV44Configuracion_correlativoswwds_1_dynamicfiltersselector1 = "";
         AV46Configuracion_correlativoswwds_3_cortip1 = "";
         AV48Configuracion_correlativoswwds_5_dynamicfiltersselector2 = "";
         AV50Configuracion_correlativoswwds_7_cortip2 = "";
         AV52Configuracion_correlativoswwds_9_dynamicfiltersselector3 = "";
         AV54Configuracion_correlativoswwds_11_cortip3 = "";
         AV55Configuracion_correlativoswwds_12_tfcortip = "";
         AV56Configuracion_correlativoswwds_13_tfcortip_sel = "";
         scmdbuf = "";
         lV46Configuracion_correlativoswwds_3_cortip1 = "";
         lV50Configuracion_correlativoswwds_7_cortip2 = "";
         lV54Configuracion_correlativoswwds_11_cortip3 = "";
         lV55Configuracion_correlativoswwds_12_tfcortip = "";
         A138CorTip = "";
         P004Z2_A758CorNum = new long[1] ;
         P004Z2_A138CorTip = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.correlativoswwexport__default(),
            new Object[][] {
                new Object[] {
               P004Z2_A758CorNum, P004Z2_A138CorTip
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
      private short AV45Configuracion_correlativoswwds_2_dynamicfiltersoperator1 ;
      private short AV49Configuracion_correlativoswwds_6_dynamicfiltersoperator2 ;
      private short AV53Configuracion_correlativoswwds_10_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV59GXV1 ;
      private long AV36TFCorNum ;
      private long AV37TFCorNum_To ;
      private long AV57Configuracion_correlativoswwds_14_tfcornum ;
      private long AV58Configuracion_correlativoswwds_15_tfcornum_to ;
      private long A758CorNum ;
      private string AV38CorTip1 ;
      private string AV39CorTip2 ;
      private string AV40CorTip3 ;
      private string AV35TFCorTip_Sel ;
      private string AV34TFCorTip ;
      private string AV46Configuracion_correlativoswwds_3_cortip1 ;
      private string AV50Configuracion_correlativoswwds_7_cortip2 ;
      private string AV54Configuracion_correlativoswwds_11_cortip3 ;
      private string AV55Configuracion_correlativoswwds_12_tfcortip ;
      private string AV56Configuracion_correlativoswwds_13_tfcortip_sel ;
      private string scmdbuf ;
      private string lV46Configuracion_correlativoswwds_3_cortip1 ;
      private string lV50Configuracion_correlativoswwds_7_cortip2 ;
      private string lV54Configuracion_correlativoswwds_11_cortip3 ;
      private string lV55Configuracion_correlativoswwds_12_tfcortip ;
      private string A138CorTip ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV47Configuracion_correlativoswwds_4_dynamicfiltersenabled2 ;
      private bool AV51Configuracion_correlativoswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV44Configuracion_correlativoswwds_1_dynamicfiltersselector1 ;
      private string AV48Configuracion_correlativoswwds_5_dynamicfiltersselector2 ;
      private string AV52Configuracion_correlativoswwds_9_dynamicfiltersselector3 ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P004Z2_A758CorNum ;
      private string[] P004Z2_A138CorTip ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class correlativoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004Z2( IGxContext context ,
                                             string AV44Configuracion_correlativoswwds_1_dynamicfiltersselector1 ,
                                             short AV45Configuracion_correlativoswwds_2_dynamicfiltersoperator1 ,
                                             string AV46Configuracion_correlativoswwds_3_cortip1 ,
                                             bool AV47Configuracion_correlativoswwds_4_dynamicfiltersenabled2 ,
                                             string AV48Configuracion_correlativoswwds_5_dynamicfiltersselector2 ,
                                             short AV49Configuracion_correlativoswwds_6_dynamicfiltersoperator2 ,
                                             string AV50Configuracion_correlativoswwds_7_cortip2 ,
                                             bool AV51Configuracion_correlativoswwds_8_dynamicfiltersenabled3 ,
                                             string AV52Configuracion_correlativoswwds_9_dynamicfiltersselector3 ,
                                             short AV53Configuracion_correlativoswwds_10_dynamicfiltersoperator3 ,
                                             string AV54Configuracion_correlativoswwds_11_cortip3 ,
                                             string AV56Configuracion_correlativoswwds_13_tfcortip_sel ,
                                             string AV55Configuracion_correlativoswwds_12_tfcortip ,
                                             long AV57Configuracion_correlativoswwds_14_tfcornum ,
                                             long AV58Configuracion_correlativoswwds_15_tfcornum_to ,
                                             string A138CorTip ,
                                             long A758CorNum ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [CorNum], [CorTip] FROM [CCORRELATIVOS]";
         if ( ( StringUtil.StrCmp(AV44Configuracion_correlativoswwds_1_dynamicfiltersselector1, "CORTIP") == 0 ) && ( AV45Configuracion_correlativoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Configuracion_correlativoswwds_3_cortip1)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like @lV46Configuracion_correlativoswwds_3_cortip1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV44Configuracion_correlativoswwds_1_dynamicfiltersselector1, "CORTIP") == 0 ) && ( AV45Configuracion_correlativoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Configuracion_correlativoswwds_3_cortip1)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like '%' + @lV46Configuracion_correlativoswwds_3_cortip1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV47Configuracion_correlativoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV48Configuracion_correlativoswwds_5_dynamicfiltersselector2, "CORTIP") == 0 ) && ( AV49Configuracion_correlativoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Configuracion_correlativoswwds_7_cortip2)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like @lV50Configuracion_correlativoswwds_7_cortip2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV47Configuracion_correlativoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV48Configuracion_correlativoswwds_5_dynamicfiltersselector2, "CORTIP") == 0 ) && ( AV49Configuracion_correlativoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Configuracion_correlativoswwds_7_cortip2)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like '%' + @lV50Configuracion_correlativoswwds_7_cortip2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV51Configuracion_correlativoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Configuracion_correlativoswwds_9_dynamicfiltersselector3, "CORTIP") == 0 ) && ( AV53Configuracion_correlativoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_correlativoswwds_11_cortip3)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like @lV54Configuracion_correlativoswwds_11_cortip3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV51Configuracion_correlativoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Configuracion_correlativoswwds_9_dynamicfiltersselector3, "CORTIP") == 0 ) && ( AV53Configuracion_correlativoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_correlativoswwds_11_cortip3)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like '%' + @lV54Configuracion_correlativoswwds_11_cortip3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_correlativoswwds_13_tfcortip_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_correlativoswwds_12_tfcortip)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like @lV55Configuracion_correlativoswwds_12_tfcortip)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_correlativoswwds_13_tfcortip_sel)) )
         {
            AddWhere(sWhereString, "([CorTip] = @AV56Configuracion_correlativoswwds_13_tfcortip_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (0==AV57Configuracion_correlativoswwds_14_tfcornum) )
         {
            AddWhere(sWhereString, "([CorNum] >= @AV57Configuracion_correlativoswwds_14_tfcornum)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV58Configuracion_correlativoswwds_15_tfcornum_to) )
         {
            AddWhere(sWhereString, "([CorNum] <= @AV58Configuracion_correlativoswwds_15_tfcornum_to)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CorTip]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CorTip] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CorNum]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CorNum] DESC";
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
                     return conditional_P004Z2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (short)dynConstraints[17] , (bool)dynConstraints[18] );
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
          Object[] prmP004Z2;
          prmP004Z2 = new Object[] {
          new ParDef("@lV46Configuracion_correlativoswwds_3_cortip1",GXType.NChar,10,0) ,
          new ParDef("@lV46Configuracion_correlativoswwds_3_cortip1",GXType.NChar,10,0) ,
          new ParDef("@lV50Configuracion_correlativoswwds_7_cortip2",GXType.NChar,10,0) ,
          new ParDef("@lV50Configuracion_correlativoswwds_7_cortip2",GXType.NChar,10,0) ,
          new ParDef("@lV54Configuracion_correlativoswwds_11_cortip3",GXType.NChar,10,0) ,
          new ParDef("@lV54Configuracion_correlativoswwds_11_cortip3",GXType.NChar,10,0) ,
          new ParDef("@lV55Configuracion_correlativoswwds_12_tfcortip",GXType.NChar,10,0) ,
          new ParDef("@AV56Configuracion_correlativoswwds_13_tfcortip_sel",GXType.NChar,10,0) ,
          new ParDef("@AV57Configuracion_correlativoswwds_14_tfcornum",GXType.Decimal,10,0) ,
          new ParDef("@AV58Configuracion_correlativoswwds_15_tfcornum_to",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Z2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                return;
       }
    }

 }

}
