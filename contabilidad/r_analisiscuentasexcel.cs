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
   public class r_analisiscuentasexcel : GXProcedure
   {
      public r_analisiscuentasexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_analisiscuentasexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref DateTime aP2_FDesde ,
                           ref DateTime aP3_Fhasta ,
                           ref string aP4_CueCod1 ,
                           ref string aP5_CueCod2 ,
                           ref string aP6_cCueCodAux ,
                           ref string aP7_Tipo ,
                           out string aP8_Filename ,
                           out string aP9_ErrorMessage )
      {
         this.AV8Ano = aP0_Ano;
         this.AV9Mes = aP1_Mes;
         this.AV88FDesde = aP2_FDesde;
         this.AV89Fhasta = aP3_Fhasta;
         this.AV90CueCod1 = aP4_CueCod1;
         this.AV91CueCod2 = aP5_CueCod2;
         this.AV92cCueCodAux = aP6_cCueCodAux;
         this.AV93Tipo = aP7_Tipo;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV9Mes;
         aP2_FDesde=this.AV88FDesde;
         aP3_Fhasta=this.AV89Fhasta;
         aP4_CueCod1=this.AV90CueCod1;
         aP5_CueCod2=this.AV91CueCod2;
         aP6_cCueCodAux=this.AV92cCueCodAux;
         aP7_Tipo=this.AV93Tipo;
         aP8_Filename=this.AV10Filename;
         aP9_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                ref DateTime aP2_FDesde ,
                                ref DateTime aP3_Fhasta ,
                                ref string aP4_CueCod1 ,
                                ref string aP5_CueCod2 ,
                                ref string aP6_cCueCodAux ,
                                ref string aP7_Tipo ,
                                out string aP8_Filename )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_FDesde, ref aP3_Fhasta, ref aP4_CueCod1, ref aP5_CueCod2, ref aP6_cCueCodAux, ref aP7_Tipo, out aP8_Filename, out aP9_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref DateTime aP2_FDesde ,
                                 ref DateTime aP3_Fhasta ,
                                 ref string aP4_CueCod1 ,
                                 ref string aP5_CueCod2 ,
                                 ref string aP6_cCueCodAux ,
                                 ref string aP7_Tipo ,
                                 out string aP8_Filename ,
                                 out string aP9_ErrorMessage )
      {
         r_analisiscuentasexcel objr_analisiscuentasexcel;
         objr_analisiscuentasexcel = new r_analisiscuentasexcel();
         objr_analisiscuentasexcel.AV8Ano = aP0_Ano;
         objr_analisiscuentasexcel.AV9Mes = aP1_Mes;
         objr_analisiscuentasexcel.AV88FDesde = aP2_FDesde;
         objr_analisiscuentasexcel.AV89Fhasta = aP3_Fhasta;
         objr_analisiscuentasexcel.AV90CueCod1 = aP4_CueCod1;
         objr_analisiscuentasexcel.AV91CueCod2 = aP5_CueCod2;
         objr_analisiscuentasexcel.AV92cCueCodAux = aP6_cCueCodAux;
         objr_analisiscuentasexcel.AV93Tipo = aP7_Tipo;
         objr_analisiscuentasexcel.AV10Filename = "" ;
         objr_analisiscuentasexcel.AV11ErrorMessage = "" ;
         objr_analisiscuentasexcel.context.SetSubmitInitialConfig(context);
         objr_analisiscuentasexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_analisiscuentasexcel);
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV9Mes;
         aP2_FDesde=this.AV88FDesde;
         aP3_Fhasta=this.AV89Fhasta;
         aP4_CueCod1=this.AV90CueCod1;
         aP5_CueCod2=this.AV91CueCod2;
         aP6_cCueCodAux=this.AV92cCueCodAux;
         aP7_Tipo=this.AV93Tipo;
         aP8_Filename=this.AV10Filename;
         aP9_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_analisiscuentasexcel)stateInfo).executePrivate();
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
         AV37Archivo.Source = "Excel/PlantillasAnalisisCuentas.xlsx";
         AV38Path = AV37Archivo.GetPath();
         AV41FilenameOrigen = StringUtil.Trim( AV38Path) + "\\PlantillasAnalisisCuentas.xlsx";
         AV10Filename = "Excel/AnalisisCuentas" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV41FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV93Tipo, "G") == 0 )
         {
            AV94cAno = StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 4, 0));
            GXt_char1 = AV42cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV9Mes, out  GXt_char1) ;
            AV42cMes = GXt_char1;
            AV39Periodo = "Periodo : " + StringUtil.Trim( AV42cMes) + " " + StringUtil.Trim( AV94cAno);
         }
         else
         {
            AV39Periodo = "Periodo : " + context.localUtil.DToC( AV88FDesde, 2, "/") + " Al " + context.localUtil.DToC( AV89Fhasta, 2, "/");
         }
         AV14CellRow = 3;
         AV15FirstColumn = 1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV39Periodo);
         AV14CellRow = 5;
         AV15FirstColumn = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV90CueCod1 ,
                                              AV91CueCod2 ,
                                              AV92cCueCodAux ,
                                              A91CueCod ,
                                              A133CueCodAux ,
                                              A2077VouSts ,
                                              A127VouAno ,
                                              AV8Ano } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00B02 */
         pr_default.execute(0, new Object[] {AV8Ano, AV90CueCod1, AV91CueCod2, AV92cCueCodAux});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKB02 = false;
            A2074VouFec = P00B02_A2074VouFec[0];
            A136VouReg = P00B02_A136VouReg[0];
            A133CueCodAux = P00B02_A133CueCodAux[0];
            A70TipACod = P00B02_A70TipACod[0];
            n70TipACod = P00B02_n70TipACod[0];
            A132VouDTipCod = P00B02_A132VouDTipCod[0];
            A126TASICod = P00B02_A126TASICod[0];
            A1894TASIAbr = P00B02_A1894TASIAbr[0];
            A129VouNum = P00B02_A129VouNum[0];
            A135VouDFec = P00B02_A135VouDFec[0];
            A2054VouDGls = P00B02_A2054VouDGls[0];
            A2053VouDDoc = P00B02_A2053VouDDoc[0];
            A128VouMes = P00B02_A128VouMes[0];
            A127VouAno = P00B02_A127VouAno[0];
            A2077VouSts = P00B02_A2077VouSts[0];
            A91CueCod = P00B02_A91CueCod[0];
            A131VouDMon = P00B02_A131VouDMon[0];
            A2055VouDHab = P00B02_A2055VouDHab[0];
            A2051VouDDeb = P00B02_A2051VouDDeb[0];
            A2056VouDHabO = P00B02_A2056VouDHabO[0];
            A2052VouDDebO = P00B02_A2052VouDDebO[0];
            A860CueDsc = P00B02_A860CueDsc[0];
            A130VouDSec = P00B02_A130VouDSec[0];
            A1894TASIAbr = P00B02_A1894TASIAbr[0];
            A2074VouFec = P00B02_A2074VouFec[0];
            A2077VouSts = P00B02_A2077VouSts[0];
            A70TipACod = P00B02_A70TipACod[0];
            n70TipACod = P00B02_n70TipACod[0];
            A860CueDsc = P00B02_A860CueDsc[0];
            AV46CueCod = A91CueCod;
            AV47CueDsc = A860CueDsc;
            AV105TSaldoS = 0.00m;
            AV106TSaldoD = 0.00m;
            AV87TipACod = A70TipACod;
            /* Execute user subroutine: 'VALIDASALDOCUENTA' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( ! (Convert.ToDecimal(0)==AV95SaldoVerCuenta) )
            {
               /* Execute user subroutine: 'PRINTSALDOINICIAL' */
               S151 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( (0==AV87TipACod) )
            {
               AV96SaldoS = 0.00m;
               AV97SaldoD = 0.00m;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00B02_A91CueCod[0], A91CueCod) == 0 ) )
               {
                  BRKB02 = false;
                  A126TASICod = P00B02_A126TASICod[0];
                  A129VouNum = P00B02_A129VouNum[0];
                  A128VouMes = P00B02_A128VouMes[0];
                  A127VouAno = P00B02_A127VouAno[0];
                  A2077VouSts = P00B02_A2077VouSts[0];
                  A131VouDMon = P00B02_A131VouDMon[0];
                  A2055VouDHab = P00B02_A2055VouDHab[0];
                  A2051VouDDeb = P00B02_A2051VouDDeb[0];
                  A2056VouDHabO = P00B02_A2056VouDHabO[0];
                  A2052VouDDebO = P00B02_A2052VouDDebO[0];
                  A130VouDSec = P00B02_A130VouDSec[0];
                  A2077VouSts = P00B02_A2077VouSts[0];
                  if ( StringUtil.StrCmp(A91CueCod, AV46CueCod) == 0 )
                  {
                     if ( A2077VouSts == 1 )
                     {
                        if ( A128VouMes < AV9Mes )
                        {
                           if ( A127VouAno == AV8Ano )
                           {
                              AV107VouDMon = A131VouDMon;
                              AV96SaldoS = (decimal)(AV96SaldoS+(NumberUtil.Round( (A2051VouDDeb-A2055VouDHab), 2)));
                              if ( ! ( AV107VouDMon == 1 ) )
                              {
                                 AV97SaldoD = (decimal)(AV97SaldoD+(NumberUtil.Round( (A2052VouDDebO-A2056VouDHabO), 2)));
                              }
                           }
                        }
                     }
                  }
                  BRKB02 = true;
                  pr_default.readNext(0);
               }
               AV105TSaldoS = AV96SaldoS;
               AV106TSaldoD = AV97SaldoD;
               /* Execute user subroutine: 'PRINTSALDOANTERIOR' */
               S181 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               while ( (pr_default.getStatus(0) != 101) && ( P00B02_A127VouAno[0] == A127VouAno ) && ( P00B02_A128VouMes[0] == A128VouMes ) && ( StringUtil.StrCmp(P00B02_A91CueCod[0], A91CueCod) == 0 ) )
               {
                  BRKB02 = false;
                  A132VouDTipCod = P00B02_A132VouDTipCod[0];
                  A126TASICod = P00B02_A126TASICod[0];
                  A1894TASIAbr = P00B02_A1894TASIAbr[0];
                  A129VouNum = P00B02_A129VouNum[0];
                  A135VouDFec = P00B02_A135VouDFec[0];
                  A2054VouDGls = P00B02_A2054VouDGls[0];
                  A2053VouDDoc = P00B02_A2053VouDDoc[0];
                  A2077VouSts = P00B02_A2077VouSts[0];
                  A131VouDMon = P00B02_A131VouDMon[0];
                  A2055VouDHab = P00B02_A2055VouDHab[0];
                  A2051VouDDeb = P00B02_A2051VouDDeb[0];
                  A2056VouDHabO = P00B02_A2056VouDHabO[0];
                  A2052VouDDebO = P00B02_A2052VouDDebO[0];
                  A130VouDSec = P00B02_A130VouDSec[0];
                  A1894TASIAbr = P00B02_A1894TASIAbr[0];
                  A2077VouSts = P00B02_A2077VouSts[0];
                  if ( StringUtil.StrCmp(A91CueCod, AV46CueCod) == 0 )
                  {
                     if ( A2077VouSts == 1 )
                     {
                        if ( A127VouAno == AV8Ano )
                        {
                           if ( A128VouMes == AV9Mes )
                           {
                              AV109VouDTipCod = A132VouDTipCod;
                              AV107VouDMon = A131VouDMon;
                              AV108TasiCod = A126TASICod;
                              AV66TasiAbr = A1894TASIAbr;
                              AV67VouNum = A129VouNum;
                              AV68VouDFec = A135VouDFec;
                              AV99VouDGls = A2054VouDGls;
                              AV69VouDDoc = A2053VouDDoc;
                              AV96SaldoS = NumberUtil.Round( (A2051VouDDeb-A2055VouDHab), 2);
                              /* Execute user subroutine: 'TIPODOCUMENTO' */
                              S131 ();
                              if ( returnInSub )
                              {
                                 pr_default.close(0);
                                 this.cleanup();
                                 if (true) return;
                              }
                              if ( ! ( AV107VouDMon == 1 ) )
                              {
                                 AV97SaldoD = NumberUtil.Round( (A2052VouDDebO-A2056VouDHabO), 2);
                              }
                              AV105TSaldoS = (decimal)(AV105TSaldoS+AV96SaldoS);
                              AV106TSaldoD = (decimal)(AV106TSaldoD+AV97SaldoD);
                              /* Execute user subroutine: 'PRINTMOVIMIENTOS' */
                              S201 ();
                              if ( returnInSub )
                              {
                                 pr_default.close(0);
                                 this.cleanup();
                                 if (true) return;
                              }
                           }
                        }
                     }
                  }
                  BRKB02 = true;
                  pr_default.readNext(0);
               }
               if ( ! (Convert.ToDecimal(0)==AV95SaldoVerCuenta) )
               {
                  /* Execute user subroutine: 'PRINTTOTALSALDOS' */
                  S191 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
               }
            }
            else
            {
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00B02_A91CueCod[0], A91CueCod) == 0 ) )
               {
                  BRKB02 = false;
                  A2074VouFec = P00B02_A2074VouFec[0];
                  A136VouReg = P00B02_A136VouReg[0];
                  A133CueCodAux = P00B02_A133CueCodAux[0];
                  A70TipACod = P00B02_A70TipACod[0];
                  n70TipACod = P00B02_n70TipACod[0];
                  A132VouDTipCod = P00B02_A132VouDTipCod[0];
                  A126TASICod = P00B02_A126TASICod[0];
                  A1894TASIAbr = P00B02_A1894TASIAbr[0];
                  A129VouNum = P00B02_A129VouNum[0];
                  A135VouDFec = P00B02_A135VouDFec[0];
                  A2054VouDGls = P00B02_A2054VouDGls[0];
                  A2053VouDDoc = P00B02_A2053VouDDoc[0];
                  A128VouMes = P00B02_A128VouMes[0];
                  A127VouAno = P00B02_A127VouAno[0];
                  A2077VouSts = P00B02_A2077VouSts[0];
                  A131VouDMon = P00B02_A131VouDMon[0];
                  A2055VouDHab = P00B02_A2055VouDHab[0];
                  A2051VouDDeb = P00B02_A2051VouDDeb[0];
                  A2056VouDHabO = P00B02_A2056VouDHabO[0];
                  A2052VouDDebO = P00B02_A2052VouDDebO[0];
                  A130VouDSec = P00B02_A130VouDSec[0];
                  A1894TASIAbr = P00B02_A1894TASIAbr[0];
                  A2074VouFec = P00B02_A2074VouFec[0];
                  A2077VouSts = P00B02_A2077VouSts[0];
                  A70TipACod = P00B02_A70TipACod[0];
                  n70TipACod = P00B02_n70TipACod[0];
                  if ( StringUtil.StrCmp(A91CueCod, AV46CueCod) == 0 )
                  {
                     if ( A2077VouSts == 1 )
                     {
                        if ( A128VouMes <= AV9Mes )
                        {
                           if ( A127VouAno == AV8Ano )
                           {
                              AV101CueCodAux = A133CueCodAux;
                              AV87TipACod = A70TipACod;
                              AV103TDebeA = 0.00m;
                              AV104THaberA = 0.00m;
                              /* Execute user subroutine: 'VALIDAAUXILIAR' */
                              S111 ();
                              if ( returnInSub )
                              {
                                 pr_default.close(0);
                                 this.cleanup();
                                 if (true) return;
                              }
                              if ( ! (Convert.ToDecimal(0)==AV100SaldoVer) )
                              {
                                 /* Execute user subroutine: 'PRINTCABECERAAUXILIAR' */
                                 S161 ();
                                 if ( returnInSub )
                                 {
                                    pr_default.close(0);
                                    this.cleanup();
                                    if (true) return;
                                 }
                              }
                              if ( ! (Convert.ToDecimal(0)==AV100SaldoVer) )
                              {
                                 while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00B02_A91CueCod[0], A91CueCod) == 0 ) && ( StringUtil.StrCmp(P00B02_A133CueCodAux[0], A133CueCodAux) == 0 ) )
                                 {
                                    BRKB02 = false;
                                    A2074VouFec = P00B02_A2074VouFec[0];
                                    A136VouReg = P00B02_A136VouReg[0];
                                    A132VouDTipCod = P00B02_A132VouDTipCod[0];
                                    A126TASICod = P00B02_A126TASICod[0];
                                    A1894TASIAbr = P00B02_A1894TASIAbr[0];
                                    A129VouNum = P00B02_A129VouNum[0];
                                    A135VouDFec = P00B02_A135VouDFec[0];
                                    A2054VouDGls = P00B02_A2054VouDGls[0];
                                    A2053VouDDoc = P00B02_A2053VouDDoc[0];
                                    A128VouMes = P00B02_A128VouMes[0];
                                    A127VouAno = P00B02_A127VouAno[0];
                                    A2077VouSts = P00B02_A2077VouSts[0];
                                    A131VouDMon = P00B02_A131VouDMon[0];
                                    A2055VouDHab = P00B02_A2055VouDHab[0];
                                    A2051VouDDeb = P00B02_A2051VouDDeb[0];
                                    A2056VouDHabO = P00B02_A2056VouDHabO[0];
                                    A2052VouDDebO = P00B02_A2052VouDDebO[0];
                                    A130VouDSec = P00B02_A130VouDSec[0];
                                    A1894TASIAbr = P00B02_A1894TASIAbr[0];
                                    A2074VouFec = P00B02_A2074VouFec[0];
                                    A2077VouSts = P00B02_A2077VouSts[0];
                                    if ( StringUtil.StrCmp(A91CueCod, AV46CueCod) == 0 )
                                    {
                                       if ( StringUtil.StrCmp(A133CueCodAux, AV101CueCodAux) == 0 )
                                       {
                                          if ( A2077VouSts == 1 )
                                          {
                                             if ( A128VouMes <= AV9Mes )
                                             {
                                                if ( A127VouAno == AV8Ano )
                                                {
                                                   AV107VouDMon = A131VouDMon;
                                                   AV108TasiCod = A126TASICod;
                                                   AV66TasiAbr = A1894TASIAbr;
                                                   AV67VouNum = A129VouNum;
                                                   AV68VouDFec = A135VouDFec;
                                                   AV99VouDGls = A2054VouDGls;
                                                   AV109VouDTipCod = A132VouDTipCod;
                                                   AV69VouDDoc = A2053VouDDoc;
                                                   AV70VouReg = A136VouReg;
                                                   AV96SaldoS = 0.00m;
                                                   AV97SaldoD = 0.00m;
                                                   /* Execute user subroutine: 'TIPODOCUMENTO' */
                                                   S131 ();
                                                   if ( returnInSub )
                                                   {
                                                      pr_default.close(0);
                                                      this.cleanup();
                                                      if (true) return;
                                                   }
                                                   while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00B02_A91CueCod[0], A91CueCod) == 0 ) && ( StringUtil.StrCmp(P00B02_A133CueCodAux[0], A133CueCodAux) == 0 ) && ( StringUtil.StrCmp(P00B02_A132VouDTipCod[0], A132VouDTipCod) == 0 ) && ( StringUtil.StrCmp(P00B02_A2053VouDDoc[0], A2053VouDDoc) == 0 ) )
                                                   {
                                                      BRKB02 = false;
                                                      A2074VouFec = P00B02_A2074VouFec[0];
                                                      A126TASICod = P00B02_A126TASICod[0];
                                                      A129VouNum = P00B02_A129VouNum[0];
                                                      A128VouMes = P00B02_A128VouMes[0];
                                                      A127VouAno = P00B02_A127VouAno[0];
                                                      A2077VouSts = P00B02_A2077VouSts[0];
                                                      A2055VouDHab = P00B02_A2055VouDHab[0];
                                                      A2051VouDDeb = P00B02_A2051VouDDeb[0];
                                                      A2056VouDHabO = P00B02_A2056VouDHabO[0];
                                                      A2052VouDDebO = P00B02_A2052VouDDebO[0];
                                                      A130VouDSec = P00B02_A130VouDSec[0];
                                                      A2074VouFec = P00B02_A2074VouFec[0];
                                                      A2077VouSts = P00B02_A2077VouSts[0];
                                                      if ( StringUtil.StrCmp(A91CueCod, AV46CueCod) == 0 )
                                                      {
                                                         if ( StringUtil.StrCmp(A132VouDTipCod, AV109VouDTipCod) == 0 )
                                                         {
                                                            if ( StringUtil.StrCmp(A2053VouDDoc, AV69VouDDoc) == 0 )
                                                            {
                                                               if ( StringUtil.StrCmp(A133CueCodAux, AV101CueCodAux) == 0 )
                                                               {
                                                                  if ( A2077VouSts == 1 )
                                                                  {
                                                                     if ( A128VouMes <= AV9Mes )
                                                                     {
                                                                        if ( A127VouAno == AV8Ano )
                                                                        {
                                                                           AV96SaldoS = (decimal)(AV96SaldoS+(NumberUtil.Round( (A2051VouDDeb-A2055VouDHab), 2)));
                                                                           if ( ! ( AV107VouDMon == 1 ) )
                                                                           {
                                                                              AV97SaldoD = (decimal)(AV97SaldoD+(NumberUtil.Round( (A2052VouDDebO-A2056VouDHabO), 2)));
                                                                           }
                                                                        }
                                                                     }
                                                                  }
                                                               }
                                                            }
                                                         }
                                                      }
                                                      BRKB02 = true;
                                                      pr_default.readNext(0);
                                                   }
                                                   AV105TSaldoS = (decimal)(AV105TSaldoS+AV96SaldoS);
                                                   AV106TSaldoD = (decimal)(AV106TSaldoD+AV97SaldoD);
                                                   AV103TDebeA = (decimal)(AV103TDebeA+AV96SaldoS);
                                                   AV104THaberA = (decimal)(AV104THaberA+AV97SaldoD);
                                                   if ( ! (Convert.ToDecimal(0)==AV96SaldoS) )
                                                   {
                                                      /* Execute user subroutine: 'PRINTMOVIMIENTOS' */
                                                      S201 ();
                                                      if ( returnInSub )
                                                      {
                                                         pr_default.close(0);
                                                         this.cleanup();
                                                         if (true) return;
                                                      }
                                                   }
                                                }
                                             }
                                          }
                                       }
                                    }
                                    if ( ! BRKB02 )
                                    {
                                       BRKB02 = true;
                                       pr_default.readNext(0);
                                    }
                                 }
                              }
                              if ( ! (Convert.ToDecimal(0)==AV100SaldoVer) )
                              {
                                 /* Execute user subroutine: 'PRINTTOTALAUXILIAR' */
                                 S171 ();
                                 if ( returnInSub )
                                 {
                                    pr_default.close(0);
                                    this.cleanup();
                                    if (true) return;
                                 }
                              }
                           }
                        }
                     }
                  }
                  if ( ! BRKB02 )
                  {
                     BRKB02 = true;
                     pr_default.readNext(0);
                  }
               }
               if ( ! (Convert.ToDecimal(0)==AV95SaldoVerCuenta) )
               {
                  /* Execute user subroutine: 'PRINTTOTALSALDOS' */
                  S191 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
               }
            }
            if ( ! BRKB02 )
            {
               BRKB02 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S141 ();
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
         /* 'VALIDAAUXILIAR' Routine */
         returnInSub = false;
         AV102TipADDsc = "";
         /* Using cursor P00B03 */
         pr_default.execute(1, new Object[] {AV87TipACod, AV101CueCodAux});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A71TipADCod = P00B03_A71TipADCod[0];
            A70TipACod = P00B03_A70TipACod[0];
            n70TipACod = P00B03_n70TipACod[0];
            A72TipADDsc = P00B03_A72TipADDsc[0];
            AV102TipADDsc = A72TipADDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV100SaldoVer = 0.00m;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV101CueCodAux ,
                                              A133CueCodAux ,
                                              A128VouMes ,
                                              AV9Mes ,
                                              A91CueCod ,
                                              AV46CueCod ,
                                              A2077VouSts ,
                                              A127VouAno ,
                                              AV8Ano } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00B04 */
         pr_default.execute(2, new Object[] {AV9Mes, AV46CueCod, AV8Ano, AV101CueCodAux});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00B04_A126TASICod[0];
            A91CueCod = P00B04_A91CueCod[0];
            A2077VouSts = P00B04_A2077VouSts[0];
            A127VouAno = P00B04_A127VouAno[0];
            A128VouMes = P00B04_A128VouMes[0];
            A133CueCodAux = P00B04_A133CueCodAux[0];
            A129VouNum = P00B04_A129VouNum[0];
            A2055VouDHab = P00B04_A2055VouDHab[0];
            A2051VouDDeb = P00B04_A2051VouDDeb[0];
            A2074VouFec = P00B04_A2074VouFec[0];
            A130VouDSec = P00B04_A130VouDSec[0];
            A2077VouSts = P00B04_A2077VouSts[0];
            A2074VouFec = P00B04_A2074VouFec[0];
            AV100SaldoVer = (decimal)(AV100SaldoVer+(NumberUtil.Round( (A2051VouDDeb-A2055VouDHab), 2)));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S121( )
      {
         /* 'VALIDASALDOCUENTA' Routine */
         returnInSub = false;
         AV95SaldoVerCuenta = 0.00m;
         /* Using cursor P00B05 */
         pr_default.execute(3, new Object[] {AV9Mes, AV46CueCod, AV8Ano});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A126TASICod = P00B05_A126TASICod[0];
            A91CueCod = P00B05_A91CueCod[0];
            A2077VouSts = P00B05_A2077VouSts[0];
            A127VouAno = P00B05_A127VouAno[0];
            A128VouMes = P00B05_A128VouMes[0];
            A129VouNum = P00B05_A129VouNum[0];
            A2055VouDHab = P00B05_A2055VouDHab[0];
            A2051VouDDeb = P00B05_A2051VouDDeb[0];
            A2074VouFec = P00B05_A2074VouFec[0];
            A130VouDSec = P00B05_A130VouDSec[0];
            A2077VouSts = P00B05_A2077VouSts[0];
            A2074VouFec = P00B05_A2074VouFec[0];
            AV95SaldoVerCuenta = (decimal)(AV95SaldoVerCuenta+(NumberUtil.Round( (A2051VouDDeb-A2055VouDHab), 2)));
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S131( )
      {
         /* 'TIPODOCUMENTO' Routine */
         returnInSub = false;
         AV98TipAbr = "";
         /* Using cursor P00B06 */
         pr_default.execute(4, new Object[] {AV109VouDTipCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A149TipCod = P00B06_A149TipCod[0];
            A306TipAbr = P00B06_A306TipAbr[0];
            AV98TipAbr = StringUtil.Trim( A306TipAbr);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      protected void S141( )
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

      protected void S151( )
      {
         /* 'PRINTSALDOINICIAL' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV46CueCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV47CueDsc);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S161( )
      {
         /* 'PRINTCABECERAAUXILIAR' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV101CueCodAux);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV102TipADDsc);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S171( )
      {
         /* 'PRINTTOTALAUXILIAR' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = "Total Auxiliar "+StringUtil.Trim( AV101CueCodAux);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV103TDebeA);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV104THaberA);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S181( )
      {
         /* 'PRINTSALDOANTERIOR' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = "Saldo Anterior";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV96SaldoS);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV97SaldoD);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S191( )
      {
         /* 'PRINTTOTALSALDOS' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = "Total Cuenta "+StringUtil.Trim( AV46CueCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV105TSaldoS);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV106TSaldoD);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S201( )
      {
         /* 'PRINTMOVIMIENTOS' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV98TipAbr);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV69VouDDoc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV70VouReg);
         GXt_dtime2 = DateTimeUtil.ResetTime( AV68VouDFec ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime2;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV99VouDGls);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV96SaldoS);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV97SaldoD);
         AV14CellRow = (int)(AV14CellRow+1);
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
         AV94cAno = "";
         AV42cMes = "";
         GXt_char1 = "";
         AV39Periodo = "";
         scmdbuf = "";
         A91CueCod = "";
         A133CueCodAux = "";
         P00B02_A2074VouFec = new DateTime[] {DateTime.MinValue} ;
         P00B02_A136VouReg = new string[] {""} ;
         P00B02_A133CueCodAux = new string[] {""} ;
         P00B02_A70TipACod = new int[1] ;
         P00B02_n70TipACod = new bool[] {false} ;
         P00B02_A132VouDTipCod = new string[] {""} ;
         P00B02_A126TASICod = new int[1] ;
         P00B02_A1894TASIAbr = new string[] {""} ;
         P00B02_A129VouNum = new string[] {""} ;
         P00B02_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00B02_A2054VouDGls = new string[] {""} ;
         P00B02_A2053VouDDoc = new string[] {""} ;
         P00B02_A128VouMes = new short[1] ;
         P00B02_A127VouAno = new short[1] ;
         P00B02_A2077VouSts = new short[1] ;
         P00B02_A91CueCod = new string[] {""} ;
         P00B02_A131VouDMon = new int[1] ;
         P00B02_A2055VouDHab = new decimal[1] ;
         P00B02_A2051VouDDeb = new decimal[1] ;
         P00B02_A2056VouDHabO = new decimal[1] ;
         P00B02_A2052VouDDebO = new decimal[1] ;
         P00B02_A860CueDsc = new string[] {""} ;
         P00B02_A130VouDSec = new int[1] ;
         A2074VouFec = DateTime.MinValue;
         A136VouReg = "";
         A132VouDTipCod = "";
         A1894TASIAbr = "";
         A129VouNum = "";
         A135VouDFec = DateTime.MinValue;
         A2054VouDGls = "";
         A2053VouDDoc = "";
         A860CueDsc = "";
         AV46CueCod = "";
         AV47CueDsc = "";
         AV109VouDTipCod = "";
         AV66TasiAbr = "";
         AV67VouNum = "";
         AV68VouDFec = DateTime.MinValue;
         AV99VouDGls = "";
         AV69VouDDoc = "";
         AV101CueCodAux = "";
         AV70VouReg = "";
         AV102TipADDsc = "";
         P00B03_A71TipADCod = new string[] {""} ;
         P00B03_A70TipACod = new int[1] ;
         P00B03_n70TipACod = new bool[] {false} ;
         P00B03_A72TipADDsc = new string[] {""} ;
         A71TipADCod = "";
         A72TipADDsc = "";
         P00B04_A126TASICod = new int[1] ;
         P00B04_A91CueCod = new string[] {""} ;
         P00B04_A2077VouSts = new short[1] ;
         P00B04_A127VouAno = new short[1] ;
         P00B04_A128VouMes = new short[1] ;
         P00B04_A133CueCodAux = new string[] {""} ;
         P00B04_A129VouNum = new string[] {""} ;
         P00B04_A2055VouDHab = new decimal[1] ;
         P00B04_A2051VouDDeb = new decimal[1] ;
         P00B04_A2074VouFec = new DateTime[] {DateTime.MinValue} ;
         P00B04_A130VouDSec = new int[1] ;
         P00B05_A126TASICod = new int[1] ;
         P00B05_A91CueCod = new string[] {""} ;
         P00B05_A2077VouSts = new short[1] ;
         P00B05_A127VouAno = new short[1] ;
         P00B05_A128VouMes = new short[1] ;
         P00B05_A129VouNum = new string[] {""} ;
         P00B05_A2055VouDHab = new decimal[1] ;
         P00B05_A2051VouDDeb = new decimal[1] ;
         P00B05_A2074VouFec = new DateTime[] {DateTime.MinValue} ;
         P00B05_A130VouDSec = new int[1] ;
         AV98TipAbr = "";
         P00B06_A149TipCod = new string[] {""} ;
         P00B06_A306TipAbr = new string[] {""} ;
         A149TipCod = "";
         A306TipAbr = "";
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_analisiscuentasexcel__default(),
            new Object[][] {
                new Object[] {
               P00B02_A2074VouFec, P00B02_A136VouReg, P00B02_A133CueCodAux, P00B02_A70TipACod, P00B02_n70TipACod, P00B02_A132VouDTipCod, P00B02_A126TASICod, P00B02_A1894TASIAbr, P00B02_A129VouNum, P00B02_A135VouDFec,
               P00B02_A2054VouDGls, P00B02_A2053VouDDoc, P00B02_A128VouMes, P00B02_A127VouAno, P00B02_A2077VouSts, P00B02_A91CueCod, P00B02_A131VouDMon, P00B02_A2055VouDHab, P00B02_A2051VouDDeb, P00B02_A2056VouDHabO,
               P00B02_A2052VouDDebO, P00B02_A860CueDsc, P00B02_A130VouDSec
               }
               , new Object[] {
               P00B03_A71TipADCod, P00B03_A70TipACod, P00B03_A72TipADDsc
               }
               , new Object[] {
               P00B04_A126TASICod, P00B04_A91CueCod, P00B04_A2077VouSts, P00B04_A127VouAno, P00B04_A128VouMes, P00B04_A133CueCodAux, P00B04_A129VouNum, P00B04_A2055VouDHab, P00B04_A2051VouDDeb, P00B04_A2074VouFec,
               P00B04_A130VouDSec
               }
               , new Object[] {
               P00B05_A126TASICod, P00B05_A91CueCod, P00B05_A2077VouSts, P00B05_A127VouAno, P00B05_A128VouMes, P00B05_A129VouNum, P00B05_A2055VouDHab, P00B05_A2051VouDDeb, P00B05_A2074VouFec, P00B05_A130VouDSec
               }
               , new Object[] {
               P00B06_A149TipCod, P00B06_A306TipAbr
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8Ano ;
      private short AV9Mes ;
      private short A2077VouSts ;
      private short A127VouAno ;
      private short A128VouMes ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A70TipACod ;
      private int A126TASICod ;
      private int A131VouDMon ;
      private int A130VouDSec ;
      private int AV87TipACod ;
      private int AV107VouDMon ;
      private int AV108TasiCod ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private decimal A2056VouDHabO ;
      private decimal A2052VouDDebO ;
      private decimal AV105TSaldoS ;
      private decimal AV106TSaldoD ;
      private decimal AV95SaldoVerCuenta ;
      private decimal AV96SaldoS ;
      private decimal AV97SaldoD ;
      private decimal AV103TDebeA ;
      private decimal AV104THaberA ;
      private decimal AV100SaldoVer ;
      private string AV90CueCod1 ;
      private string AV91CueCod2 ;
      private string AV92cCueCodAux ;
      private string AV93Tipo ;
      private string AV38Path ;
      private string AV94cAno ;
      private string AV42cMes ;
      private string GXt_char1 ;
      private string AV39Periodo ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A133CueCodAux ;
      private string A136VouReg ;
      private string A132VouDTipCod ;
      private string A1894TASIAbr ;
      private string A129VouNum ;
      private string A2054VouDGls ;
      private string A2053VouDDoc ;
      private string A860CueDsc ;
      private string AV46CueCod ;
      private string AV47CueDsc ;
      private string AV109VouDTipCod ;
      private string AV66TasiAbr ;
      private string AV67VouNum ;
      private string AV99VouDGls ;
      private string AV69VouDDoc ;
      private string AV101CueCodAux ;
      private string AV70VouReg ;
      private string AV102TipADDsc ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private string AV98TipAbr ;
      private string A149TipCod ;
      private string A306TipAbr ;
      private DateTime GXt_dtime2 ;
      private DateTime AV88FDesde ;
      private DateTime AV89Fhasta ;
      private DateTime A2074VouFec ;
      private DateTime A135VouDFec ;
      private DateTime AV68VouDFec ;
      private bool returnInSub ;
      private bool BRKB02 ;
      private bool n70TipACod ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV41FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private DateTime aP2_FDesde ;
      private DateTime aP3_Fhasta ;
      private string aP4_CueCod1 ;
      private string aP5_CueCod2 ;
      private string aP6_cCueCodAux ;
      private string aP7_Tipo ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00B02_A2074VouFec ;
      private string[] P00B02_A136VouReg ;
      private string[] P00B02_A133CueCodAux ;
      private int[] P00B02_A70TipACod ;
      private bool[] P00B02_n70TipACod ;
      private string[] P00B02_A132VouDTipCod ;
      private int[] P00B02_A126TASICod ;
      private string[] P00B02_A1894TASIAbr ;
      private string[] P00B02_A129VouNum ;
      private DateTime[] P00B02_A135VouDFec ;
      private string[] P00B02_A2054VouDGls ;
      private string[] P00B02_A2053VouDDoc ;
      private short[] P00B02_A128VouMes ;
      private short[] P00B02_A127VouAno ;
      private short[] P00B02_A2077VouSts ;
      private string[] P00B02_A91CueCod ;
      private int[] P00B02_A131VouDMon ;
      private decimal[] P00B02_A2055VouDHab ;
      private decimal[] P00B02_A2051VouDDeb ;
      private decimal[] P00B02_A2056VouDHabO ;
      private decimal[] P00B02_A2052VouDDebO ;
      private string[] P00B02_A860CueDsc ;
      private int[] P00B02_A130VouDSec ;
      private string[] P00B03_A71TipADCod ;
      private int[] P00B03_A70TipACod ;
      private bool[] P00B03_n70TipACod ;
      private string[] P00B03_A72TipADDsc ;
      private int[] P00B04_A126TASICod ;
      private string[] P00B04_A91CueCod ;
      private short[] P00B04_A2077VouSts ;
      private short[] P00B04_A127VouAno ;
      private short[] P00B04_A128VouMes ;
      private string[] P00B04_A133CueCodAux ;
      private string[] P00B04_A129VouNum ;
      private decimal[] P00B04_A2055VouDHab ;
      private decimal[] P00B04_A2051VouDDeb ;
      private DateTime[] P00B04_A2074VouFec ;
      private int[] P00B04_A130VouDSec ;
      private int[] P00B05_A126TASICod ;
      private string[] P00B05_A91CueCod ;
      private short[] P00B05_A2077VouSts ;
      private short[] P00B05_A127VouAno ;
      private short[] P00B05_A128VouMes ;
      private string[] P00B05_A129VouNum ;
      private decimal[] P00B05_A2055VouDHab ;
      private decimal[] P00B05_A2051VouDDeb ;
      private DateTime[] P00B05_A2074VouFec ;
      private int[] P00B05_A130VouDSec ;
      private string[] P00B06_A149TipCod ;
      private string[] P00B06_A306TipAbr ;
      private string aP8_Filename ;
      private string aP9_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV37Archivo ;
   }

   public class r_analisiscuentasexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B02( IGxContext context ,
                                             string AV90CueCod1 ,
                                             string AV91CueCod2 ,
                                             string AV92cCueCodAux ,
                                             string A91CueCod ,
                                             string A133CueCodAux ,
                                             short A2077VouSts ,
                                             short A127VouAno ,
                                             short AV8Ano )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T3.[VouFec], T1.[VouReg], T1.[CueCodAux], T4.[TipACod], T1.[VouDTipCod], T1.[TASICod], T2.[TASIAbr], T1.[VouNum], T1.[VouDFec], T1.[VouDGls], T1.[VouDDoc], T1.[VouMes], T1.[VouAno], T3.[VouSts], T1.[CueCod], T1.[VouDMon], T1.[VouDHab], T1.[VouDDeb], T1.[VouDHabO], T1.[VouDDebO], T4.[CueDsc], T1.[VouDSec] FROM ((([CBVOUCHERDET] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum]) INNER JOIN [CBPLANCUENTA] T4 ON T4.[CueCod] = T1.[CueCod])";
         AddWhere(sWhereString, "(T3.[VouSts] = 1)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV8Ano)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90CueCod1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] >= @AV90CueCod1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91CueCod2)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] <= @AV91CueCod2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92cCueCodAux)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV92cCueCodAux)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[CueCodAux], T1.[VouDTipCod], T1.[VouDDoc], T3.[VouFec]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00B04( IGxContext context ,
                                             string AV101CueCodAux ,
                                             string A133CueCodAux ,
                                             short A128VouMes ,
                                             short AV9Mes ,
                                             string A91CueCod ,
                                             string AV46CueCod ,
                                             short A2077VouSts ,
                                             short A127VouAno ,
                                             short AV8Ano )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[4];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T1.[CueCod], T2.[VouSts], T1.[VouAno], T1.[VouMes], T1.[CueCodAux], T1.[VouNum], T1.[VouDHab], T1.[VouDDeb], T2.[VouFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouMes] <= @AV9Mes)");
         AddWhere(sWhereString, "(T1.[CueCod] = @AV46CueCod)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV8Ano)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101CueCodAux)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV101CueCodAux)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[VouFec]";
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
                     return conditional_P00B02(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] );
               case 2 :
                     return conditional_P00B04(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00B03;
          prmP00B03 = new Object[] {
          new ParDef("@AV87TipACod",GXType.Int32,6,0) ,
          new ParDef("@AV101CueCodAux",GXType.NChar,20,0)
          };
          Object[] prmP00B05;
          prmP00B05 = new Object[] {
          new ParDef("@AV9Mes",GXType.Int16,2,0) ,
          new ParDef("@AV46CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV8Ano",GXType.Int16,4,0)
          };
          Object[] prmP00B06;
          prmP00B06 = new Object[] {
          new ParDef("@AV109VouDTipCod",GXType.NChar,3,0)
          };
          Object[] prmP00B02;
          prmP00B02 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV90CueCod1",GXType.Char,15,0) ,
          new ParDef("@AV91CueCod2",GXType.Char,15,0) ,
          new ParDef("@AV92cCueCodAux",GXType.NChar,20,0)
          };
          Object[] prmP00B04;
          prmP00B04 = new Object[] {
          new ParDef("@AV9Mes",GXType.Int16,2,0) ,
          new ParDef("@AV46CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV101CueCodAux",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B02,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B03", "SELECT [TipADCod], [TipACod], [TipADDsc] FROM [CBAUXILIARES] WHERE [TipACod] = @AV87TipACod and [TipADCod] = @AV101CueCodAux ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B03,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00B04", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B04,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00B05", "SELECT T1.[TASICod], T1.[CueCod], T2.[VouSts], T1.[VouAno], T1.[VouMes], T1.[VouNum], T1.[VouDHab], T1.[VouDDeb], T2.[VouFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouMes] <= @AV9Mes) AND (T1.[CueCod] = @AV46CueCod) AND (T2.[VouSts] = 1) AND (T1.[VouAno] = @AV8Ano) ORDER BY T2.[VouFec] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B05,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00B06", "SELECT [TipCod], [TipAbr] FROM [CTIPDOC] WHERE [TipCod] = @AV109VouDTipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B06,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 5);
                ((string[]) buf[8])[0] = rslt.getString(8, 10);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((short[]) buf[12])[0] = rslt.getShort(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 15);
                ((int[]) buf[16])[0] = rslt.getInt(16);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 100);
                ((int[]) buf[22])[0] = rslt.getInt(22);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                return;
       }
    }

 }

}
