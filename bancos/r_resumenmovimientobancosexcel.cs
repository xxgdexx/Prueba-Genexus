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
   public class r_resumenmovimientobancosexcel : GXProcedure
   {
      public r_resumenmovimientobancosexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenmovimientobancosexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_BanCod ,
                           ref DateTime aP1_FDesde ,
                           ref DateTime aP2_FHasta ,
                           ref int aP3_ConBCod ,
                           ref string aP4_TipADCod ,
                           out string aP5_Filename ,
                           out string aP6_ErrorMessage )
      {
         this.AV51BanCod = aP0_BanCod;
         this.AV50FDesde = aP1_FDesde;
         this.AV49FHasta = aP2_FHasta;
         this.AV48ConBCod = aP3_ConBCod;
         this.AV47TipADCod = aP4_TipADCod;
         this.AV23Filename = "" ;
         this.AV33ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_BanCod=this.AV51BanCod;
         aP1_FDesde=this.AV50FDesde;
         aP2_FHasta=this.AV49FHasta;
         aP3_ConBCod=this.AV48ConBCod;
         aP4_TipADCod=this.AV47TipADCod;
         aP5_Filename=this.AV23Filename;
         aP6_ErrorMessage=this.AV33ErrorMessage;
      }

      public string executeUdp( ref int aP0_BanCod ,
                                ref DateTime aP1_FDesde ,
                                ref DateTime aP2_FHasta ,
                                ref int aP3_ConBCod ,
                                ref string aP4_TipADCod ,
                                out string aP5_Filename )
      {
         execute(ref aP0_BanCod, ref aP1_FDesde, ref aP2_FHasta, ref aP3_ConBCod, ref aP4_TipADCod, out aP5_Filename, out aP6_ErrorMessage);
         return AV33ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_BanCod ,
                                 ref DateTime aP1_FDesde ,
                                 ref DateTime aP2_FHasta ,
                                 ref int aP3_ConBCod ,
                                 ref string aP4_TipADCod ,
                                 out string aP5_Filename ,
                                 out string aP6_ErrorMessage )
      {
         r_resumenmovimientobancosexcel objr_resumenmovimientobancosexcel;
         objr_resumenmovimientobancosexcel = new r_resumenmovimientobancosexcel();
         objr_resumenmovimientobancosexcel.AV51BanCod = aP0_BanCod;
         objr_resumenmovimientobancosexcel.AV50FDesde = aP1_FDesde;
         objr_resumenmovimientobancosexcel.AV49FHasta = aP2_FHasta;
         objr_resumenmovimientobancosexcel.AV48ConBCod = aP3_ConBCod;
         objr_resumenmovimientobancosexcel.AV47TipADCod = aP4_TipADCod;
         objr_resumenmovimientobancosexcel.AV23Filename = "" ;
         objr_resumenmovimientobancosexcel.AV33ErrorMessage = "" ;
         objr_resumenmovimientobancosexcel.context.SetSubmitInitialConfig(context);
         objr_resumenmovimientobancosexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenmovimientobancosexcel);
         aP0_BanCod=this.AV51BanCod;
         aP1_FDesde=this.AV50FDesde;
         aP2_FHasta=this.AV49FHasta;
         aP3_ConBCod=this.AV48ConBCod;
         aP4_TipADCod=this.AV47TipADCod;
         aP5_Filename=this.AV23Filename;
         aP6_ErrorMessage=this.AV33ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenmovimientobancosexcel)stateInfo).executePrivate();
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
         AV20Archivo.Source = "Excel/PlantillasResumenBancos.xlsx";
         AV21Path = AV20Archivo.GetPath();
         AV22FilenameOrigen = StringUtil.Trim( AV21Path) + "\\PlantillasResumenBancos.xlsx";
         AV23Filename = "Excel/ResumenBancos" + ".xlsx";
         AV24ExcelDocument.Clear();
         AV24ExcelDocument.Template = AV22FilenameOrigen;
         AV24ExcelDocument.Open(AV23Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV25CellRow = 5;
         AV26FirstColumn = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV51BanCod ,
                                              AV47TipADCod ,
                                              AV48ConBCod ,
                                              A379LBBanCod ,
                                              A1065LBDCueAux ,
                                              A386LBConBan ,
                                              A1079LBFech ,
                                              AV50FDesde ,
                                              AV49FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00AI2 */
         pr_default.execute(0, new Object[] {AV50FDesde, AV49FHasta, AV51BanCod, AV47TipADCod, AV48ConBCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A386LBConBan = P00AI2_A386LBConBan[0];
            A1079LBFech = P00AI2_A1079LBFech[0];
            A1065LBDCueAux = P00AI2_A1065LBDCueAux[0];
            A379LBBanCod = P00AI2_A379LBBanCod[0];
            A482BanDsc = P00AI2_A482BanDsc[0];
            n482BanDsc = P00AI2_n482BanDsc[0];
            A1233MonAbr = P00AI2_A1233MonAbr[0];
            n1233MonAbr = P00AI2_n1233MonAbr[0];
            A1085LBMonCod = P00AI2_A1085LBMonCod[0];
            A1075LBDocumento = P00AI2_A1075LBDocumento[0];
            A1087LBPrvCod = P00AI2_A1087LBPrvCod[0];
            A1092LBTipCod = P00AI2_A1092LBTipCod[0];
            A1068LBDDoc = P00AI2_A1068LBDDoc[0];
            A1067LBDDebe = P00AI2_A1067LBDDebe[0];
            A1074LBDHaber = P00AI2_A1074LBDHaber[0];
            A1091LBTipCmb = P00AI2_A1091LBTipCmb[0];
            A1057LBConcepto = P00AI2_A1057LBConcepto[0];
            A1058LBCueCod = P00AI2_A1058LBCueCod[0];
            A1064LBDConcepto = P00AI2_A1064LBDConcepto[0];
            A1054LBBeneficia = P00AI2_A1054LBBeneficia[0];
            A384LBDCosCod = P00AI2_A384LBDCosCod[0];
            n384LBDCosCod = P00AI2_n384LBDCosCod[0];
            A1077LBDTipCmb = P00AI2_A1077LBDTipCmb[0];
            A381LBRegistro = P00AI2_A381LBRegistro[0];
            A380LBCBCod = P00AI2_A380LBCBCod[0];
            A383LBDITem = P00AI2_A383LBDITem[0];
            A1058LBCueCod = P00AI2_A1058LBCueCod[0];
            A1064LBDConcepto = P00AI2_A1064LBDConcepto[0];
            A482BanDsc = P00AI2_A482BanDsc[0];
            n482BanDsc = P00AI2_n482BanDsc[0];
            A1079LBFech = P00AI2_A1079LBFech[0];
            A1075LBDocumento = P00AI2_A1075LBDocumento[0];
            A1091LBTipCmb = P00AI2_A1091LBTipCmb[0];
            A1057LBConcepto = P00AI2_A1057LBConcepto[0];
            A1054LBBeneficia = P00AI2_A1054LBBeneficia[0];
            A1085LBMonCod = P00AI2_A1085LBMonCod[0];
            A1233MonAbr = P00AI2_A1233MonAbr[0];
            n1233MonAbr = P00AI2_n1233MonAbr[0];
            AV27BanDsc = StringUtil.Trim( A482BanDsc);
            AV55MonAbr = StringUtil.Trim( A1233MonAbr);
            AV44MonCod = A1085LBMonCod;
            AV64LBRegistro = StringUtil.Trim( A381LBRegistro);
            AV63LBDocumento = StringUtil.Trim( A1075LBDocumento);
            AV30LBPrvCod = A1087LBPrvCod;
            AV14LBTipCod = A1092LBTipCod;
            AV13LBDDoc = A1068LBDDoc;
            AV12LBFech = A1079LBFech;
            AV56CTBco = A380LBCBCod;
            AV42Debe = A1067LBDDebe;
            AV43Haber = A1074LBDHaber;
            AV52LBDCueAux = A1065LBDCueAux;
            AV46LBTipCmb = A1091LBTipCmb;
            AV57Mov = (decimal)(AV42Debe-AV43Haber);
            AV58Saldo = (decimal)(AV58Saldo+AV57Mov);
            AV62Glosa = StringUtil.Trim( A1057LBConcepto);
            AV67ConBCueCod = A1058LBCueCod;
            AV59LBConcepto = StringUtil.Trim( A1064LBDConcepto);
            AV53LBBeneficia = A1054LBBeneficia;
            AV8LBDCosCod = A384LBDCosCod;
            AV68CosDsc = "";
            if ( ( AV46LBTipCmb == Convert.ToDecimal( 0 )) || ( AV46LBTipCmb == Convert.ToDecimal( 1 )) )
            {
               GXt_decimal1 = AV46LBTipCmb;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV12LBFech, ref  GXt_char3, out  GXt_decimal1) ;
               AV46LBTipCmb = GXt_decimal1;
            }
            AV65LBDTipCmb = AV46LBTipCmb;
            GXt_int2 = AV66DocMonCod;
            new GeneXus.Programs.contabilidad.pobtienemonedapago(context ).execute( ref  AV30LBPrvCod, ref  AV14LBTipCod, ref  AV13LBDDoc, out  GXt_int2) ;
            AV66DocMonCod = GXt_int2;
            if ( AV44MonCod != AV66DocMonCod )
            {
               AV65LBDTipCmb = ((Convert.ToDecimal(0)==A1077LBDTipCmb) ? AV65LBDTipCmb : A1077LBDTipCmb);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8LBDCosCod)) )
            {
               /* Execute user subroutine: 'CENTROCOSTO' */
               S141 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
            }
            /* Execute user subroutine: 'DETALLE' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV60TDebe = (decimal)(AV60TDebe+(((AV44MonCod==1) ? AV42Debe : NumberUtil.Round( AV42Debe*AV65LBDTipCmb, 2))));
            AV61THaber = (decimal)(AV61THaber+(((AV44MonCod==1) ? AV43Haber : NumberUtil.Round( AV43Haber*AV65LBDTipCmb, 2))));
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Execute user subroutine: 'TOTALES' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV24ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV24ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+0), 1, 1).Text = StringUtil.Trim( AV27BanDsc);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV56CTBco);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+2), 1, 1).Text = StringUtil.Trim( AV64LBRegistro);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+3), 1, 1).Text = StringUtil.Trim( AV63LBDocumento);
         GXt_dtime4 = DateTimeUtil.ResetTime( AV12LBFech ) ;
         AV24ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+4), 1, 1).Date = GXt_dtime4;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+5), 1, 1).Text = StringUtil.Trim( AV62Glosa);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+6), 1, 1).Text = StringUtil.Trim( AV53LBBeneficia);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+7), 1, 1).Text = StringUtil.Trim( AV67ConBCueCod);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+8), 1, 1).Text = StringUtil.Trim( AV59LBConcepto);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+9), 1, 1).Text = StringUtil.Trim( AV68CosDsc);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+10), 1, 1).Text = StringUtil.Trim( AV55MonAbr);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+11), 1, 1).Number = (double)(AV42Debe);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+12), 1, 1).Number = (double)(AV43Haber);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+13), 1, 1).Number = (double)(AV65LBDTipCmb);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+14), 1, 1).Number = (double)(((AV44MonCod==1) ? AV42Debe : NumberUtil.Round( AV42Debe*AV65LBDTipCmb, 2)));
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+15), 1, 1).Number = (double)(((AV44MonCod==1) ? AV43Haber : NumberUtil.Round( AV43Haber*AV65LBDTipCmb, 2)));
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+0), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+1), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+2), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+3), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+4), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+5), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+6), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+7), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+8), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+9), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+10), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+11), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+12), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+13), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+14), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+15), 1, 1).Size = 8;
         AV25CellRow = (long)(AV25CellRow+1);
      }

      protected void S121( )
      {
         /* 'TOTALES' Routine */
         returnInSub = false;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+9), 1, 1).Text = "Total General";
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+11), 1, 1).Number = (double)(AV60TDebe);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+12), 1, 1).Number = (double)(AV61THaber);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+13), 1, 1).Size = 8;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+14), 1, 1).Size = 8;
      }

      protected void S131( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV24ExcelDocument.ErrCode != 0 )
         {
            AV23Filename = "";
            AV33ErrorMessage = AV24ExcelDocument.ErrDescription;
            AV24ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S141( )
      {
         /* 'CENTROCOSTO' Routine */
         returnInSub = false;
         /* Using cursor P00AI3 */
         pr_default.execute(1, new Object[] {AV8LBDCosCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A79COSCod = P00AI3_A79COSCod[0];
            A761COSDsc = P00AI3_A761COSDsc[0];
            AV68CosDsc = StringUtil.Trim( A761COSDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
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
         AV23Filename = "";
         AV33ErrorMessage = "";
         AV20Archivo = new GxFile(context.GetPhysicalPath());
         AV21Path = "";
         AV22FilenameOrigen = "";
         AV24ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         A1065LBDCueAux = "";
         A1079LBFech = DateTime.MinValue;
         P00AI2_A386LBConBan = new int[1] ;
         P00AI2_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P00AI2_A1065LBDCueAux = new string[] {""} ;
         P00AI2_A379LBBanCod = new int[1] ;
         P00AI2_A482BanDsc = new string[] {""} ;
         P00AI2_n482BanDsc = new bool[] {false} ;
         P00AI2_A1233MonAbr = new string[] {""} ;
         P00AI2_n1233MonAbr = new bool[] {false} ;
         P00AI2_A1085LBMonCod = new int[1] ;
         P00AI2_A1075LBDocumento = new string[] {""} ;
         P00AI2_A1087LBPrvCod = new string[] {""} ;
         P00AI2_A1092LBTipCod = new string[] {""} ;
         P00AI2_A1068LBDDoc = new string[] {""} ;
         P00AI2_A1067LBDDebe = new decimal[1] ;
         P00AI2_A1074LBDHaber = new decimal[1] ;
         P00AI2_A1091LBTipCmb = new decimal[1] ;
         P00AI2_A1057LBConcepto = new string[] {""} ;
         P00AI2_A1058LBCueCod = new string[] {""} ;
         P00AI2_A1064LBDConcepto = new string[] {""} ;
         P00AI2_A1054LBBeneficia = new string[] {""} ;
         P00AI2_A384LBDCosCod = new string[] {""} ;
         P00AI2_n384LBDCosCod = new bool[] {false} ;
         P00AI2_A1077LBDTipCmb = new decimal[1] ;
         P00AI2_A381LBRegistro = new string[] {""} ;
         P00AI2_A380LBCBCod = new string[] {""} ;
         P00AI2_A383LBDITem = new int[1] ;
         A482BanDsc = "";
         A1233MonAbr = "";
         A1075LBDocumento = "";
         A1087LBPrvCod = "";
         A1092LBTipCod = "";
         A1068LBDDoc = "";
         A1057LBConcepto = "";
         A1058LBCueCod = "";
         A1064LBDConcepto = "";
         A1054LBBeneficia = "";
         A384LBDCosCod = "";
         A381LBRegistro = "";
         A380LBCBCod = "";
         AV27BanDsc = "";
         AV55MonAbr = "";
         AV64LBRegistro = "";
         AV63LBDocumento = "";
         AV30LBPrvCod = "";
         AV14LBTipCod = "";
         AV13LBDDoc = "";
         AV12LBFech = DateTime.MinValue;
         AV56CTBco = "";
         AV52LBDCueAux = "";
         AV62Glosa = "";
         AV67ConBCueCod = "";
         AV59LBConcepto = "";
         AV53LBBeneficia = "";
         AV8LBDCosCod = "";
         AV68CosDsc = "";
         GXt_char3 = "";
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         P00AI3_A79COSCod = new string[] {""} ;
         P00AI3_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.r_resumenmovimientobancosexcel__default(),
            new Object[][] {
                new Object[] {
               P00AI2_A386LBConBan, P00AI2_A1079LBFech, P00AI2_A1065LBDCueAux, P00AI2_A379LBBanCod, P00AI2_A482BanDsc, P00AI2_n482BanDsc, P00AI2_A1233MonAbr, P00AI2_n1233MonAbr, P00AI2_A1085LBMonCod, P00AI2_A1075LBDocumento,
               P00AI2_A1087LBPrvCod, P00AI2_A1092LBTipCod, P00AI2_A1068LBDDoc, P00AI2_A1067LBDDebe, P00AI2_A1074LBDHaber, P00AI2_A1091LBTipCmb, P00AI2_A1057LBConcepto, P00AI2_A1058LBCueCod, P00AI2_A1064LBDConcepto, P00AI2_A1054LBBeneficia,
               P00AI2_A384LBDCosCod, P00AI2_n384LBDCosCod, P00AI2_A1077LBDTipCmb, P00AI2_A381LBRegistro, P00AI2_A380LBCBCod, P00AI2_A383LBDITem
               }
               , new Object[] {
               P00AI3_A79COSCod, P00AI3_A761COSDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV51BanCod ;
      private int AV48ConBCod ;
      private int A379LBBanCod ;
      private int A386LBConBan ;
      private int A1085LBMonCod ;
      private int A383LBDITem ;
      private int AV44MonCod ;
      private int AV66DocMonCod ;
      private int GXt_int2 ;
      private long AV25CellRow ;
      private long AV26FirstColumn ;
      private decimal A1067LBDDebe ;
      private decimal A1074LBDHaber ;
      private decimal A1091LBTipCmb ;
      private decimal A1077LBDTipCmb ;
      private decimal AV42Debe ;
      private decimal AV43Haber ;
      private decimal AV46LBTipCmb ;
      private decimal AV57Mov ;
      private decimal AV58Saldo ;
      private decimal GXt_decimal1 ;
      private decimal AV65LBDTipCmb ;
      private decimal AV60TDebe ;
      private decimal AV61THaber ;
      private string AV47TipADCod ;
      private string AV33ErrorMessage ;
      private string AV21Path ;
      private string scmdbuf ;
      private string A1065LBDCueAux ;
      private string A482BanDsc ;
      private string A1233MonAbr ;
      private string A1075LBDocumento ;
      private string A1087LBPrvCod ;
      private string A1092LBTipCod ;
      private string A1068LBDDoc ;
      private string A1057LBConcepto ;
      private string A1058LBCueCod ;
      private string A1064LBDConcepto ;
      private string A1054LBBeneficia ;
      private string A384LBDCosCod ;
      private string A381LBRegistro ;
      private string A380LBCBCod ;
      private string AV27BanDsc ;
      private string AV55MonAbr ;
      private string AV64LBRegistro ;
      private string AV63LBDocumento ;
      private string AV30LBPrvCod ;
      private string AV14LBTipCod ;
      private string AV13LBDDoc ;
      private string AV56CTBco ;
      private string AV52LBDCueAux ;
      private string AV67ConBCueCod ;
      private string AV59LBConcepto ;
      private string AV53LBBeneficia ;
      private string AV8LBDCosCod ;
      private string AV68CosDsc ;
      private string GXt_char3 ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private DateTime GXt_dtime4 ;
      private DateTime AV50FDesde ;
      private DateTime AV49FHasta ;
      private DateTime A1079LBFech ;
      private DateTime AV12LBFech ;
      private bool returnInSub ;
      private bool n482BanDsc ;
      private bool n1233MonAbr ;
      private bool n384LBDCosCod ;
      private string AV23Filename ;
      private string AV22FilenameOrigen ;
      private string AV62Glosa ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_BanCod ;
      private DateTime aP1_FDesde ;
      private DateTime aP2_FHasta ;
      private int aP3_ConBCod ;
      private string aP4_TipADCod ;
      private IDataStoreProvider pr_default ;
      private int[] P00AI2_A386LBConBan ;
      private DateTime[] P00AI2_A1079LBFech ;
      private string[] P00AI2_A1065LBDCueAux ;
      private int[] P00AI2_A379LBBanCod ;
      private string[] P00AI2_A482BanDsc ;
      private bool[] P00AI2_n482BanDsc ;
      private string[] P00AI2_A1233MonAbr ;
      private bool[] P00AI2_n1233MonAbr ;
      private int[] P00AI2_A1085LBMonCod ;
      private string[] P00AI2_A1075LBDocumento ;
      private string[] P00AI2_A1087LBPrvCod ;
      private string[] P00AI2_A1092LBTipCod ;
      private string[] P00AI2_A1068LBDDoc ;
      private decimal[] P00AI2_A1067LBDDebe ;
      private decimal[] P00AI2_A1074LBDHaber ;
      private decimal[] P00AI2_A1091LBTipCmb ;
      private string[] P00AI2_A1057LBConcepto ;
      private string[] P00AI2_A1058LBCueCod ;
      private string[] P00AI2_A1064LBDConcepto ;
      private string[] P00AI2_A1054LBBeneficia ;
      private string[] P00AI2_A384LBDCosCod ;
      private bool[] P00AI2_n384LBDCosCod ;
      private decimal[] P00AI2_A1077LBDTipCmb ;
      private string[] P00AI2_A381LBRegistro ;
      private string[] P00AI2_A380LBCBCod ;
      private int[] P00AI2_A383LBDITem ;
      private string[] P00AI3_A79COSCod ;
      private string[] P00AI3_A761COSDsc ;
      private string aP5_Filename ;
      private string aP6_ErrorMessage ;
      private ExcelDocumentI AV24ExcelDocument ;
      private GxFile AV20Archivo ;
   }

   public class r_resumenmovimientobancosexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AI2( IGxContext context ,
                                             int AV51BanCod ,
                                             string AV47TipADCod ,
                                             int AV48ConBCod ,
                                             int A379LBBanCod ,
                                             string A1065LBDCueAux ,
                                             int A386LBConBan ,
                                             DateTime A1079LBFech ,
                                             DateTime AV50FDesde ,
                                             DateTime AV49FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[5];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[LBConBan] AS LBConBan, T4.[LBFech], T1.[LBDCueAux], T1.[LBBanCod] AS LBBanCod, T3.[BanDsc], T6.[MonAbr], T5.[MonCod] AS LBMonCod, T4.[LBDocumento], T1.[LBPrvCod], T1.[LBTipCod], T1.[LBDDoc], T1.[LBDDebe], T1.[LBDHaber], T4.[LBTipCmb], T4.[LBConcepto], T2.[ConBCueCod] AS LBCueCod, T2.[ConBDsc] AS LBDConcepto, T4.[LBBeneficia], T1.[LBDCosCod], T1.[LBDTipCmb], T1.[LBRegistro], T1.[LBCBCod] AS LBCBCod, T1.[LBDITem] FROM ((((([TSLIBROBANCOSDET] T1 INNER JOIN [TSCONCEPTOBANCOS] T2 ON T2.[ConBCod] = T1.[LBConBan]) INNER JOIN [TSBANCOS] T3 ON T3.[BanCod] = T1.[LBBanCod]) INNER JOIN [TSLIBROBANCOS] T4 ON T4.[LBBanCod] = T1.[LBBanCod] AND T4.[LBCBCod] = T1.[LBCBCod] AND T4.[LBRegistro] = T1.[LBRegistro]) INNER JOIN [TSCUENTABANCO] T5 ON T5.[BanCod] = T1.[LBBanCod] AND T5.[CBCod] = T1.[LBCBCod]) INNER JOIN [CMONEDAS] T6 ON T6.[MonCod] = T5.[MonCod])";
         AddWhere(sWhereString, "(T4.[LBFech] >= @AV50FDesde)");
         AddWhere(sWhereString, "(T4.[LBFech] <= @AV49FHasta)");
         if ( ! (0==AV51BanCod) )
         {
            AddWhere(sWhereString, "(T1.[LBBanCod] = @AV51BanCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TipADCod)) )
         {
            AddWhere(sWhereString, "(T1.[LBDCueAux] = @AV47TipADCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV48ConBCod) )
         {
            AddWhere(sWhereString, "(T1.[LBConBan] = @AV48ConBCod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[LBBanCod], T1.[LBCBCod], T1.[LBRegistro]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00AI2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AI3;
          prmP00AI3 = new Object[] {
          new ParDef("@AV8LBDCosCod",GXType.NChar,10,0)
          };
          Object[] prmP00AI2;
          prmP00AI2 = new Object[] {
          new ParDef("@AV50FDesde",GXType.Date,8,0) ,
          new ParDef("@AV49FHasta",GXType.Date,8,0) ,
          new ParDef("@AV51BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV47TipADCod",GXType.NChar,20,0) ,
          new ParDef("@AV48ConBCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AI2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AI2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AI3", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV8LBDCosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AI3,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 5);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((string[]) buf[10])[0] = rslt.getString(9, 20);
                ((string[]) buf[11])[0] = rslt.getString(10, 3);
                ((string[]) buf[12])[0] = rslt.getString(11, 15);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 60);
                ((string[]) buf[17])[0] = rslt.getString(16, 15);
                ((string[]) buf[18])[0] = rslt.getString(17, 100);
                ((string[]) buf[19])[0] = rslt.getString(18, 60);
                ((string[]) buf[20])[0] = rslt.getString(19, 10);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(20);
                ((string[]) buf[23])[0] = rslt.getString(21, 10);
                ((string[]) buf[24])[0] = rslt.getString(22, 20);
                ((int[]) buf[25])[0] = rslt.getInt(23);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
