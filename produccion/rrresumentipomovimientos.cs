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
namespace GeneXus.Programs.produccion {
   public class rrresumentipomovimientos : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "produccion.rrresumentipomovimientos.aspx")), "produccion.rrresumentipomovimientos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "produccion.rrresumentipomovimientos.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "MovCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV31MovCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV28LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
                  AV37Prodcod = GetPar( "Prodcod");
                  AV24Hdesde = context.localUtil.ParseDateParm( GetPar( "Hdesde"));
                  AV25HHasta = context.localUtil.ParseDateParm( GetPar( "HHasta"));
                  AV43SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV17FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
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

      public rrresumentipomovimientos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrresumentipomovimientos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_MovCod ,
                           ref int aP1_LinCod ,
                           ref string aP2_Prodcod ,
                           ref DateTime aP3_Hdesde ,
                           ref DateTime aP4_HHasta ,
                           ref int aP5_SubLCod ,
                           ref int aP6_FamCod )
      {
         this.AV31MovCod = aP0_MovCod;
         this.AV28LinCod = aP1_LinCod;
         this.AV37Prodcod = aP2_Prodcod;
         this.AV24Hdesde = aP3_Hdesde;
         this.AV25HHasta = aP4_HHasta;
         this.AV43SubLCod = aP5_SubLCod;
         this.AV17FamCod = aP6_FamCod;
         initialize();
         executePrivate();
         aP0_MovCod=this.AV31MovCod;
         aP1_LinCod=this.AV28LinCod;
         aP2_Prodcod=this.AV37Prodcod;
         aP3_Hdesde=this.AV24Hdesde;
         aP4_HHasta=this.AV25HHasta;
         aP5_SubLCod=this.AV43SubLCod;
         aP6_FamCod=this.AV17FamCod;
      }

      public int executeUdp( ref int aP0_MovCod ,
                             ref int aP1_LinCod ,
                             ref string aP2_Prodcod ,
                             ref DateTime aP3_Hdesde ,
                             ref DateTime aP4_HHasta ,
                             ref int aP5_SubLCod )
      {
         execute(ref aP0_MovCod, ref aP1_LinCod, ref aP2_Prodcod, ref aP3_Hdesde, ref aP4_HHasta, ref aP5_SubLCod, ref aP6_FamCod);
         return AV17FamCod ;
      }

      public void executeSubmit( ref int aP0_MovCod ,
                                 ref int aP1_LinCod ,
                                 ref string aP2_Prodcod ,
                                 ref DateTime aP3_Hdesde ,
                                 ref DateTime aP4_HHasta ,
                                 ref int aP5_SubLCod ,
                                 ref int aP6_FamCod )
      {
         rrresumentipomovimientos objrrresumentipomovimientos;
         objrrresumentipomovimientos = new rrresumentipomovimientos();
         objrrresumentipomovimientos.AV31MovCod = aP0_MovCod;
         objrrresumentipomovimientos.AV28LinCod = aP1_LinCod;
         objrrresumentipomovimientos.AV37Prodcod = aP2_Prodcod;
         objrrresumentipomovimientos.AV24Hdesde = aP3_Hdesde;
         objrrresumentipomovimientos.AV25HHasta = aP4_HHasta;
         objrrresumentipomovimientos.AV43SubLCod = aP5_SubLCod;
         objrrresumentipomovimientos.AV17FamCod = aP6_FamCod;
         objrrresumentipomovimientos.context.SetSubmitInitialConfig(context);
         objrrresumentipomovimientos.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrresumentipomovimientos);
         aP0_MovCod=this.AV31MovCod;
         aP1_LinCod=this.AV28LinCod;
         aP2_Prodcod=this.AV37Prodcod;
         aP3_Hdesde=this.AV24Hdesde;
         aP4_HHasta=this.AV25HHasta;
         aP5_SubLCod=this.AV43SubLCod;
         aP6_FamCod=this.AV17FamCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrresumentipomovimientos)stateInfo).executePrivate();
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
            AV14Empresa = AV42Session.Get("Empresa");
            AV13EmpDir = AV42Session.Get("EmpDir");
            AV15EmpRUC = AV42Session.Get("EmpRUC");
            AV38Ruta = AV42Session.Get("RUTA") + "/Logo.jpg";
            AV29Logo = AV38Ruta;
            AV60Logo_GXI = GXDbFile.PathToUrl( AV38Ruta);
            AV18Filtro1 = "Todos";
            AV19Filtro2 = "Todos";
            AV20Filtro3 = "Todos";
            AV21Filtro4 = "Todos";
            /* Using cursor P00G22 */
            pr_default.execute(0, new Object[] {AV31MovCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A234MovCod = P00G22_A234MovCod[0];
               A1239MovDsc = P00G22_A1239MovDsc[0];
               AV18Filtro1 = A1239MovDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00G23 */
            pr_default.execute(1, new Object[] {AV37Prodcod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = P00G23_A28ProdCod[0];
               A55ProdDsc = P00G23_A55ProdDsc[0];
               AV20Filtro3 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00G24 */
            pr_default.execute(2, new Object[] {AV28LinCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A52LinCod = P00G24_A52LinCod[0];
               A1153LinDsc = P00G24_A1153LinDsc[0];
               AV21Filtro4 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            AV49TotalCantidad = 0.00m;
            AV50TotalCosto = 0.00m;
            AV40SaldoCant = 0.00m;
            AV41SaldoImp = 0.00m;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV31MovCod ,
                                                 AV28LinCod ,
                                                 AV37Prodcod ,
                                                 AV9AlmCod ,
                                                 AV43SubLCod ,
                                                 AV17FamCod ,
                                                 A22MvAMov ,
                                                 A52LinCod ,
                                                 A28ProdCod ,
                                                 A21MvAlm ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A1370MVSts ,
                                                 A1158LinStk ,
                                                 A1269MvAlmCos } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00G25 */
            pr_default.execute(3, new Object[] {AV31MovCod, AV28LinCod, AV37Prodcod, AV9AlmCod, AV43SubLCod, AV17FamCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               BRKG26 = false;
               A13MvATip = P00G25_A13MvATip[0];
               A14MvACod = P00G25_A14MvACod[0];
               A55ProdDsc = P00G25_A55ProdDsc[0];
               A28ProdCod = P00G25_A28ProdCod[0];
               A1269MvAlmCos = P00G25_A1269MvAlmCos[0];
               A1158LinStk = P00G25_A1158LinStk[0];
               A1370MVSts = P00G25_A1370MVSts[0];
               A50FamCod = P00G25_A50FamCod[0];
               n50FamCod = P00G25_n50FamCod[0];
               A51SublCod = P00G25_A51SublCod[0];
               n51SublCod = P00G25_n51SublCod[0];
               A21MvAlm = P00G25_A21MvAlm[0];
               A52LinCod = P00G25_A52LinCod[0];
               A22MvAMov = P00G25_A22MvAMov[0];
               A30MvADItem = P00G25_A30MvADItem[0];
               A1370MVSts = P00G25_A1370MVSts[0];
               A21MvAlm = P00G25_A21MvAlm[0];
               A22MvAMov = P00G25_A22MvAMov[0];
               A1269MvAlmCos = P00G25_A1269MvAlmCos[0];
               A55ProdDsc = P00G25_A55ProdDsc[0];
               A50FamCod = P00G25_A50FamCod[0];
               n50FamCod = P00G25_n50FamCod[0];
               A51SublCod = P00G25_A51SublCod[0];
               n51SublCod = P00G25_n51SublCod[0];
               A52LinCod = P00G25_A52LinCod[0];
               A1158LinStk = P00G25_A1158LinStk[0];
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00G25_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRKG26 = false;
                  A13MvATip = P00G25_A13MvATip[0];
                  A14MvACod = P00G25_A14MvACod[0];
                  A55ProdDsc = P00G25_A55ProdDsc[0];
                  A30MvADItem = P00G25_A30MvADItem[0];
                  A55ProdDsc = P00G25_A55ProdDsc[0];
                  BRKG26 = true;
                  pr_default.readNext(3);
               }
               new GeneXus.Programs.produccion.pobtenersaldocostoproductofechas(context ).execute( ref  AV24Hdesde, ref  A28ProdCod, out  AV39Saldo, out  AV12CostoU) ;
               AV40SaldoCant = (decimal)(AV40SaldoCant+AV39Saldo);
               AV41SaldoImp = (decimal)(AV41SaldoImp+(NumberUtil.Round( AV12CostoU*AV39Saldo, 2)));
               if ( ! BRKG26 )
               {
                  BRKG26 = true;
                  pr_default.readNext(3);
               }
            }
            pr_default.close(3);
            HG20( false, 21) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Saldo Inicial", 309, Gx_line+5, 381, Gx_line+19, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40SaldoCant, "ZZZZ,ZZZ,ZZ9.9999")), 414, Gx_line+7, 521, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41SaldoImp, "ZZZZZZ,ZZZ,ZZ9.99")), 527, Gx_line+5, 634, Gx_line+20, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+21);
            AV49TotalCantidad = AV40SaldoCant;
            AV50TotalCosto = AV41SaldoImp;
            AV26I = 1;
            while ( AV26I <= 2 )
            {
               AV46Tipo = ((AV26I==1) ? "INGRESO" : "SALIDA");
               AV32MovTip = (short)(((AV26I==1) ? 1 : 2));
               AV27Item = 1;
               AV51TotalP = 0.0000m;
               AV48TotalC = 0.00m;
               HG20( false, 22) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Tipo, "")), 13, Gx_line+4, 639, Gx_line+19, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+22);
               /* Using cursor P00G26 */
               pr_default.execute(4, new Object[] {AV32MovTip});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A1241MovTip = P00G26_A1241MovTip[0];
                  A1239MovDsc = P00G26_A1239MovDsc[0];
                  A234MovCod = P00G26_A234MovCod[0];
                  AV33MvAMov = A234MovCod;
                  AV27Item = A234MovCod;
                  AV34MvAMovDsc = StringUtil.Trim( A1239MovDsc);
                  AV10Cantidad = 0.0000m;
                  AV47Total = 0.00m;
                  /* Execute user subroutine: 'MOVIMIENTO' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(4);
                     this.cleanup();
                     if (true) return;
                  }
                  if ( ! ( AV10Cantidad == Convert.ToDecimal( 0 )) )
                  {
                     HG20( false, 17) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV27Item), "ZZZZ9")), 14, Gx_line+2, 46, Gx_line+17, 1+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34MvAMovDsc, "")), 75, Gx_line+2, 406, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV10Cantidad, "ZZZZ,ZZZ,ZZ9.9999")), 414, Gx_line+2, 521, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47Total, "ZZZZZZ,ZZZ,ZZ9.99")), 527, Gx_line+2, 634, Gx_line+17, 2+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
                  }
                  if ( StringUtil.StrCmp(AV46Tipo, "INGRESO") == 0 )
                  {
                     AV51TotalP = (decimal)(AV51TotalP+AV10Cantidad);
                     AV48TotalC = (decimal)(AV48TotalC+AV47Total);
                  }
                  else
                  {
                     AV51TotalP = (decimal)(AV51TotalP-AV10Cantidad);
                     AV48TotalC = (decimal)(AV48TotalC-AV47Total);
                  }
                  pr_default.readNext(4);
               }
               pr_default.close(4);
               AV49TotalCantidad = (decimal)(AV49TotalCantidad+AV51TotalP);
               AV50TotalCosto = (decimal)(AV50TotalCosto+AV48TotalC);
               HG20( false, 28) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total : ", 227, Gx_line+9, 268, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48TotalC, "ZZZZZZ,ZZZ,ZZ9.99")), 527, Gx_line+9, 634, Gx_line+24, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(401, Gx_line+4, 654, Gx_line+4, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51TotalP, "ZZZZ,ZZZ,ZZ9.9999")), 414, Gx_line+9, 521, Gx_line+24, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Tipo, "")), 267, Gx_line+9, 390, Gx_line+23, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+28);
               AV26I = (short)(AV26I+1);
            }
            HG20( false, 50) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Saldo Final", 309, Gx_line+22, 373, Gx_line+36, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49TotalCantidad, "ZZZZ,ZZZ,ZZ9.9999")), 414, Gx_line+22, 521, Gx_line+37, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50TotalCosto, "ZZZZZZ,ZZZ,ZZ9.99")), 527, Gx_line+22, 634, Gx_line+37, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(401, Gx_line+18, 654, Gx_line+18, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+50);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HG20( true, 0) ;
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
         /* 'MOVIMIENTO' Routine */
         returnInSub = false;
         /* Optimized group. */
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV28LinCod ,
                                              AV37Prodcod ,
                                              AV9AlmCod ,
                                              AV43SubLCod ,
                                              AV17FamCod ,
                                              AV32MovTip ,
                                              A52LinCod ,
                                              A28ProdCod ,
                                              A21MvAlm ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A13MvATip ,
                                              AV33MvAMov } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P00G27 */
         pr_default.execute(5, new Object[] {AV24Hdesde, AV25HHasta, AV33MvAMov, AV28LinCod, AV37Prodcod, AV9AlmCod, AV43SubLCod, AV17FamCod});
         c1248MvADCant = P00G27_A1248MvADCant[0];
         c1249MVADCosto = P00G27_A1249MVADCosto[0];
         pr_default.close(5);
         AV10Cantidad = (decimal)(AV10Cantidad+c1248MvADCant);
         AV47Total = (decimal)(AV47Total+c1249MVADCosto);
         /* End optimized group. */
      }

      protected void HG20( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 664, Gx_line+45, 696, Gx_line+59, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 664, Gx_line+63, 708, Gx_line+77, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 664, Gx_line+27, 703, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 731, Gx_line+63, 770, Gx_line+78, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 710, Gx_line+45, 768, Gx_line+59, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 723, Gx_line+27, 770, Gx_line+42, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 15, Gx_line+176, 56, Gx_line+190, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Movimientos", 78, Gx_line+176, 201, Gx_line+190, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 439, Gx_line+176, 492, Gx_line+190, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+171, 797, Gx_line+197, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Costos por Tipo de Movimiento", 228, Gx_line+53, 601, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Costo Total", 550, Gx_line+176, 618, Gx_line+190, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 206, Gx_line+128, 260, Gx_line+142, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20Filtro3, "")), 268, Gx_line+123, 611, Gx_line+147, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde", 223, Gx_line+149, 260, Gx_line+163, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV24Hdesde, "99/99/99"), 268, Gx_line+144, 352, Gx_line+168, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 471, Gx_line+148, 506, Gx_line+162, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV25HHasta, "99/99/99"), 526, Gx_line+143, 610, Gx_line+167, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV29Logo)) ? AV60Logo_GXI : AV29Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 6, Gx_line+8, 159, Gx_line+81) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Empresa, "")), 6, Gx_line+83, 314, Gx_line+101, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15EmpRUC, "")), 6, Gx_line+101, 123, Gx_line+119, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Linea de Producto", 154, Gx_line+107, 260, Gx_line+121, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21Filtro4, "")), 268, Gx_line+102, 611, Gx_line+126, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+197);
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
         add_metrics2( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
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
         AV14Empresa = "";
         AV42Session = context.GetSession();
         AV13EmpDir = "";
         AV15EmpRUC = "";
         AV38Ruta = "";
         AV29Logo = "";
         AV60Logo_GXI = "";
         AV18Filtro1 = "";
         AV19Filtro2 = "";
         AV20Filtro3 = "";
         AV21Filtro4 = "";
         scmdbuf = "";
         P00G22_A234MovCod = new int[1] ;
         P00G22_A1239MovDsc = new string[] {""} ;
         A1239MovDsc = "";
         P00G23_A28ProdCod = new string[] {""} ;
         P00G23_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P00G24_A52LinCod = new int[1] ;
         P00G24_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         A1370MVSts = "";
         P00G25_A13MvATip = new string[] {""} ;
         P00G25_A14MvACod = new string[] {""} ;
         P00G25_A55ProdDsc = new string[] {""} ;
         P00G25_A28ProdCod = new string[] {""} ;
         P00G25_A1269MvAlmCos = new short[1] ;
         P00G25_A1158LinStk = new short[1] ;
         P00G25_A1370MVSts = new string[] {""} ;
         P00G25_A50FamCod = new int[1] ;
         P00G25_n50FamCod = new bool[] {false} ;
         P00G25_A51SublCod = new int[1] ;
         P00G25_n51SublCod = new bool[] {false} ;
         P00G25_A21MvAlm = new int[1] ;
         P00G25_A52LinCod = new int[1] ;
         P00G25_A22MvAMov = new int[1] ;
         P00G25_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         AV46Tipo = "";
         P00G26_A1241MovTip = new short[1] ;
         P00G26_A1239MovDsc = new string[] {""} ;
         P00G26_A234MovCod = new int[1] ;
         AV34MvAMovDsc = "";
         P00G27_A1248MvADCant = new decimal[1] ;
         P00G27_A1249MVADCosto = new decimal[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV29Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.rrresumentipomovimientos__default(),
            new Object[][] {
                new Object[] {
               P00G22_A234MovCod, P00G22_A1239MovDsc
               }
               , new Object[] {
               P00G23_A28ProdCod, P00G23_A55ProdDsc
               }
               , new Object[] {
               P00G24_A52LinCod, P00G24_A1153LinDsc
               }
               , new Object[] {
               P00G25_A13MvATip, P00G25_A14MvACod, P00G25_A55ProdDsc, P00G25_A28ProdCod, P00G25_A1269MvAlmCos, P00G25_A1158LinStk, P00G25_A1370MVSts, P00G25_A50FamCod, P00G25_n50FamCod, P00G25_A51SublCod,
               P00G25_n51SublCod, P00G25_A21MvAlm, P00G25_A52LinCod, P00G25_A22MvAMov, P00G25_A30MvADItem
               }
               , new Object[] {
               P00G26_A1241MovTip, P00G26_A1239MovDsc, P00G26_A234MovCod
               }
               , new Object[] {
               P00G27_A1248MvADCant, P00G27_A1249MVADCosto
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
      private short A1158LinStk ;
      private short A1269MvAlmCos ;
      private short AV26I ;
      private short AV32MovTip ;
      private short A1241MovTip ;
      private int AV31MovCod ;
      private int AV28LinCod ;
      private int AV43SubLCod ;
      private int AV17FamCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A234MovCod ;
      private int A52LinCod ;
      private int AV9AlmCod ;
      private int A22MvAMov ;
      private int A21MvAlm ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A30MvADItem ;
      private int Gx_OldLine ;
      private int AV27Item ;
      private int AV33MvAMov ;
      private decimal AV49TotalCantidad ;
      private decimal AV50TotalCosto ;
      private decimal AV40SaldoCant ;
      private decimal AV41SaldoImp ;
      private decimal AV39Saldo ;
      private decimal AV12CostoU ;
      private decimal AV51TotalP ;
      private decimal AV48TotalC ;
      private decimal AV10Cantidad ;
      private decimal AV47Total ;
      private decimal c1248MvADCant ;
      private decimal c1249MVADCosto ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV37Prodcod ;
      private string AV14Empresa ;
      private string AV13EmpDir ;
      private string AV15EmpRUC ;
      private string AV38Ruta ;
      private string AV18Filtro1 ;
      private string AV19Filtro2 ;
      private string AV20Filtro3 ;
      private string AV21Filtro4 ;
      private string scmdbuf ;
      private string A1239MovDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A1153LinDsc ;
      private string A1370MVSts ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string AV46Tipo ;
      private string AV34MvAMovDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV24Hdesde ;
      private DateTime AV25HHasta ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKG26 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private string AV60Logo_GXI ;
      private string AV29Logo ;
      private string Logo ;
      private IGxSession AV42Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_MovCod ;
      private int aP1_LinCod ;
      private string aP2_Prodcod ;
      private DateTime aP3_Hdesde ;
      private DateTime aP4_HHasta ;
      private int aP5_SubLCod ;
      private int aP6_FamCod ;
      private IDataStoreProvider pr_default ;
      private int[] P00G22_A234MovCod ;
      private string[] P00G22_A1239MovDsc ;
      private string[] P00G23_A28ProdCod ;
      private string[] P00G23_A55ProdDsc ;
      private int[] P00G24_A52LinCod ;
      private string[] P00G24_A1153LinDsc ;
      private string[] P00G25_A13MvATip ;
      private string[] P00G25_A14MvACod ;
      private string[] P00G25_A55ProdDsc ;
      private string[] P00G25_A28ProdCod ;
      private short[] P00G25_A1269MvAlmCos ;
      private short[] P00G25_A1158LinStk ;
      private string[] P00G25_A1370MVSts ;
      private int[] P00G25_A50FamCod ;
      private bool[] P00G25_n50FamCod ;
      private int[] P00G25_A51SublCod ;
      private bool[] P00G25_n51SublCod ;
      private int[] P00G25_A21MvAlm ;
      private int[] P00G25_A52LinCod ;
      private int[] P00G25_A22MvAMov ;
      private int[] P00G25_A30MvADItem ;
      private short[] P00G26_A1241MovTip ;
      private string[] P00G26_A1239MovDsc ;
      private int[] P00G26_A234MovCod ;
      private decimal[] P00G27_A1248MvADCant ;
      private decimal[] P00G27_A1249MVADCosto ;
   }

   public class rrresumentipomovimientos__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00G25( IGxContext context ,
                                             int AV31MovCod ,
                                             int AV28LinCod ,
                                             string AV37Prodcod ,
                                             int AV9AlmCod ,
                                             int AV43SubLCod ,
                                             int AV17FamCod ,
                                             int A22MvAMov ,
                                             int A52LinCod ,
                                             string A28ProdCod ,
                                             int A21MvAlm ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A1370MVSts ,
                                             short A1158LinStk ,
                                             short A1269MvAlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T4.[ProdDsc], T1.[ProdCod], T3.[AlmCos] AS MvAlmCos, T5.[LinStk], T2.[MVSts], T4.[FamCod], T4.[SublCod], T2.[MvAlm] AS MvAlm, T4.[LinCod], T2.[MvAMov], T1.[MvADItem] FROM (((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T4.[LinCod])";
         AddWhere(sWhereString, "(T2.[MVSts] <> 'A')");
         AddWhere(sWhereString, "(T5.[LinStk] = 1)");
         AddWhere(sWhereString, "(T3.[AlmCos] = 1)");
         if ( ! (0==AV31MovCod) )
         {
            AddWhere(sWhereString, "(T2.[MvAMov] = @AV31MovCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV28LinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV28LinCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV37Prodcod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9AlmCod) )
         {
            AddWhere(sWhereString, "(T2.[MvAlm] = @AV9AlmCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV43SubLCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV43SubLCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV17FamCod) )
         {
            AddWhere(sWhereString, "(T4.[FamCod] = @AV17FamCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T4.[ProdDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00G27( IGxContext context ,
                                             int AV28LinCod ,
                                             string AV37Prodcod ,
                                             int AV9AlmCod ,
                                             int AV43SubLCod ,
                                             int AV17FamCod ,
                                             short AV32MovTip ,
                                             int A52LinCod ,
                                             string A28ProdCod ,
                                             int A21MvAlm ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A13MvATip ,
                                             int AV33MvAMov )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[8];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SUM(T1.[MvADCant]), SUM(T1.[MVADCosto]) FROM (((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T4.[LinCod])";
         AddWhere(sWhereString, "(T2.[MvAFec] >= @AV24Hdesde and T2.[MvAFec] <= @AV25HHasta)");
         AddWhere(sWhereString, "(T2.[MVSts] <> 'A')");
         AddWhere(sWhereString, "(T2.[MvAMov] = @AV33MvAMov)");
         AddWhere(sWhereString, "(T5.[LinStk] = 1)");
         AddWhere(sWhereString, "(T3.[AlmCos] = 1)");
         if ( ! (0==AV28LinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV28LinCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV37Prodcod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV9AlmCod) )
         {
            AddWhere(sWhereString, "(T2.[MvAlm] = @AV9AlmCod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV43SubLCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV43SubLCod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV17FamCod) )
         {
            AddWhere(sWhereString, "(T4.[FamCod] = @AV17FamCod)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV32MovTip == 1 )
         {
            AddWhere(sWhereString, "(T1.[MvATip] = 'ING')");
         }
         if ( AV32MovTip == 2 )
         {
            AddWhere(sWhereString, "(T1.[MvATip] <> 'ING')");
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_P00G25(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] );
               case 5 :
                     return conditional_P00G27(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (short)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] );
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
          Object[] prmP00G22;
          prmP00G22 = new Object[] {
          new ParDef("@AV31MovCod",GXType.Int32,6,0)
          };
          Object[] prmP00G23;
          prmP00G23 = new Object[] {
          new ParDef("@AV37Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00G24;
          prmP00G24 = new Object[] {
          new ParDef("@AV28LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00G26;
          prmP00G26 = new Object[] {
          new ParDef("@AV32MovTip",GXType.Int16,1,0)
          };
          Object[] prmP00G25;
          prmP00G25 = new Object[] {
          new ParDef("@AV31MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV28LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV37Prodcod",GXType.NChar,15,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV43SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV17FamCod",GXType.Int32,6,0)
          };
          Object[] prmP00G27;
          prmP00G27 = new Object[] {
          new ParDef("@AV24Hdesde",GXType.Date,8,0) ,
          new ParDef("@AV25HHasta",GXType.Date,8,0) ,
          new ParDef("@AV33MvAMov",GXType.Int32,6,0) ,
          new ParDef("@AV28LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV37Prodcod",GXType.NChar,15,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV43SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV17FamCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00G22", "SELECT [MovCod], [MovDsc] FROM [CMOVALMACEN] WHERE [MovCod] = @AV31MovCod ORDER BY [MovCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G22,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G23", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV37Prodcod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G23,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G24", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV28LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G24,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G25", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G25,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G26", "SELECT [MovTip], [MovDsc], [MovCod] FROM [CMOVALMACEN] WHERE [MovTip] = @AV32MovTip ORDER BY [MovCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G26,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G27", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G27,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 1);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 5 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
       }
    }

 }

}
