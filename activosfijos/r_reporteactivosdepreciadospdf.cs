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
   public class r_reporteactivosdepreciadospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "activosfijos.r_reporteactivosdepreciadospdf.aspx")), "activosfijos.r_reporteactivosdepreciadospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "activosfijos.r_reporteactivosdepreciadospdf.aspx")))) ;
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
                  AV27ACTGrupCod = GetPar( "ACTGrupCod");
                  AV8ACTActCod = GetPar( "ACTActCod");
                  AV11ActActItem = GetPar( "ActActItem");
                  AV38Ano = (short)(NumberUtil.Val( GetPar( "Ano"), "."));
                  AV70Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
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

      public r_reporteactivosdepreciadospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reporteactivosdepreciadospdf( IGxContext context )
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
         this.AV27ACTGrupCod = aP1_ACTGrupCod;
         this.AV8ACTActCod = aP2_ACTActCod;
         this.AV11ActActItem = aP3_ActActItem;
         this.AV38Ano = aP4_Ano;
         this.AV70Mes = aP5_Mes;
         initialize();
         executePrivate();
         aP0_ACTClaCod=this.AV16ACTClaCod;
         aP1_ACTGrupCod=this.AV27ACTGrupCod;
         aP2_ACTActCod=this.AV8ACTActCod;
         aP3_ActActItem=this.AV11ActActItem;
         aP4_Ano=this.AV38Ano;
         aP5_Mes=this.AV70Mes;
      }

      public short executeUdp( ref string aP0_ACTClaCod ,
                               ref string aP1_ACTGrupCod ,
                               ref string aP2_ACTActCod ,
                               ref string aP3_ActActItem ,
                               ref short aP4_Ano )
      {
         execute(ref aP0_ACTClaCod, ref aP1_ACTGrupCod, ref aP2_ACTActCod, ref aP3_ActActItem, ref aP4_Ano, ref aP5_Mes);
         return AV70Mes ;
      }

      public void executeSubmit( ref string aP0_ACTClaCod ,
                                 ref string aP1_ACTGrupCod ,
                                 ref string aP2_ACTActCod ,
                                 ref string aP3_ActActItem ,
                                 ref short aP4_Ano ,
                                 ref short aP5_Mes )
      {
         r_reporteactivosdepreciadospdf objr_reporteactivosdepreciadospdf;
         objr_reporteactivosdepreciadospdf = new r_reporteactivosdepreciadospdf();
         objr_reporteactivosdepreciadospdf.AV16ACTClaCod = aP0_ACTClaCod;
         objr_reporteactivosdepreciadospdf.AV27ACTGrupCod = aP1_ACTGrupCod;
         objr_reporteactivosdepreciadospdf.AV8ACTActCod = aP2_ACTActCod;
         objr_reporteactivosdepreciadospdf.AV11ActActItem = aP3_ActActItem;
         objr_reporteactivosdepreciadospdf.AV38Ano = aP4_Ano;
         objr_reporteactivosdepreciadospdf.AV70Mes = aP5_Mes;
         objr_reporteactivosdepreciadospdf.context.SetSubmitInitialConfig(context);
         objr_reporteactivosdepreciadospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reporteactivosdepreciadospdf);
         aP0_ACTClaCod=this.AV16ACTClaCod;
         aP1_ACTGrupCod=this.AV27ACTGrupCod;
         aP2_ACTActCod=this.AV8ACTActCod;
         aP3_ActActItem=this.AV11ActActItem;
         aP4_Ano=this.AV38Ano;
         aP5_Mes=this.AV70Mes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reporteactivosdepreciadospdf)stateInfo).executePrivate();
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
            AV50Empresa = AV88Session.Get("Empresa");
            AV49EmpDir = AV88Session.Get("EmpDir");
            AV51EmpRUC = AV88Session.Get("EmpRUC");
            AV84Ruta = AV88Session.Get("RUTA") + "/Logo.jpg";
            AV69Logo = AV84Ruta;
            AV113Logo_GXI = GXDbFile.PathToUrl( AV84Ruta);
            AV96Titulo = "Reporte de Activos Totalmente Depreciados";
            GXt_char1 = AV40cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV70Mes, out  GXt_char1) ;
            AV40cMes = ((AV70Mes==0) ? "" : GXt_char1);
            AV79Periodo = "Periodo : " + StringUtil.Trim( AV40cMes) + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV38Ano), 10, 0));
            AV54FechaC = "01/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV70Mes), 10, 0)) + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV38Ano), 10, 0));
            AV56FechaIni = context.localUtil.CToD( AV54FechaC, 2);
            GXt_date2 = AV57FechaUlt;
            new GeneXus.Programs.generales.pobtieneultimodiames(context ).execute(  AV56FechaIni, out  GXt_date2) ;
            AV57FechaUlt = GXt_date2;
            AV94Tipo = "D";
            AV66jAnoAnt = AV38Ano;
            AV67jMesAnt = AV70Mes;
            if ( AV70Mes == 12 )
            {
               AV67jMesAnt = 1;
               AV66jAnoAnt = (short)(AV38Ano-1);
            }
            else
            {
               AV67jMesAnt = (short)(AV70Mes-1);
            }
            AV107TValor = 0;
            AV92TImpLibro = 0;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV16ACTClaCod ,
                                                 AV27ACTGrupCod ,
                                                 AV8ACTActCod ,
                                                 AV11ActActItem ,
                                                 AV70Mes ,
                                                 A426ACTClaCod ,
                                                 A2103ACTGrupCod ,
                                                 A2100ACTActCod ,
                                                 A2104ActActItem ,
                                                 A2190ActHisFec ,
                                                 AV38Ano ,
                                                 A2189ACTHisDepre } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL
                                                 }
            });
            /* Using cursor P00FD2 */
            pr_default.execute(0, new Object[] {AV38Ano, AV16ACTClaCod, AV27ACTGrupCod, AV8ACTActCod, AV11ActActItem, AV70Mes});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKFD3 = false;
               A2114ACTSGrupCod = P00FD2_A2114ACTSGrupCod[0];
               A2122ACTActDsc = P00FD2_A2122ACTActDsc[0];
               A2100ACTActCod = P00FD2_A2100ACTActCod[0];
               A2189ACTHisDepre = P00FD2_A2189ACTHisDepre[0];
               A2190ActHisFec = P00FD2_A2190ActHisFec[0];
               A2104ActActItem = P00FD2_A2104ActActItem[0];
               n2104ActActItem = P00FD2_n2104ActActItem[0];
               A2103ACTGrupCod = P00FD2_A2103ACTGrupCod[0];
               A426ACTClaCod = P00FD2_A426ACTClaCod[0];
               A2118ACTActCodEQV = P00FD2_A2118ACTActCodEQV[0];
               A2155ACTSGrupDsc = P00FD2_A2155ACTSGrupDsc[0];
               A2156ACTSGrupPor = P00FD2_A2156ACTSGrupPor[0];
               A2107ACTHisAno = P00FD2_A2107ACTHisAno[0];
               A2108ACTHisMes = P00FD2_A2108ACTHisMes[0];
               A2122ACTActDsc = P00FD2_A2122ACTActDsc[0];
               A2103ACTGrupCod = P00FD2_A2103ACTGrupCod[0];
               A426ACTClaCod = P00FD2_A426ACTClaCod[0];
               A2118ACTActCodEQV = P00FD2_A2118ACTActCodEQV[0];
               A2114ACTSGrupCod = P00FD2_A2114ACTSGrupCod[0];
               A2155ACTSGrupDsc = P00FD2_A2155ACTSGrupDsc[0];
               A2156ACTSGrupPor = P00FD2_A2156ACTSGrupPor[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00FD2_A2100ACTActCod[0], A2100ACTActCod) == 0 ) )
               {
                  BRKFD3 = false;
                  A2122ACTActDsc = P00FD2_A2122ACTActDsc[0];
                  A2104ActActItem = P00FD2_A2104ActActItem[0];
                  n2104ActActItem = P00FD2_n2104ActActItem[0];
                  A2107ACTHisAno = P00FD2_A2107ACTHisAno[0];
                  A2108ACTHisMes = P00FD2_A2108ACTHisMes[0];
                  A2122ACTActDsc = P00FD2_A2122ACTActDsc[0];
                  BRKFD3 = true;
                  pr_default.readNext(0);
               }
               AV17ActCod = A2100ACTActCod;
               AV28ActItem = A2104ActActItem;
               AV18ActCodEQV = StringUtil.Trim( A2118ACTActCodEQV);
               AV29ACTSGrupDsc = StringUtil.Trim( A2155ACTSGrupDsc);
               AV26ActDsc = StringUtil.Trim( A2122ACTActDsc) + " - " + StringUtil.Trim( AV29ACTSGrupDsc);
               AV81Porcentaje = A2156ACTSGrupPor;
               AV109Valor = 0;
               AV61ImpDepre = 0;
               /* Execute user subroutine: 'VALORACTIVO' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               AV55FechaFinal = AV10ACTActFech;
               AV109Valor = (decimal)(AV24ACTDetValorNeto+AV25ACTDetValorReparacion+AV23ACTDetValorCompras);
               /* Execute user subroutine: 'DEPRECIACIONFINAL' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               HFD0( false, 17) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV19ACTDetFecIni, "99/99/99"), 9, Gx_line+3, 41, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ActCodEQV, "")), 123, Gx_line+3, 207, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV109Valor, "ZZZZZZ,ZZZ,ZZ9.99")), 566, Gx_line+3, 645, Gx_line+13, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26ActDsc, "")), 208, Gx_line+3, 539, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV81Porcentaje, "ZZ9.99")), 651, Gx_line+3, 685, Gx_line+13, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61ImpDepre, "ZZZZZZ,ZZZ,ZZ9.99")), 711, Gx_line+3, 783, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV19ACTDetFecIni, "99/99/99"), 54, Gx_line+1, 86, Gx_line+12, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               AV107TValor = (decimal)(AV107TValor+AV109Valor);
               AV92TImpLibro = (decimal)(AV92TImpLibro+AV61ImpDepre);
               if ( ! BRKFD3 )
               {
                  BRKFD3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            HFD0( false, 105) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV107TValor, "ZZZZZZ,ZZZ,ZZ9.99")), 566, Gx_line+17, 645, Gx_line+31, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(395, Gx_line+10, 788, Gx_line+10, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("TOTAL GENERAL", 404, Gx_line+17, 497, Gx_line+31, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV92TImpLibro, "ZZZZZZ,ZZZ,ZZ9.99")), 664, Gx_line+17, 789, Gx_line+32, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+105);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HFD0( true, 0) ;
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
         /* 'VALORACTIVO' Routine */
         returnInSub = false;
         AV24ACTDetValorNeto = 0;
         AV25ACTDetValorReparacion = 0;
         AV23ACTDetValorCompras = 0;
         /* Using cursor P00FD3 */
         pr_default.execute(1, new Object[] {AV17ActCod, AV28ActItem});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A2104ActActItem = P00FD3_A2104ActActItem[0];
            n2104ActActItem = P00FD3_n2104ActActItem[0];
            A2100ACTActCod = P00FD3_A2100ACTActCod[0];
            A2150ACTDetValorNeto = P00FD3_A2150ACTDetValorNeto[0];
            A2143ACTDetFecIni = P00FD3_A2143ACTDetFecIni[0];
            AV24ACTDetValorNeto = A2150ACTDetValorNeto;
            AV10ACTActFech = A2143ACTDetFecIni;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         /* Using cursor P00FD4 */
         pr_default.execute(2, new Object[] {AV17ActCod, AV19ACTDetFecIni, AV57FechaUlt});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A2204AMRepFec = P00FD4_A2204AMRepFec[0];
            A2100ACTActCod = P00FD4_A2100ACTActCod[0];
            A2209AMRepValor = P00FD4_A2209AMRepValor[0];
            A2104ActActItem = P00FD4_A2104ActActItem[0];
            n2104ActActItem = P00FD4_n2104ActActItem[0];
            A2112AMRepCod = P00FD4_A2112AMRepCod[0];
            AV25ACTDetValorReparacion = (decimal)(AV25ACTDetValorReparacion+((String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem))||P00FD4_n2104ActActItem[0] ? NumberUtil.Round( (A2209AMRepValor*AV81Porcentaje)/ (decimal)(100), 2) : ((StringUtil.StrCmp(A2104ActActItem, AV11ActActItem)==0) ? A2209AMRepValor : (decimal)(0)))));
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor P00FD5 */
         pr_default.execute(3, new Object[] {AV17ActCod, AV19ACTDetFecIni, AV57FechaUlt});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A2218ACTRevFec = P00FD5_A2218ACTRevFec[0];
            A2100ACTActCod = P00FD5_A2100ACTActCod[0];
            A2217ActRevCosto = P00FD5_A2217ActRevCosto[0];
            A2104ActActItem = P00FD5_A2104ActActItem[0];
            n2104ActActItem = P00FD5_n2104ActActItem[0];
            A2113ACTRevCod = P00FD5_A2113ACTRevCod[0];
            AV23ACTDetValorCompras = (decimal)(AV23ACTDetValorCompras+((String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem))||P00FD5_n2104ActActItem[0] ? NumberUtil.Round( (A2217ActRevCosto*AV81Porcentaje)/ (decimal)(100), 2) : ((StringUtil.StrCmp(A2104ActActItem, AV11ActActItem)==0) ? A2217ActRevCosto : (decimal)(0)))));
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S121( )
      {
         /* 'DEPRECIACIONFINAL' Routine */
         returnInSub = false;
         /* Using cursor P00FD6 */
         pr_default.execute(4, new Object[] {AV17ActCod, AV28ActItem});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A2189ACTHisDepre = P00FD6_A2189ACTHisDepre[0];
            A2104ActActItem = P00FD6_A2104ActActItem[0];
            n2104ActActItem = P00FD6_n2104ActActItem[0];
            A2100ACTActCod = P00FD6_A2100ACTActCod[0];
            A2190ActHisFec = P00FD6_A2190ActHisFec[0];
            A2107ACTHisAno = P00FD6_A2107ACTHisAno[0];
            A2108ACTHisMes = P00FD6_A2108ACTHisMes[0];
            AV61ImpDepre = (decimal)(AV61ImpDepre+A2189ACTHisDepre);
            AV55FechaFinal = A2190ActHisFec;
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void HFD0( bool bFoot ,
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
               getPrinter().GxDrawText("COD. ACTIVO", 134, Gx_line+85, 189, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FECHA", 12, Gx_line+85, 40, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Empresa, "")), 8, Gx_line+14, 233, Gx_line+32, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51EmpRUC, "")), 8, Gx_line+31, 178, Gx_line+49, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79Periodo, "")), 267, Gx_line+46, 560, Gx_line+67, 1+256, 0, 0, 1) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("VALOR ACTIVO", 565, Gx_line+85, 627, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DEPRECIACIÓN TOTAL", 694, Gx_line+85, 789, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(53, Gx_line+74, 53, Gx_line+105, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(202, Gx_line+75, 202, Gx_line+105, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(540, Gx_line+74, 540, Gx_line+105, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(656, Gx_line+74, 656, Gx_line+104, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("CONCEPTO", 345, Gx_line+85, 391, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV96Titulo, "")), 217, Gx_line+18, 606, Gx_line+43, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("%", 668, Gx_line+85, 679, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(689, Gx_line+76, 689, Gx_line+106, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+74, 800, Gx_line+105, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(113, Gx_line+74, 113, Gx_line+105, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+106);
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
         AV50Empresa = "";
         AV88Session = context.GetSession();
         AV49EmpDir = "";
         AV51EmpRUC = "";
         AV84Ruta = "";
         AV69Logo = "";
         AV113Logo_GXI = "";
         AV96Titulo = "";
         AV40cMes = "";
         GXt_char1 = "";
         AV79Periodo = "";
         AV54FechaC = "";
         AV56FechaIni = DateTime.MinValue;
         AV57FechaUlt = DateTime.MinValue;
         GXt_date2 = DateTime.MinValue;
         AV94Tipo = "";
         scmdbuf = "";
         A426ACTClaCod = "";
         A2103ACTGrupCod = "";
         A2100ACTActCod = "";
         A2104ActActItem = "";
         A2190ActHisFec = DateTime.MinValue;
         P00FD2_A2114ACTSGrupCod = new string[] {""} ;
         P00FD2_A2122ACTActDsc = new string[] {""} ;
         P00FD2_A2100ACTActCod = new string[] {""} ;
         P00FD2_A2189ACTHisDepre = new decimal[1] ;
         P00FD2_A2190ActHisFec = new DateTime[] {DateTime.MinValue} ;
         P00FD2_A2104ActActItem = new string[] {""} ;
         P00FD2_n2104ActActItem = new bool[] {false} ;
         P00FD2_A2103ACTGrupCod = new string[] {""} ;
         P00FD2_A426ACTClaCod = new string[] {""} ;
         P00FD2_A2118ACTActCodEQV = new string[] {""} ;
         P00FD2_A2155ACTSGrupDsc = new string[] {""} ;
         P00FD2_A2156ACTSGrupPor = new decimal[1] ;
         P00FD2_A2107ACTHisAno = new short[1] ;
         P00FD2_A2108ACTHisMes = new short[1] ;
         A2114ACTSGrupCod = "";
         A2122ACTActDsc = "";
         A2118ACTActCodEQV = "";
         A2155ACTSGrupDsc = "";
         AV17ActCod = "";
         AV28ActItem = "";
         AV18ActCodEQV = "";
         AV29ACTSGrupDsc = "";
         AV26ActDsc = "";
         AV55FechaFinal = DateTime.MinValue;
         AV10ACTActFech = DateTime.MinValue;
         AV19ACTDetFecIni = DateTime.MinValue;
         P00FD3_A2104ActActItem = new string[] {""} ;
         P00FD3_n2104ActActItem = new bool[] {false} ;
         P00FD3_A2100ACTActCod = new string[] {""} ;
         P00FD3_A2150ACTDetValorNeto = new decimal[1] ;
         P00FD3_A2143ACTDetFecIni = new DateTime[] {DateTime.MinValue} ;
         A2143ACTDetFecIni = DateTime.MinValue;
         P00FD4_A2204AMRepFec = new DateTime[] {DateTime.MinValue} ;
         P00FD4_A2100ACTActCod = new string[] {""} ;
         P00FD4_A2209AMRepValor = new decimal[1] ;
         P00FD4_A2104ActActItem = new string[] {""} ;
         P00FD4_n2104ActActItem = new bool[] {false} ;
         P00FD4_A2112AMRepCod = new string[] {""} ;
         A2204AMRepFec = DateTime.MinValue;
         A2112AMRepCod = "";
         P00FD5_A2218ACTRevFec = new DateTime[] {DateTime.MinValue} ;
         P00FD5_A2100ACTActCod = new string[] {""} ;
         P00FD5_A2217ActRevCosto = new decimal[1] ;
         P00FD5_A2104ActActItem = new string[] {""} ;
         P00FD5_n2104ActActItem = new bool[] {false} ;
         P00FD5_A2113ACTRevCod = new string[] {""} ;
         A2218ACTRevFec = DateTime.MinValue;
         A2113ACTRevCod = "";
         P00FD6_A2189ACTHisDepre = new decimal[1] ;
         P00FD6_A2104ActActItem = new string[] {""} ;
         P00FD6_n2104ActActItem = new bool[] {false} ;
         P00FD6_A2100ACTActCod = new string[] {""} ;
         P00FD6_A2190ActHisFec = new DateTime[] {DateTime.MinValue} ;
         P00FD6_A2107ACTHisAno = new short[1] ;
         P00FD6_A2108ACTHisMes = new short[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.activosfijos.r_reporteactivosdepreciadospdf__default(),
            new Object[][] {
                new Object[] {
               P00FD2_A2114ACTSGrupCod, P00FD2_A2122ACTActDsc, P00FD2_A2100ACTActCod, P00FD2_A2189ACTHisDepre, P00FD2_A2190ActHisFec, P00FD2_A2104ActActItem, P00FD2_A2103ACTGrupCod, P00FD2_A426ACTClaCod, P00FD2_A2118ACTActCodEQV, P00FD2_A2155ACTSGrupDsc,
               P00FD2_A2156ACTSGrupPor, P00FD2_A2107ACTHisAno, P00FD2_A2108ACTHisMes
               }
               , new Object[] {
               P00FD3_A2104ActActItem, P00FD3_A2100ACTActCod, P00FD3_A2150ACTDetValorNeto, P00FD3_A2143ACTDetFecIni
               }
               , new Object[] {
               P00FD4_A2204AMRepFec, P00FD4_A2100ACTActCod, P00FD4_A2209AMRepValor, P00FD4_A2104ActActItem, P00FD4_n2104ActActItem, P00FD4_A2112AMRepCod
               }
               , new Object[] {
               P00FD5_A2218ACTRevFec, P00FD5_A2100ACTActCod, P00FD5_A2217ActRevCosto, P00FD5_A2104ActActItem, P00FD5_n2104ActActItem, P00FD5_A2113ACTRevCod
               }
               , new Object[] {
               P00FD6_A2189ACTHisDepre, P00FD6_A2104ActActItem, P00FD6_A2100ACTActCod, P00FD6_A2190ActHisFec, P00FD6_A2107ACTHisAno, P00FD6_A2108ACTHisMes
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
      private short AV38Ano ;
      private short AV70Mes ;
      private short AV66jAnoAnt ;
      private short AV67jMesAnt ;
      private short A2107ACTHisAno ;
      private short A2108ACTHisMes ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal AV107TValor ;
      private decimal AV92TImpLibro ;
      private decimal A2189ACTHisDepre ;
      private decimal A2156ACTSGrupPor ;
      private decimal AV81Porcentaje ;
      private decimal AV109Valor ;
      private decimal AV61ImpDepre ;
      private decimal AV24ACTDetValorNeto ;
      private decimal AV25ACTDetValorReparacion ;
      private decimal AV23ACTDetValorCompras ;
      private decimal A2150ACTDetValorNeto ;
      private decimal A2209AMRepValor ;
      private decimal A2217ActRevCosto ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV50Empresa ;
      private string AV49EmpDir ;
      private string AV51EmpRUC ;
      private string AV84Ruta ;
      private string AV96Titulo ;
      private string AV40cMes ;
      private string GXt_char1 ;
      private string AV54FechaC ;
      private string AV94Tipo ;
      private string scmdbuf ;
      private string A2155ACTSGrupDsc ;
      private string AV29ACTSGrupDsc ;
      private string Gx_time ;
      private DateTime AV56FechaIni ;
      private DateTime AV57FechaUlt ;
      private DateTime GXt_date2 ;
      private DateTime A2190ActHisFec ;
      private DateTime AV55FechaFinal ;
      private DateTime AV10ACTActFech ;
      private DateTime AV19ACTDetFecIni ;
      private DateTime A2143ACTDetFecIni ;
      private DateTime A2204AMRepFec ;
      private DateTime A2218ACTRevFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKFD3 ;
      private bool n2104ActActItem ;
      private bool returnInSub ;
      private string AV16ACTClaCod ;
      private string AV27ACTGrupCod ;
      private string AV8ACTActCod ;
      private string AV11ActActItem ;
      private string AV113Logo_GXI ;
      private string AV79Periodo ;
      private string A426ACTClaCod ;
      private string A2103ACTGrupCod ;
      private string A2100ACTActCod ;
      private string A2104ActActItem ;
      private string A2114ACTSGrupCod ;
      private string A2122ACTActDsc ;
      private string A2118ACTActCodEQV ;
      private string AV17ActCod ;
      private string AV28ActItem ;
      private string AV18ActCodEQV ;
      private string AV26ActDsc ;
      private string A2112AMRepCod ;
      private string A2113ACTRevCod ;
      private string AV69Logo ;
      private IGxSession AV88Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ACTClaCod ;
      private string aP1_ACTGrupCod ;
      private string aP2_ACTActCod ;
      private string aP3_ActActItem ;
      private short aP4_Ano ;
      private short aP5_Mes ;
      private IDataStoreProvider pr_default ;
      private string[] P00FD2_A2114ACTSGrupCod ;
      private string[] P00FD2_A2122ACTActDsc ;
      private string[] P00FD2_A2100ACTActCod ;
      private decimal[] P00FD2_A2189ACTHisDepre ;
      private DateTime[] P00FD2_A2190ActHisFec ;
      private string[] P00FD2_A2104ActActItem ;
      private bool[] P00FD2_n2104ActActItem ;
      private string[] P00FD2_A2103ACTGrupCod ;
      private string[] P00FD2_A426ACTClaCod ;
      private string[] P00FD2_A2118ACTActCodEQV ;
      private string[] P00FD2_A2155ACTSGrupDsc ;
      private decimal[] P00FD2_A2156ACTSGrupPor ;
      private short[] P00FD2_A2107ACTHisAno ;
      private short[] P00FD2_A2108ACTHisMes ;
      private string[] P00FD3_A2104ActActItem ;
      private bool[] P00FD3_n2104ActActItem ;
      private string[] P00FD3_A2100ACTActCod ;
      private decimal[] P00FD3_A2150ACTDetValorNeto ;
      private DateTime[] P00FD3_A2143ACTDetFecIni ;
      private DateTime[] P00FD4_A2204AMRepFec ;
      private string[] P00FD4_A2100ACTActCod ;
      private decimal[] P00FD4_A2209AMRepValor ;
      private string[] P00FD4_A2104ActActItem ;
      private bool[] P00FD4_n2104ActActItem ;
      private string[] P00FD4_A2112AMRepCod ;
      private DateTime[] P00FD5_A2218ACTRevFec ;
      private string[] P00FD5_A2100ACTActCod ;
      private decimal[] P00FD5_A2217ActRevCosto ;
      private string[] P00FD5_A2104ActActItem ;
      private bool[] P00FD5_n2104ActActItem ;
      private string[] P00FD5_A2113ACTRevCod ;
      private decimal[] P00FD6_A2189ACTHisDepre ;
      private string[] P00FD6_A2104ActActItem ;
      private bool[] P00FD6_n2104ActActItem ;
      private string[] P00FD6_A2100ACTActCod ;
      private DateTime[] P00FD6_A2190ActHisFec ;
      private short[] P00FD6_A2107ACTHisAno ;
      private short[] P00FD6_A2108ACTHisMes ;
   }

   public class r_reporteactivosdepreciadospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FD2( IGxContext context ,
                                             string AV16ACTClaCod ,
                                             string AV27ACTGrupCod ,
                                             string AV8ACTActCod ,
                                             string AV11ActActItem ,
                                             short AV70Mes ,
                                             string A426ACTClaCod ,
                                             string A2103ACTGrupCod ,
                                             string A2100ACTActCod ,
                                             string A2104ActActItem ,
                                             DateTime A2190ActHisFec ,
                                             short AV38Ano ,
                                             decimal A2189ACTHisDepre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T3.[ACTSGrupCod], T2.[ACTActDsc], T1.[ACTActCod], T1.[ACTHisDepre], T1.[ActHisFec], T1.[ActActItem], T2.[ACTGrupCod], T2.[ACTClaCod], T2.[ACTActCodEQV], T4.[ACTSGrupDsc], T4.[ACTSGrupPor], T1.[ACTHisAno], T1.[ACTHisMes] FROM ((([ACTCOSTODEP] T1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod]) INNER JOIN [ACTACTIVOSDET] T3 ON T3.[ACTActCod] = T1.[ACTActCod] AND T3.[ActActItem] = T1.[ActActItem]) LEFT JOIN [ACTSUBGRUPO] T4 ON T4.[ACTClaCod] = T2.[ACTClaCod] AND T4.[ACTGrupCod] = T2.[ACTGrupCod] AND T4.[ACTSGrupCod] = T3.[ACTSGrupCod])";
         AddWhere(sWhereString, "(YEAR(T1.[ActHisFec]) = @AV38Ano)");
         AddWhere(sWhereString, "(T1.[ACTHisDepre] = 0)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ACTClaCod)) )
         {
            AddWhere(sWhereString, "(T2.[ACTClaCod] = @AV16ACTClaCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ACTGrupCod)) )
         {
            AddWhere(sWhereString, "(T2.[ACTGrupCod] = @AV27ACTGrupCod)");
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
         if ( ! (0==AV70Mes) )
         {
            AddWhere(sWhereString, "(MONTH(T1.[ActHisFec]) = @AV70Mes)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ACTActCod], T2.[ACTActDsc]";
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
               case 0 :
                     return conditional_P00FD2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (short)dynConstraints[10] , (decimal)dynConstraints[11] );
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
          Object[] prmP00FD3;
          prmP00FD3 = new Object[] {
          new ParDef("@AV17ActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV28ActItem",GXType.NVarChar,5,0)
          };
          Object[] prmP00FD4;
          prmP00FD4 = new Object[] {
          new ParDef("@AV17ActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV19ACTDetFecIni",GXType.Date,8,0) ,
          new ParDef("@AV57FechaUlt",GXType.Date,8,0)
          };
          Object[] prmP00FD5;
          prmP00FD5 = new Object[] {
          new ParDef("@AV17ActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV19ACTDetFecIni",GXType.Date,8,0) ,
          new ParDef("@AV57FechaUlt",GXType.Date,8,0)
          };
          Object[] prmP00FD6;
          prmP00FD6 = new Object[] {
          new ParDef("@AV17ActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV28ActItem",GXType.NVarChar,5,0)
          };
          Object[] prmP00FD2;
          prmP00FD2 = new Object[] {
          new ParDef("@AV38Ano",GXType.Int16,4,0) ,
          new ParDef("@AV16ACTClaCod",GXType.NVarChar,5,0) ,
          new ParDef("@AV27ACTGrupCod",GXType.NVarChar,5,0) ,
          new ParDef("@AV8ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV11ActActItem",GXType.NVarChar,5,0) ,
          new ParDef("@AV70Mes",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FD2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FD2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FD3", "SELECT [ActActItem], [ACTActCod], [ACTDetValorNeto], [ACTDetFecIni] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @AV17ActCod and [ActActItem] = @AV28ActItem ORDER BY [ACTActCod], [ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FD3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FD4", "SELECT [AMRepFec], [ACTActCod], [AMRepValor], [ActActItem], [AMRepCod] FROM [ACTMOVREPARACION] WHERE ([ACTActCod] = @AV17ActCod) AND ([AMRepFec] > @AV19ACTDetFecIni) AND ([AMRepFec] <= @AV57FechaUlt) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FD4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FD5", "SELECT [ACTRevFec], [ACTActCod], [ActRevCosto], [ActActItem], [ACTRevCod] FROM [ACTRevaluacion] WHERE ([ACTActCod] = @AV17ActCod) AND ([ACTRevFec] > @AV19ACTDetFecIni) AND ([ACTRevFec] <= @AV57FechaUlt) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FD5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FD6", "SELECT [ACTHisDepre], [ActActItem], [ACTActCod], [ActHisFec], [ACTHisAno], [ACTHisMes] FROM [ACTCOSTODEP] WHERE ([ACTActCod] = @AV17ActCod and [ActActItem] = @AV28ActItem) AND (Not [ACTHisDepre] = 0) ORDER BY [ACTActCod], [ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FD6,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                return;
             case 2 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
             case 3 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
             case 4 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
