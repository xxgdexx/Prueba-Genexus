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
   public class rrcuentasxcobrarvendedor : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrcuentasxcobrarvendedor.aspx")), "rrcuentasxcobrarvendedor.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrcuentasxcobrarvendedor.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "TipCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV43TipCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14CliCod = GetPar( "CliCod");
                  AV35MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV55VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
                  AV23FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
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

      public rrcuentasxcobrarvendedor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrcuentasxcobrarvendedor( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_TipCod ,
                           ref string aP1_CliCod ,
                           ref int aP2_MonCod ,
                           ref int aP3_VenCod ,
                           ref DateTime aP4_FHasta )
      {
         this.AV43TipCod = aP0_TipCod;
         this.AV14CliCod = aP1_CliCod;
         this.AV35MonCod = aP2_MonCod;
         this.AV55VenCod = aP3_VenCod;
         this.AV23FHasta = aP4_FHasta;
         initialize();
         executePrivate();
         aP0_TipCod=this.AV43TipCod;
         aP1_CliCod=this.AV14CliCod;
         aP2_MonCod=this.AV35MonCod;
         aP3_VenCod=this.AV55VenCod;
         aP4_FHasta=this.AV23FHasta;
      }

      public DateTime executeUdp( ref string aP0_TipCod ,
                                  ref string aP1_CliCod ,
                                  ref int aP2_MonCod ,
                                  ref int aP3_VenCod )
      {
         execute(ref aP0_TipCod, ref aP1_CliCod, ref aP2_MonCod, ref aP3_VenCod, ref aP4_FHasta);
         return AV23FHasta ;
      }

      public void executeSubmit( ref string aP0_TipCod ,
                                 ref string aP1_CliCod ,
                                 ref int aP2_MonCod ,
                                 ref int aP3_VenCod ,
                                 ref DateTime aP4_FHasta )
      {
         rrcuentasxcobrarvendedor objrrcuentasxcobrarvendedor;
         objrrcuentasxcobrarvendedor = new rrcuentasxcobrarvendedor();
         objrrcuentasxcobrarvendedor.AV43TipCod = aP0_TipCod;
         objrrcuentasxcobrarvendedor.AV14CliCod = aP1_CliCod;
         objrrcuentasxcobrarvendedor.AV35MonCod = aP2_MonCod;
         objrrcuentasxcobrarvendedor.AV55VenCod = aP3_VenCod;
         objrrcuentasxcobrarvendedor.AV23FHasta = aP4_FHasta;
         objrrcuentasxcobrarvendedor.context.SetSubmitInitialConfig(context);
         objrrcuentasxcobrarvendedor.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrcuentasxcobrarvendedor);
         aP0_TipCod=this.AV43TipCod;
         aP1_CliCod=this.AV14CliCod;
         aP2_MonCod=this.AV35MonCod;
         aP3_VenCod=this.AV55VenCod;
         aP4_FHasta=this.AV23FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrcuentasxcobrarvendedor)stateInfo).executePrivate();
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
            AV19Empresa = AV41Session.Get("Empresa");
            AV18EmpDir = AV41Session.Get("EmpDir");
            AV20EmpRUC = AV41Session.Get("EmpRUC");
            AV39Ruta = AV41Session.Get("RUTA") + "/Logo.jpg";
            AV34Logo = AV39Ruta;
            AV63Logo_GXI = GXDbFile.PathToUrl( AV39Ruta);
            AV24Filtro1 = "Todos";
            AV25Filtro2 = "Todos";
            AV26Filtro3 = "Todos";
            AV27Filtro4 = "Todos";
            AV28Filtro5 = "Todos";
            /* Using cursor P00932 */
            pr_default.execute(0, new Object[] {AV43TipCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A149TipCod = P00932_A149TipCod[0];
               A1910TipDsc = P00932_A1910TipDsc[0];
               AV24Filtro1 = A1910TipDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00933 */
            pr_default.execute(1, new Object[] {AV55VenCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A309VenCod = P00933_A309VenCod[0];
               A2045VenDsc = P00933_A2045VenDsc[0];
               n2045VenDsc = P00933_n2045VenDsc[0];
               AV25Filtro2 = A2045VenDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00934 */
            pr_default.execute(2, new Object[] {AV35MonCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A180MonCod = P00934_A180MonCod[0];
               A1234MonDsc = P00934_A1234MonDsc[0];
               n1234MonDsc = P00934_n1234MonDsc[0];
               AV26Filtro3 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P00935 */
            pr_default.execute(3, new Object[] {AV22EstCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A140EstCod = P00935_A140EstCod[0];
               n140EstCod = P00935_n140EstCod[0];
               A602EstDsc = P00935_A602EstDsc[0];
               A139PaiCod = P00935_A139PaiCod[0];
               n139PaiCod = P00935_n139PaiCod[0];
               AV27Filtro4 = A602EstDsc;
               pr_default.readNext(3);
            }
            pr_default.close(3);
            /* Using cursor P00936 */
            pr_default.execute(4, new Object[] {AV14CliCod});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A45CliCod = P00936_A45CliCod[0];
               A161CliDsc = P00936_A161CliDsc[0];
               AV28Filtro5 = A161CliDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
            AV46TotGImporte = 0.00m;
            AV47TotGPagos = 0.00m;
            AV48TotGSaldo = 0.00m;
            AV44TotalME = 0.00m;
            AV45TotalMN = 0.00m;
            if ( DateTimeUtil.ResetTime ( AV23FHasta ) == DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
            {
               pr_default.dynParam(5, new Object[]{ new Object[]{
                                                    AV55VenCod ,
                                                    AV14CliCod ,
                                                    A186CCVendCod ,
                                                    A188CCCliCod } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.INT
                                                    }
               });
               /* Using cursor P00937 */
               pr_default.execute(5, new Object[] {AV55VenCod, AV14CliCod});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  BRK938 = false;
                  A188CCCliCod = P00937_A188CCCliCod[0];
                  A186CCVendCod = P00937_A186CCVendCod[0];
                  A2045VenDsc = P00937_A2045VenDsc[0];
                  n2045VenDsc = P00937_n2045VenDsc[0];
                  A184CCTipCod = P00937_A184CCTipCod[0];
                  A185CCDocNum = P00937_A185CCDocNum[0];
                  A2045VenDsc = P00937_A2045VenDsc[0];
                  n2045VenDsc = P00937_n2045VenDsc[0];
                  while ( (pr_default.getStatus(5) != 101) && ( P00937_A186CCVendCod[0] == A186CCVendCod ) )
                  {
                     BRK938 = false;
                     A188CCCliCod = P00937_A188CCCliCod[0];
                     A184CCTipCod = P00937_A184CCTipCod[0];
                     A185CCDocNum = P00937_A185CCDocNum[0];
                     BRK938 = true;
                     pr_default.readNext(5);
                  }
                  AV50TotImpVend = 0.00m;
                  AV52TotPagoVend = 0.00m;
                  AV54TotSaldoVend = 0.00m;
                  AV56VendeCod = A186CCVendCod;
                  AV57Vendedor = AV56VendeCod;
                  /* Execute user subroutine: 'VALIDAMOV' */
                  S1213 ();
                  if ( returnInSub )
                  {
                     pr_default.close(5);
                     this.cleanup();
                     if (true) return;
                  }
                  AV30FlaVend = AV29Flag;
                  if ( AV30FlaVend == 1 )
                  {
                     H930( false, 21) ;
                     getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2045VenDsc, "")), 8, Gx_line+4, 634, Gx_line+20, 0+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+21);
                  }
                  /* Execute user subroutine: 'CUENTACOBRAR' */
                  S141 ();
                  if ( returnInSub )
                  {
                     pr_default.close(5);
                     this.cleanup();
                     if (true) return;
                  }
                  if ( AV30FlaVend == 1 )
                  {
                     H930( false, 27) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Total Vendedor", 158, Gx_line+8, 249, Gx_line+22, 0+256, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TotPagoVend, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+8, 675, Gx_line+23, 2, 0, 0, 0) ;
                     getPrinter().GxDrawLine(466, Gx_line+3, 788, Gx_line+3, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54TotSaldoVend, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+8, 779, Gx_line+23, 2, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2045VenDsc, "")), 265, Gx_line+8, 465, Gx_line+23, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50TotImpVend, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+8, 566, Gx_line+23, 2, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+27);
                  }
                  if ( ! BRK938 )
                  {
                     BRK938 = true;
                     pr_default.readNext(5);
                  }
               }
               pr_default.close(5);
            }
            else
            {
               pr_default.dynParam(6, new Object[]{ new Object[]{
                                                    AV55VenCod ,
                                                    AV14CliCod ,
                                                    A186CCVendCod ,
                                                    A188CCCliCod } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.INT
                                                    }
               });
               /* Using cursor P00938 */
               pr_default.execute(6, new Object[] {AV55VenCod, AV14CliCod});
               while ( (pr_default.getStatus(6) != 101) )
               {
                  BRK9310 = false;
                  A188CCCliCod = P00938_A188CCCliCod[0];
                  A186CCVendCod = P00938_A186CCVendCod[0];
                  A2045VenDsc = P00938_A2045VenDsc[0];
                  n2045VenDsc = P00938_n2045VenDsc[0];
                  A184CCTipCod = P00938_A184CCTipCod[0];
                  A185CCDocNum = P00938_A185CCDocNum[0];
                  A2045VenDsc = P00938_A2045VenDsc[0];
                  n2045VenDsc = P00938_n2045VenDsc[0];
                  while ( (pr_default.getStatus(6) != 101) && ( P00938_A186CCVendCod[0] == A186CCVendCod ) )
                  {
                     BRK9310 = false;
                     A188CCCliCod = P00938_A188CCCliCod[0];
                     A184CCTipCod = P00938_A184CCTipCod[0];
                     A185CCDocNum = P00938_A185CCDocNum[0];
                     BRK9310 = true;
                     pr_default.readNext(6);
                  }
                  AV50TotImpVend = 0.00m;
                  AV52TotPagoVend = 0.00m;
                  AV54TotSaldoVend = 0.00m;
                  AV56VendeCod = A186CCVendCod;
                  AV57Vendedor = AV56VendeCod;
                  /* Execute user subroutine: 'VALIDAMOV' */
                  S1213 ();
                  if ( returnInSub )
                  {
                     pr_default.close(6);
                     this.cleanup();
                     if (true) return;
                  }
                  AV30FlaVend = AV29Flag;
                  if ( AV30FlaVend == 1 )
                  {
                     H930( false, 21) ;
                     getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2045VenDsc, "")), 8, Gx_line+4, 634, Gx_line+20, 0+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+21);
                  }
                  /* Execute user subroutine: 'CUENTACOBRARAL' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(6);
                     this.cleanup();
                     if (true) return;
                  }
                  if ( AV30FlaVend == 1 )
                  {
                     H930( false, 27) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Total Vendedor", 158, Gx_line+8, 249, Gx_line+22, 0+256, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TotPagoVend, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+8, 675, Gx_line+23, 2, 0, 0, 0) ;
                     getPrinter().GxDrawLine(466, Gx_line+3, 788, Gx_line+3, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54TotSaldoVend, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+8, 779, Gx_line+23, 2, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2045VenDsc, "")), 265, Gx_line+8, 465, Gx_line+23, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50TotImpVend, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+8, 566, Gx_line+23, 2, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+27);
                  }
                  if ( ! BRK9310 )
                  {
                     BRK9310 = true;
                     pr_default.readNext(6);
                  }
               }
               pr_default.close(6);
            }
            if ( (0==AV35MonCod) )
            {
               AV37MonMN = "";
               AV36MonME = "";
               /* Using cursor P00939 */
               pr_default.execute(7);
               while ( (pr_default.getStatus(7) != 101) )
               {
                  A1234MonDsc = P00939_A1234MonDsc[0];
                  n1234MonDsc = P00939_n1234MonDsc[0];
                  A180MonCod = P00939_A180MonCod[0];
                  if ( A180MonCod == 1 )
                  {
                     AV37MonMN = StringUtil.Trim( A1234MonDsc);
                  }
                  if ( A180MonCod == 2 )
                  {
                     AV36MonME = StringUtil.Trim( A1234MonDsc);
                  }
                  pr_default.readNext(7);
               }
               pr_default.close(7);
               H930( false, 88) ;
               getPrinter().GxDrawRect(193, Gx_line+8, 608, Gx_line+80, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(427, Gx_line+8, 427, Gx_line+80, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(193, Gx_line+30, 608, Gx_line+30, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(193, Gx_line+53, 608, Gx_line+53, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Moneda", 291, Gx_line+13, 339, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total General", 466, Gx_line+13, 546, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37MonMN, "")), 199, Gx_line+35, 420, Gx_line+49, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36MonME, "")), 199, Gx_line+59, 420, Gx_line+73, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+35, 576, Gx_line+50, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44TotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+59, 576, Gx_line+74, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+88);
            }
            else
            {
               H930( false, 28) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46TotGImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+9, 566, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TotGPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+9, 675, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48TotGSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+9, 779, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(465, Gx_line+4, 787, Gx_line+4, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total General", 360, Gx_line+10, 440, Gx_line+24, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+28);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H930( true, 0) ;
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
         /* 'CUENTACOBRARAL' Routine */
         returnInSub = false;
         pr_default.dynParam(8, new Object[]{ new Object[]{
                                              AV14CliCod ,
                                              AV35MonCod ,
                                              AV43TipCod ,
                                              A188CCCliCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A190CCFech ,
                                              AV23FHasta ,
                                              A506CCEstado ,
                                              A186CCVendCod ,
                                              AV57Vendedor } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P009310 */
         pr_default.execute(8, new Object[] {AV23FHasta, AV57Vendedor, AV14CliCod, AV35MonCod, AV43TipCod});
         while ( (pr_default.getStatus(8) != 101) )
         {
            BRK9313 = false;
            A139PaiCod = P009310_A139PaiCod[0];
            n139PaiCod = P009310_n139PaiCod[0];
            A140EstCod = P009310_A140EstCod[0];
            n140EstCod = P009310_n140EstCod[0];
            A141ProvCod = P009310_A141ProvCod[0];
            n141ProvCod = P009310_n141ProvCod[0];
            A142DisCod = P009310_A142DisCod[0];
            n142DisCod = P009310_n142DisCod[0];
            A189CCCliDsc = P009310_A189CCCliDsc[0];
            A185CCDocNum = P009310_A185CCDocNum[0];
            A511TipSigno = P009310_A511TipSigno[0];
            n511TipSigno = P009310_n511TipSigno[0];
            A513CCImpTotal = P009310_A513CCImpTotal[0];
            A509CCImpPago = P009310_A509CCImpPago[0];
            A187CCmonCod = P009310_A187CCmonCod[0];
            A508CCFVcto = P009310_A508CCFVcto[0];
            A1234MonDsc = P009310_A1234MonDsc[0];
            n1234MonDsc = P009310_n1234MonDsc[0];
            A306TipAbr = P009310_A306TipAbr[0];
            n306TipAbr = P009310_n306TipAbr[0];
            A190CCFech = P009310_A190CCFech[0];
            A184CCTipCod = P009310_A184CCTipCod[0];
            A506CCEstado = P009310_A506CCEstado[0];
            A186CCVendCod = P009310_A186CCVendCod[0];
            A188CCCliCod = P009310_A188CCCliCod[0];
            A596CliDir = P009310_A596CliDir[0];
            n596CliDir = P009310_n596CliDir[0];
            A604DisDsc = P009310_A604DisDsc[0];
            A630CliTel2 = P009310_A630CliTel2[0];
            n630CliTel2 = P009310_n630CliTel2[0];
            A629CliTel1 = P009310_A629CliTel1[0];
            n629CliTel1 = P009310_n629CliTel1[0];
            A1234MonDsc = P009310_A1234MonDsc[0];
            n1234MonDsc = P009310_n1234MonDsc[0];
            A511TipSigno = P009310_A511TipSigno[0];
            n511TipSigno = P009310_n511TipSigno[0];
            A306TipAbr = P009310_A306TipAbr[0];
            n306TipAbr = P009310_n306TipAbr[0];
            A139PaiCod = P009310_A139PaiCod[0];
            n139PaiCod = P009310_n139PaiCod[0];
            A140EstCod = P009310_A140EstCod[0];
            n140EstCod = P009310_n140EstCod[0];
            A141ProvCod = P009310_A141ProvCod[0];
            n141ProvCod = P009310_n141ProvCod[0];
            A142DisCod = P009310_A142DisCod[0];
            n142DisCod = P009310_n142DisCod[0];
            A596CliDir = P009310_A596CliDir[0];
            n596CliDir = P009310_n596CliDir[0];
            A630CliTel2 = P009310_A630CliTel2[0];
            n630CliTel2 = P009310_n630CliTel2[0];
            A629CliTel1 = P009310_A629CliTel1[0];
            n629CliTel1 = P009310_n629CliTel1[0];
            A604DisDsc = P009310_A604DisDsc[0];
            AV57Vendedor = 0;
            AV9CCCliCod = A188CCCliCod;
            AV10CCCliDsc = StringUtil.Trim( AV9CCCliCod) + " - " + StringUtil.Trim( A189CCCliDsc);
            AV60CliDir = StringUtil.Trim( A596CliDir);
            AV59DisDsc = StringUtil.Trim( A604DisDsc);
            AV58Telf = "Telf : " + StringUtil.Trim( A629CliTel1) + (!String.IsNullOrEmpty(StringUtil.RTrim( A630CliTel2)) ? " / "+StringUtil.Trim( A630CliTel2) : "");
            /* Execute user subroutine: 'VALIDAMOV' */
            S1213 ();
            if ( returnInSub )
            {
               pr_default.close(8);
               returnInSub = true;
               if (true) return;
            }
            if ( AV29Flag == 1 )
            {
               H930( false, 35) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10CCCliDsc, "")), 8, Gx_line+2, 450, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Telf, "")), 457, Gx_line+2, 666, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60CliDir, "")), 8, Gx_line+20, 450, Gx_line+35, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59DisDsc, "")), 458, Gx_line+20, 735, Gx_line+35, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+35);
            }
            AV49TotImporte = 0.00m;
            AV51TotPagos = 0.00m;
            AV53TotSaldo = 0.00m;
            while ( (pr_default.getStatus(8) != 101) && ( StringUtil.StrCmp(P009310_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
            {
               BRK9313 = false;
               A185CCDocNum = P009310_A185CCDocNum[0];
               A511TipSigno = P009310_A511TipSigno[0];
               n511TipSigno = P009310_n511TipSigno[0];
               A513CCImpTotal = P009310_A513CCImpTotal[0];
               A509CCImpPago = P009310_A509CCImpPago[0];
               A187CCmonCod = P009310_A187CCmonCod[0];
               A508CCFVcto = P009310_A508CCFVcto[0];
               A1234MonDsc = P009310_A1234MonDsc[0];
               n1234MonDsc = P009310_n1234MonDsc[0];
               A306TipAbr = P009310_A306TipAbr[0];
               n306TipAbr = P009310_n306TipAbr[0];
               A190CCFech = P009310_A190CCFech[0];
               A184CCTipCod = P009310_A184CCTipCod[0];
               A1234MonDsc = P009310_A1234MonDsc[0];
               n1234MonDsc = P009310_n1234MonDsc[0];
               A511TipSigno = P009310_A511TipSigno[0];
               n511TipSigno = P009310_n511TipSigno[0];
               A306TipAbr = P009310_A306TipAbr[0];
               n306TipAbr = P009310_n306TipAbr[0];
               AV13CCTipCod = A184CCTipCod;
               AV11CCDocNum = A185CCDocNum;
               AV33Importe = (decimal)(A513CCImpTotal*A511TipSigno);
               AV38Pagos = (decimal)(A509CCImpPago*A511TipSigno);
               AV12CCmonCod = A187CCmonCod;
               /* Execute user subroutine: 'PAGOS' */
               S1314 ();
               if ( returnInSub )
               {
                  pr_default.close(8);
                  returnInSub = true;
                  if (true) return;
               }
               AV40Saldo = (decimal)((AV33Importe-AV38Pagos)*A511TipSigno);
               AV17Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A508CCFVcto));
               if ( ( AV40Saldo != Convert.ToDecimal( 0 )) )
               {
                  AV49TotImporte = (decimal)(AV49TotImporte+AV33Importe);
                  AV51TotPagos = (decimal)(AV51TotPagos+AV38Pagos);
                  AV53TotSaldo = (decimal)(AV53TotSaldo+AV40Saldo);
                  AV45TotalMN = (decimal)(AV45TotalMN+(((AV12CCmonCod==1) ? AV40Saldo : (decimal)(0))));
                  AV44TotalME = (decimal)(AV44TotalME+(((AV12CCmonCod==2) ? AV40Saldo : (decimal)(0))));
                  H930( false, 17) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A185CCDocNum, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A190CCFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A508CCFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 394, Gx_line+2, 451, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+2, 566, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+2, 675, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+2, 779, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17Dias), "ZZZZ9")), 308, Gx_line+2, 365, Gx_line+17, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
               }
               BRK9313 = true;
               pr_default.readNext(8);
            }
            if ( ( AV53TotSaldo != Convert.ToDecimal( 0 )) )
            {
               H930( false, 24) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+6, 566, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+6, 675, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 779, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(466, Gx_line+1, 788, Gx_line+1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Cliente", 349, Gx_line+6, 424, Gx_line+20, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
            }
            AV46TotGImporte = (decimal)(AV46TotGImporte+AV49TotImporte);
            AV47TotGPagos = (decimal)(AV47TotGPagos+AV51TotPagos);
            AV48TotGSaldo = (decimal)(AV48TotGSaldo+AV53TotSaldo);
            AV50TotImpVend = (decimal)(AV50TotImpVend+AV49TotImporte);
            AV52TotPagoVend = (decimal)(AV52TotPagoVend+AV51TotPagos);
            AV54TotSaldoVend = (decimal)(AV54TotSaldoVend+AV53TotSaldo);
            if ( ! BRK9313 )
            {
               BRK9313 = true;
               pr_default.readNext(8);
            }
         }
         pr_default.close(8);
      }

      protected void S141( )
      {
         /* 'CUENTACOBRAR' Routine */
         returnInSub = false;
         pr_default.dynParam(9, new Object[]{ new Object[]{
                                              AV14CliCod ,
                                              AV35MonCod ,
                                              AV43TipCod ,
                                              A188CCCliCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A186CCVendCod ,
                                              AV57Vendedor ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P009311 */
         pr_default.execute(9, new Object[] {AV57Vendedor, AV14CliCod, AV35MonCod, AV43TipCod});
         while ( (pr_default.getStatus(9) != 101) )
         {
            BRK9315 = false;
            A139PaiCod = P009311_A139PaiCod[0];
            n139PaiCod = P009311_n139PaiCod[0];
            A140EstCod = P009311_A140EstCod[0];
            n140EstCod = P009311_n140EstCod[0];
            A141ProvCod = P009311_A141ProvCod[0];
            n141ProvCod = P009311_n141ProvCod[0];
            A142DisCod = P009311_A142DisCod[0];
            n142DisCod = P009311_n142DisCod[0];
            A189CCCliDsc = P009311_A189CCCliDsc[0];
            A511TipSigno = P009311_A511TipSigno[0];
            n511TipSigno = P009311_n511TipSigno[0];
            A513CCImpTotal = P009311_A513CCImpTotal[0];
            A509CCImpPago = P009311_A509CCImpPago[0];
            A508CCFVcto = P009311_A508CCFVcto[0];
            A187CCmonCod = P009311_A187CCmonCod[0];
            A1234MonDsc = P009311_A1234MonDsc[0];
            n1234MonDsc = P009311_n1234MonDsc[0];
            A185CCDocNum = P009311_A185CCDocNum[0];
            A306TipAbr = P009311_A306TipAbr[0];
            n306TipAbr = P009311_n306TipAbr[0];
            A190CCFech = P009311_A190CCFech[0];
            A184CCTipCod = P009311_A184CCTipCod[0];
            A506CCEstado = P009311_A506CCEstado[0];
            A186CCVendCod = P009311_A186CCVendCod[0];
            A188CCCliCod = P009311_A188CCCliCod[0];
            A596CliDir = P009311_A596CliDir[0];
            n596CliDir = P009311_n596CliDir[0];
            A604DisDsc = P009311_A604DisDsc[0];
            A630CliTel2 = P009311_A630CliTel2[0];
            n630CliTel2 = P009311_n630CliTel2[0];
            A629CliTel1 = P009311_A629CliTel1[0];
            n629CliTel1 = P009311_n629CliTel1[0];
            A1234MonDsc = P009311_A1234MonDsc[0];
            n1234MonDsc = P009311_n1234MonDsc[0];
            A511TipSigno = P009311_A511TipSigno[0];
            n511TipSigno = P009311_n511TipSigno[0];
            A306TipAbr = P009311_A306TipAbr[0];
            n306TipAbr = P009311_n306TipAbr[0];
            A139PaiCod = P009311_A139PaiCod[0];
            n139PaiCod = P009311_n139PaiCod[0];
            A140EstCod = P009311_A140EstCod[0];
            n140EstCod = P009311_n140EstCod[0];
            A141ProvCod = P009311_A141ProvCod[0];
            n141ProvCod = P009311_n141ProvCod[0];
            A142DisCod = P009311_A142DisCod[0];
            n142DisCod = P009311_n142DisCod[0];
            A596CliDir = P009311_A596CliDir[0];
            n596CliDir = P009311_n596CliDir[0];
            A630CliTel2 = P009311_A630CliTel2[0];
            n630CliTel2 = P009311_n630CliTel2[0];
            A629CliTel1 = P009311_A629CliTel1[0];
            n629CliTel1 = P009311_n629CliTel1[0];
            A604DisDsc = P009311_A604DisDsc[0];
            AV9CCCliCod = A188CCCliCod;
            AV10CCCliDsc = StringUtil.Trim( AV9CCCliCod) + " - " + StringUtil.Trim( A189CCCliDsc);
            AV60CliDir = StringUtil.Trim( A596CliDir);
            AV59DisDsc = StringUtil.Trim( A604DisDsc);
            AV58Telf = "Telf : " + StringUtil.Trim( A629CliTel1) + (!String.IsNullOrEmpty(StringUtil.RTrim( A630CliTel2)) ? " / "+StringUtil.Trim( A630CliTel2) : "");
            AV57Vendedor = 0;
            H930( false, 35) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10CCCliDsc, "")), 8, Gx_line+2, 450, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Telf, "")), 457, Gx_line+2, 666, Gx_line+17, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60CliDir, "")), 8, Gx_line+20, 450, Gx_line+35, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59DisDsc, "")), 458, Gx_line+20, 735, Gx_line+35, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+35);
            AV49TotImporte = 0.00m;
            AV51TotPagos = 0.00m;
            AV53TotSaldo = 0.00m;
            while ( (pr_default.getStatus(9) != 101) && ( StringUtil.StrCmp(P009311_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
            {
               BRK9315 = false;
               A511TipSigno = P009311_A511TipSigno[0];
               n511TipSigno = P009311_n511TipSigno[0];
               A513CCImpTotal = P009311_A513CCImpTotal[0];
               A509CCImpPago = P009311_A509CCImpPago[0];
               A508CCFVcto = P009311_A508CCFVcto[0];
               A187CCmonCod = P009311_A187CCmonCod[0];
               A1234MonDsc = P009311_A1234MonDsc[0];
               n1234MonDsc = P009311_n1234MonDsc[0];
               A185CCDocNum = P009311_A185CCDocNum[0];
               A306TipAbr = P009311_A306TipAbr[0];
               n306TipAbr = P009311_n306TipAbr[0];
               A190CCFech = P009311_A190CCFech[0];
               A184CCTipCod = P009311_A184CCTipCod[0];
               A1234MonDsc = P009311_A1234MonDsc[0];
               n1234MonDsc = P009311_n1234MonDsc[0];
               A511TipSigno = P009311_A511TipSigno[0];
               n511TipSigno = P009311_n511TipSigno[0];
               A306TipAbr = P009311_A306TipAbr[0];
               n306TipAbr = P009311_n306TipAbr[0];
               AV33Importe = (decimal)(A513CCImpTotal*A511TipSigno);
               AV38Pagos = (decimal)(A509CCImpPago*A511TipSigno);
               AV40Saldo = (decimal)((A513CCImpTotal-A509CCImpPago)*A511TipSigno);
               AV17Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A508CCFVcto));
               AV49TotImporte = (decimal)(AV49TotImporte+AV33Importe);
               AV51TotPagos = (decimal)(AV51TotPagos+AV38Pagos);
               AV53TotSaldo = (decimal)(AV53TotSaldo+AV40Saldo);
               AV45TotalMN = (decimal)(AV45TotalMN+(((A187CCmonCod==1) ? AV40Saldo : (decimal)(0))));
               AV44TotalME = (decimal)(AV44TotalME+(((A187CCmonCod==2) ? AV40Saldo : (decimal)(0))));
               H930( false, 17) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A185CCDocNum, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A190CCFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A508CCFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 394, Gx_line+2, 451, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+2, 566, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+2, 675, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+2, 779, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17Dias), "ZZZZ9")), 308, Gx_line+2, 365, Gx_line+17, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               BRK9315 = true;
               pr_default.readNext(9);
            }
            H930( false, 24) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+6, 566, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+6, 675, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 779, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(466, Gx_line+1, 788, Gx_line+1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Cliente", 349, Gx_line+6, 424, Gx_line+20, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+24);
            AV46TotGImporte = (decimal)(AV46TotGImporte+AV49TotImporte);
            AV47TotGPagos = (decimal)(AV47TotGPagos+AV51TotPagos);
            AV48TotGSaldo = (decimal)(AV48TotGSaldo+AV53TotSaldo);
            AV50TotImpVend = (decimal)(AV50TotImpVend+AV49TotImporte);
            AV52TotPagoVend = (decimal)(AV52TotPagoVend+AV51TotPagos);
            AV54TotSaldoVend = (decimal)(AV54TotSaldoVend+AV53TotSaldo);
            if ( ! BRK9315 )
            {
               BRK9315 = true;
               pr_default.readNext(9);
            }
         }
         pr_default.close(9);
      }

      protected void S1314( )
      {
         /* 'PAGOS' Routine */
         returnInSub = false;
         /* Using cursor P009312 */
         pr_default.execute(10, new Object[] {AV13CCTipCod, AV11CCDocNum, AV23FHasta});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A166CobTip = P009312_A166CobTip[0];
            A167CobCod = P009312_A167CobCod[0];
            A661CobSts = P009312_A661CobSts[0];
            A655CobFec = P009312_A655CobFec[0];
            A176CobDocNum = P009312_A176CobDocNum[0];
            A175CobTipCod = P009312_A175CobTipCod[0];
            A172CobMon = P009312_A172CobMon[0];
            A654CobDTot = P009312_A654CobDTot[0];
            A663CobTipCam = P009312_A663CobTipCam[0];
            A173Item = P009312_A173Item[0];
            A661CobSts = P009312_A661CobSts[0];
            A655CobFec = P009312_A655CobFec[0];
            A172CobMon = P009312_A172CobMon[0];
            AV16CobMon = A172CobMon;
            AV15CobDtot = NumberUtil.Round( A654CobDTot, 2);
            if ( ( AV15CobDtot < Convert.ToDecimal( 0 )) )
            {
               AV15CobDtot = (decimal)(AV15CobDtot*-1);
            }
            if ( AV12CCmonCod == AV16CobMon )
            {
               AV38Pagos = (decimal)(AV38Pagos-AV15CobDtot);
            }
            else
            {
               if ( AV12CCmonCod == 1 )
               {
                  AV38Pagos = (decimal)(AV38Pagos-(NumberUtil.Round( AV15CobDtot*A663CobTipCam, 2)));
               }
               else
               {
                  AV38Pagos = (decimal)(AV38Pagos-(NumberUtil.Round( AV15CobDtot/ (decimal)(A663CobTipCam), 2)));
               }
            }
            pr_default.readNext(10);
         }
         pr_default.close(10);
      }

      protected void S1213( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         AV29Flag = 0;
         pr_default.dynParam(11, new Object[]{ new Object[]{
                                              AV14CliCod ,
                                              AV35MonCod ,
                                              AV43TipCod ,
                                              A188CCCliCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A190CCFech ,
                                              AV23FHasta ,
                                              A506CCEstado ,
                                              A186CCVendCod ,
                                              AV57Vendedor } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P009313 */
         pr_default.execute(11, new Object[] {AV23FHasta, AV57Vendedor, AV14CliCod, AV35MonCod, AV43TipCod});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A506CCEstado = P009313_A506CCEstado[0];
            A190CCFech = P009313_A190CCFech[0];
            A186CCVendCod = P009313_A186CCVendCod[0];
            A184CCTipCod = P009313_A184CCTipCod[0];
            A187CCmonCod = P009313_A187CCmonCod[0];
            A188CCCliCod = P009313_A188CCCliCod[0];
            A513CCImpTotal = P009313_A513CCImpTotal[0];
            A509CCImpPago = P009313_A509CCImpPago[0];
            A511TipSigno = P009313_A511TipSigno[0];
            n511TipSigno = P009313_n511TipSigno[0];
            A185CCDocNum = P009313_A185CCDocNum[0];
            A511TipSigno = P009313_A511TipSigno[0];
            n511TipSigno = P009313_n511TipSigno[0];
            AV13CCTipCod = A184CCTipCod;
            AV11CCDocNum = A185CCDocNum;
            AV33Importe = A513CCImpTotal;
            AV38Pagos = A509CCImpPago;
            AV12CCmonCod = A187CCmonCod;
            /* Execute user subroutine: 'PAGOS' */
            S1314 ();
            if ( returnInSub )
            {
               pr_default.close(11);
               returnInSub = true;
               if (true) return;
            }
            AV40Saldo = (decimal)((AV33Importe-AV38Pagos)*A511TipSigno);
            if ( ( AV40Saldo != Convert.ToDecimal( 0 )) )
            {
               AV29Flag = 1;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(11);
         }
         pr_default.close(11);
      }

      protected void H930( bool bFoot ,
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
               getPrinter().GxDrawText("T/D", 14, Gx_line+246, 37, Gx_line+260, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Documento", 71, Gx_line+247, 156, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dias Vcto", 324, Gx_line+247, 379, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 395, Gx_line+247, 443, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe Total", 473, Gx_line+247, 556, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+240, 797, Gx_line+266, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuentas por Cobrar Vendedor", 263, Gx_line+70, 515, Gx_line+90, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 174, Gx_line+247, 209, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Vcto", 236, Gx_line+247, 301, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 719, Gx_line+247, 752, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pago", 616, Gx_line+247, 646, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Documento", 189, Gx_line+131, 304, Gx_line+145, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Vendedor", 189, Gx_line+153, 246, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 189, Gx_line+175, 237, Gx_line+189, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Estado", 189, Gx_line+197, 230, Gx_line+211, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 189, Gx_line+218, 231, Gx_line+232, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro1, "")), 309, Gx_line+126, 652, Gx_line+150, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Filtro2, "")), 309, Gx_line+148, 652, Gx_line+172, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Filtro3, "")), 309, Gx_line+170, 652, Gx_line+194, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Filtro4, "")), 309, Gx_line+192, 652, Gx_line+216, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28Filtro5, "")), 309, Gx_line+213, 652, Gx_line+237, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18EmpDir, "")), 19, Gx_line+29, 404, Gx_line+47, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20EmpRUC, "")), 19, Gx_line+46, 404, Gx_line+64, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Empresa, "")), 19, Gx_line+11, 404, Gx_line+29, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 325, Gx_line+93, 355, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV23FHasta, "99/99/99"), 365, Gx_line+93, 447, Gx_line+114, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+266);
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
         AV41Session = context.GetSession();
         AV18EmpDir = "";
         AV20EmpRUC = "";
         AV39Ruta = "";
         AV34Logo = "";
         AV63Logo_GXI = "";
         AV24Filtro1 = "";
         AV25Filtro2 = "";
         AV26Filtro3 = "";
         AV27Filtro4 = "";
         AV28Filtro5 = "";
         scmdbuf = "";
         P00932_A149TipCod = new string[] {""} ;
         P00932_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         P00933_A309VenCod = new int[1] ;
         P00933_A2045VenDsc = new string[] {""} ;
         P00933_n2045VenDsc = new bool[] {false} ;
         A2045VenDsc = "";
         P00934_A180MonCod = new int[1] ;
         P00934_A1234MonDsc = new string[] {""} ;
         P00934_n1234MonDsc = new bool[] {false} ;
         A1234MonDsc = "";
         AV22EstCod = "";
         P00935_A140EstCod = new string[] {""} ;
         P00935_n140EstCod = new bool[] {false} ;
         P00935_A602EstDsc = new string[] {""} ;
         P00935_A139PaiCod = new string[] {""} ;
         P00935_n139PaiCod = new bool[] {false} ;
         A140EstCod = "";
         A602EstDsc = "";
         A139PaiCod = "";
         P00936_A45CliCod = new string[] {""} ;
         P00936_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         A188CCCliCod = "";
         P00937_A188CCCliCod = new string[] {""} ;
         P00937_A186CCVendCod = new int[1] ;
         P00937_A2045VenDsc = new string[] {""} ;
         P00937_n2045VenDsc = new bool[] {false} ;
         P00937_A184CCTipCod = new string[] {""} ;
         P00937_A185CCDocNum = new string[] {""} ;
         A184CCTipCod = "";
         A185CCDocNum = "";
         P00938_A188CCCliCod = new string[] {""} ;
         P00938_A186CCVendCod = new int[1] ;
         P00938_A2045VenDsc = new string[] {""} ;
         P00938_n2045VenDsc = new bool[] {false} ;
         P00938_A184CCTipCod = new string[] {""} ;
         P00938_A185CCDocNum = new string[] {""} ;
         AV37MonMN = "";
         AV36MonME = "";
         P00939_A1234MonDsc = new string[] {""} ;
         P00939_n1234MonDsc = new bool[] {false} ;
         P00939_A180MonCod = new int[1] ;
         A190CCFech = DateTime.MinValue;
         A506CCEstado = "";
         P009310_A139PaiCod = new string[] {""} ;
         P009310_n139PaiCod = new bool[] {false} ;
         P009310_A140EstCod = new string[] {""} ;
         P009310_n140EstCod = new bool[] {false} ;
         P009310_A141ProvCod = new string[] {""} ;
         P009310_n141ProvCod = new bool[] {false} ;
         P009310_A142DisCod = new string[] {""} ;
         P009310_n142DisCod = new bool[] {false} ;
         P009310_A189CCCliDsc = new string[] {""} ;
         P009310_A185CCDocNum = new string[] {""} ;
         P009310_A511TipSigno = new short[1] ;
         P009310_n511TipSigno = new bool[] {false} ;
         P009310_A513CCImpTotal = new decimal[1] ;
         P009310_A509CCImpPago = new decimal[1] ;
         P009310_A187CCmonCod = new int[1] ;
         P009310_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P009310_A1234MonDsc = new string[] {""} ;
         P009310_n1234MonDsc = new bool[] {false} ;
         P009310_A306TipAbr = new string[] {""} ;
         P009310_n306TipAbr = new bool[] {false} ;
         P009310_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P009310_A184CCTipCod = new string[] {""} ;
         P009310_A506CCEstado = new string[] {""} ;
         P009310_A186CCVendCod = new int[1] ;
         P009310_A188CCCliCod = new string[] {""} ;
         P009310_A596CliDir = new string[] {""} ;
         P009310_n596CliDir = new bool[] {false} ;
         P009310_A604DisDsc = new string[] {""} ;
         P009310_A630CliTel2 = new string[] {""} ;
         P009310_n630CliTel2 = new bool[] {false} ;
         P009310_A629CliTel1 = new string[] {""} ;
         P009310_n629CliTel1 = new bool[] {false} ;
         A141ProvCod = "";
         A142DisCod = "";
         A189CCCliDsc = "";
         A508CCFVcto = DateTime.MinValue;
         A306TipAbr = "";
         A596CliDir = "";
         A604DisDsc = "";
         A630CliTel2 = "";
         A629CliTel1 = "";
         AV9CCCliCod = "";
         AV10CCCliDsc = "";
         AV60CliDir = "";
         AV59DisDsc = "";
         AV58Telf = "";
         AV13CCTipCod = "";
         AV11CCDocNum = "";
         P009311_A139PaiCod = new string[] {""} ;
         P009311_n139PaiCod = new bool[] {false} ;
         P009311_A140EstCod = new string[] {""} ;
         P009311_n140EstCod = new bool[] {false} ;
         P009311_A141ProvCod = new string[] {""} ;
         P009311_n141ProvCod = new bool[] {false} ;
         P009311_A142DisCod = new string[] {""} ;
         P009311_n142DisCod = new bool[] {false} ;
         P009311_A189CCCliDsc = new string[] {""} ;
         P009311_A511TipSigno = new short[1] ;
         P009311_n511TipSigno = new bool[] {false} ;
         P009311_A513CCImpTotal = new decimal[1] ;
         P009311_A509CCImpPago = new decimal[1] ;
         P009311_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P009311_A187CCmonCod = new int[1] ;
         P009311_A1234MonDsc = new string[] {""} ;
         P009311_n1234MonDsc = new bool[] {false} ;
         P009311_A185CCDocNum = new string[] {""} ;
         P009311_A306TipAbr = new string[] {""} ;
         P009311_n306TipAbr = new bool[] {false} ;
         P009311_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P009311_A184CCTipCod = new string[] {""} ;
         P009311_A506CCEstado = new string[] {""} ;
         P009311_A186CCVendCod = new int[1] ;
         P009311_A188CCCliCod = new string[] {""} ;
         P009311_A596CliDir = new string[] {""} ;
         P009311_n596CliDir = new bool[] {false} ;
         P009311_A604DisDsc = new string[] {""} ;
         P009311_A630CliTel2 = new string[] {""} ;
         P009311_n630CliTel2 = new bool[] {false} ;
         P009311_A629CliTel1 = new string[] {""} ;
         P009311_n629CliTel1 = new bool[] {false} ;
         P009312_A166CobTip = new string[] {""} ;
         P009312_A167CobCod = new string[] {""} ;
         P009312_A661CobSts = new string[] {""} ;
         P009312_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         P009312_A176CobDocNum = new string[] {""} ;
         P009312_A175CobTipCod = new string[] {""} ;
         P009312_A172CobMon = new int[1] ;
         P009312_A654CobDTot = new decimal[1] ;
         P009312_A663CobTipCam = new decimal[1] ;
         P009312_A173Item = new int[1] ;
         A166CobTip = "";
         A167CobCod = "";
         A661CobSts = "";
         A655CobFec = DateTime.MinValue;
         A176CobDocNum = "";
         A175CobTipCod = "";
         P009313_A506CCEstado = new string[] {""} ;
         P009313_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P009313_A186CCVendCod = new int[1] ;
         P009313_A184CCTipCod = new string[] {""} ;
         P009313_A187CCmonCod = new int[1] ;
         P009313_A188CCCliCod = new string[] {""} ;
         P009313_A513CCImpTotal = new decimal[1] ;
         P009313_A509CCImpPago = new decimal[1] ;
         P009313_A511TipSigno = new short[1] ;
         P009313_n511TipSigno = new bool[] {false} ;
         P009313_A185CCDocNum = new string[] {""} ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrcuentasxcobrarvendedor__default(),
            new Object[][] {
                new Object[] {
               P00932_A149TipCod, P00932_A1910TipDsc
               }
               , new Object[] {
               P00933_A309VenCod, P00933_A2045VenDsc
               }
               , new Object[] {
               P00934_A180MonCod, P00934_A1234MonDsc
               }
               , new Object[] {
               P00935_A140EstCod, P00935_A602EstDsc, P00935_A139PaiCod
               }
               , new Object[] {
               P00936_A45CliCod, P00936_A161CliDsc
               }
               , new Object[] {
               P00937_A188CCCliCod, P00937_A186CCVendCod, P00937_A2045VenDsc, P00937_n2045VenDsc, P00937_A184CCTipCod, P00937_A185CCDocNum
               }
               , new Object[] {
               P00938_A188CCCliCod, P00938_A186CCVendCod, P00938_A2045VenDsc, P00938_n2045VenDsc, P00938_A184CCTipCod, P00938_A185CCDocNum
               }
               , new Object[] {
               P00939_A1234MonDsc, P00939_A180MonCod
               }
               , new Object[] {
               P009310_A139PaiCod, P009310_n139PaiCod, P009310_A140EstCod, P009310_n140EstCod, P009310_A141ProvCod, P009310_n141ProvCod, P009310_A142DisCod, P009310_n142DisCod, P009310_A189CCCliDsc, P009310_A185CCDocNum,
               P009310_A511TipSigno, P009310_n511TipSigno, P009310_A513CCImpTotal, P009310_A509CCImpPago, P009310_A187CCmonCod, P009310_A508CCFVcto, P009310_A1234MonDsc, P009310_n1234MonDsc, P009310_A306TipAbr, P009310_n306TipAbr,
               P009310_A190CCFech, P009310_A184CCTipCod, P009310_A506CCEstado, P009310_A186CCVendCod, P009310_A188CCCliCod, P009310_A596CliDir, P009310_n596CliDir, P009310_A604DisDsc, P009310_A630CliTel2, P009310_n630CliTel2,
               P009310_A629CliTel1, P009310_n629CliTel1
               }
               , new Object[] {
               P009311_A139PaiCod, P009311_n139PaiCod, P009311_A140EstCod, P009311_n140EstCod, P009311_A141ProvCod, P009311_n141ProvCod, P009311_A142DisCod, P009311_n142DisCod, P009311_A189CCCliDsc, P009311_A511TipSigno,
               P009311_n511TipSigno, P009311_A513CCImpTotal, P009311_A509CCImpPago, P009311_A508CCFVcto, P009311_A187CCmonCod, P009311_A1234MonDsc, P009311_n1234MonDsc, P009311_A185CCDocNum, P009311_A306TipAbr, P009311_n306TipAbr,
               P009311_A190CCFech, P009311_A184CCTipCod, P009311_A506CCEstado, P009311_A186CCVendCod, P009311_A188CCCliCod, P009311_A596CliDir, P009311_n596CliDir, P009311_A604DisDsc, P009311_A630CliTel2, P009311_n630CliTel2,
               P009311_A629CliTel1, P009311_n629CliTel1
               }
               , new Object[] {
               P009312_A166CobTip, P009312_A167CobCod, P009312_A661CobSts, P009312_A655CobFec, P009312_A176CobDocNum, P009312_A175CobTipCod, P009312_A172CobMon, P009312_A654CobDTot, P009312_A663CobTipCam, P009312_A173Item
               }
               , new Object[] {
               P009313_A506CCEstado, P009313_A190CCFech, P009313_A186CCVendCod, P009313_A184CCTipCod, P009313_A187CCmonCod, P009313_A188CCCliCod, P009313_A513CCImpTotal, P009313_A509CCImpPago, P009313_A511TipSigno, P009313_n511TipSigno,
               P009313_A185CCDocNum
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
      private short AV30FlaVend ;
      private short AV29Flag ;
      private short A511TipSigno ;
      private int AV35MonCod ;
      private int AV55VenCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A309VenCod ;
      private int A180MonCod ;
      private int A186CCVendCod ;
      private int AV56VendeCod ;
      private int AV57Vendedor ;
      private int Gx_OldLine ;
      private int A187CCmonCod ;
      private int AV12CCmonCod ;
      private int AV17Dias ;
      private int A172CobMon ;
      private int A173Item ;
      private int AV16CobMon ;
      private decimal AV46TotGImporte ;
      private decimal AV47TotGPagos ;
      private decimal AV48TotGSaldo ;
      private decimal AV44TotalME ;
      private decimal AV45TotalMN ;
      private decimal AV50TotImpVend ;
      private decimal AV52TotPagoVend ;
      private decimal AV54TotSaldoVend ;
      private decimal A513CCImpTotal ;
      private decimal A509CCImpPago ;
      private decimal AV49TotImporte ;
      private decimal AV51TotPagos ;
      private decimal AV53TotSaldo ;
      private decimal AV33Importe ;
      private decimal AV38Pagos ;
      private decimal AV40Saldo ;
      private decimal A654CobDTot ;
      private decimal A663CobTipCam ;
      private decimal AV15CobDtot ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV43TipCod ;
      private string AV14CliCod ;
      private string AV19Empresa ;
      private string AV18EmpDir ;
      private string AV20EmpRUC ;
      private string AV39Ruta ;
      private string AV24Filtro1 ;
      private string AV25Filtro2 ;
      private string AV26Filtro3 ;
      private string AV27Filtro4 ;
      private string AV28Filtro5 ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A1910TipDsc ;
      private string A2045VenDsc ;
      private string A1234MonDsc ;
      private string AV22EstCod ;
      private string A140EstCod ;
      private string A602EstDsc ;
      private string A139PaiCod ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A188CCCliCod ;
      private string A184CCTipCod ;
      private string A185CCDocNum ;
      private string AV37MonMN ;
      private string AV36MonME ;
      private string A506CCEstado ;
      private string A141ProvCod ;
      private string A142DisCod ;
      private string A189CCCliDsc ;
      private string A306TipAbr ;
      private string A596CliDir ;
      private string A604DisDsc ;
      private string A630CliTel2 ;
      private string A629CliTel1 ;
      private string AV9CCCliCod ;
      private string AV10CCCliDsc ;
      private string AV60CliDir ;
      private string AV59DisDsc ;
      private string AV13CCTipCod ;
      private string AV11CCDocNum ;
      private string A166CobTip ;
      private string A167CobCod ;
      private string A661CobSts ;
      private string A176CobDocNum ;
      private string A175CobTipCod ;
      private string Gx_time ;
      private DateTime AV23FHasta ;
      private DateTime A190CCFech ;
      private DateTime A508CCFVcto ;
      private DateTime A655CobFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n2045VenDsc ;
      private bool n1234MonDsc ;
      private bool n140EstCod ;
      private bool n139PaiCod ;
      private bool BRK938 ;
      private bool returnInSub ;
      private bool BRK9310 ;
      private bool BRK9313 ;
      private bool n141ProvCod ;
      private bool n142DisCod ;
      private bool n511TipSigno ;
      private bool n306TipAbr ;
      private bool n596CliDir ;
      private bool n630CliTel2 ;
      private bool n629CliTel1 ;
      private bool BRK9315 ;
      private string AV63Logo_GXI ;
      private string AV58Telf ;
      private string AV34Logo ;
      private IGxSession AV41Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_TipCod ;
      private string aP1_CliCod ;
      private int aP2_MonCod ;
      private int aP3_VenCod ;
      private DateTime aP4_FHasta ;
      private IDataStoreProvider pr_default ;
      private string[] P00932_A149TipCod ;
      private string[] P00932_A1910TipDsc ;
      private int[] P00933_A309VenCod ;
      private string[] P00933_A2045VenDsc ;
      private bool[] P00933_n2045VenDsc ;
      private int[] P00934_A180MonCod ;
      private string[] P00934_A1234MonDsc ;
      private bool[] P00934_n1234MonDsc ;
      private string[] P00935_A140EstCod ;
      private bool[] P00935_n140EstCod ;
      private string[] P00935_A602EstDsc ;
      private string[] P00935_A139PaiCod ;
      private bool[] P00935_n139PaiCod ;
      private string[] P00936_A45CliCod ;
      private string[] P00936_A161CliDsc ;
      private string[] P00937_A188CCCliCod ;
      private int[] P00937_A186CCVendCod ;
      private string[] P00937_A2045VenDsc ;
      private bool[] P00937_n2045VenDsc ;
      private string[] P00937_A184CCTipCod ;
      private string[] P00937_A185CCDocNum ;
      private string[] P00938_A188CCCliCod ;
      private int[] P00938_A186CCVendCod ;
      private string[] P00938_A2045VenDsc ;
      private bool[] P00938_n2045VenDsc ;
      private string[] P00938_A184CCTipCod ;
      private string[] P00938_A185CCDocNum ;
      private string[] P00939_A1234MonDsc ;
      private bool[] P00939_n1234MonDsc ;
      private int[] P00939_A180MonCod ;
      private string[] P009310_A139PaiCod ;
      private bool[] P009310_n139PaiCod ;
      private string[] P009310_A140EstCod ;
      private bool[] P009310_n140EstCod ;
      private string[] P009310_A141ProvCod ;
      private bool[] P009310_n141ProvCod ;
      private string[] P009310_A142DisCod ;
      private bool[] P009310_n142DisCod ;
      private string[] P009310_A189CCCliDsc ;
      private string[] P009310_A185CCDocNum ;
      private short[] P009310_A511TipSigno ;
      private bool[] P009310_n511TipSigno ;
      private decimal[] P009310_A513CCImpTotal ;
      private decimal[] P009310_A509CCImpPago ;
      private int[] P009310_A187CCmonCod ;
      private DateTime[] P009310_A508CCFVcto ;
      private string[] P009310_A1234MonDsc ;
      private bool[] P009310_n1234MonDsc ;
      private string[] P009310_A306TipAbr ;
      private bool[] P009310_n306TipAbr ;
      private DateTime[] P009310_A190CCFech ;
      private string[] P009310_A184CCTipCod ;
      private string[] P009310_A506CCEstado ;
      private int[] P009310_A186CCVendCod ;
      private string[] P009310_A188CCCliCod ;
      private string[] P009310_A596CliDir ;
      private bool[] P009310_n596CliDir ;
      private string[] P009310_A604DisDsc ;
      private string[] P009310_A630CliTel2 ;
      private bool[] P009310_n630CliTel2 ;
      private string[] P009310_A629CliTel1 ;
      private bool[] P009310_n629CliTel1 ;
      private string[] P009311_A139PaiCod ;
      private bool[] P009311_n139PaiCod ;
      private string[] P009311_A140EstCod ;
      private bool[] P009311_n140EstCod ;
      private string[] P009311_A141ProvCod ;
      private bool[] P009311_n141ProvCod ;
      private string[] P009311_A142DisCod ;
      private bool[] P009311_n142DisCod ;
      private string[] P009311_A189CCCliDsc ;
      private short[] P009311_A511TipSigno ;
      private bool[] P009311_n511TipSigno ;
      private decimal[] P009311_A513CCImpTotal ;
      private decimal[] P009311_A509CCImpPago ;
      private DateTime[] P009311_A508CCFVcto ;
      private int[] P009311_A187CCmonCod ;
      private string[] P009311_A1234MonDsc ;
      private bool[] P009311_n1234MonDsc ;
      private string[] P009311_A185CCDocNum ;
      private string[] P009311_A306TipAbr ;
      private bool[] P009311_n306TipAbr ;
      private DateTime[] P009311_A190CCFech ;
      private string[] P009311_A184CCTipCod ;
      private string[] P009311_A506CCEstado ;
      private int[] P009311_A186CCVendCod ;
      private string[] P009311_A188CCCliCod ;
      private string[] P009311_A596CliDir ;
      private bool[] P009311_n596CliDir ;
      private string[] P009311_A604DisDsc ;
      private string[] P009311_A630CliTel2 ;
      private bool[] P009311_n630CliTel2 ;
      private string[] P009311_A629CliTel1 ;
      private bool[] P009311_n629CliTel1 ;
      private string[] P009312_A166CobTip ;
      private string[] P009312_A167CobCod ;
      private string[] P009312_A661CobSts ;
      private DateTime[] P009312_A655CobFec ;
      private string[] P009312_A176CobDocNum ;
      private string[] P009312_A175CobTipCod ;
      private int[] P009312_A172CobMon ;
      private decimal[] P009312_A654CobDTot ;
      private decimal[] P009312_A663CobTipCam ;
      private int[] P009312_A173Item ;
      private string[] P009313_A506CCEstado ;
      private DateTime[] P009313_A190CCFech ;
      private int[] P009313_A186CCVendCod ;
      private string[] P009313_A184CCTipCod ;
      private int[] P009313_A187CCmonCod ;
      private string[] P009313_A188CCCliCod ;
      private decimal[] P009313_A513CCImpTotal ;
      private decimal[] P009313_A509CCImpPago ;
      private short[] P009313_A511TipSigno ;
      private bool[] P009313_n511TipSigno ;
      private string[] P009313_A185CCDocNum ;
   }

   public class rrcuentasxcobrarvendedor__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00937( IGxContext context ,
                                             int AV55VenCod ,
                                             string AV14CliCod ,
                                             int A186CCVendCod ,
                                             string A188CCCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliCod] AS CCCliCod, T1.[CCVendCod] AS CCVendCod, T2.[VenDsc], T1.[CCTipCod] AS CCTipCod, T1.[CCDocNum] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[CCVendCod])";
         AddWhere(sWhereString, "(T1.[CCVendCod] <> 0)");
         if ( ! (0==AV55VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV55VenCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV14CliCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCVendCod], T1.[CCCliCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00938( IGxContext context ,
                                             int AV55VenCod ,
                                             string AV14CliCod ,
                                             int A186CCVendCod ,
                                             string A188CCCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliCod] AS CCCliCod, T1.[CCVendCod] AS CCVendCod, T2.[VenDsc], T1.[CCTipCod] AS CCTipCod, T1.[CCDocNum] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[CCVendCod])";
         if ( ! (0==AV55VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV55VenCod)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV14CliCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCVendCod], T1.[CCCliCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P009310( IGxContext context ,
                                              string AV14CliCod ,
                                              int AV35MonCod ,
                                              string AV43TipCod ,
                                              string A188CCCliCod ,
                                              int A187CCmonCod ,
                                              string A184CCTipCod ,
                                              DateTime A190CCFech ,
                                              DateTime AV23FHasta ,
                                              string A506CCEstado ,
                                              int A186CCVendCod ,
                                              int AV57Vendedor )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[5];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T4.[PaiCod], T4.[EstCod], T4.[ProvCod], T4.[DisCod], T1.[CCCliDsc], T1.[CCDocNum], T3.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCmonCod] AS CCmonCod, T1.[CCFVcto], T2.[MonDsc], T3.[TipAbr], T1.[CCFech], T1.[CCTipCod] AS CCTipCod, T1.[CCEstado], T1.[CCVendCod] AS CCVendCod, T1.[CCCliCod] AS CCCliCod, T4.[CliDir], T5.[DisDsc], T4.[CliTel2], T4.[CliTel1] FROM (((([CLCUENTACOBRAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[CCCliCod]) LEFT JOIN [CDISTRITOS] T5 ON T5.[PaiCod] = T4.[PaiCod] AND T5.[EstCod] = T4.[EstCod] AND T5.[ProvCod] = T4.[ProvCod] AND T5.[DisCod] = T4.[DisCod])";
         AddWhere(sWhereString, "(T1.[CCFech] <= @AV23FHasta)");
         AddWhere(sWhereString, "(T1.[CCEstado] <> 'A')");
         AddWhere(sWhereString, "(T1.[CCVendCod] = @AV57Vendedor)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV14CliCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV35MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV35MonCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV43TipCod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCTipCod], T1.[CCFech] DESC";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P009311( IGxContext context ,
                                              string AV14CliCod ,
                                              int AV35MonCod ,
                                              string AV43TipCod ,
                                              string A188CCCliCod ,
                                              int A187CCmonCod ,
                                              string A184CCTipCod ,
                                              int A186CCVendCod ,
                                              int AV57Vendedor ,
                                              string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[4];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T4.[PaiCod], T4.[EstCod], T4.[ProvCod], T4.[DisCod], T1.[CCCliDsc], T3.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCFVcto], T1.[CCmonCod] AS CCmonCod, T2.[MonDsc], T1.[CCDocNum], T3.[TipAbr], T1.[CCFech], T1.[CCTipCod] AS CCTipCod, T1.[CCEstado], T1.[CCVendCod] AS CCVendCod, T1.[CCCliCod] AS CCCliCod, T4.[CliDir], T5.[DisDsc], T4.[CliTel2], T4.[CliTel1] FROM (((([CLCUENTACOBRAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[CCCliCod]) LEFT JOIN [CDISTRITOS] T5 ON T5.[PaiCod] = T4.[PaiCod] AND T5.[EstCod] = T4.[EstCod] AND T5.[ProvCod] = T4.[ProvCod] AND T5.[DisCod] = T4.[DisCod])";
         AddWhere(sWhereString, "(T1.[CCVendCod] = @AV57Vendedor)");
         AddWhere(sWhereString, "(T1.[CCEstado] = '')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV14CliCod)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (0==AV35MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV35MonCod)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV43TipCod)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCTipCod], T1.[CCFech] DESC";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P009313( IGxContext context ,
                                              string AV14CliCod ,
                                              int AV35MonCod ,
                                              string AV43TipCod ,
                                              string A188CCCliCod ,
                                              int A187CCmonCod ,
                                              string A184CCTipCod ,
                                              DateTime A190CCFech ,
                                              DateTime AV23FHasta ,
                                              string A506CCEstado ,
                                              int A186CCVendCod ,
                                              int AV57Vendedor )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[5];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.[CCEstado], T1.[CCFech], T1.[CCVendCod] AS CCVendCod, T1.[CCTipCod] AS CCTipCod, T1.[CCmonCod] AS CCmonCod, T1.[CCCliCod] AS CCCliCod, T1.[CCImpTotal], T1.[CCImpPago], T2.[TipSigno], T1.[CCDocNum] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CCTipCod])";
         AddWhere(sWhereString, "(T1.[CCFech] <= @AV23FHasta)");
         AddWhere(sWhereString, "(T1.[CCEstado] <> 'A')");
         AddWhere(sWhereString, "(T1.[CCVendCod] = @AV57Vendedor)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV14CliCod)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! (0==AV35MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV35MonCod)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV43TipCod)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCTipCod], T1.[CCDocNum]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 5 :
                     return conditional_P00937(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] );
               case 6 :
                     return conditional_P00938(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] );
               case 8 :
                     return conditional_P009310(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
               case 9 :
                     return conditional_P009311(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] );
               case 11 :
                     return conditional_P009313(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00932;
          prmP00932 = new Object[] {
          new ParDef("@AV43TipCod",GXType.NChar,3,0)
          };
          Object[] prmP00933;
          prmP00933 = new Object[] {
          new ParDef("@AV55VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00934;
          prmP00934 = new Object[] {
          new ParDef("@AV35MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00935;
          prmP00935 = new Object[] {
          new ParDef("@AV22EstCod",GXType.NChar,4,0)
          };
          Object[] prmP00936;
          prmP00936 = new Object[] {
          new ParDef("@AV14CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00939;
          prmP00939 = new Object[] {
          };
          Object[] prmP009312;
          prmP009312 = new Object[] {
          new ParDef("@AV13CCTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV11CCDocNum",GXType.NChar,12,0) ,
          new ParDef("@AV23FHasta",GXType.Date,8,0)
          };
          Object[] prmP00937;
          prmP00937 = new Object[] {
          new ParDef("@AV55VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV14CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00938;
          prmP00938 = new Object[] {
          new ParDef("@AV55VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV14CliCod",GXType.NChar,20,0)
          };
          Object[] prmP009310;
          prmP009310 = new Object[] {
          new ParDef("@AV23FHasta",GXType.Date,8,0) ,
          new ParDef("@AV57Vendedor",GXType.Int32,6,0) ,
          new ParDef("@AV14CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV35MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV43TipCod",GXType.NChar,3,0)
          };
          Object[] prmP009311;
          prmP009311 = new Object[] {
          new ParDef("@AV57Vendedor",GXType.Int32,6,0) ,
          new ParDef("@AV14CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV35MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV43TipCod",GXType.NChar,3,0)
          };
          Object[] prmP009313;
          prmP009313 = new Object[] {
          new ParDef("@AV23FHasta",GXType.Date,8,0) ,
          new ParDef("@AV57Vendedor",GXType.Int32,6,0) ,
          new ParDef("@AV14CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV35MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV43TipCod",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00932", "SELECT [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipCod] = @AV43TipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00932,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00933", "SELECT [VenCod], [VenDsc] FROM [CVENDEDORES] WHERE [VenCod] = @AV55VenCod ORDER BY [VenCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00933,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00934", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV35MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00934,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00935", "SELECT [EstCod], [EstDsc], [PaiCod] FROM [CESTADOS] WHERE [EstCod] = @AV22EstCod ORDER BY [PaiCod], [EstCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00935,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00936", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV14CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00936,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00937", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00937,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00938", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00938,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00939", "SELECT [MonDsc], [MonCod] FROM [CMONEDAS] ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00939,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009310", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009310,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009311", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009311,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009312", "SELECT T1.[CobTip], T1.[CobCod], T2.[CobSts], T2.[CobFec], T1.[CobDocNum], T1.[CobTipCod], T2.[CobMon], T1.[CobDTot], T1.[CobTipCam], T1.[Item] FROM ([CLCOBRANZADET] T1 INNER JOIN [CLCOBRANZA] T2 ON T2.[CobTip] = T1.[CobTip] AND T2.[CobCod] = T1.[CobCod]) WHERE (T1.[CobTipCod] = @AV13CCTipCod and T1.[CobDocNum] = @AV11CCDocNum) AND (T2.[CobFec] > @AV23FHasta) AND (T2.[CobSts] <> 'A') ORDER BY T1.[CobTipCod], T1.[CobDocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009312,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009313", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009313,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((string[]) buf[5])[0] = rslt.getString(5, 12);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((string[]) buf[5])[0] = rslt.getString(5, 12);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 4);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 4);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 100);
                ((string[]) buf[9])[0] = rslt.getString(6, 12);
                ((short[]) buf[10])[0] = rslt.getShort(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(9);
                ((int[]) buf[14])[0] = rslt.getInt(10);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 100);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getString(13, 5);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(14);
                ((string[]) buf[21])[0] = rslt.getString(15, 3);
                ((string[]) buf[22])[0] = rslt.getString(16, 1);
                ((int[]) buf[23])[0] = rslt.getInt(17);
                ((string[]) buf[24])[0] = rslt.getString(18, 20);
                ((string[]) buf[25])[0] = rslt.getString(19, 100);
                ((bool[]) buf[26])[0] = rslt.wasNull(19);
                ((string[]) buf[27])[0] = rslt.getString(20, 100);
                ((string[]) buf[28])[0] = rslt.getString(21, 20);
                ((bool[]) buf[29])[0] = rslt.wasNull(21);
                ((string[]) buf[30])[0] = rslt.getString(22, 20);
                ((bool[]) buf[31])[0] = rslt.wasNull(22);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 4);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 4);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 100);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(8);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
                ((int[]) buf[14])[0] = rslt.getInt(10);
                ((string[]) buf[15])[0] = rslt.getString(11, 100);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((string[]) buf[17])[0] = rslt.getString(12, 12);
                ((string[]) buf[18])[0] = rslt.getString(13, 5);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(14);
                ((string[]) buf[21])[0] = rslt.getString(15, 3);
                ((string[]) buf[22])[0] = rslt.getString(16, 1);
                ((int[]) buf[23])[0] = rslt.getInt(17);
                ((string[]) buf[24])[0] = rslt.getString(18, 20);
                ((string[]) buf[25])[0] = rslt.getString(19, 100);
                ((bool[]) buf[26])[0] = rslt.wasNull(19);
                ((string[]) buf[27])[0] = rslt.getString(20, 100);
                ((string[]) buf[28])[0] = rslt.getString(21, 20);
                ((bool[]) buf[29])[0] = rslt.wasNull(21);
                ((string[]) buf[30])[0] = rslt.getString(22, 20);
                ((bool[]) buf[31])[0] = rslt.wasNull(22);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 12);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 12);
                return;
       }
    }

 }

}
