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
   public class r_reportepagosproveedoresexcel : GXProcedure
   {
      public r_reportepagosproveedoresexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reportepagosproveedoresexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_PagBanCod ,
                           ref string aP1_PagCBCod ,
                           ref DateTime aP2_DDesde ,
                           ref DateTime aP3_DHasta ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV47PagBanCod = aP0_PagBanCod;
         this.AV48PagCBCod = aP1_PagCBCod;
         this.AV38DDesde = aP2_DDesde;
         this.AV39DHasta = aP3_DHasta;
         this.AV23Filename = "" ;
         this.AV33ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_PagBanCod=this.AV47PagBanCod;
         aP1_PagCBCod=this.AV48PagCBCod;
         aP2_DDesde=this.AV38DDesde;
         aP3_DHasta=this.AV39DHasta;
         aP4_Filename=this.AV23Filename;
         aP5_ErrorMessage=this.AV33ErrorMessage;
      }

      public string executeUdp( ref int aP0_PagBanCod ,
                                ref string aP1_PagCBCod ,
                                ref DateTime aP2_DDesde ,
                                ref DateTime aP3_DHasta ,
                                out string aP4_Filename )
      {
         execute(ref aP0_PagBanCod, ref aP1_PagCBCod, ref aP2_DDesde, ref aP3_DHasta, out aP4_Filename, out aP5_ErrorMessage);
         return AV33ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_PagBanCod ,
                                 ref string aP1_PagCBCod ,
                                 ref DateTime aP2_DDesde ,
                                 ref DateTime aP3_DHasta ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         r_reportepagosproveedoresexcel objr_reportepagosproveedoresexcel;
         objr_reportepagosproveedoresexcel = new r_reportepagosproveedoresexcel();
         objr_reportepagosproveedoresexcel.AV47PagBanCod = aP0_PagBanCod;
         objr_reportepagosproveedoresexcel.AV48PagCBCod = aP1_PagCBCod;
         objr_reportepagosproveedoresexcel.AV38DDesde = aP2_DDesde;
         objr_reportepagosproveedoresexcel.AV39DHasta = aP3_DHasta;
         objr_reportepagosproveedoresexcel.AV23Filename = "" ;
         objr_reportepagosproveedoresexcel.AV33ErrorMessage = "" ;
         objr_reportepagosproveedoresexcel.context.SetSubmitInitialConfig(context);
         objr_reportepagosproveedoresexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reportepagosproveedoresexcel);
         aP0_PagBanCod=this.AV47PagBanCod;
         aP1_PagCBCod=this.AV48PagCBCod;
         aP2_DDesde=this.AV38DDesde;
         aP3_DHasta=this.AV39DHasta;
         aP4_Filename=this.AV23Filename;
         aP5_ErrorMessage=this.AV33ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reportepagosproveedoresexcel)stateInfo).executePrivate();
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
         AV20Archivo.Source = "Excel/PlantillasResumenPagos.xlsx";
         AV21Path = AV20Archivo.GetPath();
         AV22FilenameOrigen = StringUtil.Trim( AV21Path) + "\\PlantillasResumenPagos.xlsx";
         AV23Filename = "Excel/ResumenPagos" + ".xlsx";
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
                                              AV47PagBanCod ,
                                              AV48PagCBCod ,
                                              A379LBBanCod ,
                                              A380LBCBCod ,
                                              A1079LBFech ,
                                              AV38DDesde ,
                                              AV39DHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P009Z2 */
         pr_default.execute(0, new Object[] {AV38DDesde, AV39DHasta, AV47PagBanCod, AV48PagCBCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A386LBConBan = P009Z2_A386LBConBan[0];
            A1079LBFech = P009Z2_A1079LBFech[0];
            A380LBCBCod = P009Z2_A380LBCBCod[0];
            A379LBBanCod = P009Z2_A379LBBanCod[0];
            A482BanDsc = P009Z2_A482BanDsc[0];
            n482BanDsc = P009Z2_n482BanDsc[0];
            A384LBDCosCod = P009Z2_A384LBDCosCod[0];
            n384LBDCosCod = P009Z2_n384LBDCosCod[0];
            A1058LBCueCod = P009Z2_A1058LBCueCod[0];
            A1057LBConcepto = P009Z2_A1057LBConcepto[0];
            A1064LBDConcepto = P009Z2_A1064LBDConcepto[0];
            A381LBRegistro = P009Z2_A381LBRegistro[0];
            A1092LBTipCod = P009Z2_A1092LBTipCod[0];
            A1068LBDDoc = P009Z2_A1068LBDDoc[0];
            A1087LBPrvCod = P009Z2_A1087LBPrvCod[0];
            A1065LBDCueAux = P009Z2_A1065LBDCueAux[0];
            A1074LBDHaber = P009Z2_A1074LBDHaber[0];
            A1067LBDDebe = P009Z2_A1067LBDDebe[0];
            A1091LBTipCmb = P009Z2_A1091LBTipCmb[0];
            A383LBDITem = P009Z2_A383LBDITem[0];
            A1058LBCueCod = P009Z2_A1058LBCueCod[0];
            A1064LBDConcepto = P009Z2_A1064LBDConcepto[0];
            A482BanDsc = P009Z2_A482BanDsc[0];
            n482BanDsc = P009Z2_n482BanDsc[0];
            A1079LBFech = P009Z2_A1079LBFech[0];
            A1057LBConcepto = P009Z2_A1057LBConcepto[0];
            A1091LBTipCmb = P009Z2_A1091LBTipCmb[0];
            AV9LBBanCod = A379LBBanCod;
            AV27BanDsc = A482BanDsc;
            AV10LBCBCod = A380LBCBCod;
            AV16CCosto = "";
            AV8LBDCosCod = A384LBDCosCod;
            AV15LBCueCod = A1058LBCueCod;
            AV29LBDConcepto = A1057LBConcepto;
            AV51LBConcepto = A1064LBDConcepto;
            AV50LBRegistro = A381LBRegistro;
            AV14LBTipCod = A1092LBTipCod;
            AV13LBDDoc = A1068LBDDoc;
            AV12LBFech = A1079LBFech;
            GXt_char1 = AV11Moneda;
            new GeneXus.Programs.generales.pobtienemoneda(context ).execute(  AV9LBBanCod,  AV10LBCBCod, out  GXt_char1) ;
            AV11Moneda = GXt_char1;
            GXt_int2 = AV44MonCod;
            new GeneXus.Programs.generales.pobtienemonedabanco(context ).execute(  AV9LBBanCod,  AV10LBCBCod, out  GXt_int2) ;
            AV44MonCod = GXt_int2;
            AV30LBPrvCod = A1087LBPrvCod;
            AV49LBDCueAux = A1065LBDCueAux;
            AV17CPFech = DateTime.MinValue;
            AV18CPMonCod = 0;
            AV19Linea = "";
            AV42Debe = A1074LBDHaber;
            AV43Haber = A1067LBDDebe;
            AV45Importe = (decimal)(A1067LBDDebe-A1074LBDHaber);
            AV45Importe = ((AV45Importe<Convert.ToDecimal(0)) ? AV45Importe*-1 : AV45Importe);
            AV46LBTipCmb = A1091LBTipCmb;
            AV28Pago = (decimal)(AV45Importe*((AV44MonCod==2) ? AV46LBTipCmb : (decimal)(1)));
            AV28Pago = NumberUtil.Round( AV28Pago, 2);
            /* Execute user subroutine: 'DATOS' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'DETALLE' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         /* 'DATOS' Routine */
         returnInSub = false;
         AV34Proveedor = "";
         AV35TipoDoc = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30LBPrvCod)) )
         {
            /* Using cursor P009Z3 */
            pr_default.execute(1, new Object[] {AV14LBTipCod, AV13LBDDoc, AV30LBPrvCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A263CPMonCod = P009Z3_A263CPMonCod[0];
               A261CPComCod = P009Z3_A261CPComCod[0];
               A260CPTipCod = P009Z3_A260CPTipCod[0];
               A262CPPrvCod = P009Z3_A262CPPrvCod[0];
               A831CPPrvDsc = P009Z3_A831CPPrvDsc[0];
               A1910TipDsc = P009Z3_A1910TipDsc[0];
               n1910TipDsc = P009Z3_n1910TipDsc[0];
               A264CPFech = P009Z3_A264CPFech[0];
               A1233MonAbr = P009Z3_A1233MonAbr[0];
               n1233MonAbr = P009Z3_n1233MonAbr[0];
               A1233MonAbr = P009Z3_A1233MonAbr[0];
               n1233MonAbr = P009Z3_n1233MonAbr[0];
               A1910TipDsc = P009Z3_A1910TipDsc[0];
               n1910TipDsc = P009Z3_n1910TipDsc[0];
               A831CPPrvDsc = P009Z3_A831CPPrvDsc[0];
               AV34Proveedor = StringUtil.Trim( A831CPPrvDsc);
               AV35TipoDoc = A1910TipDsc;
               AV17CPFech = A264CPFech;
               AV36MonOrigen = StringUtil.Trim( A1233MonAbr);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8LBDCosCod)) )
            {
               /* Using cursor P009Z4 */
               pr_default.execute(2, new Object[] {AV14LBTipCod, AV13LBDDoc, AV30LBPrvCod});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A243ComCod = P009Z4_A243ComCod[0];
                  A149TipCod = P009Z4_A149TipCod[0];
                  A244PrvCod = P009Z4_A244PrvCod[0];
                  A252ComCosCod = P009Z4_A252ComCosCod[0];
                  n252ComCosCod = P009Z4_n252ComCosCod[0];
                  A251ComDOrdCod = P009Z4_A251ComDOrdCod[0];
                  A250ComDItem = P009Z4_A250ComDItem[0];
                  AV8LBDCosCod = A252ComCosCod;
                  AV37ComDOrdCod = A251ComDOrdCod;
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8LBDCosCod)) )
               {
                  /* Using cursor P009Z5 */
                  pr_default.execute(3, new Object[] {AV37ComDOrdCod});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A289OrdCod = P009Z5_A289OrdCod[0];
                     A291OrdCosCod = P009Z5_A291OrdCosCod[0];
                     n291OrdCosCod = P009Z5_n291OrdCosCod[0];
                     AV8LBDCosCod = A291OrdCosCod;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
               }
            }
            AV40ComDProCod = "";
            AV41ComDCueCod = "";
            /* Using cursor P009Z6 */
            pr_default.execute(4, new Object[] {AV14LBTipCod, AV13LBDDoc, AV30LBPrvCod});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A243ComCod = P009Z6_A243ComCod[0];
               A149TipCod = P009Z6_A149TipCod[0];
               A244PrvCod = P009Z6_A244PrvCod[0];
               A254ComDProCod = P009Z6_A254ComDProCod[0];
               n254ComDProCod = P009Z6_n254ComDProCod[0];
               A253ComDCueCod = P009Z6_A253ComDCueCod[0];
               n253ComDCueCod = P009Z6_n253ComDCueCod[0];
               A250ComDItem = P009Z6_A250ComDItem[0];
               A251ComDOrdCod = P009Z6_A251ComDOrdCod[0];
               AV40ComDProCod = A254ComDProCod;
               AV41ComDCueCod = A253ComDCueCod;
               pr_default.readNext(4);
            }
            pr_default.close(4);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40ComDProCod)) )
            {
               /* Using cursor P009Z7 */
               pr_default.execute(5, new Object[] {AV41ComDCueCod});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A91CueCod = P009Z7_A91CueCod[0];
                  A860CueDsc = P009Z7_A860CueDsc[0];
                  AV29LBDConcepto = A860CueDsc;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(5);
            }
            else
            {
               /* Using cursor P009Z8 */
               pr_default.execute(6, new Object[] {AV40ComDProCod});
               while ( (pr_default.getStatus(6) != 101) )
               {
                  A52LinCod = P009Z8_A52LinCod[0];
                  A28ProdCod = P009Z8_A28ProdCod[0];
                  A1153LinDsc = P009Z8_A1153LinDsc[0];
                  A1153LinDsc = P009Z8_A1153LinDsc[0];
                  AV29LBDConcepto = A1153LinDsc;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(6);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8LBDCosCod)) )
         {
            /* Using cursor P009Z9 */
            pr_default.execute(7, new Object[] {AV8LBDCosCod});
            while ( (pr_default.getStatus(7) != 101) )
            {
               A79COSCod = P009Z9_A79COSCod[0];
               A761COSDsc = P009Z9_A761COSDsc[0];
               AV16CCosto = StringUtil.Trim( A761COSDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(7);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49LBDCueAux)) )
         {
            /* Using cursor P009Z10 */
            pr_default.execute(8, new Object[] {AV49LBDCueAux});
            while ( (pr_default.getStatus(8) != 101) )
            {
               A1901TipADSts = P009Z10_A1901TipADSts[0];
               A71TipADCod = P009Z10_A71TipADCod[0];
               A72TipADDsc = P009Z10_A72TipADDsc[0];
               A70TipACod = P009Z10_A70TipACod[0];
               AV34Proveedor = A72TipADDsc;
               pr_default.readNext(8);
            }
            pr_default.close(8);
         }
      }

      protected void S121( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+0), 1, 1).Text = StringUtil.Trim( AV16CCosto);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV27BanDsc);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+2), 1, 1).Text = StringUtil.Trim( AV10LBCBCod);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+3), 1, 1).Text = StringUtil.Trim( AV50LBRegistro);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+4), 1, 1).Text = StringUtil.Trim( AV11Moneda);
         GXt_dtime3 = DateTimeUtil.ResetTime( AV12LBFech ) ;
         AV24ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+5), 1, 1).Date = GXt_dtime3;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+6), 1, 1).Number = (double)(AV42Debe);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+7), 1, 1).Number = (double)(AV43Haber);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+8), 1, 1).Number = (double)(AV28Pago);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+9), 1, 1).Text = StringUtil.Trim( AV30LBPrvCod);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+10), 1, 1).Text = StringUtil.Trim( AV34Proveedor);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+11), 1, 1).Text = StringUtil.Trim( AV35TipoDoc);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+12), 1, 1).Text = StringUtil.Trim( AV13LBDDoc);
         GXt_dtime3 = DateTimeUtil.ResetTime( AV17CPFech ) ;
         AV24ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+13), 1, 1).Date = GXt_dtime3;
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+14), 1, 1).Text = StringUtil.Trim( AV51LBConcepto);
         AV24ExcelDocument.get_Cells((int)(AV25CellRow), (int)(AV26FirstColumn+15), 1, 1).Text = StringUtil.Trim( AV29LBDConcepto);
         AV25CellRow = (long)(AV25CellRow+1);
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
         A380LBCBCod = "";
         A1079LBFech = DateTime.MinValue;
         P009Z2_A386LBConBan = new int[1] ;
         P009Z2_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P009Z2_A380LBCBCod = new string[] {""} ;
         P009Z2_A379LBBanCod = new int[1] ;
         P009Z2_A482BanDsc = new string[] {""} ;
         P009Z2_n482BanDsc = new bool[] {false} ;
         P009Z2_A384LBDCosCod = new string[] {""} ;
         P009Z2_n384LBDCosCod = new bool[] {false} ;
         P009Z2_A1058LBCueCod = new string[] {""} ;
         P009Z2_A1057LBConcepto = new string[] {""} ;
         P009Z2_A1064LBDConcepto = new string[] {""} ;
         P009Z2_A381LBRegistro = new string[] {""} ;
         P009Z2_A1092LBTipCod = new string[] {""} ;
         P009Z2_A1068LBDDoc = new string[] {""} ;
         P009Z2_A1087LBPrvCod = new string[] {""} ;
         P009Z2_A1065LBDCueAux = new string[] {""} ;
         P009Z2_A1074LBDHaber = new decimal[1] ;
         P009Z2_A1067LBDDebe = new decimal[1] ;
         P009Z2_A1091LBTipCmb = new decimal[1] ;
         P009Z2_A383LBDITem = new int[1] ;
         A482BanDsc = "";
         A384LBDCosCod = "";
         A1058LBCueCod = "";
         A1057LBConcepto = "";
         A1064LBDConcepto = "";
         A381LBRegistro = "";
         A1092LBTipCod = "";
         A1068LBDDoc = "";
         A1087LBPrvCod = "";
         A1065LBDCueAux = "";
         AV27BanDsc = "";
         AV10LBCBCod = "";
         AV16CCosto = "";
         AV8LBDCosCod = "";
         AV15LBCueCod = "";
         AV29LBDConcepto = "";
         AV51LBConcepto = "";
         AV50LBRegistro = "";
         AV14LBTipCod = "";
         AV13LBDDoc = "";
         AV12LBFech = DateTime.MinValue;
         AV11Moneda = "";
         GXt_char1 = "";
         AV30LBPrvCod = "";
         AV49LBDCueAux = "";
         AV17CPFech = DateTime.MinValue;
         AV19Linea = "";
         AV34Proveedor = "";
         AV35TipoDoc = "";
         P009Z3_A263CPMonCod = new int[1] ;
         P009Z3_A261CPComCod = new string[] {""} ;
         P009Z3_A260CPTipCod = new string[] {""} ;
         P009Z3_A262CPPrvCod = new string[] {""} ;
         P009Z3_A831CPPrvDsc = new string[] {""} ;
         P009Z3_A1910TipDsc = new string[] {""} ;
         P009Z3_n1910TipDsc = new bool[] {false} ;
         P009Z3_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P009Z3_A1233MonAbr = new string[] {""} ;
         P009Z3_n1233MonAbr = new bool[] {false} ;
         A261CPComCod = "";
         A260CPTipCod = "";
         A262CPPrvCod = "";
         A831CPPrvDsc = "";
         A1910TipDsc = "";
         A264CPFech = DateTime.MinValue;
         A1233MonAbr = "";
         AV36MonOrigen = "";
         P009Z4_A243ComCod = new string[] {""} ;
         P009Z4_A149TipCod = new string[] {""} ;
         P009Z4_A244PrvCod = new string[] {""} ;
         P009Z4_A252ComCosCod = new string[] {""} ;
         P009Z4_n252ComCosCod = new bool[] {false} ;
         P009Z4_A251ComDOrdCod = new string[] {""} ;
         P009Z4_A250ComDItem = new short[1] ;
         A243ComCod = "";
         A149TipCod = "";
         A244PrvCod = "";
         A252ComCosCod = "";
         A251ComDOrdCod = "";
         AV37ComDOrdCod = "";
         P009Z5_A289OrdCod = new string[] {""} ;
         P009Z5_A291OrdCosCod = new string[] {""} ;
         P009Z5_n291OrdCosCod = new bool[] {false} ;
         A289OrdCod = "";
         A291OrdCosCod = "";
         AV40ComDProCod = "";
         AV41ComDCueCod = "";
         P009Z6_A243ComCod = new string[] {""} ;
         P009Z6_A149TipCod = new string[] {""} ;
         P009Z6_A244PrvCod = new string[] {""} ;
         P009Z6_A254ComDProCod = new string[] {""} ;
         P009Z6_n254ComDProCod = new bool[] {false} ;
         P009Z6_A253ComDCueCod = new string[] {""} ;
         P009Z6_n253ComDCueCod = new bool[] {false} ;
         P009Z6_A250ComDItem = new short[1] ;
         P009Z6_A251ComDOrdCod = new string[] {""} ;
         A254ComDProCod = "";
         A253ComDCueCod = "";
         P009Z7_A91CueCod = new string[] {""} ;
         P009Z7_A860CueDsc = new string[] {""} ;
         A91CueCod = "";
         A860CueDsc = "";
         P009Z8_A52LinCod = new int[1] ;
         P009Z8_A28ProdCod = new string[] {""} ;
         P009Z8_A1153LinDsc = new string[] {""} ;
         A28ProdCod = "";
         A1153LinDsc = "";
         P009Z9_A79COSCod = new string[] {""} ;
         P009Z9_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         P009Z10_A1901TipADSts = new short[1] ;
         P009Z10_A71TipADCod = new string[] {""} ;
         P009Z10_A72TipADDsc = new string[] {""} ;
         P009Z10_A70TipACod = new int[1] ;
         A71TipADCod = "";
         A72TipADDsc = "";
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.r_reportepagosproveedoresexcel__default(),
            new Object[][] {
                new Object[] {
               P009Z2_A386LBConBan, P009Z2_A1079LBFech, P009Z2_A380LBCBCod, P009Z2_A379LBBanCod, P009Z2_A482BanDsc, P009Z2_n482BanDsc, P009Z2_A384LBDCosCod, P009Z2_n384LBDCosCod, P009Z2_A1058LBCueCod, P009Z2_A1057LBConcepto,
               P009Z2_A1064LBDConcepto, P009Z2_A381LBRegistro, P009Z2_A1092LBTipCod, P009Z2_A1068LBDDoc, P009Z2_A1087LBPrvCod, P009Z2_A1065LBDCueAux, P009Z2_A1074LBDHaber, P009Z2_A1067LBDDebe, P009Z2_A1091LBTipCmb, P009Z2_A383LBDITem
               }
               , new Object[] {
               P009Z3_A263CPMonCod, P009Z3_A261CPComCod, P009Z3_A260CPTipCod, P009Z3_A262CPPrvCod, P009Z3_A831CPPrvDsc, P009Z3_A1910TipDsc, P009Z3_n1910TipDsc, P009Z3_A264CPFech, P009Z3_A1233MonAbr, P009Z3_n1233MonAbr
               }
               , new Object[] {
               P009Z4_A243ComCod, P009Z4_A149TipCod, P009Z4_A244PrvCod, P009Z4_A252ComCosCod, P009Z4_n252ComCosCod, P009Z4_A251ComDOrdCod, P009Z4_A250ComDItem
               }
               , new Object[] {
               P009Z5_A289OrdCod, P009Z5_A291OrdCosCod, P009Z5_n291OrdCosCod
               }
               , new Object[] {
               P009Z6_A243ComCod, P009Z6_A149TipCod, P009Z6_A244PrvCod, P009Z6_A254ComDProCod, P009Z6_n254ComDProCod, P009Z6_A253ComDCueCod, P009Z6_n253ComDCueCod, P009Z6_A250ComDItem, P009Z6_A251ComDOrdCod
               }
               , new Object[] {
               P009Z7_A91CueCod, P009Z7_A860CueDsc
               }
               , new Object[] {
               P009Z8_A52LinCod, P009Z8_A28ProdCod, P009Z8_A1153LinDsc
               }
               , new Object[] {
               P009Z9_A79COSCod, P009Z9_A761COSDsc
               }
               , new Object[] {
               P009Z10_A1901TipADSts, P009Z10_A71TipADCod, P009Z10_A72TipADDsc, P009Z10_A70TipACod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A250ComDItem ;
      private short A1901TipADSts ;
      private int AV47PagBanCod ;
      private int A379LBBanCod ;
      private int A386LBConBan ;
      private int A383LBDITem ;
      private int AV9LBBanCod ;
      private int AV44MonCod ;
      private int GXt_int2 ;
      private int AV18CPMonCod ;
      private int A263CPMonCod ;
      private int A52LinCod ;
      private int A70TipACod ;
      private long AV25CellRow ;
      private long AV26FirstColumn ;
      private decimal A1074LBDHaber ;
      private decimal A1067LBDDebe ;
      private decimal A1091LBTipCmb ;
      private decimal AV42Debe ;
      private decimal AV43Haber ;
      private decimal AV45Importe ;
      private decimal AV46LBTipCmb ;
      private decimal AV28Pago ;
      private string AV48PagCBCod ;
      private string AV33ErrorMessage ;
      private string AV21Path ;
      private string scmdbuf ;
      private string A380LBCBCod ;
      private string A482BanDsc ;
      private string A384LBDCosCod ;
      private string A1058LBCueCod ;
      private string A1057LBConcepto ;
      private string A1064LBDConcepto ;
      private string A381LBRegistro ;
      private string A1092LBTipCod ;
      private string A1068LBDDoc ;
      private string A1087LBPrvCod ;
      private string A1065LBDCueAux ;
      private string AV27BanDsc ;
      private string AV10LBCBCod ;
      private string AV16CCosto ;
      private string AV8LBDCosCod ;
      private string AV15LBCueCod ;
      private string AV29LBDConcepto ;
      private string AV51LBConcepto ;
      private string AV50LBRegistro ;
      private string AV14LBTipCod ;
      private string AV13LBDDoc ;
      private string AV11Moneda ;
      private string GXt_char1 ;
      private string AV30LBPrvCod ;
      private string AV49LBDCueAux ;
      private string AV19Linea ;
      private string AV34Proveedor ;
      private string AV35TipoDoc ;
      private string A261CPComCod ;
      private string A260CPTipCod ;
      private string A262CPPrvCod ;
      private string A831CPPrvDsc ;
      private string A1910TipDsc ;
      private string A1233MonAbr ;
      private string AV36MonOrigen ;
      private string A243ComCod ;
      private string A149TipCod ;
      private string A244PrvCod ;
      private string A252ComCosCod ;
      private string A251ComDOrdCod ;
      private string AV37ComDOrdCod ;
      private string A289OrdCod ;
      private string A291OrdCosCod ;
      private string AV40ComDProCod ;
      private string AV41ComDCueCod ;
      private string A254ComDProCod ;
      private string A253ComDCueCod ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string A28ProdCod ;
      private string A1153LinDsc ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private DateTime GXt_dtime3 ;
      private DateTime AV38DDesde ;
      private DateTime AV39DHasta ;
      private DateTime A1079LBFech ;
      private DateTime AV12LBFech ;
      private DateTime AV17CPFech ;
      private DateTime A264CPFech ;
      private bool returnInSub ;
      private bool n482BanDsc ;
      private bool n384LBDCosCod ;
      private bool n1910TipDsc ;
      private bool n1233MonAbr ;
      private bool n252ComCosCod ;
      private bool n291OrdCosCod ;
      private bool n254ComDProCod ;
      private bool n253ComDCueCod ;
      private string AV23Filename ;
      private string AV22FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_PagBanCod ;
      private string aP1_PagCBCod ;
      private DateTime aP2_DDesde ;
      private DateTime aP3_DHasta ;
      private IDataStoreProvider pr_default ;
      private int[] P009Z2_A386LBConBan ;
      private DateTime[] P009Z2_A1079LBFech ;
      private string[] P009Z2_A380LBCBCod ;
      private int[] P009Z2_A379LBBanCod ;
      private string[] P009Z2_A482BanDsc ;
      private bool[] P009Z2_n482BanDsc ;
      private string[] P009Z2_A384LBDCosCod ;
      private bool[] P009Z2_n384LBDCosCod ;
      private string[] P009Z2_A1058LBCueCod ;
      private string[] P009Z2_A1057LBConcepto ;
      private string[] P009Z2_A1064LBDConcepto ;
      private string[] P009Z2_A381LBRegistro ;
      private string[] P009Z2_A1092LBTipCod ;
      private string[] P009Z2_A1068LBDDoc ;
      private string[] P009Z2_A1087LBPrvCod ;
      private string[] P009Z2_A1065LBDCueAux ;
      private decimal[] P009Z2_A1074LBDHaber ;
      private decimal[] P009Z2_A1067LBDDebe ;
      private decimal[] P009Z2_A1091LBTipCmb ;
      private int[] P009Z2_A383LBDITem ;
      private int[] P009Z3_A263CPMonCod ;
      private string[] P009Z3_A261CPComCod ;
      private string[] P009Z3_A260CPTipCod ;
      private string[] P009Z3_A262CPPrvCod ;
      private string[] P009Z3_A831CPPrvDsc ;
      private string[] P009Z3_A1910TipDsc ;
      private bool[] P009Z3_n1910TipDsc ;
      private DateTime[] P009Z3_A264CPFech ;
      private string[] P009Z3_A1233MonAbr ;
      private bool[] P009Z3_n1233MonAbr ;
      private string[] P009Z4_A243ComCod ;
      private string[] P009Z4_A149TipCod ;
      private string[] P009Z4_A244PrvCod ;
      private string[] P009Z4_A252ComCosCod ;
      private bool[] P009Z4_n252ComCosCod ;
      private string[] P009Z4_A251ComDOrdCod ;
      private short[] P009Z4_A250ComDItem ;
      private string[] P009Z5_A289OrdCod ;
      private string[] P009Z5_A291OrdCosCod ;
      private bool[] P009Z5_n291OrdCosCod ;
      private string[] P009Z6_A243ComCod ;
      private string[] P009Z6_A149TipCod ;
      private string[] P009Z6_A244PrvCod ;
      private string[] P009Z6_A254ComDProCod ;
      private bool[] P009Z6_n254ComDProCod ;
      private string[] P009Z6_A253ComDCueCod ;
      private bool[] P009Z6_n253ComDCueCod ;
      private short[] P009Z6_A250ComDItem ;
      private string[] P009Z6_A251ComDOrdCod ;
      private string[] P009Z7_A91CueCod ;
      private string[] P009Z7_A860CueDsc ;
      private int[] P009Z8_A52LinCod ;
      private string[] P009Z8_A28ProdCod ;
      private string[] P009Z8_A1153LinDsc ;
      private string[] P009Z9_A79COSCod ;
      private string[] P009Z9_A761COSDsc ;
      private short[] P009Z10_A1901TipADSts ;
      private string[] P009Z10_A71TipADCod ;
      private string[] P009Z10_A72TipADDsc ;
      private int[] P009Z10_A70TipACod ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV24ExcelDocument ;
      private GxFile AV20Archivo ;
   }

   public class r_reportepagosproveedoresexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009Z2( IGxContext context ,
                                             int AV47PagBanCod ,
                                             string AV48PagCBCod ,
                                             int A379LBBanCod ,
                                             string A380LBCBCod ,
                                             DateTime A1079LBFech ,
                                             DateTime AV38DDesde ,
                                             DateTime AV39DHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[LBConBan] AS LBConBan, T4.[LBFech], T1.[LBCBCod], T1.[LBBanCod] AS LBBanCod, T3.[BanDsc], T1.[LBDCosCod], T2.[ConBCueCod] AS LBCueCod, T4.[LBConcepto], T2.[ConBDsc] AS LBDConcepto, T1.[LBRegistro], T1.[LBTipCod], T1.[LBDDoc], T1.[LBPrvCod], T1.[LBDCueAux], T1.[LBDHaber], T1.[LBDDebe], T4.[LBTipCmb], T1.[LBDITem] FROM ((([TSLIBROBANCOSDET] T1 INNER JOIN [TSCONCEPTOBANCOS] T2 ON T2.[ConBCod] = T1.[LBConBan]) INNER JOIN [TSBANCOS] T3 ON T3.[BanCod] = T1.[LBBanCod]) INNER JOIN [TSLIBROBANCOS] T4 ON T4.[LBBanCod] = T1.[LBBanCod] AND T4.[LBCBCod] = T1.[LBCBCod] AND T4.[LBRegistro] = T1.[LBRegistro])";
         AddWhere(sWhereString, "(T4.[LBFech] >= @AV38DDesde)");
         AddWhere(sWhereString, "(T4.[LBFech] <= @AV39DHasta)");
         if ( ! (0==AV47PagBanCod) )
         {
            AddWhere(sWhereString, "(T1.[LBBanCod] = @AV47PagBanCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48PagCBCod)) )
         {
            AddWhere(sWhereString, "(T1.[LBCBCod] = @AV48PagCBCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[LBBanCod], T1.[LBCBCod]";
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
                     return conditional_P009Z2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009Z3;
          prmP009Z3 = new Object[] {
          new ParDef("@AV14LBTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV13LBDDoc",GXType.NChar,15,0) ,
          new ParDef("@AV30LBPrvCod",GXType.NChar,20,0)
          };
          Object[] prmP009Z4;
          prmP009Z4 = new Object[] {
          new ParDef("@AV14LBTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV13LBDDoc",GXType.NChar,15,0) ,
          new ParDef("@AV30LBPrvCod",GXType.NChar,20,0)
          };
          Object[] prmP009Z5;
          prmP009Z5 = new Object[] {
          new ParDef("@AV37ComDOrdCod",GXType.NChar,10,0)
          };
          Object[] prmP009Z6;
          prmP009Z6 = new Object[] {
          new ParDef("@AV14LBTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV13LBDDoc",GXType.NChar,15,0) ,
          new ParDef("@AV30LBPrvCod",GXType.NChar,20,0)
          };
          Object[] prmP009Z7;
          prmP009Z7 = new Object[] {
          new ParDef("@AV41ComDCueCod",GXType.NChar,15,0)
          };
          Object[] prmP009Z8;
          prmP009Z8 = new Object[] {
          new ParDef("@AV40ComDProCod",GXType.NChar,15,0)
          };
          Object[] prmP009Z9;
          prmP009Z9 = new Object[] {
          new ParDef("@AV8LBDCosCod",GXType.NChar,10,0)
          };
          Object[] prmP009Z10;
          prmP009Z10 = new Object[] {
          new ParDef("@AV49LBDCueAux",GXType.NChar,20,0)
          };
          Object[] prmP009Z2;
          prmP009Z2 = new Object[] {
          new ParDef("@AV38DDesde",GXType.Date,8,0) ,
          new ParDef("@AV39DHasta",GXType.Date,8,0) ,
          new ParDef("@AV47PagBanCod",GXType.Int32,6,0) ,
          new ParDef("@AV48PagCBCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Z2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009Z3", "SELECT T1.[CPMonCod] AS CPMonCod, T1.[CPComCod], T1.[CPTipCod] AS CPTipCod, T1.[CPPrvCod] AS CPPrvCod, T4.[PrvDsc] AS CPPrvDsc, T3.[TipDsc], T1.[CPFech], T2.[MonAbr] FROM ((([CPCUENTAPAGAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CPMonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CPTipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[CPPrvCod]) WHERE T1.[CPTipCod] = @AV14LBTipCod and T1.[CPComCod] = @AV13LBDDoc and T1.[CPPrvCod] = @AV30LBPrvCod ORDER BY T1.[CPTipCod], T1.[CPComCod], T1.[CPPrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Z3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Z4", "SELECT [ComCod], [TipCod], [PrvCod], [ComCosCod], [ComDOrdCod], [ComDItem] FROM [CPCOMPRASDET] WHERE [TipCod] = @AV14LBTipCod and [ComCod] = @AV13LBDDoc and [PrvCod] = @AV30LBPrvCod ORDER BY [TipCod], [ComCod], [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Z4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009Z5", "SELECT [OrdCod], [OrdCosCod] FROM [CPORDEN] WHERE [OrdCod] = @AV37ComDOrdCod ORDER BY [OrdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Z5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Z6", "SELECT [ComCod], [TipCod], [PrvCod], [ComDProCod], [ComDCueCod], [ComDItem], [ComDOrdCod] FROM [CPCOMPRASDET] WHERE [TipCod] = @AV14LBTipCod and [ComCod] = @AV13LBDDoc and [PrvCod] = @AV30LBPrvCod ORDER BY [TipCod], [ComCod], [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Z6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009Z7", "SELECT [CueCod], [CueDsc] FROM [CBPLANCUENTA] WHERE ([CueCod] = @AV41ComDCueCod) AND (Not (@AV41ComDCueCod = '')) ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Z7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Z8", "SELECT T1.[LinCod], T1.[ProdCod], T2.[LinDsc] FROM ([APRODUCTOS] T1 INNER JOIN [CLINEAPROD] T2 ON T2.[LinCod] = T1.[LinCod]) WHERE (T1.[ProdCod] = @AV40ComDProCod) AND (Not (@AV40ComDProCod = '')) ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Z8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Z9", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV8LBDCosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Z9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Z10", "SELECT [TipADSts], [TipADCod], [TipADDsc], [TipACod] FROM [CBAUXILIARES] WHERE ([TipADCod] = @AV49LBDCueAux) AND ([TipADSts] = 1) ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Z10,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[6])[0] = rslt.getString(6, 10);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 15);
                ((string[]) buf[9])[0] = rslt.getString(8, 60);
                ((string[]) buf[10])[0] = rslt.getString(9, 100);
                ((string[]) buf[11])[0] = rslt.getString(10, 10);
                ((string[]) buf[12])[0] = rslt.getString(11, 3);
                ((string[]) buf[13])[0] = rslt.getString(12, 15);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((string[]) buf[15])[0] = rslt.getString(14, 20);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(17);
                ((int[]) buf[19])[0] = rslt.getInt(18);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 5);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 10);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 10);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
