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
   public class r_registroinventariovalorizadohpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_registroinventariovalorizadohpdf.aspx")), "contabilidad.r_registroinventariovalorizadohpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_registroinventariovalorizadohpdf.aspx")))) ;
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

      public r_registroinventariovalorizadohpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_registroinventariovalorizadohpdf( IGxContext context )
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
         r_registroinventariovalorizadohpdf objr_registroinventariovalorizadohpdf;
         objr_registroinventariovalorizadohpdf = new r_registroinventariovalorizadohpdf();
         objr_registroinventariovalorizadohpdf.AV8LinCod = aP0_LinCod;
         objr_registroinventariovalorizadohpdf.AV45SublCod = aP1_SublCod;
         objr_registroinventariovalorizadohpdf.AV46FamCod = aP2_FamCod;
         objr_registroinventariovalorizadohpdf.AV10Prodcod = aP3_Prodcod;
         objr_registroinventariovalorizadohpdf.AV76FDesde = aP4_FDesde;
         objr_registroinventariovalorizadohpdf.AV77FHasta = aP5_FHasta;
         objr_registroinventariovalorizadohpdf.context.SetSubmitInitialConfig(context);
         objr_registroinventariovalorizadohpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_registroinventariovalorizadohpdf);
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
            ((r_registroinventariovalorizadohpdf)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 2, 1, 12240, 15840, 0, 1, 1, 0, 1, 1) )
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
            AV93Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV83Ano = (short)(DateTimeUtil.Year( AV76FDesde));
            AV84Mes = (short)(DateTimeUtil.Month( AV76FDesde));
            AV85FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV84Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV83Ano), 10, 0));
            AV86FechaD = context.localUtil.CToD( AV85FechaC, 2);
            GXt_char1 = AV21cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV84Mes, out  GXt_char1) ;
            AV21cMes = GXt_char1;
            AV87Tipo = "16";
            AV12Titulo = "FORMATO 13.1: REGISTRO DE INVENTARIO PERMANENTE VALORIZADO - DETALLE DE INVENTARIO VALORIZADO";
            AV82Periodo = StringUtil.Upper( AV21cMes) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV83Ano), 10, 0));
            AV89Metodo = "PROMEDIO";
            AV11Almacen = "(Todos)";
            AV22Filtro1 = "";
            AV24Filtro2 = "";
            /* Using cursor P00EW2 */
            pr_default.execute(0, new Object[] {AV8LinCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A52LinCod = P00EW2_A52LinCod[0];
               A1153LinDsc = P00EW2_A1153LinDsc[0];
               AV22Filtro1 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00EW3 */
            pr_default.execute(1, new Object[] {AV10Prodcod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = P00EW3_A28ProdCod[0];
               A55ProdDsc = P00EW3_A55ProdDsc[0];
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
            /* Using cursor P00EW4 */
            pr_default.execute(2, new Object[] {AV8LinCod, AV45SublCod, AV46FamCod, AV10Prodcod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               BRKEW5 = false;
               A13MvATip = P00EW4_A13MvATip[0];
               A14MvACod = P00EW4_A14MvACod[0];
               A21MvAlm = P00EW4_A21MvAlm[0];
               A49UniCod = P00EW4_A49UniCod[0];
               A55ProdDsc = P00EW4_A55ProdDsc[0];
               A28ProdCod = P00EW4_A28ProdCod[0];
               A1269MvAlmCos = P00EW4_A1269MvAlmCos[0];
               A1158LinStk = P00EW4_A1158LinStk[0];
               A50FamCod = P00EW4_A50FamCod[0];
               n50FamCod = P00EW4_n50FamCod[0];
               A51SublCod = P00EW4_A51SublCod[0];
               n51SublCod = P00EW4_n51SublCod[0];
               A52LinCod = P00EW4_A52LinCod[0];
               A2000UniSunat = P00EW4_A2000UniSunat[0];
               A1160LinSunat = P00EW4_A1160LinSunat[0];
               A30MvADItem = P00EW4_A30MvADItem[0];
               A21MvAlm = P00EW4_A21MvAlm[0];
               A1269MvAlmCos = P00EW4_A1269MvAlmCos[0];
               A49UniCod = P00EW4_A49UniCod[0];
               A55ProdDsc = P00EW4_A55ProdDsc[0];
               A50FamCod = P00EW4_A50FamCod[0];
               n50FamCod = P00EW4_n50FamCod[0];
               A51SublCod = P00EW4_A51SublCod[0];
               n51SublCod = P00EW4_n51SublCod[0];
               A52LinCod = P00EW4_A52LinCod[0];
               A2000UniSunat = P00EW4_A2000UniSunat[0];
               A1158LinStk = P00EW4_A1158LinStk[0];
               A1160LinSunat = P00EW4_A1160LinSunat[0];
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00EW4_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRKEW5 = false;
                  A13MvATip = P00EW4_A13MvATip[0];
                  A14MvACod = P00EW4_A14MvACod[0];
                  A55ProdDsc = P00EW4_A55ProdDsc[0];
                  A30MvADItem = P00EW4_A30MvADItem[0];
                  A55ProdDsc = P00EW4_A55ProdDsc[0];
                  BRKEW5 = true;
                  pr_default.readNext(2);
               }
               AV36ProdCodC = StringUtil.Trim( A28ProdCod);
               AV15Producto = StringUtil.Trim( A28ProdCod) + " - " + StringUtil.Trim( A55ProdDsc);
               AV65UniAbr = StringUtil.Trim( A2000UniSunat);
               AV90LinSunat = StringUtil.Trim( A1160LinSunat);
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
                  HEW0( false, 22) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Producto : ", 24, Gx_line+4, 88, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Producto, "")), 88, Gx_line+5, 436, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65UniAbr, "")), 999, Gx_line+4, 1052, Gx_line+19, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Tipo de Existencia :", 664, Gx_line+4, 776, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Codigo Unidad Medida : ", 851, Gx_line+4, 991, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV90LinSunat, "")), 781, Gx_line+4, 834, Gx_line+19, 0+256, 0, 0, 0) ;
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
                  HEW0( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70CanIni, "ZZZZ,ZZZ,ZZ9.9999")), 327, Gx_line+2, 434, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68TCosIni, "ZZZZ,ZZZ,ZZ9.9999")), 423, Gx_line+3, 513, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69TCosTIni, "ZZZZZZ,ZZZ,ZZ9.99")), 502, Gx_line+3, 592, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57SalCU, "ZZZZ,ZZZ,ZZ9.9999")), 666, Gx_line+3, 756, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58SalCT, "ZZZZZZ,ZZZ,ZZ9.99")), 746, Gx_line+3, 836, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56Sal1, "ZZZZ,ZZZ,ZZ9.9999")), 588, Gx_line+3, 678, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27CostoU, "ZZZZ,ZZZ,ZZ9.9999")), 906, Gx_line+3, 996, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 827, Gx_line+3, 917, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28CostoT, "ZZZZZZ,ZZZ,ZZ9.99")), 989, Gx_line+3, 1079, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV76FDesde, "99/99/99"), 33, Gx_line+3, 72, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV87Tipo, "")), 309, Gx_line+3, 352, Gx_line+16, 1+256, 0, 0, 0) ;
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
                  HEW0( false, 34) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Producto, "")), 24, Gx_line+9, 326, Gx_line+27, 2, 0, 0, 0) ;
                  getPrinter().GxDrawLine(359, Gx_line+5, 1079, Gx_line+5, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 827, Gx_line+13, 917, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28CostoT, "ZZZZZZ,ZZZ,ZZ9.99")), 989, Gx_line+13, 1079, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27CostoU, "ZZZZ,ZZZ,ZZ9.9999")), 906, Gx_line+13, 996, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV73TTIngreso, "ZZZZ,ZZZ,ZZ9.9999")), 345, Gx_line+13, 435, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71TIngresoCT, "ZZZZZZ,ZZZ,ZZ9.99")), 502, Gx_line+13, 592, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72TsalidaCT, "ZZZZZZ,ZZZ,ZZ9.99")), 746, Gx_line+13, 836, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV74TTSalida, "ZZZZ,ZZZ,ZZ9.9999")), 588, Gx_line+13, 678, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV78TIngresoCU, "ZZZZ,ZZZ,ZZ9.9999")), 423, Gx_line+13, 513, Gx_line+26, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV79TSalidaCU, "ZZZZ,ZZZ,ZZ9.9999")), 666, Gx_line+13, 756, Gx_line+26, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+34);
               }
               AV49CostoTotal = (decimal)(AV49CostoTotal+AV28CostoT);
               AV81TCantidad = (decimal)(AV81TCantidad+AV17Final);
               if ( ! BRKEW5 )
               {
                  BRKEW5 = true;
                  pr_default.readNext(2);
               }
            }
            pr_default.close(2);
            HEW0( false, 55) ;
            getPrinter().GxDrawLine(818, Gx_line+13, 1079, Gx_line+13, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49CostoTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 971, Gx_line+22, 1078, Gx_line+37, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Totales", 476, Gx_line+22, 521, Gx_line+36, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV81TCantidad, "ZZZZ,ZZZ,ZZ9.9999")), 809, Gx_line+22, 916, Gx_line+37, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+55);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HEW0( true, 0) ;
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
         /* Using cursor P00EW5 */
         pr_default.execute(3, new Object[] {AV76FDesde, AV36ProdCodC, AV77FHasta});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A21MvAlm = P00EW5_A21MvAlm[0];
            A52LinCod = P00EW5_A52LinCod[0];
            A1158LinStk = P00EW5_A1158LinStk[0];
            A1269MvAlmCos = P00EW5_A1269MvAlmCos[0];
            A1370MVSts = P00EW5_A1370MVSts[0];
            A25MvAFec = P00EW5_A25MvAFec[0];
            A28ProdCod = P00EW5_A28ProdCod[0];
            A14MvACod = P00EW5_A14MvACod[0];
            A13MvATip = P00EW5_A13MvATip[0];
            A19MVCDesItem = P00EW5_A19MVCDesItem[0];
            n19MVCDesItem = P00EW5_n19MVCDesItem[0];
            A30MvADItem = P00EW5_A30MvADItem[0];
            A52LinCod = P00EW5_A52LinCod[0];
            A1158LinStk = P00EW5_A1158LinStk[0];
            A21MvAlm = P00EW5_A21MvAlm[0];
            A1370MVSts = P00EW5_A1370MVSts[0];
            A25MvAFec = P00EW5_A25MvAFec[0];
            A19MVCDesItem = P00EW5_A19MVCDesItem[0];
            n19MVCDesItem = P00EW5_n19MVCDesItem[0];
            A1269MvAlmCos = P00EW5_A1269MvAlmCos[0];
            AV26Flag = 0;
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S121( )
      {
         /* 'DETALLEMOVIMIENTOS' Routine */
         returnInSub = false;
         /* Using cursor P00EW6 */
         pr_default.execute(4, new Object[] {AV76FDesde, AV36ProdCodC, AV77FHasta});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A22MvAMov = P00EW6_A22MvAMov[0];
            A21MvAlm = P00EW6_A21MvAlm[0];
            A52LinCod = P00EW6_A52LinCod[0];
            A1158LinStk = P00EW6_A1158LinStk[0];
            A1269MvAlmCos = P00EW6_A1269MvAlmCos[0];
            A1370MVSts = P00EW6_A1370MVSts[0];
            A25MvAFec = P00EW6_A25MvAFec[0];
            A28ProdCod = P00EW6_A28ProdCod[0];
            A1278MvARef = P00EW6_A1278MvARef[0];
            A1276MvAOcom = P00EW6_A1276MvAOcom[0];
            A24DocNum = P00EW6_A24DocNum[0];
            n24DocNum = P00EW6_n24DocNum[0];
            A1248MvADCant = P00EW6_A1248MvADCant[0];
            A1237MovAbr = P00EW6_A1237MovAbr[0];
            n1237MovAbr = P00EW6_n1237MovAbr[0];
            A1286MvATMov = P00EW6_A1286MvATMov[0];
            A1250MVADPrecio = P00EW6_A1250MVADPrecio[0];
            A1249MVADCosto = P00EW6_A1249MVADCosto[0];
            A14MvACod = P00EW6_A14MvACod[0];
            A13MvATip = P00EW6_A13MvATip[0];
            A19MVCDesItem = P00EW6_A19MVCDesItem[0];
            n19MVCDesItem = P00EW6_n19MVCDesItem[0];
            A30MvADItem = P00EW6_A30MvADItem[0];
            A52LinCod = P00EW6_A52LinCod[0];
            A1158LinStk = P00EW6_A1158LinStk[0];
            A22MvAMov = P00EW6_A22MvAMov[0];
            A21MvAlm = P00EW6_A21MvAlm[0];
            A1370MVSts = P00EW6_A1370MVSts[0];
            A25MvAFec = P00EW6_A25MvAFec[0];
            A1278MvARef = P00EW6_A1278MvARef[0];
            A1276MvAOcom = P00EW6_A1276MvAOcom[0];
            A24DocNum = P00EW6_A24DocNum[0];
            n24DocNum = P00EW6_n24DocNum[0];
            A1286MvATMov = P00EW6_A1286MvATMov[0];
            A19MVCDesItem = P00EW6_A19MVCDesItem[0];
            n19MVCDesItem = P00EW6_n19MVCDesItem[0];
            A1237MovAbr = P00EW6_A1237MovAbr[0];
            n1237MovAbr = P00EW6_n1237MovAbr[0];
            A1269MvAlmCos = P00EW6_A1269MvAlmCos[0];
            AV34MVATip = ((StringUtil.StrCmp(A13MvATip, "REM")==0) ? "09" : "00");
            AV35MVACod = A14MvACod;
            AV47DocRef = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? (String.IsNullOrEmpty(StringUtil.RTrim( A1276MvAOcom)) ? A1278MvARef : A1276MvAOcom) : A24DocNum);
            AV88Serie = StringUtil.Substring( A14MvACod, 1, 3);
            AV50DocNum = StringUtil.Substring( A14MvACod, 4, 7);
            AV18Ingresa = ((StringUtil.StrCmp(A13MvATip, "ING")==0) ? NumberUtil.Round( A1248MvADCant, 4) : (decimal)(0));
            AV19Salida = ((StringUtil.StrCmp(A13MvATip, "ING")!=0) ? NumberUtil.Round( A1248MvADCant, 4) : (decimal)(0));
            AV27CostoU = 0;
            AV28CostoT = 0;
            AV67MovAbr = A1237MovAbr;
            AV80MvATMov = A1286MvATMov;
            AV54Ing1 = 0;
            AV55IngCU = 0;
            AV53IngCT = 0;
            AV56Sal1 = 0;
            AV57SalCU = 0;
            AV58SalCT = 0;
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
            HEW0( false, 16) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 33, Gx_line+2, 72, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50DocNum, "")), 241, Gx_line+2, 292, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34MVATip, "")), 107, Gx_line+2, 133, Gx_line+15, 1+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67MovAbr, "")), 304, Gx_line+1, 357, Gx_line+16, 1+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54Ing1, "ZZZZ,ZZZ,ZZ9.9999")), 345, Gx_line+2, 435, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55IngCU, "ZZZZ,ZZZ,ZZ9.9999")), 423, Gx_line+2, 513, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53IngCT, "ZZZZZZ,ZZZ,ZZ9.99")), 502, Gx_line+2, 592, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57SalCU, "ZZZZ,ZZZ,ZZ9.9999")), 666, Gx_line+2, 756, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58SalCT, "ZZZZZZ,ZZZ,ZZ9.99")), 746, Gx_line+2, 836, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56Sal1, "ZZZZ,ZZZ,ZZ9.9999")), 588, Gx_line+2, 678, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27CostoU, "ZZZZ,ZZZ,ZZ9.9999")), 906, Gx_line+2, 996, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 827, Gx_line+2, 917, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28CostoT, "ZZZZZZ,ZZZ,ZZ9.99")), 989, Gx_line+2, 1079, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV88Serie, "")), 168, Gx_line+1, 200, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+16);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S138( )
      {
         /* 'VALIDADOC' Routine */
         returnInSub = false;
         /* Using cursor P00EW7 */
         pr_default.execute(5, new Object[] {AV36ProdCodC, AV51OC});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A254ComDProCod = P00EW7_A254ComDProCod[0];
            n254ComDProCod = P00EW7_n254ComDProCod[0];
            A251ComDOrdCod = P00EW7_A251ComDOrdCod[0];
            A243ComCod = P00EW7_A243ComCod[0];
            A149TipCod = P00EW7_A149TipCod[0];
            A244PrvCod = P00EW7_A244PrvCod[0];
            A250ComDItem = P00EW7_A250ComDItem[0];
            AV50DocNum = A243ComCod;
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void HEW0( bool bFoot ,
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
               getPrinter().GxDrawText("Página:", 978, Gx_line+14, 1022, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1033, Gx_line+14, 1072, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82Periodo, "")), 96, Gx_line+38, 618, Gx_line+53, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Empresa, "")), 180, Gx_line+67, 585, Gx_line+84, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41EmpRUC, "")), 96, Gx_line+52, 201, Gx_line+67, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PERIODO:", 22, Gx_line+38, 78, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RUC :", 22, Gx_line+52, 53, Gx_line+66, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(18, Gx_line+121, 1087, Gx_line+172, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo", 107, Gx_line+155, 131, Gx_line+168, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 34, Gx_line+155, 65, Gx_line+168, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 379, Gx_line+156, 426, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Serie", 173, Gx_line+155, 201, Gx_line+168, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Número", 242, Gx_line+155, 284, Gx_line+168, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(601, Gx_line+121, 601, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 455, Gx_line+156, 499, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 534, Gx_line+156, 578, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 619, Gx_line+156, 666, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 704, Gx_line+156, 748, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 779, Gx_line+156, 823, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 864, Gx_line+156, 911, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 952, Gx_line+156, 996, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 1029, Gx_line+156, 1073, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(842, Gx_line+121, 842, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("ENTRADAS", 449, Gx_line+130, 508, Gx_line+143, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("SALIDAS", 697, Gx_line+130, 746, Gx_line+143, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("SALDO FINAL", 933, Gx_line+130, 1007, Gx_line+143, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(297, Gx_line+122, 297, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(84, Gx_line+149, 84, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(154, Gx_line+149, 154, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(18, Gx_line+149, 298, Gx_line+149, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(217, Gx_line+150, 217, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(363, Gx_line+122, 363, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de", 310, Gx_line+133, 350, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Operación", 303, Gx_line+147, 357, Gx_line+160, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DOCUMENTO DE TRASLADO, COMPROBANTE ", 35, Gx_line+125, 278, Gx_line+138, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DE PAGO, DOCUMENTO INTERNO O SIMILAR", 36, Gx_line+135, 275, Gx_line+148, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12Titulo, "")), 22, Gx_line+6, 336, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(364, Gx_line+149, 1087, Gx_line+149, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("ESTABLECIMIENTO(1) : ", 22, Gx_line+85, 156, Gx_line+99, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40EmpDir, "")), 180, Gx_line+84, 585, Gx_line+101, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("METODO DE VALUACIÓN :", 22, Gx_line+103, 166, Gx_line+117, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV89Metodo, "")), 180, Gx_line+102, 329, Gx_line+119, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("ALMACEN :", 370, Gx_line+103, 431, Gx_line+117, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11Almacen, "")), 460, Gx_line+102, 763, Gx_line+119, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("RAZON SOCIAL :", 22, Gx_line+69, 115, Gx_line+83, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+172);
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
         AV93Logo_GXI = "";
         AV85FechaC = "";
         AV86FechaD = DateTime.MinValue;
         AV21cMes = "";
         GXt_char1 = "";
         AV87Tipo = "";
         AV12Titulo = "";
         AV82Periodo = "";
         AV89Metodo = "";
         AV11Almacen = "";
         AV22Filtro1 = "";
         AV24Filtro2 = "";
         scmdbuf = "";
         P00EW2_A52LinCod = new int[1] ;
         P00EW2_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P00EW3_A28ProdCod = new string[] {""} ;
         P00EW3_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P00EW4_A13MvATip = new string[] {""} ;
         P00EW4_A14MvACod = new string[] {""} ;
         P00EW4_A21MvAlm = new int[1] ;
         P00EW4_A49UniCod = new int[1] ;
         P00EW4_A55ProdDsc = new string[] {""} ;
         P00EW4_A28ProdCod = new string[] {""} ;
         P00EW4_A1269MvAlmCos = new short[1] ;
         P00EW4_A1158LinStk = new short[1] ;
         P00EW4_A50FamCod = new int[1] ;
         P00EW4_n50FamCod = new bool[] {false} ;
         P00EW4_A51SublCod = new int[1] ;
         P00EW4_n51SublCod = new bool[] {false} ;
         P00EW4_A52LinCod = new int[1] ;
         P00EW4_A2000UniSunat = new string[] {""} ;
         P00EW4_A1160LinSunat = new string[] {""} ;
         P00EW4_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A2000UniSunat = "";
         A1160LinSunat = "";
         AV36ProdCodC = "";
         AV15Producto = "";
         AV65UniAbr = "";
         AV90LinSunat = "";
         P00EW5_A21MvAlm = new int[1] ;
         P00EW5_A52LinCod = new int[1] ;
         P00EW5_A1158LinStk = new short[1] ;
         P00EW5_A1269MvAlmCos = new short[1] ;
         P00EW5_A1370MVSts = new string[] {""} ;
         P00EW5_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00EW5_A28ProdCod = new string[] {""} ;
         P00EW5_A14MvACod = new string[] {""} ;
         P00EW5_A13MvATip = new string[] {""} ;
         P00EW5_A19MVCDesItem = new int[1] ;
         P00EW5_n19MVCDesItem = new bool[] {false} ;
         P00EW5_A30MvADItem = new int[1] ;
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         P00EW6_A22MvAMov = new int[1] ;
         P00EW6_A21MvAlm = new int[1] ;
         P00EW6_A52LinCod = new int[1] ;
         P00EW6_A1158LinStk = new short[1] ;
         P00EW6_A1269MvAlmCos = new short[1] ;
         P00EW6_A1370MVSts = new string[] {""} ;
         P00EW6_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00EW6_A28ProdCod = new string[] {""} ;
         P00EW6_A1278MvARef = new string[] {""} ;
         P00EW6_A1276MvAOcom = new string[] {""} ;
         P00EW6_A24DocNum = new string[] {""} ;
         P00EW6_n24DocNum = new bool[] {false} ;
         P00EW6_A1248MvADCant = new decimal[1] ;
         P00EW6_A1237MovAbr = new string[] {""} ;
         P00EW6_n1237MovAbr = new bool[] {false} ;
         P00EW6_A1286MvATMov = new short[1] ;
         P00EW6_A1250MVADPrecio = new decimal[1] ;
         P00EW6_A1249MVADCosto = new decimal[1] ;
         P00EW6_A14MvACod = new string[] {""} ;
         P00EW6_A13MvATip = new string[] {""} ;
         P00EW6_A19MVCDesItem = new int[1] ;
         P00EW6_n19MVCDesItem = new bool[] {false} ;
         P00EW6_A30MvADItem = new int[1] ;
         A1278MvARef = "";
         A1276MvAOcom = "";
         A24DocNum = "";
         A1237MovAbr = "";
         AV34MVATip = "";
         AV35MVACod = "";
         AV47DocRef = "";
         AV88Serie = "";
         AV50DocNum = "";
         AV67MovAbr = "";
         AV51OC = "";
         P00EW7_A254ComDProCod = new string[] {""} ;
         P00EW7_n254ComDProCod = new bool[] {false} ;
         P00EW7_A251ComDOrdCod = new string[] {""} ;
         P00EW7_A243ComCod = new string[] {""} ;
         P00EW7_A149TipCod = new string[] {""} ;
         P00EW7_A244PrvCod = new string[] {""} ;
         P00EW7_A250ComDItem = new short[1] ;
         A254ComDProCod = "";
         A251ComDOrdCod = "";
         A243ComCod = "";
         A149TipCod = "";
         A244PrvCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_registroinventariovalorizadohpdf__default(),
            new Object[][] {
                new Object[] {
               P00EW2_A52LinCod, P00EW2_A1153LinDsc
               }
               , new Object[] {
               P00EW3_A28ProdCod, P00EW3_A55ProdDsc
               }
               , new Object[] {
               P00EW4_A13MvATip, P00EW4_A14MvACod, P00EW4_A21MvAlm, P00EW4_A49UniCod, P00EW4_A55ProdDsc, P00EW4_A28ProdCod, P00EW4_A1269MvAlmCos, P00EW4_A1158LinStk, P00EW4_A50FamCod, P00EW4_n50FamCod,
               P00EW4_A51SublCod, P00EW4_n51SublCod, P00EW4_A52LinCod, P00EW4_A2000UniSunat, P00EW4_A1160LinSunat, P00EW4_A30MvADItem
               }
               , new Object[] {
               P00EW5_A21MvAlm, P00EW5_A52LinCod, P00EW5_A1158LinStk, P00EW5_A1269MvAlmCos, P00EW5_A1370MVSts, P00EW5_A25MvAFec, P00EW5_A28ProdCod, P00EW5_A14MvACod, P00EW5_A13MvATip, P00EW5_A19MVCDesItem,
               P00EW5_n19MVCDesItem, P00EW5_A30MvADItem
               }
               , new Object[] {
               P00EW6_A22MvAMov, P00EW6_A21MvAlm, P00EW6_A52LinCod, P00EW6_A1158LinStk, P00EW6_A1269MvAlmCos, P00EW6_A1370MVSts, P00EW6_A25MvAFec, P00EW6_A28ProdCod, P00EW6_A1278MvARef, P00EW6_A1276MvAOcom,
               P00EW6_A24DocNum, P00EW6_n24DocNum, P00EW6_A1248MvADCant, P00EW6_A1237MovAbr, P00EW6_n1237MovAbr, P00EW6_A1286MvATMov, P00EW6_A1250MVADPrecio, P00EW6_A1249MVADCosto, P00EW6_A14MvACod, P00EW6_A13MvATip,
               P00EW6_A19MVCDesItem, P00EW6_n19MVCDesItem, P00EW6_A30MvADItem
               }
               , new Object[] {
               P00EW7_A254ComDProCod, P00EW7_n254ComDProCod, P00EW7_A251ComDOrdCod, P00EW7_A243ComCod, P00EW7_A149TipCod, P00EW7_A244PrvCod, P00EW7_A250ComDItem
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV83Ano ;
      private short AV84Mes ;
      private short A1158LinStk ;
      private short A1269MvAlmCos ;
      private short AV26Flag ;
      private short A1286MvATMov ;
      private short AV80MvATMov ;
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
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV10Prodcod ;
      private string AV39Empresa ;
      private string AV40EmpDir ;
      private string AV41EmpRUC ;
      private string AV42Ruta ;
      private string AV85FechaC ;
      private string AV21cMes ;
      private string GXt_char1 ;
      private string AV87Tipo ;
      private string AV12Titulo ;
      private string AV82Periodo ;
      private string AV89Metodo ;
      private string AV11Almacen ;
      private string AV22Filtro1 ;
      private string AV24Filtro2 ;
      private string scmdbuf ;
      private string A1153LinDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string AV36ProdCodC ;
      private string AV15Producto ;
      private string AV65UniAbr ;
      private string A1370MVSts ;
      private string A1278MvARef ;
      private string A1276MvAOcom ;
      private string A24DocNum ;
      private string A1237MovAbr ;
      private string AV34MVATip ;
      private string AV35MVACod ;
      private string AV47DocRef ;
      private string AV88Serie ;
      private string AV50DocNum ;
      private string AV67MovAbr ;
      private string AV51OC ;
      private string A254ComDProCod ;
      private string A251ComDOrdCod ;
      private string A243ComCod ;
      private string A149TipCod ;
      private string A244PrvCod ;
      private DateTime AV76FDesde ;
      private DateTime AV77FHasta ;
      private DateTime AV86FechaD ;
      private DateTime A25MvAFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKEW5 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private bool n19MVCDesItem ;
      private bool n24DocNum ;
      private bool n1237MovAbr ;
      private bool n254ComDProCod ;
      private string AV93Logo_GXI ;
      private string A2000UniSunat ;
      private string A1160LinSunat ;
      private string AV90LinSunat ;
      private string AV43Logo ;
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
      private int[] P00EW2_A52LinCod ;
      private string[] P00EW2_A1153LinDsc ;
      private string[] P00EW3_A28ProdCod ;
      private string[] P00EW3_A55ProdDsc ;
      private string[] P00EW4_A13MvATip ;
      private string[] P00EW4_A14MvACod ;
      private int[] P00EW4_A21MvAlm ;
      private int[] P00EW4_A49UniCod ;
      private string[] P00EW4_A55ProdDsc ;
      private string[] P00EW4_A28ProdCod ;
      private short[] P00EW4_A1269MvAlmCos ;
      private short[] P00EW4_A1158LinStk ;
      private int[] P00EW4_A50FamCod ;
      private bool[] P00EW4_n50FamCod ;
      private int[] P00EW4_A51SublCod ;
      private bool[] P00EW4_n51SublCod ;
      private int[] P00EW4_A52LinCod ;
      private string[] P00EW4_A2000UniSunat ;
      private string[] P00EW4_A1160LinSunat ;
      private int[] P00EW4_A30MvADItem ;
      private int[] P00EW5_A21MvAlm ;
      private int[] P00EW5_A52LinCod ;
      private short[] P00EW5_A1158LinStk ;
      private short[] P00EW5_A1269MvAlmCos ;
      private string[] P00EW5_A1370MVSts ;
      private DateTime[] P00EW5_A25MvAFec ;
      private string[] P00EW5_A28ProdCod ;
      private string[] P00EW5_A14MvACod ;
      private string[] P00EW5_A13MvATip ;
      private int[] P00EW5_A19MVCDesItem ;
      private bool[] P00EW5_n19MVCDesItem ;
      private int[] P00EW5_A30MvADItem ;
      private int[] P00EW6_A22MvAMov ;
      private int[] P00EW6_A21MvAlm ;
      private int[] P00EW6_A52LinCod ;
      private short[] P00EW6_A1158LinStk ;
      private short[] P00EW6_A1269MvAlmCos ;
      private string[] P00EW6_A1370MVSts ;
      private DateTime[] P00EW6_A25MvAFec ;
      private string[] P00EW6_A28ProdCod ;
      private string[] P00EW6_A1278MvARef ;
      private string[] P00EW6_A1276MvAOcom ;
      private string[] P00EW6_A24DocNum ;
      private bool[] P00EW6_n24DocNum ;
      private decimal[] P00EW6_A1248MvADCant ;
      private string[] P00EW6_A1237MovAbr ;
      private bool[] P00EW6_n1237MovAbr ;
      private short[] P00EW6_A1286MvATMov ;
      private decimal[] P00EW6_A1250MVADPrecio ;
      private decimal[] P00EW6_A1249MVADCosto ;
      private string[] P00EW6_A14MvACod ;
      private string[] P00EW6_A13MvATip ;
      private int[] P00EW6_A19MVCDesItem ;
      private bool[] P00EW6_n19MVCDesItem ;
      private int[] P00EW6_A30MvADItem ;
      private string[] P00EW7_A254ComDProCod ;
      private bool[] P00EW7_n254ComDProCod ;
      private string[] P00EW7_A251ComDOrdCod ;
      private string[] P00EW7_A243ComCod ;
      private string[] P00EW7_A149TipCod ;
      private string[] P00EW7_A244PrvCod ;
      private short[] P00EW7_A250ComDItem ;
   }

   public class r_registroinventariovalorizadohpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EW4( IGxContext context ,
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
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T2.[MvAlm] AS MvAlm, T4.[UniCod], T4.[ProdDsc], T1.[ProdCod], T3.[AlmCos] AS MvAlmCos, T6.[LinStk], T4.[FamCod], T4.[SublCod], T4.[LinCod], T5.[UniSunat], T6.[LinSunat], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T5 ON T5.[UniCod] = T4.[UniCod]) INNER JOIN [CLINEAPROD] T6 ON T6.[LinCod] = T4.[LinCod])";
         AddWhere(sWhereString, "(T6.[LinStk] = 1)");
         AddWhere(sWhereString, "(T3.[AlmCos] = 1)");
         if ( ! (0==AV8LinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV8LinCod)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (0==AV45SublCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV45SublCod)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV46FamCod) )
         {
            AddWhere(sWhereString, "(T4.[FamCod] = @AV46FamCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV10Prodcod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T4.[ProdDsc]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P00EW4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] );
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
          Object[] prmP00EW2;
          prmP00EW2 = new Object[] {
          new ParDef("@AV8LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00EW3;
          prmP00EW3 = new Object[] {
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00EW5;
          prmP00EW5 = new Object[] {
          new ParDef("@AV76FDesde",GXType.Date,8,0) ,
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV77FHasta",GXType.Date,8,0)
          };
          Object[] prmP00EW6;
          prmP00EW6 = new Object[] {
          new ParDef("@AV76FDesde",GXType.Date,8,0) ,
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV77FHasta",GXType.Date,8,0)
          };
          Object[] prmP00EW7;
          prmP00EW7 = new Object[] {
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV51OC",GXType.NChar,10,0)
          };
          Object[] prmP00EW4;
          prmP00EW4 = new Object[] {
          new ParDef("@AV8LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV45SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV46FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EW2", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV8LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EW2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EW3", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV10Prodcod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EW3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EW4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EW4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EW5", "SELECT T4.[MvAlm] AS MvAlm, T2.[LinCod], T3.[LinStk], T5.[AlmCos] AS MvAlmCos, T4.[MVSts], T4.[MvAFec], T1.[ProdCod], T1.[MvACod], T1.[MvATip], T4.[MVCDesItem], T1.[MvADItem] FROM (((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [AGUIAS] T4 ON T4.[MvATip] = T1.[MvATip] AND T4.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T5 ON T5.[AlmCod] = T4.[MvAlm]) WHERE (T4.[MvAFec] >= @AV76FDesde) AND (T1.[ProdCod] = RTRIM(LTRIM(@AV36ProdCodC))) AND (T4.[MVSts] <> 'A') AND (T3.[LinStk] = 1) AND (T5.[AlmCos] = 1) AND (T4.[MvAFec] <= @AV77FHasta) ORDER BY T4.[MvAFec], T4.[MVCDesItem], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EW5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EW6", "SELECT T4.[MvAMov] AS MvAMov, T4.[MvAlm] AS MvAlm, T2.[LinCod], T3.[LinStk], T6.[AlmCos] AS MvAlmCos, T4.[MVSts], T4.[MvAFec], T1.[ProdCod], T4.[MvARef], T4.[MvAOcom], T4.[DocNum], T1.[MvADCant], T5.[MovAbr], T4.[MvATMov], T1.[MVADPrecio], T1.[MVADCosto], T1.[MvACod], T1.[MvATip], T4.[MVCDesItem], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [AGUIAS] T4 ON T4.[MvATip] = T1.[MvATip] AND T4.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T5 ON T5.[MovCod] = T4.[MvAMov]) INNER JOIN [CALMACEN] T6 ON T6.[AlmCod] = T4.[MvAlm]) WHERE (T4.[MvAFec] >= @AV76FDesde) AND (T1.[ProdCod] = RTRIM(LTRIM(@AV36ProdCodC))) AND (T4.[MVSts] <> 'A') AND (T3.[LinStk] = 1) AND (T6.[AlmCos] = 1) AND (T4.[MvAFec] <= @AV77FHasta) ORDER BY T4.[MvAFec], T4.[MVCDesItem], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EW6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EW7", "SELECT [ComDProCod], [ComDOrdCod], [ComCod], [TipCod], [PrvCod], [ComDItem] FROM [CPCOMPRASDET] WHERE ([ComDProCod] = @AV36ProdCodC) AND ([ComDOrdCod] = @AV51OC) ORDER BY [ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EW7,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((string[]) buf[14])[0] = rslt.getVarchar(13);
                ((int[]) buf[15])[0] = rslt.getInt(14);
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
                ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(16);
                ((string[]) buf[18])[0] = rslt.getString(17, 12);
                ((string[]) buf[19])[0] = rslt.getString(18, 3);
                ((int[]) buf[20])[0] = rslt.getInt(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((int[]) buf[22])[0] = rslt.getInt(20);
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
       }
    }

 }

}
