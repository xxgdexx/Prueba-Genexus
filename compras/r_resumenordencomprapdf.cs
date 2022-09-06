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
namespace GeneXus.Programs.compras {
   public class r_resumenordencomprapdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_resumenordencomprapdf.aspx")), "compras.r_resumenordencomprapdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_resumenordencomprapdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "PrvCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV36PrvCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV51TprvCod = (int)(NumberUtil.Val( GetPar( "TprvCod"), "."));
                  AV28MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV17FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV18FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV35ProdCod = GetPar( "ProdCod");
                  AV26LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
                  AV29Opcion = (short)(NumberUtil.Val( GetPar( "Opcion"), "."));
                  AV10CosCod = GetPar( "CosCod");
                  AV44TipOrden = GetPar( "TipOrden");
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

      public r_resumenordencomprapdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenordencomprapdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_PrvCod ,
                           ref int aP1_TprvCod ,
                           ref int aP2_MonCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref string aP5_ProdCod ,
                           ref int aP6_LinCod ,
                           ref short aP7_Opcion ,
                           ref string aP8_CosCod ,
                           ref string aP9_TipOrden )
      {
         this.AV36PrvCod = aP0_PrvCod;
         this.AV51TprvCod = aP1_TprvCod;
         this.AV28MonCod = aP2_MonCod;
         this.AV17FDesde = aP3_FDesde;
         this.AV18FHasta = aP4_FHasta;
         this.AV35ProdCod = aP5_ProdCod;
         this.AV26LinCod = aP6_LinCod;
         this.AV29Opcion = aP7_Opcion;
         this.AV10CosCod = aP8_CosCod;
         this.AV44TipOrden = aP9_TipOrden;
         initialize();
         executePrivate();
         aP0_PrvCod=this.AV36PrvCod;
         aP1_TprvCod=this.AV51TprvCod;
         aP2_MonCod=this.AV28MonCod;
         aP3_FDesde=this.AV17FDesde;
         aP4_FHasta=this.AV18FHasta;
         aP5_ProdCod=this.AV35ProdCod;
         aP6_LinCod=this.AV26LinCod;
         aP7_Opcion=this.AV29Opcion;
         aP8_CosCod=this.AV10CosCod;
         aP9_TipOrden=this.AV44TipOrden;
      }

      public string executeUdp( ref string aP0_PrvCod ,
                                ref int aP1_TprvCod ,
                                ref int aP2_MonCod ,
                                ref DateTime aP3_FDesde ,
                                ref DateTime aP4_FHasta ,
                                ref string aP5_ProdCod ,
                                ref int aP6_LinCod ,
                                ref short aP7_Opcion ,
                                ref string aP8_CosCod )
      {
         execute(ref aP0_PrvCod, ref aP1_TprvCod, ref aP2_MonCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_ProdCod, ref aP6_LinCod, ref aP7_Opcion, ref aP8_CosCod, ref aP9_TipOrden);
         return AV44TipOrden ;
      }

      public void executeSubmit( ref string aP0_PrvCod ,
                                 ref int aP1_TprvCod ,
                                 ref int aP2_MonCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref string aP5_ProdCod ,
                                 ref int aP6_LinCod ,
                                 ref short aP7_Opcion ,
                                 ref string aP8_CosCod ,
                                 ref string aP9_TipOrden )
      {
         r_resumenordencomprapdf objr_resumenordencomprapdf;
         objr_resumenordencomprapdf = new r_resumenordencomprapdf();
         objr_resumenordencomprapdf.AV36PrvCod = aP0_PrvCod;
         objr_resumenordencomprapdf.AV51TprvCod = aP1_TprvCod;
         objr_resumenordencomprapdf.AV28MonCod = aP2_MonCod;
         objr_resumenordencomprapdf.AV17FDesde = aP3_FDesde;
         objr_resumenordencomprapdf.AV18FHasta = aP4_FHasta;
         objr_resumenordencomprapdf.AV35ProdCod = aP5_ProdCod;
         objr_resumenordencomprapdf.AV26LinCod = aP6_LinCod;
         objr_resumenordencomprapdf.AV29Opcion = aP7_Opcion;
         objr_resumenordencomprapdf.AV10CosCod = aP8_CosCod;
         objr_resumenordencomprapdf.AV44TipOrden = aP9_TipOrden;
         objr_resumenordencomprapdf.context.SetSubmitInitialConfig(context);
         objr_resumenordencomprapdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenordencomprapdf);
         aP0_PrvCod=this.AV36PrvCod;
         aP1_TprvCod=this.AV51TprvCod;
         aP2_MonCod=this.AV28MonCod;
         aP3_FDesde=this.AV17FDesde;
         aP4_FHasta=this.AV18FHasta;
         aP5_ProdCod=this.AV35ProdCod;
         aP6_LinCod=this.AV26LinCod;
         aP7_Opcion=this.AV29Opcion;
         aP8_CosCod=this.AV10CosCod;
         aP9_TipOrden=this.AV44TipOrden;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenordencomprapdf)stateInfo).executePrivate();
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
            AV13Empresa = AV41Session.Get("Empresa");
            AV12EmpDir = AV41Session.Get("EmpDir");
            AV14EmpRUC = AV41Session.Get("EmpRUC");
            AV39Ruta = AV41Session.Get("RUTA") + "/Logo.jpg";
            AV27Logo = AV39Ruta;
            AV55Logo_GXI = GXDbFile.PathToUrl( AV39Ruta);
            AV19Filtro1 = "Todos";
            AV20Filtro2 = "Todos";
            AV21Filtro3 = "Todos";
            AV22Filtro4 = AV17FDesde;
            AV23Filtro5 = AV18FHasta;
            /* Using cursor P007R2 */
            pr_default.execute(0, new Object[] {AV36PrvCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A244PrvCod = P007R2_A244PrvCod[0];
               A247PrvDsc = P007R2_A247PrvDsc[0];
               AV19Filtro1 = A247PrvDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P007R3 */
            pr_default.execute(1, new Object[] {AV28MonCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A180MonCod = P007R3_A180MonCod[0];
               A1234MonDsc = P007R3_A1234MonDsc[0];
               AV20Filtro2 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV21Filtro3 = ((AV29Opcion==1) ? "Pendientes" : "Todos");
            AV52TipoOrdenes = ((StringUtil.StrCmp(AV44TipOrden, "O")==0) ? "Compra" : ((StringUtil.StrCmp(AV44TipOrden, "S")==0) ? "Servicio" : "(Todos)"));
            AV45TotGImporte = 0.00m;
            AV46TotGPagos = 0.00m;
            AV47TotGSaldo = 0.00m;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV36PrvCod ,
                                                 AV51TprvCod ,
                                                 AV28MonCod ,
                                                 AV35ProdCod ,
                                                 AV26LinCod ,
                                                 AV10CosCod ,
                                                 AV29Opcion ,
                                                 A244PrvCod ,
                                                 A298TprvCod ,
                                                 A290OrdMonCod ,
                                                 A28ProdCod ,
                                                 A52LinCod ,
                                                 A291OrdCosCod ,
                                                 A1462OrdSts ,
                                                 A293OrdFec ,
                                                 AV17FDesde ,
                                                 AV18FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE
                                                 }
            });
            /* Using cursor P007R4 */
            pr_default.execute(2, new Object[] {AV17FDesde, AV18FHasta, AV36PrvCod, AV51TprvCod, AV28MonCod, AV35ProdCod, AV26LinCod, AV10CosCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               BRK7R5 = false;
               A49UniCod = P007R4_A49UniCod[0];
               A244PrvCod = P007R4_A244PrvCod[0];
               A1431OrdDCan = P007R4_A1431OrdDCan[0];
               A1434OrdDCanIng = P007R4_A1434OrdDCanIng[0];
               A1432OrdDCanFac = P007R4_A1432OrdDCanFac[0];
               A1997UniAbr = P007R4_A1997UniAbr[0];
               A55ProdDsc = P007R4_A55ProdDsc[0];
               A28ProdCod = P007R4_A28ProdCod[0];
               A293OrdFec = P007R4_A293OrdFec[0];
               A289OrdCod = P007R4_A289OrdCod[0];
               A1462OrdSts = P007R4_A1462OrdSts[0];
               A291OrdCosCod = P007R4_A291OrdCosCod[0];
               n291OrdCosCod = P007R4_n291OrdCosCod[0];
               A52LinCod = P007R4_A52LinCod[0];
               A290OrdMonCod = P007R4_A290OrdMonCod[0];
               A298TprvCod = P007R4_A298TprvCod[0];
               A247PrvDsc = P007R4_A247PrvDsc[0];
               A295OrdDItem = P007R4_A295OrdDItem[0];
               A49UniCod = P007R4_A49UniCod[0];
               A55ProdDsc = P007R4_A55ProdDsc[0];
               A52LinCod = P007R4_A52LinCod[0];
               A1997UniAbr = P007R4_A1997UniAbr[0];
               A244PrvCod = P007R4_A244PrvCod[0];
               A293OrdFec = P007R4_A293OrdFec[0];
               A1462OrdSts = P007R4_A1462OrdSts[0];
               A291OrdCosCod = P007R4_A291OrdCosCod[0];
               n291OrdCosCod = P007R4_n291OrdCosCod[0];
               A290OrdMonCod = P007R4_A290OrdMonCod[0];
               A298TprvCod = P007R4_A298TprvCod[0];
               A247PrvDsc = P007R4_A247PrvDsc[0];
               AV37PrvCod2 = A244PrvCod;
               AV38PrvDsc2 = A247PrvDsc;
               AV30OrdCod = A289OrdCod;
               H7R0( false, 21) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A247PrvDsc, "")), 8, Gx_line+4, 612, Gx_line+19, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
               AV32PedDCan = 0.00m;
               AV33PedDCanDsp = 0.00m;
               AV34PedDCanFac = 0.00m;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P007R4_A244PrvCod[0], A244PrvCod) == 0 ) )
               {
                  BRK7R5 = false;
                  A49UniCod = P007R4_A49UniCod[0];
                  A1431OrdDCan = P007R4_A1431OrdDCan[0];
                  A1434OrdDCanIng = P007R4_A1434OrdDCanIng[0];
                  A1432OrdDCanFac = P007R4_A1432OrdDCanFac[0];
                  A1997UniAbr = P007R4_A1997UniAbr[0];
                  A55ProdDsc = P007R4_A55ProdDsc[0];
                  A28ProdCod = P007R4_A28ProdCod[0];
                  A293OrdFec = P007R4_A293OrdFec[0];
                  A289OrdCod = P007R4_A289OrdCod[0];
                  A295OrdDItem = P007R4_A295OrdDItem[0];
                  A49UniCod = P007R4_A49UniCod[0];
                  A55ProdDsc = P007R4_A55ProdDsc[0];
                  A1997UniAbr = P007R4_A1997UniAbr[0];
                  A293OrdFec = P007R4_A293OrdFec[0];
                  AV32PedDCan = (decimal)(AV32PedDCan+A1431OrdDCan);
                  AV33PedDCanDsp = (decimal)(AV33PedDCanDsp+A1434OrdDCanIng);
                  AV34PedDCanFac = (decimal)(AV34PedDCanFac+A1432OrdDCanFac);
                  H7R0( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A289OrdCod, "")), 5, Gx_line+2, 79, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A293OrdFec, "99/99/99"), 74, Gx_line+1, 133, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 136, Gx_line+1, 224, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 244, Gx_line+1, 482, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1432OrdDCanFac, "ZZZZ,ZZZ,ZZ9.9999")), 684, Gx_line+1, 789, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1434OrdDCanIng, "ZZZZ,ZZZ,ZZ9.9999")), 597, Gx_line+1, 702, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1431OrdDCan, "ZZZZ,ZZZ,ZZ9.9999")), 515, Gx_line+1, 612, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 485, Gx_line+1, 529, Gx_line+16, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
                  BRK7R5 = true;
                  pr_default.readNext(2);
               }
               H7R0( false, 24) ;
               getPrinter().GxDrawLine(466, Gx_line+1, 788, Gx_line+1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Proveedor", 331, Gx_line+5, 427, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34PedDCanFac, "ZZZZ,ZZZ,ZZ9.9999")), 684, Gx_line+6, 789, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33PedDCanDsp, "ZZZZ,ZZZ,ZZ9.9999")), 597, Gx_line+6, 702, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32PedDCan, "ZZZZ,ZZZ,ZZ9.9999")), 515, Gx_line+6, 612, Gx_line+21, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
               if ( ! BRK7R5 )
               {
                  BRK7R5 = true;
                  pr_default.readNext(2);
               }
            }
            pr_default.close(2);
            H7R0( false, 28) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+28);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7R0( true, 0) ;
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

      protected void H7R0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 664, Gx_line+45, 696, Gx_line+59, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 664, Gx_line+63, 708, Gx_line+77, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 664, Gx_line+27, 703, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 731, Gx_line+63, 770, Gx_line+78, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 708, Gx_line+45, 768, Gx_line+59, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 723, Gx_line+27, 770, Gx_line+42, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("O.Compra", 13, Gx_line+235, 71, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 88, Gx_line+235, 123, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Unidad", 486, Gx_line+235, 528, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+214, 797, Gx_line+254, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Ordenes de Compra", 268, Gx_line+52, 545, Gx_line+72, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 152, Gx_line+235, 193, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 266, Gx_line+235, 320, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Facturada", 718, Gx_line+235, 778, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Atendida", 628, Gx_line+235, 682, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 186, Gx_line+108, 248, Gx_line+122, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 186, Gx_line+130, 234, Gx_line+144, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo", 186, Gx_line+152, 212, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde", 186, Gx_line+174, 223, Gx_line+188, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta", 186, Gx_line+195, 221, Gx_line+209, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Filtro1, "")), 253, Gx_line+103, 596, Gx_line+127, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20Filtro2, "")), 253, Gx_line+125, 596, Gx_line+149, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21Filtro3, "")), 253, Gx_line+147, 596, Gx_line+171, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV22Filtro4, "99/99/99"), 253, Gx_line+169, 596, Gx_line+193, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV23Filtro5, "99/99/99"), 253, Gx_line+190, 596, Gx_line+214, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Pedida", 553, Gx_line+235, 594, Gx_line+249, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(548, Gx_line+233, 789, Gx_line+233, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 635, Gx_line+216, 688, Gx_line+230, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV27Logo)) ? AV55Logo_GXI : AV27Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 11, Gx_line+2, 166, Gx_line+78) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Empresa, "")), 11, Gx_line+73, 240, Gx_line+91, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14EmpRUC, "")), 11, Gx_line+91, 185, Gx_line+109, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TipoOrdenes, "")), 315, Gx_line+76, 496, Gx_line+100, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+254);
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
         AV13Empresa = "";
         AV41Session = context.GetSession();
         AV12EmpDir = "";
         AV14EmpRUC = "";
         AV39Ruta = "";
         AV27Logo = "";
         AV55Logo_GXI = "";
         AV19Filtro1 = "";
         AV20Filtro2 = "";
         AV21Filtro3 = "";
         AV22Filtro4 = DateTime.MinValue;
         AV23Filtro5 = DateTime.MinValue;
         scmdbuf = "";
         P007R2_A244PrvCod = new string[] {""} ;
         P007R2_A247PrvDsc = new string[] {""} ;
         A244PrvCod = "";
         A247PrvDsc = "";
         P007R3_A180MonCod = new int[1] ;
         P007R3_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV52TipoOrdenes = "";
         A28ProdCod = "";
         A291OrdCosCod = "";
         A1462OrdSts = "";
         A293OrdFec = DateTime.MinValue;
         P007R4_A49UniCod = new int[1] ;
         P007R4_A244PrvCod = new string[] {""} ;
         P007R4_A1431OrdDCan = new decimal[1] ;
         P007R4_A1434OrdDCanIng = new decimal[1] ;
         P007R4_A1432OrdDCanFac = new decimal[1] ;
         P007R4_A1997UniAbr = new string[] {""} ;
         P007R4_A55ProdDsc = new string[] {""} ;
         P007R4_A28ProdCod = new string[] {""} ;
         P007R4_A293OrdFec = new DateTime[] {DateTime.MinValue} ;
         P007R4_A289OrdCod = new string[] {""} ;
         P007R4_A1462OrdSts = new string[] {""} ;
         P007R4_A291OrdCosCod = new string[] {""} ;
         P007R4_n291OrdCosCod = new bool[] {false} ;
         P007R4_A52LinCod = new int[1] ;
         P007R4_A290OrdMonCod = new int[1] ;
         P007R4_A298TprvCod = new int[1] ;
         P007R4_A247PrvDsc = new string[] {""} ;
         P007R4_A295OrdDItem = new int[1] ;
         A1997UniAbr = "";
         A55ProdDsc = "";
         A289OrdCod = "";
         AV37PrvCod2 = "";
         AV38PrvDsc2 = "";
         AV30OrdCod = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV27Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_resumenordencomprapdf__default(),
            new Object[][] {
                new Object[] {
               P007R2_A244PrvCod, P007R2_A247PrvDsc
               }
               , new Object[] {
               P007R3_A180MonCod, P007R3_A1234MonDsc
               }
               , new Object[] {
               P007R4_A49UniCod, P007R4_A244PrvCod, P007R4_A1431OrdDCan, P007R4_A1434OrdDCanIng, P007R4_A1432OrdDCanFac, P007R4_A1997UniAbr, P007R4_A55ProdDsc, P007R4_A28ProdCod, P007R4_A293OrdFec, P007R4_A289OrdCod,
               P007R4_A1462OrdSts, P007R4_A291OrdCosCod, P007R4_n291OrdCosCod, P007R4_A52LinCod, P007R4_A290OrdMonCod, P007R4_A298TprvCod, P007R4_A247PrvDsc, P007R4_A295OrdDItem
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
      private short AV29Opcion ;
      private int AV51TprvCod ;
      private int AV28MonCod ;
      private int AV26LinCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int A298TprvCod ;
      private int A290OrdMonCod ;
      private int A52LinCod ;
      private int A49UniCod ;
      private int A295OrdDItem ;
      private int Gx_OldLine ;
      private decimal AV45TotGImporte ;
      private decimal AV46TotGPagos ;
      private decimal AV47TotGSaldo ;
      private decimal A1431OrdDCan ;
      private decimal A1434OrdDCanIng ;
      private decimal A1432OrdDCanFac ;
      private decimal AV32PedDCan ;
      private decimal AV33PedDCanDsp ;
      private decimal AV34PedDCanFac ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV36PrvCod ;
      private string AV35ProdCod ;
      private string AV10CosCod ;
      private string AV13Empresa ;
      private string AV12EmpDir ;
      private string AV14EmpRUC ;
      private string AV39Ruta ;
      private string AV19Filtro1 ;
      private string AV20Filtro2 ;
      private string AV21Filtro3 ;
      private string scmdbuf ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A1234MonDsc ;
      private string A28ProdCod ;
      private string A291OrdCosCod ;
      private string A1462OrdSts ;
      private string A1997UniAbr ;
      private string A55ProdDsc ;
      private string A289OrdCod ;
      private string AV37PrvCod2 ;
      private string AV38PrvDsc2 ;
      private string AV30OrdCod ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV17FDesde ;
      private DateTime AV18FHasta ;
      private DateTime AV22Filtro4 ;
      private DateTime AV23Filtro5 ;
      private DateTime A293OrdFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK7R5 ;
      private bool n291OrdCosCod ;
      private string AV44TipOrden ;
      private string AV55Logo_GXI ;
      private string AV52TipoOrdenes ;
      private string AV27Logo ;
      private string Logo ;
      private IGxSession AV41Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_PrvCod ;
      private int aP1_TprvCod ;
      private int aP2_MonCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private string aP5_ProdCod ;
      private int aP6_LinCod ;
      private short aP7_Opcion ;
      private string aP8_CosCod ;
      private string aP9_TipOrden ;
      private IDataStoreProvider pr_default ;
      private string[] P007R2_A244PrvCod ;
      private string[] P007R2_A247PrvDsc ;
      private int[] P007R3_A180MonCod ;
      private string[] P007R3_A1234MonDsc ;
      private int[] P007R4_A49UniCod ;
      private string[] P007R4_A244PrvCod ;
      private decimal[] P007R4_A1431OrdDCan ;
      private decimal[] P007R4_A1434OrdDCanIng ;
      private decimal[] P007R4_A1432OrdDCanFac ;
      private string[] P007R4_A1997UniAbr ;
      private string[] P007R4_A55ProdDsc ;
      private string[] P007R4_A28ProdCod ;
      private DateTime[] P007R4_A293OrdFec ;
      private string[] P007R4_A289OrdCod ;
      private string[] P007R4_A1462OrdSts ;
      private string[] P007R4_A291OrdCosCod ;
      private bool[] P007R4_n291OrdCosCod ;
      private int[] P007R4_A52LinCod ;
      private int[] P007R4_A290OrdMonCod ;
      private int[] P007R4_A298TprvCod ;
      private string[] P007R4_A247PrvDsc ;
      private int[] P007R4_A295OrdDItem ;
   }

   public class r_resumenordencomprapdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007R4( IGxContext context ,
                                             string AV36PrvCod ,
                                             int AV51TprvCod ,
                                             int AV28MonCod ,
                                             string AV35ProdCod ,
                                             int AV26LinCod ,
                                             string AV10CosCod ,
                                             short AV29Opcion ,
                                             string A244PrvCod ,
                                             int A298TprvCod ,
                                             int A290OrdMonCod ,
                                             string A28ProdCod ,
                                             int A52LinCod ,
                                             string A291OrdCosCod ,
                                             string A1462OrdSts ,
                                             DateTime A293OrdFec ,
                                             DateTime AV17FDesde ,
                                             DateTime AV18FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T4.[PrvCod], T1.[OrdDCan], T1.[OrdDCanIng], T1.[OrdDCanFac], T3.[UniAbr], T2.[ProdDsc], T1.[ProdCod], T4.[OrdFec], T1.[OrdCod], T4.[OrdSts], T4.[OrdCosCod], T2.[LinCod], T4.[OrdMonCod], T5.[TprvCod], T5.[PrvDsc], T1.[OrdDItem] FROM (((([CPORDENDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CPORDEN] T4 ON T4.[OrdCod] = T1.[OrdCod]) INNER JOIN [CPPROVEEDORES] T5 ON T5.[PrvCod] = T4.[PrvCod])";
         AddWhere(sWhereString, "(T4.[OrdFec] >= @AV17FDesde and T4.[OrdFec] <= @AV18FHasta)");
         AddWhere(sWhereString, "(T4.[OrdSts] <> 'A')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36PrvCod)) )
         {
            AddWhere(sWhereString, "(T4.[PrvCod] = @AV36PrvCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV51TprvCod) )
         {
            AddWhere(sWhereString, "(T5.[TprvCod] = @AV51TprvCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV28MonCod) )
         {
            AddWhere(sWhereString, "(T4.[OrdMonCod] = @AV28MonCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV35ProdCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV26LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV26LinCod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CosCod)) )
         {
            AddWhere(sWhereString, "(T4.[OrdCosCod] = @AV10CosCod)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV29Opcion == 1 )
         {
            AddWhere(sWhereString, "(T4.[OrdSts] <> 'T')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T4.[PrvCod]";
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
                     return conditional_P007R4(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007R2;
          prmP007R2 = new Object[] {
          new ParDef("@AV36PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP007R3;
          prmP007R3 = new Object[] {
          new ParDef("@AV28MonCod",GXType.Int32,6,0)
          };
          Object[] prmP007R4;
          prmP007R4 = new Object[] {
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV18FHasta",GXType.Date,8,0) ,
          new ParDef("@AV36PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV51TprvCod",GXType.Int32,6,0) ,
          new ParDef("@AV28MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV35ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV26LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV10CosCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007R2", "SELECT [PrvCod], [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @AV36PrvCod ORDER BY [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007R2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007R3", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV28MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007R3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007R4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007R4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 5);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 15);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 10);
                ((string[]) buf[10])[0] = rslt.getString(11, 1);
                ((string[]) buf[11])[0] = rslt.getString(12, 10);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                ((int[]) buf[13])[0] = rslt.getInt(13);
                ((int[]) buf[14])[0] = rslt.getInt(14);
                ((int[]) buf[15])[0] = rslt.getInt(15);
                ((string[]) buf[16])[0] = rslt.getString(16, 100);
                ((int[]) buf[17])[0] = rslt.getInt(17);
                return;
       }
    }

 }

}
