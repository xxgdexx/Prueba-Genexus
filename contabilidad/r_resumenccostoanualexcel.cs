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
   public class r_resumenccostoanualexcel : GXProcedure
   {
      public r_resumenccostoanualexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenccostoanualexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_VouAno ,
                           ref string aP1_CueCod1 ,
                           ref string aP2_CueCod2 ,
                           ref string aP3_nCosCod ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV63VouAno = aP0_VouAno;
         this.AV64CueCod1 = aP1_CueCod1;
         this.AV65CueCod2 = aP2_CueCod2;
         this.AV66nCosCod = aP3_nCosCod;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_VouAno=this.AV63VouAno;
         aP1_CueCod1=this.AV64CueCod1;
         aP2_CueCod2=this.AV65CueCod2;
         aP3_nCosCod=this.AV66nCosCod;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref short aP0_VouAno ,
                                ref string aP1_CueCod1 ,
                                ref string aP2_CueCod2 ,
                                ref string aP3_nCosCod ,
                                out string aP4_Filename )
      {
         execute(ref aP0_VouAno, ref aP1_CueCod1, ref aP2_CueCod2, ref aP3_nCosCod, out aP4_Filename, out aP5_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_VouAno ,
                                 ref string aP1_CueCod1 ,
                                 ref string aP2_CueCod2 ,
                                 ref string aP3_nCosCod ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         r_resumenccostoanualexcel objr_resumenccostoanualexcel;
         objr_resumenccostoanualexcel = new r_resumenccostoanualexcel();
         objr_resumenccostoanualexcel.AV63VouAno = aP0_VouAno;
         objr_resumenccostoanualexcel.AV64CueCod1 = aP1_CueCod1;
         objr_resumenccostoanualexcel.AV65CueCod2 = aP2_CueCod2;
         objr_resumenccostoanualexcel.AV66nCosCod = aP3_nCosCod;
         objr_resumenccostoanualexcel.AV10Filename = "" ;
         objr_resumenccostoanualexcel.AV11ErrorMessage = "" ;
         objr_resumenccostoanualexcel.context.SetSubmitInitialConfig(context);
         objr_resumenccostoanualexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenccostoanualexcel);
         aP0_VouAno=this.AV63VouAno;
         aP1_CueCod1=this.AV64CueCod1;
         aP2_CueCod2=this.AV65CueCod2;
         aP3_nCosCod=this.AV66nCosCod;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenccostoanualexcel)stateInfo).executePrivate();
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
         AV37Archivo.Source = "Excel/PlantillasResumenCuentas.xlsx";
         AV38Path = AV37Archivo.GetPath();
         AV41FilenameOrigen = StringUtil.Trim( AV38Path) + "\\PlantillasResumenCuentas.xlsx";
         AV10Filename = "Excel/ResumenCuentas" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV41FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 3;
         AV15FirstColumn = 2;
         AV44Titulo = "Resumen Anual por Centros de Costos";
         AV39Periodo = "Año : " + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0));
         AV13ExcelDocument.get_Cells(2, 3, 1, 1).Text = StringUtil.Trim( AV44Titulo);
         AV14CellRow = 5;
         AV15FirstColumn = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV66nCosCod ,
                                              AV64CueCod1 ,
                                              AV65CueCod2 ,
                                              A79COSCod ,
                                              A91CueCod ,
                                              A127VouAno ,
                                              AV63VouAno } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BM2 */
         pr_default.execute(0, new Object[] {AV63VouAno, AV66nCosCod, AV64CueCod1, AV65CueCod2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKBM2 = false;
            A79COSCod = P00BM2_A79COSCod[0];
            n79COSCod = P00BM2_n79COSCod[0];
            A127VouAno = P00BM2_A127VouAno[0];
            A91CueCod = P00BM2_A91CueCod[0];
            A135VouDFec = P00BM2_A135VouDFec[0];
            A761COSDsc = P00BM2_A761COSDsc[0];
            A128VouMes = P00BM2_A128VouMes[0];
            A126TASICod = P00BM2_A126TASICod[0];
            A129VouNum = P00BM2_A129VouNum[0];
            A130VouDSec = P00BM2_A130VouDSec[0];
            A761COSDsc = P00BM2_A761COSDsc[0];
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BM2_A79COSCod[0], A79COSCod) == 0 ) )
            {
               BRKBM2 = false;
               A127VouAno = P00BM2_A127VouAno[0];
               A128VouMes = P00BM2_A128VouMes[0];
               A126TASICod = P00BM2_A126TASICod[0];
               A129VouNum = P00BM2_A129VouNum[0];
               A130VouDSec = P00BM2_A130VouDSec[0];
               BRKBM2 = true;
               pr_default.readNext(0);
            }
            AV62CosCod = A79COSCod;
            AV67COSDsc = A761COSDsc;
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV62CosCod);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV67COSDsc);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Number = (double)(0.00m);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(0.00m);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Number = (double)(0.00m);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(0.00m);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(0.00m);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(0.00m);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(0.00m);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(0.00m);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(0.00m);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Number = (double)(0.00m);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+12, 1, 1).Number = (double)(0.00m);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+13, 1, 1).Number = (double)(0.00m);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+14, 1, 1).Number = (double)(0.00m);
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'SALDOCUENTACENTROCOSTO' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV14CellRow = (int)(AV14CellRow+1);
            if ( ! BRKBM2 )
            {
               BRKBM2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV13ExcelDocument.ErrCode != 0 )
         {
            AV10Filename = "";
            AV11ErrorMessage = AV13ExcelDocument.ErrDescription;
            AV13ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'SALDOCUENTACENTROCOSTO' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV64CueCod1 ,
                                              AV65CueCod2 ,
                                              A91CueCod ,
                                              A79COSCod ,
                                              AV62CosCod ,
                                              A859CueCos ,
                                              A127VouAno ,
                                              AV63VouAno } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BM3 */
         pr_default.execute(1, new Object[] {AV62CosCod, AV63VouAno, AV64CueCod1, AV65CueCod2});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKBM4 = false;
            A133CueCodAux = P00BM3_A133CueCodAux[0];
            A91CueCod = P00BM3_A91CueCod[0];
            A127VouAno = P00BM3_A127VouAno[0];
            A859CueCos = P00BM3_A859CueCos[0];
            A79COSCod = P00BM3_A79COSCod[0];
            n79COSCod = P00BM3_n79COSCod[0];
            A860CueDsc = P00BM3_A860CueDsc[0];
            A128VouMes = P00BM3_A128VouMes[0];
            A126TASICod = P00BM3_A126TASICod[0];
            A129VouNum = P00BM3_A129VouNum[0];
            A130VouDSec = P00BM3_A130VouDSec[0];
            A859CueCos = P00BM3_A859CueCos[0];
            A860CueDsc = P00BM3_A860CueDsc[0];
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00BM3_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRKBM4 = false;
               A133CueCodAux = P00BM3_A133CueCodAux[0];
               A127VouAno = P00BM3_A127VouAno[0];
               A128VouMes = P00BM3_A128VouMes[0];
               A126TASICod = P00BM3_A126TASICod[0];
               A129VouNum = P00BM3_A129VouNum[0];
               A130VouDSec = P00BM3_A130VouDSec[0];
               BRKBM4 = true;
               pr_default.readNext(1);
            }
            AV60CueCod = A91CueCod;
            AV61Cuenta = StringUtil.Trim( A860CueDsc);
            AV9Mes = 1;
            /* Execute user subroutine: 'SALDOMES' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV45nEnero = AV72Total;
            AV9Mes = 2;
            /* Execute user subroutine: 'SALDOMES' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV48nFebrero = AV72Total;
            AV9Mes = 3;
            /* Execute user subroutine: 'SALDOMES' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV49nMarzo = AV72Total;
            AV9Mes = 4;
            /* Execute user subroutine: 'SALDOMES' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV50nAbril = AV72Total;
            AV9Mes = 5;
            /* Execute user subroutine: 'SALDOMES' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV51nMayo = AV72Total;
            AV9Mes = 6;
            /* Execute user subroutine: 'SALDOMES' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV52nJunio = AV72Total;
            AV9Mes = 7;
            /* Execute user subroutine: 'SALDOMES' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV53nJulio = AV72Total;
            AV9Mes = 8;
            /* Execute user subroutine: 'SALDOMES' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV54nAgosto = AV72Total;
            AV9Mes = 9;
            /* Execute user subroutine: 'SALDOMES' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV71nSeptiembre = AV72Total;
            AV9Mes = 10;
            /* Execute user subroutine: 'SALDOMES' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV70nOctubre = AV72Total;
            AV9Mes = 11;
            /* Execute user subroutine: 'SALDOMES' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV69nNoviembre = AV72Total;
            AV9Mes = 12;
            /* Execute user subroutine: 'SALDOMES' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV68nDiciembre = AV72Total;
            AV47nTotal = (decimal)(AV45nEnero+AV48nFebrero+AV49nMarzo+AV50nAbril+AV51nMayo+AV52nJunio+AV53nJulio+AV54nAgosto+AV71nSeptiembre+AV70nOctubre+AV69nNoviembre+AV68nDiciembre);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV60CueCod);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV61Cuenta);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Number = (double)(AV45nEnero);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV48nFebrero);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Number = (double)(AV49nMarzo);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV50nAbril);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV51nMayo);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV52nJunio);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV53nJulio);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV54nAgosto);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV71nSeptiembre);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Number = (double)(AV70nOctubre);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+12, 1, 1).Number = (double)(AV69nNoviembre);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+13, 1, 1).Number = (double)(AV68nDiciembre);
            AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+14, 1, 1).Number = (double)(AV47nTotal);
            AV14CellRow = (int)(AV14CellRow+1);
            if ( ! BRKBM4 )
            {
               BRKBM4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S134( )
      {
         /* 'SALDOMES' Routine */
         returnInSub = false;
         AV72Total = 0.00m;
         /* Using cursor P00BM4 */
         pr_default.execute(2, new Object[] {AV63VouAno, AV9Mes, AV60CueCod, AV62CosCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00BM4_A126TASICod[0];
            A129VouNum = P00BM4_A129VouNum[0];
            A2077VouSts = P00BM4_A2077VouSts[0];
            A128VouMes = P00BM4_A128VouMes[0];
            A127VouAno = P00BM4_A127VouAno[0];
            A91CueCod = P00BM4_A91CueCod[0];
            A79COSCod = P00BM4_A79COSCod[0];
            n79COSCod = P00BM4_n79COSCod[0];
            A2055VouDHab = P00BM4_A2055VouDHab[0];
            A2051VouDDeb = P00BM4_A2051VouDDeb[0];
            A130VouDSec = P00BM4_A130VouDSec[0];
            A2077VouSts = P00BM4_A2077VouSts[0];
            AV72Total = (decimal)(AV72Total+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
         AV10Filename = "";
         AV11ErrorMessage = "";
         AV37Archivo = new GxFile(context.GetPhysicalPath());
         AV38Path = "";
         AV41FilenameOrigen = "";
         AV13ExcelDocument = new ExcelDocumentI();
         AV44Titulo = "";
         AV39Periodo = "";
         scmdbuf = "";
         A79COSCod = "";
         A91CueCod = "";
         P00BM2_A79COSCod = new string[] {""} ;
         P00BM2_n79COSCod = new bool[] {false} ;
         P00BM2_A127VouAno = new short[1] ;
         P00BM2_A91CueCod = new string[] {""} ;
         P00BM2_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BM2_A761COSDsc = new string[] {""} ;
         P00BM2_A128VouMes = new short[1] ;
         P00BM2_A126TASICod = new int[1] ;
         P00BM2_A129VouNum = new string[] {""} ;
         P00BM2_A130VouDSec = new int[1] ;
         A135VouDFec = DateTime.MinValue;
         A761COSDsc = "";
         A129VouNum = "";
         AV62CosCod = "";
         AV67COSDsc = "";
         P00BM3_A133CueCodAux = new string[] {""} ;
         P00BM3_A91CueCod = new string[] {""} ;
         P00BM3_A127VouAno = new short[1] ;
         P00BM3_A859CueCos = new short[1] ;
         P00BM3_A79COSCod = new string[] {""} ;
         P00BM3_n79COSCod = new bool[] {false} ;
         P00BM3_A860CueDsc = new string[] {""} ;
         P00BM3_A128VouMes = new short[1] ;
         P00BM3_A126TASICod = new int[1] ;
         P00BM3_A129VouNum = new string[] {""} ;
         P00BM3_A130VouDSec = new int[1] ;
         A133CueCodAux = "";
         A860CueDsc = "";
         AV60CueCod = "";
         AV61Cuenta = "";
         P00BM4_A126TASICod = new int[1] ;
         P00BM4_A129VouNum = new string[] {""} ;
         P00BM4_A2077VouSts = new short[1] ;
         P00BM4_A128VouMes = new short[1] ;
         P00BM4_A127VouAno = new short[1] ;
         P00BM4_A91CueCod = new string[] {""} ;
         P00BM4_A79COSCod = new string[] {""} ;
         P00BM4_n79COSCod = new bool[] {false} ;
         P00BM4_A2055VouDHab = new decimal[1] ;
         P00BM4_A2051VouDDeb = new decimal[1] ;
         P00BM4_A130VouDSec = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_resumenccostoanualexcel__default(),
            new Object[][] {
                new Object[] {
               P00BM2_A79COSCod, P00BM2_n79COSCod, P00BM2_A127VouAno, P00BM2_A91CueCod, P00BM2_A135VouDFec, P00BM2_A761COSDsc, P00BM2_A128VouMes, P00BM2_A126TASICod, P00BM2_A129VouNum, P00BM2_A130VouDSec
               }
               , new Object[] {
               P00BM3_A133CueCodAux, P00BM3_A91CueCod, P00BM3_A127VouAno, P00BM3_A859CueCos, P00BM3_A79COSCod, P00BM3_n79COSCod, P00BM3_A860CueDsc, P00BM3_A128VouMes, P00BM3_A126TASICod, P00BM3_A129VouNum,
               P00BM3_A130VouDSec
               }
               , new Object[] {
               P00BM4_A126TASICod, P00BM4_A129VouNum, P00BM4_A2077VouSts, P00BM4_A128VouMes, P00BM4_A127VouAno, P00BM4_A91CueCod, P00BM4_A79COSCod, P00BM4_n79COSCod, P00BM4_A2055VouDHab, P00BM4_A2051VouDDeb,
               P00BM4_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV63VouAno ;
      private short AV8Ano ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short A859CueCos ;
      private short AV9Mes ;
      private short A2077VouSts ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private decimal AV45nEnero ;
      private decimal AV72Total ;
      private decimal AV48nFebrero ;
      private decimal AV49nMarzo ;
      private decimal AV50nAbril ;
      private decimal AV51nMayo ;
      private decimal AV52nJunio ;
      private decimal AV53nJulio ;
      private decimal AV54nAgosto ;
      private decimal AV71nSeptiembre ;
      private decimal AV70nOctubre ;
      private decimal AV69nNoviembre ;
      private decimal AV68nDiciembre ;
      private decimal AV47nTotal ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private string AV64CueCod1 ;
      private string AV65CueCod2 ;
      private string AV66nCosCod ;
      private string AV38Path ;
      private string AV44Titulo ;
      private string AV39Periodo ;
      private string scmdbuf ;
      private string A79COSCod ;
      private string A91CueCod ;
      private string A761COSDsc ;
      private string A129VouNum ;
      private string AV62CosCod ;
      private string AV67COSDsc ;
      private string A133CueCodAux ;
      private string A860CueDsc ;
      private string AV60CueCod ;
      private string AV61Cuenta ;
      private DateTime A135VouDFec ;
      private bool returnInSub ;
      private bool BRKBM2 ;
      private bool n79COSCod ;
      private bool BRKBM4 ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV41FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_VouAno ;
      private string aP1_CueCod1 ;
      private string aP2_CueCod2 ;
      private string aP3_nCosCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00BM2_A79COSCod ;
      private bool[] P00BM2_n79COSCod ;
      private short[] P00BM2_A127VouAno ;
      private string[] P00BM2_A91CueCod ;
      private DateTime[] P00BM2_A135VouDFec ;
      private string[] P00BM2_A761COSDsc ;
      private short[] P00BM2_A128VouMes ;
      private int[] P00BM2_A126TASICod ;
      private string[] P00BM2_A129VouNum ;
      private int[] P00BM2_A130VouDSec ;
      private string[] P00BM3_A133CueCodAux ;
      private string[] P00BM3_A91CueCod ;
      private short[] P00BM3_A127VouAno ;
      private short[] P00BM3_A859CueCos ;
      private string[] P00BM3_A79COSCod ;
      private bool[] P00BM3_n79COSCod ;
      private string[] P00BM3_A860CueDsc ;
      private short[] P00BM3_A128VouMes ;
      private int[] P00BM3_A126TASICod ;
      private string[] P00BM3_A129VouNum ;
      private int[] P00BM3_A130VouDSec ;
      private int[] P00BM4_A126TASICod ;
      private string[] P00BM4_A129VouNum ;
      private short[] P00BM4_A2077VouSts ;
      private short[] P00BM4_A128VouMes ;
      private short[] P00BM4_A127VouAno ;
      private string[] P00BM4_A91CueCod ;
      private string[] P00BM4_A79COSCod ;
      private bool[] P00BM4_n79COSCod ;
      private decimal[] P00BM4_A2055VouDHab ;
      private decimal[] P00BM4_A2051VouDDeb ;
      private int[] P00BM4_A130VouDSec ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV37Archivo ;
   }

   public class r_resumenccostoanualexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BM2( IGxContext context ,
                                             string AV66nCosCod ,
                                             string AV64CueCod1 ,
                                             string AV65CueCod2 ,
                                             string A79COSCod ,
                                             string A91CueCod ,
                                             short A127VouAno ,
                                             short AV63VouAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[COSCod], T1.[VouAno], T1.[CueCod], T1.[VouDFec], T2.[COSDsc], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 LEFT JOIN [CBCOSTOS] T2 ON T2.[COSCod] = T1.[COSCod])";
         AddWhere(sWhereString, "(Not (T1.[COSCod] = ''))");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV63VouAno)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66nCosCod)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV66nCosCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64CueCod1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] >= @AV64CueCod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65CueCod2)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] <= @AV65CueCod2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[COSCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00BM3( IGxContext context ,
                                             string AV64CueCod1 ,
                                             string AV65CueCod2 ,
                                             string A91CueCod ,
                                             string A79COSCod ,
                                             string AV62CosCod ,
                                             short A859CueCos ,
                                             short A127VouAno ,
                                             short AV63VouAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouAno], T2.[CueCos], T1.[COSCod], T2.[CueDsc], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         AddWhere(sWhereString, "(T1.[COSCod] = @AV62CosCod)");
         AddWhere(sWhereString, "(T2.[CueCos] = 1)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV63VouAno)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64CueCod1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] >= @AV64CueCod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65CueCod2)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] <= @AV65CueCod2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[CueCodAux]";
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
                     return conditional_P00BM2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] );
               case 1 :
                     return conditional_P00BM3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] );
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
          Object[] prmP00BM4;
          prmP00BM4 = new Object[] {
          new ParDef("@AV63VouAno",GXType.Int16,4,0) ,
          new ParDef("@AV9Mes",GXType.Int16,2,0) ,
          new ParDef("@AV60CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV62CosCod",GXType.NChar,10,0)
          };
          Object[] prmP00BM2;
          prmP00BM2 = new Object[] {
          new ParDef("@AV63VouAno",GXType.Int16,4,0) ,
          new ParDef("@AV66nCosCod",GXType.NChar,10,0) ,
          new ParDef("@AV64CueCod1",GXType.Char,15,0) ,
          new ParDef("@AV65CueCod2",GXType.Char,15,0)
          };
          Object[] prmP00BM3;
          prmP00BM3 = new Object[] {
          new ParDef("@AV62CosCod",GXType.NChar,10,0) ,
          new ParDef("@AV63VouAno",GXType.Int16,4,0) ,
          new ParDef("@AV64CueCod1",GXType.Char,15,0) ,
          new ParDef("@AV65CueCod2",GXType.Char,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BM2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BM2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BM3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BM3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BM4", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[VouAno], T1.[CueCod], T1.[COSCod], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV63VouAno and T1.[VouMes] = @AV9Mes and T1.[CueCod] = @AV60CueCod) AND (T1.[COSCod] = @AV62CosCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BM4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 15);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 10);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                return;
       }
    }

 }

}
