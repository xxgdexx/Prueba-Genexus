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
   public class r_resumendepreciacionmensualpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "activosfijos.r_resumendepreciacionmensualpdf.aspx")), "activosfijos.r_resumendepreciacionmensualpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "activosfijos.r_resumendepreciacionmensualpdf.aspx")))) ;
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
               AV19ACTClaCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV25ACTGrupCod = GetPar( "ACTGrupCod");
                  AV29Ano = (short)(NumberUtil.Val( GetPar( "Ano"), "."));
                  AV57Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
                  AV81Tipo = GetPar( "Tipo");
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

      public r_resumendepreciacionmensualpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumendepreciacionmensualpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ACTClaCod ,
                           ref string aP1_ACTGrupCod ,
                           ref short aP2_Ano ,
                           ref short aP3_Mes ,
                           ref string aP4_Tipo )
      {
         this.AV19ACTClaCod = aP0_ACTClaCod;
         this.AV25ACTGrupCod = aP1_ACTGrupCod;
         this.AV29Ano = aP2_Ano;
         this.AV57Mes = aP3_Mes;
         this.AV81Tipo = aP4_Tipo;
         initialize();
         executePrivate();
         aP0_ACTClaCod=this.AV19ACTClaCod;
         aP1_ACTGrupCod=this.AV25ACTGrupCod;
         aP2_Ano=this.AV29Ano;
         aP3_Mes=this.AV57Mes;
         aP4_Tipo=this.AV81Tipo;
      }

      public string executeUdp( ref string aP0_ACTClaCod ,
                                ref string aP1_ACTGrupCod ,
                                ref short aP2_Ano ,
                                ref short aP3_Mes )
      {
         execute(ref aP0_ACTClaCod, ref aP1_ACTGrupCod, ref aP2_Ano, ref aP3_Mes, ref aP4_Tipo);
         return AV81Tipo ;
      }

      public void executeSubmit( ref string aP0_ACTClaCod ,
                                 ref string aP1_ACTGrupCod ,
                                 ref short aP2_Ano ,
                                 ref short aP3_Mes ,
                                 ref string aP4_Tipo )
      {
         r_resumendepreciacionmensualpdf objr_resumendepreciacionmensualpdf;
         objr_resumendepreciacionmensualpdf = new r_resumendepreciacionmensualpdf();
         objr_resumendepreciacionmensualpdf.AV19ACTClaCod = aP0_ACTClaCod;
         objr_resumendepreciacionmensualpdf.AV25ACTGrupCod = aP1_ACTGrupCod;
         objr_resumendepreciacionmensualpdf.AV29Ano = aP2_Ano;
         objr_resumendepreciacionmensualpdf.AV57Mes = aP3_Mes;
         objr_resumendepreciacionmensualpdf.AV81Tipo = aP4_Tipo;
         objr_resumendepreciacionmensualpdf.context.SetSubmitInitialConfig(context);
         objr_resumendepreciacionmensualpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumendepreciacionmensualpdf);
         aP0_ACTClaCod=this.AV19ACTClaCod;
         aP1_ACTGrupCod=this.AV25ACTGrupCod;
         aP2_Ano=this.AV29Ano;
         aP3_Mes=this.AV57Mes;
         aP4_Tipo=this.AV81Tipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumendepreciacionmensualpdf)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 2, 9, 11909, 16834, 0, 1, 1, 0, 1, 1) )
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
            AV38Empresa = AV75Session.Get("Empresa");
            AV37EmpDir = AV75Session.Get("EmpDir");
            AV39EmpRUC = AV75Session.Get("EmpRUC");
            AV71Ruta = AV75Session.Get("RUTA") + "/Logo.jpg";
            AV56Logo = AV71Ruta;
            AV105Logo_GXI = GXDbFile.PathToUrl( AV71Ruta);
            AV41FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV57Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV29Ano), 10, 0));
            AV42FechaIni = context.localUtil.CToD( AV41FechaC, 2);
            GXt_date1 = AV43FechaUlt;
            new GeneXus.Programs.generales.pobtieneultimodiames(context ).execute(  AV42FechaIni, out  GXt_date1) ;
            AV43FechaUlt = GXt_date1;
            AV83Titulo = "Analisis de Activos Fijos";
            GXt_char2 = AV31cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV57Mes, out  GXt_char2) ;
            AV31cMes = GXt_char2;
            AV53jAnoAnt = AV29Ano;
            AV54jMesAnt = AV57Mes;
            if ( AV57Mes == 1 )
            {
               AV53jAnoAnt = (short)(AV29Ano-1);
               AV54jMesAnt = 12;
            }
            else
            {
               AV54jMesAnt = (short)(AV57Mes-1);
            }
            AV85Total1 = 0.00m;
            AV86Total2 = 0.00m;
            AV87Total3 = 0.00m;
            AV88Total4 = 0.00m;
            AV89Total5 = 0.00m;
            AV90Total6 = 0.00m;
            AV91Total7 = 0.00m;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV19ACTClaCod ,
                                                 A426ACTClaCod ,
                                                 A2107ACTHisAno ,
                                                 AV29Ano ,
                                                 A2108ACTHisMes ,
                                                 AV57Mes } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00F52 */
            pr_default.execute(0, new Object[] {AV29Ano, AV57Mes, AV19ACTClaCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKF53 = false;
               A2100ACTActCod = P00F52_A2100ACTActCod[0];
               A2107ACTHisAno = P00F52_A2107ACTHisAno[0];
               A2108ACTHisMes = P00F52_A2108ACTHisMes[0];
               A2184ACTClaDsc = P00F52_A2184ACTClaDsc[0];
               A426ACTClaCod = P00F52_A426ACTClaCod[0];
               n426ACTClaCod = P00F52_n426ACTClaCod[0];
               A2104ActActItem = P00F52_A2104ActActItem[0];
               n2104ActActItem = P00F52_n2104ActActItem[0];
               A426ACTClaCod = P00F52_A426ACTClaCod[0];
               n426ACTClaCod = P00F52_n426ACTClaCod[0];
               A2184ACTClaDsc = P00F52_A2184ACTClaDsc[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00F52_A426ACTClaCod[0], A426ACTClaCod) == 0 ) )
               {
                  BRKF53 = false;
                  A2100ACTActCod = P00F52_A2100ACTActCod[0];
                  A2107ACTHisAno = P00F52_A2107ACTHisAno[0];
                  A2108ACTHisMes = P00F52_A2108ACTHisMes[0];
                  A2184ACTClaDsc = P00F52_A2184ACTClaDsc[0];
                  A2104ActActItem = P00F52_A2104ActActItem[0];
                  n2104ActActItem = P00F52_n2104ActActItem[0];
                  A2184ACTClaDsc = P00F52_A2184ACTClaDsc[0];
                  BRKF53 = true;
                  pr_default.readNext(0);
               }
               AV30Clase = A426ACTClaCod;
               AV82TipoActivo = "Total : " + StringUtil.Trim( A2184ACTClaDsc);
               AV97TTValor = 0.00m;
               AV98TTValorCalculo = 0.00m;
               AV92TTDAcumulada = 0.00m;
               AV93TTDAnterior = 0.00m;
               AV95TTImpLibro = 0.00m;
               AV96TTImpPorDepre = 0.00m;
               AV94TTImpDepre = 0.00m;
               HF50( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2184ACTClaDsc, "")), 5, Gx_line+3, 631, Gx_line+18, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               /* Execute user subroutine: 'DETALLEACTIVOS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               HF50( false, 38) ;
               getPrinter().GxDrawLine(540, Gx_line+7, 1030, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82TipoActivo, "")), 66, Gx_line+9, 520, Gx_line+23, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV94TTImpDepre, "ZZZZZZ,ZZZ,ZZ9.99")), 928, Gx_line+11, 1018, Gx_line+22, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV96TTImpPorDepre, "ZZZZZZ,ZZZ,ZZ9.99")), 860, Gx_line+11, 950, Gx_line+22, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV79TImpLibro, "ZZZZZZ,ZZZ,ZZ9.99")), 803, Gx_line+11, 893, Gx_line+22, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV93TTDAnterior, "ZZZZZZ,ZZZ,ZZ9.99")), 750, Gx_line+11, 840, Gx_line+22, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV92TTDAcumulada, "ZZZZZZ,ZZZ,ZZ9.99")), 673, Gx_line+11, 763, Gx_line+22, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV98TTValorCalculo, "ZZZZZZ,ZZZ,ZZ9.99")), 605, Gx_line+11, 695, Gx_line+22, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV97TTValor, "ZZZZZZ,ZZZ,ZZ9.99")), 530, Gx_line+11, 620, Gx_line+22, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+38);
               AV85Total1 = (decimal)(AV85Total1+AV97TTValor);
               AV86Total2 = (decimal)(AV86Total2+AV98TTValorCalculo);
               AV87Total3 = (decimal)(AV87Total3+AV92TTDAcumulada);
               AV88Total4 = (decimal)(AV88Total4+AV93TTDAnterior);
               AV89Total5 = (decimal)(AV89Total5+AV95TTImpLibro);
               AV90Total6 = (decimal)(AV90Total6+AV96TTImpPorDepre);
               AV91Total7 = (decimal)(AV91Total7+AV94TTImpDepre);
               if ( ! BRKF53 )
               {
                  BRKF53 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            HF50( false, 51) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("TOTAL GENERAL", 428, Gx_line+22, 521, Gx_line+36, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(552, Gx_line+16, 1042, Gx_line+16, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV91Total7, "ZZZZZZ,ZZZ,ZZ9.99")), 928, Gx_line+24, 1018, Gx_line+35, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV90Total6, "ZZZZZZ,ZZZ,ZZ9.99")), 860, Gx_line+24, 950, Gx_line+35, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89Total5, "ZZZZZZ,ZZZ,ZZ9.99")), 803, Gx_line+24, 893, Gx_line+35, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV88Total4, "ZZZZZZ,ZZZ,ZZ9.99")), 750, Gx_line+24, 840, Gx_line+35, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87Total3, "ZZZZZZ,ZZZ,ZZ9.99")), 673, Gx_line+24, 763, Gx_line+35, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV86Total2, "ZZZZZZ,ZZZ,ZZ9.99")), 605, Gx_line+24, 695, Gx_line+35, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85Total1, "ZZZZZZ,ZZZ,ZZ9.99")), 530, Gx_line+24, 620, Gx_line+35, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+51);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HF50( true, 0) ;
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
         /* 'DETALLEACTIVOS' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV25ACTGrupCod ,
                                              A2103ACTGrupCod ,
                                              A2107ACTHisAno ,
                                              AV29Ano ,
                                              A2108ACTHisMes ,
                                              AV57Mes ,
                                              AV30Clase ,
                                              A426ACTClaCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00F53 */
         pr_default.execute(1, new Object[] {AV30Clase, AV29Ano, AV57Mes, AV25ACTGrupCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKF55 = false;
            A2100ACTActCod = P00F53_A2100ACTActCod[0];
            A426ACTClaCod = P00F53_A426ACTClaCod[0];
            n426ACTClaCod = P00F53_n426ACTClaCod[0];
            A2107ACTHisAno = P00F53_A2107ACTHisAno[0];
            A2108ACTHisMes = P00F53_A2108ACTHisMes[0];
            A2196ACTGrupDsc = P00F53_A2196ACTGrupDsc[0];
            A2103ACTGrupCod = P00F53_A2103ACTGrupCod[0];
            A2104ActActItem = P00F53_A2104ActActItem[0];
            n2104ActActItem = P00F53_n2104ActActItem[0];
            A426ACTClaCod = P00F53_A426ACTClaCod[0];
            n426ACTClaCod = P00F53_n426ACTClaCod[0];
            A2103ACTGrupCod = P00F53_A2103ACTGrupCod[0];
            A2196ACTGrupDsc = P00F53_A2196ACTGrupDsc[0];
            W426ACTClaCod = A426ACTClaCod;
            n426ACTClaCod = false;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00F53_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(P00F53_A2103ACTGrupCod[0], A2103ACTGrupCod) == 0 ) )
            {
               BRKF55 = false;
               A2100ACTActCod = P00F53_A2100ACTActCod[0];
               A2107ACTHisAno = P00F53_A2107ACTHisAno[0];
               A2108ACTHisMes = P00F53_A2108ACTHisMes[0];
               A2196ACTGrupDsc = P00F53_A2196ACTGrupDsc[0];
               A2104ActActItem = P00F53_A2104ActActItem[0];
               n2104ActActItem = P00F53_n2104ActActItem[0];
               A2196ACTGrupDsc = P00F53_A2196ACTGrupDsc[0];
               BRKF55 = true;
               pr_default.readNext(1);
            }
            AV47GrupoCod = A2103ACTGrupCod;
            AV46Grupo = "Total : " + StringUtil.Trim( A2196ACTGrupDsc);
            AV99TValor = 0.00m;
            AV100TValorCalculo = 0.00m;
            AV76TDAcumulada = 0.00m;
            AV77TDAnterior = 0.00m;
            AV79TImpLibro = 0.00m;
            AV80TImpPorDepre = 0.00m;
            AV78TImpDepre = 0.00m;
            HF50( false, 19) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2196ACTGrupDsc, "")), 50, Gx_line+3, 676, Gx_line+18, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            /* Execute user subroutine: 'ACTIVOS' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            HF50( false, 33) ;
            getPrinter().GxDrawLine(540, Gx_line+6, 1030, Gx_line+6, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV78TImpDepre, "ZZZZZZ,ZZZ,ZZ9.99")), 928, Gx_line+10, 1018, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV80TImpPorDepre, "ZZZZZZ,ZZZ,ZZ9.99")), 860, Gx_line+10, 950, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV79TImpLibro, "ZZZZZZ,ZZZ,ZZ9.99")), 803, Gx_line+10, 893, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV77TDAnterior, "ZZZZZZ,ZZZ,ZZ9.99")), 750, Gx_line+10, 840, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV76TDAcumulada, "ZZZZZZ,ZZZ,ZZ9.99")), 673, Gx_line+10, 763, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV100TValorCalculo, "ZZZZZZ,ZZZ,ZZ9.99")), 605, Gx_line+10, 695, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV99TValor, "ZZZZZZ,ZZZ,ZZ9.99")), 530, Gx_line+10, 620, Gx_line+21, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Grupo, "")), 66, Gx_line+8, 520, Gx_line+22, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+33);
            AV97TTValor = (decimal)(AV97TTValor+AV99TValor);
            AV98TTValorCalculo = (decimal)(AV98TTValorCalculo+AV100TValorCalculo);
            AV92TTDAcumulada = (decimal)(AV92TTDAcumulada+AV76TDAcumulada);
            AV93TTDAnterior = (decimal)(AV93TTDAnterior+AV77TDAnterior);
            AV95TTImpLibro = (decimal)(AV95TTImpLibro+AV79TImpLibro);
            AV96TTImpPorDepre = (decimal)(AV96TTImpPorDepre+AV80TImpPorDepre);
            AV94TTImpDepre = (decimal)(AV94TTImpDepre+AV78TImpDepre);
            A426ACTClaCod = W426ACTClaCod;
            n426ACTClaCod = false;
            if ( ! BRKF55 )
            {
               BRKF55 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S125( )
      {
         /* 'ACTIVOS' Routine */
         returnInSub = false;
         /* Using cursor P00F54 */
         pr_default.execute(2, new Object[] {AV30Clase, AV47GrupoCod, AV29Ano, AV57Mes});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKF57 = false;
            A2122ACTActDsc = P00F54_A2122ACTActDsc[0];
            A2100ACTActCod = P00F54_A2100ACTActCod[0];
            A2108ACTHisMes = P00F54_A2108ACTHisMes[0];
            A2107ACTHisAno = P00F54_A2107ACTHisAno[0];
            A2103ACTGrupCod = P00F54_A2103ACTGrupCod[0];
            A426ACTClaCod = P00F54_A426ACTClaCod[0];
            n426ACTClaCod = P00F54_n426ACTClaCod[0];
            A2128ACTActMarca = P00F54_A2128ACTActMarca[0];
            A2129ACTActModelo = P00F54_A2129ACTActModelo[0];
            A2135ACTActSerie = P00F54_A2135ACTActSerie[0];
            A2104ActActItem = P00F54_A2104ActActItem[0];
            n2104ActActItem = P00F54_n2104ActActItem[0];
            A2122ACTActDsc = P00F54_A2122ACTActDsc[0];
            A2103ACTGrupCod = P00F54_A2103ACTGrupCod[0];
            A426ACTClaCod = P00F54_A426ACTClaCod[0];
            n426ACTClaCod = P00F54_n426ACTClaCod[0];
            A2128ACTActMarca = P00F54_A2128ACTActMarca[0];
            A2129ACTActModelo = P00F54_A2129ACTActModelo[0];
            A2135ACTActSerie = P00F54_A2135ACTActSerie[0];
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00F54_A2100ACTActCod[0], A2100ACTActCod) == 0 ) )
            {
               BRKF57 = false;
               A2122ACTActDsc = P00F54_A2122ACTActDsc[0];
               A2108ACTHisMes = P00F54_A2108ACTHisMes[0];
               A2107ACTHisAno = P00F54_A2107ACTHisAno[0];
               A2104ActActItem = P00F54_A2104ActActItem[0];
               n2104ActActItem = P00F54_n2104ActActItem[0];
               A2122ACTActDsc = P00F54_A2122ACTActDsc[0];
               BRKF57 = true;
               pr_default.readNext(2);
            }
            AV32Codigo = A2100ACTActCod;
            AV63Nombre = StringUtil.Trim( A2100ACTActCod) + " - " + StringUtil.Trim( A2122ACTActDsc);
            AV10ACTActDsc = StringUtil.Trim( A2122ACTActDsc);
            AV14ACTActMarca = A2128ACTActMarca;
            AV15ACTActModelo = A2129ACTActModelo;
            AV17ACTActSerie = A2135ACTActSerie;
            AV84TNombre = "Total " + StringUtil.Trim( AV63Nombre);
            AV64nValor = 0.00m;
            AV65nValorCalculo = 0.00m;
            AV58nDAcumulada = 0.00m;
            AV59nDAnterior = 0.00m;
            AV61nImpLibro = 0.00m;
            AV62nImpPorDepre = 0.00m;
            AV60nImpDepre = 0.00m;
            /* Execute user subroutine: 'VALIDAACTIVO' */
            S137 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            if ( AV45FlagExiste == 1 )
            {
               HF50( false, 15) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63Nombre, "")), 7, Gx_line+2, 112, Gx_line+13, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+15);
            }
            /* Execute user subroutine: 'DETALLE' */
            S147 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            if ( AV45FlagExiste == 1 )
            {
               HF50( false, 21) ;
               getPrinter().GxDrawLine(540, Gx_line+3, 1030, Gx_line+3, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60nImpDepre, "ZZZZZZ,ZZZ,ZZ9.99")), 946, Gx_line+6, 1018, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62nImpPorDepre, "ZZZZZZ,ZZZ,ZZ9.99")), 878, Gx_line+6, 950, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61nImpLibro, "ZZZZZZ,ZZZ,ZZ9.99")), 821, Gx_line+6, 893, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59nDAnterior, "ZZZZZZ,ZZZ,ZZ9.99")), 768, Gx_line+6, 840, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58nDAcumulada, "ZZZZZZ,ZZZ,ZZ9.99")), 691, Gx_line+6, 763, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65nValorCalculo, "ZZZZZZ,ZZZ,ZZ9.99")), 623, Gx_line+6, 695, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64nValor, "ZZZZZZ,ZZZ,ZZ9.99")), 548, Gx_line+6, 620, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84TNombre, "")), 124, Gx_line+6, 542, Gx_line+17, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
            }
            if ( StringUtil.StrCmp(AV81Tipo, "R") == 0 )
            {
               HF50( false, 28) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64nValor, "ZZZZZZ,ZZZ,ZZ9.99")), 548, Gx_line+2, 620, Gx_line+13, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65nValorCalculo, "ZZZZZZ,ZZZ,ZZ9.99")), 623, Gx_line+2, 695, Gx_line+13, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58nDAcumulada, "ZZZZZZ,ZZZ,ZZ9.99")), 691, Gx_line+2, 763, Gx_line+13, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59nDAnterior, "ZZZZZZ,ZZZ,ZZ9.99")), 768, Gx_line+2, 840, Gx_line+13, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61nImpLibro, "ZZZZZZ,ZZZ,ZZ9.99")), 821, Gx_line+2, 893, Gx_line+13, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62nImpPorDepre, "ZZZZZZ,ZZZ,ZZ9.99")), 878, Gx_line+2, 950, Gx_line+13, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60nImpDepre, "ZZZZZZ,ZZZ,ZZ9.99")), 946, Gx_line+2, 1018, Gx_line+13, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17ACTActSerie, "")), 426, Gx_line+2, 489, Gx_line+12, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15ACTActModelo, "")), 346, Gx_line+2, 422, Gx_line+12, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10ACTActDsc, "")), 173, Gx_line+2, 354, Gx_line+12, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9ACTActCod, "")), 102, Gx_line+2, 177, Gx_line+12, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ACTActOrd, "")), 51, Gx_line+2, 94, Gx_line+13, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV11ACTActFech, "99/99/99"), 7, Gx_line+2, 39, Gx_line+13, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Costo, "")), 1025, Gx_line+3, 1123, Gx_line+11, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+28);
            }
            if ( ! BRKF57 )
            {
               BRKF57 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S147( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         /* Using cursor P00F55 */
         pr_default.execute(3, new Object[] {AV29Ano, AV57Mes, AV32Codigo, AV30Clase, AV47GrupoCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A2114ACTSGrupCod = P00F55_A2114ACTSGrupCod[0];
            A2108ACTHisMes = P00F55_A2108ACTHisMes[0];
            A2107ACTHisAno = P00F55_A2107ACTHisAno[0];
            A2100ACTActCod = P00F55_A2100ACTActCod[0];
            A2103ACTGrupCod = P00F55_A2103ACTGrupCod[0];
            A426ACTClaCod = P00F55_A426ACTClaCod[0];
            n426ACTClaCod = P00F55_n426ACTClaCod[0];
            A2155ACTSGrupDsc = P00F55_A2155ACTSGrupDsc[0];
            A2156ACTSGrupPor = P00F55_A2156ACTSGrupPor[0];
            A2143ACTDetFecIni = P00F55_A2143ACTDetFecIni[0];
            A2150ACTDetValorNeto = P00F55_A2150ACTDetValorNeto[0];
            A2152ACTDetValorResiduo = P00F55_A2152ACTDetValorResiduo[0];
            A2132ACTActOrd = P00F55_A2132ACTActOrd[0];
            A2123ACTActFech = P00F55_A2123ACTActFech[0];
            A2144ACTDetMarca = P00F55_A2144ACTDetMarca[0];
            A2145ACTDetModelo = P00F55_A2145ACTDetModelo[0];
            A2147ACTDetSerie = P00F55_A2147ACTDetSerie[0];
            A79COSCod = P00F55_A79COSCod[0];
            A2104ActActItem = P00F55_A2104ActActItem[0];
            n2104ActActItem = P00F55_n2104ActActItem[0];
            A2103ACTGrupCod = P00F55_A2103ACTGrupCod[0];
            A426ACTClaCod = P00F55_A426ACTClaCod[0];
            n426ACTClaCod = P00F55_n426ACTClaCod[0];
            A2132ACTActOrd = P00F55_A2132ACTActOrd[0];
            A2123ACTActFech = P00F55_A2123ACTActFech[0];
            A79COSCod = P00F55_A79COSCod[0];
            A2114ACTSGrupCod = P00F55_A2114ACTSGrupCod[0];
            A2143ACTDetFecIni = P00F55_A2143ACTDetFecIni[0];
            A2150ACTDetValorNeto = P00F55_A2150ACTDetValorNeto[0];
            A2152ACTDetValorResiduo = P00F55_A2152ACTDetValorResiduo[0];
            A2144ACTDetMarca = P00F55_A2144ACTDetMarca[0];
            A2145ACTDetModelo = P00F55_A2145ACTDetModelo[0];
            A2147ACTDetSerie = P00F55_A2147ACTDetSerie[0];
            A2155ACTSGrupDsc = P00F55_A2155ACTSGrupDsc[0];
            A2156ACTSGrupPor = P00F55_A2156ACTSGrupPor[0];
            AV9ACTActCod = A2100ACTActCod;
            AV13ActActItem = A2104ActActItem;
            AV26ACTSGrupDsc = StringUtil.Trim( A2155ACTSGrupDsc);
            AV67Porcentaje = A2156ACTSGrupPor;
            AV20ACTDetFecIni = A2143ACTDetFecIni;
            /* Execute user subroutine: 'REPARACIONES' */
            S159 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV101Valor = (decimal)((A2150ACTDetValorNeto+AV8ACTDetValorReparacion+AV24ACTDetValorCompras));
            AV102ValorCalculo = (decimal)((A2150ACTDetValorNeto+AV8ACTDetValorReparacion+AV24ACTDetValorCompras)-(A2152ACTDetValorResiduo));
            AV16ACTActOrd = A2132ACTActOrd;
            AV11ACTActFech = A2123ACTActFech;
            AV21ACTDetMarca = A2144ACTDetMarca;
            AV22ACTDetModelo = A2145ACTDetModelo;
            AV23ACTDetSerie = A2147ACTDetSerie;
            AV48ImpDepre = 0.00m;
            AV33CosCod = A79COSCod;
            if ( AV45FlagExiste == 1 )
            {
               /* Execute user subroutine: 'VALIDADESCOMPOSICION' */
               S169 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  returnInSub = true;
                  if (true) return;
               }
            }
            /* Execute user subroutine: 'SALDOINICIAL' */
            S179 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'SALDOMENSUAL' */
            S189 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'ULTIMOCENTROCOSTO' */
            S199 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV49ImpLibro = (decimal)(AV101Valor-(AV35DAcumulada+AV48ImpDepre));
            AV50ImpPorDep = (decimal)((AV101Valor)-(A2152ACTDetValorResiduo+AV35DAcumulada+AV48ImpDepre));
            if ( StringUtil.StrCmp(AV81Tipo, "D") == 0 )
            {
               HF50( false, 17) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV11ACTActFech, "99/99/99"), 7, Gx_line+3, 39, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ACTActOrd, "")), 51, Gx_line+3, 94, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9ACTActCod, "")), 102, Gx_line+3, 177, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22ACTDetModelo, "")), 346, Gx_line+3, 422, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23ACTDetSerie, "")), 426, Gx_line+3, 489, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Costo, "")), 1025, Gx_line+4, 1123, Gx_line+12, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68Porcentaje2, "ZZ9.99")), 503, Gx_line+3, 529, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV101Valor, "ZZZZZZ,ZZZ,ZZ9.99")), 548, Gx_line+3, 620, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV102ValorCalculo, "ZZZZZZ,ZZZ,ZZ9.99")), 623, Gx_line+3, 695, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35DAcumulada, "ZZZZZZ,ZZZ,ZZ9.99")), 691, Gx_line+3, 763, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36DAnterior, "ZZZZZZ,ZZZ,ZZ9.99")), 768, Gx_line+3, 840, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49ImpLibro, "ZZZZZZ,ZZZ,ZZ9.99")), 821, Gx_line+3, 893, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50ImpPorDep, "ZZZZZZ,ZZZ,ZZ9.99")), 878, Gx_line+3, 950, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48ImpDepre, "ZZZZZZ,ZZZ,ZZ9.99")), 946, Gx_line+3, 1018, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26ACTSGrupDsc, "")), 173, Gx_line+3, 354, Gx_line+13, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
            }
            AV64nValor = (decimal)(AV64nValor+AV101Valor);
            AV65nValorCalculo = (decimal)(AV65nValorCalculo+AV102ValorCalculo);
            AV58nDAcumulada = (decimal)(AV58nDAcumulada+AV35DAcumulada);
            AV59nDAnterior = (decimal)(AV59nDAnterior+AV36DAnterior);
            AV61nImpLibro = (decimal)(AV61nImpLibro+AV49ImpLibro);
            AV62nImpPorDepre = (decimal)(AV62nImpPorDepre+AV50ImpPorDep);
            AV60nImpDepre = (decimal)(AV60nImpDepre+AV48ImpDepre);
            AV99TValor = (decimal)(AV99TValor+AV101Valor);
            AV100TValorCalculo = (decimal)(AV100TValorCalculo+AV102ValorCalculo);
            AV76TDAcumulada = (decimal)(AV76TDAcumulada+AV35DAcumulada);
            AV77TDAnterior = (decimal)(AV77TDAnterior+AV36DAnterior);
            AV79TImpLibro = (decimal)(AV79TImpLibro+AV49ImpLibro);
            AV80TImpPorDepre = (decimal)(AV80TImpPorDepre+AV50ImpPorDep);
            AV78TImpDepre = (decimal)(AV78TImpDepre+AV48ImpDepre);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S179( )
      {
         /* 'SALDOINICIAL' Routine */
         returnInSub = false;
         AV35DAcumulada = 0.00m;
         /* Optimized group. */
         /* Using cursor P00F56 */
         pr_default.execute(4, new Object[] {AV9ACTActCod, AV13ActActItem, AV42FechaIni});
         c2189ACTHisDepre = P00F56_A2189ACTHisDepre[0];
         pr_default.close(4);
         AV35DAcumulada = (decimal)(AV35DAcumulada+c2189ACTHisDepre);
         /* End optimized group. */
         AV36DAnterior = 0.00m;
         /* Using cursor P00F57 */
         pr_default.execute(5, new Object[] {AV53jAnoAnt, AV54jMesAnt, AV9ACTActCod, AV13ActActItem});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A2104ActActItem = P00F57_A2104ActActItem[0];
            n2104ActActItem = P00F57_n2104ActActItem[0];
            A2100ACTActCod = P00F57_A2100ACTActCod[0];
            A2108ACTHisMes = P00F57_A2108ACTHisMes[0];
            A2107ACTHisAno = P00F57_A2107ACTHisAno[0];
            A2189ACTHisDepre = P00F57_A2189ACTHisDepre[0];
            AV36DAnterior = A2189ACTHisDepre;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
      }

      protected void S189( )
      {
         /* 'SALDOMENSUAL' Routine */
         returnInSub = false;
         AV74SaldoMes = 0.00m;
         /* Using cursor P00F58 */
         pr_default.execute(6, new Object[] {AV29Ano, AV57Mes, AV9ACTActCod, AV13ActActItem});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A2104ActActItem = P00F58_A2104ActActItem[0];
            n2104ActActItem = P00F58_n2104ActActItem[0];
            A2100ACTActCod = P00F58_A2100ACTActCod[0];
            A2108ACTHisMes = P00F58_A2108ACTHisMes[0];
            A2107ACTHisAno = P00F58_A2107ACTHisAno[0];
            A2189ACTHisDepre = P00F58_A2189ACTHisDepre[0];
            AV48ImpDepre = A2189ACTHisDepre;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(6);
      }

      protected void S199( )
      {
         /* 'ULTIMOCENTROCOSTO' Routine */
         returnInSub = false;
         AV34Costo = "";
         /* Using cursor P00F59 */
         pr_default.execute(7, new Object[] {AV9ACTActCod, AV43FechaUlt});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A2100ACTActCod = P00F59_A2100ACTActCod[0];
            A2200AMovFec = P00F59_A2200AMovFec[0];
            A2110AMovCosCod = P00F59_A2110AMovCosCod[0];
            n2110AMovCosCod = P00F59_n2110AMovCosCod[0];
            A2109AMovCod = P00F59_A2109AMovCod[0];
            AV33CosCod = A2110AMovCosCod;
            pr_default.readNext(7);
         }
         pr_default.close(7);
         /* Using cursor P00F510 */
         pr_default.execute(8, new Object[] {AV33CosCod});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A79COSCod = P00F510_A79COSCod[0];
            A761COSDsc = P00F510_A761COSDsc[0];
            AV34Costo = A761COSDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(8);
      }

      protected void S169( )
      {
         /* 'VALIDADESCOMPOSICION' Routine */
         returnInSub = false;
         AV68Porcentaje2 = 0.00m;
         /* Using cursor P00F511 */
         pr_default.execute(9, new Object[] {AV9ACTActCod, AV13ActActItem});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A426ACTClaCod = P00F511_A426ACTClaCod[0];
            n426ACTClaCod = P00F511_n426ACTClaCod[0];
            A2103ACTGrupCod = P00F511_A2103ACTGrupCod[0];
            A2114ACTSGrupCod = P00F511_A2114ACTSGrupCod[0];
            A2104ActActItem = P00F511_A2104ActActItem[0];
            n2104ActActItem = P00F511_n2104ActActItem[0];
            A2100ACTActCod = P00F511_A2100ACTActCod[0];
            A2156ACTSGrupPor = P00F511_A2156ACTSGrupPor[0];
            A2156ACTSGrupPor = P00F511_A2156ACTSGrupPor[0];
            AV68Porcentaje2 = A2156ACTSGrupPor;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(9);
      }

      protected void S137( )
      {
         /* 'VALIDAACTIVO' Routine */
         returnInSub = false;
         AV45FlagExiste = 0;
         /* Using cursor P00F512 */
         pr_default.execute(10, new Object[] {AV29Ano, AV57Mes, AV32Codigo});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A2100ACTActCod = P00F512_A2100ACTActCod[0];
            A2108ACTHisMes = P00F512_A2108ACTHisMes[0];
            A2107ACTHisAno = P00F512_A2107ACTHisAno[0];
            A2104ActActItem = P00F512_A2104ActActItem[0];
            n2104ActActItem = P00F512_n2104ActActItem[0];
            AV45FlagExiste = 1;
            pr_default.readNext(10);
         }
         pr_default.close(10);
      }

      protected void S159( )
      {
         /* 'REPARACIONES' Routine */
         returnInSub = false;
         AV8ACTDetValorReparacion = 0;
         AV24ACTDetValorCompras = 0;
         /* Using cursor P00F513 */
         pr_default.execute(11, new Object[] {AV9ACTActCod, AV20ACTDetFecIni, AV43FechaUlt});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A2204AMRepFec = P00F513_A2204AMRepFec[0];
            A2100ACTActCod = P00F513_A2100ACTActCod[0];
            A2209AMRepValor = P00F513_A2209AMRepValor[0];
            A2104ActActItem = P00F513_A2104ActActItem[0];
            n2104ActActItem = P00F513_n2104ActActItem[0];
            A2112AMRepCod = P00F513_A2112AMRepCod[0];
            AV8ACTDetValorReparacion = (decimal)(AV8ACTDetValorReparacion+((String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem))||P00F513_n2104ActActItem[0] ? NumberUtil.Round( (A2209AMRepValor*AV67Porcentaje)/ (decimal)(100), 2) : ((StringUtil.StrCmp(A2104ActActItem, AV13ActActItem)==0) ? A2209AMRepValor : (decimal)(0)))));
            pr_default.readNext(11);
         }
         pr_default.close(11);
         /* Using cursor P00F514 */
         pr_default.execute(12, new Object[] {AV9ACTActCod, AV20ACTDetFecIni, AV43FechaUlt});
         while ( (pr_default.getStatus(12) != 101) )
         {
            A2218ACTRevFec = P00F514_A2218ACTRevFec[0];
            A2100ACTActCod = P00F514_A2100ACTActCod[0];
            A2217ActRevCosto = P00F514_A2217ActRevCosto[0];
            A2104ActActItem = P00F514_A2104ActActItem[0];
            n2104ActActItem = P00F514_n2104ActActItem[0];
            A2113ACTRevCod = P00F514_A2113ACTRevCod[0];
            AV24ACTDetValorCompras = (decimal)(AV24ACTDetValorCompras+((String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem))||P00F514_n2104ActActItem[0] ? NumberUtil.Round( (A2217ActRevCosto*AV67Porcentaje)/ (decimal)(100), 2) : ((StringUtil.StrCmp(A2104ActActItem, AV13ActActItem)==0) ? A2217ActRevCosto : (decimal)(0)))));
            pr_default.readNext(12);
         }
         pr_default.close(12);
      }

      protected void HF50( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 1005, Gx_line+35, 1037, Gx_line+49, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 1005, Gx_line+53, 1049, Gx_line+67, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 1005, Gx_line+18, 1044, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1071, Gx_line+53, 1110, Gx_line+68, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1051, Gx_line+35, 1108, Gx_line+49, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1063, Gx_line+18, 1110, Gx_line+33, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83Titulo, "")), 347, Gx_line+15, 803, Gx_line+40, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+84, 1123, Gx_line+130, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("COD.EQUIPO", 111, Gx_line+102, 166, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FECHA", 9, Gx_line+102, 37, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38Empresa, "")), 18, Gx_line+16, 243, Gx_line+34, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39EmpRUC, "")), 18, Gx_line+33, 188, Gx_line+51, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Año :", 464, Gx_line+52, 510, Gx_line+72, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Mes :", 577, Gx_line+52, 623, Gx_line+72, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV29Ano), "ZZZ9")), 520, Gx_line+52, 558, Gx_line+72, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31cMes, "")), 625, Gx_line+52, 735, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("O.COMPRA", 48, Gx_line+102, 94, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("MODELO", 369, Gx_line+102, 406, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° SERIE", 434, Gx_line+102, 474, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("% ", 513, Gx_line+96, 527, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("VALOR", 576, Gx_line+96, 605, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("ACTIVO", 575, Gx_line+109, 607, Gx_line+119, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("VALOR", 644, Gx_line+88, 673, Gx_line+98, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("BASE", 648, Gx_line+102, 670, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("CALCULO", 639, Gx_line+116, 679, Gx_line+126, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("VALOR", 854, Gx_line+88, 883, Gx_line+98, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("ACUMULADA", 702, Gx_line+109, 755, Gx_line+119, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DEPRECIACION", 770, Gx_line+88, 836, Gx_line+98, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("ACUMULADA", 776, Gx_line+102, 829, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("MES ANTERIOR", 770, Gx_line+116, 836, Gx_line+126, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DISTRIBUIDO", 491, Gx_line+109, 551, Gx_line+119, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DEPRECIACION", 696, Gx_line+96, 762, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("LIBROS", 852, Gx_line+116, 885, Gx_line+126, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("VALOR", 908, Gx_line+88, 937, Gx_line+98, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("POR", 914, Gx_line+102, 933, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DEPRECIAR", 899, Gx_line+116, 949, Gx_line+126, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("EN", 863, Gx_line+102, 875, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DEPRECIACION", 951, Gx_line+88, 1017, Gx_line+98, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DEL", 974, Gx_line+102, 992, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("MES", 973, Gx_line+116, 992, Gx_line+126, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("CENTRO", 1053, Gx_line+88, 1088, Gx_line+98, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DE", 1065, Gx_line+102, 1077, Gx_line+112, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("COSTOS", 1054, Gx_line+116, 1088, Gx_line+126, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+85, 42, Gx_line+130, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(99, Gx_line+85, 99, Gx_line+130, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(177, Gx_line+85, 177, Gx_line+130, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(349, Gx_line+85, 349, Gx_line+130, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(422, Gx_line+85, 422, Gx_line+130, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(485, Gx_line+85, 485, Gx_line+130, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(553, Gx_line+85, 553, Gx_line+130, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(622, Gx_line+85, 622, Gx_line+130, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(692, Gx_line+85, 692, Gx_line+130, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(765, Gx_line+85, 765, Gx_line+130, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(838, Gx_line+85, 838, Gx_line+130, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(894, Gx_line+85, 894, Gx_line+130, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(949, Gx_line+85, 949, Gx_line+130, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1017, Gx_line+85, 1017, Gx_line+130, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("DESCRIPCIÓN", 229, Gx_line+102, 289, Gx_line+112, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+130);
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
         AV38Empresa = "";
         AV75Session = context.GetSession();
         AV37EmpDir = "";
         AV39EmpRUC = "";
         AV71Ruta = "";
         AV56Logo = "";
         AV105Logo_GXI = "";
         AV41FechaC = "";
         AV42FechaIni = DateTime.MinValue;
         AV43FechaUlt = DateTime.MinValue;
         GXt_date1 = DateTime.MinValue;
         AV83Titulo = "";
         AV31cMes = "";
         GXt_char2 = "";
         scmdbuf = "";
         A426ACTClaCod = "";
         P00F52_A2100ACTActCod = new string[] {""} ;
         P00F52_A2107ACTHisAno = new short[1] ;
         P00F52_A2108ACTHisMes = new short[1] ;
         P00F52_A2184ACTClaDsc = new string[] {""} ;
         P00F52_A426ACTClaCod = new string[] {""} ;
         P00F52_n426ACTClaCod = new bool[] {false} ;
         P00F52_A2104ActActItem = new string[] {""} ;
         P00F52_n2104ActActItem = new bool[] {false} ;
         A2100ACTActCod = "";
         A2184ACTClaDsc = "";
         A2104ActActItem = "";
         AV30Clase = "";
         AV82TipoActivo = "";
         A2103ACTGrupCod = "";
         P00F53_A2100ACTActCod = new string[] {""} ;
         P00F53_A426ACTClaCod = new string[] {""} ;
         P00F53_n426ACTClaCod = new bool[] {false} ;
         P00F53_A2107ACTHisAno = new short[1] ;
         P00F53_A2108ACTHisMes = new short[1] ;
         P00F53_A2196ACTGrupDsc = new string[] {""} ;
         P00F53_A2103ACTGrupCod = new string[] {""} ;
         P00F53_A2104ActActItem = new string[] {""} ;
         P00F53_n2104ActActItem = new bool[] {false} ;
         A2196ACTGrupDsc = "";
         W426ACTClaCod = "";
         AV47GrupoCod = "";
         AV46Grupo = "";
         P00F54_A2122ACTActDsc = new string[] {""} ;
         P00F54_A2100ACTActCod = new string[] {""} ;
         P00F54_A2108ACTHisMes = new short[1] ;
         P00F54_A2107ACTHisAno = new short[1] ;
         P00F54_A2103ACTGrupCod = new string[] {""} ;
         P00F54_A426ACTClaCod = new string[] {""} ;
         P00F54_n426ACTClaCod = new bool[] {false} ;
         P00F54_A2128ACTActMarca = new string[] {""} ;
         P00F54_A2129ACTActModelo = new string[] {""} ;
         P00F54_A2135ACTActSerie = new string[] {""} ;
         P00F54_A2104ActActItem = new string[] {""} ;
         P00F54_n2104ActActItem = new bool[] {false} ;
         A2122ACTActDsc = "";
         A2128ACTActMarca = "";
         A2129ACTActModelo = "";
         A2135ACTActSerie = "";
         AV32Codigo = "";
         AV63Nombre = "";
         AV10ACTActDsc = "";
         AV14ACTActMarca = "";
         AV15ACTActModelo = "";
         AV17ACTActSerie = "";
         AV84TNombre = "";
         AV9ACTActCod = "";
         AV16ACTActOrd = "";
         AV11ACTActFech = DateTime.MinValue;
         AV34Costo = "";
         P00F55_A2114ACTSGrupCod = new string[] {""} ;
         P00F55_A2108ACTHisMes = new short[1] ;
         P00F55_A2107ACTHisAno = new short[1] ;
         P00F55_A2100ACTActCod = new string[] {""} ;
         P00F55_A2103ACTGrupCod = new string[] {""} ;
         P00F55_A426ACTClaCod = new string[] {""} ;
         P00F55_n426ACTClaCod = new bool[] {false} ;
         P00F55_A2155ACTSGrupDsc = new string[] {""} ;
         P00F55_A2156ACTSGrupPor = new decimal[1] ;
         P00F55_A2143ACTDetFecIni = new DateTime[] {DateTime.MinValue} ;
         P00F55_A2150ACTDetValorNeto = new decimal[1] ;
         P00F55_A2152ACTDetValorResiduo = new decimal[1] ;
         P00F55_A2132ACTActOrd = new string[] {""} ;
         P00F55_A2123ACTActFech = new DateTime[] {DateTime.MinValue} ;
         P00F55_A2144ACTDetMarca = new string[] {""} ;
         P00F55_A2145ACTDetModelo = new string[] {""} ;
         P00F55_A2147ACTDetSerie = new string[] {""} ;
         P00F55_A79COSCod = new string[] {""} ;
         P00F55_A2104ActActItem = new string[] {""} ;
         P00F55_n2104ActActItem = new bool[] {false} ;
         A2114ACTSGrupCod = "";
         A2155ACTSGrupDsc = "";
         A2143ACTDetFecIni = DateTime.MinValue;
         A2132ACTActOrd = "";
         A2123ACTActFech = DateTime.MinValue;
         A2144ACTDetMarca = "";
         A2145ACTDetModelo = "";
         A2147ACTDetSerie = "";
         A79COSCod = "";
         AV13ActActItem = "";
         AV26ACTSGrupDsc = "";
         AV20ACTDetFecIni = DateTime.MinValue;
         AV21ACTDetMarca = "";
         AV22ACTDetModelo = "";
         AV23ACTDetSerie = "";
         AV33CosCod = "";
         P00F56_A2189ACTHisDepre = new decimal[1] ;
         P00F57_A2104ActActItem = new string[] {""} ;
         P00F57_n2104ActActItem = new bool[] {false} ;
         P00F57_A2100ACTActCod = new string[] {""} ;
         P00F57_A2108ACTHisMes = new short[1] ;
         P00F57_A2107ACTHisAno = new short[1] ;
         P00F57_A2189ACTHisDepre = new decimal[1] ;
         P00F58_A2104ActActItem = new string[] {""} ;
         P00F58_n2104ActActItem = new bool[] {false} ;
         P00F58_A2100ACTActCod = new string[] {""} ;
         P00F58_A2108ACTHisMes = new short[1] ;
         P00F58_A2107ACTHisAno = new short[1] ;
         P00F58_A2189ACTHisDepre = new decimal[1] ;
         P00F59_A2100ACTActCod = new string[] {""} ;
         P00F59_A2200AMovFec = new DateTime[] {DateTime.MinValue} ;
         P00F59_A2110AMovCosCod = new string[] {""} ;
         P00F59_n2110AMovCosCod = new bool[] {false} ;
         P00F59_A2109AMovCod = new string[] {""} ;
         A2200AMovFec = DateTime.MinValue;
         A2110AMovCosCod = "";
         A2109AMovCod = "";
         P00F510_A79COSCod = new string[] {""} ;
         P00F510_A761COSDsc = new string[] {""} ;
         A761COSDsc = "";
         P00F511_A426ACTClaCod = new string[] {""} ;
         P00F511_n426ACTClaCod = new bool[] {false} ;
         P00F511_A2103ACTGrupCod = new string[] {""} ;
         P00F511_A2114ACTSGrupCod = new string[] {""} ;
         P00F511_A2104ActActItem = new string[] {""} ;
         P00F511_n2104ActActItem = new bool[] {false} ;
         P00F511_A2100ACTActCod = new string[] {""} ;
         P00F511_A2156ACTSGrupPor = new decimal[1] ;
         P00F512_A2100ACTActCod = new string[] {""} ;
         P00F512_A2108ACTHisMes = new short[1] ;
         P00F512_A2107ACTHisAno = new short[1] ;
         P00F512_A2104ActActItem = new string[] {""} ;
         P00F512_n2104ActActItem = new bool[] {false} ;
         P00F513_A2204AMRepFec = new DateTime[] {DateTime.MinValue} ;
         P00F513_A2100ACTActCod = new string[] {""} ;
         P00F513_A2209AMRepValor = new decimal[1] ;
         P00F513_A2104ActActItem = new string[] {""} ;
         P00F513_n2104ActActItem = new bool[] {false} ;
         P00F513_A2112AMRepCod = new string[] {""} ;
         A2204AMRepFec = DateTime.MinValue;
         A2112AMRepCod = "";
         P00F514_A2218ACTRevFec = new DateTime[] {DateTime.MinValue} ;
         P00F514_A2100ACTActCod = new string[] {""} ;
         P00F514_A2217ActRevCosto = new decimal[1] ;
         P00F514_A2104ActActItem = new string[] {""} ;
         P00F514_n2104ActActItem = new bool[] {false} ;
         P00F514_A2113ACTRevCod = new string[] {""} ;
         A2218ACTRevFec = DateTime.MinValue;
         A2113ACTRevCod = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.activosfijos.r_resumendepreciacionmensualpdf__default(),
            new Object[][] {
                new Object[] {
               P00F52_A2100ACTActCod, P00F52_A2107ACTHisAno, P00F52_A2108ACTHisMes, P00F52_A2184ACTClaDsc, P00F52_A426ACTClaCod, P00F52_A2104ActActItem
               }
               , new Object[] {
               P00F53_A2100ACTActCod, P00F53_A426ACTClaCod, P00F53_A2107ACTHisAno, P00F53_A2108ACTHisMes, P00F53_A2196ACTGrupDsc, P00F53_A2103ACTGrupCod, P00F53_A2104ActActItem
               }
               , new Object[] {
               P00F54_A2122ACTActDsc, P00F54_A2100ACTActCod, P00F54_A2108ACTHisMes, P00F54_A2107ACTHisAno, P00F54_A2103ACTGrupCod, P00F54_A426ACTClaCod, P00F54_A2128ACTActMarca, P00F54_A2129ACTActModelo, P00F54_A2135ACTActSerie, P00F54_A2104ActActItem
               }
               , new Object[] {
               P00F55_A2114ACTSGrupCod, P00F55_A2108ACTHisMes, P00F55_A2107ACTHisAno, P00F55_A2100ACTActCod, P00F55_A2103ACTGrupCod, P00F55_A426ACTClaCod, P00F55_n426ACTClaCod, P00F55_A2155ACTSGrupDsc, P00F55_A2156ACTSGrupPor, P00F55_A2143ACTDetFecIni,
               P00F55_A2150ACTDetValorNeto, P00F55_A2152ACTDetValorResiduo, P00F55_A2132ACTActOrd, P00F55_A2123ACTActFech, P00F55_A2144ACTDetMarca, P00F55_A2145ACTDetModelo, P00F55_A2147ACTDetSerie, P00F55_A79COSCod, P00F55_A2104ActActItem
               }
               , new Object[] {
               P00F56_A2189ACTHisDepre
               }
               , new Object[] {
               P00F57_A2104ActActItem, P00F57_A2100ACTActCod, P00F57_A2108ACTHisMes, P00F57_A2107ACTHisAno, P00F57_A2189ACTHisDepre
               }
               , new Object[] {
               P00F58_A2104ActActItem, P00F58_A2100ACTActCod, P00F58_A2108ACTHisMes, P00F58_A2107ACTHisAno, P00F58_A2189ACTHisDepre
               }
               , new Object[] {
               P00F59_A2100ACTActCod, P00F59_A2200AMovFec, P00F59_A2110AMovCosCod, P00F59_n2110AMovCosCod, P00F59_A2109AMovCod
               }
               , new Object[] {
               P00F510_A79COSCod, P00F510_A761COSDsc
               }
               , new Object[] {
               P00F511_A426ACTClaCod, P00F511_n426ACTClaCod, P00F511_A2103ACTGrupCod, P00F511_A2114ACTSGrupCod, P00F511_A2104ActActItem, P00F511_A2100ACTActCod, P00F511_A2156ACTSGrupPor
               }
               , new Object[] {
               P00F512_A2100ACTActCod, P00F512_A2108ACTHisMes, P00F512_A2107ACTHisAno, P00F512_A2104ActActItem
               }
               , new Object[] {
               P00F513_A2204AMRepFec, P00F513_A2100ACTActCod, P00F513_A2209AMRepValor, P00F513_A2104ActActItem, P00F513_n2104ActActItem, P00F513_A2112AMRepCod
               }
               , new Object[] {
               P00F514_A2218ACTRevFec, P00F514_A2100ACTActCod, P00F514_A2217ActRevCosto, P00F514_A2104ActActItem, P00F514_n2104ActActItem, P00F514_A2113ACTRevCod
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
      private short AV29Ano ;
      private short AV57Mes ;
      private short AV53jAnoAnt ;
      private short AV54jMesAnt ;
      private short A2107ACTHisAno ;
      private short A2108ACTHisMes ;
      private short AV45FlagExiste ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal AV85Total1 ;
      private decimal AV86Total2 ;
      private decimal AV87Total3 ;
      private decimal AV88Total4 ;
      private decimal AV89Total5 ;
      private decimal AV90Total6 ;
      private decimal AV91Total7 ;
      private decimal AV97TTValor ;
      private decimal AV98TTValorCalculo ;
      private decimal AV92TTDAcumulada ;
      private decimal AV93TTDAnterior ;
      private decimal AV95TTImpLibro ;
      private decimal AV96TTImpPorDepre ;
      private decimal AV94TTImpDepre ;
      private decimal AV79TImpLibro ;
      private decimal AV99TValor ;
      private decimal AV100TValorCalculo ;
      private decimal AV76TDAcumulada ;
      private decimal AV77TDAnterior ;
      private decimal AV80TImpPorDepre ;
      private decimal AV78TImpDepre ;
      private decimal AV64nValor ;
      private decimal AV65nValorCalculo ;
      private decimal AV58nDAcumulada ;
      private decimal AV59nDAnterior ;
      private decimal AV61nImpLibro ;
      private decimal AV62nImpPorDepre ;
      private decimal AV60nImpDepre ;
      private decimal A2156ACTSGrupPor ;
      private decimal A2150ACTDetValorNeto ;
      private decimal A2152ACTDetValorResiduo ;
      private decimal AV67Porcentaje ;
      private decimal AV101Valor ;
      private decimal AV8ACTDetValorReparacion ;
      private decimal AV24ACTDetValorCompras ;
      private decimal AV102ValorCalculo ;
      private decimal AV48ImpDepre ;
      private decimal AV49ImpLibro ;
      private decimal AV35DAcumulada ;
      private decimal AV50ImpPorDep ;
      private decimal AV68Porcentaje2 ;
      private decimal AV36DAnterior ;
      private decimal c2189ACTHisDepre ;
      private decimal A2189ACTHisDepre ;
      private decimal AV74SaldoMes ;
      private decimal A2209AMRepValor ;
      private decimal A2217ActRevCosto ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV81Tipo ;
      private string AV38Empresa ;
      private string AV37EmpDir ;
      private string AV39EmpRUC ;
      private string AV71Ruta ;
      private string AV41FechaC ;
      private string AV83Titulo ;
      private string AV31cMes ;
      private string GXt_char2 ;
      private string scmdbuf ;
      private string A2155ACTSGrupDsc ;
      private string A79COSCod ;
      private string AV26ACTSGrupDsc ;
      private string AV33CosCod ;
      private string A2110AMovCosCod ;
      private string A761COSDsc ;
      private string Gx_time ;
      private DateTime AV42FechaIni ;
      private DateTime AV43FechaUlt ;
      private DateTime GXt_date1 ;
      private DateTime AV11ACTActFech ;
      private DateTime A2143ACTDetFecIni ;
      private DateTime A2123ACTActFech ;
      private DateTime AV20ACTDetFecIni ;
      private DateTime A2200AMovFec ;
      private DateTime A2204AMRepFec ;
      private DateTime A2218ACTRevFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKF53 ;
      private bool n426ACTClaCod ;
      private bool n2104ActActItem ;
      private bool returnInSub ;
      private bool BRKF55 ;
      private bool BRKF57 ;
      private bool n2110AMovCosCod ;
      private string AV19ACTClaCod ;
      private string AV25ACTGrupCod ;
      private string AV105Logo_GXI ;
      private string A426ACTClaCod ;
      private string A2100ACTActCod ;
      private string A2184ACTClaDsc ;
      private string A2104ActActItem ;
      private string AV30Clase ;
      private string AV82TipoActivo ;
      private string A2103ACTGrupCod ;
      private string A2196ACTGrupDsc ;
      private string W426ACTClaCod ;
      private string AV47GrupoCod ;
      private string AV46Grupo ;
      private string A2122ACTActDsc ;
      private string A2128ACTActMarca ;
      private string A2129ACTActModelo ;
      private string A2135ACTActSerie ;
      private string AV32Codigo ;
      private string AV63Nombre ;
      private string AV10ACTActDsc ;
      private string AV14ACTActMarca ;
      private string AV15ACTActModelo ;
      private string AV17ACTActSerie ;
      private string AV84TNombre ;
      private string AV9ACTActCod ;
      private string AV16ACTActOrd ;
      private string AV34Costo ;
      private string A2114ACTSGrupCod ;
      private string A2132ACTActOrd ;
      private string A2144ACTDetMarca ;
      private string A2145ACTDetModelo ;
      private string A2147ACTDetSerie ;
      private string AV13ActActItem ;
      private string AV21ACTDetMarca ;
      private string AV22ACTDetModelo ;
      private string AV23ACTDetSerie ;
      private string A2109AMovCod ;
      private string A2112AMRepCod ;
      private string A2113ACTRevCod ;
      private string AV56Logo ;
      private IGxSession AV75Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ACTClaCod ;
      private string aP1_ACTGrupCod ;
      private short aP2_Ano ;
      private short aP3_Mes ;
      private string aP4_Tipo ;
      private IDataStoreProvider pr_default ;
      private string[] P00F52_A2100ACTActCod ;
      private short[] P00F52_A2107ACTHisAno ;
      private short[] P00F52_A2108ACTHisMes ;
      private string[] P00F52_A2184ACTClaDsc ;
      private string[] P00F52_A426ACTClaCod ;
      private bool[] P00F52_n426ACTClaCod ;
      private string[] P00F52_A2104ActActItem ;
      private bool[] P00F52_n2104ActActItem ;
      private string[] P00F53_A2100ACTActCod ;
      private string[] P00F53_A426ACTClaCod ;
      private bool[] P00F53_n426ACTClaCod ;
      private short[] P00F53_A2107ACTHisAno ;
      private short[] P00F53_A2108ACTHisMes ;
      private string[] P00F53_A2196ACTGrupDsc ;
      private string[] P00F53_A2103ACTGrupCod ;
      private string[] P00F53_A2104ActActItem ;
      private bool[] P00F53_n2104ActActItem ;
      private string[] P00F54_A2122ACTActDsc ;
      private string[] P00F54_A2100ACTActCod ;
      private short[] P00F54_A2108ACTHisMes ;
      private short[] P00F54_A2107ACTHisAno ;
      private string[] P00F54_A2103ACTGrupCod ;
      private string[] P00F54_A426ACTClaCod ;
      private bool[] P00F54_n426ACTClaCod ;
      private string[] P00F54_A2128ACTActMarca ;
      private string[] P00F54_A2129ACTActModelo ;
      private string[] P00F54_A2135ACTActSerie ;
      private string[] P00F54_A2104ActActItem ;
      private bool[] P00F54_n2104ActActItem ;
      private string[] P00F55_A2114ACTSGrupCod ;
      private short[] P00F55_A2108ACTHisMes ;
      private short[] P00F55_A2107ACTHisAno ;
      private string[] P00F55_A2100ACTActCod ;
      private string[] P00F55_A2103ACTGrupCod ;
      private string[] P00F55_A426ACTClaCod ;
      private bool[] P00F55_n426ACTClaCod ;
      private string[] P00F55_A2155ACTSGrupDsc ;
      private decimal[] P00F55_A2156ACTSGrupPor ;
      private DateTime[] P00F55_A2143ACTDetFecIni ;
      private decimal[] P00F55_A2150ACTDetValorNeto ;
      private decimal[] P00F55_A2152ACTDetValorResiduo ;
      private string[] P00F55_A2132ACTActOrd ;
      private DateTime[] P00F55_A2123ACTActFech ;
      private string[] P00F55_A2144ACTDetMarca ;
      private string[] P00F55_A2145ACTDetModelo ;
      private string[] P00F55_A2147ACTDetSerie ;
      private string[] P00F55_A79COSCod ;
      private string[] P00F55_A2104ActActItem ;
      private bool[] P00F55_n2104ActActItem ;
      private decimal[] P00F56_A2189ACTHisDepre ;
      private string[] P00F57_A2104ActActItem ;
      private bool[] P00F57_n2104ActActItem ;
      private string[] P00F57_A2100ACTActCod ;
      private short[] P00F57_A2108ACTHisMes ;
      private short[] P00F57_A2107ACTHisAno ;
      private decimal[] P00F57_A2189ACTHisDepre ;
      private string[] P00F58_A2104ActActItem ;
      private bool[] P00F58_n2104ActActItem ;
      private string[] P00F58_A2100ACTActCod ;
      private short[] P00F58_A2108ACTHisMes ;
      private short[] P00F58_A2107ACTHisAno ;
      private decimal[] P00F58_A2189ACTHisDepre ;
      private string[] P00F59_A2100ACTActCod ;
      private DateTime[] P00F59_A2200AMovFec ;
      private string[] P00F59_A2110AMovCosCod ;
      private bool[] P00F59_n2110AMovCosCod ;
      private string[] P00F59_A2109AMovCod ;
      private string[] P00F510_A79COSCod ;
      private string[] P00F510_A761COSDsc ;
      private string[] P00F511_A426ACTClaCod ;
      private bool[] P00F511_n426ACTClaCod ;
      private string[] P00F511_A2103ACTGrupCod ;
      private string[] P00F511_A2114ACTSGrupCod ;
      private string[] P00F511_A2104ActActItem ;
      private bool[] P00F511_n2104ActActItem ;
      private string[] P00F511_A2100ACTActCod ;
      private decimal[] P00F511_A2156ACTSGrupPor ;
      private string[] P00F512_A2100ACTActCod ;
      private short[] P00F512_A2108ACTHisMes ;
      private short[] P00F512_A2107ACTHisAno ;
      private string[] P00F512_A2104ActActItem ;
      private bool[] P00F512_n2104ActActItem ;
      private DateTime[] P00F513_A2204AMRepFec ;
      private string[] P00F513_A2100ACTActCod ;
      private decimal[] P00F513_A2209AMRepValor ;
      private string[] P00F513_A2104ActActItem ;
      private bool[] P00F513_n2104ActActItem ;
      private string[] P00F513_A2112AMRepCod ;
      private DateTime[] P00F514_A2218ACTRevFec ;
      private string[] P00F514_A2100ACTActCod ;
      private decimal[] P00F514_A2217ActRevCosto ;
      private string[] P00F514_A2104ActActItem ;
      private bool[] P00F514_n2104ActActItem ;
      private string[] P00F514_A2113ACTRevCod ;
   }

   public class r_resumendepreciacionmensualpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00F52( IGxContext context ,
                                             string AV19ACTClaCod ,
                                             string A426ACTClaCod ,
                                             short A2107ACTHisAno ,
                                             short AV29Ano ,
                                             short A2108ACTHisMes ,
                                             short AV57Mes )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[3];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[ACTActCod], T1.[ACTHisAno], T1.[ACTHisMes], T3.[ACTClaDsc], T2.[ACTClaCod], T1.[ActActItem] FROM (([ACTCOSTODEP] T1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod]) INNER JOIN [ACTCLASE] T3 ON T3.[ACTClaCod] = T2.[ACTClaCod])";
         AddWhere(sWhereString, "(T1.[ACTHisAno] = @AV29Ano)");
         AddWhere(sWhereString, "(T1.[ACTHisMes] = @AV57Mes)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ACTClaCod)) )
         {
            AddWhere(sWhereString, "(T2.[ACTClaCod] = @AV19ACTClaCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[ACTClaCod], T3.[ACTClaDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00F53( IGxContext context ,
                                             string AV25ACTGrupCod ,
                                             string A2103ACTGrupCod ,
                                             short A2107ACTHisAno ,
                                             short AV29Ano ,
                                             short A2108ACTHisMes ,
                                             short AV57Mes ,
                                             string AV30Clase ,
                                             string A426ACTClaCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[4];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[ACTActCod], T2.[ACTClaCod], T1.[ACTHisAno], T1.[ACTHisMes], T3.[ACTGrupDsc], T2.[ACTGrupCod], T1.[ActActItem] FROM (([ACTCOSTODEP] T1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod]) INNER JOIN [ACTGRUPO] T3 ON T3.[ACTClaCod] = T2.[ACTClaCod] AND T3.[ACTGrupCod] = T2.[ACTGrupCod])";
         AddWhere(sWhereString, "(T2.[ACTClaCod] = @AV30Clase)");
         AddWhere(sWhereString, "(T1.[ACTHisAno] = @AV29Ano)");
         AddWhere(sWhereString, "(T1.[ACTHisMes] = @AV57Mes)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ACTGrupCod)) )
         {
            AddWhere(sWhereString, "(T2.[ACTGrupCod] = @AV25ACTGrupCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[ACTClaCod], T2.[ACTGrupCod], T3.[ACTGrupDsc]";
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
                     return conditional_P00F52(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] );
               case 1 :
                     return conditional_P00F53(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00F54;
          prmP00F54 = new Object[] {
          new ParDef("@AV30Clase",GXType.NVarChar,5,0) ,
          new ParDef("@AV47GrupoCod",GXType.NVarChar,5,0) ,
          new ParDef("@AV29Ano",GXType.Int16,4,0) ,
          new ParDef("@AV57Mes",GXType.Int16,2,0)
          };
          Object[] prmP00F55;
          prmP00F55 = new Object[] {
          new ParDef("@AV29Ano",GXType.Int16,4,0) ,
          new ParDef("@AV57Mes",GXType.Int16,2,0) ,
          new ParDef("@AV32Codigo",GXType.NVarChar,20,0) ,
          new ParDef("@AV30Clase",GXType.NVarChar,5,0) ,
          new ParDef("@AV47GrupoCod",GXType.NVarChar,5,0)
          };
          Object[] prmP00F56;
          prmP00F56 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV13ActActItem",GXType.NVarChar,5,0) ,
          new ParDef("@AV42FechaIni",GXType.Date,8,0)
          };
          Object[] prmP00F57;
          prmP00F57 = new Object[] {
          new ParDef("@AV53jAnoAnt",GXType.Int16,4,0) ,
          new ParDef("@AV54jMesAnt",GXType.Int16,2,0) ,
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV13ActActItem",GXType.NVarChar,5,0)
          };
          Object[] prmP00F58;
          prmP00F58 = new Object[] {
          new ParDef("@AV29Ano",GXType.Int16,4,0) ,
          new ParDef("@AV57Mes",GXType.Int16,2,0) ,
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV13ActActItem",GXType.NVarChar,5,0)
          };
          Object[] prmP00F59;
          prmP00F59 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV43FechaUlt",GXType.Date,8,0)
          };
          Object[] prmP00F510;
          prmP00F510 = new Object[] {
          new ParDef("@AV33CosCod",GXType.NChar,10,0)
          };
          Object[] prmP00F511;
          prmP00F511 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV13ActActItem",GXType.NVarChar,5,0)
          };
          Object[] prmP00F512;
          prmP00F512 = new Object[] {
          new ParDef("@AV29Ano",GXType.Int16,4,0) ,
          new ParDef("@AV57Mes",GXType.Int16,2,0) ,
          new ParDef("@AV32Codigo",GXType.NVarChar,20,0)
          };
          Object[] prmP00F513;
          prmP00F513 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV20ACTDetFecIni",GXType.Date,8,0) ,
          new ParDef("@AV43FechaUlt",GXType.Date,8,0)
          };
          Object[] prmP00F514;
          prmP00F514 = new Object[] {
          new ParDef("@AV9ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV20ACTDetFecIni",GXType.Date,8,0) ,
          new ParDef("@AV43FechaUlt",GXType.Date,8,0)
          };
          Object[] prmP00F52;
          prmP00F52 = new Object[] {
          new ParDef("@AV29Ano",GXType.Int16,4,0) ,
          new ParDef("@AV57Mes",GXType.Int16,2,0) ,
          new ParDef("@AV19ACTClaCod",GXType.NVarChar,5,0)
          };
          Object[] prmP00F53;
          prmP00F53 = new Object[] {
          new ParDef("@AV30Clase",GXType.NVarChar,5,0) ,
          new ParDef("@AV29Ano",GXType.Int16,4,0) ,
          new ParDef("@AV57Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25ACTGrupCod",GXType.NVarChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00F52", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F52,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F53", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F53,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F54", "SELECT T2.[ACTActDsc], T1.[ACTActCod], T1.[ACTHisMes], T1.[ACTHisAno], T2.[ACTGrupCod], T2.[ACTClaCod], T2.[ACTActMarca], T2.[ACTActModelo], T2.[ACTActSerie], T1.[ActActItem] FROM ([ACTCOSTODEP] T1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod]) WHERE (T2.[ACTClaCod] = @AV30Clase) AND (T2.[ACTGrupCod] = @AV47GrupoCod) AND (T1.[ACTHisAno] = @AV29Ano) AND (T1.[ACTHisMes] = @AV57Mes) ORDER BY T1.[ACTActCod], T2.[ACTActDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F54,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F55", "SELECT T3.[ACTSGrupCod], T1.[ACTHisMes], T1.[ACTHisAno], T1.[ACTActCod], T2.[ACTGrupCod], T2.[ACTClaCod], T4.[ACTSGrupDsc], T4.[ACTSGrupPor], T3.[ACTDetFecIni], T3.[ACTDetValorNeto], T3.[ACTDetValorResiduo], T2.[ACTActOrd], T2.[ACTActFech], T3.[ACTDetMarca], T3.[ACTDetModelo], T3.[ACTDetSerie], T2.[COSCod], T1.[ActActItem] FROM ((([ACTCOSTODEP] T1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod]) INNER JOIN [ACTACTIVOSDET] T3 ON T3.[ACTActCod] = T1.[ACTActCod] AND T3.[ActActItem] = T1.[ActActItem]) LEFT JOIN [ACTSUBGRUPO] T4 ON T4.[ACTClaCod] = T2.[ACTClaCod] AND T4.[ACTGrupCod] = T2.[ACTGrupCod] AND T4.[ACTSGrupCod] = T3.[ACTSGrupCod]) WHERE (T1.[ACTHisAno] = @AV29Ano and T1.[ACTHisMes] = @AV57Mes and T1.[ACTActCod] = @AV32Codigo) AND (T2.[ACTClaCod] = @AV30Clase) AND (T2.[ACTGrupCod] = @AV47GrupoCod) ORDER BY T1.[ACTHisAno], T1.[ACTHisMes], T1.[ACTActCod], T1.[ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F55,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F56", "SELECT SUM([ACTHisDepre]) FROM [ACTCOSTODEP] WHERE ([ACTActCod] = @AV9ACTActCod and [ActActItem] = @AV13ActActItem) AND ([ActHisFec] < @AV42FechaIni) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F56,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F57", "SELECT [ActActItem], [ACTActCod], [ACTHisMes], [ACTHisAno], [ACTHisDepre] FROM [ACTCOSTODEP] WHERE [ACTHisAno] = @AV53jAnoAnt and [ACTHisMes] = @AV54jMesAnt and [ACTActCod] = @AV9ACTActCod and [ActActItem] = @AV13ActActItem ORDER BY [ACTHisAno], [ACTHisMes], [ACTActCod], [ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F57,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F58", "SELECT [ActActItem], [ACTActCod], [ACTHisMes], [ACTHisAno], [ACTHisDepre] FROM [ACTCOSTODEP] WHERE [ACTHisAno] = @AV29Ano and [ACTHisMes] = @AV57Mes and [ACTActCod] = @AV9ACTActCod and [ActActItem] = @AV13ActActItem ORDER BY [ACTHisAno], [ACTHisMes], [ACTActCod], [ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F58,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F59", "SELECT [ACTActCod], [AMovFec], [AMovCosCod], [AMovCod] FROM [ACTMOVACTIVO] WHERE ([ACTActCod] = @AV9ACTActCod) AND ([AMovFec] <= @AV43FechaUlt) ORDER BY [AMovFec] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F59,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F510", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV33CosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F510,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F511", "SELECT T1.[ACTClaCod], T1.[ACTGrupCod], T1.[ACTSGrupCod], T1.[ActActItem], T1.[ACTActCod], T2.[ACTSGrupPor] FROM ([ACTACTIVOSDET] T1 LEFT JOIN [ACTSUBGRUPO] T2 ON T2.[ACTClaCod] = T1.[ACTClaCod] AND T2.[ACTGrupCod] = T1.[ACTGrupCod] AND T2.[ACTSGrupCod] = T1.[ACTSGrupCod]) WHERE T1.[ACTActCod] = @AV9ACTActCod and T1.[ActActItem] = @AV13ActActItem ORDER BY T1.[ACTActCod], T1.[ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F511,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F512", "SELECT [ACTActCod], [ACTHisMes], [ACTHisAno], [ActActItem] FROM [ACTCOSTODEP] WHERE [ACTHisAno] = @AV29Ano and [ACTHisMes] = @AV57Mes and [ACTActCod] = @AV32Codigo ORDER BY [ACTHisAno], [ACTHisMes], [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F512,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F513", "SELECT [AMRepFec], [ACTActCod], [AMRepValor], [ActActItem], [AMRepCod] FROM [ACTMOVREPARACION] WHERE ([ACTActCod] = @AV9ACTActCod) AND ([AMRepFec] > @AV20ACTDetFecIni) AND ([AMRepFec] <= @AV43FechaUlt) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F513,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F514", "SELECT [ACTRevFec], [ACTActCod], [ActRevCosto], [ActActItem], [ACTRevCod] FROM [ACTRevaluacion] WHERE ([ACTActCod] = @AV9ACTActCod) AND ([ACTRevFec] > @AV20ACTDetFecIni) AND ([ACTRevFec] <= @AV43FechaUlt) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F514,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((string[]) buf[15])[0] = rslt.getVarchar(15);
                ((string[]) buf[16])[0] = rslt.getVarchar(16);
                ((string[]) buf[17])[0] = rslt.getString(17, 10);
                ((string[]) buf[18])[0] = rslt.getVarchar(18);
                return;
             case 4 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 11 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
             case 12 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
