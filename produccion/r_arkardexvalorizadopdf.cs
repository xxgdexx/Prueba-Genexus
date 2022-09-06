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
   public class r_arkardexvalorizadopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "produccion.r_arkardexvalorizadopdf.aspx")), "produccion.r_arkardexvalorizadopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "produccion.r_arkardexvalorizadopdf.aspx")))) ;
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

      public r_arkardexvalorizadopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_arkardexvalorizadopdf( IGxContext context )
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
         r_arkardexvalorizadopdf objr_arkardexvalorizadopdf;
         objr_arkardexvalorizadopdf = new r_arkardexvalorizadopdf();
         objr_arkardexvalorizadopdf.AV8LinCod = aP0_LinCod;
         objr_arkardexvalorizadopdf.AV45SublCod = aP1_SublCod;
         objr_arkardexvalorizadopdf.AV46FamCod = aP2_FamCod;
         objr_arkardexvalorizadopdf.AV9AlmCod = aP3_AlmCod;
         objr_arkardexvalorizadopdf.AV10Prodcod = aP4_Prodcod;
         objr_arkardexvalorizadopdf.AV76FDesde = aP5_FDesde;
         objr_arkardexvalorizadopdf.AV77FHasta = aP6_FHasta;
         objr_arkardexvalorizadopdf.context.SetSubmitInitialConfig(context);
         objr_arkardexvalorizadopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_arkardexvalorizadopdf);
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
            ((r_arkardexvalorizadopdf)stateInfo).executePrivate();
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
            AV85Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV66UsuCod = AV44Session.Get("UsuCod");
            AV12Titulo = "Kardex Valorizado";
            /* Using cursor P00FM2 */
            pr_default.execute(0, new Object[] {AV9AlmCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A63AlmCod = P00FM2_A63AlmCod[0];
               A436AlmDsc = P00FM2_A436AlmDsc[0];
               AV11Almacen = A436AlmDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV22Filtro1 = "(Todos)";
            AV24Filtro2 = "(Todos)";
            /* Using cursor P00FM3 */
            pr_default.execute(1, new Object[] {AV8LinCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A52LinCod = P00FM3_A52LinCod[0];
               A1153LinDsc = P00FM3_A1153LinDsc[0];
               AV22Filtro1 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00FM4 */
            pr_default.execute(2, new Object[] {AV10Prodcod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A28ProdCod = P00FM4_A28ProdCod[0];
               A55ProdDsc = P00FM4_A55ProdDsc[0];
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
                                                 A1158LinStk ,
                                                 A1269MvAlmCos } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00FM5 */
            pr_default.execute(3, new Object[] {AV9AlmCod, AV8LinCod, AV45SublCod, AV46FamCod, AV10Prodcod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               BRKFM6 = false;
               A13MvATip = P00FM5_A13MvATip[0];
               A14MvACod = P00FM5_A14MvACod[0];
               A49UniCod = P00FM5_A49UniCod[0];
               A55ProdDsc = P00FM5_A55ProdDsc[0];
               A28ProdCod = P00FM5_A28ProdCod[0];
               A1269MvAlmCos = P00FM5_A1269MvAlmCos[0];
               A1158LinStk = P00FM5_A1158LinStk[0];
               A21MvAlm = P00FM5_A21MvAlm[0];
               A50FamCod = P00FM5_A50FamCod[0];
               n50FamCod = P00FM5_n50FamCod[0];
               A51SublCod = P00FM5_A51SublCod[0];
               n51SublCod = P00FM5_n51SublCod[0];
               A52LinCod = P00FM5_A52LinCod[0];
               A1997UniAbr = P00FM5_A1997UniAbr[0];
               A30MvADItem = P00FM5_A30MvADItem[0];
               A21MvAlm = P00FM5_A21MvAlm[0];
               A1269MvAlmCos = P00FM5_A1269MvAlmCos[0];
               A49UniCod = P00FM5_A49UniCod[0];
               A55ProdDsc = P00FM5_A55ProdDsc[0];
               A50FamCod = P00FM5_A50FamCod[0];
               n50FamCod = P00FM5_n50FamCod[0];
               A51SublCod = P00FM5_A51SublCod[0];
               n51SublCod = P00FM5_n51SublCod[0];
               A52LinCod = P00FM5_A52LinCod[0];
               A1997UniAbr = P00FM5_A1997UniAbr[0];
               A1158LinStk = P00FM5_A1158LinStk[0];
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00FM5_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRKFM6 = false;
                  A13MvATip = P00FM5_A13MvATip[0];
                  A14MvACod = P00FM5_A14MvACod[0];
                  A55ProdDsc = P00FM5_A55ProdDsc[0];
                  A30MvADItem = P00FM5_A30MvADItem[0];
                  A55ProdDsc = P00FM5_A55ProdDsc[0];
                  BRKFM6 = true;
                  pr_default.readNext(3);
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
                  HFM0( false, 22) ;
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
                  HFM0( false, 18) ;
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
                  HFM0( false, 34) ;
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
               if ( ! BRKFM6 )
               {
                  BRKFM6 = true;
                  pr_default.readNext(3);
               }
            }
            pr_default.close(3);
            HFM0( false, 55) ;
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
            HFM0( true, 0) ;
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
         /* Using cursor P00FM6 */
         pr_default.execute(4, new Object[] {AV76FDesde, AV36ProdCodC, AV9AlmCod, AV77FHasta});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A21MvAlm = P00FM6_A21MvAlm[0];
            A1370MVSts = P00FM6_A1370MVSts[0];
            A25MvAFec = P00FM6_A25MvAFec[0];
            A28ProdCod = P00FM6_A28ProdCod[0];
            A14MvACod = P00FM6_A14MvACod[0];
            A13MvATip = P00FM6_A13MvATip[0];
            A30MvADItem = P00FM6_A30MvADItem[0];
            A21MvAlm = P00FM6_A21MvAlm[0];
            A1370MVSts = P00FM6_A1370MVSts[0];
            A25MvAFec = P00FM6_A25MvAFec[0];
            AV26Flag = 0;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S121( )
      {
         /* 'DETALLEMOVIMIENTOS' Routine */
         returnInSub = false;
         /* Using cursor P00FM7 */
         pr_default.execute(5, new Object[] {AV76FDesde, AV36ProdCodC, AV9AlmCod, AV77FHasta});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A22MvAMov = P00FM7_A22MvAMov[0];
            A21MvAlm = P00FM7_A21MvAlm[0];
            A1370MVSts = P00FM7_A1370MVSts[0];
            A25MvAFec = P00FM7_A25MvAFec[0];
            A28ProdCod = P00FM7_A28ProdCod[0];
            A1278MvARef = P00FM7_A1278MvARef[0];
            A1276MvAOcom = P00FM7_A1276MvAOcom[0];
            A24DocNum = P00FM7_A24DocNum[0];
            n24DocNum = P00FM7_n24DocNum[0];
            A1248MvADCant = P00FM7_A1248MvADCant[0];
            A1237MovAbr = P00FM7_A1237MovAbr[0];
            n1237MovAbr = P00FM7_n1237MovAbr[0];
            A1286MvATMov = P00FM7_A1286MvATMov[0];
            A1250MVADPrecio = P00FM7_A1250MVADPrecio[0];
            A1249MVADCosto = P00FM7_A1249MVADCosto[0];
            A14MvACod = P00FM7_A14MvACod[0];
            A13MvATip = P00FM7_A13MvATip[0];
            A30MvADItem = P00FM7_A30MvADItem[0];
            A22MvAMov = P00FM7_A22MvAMov[0];
            A21MvAlm = P00FM7_A21MvAlm[0];
            A1370MVSts = P00FM7_A1370MVSts[0];
            A25MvAFec = P00FM7_A25MvAFec[0];
            A1278MvARef = P00FM7_A1278MvARef[0];
            A1276MvAOcom = P00FM7_A1276MvAOcom[0];
            A24DocNum = P00FM7_A24DocNum[0];
            n24DocNum = P00FM7_n24DocNum[0];
            A1286MvATMov = P00FM7_A1286MvATMov[0];
            A1237MovAbr = P00FM7_A1237MovAbr[0];
            n1237MovAbr = P00FM7_n1237MovAbr[0];
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
            HFM0( false, 16) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 9, Gx_line+1, 48, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), 91, Gx_line+1, 142, Gx_line+14, 1+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13MvATip, "")), 52, Gx_line+1, 84, Gx_line+15, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67MovAbr, "")), 167, Gx_line+1, 198, Gx_line+13, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50DocNum, "")), 204, Gx_line+1, 255, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51OC, "")), 267, Gx_line+1, 310, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52OCP, "")), 328, Gx_line+1, 371, Gx_line+14, 0+256, 0, 0, 0) ;
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
         /* Using cursor P00FM8 */
         pr_default.execute(6, new Object[] {AV36ProdCodC, AV51OC});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A254ComDProCod = P00FM8_A254ComDProCod[0];
            n254ComDProCod = P00FM8_n254ComDProCod[0];
            A251ComDOrdCod = P00FM8_A251ComDOrdCod[0];
            A243ComCod = P00FM8_A243ComCod[0];
            A149TipCod = P00FM8_A149TipCod[0];
            A244PrvCod = P00FM8_A244PrvCod[0];
            A250ComDItem = P00FM8_A250ComDItem[0];
            AV50DocNum = A243ComCod;
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void HFM0( bool bFoot ,
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11Almacen, "")), 343, Gx_line+34, 799, Gx_line+59, 1, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 413, Gx_line+59, 778, Gx_line+83, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro2, "")), 413, Gx_line+79, 778, Gx_line+103, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV76FDesde, "99/99/99"), 413, Gx_line+101, 481, Gx_line+125, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Mes :", 538, Gx_line+106, 572, Gx_line+121, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV77FHasta, "99/99/99"), 619, Gx_line+101, 715, Gx_line+125, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12Titulo, "")), 343, Gx_line+7, 799, Gx_line+32, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Corr.", 92, Gx_line+154, 136, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("T/Mov", 156, Gx_line+154, 191, Gx_line+167, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV43Logo)) ? AV85Logo_GXI : AV43Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+3, 175, Gx_line+80) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Empresa, "")), 9, Gx_line+82, 317, Gx_line+100, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41EmpRUC, "")), 9, Gx_line+100, 179, Gx_line+118, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("O/C", 277, Gx_line+154, 299, Gx_line+167, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Guia - O/P", 322, Gx_line+154, 377, Gx_line+167, 0+256, 0, 0, 0) ;
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
         AV85Logo_GXI = "";
         AV66UsuCod = "";
         AV12Titulo = "";
         scmdbuf = "";
         P00FM2_A63AlmCod = new int[1] ;
         P00FM2_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         AV11Almacen = "";
         AV22Filtro1 = "";
         AV24Filtro2 = "";
         P00FM3_A52LinCod = new int[1] ;
         P00FM3_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P00FM4_A28ProdCod = new string[] {""} ;
         P00FM4_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P00FM5_A13MvATip = new string[] {""} ;
         P00FM5_A14MvACod = new string[] {""} ;
         P00FM5_A49UniCod = new int[1] ;
         P00FM5_A55ProdDsc = new string[] {""} ;
         P00FM5_A28ProdCod = new string[] {""} ;
         P00FM5_A1269MvAlmCos = new short[1] ;
         P00FM5_A1158LinStk = new short[1] ;
         P00FM5_A21MvAlm = new int[1] ;
         P00FM5_A50FamCod = new int[1] ;
         P00FM5_n50FamCod = new bool[] {false} ;
         P00FM5_A51SublCod = new int[1] ;
         P00FM5_n51SublCod = new bool[] {false} ;
         P00FM5_A52LinCod = new int[1] ;
         P00FM5_A1997UniAbr = new string[] {""} ;
         P00FM5_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A1997UniAbr = "";
         AV36ProdCodC = "";
         AV15Producto = "";
         AV65UniAbr = "";
         P00FM6_A21MvAlm = new int[1] ;
         P00FM6_A1370MVSts = new string[] {""} ;
         P00FM6_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FM6_A28ProdCod = new string[] {""} ;
         P00FM6_A14MvACod = new string[] {""} ;
         P00FM6_A13MvATip = new string[] {""} ;
         P00FM6_A30MvADItem = new int[1] ;
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         P00FM7_A22MvAMov = new int[1] ;
         P00FM7_A21MvAlm = new int[1] ;
         P00FM7_A1370MVSts = new string[] {""} ;
         P00FM7_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FM7_A28ProdCod = new string[] {""} ;
         P00FM7_A1278MvARef = new string[] {""} ;
         P00FM7_A1276MvAOcom = new string[] {""} ;
         P00FM7_A24DocNum = new string[] {""} ;
         P00FM7_n24DocNum = new bool[] {false} ;
         P00FM7_A1248MvADCant = new decimal[1] ;
         P00FM7_A1237MovAbr = new string[] {""} ;
         P00FM7_n1237MovAbr = new bool[] {false} ;
         P00FM7_A1286MvATMov = new short[1] ;
         P00FM7_A1250MVADPrecio = new decimal[1] ;
         P00FM7_A1249MVADCosto = new decimal[1] ;
         P00FM7_A14MvACod = new string[] {""} ;
         P00FM7_A13MvATip = new string[] {""} ;
         P00FM7_A30MvADItem = new int[1] ;
         A1278MvARef = "";
         A1276MvAOcom = "";
         A24DocNum = "";
         A1237MovAbr = "";
         AV34MVATip = "";
         AV35MVACod = "";
         AV82MVAFec = DateTime.MinValue;
         AV47DocRef = "";
         AV50DocNum = "";
         AV51OC = "";
         AV52OCP = "";
         AV67MovAbr = "";
         P00FM8_A254ComDProCod = new string[] {""} ;
         P00FM8_n254ComDProCod = new bool[] {false} ;
         P00FM8_A251ComDOrdCod = new string[] {""} ;
         P00FM8_A243ComCod = new string[] {""} ;
         P00FM8_A149TipCod = new string[] {""} ;
         P00FM8_A244PrvCod = new string[] {""} ;
         P00FM8_A250ComDItem = new short[1] ;
         A254ComDProCod = "";
         A251ComDOrdCod = "";
         A243ComCod = "";
         A149TipCod = "";
         A244PrvCod = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV43Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_arkardexvalorizadopdf__default(),
            new Object[][] {
                new Object[] {
               P00FM2_A63AlmCod, P00FM2_A436AlmDsc
               }
               , new Object[] {
               P00FM3_A52LinCod, P00FM3_A1153LinDsc
               }
               , new Object[] {
               P00FM4_A28ProdCod, P00FM4_A55ProdDsc
               }
               , new Object[] {
               P00FM5_A13MvATip, P00FM5_A14MvACod, P00FM5_A49UniCod, P00FM5_A55ProdDsc, P00FM5_A28ProdCod, P00FM5_A1269MvAlmCos, P00FM5_A1158LinStk, P00FM5_A21MvAlm, P00FM5_A50FamCod, P00FM5_n50FamCod,
               P00FM5_A51SublCod, P00FM5_n51SublCod, P00FM5_A52LinCod, P00FM5_A1997UniAbr, P00FM5_A30MvADItem
               }
               , new Object[] {
               P00FM6_A21MvAlm, P00FM6_A1370MVSts, P00FM6_A25MvAFec, P00FM6_A28ProdCod, P00FM6_A14MvACod, P00FM6_A13MvATip, P00FM6_A30MvADItem
               }
               , new Object[] {
               P00FM7_A22MvAMov, P00FM7_A21MvAlm, P00FM7_A1370MVSts, P00FM7_A25MvAFec, P00FM7_A28ProdCod, P00FM7_A1278MvARef, P00FM7_A1276MvAOcom, P00FM7_A24DocNum, P00FM7_n24DocNum, P00FM7_A1248MvADCant,
               P00FM7_A1237MovAbr, P00FM7_n1237MovAbr, P00FM7_A1286MvATMov, P00FM7_A1250MVADPrecio, P00FM7_A1249MVADCosto, P00FM7_A14MvACod, P00FM7_A13MvATip, P00FM7_A30MvADItem
               }
               , new Object[] {
               P00FM8_A254ComDProCod, P00FM8_n254ComDProCod, P00FM8_A251ComDOrdCod, P00FM8_A243ComCod, P00FM8_A149TipCod, P00FM8_A244PrvCod, P00FM8_A250ComDItem
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
      private string AV66UsuCod ;
      private string AV12Titulo ;
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
      private string A1997UniAbr ;
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
      private bool BRKFM6 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private bool n24DocNum ;
      private bool n1237MovAbr ;
      private bool n254ComDProCod ;
      private string AV85Logo_GXI ;
      private string AV43Logo ;
      private string Logo ;
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
      private int[] P00FM2_A63AlmCod ;
      private string[] P00FM2_A436AlmDsc ;
      private int[] P00FM3_A52LinCod ;
      private string[] P00FM3_A1153LinDsc ;
      private string[] P00FM4_A28ProdCod ;
      private string[] P00FM4_A55ProdDsc ;
      private string[] P00FM5_A13MvATip ;
      private string[] P00FM5_A14MvACod ;
      private int[] P00FM5_A49UniCod ;
      private string[] P00FM5_A55ProdDsc ;
      private string[] P00FM5_A28ProdCod ;
      private short[] P00FM5_A1269MvAlmCos ;
      private short[] P00FM5_A1158LinStk ;
      private int[] P00FM5_A21MvAlm ;
      private int[] P00FM5_A50FamCod ;
      private bool[] P00FM5_n50FamCod ;
      private int[] P00FM5_A51SublCod ;
      private bool[] P00FM5_n51SublCod ;
      private int[] P00FM5_A52LinCod ;
      private string[] P00FM5_A1997UniAbr ;
      private int[] P00FM5_A30MvADItem ;
      private int[] P00FM6_A21MvAlm ;
      private string[] P00FM6_A1370MVSts ;
      private DateTime[] P00FM6_A25MvAFec ;
      private string[] P00FM6_A28ProdCod ;
      private string[] P00FM6_A14MvACod ;
      private string[] P00FM6_A13MvATip ;
      private int[] P00FM6_A30MvADItem ;
      private int[] P00FM7_A22MvAMov ;
      private int[] P00FM7_A21MvAlm ;
      private string[] P00FM7_A1370MVSts ;
      private DateTime[] P00FM7_A25MvAFec ;
      private string[] P00FM7_A28ProdCod ;
      private string[] P00FM7_A1278MvARef ;
      private string[] P00FM7_A1276MvAOcom ;
      private string[] P00FM7_A24DocNum ;
      private bool[] P00FM7_n24DocNum ;
      private decimal[] P00FM7_A1248MvADCant ;
      private string[] P00FM7_A1237MovAbr ;
      private bool[] P00FM7_n1237MovAbr ;
      private short[] P00FM7_A1286MvATMov ;
      private decimal[] P00FM7_A1250MVADPrecio ;
      private decimal[] P00FM7_A1249MVADCosto ;
      private string[] P00FM7_A14MvACod ;
      private string[] P00FM7_A13MvATip ;
      private int[] P00FM7_A30MvADItem ;
      private string[] P00FM8_A254ComDProCod ;
      private bool[] P00FM8_n254ComDProCod ;
      private string[] P00FM8_A251ComDOrdCod ;
      private string[] P00FM8_A243ComCod ;
      private string[] P00FM8_A149TipCod ;
      private string[] P00FM8_A244PrvCod ;
      private short[] P00FM8_A250ComDItem ;
   }

   public class r_arkardexvalorizadopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FM5( IGxContext context ,
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
                                             short A1158LinStk ,
                                             short A1269MvAlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T4.[UniCod], T4.[ProdDsc], T1.[ProdCod], T3.[AlmCos] AS MvAlmCos, T6.[LinStk], T2.[MvAlm] AS MvAlm, T4.[FamCod], T4.[SublCod], T4.[LinCod], T5.[UniAbr], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) INNER JOIN [APRODUCTOS] T4 ON T4.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T5 ON T5.[UniCod] = T4.[UniCod]) INNER JOIN [CLINEAPROD] T6 ON T6.[LinCod] = T4.[LinCod])";
         AddWhere(sWhereString, "(T2.[MvAlm] = @AV9AlmCod)");
         AddWhere(sWhereString, "(T6.[LinStk] = 1)");
         AddWhere(sWhereString, "(T3.[AlmCos] = 1)");
         if ( ! (0==AV8LinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV8LinCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV45SublCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV45SublCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV46FamCod) )
         {
            AddWhere(sWhereString, "(T4.[FamCod] = @AV46FamCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV10Prodcod)");
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
                     return conditional_P00FM5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
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
          Object[] prmP00FM2;
          prmP00FM2 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP00FM3;
          prmP00FM3 = new Object[] {
          new ParDef("@AV8LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00FM4;
          prmP00FM4 = new Object[] {
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00FM6;
          prmP00FM6 = new Object[] {
          new ParDef("@AV76FDesde",GXType.Date,8,0) ,
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV77FHasta",GXType.Date,8,0)
          };
          Object[] prmP00FM7;
          prmP00FM7 = new Object[] {
          new ParDef("@AV76FDesde",GXType.Date,8,0) ,
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV77FHasta",GXType.Date,8,0)
          };
          Object[] prmP00FM8;
          prmP00FM8 = new Object[] {
          new ParDef("@AV36ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV51OC",GXType.NChar,10,0)
          };
          Object[] prmP00FM5;
          prmP00FM5 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV8LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV45SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV46FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FM2", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV9AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FM2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FM3", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV8LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FM3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FM4", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV10Prodcod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FM4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FM5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FM5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FM6", "SELECT TOP 1 T2.[MvAlm] AS MvAlm, T2.[MVSts], T2.[MvAFec], T1.[ProdCod], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T2.[MvAFec] >= @AV76FDesde) AND (T1.[ProdCod] = RTRIM(LTRIM(@AV36ProdCodC))) AND (T2.[MVSts] <> 'A') AND (T2.[MvAlm] = @AV9AlmCod) AND (T2.[MvAFec] <= @AV77FHasta) ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FM6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FM7", "SELECT T2.[MvAMov] AS MvAMov, T2.[MvAlm] AS MvAlm, T2.[MVSts], T2.[MvAFec], T1.[ProdCod], T2.[MvARef], T2.[MvAOcom], T2.[DocNum], T1.[MvADCant], T3.[MovAbr], T2.[MvATMov], T1.[MVADPrecio], T1.[MVADCosto], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM (([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T3 ON T3.[MovCod] = T2.[MvAMov]) WHERE (T2.[MvAFec] >= @AV76FDesde) AND (T1.[ProdCod] = RTRIM(LTRIM(@AV36ProdCodC))) AND (T2.[MVSts] <> 'A') AND (T2.[MvAlm] = @AV9AlmCod) AND (T2.[MvAFec] <= @AV77FHasta) ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FM7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FM8", "SELECT [ComDProCod], [ComDOrdCod], [ComCod], [TipCod], [PrvCod], [ComDItem] FROM [CPCOMPRASDET] WHERE ([ComDProCod] = @AV36ProdCodC) AND ([ComDOrdCod] = @AV51OC) ORDER BY [ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FM8,100, GxCacheFrequency.OFF ,false,false )
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
