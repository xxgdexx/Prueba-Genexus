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
namespace GeneXus.Programs {
   public class rranticipoclientes : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rranticipoclientes.aspx")), "rranticipoclientes.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rranticipoclientes.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "CliCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV13CliCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV49TipCod = GetPar( "TipCod");
                  AV59VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
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

      public rranticipoclientes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rranticipoclientes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CliCod ,
                           ref string aP1_TipCod ,
                           ref int aP2_VenCod )
      {
         this.AV13CliCod = aP0_CliCod;
         this.AV49TipCod = aP1_TipCod;
         this.AV59VenCod = aP2_VenCod;
         initialize();
         executePrivate();
         aP0_CliCod=this.AV13CliCod;
         aP1_TipCod=this.AV49TipCod;
         aP2_VenCod=this.AV59VenCod;
      }

      public int executeUdp( ref string aP0_CliCod ,
                             ref string aP1_TipCod )
      {
         execute(ref aP0_CliCod, ref aP1_TipCod, ref aP2_VenCod);
         return AV59VenCod ;
      }

      public void executeSubmit( ref string aP0_CliCod ,
                                 ref string aP1_TipCod ,
                                 ref int aP2_VenCod )
      {
         rranticipoclientes objrranticipoclientes;
         objrranticipoclientes = new rranticipoclientes();
         objrranticipoclientes.AV13CliCod = aP0_CliCod;
         objrranticipoclientes.AV49TipCod = aP1_TipCod;
         objrranticipoclientes.AV59VenCod = aP2_VenCod;
         objrranticipoclientes.context.SetSubmitInitialConfig(context);
         objrranticipoclientes.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrranticipoclientes);
         aP0_CliCod=this.AV13CliCod;
         aP1_TipCod=this.AV49TipCod;
         aP2_VenCod=this.AV59VenCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rranticipoclientes)stateInfo).executePrivate();
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
            AV19Empresa = AV46Session.Get("Empresa");
            AV18EmpDir = AV46Session.Get("EmpDir");
            AV20EmpRUC = AV46Session.Get("EmpRUC");
            AV42Ruta = AV46Session.Get("RUTA") + "/Logo.jpg";
            AV35Logo = AV42Ruta;
            AV66Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV24Filtro1 = "Todos";
            AV25Filtro2 = "Todos";
            AV26Filtro3 = "Todos";
            AV27Filtro4 = "Todos";
            /* Using cursor P00992 */
            pr_default.execute(0, new Object[] {AV59VenCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A309VenCod = P00992_A309VenCod[0];
               A2045VenDsc = P00992_A2045VenDsc[0];
               AV24Filtro1 = StringUtil.Trim( A2045VenDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00993 */
            pr_default.execute(1, new Object[] {AV36MonCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A180MonCod = P00993_A180MonCod[0];
               A1234MonDsc = P00993_A1234MonDsc[0];
               n1234MonDsc = P00993_n1234MonDsc[0];
               AV25Filtro2 = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV53TotGImporte = 0.00m;
            AV54TotGPagos = 0.00m;
            AV55TotGSaldo = 0.00m;
            AV52TotalMN = 0.00m;
            AV51TotalME = 0.00m;
            /* Execute user subroutine: 'CUENTAANTICIPO' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            if ( (0==AV36MonCod) )
            {
               AV38MonMN = "";
               AV37MonME = "";
               /* Using cursor P00994 */
               pr_default.execute(2);
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A1234MonDsc = P00994_A1234MonDsc[0];
                  n1234MonDsc = P00994_n1234MonDsc[0];
                  A180MonCod = P00994_A180MonCod[0];
                  if ( A180MonCod == 1 )
                  {
                     AV38MonMN = StringUtil.Trim( A1234MonDsc);
                  }
                  if ( A180MonCod == 2 )
                  {
                     AV37MonME = StringUtil.Trim( A1234MonDsc);
                  }
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               H990( false, 86) ;
               getPrinter().GxDrawRect(188, Gx_line+7, 603, Gx_line+79, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(422, Gx_line+7, 422, Gx_line+79, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(188, Gx_line+29, 603, Gx_line+29, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(188, Gx_line+52, 603, Gx_line+52, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Moneda", 285, Gx_line+11, 333, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total General", 460, Gx_line+11, 540, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38MonMN, "")), 194, Gx_line+34, 415, Gx_line+48, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37MonME, "")), 194, Gx_line+58, 415, Gx_line+72, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 464, Gx_line+34, 571, Gx_line+49, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51TotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 464, Gx_line+58, 571, Gx_line+73, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+86);
            }
            else
            {
               H990( false, 28) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TotGImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 468, Gx_line+9, 565, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54TotGPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 569, Gx_line+9, 674, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55TotGSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 673, Gx_line+9, 778, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(465, Gx_line+4, 787, Gx_line+4, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total General", 360, Gx_line+10, 440, Gx_line+24, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+28);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H990( true, 0) ;
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
         /* 'CUENTAANTICIPO' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV13CliCod ,
                                              AV36MonCod ,
                                              AV59VenCod ,
                                              A148CLAntCliCod ,
                                              A147CLAntMonCod ,
                                              A146CLAntVenCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00995 */
         pr_default.execute(3, new Object[] {AV13CliCod, AV36MonCod, AV59VenCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK996 = false;
            A551CLAntCliDsc = P00995_A551CLAntCliDsc[0];
            A144CLAntTipCod = P00995_A144CLAntTipCod[0];
            A145CLAntDocNum = P00995_A145CLAntDocNum[0];
            A554CLAntImporte = P00995_A554CLAntImporte[0];
            A1234MonDsc = P00995_A1234MonDsc[0];
            n1234MonDsc = P00995_n1234MonDsc[0];
            A555CLAntImpPago = P00995_A555CLAntImpPago[0];
            A147CLAntMonCod = P00995_A147CLAntMonCod[0];
            A553ClAntFecha = P00995_A553ClAntFecha[0];
            A146CLAntVenCod = P00995_A146CLAntVenCod[0];
            A148CLAntCliCod = P00995_A148CLAntCliCod[0];
            A630CliTel2 = P00995_A630CliTel2[0];
            n630CliTel2 = P00995_n630CliTel2[0];
            A629CliTel1 = P00995_A629CliTel1[0];
            n629CliTel1 = P00995_n629CliTel1[0];
            A1234MonDsc = P00995_A1234MonDsc[0];
            n1234MonDsc = P00995_n1234MonDsc[0];
            A551CLAntCliDsc = P00995_A551CLAntCliDsc[0];
            A630CliTel2 = P00995_A630CliTel2[0];
            n630CliTel2 = P00995_n630CliTel2[0];
            A629CliTel1 = P00995_A629CliTel1[0];
            n629CliTel1 = P00995_n629CliTel1[0];
            AV9CCCliCod = A148CLAntCliCod;
            AV14CliDsc = StringUtil.Trim( A148CLAntCliCod) + " - " + StringUtil.Trim( A551CLAntCliDsc);
            AV47Telf = "Telf : " + StringUtil.Trim( A629CliTel1) + (!String.IsNullOrEmpty(StringUtil.RTrim( A630CliTel2)) ? " / "+StringUtil.Trim( A630CliTel2) : "");
            H990( false, 21) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14CliDsc, "")), 8, Gx_line+3, 434, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Telf, "")), 457, Gx_line+3, 718, Gx_line+18, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+21);
            AV56TotImporte = 0.00m;
            AV57TotPagos = 0.00m;
            AV58TotSaldo = 0.00m;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00995_A551CLAntCliDsc[0], A551CLAntCliDsc) == 0 ) )
            {
               BRK996 = false;
               A144CLAntTipCod = P00995_A144CLAntTipCod[0];
               A145CLAntDocNum = P00995_A145CLAntDocNum[0];
               A554CLAntImporte = P00995_A554CLAntImporte[0];
               A1234MonDsc = P00995_A1234MonDsc[0];
               n1234MonDsc = P00995_n1234MonDsc[0];
               A555CLAntImpPago = P00995_A555CLAntImpPago[0];
               A147CLAntMonCod = P00995_A147CLAntMonCod[0];
               A553ClAntFecha = P00995_A553ClAntFecha[0];
               A148CLAntCliCod = P00995_A148CLAntCliCod[0];
               A1234MonDsc = P00995_A1234MonDsc[0];
               n1234MonDsc = P00995_n1234MonDsc[0];
               AV61TipAbr = A144CLAntTipCod;
               AV10CCDocNum = A145CLAntDocNum;
               AV62CCFech = A553ClAntFecha;
               AV33Importe = A554CLAntImporte;
               AV63MonDsc = A1234MonDsc;
               AV40Pagos = A555CLAntImpPago;
               AV43Saldo = (decimal)(AV33Importe-AV40Pagos);
               AV56TotImporte = (decimal)(AV56TotImporte+AV33Importe);
               AV57TotPagos = (decimal)(AV57TotPagos+AV40Pagos);
               AV58TotSaldo = (decimal)(AV58TotSaldo+AV43Saldo);
               AV52TotalMN = (decimal)(AV52TotalMN+(((A147CLAntMonCod==1) ? AV43Saldo : (decimal)(0))));
               AV51TotalME = (decimal)(AV51TotalME+(((A147CLAntMonCod==2) ? AV43Saldo : (decimal)(0))));
               H990( false, 17) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61TipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10CCDocNum, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV62CCFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63MonDsc, "")), 252, Gx_line+2, 451, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+2, 566, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+2, 675, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+2, 779, Gx_line+17, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               BRK996 = true;
               pr_default.readNext(3);
            }
            H990( false, 24) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+6, 566, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+6, 675, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 779, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(466, Gx_line+1, 788, Gx_line+1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Cliente", 349, Gx_line+6, 424, Gx_line+20, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+24);
            AV53TotGImporte = (decimal)(AV53TotGImporte+AV56TotImporte);
            AV54TotGPagos = (decimal)(AV54TotGPagos+AV57TotPagos);
            AV55TotGSaldo = (decimal)(AV55TotGSaldo+AV58TotSaldo);
            if ( ! BRK996 )
            {
               BRK996 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void H990( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 675, Gx_line+29, 707, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 675, Gx_line+46, 719, Gx_line+60, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 675, Gx_line+13, 714, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 731, Gx_line+46, 770, Gx_line+61, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 700, Gx_line+29, 769, Gx_line+43, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 723, Gx_line+13, 770, Gx_line+28, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 14, Gx_line+152, 37, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Documento", 71, Gx_line+153, 156, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 275, Gx_line+153, 323, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe Total", 421, Gx_line+153, 504, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+146, 797, Gx_line+172, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Anticipos de Clientes", 302, Gx_line+70, 481, Gx_line+90, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 174, Gx_line+153, 209, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 691, Gx_line+153, 724, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Aplicación", 564, Gx_line+153, 624, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Vendedor", 248, Gx_line+97, 305, Gx_line+111, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 248, Gx_line+121, 296, Gx_line+135, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro1, "")), 309, Gx_line+92, 652, Gx_line+116, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Filtro2, "")), 309, Gx_line+116, 652, Gx_line+140, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18EmpDir, "")), 19, Gx_line+29, 404, Gx_line+47, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20EmpRUC, "")), 19, Gx_line+46, 404, Gx_line+64, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Empresa, "")), 19, Gx_line+11, 404, Gx_line+29, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+172);
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
         AV19Empresa = "";
         AV46Session = context.GetSession();
         AV18EmpDir = "";
         AV20EmpRUC = "";
         AV42Ruta = "";
         AV35Logo = "";
         AV66Logo_GXI = "";
         AV24Filtro1 = "";
         AV25Filtro2 = "";
         AV26Filtro3 = "";
         AV27Filtro4 = "";
         scmdbuf = "";
         P00992_A309VenCod = new int[1] ;
         P00992_A2045VenDsc = new string[] {""} ;
         A2045VenDsc = "";
         P00993_A180MonCod = new int[1] ;
         P00993_A1234MonDsc = new string[] {""} ;
         P00993_n1234MonDsc = new bool[] {false} ;
         A1234MonDsc = "";
         AV38MonMN = "";
         AV37MonME = "";
         P00994_A1234MonDsc = new string[] {""} ;
         P00994_n1234MonDsc = new bool[] {false} ;
         P00994_A180MonCod = new int[1] ;
         A148CLAntCliCod = "";
         P00995_A551CLAntCliDsc = new string[] {""} ;
         P00995_A144CLAntTipCod = new string[] {""} ;
         P00995_A145CLAntDocNum = new string[] {""} ;
         P00995_A554CLAntImporte = new decimal[1] ;
         P00995_A1234MonDsc = new string[] {""} ;
         P00995_n1234MonDsc = new bool[] {false} ;
         P00995_A555CLAntImpPago = new decimal[1] ;
         P00995_A147CLAntMonCod = new int[1] ;
         P00995_A553ClAntFecha = new DateTime[] {DateTime.MinValue} ;
         P00995_A146CLAntVenCod = new int[1] ;
         P00995_A148CLAntCliCod = new string[] {""} ;
         P00995_A630CliTel2 = new string[] {""} ;
         P00995_n630CliTel2 = new bool[] {false} ;
         P00995_A629CliTel1 = new string[] {""} ;
         P00995_n629CliTel1 = new bool[] {false} ;
         A551CLAntCliDsc = "";
         A144CLAntTipCod = "";
         A145CLAntDocNum = "";
         A553ClAntFecha = DateTime.MinValue;
         A630CliTel2 = "";
         A629CliTel1 = "";
         AV9CCCliCod = "";
         AV14CliDsc = "";
         AV47Telf = "";
         AV61TipAbr = "";
         AV10CCDocNum = "";
         AV62CCFech = DateTime.MinValue;
         AV63MonDsc = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rranticipoclientes__default(),
            new Object[][] {
                new Object[] {
               P00992_A309VenCod, P00992_A2045VenDsc
               }
               , new Object[] {
               P00993_A180MonCod, P00993_A1234MonDsc
               }
               , new Object[] {
               P00994_A1234MonDsc, P00994_A180MonCod
               }
               , new Object[] {
               P00995_A551CLAntCliDsc, P00995_A144CLAntTipCod, P00995_A145CLAntDocNum, P00995_A554CLAntImporte, P00995_A1234MonDsc, P00995_n1234MonDsc, P00995_A555CLAntImpPago, P00995_A147CLAntMonCod, P00995_A553ClAntFecha, P00995_A146CLAntVenCod,
               P00995_A148CLAntCliCod, P00995_A630CliTel2, P00995_n630CliTel2, P00995_A629CliTel1, P00995_n629CliTel1
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         Gx_time = context.localUtil.Time( );
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         Gx_time = context.localUtil.Time( );
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private int AV59VenCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A309VenCod ;
      private int AV36MonCod ;
      private int A180MonCod ;
      private int Gx_OldLine ;
      private int A147CLAntMonCod ;
      private int A146CLAntVenCod ;
      private decimal AV53TotGImporte ;
      private decimal AV54TotGPagos ;
      private decimal AV55TotGSaldo ;
      private decimal AV52TotalMN ;
      private decimal AV51TotalME ;
      private decimal A554CLAntImporte ;
      private decimal A555CLAntImpPago ;
      private decimal AV56TotImporte ;
      private decimal AV57TotPagos ;
      private decimal AV58TotSaldo ;
      private decimal AV33Importe ;
      private decimal AV40Pagos ;
      private decimal AV43Saldo ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV13CliCod ;
      private string AV49TipCod ;
      private string AV19Empresa ;
      private string AV18EmpDir ;
      private string AV20EmpRUC ;
      private string AV42Ruta ;
      private string AV24Filtro1 ;
      private string AV25Filtro2 ;
      private string AV26Filtro3 ;
      private string AV27Filtro4 ;
      private string scmdbuf ;
      private string A2045VenDsc ;
      private string A1234MonDsc ;
      private string AV38MonMN ;
      private string AV37MonME ;
      private string A148CLAntCliCod ;
      private string A551CLAntCliDsc ;
      private string A144CLAntTipCod ;
      private string A145CLAntDocNum ;
      private string A630CliTel2 ;
      private string A629CliTel1 ;
      private string AV9CCCliCod ;
      private string AV14CliDsc ;
      private string AV61TipAbr ;
      private string AV10CCDocNum ;
      private string AV63MonDsc ;
      private string Gx_time ;
      private DateTime A553ClAntFecha ;
      private DateTime AV62CCFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1234MonDsc ;
      private bool returnInSub ;
      private bool BRK996 ;
      private bool n630CliTel2 ;
      private bool n629CliTel1 ;
      private string AV66Logo_GXI ;
      private string AV47Telf ;
      private string AV35Logo ;
      private IGxSession AV46Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CliCod ;
      private string aP1_TipCod ;
      private int aP2_VenCod ;
      private IDataStoreProvider pr_default ;
      private int[] P00992_A309VenCod ;
      private string[] P00992_A2045VenDsc ;
      private int[] P00993_A180MonCod ;
      private string[] P00993_A1234MonDsc ;
      private bool[] P00993_n1234MonDsc ;
      private string[] P00994_A1234MonDsc ;
      private bool[] P00994_n1234MonDsc ;
      private int[] P00994_A180MonCod ;
      private string[] P00995_A551CLAntCliDsc ;
      private string[] P00995_A144CLAntTipCod ;
      private string[] P00995_A145CLAntDocNum ;
      private decimal[] P00995_A554CLAntImporte ;
      private string[] P00995_A1234MonDsc ;
      private bool[] P00995_n1234MonDsc ;
      private decimal[] P00995_A555CLAntImpPago ;
      private int[] P00995_A147CLAntMonCod ;
      private DateTime[] P00995_A553ClAntFecha ;
      private int[] P00995_A146CLAntVenCod ;
      private string[] P00995_A148CLAntCliCod ;
      private string[] P00995_A630CliTel2 ;
      private bool[] P00995_n630CliTel2 ;
      private string[] P00995_A629CliTel1 ;
      private bool[] P00995_n629CliTel1 ;
   }

   public class rranticipoclientes__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00995( IGxContext context ,
                                             string AV13CliCod ,
                                             int AV36MonCod ,
                                             int AV59VenCod ,
                                             string A148CLAntCliCod ,
                                             int A147CLAntMonCod ,
                                             int A146CLAntVenCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T3.[CliDsc] AS CLAntCliDsc, T1.[CLAntTipCod], T1.[CLAntDocNum], T1.[CLAntImporte], T2.[MonDsc], T1.[CLAntImpPago], T1.[CLAntMonCod] AS CLAntMonCod, T1.[ClAntFecha], T1.[CLAntVenCod], T1.[CLAntCliCod] AS CLAntCliCod, T3.[CliTel2], T3.[CliTel1] FROM (([CLANTICIPOS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CLAntMonCod]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T1.[CLAntCliCod])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CLAntCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV36MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CLAntMonCod] = @AV36MonCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV59VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CLAntVenCod] = @AV59VenCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[CliDsc], T1.[ClAntFecha]";
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
               case 3 :
                     return conditional_P00995(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00992;
          prmP00992 = new Object[] {
          new ParDef("@AV59VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00993;
          prmP00993 = new Object[] {
          new ParDef("@AV36MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00994;
          prmP00994 = new Object[] {
          };
          Object[] prmP00995;
          prmP00995 = new Object[] {
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV36MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV59VenCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00992", "SELECT [VenCod], [VenDsc] FROM [CVENDEDORES] WHERE [VenCod] = @AV59VenCod ORDER BY [VenCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00992,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00993", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV36MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00993,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00994", "SELECT [MonDsc], [MonCod] FROM [CMONEDAS] ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00994,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00995", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00995,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 12);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 20);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((bool[]) buf[14])[0] = rslt.wasNull(12);
                return;
       }
    }

 }

}
