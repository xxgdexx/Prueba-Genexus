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
namespace GeneXus.Programs.contabilidad {
   public class r_librocajabancos1_2excel : GXProcedure
   {
      public r_librocajabancos1_2excel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_librocajabancos1_2excel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           out string aP2_FileName ,
                           out string aP3_ErrorMessage )
      {
         this.AV22Ano = aP0_Ano;
         this.AV37Mes = aP1_Mes;
         this.AV32FileName = "" ;
         this.AV30ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV22Ano;
         aP1_Mes=this.AV37Mes;
         aP2_FileName=this.AV32FileName;
         aP3_ErrorMessage=this.AV30ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                out string aP2_FileName )
      {
         execute(ref aP0_Ano, ref aP1_Mes, out aP2_FileName, out aP3_ErrorMessage);
         return AV30ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 out string aP2_FileName ,
                                 out string aP3_ErrorMessage )
      {
         r_librocajabancos1_2excel objr_librocajabancos1_2excel;
         objr_librocajabancos1_2excel = new r_librocajabancos1_2excel();
         objr_librocajabancos1_2excel.AV22Ano = aP0_Ano;
         objr_librocajabancos1_2excel.AV37Mes = aP1_Mes;
         objr_librocajabancos1_2excel.AV32FileName = "" ;
         objr_librocajabancos1_2excel.AV30ErrorMessage = "" ;
         objr_librocajabancos1_2excel.context.SetSubmitInitialConfig(context);
         objr_librocajabancos1_2excel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_librocajabancos1_2excel);
         aP0_Ano=this.AV22Ano;
         aP1_Mes=this.AV37Mes;
         aP2_FileName=this.AV32FileName;
         aP3_ErrorMessage=this.AV30ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_librocajabancos1_2excel)stateInfo).executePrivate();
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
         AV23Archivo.Source = "Excel/FORMATO_1_2.xlsx";
         AV40Path = AV23Archivo.GetPath();
         AV33FileNameOrigen = StringUtil.Trim( AV40Path) + "\\FORMATO_1_2.xlsx";
         AV32FileName = "Excel/Libro Caja Bancos_1_2" + ".xlsx";
         AV43RUC = AV47Session.Get("EmpRUC");
         AV29Empresa = AV47Session.Get("Empresa");
         AV31ExcelDocument.Clear();
         AV31ExcelDocument.Template = AV33FileNameOrigen;
         AV31ExcelDocument.Open(AV32FileName);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV26CellRow = 3;
         AV34FirstColumn = 7;
         AV41Periodo = StringUtil.Trim( StringUtil.Str( (decimal)(AV22Ano), 10, 0)) + "" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV37Mes), 10, 0)), 2, "0");
         AV31ExcelDocument.get_Cells(3, 2, 1, 1).Text = StringUtil.Trim( AV41Periodo);
         AV31ExcelDocument.get_Cells(4, 2, 1, 1).Text = StringUtil.Trim( AV43RUC);
         AV31ExcelDocument.get_Cells(5, 3, 1, 1).Text = StringUtil.Trim( AV29Empresa);
         AV38MesAnt = (short)(AV37Mes-1);
         AV26CellRow = 9;
         AV34FirstColumn = 1;
         AV49TDebe = 0.00m;
         AV50THaber = 0.00m;
         /* Using cursor P00C62 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A504CBSts = P00C62_A504CBSts[0];
            A378CBCueCod = P00C62_A378CBCueCod[0];
            A491CBCueDsc = P00C62_A491CBCueDsc[0];
            A377CBCod = P00C62_A377CBCod[0];
            A372BanCod = P00C62_A372BanCod[0];
            A491CBCueDsc = P00C62_A491CBCueDsc[0];
            AV25cCuenta1 = A378CBCueCod;
            AV27CueDsc = A491CBCueDsc;
            AV24CBCod = A377CBCod;
            AV49TDebe = 0.00m;
            AV50THaber = 0.00m;
            /* Execute user subroutine: 'MOVIMIENTOS' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV26CellRow = (int)(AV26CellRow+2);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV31ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV31ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV31ExcelDocument.ErrCode != 0 )
         {
            AV32FileName = "";
            AV30ErrorMessage = AV31ExcelDocument.ErrDescription;
            AV31ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'MOVIMIENTOS' Routine */
         returnInSub = false;
         new GeneXus.Programs.contabilidad.psaldocuentames(context ).execute(  AV25cCuenta1,  AV22Ano,  AV38MesAnt, out  AV45SaldoDebe, out  AV46SaldoHaber, out  AV44Saldo) ;
         /* Execute user subroutine: 'VALIDAMOVIMIENTO' */
         S131 ();
         if (returnInSub) return;
         AV45SaldoDebe = ((AV44Saldo>Convert.ToDecimal(0)) ? AV44Saldo : (decimal)(0));
         AV46SaldoHaber = ((AV44Saldo<Convert.ToDecimal(0)) ? AV44Saldo*-1 : (decimal)(0));
         if ( ( AV35Flag == 1 ) || ! (Convert.ToDecimal(0)==AV44Saldo) )
         {
            /* Using cursor P00C63 */
            pr_default.execute(1, new Object[] {AV22Ano, AV37Mes, AV25cCuenta1});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A127VouAno = P00C63_A127VouAno[0];
               A128VouMes = P00C63_A128VouMes[0];
               A91CueCod = P00C63_A91CueCod[0];
               A2077VouSts = P00C63_A2077VouSts[0];
               A126TASICod = P00C63_A126TASICod[0];
               A129VouNum = P00C63_A129VouNum[0];
               A2059VouDRef1 = P00C63_A2059VouDRef1[0];
               A2062VouDRef3 = P00C63_A2062VouDRef3[0];
               A2054VouDGls = P00C63_A2054VouDGls[0];
               A2061VouDRef2 = P00C63_A2061VouDRef2[0];
               A2063VouDRef4 = P00C63_A2063VouDRef4[0];
               A2053VouDDoc = P00C63_A2053VouDDoc[0];
               A860CueDsc = P00C63_A860CueDsc[0];
               A2055VouDHab = P00C63_A2055VouDHab[0];
               A2051VouDDeb = P00C63_A2051VouDDeb[0];
               A136VouReg = P00C63_A136VouReg[0];
               A135VouDFec = P00C63_A135VouDFec[0];
               A130VouDSec = P00C63_A130VouDSec[0];
               A860CueDsc = P00C63_A860CueDsc[0];
               A2077VouSts = P00C63_A2077VouSts[0];
               AV13TASICod = A126TASICod;
               AV21VouNum = A129VouNum;
               AV17VouDRef1 = A2059VouDRef1;
               AV55VouReg = A136VouReg;
               AV52VouDFec = A135VouDFec;
               AV19VouDRef3 = A2062VouDRef3;
               AV16VouDGls = StringUtil.Trim( A2054VouDGls);
               AV18VouDRef2 = StringUtil.Trim( A2061VouDRef2);
               AV19VouDRef3 = StringUtil.Trim( A2062VouDRef3);
               AV20VouDRef4 = StringUtil.Trim( A2063VouDRef4);
               AV15VouDDoc = StringUtil.Trim( A2053VouDDoc);
               AV9DCueCod = A91CueCod;
               AV10DCueDsc = StringUtil.Trim( A860CueDsc);
               AV11LBDDebe = NumberUtil.Round( A2055VouDHab, 2);
               AV12LBDHaber = NumberUtil.Round( A2051VouDDeb, 2);
               AV49TDebe = (decimal)(AV49TDebe+AV11LBDDebe);
               AV50THaber = (decimal)(AV50THaber+AV12LBDHaber);
               /* Execute user subroutine: 'DETALLEEXCEL' */
               S143 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV14TSaldo = (decimal)((AV45SaldoDebe+AV50THaber)-(AV46SaldoHaber+AV49TDebe));
         }
      }

      protected void S131( )
      {
         /* 'VALIDAMOVIMIENTO' Routine */
         returnInSub = false;
         AV35Flag = 0;
         /* Using cursor P00C64 */
         pr_default.execute(2, new Object[] {AV22Ano, AV37Mes, AV25cCuenta1});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00C64_A126TASICod[0];
            A129VouNum = P00C64_A129VouNum[0];
            A2077VouSts = P00C64_A2077VouSts[0];
            A91CueCod = P00C64_A91CueCod[0];
            A128VouMes = P00C64_A128VouMes[0];
            A127VouAno = P00C64_A127VouAno[0];
            A130VouDSec = P00C64_A130VouDSec[0];
            A2077VouSts = P00C64_A2077VouSts[0];
            AV35Flag = 1;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         /* Using cursor P00C65 */
         pr_default.execute(3, new Object[] {AV22Ano, AV37Mes, AV13TASICod, AV21VouNum, AV25cCuenta1, AV17VouDRef1});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A91CueCod = P00C65_A91CueCod[0];
            A2059VouDRef1 = P00C65_A2059VouDRef1[0];
            A129VouNum = P00C65_A129VouNum[0];
            A126TASICod = P00C65_A126TASICod[0];
            A128VouMes = P00C65_A128VouMes[0];
            A127VouAno = P00C65_A127VouAno[0];
            A136VouReg = P00C65_A136VouReg[0];
            A135VouDFec = P00C65_A135VouDFec[0];
            A2054VouDGls = P00C65_A2054VouDGls[0];
            A2061VouDRef2 = P00C65_A2061VouDRef2[0];
            A2062VouDRef3 = P00C65_A2062VouDRef3[0];
            A2063VouDRef4 = P00C65_A2063VouDRef4[0];
            A2053VouDDoc = P00C65_A2053VouDDoc[0];
            A860CueDsc = P00C65_A860CueDsc[0];
            A2051VouDDeb = P00C65_A2051VouDDeb[0];
            A2055VouDHab = P00C65_A2055VouDHab[0];
            A130VouDSec = P00C65_A130VouDSec[0];
            A860CueDsc = P00C65_A860CueDsc[0];
            AV55VouReg = A136VouReg;
            AV52VouDFec = A135VouDFec;
            AV16VouDGls = StringUtil.Trim( A2054VouDGls);
            AV18VouDRef2 = StringUtil.Trim( A2061VouDRef2);
            AV19VouDRef3 = StringUtil.Trim( A2062VouDRef3);
            AV20VouDRef4 = StringUtil.Trim( A2063VouDRef4);
            AV15VouDDoc = StringUtil.Trim( A2053VouDDoc);
            AV9DCueCod = A91CueCod;
            AV10DCueDsc = StringUtil.Trim( A860CueDsc);
            AV11LBDDebe = NumberUtil.Round( A2051VouDDeb, 2);
            AV12LBDHaber = NumberUtil.Round( A2055VouDHab, 2);
            /* Execute user subroutine: 'DETALLEEXCEL' */
            S143 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV49TDebe = (decimal)(AV49TDebe+(NumberUtil.Round( A2051VouDDeb, 2)));
            AV50THaber = (decimal)(AV50THaber+(NumberUtil.Round( A2055VouDHab, 2)));
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S143( )
      {
         /* 'DETALLEEXCEL' Routine */
         returnInSub = false;
         AV31ExcelDocument.get_Cells(AV26CellRow, AV34FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV27CueDsc);
         AV31ExcelDocument.get_Cells(AV26CellRow, AV34FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV24CBCod);
         AV31ExcelDocument.get_Cells(AV26CellRow, AV34FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV25cCuenta1);
         AV31ExcelDocument.get_Cells(AV26CellRow, AV34FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV55VouReg);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV52VouDFec ) ;
         AV31ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV31ExcelDocument.get_Cells(AV26CellRow, AV34FirstColumn+4, 1, 1).Date = GXt_dtime1;
         AV31ExcelDocument.get_Cells(AV26CellRow, AV34FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV19VouDRef3);
         AV31ExcelDocument.get_Cells(AV26CellRow, AV34FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV16VouDGls);
         AV31ExcelDocument.get_Cells(AV26CellRow, AV34FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV18VouDRef2);
         AV31ExcelDocument.get_Cells(AV26CellRow, AV34FirstColumn+8, 1, 1).Text = StringUtil.Trim( AV15VouDDoc);
         AV31ExcelDocument.get_Cells(AV26CellRow, AV34FirstColumn+9, 1, 1).Text = StringUtil.Trim( AV9DCueCod);
         AV31ExcelDocument.get_Cells(AV26CellRow, AV34FirstColumn+10, 1, 1).Text = StringUtil.Trim( AV10DCueDsc);
         AV31ExcelDocument.get_Cells(AV26CellRow, AV34FirstColumn+11, 1, 1).Number = (double)(AV11LBDDebe);
         AV31ExcelDocument.get_Cells(AV26CellRow, AV34FirstColumn+12, 1, 1).Number = (double)(AV12LBDHaber);
         AV26CellRow = (int)(AV26CellRow+1);
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
         AV32FileName = "";
         AV30ErrorMessage = "";
         AV23Archivo = new GxFile(context.GetPhysicalPath());
         AV40Path = "";
         AV33FileNameOrigen = "";
         AV43RUC = "";
         AV47Session = context.GetSession();
         AV29Empresa = "";
         AV31ExcelDocument = new ExcelDocumentI();
         AV41Periodo = "";
         scmdbuf = "";
         P00C62_A504CBSts = new short[1] ;
         P00C62_A378CBCueCod = new string[] {""} ;
         P00C62_A491CBCueDsc = new string[] {""} ;
         P00C62_A377CBCod = new string[] {""} ;
         P00C62_A372BanCod = new int[1] ;
         A378CBCueCod = "";
         A491CBCueDsc = "";
         A377CBCod = "";
         AV25cCuenta1 = "";
         AV27CueDsc = "";
         AV24CBCod = "";
         P00C63_A127VouAno = new short[1] ;
         P00C63_A128VouMes = new short[1] ;
         P00C63_A91CueCod = new string[] {""} ;
         P00C63_A2077VouSts = new short[1] ;
         P00C63_A126TASICod = new int[1] ;
         P00C63_A129VouNum = new string[] {""} ;
         P00C63_A2059VouDRef1 = new string[] {""} ;
         P00C63_A2062VouDRef3 = new string[] {""} ;
         P00C63_A2054VouDGls = new string[] {""} ;
         P00C63_A2061VouDRef2 = new string[] {""} ;
         P00C63_A2063VouDRef4 = new string[] {""} ;
         P00C63_A2053VouDDoc = new string[] {""} ;
         P00C63_A860CueDsc = new string[] {""} ;
         P00C63_A2055VouDHab = new decimal[1] ;
         P00C63_A2051VouDDeb = new decimal[1] ;
         P00C63_A136VouReg = new string[] {""} ;
         P00C63_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00C63_A130VouDSec = new int[1] ;
         A91CueCod = "";
         A129VouNum = "";
         A2059VouDRef1 = "";
         A2062VouDRef3 = "";
         A2054VouDGls = "";
         A2061VouDRef2 = "";
         A2063VouDRef4 = "";
         A2053VouDDoc = "";
         A860CueDsc = "";
         A136VouReg = "";
         A135VouDFec = DateTime.MinValue;
         AV21VouNum = "";
         AV17VouDRef1 = "";
         AV55VouReg = "";
         AV52VouDFec = DateTime.MinValue;
         AV19VouDRef3 = "";
         AV16VouDGls = "";
         AV18VouDRef2 = "";
         AV20VouDRef4 = "";
         AV15VouDDoc = "";
         AV9DCueCod = "";
         AV10DCueDsc = "";
         P00C64_A126TASICod = new int[1] ;
         P00C64_A129VouNum = new string[] {""} ;
         P00C64_A2077VouSts = new short[1] ;
         P00C64_A91CueCod = new string[] {""} ;
         P00C64_A128VouMes = new short[1] ;
         P00C64_A127VouAno = new short[1] ;
         P00C64_A130VouDSec = new int[1] ;
         P00C65_A91CueCod = new string[] {""} ;
         P00C65_A2059VouDRef1 = new string[] {""} ;
         P00C65_A129VouNum = new string[] {""} ;
         P00C65_A126TASICod = new int[1] ;
         P00C65_A128VouMes = new short[1] ;
         P00C65_A127VouAno = new short[1] ;
         P00C65_A136VouReg = new string[] {""} ;
         P00C65_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00C65_A2054VouDGls = new string[] {""} ;
         P00C65_A2061VouDRef2 = new string[] {""} ;
         P00C65_A2062VouDRef3 = new string[] {""} ;
         P00C65_A2063VouDRef4 = new string[] {""} ;
         P00C65_A2053VouDDoc = new string[] {""} ;
         P00C65_A860CueDsc = new string[] {""} ;
         P00C65_A2051VouDDeb = new decimal[1] ;
         P00C65_A2055VouDHab = new decimal[1] ;
         P00C65_A130VouDSec = new int[1] ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_librocajabancos1_2excel__default(),
            new Object[][] {
                new Object[] {
               P00C62_A504CBSts, P00C62_A378CBCueCod, P00C62_A491CBCueDsc, P00C62_A377CBCod, P00C62_A372BanCod
               }
               , new Object[] {
               P00C63_A127VouAno, P00C63_A128VouMes, P00C63_A91CueCod, P00C63_A2077VouSts, P00C63_A126TASICod, P00C63_A129VouNum, P00C63_A2059VouDRef1, P00C63_A2062VouDRef3, P00C63_A2054VouDGls, P00C63_A2061VouDRef2,
               P00C63_A2063VouDRef4, P00C63_A2053VouDDoc, P00C63_A860CueDsc, P00C63_A2055VouDHab, P00C63_A2051VouDDeb, P00C63_A136VouReg, P00C63_A135VouDFec, P00C63_A130VouDSec
               }
               , new Object[] {
               P00C64_A126TASICod, P00C64_A129VouNum, P00C64_A2077VouSts, P00C64_A91CueCod, P00C64_A128VouMes, P00C64_A127VouAno, P00C64_A130VouDSec
               }
               , new Object[] {
               P00C65_A91CueCod, P00C65_A2059VouDRef1, P00C65_A129VouNum, P00C65_A126TASICod, P00C65_A128VouMes, P00C65_A127VouAno, P00C65_A136VouReg, P00C65_A135VouDFec, P00C65_A2054VouDGls, P00C65_A2061VouDRef2,
               P00C65_A2062VouDRef3, P00C65_A2063VouDRef4, P00C65_A2053VouDDoc, P00C65_A860CueDsc, P00C65_A2051VouDDeb, P00C65_A2055VouDHab, P00C65_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV22Ano ;
      private short AV37Mes ;
      private short AV38MesAnt ;
      private short A504CBSts ;
      private short AV35Flag ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short A2077VouSts ;
      private int AV26CellRow ;
      private int AV34FirstColumn ;
      private int A372BanCod ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private int AV13TASICod ;
      private decimal AV49TDebe ;
      private decimal AV50THaber ;
      private decimal AV45SaldoDebe ;
      private decimal AV46SaldoHaber ;
      private decimal AV44Saldo ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private decimal AV11LBDDebe ;
      private decimal AV12LBDHaber ;
      private decimal AV14TSaldo ;
      private string AV41Periodo ;
      private string scmdbuf ;
      private string A378CBCueCod ;
      private string A491CBCueDsc ;
      private string A377CBCod ;
      private string AV25cCuenta1 ;
      private string AV27CueDsc ;
      private string AV24CBCod ;
      private string A91CueCod ;
      private string A129VouNum ;
      private string A2054VouDGls ;
      private string A2053VouDDoc ;
      private string A860CueDsc ;
      private string A136VouReg ;
      private string AV21VouNum ;
      private string AV55VouReg ;
      private string AV16VouDGls ;
      private string AV15VouDDoc ;
      private string AV9DCueCod ;
      private string AV10DCueDsc ;
      private DateTime GXt_dtime1 ;
      private DateTime A135VouDFec ;
      private DateTime AV52VouDFec ;
      private bool returnInSub ;
      private string AV32FileName ;
      private string AV30ErrorMessage ;
      private string AV40Path ;
      private string AV33FileNameOrigen ;
      private string AV43RUC ;
      private string AV29Empresa ;
      private string A2059VouDRef1 ;
      private string A2062VouDRef3 ;
      private string A2061VouDRef2 ;
      private string A2063VouDRef4 ;
      private string AV17VouDRef1 ;
      private string AV19VouDRef3 ;
      private string AV18VouDRef2 ;
      private string AV20VouDRef4 ;
      private IGxSession AV47Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private IDataStoreProvider pr_default ;
      private short[] P00C62_A504CBSts ;
      private string[] P00C62_A378CBCueCod ;
      private string[] P00C62_A491CBCueDsc ;
      private string[] P00C62_A377CBCod ;
      private int[] P00C62_A372BanCod ;
      private short[] P00C63_A127VouAno ;
      private short[] P00C63_A128VouMes ;
      private string[] P00C63_A91CueCod ;
      private short[] P00C63_A2077VouSts ;
      private int[] P00C63_A126TASICod ;
      private string[] P00C63_A129VouNum ;
      private string[] P00C63_A2059VouDRef1 ;
      private string[] P00C63_A2062VouDRef3 ;
      private string[] P00C63_A2054VouDGls ;
      private string[] P00C63_A2061VouDRef2 ;
      private string[] P00C63_A2063VouDRef4 ;
      private string[] P00C63_A2053VouDDoc ;
      private string[] P00C63_A860CueDsc ;
      private decimal[] P00C63_A2055VouDHab ;
      private decimal[] P00C63_A2051VouDDeb ;
      private string[] P00C63_A136VouReg ;
      private DateTime[] P00C63_A135VouDFec ;
      private int[] P00C63_A130VouDSec ;
      private int[] P00C64_A126TASICod ;
      private string[] P00C64_A129VouNum ;
      private short[] P00C64_A2077VouSts ;
      private string[] P00C64_A91CueCod ;
      private short[] P00C64_A128VouMes ;
      private short[] P00C64_A127VouAno ;
      private int[] P00C64_A130VouDSec ;
      private string[] P00C65_A91CueCod ;
      private string[] P00C65_A2059VouDRef1 ;
      private string[] P00C65_A129VouNum ;
      private int[] P00C65_A126TASICod ;
      private short[] P00C65_A128VouMes ;
      private short[] P00C65_A127VouAno ;
      private string[] P00C65_A136VouReg ;
      private DateTime[] P00C65_A135VouDFec ;
      private string[] P00C65_A2054VouDGls ;
      private string[] P00C65_A2061VouDRef2 ;
      private string[] P00C65_A2062VouDRef3 ;
      private string[] P00C65_A2063VouDRef4 ;
      private string[] P00C65_A2053VouDDoc ;
      private string[] P00C65_A860CueDsc ;
      private decimal[] P00C65_A2051VouDDeb ;
      private decimal[] P00C65_A2055VouDHab ;
      private int[] P00C65_A130VouDSec ;
      private string aP2_FileName ;
      private string aP3_ErrorMessage ;
      private ExcelDocumentI AV31ExcelDocument ;
      private GxFile AV23Archivo ;
   }

   public class r_librocajabancos1_2excel__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00C62;
          prmP00C62 = new Object[] {
          };
          Object[] prmP00C63;
          prmP00C63 = new Object[] {
          new ParDef("@AV22Ano",GXType.Int16,4,0) ,
          new ParDef("@AV37Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25cCuenta1",GXType.NChar,15,0)
          };
          Object[] prmP00C64;
          prmP00C64 = new Object[] {
          new ParDef("@AV22Ano",GXType.Int16,4,0) ,
          new ParDef("@AV37Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25cCuenta1",GXType.NChar,15,0)
          };
          Object[] prmP00C65;
          prmP00C65 = new Object[] {
          new ParDef("@AV22Ano",GXType.Int16,4,0) ,
          new ParDef("@AV37Mes",GXType.Int16,2,0) ,
          new ParDef("@AV13TASICod",GXType.Int32,6,0) ,
          new ParDef("@AV21VouNum",GXType.NChar,10,0) ,
          new ParDef("@AV25cCuenta1",GXType.Char,15,0) ,
          new ParDef("@AV17VouDRef1",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C62", "SELECT T1.[CBSts], T1.[CBCueCod] AS CBCueCod, T2.[CueDsc] AS CBCueDsc, T1.[CBCod], T1.[BanCod] FROM ([TSCUENTABANCO] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CBCueCod]) WHERE T1.[CBSts] = 1 ORDER BY T1.[BanCod], T1.[CBCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C62,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C63", "SELECT T1.[VouAno], T1.[VouMes], T1.[CueCod], T3.[VouSts], T1.[TASICod], T1.[VouNum], T1.[VouDRef1], T1.[VouDRef3], T1.[VouDGls], T1.[VouDRef2], T1.[VouDRef4], T1.[VouDDoc], T2.[CueDsc], T1.[VouDHab], T1.[VouDDeb], T1.[VouReg], T1.[VouDFec], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV22Ano) AND (T1.[VouMes] = @AV37Mes) AND (T1.[CueCod] = @AV25cCuenta1) AND (T3.[VouSts] = 1) ORDER BY T1.[VouDFec], T1.[VouReg] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C63,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C64", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV22Ano and T1.[VouMes] = @AV37Mes and T1.[CueCod] = @AV25cCuenta1) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C64,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C65", "SELECT T1.[CueCod], T1.[VouDRef1], T1.[VouNum], T1.[TASICod], T1.[VouMes], T1.[VouAno], T1.[VouReg], T1.[VouDFec], T1.[VouDGls], T1.[VouDRef2], T1.[VouDRef3], T1.[VouDRef4], T1.[VouDDoc], T2.[CueDsc], T1.[VouDDeb], T1.[VouDHab], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE (T1.[VouAno] = @AV22Ano and T1.[VouMes] = @AV37Mes and T1.[TASICod] = @AV13TASICod and T1.[VouNum] = @AV21VouNum) AND (T1.[CueCod] <> @AV25cCuenta1) AND (Not (T1.[VouDRef1] = '')) AND (T1.[VouDRef1] = @AV17VouDRef1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C65,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((string[]) buf[12])[0] = rslt.getString(13, 100);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 15);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(17);
                ((int[]) buf[17])[0] = rslt.getInt(18);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 20);
                ((string[]) buf[13])[0] = rslt.getString(14, 100);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((int[]) buf[16])[0] = rslt.getInt(17);
                return;
       }
    }

 }

}
