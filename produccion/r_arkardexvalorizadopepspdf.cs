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
   public class r_arkardexvalorizadopepspdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "produccion.r_arkardexvalorizadopepspdf.aspx")), "produccion.r_arkardexvalorizadopepspdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "produccion.r_arkardexvalorizadopepspdf.aspx")))) ;
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
               AV55LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV81SublCod = (int)(NumberUtil.Val( GetPar( "SublCod"), "."));
                  AV43FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AV10AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
                  AV68Prodcod = GetPar( "Prodcod");
                  AV44FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV46FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
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

      public r_arkardexvalorizadopepspdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_arkardexvalorizadopepspdf( IGxContext context )
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
                           ref DateTime aP5_FDesde ,
                           ref DateTime aP6_FHasta )
      {
         this.AV55LinCod = aP0_LinCod;
         this.AV81SublCod = aP1_SublCod;
         this.AV43FamCod = aP2_FamCod;
         this.AV10AlmCod = aP3_AlmCod;
         this.AV68Prodcod = aP4_Prodcod;
         this.AV44FDesde = aP5_FDesde;
         this.AV46FHasta = aP6_FHasta;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV55LinCod;
         aP1_SublCod=this.AV81SublCod;
         aP2_FamCod=this.AV43FamCod;
         aP3_AlmCod=this.AV10AlmCod;
         aP4_Prodcod=this.AV68Prodcod;
         aP5_FDesde=this.AV44FDesde;
         aP6_FHasta=this.AV46FHasta;
      }

      public DateTime executeUdp( ref int aP0_LinCod ,
                                  ref int aP1_SublCod ,
                                  ref int aP2_FamCod ,
                                  ref int aP3_AlmCod ,
                                  ref string aP4_Prodcod ,
                                  ref DateTime aP5_FDesde )
      {
         execute(ref aP0_LinCod, ref aP1_SublCod, ref aP2_FamCod, ref aP3_AlmCod, ref aP4_Prodcod, ref aP5_FDesde, ref aP6_FHasta);
         return AV46FHasta ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SublCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_AlmCod ,
                                 ref string aP4_Prodcod ,
                                 ref DateTime aP5_FDesde ,
                                 ref DateTime aP6_FHasta )
      {
         r_arkardexvalorizadopepspdf objr_arkardexvalorizadopepspdf;
         objr_arkardexvalorizadopepspdf = new r_arkardexvalorizadopepspdf();
         objr_arkardexvalorizadopepspdf.AV55LinCod = aP0_LinCod;
         objr_arkardexvalorizadopepspdf.AV81SublCod = aP1_SublCod;
         objr_arkardexvalorizadopepspdf.AV43FamCod = aP2_FamCod;
         objr_arkardexvalorizadopepspdf.AV10AlmCod = aP3_AlmCod;
         objr_arkardexvalorizadopepspdf.AV68Prodcod = aP4_Prodcod;
         objr_arkardexvalorizadopepspdf.AV44FDesde = aP5_FDesde;
         objr_arkardexvalorizadopepspdf.AV46FHasta = aP6_FHasta;
         objr_arkardexvalorizadopepspdf.context.SetSubmitInitialConfig(context);
         objr_arkardexvalorizadopepspdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_arkardexvalorizadopepspdf);
         aP0_LinCod=this.AV55LinCod;
         aP1_SublCod=this.AV81SublCod;
         aP2_FamCod=this.AV43FamCod;
         aP3_AlmCod=this.AV10AlmCod;
         aP4_Prodcod=this.AV68Prodcod;
         aP5_FDesde=this.AV44FDesde;
         aP6_FHasta=this.AV46FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_arkardexvalorizadopepspdf)stateInfo).executePrivate();
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
            AV41Empresa = AV80Session.Get("Empresa");
            AV40EmpDir = AV80Session.Get("EmpDir");
            AV42EmpRUC = AV80Session.Get("EmpRUC");
            AV71Ruta = AV80Session.Get("RUTA") + "/Logo.jpg";
            AV56Logo = AV71Ruta;
            AV115Logo_GXI = GXDbFile.PathToUrl( AV71Ruta);
            AV110UsuCod = AV80Session.Get("UsuCod");
            AV102Titulo = "Kardex Valorizado";
            AV11Ano = (short)(DateTimeUtil.Year( AV44FDesde));
            AV57Mes = (short)(DateTimeUtil.Month( AV44FDesde));
            AV58Mes2 = (short)(AV57Mes-1);
            AV12Ano2 = AV11Ano;
            if ( AV57Mes == 1 )
            {
               AV58Mes2 = 12;
               AV12Ano2 = (short)(AV11Ano-1);
            }
            /* Using cursor P00FO2 */
            pr_default.execute(0, new Object[] {AV10AlmCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A63AlmCod = P00FO2_A63AlmCod[0];
               A436AlmDsc = P00FO2_A436AlmDsc[0];
               AV9Almacen = A436AlmDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV47Filtro1 = "(Todos)";
            AV48Filtro2 = "(Todos)";
            /* Using cursor P00FO3 */
            pr_default.execute(1, new Object[] {AV55LinCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A52LinCod = P00FO3_A52LinCod[0];
               A1153LinDsc = P00FO3_A1153LinDsc[0];
               AV47Filtro1 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00FO4 */
            pr_default.execute(2, new Object[] {AV68Prodcod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A28ProdCod = P00FO4_A28ProdCod[0];
               A55ProdDsc = P00FO4_A55ProdDsc[0];
               AV48Filtro2 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Execute user subroutine: 'CARGADATOS' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            context.CommitDataStores("produccion.r_arkardexvalorizadopepspdf",pr_default);
            AV17CanSInicial = 0;
            AV25CanUInicial = 0;
            AV21CanTInicial = 0;
            AV16CanSIngreso = 0;
            AV24CanUIngreso = 0;
            AV20CanTIngreso = 0;
            AV19CanSSalida = 0;
            AV27CanUSalida = 0;
            AV23CanTSalida = 0;
            AV18CanSSaldo = 0;
            AV26CanUSaldo = 0;
            AV22CanTSaldo = 0;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV55LinCod ,
                                                 AV81SublCod ,
                                                 AV43FamCod ,
                                                 AV68Prodcod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A28ProdCod ,
                                                 A21MvAlm ,
                                                 AV10AlmCod ,
                                                 A1158LinStk ,
                                                 A1269MvAlmCos } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00FO5 */
            pr_default.execute(3, new Object[] {AV10AlmCod, AV55LinCod, AV81SublCod, AV43FamCod, AV68Prodcod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               BRKFO6 = false;
               A13MvATip = P00FO5_A13MvATip[0];
               A14MvACod = P00FO5_A14MvACod[0];
               A49UniCod = P00FO5_A49UniCod[0];
               A55ProdDsc = P00FO5_A55ProdDsc[0];
               A28ProdCod = P00FO5_A28ProdCod[0];
               A1269MvAlmCos = P00FO5_A1269MvAlmCos[0];
               A1158LinStk = P00FO5_A1158LinStk[0];
               A21MvAlm = P00FO5_A21MvAlm[0];
               A50FamCod = P00FO5_A50FamCod[0];
               n50FamCod = P00FO5_n50FamCod[0];
               A51SublCod = P00FO5_A51SublCod[0];
               n51SublCod = P00FO5_n51SublCod[0];
               A52LinCod = P00FO5_A52LinCod[0];
               A1997UniAbr = P00FO5_A1997UniAbr[0];
               A30MvADItem = P00FO5_A30MvADItem[0];
               A21MvAlm = P00FO5_A21MvAlm[0];
               A1269MvAlmCos = P00FO5_A1269MvAlmCos[0];
               A49UniCod = P00FO5_A49UniCod[0];
               A55ProdDsc = P00FO5_A55ProdDsc[0];
               A50FamCod = P00FO5_A50FamCod[0];
               n50FamCod = P00FO5_n50FamCod[0];
               A51SublCod = P00FO5_A51SublCod[0];
               n51SublCod = P00FO5_n51SublCod[0];
               A52LinCod = P00FO5_A52LinCod[0];
               A1997UniAbr = P00FO5_A1997UniAbr[0];
               A1158LinStk = P00FO5_A1158LinStk[0];
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00FO5_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRKFO6 = false;
                  A13MvATip = P00FO5_A13MvATip[0];
                  A14MvACod = P00FO5_A14MvACod[0];
                  A55ProdDsc = P00FO5_A55ProdDsc[0];
                  A30MvADItem = P00FO5_A30MvADItem[0];
                  A55ProdDsc = P00FO5_A55ProdDsc[0];
                  BRKFO6 = true;
                  pr_default.readNext(3);
               }
               AV69ProdCodC = StringUtil.Trim( A28ProdCod);
               AV70Producto = A55ProdDsc;
               AV109UniAbr = A1997UniAbr;
               AV18CanSSaldo = 0;
               AV26CanUSaldo = 0;
               AV22CanTSaldo = 0;
               AV83TCanSInicial = 0;
               AV92TCanUInicial = 0;
               AV88TCanTInicial = 0;
               AV82TCanSIngreso = 0;
               AV91TCanUIngreso = 0;
               AV87TCanTIngreso = 0;
               AV85TCanSSalida = 0;
               AV94TCanUSalida = 0;
               AV90TCanTSalida = 0;
               /* Execute user subroutine: 'VALIDA' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  this.cleanup();
                  if (true) return;
               }
               if ( AV50Flag == 0 )
               {
                  HFO0( false, 22) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Producto : ", 25, Gx_line+5, 82, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70Producto, "")), 197, Gx_line+2, 629, Gx_line+20, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV109UniAbr, "")), 639, Gx_line+5, 682, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69ProdCodC, "@!")), 81, Gx_line+2, 194, Gx_line+20, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+22);
               }
               /* Execute user subroutine: 'SALDOINICIAL' */
               S151 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'DETALLEMOVIMIENTOS' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  this.cleanup();
                  if (true) return;
               }
               if ( ( AV50Flag == 0 ) || ( AV77Saldo != Convert.ToDecimal( 0 )) )
               {
                  AV26CanUSaldo = ((Convert.ToDecimal(0)==AV18CanSSaldo) ? (decimal)(0) : NumberUtil.Round( AV22CanTSaldo/ (decimal)(AV18CanSSaldo), 4));
                  AV86TCantidad = (decimal)(AV86TCantidad+AV18CanSSaldo);
                  AV34CostoTotal = (decimal)(AV34CostoTotal+AV22CanTSaldo);
                  HFO0( false, 34) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70Producto, "")), 111, Gx_line+9, 399, Gx_line+27, 2, 0, 0, 0) ;
                  getPrinter().GxDrawLine(403, Gx_line+7, 1110, Gx_line+7, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18CanSSaldo, "ZZZZ,ZZZ,ZZ9.9999")), 903, Gx_line+13, 993, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV26CanUSaldo, "ZZZZ,ZZZ,ZZ9.9999")), 961, Gx_line+13, 1051, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV22CanTSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 1017, Gx_line+13, 1107, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV82TCanSIngreso, "ZZZZ,ZZZ,ZZ9.9999")), 555, Gx_line+13, 645, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87TCanTIngreso, "ZZZZZZ,ZZZ,ZZ9.99")), 668, Gx_line+13, 758, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV90TCanTSalida, "ZZZZZZ,ZZZ,ZZ9.99")), 842, Gx_line+13, 932, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85TCanSSalida, "ZZZZ,ZZZ,ZZ9.9999")), 729, Gx_line+13, 819, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV83TCanSInicial, "ZZZZ,ZZZ,ZZ9.9999")), 369, Gx_line+14, 459, Gx_line+27, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV92TCanUInicial, "ZZZZ,ZZZ,ZZ9.9999")), 429, Gx_line+14, 519, Gx_line+27, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV88TCanTInicial, "ZZZZZZ,ZZZ,ZZ9.99")), 495, Gx_line+14, 585, Gx_line+27, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV91TCanUIngreso, "ZZZZ,ZZZ,ZZ9.9999")), 615, Gx_line+13, 705, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV94TCanUSalida, "ZZZZ,ZZZ,ZZ9.9999")), 785, Gx_line+13, 875, Gx_line+26, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+34);
               }
               if ( ! BRKFO6 )
               {
                  BRKFO6 = true;
                  pr_default.readNext(3);
               }
            }
            pr_default.close(3);
            HFO0( false, 41) ;
            getPrinter().GxDrawLine(784, Gx_line+13, 1108, Gx_line+13, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34CostoTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 1018, Gx_line+22, 1108, Gx_line+35, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Totales", 765, Gx_line+22, 805, Gx_line+35, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV86TCantidad, "ZZZZ,ZZZ,ZZ9.9999")), 903, Gx_line+22, 993, Gx_line+35, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+41);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HFO0( true, 0) ;
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
         /* 'VALIDA' Routine */
         returnInSub = false;
         AV50Flag = 1;
         /* Using cursor P00FO6 */
         pr_default.execute(4, new Object[] {AV44FDesde, AV69ProdCodC, AV10AlmCod, AV46FHasta});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A21MvAlm = P00FO6_A21MvAlm[0];
            A1370MVSts = P00FO6_A1370MVSts[0];
            A25MvAFec = P00FO6_A25MvAFec[0];
            A28ProdCod = P00FO6_A28ProdCod[0];
            A14MvACod = P00FO6_A14MvACod[0];
            A13MvATip = P00FO6_A13MvATip[0];
            A30MvADItem = P00FO6_A30MvADItem[0];
            A21MvAlm = P00FO6_A21MvAlm[0];
            A1370MVSts = P00FO6_A1370MVSts[0];
            A25MvAFec = P00FO6_A25MvAFec[0];
            AV50Flag = 0;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /* Using cursor P00FO7 */
         pr_default.execute(5, new Object[] {AV10AlmCod, AV44FDesde, AV69ProdCodC});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A7SalFCosProdCod = P00FO7_A7SalFCosProdCod[0];
            A1835SalFCosFecha = P00FO7_A1835SalFCosFecha[0];
            A2SalFCosAlmCod = P00FO7_A2SalFCosAlmCod[0];
            A3SalFCosAlmAno = P00FO7_A3SalFCosAlmAno[0];
            A4SalFCosAlmMes = P00FO7_A4SalFCosAlmMes[0];
            A5SalFCosMVTip = P00FO7_A5SalFCosMVTip[0];
            A6SalFCosMVCod = P00FO7_A6SalFCosMVCod[0];
            AV50Flag = 0;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S121( )
      {
         /* 'DETALLEMOVIMIENTOS' Routine */
         returnInSub = false;
         /* Using cursor P00FO8 */
         pr_default.execute(6, new Object[] {AV44FDesde, AV69ProdCodC, AV10AlmCod, AV46FHasta});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A22MvAMov = P00FO8_A22MvAMov[0];
            A21MvAlm = P00FO8_A21MvAlm[0];
            A1370MVSts = P00FO8_A1370MVSts[0];
            A25MvAFec = P00FO8_A25MvAFec[0];
            A28ProdCod = P00FO8_A28ProdCod[0];
            A1278MvARef = P00FO8_A1278MvARef[0];
            A1276MvAOcom = P00FO8_A1276MvAOcom[0];
            A24DocNum = P00FO8_A24DocNum[0];
            n24DocNum = P00FO8_n24DocNum[0];
            A1248MvADCant = P00FO8_A1248MvADCant[0];
            A1237MovAbr = P00FO8_A1237MovAbr[0];
            n1237MovAbr = P00FO8_n1237MovAbr[0];
            A1286MvATMov = P00FO8_A1286MvATMov[0];
            A1250MVADPrecio = P00FO8_A1250MVADPrecio[0];
            A1249MVADCosto = P00FO8_A1249MVADCosto[0];
            A14MvACod = P00FO8_A14MvACod[0];
            A13MvATip = P00FO8_A13MvATip[0];
            A30MvADItem = P00FO8_A30MvADItem[0];
            A22MvAMov = P00FO8_A22MvAMov[0];
            A21MvAlm = P00FO8_A21MvAlm[0];
            A1370MVSts = P00FO8_A1370MVSts[0];
            A25MvAFec = P00FO8_A25MvAFec[0];
            A1278MvARef = P00FO8_A1278MvARef[0];
            A1276MvAOcom = P00FO8_A1276MvAOcom[0];
            A24DocNum = P00FO8_A24DocNum[0];
            n24DocNum = P00FO8_n24DocNum[0];
            A1286MvATMov = P00FO8_A1286MvATMov[0];
            A1237MovAbr = P00FO8_A1237MovAbr[0];
            n1237MovAbr = P00FO8_n1237MovAbr[0];
            AV64MVATip = A13MvATip;
            AV60MVACod = A14MvACod;
            AV62MVAFec = A25MvAFec;
            AV39DocRef = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? (String.IsNullOrEmpty(StringUtil.RTrim( A1276MvAOcom)) ? A1278MvARef : A1276MvAOcom) : A24DocNum);
            AV38DocNum = A24DocNum;
            AV66OC = A1276MvAOcom;
            AV67OCP = "";
            AV54Ingresa = ((StringUtil.StrCmp(A13MvATip, "ING")==0) ? NumberUtil.Round( A1248MvADCant, 4) : (decimal)(0));
            AV79Salida = ((StringUtil.StrCmp(A13MvATip, "ING")!=0) ? NumberUtil.Round( A1248MvADCant, 4) : (decimal)(0));
            AV59MovAbr = A1237MovAbr;
            AV65MvATMov = A1286MvATMov;
            AV17CanSInicial = 0;
            AV25CanUInicial = 0;
            AV21CanTInicial = 0;
            AV16CanSIngreso = 0;
            AV24CanUIngreso = 0;
            AV20CanTIngreso = 0;
            AV19CanSSalida = 0;
            AV27CanUSalida = 0;
            AV23CanTSalida = 0;
            if ( StringUtil.StrCmp(A13MvATip, "ING") == 0 )
            {
               AV24CanUIngreso = NumberUtil.Round( A1250MVADPrecio, 4);
               AV20CanTIngreso = NumberUtil.Round( A1249MVADCosto, 2);
               AV16CanSIngreso = AV54Ingresa;
               AV18CanSSaldo = (decimal)(AV18CanSSaldo+AV16CanSIngreso);
               AV22CanTSaldo = (decimal)(AV22CanTSaldo+AV20CanTIngreso);
               if ( AV65MvATMov == 1 )
               {
                  /* Execute user subroutine: 'VALIDADOC' */
                  S1310 ();
                  if ( returnInSub )
                  {
                     pr_default.close(6);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               HFO0( false, 16) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV62MVAFec, "99/99/99"), 9, Gx_line+1, 48, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60MVACod, "")), 91, Gx_line+1, 142, Gx_line+14, 1+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64MVATip, "")), 52, Gx_line+0, 84, Gx_line+14, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59MovAbr, "")), 158, Gx_line+0, 201, Gx_line+13, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38DocNum, "")), 204, Gx_line+1, 255, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66OC, "")), 267, Gx_line+1, 310, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67OCP, "")), 328, Gx_line+1, 371, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16CanSIngreso, "ZZZZ,ZZZ,ZZ9.9999")), 555, Gx_line+1, 645, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV24CanUIngreso, "ZZZZ,ZZZ,ZZ9.9999")), 615, Gx_line+1, 705, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20CanTIngreso, "ZZZZZZ,ZZZ,ZZ9.99")), 668, Gx_line+1, 758, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27CanUSalida, "ZZZZ,ZZZ,ZZ9.9999")), 785, Gx_line+1, 875, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23CanTSalida, "ZZZZZZ,ZZZ,ZZ9.99")), 842, Gx_line+1, 932, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19CanSSalida, "ZZZZ,ZZZ,ZZ9.9999")), 729, Gx_line+1, 819, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV22CanTSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 1017, Gx_line+1, 1107, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18CanSSaldo, "ZZZZ,ZZZ,ZZ9.9999")), 903, Gx_line+1, 993, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV26CanUSaldo, "ZZZZ,ZZZ,ZZ9.9999")), 961, Gx_line+1, 1051, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 369, Gx_line+1, 459, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 429, Gx_line+1, 519, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 495, Gx_line+1, 585, Gx_line+14, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+16);
               AV82TCanSIngreso = (decimal)(AV82TCanSIngreso+AV16CanSIngreso);
               AV87TCanTIngreso = (decimal)(AV87TCanTIngreso+AV20CanTIngreso);
            }
            else
            {
               /* Execute user subroutine: 'VALIDASALIDAS' */
               S1410 ();
               if ( returnInSub )
               {
                  pr_default.close(6);
                  returnInSub = true;
                  if (true) return;
               }
            }
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S1310( )
      {
         /* 'VALIDADOC' Routine */
         returnInSub = false;
         /* Using cursor P00FO9 */
         pr_default.execute(7, new Object[] {AV69ProdCodC, AV66OC});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A254ComDProCod = P00FO9_A254ComDProCod[0];
            n254ComDProCod = P00FO9_n254ComDProCod[0];
            A251ComDOrdCod = P00FO9_A251ComDOrdCod[0];
            A243ComCod = P00FO9_A243ComCod[0];
            A149TipCod = P00FO9_A149TipCod[0];
            A244PrvCod = P00FO9_A244PrvCod[0];
            A250ComDItem = P00FO9_A250ComDItem[0];
            AV38DocNum = A243ComCod;
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void S151( )
      {
         /* 'SALDOINICIAL' Routine */
         returnInSub = false;
         /* Using cursor P00FO10 */
         pr_default.execute(8, new Object[] {AV10AlmCod, AV44FDesde, AV69ProdCodC});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A7SalFCosProdCod = P00FO10_A7SalFCosProdCod[0];
            A1835SalFCosFecha = P00FO10_A1835SalFCosFecha[0];
            A2SalFCosAlmCod = P00FO10_A2SalFCosAlmCod[0];
            A5SalFCosMVTip = P00FO10_A5SalFCosMVTip[0];
            A6SalFCosMVCod = P00FO10_A6SalFCosMVCod[0];
            A1832SalFCosCant = P00FO10_A1832SalFCosCant[0];
            A1837SalFCosUnit = P00FO10_A1837SalFCosUnit[0];
            A1836SalFCosTot = P00FO10_A1836SalFCosTot[0];
            A3SalFCosAlmAno = P00FO10_A3SalFCosAlmAno[0];
            A4SalFCosAlmMes = P00FO10_A4SalFCosAlmMes[0];
            AV64MVATip = A5SalFCosMVTip;
            AV60MVACod = A6SalFCosMVCod;
            AV62MVAFec = A1835SalFCosFecha;
            AV17CanSInicial = A1832SalFCosCant;
            AV25CanUInicial = A1837SalFCosUnit;
            AV21CanTInicial = A1836SalFCosTot;
            AV18CanSSaldo = (decimal)(AV18CanSSaldo+A1832SalFCosCant);
            AV22CanTSaldo = (decimal)(AV22CanTSaldo+A1836SalFCosTot);
            AV77Saldo = A1832SalFCosCant;
            HFO0( false, 17) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60MVACod, "")), 91, Gx_line+1, 142, Gx_line+14, 1+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64MVATip, "")), 52, Gx_line+1, 84, Gx_line+15, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV62MVAFec, "99/99/99"), 9, Gx_line+1, 48, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV21CanTInicial, "ZZZZZZ,ZZZ,ZZ9.99")), 495, Gx_line+1, 585, Gx_line+14, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV25CanUInicial, "ZZZZ,ZZZ,ZZ9.9999")), 429, Gx_line+1, 519, Gx_line+14, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17CanSInicial, "ZZZZ,ZZZ,ZZ9.9999")), 369, Gx_line+1, 459, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV26CanUSaldo, "ZZZZ,ZZZ,ZZ9.9999")), 961, Gx_line+1, 1051, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18CanSSaldo, "ZZZZ,ZZZ,ZZ9.9999")), 903, Gx_line+1, 993, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV22CanTSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 1017, Gx_line+1, 1107, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 729, Gx_line+1, 819, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 842, Gx_line+1, 932, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 785, Gx_line+1, 875, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 668, Gx_line+1, 758, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 615, Gx_line+1, 705, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 555, Gx_line+1, 645, Gx_line+14, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+17);
            AV83TCanSInicial = (decimal)(AV83TCanSInicial+AV17CanSInicial);
            AV92TCanUInicial = (decimal)(AV92TCanUInicial+0);
            AV88TCanTInicial = (decimal)(AV88TCanTInicial+AV21CanTInicial);
            pr_default.readNext(8);
         }
         pr_default.close(8);
      }

      protected void S161( )
      {
         /* 'CARGADATOS' Routine */
         returnInSub = false;
         /* Optimized DELETE. */
         /* Using cursor P00FO11 */
         pr_default.execute(9, new Object[] {AV10AlmCod});
         pr_default.close(9);
         dsDefault.SmartCacheProvider.SetUpdated("AMOVIMIENTOSFIFO");
         /* End optimized DELETE. */
         context.CommitDataStores("produccion.r_arkardexvalorizadopepspdf",pr_default);
         /* Using cursor P00FO12 */
         pr_default.execute(10, new Object[] {AV10AlmCod, AV12Ano2, AV58Mes2});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A6SalFCosMVCod = P00FO12_A6SalFCosMVCod[0];
            A7SalFCosProdCod = P00FO12_A7SalFCosProdCod[0];
            A1835SalFCosFecha = P00FO12_A1835SalFCosFecha[0];
            A1834SalFCosCantSaldo = P00FO12_A1834SalFCosCantSaldo[0];
            A1837SalFCosUnit = P00FO12_A1837SalFCosUnit[0];
            A4SalFCosAlmMes = P00FO12_A4SalFCosAlmMes[0];
            A3SalFCosAlmAno = P00FO12_A3SalFCosAlmAno[0];
            A2SalFCosAlmCod = P00FO12_A2SalFCosAlmCod[0];
            A1832SalFCosCant = P00FO12_A1832SalFCosCant[0];
            A1833SalFCosCantFifo = P00FO12_A1833SalFCosCantFifo[0];
            A5SalFCosMVTip = P00FO12_A5SalFCosMVTip[0];
            /*
               INSERT RECORD ON TABLE AMOVIMIENTOSFIFO

            */
            A40FifoAlmCod = AV10AlmCod;
            A41FifoMVACod = A6SalFCosMVCod;
            A42FifoProdCod = A7SalFCosProdCod;
            A43FifoMVADItem = 1;
            A985FifoMVAFec = A1835SalFCosFecha;
            A980FifoMVADCant = A1834SalFCosCantSaldo;
            A984FifoMVADPrecio = A1837SalFCosUnit;
            A983FifoMVADCosto = NumberUtil.Round( A1834SalFCosCantSaldo*A1837SalFCosUnit, 2);
            /* Using cursor P00FO13 */
            pr_default.execute(11, new Object[] {A40FifoAlmCod, A41FifoMVACod, A42FifoProdCod, A43FifoMVADItem, A985FifoMVAFec, A980FifoMVADCant, A984FifoMVADPrecio, A983FifoMVADCosto});
            pr_default.close(11);
            dsDefault.SmartCacheProvider.SetUpdated("AMOVIMIENTOSFIFO");
            if ( (pr_default.getStatus(11) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(10);
         }
         pr_default.close(10);
         /* Using cursor P00FO14 */
         pr_default.execute(12, new Object[] {AV44FDesde, AV46FHasta, AV10AlmCod});
         while ( (pr_default.getStatus(12) != 101) )
         {
            A52LinCod = P00FO14_A52LinCod[0];
            A14MvACod = P00FO14_A14MvACod[0];
            A28ProdCod = P00FO14_A28ProdCod[0];
            A30MvADItem = P00FO14_A30MvADItem[0];
            A25MvAFec = P00FO14_A25MvAFec[0];
            A1248MvADCant = P00FO14_A1248MvADCant[0];
            A1250MVADPrecio = P00FO14_A1250MVADPrecio[0];
            A1249MVADCosto = P00FO14_A1249MVADCosto[0];
            A1370MVSts = P00FO14_A1370MVSts[0];
            A13MvATip = P00FO14_A13MvATip[0];
            A1269MvAlmCos = P00FO14_A1269MvAlmCos[0];
            A1158LinStk = P00FO14_A1158LinStk[0];
            A21MvAlm = P00FO14_A21MvAlm[0];
            A52LinCod = P00FO14_A52LinCod[0];
            A1158LinStk = P00FO14_A1158LinStk[0];
            A25MvAFec = P00FO14_A25MvAFec[0];
            A1370MVSts = P00FO14_A1370MVSts[0];
            A21MvAlm = P00FO14_A21MvAlm[0];
            A1269MvAlmCos = P00FO14_A1269MvAlmCos[0];
            /*
               INSERT RECORD ON TABLE AMOVIMIENTOSFIFO

            */
            A40FifoAlmCod = AV10AlmCod;
            A41FifoMVACod = A14MvACod;
            A42FifoProdCod = A28ProdCod;
            A43FifoMVADItem = A30MvADItem;
            A985FifoMVAFec = A25MvAFec;
            A980FifoMVADCant = A1248MvADCant;
            A984FifoMVADPrecio = A1250MVADPrecio;
            A983FifoMVADCosto = A1249MVADCosto;
            /* Using cursor P00FO15 */
            pr_default.execute(13, new Object[] {A40FifoAlmCod, A41FifoMVACod, A42FifoProdCod, A43FifoMVADItem, A985FifoMVAFec, A980FifoMVADCant, A984FifoMVADPrecio, A983FifoMVADCosto});
            pr_default.close(13);
            dsDefault.SmartCacheProvider.SetUpdated("AMOVIMIENTOSFIFO");
            if ( (pr_default.getStatus(13) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(12);
         }
         pr_default.close(12);
      }

      protected void S1410( )
      {
         /* 'VALIDASALIDAS' Routine */
         returnInSub = false;
         AV50Flag = 0;
         /* Using cursor P00FO16 */
         pr_default.execute(14, new Object[] {AV10AlmCod, AV69ProdCodC});
         while ( (pr_default.getStatus(14) != 101) )
         {
            GXTFO18 = 0;
            A40FifoAlmCod = P00FO16_A40FifoAlmCod[0];
            A42FifoProdCod = P00FO16_A42FifoProdCod[0];
            A982FifoMVADCantSaldo = P00FO16_A982FifoMVADCantSaldo[0];
            A984FifoMVADPrecio = P00FO16_A984FifoMVADPrecio[0];
            A41FifoMVACod = P00FO16_A41FifoMVACod[0];
            A985FifoMVAFec = P00FO16_A985FifoMVAFec[0];
            A980FifoMVADCant = P00FO16_A980FifoMVADCant[0];
            A981FifoMVADCantFifo = P00FO16_A981FifoMVADCantFifo[0];
            A43FifoMVADItem = P00FO16_A43FifoMVADItem[0];
            AV77Saldo = A982FifoMVADCantSaldo;
            AV8MVADPrecio = A984FifoMVADPrecio;
            AV67OCP = A41FifoMVACod;
            if ( AV50Flag == 1 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P00FO17 */
               pr_default.execute(15, new Object[] {A981FifoMVADCantFifo, A40FifoAlmCod, A41FifoMVACod, A42FifoProdCod, A43FifoMVADItem});
               pr_default.close(15);
               dsDefault.SmartCacheProvider.SetUpdated("AMOVIMIENTOSFIFO");
               if ( GXTFO18 == 1 )
               {
                  context.CommitDataStores("produccion.r_arkardexvalorizadopepspdf",pr_default);
               }
               if (true) break;
            }
            if ( AV79Salida <= AV77Saldo )
            {
               A981FifoMVADCantFifo = (decimal)(A981FifoMVADCantFifo+AV79Salida);
               AV19CanSSalida = AV79Salida;
               AV112CostoSal = (decimal)(AV112CostoSal+(NumberUtil.Round( AV79Salida*AV8MVADPrecio, 2)));
               AV50Flag = 1;
            }
            else
            {
               A981FifoMVADCantFifo = (decimal)(A981FifoMVADCantFifo+AV77Saldo);
               AV19CanSSalida = AV77Saldo;
               AV79Salida = (decimal)(AV79Salida-AV77Saldo);
               AV112CostoSal = (decimal)(AV112CostoSal+(NumberUtil.Round( AV77Saldo*AV8MVADPrecio, 2)));
            }
            GXTFO18 = 1;
            AV27CanUSalida = AV8MVADPrecio;
            AV23CanTSalida = NumberUtil.Round( AV19CanSSalida*AV8MVADPrecio, 2);
            AV18CanSSaldo = (decimal)(AV18CanSSaldo-AV19CanSSalida);
            AV22CanTSaldo = (decimal)(AV22CanTSaldo-AV23CanTSalida);
            HFO0( false, 16) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV62MVAFec, "99/99/99"), 9, Gx_line+1, 48, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60MVACod, "")), 91, Gx_line+1, 142, Gx_line+14, 1+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64MVATip, "")), 52, Gx_line+0, 84, Gx_line+14, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59MovAbr, "")), 158, Gx_line+0, 201, Gx_line+13, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38DocNum, "")), 204, Gx_line+1, 255, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66OC, "")), 267, Gx_line+1, 310, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67OCP, "")), 328, Gx_line+1, 371, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16CanSIngreso, "ZZZZ,ZZZ,ZZ9.9999")), 555, Gx_line+1, 645, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV24CanUIngreso, "ZZZZ,ZZZ,ZZ9.9999")), 615, Gx_line+1, 705, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20CanTIngreso, "ZZZZZZ,ZZZ,ZZ9.99")), 668, Gx_line+1, 758, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27CanUSalida, "ZZZZ,ZZZ,ZZ9.9999")), 785, Gx_line+1, 875, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23CanTSalida, "ZZZZZZ,ZZZ,ZZ9.99")), 842, Gx_line+1, 932, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19CanSSalida, "ZZZZ,ZZZ,ZZ9.9999")), 729, Gx_line+1, 819, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV22CanTSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 1017, Gx_line+1, 1107, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18CanSSaldo, "ZZZZ,ZZZ,ZZ9.9999")), 903, Gx_line+1, 993, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV26CanUSaldo, "ZZZZ,ZZZ,ZZ9.9999")), 961, Gx_line+1, 1051, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 369, Gx_line+1, 459, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 429, Gx_line+1, 519, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 495, Gx_line+1, 585, Gx_line+14, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+16);
            AV85TCanSSalida = (decimal)(AV85TCanSSalida+AV19CanSSalida);
            AV90TCanTSalida = (decimal)(AV90TCanTSalida+AV23CanTSalida);
            /* Using cursor P00FO18 */
            pr_default.execute(16, new Object[] {A981FifoMVADCantFifo, A40FifoAlmCod, A41FifoMVACod, A42FifoProdCod, A43FifoMVADItem});
            pr_default.close(16);
            dsDefault.SmartCacheProvider.SetUpdated("AMOVIMIENTOSFIFO");
            if ( GXTFO18 == 1 )
            {
               context.CommitDataStores("produccion.r_arkardexvalorizadopepspdf",pr_default);
            }
            pr_default.readNext(14);
         }
         pr_default.close(14);
      }

      protected void HFO0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 1004, Gx_line+32, 1036, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 993, Gx_line+50, 1037, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 998, Gx_line+15, 1037, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1044, Gx_line+50, 1083, Gx_line+65, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1044, Gx_line+32, 1085, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1044, Gx_line+15, 1091, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9Almacen, "")), 343, Gx_line+34, 799, Gx_line+59, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+136, 1111, Gx_line+181, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/M", 57, Gx_line+154, 80, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 13, Gx_line+154, 44, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Doc.", 206, Gx_line+154, 245, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 598, Gx_line+166, 645, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Linea :", 332, Gx_line+65, 375, Gx_line+80, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto :", 332, Gx_line+84, 401, Gx_line+99, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde : ", 332, Gx_line+106, 384, Gx_line+121, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Filtro1, "")), 413, Gx_line+59, 778, Gx_line+83, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Filtro2, "")), 413, Gx_line+79, 778, Gx_line+103, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV44FDesde, "99/99/99"), 413, Gx_line+101, 481, Gx_line+125, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Mes :", 538, Gx_line+106, 572, Gx_line+121, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV46FHasta, "99/99/99"), 619, Gx_line+101, 715, Gx_line+125, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV102Titulo, "")), 343, Gx_line+7, 799, Gx_line+32, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Corr.", 92, Gx_line+154, 136, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("T/Mov", 150, Gx_line+154, 185, Gx_line+167, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV56Logo)) ? AV115Logo_GXI : AV56Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+3, 175, Gx_line+80) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41Empresa, "")), 9, Gx_line+82, 317, Gx_line+100, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42EmpRUC, "")), 9, Gx_line+100, 179, Gx_line+118, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("O/C", 277, Gx_line+154, 299, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Referencia", 322, Gx_line+154, 379, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(589, Gx_line+136, 589, Gx_line+181, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(759, Gx_line+136, 759, Gx_line+181, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 660, Gx_line+166, 704, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 714, Gx_line+166, 758, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 772, Gx_line+166, 819, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 831, Gx_line+166, 875, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 888, Gx_line+166, 932, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 946, Gx_line+166, 993, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 1007, Gx_line+166, 1051, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 1063, Gx_line+166, 1107, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(934, Gx_line+136, 934, Gx_line+181, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(404, Gx_line+158, 1111, Gx_line+158, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Ingresos", 645, Gx_line+143, 692, Gx_line+156, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Salidas", 824, Gx_line+143, 861, Gx_line+156, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 1007, Gx_line+143, 1036, Gx_line+156, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(404, Gx_line+136, 404, Gx_line+181, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 414, Gx_line+166, 461, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 476, Gx_line+166, 520, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 529, Gx_line+166, 573, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo Inicial", 463, Gx_line+143, 528, Gx_line+156, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuario :", 984, Gx_line+68, 1036, Gx_line+82, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV110UsuCod, "")), 1044, Gx_line+68, 1097, Gx_line+83, 0+256, 0, 0, 0) ;
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
         AV41Empresa = "";
         AV80Session = context.GetSession();
         AV40EmpDir = "";
         AV42EmpRUC = "";
         AV71Ruta = "";
         AV56Logo = "";
         AV115Logo_GXI = "";
         AV110UsuCod = "";
         AV102Titulo = "";
         scmdbuf = "";
         P00FO2_A63AlmCod = new int[1] ;
         P00FO2_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         AV9Almacen = "";
         AV47Filtro1 = "";
         AV48Filtro2 = "";
         P00FO3_A52LinCod = new int[1] ;
         P00FO3_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P00FO4_A28ProdCod = new string[] {""} ;
         P00FO4_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P00FO5_A13MvATip = new string[] {""} ;
         P00FO5_A14MvACod = new string[] {""} ;
         P00FO5_A49UniCod = new int[1] ;
         P00FO5_A55ProdDsc = new string[] {""} ;
         P00FO5_A28ProdCod = new string[] {""} ;
         P00FO5_A1269MvAlmCos = new short[1] ;
         P00FO5_A1158LinStk = new short[1] ;
         P00FO5_A21MvAlm = new int[1] ;
         P00FO5_A50FamCod = new int[1] ;
         P00FO5_n50FamCod = new bool[] {false} ;
         P00FO5_A51SublCod = new int[1] ;
         P00FO5_n51SublCod = new bool[] {false} ;
         P00FO5_A52LinCod = new int[1] ;
         P00FO5_A1997UniAbr = new string[] {""} ;
         P00FO5_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A1997UniAbr = "";
         AV69ProdCodC = "";
         AV70Producto = "";
         AV109UniAbr = "";
         P00FO6_A21MvAlm = new int[1] ;
         P00FO6_A1370MVSts = new string[] {""} ;
         P00FO6_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FO6_A28ProdCod = new string[] {""} ;
         P00FO6_A14MvACod = new string[] {""} ;
         P00FO6_A13MvATip = new string[] {""} ;
         P00FO6_A30MvADItem = new int[1] ;
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         P00FO7_A7SalFCosProdCod = new string[] {""} ;
         P00FO7_A1835SalFCosFecha = new DateTime[] {DateTime.MinValue} ;
         P00FO7_A2SalFCosAlmCod = new int[1] ;
         P00FO7_A3SalFCosAlmAno = new short[1] ;
         P00FO7_A4SalFCosAlmMes = new short[1] ;
         P00FO7_A5SalFCosMVTip = new string[] {""} ;
         P00FO7_A6SalFCosMVCod = new string[] {""} ;
         A7SalFCosProdCod = "";
         A1835SalFCosFecha = DateTime.MinValue;
         A5SalFCosMVTip = "";
         A6SalFCosMVCod = "";
         P00FO8_A22MvAMov = new int[1] ;
         P00FO8_A21MvAlm = new int[1] ;
         P00FO8_A1370MVSts = new string[] {""} ;
         P00FO8_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FO8_A28ProdCod = new string[] {""} ;
         P00FO8_A1278MvARef = new string[] {""} ;
         P00FO8_A1276MvAOcom = new string[] {""} ;
         P00FO8_A24DocNum = new string[] {""} ;
         P00FO8_n24DocNum = new bool[] {false} ;
         P00FO8_A1248MvADCant = new decimal[1] ;
         P00FO8_A1237MovAbr = new string[] {""} ;
         P00FO8_n1237MovAbr = new bool[] {false} ;
         P00FO8_A1286MvATMov = new short[1] ;
         P00FO8_A1250MVADPrecio = new decimal[1] ;
         P00FO8_A1249MVADCosto = new decimal[1] ;
         P00FO8_A14MvACod = new string[] {""} ;
         P00FO8_A13MvATip = new string[] {""} ;
         P00FO8_A30MvADItem = new int[1] ;
         A1278MvARef = "";
         A1276MvAOcom = "";
         A24DocNum = "";
         A1237MovAbr = "";
         AV64MVATip = "";
         AV60MVACod = "";
         AV62MVAFec = DateTime.MinValue;
         AV39DocRef = "";
         AV38DocNum = "";
         AV66OC = "";
         AV67OCP = "";
         AV59MovAbr = "";
         P00FO9_A254ComDProCod = new string[] {""} ;
         P00FO9_n254ComDProCod = new bool[] {false} ;
         P00FO9_A251ComDOrdCod = new string[] {""} ;
         P00FO9_A243ComCod = new string[] {""} ;
         P00FO9_A149TipCod = new string[] {""} ;
         P00FO9_A244PrvCod = new string[] {""} ;
         P00FO9_A250ComDItem = new short[1] ;
         A254ComDProCod = "";
         A251ComDOrdCod = "";
         A243ComCod = "";
         A149TipCod = "";
         A244PrvCod = "";
         P00FO10_A7SalFCosProdCod = new string[] {""} ;
         P00FO10_A1835SalFCosFecha = new DateTime[] {DateTime.MinValue} ;
         P00FO10_A2SalFCosAlmCod = new int[1] ;
         P00FO10_A5SalFCosMVTip = new string[] {""} ;
         P00FO10_A6SalFCosMVCod = new string[] {""} ;
         P00FO10_A1832SalFCosCant = new decimal[1] ;
         P00FO10_A1837SalFCosUnit = new decimal[1] ;
         P00FO10_A1836SalFCosTot = new decimal[1] ;
         P00FO10_A3SalFCosAlmAno = new short[1] ;
         P00FO10_A4SalFCosAlmMes = new short[1] ;
         P00FO12_A6SalFCosMVCod = new string[] {""} ;
         P00FO12_A7SalFCosProdCod = new string[] {""} ;
         P00FO12_A1835SalFCosFecha = new DateTime[] {DateTime.MinValue} ;
         P00FO12_A1834SalFCosCantSaldo = new decimal[1] ;
         P00FO12_A1837SalFCosUnit = new decimal[1] ;
         P00FO12_A4SalFCosAlmMes = new short[1] ;
         P00FO12_A3SalFCosAlmAno = new short[1] ;
         P00FO12_A2SalFCosAlmCod = new int[1] ;
         P00FO12_A1832SalFCosCant = new decimal[1] ;
         P00FO12_A1833SalFCosCantFifo = new decimal[1] ;
         P00FO12_A5SalFCosMVTip = new string[] {""} ;
         A41FifoMVACod = "";
         A42FifoProdCod = "";
         A985FifoMVAFec = DateTime.MinValue;
         Gx_emsg = "";
         P00FO14_A52LinCod = new int[1] ;
         P00FO14_A14MvACod = new string[] {""} ;
         P00FO14_A28ProdCod = new string[] {""} ;
         P00FO14_A30MvADItem = new int[1] ;
         P00FO14_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FO14_A1248MvADCant = new decimal[1] ;
         P00FO14_A1250MVADPrecio = new decimal[1] ;
         P00FO14_A1249MVADCosto = new decimal[1] ;
         P00FO14_A1370MVSts = new string[] {""} ;
         P00FO14_A13MvATip = new string[] {""} ;
         P00FO14_A1269MvAlmCos = new short[1] ;
         P00FO14_A1158LinStk = new short[1] ;
         P00FO14_A21MvAlm = new int[1] ;
         P00FO16_A40FifoAlmCod = new int[1] ;
         P00FO16_A42FifoProdCod = new string[] {""} ;
         P00FO16_A982FifoMVADCantSaldo = new decimal[1] ;
         P00FO16_A984FifoMVADPrecio = new decimal[1] ;
         P00FO16_A41FifoMVACod = new string[] {""} ;
         P00FO16_A985FifoMVAFec = new DateTime[] {DateTime.MinValue} ;
         P00FO16_A980FifoMVADCant = new decimal[1] ;
         P00FO16_A981FifoMVADCantFifo = new decimal[1] ;
         P00FO16_A43FifoMVADItem = new int[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV56Logo = "";
         sImgUrl = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_arkardexvalorizadopepspdf__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_arkardexvalorizadopepspdf__default(),
            new Object[][] {
                new Object[] {
               P00FO2_A63AlmCod, P00FO2_A436AlmDsc
               }
               , new Object[] {
               P00FO3_A52LinCod, P00FO3_A1153LinDsc
               }
               , new Object[] {
               P00FO4_A28ProdCod, P00FO4_A55ProdDsc
               }
               , new Object[] {
               P00FO5_A13MvATip, P00FO5_A14MvACod, P00FO5_A49UniCod, P00FO5_A55ProdDsc, P00FO5_A28ProdCod, P00FO5_A1269MvAlmCos, P00FO5_A1158LinStk, P00FO5_A21MvAlm, P00FO5_A50FamCod, P00FO5_n50FamCod,
               P00FO5_A51SublCod, P00FO5_n51SublCod, P00FO5_A52LinCod, P00FO5_A1997UniAbr, P00FO5_A30MvADItem
               }
               , new Object[] {
               P00FO6_A21MvAlm, P00FO6_A1370MVSts, P00FO6_A25MvAFec, P00FO6_A28ProdCod, P00FO6_A14MvACod, P00FO6_A13MvATip, P00FO6_A30MvADItem
               }
               , new Object[] {
               P00FO7_A7SalFCosProdCod, P00FO7_A1835SalFCosFecha, P00FO7_A2SalFCosAlmCod, P00FO7_A3SalFCosAlmAno, P00FO7_A4SalFCosAlmMes, P00FO7_A5SalFCosMVTip, P00FO7_A6SalFCosMVCod
               }
               , new Object[] {
               P00FO8_A22MvAMov, P00FO8_A21MvAlm, P00FO8_A1370MVSts, P00FO8_A25MvAFec, P00FO8_A28ProdCod, P00FO8_A1278MvARef, P00FO8_A1276MvAOcom, P00FO8_A24DocNum, P00FO8_n24DocNum, P00FO8_A1248MvADCant,
               P00FO8_A1237MovAbr, P00FO8_n1237MovAbr, P00FO8_A1286MvATMov, P00FO8_A1250MVADPrecio, P00FO8_A1249MVADCosto, P00FO8_A14MvACod, P00FO8_A13MvATip, P00FO8_A30MvADItem
               }
               , new Object[] {
               P00FO9_A254ComDProCod, P00FO9_n254ComDProCod, P00FO9_A251ComDOrdCod, P00FO9_A243ComCod, P00FO9_A149TipCod, P00FO9_A244PrvCod, P00FO9_A250ComDItem
               }
               , new Object[] {
               P00FO10_A7SalFCosProdCod, P00FO10_A1835SalFCosFecha, P00FO10_A2SalFCosAlmCod, P00FO10_A5SalFCosMVTip, P00FO10_A6SalFCosMVCod, P00FO10_A1832SalFCosCant, P00FO10_A1837SalFCosUnit, P00FO10_A1836SalFCosTot, P00FO10_A3SalFCosAlmAno, P00FO10_A4SalFCosAlmMes
               }
               , new Object[] {
               }
               , new Object[] {
               P00FO12_A6SalFCosMVCod, P00FO12_A7SalFCosProdCod, P00FO12_A1835SalFCosFecha, P00FO12_A1834SalFCosCantSaldo, P00FO12_A1837SalFCosUnit, P00FO12_A4SalFCosAlmMes, P00FO12_A3SalFCosAlmAno, P00FO12_A2SalFCosAlmCod, P00FO12_A1832SalFCosCant, P00FO12_A1833SalFCosCantFifo,
               P00FO12_A5SalFCosMVTip
               }
               , new Object[] {
               }
               , new Object[] {
               P00FO14_A52LinCod, P00FO14_A14MvACod, P00FO14_A28ProdCod, P00FO14_A30MvADItem, P00FO14_A25MvAFec, P00FO14_A1248MvADCant, P00FO14_A1250MVADPrecio, P00FO14_A1249MVADCosto, P00FO14_A1370MVSts, P00FO14_A13MvATip,
               P00FO14_A1269MvAlmCos, P00FO14_A1158LinStk, P00FO14_A21MvAlm
               }
               , new Object[] {
               }
               , new Object[] {
               P00FO16_A40FifoAlmCod, P00FO16_A42FifoProdCod, P00FO16_A982FifoMVADCantSaldo, P00FO16_A984FifoMVADPrecio, P00FO16_A41FifoMVACod, P00FO16_A985FifoMVAFec, P00FO16_A980FifoMVADCant, P00FO16_A981FifoMVADCantFifo, P00FO16_A43FifoMVADItem
               }
               , new Object[] {
               }
               , new Object[] {
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
      private short AV11Ano ;
      private short AV57Mes ;
      private short AV58Mes2 ;
      private short AV12Ano2 ;
      private short A1158LinStk ;
      private short A1269MvAlmCos ;
      private short AV50Flag ;
      private short A3SalFCosAlmAno ;
      private short A4SalFCosAlmMes ;
      private short A1286MvATMov ;
      private short AV65MvATMov ;
      private short A250ComDItem ;
      private short GXTFO18 ;
      private int AV55LinCod ;
      private int AV81SublCod ;
      private int AV43FamCod ;
      private int AV10AlmCod ;
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
      private int A49UniCod ;
      private int A30MvADItem ;
      private int Gx_OldLine ;
      private int A2SalFCosAlmCod ;
      private int A22MvAMov ;
      private int GX_INS3 ;
      private int A40FifoAlmCod ;
      private int A43FifoMVADItem ;
      private decimal AV17CanSInicial ;
      private decimal AV25CanUInicial ;
      private decimal AV21CanTInicial ;
      private decimal AV16CanSIngreso ;
      private decimal AV24CanUIngreso ;
      private decimal AV20CanTIngreso ;
      private decimal AV19CanSSalida ;
      private decimal AV27CanUSalida ;
      private decimal AV23CanTSalida ;
      private decimal AV18CanSSaldo ;
      private decimal AV26CanUSaldo ;
      private decimal AV22CanTSaldo ;
      private decimal AV83TCanSInicial ;
      private decimal AV92TCanUInicial ;
      private decimal AV88TCanTInicial ;
      private decimal AV82TCanSIngreso ;
      private decimal AV91TCanUIngreso ;
      private decimal AV87TCanTIngreso ;
      private decimal AV85TCanSSalida ;
      private decimal AV94TCanUSalida ;
      private decimal AV90TCanTSalida ;
      private decimal AV77Saldo ;
      private decimal AV86TCantidad ;
      private decimal AV34CostoTotal ;
      private decimal A1248MvADCant ;
      private decimal A1250MVADPrecio ;
      private decimal A1249MVADCosto ;
      private decimal AV54Ingresa ;
      private decimal AV79Salida ;
      private decimal AV29Ceros ;
      private decimal A1832SalFCosCant ;
      private decimal A1837SalFCosUnit ;
      private decimal A1836SalFCosTot ;
      private decimal A1834SalFCosCantSaldo ;
      private decimal A1833SalFCosCantFifo ;
      private decimal A980FifoMVADCant ;
      private decimal A984FifoMVADPrecio ;
      private decimal A983FifoMVADCosto ;
      private decimal A982FifoMVADCantSaldo ;
      private decimal A981FifoMVADCantFifo ;
      private decimal AV8MVADPrecio ;
      private decimal AV112CostoSal ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV68Prodcod ;
      private string AV41Empresa ;
      private string AV40EmpDir ;
      private string AV42EmpRUC ;
      private string AV71Ruta ;
      private string AV110UsuCod ;
      private string AV102Titulo ;
      private string scmdbuf ;
      private string A436AlmDsc ;
      private string AV9Almacen ;
      private string AV47Filtro1 ;
      private string AV48Filtro2 ;
      private string A1153LinDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string A1997UniAbr ;
      private string AV69ProdCodC ;
      private string AV70Producto ;
      private string AV109UniAbr ;
      private string A1370MVSts ;
      private string A1278MvARef ;
      private string A1276MvAOcom ;
      private string A24DocNum ;
      private string A1237MovAbr ;
      private string AV64MVATip ;
      private string AV60MVACod ;
      private string AV39DocRef ;
      private string AV38DocNum ;
      private string AV66OC ;
      private string AV67OCP ;
      private string AV59MovAbr ;
      private string A254ComDProCod ;
      private string A251ComDOrdCod ;
      private string A243ComCod ;
      private string A149TipCod ;
      private string A244PrvCod ;
      private string A41FifoMVACod ;
      private string A42FifoProdCod ;
      private string Gx_emsg ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV44FDesde ;
      private DateTime AV46FHasta ;
      private DateTime A25MvAFec ;
      private DateTime A1835SalFCosFecha ;
      private DateTime AV62MVAFec ;
      private DateTime A985FifoMVAFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool BRKFO6 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool n24DocNum ;
      private bool n1237MovAbr ;
      private bool n254ComDProCod ;
      private string AV115Logo_GXI ;
      private string A7SalFCosProdCod ;
      private string A5SalFCosMVTip ;
      private string A6SalFCosMVCod ;
      private string AV56Logo ;
      private string Logo ;
      private IGxSession AV80Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SublCod ;
      private int aP2_FamCod ;
      private int aP3_AlmCod ;
      private string aP4_Prodcod ;
      private DateTime aP5_FDesde ;
      private DateTime aP6_FHasta ;
      private IDataStoreProvider pr_default ;
      private int[] P00FO2_A63AlmCod ;
      private string[] P00FO2_A436AlmDsc ;
      private int[] P00FO3_A52LinCod ;
      private string[] P00FO3_A1153LinDsc ;
      private string[] P00FO4_A28ProdCod ;
      private string[] P00FO4_A55ProdDsc ;
      private string[] P00FO5_A13MvATip ;
      private string[] P00FO5_A14MvACod ;
      private int[] P00FO5_A49UniCod ;
      private string[] P00FO5_A55ProdDsc ;
      private string[] P00FO5_A28ProdCod ;
      private short[] P00FO5_A1269MvAlmCos ;
      private short[] P00FO5_A1158LinStk ;
      private int[] P00FO5_A21MvAlm ;
      private int[] P00FO5_A50FamCod ;
      private bool[] P00FO5_n50FamCod ;
      private int[] P00FO5_A51SublCod ;
      private bool[] P00FO5_n51SublCod ;
      private int[] P00FO5_A52LinCod ;
      private string[] P00FO5_A1997UniAbr ;
      private int[] P00FO5_A30MvADItem ;
      private int[] P00FO6_A21MvAlm ;
      private string[] P00FO6_A1370MVSts ;
      private DateTime[] P00FO6_A25MvAFec ;
      private string[] P00FO6_A28ProdCod ;
      private string[] P00FO6_A14MvACod ;
      private string[] P00FO6_A13MvATip ;
      private int[] P00FO6_A30MvADItem ;
      private string[] P00FO7_A7SalFCosProdCod ;
      private DateTime[] P00FO7_A1835SalFCosFecha ;
      private int[] P00FO7_A2SalFCosAlmCod ;
      private short[] P00FO7_A3SalFCosAlmAno ;
      private short[] P00FO7_A4SalFCosAlmMes ;
      private string[] P00FO7_A5SalFCosMVTip ;
      private string[] P00FO7_A6SalFCosMVCod ;
      private int[] P00FO8_A22MvAMov ;
      private int[] P00FO8_A21MvAlm ;
      private string[] P00FO8_A1370MVSts ;
      private DateTime[] P00FO8_A25MvAFec ;
      private string[] P00FO8_A28ProdCod ;
      private string[] P00FO8_A1278MvARef ;
      private string[] P00FO8_A1276MvAOcom ;
      private string[] P00FO8_A24DocNum ;
      private bool[] P00FO8_n24DocNum ;
      private decimal[] P00FO8_A1248MvADCant ;
      private string[] P00FO8_A1237MovAbr ;
      private bool[] P00FO8_n1237MovAbr ;
      private short[] P00FO8_A1286MvATMov ;
      private decimal[] P00FO8_A1250MVADPrecio ;
      private decimal[] P00FO8_A1249MVADCosto ;
      private string[] P00FO8_A14MvACod ;
      private string[] P00FO8_A13MvATip ;
      private int[] P00FO8_A30MvADItem ;
      private string[] P00FO9_A254ComDProCod ;
      private bool[] P00FO9_n254ComDProCod ;
      private string[] P00FO9_A251ComDOrdCod ;
      private string[] P00FO9_A243ComCod ;
      private string[] P00FO9_A149TipCod ;
      private string[] P00FO9_A244PrvCod ;
      private short[] P00FO9_A250ComDItem ;
      private string[] P00FO10_A7SalFCosProdCod ;
      private DateTime[] P00FO10_A1835SalFCosFecha ;
      private int[] P00FO10_A2SalFCosAlmCod ;
      private string[] P00FO10_A5SalFCosMVTip ;
      private string[] P00FO10_A6SalFCosMVCod ;
      private decimal[] P00FO10_A1832SalFCosCant ;
      private decimal[] P00FO10_A1837SalFCosUnit ;
      private decimal[] P00FO10_A1836SalFCosTot ;
      private short[] P00FO10_A3SalFCosAlmAno ;
      private short[] P00FO10_A4SalFCosAlmMes ;
      private string[] P00FO12_A6SalFCosMVCod ;
      private string[] P00FO12_A7SalFCosProdCod ;
      private DateTime[] P00FO12_A1835SalFCosFecha ;
      private decimal[] P00FO12_A1834SalFCosCantSaldo ;
      private decimal[] P00FO12_A1837SalFCosUnit ;
      private short[] P00FO12_A4SalFCosAlmMes ;
      private short[] P00FO12_A3SalFCosAlmAno ;
      private int[] P00FO12_A2SalFCosAlmCod ;
      private decimal[] P00FO12_A1832SalFCosCant ;
      private decimal[] P00FO12_A1833SalFCosCantFifo ;
      private string[] P00FO12_A5SalFCosMVTip ;
      private int[] P00FO14_A52LinCod ;
      private string[] P00FO14_A14MvACod ;
      private string[] P00FO14_A28ProdCod ;
      private int[] P00FO14_A30MvADItem ;
      private DateTime[] P00FO14_A25MvAFec ;
      private decimal[] P00FO14_A1248MvADCant ;
      private decimal[] P00FO14_A1250MVADPrecio ;
      private decimal[] P00FO14_A1249MVADCosto ;
      private string[] P00FO14_A1370MVSts ;
      private string[] P00FO14_A13MvATip ;
      private short[] P00FO14_A1269MvAlmCos ;
      private short[] P00FO14_A1158LinStk ;
      private int[] P00FO14_A21MvAlm ;
      private int[] P00FO16_A40FifoAlmCod ;
      private string[] P00FO16_A42FifoProdCod ;
      private decimal[] P00FO16_A982FifoMVADCantSaldo ;
      private decimal[] P00FO16_A984FifoMVADPrecio ;
      private string[] P00FO16_A41FifoMVACod ;
      private DateTime[] P00FO16_A985FifoMVAFec ;
      private decimal[] P00FO16_A980FifoMVADCant ;
      private decimal[] P00FO16_A981FifoMVADCantFifo ;
      private int[] P00FO16_A43FifoMVADItem ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class r_arkardexvalorizadopepspdf__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class r_arkardexvalorizadopepspdf__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P00FO5( IGxContext context ,
                                           int AV55LinCod ,
                                           int AV81SublCod ,
                                           int AV43FamCod ,
                                           string AV68Prodcod ,
                                           int A52LinCod ,
                                           int A51SublCod ,
                                           int A50FamCod ,
                                           string A28ProdCod ,
                                           int A21MvAlm ,
                                           int AV10AlmCod ,
                                           short A1158LinStk ,
                                           short A1269MvAlmCos )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int1 = new short[5];
       Object[] GXv_Object2 = new Object[2];
       scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T4.[UniCod], T4.[ProdDsc], T1.[ProdCod], T3.[AlmCos] AS MvAlmCos, T6.[LinStk], T2.[MvAlm] AS MvAlm, T4.[FamCod], T4.[SublCod], T4.[LinCod], T5.[UniAbr], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T5 ON T5.[UniCod] = T4.[UniCod]) INNER JOIN [CLINEAPROD] T6 ON T6.[LinCod] = T4.[LinCod])";
       AddWhere(sWhereString, "(T2.[MvAlm] = @AV10AlmCod)");
       AddWhere(sWhereString, "(T6.[LinStk] = 1)");
       AddWhere(sWhereString, "(T3.[AlmCos] = 1)");
       if ( ! (0==AV55LinCod) )
       {
          AddWhere(sWhereString, "(T4.[LinCod] = @AV55LinCod)");
       }
       else
       {
          GXv_int1[1] = 1;
       }
       if ( ! (0==AV81SublCod) )
       {
          AddWhere(sWhereString, "(T4.[SublCod] = @AV81SublCod)");
       }
       else
       {
          GXv_int1[2] = 1;
       }
       if ( ! (0==AV43FamCod) )
       {
          AddWhere(sWhereString, "(T4.[FamCod] = @AV43FamCod)");
       }
       else
       {
          GXv_int1[3] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Prodcod)) )
       {
          AddWhere(sWhereString, "(T1.[ProdCod] = @AV68Prodcod)");
       }
       else
       {
          GXv_int1[4] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY T1.[ProdCod], T4.[ProdDsc]";
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
             case 3 :
                   return conditional_P00FO5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
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
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00FO2;
        prmP00FO2 = new Object[] {
        new ParDef("@AV10AlmCod",GXType.Int32,6,0)
        };
        Object[] prmP00FO3;
        prmP00FO3 = new Object[] {
        new ParDef("@AV55LinCod",GXType.Int32,6,0)
        };
        Object[] prmP00FO4;
        prmP00FO4 = new Object[] {
        new ParDef("@AV68Prodcod",GXType.NChar,15,0)
        };
        Object[] prmP00FO6;
        prmP00FO6 = new Object[] {
        new ParDef("@AV44FDesde",GXType.Date,8,0) ,
        new ParDef("@AV69ProdCodC",GXType.NChar,15,0) ,
        new ParDef("@AV10AlmCod",GXType.Int32,6,0) ,
        new ParDef("@AV46FHasta",GXType.Date,8,0)
        };
        Object[] prmP00FO7;
        prmP00FO7 = new Object[] {
        new ParDef("@AV10AlmCod",GXType.Int32,6,0) ,
        new ParDef("@AV44FDesde",GXType.Date,8,0) ,
        new ParDef("@AV69ProdCodC",GXType.NChar,15,0)
        };
        Object[] prmP00FO8;
        prmP00FO8 = new Object[] {
        new ParDef("@AV44FDesde",GXType.Date,8,0) ,
        new ParDef("@AV69ProdCodC",GXType.NChar,15,0) ,
        new ParDef("@AV10AlmCod",GXType.Int32,6,0) ,
        new ParDef("@AV46FHasta",GXType.Date,8,0)
        };
        Object[] prmP00FO9;
        prmP00FO9 = new Object[] {
        new ParDef("@AV69ProdCodC",GXType.NChar,15,0) ,
        new ParDef("@AV66OC",GXType.NChar,10,0)
        };
        Object[] prmP00FO10;
        prmP00FO10 = new Object[] {
        new ParDef("@AV10AlmCod",GXType.Int32,6,0) ,
        new ParDef("@AV44FDesde",GXType.Date,8,0) ,
        new ParDef("@AV69ProdCodC",GXType.NChar,15,0)
        };
        Object[] prmP00FO11;
        prmP00FO11 = new Object[] {
        new ParDef("@AV10AlmCod",GXType.Int32,6,0)
        };
        Object[] prmP00FO12;
        prmP00FO12 = new Object[] {
        new ParDef("@AV10AlmCod",GXType.Int32,6,0) ,
        new ParDef("@AV12Ano2",GXType.Int16,4,0) ,
        new ParDef("@AV58Mes2",GXType.Int16,2,0)
        };
        Object[] prmP00FO13;
        prmP00FO13 = new Object[] {
        new ParDef("@FifoAlmCod",GXType.Int32,6,0) ,
        new ParDef("@FifoMVACod",GXType.NChar,12,0) ,
        new ParDef("@FifoProdCod",GXType.NChar,15,0) ,
        new ParDef("@FifoMVADItem",GXType.Int32,6,0) ,
        new ParDef("@FifoMVAFec",GXType.Date,8,0) ,
        new ParDef("@FifoMVADCant",GXType.Decimal,15,4) ,
        new ParDef("@FifoMVADPrecio",GXType.Decimal,15,4) ,
        new ParDef("@FifoMVADCosto",GXType.Decimal,15,2)
        };
        Object[] prmP00FO14;
        prmP00FO14 = new Object[] {
        new ParDef("@AV44FDesde",GXType.Date,8,0) ,
        new ParDef("@AV46FHasta",GXType.Date,8,0) ,
        new ParDef("@AV10AlmCod",GXType.Int32,6,0)
        };
        Object[] prmP00FO15;
        prmP00FO15 = new Object[] {
        new ParDef("@FifoAlmCod",GXType.Int32,6,0) ,
        new ParDef("@FifoMVACod",GXType.NChar,12,0) ,
        new ParDef("@FifoProdCod",GXType.NChar,15,0) ,
        new ParDef("@FifoMVADItem",GXType.Int32,6,0) ,
        new ParDef("@FifoMVAFec",GXType.Date,8,0) ,
        new ParDef("@FifoMVADCant",GXType.Decimal,15,4) ,
        new ParDef("@FifoMVADPrecio",GXType.Decimal,15,4) ,
        new ParDef("@FifoMVADCosto",GXType.Decimal,15,2)
        };
        Object[] prmP00FO16;
        prmP00FO16 = new Object[] {
        new ParDef("@AV10AlmCod",GXType.Int32,6,0) ,
        new ParDef("@AV69ProdCodC",GXType.NChar,15,0)
        };
        Object[] prmP00FO17;
        prmP00FO17 = new Object[] {
        new ParDef("@FifoMVADCantFifo",GXType.Decimal,15,4) ,
        new ParDef("@FifoAlmCod",GXType.Int32,6,0) ,
        new ParDef("@FifoMVACod",GXType.NChar,12,0) ,
        new ParDef("@FifoProdCod",GXType.NChar,15,0) ,
        new ParDef("@FifoMVADItem",GXType.Int32,6,0)
        };
        Object[] prmP00FO18;
        prmP00FO18 = new Object[] {
        new ParDef("@FifoMVADCantFifo",GXType.Decimal,15,4) ,
        new ParDef("@FifoAlmCod",GXType.Int32,6,0) ,
        new ParDef("@FifoMVACod",GXType.NChar,12,0) ,
        new ParDef("@FifoProdCod",GXType.NChar,15,0) ,
        new ParDef("@FifoMVADItem",GXType.Int32,6,0)
        };
        Object[] prmP00FO5;
        prmP00FO5 = new Object[] {
        new ParDef("@AV10AlmCod",GXType.Int32,6,0) ,
        new ParDef("@AV55LinCod",GXType.Int32,6,0) ,
        new ParDef("@AV81SublCod",GXType.Int32,6,0) ,
        new ParDef("@AV43FamCod",GXType.Int32,6,0) ,
        new ParDef("@AV68Prodcod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00FO2", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV10AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FO2,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00FO3", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV55LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FO3,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00FO4", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV68Prodcod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FO4,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00FO5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FO5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00FO6", "SELECT TOP 1 T2.[MvAlm] AS MvAlm, T2.[MVSts], T2.[MvAFec], T1.[ProdCod], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T2.[MvAFec] >= @AV44FDesde) AND (T1.[ProdCod] = RTRIM(LTRIM(@AV69ProdCodC))) AND (T2.[MVSts] <> 'A') AND (T2.[MvAlm] = @AV10AlmCod) AND (T2.[MvAFec] <= @AV46FHasta) ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FO6,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00FO7", "SELECT TOP 1 [SalFCosProdCod], [SalFCosFecha], [SalFCosAlmCod], [SalFCosAlmAno], [SalFCosAlmMes], [SalFCosMVTip], [SalFCosMVCod] FROM [ACOSTOALMACENFIFO] WHERE ([SalFCosAlmCod] = @AV10AlmCod) AND ([SalFCosFecha] < @AV44FDesde) AND ([SalFCosProdCod] = @AV69ProdCodC) ORDER BY [SalFCosAlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FO7,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00FO8", "SELECT T2.[MvAMov] AS MvAMov, T2.[MvAlm] AS MvAlm, T2.[MVSts], T2.[MvAFec], T1.[ProdCod], T2.[MvARef], T2.[MvAOcom], T2.[DocNum], T1.[MvADCant], T3.[MovAbr], T2.[MvATMov], T1.[MVADPrecio], T1.[MVADCosto], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM (([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T3 ON T3.[MovCod] = T2.[MvAMov]) WHERE (T2.[MvAFec] >= @AV44FDesde) AND (T1.[ProdCod] = RTRIM(LTRIM(@AV69ProdCodC))) AND (T2.[MVSts] <> 'A') AND (T2.[MvAlm] = @AV10AlmCod) AND (T2.[MvAFec] <= @AV46FHasta) ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FO8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00FO9", "SELECT [ComDProCod], [ComDOrdCod], [ComCod], [TipCod], [PrvCod], [ComDItem] FROM [CPCOMPRASDET] WHERE ([ComDProCod] = @AV69ProdCodC) AND ([ComDOrdCod] = @AV66OC) ORDER BY [ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FO9,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P00FO10", "SELECT [SalFCosProdCod], [SalFCosFecha], [SalFCosAlmCod], [SalFCosMVTip], [SalFCosMVCod], [SalFCosCant], [SalFCosUnit], [SalFCosTot], [SalFCosAlmAno], [SalFCosAlmMes] FROM [ACOSTOALMACENFIFO] WHERE ([SalFCosAlmCod] = @AV10AlmCod) AND ([SalFCosFecha] < @AV44FDesde) AND ([SalFCosProdCod] = @AV69ProdCodC) ORDER BY [SalFCosAlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FO10,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P00FO11", "DELETE FROM [AMOVIMIENTOSFIFO]  WHERE [FifoAlmCod] = @AV10AlmCod", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FO11)
           ,new CursorDef("P00FO12", "SELECT [SalFCosMVCod], [SalFCosProdCod], [SalFCosFecha], [SalFCosCant] - [SalFCosCantFifo] AS SalFCosCantSaldo, [SalFCosUnit], [SalFCosAlmMes], [SalFCosAlmAno], [SalFCosAlmCod], [SalFCosCant], [SalFCosCantFifo], [SalFCosMVTip] FROM [ACOSTOALMACENFIFO] WHERE ([SalFCosAlmCod] = @AV10AlmCod and [SalFCosAlmAno] = @AV12Ano2 and [SalFCosAlmMes] = @AV58Mes2) AND (Not ([SalFCosCant] - [SalFCosCantFifo] = convert(int, 0))) ORDER BY [SalFCosAlmCod], [SalFCosAlmAno], [SalFCosAlmMes] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FO12,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00FO13", "INSERT INTO [AMOVIMIENTOSFIFO]([FifoAlmCod], [FifoMVACod], [FifoProdCod], [FifoMVADItem], [FifoMVAFec], [FifoMVADCant], [FifoMVADPrecio], [FifoMVADCosto], [FifoMVADCantFifo]) VALUES(@FifoAlmCod, @FifoMVACod, @FifoProdCod, @FifoMVADItem, @FifoMVAFec, @FifoMVADCant, @FifoMVADPrecio, @FifoMVADCosto, convert(int, 0))", GxErrorMask.GX_NOMASK,prmP00FO13)
           ,new CursorDef("P00FO14", "SELECT T2.[LinCod], T1.[MvACod], T1.[ProdCod], T1.[MvADItem], T4.[MvAFec], T1.[MvADCant], T1.[MVADPrecio], T1.[MVADCosto], T4.[MVSts], T1.[MvATip], T5.[AlmCos] AS MvAlmCos, T3.[LinStk], T4.[MvAlm] AS MvAlm FROM (((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [AGUIAS] T4 ON T4.[MvATip] = T1.[MvATip] AND T4.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T5 ON T5.[AlmCod] = T4.[MvAlm]) WHERE (T1.[MvATip] = 'ING') AND (Not T4.[MVSts] = 'A') AND (T4.[MvAFec] >= @AV44FDesde) AND (T4.[MvAFec] <= @AV46FHasta) AND (T4.[MvAlm] = @AV10AlmCod) AND (T3.[LinStk] = 1) AND (T5.[AlmCos] = 1) ORDER BY T1.[MvATip] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FO14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00FO15", "INSERT INTO [AMOVIMIENTOSFIFO]([FifoAlmCod], [FifoMVACod], [FifoProdCod], [FifoMVADItem], [FifoMVAFec], [FifoMVADCant], [FifoMVADPrecio], [FifoMVADCosto], [FifoMVADCantFifo]) VALUES(@FifoAlmCod, @FifoMVACod, @FifoProdCod, @FifoMVADItem, @FifoMVAFec, @FifoMVADCant, @FifoMVADPrecio, @FifoMVADCosto, convert(int, 0))", GxErrorMask.GX_NOMASK,prmP00FO15)
           ,new CursorDef("P00FO16", "SELECT [FifoAlmCod], [FifoProdCod], [FifoMVADCant] - [FifoMVADCantFifo] AS FifoMVADCantSaldo, [FifoMVADPrecio], [FifoMVACod], [FifoMVAFec], [FifoMVADCant], [FifoMVADCantFifo], [FifoMVADItem] FROM [AMOVIMIENTOSFIFO] WITH (UPDLOCK) WHERE (Not ([FifoMVADCant] - [FifoMVADCantFifo] = convert(int, 0))) AND ([FifoAlmCod] = @AV10AlmCod) AND ([FifoProdCod] = @AV69ProdCodC) ORDER BY [FifoMVAFec] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FO16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00FO17", "UPDATE [AMOVIMIENTOSFIFO] SET [FifoMVADCantFifo]=@FifoMVADCantFifo  WHERE [FifoAlmCod] = @FifoAlmCod AND [FifoMVACod] = @FifoMVACod AND [FifoProdCod] = @FifoProdCod AND [FifoMVADItem] = @FifoMVADItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FO17)
           ,new CursorDef("P00FO18", "UPDATE [AMOVIMIENTOSFIFO] SET [FifoMVADCantFifo]=@FifoMVADCantFifo  WHERE [FifoAlmCod] = @FifoAlmCod AND [FifoMVACod] = @FifoMVACod AND [FifoProdCod] = @FifoProdCod AND [FifoMVADItem] = @FifoMVADItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FO18)
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
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
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
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((string[]) buf[4])[0] = rslt.getString(5, 12);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((string[]) buf[7])[0] = rslt.getString(8, 12);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 5);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((short[]) buf[12])[0] = rslt.getShort(11);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
              ((string[]) buf[15])[0] = rslt.getString(14, 12);
              ((string[]) buf[16])[0] = rslt.getString(15, 3);
              ((int[]) buf[17])[0] = rslt.getInt(16);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 10);
              ((string[]) buf[3])[0] = rslt.getString(3, 15);
              ((string[]) buf[4])[0] = rslt.getString(4, 3);
              ((string[]) buf[5])[0] = rslt.getString(5, 20);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 1);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((int[]) buf[12])[0] = rslt.getInt(13);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 12);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
     }
  }

}

}
