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
   public class r_saldoscontablesexcel : GXProcedure
   {
      public r_saldoscontablesexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_saldoscontablesexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FDesde ,
                           ref DateTime aP1_FHasta ,
                           ref string aP2_cCuenta1 ,
                           ref string aP3_cCuenta2 ,
                           ref string aP4_cCosto ,
                           ref string aP5_CueCodAux ,
                           out string aP6_Filename ,
                           out string aP7_ErrorMessage )
      {
         this.AV37FDesde = aP0_FDesde;
         this.AV41FHasta = aP1_FHasta;
         this.AV15cCuenta1 = aP2_cCuenta1;
         this.AV16cCuenta2 = aP3_cCuenta2;
         this.AV14cCosto = aP4_cCosto;
         this.AV22CueCodAux = aP5_CueCodAux;
         this.AV42Filename = "" ;
         this.AV35ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_FDesde=this.AV37FDesde;
         aP1_FHasta=this.AV41FHasta;
         aP2_cCuenta1=this.AV15cCuenta1;
         aP3_cCuenta2=this.AV16cCuenta2;
         aP4_cCosto=this.AV14cCosto;
         aP5_CueCodAux=this.AV22CueCodAux;
         aP6_Filename=this.AV42Filename;
         aP7_ErrorMessage=this.AV35ErrorMessage;
      }

      public string executeUdp( ref DateTime aP0_FDesde ,
                                ref DateTime aP1_FHasta ,
                                ref string aP2_cCuenta1 ,
                                ref string aP3_cCuenta2 ,
                                ref string aP4_cCosto ,
                                ref string aP5_CueCodAux ,
                                out string aP6_Filename )
      {
         execute(ref aP0_FDesde, ref aP1_FHasta, ref aP2_cCuenta1, ref aP3_cCuenta2, ref aP4_cCosto, ref aP5_CueCodAux, out aP6_Filename, out aP7_ErrorMessage);
         return AV35ErrorMessage ;
      }

      public void executeSubmit( ref DateTime aP0_FDesde ,
                                 ref DateTime aP1_FHasta ,
                                 ref string aP2_cCuenta1 ,
                                 ref string aP3_cCuenta2 ,
                                 ref string aP4_cCosto ,
                                 ref string aP5_CueCodAux ,
                                 out string aP6_Filename ,
                                 out string aP7_ErrorMessage )
      {
         r_saldoscontablesexcel objr_saldoscontablesexcel;
         objr_saldoscontablesexcel = new r_saldoscontablesexcel();
         objr_saldoscontablesexcel.AV37FDesde = aP0_FDesde;
         objr_saldoscontablesexcel.AV41FHasta = aP1_FHasta;
         objr_saldoscontablesexcel.AV15cCuenta1 = aP2_cCuenta1;
         objr_saldoscontablesexcel.AV16cCuenta2 = aP3_cCuenta2;
         objr_saldoscontablesexcel.AV14cCosto = aP4_cCosto;
         objr_saldoscontablesexcel.AV22CueCodAux = aP5_CueCodAux;
         objr_saldoscontablesexcel.AV42Filename = "" ;
         objr_saldoscontablesexcel.AV35ErrorMessage = "" ;
         objr_saldoscontablesexcel.context.SetSubmitInitialConfig(context);
         objr_saldoscontablesexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_saldoscontablesexcel);
         aP0_FDesde=this.AV37FDesde;
         aP1_FHasta=this.AV41FHasta;
         aP2_cCuenta1=this.AV15cCuenta1;
         aP3_cCuenta2=this.AV16cCuenta2;
         aP4_cCosto=this.AV14cCosto;
         aP5_CueCodAux=this.AV22CueCodAux;
         aP6_Filename=this.AV42Filename;
         aP7_ErrorMessage=this.AV35ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_saldoscontablesexcel)stateInfo).executePrivate();
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
         AV13Archivo.Source = "Excel/PlantillasSaldosContables.xlsx";
         AV63Path = AV13Archivo.GetPath();
         AV43FilenameOrigen = StringUtil.Trim( AV63Path) + "\\PlantillasSaldosContables.xlsx";
         AV42Filename = "Excel/SaldosContables" + ".xlsx";
         AV36ExcelDocument.Clear();
         AV36ExcelDocument.Template = AV43FilenameOrigen;
         AV36ExcelDocument.Open(AV42Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV39FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV55Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
         AV40FechaD = context.localUtil.CToD( AV39FechaC, 2);
         GXt_char1 = AV18cMes;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV55Mes, out  GXt_char1) ;
         AV18cMes = GXt_char1;
         AV64Periodo = "Del : " + StringUtil.Trim( context.localUtil.DToC( AV37FDesde, 2, "/")) + " Al : " + StringUtil.Trim( context.localUtil.DToC( AV41FHasta, 2, "/"));
         AV17CellRow = 3;
         AV44FirstColumn = 4;
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV64Periodo);
         AV17CellRow = 5;
         AV44FirstColumn = 1;
         AV82TDebePagMo = 0.00m;
         AV88THaberPagMO = 0.00m;
         AV81TDebePagMe = 0.00m;
         AV87THaberPagMe = 0.00m;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV15cCuenta1 ,
                                              AV16cCuenta2 ,
                                              AV22CueCodAux ,
                                              A91CueCod ,
                                              A133CueCodAux ,
                                              A135VouDFec ,
                                              AV37FDesde ,
                                              AV41FHasta } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00AY2 */
         pr_default.execute(0, new Object[] {AV37FDesde, AV41FHasta, AV15cCuenta1, AV16cCuenta2, AV22CueCodAux});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAY2 = false;
            A133CueCodAux = P00AY2_A133CueCodAux[0];
            A91CueCod = P00AY2_A91CueCod[0];
            A135VouDFec = P00AY2_A135VouDFec[0];
            A860CueDsc = P00AY2_A860CueDsc[0];
            A70TipACod = P00AY2_A70TipACod[0];
            n70TipACod = P00AY2_n70TipACod[0];
            A79COSCod = P00AY2_A79COSCod[0];
            n79COSCod = P00AY2_n79COSCod[0];
            A127VouAno = P00AY2_A127VouAno[0];
            A128VouMes = P00AY2_A128VouMes[0];
            A126TASICod = P00AY2_A126TASICod[0];
            A129VouNum = P00AY2_A129VouNum[0];
            A130VouDSec = P00AY2_A130VouDSec[0];
            A860CueDsc = P00AY2_A860CueDsc[0];
            A70TipACod = P00AY2_A70TipACod[0];
            n70TipACod = P00AY2_n70TipACod[0];
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AY2_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRKAY2 = false;
               A133CueCodAux = P00AY2_A133CueCodAux[0];
               A127VouAno = P00AY2_A127VouAno[0];
               A128VouMes = P00AY2_A128VouMes[0];
               A126TASICod = P00AY2_A126TASICod[0];
               A129VouNum = P00AY2_A129VouNum[0];
               A130VouDSec = P00AY2_A130VouDSec[0];
               BRKAY2 = true;
               pr_default.readNext(0);
            }
            AV21CueCod = A91CueCod;
            AV25CueDsc = A860CueDsc;
            AV89TipACod = A70TipACod;
            AV20CosCod = A79COSCod;
            AV23CueDAxu = A133CueCodAux;
            AV24CueDAxuDsc = "SALDO INICIAL";
            AV76TasiAbr = "";
            AV107VouNum = "";
            AV96VouDDoc = "";
            AV108VouReg = "";
            AV97VouDFec = DateTime.MinValue;
            AV47Glosa = "";
            AV95VouDDeb = 0.00m;
            AV99VouDHab = 0.00m;
            AV8VouDDebO = 0.00m;
            AV9VouDHabO = 0.00m;
            AV10VouDTcmb = 0.00m;
            AV29DebeME = 0.00m;
            AV51HaberME = 0.00m;
            AV102VouDRef1 = "";
            AV100VouDordCod = "";
            AV101VouDProdCod = "";
            AV56MonOrigen = "";
            GXt_char1 = "";
            new GeneXus.Programs.contabilidad.pobtienesaldoscuentarangosfechas(context ).execute( ref  AV21CueCod, ref  GXt_char1, ref  AV37FDesde, out  AV95VouDDeb, out  AV99VouDHab, out  AV29DebeME, out  AV51HaberME) ;
            AV75SaldoMN = (decimal)(AV95VouDDeb-AV99VouDHab);
            AV74SaldoME = (decimal)(AV29DebeME-AV51HaberME);
            AV95VouDDeb = ((AV75SaldoMN>Convert.ToDecimal(0)) ? AV75SaldoMN : (decimal)(0));
            AV99VouDHab = ((AV75SaldoMN<Convert.ToDecimal(0)) ? AV75SaldoMN*-1 : (decimal)(0));
            AV29DebeME = ((AV74SaldoME>Convert.ToDecimal(0)) ? AV74SaldoME : (decimal)(0));
            AV51HaberME = ((AV74SaldoME<Convert.ToDecimal(0)) ? AV74SaldoME*-1 : (decimal)(0));
            if ( ! (Convert.ToDecimal(0)==AV95VouDDeb) || ! (Convert.ToDecimal(0)==AV99VouDHab) )
            {
               /* Execute user subroutine: 'PRINTMOVIMIENTOS' */
               S134 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
            }
            /* Execute user subroutine: 'DETALLECONTABLE' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV17CellRow = (int)(AV17CellRow+1);
            if ( ! BRKAY2 )
            {
               BRKAY2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV36ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV36ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'DETALLECONTABLE' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV22CueCodAux ,
                                              A133CueCodAux ,
                                              A135VouDFec ,
                                              AV37FDesde ,
                                              AV41FHasta ,
                                              A2077VouSts ,
                                              AV21CueCod ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00AY3 */
         pr_default.execute(1, new Object[] {AV21CueCod, AV37FDesde, AV41FHasta, AV22CueCodAux});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A127VouAno = P00AY3_A127VouAno[0];
            A128VouMes = P00AY3_A128VouMes[0];
            A126TASICod = P00AY3_A126TASICod[0];
            A91CueCod = P00AY3_A91CueCod[0];
            A2077VouSts = P00AY3_A2077VouSts[0];
            A133CueCodAux = P00AY3_A133CueCodAux[0];
            A135VouDFec = P00AY3_A135VouDFec[0];
            A79COSCod = P00AY3_A79COSCod[0];
            n79COSCod = P00AY3_n79COSCod[0];
            A1894TASIAbr = P00AY3_A1894TASIAbr[0];
            A129VouNum = P00AY3_A129VouNum[0];
            A2053VouDDoc = P00AY3_A2053VouDDoc[0];
            A136VouReg = P00AY3_A136VouReg[0];
            A2075VouGls = P00AY3_A2075VouGls[0];
            A2051VouDDeb = P00AY3_A2051VouDDeb[0];
            A2055VouDHab = P00AY3_A2055VouDHab[0];
            A2052VouDDebO = P00AY3_A2052VouDDebO[0];
            A2056VouDHabO = P00AY3_A2056VouDHabO[0];
            A2069VouDTcmb = P00AY3_A2069VouDTcmb[0];
            A2059VouDRef1 = P00AY3_A2059VouDRef1[0];
            A2057VouDordCod = P00AY3_A2057VouDordCod[0];
            A2058VouDProdCod = P00AY3_A2058VouDProdCod[0];
            A2063VouDRef4 = P00AY3_A2063VouDRef4[0];
            A2064VouDRef5 = P00AY3_A2064VouDRef5[0];
            A2065VouDRef6 = P00AY3_A2065VouDRef6[0];
            A2066VouDRef7 = P00AY3_A2066VouDRef7[0];
            A131VouDMon = P00AY3_A131VouDMon[0];
            A2054VouDGls = P00AY3_A2054VouDGls[0];
            A130VouDSec = P00AY3_A130VouDSec[0];
            A1894TASIAbr = P00AY3_A1894TASIAbr[0];
            A2077VouSts = P00AY3_A2077VouSts[0];
            A2075VouGls = P00AY3_A2075VouGls[0];
            AV20CosCod = A79COSCod;
            AV23CueDAxu = A133CueCodAux;
            AV24CueDAxuDsc = "";
            if ( ! (0==AV89TipACod) )
            {
               /* Execute user subroutine: 'NOMBREAUXILIAR' */
               S124 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
            }
            AV76TasiAbr = StringUtil.Trim( A1894TASIAbr);
            AV107VouNum = A129VouNum;
            AV96VouDDoc = A2053VouDDoc;
            AV108VouReg = A136VouReg;
            AV97VouDFec = A135VouDFec;
            AV47Glosa = StringUtil.Trim( A2075VouGls);
            AV95VouDDeb = A2051VouDDeb;
            AV99VouDHab = A2055VouDHab;
            AV8VouDDebO = A2052VouDDebO;
            AV9VouDHabO = A2056VouDHabO;
            AV10VouDTcmb = A2069VouDTcmb;
            AV102VouDRef1 = A2059VouDRef1;
            AV100VouDordCod = A2057VouDordCod;
            AV101VouDProdCod = A2058VouDProdCod;
            AV103VouDRef4 = A2063VouDRef4;
            AV104VouDRef5 = A2064VouDRef5;
            AV105VouDRef6 = A2065VouDRef6;
            AV106VouDRef7 = A2066VouDRef7;
            AV56MonOrigen = ((A131VouDMon==1) ? "MN" : "ME");
            AV29DebeME = 0.00m;
            AV51HaberME = 0.00m;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
            {
               AV47Glosa = StringUtil.Trim( A2054VouDGls);
            }
            if ( ! ( A131VouDMon == 1 ) )
            {
               AV29DebeME = A2052VouDDebO;
               AV51HaberME = A2056VouDHabO;
            }
            /* Execute user subroutine: 'PRINTMOVIMIENTOS' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S124( )
      {
         /* 'NOMBREAUXILIAR' Routine */
         returnInSub = false;
         AV114GXLvl141 = 0;
         /* Using cursor P00AY4 */
         pr_default.execute(2, new Object[] {AV89TipACod, AV23CueDAxu});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A71TipADCod = P00AY4_A71TipADCod[0];
            A70TipACod = P00AY4_A70TipACod[0];
            n70TipACod = P00AY4_n70TipACod[0];
            A72TipADDsc = P00AY4_A72TipADDsc[0];
            AV114GXLvl141 = 1;
            AV24CueDAxuDsc = A72TipADDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( AV114GXLvl141 == 0 )
         {
            AV24CueDAxuDsc = "SIN AUXILIAR";
         }
      }

      protected void S134( )
      {
         /* 'PRINTMOVIMIENTOS' Routine */
         returnInSub = false;
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV21CueCod);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV25CueDsc);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV20CosCod);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV23CueDAxu);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV24CueDAxuDsc);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV76TasiAbr);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV107VouNum);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV96VouDDoc);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+8, 1, 1).Text = StringUtil.Trim( AV108VouReg);
         GXt_dtime2 = DateTimeUtil.ResetTime( AV97VouDFec ) ;
         AV36ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+9, 1, 1).Date = GXt_dtime2;
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+10, 1, 1).Text = StringUtil.Trim( AV47Glosa);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+11, 1, 1).Text = StringUtil.Trim( AV56MonOrigen);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+12, 1, 1).Number = (double)(NumberUtil.Round( AV95VouDDeb, 2));
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+13, 1, 1).Number = (double)(NumberUtil.Round( AV99VouDHab, 2));
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+14, 1, 1).Number = (double)(NumberUtil.Round( AV29DebeME, 2));
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+15, 1, 1).Number = (double)(NumberUtil.Round( AV51HaberME, 2));
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+16, 1, 1).Number = (double)(AV10VouDTcmb);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+17, 1, 1).Text = StringUtil.Trim( AV102VouDRef1);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+18, 1, 1).Text = StringUtil.Trim( AV100VouDordCod);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+19, 1, 1).Text = StringUtil.Trim( AV101VouDProdCod);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+20, 1, 1).Text = StringUtil.Trim( AV103VouDRef4);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+21, 1, 1).Text = StringUtil.Trim( AV104VouDRef5);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+22, 1, 1).Text = StringUtil.Trim( AV105VouDRef6);
         AV36ExcelDocument.get_Cells(AV17CellRow, AV44FirstColumn+23, 1, 1).Text = StringUtil.Trim( AV106VouDRef7);
         AV17CellRow = (int)(AV17CellRow+1);
      }

      protected void S141( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV36ExcelDocument.ErrCode != 0 )
         {
            AV42Filename = "";
            AV35ErrorMessage = AV36ExcelDocument.ErrDescription;
            AV36ExcelDocument.Close();
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
         AV42Filename = "";
         AV35ErrorMessage = "";
         AV13Archivo = new GxFile(context.GetPhysicalPath());
         AV63Path = "";
         AV43FilenameOrigen = "";
         AV36ExcelDocument = new ExcelDocumentI();
         AV39FechaC = "";
         AV40FechaD = DateTime.MinValue;
         AV18cMes = "";
         AV64Periodo = "";
         scmdbuf = "";
         A91CueCod = "";
         A133CueCodAux = "";
         A135VouDFec = DateTime.MinValue;
         P00AY2_A133CueCodAux = new string[] {""} ;
         P00AY2_A91CueCod = new string[] {""} ;
         P00AY2_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00AY2_A860CueDsc = new string[] {""} ;
         P00AY2_A70TipACod = new int[1] ;
         P00AY2_n70TipACod = new bool[] {false} ;
         P00AY2_A79COSCod = new string[] {""} ;
         P00AY2_n79COSCod = new bool[] {false} ;
         P00AY2_A127VouAno = new short[1] ;
         P00AY2_A128VouMes = new short[1] ;
         P00AY2_A126TASICod = new int[1] ;
         P00AY2_A129VouNum = new string[] {""} ;
         P00AY2_A130VouDSec = new int[1] ;
         A860CueDsc = "";
         A79COSCod = "";
         A129VouNum = "";
         AV21CueCod = "";
         AV25CueDsc = "";
         AV20CosCod = "";
         AV23CueDAxu = "";
         AV24CueDAxuDsc = "";
         AV76TasiAbr = "";
         AV107VouNum = "";
         AV96VouDDoc = "";
         AV108VouReg = "";
         AV97VouDFec = DateTime.MinValue;
         AV47Glosa = "";
         AV102VouDRef1 = "";
         AV100VouDordCod = "";
         AV101VouDProdCod = "";
         AV56MonOrigen = "";
         GXt_char1 = "";
         P00AY3_A127VouAno = new short[1] ;
         P00AY3_A128VouMes = new short[1] ;
         P00AY3_A126TASICod = new int[1] ;
         P00AY3_A91CueCod = new string[] {""} ;
         P00AY3_A2077VouSts = new short[1] ;
         P00AY3_A133CueCodAux = new string[] {""} ;
         P00AY3_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00AY3_A79COSCod = new string[] {""} ;
         P00AY3_n79COSCod = new bool[] {false} ;
         P00AY3_A1894TASIAbr = new string[] {""} ;
         P00AY3_A129VouNum = new string[] {""} ;
         P00AY3_A2053VouDDoc = new string[] {""} ;
         P00AY3_A136VouReg = new string[] {""} ;
         P00AY3_A2075VouGls = new string[] {""} ;
         P00AY3_A2051VouDDeb = new decimal[1] ;
         P00AY3_A2055VouDHab = new decimal[1] ;
         P00AY3_A2052VouDDebO = new decimal[1] ;
         P00AY3_A2056VouDHabO = new decimal[1] ;
         P00AY3_A2069VouDTcmb = new decimal[1] ;
         P00AY3_A2059VouDRef1 = new string[] {""} ;
         P00AY3_A2057VouDordCod = new string[] {""} ;
         P00AY3_A2058VouDProdCod = new string[] {""} ;
         P00AY3_A2063VouDRef4 = new string[] {""} ;
         P00AY3_A2064VouDRef5 = new string[] {""} ;
         P00AY3_A2065VouDRef6 = new string[] {""} ;
         P00AY3_A2066VouDRef7 = new string[] {""} ;
         P00AY3_A131VouDMon = new int[1] ;
         P00AY3_A2054VouDGls = new string[] {""} ;
         P00AY3_A130VouDSec = new int[1] ;
         A1894TASIAbr = "";
         A2053VouDDoc = "";
         A136VouReg = "";
         A2075VouGls = "";
         A2059VouDRef1 = "";
         A2057VouDordCod = "";
         A2058VouDProdCod = "";
         A2063VouDRef4 = "";
         A2064VouDRef5 = "";
         A2065VouDRef6 = "";
         A2066VouDRef7 = "";
         A2054VouDGls = "";
         AV103VouDRef4 = "";
         AV104VouDRef5 = "";
         AV105VouDRef6 = "";
         AV106VouDRef7 = "";
         P00AY4_A71TipADCod = new string[] {""} ;
         P00AY4_A70TipACod = new int[1] ;
         P00AY4_n70TipACod = new bool[] {false} ;
         P00AY4_A72TipADDsc = new string[] {""} ;
         A71TipADCod = "";
         A72TipADDsc = "";
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_saldoscontablesexcel__default(),
            new Object[][] {
                new Object[] {
               P00AY2_A133CueCodAux, P00AY2_A91CueCod, P00AY2_A135VouDFec, P00AY2_A860CueDsc, P00AY2_A70TipACod, P00AY2_n70TipACod, P00AY2_A79COSCod, P00AY2_n79COSCod, P00AY2_A127VouAno, P00AY2_A128VouMes,
               P00AY2_A126TASICod, P00AY2_A129VouNum, P00AY2_A130VouDSec
               }
               , new Object[] {
               P00AY3_A127VouAno, P00AY3_A128VouMes, P00AY3_A126TASICod, P00AY3_A91CueCod, P00AY3_A2077VouSts, P00AY3_A133CueCodAux, P00AY3_A135VouDFec, P00AY3_A79COSCod, P00AY3_n79COSCod, P00AY3_A1894TASIAbr,
               P00AY3_A129VouNum, P00AY3_A2053VouDDoc, P00AY3_A136VouReg, P00AY3_A2075VouGls, P00AY3_A2051VouDDeb, P00AY3_A2055VouDHab, P00AY3_A2052VouDDebO, P00AY3_A2056VouDHabO, P00AY3_A2069VouDTcmb, P00AY3_A2059VouDRef1,
               P00AY3_A2057VouDordCod, P00AY3_A2058VouDProdCod, P00AY3_A2063VouDRef4, P00AY3_A2064VouDRef5, P00AY3_A2065VouDRef6, P00AY3_A2066VouDRef7, P00AY3_A131VouDMon, P00AY3_A2054VouDGls, P00AY3_A130VouDSec
               }
               , new Object[] {
               P00AY4_A71TipADCod, P00AY4_A70TipACod, P00AY4_A72TipADDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV55Mes ;
      private short AV11Ano ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short A2077VouSts ;
      private short AV114GXLvl141 ;
      private int AV17CellRow ;
      private int AV44FirstColumn ;
      private int A70TipACod ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private int AV89TipACod ;
      private int A131VouDMon ;
      private decimal AV82TDebePagMo ;
      private decimal AV88THaberPagMO ;
      private decimal AV81TDebePagMe ;
      private decimal AV87THaberPagMe ;
      private decimal AV95VouDDeb ;
      private decimal AV99VouDHab ;
      private decimal AV8VouDDebO ;
      private decimal AV9VouDHabO ;
      private decimal AV10VouDTcmb ;
      private decimal AV29DebeME ;
      private decimal AV51HaberME ;
      private decimal AV75SaldoMN ;
      private decimal AV74SaldoME ;
      private decimal A2051VouDDeb ;
      private decimal A2055VouDHab ;
      private decimal A2052VouDDebO ;
      private decimal A2056VouDHabO ;
      private decimal A2069VouDTcmb ;
      private string AV15cCuenta1 ;
      private string AV16cCuenta2 ;
      private string AV14cCosto ;
      private string AV22CueCodAux ;
      private string AV63Path ;
      private string AV39FechaC ;
      private string AV18cMes ;
      private string AV64Periodo ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A133CueCodAux ;
      private string A860CueDsc ;
      private string A79COSCod ;
      private string A129VouNum ;
      private string AV21CueCod ;
      private string AV25CueDsc ;
      private string AV20CosCod ;
      private string AV23CueDAxu ;
      private string AV24CueDAxuDsc ;
      private string AV76TasiAbr ;
      private string AV107VouNum ;
      private string AV96VouDDoc ;
      private string AV108VouReg ;
      private string AV47Glosa ;
      private string AV100VouDordCod ;
      private string AV101VouDProdCod ;
      private string GXt_char1 ;
      private string A1894TASIAbr ;
      private string A2053VouDDoc ;
      private string A136VouReg ;
      private string A2075VouGls ;
      private string A2057VouDordCod ;
      private string A2058VouDProdCod ;
      private string A2054VouDGls ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private DateTime GXt_dtime2 ;
      private DateTime AV37FDesde ;
      private DateTime AV41FHasta ;
      private DateTime AV40FechaD ;
      private DateTime A135VouDFec ;
      private DateTime AV97VouDFec ;
      private bool returnInSub ;
      private bool BRKAY2 ;
      private bool n70TipACod ;
      private bool n79COSCod ;
      private string AV42Filename ;
      private string AV35ErrorMessage ;
      private string AV43FilenameOrigen ;
      private string AV102VouDRef1 ;
      private string AV56MonOrigen ;
      private string A2059VouDRef1 ;
      private string A2063VouDRef4 ;
      private string A2064VouDRef5 ;
      private string A2065VouDRef6 ;
      private string A2066VouDRef7 ;
      private string AV103VouDRef4 ;
      private string AV104VouDRef5 ;
      private string AV105VouDRef6 ;
      private string AV106VouDRef7 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FDesde ;
      private DateTime aP1_FHasta ;
      private string aP2_cCuenta1 ;
      private string aP3_cCuenta2 ;
      private string aP4_cCosto ;
      private string aP5_CueCodAux ;
      private IDataStoreProvider pr_default ;
      private string[] P00AY2_A133CueCodAux ;
      private string[] P00AY2_A91CueCod ;
      private DateTime[] P00AY2_A135VouDFec ;
      private string[] P00AY2_A860CueDsc ;
      private int[] P00AY2_A70TipACod ;
      private bool[] P00AY2_n70TipACod ;
      private string[] P00AY2_A79COSCod ;
      private bool[] P00AY2_n79COSCod ;
      private short[] P00AY2_A127VouAno ;
      private short[] P00AY2_A128VouMes ;
      private int[] P00AY2_A126TASICod ;
      private string[] P00AY2_A129VouNum ;
      private int[] P00AY2_A130VouDSec ;
      private short[] P00AY3_A127VouAno ;
      private short[] P00AY3_A128VouMes ;
      private int[] P00AY3_A126TASICod ;
      private string[] P00AY3_A91CueCod ;
      private short[] P00AY3_A2077VouSts ;
      private string[] P00AY3_A133CueCodAux ;
      private DateTime[] P00AY3_A135VouDFec ;
      private string[] P00AY3_A79COSCod ;
      private bool[] P00AY3_n79COSCod ;
      private string[] P00AY3_A1894TASIAbr ;
      private string[] P00AY3_A129VouNum ;
      private string[] P00AY3_A2053VouDDoc ;
      private string[] P00AY3_A136VouReg ;
      private string[] P00AY3_A2075VouGls ;
      private decimal[] P00AY3_A2051VouDDeb ;
      private decimal[] P00AY3_A2055VouDHab ;
      private decimal[] P00AY3_A2052VouDDebO ;
      private decimal[] P00AY3_A2056VouDHabO ;
      private decimal[] P00AY3_A2069VouDTcmb ;
      private string[] P00AY3_A2059VouDRef1 ;
      private string[] P00AY3_A2057VouDordCod ;
      private string[] P00AY3_A2058VouDProdCod ;
      private string[] P00AY3_A2063VouDRef4 ;
      private string[] P00AY3_A2064VouDRef5 ;
      private string[] P00AY3_A2065VouDRef6 ;
      private string[] P00AY3_A2066VouDRef7 ;
      private int[] P00AY3_A131VouDMon ;
      private string[] P00AY3_A2054VouDGls ;
      private int[] P00AY3_A130VouDSec ;
      private string[] P00AY4_A71TipADCod ;
      private int[] P00AY4_A70TipACod ;
      private bool[] P00AY4_n70TipACod ;
      private string[] P00AY4_A72TipADDsc ;
      private string aP6_Filename ;
      private string aP7_ErrorMessage ;
      private ExcelDocumentI AV36ExcelDocument ;
      private GxFile AV13Archivo ;
   }

   public class r_saldoscontablesexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AY2( IGxContext context ,
                                             string AV15cCuenta1 ,
                                             string AV16cCuenta2 ,
                                             string AV22CueCodAux ,
                                             string A91CueCod ,
                                             string A133CueCodAux ,
                                             DateTime A135VouDFec ,
                                             DateTime AV37FDesde ,
                                             DateTime AV41FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouDFec], T2.[CueDsc], T2.[TipACod], T1.[COSCod], T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         AddWhere(sWhereString, "(T1.[VouDFec] >= @AV37FDesde)");
         AddWhere(sWhereString, "(T1.[VouDFec] <= @AV41FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15cCuenta1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] >= @AV15cCuenta1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16cCuenta2)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] <= @AV16cCuenta2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CueCodAux)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV22CueCodAux)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[CueCodAux]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00AY3( IGxContext context ,
                                             string AV22CueCodAux ,
                                             string A133CueCodAux ,
                                             DateTime A135VouDFec ,
                                             DateTime AV37FDesde ,
                                             DateTime AV41FHasta ,
                                             short A2077VouSts ,
                                             string AV21CueCod ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[4];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[CueCod], T3.[VouSts], T1.[CueCodAux], T1.[VouDFec], T1.[COSCod], T2.[TASIAbr], T1.[VouNum], T1.[VouDDoc], T1.[VouReg], T3.[VouGls], T1.[VouDDeb], T1.[VouDHab], T1.[VouDDebO], T1.[VouDHabO], T1.[VouDTcmb], T1.[VouDRef1], T1.[VouDordCod], T1.[VouDProdCod], T1.[VouDRef4], T1.[VouDRef5], T1.[VouDRef6], T1.[VouDRef7], T1.[VouDMon], T1.[VouDGls], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV21CueCod)");
         AddWhere(sWhereString, "(T1.[VouDFec] >= @AV37FDesde)");
         AddWhere(sWhereString, "(T1.[VouDFec] <= @AV41FHasta)");
         AddWhere(sWhereString, "(T3.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CueCodAux)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV22CueCodAux)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[CueCodAux], T1.[VouDFec]";
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
                     return conditional_P00AY2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] );
               case 1 :
                     return conditional_P00AY3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AY4;
          prmP00AY4 = new Object[] {
          new ParDef("@AV89TipACod",GXType.Int32,6,0) ,
          new ParDef("@AV23CueDAxu",GXType.NChar,20,0)
          };
          Object[] prmP00AY2;
          prmP00AY2 = new Object[] {
          new ParDef("@AV37FDesde",GXType.Date,8,0) ,
          new ParDef("@AV41FHasta",GXType.Date,8,0) ,
          new ParDef("@AV15cCuenta1",GXType.Char,15,0) ,
          new ParDef("@AV16cCuenta2",GXType.Char,15,0) ,
          new ParDef("@AV22CueCodAux",GXType.NChar,20,0)
          };
          Object[] prmP00AY3;
          prmP00AY3 = new Object[] {
          new ParDef("@AV21CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV37FDesde",GXType.Date,8,0) ,
          new ParDef("@AV41FHasta",GXType.Date,8,0) ,
          new ParDef("@AV22CueCodAux",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AY2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AY2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AY3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AY3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AY4", "SELECT [TipADCod], [TipACod], [TipADDsc] FROM [CBAUXILIARES] WHERE [TipACod] = @AV89TipACod and [TipADCod] = @AV23CueDAxu ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AY4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 10);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((short[]) buf[8])[0] = rslt.getShort(7);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 10);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 5);
                ((string[]) buf[10])[0] = rslt.getString(10, 10);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((string[]) buf[12])[0] = rslt.getString(12, 15);
                ((string[]) buf[13])[0] = rslt.getString(13, 100);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((string[]) buf[19])[0] = rslt.getVarchar(19);
                ((string[]) buf[20])[0] = rslt.getString(20, 10);
                ((string[]) buf[21])[0] = rslt.getString(21, 15);
                ((string[]) buf[22])[0] = rslt.getVarchar(22);
                ((string[]) buf[23])[0] = rslt.getVarchar(23);
                ((string[]) buf[24])[0] = rslt.getVarchar(24);
                ((string[]) buf[25])[0] = rslt.getVarchar(25);
                ((int[]) buf[26])[0] = rslt.getInt(26);
                ((string[]) buf[27])[0] = rslt.getString(27, 100);
                ((int[]) buf[28])[0] = rslt.getInt(28);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
