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
   public class rrlibro4_1 : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.rrlibro4_1.aspx")), "contabilidad.rrlibro4_1.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.rrlibro4_1.aspx")))) ;
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

      public rrlibro4_1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrlibro4_1( IGxContext context )
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
         rrlibro4_1 objrrlibro4_1;
         objrrlibro4_1 = new rrlibro4_1();
         objrrlibro4_1.AV11Ano = aP0_Ano;
         objrrlibro4_1.AV12Mes = aP1_Mes;
         objrrlibro4_1.context.SetSubmitInitialConfig(context);
         objrrlibro4_1.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrlibro4_1);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrlibro4_1)stateInfo).executePrivate();
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
            AV52EmpRUC = AV30Session.Get("EmpRUC");
            AV54Ruta = AV30Session.Get("RUTA") + "/Logo.jpg";
            AV53Logo = AV54Ruta;
            AV98Logo_GXI = GXDbFile.PathToUrl( AV54Ruta);
            AV51FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV16FechaD = context.localUtil.CToD( AV51FechaC, 2);
            GXt_char1 = AV50cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
            AV50cMes = GXt_char1;
            AV13Titulo = "REGISTRO DEL REGIMEN DE RETENCIONES DEL IGV";
            AV14Periodo = StringUtil.Upper( AV50cMes) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV47TDebeMO = 0.00m;
            AV48ThaberMO = 0.00m;
            AV92Total1 = 0.00m;
            AV93Total2 = 0.00m;
            AV94Total3 = 0.00m;
            /* Using cursor P009O2 */
            pr_default.execute(0, new Object[] {AV11Ano, AV12Mes});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK9O3 = false;
               A244PrvCod = P009O2_A244PrvCod[0];
               A304CPRetTipCod = P009O2_A304CPRetTipCod[0];
               A847CPRetSts = P009O2_A847CPRetSts[0];
               A834CPRetFec = P009O2_A834CPRetFec[0];
               A303CPRetPrvCod = P009O2_A303CPRetPrvCod[0];
               A302CPRetCod = P009O2_A302CPRetCod[0];
               A264CPFech = P009O2_A264CPFech[0];
               n264CPFech = P009O2_n264CPFech[0];
               A817CPFVcto = P009O2_A817CPFVcto[0];
               n817CPFVcto = P009O2_n817CPFVcto[0];
               A849CPRetTipAbr = P009O2_A849CPRetTipAbr[0];
               A305CPRetComCod = P009O2_A305CPRetComCod[0];
               A247PrvDsc = P009O2_A247PrvDsc[0];
               A843CPRetRet = P009O2_A843CPRetRet[0];
               A840CPRetTipCmb = P009O2_A840CPRetTipCmb[0];
               A839CPRetTotal = P009O2_A839CPRetTotal[0];
               A833CPRetComMon = P009O2_A833CPRetComMon[0];
               A849CPRetTipAbr = P009O2_A849CPRetTipAbr[0];
               A244PrvCod = P009O2_A244PrvCod[0];
               A847CPRetSts = P009O2_A847CPRetSts[0];
               A834CPRetFec = P009O2_A834CPRetFec[0];
               A840CPRetTipCmb = P009O2_A840CPRetTipCmb[0];
               A247PrvDsc = P009O2_A247PrvDsc[0];
               A264CPFech = P009O2_A264CPFech[0];
               n264CPFech = P009O2_n264CPFech[0];
               A817CPFVcto = P009O2_A817CPFVcto[0];
               n817CPFVcto = P009O2_n817CPFVcto[0];
               A833CPRetComMon = P009O2_A833CPRetComMon[0];
               A838CPRetTotalMN = ((A833CPRetComMon==2) ? NumberUtil.Round( A839CPRetTotal*A840CPRetTipCmb, 2) : A839CPRetTotal);
               A842CPRetRetMN = ((A833CPRetComMon==2) ? NumberUtil.Round( A843CPRetRet*A840CPRetTipCmb, 2) : A843CPRetRet);
               AV79PrvDsc = StringUtil.Trim( A303CPRetPrvCod) + " " + StringUtil.Trim( A247PrvDsc);
               AV95Proveedor = "Total : " + StringUtil.Trim( A247PrvDsc);
               AV88CPRetPrvCod = A303CPRetPrvCod;
               AV89TotalProv1 = 0.00m;
               AV90TotalProv2 = 0.00m;
               AV91TotalProv3 = 0.00m;
               H9O0( false, 21) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79PrvDsc, "")), 63, Gx_line+3, 585, Gx_line+18, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P009O2_A303CPRetPrvCod[0], A303CPRetPrvCod) == 0 ) )
               {
                  BRK9O3 = false;
                  A304CPRetTipCod = P009O2_A304CPRetTipCod[0];
                  A847CPRetSts = P009O2_A847CPRetSts[0];
                  A834CPRetFec = P009O2_A834CPRetFec[0];
                  A302CPRetCod = P009O2_A302CPRetCod[0];
                  A264CPFech = P009O2_A264CPFech[0];
                  n264CPFech = P009O2_n264CPFech[0];
                  A817CPFVcto = P009O2_A817CPFVcto[0];
                  n817CPFVcto = P009O2_n817CPFVcto[0];
                  A849CPRetTipAbr = P009O2_A849CPRetTipAbr[0];
                  A305CPRetComCod = P009O2_A305CPRetComCod[0];
                  A843CPRetRet = P009O2_A843CPRetRet[0];
                  A840CPRetTipCmb = P009O2_A840CPRetTipCmb[0];
                  A839CPRetTotal = P009O2_A839CPRetTotal[0];
                  A833CPRetComMon = P009O2_A833CPRetComMon[0];
                  A849CPRetTipAbr = P009O2_A849CPRetTipAbr[0];
                  A847CPRetSts = P009O2_A847CPRetSts[0];
                  A834CPRetFec = P009O2_A834CPRetFec[0];
                  A840CPRetTipCmb = P009O2_A840CPRetTipCmb[0];
                  A264CPFech = P009O2_A264CPFech[0];
                  n264CPFech = P009O2_n264CPFech[0];
                  A817CPFVcto = P009O2_A817CPFVcto[0];
                  n817CPFVcto = P009O2_n817CPFVcto[0];
                  A833CPRetComMon = P009O2_A833CPRetComMon[0];
                  if ( DateTimeUtil.Year( A834CPRetFec) == AV11Ano )
                  {
                     if ( DateTimeUtil.Month( A834CPRetFec) == AV12Mes )
                     {
                        if ( StringUtil.StrCmp(A847CPRetSts, "A") != 0 )
                        {
                           if ( StringUtil.StrCmp(A303CPRetPrvCod, AV88CPRetPrvCod) == 0 )
                           {
                              A838CPRetTotalMN = ((A833CPRetComMon==2) ? NumberUtil.Round( A839CPRetTotal*A840CPRetTipCmb, 2) : A839CPRetTotal);
                              A842CPRetRetMN = ((A833CPRetComMon==2) ? NumberUtil.Round( A843CPRetRet*A840CPRetTipCmb, 2) : A843CPRetRet);
                              AV77CPRetCod = A302CPRetCod;
                              AV78CPRetFec = A834CPRetFec;
                              AV84CPFech = A264CPFech;
                              AV85CPFVcto = A817CPFVcto;
                              AV83TipAbr = A849CPRetTipAbr;
                              AV82CPRetComCod = A305CPRetComCod;
                              AV86CPRetTotalMN = A838CPRetTotalMN;
                              AV87CPRetRetMN = A842CPRetRetMN;
                              AV74Saldo = (decimal)(AV86CPRetTotalMN-AV87CPRetRetMN);
                              H9O0( false, 17) ;
                              getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(context.localUtil.Format( AV78CPRetFec, "99/99/99"), 66, Gx_line+1, 113, Gx_line+16, 0+256, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77CPRetCod, "")), 145, Gx_line+1, 198, Gx_line+16, 0+256, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV86CPRetTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 635, Gx_line+1, 742, Gx_line+16, 2+256, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87CPRetRetMN, "ZZZZZZ,ZZZ,ZZ9.99")), 754, Gx_line+1, 861, Gx_line+16, 2+256, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV74Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 868, Gx_line+1, 975, Gx_line+16, 2+256, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83TipAbr, "")), 253, Gx_line+1, 306, Gx_line+16, 1+256, 0, 0, 0) ;
                              getPrinter().GxDrawText(context.localUtil.Format( AV84CPFech, "99/99/99"), 458, Gx_line+1, 505, Gx_line+16, 0+256, 0, 0, 0) ;
                              getPrinter().GxDrawText(context.localUtil.Format( AV85CPFVcto, "99/99/99"), 558, Gx_line+1, 605, Gx_line+16, 0+256, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82CPRetComCod, "")), 335, Gx_line+1, 414, Gx_line+16, 0+256, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+17);
                              AV89TotalProv1 = (decimal)(AV89TotalProv1+AV86CPRetTotalMN);
                              AV90TotalProv2 = (decimal)(AV90TotalProv2+AV87CPRetRetMN);
                              AV91TotalProv3 = (decimal)(AV91TotalProv3+AV74Saldo);
                           }
                        }
                     }
                  }
                  BRK9O3 = true;
                  pr_default.readNext(0);
               }
               H9O0( false, 40) ;
               getPrinter().GxDrawLine(627, Gx_line+5, 980, Gx_line+5, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89TotalProv1, "ZZZZZZ,ZZZ,ZZ9.99")), 635, Gx_line+13, 742, Gx_line+28, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV90TotalProv2, "ZZZZZZ,ZZZ,ZZ9.99")), 754, Gx_line+13, 861, Gx_line+28, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV91TotalProv3, "ZZZZZZ,ZZZ,ZZ9.99")), 868, Gx_line+13, 975, Gx_line+28, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95Proveedor, "")), 98, Gx_line+13, 620, Gx_line+28, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               AV92Total1 = (decimal)(AV92Total1+AV89TotalProv1);
               AV93Total2 = (decimal)(AV93Total2+AV90TotalProv2);
               AV94Total3 = (decimal)(AV94Total3+AV91TotalProv3);
               if ( ! BRK9O3 )
               {
                  BRK9O3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            H9O0( false, 58) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General :", 508, Gx_line+19, 594, Gx_line+33, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(627, Gx_line+11, 980, Gx_line+11, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV92Total1, "ZZZZZZ,ZZZ,ZZ9.99")), 635, Gx_line+19, 742, Gx_line+34, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV93Total2, "ZZZZZZ,ZZZ,ZZ9.99")), 754, Gx_line+19, 861, Gx_line+34, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV94Total3, "ZZZZZZ,ZZZ,ZZ9.99")), 868, Gx_line+19, 975, Gx_line+34, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+58);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9O0( true, 0) ;
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

      protected void H9O0( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 895, Gx_line+21, 939, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 941, Gx_line+21, 980, Gx_line+36, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 67, Gx_line+14, 568, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 141, Gx_line+50, 767, Gx_line+68, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 486, Gx_line+88, 891, Gx_line+105, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52EmpRUC, "")), 141, Gx_line+68, 267, Gx_line+86, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PERIODO:", 67, Gx_line+50, 132, Gx_line+68, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RUC :", 67, Gx_line+68, 103, Gx_line+86, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("APELLIDOS Y NOMBRES, DENOMINACIÓN O RAZON SOCIAL :", 67, Gx_line+86, 456, Gx_line+104, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+111);
               getPrinter().GxDrawLine(135, Gx_line+0, 135, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(632, Gx_line+1, 632, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("MONTO", 669, Gx_line+30, 712, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(54, Gx_line+0, 978, Gx_line+65, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("BRUTO", 670, Gx_line+46, 711, Gx_line+60, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(317, Gx_line+26, 317, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(752, Gx_line+26, 752, Gx_line+64, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("INFORMACION DEL DOCUMENTO", 336, Gx_line+5, 518, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FECHA DE", 73, Gx_line+6, 128, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(243, Gx_line+25, 977, Gx_line+25, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("EFECTUADA", 777, Gx_line+46, 845, Gx_line+60, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RETENCION", 778, Gx_line+30, 843, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(868, Gx_line+25, 868, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("MONTO", 897, Gx_line+30, 940, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("MONTO DE RETENCIÓN", 738, Gx_line+5, 865, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("PAGO O", 78, Gx_line+24, 123, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RETENCION", 68, Gx_line+43, 133, Gx_line+57, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("NETO", 903, Gx_line+46, 933, Gx_line+60, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(241, Gx_line+0, 241, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("COMPROBANTE", 144, Gx_line+6, 231, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DE", 180, Gx_line+24, 196, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RETENCIÓN", 155, Gx_line+43, 220, Gx_line+57, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("T/D", 271, Gx_line+38, 294, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(438, Gx_line+26, 438, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N° DOCUMENTO", 336, Gx_line+38, 426, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(536, Gx_line+26, 536, Gx_line+65, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("FECHA EMISIÓN", 443, Gx_line+38, 534, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FECHA VCTO.", 547, Gx_line+38, 621, Gx_line+52, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+65);
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
         AV52EmpRUC = "";
         AV54Ruta = "";
         AV53Logo = "";
         AV98Logo_GXI = "";
         AV51FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV50cMes = "";
         GXt_char1 = "";
         AV13Titulo = "";
         AV14Periodo = "";
         scmdbuf = "";
         P009O2_A244PrvCod = new string[] {""} ;
         P009O2_A304CPRetTipCod = new string[] {""} ;
         P009O2_A847CPRetSts = new string[] {""} ;
         P009O2_A834CPRetFec = new DateTime[] {DateTime.MinValue} ;
         P009O2_A303CPRetPrvCod = new string[] {""} ;
         P009O2_A302CPRetCod = new string[] {""} ;
         P009O2_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P009O2_n264CPFech = new bool[] {false} ;
         P009O2_A817CPFVcto = new DateTime[] {DateTime.MinValue} ;
         P009O2_n817CPFVcto = new bool[] {false} ;
         P009O2_A849CPRetTipAbr = new string[] {""} ;
         P009O2_A305CPRetComCod = new string[] {""} ;
         P009O2_A247PrvDsc = new string[] {""} ;
         P009O2_A843CPRetRet = new decimal[1] ;
         P009O2_A840CPRetTipCmb = new decimal[1] ;
         P009O2_A839CPRetTotal = new decimal[1] ;
         P009O2_A833CPRetComMon = new int[1] ;
         A244PrvCod = "";
         A304CPRetTipCod = "";
         A847CPRetSts = "";
         A834CPRetFec = DateTime.MinValue;
         A303CPRetPrvCod = "";
         A302CPRetCod = "";
         A264CPFech = DateTime.MinValue;
         A817CPFVcto = DateTime.MinValue;
         A849CPRetTipAbr = "";
         A305CPRetComCod = "";
         A247PrvDsc = "";
         AV79PrvDsc = "";
         AV95Proveedor = "";
         AV88CPRetPrvCod = "";
         AV77CPRetCod = "";
         AV78CPRetFec = DateTime.MinValue;
         AV84CPFech = DateTime.MinValue;
         AV85CPFVcto = DateTime.MinValue;
         AV83TipAbr = "";
         AV82CPRetComCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rrlibro4_1__default(),
            new Object[][] {
                new Object[] {
               P009O2_A244PrvCod, P009O2_A304CPRetTipCod, P009O2_A847CPRetSts, P009O2_A834CPRetFec, P009O2_A303CPRetPrvCod, P009O2_A302CPRetCod, P009O2_A264CPFech, P009O2_n264CPFech, P009O2_A817CPFVcto, P009O2_n817CPFVcto,
               P009O2_A849CPRetTipAbr, P009O2_A305CPRetComCod, P009O2_A247PrvDsc, P009O2_A843CPRetRet, P009O2_A840CPRetTipCmb, P009O2_A839CPRetTotal, P009O2_A833CPRetComMon
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
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A833CPRetComMon ;
      private int Gx_OldLine ;
      private decimal AV47TDebeMO ;
      private decimal AV48ThaberMO ;
      private decimal AV92Total1 ;
      private decimal AV93Total2 ;
      private decimal AV94Total3 ;
      private decimal A843CPRetRet ;
      private decimal A840CPRetTipCmb ;
      private decimal A839CPRetTotal ;
      private decimal A838CPRetTotalMN ;
      private decimal A842CPRetRetMN ;
      private decimal AV89TotalProv1 ;
      private decimal AV90TotalProv2 ;
      private decimal AV91TotalProv3 ;
      private decimal AV86CPRetTotalMN ;
      private decimal AV87CPRetRetMN ;
      private decimal AV74Saldo ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV27Empresa ;
      private string AV28EmpDir ;
      private string AV52EmpRUC ;
      private string AV54Ruta ;
      private string AV51FechaC ;
      private string AV50cMes ;
      private string GXt_char1 ;
      private string AV13Titulo ;
      private string AV14Periodo ;
      private string scmdbuf ;
      private string A244PrvCod ;
      private string A304CPRetTipCod ;
      private string A847CPRetSts ;
      private string A303CPRetPrvCod ;
      private string A302CPRetCod ;
      private string A849CPRetTipAbr ;
      private string A305CPRetComCod ;
      private string A247PrvDsc ;
      private string AV79PrvDsc ;
      private string AV95Proveedor ;
      private string AV88CPRetPrvCod ;
      private string AV77CPRetCod ;
      private string AV83TipAbr ;
      private string AV82CPRetComCod ;
      private DateTime AV16FechaD ;
      private DateTime A834CPRetFec ;
      private DateTime A264CPFech ;
      private DateTime A817CPFVcto ;
      private DateTime AV78CPRetFec ;
      private DateTime AV84CPFech ;
      private DateTime AV85CPFVcto ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK9O3 ;
      private bool n264CPFech ;
      private bool n817CPFVcto ;
      private string AV98Logo_GXI ;
      private string AV53Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private IDataStoreProvider pr_default ;
      private string[] P009O2_A244PrvCod ;
      private string[] P009O2_A304CPRetTipCod ;
      private string[] P009O2_A847CPRetSts ;
      private DateTime[] P009O2_A834CPRetFec ;
      private string[] P009O2_A303CPRetPrvCod ;
      private string[] P009O2_A302CPRetCod ;
      private DateTime[] P009O2_A264CPFech ;
      private bool[] P009O2_n264CPFech ;
      private DateTime[] P009O2_A817CPFVcto ;
      private bool[] P009O2_n817CPFVcto ;
      private string[] P009O2_A849CPRetTipAbr ;
      private string[] P009O2_A305CPRetComCod ;
      private string[] P009O2_A247PrvDsc ;
      private decimal[] P009O2_A843CPRetRet ;
      private decimal[] P009O2_A840CPRetTipCmb ;
      private decimal[] P009O2_A839CPRetTotal ;
      private int[] P009O2_A833CPRetComMon ;
   }

   public class rrlibro4_1__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009O2;
          prmP009O2 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009O2", "SELECT T3.[PrvCod], T1.[CPRetTipCod] AS CPRetTipCod, T3.[CPRetSts], T3.[CPRetFec], T1.[CPRetPrvCod] AS CPRetPrvCod, T1.[CPRetCod], T5.[CPFech], T5.[CPFVcto], T2.[TipAbr] AS CPRetTipAbr, T1.[CPRetComCod] AS CPRetComCod, T4.[PrvDsc], T1.[CPRetRet], T3.[CPRetTipCmb], T1.[CPRetTotal], T5.[CPMonCod] AS CPRetComMon FROM (((([CPRETENCIONDET] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CPRetTipCod]) INNER JOIN [CPRETENCION] T3 ON T3.[CPRetCod] = T1.[CPRetCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T3.[PrvCod]) INNER JOIN [CPCUENTAPAGAR] T5 ON T5.[CPTipCod] = T1.[CPRetTipCod] AND T5.[CPComCod] = T1.[CPRetComCod] AND T5.[CPPrvCod] = T1.[CPRetPrvCod]) WHERE (YEAR(T3.[CPRetFec]) = @AV11Ano) AND (MONTH(T3.[CPRetFec]) = @AV12Mes) AND (T3.[CPRetSts] <> 'A') ORDER BY T1.[CPRetPrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009O2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((string[]) buf[11])[0] = rslt.getString(10, 15);
                ((string[]) buf[12])[0] = rslt.getString(11, 100);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((int[]) buf[16])[0] = rslt.getInt(15);
                return;
       }
    }

 }

}
