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
   public class r_cuentasxpagarpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_cuentasxpagarpdf.aspx")), "compras.r_cuentasxpagarpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_cuentasxpagarpdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "TprvCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV68TprvCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV26EstCod = GetPar( "EstCod");
                  AV46PrvCod = GetPar( "PrvCod");
                  AV52TipCod = GetPar( "TipCod");
                  AV38MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV27FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV56TipFecha = GetPar( "TipFecha");
                  AV40Orden = GetPar( "Orden");
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

      public r_cuentasxpagarpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_cuentasxpagarpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TprvCod ,
                           ref string aP1_EstCod ,
                           ref string aP2_PrvCod ,
                           ref string aP3_TipCod ,
                           ref int aP4_MonCod ,
                           ref DateTime aP5_FHasta ,
                           ref string aP6_TipFecha ,
                           ref string aP7_Orden )
      {
         this.AV68TprvCod = aP0_TprvCod;
         this.AV26EstCod = aP1_EstCod;
         this.AV46PrvCod = aP2_PrvCod;
         this.AV52TipCod = aP3_TipCod;
         this.AV38MonCod = aP4_MonCod;
         this.AV27FHasta = aP5_FHasta;
         this.AV56TipFecha = aP6_TipFecha;
         this.AV40Orden = aP7_Orden;
         initialize();
         executePrivate();
         aP0_TprvCod=this.AV68TprvCod;
         aP1_EstCod=this.AV26EstCod;
         aP2_PrvCod=this.AV46PrvCod;
         aP3_TipCod=this.AV52TipCod;
         aP4_MonCod=this.AV38MonCod;
         aP5_FHasta=this.AV27FHasta;
         aP6_TipFecha=this.AV56TipFecha;
         aP7_Orden=this.AV40Orden;
      }

      public string executeUdp( ref int aP0_TprvCod ,
                                ref string aP1_EstCod ,
                                ref string aP2_PrvCod ,
                                ref string aP3_TipCod ,
                                ref int aP4_MonCod ,
                                ref DateTime aP5_FHasta ,
                                ref string aP6_TipFecha )
      {
         execute(ref aP0_TprvCod, ref aP1_EstCod, ref aP2_PrvCod, ref aP3_TipCod, ref aP4_MonCod, ref aP5_FHasta, ref aP6_TipFecha, ref aP7_Orden);
         return AV40Orden ;
      }

      public void executeSubmit( ref int aP0_TprvCod ,
                                 ref string aP1_EstCod ,
                                 ref string aP2_PrvCod ,
                                 ref string aP3_TipCod ,
                                 ref int aP4_MonCod ,
                                 ref DateTime aP5_FHasta ,
                                 ref string aP6_TipFecha ,
                                 ref string aP7_Orden )
      {
         r_cuentasxpagarpdf objr_cuentasxpagarpdf;
         objr_cuentasxpagarpdf = new r_cuentasxpagarpdf();
         objr_cuentasxpagarpdf.AV68TprvCod = aP0_TprvCod;
         objr_cuentasxpagarpdf.AV26EstCod = aP1_EstCod;
         objr_cuentasxpagarpdf.AV46PrvCod = aP2_PrvCod;
         objr_cuentasxpagarpdf.AV52TipCod = aP3_TipCod;
         objr_cuentasxpagarpdf.AV38MonCod = aP4_MonCod;
         objr_cuentasxpagarpdf.AV27FHasta = aP5_FHasta;
         objr_cuentasxpagarpdf.AV56TipFecha = aP6_TipFecha;
         objr_cuentasxpagarpdf.AV40Orden = aP7_Orden;
         objr_cuentasxpagarpdf.context.SetSubmitInitialConfig(context);
         objr_cuentasxpagarpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_cuentasxpagarpdf);
         aP0_TprvCod=this.AV68TprvCod;
         aP1_EstCod=this.AV26EstCod;
         aP2_PrvCod=this.AV46PrvCod;
         aP3_TipCod=this.AV52TipCod;
         aP4_MonCod=this.AV38MonCod;
         aP5_FHasta=this.AV27FHasta;
         aP6_TipFecha=this.AV56TipFecha;
         aP7_Orden=this.AV40Orden;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_cuentasxpagarpdf)stateInfo).executePrivate();
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
            AV23Empresa = AV49Session.Get("Empresa");
            AV22EmpDir = AV49Session.Get("EmpDir");
            AV24EmpRUC = AV49Session.Get("EmpRUC");
            AV47Ruta = AV49Session.Get("RUTA") + "/Logo.jpg";
            AV37Logo = AV47Ruta;
            AV75Logo_GXI = GXDbFile.PathToUrl( AV47Ruta);
            AV28Filtro1 = "Todos";
            AV29Filtro2 = "Todos";
            AV30Filtro3 = "Todos";
            AV31Filtro4 = "Todos";
            AV32Filtro5 = "Todos";
            /* Using cursor P009J2 */
            pr_default.execute(0, new Object[] {AV52TipCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A149TipCod = P009J2_A149TipCod[0];
               A1910TipDsc = P009J2_A1910TipDsc[0];
               n1910TipDsc = P009J2_n1910TipDsc[0];
               AV28Filtro1 = A1910TipDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P009J3 */
            pr_default.execute(1, new Object[] {AV68TprvCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A298TprvCod = P009J3_A298TprvCod[0];
               n298TprvCod = P009J3_n298TprvCod[0];
               A1941TprvDsc = P009J3_A1941TprvDsc[0];
               AV29Filtro2 = A1941TprvDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P009J4 */
            pr_default.execute(2, new Object[] {AV38MonCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A180MonCod = P009J4_A180MonCod[0];
               A1234MonDsc = P009J4_A1234MonDsc[0];
               AV30Filtro3 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P009J5 */
            pr_default.execute(3, new Object[] {AV46PrvCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A244PrvCod = P009J5_A244PrvCod[0];
               A247PrvDsc = P009J5_A247PrvDsc[0];
               AV31Filtro4 = A247PrvDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            AV62TotGImporte = 0.00m;
            AV63TotGPagos = 0.00m;
            AV64TotGSaldo = 0.00m;
            AV71TotalMN = 0.00m;
            AV72TotalME = 0.00m;
            if ( DateTimeUtil.ResetTime ( AV27FHasta ) == DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
            {
               if ( StringUtil.StrCmp(AV40Orden, "D") == 0 )
               {
                  /* Execute user subroutine: 'CUENTAPAGAR' */
                  S111 ();
                  if ( returnInSub )
                  {
                     this.cleanup();
                     if (true) return;
                  }
               }
               else
               {
                  /* Execute user subroutine: 'CUENTAPAGARCODIGO' */
                  S131 ();
                  if ( returnInSub )
                  {
                     this.cleanup();
                     if (true) return;
                  }
               }
            }
            else
            {
               if ( StringUtil.StrCmp(AV40Orden, "D") == 0 )
               {
                  /* Execute user subroutine: 'CUENTAPAGARAL' */
                  S141 ();
                  if ( returnInSub )
                  {
                     this.cleanup();
                     if (true) return;
                  }
               }
               else
               {
                  /* Execute user subroutine: 'CUENTAPAGARALCODIGO' */
                  S171 ();
                  if ( returnInSub )
                  {
                     this.cleanup();
                     if (true) return;
                  }
               }
            }
            if ( (0==AV38MonCod) )
            {
               AV69MonMN = "";
               AV70MonME = "";
               /* Using cursor P009J6 */
               pr_default.execute(4);
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A1234MonDsc = P009J6_A1234MonDsc[0];
                  A180MonCod = P009J6_A180MonCod[0];
                  if ( A180MonCod == 1 )
                  {
                     AV69MonMN = StringUtil.Trim( A1234MonDsc);
                  }
                  if ( A180MonCod == 2 )
                  {
                     AV70MonME = StringUtil.Trim( A1234MonDsc);
                  }
                  pr_default.readNext(4);
               }
               pr_default.close(4);
               H9J0( false, 90) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72TotalME, "ZZZZZZ,ZZZ,ZZ9.99")), 461, Gx_line+61, 568, Gx_line+76, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 461, Gx_line+38, 568, Gx_line+53, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70MonME, "")), 197, Gx_line+61, 418, Gx_line+75, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69MonMN, "")), 197, Gx_line+38, 418, Gx_line+52, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total General", 464, Gx_line+15, 544, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 289, Gx_line+15, 337, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(191, Gx_line+55, 606, Gx_line+55, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(191, Gx_line+32, 606, Gx_line+32, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(425, Gx_line+10, 425, Gx_line+82, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(191, Gx_line+10, 606, Gx_line+82, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+90);
            }
            else
            {
               H9J0( false, 28) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62TotGImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 468, Gx_line+9, 565, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63TotGPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 569, Gx_line+9, 674, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TotGSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 673, Gx_line+9, 778, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(465, Gx_line+4, 787, Gx_line+4, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total General", 360, Gx_line+10, 440, Gx_line+24, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+28);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9J0( true, 0) ;
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
         /* 'CUENTAPAGAR' Routine */
         returnInSub = false;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV46PrvCod ,
                                              AV26EstCod ,
                                              AV68TprvCod ,
                                              AV38MonCod ,
                                              AV52TipCod ,
                                              A262CPPrvCod ,
                                              A140EstCod ,
                                              A298TprvCod ,
                                              A263CPMonCod ,
                                              A260CPTipCod ,
                                              A815CPEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P009J7 */
         pr_default.execute(5, new Object[] {AV46PrvCod, AV26EstCod, AV68TprvCod, AV38MonCod, AV52TipCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK9J8 = false;
            A815CPEstado = P009J7_A815CPEstado[0];
            A262CPPrvCod = P009J7_A262CPPrvCod[0];
            A831CPPrvDsc = P009J7_A831CPPrvDsc[0];
            A260CPTipCod = P009J7_A260CPTipCod[0];
            A263CPMonCod = P009J7_A263CPMonCod[0];
            A298TprvCod = P009J7_A298TprvCod[0];
            n298TprvCod = P009J7_n298TprvCod[0];
            A140EstCod = P009J7_A140EstCod[0];
            n140EstCod = P009J7_n140EstCod[0];
            A818CPImpPago = P009J7_A818CPImpPago[0];
            A261CPComCod = P009J7_A261CPComCod[0];
            A831CPPrvDsc = P009J7_A831CPPrvDsc[0];
            A298TprvCod = P009J7_A298TprvCod[0];
            n298TprvCod = P009J7_n298TprvCod[0];
            A140EstCod = P009J7_A140EstCod[0];
            n140EstCod = P009J7_n140EstCod[0];
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P009J7_A831CPPrvDsc[0], A831CPPrvDsc) == 0 ) )
            {
               BRK9J8 = false;
               A262CPPrvCod = P009J7_A262CPPrvCod[0];
               A260CPTipCod = P009J7_A260CPTipCod[0];
               A261CPComCod = P009J7_A261CPComCod[0];
               BRK9J8 = true;
               pr_default.readNext(5);
            }
            AV19CPPrvDsc = StringUtil.Trim( A262CPPrvCod) + " - " + StringUtil.Trim( A831CPPrvDsc);
            AV10Codigo = A262CPPrvCod;
            H9J0( false, 21) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CPPrvDsc, "")), 8, Gx_line+4, 612, Gx_line+19, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+21);
            AV65TotImporte = 0.00m;
            AV66TotPagos = 0.00m;
            AV67TotSaldo = 0.00m;
            /* Execute user subroutine: 'DETALLECXP' */
            S128 ();
            if ( returnInSub )
            {
               pr_default.close(5);
               returnInSub = true;
               if (true) return;
            }
            H9J0( false, 24) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+6, 566, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+6, 675, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 779, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(465, Gx_line+1, 787, Gx_line+1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Proveedor", 331, Gx_line+5, 427, Gx_line+19, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+24);
            AV62TotGImporte = (decimal)(AV62TotGImporte+AV65TotImporte);
            AV63TotGPagos = (decimal)(AV63TotGPagos+AV66TotPagos);
            AV64TotGSaldo = (decimal)(AV64TotGSaldo+AV67TotSaldo);
            if ( ! BRK9J8 )
            {
               BRK9J8 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S131( )
      {
         /* 'CUENTAPAGARCODIGO' Routine */
         returnInSub = false;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV46PrvCod ,
                                              AV26EstCod ,
                                              AV68TprvCod ,
                                              AV38MonCod ,
                                              AV52TipCod ,
                                              A262CPPrvCod ,
                                              A140EstCod ,
                                              A298TprvCod ,
                                              A263CPMonCod ,
                                              A260CPTipCod ,
                                              A815CPEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P009J8 */
         pr_default.execute(6, new Object[] {AV46PrvCod, AV26EstCod, AV68TprvCod, AV38MonCod, AV52TipCod});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRK9J10 = false;
            A831CPPrvDsc = P009J8_A831CPPrvDsc[0];
            A262CPPrvCod = P009J8_A262CPPrvCod[0];
            A815CPEstado = P009J8_A815CPEstado[0];
            A260CPTipCod = P009J8_A260CPTipCod[0];
            A263CPMonCod = P009J8_A263CPMonCod[0];
            A298TprvCod = P009J8_A298TprvCod[0];
            n298TprvCod = P009J8_n298TprvCod[0];
            A140EstCod = P009J8_A140EstCod[0];
            n140EstCod = P009J8_n140EstCod[0];
            A818CPImpPago = P009J8_A818CPImpPago[0];
            A261CPComCod = P009J8_A261CPComCod[0];
            A831CPPrvDsc = P009J8_A831CPPrvDsc[0];
            A298TprvCod = P009J8_A298TprvCod[0];
            n298TprvCod = P009J8_n298TprvCod[0];
            A140EstCod = P009J8_A140EstCod[0];
            n140EstCod = P009J8_n140EstCod[0];
            while ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(P009J8_A262CPPrvCod[0], A262CPPrvCod) == 0 ) )
            {
               BRK9J10 = false;
               A831CPPrvDsc = P009J8_A831CPPrvDsc[0];
               A260CPTipCod = P009J8_A260CPTipCod[0];
               A261CPComCod = P009J8_A261CPComCod[0];
               A831CPPrvDsc = P009J8_A831CPPrvDsc[0];
               BRK9J10 = true;
               pr_default.readNext(6);
            }
            AV19CPPrvDsc = StringUtil.Trim( A262CPPrvCod) + " - " + StringUtil.Trim( A831CPPrvDsc);
            AV10Codigo = A262CPPrvCod;
            H9J0( false, 21) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CPPrvDsc, "")), 8, Gx_line+4, 612, Gx_line+19, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+21);
            AV65TotImporte = 0.00m;
            AV66TotPagos = 0.00m;
            AV67TotSaldo = 0.00m;
            /* Execute user subroutine: 'DETALLECXP' */
            S128 ();
            if ( returnInSub )
            {
               pr_default.close(6);
               returnInSub = true;
               if (true) return;
            }
            H9J0( false, 24) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+6, 566, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+6, 675, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 779, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(465, Gx_line+1, 787, Gx_line+1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Proveedor", 331, Gx_line+5, 427, Gx_line+19, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+24);
            AV62TotGImporte = (decimal)(AV62TotGImporte+AV65TotImporte);
            AV63TotGPagos = (decimal)(AV63TotGPagos+AV66TotPagos);
            AV64TotGSaldo = (decimal)(AV64TotGSaldo+AV67TotSaldo);
            if ( ! BRK9J10 )
            {
               BRK9J10 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
      }

      protected void S128( )
      {
         /* 'DETALLECXP' Routine */
         returnInSub = false;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV26EstCod ,
                                              AV68TprvCod ,
                                              AV38MonCod ,
                                              AV52TipCod ,
                                              A140EstCod ,
                                              A298TprvCod ,
                                              A263CPMonCod ,
                                              A260CPTipCod ,
                                              A262CPPrvCod ,
                                              AV10Codigo ,
                                              A815CPEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P009J9 */
         pr_default.execute(7, new Object[] {AV10Codigo, AV26EstCod, AV68TprvCod, AV38MonCod, AV52TipCod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            BRK9J12 = false;
            A815CPEstado = P009J9_A815CPEstado[0];
            A263CPMonCod = P009J9_A263CPMonCod[0];
            A298TprvCod = P009J9_A298TprvCod[0];
            n298TprvCod = P009J9_n298TprvCod[0];
            A140EstCod = P009J9_A140EstCod[0];
            n140EstCod = P009J9_n140EstCod[0];
            A260CPTipCod = P009J9_A260CPTipCod[0];
            A262CPPrvCod = P009J9_A262CPPrvCod[0];
            A264CPFech = P009J9_A264CPFech[0];
            n264CPFech = P009J9_n264CPFech[0];
            A817CPFVcto = P009J9_A817CPFVcto[0];
            A830CPMonDsc = P009J9_A830CPMonDsc[0];
            A511TipSigno = P009J9_A511TipSigno[0];
            n511TipSigno = P009J9_n511TipSigno[0];
            A820CPImpTotal = P009J9_A820CPImpTotal[0];
            A818CPImpPago = P009J9_A818CPImpPago[0];
            A261CPComCod = P009J9_A261CPComCod[0];
            A856CPTipAbr = P009J9_A856CPTipAbr[0];
            A1910TipDsc = P009J9_A1910TipDsc[0];
            n1910TipDsc = P009J9_n1910TipDsc[0];
            A830CPMonDsc = P009J9_A830CPMonDsc[0];
            A511TipSigno = P009J9_A511TipSigno[0];
            n511TipSigno = P009J9_n511TipSigno[0];
            A856CPTipAbr = P009J9_A856CPTipAbr[0];
            A1910TipDsc = P009J9_A1910TipDsc[0];
            n1910TipDsc = P009J9_n1910TipDsc[0];
            A298TprvCod = P009J9_A298TprvCod[0];
            n298TprvCod = P009J9_n298TprvCod[0];
            A140EstCod = P009J9_A140EstCod[0];
            n140EstCod = P009J9_n140EstCod[0];
            AV53TipCod2 = A260CPTipCod;
            AV50TipAbr = A856CPTipAbr;
            AV55TipDsc2 = "Total : " + StringUtil.Trim( A1910TipDsc);
            AV57TipImporte = 0.00m;
            AV59TipPagos = 0.00m;
            AV60TipSaldo = 0.00m;
            while ( (pr_default.getStatus(7) != 101) && ( StringUtil.StrCmp(P009J9_A260CPTipCod[0], A260CPTipCod) == 0 ) )
            {
               BRK9J12 = false;
               A815CPEstado = P009J9_A815CPEstado[0];
               A263CPMonCod = P009J9_A263CPMonCod[0];
               A298TprvCod = P009J9_A298TprvCod[0];
               n298TprvCod = P009J9_n298TprvCod[0];
               A140EstCod = P009J9_A140EstCod[0];
               n140EstCod = P009J9_n140EstCod[0];
               A262CPPrvCod = P009J9_A262CPPrvCod[0];
               A264CPFech = P009J9_A264CPFech[0];
               n264CPFech = P009J9_n264CPFech[0];
               A817CPFVcto = P009J9_A817CPFVcto[0];
               A830CPMonDsc = P009J9_A830CPMonDsc[0];
               A511TipSigno = P009J9_A511TipSigno[0];
               n511TipSigno = P009J9_n511TipSigno[0];
               A820CPImpTotal = P009J9_A820CPImpTotal[0];
               A818CPImpPago = P009J9_A818CPImpPago[0];
               A261CPComCod = P009J9_A261CPComCod[0];
               A830CPMonDsc = P009J9_A830CPMonDsc[0];
               A511TipSigno = P009J9_A511TipSigno[0];
               n511TipSigno = P009J9_n511TipSigno[0];
               A298TprvCod = P009J9_A298TprvCod[0];
               n298TprvCod = P009J9_n298TprvCod[0];
               A140EstCod = P009J9_A140EstCod[0];
               n140EstCod = P009J9_n140EstCod[0];
               if ( StringUtil.StrCmp(A260CPTipCod, AV53TipCod2) == 0 )
               {
                  if ( StringUtil.StrCmp(A262CPPrvCod, AV10Codigo) == 0 )
                  {
                     if ( StringUtil.StrCmp(A815CPEstado, "") == 0 )
                     {
                        AV14CPComCod = A261CPComCod;
                        AV15CPFech = A264CPFech;
                        AV16CPFVcto = A817CPFVcto;
                        AV39MonDsc = A830CPMonDsc;
                        AV17CPMonCod = A263CPMonCod;
                        AV36Importe = (decimal)(A820CPImpTotal*A511TipSigno);
                        AV45Pagos = (decimal)(A818CPImpPago*A511TipSigno);
                        AV48Saldo = (decimal)((A820CPImpTotal-A818CPImpPago)*A511TipSigno);
                        AV65TotImporte = (decimal)(AV65TotImporte+AV36Importe);
                        AV66TotPagos = (decimal)(AV66TotPagos+AV45Pagos);
                        AV67TotSaldo = (decimal)(AV67TotSaldo+AV48Saldo);
                        AV21Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A817CPFVcto));
                        H9J0( false, 17) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14CPComCod, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV15CPFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV16CPFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39MonDsc, "")), 394, Gx_line+2, 451, Gx_line+17, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+2, 566, Gx_line+17, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+2, 675, Gx_line+17, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+2, 779, Gx_line+17, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV21Dias), "ZZZZ9")), 313, Gx_line+1, 370, Gx_line+16, 2, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+17);
                        AV57TipImporte = (decimal)(AV57TipImporte+AV36Importe);
                        AV59TipPagos = (decimal)(AV59TipPagos+AV45Pagos);
                        AV60TipSaldo = (decimal)(AV60TipSaldo+AV48Saldo);
                        AV71TotalMN = (decimal)(AV71TotalMN+(((AV17CPMonCod==1) ? AV48Saldo : (decimal)(0))));
                        AV72TotalME = (decimal)(AV72TotalME+(((AV17CPMonCod==2) ? AV48Saldo : (decimal)(0))));
                     }
                  }
               }
               BRK9J12 = true;
               pr_default.readNext(7);
            }
            H9J0( false, 30) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TipDsc2, "")), 169, Gx_line+5, 450, Gx_line+19, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57TipImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 459, Gx_line+5, 566, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59TipPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 569, Gx_line+5, 676, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60TipSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 673, Gx_line+5, 780, Gx_line+20, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(465, Gx_line+2, 787, Gx_line+2, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+30);
            if ( ! BRK9J12 )
            {
               BRK9J12 = true;
               pr_default.readNext(7);
            }
         }
         pr_default.close(7);
      }

      protected void S141( )
      {
         /* 'CUENTAPAGARAL' Routine */
         returnInSub = false;
         pr_default.dynParam(8, new Object[]{ new Object[]{
                                              AV46PrvCod ,
                                              AV26EstCod ,
                                              AV68TprvCod ,
                                              AV38MonCod ,
                                              AV52TipCod ,
                                              AV56TipFecha ,
                                              A262CPPrvCod ,
                                              A140EstCod ,
                                              A298TprvCod ,
                                              A263CPMonCod ,
                                              A260CPTipCod ,
                                              A264CPFech ,
                                              AV27FHasta ,
                                              A816CPFReg ,
                                              A815CPEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P009J10 */
         pr_default.execute(8, new Object[] {AV46PrvCod, AV26EstCod, AV68TprvCod, AV38MonCod, AV52TipCod, AV27FHasta, AV27FHasta});
         while ( (pr_default.getStatus(8) != 101) )
         {
            BRK9J14 = false;
            A262CPPrvCod = P009J10_A262CPPrvCod[0];
            A831CPPrvDsc = P009J10_A831CPPrvDsc[0];
            A815CPEstado = P009J10_A815CPEstado[0];
            A816CPFReg = P009J10_A816CPFReg[0];
            n816CPFReg = P009J10_n816CPFReg[0];
            A264CPFech = P009J10_A264CPFech[0];
            n264CPFech = P009J10_n264CPFech[0];
            A260CPTipCod = P009J10_A260CPTipCod[0];
            A263CPMonCod = P009J10_A263CPMonCod[0];
            A298TprvCod = P009J10_A298TprvCod[0];
            n298TprvCod = P009J10_n298TprvCod[0];
            A140EstCod = P009J10_A140EstCod[0];
            n140EstCod = P009J10_n140EstCod[0];
            A818CPImpPago = P009J10_A818CPImpPago[0];
            A261CPComCod = P009J10_A261CPComCod[0];
            A831CPPrvDsc = P009J10_A831CPPrvDsc[0];
            A298TprvCod = P009J10_A298TprvCod[0];
            n298TprvCod = P009J10_n298TprvCod[0];
            A140EstCod = P009J10_A140EstCod[0];
            n140EstCod = P009J10_n140EstCod[0];
            while ( (pr_default.getStatus(8) != 101) && ( StringUtil.StrCmp(P009J10_A831CPPrvDsc[0], A831CPPrvDsc) == 0 ) )
            {
               BRK9J14 = false;
               A262CPPrvCod = P009J10_A262CPPrvCod[0];
               A260CPTipCod = P009J10_A260CPTipCod[0];
               A261CPComCod = P009J10_A261CPComCod[0];
               BRK9J14 = true;
               pr_default.readNext(8);
            }
            AV10Codigo = A262CPPrvCod;
            AV19CPPrvDsc = StringUtil.Trim( A262CPPrvCod) + " - " + StringUtil.Trim( A831CPPrvDsc);
            AV33Flag = 1;
            /* Execute user subroutine: 'VALIDAMOV' */
            S1514 ();
            if ( returnInSub )
            {
               pr_default.close(8);
               returnInSub = true;
               if (true) return;
            }
            if ( AV33Flag == 1 )
            {
               H9J0( false, 21) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CPPrvDsc, "")), 8, Gx_line+4, 612, Gx_line+19, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
            }
            AV65TotImporte = 0.00m;
            AV66TotPagos = 0.00m;
            AV67TotSaldo = 0.00m;
            /* Execute user subroutine: 'DETALLECXPAL' */
            S1614 ();
            if ( returnInSub )
            {
               pr_default.close(8);
               returnInSub = true;
               if (true) return;
            }
            if ( AV33Flag == 1 )
            {
               H9J0( false, 24) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+6, 566, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+6, 675, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 779, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(465, Gx_line+1, 787, Gx_line+1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Proveedor", 331, Gx_line+5, 427, Gx_line+19, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
            }
            AV62TotGImporte = (decimal)(AV62TotGImporte+AV65TotImporte);
            AV63TotGPagos = (decimal)(AV63TotGPagos+AV66TotPagos);
            AV64TotGSaldo = (decimal)(AV64TotGSaldo+AV67TotSaldo);
            if ( ! BRK9J14 )
            {
               BRK9J14 = true;
               pr_default.readNext(8);
            }
         }
         pr_default.close(8);
      }

      protected void S171( )
      {
         /* 'CUENTAPAGARALCODIGO' Routine */
         returnInSub = false;
         pr_default.dynParam(9, new Object[]{ new Object[]{
                                              AV46PrvCod ,
                                              AV26EstCod ,
                                              AV68TprvCod ,
                                              AV38MonCod ,
                                              AV52TipCod ,
                                              AV56TipFecha ,
                                              A262CPPrvCod ,
                                              A140EstCod ,
                                              A298TprvCod ,
                                              A263CPMonCod ,
                                              A260CPTipCod ,
                                              A264CPFech ,
                                              AV27FHasta ,
                                              A816CPFReg ,
                                              A815CPEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P009J11 */
         pr_default.execute(9, new Object[] {AV46PrvCod, AV26EstCod, AV68TprvCod, AV38MonCod, AV52TipCod, AV27FHasta, AV27FHasta});
         while ( (pr_default.getStatus(9) != 101) )
         {
            BRK9J16 = false;
            A831CPPrvDsc = P009J11_A831CPPrvDsc[0];
            A262CPPrvCod = P009J11_A262CPPrvCod[0];
            A815CPEstado = P009J11_A815CPEstado[0];
            A816CPFReg = P009J11_A816CPFReg[0];
            n816CPFReg = P009J11_n816CPFReg[0];
            A264CPFech = P009J11_A264CPFech[0];
            n264CPFech = P009J11_n264CPFech[0];
            A260CPTipCod = P009J11_A260CPTipCod[0];
            A263CPMonCod = P009J11_A263CPMonCod[0];
            A298TprvCod = P009J11_A298TprvCod[0];
            n298TprvCod = P009J11_n298TprvCod[0];
            A140EstCod = P009J11_A140EstCod[0];
            n140EstCod = P009J11_n140EstCod[0];
            A818CPImpPago = P009J11_A818CPImpPago[0];
            A261CPComCod = P009J11_A261CPComCod[0];
            A831CPPrvDsc = P009J11_A831CPPrvDsc[0];
            A298TprvCod = P009J11_A298TprvCod[0];
            n298TprvCod = P009J11_n298TprvCod[0];
            A140EstCod = P009J11_A140EstCod[0];
            n140EstCod = P009J11_n140EstCod[0];
            while ( (pr_default.getStatus(9) != 101) && ( StringUtil.StrCmp(P009J11_A262CPPrvCod[0], A262CPPrvCod) == 0 ) )
            {
               BRK9J16 = false;
               A831CPPrvDsc = P009J11_A831CPPrvDsc[0];
               A260CPTipCod = P009J11_A260CPTipCod[0];
               A261CPComCod = P009J11_A261CPComCod[0];
               A831CPPrvDsc = P009J11_A831CPPrvDsc[0];
               BRK9J16 = true;
               pr_default.readNext(9);
            }
            AV10Codigo = A262CPPrvCod;
            AV19CPPrvDsc = StringUtil.Trim( A262CPPrvCod) + " - " + StringUtil.Trim( A831CPPrvDsc);
            AV33Flag = 1;
            /* Execute user subroutine: 'VALIDAMOV' */
            S1514 ();
            if ( returnInSub )
            {
               pr_default.close(9);
               returnInSub = true;
               if (true) return;
            }
            if ( AV33Flag == 1 )
            {
               H9J0( false, 21) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CPPrvDsc, "")), 8, Gx_line+4, 612, Gx_line+19, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
            }
            AV65TotImporte = 0.00m;
            AV66TotPagos = 0.00m;
            AV67TotSaldo = 0.00m;
            /* Execute user subroutine: 'DETALLECXPAL' */
            S1614 ();
            if ( returnInSub )
            {
               pr_default.close(9);
               returnInSub = true;
               if (true) return;
            }
            if ( AV33Flag == 1 )
            {
               H9J0( false, 24) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+6, 566, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+6, 675, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 779, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(465, Gx_line+1, 787, Gx_line+1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Proveedor", 331, Gx_line+5, 427, Gx_line+19, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
            }
            AV62TotGImporte = (decimal)(AV62TotGImporte+AV65TotImporte);
            AV63TotGPagos = (decimal)(AV63TotGPagos+AV66TotPagos);
            AV64TotGSaldo = (decimal)(AV64TotGSaldo+AV67TotSaldo);
            if ( ! BRK9J16 )
            {
               BRK9J16 = true;
               pr_default.readNext(9);
            }
         }
         pr_default.close(9);
      }

      protected void S1614( )
      {
         /* 'DETALLECXPAL' Routine */
         returnInSub = false;
         pr_default.dynParam(10, new Object[]{ new Object[]{
                                              AV52TipCod ,
                                              AV26EstCod ,
                                              AV68TprvCod ,
                                              AV38MonCod ,
                                              AV56TipFecha ,
                                              A260CPTipCod ,
                                              A140EstCod ,
                                              A298TprvCod ,
                                              A263CPMonCod ,
                                              A264CPFech ,
                                              AV27FHasta ,
                                              A816CPFReg ,
                                              A815CPEstado ,
                                              A262CPPrvCod ,
                                              AV10Codigo } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P009J12 */
         pr_default.execute(10, new Object[] {AV10Codigo, AV52TipCod, AV26EstCod, AV68TprvCod, AV38MonCod, AV27FHasta, AV27FHasta});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A815CPEstado = P009J12_A815CPEstado[0];
            A816CPFReg = P009J12_A816CPFReg[0];
            n816CPFReg = P009J12_n816CPFReg[0];
            A264CPFech = P009J12_A264CPFech[0];
            n264CPFech = P009J12_n264CPFech[0];
            A263CPMonCod = P009J12_A263CPMonCod[0];
            A298TprvCod = P009J12_A298TprvCod[0];
            n298TprvCod = P009J12_n298TprvCod[0];
            A140EstCod = P009J12_A140EstCod[0];
            n140EstCod = P009J12_n140EstCod[0];
            A260CPTipCod = P009J12_A260CPTipCod[0];
            A262CPPrvCod = P009J12_A262CPPrvCod[0];
            A1910TipDsc = P009J12_A1910TipDsc[0];
            n1910TipDsc = P009J12_n1910TipDsc[0];
            A856CPTipAbr = P009J12_A856CPTipAbr[0];
            A817CPFVcto = P009J12_A817CPFVcto[0];
            A830CPMonDsc = P009J12_A830CPMonDsc[0];
            A511TipSigno = P009J12_A511TipSigno[0];
            n511TipSigno = P009J12_n511TipSigno[0];
            A820CPImpTotal = P009J12_A820CPImpTotal[0];
            A818CPImpPago = P009J12_A818CPImpPago[0];
            A261CPComCod = P009J12_A261CPComCod[0];
            A830CPMonDsc = P009J12_A830CPMonDsc[0];
            A1910TipDsc = P009J12_A1910TipDsc[0];
            n1910TipDsc = P009J12_n1910TipDsc[0];
            A856CPTipAbr = P009J12_A856CPTipAbr[0];
            A511TipSigno = P009J12_A511TipSigno[0];
            n511TipSigno = P009J12_n511TipSigno[0];
            A298TprvCod = P009J12_A298TprvCod[0];
            n298TprvCod = P009J12_n298TprvCod[0];
            A140EstCod = P009J12_A140EstCod[0];
            n140EstCod = P009J12_n140EstCod[0];
            AV18CPPrvCod = A262CPPrvCod;
            AV20CPTipCod = A260CPTipCod;
            AV54TipDsc = A1910TipDsc;
            AV50TipAbr = A856CPTipAbr;
            AV14CPComCod = A261CPComCod;
            AV15CPFech = A264CPFech;
            AV16CPFVcto = A817CPFVcto;
            AV39MonDsc = A830CPMonDsc;
            AV36Importe = (decimal)(A820CPImpTotal*A511TipSigno);
            AV45Pagos = (decimal)(A818CPImpPago*A511TipSigno);
            AV35ImpDoc = A820CPImpTotal;
            AV44PagoDoc = A818CPImpPago;
            AV17CPMonCod = A263CPMonCod;
            /* Execute user subroutine: 'PAGOS' */
            S1818 ();
            if ( returnInSub )
            {
               pr_default.close(10);
               returnInSub = true;
               if (true) return;
            }
            if ( ( AV44PagoDoc < Convert.ToDecimal( 0 )) )
            {
               AV44PagoDoc = 0;
            }
            AV36Importe = (decimal)(AV35ImpDoc*A511TipSigno);
            AV45Pagos = (decimal)(AV44PagoDoc*A511TipSigno);
            AV48Saldo = (decimal)((AV35ImpDoc-AV44PagoDoc)*A511TipSigno);
            AV21Dias = (int)(DateTimeUtil.DDiff(A817CPFVcto,DateTimeUtil.Today( context)));
            if ( ( AV48Saldo != Convert.ToDecimal( 0 )) )
            {
               AV65TotImporte = (decimal)(AV65TotImporte+AV36Importe);
               AV66TotPagos = (decimal)(AV66TotPagos+AV45Pagos);
               AV67TotSaldo = (decimal)(AV67TotSaldo+AV48Saldo);
               AV57TipImporte = (decimal)(AV57TipImporte+AV36Importe);
               AV59TipPagos = (decimal)(AV59TipPagos+AV45Pagos);
               AV60TipSaldo = (decimal)(AV60TipSaldo+AV48Saldo);
               AV71TotalMN = (decimal)(AV71TotalMN+(((AV17CPMonCod==1) ? AV48Saldo : (decimal)(0))));
               AV72TotalME = (decimal)(AV72TotalME+(((AV17CPMonCod==2) ? AV48Saldo : (decimal)(0))));
               H9J0( false, 17) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14CPComCod, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV15CPFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV16CPFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39MonDsc, "")), 394, Gx_line+2, 451, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+2, 566, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+2, 675, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+2, 779, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV21Dias), "ZZZZ9")), 313, Gx_line+1, 370, Gx_line+16, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
            }
            pr_default.readNext(10);
         }
         pr_default.close(10);
      }

      protected void S1818( )
      {
         /* 'PAGOS' Routine */
         returnInSub = false;
         /* Using cursor P009J13 */
         pr_default.execute(11, new Object[] {AV20CPTipCod, AV14CPComCod, AV27FHasta, AV18CPPrvCod});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A412PagReg = P009J13_A412PagReg[0];
            A418PagFech = P009J13_A418PagFech[0];
            A421PagDComCod = P009J13_A421PagDComCod[0];
            A420PagDTipCod = P009J13_A420PagDTipCod[0];
            A417PagPrvCod = P009J13_A417PagPrvCod[0];
            A413PagMonCod = P009J13_A413PagMonCod[0];
            A1481PagDTot = P009J13_A1481PagDTot[0];
            A1491PagTipCmb = P009J13_A1491PagTipCmb[0];
            A419PagItem = P009J13_A419PagItem[0];
            A418PagFech = P009J13_A418PagFech[0];
            A417PagPrvCod = P009J13_A417PagPrvCod[0];
            A413PagMonCod = P009J13_A413PagMonCod[0];
            A1491PagTipCmb = P009J13_A1491PagTipCmb[0];
            AV43PagMonCod = A413PagMonCod;
            AV42PagDTot = NumberUtil.Round( A1481PagDTot, 2);
            if ( ( AV42PagDTot < Convert.ToDecimal( 0 )) )
            {
               AV42PagDTot = (decimal)(AV42PagDTot*-1);
            }
            if ( AV17CPMonCod == AV43PagMonCod )
            {
               AV44PagoDoc = (decimal)(AV44PagoDoc-AV42PagDTot);
            }
            else
            {
               if ( AV17CPMonCod == 1 )
               {
                  AV44PagoDoc = (decimal)(AV44PagoDoc-(NumberUtil.Round( AV42PagDTot*A1491PagTipCmb, 2)));
               }
               else
               {
                  AV44PagoDoc = (decimal)(AV44PagoDoc-(NumberUtil.Round( AV42PagDTot/ (decimal)(A1491PagTipCmb), 2)));
               }
            }
            pr_default.readNext(11);
         }
         pr_default.close(11);
      }

      protected void S1514( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         AV33Flag = 0;
         pr_default.dynParam(12, new Object[]{ new Object[]{
                                              AV26EstCod ,
                                              AV68TprvCod ,
                                              AV38MonCod ,
                                              AV52TipCod ,
                                              AV56TipFecha ,
                                              A140EstCod ,
                                              A298TprvCod ,
                                              A263CPMonCod ,
                                              A260CPTipCod ,
                                              A264CPFech ,
                                              AV27FHasta ,
                                              A816CPFReg ,
                                              A815CPEstado ,
                                              A262CPPrvCod ,
                                              AV10Codigo } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P009J14 */
         pr_default.execute(12, new Object[] {AV10Codigo, AV26EstCod, AV68TprvCod, AV38MonCod, AV52TipCod, AV27FHasta, AV27FHasta});
         while ( (pr_default.getStatus(12) != 101) )
         {
            A815CPEstado = P009J14_A815CPEstado[0];
            A816CPFReg = P009J14_A816CPFReg[0];
            n816CPFReg = P009J14_n816CPFReg[0];
            A264CPFech = P009J14_A264CPFech[0];
            n264CPFech = P009J14_n264CPFech[0];
            A260CPTipCod = P009J14_A260CPTipCod[0];
            A263CPMonCod = P009J14_A263CPMonCod[0];
            A298TprvCod = P009J14_A298TprvCod[0];
            n298TprvCod = P009J14_n298TprvCod[0];
            A140EstCod = P009J14_A140EstCod[0];
            n140EstCod = P009J14_n140EstCod[0];
            A262CPPrvCod = P009J14_A262CPPrvCod[0];
            A820CPImpTotal = P009J14_A820CPImpTotal[0];
            A818CPImpPago = P009J14_A818CPImpPago[0];
            A511TipSigno = P009J14_A511TipSigno[0];
            n511TipSigno = P009J14_n511TipSigno[0];
            A261CPComCod = P009J14_A261CPComCod[0];
            A511TipSigno = P009J14_A511TipSigno[0];
            n511TipSigno = P009J14_n511TipSigno[0];
            A298TprvCod = P009J14_A298TprvCod[0];
            n298TprvCod = P009J14_n298TprvCod[0];
            A140EstCod = P009J14_A140EstCod[0];
            n140EstCod = P009J14_n140EstCod[0];
            AV18CPPrvCod = A262CPPrvCod;
            AV20CPTipCod = A260CPTipCod;
            AV14CPComCod = A261CPComCod;
            AV36Importe = A820CPImpTotal;
            AV45Pagos = A818CPImpPago;
            AV17CPMonCod = A263CPMonCod;
            AV35ImpDoc = A820CPImpTotal;
            AV44PagoDoc = A818CPImpPago;
            AV17CPMonCod = A263CPMonCod;
            /* Execute user subroutine: 'PAGOS' */
            S1818 ();
            if ( returnInSub )
            {
               pr_default.close(12);
               returnInSub = true;
               if (true) return;
            }
            if ( ( AV44PagoDoc < Convert.ToDecimal( 0 )) )
            {
               AV44PagoDoc = 0;
            }
            AV36Importe = (decimal)(AV35ImpDoc*A511TipSigno);
            AV45Pagos = (decimal)(AV44PagoDoc*A511TipSigno);
            AV48Saldo = (decimal)((AV35ImpDoc-AV44PagoDoc)*A511TipSigno);
            if ( ( AV48Saldo != Convert.ToDecimal( 0 )) )
            {
               AV33Flag = 1;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(12);
         }
         pr_default.close(12);
      }

      protected void S191( )
      {
         /* 'PAGOSADELANTADOS' Routine */
         returnInSub = false;
         pr_default.dynParam(13, new Object[]{ new Object[]{
                                              AV38MonCod ,
                                              AV52TipCod ,
                                              A413PagMonCod ,
                                              A420PagDTipCod ,
                                              A418PagFech ,
                                              AV27FHasta ,
                                              A816CPFReg } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P009J15 */
         pr_default.execute(13, new Object[] {AV27FHasta, AV27FHasta, AV38MonCod, AV52TipCod});
         while ( (pr_default.getStatus(13) != 101) )
         {
            BRK9J21 = false;
            A412PagReg = P009J15_A412PagReg[0];
            A421PagDComCod = P009J15_A421PagDComCod[0];
            A422PagDPrvCod = P009J15_A422PagDPrvCod[0];
            A1488PagPrvDsc = P009J15_A1488PagPrvDsc[0];
            A417PagPrvCod = P009J15_A417PagPrvCod[0];
            A420PagDTipCod = P009J15_A420PagDTipCod[0];
            A413PagMonCod = P009J15_A413PagMonCod[0];
            A816CPFReg = P009J15_A816CPFReg[0];
            n816CPFReg = P009J15_n816CPFReg[0];
            A418PagFech = P009J15_A418PagFech[0];
            A419PagItem = P009J15_A419PagItem[0];
            A417PagPrvCod = P009J15_A417PagPrvCod[0];
            A413PagMonCod = P009J15_A413PagMonCod[0];
            A418PagFech = P009J15_A418PagFech[0];
            A1488PagPrvDsc = P009J15_A1488PagPrvDsc[0];
            A816CPFReg = P009J15_A816CPFReg[0];
            n816CPFReg = P009J15_n816CPFReg[0];
            while ( (pr_default.getStatus(13) != 101) && ( StringUtil.StrCmp(P009J15_A417PagPrvCod[0], A417PagPrvCod) == 0 ) )
            {
               BRK9J21 = false;
               A412PagReg = P009J15_A412PagReg[0];
               A1488PagPrvDsc = P009J15_A1488PagPrvDsc[0];
               A419PagItem = P009J15_A419PagItem[0];
               A1488PagPrvDsc = P009J15_A1488PagPrvDsc[0];
               BRK9J21 = true;
               pr_default.readNext(13);
            }
            AV10Codigo = A417PagPrvCod;
            AV19CPPrvDsc = StringUtil.Trim( A417PagPrvCod) + " - " + StringUtil.Trim( A1488PagPrvDsc);
            AV65TotImporte = 0.00m;
            AV66TotPagos = 0.00m;
            AV67TotSaldo = 0.00m;
            H9J0( false, 21) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CPPrvDsc, "")), 8, Gx_line+4, 612, Gx_line+19, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+21);
            /* Execute user subroutine: 'PAGOADELANTADOSDETALLECXP' */
            S2021 ();
            if ( returnInSub )
            {
               pr_default.close(13);
               returnInSub = true;
               if (true) return;
            }
            H9J0( false, 24) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+6, 566, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+6, 675, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 779, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(465, Gx_line+1, 787, Gx_line+1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Proveedor", 331, Gx_line+5, 427, Gx_line+19, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+24);
            AV62TotGImporte = (decimal)(AV62TotGImporte+AV65TotImporte);
            AV63TotGPagos = (decimal)(AV63TotGPagos+AV66TotPagos);
            AV64TotGSaldo = (decimal)(AV64TotGSaldo+AV67TotSaldo);
            if ( ! BRK9J21 )
            {
               BRK9J21 = true;
               pr_default.readNext(13);
            }
         }
         pr_default.close(13);
      }

      protected void S2021( )
      {
         /* 'PAGOADELANTADOSDETALLECXP' Routine */
         returnInSub = false;
         pr_default.dynParam(14, new Object[]{ new Object[]{
                                              AV38MonCod ,
                                              AV52TipCod ,
                                              A413PagMonCod ,
                                              A420PagDTipCod ,
                                              A418PagFech ,
                                              AV27FHasta ,
                                              A816CPFReg ,
                                              AV10Codigo ,
                                              A417PagPrvCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P009J16 */
         pr_default.execute(14, new Object[] {AV10Codigo, AV27FHasta, AV27FHasta, AV38MonCod, AV52TipCod});
         while ( (pr_default.getStatus(14) != 101) )
         {
            A412PagReg = P009J16_A412PagReg[0];
            A422PagDPrvCod = P009J16_A422PagDPrvCod[0];
            A417PagPrvCod = P009J16_A417PagPrvCod[0];
            A420PagDTipCod = P009J16_A420PagDTipCod[0];
            A413PagMonCod = P009J16_A413PagMonCod[0];
            A816CPFReg = P009J16_A816CPFReg[0];
            n816CPFReg = P009J16_n816CPFReg[0];
            A418PagFech = P009J16_A418PagFech[0];
            A421PagDComCod = P009J16_A421PagDComCod[0];
            A306TipAbr = P009J16_A306TipAbr[0];
            n306TipAbr = P009J16_n306TipAbr[0];
            A264CPFech = P009J16_A264CPFech[0];
            n264CPFech = P009J16_n264CPFech[0];
            A1486PagMonDsc = P009J16_A1486PagMonDsc[0];
            A1481PagDTot = P009J16_A1481PagDTot[0];
            A419PagItem = P009J16_A419PagItem[0];
            A417PagPrvCod = P009J16_A417PagPrvCod[0];
            A413PagMonCod = P009J16_A413PagMonCod[0];
            A418PagFech = P009J16_A418PagFech[0];
            A1486PagMonDsc = P009J16_A1486PagMonDsc[0];
            A306TipAbr = P009J16_A306TipAbr[0];
            n306TipAbr = P009J16_n306TipAbr[0];
            A816CPFReg = P009J16_A816CPFReg[0];
            n816CPFReg = P009J16_n816CPFReg[0];
            A264CPFech = P009J16_A264CPFech[0];
            n264CPFech = P009J16_n264CPFech[0];
            AV14CPComCod = A421PagDComCod;
            AV50TipAbr = A306TipAbr;
            AV61TipSigno = -1;
            AV15CPFech = A264CPFech;
            AV16CPFVcto = A816CPFReg;
            AV41PagCBMon = A413PagMonCod;
            AV39MonDsc = A1486PagMonDsc;
            AV36Importe = (decimal)(A1481PagDTot*AV61TipSigno);
            AV45Pagos = 0;
            AV48Saldo = (decimal)(A1481PagDTot*AV61TipSigno);
            H9J0( false, 17) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14CPComCod, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV15CPFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV16CPFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39MonDsc, "")), 394, Gx_line+2, 451, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+2, 566, Gx_line+17, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+2, 675, Gx_line+17, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+2, 779, Gx_line+17, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV21Dias), "ZZZZ9")), 313, Gx_line+1, 370, Gx_line+16, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+17);
            AV65TotImporte = (decimal)(AV65TotImporte+AV36Importe);
            AV66TotPagos = (decimal)(AV66TotPagos+AV45Pagos);
            AV67TotSaldo = (decimal)(AV67TotSaldo+AV48Saldo);
            pr_default.readNext(14);
         }
         pr_default.close(14);
      }

      protected void H9J0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 664, Gx_line+31, 696, Gx_line+45, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 664, Gx_line+49, 708, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 664, Gx_line+14, 703, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 733, Gx_line+49, 772, Gx_line+64, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 710, Gx_line+31, 770, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 725, Gx_line+14, 772, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 14, Gx_line+221, 37, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Documento", 71, Gx_line+221, 156, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dias Vcto", 324, Gx_line+221, 379, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 395, Gx_line+221, 443, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe Total", 473, Gx_line+221, 556, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+214, 797, Gx_line+240, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuentas por Pagar", 302, Gx_line+71, 460, Gx_line+91, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 174, Gx_line+221, 209, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Vcto", 236, Gx_line+221, 301, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 719, Gx_line+221, 752, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pago", 616, Gx_line+221, 646, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Documento", 118, Gx_line+123, 233, Gx_line+137, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Proveedor", 118, Gx_line+145, 226, Gx_line+159, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 118, Gx_line+167, 166, Gx_line+181, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 118, Gx_line+190, 180, Gx_line+204, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28Filtro1, "")), 253, Gx_line+118, 596, Gx_line+142, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Filtro2, "")), 253, Gx_line+140, 596, Gx_line+164, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Filtro3, "")), 253, Gx_line+161, 596, Gx_line+185, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31Filtro4, "")), 253, Gx_line+184, 596, Gx_line+208, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24EmpRUC, "")), 14, Gx_line+46, 399, Gx_line+64, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22EmpDir, "")), 14, Gx_line+29, 399, Gx_line+47, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Empresa, "")), 14, Gx_line+11, 399, Gx_line+29, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 319, Gx_line+93, 349, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV27FHasta, "99/99/99"), 358, Gx_line+93, 440, Gx_line+114, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+240);
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
         AV23Empresa = "";
         AV49Session = context.GetSession();
         AV22EmpDir = "";
         AV24EmpRUC = "";
         AV47Ruta = "";
         AV37Logo = "";
         AV75Logo_GXI = "";
         AV28Filtro1 = "";
         AV29Filtro2 = "";
         AV30Filtro3 = "";
         AV31Filtro4 = "";
         AV32Filtro5 = "";
         scmdbuf = "";
         P009J2_A149TipCod = new string[] {""} ;
         P009J2_A1910TipDsc = new string[] {""} ;
         P009J2_n1910TipDsc = new bool[] {false} ;
         A149TipCod = "";
         A1910TipDsc = "";
         P009J3_A298TprvCod = new int[1] ;
         P009J3_n298TprvCod = new bool[] {false} ;
         P009J3_A1941TprvDsc = new string[] {""} ;
         A1941TprvDsc = "";
         P009J4_A180MonCod = new int[1] ;
         P009J4_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         P009J5_A244PrvCod = new string[] {""} ;
         P009J5_A247PrvDsc = new string[] {""} ;
         A244PrvCod = "";
         A247PrvDsc = "";
         AV69MonMN = "";
         AV70MonME = "";
         P009J6_A1234MonDsc = new string[] {""} ;
         P009J6_A180MonCod = new int[1] ;
         A262CPPrvCod = "";
         A140EstCod = "";
         A260CPTipCod = "";
         A815CPEstado = "";
         P009J7_A815CPEstado = new string[] {""} ;
         P009J7_A262CPPrvCod = new string[] {""} ;
         P009J7_A831CPPrvDsc = new string[] {""} ;
         P009J7_A260CPTipCod = new string[] {""} ;
         P009J7_A263CPMonCod = new int[1] ;
         P009J7_A298TprvCod = new int[1] ;
         P009J7_n298TprvCod = new bool[] {false} ;
         P009J7_A140EstCod = new string[] {""} ;
         P009J7_n140EstCod = new bool[] {false} ;
         P009J7_A818CPImpPago = new decimal[1] ;
         P009J7_A261CPComCod = new string[] {""} ;
         A831CPPrvDsc = "";
         A261CPComCod = "";
         AV19CPPrvDsc = "";
         AV10Codigo = "";
         P009J8_A831CPPrvDsc = new string[] {""} ;
         P009J8_A262CPPrvCod = new string[] {""} ;
         P009J8_A815CPEstado = new string[] {""} ;
         P009J8_A260CPTipCod = new string[] {""} ;
         P009J8_A263CPMonCod = new int[1] ;
         P009J8_A298TprvCod = new int[1] ;
         P009J8_n298TprvCod = new bool[] {false} ;
         P009J8_A140EstCod = new string[] {""} ;
         P009J8_n140EstCod = new bool[] {false} ;
         P009J8_A818CPImpPago = new decimal[1] ;
         P009J8_A261CPComCod = new string[] {""} ;
         P009J9_A815CPEstado = new string[] {""} ;
         P009J9_A263CPMonCod = new int[1] ;
         P009J9_A298TprvCod = new int[1] ;
         P009J9_n298TprvCod = new bool[] {false} ;
         P009J9_A140EstCod = new string[] {""} ;
         P009J9_n140EstCod = new bool[] {false} ;
         P009J9_A260CPTipCod = new string[] {""} ;
         P009J9_A262CPPrvCod = new string[] {""} ;
         P009J9_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P009J9_n264CPFech = new bool[] {false} ;
         P009J9_A817CPFVcto = new DateTime[] {DateTime.MinValue} ;
         P009J9_A830CPMonDsc = new string[] {""} ;
         P009J9_A511TipSigno = new short[1] ;
         P009J9_n511TipSigno = new bool[] {false} ;
         P009J9_A820CPImpTotal = new decimal[1] ;
         P009J9_A818CPImpPago = new decimal[1] ;
         P009J9_A261CPComCod = new string[] {""} ;
         P009J9_A856CPTipAbr = new string[] {""} ;
         P009J9_A1910TipDsc = new string[] {""} ;
         P009J9_n1910TipDsc = new bool[] {false} ;
         A264CPFech = DateTime.MinValue;
         A817CPFVcto = DateTime.MinValue;
         A830CPMonDsc = "";
         A856CPTipAbr = "";
         AV53TipCod2 = "";
         AV50TipAbr = "";
         AV55TipDsc2 = "";
         AV14CPComCod = "";
         AV15CPFech = DateTime.MinValue;
         AV16CPFVcto = DateTime.MinValue;
         AV39MonDsc = "";
         A816CPFReg = DateTime.MinValue;
         P009J10_A262CPPrvCod = new string[] {""} ;
         P009J10_A831CPPrvDsc = new string[] {""} ;
         P009J10_A815CPEstado = new string[] {""} ;
         P009J10_A816CPFReg = new DateTime[] {DateTime.MinValue} ;
         P009J10_n816CPFReg = new bool[] {false} ;
         P009J10_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P009J10_n264CPFech = new bool[] {false} ;
         P009J10_A260CPTipCod = new string[] {""} ;
         P009J10_A263CPMonCod = new int[1] ;
         P009J10_A298TprvCod = new int[1] ;
         P009J10_n298TprvCod = new bool[] {false} ;
         P009J10_A140EstCod = new string[] {""} ;
         P009J10_n140EstCod = new bool[] {false} ;
         P009J10_A818CPImpPago = new decimal[1] ;
         P009J10_A261CPComCod = new string[] {""} ;
         P009J11_A831CPPrvDsc = new string[] {""} ;
         P009J11_A262CPPrvCod = new string[] {""} ;
         P009J11_A815CPEstado = new string[] {""} ;
         P009J11_A816CPFReg = new DateTime[] {DateTime.MinValue} ;
         P009J11_n816CPFReg = new bool[] {false} ;
         P009J11_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P009J11_n264CPFech = new bool[] {false} ;
         P009J11_A260CPTipCod = new string[] {""} ;
         P009J11_A263CPMonCod = new int[1] ;
         P009J11_A298TprvCod = new int[1] ;
         P009J11_n298TprvCod = new bool[] {false} ;
         P009J11_A140EstCod = new string[] {""} ;
         P009J11_n140EstCod = new bool[] {false} ;
         P009J11_A818CPImpPago = new decimal[1] ;
         P009J11_A261CPComCod = new string[] {""} ;
         P009J12_A815CPEstado = new string[] {""} ;
         P009J12_A816CPFReg = new DateTime[] {DateTime.MinValue} ;
         P009J12_n816CPFReg = new bool[] {false} ;
         P009J12_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P009J12_n264CPFech = new bool[] {false} ;
         P009J12_A263CPMonCod = new int[1] ;
         P009J12_A298TprvCod = new int[1] ;
         P009J12_n298TprvCod = new bool[] {false} ;
         P009J12_A140EstCod = new string[] {""} ;
         P009J12_n140EstCod = new bool[] {false} ;
         P009J12_A260CPTipCod = new string[] {""} ;
         P009J12_A262CPPrvCod = new string[] {""} ;
         P009J12_A1910TipDsc = new string[] {""} ;
         P009J12_n1910TipDsc = new bool[] {false} ;
         P009J12_A856CPTipAbr = new string[] {""} ;
         P009J12_A817CPFVcto = new DateTime[] {DateTime.MinValue} ;
         P009J12_A830CPMonDsc = new string[] {""} ;
         P009J12_A511TipSigno = new short[1] ;
         P009J12_n511TipSigno = new bool[] {false} ;
         P009J12_A820CPImpTotal = new decimal[1] ;
         P009J12_A818CPImpPago = new decimal[1] ;
         P009J12_A261CPComCod = new string[] {""} ;
         AV18CPPrvCod = "";
         AV20CPTipCod = "";
         AV54TipDsc = "";
         P009J13_A412PagReg = new long[1] ;
         P009J13_A418PagFech = new DateTime[] {DateTime.MinValue} ;
         P009J13_A421PagDComCod = new string[] {""} ;
         P009J13_A420PagDTipCod = new string[] {""} ;
         P009J13_A417PagPrvCod = new string[] {""} ;
         P009J13_A413PagMonCod = new int[1] ;
         P009J13_A1481PagDTot = new decimal[1] ;
         P009J13_A1491PagTipCmb = new decimal[1] ;
         P009J13_A419PagItem = new short[1] ;
         A418PagFech = DateTime.MinValue;
         A421PagDComCod = "";
         A420PagDTipCod = "";
         A417PagPrvCod = "";
         P009J14_A815CPEstado = new string[] {""} ;
         P009J14_A816CPFReg = new DateTime[] {DateTime.MinValue} ;
         P009J14_n816CPFReg = new bool[] {false} ;
         P009J14_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P009J14_n264CPFech = new bool[] {false} ;
         P009J14_A260CPTipCod = new string[] {""} ;
         P009J14_A263CPMonCod = new int[1] ;
         P009J14_A298TprvCod = new int[1] ;
         P009J14_n298TprvCod = new bool[] {false} ;
         P009J14_A140EstCod = new string[] {""} ;
         P009J14_n140EstCod = new bool[] {false} ;
         P009J14_A262CPPrvCod = new string[] {""} ;
         P009J14_A820CPImpTotal = new decimal[1] ;
         P009J14_A818CPImpPago = new decimal[1] ;
         P009J14_A511TipSigno = new short[1] ;
         P009J14_n511TipSigno = new bool[] {false} ;
         P009J14_A261CPComCod = new string[] {""} ;
         P009J15_A412PagReg = new long[1] ;
         P009J15_A421PagDComCod = new string[] {""} ;
         P009J15_A422PagDPrvCod = new string[] {""} ;
         P009J15_A1488PagPrvDsc = new string[] {""} ;
         P009J15_A417PagPrvCod = new string[] {""} ;
         P009J15_A420PagDTipCod = new string[] {""} ;
         P009J15_A413PagMonCod = new int[1] ;
         P009J15_A816CPFReg = new DateTime[] {DateTime.MinValue} ;
         P009J15_n816CPFReg = new bool[] {false} ;
         P009J15_A418PagFech = new DateTime[] {DateTime.MinValue} ;
         P009J15_A419PagItem = new short[1] ;
         A422PagDPrvCod = "";
         A1488PagPrvDsc = "";
         P009J16_A412PagReg = new long[1] ;
         P009J16_A422PagDPrvCod = new string[] {""} ;
         P009J16_A417PagPrvCod = new string[] {""} ;
         P009J16_A420PagDTipCod = new string[] {""} ;
         P009J16_A413PagMonCod = new int[1] ;
         P009J16_A816CPFReg = new DateTime[] {DateTime.MinValue} ;
         P009J16_n816CPFReg = new bool[] {false} ;
         P009J16_A418PagFech = new DateTime[] {DateTime.MinValue} ;
         P009J16_A421PagDComCod = new string[] {""} ;
         P009J16_A306TipAbr = new string[] {""} ;
         P009J16_n306TipAbr = new bool[] {false} ;
         P009J16_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P009J16_n264CPFech = new bool[] {false} ;
         P009J16_A1486PagMonDsc = new string[] {""} ;
         P009J16_A1481PagDTot = new decimal[1] ;
         P009J16_A419PagItem = new short[1] ;
         A306TipAbr = "";
         A1486PagMonDsc = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_cuentasxpagarpdf__default(),
            new Object[][] {
                new Object[] {
               P009J2_A149TipCod, P009J2_A1910TipDsc
               }
               , new Object[] {
               P009J3_A298TprvCod, P009J3_A1941TprvDsc
               }
               , new Object[] {
               P009J4_A180MonCod, P009J4_A1234MonDsc
               }
               , new Object[] {
               P009J5_A244PrvCod, P009J5_A247PrvDsc
               }
               , new Object[] {
               P009J6_A1234MonDsc, P009J6_A180MonCod
               }
               , new Object[] {
               P009J7_A815CPEstado, P009J7_A262CPPrvCod, P009J7_A831CPPrvDsc, P009J7_A260CPTipCod, P009J7_A263CPMonCod, P009J7_A298TprvCod, P009J7_n298TprvCod, P009J7_A140EstCod, P009J7_n140EstCod, P009J7_A818CPImpPago,
               P009J7_A261CPComCod
               }
               , new Object[] {
               P009J8_A831CPPrvDsc, P009J8_A262CPPrvCod, P009J8_A815CPEstado, P009J8_A260CPTipCod, P009J8_A263CPMonCod, P009J8_A298TprvCod, P009J8_n298TprvCod, P009J8_A140EstCod, P009J8_n140EstCod, P009J8_A818CPImpPago,
               P009J8_A261CPComCod
               }
               , new Object[] {
               P009J9_A815CPEstado, P009J9_A263CPMonCod, P009J9_A298TprvCod, P009J9_n298TprvCod, P009J9_A140EstCod, P009J9_n140EstCod, P009J9_A260CPTipCod, P009J9_A262CPPrvCod, P009J9_A264CPFech, P009J9_A817CPFVcto,
               P009J9_A830CPMonDsc, P009J9_A511TipSigno, P009J9_n511TipSigno, P009J9_A820CPImpTotal, P009J9_A818CPImpPago, P009J9_A261CPComCod, P009J9_A856CPTipAbr, P009J9_A1910TipDsc, P009J9_n1910TipDsc
               }
               , new Object[] {
               P009J10_A262CPPrvCod, P009J10_A831CPPrvDsc, P009J10_A815CPEstado, P009J10_A816CPFReg, P009J10_A264CPFech, P009J10_A260CPTipCod, P009J10_A263CPMonCod, P009J10_A298TprvCod, P009J10_n298TprvCod, P009J10_A140EstCod,
               P009J10_n140EstCod, P009J10_A818CPImpPago, P009J10_A261CPComCod
               }
               , new Object[] {
               P009J11_A831CPPrvDsc, P009J11_A262CPPrvCod, P009J11_A815CPEstado, P009J11_A816CPFReg, P009J11_A264CPFech, P009J11_A260CPTipCod, P009J11_A263CPMonCod, P009J11_A298TprvCod, P009J11_n298TprvCod, P009J11_A140EstCod,
               P009J11_n140EstCod, P009J11_A818CPImpPago, P009J11_A261CPComCod
               }
               , new Object[] {
               P009J12_A815CPEstado, P009J12_A816CPFReg, P009J12_A264CPFech, P009J12_A263CPMonCod, P009J12_A298TprvCod, P009J12_n298TprvCod, P009J12_A140EstCod, P009J12_n140EstCod, P009J12_A260CPTipCod, P009J12_A262CPPrvCod,
               P009J12_A1910TipDsc, P009J12_n1910TipDsc, P009J12_A856CPTipAbr, P009J12_A817CPFVcto, P009J12_A830CPMonDsc, P009J12_A511TipSigno, P009J12_n511TipSigno, P009J12_A820CPImpTotal, P009J12_A818CPImpPago, P009J12_A261CPComCod
               }
               , new Object[] {
               P009J13_A412PagReg, P009J13_A418PagFech, P009J13_A421PagDComCod, P009J13_A420PagDTipCod, P009J13_A417PagPrvCod, P009J13_A413PagMonCod, P009J13_A1481PagDTot, P009J13_A1491PagTipCmb, P009J13_A419PagItem
               }
               , new Object[] {
               P009J14_A815CPEstado, P009J14_A816CPFReg, P009J14_A264CPFech, P009J14_A260CPTipCod, P009J14_A263CPMonCod, P009J14_A298TprvCod, P009J14_n298TprvCod, P009J14_A140EstCod, P009J14_n140EstCod, P009J14_A262CPPrvCod,
               P009J14_A820CPImpTotal, P009J14_A818CPImpPago, P009J14_A511TipSigno, P009J14_n511TipSigno, P009J14_A261CPComCod
               }
               , new Object[] {
               P009J15_A412PagReg, P009J15_A421PagDComCod, P009J15_A422PagDPrvCod, P009J15_A1488PagPrvDsc, P009J15_A417PagPrvCod, P009J15_A420PagDTipCod, P009J15_A413PagMonCod, P009J15_A816CPFReg, P009J15_n816CPFReg, P009J15_A418PagFech,
               P009J15_A419PagItem
               }
               , new Object[] {
               P009J16_A412PagReg, P009J16_A422PagDPrvCod, P009J16_A417PagPrvCod, P009J16_A420PagDTipCod, P009J16_A413PagMonCod, P009J16_A816CPFReg, P009J16_n816CPFReg, P009J16_A418PagFech, P009J16_A421PagDComCod, P009J16_A306TipAbr,
               P009J16_n306TipAbr, P009J16_A264CPFech, P009J16_n264CPFech, P009J16_A1486PagMonDsc, P009J16_A1481PagDTot, P009J16_A419PagItem
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
      private short AV33Flag ;
      private short A419PagItem ;
      private short AV61TipSigno ;
      private int AV68TprvCod ;
      private int AV38MonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A298TprvCod ;
      private int A180MonCod ;
      private int Gx_OldLine ;
      private int A263CPMonCod ;
      private int AV17CPMonCod ;
      private int AV21Dias ;
      private int A413PagMonCod ;
      private int AV43PagMonCod ;
      private int AV41PagCBMon ;
      private long A412PagReg ;
      private decimal AV62TotGImporte ;
      private decimal AV63TotGPagos ;
      private decimal AV64TotGSaldo ;
      private decimal AV71TotalMN ;
      private decimal AV72TotalME ;
      private decimal A818CPImpPago ;
      private decimal AV65TotImporte ;
      private decimal AV66TotPagos ;
      private decimal AV67TotSaldo ;
      private decimal A820CPImpTotal ;
      private decimal AV57TipImporte ;
      private decimal AV59TipPagos ;
      private decimal AV60TipSaldo ;
      private decimal AV36Importe ;
      private decimal AV45Pagos ;
      private decimal AV48Saldo ;
      private decimal AV35ImpDoc ;
      private decimal AV44PagoDoc ;
      private decimal A1481PagDTot ;
      private decimal A1491PagTipCmb ;
      private decimal AV42PagDTot ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV26EstCod ;
      private string AV46PrvCod ;
      private string AV52TipCod ;
      private string AV56TipFecha ;
      private string AV40Orden ;
      private string AV23Empresa ;
      private string AV22EmpDir ;
      private string AV24EmpRUC ;
      private string AV47Ruta ;
      private string AV28Filtro1 ;
      private string AV29Filtro2 ;
      private string AV30Filtro3 ;
      private string AV31Filtro4 ;
      private string AV32Filtro5 ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A1910TipDsc ;
      private string A1941TprvDsc ;
      private string A1234MonDsc ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A262CPPrvCod ;
      private string A140EstCod ;
      private string A260CPTipCod ;
      private string A815CPEstado ;
      private string A831CPPrvDsc ;
      private string A261CPComCod ;
      private string AV19CPPrvDsc ;
      private string AV10Codigo ;
      private string A830CPMonDsc ;
      private string A856CPTipAbr ;
      private string AV53TipCod2 ;
      private string AV50TipAbr ;
      private string AV55TipDsc2 ;
      private string AV14CPComCod ;
      private string AV39MonDsc ;
      private string AV18CPPrvCod ;
      private string AV20CPTipCod ;
      private string AV54TipDsc ;
      private string A421PagDComCod ;
      private string A420PagDTipCod ;
      private string A417PagPrvCod ;
      private string A422PagDPrvCod ;
      private string A1488PagPrvDsc ;
      private string A306TipAbr ;
      private string A1486PagMonDsc ;
      private string Gx_time ;
      private DateTime AV27FHasta ;
      private DateTime A264CPFech ;
      private DateTime A817CPFVcto ;
      private DateTime AV15CPFech ;
      private DateTime AV16CPFVcto ;
      private DateTime A816CPFReg ;
      private DateTime A418PagFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1910TipDsc ;
      private bool n298TprvCod ;
      private bool returnInSub ;
      private bool BRK9J8 ;
      private bool n140EstCod ;
      private bool BRK9J10 ;
      private bool BRK9J12 ;
      private bool n264CPFech ;
      private bool n511TipSigno ;
      private bool BRK9J14 ;
      private bool n816CPFReg ;
      private bool BRK9J16 ;
      private bool BRK9J21 ;
      private bool n306TipAbr ;
      private string AV75Logo_GXI ;
      private string AV69MonMN ;
      private string AV70MonME ;
      private string AV37Logo ;
      private IGxSession AV49Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TprvCod ;
      private string aP1_EstCod ;
      private string aP2_PrvCod ;
      private string aP3_TipCod ;
      private int aP4_MonCod ;
      private DateTime aP5_FHasta ;
      private string aP6_TipFecha ;
      private string aP7_Orden ;
      private IDataStoreProvider pr_default ;
      private string[] P009J2_A149TipCod ;
      private string[] P009J2_A1910TipDsc ;
      private bool[] P009J2_n1910TipDsc ;
      private int[] P009J3_A298TprvCod ;
      private bool[] P009J3_n298TprvCod ;
      private string[] P009J3_A1941TprvDsc ;
      private int[] P009J4_A180MonCod ;
      private string[] P009J4_A1234MonDsc ;
      private string[] P009J5_A244PrvCod ;
      private string[] P009J5_A247PrvDsc ;
      private string[] P009J6_A1234MonDsc ;
      private int[] P009J6_A180MonCod ;
      private string[] P009J7_A815CPEstado ;
      private string[] P009J7_A262CPPrvCod ;
      private string[] P009J7_A831CPPrvDsc ;
      private string[] P009J7_A260CPTipCod ;
      private int[] P009J7_A263CPMonCod ;
      private int[] P009J7_A298TprvCod ;
      private bool[] P009J7_n298TprvCod ;
      private string[] P009J7_A140EstCod ;
      private bool[] P009J7_n140EstCod ;
      private decimal[] P009J7_A818CPImpPago ;
      private string[] P009J7_A261CPComCod ;
      private string[] P009J8_A831CPPrvDsc ;
      private string[] P009J8_A262CPPrvCod ;
      private string[] P009J8_A815CPEstado ;
      private string[] P009J8_A260CPTipCod ;
      private int[] P009J8_A263CPMonCod ;
      private int[] P009J8_A298TprvCod ;
      private bool[] P009J8_n298TprvCod ;
      private string[] P009J8_A140EstCod ;
      private bool[] P009J8_n140EstCod ;
      private decimal[] P009J8_A818CPImpPago ;
      private string[] P009J8_A261CPComCod ;
      private string[] P009J9_A815CPEstado ;
      private int[] P009J9_A263CPMonCod ;
      private int[] P009J9_A298TprvCod ;
      private bool[] P009J9_n298TprvCod ;
      private string[] P009J9_A140EstCod ;
      private bool[] P009J9_n140EstCod ;
      private string[] P009J9_A260CPTipCod ;
      private string[] P009J9_A262CPPrvCod ;
      private DateTime[] P009J9_A264CPFech ;
      private bool[] P009J9_n264CPFech ;
      private DateTime[] P009J9_A817CPFVcto ;
      private string[] P009J9_A830CPMonDsc ;
      private short[] P009J9_A511TipSigno ;
      private bool[] P009J9_n511TipSigno ;
      private decimal[] P009J9_A820CPImpTotal ;
      private decimal[] P009J9_A818CPImpPago ;
      private string[] P009J9_A261CPComCod ;
      private string[] P009J9_A856CPTipAbr ;
      private string[] P009J9_A1910TipDsc ;
      private bool[] P009J9_n1910TipDsc ;
      private string[] P009J10_A262CPPrvCod ;
      private string[] P009J10_A831CPPrvDsc ;
      private string[] P009J10_A815CPEstado ;
      private DateTime[] P009J10_A816CPFReg ;
      private bool[] P009J10_n816CPFReg ;
      private DateTime[] P009J10_A264CPFech ;
      private bool[] P009J10_n264CPFech ;
      private string[] P009J10_A260CPTipCod ;
      private int[] P009J10_A263CPMonCod ;
      private int[] P009J10_A298TprvCod ;
      private bool[] P009J10_n298TprvCod ;
      private string[] P009J10_A140EstCod ;
      private bool[] P009J10_n140EstCod ;
      private decimal[] P009J10_A818CPImpPago ;
      private string[] P009J10_A261CPComCod ;
      private string[] P009J11_A831CPPrvDsc ;
      private string[] P009J11_A262CPPrvCod ;
      private string[] P009J11_A815CPEstado ;
      private DateTime[] P009J11_A816CPFReg ;
      private bool[] P009J11_n816CPFReg ;
      private DateTime[] P009J11_A264CPFech ;
      private bool[] P009J11_n264CPFech ;
      private string[] P009J11_A260CPTipCod ;
      private int[] P009J11_A263CPMonCod ;
      private int[] P009J11_A298TprvCod ;
      private bool[] P009J11_n298TprvCod ;
      private string[] P009J11_A140EstCod ;
      private bool[] P009J11_n140EstCod ;
      private decimal[] P009J11_A818CPImpPago ;
      private string[] P009J11_A261CPComCod ;
      private string[] P009J12_A815CPEstado ;
      private DateTime[] P009J12_A816CPFReg ;
      private bool[] P009J12_n816CPFReg ;
      private DateTime[] P009J12_A264CPFech ;
      private bool[] P009J12_n264CPFech ;
      private int[] P009J12_A263CPMonCod ;
      private int[] P009J12_A298TprvCod ;
      private bool[] P009J12_n298TprvCod ;
      private string[] P009J12_A140EstCod ;
      private bool[] P009J12_n140EstCod ;
      private string[] P009J12_A260CPTipCod ;
      private string[] P009J12_A262CPPrvCod ;
      private string[] P009J12_A1910TipDsc ;
      private bool[] P009J12_n1910TipDsc ;
      private string[] P009J12_A856CPTipAbr ;
      private DateTime[] P009J12_A817CPFVcto ;
      private string[] P009J12_A830CPMonDsc ;
      private short[] P009J12_A511TipSigno ;
      private bool[] P009J12_n511TipSigno ;
      private decimal[] P009J12_A820CPImpTotal ;
      private decimal[] P009J12_A818CPImpPago ;
      private string[] P009J12_A261CPComCod ;
      private long[] P009J13_A412PagReg ;
      private DateTime[] P009J13_A418PagFech ;
      private string[] P009J13_A421PagDComCod ;
      private string[] P009J13_A420PagDTipCod ;
      private string[] P009J13_A417PagPrvCod ;
      private int[] P009J13_A413PagMonCod ;
      private decimal[] P009J13_A1481PagDTot ;
      private decimal[] P009J13_A1491PagTipCmb ;
      private short[] P009J13_A419PagItem ;
      private string[] P009J14_A815CPEstado ;
      private DateTime[] P009J14_A816CPFReg ;
      private bool[] P009J14_n816CPFReg ;
      private DateTime[] P009J14_A264CPFech ;
      private bool[] P009J14_n264CPFech ;
      private string[] P009J14_A260CPTipCod ;
      private int[] P009J14_A263CPMonCod ;
      private int[] P009J14_A298TprvCod ;
      private bool[] P009J14_n298TprvCod ;
      private string[] P009J14_A140EstCod ;
      private bool[] P009J14_n140EstCod ;
      private string[] P009J14_A262CPPrvCod ;
      private decimal[] P009J14_A820CPImpTotal ;
      private decimal[] P009J14_A818CPImpPago ;
      private short[] P009J14_A511TipSigno ;
      private bool[] P009J14_n511TipSigno ;
      private string[] P009J14_A261CPComCod ;
      private long[] P009J15_A412PagReg ;
      private string[] P009J15_A421PagDComCod ;
      private string[] P009J15_A422PagDPrvCod ;
      private string[] P009J15_A1488PagPrvDsc ;
      private string[] P009J15_A417PagPrvCod ;
      private string[] P009J15_A420PagDTipCod ;
      private int[] P009J15_A413PagMonCod ;
      private DateTime[] P009J15_A816CPFReg ;
      private bool[] P009J15_n816CPFReg ;
      private DateTime[] P009J15_A418PagFech ;
      private short[] P009J15_A419PagItem ;
      private long[] P009J16_A412PagReg ;
      private string[] P009J16_A422PagDPrvCod ;
      private string[] P009J16_A417PagPrvCod ;
      private string[] P009J16_A420PagDTipCod ;
      private int[] P009J16_A413PagMonCod ;
      private DateTime[] P009J16_A816CPFReg ;
      private bool[] P009J16_n816CPFReg ;
      private DateTime[] P009J16_A418PagFech ;
      private string[] P009J16_A421PagDComCod ;
      private string[] P009J16_A306TipAbr ;
      private bool[] P009J16_n306TipAbr ;
      private DateTime[] P009J16_A264CPFech ;
      private bool[] P009J16_n264CPFech ;
      private string[] P009J16_A1486PagMonDsc ;
      private decimal[] P009J16_A1481PagDTot ;
      private short[] P009J16_A419PagItem ;
   }

   public class r_cuentasxpagarpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009J7( IGxContext context ,
                                             string AV46PrvCod ,
                                             string AV26EstCod ,
                                             int AV68TprvCod ,
                                             int AV38MonCod ,
                                             string AV52TipCod ,
                                             string A262CPPrvCod ,
                                             string A140EstCod ,
                                             int A298TprvCod ,
                                             int A263CPMonCod ,
                                             string A260CPTipCod ,
                                             string A815CPEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CPEstado], T1.[CPPrvCod] AS CPPrvCod, T2.[PrvDsc] AS CPPrvDsc, T1.[CPTipCod] AS CPTipCod, T1.[CPMonCod] AS CPMonCod, T2.[TprvCod], T2.[EstCod], T1.[CPImpPago], T1.[CPComCod] FROM ([CPCUENTAPAGAR] T1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = T1.[CPPrvCod])";
         AddWhere(sWhereString, "(T1.[CPEstado] = '')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPPrvCod] = @AV46PrvCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26EstCod)) )
         {
            AddWhere(sWhereString, "(T2.[EstCod] = @AV26EstCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV68TprvCod) )
         {
            AddWhere(sWhereString, "(T2.[TprvCod] = @AV68TprvCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV38MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CPMonCod] = @AV38MonCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPTipCod] = @AV52TipCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[PrvDsc], T1.[CPPrvCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P009J8( IGxContext context ,
                                             string AV46PrvCod ,
                                             string AV26EstCod ,
                                             int AV68TprvCod ,
                                             int AV38MonCod ,
                                             string AV52TipCod ,
                                             string A262CPPrvCod ,
                                             string A140EstCod ,
                                             int A298TprvCod ,
                                             int A263CPMonCod ,
                                             string A260CPTipCod ,
                                             string A815CPEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.[PrvDsc] AS CPPrvDsc, T1.[CPPrvCod] AS CPPrvCod, T1.[CPEstado], T1.[CPTipCod] AS CPTipCod, T1.[CPMonCod] AS CPMonCod, T2.[TprvCod], T2.[EstCod], T1.[CPImpPago], T1.[CPComCod] FROM ([CPCUENTAPAGAR] T1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = T1.[CPPrvCod])";
         AddWhere(sWhereString, "(T1.[CPEstado] = '')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPPrvCod] = @AV46PrvCod)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26EstCod)) )
         {
            AddWhere(sWhereString, "(T2.[EstCod] = @AV26EstCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV68TprvCod) )
         {
            AddWhere(sWhereString, "(T2.[TprvCod] = @AV68TprvCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV38MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CPMonCod] = @AV38MonCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPTipCod] = @AV52TipCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CPPrvCod], T2.[PrvDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P009J9( IGxContext context ,
                                             string AV26EstCod ,
                                             int AV68TprvCod ,
                                             int AV38MonCod ,
                                             string AV52TipCod ,
                                             string A140EstCod ,
                                             int A298TprvCod ,
                                             int A263CPMonCod ,
                                             string A260CPTipCod ,
                                             string A262CPPrvCod ,
                                             string AV10Codigo ,
                                             string A815CPEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[5];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[CPEstado], T1.[CPMonCod] AS CPMonCod, T4.[TprvCod], T4.[EstCod], T1.[CPTipCod] AS CPTipCod, T1.[CPPrvCod] AS CPPrvCod, T1.[CPFech], T1.[CPFVcto], T2.[MonDsc] AS CPMonDsc, T3.[TipSigno], T1.[CPImpTotal], T1.[CPImpPago], T1.[CPComCod], T3.[TipAbr] AS CPTipAbr, T3.[TipDsc] FROM ((([CPCUENTAPAGAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CPMonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CPTipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[CPPrvCod])";
         AddWhere(sWhereString, "(T1.[CPPrvCod] = @AV10Codigo)");
         AddWhere(sWhereString, "(T1.[CPEstado] = '')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26EstCod)) )
         {
            AddWhere(sWhereString, "(T4.[EstCod] = @AV26EstCod)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (0==AV68TprvCod) )
         {
            AddWhere(sWhereString, "(T4.[TprvCod] = @AV68TprvCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV38MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CPMonCod] = @AV38MonCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPTipCod] = @AV52TipCod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CPTipCod], T1.[CPComCod], T1.[CPPrvCod]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P009J10( IGxContext context ,
                                              string AV46PrvCod ,
                                              string AV26EstCod ,
                                              int AV68TprvCod ,
                                              int AV38MonCod ,
                                              string AV52TipCod ,
                                              string AV56TipFecha ,
                                              string A262CPPrvCod ,
                                              string A140EstCod ,
                                              int A298TprvCod ,
                                              int A263CPMonCod ,
                                              string A260CPTipCod ,
                                              DateTime A264CPFech ,
                                              DateTime AV27FHasta ,
                                              DateTime A816CPFReg ,
                                              string A815CPEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[7];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[CPPrvCod] AS CPPrvCod, T2.[PrvDsc] AS CPPrvDsc, T1.[CPEstado], T1.[CPFReg], T1.[CPFech], T1.[CPTipCod] AS CPTipCod, T1.[CPMonCod] AS CPMonCod, T2.[TprvCod], T2.[EstCod], T1.[CPImpPago], T1.[CPComCod] FROM ([CPCUENTAPAGAR] T1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = T1.[CPPrvCod])";
         AddWhere(sWhereString, "(T1.[CPEstado] <> 'A')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPPrvCod] = @AV46PrvCod)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26EstCod)) )
         {
            AddWhere(sWhereString, "(T2.[EstCod] = @AV26EstCod)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (0==AV68TprvCod) )
         {
            AddWhere(sWhereString, "(T2.[TprvCod] = @AV68TprvCod)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (0==AV38MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CPMonCod] = @AV38MonCod)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPTipCod] = @AV52TipCod)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( StringUtil.StrCmp(AV56TipFecha, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[CPFech] <= @AV27FHasta)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56TipFecha, "R") == 0 )
         {
            AddWhere(sWhereString, "(T1.[CPFReg] <= @AV27FHasta)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[PrvDsc], T1.[CPPrvCod]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P009J11( IGxContext context ,
                                              string AV46PrvCod ,
                                              string AV26EstCod ,
                                              int AV68TprvCod ,
                                              int AV38MonCod ,
                                              string AV52TipCod ,
                                              string AV56TipFecha ,
                                              string A262CPPrvCod ,
                                              string A140EstCod ,
                                              int A298TprvCod ,
                                              int A263CPMonCod ,
                                              string A260CPTipCod ,
                                              DateTime A264CPFech ,
                                              DateTime AV27FHasta ,
                                              DateTime A816CPFReg ,
                                              string A815CPEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[7];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T2.[PrvDsc] AS CPPrvDsc, T1.[CPPrvCod] AS CPPrvCod, T1.[CPEstado], T1.[CPFReg], T1.[CPFech], T1.[CPTipCod] AS CPTipCod, T1.[CPMonCod] AS CPMonCod, T2.[TprvCod], T2.[EstCod], T1.[CPImpPago], T1.[CPComCod] FROM ([CPCUENTAPAGAR] T1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = T1.[CPPrvCod])";
         AddWhere(sWhereString, "(T1.[CPEstado] <> 'A')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPPrvCod] = @AV46PrvCod)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26EstCod)) )
         {
            AddWhere(sWhereString, "(T2.[EstCod] = @AV26EstCod)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! (0==AV68TprvCod) )
         {
            AddWhere(sWhereString, "(T2.[TprvCod] = @AV68TprvCod)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! (0==AV38MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CPMonCod] = @AV38MonCod)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPTipCod] = @AV52TipCod)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( StringUtil.StrCmp(AV56TipFecha, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[CPFech] <= @AV27FHasta)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56TipFecha, "R") == 0 )
         {
            AddWhere(sWhereString, "(T1.[CPFReg] <= @AV27FHasta)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CPPrvCod], T2.[PrvDsc]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P009J12( IGxContext context ,
                                              string AV52TipCod ,
                                              string AV26EstCod ,
                                              int AV68TprvCod ,
                                              int AV38MonCod ,
                                              string AV56TipFecha ,
                                              string A260CPTipCod ,
                                              string A140EstCod ,
                                              int A298TprvCod ,
                                              int A263CPMonCod ,
                                              DateTime A264CPFech ,
                                              DateTime AV27FHasta ,
                                              DateTime A816CPFReg ,
                                              string A815CPEstado ,
                                              string A262CPPrvCod ,
                                              string AV10Codigo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[7];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.[CPEstado], T1.[CPFReg], T1.[CPFech], T1.[CPMonCod] AS CPMonCod, T4.[TprvCod], T4.[EstCod], T1.[CPTipCod] AS CPTipCod, T1.[CPPrvCod] AS CPPrvCod, T3.[TipDsc], T3.[TipAbr] AS CPTipAbr, T1.[CPFVcto], T2.[MonDsc] AS CPMonDsc, T3.[TipSigno], T1.[CPImpTotal], T1.[CPImpPago], T1.[CPComCod] FROM ((([CPCUENTAPAGAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CPMonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CPTipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[CPPrvCod])";
         AddWhere(sWhereString, "(T1.[CPEstado] <> 'A')");
         AddWhere(sWhereString, "(T1.[CPPrvCod] = @AV10Codigo)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPTipCod] = @AV52TipCod)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26EstCod)) )
         {
            AddWhere(sWhereString, "(T4.[EstCod] = @AV26EstCod)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ! (0==AV68TprvCod) )
         {
            AddWhere(sWhereString, "(T4.[TprvCod] = @AV68TprvCod)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! (0==AV38MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CPMonCod] = @AV38MonCod)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( StringUtil.StrCmp(AV56TipFecha, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[CPFech] <= @AV27FHasta)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56TipFecha, "R") == 0 )
         {
            AddWhere(sWhereString, "(T1.[CPFReg] <= @AV27FHasta)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CPTipCod], T1.[CPComCod], T1.[CPPrvCod]";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P009J14( IGxContext context ,
                                              string AV26EstCod ,
                                              int AV68TprvCod ,
                                              int AV38MonCod ,
                                              string AV52TipCod ,
                                              string AV56TipFecha ,
                                              string A140EstCod ,
                                              int A298TprvCod ,
                                              int A263CPMonCod ,
                                              string A260CPTipCod ,
                                              DateTime A264CPFech ,
                                              DateTime AV27FHasta ,
                                              DateTime A816CPFReg ,
                                              string A815CPEstado ,
                                              string A262CPPrvCod ,
                                              string AV10Codigo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[7];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT T1.[CPEstado], T1.[CPFReg], T1.[CPFech], T1.[CPTipCod] AS CPTipCod, T1.[CPMonCod] AS CPMonCod, T3.[TprvCod], T3.[EstCod], T1.[CPPrvCod] AS CPPrvCod, T1.[CPImpTotal], T1.[CPImpPago], T2.[TipSigno], T1.[CPComCod] FROM (([CPCUENTAPAGAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CPTipCod]) INNER JOIN [CPPROVEEDORES] T3 ON T3.[PrvCod] = T1.[CPPrvCod])";
         AddWhere(sWhereString, "(T1.[CPEstado] <> 'A')");
         AddWhere(sWhereString, "(T1.[CPPrvCod] = @AV10Codigo)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26EstCod)) )
         {
            AddWhere(sWhereString, "(T3.[EstCod] = @AV26EstCod)");
         }
         else
         {
            GXv_int13[1] = 1;
         }
         if ( ! (0==AV68TprvCod) )
         {
            AddWhere(sWhereString, "(T3.[TprvCod] = @AV68TprvCod)");
         }
         else
         {
            GXv_int13[2] = 1;
         }
         if ( ! (0==AV38MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CPMonCod] = @AV38MonCod)");
         }
         else
         {
            GXv_int13[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPTipCod] = @AV52TipCod)");
         }
         else
         {
            GXv_int13[4] = 1;
         }
         if ( StringUtil.StrCmp(AV56TipFecha, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[CPFech] <= @AV27FHasta)");
         }
         else
         {
            GXv_int13[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56TipFecha, "R") == 0 )
         {
            AddWhere(sWhereString, "(T1.[CPFReg] <= @AV27FHasta)");
         }
         else
         {
            GXv_int13[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CPTipCod], T1.[CPComCod], T1.[CPPrvCod]";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      protected Object[] conditional_P009J15( IGxContext context ,
                                              int AV38MonCod ,
                                              string AV52TipCod ,
                                              int A413PagMonCod ,
                                              string A420PagDTipCod ,
                                              DateTime A418PagFech ,
                                              DateTime AV27FHasta ,
                                              DateTime A816CPFReg )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[4];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT T1.[PagReg], T1.[PagDComCod] AS PagDComCod, T1.[PagDPrvCod] AS PagDPrvCod, T3.[PrvDsc] AS PagPrvDsc, T2.[PagPrvCod] AS PagPrvCod, T1.[PagDTipCod] AS PagDTipCod, T2.[PagMonCod] AS PagMonCod, T4.[CPFReg], T2.[PagFech], T1.[PagItem] FROM ((([TSPAGOSDET] T1 INNER JOIN [TSPAGOS] T2 ON T2.[PagReg] = T1.[PagReg]) INNER JOIN [CPPROVEEDORES] T3 ON T3.[PrvCod] = T2.[PagPrvCod]) INNER JOIN [CPCUENTAPAGAR] T4 ON T4.[CPTipCod] = T1.[PagDTipCod] AND T4.[CPComCod] = T1.[PagDComCod] AND T4.[CPPrvCod] = T1.[PagDPrvCod])";
         AddWhere(sWhereString, "(T2.[PagFech] <= @AV27FHasta)");
         AddWhere(sWhereString, "(T4.[CPFReg] > @AV27FHasta)");
         if ( ! (0==AV38MonCod) )
         {
            AddWhere(sWhereString, "(T2.[PagMonCod] = @AV38MonCod)");
         }
         else
         {
            GXv_int15[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[PagDTipCod] = @AV52TipCod)");
         }
         else
         {
            GXv_int15[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[PagPrvCod], T3.[PrvDsc]";
         GXv_Object16[0] = scmdbuf;
         GXv_Object16[1] = GXv_int15;
         return GXv_Object16 ;
      }

      protected Object[] conditional_P009J16( IGxContext context ,
                                              int AV38MonCod ,
                                              string AV52TipCod ,
                                              int A413PagMonCod ,
                                              string A420PagDTipCod ,
                                              DateTime A418PagFech ,
                                              DateTime AV27FHasta ,
                                              DateTime A816CPFReg ,
                                              string AV10Codigo ,
                                              string A417PagPrvCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int17 = new short[5];
         Object[] GXv_Object18 = new Object[2];
         scmdbuf = "SELECT T1.[PagReg], T1.[PagDPrvCod] AS PagDPrvCod, T2.[PagPrvCod] AS PagPrvCod, T1.[PagDTipCod] AS PagDTipCod, T2.[PagMonCod] AS PagMonCod, T5.[CPFReg], T2.[PagFech], T1.[PagDComCod] AS PagDComCod, T4.[TipAbr], T5.[CPFech], T3.[MonDsc] AS PagMonDsc, T1.[PagDTot], T1.[PagItem] FROM (((([TSPAGOSDET] T1 INNER JOIN [TSPAGOS] T2 ON T2.[PagReg] = T1.[PagReg]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T2.[PagMonCod]) INNER JOIN [CTIPDOC] T4 ON T4.[TipCod] = T1.[PagDTipCod]) INNER JOIN [CPCUENTAPAGAR] T5 ON T5.[CPTipCod] = T1.[PagDTipCod] AND T5.[CPComCod] = T1.[PagDComCod] AND T5.[CPPrvCod] = T1.[PagDPrvCod])";
         AddWhere(sWhereString, "(T2.[PagPrvCod] = @AV10Codigo)");
         AddWhere(sWhereString, "(T2.[PagFech] <= @AV27FHasta)");
         AddWhere(sWhereString, "(T5.[CPFReg] > @AV27FHasta)");
         if ( ! (0==AV38MonCod) )
         {
            AddWhere(sWhereString, "(T2.[PagMonCod] = @AV38MonCod)");
         }
         else
         {
            GXv_int17[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[PagDTipCod] = @AV52TipCod)");
         }
         else
         {
            GXv_int17[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[PagPrvCod]";
         GXv_Object18[0] = scmdbuf;
         GXv_Object18[1] = GXv_int17;
         return GXv_Object18 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 5 :
                     return conditional_P009J7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
               case 6 :
                     return conditional_P009J8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
               case 7 :
                     return conditional_P009J9(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
               case 8 :
                     return conditional_P009J10(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] );
               case 9 :
                     return conditional_P009J11(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (string)dynConstraints[14] );
               case 10 :
                     return conditional_P009J12(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] );
               case 12 :
                     return conditional_P009J14(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] );
               case 13 :
                     return conditional_P009J15(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] );
               case 14 :
                     return conditional_P009J16(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] );
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
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009J2;
          prmP009J2 = new Object[] {
          new ParDef("@AV52TipCod",GXType.NChar,3,0)
          };
          Object[] prmP009J3;
          prmP009J3 = new Object[] {
          new ParDef("@AV68TprvCod",GXType.Int32,6,0)
          };
          Object[] prmP009J4;
          prmP009J4 = new Object[] {
          new ParDef("@AV38MonCod",GXType.Int32,6,0)
          };
          Object[] prmP009J5;
          prmP009J5 = new Object[] {
          new ParDef("@AV46PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP009J6;
          prmP009J6 = new Object[] {
          };
          Object[] prmP009J13;
          prmP009J13 = new Object[] {
          new ParDef("@AV20CPTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV14CPComCod",GXType.NChar,15,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV18CPPrvCod",GXType.NChar,20,0)
          };
          Object[] prmP009J7;
          prmP009J7 = new Object[] {
          new ParDef("@AV46PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV26EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV68TprvCod",GXType.Int32,6,0) ,
          new ParDef("@AV38MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV52TipCod",GXType.NChar,3,0)
          };
          Object[] prmP009J8;
          prmP009J8 = new Object[] {
          new ParDef("@AV46PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV26EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV68TprvCod",GXType.Int32,6,0) ,
          new ParDef("@AV38MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV52TipCod",GXType.NChar,3,0)
          };
          Object[] prmP009J9;
          prmP009J9 = new Object[] {
          new ParDef("@AV10Codigo",GXType.NChar,20,0) ,
          new ParDef("@AV26EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV68TprvCod",GXType.Int32,6,0) ,
          new ParDef("@AV38MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV52TipCod",GXType.NChar,3,0)
          };
          Object[] prmP009J10;
          prmP009J10 = new Object[] {
          new ParDef("@AV46PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV26EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV68TprvCod",GXType.Int32,6,0) ,
          new ParDef("@AV38MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV52TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0)
          };
          Object[] prmP009J11;
          prmP009J11 = new Object[] {
          new ParDef("@AV46PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV26EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV68TprvCod",GXType.Int32,6,0) ,
          new ParDef("@AV38MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV52TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0)
          };
          Object[] prmP009J12;
          prmP009J12 = new Object[] {
          new ParDef("@AV10Codigo",GXType.NChar,20,0) ,
          new ParDef("@AV52TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV26EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV68TprvCod",GXType.Int32,6,0) ,
          new ParDef("@AV38MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0)
          };
          Object[] prmP009J14;
          prmP009J14 = new Object[] {
          new ParDef("@AV10Codigo",GXType.NChar,20,0) ,
          new ParDef("@AV26EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV68TprvCod",GXType.Int32,6,0) ,
          new ParDef("@AV38MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV52TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0)
          };
          Object[] prmP009J15;
          prmP009J15 = new Object[] {
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV38MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV52TipCod",GXType.NChar,3,0)
          };
          Object[] prmP009J16;
          prmP009J16 = new Object[] {
          new ParDef("@AV10Codigo",GXType.NChar,20,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV27FHasta",GXType.Date,8,0) ,
          new ParDef("@AV38MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV52TipCod",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009J2", "SELECT [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipCod] = @AV52TipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009J3", "SELECT [TprvCod], [TprvDsc] FROM [CTIPOPROVEEDOR] WHERE [TprvCod] = @AV68TprvCod ORDER BY [TprvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009J4", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV38MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009J5", "SELECT [PrvCod], [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @AV46PrvCod ORDER BY [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009J6", "SELECT [MonDsc], [MonCod] FROM [CMONEDAS] ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009J7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009J8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009J9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009J10", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009J11", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009J12", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009J13", "SELECT T1.[PagReg], T2.[PagFech], T1.[PagDComCod] AS PagDComCod, T1.[PagDTipCod] AS PagDTipCod, T2.[PagPrvCod] AS PagPrvCod, T2.[PagMonCod] AS PagMonCod, T1.[PagDTot], T2.[PagTipCmb], T1.[PagItem] FROM ([TSPAGOSDET] T1 INNER JOIN [TSPAGOS] T2 ON T2.[PagReg] = T1.[PagReg]) WHERE (T1.[PagDTipCod] = @AV20CPTipCod and T1.[PagDComCod] = @AV14CPComCod) AND (T2.[PagFech] > @AV27FHasta) AND (T2.[PagPrvCod] = @AV18CPPrvCod) ORDER BY T1.[PagDTipCod], T1.[PagDComCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J13,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009J14", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009J15", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009J16", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009J16,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 4);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 15);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 4);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 15);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 3);
                ((string[]) buf[7])[0] = rslt.getString(6, 20);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 100);
                ((short[]) buf[11])[0] = rslt.getShort(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(12);
                ((string[]) buf[15])[0] = rslt.getString(13, 15);
                ((string[]) buf[16])[0] = rslt.getString(14, 5);
                ((string[]) buf[17])[0] = rslt.getString(15, 100);
                ((bool[]) buf[18])[0] = rslt.wasNull(15);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 4);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 15);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 4);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 15);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 4);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((string[]) buf[10])[0] = rslt.getString(9, 100);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 5);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(11);
                ((string[]) buf[14])[0] = rslt.getString(12, 100);
                ((short[]) buf[15])[0] = rslt.getShort(13);
                ((bool[]) buf[16])[0] = rslt.wasNull(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(15);
                ((string[]) buf[19])[0] = rslt.getString(16, 15);
                return;
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 4);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((short[]) buf[12])[0] = rslt.getShort(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((string[]) buf[14])[0] = rslt.getString(12, 15);
                return;
             case 13 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((short[]) buf[10])[0] = rslt.getShort(10);
                return;
             case 14 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 15);
                ((string[]) buf[9])[0] = rslt.getString(9, 5);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((string[]) buf[13])[0] = rslt.getString(11, 100);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(12);
                ((short[]) buf[15])[0] = rslt.getShort(13);
                return;
       }
    }

 }

}
