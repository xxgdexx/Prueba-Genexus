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
   public class cuentabancoswwexport : GXProcedure
   {
      public cuentabancoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cuentabancoswwexport( IGxContext context )
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
         cuentabancoswwexport objcuentabancoswwexport;
         objcuentabancoswwexport = new cuentabancoswwexport();
         objcuentabancoswwexport.AV11Filename = "" ;
         objcuentabancoswwexport.AV12ErrorMessage = "" ;
         objcuentabancoswwexport.context.SetSubmitInitialConfig(context);
         objcuentabancoswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcuentabancoswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cuentabancoswwexport)stateInfo).executePrivate();
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
         AV11Filename = "CuentaBancosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "BANDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV55BanDsc1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55BanDsc1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55BanDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MONCOD") == 0 )
            {
               AV56MonCod1 = (int)(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."));
               if ( ! (0==AV56MonCod1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Moneda";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV56MonCod1;
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "BANDSC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV57BanDsc2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57BanDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57BanDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "MONCOD") == 0 )
               {
                  AV58MonCod2 = (int)(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."));
                  if ( ! (0==AV58MonCod2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Moneda";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV58MonCod2;
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "BANDSC") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV59BanDsc3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59BanDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV59BanDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "MONCOD") == 0 )
                  {
                     AV60MonCod3 = (int)(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."));
                     if ( ! (0==AV60MonCod3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Moneda";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV60MonCod3;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFBanDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Banco") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62TFBanDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFBanDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Banco") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV61TFBanDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCBCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "N° de Cuenta") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFCBCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCBCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "N° de Cuenta") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFCBCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFMonDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Moneda") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV64TFMonDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFMonDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Moneda") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV63TFMonDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV45TFCBSts) && (0==AV46TFCBSts_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV45TFCBSts;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV46TFCBSts_To;
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Banco";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "N° de Cuenta";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Moneda";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV72Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV73Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV74Bancos_cuentabancoswwds_3_bandsc1 = AV55BanDsc1;
         AV75Bancos_cuentabancoswwds_4_moncod1 = AV56MonCod1;
         AV76Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV77Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV78Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV79Bancos_cuentabancoswwds_8_bandsc2 = AV57BanDsc2;
         AV80Bancos_cuentabancoswwds_9_moncod2 = AV58MonCod2;
         AV81Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV82Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV83Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV84Bancos_cuentabancoswwds_13_bandsc3 = AV59BanDsc3;
         AV85Bancos_cuentabancoswwds_14_moncod3 = AV60MonCod3;
         AV86Bancos_cuentabancoswwds_15_tfbandsc = AV61TFBanDsc;
         AV87Bancos_cuentabancoswwds_16_tfbandsc_sel = AV62TFBanDsc_Sel;
         AV88Bancos_cuentabancoswwds_17_tfcbcod = AV39TFCBCod;
         AV89Bancos_cuentabancoswwds_18_tfcbcod_sel = AV40TFCBCod_Sel;
         AV90Bancos_cuentabancoswwds_19_tfmondsc = AV63TFMonDsc;
         AV91Bancos_cuentabancoswwds_20_tfmondsc_sel = AV64TFMonDsc_Sel;
         AV92Bancos_cuentabancoswwds_21_tfcbsts = AV45TFCBSts;
         AV93Bancos_cuentabancoswwds_22_tfcbsts_to = AV46TFCBSts_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV72Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ,
                                              AV73Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ,
                                              AV74Bancos_cuentabancoswwds_3_bandsc1 ,
                                              AV75Bancos_cuentabancoswwds_4_moncod1 ,
                                              AV76Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ,
                                              AV77Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ,
                                              AV78Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ,
                                              AV79Bancos_cuentabancoswwds_8_bandsc2 ,
                                              AV80Bancos_cuentabancoswwds_9_moncod2 ,
                                              AV81Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ,
                                              AV82Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ,
                                              AV83Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ,
                                              AV84Bancos_cuentabancoswwds_13_bandsc3 ,
                                              AV85Bancos_cuentabancoswwds_14_moncod3 ,
                                              AV87Bancos_cuentabancoswwds_16_tfbandsc_sel ,
                                              AV86Bancos_cuentabancoswwds_15_tfbandsc ,
                                              AV89Bancos_cuentabancoswwds_18_tfcbcod_sel ,
                                              AV88Bancos_cuentabancoswwds_17_tfcbcod ,
                                              AV91Bancos_cuentabancoswwds_20_tfmondsc_sel ,
                                              AV90Bancos_cuentabancoswwds_19_tfmondsc ,
                                              AV92Bancos_cuentabancoswwds_21_tfcbsts ,
                                              AV93Bancos_cuentabancoswwds_22_tfcbsts_to ,
                                              A482BanDsc ,
                                              A180MonCod ,
                                              A377CBCod ,
                                              A1234MonDsc ,
                                              A504CBSts ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Bancos_cuentabancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_cuentabancoswwds_3_bandsc1), 100, "%");
         lV74Bancos_cuentabancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_cuentabancoswwds_3_bandsc1), 100, "%");
         lV79Bancos_cuentabancoswwds_8_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV79Bancos_cuentabancoswwds_8_bandsc2), 100, "%");
         lV79Bancos_cuentabancoswwds_8_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV79Bancos_cuentabancoswwds_8_bandsc2), 100, "%");
         lV84Bancos_cuentabancoswwds_13_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV84Bancos_cuentabancoswwds_13_bandsc3), 100, "%");
         lV84Bancos_cuentabancoswwds_13_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV84Bancos_cuentabancoswwds_13_bandsc3), 100, "%");
         lV86Bancos_cuentabancoswwds_15_tfbandsc = StringUtil.PadR( StringUtil.RTrim( AV86Bancos_cuentabancoswwds_15_tfbandsc), 100, "%");
         lV88Bancos_cuentabancoswwds_17_tfcbcod = StringUtil.PadR( StringUtil.RTrim( AV88Bancos_cuentabancoswwds_17_tfcbcod), 20, "%");
         lV90Bancos_cuentabancoswwds_19_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV90Bancos_cuentabancoswwds_19_tfmondsc), 100, "%");
         /* Using cursor P005D2 */
         pr_default.execute(0, new Object[] {lV74Bancos_cuentabancoswwds_3_bandsc1, lV74Bancos_cuentabancoswwds_3_bandsc1, AV75Bancos_cuentabancoswwds_4_moncod1, lV79Bancos_cuentabancoswwds_8_bandsc2, lV79Bancos_cuentabancoswwds_8_bandsc2, AV80Bancos_cuentabancoswwds_9_moncod2, lV84Bancos_cuentabancoswwds_13_bandsc3, lV84Bancos_cuentabancoswwds_13_bandsc3, AV85Bancos_cuentabancoswwds_14_moncod3, lV86Bancos_cuentabancoswwds_15_tfbandsc, AV87Bancos_cuentabancoswwds_16_tfbandsc_sel, lV88Bancos_cuentabancoswwds_17_tfcbcod, AV89Bancos_cuentabancoswwds_18_tfcbcod_sel, lV90Bancos_cuentabancoswwds_19_tfmondsc, AV91Bancos_cuentabancoswwds_20_tfmondsc_sel, AV92Bancos_cuentabancoswwds_21_tfcbsts, AV93Bancos_cuentabancoswwds_22_tfcbsts_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A504CBSts = P005D2_A504CBSts[0];
            A1234MonDsc = P005D2_A1234MonDsc[0];
            A377CBCod = P005D2_A377CBCod[0];
            A180MonCod = P005D2_A180MonCod[0];
            A482BanDsc = P005D2_A482BanDsc[0];
            A372BanCod = P005D2_A372BanCod[0];
            A1234MonDsc = P005D2_A1234MonDsc[0];
            A482BanDsc = P005D2_A482BanDsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A482BanDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A377CBCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1234MonDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = A504CBSts;
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
         if ( StringUtil.StrCmp(AV33Session.Get("Bancos.CuentaBancosWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.CuentaBancosWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Bancos.CuentaBancosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV94GXV1 = 1;
         while ( AV94GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV94GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFBANDSC") == 0 )
            {
               AV61TFBanDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFBANDSC_SEL") == 0 )
            {
               AV62TFBanDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCBCOD") == 0 )
            {
               AV39TFCBCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCBCOD_SEL") == 0 )
            {
               AV40TFCBCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMONDSC") == 0 )
            {
               AV63TFMonDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMONDSC_SEL") == 0 )
            {
               AV64TFMonDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCBSTS") == 0 )
            {
               AV45TFCBSts = (short)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV46TFCBSts_To = (short)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV94GXV1 = (int)(AV94GXV1+1);
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
         AV55BanDsc1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV57BanDsc2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV59BanDsc3 = "";
         AV62TFBanDsc_Sel = "";
         AV61TFBanDsc = "";
         AV40TFCBCod_Sel = "";
         AV39TFCBCod = "";
         AV64TFMonDsc_Sel = "";
         AV63TFMonDsc = "";
         AV72Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = "";
         AV74Bancos_cuentabancoswwds_3_bandsc1 = "";
         AV77Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = "";
         AV79Bancos_cuentabancoswwds_8_bandsc2 = "";
         AV82Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = "";
         AV84Bancos_cuentabancoswwds_13_bandsc3 = "";
         AV86Bancos_cuentabancoswwds_15_tfbandsc = "";
         AV87Bancos_cuentabancoswwds_16_tfbandsc_sel = "";
         AV88Bancos_cuentabancoswwds_17_tfcbcod = "";
         AV89Bancos_cuentabancoswwds_18_tfcbcod_sel = "";
         AV90Bancos_cuentabancoswwds_19_tfmondsc = "";
         AV91Bancos_cuentabancoswwds_20_tfmondsc_sel = "";
         scmdbuf = "";
         lV74Bancos_cuentabancoswwds_3_bandsc1 = "";
         lV79Bancos_cuentabancoswwds_8_bandsc2 = "";
         lV84Bancos_cuentabancoswwds_13_bandsc3 = "";
         lV86Bancos_cuentabancoswwds_15_tfbandsc = "";
         lV88Bancos_cuentabancoswwds_17_tfcbcod = "";
         lV90Bancos_cuentabancoswwds_19_tfmondsc = "";
         A482BanDsc = "";
         A377CBCod = "";
         A1234MonDsc = "";
         P005D2_A504CBSts = new short[1] ;
         P005D2_A1234MonDsc = new string[] {""} ;
         P005D2_A377CBCod = new string[] {""} ;
         P005D2_A180MonCod = new int[1] ;
         P005D2_A482BanDsc = new string[] {""} ;
         P005D2_A372BanCod = new int[1] ;
         GXt_char1 = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.cuentabancoswwexport__default(),
            new Object[][] {
                new Object[] {
               P005D2_A504CBSts, P005D2_A1234MonDsc, P005D2_A377CBCod, P005D2_A180MonCod, P005D2_A482BanDsc, P005D2_A372BanCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV45TFCBSts ;
      private short AV46TFCBSts_To ;
      private short GXt_int2 ;
      private short AV73Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ;
      private short AV78Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ;
      private short AV83Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ;
      private short AV92Bancos_cuentabancoswwds_21_tfcbsts ;
      private short AV93Bancos_cuentabancoswwds_22_tfcbsts_to ;
      private short A504CBSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV56MonCod1 ;
      private int AV58MonCod2 ;
      private int AV60MonCod3 ;
      private int AV75Bancos_cuentabancoswwds_4_moncod1 ;
      private int AV80Bancos_cuentabancoswwds_9_moncod2 ;
      private int AV85Bancos_cuentabancoswwds_14_moncod3 ;
      private int A180MonCod ;
      private int A372BanCod ;
      private int AV94GXV1 ;
      private string AV55BanDsc1 ;
      private string AV57BanDsc2 ;
      private string AV59BanDsc3 ;
      private string AV62TFBanDsc_Sel ;
      private string AV61TFBanDsc ;
      private string AV40TFCBCod_Sel ;
      private string AV39TFCBCod ;
      private string AV64TFMonDsc_Sel ;
      private string AV63TFMonDsc ;
      private string AV74Bancos_cuentabancoswwds_3_bandsc1 ;
      private string AV79Bancos_cuentabancoswwds_8_bandsc2 ;
      private string AV84Bancos_cuentabancoswwds_13_bandsc3 ;
      private string AV86Bancos_cuentabancoswwds_15_tfbandsc ;
      private string AV87Bancos_cuentabancoswwds_16_tfbandsc_sel ;
      private string AV88Bancos_cuentabancoswwds_17_tfcbcod ;
      private string AV89Bancos_cuentabancoswwds_18_tfcbcod_sel ;
      private string AV90Bancos_cuentabancoswwds_19_tfmondsc ;
      private string AV91Bancos_cuentabancoswwds_20_tfmondsc_sel ;
      private string scmdbuf ;
      private string lV74Bancos_cuentabancoswwds_3_bandsc1 ;
      private string lV79Bancos_cuentabancoswwds_8_bandsc2 ;
      private string lV84Bancos_cuentabancoswwds_13_bandsc3 ;
      private string lV86Bancos_cuentabancoswwds_15_tfbandsc ;
      private string lV88Bancos_cuentabancoswwds_17_tfcbcod ;
      private string lV90Bancos_cuentabancoswwds_19_tfmondsc ;
      private string A482BanDsc ;
      private string A377CBCod ;
      private string A1234MonDsc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV76Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ;
      private bool AV81Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV72Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ;
      private string AV77Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ;
      private string AV82Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005D2_A504CBSts ;
      private string[] P005D2_A1234MonDsc ;
      private string[] P005D2_A377CBCod ;
      private int[] P005D2_A180MonCod ;
      private string[] P005D2_A482BanDsc ;
      private int[] P005D2_A372BanCod ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
   }

   public class cuentabancoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005D2( IGxContext context ,
                                             string AV72Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ,
                                             short AV73Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV74Bancos_cuentabancoswwds_3_bandsc1 ,
                                             int AV75Bancos_cuentabancoswwds_4_moncod1 ,
                                             bool AV76Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ,
                                             string AV77Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ,
                                             short AV78Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ,
                                             string AV79Bancos_cuentabancoswwds_8_bandsc2 ,
                                             int AV80Bancos_cuentabancoswwds_9_moncod2 ,
                                             bool AV81Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ,
                                             string AV82Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ,
                                             short AV83Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ,
                                             string AV84Bancos_cuentabancoswwds_13_bandsc3 ,
                                             int AV85Bancos_cuentabancoswwds_14_moncod3 ,
                                             string AV87Bancos_cuentabancoswwds_16_tfbandsc_sel ,
                                             string AV86Bancos_cuentabancoswwds_15_tfbandsc ,
                                             string AV89Bancos_cuentabancoswwds_18_tfcbcod_sel ,
                                             string AV88Bancos_cuentabancoswwds_17_tfcbcod ,
                                             string AV91Bancos_cuentabancoswwds_20_tfmondsc_sel ,
                                             string AV90Bancos_cuentabancoswwds_19_tfmondsc ,
                                             short AV92Bancos_cuentabancoswwds_21_tfcbsts ,
                                             short AV93Bancos_cuentabancoswwds_22_tfcbsts_to ,
                                             string A482BanDsc ,
                                             int A180MonCod ,
                                             string A377CBCod ,
                                             string A1234MonDsc ,
                                             short A504CBSts ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CBSts], T2.[MonDsc], T1.[CBCod], T1.[MonCod], T3.[BanDsc], T1.[BanCod] FROM (([TSCUENTABANCO] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[MonCod]) INNER JOIN [TSBANCOS] T3 ON T3.[BanCod] = T1.[BanCod])";
         if ( ( StringUtil.StrCmp(AV72Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV73Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_cuentabancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like @lV74Bancos_cuentabancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV73Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_cuentabancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like '%' + @lV74Bancos_cuentabancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "MONCOD") == 0 ) && ( ! (0==AV75Bancos_cuentabancoswwds_4_moncod1) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV75Bancos_cuentabancoswwds_4_moncod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV76Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV78Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_cuentabancoswwds_8_bandsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like @lV79Bancos_cuentabancoswwds_8_bandsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV76Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV78Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_cuentabancoswwds_8_bandsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like '%' + @lV79Bancos_cuentabancoswwds_8_bandsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV76Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "MONCOD") == 0 ) && ( ! (0==AV80Bancos_cuentabancoswwds_9_moncod2) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV80Bancos_cuentabancoswwds_9_moncod2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV81Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV83Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Bancos_cuentabancoswwds_13_bandsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like @lV84Bancos_cuentabancoswwds_13_bandsc3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV81Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV83Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Bancos_cuentabancoswwds_13_bandsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like '%' + @lV84Bancos_cuentabancoswwds_13_bandsc3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV81Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "MONCOD") == 0 ) && ( ! (0==AV85Bancos_cuentabancoswwds_14_moncod3) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV85Bancos_cuentabancoswwds_14_moncod3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Bancos_cuentabancoswwds_16_tfbandsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Bancos_cuentabancoswwds_15_tfbandsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like @lV86Bancos_cuentabancoswwds_15_tfbandsc)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Bancos_cuentabancoswwds_16_tfbandsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] = @AV87Bancos_cuentabancoswwds_16_tfbandsc_sel)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Bancos_cuentabancoswwds_18_tfcbcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Bancos_cuentabancoswwds_17_tfcbcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBCod] like @lV88Bancos_cuentabancoswwds_17_tfcbcod)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Bancos_cuentabancoswwds_18_tfcbcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CBCod] = @AV89Bancos_cuentabancoswwds_18_tfcbcod_sel)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_cuentabancoswwds_20_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_cuentabancoswwds_19_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV90Bancos_cuentabancoswwds_19_tfmondsc)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_cuentabancoswwds_20_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] = @AV91Bancos_cuentabancoswwds_20_tfmondsc_sel)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (0==AV92Bancos_cuentabancoswwds_21_tfcbsts) )
         {
            AddWhere(sWhereString, "(T1.[CBSts] >= @AV92Bancos_cuentabancoswwds_21_tfcbsts)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (0==AV93Bancos_cuentabancoswwds_22_tfcbsts_to) )
         {
            AddWhere(sWhereString, "(T1.[CBSts] <= @AV93Bancos_cuentabancoswwds_22_tfcbsts_to)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[BanCod], T1.[CBCod]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[BanDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[BanDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CBCod]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CBCod] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MonDsc]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MonDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CBSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CBSts] DESC";
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
                     return conditional_P005D2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
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
          Object[] prmP005D2;
          prmP005D2 = new Object[] {
          new ParDef("@lV74Bancos_cuentabancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV74Bancos_cuentabancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@AV75Bancos_cuentabancoswwds_4_moncod1",GXType.Int32,6,0) ,
          new ParDef("@lV79Bancos_cuentabancoswwds_8_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV79Bancos_cuentabancoswwds_8_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@AV80Bancos_cuentabancoswwds_9_moncod2",GXType.Int32,6,0) ,
          new ParDef("@lV84Bancos_cuentabancoswwds_13_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@lV84Bancos_cuentabancoswwds_13_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@AV85Bancos_cuentabancoswwds_14_moncod3",GXType.Int32,6,0) ,
          new ParDef("@lV86Bancos_cuentabancoswwds_15_tfbandsc",GXType.NChar,100,0) ,
          new ParDef("@AV87Bancos_cuentabancoswwds_16_tfbandsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV88Bancos_cuentabancoswwds_17_tfcbcod",GXType.NChar,20,0) ,
          new ParDef("@AV89Bancos_cuentabancoswwds_18_tfcbcod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV90Bancos_cuentabancoswwds_19_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV91Bancos_cuentabancoswwds_20_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV92Bancos_cuentabancoswwds_21_tfcbsts",GXType.Int16,1,0) ,
          new ParDef("@AV93Bancos_cuentabancoswwds_22_tfcbsts_to",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005D2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
