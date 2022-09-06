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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.contabilidad {
   public class r_libroinventariobalancepdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_libroinventariobalancepdf.aspx")), "contabilidad.r_libroinventariobalancepdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_libroinventariobalancepdf.aspx")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Ano");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV11Ano = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
                  AV63nDig = (short)(NumberUtil.Val( GetPar( "nDig"), "."));
                  AV64CDetalles = (short)(NumberUtil.Val( GetPar( "CDetalles"), "."));
               }
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public r_libroinventariobalancepdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_libroinventariobalancepdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref short aP2_nDig ,
                           ref short aP3_CDetalles )
      {
         this.AV11Ano = aP0_Ano;
         this.AV12Mes = aP1_Mes;
         this.AV63nDig = aP2_nDig;
         this.AV64CDetalles = aP3_CDetalles;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_nDig=this.AV63nDig;
         aP3_CDetalles=this.AV64CDetalles;
      }

      public short executeUdp( ref short aP0_Ano ,
                               ref short aP1_Mes ,
                               ref short aP2_nDig )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_nDig, ref aP3_CDetalles);
         return AV64CDetalles ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref short aP2_nDig ,
                                 ref short aP3_CDetalles )
      {
         r_libroinventariobalancepdf objr_libroinventariobalancepdf;
         objr_libroinventariobalancepdf = new r_libroinventariobalancepdf();
         objr_libroinventariobalancepdf.AV11Ano = aP0_Ano;
         objr_libroinventariobalancepdf.AV12Mes = aP1_Mes;
         objr_libroinventariobalancepdf.AV63nDig = aP2_nDig;
         objr_libroinventariobalancepdf.AV64CDetalles = aP3_CDetalles;
         objr_libroinventariobalancepdf.context.SetSubmitInitialConfig(context);
         objr_libroinventariobalancepdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_libroinventariobalancepdf);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_nDig=this.AV63nDig;
         aP3_CDetalles=this.AV64CDetalles;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_libroinventariobalancepdf)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 9, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV27Empresa = AV30Session.Get("Empresa");
            AV28EmpDir = AV30Session.Get("EmpDir");
            AV68EmpRUC = AV30Session.Get("EmpRUC");
            AV69Ruta = AV30Session.Get("RUTA") + "/Logo.jpg";
            AV70Logo = AV69Ruta;
            AV79Logo_GXI = GXDbFile.PathToUrl( AV69Ruta);
            AV59FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            if ( AV12Mes == 0 )
            {
               AV59FechaC = "01/01/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            }
            AV16FechaD = context.localUtil.CToD( AV59FechaC, 2);
            GXt_date1 = AV15Fecha;
            new GeneXus.Programs.generales.pobtieneultimodiames(context ).execute(  AV16FechaD, out  GXt_date1) ;
            AV15Fecha = GXt_date1;
            if ( AV12Mes == 0 )
            {
               AV16FechaD = context.localUtil.CToD( AV59FechaC, 2);
            }
            else
            {
               AV16FechaD = AV15Fecha;
            }
            /* Using cursor P00B42 */
            pr_default.execute(0, new Object[] {AV11Ano, AV12Mes});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A126TASICod = P00B42_A126TASICod[0];
               A2077VouSts = P00B42_A2077VouSts[0];
               A128VouMes = P00B42_A128VouMes[0];
               A127VouAno = P00B42_A127VouAno[0];
               A2074VouFec = P00B42_A2074VouFec[0];
               A129VouNum = P00B42_A129VouNum[0];
               AV16FechaD = A2074VouFec;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV13Titulo = "Libro de Inventarios y Balances";
            AV14Periodo = "Al : " + context.localUtil.DToC( AV16FechaD, 2, "/");
            AV65TTDebeAcumula = 0.00m;
            AV66TTHaberAcumula = 0.00m;
            AV47TDebeMO = 0.00m;
            AV48ThaberMO = 0.00m;
            AV72i = 1;
            AV74TotalPYP = 0.00m;
            while ( AV72i <= 3 )
            {
               if ( AV72i == 1 )
               {
                  AV71Titulo3 = "ACTIVO";
               }
               if ( AV72i == 2 )
               {
                  AV74TotalPYP = 0.00m;
                  AV71Titulo3 = "PASIVO";
               }
               if ( AV72i == 3 )
               {
                  AV71Titulo3 = "PATRIMONIO";
               }
               HB40( false, 50) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71Titulo3, "")), 48, Gx_line+11, 778, Gx_line+29, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+50);
               AV73TotalTitulo = 0.00m;
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV72i ,
                                                    A91CueCod ,
                                                    AV63nDig } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.SHORT
                                                    }
               });
               /* Using cursor P00B43 */
               pr_default.execute(1, new Object[] {AV63nDig});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A91CueCod = P00B43_A91CueCod[0];
                  A860CueDsc = P00B43_A860CueDsc[0];
                  AV61Cuenta = StringUtil.Trim( A91CueCod);
                  AV41CueDsc = A860CueDsc;
                  AV65TTDebeAcumula = 0.00m;
                  AV66TTHaberAcumula = 0.00m;
                  /* Execute user subroutine: 'VALIDAMOVIMIENTOS' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     this.cleanup();
                     if (true) return;
                  }
                  AV73TotalTitulo = (decimal)(AV73TotalTitulo+AV54Saldo);
                  if ( ( AV54Saldo != Convert.ToDecimal( 0 )) )
                  {
                     HB40( false, 22) ;
                     getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61Cuenta, "")), 48, Gx_line+1, 157, Gx_line+18, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41CueDsc, "")), 149, Gx_line+2, 593, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 602, Gx_line+2, 745, Gx_line+20, 2+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+22);
                  }
                  if ( AV64CDetalles == 1 )
                  {
                     /* Execute user subroutine: 'MOVIMIENTOS' */
                     S121 ();
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
               AV74TotalPYP = (decimal)(AV74TotalPYP+AV73TotalTitulo);
               AV71Titulo3 = "TOTAL " + StringUtil.Trim( AV71Titulo3);
               HB40( false, 53) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV73TotalTitulo, "ZZZZZZ,ZZZ,ZZ9.99")), 602, Gx_line+15, 745, Gx_line+33, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71Titulo3, "")), 82, Gx_line+15, 587, Gx_line+32, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+53);
               AV72i = (int)(AV72i+1);
            }
            AV75Titulo4 = "TOTAL PASIVO Y PATRIMONIO";
            HB40( false, 42) ;
            getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75Titulo4, "")), 82, Gx_line+15, 587, Gx_line+32, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV74TotalPYP, "ZZZZZZ,ZZZ,ZZ9.99")), 602, Gx_line+15, 745, Gx_line+33, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+42);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HB40( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'VALIDAMOVIMIENTOS' Routine */
         returnInSub = false;
         AV54Saldo = 0.00m;
         /* Using cursor P00B44 */
         pr_default.execute(2, new Object[] {AV63nDig, AV61Cuenta});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A867CueMov = P00B44_A867CueMov[0];
            A91CueCod = P00B44_A91CueCod[0];
            AV25CueCod = A91CueCod;
            GXt_char2 = "";
            GXt_char3 = "";
            new GeneXus.Programs.contabilidad.poptienesaldocuentamesactual(context ).execute( ref  AV11Ano, ref  AV12Mes, ref  AV25CueCod, ref  GXt_char2, ref  GXt_char3, out  AV52SaldoDMN, out  AV55SaldoHMN) ;
            AV65TTDebeAcumula = (decimal)(AV65TTDebeAcumula+AV52SaldoDMN);
            AV66TTHaberAcumula = (decimal)(AV66TTHaberAcumula+AV55SaldoHMN);
            AV54Saldo = (decimal)(AV65TTDebeAcumula-AV66TTHaberAcumula);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( StringUtil.StrCmp(StringUtil.Substring( AV25CueCod, 1, 2), "40") >= 0 )
         {
            AV54Saldo = (decimal)(AV54Saldo*(-1));
         }
      }

      protected void S121( )
      {
         /* 'MOVIMIENTOS' Routine */
         returnInSub = false;
         /* Using cursor P00B45 */
         pr_default.execute(3, new Object[] {AV63nDig, AV61Cuenta});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A91CueCod = P00B45_A91CueCod[0];
            A859CueCos = P00B45_A859CueCos[0];
            A70TipACod = P00B45_A70TipACod[0];
            n70TipACod = P00B45_n70TipACod[0];
            A860CueDsc = P00B45_A860CueDsc[0];
            AV76TipACod = A70TipACod;
            AV25CueCod = A91CueCod;
            AV41CueDsc = A860CueDsc;
            GXt_char3 = "";
            GXt_char2 = "";
            new GeneXus.Programs.contabilidad.poptienesaldocuentamesactual(context ).execute( ref  AV11Ano, ref  AV12Mes, ref  AV25CueCod, ref  GXt_char3, ref  GXt_char2, out  AV52SaldoDMN, out  AV55SaldoHMN) ;
            AV54Saldo = (decimal)(AV52SaldoDMN-AV55SaldoHMN);
            if ( StringUtil.StrCmp(StringUtil.Substring( AV25CueCod, 1, 2), "40") >= 0 )
            {
               AV54Saldo = (decimal)(AV54Saldo*-1);
            }
            if ( ( AV54Saldo > Convert.ToDecimal( 0 )) )
            {
               AV52SaldoDMN = AV54Saldo;
               AV55SaldoHMN = 0.00m;
            }
            else
            {
               AV52SaldoDMN = 0.00m;
               AV55SaldoHMN = (decimal)(AV54Saldo*(-1));
            }
            if ( ( AV54Saldo != Convert.ToDecimal( 0 )) )
            {
               HB40( false, 20) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 48, Gx_line+3, 143, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41CueDsc, "")), 149, Gx_line+3, 483, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 620, Gx_line+3, 745, Gx_line+18, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
            AV47TDebeMO = (decimal)(AV47TDebeMO+AV52SaldoDMN);
            AV48ThaberMO = (decimal)(AV48ThaberMO+AV55SaldoHMN);
            /* Execute user subroutine: 'DETALLES' */
            S136 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S136( )
      {
         /* 'DETALLES' Routine */
         returnInSub = false;
         /* Using cursor P00B46 */
         pr_default.execute(4, new Object[] {AV11Ano, AV25CueCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKB47 = false;
            A134CueAuxCod = P00B46_A134CueAuxCod[0];
            A133CueCodAux = P00B46_A133CueCodAux[0];
            A91CueCod = P00B46_A91CueCod[0];
            A127VouAno = P00B46_A127VouAno[0];
            A128VouMes = P00B46_A128VouMes[0];
            A126TASICod = P00B46_A126TASICod[0];
            A129VouNum = P00B46_A129VouNum[0];
            A130VouDSec = P00B46_A130VouDSec[0];
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00B46_A133CueCodAux[0], A133CueCodAux) == 0 ) )
            {
               BRKB47 = false;
               A134CueAuxCod = P00B46_A134CueAuxCod[0];
               A127VouAno = P00B46_A127VouAno[0];
               A128VouMes = P00B46_A128VouMes[0];
               A126TASICod = P00B46_A126TASICod[0];
               A129VouNum = P00B46_A129VouNum[0];
               A130VouDSec = P00B46_A130VouDSec[0];
               BRKB47 = true;
               pr_default.readNext(4);
            }
            AV51CueDAxu = A133CueCodAux;
            /* Execute user subroutine: 'NOMBREAUXILIAR' */
            S147 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            GXt_char3 = "";
            new GeneXus.Programs.contabilidad.poptienesaldocuentamesactual(context ).execute( ref  AV11Ano, ref  AV12Mes, ref  AV25CueCod, ref  AV51CueDAxu, ref  GXt_char3, out  AV52SaldoDMN, out  AV55SaldoHMN) ;
            AV54Saldo = (decimal)(AV52SaldoDMN-AV55SaldoHMN);
            if ( StringUtil.StrCmp(StringUtil.Substring( AV25CueCod, 1, 1), "4") >= 0 )
            {
               AV54Saldo = (decimal)(AV54Saldo*-1);
            }
            if ( ( AV54Saldo != Convert.ToDecimal( 0 )) )
            {
               HB40( false, 18) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 457, Gx_line+2, 564, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51CueDAxu, "")), 72, Gx_line+2, 177, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56CueDAxuDsc, "")), 173, Gx_line+2, 507, Gx_line+16, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
            }
            if ( ! BRKB47 )
            {
               BRKB47 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S147( )
      {
         /* 'NOMBREAUXILIAR' Routine */
         returnInSub = false;
         AV87GXLvl200 = 0;
         /* Using cursor P00B47 */
         pr_default.execute(5, new Object[] {AV76TipACod, AV51CueDAxu});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A71TipADCod = P00B47_A71TipADCod[0];
            A70TipACod = P00B47_A70TipACod[0];
            n70TipACod = P00B47_n70TipACod[0];
            A72TipADDsc = P00B47_A72TipADDsc[0];
            AV87GXLvl200 = 1;
            AV56CueDAxuDsc = A72TipADDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
         if ( AV87GXLvl200 == 0 )
         {
            AV56CueDAxuDsc = "SIN AUXILIAR";
         }
      }

      protected void HB40( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 200, Gx_line+18, 656, Gx_line+52, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 200, Gx_line+50, 656, Gx_line+84, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 24, Gx_line+85, 392, Gx_line+103, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68EmpRUC, "")), 24, Gx_line+102, 395, Gx_line+120, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV70Logo)) ? AV79Logo_GXI : AV70Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 24, Gx_line+8, 182, Gx_line+86) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 696, Gx_line+23, 740, Gx_line+37, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 746, Gx_line+23, 785, Gx_line+38, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+125);
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción", 236, Gx_line+11, 305, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo Auxiliar", 458, Gx_line+11, 539, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(128, Gx_line+1, 128, Gx_line+36, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(434, Gx_line+0, 434, Gx_line+35, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(573, Gx_line+0, 573, Gx_line+35, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Cuenta", 50, Gx_line+11, 93, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+0, 815, Gx_line+36, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo Actual", 650, Gx_line+13, 724, Gx_line+27, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+35);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
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
         GXKey = "";
         GXDecQS = "";
         gxfirstwebparm = "";
         AV27Empresa = "";
         AV30Session = context.GetSession();
         AV28EmpDir = "";
         AV68EmpRUC = "";
         AV69Ruta = "";
         AV70Logo = "";
         AV79Logo_GXI = "";
         AV59FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV15Fecha = DateTime.MinValue;
         GXt_date1 = DateTime.MinValue;
         scmdbuf = "";
         P00B42_A126TASICod = new int[1] ;
         P00B42_A2077VouSts = new short[1] ;
         P00B42_A128VouMes = new short[1] ;
         P00B42_A127VouAno = new short[1] ;
         P00B42_A2074VouFec = new DateTime[] {DateTime.MinValue} ;
         P00B42_A129VouNum = new string[] {""} ;
         A2074VouFec = DateTime.MinValue;
         A129VouNum = "";
         AV13Titulo = "";
         AV14Periodo = "";
         AV71Titulo3 = "";
         A91CueCod = "";
         P00B43_A91CueCod = new string[] {""} ;
         P00B43_A860CueDsc = new string[] {""} ;
         A860CueDsc = "";
         AV61Cuenta = "";
         AV41CueDsc = "";
         AV75Titulo4 = "";
         P00B44_A867CueMov = new short[1] ;
         P00B44_A91CueCod = new string[] {""} ;
         AV25CueCod = "";
         P00B45_A91CueCod = new string[] {""} ;
         P00B45_A859CueCos = new short[1] ;
         P00B45_A70TipACod = new int[1] ;
         P00B45_n70TipACod = new bool[] {false} ;
         P00B45_A860CueDsc = new string[] {""} ;
         GXt_char2 = "";
         P00B46_A134CueAuxCod = new string[] {""} ;
         P00B46_A133CueCodAux = new string[] {""} ;
         P00B46_A91CueCod = new string[] {""} ;
         P00B46_A127VouAno = new short[1] ;
         P00B46_A128VouMes = new short[1] ;
         P00B46_A126TASICod = new int[1] ;
         P00B46_A129VouNum = new string[] {""} ;
         P00B46_A130VouDSec = new int[1] ;
         A134CueAuxCod = "";
         A133CueCodAux = "";
         AV51CueDAxu = "";
         GXt_char3 = "";
         AV56CueDAxuDsc = "";
         P00B47_A71TipADCod = new string[] {""} ;
         P00B47_A70TipACod = new int[1] ;
         P00B47_n70TipACod = new bool[] {false} ;
         P00B47_A72TipADDsc = new string[] {""} ;
         A71TipADCod = "";
         A72TipADDsc = "";
         AV70Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_libroinventariobalancepdf__default(),
            new Object[][] {
                new Object[] {
               P00B42_A126TASICod, P00B42_A2077VouSts, P00B42_A128VouMes, P00B42_A127VouAno, P00B42_A2074VouFec, P00B42_A129VouNum
               }
               , new Object[] {
               P00B43_A91CueCod, P00B43_A860CueDsc
               }
               , new Object[] {
               P00B44_A867CueMov, P00B44_A91CueCod
               }
               , new Object[] {
               P00B45_A91CueCod, P00B45_A859CueCos, P00B45_A70TipACod, P00B45_n70TipACod, P00B45_A860CueDsc
               }
               , new Object[] {
               P00B46_A134CueAuxCod, P00B46_A133CueCodAux, P00B46_A91CueCod, P00B46_A127VouAno, P00B46_A128VouMes, P00B46_A126TASICod, P00B46_A129VouNum, P00B46_A130VouDSec
               }
               , new Object[] {
               P00B47_A71TipADCod, P00B47_A70TipACod, P00B47_A72TipADDsc
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV11Ano ;
      private short AV12Mes ;
      private short AV63nDig ;
      private short AV64CDetalles ;
      private short A2077VouSts ;
      private short A128VouMes ;
      private short A127VouAno ;
      private short A867CueMov ;
      private short A859CueCos ;
      private short AV87GXLvl200 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A126TASICod ;
      private int AV72i ;
      private int Gx_OldLine ;
      private int A70TipACod ;
      private int AV76TipACod ;
      private int A130VouDSec ;
      private decimal AV65TTDebeAcumula ;
      private decimal AV66TTHaberAcumula ;
      private decimal AV47TDebeMO ;
      private decimal AV48ThaberMO ;
      private decimal AV74TotalPYP ;
      private decimal AV73TotalTitulo ;
      private decimal AV54Saldo ;
      private decimal AV52SaldoDMN ;
      private decimal AV55SaldoHMN ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV27Empresa ;
      private string AV28EmpDir ;
      private string AV68EmpRUC ;
      private string AV69Ruta ;
      private string AV59FechaC ;
      private string scmdbuf ;
      private string A129VouNum ;
      private string AV13Titulo ;
      private string AV14Periodo ;
      private string AV71Titulo3 ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string AV61Cuenta ;
      private string AV41CueDsc ;
      private string AV75Titulo4 ;
      private string AV25CueCod ;
      private string GXt_char2 ;
      private string A134CueAuxCod ;
      private string A133CueCodAux ;
      private string AV51CueDAxu ;
      private string GXt_char3 ;
      private string AV56CueDAxuDsc ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private string sImgUrl ;
      private DateTime AV16FechaD ;
      private DateTime AV15Fecha ;
      private DateTime GXt_date1 ;
      private DateTime A2074VouFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool n70TipACod ;
      private bool BRKB47 ;
      private string AV79Logo_GXI ;
      private string AV70Logo ;
      private string Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private short aP2_nDig ;
      private short aP3_CDetalles ;
      private IDataStoreProvider pr_default ;
      private int[] P00B42_A126TASICod ;
      private short[] P00B42_A2077VouSts ;
      private short[] P00B42_A128VouMes ;
      private short[] P00B42_A127VouAno ;
      private DateTime[] P00B42_A2074VouFec ;
      private string[] P00B42_A129VouNum ;
      private string[] P00B43_A91CueCod ;
      private string[] P00B43_A860CueDsc ;
      private short[] P00B44_A867CueMov ;
      private string[] P00B44_A91CueCod ;
      private string[] P00B45_A91CueCod ;
      private short[] P00B45_A859CueCos ;
      private int[] P00B45_A70TipACod ;
      private bool[] P00B45_n70TipACod ;
      private string[] P00B45_A860CueDsc ;
      private string[] P00B46_A134CueAuxCod ;
      private string[] P00B46_A133CueCodAux ;
      private string[] P00B46_A91CueCod ;
      private short[] P00B46_A127VouAno ;
      private short[] P00B46_A128VouMes ;
      private int[] P00B46_A126TASICod ;
      private string[] P00B46_A129VouNum ;
      private int[] P00B46_A130VouDSec ;
      private string[] P00B47_A71TipADCod ;
      private int[] P00B47_A70TipACod ;
      private bool[] P00B47_n70TipACod ;
      private string[] P00B47_A72TipADDsc ;
   }

   public class r_libroinventariobalancepdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B43( IGxContext context ,
                                             int AV72i ,
                                             string A91CueCod ,
                                             short AV63nDig )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[1];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [CueCod], [CueDsc] FROM [CBPLANCUENTA]";
         AddWhere(sWhereString, "(LEN([CueCod]) = @AV63nDig)");
         if ( AV72i == 1 )
         {
            AddWhere(sWhereString, "(SUBSTRING([CueCod], 1, 2) >= '10' and SUBSTRING([CueCod], 1, 2) <= '39')");
         }
         if ( AV72i == 2 )
         {
            AddWhere(sWhereString, "(SUBSTRING([CueCod], 1, 2) >= '40' and SUBSTRING([CueCod], 1, 2) <= '49')");
         }
         if ( AV72i == 3 )
         {
            AddWhere(sWhereString, "(SUBSTRING([CueCod], 1, 2) >= '50' and SUBSTRING([CueCod], 1, 2) <= '59')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueCod]";
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
               case 1 :
                     return conditional_P00B43(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00B42;
          prmP00B42 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0)
          };
          Object[] prmP00B44;
          prmP00B44 = new Object[] {
          new ParDef("@AV63nDig",GXType.Int16,2,0) ,
          new ParDef("@AV61Cuenta",GXType.Char,15,0)
          };
          Object[] prmP00B45;
          prmP00B45 = new Object[] {
          new ParDef("@AV63nDig",GXType.Int16,2,0) ,
          new ParDef("@AV61Cuenta",GXType.Char,15,0)
          };
          Object[] prmP00B46;
          prmP00B46 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0)
          };
          Object[] prmP00B47;
          prmP00B47 = new Object[] {
          new ParDef("@AV76TipACod",GXType.Int32,6,0) ,
          new ParDef("@AV51CueDAxu",GXType.NChar,20,0)
          };
          Object[] prmP00B43;
          prmP00B43 = new Object[] {
          new ParDef("@AV63nDig",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B42", "SELECT TOP 1 [TASICod], [VouSts], [VouMes], [VouAno], [VouFec], [VouNum] FROM [CBVOUCHER] WHERE ([VouAno] = @AV11Ano and [VouMes] = @AV12Mes and [TASICod] = 1) AND ([VouSts] = 1) ORDER BY [VouAno], [VouMes], [TASICod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B42,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00B43", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B43,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B44", "SELECT [CueMov], [CueCod] FROM [CBPLANCUENTA] WHERE (SUBSTRING(RTRIM(LTRIM([CueCod])), 1, @AV63nDig) = RTRIM(LTRIM(@AV61Cuenta))) AND ([CueMov] = 1) ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B44,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B45", "SELECT [CueCod], [CueCos], [TipACod], [CueDsc] FROM [CBPLANCUENTA] WHERE SUBSTRING([CueCod], 1, @AV63nDig) = @AV61Cuenta ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B45,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B46", "SELECT [CueAuxCod], [CueCodAux], [CueCod], [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE ([VouAno] = @AV11Ano) AND ([CueCod] = @AV25CueCod) ORDER BY [CueCodAux], [CueAuxCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B46,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B47", "SELECT [TipADCod], [TipACod], [TipADDsc] FROM [CBAUXILIARES] WHERE [TipACod] = @AV76TipACod and [TipADCod] = @AV51CueDAxu ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B47,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
