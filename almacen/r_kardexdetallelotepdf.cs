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
namespace GeneXus.Programs.almacen {
   public class r_kardexdetallelotepdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "almacen.r_kardexdetallelotepdf.aspx")), "almacen.r_kardexdetallelotepdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "almacen.r_kardexdetallelotepdf.aspx")))) ;
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
                  AV40CliCod = GetPar( "CliCod");
                  AV39MVCliOrigen = (int)(NumberUtil.Val( GetPar( "MVCliOrigen"), "."));
                  AV42MovCod = (int)(NumberUtil.Val( GetPar( "MovCod"), "."));
                  AV43MVADLRef1 = GetPar( "MVADLRef1");
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

      public r_kardexdetallelotepdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_kardexdetallelotepdf( IGxContext context )
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
                           ref string aP4_CliCod ,
                           ref int aP5_MVCliOrigen ,
                           ref int aP6_MovCod ,
                           ref string aP7_MVADLRef1 )
      {
         this.AV9AlmCod = aP0_AlmCod;
         this.AV10Prodcod = aP1_Prodcod;
         this.AV13cDesde = aP2_cDesde;
         this.AV14cHasta = aP3_cHasta;
         this.AV40CliCod = aP4_CliCod;
         this.AV39MVCliOrigen = aP5_MVCliOrigen;
         this.AV42MovCod = aP6_MovCod;
         this.AV43MVADLRef1 = aP7_MVADLRef1;
         initialize();
         executePrivate();
         aP0_AlmCod=this.AV9AlmCod;
         aP1_Prodcod=this.AV10Prodcod;
         aP2_cDesde=this.AV13cDesde;
         aP3_cHasta=this.AV14cHasta;
         aP4_CliCod=this.AV40CliCod;
         aP5_MVCliOrigen=this.AV39MVCliOrigen;
         aP6_MovCod=this.AV42MovCod;
         aP7_MVADLRef1=this.AV43MVADLRef1;
      }

      public string executeUdp( ref int aP0_AlmCod ,
                                ref string aP1_Prodcod ,
                                ref DateTime aP2_cDesde ,
                                ref DateTime aP3_cHasta ,
                                ref string aP4_CliCod ,
                                ref int aP5_MVCliOrigen ,
                                ref int aP6_MovCod )
      {
         execute(ref aP0_AlmCod, ref aP1_Prodcod, ref aP2_cDesde, ref aP3_cHasta, ref aP4_CliCod, ref aP5_MVCliOrigen, ref aP6_MovCod, ref aP7_MVADLRef1);
         return AV43MVADLRef1 ;
      }

      public void executeSubmit( ref int aP0_AlmCod ,
                                 ref string aP1_Prodcod ,
                                 ref DateTime aP2_cDesde ,
                                 ref DateTime aP3_cHasta ,
                                 ref string aP4_CliCod ,
                                 ref int aP5_MVCliOrigen ,
                                 ref int aP6_MovCod ,
                                 ref string aP7_MVADLRef1 )
      {
         r_kardexdetallelotepdf objr_kardexdetallelotepdf;
         objr_kardexdetallelotepdf = new r_kardexdetallelotepdf();
         objr_kardexdetallelotepdf.AV9AlmCod = aP0_AlmCod;
         objr_kardexdetallelotepdf.AV10Prodcod = aP1_Prodcod;
         objr_kardexdetallelotepdf.AV13cDesde = aP2_cDesde;
         objr_kardexdetallelotepdf.AV14cHasta = aP3_cHasta;
         objr_kardexdetallelotepdf.AV40CliCod = aP4_CliCod;
         objr_kardexdetallelotepdf.AV39MVCliOrigen = aP5_MVCliOrigen;
         objr_kardexdetallelotepdf.AV42MovCod = aP6_MovCod;
         objr_kardexdetallelotepdf.AV43MVADLRef1 = aP7_MVADLRef1;
         objr_kardexdetallelotepdf.context.SetSubmitInitialConfig(context);
         objr_kardexdetallelotepdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_kardexdetallelotepdf);
         aP0_AlmCod=this.AV9AlmCod;
         aP1_Prodcod=this.AV10Prodcod;
         aP2_cDesde=this.AV13cDesde;
         aP3_cHasta=this.AV14cHasta;
         aP4_CliCod=this.AV40CliCod;
         aP5_MVCliOrigen=this.AV39MVCliOrigen;
         aP6_MovCod=this.AV42MovCod;
         aP7_MVADLRef1=this.AV43MVADLRef1;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_kardexdetallelotepdf)stateInfo).executePrivate();
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
            AV46Logo_GXI = GXDbFile.PathToUrl( AV30Ruta);
            AV12Titulo = "Kardex por producto";
            /* Using cursor P00DQ2 */
            pr_default.execute(0, new Object[] {AV9AlmCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A63AlmCod = P00DQ2_A63AlmCod[0];
               A436AlmDsc = P00DQ2_A436AlmDsc[0];
               AV11Almacen = A436AlmDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV22Filtro1 = "";
            AV24Filtro2 = "";
            /* Using cursor P00DQ3 */
            pr_default.execute(1, new Object[] {AV10Prodcod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = P00DQ3_A28ProdCod[0];
               A55ProdDsc = P00DQ3_A55ProdDsc[0];
               AV24Filtro2 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV16Saldo = 0.0000m;
            AV33TIngresos = 0.0000m;
            AV34TSalidas = 0.0000m;
            AV17Final = 0.0000m;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV8LinCod ,
                                                 AV10Prodcod ,
                                                 AV40CliCod ,
                                                 AV42MovCod ,
                                                 AV39MVCliOrigen ,
                                                 AV43MVADLRef1 ,
                                                 A52LinCod ,
                                                 A28ProdCod ,
                                                 A15MVCliCod ,
                                                 A22MvAMov ,
                                                 A16MVCliOrigen ,
                                                 A31MVADLRef1 ,
                                                 A1370MVSts ,
                                                 A21MvAlm ,
                                                 AV9AlmCod ,
                                                 A1158LinStk } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00DQ4 */
            pr_default.execute(2, new Object[] {AV9AlmCod, AV8LinCod, AV10Prodcod, AV40CliCod, AV42MovCod, AV39MVCliOrigen, AV43MVADLRef1});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A49UniCod = P00DQ4_A49UniCod[0];
               A21MvAlm = P00DQ4_A21MvAlm[0];
               A1158LinStk = P00DQ4_A1158LinStk[0];
               A1370MVSts = P00DQ4_A1370MVSts[0];
               A31MVADLRef1 = P00DQ4_A31MVADLRef1[0];
               A16MVCliOrigen = P00DQ4_A16MVCliOrigen[0];
               n16MVCliOrigen = P00DQ4_n16MVCliOrigen[0];
               A22MvAMov = P00DQ4_A22MvAMov[0];
               A15MVCliCod = P00DQ4_A15MVCliCod[0];
               n15MVCliCod = P00DQ4_n15MVCliCod[0];
               A28ProdCod = P00DQ4_A28ProdCod[0];
               A52LinCod = P00DQ4_A52LinCod[0];
               A55ProdDsc = P00DQ4_A55ProdDsc[0];
               A1997UniAbr = P00DQ4_A1997UniAbr[0];
               A1278MvARef = P00DQ4_A1278MvARef[0];
               A24DocNum = P00DQ4_A24DocNum[0];
               n24DocNum = P00DQ4_n24DocNum[0];
               A1276MvAOcom = P00DQ4_A1276MvAOcom[0];
               A1251MVADLCant = P00DQ4_A1251MVADLCant[0];
               A13MvATip = P00DQ4_A13MvATip[0];
               A1274MvAMovDsc = P00DQ4_A1274MvAMovDsc[0];
               A25MvAFec = P00DQ4_A25MvAFec[0];
               A14MvACod = P00DQ4_A14MvACod[0];
               A30MvADItem = P00DQ4_A30MvADItem[0];
               A49UniCod = P00DQ4_A49UniCod[0];
               A52LinCod = P00DQ4_A52LinCod[0];
               A55ProdDsc = P00DQ4_A55ProdDsc[0];
               A1997UniAbr = P00DQ4_A1997UniAbr[0];
               A1158LinStk = P00DQ4_A1158LinStk[0];
               A21MvAlm = P00DQ4_A21MvAlm[0];
               A1370MVSts = P00DQ4_A1370MVSts[0];
               A16MVCliOrigen = P00DQ4_A16MVCliOrigen[0];
               n16MVCliOrigen = P00DQ4_n16MVCliOrigen[0];
               A22MvAMov = P00DQ4_A22MvAMov[0];
               A15MVCliCod = P00DQ4_A15MVCliCod[0];
               n15MVCliCod = P00DQ4_n15MVCliCod[0];
               A1278MvARef = P00DQ4_A1278MvARef[0];
               A24DocNum = P00DQ4_A24DocNum[0];
               n24DocNum = P00DQ4_n24DocNum[0];
               A1276MvAOcom = P00DQ4_A1276MvAOcom[0];
               A25MvAFec = P00DQ4_A25MvAFec[0];
               A1274MvAMovDsc = P00DQ4_A1274MvAMovDsc[0];
               AV37Codigo = A28ProdCod;
               AV15Producto = A55ProdDsc;
               AV38UniAbr = A1997UniAbr;
               AV18Ingresa = 0.0000m;
               AV19Salida = 0.0000m;
               /* Execute user subroutine: 'VALIDACLIENTE' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               AV36DocRef = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? A1278MvARef : A24DocNum);
               AV41MvAOcom = StringUtil.Trim( A1276MvAOcom);
               AV18Ingresa = ((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1251MVADLCant : (decimal)(0));
               AV19Salida = ((StringUtil.StrCmp(A13MvATip, "ING")!=0) ? A1251MVADLCant : (decimal)(0));
               AV17Final = (decimal)(AV17Final+(AV18Ingresa-AV19Salida));
               AV33TIngresos = (decimal)(AV33TIngresos+AV18Ingresa);
               AV34TSalidas = (decimal)(AV34TSalidas+AV19Salida);
               HDQ0( false, 17) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13MvATip, "")), 3, Gx_line+1, 28, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), 29, Gx_line+1, 93, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 95, Gx_line+1, 143, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1274MvAMovDsc, "")), 276, Gx_line+0, 436, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18Ingresa, "ZZZZ,ZZZ,ZZ9.9999")), 568, Gx_line+2, 658, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19Salida, "ZZZZ,ZZZ,ZZ9.9999")), 638, Gx_line+2, 728, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 723, Gx_line+2, 813, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36DocRef, "")), 147, Gx_line+1, 212, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Cliente, "")), 444, Gx_line+0, 602, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41MvAOcom, "")), 216, Gx_line+2, 259, Gx_line+15, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV17Final = (decimal)(AV33TIngresos-AV34TSalidas);
            HDQ0( false, 41) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Producto, "")), 76, Gx_line+2, 518, Gx_line+20, 2, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 723, Gx_line+5, 813, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33TIngresos, "ZZZZ,ZZZ,ZZ9.9999")), 568, Gx_line+5, 658, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34TSalidas, "ZZZZ,ZZZ,ZZ9.9999")), 638, Gx_line+5, 728, Gx_line+18, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+41);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HDQ0( true, 0) ;
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
         /* 'VALIDACLIENTE' Routine */
         returnInSub = false;
         /* Using cursor P00DQ5 */
         pr_default.execute(3, new Object[] {A13MvATip, A14MvACod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A15MVCliCod = P00DQ5_A15MVCliCod[0];
            n15MVCliCod = P00DQ5_n15MVCliCod[0];
            A14MvACod = P00DQ5_A14MvACod[0];
            A13MvATip = P00DQ5_A13MvATip[0];
            A1290MVCliDsc = P00DQ5_A1290MVCliDsc[0];
            A1290MVCliDsc = P00DQ5_A1290MVCliDsc[0];
            AV35Cliente = StringUtil.Trim( A1290MVCliDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      protected void HDQ0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 696, Gx_line+41, 728, Gx_line+55, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 696, Gx_line+58, 740, Gx_line+72, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 696, Gx_line+23, 735, Gx_line+37, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 758, Gx_line+57, 797, Gx_line+72, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 735, Gx_line+40, 795, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 750, Gx_line+22, 797, Gx_line+37, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11Almacen, "")), 189, Gx_line+54, 645, Gx_line+79, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+136, 818, Gx_line+162, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/G", 4, Gx_line+143, 27, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Guia", 41, Gx_line+143, 85, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Ing.", 599, Gx_line+143, 659, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Sal.", 671, Gx_line+143, 729, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Actual", 739, Gx_line+143, 814, Gx_line+157, 0+256, 0, 0, 0) ;
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
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV31Logo)) ? AV46Logo_GXI : AV31Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 8, Gx_line+41, 175, Gx_line+117) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 102, Gx_line+143, 137, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Doc. Ref.", 155, Gx_line+143, 207, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo Movimiento", 297, Gx_line+143, 396, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 486, Gx_line+143, 528, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 8, Gx_line+5, 376, Gx_line+23, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29EmpRUC, "")), 8, Gx_line+23, 178, Gx_line+41, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Orden", 218, Gx_line+143, 271, Gx_line+157, 0+256, 0, 0, 0) ;
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
         AV27Empresa = "";
         AV32Session = context.GetSession();
         AV28EmpDir = "";
         AV29EmpRUC = "";
         AV30Ruta = "";
         AV31Logo = "";
         AV46Logo_GXI = "";
         AV12Titulo = "";
         scmdbuf = "";
         P00DQ2_A63AlmCod = new int[1] ;
         P00DQ2_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         AV11Almacen = "";
         AV22Filtro1 = "";
         AV24Filtro2 = "";
         P00DQ3_A28ProdCod = new string[] {""} ;
         P00DQ3_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         A15MVCliCod = "";
         A31MVADLRef1 = "";
         A1370MVSts = "";
         P00DQ4_A49UniCod = new int[1] ;
         P00DQ4_A21MvAlm = new int[1] ;
         P00DQ4_A1158LinStk = new short[1] ;
         P00DQ4_A1370MVSts = new string[] {""} ;
         P00DQ4_A31MVADLRef1 = new string[] {""} ;
         P00DQ4_A16MVCliOrigen = new int[1] ;
         P00DQ4_n16MVCliOrigen = new bool[] {false} ;
         P00DQ4_A22MvAMov = new int[1] ;
         P00DQ4_A15MVCliCod = new string[] {""} ;
         P00DQ4_n15MVCliCod = new bool[] {false} ;
         P00DQ4_A28ProdCod = new string[] {""} ;
         P00DQ4_A52LinCod = new int[1] ;
         P00DQ4_A55ProdDsc = new string[] {""} ;
         P00DQ4_A1997UniAbr = new string[] {""} ;
         P00DQ4_A1278MvARef = new string[] {""} ;
         P00DQ4_A24DocNum = new string[] {""} ;
         P00DQ4_n24DocNum = new bool[] {false} ;
         P00DQ4_A1276MvAOcom = new string[] {""} ;
         P00DQ4_A1251MVADLCant = new decimal[1] ;
         P00DQ4_A13MvATip = new string[] {""} ;
         P00DQ4_A1274MvAMovDsc = new string[] {""} ;
         P00DQ4_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00DQ4_A14MvACod = new string[] {""} ;
         P00DQ4_A30MvADItem = new int[1] ;
         A1997UniAbr = "";
         A1278MvARef = "";
         A24DocNum = "";
         A1276MvAOcom = "";
         A13MvATip = "";
         A1274MvAMovDsc = "";
         A25MvAFec = DateTime.MinValue;
         A14MvACod = "";
         AV37Codigo = "";
         AV15Producto = "";
         AV38UniAbr = "";
         AV36DocRef = "";
         AV41MvAOcom = "";
         AV35Cliente = "";
         P00DQ5_A15MVCliCod = new string[] {""} ;
         P00DQ5_n15MVCliCod = new bool[] {false} ;
         P00DQ5_A14MvACod = new string[] {""} ;
         P00DQ5_A13MvATip = new string[] {""} ;
         P00DQ5_A1290MVCliDsc = new string[] {""} ;
         A1290MVCliDsc = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV31Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_kardexdetallelotepdf__default(),
            new Object[][] {
                new Object[] {
               P00DQ2_A63AlmCod, P00DQ2_A436AlmDsc
               }
               , new Object[] {
               P00DQ3_A28ProdCod, P00DQ3_A55ProdDsc
               }
               , new Object[] {
               P00DQ4_A49UniCod, P00DQ4_A21MvAlm, P00DQ4_A1158LinStk, P00DQ4_A1370MVSts, P00DQ4_A31MVADLRef1, P00DQ4_A16MVCliOrigen, P00DQ4_n16MVCliOrigen, P00DQ4_A22MvAMov, P00DQ4_A15MVCliCod, P00DQ4_n15MVCliCod,
               P00DQ4_A28ProdCod, P00DQ4_A52LinCod, P00DQ4_A55ProdDsc, P00DQ4_A1997UniAbr, P00DQ4_A1278MvARef, P00DQ4_A24DocNum, P00DQ4_n24DocNum, P00DQ4_A1276MvAOcom, P00DQ4_A1251MVADLCant, P00DQ4_A13MvATip,
               P00DQ4_A1274MvAMovDsc, P00DQ4_A25MvAFec, P00DQ4_A14MvACod, P00DQ4_A30MvADItem
               }
               , new Object[] {
               P00DQ5_A15MVCliCod, P00DQ5_n15MVCliCod, P00DQ5_A14MvACod, P00DQ5_A13MvATip, P00DQ5_A1290MVCliDsc
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
      private int AV9AlmCod ;
      private int AV39MVCliOrigen ;
      private int AV42MovCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A63AlmCod ;
      private int AV8LinCod ;
      private int A52LinCod ;
      private int A22MvAMov ;
      private int A16MVCliOrigen ;
      private int A21MvAlm ;
      private int A49UniCod ;
      private int A30MvADItem ;
      private int Gx_OldLine ;
      private decimal AV16Saldo ;
      private decimal AV33TIngresos ;
      private decimal AV34TSalidas ;
      private decimal AV17Final ;
      private decimal A1251MVADLCant ;
      private decimal AV18Ingresa ;
      private decimal AV19Salida ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV10Prodcod ;
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
      private string A15MVCliCod ;
      private string A1370MVSts ;
      private string A1997UniAbr ;
      private string A1278MvARef ;
      private string A24DocNum ;
      private string A1276MvAOcom ;
      private string A13MvATip ;
      private string A1274MvAMovDsc ;
      private string A14MvACod ;
      private string AV37Codigo ;
      private string AV15Producto ;
      private string AV38UniAbr ;
      private string AV36DocRef ;
      private string AV41MvAOcom ;
      private string AV35Cliente ;
      private string A1290MVCliDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV13cDesde ;
      private DateTime AV14cHasta ;
      private DateTime A25MvAFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n16MVCliOrigen ;
      private bool n15MVCliCod ;
      private bool n24DocNum ;
      private bool returnInSub ;
      private string AV43MVADLRef1 ;
      private string AV46Logo_GXI ;
      private string A31MVADLRef1 ;
      private string AV31Logo ;
      private string Logo ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_AlmCod ;
      private string aP1_Prodcod ;
      private DateTime aP2_cDesde ;
      private DateTime aP3_cHasta ;
      private string aP4_CliCod ;
      private int aP5_MVCliOrigen ;
      private int aP6_MovCod ;
      private string aP7_MVADLRef1 ;
      private IDataStoreProvider pr_default ;
      private int[] P00DQ2_A63AlmCod ;
      private string[] P00DQ2_A436AlmDsc ;
      private string[] P00DQ3_A28ProdCod ;
      private string[] P00DQ3_A55ProdDsc ;
      private int[] P00DQ4_A49UniCod ;
      private int[] P00DQ4_A21MvAlm ;
      private short[] P00DQ4_A1158LinStk ;
      private string[] P00DQ4_A1370MVSts ;
      private string[] P00DQ4_A31MVADLRef1 ;
      private int[] P00DQ4_A16MVCliOrigen ;
      private bool[] P00DQ4_n16MVCliOrigen ;
      private int[] P00DQ4_A22MvAMov ;
      private string[] P00DQ4_A15MVCliCod ;
      private bool[] P00DQ4_n15MVCliCod ;
      private string[] P00DQ4_A28ProdCod ;
      private int[] P00DQ4_A52LinCod ;
      private string[] P00DQ4_A55ProdDsc ;
      private string[] P00DQ4_A1997UniAbr ;
      private string[] P00DQ4_A1278MvARef ;
      private string[] P00DQ4_A24DocNum ;
      private bool[] P00DQ4_n24DocNum ;
      private string[] P00DQ4_A1276MvAOcom ;
      private decimal[] P00DQ4_A1251MVADLCant ;
      private string[] P00DQ4_A13MvATip ;
      private string[] P00DQ4_A1274MvAMovDsc ;
      private DateTime[] P00DQ4_A25MvAFec ;
      private string[] P00DQ4_A14MvACod ;
      private int[] P00DQ4_A30MvADItem ;
      private string[] P00DQ5_A15MVCliCod ;
      private bool[] P00DQ5_n15MVCliCod ;
      private string[] P00DQ5_A14MvACod ;
      private string[] P00DQ5_A13MvATip ;
      private string[] P00DQ5_A1290MVCliDsc ;
   }

   public class r_kardexdetallelotepdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DQ4( IGxContext context ,
                                             int AV8LinCod ,
                                             string AV10Prodcod ,
                                             string AV40CliCod ,
                                             int AV42MovCod ,
                                             int AV39MVCliOrigen ,
                                             string AV43MVADLRef1 ,
                                             int A52LinCod ,
                                             string A28ProdCod ,
                                             string A15MVCliCod ,
                                             int A22MvAMov ,
                                             int A16MVCliOrigen ,
                                             string A31MVADLRef1 ,
                                             string A1370MVSts ,
                                             int A21MvAlm ,
                                             int AV9AlmCod ,
                                             short A1158LinStk )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T5.[MvAlm], T4.[LinStk], T5.[MVSts], T1.[MVADLRef1], T5.[MVCliOrigen], T5.[MvAMov] AS MvAMov, T5.[MVCliCod] AS MVCliCod, T1.[ProdCod], T2.[LinCod], T2.[ProdDsc], T3.[UniAbr], T5.[MvARef], T5.[DocNum], T5.[MvAOcom], T1.[MVADLCant], T1.[MvATip], T6.[MovDsc] AS MvAMovDsc, T5.[MvAFec], T1.[MvACod], T1.[MvADItem] FROM ((((([AGUIASDETLOTE] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T2.[LinCod]) INNER JOIN [AGUIAS] T5 ON T5.[MvATip] = T1.[MvATip] AND T5.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T6 ON T6.[MovCod] = T5.[MvAMov])";
         AddWhere(sWhereString, "(T5.[MVSts] <> 'A')");
         AddWhere(sWhereString, "(T5.[MvAlm] = @AV9AlmCod)");
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         if ( ! (0==AV8LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV8LinCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV10Prodcod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40CliCod)) )
         {
            AddWhere(sWhereString, "(T5.[MVCliCod] = @AV40CliCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV42MovCod) )
         {
            AddWhere(sWhereString, "(T5.[MvAMov] = @AV42MovCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV39MVCliOrigen) )
         {
            AddWhere(sWhereString, "(T5.[MVCliOrigen] = @AV39MVCliOrigen)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43MVADLRef1)) )
         {
            AddWhere(sWhereString, "(T1.[MVADLRef1] = @AV43MVADLRef1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod]";
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
                     return conditional_P00DQ4(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (short)dynConstraints[15] );
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
          Object[] prmP00DQ2;
          prmP00DQ2 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP00DQ3;
          prmP00DQ3 = new Object[] {
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00DQ5;
          prmP00DQ5 = new Object[] {
          new ParDef("@MvATip",GXType.NChar,3,0) ,
          new ParDef("@MvACod",GXType.NChar,12,0)
          };
          Object[] prmP00DQ4;
          prmP00DQ4 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV8LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV10Prodcod",GXType.NChar,15,0) ,
          new ParDef("@AV40CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV42MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV39MVCliOrigen",GXType.Int32,6,0) ,
          new ParDef("@AV43MVADLRef1",GXType.NVarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DQ2", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV9AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DQ2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DQ3", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV10Prodcod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DQ3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DQ4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DQ4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DQ5", "SELECT T1.[MVCliCod] AS MVCliCod, T1.[MvACod], T1.[MvATip], T2.[CliDsc] AS MVCliDsc FROM ([AGUIAS] T1 LEFT JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[MVCliCod]) WHERE T1.[MvATip] = @MvATip and T1.[MvACod] = @MvACod ORDER BY T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DQ5,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 15);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 100);
                ((string[]) buf[13])[0] = rslt.getString(12, 5);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((string[]) buf[15])[0] = rslt.getString(14, 12);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                ((string[]) buf[17])[0] = rslt.getString(15, 10);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(16);
                ((string[]) buf[19])[0] = rslt.getString(17, 3);
                ((string[]) buf[20])[0] = rslt.getString(18, 100);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(19);
                ((string[]) buf[22])[0] = rslt.getString(20, 12);
                ((int[]) buf[23])[0] = rslt.getInt(21);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 12);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((string[]) buf[4])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
