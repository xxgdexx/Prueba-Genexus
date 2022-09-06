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
   public class r_libromayorgeneralbimonedaexcel : GXProcedure
   {
      public r_libromayorgeneralbimonedaexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_libromayorgeneralbimonedaexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FDesde ,
                           ref DateTime aP1_FHasta ,
                           ref string aP2_cCosto ,
                           ref string aP3_cCuenta1 ,
                           ref string aP4_cCuenta2 ,
                           ref string aP5_CueCodAux ,
                           out string aP6_Filename ,
                           out string aP7_ErrorMessage )
      {
         this.AV88FDesde = aP0_FDesde;
         this.AV89FHasta = aP1_FHasta;
         this.AV43cCosto = aP2_cCosto;
         this.AV44cCuenta1 = aP3_cCuenta1;
         this.AV45cCuenta2 = aP4_cCuenta2;
         this.AV90CueCodAux = aP5_CueCodAux;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_FDesde=this.AV88FDesde;
         aP1_FHasta=this.AV89FHasta;
         aP2_cCosto=this.AV43cCosto;
         aP3_cCuenta1=this.AV44cCuenta1;
         aP4_cCuenta2=this.AV45cCuenta2;
         aP5_CueCodAux=this.AV90CueCodAux;
         aP6_Filename=this.AV10Filename;
         aP7_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref DateTime aP0_FDesde ,
                                ref DateTime aP1_FHasta ,
                                ref string aP2_cCosto ,
                                ref string aP3_cCuenta1 ,
                                ref string aP4_cCuenta2 ,
                                ref string aP5_CueCodAux ,
                                out string aP6_Filename )
      {
         execute(ref aP0_FDesde, ref aP1_FHasta, ref aP2_cCosto, ref aP3_cCuenta1, ref aP4_cCuenta2, ref aP5_CueCodAux, out aP6_Filename, out aP7_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref DateTime aP0_FDesde ,
                                 ref DateTime aP1_FHasta ,
                                 ref string aP2_cCosto ,
                                 ref string aP3_cCuenta1 ,
                                 ref string aP4_cCuenta2 ,
                                 ref string aP5_CueCodAux ,
                                 out string aP6_Filename ,
                                 out string aP7_ErrorMessage )
      {
         r_libromayorgeneralbimonedaexcel objr_libromayorgeneralbimonedaexcel;
         objr_libromayorgeneralbimonedaexcel = new r_libromayorgeneralbimonedaexcel();
         objr_libromayorgeneralbimonedaexcel.AV88FDesde = aP0_FDesde;
         objr_libromayorgeneralbimonedaexcel.AV89FHasta = aP1_FHasta;
         objr_libromayorgeneralbimonedaexcel.AV43cCosto = aP2_cCosto;
         objr_libromayorgeneralbimonedaexcel.AV44cCuenta1 = aP3_cCuenta1;
         objr_libromayorgeneralbimonedaexcel.AV45cCuenta2 = aP4_cCuenta2;
         objr_libromayorgeneralbimonedaexcel.AV90CueCodAux = aP5_CueCodAux;
         objr_libromayorgeneralbimonedaexcel.AV10Filename = "" ;
         objr_libromayorgeneralbimonedaexcel.AV11ErrorMessage = "" ;
         objr_libromayorgeneralbimonedaexcel.context.SetSubmitInitialConfig(context);
         objr_libromayorgeneralbimonedaexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_libromayorgeneralbimonedaexcel);
         aP0_FDesde=this.AV88FDesde;
         aP1_FHasta=this.AV89FHasta;
         aP2_cCosto=this.AV43cCosto;
         aP3_cCuenta1=this.AV44cCuenta1;
         aP4_cCuenta2=this.AV45cCuenta2;
         aP5_CueCodAux=this.AV90CueCodAux;
         aP6_Filename=this.AV10Filename;
         aP7_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_libromayorgeneralbimonedaexcel)stateInfo).executePrivate();
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
         AV37Archivo.Source = "Excel/PlantillaLibroMayorGeneralAnalitico.xlsx";
         AV38Path = AV37Archivo.GetPath();
         AV41FilenameOrigen = StringUtil.Trim( AV38Path) + "\\PlantillaLibroMayorGeneralAnalitico.xlsx";
         AV10Filename = "Excel/LibroMayorBimonedaExcel" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV41FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S191 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV39Periodo = "Del : " + context.localUtil.DToC( AV88FDesde, 2, "/") + "   Al  " + context.localUtil.DToC( AV89FHasta, 2, "/");
         AV14CellRow = 3;
         AV15FirstColumn = 4;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV39Periodo);
         AV14CellRow = 6;
         AV15FirstColumn = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44cCuenta1 ,
                                              AV90CueCodAux ,
                                              A91CueCod ,
                                              A133CueCodAux ,
                                              A135VouDFec ,
                                              AV88FDesde ,
                                              AV89FHasta ,
                                              A2077VouSts } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BI2 */
         pr_default.execute(0, new Object[] {AV88FDesde, AV89FHasta, AV44cCuenta1, AV90CueCodAux});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKBI2 = false;
            A127VouAno = P00BI2_A127VouAno[0];
            A128VouMes = P00BI2_A128VouMes[0];
            A126TASICod = P00BI2_A126TASICod[0];
            A129VouNum = P00BI2_A129VouNum[0];
            A133CueCodAux = P00BI2_A133CueCodAux[0];
            A91CueCod = P00BI2_A91CueCod[0];
            A2077VouSts = P00BI2_A2077VouSts[0];
            A135VouDFec = P00BI2_A135VouDFec[0];
            A860CueDsc = P00BI2_A860CueDsc[0];
            A70TipACod = P00BI2_A70TipACod[0];
            n70TipACod = P00BI2_n70TipACod[0];
            A130VouDSec = P00BI2_A130VouDSec[0];
            A2077VouSts = P00BI2_A2077VouSts[0];
            A860CueDsc = P00BI2_A860CueDsc[0];
            A70TipACod = P00BI2_A70TipACod[0];
            n70TipACod = P00BI2_n70TipACod[0];
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BI2_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRKBI2 = false;
               A127VouAno = P00BI2_A127VouAno[0];
               A128VouMes = P00BI2_A128VouMes[0];
               A126TASICod = P00BI2_A126TASICod[0];
               A129VouNum = P00BI2_A129VouNum[0];
               A133CueCodAux = P00BI2_A133CueCodAux[0];
               A130VouDSec = P00BI2_A130VouDSec[0];
               BRKBI2 = true;
               pr_default.readNext(0);
            }
            AV46CueCod = A91CueCod;
            AV47CueDsc = A860CueDsc;
            AV87TipACod = A70TipACod;
            AV91TDebeMN = 0.00m;
            AV92ThaberMN = 0.00m;
            AV54TDebeME = 0.00m;
            AV55THaberME = 0.00m;
            /* Execute user subroutine: 'PRINTAGRUPACUENTA' */
            S201 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'AUXILIAR' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTTOTALCUENTA' */
            S211 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( ! BRKBI2 )
            {
               BRKBI2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S191 ();
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
         /* 'AUXILIAR' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV90CueCodAux ,
                                              A133CueCodAux ,
                                              A135VouDFec ,
                                              AV88FDesde ,
                                              AV89FHasta ,
                                              A91CueCod ,
                                              AV46CueCod ,
                                              A2077VouSts } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BI3 */
         pr_default.execute(1, new Object[] {AV88FDesde, AV89FHasta, AV46CueCod, AV90CueCodAux});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKBI4 = false;
            A127VouAno = P00BI3_A127VouAno[0];
            A128VouMes = P00BI3_A128VouMes[0];
            A126TASICod = P00BI3_A126TASICod[0];
            A129VouNum = P00BI3_A129VouNum[0];
            A134CueAuxCod = P00BI3_A134CueAuxCod[0];
            A133CueCodAux = P00BI3_A133CueCodAux[0];
            A2077VouSts = P00BI3_A2077VouSts[0];
            A91CueCod = P00BI3_A91CueCod[0];
            A135VouDFec = P00BI3_A135VouDFec[0];
            A130VouDSec = P00BI3_A130VouDSec[0];
            A2077VouSts = P00BI3_A2077VouSts[0];
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00BI3_A133CueCodAux[0], A133CueCodAux) == 0 ) )
            {
               BRKBI4 = false;
               A127VouAno = P00BI3_A127VouAno[0];
               A128VouMes = P00BI3_A128VouMes[0];
               A126TASICod = P00BI3_A126TASICod[0];
               A129VouNum = P00BI3_A129VouNum[0];
               A134CueAuxCod = P00BI3_A134CueAuxCod[0];
               A130VouDSec = P00BI3_A130VouDSec[0];
               BRKBI4 = true;
               pr_default.readNext(1);
            }
            AV64CueDAxu = A133CueCodAux;
            AV93TADebeMN = 0.00m;
            AV106TAHaberMN = 0.00m;
            AV94TADebeME = 0.00m;
            AV95TAHaberME = 0.00m;
            /* Execute user subroutine: 'NOMBREAUXILIAR' */
            S124 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64CueDAxu)) )
            {
               /* Execute user subroutine: 'PRINTAGRUPAAUXILIAR' */
               S134 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
            }
            /* Execute user subroutine: 'DOCUMENTOS' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64CueDAxu)) )
            {
               /* Execute user subroutine: 'PRINTTOTALAUXILIAR' */
               S154 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
            }
            AV91TDebeMN = (decimal)(AV91TDebeMN+AV93TADebeMN);
            AV92ThaberMN = (decimal)(AV92ThaberMN+AV106TAHaberMN);
            AV54TDebeME = (decimal)(AV54TDebeME+AV94TADebeME);
            AV55THaberME = (decimal)(AV55THaberME+AV95TAHaberME);
            if ( ! BRKBI4 )
            {
               BRKBI4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S144( )
      {
         /* 'DOCUMENTOS' Routine */
         returnInSub = false;
         /* Using cursor P00BI4 */
         pr_default.execute(2, new Object[] {AV88FDesde, AV89FHasta, AV64CueDAxu, AV46CueCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKBI6 = false;
            A127VouAno = P00BI4_A127VouAno[0];
            A128VouMes = P00BI4_A128VouMes[0];
            A126TASICod = P00BI4_A126TASICod[0];
            A129VouNum = P00BI4_A129VouNum[0];
            A133CueCodAux = P00BI4_A133CueCodAux[0];
            A91CueCod = P00BI4_A91CueCod[0];
            A2077VouSts = P00BI4_A2077VouSts[0];
            A136VouReg = P00BI4_A136VouReg[0];
            A2053VouDDoc = P00BI4_A2053VouDDoc[0];
            A132VouDTipCod = P00BI4_A132VouDTipCod[0];
            A134CueAuxCod = P00BI4_A134CueAuxCod[0];
            A135VouDFec = P00BI4_A135VouDFec[0];
            A130VouDSec = P00BI4_A130VouDSec[0];
            A2077VouSts = P00BI4_A2077VouSts[0];
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00BI4_A134CueAuxCod[0], A134CueAuxCod) == 0 ) && ( StringUtil.StrCmp(P00BI4_A133CueCodAux[0], A133CueCodAux) == 0 ) && ( StringUtil.StrCmp(P00BI4_A132VouDTipCod[0], A132VouDTipCod) == 0 ) && ( StringUtil.StrCmp(P00BI4_A2053VouDDoc[0], A2053VouDDoc) == 0 ) )
            {
               BRKBI6 = false;
               A127VouAno = P00BI4_A127VouAno[0];
               A128VouMes = P00BI4_A128VouMes[0];
               A126TASICod = P00BI4_A126TASICod[0];
               A129VouNum = P00BI4_A129VouNum[0];
               A136VouReg = P00BI4_A136VouReg[0];
               A130VouDSec = P00BI4_A130VouDSec[0];
               BRKBI6 = true;
               pr_default.readNext(2);
            }
            AV100VouDTipCod = A132VouDTipCod;
            AV69VouDDoc = A2053VouDDoc;
            AV90CueCodAux = A133CueCodAux;
            AV96TDDebeMN = 0.00m;
            AV97TDHaberMN = 0.00m;
            AV98TDDebeME = 0.00m;
            AV99TDHaberME = 0.00m;
            /* Execute user subroutine: 'DETALLE' */
            S166 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTDOCUMENTO' */
            S176 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            AV93TADebeMN = (decimal)(AV93TADebeMN+AV96TDDebeMN);
            AV106TAHaberMN = (decimal)(AV106TAHaberMN+AV97TDHaberMN);
            AV94TADebeME = (decimal)(AV94TADebeME+AV98TDDebeME);
            AV95TAHaberME = (decimal)(AV95TAHaberME+AV99TDHaberME);
            if ( ! BRKBI6 )
            {
               BRKBI6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S166( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         /* Using cursor P00BI5 */
         pr_default.execute(3, new Object[] {AV46CueCod, AV64CueDAxu, AV88FDesde, AV89FHasta, AV100VouDTipCod, AV69VouDDoc});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A127VouAno = P00BI5_A127VouAno[0];
            A128VouMes = P00BI5_A128VouMes[0];
            A126TASICod = P00BI5_A126TASICod[0];
            A129VouNum = P00BI5_A129VouNum[0];
            A2077VouSts = P00BI5_A2077VouSts[0];
            A2053VouDDoc = P00BI5_A2053VouDDoc[0];
            A132VouDTipCod = P00BI5_A132VouDTipCod[0];
            A91CueCod = P00BI5_A91CueCod[0];
            A133CueCodAux = P00BI5_A133CueCodAux[0];
            A135VouDFec = P00BI5_A135VouDFec[0];
            A136VouReg = P00BI5_A136VouReg[0];
            A2069VouDTcmb = P00BI5_A2069VouDTcmb[0];
            A2051VouDDeb = P00BI5_A2051VouDDeb[0];
            A2055VouDHab = P00BI5_A2055VouDHab[0];
            A2052VouDDebO = P00BI5_A2052VouDDebO[0];
            A2056VouDHabO = P00BI5_A2056VouDHabO[0];
            A2054VouDGls = P00BI5_A2054VouDGls[0];
            A131VouDMon = P00BI5_A131VouDMon[0];
            A130VouDSec = P00BI5_A130VouDSec[0];
            A2077VouSts = P00BI5_A2077VouSts[0];
            AV68VouDFec = A135VouDFec;
            AV70VouReg = A136VouReg;
            AV103VouDTCmb = A2069VouDTcmb;
            AV71VouDDeb = A2051VouDDeb;
            AV72VouDHab = A2055VouDHab;
            AV101VouDDebE = ((AV104VouDMon>1) ? A2052VouDDebO : NumberUtil.Round( AV71VouDDeb/ (decimal)(A2069VouDTcmb), 2));
            AV102VouDHabE = ((AV104VouDMon>1) ? A2056VouDHabO : NumberUtil.Round( AV72VouDHab/ (decimal)(A2069VouDTcmb), 2));
            AV105VouDGls = A2054VouDGls;
            AV104VouDMon = A131VouDMon;
            /* Execute user subroutine: 'PRINTMOVIMIENTOS' */
            S188 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV96TDDebeMN = (decimal)(AV96TDDebeMN+AV71VouDDeb);
            AV97TDHaberMN = (decimal)(AV97TDHaberMN+AV72VouDHab);
            AV98TDDebeME = (decimal)(AV98TDDebeME+AV101VouDDebE);
            AV99TDHaberME = (decimal)(AV99TDHaberME+AV102VouDHabE);
            AV107TDSaldoMN = (decimal)(AV96TDDebeMN-AV97TDHaberMN);
            AV108TDSaldoME = (decimal)(AV98TDDebeME-AV99TDHaberME);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S124( )
      {
         /* 'NOMBREAUXILIAR' Routine */
         returnInSub = false;
         AV118GXLvl164 = 0;
         /* Using cursor P00BI6 */
         pr_default.execute(4, new Object[] {AV87TipACod, AV64CueDAxu});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A71TipADCod = P00BI6_A71TipADCod[0];
            A70TipACod = P00BI6_A70TipACod[0];
            n70TipACod = P00BI6_n70TipACod[0];
            A72TipADDsc = P00BI6_A72TipADDsc[0];
            AV118GXLvl164 = 1;
            AV65CueDAxuDsc = A72TipADDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         if ( AV118GXLvl164 == 0 )
         {
            AV65CueDAxuDsc = "SIN AUXILIAR";
         }
      }

      protected void S191( )
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

      protected void S201( )
      {
         /* 'PRINTAGRUPACUENTA' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV46CueCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV47CueDsc);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S134( )
      {
         /* 'PRINTAGRUPAAUXILIAR' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV64CueDAxu);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV65CueDAxuDsc);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S188( )
      {
         /* 'PRINTMOVIMIENTOS' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = AV46CueCod;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV68VouDFec ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = AV70VouReg;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = AV100VouDTipCod;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = AV69VouDDoc;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV71VouDDeb);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV72VouDHab);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV103VouDTCmb);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV101VouDDebE);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV102VouDHabE);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Text = StringUtil.Trim( AV73Glosa);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S176( )
      {
         /* 'PRINTDOCUMENTO' Routine */
         returnInSub = false;
         AV14CellRow = (int)(AV14CellRow+1);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV69VouDDoc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV96TDDebeMN);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV97TDHaberMN);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV98TDDebeME);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV99TDHaberME);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S154( )
      {
         /* 'PRINTTOTALAUXILIAR' Routine */
         returnInSub = false;
         AV14CellRow = (int)(AV14CellRow+1);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV64CueDAxu);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV93TADebeMN);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV106TAHaberMN);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV94TADebeME);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV95TAHaberME);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S211( )
      {
         /* 'PRINTTOTALCUENTA' Routine */
         returnInSub = false;
         AV14CellRow = (int)(AV14CellRow+1);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV46CueCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV91TDebeMN);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV92ThaberMN);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV54TDebeME);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV55THaberME);
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
         AV39Periodo = "";
         scmdbuf = "";
         A91CueCod = "";
         A133CueCodAux = "";
         A135VouDFec = DateTime.MinValue;
         P00BI2_A127VouAno = new short[1] ;
         P00BI2_A128VouMes = new short[1] ;
         P00BI2_A126TASICod = new int[1] ;
         P00BI2_A129VouNum = new string[] {""} ;
         P00BI2_A133CueCodAux = new string[] {""} ;
         P00BI2_A91CueCod = new string[] {""} ;
         P00BI2_A2077VouSts = new short[1] ;
         P00BI2_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BI2_A860CueDsc = new string[] {""} ;
         P00BI2_A70TipACod = new int[1] ;
         P00BI2_n70TipACod = new bool[] {false} ;
         P00BI2_A130VouDSec = new int[1] ;
         A129VouNum = "";
         A860CueDsc = "";
         AV46CueCod = "";
         AV47CueDsc = "";
         P00BI3_A127VouAno = new short[1] ;
         P00BI3_A128VouMes = new short[1] ;
         P00BI3_A126TASICod = new int[1] ;
         P00BI3_A129VouNum = new string[] {""} ;
         P00BI3_A134CueAuxCod = new string[] {""} ;
         P00BI3_A133CueCodAux = new string[] {""} ;
         P00BI3_A2077VouSts = new short[1] ;
         P00BI3_A91CueCod = new string[] {""} ;
         P00BI3_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BI3_A130VouDSec = new int[1] ;
         A134CueAuxCod = "";
         AV64CueDAxu = "";
         P00BI4_A127VouAno = new short[1] ;
         P00BI4_A128VouMes = new short[1] ;
         P00BI4_A126TASICod = new int[1] ;
         P00BI4_A129VouNum = new string[] {""} ;
         P00BI4_A133CueCodAux = new string[] {""} ;
         P00BI4_A91CueCod = new string[] {""} ;
         P00BI4_A2077VouSts = new short[1] ;
         P00BI4_A136VouReg = new string[] {""} ;
         P00BI4_A2053VouDDoc = new string[] {""} ;
         P00BI4_A132VouDTipCod = new string[] {""} ;
         P00BI4_A134CueAuxCod = new string[] {""} ;
         P00BI4_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BI4_A130VouDSec = new int[1] ;
         A136VouReg = "";
         A2053VouDDoc = "";
         A132VouDTipCod = "";
         AV100VouDTipCod = "";
         AV69VouDDoc = "";
         P00BI5_A127VouAno = new short[1] ;
         P00BI5_A128VouMes = new short[1] ;
         P00BI5_A126TASICod = new int[1] ;
         P00BI5_A129VouNum = new string[] {""} ;
         P00BI5_A2077VouSts = new short[1] ;
         P00BI5_A2053VouDDoc = new string[] {""} ;
         P00BI5_A132VouDTipCod = new string[] {""} ;
         P00BI5_A91CueCod = new string[] {""} ;
         P00BI5_A133CueCodAux = new string[] {""} ;
         P00BI5_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BI5_A136VouReg = new string[] {""} ;
         P00BI5_A2069VouDTcmb = new decimal[1] ;
         P00BI5_A2051VouDDeb = new decimal[1] ;
         P00BI5_A2055VouDHab = new decimal[1] ;
         P00BI5_A2052VouDDebO = new decimal[1] ;
         P00BI5_A2056VouDHabO = new decimal[1] ;
         P00BI5_A2054VouDGls = new string[] {""} ;
         P00BI5_A131VouDMon = new int[1] ;
         P00BI5_A130VouDSec = new int[1] ;
         A2054VouDGls = "";
         AV68VouDFec = DateTime.MinValue;
         AV70VouReg = "";
         AV105VouDGls = "";
         P00BI6_A71TipADCod = new string[] {""} ;
         P00BI6_A70TipACod = new int[1] ;
         P00BI6_n70TipACod = new bool[] {false} ;
         P00BI6_A72TipADDsc = new string[] {""} ;
         A71TipADCod = "";
         A72TipADDsc = "";
         AV65CueDAxuDsc = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV73Glosa = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_libromayorgeneralbimonedaexcel__default(),
            new Object[][] {
                new Object[] {
               P00BI2_A127VouAno, P00BI2_A128VouMes, P00BI2_A126TASICod, P00BI2_A129VouNum, P00BI2_A133CueCodAux, P00BI2_A91CueCod, P00BI2_A2077VouSts, P00BI2_A135VouDFec, P00BI2_A860CueDsc, P00BI2_A70TipACod,
               P00BI2_n70TipACod, P00BI2_A130VouDSec
               }
               , new Object[] {
               P00BI3_A127VouAno, P00BI3_A128VouMes, P00BI3_A126TASICod, P00BI3_A129VouNum, P00BI3_A134CueAuxCod, P00BI3_A133CueCodAux, P00BI3_A2077VouSts, P00BI3_A91CueCod, P00BI3_A135VouDFec, P00BI3_A130VouDSec
               }
               , new Object[] {
               P00BI4_A127VouAno, P00BI4_A128VouMes, P00BI4_A126TASICod, P00BI4_A129VouNum, P00BI4_A133CueCodAux, P00BI4_A91CueCod, P00BI4_A2077VouSts, P00BI4_A136VouReg, P00BI4_A2053VouDDoc, P00BI4_A132VouDTipCod,
               P00BI4_A134CueAuxCod, P00BI4_A135VouDFec, P00BI4_A130VouDSec
               }
               , new Object[] {
               P00BI5_A127VouAno, P00BI5_A128VouMes, P00BI5_A126TASICod, P00BI5_A129VouNum, P00BI5_A2077VouSts, P00BI5_A2053VouDDoc, P00BI5_A132VouDTipCod, P00BI5_A91CueCod, P00BI5_A133CueCodAux, P00BI5_A135VouDFec,
               P00BI5_A136VouReg, P00BI5_A2069VouDTcmb, P00BI5_A2051VouDDeb, P00BI5_A2055VouDHab, P00BI5_A2052VouDDebO, P00BI5_A2056VouDHabO, P00BI5_A2054VouDGls, P00BI5_A131VouDMon, P00BI5_A130VouDSec
               }
               , new Object[] {
               P00BI6_A71TipADCod, P00BI6_A70TipACod, P00BI6_A72TipADDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A2077VouSts ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short AV118GXLvl164 ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A126TASICod ;
      private int A70TipACod ;
      private int A130VouDSec ;
      private int AV87TipACod ;
      private int A131VouDMon ;
      private int AV104VouDMon ;
      private decimal AV91TDebeMN ;
      private decimal AV92ThaberMN ;
      private decimal AV54TDebeME ;
      private decimal AV55THaberME ;
      private decimal AV93TADebeMN ;
      private decimal AV106TAHaberMN ;
      private decimal AV94TADebeME ;
      private decimal AV95TAHaberME ;
      private decimal AV96TDDebeMN ;
      private decimal AV97TDHaberMN ;
      private decimal AV98TDDebeME ;
      private decimal AV99TDHaberME ;
      private decimal A2069VouDTcmb ;
      private decimal A2051VouDDeb ;
      private decimal A2055VouDHab ;
      private decimal A2052VouDDebO ;
      private decimal A2056VouDHabO ;
      private decimal AV103VouDTCmb ;
      private decimal AV71VouDDeb ;
      private decimal AV72VouDHab ;
      private decimal AV101VouDDebE ;
      private decimal AV102VouDHabE ;
      private decimal AV107TDSaldoMN ;
      private decimal AV108TDSaldoME ;
      private string AV43cCosto ;
      private string AV44cCuenta1 ;
      private string AV45cCuenta2 ;
      private string AV90CueCodAux ;
      private string AV38Path ;
      private string AV39Periodo ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A133CueCodAux ;
      private string A129VouNum ;
      private string A860CueDsc ;
      private string AV46CueCod ;
      private string AV47CueDsc ;
      private string A134CueAuxCod ;
      private string AV64CueDAxu ;
      private string A136VouReg ;
      private string A2053VouDDoc ;
      private string A132VouDTipCod ;
      private string AV100VouDTipCod ;
      private string AV69VouDDoc ;
      private string A2054VouDGls ;
      private string AV70VouReg ;
      private string AV105VouDGls ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private string AV65CueDAxuDsc ;
      private string AV73Glosa ;
      private DateTime GXt_dtime1 ;
      private DateTime AV88FDesde ;
      private DateTime AV89FHasta ;
      private DateTime A135VouDFec ;
      private DateTime AV68VouDFec ;
      private bool returnInSub ;
      private bool BRKBI2 ;
      private bool n70TipACod ;
      private bool BRKBI4 ;
      private bool BRKBI6 ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV41FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FDesde ;
      private DateTime aP1_FHasta ;
      private string aP2_cCosto ;
      private string aP3_cCuenta1 ;
      private string aP4_cCuenta2 ;
      private string aP5_CueCodAux ;
      private IDataStoreProvider pr_default ;
      private short[] P00BI2_A127VouAno ;
      private short[] P00BI2_A128VouMes ;
      private int[] P00BI2_A126TASICod ;
      private string[] P00BI2_A129VouNum ;
      private string[] P00BI2_A133CueCodAux ;
      private string[] P00BI2_A91CueCod ;
      private short[] P00BI2_A2077VouSts ;
      private DateTime[] P00BI2_A135VouDFec ;
      private string[] P00BI2_A860CueDsc ;
      private int[] P00BI2_A70TipACod ;
      private bool[] P00BI2_n70TipACod ;
      private int[] P00BI2_A130VouDSec ;
      private short[] P00BI3_A127VouAno ;
      private short[] P00BI3_A128VouMes ;
      private int[] P00BI3_A126TASICod ;
      private string[] P00BI3_A129VouNum ;
      private string[] P00BI3_A134CueAuxCod ;
      private string[] P00BI3_A133CueCodAux ;
      private short[] P00BI3_A2077VouSts ;
      private string[] P00BI3_A91CueCod ;
      private DateTime[] P00BI3_A135VouDFec ;
      private int[] P00BI3_A130VouDSec ;
      private short[] P00BI4_A127VouAno ;
      private short[] P00BI4_A128VouMes ;
      private int[] P00BI4_A126TASICod ;
      private string[] P00BI4_A129VouNum ;
      private string[] P00BI4_A133CueCodAux ;
      private string[] P00BI4_A91CueCod ;
      private short[] P00BI4_A2077VouSts ;
      private string[] P00BI4_A136VouReg ;
      private string[] P00BI4_A2053VouDDoc ;
      private string[] P00BI4_A132VouDTipCod ;
      private string[] P00BI4_A134CueAuxCod ;
      private DateTime[] P00BI4_A135VouDFec ;
      private int[] P00BI4_A130VouDSec ;
      private short[] P00BI5_A127VouAno ;
      private short[] P00BI5_A128VouMes ;
      private int[] P00BI5_A126TASICod ;
      private string[] P00BI5_A129VouNum ;
      private short[] P00BI5_A2077VouSts ;
      private string[] P00BI5_A2053VouDDoc ;
      private string[] P00BI5_A132VouDTipCod ;
      private string[] P00BI5_A91CueCod ;
      private string[] P00BI5_A133CueCodAux ;
      private DateTime[] P00BI5_A135VouDFec ;
      private string[] P00BI5_A136VouReg ;
      private decimal[] P00BI5_A2069VouDTcmb ;
      private decimal[] P00BI5_A2051VouDDeb ;
      private decimal[] P00BI5_A2055VouDHab ;
      private decimal[] P00BI5_A2052VouDDebO ;
      private decimal[] P00BI5_A2056VouDHabO ;
      private string[] P00BI5_A2054VouDGls ;
      private int[] P00BI5_A131VouDMon ;
      private int[] P00BI5_A130VouDSec ;
      private string[] P00BI6_A71TipADCod ;
      private int[] P00BI6_A70TipACod ;
      private bool[] P00BI6_n70TipACod ;
      private string[] P00BI6_A72TipADDsc ;
      private string aP6_Filename ;
      private string aP7_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV37Archivo ;
   }

   public class r_libromayorgeneralbimonedaexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BI2( IGxContext context ,
                                             string AV44cCuenta1 ,
                                             string AV90CueCodAux ,
                                             string A91CueCod ,
                                             string A133CueCodAux ,
                                             DateTime A135VouDFec ,
                                             DateTime AV88FDesde ,
                                             DateTime AV89FHasta ,
                                             short A2077VouSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[CueCodAux], T1.[CueCod], T2.[VouSts], T1.[VouDFec], T3.[CueDsc], T3.[TipACod], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) INNER JOIN [CBPLANCUENTA] T3 ON T3.[CueCod] = T1.[CueCod])";
         AddWhere(sWhereString, "(T1.[VouDFec] >= @AV88FDesde)");
         AddWhere(sWhereString, "(T1.[VouDFec] <= @AV89FHasta)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44cCuenta1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV44cCuenta1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90CueCodAux)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV90CueCodAux)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[CueCodAux]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00BI3( IGxContext context ,
                                             string AV90CueCodAux ,
                                             string A133CueCodAux ,
                                             DateTime A135VouDFec ,
                                             DateTime AV88FDesde ,
                                             DateTime AV89FHasta ,
                                             string A91CueCod ,
                                             string AV46CueCod ,
                                             short A2077VouSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[CueAuxCod], T1.[CueCodAux], T2.[VouSts], T1.[CueCod], T1.[VouDFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouDFec] >= @AV88FDesde)");
         AddWhere(sWhereString, "(T1.[VouDFec] <= @AV89FHasta)");
         AddWhere(sWhereString, "(T1.[CueCod] = @AV46CueCod)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90CueCodAux)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV90CueCodAux)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCodAux], T1.[CueAuxCod]";
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
                     return conditional_P00BI2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] );
               case 1 :
                     return conditional_P00BI3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] );
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
          Object[] prmP00BI4;
          prmP00BI4 = new Object[] {
          new ParDef("@AV88FDesde",GXType.Date,8,0) ,
          new ParDef("@AV89FHasta",GXType.Date,8,0) ,
          new ParDef("@AV64CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV46CueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BI5;
          prmP00BI5 = new Object[] {
          new ParDef("@AV46CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV64CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV88FDesde",GXType.Date,8,0) ,
          new ParDef("@AV89FHasta",GXType.Date,8,0) ,
          new ParDef("@AV100VouDTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV69VouDDoc",GXType.NChar,20,0)
          };
          Object[] prmP00BI6;
          prmP00BI6 = new Object[] {
          new ParDef("@AV87TipACod",GXType.Int32,6,0) ,
          new ParDef("@AV64CueDAxu",GXType.NChar,20,0)
          };
          Object[] prmP00BI2;
          prmP00BI2 = new Object[] {
          new ParDef("@AV88FDesde",GXType.Date,8,0) ,
          new ParDef("@AV89FHasta",GXType.Date,8,0) ,
          new ParDef("@AV44cCuenta1",GXType.NChar,15,0) ,
          new ParDef("@AV90CueCodAux",GXType.NChar,20,0)
          };
          Object[] prmP00BI3;
          prmP00BI3 = new Object[] {
          new ParDef("@AV88FDesde",GXType.Date,8,0) ,
          new ParDef("@AV89FHasta",GXType.Date,8,0) ,
          new ParDef("@AV46CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV90CueCodAux",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BI2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BI2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BI3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BI3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BI4", "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[CueCodAux], T1.[CueCod], T2.[VouSts], T1.[VouReg], T1.[VouDDoc], T1.[VouDTipCod], T1.[CueAuxCod], T1.[VouDFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouDFec] >= @AV88FDesde) AND (T1.[VouDFec] <= @AV89FHasta) AND (T1.[CueCodAux] = @AV64CueDAxu) AND (T1.[CueCod] = @AV46CueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[CueAuxCod], T1.[CueCodAux], T1.[VouDTipCod], T1.[VouDDoc], T1.[VouReg] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BI4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BI5", "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouDDoc], T1.[VouDTipCod], T1.[CueCod], T1.[CueCodAux], T1.[VouDFec], T1.[VouReg], T1.[VouDTcmb], T1.[VouDDeb], T1.[VouDHab], T1.[VouDDebO], T1.[VouDHabO], T1.[VouDGls], T1.[VouDMon], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[CueCod] = @AV46CueCod and T1.[CueCodAux] = @AV64CueDAxu) AND (T1.[VouDFec] >= @AV88FDesde) AND (T1.[VouDFec] <= @AV89FHasta) AND (T1.[VouDTipCod] = @AV100VouDTipCod) AND (T1.[VouDDoc] = @AV69VouDDoc) AND (T2.[VouSts] = 1) ORDER BY T1.[CueCod], T1.[CueCodAux] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BI5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BI6", "SELECT [TipADCod], [TipACod], [TipADDsc] FROM [CBAUXILIARES] WHERE [TipACod] = @AV87TipACod and [TipADCod] = @AV64CueDAxu ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BI6,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 15);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 15);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 3);
                ((string[]) buf[10])[0] = rslt.getString(11, 15);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                ((int[]) buf[12])[0] = rslt.getInt(13);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 3);
                ((string[]) buf[7])[0] = rslt.getString(8, 15);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 15);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 100);
                ((int[]) buf[17])[0] = rslt.getInt(18);
                ((int[]) buf[18])[0] = rslt.getInt(19);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
