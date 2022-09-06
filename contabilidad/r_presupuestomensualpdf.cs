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
   public class r_presupuestomensualpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_presupuestomensualpdf.aspx")), "contabilidad.r_presupuestomensualpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_presupuestomensualpdf.aspx")))) ;
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
                  AV40Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
                  AV20CBTipPre = (int)(NumberUtil.Val( GetPar( "CBTipPre"), "."));
                  AV50TipoDetalle = GetPar( "TipoDetalle");
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

      public r_presupuestomensualpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_presupuestomensualpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref int aP2_CBTipPre ,
                           ref string aP3_TipoDetalle )
      {
         this.AV11Ano = aP0_Ano;
         this.AV40Mes = aP1_Mes;
         this.AV20CBTipPre = aP2_CBTipPre;
         this.AV50TipoDetalle = aP3_TipoDetalle;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV40Mes;
         aP2_CBTipPre=this.AV20CBTipPre;
         aP3_TipoDetalle=this.AV50TipoDetalle;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                ref int aP2_CBTipPre )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_CBTipPre, ref aP3_TipoDetalle);
         return AV50TipoDetalle ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref int aP2_CBTipPre ,
                                 ref string aP3_TipoDetalle )
      {
         r_presupuestomensualpdf objr_presupuestomensualpdf;
         objr_presupuestomensualpdf = new r_presupuestomensualpdf();
         objr_presupuestomensualpdf.AV11Ano = aP0_Ano;
         objr_presupuestomensualpdf.AV40Mes = aP1_Mes;
         objr_presupuestomensualpdf.AV20CBTipPre = aP2_CBTipPre;
         objr_presupuestomensualpdf.AV50TipoDetalle = aP3_TipoDetalle;
         objr_presupuestomensualpdf.context.SetSubmitInitialConfig(context);
         objr_presupuestomensualpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_presupuestomensualpdf);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV40Mes;
         aP2_CBTipPre=this.AV20CBTipPre;
         aP3_TipoDetalle=this.AV50TipoDetalle;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_presupuestomensualpdf)stateInfo).executePrivate();
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
            AV24Empresa = AV46Session.Get("Empresa");
            AV23EmpDir = AV46Session.Get("EmpDir");
            AV25EmpRUC = AV46Session.Get("EmpRUC");
            AV43Ruta = AV46Session.Get("RUTA") + "/Logo.jpg";
            AV39Logo = AV43Ruta;
            AV59Logo_GXI = GXDbFile.PathToUrl( AV43Ruta);
            GXt_char1 = AV22cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV40Mes, out  GXt_char1) ;
            AV22cMes = GXt_char1;
            AV29FechaIni = "01/01/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV27FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV40Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV28FechaD = context.localUtil.CToD( AV27FechaC, 2);
            GXt_date2 = AV28FechaD;
            new GeneXus.Programs.generales.pobtieneultimodiames(context ).execute(  AV28FechaD, out  GXt_date2) ;
            AV28FechaD = GXt_date2;
            AV42Periodo = "Del : " + AV29FechaIni + "  al : " + context.localUtil.DToC( AV28FechaD, 2, "/");
            /* Using cursor P00CU2 */
            pr_default.execute(0, new Object[] {AV20CBTipPre});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A2280CBTipPre = P00CU2_A2280CBTipPre[0];
               A2291CBTipPreDsc = P00CU2_A2291CBTipPreDsc[0];
               A180MonCod = P00CU2_A180MonCod[0];
               AV52Titulo = StringUtil.Trim( A2291CBTipPreDsc);
               AV41MonCod = A180MonCod;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV30i = 1;
            AV51TipoPresupuesto = "";
            while ( AV30i <= 2 )
            {
               if ( AV30i == 1 )
               {
                  AV47Tip = "I";
                  AV51TipoPresupuesto = "INGRESO";
               }
               if ( AV30i == 2 )
               {
                  AV47Tip = "E";
                  AV51TipoPresupuesto = "EGRESO";
               }
               HCU0( false, 20) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TipoPresupuesto, "")), 6, Gx_line+1, 445, Gx_line+19, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
               AV38ImpTPre = 0.00m;
               AV36ImpTEje = 0.00m;
               AV35ImpTDif = 0.00m;
               /* Using cursor P00CU3 */
               pr_default.execute(1, new Object[] {AV20CBTipPre, AV47Tip});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A2281CBTipTipo = P00CU3_A2281CBTipTipo[0];
                  A2280CBTipPre = P00CU3_A2280CBTipPre[0];
                  A2282CBLinPre = P00CU3_A2282CBLinPre[0];
                  A2289CBLinPreDsc = P00CU3_A2289CBLinPreDsc[0];
                  AV12CBLinPre = A2282CBLinPre;
                  AV13CBLinPreDsc = A2289CBLinPreDsc;
                  AV18CBRubPre = 0;
                  AV34ImpPre = 0.00m;
                  AV32ImpEje = 0.00m;
                  AV31ImpDif = 0.00m;
                  AV33ImpPor = 0.00m;
                  /* Execute user subroutine: 'SUBTOTALLINEA' */
                  S131 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     this.cleanup();
                     if (true) return;
                  }
                  AV31ImpDif = (decimal)(AV34ImpPre-AV32ImpEje);
                  AV33ImpPor = ((Convert.ToDecimal(0)==AV34ImpPre) ? (decimal)(0) : NumberUtil.Round( (AV32ImpEje/ (decimal)(AV34ImpPre))*100, 2));
                  HCU0( false, 19) ;
                  getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13CBLinPreDsc, "")), 28, Gx_line+2, 358, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34ImpPre, "ZZZZZZ,ZZZ,ZZ9.99")), 358, Gx_line+2, 483, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32ImpEje, "ZZZZZZ,ZZZ,ZZ9.99")), 470, Gx_line+2, 595, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31ImpDif, "ZZZZZZ,ZZZ,ZZ9.99")), 564, Gx_line+2, 689, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33ImpPor, "ZZ9.99")), 724, Gx_line+2, 769, Gx_line+18, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
                  AV38ImpTPre = (decimal)(AV38ImpTPre+AV34ImpPre);
                  AV36ImpTEje = (decimal)(AV36ImpTEje+AV32ImpEje);
                  AV35ImpTDif = (decimal)(AV35ImpTDif+AV31ImpDif);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TipoDetalle)) )
                  {
                     /* Execute user subroutine: 'RUBROS' */
                     S111 ();
                     if ( returnInSub )
                     {
                        pr_default.close(1);
                        this.cleanup();
                        if (true) return;
                     }
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               if ( AV30i == 1 )
               {
                  AV51TipoPresupuesto = "TOTAL INGRESO";
               }
               if ( AV30i == 2 )
               {
                  AV51TipoPresupuesto = "TOTAL EGRESO";
               }
               AV35ImpTDif = (decimal)(AV38ImpTPre-AV36ImpTEje);
               AV37ImpTPor = ((Convert.ToDecimal(0)==AV38ImpTPre) ? (decimal)(0) : NumberUtil.Round( (AV36ImpTEje/ (decimal)(AV38ImpTPre))*100, 2));
               AV30i = (short)(AV30i+1);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HCU0( true, 0) ;
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
         /* 'RUBROS' Routine */
         returnInSub = false;
         /* Using cursor P00CU4 */
         pr_default.execute(2, new Object[] {AV20CBTipPre, AV47Tip, AV12CBLinPre});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A2282CBLinPre = P00CU4_A2282CBLinPre[0];
            A2281CBTipTipo = P00CU4_A2281CBTipTipo[0];
            A2280CBTipPre = P00CU4_A2280CBTipPre[0];
            A2283CBRubPre = P00CU4_A2283CBRubPre[0];
            A2293CBRubPreDsc = P00CU4_A2293CBRubPreDsc[0];
            AV18CBRubPre = A2283CBRubPre;
            AV19CBRubPreDsc = A2293CBRubPreDsc;
            AV17CBRImpPre = 0.00m;
            AV15CBRImpEje = 0.00m;
            AV14CBRImpDif = 0.00m;
            AV16CBRImpPor = 0.00m;
            /* Execute user subroutine: 'SUBTOTALRUBROS' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            AV14CBRImpDif = (decimal)(AV17CBRImpPre-AV15CBRImpEje);
            AV16CBRImpPor = ((Convert.ToDecimal(0)==AV17CBRImpPre) ? (decimal)(0) : NumberUtil.Round( (AV15CBRImpEje/ (decimal)(AV17CBRImpPre))*100, 2));
            HCU0( false, 22) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CBRubPreDsc, "")), 53, Gx_line+3, 383, Gx_line+18, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16CBRImpPor, "ZZ9.99")), 730, Gx_line+3, 769, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV14CBRImpDif, "ZZZZZZ,ZZZ,ZZ9.99")), 582, Gx_line+3, 689, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV15CBRImpEje, "ZZZZZZ,ZZZ,ZZ9.99")), 488, Gx_line+3, 595, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17CBRImpPre, "ZZZZZZ,ZZZ,ZZ9.99")), 376, Gx_line+3, 483, Gx_line+18, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+22);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S131( )
      {
         /* 'SUBTOTALLINEA' Routine */
         returnInSub = false;
         /* Using cursor P00CU5 */
         pr_default.execute(3, new Object[] {AV20CBTipPre, AV47Tip, AV12CBLinPre, AV11Ano});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A2285CBRubPreAno = P00CU5_A2285CBRubPreAno[0];
            A2282CBLinPre = P00CU5_A2282CBLinPre[0];
            A2281CBTipTipo = P00CU5_A2281CBTipTipo[0];
            A2280CBTipPre = P00CU5_A2280CBTipPre[0];
            A2296CBRubPreEne = P00CU5_A2296CBRubPreEne[0];
            A2297CBRubPreFeb = P00CU5_A2297CBRubPreFeb[0];
            A2298CBRubPreMar = P00CU5_A2298CBRubPreMar[0];
            A2299CBRubPreAbr = P00CU5_A2299CBRubPreAbr[0];
            A2300CBRubPreMay = P00CU5_A2300CBRubPreMay[0];
            A2301CBRubPreJun = P00CU5_A2301CBRubPreJun[0];
            A2302CBRubPreJul = P00CU5_A2302CBRubPreJul[0];
            A2303CBRubPreAgo = P00CU5_A2303CBRubPreAgo[0];
            A2304CBRubPreSep = P00CU5_A2304CBRubPreSep[0];
            A2305CBRubPreOct = P00CU5_A2305CBRubPreOct[0];
            A2306CBRubPreNov = P00CU5_A2306CBRubPreNov[0];
            A2307CBRubPreDic = P00CU5_A2307CBRubPreDic[0];
            A2283CBRubPre = P00CU5_A2283CBRubPre[0];
            if ( AV40Mes == 1 )
            {
               AV34ImpPre = (decimal)(AV34ImpPre+A2296CBRubPreEne);
            }
            if ( AV40Mes == 2 )
            {
               AV34ImpPre = (decimal)(AV34ImpPre+A2297CBRubPreFeb);
            }
            if ( AV40Mes == 3 )
            {
               AV34ImpPre = (decimal)(AV34ImpPre+A2298CBRubPreMar);
            }
            if ( AV40Mes == 4 )
            {
               AV34ImpPre = (decimal)(AV34ImpPre+A2299CBRubPreAbr);
            }
            if ( AV40Mes == 5 )
            {
               AV34ImpPre = (decimal)(AV34ImpPre+A2300CBRubPreMay);
            }
            if ( AV40Mes == 6 )
            {
               AV34ImpPre = (decimal)(AV34ImpPre+A2301CBRubPreJun);
            }
            if ( AV40Mes == 7 )
            {
               AV34ImpPre = (decimal)(AV34ImpPre+A2302CBRubPreJul);
            }
            if ( AV40Mes == 8 )
            {
               AV34ImpPre = (decimal)(AV34ImpPre+A2303CBRubPreAgo);
            }
            if ( AV40Mes == 9 )
            {
               AV34ImpPre = (decimal)(AV34ImpPre+A2304CBRubPreSep);
            }
            if ( AV40Mes == 10 )
            {
               AV34ImpPre = (decimal)(AV34ImpPre+A2305CBRubPreOct);
            }
            if ( AV40Mes == 11 )
            {
               AV34ImpPre = (decimal)(AV34ImpPre+A2306CBRubPreNov);
            }
            if ( AV40Mes == 12 )
            {
               AV34ImpPre = (decimal)(AV34ImpPre+A2307CBRubPreDic);
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV32ImpEje = 0.00m;
         /* Using cursor P00CU6 */
         pr_default.execute(4, new Object[] {AV20CBTipPre, AV47Tip, AV12CBLinPre});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A2282CBLinPre = P00CU6_A2282CBLinPre[0];
            A2281CBTipTipo = P00CU6_A2281CBTipTipo[0];
            A2280CBTipPre = P00CU6_A2280CBTipPre[0];
            A91CueCod = P00CU6_A91CueCod[0];
            A79COSCod = P00CU6_A79COSCod[0];
            n79COSCod = P00CU6_n79COSCod[0];
            A2283CBRubPre = P00CU6_A2283CBRubPre[0];
            A2284CBRubDItem = P00CU6_A2284CBRubDItem[0];
            AV9CueCod = A91CueCod;
            AV8CosCod = A79COSCod;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S147 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            AV32ImpEje = (decimal)(AV32ImpEje+AV10Saldo);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S125( )
      {
         /* 'SUBTOTALRUBROS' Routine */
         returnInSub = false;
         /* Using cursor P00CU7 */
         pr_default.execute(5, new Object[] {AV20CBTipPre, AV47Tip, AV12CBLinPre, AV18CBRubPre, AV11Ano});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A2285CBRubPreAno = P00CU7_A2285CBRubPreAno[0];
            A2283CBRubPre = P00CU7_A2283CBRubPre[0];
            A2282CBLinPre = P00CU7_A2282CBLinPre[0];
            A2281CBTipTipo = P00CU7_A2281CBTipTipo[0];
            A2280CBTipPre = P00CU7_A2280CBTipPre[0];
            A2296CBRubPreEne = P00CU7_A2296CBRubPreEne[0];
            A2297CBRubPreFeb = P00CU7_A2297CBRubPreFeb[0];
            A2298CBRubPreMar = P00CU7_A2298CBRubPreMar[0];
            A2299CBRubPreAbr = P00CU7_A2299CBRubPreAbr[0];
            A2300CBRubPreMay = P00CU7_A2300CBRubPreMay[0];
            A2301CBRubPreJun = P00CU7_A2301CBRubPreJun[0];
            A2302CBRubPreJul = P00CU7_A2302CBRubPreJul[0];
            A2303CBRubPreAgo = P00CU7_A2303CBRubPreAgo[0];
            A2304CBRubPreSep = P00CU7_A2304CBRubPreSep[0];
            A2305CBRubPreOct = P00CU7_A2305CBRubPreOct[0];
            A2306CBRubPreNov = P00CU7_A2306CBRubPreNov[0];
            A2307CBRubPreDic = P00CU7_A2307CBRubPreDic[0];
            if ( AV40Mes == 1 )
            {
               AV17CBRImpPre = (decimal)(AV17CBRImpPre+A2296CBRubPreEne);
            }
            if ( AV40Mes == 2 )
            {
               AV17CBRImpPre = (decimal)(AV17CBRImpPre+A2297CBRubPreFeb);
            }
            if ( AV40Mes == 3 )
            {
               AV17CBRImpPre = (decimal)(AV17CBRImpPre+A2298CBRubPreMar);
            }
            if ( AV40Mes == 4 )
            {
               AV17CBRImpPre = (decimal)(AV17CBRImpPre+A2299CBRubPreAbr);
            }
            if ( AV40Mes == 5 )
            {
               AV17CBRImpPre = (decimal)(AV17CBRImpPre+A2300CBRubPreMay);
            }
            if ( AV40Mes == 6 )
            {
               AV17CBRImpPre = (decimal)(AV17CBRImpPre+A2301CBRubPreJun);
            }
            if ( AV40Mes == 7 )
            {
               AV17CBRImpPre = (decimal)(AV17CBRImpPre+A2302CBRubPreJul);
            }
            if ( AV40Mes == 8 )
            {
               AV17CBRImpPre = (decimal)(AV17CBRImpPre+A2303CBRubPreAgo);
            }
            if ( AV40Mes == 9 )
            {
               AV17CBRImpPre = (decimal)(AV17CBRImpPre+A2304CBRubPreSep);
            }
            if ( AV40Mes == 10 )
            {
               AV17CBRImpPre = (decimal)(AV17CBRImpPre+A2305CBRubPreOct);
            }
            if ( AV40Mes == 11 )
            {
               AV17CBRImpPre = (decimal)(AV17CBRImpPre+A2306CBRubPreNov);
            }
            if ( AV40Mes == 12 )
            {
               AV17CBRImpPre = (decimal)(AV17CBRImpPre+A2307CBRubPreDic);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
         /* Using cursor P00CU8 */
         pr_default.execute(6, new Object[] {AV20CBTipPre, AV47Tip, AV12CBLinPre, AV18CBRubPre});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A2283CBRubPre = P00CU8_A2283CBRubPre[0];
            A2282CBLinPre = P00CU8_A2282CBLinPre[0];
            A2281CBTipTipo = P00CU8_A2281CBTipTipo[0];
            A2280CBTipPre = P00CU8_A2280CBTipPre[0];
            A91CueCod = P00CU8_A91CueCod[0];
            A79COSCod = P00CU8_A79COSCod[0];
            n79COSCod = P00CU8_n79COSCod[0];
            A2284CBRubDItem = P00CU8_A2284CBRubDItem[0];
            AV9CueCod = A91CueCod;
            AV8CosCod = A79COSCod;
            AV15CBRImpEje = 0.00m;
            /* Execute user subroutine: 'MOVIMIENTOCUENTA' */
            S147 ();
            if ( returnInSub )
            {
               pr_default.close(6);
               returnInSub = true;
               if (true) return;
            }
            AV15CBRImpEje = AV10Saldo;
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S147( )
      {
         /* 'MOVIMIENTOCUENTA' Routine */
         returnInSub = false;
         AV10Saldo = 0.00m;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV8CosCod ,
                                              A79COSCod ,
                                              A2077VouSts ,
                                              AV11Ano ,
                                              AV40Mes ,
                                              AV9CueCod ,
                                              A127VouAno ,
                                              A128VouMes ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00CU9 */
         pr_default.execute(7, new Object[] {AV11Ano, AV40Mes, AV9CueCod, AV8CosCod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A126TASICod = P00CU9_A126TASICod[0];
            A129VouNum = P00CU9_A129VouNum[0];
            A2077VouSts = P00CU9_A2077VouSts[0];
            A79COSCod = P00CU9_A79COSCod[0];
            n79COSCod = P00CU9_n79COSCod[0];
            A91CueCod = P00CU9_A91CueCod[0];
            A128VouMes = P00CU9_A128VouMes[0];
            A127VouAno = P00CU9_A127VouAno[0];
            A864CueMon = P00CU9_A864CueMon[0];
            A2056VouDHabO = P00CU9_A2056VouDHabO[0];
            A2052VouDDebO = P00CU9_A2052VouDDebO[0];
            A2069VouDTcmb = P00CU9_A2069VouDTcmb[0];
            A2055VouDHab = P00CU9_A2055VouDHab[0];
            A2051VouDDeb = P00CU9_A2051VouDDeb[0];
            A130VouDSec = P00CU9_A130VouDSec[0];
            A864CueMon = P00CU9_A864CueMon[0];
            A2077VouSts = P00CU9_A2077VouSts[0];
            AV56CueMon = A864CueMon;
            if ( AV41MonCod == 1 )
            {
               AV10Saldo = (decimal)(AV10Saldo+((A2052VouDDebO-A2056VouDHabO)));
            }
            else
            {
               AV10Saldo = (decimal)(AV10Saldo+(((AV56CueMon==1) ? (A2052VouDDebO-A2056VouDHabO) : NumberUtil.Round( (A2051VouDDeb-A2055VouDHab)/ (decimal)(A2069VouDTcmb), 2))));
            }
            pr_default.readNext(7);
         }
         pr_default.close(7);
         AV10Saldo = ((AV10Saldo<Convert.ToDecimal(0)) ? AV10Saldo*-1 : AV10Saldo);
      }

      protected void HCU0( bool bFoot ,
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
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV39Logo)) ? AV59Logo_GXI : AV39Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 8, Gx_line+2, 159, Gx_line+71) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Empresa, "")), 10, Gx_line+94, 316, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25EmpRUC, "")), 10, Gx_line+76, 148, Gx_line+94, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha:", 683, Gx_line+17, 722, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 735, Gx_line+17, 782, Gx_line+32, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hora:", 683, Gx_line+35, 715, Gx_line+49, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 721, Gx_line+35, 781, Gx_line+49, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 744, Gx_line+55, 783, Gx_line+70, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 683, Gx_line+55, 727, Gx_line+69, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PRESUPUESTO", 353, Gx_line+11, 467, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Año :", 269, Gx_line+60, 315, Gx_line+80, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Mes :", 381, Gx_line+60, 427, Gx_line+80, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11Ano), "ZZZ9")), 329, Gx_line+60, 368, Gx_line+81, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22cMes, "")), 448, Gx_line+60, 558, Gx_line+81, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Titulo, "")), 190, Gx_line+34, 629, Gx_line+55, 1+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+113);
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Presupuestado", 394, Gx_line+7, 484, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Ejecutado", 535, Gx_line+7, 594, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Diferencia", 626, Gx_line+7, 686, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText("%", 744, Gx_line+7, 759, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Linea", 20, Gx_line+7, 52, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+0, 796, Gx_line+27, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+27);
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
         AV24Empresa = "";
         AV46Session = context.GetSession();
         AV23EmpDir = "";
         AV25EmpRUC = "";
         AV43Ruta = "";
         AV39Logo = "";
         AV59Logo_GXI = "";
         AV22cMes = "";
         GXt_char1 = "";
         AV29FechaIni = "";
         AV27FechaC = "";
         AV28FechaD = DateTime.MinValue;
         GXt_date2 = DateTime.MinValue;
         AV42Periodo = "";
         scmdbuf = "";
         P00CU2_A2280CBTipPre = new int[1] ;
         P00CU2_A2291CBTipPreDsc = new string[] {""} ;
         P00CU2_A180MonCod = new int[1] ;
         A2291CBTipPreDsc = "";
         AV52Titulo = "";
         AV51TipoPresupuesto = "";
         AV47Tip = "";
         P00CU3_A2281CBTipTipo = new string[] {""} ;
         P00CU3_A2280CBTipPre = new int[1] ;
         P00CU3_A2282CBLinPre = new int[1] ;
         P00CU3_A2289CBLinPreDsc = new string[] {""} ;
         A2281CBTipTipo = "";
         A2289CBLinPreDsc = "";
         AV13CBLinPreDsc = "";
         P00CU4_A2282CBLinPre = new int[1] ;
         P00CU4_A2281CBTipTipo = new string[] {""} ;
         P00CU4_A2280CBTipPre = new int[1] ;
         P00CU4_A2283CBRubPre = new int[1] ;
         P00CU4_A2293CBRubPreDsc = new string[] {""} ;
         A2293CBRubPreDsc = "";
         AV19CBRubPreDsc = "";
         P00CU5_A2285CBRubPreAno = new short[1] ;
         P00CU5_A2282CBLinPre = new int[1] ;
         P00CU5_A2281CBTipTipo = new string[] {""} ;
         P00CU5_A2280CBTipPre = new int[1] ;
         P00CU5_A2296CBRubPreEne = new decimal[1] ;
         P00CU5_A2297CBRubPreFeb = new decimal[1] ;
         P00CU5_A2298CBRubPreMar = new decimal[1] ;
         P00CU5_A2299CBRubPreAbr = new decimal[1] ;
         P00CU5_A2300CBRubPreMay = new decimal[1] ;
         P00CU5_A2301CBRubPreJun = new decimal[1] ;
         P00CU5_A2302CBRubPreJul = new decimal[1] ;
         P00CU5_A2303CBRubPreAgo = new decimal[1] ;
         P00CU5_A2304CBRubPreSep = new decimal[1] ;
         P00CU5_A2305CBRubPreOct = new decimal[1] ;
         P00CU5_A2306CBRubPreNov = new decimal[1] ;
         P00CU5_A2307CBRubPreDic = new decimal[1] ;
         P00CU5_A2283CBRubPre = new int[1] ;
         P00CU6_A2282CBLinPre = new int[1] ;
         P00CU6_A2281CBTipTipo = new string[] {""} ;
         P00CU6_A2280CBTipPre = new int[1] ;
         P00CU6_A91CueCod = new string[] {""} ;
         P00CU6_A79COSCod = new string[] {""} ;
         P00CU6_n79COSCod = new bool[] {false} ;
         P00CU6_A2283CBRubPre = new int[1] ;
         P00CU6_A2284CBRubDItem = new int[1] ;
         A91CueCod = "";
         A79COSCod = "";
         AV9CueCod = "";
         AV8CosCod = "";
         P00CU7_A2285CBRubPreAno = new short[1] ;
         P00CU7_A2283CBRubPre = new int[1] ;
         P00CU7_A2282CBLinPre = new int[1] ;
         P00CU7_A2281CBTipTipo = new string[] {""} ;
         P00CU7_A2280CBTipPre = new int[1] ;
         P00CU7_A2296CBRubPreEne = new decimal[1] ;
         P00CU7_A2297CBRubPreFeb = new decimal[1] ;
         P00CU7_A2298CBRubPreMar = new decimal[1] ;
         P00CU7_A2299CBRubPreAbr = new decimal[1] ;
         P00CU7_A2300CBRubPreMay = new decimal[1] ;
         P00CU7_A2301CBRubPreJun = new decimal[1] ;
         P00CU7_A2302CBRubPreJul = new decimal[1] ;
         P00CU7_A2303CBRubPreAgo = new decimal[1] ;
         P00CU7_A2304CBRubPreSep = new decimal[1] ;
         P00CU7_A2305CBRubPreOct = new decimal[1] ;
         P00CU7_A2306CBRubPreNov = new decimal[1] ;
         P00CU7_A2307CBRubPreDic = new decimal[1] ;
         P00CU8_A2283CBRubPre = new int[1] ;
         P00CU8_A2282CBLinPre = new int[1] ;
         P00CU8_A2281CBTipTipo = new string[] {""} ;
         P00CU8_A2280CBTipPre = new int[1] ;
         P00CU8_A91CueCod = new string[] {""} ;
         P00CU8_A79COSCod = new string[] {""} ;
         P00CU8_n79COSCod = new bool[] {false} ;
         P00CU8_A2284CBRubDItem = new int[1] ;
         P00CU9_A126TASICod = new int[1] ;
         P00CU9_A129VouNum = new string[] {""} ;
         P00CU9_A2077VouSts = new short[1] ;
         P00CU9_A79COSCod = new string[] {""} ;
         P00CU9_n79COSCod = new bool[] {false} ;
         P00CU9_A91CueCod = new string[] {""} ;
         P00CU9_A128VouMes = new short[1] ;
         P00CU9_A127VouAno = new short[1] ;
         P00CU9_A864CueMon = new short[1] ;
         P00CU9_A2056VouDHabO = new decimal[1] ;
         P00CU9_A2052VouDDebO = new decimal[1] ;
         P00CU9_A2069VouDTcmb = new decimal[1] ;
         P00CU9_A2055VouDHab = new decimal[1] ;
         P00CU9_A2051VouDDeb = new decimal[1] ;
         P00CU9_A130VouDSec = new int[1] ;
         A129VouNum = "";
         AV39Logo = "";
         sImgUrl = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_presupuestomensualpdf__default(),
            new Object[][] {
                new Object[] {
               P00CU2_A2280CBTipPre, P00CU2_A2291CBTipPreDsc, P00CU2_A180MonCod
               }
               , new Object[] {
               P00CU3_A2281CBTipTipo, P00CU3_A2280CBTipPre, P00CU3_A2282CBLinPre, P00CU3_A2289CBLinPreDsc
               }
               , new Object[] {
               P00CU4_A2282CBLinPre, P00CU4_A2281CBTipTipo, P00CU4_A2280CBTipPre, P00CU4_A2283CBRubPre, P00CU4_A2293CBRubPreDsc
               }
               , new Object[] {
               P00CU5_A2285CBRubPreAno, P00CU5_A2282CBLinPre, P00CU5_A2281CBTipTipo, P00CU5_A2280CBTipPre, P00CU5_A2296CBRubPreEne, P00CU5_A2297CBRubPreFeb, P00CU5_A2298CBRubPreMar, P00CU5_A2299CBRubPreAbr, P00CU5_A2300CBRubPreMay, P00CU5_A2301CBRubPreJun,
               P00CU5_A2302CBRubPreJul, P00CU5_A2303CBRubPreAgo, P00CU5_A2304CBRubPreSep, P00CU5_A2305CBRubPreOct, P00CU5_A2306CBRubPreNov, P00CU5_A2307CBRubPreDic, P00CU5_A2283CBRubPre
               }
               , new Object[] {
               P00CU6_A2282CBLinPre, P00CU6_A2281CBTipTipo, P00CU6_A2280CBTipPre, P00CU6_A91CueCod, P00CU6_A79COSCod, P00CU6_n79COSCod, P00CU6_A2283CBRubPre, P00CU6_A2284CBRubDItem
               }
               , new Object[] {
               P00CU7_A2285CBRubPreAno, P00CU7_A2283CBRubPre, P00CU7_A2282CBLinPre, P00CU7_A2281CBTipTipo, P00CU7_A2280CBTipPre, P00CU7_A2296CBRubPreEne, P00CU7_A2297CBRubPreFeb, P00CU7_A2298CBRubPreMar, P00CU7_A2299CBRubPreAbr, P00CU7_A2300CBRubPreMay,
               P00CU7_A2301CBRubPreJun, P00CU7_A2302CBRubPreJul, P00CU7_A2303CBRubPreAgo, P00CU7_A2304CBRubPreSep, P00CU7_A2305CBRubPreOct, P00CU7_A2306CBRubPreNov, P00CU7_A2307CBRubPreDic
               }
               , new Object[] {
               P00CU8_A2283CBRubPre, P00CU8_A2282CBLinPre, P00CU8_A2281CBTipTipo, P00CU8_A2280CBTipPre, P00CU8_A91CueCod, P00CU8_A79COSCod, P00CU8_n79COSCod, P00CU8_A2284CBRubDItem
               }
               , new Object[] {
               P00CU9_A126TASICod, P00CU9_A129VouNum, P00CU9_A2077VouSts, P00CU9_A79COSCod, P00CU9_n79COSCod, P00CU9_A91CueCod, P00CU9_A128VouMes, P00CU9_A127VouAno, P00CU9_A864CueMon, P00CU9_A2056VouDHabO,
               P00CU9_A2052VouDDebO, P00CU9_A2069VouDTcmb, P00CU9_A2055VouDHab, P00CU9_A2051VouDDeb, P00CU9_A130VouDSec
               }
            }
         );
         Gx_time = context.localUtil.Time( );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_time = context.localUtil.Time( );
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV11Ano ;
      private short AV40Mes ;
      private short AV30i ;
      private short A2285CBRubPreAno ;
      private short A2077VouSts ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short A864CueMon ;
      private short AV56CueMon ;
      private int AV20CBTipPre ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A2280CBTipPre ;
      private int A180MonCod ;
      private int AV41MonCod ;
      private int Gx_OldLine ;
      private int A2282CBLinPre ;
      private int AV12CBLinPre ;
      private int AV18CBRubPre ;
      private int A2283CBRubPre ;
      private int A2284CBRubDItem ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private decimal AV38ImpTPre ;
      private decimal AV36ImpTEje ;
      private decimal AV35ImpTDif ;
      private decimal AV34ImpPre ;
      private decimal AV32ImpEje ;
      private decimal AV31ImpDif ;
      private decimal AV33ImpPor ;
      private decimal AV37ImpTPor ;
      private decimal AV17CBRImpPre ;
      private decimal AV15CBRImpEje ;
      private decimal AV14CBRImpDif ;
      private decimal AV16CBRImpPor ;
      private decimal A2296CBRubPreEne ;
      private decimal A2297CBRubPreFeb ;
      private decimal A2298CBRubPreMar ;
      private decimal A2299CBRubPreAbr ;
      private decimal A2300CBRubPreMay ;
      private decimal A2301CBRubPreJun ;
      private decimal A2302CBRubPreJul ;
      private decimal A2303CBRubPreAgo ;
      private decimal A2304CBRubPreSep ;
      private decimal A2305CBRubPreOct ;
      private decimal A2306CBRubPreNov ;
      private decimal A2307CBRubPreDic ;
      private decimal AV10Saldo ;
      private decimal A2056VouDHabO ;
      private decimal A2052VouDDebO ;
      private decimal A2069VouDTcmb ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV25EmpRUC ;
      private string AV22cMes ;
      private string GXt_char1 ;
      private string AV29FechaIni ;
      private string AV27FechaC ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A79COSCod ;
      private string AV9CueCod ;
      private string AV8CosCod ;
      private string A129VouNum ;
      private string sImgUrl ;
      private string Gx_time ;
      private DateTime AV28FechaD ;
      private DateTime GXt_date2 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool n79COSCod ;
      private string AV50TipoDetalle ;
      private string AV24Empresa ;
      private string AV23EmpDir ;
      private string AV43Ruta ;
      private string AV59Logo_GXI ;
      private string AV42Periodo ;
      private string A2291CBTipPreDsc ;
      private string AV52Titulo ;
      private string AV51TipoPresupuesto ;
      private string AV47Tip ;
      private string A2281CBTipTipo ;
      private string A2289CBLinPreDsc ;
      private string AV13CBLinPreDsc ;
      private string A2293CBRubPreDsc ;
      private string AV19CBRubPreDsc ;
      private string AV39Logo ;
      private string Logo ;
      private IGxSession AV46Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private int aP2_CBTipPre ;
      private string aP3_TipoDetalle ;
      private IDataStoreProvider pr_default ;
      private int[] P00CU2_A2280CBTipPre ;
      private string[] P00CU2_A2291CBTipPreDsc ;
      private int[] P00CU2_A180MonCod ;
      private string[] P00CU3_A2281CBTipTipo ;
      private int[] P00CU3_A2280CBTipPre ;
      private int[] P00CU3_A2282CBLinPre ;
      private string[] P00CU3_A2289CBLinPreDsc ;
      private int[] P00CU4_A2282CBLinPre ;
      private string[] P00CU4_A2281CBTipTipo ;
      private int[] P00CU4_A2280CBTipPre ;
      private int[] P00CU4_A2283CBRubPre ;
      private string[] P00CU4_A2293CBRubPreDsc ;
      private short[] P00CU5_A2285CBRubPreAno ;
      private int[] P00CU5_A2282CBLinPre ;
      private string[] P00CU5_A2281CBTipTipo ;
      private int[] P00CU5_A2280CBTipPre ;
      private decimal[] P00CU5_A2296CBRubPreEne ;
      private decimal[] P00CU5_A2297CBRubPreFeb ;
      private decimal[] P00CU5_A2298CBRubPreMar ;
      private decimal[] P00CU5_A2299CBRubPreAbr ;
      private decimal[] P00CU5_A2300CBRubPreMay ;
      private decimal[] P00CU5_A2301CBRubPreJun ;
      private decimal[] P00CU5_A2302CBRubPreJul ;
      private decimal[] P00CU5_A2303CBRubPreAgo ;
      private decimal[] P00CU5_A2304CBRubPreSep ;
      private decimal[] P00CU5_A2305CBRubPreOct ;
      private decimal[] P00CU5_A2306CBRubPreNov ;
      private decimal[] P00CU5_A2307CBRubPreDic ;
      private int[] P00CU5_A2283CBRubPre ;
      private int[] P00CU6_A2282CBLinPre ;
      private string[] P00CU6_A2281CBTipTipo ;
      private int[] P00CU6_A2280CBTipPre ;
      private string[] P00CU6_A91CueCod ;
      private string[] P00CU6_A79COSCod ;
      private bool[] P00CU6_n79COSCod ;
      private int[] P00CU6_A2283CBRubPre ;
      private int[] P00CU6_A2284CBRubDItem ;
      private short[] P00CU7_A2285CBRubPreAno ;
      private int[] P00CU7_A2283CBRubPre ;
      private int[] P00CU7_A2282CBLinPre ;
      private string[] P00CU7_A2281CBTipTipo ;
      private int[] P00CU7_A2280CBTipPre ;
      private decimal[] P00CU7_A2296CBRubPreEne ;
      private decimal[] P00CU7_A2297CBRubPreFeb ;
      private decimal[] P00CU7_A2298CBRubPreMar ;
      private decimal[] P00CU7_A2299CBRubPreAbr ;
      private decimal[] P00CU7_A2300CBRubPreMay ;
      private decimal[] P00CU7_A2301CBRubPreJun ;
      private decimal[] P00CU7_A2302CBRubPreJul ;
      private decimal[] P00CU7_A2303CBRubPreAgo ;
      private decimal[] P00CU7_A2304CBRubPreSep ;
      private decimal[] P00CU7_A2305CBRubPreOct ;
      private decimal[] P00CU7_A2306CBRubPreNov ;
      private decimal[] P00CU7_A2307CBRubPreDic ;
      private int[] P00CU8_A2283CBRubPre ;
      private int[] P00CU8_A2282CBLinPre ;
      private string[] P00CU8_A2281CBTipTipo ;
      private int[] P00CU8_A2280CBTipPre ;
      private string[] P00CU8_A91CueCod ;
      private string[] P00CU8_A79COSCod ;
      private bool[] P00CU8_n79COSCod ;
      private int[] P00CU8_A2284CBRubDItem ;
      private int[] P00CU9_A126TASICod ;
      private string[] P00CU9_A129VouNum ;
      private short[] P00CU9_A2077VouSts ;
      private string[] P00CU9_A79COSCod ;
      private bool[] P00CU9_n79COSCod ;
      private string[] P00CU9_A91CueCod ;
      private short[] P00CU9_A128VouMes ;
      private short[] P00CU9_A127VouAno ;
      private short[] P00CU9_A864CueMon ;
      private decimal[] P00CU9_A2056VouDHabO ;
      private decimal[] P00CU9_A2052VouDDebO ;
      private decimal[] P00CU9_A2069VouDTcmb ;
      private decimal[] P00CU9_A2055VouDHab ;
      private decimal[] P00CU9_A2051VouDDeb ;
      private int[] P00CU9_A130VouDSec ;
   }

   public class r_presupuestomensualpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CU9( IGxContext context ,
                                             string AV8CosCod ,
                                             string A79COSCod ,
                                             short A2077VouSts ,
                                             short AV11Ano ,
                                             short AV40Mes ,
                                             string AV9CueCod ,
                                             short A127VouAno ,
                                             short A128VouMes ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T1.[VouNum], T3.[VouSts], T1.[COSCod], T1.[CueCod], T1.[VouMes], T1.[VouAno], T2.[CueMon], T1.[VouDHabO], T1.[VouDDebO], T1.[VouDTcmb], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV40Mes and T1.[CueCod] = @AV9CueCod)");
         AddWhere(sWhereString, "(T3.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CosCod)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV8CosCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod]";
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
               case 7 :
                     return conditional_P00CU9(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] );
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
          Object[] prmP00CU2;
          prmP00CU2 = new Object[] {
          new ParDef("@AV20CBTipPre",GXType.Int32,6,0)
          };
          Object[] prmP00CU3;
          prmP00CU3 = new Object[] {
          new ParDef("@AV20CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV47Tip",GXType.NVarChar,1,0)
          };
          Object[] prmP00CU4;
          prmP00CU4 = new Object[] {
          new ParDef("@AV20CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV47Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV12CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CU5;
          prmP00CU5 = new Object[] {
          new ParDef("@AV20CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV47Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV12CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0)
          };
          Object[] prmP00CU6;
          prmP00CU6 = new Object[] {
          new ParDef("@AV20CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV47Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV12CBLinPre",GXType.Int32,6,0)
          };
          Object[] prmP00CU7;
          prmP00CU7 = new Object[] {
          new ParDef("@AV20CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV47Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV12CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV18CBRubPre",GXType.Int32,6,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0)
          };
          Object[] prmP00CU8;
          prmP00CU8 = new Object[] {
          new ParDef("@AV20CBTipPre",GXType.Int32,6,0) ,
          new ParDef("@AV47Tip",GXType.NVarChar,1,0) ,
          new ParDef("@AV12CBLinPre",GXType.Int32,6,0) ,
          new ParDef("@AV18CBRubPre",GXType.Int32,6,0)
          };
          Object[] prmP00CU9;
          prmP00CU9 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV40Mes",GXType.Int16,2,0) ,
          new ParDef("@AV9CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV8CosCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CU2", "SELECT [CBTipPre], [CBTipPreDsc], [MonCod] FROM [CBPRESUPUESTOTIPO] WHERE [CBTipPre] = @AV20CBTipPre ORDER BY [CBTipPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CU2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CU3", "SELECT [CBTipTipo], [CBTipPre], [CBLinPre], [CBLinPreDsc] FROM [CBPRESUPUESTOLINEA] WHERE [CBTipPre] = @AV20CBTipPre and [CBTipTipo] = @AV47Tip ORDER BY [CBTipPre], [CBTipTipo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CU3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CU4", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CBRubPre], [CBRubPreDsc] FROM [CBPRESUPUESTORUBROS] WHERE [CBTipPre] = @AV20CBTipPre and [CBTipTipo] = @AV47Tip and [CBLinPre] = @AV12CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CU4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CU5", "SELECT [CBRubPreAno], [CBLinPre], [CBTipTipo], [CBTipPre], [CBRubPreEne], [CBRubPreFeb], [CBRubPreMar], [CBRubPreAbr], [CBRubPreMay], [CBRubPreJun], [CBRubPreJul], [CBRubPreAgo], [CBRubPreSep], [CBRubPreOct], [CBRubPreNov], [CBRubPreDic], [CBRubPre] FROM [CBPRESUPUESTORUBROSDET] WHERE ([CBTipPre] = @AV20CBTipPre and [CBTipTipo] = @AV47Tip and [CBLinPre] = @AV12CBLinPre) AND ([CBRubPreAno] = @AV11Ano) ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CU5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CU6", "SELECT [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV20CBTipPre and [CBTipTipo] = @AV47Tip and [CBLinPre] = @AV12CBLinPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CU6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CU7", "SELECT [CBRubPreAno], [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CBRubPreEne], [CBRubPreFeb], [CBRubPreMar], [CBRubPreAbr], [CBRubPreMay], [CBRubPreJun], [CBRubPreJul], [CBRubPreAgo], [CBRubPreSep], [CBRubPreOct], [CBRubPreNov], [CBRubPreDic] FROM [CBPRESUPUESTORUBROSDET] WHERE [CBTipPre] = @AV20CBTipPre and [CBTipTipo] = @AV47Tip and [CBLinPre] = @AV12CBLinPre and [CBRubPre] = @AV18CBRubPre and [CBRubPreAno] = @AV11Ano ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubPreAno] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CU7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CU8", "SELECT [CBRubPre], [CBLinPre], [CBTipTipo], [CBTipPre], [CueCod], [COSCod], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CBTipPre] = @AV20CBTipPre and [CBTipTipo] = @AV47Tip and [CBLinPre] = @AV12CBLinPre and [CBRubPre] = @AV18CBRubPre ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CU8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CU9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CU9,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((int[]) buf[16])[0] = rslt.getInt(17);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((int[]) buf[14])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
