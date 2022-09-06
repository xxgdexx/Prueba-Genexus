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
   public class r_resumensaldosvalorizadospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "produccion.r_resumensaldosvalorizadospdf.aspx")), "produccion.r_resumensaldosvalorizadospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "produccion.r_resumensaldosvalorizadospdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "LinCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV45SublCod = (int)(NumberUtil.Val( GetPar( "SublCod"), "."));
                  AV46FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AV9AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
                  AV10Prodcod = GetPar( "Prodcod");
                  AV91Ano = (short)(NumberUtil.Val( GetPar( "Ano"), "."));
                  AV92Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
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

      public r_resumensaldosvalorizadospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumensaldosvalorizadospdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SublCod ,
                           ref int aP2_FamCod ,
                           ref int aP3_AlmCod ,
                           ref string aP4_Prodcod ,
                           ref short aP5_Ano ,
                           ref short aP6_Mes )
      {
         this.AV8LinCod = aP0_LinCod;
         this.AV45SublCod = aP1_SublCod;
         this.AV46FamCod = aP2_FamCod;
         this.AV9AlmCod = aP3_AlmCod;
         this.AV10Prodcod = aP4_Prodcod;
         this.AV91Ano = aP5_Ano;
         this.AV92Mes = aP6_Mes;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV8LinCod;
         aP1_SublCod=this.AV45SublCod;
         aP2_FamCod=this.AV46FamCod;
         aP3_AlmCod=this.AV9AlmCod;
         aP4_Prodcod=this.AV10Prodcod;
         aP5_Ano=this.AV91Ano;
         aP6_Mes=this.AV92Mes;
      }

      public short executeUdp( ref int aP0_LinCod ,
                               ref int aP1_SublCod ,
                               ref int aP2_FamCod ,
                               ref int aP3_AlmCod ,
                               ref string aP4_Prodcod ,
                               ref short aP5_Ano )
      {
         execute(ref aP0_LinCod, ref aP1_SublCod, ref aP2_FamCod, ref aP3_AlmCod, ref aP4_Prodcod, ref aP5_Ano, ref aP6_Mes);
         return AV92Mes ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SublCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_AlmCod ,
                                 ref string aP4_Prodcod ,
                                 ref short aP5_Ano ,
                                 ref short aP6_Mes )
      {
         r_resumensaldosvalorizadospdf objr_resumensaldosvalorizadospdf;
         objr_resumensaldosvalorizadospdf = new r_resumensaldosvalorizadospdf();
         objr_resumensaldosvalorizadospdf.AV8LinCod = aP0_LinCod;
         objr_resumensaldosvalorizadospdf.AV45SublCod = aP1_SublCod;
         objr_resumensaldosvalorizadospdf.AV46FamCod = aP2_FamCod;
         objr_resumensaldosvalorizadospdf.AV9AlmCod = aP3_AlmCod;
         objr_resumensaldosvalorizadospdf.AV10Prodcod = aP4_Prodcod;
         objr_resumensaldosvalorizadospdf.AV91Ano = aP5_Ano;
         objr_resumensaldosvalorizadospdf.AV92Mes = aP6_Mes;
         objr_resumensaldosvalorizadospdf.context.SetSubmitInitialConfig(context);
         objr_resumensaldosvalorizadospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumensaldosvalorizadospdf);
         aP0_LinCod=this.AV8LinCod;
         aP1_SublCod=this.AV45SublCod;
         aP2_FamCod=this.AV46FamCod;
         aP3_AlmCod=this.AV9AlmCod;
         aP4_Prodcod=this.AV10Prodcod;
         aP5_Ano=this.AV91Ano;
         aP6_Mes=this.AV92Mes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumensaldosvalorizadospdf)stateInfo).executePrivate();
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
            AV39Empresa = AV44Session.Get("Empresa");
            AV40EmpDir = AV44Session.Get("EmpDir");
            AV41EmpRUC = AV44Session.Get("EmpRUC");
            AV42Ruta = AV44Session.Get("RUTA") + "/Logo.jpg";
            AV43Logo = AV42Ruta;
            AV110Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV66UsuCod = AV44Session.Get("UsuCod");
            AV12Titulo = "Resumen de Saldos Valorizados";
            /* Using cursor P00FY2 */
            pr_default.execute(0, new Object[] {AV9AlmCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A63AlmCod = P00FY2_A63AlmCod[0];
               A436AlmDsc = P00FY2_A436AlmDsc[0];
               AV11Almacen = A436AlmDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            GXt_char1 = AV21cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV92Mes, out  GXt_char1) ;
            AV21cMes = GXt_char1;
            AV22Filtro1 = "(Todos)";
            AV24Filtro2 = "Periodo : " + StringUtil.Trim( AV21cMes) + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV91Ano), 10, 0));
            AV106FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV92Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV91Ano), 10, 0));
            AV107fechaD = context.localUtil.CToD( AV106FechaC, 2);
            GXt_date2 = AV25Fecha;
            new GeneXus.Programs.generales.pobtieneultimodiames(context ).execute(  AV107fechaD, out  GXt_date2) ;
            AV25Fecha = GXt_date2;
            /* Using cursor P00FY3 */
            pr_default.execute(1, new Object[] {AV8LinCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A52LinCod = P00FY3_A52LinCod[0];
               A1153LinDsc = P00FY3_A1153LinDsc[0];
               AV22Filtro1 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV101TotalGeneral = 0.00m;
            AV102SaldoGeneral = 0.0000m;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV8LinCod ,
                                                 AV45SublCod ,
                                                 AV46FamCod ,
                                                 AV9AlmCod ,
                                                 AV10Prodcod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A21MvAlm ,
                                                 A28ProdCod ,
                                                 A1158LinStk ,
                                                 A1269MvAlmCos } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00FY4 */
            pr_default.execute(2, new Object[] {AV8LinCod, AV45SublCod, AV46FamCod, AV9AlmCod, AV10Prodcod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               BRKFY5 = false;
               A13MvATip = P00FY4_A13MvATip[0];
               A14MvACod = P00FY4_A14MvACod[0];
               A1158LinStk = P00FY4_A1158LinStk[0];
               A1269MvAlmCos = P00FY4_A1269MvAlmCos[0];
               A1153LinDsc = P00FY4_A1153LinDsc[0];
               A52LinCod = P00FY4_A52LinCod[0];
               A28ProdCod = P00FY4_A28ProdCod[0];
               A21MvAlm = P00FY4_A21MvAlm[0];
               A50FamCod = P00FY4_A50FamCod[0];
               n50FamCod = P00FY4_n50FamCod[0];
               A51SublCod = P00FY4_A51SublCod[0];
               n51SublCod = P00FY4_n51SublCod[0];
               A30MvADItem = P00FY4_A30MvADItem[0];
               A21MvAlm = P00FY4_A21MvAlm[0];
               A1269MvAlmCos = P00FY4_A1269MvAlmCos[0];
               A52LinCod = P00FY4_A52LinCod[0];
               A50FamCod = P00FY4_A50FamCod[0];
               n50FamCod = P00FY4_n50FamCod[0];
               A51SublCod = P00FY4_A51SublCod[0];
               n51SublCod = P00FY4_n51SublCod[0];
               A1158LinStk = P00FY4_A1158LinStk[0];
               A1153LinDsc = P00FY4_A1153LinDsc[0];
               while ( (pr_default.getStatus(2) != 101) && ( P00FY4_A52LinCod[0] == A52LinCod ) )
               {
                  BRKFY5 = false;
                  A13MvATip = P00FY4_A13MvATip[0];
                  A14MvACod = P00FY4_A14MvACod[0];
                  A1153LinDsc = P00FY4_A1153LinDsc[0];
                  A28ProdCod = P00FY4_A28ProdCod[0];
                  A30MvADItem = P00FY4_A30MvADItem[0];
                  A1153LinDsc = P00FY4_A1153LinDsc[0];
                  BRKFY5 = true;
                  pr_default.readNext(2);
               }
               AV97Linea = A52LinCod;
               AV98LineaDsc = StringUtil.Trim( A1153LinDsc);
               AV103LineaTot = "Total Linea " + StringUtil.Trim( A1153LinDsc);
               AV100CantLinea = 0.0000m;
               AV99TotLinea = 0.00m;
               HFY0( false, 20) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV98LineaDsc, "")), 3, Gx_line+3, 629, Gx_line+18, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
               /* Execute user subroutine: 'DETALLES' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               AV102SaldoGeneral = (decimal)(AV102SaldoGeneral+AV100CantLinea);
               AV101TotalGeneral = (decimal)(AV101TotalGeneral+AV99TotLinea);
               if ( ! (Convert.ToDecimal(0)==AV102SaldoGeneral) )
               {
                  HFY0( false, 27) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV103LineaTot, "")), 32, Gx_line+7, 587, Gx_line+24, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV100CantLinea, "ZZZZ,ZZZ,ZZ9.9999")), 558, Gx_line+8, 683, Gx_line+23, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV99TotLinea, "ZZZZZZ,ZZZ,ZZ9.99")), 684, Gx_line+8, 809, Gx_line+23, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(589, Gx_line+5, 806, Gx_line+5, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+27);
               }
               if ( ! BRKFY5 )
               {
                  BRKFY5 = true;
                  pr_default.readNext(2);
               }
            }
            pr_default.close(2);
            HFY0( false, 53) ;
            getPrinter().GxDrawLine(589, Gx_line+16, 806, Gx_line+16, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 472, Gx_line+22, 552, Gx_line+36, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV102SaldoGeneral, "ZZZZ,ZZZ,ZZ9.9999")), 558, Gx_line+22, 683, Gx_line+37, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV101TotalGeneral, "ZZZZZZ,ZZZ,ZZ9.99")), 684, Gx_line+22, 809, Gx_line+37, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+53);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HFY0( true, 0) ;
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
         /* 'DETALLES' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV45SublCod ,
                                              AV46FamCod ,
                                              AV9AlmCod ,
                                              AV10Prodcod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A21MvAlm ,
                                              A28ProdCod ,
                                              A52LinCod ,
                                              AV97Linea ,
                                              A1158LinStk ,
                                              A1269MvAlmCos } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00FY5 */
         pr_default.execute(3, new Object[] {AV97Linea, AV45SublCod, AV46FamCod, AV9AlmCod, AV10Prodcod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKFY7 = false;
            A13MvATip = P00FY5_A13MvATip[0];
            A14MvACod = P00FY5_A14MvACod[0];
            A49UniCod = P00FY5_A49UniCod[0];
            A55ProdDsc = P00FY5_A55ProdDsc[0];
            A28ProdCod = P00FY5_A28ProdCod[0];
            A1269MvAlmCos = P00FY5_A1269MvAlmCos[0];
            A1158LinStk = P00FY5_A1158LinStk[0];
            A21MvAlm = P00FY5_A21MvAlm[0];
            A50FamCod = P00FY5_A50FamCod[0];
            n50FamCod = P00FY5_n50FamCod[0];
            A51SublCod = P00FY5_A51SublCod[0];
            n51SublCod = P00FY5_n51SublCod[0];
            A52LinCod = P00FY5_A52LinCod[0];
            A1997UniAbr = P00FY5_A1997UniAbr[0];
            A30MvADItem = P00FY5_A30MvADItem[0];
            A21MvAlm = P00FY5_A21MvAlm[0];
            A1269MvAlmCos = P00FY5_A1269MvAlmCos[0];
            A49UniCod = P00FY5_A49UniCod[0];
            A55ProdDsc = P00FY5_A55ProdDsc[0];
            A50FamCod = P00FY5_A50FamCod[0];
            n50FamCod = P00FY5_n50FamCod[0];
            A51SublCod = P00FY5_A51SublCod[0];
            n51SublCod = P00FY5_n51SublCod[0];
            A52LinCod = P00FY5_A52LinCod[0];
            A1997UniAbr = P00FY5_A1997UniAbr[0];
            A1158LinStk = P00FY5_A1158LinStk[0];
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00FY5_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRKFY7 = false;
               A13MvATip = P00FY5_A13MvATip[0];
               A14MvACod = P00FY5_A14MvACod[0];
               A55ProdDsc = P00FY5_A55ProdDsc[0];
               A30MvADItem = P00FY5_A30MvADItem[0];
               A55ProdDsc = P00FY5_A55ProdDsc[0];
               BRKFY7 = true;
               pr_default.readNext(3);
            }
            AV36ProdCodC = A28ProdCod;
            AV15Producto = A55ProdDsc;
            AV65UniAbr = A1997UniAbr;
            AV90SaldoFinal = 0.0000m;
            AV94SaldoTotal = 0.00m;
            AV95CostoUnit = 0.0000m;
            AV96TituloTot = "Total " + StringUtil.Trim( AV15Producto);
            /* Execute user subroutine: 'MUESTRAPRODUCTOS' */
            S127 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV100CantLinea = (decimal)(AV100CantLinea+AV90SaldoFinal);
            AV99TotLinea = (decimal)(AV99TotLinea+AV94SaldoTotal);
            if ( ! (Convert.ToDecimal(0)==AV100CantLinea) )
            {
               HFY0( false, 28) ;
               getPrinter().GxDrawLine(589, Gx_line+4, 806, Gx_line+4, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV94SaldoTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 720, Gx_line+8, 810, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV90SaldoFinal, "ZZZZ,ZZZ,ZZ9.9999")), 594, Gx_line+8, 684, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV95CostoUnit, "ZZZZ,ZZZ,ZZ9.9999")), 655, Gx_line+8, 745, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV96TituloTot, "")), 171, Gx_line+8, 589, Gx_line+21, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+28);
            }
            if ( ! BRKFY7 )
            {
               BRKFY7 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S127( )
      {
         /* 'MUESTRAPRODUCTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV9AlmCod ,
                                              A63AlmCod ,
                                              A434AlmCos ,
                                              A438AlmSts ,
                                              AV36ProdCodC ,
                                              A28ProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00FY6 */
         pr_default.execute(4, new Object[] {AV36ProdCodC, AV9AlmCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A49UniCod = P00FY6_A49UniCod[0];
            A28ProdCod = P00FY6_A28ProdCod[0];
            A63AlmCod = P00FY6_A63AlmCod[0];
            A438AlmSts = P00FY6_A438AlmSts[0];
            A434AlmCos = P00FY6_A434AlmCos[0];
            A436AlmDsc = P00FY6_A436AlmDsc[0];
            A1997UniAbr = P00FY6_A1997UniAbr[0];
            A49UniCod = P00FY6_A49UniCod[0];
            A1997UniAbr = P00FY6_A1997UniAbr[0];
            A438AlmSts = P00FY6_A438AlmSts[0];
            A434AlmCos = P00FY6_A434AlmCos[0];
            A436AlmDsc = P00FY6_A436AlmDsc[0];
            AV9AlmCod = A63AlmCod;
            AV105AlmacenDsc = A436AlmDsc;
            new GeneXus.Programs.produccion.pobtenersaldoproductoalmacencosto(context ).execute( ref  AV36ProdCodC, ref  AV9AlmCod, ref  AV25Fecha, out  AV16Saldo, out  AV95CostoUnit) ;
            if ( ! (Convert.ToDecimal(0)==AV16Saldo) )
            {
               AV93CostUnit = AV95CostoUnit;
               AV28CostoT = NumberUtil.Round( AV16Saldo*AV95CostoUnit, 2);
               AV65UniAbr = StringUtil.Trim( A1997UniAbr);
               HFY0( false, 18) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16Saldo, "ZZZZ,ZZZ,ZZ9.9999")), 594, Gx_line+2, 684, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV93CostUnit, "ZZZZ,ZZZ,ZZ9.9999")), 655, Gx_line+2, 745, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28CostoT, "ZZZZZZ,ZZZ,ZZ9.99")), 720, Gx_line+2, 810, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Producto, "")), 75, Gx_line+2, 346, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65UniAbr, "")), 349, Gx_line+2, 392, Gx_line+15, 1+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36ProdCodC, "@!")), 3, Gx_line+2, 67, Gx_line+15, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV105AlmacenDsc, "")), 400, Gx_line+2, 606, Gx_line+13, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               AV90SaldoFinal = (decimal)(AV90SaldoFinal+AV16Saldo);
               AV94SaldoTotal = (decimal)(AV94SaldoTotal+AV28CostoT);
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void HFY0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 717, Gx_line+19, 749, Gx_line+33, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 705, Gx_line+36, 749, Gx_line+50, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 756, Gx_line+36, 795, Gx_line+51, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 756, Gx_line+19, 797, Gx_line+33, 2, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+122, 814, Gx_line+167, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción del Producto", 122, Gx_line+139, 251, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Codigo", 17, Gx_line+139, 53, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Linea :", 249, Gx_line+74, 292, Gx_line+89, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 319, Gx_line+69, 628, Gx_line+93, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro2, "")), 264, Gx_line+39, 577, Gx_line+63, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12Titulo, "")), 166, Gx_line+14, 673, Gx_line+39, 1, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV43Logo)) ? AV110Logo_GXI : AV43Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+3, 175, Gx_line+80) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Empresa, "")), 9, Gx_line+82, 257, Gx_line+100, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41EmpRUC, "")), 9, Gx_line+100, 179, Gx_line+118, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(610, Gx_line+122, 610, Gx_line+167, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cantidad", 628, Gx_line+149, 675, Gx_line+162, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 760, Gx_line+149, 804, Gx_line+162, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 696, Gx_line+149, 740, Gx_line+162, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(611, Gx_line+144, 812, Gx_line+144, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 696, Gx_line+126, 725, Gx_line+139, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(394, Gx_line+122, 394, Gx_line+167, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuario :", 697, Gx_line+54, 749, Gx_line+68, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66UsuCod, "")), 756, Gx_line+54, 809, Gx_line+69, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Medida", 352, Gx_line+139, 391, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Almacen", 480, Gx_line+136, 526, Gx_line+149, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(348, Gx_line+122, 348, Gx_line+167, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(73, Gx_line+122, 73, Gx_line+167, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+167);
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
         AV39Empresa = "";
         AV44Session = context.GetSession();
         AV40EmpDir = "";
         AV41EmpRUC = "";
         AV42Ruta = "";
         AV43Logo = "";
         AV110Logo_GXI = "";
         AV66UsuCod = "";
         AV12Titulo = "";
         scmdbuf = "";
         P00FY2_A63AlmCod = new int[1] ;
         P00FY2_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         AV11Almacen = "";
         AV21cMes = "";
         GXt_char1 = "";
         AV22Filtro1 = "";
         AV24Filtro2 = "";
         AV106FechaC = "";
         AV107fechaD = DateTime.MinValue;
         AV25Fecha = DateTime.MinValue;
         GXt_date2 = DateTime.MinValue;
         P00FY3_A52LinCod = new int[1] ;
         P00FY3_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         A28ProdCod = "";
         P00FY4_A13MvATip = new string[] {""} ;
         P00FY4_A14MvACod = new string[] {""} ;
         P00FY4_A1158LinStk = new short[1] ;
         P00FY4_A1269MvAlmCos = new short[1] ;
         P00FY4_A1153LinDsc = new string[] {""} ;
         P00FY4_A52LinCod = new int[1] ;
         P00FY4_A28ProdCod = new string[] {""} ;
         P00FY4_A21MvAlm = new int[1] ;
         P00FY4_A50FamCod = new int[1] ;
         P00FY4_n50FamCod = new bool[] {false} ;
         P00FY4_A51SublCod = new int[1] ;
         P00FY4_n51SublCod = new bool[] {false} ;
         P00FY4_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         AV98LineaDsc = "";
         AV103LineaTot = "";
         P00FY5_A13MvATip = new string[] {""} ;
         P00FY5_A14MvACod = new string[] {""} ;
         P00FY5_A49UniCod = new int[1] ;
         P00FY5_A55ProdDsc = new string[] {""} ;
         P00FY5_A28ProdCod = new string[] {""} ;
         P00FY5_A1269MvAlmCos = new short[1] ;
         P00FY5_A1158LinStk = new short[1] ;
         P00FY5_A21MvAlm = new int[1] ;
         P00FY5_A50FamCod = new int[1] ;
         P00FY5_n50FamCod = new bool[] {false} ;
         P00FY5_A51SublCod = new int[1] ;
         P00FY5_n51SublCod = new bool[] {false} ;
         P00FY5_A52LinCod = new int[1] ;
         P00FY5_A1997UniAbr = new string[] {""} ;
         P00FY5_A30MvADItem = new int[1] ;
         A55ProdDsc = "";
         A1997UniAbr = "";
         AV36ProdCodC = "";
         AV15Producto = "";
         AV65UniAbr = "";
         AV96TituloTot = "";
         P00FY6_A49UniCod = new int[1] ;
         P00FY6_A28ProdCod = new string[] {""} ;
         P00FY6_A63AlmCod = new int[1] ;
         P00FY6_A438AlmSts = new short[1] ;
         P00FY6_A434AlmCos = new short[1] ;
         P00FY6_A436AlmDsc = new string[] {""} ;
         P00FY6_A1997UniAbr = new string[] {""} ;
         AV105AlmacenDsc = "";
         Gx_time = "";
         AV43Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_resumensaldosvalorizadospdf__default(),
            new Object[][] {
                new Object[] {
               P00FY2_A63AlmCod, P00FY2_A436AlmDsc
               }
               , new Object[] {
               P00FY3_A52LinCod, P00FY3_A1153LinDsc
               }
               , new Object[] {
               P00FY4_A13MvATip, P00FY4_A14MvACod, P00FY4_A1158LinStk, P00FY4_A1269MvAlmCos, P00FY4_A1153LinDsc, P00FY4_A52LinCod, P00FY4_A28ProdCod, P00FY4_A21MvAlm, P00FY4_A50FamCod, P00FY4_n50FamCod,
               P00FY4_A51SublCod, P00FY4_n51SublCod, P00FY4_A30MvADItem
               }
               , new Object[] {
               P00FY5_A13MvATip, P00FY5_A14MvACod, P00FY5_A49UniCod, P00FY5_A55ProdDsc, P00FY5_A28ProdCod, P00FY5_A1269MvAlmCos, P00FY5_A1158LinStk, P00FY5_A21MvAlm, P00FY5_A50FamCod, P00FY5_n50FamCod,
               P00FY5_A51SublCod, P00FY5_n51SublCod, P00FY5_A52LinCod, P00FY5_A1997UniAbr, P00FY5_A30MvADItem
               }
               , new Object[] {
               P00FY6_A49UniCod, P00FY6_A28ProdCod, P00FY6_A63AlmCod, P00FY6_A438AlmSts, P00FY6_A434AlmCos, P00FY6_A436AlmDsc, P00FY6_A1997UniAbr
               }
            }
         );
         Gx_time = context.localUtil.Time( );
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_time = context.localUtil.Time( );
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV91Ano ;
      private short AV92Mes ;
      private short A1158LinStk ;
      private short A1269MvAlmCos ;
      private short A434AlmCos ;
      private short A438AlmSts ;
      private int AV8LinCod ;
      private int AV45SublCod ;
      private int AV46FamCod ;
      private int AV9AlmCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A63AlmCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private int AV97Linea ;
      private int Gx_OldLine ;
      private int A49UniCod ;
      private decimal AV101TotalGeneral ;
      private decimal AV102SaldoGeneral ;
      private decimal AV100CantLinea ;
      private decimal AV99TotLinea ;
      private decimal AV90SaldoFinal ;
      private decimal AV94SaldoTotal ;
      private decimal AV95CostoUnit ;
      private decimal AV16Saldo ;
      private decimal AV93CostUnit ;
      private decimal AV28CostoT ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV10Prodcod ;
      private string AV39Empresa ;
      private string AV40EmpDir ;
      private string AV41EmpRUC ;
      private string AV42Ruta ;
      private string AV66UsuCod ;
      private string AV12Titulo ;
      private string scmdbuf ;
      private string A436AlmDsc ;
      private string AV11Almacen ;
      private string AV21cMes ;
      private string GXt_char1 ;
      private string AV22Filtro1 ;
      private string AV24Filtro2 ;
      private string AV106FechaC ;
      private string A1153LinDsc ;
      private string A28ProdCod ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string AV98LineaDsc ;
      private string AV103LineaTot ;
      private string A55ProdDsc ;
      private string A1997UniAbr ;
      private string AV36ProdCodC ;
      private string AV15Producto ;
      private string AV65UniAbr ;
      private string AV96TituloTot ;
      private string AV105AlmacenDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV107fechaD ;
      private DateTime AV25Fecha ;
      private DateTime GXt_date2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKFY5 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private bool BRKFY7 ;
      private string AV110Logo_GXI ;
      private string AV43Logo ;
      private string Logo ;
      private IGxSession AV44Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SublCod ;
      private int aP2_FamCod ;
      private int aP3_AlmCod ;
      private string aP4_Prodcod ;
      private short aP5_Ano ;
      private short aP6_Mes ;
      private IDataStoreProvider pr_default ;
      private int[] P00FY2_A63AlmCod ;
      private string[] P00FY2_A436AlmDsc ;
      private int[] P00FY3_A52LinCod ;
      private string[] P00FY3_A1153LinDsc ;
      private string[] P00FY4_A13MvATip ;
      private string[] P00FY4_A14MvACod ;
      private short[] P00FY4_A1158LinStk ;
      private short[] P00FY4_A1269MvAlmCos ;
      private string[] P00FY4_A1153LinDsc ;
      private int[] P00FY4_A52LinCod ;
      private string[] P00FY4_A28ProdCod ;
      private int[] P00FY4_A21MvAlm ;
      private int[] P00FY4_A50FamCod ;
      private bool[] P00FY4_n50FamCod ;
      private int[] P00FY4_A51SublCod ;
      private bool[] P00FY4_n51SublCod ;
      private int[] P00FY4_A30MvADItem ;
      private string[] P00FY5_A13MvATip ;
      private string[] P00FY5_A14MvACod ;
      private int[] P00FY5_A49UniCod ;
      private string[] P00FY5_A55ProdDsc ;
      private string[] P00FY5_A28ProdCod ;
      private short[] P00FY5_A1269MvAlmCos ;
      private short[] P00FY5_A1158LinStk ;
      private int[] P00FY5_A21MvAlm ;
      private int[] P00FY5_A50FamCod ;
      private bool[] P00FY5_n50FamCod ;
      private int[] P00FY5_A51SublCod ;
      private bool[] P00FY5_n51SublCod ;
      private int[] P00FY5_A52LinCod ;
      private string[] P00FY5_A1997UniAbr ;
      private int[] P00FY5_A30MvADItem ;
      private int[] P00FY6_A49UniCod ;
      private string[] P00FY6_A28ProdCod ;
      private int[] P00FY6_A63AlmCod ;
      private short[] P00FY6_A438AlmSts ;
      private short[] P00FY6_A434AlmCos ;
      private string[] P00FY6_A436AlmDsc ;
      private string[] P00FY6_A1997UniAbr ;
   }

   public class r_resumensaldosvalorizadospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FY4( IGxContext context ,
                                             int AV8LinCod ,
                                             int AV45SublCod ,
                                             int AV46FamCod ,
                                             int AV9AlmCod ,
                                             string AV10Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A21MvAlm ,
                                             string A28ProdCod ,
                                             short A1158LinStk ,
                                             short A1269MvAlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T5.[LinStk], T3.[AlmCos] AS MvAlmCos, T5.[LinDsc], T4.[LinCod], T1.[ProdCod], T2.[MvAlm] AS MvAlm, T4.[FamCod], T4.[SublCod], T1.[MvADItem] FROM (((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T4.[LinCod])";
         AddWhere(sWhereString, "(T5.[LinStk] = 1)");
         AddWhere(sWhereString, "(T3.[AlmCos] = 1)");
         if ( ! (0==AV8LinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV8LinCod)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV45SublCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV45SublCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV46FamCod) )
         {
            AddWhere(sWhereString, "(T4.[FamCod] = @AV46FamCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9AlmCod) )
         {
            AddWhere(sWhereString, "(T2.[MvAlm] = @AV9AlmCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV10Prodcod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T4.[LinCod], T5.[LinDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00FY5( IGxContext context ,
                                             int AV45SublCod ,
                                             int AV46FamCod ,
                                             int AV9AlmCod ,
                                             string AV10Prodcod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A21MvAlm ,
                                             string A28ProdCod ,
                                             int A52LinCod ,
                                             int AV97Linea ,
                                             short A1158LinStk ,
                                             short A1269MvAlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[5];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T4.[UniCod], T4.[ProdDsc], T1.[ProdCod], T3.[AlmCos] AS MvAlmCos, T6.[LinStk], T2.[MvAlm] AS MvAlm, T4.[FamCod], T4.[SublCod], T4.[LinCod], T5.[UniAbr], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T5 ON T5.[UniCod] = T4.[UniCod]) INNER JOIN [CLINEAPROD] T6 ON T6.[LinCod] = T4.[LinCod])";
         AddWhere(sWhereString, "(T4.[LinCod] = @AV97Linea)");
         AddWhere(sWhereString, "(T6.[LinStk] = 1)");
         AddWhere(sWhereString, "(T3.[AlmCos] = 1)");
         if ( ! (0==AV45SublCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV45SublCod)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (0==AV46FamCod) )
         {
            AddWhere(sWhereString, "(T4.[FamCod] = @AV46FamCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV9AlmCod) )
         {
            AddWhere(sWhereString, "(T2.[MvAlm] = @AV9AlmCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV10Prodcod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T4.[ProdDsc]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00FY6( IGxContext context ,
                                             int AV9AlmCod ,
                                             int A63AlmCod ,
                                             short A434AlmCos ,
                                             short A438AlmSts ,
                                             string AV36ProdCodC ,
                                             string A28ProdCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[2];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T1.[ProdCod], T1.[AlmCod], T4.[AlmSts], T4.[AlmCos], T4.[AlmDsc], T3.[UniAbr] FROM ((([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T1.[AlmCod])";
         AddWhere(sWhereString, "(T1.[ProdCod] = @AV36ProdCodC)");
         AddWhere(sWhereString, "(T4.[AlmCos] = 1)");
         AddWhere(sWhereString, "(T4.[AlmSts] = 1)");
         if ( ! (0==AV9AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[AlmCod] = @AV9AlmCod)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P00FY4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
               case 3 :
                     return conditional_P00FY5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
               case 4 :
                     return conditional_P00FY6(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00FY2;
          prmP00FY2 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP00FY3;
          prmP00FY3 = new Object[] {
          new ParDef("@AV8LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00FY4;
          prmP00FY4 = new Object[] {
          new ParDef("@AV8LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV45SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV46FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00FY5;
          prmP00FY5 = new Object[] {
          new ParDef("@AV97Linea",GXType.Int32,6,0) ,
          new ParDef("@AV45SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV46FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00FY6;
          prmP00FY6 = new Object[] {
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FY2", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV9AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FY2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FY3", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV8LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FY3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FY4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FY4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FY5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FY5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FY6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FY6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 5);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                return;
       }
    }

 }

}
