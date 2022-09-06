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
namespace GeneXus.Programs.produccion {
   public class r_resumensaldosvalorizadosexcel : GXProcedure
   {
      public r_resumensaldosvalorizadosexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumensaldosvalorizadosexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SublCod ,
                           ref int aP2_FamCod ,
                           ref int aP3_AlmCod ,
                           ref string aP4_Prodcod ,
                           ref short aP5_Ano ,
                           ref short aP6_Mes ,
                           out string aP7_Filename ,
                           out string aP8_ErrorMessage )
      {
         this.AV78LinCod = aP0_LinCod;
         this.AV116SublCod = aP1_SublCod;
         this.AV44FamCod = aP2_FamCod;
         this.AV10AlmCod = aP3_AlmCod;
         this.AV99Prodcod = aP4_Prodcod;
         this.AV12Ano = aP5_Ano;
         this.AV81Mes = aP6_Mes;
         this.AV50Filename = "" ;
         this.AV42ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV78LinCod;
         aP1_SublCod=this.AV116SublCod;
         aP2_FamCod=this.AV44FamCod;
         aP3_AlmCod=this.AV10AlmCod;
         aP4_Prodcod=this.AV99Prodcod;
         aP5_Ano=this.AV12Ano;
         aP6_Mes=this.AV81Mes;
         aP7_Filename=this.AV50Filename;
         aP8_ErrorMessage=this.AV42ErrorMessage;
      }

