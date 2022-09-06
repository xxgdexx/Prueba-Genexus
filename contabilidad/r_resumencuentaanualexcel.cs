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
   public class r_resumencuentaanualexcel : GXProcedure
   {
      public r_resumencuentaanualexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumencuentaanualexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref string aP1_Cuenta1 ,
                           ref string aP2_Cuenta2 ,
                           out string aP3_Filename ,
                           out string aP4_ErrorMessage )
      {
         this.AV8Ano = aP0_Ano;
         this.AV12Cuenta1 = aP1_Cuenta1;
         this.AV13Cuenta2 = aP2_Cuenta2;
         this.AV25Filename = "" ;
         this.AV20ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_Cuenta1=this.AV12Cuenta1;
         aP2_Cuenta2=this.AV13Cuenta2;
         aP3_Filename=this.AV25Filename;
         aP4_ErrorMessage=this.AV20ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref string aP1_Cuenta1 ,
                                ref string aP2_Cuenta2 ,
                                out string aP3_Filename )
      {
         execute(ref aP0_Ano, ref aP1_Cuenta1, ref aP2_Cuenta2, out aP3_Filename, out aP4_ErrorMessage);
         return AV20ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref string aP1_Cuenta1 ,
                                 ref string aP2_Cuenta2 ,
                                 out string aP3_Filename ,
                                 out string aP4_ErrorMessage )
      {
         r_resumencuentaanualexcel objr_resumencuentaanualexcel;
         objr_resumencuentaanualexcel = new r_resumencuentaanualexcel();
         objr_resumencuentaanualexcel.AV8Ano = aP0_Ano;
         objr_resumencuentaanualexcel.AV12Cuenta1 = aP1_Cuenta1;
         objr_resumencuentaanualexcel.AV13Cuenta2 = aP2_Cuenta2;
         objr_resumencuentaanualexcel.AV25Filename = "" ;
         objr_resumencuentaanualexcel.AV20ErrorMessage = "" ;
         objr_resumencuentaanualexcel.context.SetSubmitInitialConfig(context);
         objr_resumencuentaanualexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumencuentaanualexcel);
         aP0_Ano=this.AV8Ano;
         aP1_Cuenta1=this.AV12Cuenta1;
         aP2_Cuenta2=this.AV13Cuenta2;
         aP3_Filename=this.AV25Filename;
         aP4_ErrorMessage=this.AV20ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumencuentaanualexcel)stateInfo).executePrivate();
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
         AV10Archivo.Source = "Excel/PlantillasResumenCuentas.xlsx";
         AV55Path = AV10Archivo.GetPath();
         AV26FilenameOrigen = StringUtil.Trim( AV55Path) + "\\PlantillasResumenCuentas.xlsx";
         AV25Filename = "Excel/ResumenCuentas" + ".xlsx";
         AV21ExcelDocument.Clear();
         AV21ExcelDocument.Template = AV26FilenameOrigen;
         AV21ExcelDocument.Open(AV25Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11CellRow = 3;
         AV27FirstColumn = 2;
         AV63Titulo = "Resumen Anual de Cuentas";
         AV56Periodo = "Año : " + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0));
         AV11CellRow = 5;
         AV27FirstColumn = 1;
         /* Using cursor P00BK2 */
         pr_default.execute(0, new Object[] {AV12Cuenta1, AV8Ano, AV13Cuenta2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKBK2 = false;
            A133CueCodAux = P00BK2_A133CueCodAux[0];
            A91CueCod = P00BK2_A91CueCod[0];
            A127VouAno = P00BK2_A127VouAno[0];
            A2053VouDDoc = P00BK2_A2053VouDDoc[0];
            A860CueDsc = P00BK2_A860CueDsc[0];
            A128VouMes = P00BK2_A128VouMes[0];
            A126TASICod = P00BK2_A126TASICod[0];
            A129VouNum = P00BK2_A129VouNum[0];
            A130VouDSec = P00BK2_A130VouDSec[0];
            A860CueDsc = P00BK2_A860CueDsc[0];
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BK2_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRKBK2 = false;
               A133CueCodAux = P00BK2_A133CueCodAux[0];
               A127VouAno = P00BK2_A127VouAno[0];
               A128VouMes = P00BK2_A128VouMes[0];
               A126TASICod = P00BK2_A126TASICod[0];
               A129VouNum = P00BK2_A129VouNum[0];
               A130VouDSec = P00BK2_A130VouDSec[0];
               BRKBK2 = true;
               pr_default.readNext(0);
            }
            AV38nCueCod = StringUtil.Trim( A91CueCod);
            AV39nCueDsc = A860CueDsc;
            AV43nEnero = 0.00m;
            AV44nFebrero = 0.00m;
            AV48nMarzo = 0.00m;
            AV36nAbril = 0.00m;
            AV49nMayo = 0.00m;
            AV47nJunio = 0.00m;
            AV46nJulio = 0.00m;
            AV37nAgosto = 0.00m;
            AV53nSep = 0.00m;
            AV51nOct = 0.00m;
            AV50nNov = 0.00m;
            AV41nDic = 0.00m;
            AV54nTotal = 0.00m;
            /* Execute user subroutine: 'MOVIMIENTOMES' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( ! BRKBK2 )
            {
               BRKBK2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV21ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV21ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV21ExcelDocument.ErrCode != 0 )
         {
            AV25Filename = "";
            AV20ErrorMessage = AV21ExcelDocument.ErrDescription;
            AV21ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'MOVIMIENTOMES' Routine */
         returnInSub = false;
         /* Using cursor P00BK3 */
         pr_default.execute(1, new Object[] {AV8Ano, AV38nCueCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A126TASICod = P00BK3_A126TASICod[0];
            A129VouNum = P00BK3_A129VouNum[0];
            A2077VouSts = P00BK3_A2077VouSts[0];
            A128VouMes = P00BK3_A128VouMes[0];
            A91CueCod = P00BK3_A91CueCod[0];
            A127VouAno = P00BK3_A127VouAno[0];
            A2055VouDHab = P00BK3_A2055VouDHab[0];
            A2051VouDDeb = P00BK3_A2051VouDDeb[0];
            A130VouDSec = P00BK3_A130VouDSec[0];
            A2077VouSts = P00BK3_A2077VouSts[0];
            AV43nEnero = (decimal)(AV43nEnero+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00BK4 */
         pr_default.execute(2, new Object[] {AV8Ano, AV38nCueCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00BK4_A126TASICod[0];
            A129VouNum = P00BK4_A129VouNum[0];
            A2077VouSts = P00BK4_A2077VouSts[0];
            A128VouMes = P00BK4_A128VouMes[0];
            A91CueCod = P00BK4_A91CueCod[0];
            A127VouAno = P00BK4_A127VouAno[0];
            A2055VouDHab = P00BK4_A2055VouDHab[0];
            A2051VouDDeb = P00BK4_A2051VouDDeb[0];
            A130VouDSec = P00BK4_A130VouDSec[0];
            A2077VouSts = P00BK4_A2077VouSts[0];
            AV44nFebrero = (decimal)(AV44nFebrero+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor P00BK5 */
         pr_default.execute(3, new Object[] {AV8Ano, AV38nCueCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A126TASICod = P00BK5_A126TASICod[0];
            A129VouNum = P00BK5_A129VouNum[0];
            A2077VouSts = P00BK5_A2077VouSts[0];
            A128VouMes = P00BK5_A128VouMes[0];
            A91CueCod = P00BK5_A91CueCod[0];
            A127VouAno = P00BK5_A127VouAno[0];
            A2055VouDHab = P00BK5_A2055VouDHab[0];
            A2051VouDDeb = P00BK5_A2051VouDDeb[0];
            A130VouDSec = P00BK5_A130VouDSec[0];
            A2077VouSts = P00BK5_A2077VouSts[0];
            AV48nMarzo = (decimal)(AV48nMarzo+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Using cursor P00BK6 */
         pr_default.execute(4, new Object[] {AV8Ano, AV38nCueCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A126TASICod = P00BK6_A126TASICod[0];
            A129VouNum = P00BK6_A129VouNum[0];
            A2077VouSts = P00BK6_A2077VouSts[0];
            A128VouMes = P00BK6_A128VouMes[0];
            A91CueCod = P00BK6_A91CueCod[0];
            A127VouAno = P00BK6_A127VouAno[0];
            A2055VouDHab = P00BK6_A2055VouDHab[0];
            A2051VouDDeb = P00BK6_A2051VouDDeb[0];
            A130VouDSec = P00BK6_A130VouDSec[0];
            A2077VouSts = P00BK6_A2077VouSts[0];
            AV36nAbril = (decimal)(AV36nAbril+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /* Using cursor P00BK7 */
         pr_default.execute(5, new Object[] {AV8Ano, AV38nCueCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A126TASICod = P00BK7_A126TASICod[0];
            A129VouNum = P00BK7_A129VouNum[0];
            A2077VouSts = P00BK7_A2077VouSts[0];
            A128VouMes = P00BK7_A128VouMes[0];
            A91CueCod = P00BK7_A91CueCod[0];
            A127VouAno = P00BK7_A127VouAno[0];
            A2055VouDHab = P00BK7_A2055VouDHab[0];
            A2051VouDDeb = P00BK7_A2051VouDDeb[0];
            A130VouDSec = P00BK7_A130VouDSec[0];
            A2077VouSts = P00BK7_A2077VouSts[0];
            AV49nMayo = (decimal)(AV49nMayo+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /* Using cursor P00BK8 */
         pr_default.execute(6, new Object[] {AV8Ano, AV38nCueCod});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A126TASICod = P00BK8_A126TASICod[0];
            A129VouNum = P00BK8_A129VouNum[0];
            A2077VouSts = P00BK8_A2077VouSts[0];
            A128VouMes = P00BK8_A128VouMes[0];
            A91CueCod = P00BK8_A91CueCod[0];
            A127VouAno = P00BK8_A127VouAno[0];
            A2055VouDHab = P00BK8_A2055VouDHab[0];
            A2051VouDDeb = P00BK8_A2051VouDDeb[0];
            A130VouDSec = P00BK8_A130VouDSec[0];
            A2077VouSts = P00BK8_A2077VouSts[0];
            AV47nJunio = (decimal)(AV47nJunio+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(6);
         }
         pr_default.close(6);
         /* Using cursor P00BK9 */
         pr_default.execute(7, new Object[] {AV8Ano, AV38nCueCod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A126TASICod = P00BK9_A126TASICod[0];
            A129VouNum = P00BK9_A129VouNum[0];
            A2077VouSts = P00BK9_A2077VouSts[0];
            A128VouMes = P00BK9_A128VouMes[0];
            A91CueCod = P00BK9_A91CueCod[0];
            A127VouAno = P00BK9_A127VouAno[0];
            A2055VouDHab = P00BK9_A2055VouDHab[0];
            A2051VouDDeb = P00BK9_A2051VouDDeb[0];
            A130VouDSec = P00BK9_A130VouDSec[0];
            A2077VouSts = P00BK9_A2077VouSts[0];
            AV46nJulio = (decimal)(AV46nJulio+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(7);
         }
         pr_default.close(7);
         /* Using cursor P00BK10 */
         pr_default.execute(8, new Object[] {AV8Ano, AV38nCueCod});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A126TASICod = P00BK10_A126TASICod[0];
            A129VouNum = P00BK10_A129VouNum[0];
            A2077VouSts = P00BK10_A2077VouSts[0];
            A128VouMes = P00BK10_A128VouMes[0];
            A91CueCod = P00BK10_A91CueCod[0];
            A127VouAno = P00BK10_A127VouAno[0];
            A2055VouDHab = P00BK10_A2055VouDHab[0];
            A2051VouDDeb = P00BK10_A2051VouDDeb[0];
            A130VouDSec = P00BK10_A130VouDSec[0];
            A2077VouSts = P00BK10_A2077VouSts[0];
            AV37nAgosto = (decimal)(AV37nAgosto+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(8);
         }
         pr_default.close(8);
         /* Using cursor P00BK11 */
         pr_default.execute(9, new Object[] {AV8Ano, AV38nCueCod});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A126TASICod = P00BK11_A126TASICod[0];
            A129VouNum = P00BK11_A129VouNum[0];
            A2077VouSts = P00BK11_A2077VouSts[0];
            A128VouMes = P00BK11_A128VouMes[0];
            A91CueCod = P00BK11_A91CueCod[0];
            A127VouAno = P00BK11_A127VouAno[0];
            A2055VouDHab = P00BK11_A2055VouDHab[0];
            A2051VouDDeb = P00BK11_A2051VouDDeb[0];
            A130VouDSec = P00BK11_A130VouDSec[0];
            A2077VouSts = P00BK11_A2077VouSts[0];
            AV53nSep = (decimal)(AV53nSep+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(9);
         }
         pr_default.close(9);
         /* Using cursor P00BK12 */
         pr_default.execute(10, new Object[] {AV8Ano, AV38nCueCod});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A126TASICod = P00BK12_A126TASICod[0];
            A129VouNum = P00BK12_A129VouNum[0];
            A2077VouSts = P00BK12_A2077VouSts[0];
            A128VouMes = P00BK12_A128VouMes[0];
            A91CueCod = P00BK12_A91CueCod[0];
            A127VouAno = P00BK12_A127VouAno[0];
            A2055VouDHab = P00BK12_A2055VouDHab[0];
            A2051VouDDeb = P00BK12_A2051VouDDeb[0];
            A130VouDSec = P00BK12_A130VouDSec[0];
            A2077VouSts = P00BK12_A2077VouSts[0];
            AV51nOct = (decimal)(AV51nOct+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(10);
         }
         pr_default.close(10);
         /* Using cursor P00BK13 */
         pr_default.execute(11, new Object[] {AV8Ano, AV38nCueCod});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A126TASICod = P00BK13_A126TASICod[0];
            A129VouNum = P00BK13_A129VouNum[0];
            A2077VouSts = P00BK13_A2077VouSts[0];
            A128VouMes = P00BK13_A128VouMes[0];
            A91CueCod = P00BK13_A91CueCod[0];
            A127VouAno = P00BK13_A127VouAno[0];
            A2055VouDHab = P00BK13_A2055VouDHab[0];
            A2051VouDDeb = P00BK13_A2051VouDDeb[0];
            A130VouDSec = P00BK13_A130VouDSec[0];
            A2077VouSts = P00BK13_A2077VouSts[0];
            AV50nNov = (decimal)(AV50nNov+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(11);
         }
         pr_default.close(11);
         /* Using cursor P00BK14 */
         pr_default.execute(12, new Object[] {AV8Ano, AV38nCueCod});
         while ( (pr_default.getStatus(12) != 101) )
         {
            A126TASICod = P00BK14_A126TASICod[0];
            A129VouNum = P00BK14_A129VouNum[0];
            A2077VouSts = P00BK14_A2077VouSts[0];
            A128VouMes = P00BK14_A128VouMes[0];
            A91CueCod = P00BK14_A91CueCod[0];
            A127VouAno = P00BK14_A127VouAno[0];
            A2055VouDHab = P00BK14_A2055VouDHab[0];
            A2051VouDDeb = P00BK14_A2051VouDDeb[0];
            A130VouDSec = P00BK14_A130VouDSec[0];
            A2077VouSts = P00BK14_A2077VouSts[0];
            AV41nDic = (decimal)(AV41nDic+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(12);
         }
         pr_default.close(12);
         AV54nTotal = (decimal)(AV43nEnero+AV44nFebrero+AV48nMarzo+AV36nAbril+AV49nMayo+AV47nJunio+AV46nJulio+AV37nAgosto+AV53nSep+AV51nOct+AV50nNov+AV41nDic);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV38nCueCod);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV39nCueDsc);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+2, 1, 1).Number = (double)(AV43nEnero);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+3, 1, 1).Number = (double)(AV44nFebrero);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+4, 1, 1).Number = (double)(AV48nMarzo);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+5, 1, 1).Number = (double)(AV36nAbril);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+6, 1, 1).Number = (double)(AV49nMayo);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+7, 1, 1).Number = (double)(AV47nJunio);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+8, 1, 1).Number = (double)(AV46nJulio);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+9, 1, 1).Number = (double)(AV37nAgosto);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+10, 1, 1).Number = (double)(AV53nSep);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+11, 1, 1).Number = (double)(AV51nOct);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+12, 1, 1).Number = (double)(AV50nNov);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+13, 1, 1).Number = (double)(AV41nDic);
         AV21ExcelDocument.get_Cells(AV11CellRow, AV27FirstColumn+14, 1, 1).Number = (double)(AV54nTotal);
         AV11CellRow = (int)(AV11CellRow+1);
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
         AV25Filename = "";
         AV20ErrorMessage = "";
         AV10Archivo = new GxFile(context.GetPhysicalPath());
         AV55Path = "";
         AV26FilenameOrigen = "";
         AV21ExcelDocument = new ExcelDocumentI();
         AV63Titulo = "";
         AV56Periodo = "";
         scmdbuf = "";
         P00BK2_A133CueCodAux = new string[] {""} ;
         P00BK2_A91CueCod = new string[] {""} ;
         P00BK2_A127VouAno = new short[1] ;
         P00BK2_A2053VouDDoc = new string[] {""} ;
         P00BK2_A860CueDsc = new string[] {""} ;
         P00BK2_A128VouMes = new short[1] ;
         P00BK2_A126TASICod = new int[1] ;
         P00BK2_A129VouNum = new string[] {""} ;
         P00BK2_A130VouDSec = new int[1] ;
         A133CueCodAux = "";
         A91CueCod = "";
         A2053VouDDoc = "";
         A860CueDsc = "";
         A129VouNum = "";
         AV38nCueCod = "";
         AV39nCueDsc = "";
         P00BK3_A126TASICod = new int[1] ;
         P00BK3_A129VouNum = new string[] {""} ;
         P00BK3_A2077VouSts = new short[1] ;
         P00BK3_A128VouMes = new short[1] ;
         P00BK3_A91CueCod = new string[] {""} ;
         P00BK3_A127VouAno = new short[1] ;
         P00BK3_A2055VouDHab = new decimal[1] ;
         P00BK3_A2051VouDDeb = new decimal[1] ;
         P00BK3_A130VouDSec = new int[1] ;
         P00BK4_A126TASICod = new int[1] ;
         P00BK4_A129VouNum = new string[] {""} ;
         P00BK4_A2077VouSts = new short[1] ;
         P00BK4_A128VouMes = new short[1] ;
         P00BK4_A91CueCod = new string[] {""} ;
         P00BK4_A127VouAno = new short[1] ;
         P00BK4_A2055VouDHab = new decimal[1] ;
         P00BK4_A2051VouDDeb = new decimal[1] ;
         P00BK4_A130VouDSec = new int[1] ;
         P00BK5_A126TASICod = new int[1] ;
         P00BK5_A129VouNum = new string[] {""} ;
         P00BK5_A2077VouSts = new short[1] ;
         P00BK5_A128VouMes = new short[1] ;
         P00BK5_A91CueCod = new string[] {""} ;
         P00BK5_A127VouAno = new short[1] ;
         P00BK5_A2055VouDHab = new decimal[1] ;
         P00BK5_A2051VouDDeb = new decimal[1] ;
         P00BK5_A130VouDSec = new int[1] ;
         P00BK6_A126TASICod = new int[1] ;
         P00BK6_A129VouNum = new string[] {""} ;
         P00BK6_A2077VouSts = new short[1] ;
         P00BK6_A128VouMes = new short[1] ;
         P00BK6_A91CueCod = new string[] {""} ;
         P00BK6_A127VouAno = new short[1] ;
         P00BK6_A2055VouDHab = new decimal[1] ;
         P00BK6_A2051VouDDeb = new decimal[1] ;
         P00BK6_A130VouDSec = new int[1] ;
         P00BK7_A126TASICod = new int[1] ;
         P00BK7_A129VouNum = new string[] {""} ;
         P00BK7_A2077VouSts = new short[1] ;
         P00BK7_A128VouMes = new short[1] ;
         P00BK7_A91CueCod = new string[] {""} ;
         P00BK7_A127VouAno = new short[1] ;
         P00BK7_A2055VouDHab = new decimal[1] ;
         P00BK7_A2051VouDDeb = new decimal[1] ;
         P00BK7_A130VouDSec = new int[1] ;
         P00BK8_A126TASICod = new int[1] ;
         P00BK8_A129VouNum = new string[] {""} ;
         P00BK8_A2077VouSts = new short[1] ;
         P00BK8_A128VouMes = new short[1] ;
         P00BK8_A91CueCod = new string[] {""} ;
         P00BK8_A127VouAno = new short[1] ;
         P00BK8_A2055VouDHab = new decimal[1] ;
         P00BK8_A2051VouDDeb = new decimal[1] ;
         P00BK8_A130VouDSec = new int[1] ;
         P00BK9_A126TASICod = new int[1] ;
         P00BK9_A129VouNum = new string[] {""} ;
         P00BK9_A2077VouSts = new short[1] ;
         P00BK9_A128VouMes = new short[1] ;
         P00BK9_A91CueCod = new string[] {""} ;
         P00BK9_A127VouAno = new short[1] ;
         P00BK9_A2055VouDHab = new decimal[1] ;
         P00BK9_A2051VouDDeb = new decimal[1] ;
         P00BK9_A130VouDSec = new int[1] ;
         P00BK10_A126TASICod = new int[1] ;
         P00BK10_A129VouNum = new string[] {""} ;
         P00BK10_A2077VouSts = new short[1] ;
         P00BK10_A128VouMes = new short[1] ;
         P00BK10_A91CueCod = new string[] {""} ;
         P00BK10_A127VouAno = new short[1] ;
         P00BK10_A2055VouDHab = new decimal[1] ;
         P00BK10_A2051VouDDeb = new decimal[1] ;
         P00BK10_A130VouDSec = new int[1] ;
         P00BK11_A126TASICod = new int[1] ;
         P00BK11_A129VouNum = new string[] {""} ;
         P00BK11_A2077VouSts = new short[1] ;
         P00BK11_A128VouMes = new short[1] ;
         P00BK11_A91CueCod = new string[] {""} ;
         P00BK11_A127VouAno = new short[1] ;
         P00BK11_A2055VouDHab = new decimal[1] ;
         P00BK11_A2051VouDDeb = new decimal[1] ;
         P00BK11_A130VouDSec = new int[1] ;
         P00BK12_A126TASICod = new int[1] ;
         P00BK12_A129VouNum = new string[] {""} ;
         P00BK12_A2077VouSts = new short[1] ;
         P00BK12_A128VouMes = new short[1] ;
         P00BK12_A91CueCod = new string[] {""} ;
         P00BK12_A127VouAno = new short[1] ;
         P00BK12_A2055VouDHab = new decimal[1] ;
         P00BK12_A2051VouDDeb = new decimal[1] ;
         P00BK12_A130VouDSec = new int[1] ;
         P00BK13_A126TASICod = new int[1] ;
         P00BK13_A129VouNum = new string[] {""} ;
         P00BK13_A2077VouSts = new short[1] ;
         P00BK13_A128VouMes = new short[1] ;
         P00BK13_A91CueCod = new string[] {""} ;
         P00BK13_A127VouAno = new short[1] ;
         P00BK13_A2055VouDHab = new decimal[1] ;
         P00BK13_A2051VouDDeb = new decimal[1] ;
         P00BK13_A130VouDSec = new int[1] ;
         P00BK14_A126TASICod = new int[1] ;
         P00BK14_A129VouNum = new string[] {""} ;
         P00BK14_A2077VouSts = new short[1] ;
         P00BK14_A128VouMes = new short[1] ;
         P00BK14_A91CueCod = new string[] {""} ;
         P00BK14_A127VouAno = new short[1] ;
         P00BK14_A2055VouDHab = new decimal[1] ;
         P00BK14_A2051VouDDeb = new decimal[1] ;
         P00BK14_A130VouDSec = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_resumencuentaanualexcel__default(),
            new Object[][] {
                new Object[] {
               P00BK2_A133CueCodAux, P00BK2_A91CueCod, P00BK2_A127VouAno, P00BK2_A2053VouDDoc, P00BK2_A860CueDsc, P00BK2_A128VouMes, P00BK2_A126TASICod, P00BK2_A129VouNum, P00BK2_A130VouDSec
               }
               , new Object[] {
               P00BK3_A126TASICod, P00BK3_A129VouNum, P00BK3_A2077VouSts, P00BK3_A128VouMes, P00BK3_A91CueCod, P00BK3_A127VouAno, P00BK3_A2055VouDHab, P00BK3_A2051VouDDeb, P00BK3_A130VouDSec
               }
               , new Object[] {
               P00BK4_A126TASICod, P00BK4_A129VouNum, P00BK4_A2077VouSts, P00BK4_A128VouMes, P00BK4_A91CueCod, P00BK4_A127VouAno, P00BK4_A2055VouDHab, P00BK4_A2051VouDDeb, P00BK4_A130VouDSec
               }
               , new Object[] {
               P00BK5_A126TASICod, P00BK5_A129VouNum, P00BK5_A2077VouSts, P00BK5_A128VouMes, P00BK5_A91CueCod, P00BK5_A127VouAno, P00BK5_A2055VouDHab, P00BK5_A2051VouDDeb, P00BK5_A130VouDSec
               }
               , new Object[] {
               P00BK6_A126TASICod, P00BK6_A129VouNum, P00BK6_A2077VouSts, P00BK6_A128VouMes, P00BK6_A91CueCod, P00BK6_A127VouAno, P00BK6_A2055VouDHab, P00BK6_A2051VouDDeb, P00BK6_A130VouDSec
               }
               , new Object[] {
               P00BK7_A126TASICod, P00BK7_A129VouNum, P00BK7_A2077VouSts, P00BK7_A128VouMes, P00BK7_A91CueCod, P00BK7_A127VouAno, P00BK7_A2055VouDHab, P00BK7_A2051VouDDeb, P00BK7_A130VouDSec
               }
               , new Object[] {
               P00BK8_A126TASICod, P00BK8_A129VouNum, P00BK8_A2077VouSts, P00BK8_A128VouMes, P00BK8_A91CueCod, P00BK8_A127VouAno, P00BK8_A2055VouDHab, P00BK8_A2051VouDDeb, P00BK8_A130VouDSec
               }
               , new Object[] {
               P00BK9_A126TASICod, P00BK9_A129VouNum, P00BK9_A2077VouSts, P00BK9_A128VouMes, P00BK9_A91CueCod, P00BK9_A127VouAno, P00BK9_A2055VouDHab, P00BK9_A2051VouDDeb, P00BK9_A130VouDSec
               }
               , new Object[] {
               P00BK10_A126TASICod, P00BK10_A129VouNum, P00BK10_A2077VouSts, P00BK10_A128VouMes, P00BK10_A91CueCod, P00BK10_A127VouAno, P00BK10_A2055VouDHab, P00BK10_A2051VouDDeb, P00BK10_A130VouDSec
               }
               , new Object[] {
               P00BK11_A126TASICod, P00BK11_A129VouNum, P00BK11_A2077VouSts, P00BK11_A128VouMes, P00BK11_A91CueCod, P00BK11_A127VouAno, P00BK11_A2055VouDHab, P00BK11_A2051VouDDeb, P00BK11_A130VouDSec
               }
               , new Object[] {
               P00BK12_A126TASICod, P00BK12_A129VouNum, P00BK12_A2077VouSts, P00BK12_A128VouMes, P00BK12_A91CueCod, P00BK12_A127VouAno, P00BK12_A2055VouDHab, P00BK12_A2051VouDDeb, P00BK12_A130VouDSec
               }
               , new Object[] {
               P00BK13_A126TASICod, P00BK13_A129VouNum, P00BK13_A2077VouSts, P00BK13_A128VouMes, P00BK13_A91CueCod, P00BK13_A127VouAno, P00BK13_A2055VouDHab, P00BK13_A2051VouDDeb, P00BK13_A130VouDSec
               }
               , new Object[] {
               P00BK14_A126TASICod, P00BK14_A129VouNum, P00BK14_A2077VouSts, P00BK14_A128VouMes, P00BK14_A91CueCod, P00BK14_A127VouAno, P00BK14_A2055VouDHab, P00BK14_A2051VouDDeb, P00BK14_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8Ano ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short A2077VouSts ;
      private int AV11CellRow ;
      private int AV27FirstColumn ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private decimal AV43nEnero ;
      private decimal AV44nFebrero ;
      private decimal AV48nMarzo ;
      private decimal AV36nAbril ;
      private decimal AV49nMayo ;
      private decimal AV47nJunio ;
      private decimal AV46nJulio ;
      private decimal AV37nAgosto ;
      private decimal AV53nSep ;
      private decimal AV51nOct ;
      private decimal AV50nNov ;
      private decimal AV41nDic ;
      private decimal AV54nTotal ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private string AV12Cuenta1 ;
      private string AV13Cuenta2 ;
      private string AV55Path ;
      private string AV63Titulo ;
      private string AV56Periodo ;
      private string scmdbuf ;
      private string A133CueCodAux ;
      private string A91CueCod ;
      private string A2053VouDDoc ;
      private string A860CueDsc ;
      private string A129VouNum ;
      private string AV38nCueCod ;
      private string AV39nCueDsc ;
      private bool returnInSub ;
      private bool BRKBK2 ;
      private string AV25Filename ;
      private string AV20ErrorMessage ;
      private string AV26FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private string aP1_Cuenta1 ;
      private string aP2_Cuenta2 ;
      private IDataStoreProvider pr_default ;
      private string[] P00BK2_A133CueCodAux ;
      private string[] P00BK2_A91CueCod ;
      private short[] P00BK2_A127VouAno ;
      private string[] P00BK2_A2053VouDDoc ;
      private string[] P00BK2_A860CueDsc ;
      private short[] P00BK2_A128VouMes ;
      private int[] P00BK2_A126TASICod ;
      private string[] P00BK2_A129VouNum ;
      private int[] P00BK2_A130VouDSec ;
      private int[] P00BK3_A126TASICod ;
      private string[] P00BK3_A129VouNum ;
      private short[] P00BK3_A2077VouSts ;
      private short[] P00BK3_A128VouMes ;
      private string[] P00BK3_A91CueCod ;
      private short[] P00BK3_A127VouAno ;
      private decimal[] P00BK3_A2055VouDHab ;
      private decimal[] P00BK3_A2051VouDDeb ;
      private int[] P00BK3_A130VouDSec ;
      private int[] P00BK4_A126TASICod ;
      private string[] P00BK4_A129VouNum ;
      private short[] P00BK4_A2077VouSts ;
      private short[] P00BK4_A128VouMes ;
      private string[] P00BK4_A91CueCod ;
      private short[] P00BK4_A127VouAno ;
      private decimal[] P00BK4_A2055VouDHab ;
      private decimal[] P00BK4_A2051VouDDeb ;
      private int[] P00BK4_A130VouDSec ;
      private int[] P00BK5_A126TASICod ;
      private string[] P00BK5_A129VouNum ;
      private short[] P00BK5_A2077VouSts ;
      private short[] P00BK5_A128VouMes ;
      private string[] P00BK5_A91CueCod ;
      private short[] P00BK5_A127VouAno ;
      private decimal[] P00BK5_A2055VouDHab ;
      private decimal[] P00BK5_A2051VouDDeb ;
      private int[] P00BK5_A130VouDSec ;
      private int[] P00BK6_A126TASICod ;
      private string[] P00BK6_A129VouNum ;
      private short[] P00BK6_A2077VouSts ;
      private short[] P00BK6_A128VouMes ;
      private string[] P00BK6_A91CueCod ;
      private short[] P00BK6_A127VouAno ;
      private decimal[] P00BK6_A2055VouDHab ;
      private decimal[] P00BK6_A2051VouDDeb ;
      private int[] P00BK6_A130VouDSec ;
      private int[] P00BK7_A126TASICod ;
      private string[] P00BK7_A129VouNum ;
      private short[] P00BK7_A2077VouSts ;
      private short[] P00BK7_A128VouMes ;
      private string[] P00BK7_A91CueCod ;
      private short[] P00BK7_A127VouAno ;
      private decimal[] P00BK7_A2055VouDHab ;
      private decimal[] P00BK7_A2051VouDDeb ;
      private int[] P00BK7_A130VouDSec ;
      private int[] P00BK8_A126TASICod ;
      private string[] P00BK8_A129VouNum ;
      private short[] P00BK8_A2077VouSts ;
      private short[] P00BK8_A128VouMes ;
      private string[] P00BK8_A91CueCod ;
      private short[] P00BK8_A127VouAno ;
      private decimal[] P00BK8_A2055VouDHab ;
      private decimal[] P00BK8_A2051VouDDeb ;
      private int[] P00BK8_A130VouDSec ;
      private int[] P00BK9_A126TASICod ;
      private string[] P00BK9_A129VouNum ;
      private short[] P00BK9_A2077VouSts ;
      private short[] P00BK9_A128VouMes ;
      private string[] P00BK9_A91CueCod ;
      private short[] P00BK9_A127VouAno ;
      private decimal[] P00BK9_A2055VouDHab ;
      private decimal[] P00BK9_A2051VouDDeb ;
      private int[] P00BK9_A130VouDSec ;
      private int[] P00BK10_A126TASICod ;
      private string[] P00BK10_A129VouNum ;
      private short[] P00BK10_A2077VouSts ;
      private short[] P00BK10_A128VouMes ;
      private string[] P00BK10_A91CueCod ;
      private short[] P00BK10_A127VouAno ;
      private decimal[] P00BK10_A2055VouDHab ;
      private decimal[] P00BK10_A2051VouDDeb ;
      private int[] P00BK10_A130VouDSec ;
      private int[] P00BK11_A126TASICod ;
      private string[] P00BK11_A129VouNum ;
      private short[] P00BK11_A2077VouSts ;
      private short[] P00BK11_A128VouMes ;
      private string[] P00BK11_A91CueCod ;
      private short[] P00BK11_A127VouAno ;
      private decimal[] P00BK11_A2055VouDHab ;
      private decimal[] P00BK11_A2051VouDDeb ;
      private int[] P00BK11_A130VouDSec ;
      private int[] P00BK12_A126TASICod ;
      private string[] P00BK12_A129VouNum ;
      private short[] P00BK12_A2077VouSts ;
      private short[] P00BK12_A128VouMes ;
      private string[] P00BK12_A91CueCod ;
      private short[] P00BK12_A127VouAno ;
      private decimal[] P00BK12_A2055VouDHab ;
      private decimal[] P00BK12_A2051VouDDeb ;
      private int[] P00BK12_A130VouDSec ;
      private int[] P00BK13_A126TASICod ;
      private string[] P00BK13_A129VouNum ;
      private short[] P00BK13_A2077VouSts ;
      private short[] P00BK13_A128VouMes ;
      private string[] P00BK13_A91CueCod ;
      private short[] P00BK13_A127VouAno ;
      private decimal[] P00BK13_A2055VouDHab ;
      private decimal[] P00BK13_A2051VouDDeb ;
      private int[] P00BK13_A130VouDSec ;
      private int[] P00BK14_A126TASICod ;
      private string[] P00BK14_A129VouNum ;
      private short[] P00BK14_A2077VouSts ;
      private short[] P00BK14_A128VouMes ;
      private string[] P00BK14_A91CueCod ;
      private short[] P00BK14_A127VouAno ;
      private decimal[] P00BK14_A2055VouDHab ;
      private decimal[] P00BK14_A2051VouDDeb ;
      private int[] P00BK14_A130VouDSec ;
      private string aP3_Filename ;
      private string aP4_ErrorMessage ;
      private ExcelDocumentI AV21ExcelDocument ;
      private GxFile AV10Archivo ;
   }

   public class r_resumencuentaanualexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
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
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BK2;
          prmP00BK2 = new Object[] {
          new ParDef("@AV12Cuenta1",GXType.Char,15,0) ,
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV13Cuenta2",GXType.Char,15,0)
          };
          Object[] prmP00BK3;
          prmP00BK3 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV38nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BK4;
          prmP00BK4 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV38nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BK5;
          prmP00BK5 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV38nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BK6;
          prmP00BK6 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV38nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BK7;
          prmP00BK7 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV38nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BK8;
          prmP00BK8 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV38nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BK9;
          prmP00BK9 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV38nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BK10;
          prmP00BK10 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV38nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BK11;
          prmP00BK11 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV38nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BK12;
          prmP00BK12 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV38nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BK13;
          prmP00BK13 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV38nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BK14;
          prmP00BK14 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV38nCueCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BK2", "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouAno], T1.[VouDDoc], T2.[CueDsc], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE (T1.[CueCod] >= @AV12Cuenta1) AND (T1.[VouAno] = @AV8Ano) AND (T1.[CueCod] <= @AV13Cuenta2) ORDER BY T1.[CueCod], T1.[CueCodAux] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BK3", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 1 and T1.[CueCod] = @AV38nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BK4", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 2 and T1.[CueCod] = @AV38nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BK5", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 3 and T1.[CueCod] = @AV38nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BK6", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 4 and T1.[CueCod] = @AV38nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BK7", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 5 and T1.[CueCod] = @AV38nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BK8", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 6 and T1.[CueCod] = @AV38nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BK9", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 7 and T1.[CueCod] = @AV38nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BK10", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 8 and T1.[CueCod] = @AV38nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK10,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BK11", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 9 and T1.[CueCod] = @AV38nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BK12", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 10 and T1.[CueCod] = @AV38nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK12,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BK13", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 11 and T1.[CueCod] = @AV38nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK13,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BK14", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 12 and T1.[CueCod] = @AV38nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK14,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 10);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
