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
   public class r_registroinventariopermanenteunidadespdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_registroinventariopermanenteunidadespdf.aspx")), "contabilidad.r_registroinventariopermanenteunidadespdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_registroinventariopermanenteunidadespdf.aspx")))) ;
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

      public r_registroinventariopermanenteunidadespdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_registroinventariopermanenteunidadespdf( IGxContext context )
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
         this.AV8LinCod = aP0_LinCod;
         this.AV45SublCod = aP1_SublCod;
         this.AV46FamCod = aP2_FamCod;
         this.AV9AlmCod = aP3_AlmCod;
         this.AV10Prodcod = aP4_Prodcod;
         this.AV76FDesde = aP5_FDesde;
         this.AV77FHasta = aP6_FHasta;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV8LinCod;
         aP1_SublCod=this.AV45SublCod;
         aP2_FamCod=this.AV46FamCod;
         aP3_AlmCod=this.AV9AlmCod;
         aP4_Prodcod=this.AV10Prodcod;
         aP5_FDesde=this.AV76FDesde;
         aP6_FHasta=this.AV77FHasta;
      }

      public DateTime executeUdp( ref int aP0_LinCod ,
                                  ref int aP1_SublCod ,
                                  ref int aP2_FamCod ,
                                  ref int aP3_AlmCod ,
                                  ref string aP4_Prodcod ,
                                  ref DateTime aP5_FDesde )
      {
         execute(ref aP0_LinCod, ref aP1_SublCod, ref aP2_FamCod, ref aP3_AlmCod, ref aP4_Prodcod, ref aP5_FDesde, ref aP6_FHasta);
         return AV77FHasta ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SublCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_AlmCod ,
                                 ref string aP4_Prodcod ,
                                 ref DateTime aP5_FDesde ,
                                 ref DateTime aP6_FHasta )
      {
         r_registroinventariopermanenteunidadespdf objr_registroinventariopermanenteunidadespdf;
         objr_registroinventariopermanenteunidadespdf = new r_registroinventariopermanenteunidadespdf();
         objr_registroinventariopermanenteunidadespdf.AV8LinCod = aP0_LinCod;
         objr_registroinventariopermanenteunidadespdf.AV45SublCod = aP1_SublCod;
         objr_registroinventariopermanenteunidadespdf.AV46FamCod = aP2_FamCod;
         objr_registroinventariopermanenteunidadespdf.AV9AlmCod = aP3_AlmCod;
         objr_registroinventariopermanenteunidadespdf.AV10Prodcod = aP4_Prodcod;
         objr_registroinventariopermanenteunidadespdf.AV76FDesde = aP5_FDesde;
         objr_registroinventariopermanenteunidadespdf.AV77FHasta = aP6_FHasta;
         objr_registroinventariopermanenteunidadespdf.context.SetSubmitInitialConfig(context);
         objr_registroinventariopermanenteunidadespdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_registroinventariopermanenteunidadespdf);
         aP0_LinCod=this.AV8LinCod;
         aP1_SublCod=this.AV45SublCod;
         aP2_FamCod=this.AV46FamCod;
         aP3_AlmCod=this.AV9AlmCod;
         aP4_Prodcod=this.AV10Prodcod;
         aP5_FDesde=this.AV76FDesde;
         aP6_FHasta=this.AV77FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_registroinventariopermanenteunidadespdf)stateInfo).executePrivate();
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
            AV93Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV83Ano = (short)(DateTimeUtil.Year( AV76FDesde));
            AV84Mes = (short)(DateTimeUtil.Month( AV76FDesde));
            AV85FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV84Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV83Ano), 10, 0));
            AV86FechaD = context.localUtil.CToD( AV85FechaC, 2);
            GXt_char1 = AV21cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV84Mes, out  GXt_char1) ;
            AV21cMes = GXt_char1;
            AV87Tipo = "16";
            AV12Titulo = "FORMATO 12.1: REGISTRO DE INVENTARIO PERMANENTE EN UNIDADES F?SICAS - DETALLE DE INVENTARIO PERMANENTE EN UNIDADES F?SICAS";
            AV82Periodo = StringUtil.Upper( AV21cMes) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV83Ano), 10, 0));
            AV89Metodo = "PROMEDIO";
            /* Using cursor P00C22 */
            pr_default.execute(0, new Object[] {AV9AlmCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A63AlmCod = P00C22_A63AlmCod[0];
               A436AlmDsc = P00C22_A436AlmDsc[0];
               A435AlmDir = P00C22_A435AlmDir[0];
               AV11Almacen = A436AlmDsc;
               AV40EmpDir = StringUtil.Trim( A435AlmDir);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV22Filtro1 = "";
            AV24Filtro2 = "";
            /* Using cursor P00C23 */
            pr_default.execute(1, new Object[] {AV8LinCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A52LinCod = P00C23_A52LinCod[0];
               A1153LinDsc = P00C23_A1153LinDsc[0];
               AV22Filtro1 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00C24 */
            pr_default.execute(2, new Object[] {AV10Prodcod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A28ProdCod = P00C24_A28ProdCod[0];
               A55ProdDsc = P00C24_A55ProdDsc[0];
               AV24Filtro2 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            AV49CostoTotal = 0;
            AV81TCantidad = 0;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV8LinCod ,
                                                 AV45SublCod ,
                                                 AV46FamCod ,
                                                 AV10Prodcod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A28ProdCod ,
                                                 A21MvAlm ,
                                                 AV9AlmCod ,
                                                 A1158LinStk } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00C25 */
            pr_default.execute(3, new Object[] {AV9AlmCod, AV8LinCod, AV45SublCod, AV46FamCod, AV10Prodcod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               BRKC26 = false;
               A13MvATip = P00C25_A13MvATip[0];
               A14MvACod = P00C25_A14MvACod[0];
               A49UniCod = P00C25_A49UniCod[0];
               A55ProdDsc = P00C25_A55ProdDsc[0];
               A28ProdCod = P00C25_A28ProdCod[0];
               A1158LinStk = P00C25_A1158LinStk[0];
               A21MvAlm = P00C25_A21MvAlm[0];
               A50FamCod = P00C25_A50FamCod[0];
               n50FamCod = P00C25_n50FamCod[0];
               A51SublCod = P00C25_A51SublCod[0];
               n51SublCod = P00C25_n51SublCod[0];
               A52LinCod = P00C25_A52LinCod[0];
               A2000UniSunat = P00C25_A2000UniSunat[0];
               A1160LinSunat = P00C25_A1160LinSunat[0];
               A30MvADItem = P00C25_A30MvADItem[0];
               A21MvAlm = P00C25_A21MvAlm[0];
               A49UniCod = P00C25_A49UniCod[0];
               A55ProdDsc = P00C25_A55ProdDsc[0];
               A50FamCod = P00C25_A50FamCod[0];
               n50FamCod = P00C25_n50FamCod[0];
               A51SublCod = P00C25_A51SublCod[0];
               n51SublCod = P00C25_n51SublCod[0];
               A52LinCod = P00C25_A52LinCod[0];
               A2000UniSunat = P00C25_A2000UniSunat[0];
               A1158LinStk = P00C25_A1158LinStk[0];
               A1160LinSunat = P00C25_A1160LinSunat[0];
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00C25_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRKC26 = false;
                  A13MvATip = P00C25_A13MvATip[0];
                  A14MvACod = P00C25_A14MvACod[0];
                  A55ProdDsc = P00C25_A55ProdDsc[0];
                  A30MvADItem = P00C25_A30MvADItem[0];
                  A55ProdDsc = P00C25_A55ProdDsc[0];
                  BRKC26 = true;
                  pr_default.readNext(3);
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
               new GeneXus.Programs.contabilidad.paobtenersaldocostoproductofechas(context ).execute( ref  AV76FDesde, ref  AV9AlmCod, ref  AV36ProdCodC, out  AV16Saldo, out  AV27CostoU) ;
               AV28CostoT = NumberUtil.Round( AV16Saldo*AV27CostoU, 2);
               AV31TCosto = AV28CostoT;
               AV17Final = AV16Saldo;
               /* Execute user subroutine: 'VALIDA' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  this.cleanup();
                  if (true) return;
               }
               if ( ( AV26Flag == 0 ) || ( AV16Saldo != Convert.ToDecimal( 0 )) )
               {
                  HC20( false, 22) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Producto : ", 6, Gx_line+5, 63, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Producto, "")), 70, Gx_line+5, 418, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65UniAbr, "")), 731, Gx_line+5, 774, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Tipo de Existencia :", 425, Gx_line+5, 526, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Codigo Unidad Medida : ", 595, Gx_line+5, 720, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV90LinSunat, "")), 540, Gx_line+5, 583, Gx_line+18, 0+256, 0, 0, 0) ;
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
                  HC20( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70CanIni, "ZZZZ,ZZZ,ZZ9.9999")), 386, Gx_line+3, 458, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56Sal1, "ZZZZ,ZZZ,ZZ9.9999")), 534, Gx_line+3, 606, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 679, Gx_line+3, 751, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV76FDesde, "99/99/99"), 15, Gx_line+3, 47, Gx_line+14, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV87Tipo, "")), 296, Gx_line+3, 333, Gx_line+14, 1+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
               }
               /* Execute user subroutine: 'DETALLEMOVIMIENTOS' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
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
                  HC20( false, 34) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Producto, "")), 6, Gx_line+8, 348, Gx_line+26, 2, 0, 0, 0) ;
                  getPrinter().GxDrawLine(257, Gx_line+5, 785, Gx_line+5, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 679, Gx_line+13, 751, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV73TTIngreso, "ZZZZ,ZZZ,ZZ9.9999")), 386, Gx_line+13, 458, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV74TTSalida, "ZZZZ,ZZZ,ZZ9.9999")), 534, Gx_line+13, 606, Gx_line+24, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+34);
               }
               AV49CostoTotal = (decimal)(AV49CostoTotal+AV28CostoT);
               AV81TCantidad = (decimal)(AV81TCantidad+AV17Final);
               if ( ! BRKC26 )
               {
                  BRKC26 = true;
                  pr_default.readNext(3);
               }
            }
            pr_default.close(3);
            HC20( false, 55) ;
            getPrinter().GxDrawLine(599, Gx_line+13, 785, Gx_line+13, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Totales", 458, Gx_line+22, 503, Gx_line+36, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV81TCantidad, "ZZZZ,ZZZ,ZZ9.9999")), 644, Gx_line+22, 751, Gx_line+37, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+55);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HC20( true, 0) ;
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
         /* Using cursor P00C26 */
         pr_default.execute(4, new Object[] {AV76FDesde, AV36ProdCodC, AV9AlmCod, AV77FHasta});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A21MvAlm = P00C26_A21MvAlm[0];
            A1370MVSts = P00C26_A1370MVSts[0];
            A25MvAFec = P00C26_A25MvAFec[0];
            A28ProdCod = P00C26_A28ProdCod[0];
            A14MvACod = P00C26_A14MvACod[0];
            A13MvATip = P00C26_A13MvATip[0];
            A19MVCDesItem = P00C26_A19MVCDesItem[0];
            n19MVCDesItem = P00C26_n19MVCDesItem[0];
            A30MvADItem = P00C26_A30MvADItem[0];
            A21MvAlm = P00C26_A21MvAlm[0];
            A1370MVSts = P00C26_A1370MVSts[0];
            A25MvAFec = P00C26_A25MvAFec[0];
            A19MVCDesItem = P00C26_A19MVCDesItem[0];
            n19MVCDesItem = P00C26_n19MVCDesItem[0];
            AV26Flag = 0;
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S121( )
      {
         /* 'DETALLEMOVIMIENTOS' Routine */
         returnInSub = false;
         /* Using cursor P00C27 */
         pr_default.execute(5, new Object[] {AV76FDesde, AV36ProdCodC, AV9AlmCod, AV77FHasta});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A22MvAMov = P00C27_A22MvAMov[0];
            A21MvAlm = P00C27_A21MvAlm[0];
            A1370MVSts = P00C27_A1370MVSts[0];
            A25MvAFec = P00C27_A25MvAFec[0];
            A28ProdCod = P00C27_A28ProdCod[0];
            A1278MvARef = P00C27_A1278MvARef[0];
            A1276MvAOcom = P00C27_A1276MvAOcom[0];
            A24DocNum = P00C27_A24DocNum[0];
            n24DocNum = P00C27_n24DocNum[0];
            A1248MvADCant = P00C27_A1248MvADCant[0];
            A1237MovAbr = P00C27_A1237MovAbr[0];
            n1237MovAbr = P00C27_n1237MovAbr[0];
            A1286MvATMov = P00C27_A1286MvATMov[0];
            A1250MVADPrecio = P00C27_A1250MVADPrecio[0];
            A1249MVADCosto = P00C27_A1249MVADCosto[0];
            A14MvACod = P00C27_A14MvACod[0];
            A13MvATip = P00C27_A13MvATip[0];
            A19MVCDesItem = P00C27_A19MVCDesItem[0];
            n19MVCDesItem = P00C27_n19MVCDesItem[0];
            A30MvADItem = P00C27_A30MvADItem[0];
            A22MvAMov = P00C27_A22MvAMov[0];
            A21MvAlm = P00C27_A21MvAlm[0];
            A1370MVSts = P00C27_A1370MVSts[0];
            A25MvAFec = P00C27_A25MvAFec[0];
            A1278MvARef = P00C27_A1278MvARef[0];
            A1276MvAOcom = P00C27_A1276MvAOcom[0];
            A24DocNum = P00C27_A24DocNum[0];
            n24DocNum = P00C27_n24DocNum[0];
            A1286MvATMov = P00C27_A1286MvATMov[0];
            A19MVCDesItem = P00C27_A19MVCDesItem[0];
            n19MVCDesItem = P00C27_n19MVCDesItem[0];
            A1237MovAbr = P00C27_A1237MovAbr[0];
            n1237MovAbr = P00C27_n1237MovAbr[0];
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
                  S139 ();
                  if ( returnInSub )
                  {
                     pr_default.close(5);
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
            HC20( false, 16) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 14, Gx_line+3, 46, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50DocNum, "")), 199, Gx_line+3, 250, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34MVATip, "")), 85, Gx_line+3, 108, Gx_line+14, 1+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67MovAbr, "")), 296, Gx_line+3, 333, Gx_line+14, 1+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54Ing1, "ZZZZ,ZZZ,ZZ9.9999")), 386, Gx_line+3, 458, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56Sal1, "ZZZZ,ZZZ,ZZ9.9999")), 534, Gx_line+3, 606, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 679, Gx_line+3, 751, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV88Serie, "")), 144, Gx_line+1, 176, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+16);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S139( )
      {
         /* 'VALIDADOC' Routine */
         returnInSub = false;
         /* Using cursor P00C28 */
         pr_default.execute(6, new Object[] {AV36ProdCodC, AV51OC});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A254ComDProCod = P00C28_A254ComDProCod[0];
            n254ComDProCod = P00C28_n254ComDProCod[0];
            A251ComDOrdCod = P00C28_A251ComDOrdCod[0];
            A243ComCod = P00C28_A243ComCod[0];
            A149TipCod = P00C28_A149TipCod[0];
            A244PrvCod = P00C28_A244PrvCod[0];
            A250ComDItem = P00C28_A250ComDItem[0];
            AV50DocNum = A243ComCod;
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void HC20( bool bFoot ,
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
               getPrinter().GxDrawText("P?gina:", 693, Gx_line+31, 737, Gx_line+45, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 748, Gx_line+31, 787, Gx_line+46, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82Periodo, "")), 66, Gx_line+38, 588, Gx_line+53, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Empresa, "")), 4, Gx_line+67, 409, Gx_line+84, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41EmpRUC, "")), 66, Gx_line+52, 171, Gx_line+67, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PERIODO:", 4, Gx_line+38, 60, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RUC :", 4, Gx_line+52, 35, Gx_line+66, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+121, 788, Gx_line+172, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo", 80, Gx_line+155, 104, Gx_line+168, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 17, Gx_line+155, 48, Gx_line+168, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Serie", 139, Gx_line+155, 167, Gx_line+168, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N?mero", 203, Gx_line+155, 245, Gx_line+168, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(489, Gx_line+121, 489, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(632, Gx_line+121, 632, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("ENTRADAS", 394, Gx_line+145, 453, Gx_line+158, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("SALIDAS", 543, Gx_line+145, 592, Gx_line+158, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("SALDO FINAL", 673, Gx_line+145, 747, Gx_line+158, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(273, Gx_line+122, 273, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(68, Gx_line+149, 68, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(125, Gx_line+149, 125, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+149, 274, Gx_line+149, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(188, Gx_line+150, 188, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(349, Gx_line+122, 349, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de", 290, Gx_line+133, 330, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Operaci?n", 282, Gx_line+147, 336, Gx_line+160, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("DOCUMENTO DE TRASLADO, COMPROBANTE ", 49, Gx_line+125, 235, Gx_line+135, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DE PAGO, DOCUMENTO INTERNO O SIMILAR", 50, Gx_line+135, 236, Gx_line+145, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12Titulo, "")), 4, Gx_line+6, 318, Gx_line+21, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("ESTABLECIMIENTO(1) : ", 4, Gx_line+85, 138, Gx_line+99, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40EmpDir, "")), 150, Gx_line+84, 555, Gx_line+101, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("METODO DE VALUACI?N :", 4, Gx_line+103, 148, Gx_line+117, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV89Metodo, "")), 150, Gx_line+102, 299, Gx_line+119, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("ALMACEN :", 308, Gx_line+103, 369, Gx_line+117, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11Almacen, "")), 380, Gx_line+102, 683, Gx_line+119, 0, 0, 0, 0) ;
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
         scmdbuf = "";
         P00C22_A63AlmCod = new int[1] ;
         P00C22_A436AlmDsc = new string[] {""} ;
         P00C22_A435AlmDir = new string[] {""} ;
         A436AlmDsc = "";
         A435AlmDir = "";
         AV11Almacen = "";
         AV22Filtro1 = "";
         AV24Filtro2 = "";
         P00C23_A52LinCod = new int[1] ;
         P00C23_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P00C24_A28ProdCod = new string[] {""} ;
         P00C24_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P00C25_A13MvATip = new string[] {""} ;
         P00C25_A14MvACod = new string[] {""} ;
         P00C25_A49UniCod = new int[1] ;
         P00C25_A55ProdDsc = new string[] {""} ;
         P00C25_A28ProdCod = new string[] {""} ;
         P00C25_A1158LinStk = new short[1] ;
         P00C25_A21MvAlm = new int[1] ;
         P00C25_A50FamCod = new int[1] ;
         P00C25_n50FamCod = new bool[] {false} ;
         P00C25_A51SublCod = new int[1] ;
         P00C25_n51SublCod = new bool[] {false} ;
         P00C25_A52LinCod = new int[1] ;
         P00C25_A2000UniSunat = new string[] {""} ;
         P00C25_A1160LinSunat = new string[] {""} ;
         P00C25_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A2000UniSunat = "";
         A1160LinSunat = "";
         AV36ProdCodC = "";
         AV15Producto = "";
         AV65UniAbr = "";
         AV90LinSunat = "";
         P00C26_A21MvAlm = new int[1] ;
         P00C26_A1370MVSts = new string[] {""} ;
         P00C26_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00C26_A28ProdCod = new string[] {""} ;
         P00C26_A14MvACod = new string[] {""} ;
         P00C26_A13MvATip = new string[] {""} ;
         P00C26_A19MVCDesItem = new int[1] ;
         P00C26_n19MVCDesItem = new bool[] {false} ;
         P00C26_A30MvADItem = new int[1] ;
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         P00C27_A22MvAMov = new int[1] ;
         P00C27_A21MvAlm = new int[1] ;
         P00C27_A1370MVSts = new string[] {""} ;
         P00C27_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00C27_A28ProdCod = new string[] {""} ;
         P00C27_A1278MvARef = new string[] {""} ;
         P00C27_A1276MvAOcom = new string[] {""} ;
         P00C27_A24DocNum = new string[] {""} ;
         P00C27_n24DocNum = new bool[] {false} ;
         P00C27_A1248MvADCant = new decimal[1] ;
         P00C27_A1237MovAbr = new string[] {""} ;
         P00C27_n1237MovAbr = new bool[] {false} ;
         P00C27_A1286MvATMov = new short[1] ;
         P00C27_A1250MVADPrecio = new decimal[1] ;
         P00C27_A1249MVADCosto = new decimal[1] ;
         P00C27_A14MvACod = new string[] {""} ;
         P00C27_A13MvATip = new string[] {""} ;
         P00C27_A19MVCDesItem = new int[1] ;
         P00C27_n19MVCDesItem = new bool[] {false} ;
         P00C27_A30MvADItem = new int[1] ;
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
         P00C28_A254ComDProCod = new string[] {""} ;
         P00C28_n254ComDProCod = new bool[] {false} ;
         P00C28_A251ComDOrdCod = new string[] {""} ;
         P00C28_A243ComCod = new string[] {""} ;
         P00C28_A149TipCod = new string[] {""} ;
         P00C28_A244PrvCod = new string[] {""} ;
         P00C28_A250ComDItem = new short[1] ;
         A254ComDProCod = "";
         A251ComDOrdCod = "";
         A243ComCod = "";
         A149TipCod = "";
         A244PrvCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_registroinventariopermanenteunidadespdf__default(),
            new Object[][] {
                new Object[] {
               P00C22_A63AlmCod, P00C22_A436AlmDsc, P00C22_A435AlmDir
               }
               , new Object[] {
               P00C23_A52LinCod, P00C23_A1153LinDsc
               }
               , new Object[] {
               P00C24_A28ProdCod, P00C24_A55ProdDsc
               }
               , new Object[] {
               P00C25_A13MvATip, P00C25_A14MvACod, P00C25_A49UniCod, P00C25_A55ProdDsc, P00C25_A28ProdCod, P00C25_A1158LinStk, P00C25_A21MvAlm, P00C25_A50FamCod, P00C25_n50FamCod, P00C25_A51SublCod,
               P00C25_n51SublCod, P00C25_A52LinCod, P00C25_A2000UniSunat, P00C25_A1160LinSunat, P00C25_A30MvADItem
               }
               , new Object[] {
               P00C26_A21MvAlm, P00C26_A1370MVSts, P00C26_A25MvAFec, P00C26_A28ProdCod, P00C26_A14MvACod, P00C26_A13MvATip, P00C26_A19MVCDesItem, P00C26_n19MVCDesItem, P00C26_A30MvADItem
               }
               , new Object[] {
               P00C27_A22MvAMov, P00C27_A21MvAlm, P00C27_A1370MVSts, P00C27_A25MvAFec, P00C27_A28ProdCod, P00C27_A1278MvARef, P00C27_A1276MvAOcom, P00C27_A24DocNum, P00C27_n24DocNum, P00C27_A1248MvADCant,
               P00C27_A1237MovAbr, P00C27_n1237MovAbr, P00C27_A1286MvATMov, P00C27_A1250MVADPrecio, P00C27_A1249MVADCosto, P00C27_A14MvACod, P00C27_A13MvATip, P00C27_A19MVCDesItem, P00C27_n19MVCDesItem, P00C27_A30MvADItem
               }
               , new Object[] {
               P00C28_A254ComDProCod, P00C28_n254ComDProCod, P00C28_A251ComDOrdCod, P00C28_A243ComCod, P00C28_A149TipCod, P00C28_A244PrvCod, P00C28_A250ComDItem
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
      private short AV26Flag ;
      private short A1286MvATMov ;
      private short AV80MvATMov ;
      private short A250ComDItem ;
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
      private string scmdbuf ;
      private string A436AlmDsc ;
      private string AV11Almacen ;
      private string AV22Filtro1 ;
      private string AV24Filtro2 ;
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
      private bool BRKC26 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private bool n19MVCDesItem ;
      private bool n24DocNum ;
      private bool n1237MovAbr ;
      private bool n254ComDProCod ;
      private string AV93Logo_GXI ;
      private string A435AlmDir ;
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
      private int aP3_AlmCod ;
      private string aP4_Prodcod ;
      private DateTime aP5_FDesde ;
      private DateTime aP6_FHasta ;
      private IDataStoreProvider pr_default ;
      private int[] P00C22_A63AlmCod ;
      private string[] P00C22_A436AlmDsc ;
      private string[] P00C22_A435AlmDir ;
      private int[] P00C23_A52LinCod ;
      private string[] P00C23_A1153LinDsc ;
      private string[] P00C24_A28ProdCod ;
      private string[] P00C24_A55ProdDsc ;
      private string[] P00C25_A13MvATip ;
      private string[] P00C25_A14MvACod ;
      private int[] P00C25_A49UniCod ;
      private string[] P00C25_A55ProdDsc ;
      private string[] P00C25_A28ProdCod ;
      private short[] P00C25_A1158LinStk ;
      private int[] P00C25_A21MvAlm ;
      private int[] P00C25_A50FamCod ;
      private bool[] P00C25_n50FamCod ;
      private int[] P00C25_A51SublCod ;
      private bool[] P00C25_n51SublCod ;
      private int[] P00C25_A52LinCod ;
      private string[] P00C25_A2000UniSunat ;
      private string[] P00C25_A1160LinSunat ;
      private int[] P00C25_A30MvADItem ;
      private int[] P00C26_A21MvAlm ;
      private string[] P00C26_A1370MVSts ;
      private DateTime[] P00C26_A25MvAFec ;
      private string[] P00C26_A28ProdCod ;
      private string[] P00C26_A14MvACod ;
      private string[] P00C26_A13MvATip ;
      private int[] P00C26_A19MVCDesItem ;
      private bool[] P00C26_n19MVCDesItem ;
      private int[] P00C26_A30MvADItem ;
      private int[] P00C27_A22MvAMov ;
      private int[] P00C27_A21MvAlm ;
      private string[] P00C27_A1370MVSts ;
      private DateTime[] P00C27_A25MvAFec ;
      private string[] P00C27_A28ProdCod ;
      private string[] P00C27_A1278MvARef ;
      private string[] P00C27_A1276MvAOcom ;
      private string[] P00C27_A24DocNum ;
      private bool[] P00C27_n24DocNum ;
      private decimal[] P00C27_A1248MvADCant ;
      private string[] P00C27_A1237MovAbr ;
      private bool[] P00C27_n1237MovAbr ;
      private short[] P00C27_A1286MvATMov ;
      private decimal[] P00C27_A1250MVADPrecio ;
      private decimal[] P00C27_A1249MVADCosto ;
      private string[] P00C27_A14MvACod ;
      private string[] P00C27_A13MvATip ;
      private int[] P00C27_A19MVCDesItem ;
      private bool[] P00C27_n19MVCDesItem ;
      private int[] P00C27_A30MvADItem ;
      private string[] P00C28_A254ComDProCod ;
      private bool[] P00C28_n254ComDProCod ;
      private string[] P00C28_A251ComDOrdCod ;
      private string[] P00C28_A243ComCod ;
      private string[] P00C28_A149TipCod ;
      private string[] P00C28_A244PrvCod ;
      private short[] P00C28_A250ComDItem ;
   }

   public class r_registroinventariopermanenteunidadespdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C25( IGxContext context ,
                                             int AV8LinCod ,
                                             int AV45SublCod ,
                                             int AV46FamCod ,
                                             string AV10Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             int A21MvAlm ,
                                             int AV9AlmCod ,
                                             short A1158LinStk )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T3.[UniCod], T3.[ProdDsc], T1.[ProdCod], T5.[LinStk], T2.[MvAlm], T3.[FamCod], T3.[SublCod], T3.[LinCod], T4.[UniSunat], T5.[LinSunat], T1.[MvADItem] FROM (((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T4 ON T4.[UniCod] = T3.[UniCod]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T3.[LinCod])";
         AddWhere(sWhereString, "(T2.[MvAlm] = @AV9AlmCod)");
         AddWhere(sWhereString, "(T5.[LinStk] = 1)");
         if ( ! (0==AV8LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV8LinCod)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV45SublCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV45SublCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV46FamCod) )
         {
            AddWhere(sWhereString, "(T3.[FamCod] = @AV46FamCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV10Prodcod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T3.[ProdDsc]";
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
               case 3 :
                     return conditional_P00C25(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmP00C22;
          prmP00C22 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP00C23;
          prmP00C23 = new Object[] {
          new ParDef("@AV8LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00C24;
          prmP00C24 = new Object[] {
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00C26;
          prmP00C26 = new Object[] {
          new ParDef("@AV76FDesde",GXType.Date,8,0) ,
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV77FHasta",GXType.Date,8,0)
          };
          Object[] prmP00C27;
          prmP00C27 = new Object[] {
          new ParDef("@AV76FDesde",GXType.Date,8,0) ,
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV77FHasta",GXType.Date,8,0)
          };
          Object[] prmP00C28;
          prmP00C28 = new Object[] {
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV51OC",GXType.NChar,10,0)
          };
          Object[] prmP00C25;
          prmP00C25 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV8LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV45SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV46FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C22", "SELECT [AlmCod], [AlmDsc], [AlmDir] FROM [CALMACEN] WHERE [AlmCod] = @AV9AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C22,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C23", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV8LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C23,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C24", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV10Prodcod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C24,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C25", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C25,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C26", "SELECT T2.[MvAlm], T2.[MVSts], T2.[MvAFec], T1.[ProdCod], T1.[MvACod], T1.[MvATip], T2.[MVCDesItem], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T2.[MvAFec] >= @AV76FDesde) AND (T1.[ProdCod] = RTRIM(LTRIM(@AV36ProdCodC))) AND (T2.[MVSts] <> 'A') AND (T2.[MvAlm] = @AV9AlmCod) AND (T2.[MvAFec] <= @AV77FHasta) ORDER BY T2.[MvAFec], T2.[MVCDesItem], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C26,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C27", "SELECT T2.[MvAMov] AS MvAMov, T2.[MvAlm], T2.[MVSts], T2.[MvAFec], T1.[ProdCod], T2.[MvARef], T2.[MvAOcom], T2.[DocNum], T1.[MvADCant], T3.[MovAbr], T2.[MvATMov], T1.[MVADPrecio], T1.[MVADCosto], T1.[MvACod], T1.[MvATip], T2.[MVCDesItem], T1.[MvADItem] FROM (([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T3 ON T3.[MovCod] = T2.[MvAMov]) WHERE (T2.[MvAFec] >= @AV76FDesde) AND (T1.[ProdCod] = RTRIM(LTRIM(@AV36ProdCodC))) AND (T2.[MVSts] <> 'A') AND (T2.[MvAlm] = @AV9AlmCod) AND (T2.[MvAFec] <= @AV77FHasta) ORDER BY T2.[MvAFec], T2.[MVCDesItem], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C27,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C28", "SELECT [ComDProCod], [ComDOrdCod], [ComCod], [TipCod], [PrvCod], [ComDItem] FROM [CPCOMPRASDET] WHERE ([ComDProCod] = @AV36ProdCodC) AND ([ComDOrdCod] = @AV51OC) ORDER BY [ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C28,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
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
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
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
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
             case 5 :
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
                ((bool[]) buf[18])[0] = rslt.wasNull(16);
                ((int[]) buf[19])[0] = rslt.getInt(17);
                return;
             case 6 :
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
