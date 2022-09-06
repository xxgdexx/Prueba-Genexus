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
   public class areaswwexport : GXProcedure
   {
      public areaswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public areaswwexport( IGxContext context )
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
         areaswwexport objareaswwexport;
         objareaswwexport = new areaswwexport();
         objareaswwexport.AV11Filename = "" ;
         objareaswwexport.AV12ErrorMessage = "" ;
         objareaswwexport.context.SetSubmitInitialConfig(context);
         objareaswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objareaswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((areaswwexport)stateInfo).executePrivate();
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
         AV11Filename = "AreasWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "AREDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20AreDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20AreDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Area de la Empresa", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Area de la Empresa", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20AreDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "AREDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24AreDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24AreDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Area de la Empresa", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Area de la Empresa", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24AreDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "AREDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28AreDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28AreDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Area de la Empresa", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Area de la Empresa", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28AreDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFAreCod) && (0==AV35TFAreCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFAreCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFAreCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFAreDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Area de la Empresa") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFAreDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFAreDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Area de la Empresa") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFAreDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV41TFAreSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV43i = 1;
            AV46GXV1 = 1;
            while ( AV46GXV1 <= AV41TFAreSts_Sels.Count )
            {
               AV42TFAreSts_Sel = (short)(AV41TFAreSts_Sels.GetNumeric(AV46GXV1));
               if ( AV43i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV42TFAreSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV42TFAreSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV43i = (long)(AV43i+1);
               AV46GXV1 = (int)(AV46GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Area de la Empresa";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV48Configuracion_areaswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV49Configuracion_areaswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV50Configuracion_areaswwds_3_aredsc1 = AV20AreDsc1;
         AV51Configuracion_areaswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV52Configuracion_areaswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV53Configuracion_areaswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV54Configuracion_areaswwds_7_aredsc2 = AV24AreDsc2;
         AV55Configuracion_areaswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV56Configuracion_areaswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV57Configuracion_areaswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV58Configuracion_areaswwds_11_aredsc3 = AV28AreDsc3;
         AV59Configuracion_areaswwds_12_tfarecod = AV34TFAreCod;
         AV60Configuracion_areaswwds_13_tfarecod_to = AV35TFAreCod_To;
         AV61Configuracion_areaswwds_14_tfaredsc = AV36TFAreDsc;
         AV62Configuracion_areaswwds_15_tfaredsc_sel = AV37TFAreDsc_Sel;
         AV63Configuracion_areaswwds_16_tfarests_sels = AV41TFAreSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A475AreSts ,
                                              AV63Configuracion_areaswwds_16_tfarests_sels ,
                                              AV48Configuracion_areaswwds_1_dynamicfiltersselector1 ,
                                              AV49Configuracion_areaswwds_2_dynamicfiltersoperator1 ,
                                              AV50Configuracion_areaswwds_3_aredsc1 ,
                                              AV51Configuracion_areaswwds_4_dynamicfiltersenabled2 ,
                                              AV52Configuracion_areaswwds_5_dynamicfiltersselector2 ,
                                              AV53Configuracion_areaswwds_6_dynamicfiltersoperator2 ,
                                              AV54Configuracion_areaswwds_7_aredsc2 ,
                                              AV55Configuracion_areaswwds_8_dynamicfiltersenabled3 ,
                                              AV56Configuracion_areaswwds_9_dynamicfiltersselector3 ,
                                              AV57Configuracion_areaswwds_10_dynamicfiltersoperator3 ,
                                              AV58Configuracion_areaswwds_11_aredsc3 ,
                                              AV59Configuracion_areaswwds_12_tfarecod ,
                                              AV60Configuracion_areaswwds_13_tfarecod_to ,
                                              AV62Configuracion_areaswwds_15_tfaredsc_sel ,
                                              AV61Configuracion_areaswwds_14_tfaredsc ,
                                              AV63Configuracion_areaswwds_16_tfarests_sels.Count ,
                                              A474AreDsc ,
                                              A69AreCod ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV50Configuracion_areaswwds_3_aredsc1 = StringUtil.Concat( StringUtil.RTrim( AV50Configuracion_areaswwds_3_aredsc1), "%", "");
         lV50Configuracion_areaswwds_3_aredsc1 = StringUtil.Concat( StringUtil.RTrim( AV50Configuracion_areaswwds_3_aredsc1), "%", "");
         lV54Configuracion_areaswwds_7_aredsc2 = StringUtil.Concat( StringUtil.RTrim( AV54Configuracion_areaswwds_7_aredsc2), "%", "");
         lV54Configuracion_areaswwds_7_aredsc2 = StringUtil.Concat( StringUtil.RTrim( AV54Configuracion_areaswwds_7_aredsc2), "%", "");
         lV58Configuracion_areaswwds_11_aredsc3 = StringUtil.Concat( StringUtil.RTrim( AV58Configuracion_areaswwds_11_aredsc3), "%", "");
         lV58Configuracion_areaswwds_11_aredsc3 = StringUtil.Concat( StringUtil.RTrim( AV58Configuracion_areaswwds_11_aredsc3), "%", "");
         lV61Configuracion_areaswwds_14_tfaredsc = StringUtil.Concat( StringUtil.RTrim( AV61Configuracion_areaswwds_14_tfaredsc), "%", "");
         /* Using cursor P004V2 */
         pr_default.execute(0, new Object[] {lV50Configuracion_areaswwds_3_aredsc1, lV50Configuracion_areaswwds_3_aredsc1, lV54Configuracion_areaswwds_7_aredsc2, lV54Configuracion_areaswwds_7_aredsc2, lV58Configuracion_areaswwds_11_aredsc3, lV58Configuracion_areaswwds_11_aredsc3, AV59Configuracion_areaswwds_12_tfarecod, AV60Configuracion_areaswwds_13_tfarecod_to, lV61Configuracion_areaswwds_14_tfaredsc, AV62Configuracion_areaswwds_15_tfaredsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A475AreSts = P004V2_A475AreSts[0];
            A69AreCod = P004V2_A69AreCod[0];
            A474AreDsc = P004V2_A474AreDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A69AreCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A474AreDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( A475AreSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "ACTIVO";
            }
            else if ( A475AreSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "INACTIVO";
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.AreasWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.AreasWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.AreasWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV64GXV2 = 1;
         while ( AV64GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV64GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFARECOD") == 0 )
            {
               AV34TFAreCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFAreCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFAREDSC") == 0 )
            {
               AV36TFAreDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFAREDSC_SEL") == 0 )
            {
               AV37TFAreDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFARESTS_SEL") == 0 )
            {
               AV40TFAreSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV41TFAreSts_Sels.FromJSonString(AV40TFAreSts_SelsJson, null);
            }
            AV64GXV2 = (int)(AV64GXV2+1);
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
         AV20AreDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24AreDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28AreDsc3 = "";
         AV37TFAreDsc_Sel = "";
         AV36TFAreDsc = "";
         AV41TFAreSts_Sels = new GxSimpleCollection<short>();
         AV48Configuracion_areaswwds_1_dynamicfiltersselector1 = "";
         AV50Configuracion_areaswwds_3_aredsc1 = "";
         AV52Configuracion_areaswwds_5_dynamicfiltersselector2 = "";
         AV54Configuracion_areaswwds_7_aredsc2 = "";
         AV56Configuracion_areaswwds_9_dynamicfiltersselector3 = "";
         AV58Configuracion_areaswwds_11_aredsc3 = "";
         AV61Configuracion_areaswwds_14_tfaredsc = "";
         AV62Configuracion_areaswwds_15_tfaredsc_sel = "";
         AV63Configuracion_areaswwds_16_tfarests_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV50Configuracion_areaswwds_3_aredsc1 = "";
         lV54Configuracion_areaswwds_7_aredsc2 = "";
         lV58Configuracion_areaswwds_11_aredsc3 = "";
         lV61Configuracion_areaswwds_14_tfaredsc = "";
         A474AreDsc = "";
         P004V2_A475AreSts = new short[1] ;
         P004V2_A69AreCod = new int[1] ;
         P004V2_A474AreDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40TFAreSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.areaswwexport__default(),
            new Object[][] {
                new Object[] {
               P004V2_A475AreSts, P004V2_A69AreCod, P004V2_A474AreDsc
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
      private short AV42TFAreSts_Sel ;
      private short AV49Configuracion_areaswwds_2_dynamicfiltersoperator1 ;
      private short AV53Configuracion_areaswwds_6_dynamicfiltersoperator2 ;
      private short AV57Configuracion_areaswwds_10_dynamicfiltersoperator3 ;
      private short A475AreSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFAreCod ;
      private int AV35TFAreCod_To ;
      private int AV46GXV1 ;
      private int AV59Configuracion_areaswwds_12_tfarecod ;
      private int AV60Configuracion_areaswwds_13_tfarecod_to ;
      private int AV63Configuracion_areaswwds_16_tfarests_sels_Count ;
      private int A69AreCod ;
      private int AV64GXV2 ;
      private long AV43i ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV51Configuracion_areaswwds_4_dynamicfiltersenabled2 ;
      private bool AV55Configuracion_areaswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV40TFAreSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20AreDsc1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24AreDsc2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28AreDsc3 ;
      private string AV37TFAreDsc_Sel ;
      private string AV36TFAreDsc ;
      private string AV48Configuracion_areaswwds_1_dynamicfiltersselector1 ;
      private string AV50Configuracion_areaswwds_3_aredsc1 ;
      private string AV52Configuracion_areaswwds_5_dynamicfiltersselector2 ;
      private string AV54Configuracion_areaswwds_7_aredsc2 ;
      private string AV56Configuracion_areaswwds_9_dynamicfiltersselector3 ;
      private string AV58Configuracion_areaswwds_11_aredsc3 ;
      private string AV61Configuracion_areaswwds_14_tfaredsc ;
      private string AV62Configuracion_areaswwds_15_tfaredsc_sel ;
      private string lV50Configuracion_areaswwds_3_aredsc1 ;
      private string lV54Configuracion_areaswwds_7_aredsc2 ;
      private string lV58Configuracion_areaswwds_11_aredsc3 ;
      private string lV61Configuracion_areaswwds_14_tfaredsc ;
      private string A474AreDsc ;
      private GxSimpleCollection<short> AV41TFAreSts_Sels ;
      private GxSimpleCollection<short> AV63Configuracion_areaswwds_16_tfarests_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P004V2_A475AreSts ;
      private int[] P004V2_A69AreCod ;
      private string[] P004V2_A474AreDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class areaswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004V2( IGxContext context ,
                                             short A475AreSts ,
                                             GxSimpleCollection<short> AV63Configuracion_areaswwds_16_tfarests_sels ,
                                             string AV48Configuracion_areaswwds_1_dynamicfiltersselector1 ,
                                             short AV49Configuracion_areaswwds_2_dynamicfiltersoperator1 ,
                                             string AV50Configuracion_areaswwds_3_aredsc1 ,
                                             bool AV51Configuracion_areaswwds_4_dynamicfiltersenabled2 ,
                                             string AV52Configuracion_areaswwds_5_dynamicfiltersselector2 ,
                                             short AV53Configuracion_areaswwds_6_dynamicfiltersoperator2 ,
                                             string AV54Configuracion_areaswwds_7_aredsc2 ,
                                             bool AV55Configuracion_areaswwds_8_dynamicfiltersenabled3 ,
                                             string AV56Configuracion_areaswwds_9_dynamicfiltersselector3 ,
                                             short AV57Configuracion_areaswwds_10_dynamicfiltersoperator3 ,
                                             string AV58Configuracion_areaswwds_11_aredsc3 ,
                                             int AV59Configuracion_areaswwds_12_tfarecod ,
                                             int AV60Configuracion_areaswwds_13_tfarecod_to ,
                                             string AV62Configuracion_areaswwds_15_tfaredsc_sel ,
                                             string AV61Configuracion_areaswwds_14_tfaredsc ,
                                             int AV63Configuracion_areaswwds_16_tfarests_sels_Count ,
                                             string A474AreDsc ,
                                             int A69AreCod ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [AreSts], [AreCod], [AreDsc] FROM [CAREAS]";
         if ( ( StringUtil.StrCmp(AV48Configuracion_areaswwds_1_dynamicfiltersselector1, "AREDSC") == 0 ) && ( AV49Configuracion_areaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Configuracion_areaswwds_3_aredsc1)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like @lV50Configuracion_areaswwds_3_aredsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV48Configuracion_areaswwds_1_dynamicfiltersselector1, "AREDSC") == 0 ) && ( AV49Configuracion_areaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Configuracion_areaswwds_3_aredsc1)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like '%' + @lV50Configuracion_areaswwds_3_aredsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV51Configuracion_areaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV52Configuracion_areaswwds_5_dynamicfiltersselector2, "AREDSC") == 0 ) && ( AV53Configuracion_areaswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_areaswwds_7_aredsc2)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like @lV54Configuracion_areaswwds_7_aredsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV51Configuracion_areaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV52Configuracion_areaswwds_5_dynamicfiltersselector2, "AREDSC") == 0 ) && ( AV53Configuracion_areaswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_areaswwds_7_aredsc2)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like '%' + @lV54Configuracion_areaswwds_7_aredsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV55Configuracion_areaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Configuracion_areaswwds_9_dynamicfiltersselector3, "AREDSC") == 0 ) && ( AV57Configuracion_areaswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_areaswwds_11_aredsc3)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like @lV58Configuracion_areaswwds_11_aredsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV55Configuracion_areaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV56Configuracion_areaswwds_9_dynamicfiltersselector3, "AREDSC") == 0 ) && ( AV57Configuracion_areaswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_areaswwds_11_aredsc3)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like '%' + @lV58Configuracion_areaswwds_11_aredsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV59Configuracion_areaswwds_12_tfarecod) )
         {
            AddWhere(sWhereString, "([AreCod] >= @AV59Configuracion_areaswwds_12_tfarecod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV60Configuracion_areaswwds_13_tfarecod_to) )
         {
            AddWhere(sWhereString, "([AreCod] <= @AV60Configuracion_areaswwds_13_tfarecod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_areaswwds_15_tfaredsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_areaswwds_14_tfaredsc)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like @lV61Configuracion_areaswwds_14_tfaredsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_areaswwds_15_tfaredsc_sel)) )
         {
            AddWhere(sWhereString, "([AreDsc] = @AV62Configuracion_areaswwds_15_tfaredsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV63Configuracion_areaswwds_16_tfarests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV63Configuracion_areaswwds_16_tfarests_sels, "[AreSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [AreDsc]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AreDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [AreCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AreCod] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [AreSts]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [AreSts] DESC";
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
                     return conditional_P004V2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP004V2;
          prmP004V2 = new Object[] {
          new ParDef("@lV50Configuracion_areaswwds_3_aredsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV50Configuracion_areaswwds_3_aredsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Configuracion_areaswwds_7_aredsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Configuracion_areaswwds_7_aredsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV58Configuracion_areaswwds_11_aredsc3",GXType.NVarChar,100,0) ,
          new ParDef("@lV58Configuracion_areaswwds_11_aredsc3",GXType.NVarChar,100,0) ,
          new ParDef("@AV59Configuracion_areaswwds_12_tfarecod",GXType.Int32,6,0) ,
          new ParDef("@AV60Configuracion_areaswwds_13_tfarecod_to",GXType.Int32,6,0) ,
          new ParDef("@lV61Configuracion_areaswwds_14_tfaredsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV62Configuracion_areaswwds_15_tfaredsc_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004V2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
