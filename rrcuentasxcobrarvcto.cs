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
   public class rrcuentasxcobrarvcto : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrcuentasxcobrarvcto.aspx")), "rrcuentasxcobrarvcto.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrcuentasxcobrarvcto.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "TipCCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV41TipCCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12CliCod = GetPar( "CliCod");
                  AV42TipCod = GetPar( "TipCod");
                  AV34MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV22FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV23FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV51VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
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

      public rrcuentasxcobrarvcto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrcuentasxcobrarvcto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TipCCod ,
                           ref string aP1_CliCod ,
                           ref string aP2_TipCod ,
                           ref int aP3_MonCod ,
                           ref DateTime aP4_FDesde ,
                           ref DateTime aP5_FHasta ,
                           ref int aP6_VenCod )
      {
         this.AV41TipCCod = aP0_TipCCod;
         this.AV12CliCod = aP1_CliCod;
         this.AV42TipCod = aP2_TipCod;
         this.AV34MonCod = aP3_MonCod;
         this.AV22FDesde = aP4_FDesde;
         this.AV23FHasta = aP5_FHasta;
         this.AV51VenCod = aP6_VenCod;
         initialize();
         executePrivate();
         aP0_TipCCod=this.AV41TipCCod;
         aP1_CliCod=this.AV12CliCod;
         aP2_TipCod=this.AV42TipCod;
         aP3_MonCod=this.AV34MonCod;
         aP4_FDesde=this.AV22FDesde;
         aP5_FHasta=this.AV23FHasta;
         aP6_VenCod=this.AV51VenCod;
      }

      public int executeUdp( ref int aP0_TipCCod ,
                             ref string aP1_CliCod ,
                             ref string aP2_TipCod ,
                             ref int aP3_MonCod ,
                             ref DateTime aP4_FDesde ,
                             ref DateTime aP5_FHasta )
      {
         execute(ref aP0_TipCCod, ref aP1_CliCod, ref aP2_TipCod, ref aP3_MonCod, ref aP4_FDesde, ref aP5_FHasta, ref aP6_VenCod);
         return AV51VenCod ;
      }

      public void executeSubmit( ref int aP0_TipCCod ,
                                 ref string aP1_CliCod ,
                                 ref string aP2_TipCod ,
                                 ref int aP3_MonCod ,
                                 ref DateTime aP4_FDesde ,
                                 ref DateTime aP5_FHasta ,
                                 ref int aP6_VenCod )
      {
         rrcuentasxcobrarvcto objrrcuentasxcobrarvcto;
         objrrcuentasxcobrarvcto = new rrcuentasxcobrarvcto();
         objrrcuentasxcobrarvcto.AV41TipCCod = aP0_TipCCod;
         objrrcuentasxcobrarvcto.AV12CliCod = aP1_CliCod;
         objrrcuentasxcobrarvcto.AV42TipCod = aP2_TipCod;
         objrrcuentasxcobrarvcto.AV34MonCod = aP3_MonCod;
         objrrcuentasxcobrarvcto.AV22FDesde = aP4_FDesde;
         objrrcuentasxcobrarvcto.AV23FHasta = aP5_FHasta;
         objrrcuentasxcobrarvcto.AV51VenCod = aP6_VenCod;
         objrrcuentasxcobrarvcto.context.SetSubmitInitialConfig(context);
         objrrcuentasxcobrarvcto.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrcuentasxcobrarvcto);
         aP0_TipCCod=this.AV41TipCCod;
         aP1_CliCod=this.AV12CliCod;
         aP2_TipCod=this.AV42TipCod;
         aP3_MonCod=this.AV34MonCod;
         aP4_FDesde=this.AV22FDesde;
         aP5_FHasta=this.AV23FHasta;
         aP6_VenCod=this.AV51VenCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrcuentasxcobrarvcto)stateInfo).executePrivate();
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
            AV18Empresa = AV40Session.Get("Empresa");
            AV17EmpDir = AV40Session.Get("EmpDir");
            AV19EmpRUC = AV40Session.Get("EmpRUC");
            AV38Ruta = AV40Session.Get("RUTA") + "/Logo.jpg";
            AV33Logo = AV38Ruta;
            AV54Logo_GXI = GXDbFile.PathToUrl( AV38Ruta);
            AV24Filtro1 = "Todos";
            AV25Filtro2 = "Todos";
            AV26Filtro3 = "Todos";
            AV27Filtro4 = "Todos";
            /* Using cursor P00922 */
            pr_default.execute(0, new Object[] {AV42TipCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A149TipCod = P00922_A149TipCod[0];
               A1910TipDsc = P00922_A1910TipDsc[0];
               AV24Filtro1 = A1910TipDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00923 */
            pr_default.execute(1, new Object[] {AV41TipCCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A159TipCCod = P00923_A159TipCCod[0];
               n159TipCCod = P00923_n159TipCCod[0];
               A1905TipCDsc = P00923_A1905TipCDsc[0];
               AV25Filtro2 = A1905TipCDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00924 */
            pr_default.execute(2, new Object[] {AV34MonCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A180MonCod = P00924_A180MonCod[0];
               A1234MonDsc = P00924_A1234MonDsc[0];
               n1234MonDsc = P00924_n1234MonDsc[0];
               AV26Filtro3 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P00925 */
            pr_default.execute(3, new Object[] {AV12CliCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A45CliCod = P00925_A45CliCod[0];
               A161CliDsc = P00925_A161CliDsc[0];
               AV27Filtro4 = A161CliDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            AV45TotGImporte = 0.00m;
            AV46TotGPagos = 0.00m;
            AV47TotGSaldo = 0.00m;
            AV43TotalME = 0.00m;
            AV44TotalMN = 0.00m;
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 AV12CliCod ,
                                                 AV41TipCCod ,
                                                 AV34MonCod ,
                                                 AV42TipCod ,
                                                 AV51VenCod ,
                                                 A188CCCliCod ,
                                                 A159TipCCod ,
                                                 A187CCmonCod ,
                                                 A184CCTipCod ,
                                                 A186CCVendCod ,
                                                 A508CCFVcto ,
                                                 AV22FDesde ,
                                                 AV23FHasta ,
                                                 A506CCEstado } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00926 */
            pr_default.execute(4, new Object[] {AV22FDesde, AV23FHasta, AV12CliCod, AV41TipCCod, AV34MonCod, AV42TipCod, AV51VenCod});
            while ( (pr_default.getStatus(4) != 101) )
            {
               BRK927 = false;
               A189CCCliDsc = P00926_A189CCCliDsc[0];
               A511TipSigno = P00926_A511TipSigno[0];
               n511TipSigno = P00926_n511TipSigno[0];
               A513CCImpTotal = P00926_A513CCImpTotal[0];
               A509CCImpPago = P00926_A509CCImpPago[0];
               A508CCFVcto = P00926_A508CCFVcto[0];
               A187CCmonCod = P00926_A187CCmonCod[0];
               A1234MonDsc = P00926_A1234MonDsc[0];
               n1234MonDsc = P00926_n1234MonDsc[0];
               A185CCDocNum = P00926_A185CCDocNum[0];
               A306TipAbr = P00926_A306TipAbr[0];
               n306TipAbr = P00926_n306TipAbr[0];
               A190CCFech = P00926_A190CCFech[0];
               A184CCTipCod = P00926_A184CCTipCod[0];
               A506CCEstado = P00926_A506CCEstado[0];
               A186CCVendCod = P00926_A186CCVendCod[0];
               A159TipCCod = P00926_A159TipCCod[0];
               n159TipCCod = P00926_n159TipCCod[0];
               A188CCCliCod = P00926_A188CCCliCod[0];
               A1234MonDsc = P00926_A1234MonDsc[0];
               n1234MonDsc = P00926_n1234MonDsc[0];
               A511TipSigno = P00926_A511TipSigno[0];
               n511TipSigno = P00926_n511TipSigno[0];
               A306TipAbr = P00926_A306TipAbr[0];
               n306TipAbr = P00926_n306TipAbr[0];
               A159TipCCod = P00926_A159TipCCod[0];
               n159TipCCod = P00926_n159TipCCod[0];
               AV13Cliente = StringUtil.Trim( A188CCCliCod) + " - " + StringUtil.Trim( A189CCCliDsc);
               H920( false, 21) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Cliente, "")), 8, Gx_line+4, 612, Gx_line+19, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
               AV48TotImporte = 0.00m;
               AV49TotPagos = 0.00m;
               AV50TotSaldo = 0.00m;
               while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00926_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
               {
                  BRK927 = false;
                  A511TipSigno = P00926_A511TipSigno[0];
                  n511TipSigno = P00926_n511TipSigno[0];
                  A513CCImpTotal = P00926_A513CCImpTotal[0];
                  A509CCImpPago = P00926_A509CCImpPago[0];
                  A508CCFVcto = P00926_A508CCFVcto[0];
                  A187CCmonCod = P00926_A187CCmonCod[0];
                  A1234MonDsc = P00926_A1234MonDsc[0];
                  n1234MonDsc = P00926_n1234MonDsc[0];
                  A185CCDocNum = P00926_A185CCDocNum[0];
                  A306TipAbr = P00926_A306TipAbr[0];
                  n306TipAbr = P00926_n306TipAbr[0];
                  A190CCFech = P00926_A190CCFech[0];
                  A184CCTipCod = P00926_A184CCTipCod[0];
                  A1234MonDsc = P00926_A1234MonDsc[0];
                  n1234MonDsc = P00926_n1234MonDsc[0];
                  A511TipSigno = P00926_A511TipSigno[0];
                  n511TipSigno = P00926_n511TipSigno[0];
                  A306TipAbr = P00926_A306TipAbr[0];
                  n306TipAbr = P00926_n306TipAbr[0];
                  AV32Importe = (decimal)(A513CCImpTotal*A511TipSigno);
                  AV37Pagos = (decimal)(A509CCImpPago*A511TipSigno);
                  AV39Saldo = (decimal)((A513CCImpTotal-A509CCImpPago)*A511TipSigno);
                  AV16Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A508CCFVcto));
                  AV48TotImporte = (decimal)(AV48TotImporte+AV32Importe);
                  AV49TotPagos = (decimal)(AV49TotPagos+AV37Pagos);
                  AV50TotSaldo = (decimal)(AV50TotSaldo+AV39Saldo);
                  AV44TotalMN = (decimal)(AV44TotalMN+(((A187CCmonCod==1) ? AV39Saldo : (decimal)(0))));
                  AV43TotalME = (decimal)(AV43TotalME+(((A187CCmonCod==2) ? AV39Saldo : (decimal)(0))));
                  H920( false, 17) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A185CCDocNum, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A190CCFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A508CCFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 394, Gx_line+2, 451, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+2, 566, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+2, 675, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+2, 779, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16Dias), "ZZZZ9")), 308, Gx_line+2, 365, Gx_line+17, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
                  BRK927 = true;
                  pr_default.readNext(4);
               }
               H920( false, 24) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+6, 566, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+6, 675, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 779, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(466, Gx_line+1, 788, Gx_line+1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Cliente", 349, Gx_line+6, 424, Gx_line+20, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
               AV45TotGImporte = (decimal)(AV45TotGImporte+AV48TotImporte);
               AV46TotGPagos = (decimal)(AV46TotGPagos+AV49TotPagos);
               AV47TotGSaldo = (decimal)(AV47TotGSaldo+AV50TotSaldo);
               if ( ! BRK927 )
               {
                  BRK927 = true;
                  pr_default.readNext(4);
               }
            }
            pr_default.close(4);
            if ( (0==AV34MonCod) )
            {
               AV36MonMN = "";
               AV35MonME = "";
               /* Using cursor P00927 */
               pr_default.execute(5);
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A1234MonDsc = P00927_A1234MonDsc[0];
                  n1234MonDsc = P00927_n1234MonDsc[0];
                  A180MonCod = P00927_A180MonCod[0];
                  if ( A180MonCod == 1 )
                  {
                     AV36MonMN = StringUtil.Trim( A1234MonDsc);
                  }
                  if ( A180MonCod == 2 )
                  {
                     AV35MonME = StringUtil.Trim( A1234MonDsc);
                  }
                  pr_default.readNext(5);
               }
               pr_default.close(5);
               H920( false, 90) ;
               getPrinter().GxDrawRect(193, Gx_line+13, 608, Gx_line+85, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(427, Gx_line+13, 427, Gx_line+85, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(193, Gx_line+34, 608, Gx_line+34, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(193, Gx_line+57, 608, Gx_line+57, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Moneda", 291, Gx_line+17, 339, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total General", 466, Gx_line+17, 546, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36MonMN, "")), 199, Gx_line+40, 420, Gx_line+54, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35MonME, "")), 199, Gx_line+63, 420, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+40, 576, Gx_line+55, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43TotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+63, 576, Gx_line+78, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+90);
            }
            else
            {
               H920( false, 28) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TotGImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 468, Gx_line+9, 565, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46TotGPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 569, Gx_line+9, 674, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TotGSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 673, Gx_line+9, 778, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(465, Gx_line+4, 787, Gx_line+4, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total General", 360, Gx_line+10, 440, Gx_line+24, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+28);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H920( true, 0) ;
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

      protected void H920( bool bFoot ,
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
               getPrinter().GxDrawText("T/D", 14, Gx_line+230, 37, Gx_line+244, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Documento", 71, Gx_line+231, 156, Gx_line+245, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dias Vcto", 324, Gx_line+231, 379, Gx_line+245, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 395, Gx_line+231, 443, Gx_line+245, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe Total", 473, Gx_line+231, 556, Gx_line+245, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+224, 797, Gx_line+250, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuentas por Cobrar Vencimiento", 271, Gx_line+70, 547, Gx_line+90, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 174, Gx_line+231, 209, Gx_line+245, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Vcto", 236, Gx_line+231, 301, Gx_line+245, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 719, Gx_line+231, 752, Gx_line+245, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pago", 616, Gx_line+231, 646, Gx_line+245, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Documento", 198, Gx_line+131, 313, Gx_line+145, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Cliente", 198, Gx_line+153, 285, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 198, Gx_line+175, 246, Gx_line+189, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 198, Gx_line+199, 240, Gx_line+213, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro1, "")), 332, Gx_line+126, 675, Gx_line+150, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Filtro2, "")), 332, Gx_line+148, 675, Gx_line+172, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Filtro3, "")), 332, Gx_line+170, 675, Gx_line+194, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Filtro4, "")), 332, Gx_line+194, 675, Gx_line+218, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EmpDir, "")), 19, Gx_line+29, 404, Gx_line+47, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19EmpRUC, "")), 19, Gx_line+46, 404, Gx_line+64, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Empresa, "")), 19, Gx_line+11, 404, Gx_line+29, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 414, Gx_line+92, 444, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV23FHasta, "99/99/99"), 453, Gx_line+92, 535, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Del :", 288, Gx_line+92, 329, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV22FDesde, "99/99/99"), 327, Gx_line+92, 408, Gx_line+112, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+250);
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
         AV18Empresa = "";
         AV40Session = context.GetSession();
         AV17EmpDir = "";
         AV19EmpRUC = "";
         AV38Ruta = "";
         AV33Logo = "";
         AV54Logo_GXI = "";
         AV24Filtro1 = "";
         AV25Filtro2 = "";
         AV26Filtro3 = "";
         AV27Filtro4 = "";
         scmdbuf = "";
         P00922_A149TipCod = new string[] {""} ;
         P00922_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         P00923_A159TipCCod = new int[1] ;
         P00923_n159TipCCod = new bool[] {false} ;
         P00923_A1905TipCDsc = new string[] {""} ;
         A1905TipCDsc = "";
         P00924_A180MonCod = new int[1] ;
         P00924_A1234MonDsc = new string[] {""} ;
         P00924_n1234MonDsc = new bool[] {false} ;
         A1234MonDsc = "";
         P00925_A45CliCod = new string[] {""} ;
         P00925_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         A188CCCliCod = "";
         A184CCTipCod = "";
         A508CCFVcto = DateTime.MinValue;
         A506CCEstado = "";
         P00926_A189CCCliDsc = new string[] {""} ;
         P00926_A511TipSigno = new short[1] ;
         P00926_n511TipSigno = new bool[] {false} ;
         P00926_A513CCImpTotal = new decimal[1] ;
         P00926_A509CCImpPago = new decimal[1] ;
         P00926_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00926_A187CCmonCod = new int[1] ;
         P00926_A1234MonDsc = new string[] {""} ;
         P00926_n1234MonDsc = new bool[] {false} ;
         P00926_A185CCDocNum = new string[] {""} ;
         P00926_A306TipAbr = new string[] {""} ;
         P00926_n306TipAbr = new bool[] {false} ;
         P00926_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00926_A184CCTipCod = new string[] {""} ;
         P00926_A506CCEstado = new string[] {""} ;
         P00926_A186CCVendCod = new int[1] ;
         P00926_A159TipCCod = new int[1] ;
         P00926_n159TipCCod = new bool[] {false} ;
         P00926_A188CCCliCod = new string[] {""} ;
         A189CCCliDsc = "";
         A185CCDocNum = "";
         A306TipAbr = "";
         A190CCFech = DateTime.MinValue;
         AV13Cliente = "";
         AV36MonMN = "";
         AV35MonME = "";
         P00927_A1234MonDsc = new string[] {""} ;
         P00927_n1234MonDsc = new bool[] {false} ;
         P00927_A180MonCod = new int[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrcuentasxcobrarvcto__default(),
            new Object[][] {
                new Object[] {
               P00922_A149TipCod, P00922_A1910TipDsc
               }
               , new Object[] {
               P00923_A159TipCCod, P00923_A1905TipCDsc
               }
               , new Object[] {
               P00924_A180MonCod, P00924_A1234MonDsc
               }
               , new Object[] {
               P00925_A45CliCod, P00925_A161CliDsc
               }
               , new Object[] {
               P00926_A189CCCliDsc, P00926_A511TipSigno, P00926_n511TipSigno, P00926_A513CCImpTotal, P00926_A509CCImpPago, P00926_A508CCFVcto, P00926_A187CCmonCod, P00926_A1234MonDsc, P00926_n1234MonDsc, P00926_A185CCDocNum,
               P00926_A306TipAbr, P00926_n306TipAbr, P00926_A190CCFech, P00926_A184CCTipCod, P00926_A506CCEstado, P00926_A186CCVendCod, P00926_A159TipCCod, P00926_n159TipCCod, P00926_A188CCCliCod
               }
               , new Object[] {
               P00927_A1234MonDsc, P00927_A180MonCod
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
      private short A511TipSigno ;
      private int AV41TipCCod ;
      private int AV34MonCod ;
      private int AV51VenCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A159TipCCod ;
      private int A180MonCod ;
      private int A187CCmonCod ;
      private int A186CCVendCod ;
      private int Gx_OldLine ;
      private int AV16Dias ;
      private decimal AV45TotGImporte ;
      private decimal AV46TotGPagos ;
      private decimal AV47TotGSaldo ;
      private decimal AV43TotalME ;
      private decimal AV44TotalMN ;
      private decimal A513CCImpTotal ;
      private decimal A509CCImpPago ;
      private decimal AV48TotImporte ;
      private decimal AV49TotPagos ;
      private decimal AV50TotSaldo ;
      private decimal AV32Importe ;
      private decimal AV37Pagos ;
      private decimal AV39Saldo ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV12CliCod ;
      private string AV42TipCod ;
      private string AV18Empresa ;
      private string AV17EmpDir ;
      private string AV19EmpRUC ;
      private string AV38Ruta ;
      private string AV24Filtro1 ;
      private string AV25Filtro2 ;
      private string AV26Filtro3 ;
      private string AV27Filtro4 ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A1910TipDsc ;
      private string A1905TipCDsc ;
      private string A1234MonDsc ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A188CCCliCod ;
      private string A184CCTipCod ;
      private string A506CCEstado ;
      private string A189CCCliDsc ;
      private string A185CCDocNum ;
      private string A306TipAbr ;
      private string AV36MonMN ;
      private string AV35MonME ;
      private string Gx_time ;
      private DateTime AV22FDesde ;
      private DateTime AV23FHasta ;
      private DateTime A508CCFVcto ;
      private DateTime A190CCFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n159TipCCod ;
      private bool n1234MonDsc ;
      private bool BRK927 ;
      private bool n511TipSigno ;
      private bool n306TipAbr ;
      private string AV54Logo_GXI ;
      private string AV13Cliente ;
      private string AV33Logo ;
      private IGxSession AV40Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TipCCod ;
      private string aP1_CliCod ;
      private string aP2_TipCod ;
      private int aP3_MonCod ;
      private DateTime aP4_FDesde ;
      private DateTime aP5_FHasta ;
      private int aP6_VenCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00922_A149TipCod ;
      private string[] P00922_A1910TipDsc ;
      private int[] P00923_A159TipCCod ;
      private bool[] P00923_n159TipCCod ;
      private string[] P00923_A1905TipCDsc ;
      private int[] P00924_A180MonCod ;
      private string[] P00924_A1234MonDsc ;
      private bool[] P00924_n1234MonDsc ;
      private string[] P00925_A45CliCod ;
      private string[] P00925_A161CliDsc ;
      private string[] P00926_A189CCCliDsc ;
      private short[] P00926_A511TipSigno ;
      private bool[] P00926_n511TipSigno ;
      private decimal[] P00926_A513CCImpTotal ;
      private decimal[] P00926_A509CCImpPago ;
      private DateTime[] P00926_A508CCFVcto ;
      private int[] P00926_A187CCmonCod ;
      private string[] P00926_A1234MonDsc ;
      private bool[] P00926_n1234MonDsc ;
      private string[] P00926_A185CCDocNum ;
      private string[] P00926_A306TipAbr ;
      private bool[] P00926_n306TipAbr ;
      private DateTime[] P00926_A190CCFech ;
      private string[] P00926_A184CCTipCod ;
      private string[] P00926_A506CCEstado ;
      private int[] P00926_A186CCVendCod ;
      private int[] P00926_A159TipCCod ;
      private bool[] P00926_n159TipCCod ;
      private string[] P00926_A188CCCliCod ;
      private string[] P00927_A1234MonDsc ;
      private bool[] P00927_n1234MonDsc ;
      private int[] P00927_A180MonCod ;
   }

   public class rrcuentasxcobrarvcto__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00926( IGxContext context ,
                                             string AV12CliCod ,
                                             int AV41TipCCod ,
                                             int AV34MonCod ,
                                             string AV42TipCod ,
                                             int AV51VenCod ,
                                             string A188CCCliCod ,
                                             int A159TipCCod ,
                                             int A187CCmonCod ,
                                             string A184CCTipCod ,
                                             int A186CCVendCod ,
                                             DateTime A508CCFVcto ,
                                             DateTime AV22FDesde ,
                                             DateTime AV23FHasta ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliDsc], T3.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCFVcto], T1.[CCmonCod] AS CCmonCod, T2.[MonDsc], T1.[CCDocNum], T3.[TipAbr], T1.[CCFech], T1.[CCTipCod] AS CCTipCod, T1.[CCEstado], T1.[CCVendCod], T4.[TipCCod], T1.[CCCliCod] AS CCCliCod FROM ((([CLCUENTACOBRAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "(T1.[CCFVcto] >= @AV22FDesde and T1.[CCFVcto] <= @AV23FHasta)");
         AddWhere(sWhereString, "(T1.[CCEstado] = '')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV12CliCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV41TipCCod) )
         {
            AddWhere(sWhereString, "(T4.[TipCCod] = @AV41TipCCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV34MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV34MonCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV42TipCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV51VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV51VenCod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCTipCod], T1.[CCFech]";
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
               case 4 :
                     return conditional_P00926(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] );
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
          Object[] prmP00922;
          prmP00922 = new Object[] {
          new ParDef("@AV42TipCod",GXType.NChar,3,0)
          };
          Object[] prmP00923;
          prmP00923 = new Object[] {
          new ParDef("@AV41TipCCod",GXType.Int32,6,0)
          };
          Object[] prmP00924;
          prmP00924 = new Object[] {
          new ParDef("@AV34MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00925;
          prmP00925 = new Object[] {
          new ParDef("@AV12CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00927;
          prmP00927 = new Object[] {
          };
          Object[] prmP00926;
          prmP00926 = new Object[] {
          new ParDef("@AV22FDesde",GXType.Date,8,0) ,
          new ParDef("@AV23FHasta",GXType.Date,8,0) ,
          new ParDef("@AV12CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV41TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV34MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV42TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV51VenCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00922", "SELECT [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipCod] = @AV42TipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00922,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00923", "SELECT [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE] WHERE [TipCCod] = @AV41TipCCod ORDER BY [TipCCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00923,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00924", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV34MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00924,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00925", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV12CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00925,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00926", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00926,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00927", "SELECT [MonDsc], [MonCod] FROM [CMONEDAS] ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00927,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 12);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(10);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((string[]) buf[14])[0] = rslt.getString(12, 1);
                ((int[]) buf[15])[0] = rslt.getInt(13);
                ((int[]) buf[16])[0] = rslt.getInt(14);
                ((bool[]) buf[17])[0] = rslt.wasNull(14);
                ((string[]) buf[18])[0] = rslt.getString(15, 20);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
