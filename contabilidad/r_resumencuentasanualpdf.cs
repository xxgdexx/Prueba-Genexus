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
   public class r_resumencuentasanualpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_resumencuentasanualpdf.aspx")), "contabilidad.r_resumencuentasanualpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_resumencuentasanualpdf.aspx")))) ;
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
               AV8Ano = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV15Cuenta1 = GetPar( "Cuenta1");
                  AV16Cuenta2 = GetPar( "Cuenta2");
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

      public r_resumencuentasanualpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumencuentasanualpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref string aP1_Cuenta1 ,
                           ref string aP2_Cuenta2 )
      {
         this.AV8Ano = aP0_Ano;
         this.AV15Cuenta1 = aP1_Cuenta1;
         this.AV16Cuenta2 = aP2_Cuenta2;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_Cuenta1=this.AV15Cuenta1;
         aP2_Cuenta2=this.AV16Cuenta2;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref string aP1_Cuenta1 )
      {
         execute(ref aP0_Ano, ref aP1_Cuenta1, ref aP2_Cuenta2);
         return AV16Cuenta2 ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref string aP1_Cuenta1 ,
                                 ref string aP2_Cuenta2 )
      {
         r_resumencuentasanualpdf objr_resumencuentasanualpdf;
         objr_resumencuentasanualpdf = new r_resumencuentasanualpdf();
         objr_resumencuentasanualpdf.AV8Ano = aP0_Ano;
         objr_resumencuentasanualpdf.AV15Cuenta1 = aP1_Cuenta1;
         objr_resumencuentasanualpdf.AV16Cuenta2 = aP2_Cuenta2;
         objr_resumencuentasanualpdf.context.SetSubmitInitialConfig(context);
         objr_resumencuentasanualpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumencuentasanualpdf);
         aP0_Ano=this.AV8Ano;
         aP1_Cuenta1=this.AV15Cuenta1;
         aP2_Cuenta2=this.AV16Cuenta2;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumencuentasanualpdf)stateInfo).executePrivate();
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
            AV20Empresa = AV81Session.Get("Empresa");
            AV19EmpDir = AV81Session.Get("EmpDir");
            AV21EmpRUC = AV81Session.Get("EmpRUC");
            AV75Ruta = AV81Session.Get("RUTA") + "/Logo.jpg";
            AV38Logo = AV75Ruta;
            AV102Logo_GXI = GXDbFile.PathToUrl( AV75Ruta);
            AV83Titulo = "Resumen Anual de Cuentas";
            AV72Periodo = "Año : " + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0));
            HBJ0( false, 105) ;
            getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83Titulo, "")), 352, Gx_line+14, 808, Gx_line+39, 1, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+76, 1148, Gx_line+105, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descripción", 151, Gx_line+85, 199, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20Empresa, "")), 14, Gx_line+28, 384, Gx_line+46, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21EmpRUC, "")), 14, Gx_line+46, 385, Gx_line+64, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72Periodo, "")), 352, Gx_line+39, 808, Gx_line+64, 1, 0, 0, 0) ;
            getPrinter().GxDrawLine(306, Gx_line+76, 306, Gx_line+104, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Enero", 324, Gx_line+85, 349, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(371, Gx_line+76, 371, Gx_line+104, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Febrero", 384, Gx_line+85, 417, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Marzo", 451, Gx_line+85, 477, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(435, Gx_line+77, 435, Gx_line+105, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Abril", 520, Gx_line+85, 539, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(500, Gx_line+77, 500, Gx_line+105, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Junio", 648, Gx_line+85, 671, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(565, Gx_line+77, 565, Gx_line+105, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Mayo", 588, Gx_line+85, 612, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(693, Gx_line+77, 693, Gx_line+105, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Julio", 716, Gx_line+85, 736, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(757, Gx_line+77, 757, Gx_line+105, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Agosto", 775, Gx_line+85, 804, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(822, Gx_line+77, 822, Gx_line+105, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Sept.", 848, Gx_line+85, 871, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(886, Gx_line+77, 886, Gx_line+105, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Oct.", 914, Gx_line+85, 932, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(951, Gx_line+77, 951, Gx_line+105, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Nov.", 975, Gx_line+85, 996, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(1016, Gx_line+77, 1016, Gx_line+105, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Dic.", 1041, Gx_line+85, 1058, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(61, Gx_line+76, 61, Gx_line+104, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(1080, Gx_line+77, 1080, Gx_line+105, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Total", 1106, Gx_line+85, 1128, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(629, Gx_line+77, 629, Gx_line+105, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Cuenta", 11, Gx_line+85, 41, Gx_line+95, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Página:", 981, Gx_line+28, 1025, Gx_line+42, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1031, Gx_line+28, 1070, Gx_line+43, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+105);
            /* Using cursor P00BJ2 */
            pr_default.execute(0, new Object[] {AV15Cuenta1, AV8Ano, AV16Cuenta2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKBJ2 = false;
               A133CueCodAux = P00BJ2_A133CueCodAux[0];
               A91CueCod = P00BJ2_A91CueCod[0];
               A127VouAno = P00BJ2_A127VouAno[0];
               A2053VouDDoc = P00BJ2_A2053VouDDoc[0];
               A860CueDsc = P00BJ2_A860CueDsc[0];
               A128VouMes = P00BJ2_A128VouMes[0];
               A126TASICod = P00BJ2_A126TASICod[0];
               A129VouNum = P00BJ2_A129VouNum[0];
               A130VouDSec = P00BJ2_A130VouDSec[0];
               A860CueDsc = P00BJ2_A860CueDsc[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BJ2_A91CueCod[0], A91CueCod) == 0 ) )
               {
                  BRKBJ2 = false;
                  A133CueCodAux = P00BJ2_A133CueCodAux[0];
                  A127VouAno = P00BJ2_A127VouAno[0];
                  A128VouMes = P00BJ2_A128VouMes[0];
                  A126TASICod = P00BJ2_A126TASICod[0];
                  A129VouNum = P00BJ2_A129VouNum[0];
                  A130VouDSec = P00BJ2_A130VouDSec[0];
                  BRKBJ2 = true;
                  pr_default.readNext(0);
               }
               AV45nCueCod = StringUtil.Trim( A91CueCod);
               AV46nCueDsc = A860CueDsc;
               AV48nEnero = 0.00m;
               AV49nFebrero = 0.00m;
               AV52nMarzo = 0.00m;
               AV42nAbril = 0.00m;
               AV53nMayo = 0.00m;
               AV51nJunio = 0.00m;
               AV50nJulio = 0.00m;
               AV43nAgosto = 0.00m;
               AV56nSep = 0.00m;
               AV55nOct = 0.00m;
               AV54nNov = 0.00m;
               AV47nDic = 0.00m;
               AV69nTotal = 0.00m;
               /* Execute user subroutine: 'MOVIMIENTOMES' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               AV61nTEnero = (decimal)(AV61nTEnero+AV48nEnero);
               AV62nTFebrero = (decimal)(AV62nTFebrero+AV49nFebrero);
               AV65nTMarzo = (decimal)(AV65nTMarzo+AV52nMarzo);
               AV57nTAbril = (decimal)(AV57nTAbril+AV42nAbril);
               AV66nTMayo = (decimal)(AV66nTMayo+AV53nMayo);
               AV64nTJunio = (decimal)(AV64nTJunio+AV51nJunio);
               AV63nTJulio = (decimal)(AV63nTJulio+AV50nJulio);
               AV58nTAgosto = (decimal)(AV58nTAgosto+AV43nAgosto);
               AV70nTSep = (decimal)(AV70nTSep+AV56nSep);
               AV68nTOct = (decimal)(AV68nTOct+AV55nOct);
               AV67nTNov = (decimal)(AV67nTNov+AV54nNov);
               AV60nTDic = (decimal)(AV60nTDic+AV47nDic);
               if ( ! BRKBJ2 )
               {
                  BRKBJ2 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            HBJ0( false, 25) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61nTEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 300, Gx_line+8, 372, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64nTJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 621, Gx_line+8, 693, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58nTAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 750, Gx_line+8, 822, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62nTFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 364, Gx_line+8, 436, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65nTMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 427, Gx_line+8, 499, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57nTAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 492, Gx_line+8, 564, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66nTMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 557, Gx_line+8, 629, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63nTJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 686, Gx_line+8, 758, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70nTSep, "ZZZZZZ,ZZZ,ZZ9.99")), 814, Gx_line+8, 886, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68nTOct, "ZZZZZZ,ZZZ,ZZ9.99")), 879, Gx_line+8, 951, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67nTNov, "ZZZZZZ,ZZZ,ZZ9.99")), 942, Gx_line+8, 1014, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60nTDic, "ZZZZZZ,ZZZ,ZZ9.99")), 1007, Gx_line+8, 1079, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(294, Gx_line+1, 1146, Gx_line+1, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71nTTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 1074, Gx_line+8, 1146, Gx_line+19, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 235, Gx_line+8, 291, Gx_line+18, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+25);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HBJ0( true, 0) ;
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
         /* 'MOVIMIENTOMES' Routine */
         returnInSub = false;
         /* Using cursor P00BJ3 */
         pr_default.execute(1, new Object[] {AV8Ano, AV45nCueCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A126TASICod = P00BJ3_A126TASICod[0];
            A129VouNum = P00BJ3_A129VouNum[0];
            A2077VouSts = P00BJ3_A2077VouSts[0];
            A128VouMes = P00BJ3_A128VouMes[0];
            A91CueCod = P00BJ3_A91CueCod[0];
            A127VouAno = P00BJ3_A127VouAno[0];
            A2055VouDHab = P00BJ3_A2055VouDHab[0];
            A2051VouDDeb = P00BJ3_A2051VouDDeb[0];
            A130VouDSec = P00BJ3_A130VouDSec[0];
            A2077VouSts = P00BJ3_A2077VouSts[0];
            AV48nEnero = (decimal)(AV48nEnero+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00BJ4 */
         pr_default.execute(2, new Object[] {AV8Ano, AV45nCueCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00BJ4_A126TASICod[0];
            A129VouNum = P00BJ4_A129VouNum[0];
            A2077VouSts = P00BJ4_A2077VouSts[0];
            A128VouMes = P00BJ4_A128VouMes[0];
            A91CueCod = P00BJ4_A91CueCod[0];
            A127VouAno = P00BJ4_A127VouAno[0];
            A2055VouDHab = P00BJ4_A2055VouDHab[0];
            A2051VouDDeb = P00BJ4_A2051VouDDeb[0];
            A130VouDSec = P00BJ4_A130VouDSec[0];
            A2077VouSts = P00BJ4_A2077VouSts[0];
            AV49nFebrero = (decimal)(AV49nFebrero+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor P00BJ5 */
         pr_default.execute(3, new Object[] {AV8Ano, AV45nCueCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A126TASICod = P00BJ5_A126TASICod[0];
            A129VouNum = P00BJ5_A129VouNum[0];
            A2077VouSts = P00BJ5_A2077VouSts[0];
            A128VouMes = P00BJ5_A128VouMes[0];
            A91CueCod = P00BJ5_A91CueCod[0];
            A127VouAno = P00BJ5_A127VouAno[0];
            A2055VouDHab = P00BJ5_A2055VouDHab[0];
            A2051VouDDeb = P00BJ5_A2051VouDDeb[0];
            A130VouDSec = P00BJ5_A130VouDSec[0];
            A2077VouSts = P00BJ5_A2077VouSts[0];
            AV52nMarzo = (decimal)(AV52nMarzo+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Using cursor P00BJ6 */
         pr_default.execute(4, new Object[] {AV8Ano, AV45nCueCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A126TASICod = P00BJ6_A126TASICod[0];
            A129VouNum = P00BJ6_A129VouNum[0];
            A2077VouSts = P00BJ6_A2077VouSts[0];
            A128VouMes = P00BJ6_A128VouMes[0];
            A91CueCod = P00BJ6_A91CueCod[0];
            A127VouAno = P00BJ6_A127VouAno[0];
            A2055VouDHab = P00BJ6_A2055VouDHab[0];
            A2051VouDDeb = P00BJ6_A2051VouDDeb[0];
            A130VouDSec = P00BJ6_A130VouDSec[0];
            A2077VouSts = P00BJ6_A2077VouSts[0];
            AV42nAbril = (decimal)(AV42nAbril+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /* Using cursor P00BJ7 */
         pr_default.execute(5, new Object[] {AV8Ano, AV45nCueCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A126TASICod = P00BJ7_A126TASICod[0];
            A129VouNum = P00BJ7_A129VouNum[0];
            A2077VouSts = P00BJ7_A2077VouSts[0];
            A128VouMes = P00BJ7_A128VouMes[0];
            A91CueCod = P00BJ7_A91CueCod[0];
            A127VouAno = P00BJ7_A127VouAno[0];
            A2055VouDHab = P00BJ7_A2055VouDHab[0];
            A2051VouDDeb = P00BJ7_A2051VouDDeb[0];
            A130VouDSec = P00BJ7_A130VouDSec[0];
            A2077VouSts = P00BJ7_A2077VouSts[0];
            AV53nMayo = (decimal)(AV53nMayo+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /* Using cursor P00BJ8 */
         pr_default.execute(6, new Object[] {AV8Ano, AV45nCueCod});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A126TASICod = P00BJ8_A126TASICod[0];
            A129VouNum = P00BJ8_A129VouNum[0];
            A2077VouSts = P00BJ8_A2077VouSts[0];
            A128VouMes = P00BJ8_A128VouMes[0];
            A91CueCod = P00BJ8_A91CueCod[0];
            A127VouAno = P00BJ8_A127VouAno[0];
            A2055VouDHab = P00BJ8_A2055VouDHab[0];
            A2051VouDDeb = P00BJ8_A2051VouDDeb[0];
            A130VouDSec = P00BJ8_A130VouDSec[0];
            A2077VouSts = P00BJ8_A2077VouSts[0];
            AV51nJunio = (decimal)(AV51nJunio+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(6);
         }
         pr_default.close(6);
         /* Using cursor P00BJ9 */
         pr_default.execute(7, new Object[] {AV8Ano, AV45nCueCod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A126TASICod = P00BJ9_A126TASICod[0];
            A129VouNum = P00BJ9_A129VouNum[0];
            A2077VouSts = P00BJ9_A2077VouSts[0];
            A128VouMes = P00BJ9_A128VouMes[0];
            A91CueCod = P00BJ9_A91CueCod[0];
            A127VouAno = P00BJ9_A127VouAno[0];
            A2055VouDHab = P00BJ9_A2055VouDHab[0];
            A2051VouDDeb = P00BJ9_A2051VouDDeb[0];
            A130VouDSec = P00BJ9_A130VouDSec[0];
            A2077VouSts = P00BJ9_A2077VouSts[0];
            AV50nJulio = (decimal)(AV50nJulio+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(7);
         }
         pr_default.close(7);
         /* Using cursor P00BJ10 */
         pr_default.execute(8, new Object[] {AV8Ano, AV45nCueCod});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A126TASICod = P00BJ10_A126TASICod[0];
            A129VouNum = P00BJ10_A129VouNum[0];
            A2077VouSts = P00BJ10_A2077VouSts[0];
            A128VouMes = P00BJ10_A128VouMes[0];
            A91CueCod = P00BJ10_A91CueCod[0];
            A127VouAno = P00BJ10_A127VouAno[0];
            A2055VouDHab = P00BJ10_A2055VouDHab[0];
            A2051VouDDeb = P00BJ10_A2051VouDDeb[0];
            A130VouDSec = P00BJ10_A130VouDSec[0];
            A2077VouSts = P00BJ10_A2077VouSts[0];
            AV43nAgosto = (decimal)(AV43nAgosto+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(8);
         }
         pr_default.close(8);
         /* Using cursor P00BJ11 */
         pr_default.execute(9, new Object[] {AV8Ano, AV45nCueCod});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A126TASICod = P00BJ11_A126TASICod[0];
            A129VouNum = P00BJ11_A129VouNum[0];
            A2077VouSts = P00BJ11_A2077VouSts[0];
            A128VouMes = P00BJ11_A128VouMes[0];
            A91CueCod = P00BJ11_A91CueCod[0];
            A127VouAno = P00BJ11_A127VouAno[0];
            A2055VouDHab = P00BJ11_A2055VouDHab[0];
            A2051VouDDeb = P00BJ11_A2051VouDDeb[0];
            A130VouDSec = P00BJ11_A130VouDSec[0];
            A2077VouSts = P00BJ11_A2077VouSts[0];
            AV56nSep = (decimal)(AV56nSep+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(9);
         }
         pr_default.close(9);
         /* Using cursor P00BJ12 */
         pr_default.execute(10, new Object[] {AV8Ano, AV45nCueCod});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A126TASICod = P00BJ12_A126TASICod[0];
            A129VouNum = P00BJ12_A129VouNum[0];
            A2077VouSts = P00BJ12_A2077VouSts[0];
            A128VouMes = P00BJ12_A128VouMes[0];
            A91CueCod = P00BJ12_A91CueCod[0];
            A127VouAno = P00BJ12_A127VouAno[0];
            A2055VouDHab = P00BJ12_A2055VouDHab[0];
            A2051VouDDeb = P00BJ12_A2051VouDDeb[0];
            A130VouDSec = P00BJ12_A130VouDSec[0];
            A2077VouSts = P00BJ12_A2077VouSts[0];
            AV55nOct = (decimal)(AV55nOct+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(10);
         }
         pr_default.close(10);
         /* Using cursor P00BJ13 */
         pr_default.execute(11, new Object[] {AV8Ano, AV45nCueCod});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A126TASICod = P00BJ13_A126TASICod[0];
            A129VouNum = P00BJ13_A129VouNum[0];
            A2077VouSts = P00BJ13_A2077VouSts[0];
            A128VouMes = P00BJ13_A128VouMes[0];
            A91CueCod = P00BJ13_A91CueCod[0];
            A127VouAno = P00BJ13_A127VouAno[0];
            A2055VouDHab = P00BJ13_A2055VouDHab[0];
            A2051VouDDeb = P00BJ13_A2051VouDDeb[0];
            A130VouDSec = P00BJ13_A130VouDSec[0];
            A2077VouSts = P00BJ13_A2077VouSts[0];
            AV54nNov = (decimal)(AV54nNov+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(11);
         }
         pr_default.close(11);
         /* Using cursor P00BJ14 */
         pr_default.execute(12, new Object[] {AV8Ano, AV45nCueCod});
         while ( (pr_default.getStatus(12) != 101) )
         {
            A126TASICod = P00BJ14_A126TASICod[0];
            A129VouNum = P00BJ14_A129VouNum[0];
            A2077VouSts = P00BJ14_A2077VouSts[0];
            A128VouMes = P00BJ14_A128VouMes[0];
            A91CueCod = P00BJ14_A91CueCod[0];
            A127VouAno = P00BJ14_A127VouAno[0];
            A2055VouDHab = P00BJ14_A2055VouDHab[0];
            A2051VouDDeb = P00BJ14_A2051VouDDeb[0];
            A130VouDSec = P00BJ14_A130VouDSec[0];
            A2077VouSts = P00BJ14_A2077VouSts[0];
            AV47nDic = (decimal)(AV47nDic+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(12);
         }
         pr_default.close(12);
         AV69nTotal = (decimal)(AV48nEnero+AV49nFebrero+AV52nMarzo+AV42nAbril+AV53nMayo+AV51nJunio+AV50nJulio+AV43nAgosto+AV56nSep+AV55nOct+AV54nNov+AV47nDic);
         HBJ0( false, 17) ;
         getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48nEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 300, Gx_line+2, 372, Gx_line+13, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51nJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 621, Gx_line+2, 693, Gx_line+13, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43nAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 750, Gx_line+2, 822, Gx_line+13, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49nFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 364, Gx_line+2, 436, Gx_line+13, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52nMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 427, Gx_line+2, 499, Gx_line+13, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42nAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 492, Gx_line+2, 564, Gx_line+13, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53nMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 557, Gx_line+2, 629, Gx_line+13, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50nJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 686, Gx_line+2, 758, Gx_line+13, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56nSep, "ZZZZZZ,ZZZ,ZZ9.99")), 814, Gx_line+2, 886, Gx_line+13, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55nOct, "ZZZZZZ,ZZZ,ZZ9.99")), 879, Gx_line+2, 951, Gx_line+13, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54nNov, "ZZZZZZ,ZZZ,ZZ9.99")), 942, Gx_line+2, 1014, Gx_line+13, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47nDic, "ZZZZZZ,ZZZ,ZZ9.99")), 1007, Gx_line+2, 1079, Gx_line+13, 2+256, 0, 0, 0) ;
         getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45nCueCod, "")), 1, Gx_line+2, 65, Gx_line+13, 0+256, 0, 0, 0) ;
         getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46nCueDsc, "")), 61, Gx_line+1, 290, Gx_line+12, 0, 0, 0, 0) ;
         getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69nTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 1074, Gx_line+2, 1146, Gx_line+13, 2+256, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+17);
      }

      protected void HBJ0( bool bFoot ,
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
         AV20Empresa = "";
         AV81Session = context.GetSession();
         AV19EmpDir = "";
         AV21EmpRUC = "";
         AV75Ruta = "";
         AV38Logo = "";
         AV102Logo_GXI = "";
         AV83Titulo = "";
         AV72Periodo = "";
         scmdbuf = "";
         P00BJ2_A133CueCodAux = new string[] {""} ;
         P00BJ2_A91CueCod = new string[] {""} ;
         P00BJ2_A127VouAno = new short[1] ;
         P00BJ2_A2053VouDDoc = new string[] {""} ;
         P00BJ2_A860CueDsc = new string[] {""} ;
         P00BJ2_A128VouMes = new short[1] ;
         P00BJ2_A126TASICod = new int[1] ;
         P00BJ2_A129VouNum = new string[] {""} ;
         P00BJ2_A130VouDSec = new int[1] ;
         A133CueCodAux = "";
         A91CueCod = "";
         A2053VouDDoc = "";
         A860CueDsc = "";
         A129VouNum = "";
         AV45nCueCod = "";
         AV46nCueDsc = "";
         P00BJ3_A126TASICod = new int[1] ;
         P00BJ3_A129VouNum = new string[] {""} ;
         P00BJ3_A2077VouSts = new short[1] ;
         P00BJ3_A128VouMes = new short[1] ;
         P00BJ3_A91CueCod = new string[] {""} ;
         P00BJ3_A127VouAno = new short[1] ;
         P00BJ3_A2055VouDHab = new decimal[1] ;
         P00BJ3_A2051VouDDeb = new decimal[1] ;
         P00BJ3_A130VouDSec = new int[1] ;
         P00BJ4_A126TASICod = new int[1] ;
         P00BJ4_A129VouNum = new string[] {""} ;
         P00BJ4_A2077VouSts = new short[1] ;
         P00BJ4_A128VouMes = new short[1] ;
         P00BJ4_A91CueCod = new string[] {""} ;
         P00BJ4_A127VouAno = new short[1] ;
         P00BJ4_A2055VouDHab = new decimal[1] ;
         P00BJ4_A2051VouDDeb = new decimal[1] ;
         P00BJ4_A130VouDSec = new int[1] ;
         P00BJ5_A126TASICod = new int[1] ;
         P00BJ5_A129VouNum = new string[] {""} ;
         P00BJ5_A2077VouSts = new short[1] ;
         P00BJ5_A128VouMes = new short[1] ;
         P00BJ5_A91CueCod = new string[] {""} ;
         P00BJ5_A127VouAno = new short[1] ;
         P00BJ5_A2055VouDHab = new decimal[1] ;
         P00BJ5_A2051VouDDeb = new decimal[1] ;
         P00BJ5_A130VouDSec = new int[1] ;
         P00BJ6_A126TASICod = new int[1] ;
         P00BJ6_A129VouNum = new string[] {""} ;
         P00BJ6_A2077VouSts = new short[1] ;
         P00BJ6_A128VouMes = new short[1] ;
         P00BJ6_A91CueCod = new string[] {""} ;
         P00BJ6_A127VouAno = new short[1] ;
         P00BJ6_A2055VouDHab = new decimal[1] ;
         P00BJ6_A2051VouDDeb = new decimal[1] ;
         P00BJ6_A130VouDSec = new int[1] ;
         P00BJ7_A126TASICod = new int[1] ;
         P00BJ7_A129VouNum = new string[] {""} ;
         P00BJ7_A2077VouSts = new short[1] ;
         P00BJ7_A128VouMes = new short[1] ;
         P00BJ7_A91CueCod = new string[] {""} ;
         P00BJ7_A127VouAno = new short[1] ;
         P00BJ7_A2055VouDHab = new decimal[1] ;
         P00BJ7_A2051VouDDeb = new decimal[1] ;
         P00BJ7_A130VouDSec = new int[1] ;
         P00BJ8_A126TASICod = new int[1] ;
         P00BJ8_A129VouNum = new string[] {""} ;
         P00BJ8_A2077VouSts = new short[1] ;
         P00BJ8_A128VouMes = new short[1] ;
         P00BJ8_A91CueCod = new string[] {""} ;
         P00BJ8_A127VouAno = new short[1] ;
         P00BJ8_A2055VouDHab = new decimal[1] ;
         P00BJ8_A2051VouDDeb = new decimal[1] ;
         P00BJ8_A130VouDSec = new int[1] ;
         P00BJ9_A126TASICod = new int[1] ;
         P00BJ9_A129VouNum = new string[] {""} ;
         P00BJ9_A2077VouSts = new short[1] ;
         P00BJ9_A128VouMes = new short[1] ;
         P00BJ9_A91CueCod = new string[] {""} ;
         P00BJ9_A127VouAno = new short[1] ;
         P00BJ9_A2055VouDHab = new decimal[1] ;
         P00BJ9_A2051VouDDeb = new decimal[1] ;
         P00BJ9_A130VouDSec = new int[1] ;
         P00BJ10_A126TASICod = new int[1] ;
         P00BJ10_A129VouNum = new string[] {""} ;
         P00BJ10_A2077VouSts = new short[1] ;
         P00BJ10_A128VouMes = new short[1] ;
         P00BJ10_A91CueCod = new string[] {""} ;
         P00BJ10_A127VouAno = new short[1] ;
         P00BJ10_A2055VouDHab = new decimal[1] ;
         P00BJ10_A2051VouDDeb = new decimal[1] ;
         P00BJ10_A130VouDSec = new int[1] ;
         P00BJ11_A126TASICod = new int[1] ;
         P00BJ11_A129VouNum = new string[] {""} ;
         P00BJ11_A2077VouSts = new short[1] ;
         P00BJ11_A128VouMes = new short[1] ;
         P00BJ11_A91CueCod = new string[] {""} ;
         P00BJ11_A127VouAno = new short[1] ;
         P00BJ11_A2055VouDHab = new decimal[1] ;
         P00BJ11_A2051VouDDeb = new decimal[1] ;
         P00BJ11_A130VouDSec = new int[1] ;
         P00BJ12_A126TASICod = new int[1] ;
         P00BJ12_A129VouNum = new string[] {""} ;
         P00BJ12_A2077VouSts = new short[1] ;
         P00BJ12_A128VouMes = new short[1] ;
         P00BJ12_A91CueCod = new string[] {""} ;
         P00BJ12_A127VouAno = new short[1] ;
         P00BJ12_A2055VouDHab = new decimal[1] ;
         P00BJ12_A2051VouDDeb = new decimal[1] ;
         P00BJ12_A130VouDSec = new int[1] ;
         P00BJ13_A126TASICod = new int[1] ;
         P00BJ13_A129VouNum = new string[] {""} ;
         P00BJ13_A2077VouSts = new short[1] ;
         P00BJ13_A128VouMes = new short[1] ;
         P00BJ13_A91CueCod = new string[] {""} ;
         P00BJ13_A127VouAno = new short[1] ;
         P00BJ13_A2055VouDHab = new decimal[1] ;
         P00BJ13_A2051VouDDeb = new decimal[1] ;
         P00BJ13_A130VouDSec = new int[1] ;
         P00BJ14_A126TASICod = new int[1] ;
         P00BJ14_A129VouNum = new string[] {""} ;
         P00BJ14_A2077VouSts = new short[1] ;
         P00BJ14_A128VouMes = new short[1] ;
         P00BJ14_A91CueCod = new string[] {""} ;
         P00BJ14_A127VouAno = new short[1] ;
         P00BJ14_A2055VouDHab = new decimal[1] ;
         P00BJ14_A2051VouDDeb = new decimal[1] ;
         P00BJ14_A130VouDSec = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_resumencuentasanualpdf__default(),
            new Object[][] {
                new Object[] {
               P00BJ2_A133CueCodAux, P00BJ2_A91CueCod, P00BJ2_A127VouAno, P00BJ2_A2053VouDDoc, P00BJ2_A860CueDsc, P00BJ2_A128VouMes, P00BJ2_A126TASICod, P00BJ2_A129VouNum, P00BJ2_A130VouDSec
               }
               , new Object[] {
               P00BJ3_A126TASICod, P00BJ3_A129VouNum, P00BJ3_A2077VouSts, P00BJ3_A128VouMes, P00BJ3_A91CueCod, P00BJ3_A127VouAno, P00BJ3_A2055VouDHab, P00BJ3_A2051VouDDeb, P00BJ3_A130VouDSec
               }
               , new Object[] {
               P00BJ4_A126TASICod, P00BJ4_A129VouNum, P00BJ4_A2077VouSts, P00BJ4_A128VouMes, P00BJ4_A91CueCod, P00BJ4_A127VouAno, P00BJ4_A2055VouDHab, P00BJ4_A2051VouDDeb, P00BJ4_A130VouDSec
               }
               , new Object[] {
               P00BJ5_A126TASICod, P00BJ5_A129VouNum, P00BJ5_A2077VouSts, P00BJ5_A128VouMes, P00BJ5_A91CueCod, P00BJ5_A127VouAno, P00BJ5_A2055VouDHab, P00BJ5_A2051VouDDeb, P00BJ5_A130VouDSec
               }
               , new Object[] {
               P00BJ6_A126TASICod, P00BJ6_A129VouNum, P00BJ6_A2077VouSts, P00BJ6_A128VouMes, P00BJ6_A91CueCod, P00BJ6_A127VouAno, P00BJ6_A2055VouDHab, P00BJ6_A2051VouDDeb, P00BJ6_A130VouDSec
               }
               , new Object[] {
               P00BJ7_A126TASICod, P00BJ7_A129VouNum, P00BJ7_A2077VouSts, P00BJ7_A128VouMes, P00BJ7_A91CueCod, P00BJ7_A127VouAno, P00BJ7_A2055VouDHab, P00BJ7_A2051VouDDeb, P00BJ7_A130VouDSec
               }
               , new Object[] {
               P00BJ8_A126TASICod, P00BJ8_A129VouNum, P00BJ8_A2077VouSts, P00BJ8_A128VouMes, P00BJ8_A91CueCod, P00BJ8_A127VouAno, P00BJ8_A2055VouDHab, P00BJ8_A2051VouDDeb, P00BJ8_A130VouDSec
               }
               , new Object[] {
               P00BJ9_A126TASICod, P00BJ9_A129VouNum, P00BJ9_A2077VouSts, P00BJ9_A128VouMes, P00BJ9_A91CueCod, P00BJ9_A127VouAno, P00BJ9_A2055VouDHab, P00BJ9_A2051VouDDeb, P00BJ9_A130VouDSec
               }
               , new Object[] {
               P00BJ10_A126TASICod, P00BJ10_A129VouNum, P00BJ10_A2077VouSts, P00BJ10_A128VouMes, P00BJ10_A91CueCod, P00BJ10_A127VouAno, P00BJ10_A2055VouDHab, P00BJ10_A2051VouDDeb, P00BJ10_A130VouDSec
               }
               , new Object[] {
               P00BJ11_A126TASICod, P00BJ11_A129VouNum, P00BJ11_A2077VouSts, P00BJ11_A128VouMes, P00BJ11_A91CueCod, P00BJ11_A127VouAno, P00BJ11_A2055VouDHab, P00BJ11_A2051VouDDeb, P00BJ11_A130VouDSec
               }
               , new Object[] {
               P00BJ12_A126TASICod, P00BJ12_A129VouNum, P00BJ12_A2077VouSts, P00BJ12_A128VouMes, P00BJ12_A91CueCod, P00BJ12_A127VouAno, P00BJ12_A2055VouDHab, P00BJ12_A2051VouDDeb, P00BJ12_A130VouDSec
               }
               , new Object[] {
               P00BJ13_A126TASICod, P00BJ13_A129VouNum, P00BJ13_A2077VouSts, P00BJ13_A128VouMes, P00BJ13_A91CueCod, P00BJ13_A127VouAno, P00BJ13_A2055VouDHab, P00BJ13_A2051VouDDeb, P00BJ13_A130VouDSec
               }
               , new Object[] {
               P00BJ14_A126TASICod, P00BJ14_A129VouNum, P00BJ14_A2077VouSts, P00BJ14_A128VouMes, P00BJ14_A91CueCod, P00BJ14_A127VouAno, P00BJ14_A2055VouDHab, P00BJ14_A2051VouDDeb, P00BJ14_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV8Ano ;
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
      private decimal AV48nEnero ;
      private decimal AV49nFebrero ;
      private decimal AV52nMarzo ;
      private decimal AV42nAbril ;
      private decimal AV53nMayo ;
      private decimal AV51nJunio ;
      private decimal AV50nJulio ;
      private decimal AV43nAgosto ;
      private decimal AV56nSep ;
      private decimal AV55nOct ;
      private decimal AV54nNov ;
      private decimal AV47nDic ;
      private decimal AV69nTotal ;
      private decimal AV61nTEnero ;
      private decimal AV62nTFebrero ;
      private decimal AV65nTMarzo ;
      private decimal AV57nTAbril ;
      private decimal AV66nTMayo ;
      private decimal AV64nTJunio ;
      private decimal AV63nTJulio ;
      private decimal AV58nTAgosto ;
      private decimal AV70nTSep ;
      private decimal AV68nTOct ;
      private decimal AV67nTNov ;
      private decimal AV60nTDic ;
      private decimal AV71nTTotal ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV15Cuenta1 ;
      private string AV16Cuenta2 ;
      private string AV20Empresa ;
      private string AV19EmpDir ;
      private string AV21EmpRUC ;
      private string AV75Ruta ;
      private string AV83Titulo ;
      private string AV72Periodo ;
      private string scmdbuf ;
      private string A133CueCodAux ;
      private string A91CueCod ;
      private string A2053VouDDoc ;
      private string A860CueDsc ;
      private string A129VouNum ;
      private string AV45nCueCod ;
      private string AV46nCueDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKBJ2 ;
      private bool returnInSub ;
      private string AV102Logo_GXI ;
      private string AV38Logo ;
      private IGxSession AV81Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private string aP1_Cuenta1 ;
      private string aP2_Cuenta2 ;
      private IDataStoreProvider pr_default ;
      private string[] P00BJ2_A133CueCodAux ;
      private string[] P00BJ2_A91CueCod ;
      private short[] P00BJ2_A127VouAno ;
      private string[] P00BJ2_A2053VouDDoc ;
      private string[] P00BJ2_A860CueDsc ;
      private short[] P00BJ2_A128VouMes ;
      private int[] P00BJ2_A126TASICod ;
      private string[] P00BJ2_A129VouNum ;
      private int[] P00BJ2_A130VouDSec ;
      private int[] P00BJ3_A126TASICod ;
      private string[] P00BJ3_A129VouNum ;
      private short[] P00BJ3_A2077VouSts ;
      private short[] P00BJ3_A128VouMes ;
      private string[] P00BJ3_A91CueCod ;
      private short[] P00BJ3_A127VouAno ;
      private decimal[] P00BJ3_A2055VouDHab ;
      private decimal[] P00BJ3_A2051VouDDeb ;
      private int[] P00BJ3_A130VouDSec ;
      private int[] P00BJ4_A126TASICod ;
      private string[] P00BJ4_A129VouNum ;
      private short[] P00BJ4_A2077VouSts ;
      private short[] P00BJ4_A128VouMes ;
      private string[] P00BJ4_A91CueCod ;
      private short[] P00BJ4_A127VouAno ;
      private decimal[] P00BJ4_A2055VouDHab ;
      private decimal[] P00BJ4_A2051VouDDeb ;
      private int[] P00BJ4_A130VouDSec ;
      private int[] P00BJ5_A126TASICod ;
      private string[] P00BJ5_A129VouNum ;
      private short[] P00BJ5_A2077VouSts ;
      private short[] P00BJ5_A128VouMes ;
      private string[] P00BJ5_A91CueCod ;
      private short[] P00BJ5_A127VouAno ;
      private decimal[] P00BJ5_A2055VouDHab ;
      private decimal[] P00BJ5_A2051VouDDeb ;
      private int[] P00BJ5_A130VouDSec ;
      private int[] P00BJ6_A126TASICod ;
      private string[] P00BJ6_A129VouNum ;
      private short[] P00BJ6_A2077VouSts ;
      private short[] P00BJ6_A128VouMes ;
      private string[] P00BJ6_A91CueCod ;
      private short[] P00BJ6_A127VouAno ;
      private decimal[] P00BJ6_A2055VouDHab ;
      private decimal[] P00BJ6_A2051VouDDeb ;
      private int[] P00BJ6_A130VouDSec ;
      private int[] P00BJ7_A126TASICod ;
      private string[] P00BJ7_A129VouNum ;
      private short[] P00BJ7_A2077VouSts ;
      private short[] P00BJ7_A128VouMes ;
      private string[] P00BJ7_A91CueCod ;
      private short[] P00BJ7_A127VouAno ;
      private decimal[] P00BJ7_A2055VouDHab ;
      private decimal[] P00BJ7_A2051VouDDeb ;
      private int[] P00BJ7_A130VouDSec ;
      private int[] P00BJ8_A126TASICod ;
      private string[] P00BJ8_A129VouNum ;
      private short[] P00BJ8_A2077VouSts ;
      private short[] P00BJ8_A128VouMes ;
      private string[] P00BJ8_A91CueCod ;
      private short[] P00BJ8_A127VouAno ;
      private decimal[] P00BJ8_A2055VouDHab ;
      private decimal[] P00BJ8_A2051VouDDeb ;
      private int[] P00BJ8_A130VouDSec ;
      private int[] P00BJ9_A126TASICod ;
      private string[] P00BJ9_A129VouNum ;
      private short[] P00BJ9_A2077VouSts ;
      private short[] P00BJ9_A128VouMes ;
      private string[] P00BJ9_A91CueCod ;
      private short[] P00BJ9_A127VouAno ;
      private decimal[] P00BJ9_A2055VouDHab ;
      private decimal[] P00BJ9_A2051VouDDeb ;
      private int[] P00BJ9_A130VouDSec ;
      private int[] P00BJ10_A126TASICod ;
      private string[] P00BJ10_A129VouNum ;
      private short[] P00BJ10_A2077VouSts ;
      private short[] P00BJ10_A128VouMes ;
      private string[] P00BJ10_A91CueCod ;
      private short[] P00BJ10_A127VouAno ;
      private decimal[] P00BJ10_A2055VouDHab ;
      private decimal[] P00BJ10_A2051VouDDeb ;
      private int[] P00BJ10_A130VouDSec ;
      private int[] P00BJ11_A126TASICod ;
      private string[] P00BJ11_A129VouNum ;
      private short[] P00BJ11_A2077VouSts ;
      private short[] P00BJ11_A128VouMes ;
      private string[] P00BJ11_A91CueCod ;
      private short[] P00BJ11_A127VouAno ;
      private decimal[] P00BJ11_A2055VouDHab ;
      private decimal[] P00BJ11_A2051VouDDeb ;
      private int[] P00BJ11_A130VouDSec ;
      private int[] P00BJ12_A126TASICod ;
      private string[] P00BJ12_A129VouNum ;
      private short[] P00BJ12_A2077VouSts ;
      private short[] P00BJ12_A128VouMes ;
      private string[] P00BJ12_A91CueCod ;
      private short[] P00BJ12_A127VouAno ;
      private decimal[] P00BJ12_A2055VouDHab ;
      private decimal[] P00BJ12_A2051VouDDeb ;
      private int[] P00BJ12_A130VouDSec ;
      private int[] P00BJ13_A126TASICod ;
      private string[] P00BJ13_A129VouNum ;
      private short[] P00BJ13_A2077VouSts ;
      private short[] P00BJ13_A128VouMes ;
      private string[] P00BJ13_A91CueCod ;
      private short[] P00BJ13_A127VouAno ;
      private decimal[] P00BJ13_A2055VouDHab ;
      private decimal[] P00BJ13_A2051VouDDeb ;
      private int[] P00BJ13_A130VouDSec ;
      private int[] P00BJ14_A126TASICod ;
      private string[] P00BJ14_A129VouNum ;
      private short[] P00BJ14_A2077VouSts ;
      private short[] P00BJ14_A128VouMes ;
      private string[] P00BJ14_A91CueCod ;
      private short[] P00BJ14_A127VouAno ;
      private decimal[] P00BJ14_A2055VouDHab ;
      private decimal[] P00BJ14_A2051VouDDeb ;
      private int[] P00BJ14_A130VouDSec ;
   }

   public class r_resumencuentasanualpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BJ2;
          prmP00BJ2 = new Object[] {
          new ParDef("@AV15Cuenta1",GXType.Char,15,0) ,
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV16Cuenta2",GXType.Char,15,0)
          };
          Object[] prmP00BJ3;
          prmP00BJ3 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV45nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BJ4;
          prmP00BJ4 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV45nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BJ5;
          prmP00BJ5 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV45nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BJ6;
          prmP00BJ6 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV45nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BJ7;
          prmP00BJ7 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV45nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BJ8;
          prmP00BJ8 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV45nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BJ9;
          prmP00BJ9 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV45nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BJ10;
          prmP00BJ10 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV45nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BJ11;
          prmP00BJ11 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV45nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BJ12;
          prmP00BJ12 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV45nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BJ13;
          prmP00BJ13 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV45nCueCod",GXType.NChar,15,0)
          };
          Object[] prmP00BJ14;
          prmP00BJ14 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV45nCueCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BJ2", "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouAno], T1.[VouDDoc], T2.[CueDsc], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE (T1.[CueCod] >= @AV15Cuenta1) AND (T1.[VouAno] = @AV8Ano) AND (T1.[CueCod] <= @AV16Cuenta2) ORDER BY T1.[CueCod], T1.[CueCodAux] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BJ3", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 1 and T1.[CueCod] = @AV45nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BJ4", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 2 and T1.[CueCod] = @AV45nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BJ5", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 3 and T1.[CueCod] = @AV45nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BJ6", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 4 and T1.[CueCod] = @AV45nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BJ7", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 5 and T1.[CueCod] = @AV45nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BJ8", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 6 and T1.[CueCod] = @AV45nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BJ9", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 7 and T1.[CueCod] = @AV45nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BJ10", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 8 and T1.[CueCod] = @AV45nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ10,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BJ11", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 9 and T1.[CueCod] = @AV45nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BJ12", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 10 and T1.[CueCod] = @AV45nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ12,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BJ13", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 11 and T1.[CueCod] = @AV45nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ13,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BJ14", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[CueCod], T1.[VouAno], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV8Ano and T1.[VouMes] = 12 and T1.[CueCod] = @AV45nCueCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ14,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 10);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
