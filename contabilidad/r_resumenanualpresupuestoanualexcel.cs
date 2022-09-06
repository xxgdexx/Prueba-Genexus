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
   public class r_resumenanualpresupuestoanualexcel : GXProcedure
   {
      public r_resumenanualpresupuestoanualexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenanualpresupuestoanualexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref int aP1_CBTipPre ,
                           ref string aP2_TipoDetalle ,
                           out string aP3_Filename ,
                           out string aP4_ErrorMessage )
      {
         this.AV10Ano = aP0_Ano;
         this.AV14CBTipPre = aP1_CBTipPre;
         this.AV113TipoDetalle = aP2_TipoDetalle;
         this.AV61Filename = "" ;
         this.AV59ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV10Ano;
         aP1_CBTipPre=this.AV14CBTipPre;
         aP2_TipoDetalle=this.AV113TipoDetalle;
         aP3_Filename=this.AV61Filename;
         aP4_ErrorMessage=this.AV59ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref int aP1_CBTipPre ,
                                ref string aP2_TipoDetalle ,
                                out string aP3_Filename )
      {
         execute(ref aP0_Ano, ref aP1_CBTipPre, ref aP2_TipoDetalle, out aP3_Filename, out aP4_ErrorMessage);
         return AV59ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref int aP1_CBTipPre ,
                                 ref string aP2_TipoDetalle ,
                                 out string aP3_Filename ,
                                 out string aP4_ErrorMessage )
      {
         r_resumenanualpresupuestoanualexcel objr_resumenanualpresupuestoanualexcel;
         objr_resumenanualpresupuestoanualexcel = new r_resumenanualpresupuestoanualexcel();
         objr_resumenanualpresupuestoanualexcel.AV10Ano = aP0_Ano;
         objr_resumenanualpresupuestoanualexcel.AV14CBTipPre = aP1_CBTipPre;
         objr_resumenanualpresupuestoanualexcel.AV113TipoDetalle = aP2_TipoDetalle;
         objr_resumenanualpresupuestoanualexcel.AV61Filename = "" ;
         objr_resumenanualpresupuestoanualexcel.AV59ErrorMessage = "" ;
         objr_resumenanualpresupuestoanualexcel.context.SetSubmitInitialConfig(context);
         objr_resumenanualpresupuestoanualexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenanualpresupuestoanualexcel);
         aP0_Ano=this.AV10Ano;
         aP1_CBTipPre=this.AV14CBTipPre;
         aP2_TipoDetalle=this.AV113TipoDetalle;
         aP3_Filename=this.AV61Filename;
         aP4_ErrorMessage=this.AV59ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenanualpresupuestoanualexcel)stateInfo).executePrivate();
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
         AV11Archivo.Source = "Excel/PlantillaPresupuesto.xlsx";
         AV79Path = AV11Archivo.GetPath();
         AV62FilenameOrigen = StringUtil.Trim( AV79Path) + "\\PlantillaPresupuesto.xlsx";
         AV61Filename = "Excel/ResumanAnualPresupuesto" + ".xlsx";
         AV60ExcelDocument.Clear();
         AV60ExcelDocument.Template = AV62FilenameOrigen;
         AV60ExcelDocument.Open(AV61Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S171 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV60ExcelDocument.get_Cells(1, 1, 1, 1).Text = "Reporte Anual de Presupuesto";
         AV60ExcelDocument.get_Cells(2, 1, 1, 1).Text = "Periodo : "+StringUtil.Trim( StringUtil.Str( (decimal)(AV10Ano), 10, 0));
         AV16CellRow = 4;
         AV63FirstColumn = 1;
         /* Using cursor P00CW2 */
         pr_default.execute(0, new Object[] {AV14CBTipPre});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2280CBTipPre = P00CW2_A2280CBTipPre[0];
            A2291CBTipPreDsc = P00CW2_A2291CBTipPreDsc[0];
            A180MonCod = P00CW2_A180MonCod[0];
            AV14CBTipPre = A2280CBTipPre;
            AV15CBTipPreDsc = A2291CBTipPreDsc;
            AV118MonCod = A180MonCod;
            /* Execute user subroutine: 'LINEAS' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV60ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S171 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV60ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LINEAS' Routine */
         returnInSub = false;
         AV64i = 1;
         AV114TipoPresupuesto = "";
         while ( AV64i <= 2 )
         {
            if ( AV64i == 1 )
            {
               AV111Tip = "I";
               AV114TipoPresupuesto = "INGRESO";
            }
            if ( AV64i == 2 )
            {
               AV111Tip = "E";
               AV114TipoPresupuesto = "EGRESO";
            }
            /* Using cursor P00CW3 */
            pr_default.execute(1, new Object[] {AV15CBTipPreDsc, AV111Tip});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A2280CBTipPre = P00CW3_A2280CBTipPre[0];
               A2281CBTipTipo = P00CW3_A2281CBTipTipo[0];
               A2291CBTipPreDsc = P00CW3_A2291CBTipPreDsc[0];
               A2282CBLinPre = P00CW3_A2282CBLinPre[0];
               A2289CBLinPreDsc = P00CW3_A2289CBLinPreDsc[0];
               A2291CBTipPreDsc = P00CW3_A2291CBTipPreDsc[0];
               AV8CBLinPre = A2282CBLinPre;
               AV9CBLinPreDsc = A2289CBLinPreDsc;
               AV12CBRubPre = 0;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113TipoDetalle)) )
               {
                  /* Execute user subroutine: 'RUBROS' */
                  S123 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               else
               {
                  /* Execute user subroutine: 'EJECUCION' */
                  S133 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     returnInSub = true;
                     if (true) return;
                  }
                  /* Execute user subroutine: 'DETALLELINEAS' */
                  S143 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV64i = (long)(AV64i+1);
         }
      }

      protected void S133( )
      {
         /* 'EJECUCION' Routine */
         returnInSub = false;
         AV80PImp1 = 0.00m;
         AV84PImp2 = 0.00m;
         AV85PImp3 = 0.00m;
         AV86PImp4 = 0.00m;
         AV87PImp5 = 0.00m;
         AV88PImp6 = 0.00m;
         AV89PImp7 = 0.00m;
         AV90PImp8 = 0.00m;
         AV91PImp9 = 0.00m;
         AV81PImp10 = 0.00m;
         AV82PImp11 = 0.00m;
         AV83PImp12 = 0.00m;
         AV33DImp1 = 0.00m;
         AV37DImp2 = 0.00m;
         AV38DImp3 = 0.00m;
         AV39DImp4 = 0.00m;
         AV40DImp5 = 0.00m;
         AV41DImp6 = 0.00m;
         AV42DImp7 = 0.00m;
         AV43DImp8 = 0.00m;
         AV44DImp9 = 0.00m;
         AV34DImp10 = 0.00m;
         AV35DImp11 = 0.00m;
         AV36DImp12 = 0.00m;
         /* Optimized group. */
         /* Using cursor P00CW4 */
         pr_default.execute(2, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre, AV10Ano});
         c2296CBRubPreEne = P00CW4_A2296CBRubPreEne[0];
         c2297CBRubPreFeb = P00CW4_A2297CBRubPreFeb[0];
         c2298CBRubPreMar = P00CW4_A2298CBRubPreMar[0];
         c2299CBRubPreAbr = P00CW4_A2299CBRubPreAbr[0];
         c2300CBRubPreMay = P00CW4_A2300CBRubPreMay[0];
         c2301CBRubPreJun = P00CW4_A2301CBRubPreJun[0];
         c2302CBRubPreJul = P00CW4_A2302CBRubPreJul[0];
         c2303CBRubPreAgo = P00CW4_A2303CBRubPreAgo[0];
         c2304CBRubPreSep = P00CW4_A2304CBRubPreSep[0];
         c2305CBRubPreOct = P00CW4_A2305CBRubPreOct[0];
         c2306CBRubPreNov = P00CW4_A2306CBRubPreNov[0];
         c2307CBRubPreDic = P00CW4_A2307CBRubPreDic[0];
         pr_default.close(2);
         AV80PImp1 = (decimal)(AV80PImp1+c2296CBRubPreEne);
         AV84PImp2 = (decimal)(AV84PImp2+c2297CBRubPreFeb);
         AV85PImp3 = (decimal)(AV85PImp3+c2298CBRubPreMar);
         AV86PImp4 = (decimal)(AV86PImp4+c2299CBRubPreAbr);
         AV87PImp5 = (decimal)(AV87PImp5+c2300CBRubPreMay);
         AV88PImp6 = (decimal)(AV88PImp6+c2301CBRubPreJun);
         AV89PImp7 = (decimal)(AV89PImp7+c2302CBRubPreJul);
         AV90PImp8 = (decimal)(AV90PImp8+c2303CBRubPreAgo);
         AV91PImp9 = (decimal)(AV91PImp9+c2304CBRubPreSep);
         AV81PImp10 = (decimal)(AV81PImp10+c2305CBRubPreOct);
         AV82PImp11 = (decimal)(AV82PImp11+c2306CBRubPreNov);
         AV83PImp12 = (decimal)(AV83PImp12+c2307CBRubPreDic);
         /* End optimized group. */
         /* Using cursor P00CW5 */
         pr_default.execute(3, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A2282CBLinPre = P00CW5_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW5_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW5_A2280CBTipPre[0];
            A91CueCod = P00CW5_A91CueCod[0];
            A79COSCod = P00CW5_A79COSCod[0];
            n79COSCod = P00CW5_n79COSCod[0];
            A2283CBRubPre = P00CW5_A2283CBRubPre[0];
            A2284CBRubDItem = P00CW5_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 1;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV33DImp1 = (decimal)(AV33DImp1+(((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo)));
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Using cursor P00CW6 */
         pr_default.execute(4, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A2282CBLinPre = P00CW6_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW6_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW6_A2280CBTipPre[0];
            A91CueCod = P00CW6_A91CueCod[0];
            A79COSCod = P00CW6_A79COSCod[0];
            n79COSCod = P00CW6_n79COSCod[0];
            A2283CBRubPre = P00CW6_A2283CBRubPre[0];
            A2284CBRubDItem = P00CW6_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 2;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            AV37DImp2 = (decimal)(AV37DImp2+(((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo)));
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /* Using cursor P00CW7 */
         pr_default.execute(5, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A2282CBLinPre = P00CW7_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW7_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW7_A2280CBTipPre[0];
            A91CueCod = P00CW7_A91CueCod[0];
            A79COSCod = P00CW7_A79COSCod[0];
            n79COSCod = P00CW7_n79COSCod[0];
            A2283CBRubPre = P00CW7_A2283CBRubPre[0];
            A2284CBRubDItem = P00CW7_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 3;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(5);
               returnInSub = true;
               if (true) return;
            }
            AV38DImp3 = (decimal)(AV38DImp3+(((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo)));
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /* Using cursor P00CW8 */
         pr_default.execute(6, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A2282CBLinPre = P00CW8_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW8_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW8_A2280CBTipPre[0];
            A91CueCod = P00CW8_A91CueCod[0];
            A79COSCod = P00CW8_A79COSCod[0];
            n79COSCod = P00CW8_n79COSCod[0];
            A2283CBRubPre = P00CW8_A2283CBRubPre[0];
            A2284CBRubDItem = P00CW8_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 4;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(6);
               returnInSub = true;
               if (true) return;
            }
            AV39DImp4 = (decimal)(AV39DImp4+(((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo)));
            pr_default.readNext(6);
         }
         pr_default.close(6);
         /* Using cursor P00CW9 */
         pr_default.execute(7, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A2282CBLinPre = P00CW9_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW9_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW9_A2280CBTipPre[0];
            A91CueCod = P00CW9_A91CueCod[0];
            A79COSCod = P00CW9_A79COSCod[0];
            n79COSCod = P00CW9_n79COSCod[0];
            A2283CBRubPre = P00CW9_A2283CBRubPre[0];
            A2284CBRubDItem = P00CW9_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 5;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(7);
               returnInSub = true;
               if (true) return;
            }
            AV40DImp5 = (decimal)(AV40DImp5+(((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo)));
            pr_default.readNext(7);
         }
         pr_default.close(7);
         /* Using cursor P00CW10 */
         pr_default.execute(8, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A2282CBLinPre = P00CW10_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW10_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW10_A2280CBTipPre[0];
            A91CueCod = P00CW10_A91CueCod[0];
            A79COSCod = P00CW10_A79COSCod[0];
            n79COSCod = P00CW10_n79COSCod[0];
            A2283CBRubPre = P00CW10_A2283CBRubPre[0];
            A2284CBRubDItem = P00CW10_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 6;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(8);
               returnInSub = true;
               if (true) return;
            }
            AV41DImp6 = (decimal)(AV41DImp6+(((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo)));
            pr_default.readNext(8);
         }
         pr_default.close(8);
         /* Using cursor P00CW11 */
         pr_default.execute(9, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A2282CBLinPre = P00CW11_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW11_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW11_A2280CBTipPre[0];
            A91CueCod = P00CW11_A91CueCod[0];
            A79COSCod = P00CW11_A79COSCod[0];
            n79COSCod = P00CW11_n79COSCod[0];
            A2283CBRubPre = P00CW11_A2283CBRubPre[0];
            A2284CBRubDItem = P00CW11_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 7;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(9);
               returnInSub = true;
               if (true) return;
            }
            AV42DImp7 = (decimal)(AV42DImp7+(((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo)));
            pr_default.readNext(9);
         }
         pr_default.close(9);
         /* Using cursor P00CW12 */
         pr_default.execute(10, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A2282CBLinPre = P00CW12_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW12_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW12_A2280CBTipPre[0];
            A91CueCod = P00CW12_A91CueCod[0];
            A79COSCod = P00CW12_A79COSCod[0];
            n79COSCod = P00CW12_n79COSCod[0];
            A2283CBRubPre = P00CW12_A2283CBRubPre[0];
            A2284CBRubDItem = P00CW12_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 8;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(10);
               returnInSub = true;
               if (true) return;
            }
            AV43DImp8 = (decimal)(AV43DImp8+(((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo)));
            pr_default.readNext(10);
         }
         pr_default.close(10);
         /* Using cursor P00CW13 */
         pr_default.execute(11, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A2282CBLinPre = P00CW13_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW13_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW13_A2280CBTipPre[0];
            A91CueCod = P00CW13_A91CueCod[0];
            A79COSCod = P00CW13_A79COSCod[0];
            n79COSCod = P00CW13_n79COSCod[0];
            A2283CBRubPre = P00CW13_A2283CBRubPre[0];
            A2284CBRubDItem = P00CW13_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 9;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(11);
               returnInSub = true;
               if (true) return;
            }
            AV44DImp9 = (decimal)(AV44DImp9+(((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo)));
            pr_default.readNext(11);
         }
         pr_default.close(11);
         /* Using cursor P00CW14 */
         pr_default.execute(12, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre});
         while ( (pr_default.getStatus(12) != 101) )
         {
            A2282CBLinPre = P00CW14_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW14_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW14_A2280CBTipPre[0];
            A91CueCod = P00CW14_A91CueCod[0];
            A79COSCod = P00CW14_A79COSCod[0];
            n79COSCod = P00CW14_n79COSCod[0];
            A2283CBRubPre = P00CW14_A2283CBRubPre[0];
            A2284CBRubDItem = P00CW14_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 10;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(12);
               returnInSub = true;
               if (true) return;
            }
            AV34DImp10 = (decimal)(AV34DImp10+(((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo)));
            pr_default.readNext(12);
         }
         pr_default.close(12);
         /* Using cursor P00CW15 */
         pr_default.execute(13, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre});
         while ( (pr_default.getStatus(13) != 101) )
         {
            A2282CBLinPre = P00CW15_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW15_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW15_A2280CBTipPre[0];
            A91CueCod = P00CW15_A91CueCod[0];
            A79COSCod = P00CW15_A79COSCod[0];
            n79COSCod = P00CW15_n79COSCod[0];
            A2283CBRubPre = P00CW15_A2283CBRubPre[0];
            A2284CBRubDItem = P00CW15_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 11;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(13);
               returnInSub = true;
               if (true) return;
            }
            AV35DImp11 = (decimal)(AV35DImp11+(((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo)));
            pr_default.readNext(13);
         }
         pr_default.close(13);
         /* Using cursor P00CW16 */
         pr_default.execute(14, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre});
         while ( (pr_default.getStatus(14) != 101) )
         {
            A2282CBLinPre = P00CW16_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW16_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW16_A2280CBTipPre[0];
            A91CueCod = P00CW16_A91CueCod[0];
            A79COSCod = P00CW16_A79COSCod[0];
            n79COSCod = P00CW16_n79COSCod[0];
            A2283CBRubPre = P00CW16_A2283CBRubPre[0];
            A2284CBRubDItem = P00CW16_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 12;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(14);
               returnInSub = true;
               if (true) return;
            }
            AV36DImp12 = (decimal)(AV36DImp12+(((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo)));
            pr_default.readNext(14);
         }
         pr_default.close(14);
         AV58DTOT = (decimal)(AV80PImp1+AV84PImp2+AV85PImp3+AV86PImp4+AV87PImp5+AV88PImp6+AV89PImp7+AV90PImp8+AV91PImp9+AV81PImp10+AV82PImp11+AV83PImp12);
         AV57DPTot = (decimal)(AV33DImp1+AV37DImp2+AV38DImp3+AV39DImp4+AV40DImp5+AV41DImp6+AV42DImp7+AV43DImp8+AV44DImp9+AV34DImp10+AV35DImp11+AV36DImp12);
         AV93Por1 = ((Convert.ToDecimal(0)==AV80PImp1) ? (decimal)(0) : NumberUtil.Round( (AV33DImp1/ (decimal)(AV80PImp1))*100, 2));
         AV97Por2 = ((Convert.ToDecimal(0)==AV84PImp2) ? (decimal)(0) : NumberUtil.Round( (AV37DImp2/ (decimal)(AV84PImp2))*100, 2));
         AV98Por3 = ((Convert.ToDecimal(0)==AV85PImp3) ? (decimal)(0) : NumberUtil.Round( (AV38DImp3/ (decimal)(AV85PImp3))*100, 2));
         AV99Por4 = ((Convert.ToDecimal(0)==AV86PImp4) ? (decimal)(0) : NumberUtil.Round( (AV39DImp4/ (decimal)(AV86PImp4))*100, 2));
         AV100Por5 = ((Convert.ToDecimal(0)==AV87PImp5) ? (decimal)(0) : NumberUtil.Round( (AV40DImp5/ (decimal)(AV87PImp5))*100, 2));
         AV101Por6 = ((Convert.ToDecimal(0)==AV88PImp6) ? (decimal)(0) : NumberUtil.Round( (AV41DImp6/ (decimal)(AV88PImp6))*100, 2));
         AV102Por7 = ((Convert.ToDecimal(0)==AV89PImp7) ? (decimal)(0) : NumberUtil.Round( (AV42DImp7/ (decimal)(AV89PImp7))*100, 2));
         AV103Por8 = ((Convert.ToDecimal(0)==AV90PImp8) ? (decimal)(0) : NumberUtil.Round( (AV43DImp8/ (decimal)(AV90PImp8))*100, 2));
         AV104Por9 = ((Convert.ToDecimal(0)==AV91PImp9) ? (decimal)(0) : NumberUtil.Round( (AV44DImp9/ (decimal)(AV91PImp9))*100, 2));
         AV94Por10 = ((Convert.ToDecimal(0)==AV81PImp10) ? (decimal)(0) : NumberUtil.Round( (AV34DImp10/ (decimal)(AV81PImp10))*100, 2));
         AV95Por11 = ((Convert.ToDecimal(0)==AV82PImp11) ? (decimal)(0) : NumberUtil.Round( (AV35DImp11/ (decimal)(AV82PImp11))*100, 2));
         AV96Por12 = ((Convert.ToDecimal(0)==AV83PImp12) ? (decimal)(0) : NumberUtil.Round( (AV36DImp12/ (decimal)(AV83PImp12))*100, 2));
         AV105PorT = ((Convert.ToDecimal(0)==AV58DTOT) ? (decimal)(0) : NumberUtil.Round( (AV57DPTot/ (decimal)(AV58DTOT))*100, 2));
      }

      protected void S155( )
      {
         /* 'MOVIMIENTOCUENTA' Routine */
         returnInSub = false;
         AV110Saldo = 0.00m;
         pr_default.dynParam(15, new Object[]{ new Object[]{
                                              AV17CosCod ,
                                              A79COSCod ,
                                              A2077VouSts ,
                                              AV10Ano ,
                                              AV78Mes ,
                                              AV18CueCod ,
                                              A127VouAno ,
                                              A128VouMes ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CW17 */
         pr_default.execute(15, new Object[] {AV10Ano, AV78Mes, AV18CueCod, AV17CosCod});
         while ( (pr_default.getStatus(15) != 101) )
         {
            A126TASICod = P00CW17_A126TASICod[0];
            A129VouNum = P00CW17_A129VouNum[0];
            A2077VouSts = P00CW17_A2077VouSts[0];
            A79COSCod = P00CW17_A79COSCod[0];
            n79COSCod = P00CW17_n79COSCod[0];
            A91CueCod = P00CW17_A91CueCod[0];
            A128VouMes = P00CW17_A128VouMes[0];
            A127VouAno = P00CW17_A127VouAno[0];
            A864CueMon = P00CW17_A864CueMon[0];
            A2056VouDHabO = P00CW17_A2056VouDHabO[0];
            A2052VouDDebO = P00CW17_A2052VouDDebO[0];
            A2069VouDTcmb = P00CW17_A2069VouDTcmb[0];
            A2055VouDHab = P00CW17_A2055VouDHab[0];
            A2051VouDDeb = P00CW17_A2051VouDDeb[0];
            A130VouDSec = P00CW17_A130VouDSec[0];
            A864CueMon = P00CW17_A864CueMon[0];
            A2077VouSts = P00CW17_A2077VouSts[0];
            AV119CueMon = A864CueMon;
            if ( AV118MonCod == 1 )
            {
               AV110Saldo = (decimal)(AV110Saldo+((A2052VouDDebO-A2056VouDHabO)));
            }
            else
            {
               AV110Saldo = (decimal)(AV110Saldo+(((AV119CueMon==1) ? (A2052VouDDebO-A2056VouDHabO) : NumberUtil.Round( (A2051VouDDeb-A2055VouDHab)/ (decimal)(A2069VouDTcmb), 2))));
            }
            pr_default.readNext(15);
         }
         pr_default.close(15);
         AV110Saldo = ((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo);
      }

      protected void S123( )
      {
         /* 'RUBROS' Routine */
         returnInSub = false;
         /* Using cursor P00CW18 */
         pr_default.execute(16, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre});
         while ( (pr_default.getStatus(16) != 101) )
         {
            A2282CBLinPre = P00CW18_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW18_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW18_A2280CBTipPre[0];
            A2283CBRubPre = P00CW18_A2283CBRubPre[0];
            A2293CBRubPreDsc = P00CW18_A2293CBRubPreDsc[0];
            AV12CBRubPre = A2283CBRubPre;
            AV13CBRubPreDsc = A2293CBRubPreDsc;
            /* Execute user subroutine: 'EJECUCIONRUBROS' */
            S1618 ();
            if ( returnInSub )
            {
               pr_default.close(16);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'DETALLELINEAS' */
            S143 ();
            if ( returnInSub )
            {
               pr_default.close(16);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(16);
         }
         pr_default.close(16);
      }

      protected void S1618( )
      {
         /* 'EJECUCIONRUBROS' Routine */
         returnInSub = false;
         AV80PImp1 = 0.00m;
         AV84PImp2 = 0.00m;
         AV85PImp3 = 0.00m;
         AV86PImp4 = 0.00m;
         AV87PImp5 = 0.00m;
         AV88PImp6 = 0.00m;
         AV89PImp7 = 0.00m;
         AV90PImp8 = 0.00m;
         AV91PImp9 = 0.00m;
         AV81PImp10 = 0.00m;
         AV82PImp11 = 0.00m;
         AV83PImp12 = 0.00m;
         AV33DImp1 = 0.00m;
         AV37DImp2 = 0.00m;
         AV38DImp3 = 0.00m;
         AV39DImp4 = 0.00m;
         AV40DImp5 = 0.00m;
         AV41DImp6 = 0.00m;
         AV42DImp7 = 0.00m;
         AV43DImp8 = 0.00m;
         AV44DImp9 = 0.00m;
         AV34DImp10 = 0.00m;
         AV35DImp11 = 0.00m;
         AV36DImp12 = 0.00m;
         /* Optimized group. */
         /* Using cursor P00CW19 */
         pr_default.execute(17, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre, AV12CBRubPre, AV10Ano});
         c2296CBRubPreEne = P00CW19_A2296CBRubPreEne[0];
         c2297CBRubPreFeb = P00CW19_A2297CBRubPreFeb[0];
         c2298CBRubPreMar = P00CW19_A2298CBRubPreMar[0];
         c2299CBRubPreAbr = P00CW19_A2299CBRubPreAbr[0];
         c2300CBRubPreMay = P00CW19_A2300CBRubPreMay[0];
         c2301CBRubPreJun = P00CW19_A2301CBRubPreJun[0];
         c2302CBRubPreJul = P00CW19_A2302CBRubPreJul[0];
         c2303CBRubPreAgo = P00CW19_A2303CBRubPreAgo[0];
         c2304CBRubPreSep = P00CW19_A2304CBRubPreSep[0];
         c2305CBRubPreOct = P00CW19_A2305CBRubPreOct[0];
         c2306CBRubPreNov = P00CW19_A2306CBRubPreNov[0];
         c2307CBRubPreDic = P00CW19_A2307CBRubPreDic[0];
         pr_default.close(17);
         AV80PImp1 = (decimal)(AV80PImp1+c2296CBRubPreEne);
         AV84PImp2 = (decimal)(AV84PImp2+c2297CBRubPreFeb);
         AV85PImp3 = (decimal)(AV85PImp3+c2298CBRubPreMar);
         AV86PImp4 = (decimal)(AV86PImp4+c2299CBRubPreAbr);
         AV87PImp5 = (decimal)(AV87PImp5+c2300CBRubPreMay);
         AV88PImp6 = (decimal)(AV88PImp6+c2301CBRubPreJun);
         AV89PImp7 = (decimal)(AV89PImp7+c2302CBRubPreJul);
         AV90PImp8 = (decimal)(AV90PImp8+c2303CBRubPreAgo);
         AV91PImp9 = (decimal)(AV91PImp9+c2304CBRubPreSep);
         AV81PImp10 = (decimal)(AV81PImp10+c2305CBRubPreOct);
         AV82PImp11 = (decimal)(AV82PImp11+c2306CBRubPreNov);
         AV83PImp12 = (decimal)(AV83PImp12+c2307CBRubPreDic);
         /* End optimized group. */
         /* Using cursor P00CW20 */
         pr_default.execute(18, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre, AV12CBRubPre});
         while ( (pr_default.getStatus(18) != 101) )
         {
            A2283CBRubPre = P00CW20_A2283CBRubPre[0];
            A2282CBLinPre = P00CW20_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW20_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW20_A2280CBTipPre[0];
            A91CueCod = P00CW20_A91CueCod[0];
            A79COSCod = P00CW20_A79COSCod[0];
            n79COSCod = P00CW20_n79COSCod[0];
            A2284CBRubDItem = P00CW20_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 1;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(18);
               returnInSub = true;
               if (true) return;
            }
            AV33DImp1 = ((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo);
            pr_default.readNext(18);
         }
         pr_default.close(18);
         /* Using cursor P00CW21 */
         pr_default.execute(19, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre, AV12CBRubPre});
         while ( (pr_default.getStatus(19) != 101) )
         {
            A2283CBRubPre = P00CW21_A2283CBRubPre[0];
            A2282CBLinPre = P00CW21_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW21_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW21_A2280CBTipPre[0];
            A91CueCod = P00CW21_A91CueCod[0];
            A79COSCod = P00CW21_A79COSCod[0];
            n79COSCod = P00CW21_n79COSCod[0];
            A2284CBRubDItem = P00CW21_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 2;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(19);
               returnInSub = true;
               if (true) return;
            }
            AV37DImp2 = ((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo);
            pr_default.readNext(19);
         }
         pr_default.close(19);
         /* Using cursor P00CW22 */
         pr_default.execute(20, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre, AV12CBRubPre});
         while ( (pr_default.getStatus(20) != 101) )
         {
            A2283CBRubPre = P00CW22_A2283CBRubPre[0];
            A2282CBLinPre = P00CW22_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW22_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW22_A2280CBTipPre[0];
            A91CueCod = P00CW22_A91CueCod[0];
            A79COSCod = P00CW22_A79COSCod[0];
            n79COSCod = P00CW22_n79COSCod[0];
            A2284CBRubDItem = P00CW22_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 3;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(20);
               returnInSub = true;
               if (true) return;
            }
            AV38DImp3 = ((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo);
            pr_default.readNext(20);
         }
         pr_default.close(20);
         /* Using cursor P00CW23 */
         pr_default.execute(21, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre, AV12CBRubPre});
         while ( (pr_default.getStatus(21) != 101) )
         {
            A2283CBRubPre = P00CW23_A2283CBRubPre[0];
            A2282CBLinPre = P00CW23_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW23_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW23_A2280CBTipPre[0];
            A91CueCod = P00CW23_A91CueCod[0];
            A79COSCod = P00CW23_A79COSCod[0];
            n79COSCod = P00CW23_n79COSCod[0];
            A2284CBRubDItem = P00CW23_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 4;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(21);
               returnInSub = true;
               if (true) return;
            }
            AV39DImp4 = ((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo);
            pr_default.readNext(21);
         }
         pr_default.close(21);
         /* Using cursor P00CW24 */
         pr_default.execute(22, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre, AV12CBRubPre});
         while ( (pr_default.getStatus(22) != 101) )
         {
            A2283CBRubPre = P00CW24_A2283CBRubPre[0];
            A2282CBLinPre = P00CW24_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW24_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW24_A2280CBTipPre[0];
            A91CueCod = P00CW24_A91CueCod[0];
            A79COSCod = P00CW24_A79COSCod[0];
            n79COSCod = P00CW24_n79COSCod[0];
            A2284CBRubDItem = P00CW24_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 5;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(22);
               returnInSub = true;
               if (true) return;
            }
            AV40DImp5 = ((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo);
            pr_default.readNext(22);
         }
         pr_default.close(22);
         /* Using cursor P00CW25 */
         pr_default.execute(23, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre, AV12CBRubPre});
         while ( (pr_default.getStatus(23) != 101) )
         {
            A2283CBRubPre = P00CW25_A2283CBRubPre[0];
            A2282CBLinPre = P00CW25_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW25_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW25_A2280CBTipPre[0];
            A91CueCod = P00CW25_A91CueCod[0];
            A79COSCod = P00CW25_A79COSCod[0];
            n79COSCod = P00CW25_n79COSCod[0];
            A2284CBRubDItem = P00CW25_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 6;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(23);
               returnInSub = true;
               if (true) return;
            }
            AV41DImp6 = ((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo);
            pr_default.readNext(23);
         }
         pr_default.close(23);
         /* Using cursor P00CW26 */
         pr_default.execute(24, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre, AV12CBRubPre});
         while ( (pr_default.getStatus(24) != 101) )
         {
            A2283CBRubPre = P00CW26_A2283CBRubPre[0];
            A2282CBLinPre = P00CW26_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW26_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW26_A2280CBTipPre[0];
            A91CueCod = P00CW26_A91CueCod[0];
            A79COSCod = P00CW26_A79COSCod[0];
            n79COSCod = P00CW26_n79COSCod[0];
            A2284CBRubDItem = P00CW26_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 7;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(24);
               returnInSub = true;
               if (true) return;
            }
            AV42DImp7 = ((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo);
            pr_default.readNext(24);
         }
         pr_default.close(24);
         /* Using cursor P00CW27 */
         pr_default.execute(25, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre, AV12CBRubPre});
         while ( (pr_default.getStatus(25) != 101) )
         {
            A2283CBRubPre = P00CW27_A2283CBRubPre[0];
            A2282CBLinPre = P00CW27_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW27_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW27_A2280CBTipPre[0];
            A91CueCod = P00CW27_A91CueCod[0];
            A79COSCod = P00CW27_A79COSCod[0];
            n79COSCod = P00CW27_n79COSCod[0];
            A2284CBRubDItem = P00CW27_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 8;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(25);
               returnInSub = true;
               if (true) return;
            }
            AV43DImp8 = ((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo);
            pr_default.readNext(25);
         }
         pr_default.close(25);
         /* Using cursor P00CW28 */
         pr_default.execute(26, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre, AV12CBRubPre});
         while ( (pr_default.getStatus(26) != 101) )
         {
            A2283CBRubPre = P00CW28_A2283CBRubPre[0];
            A2282CBLinPre = P00CW28_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW28_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW28_A2280CBTipPre[0];
            A91CueCod = P00CW28_A91CueCod[0];
            A79COSCod = P00CW28_A79COSCod[0];
            n79COSCod = P00CW28_n79COSCod[0];
            A2284CBRubDItem = P00CW28_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 9;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(26);
               returnInSub = true;
               if (true) return;
            }
            AV44DImp9 = ((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo);
            pr_default.readNext(26);
         }
         pr_default.close(26);
         /* Using cursor P00CW29 */
         pr_default.execute(27, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre, AV12CBRubPre});
         while ( (pr_default.getStatus(27) != 101) )
         {
            A2283CBRubPre = P00CW29_A2283CBRubPre[0];
            A2282CBLinPre = P00CW29_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW29_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW29_A2280CBTipPre[0];
            A91CueCod = P00CW29_A91CueCod[0];
            A79COSCod = P00CW29_A79COSCod[0];
            n79COSCod = P00CW29_n79COSCod[0];
            A2284CBRubDItem = P00CW29_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 10;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(27);
               returnInSub = true;
               if (true) return;
            }
            AV34DImp10 = ((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo);
            pr_default.readNext(27);
         }
         pr_default.close(27);
         /* Using cursor P00CW30 */
         pr_default.execute(28, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre, AV12CBRubPre});
         while ( (pr_default.getStatus(28) != 101) )
         {
            A2283CBRubPre = P00CW30_A2283CBRubPre[0];
            A2282CBLinPre = P00CW30_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW30_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW30_A2280CBTipPre[0];
            A91CueCod = P00CW30_A91CueCod[0];
            A79COSCod = P00CW30_A79COSCod[0];
            n79COSCod = P00CW30_n79COSCod[0];
            A2284CBRubDItem = P00CW30_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 11;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(28);
               returnInSub = true;
               if (true) return;
            }
            AV35DImp11 = ((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo);
            pr_default.readNext(28);
         }
         pr_default.close(28);
         /* Using cursor P00CW31 */
         pr_default.execute(29, new Object[] {AV14CBTipPre, AV111Tip, AV8CBLinPre, AV12CBRubPre});
         while ( (pr_default.getStatus(29) != 101) )
         {
            A2283CBRubPre = P00CW31_A2283CBRubPre[0];
            A2282CBLinPre = P00CW31_A2282CBLinPre[0];
            A2281CBTipTipo = P00CW31_A2281CBTipTipo[0];
            A2280CBTipPre = P00CW31_A2280CBTipPre[0];
            A91CueCod = P00CW31_A91CueCod[0];
            A79COSCod = P00CW31_A79COSCod[0];
            n79COSCod = P00CW31_n79COSCod[0];
            A2284CBRubDItem = P00CW31_A2284CBRubDItem[0];
            AV18CueCod = A91CueCod;
            AV17CosCod = A79COSCod;
            AV78Mes = 12;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(29);
               returnInSub = true;
               if (true) return;
            }
            AV36DImp12 = ((AV110Saldo<Convert.ToDecimal(0)) ? AV110Saldo*-1 : AV110Saldo);
            pr_default.readNext(29);
         }
         pr_default.close(29);
         AV58DTOT = (decimal)(AV80PImp1+AV84PImp2+AV85PImp3+AV86PImp4+AV87PImp5+AV88PImp6+AV89PImp7+AV90PImp8+AV91PImp9+AV81PImp10+AV82PImp11+AV83PImp12);
         AV57DPTot = (decimal)(AV33DImp1+AV37DImp2+AV38DImp3+AV39DImp4+AV40DImp5+AV41DImp6+AV42DImp7+AV43DImp8+AV44DImp9+AV34DImp10+AV35DImp11+AV36DImp12);
         AV93Por1 = ((Convert.ToDecimal(0)==AV80PImp1) ? (decimal)(0) : NumberUtil.Round( (AV33DImp1/ (decimal)(AV80PImp1))*100, 2));
         AV97Por2 = ((Convert.ToDecimal(0)==AV84PImp2) ? (decimal)(0) : NumberUtil.Round( (AV37DImp2/ (decimal)(AV84PImp2))*100, 2));
         AV98Por3 = ((Convert.ToDecimal(0)==AV85PImp3) ? (decimal)(0) : NumberUtil.Round( (AV38DImp3/ (decimal)(AV85PImp3))*100, 2));
         AV99Por4 = ((Convert.ToDecimal(0)==AV86PImp4) ? (decimal)(0) : NumberUtil.Round( (AV39DImp4/ (decimal)(AV86PImp4))*100, 2));
         AV100Por5 = ((Convert.ToDecimal(0)==AV87PImp5) ? (decimal)(0) : NumberUtil.Round( (AV40DImp5/ (decimal)(AV87PImp5))*100, 2));
         AV101Por6 = ((Convert.ToDecimal(0)==AV88PImp6) ? (decimal)(0) : NumberUtil.Round( (AV41DImp6/ (decimal)(AV88PImp6))*100, 2));
         AV102Por7 = ((Convert.ToDecimal(0)==AV89PImp7) ? (decimal)(0) : NumberUtil.Round( (AV42DImp7/ (decimal)(AV89PImp7))*100, 2));
         AV103Por8 = ((Convert.ToDecimal(0)==AV90PImp8) ? (decimal)(0) : NumberUtil.Round( (AV43DImp8/ (decimal)(AV90PImp8))*100, 2));
         AV104Por9 = ((Convert.ToDecimal(0)==AV91PImp9) ? (decimal)(0) : NumberUtil.Round( (AV44DImp9/ (decimal)(AV91PImp9))*100, 2));
         AV94Por10 = ((Convert.ToDecimal(0)==AV81PImp10) ? (decimal)(0) : NumberUtil.Round( (AV34DImp10/ (decimal)(AV81PImp10))*100, 2));
         AV95Por11 = ((Convert.ToDecimal(0)==AV82PImp11) ? (decimal)(0) : NumberUtil.Round( (AV35DImp11/ (decimal)(AV82PImp11))*100, 2));
         AV96Por12 = ((Convert.ToDecimal(0)==AV83PImp12) ? (decimal)(0) : NumberUtil.Round( (AV36DImp12/ (decimal)(AV83PImp12))*100, 2));
         AV105PorT = ((Convert.ToDecimal(0)==AV58DTOT) ? (decimal)(0) : NumberUtil.Round( (AV57DPTot/ (decimal)(AV58DTOT))*100, 2));
      }

      protected void S143( )
      {
         /* 'DETALLELINEAS' Routine */
         returnInSub = false;
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+0), 1, 1).Text = StringUtil.Trim( AV15CBTipPreDsc);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV114TipoPresupuesto);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+2), 1, 1).Text = StringUtil.Trim( AV9CBLinPreDsc);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+3), 1, 1).Text = AV13CBRubPreDsc;
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+4), 1, 1).Number = (double)(AV80PImp1);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+5), 1, 1).Number = (double)(AV33DImp1);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+6), 1, 1).Number = (double)(AV93Por1);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+7), 1, 1).Number = (double)(AV84PImp2);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+8), 1, 1).Number = (double)(AV37DImp2);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+9), 1, 1).Number = (double)(AV97Por2);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+10), 1, 1).Number = (double)(AV85PImp3);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+11), 1, 1).Number = (double)(AV38DImp3);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+12), 1, 1).Number = (double)(AV98Por3);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+13), 1, 1).Number = (double)(AV86PImp4);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+14), 1, 1).Number = (double)(AV39DImp4);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+15), 1, 1).Number = (double)(AV99Por4);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+16), 1, 1).Number = (double)(AV87PImp5);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+17), 1, 1).Number = (double)(AV40DImp5);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+18), 1, 1).Number = (double)(AV100Por5);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+19), 1, 1).Number = (double)(AV88PImp6);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+20), 1, 1).Number = (double)(AV41DImp6);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+21), 1, 1).Number = (double)(AV101Por6);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+22), 1, 1).Number = (double)(AV89PImp7);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+23), 1, 1).Number = (double)(AV42DImp7);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+24), 1, 1).Number = (double)(AV102Por7);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+25), 1, 1).Number = (double)(AV90PImp8);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+26), 1, 1).Number = (double)(AV43DImp8);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+27), 1, 1).Number = (double)(AV103Por8);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+28), 1, 1).Number = (double)(AV91PImp9);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+29), 1, 1).Number = (double)(AV44DImp9);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+30), 1, 1).Number = (double)(AV104Por9);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+31), 1, 1).Number = (double)(AV81PImp10);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+32), 1, 1).Number = (double)(AV34DImp10);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+33), 1, 1).Number = (double)(AV94Por10);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+34), 1, 1).Number = (double)(AV82PImp11);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+35), 1, 1).Number = (double)(AV35DImp11);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+36), 1, 1).Number = (double)(AV95Por11);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+37), 1, 1).Number = (double)(AV83PImp12);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+38), 1, 1).Number = (double)(AV36DImp12);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+39), 1, 1).Number = (double)(AV96Por12);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+40), 1, 1).Number = (double)(AV58DTOT);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+41), 1, 1).Number = (double)(AV57DPTot);
         AV60ExcelDocument.get_Cells((int)(AV16CellRow), (int)(AV63FirstColumn+42), 1, 1).Number = (double)(AV105PorT);
         AV16CellRow = (long)(AV16CellRow+1);
      }

      protected void S171( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV60ExcelDocument.ErrCode != 0 )
         {
            AV61Filename = "";
            AV59ErrorMessage = AV60ExcelDocument.ErrDescription;
            AV60ExcelDocument.Close();
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
         AV61Filename = "";
         AV59ErrorMessage = "";
         AV11Archivo = new GxFile(context.GetPhysicalPath());
         AV79Path = "";
         AV62FilenameOrigen = "";
         AV60ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P00CW2_A2280CBTipPre = new int[1] ;
         P00CW2_A2291CBTipPreDsc = new string[] {""} ;
         P00CW2_A180MonCod = new int[1] ;
         A2291CBTipPreDsc = "";
         AV15CBTipPreDsc = "";
         AV114TipoPresupuesto = "";
         AV111Tip = "";
         P00CW3_A2280CBTipPre = new int[1] ;
         P00CW3_A2281CBTipTipo = new string[] {""} ;
         P00CW3_A2291CBTipPreDsc = new string[] {""} ;
         P00CW3_A2282CBLinPre = new int[1] ;
         P00CW3_A2289CBLinPreDsc = new string[] {""} ;
         A2281CBTipTipo = "";
         A2289CBLinPreDsc = "";
         AV9CBLinPreDsc = "";
         P00CW4_A2296CBRubPreEne = new decimal[1] ;
         P00CW4_A2297CBRubPreFeb = new decimal[1] ;
         P00CW4_A2298CBRubPreMar = new decimal[1] ;
         P00CW4_A2299CBRubPreAbr = new decimal[1] ;
         P00CW4_A2300CBRubPreMay = new decimal[1] ;
         P00CW4_A2301CBRubPreJun = new decimal[1] ;
         P00CW4_A2302CBRubPreJul = new decimal[1] ;
         P00CW4_A2303CBRubPreAgo = new decimal[1] ;
         P00CW4_A2304CBRubPreSep = new decimal[1] ;
         P00CW4_A2305CBRubPreOct = new decimal[1] ;
         P00CW4_A2306CBRubPreNov = new decimal[1] ;
         P00CW4_A2307CBRubPreDic = new decimal[1] ;
         P00CW5_A2282CBLinPre = new int[1] ;
         P00CW5_A2281CBTipTipo = new string[] {""} ;
         P00CW5_A2280CBTipPre = new int[1] ;
         P00CW5_A91CueCod = new string[] {""} ;
         P00CW5_A79COSCod = new string[] {""} ;
         P00CW5_n79COSCod = new bool[] {false} ;
         P00CW5_A2283CBRubPre = new int[1] ;
         P00CW5_A2284CBRubDItem = new int[1] ;
         A91CueCod = "";
         A79COSCod = "";
         AV18CueCod = "";
         AV17CosCod = "";
         P00CW6_A2282CBLinPre = new int[1] ;
         P00CW6_A2281CBTipTipo = new string[] {""} ;
         P00CW6_A2280CBTipPre = new int[1] ;
         P00CW6_A91CueCod = new string[] {""} ;
         P00CW6_A79COSCod = new string[] {""} ;
         P00CW6_n79COSCod = new bool[] {false} ;
         P00CW6_A2283CBRubPre = new int[1] ;
         P00CW6_A2284CBRubDItem = new int[1] ;
         P00CW7_A2282CBLinPre = new int[1] ;
         P00CW7_A2281CBTipTipo = new string[] {""} ;
         P00CW7_A2280CBTipPre = new int[1] ;
         P00CW7_A91CueCod = new string[] {""} ;
         P00CW7_A79COSCod = new string[] {""} ;
         P00CW7_n79COSCod = new bool[] {false} ;
         P00CW7_A2283CBRubPre = new int[1] ;
         P00CW7_A2284CBRubDItem = new int[1] ;
         P00CW8_A2282CBLinPre = new int[1] ;
         P00CW8_A2281CBTipTipo = new string[] {""} ;
         P00CW8_A2280CBTipPre = new int[1] ;
         P00CW8_A91CueCod = new string[] {""} ;
         P00CW8_A79COSCod = new string[] {""} ;
         P00CW8_n79COSCod = new bool[] {false} ;
         P00CW8_A2283CBRubPre = new int[1] ;
         P00CW8_A2284CBRubDItem = new int[1] ;
         P00CW9_A2282CBLinPre = new int[1] ;
         P00CW9_A2281CBTipTipo = new string[] {""} ;
         P00CW9_A2280CBTipPre = new int[1] ;
         P00CW9_A91CueCod = new string[] {""} ;
         P00CW9_A79COSCod = new string[] {""} ;
         P00CW9_n79COSCod = new bool[] {false} ;
         P00CW9_A2283CBRubPre = new int[1] ;
         P00CW9_A2284CBRubDItem = new int[1] ;
         P00CW10_A2282CBLinPre = new int[1] ;
         P00CW10_A2281CBTipTipo = new string[] {""} ;
         P00CW10_A2280CBTipPre = new int[1] ;
         P00CW10_A91CueCod = new string[] {""} ;
         P00CW10_A79COSCod = new string[] {""} ;
         P00CW10_n79COSCod = new bool[] {false} ;
         P00CW10_A2283CBRubPre = new int[1] ;
         P00CW10_A2284CBRubDItem = new int[1] ;
         P00CW11_A2282CBLinPre = new int[1] ;
         P00CW11_A2281CBTipTipo = new string[] {""} ;
         P00CW11_A2280CBTipPre = new int[1] ;
         P00CW11_A91CueCod = new string[] {""} ;
         P00CW11_A79COSCod = new string[] {""} ;
         P00CW11_n79COSCod = new bool[] {false} ;
         P00CW11_A2283CBRubPre = new int[1] ;
         P00CW11_A2284CBRubDItem = new int[1] ;
         P00CW12_A2282CBLinPre = new int[1] ;
         P00CW12_A2281CBTipTipo = new string[] {""} ;
         P00CW12_A2280CBTipPre = new int[1] ;
         P00CW12_A91CueCod = new string[] {""} ;
         P00CW12_A79COSCod = new string[] {""} ;
         P00CW12_n79COSCod = new bool[] {false} ;
         P00CW12_A2283CBRubPre = new int[1] ;
         P00CW12_A2284CBRubDItem = new int[1] ;
         P00CW13_A2282CBLinPre = new int[1] ;
         P00CW13_A2281CBTipTipo = new string[] {""} ;
         P00CW13_A2280CBTipPre = new int[1] ;
         P00CW13_A91CueCod = new string[] {""} ;
         P00CW13_A79COSCod = new string[] {""} ;
         P00CW13_n79COSCod = new bool[] {false} ;
         P00CW13_A2283CBRubPre = new int[1] ;
         P00CW13_A2284CBRubDItem = new int[1] ;
         P00CW14_A2282CBLinPre = new int[1] ;
         P00CW14_A2281CBTipTipo = new string[] {""} ;
         P00CW14_A2280CBTipPre = new int[1] ;
         P00CW14_A91CueCod = new string[] {""} ;
         P00CW14_A79COSCod = new string[] {""} ;
         P00CW14_n79COSCod = new bool[] {false} ;
         P00CW14_A2283CBRubPre = new int[1] ;
         P00CW14_A2284CBRubDItem = new int[1] ;
         P00CW15_A2282CBLinPre = new int[1] ;
         P00CW15_A2281CBTipTipo = new string[] {""} ;
         P00CW15_A2280CBTipPre = new int[1] ;
         P00CW15_A91CueCod = new string[] {""} ;
         P00CW15_A79COSCod = new string[] {""} ;
         P00CW15_n79COSCod = new bool[] {false} ;
         P00CW15_A2283CBRubPre = new int[1] ;
         P00CW15_A2284CBRubDItem = new int[1] ;
         P00CW16_A2282CBLinPre = new int[1] ;
         P00CW16_A2281CBTipTipo = new string[] {""} ;
         P00CW16_A2280CBTipPre = new int[1] ;
         P00CW16_A91CueCod = new string[] {""} ;
         P00CW16_A79COSCod = new string[] {""} ;
         P00CW16_n79COSCod = new bool[] {false} ;
         P00CW16_A2283CBRubPre = new int[1] ;
         P00CW16_A2284CBRubDItem = new int[1] ;
         P00CW17_A126TASICod = new int[1] ;
         P00CW17_A129VouNum = new string[] {""} ;
         P00CW17_A2077VouSts = new short[1] ;
         P00CW17_A79COSCod = new string[] {""} ;
         P00CW17_n79COSCod = new bool[] {false} ;
         P00CW17_A91CueCod = new string[] {""} ;
         P00CW17_A128VouMes = new short[1] ;
         P00CW17_A127VouAno = new short[1] ;
         P00CW17_A864CueMon = new short[1] ;
         P00CW17_A2056VouDHabO = new decimal[1] ;
         P00CW17_A2052VouDDebO = new decimal[1] ;
         P00CW17_A2069VouDTcmb = new decimal[1] ;
         P00CW17_A2055VouDHab = new decimal[1] ;
         P00CW17_A2051VouDDeb = new decimal[1] ;
         P00CW17_A130VouDSec = new int[1] ;
         A129VouNum = "";
         P00CW18_A2282CBLinPre = new int[1] ;
         P00CW18_A2281CBTipTipo = new string[] {""} ;
         P00CW18_A2280CBTipPre = new int[1] ;
         P00CW18_A2283CBRubPre = new int[1] ;
         P00CW18_A2293CBRubPreDsc = new string[] {""} ;
         A2293CBRubPreDsc = "";
         AV13CBRubPreDsc = "";
         P00CW19_A2296CBRubPreEne = new decimal[1] ;
         P00CW19_A2297CBRubPreFeb = new decimal[1] ;
         P00CW19_A2298CBRubPreMar = new decimal[1] ;
         P00CW19_A2299CBRubPreAbr = new decimal[1] ;
         P00CW19_A2300CBRubPreMay = new decimal[1] ;
         P00CW19_A2301CBRubPreJun = new decimal[1] ;
         P00CW19_A2302CBRubPreJul = new decimal[1] ;
         P00CW19_A2303CBRubPreAgo = new decimal[1] ;
         P00CW19_A2304CBRubPreSep = new decimal[1] ;
         P00CW19_A2305CBRubPreOct = new decimal[1] ;
         P00CW19_A2306CBRubPreNov = new decimal[1] ;
         P00CW19_A2307CBRubPreDic = new decimal[1] ;
         P00CW20_A2283CBRubPre = new int[1] ;
         P00CW20_A2282CBLinPre = new int[1] ;
         P00CW20_A2281CBTipTipo = new string[] {""} ;
         P00CW20_A2280CBTipPre = new int[1] ;
         P00CW20_A91CueCod = new string[] {""} ;
         P00CW20_A79COSCod = new string[] {""} ;
         P00CW20_n79COSCod = new bool[] {false} ;
         P00CW20_A2284CBRubDItem = new int[1] ;
         P00CW21_A2283CBRubPre = new int[1] ;
         P00CW21_A2282CBLinPre = new int[1] ;
         P00CW21_A2281CBTipTipo = new string[] {""} ;
         P00CW21_A2280CBTipPre = new int[1] ;
         P00CW21_A91CueCod = new string[] {""} ;
         P00CW21_A79COSCod = new string[] {""} ;
         P00CW21_n79COSCod = new bool[] {false} ;
         P00CW21_A2284CBRubDItem = new int[1] ;
         P00CW22_A2283CBRubPre = new int[1] ;
         P00CW22_A2282CBLinPre = new int[1] ;
         P00CW22_A2281CBTipTipo = new string[] {""} ;
         P00CW22_A2280CBTipPre = new int[1] ;
         P00CW22_A91CueCod = new string[] {""} ;
         P00CW22_A79COSCod = new string[] {""} ;
         P00CW22_n79COSCod = new bool[] {false} ;
         P00CW22_A2284CBRubDItem = new int[1] ;
         P00CW23_A2283CBRubPre = new int[1] ;
         P00CW23_A2282CBLinPre = new int[1] ;
         P00CW23_A2281CBTipTipo = new string[] {""} ;
         P00CW23_A2280CBTipPre = new int[1] ;
         P00CW23_A91CueCod = new string[] {""} ;
         P00CW23_A79COSCod = new string[] {""} ;
         P00CW23_n79COSCod = new bool[] {false} ;
         P00CW23_A2284CBRubDItem = new int[1] ;
         P00CW24_A2283CBRubPre = new int[1] ;
         P00CW24_A2282CBLinPre = new int[1] ;
         P00CW24_A2281CBTipTipo = new string[] {""} ;
         P00CW24_A2280CBTipPre = new int[1] ;
         P00CW24_A91CueCod = new string[] {""} ;
         P00CW24_A79COSCod = new string[] {""} ;
         P00CW24_n79COSCod = new bool[] {false} ;
         P00CW24_A2284CBRubDItem = new int[1] ;
         P00CW25_A2283CBRubPre = new int[1] ;
         P00CW25_A2282CBLinPre = new int[1] ;
         P00CW25_A2281CBTipTipo = new string[] {""} ;
         P00CW25_A2280CBTipPre = new int[1] ;
         P00CW25_A91CueCod = new string[] {""} ;
         P00CW25_A79COSCod = new string[] {""} ;
         P00CW25_n79COSCod = new bool[] {false} ;
         P00CW25_A2284CBRubDItem = new int[1] ;
         P00CW26_A2283CBRubPre = new int[1] ;
         P00CW26_A2282CBLinPre = new int[1] ;
         P00CW26_A2281CBTipTipo = new string[] {""} ;
         P00CW26_A2280CBTipPre = new int[1] ;
         P00CW26_A91CueCod = new string[] {""} ;
         P00CW26_A79COSCod = new string[] {""} ;
         P00CW26_n79COSCod = new bool[] {false} ;
         P00CW26_A2284CBRubDItem = new int[1] ;
         P00CW27_A2283CBRubPre = new int[1] ;
         P00CW27_A2282CBLinPre = new int[1] ;
         P00CW27_A2281CBTipTipo = new string[] {""} ;
         P00CW27_A2280CBTipPre = new int[1] ;
         P00CW27_A91CueCod = new string[] {""} ;
         P00CW27_A79COSCod = new string[] {""} ;
         P00CW27_n79COSCod = new bool[] {false} ;
         P00CW27_A2284CBRubDItem = new int[1] ;
         P00CW28_A2283CBRubPre = new int[1] ;
         P00CW28_A2282CBLinPre = new int[1] ;
         P00CW28_A2281CBTipTipo = new string[] {""} ;
         P00CW28_A2280CBTipPre = new int[1] ;
         P00CW28_A91CueCod = new string[] {""} ;
         P00CW28_A79COSCod = new string[] {""} ;
         P00CW28_n79COSCod = new bool[] {false} ;
         P00CW28_A2284CBRubDItem = new int[1] ;
         P00CW29_A2283CBRubPre = new int[1] ;
         P00CW29_A2282CBLinPre = new int[1] ;
         P00CW29_A2281CBTipTipo = new string[] {""} ;
         P00CW29_A2280CBTipPre = new int[1] ;
         P00CW29_A91CueCod = new string[] {""} ;
         P00CW29_A79COSCod = new string[] {""} ;
         P00CW29_n79COSCod = new bool[] {false} ;
         P00CW29_A2284CBRubDItem = new int[1] ;
         P00CW30_A2283CBRubPre = new int[1] ;
         P00CW30_A2282CBLinPre = new int[1] ;
         P00CW30_A2281CBTipTipo = new string[] {""} ;
         P00CW30_A2280CBTipPre = new int[1] ;
         P00CW30_A91CueCod = new string[] {""} ;
         P00CW30_A79COSCod = new string[] {""} ;
         P00CW30_n79COSCod = new bool[] {false} ;
         P00CW30_A2284CBRubDItem = new int[1] ;
         P00CW31_A2283CBRubPre = new int[1] ;
         P00CW31_A2282CBLinPre = new int[1] ;
         P00CW31_A2281CBTipTipo = new string[] {""} ;
         P00CW31_A2280CBTipPre = new int[1] ;
         P00CW31_A91CueCod = new string[] {""} ;
         P00CW31_A79COSCod = new string[] {""} ;
         P00CW31_n79COSCod = new bool[] {false} ;
         P00CW31_A2284CBRubDItem = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_resumenanualpresupuestoanualexcel__default(),
            new Object[][] {
                new Object[] {
               P00CW2_A2280CBTipPre, P00CW2_A2291CBTipPreDsc, P00CW2_A180MonCod
               }
               , new Object[] {
               P00CW3_A2280CBTipPre, P00CW3_A2281CBTipTipo, P00CW3_A2291CBTipPreDsc, P00CW3_A2282CBLinPre, P00CW3_A2289CBLinPreDsc
               }
               , new Object[] {
               P00CW4_A2296CBRubPreEne, P00CW4_A2297CBRubPreFeb, P00CW4_A2298CBRubPreMar, P00CW4_A2299CBRubPreAbr, P00CW4_A2300CBRubPreMay, P00CW4_A2301CBRubPreJun, P00CW4_A2302CBRubPreJul, P00CW4_A2303CBRubPreAgo, P00CW4_A2304CBRubPreSep, P00CW4_A2305CBRubPreOct,
               P00CW4_A2306CBRubPreNov, P00CW4_A2307CBRubPreDic
               }
               , new Object[] {
               P00CW5_A2282CBLinPre, P00CW5_A2281CBTipTipo, P00CW5_A2280CBTipPre, P00CW5_A91CueCod, P00CW5_A79COSCod, P00CW5_n79COSCod, P00CW5_A2283CBRubPre, P00CW5_A2284CBRubDItem
               }
               , new Object[] {
               P00CW6_A2282CBLinPre, P00CW6_A2281CBTipTipo, P00CW6_A2280CBTipPre, P00CW6_A91CueCod, P00CW6_A79COSCod, P00CW6_n79COSCod, P00CW6_A2283CBRubPre, P00CW6_A2284CBRubDItem
               }
               , new Object[] {
               P00CW7_A2282CBLinPre, P00CW7_A2281CBTipTipo, P00CW7_A2280CBTipPre, P00CW7_A91CueCod, P00CW7_A79COSCod, P00CW7_n79COSCod, P00CW7_A2283CBRubPre, P00CW7_A2284CBRubDItem
               }
               , new Object[] {
               P00CW8_A2282CBLinPre, P00CW8_A2281CBTipTipo, P00CW8_A2280CBTipPre, P00CW8_A91CueCod, P00CW8_A79COSCod, P00CW8_n79COSCod, P00CW8_A2283CBRubPre, P00CW8_A2284CBRubDItem
               }
               , new Object[] {
               P00CW9_A2282CBLinPre, P00CW9_A2281CBTipTipo, P00CW9_A2280CBTipPre, P00CW9_A91CueCod, P00CW9_A79COSCod, P00CW9_n79COSCod, P00CW9_A2283CBRubPre, P00CW9_A2284CBRubDItem
               }
               , new Object[] {
               P00CW10_A2282CBLinPre, P00CW10_A2281CBTipTipo, P00CW10_A2280CBTipPre, P00CW10_A91CueCod, P00CW10_A79COSCod, P00CW10_n79COSCod, P00CW10_A2283CBRubPre, P00CW10_A2284CBRubDItem
               }
               , new Object[] {
               P00CW11_A2282CBLinPre, P00CW11_A2281CBTipTipo, P00CW11_A2280CBTipPre, P00CW11_A91CueCod, P00CW11_A79COSCod, P00CW11_n79COSCod, P00CW11_A2283CBRubPre, P00CW11_A2284CBRubDItem
               }
               , new Object[] {
               P00CW12_A2282CBLinPre, P00CW12_A2281CBTipTipo, P00CW12_A2280CBTipPre, P00CW12_A91CueCod, P00CW12_A79COSCod, P00CW12_n79COSCod, P00CW12_A2283CBRubPre, P00CW12_A2284CBRubDItem
               }
               , new Object[] {
               P00CW13_A2282CBLinPre, P00CW13_A2281CBTipTipo, P00CW13_A2280CBTipPre, P00CW13_A91CueCod, P00CW13_A79COSCod, P00CW13_n79COSCod, P00CW13_A2283CBRubPre, P00CW13_A2284CBRubDItem
               }
               , new Object[] {
               P00CW14_A2282CBLinPre, P00CW14_A2281CBTipTipo, P00CW14_A2280CBTipPre, P00CW14_A91CueCod, P00CW14_A79COSCod, P00CW14_n79COSCod, P00CW14_A2283CBRubPre, P00CW14_A2284CBRubDItem
               }
               , new Object[] {
               P00CW15_A2282CBLinPre, P00CW15_A2281CBTipTipo, P00CW15_A2280CBTipPre, P00CW15_A91CueCod, P00CW15_A79COSCod, P00CW15_n79COSCod, P00CW15_A2283CBRubPre, P00CW15_A2284CBRubDItem
               }
               , new Object[] {
               P00CW16_A2282CBLinPre, P00CW16_A2281CBTipTipo, P00CW16_A2280CBTipPre, P00CW16_A91CueCod, P00CW16_A79COSCod, P00CW16_n79COSCod, P00CW16_A2283CBRubPre, P00CW16_A2284CBRubDItem
               }
               , new Object[] {
               P00CW17_A126TASICod, P00CW17_A129VouNum, P00CW17_A2077VouSts, P00CW17_A79COSCod, P00CW17_n79COSCod, P00CW17_A91CueCod, P00CW17_A128VouMes, P00CW17_A127VouAno, P00CW17_A864CueMon, P00CW17_A2056VouDHabO,
               P00CW17_A2052VouDDebO, P00CW17_A2069VouDTcmb, P00CW17_A2055VouDHab, P00CW17_A2051VouDDeb, P00CW17_A130VouDSec
               }
               , new Object[] {
               P00CW18_A2282CBLinPre, P00CW18_A2281CBTipTipo, P00CW18_A2280CBTipPre, P00CW18_A2283CBRubPre, P00CW18_A2293CBRubPreDsc
               }
               , new Object[] {
               P00CW19_A2296CBRubPreEne, P00CW19_A2297CBRubPreFeb, P00CW19_A2298CBRubPreMar, P00CW19_A2299CBRubPreAbr, P00CW19_A2300CBRubPreMay, P00CW19_A2301CBRubPreJun, P00CW19_A2302CBRubPreJul, P00CW19_A2303CBRubPreAgo, P00CW19_A2304CBRubPreSep, P00CW19_A2305CBRubPreOct,
               P00CW19_A2306CBRubPreNov, P00CW19_A2307CBRubPreDic
               }
               , new Object[] {
               P00CW20_A2283CBRubPre, P00CW20_A2282CBLinPre, P00CW20_A2281CBTipTipo, P00CW20_A2280CBTipPre, P00CW20_A91CueCod, P00CW20_A79COSCod, P00CW20_n79COSCod, P00CW20_A2284CBRubDItem
               }
               , new Object[] {
               P00CW21_A2283CBRubPre, P00CW21_A2282CBLinPre, P00CW21_A2281CBTipTipo, P00CW21_A2280CBTipPre, P00CW21_A91CueCod, P00CW21_A79COSCod, P00CW21_n79COSCod, P00CW21_A2284CBRubDItem
               }
               , new Object[] {
               P00CW22_A2283CBRubPre, P00CW22_A2282CBLinPre, P00CW22_A2281CBTipTipo, P00CW22_A2280CBTipPre, P00CW22_A91CueCod, P00CW22_A79COSCod, P00CW22_n79COSCod, P00CW22_A2284CBRubDItem
               }
               , new Object[] {
               P00CW23_A2283CBRubPre, P00CW23_A2282CBLinPre, P00CW23_A2281CBTipTipo, P00CW23_A2280CBTipPre, P00CW23_A91CueCod, P00CW23_A79COSCod, P00CW23_n79COSCod, P00CW23_A2284CBRubDItem
               }
               , new Object[] {
               P00CW24_A2283CBRubPre, P00CW24_A2282CBLinPre, P00CW24_A2281CBTipTipo, P00CW24_A2280CBTipPre, P00CW24_A91CueCod, P00CW24_A79COSCod, P00CW24_n79COSCod, P00CW24_A2284CBRubDItem
               }
               , new Object[] {
               P00CW25_A2283CBRubPre, P00CW25_A2282CBLinPre, P00CW25_A2281CBTipTipo, P00CW25_A2280CBTipPre, P00CW25_A91CueCod, P00CW25_A79COSCod, P00CW25_n79COSCod, P00CW25_A2284CBRubDItem
               }
               , new Object[] {
               P00CW26_A2283CBRubPre, P00CW26_A2282CBLinPre, P00CW26_A2281CBTipTipo, P00CW26_A2280CBTipPre, P00CW26_A91CueCod, P00CW26_A79COSCod, P00CW26_n79COSCod, P00CW26_A2284CBRubDItem
               }
               , new Object[] {
               P00CW27_A2283CBRubPre, P00CW27_A2282CBLinPre, P00CW27_A2281CBTipTipo, P00CW27_A2280CBTipPre, P00CW27_A91CueCod, P00CW27_A79COSCod, P00CW27_n79COSCod, P00CW27_A2284CBRubDItem
               }
               , new Object[] {
               P00CW28_A2283CBRubPre, P00CW28_A2282CBLinPre, P00CW28_A2281CBTipTipo, P00CW28_A2280CBTipPre, P00CW28_A91CueCod, P00CW28_A79COSCod, P00CW28_n79COSCod, P00CW28_A2284CBRubDItem
               }
               , new Object[] {
               P00CW29_A2283CBRubPre, P00CW29_A2282CBLinPre, P00CW29_A2281CBTipTipo, P00CW29_A2280CBTipPre, P00CW29_A91CueCod, P00CW29_A79COSCod, P00CW29_n79COSCod, P00CW29_A2284CBRubDItem
               }
               , new Object[] {
               P00CW30_A2283CBRubPre, P00CW30_A2282CBLinPre, P00CW30_A2281CBTipTipo, P00CW30_A2280CBTipPre, P00CW30_A91CueCod, P00CW30_A79COSCod, P00CW30_n79COSCod, P00CW30_A2284CBRubDItem
               }
               , new Object[] {
               P00CW31_A2283CBRubPre, P00CW31_A2282CBLinPre, P00CW31_A2281CBTipTipo, P00CW31_A2280CBTipPre, P00CW31_A91CueCod, P00CW31_A79COSCod, P00CW31_n79COSCod, P00CW31_A2284CBRubDItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10Ano ;
      private short AV78Mes ;
      private short A2077VouSts ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short A864CueMon ;
      private short AV119CueMon ;
      private int AV14CBTipPre ;
      private int A2280CBTipPre ;
      private int A180MonCod ;
      private int AV118MonCod ;
      private int A2282CBLinPre ;
      private int AV8CBLinPre ;
      private int AV12CBRubPre ;
      private int A2283CBRubPre ;
      private int A2284CBRubDItem ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private long AV16CellRow ;
      private long AV63FirstColumn ;
      private long AV64i ;
      private decimal AV80PImp1 ;
      private decimal AV84PImp2 ;
      private decimal AV85PImp3 ;
      private decimal AV86PImp4 ;
      private decimal AV87PImp5 ;
      private decimal AV88PImp6 ;
      private decimal AV89PImp7 ;
      private decimal AV90PImp8 ;
      private decimal AV91PImp9 ;
      private decimal AV81PImp10 ;
      private decimal AV82PImp11 ;
      private decimal AV83PImp12 ;
      private decimal AV33DImp1 ;
      private decimal AV37DImp2 ;
      private decimal AV38DImp3 ;
      private decimal AV39DImp4 ;
      private decimal AV40DImp5 ;
      private decimal AV41DImp6 ;
      private decimal AV42DImp7 ;
      private decimal AV43DImp8 ;
      private decimal AV44DImp9 ;
      private decimal AV34DImp10 ;
      private decimal AV35DImp11 ;
      private decimal AV36DImp12 ;
      private decimal c2296CBRubPreEne ;
      private decimal c2297CBRubPreFeb ;
      private decimal c2298CBRubPreMar ;
      private decimal c2299CBRubPreAbr ;
      private decimal c2300CBRubPreMay ;
      private decimal c2301CBRubPreJun ;
      private decimal c2302CBRubPreJul ;
      private decimal c2303CBRubPreAgo ;
      private decimal c2304CBRubPreSep ;
      private decimal c2305CBRubPreOct ;
      private decimal c2306CBRubPreNov ;
      private decimal c2307CBRubPreDic ;
      private decimal AV110Saldo ;
      private decimal AV58DTOT ;
      private decimal AV57DPTot ;
      private decimal AV93Por1 ;
      private decimal AV97Por2 ;
      private decimal AV98Por3 ;
      private decimal AV99Por4 ;
      private decimal AV100Por5 ;
      private decimal AV101Por6 ;
      private decimal AV102Por7 ;
      private decimal AV103Por8 ;
      private decimal AV104Por9 ;
      private decimal AV94Por10 ;
      private decimal AV95Por11 ;
      private decimal AV96Por12 ;
      private decimal AV105PorT ;
      private decimal A2056VouDHabO ;
      private decimal A2052VouDDebO ;
      private decimal A2069VouDTcmb ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A79COSCod ;
      private string AV18CueCod ;
      private string AV17CosCod ;
      private string A129VouNum ;
      private bool returnInSub ;
      private bool n79COSCod ;
      private string AV113TipoDetalle ;
      private string AV61Filename ;
      private string AV59ErrorMessage ;
      private string AV79Path ;
      private string AV62FilenameOrigen ;
      private string A2291CBTipPreDsc ;
      private string AV15CBTipPreDsc ;
      private string AV114TipoPresupuesto ;
      private string AV111Tip ;
      private string A2281CBTipTipo ;
      private string A2289CBLinPreDsc ;
      private string AV9CBLinPreDsc ;
      private string A2293CBRubPreDsc ;
      private string AV13CBRubPreDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private int aP1_CBTipPre ;
      private string aP2_TipoDetalle ;
      private IDataStoreProvider pr_default ;
      private int[] P00CW2_A2280CBTipPre ;
      private string[] P00CW2_A2291CBTipPreDsc ;
      private int[] P00CW2_A180MonCod ;
      private int[] P00CW3_A2280CBTipPre ;
      private string[] P00CW3_A2281CBTipTipo ;
      private string[] P00CW3_A2291CBTipPreDsc ;
      private int[] P00CW3_A2282CBLinPre ;
      private string[] P00CW3_A2289CBLinPreDsc ;
      private decimal[] P00CW4_A2296CBRubPreEne ;
      private decimal[] P00CW4_A2297CBRubPreFeb ;
      private decimal[] P00CW4_A2298CBRubPreMar ;
      private decimal[] P00CW4_A2299CBRubPreAbr ;
      private decimal[] P00CW4_A2300CBRubPreMay ;
      private decimal[] P00CW4_A2301CBRubPreJun ;
      private decimal[] P00CW4_A2302CBRubPreJul ;
      private decimal[] P00CW4_A2303CBRubPreAgo ;
      private decimal[] P00CW4_A2304CBRubPreSep ;
      private decimal[] P00CW4_A2305CBRubPreOct ;
      private decimal[] P00CW4_A2306CBRubPreNov ;
      private decimal[] P00CW4_A2307CBRubPreDic ;
      private int[] P00CW5_A2282CBLinPre ;
      private string[] P00CW5_A2281CBTipTipo ;
      private int[] P00CW5_A2280CBTipPre ;
      private string[] P00CW5_A91CueCod ;
      private string[] P00CW5_A79COSCod ;
      private bool[] P00CW5_n79COSCod ;
      private int[] P00CW5_A2283CBRubPre ;
      private int[] P00CW5_A2284CBRubDItem ;
      private int[] P00CW6_A2282CBLinPre ;
      private string[] P00CW6_A2281CBTipTipo ;
      private int[] P00CW6_A2280CBTipPre ;
      private string[] P00CW6_A91CueCod ;
      private string[] P00CW6_A79COSCod ;
      private bool[] P00CW6_n79COSCod ;
      private int[] P00CW6_A2283CBRubPre ;
      private int[] P00CW6_A2284CBRubDItem ;
      private int[] P00CW7_A2282CBLinPre ;
      private string[] P00CW7_A2281CBTipTipo ;
      private int[] P00CW7_A2280CBTipPre ;
      private string[] P00CW7_A91CueCod ;
      private string[] P00CW7_A79COSCod ;
      private bool[] P00CW7_n79COSCod ;
      private int[] P00CW7_A2283CBRubPre ;
      private int[] P00CW7_A2284CBRubDItem ;
      private int[] P00CW8_A2282CBLinPre ;
      private string[] P00CW8_A2281CBTipTipo ;
      private int[] P00CW8_A2280CBTipPre ;
      private string[] P00CW8_A91CueCod ;
      private string[] P00CW8_A79COSCod ;
      private bool[] P00CW8_n79COSCod ;
      private int[] P00CW8_A2283CBRubPre ;
      private int[] P00CW8_A2284CBRubDItem ;
      private int[] P00CW9_A2282CBLinPre ;
      private string[] P00CW9_A2281CBTipTipo ;
      private int[] P00CW9_A2280CBTipPre ;
      private string[] P00CW9_A91CueCod ;
      private string[] P00CW9_A79COSCod ;
      private bool[] P00CW9_n79COSCod ;
      private int[] P00CW9_A2283CBRubPre ;
      private int[] P00CW9_A2284CBRubDItem ;
      private int[] P00CW10_A2282CBLinPre ;
      private string[] P00CW10_A2281CBTipTipo ;
      private int[] P00CW10_A2280CBTipPre ;
      private string[] P00CW10_A91CueCod ;
      private string[] P00CW10_A79COSCod ;
      private bool[] P00CW10_n79COSCod ;
      private int[] P00CW10_A2283CBRubPre ;
      private int[] P00CW10_A2284CBRubDItem ;
      private int[] P00CW11_A2282CBLinPre ;
      private string[] P00CW11_A2281CBTipTipo ;
      private int[] P00CW11_A2280CBTipPre ;
      private string[] P00CW11_A91CueCod ;
      private string[] P00CW11_A79COSCod ;
      private bool[] P00CW11_n79COSCod ;
      private int[] P00CW11_A2283CBRubPre ;
      private int[] P00CW11_A2284CBRubDItem ;
      private int[] P00CW12_A2282CBLinPre ;
      private string[] P00CW12_A2281CBTipTipo ;
      private int[] P00CW12_A2280CBTipPre ;
      private string[] P00CW12_A91CueCod ;
      private string[] P00CW12_A79COSCod ;
      private bool[] P00CW12_n79COSCod ;
      private int[] P00CW12_A2283CBRubPre ;
      private int[] P00CW12_A2284CBRubDItem ;
      private int[] P00CW13_A2282CBLinPre ;
      private string[] P00CW13_A2281CBTipTipo ;
      private int[] P00CW13_A2280CBTipPre ;
      private string[] P00CW13_A91CueCod ;
      private string[] P00CW13_A79COSCod ;
      private bool[] P00CW13_n79COSCod ;
      private int[] P00CW13_A2283CBRubPre ;
      private int[] P00CW13_A2284CBRubDItem ;
      private int[] P00CW14_A2282CBLinPre ;
      private string[] P00CW14_A2281CBTipTipo ;
      private int[] P00CW14_A2280CBTipPre ;
      private string[] P00CW14_A91CueCod ;
      private string[] P00CW14_A79COSCod ;
      private bool[] P00CW14_n79COSCod ;
      private int[] P00CW14_A2283CBRubPre ;
      private int[] P00CW14_A2284CBRubDItem ;
      private int[] P00CW15_A2282CBLinPre ;
      private string[] P00CW15_A2281CBTipTipo ;
      private int[] P00CW15_A2280CBTipPre ;
      private string[] P00CW15_A91CueCod ;
      private string[] P00CW15_A79COSCod ;
      private bool[] P00CW15_n79COSCod ;
      private int[] P00CW15_A2283CBRubPre ;
      private int[] P00CW15_A2284CBRubDItem ;
      private int[] P00CW16_A2282CBLinPre ;
      private string[] P00CW16_A2281CBTipTipo ;
      private int[] P00CW16_A2280CBTipPre ;
      private string[] P00CW16_A91CueCod ;
      private string[] P00CW16_A79COSCod ;
      private bool[] P00CW16_n79COSCod ;
      private int[] P00CW16_A2283CBRubPre ;
      private int[] P00CW16_A2284CBRubDItem ;
      private int[] P00CW17_A126TASICod ;
      private string[] P00CW17_A129VouNum ;
      private short[] P00CW17_A2077VouSts ;
      private string[] P00CW17_A79COSCod ;
      private bool[] P00CW17_n79COSCod ;
      private string[] P00CW17_A91CueCod ;
      private short[] P00CW17_A128VouMes ;
      private short[] P00CW17_A127VouAno ;
      private short[] P00CW17_A864CueMon ;
      private decimal[] P00CW17_A2056VouDHabO ;
      private decimal[] P00CW17_A2052VouDDebO ;
      private decimal[] P00CW17_A2069VouDTcmb ;
      private decimal[] P00CW17_A2055VouDHab ;
      private decimal[] P00CW17_A2051VouDDeb ;
      private int[] P00CW17_A130VouDSec ;
      private int[] P00CW18_A2282CBLinPre ;
      private string[] P00CW18_A2281CBTipTipo ;
      private int[] P00CW18_A2280CBTipPre ;
      private int[] P00CW18_A2283CBRubPre ;
      private string[] P00CW18_A2293CBRubPreDsc ;
      private decimal[] P00CW19_A2296CBRubPreEne ;
      private decimal[] P00CW19_A2297CBRubPreFeb ;
      private decimal[] P00CW19_A2298CBRubPreMar ;
      private decimal[] P00CW19_A2299CBRubPreAbr ;
      private decimal[] P00CW19_A2300CBRubPreMay ;
      private decimal[] P00CW19_A2301CBRubPreJun ;
      private decimal[] P00CW19_A2302CBRubPreJul ;
      private decimal[] P00CW19_A2303CBRubPreAgo ;
      private decimal[] P00CW19_A2304CBRubPreSep ;
      private decimal[] P00CW19_A2305CBRubPreOct ;
      private decimal[] P00CW19_A2306CBRubPreNov ;
      private decimal[] P00CW19_A2307CBRubPreDic ;
      private int[] P00CW20_A2283CBRubPre ;
      private int[] P00CW20_A2282CBLinPre ;
      private string[] P00CW20_A2281CBTipTipo ;
      private int[] P00CW20_A2280CBTipPre ;
      private string[] P00CW20_A91CueCod ;
      private string[] P00CW20_A79COSCod ;
      private bool[] P00CW20_n79COSCod ;
      private int[] P00CW20_A2284CBRubDItem ;
      private int[] P00CW21_A2283CBRubPre ;
      private int[] P00CW21_A2282CBLinPre ;
      private string[] P00CW21_A2281CBTipTipo ;
      private int[] P00CW21_A2280CBTipPre ;
      private string[] P00CW21_A91CueCod ;
      private string[] P00CW21_A79COSCod ;
      private bool[] P00CW21_n79COSCod ;
      private int[] P00CW21_A2284CBRubDItem ;
      private int[] P00CW22_A2283CBRubPre ;
      private int[] P00CW22_A2282CBLinPre ;
      private string[] P00CW22_A2281CBTipTipo ;
      private int[] P00CW22_A2280CBTipPre ;
      private string[] P00CW22_A91CueCod ;
      private string[] P00CW22_A79COSCod ;
      private bool[] P00CW22_n79COSCod ;
      private int[] P00CW22_A2284CBRubDItem ;
      private int[] P00CW23_A2283CBRubPre ;
      private int[] P00CW23_A2282CBLinPre ;
      private string[] P00CW23_A2281CBTipTipo ;
      private int[] P00CW23_A2280CBTipPre ;
      private string[] P00CW23_A91CueCod ;
      private string[] P00CW23_A79COSCod ;
      private bool[] P00CW23_n79COSCod ;
      private int[] P00CW23_A2284CBRubDItem ;
      private int[] P00CW24_A2283CBRubPre ;
      private int[] P00CW24_A2282CBLinPre ;
      private string[] P00CW24_A2281CBTipTipo ;
      private int[] P00CW24_A2280CBTipPre ;
      private string[] P00CW24_A91CueCod ;
      private string[] P00CW24_A79COSCod ;
      private bool[] P00CW24_n79COSCod ;
      private int[] P00CW24_A2284CBRubDItem ;
      private int[] P00CW25_A2283CBRubPre ;
      private int[] P00CW25_A2282CBLinPre ;
      private string[] P00CW25_A2281CBTipTipo ;
      private int[] P00CW25_A2280CBTipPre ;
      private string[] P00CW25_A91CueCod ;
      private string[] P00CW25_A79COSCod ;
      private bool[] P00CW25_n79COSCod ;
      private int[] P00CW25_A2284CBRubDItem ;
      private int[] P00CW26_A2283CBRubPre ;
      private int[] P00CW26_A2282CBLinPre ;
      private string[] P00CW26_A2281CBTipTipo ;
      private int[] P00CW26_A2280CBTipPre ;
      private string[] P00CW26_A91CueCod ;
      private string[] P00CW26_A79COSCod ;
      private bool[] P00CW26_n79COSCod ;
      private int[] P00CW26_A2284CBRubDItem ;
      private int[] P00CW27_A2283CBRubPre ;
      private int[] P00CW27_A2282CBLinPre ;
      private string[] P00CW27_A2281CBTipTipo ;
      private int[] P00CW27_A2280CBTipPre ;
      private string[] P00CW27_A91CueCod ;
      private string[] P00CW27_A79COSCod ;
      private bool[] P00CW27_n79COSCod ;
      private int[] P00CW27_A2284CBRubDItem ;
      private int[] P00CW28_A2283CBRubPre ;
      private int[] P00CW28_A2282CBLinPre ;
      private string[] P00CW28_A2281CBTipTipo ;
      private int[] P00CW28_A2280CBTipPre ;
      private string[] P00CW28_A91CueCod ;
      private string[] P00CW28_A79COSCod ;
      private bool[] P00CW28_n79COSCod ;
      private int[] P00CW28_A2284CBRubDItem ;
      private int[] P00CW29_A2283CBRubPre ;
      private int[] P00CW29_A2282CBLinPre ;
      private string[] P00CW29_A2281CBTipTipo ;
      private int[] P00CW29_A2280CBTipPre ;
      private string[] P00CW29_A91CueCod ;
      private string[] P00CW29_A79COSCod ;
      private bool[] P00CW29_n79COSCod ;
      private int[] P00CW29_A2284CBRubDItem ;
      private int[] P00CW30_A2283CBRubPre ;
      private int[] P00CW30_A2282CBLinPre ;
      private string[] P00CW30_A2281CBTipTipo ;
      private int[] P00CW30_A2280CBTipPre ;
      private string[] P00CW30_A91CueCod ;
      private string[] P00CW30_A79COSCod ;
      private bool[] P00CW30_n79COSCod ;
      private int[] P00CW30_A2284CBRubDItem ;
      private int[] P00CW31_A2283CBRubPre ;
      private int[] P00CW31_A2282CBLinPre ;
      private string[] P00CW31_A2281CBTipTipo ;
      private int[] P00CW31_A2280CBTipPre ;
      private string[] P00CW31_A91CueCod ;
      private string[] P00CW31_A79COSCod ;
      private bool[] P00CW31_n79COSCod ;
      private int[] P00CW31_A2284CBRubDItem ;
      private string aP3_Filename ;
      private string aP4_ErrorMessage ;
      private ExcelDocumentI AV60ExcelDocument ;
      private GxFile AV11Archivo ;
   }

   public class r_resumenanualpresupuestoanualexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CW17( IGxContext context ,
                                              string AV17CosCod ,
                                              string A79COSCod ,
                                              short A2077VouSts ,
                                              short AV10Ano ,
                                              short AV78Mes ,
                                              string AV18CueCod ,
                                              short A127VouAno ,
                                              short A128VouMes ,
                                              string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T1.[VouNum], T3.[VouSts], T1.[COSCod], T1.[CueCod], T1.[VouMes], T1.[VouAno], T2.[CueMon], T1.[VouDHabO], T1.[VouDDebO], T1.[VouDTcmb], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV10Ano and T1.[VouMes] = @AV78Mes and T1.[CueCod] = @AV18CueCod)");
         AddWhere(sWhereString, "(T3.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17CosCod)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV17CosCod)");
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
               case 15 :
                     return conditional_P00CW17(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] );
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
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CW2;
          prmP00CW2 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW3;
          prmP00CW3 = new Object[] {
          new ParDef("@AV15CBTipPreDsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0)
          };
          Object[] prmP00CW4;
          prmP00CW4 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV10Ano",GXType.Int16,4,0)
          };
          Object[] prmP00CW5;
          prmP00CW5 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW6;
          prmP00CW6 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW7;
          prmP00CW7 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW8;
          prmP00CW8 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW9;
          prmP00CW9 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW10;
          prmP00CW10 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW11;
          prmP00CW11 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW12;
          prmP00CW12 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW13;
          prmP00CW13 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW14;
          prmP00CW14 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW15;
          prmP00CW15 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW16;
          prmP00CW16 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW18;
          prmP00CW18 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW19;
          prmP00CW19 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV12CBRubPre",GXType.Int32,6,0) ,
          new ParDef("@AV10Ano",GXType.Int16,4,0)
          };
          Object[] prmP00CW20;
          prmP00CW20 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV12CBRubPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW21;
          prmP00CW21 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV12CBRubPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW22;
          prmP00CW22 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV12CBRubPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW23;
          prmP00CW23 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV12CBRubPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW24;
          prmP00CW24 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV12CBRubPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW25;
          prmP00CW25 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV12CBRubPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW26;
          prmP00CW26 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV12CBRubPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW27;
          prmP00CW27 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV12CBRubPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW28;
          prmP00CW28 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV12CBRubPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW29;
          prmP00CW29 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV12CBRubPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW30;
          prmP00CW30 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV12CBRubPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW31;
          prmP00CW31 = new Object[] {
          new ParDef("@AV14CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV111Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV8CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV12CBRubPre",GXType.Int32,6,0)
          };
          Object[] prmP00CW17;
          prmP00CW17 = new Object[] {
          new ParDef("@AV10Ano",GXType.Int16,4,0) ,
          new ParDef("@AV78Mes",GXType.Int16,2,0) ,
          new ParDef("@AV18CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV17CosCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CW2", "SELECT [CBTipPre], [CBTipPreDsc], [MonCod] FROM [CBPRESUPUESTOTIPO] WHERE [CBTipPre] = @AV14CBTipPre ORDER BY [CBTipPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00CW3", "SELECT T1.[CBTipPre], T1.[CBTipTipo], T2.[CBTipPreDsc], T1.[CBLinPre], T1.[CBLinPreDsc] FROM ([CBPRESUPUESTOLINEA] T1 INNER JOIN [CBPRESUPUESTOTIPO] T2 ON T2.[CBTipPre] = T1.[CBTipPre]) WHERE (T2.[CBTipPreDsc] = @AV15CBTipPreDsc) AND (T1.[CBTipTipo] = @AV111Tip) ORDER BY T1.[CBTipPre], T1.[CBTipTipo], T1.[CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW4", "SELECT SUM([CBRubPreEne]), SUM([CBRubPreFeb]), SUM([CBRubPreMar]), SUM([CBRubPreAbr]), SUM([CBRubPreMay]), SUM([CBRubPreJun]), SUM([CBRubPreJul]), SUM([CBRubPreAgo]), SUM([CBRubPreSep]), SUM([CBRubPreOct]), SUM([CBRubPreNov]), SUM([CBRubPreDic]) FROM [CBPRESUPUESTORUBROSDET] WHERE ([CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre) AND ([CBRubPreAno] = @AV10Ano) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW5", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW6", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW7", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW8", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW9", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW10", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW11", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW12", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW13", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW14", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW15", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW16", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW16,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW17", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW17,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CW18", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CBRubPre], [CBRubPreDsc] FROM [CBPRESUPUESTORUBROS] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW18,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW19", "SELECT SUM([CBRubPreEne]), SUM([CBRubPreFeb]), SUM([CBRubPreMar]), SUM([CBRubPreAbr]), SUM([CBRubPreMay]), SUM([CBRubPreJun]), SUM([CBRubPreJul]), SUM([CBRubPreAgo]), SUM([CBRubPreSep]), SUM([CBRubPreOct]), SUM([CBRubPreNov]), SUM([CBRubPreDic]) FROM [CBPRESUPUESTORUBROSDET] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre and [CBRubPre] = @AV12CBRubPre and [CBRubPreAno] = @AV10Ano ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW20", "SELECT [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre and [CBRubPre] = @AV12CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW20,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW21", "SELECT [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre and [CBRubPre] = @AV12CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW21,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW22", "SELECT [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre and [CBRubPre] = @AV12CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW22,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW23", "SELECT [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre and [CBRubPre] = @AV12CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW23,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW24", "SELECT [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre and [CBRubPre] = @AV12CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW24,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW25", "SELECT [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre and [CBRubPre] = @AV12CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW25,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW26", "SELECT [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre and [CBRubPre] = @AV12CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW26,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW27", "SELECT [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre and [CBRubPre] = @AV12CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW27,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW28", "SELECT [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre and [CBRubPre] = @AV12CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW28,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW29", "SELECT [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre and [CBRubPre] = @AV12CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW29,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW30", "SELECT [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre and [CBRubPre] = @AV12CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW30,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CW31", "SELECT [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV14CBTipPre and [CBTipTipo] = @AV111Tip and [CBLinPre] = @AV8CBLinPre and [CBRubPre] = @AV12CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CW31,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 15 :
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
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 17 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 25 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 26 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 27 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 29 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
