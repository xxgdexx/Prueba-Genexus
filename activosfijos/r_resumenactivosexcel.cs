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
namespace GeneXus.Programs.activosfijos {
   public class r_resumenactivosexcel : GXProcedure
   {
      public r_resumenactivosexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenactivosexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ACTClaCod ,
                           ref string aP1_ACTGrupCod ,
                           ref short aP2_Ano ,
                           ref short aP3_Mes ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV23ACTClaCod = aP0_ACTClaCod;
         this.AV33ACTGrupCod = aP1_ACTGrupCod;
         this.AV35Ano = aP2_Ano;
         this.AV63Mes = aP3_Mes;
         this.AV52Filename = "" ;
         this.AV47ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_ACTClaCod=this.AV23ACTClaCod;
         aP1_ACTGrupCod=this.AV33ACTGrupCod;
         aP2_Ano=this.AV35Ano;
         aP3_Mes=this.AV63Mes;
         aP4_Filename=this.AV52Filename;
         aP5_ErrorMessage=this.AV47ErrorMessage;
      }

      public string executeUdp( ref string aP0_ACTClaCod ,
                                ref string aP1_ACTGrupCod ,
                                ref short aP2_Ano ,
                                ref short aP3_Mes ,
                                out string aP4_Filename )
      {
         execute(ref aP0_ACTClaCod, ref aP1_ACTGrupCod, ref aP2_Ano, ref aP3_Mes, out aP4_Filename, out aP5_ErrorMessage);
         return AV47ErrorMessage ;
      }

