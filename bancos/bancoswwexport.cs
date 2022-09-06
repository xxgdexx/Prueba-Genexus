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
   public class bancoswwexport : GXProcedure
   {
      public bancoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public bancoswwexport( IGxContext context )
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
         bancoswwexport objbancoswwexport;
         objbancoswwexport = new bancoswwexport();
         objbancoswwexport.AV11Filename = "" ;
         objbancoswwexport.AV12ErrorMessage = "" ;
         objbancoswwexport.context.SetSubmitInitialConfig(context);
         objbancoswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objbancoswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((bancoswwexport)stateInfo).executePrivate();
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
         AV11Filename = "BancosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "BANDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20BanDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20BanDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20BanDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "BANDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24BanDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24BanDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24BanDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "BANDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28BanDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28BanDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28BanDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFBanCod) && (0==AV35TFBanCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFBanCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFBanCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFBanDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Banco") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFBanDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFBanDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Banco") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFBanDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFBanAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFBanAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFBanAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Abreviatura") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFBanAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFBanSunat_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sunat") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFBanSunat_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFBanSunat)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sunat") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFBanSunat, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV40TFBanSts) && (0==AV41TFBanSts_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV40TFBanSts;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV41TFBanSts_To;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Banco";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Abreviatura";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Codigo Sunat";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV51Bancos_bancoswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV52Bancos_bancoswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV53Bancos_bancoswwds_3_bandsc1 = AV20BanDsc1;
         AV54Bancos_bancoswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV55Bancos_bancoswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV56Bancos_bancoswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV57Bancos_bancoswwds_7_bandsc2 = AV24BanDsc2;
         AV58Bancos_bancoswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV59Bancos_bancoswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV60Bancos_bancoswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV61Bancos_bancoswwds_11_bandsc3 = AV28BanDsc3;
         AV62Bancos_bancoswwds_12_tfbancod = AV34TFBanCod;
         AV63Bancos_bancoswwds_13_tfbancod_to = AV35TFBanCod_To;
         AV64Bancos_bancoswwds_14_tfbandsc = AV36TFBanDsc;
         AV65Bancos_bancoswwds_15_tfbandsc_sel = AV37TFBanDsc_Sel;
         AV66Bancos_bancoswwds_16_tfbanabr = AV38TFBanAbr;
         AV67Bancos_bancoswwds_17_tfbanabr_sel = AV39TFBanAbr_Sel;
         AV68Bancos_bancoswwds_18_tfbansunat = AV42TFBanSunat;
         AV69Bancos_bancoswwds_19_tfbansunat_sel = AV43TFBanSunat_Sel;
         AV70Bancos_bancoswwds_20_tfbansts = AV40TFBanSts;
         AV71Bancos_bancoswwds_21_tfbansts_to = AV41TFBanSts_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV51Bancos_bancoswwds_1_dynamicfiltersselector1 ,
                                              AV52Bancos_bancoswwds_2_dynamicfiltersoperator1 ,
                                              AV53Bancos_bancoswwds_3_bandsc1 ,
                                              AV54Bancos_bancoswwds_4_dynamicfiltersenabled2 ,
                                              AV55Bancos_bancoswwds_5_dynamicfiltersselector2 ,
                                              AV56Bancos_bancoswwds_6_dynamicfiltersoperator2 ,
                                              AV57Bancos_bancoswwds_7_bandsc2 ,
                                              AV58Bancos_bancoswwds_8_dynamicfiltersenabled3 ,
                                              AV59Bancos_bancoswwds_9_dynamicfiltersselector3 ,
                                              AV60Bancos_bancoswwds_10_dynamicfiltersoperator3 ,
                                              AV61Bancos_bancoswwds_11_bandsc3 ,
                                              AV62Bancos_bancoswwds_12_tfbancod ,
                                              AV63Bancos_bancoswwds_13_tfbancod_to ,
                                              AV65Bancos_bancoswwds_15_tfbandsc_sel ,
                                              AV64Bancos_bancoswwds_14_tfbandsc ,
                                              AV67Bancos_bancoswwds_17_tfbanabr_sel ,
                                              AV66Bancos_bancoswwds_16_tfbanabr ,
                                              AV69Bancos_bancoswwds_19_tfbansunat_sel ,
                                              AV68Bancos_bancoswwds_18_tfbansunat ,
                                              AV70Bancos_bancoswwds_20_tfbansts ,
                                              AV71Bancos_bancoswwds_21_tfbansts_to ,
                                              A482BanDsc ,
                                              A372BanCod ,
                                              A481BanAbr ,
                                              A484BanSunat ,
                                              A483BanSts ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV53Bancos_bancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Bancos_bancoswwds_3_bandsc1), 100, "%");
         lV53Bancos_bancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Bancos_bancoswwds_3_bandsc1), 100, "%");
         lV57Bancos_bancoswwds_7_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Bancos_bancoswwds_7_bandsc2), 100, "%");
         lV57Bancos_bancoswwds_7_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Bancos_bancoswwds_7_bandsc2), 100, "%");
         lV61Bancos_bancoswwds_11_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_bancoswwds_11_bandsc3), 100, "%");
         lV61Bancos_bancoswwds_11_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_bancoswwds_11_bandsc3), 100, "%");
         lV64Bancos_bancoswwds_14_tfbandsc = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_bancoswwds_14_tfbandsc), 100, "%");
         lV66Bancos_bancoswwds_16_tfbanabr = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_bancoswwds_16_tfbanabr), 5, "%");
         lV68Bancos_bancoswwds_18_tfbansunat = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_bancoswwds_18_tfbansunat), 5, "%");
         /* Using cursor P005A2 */
         pr_default.execute(0, new Object[] {lV53Bancos_bancoswwds_3_bandsc1, lV53Bancos_bancoswwds_3_bandsc1, lV57Bancos_bancoswwds_7_bandsc2, lV57Bancos_bancoswwds_7_bandsc2, lV61Bancos_bancoswwds_11_bandsc3, lV61Bancos_bancoswwds_11_bandsc3, AV62Bancos_bancoswwds_12_tfbancod, AV63Bancos_bancoswwds_13_tfbancod_to, lV64Bancos_bancoswwds_14_tfbandsc, AV65Bancos_bancoswwds_15_tfbandsc_sel, lV66Bancos_bancoswwds_16_tfbanabr, AV67Bancos_bancoswwds_17_tfbanabr_sel, lV68Bancos_bancoswwds_18_tfbansunat, AV69Bancos_bancoswwds_19_tfbansunat_sel, AV70Bancos_bancoswwds_20_tfbansts, AV71Bancos_bancoswwds_21_tfbansts_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A483BanSts = P005A2_A483BanSts[0];
            A484BanSunat = P005A2_A484BanSunat[0];
            A481BanAbr = P005A2_A481BanAbr[0];
            A372BanCod = P005A2_A372BanCod[0];
            A482BanDsc = P005A2_A482BanDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A372BanCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A482BanDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A481BanAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A484BanSunat, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = A483BanSts;
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
         if ( StringUtil.StrCmp(AV30Session.Get("Bancos.BancosWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.BancosWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Bancos.BancosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV72GXV1 = 1;
         while ( AV72GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV72GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFBANCOD") == 0 )
            {
               AV34TFBanCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFBanCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFBANDSC") == 0 )
            {
               AV36TFBanDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFBANDSC_SEL") == 0 )
            {
               AV37TFBanDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFBANABR") == 0 )
            {
               AV38TFBanAbr = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFBANABR_SEL") == 0 )
            {
               AV39TFBanAbr_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFBANSUNAT") == 0 )
            {
               AV42TFBanSunat = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFBANSUNAT_SEL") == 0 )
            {
               AV43TFBanSunat_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFBANSTS") == 0 )
            {
               AV40TFBanSts = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV41TFBanSts_To = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV72GXV1 = (int)(AV72GXV1+1);
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
         AV20BanDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24BanDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28BanDsc3 = "";
         AV37TFBanDsc_Sel = "";
         AV36TFBanDsc = "";
         AV39TFBanAbr_Sel = "";
         AV38TFBanAbr = "";
         AV43TFBanSunat_Sel = "";
         AV42TFBanSunat = "";
         AV51Bancos_bancoswwds_1_dynamicfiltersselector1 = "";
         AV53Bancos_bancoswwds_3_bandsc1 = "";
         AV55Bancos_bancoswwds_5_dynamicfiltersselector2 = "";
         AV57Bancos_bancoswwds_7_bandsc2 = "";
         AV59Bancos_bancoswwds_9_dynamicfiltersselector3 = "";
         AV61Bancos_bancoswwds_11_bandsc3 = "";
         AV64Bancos_bancoswwds_14_tfbandsc = "";
         AV65Bancos_bancoswwds_15_tfbandsc_sel = "";
         AV66Bancos_bancoswwds_16_tfbanabr = "";
         AV67Bancos_bancoswwds_17_tfbanabr_sel = "";
         AV68Bancos_bancoswwds_18_tfbansunat = "";
         AV69Bancos_bancoswwds_19_tfbansunat_sel = "";
         scmdbuf = "";
         lV53Bancos_bancoswwds_3_bandsc1 = "";
         lV57Bancos_bancoswwds_7_bandsc2 = "";
         lV61Bancos_bancoswwds_11_bandsc3 = "";
         lV64Bancos_bancoswwds_14_tfbandsc = "";
         lV66Bancos_bancoswwds_16_tfbanabr = "";
         lV68Bancos_bancoswwds_18_tfbansunat = "";
         A482BanDsc = "";
         A481BanAbr = "";
         A484BanSunat = "";
         P005A2_A483BanSts = new short[1] ;
         P005A2_A484BanSunat = new string[] {""} ;
         P005A2_A481BanAbr = new string[] {""} ;
         P005A2_A372BanCod = new int[1] ;
         P005A2_A482BanDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.bancoswwexport__default(),
            new Object[][] {
                new Object[] {
               P005A2_A483BanSts, P005A2_A484BanSunat, P005A2_A481BanAbr, P005A2_A372BanCod, P005A2_A482BanDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV40TFBanSts ;
      private short AV41TFBanSts_To ;
      private short GXt_int2 ;
      private short AV52Bancos_bancoswwds_2_dynamicfiltersoperator1 ;
      private short AV56Bancos_bancoswwds_6_dynamicfiltersoperator2 ;
      private short AV60Bancos_bancoswwds_10_dynamicfiltersoperator3 ;
      private short AV70Bancos_bancoswwds_20_tfbansts ;
      private short AV71Bancos_bancoswwds_21_tfbansts_to ;
      private short A483BanSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFBanCod ;
      private int AV35TFBanCod_To ;
      private int AV62Bancos_bancoswwds_12_tfbancod ;
      private int AV63Bancos_bancoswwds_13_tfbancod_to ;
      private int A372BanCod ;
      private int AV72GXV1 ;
      private string AV20BanDsc1 ;
      private string AV24BanDsc2 ;
      private string AV28BanDsc3 ;
      private string AV37TFBanDsc_Sel ;
      private string AV36TFBanDsc ;
      private string AV39TFBanAbr_Sel ;
      private string AV38TFBanAbr ;
      private string AV43TFBanSunat_Sel ;
      private string AV42TFBanSunat ;
      private string AV53Bancos_bancoswwds_3_bandsc1 ;
      private string AV57Bancos_bancoswwds_7_bandsc2 ;
      private string AV61Bancos_bancoswwds_11_bandsc3 ;
      private string AV64Bancos_bancoswwds_14_tfbandsc ;
      private string AV65Bancos_bancoswwds_15_tfbandsc_sel ;
      private string AV66Bancos_bancoswwds_16_tfbanabr ;
      private string AV67Bancos_bancoswwds_17_tfbanabr_sel ;
      private string AV68Bancos_bancoswwds_18_tfbansunat ;
      private string AV69Bancos_bancoswwds_19_tfbansunat_sel ;
      private string scmdbuf ;
      private string lV53Bancos_bancoswwds_3_bandsc1 ;
      private string lV57Bancos_bancoswwds_7_bandsc2 ;
      private string lV61Bancos_bancoswwds_11_bandsc3 ;
      private string lV64Bancos_bancoswwds_14_tfbandsc ;
      private string lV66Bancos_bancoswwds_16_tfbanabr ;
      private string lV68Bancos_bancoswwds_18_tfbansunat ;
      private string A482BanDsc ;
      private string A481BanAbr ;
      private string A484BanSunat ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV54Bancos_bancoswwds_4_dynamicfiltersenabled2 ;
      private bool AV58Bancos_bancoswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV51Bancos_bancoswwds_1_dynamicfiltersselector1 ;
      private string AV55Bancos_bancoswwds_5_dynamicfiltersselector2 ;
      private string AV59Bancos_bancoswwds_9_dynamicfiltersselector3 ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005A2_A483BanSts ;
      private string[] P005A2_A484BanSunat ;
      private string[] P005A2_A481BanAbr ;
      private int[] P005A2_A372BanCod ;
      private string[] P005A2_A482BanDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class bancoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005A2( IGxContext context ,
                                             string AV51Bancos_bancoswwds_1_dynamicfiltersselector1 ,
                                             short AV52Bancos_bancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV53Bancos_bancoswwds_3_bandsc1 ,
                                             bool AV54Bancos_bancoswwds_4_dynamicfiltersenabled2 ,
                                             string AV55Bancos_bancoswwds_5_dynamicfiltersselector2 ,
                                             short AV56Bancos_bancoswwds_6_dynamicfiltersoperator2 ,
                                             string AV57Bancos_bancoswwds_7_bandsc2 ,
                                             bool AV58Bancos_bancoswwds_8_dynamicfiltersenabled3 ,
                                             string AV59Bancos_bancoswwds_9_dynamicfiltersselector3 ,
                                             short AV60Bancos_bancoswwds_10_dynamicfiltersoperator3 ,
                                             string AV61Bancos_bancoswwds_11_bandsc3 ,
                                             int AV62Bancos_bancoswwds_12_tfbancod ,
                                             int AV63Bancos_bancoswwds_13_tfbancod_to ,
                                             string AV65Bancos_bancoswwds_15_tfbandsc_sel ,
                                             string AV64Bancos_bancoswwds_14_tfbandsc ,
                                             string AV67Bancos_bancoswwds_17_tfbanabr_sel ,
                                             string AV66Bancos_bancoswwds_16_tfbanabr ,
                                             string AV69Bancos_bancoswwds_19_tfbansunat_sel ,
                                             string AV68Bancos_bancoswwds_18_tfbansunat ,
                                             short AV70Bancos_bancoswwds_20_tfbansts ,
                                             short AV71Bancos_bancoswwds_21_tfbansts_to ,
                                             string A482BanDsc ,
                                             int A372BanCod ,
                                             string A481BanAbr ,
                                             string A484BanSunat ,
                                             short A483BanSts ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [BanSts], [BanSunat], [BanAbr], [BanCod], [BanDsc] FROM [TSBANCOS]";
         if ( ( StringUtil.StrCmp(AV51Bancos_bancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV52Bancos_bancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Bancos_bancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV53Bancos_bancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Bancos_bancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV52Bancos_bancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Bancos_bancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV53Bancos_bancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV54Bancos_bancoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Bancos_bancoswwds_5_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV56Bancos_bancoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Bancos_bancoswwds_7_bandsc2)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV57Bancos_bancoswwds_7_bandsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV54Bancos_bancoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Bancos_bancoswwds_5_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV56Bancos_bancoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Bancos_bancoswwds_7_bandsc2)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV57Bancos_bancoswwds_7_bandsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV58Bancos_bancoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Bancos_bancoswwds_9_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV60Bancos_bancoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_bancoswwds_11_bandsc3)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV61Bancos_bancoswwds_11_bandsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV58Bancos_bancoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Bancos_bancoswwds_9_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV60Bancos_bancoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_bancoswwds_11_bandsc3)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV61Bancos_bancoswwds_11_bandsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV62Bancos_bancoswwds_12_tfbancod) )
         {
            AddWhere(sWhereString, "([BanCod] >= @AV62Bancos_bancoswwds_12_tfbancod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV63Bancos_bancoswwds_13_tfbancod_to) )
         {
            AddWhere(sWhereString, "([BanCod] <= @AV63Bancos_bancoswwds_13_tfbancod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_bancoswwds_15_tfbandsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_bancoswwds_14_tfbandsc)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV64Bancos_bancoswwds_14_tfbandsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_bancoswwds_15_tfbandsc_sel)) )
         {
            AddWhere(sWhereString, "([BanDsc] = @AV65Bancos_bancoswwds_15_tfbandsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Bancos_bancoswwds_17_tfbanabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_bancoswwds_16_tfbanabr)) ) )
         {
            AddWhere(sWhereString, "([BanAbr] like @lV66Bancos_bancoswwds_16_tfbanabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Bancos_bancoswwds_17_tfbanabr_sel)) )
         {
            AddWhere(sWhereString, "([BanAbr] = @AV67Bancos_bancoswwds_17_tfbanabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_bancoswwds_19_tfbansunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_bancoswwds_18_tfbansunat)) ) )
         {
            AddWhere(sWhereString, "([BanSunat] like @lV68Bancos_bancoswwds_18_tfbansunat)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_bancoswwds_19_tfbansunat_sel)) )
         {
            AddWhere(sWhereString, "([BanSunat] = @AV69Bancos_bancoswwds_19_tfbansunat_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (0==AV70Bancos_bancoswwds_20_tfbansts) )
         {
            AddWhere(sWhereString, "([BanSts] >= @AV70Bancos_bancoswwds_20_tfbansts)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (0==AV71Bancos_bancoswwds_21_tfbansts_to) )
         {
            AddWhere(sWhereString, "([BanSts] <= @AV71Bancos_bancoswwds_21_tfbansts_to)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [BanCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [BanCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [BanDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [BanDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [BanAbr]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [BanAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [BanSunat]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [BanSunat] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [BanSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [BanSts] DESC";
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
                     return conditional_P005A2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP005A2;
          prmP005A2 = new Object[] {
          new ParDef("@lV53Bancos_bancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Bancos_bancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Bancos_bancoswwds_7_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Bancos_bancoswwds_7_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_bancoswwds_11_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_bancoswwds_11_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@AV62Bancos_bancoswwds_12_tfbancod",GXType.Int32,6,0) ,
          new ParDef("@AV63Bancos_bancoswwds_13_tfbancod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Bancos_bancoswwds_14_tfbandsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Bancos_bancoswwds_15_tfbandsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV66Bancos_bancoswwds_16_tfbanabr",GXType.NChar,5,0) ,
          new ParDef("@AV67Bancos_bancoswwds_17_tfbanabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV68Bancos_bancoswwds_18_tfbansunat",GXType.NChar,5,0) ,
          new ParDef("@AV69Bancos_bancoswwds_19_tfbansunat_sel",GXType.NChar,5,0) ,
          new ParDef("@AV70Bancos_bancoswwds_20_tfbansts",GXType.Int16,1,0) ,
          new ParDef("@AV71Bancos_bancoswwds_21_tfbansts_to",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005A2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
