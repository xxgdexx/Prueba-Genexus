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
namespace GeneXus.Programs.compras {
   public class r_registrohonorariospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_registrohonorariospdf.aspx")), "compras.r_registrohonorariospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_registrohonorariospdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "jAno");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8jAno = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9jMes = (short)(NumberUtil.Val( GetPar( "jMes"), "."));
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

      public r_registrohonorariospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_registrohonorariospdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_jAno ,
                           ref short aP1_jMes )
      {
         this.AV8jAno = aP0_jAno;
         this.AV9jMes = aP1_jMes;
         initialize();
         executePrivate();
         aP0_jAno=this.AV8jAno;
         aP1_jMes=this.AV9jMes;
      }

      public short executeUdp( ref short aP0_jAno )
      {
         execute(ref aP0_jAno, ref aP1_jMes);
         return AV9jMes ;
      }

      public void executeSubmit( ref short aP0_jAno ,
                                 ref short aP1_jMes )
      {
         r_registrohonorariospdf objr_registrohonorariospdf;
         objr_registrohonorariospdf = new r_registrohonorariospdf();
         objr_registrohonorariospdf.AV8jAno = aP0_jAno;
         objr_registrohonorariospdf.AV9jMes = aP1_jMes;
         objr_registrohonorariospdf.context.SetSubmitInitialConfig(context);
         objr_registrohonorariospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_registrohonorariospdf);
         aP0_jAno=this.AV8jAno;
         aP1_jMes=this.AV9jMes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_registrohonorariospdf)stateInfo).executePrivate();
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
            Gx_out = "SCR" ;
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
            AV38Empresa = AV37Session.Get("Empresa");
            AV39EmpDir = AV37Session.Get("EmpDir");
            AV45EmpRUC = AV37Session.Get("EmpRUC");
            AV46Ruta = AV37Session.Get("RUTA") + "/Logo.jpg";
            AV47Logo = AV46Ruta;
            AV51Logo_GXI = GXDbFile.PathToUrl( AV46Ruta);
            GXt_char1 = AV48cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV9jMes, out  GXt_char1) ;
            AV48cMes = GXt_char1;
            AV10DocAbr = "";
            AV11DocNum = "";
            AV12DocFec = DateTimeUtil.ResetTime(DateTimeUtil.Now( context));
            AV35PrvCod = "";
            AV34PrvDsc = "";
            AV15SubTotal = 0.00m;
            AV16Dscto = 0.00m;
            AV17Igv = 0.00m;
            AV18TotalMN = 0.00m;
            AV19TotalMO = 0.00m;
            AV20TipCmb = 0.0000m;
            AV29TSubTotal = 0.00m;
            AV43TSubTotalI = 0.00m;
            AV30TTDscto = 0.00m;
            AV31TIGV = 0.00m;
            AV32TTotalMN = 0.00m;
            /* Using cursor P009M3 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK9M3 = false;
               A1915TipRHo = P009M3_A1915TipRHo[0];
               A306TipAbr = P009M3_A306TipAbr[0];
               A707ComFReg = P009M3_A707ComFReg[0];
               A708ComFVcto = P009M3_A708ComFVcto[0];
               A246ComMon = P009M3_A246ComMon[0];
               A1233MonAbr = P009M3_A1233MonAbr[0];
               n1233MonAbr = P009M3_n1233MonAbr[0];
               A244PrvCod = P009M3_A244PrvCod[0];
               A247PrvDsc = P009M3_A247PrvDsc[0];
               A511TipSigno = P009M3_A511TipSigno[0];
               A243ComCod = P009M3_A243ComCod[0];
               A248ComFec = P009M3_A248ComFec[0];
               A149TipCod = P009M3_A149TipCod[0];
               A719ComIVADUA = P009M3_A719ComIVADUA[0];
               A718ComRedondeo = P009M3_A718ComRedondeo[0];
               A717ComPorIva = P009M3_A717ComPorIva[0];
               A729ComRete2 = P009M3_A729ComRete2[0];
               A728ComRete1 = P009M3_A728ComRete1[0];
               A698ComDscto = P009M3_A698ComDscto[0];
               A706ComFlete = P009M3_A706ComFlete[0];
               A713ComISC = P009M3_A713ComISC[0];
               A732ComSubIna = P009M3_A732ComSubIna[0];
               A716ComSubAfe = P009M3_A716ComSubAfe[0];
               A1233MonAbr = P009M3_A1233MonAbr[0];
               n1233MonAbr = P009M3_n1233MonAbr[0];
               A1915TipRHo = P009M3_A1915TipRHo[0];
               A306TipAbr = P009M3_A306TipAbr[0];
               A511TipSigno = P009M3_A511TipSigno[0];
               A732ComSubIna = P009M3_A732ComSubIna[0];
               A716ComSubAfe = P009M3_A716ComSubAfe[0];
               A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
               A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
               A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
               AV21GSubTotal = 0.00m;
               AV42GSubIna = 0.00m;
               AV22GDscto = 0.00m;
               AV23GIgv = 0.00m;
               AV24GTotalMN = 0.00m;
               AV25GTotalMO = 0.00m;
               AV36TipCod = A149TipCod;
               AV44TipAbr = A306TipAbr;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P009M3_A306TipAbr[0], A306TipAbr) == 0 ) )
               {
                  BRK9M3 = false;
                  A707ComFReg = P009M3_A707ComFReg[0];
                  A708ComFVcto = P009M3_A708ComFVcto[0];
                  A246ComMon = P009M3_A246ComMon[0];
                  A1233MonAbr = P009M3_A1233MonAbr[0];
                  n1233MonAbr = P009M3_n1233MonAbr[0];
                  A244PrvCod = P009M3_A244PrvCod[0];
                  A247PrvDsc = P009M3_A247PrvDsc[0];
                  A511TipSigno = P009M3_A511TipSigno[0];
                  A243ComCod = P009M3_A243ComCod[0];
                  A248ComFec = P009M3_A248ComFec[0];
                  A149TipCod = P009M3_A149TipCod[0];
                  A719ComIVADUA = P009M3_A719ComIVADUA[0];
                  A718ComRedondeo = P009M3_A718ComRedondeo[0];
                  A717ComPorIva = P009M3_A717ComPorIva[0];
                  A729ComRete2 = P009M3_A729ComRete2[0];
                  A728ComRete1 = P009M3_A728ComRete1[0];
                  A698ComDscto = P009M3_A698ComDscto[0];
                  A706ComFlete = P009M3_A706ComFlete[0];
                  A713ComISC = P009M3_A713ComISC[0];
                  A1233MonAbr = P009M3_A1233MonAbr[0];
                  n1233MonAbr = P009M3_n1233MonAbr[0];
                  A511TipSigno = P009M3_A511TipSigno[0];
                  if ( StringUtil.StrCmp(A306TipAbr, AV44TipAbr) == 0 )
                  {
                     if ( DateTimeUtil.Year( A707ComFReg) == AV8jAno )
                     {
                        if ( DateTimeUtil.Month( A707ComFReg) == AV9jMes )
                        {
                           /* Using cursor P009M5 */
                           pr_default.execute(1, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                           if ( (pr_default.getStatus(1) != 101) )
                           {
                              A732ComSubIna = P009M5_A732ComSubIna[0];
                              A716ComSubAfe = P009M5_A716ComSubAfe[0];
                           }
                           else
                           {
                              A732ComSubIna = 0;
                              A716ComSubAfe = 0;
                           }
                           pr_default.close(1);
                           A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
                           A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
                           A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
                           AV26MonCod = A246ComMon;
                           AV36TipCod = A149TipCod;
                           AV28MonAbr = A1233MonAbr;
                           AV27TipVenta = 1.00000m;
                           AV20TipCmb = 0.00000m;
                           AV10DocAbr = A306TipAbr;
                           AV11DocNum = A243ComCod;
                           AV12DocFec = A248ComFec;
                           AV35PrvCod = A244PrvCod;
                           AV34PrvDsc = A247PrvDsc;
                           GXt_char1 = AV33DocSts;
                           new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV35PrvCod, ref  AV36TipCod, ref  AV11DocNum, out  GXt_char1) ;
                           AV33DocSts = GXt_char1;
                           AV15SubTotal = 0.00m;
                           AV41SubIna = 0.00m;
                           AV16Dscto = 0.00m;
                           AV17Igv = 0.00m;
                           AV18TotalMN = 0.00m;
                           AV19TotalMO = 0.00m;
                           if ( AV26MonCod != 1 )
                           {
                              /* Using cursor P009M6 */
                              pr_default.execute(2, new Object[] {AV26MonCod, AV12DocFec});
                              while ( (pr_default.getStatus(2) != 101) )
                              {
                                 A308TipFech = P009M6_A308TipFech[0];
                                 A307TipMonCod = P009M6_A307TipMonCod[0];
                                 A1920TipVenta = P009M6_A1920TipVenta[0];
                                 AV27TipVenta = A1920TipVenta;
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(2);
                              AV20TipCmb = AV27TipVenta;
                           }
                           if ( StringUtil.StrCmp(AV33DocSts, "A") != 0 )
                           {
                              AV15SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV27TipVenta)*A511TipSigno);
                              AV41SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV27TipVenta)*A511TipSigno);
                              AV16Dscto = (decimal)((NumberUtil.Round( A728ComRete1, 2)*AV27TipVenta)*A511TipSigno);
                              AV17Igv = (decimal)((NumberUtil.Round( A729ComRete2, 2)*AV27TipVenta)*A511TipSigno);
                              AV18TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV27TipVenta)*A511TipSigno);
                              AV19TotalMO = NumberUtil.Round( A736ComTotal, 2);
                           }
                           AV21GSubTotal = (decimal)(AV21GSubTotal+AV15SubTotal);
                           AV42GSubIna = (decimal)(AV42GSubIna+AV41SubIna);
                           AV22GDscto = (decimal)(AV22GDscto+AV16Dscto);
                           AV23GIgv = (decimal)(AV23GIgv+AV17Igv);
                           AV24GTotalMN = (decimal)(AV24GTotalMN+AV18TotalMN);
                           AV25GTotalMO = (decimal)(AV25GTotalMO+AV19TotalMO);
                           H9M0( false, 19) ;
                           getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34PrvDsc, "")), 279, Gx_line+1, 523, Gx_line+15, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35PrvCod, "@!")), 168, Gx_line+1, 274, Gx_line+15, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11DocNum, "")), 74, Gx_line+1, 162, Gx_line+15, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(context.localUtil.Format( AV12DocFec, "99/99/99"), 4, Gx_line+1, 69, Gx_line+15, 0, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV15SubTotal, "ZZZZZZZZZZZ9.99")), 551, Gx_line+1, 648, Gx_line+15, 2, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Igv, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+1, 912, Gx_line+15, 2, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16Dscto, "ZZZZZZ,ZZZ,ZZ9.99")), 730, Gx_line+1, 827, Gx_line+15, 2, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 891, Gx_line+1, 988, Gx_line+15, 2, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19TotalMO, "ZZZZZZ,ZZZ,ZZ9.99")), 967, Gx_line+1, 1064, Gx_line+15, 2, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20TipCmb, "ZZZ9.99999")), 1041, Gx_line+1, 1138, Gx_line+15, 2, 0, 0, 0) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28MonAbr, "")), 526, Gx_line+1, 566, Gx_line+15, 1, 0, 0, 0) ;
                           getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 614, Gx_line+0, 721, Gx_line+15, 2+256, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+19);
                        }
                     }
                  }
                  BRK9M3 = true;
                  pr_default.readNext(0);
               }
               AV29TSubTotal = (decimal)(AV29TSubTotal+AV21GSubTotal);
               AV43TSubTotalI = (decimal)(AV43TSubTotalI+AV42GSubIna);
               AV30TTDscto = (decimal)(AV30TTDscto+AV22GDscto);
               AV31TIGV = (decimal)(AV31TIGV+AV23GIgv);
               AV32TTotalMN = (decimal)(AV32TTotalMN+AV24GTotalMN);
               if ( ! BRK9M3 )
               {
                  BRK9M3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9M0( true, 0) ;
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

      protected void H9M0( bool bFoot ,
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
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29TSubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 551, Gx_line+14, 648, Gx_line+28, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31TIGV, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+10, 912, Gx_line+24, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV30TTDscto, "ZZZZZZ,ZZZ,ZZ9.99")), 730, Gx_line+10, 827, Gx_line+24, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32TTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 891, Gx_line+10, 988, Gx_line+24, 2, 0, 0, 0) ;
                  getPrinter().GxDrawLine(570, Gx_line+4, 1011, Gx_line+4, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total General", 464, Gx_line+14, 544, Gx_line+28, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43TSubTotalI, "ZZZZZZ,ZZZ,ZZ9.99")), 614, Gx_line+14, 721, Gx_line+29, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+53);
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
               getPrinter().GxDrawText("Registro de Honorarios Profesionales", 381, Gx_line+53, 698, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Año :", 376, Gx_line+93, 422, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Mes :", 554, Gx_line+93, 600, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8jAno), "ZZZ9")), 444, Gx_line+93, 483, Gx_line+114, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48cMes, "")), 621, Gx_line+93, 768, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45EmpRUC, "")), 6, Gx_line+119, 377, Gx_line+137, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39EmpDir, "")), 6, Gx_line+102, 377, Gx_line+120, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38Empresa, "")), 6, Gx_line+84, 374, Gx_line+102, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV47Logo)) ? AV51Logo_GXI : AV47Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 6, Gx_line+8, 178, Gx_line+83) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+139);
               getPrinter().GxDrawRect(0, Gx_line+0, 1139, Gx_line+31, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(70, Gx_line+0, 70, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 15, Gx_line+8, 50, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Doc.", 91, Gx_line+8, 134, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(165, Gx_line+0, 165, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("R.U.C.", 202, Gx_line+8, 236, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(279, Gx_line+0, 279, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Nombres y Apellido", 332, Gx_line+8, 446, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(525, Gx_line+0, 525, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Afecto", 590, Gx_line+8, 630, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(652, Gx_line+0, 652, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Retencion 1", 747, Gx_line+8, 818, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(830, Gx_line+0, 830, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Retencion 2", 834, Gx_line+8, 905, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(915, Gx_line+0, 915, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Total MN", 923, Gx_line+8, 975, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(989, Gx_line+0, 989, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Total M.O.", 993, Gx_line+8, 1052, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1063, Gx_line+0, 1063, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("T.Cambio", 1068, Gx_line+8, 1123, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(571, Gx_line+0, 571, Gx_line+31, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Mon", 531, Gx_line+8, 557, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Inafecto", 668, Gx_line+8, 719, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(739, Gx_line+0, 739, Gx_line+31, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+31);
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
         pr_default.close(1);
      }

      public override void initialize( )
      {
         GXKey = "";
         GXDecQS = "";
         gxfirstwebparm = "";
         AV38Empresa = "";
         AV37Session = context.GetSession();
         AV39EmpDir = "";
         AV45EmpRUC = "";
         AV46Ruta = "";
         AV47Logo = "";
         AV51Logo_GXI = "";
         AV48cMes = "";
         AV10DocAbr = "";
         AV11DocNum = "";
         AV12DocFec = DateTime.MinValue;
         AV35PrvCod = "";
         AV34PrvDsc = "";
         scmdbuf = "";
         P009M3_A1915TipRHo = new short[1] ;
         P009M3_A306TipAbr = new string[] {""} ;
         P009M3_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P009M3_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P009M3_A246ComMon = new int[1] ;
         P009M3_A1233MonAbr = new string[] {""} ;
         P009M3_n1233MonAbr = new bool[] {false} ;
         P009M3_A244PrvCod = new string[] {""} ;
         P009M3_A247PrvDsc = new string[] {""} ;
         P009M3_A511TipSigno = new short[1] ;
         P009M3_A243ComCod = new string[] {""} ;
         P009M3_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P009M3_A149TipCod = new string[] {""} ;
         P009M3_A719ComIVADUA = new decimal[1] ;
         P009M3_A718ComRedondeo = new decimal[1] ;
         P009M3_A717ComPorIva = new decimal[1] ;
         P009M3_A729ComRete2 = new decimal[1] ;
         P009M3_A728ComRete1 = new decimal[1] ;
         P009M3_A698ComDscto = new decimal[1] ;
         P009M3_A706ComFlete = new decimal[1] ;
         P009M3_A713ComISC = new decimal[1] ;
         P009M3_A732ComSubIna = new decimal[1] ;
         P009M3_A716ComSubAfe = new decimal[1] ;
         A306TipAbr = "";
         A707ComFReg = DateTime.MinValue;
         A708ComFVcto = DateTime.MinValue;
         A1233MonAbr = "";
         A244PrvCod = "";
         A247PrvDsc = "";
         A243ComCod = "";
         A248ComFec = DateTime.MinValue;
         A149TipCod = "";
         AV36TipCod = "";
         AV44TipAbr = "";
         P009M5_A732ComSubIna = new decimal[1] ;
         P009M5_A716ComSubAfe = new decimal[1] ;
         AV28MonAbr = "";
         AV33DocSts = "";
         GXt_char1 = "";
         P009M6_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         P009M6_A307TipMonCod = new int[1] ;
         P009M6_A1920TipVenta = new decimal[1] ;
         A308TipFech = DateTime.MinValue;
         AV47Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_registrohonorariospdf__default(),
            new Object[][] {
                new Object[] {
               P009M3_A1915TipRHo, P009M3_A306TipAbr, P009M3_A707ComFReg, P009M3_A708ComFVcto, P009M3_A246ComMon, P009M3_A1233MonAbr, P009M3_n1233MonAbr, P009M3_A244PrvCod, P009M3_A247PrvDsc, P009M3_A511TipSigno,
               P009M3_A243ComCod, P009M3_A248ComFec, P009M3_A149TipCod, P009M3_A719ComIVADUA, P009M3_A718ComRedondeo, P009M3_A717ComPorIva, P009M3_A729ComRete2, P009M3_A728ComRete1, P009M3_A698ComDscto, P009M3_A706ComFlete,
               P009M3_A713ComISC, P009M3_A732ComSubIna, P009M3_A716ComSubAfe
               }
               , new Object[] {
               P009M5_A732ComSubIna, P009M5_A716ComSubAfe
               }
               , new Object[] {
               P009M6_A308TipFech, P009M6_A307TipMonCod, P009M6_A1920TipVenta
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV8jAno ;
      private short AV9jMes ;
      private short A1915TipRHo ;
      private short A511TipSigno ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A246ComMon ;
      private int AV26MonCod ;
      private int A307TipMonCod ;
      private int Gx_OldLine ;
      private decimal AV15SubTotal ;
      private decimal AV16Dscto ;
      private decimal AV17Igv ;
      private decimal AV18TotalMN ;
      private decimal AV19TotalMO ;
      private decimal AV20TipCmb ;
      private decimal AV29TSubTotal ;
      private decimal AV43TSubTotalI ;
      private decimal AV30TTDscto ;
      private decimal AV31TIGV ;
      private decimal AV32TTotalMN ;
      private decimal A719ComIVADUA ;
      private decimal A718ComRedondeo ;
      private decimal A717ComPorIva ;
      private decimal A729ComRete2 ;
      private decimal A728ComRete1 ;
      private decimal A698ComDscto ;
      private decimal A706ComFlete ;
      private decimal A713ComISC ;
      private decimal A732ComSubIna ;
      private decimal A716ComSubAfe ;
      private decimal A715ComIva ;
      private decimal A733ComSubTotal ;
      private decimal A736ComTotal ;
      private decimal AV21GSubTotal ;
      private decimal AV42GSubIna ;
      private decimal AV22GDscto ;
      private decimal AV23GIgv ;
      private decimal AV24GTotalMN ;
      private decimal AV25GTotalMO ;
      private decimal AV27TipVenta ;
      private decimal AV41SubIna ;
      private decimal A1920TipVenta ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV38Empresa ;
      private string AV39EmpDir ;
      private string AV45EmpRUC ;
      private string AV46Ruta ;
      private string AV48cMes ;
      private string AV10DocAbr ;
      private string AV11DocNum ;
      private string AV35PrvCod ;
      private string AV34PrvDsc ;
      private string scmdbuf ;
      private string A306TipAbr ;
      private string A1233MonAbr ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A243ComCod ;
      private string A149TipCod ;
      private string AV36TipCod ;
      private string AV44TipAbr ;
      private string AV28MonAbr ;
      private string AV33DocSts ;
      private string GXt_char1 ;
      private string sImgUrl ;
      private DateTime AV12DocFec ;
      private DateTime A707ComFReg ;
      private DateTime A708ComFVcto ;
      private DateTime A248ComFec ;
      private DateTime A308TipFech ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK9M3 ;
      private bool n1233MonAbr ;
      private string AV51Logo_GXI ;
      private string AV47Logo ;
      private string Logo ;
      private IGxSession AV37Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_jAno ;
      private short aP1_jMes ;
      private IDataStoreProvider pr_default ;
      private short[] P009M3_A1915TipRHo ;
      private string[] P009M3_A306TipAbr ;
      private DateTime[] P009M3_A707ComFReg ;
      private DateTime[] P009M3_A708ComFVcto ;
      private int[] P009M3_A246ComMon ;
      private string[] P009M3_A1233MonAbr ;
      private bool[] P009M3_n1233MonAbr ;
      private string[] P009M3_A244PrvCod ;
      private string[] P009M3_A247PrvDsc ;
      private short[] P009M3_A511TipSigno ;
      private string[] P009M3_A243ComCod ;
      private DateTime[] P009M3_A248ComFec ;
      private string[] P009M3_A149TipCod ;
      private decimal[] P009M3_A719ComIVADUA ;
      private decimal[] P009M3_A718ComRedondeo ;
      private decimal[] P009M3_A717ComPorIva ;
      private decimal[] P009M3_A729ComRete2 ;
      private decimal[] P009M3_A728ComRete1 ;
      private decimal[] P009M3_A698ComDscto ;
      private decimal[] P009M3_A706ComFlete ;
      private decimal[] P009M3_A713ComISC ;
      private decimal[] P009M3_A732ComSubIna ;
      private decimal[] P009M3_A716ComSubAfe ;
      private decimal[] P009M5_A732ComSubIna ;
      private decimal[] P009M5_A716ComSubAfe ;
      private DateTime[] P009M6_A308TipFech ;
      private int[] P009M6_A307TipMonCod ;
      private decimal[] P009M6_A1920TipVenta ;
   }

   public class r_registrohonorariospdf__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009M3;
          prmP009M3 = new Object[] {
          };
          Object[] prmP009M5;
          prmP009M5 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP009M6;
          prmP009M6 = new Object[] {
          new ParDef("@AV26MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV12DocFec",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009M3", "SELECT T3.[TipRHo], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T2.[MonAbr], T1.[PrvCod], T1.[PrvDsc], T3.[TipSigno], T1.[ComCod], T1.[ComFec], T1.[TipCod], T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComRete2], T1.[ComRete1], T1.[ComDscto], T1.[ComFlete], T1.[ComISC], COALESCE( T4.[ComSubIna], 0) AS ComSubIna, COALESCE( T4.[ComSubAfe], 0) AS ComSubAfe FROM ((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna, SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipRHo] = 1 ORDER BY T3.[TipAbr], T1.[TipCod], T1.[ComFec], T1.[ComCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009M3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009M5", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna, SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009M5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009M6", "SELECT [TipFech], [TipMonCod], [TipVenta] FROM [CTIPOCAMBIO] WHERE [TipMonCod] = @AV26MonCod and [TipFech] = @AV12DocFec ORDER BY [TipMonCod], [TipFech] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009M6,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 5);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 15);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(11);
                ((string[]) buf[12])[0] = rslt.getString(12, 3);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(22);
                return;
             case 1 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 2 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
       }
    }

 }

}
