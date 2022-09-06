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
namespace GeneXus.Programs.bancos {
   public class r_reporteconciliacionbancariapdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "bancos.r_reporteconciliacionbancariapdf.aspx")), "bancos.r_reporteconciliacionbancariapdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "bancos.r_reporteconciliacionbancariapdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "BanCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV10BanCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12CBCod = GetPar( "CBCod");
                  AV23LBAno = (short)(NumberUtil.Val( GetPar( "LBAno"), "."));
                  AV25LBMes = (short)(NumberUtil.Val( GetPar( "LBMes"), "."));
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

      public r_reporteconciliacionbancariapdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reporteconciliacionbancariapdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_BanCod ,
                           ref string aP1_CBCod ,
                           ref short aP2_LBAno ,
                           ref short aP3_LBMes )
      {
         this.AV10BanCod = aP0_BanCod;
         this.AV12CBCod = aP1_CBCod;
         this.AV23LBAno = aP2_LBAno;
         this.AV25LBMes = aP3_LBMes;
         initialize();
         executePrivate();
         aP0_BanCod=this.AV10BanCod;
         aP1_CBCod=this.AV12CBCod;
         aP2_LBAno=this.AV23LBAno;
         aP3_LBMes=this.AV25LBMes;
      }

      public short executeUdp( ref int aP0_BanCod ,
                               ref string aP1_CBCod ,
                               ref short aP2_LBAno )
      {
         execute(ref aP0_BanCod, ref aP1_CBCod, ref aP2_LBAno, ref aP3_LBMes);
         return AV25LBMes ;
      }

      public void executeSubmit( ref int aP0_BanCod ,
                                 ref string aP1_CBCod ,
                                 ref short aP2_LBAno ,
                                 ref short aP3_LBMes )
      {
         r_reporteconciliacionbancariapdf objr_reporteconciliacionbancariapdf;
         objr_reporteconciliacionbancariapdf = new r_reporteconciliacionbancariapdf();
         objr_reporteconciliacionbancariapdf.AV10BanCod = aP0_BanCod;
         objr_reporteconciliacionbancariapdf.AV12CBCod = aP1_CBCod;
         objr_reporteconciliacionbancariapdf.AV23LBAno = aP2_LBAno;
         objr_reporteconciliacionbancariapdf.AV25LBMes = aP3_LBMes;
         objr_reporteconciliacionbancariapdf.context.SetSubmitInitialConfig(context);
         objr_reporteconciliacionbancariapdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reporteconciliacionbancariapdf);
         aP0_BanCod=this.AV10BanCod;
         aP1_CBCod=this.AV12CBCod;
         aP2_LBAno=this.AV23LBAno;
         aP3_LBMes=this.AV25LBMes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reporteconciliacionbancariapdf)stateInfo).executePrivate();
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
            AV17Empresa = AV33Session.Get("Empresa");
            AV16EmpDir = AV33Session.Get("EmpDir");
            AV18EmpRUC = AV33Session.Get("EmpRUC");
            AV30Ruta = AV33Session.Get("RUTA") + "/Logo.jpg";
            AV26Logo = AV30Ruta;
            AV39Logo_GXI = GXDbFile.PathToUrl( AV30Ruta);
            AV9AnoPos = AV23LBAno;
            AV28MesPos = AV25LBMes;
            AV20FechaCHR = "01/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV25LBMes), 10, 0)) + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV23LBAno), 10, 0));
            AV19Fecha = context.localUtil.CToD( AV20FechaCHR, 2);
            GXt_char1 = AV13CMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV25LBMes, out  GXt_char1) ;
            AV13CMes = GXt_char1;
            if ( AV25LBMes == 12 )
            {
               AV27MesAct = 1;
               AV8AnoAct = (short)(AV23LBAno+1);
            }
            else
            {
               AV27MesAct = (short)(AV25LBMes+1);
               AV8AnoAct = AV23LBAno;
            }
            AV20FechaCHR = "01/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV27MesAct), 10, 0)) + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV8AnoAct), 10, 0));
            AV19Fecha = context.localUtil.CToD( AV20FechaCHR, 2);
            AV11BanDsc = "";
            AV14CTBco = "";
            GXt_decimal2 = AV32SaldoIni;
            new GeneXus.Programs.bancos.pobtienesaldobancos(context ).execute( ref  AV10BanCod, ref  AV12CBCod, ref  AV19Fecha, out  GXt_decimal2) ;
            AV32SaldoIni = GXt_decimal2;
            AV15Debe = 0.00m;
            AV22Haber = 0.00m;
            AV31Saldo = AV32SaldoIni;
            AV34TDebe = 0.00m;
            AV35THaber = 0.00m;
            /* Using cursor P00AJ2 */
            pr_default.execute(0, new Object[] {AV10BanCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A372BanCod = P00AJ2_A372BanCod[0];
               A482BanDsc = P00AJ2_A482BanDsc[0];
               AV11BanDsc = A482BanDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00AJ3 */
            pr_default.execute(1, new Object[] {AV10BanCod, AV12CBCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A377CBCod = P00AJ3_A377CBCod[0];
               A372BanCod = P00AJ3_A372BanCod[0];
               AV14CTBco = A377CBCod;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            HAJ0( false, 45) ;
            getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11BanDsc, "")), 17, Gx_line+6, 643, Gx_line+24, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14CTBco, "")), 17, Gx_line+24, 143, Gx_line+42, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Saldo Final de Bancos", 296, Gx_line+25, 422, Gx_line+39, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32SaldoIni, "ZZZZZZ,ZZZ,ZZ9.99")), 442, Gx_line+25, 549, Gx_line+40, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+45);
            /* Using cursor P00AJ4 */
            pr_default.execute(2, new Object[] {AV10BanCod, AV12CBCod, AV21FechaUlt});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A1086LBProcesado = P00AJ4_A1086LBProcesado[0];
               A1079LBFech = P00AJ4_A1079LBFech[0];
               A380LBCBCod = P00AJ4_A380LBCBCod[0];
               A379LBBanCod = P00AJ4_A379LBBanCod[0];
               A1056LBCheq = P00AJ4_A1056LBCheq[0];
               A1057LBConcepto = P00AJ4_A1057LBConcepto[0];
               A1054LBBeneficia = P00AJ4_A1054LBBeneficia[0];
               A1078LBEstado = P00AJ4_A1078LBEstado[0];
               A1075LBDocumento = P00AJ4_A1075LBDocumento[0];
               A381LBRegistro = P00AJ4_A381LBRegistro[0];
               A1073LBTHaber = P00AJ4_A1073LBTHaber[0];
               A1072LBTDebe = P00AJ4_A1072LBTDebe[0];
               A1070LBTipo = P00AJ4_A1070LBTipo[0];
               A1071LBTSaldo = (((A1072LBTDebe-A1073LBTHaber)<Convert.ToDecimal(0)) ? (A1072LBTDebe-A1073LBTHaber)*-1 : (((A1073LBTHaber-A1072LBTDebe)<Convert.ToDecimal(0)) ? (A1073LBTHaber-A1072LBTDebe)*-1 : A1072LBTDebe-A1073LBTHaber));
               A1082LBHaberTot = ((A1070LBTipo==0) ? A1071LBTSaldo : (decimal)(0));
               A1069LBDebeTot = ((A1070LBTipo==1) ? A1071LBTSaldo : (decimal)(0));
               AV15Debe = A1069LBDebeTot;
               AV22Haber = A1082LBHaberTot;
               AV29Mov = (decimal)(AV15Debe-AV22Haber);
               AV31Saldo = (decimal)(AV31Saldo-AV29Mov);
               AV24LBBeneficia = ((StringUtil.StrCmp(A1078LBEstado, "P")==0) ? A1054LBBeneficia : A1057LBConcepto);
               HAJ0( false, 20) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV15Debe, "ZZZZZZ,ZZZ,ZZ9.99")), 442, Gx_line+3, 549, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV22Haber, "ZZZZZZ,ZZZ,ZZ9.99")), 566, Gx_line+3, 673, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 671, Gx_line+3, 778, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A381LBRegistro, "")), 11, Gx_line+2, 84, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A1079LBFech, "99/99/99"), 178, Gx_line+2, 253, Gx_line+19, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24LBBeneficia, "")), 252, Gx_line+2, 497, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1075LBDocumento, "")), 89, Gx_line+1, 186, Gx_line+19, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
               AV34TDebe = (decimal)(AV34TDebe+AV15Debe);
               AV35THaber = (decimal)(AV35THaber+AV22Haber);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            HAJ0( false, 31) ;
            getPrinter().GxDrawLine(485, Gx_line+4, 785, Gx_line+4, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34TDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 424, Gx_line+6, 548, Gx_line+20, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35THaber, "ZZZZZZ,ZZZ,ZZ9.99")), 548, Gx_line+6, 672, Gx_line+20, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 671, Gx_line+6, 778, Gx_line+21, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+31);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HAJ0( true, 0) ;
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

      protected void HAJ0( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Conciliación Bancaria", 291, Gx_line+28, 472, Gx_line+48, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+109, 796, Gx_line+143, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Registro", 10, Gx_line+120, 78, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Documento", 89, Gx_line+120, 174, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 196, Gx_line+120, 231, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Concepto", 331, Gx_line+120, 387, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Debe", 525, Gx_line+120, 556, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Haber", 623, Gx_line+120, 659, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 727, Gx_line+120, 760, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hora:", 670, Gx_line+32, 702, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 670, Gx_line+50, 714, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 670, Gx_line+15, 709, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 717, Gx_line+14, 764, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 679, Gx_line+31, 763, Gx_line+46, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 725, Gx_line+49, 764, Gx_line+64, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Mes : ", 272, Gx_line+59, 311, Gx_line+74, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Año :", 405, Gx_line+59, 440, Gx_line+74, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV23LBAno), "ZZZ9")), 448, Gx_line+59, 478, Gx_line+75, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13CMes, "")), 310, Gx_line+59, 374, Gx_line+75, 1+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV26Logo)) ? AV39Logo_GXI : AV26Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 19, Gx_line+17, 177, Gx_line+95) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+144);
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
         AV17Empresa = "";
         AV33Session = context.GetSession();
         AV16EmpDir = "";
         AV18EmpRUC = "";
         AV30Ruta = "";
         AV26Logo = "";
         AV39Logo_GXI = "";
         AV20FechaCHR = "";
         AV19Fecha = DateTime.MinValue;
         AV13CMes = "";
         GXt_char1 = "";
         AV11BanDsc = "";
         AV14CTBco = "";
         scmdbuf = "";
         P00AJ2_A372BanCod = new int[1] ;
         P00AJ2_A482BanDsc = new string[] {""} ;
         A482BanDsc = "";
         P00AJ3_A377CBCod = new string[] {""} ;
         P00AJ3_A372BanCod = new int[1] ;
         A377CBCod = "";
         AV21FechaUlt = DateTime.MinValue;
         P00AJ4_A1086LBProcesado = new short[1] ;
         P00AJ4_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P00AJ4_A380LBCBCod = new string[] {""} ;
         P00AJ4_A379LBBanCod = new int[1] ;
         P00AJ4_A1056LBCheq = new short[1] ;
         P00AJ4_A1057LBConcepto = new string[] {""} ;
         P00AJ4_A1054LBBeneficia = new string[] {""} ;
         P00AJ4_A1078LBEstado = new string[] {""} ;
         P00AJ4_A1075LBDocumento = new string[] {""} ;
         P00AJ4_A381LBRegistro = new string[] {""} ;
         P00AJ4_A1073LBTHaber = new decimal[1] ;
         P00AJ4_A1072LBTDebe = new decimal[1] ;
         P00AJ4_A1070LBTipo = new short[1] ;
         A1079LBFech = DateTime.MinValue;
         A380LBCBCod = "";
         A1057LBConcepto = "";
         A1054LBBeneficia = "";
         A1078LBEstado = "";
         A1075LBDocumento = "";
         A381LBRegistro = "";
         AV24LBBeneficia = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV26Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.r_reporteconciliacionbancariapdf__default(),
            new Object[][] {
                new Object[] {
               P00AJ2_A372BanCod, P00AJ2_A482BanDsc
               }
               , new Object[] {
               P00AJ3_A377CBCod, P00AJ3_A372BanCod
               }
               , new Object[] {
               P00AJ4_A1086LBProcesado, P00AJ4_A1079LBFech, P00AJ4_A380LBCBCod, P00AJ4_A379LBBanCod, P00AJ4_A1056LBCheq, P00AJ4_A1057LBConcepto, P00AJ4_A1054LBBeneficia, P00AJ4_A1078LBEstado, P00AJ4_A1075LBDocumento, P00AJ4_A381LBRegistro,
               P00AJ4_A1073LBTHaber, P00AJ4_A1072LBTDebe, P00AJ4_A1070LBTipo
               }
            }
         );
         Gx_time = context.localUtil.Time( );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_time = context.localUtil.Time( );
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV23LBAno ;
      private short AV25LBMes ;
      private short AV9AnoPos ;
      private short AV28MesPos ;
      private short AV27MesAct ;
      private short AV8AnoAct ;
      private short A1086LBProcesado ;
      private short A1056LBCheq ;
      private short A1070LBTipo ;
      private int AV10BanCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A372BanCod ;
      private int Gx_OldLine ;
      private int A379LBBanCod ;
      private decimal AV32SaldoIni ;
      private decimal GXt_decimal2 ;
      private decimal AV15Debe ;
      private decimal AV22Haber ;
      private decimal AV31Saldo ;
      private decimal AV34TDebe ;
      private decimal AV35THaber ;
      private decimal A1073LBTHaber ;
      private decimal A1072LBTDebe ;
      private decimal A1071LBTSaldo ;
      private decimal A1082LBHaberTot ;
      private decimal A1069LBDebeTot ;
      private decimal AV29Mov ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV12CBCod ;
      private string AV17Empresa ;
      private string AV16EmpDir ;
      private string AV18EmpRUC ;
      private string AV30Ruta ;
      private string AV20FechaCHR ;
      private string AV13CMes ;
      private string GXt_char1 ;
      private string AV11BanDsc ;
      private string AV14CTBco ;
      private string scmdbuf ;
      private string A482BanDsc ;
      private string A377CBCod ;
      private string A380LBCBCod ;
      private string A1057LBConcepto ;
      private string A1054LBBeneficia ;
      private string A1078LBEstado ;
      private string A1075LBDocumento ;
      private string A381LBRegistro ;
      private string AV24LBBeneficia ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV19Fecha ;
      private DateTime AV21FechaUlt ;
      private DateTime A1079LBFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string AV39Logo_GXI ;
      private string AV26Logo ;
      private string Logo ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_BanCod ;
      private string aP1_CBCod ;
      private short aP2_LBAno ;
      private short aP3_LBMes ;
      private IDataStoreProvider pr_default ;
      private int[] P00AJ2_A372BanCod ;
      private string[] P00AJ2_A482BanDsc ;
      private string[] P00AJ3_A377CBCod ;
      private int[] P00AJ3_A372BanCod ;
      private short[] P00AJ4_A1086LBProcesado ;
      private DateTime[] P00AJ4_A1079LBFech ;
      private string[] P00AJ4_A380LBCBCod ;
      private int[] P00AJ4_A379LBBanCod ;
      private short[] P00AJ4_A1056LBCheq ;
      private string[] P00AJ4_A1057LBConcepto ;
      private string[] P00AJ4_A1054LBBeneficia ;
      private string[] P00AJ4_A1078LBEstado ;
      private string[] P00AJ4_A1075LBDocumento ;
      private string[] P00AJ4_A381LBRegistro ;
      private decimal[] P00AJ4_A1073LBTHaber ;
      private decimal[] P00AJ4_A1072LBTDebe ;
      private short[] P00AJ4_A1070LBTipo ;
   }

   public class r_reporteconciliacionbancariapdf__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AJ2;
          prmP00AJ2 = new Object[] {
          new ParDef("@AV10BanCod",GXType.Int32,6,0)
          };
          Object[] prmP00AJ3;
          prmP00AJ3 = new Object[] {
          new ParDef("@AV10BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV12CBCod",GXType.NChar,20,0)
          };
          Object[] prmP00AJ4;
          prmP00AJ4 = new Object[] {
          new ParDef("@AV10BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV12CBCod",GXType.NChar,20,0) ,
          new ParDef("@AV21FechaUlt",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AJ2", "SELECT [BanCod], [BanDsc] FROM [TSBANCOS] WHERE [BanCod] = @AV10BanCod ORDER BY [BanCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AJ2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AJ3", "SELECT [CBCod], [BanCod] FROM [TSCUENTABANCO] WHERE [BanCod] = @AV10BanCod and [CBCod] = @AV12CBCod ORDER BY [BanCod], [CBCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AJ3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AJ4", "SELECT [LBProcesado], [LBFech], [LBCBCod], [LBBanCod], [LBCheq], [LBConcepto], [LBBeneficia], [LBEstado], [LBDocumento], [LBRegistro], [LBTHaber], [LBTDebe], [LBTipo] FROM [TSLIBROBANCOS] WHERE ([LBBanCod] = @AV10BanCod and [LBCBCod] = @AV12CBCod) AND ([LBFech] <= @AV21FechaUlt) AND ([LBProcesado] = 0) ORDER BY [LBBanCod], [LBCBCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AJ4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 60);
                ((string[]) buf[6])[0] = rslt.getString(7, 60);
                ((string[]) buf[7])[0] = rslt.getString(8, 1);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                return;
       }
    }

 }

}
