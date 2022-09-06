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
   public class r_kardexvalorizadopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "produccion.r_kardexvalorizadopdf.aspx")), "produccion.r_kardexvalorizadopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "produccion.r_kardexvalorizadopdf.aspx")))) ;
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
                  AV10Prodcod = GetPar( "Prodcod");
                  AV76FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV77FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
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

      public r_kardexvalorizadopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_kardexvalorizadopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SublCod ,
                           ref int aP2_FamCod ,
                           ref string aP3_Prodcod ,
                           ref DateTime aP4_FDesde ,
                           ref DateTime aP5_FHasta )
      {
         this.AV8LinCod = aP0_LinCod;
         this.AV45SublCod = aP1_SublCod;
         this.AV46FamCod = aP2_FamCod;
         this.AV10Prodcod = aP3_Prodcod;
         this.AV76FDesde = aP4_FDesde;
         this.AV77FHasta = aP5_FHasta;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV8LinCod;
         aP1_SublCod=this.AV45SublCod;
         aP2_FamCod=this.AV46FamCod;
         aP3_Prodcod=this.AV10Prodcod;
         aP4_FDesde=this.AV76FDesde;
         aP5_FHasta=this.AV77FHasta;
      }

      public DateTime executeUdp( ref int aP0_LinCod ,
                                  ref int aP1_SublCod ,
                                  ref int aP2_FamCod ,
                                  ref string aP3_Prodcod ,
                                  ref DateTime aP4_FDesde )
      {
         execute(ref aP0_LinCod, ref aP1_SublCod, ref aP2_FamCod, ref aP3_Prodcod, ref aP4_FDesde, ref aP5_FHasta);
         return AV77FHasta ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SublCod ,
                                 ref int aP2_FamCod ,
                                 ref string aP3_Prodcod ,
                                 ref DateTime aP4_FDesde ,
                                 ref DateTime aP5_FHasta )
      {
         r_kardexvalorizadopdf objr_kardexvalorizadopdf;
         objr_kardexvalorizadopdf = new r_kardexvalorizadopdf();
         objr_kardexvalorizadopdf.AV8LinCod = aP0_LinCod;
         objr_kardexvalorizadopdf.AV45SublCod = aP1_SublCod;
         objr_kardexvalorizadopdf.AV46FamCod = aP2_FamCod;
         objr_kardexvalorizadopdf.AV10Prodcod = aP3_Prodcod;
         objr_kardexvalorizadopdf.AV76FDesde = aP4_FDesde;
         objr_kardexvalorizadopdf.AV77FHasta = aP5_FHasta;
         objr_kardexvalorizadopdf.context.SetSubmitInitialConfig(context);
         objr_kardexvalorizadopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_kardexvalorizadopdf);
         aP0_LinCod=this.AV8LinCod;
         aP1_SublCod=this.AV45SublCod;
         aP2_FamCod=this.AV46FamCod;
         aP3_Prodcod=this.AV10Prodcod;
         aP4_FDesde=this.AV76FDesde;
         aP5_FHasta=this.AV77FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_kardexvalorizadopdf)stateInfo).executePrivate();
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
            AV39Empresa = AV44Session.Get("Empresa");
            AV40EmpDir = AV44Session.Get("EmpDir");
            AV41EmpRUC = AV44Session.Get("EmpRUC");
            AV42Ruta = AV44Session.Get("RUTA") + "/Logo.jpg";
            AV43Logo = AV42Ruta;
            AV94Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV66UsuCod = AV44Session.Get("UsuCod");
            AV12Titulo = "Kardex Valorizado";
            AV22Filtro1 = "(Todos)";
            AV24Filtro2 = "(Todos)";
            /* Using cursor P00FN2 */
            pr_default.execute(0, new Object[] {AV8LinCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A52LinCod = P00FN2_A52LinCod[0];
               A1153LinDsc = P00FN2_A1153LinDsc[0];
               AV22Filtro1 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00FN3 */
            pr_default.execute(1, new Object[] {AV10Prodcod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = P00FN3_A28ProdCod[0];
               A55ProdDsc = P00FN3_A55ProdDsc[0];
               AV24Filtro2 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV49CostoTotal = 0;
            AV81TCantidad = 0;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV8LinCod ,
                                                 AV45SublCod ,
                                                 AV46FamCod ,
                                                 AV10Prodcod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A28ProdCod ,
                                                 A1158LinStk ,
                                                 A1269MvAlmCos } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00FN4 */
            pr_default.execute(2, new Object[] {AV8LinCod, AV45SublCod, AV46FamCod, AV10Prodcod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               BRKFN5 = false;
               A13MvATip = P00FN4_A13MvATip[0];
               A14MvACod = P00FN4_A14MvACod[0];
               A21MvAlm = P00FN4_A21MvAlm[0];
               A49UniCod = P00FN4_A49UniCod[0];
               A55ProdDsc = P00FN4_A55ProdDsc[0];
               A28ProdCod = P00FN4_A28ProdCod[0];
               A1269MvAlmCos = P00FN4_A1269MvAlmCos[0];
               A1158LinStk = P00FN4_A1158LinStk[0];
               A50FamCod = P00FN4_A50FamCod[0];
               n50FamCod = P00FN4_n50FamCod[0];
               A51SublCod = P00FN4_A51SublCod[0];
               n51SublCod = P00FN4_n51SublCod[0];
               A52LinCod = P00FN4_A52LinCod[0];
               A1997UniAbr = P00FN4_A1997UniAbr[0];
               A30MvADItem = P00FN4_A30MvADItem[0];
               A21MvAlm = P00FN4_A21MvAlm[0];
               A1269MvAlmCos = P00FN4_A1269MvAlmCos[0];
               A49UniCod = P00FN4_A49UniCod[0];
               A55ProdDsc = P00FN4_A55ProdDsc[0];
               A50FamCod = P00FN4_A50FamCod[0];
               n50FamCod = P00FN4_n50FamCod[0];
               A51SublCod = P00FN4_A51SublCod[0];
               n51SublCod = P00FN4_n51SublCod[0];
               A52LinCod = P00FN4_A52LinCod[0];
               A1997UniAbr = P00FN4_A1997UniAbr[0];
               A1158LinStk = P00FN4_A1158LinStk[0];
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00FN4_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRKFN5 = false;
                  A13MvATip = P00FN4_A13MvATip[0];
                  A14MvACod = P00FN4_A14MvACod[0];
                  A55ProdDsc = P00FN4_A55ProdDsc[0];
                  A30MvADItem = P00FN4_A30MvADItem[0];
                  A55ProdDsc = P00FN4_A55ProdDsc[0];
                  BRKFN5 = true;
                  pr_default.readNext(2);
               }
               AV36ProdCodC = StringUtil.Trim( A28ProdCod);
               AV15Producto = A55ProdDsc;
               AV65UniAbr = A1997UniAbr;
               AV70CanIni = 0;
               AV68TCosIni = 0;
               AV69TCosTIni = 0;
               AV54Ing1 = 0;
               AV55IngCU = 0;
               AV53IngCT = 0;
               AV73TTIngreso = 0;
               AV71TIngresoCT = 0;
               AV78TIngresoCU = 0;
               AV56Sal1 = 0;
               AV57SalCU = 0;
               AV58SalCT = 0;
               AV74TTSalida = 0;
               AV72TsalidaCT = 0;
               AV79TSalidaCU = 0;
               AV17Final = 0;
               new GeneXus.Programs.produccion.pobtenersaldocostoproductofechas(context ).execute( ref  AV76FDesde, ref  AV36ProdCodC, out  AV16Saldo, out  AV27CostoU) ;
               AV28CostoT = NumberUtil.Round( AV16Saldo*AV27CostoU, 2);
               AV31TCosto = AV28CostoT;
               AV17Final = AV16Saldo;
               /* Execute user subroutine: 'VALIDA' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               if ( ( AV26Flag == 0 ) || ( AV16Saldo != Convert.ToDecimal( 0 )) )
               {
                  HFN0( false, 22) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Producto : ", 25, Gx_line+5, 82, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Producto, "")), 197, Gx_line+2, 629, Gx_line+20, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65UniAbr, "")), 639, Gx_line+5, 682, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36ProdCodC, "@!")), 81, Gx_line+2, 194, Gx_line+20, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+22);
               }
               AV18Ingresa = 0;
               AV19Salida = 0;
               AV75Ceros = 0;
               AV29TIngreso = ((AV16Saldo>Convert.ToDecimal(0)) ? AV16Saldo : (decimal)(0));
               AV30TSalida = ((AV16Saldo<Convert.ToDecimal(0)) ? AV16Saldo : (decimal)(0));
               AV33CostoUAnt = AV27CostoU;
               if ( ( AV16Saldo != Convert.ToDecimal( 0 )) )
               {
                  AV70CanIni = AV29TIngreso;
                  AV68TCosIni = AV33CostoUAnt;
                  AV69TCosTIni = NumberUtil.Round( AV70CanIni*AV68TCosIni, 2);
                  HFN0( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54Ing1, "ZZZZ,ZZZ,ZZ9.9999")), 555, Gx_line+3, 645, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55IngCU, "ZZZZ,ZZZ,ZZ9.9999")), 615, Gx_line+3, 705, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53IngCT, "ZZZZZZ,ZZZ,ZZ9.99")), 668, Gx_line+3, 758, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57SalCU, "ZZZZ,ZZZ,ZZ9.9999")), 785, Gx_line+3, 875, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58SalCT, "ZZZZZZ,ZZZ,ZZ9.99")), 842, Gx_line+3, 932, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56Sal1, "ZZZZ,ZZZ,ZZ9.9999")), 729, Gx_line+3, 819, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27CostoU, "ZZZZ,ZZZ,ZZ9.9999")), 1017, Gx_line+3, 1107, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 903, Gx_line+3, 993, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28CostoT, "ZZZZZZ,ZZZ,ZZ9.99")), 961, Gx_line+3, 1051, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70CanIni, "ZZZZ,ZZZ,ZZ9.9999")), 369, Gx_line+3, 459, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68TCosIni, "ZZZZ,ZZZ,ZZ9.9999")), 429, Gx_line+3, 519, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69TCosTIni, "ZZZZZZ,ZZZ,ZZ9.99")), 495, Gx_line+3, 585, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Saldo Inicial", 294, Gx_line+3, 359, Gx_line+16, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
               }
               /* Execute user subroutine: 'DETALLEMOVIMIENTOS' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               if ( ( AV17Final <= Convert.ToDecimal( 0 )) )
               {
                  AV27CostoU = 0;
                  AV28CostoT = 0;
               }
               if ( ( AV26Flag == 0 ) || ( AV16Saldo != Convert.ToDecimal( 0 )) )
               {
                  HFN0( false, 34) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Producto, "")), 111, Gx_line+9, 399, Gx_line+27, 2, 0, 0, 0) ;
                  getPrinter().GxDrawLine(403, Gx_line+7, 1110, Gx_line+7, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 903, Gx_line+13, 993, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28CostoT, "ZZZZZZ,ZZZ,ZZ9.99")), 961, Gx_line+13, 1051, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27CostoU, "ZZZZ,ZZZ,ZZ9.9999")), 1017, Gx_line+13, 1107, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV73TTIngreso, "ZZZZ,ZZZ,ZZ9.9999")), 555, Gx_line+13, 645, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71TIngresoCT, "ZZZZZZ,ZZZ,ZZ9.99")), 668, Gx_line+13, 758, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72TsalidaCT, "ZZZZZZ,ZZZ,ZZ9.99")), 842, Gx_line+13, 932, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV74TTSalida, "ZZZZ,ZZZ,ZZ9.9999")), 729, Gx_line+13, 819, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70CanIni, "ZZZZ,ZZZ,ZZ9.9999")), 369, Gx_line+14, 459, Gx_line+27, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68TCosIni, "ZZZZ,ZZZ,ZZ9.9999")), 429, Gx_line+14, 519, Gx_line+27, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69TCosTIni, "ZZZZZZ,ZZZ,ZZ9.99")), 495, Gx_line+14, 585, Gx_line+27, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV78TIngresoCU, "ZZZZ,ZZZ,ZZ9.9999")), 615, Gx_line+13, 705, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV79TSalidaCU, "ZZZZ,ZZZ,ZZ9.9999")), 785, Gx_line+13, 875, Gx_line+26, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+34);
               }
               AV49CostoTotal = (decimal)(AV49CostoTotal+AV28CostoT);
               AV81TCantidad = (decimal)(AV81TCantidad+AV17Final);
               if ( ! BRKFN5 )
               {
                  BRKFN5 = true;
                  pr_default.readNext(2);
               }
            }
            pr_default.close(2);
            HFN0( false, 55) ;
            getPrinter().GxDrawLine(784, Gx_line+13, 1108, Gx_line+13, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49CostoTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 1018, Gx_line+22, 1108, Gx_line+35, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Totales", 765, Gx_line+22, 805, Gx_line+35, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV81TCantidad, "ZZZZ,ZZZ,ZZ9.9999")), 842, Gx_line+22, 932, Gx_line+35, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+55);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HFN0( true, 0) ;
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
         AV26Flag = 1;
         /* Using cursor P00FN5 */
         pr_default.execute(3, new Object[] {AV76FDesde, AV36ProdCodC, AV77FHasta});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A21MvAlm = P00FN5_A21MvAlm[0];
            A52LinCod = P00FN5_A52LinCod[0];
            A1158LinStk = P00FN5_A1158LinStk[0];
            A1269MvAlmCos = P00FN5_A1269MvAlmCos[0];
            A1370MVSts = P00FN5_A1370MVSts[0];
            A25MvAFec = P00FN5_A25MvAFec[0];
            A28ProdCod = P00FN5_A28ProdCod[0];
            A14MvACod = P00FN5_A14MvACod[0];
            A13MvATip = P00FN5_A13MvATip[0];
            A19MVCDesItem = P00FN5_A19MVCDesItem[0];
            n19MVCDesItem = P00FN5_n19MVCDesItem[0];
            A30MvADItem = P00FN5_A30MvADItem[0];
            A52LinCod = P00FN5_A52LinCod[0];
            A1158LinStk = P00FN5_A1158LinStk[0];
            A21MvAlm = P00FN5_A21MvAlm[0];
            A1370MVSts = P00FN5_A1370MVSts[0];
            A25MvAFec = P00FN5_A25MvAFec[0];
            A19MVCDesItem = P00FN5_A19MVCDesItem[0];
            n19MVCDesItem = P00FN5_n19MVCDesItem[0];
            A1269MvAlmCos = P00FN5_A1269MvAlmCos[0];
            AV26Flag = 0;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S121( )
      {
         /* 'DETALLEMOVIMIENTOS' Routine */
         returnInSub = false;
         /* Using cursor P00FN6 */
         pr_default.execute(4, new Object[] {AV76FDesde, AV36ProdCodC, AV77FHasta});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A22MvAMov = P00FN6_A22MvAMov[0];
            A21MvAlm = P00FN6_A21MvAlm[0];
            A52LinCod = P00FN6_A52LinCod[0];
            A1158LinStk = P00FN6_A1158LinStk[0];
            A1269MvAlmCos = P00FN6_A1269MvAlmCos[0];
            A1370MVSts = P00FN6_A1370MVSts[0];
            A25MvAFec = P00FN6_A25MvAFec[0];
            A28ProdCod = P00FN6_A28ProdCod[0];
            A1278MvARef = P00FN6_A1278MvARef[0];
            A1276MvAOcom = P00FN6_A1276MvAOcom[0];
            A24DocNum = P00FN6_A24DocNum[0];
            n24DocNum = P00FN6_n24DocNum[0];
            A1248MvADCant = P00FN6_A1248MvADCant[0];
            A1237MovAbr = P00FN6_A1237MovAbr[0];
            n1237MovAbr = P00FN6_n1237MovAbr[0];
            A1286MvATMov = P00FN6_A1286MvATMov[0];
            A1154LinRef1 = P00FN6_A1154LinRef1[0];
            A1258MVADRef1 = P00FN6_A1258MVADRef1[0];
            A1250MVADPrecio = P00FN6_A1250MVADPrecio[0];
            A1249MVADCosto = P00FN6_A1249MVADCosto[0];
            A14MvACod = P00FN6_A14MvACod[0];
            A13MvATip = P00FN6_A13MvATip[0];
            A19MVCDesItem = P00FN6_A19MVCDesItem[0];
            n19MVCDesItem = P00FN6_n19MVCDesItem[0];
            A30MvADItem = P00FN6_A30MvADItem[0];
            A52LinCod = P00FN6_A52LinCod[0];
            A1158LinStk = P00FN6_A1158LinStk[0];
            A1154LinRef1 = P00FN6_A1154LinRef1[0];
            A22MvAMov = P00FN6_A22MvAMov[0];
            A21MvAlm = P00FN6_A21MvAlm[0];
            A1370MVSts = P00FN6_A1370MVSts[0];
            A25MvAFec = P00FN6_A25MvAFec[0];
            A1278MvARef = P00FN6_A1278MvARef[0];
            A1276MvAOcom = P00FN6_A1276MvAOcom[0];
            A24DocNum = P00FN6_A24DocNum[0];
            n24DocNum = P00FN6_n24DocNum[0];
            A1286MvATMov = P00FN6_A1286MvATMov[0];
            A19MVCDesItem = P00FN6_A19MVCDesItem[0];
            n19MVCDesItem = P00FN6_n19MVCDesItem[0];
            A1237MovAbr = P00FN6_A1237MovAbr[0];
            n1237MovAbr = P00FN6_n1237MovAbr[0];
            A1269MvAlmCos = P00FN6_A1269MvAlmCos[0];
            AV34MVATip = A13MvATip;
            AV35MVACod = A14MvACod;
            AV82MVAFec = A25MvAFec;
            AV47DocRef = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? (String.IsNullOrEmpty(StringUtil.RTrim( A1276MvAOcom)) ? A1278MvARef : A1276MvAOcom) : A24DocNum);
            AV50DocNum = A24DocNum;
            AV51OC = A1276MvAOcom;
            AV52OCP = A1278MvARef;
            AV18Ingresa = ((StringUtil.StrCmp(A13MvATip, "ING")==0) ? NumberUtil.Round( A1248MvADCant, 4) : (decimal)(0));
            AV19Salida = ((StringUtil.StrCmp(A13MvATip, "ING")!=0) ? NumberUtil.Round( A1248MvADCant, 4) : (decimal)(0));
            AV27CostoU = 0;
            AV28CostoT = 0;
            AV67MovAbr = A1237MovAbr;
            AV80MvATMov = A1286MvATMov;
            AV84LinRef1 = A1154LinRef1;
            AV83Lote = StringUtil.Trim( A1258MVADRef1);
            AV54Ing1 = 0;
            AV55IngCU = 0;
            AV53IngCT = 0;
            AV56Sal1 = 0;
            AV57SalCU = 0;
            AV58SalCT = 0;
            AV91FlagLote = 0;
            if ( StringUtil.StrCmp(A13MvATip, "ING") == 0 )
            {
               AV27CostoU = NumberUtil.Round( A1250MVADPrecio, 4);
               AV28CostoT = NumberUtil.Round( A1249MVADCosto, 2);
               AV31TCosto = (decimal)(AV31TCosto+AV28CostoT);
               AV33CostoUAnt = 0;
               AV54Ing1 = AV18Ingresa;
               AV55IngCU = AV27CostoU;
               AV53IngCT = AV28CostoT;
               if ( ( AV80MvATMov == 1 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV51OC)) )
               {
                  /* Execute user subroutine: 'VALIDADOC' */
                  S138 ();
                  if ( returnInSub )
                  {
                     pr_default.close(4);
                     returnInSub = true;
                     if (true) return;
                  }
               }
            }
            else
            {
               if ( ! (Convert.ToDecimal(0)==AV33CostoUAnt) )
               {
                  AV27CostoU = AV33CostoUAnt;
               }
               else
               {
                  if ( ( AV17Final <= Convert.ToDecimal( 0 )) )
                  {
                     AV27CostoU = 0;
                  }
                  else
                  {
                     AV27CostoU = NumberUtil.Round( AV31TCosto/ (decimal)(AV17Final), 4);
                  }
               }
               AV28CostoT = NumberUtil.Round( AV27CostoU*AV19Salida, 2);
               AV31TCosto = (decimal)(AV31TCosto+(NumberUtil.Round( AV28CostoT*-1, 2)));
               AV33CostoUAnt = AV27CostoU;
               AV56Sal1 = AV19Salida;
               AV57SalCU = AV27CostoU;
               AV58SalCT = AV28CostoT;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84LinRef1)) )
               {
                  /* Execute user subroutine: 'VALIDASALIDASLOTES' */
                  S148 ();
                  if ( returnInSub )
                  {
                     pr_default.close(4);
                     returnInSub = true;
                     if (true) return;
                  }
               }
            }
            AV73TTIngreso = (decimal)(AV73TTIngreso+AV54Ing1);
            AV71TIngresoCT = (decimal)(AV71TIngresoCT+AV53IngCT);
            AV78TIngresoCU = ((AV73TTIngreso>Convert.ToDecimal(0)) ? NumberUtil.Round( AV71TIngresoCT/ (decimal)(AV73TTIngreso), 6) : (decimal)(0));
            AV74TTSalida = (decimal)(AV74TTSalida+AV56Sal1);
            AV72TsalidaCT = (decimal)(AV72TsalidaCT+AV58SalCT);
            AV79TSalidaCU = ((AV74TTSalida>Convert.ToDecimal(0)) ? NumberUtil.Round( AV72TsalidaCT/ (decimal)(AV74TTSalida), 6) : (decimal)(0));
            AV17Final = (decimal)(AV17Final+((AV18Ingresa-AV19Salida)));
            AV29TIngreso = (decimal)(AV29TIngreso+AV18Ingresa);
            AV30TSalida = (decimal)(AV30TSalida+AV19Salida);
            if ( ! (Convert.ToDecimal(0)==AV33CostoUAnt) )
            {
               AV27CostoU = AV33CostoUAnt;
            }
            else
            {
               if ( ( AV17Final <= Convert.ToDecimal( 0 )) )
               {
                  AV27CostoU = 0;
               }
               else
               {
                  AV27CostoU = NumberUtil.Round( AV31TCosto/ (decimal)(AV17Final), 4);
               }
            }
            AV28CostoT = NumberUtil.Round( AV27CostoU*AV17Final, 2);
            AV31TCosto = AV28CostoT;
            if ( AV91FlagLote == 0 )
            {
               HFN0( false, 16) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 6, Gx_line+1, 45, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), 84, Gx_line+1, 135, Gx_line+14, 1+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13MvATip, "")), 48, Gx_line+0, 80, Gx_line+14, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67MovAbr, "")), 142, Gx_line+0, 185, Gx_line+13, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50DocNum, "")), 181, Gx_line+1, 232, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51OC, "")), 230, Gx_line+1, 273, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52OCP, "")), 289, Gx_line+1, 332, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54Ing1, "ZZZZ,ZZZ,ZZ9.9999")), 555, Gx_line+1, 645, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55IngCU, "ZZZZ,ZZZ,ZZ9.9999")), 615, Gx_line+1, 705, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53IngCT, "ZZZZZZ,ZZZ,ZZ9.99")), 668, Gx_line+1, 758, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57SalCU, "ZZZZ,ZZZ,ZZ9.9999")), 785, Gx_line+1, 875, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58SalCT, "ZZZZZZ,ZZZ,ZZ9.99")), 842, Gx_line+1, 932, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56Sal1, "ZZZZ,ZZZ,ZZ9.9999")), 729, Gx_line+1, 819, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27CostoU, "ZZZZ,ZZZ,ZZ9.9999")), 1017, Gx_line+1, 1107, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 903, Gx_line+1, 993, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28CostoT, "ZZZZZZ,ZZZ,ZZ9.99")), 961, Gx_line+1, 1051, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 369, Gx_line+1, 459, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 429, Gx_line+1, 519, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 495, Gx_line+1, 585, Gx_line+14, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83Lote, "")), 348, Gx_line+1, 391, Gx_line+14, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+16);
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S138( )
      {
         /* 'VALIDADOC' Routine */
         returnInSub = false;
         /* Using cursor P00FN7 */
         pr_default.execute(5, new Object[] {AV36ProdCodC, AV51OC});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A254ComDProCod = P00FN7_A254ComDProCod[0];
            n254ComDProCod = P00FN7_n254ComDProCod[0];
            A251ComDOrdCod = P00FN7_A251ComDOrdCod[0];
            A243ComCod = P00FN7_A243ComCod[0];
            A149TipCod = P00FN7_A149TipCod[0];
            A244PrvCod = P00FN7_A244PrvCod[0];
            A250ComDItem = P00FN7_A250ComDItem[0];
            AV50DocNum = A243ComCod;
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S148( )
      {
         /* 'VALIDASALIDASLOTES' Routine */
         returnInSub = false;
         AV88FinalLote = AV17Final;
         /* Using cursor P00FN8 */
         pr_default.execute(6, new Object[] {AV34MVATip, AV35MVACod, AV36ProdCodC});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A28ProdCod = P00FN8_A28ProdCod[0];
            A14MvACod = P00FN8_A14MvACod[0];
            A13MvATip = P00FN8_A13MvATip[0];
            A1251MVADLCant = P00FN8_A1251MVADLCant[0];
            A31MVADLRef1 = P00FN8_A31MVADLRef1[0];
            A25MvAFec = P00FN8_A25MvAFec[0];
            A30MvADItem = P00FN8_A30MvADItem[0];
            A25MvAFec = P00FN8_A25MvAFec[0];
            AV85Sal1Lote = A1251MVADLCant;
            AV86Sal1CULote = AV57SalCU;
            AV87Sal1CTLote = NumberUtil.Round( AV85Sal1Lote*AV57SalCU, 2);
            AV88FinalLote = (decimal)(AV88FinalLote+((AV18Ingresa-AV85Sal1Lote)));
            AV89CostoULote = AV86Sal1CULote;
            AV90CostoTLote = NumberUtil.Round( AV89CostoULote*AV88FinalLote, 2);
            AV83Lote = StringUtil.Trim( A31MVADLRef1);
            AV91FlagLote = 1;
            HFN0( false, 16) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 6, Gx_line+1, 45, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), 84, Gx_line+1, 135, Gx_line+14, 1+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13MvATip, "")), 48, Gx_line+0, 80, Gx_line+14, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67MovAbr, "")), 142, Gx_line+0, 185, Gx_line+13, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50DocNum, "")), 181, Gx_line+1, 232, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51OC, "")), 230, Gx_line+1, 273, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52OCP, "")), 289, Gx_line+1, 332, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV86Sal1CULote, "ZZZZ,ZZZ,ZZ9.9999")), 785, Gx_line+1, 875, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87Sal1CTLote, "ZZZZZZ,ZZZ,ZZ9.99")), 842, Gx_line+1, 932, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85Sal1Lote, "ZZZZ,ZZZ,ZZ9.9999")), 729, Gx_line+1, 819, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89CostoULote, "ZZZZ,ZZZ,ZZ9.9999")), 1017, Gx_line+1, 1107, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV88FinalLote, "ZZZZ,ZZZ,ZZ9.9999")), 903, Gx_line+1, 993, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV90CostoTLote, "ZZZZZZ,ZZZ,ZZ9.99")), 961, Gx_line+1, 1051, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 369, Gx_line+1, 459, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 429, Gx_line+1, 519, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 495, Gx_line+1, 585, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83Lote, "")), 348, Gx_line+1, 391, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 555, Gx_line+1, 645, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 615, Gx_line+1, 705, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75Ceros, "ZZZZ,ZZZ,ZZ9.9999")), 668, Gx_line+1, 758, Gx_line+14, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+16);
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void HFN0( bool bFoot ,
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
               getPrinter().GxDrawRect(0, Gx_line+136, 1111, Gx_line+181, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/M", 53, Gx_line+154, 76, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 9, Gx_line+154, 40, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Doc.", 183, Gx_line+154, 222, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 598, Gx_line+166, 645, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Linea :", 332, Gx_line+65, 375, Gx_line+80, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto :", 332, Gx_line+84, 401, Gx_line+99, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde : ", 332, Gx_line+106, 384, Gx_line+121, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 413, Gx_line+59, 778, Gx_line+83, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro2, "")), 413, Gx_line+79, 778, Gx_line+103, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV76FDesde, "99/99/99"), 413, Gx_line+101, 481, Gx_line+125, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Mes :", 538, Gx_line+106, 572, Gx_line+121, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV77FHasta, "99/99/99"), 619, Gx_line+101, 715, Gx_line+125, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12Titulo, "")), 343, Gx_line+27, 799, Gx_line+52, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Corr.", 85, Gx_line+154, 129, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("T/Mov", 139, Gx_line+154, 174, Gx_line+167, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV43Logo)) ? AV94Logo_GXI : AV43Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+3, 175, Gx_line+80) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Empresa, "")), 9, Gx_line+82, 317, Gx_line+100, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41EmpRUC, "")), 9, Gx_line+100, 179, Gx_line+118, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("O/C", 241, Gx_line+154, 263, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Guia - O/P", 282, Gx_line+154, 337, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(589, Gx_line+136, 589, Gx_line+181, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(759, Gx_line+136, 759, Gx_line+181, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 660, Gx_line+166, 704, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 714, Gx_line+166, 758, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 772, Gx_line+166, 819, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 831, Gx_line+166, 875, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 888, Gx_line+166, 932, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 946, Gx_line+166, 993, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 1007, Gx_line+166, 1051, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 1063, Gx_line+166, 1107, Gx_line+179, 0+256, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66UsuCod, "")), 1044, Gx_line+68, 1097, Gx_line+83, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Lote", 353, Gx_line+154, 393, Gx_line+167, 0+256, 0, 0, 0) ;
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
         AV94Logo_GXI = "";
         AV66UsuCod = "";
         AV12Titulo = "";
         AV22Filtro1 = "";
         AV24Filtro2 = "";
         scmdbuf = "";
         P00FN2_A52LinCod = new int[1] ;
         P00FN2_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P00FN3_A28ProdCod = new string[] {""} ;
         P00FN3_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P00FN4_A13MvATip = new string[] {""} ;
         P00FN4_A14MvACod = new string[] {""} ;
         P00FN4_A21MvAlm = new int[1] ;
         P00FN4_A49UniCod = new int[1] ;
         P00FN4_A55ProdDsc = new string[] {""} ;
         P00FN4_A28ProdCod = new string[] {""} ;
         P00FN4_A1269MvAlmCos = new short[1] ;
         P00FN4_A1158LinStk = new short[1] ;
         P00FN4_A50FamCod = new int[1] ;
         P00FN4_n50FamCod = new bool[] {false} ;
         P00FN4_A51SublCod = new int[1] ;
         P00FN4_n51SublCod = new bool[] {false} ;
         P00FN4_A52LinCod = new int[1] ;
         P00FN4_A1997UniAbr = new string[] {""} ;
         P00FN4_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A1997UniAbr = "";
         AV36ProdCodC = "";
         AV15Producto = "";
         AV65UniAbr = "";
         P00FN5_A21MvAlm = new int[1] ;
         P00FN5_A52LinCod = new int[1] ;
         P00FN5_A1158LinStk = new short[1] ;
         P00FN5_A1269MvAlmCos = new short[1] ;
         P00FN5_A1370MVSts = new string[] {""} ;
         P00FN5_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FN5_A28ProdCod = new string[] {""} ;
         P00FN5_A14MvACod = new string[] {""} ;
         P00FN5_A13MvATip = new string[] {""} ;
         P00FN5_A19MVCDesItem = new int[1] ;
         P00FN5_n19MVCDesItem = new bool[] {false} ;
         P00FN5_A30MvADItem = new int[1] ;
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         P00FN6_A22MvAMov = new int[1] ;
         P00FN6_A21MvAlm = new int[1] ;
         P00FN6_A52LinCod = new int[1] ;
         P00FN6_A1158LinStk = new short[1] ;
         P00FN6_A1269MvAlmCos = new short[1] ;
         P00FN6_A1370MVSts = new string[] {""} ;
         P00FN6_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FN6_A28ProdCod = new string[] {""} ;
         P00FN6_A1278MvARef = new string[] {""} ;
         P00FN6_A1276MvAOcom = new string[] {""} ;
         P00FN6_A24DocNum = new string[] {""} ;
         P00FN6_n24DocNum = new bool[] {false} ;
         P00FN6_A1248MvADCant = new decimal[1] ;
         P00FN6_A1237MovAbr = new string[] {""} ;
         P00FN6_n1237MovAbr = new bool[] {false} ;
         P00FN6_A1286MvATMov = new short[1] ;
         P00FN6_A1154LinRef1 = new string[] {""} ;
         P00FN6_A1258MVADRef1 = new string[] {""} ;
         P00FN6_A1250MVADPrecio = new decimal[1] ;
         P00FN6_A1249MVADCosto = new decimal[1] ;
         P00FN6_A14MvACod = new string[] {""} ;
         P00FN6_A13MvATip = new string[] {""} ;
         P00FN6_A19MVCDesItem = new int[1] ;
         P00FN6_n19MVCDesItem = new bool[] {false} ;
         P00FN6_A30MvADItem = new int[1] ;
         A1278MvARef = "";
         A1276MvAOcom = "";
         A24DocNum = "";
         A1237MovAbr = "";
         A1154LinRef1 = "";
         A1258MVADRef1 = "";
         AV34MVATip = "";
         AV35MVACod = "";
         AV82MVAFec = DateTime.MinValue;
         AV47DocRef = "";
         AV50DocNum = "";
         AV51OC = "";
         AV52OCP = "";
         AV67MovAbr = "";
         AV84LinRef1 = "";
         AV83Lote = "";
         P00FN7_A254ComDProCod = new string[] {""} ;
         P00FN7_n254ComDProCod = new bool[] {false} ;
         P00FN7_A251ComDOrdCod = new string[] {""} ;
         P00FN7_A243ComCod = new string[] {""} ;
         P00FN7_A149TipCod = new string[] {""} ;
         P00FN7_A244PrvCod = new string[] {""} ;
         P00FN7_A250ComDItem = new short[1] ;
         A254ComDProCod = "";
         A251ComDOrdCod = "";
         A243ComCod = "";
         A149TipCod = "";
         A244PrvCod = "";
         P00FN8_A28ProdCod = new string[] {""} ;
         P00FN8_A14MvACod = new string[] {""} ;
         P00FN8_A13MvATip = new string[] {""} ;
         P00FN8_A1251MVADLCant = new decimal[1] ;
         P00FN8_A31MVADLRef1 = new string[] {""} ;
         P00FN8_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FN8_A30MvADItem = new int[1] ;
         A31MVADLRef1 = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV43Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_kardexvalorizadopdf__default(),
            new Object[][] {
                new Object[] {
               P00FN2_A52LinCod, P00FN2_A1153LinDsc
               }
               , new Object[] {
               P00FN3_A28ProdCod, P00FN3_A55ProdDsc
               }
               , new Object[] {
               P00FN4_A13MvATip, P00FN4_A14MvACod, P00FN4_A21MvAlm, P00FN4_A49UniCod, P00FN4_A55ProdDsc, P00FN4_A28ProdCod, P00FN4_A1269MvAlmCos, P00FN4_A1158LinStk, P00FN4_A50FamCod, P00FN4_n50FamCod,
               P00FN4_A51SublCod, P00FN4_n51SublCod, P00FN4_A52LinCod, P00FN4_A1997UniAbr, P00FN4_A30MvADItem
               }
               , new Object[] {
               P00FN5_A21MvAlm, P00FN5_A52LinCod, P00FN5_A1158LinStk, P00FN5_A1269MvAlmCos, P00FN5_A1370MVSts, P00FN5_A25MvAFec, P00FN5_A28ProdCod, P00FN5_A14MvACod, P00FN5_A13MvATip, P00FN5_A19MVCDesItem,
               P00FN5_n19MVCDesItem, P00FN5_A30MvADItem
               }
               , new Object[] {
               P00FN6_A22MvAMov, P00FN6_A21MvAlm, P00FN6_A52LinCod, P00FN6_A1158LinStk, P00FN6_A1269MvAlmCos, P00FN6_A1370MVSts, P00FN6_A25MvAFec, P00FN6_A28ProdCod, P00FN6_A1278MvARef, P00FN6_A1276MvAOcom,
               P00FN6_A24DocNum, P00FN6_n24DocNum, P00FN6_A1248MvADCant, P00FN6_A1237MovAbr, P00FN6_n1237MovAbr, P00FN6_A1286MvATMov, P00FN6_A1154LinRef1, P00FN6_A1258MVADRef1, P00FN6_A1250MVADPrecio, P00FN6_A1249MVADCosto,
               P00FN6_A14MvACod, P00FN6_A13MvATip, P00FN6_A19MVCDesItem, P00FN6_n19MVCDesItem, P00FN6_A30MvADItem
               }
               , new Object[] {
               P00FN7_A254ComDProCod, P00FN7_n254ComDProCod, P00FN7_A251ComDOrdCod, P00FN7_A243ComCod, P00FN7_A149TipCod, P00FN7_A244PrvCod, P00FN7_A250ComDItem
               }
               , new Object[] {
               P00FN8_A28ProdCod, P00FN8_A14MvACod, P00FN8_A13MvATip, P00FN8_A1251MVADLCant, P00FN8_A31MVADLRef1, P00FN8_A25MvAFec, P00FN8_A30MvADItem
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
      private short AV26Flag ;
      private short A1286MvATMov ;
      private short AV80MvATMov ;
      private short AV91FlagLote ;
      private short A250ComDItem ;
      private int AV8LinCod ;
      private int AV45SublCod ;
      private int AV46FamCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A21MvAlm ;
      private int A49UniCod ;
      private int A30MvADItem ;
      private int Gx_OldLine ;
      private int A19MVCDesItem ;
      private int A22MvAMov ;
      private decimal AV49CostoTotal ;
      private decimal AV81TCantidad ;
      private decimal AV70CanIni ;
      private decimal AV68TCosIni ;
      private decimal AV69TCosTIni ;
      private decimal AV54Ing1 ;
      private decimal AV55IngCU ;
      private decimal AV53IngCT ;
      private decimal AV73TTIngreso ;
      private decimal AV71TIngresoCT ;
      private decimal AV78TIngresoCU ;
      private decimal AV56Sal1 ;
      private decimal AV57SalCU ;
      private decimal AV58SalCT ;
      private decimal AV74TTSalida ;
      private decimal AV72TsalidaCT ;
      private decimal AV79TSalidaCU ;
      private decimal AV17Final ;
      private decimal AV16Saldo ;
      private decimal AV27CostoU ;
      private decimal AV28CostoT ;
      private decimal AV31TCosto ;
      private decimal AV18Ingresa ;
      private decimal AV19Salida ;
      private decimal AV75Ceros ;
      private decimal AV29TIngreso ;
      private decimal AV30TSalida ;
      private decimal AV33CostoUAnt ;
      private decimal A1248MvADCant ;
      private decimal A1250MVADPrecio ;
      private decimal A1249MVADCosto ;
      private decimal AV88FinalLote ;
      private decimal A1251MVADLCant ;
      private decimal AV85Sal1Lote ;
      private decimal AV86Sal1CULote ;
      private decimal AV87Sal1CTLote ;
      private decimal AV89CostoULote ;
      private decimal AV90CostoTLote ;
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
      private string AV22Filtro1 ;
      private string AV24Filtro2 ;
      private string scmdbuf ;
      private string A1153LinDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string A1997UniAbr ;
      private string AV36ProdCodC ;
      private string AV15Producto ;
      private string AV65UniAbr ;
      private string A1370MVSts ;
      private string A1278MvARef ;
      private string A1276MvAOcom ;
      private string A24DocNum ;
      private string A1237MovAbr ;
      private string A1258MVADRef1 ;
      private string AV34MVATip ;
      private string AV35MVACod ;
      private string AV47DocRef ;
      private string AV50DocNum ;
      private string AV51OC ;
      private string AV52OCP ;
      private string AV67MovAbr ;
      private string A254ComDProCod ;
      private string A251ComDOrdCod ;
      private string A243ComCod ;
      private string A149TipCod ;
      private string A244PrvCod ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV76FDesde ;
      private DateTime AV77FHasta ;
      private DateTime A25MvAFec ;
      private DateTime AV82MVAFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKFN5 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private bool n19MVCDesItem ;
      private bool n24DocNum ;
      private bool n1237MovAbr ;
      private bool n254ComDProCod ;
      private string AV94Logo_GXI ;
      private string A1154LinRef1 ;
      private string AV84LinRef1 ;
      private string AV83Lote ;
      private string A31MVADLRef1 ;
      private string AV43Logo ;
      private string Logo ;
      private IGxSession AV44Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SublCod ;
      private int aP2_FamCod ;
      private string aP3_Prodcod ;
      private DateTime aP4_FDesde ;
      private DateTime aP5_FHasta ;
      private IDataStoreProvider pr_default ;
      private int[] P00FN2_A52LinCod ;
      private string[] P00FN2_A1153LinDsc ;
      private string[] P00FN3_A28ProdCod ;
      private string[] P00FN3_A55ProdDsc ;
      private string[] P00FN4_A13MvATip ;
      private string[] P00FN4_A14MvACod ;
      private int[] P00FN4_A21MvAlm ;
      private int[] P00FN4_A49UniCod ;
      private string[] P00FN4_A55ProdDsc ;
      private string[] P00FN4_A28ProdCod ;
      private short[] P00FN4_A1269MvAlmCos ;
      private short[] P00FN4_A1158LinStk ;
      private int[] P00FN4_A50FamCod ;
      private bool[] P00FN4_n50FamCod ;
      private int[] P00FN4_A51SublCod ;
      private bool[] P00FN4_n51SublCod ;
      private int[] P00FN4_A52LinCod ;
      private string[] P00FN4_A1997UniAbr ;
      private int[] P00FN4_A30MvADItem ;
      private int[] P00FN5_A21MvAlm ;
      private int[] P00FN5_A52LinCod ;
      private short[] P00FN5_A1158LinStk ;
      private short[] P00FN5_A1269MvAlmCos ;
      private string[] P00FN5_A1370MVSts ;
      private DateTime[] P00FN5_A25MvAFec ;
      private string[] P00FN5_A28ProdCod ;
      private string[] P00FN5_A14MvACod ;
      private string[] P00FN5_A13MvATip ;
      private int[] P00FN5_A19MVCDesItem ;
      private bool[] P00FN5_n19MVCDesItem ;
      private int[] P00FN5_A30MvADItem ;
      private int[] P00FN6_A22MvAMov ;
      private int[] P00FN6_A21MvAlm ;
      private int[] P00FN6_A52LinCod ;
      private short[] P00FN6_A1158LinStk ;
      private short[] P00FN6_A1269MvAlmCos ;
      private string[] P00FN6_A1370MVSts ;
      private DateTime[] P00FN6_A25MvAFec ;
      private string[] P00FN6_A28ProdCod ;
      private string[] P00FN6_A1278MvARef ;
      private string[] P00FN6_A1276MvAOcom ;
      private string[] P00FN6_A24DocNum ;
      private bool[] P00FN6_n24DocNum ;
      private decimal[] P00FN6_A1248MvADCant ;
      private string[] P00FN6_A1237MovAbr ;
      private bool[] P00FN6_n1237MovAbr ;
      private short[] P00FN6_A1286MvATMov ;
      private string[] P00FN6_A1154LinRef1 ;
      private string[] P00FN6_A1258MVADRef1 ;
      private decimal[] P00FN6_A1250MVADPrecio ;
      private decimal[] P00FN6_A1249MVADCosto ;
      private string[] P00FN6_A14MvACod ;
      private string[] P00FN6_A13MvATip ;
      private int[] P00FN6_A19MVCDesItem ;
      private bool[] P00FN6_n19MVCDesItem ;
      private int[] P00FN6_A30MvADItem ;
      private string[] P00FN7_A254ComDProCod ;
      private bool[] P00FN7_n254ComDProCod ;
      private string[] P00FN7_A251ComDOrdCod ;
      private string[] P00FN7_A243ComCod ;
      private string[] P00FN7_A149TipCod ;
      private string[] P00FN7_A244PrvCod ;
      private short[] P00FN7_A250ComDItem ;
      private string[] P00FN8_A28ProdCod ;
      private string[] P00FN8_A14MvACod ;
      private string[] P00FN8_A13MvATip ;
      private decimal[] P00FN8_A1251MVADLCant ;
      private string[] P00FN8_A31MVADLRef1 ;
      private DateTime[] P00FN8_A25MvAFec ;
      private int[] P00FN8_A30MvADItem ;
   }

   public class r_kardexvalorizadopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FN4( IGxContext context ,
                                             int AV8LinCod ,
                                             int AV45SublCod ,
                                             int AV46FamCod ,
                                             string AV10Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             short A1158LinStk ,
                                             short A1269MvAlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T2.[MvAlm] AS MvAlm, T4.[UniCod], T4.[ProdDsc], T1.[ProdCod], T3.[AlmCos] AS MvAlmCos, T6.[LinStk], T4.[FamCod], T4.[SublCod], T4.[LinCod], T5.[UniAbr], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T5 ON T5.[UniCod] = T4.[UniCod]) INNER JOIN [CLINEAPROD] T6 ON T6.[LinCod] = T4.[LinCod])";
         AddWhere(sWhereString, "(T6.[LinStk] = 1)");
         AddWhere(sWhereString, "(T3.[AlmCos] = 1)");
         if ( ! (0==AV8LinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV8LinCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV45SublCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV45SublCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV46FamCod) )
         {
            AddWhere(sWhereString, "(T4.[FamCod] = @AV46FamCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV10Prodcod)");
         }
         else
         {
            GXv_int1[3] = 1;
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
               case 2 :
                     return conditional_P00FN4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00FN2;
          prmP00FN2 = new Object[] {
          new ParDef("@AV8LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00FN3;
          prmP00FN3 = new Object[] {
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00FN5;
          prmP00FN5 = new Object[] {
          new ParDef("@AV76FDesde",GXType.Date,8,0) ,
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV77FHasta",GXType.Date,8,0)
          };
          Object[] prmP00FN6;
          prmP00FN6 = new Object[] {
          new ParDef("@AV76FDesde",GXType.Date,8,0) ,
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV77FHasta",GXType.Date,8,0)
          };
          Object[] prmP00FN7;
          prmP00FN7 = new Object[] {
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV51OC",GXType.NChar,10,0)
          };
          Object[] prmP00FN8;
          prmP00FN8 = new Object[] {
          new ParDef("@AV34MVATip",GXType.NChar,3,0) ,
          new ParDef("@AV35MVACod",GXType.NChar,12,0) ,
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0)
          };
          Object[] prmP00FN4;
          prmP00FN4 = new Object[] {
          new ParDef("@AV8LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV45SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV46FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FN2", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV8LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FN2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FN3", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV10Prodcod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FN3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FN4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FN4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FN5", "SELECT TOP 1 T4.[MvAlm] AS MvAlm, T2.[LinCod], T3.[LinStk], T5.[AlmCos] AS MvAlmCos, T4.[MVSts], T4.[MvAFec], T1.[ProdCod], T1.[MvACod], T1.[MvATip], T4.[MVCDesItem], T1.[MvADItem] FROM (((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [AGUIAS] T4 ON T4.[MvATip] = T1.[MvATip] AND T4.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T5 ON T5.[AlmCod] = T4.[MvAlm]) WHERE (T4.[MvAFec] >= @AV76FDesde) AND (T1.[ProdCod] = RTRIM(LTRIM(@AV36ProdCodC))) AND (T4.[MVSts] <> 'A') AND (T3.[LinStk] = 1) AND (T5.[AlmCos] = 1) AND (T4.[MvAFec] <= @AV77FHasta) ORDER BY T4.[MvAFec], T4.[MVCDesItem], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FN5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FN6", "SELECT T4.[MvAMov] AS MvAMov, T4.[MvAlm] AS MvAlm, T2.[LinCod], T3.[LinStk], T6.[AlmCos] AS MvAlmCos, T4.[MVSts], T4.[MvAFec], T1.[ProdCod], T4.[MvARef], T4.[MvAOcom], T4.[DocNum], T1.[MvADCant], T5.[MovAbr], T4.[MvATMov], T3.[LinRef1], T1.[MVADRef1], T1.[MVADPrecio], T1.[MVADCosto], T1.[MvACod], T1.[MvATip], T4.[MVCDesItem], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [AGUIAS] T4 ON T4.[MvATip] = T1.[MvATip] AND T4.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T5 ON T5.[MovCod] = T4.[MvAMov]) INNER JOIN [CALMACEN] T6 ON T6.[AlmCod] = T4.[MvAlm]) WHERE (T4.[MvAFec] >= @AV76FDesde) AND (T1.[ProdCod] = RTRIM(LTRIM(@AV36ProdCodC))) AND (T4.[MVSts] <> 'A') AND (T3.[LinStk] = 1) AND (T6.[AlmCos] = 1) AND (T4.[MvAFec] <= @AV77FHasta) ORDER BY T4.[MvAFec], T4.[MVCDesItem], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FN6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FN7", "SELECT [ComDProCod], [ComDOrdCod], [ComCod], [TipCod], [PrvCod], [ComDItem] FROM [CPCOMPRASDET] WHERE ([ComDProCod] = @AV36ProdCodC) AND ([ComDOrdCod] = @AV51OC) ORDER BY [ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FN7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FN8", "SELECT T1.[ProdCod], T1.[MvACod], T1.[MvATip], T1.[MVADLCant], T1.[MVADLRef1], T2.[MvAFec], T1.[MvADItem] FROM ([AGUIASDETLOTE] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T1.[MvATip] = @AV34MVATip and T1.[MvACod] = @AV35MVACod) AND (T1.[ProdCod] = @AV36ProdCodC) ORDER BY T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FN8,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 5);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((string[]) buf[7])[0] = rslt.getString(8, 12);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 1);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 15);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 10);
                ((string[]) buf[10])[0] = rslt.getString(11, 12);
                ((bool[]) buf[11])[0] = rslt.wasNull(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((string[]) buf[13])[0] = rslt.getString(13, 5);
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                ((short[]) buf[15])[0] = rslt.getShort(14);
                ((string[]) buf[16])[0] = rslt.getVarchar(15);
                ((string[]) buf[17])[0] = rslt.getString(16, 20);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(18);
                ((string[]) buf[20])[0] = rslt.getString(19, 12);
                ((string[]) buf[21])[0] = rslt.getString(20, 3);
                ((int[]) buf[22])[0] = rslt.getInt(21);
                ((bool[]) buf[23])[0] = rslt.wasNull(21);
                ((int[]) buf[24])[0] = rslt.getInt(22);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 10);
                ((string[]) buf[3])[0] = rslt.getString(3, 15);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
