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
namespace GeneXus.Programs {
   public class rrkardexlotes : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrkardexlotes.aspx")), "rrkardexlotes.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrkardexlotes.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "AlmCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV9AlmCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10Prodcod = GetPar( "Prodcod");
                  AV13cDesde = context.localUtil.ParseDateParm( GetPar( "cDesde"));
                  AV14cHasta = context.localUtil.ParseDateParm( GetPar( "cHasta"));
                  AV49Lote = GetPar( "Lote");
                  AV53Tipo = GetPar( "Tipo");
                  AV40CliCod = GetPar( "CliCod");
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

      public rrkardexlotes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrkardexlotes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_AlmCod ,
                           ref string aP1_Prodcod ,
                           ref DateTime aP2_cDesde ,
                           ref DateTime aP3_cHasta ,
                           ref string aP4_Lote ,
                           ref string aP5_Tipo ,
                           ref string aP6_CliCod )
      {
         this.AV9AlmCod = aP0_AlmCod;
         this.AV10Prodcod = aP1_Prodcod;
         this.AV13cDesde = aP2_cDesde;
         this.AV14cHasta = aP3_cHasta;
         this.AV49Lote = aP4_Lote;
         this.AV53Tipo = aP5_Tipo;
         this.AV40CliCod = aP6_CliCod;
         initialize();
         executePrivate();
         aP0_AlmCod=this.AV9AlmCod;
         aP1_Prodcod=this.AV10Prodcod;
         aP2_cDesde=this.AV13cDesde;
         aP3_cHasta=this.AV14cHasta;
         aP4_Lote=this.AV49Lote;
         aP5_Tipo=this.AV53Tipo;
         aP6_CliCod=this.AV40CliCod;
      }

      public string executeUdp( ref int aP0_AlmCod ,
                                ref string aP1_Prodcod ,
                                ref DateTime aP2_cDesde ,
                                ref DateTime aP3_cHasta ,
                                ref string aP4_Lote ,
                                ref string aP5_Tipo )
      {
         execute(ref aP0_AlmCod, ref aP1_Prodcod, ref aP2_cDesde, ref aP3_cHasta, ref aP4_Lote, ref aP5_Tipo, ref aP6_CliCod);
         return AV40CliCod ;
      }

      public void executeSubmit( ref int aP0_AlmCod ,
                                 ref string aP1_Prodcod ,
                                 ref DateTime aP2_cDesde ,
                                 ref DateTime aP3_cHasta ,
                                 ref string aP4_Lote ,
                                 ref string aP5_Tipo ,
                                 ref string aP6_CliCod )
      {
         rrkardexlotes objrrkardexlotes;
         objrrkardexlotes = new rrkardexlotes();
         objrrkardexlotes.AV9AlmCod = aP0_AlmCod;
         objrrkardexlotes.AV10Prodcod = aP1_Prodcod;
         objrrkardexlotes.AV13cDesde = aP2_cDesde;
         objrrkardexlotes.AV14cHasta = aP3_cHasta;
         objrrkardexlotes.AV49Lote = aP4_Lote;
         objrrkardexlotes.AV53Tipo = aP5_Tipo;
         objrrkardexlotes.AV40CliCod = aP6_CliCod;
         objrrkardexlotes.context.SetSubmitInitialConfig(context);
         objrrkardexlotes.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrkardexlotes);
         aP0_AlmCod=this.AV9AlmCod;
         aP1_Prodcod=this.AV10Prodcod;
         aP2_cDesde=this.AV13cDesde;
         aP3_cHasta=this.AV14cHasta;
         aP4_Lote=this.AV49Lote;
         aP5_Tipo=this.AV53Tipo;
         aP6_CliCod=this.AV40CliCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrkardexlotes)stateInfo).executePrivate();
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
            AV27Empresa = AV32Session.Get("Empresa");
            AV28EmpDir = AV32Session.Get("EmpDir");
            AV29EmpRUC = AV32Session.Get("EmpRUC");
            AV30Ruta = AV32Session.Get("RUTA") + "/Logo.jpg";
            AV31Logo = AV30Ruta;
            AV56Logo_GXI = GXDbFile.PathToUrl( AV30Ruta);
            AV48FMT = "FMT-GO-AL-07";
            AV12Titulo = "Kardex por producto lotes";
            /* Using cursor P008P2 */
            pr_default.execute(0, new Object[] {AV9AlmCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A63AlmCod = P008P2_A63AlmCod[0];
               A436AlmDsc = P008P2_A436AlmDsc[0];
               AV11Almacen = A436AlmDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV22Filtro1 = "";
            AV24Filtro2 = "";
            /* Using cursor P008P3 */
            pr_default.execute(1, new Object[] {AV10Prodcod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = P008P3_A28ProdCod[0];
               A55ProdDsc = P008P3_A55ProdDsc[0];
               AV24Filtro2 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV16Saldo = 0.0000m;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV8LinCod ,
                                                 AV10Prodcod ,
                                                 AV40CliCod ,
                                                 AV42MovCod ,
                                                 AV39MVCliOrigen ,
                                                 AV44CosCod ,
                                                 AV49Lote ,
                                                 A52LinCod ,
                                                 A28ProdCod ,
                                                 A15MVCliCod ,
                                                 A22MvAMov ,
                                                 A16MVCliOrigen ,
                                                 A1287MVCCosto ,
                                                 A31MVADLRef1 ,
                                                 A1158LinStk } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P008P4 */
            pr_default.execute(2, new Object[] {AV8LinCod, AV10Prodcod, AV40CliCod, AV42MovCod, AV39MVCliOrigen, AV44CosCod, AV49Lote});
            while ( (pr_default.getStatus(2) != 101) )
            {
               BRK8P5 = false;
               A49UniCod = P008P4_A49UniCod[0];
               A1158LinStk = P008P4_A1158LinStk[0];
               A1370MVSts = P008P4_A1370MVSts[0];
               A25MvAFec = P008P4_A25MvAFec[0];
               A31MVADLRef1 = P008P4_A31MVADLRef1[0];
               A15MVCliCod = P008P4_A15MVCliCod[0];
               n15MVCliCod = P008P4_n15MVCliCod[0];
               A22MvAMov = P008P4_A22MvAMov[0];
               A21MvAlm = P008P4_A21MvAlm[0];
               A28ProdCod = P008P4_A28ProdCod[0];
               A1287MVCCosto = P008P4_A1287MVCCosto[0];
               A1278MvARef = P008P4_A1278MvARef[0];
               A24DocNum = P008P4_A24DocNum[0];
               n24DocNum = P008P4_n24DocNum[0];
               A1276MvAOcom = P008P4_A1276MvAOcom[0];
               A1254MVADLRef2 = P008P4_A1254MVADLRef2[0];
               A1274MvAMovDsc = P008P4_A1274MvAMovDsc[0];
               A1251MVADLCant = P008P4_A1251MVADLCant[0];
               A14MvACod = P008P4_A14MvACod[0];
               A13MvATip = P008P4_A13MvATip[0];
               A16MVCliOrigen = P008P4_A16MVCliOrigen[0];
               n16MVCliOrigen = P008P4_n16MVCliOrigen[0];
               A52LinCod = P008P4_A52LinCod[0];
               A55ProdDsc = P008P4_A55ProdDsc[0];
               A1997UniAbr = P008P4_A1997UniAbr[0];
               A30MvADItem = P008P4_A30MvADItem[0];
               A49UniCod = P008P4_A49UniCod[0];
               A52LinCod = P008P4_A52LinCod[0];
               A55ProdDsc = P008P4_A55ProdDsc[0];
               A1997UniAbr = P008P4_A1997UniAbr[0];
               A1158LinStk = P008P4_A1158LinStk[0];
               A1370MVSts = P008P4_A1370MVSts[0];
               A25MvAFec = P008P4_A25MvAFec[0];
               A15MVCliCod = P008P4_A15MVCliCod[0];
               n15MVCliCod = P008P4_n15MVCliCod[0];
               A22MvAMov = P008P4_A22MvAMov[0];
               A21MvAlm = P008P4_A21MvAlm[0];
               A1287MVCCosto = P008P4_A1287MVCCosto[0];
               A1278MvARef = P008P4_A1278MvARef[0];
               A24DocNum = P008P4_A24DocNum[0];
               n24DocNum = P008P4_n24DocNum[0];
               A1276MvAOcom = P008P4_A1276MvAOcom[0];
               A16MVCliOrigen = P008P4_A16MVCliOrigen[0];
               n16MVCliOrigen = P008P4_n16MVCliOrigen[0];
               A1274MvAMovDsc = P008P4_A1274MvAMovDsc[0];
               AV37Codigo = A28ProdCod;
               AV15Producto = StringUtil.Trim( A28ProdCod) + " - " + StringUtil.Trim( A55ProdDsc);
               AV38UniAbr = A1997UniAbr;
               GXt_decimal1 = AV16Saldo;
               new pobtenersaldoproductolote(context ).execute( ref  AV37Codigo, ref  AV9AlmCod, ref  AV13cDesde, ref  AV49Lote, out  GXt_decimal1) ;
               AV16Saldo = GXt_decimal1;
               AV17Final = AV16Saldo;
               /* Execute user subroutine: 'VALIDA' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               if ( AV26Flag == 0 )
               {
                  H8P0( false, 22) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Producto : ", 25, Gx_line+5, 82, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Producto, "")), 85, Gx_line+5, 437, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Saldo :", 526, Gx_line+5, 561, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16Saldo, "ZZZZ,ZZZ,ZZ9.9999")), 568, Gx_line+5, 658, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38UniAbr, "")), 446, Gx_line+5, 489, Gx_line+18, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+22);
               }
               AV18Ingresa = 0.0000m;
               AV19Salida = 0.0000m;
               AV33TIngresos = 0.0000m;
               AV34TSalidas = 0.0000m;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P008P4_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRK8P5 = false;
                  A1370MVSts = P008P4_A1370MVSts[0];
                  A25MvAFec = P008P4_A25MvAFec[0];
                  A31MVADLRef1 = P008P4_A31MVADLRef1[0];
                  A15MVCliCod = P008P4_A15MVCliCod[0];
                  n15MVCliCod = P008P4_n15MVCliCod[0];
                  A22MvAMov = P008P4_A22MvAMov[0];
                  A21MvAlm = P008P4_A21MvAlm[0];
                  A1287MVCCosto = P008P4_A1287MVCCosto[0];
                  A1278MvARef = P008P4_A1278MvARef[0];
                  A24DocNum = P008P4_A24DocNum[0];
                  n24DocNum = P008P4_n24DocNum[0];
                  A1276MvAOcom = P008P4_A1276MvAOcom[0];
                  A1254MVADLRef2 = P008P4_A1254MVADLRef2[0];
                  A1274MvAMovDsc = P008P4_A1274MvAMovDsc[0];
                  A1251MVADLCant = P008P4_A1251MVADLCant[0];
                  A14MvACod = P008P4_A14MvACod[0];
                  A13MvATip = P008P4_A13MvATip[0];
                  A30MvADItem = P008P4_A30MvADItem[0];
                  A1370MVSts = P008P4_A1370MVSts[0];
                  A25MvAFec = P008P4_A25MvAFec[0];
                  A15MVCliCod = P008P4_A15MVCliCod[0];
                  n15MVCliCod = P008P4_n15MVCliCod[0];
                  A22MvAMov = P008P4_A22MvAMov[0];
                  A21MvAlm = P008P4_A21MvAlm[0];
                  A1287MVCCosto = P008P4_A1287MVCCosto[0];
                  A1278MvARef = P008P4_A1278MvARef[0];
                  A24DocNum = P008P4_A24DocNum[0];
                  n24DocNum = P008P4_n24DocNum[0];
                  A1276MvAOcom = P008P4_A1276MvAOcom[0];
                  A1274MvAMovDsc = P008P4_A1274MvAMovDsc[0];
                  if ( DateTimeUtil.ResetTime ( A25MvAFec ) <= DateTimeUtil.ResetTime ( AV14cHasta ) )
                  {
                     if ( DateTimeUtil.ResetTime ( A25MvAFec ) >= DateTimeUtil.ResetTime ( AV13cDesde ) )
                     {
                        if ( StringUtil.StrCmp(A28ProdCod, AV37Codigo) == 0 )
                        {
                           if ( A21MvAlm == AV9AlmCod )
                           {
                              if ( ( StringUtil.StrCmp(AV53Tipo, "A") == 0 ) || ( ( StringUtil.StrCmp(A1370MVSts, "A") != 0 ) ) )
                              {
                                 AV35Cliente = "";
                                 AV46MvATip = A13MvATip;
                                 AV47MvACod = A14MvACod;
                                 AV51MVSts = A1370MVSts;
                                 AV45MVCCosto = A1287MVCCosto;
                                 AV36DocRef = ((StringUtil.StrCmp(AV51MVSts, "A")==0) ? "" : (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? A1278MvARef : A24DocNum));
                                 AV41MvAOcom = ((StringUtil.StrCmp(AV51MVSts, "A")==0) ? "" : StringUtil.Trim( A1276MvAOcom));
                                 AV43MVADLRef1 = A31MVADLRef1;
                                 AV50MVADLRef2 = A1254MVADLRef2;
                                 AV52MvAMovDsc = ((StringUtil.StrCmp(AV51MVSts, "A")==0) ? "ANULADO" : StringUtil.Trim( A1274MvAMovDsc));
                                 AV35Cliente = StringUtil.Trim( AV43MVADLRef1) + "  -  " + StringUtil.Trim( A1254MVADLRef2);
                                 AV18Ingresa = ((StringUtil.StrCmp(AV51MVSts, "A")==0) ? (decimal)(0) : ((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1251MVADLCant : (decimal)(0)));
                                 AV19Salida = ((StringUtil.StrCmp(AV51MVSts, "A")==0) ? (decimal)(0) : ((StringUtil.StrCmp(A13MvATip, "ING")!=0) ? A1251MVADLCant : (decimal)(0)));
                                 AV17Final = (decimal)(AV17Final+(AV18Ingresa-AV19Salida));
                                 AV33TIngresos = (decimal)(AV33TIngresos+AV18Ingresa);
                                 AV34TSalidas = (decimal)(AV34TSalidas+AV19Salida);
                                 H8P0( false, 17) ;
                                 getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13MvATip, "")), 3, Gx_line+1, 28, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), 29, Gx_line+1, 93, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 94, Gx_line+1, 142, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52MvAMovDsc, "")), 278, Gx_line+0, 438, Gx_line+16, 0, 0, 0, 0) ;
                                 getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18Ingresa, "ZZZZ,ZZZ,ZZ9.9999")), 568, Gx_line+2, 658, Gx_line+15, 2+256, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19Salida, "ZZZZ,ZZZ,ZZ9.9999")), 638, Gx_line+2, 728, Gx_line+15, 2+256, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 723, Gx_line+2, 813, Gx_line+15, 2+256, 0, 0, 0) ;
                                 getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36DocRef, "")), 146, Gx_line+1, 211, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Cliente, "")), 444, Gx_line+0, 602, Gx_line+16, 0, 0, 0, 0) ;
                                 getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41MvAOcom, "")), 219, Gx_line+2, 262, Gx_line+15, 0+256, 0, 0, 0) ;
                                 Gx_OldLine = Gx_line;
                                 Gx_line = (int)(Gx_line+17);
                              }
                           }
                        }
                     }
                  }
                  BRK8P5 = true;
                  pr_default.readNext(2);
               }
               if ( AV26Flag == 0 )
               {
                  H8P0( false, 36) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Producto, "")), 140, Gx_line+5, 557, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 723, Gx_line+5, 813, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33TIngresos, "ZZZZ,ZZZ,ZZ9.9999")), 568, Gx_line+5, 658, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34TSalidas, "ZZZZ,ZZZ,ZZ9.9999")), 638, Gx_line+5, 728, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(556, Gx_line+2, 814, Gx_line+2, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+36);
               }
               if ( ! BRK8P5 )
               {
                  BRK8P5 = true;
                  pr_default.readNext(2);
               }
            }
            pr_default.close(2);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8P0( true, 0) ;
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
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV40CliCod ,
                                              AV49Lote ,
                                              AV53Tipo ,
                                              A15MVCliCod ,
                                              A31MVADLRef1 ,
                                              A1370MVSts ,
                                              A28ProdCod ,
                                              AV37Codigo ,
                                              A21MvAlm ,
                                              AV9AlmCod ,
                                              AV13cDesde ,
                                              A25MvAFec ,
                                              AV14cHasta } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P008P5 */
         pr_default.execute(3, new Object[] {AV13cDesde, AV37Codigo, AV9AlmCod, AV14cHasta, AV40CliCod, AV49Lote});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A28ProdCod = P008P5_A28ProdCod[0];
            A21MvAlm = P008P5_A21MvAlm[0];
            A1370MVSts = P008P5_A1370MVSts[0];
            A31MVADLRef1 = P008P5_A31MVADLRef1[0];
            A15MVCliCod = P008P5_A15MVCliCod[0];
            n15MVCliCod = P008P5_n15MVCliCod[0];
            A25MvAFec = P008P5_A25MvAFec[0];
            A14MvACod = P008P5_A14MvACod[0];
            A13MvATip = P008P5_A13MvATip[0];
            A30MvADItem = P008P5_A30MvADItem[0];
            A21MvAlm = P008P5_A21MvAlm[0];
            A1370MVSts = P008P5_A1370MVSts[0];
            A15MVCliCod = P008P5_A15MVCliCod[0];
            n15MVCliCod = P008P5_n15MVCliCod[0];
            A25MvAFec = P008P5_A25MvAFec[0];
            AV26Flag = 0;
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void H8P0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 696, Gx_line+59, 728, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 696, Gx_line+77, 740, Gx_line+91, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 696, Gx_line+42, 735, Gx_line+56, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 758, Gx_line+76, 797, Gx_line+91, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 735, Gx_line+58, 795, Gx_line+72, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 750, Gx_line+41, 797, Gx_line+56, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11Almacen, "")), 189, Gx_line+54, 645, Gx_line+79, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+136, 818, Gx_line+162, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/G", 4, Gx_line+144, 25, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Guia", 41, Gx_line+144, 81, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Ing.", 599, Gx_line+144, 652, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Sal.", 671, Gx_line+144, 722, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Actual", 739, Gx_line+144, 805, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Producto :", 178, Gx_line+86, 247, Gx_line+101, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde :", 178, Gx_line+108, 226, Gx_line+123, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro2, "")), 258, Gx_line+81, 623, Gx_line+105, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV13cDesde, "99/99/99"), 259, Gx_line+103, 327, Gx_line+127, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta :", 338, Gx_line+108, 384, Gx_line+123, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV14cHasta, "99/99/99"), 404, Gx_line+103, 500, Gx_line+127, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12Titulo, "")), 189, Gx_line+27, 645, Gx_line+52, 1, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV31Logo)) ? AV56Logo_GXI : AV31Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 8, Gx_line+41, 175, Gx_line+117) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 100, Gx_line+144, 131, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Doc. Ref.", 150, Gx_line+144, 197, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo Movimiento", 297, Gx_line+144, 384, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Lote", 472, Gx_line+144, 496, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 8, Gx_line+5, 376, Gx_line+23, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29EmpRUC, "")), 8, Gx_line+23, 178, Gx_line+41, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Orden", 214, Gx_line+144, 263, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48FMT, "")), 671, Gx_line+16, 797, Gx_line+34, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+163);
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
         AV27Empresa = "";
         AV32Session = context.GetSession();
         AV28EmpDir = "";
         AV29EmpRUC = "";
         AV30Ruta = "";
         AV31Logo = "";
         AV56Logo_GXI = "";
         AV48FMT = "";
         AV12Titulo = "";
         scmdbuf = "";
         P008P2_A63AlmCod = new int[1] ;
         P008P2_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         AV11Almacen = "";
         AV22Filtro1 = "";
         AV24Filtro2 = "";
         P008P3_A28ProdCod = new string[] {""} ;
         P008P3_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         AV44CosCod = "";
         A15MVCliCod = "";
         A1287MVCCosto = "";
         A31MVADLRef1 = "";
         P008P4_A49UniCod = new int[1] ;
         P008P4_A1158LinStk = new short[1] ;
         P008P4_A1370MVSts = new string[] {""} ;
         P008P4_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008P4_A31MVADLRef1 = new string[] {""} ;
         P008P4_A15MVCliCod = new string[] {""} ;
         P008P4_n15MVCliCod = new bool[] {false} ;
         P008P4_A22MvAMov = new int[1] ;
         P008P4_A21MvAlm = new int[1] ;
         P008P4_A28ProdCod = new string[] {""} ;
         P008P4_A1287MVCCosto = new string[] {""} ;
         P008P4_A1278MvARef = new string[] {""} ;
         P008P4_A24DocNum = new string[] {""} ;
         P008P4_n24DocNum = new bool[] {false} ;
         P008P4_A1276MvAOcom = new string[] {""} ;
         P008P4_A1254MVADLRef2 = new string[] {""} ;
         P008P4_A1274MvAMovDsc = new string[] {""} ;
         P008P4_A1251MVADLCant = new decimal[1] ;
         P008P4_A14MvACod = new string[] {""} ;
         P008P4_A13MvATip = new string[] {""} ;
         P008P4_A16MVCliOrigen = new int[1] ;
         P008P4_n16MVCliOrigen = new bool[] {false} ;
         P008P4_A52LinCod = new int[1] ;
         P008P4_A55ProdDsc = new string[] {""} ;
         P008P4_A1997UniAbr = new string[] {""} ;
         P008P4_A30MvADItem = new int[1] ;
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         A1278MvARef = "";
         A24DocNum = "";
         A1276MvAOcom = "";
         A1254MVADLRef2 = "";
         A1274MvAMovDsc = "";
         A14MvACod = "";
         A13MvATip = "";
         A1997UniAbr = "";
         AV37Codigo = "";
         AV15Producto = "";
         AV38UniAbr = "";
         AV35Cliente = "";
         AV46MvATip = "";
         AV47MvACod = "";
         AV51MVSts = "";
         AV45MVCCosto = "";
         AV36DocRef = "";
         AV41MvAOcom = "";
         AV43MVADLRef1 = "";
         AV50MVADLRef2 = "";
         AV52MvAMovDsc = "";
         P008P5_A28ProdCod = new string[] {""} ;
         P008P5_A21MvAlm = new int[1] ;
         P008P5_A1370MVSts = new string[] {""} ;
         P008P5_A31MVADLRef1 = new string[] {""} ;
         P008P5_A15MVCliCod = new string[] {""} ;
         P008P5_n15MVCliCod = new bool[] {false} ;
         P008P5_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008P5_A14MvACod = new string[] {""} ;
         P008P5_A13MvATip = new string[] {""} ;
         P008P5_A30MvADItem = new int[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV31Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrkardexlotes__default(),
            new Object[][] {
                new Object[] {
               P008P2_A63AlmCod, P008P2_A436AlmDsc
               }
               , new Object[] {
               P008P3_A28ProdCod, P008P3_A55ProdDsc
               }
               , new Object[] {
               P008P4_A49UniCod, P008P4_A1158LinStk, P008P4_A1370MVSts, P008P4_A25MvAFec, P008P4_A31MVADLRef1, P008P4_A15MVCliCod, P008P4_n15MVCliCod, P008P4_A22MvAMov, P008P4_A21MvAlm, P008P4_A28ProdCod,
               P008P4_A1287MVCCosto, P008P4_A1278MvARef, P008P4_A24DocNum, P008P4_n24DocNum, P008P4_A1276MvAOcom, P008P4_A1254MVADLRef2, P008P4_A1274MvAMovDsc, P008P4_A1251MVADLCant, P008P4_A14MvACod, P008P4_A13MvATip,
               P008P4_A16MVCliOrigen, P008P4_n16MVCliOrigen, P008P4_A52LinCod, P008P4_A55ProdDsc, P008P4_A1997UniAbr, P008P4_A30MvADItem
               }
               , new Object[] {
               P008P5_A28ProdCod, P008P5_A21MvAlm, P008P5_A1370MVSts, P008P5_A31MVADLRef1, P008P5_A15MVCliCod, P008P5_n15MVCliCod, P008P5_A25MvAFec, P008P5_A14MvACod, P008P5_A13MvATip, P008P5_A30MvADItem
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
      private short AV26Flag ;
      private int AV9AlmCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A63AlmCod ;
      private int AV8LinCod ;
      private int AV42MovCod ;
      private int AV39MVCliOrigen ;
      private int A52LinCod ;
      private int A22MvAMov ;
      private int A16MVCliOrigen ;
      private int A49UniCod ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private int Gx_OldLine ;
      private decimal AV16Saldo ;
      private decimal A1251MVADLCant ;
      private decimal GXt_decimal1 ;
      private decimal AV17Final ;
      private decimal AV18Ingresa ;
      private decimal AV19Salida ;
      private decimal AV33TIngresos ;
      private decimal AV34TSalidas ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV10Prodcod ;
      private string AV53Tipo ;
      private string AV40CliCod ;
      private string AV27Empresa ;
      private string AV28EmpDir ;
      private string AV29EmpRUC ;
      private string AV30Ruta ;
      private string AV12Titulo ;
      private string scmdbuf ;
      private string A436AlmDsc ;
      private string AV11Almacen ;
      private string AV22Filtro1 ;
      private string AV24Filtro2 ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string AV44CosCod ;
      private string A15MVCliCod ;
      private string A1287MVCCosto ;
      private string A1370MVSts ;
      private string A1278MvARef ;
      private string A24DocNum ;
      private string A1276MvAOcom ;
      private string A1274MvAMovDsc ;
      private string A14MvACod ;
      private string A13MvATip ;
      private string A1997UniAbr ;
      private string AV37Codigo ;
      private string AV15Producto ;
      private string AV38UniAbr ;
      private string AV35Cliente ;
      private string AV46MvATip ;
      private string AV47MvACod ;
      private string AV51MVSts ;
      private string AV45MVCCosto ;
      private string AV36DocRef ;
      private string AV41MvAOcom ;
      private string AV52MvAMovDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV13cDesde ;
      private DateTime AV14cHasta ;
      private DateTime A25MvAFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK8P5 ;
      private bool n15MVCliCod ;
      private bool n24DocNum ;
      private bool n16MVCliOrigen ;
      private bool returnInSub ;
      private string AV49Lote ;
      private string AV56Logo_GXI ;
      private string AV48FMT ;
      private string A31MVADLRef1 ;
      private string A1254MVADLRef2 ;
      private string AV43MVADLRef1 ;
      private string AV50MVADLRef2 ;
      private string AV31Logo ;
      private string Logo ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_AlmCod ;
      private string aP1_Prodcod ;
      private DateTime aP2_cDesde ;
      private DateTime aP3_cHasta ;
      private string aP4_Lote ;
      private string aP5_Tipo ;
      private string aP6_CliCod ;
      private IDataStoreProvider pr_default ;
      private int[] P008P2_A63AlmCod ;
      private string[] P008P2_A436AlmDsc ;
      private string[] P008P3_A28ProdCod ;
      private string[] P008P3_A55ProdDsc ;
      private int[] P008P4_A49UniCod ;
      private short[] P008P4_A1158LinStk ;
      private string[] P008P4_A1370MVSts ;
      private DateTime[] P008P4_A25MvAFec ;
      private string[] P008P4_A31MVADLRef1 ;
      private string[] P008P4_A15MVCliCod ;
      private bool[] P008P4_n15MVCliCod ;
      private int[] P008P4_A22MvAMov ;
      private int[] P008P4_A21MvAlm ;
      private string[] P008P4_A28ProdCod ;
      private string[] P008P4_A1287MVCCosto ;
      private string[] P008P4_A1278MvARef ;
      private string[] P008P4_A24DocNum ;
      private bool[] P008P4_n24DocNum ;
      private string[] P008P4_A1276MvAOcom ;
      private string[] P008P4_A1254MVADLRef2 ;
      private string[] P008P4_A1274MvAMovDsc ;
      private decimal[] P008P4_A1251MVADLCant ;
      private string[] P008P4_A14MvACod ;
      private string[] P008P4_A13MvATip ;
      private int[] P008P4_A16MVCliOrigen ;
      private bool[] P008P4_n16MVCliOrigen ;
      private int[] P008P4_A52LinCod ;
      private string[] P008P4_A55ProdDsc ;
      private string[] P008P4_A1997UniAbr ;
      private int[] P008P4_A30MvADItem ;
      private string[] P008P5_A28ProdCod ;
      private int[] P008P5_A21MvAlm ;
      private string[] P008P5_A1370MVSts ;
      private string[] P008P5_A31MVADLRef1 ;
      private string[] P008P5_A15MVCliCod ;
      private bool[] P008P5_n15MVCliCod ;
      private DateTime[] P008P5_A25MvAFec ;
      private string[] P008P5_A14MvACod ;
      private string[] P008P5_A13MvATip ;
      private int[] P008P5_A30MvADItem ;
   }

   public class rrkardexlotes__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008P4( IGxContext context ,
                                             int AV8LinCod ,
                                             string AV10Prodcod ,
                                             string AV40CliCod ,
                                             int AV42MovCod ,
                                             int AV39MVCliOrigen ,
                                             string AV44CosCod ,
                                             string AV49Lote ,
                                             int A52LinCod ,
                                             string A28ProdCod ,
                                             string A15MVCliCod ,
                                             int A22MvAMov ,
                                             int A16MVCliOrigen ,
                                             string A1287MVCCosto ,
                                             string A31MVADLRef1 ,
                                             short A1158LinStk )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T4.[LinStk], T5.[MVSts], T5.[MvAFec], T1.[MVADLRef1], T5.[MVCliCod], T5.[MvAMov] AS MvAMov, T5.[MvAlm], T1.[ProdCod], T5.[MVCCosto], T5.[MvARef], T5.[DocNum], T5.[MvAOcom], T1.[MVADLRef2], T6.[MovDsc] AS MvAMovDsc, T1.[MVADLCant], T1.[MvACod], T1.[MvATip], T5.[MVCliOrigen], T2.[LinCod], T2.[ProdDsc], T3.[UniAbr], T1.[MvADItem] FROM ((((([AGUIASDETLOTE] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T2.[LinCod]) INNER JOIN [AGUIAS] T5 ON T5.[MvATip] = T1.[MvATip] AND T5.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T6 ON T6.[MovCod] = T5.[MvAMov])";
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         if ( ! (0==AV8LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV8LinCod)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV10Prodcod)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40CliCod)) )
         {
            AddWhere(sWhereString, "(T5.[MVCliCod] = @AV40CliCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV42MovCod) )
         {
            AddWhere(sWhereString, "(T5.[MvAMov] = @AV42MovCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV39MVCliOrigen) )
         {
            AddWhere(sWhereString, "(T5.[MVCliOrigen] = @AV39MVCliOrigen)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44CosCod)) )
         {
            AddWhere(sWhereString, "(T5.[MVCCosto] = @AV44CosCod)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Lote)) )
         {
            AddWhere(sWhereString, "(T1.[MVADLRef1] = @AV49Lote)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T5.[MvAFec], T1.[MvATip], T1.[MvACod]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P008P5( IGxContext context ,
                                             string AV40CliCod ,
                                             string AV49Lote ,
                                             string AV53Tipo ,
                                             string A15MVCliCod ,
                                             string A31MVADLRef1 ,
                                             string A1370MVSts ,
                                             string A28ProdCod ,
                                             string AV37Codigo ,
                                             int A21MvAlm ,
                                             int AV9AlmCod ,
                                             DateTime AV13cDesde ,
                                             DateTime A25MvAFec ,
                                             DateTime AV14cHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[ProdCod], T2.[MvAlm], T2.[MVSts], T1.[MVADLRef1], T2.[MVCliCod], T2.[MvAFec], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM ([AGUIASDETLOTE] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod])";
         AddWhere(sWhereString, "(T2.[MvAFec] >= @AV13cDesde)");
         AddWhere(sWhereString, "(T1.[ProdCod] = @AV37Codigo)");
         AddWhere(sWhereString, "(T2.[MvAlm] = @AV9AlmCod)");
         AddWhere(sWhereString, "(T2.[MvAFec] <= @AV14cHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[MVCliCod] = @AV40CliCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Lote)) )
         {
            AddWhere(sWhereString, "(T1.[MVADLRef1] = @AV49Lote)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! ( StringUtil.StrCmp(AV53Tipo, "A") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MVSts] <> 'A')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P008P4(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] );
               case 3 :
                     return conditional_P008P5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] );
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
          Object[] prmP008P2;
          prmP008P2 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP008P3;
          prmP008P3 = new Object[] {
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP008P4;
          prmP008P4 = new Object[] {
          new ParDef("@AV8LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV10Prodcod",GXType.NChar,15,0) ,
          new ParDef("@AV40CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV42MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV39MVCliOrigen",GXType.Int32,6,0) ,
          new ParDef("@AV44CosCod",GXType.NChar,10,0) ,
          new ParDef("@AV49Lote",GXType.NVarChar,40,0)
          };
          Object[] prmP008P5;
          prmP008P5 = new Object[] {
          new ParDef("@AV13cDesde",GXType.Date,8,0) ,
          new ParDef("@AV37Codigo",GXType.NChar,15,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV14cHasta",GXType.Date,8,0) ,
          new ParDef("@AV40CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV49Lote",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008P2", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV9AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008P2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008P3", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV10Prodcod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008P3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008P4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008P4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008P5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008P5,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 15);
                ((string[]) buf[10])[0] = rslt.getString(10, 10);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((string[]) buf[12])[0] = rslt.getString(12, 12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 10);
                ((string[]) buf[15])[0] = rslt.getVarchar(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 100);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(16);
                ((string[]) buf[18])[0] = rslt.getString(17, 12);
                ((string[]) buf[19])[0] = rslt.getString(18, 3);
                ((int[]) buf[20])[0] = rslt.getInt(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((int[]) buf[22])[0] = rslt.getInt(20);
                ((string[]) buf[23])[0] = rslt.getString(21, 100);
                ((string[]) buf[24])[0] = rslt.getString(22, 5);
                ((int[]) buf[25])[0] = rslt.getInt(23);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 12);
                ((string[]) buf[8])[0] = rslt.getString(8, 3);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
