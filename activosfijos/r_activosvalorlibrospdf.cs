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
namespace GeneXus.Programs.activosfijos {
   public class r_activosvalorlibrospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "activosfijos.r_activosvalorlibrospdf.aspx")), "activosfijos.r_activosvalorlibrospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "activosfijos.r_activosvalorlibrospdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "ACTClaCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV16ACTClaCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV26ACTGrupCod = GetPar( "ACTGrupCod");
                  AV8ACTActCod = GetPar( "ACTActCod");
                  AV11ActActItem = GetPar( "ActActItem");
                  AV37Ano = (short)(NumberUtil.Val( GetPar( "Ano"), "."));
                  AV68Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
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

      public r_activosvalorlibrospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_activosvalorlibrospdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ACTClaCod ,
                           ref string aP1_ACTGrupCod ,
                           ref string aP2_ACTActCod ,
                           ref string aP3_ActActItem ,
                           ref short aP4_Ano ,
                           ref short aP5_Mes )
      {
         this.AV16ACTClaCod = aP0_ACTClaCod;
         this.AV26ACTGrupCod = aP1_ACTGrupCod;
         this.AV8ACTActCod = aP2_ACTActCod;
         this.AV11ActActItem = aP3_ActActItem;
         this.AV37Ano = aP4_Ano;
         this.AV68Mes = aP5_Mes;
         initialize();
         executePrivate();
         aP0_ACTClaCod=this.AV16ACTClaCod;
         aP1_ACTGrupCod=this.AV26ACTGrupCod;
         aP2_ACTActCod=this.AV8ACTActCod;
         aP3_ActActItem=this.AV11ActActItem;
         aP4_Ano=this.AV37Ano;
         aP5_Mes=this.AV68Mes;
      }

      public short executeUdp( ref string aP0_ACTClaCod ,
                               ref string aP1_ACTGrupCod ,
                               ref string aP2_ACTActCod ,
                               ref string aP3_ActActItem ,
                               ref short aP4_Ano )
      {
         execute(ref aP0_ACTClaCod, ref aP1_ACTGrupCod, ref aP2_ACTActCod, ref aP3_ActActItem, ref aP4_Ano, ref aP5_Mes);
         return AV68Mes ;
      }

      public void executeSubmit( ref string aP0_ACTClaCod ,
                                 ref string aP1_ACTGrupCod ,
                                 ref string aP2_ACTActCod ,
                                 ref string aP3_ActActItem ,
                                 ref short aP4_Ano ,
                                 ref short aP5_Mes )
      {
         r_activosvalorlibrospdf objr_activosvalorlibrospdf;
         objr_activosvalorlibrospdf = new r_activosvalorlibrospdf();
         objr_activosvalorlibrospdf.AV16ACTClaCod = aP0_ACTClaCod;
         objr_activosvalorlibrospdf.AV26ACTGrupCod = aP1_ACTGrupCod;
         objr_activosvalorlibrospdf.AV8ACTActCod = aP2_ACTActCod;
         objr_activosvalorlibrospdf.AV11ActActItem = aP3_ActActItem;
         objr_activosvalorlibrospdf.AV37Ano = aP4_Ano;
         objr_activosvalorlibrospdf.AV68Mes = aP5_Mes;
         objr_activosvalorlibrospdf.context.SetSubmitInitialConfig(context);
         objr_activosvalorlibrospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_activosvalorlibrospdf);
         aP0_ACTClaCod=this.AV16ACTClaCod;
         aP1_ACTGrupCod=this.AV26ACTGrupCod;
         aP2_ACTActCod=this.AV8ACTActCod;
         aP3_ActActItem=this.AV11ActActItem;
         aP4_Ano=this.AV37Ano;
         aP5_Mes=this.AV68Mes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_activosvalorlibrospdf)stateInfo).executePrivate();
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
            AV49Empresa = AV86Session.Get("Empresa");
            AV48EmpDir = AV86Session.Get("EmpDir");
            AV50EmpRUC = AV86Session.Get("EmpRUC");
            AV82Ruta = AV86Session.Get("RUTA") + "/Logo.jpg";
            AV67Logo = AV82Ruta;
            AV111Logo_GXI = GXDbFile.PathToUrl( AV82Ruta);
            AV94Titulo = "Reporte de Activos Valor en Libros";
            GXt_char1 = AV39cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV68Mes, out  GXt_char1) ;
            AV39cMes = ((AV68Mes==0) ? "" : GXt_char1);
            AV77Periodo = "Periodo : " + StringUtil.Trim( AV39cMes) + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV37Ano), 10, 0));
            AV53FechaC = "01/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV68Mes), 10, 0)) + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV37Ano), 10, 0));
            AV54FechaIni = context.localUtil.CToD( AV53FechaC, 2);
            GXt_date2 = AV55FechaUlt;
            new GeneXus.Programs.generales.pobtieneultimodiames(context ).execute(  AV54FechaIni, out  GXt_date2) ;
            AV55FechaUlt = GXt_date2;
            AV92Tipo = "D";
            AV64jAnoAnt = AV37Ano;
            AV65jMesAnt = AV68Mes;
            if ( AV68Mes == 12 )
            {
               AV65jMesAnt = 1;
               AV64jAnoAnt = (short)(AV37Ano-1);
            }
            else
            {
               AV65jMesAnt = (short)(AV68Mes-1);
            }
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV16ACTClaCod ,
                                                 AV26ACTGrupCod ,
                                                 AV8ACTActCod ,
                                                 AV11ActActItem ,
                                                 AV68Mes ,
                                                 A426ACTClaCod ,
                                                 A2103ACTGrupCod ,
                                                 A2100ACTActCod ,
                                                 A2104ActActItem ,
                                                 A2108ACTHisMes ,
                                                 A2107ACTHisAno ,
                                                 AV37Ano } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00F82 */
            pr_default.execute(0, new Object[] {AV37Ano, AV16ACTClaCod, AV26ACTGrupCod, AV8ACTActCod, AV11ActActItem, AV68Mes});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKF83 = false;
               A2107ACTHisAno = P00F82_A2107ACTHisAno[0];
               A2184ACTClaDsc = P00F82_A2184ACTClaDsc[0];
               A426ACTClaCod = P00F82_A426ACTClaCod[0];
               A2108ACTHisMes = P00F82_A2108ACTHisMes[0];
               A2104ActActItem = P00F82_A2104ActActItem[0];
               n2104ActActItem = P00F82_n2104ActActItem[0];
               A2100ACTActCod = P00F82_A2100ACTActCod[0];
               A2103ACTGrupCod = P00F82_A2103ACTGrupCod[0];
               A426ACTClaCod = P00F82_A426ACTClaCod[0];
               A2103ACTGrupCod = P00F82_A2103ACTGrupCod[0];
               A2184ACTClaDsc = P00F82_A2184ACTClaDsc[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00F82_A426ACTClaCod[0], A426ACTClaCod) == 0 ) )
               {
                  BRKF83 = false;
                  A2107ACTHisAno = P00F82_A2107ACTHisAno[0];
                  A2184ACTClaDsc = P00F82_A2184ACTClaDsc[0];
                  A2108ACTHisMes = P00F82_A2108ACTHisMes[0];
                  A2104ActActItem = P00F82_A2104ActActItem[0];
                  n2104ActActItem = P00F82_n2104ActActItem[0];
                  A2100ACTActCod = P00F82_A2100ACTActCod[0];
                  A2184ACTClaDsc = P00F82_A2184ACTClaDsc[0];
                  BRKF83 = true;
                  pr_default.readNext(0);
               }
               AV40Codigo = A426ACTClaCod;
               AV38CentroCosto = "Tipo de Activo : " + StringUtil.Trim( A2184ACTClaDsc);
               AV42CosDSc = StringUtil.Trim( A2184ACTClaDsc);
               AV75nValor = 0;
               AV76nValorCalculo = 0;
               AV69nDAcumulada = 0;
               AV70nDAnterior = 0;
               AV72nImpLibro = 0;
               AV73nImpPorDepre = 0;
               AV71nImpDepre = 0;
               HF80( false, 15) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38CentroCosto, "")), 7, Gx_line+2, 425, Gx_line+13, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+15);
               /* Execute user subroutine: 'DETALLE' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               HF80( false, 31) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38CentroCosto, "")), 30, Gx_line+10, 391, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(400, Gx_line+5, 793, Gx_line+5, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75nValor, "ZZZZZZ,ZZZ,ZZ9.99")), 523, Gx_line+10, 602, Gx_line+20, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72nImpLibro, "ZZZZZZ,ZZZ,ZZ9.99")), 701, Gx_line+10, 773, Gx_line+21, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+31);
               if ( ! BRKF83 )
               {
                  BRKF83 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            HF80( false, 65) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV105TValor, "ZZZZZZ,ZZZ,ZZ9.99")), 523, Gx_line+19, 602, Gx_line+33, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(395, Gx_line+10, 788, Gx_line+10, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("TOTAL GENERAL", 298, Gx_line+19, 391, Gx_line+33, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV90TImpLibro, "ZZZZZZ,ZZZ,ZZ9.99")), 648, Gx_line+19, 773, Gx_line+34, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+65);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HF80( true, 0) ;
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
         /* 'DETALLE' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV26ACTGrupCod ,
                                              AV8ACTActCod ,
                                              AV11ActActItem ,
                                              AV68Mes ,
                                              A2103ACTGrupCod ,
                                              A2100ACTActCod ,
                                              A2104ActActItem ,
                                              A2108ACTHisMes ,
                                              A426ACTClaCod ,
                                              AV40Codigo ,
                                              A2107ACTHisAno ,
                                              AV37Ano } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00F83 */
         pr_default.execute(1, new Object[] {AV40Codigo, AV37Ano, AV26ACTGrupCod, AV8ACTActCod, AV11ActActItem, AV68Mes});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A2114ACTSGrupCod = P00F83_A2114ACTSGrupCod[0];
            A2108ACTHisMes = P00F83_A2108ACTHisMes[0];
            A2107ACTHisAno = P00F83_A2107ACTHisAno[0];
            A2104ActActItem = P00F83_A2104ActActItem[0];
            n2104ActActItem = P00F83_n2104ActActItem[0];
            A2100ACTActCod = P00F83_A2100ACTActCod[0];
            A2103ACTGrupCod = P00F83_A2103ACTGrupCod[0];
            A426ACTClaCod = P00F83_A426ACTClaCod[0];
            A2118ACTActCodEQV = P00F83_A2118ACTActCodEQV[0];
            A2155ACTSGrupDsc = P00F83_A2155ACTSGrupDsc[0];
            A2122ACTActDsc = P00F83_A2122ACTActDsc[0];
            A2156ACTSGrupPor = P00F83_A2156ACTSGrupPor[0];
            A2143ACTDetFecIni = P00F83_A2143ACTDetFecIni[0];
            A2150ACTDetValorNeto = P00F83_A2150ACTDetValorNeto[0];
            A2152ACTDetValorResiduo = P00F83_A2152ACTDetValorResiduo[0];
            A2132ACTActOrd = P00F83_A2132ACTActOrd[0];
            A2123ACTActFech = P00F83_A2123ACTActFech[0];
            A2144ACTDetMarca = P00F83_A2144ACTDetMarca[0];
            A2145ACTDetModelo = P00F83_A2145ACTDetModelo[0];
            A2147ACTDetSerie = P00F83_A2147ACTDetSerie[0];
            A2103ACTGrupCod = P00F83_A2103ACTGrupCod[0];
            A426ACTClaCod = P00F83_A426ACTClaCod[0];
            A2118ACTActCodEQV = P00F83_A2118ACTActCodEQV[0];
            A2122ACTActDsc = P00F83_A2122ACTActDsc[0];
            A2132ACTActOrd = P00F83_A2132ACTActOrd[0];
            A2123ACTActFech = P00F83_A2123ACTActFech[0];
            A2114ACTSGrupCod = P00F83_A2114ACTSGrupCod[0];
            A2143ACTDetFecIni = P00F83_A2143ACTDetFecIni[0];
            A2150ACTDetValorNeto = P00F83_A2150ACTDetValorNeto[0];
            A2152ACTDetValorResiduo = P00F83_A2152ACTDetValorResiduo[0];
            A2144ACTDetMarca = P00F83_A2144ACTDetMarca[0];
            A2145ACTDetModelo = P00F83_A2145ACTDetModelo[0];
            A2147ACTDetSerie = P00F83_A2147ACTDetSerie[0];
            A2155ACTSGrupDsc = P00F83_A2155ACTSGrupDsc[0];
            A2156ACTSGrupPor = P00F83_A2156ACTSGrupPor[0];
            AV17ActCod = A2100ACTActCod;
            AV27ActItem = A2104ActActItem;
            AV18ActCodEQV = StringUtil.Trim( A2118ACTActCodEQV);
            AV28ACTSGrupDsc = StringUtil.Trim( A2155ACTSGrupDsc);
            AV25ActDsc = StringUtil.Trim( A2122ACTActDsc) + " - " + StringUtil.Trim( AV28ACTSGrupDsc);
            AV79Porcentaje = A2156ACTSGrupPor;
            AV19ACTDetFecIni = A2143ACTDetFecIni;
            AV51Estado = "Activo";
            /* Execute user subroutine: 'REPARACIONES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'BAJA' */
            S135 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV107Valor = (decimal)((A2150ACTDetValorNeto+AV24ACTDetValorReparacion+AV23ACTDetValorCompras));
            AV108ValorCalculo = (decimal)((A2150ACTDetValorNeto+AV24ACTDetValorReparacion+AV23ACTDetValorCompras)-(A2152ACTDetValorResiduo));
            AV14ACTActOrd = A2132ACTActOrd;
            AV10ACTActFech = A2123ACTActFech;
            AV20ACTDetMarca = A2144ACTDetMarca;
            AV21ACTDetModelo = A2145ACTDetModelo;
            AV22ACTDetSerie = A2147ACTDetSerie;
            AV59ImpDepre = 0.00m;
            /* Execute user subroutine: 'SALDOINICIAL' */
            S145 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'SALDOMENSUAL' */
            S155 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV60ImpLibro = (decimal)(AV107Valor-(AV44DAcumulada+AV59ImpDepre));
            AV61ImpPorDep = (decimal)((AV107Valor)-(A2152ACTDetValorResiduo+AV44DAcumulada+AV59ImpDepre));
            if ( StringUtil.StrCmp(AV92Tipo, "D") == 0 )
            {
               HF80( false, 17) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV19ACTDetFecIni, "99/99/99"), 9, Gx_line+3, 41, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ActCodEQV, "")), 59, Gx_line+3, 143, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV107Valor, "ZZZZZZ,ZZZ,ZZ9.99")), 523, Gx_line+3, 602, Gx_line+13, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25ActDsc, "")), 136, Gx_line+3, 391, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV79Porcentaje, "ZZ9.99")), 618, Gx_line+3, 652, Gx_line+13, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60ImpLibro, "ZZZZZZ,ZZZ,ZZ9.99")), 701, Gx_line+3, 773, Gx_line+14, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
            }
            AV75nValor = (decimal)(AV75nValor+AV107Valor);
            AV76nValorCalculo = (decimal)(AV76nValorCalculo+AV108ValorCalculo);
            AV69nDAcumulada = (decimal)(AV69nDAcumulada+AV44DAcumulada);
            AV70nDAnterior = (decimal)(AV70nDAnterior+AV45DAnterior);
            AV72nImpLibro = (decimal)(AV72nImpLibro+AV60ImpLibro);
            AV73nImpPorDepre = (decimal)(AV73nImpPorDepre+AV61ImpPorDep);
            AV71nImpDepre = (decimal)(AV71nImpDepre+AV59ImpDepre);
            AV105TValor = (decimal)(AV105TValor+AV107Valor);
            AV106TValorCalculo = (decimal)(AV106TValorCalculo+AV108ValorCalculo);
            AV87TDAcumulada = (decimal)(AV87TDAcumulada+AV44DAcumulada);
            AV88TDAnterior = (decimal)(AV88TDAnterior+AV45DAnterior);
            AV90TImpLibro = (decimal)(AV90TImpLibro+AV60ImpLibro);
            AV91TImpPorDepre = (decimal)(AV91TImpPorDepre+AV61ImpPorDep);
            AV89TImpDepre = (decimal)(AV89TImpDepre+AV59ImpDepre);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S145( )
      {
         /* 'SALDOINICIAL' Routine */
         returnInSub = false;
         AV44DAcumulada = 0.00m;
         /* Optimized group. */
         /* Using cursor P00F84 */
         pr_default.execute(2, new Object[] {AV17ActCod, AV27ActItem, AV54FechaIni});
         c2189ACTHisDepre = P00F84_A2189ACTHisDepre[0];
         pr_default.close(2);
         AV44DAcumulada = (decimal)(AV44DAcumulada+c2189ACTHisDepre);
         /* End optimized group. */
         AV45DAnterior = 0.00m;
         /* Using cursor P00F85 */
         pr_default.execute(3, new Object[] {AV64jAnoAnt, AV65jMesAnt, AV17ActCod, AV27ActItem});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A2104ActActItem = P00F85_A2104ActActItem[0];
            n2104ActActItem = P00F85_n2104ActActItem[0];
            A2100ACTActCod = P00F85_A2100ACTActCod[0];
            A2108ACTHisMes = P00F85_A2108ACTHisMes[0];
            A2107ACTHisAno = P00F85_A2107ACTHisAno[0];
            A2189ACTHisDepre = P00F85_A2189ACTHisDepre[0];
            AV45DAnterior = A2189ACTHisDepre;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      protected void S155( )
      {
         /* 'SALDOMENSUAL' Routine */
         returnInSub = false;
         AV85SaldoMes = 0.00m;
         /* Using cursor P00F86 */
         pr_default.execute(4, new Object[] {AV37Ano, AV68Mes, AV17ActCod, AV27ActItem});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A2104ActActItem = P00F86_A2104ActActItem[0];
            n2104ActActItem = P00F86_n2104ActActItem[0];
            A2100ACTActCod = P00F86_A2100ACTActCod[0];
            A2108ACTHisMes = P00F86_A2108ACTHisMes[0];
            A2107ACTHisAno = P00F86_A2107ACTHisAno[0];
            A2189ACTHisDepre = P00F86_A2189ACTHisDepre[0];
            AV59ImpDepre = A2189ACTHisDepre;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      protected void S125( )
      {
         /* 'REPARACIONES' Routine */
         returnInSub = false;
         AV24ACTDetValorReparacion = 0;
         AV23ACTDetValorCompras = 0;
         /* Using cursor P00F87 */
         pr_default.execute(5, new Object[] {AV17ActCod, AV19ACTDetFecIni, AV55FechaUlt});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A2204AMRepFec = P00F87_A2204AMRepFec[0];
            A2100ACTActCod = P00F87_A2100ACTActCod[0];
            A2209AMRepValor = P00F87_A2209AMRepValor[0];
            A2104ActActItem = P00F87_A2104ActActItem[0];
            n2104ActActItem = P00F87_n2104ActActItem[0];
            A2112AMRepCod = P00F87_A2112AMRepCod[0];
            AV24ACTDetValorReparacion = (decimal)(AV24ACTDetValorReparacion+((String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem))||P00F87_n2104ActActItem[0] ? NumberUtil.Round( (A2209AMRepValor*AV79Porcentaje)/ (decimal)(100), 2) : ((StringUtil.StrCmp(A2104ActActItem, AV11ActActItem)==0) ? A2209AMRepValor : (decimal)(0)))));
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /* Using cursor P00F88 */
         pr_default.execute(6, new Object[] {AV17ActCod, AV19ACTDetFecIni, AV55FechaUlt});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A2218ACTRevFec = P00F88_A2218ACTRevFec[0];
            A2100ACTActCod = P00F88_A2100ACTActCod[0];
            A2217ActRevCosto = P00F88_A2217ActRevCosto[0];
            A2104ActActItem = P00F88_A2104ActActItem[0];
            n2104ActActItem = P00F88_n2104ActActItem[0];
            A2113ACTRevCod = P00F88_A2113ACTRevCod[0];
            AV23ACTDetValorCompras = (decimal)(AV23ACTDetValorCompras+((String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem))||P00F88_n2104ActActItem[0] ? NumberUtil.Round( (A2217ActRevCosto*AV79Porcentaje)/ (decimal)(100), 2) : ((StringUtil.StrCmp(A2104ActActItem, AV11ActActItem)==0) ? A2217ActRevCosto : (decimal)(0)))));
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S135( )
      {
         /* 'BAJA' Routine */
         returnInSub = false;
         /* Using cursor P00F89 */
         pr_default.execute(7, new Object[] {AV17ActCod, AV55FechaUlt});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A2100ACTActCod = P00F89_A2100ACTActCod[0];
            A2175ACTABajFec = P00F89_A2175ACTABajFec[0];
            A2104ActActItem = P00F89_A2104ActActItem[0];
            n2104ActActItem = P00F89_n2104ActActItem[0];
            A2106ACTABajCod = P00F89_A2106ACTABajCod[0];
            AV51Estado = (String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem)) ? "Baja" : ((StringUtil.StrCmp(A2104ActActItem, AV27ActItem)==0) ? "Baja" : "Activo"));
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void HF80( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 693, Gx_line+24, 725, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 693, Gx_line+42, 737, Gx_line+56, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 693, Gx_line+6, 732, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 758, Gx_line+42, 797, Gx_line+57, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 739, Gx_line+24, 796, Gx_line+38, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 750, Gx_line+6, 797, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("COD. ACTIVO", 65, Gx_line+84, 120, Gx_line+94, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FECHA", 12, Gx_line+84, 40, Gx_line+94, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Empresa, "")), 8, Gx_line+14, 233, Gx_line+32, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50EmpRUC, "")), 8, Gx_line+31, 178, Gx_line+49, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77Periodo, "")), 267, Gx_line+46, 560, Gx_line+67, 1+256, 0, 0, 1) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("VALOR ACTIVO", 517, Gx_line+83, 579, Gx_line+93, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("VALOR EN LIBROS", 686, Gx_line+83, 763, Gx_line+93, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(56, Gx_line+74, 56, Gx_line+105, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(132, Gx_line+75, 132, Gx_line+105, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(496, Gx_line+74, 496, Gx_line+105, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(609, Gx_line+74, 609, Gx_line+104, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("CONCEPTO", 223, Gx_line+84, 269, Gx_line+94, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+74, 800, Gx_line+105, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94Titulo, "")), 217, Gx_line+18, 606, Gx_line+43, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("%", 629, Gx_line+83, 640, Gx_line+93, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(657, Gx_line+74, 657, Gx_line+104, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+105);
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
         AV49Empresa = "";
         AV86Session = context.GetSession();
         AV48EmpDir = "";
         AV50EmpRUC = "";
         AV82Ruta = "";
         AV67Logo = "";
         AV111Logo_GXI = "";
         AV94Titulo = "";
         AV39cMes = "";
         GXt_char1 = "";
         AV77Periodo = "";
         AV53FechaC = "";
         AV54FechaIni = DateTime.MinValue;
         AV55FechaUlt = DateTime.MinValue;
         GXt_date2 = DateTime.MinValue;
         AV92Tipo = "";
         scmdbuf = "";
         A426ACTClaCod = "";
         A2103ACTGrupCod = "";
         A2100ACTActCod = "";
         A2104ActActItem = "";
         P00F82_A2107ACTHisAno = new short[1] ;
         P00F82_A2184ACTClaDsc = new string[] {""} ;
         P00F82_A426ACTClaCod = new string[] {""} ;
         P00F82_A2108ACTHisMes = new short[1] ;
         P00F82_A2104ActActItem = new string[] {""} ;
         P00F82_n2104ActActItem = new bool[] {false} ;
         P00F82_A2100ACTActCod = new string[] {""} ;
         P00F82_A2103ACTGrupCod = new string[] {""} ;
         A2184ACTClaDsc = "";
         AV40Codigo = "";
         AV38CentroCosto = "";
         AV42CosDSc = "";
         P00F83_A2114ACTSGrupCod = new string[] {""} ;
         P00F83_A2108ACTHisMes = new short[1] ;
         P00F83_A2107ACTHisAno = new short[1] ;
         P00F83_A2104ActActItem = new string[] {""} ;
         P00F83_n2104ActActItem = new bool[] {false} ;
         P00F83_A2100ACTActCod = new string[] {""} ;
         P00F83_A2103ACTGrupCod = new string[] {""} ;
         P00F83_A426ACTClaCod = new string[] {""} ;
         P00F83_A2118ACTActCodEQV = new string[] {""} ;
         P00F83_A2155ACTSGrupDsc = new string[] {""} ;
         P00F83_A2122ACTActDsc = new string[] {""} ;
         P00F83_A2156ACTSGrupPor = new decimal[1] ;
         P00F83_A2143ACTDetFecIni = new DateTime[] {DateTime.MinValue} ;
         P00F83_A2150ACTDetValorNeto = new decimal[1] ;
         P00F83_A2152ACTDetValorResiduo = new decimal[1] ;
         P00F83_A2132ACTActOrd = new string[] {""} ;
         P00F83_A2123ACTActFech = new DateTime[] {DateTime.MinValue} ;
         P00F83_A2144ACTDetMarca = new string[] {""} ;
         P00F83_A2145ACTDetModelo = new string[] {""} ;
         P00F83_A2147ACTDetSerie = new string[] {""} ;
         A2114ACTSGrupCod = "";
         A2118ACTActCodEQV = "";
         A2155ACTSGrupDsc = "";
         A2122ACTActDsc = "";
         A2143ACTDetFecIni = DateTime.MinValue;
         A2132ACTActOrd = "";
         A2123ACTActFech = DateTime.MinValue;
         A2144ACTDetMarca = "";
         A2145ACTDetModelo = "";
         A2147ACTDetSerie = "";
         AV17ActCod = "";
         AV27ActItem = "";
         AV18ActCodEQV = "";
         AV28ACTSGrupDsc = "";
         AV25ActDsc = "";
         AV19ACTDetFecIni = DateTime.MinValue;
         AV51Estado = "";
         AV14ACTActOrd = "";
         AV10ACTActFech = DateTime.MinValue;
         AV20ACTDetMarca = "";
         AV21ACTDetModelo = "";
         AV22ACTDetSerie = "";
         P00F84_A2189ACTHisDepre = new decimal[1] ;
         P00F85_A2104ActActItem = new string[] {""} ;
         P00F85_n2104ActActItem = new bool[] {false} ;
         P00F85_A2100ACTActCod = new string[] {""} ;
         P00F85_A2108ACTHisMes = new short[1] ;
         P00F85_A2107ACTHisAno = new short[1] ;
         P00F85_A2189ACTHisDepre = new decimal[1] ;
         P00F86_A2104ActActItem = new string[] {""} ;
         P00F86_n2104ActActItem = new bool[] {false} ;
         P00F86_A2100ACTActCod = new string[] {""} ;
         P00F86_A2108ACTHisMes = new short[1] ;
         P00F86_A2107ACTHisAno = new short[1] ;
         P00F86_A2189ACTHisDepre = new decimal[1] ;
         P00F87_A2204AMRepFec = new DateTime[] {DateTime.MinValue} ;
         P00F87_A2100ACTActCod = new string[] {""} ;
         P00F87_A2209AMRepValor = new decimal[1] ;
         P00F87_A2104ActActItem = new string[] {""} ;
         P00F87_n2104ActActItem = new bool[] {false} ;
         P00F87_A2112AMRepCod = new string[] {""} ;
         A2204AMRepFec = DateTime.MinValue;
         A2112AMRepCod = "";
         P00F88_A2218ACTRevFec = new DateTime[] {DateTime.MinValue} ;
         P00F88_A2100ACTActCod = new string[] {""} ;
         P00F88_A2217ActRevCosto = new decimal[1] ;
         P00F88_A2104ActActItem = new string[] {""} ;
         P00F88_n2104ActActItem = new bool[] {false} ;
         P00F88_A2113ACTRevCod = new string[] {""} ;
         A2218ACTRevFec = DateTime.MinValue;
         A2113ACTRevCod = "";
         P00F89_A2100ACTActCod = new string[] {""} ;
         P00F89_A2175ACTABajFec = new DateTime[] {DateTime.MinValue} ;
         P00F89_A2104ActActItem = new string[] {""} ;
         P00F89_n2104ActActItem = new bool[] {false} ;
         P00F89_A2106ACTABajCod = new string[] {""} ;
         A2175ACTABajFec = DateTime.MinValue;
         A2106ACTABajCod = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.activosfijos.r_activosvalorlibrospdf__default(),
            new Object[][] {
                new Object[] {
               P00F82_A2107ACTHisAno, P00F82_A2184ACTClaDsc, P00F82_A426ACTClaCod, P00F82_A2108ACTHisMes, P00F82_A2104ActActItem, P00F82_A2100ACTActCod, P00F82_A2103ACTGrupCod
               }
               , new Object[] {
               P00F83_A2114ACTSGrupCod, P00F83_A2108ACTHisMes, P00F83_A2107ACTHisAno, P00F83_A2104ActActItem, P00F83_A2100ACTActCod, P00F83_A2103ACTGrupCod, P00F83_A426ACTClaCod, P00F83_A2118ACTActCodEQV, P00F83_A2155ACTSGrupDsc, P00F83_A2122ACTActDsc,
               P00F83_A2156ACTSGrupPor, P00F83_A2143ACTDetFecIni, P00F83_A2150ACTDetValorNeto, P00F83_A2152ACTDetValorResiduo, P00F83_A2132ACTActOrd, P00F83_A2123ACTActFech, P00F83_A2144ACTDetMarca, P00F83_A2145ACTDetModelo, P00F83_A2147ACTDetSerie
               }
               , new Object[] {
               P00F84_A2189ACTHisDepre
               }
               , new Object[] {
               P00F85_A2104ActActItem, P00F85_A2100ACTActCod, P00F85_A2108ACTHisMes, P00F85_A2107ACTHisAno, P00F85_A2189ACTHisDepre
               }
               , new Object[] {
               P00F86_A2104ActActItem, P00F86_A2100ACTActCod, P00F86_A2108ACTHisMes, P00F86_A2107ACTHisAno, P00F86_A2189ACTHisDepre
               }
               , new Object[] {
               P00F87_A2204AMRepFec, P00F87_A2100ACTActCod, P00F87_A2209AMRepValor, P00F87_A2104ActActItem, P00F87_n2104ActActItem, P00F87_A2112AMRepCod
               }
               , new Object[] {
               P00F88_A2218ACTRevFec, P00F88_A2100ACTActCod, P00F88_A2217ActRevCosto, P00F88_A2104ActActItem, P00F88_n2104ActActItem, P00F88_A2113ACTRevCod
               }
               , new Object[] {
               P00F89_A2100ACTActCod, P00F89_A2175ACTABajFec, P00F89_A2104ActActItem, P00F89_n2104ActActItem, P00F89_A2106ACTABajCod
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
      private short AV37Ano ;
      private short AV68Mes ;
      private short AV64jAnoAnt ;
      private short AV65jMesAnt ;
      private short A2108ACTHisMes ;
      private short A2107ACTHisAno ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal AV75nValor ;
      private decimal AV76nValorCalculo ;
      private decimal AV69nDAcumulada ;
      private decimal AV70nDAnterior ;
      private decimal AV72nImpLibro ;
      private decimal AV73nImpPorDepre ;
      private decimal AV71nImpDepre ;
      private decimal AV105TValor ;
      private decimal AV90TImpLibro ;
      private decimal A2156ACTSGrupPor ;
      private decimal A2150ACTDetValorNeto ;
      private decimal A2152ACTDetValorResiduo ;
      private decimal AV79Porcentaje ;
      private decimal AV107Valor ;
      private decimal AV24ACTDetValorReparacion ;
      private decimal AV23ACTDetValorCompras ;
      private decimal AV108ValorCalculo ;
      private decimal AV59ImpDepre ;
      private decimal AV60ImpLibro ;
      private decimal AV44DAcumulada ;
      private decimal AV61ImpPorDep ;
      private decimal AV45DAnterior ;
      private decimal AV106TValorCalculo ;
      private decimal AV87TDAcumulada ;
      private decimal AV88TDAnterior ;
      private decimal AV91TImpPorDepre ;
      private decimal AV89TImpDepre ;
      private decimal c2189ACTHisDepre ;
      private decimal A2189ACTHisDepre ;
      private decimal AV85SaldoMes ;
      private decimal A2209AMRepValor ;
      private decimal A2217ActRevCosto ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV49Empresa ;
      private string AV48EmpDir ;
      private string AV50EmpRUC ;
      private string AV82Ruta ;
      private string AV94Titulo ;
      private string AV39cMes ;
      private string GXt_char1 ;
      private string AV53FechaC ;
      private string AV92Tipo ;
      private string scmdbuf ;
      private string AV42CosDSc ;
      private string A2155ACTSGrupDsc ;
      private string AV28ACTSGrupDsc ;
      private string Gx_time ;
      private DateTime AV54FechaIni ;
      private DateTime AV55FechaUlt ;
      private DateTime GXt_date2 ;
      private DateTime A2143ACTDetFecIni ;
      private DateTime A2123ACTActFech ;
      private DateTime AV19ACTDetFecIni ;
      private DateTime AV10ACTActFech ;
      private DateTime A2204AMRepFec ;
      private DateTime A2218ACTRevFec ;
      private DateTime A2175ACTABajFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKF83 ;
      private bool n2104ActActItem ;
      private bool returnInSub ;
      private string AV16ACTClaCod ;
      private string AV26ACTGrupCod ;
      private string AV8ACTActCod ;
      private string AV11ActActItem ;
      private string AV111Logo_GXI ;
      private string AV77Periodo ;
      private string A426ACTClaCod ;
      private string A2103ACTGrupCod ;
      private string A2100ACTActCod ;
      private string A2104ActActItem ;
      private string A2184ACTClaDsc ;
      private string AV40Codigo ;
      private string AV38CentroCosto ;
      private string A2114ACTSGrupCod ;
      private string A2118ACTActCodEQV ;
      private string A2122ACTActDsc ;
      private string A2132ACTActOrd ;
      private string A2144ACTDetMarca ;
      private string A2145ACTDetModelo ;
      private string A2147ACTDetSerie ;
      private string AV17ActCod ;
      private string AV27ActItem ;
      private string AV18ActCodEQV ;
      private string AV25ActDsc ;
      private string AV51Estado ;
      private string AV14ACTActOrd ;
      private string AV20ACTDetMarca ;
      private string AV21ACTDetModelo ;
      private string AV22ACTDetSerie ;
      private string A2112AMRepCod ;
      private string A2113ACTRevCod ;
      private string A2106ACTABajCod ;
      private string AV67Logo ;
      private IGxSession AV86Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ACTClaCod ;
      private string aP1_ACTGrupCod ;
      private string aP2_ACTActCod ;
      private string aP3_ActActItem ;
      private short aP4_Ano ;
      private short aP5_Mes ;
      private IDataStoreProvider pr_default ;
      private short[] P00F82_A2107ACTHisAno ;
      private string[] P00F82_A2184ACTClaDsc ;
      private string[] P00F82_A426ACTClaCod ;
      private short[] P00F82_A2108ACTHisMes ;
      private string[] P00F82_A2104ActActItem ;
      private bool[] P00F82_n2104ActActItem ;
      private string[] P00F82_A2100ACTActCod ;
      private string[] P00F82_A2103ACTGrupCod ;
      private string[] P00F83_A2114ACTSGrupCod ;
      private short[] P00F83_A2108ACTHisMes ;
      private short[] P00F83_A2107ACTHisAno ;
      private string[] P00F83_A2104ActActItem ;
      private bool[] P00F83_n2104ActActItem ;
      private string[] P00F83_A2100ACTActCod ;
      private string[] P00F83_A2103ACTGrupCod ;
      private string[] P00F83_A426ACTClaCod ;
      private string[] P00F83_A2118ACTActCodEQV ;
      private string[] P00F83_A2155ACTSGrupDsc ;
      private string[] P00F83_A2122ACTActDsc ;
      private decimal[] P00F83_A2156ACTSGrupPor ;
      private DateTime[] P00F83_A2143ACTDetFecIni ;
      private decimal[] P00F83_A2150ACTDetValorNeto ;
      private decimal[] P00F83_A2152ACTDetValorResiduo ;
      private string[] P00F83_A2132ACTActOrd ;
      private DateTime[] P00F83_A2123ACTActFech ;
      private string[] P00F83_A2144ACTDetMarca ;
      private string[] P00F83_A2145ACTDetModelo ;
      private string[] P00F83_A2147ACTDetSerie ;
      private decimal[] P00F84_A2189ACTHisDepre ;
      private string[] P00F85_A2104ActActItem ;
      private bool[] P00F85_n2104ActActItem ;
      private string[] P00F85_A2100ACTActCod ;
      private short[] P00F85_A2108ACTHisMes ;
      private short[] P00F85_A2107ACTHisAno ;
      private decimal[] P00F85_A2189ACTHisDepre ;
      private string[] P00F86_A2104ActActItem ;
      private bool[] P00F86_n2104ActActItem ;
      private string[] P00F86_A2100ACTActCod ;
      private short[] P00F86_A2108ACTHisMes ;
      private short[] P00F86_A2107ACTHisAno ;
      private decimal[] P00F86_A2189ACTHisDepre ;
      private DateTime[] P00F87_A2204AMRepFec ;
      private string[] P00F87_A2100ACTActCod ;
      private decimal[] P00F87_A2209AMRepValor ;
      private string[] P00F87_A2104ActActItem ;
      private bool[] P00F87_n2104ActActItem ;
      private string[] P00F87_A2112AMRepCod ;
      private DateTime[] P00F88_A2218ACTRevFec ;
      private string[] P00F88_A2100ACTActCod ;
      private decimal[] P00F88_A2217ActRevCosto ;
      private string[] P00F88_A2104ActActItem ;
      private bool[] P00F88_n2104ActActItem ;
      private string[] P00F88_A2113ACTRevCod ;
      private string[] P00F89_A2100ACTActCod ;
      private DateTime[] P00F89_A2175ACTABajFec ;
      private string[] P00F89_A2104ActActItem ;
      private bool[] P00F89_n2104ActActItem ;
      private string[] P00F89_A2106ACTABajCod ;
   }

   public class r_activosvalorlibrospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00F82( IGxContext context ,
                                             string AV16ACTClaCod ,
                                             string AV26ACTGrupCod ,
                                             string AV8ACTActCod ,
                                             string AV11ActActItem ,
                                             short AV68Mes ,
                                             string A426ACTClaCod ,
                                             string A2103ACTGrupCod ,
                                             string A2100ACTActCod ,
                                             string A2104ActActItem ,
                                             short A2108ACTHisMes ,
                                             short A2107ACTHisAno ,
                                             short AV37Ano )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[ACTHisAno], T3.[ACTClaDsc], T2.[ACTClaCod], T1.[ACTHisMes], T1.[ActActItem], T1.[ACTActCod], T2.[ACTGrupCod] FROM (([ACTCOSTODEP] T1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod]) INNER JOIN [ACTCLASE] T3 ON T3.[ACTClaCod] = T2.[ACTClaCod])";
         AddWhere(sWhereString, "(T1.[ACTHisAno] = @AV37Ano)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ACTClaCod)) )
         {
            AddWhere(sWhereString, "(T2.[ACTClaCod] = @AV16ACTClaCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ACTGrupCod)) )
         {
            AddWhere(sWhereString, "(T2.[ACTGrupCod] = @AV26ACTGrupCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8ACTActCod)) )
         {
            AddWhere(sWhereString, "(T1.[ACTActCod] = @AV8ACTActCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11ActActItem)) )
         {
            AddWhere(sWhereString, "(T1.[ActActItem] = @AV11ActActItem)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV68Mes) )
         {
            AddWhere(sWhereString, "(T1.[ACTHisMes] = @AV68Mes)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[ACTClaCod], T3.[ACTClaDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00F83( IGxContext context ,
                                             string AV26ACTGrupCod ,
                                             string AV8ACTActCod ,
                                             string AV11ActActItem ,
                                             short AV68Mes ,
                                             string A2103ACTGrupCod ,
                                             string A2100ACTActCod ,
                                             string A2104ActActItem ,
                                             short A2108ACTHisMes ,
                                             string A426ACTClaCod ,
                                             string AV40Codigo ,
                                             short A2107ACTHisAno ,
                                             short AV37Ano )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[6];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T3.[ACTSGrupCod], T1.[ACTHisMes], T1.[ACTHisAno], T1.[ActActItem], T1.[ACTActCod], T2.[ACTGrupCod], T2.[ACTClaCod], T2.[ACTActCodEQV], T4.[ACTSGrupDsc], T2.[ACTActDsc], T4.[ACTSGrupPor], T3.[ACTDetFecIni], T3.[ACTDetValorNeto], T3.[ACTDetValorResiduo], T2.[ACTActOrd], T2.[ACTActFech], T3.[ACTDetMarca], T3.[ACTDetModelo], T3.[ACTDetSerie] FROM ((([ACTCOSTODEP] T1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod]) INNER JOIN [ACTACTIVOSDET] T3 ON T3.[ACTActCod] = T1.[ACTActCod] AND T3.[ActActItem] = T1.[ActActItem]) LEFT JOIN [ACTSUBGRUPO] T4 ON T4.[ACTClaCod] = T2.[ACTClaCod] AND T4.[ACTGrupCod] = T2.[ACTGrupCod] AND T4.[ACTSGrupCod] = T3.[ACTSGrupCod])";
         AddWhere(sWhereString, "(T2.[ACTClaCod] = @AV40Codigo)");
         AddWhere(sWhereString, "(T1.[ACTHisAno] = @AV37Ano)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ACTGrupCod)) )
         {
            AddWhere(sWhereString, "(T2.[ACTGrupCod] = @AV26ACTGrupCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8ACTActCod)) )
         {
            AddWhere(sWhereString, "(T1.[ACTActCod] = @AV8ACTActCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11ActActItem)) )
         {
            AddWhere(sWhereString, "(T1.[ActActItem] = @AV11ActActItem)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (0==AV68Mes) )
         {
            AddWhere(sWhereString, "(T1.[ACTHisMes] = @AV68Mes)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ACTActCod], T1.[ActActItem]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00F82(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
               case 1 :
                     return conditional_P00F83(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00F84;
          prmP00F84 = new Object[] {
          new ParDef("@AV17ActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV27ActItem",GXType.NVarChar,5,0) ,
          new ParDef("@AV54FechaIni",GXType.Date,8,0)
          };
          Object[] prmP00F85;
          prmP00F85 = new Object[] {
          new ParDef("@AV64jAnoAnt",GXType.Int16,4,0) ,
          new ParDef("@AV65jMesAnt",GXType.Int16,2,0) ,
          new ParDef("@AV17ActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV27ActItem",GXType.NVarChar,5,0)
          };
          Object[] prmP00F86;
          prmP00F86 = new Object[] {
          new ParDef("@AV37Ano",GXType.Int16,4,0) ,
          new ParDef("@AV68Mes",GXType.Int16,2,0) ,
          new ParDef("@AV17ActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV27ActItem",GXType.NVarChar,5,0)
          };
          Object[] prmP00F87;
          prmP00F87 = new Object[] {
          new ParDef("@AV17ActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV19ACTDetFecIni",GXType.Date,8,0) ,
          new ParDef("@AV55FechaUlt",GXType.Date,8,0)
          };
          Object[] prmP00F88;
          prmP00F88 = new Object[] {
          new ParDef("@AV17ActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV19ACTDetFecIni",GXType.Date,8,0) ,
          new ParDef("@AV55FechaUlt",GXType.Date,8,0)
          };
          Object[] prmP00F89;
          prmP00F89 = new Object[] {
          new ParDef("@AV17ActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV55FechaUlt",GXType.Date,8,0)
          };
          Object[] prmP00F82;
          prmP00F82 = new Object[] {
          new ParDef("@AV37Ano",GXType.Int16,4,0) ,
          new ParDef("@AV16ACTClaCod",GXType.NVarChar,5,0) ,
          new ParDef("@AV26ACTGrupCod",GXType.NVarChar,5,0) ,
          new ParDef("@AV8ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV11ActActItem",GXType.NVarChar,5,0) ,
          new ParDef("@AV68Mes",GXType.Int16,2,0)
          };
          Object[] prmP00F83;
          prmP00F83 = new Object[] {
          new ParDef("@AV40Codigo",GXType.NVarChar,20,0) ,
          new ParDef("@AV37Ano",GXType.Int16,4,0) ,
          new ParDef("@AV26ACTGrupCod",GXType.NVarChar,5,0) ,
          new ParDef("@AV8ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV11ActActItem",GXType.NVarChar,5,0) ,
          new ParDef("@AV68Mes",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00F82", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F82,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F83", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F83,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F84", "SELECT SUM([ACTHisDepre]) FROM [ACTCOSTODEP] WHERE ([ACTActCod] = @AV17ActCod and [ActActItem] = @AV27ActItem) AND ([ActHisFec] < @AV54FechaIni) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F84,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F85", "SELECT [ActActItem], [ACTActCod], [ACTHisMes], [ACTHisAno], [ACTHisDepre] FROM [ACTCOSTODEP] WHERE [ACTHisAno] = @AV64jAnoAnt and [ACTHisMes] = @AV65jMesAnt and [ACTActCod] = @AV17ActCod and [ActActItem] = @AV27ActItem ORDER BY [ACTHisAno], [ACTHisMes], [ACTActCod], [ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F85,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F86", "SELECT [ActActItem], [ACTActCod], [ACTHisMes], [ACTHisAno], [ACTHisDepre] FROM [ACTCOSTODEP] WHERE [ACTHisAno] = @AV37Ano and [ACTHisMes] = @AV68Mes and [ACTActCod] = @AV17ActCod and [ActActItem] = @AV27ActItem ORDER BY [ACTHisAno], [ACTHisMes], [ACTActCod], [ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F86,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F87", "SELECT [AMRepFec], [ACTActCod], [AMRepValor], [ActActItem], [AMRepCod] FROM [ACTMOVREPARACION] WHERE ([ACTActCod] = @AV17ActCod) AND ([AMRepFec] > @AV19ACTDetFecIni) AND ([AMRepFec] <= @AV55FechaUlt) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F87,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F88", "SELECT [ACTRevFec], [ACTActCod], [ActRevCosto], [ActActItem], [ACTRevCod] FROM [ACTRevaluacion] WHERE ([ACTActCod] = @AV17ActCod) AND ([ACTRevFec] > @AV19ACTDetFecIni) AND ([ACTRevFec] <= @AV55FechaUlt) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F88,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F89", "SELECT [ACTActCod], [ACTABajFec], [ActActItem], [ACTABajCod] FROM [ACTBAJAACTIVO] WHERE ([ACTActCod] = @AV17ActCod) AND ([ACTABajFec] <= @AV55FechaUlt) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F89,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                ((string[]) buf[17])[0] = rslt.getVarchar(18);
                ((string[]) buf[18])[0] = rslt.getVarchar(19);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 5 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
             case 6 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