      public string executeUdp( ref int aP0_LinCod ,
                                ref int aP1_SublCod ,
                                ref int aP2_FamCod ,
                                ref int aP3_AlmCod ,
                                ref string aP4_Prodcod ,
                                ref short aP5_Ano ,
                                ref short aP6_Mes ,
                                out string aP7_Filename )
      {
         execute(ref aP0_LinCod, ref aP1_SublCod, ref aP2_FamCod, ref aP3_AlmCod, ref aP4_Prodcod, ref aP5_Ano, ref aP6_Mes, out aP7_Filename, out aP8_ErrorMessage);
         return AV42ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SublCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_AlmCod ,
                                 ref string aP4_Prodcod ,
                                 ref short aP5_Ano ,
                                 ref short aP6_Mes ,
                                 out string aP7_Filename ,
                                 out string aP8_ErrorMessage )
      {
         r_resumensaldosvalorizadosexcel objr_resumensaldosvalorizadosexcel;
         objr_resumensaldosvalorizadosexcel = new r_resumensaldosvalorizadosexcel();
         objr_resumensaldosvalorizadosexcel.AV78LinCod = aP0_LinCod;
         objr_resumensaldosvalorizadosexcel.AV116SublCod = aP1_SublCod;
         objr_resumensaldosvalorizadosexcel.AV44FamCod = aP2_FamCod;
         objr_resumensaldosvalorizadosexcel.AV10AlmCod = aP3_AlmCod;
         objr_resumensaldosvalorizadosexcel.AV99Prodcod = aP4_Prodcod;
         objr_resumensaldosvalorizadosexcel.AV12Ano = aP5_Ano;
         objr_resumensaldosvalorizadosexcel.AV81Mes = aP6_Mes;
         objr_resumensaldosvalorizadosexcel.AV50Filename = "" ;
         objr_resumensaldosvalorizadosexcel.AV42ErrorMessage = "" ;
         objr_resumensaldosvalorizadosexcel.context.SetSubmitInitialConfig(context);
         objr_resumensaldosvalorizadosexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumensaldosvalorizadosexcel);
         aP0_LinCod=this.AV78LinCod;
         aP1_SublCod=this.AV116SublCod;
         aP2_FamCod=this.AV44FamCod;
         aP3_AlmCod=this.AV10AlmCod;
         aP4_Prodcod=this.AV99Prodcod;
         aP5_Ano=this.AV12Ano;
         aP6_Mes=this.AV81Mes;
         aP7_Filename=this.AV50Filename;
         aP8_ErrorMessage=this.AV42ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumensaldosvalorizadosexcel)stateInfo).executePrivate();
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
         AV14Archivo.Source = "Excel/PlantillasSaldosValorizadosExcel.xlsx";
         AV98Path = AV14Archivo.GetPath();
         AV51FilenameOrigen = StringUtil.Trim( AV98Path) + "\\PlantillasSaldosValorizadosExcel.xlsx";
         AV50Filename = "Excel/SaldosValorizadosExcel" + ".xlsx";
         AV43ExcelDocument.Clear();
         AV43ExcelDocument.Template = AV51FilenameOrigen;
         AV43ExcelDocument.Open(AV50Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV17CellRow = 7;
         AV55FirstColumn = 1;
         AV97OpcEntrada = (short)(NumberUtil.Val( AV114Session.Get("OpcEntrada"), "."));
         AV24CostoTotal = 0;
         AV118TCantidad = 0;
         AV47FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV81Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV12Ano), 10, 0));
         AV48FechaD = context.localUtil.CToD( AV47FechaC, 2);
         GXt_date1 = AV46Fecha;
         new GeneXus.Programs.generales.pobtieneultimodiames(context ).execute(  AV48FechaD, out  GXt_date1) ;
         AV46Fecha = GXt_date1;
         if ( AV97OpcEntrada == 0 )
         {
            /* Execute user subroutine: 'PORALMACENES' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'SINALMACENES' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'PORALMACENES' Routine */
         returnInSub = false;
         /* Using cursor P00G02 */
         pr_default.execute(0, new Object[] {AV10AlmCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A63AlmCod = P00G02_A63AlmCod[0];
            A436AlmDsc = P00G02_A436AlmDsc[0];
            n436AlmDsc = P00G02_n436AlmDsc[0];
            AV8Almacen = A436AlmDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         GXt_char2 = AV21cMes;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV81Mes, out  GXt_char2) ;
         AV21cMes = GXt_char2;
         AV52Filtro1 = "(Todos)";
         AV53Filtro2 = "Periodo : " + StringUtil.Trim( AV21cMes) + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV12Ano), 10, 0));
         /* Using cursor P00G03 */
         pr_default.execute(1, new Object[] {AV78LinCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A52LinCod = P00G03_A52LinCod[0];
            n52LinCod = P00G03_n52LinCod[0];
            A1153LinDsc = P00G03_A1153LinDsc[0];
            AV52Filtro1 = A1153LinDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV43ExcelDocument.get_Cells(3, 1, 1, 1).Text = StringUtil.Trim( AV53Filtro2);
         AV138TotalGeneral = 0.00m;
         AV111SaldoGeneral = 0.0000m;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV78LinCod ,
                                              AV116SublCod ,
                                              AV44FamCod ,
                                              AV10AlmCod ,
                                              AV99Prodcod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A61SalCosAlmCod ,
                                              A62SalCosProdCod ,
                                              A1830SalCosCant ,
                                              A59SalCosAno ,
                                              AV12Ano ,
                                              A60SalCosMes ,
                                              AV81Mes ,
                                              A1158LinStk ,
                                              A434AlmCos } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00G04 */
         pr_default.execute(2, new Object[] {AV12Ano, AV81Mes, AV78LinCod, AV116SublCod, AV44FamCod, AV10AlmCod, AV99Prodcod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKG04 = false;
            A59SalCosAno = P00G04_A59SalCosAno[0];
            A60SalCosMes = P00G04_A60SalCosMes[0];
            A1158LinStk = P00G04_A1158LinStk[0];
            A434AlmCos = P00G04_A434AlmCos[0];
            n434AlmCos = P00G04_n434AlmCos[0];
            A1153LinDsc = P00G04_A1153LinDsc[0];
            A52LinCod = P00G04_A52LinCod[0];
            n52LinCod = P00G04_n52LinCod[0];
            A1830SalCosCant = P00G04_A1830SalCosCant[0];
            A62SalCosProdCod = P00G04_A62SalCosProdCod[0];
            A61SalCosAlmCod = P00G04_A61SalCosAlmCod[0];
            A50FamCod = P00G04_A50FamCod[0];
            n50FamCod = P00G04_n50FamCod[0];
            A51SublCod = P00G04_A51SublCod[0];
            n51SublCod = P00G04_n51SublCod[0];
            A52LinCod = P00G04_A52LinCod[0];
            n52LinCod = P00G04_n52LinCod[0];
            A50FamCod = P00G04_A50FamCod[0];
            n50FamCod = P00G04_n50FamCod[0];
            A51SublCod = P00G04_A51SublCod[0];
            n51SublCod = P00G04_n51SublCod[0];
            A1158LinStk = P00G04_A1158LinStk[0];
            A1153LinDsc = P00G04_A1153LinDsc[0];
            A434AlmCos = P00G04_A434AlmCos[0];
            n434AlmCos = P00G04_n434AlmCos[0];
            while ( (pr_default.getStatus(2) != 101) && ( P00G04_A52LinCod[0] == A52LinCod ) )
            {
               BRKG04 = false;
               A59SalCosAno = P00G04_A59SalCosAno[0];
               A60SalCosMes = P00G04_A60SalCosMes[0];
               A1153LinDsc = P00G04_A1153LinDsc[0];
               A62SalCosProdCod = P00G04_A62SalCosProdCod[0];
               A61SalCosAlmCod = P00G04_A61SalCosAlmCod[0];
               A1153LinDsc = P00G04_A1153LinDsc[0];
               BRKG04 = true;
               pr_default.readNext(2);
            }
            AV79Linea = A52LinCod;
            AV80LineaDsc = StringUtil.Trim( A1153LinDsc);
            AV16CantLinea = 0.0000m;
            AV141TotLinea = 0.00m;
            /* Execute user subroutine: 'DETALLES' */
            S124 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            AV111SaldoGeneral = (decimal)(AV111SaldoGeneral+AV16CantLinea);
            AV138TotalGeneral = (decimal)(AV138TotalGeneral+AV141TotLinea);
            if ( ! BRKG04 )
            {
               BRKG04 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         AV43ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S131 ();
         if (returnInSub) return;
         AV43ExcelDocument.Close();
      }

      protected void S124( )
      {
         /* 'DETALLES' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV116SublCod ,
                                              AV44FamCod ,
                                              AV10AlmCod ,
                                              AV99Prodcod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A61SalCosAlmCod ,
                                              A62SalCosProdCod ,
                                              A1830SalCosCant ,
                                              A52LinCod ,
                                              AV79Linea ,
                                              A59SalCosAno ,
                                              AV12Ano ,
                                              A60SalCosMes ,
                                              AV81Mes ,
                                              A1158LinStk ,
                                              A434AlmCos } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00G05 */
         pr_default.execute(3, new Object[] {AV79Linea, AV12Ano, AV81Mes, AV116SublCod, AV44FamCod, AV10AlmCod, AV99Prodcod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKG06 = false;
            A55ProdDsc = P00G05_A55ProdDsc[0];
            n55ProdDsc = P00G05_n55ProdDsc[0];
            A62SalCosProdCod = P00G05_A62SalCosProdCod[0];
            A434AlmCos = P00G05_A434AlmCos[0];
            n434AlmCos = P00G05_n434AlmCos[0];
            A1158LinStk = P00G05_A1158LinStk[0];
            A1830SalCosCant = P00G05_A1830SalCosCant[0];
            A60SalCosMes = P00G05_A60SalCosMes[0];
            A59SalCosAno = P00G05_A59SalCosAno[0];
            A61SalCosAlmCod = P00G05_A61SalCosAlmCod[0];
            A50FamCod = P00G05_A50FamCod[0];
            n50FamCod = P00G05_n50FamCod[0];
            A51SublCod = P00G05_A51SublCod[0];
            n51SublCod = P00G05_n51SublCod[0];
            A52LinCod = P00G05_A52LinCod[0];
            n52LinCod = P00G05_n52LinCod[0];
            A55ProdDsc = P00G05_A55ProdDsc[0];
            n55ProdDsc = P00G05_n55ProdDsc[0];
            A50FamCod = P00G05_A50FamCod[0];
            n50FamCod = P00G05_n50FamCod[0];
            A51SublCod = P00G05_A51SublCod[0];
            n51SublCod = P00G05_n51SublCod[0];
            A52LinCod = P00G05_A52LinCod[0];
            n52LinCod = P00G05_n52LinCod[0];
            A1158LinStk = P00G05_A1158LinStk[0];
            A434AlmCos = P00G05_A434AlmCos[0];
            n434AlmCos = P00G05_n434AlmCos[0];
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00G05_A62SalCosProdCod[0], A62SalCosProdCod) == 0 ) )
            {
               BRKG06 = false;
               A55ProdDsc = P00G05_A55ProdDsc[0];
               n55ProdDsc = P00G05_n55ProdDsc[0];
               A60SalCosMes = P00G05_A60SalCosMes[0];
               A59SalCosAno = P00G05_A59SalCosAno[0];
               A61SalCosAlmCod = P00G05_A61SalCosAlmCod[0];
               A55ProdDsc = P00G05_A55ProdDsc[0];
               n55ProdDsc = P00G05_n55ProdDsc[0];
               BRKG06 = true;
               pr_default.readNext(3);
            }
            AV100ProdCodC = A62SalCosProdCod;
            AV102Producto = A55ProdDsc;
            AV110SaldoFinal = 0.0000m;
            AV112SaldoTotal = 0.00m;
            AV27CostoUnit = 0.0000m;
            /* Execute user subroutine: 'MUESTRAPRODUCTOS' */
            S146 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV27CostoUnit = ((AV110SaldoFinal>Convert.ToDecimal(0)) ? NumberUtil.Round( AV112SaldoTotal/ (decimal)(AV110SaldoFinal), 4) : (decimal)(0));
            AV16CantLinea = (decimal)(AV16CantLinea+AV110SaldoFinal);
            AV141TotLinea = (decimal)(AV141TotLinea+AV112SaldoTotal);
            if ( ! BRKG06 )
            {
               BRKG06 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S146( )
      {
         /* 'MUESTRAPRODUCTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV78LinCod ,
                                              AV116SublCod ,
                                              AV44FamCod ,
                                              AV10AlmCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A61SalCosAlmCod ,
                                              A1830SalCosCant ,
                                              A1158LinStk ,
                                              A434AlmCos ,
                                              A59SalCosAno ,
                                              AV12Ano ,
                                              A60SalCosMes ,
                                              AV81Mes ,
                                              AV100ProdCodC ,
                                              A62SalCosProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00G06 */
         pr_default.execute(4, new Object[] {AV100ProdCodC, AV12Ano, AV81Mes, AV78LinCod, AV116SublCod, AV44FamCod, AV10AlmCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A49UniCod = P00G06_A49UniCod[0];
            n49UniCod = P00G06_n49UniCod[0];
            A62SalCosProdCod = P00G06_A62SalCosProdCod[0];
            A60SalCosMes = P00G06_A60SalCosMes[0];
            A59SalCosAno = P00G06_A59SalCosAno[0];
            A434AlmCos = P00G06_A434AlmCos[0];
            n434AlmCos = P00G06_n434AlmCos[0];
            A1158LinStk = P00G06_A1158LinStk[0];
            A1830SalCosCant = P00G06_A1830SalCosCant[0];
            A61SalCosAlmCod = P00G06_A61SalCosAlmCod[0];
            A50FamCod = P00G06_A50FamCod[0];
            n50FamCod = P00G06_n50FamCod[0];
            A51SublCod = P00G06_A51SublCod[0];
            n51SublCod = P00G06_n51SublCod[0];
            A52LinCod = P00G06_A52LinCod[0];
            n52LinCod = P00G06_n52LinCod[0];
            A436AlmDsc = P00G06_A436AlmDsc[0];
            n436AlmDsc = P00G06_n436AlmDsc[0];
            A1997UniAbr = P00G06_A1997UniAbr[0];
            A1831SalCosUni = P00G06_A1831SalCosUni[0];
            A49UniCod = P00G06_A49UniCod[0];
            n49UniCod = P00G06_n49UniCod[0];
            A50FamCod = P00G06_A50FamCod[0];
            n50FamCod = P00G06_n50FamCod[0];
            A51SublCod = P00G06_A51SublCod[0];
            n51SublCod = P00G06_n51SublCod[0];
            A52LinCod = P00G06_A52LinCod[0];
            n52LinCod = P00G06_n52LinCod[0];
            A1997UniAbr = P00G06_A1997UniAbr[0];
            A1158LinStk = P00G06_A1158LinStk[0];
            A434AlmCos = P00G06_A434AlmCos[0];
            n434AlmCos = P00G06_n434AlmCos[0];
            A436AlmDsc = P00G06_A436AlmDsc[0];
            n436AlmDsc = P00G06_n436AlmDsc[0];
            AV11AlmCodigo = A61SalCosAlmCod;
            AV9AlmacenDsc = StringUtil.Trim( A436AlmDsc);
            AV151UniAbr = StringUtil.Trim( A1997UniAbr);
            AV109Saldo = NumberUtil.Round( A1830SalCosCant, 4);
            AV28CostUnit = NumberUtil.Round( A1831SalCosUni, 4);
            AV23CostoT = NumberUtil.Round( AV109Saldo*AV28CostUnit, 2);
            /* Execute user subroutine: 'DETALLE' */
            S158 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            AV110SaldoFinal = (decimal)(AV110SaldoFinal+AV109Saldo);
            AV112SaldoTotal = (decimal)(AV112SaldoTotal+AV23CostoT);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S131( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV43ExcelDocument.ErrCode != 0 )
         {
            AV50Filename = "";
            AV42ErrorMessage = AV43ExcelDocument.ErrDescription;
            AV43ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S158( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV43ExcelDocument.get_Cells(AV17CellRow, AV55FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV80LineaDsc);
         AV43ExcelDocument.get_Cells(AV17CellRow, AV55FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV100ProdCodC);
         AV43ExcelDocument.get_Cells(AV17CellRow, AV55FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV102Producto);
         AV43ExcelDocument.get_Cells(AV17CellRow, AV55FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV151UniAbr);
         AV43ExcelDocument.get_Cells(AV17CellRow, AV55FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV9AlmacenDsc);
         AV43ExcelDocument.get_Cells(AV17CellRow, AV55FirstColumn+5, 1, 1).Number = (double)(AV109Saldo);
         AV43ExcelDocument.get_Cells(AV17CellRow, AV55FirstColumn+6, 1, 1).Number = (double)(AV28CostUnit);
         AV43ExcelDocument.get_Cells(AV17CellRow, AV55FirstColumn+7, 1, 1).Number = (double)(AV23CostoT);
         AV17CellRow = (int)(AV17CellRow+1);
      }

      protected void S161( )
      {
         /* 'SINALMACENES' Routine */
         returnInSub = false;
         /* Using cursor P00G07 */
         pr_default.execute(5, new Object[] {AV10AlmCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A63AlmCod = P00G07_A63AlmCod[0];
            A436AlmDsc = P00G07_A436AlmDsc[0];
            n436AlmDsc = P00G07_n436AlmDsc[0];
            AV8Almacen = A436AlmDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
         GXt_char2 = AV21cMes;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV81Mes, out  GXt_char2) ;
         AV21cMes = GXt_char2;
         AV52Filtro1 = "(Todos)";
         AV53Filtro2 = "Periodo : " + StringUtil.Trim( AV21cMes) + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV12Ano), 10, 0));
         /* Using cursor P00G08 */
         pr_default.execute(6, new Object[] {AV78LinCod});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A52LinCod = P00G08_A52LinCod[0];
            n52LinCod = P00G08_n52LinCod[0];
            A1153LinDsc = P00G08_A1153LinDsc[0];
            AV52Filtro1 = A1153LinDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(6);
         AV43ExcelDocument.get_Cells(3, 1, 1, 1).Text = StringUtil.Trim( AV53Filtro2);
         AV138TotalGeneral = 0.00m;
         AV111SaldoGeneral = 0.0000m;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV78LinCod ,
                                              AV116SublCod ,
                                              AV44FamCod ,
                                              AV10AlmCod ,
                                              AV99Prodcod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A21MvAlm ,
                                              A28ProdCod ,
                                              A1158LinStk ,
                                              A1269MvAlmCos } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00G09 */
         pr_default.execute(7, new Object[] {AV78LinCod, AV116SublCod, AV44FamCod, AV10AlmCod, AV99Prodcod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            BRKG011 = false;
            A13MvATip = P00G09_A13MvATip[0];
            A14MvACod = P00G09_A14MvACod[0];
            A1158LinStk = P00G09_A1158LinStk[0];
            A1269MvAlmCos = P00G09_A1269MvAlmCos[0];
            A1153LinDsc = P00G09_A1153LinDsc[0];
            A52LinCod = P00G09_A52LinCod[0];
            n52LinCod = P00G09_n52LinCod[0];
            A28ProdCod = P00G09_A28ProdCod[0];
            A21MvAlm = P00G09_A21MvAlm[0];
            A50FamCod = P00G09_A50FamCod[0];
            n50FamCod = P00G09_n50FamCod[0];
            A51SublCod = P00G09_A51SublCod[0];
            n51SublCod = P00G09_n51SublCod[0];
            A30MvADItem = P00G09_A30MvADItem[0];
            A21MvAlm = P00G09_A21MvAlm[0];
            A1269MvAlmCos = P00G09_A1269MvAlmCos[0];
            A52LinCod = P00G09_A52LinCod[0];
            n52LinCod = P00G09_n52LinCod[0];
            A50FamCod = P00G09_A50FamCod[0];
            n50FamCod = P00G09_n50FamCod[0];
            A51SublCod = P00G09_A51SublCod[0];
            n51SublCod = P00G09_n51SublCod[0];
            A1158LinStk = P00G09_A1158LinStk[0];
            A1153LinDsc = P00G09_A1153LinDsc[0];
            while ( (pr_default.getStatus(7) != 101) && ( P00G09_A52LinCod[0] == A52LinCod ) )
            {
               BRKG011 = false;
               A13MvATip = P00G09_A13MvATip[0];
               A14MvACod = P00G09_A14MvACod[0];
               A1153LinDsc = P00G09_A1153LinDsc[0];
               A28ProdCod = P00G09_A28ProdCod[0];
               A30MvADItem = P00G09_A30MvADItem[0];
               A1153LinDsc = P00G09_A1153LinDsc[0];
               BRKG011 = true;
               pr_default.readNext(7);
            }
            AV79Linea = A52LinCod;
            AV80LineaDsc = StringUtil.Trim( A1153LinDsc);
            AV16CantLinea = 0.0000m;
            AV141TotLinea = 0.00m;
            /* Execute user subroutine: 'DETALLESS' */
            S1711 ();
            if ( returnInSub )
            {
               pr_default.close(7);
               returnInSub = true;
               if (true) return;
            }
            AV111SaldoGeneral = (decimal)(AV111SaldoGeneral+AV16CantLinea);
            AV138TotalGeneral = (decimal)(AV138TotalGeneral+AV141TotLinea);
            if ( ! BRKG011 )
            {
               BRKG011 = true;
               pr_default.readNext(7);
            }
         }
         pr_default.close(7);
         AV43ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S131 ();
         if (returnInSub) return;
         AV43ExcelDocument.Close();
      }

      protected void S1711( )
      {
         /* 'DETALLESS' Routine */
         returnInSub = false;
         pr_default.dynParam(8, new Object[]{ new Object[]{
                                              AV116SublCod ,
                                              AV44FamCod ,
                                              AV10AlmCod ,
                                              AV99Prodcod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A21MvAlm ,
                                              A28ProdCod ,
                                              A52LinCod ,
                                              AV79Linea ,
                                              A1158LinStk ,
                                              A1269MvAlmCos } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00G010 */
         pr_default.execute(8, new Object[] {AV79Linea, AV116SublCod, AV44FamCod, AV10AlmCod, AV99Prodcod});
         while ( (pr_default.getStatus(8) != 101) )
         {
            BRKG013 = false;
            A13MvATip = P00G010_A13MvATip[0];
            A14MvACod = P00G010_A14MvACod[0];
            A49UniCod = P00G010_A49UniCod[0];
            n49UniCod = P00G010_n49UniCod[0];
            A55ProdDsc = P00G010_A55ProdDsc[0];
            n55ProdDsc = P00G010_n55ProdDsc[0];
            A28ProdCod = P00G010_A28ProdCod[0];
            A1269MvAlmCos = P00G010_A1269MvAlmCos[0];
            A1158LinStk = P00G010_A1158LinStk[0];
            A21MvAlm = P00G010_A21MvAlm[0];
            A50FamCod = P00G010_A50FamCod[0];
            n50FamCod = P00G010_n50FamCod[0];
            A51SublCod = P00G010_A51SublCod[0];
            n51SublCod = P00G010_n51SublCod[0];
            A52LinCod = P00G010_A52LinCod[0];
            n52LinCod = P00G010_n52LinCod[0];
            A1997UniAbr = P00G010_A1997UniAbr[0];
            A30MvADItem = P00G010_A30MvADItem[0];
            A21MvAlm = P00G010_A21MvAlm[0];
            A1269MvAlmCos = P00G010_A1269MvAlmCos[0];
            A49UniCod = P00G010_A49UniCod[0];
            n49UniCod = P00G010_n49UniCod[0];
            A55ProdDsc = P00G010_A55ProdDsc[0];
            n55ProdDsc = P00G010_n55ProdDsc[0];
            A50FamCod = P00G010_A50FamCod[0];
            n50FamCod = P00G010_n50FamCod[0];
            A51SublCod = P00G010_A51SublCod[0];
            n51SublCod = P00G010_n51SublCod[0];
            A52LinCod = P00G010_A52LinCod[0];
            n52LinCod = P00G010_n52LinCod[0];
            A1997UniAbr = P00G010_A1997UniAbr[0];
            A1158LinStk = P00G010_A1158LinStk[0];
            while ( (pr_default.getStatus(8) != 101) && ( StringUtil.StrCmp(P00G010_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRKG013 = false;
               A13MvATip = P00G010_A13MvATip[0];
               A14MvACod = P00G010_A14MvACod[0];
               A55ProdDsc = P00G010_A55ProdDsc[0];
               n55ProdDsc = P00G010_n55ProdDsc[0];
               A30MvADItem = P00G010_A30MvADItem[0];
               A55ProdDsc = P00G010_A55ProdDsc[0];
               n55ProdDsc = P00G010_n55ProdDsc[0];
               BRKG013 = true;
               pr_default.readNext(8);
            }
            AV100ProdCodC = A28ProdCod;
            AV102Producto = A55ProdDsc;
            AV151UniAbr = A1997UniAbr;
            AV110SaldoFinal = 0.0000m;
            AV112SaldoTotal = 0.00m;
            AV27CostoUnit = 0.0000m;
            /* Execute user subroutine: 'MUESTRAPRODUCTOSS' */
            S1813 ();
            if ( returnInSub )
            {
               pr_default.close(8);
               returnInSub = true;
               if (true) return;
            }
            AV16CantLinea = (decimal)(AV16CantLinea+AV110SaldoFinal);
            AV141TotLinea = (decimal)(AV141TotLinea+AV112SaldoTotal);
            if ( ! BRKG013 )
            {
               BRKG013 = true;
               pr_default.readNext(8);
            }
         }
         pr_default.close(8);
      }

      protected void S1813( )
      {
         /* 'MUESTRAPRODUCTOSS' Routine */
         returnInSub = false;
         pr_default.dynParam(9, new Object[]{ new Object[]{
                                              AV10AlmCod ,
                                              A63AlmCod ,
                                              A434AlmCos ,
                                              A438AlmSts ,
                                              AV100ProdCodC ,
                                              A28ProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00G011 */
         pr_default.execute(9, new Object[] {AV100ProdCodC, AV10AlmCod});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A49UniCod = P00G011_A49UniCod[0];
            n49UniCod = P00G011_n49UniCod[0];
            A28ProdCod = P00G011_A28ProdCod[0];
            A63AlmCod = P00G011_A63AlmCod[0];
            A438AlmSts = P00G011_A438AlmSts[0];
            A434AlmCos = P00G011_A434AlmCos[0];
            n434AlmCos = P00G011_n434AlmCos[0];
            A436AlmDsc = P00G011_A436AlmDsc[0];
            n436AlmDsc = P00G011_n436AlmDsc[0];
            A1997UniAbr = P00G011_A1997UniAbr[0];
            A49UniCod = P00G011_A49UniCod[0];
            n49UniCod = P00G011_n49UniCod[0];
            A1997UniAbr = P00G011_A1997UniAbr[0];
            A438AlmSts = P00G011_A438AlmSts[0];
            A434AlmCos = P00G011_A434AlmCos[0];
            n434AlmCos = P00G011_n434AlmCos[0];
            A436AlmDsc = P00G011_A436AlmDsc[0];
            n436AlmDsc = P00G011_n436AlmDsc[0];
            AV10AlmCod = A63AlmCod;
            AV9AlmacenDsc = A436AlmDsc;
            new GeneXus.Programs.produccion.pobtenersaldoproductoalmacencosto(context ).execute( ref  AV100ProdCodC, ref  AV10AlmCod, ref  AV46Fecha, out  AV109Saldo, out  AV27CostoUnit) ;
            if ( ! (Convert.ToDecimal(0)==AV109Saldo) )
            {
               AV28CostUnit = AV27CostoUnit;
               AV23CostoT = NumberUtil.Round( AV109Saldo*AV27CostoUnit, 2);
               AV151UniAbr = StringUtil.Trim( A1997UniAbr);
               /* Execute user subroutine: 'DETALLE' */
               S158 ();
               if ( returnInSub )
               {
                  pr_default.close(9);
                  returnInSub = true;
                  if (true) return;
               }
               AV110SaldoFinal = (decimal)(AV110SaldoFinal+AV109Saldo);
               AV112SaldoTotal = (decimal)(AV112SaldoTotal+AV23CostoT);
            }
            pr_default.readNext(9);
         }
         pr_default.close(9);
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
         AV50Filename = "";
         AV42ErrorMessage = "";
         AV14Archivo = new GxFile(context.GetPhysicalPath());
         AV98Path = "";
         AV51FilenameOrigen = "";
         AV43ExcelDocument = new ExcelDocumentI();
         AV114Session = context.GetSession();
         AV47FechaC = "";
         AV48FechaD = DateTime.MinValue;
         AV46Fecha = DateTime.MinValue;
         GXt_date1 = DateTime.MinValue;
         scmdbuf = "";
         P00G02_A63AlmCod = new int[1] ;
         P00G02_A436AlmDsc = new string[] {""} ;
         P00G02_n436AlmDsc = new bool[] {false} ;
         A436AlmDsc = "";
         AV8Almacen = "";
         AV21cMes = "";
         AV52Filtro1 = "";
         AV53Filtro2 = "";
         P00G03_A52LinCod = new int[1] ;
         P00G03_n52LinCod = new bool[] {false} ;
         P00G03_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         A62SalCosProdCod = "";
         P00G04_A59SalCosAno = new int[1] ;
         P00G04_A60SalCosMes = new short[1] ;
         P00G04_A1158LinStk = new short[1] ;
         P00G04_A434AlmCos = new short[1] ;
         P00G04_n434AlmCos = new bool[] {false} ;
         P00G04_A1153LinDsc = new string[] {""} ;
         P00G04_A52LinCod = new int[1] ;
         P00G04_n52LinCod = new bool[] {false} ;
         P00G04_A1830SalCosCant = new decimal[1] ;
         P00G04_A62SalCosProdCod = new string[] {""} ;
         P00G04_A61SalCosAlmCod = new int[1] ;
         P00G04_A50FamCod = new int[1] ;
         P00G04_n50FamCod = new bool[] {false} ;
         P00G04_A51SublCod = new int[1] ;
         P00G04_n51SublCod = new bool[] {false} ;
         AV80LineaDsc = "";
         P00G05_A55ProdDsc = new string[] {""} ;
         P00G05_n55ProdDsc = new bool[] {false} ;
         P00G05_A62SalCosProdCod = new string[] {""} ;
         P00G05_A434AlmCos = new short[1] ;
         P00G05_n434AlmCos = new bool[] {false} ;
         P00G05_A1158LinStk = new short[1] ;
         P00G05_A1830SalCosCant = new decimal[1] ;
         P00G05_A60SalCosMes = new short[1] ;
         P00G05_A59SalCosAno = new int[1] ;
         P00G05_A61SalCosAlmCod = new int[1] ;
         P00G05_A50FamCod = new int[1] ;
         P00G05_n50FamCod = new bool[] {false} ;
         P00G05_A51SublCod = new int[1] ;
         P00G05_n51SublCod = new bool[] {false} ;
         P00G05_A52LinCod = new int[1] ;
         P00G05_n52LinCod = new bool[] {false} ;
         A55ProdDsc = "";
         AV100ProdCodC = "";
         AV102Producto = "";
         P00G06_A49UniCod = new int[1] ;
         P00G06_n49UniCod = new bool[] {false} ;
         P00G06_A62SalCosProdCod = new string[] {""} ;
         P00G06_A60SalCosMes = new short[1] ;
         P00G06_A59SalCosAno = new int[1] ;
         P00G06_A434AlmCos = new short[1] ;
         P00G06_n434AlmCos = new bool[] {false} ;
         P00G06_A1158LinStk = new short[1] ;
         P00G06_A1830SalCosCant = new decimal[1] ;
         P00G06_A61SalCosAlmCod = new int[1] ;
         P00G06_A50FamCod = new int[1] ;
         P00G06_n50FamCod = new bool[] {false} ;
         P00G06_A51SublCod = new int[1] ;
         P00G06_n51SublCod = new bool[] {false} ;
         P00G06_A52LinCod = new int[1] ;
         P00G06_n52LinCod = new bool[] {false} ;
         P00G06_A436AlmDsc = new string[] {""} ;
         P00G06_n436AlmDsc = new bool[] {false} ;
         P00G06_A1997UniAbr = new string[] {""} ;
         P00G06_A1831SalCosUni = new decimal[1] ;
         A1997UniAbr = "";
         AV9AlmacenDsc = "";
         AV151UniAbr = "";
         P00G07_A63AlmCod = new int[1] ;
         P00G07_A436AlmDsc = new string[] {""} ;
         P00G07_n436AlmDsc = new bool[] {false} ;
         GXt_char2 = "";
         P00G08_A52LinCod = new int[1] ;
         P00G08_n52LinCod = new bool[] {false} ;
         P00G08_A1153LinDsc = new string[] {""} ;
         A28ProdCod = "";
         P00G09_A13MvATip = new string[] {""} ;
         P00G09_A14MvACod = new string[] {""} ;
         P00G09_A1158LinStk = new short[1] ;
         P00G09_A1269MvAlmCos = new short[1] ;
         P00G09_A1153LinDsc = new string[] {""} ;
         P00G09_A52LinCod = new int[1] ;
         P00G09_n52LinCod = new bool[] {false} ;
         P00G09_A28ProdCod = new string[] {""} ;
         P00G09_A21MvAlm = new int[1] ;
         P00G09_A50FamCod = new int[1] ;
         P00G09_n50FamCod = new bool[] {false} ;
         P00G09_A51SublCod = new int[1] ;
         P00G09_n51SublCod = new bool[] {false} ;
         P00G09_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         P00G010_A13MvATip = new string[] {""} ;
         P00G010_A14MvACod = new string[] {""} ;
         P00G010_A49UniCod = new int[1] ;
         P00G010_n49UniCod = new bool[] {false} ;
         P00G010_A55ProdDsc = new string[] {""} ;
         P00G010_n55ProdDsc = new bool[] {false} ;
         P00G010_A28ProdCod = new string[] {""} ;
         P00G010_A1269MvAlmCos = new short[1] ;
         P00G010_A1158LinStk = new short[1] ;
         P00G010_A21MvAlm = new int[1] ;
         P00G010_A50FamCod = new int[1] ;
         P00G010_n50FamCod = new bool[] {false} ;
         P00G010_A51SublCod = new int[1] ;
         P00G010_n51SublCod = new bool[] {false} ;
         P00G010_A52LinCod = new int[1] ;
         P00G010_n52LinCod = new bool[] {false} ;
         P00G010_A1997UniAbr = new string[] {""} ;
         P00G010_A30MvADItem = new int[1] ;
         P00G011_A49UniCod = new int[1] ;
         P00G011_n49UniCod = new bool[] {false} ;
         P00G011_A28ProdCod = new string[] {""} ;
         P00G011_A63AlmCod = new int[1] ;
         P00G011_A438AlmSts = new short[1] ;
         P00G011_A434AlmCos = new short[1] ;
         P00G011_n434AlmCos = new bool[] {false} ;
         P00G011_A436AlmDsc = new string[] {""} ;
         P00G011_n436AlmDsc = new bool[] {false} ;
         P00G011_A1997UniAbr = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_resumensaldosvalorizadosexcel__default(),
            new Object[][] {
                new Object[] {
               P00G02_A63AlmCod, P00G02_A436AlmDsc
               }
               , new Object[] {
               P00G03_A52LinCod, P00G03_A1153LinDsc
               }
               , new Object[] {
               P00G04_A59SalCosAno, P00G04_A60SalCosMes, P00G04_A1158LinStk, P00G04_A434AlmCos, P00G04_n434AlmCos, P00G04_A1153LinDsc, P00G04_A52LinCod, P00G04_n52LinCod, P00G04_A1830SalCosCant, P00G04_A62SalCosProdCod,
               P00G04_A61SalCosAlmCod, P00G04_A50FamCod, P00G04_n50FamCod, P00G04_A51SublCod, P00G04_n51SublCod
               }
               , new Object[] {
               P00G05_A55ProdDsc, P00G05_n55ProdDsc, P00G05_A62SalCosProdCod, P00G05_A434AlmCos, P00G05_n434AlmCos, P00G05_A1158LinStk, P00G05_A1830SalCosCant, P00G05_A60SalCosMes, P00G05_A59SalCosAno, P00G05_A61SalCosAlmCod,
               P00G05_A50FamCod, P00G05_n50FamCod, P00G05_A51SublCod, P00G05_n51SublCod, P00G05_A52LinCod, P00G05_n52LinCod
               }
               , new Object[] {
               P00G06_A49UniCod, P00G06_n49UniCod, P00G06_A62SalCosProdCod, P00G06_A60SalCosMes, P00G06_A59SalCosAno, P00G06_A434AlmCos, P00G06_n434AlmCos, P00G06_A1158LinStk, P00G06_A1830SalCosCant, P00G06_A61SalCosAlmCod,
               P00G06_A50FamCod, P00G06_n50FamCod, P00G06_A51SublCod, P00G06_n51SublCod, P00G06_A52LinCod, P00G06_n52LinCod, P00G06_A436AlmDsc, P00G06_n436AlmDsc, P00G06_A1997UniAbr, P00G06_A1831SalCosUni
               }
               , new Object[] {
               P00G07_A63AlmCod, P00G07_A436AlmDsc
               }
               , new Object[] {
               P00G08_A52LinCod, P00G08_A1153LinDsc
               }
               , new Object[] {
               P00G09_A13MvATip, P00G09_A14MvACod, P00G09_A1158LinStk, P00G09_A1269MvAlmCos, P00G09_A1153LinDsc, P00G09_A52LinCod, P00G09_A28ProdCod, P00G09_A21MvAlm, P00G09_A50FamCod, P00G09_n50FamCod,
               P00G09_A51SublCod, P00G09_n51SublCod, P00G09_A30MvADItem
               }
               , new Object[] {
               P00G010_A13MvATip, P00G010_A14MvACod, P00G010_A49UniCod, P00G010_A55ProdDsc, P00G010_A28ProdCod, P00G010_A1269MvAlmCos, P00G010_A1158LinStk, P00G010_A21MvAlm, P00G010_A50FamCod, P00G010_n50FamCod,
               P00G010_A51SublCod, P00G010_n51SublCod, P00G010_A52LinCod, P00G010_A1997UniAbr, P00G010_A30MvADItem
               }
               , new Object[] {
               P00G011_A49UniCod, P00G011_A28ProdCod, P00G011_A63AlmCod, P00G011_A438AlmSts, P00G011_A434AlmCos, P00G011_A436AlmDsc, P00G011_A1997UniAbr
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12Ano ;
      private short AV81Mes ;
      private short AV97OpcEntrada ;
      private short A60SalCosMes ;
      private short A1158LinStk ;
      private short A434AlmCos ;
      private short A1269MvAlmCos ;
      private short A438AlmSts ;
      private int AV78LinCod ;
      private int AV116SublCod ;
      private int AV44FamCod ;
      private int AV10AlmCod ;
      private int AV17CellRow ;
      private int AV55FirstColumn ;
      private int A63AlmCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A61SalCosAlmCod ;
      private int A59SalCosAno ;
      private int AV79Linea ;
      private int A49UniCod ;
      private int AV11AlmCodigo ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private decimal AV24CostoTotal ;
      private decimal AV118TCantidad ;
      private decimal AV138TotalGeneral ;
      private decimal AV111SaldoGeneral ;
      private decimal A1830SalCosCant ;
      private decimal AV16CantLinea ;
      private decimal AV141TotLinea ;
      private decimal AV110SaldoFinal ;
      private decimal AV112SaldoTotal ;
      private decimal AV27CostoUnit ;
      private decimal A1831SalCosUni ;
      private decimal AV109Saldo ;
      private decimal AV28CostUnit ;
      private decimal AV23CostoT ;
      private string AV99Prodcod ;
      private string AV98Path ;
      private string AV47FechaC ;
      private string scmdbuf ;
      private string A436AlmDsc ;
      private string AV8Almacen ;
      private string AV21cMes ;
      private string A1153LinDsc ;
      private string A62SalCosProdCod ;
      private string AV80LineaDsc ;
      private string A55ProdDsc ;
      private string AV100ProdCodC ;
      private string AV102Producto ;
      private string A1997UniAbr ;
      private string AV9AlmacenDsc ;
      private string AV151UniAbr ;
      private string GXt_char2 ;
      private string A28ProdCod ;
      private string A13MvATip ;
      private string A14MvACod ;
      private DateTime AV48FechaD ;
      private DateTime AV46Fecha ;
      private DateTime GXt_date1 ;
      private bool returnInSub ;
      private bool n436AlmDsc ;
      private bool n52LinCod ;
      private bool BRKG04 ;
      private bool n434AlmCos ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool BRKG06 ;
      private bool n55ProdDsc ;
      private bool n49UniCod ;
      private bool BRKG011 ;
      private bool BRKG013 ;
      private string AV50Filename ;
      private string AV42ErrorMessage ;
      private string AV51FilenameOrigen ;
      private string AV52Filtro1 ;
      private string AV53Filtro2 ;
      private IGxSession AV114Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SublCod ;
      private int aP2_FamCod ;
      private int aP3_AlmCod ;
      private string aP4_Prodcod ;
      private short aP5_Ano ;
      private short aP6_Mes ;
      private IDataStoreProvider pr_default ;
      private int[] P00G02_A63AlmCod ;
      private string[] P00G02_A436AlmDsc ;
      private bool[] P00G02_n436AlmDsc ;
      private int[] P00G03_A52LinCod ;
      private bool[] P00G03_n52LinCod ;
      private string[] P00G03_A1153LinDsc ;
      private int[] P00G04_A59SalCosAno ;
      private short[] P00G04_A60SalCosMes ;
      private short[] P00G04_A1158LinStk ;
      private short[] P00G04_A434AlmCos ;
      private bool[] P00G04_n434AlmCos ;
      private string[] P00G04_A1153LinDsc ;
      private int[] P00G04_A52LinCod ;
      private bool[] P00G04_n52LinCod ;
      private decimal[] P00G04_A1830SalCosCant ;
      private string[] P00G04_A62SalCosProdCod ;
      private int[] P00G04_A61SalCosAlmCod ;
      private int[] P00G04_A50FamCod ;
      private bool[] P00G04_n50FamCod ;
      private int[] P00G04_A51SublCod ;
      private bool[] P00G04_n51SublCod ;
      private string[] P00G05_A55ProdDsc ;
      private bool[] P00G05_n55ProdDsc ;
      private string[] P00G05_A62SalCosProdCod ;
      private short[] P00G05_A434AlmCos ;
      private bool[] P00G05_n434AlmCos ;
      private short[] P00G05_A1158LinStk ;
      private decimal[] P00G05_A1830SalCosCant ;
      private short[] P00G05_A60SalCosMes ;
      private int[] P00G05_A59SalCosAno ;
      private int[] P00G05_A61SalCosAlmCod ;
      private int[] P00G05_A50FamCod ;
      private bool[] P00G05_n50FamCod ;
      private int[] P00G05_A51SublCod ;
      private bool[] P00G05_n51SublCod ;
      private int[] P00G05_A52LinCod ;
      private bool[] P00G05_n52LinCod ;
      private int[] P00G06_A49UniCod ;
      private bool[] P00G06_n49UniCod ;
      private string[] P00G06_A62SalCosProdCod ;
      private short[] P00G06_A60SalCosMes ;
      private int[] P00G06_A59SalCosAno ;
      private short[] P00G06_A434AlmCos ;
      private bool[] P00G06_n434AlmCos ;
      private short[] P00G06_A1158LinStk ;
      private decimal[] P00G06_A1830SalCosCant ;
      private int[] P00G06_A61SalCosAlmCod ;
      private int[] P00G06_A50FamCod ;
      private bool[] P00G06_n50FamCod ;
      private int[] P00G06_A51SublCod ;
      private bool[] P00G06_n51SublCod ;
      private int[] P00G06_A52LinCod ;
      private bool[] P00G06_n52LinCod ;
      private string[] P00G06_A436AlmDsc ;
      private bool[] P00G06_n436AlmDsc ;
      private string[] P00G06_A1997UniAbr ;
      private decimal[] P00G06_A1831SalCosUni ;
      private int[] P00G07_A63AlmCod ;
      private string[] P00G07_A436AlmDsc ;
      private bool[] P00G07_n436AlmDsc ;
      private int[] P00G08_A52LinCod ;
      private bool[] P00G08_n52LinCod ;
      private string[] P00G08_A1153LinDsc ;
      private string[] P00G09_A13MvATip ;
      private string[] P00G09_A14MvACod ;
      private short[] P00G09_A1158LinStk ;
      private short[] P00G09_A1269MvAlmCos ;
      private string[] P00G09_A1153LinDsc ;
      private int[] P00G09_A52LinCod ;
      private bool[] P00G09_n52LinCod ;
      private string[] P00G09_A28ProdCod ;
      private int[] P00G09_A21MvAlm ;
      private int[] P00G09_A50FamCod ;
      private bool[] P00G09_n50FamCod ;
      private int[] P00G09_A51SublCod ;
      private bool[] P00G09_n51SublCod ;
      private int[] P00G09_A30MvADItem ;
      private string[] P00G010_A13MvATip ;
      private string[] P00G010_A14MvACod ;
      private int[] P00G010_A49UniCod ;
      private bool[] P00G010_n49UniCod ;
      private string[] P00G010_A55ProdDsc ;
      private bool[] P00G010_n55ProdDsc ;
      private string[] P00G010_A28ProdCod ;
      private short[] P00G010_A1269MvAlmCos ;
      private short[] P00G010_A1158LinStk ;
      private int[] P00G010_A21MvAlm ;
      private int[] P00G010_A50FamCod ;
      private bool[] P00G010_n50FamCod ;
      private int[] P00G010_A51SublCod ;
      private bool[] P00G010_n51SublCod ;
      private int[] P00G010_A52LinCod ;
      private bool[] P00G010_n52LinCod ;
      private string[] P00G010_A1997UniAbr ;
      private int[] P00G010_A30MvADItem ;
      private int[] P00G011_A49UniCod ;
      private bool[] P00G011_n49UniCod ;
      private string[] P00G011_A28ProdCod ;
      private int[] P00G011_A63AlmCod ;
      private short[] P00G011_A438AlmSts ;
      private short[] P00G011_A434AlmCos ;
      private bool[] P00G011_n434AlmCos ;
      private string[] P00G011_A436AlmDsc ;
      private bool[] P00G011_n436AlmDsc ;
      private string[] P00G011_A1997UniAbr ;
      private string aP7_Filename ;
      private string aP8_ErrorMessage ;
      private ExcelDocumentI AV43ExcelDocument ;
      private GxFile AV14Archivo ;
   }

   public class r_resumensaldosvalorizadosexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00G04( IGxContext context ,
                                             int AV78LinCod ,
                                             int AV116SublCod ,
                                             int AV44FamCod ,
                                             int AV10AlmCod ,
                                             string AV99Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A61SalCosAlmCod ,
                                             string A62SalCosProdCod ,
                                             decimal A1830SalCosCant ,
                                             int A59SalCosAno ,
                                             short AV12Ano ,
                                             short A60SalCosMes ,
                                             short AV81Mes ,
                                             short A1158LinStk ,
                                             short A434AlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[SalCosAno], T1.[SalCosMes], T3.[LinStk], T4.[AlmCos], T3.[LinDsc], T2.[LinCod], T1.[SalCosCant], T1.[SalCosProdCod] AS SalCosProdCod, T1.[SalCosAlmCod] AS SalCosAlmCod, T2.[FamCod], T2.[SublCod] FROM ((([ASALDOCOSTOMENSUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[SalCosProdCod]) LEFT JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T1.[SalCosAlmCod])";
         AddWhere(sWhereString, "(T1.[SalCosCant] <> 0)");
         AddWhere(sWhereString, "(T1.[SalCosAno] = @AV12Ano)");
         AddWhere(sWhereString, "(T1.[SalCosMes] = @AV81Mes)");
         AddWhere(sWhereString, "(T3.[LinStk] = 1)");
         AddWhere(sWhereString, "(T4.[AlmCos] = 1)");
         if ( ! (0==AV78LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV78LinCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV116SublCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV116SublCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV44FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV44FamCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV10AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[SalCosAlmCod] = @AV10AlmCod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[SalCosProdCod] = @AV99Prodcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[LinCod], T3.[LinDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00G05( IGxContext context ,
                                             int AV116SublCod ,
                                             int AV44FamCod ,
                                             int AV10AlmCod ,
                                             string AV99Prodcod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A61SalCosAlmCod ,
                                             string A62SalCosProdCod ,
                                             decimal A1830SalCosCant ,
                                             int A52LinCod ,
                                             int AV79Linea ,
                                             int A59SalCosAno ,
                                             short AV12Ano ,
                                             short A60SalCosMes ,
                                             short AV81Mes ,
                                             short A1158LinStk ,
                                             short A434AlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[7];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T2.[ProdDsc], T1.[SalCosProdCod] AS SalCosProdCod, T4.[AlmCos], T3.[LinStk], T1.[SalCosCant], T1.[SalCosMes], T1.[SalCosAno], T1.[SalCosAlmCod] AS SalCosAlmCod, T2.[FamCod], T2.[SublCod], T2.[LinCod] FROM ((([ASALDOCOSTOMENSUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[SalCosProdCod]) LEFT JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T1.[SalCosAlmCod])";
         AddWhere(sWhereString, "(T1.[SalCosCant] <> 0)");
         AddWhere(sWhereString, "(T2.[LinCod] = @AV79Linea)");
         AddWhere(sWhereString, "(T1.[SalCosAno] = @AV12Ano)");
         AddWhere(sWhereString, "(T1.[SalCosMes] = @AV81Mes)");
         AddWhere(sWhereString, "(T3.[LinStk] = 1)");
         AddWhere(sWhereString, "(T4.[AlmCos] = 1)");
         if ( ! (0==AV116SublCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV116SublCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV44FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV44FamCod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (0==AV10AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[SalCosAlmCod] = @AV10AlmCod)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[SalCosProdCod] = @AV99Prodcod)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SalCosProdCod], T2.[ProdDsc]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00G06( IGxContext context ,
                                             int AV78LinCod ,
                                             int AV116SublCod ,
                                             int AV44FamCod ,
                                             int AV10AlmCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A61SalCosAlmCod ,
                                             decimal A1830SalCosCant ,
                                             short A1158LinStk ,
                                             short A434AlmCos ,
                                             int A59SalCosAno ,
                                             short AV12Ano ,
                                             short A60SalCosMes ,
                                             short AV81Mes ,
                                             string AV100ProdCodC ,
                                             string A62SalCosProdCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[7];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T1.[SalCosProdCod] AS SalCosProdCod, T1.[SalCosMes], T1.[SalCosAno], T5.[AlmCos], T4.[LinStk], T1.[SalCosCant], T1.[SalCosAlmCod] AS SalCosAlmCod, T2.[FamCod], T2.[SublCod], T2.[LinCod], T5.[AlmDsc], T3.[UniAbr], T1.[SalCosUni] FROM (((([ASALDOCOSTOMENSUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[SalCosProdCod]) LEFT JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) LEFT JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T2.[LinCod]) INNER JOIN [CALMACEN] T5 ON T5.[AlmCod] = T1.[SalCosAlmCod])";
         AddWhere(sWhereString, "(T1.[SalCosProdCod] = @AV100ProdCodC)");
         AddWhere(sWhereString, "(T1.[SalCosCant] <> 0)");
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         AddWhere(sWhereString, "(T5.[AlmCos] = 1)");
         AddWhere(sWhereString, "(T1.[SalCosAno] = @AV12Ano)");
         AddWhere(sWhereString, "(T1.[SalCosMes] = @AV81Mes)");
         if ( ! (0==AV78LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV78LinCod)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (0==AV116SublCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV116SublCod)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! (0==AV44FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV44FamCod)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (0==AV10AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[SalCosAlmCod] = @AV10AlmCod)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SalCosProdCod]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00G09( IGxContext context ,
                                             int AV78LinCod ,
                                             int AV116SublCod ,
                                             int AV44FamCod ,
                                             int AV10AlmCod ,
                                             string AV99Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A21MvAlm ,
                                             string A28ProdCod ,
                                             short A1158LinStk ,
                                             short A1269MvAlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[5];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T5.[LinStk], T3.[AlmCos] AS MvAlmCos, T5.[LinDsc], T4.[LinCod], T1.[ProdCod], T2.[MvAlm] AS MvAlm, T4.[FamCod], T4.[SublCod], T1.[MvADItem] FROM (((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T4.[LinCod])";
         AddWhere(sWhereString, "(T5.[LinStk] = 1)");
         AddWhere(sWhereString, "(T3.[AlmCos] = 1)");
         if ( ! (0==AV78LinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV78LinCod)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! (0==AV116SublCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV116SublCod)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! (0==AV44FamCod) )
         {
            AddWhere(sWhereString, "(T4.[FamCod] = @AV44FamCod)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! (0==AV10AlmCod) )
         {
            AddWhere(sWhereString, "(T2.[MvAlm] = @AV10AlmCod)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV99Prodcod)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T4.[LinCod], T5.[LinDsc]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P00G010( IGxContext context ,
                                              int AV116SublCod ,
                                              int AV44FamCod ,
                                              int AV10AlmCod ,
                                              string AV99Prodcod ,
                                              int A51SublCod ,
                                              int A50FamCod ,
                                              int A21MvAlm ,
                                              string A28ProdCod ,
                                              int A52LinCod ,
                                              int AV79Linea ,
                                              short A1158LinStk ,
                                              short A1269MvAlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[5];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T4.[UniCod], T4.[ProdDsc], T1.[ProdCod], T3.[AlmCos] AS MvAlmCos, T6.[LinStk], T2.[MvAlm] AS MvAlm, T4.[FamCod], T4.[SublCod], T4.[LinCod], T5.[UniAbr], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T5 ON T5.[UniCod] = T4.[UniCod]) INNER JOIN [CLINEAPROD] T6 ON T6.[LinCod] = T4.[LinCod])";
         AddWhere(sWhereString, "(T4.[LinCod] = @AV79Linea)");
         AddWhere(sWhereString, "(T6.[LinStk] = 1)");
         AddWhere(sWhereString, "(T3.[AlmCos] = 1)");
         if ( ! (0==AV116SublCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV116SublCod)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ! (0==AV44FamCod) )
         {
            AddWhere(sWhereString, "(T4.[FamCod] = @AV44FamCod)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ! (0==AV10AlmCod) )
         {
            AddWhere(sWhereString, "(T2.[MvAlm] = @AV10AlmCod)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV99Prodcod)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T4.[ProdDsc]";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P00G011( IGxContext context ,
                                              int AV10AlmCod ,
                                              int A63AlmCod ,
                                              short A434AlmCos ,
                                              short A438AlmSts ,
                                              string AV100ProdCodC ,
                                              string A28ProdCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[2];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T1.[ProdCod], T1.[AlmCod], T4.[AlmSts], T4.[AlmCos], T4.[AlmDsc], T3.[UniAbr] FROM ((([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T1.[AlmCod])";
         AddWhere(sWhereString, "(T1.[ProdCod] = @AV100ProdCodC)");
         AddWhere(sWhereString, "(T4.[AlmCos] = 1)");
         AddWhere(sWhereString, "(T4.[AlmSts] = 1)");
         if ( ! (0==AV10AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[AlmCod] = @AV10AlmCod)");
         }
         else
         {
            GXv_int13[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod]";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P00G04(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (decimal)dynConstraints[10] , (int)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] );
               case 3 :
                     return conditional_P00G05(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] );
               case 4 :
                     return conditional_P00G06(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (decimal)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (int)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] );
               case 7 :
                     return conditional_P00G09(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
               case 8 :
                     return conditional_P00G010(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
               case 9 :
                     return conditional_P00G011(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] );
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
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00G02;
          prmP00G02 = new Object[] {
          new ParDef("@AV10AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP00G03;
          prmP00G03 = new Object[] {
          new ParDef("@AV78LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00G07;
          prmP00G07 = new Object[] {
          new ParDef("@AV10AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP00G08;
          prmP00G08 = new Object[] {
          new ParDef("@AV78LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00G04;
          prmP00G04 = new Object[] {
          new ParDef("@AV12Ano",GXType.Int16,4,0) ,
          new ParDef("@AV81Mes",GXType.Int16,2,0) ,
          new ParDef("@AV78LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV116SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV44FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV10AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV99Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00G05;
          prmP00G05 = new Object[] {
          new ParDef("@AV79Linea",GXType.Int32,6,0) ,
          new ParDef("@AV12Ano",GXType.Int16,4,0) ,
          new ParDef("@AV81Mes",GXType.Int16,2,0) ,
          new ParDef("@AV116SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV44FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV10AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV99Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00G06;
          prmP00G06 = new Object[] {
          new ParDef("@AV100ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV12Ano",GXType.Int16,4,0) ,
          new ParDef("@AV81Mes",GXType.Int16,2,0) ,
          new ParDef("@AV78LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV116SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV44FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV10AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP00G09;
          prmP00G09 = new Object[] {
          new ParDef("@AV78LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV116SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV44FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV10AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV99Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00G010;
          prmP00G010 = new Object[] {
          new ParDef("@AV79Linea",GXType.Int32,6,0) ,
          new ParDef("@AV116SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV44FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV10AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV99Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00G011;
          prmP00G011 = new Object[] {
          new ParDef("@AV100ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV10AlmCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00G02", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV10AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G02,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G03", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV78LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G03,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G04", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G04,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G05", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G05,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G06", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G06,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G07", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV10AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G07,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G08", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV78LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G08,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G09", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G09,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G010", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G010,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G011", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G011,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 15);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((int[]) buf[13])[0] = rslt.getInt(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 15);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((int[]) buf[12])[0] = rslt.getInt(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((int[]) buf[14])[0] = rslt.getInt(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 15);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((int[]) buf[12])[0] = rslt.getInt(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((int[]) buf[14])[0] = rslt.getInt(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 100);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getString(13, 5);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(14);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 5);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                return;
       }
    }

 }

}
