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
   public class r_resumenpresupuestomensualexcel : GXProcedure
   {
      public r_resumenpresupuestomensualexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenpresupuestomensualexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref int aP2_CBTipPre ,
                           ref string aP3_TipoDetalle ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV8Ano = aP0_Ano;
         this.AV38Mes = aP1_Mes;
         this.AV18CBTipPre = aP2_CBTipPre;
         this.AV43TipoDetalle = aP3_TipoDetalle;
         this.AV26Filename = "" ;
         this.AV24ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV38Mes;
         aP2_CBTipPre=this.AV18CBTipPre;
         aP3_TipoDetalle=this.AV43TipoDetalle;
         aP4_Filename=this.AV26Filename;
         aP5_ErrorMessage=this.AV24ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                ref int aP2_CBTipPre ,
                                ref string aP3_TipoDetalle ,
                                out string aP4_Filename )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_CBTipPre, ref aP3_TipoDetalle, out aP4_Filename, out aP5_ErrorMessage);
         return AV24ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref int aP2_CBTipPre ,
                                 ref string aP3_TipoDetalle ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         r_resumenpresupuestomensualexcel objr_resumenpresupuestomensualexcel;
         objr_resumenpresupuestomensualexcel = new r_resumenpresupuestomensualexcel();
         objr_resumenpresupuestomensualexcel.AV8Ano = aP0_Ano;
         objr_resumenpresupuestomensualexcel.AV38Mes = aP1_Mes;
         objr_resumenpresupuestomensualexcel.AV18CBTipPre = aP2_CBTipPre;
         objr_resumenpresupuestomensualexcel.AV43TipoDetalle = aP3_TipoDetalle;
         objr_resumenpresupuestomensualexcel.AV26Filename = "" ;
         objr_resumenpresupuestomensualexcel.AV24ErrorMessage = "" ;
         objr_resumenpresupuestomensualexcel.context.SetSubmitInitialConfig(context);
         objr_resumenpresupuestomensualexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenpresupuestomensualexcel);
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV38Mes;
         aP2_CBTipPre=this.AV18CBTipPre;
         aP3_TipoDetalle=this.AV43TipoDetalle;
         aP4_Filename=this.AV26Filename;
         aP5_ErrorMessage=this.AV24ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenpresupuestomensualexcel)stateInfo).executePrivate();
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
         AV9Archivo.Source = "Excel/PlantillasPresupuestoMensual.xlsx";
         AV40Path = AV9Archivo.GetPath();
         AV27FilenameOrigen = StringUtil.Trim( AV40Path) + "\\PlantillasPresupuestoMensual.xlsx";
         AV26Filename = "Excel/PresupuestoMensual" + ".xlsx";
         AV25ExcelDocument.Clear();
         AV25ExcelDocument.Template = AV27FilenameOrigen;
         AV25ExcelDocument.Open(AV26Filename);
         /* Using cursor P00CV2 */
         pr_default.execute(0, new Object[] {AV18CBTipPre});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2280CBTipPre = P00CV2_A2280CBTipPre[0];
            A2291CBTipPreDsc = P00CV2_A2291CBTipPreDsc[0];
            A180MonCod = P00CV2_A180MonCod[0];
            AV45Titulo = StringUtil.Trim( A2291CBTipPreDsc);
            AV39MonCod = A180MonCod;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV25ExcelDocument.get_Cells(3, 1, 1, 1).Text = StringUtil.Trim( AV45Titulo);
         AV20CellRow = 5;
         AV28FirstColumn = 1;
         AV29i = 1;
         AV44TipoPresupuesto = "";
         while ( AV29i <= 2 )
         {
            if ( AV29i == 1 )
            {
               AV42Tip = "I";
               AV44TipoPresupuesto = "INGRESO";
            }
            if ( AV29i == 2 )
            {
               AV42Tip = "E";
               AV44TipoPresupuesto = "EGRESO";
            }
            AV37ImpTPre = 0.00m;
            AV35ImpTEje = 0.00m;
            AV34ImpTDif = 0.00m;
            /* Using cursor P00CV3 */
            pr_default.execute(1, new Object[] {AV18CBTipPre, AV42Tip});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A2281CBTipTipo = P00CV3_A2281CBTipTipo[0];
               A2280CBTipPre = P00CV3_A2280CBTipPre[0];
               A2282CBLinPre = P00CV3_A2282CBLinPre[0];
               A2289CBLinPreDsc = P00CV3_A2289CBLinPreDsc[0];
               AV10CBLinPre = A2282CBLinPre;
               AV11CBLinPreDsc = A2289CBLinPreDsc;
               AV16CBRubPre = 0;
               AV33ImpPre = 0.00m;
               AV31ImpEje = 0.00m;
               AV30ImpDif = 0.00m;
               AV32ImpPor = 0.00m;
               /* Execute user subroutine: 'SUBTOTALLINEA' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               AV30ImpDif = (decimal)(AV33ImpPre-AV31ImpEje);
               AV32ImpPor = ((Convert.ToDecimal(0)==AV33ImpPre) ? (decimal)(0) : NumberUtil.Round( (AV31ImpEje/ (decimal)(AV33ImpPre))*100, 2));
               /* Execute user subroutine: 'DETALLELINEAS' */
               S151 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               AV37ImpTPre = (decimal)(AV37ImpTPre+AV33ImpPre);
               AV35ImpTEje = (decimal)(AV35ImpTEje+AV31ImpEje);
               AV34ImpTDif = (decimal)(AV34ImpTDif+AV30ImpDif);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TipoDetalle)) )
               {
                  /* Execute user subroutine: 'RUBROS' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     this.cleanup();
                     if (true) return;
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV29i == 1 )
            {
               AV44TipoPresupuesto = "TOTAL INGRESO";
            }
            if ( AV29i == 2 )
            {
               AV44TipoPresupuesto = "TOTAL EGRESO";
            }
            AV34ImpTDif = (decimal)(AV37ImpTPre-AV35ImpTEje);
            AV36ImpTPor = ((Convert.ToDecimal(0)==AV37ImpTPre) ? (decimal)(0) : NumberUtil.Round( (AV35ImpTEje/ (decimal)(AV37ImpTPre))*100, 2));
            AV29i = (long)(AV29i+1);
         }
         AV25ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV25ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'RUBROS' Routine */
         returnInSub = false;
         /* Using cursor P00CV4 */
         pr_default.execute(2, new Object[] {AV18CBTipPre, AV42Tip, AV10CBLinPre});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A2282CBLinPre = P00CV4_A2282CBLinPre[0];
            A2281CBTipTipo = P00CV4_A2281CBTipTipo[0];
            A2280CBTipPre = P00CV4_A2280CBTipPre[0];
            A2283CBRubPre = P00CV4_A2283CBRubPre[0];
            A2293CBRubPreDsc = P00CV4_A2293CBRubPreDsc[0];
            AV16CBRubPre = A2283CBRubPre;
            AV17CBRubPreDsc = A2293CBRubPreDsc;
            AV15CBRImpPre = 0.00m;
            AV13CBRImpEje = 0.00m;
            AV12CBRImpDif = 0.00m;
            AV14CBRImpPor = 0.00m;
            /* Execute user subroutine: 'SUBTOTALRUBROS' */
            S124 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            AV12CBRImpDif = (decimal)(AV15CBRImpPre-AV13CBRImpEje);
            AV14CBRImpPor = ((Convert.ToDecimal(0)==AV15CBRImpPre) ? (decimal)(0) : NumberUtil.Round( (AV13CBRImpEje/ (decimal)(AV15CBRImpPre))*100, 2));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S131( )
      {
         /* 'SUBTOTALLINEA' Routine */
         returnInSub = false;
         /* Using cursor P00CV5 */
         pr_default.execute(3, new Object[] {AV18CBTipPre, AV42Tip, AV10CBLinPre, AV8Ano});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A2285CBRubPreAno = P00CV5_A2285CBRubPreAno[0];
            A2282CBLinPre = P00CV5_A2282CBLinPre[0];
            A2281CBTipTipo = P00CV5_A2281CBTipTipo[0];
            A2280CBTipPre = P00CV5_A2280CBTipPre[0];
            A2296CBRubPreEne = P00CV5_A2296CBRubPreEne[0];
            A2297CBRubPreFeb = P00CV5_A2297CBRubPreFeb[0];
            A2298CBRubPreMar = P00CV5_A2298CBRubPreMar[0];
            A2299CBRubPreAbr = P00CV5_A2299CBRubPreAbr[0];
            A2300CBRubPreMay = P00CV5_A2300CBRubPreMay[0];
            A2301CBRubPreJun = P00CV5_A2301CBRubPreJun[0];
            A2302CBRubPreJul = P00CV5_A2302CBRubPreJul[0];
            A2303CBRubPreAgo = P00CV5_A2303CBRubPreAgo[0];
            A2304CBRubPreSep = P00CV5_A2304CBRubPreSep[0];
            A2305CBRubPreOct = P00CV5_A2305CBRubPreOct[0];
            A2306CBRubPreNov = P00CV5_A2306CBRubPreNov[0];
            A2307CBRubPreDic = P00CV5_A2307CBRubPreDic[0];
            A2283CBRubPre = P00CV5_A2283CBRubPre[0];
            if ( AV38Mes == 1 )
            {
               AV33ImpPre = (decimal)(AV33ImpPre+A2296CBRubPreEne);
            }
            if ( AV38Mes == 2 )
            {
               AV33ImpPre = (decimal)(AV33ImpPre+A2297CBRubPreFeb);
            }
            if ( AV38Mes == 3 )
            {
               AV33ImpPre = (decimal)(AV33ImpPre+A2298CBRubPreMar);
            }
            if ( AV38Mes == 4 )
            {
               AV33ImpPre = (decimal)(AV33ImpPre+A2299CBRubPreAbr);
            }
            if ( AV38Mes == 5 )
            {
               AV33ImpPre = (decimal)(AV33ImpPre+A2300CBRubPreMay);
            }
            if ( AV38Mes == 6 )
            {
               AV33ImpPre = (decimal)(AV33ImpPre+A2301CBRubPreJun);
            }
            if ( AV38Mes == 7 )
            {
               AV33ImpPre = (decimal)(AV33ImpPre+A2302CBRubPreJul);
            }
            if ( AV38Mes == 8 )
            {
               AV33ImpPre = (decimal)(AV33ImpPre+A2303CBRubPreAgo);
            }
            if ( AV38Mes == 9 )
            {
               AV33ImpPre = (decimal)(AV33ImpPre+A2304CBRubPreSep);
            }
            if ( AV38Mes == 10 )
            {
               AV33ImpPre = (decimal)(AV33ImpPre+A2305CBRubPreOct);
            }
            if ( AV38Mes == 11 )
            {
               AV33ImpPre = (decimal)(AV33ImpPre+A2306CBRubPreNov);
            }
            if ( AV38Mes == 12 )
            {
               AV33ImpPre = (decimal)(AV33ImpPre+A2307CBRubPreDic);
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV31ImpEje = 0.00m;
         /* Using cursor P00CV6 */
         pr_default.execute(4, new Object[] {AV18CBTipPre, AV42Tip, AV10CBLinPre});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A2282CBLinPre = P00CV6_A2282CBLinPre[0];
            A2281CBTipTipo = P00CV6_A2281CBTipTipo[0];
            A2280CBTipPre = P00CV6_A2280CBTipPre[0];
            A91CueCod = P00CV6_A91CueCod[0];
            A79COSCod = P00CV6_A79COSCod[0];
            n79COSCod = P00CV6_n79COSCod[0];
            A2283CBRubPre = P00CV6_A2283CBRubPre[0];
            A2284CBRubDItem = P00CV6_A2284CBRubDItem[0];
            AV22CueCod = A91CueCod;
            AV21CosCod = A79COSCod;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S146 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            AV31ImpEje = (decimal)(AV31ImpEje+AV41Saldo);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S124( )
      {
         /* 'SUBTOTALRUBROS' Routine */
         returnInSub = false;
         /* Using cursor P00CV7 */
         pr_default.execute(5, new Object[] {AV18CBTipPre, AV42Tip, AV10CBLinPre, AV16CBRubPre, AV8Ano});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A2285CBRubPreAno = P00CV7_A2285CBRubPreAno[0];
            A2283CBRubPre = P00CV7_A2283CBRubPre[0];
            A2282CBLinPre = P00CV7_A2282CBLinPre[0];
            A2281CBTipTipo = P00CV7_A2281CBTipTipo[0];
            A2280CBTipPre = P00CV7_A2280CBTipPre[0];
            A2296CBRubPreEne = P00CV7_A2296CBRubPreEne[0];
            A2297CBRubPreFeb = P00CV7_A2297CBRubPreFeb[0];
            A2298CBRubPreMar = P00CV7_A2298CBRubPreMar[0];
            A2299CBRubPreAbr = P00CV7_A2299CBRubPreAbr[0];
            A2300CBRubPreMay = P00CV7_A2300CBRubPreMay[0];
            A2301CBRubPreJun = P00CV7_A2301CBRubPreJun[0];
            A2302CBRubPreJul = P00CV7_A2302CBRubPreJul[0];
            A2303CBRubPreAgo = P00CV7_A2303CBRubPreAgo[0];
            A2304CBRubPreSep = P00CV7_A2304CBRubPreSep[0];
            A2305CBRubPreOct = P00CV7_A2305CBRubPreOct[0];
            A2306CBRubPreNov = P00CV7_A2306CBRubPreNov[0];
            A2307CBRubPreDic = P00CV7_A2307CBRubPreDic[0];
            if ( AV38Mes == 1 )
            {
               AV15CBRImpPre = (decimal)(AV15CBRImpPre+A2296CBRubPreEne);
            }
            if ( AV38Mes == 2 )
            {
               AV15CBRImpPre = (decimal)(AV15CBRImpPre+A2297CBRubPreFeb);
            }
            if ( AV38Mes == 3 )
            {
               AV15CBRImpPre = (decimal)(AV15CBRImpPre+A2298CBRubPreMar);
            }
            if ( AV38Mes == 4 )
            {
               AV15CBRImpPre = (decimal)(AV15CBRImpPre+A2299CBRubPreAbr);
            }
            if ( AV38Mes == 5 )
            {
               AV15CBRImpPre = (decimal)(AV15CBRImpPre+A2300CBRubPreMay);
            }
            if ( AV38Mes == 6 )
            {
               AV15CBRImpPre = (decimal)(AV15CBRImpPre+A2301CBRubPreJun);
            }
            if ( AV38Mes == 7 )
            {
               AV15CBRImpPre = (decimal)(AV15CBRImpPre+A2302CBRubPreJul);
            }
            if ( AV38Mes == 8 )
            {
               AV15CBRImpPre = (decimal)(AV15CBRImpPre+A2303CBRubPreAgo);
            }
            if ( AV38Mes == 9 )
            {
               AV15CBRImpPre = (decimal)(AV15CBRImpPre+A2304CBRubPreSep);
            }
            if ( AV38Mes == 10 )
            {
               AV15CBRImpPre = (decimal)(AV15CBRImpPre+A2305CBRubPreOct);
            }
            if ( AV38Mes == 11 )
            {
               AV15CBRImpPre = (decimal)(AV15CBRImpPre+A2306CBRubPreNov);
            }
            if ( AV38Mes == 12 )
            {
               AV15CBRImpPre = (decimal)(AV15CBRImpPre+A2307CBRubPreDic);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
         /* Using cursor P00CV8 */
         pr_default.execute(6, new Object[] {AV18CBTipPre, AV42Tip, AV10CBLinPre, AV16CBRubPre});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A2283CBRubPre = P00CV8_A2283CBRubPre[0];
            A2282CBLinPre = P00CV8_A2282CBLinPre[0];
            A2281CBTipTipo = P00CV8_A2281CBTipTipo[0];
            A2280CBTipPre = P00CV8_A2280CBTipPre[0];
            A91CueCod = P00CV8_A91CueCod[0];
            A79COSCod = P00CV8_A79COSCod[0];
            n79COSCod = P00CV8_n79COSCod[0];
            A2284CBRubDItem = P00CV8_A2284CBRubDItem[0];
            AV22CueCod = A91CueCod;
            AV21CosCod = A79COSCod;
            AV13CBRImpEje = 0.00m;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S146 ();
            if ( returnInSub )
            {
               pr_default.close(6);
               returnInSub = true;
               if (true) return;
            }
            AV13CBRImpEje = AV41Saldo;
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S146( )
      {
         /* 'MOVIMIENTOCUENTA' Routine */
         returnInSub = false;
         AV41Saldo = 0.00m;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV21CosCod ,
                                              A79COSCod ,
                                              A2077VouSts ,
                                              AV8Ano ,
                                              AV38Mes ,
                                              AV22CueCod ,
                                              A127VouAno ,
                                              A128VouMes ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CV9 */
         pr_default.execute(7, new Object[] {AV8Ano, AV38Mes, AV22CueCod, AV21CosCod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A126TASICod = P00CV9_A126TASICod[0];
            A129VouNum = P00CV9_A129VouNum[0];
            A2077VouSts = P00CV9_A2077VouSts[0];
            A79COSCod = P00CV9_A79COSCod[0];
            n79COSCod = P00CV9_n79COSCod[0];
            A91CueCod = P00CV9_A91CueCod[0];
            A128VouMes = P00CV9_A128VouMes[0];
            A127VouAno = P00CV9_A127VouAno[0];
            A864CueMon = P00CV9_A864CueMon[0];
            A2056VouDHabO = P00CV9_A2056VouDHabO[0];
            A2052VouDDebO = P00CV9_A2052VouDDebO[0];
            A2069VouDTcmb = P00CV9_A2069VouDTcmb[0];
            A2055VouDHab = P00CV9_A2055VouDHab[0];
            A2051VouDDeb = P00CV9_A2051VouDDeb[0];
            A130VouDSec = P00CV9_A130VouDSec[0];
            A864CueMon = P00CV9_A864CueMon[0];
            A2077VouSts = P00CV9_A2077VouSts[0];
            AV23CueMon = A864CueMon;
            if ( AV39MonCod == 1 )
            {
               AV41Saldo = (decimal)(AV41Saldo+((A2052VouDDebO-A2056VouDHabO)));
            }
            else
            {
               AV41Saldo = (decimal)(AV41Saldo+(((AV23CueMon==1) ? (A2052VouDDebO-A2056VouDHabO) : NumberUtil.Round( (A2051VouDDeb-A2055VouDHab)/ (decimal)(A2069VouDTcmb), 2))));
            }
            pr_default.readNext(7);
         }
         pr_default.close(7);
         AV41Saldo = ((AV41Saldo<Convert.ToDecimal(0)) ? AV41Saldo*-1 : AV41Saldo);
      }

      protected void S151( )
      {
         /* 'DETALLELINEAS' Routine */
         returnInSub = false;
         AV25ExcelDocument.get_Cells((int)(AV20CellRow), (int)(AV28FirstColumn+0), 1, 1).Text = StringUtil.Trim( AV44TipoPresupuesto);
         AV25ExcelDocument.get_Cells((int)(AV20CellRow), (int)(AV28FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV11CBLinPreDsc);
         AV25ExcelDocument.get_Cells((int)(AV20CellRow), (int)(AV28FirstColumn+2), 1, 1).Text = StringUtil.Trim( AV17CBRubPreDsc);
         AV25ExcelDocument.get_Cells((int)(AV20CellRow), (int)(AV28FirstColumn+3), 1, 1).Number = (double)(AV33ImpPre);
         AV25ExcelDocument.get_Cells((int)(AV20CellRow), (int)(AV28FirstColumn+4), 1, 1).Number = (double)(AV31ImpEje);
         AV25ExcelDocument.get_Cells((int)(AV20CellRow), (int)(AV28FirstColumn+5), 1, 1).Number = (double)(AV30ImpDif);
         AV25ExcelDocument.get_Cells((int)(AV20CellRow), (int)(AV28FirstColumn+6), 1, 1).Number = (double)(AV32ImpPor);
         AV20CellRow = (long)(AV20CellRow+1);
      }

      protected void S161( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV25ExcelDocument.ErrCode != 0 )
         {
            AV26Filename = "";
            AV24ErrorMessage = AV25ExcelDocument.ErrDescription;
            AV25ExcelDocument.Close();
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
         AV26Filename = "";
         AV24ErrorMessage = "";
         AV9Archivo = new GxFile(context.GetPhysicalPath());
         AV40Path = "";
         AV27FilenameOrigen = "";
         AV25ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P00CV2_A2280CBTipPre = new int[1] ;
         P00CV2_A2291CBTipPreDsc = new string[] {""} ;
         P00CV2_A180MonCod = new int[1] ;
         A2291CBTipPreDsc = "";
         AV45Titulo = "";
         AV44TipoPresupuesto = "";
         AV42Tip = "";
         P00CV3_A2281CBTipTipo = new string[] {""} ;
         P00CV3_A2280CBTipPre = new int[1] ;
         P00CV3_A2282CBLinPre = new int[1] ;
         P00CV3_A2289CBLinPreDsc = new string[] {""} ;
         A2281CBTipTipo = "";
         A2289CBLinPreDsc = "";
         AV11CBLinPreDsc = "";
         P00CV4_A2282CBLinPre = new int[1] ;
         P00CV4_A2281CBTipTipo = new string[] {""} ;
         P00CV4_A2280CBTipPre = new int[1] ;
         P00CV4_A2283CBRubPre = new int[1] ;
         P00CV4_A2293CBRubPreDsc = new string[] {""} ;
         A2293CBRubPreDsc = "";
         AV17CBRubPreDsc = "";
         P00CV5_A2285CBRubPreAno = new short[1] ;
         P00CV5_A2282CBLinPre = new int[1] ;
         P00CV5_A2281CBTipTipo = new string[] {""} ;
         P00CV5_A2280CBTipPre = new int[1] ;
         P00CV5_A2296CBRubPreEne = new decimal[1] ;
         P00CV5_A2297CBRubPreFeb = new decimal[1] ;
         P00CV5_A2298CBRubPreMar = new decimal[1] ;
         P00CV5_A2299CBRubPreAbr = new decimal[1] ;
         P00CV5_A2300CBRubPreMay = new decimal[1] ;
         P00CV5_A2301CBRubPreJun = new decimal[1] ;
         P00CV5_A2302CBRubPreJul = new decimal[1] ;
         P00CV5_A2303CBRubPreAgo = new decimal[1] ;
         P00CV5_A2304CBRubPreSep = new decimal[1] ;
         P00CV5_A2305CBRubPreOct = new decimal[1] ;
         P00CV5_A2306CBRubPreNov = new decimal[1] ;
         P00CV5_A2307CBRubPreDic = new decimal[1] ;
         P00CV5_A2283CBRubPre = new int[1] ;
         P00CV6_A2282CBLinPre = new int[1] ;
         P00CV6_A2281CBTipTipo = new string[] {""} ;
         P00CV6_A2280CBTipPre = new int[1] ;
         P00CV6_A91CueCod = new string[] {""} ;
         P00CV6_A79COSCod = new string[] {""} ;
         P00CV6_n79COSCod = new bool[] {false} ;
         P00CV6_A2283CBRubPre = new int[1] ;
         P00CV6_A2284CBRubDItem = new int[1] ;
         A91CueCod = "";
         A79COSCod = "";
         AV22CueCod = "";
         AV21CosCod = "";
         P00CV7_A2285CBRubPreAno = new short[1] ;
         P00CV7_A2283CBRubPre = new int[1] ;
         P00CV7_A2282CBLinPre = new int[1] ;
         P00CV7_A2281CBTipTipo = new string[] {""} ;
         P00CV7_A2280CBTipPre = new int[1] ;
         P00CV7_A2296CBRubPreEne = new decimal[1] ;
         P00CV7_A2297CBRubPreFeb = new decimal[1] ;
         P00CV7_A2298CBRubPreMar = new decimal[1] ;
         P00CV7_A2299CBRubPreAbr = new decimal[1] ;
         P00CV7_A2300CBRubPreMay = new decimal[1] ;
         P00CV7_A2301CBRubPreJun = new decimal[1] ;
         P00CV7_A2302CBRubPreJul = new decimal[1] ;
         P00CV7_A2303CBRubPreAgo = new decimal[1] ;
         P00CV7_A2304CBRubPreSep = new decimal[1] ;
         P00CV7_A2305CBRubPreOct = new decimal[1] ;
         P00CV7_A2306CBRubPreNov = new decimal[1] ;
         P00CV7_A2307CBRubPreDic = new decimal[1] ;
         P00CV8_A2283CBRubPre = new int[1] ;
         P00CV8_A2282CBLinPre = new int[1] ;
         P00CV8_A2281CBTipTipo = new string[] {""} ;
         P00CV8_A2280CBTipPre = new int[1] ;
         P00CV8_A91CueCod = new string[] {""} ;
         P00CV8_A79COSCod = new string[] {""} ;
         P00CV8_n79COSCod = new bool[] {false} ;
         P00CV8_A2284CBRubDItem = new int[1] ;
         P00CV9_A126TASICod = new int[1] ;
         P00CV9_A129VouNum = new string[] {""} ;
         P00CV9_A2077VouSts = new short[1] ;
         P00CV9_A79COSCod = new string[] {""} ;
         P00CV9_n79COSCod = new bool[] {false} ;
         P00CV9_A91CueCod = new string[] {""} ;
         P00CV9_A128VouMes = new short[1] ;
         P00CV9_A127VouAno = new short[1] ;
         P00CV9_A864CueMon = new short[1] ;
         P00CV9_A2056VouDHabO = new decimal[1] ;
         P00CV9_A2052VouDDebO = new decimal[1] ;
         P00CV9_A2069VouDTcmb = new decimal[1] ;
         P00CV9_A2055VouDHab = new decimal[1] ;
         P00CV9_A2051VouDDeb = new decimal[1] ;
         P00CV9_A130VouDSec = new int[1] ;
         A129VouNum = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_resumenpresupuestomensualexcel__default(),
            new Object[][] {
                new Object[] {
               P00CV2_A2280CBTipPre, P00CV2_A2291CBTipPreDsc, P00CV2_A180MonCod
               }
               , new Object[] {
               P00CV3_A2281CBTipTipo, P00CV3_A2280CBTipPre, P00CV3_A2282CBLinPre, P00CV3_A2289CBLinPreDsc
               }
               , new Object[] {
               P00CV4_A2282CBLinPre, P00CV4_A2281CBTipTipo, P00CV4_A2280CBTipPre, P00CV4_A2283CBRubPre, P00CV4_A2293CBRubPreDsc
               }
               , new Object[] {
               P00CV5_A2285CBRubPreAno, P00CV5_A2282CBLinPre, P00CV5_A2281CBTipTipo, P00CV5_A2280CBTipPre, P00CV5_A2296CBRubPreEne, P00CV5_A2297CBRubPreFeb, P00CV5_A2298CBRubPreMar, P00CV5_A2299CBRubPreAbr, P00CV5_A2300CBRubPreMay, P00CV5_A2301CBRubPreJun,
               P00CV5_A2302CBRubPreJul, P00CV5_A2303CBRubPreAgo, P00CV5_A2304CBRubPreSep, P00CV5_A2305CBRubPreOct, P00CV5_A2306CBRubPreNov, P00CV5_A2307CBRubPreDic, P00CV5_A2283CBRubPre
               }
               , new Object[] {
               P00CV6_A2282CBLinPre, P00CV6_A2281CBTipTipo, P00CV6_A2280CBTipPre, P00CV6_A91CueCod, P00CV6_A79COSCod, P00CV6_n79COSCod, P00CV6_A2283CBRubPre, P00CV6_A2284CBRubDItem
               }
               , new Object[] {
               P00CV7_A2285CBRubPreAno, P00CV7_A2283CBRubPre, P00CV7_A2282CBLinPre, P00CV7_A2281CBTipTipo, P00CV7_A2280CBTipPre, P00CV7_A2296CBRubPreEne, P00CV7_A2297CBRubPreFeb, P00CV7_A2298CBRubPreMar, P00CV7_A2299CBRubPreAbr, P00CV7_A2300CBRubPreMay,
               P00CV7_A2301CBRubPreJun, P00CV7_A2302CBRubPreJul, P00CV7_A2303CBRubPreAgo, P00CV7_A2304CBRubPreSep, P00CV7_A2305CBRubPreOct, P00CV7_A2306CBRubPreNov, P00CV7_A2307CBRubPreDic
               }
               , new Object[] {
               P00CV8_A2283CBRubPre, P00CV8_A2282CBLinPre, P00CV8_A2281CBTipTipo, P00CV8_A2280CBTipPre, P00CV8_A91CueCod, P00CV8_A79COSCod, P00CV8_n79COSCod, P00CV8_A2284CBRubDItem
               }
               , new Object[] {
               P00CV9_A126TASICod, P00CV9_A129VouNum, P00CV9_A2077VouSts, P00CV9_A79COSCod, P00CV9_n79COSCod, P00CV9_A91CueCod, P00CV9_A128VouMes, P00CV9_A127VouAno, P00CV9_A864CueMon, P00CV9_A2056VouDHabO,
               P00CV9_A2052VouDDebO, P00CV9_A2069VouDTcmb, P00CV9_A2055VouDHab, P00CV9_A2051VouDDeb, P00CV9_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8Ano ;
      private short AV38Mes ;
      private short A2285CBRubPreAno ;
      private short A2077VouSts ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short A864CueMon ;
      private short AV23CueMon ;
      private int AV18CBTipPre ;
      private int A2280CBTipPre ;
      private int A180MonCod ;
      private int AV39MonCod ;
      private int A2282CBLinPre ;
      private int AV10CBLinPre ;
      private int AV16CBRubPre ;
      private int A2283CBRubPre ;
      private int A2284CBRubDItem ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private long AV20CellRow ;
      private long AV28FirstColumn ;
      private long AV29i ;
      private decimal AV37ImpTPre ;
      private decimal AV35ImpTEje ;
      private decimal AV34ImpTDif ;
      private decimal AV33ImpPre ;
      private decimal AV31ImpEje ;
      private decimal AV30ImpDif ;
      private decimal AV32ImpPor ;
      private decimal AV36ImpTPor ;
      private decimal AV15CBRImpPre ;
      private decimal AV13CBRImpEje ;
      private decimal AV12CBRImpDif ;
      private decimal AV14CBRImpPor ;
      private decimal A2296CBRubPreEne ;
      private decimal A2297CBRubPreFeb ;
      private decimal A2298CBRubPreMar ;
      private decimal A2299CBRubPreAbr ;
      private decimal A2300CBRubPreMay ;
      private decimal A2301CBRubPreJun ;
      private decimal A2302CBRubPreJul ;
      private decimal A2303CBRubPreAgo ;
      private decimal A2304CBRubPreSep ;
      private decimal A2305CBRubPreOct ;
      private decimal A2306CBRubPreNov ;
      private decimal A2307CBRubPreDic ;
      private decimal AV41Saldo ;
      private decimal A2056VouDHabO ;
      private decimal A2052VouDDebO ;
      private decimal A2069VouDTcmb ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A79COSCod ;
      private string AV22CueCod ;
      private string AV21CosCod ;
      private string A129VouNum ;
      private bool returnInSub ;
      private bool n79COSCod ;
      private string AV43TipoDetalle ;
      private string AV26Filename ;
      private string AV24ErrorMessage ;
      private string AV40Path ;
      private string AV27FilenameOrigen ;
      private string A2291CBTipPreDsc ;
      private string AV45Titulo ;
      private string AV44TipoPresupuesto ;
      private string AV42Tip ;
      private string A2281CBTipTipo ;
      private string A2289CBLinPreDsc ;
      private string AV11CBLinPreDsc ;
      private string A2293CBRubPreDsc ;
      private string AV17CBRubPreDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private int aP2_CBTipPre ;
      private string aP3_TipoDetalle ;
      private IDataStoreProvider pr_default ;
      private int[] P00CV2_A2280CBTipPre ;
      private string[] P00CV2_A2291CBTipPreDsc ;
      private int[] P00CV2_A180MonCod ;
      private string[] P00CV3_A2281CBTipTipo ;
      private int[] P00CV3_A2280CBTipPre ;
      private int[] P00CV3_A2282CBLinPre ;
      private string[] P00CV3_A2289CBLinPreDsc ;
      private int[] P00CV4_A2282CBLinPre ;
      private string[] P00CV4_A2281CBTipTipo ;
      private int[] P00CV4_A2280CBTipPre ;
      private int[] P00CV4_A2283CBRubPre ;
      private string[] P00CV4_A2293CBRubPreDsc ;
      private short[] P00CV5_A2285CBRubPreAno ;
      private int[] P00CV5_A2282CBLinPre ;
      private string[] P00CV5_A2281CBTipTipo ;
      private int[] P00CV5_A2280CBTipPre ;
      private decimal[] P00CV5_A2296CBRubPreEne ;
      private decimal[] P00CV5_A2297CBRubPreFeb ;
      private decimal[] P00CV5_A2298CBRubPreMar ;
      private decimal[] P00CV5_A2299CBRubPreAbr ;
      private decimal[] P00CV5_A2300CBRubPreMay ;
      private decimal[] P00CV5_A2301CBRubPreJun ;
      private decimal[] P00CV5_A2302CBRubPreJul ;
      private decimal[] P00CV5_A2303CBRubPreAgo ;
      private decimal[] P00CV5_A2304CBRubPreSep ;
      private decimal[] P00CV5_A2305CBRubPreOct ;
      private decimal[] P00CV5_A2306CBRubPreNov ;
      private decimal[] P00CV5_A2307CBRubPreDic ;
      private int[] P00CV5_A2283CBRubPre ;
      private int[] P00CV6_A2282CBLinPre ;
      private string[] P00CV6_A2281CBTipTipo ;
      private int[] P00CV6_A2280CBTipPre ;
      private string[] P00CV6_A91CueCod ;
      private string[] P00CV6_A79COSCod ;
      private bool[] P00CV6_n79COSCod ;
      private int[] P00CV6_A2283CBRubPre ;
      private int[] P00CV6_A2284CBRubDItem ;
      private short[] P00CV7_A2285CBRubPreAno ;
      private int[] P00CV7_A2283CBRubPre ;
      private int[] P00CV7_A2282CBLinPre ;
      private string[] P00CV7_A2281CBTipTipo ;
      private int[] P00CV7_A2280CBTipPre ;
      private decimal[] P00CV7_A2296CBRubPreEne ;
      private decimal[] P00CV7_A2297CBRubPreFeb ;
      private decimal[] P00CV7_A2298CBRubPreMar ;
      private decimal[] P00CV7_A2299CBRubPreAbr ;
      private decimal[] P00CV7_A2300CBRubPreMay ;
      private decimal[] P00CV7_A2301CBRubPreJun ;
      private decimal[] P00CV7_A2302CBRubPreJul ;
      private decimal[] P00CV7_A2303CBRubPreAgo ;
      private decimal[] P00CV7_A2304CBRubPreSep ;
      private decimal[] P00CV7_A2305CBRubPreOct ;
      private decimal[] P00CV7_A2306CBRubPreNov ;
      private decimal[] P00CV7_A2307CBRubPreDic ;
      private int[] P00CV8_A2283CBRubPre ;
      private int[] P00CV8_A2282CBLinPre ;
      private string[] P00CV8_A2281CBTipTipo ;
      private int[] P00CV8_A2280CBTipPre ;
      private string[] P00CV8_A91CueCod ;
      private string[] P00CV8_A79COSCod ;
      private bool[] P00CV8_n79COSCod ;
      private int[] P00CV8_A2284CBRubDItem ;
      private int[] P00CV9_A126TASICod ;
      private string[] P00CV9_A129VouNum ;
      private short[] P00CV9_A2077VouSts ;
      private string[] P00CV9_A79COSCod ;
      private bool[] P00CV9_n79COSCod ;
      private string[] P00CV9_A91CueCod ;
      private short[] P00CV9_A128VouMes ;
      private short[] P00CV9_A127VouAno ;
      private short[] P00CV9_A864CueMon ;
      private decimal[] P00CV9_A2056VouDHabO ;
      private decimal[] P00CV9_A2052VouDDebO ;
      private decimal[] P00CV9_A2069VouDTcmb ;
      private decimal[] P00CV9_A2055VouDHab ;
      private decimal[] P00CV9_A2051VouDDeb ;
      private int[] P00CV9_A130VouDSec ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV25ExcelDocument ;
      private GxFile AV9Archivo ;
   }

   public class r_resumenpresupuestomensualexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CV9( IGxContext context ,
                                             string AV21CosCod ,
                                             string A79COSCod ,
                                             short A2077VouSts ,
                                             short AV8Ano ,
                                             short AV38Mes ,
                                             string AV22CueCod ,
                                             short A127VouAno ,
                                             short A128VouMes ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T1.[VouNum], T3.[VouSts], T1.[COSCod], T1.[CueCod], T1.[VouMes], T1.[VouAno], T2.[CueMon], T1.[VouDHabO], T1.[VouDDebO], T1.[VouDTcmb], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV8Ano and T1.[VouMes] = @AV38Mes and T1.[CueCod] = @AV22CueCod)");
         AddWhere(sWhereString, "(T3.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21CosCod)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV21CosCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 7 :
                     return conditional_P00CV9(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CV2;
          prmP00CV2 = new Object[] {
          new ParDef("@AV18CBTipPre",GXType.Int32,6,0)
          };
          Object[] prmP00CV3;
          prmP00CV3 = new Object[] {
          new ParDef("@AV18CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV42Tip",GXType.NVarChar,1,0)
          };
          Object[] prmP00CV4;
          prmP00CV4 = new Object[] {
          new ParDef("@AV18CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV42Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV10CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CV5;
          prmP00CV5 = new Object[] {
          new ParDef("@AV18CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV42Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV10CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV8Ano",GXType.Int16,4,0)
          };
          Object[] prmP00CV6;
          prmP00CV6 = new Object[] {
          new ParDef("@AV18CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV42Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV10CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CV7;
          prmP00CV7 = new Object[] {
          new ParDef("@AV18CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV42Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV10CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV16CBRubPre",GXType.Int32,6,0) ,
          new ParDef("@AV8Ano",GXType.Int16,4,0)
          };
          Object[] prmP00CV8;
          prmP00CV8 = new Object[] {
          new ParDef("@AV18CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV42Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV10CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV16CBRubPre",GXType.Int32,6,0)
          };
          Object[] prmP00CV9;
          prmP00CV9 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV38Mes",GXType.Int16,2,0) ,
          new ParDef("@AV22CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV21CosCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CV2", "SELECT [CBTipPre], [CBTipPreDsc], [MonCod] FROM [CBPRESUPUESTOTIPO] WHERE [CBTipPre] = @AV18CBTipPre ORDER BY [CBTipPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CV2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CV3", "SELECT [CBTipTipo], [CBTipPre], [CBLinPre], [CBLinPreDsc] FROM [CBPRESUPUESTOLINEA] WHERE [CBTipPre] = @AV18CBTipPre and [CBTipTipo] = @AV42Tip ORDER BY [CBTipPre], [CBTipTipo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CV3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CV4", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CBRubPre], [CBRubPreDsc] FROM [CBPRESUPUESTORUBROS] WHERE [CBTipPre] = @AV18CBTipPre and [CBTipTipo] = @AV42Tip and [CBLinPre] = @AV10CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CV4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CV5", "SELECT [CBRubPreAno], [CBLinPre], [CBTipTipo], [CBTipPre], [CBRubPreEne], [CBRubPreFeb], [CBRubPreMar], [CBRubPreAbr], [CBRubPreMay], [CBRubPreJun], [CBRubPreJul], [CBRubPreAgo], [CBRubPreSep], [CBRubPreOct], [CBRubPreNov], [CBRubPreDic], [CBRubPre] FROM [CBPRESUPUESTORUBROSDET] WHERE ([CBTipPre] = @AV18CBTipPre and [CBTipTipo] = @AV42Tip and [CBLinPre] = @AV10CBLinPre) AND ([CBRubPreAno] = @AV8Ano) ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CV5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CV6", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV18CBTipPre and [CBTipTipo] = @AV42Tip and [CBLinPre] = @AV10CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CV6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CV7", "SELECT [CBRubPreAno], [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CBRubPreEne], [CBRubPreFeb], [CBRubPreMar], [CBRubPreAbr], [CBRubPreMay], [CBRubPreJun], [CBRubPreJul], [CBRubPreAgo], [CBRubPreSep], [CBRubPreOct], [CBRubPreNov], [CBRubPreDic] FROM [CBPRESUPUESTORUBROSDET] WHERE [CBTipPre] = @AV18CBTipPre and [CBTipTipo] = @AV42Tip and [CBLinPre] = @AV10CBLinPre and [CBRubPre] = @AV16CBRubPre and [CBRubPreAno] = @AV8Ano ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubPreAno] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CV7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CV8", "SELECT [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV18CBTipPre and [CBTipTipo] = @AV42Tip and [CBLinPre] = @AV10CBLinPre and [CBRubPre] = @AV16CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CV8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CV9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CV9,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((int[]) buf[16])[0] = rslt.getInt(17);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((int[]) buf[14])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