      public void executeSubmit( ref string aP0_ACTClaCod ,
                                 ref string aP1_ACTGrupCod ,
                                 ref short aP2_Ano ,
                                 ref short aP3_Mes ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         r_resumenactivosexcel objr_resumenactivosexcel;
         objr_resumenactivosexcel = new r_resumenactivosexcel();
         objr_resumenactivosexcel.AV23ACTClaCod = aP0_ACTClaCod;
         objr_resumenactivosexcel.AV33ACTGrupCod = aP1_ACTGrupCod;
         objr_resumenactivosexcel.AV35Ano = aP2_Ano;
         objr_resumenactivosexcel.AV63Mes = aP3_Mes;
         objr_resumenactivosexcel.AV52Filename = "" ;
         objr_resumenactivosexcel.AV47ErrorMessage = "" ;
         objr_resumenactivosexcel.context.SetSubmitInitialConfig(context);
         objr_resumenactivosexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenactivosexcel);
         aP0_ACTClaCod=this.AV23ACTClaCod;
         aP1_ACTGrupCod=this.AV33ACTGrupCod;
         aP2_Ano=this.AV35Ano;
         aP3_Mes=this.AV63Mes;
         aP4_Filename=this.AV52Filename;
         aP5_ErrorMessage=this.AV47ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenactivosexcel)stateInfo).executePrivate();
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
         AV36Archivo.Source = "Excel/PlantillasActivosFijosResumen.xlsx";
         AV64Path = AV36Archivo.GetPath();
         AV53FilenameOrigen = StringUtil.Trim( AV64Path) + "\\PlantillasActivosFijosResumen.xlsx";
         AV52Filename = "Excel/ResumenActivosFijos" + ".xlsx";
         AV48ExcelDocument.Clear();
         AV48ExcelDocument.Template = AV53FilenameOrigen;
         AV48ExcelDocument.Open(AV52Filename);
         AV49FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV63Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV35Ano), 10, 0));
         AV50FechaIni = context.localUtil.CToD( AV49FechaC, 2);
         GXt_date1 = AV51FechaUlt;
         new GeneXus.Programs.generales.pobtieneultimodiames(context ).execute(  AV50FechaIni, out  GXt_date1) ;
         AV51FechaUlt = GXt_date1;
         AV60jAno = AV35Ano;
         AV62jMes = AV63Mes;
         AV61jAnoAnt = (short)(AV35Ano-1);
         if ( AV63Mes == 1 )
         {
            AV60jAno = (short)(AV35Ano-1);
            AV62jMes = 12;
         }
         else
         {
            AV62jMes = (short)(AV63Mes-1);
         }
         AV38CellRow = 5;
         AV54FirstColumn = 0;
         AV48ExcelDocument.get_Cells(4, 9, 1, 1).Text = "Valor Activo al Año : "+StringUtil.Trim( StringUtil.Str( (decimal)(AV61jAnoAnt), 10, 0));
         AV48ExcelDocument.get_Cells(4, 10, 1, 1).Text = "% Componentes";
         AV48ExcelDocument.get_Cells(4, 11, 1, 1).Text = "Valor Activo al Año : "+StringUtil.Trim( StringUtil.Str( (decimal)(AV61jAnoAnt), 10, 0))+" Componentes";
         AV48ExcelDocument.get_Cells(4, 12, 1, 1).Text = "Valor Base Calculo al : "+StringUtil.Trim( StringUtil.Str( (decimal)(AV61jAnoAnt), 10, 0));
         AV48ExcelDocument.get_Cells(4, 13, 1, 1).Text = "Valor Base Calculo al : "+StringUtil.Trim( StringUtil.Str( (decimal)(AV61jAnoAnt), 10, 0))+" Componentes";
         AV48ExcelDocument.get_Cells(4, 14, 1, 1).Text = "Retiro de Activos";
         AV48ExcelDocument.get_Cells(4, 15, 1, 1).Text = "Retiro de Activos Componentes";
         AV48ExcelDocument.get_Cells(4, 16, 1, 1).Text = "Baja de Activos";
         AV48ExcelDocument.get_Cells(4, 17, 1, 1).Text = "Baja de Activos Componentes";
         AV48ExcelDocument.get_Cells(4, 18, 1, 1).Text = "Valor de Compra Activos";
         AV48ExcelDocument.get_Cells(4, 19, 1, 1).Text = "Valor de Compra Activos Componentes";
         AV48ExcelDocument.get_Cells(4, 20, 1, 1).Text = "Reparaciones / OverHall";
         AV48ExcelDocument.get_Cells(4, 21, 1, 1).Text = "Reparaciones / OverHall Componentes";
         AV48ExcelDocument.get_Cells(4, 22, 1, 1).Text = "Valor Total del Activo";
         AV48ExcelDocument.get_Cells(4, 23, 1, 1).Text = "Valor Total del Activo Componentes";
         AV48ExcelDocument.get_Cells(4, 24, 1, 1).Text = "Depreciación Acumulada al Año : "+StringUtil.Trim( StringUtil.Str( (decimal)(AV61jAnoAnt), 10, 0));
         AV48ExcelDocument.get_Cells(4, 25, 1, 1).Text = "Depreciación Acumulada al Año : "+StringUtil.Trim( StringUtil.Str( (decimal)(AV61jAnoAnt), 10, 0))+" Componentes";
         AV48ExcelDocument.get_Cells(4, 26, 1, 1).Text = "Retiro por Baja Depreciación Acumulada";
         AV48ExcelDocument.get_Cells(4, 27, 1, 1).Text = "Retiro por Baja Depreciación Acumulada Componentes";
         AV48ExcelDocument.get_Cells(4, 28, 1, 1).Text = "Vida Util";
         AV48ExcelDocument.get_Cells(4, 29, 1, 1).Text = "Depreciación Año Actual";
         AV48ExcelDocument.get_Cells(4, 30, 1, 1).Text = "Depreciación Año Actual Componentes";
         AV48ExcelDocument.get_Cells(4, 31, 1, 1).Text = "Depreciación Acumulada Mes Anterior";
         AV48ExcelDocument.get_Cells(4, 32, 1, 1).Text = "Depreciación Acumulada Mes Anterior Componentes";
         AV48ExcelDocument.get_Cells(4, 33, 1, 1).Text = "Depreciación Acumulada Total";
         AV48ExcelDocument.get_Cells(4, 34, 1, 1).Text = "Depreciación Acumulada Total Componentes";
         AV48ExcelDocument.get_Cells(4, 35, 1, 1).Text = "Valor Residual";
         AV48ExcelDocument.get_Cells(4, 36, 1, 1).Text = "Valor en Libros";
         AV48ExcelDocument.get_Cells(4, 37, 1, 1).Text = "Valor en Libros Componentes";
         AV48ExcelDocument.get_Cells(4, 38, 1, 1).Text = "Centro de Costos";
         AV48ExcelDocument.get_Cells(4, 39, 1, 1).Text = "Depreciación Mes Actual";
         AV48ExcelDocument.get_Cells(4, 40, 1, 1).Text = "Depreciación Mes Actual Componentes";
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV23ACTClaCod ,
                                              A426ACTClaCod ,
                                              A2107ACTHisAno ,
                                              AV35Ano ,
                                              A2108ACTHisMes ,
                                              AV63Mes } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00F62 */
         pr_default.execute(0, new Object[] {AV35Ano, AV63Mes, AV23ACTClaCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKF62 = false;
            A2100ACTActCod = P00F62_A2100ACTActCod[0];
            A2107ACTHisAno = P00F62_A2107ACTHisAno[0];
            A2108ACTHisMes = P00F62_A2108ACTHisMes[0];
            A2184ACTClaDsc = P00F62_A2184ACTClaDsc[0];
            A426ACTClaCod = P00F62_A426ACTClaCod[0];
            n426ACTClaCod = P00F62_n426ACTClaCod[0];
            A2104ActActItem = P00F62_A2104ActActItem[0];
            n2104ActActItem = P00F62_n2104ActActItem[0];
            A426ACTClaCod = P00F62_A426ACTClaCod[0];
            n426ACTClaCod = P00F62_n426ACTClaCod[0];
            A2184ACTClaDsc = P00F62_A2184ACTClaDsc[0];
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00F62_A426ACTClaCod[0], A426ACTClaCod) == 0 ) )
            {
               BRKF62 = false;
               A2100ACTActCod = P00F62_A2100ACTActCod[0];
               A2107ACTHisAno = P00F62_A2107ACTHisAno[0];
               A2108ACTHisMes = P00F62_A2108ACTHisMes[0];
               A2184ACTClaDsc = P00F62_A2184ACTClaDsc[0];
               A2104ActActItem = P00F62_A2104ActActItem[0];
               n2104ActActItem = P00F62_n2104ActActItem[0];
               A2184ACTClaDsc = P00F62_A2184ACTClaDsc[0];
               BRKF62 = true;
               pr_default.readNext(0);
            }
            AV39Clase = A426ACTClaCod;
            AV24ACTClaDsc = StringUtil.Trim( A2184ACTClaDsc);
            /* Execute user subroutine: 'DETALLEACTIVOS' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( ! BRKF62 )
            {
               BRKF62 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV48ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV48ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV48ExcelDocument.ErrCode != 0 )
         {
            AV52Filename = "";
            AV47ErrorMessage = AV48ExcelDocument.ErrDescription;
            AV48ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'DETALLEACTIVOS' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV33ACTGrupCod ,
                                              A2103ACTGrupCod ,
                                              A2107ACTHisAno ,
                                              AV35Ano ,
                                              A2108ACTHisMes ,
                                              AV63Mes ,
                                              AV39Clase ,
                                              A426ACTClaCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00F63 */
         pr_default.execute(1, new Object[] {AV39Clase, AV35Ano, AV63Mes, AV33ACTGrupCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKF64 = false;
            A2100ACTActCod = P00F63_A2100ACTActCod[0];
            A426ACTClaCod = P00F63_A426ACTClaCod[0];
            n426ACTClaCod = P00F63_n426ACTClaCod[0];
            A2107ACTHisAno = P00F63_A2107ACTHisAno[0];
            A2108ACTHisMes = P00F63_A2108ACTHisMes[0];
            A2196ACTGrupDsc = P00F63_A2196ACTGrupDsc[0];
            A2103ACTGrupCod = P00F63_A2103ACTGrupCod[0];
            A2104ActActItem = P00F63_A2104ActActItem[0];
            n2104ActActItem = P00F63_n2104ActActItem[0];
            A426ACTClaCod = P00F63_A426ACTClaCod[0];
            n426ACTClaCod = P00F63_n426ACTClaCod[0];
            A2103ACTGrupCod = P00F63_A2103ACTGrupCod[0];
            A2196ACTGrupDsc = P00F63_A2196ACTGrupDsc[0];
            W426ACTClaCod = A426ACTClaCod;
            n426ACTClaCod = false;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00F63_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(P00F63_A2103ACTGrupCod[0], A2103ACTGrupCod) == 0 ) )
            {
               BRKF64 = false;
               A2100ACTActCod = P00F63_A2100ACTActCod[0];
               A2107ACTHisAno = P00F63_A2107ACTHisAno[0];
               A2108ACTHisMes = P00F63_A2108ACTHisMes[0];
               A2196ACTGrupDsc = P00F63_A2196ACTGrupDsc[0];
               A2104ActActItem = P00F63_A2104ActActItem[0];
               n2104ActActItem = P00F63_n2104ActActItem[0];
               A2196ACTGrupDsc = P00F63_A2196ACTGrupDsc[0];
               BRKF64 = true;
               pr_default.readNext(1);
            }
            AV55Grupo = A2103ACTGrupCod;
            AV8ACTGrupDsc = StringUtil.Trim( A2196ACTGrupDsc);
            /* Execute user subroutine: 'ACTIVOS' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            A426ACTClaCod = W426ACTClaCod;
            n426ACTClaCod = false;
            if ( ! BRKF64 )
            {
               BRKF64 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S134( )
      {
         /* 'ACTIVOS' Routine */
         returnInSub = false;
         /* Using cursor P00F64 */
         pr_default.execute(2, new Object[] {AV39Clase, AV55Grupo, AV35Ano, AV63Mes});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKF66 = false;
            A2122ACTActDsc = P00F64_A2122ACTActDsc[0];
            A2100ACTActCod = P00F64_A2100ACTActCod[0];
            A2108ACTHisMes = P00F64_A2108ACTHisMes[0];
            A2107ACTHisAno = P00F64_A2107ACTHisAno[0];
            A2103ACTGrupCod = P00F64_A2103ACTGrupCod[0];
            A426ACTClaCod = P00F64_A426ACTClaCod[0];
            n426ACTClaCod = P00F64_n426ACTClaCod[0];
            A2118ACTActCodEQV = P00F64_A2118ACTActCodEQV[0];
            A2128ACTActMarca = P00F64_A2128ACTActMarca[0];
            A2129ACTActModelo = P00F64_A2129ACTActModelo[0];
            A2135ACTActSerie = P00F64_A2135ACTActSerie[0];
            A2123ACTActFech = P00F64_A2123ACTActFech[0];
            A2124ACTActFIni = P00F64_A2124ACTActFIni[0];
            A2132ACTActOrd = P00F64_A2132ACTActOrd[0];
            A2121ACTActDocNum = P00F64_A2121ACTActDocNum[0];
            A2104ActActItem = P00F64_A2104ActActItem[0];
            n2104ActActItem = P00F64_n2104ActActItem[0];
            A2122ACTActDsc = P00F64_A2122ACTActDsc[0];
            A2103ACTGrupCod = P00F64_A2103ACTGrupCod[0];
            A426ACTClaCod = P00F64_A426ACTClaCod[0];
            n426ACTClaCod = P00F64_n426ACTClaCod[0];
            A2118ACTActCodEQV = P00F64_A2118ACTActCodEQV[0];
            A2128ACTActMarca = P00F64_A2128ACTActMarca[0];
            A2129ACTActModelo = P00F64_A2129ACTActModelo[0];
            A2135ACTActSerie = P00F64_A2135ACTActSerie[0];
            A2123ACTActFech = P00F64_A2123ACTActFech[0];
            A2124ACTActFIni = P00F64_A2124ACTActFIni[0];
            A2132ACTActOrd = P00F64_A2132ACTActOrd[0];
            A2121ACTActDocNum = P00F64_A2121ACTActDocNum[0];
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00F64_A2100ACTActCod[0], A2100ACTActCod) == 0 ) )
            {
               BRKF66 = false;
               A2122ACTActDsc = P00F64_A2122ACTActDsc[0];
               A2108ACTHisMes = P00F64_A2108ACTHisMes[0];
               A2107ACTHisAno = P00F64_A2107ACTHisAno[0];
               A2104ActActItem = P00F64_A2104ActActItem[0];
               n2104ActActItem = P00F64_n2104ActActItem[0];
               A2122ACTActDsc = P00F64_A2122ACTActDsc[0];
               BRKF66 = true;
               pr_default.readNext(2);
            }
            AV40Codigo = A2100ACTActCod;
            AV10ACTActCodEQV = A2118ACTActCodEQV;
            AV12ACTActDsc = StringUtil.Trim( A2122ACTActDsc);
            AV16ACTActMarca = A2128ACTActMarca;
            AV17ACTActModelo = A2129ACTActModelo;
            AV19ACTActSerie = A2135ACTActSerie;
            AV13ACTActFech = A2123ACTActFech;
            AV14ACTActFIni = A2124ACTActFIni;
            AV18ACTActOrd = A2132ACTActOrd;
            AV11ACTActDocNum = A2121ACTActDocNum;
            AV59Item = 1;
            AV69VAAAT = 0;
            AV79VBCT = 0;
            AV97VRAAT = 0;
            AV81VCAAT = 0;
            AV93VNAT = 0;
            AV97VRAAT = 0;
            AV77VBAT = 0;
            AV81VCAAT = 0;
            AV95VOVERT = 0;
            AV66TVBAJA = 0;
            AV83VDAAAT = 0;
            AV88VDATT = 0;
            AV86VDAMAT = 0;
            AV90VDMAT = 0;
            AV70VACUMUTOTAL = 0;
            AV67TVLIBROS = 0;
            /* Execute user subroutine: 'PRINTACTIVOTOTAL' */
            S146 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'DETALLE' */
            S156 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTTOTALESACTIVO' */
            S166 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            AV38CellRow = (int)(AV38CellRow+1);
            if ( ! BRKF66 )
            {
               BRKF66 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S156( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         /* Using cursor P00F65 */
         pr_default.execute(3, new Object[] {AV35Ano, AV63Mes, AV40Codigo, AV39Clase, AV55Grupo});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A2114ACTSGrupCod = P00F65_A2114ACTSGrupCod[0];
            A2108ACTHisMes = P00F65_A2108ACTHisMes[0];
            A2107ACTHisAno = P00F65_A2107ACTHisAno[0];
            A2100ACTActCod = P00F65_A2100ACTActCod[0];
            A2103ACTGrupCod = P00F65_A2103ACTGrupCod[0];
            A426ACTClaCod = P00F65_A426ACTClaCod[0];
            n426ACTClaCod = P00F65_n426ACTClaCod[0];
            A2155ACTSGrupDsc = P00F65_A2155ACTSGrupDsc[0];
            A2150ACTDetValorNeto = P00F65_A2150ACTDetValorNeto[0];
            A2152ACTDetValorResiduo = P00F65_A2152ACTDetValorResiduo[0];
            A2143ACTDetFecIni = P00F65_A2143ACTDetFecIni[0];
            A2154ACTDetVidaUtil = P00F65_A2154ACTDetVidaUtil[0];
            A2149ACTDetValorCompras = P00F65_A2149ACTDetValorCompras[0];
            A2144ACTDetMarca = P00F65_A2144ACTDetMarca[0];
            A2145ACTDetModelo = P00F65_A2145ACTDetModelo[0];
            A2147ACTDetSerie = P00F65_A2147ACTDetSerie[0];
            A79COSCod = P00F65_A79COSCod[0];
            A2104ActActItem = P00F65_A2104ActActItem[0];
            n2104ActActItem = P00F65_n2104ActActItem[0];
            A2103ACTGrupCod = P00F65_A2103ACTGrupCod[0];
            A426ACTClaCod = P00F65_A426ACTClaCod[0];
            n426ACTClaCod = P00F65_n426ACTClaCod[0];
            A79COSCod = P00F65_A79COSCod[0];
            A2114ACTSGrupCod = P00F65_A2114ACTSGrupCod[0];
            A2150ACTDetValorNeto = P00F65_A2150ACTDetValorNeto[0];
            A2152ACTDetValorResiduo = P00F65_A2152ACTDetValorResiduo[0];
            A2143ACTDetFecIni = P00F65_A2143ACTDetFecIni[0];
            A2154ACTDetVidaUtil = P00F65_A2154ACTDetVidaUtil[0];
            A2149ACTDetValorCompras = P00F65_A2149ACTDetValorCompras[0];
            A2144ACTDetMarca = P00F65_A2144ACTDetMarca[0];
            A2145ACTDetModelo = P00F65_A2145ACTDetModelo[0];
            A2147ACTDetSerie = P00F65_A2147ACTDetSerie[0];
            A2155ACTSGrupDsc = P00F65_A2155ACTSGrupDsc[0];
            AV9ACTActCod = A2100ACTActCod;
            AV15ActActItem = A2104ActActItem;
            AV34ACTSGrupDsc = StringUtil.Trim( A2155ACTSGrupDsc);
            AV30ACTDetValorNeto = A2150ACTDetValorNeto;
            AV31ACTDetValorResiduo = A2152ACTDetValorResiduo;
            AV25ACTDetFecIni = A2143ACTDetFecIni;
            AV32ACTDetVidaUtil = A2154ACTDetVidaUtil;
            AV71Valor = (decimal)((A2150ACTDetValorNeto+AV21ACTActValorReparacion+A2149ACTDetValorCompras));
            AV73ValorCalculo = (decimal)((A2150ACTDetValorNeto+AV21ACTActValorReparacion+A2149ACTDetValorCompras)-(A2152ACTDetValorResiduo));
            AV26ACTDetMarca = A2144ACTDetMarca;
            AV27ACTDetModelo = A2145ACTDetModelo;
            AV28ACTDetSerie = A2147ACTDetSerie;
            AV56ImpDepre = 0;
            AV41CosCod = A79COSCod;
            AV29ACTDetSts = "";
            AV68VAAAC = 0;
            AV78VBCC = 0;
            AV96VRAAC = 0;
            AV75VBAC = 0;
            AV80VCAAC = 0;
            AV94VOVERC = 0;
            AV92VNAC = 0;
            AV76VBAJA = 0;
            AV82VDAAAC = 0;
            AV87VDATC = 0;
            AV85VDAMAC = 0;
            AV84VDAC = 0;
            AV89VDMAC = 0;
            AV91VLIBROS = 0;
            /* Execute user subroutine: 'PORCENTAJES' */
            S178 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'VAAA' */
            S188 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'VRAA' */
            S198 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'VBA' */
            S208 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV78VBCC = AV68VAAAC;
            /* Execute user subroutine: 'VCAA' */
            S218 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'VOVER' */
            S228 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV92VNAC = (decimal)((AV68VAAAC+AV80VCAAC+AV94VOVERC));
            /* Execute user subroutine: 'VDAAA' */
            S238 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'VDAT' */
            S248 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'VDAMA' */
            S258 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'VDMAC' */
            S268 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV76VBAJA = (!(Convert.ToDecimal(0)==AV75VBAC) ? AV82VDAAAC+AV87VDATC : (decimal)(0));
            AV87VDATC = (!(Convert.ToDecimal(0)==AV75VBAC) ? (decimal)(0) : AV87VDATC);
            AV84VDAC = (!(Convert.ToDecimal(0)==AV75VBAC) ? (decimal)(0) : (AV82VDAAAC+AV87VDATC));
            AV31ACTDetValorResiduo = (!(Convert.ToDecimal(0)==AV75VBAC) ? (decimal)(0) : AV31ACTDetValorResiduo);
            AV91VLIBROS = (!(Convert.ToDecimal(0)==AV75VBAC) ? (decimal)(0) : AV92VNAC-(AV82VDAAAC+AV87VDATC));
            /* Execute user subroutine: 'ULTIMOCENTROCOSTO' */
            S278 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV69VAAAT = (decimal)(AV69VAAAT+AV68VAAAC);
            AV79VBCT = (decimal)(AV79VBCT+AV78VBCC);
            AV93VNAT = (decimal)(AV93VNAT+AV92VNAC);
            AV97VRAAT = (decimal)(AV97VRAAT+AV96VRAAC);
            AV77VBAT = (decimal)(AV77VBAT+AV75VBAC);
            AV81VCAAT = (decimal)(AV81VCAAT+AV80VCAAC);
            AV95VOVERT = (decimal)(AV95VOVERT+AV94VOVERC);
            AV83VDAAAT = (decimal)(AV83VDAAAT+AV82VDAAAC);
            AV88VDATT = (decimal)(AV88VDATT+AV87VDATC);
            AV86VDAMAT = (decimal)(AV86VDAMAT+AV85VDAMAC);
            AV70VACUMUTOTAL = (decimal)(AV70VACUMUTOTAL+AV84VDAC);
            AV66TVBAJA = (decimal)(AV66TVBAJA+AV76VBAJA);
            AV67TVLIBROS = (decimal)(AV67TVLIBROS+AV91VLIBROS);
            AV90VDMAT = (decimal)(AV90VDMAT+AV89VDMAC);
            /* Execute user subroutine: 'PRINTACTIVOCOMPONENTE' */
            S288 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV59Item = (int)(AV59Item+1);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S188( )
      {
         /* 'VAAA' Routine */
         returnInSub = false;
         /* Using cursor P00F66 */
         pr_default.execute(4, new Object[] {AV9ACTActCod, AV15ActActItem, AV35Ano});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A2143ACTDetFecIni = P00F66_A2143ACTDetFecIni[0];
            A2104ActActItem = P00F66_A2104ActActItem[0];
            n2104ActActItem = P00F66_n2104ActActItem[0];
            A2100ACTActCod = P00F66_A2100ACTActCod[0];
            A2150ACTDetValorNeto = P00F66_A2150ACTDetValorNeto[0];
            AV68VAAAC = A2150ACTDetValorNeto;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         /* Using cursor P00F67 */
         pr_default.execute(5, new Object[] {AV9ACTActCod, AV35Ano, AV25ACTDetFecIni});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A2204AMRepFec = P00F67_A2204AMRepFec[0];
            A2100ACTActCod = P00F67_A2100ACTActCod[0];
            A2209AMRepValor = P00F67_A2209AMRepValor[0];
            A2104ActActItem = P00F67_A2104ActActItem[0];
            n2104ActActItem = P00F67_n2104ActActItem[0];
            A2112AMRepCod = P00F67_A2112AMRepCod[0];
            AV68VAAAC = (decimal)(AV68VAAAC+((String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem))||P00F67_n2104ActActItem[0] ? NumberUtil.Round( (A2209AMRepValor*AV65Porcentaje)/ (decimal)(100), 2) : ((StringUtil.StrCmp(A2104ActActItem, AV15ActActItem)==0) ? A2209AMRepValor : (decimal)(0)))));
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /* Using cursor P00F68 */
         pr_default.execute(6, new Object[] {AV9ACTActCod, AV35Ano, AV25ACTDetFecIni});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A2218ACTRevFec = P00F68_A2218ACTRevFec[0];
            A2100ACTActCod = P00F68_A2100ACTActCod[0];
            A2217ActRevCosto = P00F68_A2217ActRevCosto[0];
            A2104ActActItem = P00F68_A2104ActActItem[0];
            n2104ActActItem = P00F68_n2104ActActItem[0];
            A2113ACTRevCod = P00F68_A2113ACTRevCod[0];
            AV68VAAAC = (decimal)(AV68VAAAC+((String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem))||P00F68_n2104ActActItem[0] ? NumberUtil.Round( (A2217ActRevCosto*AV65Porcentaje)/ (decimal)(100), 2) : ((StringUtil.StrCmp(A2104ActActItem, AV15ActActItem)==0) ? A2217ActRevCosto : (decimal)(0)))));
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S198( )
      {
         /* 'VRAA' Routine */
         returnInSub = false;
         /* Using cursor P00F69 */
         pr_default.execute(7, new Object[] {AV9ACTActCod, AV35Ano, AV51FechaUlt, AV25ACTDetFecIni});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A2159ACTRetFec = P00F69_A2159ACTRetFec[0];
            A2100ACTActCod = P00F69_A2100ACTActCod[0];
            A2162ACTRetRetFec = P00F69_A2162ACTRetRetFec[0];
            A2157ACTRetCosto = P00F69_A2157ACTRetCosto[0];
            A2104ActActItem = P00F69_A2104ActActItem[0];
            n2104ActActItem = P00F69_n2104ActActItem[0];
            A2105ACTRetCod = P00F69_A2105ACTRetCod[0];
            if ( ! (DateTime.MinValue==A2162ACTRetRetFec) )
            {
               AV96VRAAC = (decimal)(AV96VRAAC+((String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem))||P00F69_n2104ActActItem[0] ? NumberUtil.Round( (A2157ACTRetCosto*AV65Porcentaje)/ (decimal)(100), 2) : ((StringUtil.StrCmp(A2104ActActItem, AV15ActActItem)==0) ? A2157ACTRetCosto : (decimal)(0)))));
            }
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void S208( )
      {
         /* 'VBA' Routine */
         returnInSub = false;
         /* Using cursor P00F610 */
         pr_default.execute(8, new Object[] {AV9ACTActCod, AV35Ano, AV51FechaUlt, AV25ACTDetFecIni});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A2175ACTABajFec = P00F610_A2175ACTABajFec[0];
            A2100ACTActCod = P00F610_A2100ACTActCod[0];
            A2177ACTBajCosto = P00F610_A2177ACTBajCosto[0];
            A2104ActActItem = P00F610_A2104ActActItem[0];
            n2104ActActItem = P00F610_n2104ActActItem[0];
            A2106ACTABajCod = P00F610_A2106ACTABajCod[0];
            AV75VBAC = (decimal)(AV75VBAC+((String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem))||P00F610_n2104ActActItem[0] ? NumberUtil.Round( ((A2177ACTBajCosto)*AV65Porcentaje)/ (decimal)(100), 2) : ((StringUtil.StrCmp(A2104ActActItem, AV15ActActItem)==0) ? A2177ACTBajCosto : (decimal)(0)))));
            pr_default.readNext(8);
         }
         pr_default.close(8);
         if ( ! (Convert.ToDecimal(0)==AV75VBAC) )
         {
            AV29ACTDetSts = "B";
         }
      }

      protected void S218( )
      {
         /* 'VCAA' Routine */
         returnInSub = false;
         /* Using cursor P00F611 */
         pr_default.execute(9, new Object[] {AV9ACTActCod, AV15ActActItem, AV35Ano, AV51FechaUlt});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A2143ACTDetFecIni = P00F611_A2143ACTDetFecIni[0];
            A2104ActActItem = P00F611_A2104ActActItem[0];
            n2104ActActItem = P00F611_n2104ActActItem[0];
            A2100ACTActCod = P00F611_A2100ACTActCod[0];
            A2150ACTDetValorNeto = P00F611_A2150ACTDetValorNeto[0];
            AV80VCAAC = A2150ACTDetValorNeto;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(9);
         /* Using cursor P00F612 */
         pr_default.execute(10, new Object[] {AV9ACTActCod, AV35Ano, AV51FechaUlt, AV25ACTDetFecIni});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A2218ACTRevFec = P00F612_A2218ACTRevFec[0];
            A2100ACTActCod = P00F612_A2100ACTActCod[0];
            A2217ActRevCosto = P00F612_A2217ActRevCosto[0];
            A2104ActActItem = P00F612_A2104ActActItem[0];
            n2104ActActItem = P00F612_n2104ActActItem[0];
            A2113ACTRevCod = P00F612_A2113ACTRevCod[0];
            AV80VCAAC = (decimal)(AV80VCAAC+((String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem))||P00F612_n2104ActActItem[0] ? NumberUtil.Round( (A2217ActRevCosto*AV65Porcentaje)/ (decimal)(100), 2) : ((StringUtil.StrCmp(A2104ActActItem, AV15ActActItem)==0) ? A2217ActRevCosto : (decimal)(0)))));
            pr_default.readNext(10);
         }
         pr_default.close(10);
      }

      protected void S228( )
      {
         /* 'VOVER' Routine */
         returnInSub = false;
         /* Using cursor P00F613 */
         pr_default.execute(11, new Object[] {AV9ACTActCod, AV35Ano, AV51FechaUlt});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A2204AMRepFec = P00F613_A2204AMRepFec[0];
            A2100ACTActCod = P00F613_A2100ACTActCod[0];
            A2209AMRepValor = P00F613_A2209AMRepValor[0];
            A2104ActActItem = P00F613_A2104ActActItem[0];
            n2104ActActItem = P00F613_n2104ActActItem[0];
            A2112AMRepCod = P00F613_A2112AMRepCod[0];
            AV94VOVERC = (decimal)(AV94VOVERC+((String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem))||P00F613_n2104ActActItem[0] ? NumberUtil.Round( (A2209AMRepValor*AV65Porcentaje)/ (decimal)(100), 2) : ((StringUtil.StrCmp(A2104ActActItem, AV15ActActItem)==0) ? A2209AMRepValor : (decimal)(0)))));
            pr_default.readNext(11);
         }
         pr_default.close(11);
      }

      protected void S238( )
      {
         /* 'VDAAA' Routine */
         returnInSub = false;
         /* Optimized group. */
         /* Using cursor P00F614 */
         pr_default.execute(12, new Object[] {AV9ACTActCod, AV15ActActItem, AV35Ano});
         c2189ACTHisDepre = P00F614_A2189ACTHisDepre[0];
         pr_default.close(12);
         AV82VDAAAC = (decimal)(AV82VDAAAC+c2189ACTHisDepre);
         /* End optimized group. */
      }

      protected void S248( )
      {
         /* 'VDAT' Routine */
         returnInSub = false;
         /* Optimized group. */
         /* Using cursor P00F615 */
         pr_default.execute(13, new Object[] {AV9ACTActCod, AV15ActActItem, AV51FechaUlt, AV35Ano});
         c2189ACTHisDepre = P00F615_A2189ACTHisDepre[0];
         pr_default.close(13);
         AV87VDATC = (decimal)(AV87VDATC+c2189ACTHisDepre);
         /* End optimized group. */
      }

      protected void S258( )
      {
         /* 'VDAMA' Routine */
         returnInSub = false;
         /* Optimized group. */
         /* Using cursor P00F616 */
         pr_default.execute(14, new Object[] {AV9ACTActCod, AV15ActActItem, AV35Ano, AV50FechaIni});
         c2189ACTHisDepre = P00F616_A2189ACTHisDepre[0];
         pr_default.close(14);
         AV85VDAMAC = (decimal)(AV85VDAMAC+c2189ACTHisDepre);
         /* End optimized group. */
      }

      protected void S268( )
      {
         /* 'VDMAC' Routine */
         returnInSub = false;
         /* Using cursor P00F617 */
         pr_default.execute(15, new Object[] {AV35Ano, AV63Mes, AV9ACTActCod, AV15ActActItem});
         while ( (pr_default.getStatus(15) != 101) )
         {
            A2108ACTHisMes = P00F617_A2108ACTHisMes[0];
            A2107ACTHisAno = P00F617_A2107ACTHisAno[0];
            A2104ActActItem = P00F617_A2104ActActItem[0];
            n2104ActActItem = P00F617_n2104ActActItem[0];
            A2100ACTActCod = P00F617_A2100ACTActCod[0];
            A2189ACTHisDepre = P00F617_A2189ACTHisDepre[0];
            AV89VDMAC = A2189ACTHisDepre;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(15);
      }

      protected void S278( )
      {
         /* 'ULTIMOCENTROCOSTO' Routine */
         returnInSub = false;
         AV42Costo = "";
         /* Using cursor P00F618 */
         pr_default.execute(16, new Object[] {AV9ACTActCod, AV51FechaUlt});
         while ( (pr_default.getStatus(16) != 101) )
         {
            A2100ACTActCod = P00F618_A2100ACTActCod[0];
            A2200AMovFec = P00F618_A2200AMovFec[0];
            A2110AMovCosCod = P00F618_A2110AMovCosCod[0];
            n2110AMovCosCod = P00F618_n2110AMovCosCod[0];
            A2109AMovCod = P00F618_A2109AMovCod[0];
            AV41CosCod = A2110AMovCosCod;
            pr_default.readNext(16);
         }
         pr_default.close(16);
         /* Using cursor P00F619 */
         pr_default.execute(17, new Object[] {AV41CosCod});
         while ( (pr_default.getStatus(17) != 101) )
         {
            A79COSCod = P00F619_A79COSCod[0];
            A761COSDsc = P00F619_A761COSDsc[0];
            AV42Costo = A761COSDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(17);
      }

      protected void S178( )
      {
         /* 'PORCENTAJES' Routine */
         returnInSub = false;
         AV65Porcentaje = 0;
         /* Using cursor P00F620 */
         pr_default.execute(18, new Object[] {AV9ACTActCod, AV15ActActItem});
         while ( (pr_default.getStatus(18) != 101) )
         {
            A426ACTClaCod = P00F620_A426ACTClaCod[0];
            n426ACTClaCod = P00F620_n426ACTClaCod[0];
            A2103ACTGrupCod = P00F620_A2103ACTGrupCod[0];
            A2114ACTSGrupCod = P00F620_A2114ACTSGrupCod[0];
            A2104ActActItem = P00F620_A2104ActActItem[0];
            n2104ActActItem = P00F620_n2104ActActItem[0];
            A2100ACTActCod = P00F620_A2100ACTActCod[0];
            A2156ACTSGrupPor = P00F620_A2156ACTSGrupPor[0];
            A2156ACTSGrupPor = P00F620_A2156ACTSGrupPor[0];
            AV65Porcentaje = A2156ACTSGrupPor;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(18);
      }

      protected void S146( )
      {
         /* 'PRINTACTIVOTOTAL' Routine */
         returnInSub = false;
         GXt_dtime2 = DateTimeUtil.ResetTime( AV13ACTActFech ) ;
         AV48ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+1, 1, 1).Date = GXt_dtime2;
         GXt_dtime2 = DateTimeUtil.ResetTime( AV14ACTActFIni ) ;
         AV48ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+2, 1, 1).Date = GXt_dtime2;
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV24ACTClaDsc);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV8ACTGrupDsc);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV18ACTActOrd);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV11ACTActDocNum);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+7, 1, 1).Text = (String.IsNullOrEmpty(StringUtil.RTrim( AV10ACTActCodEQV)) ? StringUtil.Trim( AV9ACTActCod) : StringUtil.Trim( AV10ACTActCodEQV));
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+8, 1, 1).Text = StringUtil.Trim( AV12ACTActDsc);
         AV38CellRow = (int)(AV38CellRow+1);
      }

      protected void S288( )
      {
         /* 'PRINTACTIVOCOMPONENTE' Routine */
         returnInSub = false;
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV10ACTActCodEQV);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+8, 1, 1).Text = StringUtil.Trim( AV34ACTSGrupDsc);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+10, 1, 1).Number = (double)(AV65Porcentaje);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+11, 1, 1).Number = (double)(AV68VAAAC);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+13, 1, 1).Number = (double)(AV78VBCC);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+15, 1, 1).Number = (double)(AV96VRAAC);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+17, 1, 1).Number = (double)(AV75VBAC);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+19, 1, 1).Number = (double)(AV80VCAAC);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+21, 1, 1).Number = (double)(AV94VOVERC);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+23, 1, 1).Number = (double)(AV92VNAC);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+25, 1, 1).Number = (double)(AV82VDAAAC);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+27, 1, 1).Number = (double)(AV76VBAJA);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+28, 1, 1).Number = (double)(AV32ACTDetVidaUtil);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+30, 1, 1).Number = (double)(AV87VDATC);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+32, 1, 1).Number = (double)(AV85VDAMAC);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+34, 1, 1).Number = (double)(AV84VDAC);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+35, 1, 1).Number = (double)(AV31ACTDetValorResiduo);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+37, 1, 1).Number = (double)(AV91VLIBROS);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+38, 1, 1).Text = StringUtil.Trim( AV42Costo);
         AV48ExcelDocument.get_Cells(AV38CellRow, AV54FirstColumn+40, 1, 1).Number = (double)(AV89VDMAC);
         AV38CellRow = (int)(AV38CellRow+1);
      }

      protected void S166( )
      {
         /* 'PRINTTOTALESACTIVO' Routine */
         returnInSub = false;
         AV48ExcelDocument.get_Cells(AV38CellRow-AV59Item, 9, 1, 1).Number = (double)(AV69VAAAT);
         AV48ExcelDocument.get_Cells(AV38CellRow-AV59Item, 12, 1, 1).Number = (double)(AV79VBCT);
         AV48ExcelDocument.get_Cells(AV38CellRow-AV59Item, 14, 1, 1).Number = (double)(AV97VRAAT);
         AV48ExcelDocument.get_Cells(AV38CellRow-AV59Item, 16, 1, 1).Number = (double)(AV77VBAT);
         AV48ExcelDocument.get_Cells(AV38CellRow-AV59Item, 18, 1, 1).Number = (double)(AV81VCAAT);
         AV48ExcelDocument.get_Cells(AV38CellRow-AV59Item, 20, 1, 1).Number = (double)(AV95VOVERT);
         AV48ExcelDocument.get_Cells(AV38CellRow-AV59Item, 22, 1, 1).Number = (double)(AV93VNAT);
         AV48ExcelDocument.get_Cells(AV38CellRow-AV59Item, 24, 1, 1).Number = (double)(AV83VDAAAT);
         AV48ExcelDocument.get_Cells(AV38CellRow-AV59Item, 26, 1, 1).Number = (double)(AV66TVBAJA);
         AV48ExcelDocument.get_Cells(AV38CellRow-AV59Item, 29, 1, 1).Number = (double)(AV88VDATT);
         AV48ExcelDocument.get_Cells(AV38CellRow-AV59Item, 31, 1, 1).Number = (double)(AV86VDAMAT);
         AV48ExcelDocument.get_Cells(AV38CellRow-AV59Item, 33, 1, 1).Number = (double)(AV70VACUMUTOTAL);
         AV48ExcelDocument.get_Cells(AV38CellRow-AV59Item, 36, 1, 1).Number = (double)(AV67TVLIBROS);
         AV48ExcelDocument.get_Cells(AV38CellRow-AV59Item, 39, 1, 1).Number = (double)(AV90VDMAT);
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
         AV52Filename = "";
         AV47ErrorMessage = "";
         AV36Archivo = new GxFile(context.GetPhysicalPath());
         AV64Path = "";
         AV53FilenameOrigen = "";
         AV48ExcelDocument = new ExcelDocumentI();
         AV49FechaC = "";
         AV50FechaIni = DateTime.MinValue;
         AV51FechaUlt = DateTime.MinValue;
         GXt_date1 = DateTime.MinValue;
         scmdbuf = "";
         A426ACTClaCod = "";
         P00F62_A2100ACTActCod = new string[] {""} ;
         P00F62_A2107ACTHisAno = new short[1] ;
         P00F62_A2108ACTHisMes = new short[1] ;
         P00F62_A2184ACTClaDsc = new string[] {""} ;
         P00F62_A426ACTClaCod = new string[] {""} ;
         P00F62_n426ACTClaCod = new bool[] {false} ;
         P00F62_A2104ActActItem = new string[] {""} ;
         P00F62_n2104ActActItem = new bool[] {false} ;
         A2100ACTActCod = "";
         A2184ACTClaDsc = "";
         A2104ActActItem = "";
         AV39Clase = "";
         AV24ACTClaDsc = "";
         A2103ACTGrupCod = "";
         P00F63_A2100ACTActCod = new string[] {""} ;
         P00F63_A426ACTClaCod = new string[] {""} ;
         P00F63_n426ACTClaCod = new bool[] {false} ;
         P00F63_A2107ACTHisAno = new short[1] ;
         P00F63_A2108ACTHisMes = new short[1] ;
         P00F63_A2196ACTGrupDsc = new string[] {""} ;
         P00F63_A2103ACTGrupCod = new string[] {""} ;
         P00F63_A2104ActActItem = new string[] {""} ;
         P00F63_n2104ActActItem = new bool[] {false} ;
         A2196ACTGrupDsc = "";
         W426ACTClaCod = "";
         AV55Grupo = "";
         AV8ACTGrupDsc = "";
         P00F64_A2122ACTActDsc = new string[] {""} ;
         P00F64_A2100ACTActCod = new string[] {""} ;
         P00F64_A2108ACTHisMes = new short[1] ;
         P00F64_A2107ACTHisAno = new short[1] ;
         P00F64_A2103ACTGrupCod = new string[] {""} ;
         P00F64_A426ACTClaCod = new string[] {""} ;
         P00F64_n426ACTClaCod = new bool[] {false} ;
         P00F64_A2118ACTActCodEQV = new string[] {""} ;
         P00F64_A2128ACTActMarca = new string[] {""} ;
         P00F64_A2129ACTActModelo = new string[] {""} ;
         P00F64_A2135ACTActSerie = new string[] {""} ;
         P00F64_A2123ACTActFech = new DateTime[] {DateTime.MinValue} ;
         P00F64_A2124ACTActFIni = new DateTime[] {DateTime.MinValue} ;
         P00F64_A2132ACTActOrd = new string[] {""} ;
         P00F64_A2121ACTActDocNum = new string[] {""} ;
         P00F64_A2104ActActItem = new string[] {""} ;
         P00F64_n2104ActActItem = new bool[] {false} ;
         A2122ACTActDsc = "";
         A2118ACTActCodEQV = "";
         A2128ACTActMarca = "";
         A2129ACTActModelo = "";
         A2135ACTActSerie = "";
         A2123ACTActFech = DateTime.MinValue;
         A2124ACTActFIni = DateTime.MinValue;
         A2132ACTActOrd = "";
         A2121ACTActDocNum = "";
         AV40Codigo = "";
         AV10ACTActCodEQV = "";
         AV12ACTActDsc = "";
         AV16ACTActMarca = "";
         AV17ACTActModelo = "";
         AV19ACTActSerie = "";
         AV13ACTActFech = DateTime.MinValue;
         AV14ACTActFIni = DateTime.MinValue;
         AV18ACTActOrd = "";
         AV11ACTActDocNum = "";
         P00F65_A2114ACTSGrupCod = new string[] {""} ;
         P00F65_A2108ACTHisMes = new short[1] ;
         P00F65_A2107ACTHisAno = new short[1] ;
         P00F65_A2100ACTActCod = new string[] {""} ;
         P00F65_A2103ACTGrupCod = new string[] {""} ;
         P00F65_A426ACTClaCod = new string[] {""} ;
         P00F65_n426ACTClaCod = new bool[] {false} ;
         P00F65_A2155ACTSGrupDsc = new string[] {""} ;
         P00F65_A2150ACTDetValorNeto = new decimal[1] ;
         P00F65_A2152ACTDetValorResiduo = new decimal[1] ;
         P00F65_A2143ACTDetFecIni = new DateTime[] {DateTime.MinValue} ;
         P00F65_A2154ACTDetVidaUtil = new decimal[1] ;
         P00F65_A2149ACTDetValorCompras = new decimal[1] ;
         P00F65_A2144ACTDetMarca = new string[] {""} ;
         P00F65_A2145ACTDetModelo = new string[] {""} ;
         P00F65_A2147ACTDetSerie = new string[] {""} ;
         P00F65_A79COSCod = new string[] {""} ;
         P00F65_A2104ActActItem = new string[] {""} ;
         P00F65_n2104ActActItem = new bool[] {false} ;
         A2114ACTSGrupCod = "";
         A2155ACTSGrupDsc = "";
         A2143ACTDetFecIni = DateTime.MinValue;
         A2144ACTDetMarca = "";
         A2145ACTDetModelo = "";
         A2147ACTDetSerie = "";
         A79COSCod = "";
         AV9ACTActCod = "";
         AV15ActActItem = "";
         AV34ACTSGrupDsc = "";
         AV25ACTDetFecIni = DateTime.MinValue;
         AV26ACTDetMarca = "";
         AV27ACTDetModelo = "";
         AV28ACTDetSerie = "";
         AV41CosCod = "";
         AV29ACTDetSts = "";
         P00F66_A2143ACTDetFecIni = new DateTime[] {DateTime.MinValue} ;
         P00F66_A2104ActActItem = new string[] {""} ;
         P00F66_n2104ActActItem = new bool[] {false} ;
         P00F66_A2100ACTActCod = new string[] {""} ;
         P00F66_A2150ACTDetValorNeto = new decimal[1] ;
         P00F67_A2204AMRepFec = new DateTime[] {DateTime.MinValue} ;
         P00F67_A2100ACTActCod = new string[] {""} ;
         P00F67_A2209AMRepValor = new decimal[1] ;
         P00F67_A2104ActActItem = new string[] {""} ;
         P00F67_n2104ActActItem = new bool[] {false} ;
         P00F67_A2112AMRepCod = new string[] {""} ;
         A2204AMRepFec = DateTime.MinValue;
         A2112AMRepCod = "";
         P00F68_A2218ACTRevFec = new DateTime[] {DateTime.MinValue} ;
         P00F68_A2100ACTActCod = new string[] {""} ;
         P00F68_A2217ActRevCosto = new decimal[1] ;
         P00F68_A2104ActActItem = new string[] {""} ;
         P00F68_n2104ActActItem = new bool[] {false} ;
         P00F68_A2113ACTRevCod = new string[] {""} ;
         A2218ACTRevFec = DateTime.MinValue;
         A2113ACTRevCod = "";
         P00F69_A2159ACTRetFec = new DateTime[] {DateTime.MinValue} ;
         P00F69_A2100ACTActCod = new string[] {""} ;
         P00F69_A2162ACTRetRetFec = new DateTime[] {DateTime.MinValue} ;
         P00F69_A2157ACTRetCosto = new decimal[1] ;
         P00F69_A2104ActActItem = new string[] {""} ;
         P00F69_n2104ActActItem = new bool[] {false} ;
         P00F69_A2105ACTRetCod = new string[] {""} ;
         A2159ACTRetFec = DateTime.MinValue;
         A2162ACTRetRetFec = DateTime.MinValue;
         A2105ACTRetCod = "";
         P00F610_A2175ACTABajFec = new DateTime[] {DateTime.MinValue} ;
         P00F610_A2100ACTActCod = new string[] {""} ;
         P00F610_A2177ACTBajCosto = new decimal[1] ;
         P00F610_A2104ActActItem = new string[] {""} ;
         P00F610_n2104ActActItem = new bool[] {false} ;
         P00F610_A2106ACTABajCod = new string[] {""} ;
         A2175ACTABajFec = DateTime.MinValue;
         A2106ACTABajCod = "";
         P00F611_A2143ACTDetFecIni = new DateTime[] {DateTime.MinValue} ;
         P00F611_A2104ActActItem = new string[] {""} ;
         P00F611_n2104ActActItem = new bool[] {false} ;
         P00F611_A2100ACTActCod = new string[] {""} ;
         P00F611_A2150ACTDetValorNeto = new decimal[1] ;
         P00F612_A2218ACTRevFec = new DateTime[] {DateTime.MinValue} ;
         P00F612_A2100ACTActCod = new string[] {""} ;
         P00F612_A2217ActRevCosto = new decimal[1] ;
         P00F612_A2104ActActItem = new string[] {""} ;
         P00F612_n2104ActActItem = new bool[] {false} ;
         P00F612_A2113ACTRevCod = new string[] {""} ;
         P00F613_A2204AMRepFec = new DateTime[] {DateTime.MinValue} ;
         P00F613_A2100ACTActCod = new string[] {""} ;
         P00F613_A2209AMRepValor = new decimal[1] ;
         P00F613_A2104ActActItem = new string[] {""} ;
         P00F613_n2104ActActItem = new bool[] {false} ;
         P00F613_A2112AMRepCod = new string[] {""} ;
         P00F614_A2189ACTHisDepre = new decimal[1] ;
         P00F615_A2189ACTHisDepre = new decimal[1] ;
         P00F616_A2189ACTHisDepre = new decimal[1] ;
         P00F617_A2108ACTHisMes = new short[1] ;
         P00F617_A2107ACTHisAno = new short[1] ;
         P00F617_A2104ActActItem = new string[] {""} ;
         P00F617_n2104ActActItem = new bool[] {false} ;
         P00F617_A2100ACTActCod = new string[] {""} ;
         P00F617_A2189ACTHisDepre = new decimal[1] ;
         AV42Costo = "";
         P00F618_A2100ACTActCod = new string[] {""} ;
         P00F618_A2200AMovFec = new DateTime[] {DateTime.MinValue} ;
         P00F618_A2110AMovCosCod = new string[] {""} ;
         P00F618_n2110AMovCosCod = new bool[] {false} ;
         P00F618_A2109AMovCod = new string[] {""} ;
         A2200AMovFec = DateTime.MinValue;
         A2110AMovCosCod = "";
         A2109AMovCod = "";
         P00F619_A79COSCod = new string[] {""} ;
         P00F619_A761COSDsc = new string[] {""} ;
         A761COSDsc = "";
         P00F620_A426ACTClaCod = new string[] {""} ;
         P00F620_n426ACTClaCod = new bool[] {false} ;
         P00F620_A2103ACTGrupCod = new string[] {""} ;
         P00F620_A2114ACTSGrupCod = new string[] {""} ;
         P00F620_A2104ActActItem = new string[] {""} ;
         P00F620_n2104ActActItem = new bool[] {false} ;
         P00F620_A2100ACTActCod = new string[] {""} ;
         P00F620_A2156ACTSGrupPor = new decimal[1] ;
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.activosfijos.r_resumenactivosexcel__default(),
            new Object[][] {
                new Object[] {
               P00F62_A2100ACTActCod, P00F62_A2107ACTHisAno, P00F62_A2108ACTHisMes, P00F62_A2184ACTClaDsc, P00F62_A426ACTClaCod, P00F62_A2104ActActItem
               }
               , new Object[] {
               P00F63_A2100ACTActCod, P00F63_A426ACTClaCod, P00F63_A2107ACTHisAno, P00F63_A2108ACTHisMes, P00F63_A2196ACTGrupDsc, P00F63_A2103ACTGrupCod, P00F63_A2104ActActItem
               }
               , new Object[] {
               P00F64_A2122ACTActDsc, P00F64_A2100ACTActCod, P00F64_A2108ACTHisMes, P00F64_A2107ACTHisAno, P00F64_A2103ACTGrupCod, P00F64_A426ACTClaCod, P00F64_A2118ACTActCodEQV, P00F64_A2128ACTActMarca, P00F64_A2129ACTActModelo, P00F64_A2135ACTActSerie,
               P00F64_A2123ACTActFech, P00F64_A2124ACTActFIni, P00F64_A2132ACTActOrd, P00F64_A2121ACTActDocNum, P00F64_A2104ActActItem
               }
               , new Object[] {
               P00F65_A2114ACTSGrupCod, P00F65_A2108ACTHisMes, P00F65_A2107ACTHisAno, P00F65_A2100ACTActCod, P00F65_A2103ACTGrupCod, P00F65_A426ACTClaCod, P00F65_n426ACTClaCod, P00F65_A2155ACTSGrupDsc, P00F65_A2150ACTDetValorNeto, P00F65_A2152ACTDetValorResiduo,
               P00F65_A2143ACTDetFecIni, P00F65_A2154ACTDetVidaUtil, P00F65_A2149ACTDetValorCompras, P00F65_A2144ACTDetMarca, P00F65_A2145ACTDetModelo, P00F65_A2147ACTDetSerie, P00F65_A79COSCod, P00F65_A2104ActActItem
               }
               , new Object[] {
               P00F66_A2143ACTDetFecIni, P00F66_A2104ActActItem, P00F66_A2100ACTActCod, P00F66_A2150ACTDetValorNeto
               }
               , new Object[] {
               P00F67_A2204AMRepFec, P00F67_A2100ACTActCod, P00F67_A2209AMRepValor, P00F67_A2104ActActItem, P00F67_n2104ActActItem, P00F67_A2112AMRepCod
               }
               , new Object[] {
               P00F68_A2218ACTRevFec, P00F68_A2100ACTActCod, P00F68_A2217ActRevCosto, P00F68_A2104ActActItem, P00F68_n2104ActActItem, P00F68_A2113ACTRevCod
               }
               , new Object[] {
               P00F69_A2159ACTRetFec, P00F69_A2100ACTActCod, P00F69_A2162ACTRetRetFec, P00F69_A2157ACTRetCosto, P00F69_A2104ActActItem, P00F69_n2104ActActItem, P00F69_A2105ACTRetCod
               }
               , new Object[] {
               P00F610_A2175ACTABajFec, P00F610_A2100ACTActCod, P00F610_A2177ACTBajCosto, P00F610_A2104ActActItem, P00F610_n2104ActActItem, P00F610_A2106ACTABajCod
               }
               , new Object[] {
               P00F611_A2143ACTDetFecIni, P00F611_A2104ActActItem, P00F611_A2100ACTActCod, P00F611_A2150ACTDetValorNeto
               }
               , new Object[] {
               P00F612_A2218ACTRevFec, P00F612_A2100ACTActCod, P00F612_A2217ActRevCosto, P00F612_A2104ActActItem, P00F612_n2104ActActItem, P00F612_A2113ACTRevCod
               }
               , new Object[] {
               P00F613_A2204AMRepFec, P00F613_A2100ACTActCod, P00F613_A2209AMRepValor, P00F613_A2104ActActItem, P00F613_n2104ActActItem, P00F613_A2112AMRepCod
               }
               , new Object[] {
               P00F614_A2189ACTHisDepre
               }
               , new Object[] {
               P00F615_A2189ACTHisDepre
               }
               , new Object[] {
               P00F616_A2189ACTHisDepre
               }
               , new Object[] {
               P00F617_A2108ACTHisMes, P00F617_A2107ACTHisAno, P00F617_A2104ActActItem, P00F617_A2100ACTActCod, P00F617_A2189ACTHisDepre
               }
               , new Object[] {
               P00F618_A2100ACTActCod, P00F618_A2200AMovFec, P00F618_A2110AMovCosCod, P00F618_n2110AMovCosCod, P00F618_A2109AMovCod
               }
               , new Object[] {
               P00F619_A79COSCod, P00F619_A761COSDsc
               }
               , new Object[] {
               P00F620_A426ACTClaCod, P00F620_n426ACTClaCod, P00F620_A2103ACTGrupCod, P00F620_A2114ACTSGrupCod, P00F620_A2104ActActItem, P00F620_A2100ACTActCod, P00F620_A2156ACTSGrupPor
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV35Ano ;
      private short AV63Mes ;
      private short AV60jAno ;
      private short AV62jMes ;
      private short AV61jAnoAnt ;
      private short A2107ACTHisAno ;
      private short A2108ACTHisMes ;
      private int AV38CellRow ;
      private int AV54FirstColumn ;
      private int AV59Item ;
      private decimal AV69VAAAT ;
      private decimal AV79VBCT ;
      private decimal AV97VRAAT ;
      private decimal AV81VCAAT ;
      private decimal AV93VNAT ;
      private decimal AV77VBAT ;
      private decimal AV95VOVERT ;
      private decimal AV66TVBAJA ;
      private decimal AV83VDAAAT ;
      private decimal AV88VDATT ;
      private decimal AV86VDAMAT ;
      private decimal AV90VDMAT ;
      private decimal AV70VACUMUTOTAL ;
      private decimal AV67TVLIBROS ;
      private decimal A2150ACTDetValorNeto ;
      private decimal A2152ACTDetValorResiduo ;
      private decimal A2154ACTDetVidaUtil ;
      private decimal A2149ACTDetValorCompras ;
      private decimal AV30ACTDetValorNeto ;
      private decimal AV31ACTDetValorResiduo ;
      private decimal AV32ACTDetVidaUtil ;
      private decimal AV71Valor ;
      private decimal AV21ACTActValorReparacion ;
      private decimal AV73ValorCalculo ;
      private decimal AV56ImpDepre ;
      private decimal AV68VAAAC ;
      private decimal AV78VBCC ;
      private decimal AV96VRAAC ;
      private decimal AV75VBAC ;
      private decimal AV80VCAAC ;
      private decimal AV94VOVERC ;
      private decimal AV92VNAC ;
      private decimal AV76VBAJA ;
      private decimal AV82VDAAAC ;
      private decimal AV87VDATC ;
      private decimal AV85VDAMAC ;
      private decimal AV84VDAC ;
      private decimal AV89VDMAC ;
      private decimal AV91VLIBROS ;
      private decimal A2209AMRepValor ;
      private decimal AV65Porcentaje ;
      private decimal A2217ActRevCosto ;
      private decimal A2157ACTRetCosto ;
      private decimal A2177ACTBajCosto ;
      private decimal c2189ACTHisDepre ;
      private decimal A2189ACTHisDepre ;
      private decimal A2156ACTSGrupPor ;
      private string AV64Path ;
      private string AV49FechaC ;
      private string scmdbuf ;
      private string A2155ACTSGrupDsc ;
      private string A79COSCod ;
      private string AV34ACTSGrupDsc ;
      private string AV41CosCod ;
      private string AV42Costo ;
      private string A2110AMovCosCod ;
      private string A761COSDsc ;
      private DateTime GXt_dtime2 ;
      private DateTime AV50FechaIni ;
      private DateTime AV51FechaUlt ;
      private DateTime GXt_date1 ;
      private DateTime A2123ACTActFech ;
      private DateTime A2124ACTActFIni ;
      private DateTime AV13ACTActFech ;
      private DateTime AV14ACTActFIni ;
      private DateTime A2143ACTDetFecIni ;
      private DateTime AV25ACTDetFecIni ;
      private DateTime A2204AMRepFec ;
      private DateTime A2218ACTRevFec ;
      private DateTime A2159ACTRetFec ;
      private DateTime A2162ACTRetRetFec ;
      private DateTime A2175ACTABajFec ;
      private DateTime A2200AMovFec ;
      private bool returnInSub ;
      private bool BRKF62 ;
      private bool n426ACTClaCod ;
      private bool n2104ActActItem ;
      private bool BRKF64 ;
      private bool BRKF66 ;
      private bool n2110AMovCosCod ;
      private string AV23ACTClaCod ;
      private string AV33ACTGrupCod ;
      private string AV52Filename ;
      private string AV47ErrorMessage ;
      private string AV53FilenameOrigen ;
      private string A426ACTClaCod ;
      private string A2100ACTActCod ;
      private string A2184ACTClaDsc ;
      private string A2104ActActItem ;
      private string AV39Clase ;
      private string AV24ACTClaDsc ;
      private string A2103ACTGrupCod ;
      private string A2196ACTGrupDsc ;
      private string W426ACTClaCod ;
      private string AV55Grupo ;
      private string AV8ACTGrupDsc ;
      private string A2122ACTActDsc ;
      private string A2118ACTActCodEQV ;
      private string A2128ACTActMarca ;
      private string A2129ACTActModelo ;
      private string A2135ACTActSerie ;
      private string A2132ACTActOrd ;
      private string A2121ACTActDocNum ;
      private string AV40Codigo ;
      private string AV10ACTActCodEQV ;
      private string AV12ACTActDsc ;
      private string AV16ACTActMarca ;
      private string AV17ACTActModelo ;
      private string AV19ACTActSerie ;
      private string AV18ACTActOrd ;
      private string AV11ACTActDocNum ;
      private string A2114ACTSGrupCod ;
      private string A2144ACTDetMarca ;
      private string A2145ACTDetModelo ;
      private string A2147ACTDetSerie ;
      private string AV9ACTActCod ;
      private string AV15ActActItem ;
      private string AV26ACTDetMarca ;
      private string AV27ACTDetModelo ;
      private string AV28ACTDetSerie ;
      private string AV29ACTDetSts ;
      private string A2112AMRepCod ;
      private string A2113ACTRevCod ;
      private string A2105ACTRetCod ;
      private string A2106ACTABajCod ;
      private string A2109AMovCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ACTClaCod ;
      private string aP1_ACTGrupCod ;
      private short aP2_Ano ;
      private short aP3_Mes ;
      private IDataStoreProvider pr_default ;
      private string[] P00F62_A2100ACTActCod ;
      private short[] P00F62_A2107ACTHisAno ;
      private short[] P00F62_A2108ACTHisMes ;
      private string[] P00F62_A2184ACTClaDsc ;
      private string[] P00F62_A426ACTClaCod ;
      private bool[] P00F62_n426ACTClaCod ;
      private string[] P00F62_A2104ActActItem ;
      private bool[] P00F62_n2104ActActItem ;
      private string[] P00F63_A2100ACTActCod ;
      private string[] P00F63_A426ACTClaCod ;
      private bool[] P00F63_n426ACTClaCod ;
      private short[] P00F63_A2107ACTHisAno ;
      private short[] P00F63_A2108ACTHisMes ;
      private string[] P00F63_A2196ACTGrupDsc ;
      private string[] P00F63_A2103ACTGrupCod ;
      private string[] P00F63_A2104ActActItem ;
      private bool[] P00F63_n2104ActActItem ;
      private string[] P00F64_A2122ACTActDsc ;
      private string[] P00F64_A2100ACTActCod ;
      private short[] P00F64_A2108ACTHisMes ;
      private short[] P00F64_A2107ACTHisAno ;
      private string[] P00F64_A2103ACTGrupCod ;
      private string[] P00F64_A426ACTClaCod ;
      private bool[] P00F64_n426ACTClaCod ;
      private string[] P00F64_A2118ACTActCodEQV ;
      private string[] P00F64_A2128ACTActMarca ;
      private string[] P00F64_A2129ACTActModelo ;
      private string[] P00F64_A2135ACTActSerie ;
      private DateTime[] P00F64_A2123ACTActFech ;
      private DateTime[] P00F64_A2124ACTActFIni ;
      private string[] P00F64_A2132ACTActOrd ;
      private string[] P00F64_A2121ACTActDocNum ;
      private string[] P00F64_A2104ActActItem ;
      private bool[] P00F64_n2104ActActItem ;
      private string[] P00F65_A2114ACTSGrupCod ;
      private short[] P00F65_A2108ACTHisMes ;
      private short[] P00F65_A2107ACTHisAno ;
      private string[] P00F65_A2100ACTActCod ;
      private string[] P00F65_A2103ACTGrupCod ;
      private string[] P00F65_A426ACTClaCod ;
      private bool[] P00F65_n426ACTClaCod ;
      private string[] P00F65_A2155ACTSGrupDsc ;
      private decimal[] P00F65_A2150ACTDetValorNeto ;
      private decimal[] P00F65_A2152ACTDetValorResiduo ;
      private DateTime[] P00F65_A2143ACTDetFecIni ;
      private decimal[] P00F65_A2154ACTDetVidaUtil ;
      private decimal[] P00F65_A2149ACTDetValorCompras ;
      private string[] P00F65_A2144ACTDetMarca ;
      private string[] P00F65_A2145ACTDetModelo ;
      private string[] P00F65_A2147ACTDetSerie ;
      private string[] P00F65_A79COSCod ;
      private string[] P00F65_A2104ActActItem ;
      private bool[] P00F65_n2104ActActItem ;
      private DateTime[] P00F66_A2143ACTDetFecIni ;
      private string[] P00F66_A2104ActActItem ;
      private bool[] P00F66_n2104ActActItem ;
      private string[] P00F66_A2100ACTActCod ;
      private decimal[] P00F66_A2150ACTDetValorNeto ;
      private DateTime[] P00F67_A2204AMRepFec ;
      private string[] P00F67_A2100ACTActCod ;
      private decimal[] P00F67_A2209AMRepValor ;
      private string[] P00F67_A2104ActActItem ;
      private bool[] P00F67_n2104ActActItem ;
      private string[] P00F67_A2112AMRepCod ;
      private DateTime[] P00F68_A2218ACTRevFec ;
      private string[] P00F68_A2100ACTActCod ;
      private decimal[] P00F68_A2217ActRevCosto ;
      private string[] P00F68_A2104ActActItem ;
      private bool[] P00F68_n2104ActActItem ;
      private string[] P00F68_A2113ACTRevCod ;
      private DateTime[] P00F69_A2159ACTRetFec ;
      private string[] P00F69_A2100ACTActCod ;
      private DateTime[] P00F69_A2162ACTRetRetFec ;
      private decimal[] P00F69_A2157ACTRetCosto ;
      private string[] P00F69_A2104ActActItem ;
      private bool[] P00F69_n2104ActActItem ;
      private string[] P00F69_A2105ACTRetCod ;
      private DateTime[] P00F610_A2175ACTABajFec ;
      private string[] P00F610_A2100ACTActCod ;
      private decimal[] P00F610_A2177ACTBajCosto ;
      private string[] P00F610_A2104ActActItem ;
      private bool[] P00F610_n2104ActActItem ;
      private string[] P00F610_A2106ACTABajCod ;
      private DateTime[] P00F611_A2143ACTDetFecIni ;
      private string[] P00F611_A2104ActActItem ;
      private bool[] P00F611_n2104ActActItem ;
      private string[] P00F611_A2100ACTActCod ;
      private decimal[] P00F611_A2150ACTDetValorNeto ;
      private DateTime[] P00F612_A2218ACTRevFec ;
      private string[] P00F612_A2100ACTActCod ;
      private decimal[] P00F612_A2217ActRevCosto ;
      private string[] P00F612_A2104ActActItem ;
      private bool[] P00F612_n2104ActActItem ;
      private string[] P00F612_A2113ACTRevCod ;
      private DateTime[] P00F613_A2204AMRepFec ;
      private string[] P00F613_A2100ACTActCod ;
      private decimal[] P00F613_A2209AMRepValor ;
      private string[] P00F613_A2104ActActItem ;
      private bool[] P00F613_n2104ActActItem ;
      private string[] P00F613_A2112AMRepCod ;
      private decimal[] P00F614_A2189ACTHisDepre ;
      private decimal[] P00F615_A2189ACTHisDepre ;
      private decimal[] P00F616_A2189ACTHisDepre ;
      private short[] P00F617_A2108ACTHisMes ;
      private short[] P00F617_A2107ACTHisAno ;
      private string[] P00F617_A2104ActActItem ;
      private bool[] P00F617_n2104ActActItem ;
      private string[] P00F617_A2100ACTActCod ;
      private decimal[] P00F617_A2189ACTHisDepre ;
      private string[] P00F618_A2100ACTActCod ;
      private DateTime[] P00F618_A2200AMovFec ;
      private string[] P00F618_A2110AMovCosCod ;
      private bool[] P00F618_n2110AMovCosCod ;
      private string[] P00F618_A2109AMovCod ;
      private string[] P00F619_A79COSCod ;
      private string[] P00F619_A761COSDsc ;
      private string[] P00F620_A426ACTClaCod ;
      private bool[] P00F620_n426ACTClaCod ;
      private string[] P00F620_A2103ACTGrupCod ;
      private string[] P00F620_A2114ACTSGrupCod ;
      private string[] P00F620_A2104ActActItem ;
      private bool[] P00F620_n2104ActActItem ;
      private string[] P00F620_A2100ACTActCod ;
      private decimal[] P00F620_A2156ACTSGrupPor ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV48ExcelDocument ;
      private GxFile AV36Archivo ;
   }

   public class r_resumenactivosexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00F62( IGxContext context ,
                                             string AV23ACTClaCod ,
                                             string A426ACTClaCod ,
                                             short A2107ACTHisAno ,
                                             short AV35Ano ,
                                             short A2108ACTHisMes ,
                                             short AV63Mes )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[3];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[ACTActCod], T1.[ACTHisAno], T1.[ACTHisMes], T3.[ACTClaDsc], T2.[ACTClaCod], T1.[ActActItem] FROM (([ACTCOSTODEP] T1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod]) INNER JOIN [ACTCLASE] T3 ON T3.[ACTClaCod] = T2.[ACTClaCod])";
         AddWhere(sWhereString, "(T1.[ACTHisAno] = @AV35Ano)");
         AddWhere(sWhereString, "(T1.[ACTHisMes] = @AV63Mes)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ACTClaCod)) )
         {
            AddWhere(sWhereString, "(T2.[ACTClaCod] = @AV23ACTClaCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[ACTClaCod], T3.[ACTClaDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00F63( IGxContext context ,
                                             string AV33ACTGrupCod ,
                                             string A2103ACTGrupCod ,
                                             short A2107ACTHisAno ,
                                             short AV35Ano ,
                                             short A2108ACTHisMes ,
                                             short AV63Mes ,
                                             string AV39Clase ,
                                             string A426ACTClaCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[4];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[ACTActCod], T2.[ACTClaCod], T1.[ACTHisAno], T1.[ACTHisMes], T3.[ACTGrupDsc], T2.[ACTGrupCod], T1.[ActActItem] FROM (([ACTCOSTODEP] T1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod]) INNER JOIN [ACTGRUPO] T3 ON T3.[ACTClaCod] = T2.[ACTClaCod] AND T3.[ACTGrupCod] = T2.[ACTGrupCod])";
         AddWhere(sWhereString, "(T2.[ACTClaCod] = @AV39Clase)");
         AddWhere(sWhereString, "(T1.[ACTHisAno] = @AV35Ano)");
         AddWhere(sWhereString, "(T1.[ACTHisMes] = @AV63Mes)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ACTGrupCod)) )
         {
            AddWhere(sWhereString, "(T2.[ACTGrupCod] = @AV33ACTGrupCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[ACTClaCod], T2.[ACTGrupCod], T3.[ACTGrupDsc]";
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
                     return conditional_P00F62(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] );
               case 1 :
                     return conditional_P00F63(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] );
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00F64;
          prmP00F64 = new Object[] {
          new ParDef("@AV39Clase",GXType.NVarChar,5,0) ,
          new ParDef("@AV55Grupo",GXType.NVarChar,5,0) ,
          new ParDef("@AV35Ano",GXType.Int16,4,0) ,
          new ParDef("@AV63Mes",GXType.Int16,2,0)
          };
          Object[] prmP00F65;
          prmP00F65 = new Object[] {
          new ParDef("@AV35Ano",GXType.Int16,4,0) ,
          new ParDef("@AV63Mes",GXType.Int16,2,0) ,
          new ParDef("@AV40Codigo",GXType.NVarChar,20,0) ,
          new ParDef("@AV39Clase",GXType.NVarChar,5,0) ,
          new ParDef("@AV55Grupo",GXType.NVarChar,5,0)
          };
          Object[] prmP00F66;
          prmP00F66 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV15ActActItem",GXType.NVarChar,5,0) ,
          new ParDef("@AV35Ano",GXType.Int16,4,0)
          };
          Object[] prmP00F67;
          prmP00F67 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV35Ano",GXType.Int16,4,0) ,
          new ParDef("@AV25ACTDetFecIni",GXType.Date,8,0)
          };
          Object[] prmP00F68;
          prmP00F68 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV35Ano",GXType.Int16,4,0) ,
          new ParDef("@AV25ACTDetFecIni",GXType.Date,8,0)
          };
          Object[] prmP00F69;
          prmP00F69 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV35Ano",GXType.Int16,4,0) ,
          new ParDef("@AV51FechaUlt",GXType.Date,8,0) ,
          new ParDef("@AV25ACTDetFecIni",GXType.Date,8,0)
          };
          Object[] prmP00F610;
          prmP00F610 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV35Ano",GXType.Int16,4,0) ,
          new ParDef("@AV51FechaUlt",GXType.Date,8,0) ,
          new ParDef("@AV25ACTDetFecIni",GXType.Date,8,0)
          };
          Object[] prmP00F611;
          prmP00F611 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV15ActActItem",GXType.NVarChar,5,0) ,
          new ParDef("@AV35Ano",GXType.Int16,4,0) ,
          new ParDef("@AV51FechaUlt",GXType.Date,8,0)
          };
          Object[] prmP00F612;
          prmP00F612 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV35Ano",GXType.Int16,4,0) ,
          new ParDef("@AV51FechaUlt",GXType.Date,8,0) ,
          new ParDef("@AV25ACTDetFecIni",GXType.Date,8,0)
          };
          Object[] prmP00F613;
          prmP00F613 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV35Ano",GXType.Int16,4,0) ,
          new ParDef("@AV51FechaUlt",GXType.Date,8,0)
          };
          Object[] prmP00F614;
          prmP00F614 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV15ActActItem",GXType.NVarChar,5,0) ,
          new ParDef("@AV35Ano",GXType.Int16,4,0)
          };
          Object[] prmP00F615;
          prmP00F615 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV15ActActItem",GXType.NVarChar,5,0) ,
          new ParDef("@AV51FechaUlt",GXType.Date,8,0) ,
          new ParDef("@AV35Ano",GXType.Int16,4,0)
          };
          Object[] prmP00F616;
          prmP00F616 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV15ActActItem",GXType.NVarChar,5,0) ,
          new ParDef("@AV35Ano",GXType.Int16,4,0) ,
          new ParDef("@AV50FechaIni",GXType.Date,8,0)
          };
          Object[] prmP00F617;
          prmP00F617 = new Object[] {
          new ParDef("@AV35Ano",GXType.Int16,4,0) ,
          new ParDef("@AV63Mes",GXType.Int16,2,0) ,
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV15ActActItem",GXType.NVarChar,5,0)
          };
          Object[] prmP00F618;
          prmP00F618 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV51FechaUlt",GXType.Date,8,0)
          };
          Object[] prmP00F619;
          prmP00F619 = new Object[] {
          new ParDef("@AV41CosCod",GXType.NChar,10,0)
          };
          Object[] prmP00F620;
          prmP00F620 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV15ActActItem",GXType.NVarChar,5,0)
          };
          Object[] prmP00F62;
          prmP00F62 = new Object[] {
          new ParDef("@AV35Ano",GXType.Int16,4,0) ,
          new ParDef("@AV63Mes",GXType.Int16,2,0) ,
          new ParDef("@AV23ACTClaCod",GXType.NVarChar,5,0)
          };
          Object[] prmP00F63;
          prmP00F63 = new Object[] {
          new ParDef("@AV39Clase",GXType.NVarChar,5,0) ,
          new ParDef("@AV35Ano",GXType.Int16,4,0) ,
          new ParDef("@AV63Mes",GXType.Int16,2,0) ,
          new ParDef("@AV33ACTGrupCod",GXType.NVarChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00F62", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F62,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F63", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F63,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F64", "SELECT T2.[ACTActDsc], T1.[ACTActCod], T1.[ACTHisMes], T1.[ACTHisAno], T2.[ACTGrupCod], T2.[ACTClaCod], T2.[ACTActCodEQV], T2.[ACTActMarca], T2.[ACTActModelo], T2.[ACTActSerie], T2.[ACTActFech], T2.[ACTActFIni], T2.[ACTActOrd], T2.[ACTActDocNum], T1.[ActActItem] FROM ([ACTCOSTODEP] T1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod]) WHERE (T2.[ACTClaCod] = @AV39Clase) AND (T2.[ACTGrupCod] = @AV55Grupo) AND (T1.[ACTHisAno] = @AV35Ano) AND (T1.[ACTHisMes] = @AV63Mes) ORDER BY T1.[ACTActCod], T2.[ACTActDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F64,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F65", "SELECT T3.[ACTSGrupCod], T1.[ACTHisMes], T1.[ACTHisAno], T1.[ACTActCod], T2.[ACTGrupCod], T2.[ACTClaCod], T4.[ACTSGrupDsc], T3.[ACTDetValorNeto], T3.[ACTDetValorResiduo], T3.[ACTDetFecIni], T3.[ACTDetVidaUtil], T3.[ACTDetValorCompras], T3.[ACTDetMarca], T3.[ACTDetModelo], T3.[ACTDetSerie], T2.[COSCod], T1.[ActActItem] FROM ((([ACTCOSTODEP] T1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod]) INNER JOIN [ACTACTIVOSDET] T3 ON T3.[ACTActCod] = T1.[ACTActCod] AND T3.[ActActItem] = T1.[ActActItem]) LEFT JOIN [ACTSUBGRUPO] T4 ON T4.[ACTClaCod] = T2.[ACTClaCod] AND T4.[ACTGrupCod] = T2.[ACTGrupCod] AND T4.[ACTSGrupCod] = T3.[ACTSGrupCod]) WHERE (T1.[ACTHisAno] = @AV35Ano and T1.[ACTHisMes] = @AV63Mes and T1.[ACTActCod] = @AV40Codigo) AND (T2.[ACTClaCod] = @AV39Clase) AND (T2.[ACTGrupCod] = @AV55Grupo) ORDER BY T1.[ACTHisAno], T1.[ACTHisMes], T1.[ACTActCod], T1.[ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F65,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F66", "SELECT [ACTDetFecIni], [ActActItem], [ACTActCod], [ACTDetValorNeto] FROM [ACTACTIVOSDET] WHERE ([ACTActCod] = @AV9ACTActCod and [ActActItem] = @AV15ActActItem) AND (YEAR([ACTDetFecIni]) < @AV35Ano) ORDER BY [ACTActCod], [ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F66,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F67", "SELECT [AMRepFec], [ACTActCod], [AMRepValor], [ActActItem], [AMRepCod] FROM [ACTMOVREPARACION] WHERE ([ACTActCod] = @AV9ACTActCod) AND (YEAR([AMRepFec]) < @AV35Ano) AND ([AMRepFec] > @AV25ACTDetFecIni) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F67,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F68", "SELECT [ACTRevFec], [ACTActCod], [ActRevCosto], [ActActItem], [ACTRevCod] FROM [ACTRevaluacion] WHERE ([ACTActCod] = @AV9ACTActCod) AND (YEAR([ACTRevFec]) < @AV35Ano) AND ([ACTRevFec] > @AV25ACTDetFecIni) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F68,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F69", "SELECT [ACTRetFec], [ACTActCod], [ACTRetRetFec], [ACTRetCosto], [ActActItem], [ACTRetCod] FROM [ACTRETIROACTIVO] WHERE ([ACTActCod] = @AV9ACTActCod) AND (YEAR([ACTRetFec]) = @AV35Ano) AND ([ACTRetFec] <= @AV51FechaUlt) AND ([ACTRetFec] > @AV25ACTDetFecIni) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F69,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F610", "SELECT [ACTABajFec], [ACTActCod], [ACTBajCosto], [ActActItem], [ACTABajCod] FROM [ACTBAJAACTIVO] WHERE ([ACTActCod] = @AV9ACTActCod) AND (YEAR([ACTABajFec]) = @AV35Ano) AND ([ACTABajFec] <= @AV51FechaUlt) AND ([ACTABajFec] > @AV25ACTDetFecIni) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F610,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F611", "SELECT [ACTDetFecIni], [ActActItem], [ACTActCod], [ACTDetValorNeto] FROM [ACTACTIVOSDET] WHERE ([ACTActCod] = @AV9ACTActCod and [ActActItem] = @AV15ActActItem) AND (YEAR([ACTDetFecIni]) = @AV35Ano) AND ([ACTDetFecIni] <= @AV51FechaUlt) ORDER BY [ACTActCod], [ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F611,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F612", "SELECT [ACTRevFec], [ACTActCod], [ActRevCosto], [ActActItem], [ACTRevCod] FROM [ACTRevaluacion] WHERE ([ACTActCod] = @AV9ACTActCod) AND (YEAR([ACTRevFec]) = @AV35Ano) AND ([ACTRevFec] <= @AV51FechaUlt) AND ([ACTRevFec] > @AV25ACTDetFecIni) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F612,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F613", "SELECT [AMRepFec], [ACTActCod], [AMRepValor], [ActActItem], [AMRepCod] FROM [ACTMOVREPARACION] WHERE ([ACTActCod] = @AV9ACTActCod) AND (YEAR([AMRepFec]) = @AV35Ano) AND ([AMRepFec] <= @AV51FechaUlt) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F613,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F614", "SELECT SUM([ACTHisDepre]) FROM [ACTCOSTODEP] WHERE ([ACTActCod] = @AV9ACTActCod and [ActActItem] = @AV15ActActItem) AND ([ACTHisAno] < @AV35Ano) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F614,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F615", "SELECT SUM([ACTHisDepre]) FROM [ACTCOSTODEP] WHERE ([ACTActCod] = @AV9ACTActCod and [ActActItem] = @AV15ActActItem) AND ([ActHisFec] <= @AV51FechaUlt) AND ([ACTHisAno] = @AV35Ano) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F615,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F616", "SELECT SUM([ACTHisDepre]) FROM [ACTCOSTODEP] WHERE ([ACTActCod] = @AV9ACTActCod and [ActActItem] = @AV15ActActItem) AND (YEAR([ActHisFec]) = @AV35Ano) AND ([ActHisFec] < @AV50FechaIni) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F616,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F617", "SELECT [ACTHisMes], [ACTHisAno], [ActActItem], [ACTActCod], [ACTHisDepre] FROM [ACTCOSTODEP] WHERE [ACTHisAno] = @AV35Ano and [ACTHisMes] = @AV63Mes and [ACTActCod] = @AV9ACTActCod and [ActActItem] = @AV15ActActItem ORDER BY [ACTHisAno], [ACTHisMes], [ACTActCod], [ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F617,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F618", "SELECT [ACTActCod], [AMovFec], [AMovCosCod], [AMovCod] FROM [ACTMOVACTIVO] WHERE ([ACTActCod] = @AV9ACTActCod) AND ([AMovFec] <= @AV51FechaUlt) ORDER BY [AMovFec] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F618,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F619", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV41CosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F619,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F620", "SELECT T1.[ACTClaCod], T1.[ACTGrupCod], T1.[ACTSGrupCod], T1.[ActActItem], T1.[ACTActCod], T2.[ACTSGrupPor] FROM ([ACTACTIVOSDET] T1 LEFT JOIN [ACTSUBGRUPO] T2 ON T2.[ACTClaCod] = T1.[ACTClaCod] AND T2.[ACTGrupCod] = T1.[ACTGrupCod] AND T2.[ACTSGrupCod] = T1.[ACTSGrupCod]) WHERE T1.[ACTActCod] = @AV9ACTActCod and T1.[ActActItem] = @AV15ActActItem ORDER BY T1.[ACTActCod], T1.[ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F620,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((string[]) buf[13])[0] = rslt.getVarchar(13);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((string[]) buf[15])[0] = rslt.getVarchar(15);
                ((string[]) buf[16])[0] = rslt.getString(16, 10);
                ((string[]) buf[17])[0] = rslt.getVarchar(17);
                return;
             case 4 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 5 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
             case 6 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
             case 7 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                return;
             case 8 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
             case 9 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 10 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
             case 11 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
             case 12 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
             case 13 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
             case 14 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                return;
       }
    }

 }

}
