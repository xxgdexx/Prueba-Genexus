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
   public class r_arresumensaldosvalorizadospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "produccion.r_arresumensaldosvalorizadospdf.aspx")), "produccion.r_arresumensaldosvalorizadospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "produccion.r_arresumensaldosvalorizadospdf.aspx")))) ;
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

      public r_arresumensaldosvalorizadospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_arresumensaldosvalorizadospdf( IGxContext context )
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
         r_arresumensaldosvalorizadospdf objr_arresumensaldosvalorizadospdf;
         objr_arresumensaldosvalorizadospdf = new r_arresumensaldosvalorizadospdf();
         objr_arresumensaldosvalorizadospdf.AV8LinCod = aP0_LinCod;
         objr_arresumensaldosvalorizadospdf.AV45SublCod = aP1_SublCod;
         objr_arresumensaldosvalorizadospdf.AV46FamCod = aP2_FamCod;
         objr_arresumensaldosvalorizadospdf.AV9AlmCod = aP3_AlmCod;
         objr_arresumensaldosvalorizadospdf.AV10Prodcod = aP4_Prodcod;
         objr_arresumensaldosvalorizadospdf.AV91Ano = aP5_Ano;
         objr_arresumensaldosvalorizadospdf.AV92Mes = aP6_Mes;
         objr_arresumensaldosvalorizadospdf.context.SetSubmitInitialConfig(context);
         objr_arresumensaldosvalorizadospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_arresumensaldosvalorizadospdf);
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
            ((r_arresumensaldosvalorizadospdf)stateInfo).executePrivate();
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
            AV108Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV66UsuCod = AV44Session.Get("UsuCod");
            AV12Titulo = "Resumen de Saldos Valorizados";
            /* Using cursor P00FX2 */
            pr_default.execute(0, new Object[] {AV9AlmCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A63AlmCod = P00FX2_A63AlmCod[0];
               A436AlmDsc = P00FX2_A436AlmDsc[0];
               n436AlmDsc = P00FX2_n436AlmDsc[0];
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
            /* Using cursor P00FX3 */
            pr_default.execute(1, new Object[] {AV8LinCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A52LinCod = P00FX3_A52LinCod[0];
               n52LinCod = P00FX3_n52LinCod[0];
               A1153LinDsc = P00FX3_A1153LinDsc[0];
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
                                                 A61SalCosAlmCod ,
                                                 A62SalCosProdCod ,
                                                 A1830SalCosCant ,
                                                 A59SalCosAno ,
                                                 AV91Ano ,
                                                 A60SalCosMes ,
                                                 AV92Mes ,
                                                 A1158LinStk ,
                                                 A434AlmCos } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor P00FX4 */
            pr_default.execute(2, new Object[] {AV91Ano, AV92Mes, AV8LinCod, AV45SublCod, AV46FamCod, AV9AlmCod, AV10Prodcod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               BRKFX5 = false;
               A59SalCosAno = P00FX4_A59SalCosAno[0];
               A60SalCosMes = P00FX4_A60SalCosMes[0];
               A1158LinStk = P00FX4_A1158LinStk[0];
               A434AlmCos = P00FX4_A434AlmCos[0];
               n434AlmCos = P00FX4_n434AlmCos[0];
               A1153LinDsc = P00FX4_A1153LinDsc[0];
               A52LinCod = P00FX4_A52LinCod[0];
               n52LinCod = P00FX4_n52LinCod[0];
               A1830SalCosCant = P00FX4_A1830SalCosCant[0];
               A62SalCosProdCod = P00FX4_A62SalCosProdCod[0];
               A61SalCosAlmCod = P00FX4_A61SalCosAlmCod[0];
               A50FamCod = P00FX4_A50FamCod[0];
               n50FamCod = P00FX4_n50FamCod[0];
               A51SublCod = P00FX4_A51SublCod[0];
               n51SublCod = P00FX4_n51SublCod[0];
               A52LinCod = P00FX4_A52LinCod[0];
               n52LinCod = P00FX4_n52LinCod[0];
               A50FamCod = P00FX4_A50FamCod[0];
               n50FamCod = P00FX4_n50FamCod[0];
               A51SublCod = P00FX4_A51SublCod[0];
               n51SublCod = P00FX4_n51SublCod[0];
               A1158LinStk = P00FX4_A1158LinStk[0];
               A1153LinDsc = P00FX4_A1153LinDsc[0];
               A434AlmCos = P00FX4_A434AlmCos[0];
               n434AlmCos = P00FX4_n434AlmCos[0];
               while ( (pr_default.getStatus(2) != 101) && ( P00FX4_A52LinCod[0] == A52LinCod ) )
               {
                  BRKFX5 = false;
                  A59SalCosAno = P00FX4_A59SalCosAno[0];
                  A60SalCosMes = P00FX4_A60SalCosMes[0];
                  A1153LinDsc = P00FX4_A1153LinDsc[0];
                  A62SalCosProdCod = P00FX4_A62SalCosProdCod[0];
                  A61SalCosAlmCod = P00FX4_A61SalCosAlmCod[0];
                  A1153LinDsc = P00FX4_A1153LinDsc[0];
                  BRKFX5 = true;
                  pr_default.readNext(2);
               }
               AV97Linea = A52LinCod;
               AV98LineaDsc = StringUtil.Trim( A1153LinDsc);
               AV103LineaTot = "Total Linea " + StringUtil.Trim( A1153LinDsc);
               AV100CantLinea = 0.0000m;
               AV99TotLinea = 0.00m;
               HFX0( false, 20) ;
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
               HFX0( false, 27) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV103LineaTot, "")), 32, Gx_line+7, 587, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV100CantLinea, "ZZZZ,ZZZ,ZZ9.9999")), 558, Gx_line+8, 683, Gx_line+23, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV99TotLinea, "ZZZZZZ,ZZZ,ZZ9.99")), 684, Gx_line+8, 809, Gx_line+23, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(589, Gx_line+5, 806, Gx_line+5, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+27);
               AV102SaldoGeneral = (decimal)(AV102SaldoGeneral+AV100CantLinea);
               AV101TotalGeneral = (decimal)(AV101TotalGeneral+AV99TotLinea);
               if ( ! BRKFX5 )
               {
                  BRKFX5 = true;
                  pr_default.readNext(2);
               }
            }
            pr_default.close(2);
            HFX0( false, 53) ;
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
            HFX0( true, 0) ;
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
                                              A61SalCosAlmCod ,
                                              A62SalCosProdCod ,
                                              A1830SalCosCant ,
                                              A52LinCod ,
                                              AV97Linea ,
                                              A59SalCosAno ,
                                              AV91Ano ,
                                              A60SalCosMes ,
                                              AV92Mes ,
                                              A1158LinStk ,
                                              A434AlmCos } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00FX5 */
         pr_default.execute(3, new Object[] {AV97Linea, AV91Ano, AV92Mes, AV45SublCod, AV46FamCod, AV9AlmCod, AV10Prodcod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKFX7 = false;
            A55ProdDsc = P00FX5_A55ProdDsc[0];
            n55ProdDsc = P00FX5_n55ProdDsc[0];
            A62SalCosProdCod = P00FX5_A62SalCosProdCod[0];
            A434AlmCos = P00FX5_A434AlmCos[0];
            n434AlmCos = P00FX5_n434AlmCos[0];
            A1158LinStk = P00FX5_A1158LinStk[0];
            A1830SalCosCant = P00FX5_A1830SalCosCant[0];
            A60SalCosMes = P00FX5_A60SalCosMes[0];
            A59SalCosAno = P00FX5_A59SalCosAno[0];
            A61SalCosAlmCod = P00FX5_A61SalCosAlmCod[0];
            A50FamCod = P00FX5_A50FamCod[0];
            n50FamCod = P00FX5_n50FamCod[0];
            A51SublCod = P00FX5_A51SublCod[0];
            n51SublCod = P00FX5_n51SublCod[0];
            A52LinCod = P00FX5_A52LinCod[0];
            n52LinCod = P00FX5_n52LinCod[0];
            A55ProdDsc = P00FX5_A55ProdDsc[0];
            n55ProdDsc = P00FX5_n55ProdDsc[0];
            A50FamCod = P00FX5_A50FamCod[0];
            n50FamCod = P00FX5_n50FamCod[0];
            A51SublCod = P00FX5_A51SublCod[0];
            n51SublCod = P00FX5_n51SublCod[0];
            A52LinCod = P00FX5_A52LinCod[0];
            n52LinCod = P00FX5_n52LinCod[0];
            A1158LinStk = P00FX5_A1158LinStk[0];
            A434AlmCos = P00FX5_A434AlmCos[0];
            n434AlmCos = P00FX5_n434AlmCos[0];
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00FX5_A62SalCosProdCod[0], A62SalCosProdCod) == 0 ) )
            {
               BRKFX7 = false;
               A55ProdDsc = P00FX5_A55ProdDsc[0];
               n55ProdDsc = P00FX5_n55ProdDsc[0];
               A60SalCosMes = P00FX5_A60SalCosMes[0];
               A59SalCosAno = P00FX5_A59SalCosAno[0];
               A61SalCosAlmCod = P00FX5_A61SalCosAlmCod[0];
               A55ProdDsc = P00FX5_A55ProdDsc[0];
               n55ProdDsc = P00FX5_n55ProdDsc[0];
               BRKFX7 = true;
               pr_default.readNext(3);
            }
            AV36ProdCodC = A62SalCosProdCod;
            AV15Producto = A55ProdDsc;
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
            AV95CostoUnit = ((AV90SaldoFinal>Convert.ToDecimal(0)) ? NumberUtil.Round( AV94SaldoTotal/ (decimal)(AV90SaldoFinal), 4) : (decimal)(0));
            HFX0( false, 28) ;
            getPrinter().GxDrawLine(589, Gx_line+4, 806, Gx_line+4, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV94SaldoTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 720, Gx_line+8, 810, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV90SaldoFinal, "ZZZZ,ZZZ,ZZ9.9999")), 594, Gx_line+8, 684, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV95CostoUnit, "ZZZZ,ZZZ,ZZ9.9999")), 655, Gx_line+8, 745, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV96TituloTot, "")), 171, Gx_line+8, 589, Gx_line+21, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+28);
            AV100CantLinea = (decimal)(AV100CantLinea+AV90SaldoFinal);
            AV99TotLinea = (decimal)(AV99TotLinea+AV94SaldoTotal);
            if ( ! BRKFX7 )
            {
               BRKFX7 = true;
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
                                              AV8LinCod ,
                                              AV45SublCod ,
                                              AV46FamCod ,
                                              AV9AlmCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A61SalCosAlmCod ,
                                              A1830SalCosCant ,
                                              A1158LinStk ,
                                              A434AlmCos ,
                                              A59SalCosAno ,
                                              AV91Ano ,
                                              A60SalCosMes ,
                                              AV92Mes ,
                                              AV36ProdCodC ,
                                              A62SalCosProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00FX6 */
         pr_default.execute(4, new Object[] {AV36ProdCodC, AV91Ano, AV92Mes, AV8LinCod, AV45SublCod, AV46FamCod, AV9AlmCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A49UniCod = P00FX6_A49UniCod[0];
            n49UniCod = P00FX6_n49UniCod[0];
            A62SalCosProdCod = P00FX6_A62SalCosProdCod[0];
            A60SalCosMes = P00FX6_A60SalCosMes[0];
            A59SalCosAno = P00FX6_A59SalCosAno[0];
            A434AlmCos = P00FX6_A434AlmCos[0];
            n434AlmCos = P00FX6_n434AlmCos[0];
            A1158LinStk = P00FX6_A1158LinStk[0];
            A1830SalCosCant = P00FX6_A1830SalCosCant[0];
            A61SalCosAlmCod = P00FX6_A61SalCosAlmCod[0];
            A50FamCod = P00FX6_A50FamCod[0];
            n50FamCod = P00FX6_n50FamCod[0];
            A51SublCod = P00FX6_A51SublCod[0];
            n51SublCod = P00FX6_n51SublCod[0];
            A52LinCod = P00FX6_A52LinCod[0];
            n52LinCod = P00FX6_n52LinCod[0];
            A436AlmDsc = P00FX6_A436AlmDsc[0];
            n436AlmDsc = P00FX6_n436AlmDsc[0];
            A1997UniAbr = P00FX6_A1997UniAbr[0];
            A1831SalCosUni = P00FX6_A1831SalCosUni[0];
            A49UniCod = P00FX6_A49UniCod[0];
            n49UniCod = P00FX6_n49UniCod[0];
            A50FamCod = P00FX6_A50FamCod[0];
            n50FamCod = P00FX6_n50FamCod[0];
            A51SublCod = P00FX6_A51SublCod[0];
            n51SublCod = P00FX6_n51SublCod[0];
            A52LinCod = P00FX6_A52LinCod[0];
            n52LinCod = P00FX6_n52LinCod[0];
            A1997UniAbr = P00FX6_A1997UniAbr[0];
            A1158LinStk = P00FX6_A1158LinStk[0];
            A434AlmCos = P00FX6_A434AlmCos[0];
            n434AlmCos = P00FX6_n434AlmCos[0];
            A436AlmDsc = P00FX6_A436AlmDsc[0];
            n436AlmDsc = P00FX6_n436AlmDsc[0];
            AV104AlmCodigo = A61SalCosAlmCod;
            AV105AlmacenDsc = StringUtil.Trim( A436AlmDsc);
            AV65UniAbr = StringUtil.Trim( A1997UniAbr);
            AV16Saldo = NumberUtil.Round( A1830SalCosCant, 4);
            AV93CostUnit = NumberUtil.Round( A1831SalCosUni, 4);
            AV28CostoT = NumberUtil.Round( AV16Saldo*AV93CostUnit, 2);
            HFX0( false, 18) ;
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
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void HFX0( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11Almacen, "")), 165, Gx_line+34, 674, Gx_line+59, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+136, 814, Gx_line+181, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción del Producto", 122, Gx_line+153, 251, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Codigo", 17, Gx_line+153, 53, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Linea :", 249, Gx_line+103, 292, Gx_line+118, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 319, Gx_line+98, 628, Gx_line+122, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro2, "")), 264, Gx_line+59, 577, Gx_line+83, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12Titulo, "")), 166, Gx_line+14, 673, Gx_line+39, 1, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV43Logo)) ? AV108Logo_GXI : AV43Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+3, 175, Gx_line+80) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Empresa, "")), 9, Gx_line+82, 257, Gx_line+100, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41EmpRUC, "")), 9, Gx_line+100, 179, Gx_line+118, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(610, Gx_line+136, 610, Gx_line+181, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cantidad", 628, Gx_line+164, 675, Gx_line+177, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 760, Gx_line+164, 804, Gx_line+177, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 696, Gx_line+164, 740, Gx_line+177, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(611, Gx_line+158, 812, Gx_line+158, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 696, Gx_line+141, 725, Gx_line+154, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(394, Gx_line+136, 394, Gx_line+181, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuario :", 697, Gx_line+54, 749, Gx_line+68, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66UsuCod, "")), 756, Gx_line+54, 809, Gx_line+69, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Medida", 353, Gx_line+153, 392, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Almacen", 480, Gx_line+151, 526, Gx_line+164, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(348, Gx_line+136, 348, Gx_line+181, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(73, Gx_line+136, 73, Gx_line+181, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+181);
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
         AV108Logo_GXI = "";
         AV66UsuCod = "";
         AV12Titulo = "";
         scmdbuf = "";
         P00FX2_A63AlmCod = new int[1] ;
         P00FX2_A436AlmDsc = new string[] {""} ;
         P00FX2_n436AlmDsc = new bool[] {false} ;
         A436AlmDsc = "";
         AV11Almacen = "";
         AV21cMes = "";
         GXt_char1 = "";
         AV22Filtro1 = "";
         AV24Filtro2 = "";
         P00FX3_A52LinCod = new int[1] ;
         P00FX3_n52LinCod = new bool[] {false} ;
         P00FX3_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         A62SalCosProdCod = "";
         P00FX4_A59SalCosAno = new int[1] ;
         P00FX4_A60SalCosMes = new short[1] ;
         P00FX4_A1158LinStk = new short[1] ;
         P00FX4_A434AlmCos = new short[1] ;
         P00FX4_n434AlmCos = new bool[] {false} ;
         P00FX4_A1153LinDsc = new string[] {""} ;
         P00FX4_A52LinCod = new int[1] ;
         P00FX4_n52LinCod = new bool[] {false} ;
         P00FX4_A1830SalCosCant = new decimal[1] ;
         P00FX4_A62SalCosProdCod = new string[] {""} ;
         P00FX4_A61SalCosAlmCod = new int[1] ;
         P00FX4_A50FamCod = new int[1] ;
         P00FX4_n50FamCod = new bool[] {false} ;
         P00FX4_A51SublCod = new int[1] ;
         P00FX4_n51SublCod = new bool[] {false} ;
         AV98LineaDsc = "";
         AV103LineaTot = "";
         P00FX5_A55ProdDsc = new string[] {""} ;
         P00FX5_n55ProdDsc = new bool[] {false} ;
         P00FX5_A62SalCosProdCod = new string[] {""} ;
         P00FX5_A434AlmCos = new short[1] ;
         P00FX5_n434AlmCos = new bool[] {false} ;
         P00FX5_A1158LinStk = new short[1] ;
         P00FX5_A1830SalCosCant = new decimal[1] ;
         P00FX5_A60SalCosMes = new short[1] ;
         P00FX5_A59SalCosAno = new int[1] ;
         P00FX5_A61SalCosAlmCod = new int[1] ;
         P00FX5_A50FamCod = new int[1] ;
         P00FX5_n50FamCod = new bool[] {false} ;
         P00FX5_A51SublCod = new int[1] ;
         P00FX5_n51SublCod = new bool[] {false} ;
         P00FX5_A52LinCod = new int[1] ;
         P00FX5_n52LinCod = new bool[] {false} ;
         A55ProdDsc = "";
         AV36ProdCodC = "";
         AV15Producto = "";
         AV96TituloTot = "";
         P00FX6_A49UniCod = new int[1] ;
         P00FX6_n49UniCod = new bool[] {false} ;
         P00FX6_A62SalCosProdCod = new string[] {""} ;
         P00FX6_A60SalCosMes = new short[1] ;
         P00FX6_A59SalCosAno = new int[1] ;
         P00FX6_A434AlmCos = new short[1] ;
         P00FX6_n434AlmCos = new bool[] {false} ;
         P00FX6_A1158LinStk = new short[1] ;
         P00FX6_A1830SalCosCant = new decimal[1] ;
         P00FX6_A61SalCosAlmCod = new int[1] ;
         P00FX6_A50FamCod = new int[1] ;
         P00FX6_n50FamCod = new bool[] {false} ;
         P00FX6_A51SublCod = new int[1] ;
         P00FX6_n51SublCod = new bool[] {false} ;
         P00FX6_A52LinCod = new int[1] ;
         P00FX6_n52LinCod = new bool[] {false} ;
         P00FX6_A436AlmDsc = new string[] {""} ;
         P00FX6_n436AlmDsc = new bool[] {false} ;
         P00FX6_A1997UniAbr = new string[] {""} ;
         P00FX6_A1831SalCosUni = new decimal[1] ;
         A1997UniAbr = "";
         AV105AlmacenDsc = "";
         AV65UniAbr = "";
         Gx_time = "";
         AV43Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_arresumensaldosvalorizadospdf__default(),
            new Object[][] {
                new Object[] {
               P00FX2_A63AlmCod, P00FX2_A436AlmDsc
               }
               , new Object[] {
               P00FX3_A52LinCod, P00FX3_A1153LinDsc
               }
               , new Object[] {
               P00FX4_A59SalCosAno, P00FX4_A60SalCosMes, P00FX4_A1158LinStk, P00FX4_A434AlmCos, P00FX4_n434AlmCos, P00FX4_A1153LinDsc, P00FX4_A52LinCod, P00FX4_n52LinCod, P00FX4_A1830SalCosCant, P00FX4_A62SalCosProdCod,
               P00FX4_A61SalCosAlmCod, P00FX4_A50FamCod, P00FX4_n50FamCod, P00FX4_A51SublCod, P00FX4_n51SublCod
               }
               , new Object[] {
               P00FX5_A55ProdDsc, P00FX5_n55ProdDsc, P00FX5_A62SalCosProdCod, P00FX5_A434AlmCos, P00FX5_n434AlmCos, P00FX5_A1158LinStk, P00FX5_A1830SalCosCant, P00FX5_A60SalCosMes, P00FX5_A59SalCosAno, P00FX5_A61SalCosAlmCod,
               P00FX5_A50FamCod, P00FX5_n50FamCod, P00FX5_A51SublCod, P00FX5_n51SublCod, P00FX5_A52LinCod, P00FX5_n52LinCod
               }
               , new Object[] {
               P00FX6_A49UniCod, P00FX6_n49UniCod, P00FX6_A62SalCosProdCod, P00FX6_A60SalCosMes, P00FX6_A59SalCosAno, P00FX6_A434AlmCos, P00FX6_n434AlmCos, P00FX6_A1158LinStk, P00FX6_A1830SalCosCant, P00FX6_A61SalCosAlmCod,
               P00FX6_A50FamCod, P00FX6_n50FamCod, P00FX6_A51SublCod, P00FX6_n51SublCod, P00FX6_A52LinCod, P00FX6_n52LinCod, P00FX6_A436AlmDsc, P00FX6_n436AlmDsc, P00FX6_A1997UniAbr, P00FX6_A1831SalCosUni
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
      private short A60SalCosMes ;
      private short A1158LinStk ;
      private short A434AlmCos ;
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
      private int A61SalCosAlmCod ;
      private int A59SalCosAno ;
      private int AV97Linea ;
      private int Gx_OldLine ;
      private int A49UniCod ;
      private int AV104AlmCodigo ;
      private decimal AV101TotalGeneral ;
      private decimal AV102SaldoGeneral ;
      private decimal A1830SalCosCant ;
      private decimal AV100CantLinea ;
      private decimal AV99TotLinea ;
      private decimal AV90SaldoFinal ;
      private decimal AV94SaldoTotal ;
      private decimal AV95CostoUnit ;
      private decimal A1831SalCosUni ;
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
      private string A1153LinDsc ;
      private string A62SalCosProdCod ;
      private string AV98LineaDsc ;
      private string AV103LineaTot ;
      private string A55ProdDsc ;
      private string AV36ProdCodC ;
      private string AV15Producto ;
      private string AV96TituloTot ;
      private string A1997UniAbr ;
      private string AV105AlmacenDsc ;
      private string AV65UniAbr ;
      private string Gx_time ;
      private string sImgUrl ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n436AlmDsc ;
      private bool n52LinCod ;
      private bool BRKFX5 ;
      private bool n434AlmCos ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private bool BRKFX7 ;
      private bool n55ProdDsc ;
      private bool n49UniCod ;
      private string AV108Logo_GXI ;
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
      private int[] P00FX2_A63AlmCod ;
      private string[] P00FX2_A436AlmDsc ;
      private bool[] P00FX2_n436AlmDsc ;
      private int[] P00FX3_A52LinCod ;
      private bool[] P00FX3_n52LinCod ;
      private string[] P00FX3_A1153LinDsc ;
      private int[] P00FX4_A59SalCosAno ;
      private short[] P00FX4_A60SalCosMes ;
      private short[] P00FX4_A1158LinStk ;
      private short[] P00FX4_A434AlmCos ;
      private bool[] P00FX4_n434AlmCos ;
      private string[] P00FX4_A1153LinDsc ;
      private int[] P00FX4_A52LinCod ;
      private bool[] P00FX4_n52LinCod ;
      private decimal[] P00FX4_A1830SalCosCant ;
      private string[] P00FX4_A62SalCosProdCod ;
      private int[] P00FX4_A61SalCosAlmCod ;
      private int[] P00FX4_A50FamCod ;
      private bool[] P00FX4_n50FamCod ;
      private int[] P00FX4_A51SublCod ;
      private bool[] P00FX4_n51SublCod ;
      private string[] P00FX5_A55ProdDsc ;
      private bool[] P00FX5_n55ProdDsc ;
      private string[] P00FX5_A62SalCosProdCod ;
      private short[] P00FX5_A434AlmCos ;
      private bool[] P00FX5_n434AlmCos ;
      private short[] P00FX5_A1158LinStk ;
      private decimal[] P00FX5_A1830SalCosCant ;
      private short[] P00FX5_A60SalCosMes ;
      private int[] P00FX5_A59SalCosAno ;
      private int[] P00FX5_A61SalCosAlmCod ;
      private int[] P00FX5_A50FamCod ;
      private bool[] P00FX5_n50FamCod ;
      private int[] P00FX5_A51SublCod ;
      private bool[] P00FX5_n51SublCod ;
      private int[] P00FX5_A52LinCod ;
      private bool[] P00FX5_n52LinCod ;
      private int[] P00FX6_A49UniCod ;
      private bool[] P00FX6_n49UniCod ;
      private string[] P00FX6_A62SalCosProdCod ;
      private short[] P00FX6_A60SalCosMes ;
      private int[] P00FX6_A59SalCosAno ;
      private short[] P00FX6_A434AlmCos ;
      private bool[] P00FX6_n434AlmCos ;
      private short[] P00FX6_A1158LinStk ;
      private decimal[] P00FX6_A1830SalCosCant ;
      private int[] P00FX6_A61SalCosAlmCod ;
      private int[] P00FX6_A50FamCod ;
      private bool[] P00FX6_n50FamCod ;
      private int[] P00FX6_A51SublCod ;
      private bool[] P00FX6_n51SublCod ;
      private int[] P00FX6_A52LinCod ;
      private bool[] P00FX6_n52LinCod ;
      private string[] P00FX6_A436AlmDsc ;
      private bool[] P00FX6_n436AlmDsc ;
      private string[] P00FX6_A1997UniAbr ;
      private decimal[] P00FX6_A1831SalCosUni ;
   }

   public class r_arresumensaldosvalorizadospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FX4( IGxContext context ,
                                             int AV8LinCod ,
                                             int AV45SublCod ,
                                             int AV46FamCod ,
                                             int AV9AlmCod ,
                                             string AV10Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A61SalCosAlmCod ,
                                             string A62SalCosProdCod ,
                                             decimal A1830SalCosCant ,
                                             int A59SalCosAno ,
                                             short AV91Ano ,
                                             short A60SalCosMes ,
                                             short AV92Mes ,
                                             short A1158LinStk ,
                                             short A434AlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[SalCosAno], T1.[SalCosMes], T3.[LinStk], T4.[AlmCos], T3.[LinDsc], T2.[LinCod], T1.[SalCosCant], T1.[SalCosProdCod] AS SalCosProdCod, T1.[SalCosAlmCod] AS SalCosAlmCod, T2.[FamCod], T2.[SublCod] FROM ((([ASALDOCOSTOMENSUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[SalCosProdCod]) LEFT JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T1.[SalCosAlmCod])";
         AddWhere(sWhereString, "(T1.[SalCosCant] <> 0)");
         AddWhere(sWhereString, "(T1.[SalCosAno] = @AV91Ano)");
         AddWhere(sWhereString, "(T1.[SalCosMes] = @AV92Mes)");
         AddWhere(sWhereString, "(T3.[LinStk] = 1)");
         AddWhere(sWhereString, "(T4.[AlmCos] = 1)");
         if ( ! (0==AV8LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV8LinCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV45SublCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV45SublCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV46FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV46FamCod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV9AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[SalCosAlmCod] = @AV9AlmCod)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[SalCosProdCod] = @AV10Prodcod)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[LinCod], T3.[LinDsc]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00FX5( IGxContext context ,
                                             int AV45SublCod ,
                                             int AV46FamCod ,
                                             int AV9AlmCod ,
                                             string AV10Prodcod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A61SalCosAlmCod ,
                                             string A62SalCosProdCod ,
                                             decimal A1830SalCosCant ,
                                             int A52LinCod ,
                                             int AV97Linea ,
                                             int A59SalCosAno ,
                                             short AV91Ano ,
                                             short A60SalCosMes ,
                                             short AV92Mes ,
                                             short A1158LinStk ,
                                             short A434AlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[7];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.[ProdDsc], T1.[SalCosProdCod] AS SalCosProdCod, T4.[AlmCos], T3.[LinStk], T1.[SalCosCant], T1.[SalCosMes], T1.[SalCosAno], T1.[SalCosAlmCod] AS SalCosAlmCod, T2.[FamCod], T2.[SublCod], T2.[LinCod] FROM ((([ASALDOCOSTOMENSUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[SalCosProdCod]) LEFT JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T1.[SalCosAlmCod])";
         AddWhere(sWhereString, "(T1.[SalCosCant] <> 0)");
         AddWhere(sWhereString, "(T2.[LinCod] = @AV97Linea)");
         AddWhere(sWhereString, "(T1.[SalCosAno] = @AV91Ano)");
         AddWhere(sWhereString, "(T1.[SalCosMes] = @AV92Mes)");
         AddWhere(sWhereString, "(T3.[LinStk] = 1)");
         AddWhere(sWhereString, "(T4.[AlmCos] = 1)");
         if ( ! (0==AV45SublCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV45SublCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV46FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV46FamCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV9AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[SalCosAlmCod] = @AV9AlmCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[SalCosProdCod] = @AV10Prodcod)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SalCosProdCod], T2.[ProdDsc]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00FX6( IGxContext context ,
                                             int AV8LinCod ,
                                             int AV45SublCod ,
                                             int AV46FamCod ,
                                             int AV9AlmCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A61SalCosAlmCod ,
                                             decimal A1830SalCosCant ,
                                             short A1158LinStk ,
                                             short A434AlmCos ,
                                             int A59SalCosAno ,
                                             short AV91Ano ,
                                             short A60SalCosMes ,
                                             short AV92Mes ,
                                             string AV36ProdCodC ,
                                             string A62SalCosProdCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[7];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T1.[SalCosProdCod] AS SalCosProdCod, T1.[SalCosMes], T1.[SalCosAno], T5.[AlmCos], T4.[LinStk], T1.[SalCosCant], T1.[SalCosAlmCod] AS SalCosAlmCod, T2.[FamCod], T2.[SublCod], T2.[LinCod], T5.[AlmDsc], T3.[UniAbr], T1.[SalCosUni] FROM (((([ASALDOCOSTOMENSUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[SalCosProdCod]) LEFT JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) LEFT JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T2.[LinCod]) INNER JOIN [CALMACEN] T5 ON T5.[AlmCod] = T1.[SalCosAlmCod])";
         AddWhere(sWhereString, "(T1.[SalCosProdCod] = @AV36ProdCodC)");
         AddWhere(sWhereString, "(T1.[SalCosCant] <> 0)");
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         AddWhere(sWhereString, "(T5.[AlmCos] = 1)");
         AddWhere(sWhereString, "(T1.[SalCosAno] = @AV91Ano)");
         AddWhere(sWhereString, "(T1.[SalCosMes] = @AV92Mes)");
         if ( ! (0==AV8LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV8LinCod)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV45SublCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV45SublCod)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! (0==AV46FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV46FamCod)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (0==AV9AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[SalCosAlmCod] = @AV9AlmCod)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SalCosProdCod]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P00FX4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (decimal)dynConstraints[10] , (int)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] );
               case 3 :
                     return conditional_P00FX5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] );
               case 4 :
                     return conditional_P00FX6(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (decimal)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (int)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] );
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
          Object[] prmP00FX2;
          prmP00FX2 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP00FX3;
          prmP00FX3 = new Object[] {
          new ParDef("@AV8LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00FX4;
          prmP00FX4 = new Object[] {
          new ParDef("@AV91Ano",GXType.Int16,4,0) ,
          new ParDef("@AV92Mes",GXType.Int16,2,0) ,
          new ParDef("@AV8LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV45SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV46FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00FX5;
          prmP00FX5 = new Object[] {
          new ParDef("@AV97Linea",GXType.Int32,6,0) ,
          new ParDef("@AV91Ano",GXType.Int16,4,0) ,
          new ParDef("@AV92Mes",GXType.Int16,2,0) ,
          new ParDef("@AV45SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV46FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00FX6;
          prmP00FX6 = new Object[] {
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV91Ano",GXType.Int16,4,0) ,
          new ParDef("@AV92Mes",GXType.Int16,2,0) ,
          new ParDef("@AV8LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV45SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV46FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FX2", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV9AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FX2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FX3", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV8LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FX3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FX4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FX4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FX5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FX5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FX6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FX6,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 15);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((int[]) buf[13])[0] = rslt.getInt(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 15);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((int[]) buf[12])[0] = rslt.getInt(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((int[]) buf[14])[0] = rslt.getInt(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 15);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((int[]) buf[12])[0] = rslt.getInt(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((int[]) buf[14])[0] = rslt.getInt(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 100);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getString(13, 5);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(14);
                return;
       }
    }

 }

}
