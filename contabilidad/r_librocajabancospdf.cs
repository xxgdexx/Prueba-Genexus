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
   public class r_librocajabancospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_librocajabancospdf.aspx")), "contabilidad.r_librocajabancospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_librocajabancospdf.aspx")))) ;
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
                  AV34cCuenta1 = GetPar( "cCuenta1");
                  AV35cCuenta2 = GetPar( "cCuenta2");
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

      public r_librocajabancospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_librocajabancospdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref string aP2_cCuenta1 ,
                           ref string aP3_cCuenta2 )
      {
         this.AV11Ano = aP0_Ano;
         this.AV12Mes = aP1_Mes;
         this.AV34cCuenta1 = aP2_cCuenta1;
         this.AV35cCuenta2 = aP3_cCuenta2;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_cCuenta1=this.AV34cCuenta1;
         aP3_cCuenta2=this.AV35cCuenta2;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                ref string aP2_cCuenta1 )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_cCuenta1, ref aP3_cCuenta2);
         return AV35cCuenta2 ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref string aP2_cCuenta1 ,
                                 ref string aP3_cCuenta2 )
      {
         r_librocajabancospdf objr_librocajabancospdf;
         objr_librocajabancospdf = new r_librocajabancospdf();
         objr_librocajabancospdf.AV11Ano = aP0_Ano;
         objr_librocajabancospdf.AV12Mes = aP1_Mes;
         objr_librocajabancospdf.AV34cCuenta1 = aP2_cCuenta1;
         objr_librocajabancospdf.AV35cCuenta2 = aP3_cCuenta2;
         objr_librocajabancospdf.context.SetSubmitInitialConfig(context);
         objr_librocajabancospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_librocajabancospdf);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_cCuenta1=this.AV34cCuenta1;
         aP3_cCuenta2=this.AV35cCuenta2;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_librocajabancospdf)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 2, 9, 11909, 16834, 0, 1, 1, 0, 1, 1) )
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
            AV58EmpRUC = AV30Session.Get("EmpRUC");
            AV59Ruta = AV30Session.Get("RUTA") + "/Logo.jpg";
            AV60Logo = AV59Ruta;
            AV66Logo_GXI = GXDbFile.PathToUrl( AV59Ruta);
            AV57FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV16FechaD = context.localUtil.CToD( AV57FechaC, 2);
            GXt_char1 = AV56cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
            AV56cMes = GXt_char1;
            AV13Titulo = "Libro Caja Bancos";
            AV14Periodo = "Año : " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0)) + " Mes : " + AV56cMes;
            AV51MesAnt = (short)(AV12Mes-1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV34cCuenta1 ,
                                                 A91CueCod ,
                                                 AV35cCuenta2 } ,
                                                 new int[]{
                                                 }
            });
            /* Using cursor P00B22 */
            pr_default.execute(0, new Object[] {AV34cCuenta1, AV35cCuenta2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A91CueCod = P00B22_A91CueCod[0];
               A860CueDsc = P00B22_A860CueDsc[0];
               AV25CueCod = A91CueCod;
               AV41CueDsc = "Cuenta : " + StringUtil.Trim( AV25CueCod) + " " + StringUtil.Trim( A860CueDsc);
               AV53CueDsc2 = "Total Cuenta : " + StringUtil.Trim( AV25CueCod);
               AV49SaldoDebe = 0.00m;
               AV50SaldoHaber = 0.00m;
               AV22TDebe = 0.00m;
               AV23THaber = 0.00m;
               AV52Saldo = 0.00m;
               AV55Flag = 0;
               new GeneXus.Programs.contabilidad.psaldocuentames(context ).execute(  AV25CueCod,  AV11Ano,  AV51MesAnt, out  AV49SaldoDebe, out  AV50SaldoHaber, out  AV52Saldo) ;
               AV49SaldoDebe = ((AV52Saldo>Convert.ToDecimal(0)) ? AV52Saldo : (decimal)(0));
               AV50SaldoHaber = ((AV52Saldo<Convert.ToDecimal(0)) ? AV52Saldo*-1 : (decimal)(0));
               if ( ( AV52Saldo != Convert.ToDecimal( 0 )) )
               {
                  AV55Flag = 1;
               }
               /* Execute user subroutine: 'VALIDAMOV' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( AV55Flag == 1 )
               {
                  HB20( false, 20) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41CueDsc, "")), 14, Gx_line+3, 517, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49SaldoDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 710, Gx_line+3, 817, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50SaldoHaber, "ZZZZZZ,ZZZ,ZZ9.99")), 796, Gx_line+3, 903, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Saldo Cuenta Anterior", 609, Gx_line+3, 739, Gx_line+17, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
                  AV22TDebe = AV49SaldoDebe;
                  AV23THaber = AV50SaldoHaber;
               }
               /* Using cursor P00B23 */
               pr_default.execute(1, new Object[] {AV11Ano, AV12Mes, AV25CueCod});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A126TASICod = P00B23_A126TASICod[0];
                  A2077VouSts = P00B23_A2077VouSts[0];
                  A91CueCod = P00B23_A91CueCod[0];
                  A128VouMes = P00B23_A128VouMes[0];
                  A127VouAno = P00B23_A127VouAno[0];
                  A2075VouGls = P00B23_A2075VouGls[0];
                  A2054VouDGls = P00B23_A2054VouDGls[0];
                  A2055VouDHab = P00B23_A2055VouDHab[0];
                  A2051VouDDeb = P00B23_A2051VouDDeb[0];
                  A129VouNum = P00B23_A129VouNum[0];
                  A1894TASIAbr = P00B23_A1894TASIAbr[0];
                  A135VouDFec = P00B23_A135VouDFec[0];
                  A2053VouDDoc = P00B23_A2053VouDDoc[0];
                  A130VouDSec = P00B23_A130VouDSec[0];
                  A1894TASIAbr = P00B23_A1894TASIAbr[0];
                  A2077VouSts = P00B23_A2077VouSts[0];
                  A2075VouGls = P00B23_A2075VouGls[0];
                  AV54Glosa = A2075VouGls;
                  AV25CueCod = A91CueCod;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
                  {
                     AV54Glosa = A2054VouDGls;
                  }
                  AV52Saldo = (decimal)(AV52Saldo+(A2051VouDDeb-A2055VouDHab));
                  HB20( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2051VouDDeb, "ZZZ,ZZZ,ZZ9.99")), 710, Gx_line+1, 805, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2055VouDHab, "ZZZ,ZZZ,ZZ9.99")), 796, Gx_line+1, 891, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2053VouDDoc, "")), 203, Gx_line+1, 310, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A135VouDFec, "99/99/99"), 356, Gx_line+1, 403, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1894TASIAbr, "")), 15, Gx_line+1, 68, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A129VouNum, "")), 104, Gx_line+1, 157, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Glosa, "")), 436, Gx_line+1, 755, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 888, Gx_line+3, 995, Gx_line+18, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
                  AV22TDebe = (decimal)(AV22TDebe+A2051VouDDeb);
                  AV23THaber = (decimal)(AV23THaber+A2055VouDHab);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV47TDebeMO = (decimal)(AV47TDebeMO+AV22TDebe);
               AV48ThaberMO = (decimal)(AV48ThaberMO+AV23THaber);
               AV52Saldo = (decimal)(AV22TDebe-AV23THaber);
               AV61CueDsc3 = "Saldo Cuenta " + AV25CueCod;
               AV62TDebePagMo = (decimal)(AV62TDebePagMo+AV22TDebe);
               AV63THaberPagMo = (decimal)(AV63THaberPagMo+AV23THaber);
               if ( AV55Flag == 1 )
               {
                  HB20( false, 57) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV22TDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 710, Gx_line+7, 817, Gx_line+22, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23THaber, "ZZZZZZ,ZZZ,ZZ9.99")), 796, Gx_line+7, 903, Gx_line+22, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53CueDsc2, "")), 446, Gx_line+8, 747, Gx_line+22, 2, 0, 0, 0) ;
                  getPrinter().GxDrawLine(750, Gx_line+5, 1011, Gx_line+5, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61CueDsc3, "")), 446, Gx_line+24, 747, Gx_line+38, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 710, Gx_line+24, 817, Gx_line+39, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+57);
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV52Saldo = (decimal)(AV47TDebeMO-AV48ThaberMO);
            AV47TDebeMO = ((AV52Saldo>Convert.ToDecimal(0)) ? AV52Saldo : (decimal)(0));
            AV48ThaberMO = ((AV52Saldo<Convert.ToDecimal(0)) ? AV52Saldo*-1 : (decimal)(0));
            HB20( false, 35) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Cuenta General :", 550, Gx_line+9, 681, Gx_line+23, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(750, Gx_line+3, 1011, Gx_line+3, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TDebeMO, "ZZZZZZ,ZZZ,ZZ9.99")), 710, Gx_line+9, 817, Gx_line+24, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48ThaberMO, "ZZZZZZ,ZZZ,ZZ9.99")), 796, Gx_line+9, 903, Gx_line+24, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+35);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HB20( true, 0) ;
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
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         /* Using cursor P00B24 */
         pr_default.execute(2, new Object[] {AV11Ano, AV12Mes, AV25CueCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00B24_A126TASICod[0];
            A129VouNum = P00B24_A129VouNum[0];
            A2077VouSts = P00B24_A2077VouSts[0];
            A91CueCod = P00B24_A91CueCod[0];
            A128VouMes = P00B24_A128VouMes[0];
            A127VouAno = P00B24_A127VouAno[0];
            A130VouDSec = P00B24_A130VouDSec[0];
            A2077VouSts = P00B24_A2077VouSts[0];
            AV55Flag = 1;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void HB20( bool bFoot ,
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
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62TDebePagMo, "ZZZZZZ,ZZZ,ZZ9.99")), 709, Gx_line+4, 816, Gx_line+19, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63THaberPagMo, "ZZZZZZ,ZZZ,ZZ9.99")), 795, Gx_line+4, 902, Gx_line+19, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Pagina ", 570, Gx_line+4, 647, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 655, Gx_line+4, 694, Gx_line+19, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+29);
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 296, Gx_line+25, 752, Gx_line+59, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 296, Gx_line+56, 752, Gx_line+90, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 9, Gx_line+90, 377, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58EmpRUC, "")), 9, Gx_line+107, 380, Gx_line+125, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV60Logo)) ? AV66Logo_GXI : AV60Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 10, Gx_line+7, 168, Gx_line+85) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 905, Gx_line+29, 949, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 955, Gx_line+29, 994, Gx_line+44, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+130);
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Debe", 789, Gx_line+21, 820, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Haber", 870, Gx_line+21, 906, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Documento", 223, Gx_line+21, 292, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 357, Gx_line+21, 392, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(186, Gx_line+1, 186, Gx_line+36, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(436, Gx_line+0, 436, Gx_line+35, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(751, Gx_line+1, 751, Gx_line+36, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe Moneda Nacional", 806, Gx_line+2, 958, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Documento", 272, Gx_line+2, 341, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+0, 1023, Gx_line+36, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(751, Gx_line+19, 1022, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 951, Gx_line+21, 984, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Glosa", 578, Gx_line+14, 611, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+19, 438, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Asiento", 64, Gx_line+3, 110, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo Asiento", 7, Gx_line+21, 81, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Asiento", 103, Gx_line+21, 165, Gx_line+35, 0+256, 0, 0, 0) ;
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
         AV66Logo_GXI = "";
         AV57FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV56cMes = "";
         GXt_char1 = "";
         AV13Titulo = "";
         AV14Periodo = "";
         scmdbuf = "";
         A91CueCod = "";
         P00B22_A91CueCod = new string[] {""} ;
         P00B22_A860CueDsc = new string[] {""} ;
         A860CueDsc = "";
         AV25CueCod = "";
         AV41CueDsc = "";
         AV53CueDsc2 = "";
         P00B23_A126TASICod = new int[1] ;
         P00B23_A2077VouSts = new short[1] ;
         P00B23_A91CueCod = new string[] {""} ;
         P00B23_A128VouMes = new short[1] ;
         P00B23_A127VouAno = new short[1] ;
         P00B23_A2075VouGls = new string[] {""} ;
         P00B23_A2054VouDGls = new string[] {""} ;
         P00B23_A2055VouDHab = new decimal[1] ;
         P00B23_A2051VouDDeb = new decimal[1] ;
         P00B23_A129VouNum = new string[] {""} ;
         P00B23_A1894TASIAbr = new string[] {""} ;
         P00B23_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00B23_A2053VouDDoc = new string[] {""} ;
         P00B23_A130VouDSec = new int[1] ;
         A2075VouGls = "";
         A2054VouDGls = "";
         A129VouNum = "";
         A1894TASIAbr = "";
         A135VouDFec = DateTime.MinValue;
         A2053VouDDoc = "";
         AV54Glosa = "";
         AV61CueDsc3 = "";
         P00B24_A126TASICod = new int[1] ;
         P00B24_A129VouNum = new string[] {""} ;
         P00B24_A2077VouSts = new short[1] ;
         P00B24_A91CueCod = new string[] {""} ;
         P00B24_A128VouMes = new short[1] ;
         P00B24_A127VouAno = new short[1] ;
         P00B24_A130VouDSec = new int[1] ;
         AV60Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_librocajabancospdf__default(),
            new Object[][] {
                new Object[] {
               P00B22_A91CueCod, P00B22_A860CueDsc
               }
               , new Object[] {
               P00B23_A126TASICod, P00B23_A2077VouSts, P00B23_A91CueCod, P00B23_A128VouMes, P00B23_A127VouAno, P00B23_A2075VouGls, P00B23_A2054VouDGls, P00B23_A2055VouDHab, P00B23_A2051VouDDeb, P00B23_A129VouNum,
               P00B23_A1894TASIAbr, P00B23_A135VouDFec, P00B23_A2053VouDDoc, P00B23_A130VouDSec
               }
               , new Object[] {
               P00B24_A126TASICod, P00B24_A129VouNum, P00B24_A2077VouSts, P00B24_A91CueCod, P00B24_A128VouMes, P00B24_A127VouAno, P00B24_A130VouDSec
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
      private short AV55Flag ;
      private short A2077VouSts ;
      private short A128VouMes ;
      private short A127VouAno ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private decimal AV49SaldoDebe ;
      private decimal AV50SaldoHaber ;
      private decimal AV22TDebe ;
      private decimal AV23THaber ;
      private decimal AV52Saldo ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private decimal AV47TDebeMO ;
      private decimal AV48ThaberMO ;
      private decimal AV62TDebePagMo ;
      private decimal AV63THaberPagMo ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV34cCuenta1 ;
      private string AV35cCuenta2 ;
      private string AV27Empresa ;
      private string AV28EmpDir ;
      private string AV58EmpRUC ;
      private string AV59Ruta ;
      private string AV57FechaC ;
      private string AV56cMes ;
      private string GXt_char1 ;
      private string AV13Titulo ;
      private string AV14Periodo ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string AV25CueCod ;
      private string AV41CueDsc ;
      private string AV53CueDsc2 ;
      private string A2075VouGls ;
      private string A2054VouDGls ;
      private string A129VouNum ;
      private string A1894TASIAbr ;
      private string A2053VouDDoc ;
      private string AV54Glosa ;
      private string AV61CueDsc3 ;
      private string sImgUrl ;
      private DateTime AV16FechaD ;
      private DateTime A135VouDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private string AV66Logo_GXI ;
      private string AV60Logo ;
      private string Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_cCuenta1 ;
      private string aP3_cCuenta2 ;
      private IDataStoreProvider pr_default ;
      private string[] P00B22_A91CueCod ;
      private string[] P00B22_A860CueDsc ;
      private int[] P00B23_A126TASICod ;
      private short[] P00B23_A2077VouSts ;
      private string[] P00B23_A91CueCod ;
      private short[] P00B23_A128VouMes ;
      private short[] P00B23_A127VouAno ;
      private string[] P00B23_A2075VouGls ;
      private string[] P00B23_A2054VouDGls ;
      private decimal[] P00B23_A2055VouDHab ;
      private decimal[] P00B23_A2051VouDDeb ;
      private string[] P00B23_A129VouNum ;
      private string[] P00B23_A1894TASIAbr ;
      private DateTime[] P00B23_A135VouDFec ;
      private string[] P00B23_A2053VouDDoc ;
      private int[] P00B23_A130VouDSec ;
      private int[] P00B24_A126TASICod ;
      private string[] P00B24_A129VouNum ;
      private short[] P00B24_A2077VouSts ;
      private string[] P00B24_A91CueCod ;
      private short[] P00B24_A128VouMes ;
      private short[] P00B24_A127VouAno ;
      private int[] P00B24_A130VouDSec ;
   }

   public class r_librocajabancospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B22( IGxContext context ,
                                             string AV34cCuenta1 ,
                                             string A91CueCod ,
                                             string AV35cCuenta2 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[2];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [CueCod], [CueDsc] FROM [CBPLANCUENTA]";
         AddWhere(sWhereString, "([CueCod] < '11')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34cCuenta1)) )
         {
            AddWhere(sWhereString, "([CueCod] >= @AV34cCuenta1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34cCuenta1)) )
         {
            AddWhere(sWhereString, "([CueCod] <= @AV35cCuenta2)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueCod]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00B22(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] );
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
          Object[] prmP00B23;
          prmP00B23 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0)
          };
          Object[] prmP00B24;
          prmP00B24 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0)
          };
          Object[] prmP00B22;
          prmP00B22 = new Object[] {
          new ParDef("@AV34cCuenta1",GXType.Char,15,0) ,
          new ParDef("@AV35cCuenta2",GXType.Char,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B22", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B22,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B23", "SELECT T1.[TASICod], T3.[VouSts], T1.[CueCod], T1.[VouMes], T1.[VouAno], T3.[VouGls], T1.[VouDGls], T1.[VouDHab], T1.[VouDDeb], T1.[VouNum], T2.[TASIAbr], T1.[VouDFec], T1.[VouDDoc], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes and T1.[CueCod] = @AV25CueCod) AND (T3.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B23,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00B24", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[CueCod], T1.[VouMes], T1.[VouAno], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes and T1.[CueCod] = @AV25CueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B24,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 10);
                ((string[]) buf[10])[0] = rslt.getString(11, 5);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 20);
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
