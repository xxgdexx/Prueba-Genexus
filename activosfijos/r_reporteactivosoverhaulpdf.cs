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
   public class r_reporteactivosoverhaulpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "activosfijos.r_reporteactivosoverhaulpdf.aspx")), "activosfijos.r_reporteactivosoverhaulpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "activosfijos.r_reporteactivosoverhaulpdf.aspx")))) ;
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
                  AV69Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
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

      public r_reporteactivosoverhaulpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reporteactivosoverhaulpdf( IGxContext context )
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
         this.AV69Mes = aP5_Mes;
         initialize();
         executePrivate();
         aP0_ACTClaCod=this.AV16ACTClaCod;
         aP1_ACTGrupCod=this.AV27ACTGrupCod;
         aP2_ACTActCod=this.AV8ACTActCod;
         aP3_ActActItem=this.AV11ActActItem;
         aP4_Ano=this.AV38Ano;
         aP5_Mes=this.AV69Mes;
      }

      public short executeUdp( ref string aP0_ACTClaCod ,
                               ref string aP1_ACTGrupCod ,
                               ref string aP2_ACTActCod ,
                               ref string aP3_ActActItem ,
                               ref short aP4_Ano )
      {
         execute(ref aP0_ACTClaCod, ref aP1_ACTGrupCod, ref aP2_ACTActCod, ref aP3_ActActItem, ref aP4_Ano, ref aP5_Mes);
         return AV69Mes ;
      }

      public void executeSubmit( ref string aP0_ACTClaCod ,
                                 ref string aP1_ACTGrupCod ,
                                 ref string aP2_ACTActCod ,
                                 ref string aP3_ActActItem ,
                                 ref short aP4_Ano ,
                                 ref short aP5_Mes )
      {
         r_reporteactivosoverhaulpdf objr_reporteactivosoverhaulpdf;
         objr_reporteactivosoverhaulpdf = new r_reporteactivosoverhaulpdf();
         objr_reporteactivosoverhaulpdf.AV16ACTClaCod = aP0_ACTClaCod;
         objr_reporteactivosoverhaulpdf.AV27ACTGrupCod = aP1_ACTGrupCod;
         objr_reporteactivosoverhaulpdf.AV8ACTActCod = aP2_ACTActCod;
         objr_reporteactivosoverhaulpdf.AV11ActActItem = aP3_ActActItem;
         objr_reporteactivosoverhaulpdf.AV38Ano = aP4_Ano;
         objr_reporteactivosoverhaulpdf.AV69Mes = aP5_Mes;
         objr_reporteactivosoverhaulpdf.context.SetSubmitInitialConfig(context);
         objr_reporteactivosoverhaulpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reporteactivosoverhaulpdf);
         aP0_ACTClaCod=this.AV16ACTClaCod;
         aP1_ACTGrupCod=this.AV27ACTGrupCod;
         aP2_ACTActCod=this.AV8ACTActCod;
         aP3_ActActItem=this.AV11ActActItem;
         aP4_Ano=this.AV38Ano;
         aP5_Mes=this.AV69Mes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reporteactivosoverhaulpdf)stateInfo).executePrivate();
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
            AV50Empresa = AV87Session.Get("Empresa");
            AV49EmpDir = AV87Session.Get("EmpDir");
            AV51EmpRUC = AV87Session.Get("EmpRUC");
            AV83Ruta = AV87Session.Get("RUTA") + "/Logo.jpg";
            AV68Logo = AV83Ruta;
            AV116Logo_GXI = GXDbFile.PathToUrl( AV83Ruta);
            AV95Titulo = "Reporte de Activos en OverHaul";
            GXt_char1 = AV40cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV69Mes, out  GXt_char1) ;
            AV40cMes = ((AV69Mes==0) ? "" : GXt_char1);
            AV78Periodo = "Periodo : " + StringUtil.Trim( AV40cMes) + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV38Ano), 10, 0));
            AV54FechaC = "01/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV69Mes), 10, 0)) + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV38Ano), 10, 0));
            AV55FechaIni = context.localUtil.CToD( AV54FechaC, 2);
            GXt_date2 = AV56FechaUlt;
            new GeneXus.Programs.generales.pobtieneultimodiames(context ).execute(  AV55FechaIni, out  GXt_date2) ;
            AV56FechaUlt = GXt_date2;
            AV93Tipo = "D";
            AV65jAnoAnt = AV38Ano;
            AV66jMesAnt = AV69Mes;
            if ( AV69Mes == 12 )
            {
               AV66jMesAnt = 1;
               AV65jAnoAnt = (short)(AV38Ano-1);
            }
            else
            {
               AV66jMesAnt = (short)(AV69Mes-1);
            }
            AV106TValor = 0;
            AV108TValorOver = 0;
            AV109TValorTotal = 0;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV16ACTClaCod ,
                                                 AV27ACTGrupCod ,
                                                 AV8ACTActCod ,
                                                 AV11ActActItem ,
                                                 AV69Mes ,
                                                 A426ACTClaCod ,
                                                 A2103ACTGrupCod ,
                                                 A2100ACTActCod ,
                                                 A2104ActActItem ,
                                                 A2204AMRepFec ,
                                                 AV38Ano } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00FB2 */
            pr_default.execute(0, new Object[] {AV38Ano, AV16ACTClaCod, AV27ACTGrupCod, AV8ACTActCod, AV11ActActItem, AV69Mes});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A2114ACTSGrupCod = P00FB2_A2114ACTSGrupCod[0];
               A2204AMRepFec = P00FB2_A2204AMRepFec[0];
               A2104ActActItem = P00FB2_A2104ActActItem[0];
               n2104ActActItem = P00FB2_n2104ActActItem[0];
               A2100ACTActCod = P00FB2_A2100ACTActCod[0];
               A2103ACTGrupCod = P00FB2_A2103ACTGrupCod[0];
               A426ACTClaCod = P00FB2_A426ACTClaCod[0];
               A2118ACTActCodEQV = P00FB2_A2118ACTActCodEQV[0];
               A2155ACTSGrupDsc = P00FB2_A2155ACTSGrupDsc[0];
               A2122ACTActDsc = P00FB2_A2122ACTActDsc[0];
               A2156ACTSGrupPor = P00FB2_A2156ACTSGrupPor[0];
               A2112AMRepCod = P00FB2_A2112AMRepCod[0];
               A2103ACTGrupCod = P00FB2_A2103ACTGrupCod[0];
               A426ACTClaCod = P00FB2_A426ACTClaCod[0];
               A2118ACTActCodEQV = P00FB2_A2118ACTActCodEQV[0];
               A2122ACTActDsc = P00FB2_A2122ACTActDsc[0];
               A2114ACTSGrupCod = P00FB2_A2114ACTSGrupCod[0];
               A2155ACTSGrupDsc = P00FB2_A2155ACTSGrupDsc[0];
               A2156ACTSGrupPor = P00FB2_A2156ACTSGrupPor[0];
               AV19ACTDetFecIni = A2204AMRepFec;
               AV17ActCod = A2100ACTActCod;
               AV28ActItem = A2104ActActItem;
               AV18ActCodEQV = StringUtil.Trim( A2118ACTActCodEQV);
               AV29ACTSGrupDsc = StringUtil.Trim( A2155ACTSGrupDsc);
               AV26ActDsc = StringUtil.Trim( A2122ACTActDsc) + " - " + StringUtil.Trim( AV29ACTSGrupDsc);
               AV80Porcentaje = A2156ACTSGrupPor;
               AV110Valor = 0;
               AV113ValorOver = 0;
               AV111ValorActivo = 0;
               /* Execute user subroutine: 'VALORACTIVO' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               AV110Valor = AV24ACTDetValorNeto;
               AV113ValorOver = AV25ACTDetValorReparacion;
               AV111ValorActivo = (decimal)(AV110Valor+AV113ValorOver);
               HFB0( false, 17) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV19ACTDetFecIni, "99/99/99"), 9, Gx_line+3, 41, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ActCodEQV, "")), 59, Gx_line+3, 143, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV110Valor, "ZZZZZZ,ZZZ,ZZ9.99")), 459, Gx_line+3, 538, Gx_line+13, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26ActDsc, "")), 136, Gx_line+3, 391, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV80Porcentaje, "ZZ9.99")), 545, Gx_line+3, 579, Gx_line+13, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV111ValorActivo, "ZZZZZZ,ZZZ,ZZ9.99")), 711, Gx_line+3, 783, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV113ValorOver, "ZZZZZZ,ZZZ,ZZ9.99")), 604, Gx_line+3, 683, Gx_line+13, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               AV106TValor = (decimal)(AV106TValor+AV110Valor);
               AV108TValorOver = (decimal)(AV108TValorOver+AV113ValorOver);
               AV109TValorTotal = (decimal)(AV109TValorTotal+AV111ValorActivo);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            HFB0( false, 65) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV106TValor, "ZZZZZZ,ZZZ,ZZ9.99")), 459, Gx_line+17, 538, Gx_line+31, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(395, Gx_line+10, 788, Gx_line+10, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("TOTAL GENERAL", 298, Gx_line+17, 391, Gx_line+31, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV109TValorTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 664, Gx_line+17, 789, Gx_line+32, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV108TValorOver, "ZZZZZZ,ZZZ,ZZ9.99")), 604, Gx_line+17, 683, Gx_line+31, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+65);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HFB0( true, 0) ;
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
         /* Using cursor P00FB3 */
         pr_default.execute(1, new Object[] {AV17ActCod, AV28ActItem});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A2104ActActItem = P00FB3_A2104ActActItem[0];
            n2104ActActItem = P00FB3_n2104ActActItem[0];
            A2100ACTActCod = P00FB3_A2100ACTActCod[0];
            A2150ACTDetValorNeto = P00FB3_A2150ACTDetValorNeto[0];
            AV24ACTDetValorNeto = A2150ACTDetValorNeto;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         /* Using cursor P00FB4 */
         pr_default.execute(2, new Object[] {AV17ActCod, AV19ACTDetFecIni, AV56FechaUlt});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A2204AMRepFec = P00FB4_A2204AMRepFec[0];
            A2100ACTActCod = P00FB4_A2100ACTActCod[0];
            A2209AMRepValor = P00FB4_A2209AMRepValor[0];
            A2104ActActItem = P00FB4_A2104ActActItem[0];
            n2104ActActItem = P00FB4_n2104ActActItem[0];
            A2112AMRepCod = P00FB4_A2112AMRepCod[0];
            AV25ACTDetValorReparacion = (decimal)(AV25ACTDetValorReparacion+((String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem))||P00FB4_n2104ActActItem[0] ? NumberUtil.Round( (A2209AMRepValor*AV80Porcentaje)/ (decimal)(100), 2) : ((StringUtil.StrCmp(A2104ActActItem, AV11ActActItem)==0) ? A2209AMRepValor : (decimal)(0)))));
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor P00FB5 */
         pr_default.execute(3, new Object[] {AV17ActCod, AV19ACTDetFecIni, AV56FechaUlt});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A2218ACTRevFec = P00FB5_A2218ACTRevFec[0];
            A2100ACTActCod = P00FB5_A2100ACTActCod[0];
            A2217ActRevCosto = P00FB5_A2217ActRevCosto[0];
            A2104ActActItem = P00FB5_A2104ActActItem[0];
            n2104ActActItem = P00FB5_n2104ActActItem[0];
            A2113ACTRevCod = P00FB5_A2113ACTRevCod[0];
            AV23ACTDetValorCompras = (decimal)(AV23ACTDetValorCompras+((String.IsNullOrEmpty(StringUtil.RTrim( A2104ActActItem))||P00FB5_n2104ActActItem[0] ? NumberUtil.Round( (A2217ActRevCosto*AV80Porcentaje)/ (decimal)(100), 2) : ((StringUtil.StrCmp(A2104ActActItem, AV11ActActItem)==0) ? A2217ActRevCosto : (decimal)(0)))));
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void HFB0( bool bFoot ,
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
               getPrinter().GxDrawText("COD. ACTIVO", 65, Gx_line+85, 120, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FECHA", 12, Gx_line+85, 40, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Empresa, "")), 8, Gx_line+14, 233, Gx_line+32, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51EmpRUC, "")), 8, Gx_line+31, 178, Gx_line+49, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78Periodo, "")), 267, Gx_line+46, 560, Gx_line+67, 1+256, 0, 0, 1) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("VALOR ACTIVO", 458, Gx_line+85, 520, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("VALOR ACTIVO", 708, Gx_line+85, 770, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(56, Gx_line+74, 56, Gx_line+105, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(132, Gx_line+75, 132, Gx_line+105, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(433, Gx_line+74, 433, Gx_line+105, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(550, Gx_line+74, 550, Gx_line+104, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("CONCEPTO", 223, Gx_line+85, 269, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+74, 800, Gx_line+105, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95Titulo, "")), 217, Gx_line+18, 606, Gx_line+43, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("%", 561, Gx_line+85, 572, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(581, Gx_line+74, 581, Gx_line+104, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(689, Gx_line+76, 689, Gx_line+106, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("OVERHAUL", 612, Gx_line+85, 659, Gx_line+95, 0+256, 0, 0, 0) ;
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
         AV87Session = context.GetSession();
         AV49EmpDir = "";
         AV51EmpRUC = "";
         AV83Ruta = "";
         AV68Logo = "";
         AV116Logo_GXI = "";
         AV95Titulo = "";
         AV40cMes = "";
         GXt_char1 = "";
         AV78Periodo = "";
         AV54FechaC = "";
         AV55FechaIni = DateTime.MinValue;
         AV56FechaUlt = DateTime.MinValue;
         GXt_date2 = DateTime.MinValue;
         AV93Tipo = "";
         scmdbuf = "";
         A426ACTClaCod = "";
         A2103ACTGrupCod = "";
         A2100ACTActCod = "";
         A2104ActActItem = "";
         A2204AMRepFec = DateTime.MinValue;
         P00FB2_A2114ACTSGrupCod = new string[] {""} ;
         P00FB2_A2204AMRepFec = new DateTime[] {DateTime.MinValue} ;
         P00FB2_A2104ActActItem = new string[] {""} ;
         P00FB2_n2104ActActItem = new bool[] {false} ;
         P00FB2_A2100ACTActCod = new string[] {""} ;
         P00FB2_A2103ACTGrupCod = new string[] {""} ;
         P00FB2_A426ACTClaCod = new string[] {""} ;
         P00FB2_A2118ACTActCodEQV = new string[] {""} ;
         P00FB2_A2155ACTSGrupDsc = new string[] {""} ;
         P00FB2_A2122ACTActDsc = new string[] {""} ;
         P00FB2_A2156ACTSGrupPor = new decimal[1] ;
         P00FB2_A2112AMRepCod = new string[] {""} ;
         A2114ACTSGrupCod = "";
         A2118ACTActCodEQV = "";
         A2155ACTSGrupDsc = "";
         A2122ACTActDsc = "";
         A2112AMRepCod = "";
         AV19ACTDetFecIni = DateTime.MinValue;
         AV17ActCod = "";
         AV28ActItem = "";
         AV18ActCodEQV = "";
         AV29ACTSGrupDsc = "";
         AV26ActDsc = "";
         P00FB3_A2104ActActItem = new string[] {""} ;
         P00FB3_n2104ActActItem = new bool[] {false} ;
         P00FB3_A2100ACTActCod = new string[] {""} ;
         P00FB3_A2150ACTDetValorNeto = new decimal[1] ;
         P00FB4_A2204AMRepFec = new DateTime[] {DateTime.MinValue} ;
         P00FB4_A2100ACTActCod = new string[] {""} ;
         P00FB4_A2209AMRepValor = new decimal[1] ;
         P00FB4_A2104ActActItem = new string[] {""} ;
         P00FB4_n2104ActActItem = new bool[] {false} ;
         P00FB4_A2112AMRepCod = new string[] {""} ;
         P00FB5_A2218ACTRevFec = new DateTime[] {DateTime.MinValue} ;
         P00FB5_A2100ACTActCod = new string[] {""} ;
         P00FB5_A2217ActRevCosto = new decimal[1] ;
         P00FB5_A2104ActActItem = new string[] {""} ;
         P00FB5_n2104ActActItem = new bool[] {false} ;
         P00FB5_A2113ACTRevCod = new string[] {""} ;
         A2218ACTRevFec = DateTime.MinValue;
         A2113ACTRevCod = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.activosfijos.r_reporteactivosoverhaulpdf__default(),
            new Object[][] {
                new Object[] {
               P00FB2_A2114ACTSGrupCod, P00FB2_A2204AMRepFec, P00FB2_A2104ActActItem, P00FB2_n2104ActActItem, P00FB2_A2100ACTActCod, P00FB2_A2103ACTGrupCod, P00FB2_A426ACTClaCod, P00FB2_A2118ACTActCodEQV, P00FB2_A2155ACTSGrupDsc, P00FB2_A2122ACTActDsc,
               P00FB2_A2156ACTSGrupPor, P00FB2_A2112AMRepCod
               }
               , new Object[] {
               P00FB3_A2104ActActItem, P00FB3_A2100ACTActCod, P00FB3_A2150ACTDetValorNeto
               }
               , new Object[] {
               P00FB4_A2204AMRepFec, P00FB4_A2100ACTActCod, P00FB4_A2209AMRepValor, P00FB4_A2104ActActItem, P00FB4_n2104ActActItem, P00FB4_A2112AMRepCod
               }
               , new Object[] {
               P00FB5_A2218ACTRevFec, P00FB5_A2100ACTActCod, P00FB5_A2217ActRevCosto, P00FB5_A2104ActActItem, P00FB5_n2104ActActItem, P00FB5_A2113ACTRevCod
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
      private short AV69Mes ;
      private short AV65jAnoAnt ;
      private short AV66jMesAnt ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal AV106TValor ;
      private decimal AV108TValorOver ;
      private decimal AV109TValorTotal ;
      private decimal A2156ACTSGrupPor ;
      private decimal AV80Porcentaje ;
      private decimal AV110Valor ;
      private decimal AV113ValorOver ;
      private decimal AV111ValorActivo ;
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
      private string AV83Ruta ;
      private string AV95Titulo ;
      private string AV40cMes ;
      private string GXt_char1 ;
      private string AV54FechaC ;
      private string AV93Tipo ;
      private string scmdbuf ;
      private string A2155ACTSGrupDsc ;
      private string AV29ACTSGrupDsc ;
      private string Gx_time ;
      private DateTime AV55FechaIni ;
      private DateTime AV56FechaUlt ;
      private DateTime GXt_date2 ;
      private DateTime A2204AMRepFec ;
      private DateTime AV19ACTDetFecIni ;
      private DateTime A2218ACTRevFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n2104ActActItem ;
      private bool returnInSub ;
      private string AV16ACTClaCod ;
      private string AV27ACTGrupCod ;
      private string AV8ACTActCod ;
      private string AV11ActActItem ;
      private string AV116Logo_GXI ;
      private string AV78Periodo ;
      private string A426ACTClaCod ;
      private string A2103ACTGrupCod ;
      private string A2100ACTActCod ;
      private string A2104ActActItem ;
      private string A2114ACTSGrupCod ;
      private string A2118ACTActCodEQV ;
      private string A2122ACTActDsc ;
      private string A2112AMRepCod ;
      private string AV17ActCod ;
      private string AV28ActItem ;
      private string AV18ActCodEQV ;
      private string AV26ActDsc ;
      private string A2113ACTRevCod ;
      private string AV68Logo ;
      private IGxSession AV87Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ACTClaCod ;
      private string aP1_ACTGrupCod ;
      private string aP2_ACTActCod ;
      private string aP3_ActActItem ;
      private short aP4_Ano ;
      private short aP5_Mes ;
      private IDataStoreProvider pr_default ;
      private string[] P00FB2_A2114ACTSGrupCod ;
      private DateTime[] P00FB2_A2204AMRepFec ;
      private string[] P00FB2_A2104ActActItem ;
      private bool[] P00FB2_n2104ActActItem ;
      private string[] P00FB2_A2100ACTActCod ;
      private string[] P00FB2_A2103ACTGrupCod ;
      private string[] P00FB2_A426ACTClaCod ;
      private string[] P00FB2_A2118ACTActCodEQV ;
      private string[] P00FB2_A2155ACTSGrupDsc ;
      private string[] P00FB2_A2122ACTActDsc ;
      private decimal[] P00FB2_A2156ACTSGrupPor ;
      private string[] P00FB2_A2112AMRepCod ;
      private string[] P00FB3_A2104ActActItem ;
      private bool[] P00FB3_n2104ActActItem ;
      private string[] P00FB3_A2100ACTActCod ;
      private decimal[] P00FB3_A2150ACTDetValorNeto ;
      private DateTime[] P00FB4_A2204AMRepFec ;
      private string[] P00FB4_A2100ACTActCod ;
      private decimal[] P00FB4_A2209AMRepValor ;
      private string[] P00FB4_A2104ActActItem ;
      private bool[] P00FB4_n2104ActActItem ;
      private string[] P00FB4_A2112AMRepCod ;
      private DateTime[] P00FB5_A2218ACTRevFec ;
      private string[] P00FB5_A2100ACTActCod ;
      private decimal[] P00FB5_A2217ActRevCosto ;
      private string[] P00FB5_A2104ActActItem ;
      private bool[] P00FB5_n2104ActActItem ;
      private string[] P00FB5_A2113ACTRevCod ;
   }

   public class r_reporteactivosoverhaulpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FB2( IGxContext context ,
                                             string AV16ACTClaCod ,
                                             string AV27ACTGrupCod ,
                                             string AV8ACTActCod ,
                                             string AV11ActActItem ,
                                             short AV69Mes ,
                                             string A426ACTClaCod ,
                                             string A2103ACTGrupCod ,
                                             string A2100ACTActCod ,
                                             string A2104ActActItem ,
                                             DateTime A2204AMRepFec ,
                                             short AV38Ano )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T3.[ACTSGrupCod], T1.[AMRepFec], T1.[ActActItem], T1.[ACTActCod], T2.[ACTGrupCod], T2.[ACTClaCod], T2.[ACTActCodEQV], T4.[ACTSGrupDsc], T2.[ACTActDsc], T4.[ACTSGrupPor], T1.[AMRepCod] FROM ((([ACTMOVREPARACION] T1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod]) LEFT JOIN [ACTACTIVOSDET] T3 ON T3.[ACTActCod] = T1.[ACTActCod] AND T3.[ActActItem] = T1.[ActActItem]) LEFT JOIN [ACTSUBGRUPO] T4 ON T4.[ACTClaCod] = T2.[ACTClaCod] AND T4.[ACTGrupCod] = T2.[ACTGrupCod] AND T4.[ACTSGrupCod] = T3.[ACTSGrupCod])";
         AddWhere(sWhereString, "(YEAR(T1.[AMRepFec]) = @AV38Ano)");
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
         if ( ! (0==AV69Mes) )
         {
            AddWhere(sWhereString, "(MONTH(T1.[AMRepFec]) = @AV69Mes)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ACTActCod]";
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
                     return conditional_P00FB2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (short)dynConstraints[10] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00FB3;
          prmP00FB3 = new Object[] {
          new ParDef("@AV17ActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV28ActItem",GXType.NVarChar,5,0)
          };
          Object[] prmP00FB4;
          prmP00FB4 = new Object[] {
          new ParDef("@AV17ActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV19ACTDetFecIni",GXType.Date,8,0) ,
          new ParDef("@AV56FechaUlt",GXType.Date,8,0)
          };
          Object[] prmP00FB5;
          prmP00FB5 = new Object[] {
          new ParDef("@AV17ActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV19ACTDetFecIni",GXType.Date,8,0) ,
          new ParDef("@AV56FechaUlt",GXType.Date,8,0)
          };
          Object[] prmP00FB2;
          prmP00FB2 = new Object[] {
          new ParDef("@AV38Ano",GXType.Int16,4,0) ,
          new ParDef("@AV16ACTClaCod",GXType.NVarChar,5,0) ,
          new ParDef("@AV27ACTGrupCod",GXType.NVarChar,5,0) ,
          new ParDef("@AV8ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV11ActActItem",GXType.NVarChar,5,0) ,
          new ParDef("@AV69Mes",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FB2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FB2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FB3", "SELECT [ActActItem], [ACTActCod], [ACTDetValorNeto] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @AV17ActCod and [ActActItem] = @AV28ActItem ORDER BY [ACTActCod], [ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FB3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FB4", "SELECT [AMRepFec], [ACTActCod], [AMRepValor], [ActActItem], [AMRepCod] FROM [ACTMOVREPARACION] WHERE ([ACTActCod] = @AV17ActCod) AND ([AMRepFec] > @AV19ACTDetFecIni) AND ([AMRepFec] <= @AV56FechaUlt) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FB4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FB5", "SELECT [ACTRevFec], [ACTActCod], [ActRevCosto], [ActActItem], [ACTRevCod] FROM [ACTRevaluacion] WHERE ([ACTActCod] = @AV17ActCod) AND ([ACTRevFec] > @AV19ACTDetFecIni) AND ([ACTRevFec] <= @AV56FechaUlt) ORDER BY [ACTActCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FB5,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
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
       }
    }

 }

}
