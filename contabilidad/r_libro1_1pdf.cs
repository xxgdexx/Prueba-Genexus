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
   public class r_libro1_1pdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_libro1_1pdf.aspx")), "contabilidad.r_libro1_1pdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_libro1_1pdf.aspx")))) ;
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

      public r_libro1_1pdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_libro1_1pdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes )
      {
         this.AV11Ano = aP0_Ano;
         this.AV12Mes = aP1_Mes;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
      }

      public short executeUdp( ref short aP0_Ano )
      {
         execute(ref aP0_Ano, ref aP1_Mes);
         return AV12Mes ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes )
      {
         r_libro1_1pdf objr_libro1_1pdf;
         objr_libro1_1pdf = new r_libro1_1pdf();
         objr_libro1_1pdf.AV11Ano = aP0_Ano;
         objr_libro1_1pdf.AV12Mes = aP1_Mes;
         objr_libro1_1pdf.context.SetSubmitInitialConfig(context);
         objr_libro1_1pdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_libro1_1pdf);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_libro1_1pdf)stateInfo).executePrivate();
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
         M_bot = 2;
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 2, 9, 11909, 16834, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*2));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV27Empresa = StringUtil.Trim( AV30Session.Get("Empresa"));
            AV28EmpDir = AV30Session.Get("EmpDir");
            AV58EmpRUC = AV30Session.Get("EmpRUC");
            AV59Ruta = AV30Session.Get("RUTA") + "/Logo.jpg";
            AV60Logo = AV59Ruta;
            AV74Logo_GXI = GXDbFile.PathToUrl( AV59Ruta);
            GXt_char1 = AV56cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
            AV56cMes = GXt_char1;
            AV51MesAnt = (short)(AV12Mes-1);
            AV13Titulo = "FORMATO 1.1: LIBRO CAJA Y BANCOS - DETALLE DE LOS MOVIMIENTOS DEL EFECTIVO";
            AV14Periodo = StringUtil.Upper( AV56cMes) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            /* Using cursor P00C32 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A867CueMov = P00C32_A867CueMov[0];
               A91CueCod = P00C32_A91CueCod[0];
               A860CueDsc = P00C32_A860CueDsc[0];
               AV34cCuenta1 = A91CueCod;
               AV41CueDsc = A860CueDsc;
               AV70TitCuenta = "Cuenta : " + StringUtil.Trim( AV34cCuenta1) + " - " + StringUtil.Trim( AV41CueDsc);
               AV71TitCuenta2 = "Total Saldo Cuenta : " + StringUtil.Trim( AV34cCuenta1);
               AV22TDebe = 0.00m;
               AV23THaber = 0.00m;
               /* Execute user subroutine: 'MOVIMIENTOS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HC30( true, 0) ;
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
         /* 'MOVIMIENTOS' Routine */
         returnInSub = false;
         new GeneXus.Programs.contabilidad.psaldocuentames(context ).execute(  AV34cCuenta1,  AV11Ano,  AV51MesAnt, out  AV49SaldoDebe, out  AV50SaldoHaber, out  AV52Saldo) ;
         /* Execute user subroutine: 'VALIDAMOVIMIENTO' */
         S121 ();
         if (returnInSub) return;
         AV49SaldoDebe = ((AV52Saldo>Convert.ToDecimal(0)) ? AV52Saldo : (decimal)(0));
         AV50SaldoHaber = ((AV52Saldo<Convert.ToDecimal(0)) ? AV52Saldo*-1 : (decimal)(0));
         if ( ( AV55Flag == 1 ) || ! (Convert.ToDecimal(0)==AV52Saldo) )
         {
            HC30( false, 20) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70TitCuenta, "")), 20, Gx_line+2, 661, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Saldo Anterior Cuenta", 808, Gx_line+2, 898, Gx_line+12, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49SaldoDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 965, Gx_line+2, 1037, Gx_line+13, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50SaldoHaber, "ZZZZZZ,ZZZ,ZZ9.99")), 1053, Gx_line+2, 1125, Gx_line+13, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            /* Using cursor P00C33 */
            pr_default.execute(1, new Object[] {AV11Ano, AV12Mes, AV34cCuenta1});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A126TASICod = P00C33_A126TASICod[0];
               A129VouNum = P00C33_A129VouNum[0];
               A127VouAno = P00C33_A127VouAno[0];
               A128VouMes = P00C33_A128VouMes[0];
               A91CueCod = P00C33_A91CueCod[0];
               A2077VouSts = P00C33_A2077VouSts[0];
               A2075VouGls = P00C33_A2075VouGls[0];
               A2054VouDGls = P00C33_A2054VouDGls[0];
               A2055VouDHab = P00C33_A2055VouDHab[0];
               A2051VouDDeb = P00C33_A2051VouDDeb[0];
               A860CueDsc = P00C33_A860CueDsc[0];
               A136VouReg = P00C33_A136VouReg[0];
               A135VouDFec = P00C33_A135VouDFec[0];
               A130VouDSec = P00C33_A130VouDSec[0];
               A2077VouSts = P00C33_A2077VouSts[0];
               A2075VouGls = P00C33_A2075VouGls[0];
               A860CueDsc = P00C33_A860CueDsc[0];
               AV54Glosa = A2075VouGls;
               AV25CueCod = A91CueCod;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
               {
                  AV54Glosa = A2054VouDGls;
               }
               HC30( false, 18) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136VouReg, "")), 20, Gx_line+2, 84, Gx_line+13, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A135VouDFec, "99/99/99"), 136, Gx_line+2, 168, Gx_line+13, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2054VouDGls, "")), 202, Gx_line+2, 563, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), 576, Gx_line+2, 640, Gx_line+13, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A860CueDsc, "")), 655, Gx_line+2, 947, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2051VouDDeb, "ZZZ,ZZZ,ZZ9.99")), 972, Gx_line+2, 1036, Gx_line+13, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2055VouDHab, "ZZZ,ZZZ,ZZ9.99")), 1061, Gx_line+2, 1125, Gx_line+13, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               AV22TDebe = (decimal)(AV22TDebe+A2051VouDDeb);
               AV23THaber = (decimal)(AV23THaber+A2055VouDHab);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV52Saldo = (decimal)((AV49SaldoDebe+AV22TDebe)-(AV50SaldoHaber+AV23THaber));
            HC30( false, 65) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV22TDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 965, Gx_line+20, 1037, Gx_line+31, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23THaber, "ZZZZZZ,ZZZ,ZZ9.99")), 1053, Gx_line+20, 1125, Gx_line+31, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(965, Gx_line+12, 1136, Gx_line+12, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Movimientos del Mes", 860, Gx_line+20, 947, Gx_line+30, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 965, Gx_line+38, 1037, Gx_line+49, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71TitCuenta2, "")), 529, Gx_line+38, 947, Gx_line+49, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+65);
            /* Eject command */
            Gx_OldLine = Gx_line;
            Gx_line = (int)(P_lines+1);
         }
      }

      protected void S121( )
      {
         /* 'VALIDAMOVIMIENTO' Routine */
         returnInSub = false;
         AV55Flag = 0;
         /* Using cursor P00C34 */
         pr_default.execute(2, new Object[] {AV11Ano, AV12Mes, AV34cCuenta1});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00C34_A126TASICod[0];
            A129VouNum = P00C34_A129VouNum[0];
            A2077VouSts = P00C34_A2077VouSts[0];
            A91CueCod = P00C34_A91CueCod[0];
            A128VouMes = P00C34_A128VouMes[0];
            A127VouAno = P00C34_A127VouAno[0];
            A130VouDSec = P00C34_A130VouDSec[0];
            A2077VouSts = P00C34_A2077VouSts[0];
            AV55Flag = 1;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void HC30( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 19, Gx_line+8, 541, Gx_line+24, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 86, Gx_line+33, 608, Gx_line+48, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 18, Gx_line+70, 540, Gx_line+85, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58EmpRUC, "")), 86, Gx_line+51, 191, Gx_line+66, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 1027, Gx_line+29, 1071, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1077, Gx_line+29, 1116, Gx_line+44, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PERIODO:", 18, Gx_line+33, 74, Gx_line+47, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RUC :", 18, Gx_line+51, 49, Gx_line+65, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+85);
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Código", 591, Gx_line+32, 620, Gx_line+42, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Denominación", 757, Gx_line+32, 817, Gx_line+42, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DESCRIPCIÓN DE LA OPERACIÓN", 306, Gx_line+20, 445, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(121, Gx_line+1, 121, Gx_line+49, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(571, Gx_line+1, 571, Gx_line+50, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("SALDOS Y MOVIMIENTOS", 993, Gx_line+7, 1099, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha de ", 138, Gx_line+11, 179, Gx_line+21, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Deudor", 986, Gx_line+32, 1017, Gx_line+42, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(571, Gx_line+20, 1137, Gx_line+20, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Número Correlativo", 21, Gx_line+11, 102, Gx_line+21, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("del Registro", 35, Gx_line+26, 85, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(195, Gx_line+0, 195, Gx_line+49, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Operación", 136, Gx_line+26, 179, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(958, Gx_line+0, 958, Gx_line+49, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1046, Gx_line+22, 1046, Gx_line+50, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Acreedor", 1067, Gx_line+32, 1104, Gx_line+42, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("CUENTA CONTABLE ASOCIADA", 696, Gx_line+7, 821, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(649, Gx_line+21, 649, Gx_line+49, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+0, 1136, Gx_line+50, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+50);
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
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
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
         AV58EmpRUC = "";
         AV59Ruta = "";
         AV60Logo = "";
         AV74Logo_GXI = "";
         AV56cMes = "";
         GXt_char1 = "";
         AV13Titulo = "";
         AV14Periodo = "";
         scmdbuf = "";
         P00C32_A867CueMov = new short[1] ;
         P00C32_A91CueCod = new string[] {""} ;
         P00C32_A860CueDsc = new string[] {""} ;
         A91CueCod = "";
         A860CueDsc = "";
         AV34cCuenta1 = "";
         AV41CueDsc = "";
         AV70TitCuenta = "";
         AV71TitCuenta2 = "";
         P00C33_A126TASICod = new int[1] ;
         P00C33_A129VouNum = new string[] {""} ;
         P00C33_A127VouAno = new short[1] ;
         P00C33_A128VouMes = new short[1] ;
         P00C33_A91CueCod = new string[] {""} ;
         P00C33_A2077VouSts = new short[1] ;
         P00C33_A2075VouGls = new string[] {""} ;
         P00C33_A2054VouDGls = new string[] {""} ;
         P00C33_A2055VouDHab = new decimal[1] ;
         P00C33_A2051VouDDeb = new decimal[1] ;
         P00C33_A860CueDsc = new string[] {""} ;
         P00C33_A136VouReg = new string[] {""} ;
         P00C33_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00C33_A130VouDSec = new int[1] ;
         A129VouNum = "";
         A2075VouGls = "";
         A2054VouDGls = "";
         A136VouReg = "";
         A135VouDFec = DateTime.MinValue;
         AV54Glosa = "";
         AV25CueCod = "";
         P00C34_A126TASICod = new int[1] ;
         P00C34_A129VouNum = new string[] {""} ;
         P00C34_A2077VouSts = new short[1] ;
         P00C34_A91CueCod = new string[] {""} ;
         P00C34_A128VouMes = new short[1] ;
         P00C34_A127VouAno = new short[1] ;
         P00C34_A130VouDSec = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_libro1_1pdf__default(),
            new Object[][] {
                new Object[] {
               P00C32_A867CueMov, P00C32_A91CueCod, P00C32_A860CueDsc
               }
               , new Object[] {
               P00C33_A126TASICod, P00C33_A129VouNum, P00C33_A127VouAno, P00C33_A128VouMes, P00C33_A91CueCod, P00C33_A2077VouSts, P00C33_A2075VouGls, P00C33_A2054VouDGls, P00C33_A2055VouDHab, P00C33_A2051VouDDeb,
               P00C33_A860CueDsc, P00C33_A136VouReg, P00C33_A135VouDFec, P00C33_A130VouDSec
               }
               , new Object[] {
               P00C34_A126TASICod, P00C34_A129VouNum, P00C34_A2077VouSts, P00C34_A91CueCod, P00C34_A128VouMes, P00C34_A127VouAno, P00C34_A130VouDSec
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
      private short AV51MesAnt ;
      private short A867CueMov ;
      private short AV55Flag ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short A2077VouSts ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private decimal AV22TDebe ;
      private decimal AV23THaber ;
      private decimal AV49SaldoDebe ;
      private decimal AV50SaldoHaber ;
      private decimal AV52Saldo ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV27Empresa ;
      private string AV28EmpDir ;
      private string AV58EmpRUC ;
      private string AV59Ruta ;
      private string AV56cMes ;
      private string GXt_char1 ;
      private string AV13Titulo ;
      private string AV14Periodo ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string AV34cCuenta1 ;
      private string AV41CueDsc ;
      private string AV70TitCuenta ;
      private string AV71TitCuenta2 ;
      private string A129VouNum ;
      private string A2075VouGls ;
      private string A2054VouDGls ;
      private string A136VouReg ;
      private string AV54Glosa ;
      private string AV25CueCod ;
      private DateTime A135VouDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private string AV74Logo_GXI ;
      private string AV60Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private IDataStoreProvider pr_default ;
      private short[] P00C32_A867CueMov ;
      private string[] P00C32_A91CueCod ;
      private string[] P00C32_A860CueDsc ;
      private int[] P00C33_A126TASICod ;
      private string[] P00C33_A129VouNum ;
      private short[] P00C33_A127VouAno ;
      private short[] P00C33_A128VouMes ;
      private string[] P00C33_A91CueCod ;
      private short[] P00C33_A2077VouSts ;
      private string[] P00C33_A2075VouGls ;
      private string[] P00C33_A2054VouDGls ;
      private decimal[] P00C33_A2055VouDHab ;
      private decimal[] P00C33_A2051VouDDeb ;
      private string[] P00C33_A860CueDsc ;
      private string[] P00C33_A136VouReg ;
      private DateTime[] P00C33_A135VouDFec ;
      private int[] P00C33_A130VouDSec ;
      private int[] P00C34_A126TASICod ;
      private string[] P00C34_A129VouNum ;
      private short[] P00C34_A2077VouSts ;
      private string[] P00C34_A91CueCod ;
      private short[] P00C34_A128VouMes ;
      private short[] P00C34_A127VouAno ;
      private int[] P00C34_A130VouDSec ;
   }

   public class r_libro1_1pdf__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00C32;
          prmP00C32 = new Object[] {
          };
          Object[] prmP00C33;
          prmP00C33 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV34cCuenta1",GXType.NChar,15,0)
          };
          Object[] prmP00C34;
          prmP00C34 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV34cCuenta1",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C32", "SELECT [CueMov], [CueCod], [CueDsc] FROM [CBPLANCUENTA] WHERE (SUBSTRING([CueCod], 1, 3) = '101' or SUBSTRING([CueCod], 1, 3) = '102' or SUBSTRING([CueCod], 1, 3) = '103') AND ([CueMov] = 1) ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C32,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C33", "SELECT T1.[TASICod], T1.[VouNum], T1.[VouAno], T1.[VouMes], T1.[CueCod], T2.[VouSts], T2.[VouGls], T1.[VouDGls], T1.[VouDHab], T1.[VouDDeb], T3.[CueDsc], T1.[VouReg], T1.[VouDFec], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) INNER JOIN [CBPLANCUENTA] T3 ON T3.[CueCod] = T1.[CueCod]) WHERE (T1.[VouAno] = @AV11Ano) AND (T1.[VouMes] = @AV12Mes) AND (T1.[CueCod] = @AV34cCuenta1) AND (T2.[VouSts] = 1) ORDER BY T1.[VouDFec], T1.[VouReg] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C33,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C34", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes and T1.[CueCod] = @AV34cCuenta1) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C34,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 100);
                ((string[]) buf[11])[0] = rslt.getString(12, 15);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(13);
                ((int[]) buf[13])[0] = rslt.getInt(14);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
