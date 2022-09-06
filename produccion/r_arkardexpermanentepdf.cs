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
   public class r_arkardexpermanentepdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "produccion.r_arkardexpermanentepdf.aspx")), "produccion.r_arkardexpermanentepdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "produccion.r_arkardexpermanentepdf.aspx")))) ;
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
               AV40LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV63SublCod = (int)(NumberUtil.Val( GetPar( "SublCod"), "."));
                  AV28FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AV9AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
                  AV49Prodcod = GetPar( "Prodcod");
                  AV29FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV31FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
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

      public r_arkardexpermanentepdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_arkardexpermanentepdf( IGxContext context )
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
         this.AV40LinCod = aP0_LinCod;
         this.AV63SublCod = aP1_SublCod;
         this.AV28FamCod = aP2_FamCod;
         this.AV9AlmCod = aP3_AlmCod;
         this.AV49Prodcod = aP4_Prodcod;
         this.AV29FDesde = aP5_FDesde;
         this.AV31FHasta = aP6_FHasta;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV40LinCod;
         aP1_SublCod=this.AV63SublCod;
         aP2_FamCod=this.AV28FamCod;
         aP3_AlmCod=this.AV9AlmCod;
         aP4_Prodcod=this.AV49Prodcod;
         aP5_FDesde=this.AV29FDesde;
         aP6_FHasta=this.AV31FHasta;
      }

      public DateTime executeUdp( ref int aP0_LinCod ,
                                  ref int aP1_SublCod ,
                                  ref int aP2_FamCod ,
                                  ref int aP3_AlmCod ,
                                  ref string aP4_Prodcod ,
                                  ref DateTime aP5_FDesde )
      {
         execute(ref aP0_LinCod, ref aP1_SublCod, ref aP2_FamCod, ref aP3_AlmCod, ref aP4_Prodcod, ref aP5_FDesde, ref aP6_FHasta);
         return AV31FHasta ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SublCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_AlmCod ,
                                 ref string aP4_Prodcod ,
                                 ref DateTime aP5_FDesde ,
                                 ref DateTime aP6_FHasta )
      {
         r_arkardexpermanentepdf objr_arkardexpermanentepdf;
         objr_arkardexpermanentepdf = new r_arkardexpermanentepdf();
         objr_arkardexpermanentepdf.AV40LinCod = aP0_LinCod;
         objr_arkardexpermanentepdf.AV63SublCod = aP1_SublCod;
         objr_arkardexpermanentepdf.AV28FamCod = aP2_FamCod;
         objr_arkardexpermanentepdf.AV9AlmCod = aP3_AlmCod;
         objr_arkardexpermanentepdf.AV49Prodcod = aP4_Prodcod;
         objr_arkardexpermanentepdf.AV29FDesde = aP5_FDesde;
         objr_arkardexpermanentepdf.AV31FHasta = aP6_FHasta;
         objr_arkardexpermanentepdf.context.SetSubmitInitialConfig(context);
         objr_arkardexpermanentepdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_arkardexpermanentepdf);
         aP0_LinCod=this.AV40LinCod;
         aP1_SublCod=this.AV63SublCod;
         aP2_FamCod=this.AV28FamCod;
         aP3_AlmCod=this.AV9AlmCod;
         aP4_Prodcod=this.AV49Prodcod;
         aP5_FDesde=this.AV29FDesde;
         aP6_FHasta=this.AV31FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_arkardexpermanentepdf)stateInfo).executePrivate();
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
            AV26Empresa = AV62Session.Get("Empresa");
            AV25EmpDir = AV62Session.Get("EmpDir");
            AV27EmpRUC = AV62Session.Get("EmpRUC");
            AV52Ruta = AV62Session.Get("RUTA") + "/Logo.jpg";
            AV41Logo = AV52Ruta;
            AV93Logo_GXI = GXDbFile.PathToUrl( AV52Ruta);
            AV89UsuCod = AV62Session.Get("UsuCod");
            AV71Titulo = "Registro de Inventario Permanente Valorizado";
            /* Using cursor P00FR2 */
            pr_default.execute(0, new Object[] {AV9AlmCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A63AlmCod = P00FR2_A63AlmCod[0];
               A436AlmDsc = P00FR2_A436AlmDsc[0];
               AV8Almacen = A436AlmDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV32Filtro1 = "";
            AV33Filtro2 = "";
            AV72Titulo2 = "Metodo de valuación promedio";
            /* Using cursor P00FR3 */
            pr_default.execute(1, new Object[] {AV40LinCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A52LinCod = P00FR3_A52LinCod[0];
               A1153LinDsc = P00FR3_A1153LinDsc[0];
               AV32Filtro1 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00FR4 */
            pr_default.execute(2, new Object[] {AV49Prodcod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A28ProdCod = P00FR4_A28ProdCod[0];
               A55ProdDsc = P00FR4_A55ProdDsc[0];
               AV33Filtro2 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            AV73Tot1 = 0;
            AV74Tot2 = 0;
            AV75Tot3 = 0;
            AV76Tot4 = 0;
            AV77Tot5 = 0;
            AV78Tot6 = 0;
            AV79Tot7 = 0;
            AV80Tot8 = 0;
            AV81Tot9 = 0;
            AV19CostoTotal = 0;
            AV60SaldoFinal = 0;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV40LinCod ,
                                                 AV63SublCod ,
                                                 AV28FamCod ,
                                                 AV49Prodcod ,
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
            /* Using cursor P00FR5 */
            pr_default.execute(3, new Object[] {AV9AlmCod, AV40LinCod, AV63SublCod, AV28FamCod, AV49Prodcod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               BRKFR6 = false;
               A13MvATip = P00FR5_A13MvATip[0];
               A14MvACod = P00FR5_A14MvACod[0];
               A49UniCod = P00FR5_A49UniCod[0];
               A55ProdDsc = P00FR5_A55ProdDsc[0];
               A28ProdCod = P00FR5_A28ProdCod[0];
               A1269MvAlmCos = P00FR5_A1269MvAlmCos[0];
               A1158LinStk = P00FR5_A1158LinStk[0];
               A21MvAlm = P00FR5_A21MvAlm[0];
               A50FamCod = P00FR5_A50FamCod[0];
               n50FamCod = P00FR5_n50FamCod[0];
               A51SublCod = P00FR5_A51SublCod[0];
               n51SublCod = P00FR5_n51SublCod[0];
               A52LinCod = P00FR5_A52LinCod[0];
               A1997UniAbr = P00FR5_A1997UniAbr[0];
               A30MvADItem = P00FR5_A30MvADItem[0];
               A21MvAlm = P00FR5_A21MvAlm[0];
               A1269MvAlmCos = P00FR5_A1269MvAlmCos[0];
               A49UniCod = P00FR5_A49UniCod[0];
               A55ProdDsc = P00FR5_A55ProdDsc[0];
               A50FamCod = P00FR5_A50FamCod[0];
               n50FamCod = P00FR5_n50FamCod[0];
               A51SublCod = P00FR5_A51SublCod[0];
               n51SublCod = P00FR5_n51SublCod[0];
               A52LinCod = P00FR5_A52LinCod[0];
               A1997UniAbr = P00FR5_A1997UniAbr[0];
               A1158LinStk = P00FR5_A1158LinStk[0];
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00FR5_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRKFR6 = false;
                  A13MvATip = P00FR5_A13MvATip[0];
                  A14MvACod = P00FR5_A14MvACod[0];
                  A55ProdDsc = P00FR5_A55ProdDsc[0];
                  A30MvADItem = P00FR5_A30MvADItem[0];
                  A55ProdDsc = P00FR5_A55ProdDsc[0];
                  BRKFR6 = true;
                  pr_default.readNext(3);
               }
               AV50ProdCodC = StringUtil.Trim( A28ProdCod);
               AV51Producto = A55ProdDsc;
               AV88UniAbr = A1997UniAbr;
               AV10CanIni = 0;
               AV64TCosIni = 0;
               AV65TCosTIni = 0;
               AV36Ing1 = 0;
               AV38IngCU = 0;
               AV37IngCT = 0;
               AV86TTIngreso = 0;
               AV69TIngresoCT = 0;
               AV70TIngresoCU = 0;
               AV53Sal1 = 0;
               AV55SalCU = 0;
               AV54SalCT = 0;
               AV87TTSalida = 0;
               AV84TsalidaCT = 0;
               AV85TSalidaCU = 0;
               AV34Final = 0;
               new GeneXus.Programs.contabilidad.paobtenersaldocostoproductofechas(context ).execute( ref  AV29FDesde, ref  AV9AlmCod, ref  AV50ProdCodC, out  AV58Saldo, out  AV20CostoU) ;
               AV18CostoT = NumberUtil.Round( AV58Saldo*AV20CostoU, 2);
               AV66TCosto = AV18CostoT;
               AV34Final = AV58Saldo;
               /* Execute user subroutine: 'VALIDA' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  this.cleanup();
                  if (true) return;
               }
               AV39Ingresa = 0;
               AV61Salida = 0;
               AV14Ceros = 0;
               AV68TIngreso = ((AV58Saldo>Convert.ToDecimal(0)) ? AV58Saldo : (decimal)(0));
               AV83TSalida = ((AV58Saldo<Convert.ToDecimal(0)) ? AV58Saldo : (decimal)(0));
               AV21CostoUAnt = AV20CostoU;
               if ( ( AV58Saldo != Convert.ToDecimal( 0 )) )
               {
                  AV10CanIni = AV68TIngreso;
                  AV64TCosIni = AV21CostoUAnt;
                  AV65TCosTIni = NumberUtil.Round( AV10CanIni*AV64TCosIni, 2);
               }
               /* Execute user subroutine: 'DETALLEMOVIMIENTO' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  this.cleanup();
                  if (true) return;
               }
               if ( ( AV34Final == Convert.ToDecimal( 0 )) )
               {
                  AV20CostoU = 0;
                  AV18CostoT = 0;
               }
               if ( ( AV35Flag == 0 ) || ( AV58Saldo != Convert.ToDecimal( 0 )) )
               {
                  HFR0( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34Final, "ZZZZ,ZZZ,ZZ9.9999")), 903, Gx_line+3, 993, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18CostoT, "ZZZZZZ,ZZZ,ZZ9.99")), 961, Gx_line+3, 1051, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20CostoU, "ZZZZ,ZZZ,ZZ9.9999")), 1017, Gx_line+3, 1107, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV86TTIngreso, "ZZZZ,ZZZ,ZZ9.9999")), 555, Gx_line+3, 645, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69TIngresoCT, "ZZZZZZ,ZZZ,ZZ9.99")), 668, Gx_line+3, 758, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV84TsalidaCT, "ZZZZZZ,ZZZ,ZZ9.99")), 842, Gx_line+3, 932, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87TTSalida, "ZZZZ,ZZZ,ZZ9.9999")), 729, Gx_line+3, 819, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV10CanIni, "ZZZZ,ZZZ,ZZ9.9999")), 369, Gx_line+4, 459, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TCosIni, "ZZZZ,ZZZ,ZZ9.9999")), 429, Gx_line+4, 519, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TCosTIni, "ZZZZZZ,ZZZ,ZZ9.99")), 495, Gx_line+4, 585, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70TIngresoCU, "ZZZZ,ZZZ,ZZ9.9999")), 615, Gx_line+3, 705, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85TSalidaCU, "ZZZZ,ZZZ,ZZ9.9999")), 785, Gx_line+3, 875, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Producto, "")), 76, Gx_line+4, 362, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV88UniAbr, "")), 368, Gx_line+4, 395, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50ProdCodC, "@!")), 5, Gx_line+4, 69, Gx_line+17, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
               }
               AV73Tot1 = (decimal)(AV73Tot1+AV86TTIngreso);
               AV74Tot2 = (decimal)(AV74Tot2+AV70TIngresoCU);
               AV75Tot3 = (decimal)(AV75Tot3+AV69TIngresoCT);
               AV76Tot4 = (decimal)(AV76Tot4+AV87TTSalida);
               AV77Tot5 = (decimal)(AV77Tot5+AV85TSalidaCU);
               AV78Tot6 = (decimal)(AV78Tot6+AV84TsalidaCT);
               AV79Tot7 = (decimal)(AV79Tot7+AV10CanIni);
               AV81Tot9 = (decimal)(AV81Tot9+AV65TCosTIni);
               AV80Tot8 = (decimal)(AV80Tot8+(((AV79Tot7==Convert.ToDecimal(0)) ? (decimal)(0) : ((AV10CanIni==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( AV65TCosTIni/ (decimal)(AV10CanIni), 2)))));
               AV60SaldoFinal = (decimal)(AV60SaldoFinal+AV34Final);
               AV19CostoTotal = (decimal)(AV19CostoTotal+AV18CostoT);
               if ( ! BRKFR6 )
               {
                  BRKFR6 = true;
                  pr_default.readNext(3);
               }
            }
            pr_default.close(3);
            HFR0( false, 55) ;
            getPrinter().GxDrawLine(402, Gx_line+13, 1108, Gx_line+13, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Costo Total", 296, Gx_line+23, 356, Gx_line+36, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19CostoTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 1017, Gx_line+23, 1107, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60SaldoFinal, "ZZZZ,ZZZ,ZZ9.9999")), 903, Gx_line+23, 993, Gx_line+36, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+55);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HFR0( true, 0) ;
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
         AV35Flag = 1;
         /* Using cursor P00FR6 */
         pr_default.execute(4, new Object[] {AV29FDesde, AV50ProdCodC, AV9AlmCod, AV31FHasta});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A28ProdCod = P00FR6_A28ProdCod[0];
            A21MvAlm = P00FR6_A21MvAlm[0];
            A1370MVSts = P00FR6_A1370MVSts[0];
            A25MvAFec = P00FR6_A25MvAFec[0];
            A14MvACod = P00FR6_A14MvACod[0];
            A13MvATip = P00FR6_A13MvATip[0];
            A30MvADItem = P00FR6_A30MvADItem[0];
            A21MvAlm = P00FR6_A21MvAlm[0];
            A1370MVSts = P00FR6_A1370MVSts[0];
            A25MvAFec = P00FR6_A25MvAFec[0];
            AV35Flag = 0;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S121( )
      {
         /* 'DETALLEMOVIMIENTO' Routine */
         returnInSub = false;
         /* Using cursor P00FR7 */
         pr_default.execute(5, new Object[] {AV29FDesde, AV50ProdCodC, AV9AlmCod, AV31FHasta});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A22MvAMov = P00FR7_A22MvAMov[0];
            A28ProdCod = P00FR7_A28ProdCod[0];
            A21MvAlm = P00FR7_A21MvAlm[0];
            A1370MVSts = P00FR7_A1370MVSts[0];
            A25MvAFec = P00FR7_A25MvAFec[0];
            A1278MvARef = P00FR7_A1278MvARef[0];
            A1276MvAOcom = P00FR7_A1276MvAOcom[0];
            A24DocNum = P00FR7_A24DocNum[0];
            n24DocNum = P00FR7_n24DocNum[0];
            A1248MvADCant = P00FR7_A1248MvADCant[0];
            A1237MovAbr = P00FR7_A1237MovAbr[0];
            n1237MovAbr = P00FR7_n1237MovAbr[0];
            A1250MVADPrecio = P00FR7_A1250MVADPrecio[0];
            A1249MVADCosto = P00FR7_A1249MVADCosto[0];
            A14MvACod = P00FR7_A14MvACod[0];
            A13MvATip = P00FR7_A13MvATip[0];
            A30MvADItem = P00FR7_A30MvADItem[0];
            A22MvAMov = P00FR7_A22MvAMov[0];
            A21MvAlm = P00FR7_A21MvAlm[0];
            A1370MVSts = P00FR7_A1370MVSts[0];
            A25MvAFec = P00FR7_A25MvAFec[0];
            A1278MvARef = P00FR7_A1278MvARef[0];
            A1276MvAOcom = P00FR7_A1276MvAOcom[0];
            A24DocNum = P00FR7_A24DocNum[0];
            n24DocNum = P00FR7_n24DocNum[0];
            A1237MovAbr = P00FR7_A1237MovAbr[0];
            n1237MovAbr = P00FR7_n1237MovAbr[0];
            AV46MVATip = A13MvATip;
            AV43MVACod = A14MvACod;
            AV24DocRef = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? (String.IsNullOrEmpty(StringUtil.RTrim( A1276MvAOcom)) ? A1278MvARef : A1276MvAOcom) : A24DocNum);
            AV39Ingresa = ((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1248MvADCant : (decimal)(0));
            AV61Salida = ((StringUtil.StrCmp(A13MvATip, "ING")!=0) ? A1248MvADCant : (decimal)(0));
            AV20CostoU = 0;
            AV18CostoT = 0;
            AV42MovAbr = A1237MovAbr;
            AV36Ing1 = 0;
            AV38IngCU = 0;
            AV37IngCT = 0;
            AV53Sal1 = 0;
            AV55SalCU = 0;
            AV54SalCT = 0;
            if ( StringUtil.StrCmp(A13MvATip, "ING") == 0 )
            {
               AV20CostoU = A1250MVADPrecio;
               AV18CostoT = A1249MVADCosto;
               AV66TCosto = (decimal)(AV66TCosto+AV18CostoT);
               AV21CostoUAnt = 0;
               AV36Ing1 = AV39Ingresa;
               AV38IngCU = AV20CostoU;
               AV37IngCT = AV18CostoT;
            }
            else
            {
               if ( ! (Convert.ToDecimal(0)==AV21CostoUAnt) )
               {
                  AV20CostoU = AV21CostoUAnt;
               }
               else
               {
                  if ( ( AV34Final <= Convert.ToDecimal( 0 )) )
                  {
                     AV20CostoU = 0;
                  }
                  else
                  {
                     AV20CostoU = NumberUtil.Round( AV66TCosto/ (decimal)(AV34Final), 4);
                  }
               }
               AV18CostoT = NumberUtil.Round( AV20CostoU*AV61Salida, 2);
               AV66TCosto = (decimal)(AV66TCosto+((AV18CostoT*-1)));
               AV21CostoUAnt = AV20CostoU;
               AV53Sal1 = AV61Salida;
               AV55SalCU = AV20CostoU;
               AV54SalCT = AV18CostoT;
            }
            AV86TTIngreso = (decimal)(AV86TTIngreso+AV36Ing1);
            AV69TIngresoCT = (decimal)(AV69TIngresoCT+AV37IngCT);
            AV70TIngresoCU = ((AV86TTIngreso>Convert.ToDecimal(0)) ? NumberUtil.Round( AV69TIngresoCT/ (decimal)(AV86TTIngreso), 6) : (decimal)(0));
            AV87TTSalida = (decimal)(AV87TTSalida+AV53Sal1);
            AV84TsalidaCT = (decimal)(AV84TsalidaCT+AV54SalCT);
            AV85TSalidaCU = ((AV87TTSalida>Convert.ToDecimal(0)) ? NumberUtil.Round( AV84TsalidaCT/ (decimal)(AV87TTSalida), 6) : (decimal)(0));
            AV34Final = (decimal)(AV34Final+((AV39Ingresa-AV61Salida)));
            AV68TIngreso = (decimal)(AV68TIngreso+AV39Ingresa);
            AV83TSalida = (decimal)(AV83TSalida+AV61Salida);
            if ( ! (Convert.ToDecimal(0)==AV21CostoUAnt) )
            {
               AV20CostoU = AV21CostoUAnt;
            }
            else
            {
               if ( ( AV34Final <= Convert.ToDecimal( 0 )) )
               {
                  AV20CostoU = 0;
               }
               else
               {
                  AV20CostoU = NumberUtil.Round( AV66TCosto/ (decimal)(AV34Final), 4);
               }
            }
            AV18CostoT = NumberUtil.Round( AV20CostoU*AV34Final, 2);
            AV66TCosto = AV18CostoT;
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void HFR0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 1004, Gx_line+22, 1036, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 993, Gx_line+40, 1037, Gx_line+54, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1044, Gx_line+40, 1083, Gx_line+55, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1044, Gx_line+22, 1085, Gx_line+36, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8Almacen, "")), 331, Gx_line+25, 840, Gx_line+50, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+136, 1111, Gx_line+181, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descripción del Producto", 80, Gx_line+153, 209, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Codigo", 17, Gx_line+153, 53, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 598, Gx_line+166, 645, Gx_line+179, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Linea :", 332, Gx_line+71, 375, Gx_line+86, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto :", 332, Gx_line+91, 401, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde : ", 332, Gx_line+113, 384, Gx_line+128, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32Filtro1, "")), 413, Gx_line+66, 778, Gx_line+90, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Filtro2, "")), 413, Gx_line+85, 778, Gx_line+109, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV29FDesde, "99/99/99"), 413, Gx_line+107, 481, Gx_line+131, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta :", 538, Gx_line+113, 584, Gx_line+128, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV31FHasta, "99/99/99"), 619, Gx_line+107, 715, Gx_line+131, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71Titulo, "")), 331, Gx_line+4, 838, Gx_line+29, 1, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV41Logo)) ? AV93Logo_GXI : AV41Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+3, 175, Gx_line+80) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Empresa, "")), 9, Gx_line+82, 317, Gx_line+100, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27EmpRUC, "")), 9, Gx_line+100, 179, Gx_line+118, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(589, Gx_line+136, 589, Gx_line+181, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(759, Gx_line+136, 759, Gx_line+181, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
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
               getPrinter().GxDrawText("Usuario :", 984, Gx_line+57, 1036, Gx_line+71, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV89UsuCod, "")), 1044, Gx_line+57, 1097, Gx_line+72, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Medida", 363, Gx_line+153, 402, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72Titulo2, "")), 331, Gx_line+46, 840, Gx_line+71, 1, 0, 0, 0) ;
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
         AV26Empresa = "";
         AV62Session = context.GetSession();
         AV25EmpDir = "";
         AV27EmpRUC = "";
         AV52Ruta = "";
         AV41Logo = "";
         AV93Logo_GXI = "";
         AV89UsuCod = "";
         AV71Titulo = "";
         scmdbuf = "";
         P00FR2_A63AlmCod = new int[1] ;
         P00FR2_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         AV8Almacen = "";
         AV32Filtro1 = "";
         AV33Filtro2 = "";
         AV72Titulo2 = "";
         P00FR3_A52LinCod = new int[1] ;
         P00FR3_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P00FR4_A28ProdCod = new string[] {""} ;
         P00FR4_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P00FR5_A13MvATip = new string[] {""} ;
         P00FR5_A14MvACod = new string[] {""} ;
         P00FR5_A49UniCod = new int[1] ;
         P00FR5_A55ProdDsc = new string[] {""} ;
         P00FR5_A28ProdCod = new string[] {""} ;
         P00FR5_A1269MvAlmCos = new short[1] ;
         P00FR5_A1158LinStk = new short[1] ;
         P00FR5_A21MvAlm = new int[1] ;
         P00FR5_A50FamCod = new int[1] ;
         P00FR5_n50FamCod = new bool[] {false} ;
         P00FR5_A51SublCod = new int[1] ;
         P00FR5_n51SublCod = new bool[] {false} ;
         P00FR5_A52LinCod = new int[1] ;
         P00FR5_A1997UniAbr = new string[] {""} ;
         P00FR5_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A1997UniAbr = "";
         AV50ProdCodC = "";
         AV51Producto = "";
         AV88UniAbr = "";
         P00FR6_A28ProdCod = new string[] {""} ;
         P00FR6_A21MvAlm = new int[1] ;
         P00FR6_A1370MVSts = new string[] {""} ;
         P00FR6_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FR6_A14MvACod = new string[] {""} ;
         P00FR6_A13MvATip = new string[] {""} ;
         P00FR6_A30MvADItem = new int[1] ;
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         P00FR7_A22MvAMov = new int[1] ;
         P00FR7_A28ProdCod = new string[] {""} ;
         P00FR7_A21MvAlm = new int[1] ;
         P00FR7_A1370MVSts = new string[] {""} ;
         P00FR7_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00FR7_A1278MvARef = new string[] {""} ;
         P00FR7_A1276MvAOcom = new string[] {""} ;
         P00FR7_A24DocNum = new string[] {""} ;
         P00FR7_n24DocNum = new bool[] {false} ;
         P00FR7_A1248MvADCant = new decimal[1] ;
         P00FR7_A1237MovAbr = new string[] {""} ;
         P00FR7_n1237MovAbr = new bool[] {false} ;
         P00FR7_A1250MVADPrecio = new decimal[1] ;
         P00FR7_A1249MVADCosto = new decimal[1] ;
         P00FR7_A14MvACod = new string[] {""} ;
         P00FR7_A13MvATip = new string[] {""} ;
         P00FR7_A30MvADItem = new int[1] ;
         A1278MvARef = "";
         A1276MvAOcom = "";
         A24DocNum = "";
         A1237MovAbr = "";
         AV46MVATip = "";
         AV43MVACod = "";
         AV24DocRef = "";
         AV42MovAbr = "";
         Gx_time = "";
         AV41Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_arkardexpermanentepdf__default(),
            new Object[][] {
                new Object[] {
               P00FR2_A63AlmCod, P00FR2_A436AlmDsc
               }
               , new Object[] {
               P00FR3_A52LinCod, P00FR3_A1153LinDsc
               }
               , new Object[] {
               P00FR4_A28ProdCod, P00FR4_A55ProdDsc
               }
               , new Object[] {
               P00FR5_A13MvATip, P00FR5_A14MvACod, P00FR5_A49UniCod, P00FR5_A55ProdDsc, P00FR5_A28ProdCod, P00FR5_A1269MvAlmCos, P00FR5_A1158LinStk, P00FR5_A21MvAlm, P00FR5_A50FamCod, P00FR5_n50FamCod,
               P00FR5_A51SublCod, P00FR5_n51SublCod, P00FR5_A52LinCod, P00FR5_A1997UniAbr, P00FR5_A30MvADItem
               }
               , new Object[] {
               P00FR6_A28ProdCod, P00FR6_A21MvAlm, P00FR6_A1370MVSts, P00FR6_A25MvAFec, P00FR6_A14MvACod, P00FR6_A13MvATip, P00FR6_A30MvADItem
               }
               , new Object[] {
               P00FR7_A22MvAMov, P00FR7_A28ProdCod, P00FR7_A21MvAlm, P00FR7_A1370MVSts, P00FR7_A25MvAFec, P00FR7_A1278MvARef, P00FR7_A1276MvAOcom, P00FR7_A24DocNum, P00FR7_n24DocNum, P00FR7_A1248MvADCant,
               P00FR7_A1237MovAbr, P00FR7_n1237MovAbr, P00FR7_A1250MVADPrecio, P00FR7_A1249MVADCosto, P00FR7_A14MvACod, P00FR7_A13MvATip, P00FR7_A30MvADItem
               }
            }
         );
         Gx_time = context.localUtil.Time( );
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_time = context.localUtil.Time( );
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short A1158LinStk ;
      private short A1269MvAlmCos ;
      private short AV35Flag ;
      private int AV40LinCod ;
      private int AV63SublCod ;
      private int AV28FamCod ;
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
      private decimal AV73Tot1 ;
      private decimal AV74Tot2 ;
      private decimal AV75Tot3 ;
      private decimal AV76Tot4 ;
      private decimal AV77Tot5 ;
      private decimal AV78Tot6 ;
      private decimal AV79Tot7 ;
      private decimal AV80Tot8 ;
      private decimal AV81Tot9 ;
      private decimal AV19CostoTotal ;
      private decimal AV60SaldoFinal ;
      private decimal AV10CanIni ;
      private decimal AV64TCosIni ;
      private decimal AV65TCosTIni ;
      private decimal AV36Ing1 ;
      private decimal AV38IngCU ;
      private decimal AV37IngCT ;
      private decimal AV86TTIngreso ;
      private decimal AV69TIngresoCT ;
      private decimal AV70TIngresoCU ;
      private decimal AV53Sal1 ;
      private decimal AV55SalCU ;
      private decimal AV54SalCT ;
      private decimal AV87TTSalida ;
      private decimal AV84TsalidaCT ;
      private decimal AV85TSalidaCU ;
      private decimal AV34Final ;
      private decimal AV58Saldo ;
      private decimal AV20CostoU ;
      private decimal AV18CostoT ;
      private decimal AV66TCosto ;
      private decimal AV39Ingresa ;
      private decimal AV61Salida ;
      private decimal AV14Ceros ;
      private decimal AV68TIngreso ;
      private decimal AV83TSalida ;
      private decimal AV21CostoUAnt ;
      private decimal A1248MvADCant ;
      private decimal A1250MVADPrecio ;
      private decimal A1249MVADCosto ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV49Prodcod ;
      private string AV26Empresa ;
      private string AV25EmpDir ;
      private string AV27EmpRUC ;
      private string AV52Ruta ;
      private string AV89UsuCod ;
      private string AV71Titulo ;
      private string scmdbuf ;
      private string A436AlmDsc ;
      private string AV8Almacen ;
      private string AV32Filtro1 ;
      private string AV33Filtro2 ;
      private string AV72Titulo2 ;
      private string A1153LinDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string A1997UniAbr ;
      private string AV50ProdCodC ;
      private string AV51Producto ;
      private string AV88UniAbr ;
      private string A1370MVSts ;
      private string A1278MvARef ;
      private string A1276MvAOcom ;
      private string A24DocNum ;
      private string A1237MovAbr ;
      private string AV46MVATip ;
      private string AV43MVACod ;
      private string AV24DocRef ;
      private string AV42MovAbr ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV29FDesde ;
      private DateTime AV31FHasta ;
      private DateTime A25MvAFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKFR6 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private bool n24DocNum ;
      private bool n1237MovAbr ;
      private string AV93Logo_GXI ;
      private string AV41Logo ;
      private string Logo ;
      private IGxSession AV62Session ;
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
      private int[] P00FR2_A63AlmCod ;
      private string[] P00FR2_A436AlmDsc ;
      private int[] P00FR3_A52LinCod ;
      private string[] P00FR3_A1153LinDsc ;
      private string[] P00FR4_A28ProdCod ;
      private string[] P00FR4_A55ProdDsc ;
      private string[] P00FR5_A13MvATip ;
      private string[] P00FR5_A14MvACod ;
      private int[] P00FR5_A49UniCod ;
      private string[] P00FR5_A55ProdDsc ;
      private string[] P00FR5_A28ProdCod ;
      private short[] P00FR5_A1269MvAlmCos ;
      private short[] P00FR5_A1158LinStk ;
      private int[] P00FR5_A21MvAlm ;
      private int[] P00FR5_A50FamCod ;
      private bool[] P00FR5_n50FamCod ;
      private int[] P00FR5_A51SublCod ;
      private bool[] P00FR5_n51SublCod ;
      private int[] P00FR5_A52LinCod ;
      private string[] P00FR5_A1997UniAbr ;
      private int[] P00FR5_A30MvADItem ;
      private string[] P00FR6_A28ProdCod ;
      private int[] P00FR6_A21MvAlm ;
      private string[] P00FR6_A1370MVSts ;
      private DateTime[] P00FR6_A25MvAFec ;
      private string[] P00FR6_A14MvACod ;
      private string[] P00FR6_A13MvATip ;
      private int[] P00FR6_A30MvADItem ;
      private int[] P00FR7_A22MvAMov ;
      private string[] P00FR7_A28ProdCod ;
      private int[] P00FR7_A21MvAlm ;
      private string[] P00FR7_A1370MVSts ;
      private DateTime[] P00FR7_A25MvAFec ;
      private string[] P00FR7_A1278MvARef ;
      private string[] P00FR7_A1276MvAOcom ;
      private string[] P00FR7_A24DocNum ;
      private bool[] P00FR7_n24DocNum ;
      private decimal[] P00FR7_A1248MvADCant ;
      private string[] P00FR7_A1237MovAbr ;
      private bool[] P00FR7_n1237MovAbr ;
      private decimal[] P00FR7_A1250MVADPrecio ;
      private decimal[] P00FR7_A1249MVADCosto ;
      private string[] P00FR7_A14MvACod ;
      private string[] P00FR7_A13MvATip ;
      private int[] P00FR7_A30MvADItem ;
   }

   public class r_arkardexpermanentepdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FR5( IGxContext context ,
                                             int AV40LinCod ,
                                             int AV63SublCod ,
                                             int AV28FamCod ,
                                             string AV49Prodcod ,
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
         if ( ! (0==AV40LinCod) )
         {
            AddWhere(sWhereString, "(T4.[LinCod] = @AV40LinCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV63SublCod) )
         {
            AddWhere(sWhereString, "(T4.[SublCod] = @AV63SublCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV28FamCod) )
         {
            AddWhere(sWhereString, "(T4.[FamCod] = @AV28FamCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV49Prodcod)");
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
                     return conditional_P00FR5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
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
          Object[] prmP00FR2;
          prmP00FR2 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP00FR3;
          prmP00FR3 = new Object[] {
          new ParDef("@AV40LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00FR4;
          prmP00FR4 = new Object[] {
          new ParDef("@AV49Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00FR6;
          prmP00FR6 = new Object[] {
          new ParDef("@AV29FDesde",GXType.Date,8,0) ,
          new ParDef("@AV50ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV31FHasta",GXType.Date,8,0)
          };
          Object[] prmP00FR7;
          prmP00FR7 = new Object[] {
          new ParDef("@AV29FDesde",GXType.Date,8,0) ,
          new ParDef("@AV50ProdCodC",GXType.NChar,15,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV31FHasta",GXType.Date,8,0)
          };
          Object[] prmP00FR5;
          prmP00FR5 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV40LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV63SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV28FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV49Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FR2", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV9AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FR2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FR3", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV40LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FR3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FR4", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV49Prodcod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FR4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FR5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FR5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FR6", "SELECT TOP 1 T1.[ProdCod], T2.[MvAlm] AS MvAlm, T2.[MVSts], T2.[MvAFec], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T2.[MvAFec] >= @AV29FDesde) AND (T2.[MVSts] <> 'A') AND (T1.[ProdCod] = @AV50ProdCodC) AND (T2.[MvAlm] = @AV9AlmCod) AND (T2.[MvAFec] <= @AV31FHasta) ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FR6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FR7", "SELECT T2.[MvAMov] AS MvAMov, T1.[ProdCod], T2.[MvAlm] AS MvAlm, T2.[MVSts], T2.[MvAFec], T2.[MvARef], T2.[MvAOcom], T2.[DocNum], T1.[MvADCant], T3.[MovAbr], T1.[MVADPrecio], T1.[MVADCosto], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM (([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T3 ON T3.[MovCod] = T2.[MvAMov]) WHERE (T2.[MvAFec] >= @AV29FDesde) AND (T2.[MVSts] <> 'A') AND (T1.[ProdCod] = @AV50ProdCodC) AND (T2.[MvAlm] = @AV9AlmCod) AND (T2.[MvAFec] <= @AV31FHasta) ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FR7,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 12);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((string[]) buf[7])[0] = rslt.getString(8, 12);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 5);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 12);
                ((string[]) buf[15])[0] = rslt.getString(14, 3);
                ((int[]) buf[16])[0] = rslt.getInt(15);
                return;
       }
    }

 }

}
