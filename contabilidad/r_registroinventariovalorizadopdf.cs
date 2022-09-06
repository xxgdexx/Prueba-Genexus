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
   public class r_registroinventariovalorizadopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_registroinventariovalorizadopdf.aspx")), "contabilidad.r_registroinventariovalorizadopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_registroinventariovalorizadopdf.aspx")))) ;
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
               AV42LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV68SublCod = (int)(NumberUtil.Val( GetPar( "SublCod"), "."));
                  AV28FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AV89ProdCod = GetPar( "ProdCod");
                  AV29FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV33FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
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

      public r_registroinventariovalorizadopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_registroinventariovalorizadopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SublCod ,
                           ref int aP2_FamCod ,
                           ref string aP3_ProdCod ,
                           ref DateTime aP4_FDesde ,
                           ref DateTime aP5_FHasta )
      {
         this.AV42LinCod = aP0_LinCod;
         this.AV68SublCod = aP1_SublCod;
         this.AV28FamCod = aP2_FamCod;
         this.AV89ProdCod = aP3_ProdCod;
         this.AV29FDesde = aP4_FDesde;
         this.AV33FHasta = aP5_FHasta;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV42LinCod;
         aP1_SublCod=this.AV68SublCod;
         aP2_FamCod=this.AV28FamCod;
         aP3_ProdCod=this.AV89ProdCod;
         aP4_FDesde=this.AV29FDesde;
         aP5_FHasta=this.AV33FHasta;
      }

      public DateTime executeUdp( ref int aP0_LinCod ,
                                  ref int aP1_SublCod ,
                                  ref int aP2_FamCod ,
                                  ref string aP3_ProdCod ,
                                  ref DateTime aP4_FDesde )
      {
         execute(ref aP0_LinCod, ref aP1_SublCod, ref aP2_FamCod, ref aP3_ProdCod, ref aP4_FDesde, ref aP5_FHasta);
         return AV33FHasta ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SublCod ,
                                 ref int aP2_FamCod ,
                                 ref string aP3_ProdCod ,
                                 ref DateTime aP4_FDesde ,
                                 ref DateTime aP5_FHasta )
      {
         r_registroinventariovalorizadopdf objr_registroinventariovalorizadopdf;
         objr_registroinventariovalorizadopdf = new r_registroinventariovalorizadopdf();
         objr_registroinventariovalorizadopdf.AV42LinCod = aP0_LinCod;
         objr_registroinventariovalorizadopdf.AV68SublCod = aP1_SublCod;
         objr_registroinventariovalorizadopdf.AV28FamCod = aP2_FamCod;
         objr_registroinventariovalorizadopdf.AV89ProdCod = aP3_ProdCod;
         objr_registroinventariovalorizadopdf.AV29FDesde = aP4_FDesde;
         objr_registroinventariovalorizadopdf.AV33FHasta = aP5_FHasta;
         objr_registroinventariovalorizadopdf.context.SetSubmitInitialConfig(context);
         objr_registroinventariovalorizadopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_registroinventariovalorizadopdf);
         aP0_LinCod=this.AV42LinCod;
         aP1_SublCod=this.AV68SublCod;
         aP2_FamCod=this.AV28FamCod;
         aP3_ProdCod=this.AV89ProdCod;
         aP4_FDesde=this.AV29FDesde;
         aP5_FHasta=this.AV33FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_registroinventariovalorizadopdf)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
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
            AV26Empresa = AV67Session.Get("Empresa");
            AV25EmpDir = AV67Session.Get("EmpDir");
            AV27EmpRUC = AV67Session.Get("EmpRUC");
            AV57Ruta = AV67Session.Get("RUTA") + "/Logo.jpg";
            AV44Logo = AV57Ruta;
            AV93Logo_GXI = GXDbFile.PathToUrl( AV57Ruta);
            AV10Ano = (short)(DateTimeUtil.Year( AV29FDesde));
            AV45Mes = (short)(DateTimeUtil.Month( AV29FDesde));
            AV31FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV45Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV10Ano), 10, 0));
            AV32FechaD = context.localUtil.CToD( AV31FechaC, 2);
            GXt_char1 = AV17cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV45Mes, out  GXt_char1) ;
            AV17cMes = GXt_char1;
            AV77Tipo = "16";
            AV78Titulo = "FORMATO 13.1: REGISTRO DE INVENTARIO PERMANENTE VALORIZADO - DETALLE DE INVENTARIO VALORIZADO";
            AV55Periodo = StringUtil.Upper( AV17cMes) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV10Ano), 10, 0));
            AV46Metodo = "PROMEDIO";
            AV8Almacen = "(Todos)";
            AV34Filtro1 = "";
            AV35Filtro2 = "";
            /* Using cursor P00EU2 */
            pr_default.execute(0, new Object[] {AV42LinCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A52LinCod = P00EU2_A52LinCod[0];
               A1153LinDsc = P00EU2_A1153LinDsc[0];
               AV34Filtro1 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00EU3 */
            pr_default.execute(1, new Object[] {AV89ProdCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = P00EU3_A28ProdCod[0];
               A55ProdDsc = P00EU3_A55ProdDsc[0];
               AV35Filtro2 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV20CostoTotal = 0;
            AV69TCantidad = 0;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV42LinCod ,
                                                 AV68SublCod ,
                                                 AV28FamCod ,
                                                 AV89ProdCod ,
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
            /* Using cursor P00EU4 */
            pr_default.execute(2, new Object[] {AV42LinCod, AV68SublCod, AV28FamCod, AV89ProdCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               BRKEU5 = false;
               A13MvATip = P00EU4_A13MvATip[0];
               A14MvACod = P00EU4_A14MvACod[0];
               A21MvAlm = P00EU4_A21MvAlm[0];
               A49UniCod = P00EU4_A49UniCod[0];
               A55ProdDsc = P00EU4_A55ProdDsc[0];
               A28ProdCod = P00EU4_A28ProdCod[0];
               A1269MvAlmCos = P00EU4_A1269MvAlmCos[0];
               A1158LinStk = P00EU4_A1158LinStk[0];
               A50FamCod = P00EU4_A50FamCod[0];
               n50FamCod = P00EU4_n50FamCod[0];
               A51SublCod = P00EU4_A51SublCod[0];
               n51SublCod = P00EU4_n51SublCod[0];
               A52LinCod = P00EU4_A52LinCod[0];
               A2000UniSunat = P00EU4_A2000UniSunat[0];
               A1160LinSunat = P00EU4_A1160LinSunat[0];
               A30MvADItem = P00EU4_A30MvADItem[0];
               A21MvAlm = P00EU4_A21MvAlm[0];
               A1269MvAlmCos = P00EU4_A1269MvAlmCos[0];
               A49UniCod = P00EU4_A49UniCod[0];
               A55ProdDsc = P00EU4_A55ProdDsc[0];
               A50FamCod = P00EU4_A50FamCod[0];
               n50FamCod = P00EU4_n50FamCod[0];
               A51SublCod = P00EU4_A51SublCod[0];
               n51SublCod = P00EU4_n51SublCod[0];
               A52LinCod = P00EU4_A52LinCod[0];
               A2000UniSunat = P00EU4_A2000UniSunat[0];
               A1158LinStk = P00EU4_A1158LinStk[0];
               A1160LinSunat = P00EU4_A1160LinSunat[0];
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00EU4_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRKEU5 = false;
                  A13MvATip = P00EU4_A13MvATip[0];
                  A14MvACod = P00EU4_A14MvACod[0];
                  A55ProdDsc = P00EU4_A55ProdDsc[0];
                  A30MvADItem = P00EU4_A30MvADItem[0];
                  A55ProdDsc = P00EU4_A55ProdDsc[0];
                  BRKEU5 = true;
                  pr_default.readNext(2);
               }
               AV90ProdCodC = StringUtil.Trim( A28ProdCod);
               AV56Producto = StringUtil.Trim( A28ProdCod) + " - " + StringUtil.Trim( A55ProdDsc);
               AV85UniAbr = StringUtil.Trim( A2000UniSunat);
               AV43LinSunat = StringUtil.Trim( A1160LinSunat);
               AV11CanIni = 0;
               AV70TCosIni = 0;
               AV71TCosTIni = 0;
               AV38Ing1 = 0;
               AV40IngCU = 0;
               AV39IngCT = 0;
               AV83TTIngreso = 0;
               AV75TIngresoCT = 0;
               AV76TIngresoCU = 0;
               AV58Sal1 = 0;
               AV60SalCU = 0;
               AV59SalCT = 0;
               AV84TTSalida = 0;
               AV81TsalidaCT = 0;
               AV82TSalidaCU = 0;
               AV36Final = 0;
               new GeneXus.Programs.produccion.pobtenersaldocostoproductofechas(context ).execute( ref  AV29FDesde, ref  AV90ProdCodC, out  AV63Saldo, out  AV21CostoU) ;
               AV19CostoT = NumberUtil.Round( AV63Saldo*AV21CostoU, 2);
               AV72TCosto = AV19CostoT;
               AV36Final = AV63Saldo;
               /* Execute user subroutine: 'VALIDA' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               if ( ( AV37Flag == 0 ) || ( AV63Saldo != Convert.ToDecimal( 0 )) )
               {
                  HEU0( false, 22) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Producto : ", 6, Gx_line+5, 63, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Producto, "")), 70, Gx_line+5, 418, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85UniAbr, "")), 731, Gx_line+5, 774, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Tipo de Existencia :", 425, Gx_line+5, 526, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Codigo Unidad Medida : ", 595, Gx_line+5, 720, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43LinSunat, "")), 540, Gx_line+5, 583, Gx_line+18, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+22);
               }
               AV41Ingresa = 0;
               AV65Salida = 0;
               AV15Ceros = 0;
               AV74TIngreso = ((AV63Saldo>Convert.ToDecimal(0)) ? AV63Saldo : (decimal)(0));
               AV80TSalida = ((AV63Saldo<Convert.ToDecimal(0)) ? AV63Saldo : (decimal)(0));
               AV22CostoUAnt = AV21CostoU;
               if ( ( AV63Saldo != Convert.ToDecimal( 0 )) )
               {
                  AV11CanIni = AV74TIngreso;
                  AV70TCosIni = AV22CostoUAnt;
                  AV71TCosTIni = NumberUtil.Round( AV11CanIni*AV70TCosIni, 2);
                  HEU0( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV11CanIni, "ZZZZ,ZZZ,ZZ9.9999")), 236, Gx_line+3, 308, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70TCosIni, "ZZZZ,ZZZ,ZZ9.9999")), 295, Gx_line+3, 367, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71TCosTIni, "ZZZZZZ,ZZZ,ZZ9.99")), 350, Gx_line+3, 422, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60SalCU, "ZZZZ,ZZZ,ZZ9.9999")), 467, Gx_line+3, 539, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59SalCT, "ZZZZZZ,ZZZ,ZZ9.99")), 526, Gx_line+3, 598, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58Sal1, "ZZZZ,ZZZ,ZZ9.9999")), 404, Gx_line+3, 476, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV21CostoU, "ZZZZ,ZZZ,ZZ9.9999")), 644, Gx_line+3, 716, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36Final, "ZZZZ,ZZZ,ZZ9.9999")), 585, Gx_line+3, 657, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19CostoT, "ZZZZZZ,ZZZ,ZZ9.99")), 707, Gx_line+3, 779, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV29FDesde, "99/99/99"), 2, Gx_line+3, 34, Gx_line+14, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77Tipo, "")), 202, Gx_line+3, 239, Gx_line+14, 1+256, 0, 0, 0) ;
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
               if ( ( AV36Final <= Convert.ToDecimal( 0 )) )
               {
                  AV21CostoU = 0;
                  AV19CostoT = 0;
               }
               if ( ( AV37Flag == 0 ) || ( AV63Saldo != Convert.ToDecimal( 0 )) )
               {
                  HEU0( false, 34) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Producto, "")), 6, Gx_line+8, 235, Gx_line+26, 2, 0, 0, 0) ;
                  getPrinter().GxDrawLine(257, Gx_line+5, 785, Gx_line+5, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36Final, "ZZZZ,ZZZ,ZZ9.9999")), 585, Gx_line+13, 657, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19CostoT, "ZZZZZZ,ZZZ,ZZ9.99")), 707, Gx_line+13, 779, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV21CostoU, "ZZZZ,ZZZ,ZZ9.9999")), 644, Gx_line+13, 716, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV83TTIngreso, "ZZZZ,ZZZ,ZZ9.9999")), 236, Gx_line+13, 308, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75TIngresoCT, "ZZZZZZ,ZZZ,ZZ9.99")), 350, Gx_line+13, 422, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV81TsalidaCT, "ZZZZZZ,ZZZ,ZZ9.99")), 526, Gx_line+13, 598, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV84TTSalida, "ZZZZ,ZZZ,ZZ9.9999")), 404, Gx_line+13, 476, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV76TIngresoCU, "ZZZZ,ZZZ,ZZ9.9999")), 294, Gx_line+13, 366, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV82TSalidaCU, "ZZZZ,ZZZ,ZZ9.9999")), 467, Gx_line+13, 539, Gx_line+24, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+34);
               }
               AV20CostoTotal = (decimal)(AV20CostoTotal+AV19CostoT);
               AV69TCantidad = (decimal)(AV69TCantidad+AV36Final);
               if ( ! BRKEU5 )
               {
                  BRKEU5 = true;
                  pr_default.readNext(2);
               }
            }
            pr_default.close(2);
            HEU0( false, 55) ;
            getPrinter().GxDrawLine(599, Gx_line+13, 785, Gx_line+13, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20CostoTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 672, Gx_line+22, 779, Gx_line+37, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Totales", 458, Gx_line+22, 503, Gx_line+36, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69TCantidad, "ZZZZ,ZZZ,ZZ9.9999")), 552, Gx_line+22, 659, Gx_line+37, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+55);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HEU0( true, 0) ;
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
         AV37Flag = 1;
         /* Using cursor P00EU5 */
         pr_default.execute(3, new Object[] {AV29FDesde, AV90ProdCodC, AV33FHasta});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A21MvAlm = P00EU5_A21MvAlm[0];
            A52LinCod = P00EU5_A52LinCod[0];
            A1158LinStk = P00EU5_A1158LinStk[0];
            A1269MvAlmCos = P00EU5_A1269MvAlmCos[0];
            A1370MVSts = P00EU5_A1370MVSts[0];
            A25MvAFec = P00EU5_A25MvAFec[0];
            A28ProdCod = P00EU5_A28ProdCod[0];
            A14MvACod = P00EU5_A14MvACod[0];
            A13MvATip = P00EU5_A13MvATip[0];
            A19MVCDesItem = P00EU5_A19MVCDesItem[0];
            n19MVCDesItem = P00EU5_n19MVCDesItem[0];
            A30MvADItem = P00EU5_A30MvADItem[0];
            A52LinCod = P00EU5_A52LinCod[0];
            A1158LinStk = P00EU5_A1158LinStk[0];
            A21MvAlm = P00EU5_A21MvAlm[0];
            A1370MVSts = P00EU5_A1370MVSts[0];
            A25MvAFec = P00EU5_A25MvAFec[0];
            A19MVCDesItem = P00EU5_A19MVCDesItem[0];
            n19MVCDesItem = P00EU5_n19MVCDesItem[0];
            A1269MvAlmCos = P00EU5_A1269MvAlmCos[0];
            AV37Flag = 0;
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S121( )
      {
         /* 'DETALLEMOVIMIENTOS' Routine */
         returnInSub = false;
         /* Using cursor P00EU6 */
         pr_default.execute(4, new Object[] {AV29FDesde, AV90ProdCodC, AV33FHasta});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A22MvAMov = P00EU6_A22MvAMov[0];
            A21MvAlm = P00EU6_A21MvAlm[0];
            A52LinCod = P00EU6_A52LinCod[0];
            A1158LinStk = P00EU6_A1158LinStk[0];
            A1269MvAlmCos = P00EU6_A1269MvAlmCos[0];
            A1370MVSts = P00EU6_A1370MVSts[0];
            A25MvAFec = P00EU6_A25MvAFec[0];
            A28ProdCod = P00EU6_A28ProdCod[0];
            A1278MvARef = P00EU6_A1278MvARef[0];
            A1276MvAOcom = P00EU6_A1276MvAOcom[0];
            A24DocNum = P00EU6_A24DocNum[0];
            n24DocNum = P00EU6_n24DocNum[0];
            A1248MvADCant = P00EU6_A1248MvADCant[0];
            A1237MovAbr = P00EU6_A1237MovAbr[0];
            n1237MovAbr = P00EU6_n1237MovAbr[0];
            A1286MvATMov = P00EU6_A1286MvATMov[0];
            A1250MVADPrecio = P00EU6_A1250MVADPrecio[0];
            A1249MVADCosto = P00EU6_A1249MVADCosto[0];
            A14MvACod = P00EU6_A14MvACod[0];
            A13MvATip = P00EU6_A13MvATip[0];
            A19MVCDesItem = P00EU6_A19MVCDesItem[0];
            n19MVCDesItem = P00EU6_n19MVCDesItem[0];
            A30MvADItem = P00EU6_A30MvADItem[0];
            A52LinCod = P00EU6_A52LinCod[0];
            A1158LinStk = P00EU6_A1158LinStk[0];
            A22MvAMov = P00EU6_A22MvAMov[0];
            A21MvAlm = P00EU6_A21MvAlm[0];
            A1370MVSts = P00EU6_A1370MVSts[0];
            A25MvAFec = P00EU6_A25MvAFec[0];
            A1278MvARef = P00EU6_A1278MvARef[0];
            A1276MvAOcom = P00EU6_A1276MvAOcom[0];
            A24DocNum = P00EU6_A24DocNum[0];
            n24DocNum = P00EU6_n24DocNum[0];
            A1286MvATMov = P00EU6_A1286MvATMov[0];
            A19MVCDesItem = P00EU6_A19MVCDesItem[0];
            n19MVCDesItem = P00EU6_n19MVCDesItem[0];
            A1237MovAbr = P00EU6_A1237MovAbr[0];
            n1237MovAbr = P00EU6_n1237MovAbr[0];
            A1269MvAlmCos = P00EU6_A1269MvAlmCos[0];
            AV51MVATip = ((StringUtil.StrCmp(A13MvATip, "REM")==0) ? "09" : "00");
            AV48MVACod = A14MvACod;
            AV88DocRef = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? (String.IsNullOrEmpty(StringUtil.RTrim( A1276MvAOcom)) ? A1278MvARef : A1276MvAOcom) : A24DocNum);
            AV66Serie = StringUtil.Substring( A14MvACod, 1, 3);
            AV24DocNum = StringUtil.Substring( A14MvACod, 4, 7);
            AV41Ingresa = ((StringUtil.StrCmp(A13MvATip, "ING")==0) ? NumberUtil.Round( A1248MvADCant, 4) : (decimal)(0));
            AV65Salida = ((StringUtil.StrCmp(A13MvATip, "ING")!=0) ? NumberUtil.Round( A1248MvADCant, 4) : (decimal)(0));
            AV21CostoU = 0;
            AV19CostoT = 0;
            AV47MovAbr = A1237MovAbr;
            AV52MvATMov = A1286MvATMov;
            AV38Ing1 = 0;
            AV40IngCU = 0;
            AV39IngCT = 0;
            AV58Sal1 = 0;
            AV60SalCU = 0;
            AV59SalCT = 0;
            if ( StringUtil.StrCmp(A13MvATip, "ING") == 0 )
            {
               AV21CostoU = NumberUtil.Round( A1250MVADPrecio, 4);
               AV19CostoT = NumberUtil.Round( A1249MVADCosto, 2);
               AV72TCosto = (decimal)(AV72TCosto+AV19CostoT);
               AV22CostoUAnt = 0;
               AV38Ing1 = AV41Ingresa;
               AV40IngCU = AV21CostoU;
               AV39IngCT = AV19CostoT;
               if ( ( AV52MvATMov == 1 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV53OC)) )
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
               if ( ! (Convert.ToDecimal(0)==AV22CostoUAnt) )
               {
                  AV21CostoU = AV22CostoUAnt;
               }
               else
               {
                  if ( ( AV36Final <= Convert.ToDecimal( 0 )) )
                  {
                     AV21CostoU = 0;
                  }
                  else
                  {
                     AV21CostoU = NumberUtil.Round( AV72TCosto/ (decimal)(AV36Final), 4);
                  }
               }
               AV19CostoT = NumberUtil.Round( AV21CostoU*AV65Salida, 2);
               AV72TCosto = (decimal)(AV72TCosto+(NumberUtil.Round( AV19CostoT*-1, 2)));
               AV22CostoUAnt = AV21CostoU;
               AV58Sal1 = AV65Salida;
               AV60SalCU = AV21CostoU;
               AV59SalCT = AV19CostoT;
            }
            AV83TTIngreso = (decimal)(AV83TTIngreso+AV38Ing1);
            AV75TIngresoCT = (decimal)(AV75TIngresoCT+AV39IngCT);
            AV76TIngresoCU = ((AV83TTIngreso>Convert.ToDecimal(0)) ? NumberUtil.Round( AV75TIngresoCT/ (decimal)(AV83TTIngreso), 6) : (decimal)(0));
            AV84TTSalida = (decimal)(AV84TTSalida+AV58Sal1);
            AV81TsalidaCT = (decimal)(AV81TsalidaCT+AV59SalCT);
            AV82TSalidaCU = ((AV84TTSalida>Convert.ToDecimal(0)) ? NumberUtil.Round( AV81TsalidaCT/ (decimal)(AV84TTSalida), 6) : (decimal)(0));
            AV36Final = (decimal)(AV36Final+((AV41Ingresa-AV65Salida)));
            AV74TIngreso = (decimal)(AV74TIngreso+AV41Ingresa);
            AV80TSalida = (decimal)(AV80TSalida+AV65Salida);
            if ( ! (Convert.ToDecimal(0)==AV22CostoUAnt) )
            {
               AV21CostoU = AV22CostoUAnt;
            }
            else
            {
               if ( ( AV36Final <= Convert.ToDecimal( 0 )) )
               {
                  AV21CostoU = 0;
               }
               else
               {
                  AV21CostoU = NumberUtil.Round( AV72TCosto/ (decimal)(AV36Final), 4);
               }
            }
            AV19CostoT = NumberUtil.Round( AV21CostoU*AV36Final, 2);
            AV72TCosto = AV19CostoT;
            HEU0( false, 16) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 1, Gx_line+3, 33, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24DocNum, "")), 134, Gx_line+3, 185, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51MVATip, "")), 51, Gx_line+3, 74, Gx_line+14, 1+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47MovAbr, "")), 202, Gx_line+3, 239, Gx_line+14, 1+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38Ing1, "ZZZZ,ZZZ,ZZ9.9999")), 236, Gx_line+3, 308, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40IngCU, "ZZZZ,ZZZ,ZZ9.9999")), 295, Gx_line+3, 367, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39IngCT, "ZZZZZZ,ZZZ,ZZ9.99")), 350, Gx_line+3, 422, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60SalCU, "ZZZZ,ZZZ,ZZ9.9999")), 467, Gx_line+3, 539, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59SalCT, "ZZZZZZ,ZZZ,ZZ9.99")), 526, Gx_line+3, 598, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58Sal1, "ZZZZ,ZZZ,ZZ9.9999")), 404, Gx_line+3, 476, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV21CostoU, "ZZZZ,ZZZ,ZZ9.9999")), 644, Gx_line+3, 716, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36Final, "ZZZZ,ZZZ,ZZ9.9999")), 585, Gx_line+3, 657, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19CostoT, "ZZZZZZ,ZZZ,ZZ9.99")), 707, Gx_line+3, 779, Gx_line+14, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66Serie, "")), 91, Gx_line+1, 123, Gx_line+15, 0, 0, 0, 0) ;
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
         /* Using cursor P00EU7 */
         pr_default.execute(5, new Object[] {AV90ProdCodC, AV53OC});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A254ComDProCod = P00EU7_A254ComDProCod[0];
            n254ComDProCod = P00EU7_n254ComDProCod[0];
            A251ComDOrdCod = P00EU7_A251ComDOrdCod[0];
            A243ComCod = P00EU7_A243ComCod[0];
            A149TipCod = P00EU7_A149TipCod[0];
            A244PrvCod = P00EU7_A244PrvCod[0];
            A250ComDItem = P00EU7_A250ComDItem[0];
            AV24DocNum = A243ComCod;
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void HEU0( bool bFoot ,
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
               getPrinter().GxDrawText("Página:", 693, Gx_line+17, 737, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 748, Gx_line+17, 787, Gx_line+32, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Periodo, "")), 66, Gx_line+38, 588, Gx_line+53, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Empresa, "")), 149, Gx_line+67, 554, Gx_line+84, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27EmpRUC, "")), 66, Gx_line+52, 171, Gx_line+67, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PERIODO:", 4, Gx_line+38, 60, Gx_line+52, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RUC :", 4, Gx_line+52, 35, Gx_line+66, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+121, 788, Gx_line+172, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo", 52, Gx_line+155, 76, Gx_line+168, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 7, Gx_line+155, 38, Gx_line+168, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 265, Gx_line+156, 312, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Serie", 94, Gx_line+155, 122, Gx_line+168, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Número", 139, Gx_line+155, 181, Gx_line+168, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(425, Gx_line+121, 425, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 326, Gx_line+156, 370, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 379, Gx_line+156, 423, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 438, Gx_line+156, 485, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 497, Gx_line+156, 541, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 553, Gx_line+156, 597, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 611, Gx_line+156, 658, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo U.", 673, Gx_line+156, 717, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo T.", 728, Gx_line+156, 772, Gx_line+169, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(600, Gx_line+121, 600, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("ENTRADAS", 310, Gx_line+130, 369, Gx_line+143, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("SALIDAS", 490, Gx_line+130, 539, Gx_line+143, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("SALDO FINAL", 668, Gx_line+130, 742, Gx_line+143, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(195, Gx_line+122, 195, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(47, Gx_line+149, 47, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(84, Gx_line+149, 84, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+149, 195, Gx_line+149, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(128, Gx_line+150, 128, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(258, Gx_line+122, 258, Gx_line+172, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de", 206, Gx_line+133, 246, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Operación", 199, Gx_line+147, 253, Gx_line+160, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("DOCUMENTO DE TRASLADO, COMPROBANTE ", 6, Gx_line+125, 192, Gx_line+135, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DE PAGO, DOCUMENTO INTERNO O SIMILAR", 7, Gx_line+135, 193, Gx_line+145, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78Titulo, "")), 4, Gx_line+6, 318, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(259, Gx_line+149, 786, Gx_line+149, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("ESTABLECIMIENTO(1) : ", 4, Gx_line+85, 138, Gx_line+99, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25EmpDir, "")), 150, Gx_line+84, 555, Gx_line+101, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("METODO DE VALUACIÓN :", 4, Gx_line+103, 148, Gx_line+117, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Metodo, "")), 150, Gx_line+102, 299, Gx_line+119, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("ALMACEN :", 308, Gx_line+103, 369, Gx_line+117, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8Almacen, "")), 380, Gx_line+102, 683, Gx_line+119, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("RAZON SOCIAL :", 4, Gx_line+69, 97, Gx_line+83, 0+256, 0, 0, 0) ;
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
         AV26Empresa = "";
         AV67Session = context.GetSession();
         AV25EmpDir = "";
         AV27EmpRUC = "";
         AV57Ruta = "";
         AV44Logo = "";
         AV93Logo_GXI = "";
         AV31FechaC = "";
         AV32FechaD = DateTime.MinValue;
         AV17cMes = "";
         GXt_char1 = "";
         AV77Tipo = "";
         AV78Titulo = "";
         AV55Periodo = "";
         AV46Metodo = "";
         AV8Almacen = "";
         AV34Filtro1 = "";
         AV35Filtro2 = "";
         scmdbuf = "";
         P00EU2_A52LinCod = new int[1] ;
         P00EU2_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P00EU3_A28ProdCod = new string[] {""} ;
         P00EU3_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P00EU4_A13MvATip = new string[] {""} ;
         P00EU4_A14MvACod = new string[] {""} ;
         P00EU4_A21MvAlm = new int[1] ;
         P00EU4_A49UniCod = new int[1] ;
         P00EU4_A55ProdDsc = new string[] {""} ;
         P00EU4_A28ProdCod = new string[] {""} ;
         P00EU4_A1269MvAlmCos = new short[1] ;
         P00EU4_A1158LinStk = new short[1] ;
         P00EU4_A50FamCod = new int[1] ;
         P00EU4_n50FamCod = new bool[] {false} ;
         P00EU4_A51SublCod = new int[1] ;
         P00EU4_n51SublCod = new bool[] {false} ;
         P00EU4_A52LinCod = new int[1] ;
         P00EU4_A2000UniSunat = new string[] {""} ;
         P00EU4_A1160LinSunat = new string[] {""} ;
         P00EU4_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A2000UniSunat = "";
         A1160LinSunat = "";
         AV90ProdCodC = "";
         AV56Producto = "";
         AV85UniAbr = "";
         AV43LinSunat = "";
         P00EU5_A21MvAlm = new int[1] ;
         P00EU5_A52LinCod = new int[1] ;
         P00EU5_A1158LinStk = new short[1] ;
         P00EU5_A1269MvAlmCos = new short[1] ;
         P00EU5_A1370MVSts = new string[] {""} ;
         P00EU5_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00EU5_A28ProdCod = new string[] {""} ;
         P00EU5_A14MvACod = new string[] {""} ;
         P00EU5_A13MvATip = new string[] {""} ;
         P00EU5_A19MVCDesItem = new int[1] ;
         P00EU5_n19MVCDesItem = new bool[] {false} ;
         P00EU5_A30MvADItem = new int[1] ;
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         P00EU6_A22MvAMov = new int[1] ;
         P00EU6_A21MvAlm = new int[1] ;
         P00EU6_A52LinCod = new int[1] ;
         P00EU6_A1158LinStk = new short[1] ;
         P00EU6_A1269MvAlmCos = new short[1] ;
         P00EU6_A1370MVSts = new string[] {""} ;
         P00EU6_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00EU6_A28ProdCod = new string[] {""} ;
         P00EU6_A1278MvARef = new string[] {""} ;
         P00EU6_A1276MvAOcom = new string[] {""} ;
         P00EU6_A24DocNum = new string[] {""} ;
         P00EU6_n24DocNum = new bool[] {false} ;
         P00EU6_A1248MvADCant = new decimal[1] ;
         P00EU6_A1237MovAbr = new string[] {""} ;
         P00EU6_n1237MovAbr = new bool[] {false} ;
         P00EU6_A1286MvATMov = new short[1] ;
         P00EU6_A1250MVADPrecio = new decimal[1] ;
         P00EU6_A1249MVADCosto = new decimal[1] ;
         P00EU6_A14MvACod = new string[] {""} ;
         P00EU6_A13MvATip = new string[] {""} ;
         P00EU6_A19MVCDesItem = new int[1] ;
         P00EU6_n19MVCDesItem = new bool[] {false} ;
         P00EU6_A30MvADItem = new int[1] ;
         A1278MvARef = "";
         A1276MvAOcom = "";
         A24DocNum = "";
         A1237MovAbr = "";
         AV51MVATip = "";
         AV48MVACod = "";
         AV88DocRef = "";
         AV66Serie = "";
         AV24DocNum = "";
         AV47MovAbr = "";
         AV53OC = "";
         P00EU7_A254ComDProCod = new string[] {""} ;
         P00EU7_n254ComDProCod = new bool[] {false} ;
         P00EU7_A251ComDOrdCod = new string[] {""} ;
         P00EU7_A243ComCod = new string[] {""} ;
         P00EU7_A149TipCod = new string[] {""} ;
         P00EU7_A244PrvCod = new string[] {""} ;
         P00EU7_A250ComDItem = new short[1] ;
         A254ComDProCod = "";
         A251ComDOrdCod = "";
         A243ComCod = "";
         A149TipCod = "";
         A244PrvCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_registroinventariovalorizadopdf__default(),
            new Object[][] {
                new Object[] {
               P00EU2_A52LinCod, P00EU2_A1153LinDsc
               }
               , new Object[] {
               P00EU3_A28ProdCod, P00EU3_A55ProdDsc
               }
               , new Object[] {
               P00EU4_A13MvATip, P00EU4_A14MvACod, P00EU4_A21MvAlm, P00EU4_A49UniCod, P00EU4_A55ProdDsc, P00EU4_A28ProdCod, P00EU4_A1269MvAlmCos, P00EU4_A1158LinStk, P00EU4_A50FamCod, P00EU4_n50FamCod,
               P00EU4_A51SublCod, P00EU4_n51SublCod, P00EU4_A52LinCod, P00EU4_A2000UniSunat, P00EU4_A1160LinSunat, P00EU4_A30MvADItem
               }
               , new Object[] {
               P00EU5_A21MvAlm, P00EU5_A52LinCod, P00EU5_A1158LinStk, P00EU5_A1269MvAlmCos, P00EU5_A1370MVSts, P00EU5_A25MvAFec, P00EU5_A28ProdCod, P00EU5_A14MvACod, P00EU5_A13MvATip, P00EU5_A19MVCDesItem,
               P00EU5_n19MVCDesItem, P00EU5_A30MvADItem
               }
               , new Object[] {
               P00EU6_A22MvAMov, P00EU6_A21MvAlm, P00EU6_A52LinCod, P00EU6_A1158LinStk, P00EU6_A1269MvAlmCos, P00EU6_A1370MVSts, P00EU6_A25MvAFec, P00EU6_A28ProdCod, P00EU6_A1278MvARef, P00EU6_A1276MvAOcom,
               P00EU6_A24DocNum, P00EU6_n24DocNum, P00EU6_A1248MvADCant, P00EU6_A1237MovAbr, P00EU6_n1237MovAbr, P00EU6_A1286MvATMov, P00EU6_A1250MVADPrecio, P00EU6_A1249MVADCosto, P00EU6_A14MvACod, P00EU6_A13MvATip,
               P00EU6_A19MVCDesItem, P00EU6_n19MVCDesItem, P00EU6_A30MvADItem
               }
               , new Object[] {
               P00EU7_A254ComDProCod, P00EU7_n254ComDProCod, P00EU7_A251ComDOrdCod, P00EU7_A243ComCod, P00EU7_A149TipCod, P00EU7_A244PrvCod, P00EU7_A250ComDItem
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV10Ano ;
      private short AV45Mes ;
      private short A1158LinStk ;
      private short A1269MvAlmCos ;
      private short AV37Flag ;
      private short A1286MvATMov ;
      private short AV52MvATMov ;
      private short A250ComDItem ;
      private int AV42LinCod ;
      private int AV68SublCod ;
      private int AV28FamCod ;
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
      private decimal AV20CostoTotal ;
      private decimal AV69TCantidad ;
      private decimal AV11CanIni ;
      private decimal AV70TCosIni ;
      private decimal AV71TCosTIni ;
      private decimal AV38Ing1 ;
      private decimal AV40IngCU ;
      private decimal AV39IngCT ;
      private decimal AV83TTIngreso ;
      private decimal AV75TIngresoCT ;
      private decimal AV76TIngresoCU ;
      private decimal AV58Sal1 ;
      private decimal AV60SalCU ;
      private decimal AV59SalCT ;
      private decimal AV84TTSalida ;
      private decimal AV81TsalidaCT ;
      private decimal AV82TSalidaCU ;
      private decimal AV36Final ;
      private decimal AV63Saldo ;
      private decimal AV21CostoU ;
      private decimal AV19CostoT ;
      private decimal AV72TCosto ;
      private decimal AV41Ingresa ;
      private decimal AV65Salida ;
      private decimal AV15Ceros ;
      private decimal AV74TIngreso ;
      private decimal AV80TSalida ;
      private decimal AV22CostoUAnt ;
      private decimal A1248MvADCant ;
      private decimal A1250MVADPrecio ;
      private decimal A1249MVADCosto ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV89ProdCod ;
      private string AV26Empresa ;
      private string AV25EmpDir ;
      private string AV27EmpRUC ;
      private string AV57Ruta ;
      private string AV31FechaC ;
      private string AV17cMes ;
      private string GXt_char1 ;
      private string AV77Tipo ;
      private string AV78Titulo ;
      private string AV55Periodo ;
      private string AV46Metodo ;
      private string AV8Almacen ;
      private string AV34Filtro1 ;
      private string AV35Filtro2 ;
      private string scmdbuf ;
      private string A1153LinDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string AV90ProdCodC ;
      private string AV56Producto ;
      private string AV85UniAbr ;
      private string A1370MVSts ;
      private string A1278MvARef ;
      private string A1276MvAOcom ;
      private string A24DocNum ;
      private string A1237MovAbr ;
      private string AV51MVATip ;
      private string AV48MVACod ;
      private string AV88DocRef ;
      private string AV66Serie ;
      private string AV24DocNum ;
      private string AV47MovAbr ;
      private string AV53OC ;
      private string A254ComDProCod ;
      private string A251ComDOrdCod ;
      private string A243ComCod ;
      private string A149TipCod ;
      private string A244PrvCod ;
      private DateTime AV29FDesde ;
      private DateTime AV33FHasta ;
      private DateTime AV32FechaD ;
      private DateTime A25MvAFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKEU5 ;
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
      private string AV43LinSunat ;
      private string AV44Logo ;
      private IGxSession AV67Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SublCod ;
      private int aP2_FamCod ;
      private string aP3_ProdCod ;
      private DateTime aP4_FDesde ;
      private DateTime aP5_FHasta ;
      private IDataStoreProvider pr_default ;
      private int[] P00EU2_A52LinCod ;
      private string[] P00EU2_A1153LinDsc ;
      private string[] P00EU3_A28ProdCod ;
      private string[] P00EU3_A55ProdDsc ;
      private string[] P00EU4_A13MvATip ;
      private string[] P00EU4_A14MvACod ;
      private int[] P00EU4_A21MvAlm ;
      private int[] P00EU4_A49UniCod ;
      private string[] P00EU4_A55ProdDsc ;
      private string[] P00EU4_A28ProdCod ;
      private short[] P00EU4_A1269MvAlmCos ;
      private short[] P00EU4_A1158LinStk ;
      private int[] P00EU4_A50FamCod ;
      private bool[] P00EU4_n50FamCod ;
      private int[] P00EU4_A51SublCod ;
      private bool[] P00EU4_n51SublCod ;
      private int[] P00EU4_A52LinCod ;
      private string[] P00EU4_A2000UniSunat ;
      private string[] P00EU4_A1160LinSunat ;
      private int[] P00EU4_A30MvADItem ;
      private int[] P00EU5_A21MvAlm ;
      private int[] P00EU5_A52LinCod ;
      private short[] P00EU5_A1158LinStk ;
      private short[] P00EU5_A1269MvAlmCos ;
      private string[] P00EU5_A1370MVSts ;
      private DateTime[] P00EU5_A25MvAFec ;
      private string[] P00EU5_A28ProdCod ;
      private string[] P00EU5_A14MvACod ;
      private string[] P00EU5_A13MvATip ;
      private int[] P00EU5_A19MVCDesItem ;
      private bool[] P00EU5_n19MVCDesItem ;
      private int[] P00EU5_A30MvADItem ;
      private int[] P00EU6_A22MvAMov ;
      private int[] P00EU6_A21MvAlm ;
      private int[] P00EU6_A52LinCod ;
      private short[] P00EU6_A1158LinStk ;
      private short[] P00EU6_A1269MvAlmCos ;
      private string[] P00EU6_A1370MVSts ;
      private DateTime[] P00EU6_A25MvAFec ;
      private string[] P00EU6_A28ProdCod ;
      private string[] P00EU6_A1278MvARef ;
      private string[] P00EU6_A1276MvAOcom ;
      private string[] P00EU6_A24DocNum ;
      private bool[] P00EU6_n24DocNum ;
      private decimal[] P00EU6_A1248MvADCant ;
      private string[] P00EU6_A1237MovAbr ;
      private bool[] P00EU6_n1237MovAbr ;
      private short[] P00EU6_A1286MvATMov ;
      private decimal[] P00EU6_A1250MVADPrecio ;
      private decimal[] P00EU6_A1249MVADCosto ;
      private string[] P00EU6_A14MvACod ;
      private string[] P00EU6_A13MvATip ;
      private int[] P00EU6_A19MVCDesItem ;
      private bool[] P00EU6_n19MVCDesItem ;
      private int[] P00EU6_A30MvADItem ;
      private string[] P00EU7_A254ComDProCod ;
      private bool[] P00EU7_n254ComDProCod ;
      private string[] P00EU7_A251ComDOrdCod ;
      private string[] P00EU7_A243ComCod ;
      private string[] P00EU7_A149TipCod ;
      private string[] P00EU7_A244PrvCod ;
      private short[] P00EU7_A250ComDItem ;
   }

   public class r_registroinventariovalorizadopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EU4( IGxContext context ,
                                             int AV42LinCod ,
                                             int AV68SublCod ,
                                             int AV28FamCod ,
                                             string AV89ProdCod ,
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
         if ( ! (0==AV42LinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV42LinCod)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (0==AV68SublCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV68SublCod)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV28FamCod) )
         {
            AddWhere(sWhereString, "(T4.[FamCod] = @AV28FamCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV89ProdCod)");
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
                     return conditional_P00EU4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] );
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
          Object[] prmP00EU2;
          prmP00EU2 = new Object[] {
          new ParDef("@AV42LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00EU3;
          prmP00EU3 = new Object[] {
          new ParDef("@AV89ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00EU5;
          prmP00EU5 = new Object[] {
          new ParDef("@AV29FDesde",GXType.Date,8,0) ,
          new ParDef("@AV90ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV33FHasta",GXType.Date,8,0)
          };
          Object[] prmP00EU6;
          prmP00EU6 = new Object[] {
          new ParDef("@AV29FDesde",GXType.Date,8,0) ,
          new ParDef("@AV90ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV33FHasta",GXType.Date,8,0)
          };
          Object[] prmP00EU7;
          prmP00EU7 = new Object[] {
          new ParDef("@AV90ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV53OC",GXType.NChar,10,0)
          };
          Object[] prmP00EU4;
          prmP00EU4 = new Object[] {
          new ParDef("@AV42LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV68SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV28FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV89ProdCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EU2", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV42LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EU2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EU3", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV89ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EU3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EU4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EU4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EU5", "SELECT T4.[MvAlm] AS MvAlm, T2.[LinCod], T3.[LinStk], T5.[AlmCos] AS MvAlmCos, T4.[MVSts], T4.[MvAFec], T1.[ProdCod], T1.[MvACod], T1.[MvATip], T4.[MVCDesItem], T1.[MvADItem] FROM (((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [AGUIAS] T4 ON T4.[MvATip] = T1.[MvATip] AND T4.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T5 ON T5.[AlmCod] = T4.[MvAlm]) WHERE (T4.[MvAFec] >= @AV29FDesde) AND (T1.[ProdCod] = RTRIM(LTRIM(@AV90ProdCodC))) AND (T4.[MVSts] <> 'A') AND (T3.[LinStk] = 1) AND (T5.[AlmCos] = 1) AND (T4.[MvAFec] <= @AV33FHasta) ORDER BY T4.[MvAFec], T4.[MVCDesItem], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EU5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EU6", "SELECT T4.[MvAMov] AS MvAMov, T4.[MvAlm] AS MvAlm, T2.[LinCod], T3.[LinStk], T6.[AlmCos] AS MvAlmCos, T4.[MVSts], T4.[MvAFec], T1.[ProdCod], T4.[MvARef], T4.[MvAOcom], T4.[DocNum], T1.[MvADCant], T5.[MovAbr], T4.[MvATMov], T1.[MVADPrecio], T1.[MVADCosto], T1.[MvACod], T1.[MvATip], T4.[MVCDesItem], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [AGUIAS] T4 ON T4.[MvATip] = T1.[MvATip] AND T4.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T5 ON T5.[MovCod] = T4.[MvAMov]) INNER JOIN [CALMACEN] T6 ON T6.[AlmCod] = T4.[MvAlm]) WHERE (T4.[MvAFec] >= @AV29FDesde) AND (T1.[ProdCod] = RTRIM(LTRIM(@AV90ProdCodC))) AND (T4.[MVSts] <> 'A') AND (T3.[LinStk] = 1) AND (T6.[AlmCos] = 1) AND (T4.[MvAFec] <= @AV33FHasta) ORDER BY T4.[MvAFec], T4.[MVCDesItem], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EU6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EU7", "SELECT [ComDProCod], [ComDOrdCod], [ComCod], [TipCod], [PrvCod], [ComDItem] FROM [CPCOMPRASDET] WHERE ([ComDProCod] = @AV90ProdCodC) AND ([ComDOrdCod] = @AV53OC) ORDER BY [ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EU7,100, GxCacheFrequency.OFF ,false,false )
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
